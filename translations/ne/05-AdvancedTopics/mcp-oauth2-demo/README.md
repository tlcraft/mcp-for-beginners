<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a7083e660ca0d85fd6a947514c61993",
  "translation_date": "2025-06-12T23:28:02+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "ne"
}
-->
# MCP OAuth2 Demo

यो परियोजना एक **सामान्य Spring Boot एप्लिकेशन** हो जुन दुबैको रूपमा काम गर्छ:

* एक **Spring Authorization Server** (जो `client_credentials` फ्लो मार्फत JWT एक्सेस टोकन जारी गर्छ), र  
* एक **Resource Server** (आफ्नो `/hello` एन्डपोइन्टलाई सुरक्षा गर्छ)।

यो [Spring ब्लग पोस्ट (2 अप्रिल 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) मा देखाइएको सेटअपलाई प्रतिबिम्बित गर्छ।

---

## छिटो सुरु (स्थानीय)

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

## OAuth2 कन्फिगरेसन परीक्षण गर्ने

तपाईंले OAuth2 सुरक्षा कन्फिगरेसन निम्न चरणहरू मार्फत परीक्षण गर्न सक्नुहुन्छ:

### 1. सर्भर चलिरहेको र सुरक्षित छ भनि जाँच गर्नुहोस्

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. क्लाइन्ट क्रेडेन्सियल्स प्रयोग गरी एक्सेस टोकन प्राप्त गर्नुहोस्

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

Note: Basic Authentication हेडर (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`।

### 3. टोकन प्रयोग गरी सुरक्षित एन्डपोइन्टमा पहुँच गर्नुहोस्

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"Hello from MCP OAuth2 Demo!" को सफल प्रतिक्रिया प्राप्त भएमा OAuth2 कन्फिगरेसन सही रूपमा काम गरिरहेको छ भनी पुष्टि हुन्छ।

---

## कन्टेनर निर्माण

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure Container Apps** मा डिप्लोय गर्नुहोस्

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Ingress FQDN तपाईंको **issuer** हुन्छ (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`।

---

## **Azure API Management** मा जोड्ने

तपाईंको API मा यो inbound policy थप्नुहोस्:

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

APIM ले JWKS प्राप्त गरी हरेक अनुरोधलाई प्रमाणित गर्नेछ।

---

## अब के गर्ने

- [5.4 Root contexts](../mcp-root-contexts/README.md)

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा असत्यताहरू हुन सक्छन्। मूल दस्तावेज़लाई यसको मूल भाषामा आधिकारिक स्रोतको रूपमा मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।