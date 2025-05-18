<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:40:20+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "mr"
}
-->
# MCP OAuth2 डेमो

हा प्रकल्प एक **किमान Spring Boot अनुप्रयोग** आहे जो दोन्हीप्रमाणे कार्य करतो:

* एक **Spring Authorization Server** (JWT access tokens जारी करतो `client_credentials` प्रवाहाद्वारे), आणि  
* एक **Resource Server** (त्याच्या स्वतःच्या `/hello` एन्डपॉइंटचे संरक्षण करतो).

हे [Spring ब्लॉग पोस्ट (2 एप्रिल 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) मध्ये दर्शवलेल्या सेटअपशी जुळते.

---

## जलद प्रारंभ (स्थानिक)

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

## OAuth2 कॉन्फिगरेशन चाचणी

तुम्ही खालील चरणांसह OAuth2 सुरक्षा कॉन्फिगरेशनची चाचणी करू शकता:

### 1. सर्व्हर चालू आहे आणि सुरक्षित आहे हे सत्यापित करा

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. क्लायंट क्रेडेन्शियल्स वापरून प्रवेश टोकन मिळवा

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

टीप: बेसिक ऑथेंटिकेशन हेडर (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. टोकन वापरून संरक्षित एन्डपॉइंटवर प्रवेश करा

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"MCP OAuth2 डेमोकडून नमस्कार!" असा यशस्वी प्रतिसाद मिळाल्यास OAuth2 कॉन्फिगरेशन योग्यरित्या कार्यरत आहे हे पुष्टी होते.

---

## कंटेनर बांधणी

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure Container Apps** वर तैनात करा

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

प्रवेश FQDN तुमचा **issuer** बनतो (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## **Azure API Management** मध्ये वायर करा

तुमच्या API मध्ये हा इनबाउंड धोरण जोडा:

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

APIM JWKS मिळवेल आणि प्रत्येक विनंतीची पडताळणी करेल.

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्न करत असलो तरी कृपया लक्षात ठेवा की स्वयंचलित भाषांतरांमध्ये त्रुटी किंवा अचूकतेचा अभाव असू शकतो. मूळ भाषेतील दस्तऐवज हा अधिकृत स्रोत म्हणून विचारात घेतला पाहिजे. महत्त्वपूर्ण माहितीसाठी, व्यावसायिक मानवी भाषांतराची शिफारस केली जाते. या भाषांतराचा वापर केल्यामुळे निर्माण होणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थासाठी आम्ही जबाबदार नाही.