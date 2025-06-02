<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9dc0d1fc8ddcd9426558f0d200894951",
  "translation_date": "2025-06-02T12:14:53+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "mr"
}
-->
# MCP OAuth2 डेमो

हा प्रोजेक्ट एक **मिनिमल Spring Boot ऍप्लिकेशन** आहे जे दोन्ही भूमिका बजावते:

* एक **Spring Authorization Server** (जो JWT access tokens `client_credentials` फ्लो वापरून जारी करतो), आणि  
* एक **Resource Server** (जो स्वतःचा `/hello` endpoint संरक्षित करतो).

हे [Spring ब्लॉग पोस्ट (2 एप्रिल 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) मध्ये दाखवलेल्या सेटअपशी जुळते.

---

## जलद सुरुवात (स्थानिक)

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

## OAuth2 कॉन्फिगरेशनची चाचणी करणे

खालील पायऱ्यांनी तुम्ही OAuth2 सुरक्षा कॉन्फिगरेशनची चाचणी करू शकता:

### 1. सर्व्हर चालू आहे आणि सुरक्षित आहे का ते तपासा

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. क्लायंट क्रेडेन्शियल्स वापरून access token मिळवा

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

टीप: Basic Authentication हेडर (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret` आहे.

### 3. token वापरून संरक्षित endpoint ला प्रवेश करा

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"Hello from MCP OAuth2 Demo!" असा यशस्वी प्रतिसाद मिळाल्यास OAuth2 कॉन्फिगरेशन योग्यरित्या कार्यरत आहे याची खात्री होते.

---

## कंटेनर बिल्ड

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure Container Apps** मध्ये डिप्लॉय करा

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

ingress FQDN तुमचा **issuer** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`) बनतो.

---

## **Azure API Management** मध्ये कनेक्ट करा

तुमच्या API मध्ये हा inbound पॉलिसी जोडा:

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

APIM JWKS प्राप्त करेल आणि प्रत्येक विनंतीची पडताळणी करेल.

---

## पुढे काय

- [5.2 Web Search MCP Sample](../web-search-mcp/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) चा वापर करून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात ठेवा की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला पाहिजे. महत्त्वाच्या माहिती साठी व्यावसायिक मानवी अनुवाद शिफारसीय आहे. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थलावणीबाबत आम्ही जबाबदार नाही.