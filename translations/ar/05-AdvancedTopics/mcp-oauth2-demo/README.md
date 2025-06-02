<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9dc0d1fc8ddcd9426558f0d200894951",
  "translation_date": "2025-06-02T11:56:36+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "ar"
}
-->
# MCP OAuth2 Demo

هذا المشروع هو **تطبيق Spring Boot بسيط** يعمل كـ:

* **خادم تفويض Spring** (يصدر رموز وصول JWT عبر تدفق `client_credentials`)، و  
* **خادم موارد** (يحمي نقطة النهاية الخاصة به `/hello`).

يعكس الإعداد المعروض في [مقالة مدونة Spring (2 أبريل 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## بدء سريع (محلي)

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

## اختبار تكوين OAuth2

يمكنك اختبار إعداد أمان OAuth2 باتباع الخطوات التالية:

### 1. تحقق من تشغيل الخادم وتأمينه

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. احصل على رمز وصول باستخدام بيانات اعتماد العميل

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

ملاحظة: رأس المصادقة الأساسية (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. الوصول إلى نقطة النهاية المحمية باستخدام الرمز

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

الاستجابة الناجحة مع "Hello from MCP OAuth2 Demo!" تؤكد أن تكوين OAuth2 يعمل بشكل صحيح.

---

## بناء الحاوية

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## النشر إلى **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

يصبح اسم المجال الكامل (FQDN) الخاص بالدخول هو **المُصدر** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## الربط مع **Azure API Management**

أضف سياسة الإدخال هذه إلى واجهة برمجة التطبيقات الخاصة بك:

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

سيقوم APIM بجلب JWKS والتحقق من صحة كل طلب.

---

## ماذا بعد

- [5.2 Web Search MCP Sample](../web-search-mcp/README.md)

**تنويه**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى للدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاستعانة بترجمة بشرية محترفة. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.