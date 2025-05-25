<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:45:34+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "sl"
}
-->
# MCP OAuth2 පෙළගැස්ම

මෙම ව්‍යාපෘතිය **අවම Spring Boot යෙදුමක්** වන අතර එය දෙකක් ලෙස ක්‍රියා කරයි:

* **Spring අවසර සර්වර්** (JWT ප්‍රවේශ ටෝකන නිකුත් කිරීමේ `client_credentials` ගැලීම් හරහා), සහ  
* **සම්පත් සර්වර්** (තමන්ගේම `/hello` අන්තර්ගතය ආරක්ෂා කිරීම).

එය [Spring බ්ලොග් ලිපිය (2025 අප්‍රේල් 2)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) හි දැක්වෙන සැකසුම පෙන්වයි.

---

## ඉක්මන් ආරම්භය (ස්ථානික)

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

## OAuth2 වින්‍යාසය පරීක්ෂා කිරීම

ඔබට OAuth2 ආරක්ෂිත වින්‍යාසය පරීක්ෂා කළ හැකිය පහත පියවර මගින්:

### 1. සර්වර් ක්‍රියාත්මක වන බව සහ ආරක්ෂිත බව තහවුරු කරන්න

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. ගනුදෙනුකරු අයිතිවාසිකම් භාවිතා කරමින් ප්‍රවේශ ටෝකනයක් ලබා ගන්න

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

සටහන: මූලික සත්‍යාපන ශීර්ෂය (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. ටෝකනය භාවිතා කරමින් ආරක්ෂිත අන්තර්ගතය ප්‍රවේශ වන්න

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

"MCP OAuth2 පෙළගැස්මෙන් ආයුබෝවන්!" යන සාර්ථක පිළිතුරක් ලැබීමෙන් OAuth2 වින්‍යාසය නිවැරදිව ක්‍රියාත්මක වන බව තහවුරු වේ.

---

## කන්ටේනර් ගොඩනැගීම

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## **Azure Container Apps** වෙත යොමු කිරීම

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

ආගමන FQDN ඔබේ **නිකුත්කරු** වේ (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## **Azure API Management** වෙත සම්බන්ධ වීම

ඔබේ API සඳහා මෙම ආගත ප්‍රතිපත්තිය එක් කරන්න:

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

APIM JWKS ලබා ගෙන, සෑම ඉල්ලීමක්ම සත්‍යාපනය කරනු ඇත.

**Omejitev odgovornosti**: 
Ta dokument je bil preveden z uporabo storitve AI za prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da se zavedate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za kritične informacije je priporočljivo profesionalno človeško prevajanje. Ne odgovarjamo za kakršne koli nesporazume ali napačne interpretacije, ki bi nastale zaradi uporabe tega prevoda.