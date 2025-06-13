<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a7083e660ca0d85fd6a947514c61993",
  "translation_date": "2025-06-12T23:57:12+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "th"
}
-->
# MCP OAuth2 Demo

โปรเจกต์นี้เป็น **แอปพลิเคชัน Spring Boot ขนาดเล็ก** ที่ทำหน้าที่ทั้ง:

* เป็น **Spring Authorization Server** (ออก JWT access token ผ่าน flow `client_credentials`), และ  
* เป็น **Resource Server** (ปกป้อง endpoint `/hello` ของตัวเอง)

ซึ่งเหมือนกับการตั้งค่าที่แสดงใน [Spring blog post (2 Apr 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2)

---

## เริ่มต้นอย่างรวดเร็ว (ในเครื่อง)

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

## การทดสอบการตั้งค่า OAuth2

คุณสามารถทดสอบการตั้งค่าความปลอดภัย OAuth2 ด้วยขั้นตอนดังนี้:

### 1. ตรวจสอบว่าเซิร์ฟเวอร์กำลังทำงานและมีการป้องกัน

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. รับ access token โดยใช้ client credentials

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

หมายเหตุ: Header Basic Authentication คือ (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`

### 3. เข้าถึง endpoint ที่ถูกป้องกันโดยใช้ token

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

ถ้าตอบกลับสำเร็จด้วยข้อความ "Hello from MCP OAuth2 Demo!" แสดงว่าการตั้งค่า OAuth2 ทำงานถูกต้อง

---

## การสร้าง Container

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## การดีพลอยไปยัง **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Ingress FQDN จะกลายเป็น **issuer** ของคุณ (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`)

---

## การเชื่อมต่อกับ **Azure API Management**

เพิ่มนโยบาย inbound นี้ไปยัง API ของคุณ:

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

APIM จะดึง JWKS และตรวจสอบความถูกต้องของทุกคำขอ

---

## ต่อไปคืออะไร

- [5.4 Root contexts](../mcp-root-contexts/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาด้วย AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้มีความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความคลาดเคลื่อนได้ เอกสารต้นฉบับในภาษาดั้งเดิมถือเป็นแหล่งข้อมูลที่ถูกต้องและเชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญด้านภาษามนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้