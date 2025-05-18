<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:41:27+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "tr"
}
-->
# MCP OAuth2 Demo

Bu proje, hem **Spring Yetkilendirme Sunucusu** (JWT erişim belirteçleri `client_credentials` akışı aracılığıyla veren) hem de  
**Kaynak Sunucusu** (kendi `/hello` uç noktasını koruyan) olarak işlev gören **minimal bir Spring Boot uygulaması**dır.

[Spring blog yazısında (2 Nisan 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) gösterilen kurulumu yansıtır.

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

### 1. Sunucunun çalıştığını ve güvenli olduğunu doğrulayın

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. İstemci kimlik bilgilerini kullanarak bir erişim belirteci alın

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

Not: Temel Kimlik Doğrulama başlığı (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. Belirteci kullanarak korunan uç noktaya erişin

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"MCP OAuth2 Demo'dan Merhaba!" yanıtı başarılı bir şekilde alındığında OAuth2 yapılandırmasının doğru çalıştığını doğrular.

---

## Konteyner oluşturma

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure Container Apps**'e Dağıtım

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Giriş FQDN'niz **issuer** olur (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## **Azure API Management** ile Bağlantı Kurma

API'nize bu inbound politikasını ekleyin:

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

APIM, JWKS'i alacak ve her isteği doğrulayacaktır.

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluğu sağlamak için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini unutmayın. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanılması sonucunda oluşabilecek yanlış anlamalar veya yanlış yorumlamalardan dolayı sorumlu değiliz.