<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "32c9a4263be08f9050c8044bb26267c4",
  "translation_date": "2025-06-17T16:52:03+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/apimoauth.md",
  "language_code": "uk"
}
-->
# Розгортання Spring AI MCP додатку в Azure Container Apps

 ([Захист серверів Spring AI MCP за допомогою OAuth2](https://spring.io/blog/2025/04/02/mcp-server-oauth2)) *Ілюстрація: Сервер Spring AI MCP захищений Spring Authorization Server. Сервер видає клієнтам токени доступу та перевіряє їх при вхідних запитах (джерело: Spring blog) ([Захист серверів Spring AI MCP за допомогою OAuth2](https://spring.io/blog/2025/04/02/mcp-server-oauth2#:~:text=,server%20with%20the%20MCP%20inspector)).* Для розгортання сервера Spring MCP зберіть його у контейнер і використовуйте Azure Container Apps з зовнішнім ingress. Наприклад, за допомогою Azure CLI можна виконати:

```bash
az containerapp up \
  --name my-mcp-app \
  --resource-group MyResourceGroup \
  --location eastus \
  --environment MyContainerEnv \
  --image myregistry.azurecr.io/my-mcp-server:latest \
  --ingress external \
  --target-port 8080 \
  --query properties.configuration.ingress.fqdn
```

Це створює загальнодоступний Container App з увімкненим HTTPS (Azure видає безкоштовний TLS-сертифікат для стандартного `*.azurecontainerapps.io` domain ([Custom domain names and free managed certificates in Azure Container Apps | Microsoft Learn](https://learn.microsoft.com/en-us/azure/container-apps/custom-domains-managed-certificates#:~:text=Free%20certificate%20requirements))). The command output includes the app’s FQDN (e.g. `my-mcp-app.eastus.azurecontainerapps.io`), which becomes the **issuer URL** base. Ensure HTTP ingress is enabled (as above) so APIM can reach the app. In a test/dev setup, use the `--ingress external` option (or bind a custom domain with TLS per [Microsoft docs](https://learn.microsoft.com/azure/container-apps/custom-domains-managed-certificates) ([Custom domain names and free managed certificates in Azure Container Apps | Microsoft Learn](https://learn.microsoft.com/en-us/azure/container-apps/custom-domains-managed-certificates#:~:text=Free%20certificate%20requirements))). Store any sensitive properties (like OAuth client secrets) in Container Apps secrets or Azure Key Vault, and map them into the container as environment variables. 

## Configuring Spring Authorization Server

In your Spring Boot app’s code, include the Spring Authorization Server and Resource Server starters. Configure a `RegisteredClient` (for the `client_credentials` grant in dev/test) and a JWT key source. For example, in `application.properties`, ви можете налаштувати:

```properties
# OAuth2 client (for testing token issuance)
spring.security.oauth2.authorizationserver.client.oidc-client.registration.client-id=mcp-client
spring.security.oauth2.authorizationserver.client.oidc-client.registration.client-secret={noop}secret
spring.security.oauth2.authorizationserver.client.oidc-client.registration.authorization-grant-types=client_credentials
spring.security.oauth2.authorizationserver.client.oidc-client.registration.client-authentication-methods=client_secret_basic
```

Увімкніть Authorization Server і Resource Server, визначивши ланцюг фільтрів безпеки. Наприклад:

```java
@Configuration
@EnableWebSecurity
public class SecurityConfiguration {

    @Bean
    SecurityFilterChain securityFilterChain(HttpSecurity http) throws Exception {
        OAuth2AuthorizationServerConfigurer<HttpSecurity> authzServer = OAuth2AuthorizationServerConfigurer.authorizationServer();
        http
            .authorizeHttpRequests(auth -> auth.anyRequest().authenticated())
            // Enable the Authorization Server endpoints
            .apply(authzServer.and())
            // Enable the Resource Server (validate JWT on incoming requests)
            .oauth2ResourceServer(oauth2 -> oauth2.jwt(withDefaults()))
            // Disable CSRF (MCP server is not browser-based)
            .csrf(csrf -> csrf.disable())
            // Allow CORS for client demo tools
            .cors(withDefaults());
        return http.build();
    }

    // Define an in-memory client (RegisteredClient) and a JWK source:
    @Bean
    public RegisteredClientRepository registeredClientRepository() {
        RegisteredClient client = RegisteredClient.withId("1")
            .clientId("mcp-client")
            .clientSecret("{noop}secret")
            .authorizationGrantType(AuthorizationGrantType.CLIENT_CREDENTIALS)
            .scope("mcp.read")
            .clientSettings(ClientSettings.builder().build())
            .tokenSettings(TokenSettings.builder().build())
            .build();
        return new InMemoryRegisteredClientRepository(client);
    }

    @Bean
    public JWKSource<SecurityContext> jwkSource() {
        // Generate an RSA key (for dev/test, generate anew at startup)
        RSAKey rsaKey = new RSAKeyGenerator(2048).keyID("1").generate();
        JWKSet jwkSet = new JWKSet(rsaKey);
        return (selector, context) -> selector.select(jwkSet);
    }
}
```

Ця конфігурація відкриє стандартні OAuth2 кінцеві точки: `/oauth2/token` for tokens and `/oauth2/jwks` for the JSON Web Key Set. (By default Spring’s `AuthorizationServerSettings` maps `/oauth2/token` and `/oauth2/jwks` ([Configuration Model :: Spring Authorization Server](https://docs.spring.io/spring-authorization-server/reference/configuration-model.html#:~:text=public%20static%20Builder%20builder%28%29%20,oauth2%2Fauthorize)).) The server will issue JWT access tokens signed by the RSA key above, and publish its public key at `https://<your-app>:/oauth2/jwks`. 

**Enable OpenID Connect discovery:** To let APIM automatically retrieve the issuer and JWKS, enable the OIDC provider configuration endpoint by adding `.oidc(Customizer.withDefaults())` у вашій конфігурації безпеки ([Configuration Model :: Spring Authorization Server](https://docs.spring.io/spring-authorization-server/reference/configuration-model.html#:~:text=.securityMatcher%28authorizationServerConfigurer.getEndpointsMatcher%28%29%29%20.with%28authorizationServerConfigurer%2C%20%28authorizationServer%29%20,%29%3B%20return%20http.build)). Наприклад:

```java
http
  .apply(authzServer.and())
  .securityMatcher(authzServer.getEndpointsMatcher())
  .with(authzServer, authz -> authz
      .oidc(Customizer.withDefaults()));  // <– enables /.well-known/openid-configuration
```

Це відкриває `/.well-known/openid-configuration`, which APIM can use for metadata. Finally, you may want to customize the JWT **audience** claim so that APIM’s `<audiences>` перевірка пройде успішно. Наприклад, додайте кастомізатор токена:

```java
@Bean
public OAuth2TokenCustomizer<OAuth2TokenClaimsContext> tokenCustomizer() {
    return context -> {
        // Set a custom audience (e.g. the client ID or API identifier)
        context.getClaims().audience(Collections.singletonList("mcp-client"));
    };
}
```

Це гарантує, що токени містять `"aud": ["mcp-client"]`, matching the client ID or scope expected by APIM. 

## Exposing Token and JWKS Endpoints

After deploying, your app’s **issuer URL** will be `https://<app-fqdn>`, e.g. `https://my-mcp-app.eastus.azurecontainerapps.io`. Its OAuth2 endpoints are:

- **Token endpoint:** `https://<app-fqdn>/oauth2/token` – clients obtain tokens here (client_credentials flow).
- **JWKS endpoint:** `https://<app-fqdn>/oauth2/jwks` – returns the JWK set (used by APIM to get signing keys).
- **OpenID Config:** `https://<app-fqdn>/.well-known/openid-configuration` – OIDC discovery JSON (contains `issuer`, `token_endpoint`, `jwks_uri`, etc.).  

APIM will point to the **OpenID configuration URL**, from which it discovers the `jwks_uri`. For example, if your Container App FQDN is `my-mcp-app.eastus.azurecontainerapps.io`, then APIM’s `<openid-config url="...">` should use `https://my-mcp-app.eastus.azurecontainerapps.io/.well-known/openid-configuration`. (By default Spring will set the `issuer` in that metadata to the same base URL ([Configuration Model :: Spring Authorization Server](https://docs.spring.io/spring-authorization-server/reference/configuration-model.html#:~:text=public%20static%20Builder%20builder%28%29%20,oauth2%2Fauthorize)).)

## Configuring Azure API Management (`validate-jwt`)

In Azure APIM, add an inbound policy that uses the `<validate-jwt>` політику для перевірки вхідних JWT проти вашого Spring Authorization Server. Для простої налаштування можна використати URL метаданих OpenID Connect. Приклад фрагменту політики:

```xml
<inbound>
  <validate-jwt header-name="Authorization" require-scheme="Bearer">
    <openid-config url="https://my-mcp-app.eastus.azurecontainerapps.io/.well-known/openid-configuration" />
    <audiences>
      <audience>mcp-client</audience>  <!-- Expected audience in the JWT -->
    </audiences>
    <issuers>
      <issuer>https://my-mcp-app.eastus.azurecontainerapps.io</issuer>
    </issuers>
  </validate-jwt>
  <!-- (optional) other policies -->
</inbound>
```

Ця політика вказує APIM отримати OpenID конфігурацію з Spring Auth Server, завантажити його JWKS і перевірити, що кожен токен підписаний довіреним ключем і має правильну аудиторію. (Якщо пропустити `<issuers>`, APIM will use the `issuer` claim from the metadata automatically.) The `<audience>` should match your client ID or API resource identifier in the token (in the example above, we set it to `"mcp-client"`). This is consistent with Microsoft’s documentation on using `validate-jwt` with `<openid-config>` ([Azure API Management policy reference - validate-jwt | Microsoft Learn](https://learn.microsoft.com/en-us/azure/api-management/validate-jwt-policy#:~:text=Microsoft%20Entra%20ID%20single%20tenant,token%20validation)).

After validation, APIM will forward the request (including the original `Authorization` header) to the backend. Since the Spring app is also a resource server, it will re-validate the token, but APIM has already ensured its validity. (For development, you can rely on APIM’s check and disable additional checks in the app if desired, but it’s safer to keep both.)

## Example Settings

| Setting            | Example Value                                                        | Notes                                      |
|--------------------|----------------------------------------------------------------------|--------------------------------------------|
| **Issuer**         | `https://my-mcp-app.eastus.azurecontainerapps.io`                    | Your Container App’s URL (base URI)        |
| **Token endpoint** | `https://my-mcp-app.eastus.azurecontainerapps.io/oauth2/token`       | Default Spring token endpoint ([Configuration Model :: Spring Authorization Server](https://docs.spring.io/spring-authorization-server/reference/configuration-model.html#:~:text=public%20static%20Builder%20builder%28%29%20,oauth2%2Fauthorize))  |
| **JWKS endpoint**  | `https://my-mcp-app.eastus.azurecontainerapps.io/oauth2/jwks`        | Default JWK Set endpoint ([Configuration Model :: Spring Authorization Server](https://docs.spring.io/spring-authorization-server/reference/configuration-model.html#:~:text=public%20static%20Builder%20builder%28%29%20,oauth2%2Fauthorize))    |
| **OpenID Config**  | `https://my-mcp-app.eastus.azurecontainerapps.io/.well-known/openid-configuration` | OIDC discovery document (auto-generated)    |
| **APIM audience**  | `mcp-client`                                                         | OAuth client ID or API resource name       |
| **APIM policy**    | `<openid-config url="https://.../.well-known/openid-configuration" />` | `<validate-jwt>` uses this URL ([Azure API Management policy reference - validate-jwt | Microsoft Learn](https://learn.microsoft.com/en-us/azure/api-management/validate-jwt-policy#:~:text=Microsoft%20Entra%20ID%20single%20tenant,token%20validation)) |

## Common Pitfalls

- **HTTPS/TLS:** The APIM gateway requires that the OpenID/JWKS endpoint be HTTPS with a valid certificate. By default, Azure Container Apps provides a trusted TLS cert for the Azure-managed domain ([Custom domain names and free managed certificates in Azure Container Apps | Microsoft Learn](https://learn.microsoft.com/en-us/azure/container-apps/custom-domains-managed-certificates#:~:text=Free%20certificate%20requirements)). If you use a custom domain, be sure to bind a certificate (you can use Azure’s free managed cert feature) ([Custom domain names and free managed certificates in Azure Container Apps | Microsoft Learn](https://learn.microsoft.com/en-us/azure/container-apps/custom-domains-managed-certificates#:~:text=Free%20certificate%20requirements)). If APIM cannot trust the endpoint’s certificate, `<validate-jwt>` will fail to fetch the metadata.  

- **Endpoint Accessibility:** Ensure the Spring app’s endpoints are reachable from APIM. Using `--ingress external` (or enabling ingress in the portal) is simplest. If you chose an internal or vNet-bound environment, APIM (by default public) might not reach it unless placed in the same VNet. In a test setup, prefer public ingress so APIM can call the `.well-known` and `/jwks` URLs. 

- **OpenID Discovery Enabled:** By default, Spring Authorization Server **does not expose** the `/.well-known/openid-configuration` unless OIDC is enabled. Make sure to include `.oidc(Customizer.withDefaults())` in your security config (see above) so that the provider configuration endpoint is active ([Configuration Model :: Spring Authorization Server](https://docs.spring.io/spring-authorization-server/reference/configuration-model.html#:~:text=.securityMatcher%28authorizationServerConfigurer.getEndpointsMatcher%28%29%29%20.with%28authorizationServerConfigurer%2C%20%28authorizationServer%29%20,%29%3B%20return%20http.build)). Otherwise APIM’s `<openid-config>` call will 404.

- **Audience Claim:** Spring’s default behavior is to set the `aud` claim to the client ID. If APIM’s `<audience>` check fails, you may need to customize the token (as shown above) or adjust the APIM policy. Ensure the audience in your JWT matches what you configure in `<audience>`. 

- **JSON Metadata Parsing:** The OpenID configuration JSON must be valid. Spring’s default config will emit a standard OIDC metadata document. Verify that it contains the correct `issuer` and `jwks_uri`. If you host Spring behind a proxy or path-based route, double-check the URLs in this metadata. APIM will use these values as-is. 

- **Policy Ordering:** In the APIM policy, place `<validate-jwt>` **before** any routing to the backend. Otherwise, calls might reach your app without a valid token. Also ensure `<validate-jwt>` appears immediately under `<inbound>` (not nested inside another condition) so that APIM applies it.

By following the above steps, you can run your Spring AI MCP server in Azure Container Apps and have Azure API Management validate incoming OAuth2 JWTs with a minimal policy. The key points are: expose the Spring Auth endpoints publicly with TLS, enable OIDC discovery, and point APIM’s `validate-jwt` at the OpenID config URL (so it can fetch the JWKS automatically). This setup is suitable for a dev/test environment; for production, consider proper secret management, token lifetimes, and rotating keys in JWKS as needed. 

**References:** See Spring Authorization Server docs for default endpoints ([Configuration Model :: Spring Authorization Server](https://docs.spring.io/spring-authorization-server/reference/configuration-model.html#:~:text=public%20static%20Builder%20builder%28%29%20,oauth2%2Fauthorize)) and OIDC configuration ([Configuration Model :: Spring Authorization Server](https://docs.spring.io/spring-authorization-server/reference/configuration-model.html#:~:text=.securityMatcher%28authorizationServerConfigurer.getEndpointsMatcher%28%29%29%20.with%28authorizationServerConfigurer%2C%20%28authorizationServer%29%20,%29%3B%20return%20http.build)); see Microsoft APIM docs for `validate-jwt` приклади ([Azure API Management policy reference - validate-jwt | Microsoft Learn](https://learn.microsoft.com/en-us/azure/api-management/validate-jwt-policy#:~:text=Microsoft%20Entra%20ID%20single%20tenant,token%20validation)); а також документація Azure Container Apps щодо розгортання та сертифікатів ([Deploy Java Spring Boot apps to Azure Container Apps - Java on Azure | Microsoft Learn](https://learn.microsoft.com/en-us/azure/developer/java/identity/deploy-spring-boot-to-azure-container-apps#:~:text=Now%20you%20can%20deploy%20your,CLI%20command)) ([Custom domain names and free managed certificates in Azure Container Apps | Microsoft Learn](https://learn.microsoft.com/en-us/azure/container-apps/custom-domains-managed-certificates#:~:text=Free%20certificate%20requirements)).

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.