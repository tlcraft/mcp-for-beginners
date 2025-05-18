<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:40:42+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "ne"
}
-->
# MCP OAuth2 डेमो

यो परियोजना एक **सानो स्प्रिंग बूट एप्लिकेशन** हो जुन दुबैको रूपमा काम गर्छ:

* एक **स्प्रिंग प्राधिकरण सर्भर** (JWT पहुँच टोकनहरू `client_credentials` प्रवाह मार्फत जारी गर्दै), र  
* एक **स्रोत सर्भर** (आफ्नो `/hello` अन्त बिन्दु सुरक्षित गर्दै)।

यो सेटअपलाई [स्प्रिंग ब्लग पोस्ट (२ अप्रिल २०२५)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) मा देखाइएको छ।

---

## छिटो सुरुवात (स्थानीय)

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

## OAuth2 कन्फिगरेसन परीक्षण गर्दै

तपाईं निम्न चरणहरू प्रयोग गरेर OAuth2 सुरक्षा कन्फिगरेसन परीक्षण गर्न सक्नुहुन्छ:

### १. सर्भर चलिरहेको र सुरक्षित भएको सुनिश्चित गर्नुहोस्

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### २. क्लाइन्ट प्रमाणपत्र प्रयोग गरेर पहुँच टोकन प्राप्त गर्नुहोस्

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

नोट: बेसिक प्रमाणिकरण हेडर (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### ३. टोकन प्रयोग गरेर सुरक्षित अन्त बिन्दुमा पहुँच गर्नुहोस्

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"MCP OAuth2 डेमोबाट नमस्ते!" भन्ने सफल प्रतिक्रिया प्राप्त गर्दा OAuth2 कन्फिगरेसन सही रूपमा काम गरिरहेको पुष्टि हुन्छ।

---

## कन्टेनर निर्माण

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure Container Apps** मा परिनियोजन गर्नुहोस्

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

इन्ग्रेस FQDN तपाईंको **issuer** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io` हुन्छ।

---

## **Azure API Management** मा जडान गर्नुहोस्

तपाईंको API मा यो इनबाउन्ड नीति थप्नुहोस्:

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

APIM ले JWKS प्राप्त गर्नेछ र प्रत्येक अनुरोधलाई मान्यता दिनेछ।

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको छ। हामी शुद्धताको लागि प्रयास गर्छौं, तर कृपया सचेत रहनुहोस् कि स्वचालित अनुवादहरूमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छन्। यसको मूल भाषा मा रहेको दस्तावेजलाई आधिकारिक स्रोत मान्नुपर्छ। महत्वपूर्ण जानकारीको लागि, व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्या को लागि हामी जिम्मेवार छैनौं।