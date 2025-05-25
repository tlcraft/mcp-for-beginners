<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "32c9a4263be08f9050c8044bb26267c4",
  "translation_date": "2025-05-17T15:37:46+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/apimoauth.md",
  "language_code": "sr"
}
-->
# Postavljanje Spring AI MCP aplikacije na Azure Container Apps

([Osiguranje Spring AI MCP servera pomoću OAuth2](https://spring.io/blog/2025/04/02/mcp-server-oauth2)) *Slika: Spring AI MCP server osiguran Spring Authorization Serverom. Server izdaje pristupne tokene klijentima i proverava ih na dolaznim zahtevima (izvor: Spring blog) ([Osiguranje Spring AI MCP servera pomoću OAuth2](https://spring.io/blog/2025/04/02/mcp-server-oauth2#:~:text=,server%20with%20the%20MCP%20inspector)).* Da biste postavili Spring MCP server, izgradite ga kao kontejner i koristite Azure Container Apps sa spoljnim pristupom. Na primer, koristeći Azure CLI možete pokrenuti:

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

Ovo kreira javno dostupnu Container App sa omogućenom HTTPS podrškom (Azure izdaje besplatni TLS sertifikat za podrazumevani `*.azurecontainerapps.io` domain ([Custom domain names and free managed certificates in Azure Container Apps | Microsoft Learn](https://learn.microsoft.com/en-us/azure/container-apps/custom-domains-managed-certificates#:~:text=Free%20certificate%20requirements))). The command output includes the app’s FQDN (e.g. `my-mcp-app.eastus.azurecontainerapps.io`), which becomes the **issuer URL** base. Ensure HTTP ingress is enabled (as above) so APIM can reach the app. In a test/dev setup, use the `--ingress external` option (or bind a custom domain with TLS per [Microsoft docs](https://learn.microsoft.com/azure/container-apps/custom-domains-managed-certificates) ([Custom domain names and free managed certificates in Azure Container Apps | Microsoft Learn](https://learn.microsoft.com/en-us/azure/container-apps/custom-domains-managed-certificates#:~:text=Free%20certificate%20requirements))). Store any sensitive properties (like OAuth client secrets) in Container Apps secrets or Azure Key Vault, and map them into the container as environment variables. 

## Configuring Spring Authorization Server

In your Spring Boot app’s code, include the Spring Authorization Server and Resource Server starters. Configure a `RegisteredClient` (for the `client_credentials` grant in dev/test) and a JWT key source. For example, in `application.properties` možete postaviti:

```properties
# OAuth2 client (for testing token issuance)
spring.security.oauth2.authorizationserver.client.oidc-client.registration.client-id=mcp-client
spring.security.oauth2.authorizationserver.client.oidc-client.registration.client-secret={noop}secret
spring.security.oauth2.authorizationserver.client.oidc-client.registration.authorization-grant-types=client_credentials
spring.security.oauth2.authorizationserver.client.oidc-client.registration.client-authentication-methods=client_secret_basic
```

Omogućite Authorization Server i Resource Server definišući lanac sigurnosnih filtera. Na primer:

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

Ova postavka će izložiti podrazumevane OAuth2 krajnje tačke: `/oauth2/token` for tokens and `/oauth2/jwks` for the JSON Web Key Set. (By default Spring’s `AuthorizationServerSettings` maps `/oauth2/token` and `/oauth2/jwks` ([Configuration Model :: Spring Authorization Server](https://docs.spring.io/spring-authorization-server/reference/configuration-model.html#:~:text=public%20static%20Builder%20builder%28%29%20,oauth2%2Fauthorize)).) The server will issue JWT access tokens signed by the RSA key above, and publish its public key at `https://<your-app>:/oauth2/jwks`. 

**Enable OpenID Connect discovery:** To let APIM automatically retrieve the issuer and JWKS, enable the OIDC provider configuration endpoint by adding `.oidc(Customizer.withDefaults())` u vašoj sigurnosnoj konfiguraciji ([Konfiguracioni model :: Spring Authorization Server](https://docs.spring.io/spring-authorization-server/reference/configuration-model.html#:~:text=.securityMatcher%28authorizationServerConfigurer.getEndpointsMatcher%28%29%29%20.with%28authorizationServerConfigurer%2C%20%28authorizationServer%29%20,%29%3B%20return%20http.build)). Na primer:

```java
http
  .apply(authzServer.and())
  .securityMatcher(authzServer.getEndpointsMatcher())
  .with(authzServer, authz -> authz
      .oidc(Customizer.withDefaults()));  // <– enables /.well-known/openid-configuration
```

Ovo izlaže `/.well-known/openid-configuration`, which APIM can use for metadata. Finally, you may want to customize the JWT **audience** claim so that APIM’s `<audiences>` provera će proći. Na primer, dodajte prilagođivač tokena:

```java
@Bean
public OAuth2TokenCustomizer<OAuth2TokenClaimsContext> tokenCustomizer() {
    return context -> {
        // Set a custom audience (e.g. the client ID or API identifier)
        context.getClaims().audience(Collections.singletonList("mcp-client"));
    };
}
```

Ovo osigurava da tokeni nose `"aud": ["mcp-client"]`, matching the client ID or scope expected by APIM. 

## Exposing Token and JWKS Endpoints

After deploying, your app’s **issuer URL** will be `https://<app-fqdn>`, e.g. `https://my-mcp-app.eastus.azurecontainerapps.io`. Its OAuth2 endpoints are:

- **Token endpoint:** `https://<app-fqdn>/oauth2/token` – clients obtain tokens here (client_credentials flow).
- **JWKS endpoint:** `https://<app-fqdn>/oauth2/jwks` – returns the JWK set (used by APIM to get signing keys).
- **OpenID Config:** `https://<app-fqdn>/.well-known/openid-configuration` – OIDC discovery JSON (contains `issuer`, `token_endpoint`, `jwks_uri`, etc.).  

APIM will point to the **OpenID configuration URL**, from which it discovers the `jwks_uri`. For example, if your Container App FQDN is `my-mcp-app.eastus.azurecontainerapps.io`, then APIM’s `<openid-config url="...">` should use `https://my-mcp-app.eastus.azurecontainerapps.io/.well-known/openid-configuration`. (By default Spring will set the `issuer` in that metadata to the same base URL ([Configuration Model :: Spring Authorization Server](https://docs.spring.io/spring-authorization-server/reference/configuration-model.html#:~:text=public%20static%20Builder%20builder%28%29%20,oauth2%2Fauthorize)).)

## Configuring Azure API Management (`validate-jwt`)

In Azure APIM, add an inbound policy that uses the `<validate-jwt>` politika za proveru dolaznih JWT-ova protiv vašeg Spring Authorization Servera. Za jednostavnu postavku možete koristiti OpenID Connect URL metapodataka. Primer politike:

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

Ova politika govori APIM-u da preuzme OpenID konfiguraciju sa Spring Auth Servera, preuzme njegov JWKS i proveri da li je svaki token potpisan od strane pouzdanog ključa i ima odgovarajuću publiku. (Ako izostavite `<issuers>`, APIM will use the `issuer` claim from the metadata automatically.) The `<audience>` should match your client ID or API resource identifier in the token (in the example above, we set it to `"mcp-client"`). This is consistent with Microsoft’s documentation on using `validate-jwt` with `<openid-config>` ([Azure API Management policy reference - validate-jwt | Microsoft Learn](https://learn.microsoft.com/en-us/azure/api-management/validate-jwt-policy#:~:text=Microsoft%20Entra%20ID%20single%20tenant,token%20validation)).

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

**References:** See Spring Authorization Server docs for default endpoints ([Configuration Model :: Spring Authorization Server](https://docs.spring.io/spring-authorization-server/reference/configuration-model.html#:~:text=public%20static%20Builder%20builder%28%29%20,oauth2%2Fauthorize)) and OIDC configuration ([Configuration Model :: Spring Authorization Server](https://docs.spring.io/spring-authorization-server/reference/configuration-model.html#:~:text=.securityMatcher%28authorizationServerConfigurer.getEndpointsMatcher%28%29%29%20.with%28authorizationServerConfigurer%2C%20%28authorizationServer%29%20,%29%3B%20return%20http.build)); see Microsoft APIM docs for `validate-jwt` primeri ([Azure API Management referenca politike - validate-jwt | Microsoft Learn](https://learn.microsoft.com/en-us/azure/api-management/validate-jwt-policy#:~:text=Microsoft%20Entra%20ID%20single%20tenant,token%20validation)); i Azure Container Apps dokumentacija za postavljanje i sertifikate ([Postavljanje Java Spring Boot aplikacija na Azure Container Apps - Java na Azure | Microsoft Learn](https://learn.microsoft.com/en-us/azure/developer/java/identity/deploy-spring-boot-to-azure-container-apps#:~:text=Now%20you%20can%20deploy%20your,CLI%20command)) ([Prilagođeni nazivi domena i besplatni upravljani sertifikati u Azure Container Apps | Microsoft Learn](https://learn.microsoft.com/en-us/azure/container-apps/custom-domains-managed-certificates#:~:text=Free%20certificate%20requirements)).

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо тачности, молимо вас да будете свесни да аутоматизовани преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитативним извором. За критичне информације препоручује се професионални превод од стране људи. Не сносимо одговорност за било каква неразумевања или погрешна тумачења која произилазе из коришћења овог превода.