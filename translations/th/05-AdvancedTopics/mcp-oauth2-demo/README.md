<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:41:59+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "th"
}
-->
# MCP OAuth2 Demo

โปรเจกต์นี้คือ **แอปพลิเคชัน Spring Boot ขนาดเล็ก** ที่ทำหน้าที่เป็นทั้ง:

* **Spring Authorization Server** (ออก JWT access tokens ผ่าน `client_credentials` flow), และ  
* **Resource Server** (ปกป้อง `/hello` endpoint ของตัวเอง)

มันเป็นการตั้งค่าที่แสดงใน [บล็อกโพสต์ของ Spring (2 เม.ย. 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2)

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

## ทดสอบการตั้งค่า OAuth2

คุณสามารถทดสอบการตั้งค่าความปลอดภัยของ OAuth2 ด้วยขั้นตอนต่อไปนี้:

### 1. ตรวจสอบว่าเซิร์ฟเวอร์กำลังทำงานและมีการรักษาความปลอดภัย

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

หมายเหตุ: ส่วนหัว Basic Authentication (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. เข้าถึง endpoint ที่ได้รับการปกป้องโดยใช้ token

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

การตอบสนองที่ประสบความสำเร็จพร้อมข้อความ "Hello from MCP OAuth2 Demo!" ยืนยันว่าการตั้งค่า OAuth2 ทำงานได้ถูกต้อง

---

## สร้าง Container

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## นำไปใช้กับ **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

FQDN ของ ingress จะกลายเป็น **issuer** ของคุณ (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## เชื่อมต่อกับ **Azure API Management**

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

APIM จะดึง JWKS และตรวจสอบทุกคำขอ

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ได้ความถูกต้องมากที่สุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาที่เป็นต้นฉบับควรถือว่าเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้บริการแปลภาษามนุษย์มืออาชีพ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้