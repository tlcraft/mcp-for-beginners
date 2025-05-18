<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:39:11+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "ur"
}
-->
# ایم سی پی اوتھ2 ڈیمو

یہ پروجیکٹ ایک **کم سے کم اسپرنگ بوٹ ایپلیکیشن** ہے جو دونوں کے طور پر کام کرتی ہے:

* ایک **اسپرنگ اتھورائزیشن سرور** (جو JWT ایکسیس ٹوکن جاری کرتا ہے `client_credentials` فلو کے ذریعے)، اور  
* ایک **ریسورس سرور** (اپنے `/hello` اینڈپوائنٹ کو محفوظ بناتا ہے)۔

یہ اس سیٹ اپ کو منعکس کرتا ہے جو [اسپرنگ بلاگ پوسٹ (2 اپریل 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) میں دکھایا گیا ہے۔

---

## فوری آغاز (مقامی)

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

## اوتھ2 کنفیگریشن کی جانچ

آپ درج ذیل مراحل کے ساتھ اوتھ2 سیکیورٹی کنفیگریشن کو جانچ سکتے ہیں:

### 1. تصدیق کریں کہ سرور چل رہا ہے اور محفوظ ہے

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. کلائنٹ کریڈینشلز کا استعمال کرتے ہوئے ایکسیس ٹوکن حاصل کریں

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

نوٹ: بیسک اتھینٹیکیشن ہیڈر (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`۔

### 3. ٹوکن کا استعمال کرتے ہوئے محفوظ اینڈپوائنٹ تک رسائی حاصل کریں

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"ایم سی پی اوتھ2 ڈیمو سے ہیلو!" کے ساتھ کامیاب جواب اس بات کی تصدیق کرتا ہے کہ اوتھ2 کنفیگریشن صحیح کام کر رہی ہے۔

---

## کنٹینر بلڈ

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **ایزور کنٹینر ایپس** پر ڈیپلائے کریں

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

انگریس ایف کیو ڈی این آپ کا **جاری کنندہ** بن جاتا ہے (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`۔

---

## **ایزور اے پی آئی مینیجمنٹ** میں وائر کریں

اپنے اے پی آئی میں یہ ان باؤنڈ پالیسی شامل کریں:

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

اے پی آئی ایم JWKS کو حاصل کرے گا اور ہر درخواست کی تصدیق کرے گا۔

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ ہم درستگی کے لئے کوشش کرتے ہیں، لیکن براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا غیر درستگیاں ہو سکتی ہیں۔ اصل دستاویز کو اس کی اصل زبان میں معتبر ذریعہ سمجھا جانا چاہئے۔ اہم معلومات کے لئے، پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمہ کے استعمال سے پیدا ہونے والے کسی بھی غلط فہمی یا غلط تعبیرات کے ذمہ دار نہیں ہیں۔