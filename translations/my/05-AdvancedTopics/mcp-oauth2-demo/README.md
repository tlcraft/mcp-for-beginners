<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a7083e660ca0d85fd6a947514c61993",
  "translation_date": "2025-06-17T16:51:24+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "my"
}
-->
# MCP OAuth2 များပြသချက်

ဤပရောဂျက်သည် **အနည်းဆုံး Spring Boot application** ဖြစ်ပြီး အောက်ပါအဖြစ်ဆောင်ရွက်သည်။

* **Spring Authorization Server** (`client_credentials` flow ဖြင့် JWT access token များထုတ်ပေးခြင်း), နှင့်  
* **Resource Server** (၎င်း၏ `/hello` endpoint ကို ကာကွယ်ထားခြင်း)။

ဒါဟာ [Spring ဘလော့ဂ်ပို့စ် (2025 ခုနှစ် ဧပြီ 2 ရက်)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) တွင် ဖော်ပြထားသည့် စနစ်ကို လိုက်နာထားသည်။

---

## အမြန်စတင်ခြင်း (ဒေသခံ)

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

## OAuth2 ဖွဲ့စည်းမှု စမ်းသပ်ခြင်း

အောက်ပါအဆင့်များဖြင့် OAuth2 လုံခြုံရေးဖွဲ့စည်းမှုကို စမ်းသပ်နိုင်သည်။

### 1. ဆာဗာရပ်တည်ပြီး လုံခြုံမှုရှိသည်ကို စစ်ဆေးပါ

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. client credentials ဖြင့် access token ရယူပါ

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

မှတ်ချက် - Basic Authentication header သည် (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret` ဖြစ်သည်။

### 3. token ကို အသုံးပြုပြီး ကာကွယ်ထားသော endpoint သို့ ဝင်ရောက်ပါ

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"Hello from MCP OAuth2 Demo!" ဟူသော အောင်မြင်သော တုံ့ပြန်မှုသည် OAuth2 ဖွဲ့စည်းမှုမှန်ကန်စွာ လည်ပတ်နေသည်ကို အတည်ပြုသည်။

---

## ကွန်တိန်နာ တည်ဆောက်ခြင်း

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure Container Apps** သို့ တင်သွင်းခြင်း

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

ingress FQDN သည် သင့် **issuer** ဖြစ်လာမည် (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`)။

---

## **Azure API Management** နှင့် ပေါင်းစည်းခြင်း

သင့် API တွင် ဤ inbound policy ကို ထည့်ပါ။

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

APIM သည် JWKS ကို ရယူပြီး တောင်းဆိုမှုတိုင်းကို စစ်ဆေးမည်ဖြစ်သည်။

---

## နောက်တစ်ဆင့်

- [5.4 Root contexts](../mcp-root-contexts/README.md)

**အတည်မပြုချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားပေမယ့်၊ အလိုအလျောက် ဘာသာပြန်ချက်များတွင် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ရှိနိုင်ကြောင်း သတိပြုပါရန် ဖိတ်ခေါ်ပါသည်။ မူရင်းစာတမ်းကို မူလဘာသာဖြင့်သာ ယုံကြည်စိတ်ချရသော အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန် ဝန်ဆောင်မှုကို အသုံးပြုရန် အကြံပြုပါသည်။ ဤဘာသာပြန်ချက် အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် မမှန်ကန်မှုများ သို့မဟုတ် နားမလည်မှုများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။