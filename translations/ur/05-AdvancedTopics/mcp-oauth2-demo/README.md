<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a7083e660ca0d85fd6a947514c61993",
  "translation_date": "2025-06-12T23:07:39+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "ur"
}
-->
# MCP OAuth2 Demo

یہ پروجیکٹ ایک **کم از کم Spring Boot ایپلیکیشن** ہے جو دونوں کام کرتی ہے:

* ایک **Spring Authorization Server** کے طور پر (جو JWT ایکسیس ٹوکنز `client_credentials` فلو کے ذریعے جاری کرتا ہے)، اور  
* ایک **Resource Server** کے طور پر (جو اپنے `/hello` اینڈپوائنٹ کو محفوظ بناتا ہے)۔

یہ [Spring بلاگ پوسٹ (2 اپریل 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) میں دکھائے گئے سیٹ اپ کی عکاسی کرتا ہے۔

---

## تیزی سے شروع کریں (مقامی)

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

## OAuth2 کنفیگریشن کی جانچ

آپ OAuth2 سیکیورٹی کنفیگریشن کو درج ذیل اقدامات کے ذریعے ٹیسٹ کر سکتے ہیں:

### 1. تصدیق کریں کہ سرور چل رہا ہے اور محفوظ ہے

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. کلائنٹ کی اسناد کے ذریعے ایکسیس ٹوکن حاصل کریں

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

نوٹ: Basic Authentication ہیڈر (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`۔

### 3. ٹوکن کا استعمال کرتے ہوئے محفوظ اینڈپوائنٹ تک رسائی حاصل کریں

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"Hello from MCP OAuth2 Demo!" کے ساتھ کامیاب جواب اس بات کی تصدیق کرتا ہے کہ OAuth2 کنفیگریشن درست طریقے سے کام کر رہی ہے۔

---

## کنٹینر بنائیں

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure Container Apps** پر تعینات کریں

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

ingress FQDN آپ کا **issuer** بن جاتا ہے (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`۔

---

## **Azure API Management** میں شامل کریں

اپنے API میں یہ inbound پالیسی شامل کریں:

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

APIM JWKS حاصل کرے گا اور ہر درخواست کی تصدیق کرے گا۔

---

## اگلا کیا ہے

- [5.4 Root contexts](../mcp-root-contexts/README.md)

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار ترجموں میں غلطیاں یا غیر درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی مستند ذریعہ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ورانہ انسانی ترجمہ تجویز کیا جاتا ہے۔ ہم اس ترجمہ کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔