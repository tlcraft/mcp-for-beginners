<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:43:05+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "he"
}
-->
# MCP OAuth2 דמו

הפרויקט הזה הוא **יישום מינימלי של Spring Boot** שמשמש גם כ:

* **שרת הרשאות של Spring** (המנפיק JWT access tokens באמצעות הזרימה של `client_credentials`), וגם  
* **שרת משאבים** (מגן על נקודת הקצה של `/hello` שלו).

הוא משקף את ההגדרה המוצגת בפוסט בבלוג של [Spring (2 אפריל 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## התחלה מהירה (מקומי)

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

## בדיקת תצורת OAuth2

ניתן לבדוק את תצורת האבטחה של OAuth2 באמצעות השלבים הבאים:

### 1. ודא שהשרת פועל ומאובטח

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. קבל אסימון גישה באמצעות אישורי לקוח

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

הערה: הכותרת של Basic Authentication (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. גש לנקודת הקצה המוגנת באמצעות האסימון

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

תגובה מוצלחת עם "Hello from MCP OAuth2 Demo!" מאשרת שהתצורה של OAuth2 עובדת כראוי.

---

## בניית מיכל

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## פריסה ל-**Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

ה-FQDN של הכניסה הופך ל**issuer** שלך (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## חיבור ל-**Azure API Management**

הוסף מדיניות נכנסת זו ל-API שלך:

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

APIM יבצע אחזור של JWKS ויאמת כל בקשה.

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, אנא היו מודעים לכך שתרגומים אוטומטיים עשויים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור הסמכותי. למידע קריטי, מומלץ להשתמש בתרגום מקצועי על ידי בני אדם. אנו לא נושאים באחריות לכל אי הבנות או פירושים שגויים הנובעים משימוש בתרגום זה.