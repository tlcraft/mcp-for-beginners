<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:40:02+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "hi"
}
-->
# MCP OAuth2 डेमो

यह प्रोजेक्ट एक **न्यूनतम स्प्रिंग बूट एप्लिकेशन** है जो दोनों के रूप में कार्य करता है:

* एक **स्प्रिंग ऑथराइजेशन सर्वर** (जो `client_credentials` फ्लो के माध्यम से JWT एक्सेस टोकन जारी करता है), और  
* एक **रिसोर्स सर्वर** (अपने स्वयं के `/hello` एंडपॉइंट की सुरक्षा करता है)।

यह सेटअप [स्प्रिंग ब्लॉग पोस्ट (2 अप्रैल 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) में दिखाए गए सेटअप का प्रतिबिंब है।

---

## त्वरित शुरुआत (स्थानीय)

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

## OAuth2 कॉन्फ़िगरेशन का परीक्षण

आप निम्नलिखित चरणों के साथ OAuth2 सुरक्षा कॉन्फ़िगरेशन का परीक्षण कर सकते हैं:

### 1. सुनिश्चित करें कि सर्वर चल रहा है और सुरक्षित है

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. क्लाइंट क्रेडेंशियल का उपयोग करके एक्सेस टोकन प्राप्त करें

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

ध्यान दें: बेसिक ऑथेंटिकेशन हेडर (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`।

### 3. टोकन का उपयोग करके सुरक्षित एंडपॉइंट का उपयोग करें

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"MCP OAuth2 डेमो से हैलो!" के साथ एक सफल प्रतिक्रिया पुष्टि करती है कि OAuth2 कॉन्फ़िगरेशन सही तरीके से काम कर रहा है।

---

## कंटेनर बिल्ड

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure कंटेनर ऐप्स** पर डिप्लॉय करें

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

इन्ग्रेस FQDN आपका **issuer** बन जाता है (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`।

---

## **Azure API प्रबंधन** में वायर करें

अपने API में यह इनबाउंड नीति जोड़ें:

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

APIM JWKS को प्राप्त करेगा और हर अनुरोध को मान्य करेगा।

**अस्वीकरण**:
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ को इसकी मूल भाषा में आधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।