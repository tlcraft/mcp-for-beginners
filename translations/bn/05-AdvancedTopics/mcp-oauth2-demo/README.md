<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2d6413f234258f6bbc8189c463e510ee",
  "translation_date": "2025-06-02T18:40:10+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "bn"
}
-->
# MCP OAuth2 ডেমো

এই প্রজেক্টটি একটি **সর্বনিম্ন Spring Boot অ্যাপ্লিকেশন** যা একই সাথে কাজ করে:

* একটি **Spring Authorization Server** (JWT অ্যাক্সেস টোকেন ইস্যু করার জন্য `client_credentials` ফ্লো ব্যবহার করে), এবং  
* একটি **Resource Server** (নিজের `/hello` এন্ডপয়েন্টকে সুরক্ষিত করে)।

এটি [Spring ব্লগ পোস্ট (২ এপ্রিল ২০২৫)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) এ দেখানো সেটআপের অনুকরণ করে।

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

নিম্নলিখিত ধাপগুলো অনুসরণ করে আপনি OAuth2 সিকিউরিটি কনফিগারেশন পরীক্ষা করতে পারেন:

### ১. নিশ্চিত করুন সার্ভার চলছে এবং সুরক্ষিত

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### ২. ক্লায়েন্ট ক্রেডেনশিয়াল ব্যবহার করে অ্যাক্সেস টোকেন পান

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

[!NOTE] Basic Authentication হেডারটি হল (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`।

### ৩. টোকেন ব্যবহার করে সুরক্ষিত এন্ডপয়েন্টে প্রবেশ করুন

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"Hello from MCP OAuth2 Demo!" এই সফল রেসপন্স পাওয়া মানে OAuth2 কনফিগারেশন সঠিকভাবে কাজ করছে।

---

## কন্টেইনার বিল্ড

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure Container Apps** এ ডিপ্লয় করুন

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

ইনগ্রেস FQDN হবে আপনার **issuer** (`https://<fqdn>`).  
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

APIM JWKS নিয়ে আসবে এবং প্রতিটি অনুরোধ যাচাই করবে।

---

## পরবর্তী ধাপ

- [Root contexts](../mcp-root-contexts/README.md)

**অস্বীকারোক্তি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথি তার নিজস্ব ভাষায় কর্তৃপক্ষসূত্র হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদের পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়বদ্ধ নই।