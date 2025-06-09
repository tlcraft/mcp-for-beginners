<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2d6413f234258f6bbc8189c463e510ee",
  "translation_date": "2025-06-02T19:16:40+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "he"
}
-->
# הדגמת MCP OAuth2

הפרויקט הזה הוא **אפליקציית Spring Boot מינימלית** שפועלת גם בתור:

* **שרת הרשאות Spring** (מנפיק אסימוני גישה JWT דרך הזרימה `client_credentials`), וגם  
* **שרת משאבים** (מגן על נקודת הקצה שלו `/hello`).

זה משקף את ההגדרה המוצגת ב-[פוסט הבלוג של Spring (2 באפריל 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## התחלה מהירה (מקומית)

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

ניתן לבדוק את תצורת האבטחה של OAuth2 עם השלבים הבאים:

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

[!NOTE] כותרת ה-Basic Authentication היא (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. גש לנקודת הקצה המוגנת באמצעות האסימון

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

תגובה מוצלחת עם "Hello from MCP OAuth2 Demo!" מאשרת שהתצורה של OAuth2 פועלת כראוי.

---

## בניית מכולה

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

שם המארח (FQDN) של ה-ingress יהפוך ל-**issuer** שלך (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## חיבור ל-**Azure API Management**

הוסף מדיניות זו ל-API שלך:

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

APIM ימשוך את ה-JWKS ויוודא כל בקשה.

---

## מה הלאה

- [Root contexts](../mcp-root-contexts/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. יש להתייחס למסמך המקורי בשפת המקור כמקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי הבנה או פרשנות שגויה הנובעים משימוש בתרגום זה.