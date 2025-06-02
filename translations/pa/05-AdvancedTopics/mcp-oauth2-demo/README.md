<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9dc0d1fc8ddcd9426558f0d200894951",
  "translation_date": "2025-06-02T12:18:28+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "pa"
}
-->
# MCP OAuth2 Demo

ਇਹ ਪ੍ਰੋਜੈਕਟ ਇੱਕ **ਘੱਟੋ-ਘੱਟ Spring Boot ਐਪਲੀਕੇਸ਼ਨ** ਹੈ ਜੋ ਦੋਹਾਂ ਵਜੋਂ ਕੰਮ ਕਰਦਾ ਹੈ:

* ਇੱਕ **Spring Authorization Server** (ਜੋ `client_credentials` ਫਲੋ ਰਾਹੀਂ JWT ਐਕਸੈਸ ਟੋਕਨ ਜਾਰੀ ਕਰਦਾ ਹੈ), ਅਤੇ  
* ਇੱਕ **Resource Server** (ਜੋ ਆਪਣੇ `/hello` ਐਂਡਪੌਇੰਟ ਦੀ ਸੁਰੱਖਿਆ ਕਰਦਾ ਹੈ)।

ਇਹ [Spring ਬਲੌਗ ਪੋਸਟ (2 ਅਪ੍ਰੈਲ 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) ਵਿੱਚ ਦਰਸਾਏ ਗਏ ਸੈਟਅਪ ਨੂੰ ਦਰਸਾਉਂਦਾ ਹੈ।

---

## ਤੇਜ਼ ਸ਼ੁਰੂਆਤ (ਲੋਕਲ)

```bash
# build & run
./mvnw spring-boot:run

# obtain a token
curl -u mcp-client:secret -d grant_type=client_credentials \
     http://localhost:8081/oauth2/token | jq -r .access_token > token.txt

# call the protected endpoint
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello
```

---

## OAuth2 ਕਨਫਿਗਰੇਸ਼ਨ ਦੀ ਜਾਂਚ

ਤੁਸੀਂ ਹੇਠਾਂ ਦਿੱਤੇ ਕਦਮਾਂ ਨਾਲ OAuth2 ਸੁਰੱਖਿਆ ਕਨਫਿਗਰੇਸ਼ਨ ਦੀ ਜਾਂਚ ਕਰ ਸਕਦੇ ਹੋ:

### 1. ਸਰਵਰ ਚੱਲ ਰਹਿਆ ਹੈ ਅਤੇ ਸੁਰੱਖਿਅਤ ਹੈ ਇਹ ਪੁਸ਼ਟੀ ਕਰੋ

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. ਕਲਾਇੰਟ ਪ੍ਰਮਾਣ ਪੱਤਰਾਂ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਐਕਸੈਸ ਟੋਕਨ ਪ੍ਰਾਪਤ ਕਰੋ

```bash
# Get and extract the full token response
curl -v -X POST http://localhost:8081/oauth2/token \
  -H "Content-Type: application/x-www-form-urlencoded" \
  -H "Authorization: Basic bWNwLWNsaWVudDpzZWNyZXQ=" \
  -d "grant_type=client_credentials&scope=mcp.access"

# Or to extract just the token (requires jq)
curl -s -X POST http://localhost:8081/oauth2/token \
  -H "Content-Type: application/x-www-form-urlencoded" \
  -H "Authorization: Basic bWNwLWNsaWVudDpzZWNyZXQ=" \
  -d "grant_type=client_credentials&scope=mcp.access" | jq -r .access_token > token.txt
```

ਨੋਟ: Basic Authentication ਹੈਡਰ (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret` ਹੈ।

### 3. ਟੋਕਨ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਸੁਰੱਖਿਅਤ ਐਂਡਪੌਇੰਟ ਤੱਕ ਪਹੁੰਚੋ

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"Hello from MCP OAuth2 Demo!" ਨਾਲ ਸਫਲ ਜਵਾਬ ਮਿਲਣਾ ਇਹ ਪੁਸ਼ਟੀ ਕਰਦਾ ਹੈ ਕਿ OAuth2 ਕਨਫਿਗਰੇਸ਼ਨ ਠੀਕ ਕੰਮ ਕਰ ਰਿਹਾ ਹੈ।

---

## ਕੰਟੇਨਰ ਬਿਲਡ

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure Container Apps** 'ਤੇ ਡਿਪਲੌਏ ਕਰੋ

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Ingress FQDN ਤੁਹਾਡਾ **issuer** ਬਣ ਜਾਂਦਾ ਹੈ (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`)।

---

## **Azure API Management** ਨਾਲ ਜੁੜੋ

ਆਪਣੇ API ਵਿੱਚ ਇਹ inbound policy ਸ਼ਾਮਿਲ ਕਰੋ:

```xml
<inbound>
  <validate-jwt header-name="Authorization">
    <openid-config url="https://<fqdn>/.well-known/openid-configuration"/>
    <audiences>
      <audience>mcp-client</audience>
    </audiences>
  </validate-jwt>
  <base/>
</inbound>
```

APIM JWKS ਲੈ ਕੇ ਹਰ ਬੇਨਤੀ ਦੀ ਜਾਂਚ ਕਰੇਗਾ।

---

## ਅਗਲਾ ਕੀ ਹੈ

- [5.2 Web Search MCP Sample](../web-search-mcp/README.md)

**ਅਸਵੀਕਾਰੋक्ति**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਥਿਰਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਭ੍ਰਮ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।