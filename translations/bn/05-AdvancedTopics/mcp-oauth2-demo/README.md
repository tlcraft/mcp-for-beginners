<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:40:11+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "bn"
}
-->
# এমসিপি OAuth2 ডেমো

এই প্রকল্পটি একটি **ন্যূনতম স্প্রিং বুট অ্যাপ্লিকেশন** যা উভয়ের কাজ করে:

* একটি **স্প্রিং অথরাইজেশন সার্ভার** (JWT অ্যাক্সেস টোকেন প্রদান করে `client_credentials` ফ্লো এর মাধ্যমে), এবং  
* একটি **রিসোর্স সার্ভার** (তার নিজস্ব `/hello` এন্ডপয়েন্ট সুরক্ষিত করে)।

এটি [স্প্রিং ব্লগ পোস্ট (২ এপ্রিল ২০২৫)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) এ প্রদর্শিত সেটআপের প্রতিচ্ছবি।

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

আপনি নিম্নলিখিত পদক্ষেপগুলি ব্যবহার করে OAuth2 নিরাপত্তা কনফিগারেশন পরীক্ষা করতে পারেন:

### ১. নিশ্চিত করুন যে সার্ভার চলছে এবং সুরক্ষিত

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### ২. ক্লায়েন্ট পরিচয়পত্র ব্যবহার করে একটি অ্যাক্সেস টোকেন পান

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

বিঃদ্রঃ: বেসিক অথেন্টিকেশন হেডার (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### ৩. টোকেন ব্যবহার করে সুরক্ষিত এন্ডপয়েন্টে প্রবেশ করুন

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"এমসিপি OAuth2 ডেমো থেকে হ্যালো!" সহ একটি সফল প্রতিক্রিয়া নিশ্চিত করে যে OAuth2 কনফিগারেশন সঠিকভাবে কাজ করছে।

---

## কন্টেইনার বিল্ড

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **অ্যাজিউর কন্টেইনার অ্যাপস** এ মোতায়েন

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

ইনগ্রেস FQDN আপনার **প্রদানকারী** হয়ে যায় (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## **অ্যাজিউর এপিআই ম্যানেজমেন্ট** এ সংযোগ

আপনার এপিআইতে এই ইনবাউন্ড পলিসি যোগ করুন:

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

APIM JWKS সংগ্রহ করবে এবং প্রতিটি অনুরোধ যাচাই করবে।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ পরিষেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসম্ভব সঠিকতার চেষ্টা করি, তবে অনুগ্রহ করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসামঞ্জস্য থাকতে পারে। মূল ভাষায় থাকা নথিটিকে প্রামাণিক উৎস হিসাবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে উদ্ভূত কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।