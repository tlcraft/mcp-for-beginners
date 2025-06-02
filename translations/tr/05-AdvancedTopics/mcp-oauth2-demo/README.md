<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2d6413f234258f6bbc8189c463e510ee",
  "translation_date": "2025-06-02T19:01:53+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "tr"
}
-->
# MCP OAuth2 Demo

Bu proje, hem şunları yapan **minimal bir Spring Boot uygulamasıdır**:

* **Spring Authorization Server** (JWT erişim tokenlarını `client_credentials` akışı ile veren), ve  
* **Resource Server** (kendi `/hello` uç noktasını koruyan).

[Spring blog yazısında (2 Nis 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) gösterilen yapı ile aynıdır.

---

## Hızlı başlangıç (yerel)

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

## OAuth2 Yapılandırmasını Test Etme

OAuth2 güvenlik yapılandırmasını aşağıdaki adımlarla test edebilirsiniz:

### 1. Sunucunun çalıştığını ve korunduğunu doğrulayın

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. İstemci kimlik bilgileri ile erişim tokenı alın

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

Not: Basic Authentication başlığı (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. Token kullanarak korumalı uç noktaya erişin

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"Hello from MCP OAuth2 Demo!" içeren başarılı bir yanıt, OAuth2 yapılandırmasının doğru çalıştığını gösterir.

---

## Container oluşturma

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure Container Apps** üzerine dağıtım

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Ingress FQDN, sizin **issuer** adresiniz olur (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## **Azure API Management** ile entegrasyon

API’nize bu inbound policy’yi ekleyin:

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

APIM JWKS’yi alır ve her isteği doğrular.

---

## Sonraki adımlar

- [Root contexts](../mcp-root-contexts/README.md)

**Feragatname**:  
Bu belge, [Co-op Translator](https://github.com/Azure/co-op-translator) adlı yapay zeka çeviri hizmeti kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucunda oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.