<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2d6413f234258f6bbc8189c463e510ee",
  "translation_date": "2025-06-02T18:49:11+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "ne"
}
-->
# MCP OAuth2 डेमो

यो प्रोजेक्ट एक **सामान्य Spring Boot एप्लिकेशन** हो जुन दुवै रूपमा काम गर्छ:

* एक **Spring Authorization Server** (जो JWT एक्सेस टोकनहरू `client_credentials` फ्लो मार्फत जारी गर्छ), र  
* एक **Resource Server** (आफ्नो `/hello` एन्डपोइन्टलाई सुरक्षित बनाउँछ)।

यसले [Spring ब्लग पोस्ट (2 अप्रिल 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) मा देखाइएको सेटअपलाई प्रतिबिम्बित गर्छ।

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

तपाईं तलका चरणहरूद्वारा OAuth2 सुरक्षा कन्फिगरेसन परीक्षण गर्न सक्नुहुन्छ:

### 1. सर्भर चलिरहेको र सुरक्षित छ कि छैन जाँच्नुहोस्

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

Note: Basic Authentication हेडर (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret` हो।

### 3. टोकन प्रयोग गरी सुरक्षित एन्डपोइन्टमा पहुँच गर्नुहोस्

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"Hello from MCP OAuth2 Demo!" भन्ने सफल प्रतिक्रिया प्राप्त भएमा OAuth2 कन्फिगरेसन ठीकसँग काम गरिरहेको पुष्टि हुन्छ।

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

## **Azure API Management** सँग जोड्नुहोस्

तपाईंको API मा यो inbound नीति थप्नुहोस्:

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

APIM ले JWKS ल्याएर प्रत्येक अनुरोधको मान्यता गर्नेछ।

---

## अब के गर्ने

- [Root contexts](../mcp-root-contexts/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया जानकार हुनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा गलतफहमी हुन सक्छन्। मूल दस्तावेज यसको स्वदेशी भाषामा नै अधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानवीय अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलत बुझाइ वा गलत व्याख्याको लागि हामी जिम्मेवार छैनौं।