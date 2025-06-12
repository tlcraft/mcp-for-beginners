<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a7083e660ca0d85fd6a947514c61993",
  "translation_date": "2025-06-12T21:58:25+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "fa"
}
-->
# دموی MCP OAuth2

این پروژه یک **اپلیکیشن مینیمال Spring Boot** است که هم به عنوان:

* یک **سرور احراز هویت Spring** (که توکن‌های دسترسی JWT را از طریق جریان `client_credentials` صادر می‌کند)، و  
* یک **سرور منابع** (که نقطه انتهایی `/hello` خود را محافظت می‌کند) عمل می‌کند.

این پروژه مشابه تنظیماتی است که در [پست وبلاگ Spring (2 آوریل 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) نشان داده شده است.

---

## شروع سریع (محلی)

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

## آزمایش پیکربندی OAuth2

شما می‌توانید پیکربندی امنیتی OAuth2 را با مراحل زیر آزمایش کنید:

### 1. بررسی اینکه سرور در حال اجرا و امن است

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. دریافت توکن دسترسی با استفاده از اطلاعات کاربری کلاینت

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

توجه: هدر احراز هویت Basic (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. دسترسی به نقطه انتهایی محافظت‌شده با استفاده از توکن

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

پاسخ موفقیت‌آمیز با پیام "Hello from MCP OAuth2 Demo!" نشان می‌دهد که پیکربندی OAuth2 به درستی کار می‌کند.

---

## ساخت کانتینر

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## استقرار در **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

نام دامنه ورودی (ingress FQDN) به عنوان **issuer** شما تبدیل می‌شود (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## اتصال به **Azure API Management**

این سیاست ورودی را به API خود اضافه کنید:

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

APIM فایل JWKS را دریافت کرده و هر درخواست را اعتبارسنجی خواهد کرد.

---

## گام بعدی چیست

- [5.4 ریشه‌های context](../mcp-root-contexts/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل اشتباهات یا نادرستی‌هایی باشند. سند اصلی به زبان بومی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوء تفاهم یا تفسیر نادرستی که از استفاده از این ترجمه ناشی شود، نیستیم.