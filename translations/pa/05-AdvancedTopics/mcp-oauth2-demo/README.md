<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a7083e660ca0d85fd6a947514c61993",
  "translation_date": "2025-06-12T23:33:00+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "pa"
}
-->
# MCP OAuth2 ਡੈਮੋ

ਇਹ ਪ੍ਰੋਜੈਕਟ ਇੱਕ **ਸਰਲ Spring Boot ਐਪਲੀਕੇਸ਼ਨ** ਹੈ ਜੋ ਦੋਹਾਂ ਵਜੋਂ ਕੰਮ ਕਰਦਾ ਹੈ:

* ਇੱਕ **Spring Authorization Server** (ਜੋ `client_credentials` ਫਲੋ ਰਾਹੀਂ JWT ਐਕਸੈੱਸ ਟੋਕਨ ਜਾਰੀ ਕਰਦਾ ਹੈ), ਅਤੇ  
* ਇੱਕ **Resource Server** (ਆਪਣੇ `/hello` ਐਂਡਪੌਇੰਟ ਦੀ ਸੁਰੱਖਿਆ ਕਰਦਾ ਹੈ)।

ਇਹ ਸੈਟਅੱਪ [Spring ਬਲੌਗ ਪੋਸਟ (2 ਅਪ੍ਰੈਲ 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) ਵਿੱਚ ਦਿਖਾਏ ਗਏ ਤਰੀਕੇ ਦੀ ਨਕਲ ਕਰਦਾ ਹੈ।

---

## ਤੁਰੰਤ ਸ਼ੁਰੂਆਤ (ਲੋਕਲ)

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

ਤੁਸੀਂ OAuth2 ਸੁਰੱਖਿਆ ਕਨਫਿਗਰੇਸ਼ਨ ਨੂੰ ਹੇਠਾਂ ਦਿੱਤੇ ਕਦਮਾਂ ਨਾਲ ਟੈਸਟ ਕਰ ਸਕਦੇ ਹੋ:

### 1. ਸਰਵਰ ਚੱਲ ਰਿਹਾ ਹੈ ਅਤੇ ਸੁਰੱਖਿਅਤ ਹੈ ਇਹ ਪੱਕਾ ਕਰੋ

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. ਕਲਾਇੰਟ ਕ੍ਰੈਡੈਂਸ਼ਲਜ਼ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਐਕਸੈੱਸ ਟੋਕਨ ਪ੍ਰਾਪਤ ਕਰੋ

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

ਨੋਟ: Basic Authentication ਹੈਡਰ (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`)।

### 3. ਟੋਕਨ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਸੁਰੱਖਿਅਤ ਐਂਡਪੌਇੰਟ ਤੱਕ ਪਹੁੰਚ ਕਰੋ

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

ਜੇ "Hello from MCP OAuth2 Demo!" ਨਾਲ ਸਫਲ ਜਵਾਬ ਮਿਲਦਾ ਹੈ, ਤਾਂ ਇਸਦਾ ਮਤਲਬ ਹੈ ਕਿ OAuth2 ਕਨਫਿਗਰੇਸ਼ਨ ਠੀਕ ਤਰ੍ਹਾਂ ਕੰਮ ਕਰ ਰਿਹਾ ਹੈ।

---

## ਕੰਟੇਨਰ ਬਣਾਉਣਾ

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure Container Apps** 'ਤੇ ਡਿਪਲੋਇ ਕਰੋ

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Ingress FQDN ਤੁਹਾਡਾ **issuer** ਬਣ ਜਾਂਦਾ ਹੈ (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`)।

---

## **Azure API Management** ਨਾਲ ਜੋੜੋ

ਆਪਣੇ API ਵਿੱਚ ਇਹ inbound policy ਸ਼ਾਮਲ ਕਰੋ:

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

APIM JWKS ਲਿਆਵੇਗਾ ਅਤੇ ਹਰ ਬੇਨਤੀ ਦੀ ਜਾਂਚ ਕਰੇਗਾ।

---

## ਅਗਲਾ ਕੀ ਹੈ

- [5.4 Root contexts](../mcp-root-contexts/README.md)

**ਅਸਵੀਕਾਰਤਾ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਨਾਲ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।