<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:38:52+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "ar"
}
-->
# MCP OAuth2 Demo

هذا المشروع هو **تطبيق Spring Boot بسيط** يعمل كـ:

* **خادم تفويض Spring** (يصدر رموز JWT عبر تدفق `client_credentials`)، و  
* **خادم موارد** (يحمي نقطة النهاية الخاصة به `/hello`).

يعكس الإعداد الموضح في [مقالة مدونة Spring (2 أبريل 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## البدء السريع (محلي)

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

يمكنك اختبار تكوين أمان OAuth2 بالخطوات التالية:

### 1. تحقق من تشغيل الخادم وتأمينه

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. الحصول على رمز وصول باستخدام بيانات اعتماد العميل

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

ملاحظة: يحتوي رأس المصادقة الأساسية (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. الوصول إلى نقطة النهاية المحمية باستخدام الرمز

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

يؤكد الرد الناجح مع "مرحبًا من MCP OAuth2 Demo!" أن تكوين OAuth2 يعمل بشكل صحيح.

---

## بناء الحاوية

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## النشر إلى **تطبيقات حاويات Azure**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

يصبح FQDN للتوجيه هو **الجهة المصدرة** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## ربط في **إدارة واجهة برمجة تطبيقات Azure**

أضف هذه السياسة الواردة إلى واجهة برمجة التطبيقات الخاصة بك:

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

ستقوم APIM بجلب JWKS والتحقق من كل طلب.

**إخلاء المسؤولية**:  
تم ترجمة هذه الوثيقة باستخدام خدمة الترجمة بالذكاء الاصطناعي [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يُرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار الوثيقة الأصلية بلغتها الأصلية المصدر الرسمي. بالنسبة للمعلومات الحيوية، يُوصى بالترجمة البشرية الاحترافية. نحن غير مسؤولين عن أي سوء فهم أو تفسيرات خاطئة تنشأ عن استخدام هذه الترجمة.