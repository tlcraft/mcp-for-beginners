<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a7083e660ca0d85fd6a947514c61993",
  "translation_date": "2025-06-12T23:17:45+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "bn"
}
-->
# MCP OAuth2 ডেমো

এই প্রজেক্টটি একটি **সর্বনিম্ন Spring Boot অ্যাপ্লিকেশন** যা একইসাথে:

* একটি **Spring Authorization Server** (যা `client_credentials` ফ্লো এর মাধ্যমে JWT অ্যাক্সেস টোকেন ইস্যু করে), এবং  
* একটি **Resource Server** (যা নিজস্ব `/hello` এন্ডপয়েন্ট সুরক্ষিত রাখে)।

এটি [Spring ব্লগ পোস্ট (2 এপ্রিল 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) এ দেখানো সেটআপের প্রতিফলন।

---

## দ্রুত শুরু (লোকাল)

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

## OAuth2 কনফিগারেশন পরীক্ষা

আপনি নিচের ধাপগুলো অনুসরণ করে OAuth2 সিকিউরিটি কনফিগারেশন পরীক্ষা করতে পারেন:

### 1. সার্ভার চলছে এবং সুরক্ষিত কিনা যাচাই করুন

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. ক্লায়েন্ট ক্রেডেনশিয়াল ব্যবহার করে অ্যাক্সেস টোকেন পান

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

Note: Basic Authentication হেডারটি (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`।

### 3. টোকেন ব্যবহার করে সুরক্ষিত এন্ডপয়েন্টে প্রবেশ করুন

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"Hello from MCP OAuth2 Demo!" সহ সফল প্রতিক্রিয়া নিশ্চিত করে যে OAuth2 কনফিগারেশন সঠিকভাবে কাজ করছে।

---

## কন্টেইনার বিল্ড

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure Container Apps** এ ডিপ্লয় করুন

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

ইনগ্রেস FQDN আপনার **issuer** হয়ে যাবে (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`)।

---

## **Azure API Management** এর সাথে সংযুক্ত করুন

আপনার API তে এই ইনবাউন্ড পলিসি যোগ করুন:

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

APIM JWKS নিয়ে আসবে এবং প্রতিটি রিকোয়েস্ট যাচাই করবে।

---

## পরবর্তী ধাপ

- [5.4 Root contexts](../mcp-root-contexts/README.md)

**বিজ্ঞপ্তি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে দয়া করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ভুল বা অমিল থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃপক্ষপূর্ণ উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদের পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহার থেকে উদ্ভূত কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়বদ্ধ নই।