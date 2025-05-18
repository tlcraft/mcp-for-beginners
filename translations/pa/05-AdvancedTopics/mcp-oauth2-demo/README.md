<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:40:52+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "pa"
}
-->
# MCP OAuth2 ਡੈਮੋ

ਇਹ ਪ੍ਰੋਜੈਕਟ ਇੱਕ **ਛੋਟਾ ਸਪ੍ਰਿੰਗ ਬੂਟ ਐਪਲੀਕੇਸ਼ਨ** ਹੈ ਜੋ ਦੋਵਾਂ ਤਰ੍ਹਾਂ ਕੰਮ ਕਰਦਾ ਹੈ:

* ਇੱਕ **ਸਪ੍ਰਿੰਗ ਅਥਾਰਾਈਜ਼ੇਸ਼ਨ ਸਰਵਰ** (JWT ਐਕਸੈਸ ਟੋਕਨ ਜਾਰੀ ਕਰ ਰਿਹਾ ਹੈ `client_credentials` ਫਲੋ ਦੁਆਰਾ), ਅਤੇ  
* ਇੱਕ **ਰਿਸੋਰਸ ਸਰਵਰ** (ਆਪਣੇ ਹੀ `/hello` ਐਂਡਪੌਇੰਟ ਦੀ ਸੁਰੱਖਿਆ ਕਰ ਰਿਹਾ ਹੈ)।

ਇਹ ਸੈਟਅਪ ਨੂੰ ਦਰਸਾਉਂਦਾ ਹੈ ਜਿਵੇਂ ਕਿ [ਸਪ੍ਰਿੰਗ ਬਲੌਗ ਪੋਸਟ (2 ਅਪ੍ਰੈਲ 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) ਵਿੱਚ ਦਿਖਾਇਆ ਗਿਆ ਹੈ।

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

## OAuth2 ਕੰਫਿਗਰੇਸ਼ਨ ਦੀ ਜਾਂਚ

ਤੁਸੀਂ OAuth2 ਸੁਰੱਖਿਆ ਕੰਫਿਗਰੇਸ਼ਨ ਦੀ ਜਾਂਚ ਹੇਠਾਂ ਦਿੱਤੇ ਕਦਮਾਂ ਨਾਲ ਕਰ ਸਕਦੇ ਹੋ:

### 1. ਪੱਕਾ ਕਰੋ ਕਿ ਸਰਵਰ ਚੱਲ ਰਿਹਾ ਹੈ ਅਤੇ ਸੁਰੱਖਿਅਤ ਹੈ

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. ਕਲਾਇੰਟ ਕ੍ਰਿਡੈਂਸ਼ਲ ਵਰਤ ਕੇ ਇੱਕ ਐਕਸੈਸ ਟੋਕਨ ਪ੍ਰਾਪਤ ਕਰੋ

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

ਨੋਟ: ਬੇਸਿਕ ਅਥਾਰਾਈਜ਼ੇਸ਼ਨ ਹੈਡਰ (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. ਟੋਕਨ ਵਰਤ ਕੇ ਸੁਰੱਖਿਅਤ ਐਂਡਪੌਇੰਟ ਦੀ ਪਹੁੰਚ ਕਰੋ

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"Hello from MCP OAuth2 Demo!" ਨਾਲ ਸਫਲ ਰਿਸਪਾਂਸ ਇਹ ਪੱਕਾ ਕਰਦਾ ਹੈ ਕਿ OAuth2 ਕੰਫਿਗਰੇਸ਼ਨ ਸਹੀ ਤਰੀਕੇ ਨਾਲ ਕੰਮ ਕਰ ਰਿਹਾ ਹੈ।

---

## ਕੰਟੇਨਰ ਬਣਾਉ

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure Container Apps** ਵਿੱਚ ਡਿਪਲੌਇ

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

ਇਨਗਰੈਸ FQDN ਤੁਹਾਡਾ **issuer** ਬਣ ਜਾਂਦਾ ਹੈ (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## **Azure API Management** ਵਿੱਚ ਵਾਇਰ ਕਰੋ

ਆਪਣੇ API ਵਿੱਚ ਇਹ ਇਨਬਾਊਂਡ ਪਾਲਿਸੀ ਸ਼ਾਮਲ ਕਰੋ:

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

APIM JWKS ਨੂੰ ਫੈਚ ਕਰੇਗਾ ਅਤੇ ਹਰ ਬੇਨਤੀ ਦੀ ਵੈਰੀਫਿਕੇਸ਼ਨ ਕਰੇਗਾ।

**ਅਸਵੀਕਤੀ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਦਿਓ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਹੀਤਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਇਸਦੇ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਮੂਲ ਦਸਤਾਵੇਜ਼ ਨੂੰ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਗੰਭੀਰ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੇ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।