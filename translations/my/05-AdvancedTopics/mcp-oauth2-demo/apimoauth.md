<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "32c9a4263be08f9050c8044bb26267c4",
  "translation_date": "2025-06-17T16:51:50+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/apimoauth.md",
  "language_code": "my"
}
-->
# Spring AI MCP App ကို Azure Container Apps တွင် တပ်ဆင်ခြင်း

([Securing Spring AI MCP servers with OAuth2](https://spring.io/blog/2025/04/02/mcp-server-oauth2)) *ပုံဖော်ချက် - Spring AI MCP server ကို Spring Authorization Server ဖြင့် လုံခြုံစေထားသည်။ Server သည် client များထံ access token များထုတ်ပေးပြီး၊ လာရောက်သော တောင်းဆိုမှုများကို စစ်ဆေးသည် (အရင်းအမြစ် - Spring blog) ([Securing Spring AI MCP servers with OAuth2](https://spring.io/blog/2025/04/02/mcp-server-oauth2#:~:text=,server%20with%20the%20MCP%20inspector))။* Spring MCP server ကို deploy လုပ်ရန်အတွက် container အဖြစ် build ပြီး Azure Container Apps ကို external ingress ဖြင့် အသုံးပြုနိုင်သည်။ ဥပမာအားဖြင့် Azure CLI ကို အသုံးပြု၍ အောက်ပါ command ကို run ပါ။

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

ဒါကတော့ HTTPS ကို အတည်ပြုထားသော လူသုံးများရောက်နိုင်သော Container App တစ်ခု ဖန်တီးပေးမည်ဖြစ်သည် (Azure သည် default `*.azurecontainerapps.io` အတွက် အခမဲ့ TLS certificate ထုတ်ပေးသည်)။ `application.properties` တွင် အောက်ပါအတိုင်း သတ်မှတ်နိုင်ပါသည်။

```properties
# OAuth2 client (for testing token issuance)
spring.security.oauth2.authorizationserver.client.oidc-client.registration.client-id=mcp-client
spring.security.oauth2.authorizationserver.client.oidc-client.registration.client-secret={noop}secret
spring.security.oauth2.authorizationserver.client.oidc-client.registration.authorization-grant-types=client_credentials
spring.security.oauth2.authorizationserver.client.oidc-client.registration.client-authentication-methods=client_secret_basic
```

Authorization Server နှင့် Resource Server ကို security filter chain ဖြင့် ဖွင့်ပါ။ ဥပမာ -

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

ဒီစနစ်က default OAuth2 endpoint များကို ဖော်ပြပေးမည်ဖြစ်သည် - `/oauth2/token`, `/oauth2/jwks`, `AuthorizationServerSettings`, `/oauth2/token`, `/oauth2/jwks`, `https://<your-app>:/oauth2/jwks`, `.oidc(Customizer.withDefaults())` စသဖြင့် security configuration တွင် ပါဝင်သည် ([Configuration Model :: Spring Authorization Server](https://docs.spring.io/spring-authorization-server/reference/configuration-model.html#:~:text=.securityMatcher%28authorizationServerConfigurer.getEndpointsMatcher%28%29%29%20.with%28authorizationServerConfigurer%2C%20%28authorizationServer%29%20,%29%3B%20return%20http.build))။ ဥပမာ -

```java
http
  .apply(authzServer.and())
  .securityMatcher(authzServer.getEndpointsMatcher())
  .with(authzServer, authz -> authz
      .oidc(Customizer.withDefaults()));  // <– enables /.well-known/openid-configuration
```

ဒါကတော့ `/.well-known/openid-configuration` ကို ဖော်ပြပေးပြီး `<audiences>` စစ်ဆေးမှုကို ဖြတ်သွားစေပါသည်။ ဥပမာ token customizer တစ်ခု ထည့်ပါ။

```java
@Bean
public OAuth2TokenCustomizer<OAuth2TokenClaimsContext> tokenCustomizer() {
    return context -> {
        // Set a custom audience (e.g. the client ID or API identifier)
        context.getClaims().audience(Collections.singletonList("mcp-client"));
    };
}
```

ဒီနည်းလမ်းက tokens တွင် `"aud": ["mcp-client"]` ပါရှိရန် သေချာစေပါသည်။ `https://<app-fqdn>`, `https://my-mcp-app.eastus.azurecontainerapps.io`, `https://<app-fqdn>/oauth2/token`, `https://<app-fqdn>/oauth2/jwks`, `https://<app-fqdn>/.well-known/openid-configuration`, `issuer`, `token_endpoint`, `jwks_uri`, `my-mcp-app.eastus.azurecontainerapps.io`, `<openid-config url="...">`, `https://my-mcp-app.eastus.azurecontainerapps.io/.well-known/openid-configuration`, `issuer`, `validate-jwt`, `<validate-jwt>` policy များကို အသုံးပြု၍ Spring Authorization Server နှင့် သင့် JWT များကို စစ်ဆေးနိုင်သည်။ ပုံမှန်စနစ်အတွက် OpenID Connect metadata URL ကို အသုံးပြုနိုင်သည်။ နမူနာ policy အပိုင်း -

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

ဒီ policy က APIM ကို Spring Auth Server မှ OpenID configuration ကို ရယူရန်၊ JWKS ကို ယူရန်၊ token တစ်ခုချင်းစီကို ယုံကြည်စိတ်ချရသော key ဖြင့် လက်မှတ်ရေးထိုးထားပြီး audience မှန်ကန်မှုရှိကြောင်း စစ်ဆေးရန် ပြောဆိုသည်။ (`<issuers>`, `issuer`, `<audience>`, `"mcp-client"`, `validate-jwt`, `<openid-config>`, `Authorization`, `https://my-mcp-app.eastus.azurecontainerapps.io`, `https://my-mcp-app.eastus.azurecontainerapps.io/oauth2/token`, `https://my-mcp-app.eastus.azurecontainerapps.io/oauth2/jwks`, `https://my-mcp-app.eastus.azurecontainerapps.io/.well-known/openid-configuration`, `mcp-client`, `<openid-config url="https://.../.well-known/openid-configuration" />`, `<validate-jwt>`, `<validate-jwt>`, `--ingress external`, `.well-known`, `/jwks`, `/.well-known/openid-configuration`, `.oidc(Customizer.withDefaults())`, `<openid-config>`, `aud`, `<audience>`, `<audience>`, `issuer`, `jwks_uri`, `<validate-jwt>`, `<validate-jwt>`, `<inbound>`, `validate-jwt`, `validate-jwt`) စသည်ဖြင့်) ([Azure API Management policy reference - validate-jwt | Microsoft Learn](https://learn.microsoft.com/en-us/azure/api-management/validate-jwt-policy#:~:text=Microsoft%20Entra%20ID%20single%20tenant,token%20validation)) နှင့် Azure Container Apps ရဲ့ deployment နှင့် certificate များအတွက် documentation များ ([Deploy Java Spring Boot apps to Azure Container Apps - Java on Azure | Microsoft Learn](https://learn.microsoft.com/en-us/azure/developer/java/identity/deploy-spring-boot-to-azure-container-apps#:~:text=Now%20you%20can%20deploy%20your,CLI%20command)) ([Custom domain names and free managed certificates in Azure Container Apps | Microsoft Learn](https://learn.microsoft.com/en-us/azure/container-apps/custom-domains-managed-certificates#:~:text=Free%20certificate%20requirements)) ကို ကြည့်ရှုနိုင်ပါသည်။

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးပမ်းပါသော်လည်း၊ စက်ရုပ်ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် တိကျမှုနည်းပါးမှုများ ရှိနိုင်ကြောင်း ကျေးဇူးပြု၍ သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မူရင်းဘာသာဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသောအချက်အလက်များအတွက် သက်ဆိုင်ရာ လူ့ဘာသာပြန်သူ ပရော်ဖက်ရှင်နယ် ဝန်ဆောင်မှုကို အသုံးပြုရန် အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုအမှားများ သို့မဟုတ် မှားယွင်းဖော်ပြချက်များအတွက် ကျွန်ုပ်တို့သည် တာဝန်မရှိပါ။