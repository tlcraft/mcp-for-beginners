<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:27:57+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "th"
}
-->
# Calculator LLM Client

แอปพลิเคชัน Java ที่แสดงตัวอย่างการใช้ LangChain4j เพื่อเชื่อมต่อกับบริการเครื่องคิดเลข MCP (Model Context Protocol) ที่มีการรวม GitHub Models

## ข้อกำหนดเบื้องต้น

- Java 21 ขึ้นไป  
- Maven 3.6+ (หรือใช้ Maven wrapper ที่รวมมาให้)  
- บัญชี GitHub ที่มีสิทธิ์เข้าถึง GitHub Models  
- บริการเครื่องคิดเลข MCP ที่กำลังรันอยู่บน `http://localhost:8080`  

## การขอรับ GitHub Token

แอปนี้ใช้ GitHub Models ซึ่งต้องใช้ GitHub personal access token ทำตามขั้นตอนเหล่านี้เพื่อรับ token ของคุณ:

### 1. เข้าถึง GitHub Models  
1. ไปที่ [GitHub Models](https://github.com/marketplace/models)  
2. ลงชื่อเข้าใช้ด้วยบัญชี GitHub ของคุณ  
3. ขอสิทธิ์เข้าถึง GitHub Models หากยังไม่ได้รับ  

### 2. สร้าง Personal Access Token  
1. ไปที่ [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)  
2. คลิก "Generate new token" → "Generate new token (classic)"  
3. ตั้งชื่อ token ให้สื่อความหมาย (เช่น "MCP Calculator Client")  
4. กำหนดวันหมดอายุตามต้องการ  
5. เลือก scope ดังนี้:  
   - `repo` (ถ้าต้องการเข้าถึง private repositories)  
   - `user:email`  
6. คลิก "Generate token"  
7. **สำคัญ**: คัดลอก token ทันที - คุณจะไม่สามารถดูได้อีกครั้ง!  

### 3. ตั้งค่าตัวแปรสภาพแวดล้อม

#### บน Windows (Command Prompt):  
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### บน Windows (PowerShell):  
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### บน macOS/Linux:  
```bash
export GITHUB_TOKEN=your_github_token_here
```

## การติดตั้งและตั้งค่า

1. **โคลนหรือเข้าไปยังโฟลเดอร์โปรเจกต์**

2. **ติดตั้ง dependencies**:  
   ```cmd
   mvnw clean install
   ```  
   หรือถ้าคุณติดตั้ง Maven ไว้ทั่วระบบแล้ว:  
   ```cmd
   mvn clean install
   ```

3. **ตั้งค่าตัวแปรสภาพแวดล้อม** (ดูหัวข้อ "การขอรับ GitHub Token" ข้างต้น)

4. **เริ่มต้นบริการ MCP Calculator**:  
   ตรวจสอบให้แน่ใจว่าบริการ MCP calculator ในบทที่ 1 กำลังรันอยู่ที่ `http://localhost:8080/sse` ก่อนเริ่มใช้งาน client

## การรันแอปพลิเคชัน

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## แอปพลิเคชันทำอะไร

แอปนี้แสดงตัวอย่างการโต้ตอบหลัก 3 อย่างกับบริการเครื่องคิดเลข:

1. **การบวก**: คำนวณผลรวมของ 24.5 และ 17.3  
2. **รากที่สอง**: คำนวณรากที่สองของ 144  
3. **ช่วยเหลือ**: แสดงฟังก์ชันเครื่องคิดเลขที่มีให้ใช้  

## ผลลัพธ์ที่คาดหวัง

เมื่อรันสำเร็จ คุณจะเห็นผลลัพธ์ประมาณนี้:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## การแก้ไขปัญหา

### ปัญหาที่พบบ่อย

1. **"GITHUB_TOKEN environment variable not set"**  
   - ตรวจสอบว่าคุณได้ตั้งค่าตัวแปร `GITHUB_TOKEN` แล้วหรือยัง  

### การดีบัก

หากต้องการเปิดใช้งาน debug logging ให้เพิ่มอาร์กิวเมนต์ JVM นี้ตอนรัน:  
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## การตั้งค่า

แอปนี้ตั้งค่าให้:  
- ใช้ GitHub Models กับ `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`  
- ตั้งเวลารอคำขอ 60 วินาที  
- เปิดใช้งานการบันทึกคำขอ/คำตอบเพื่อช่วยดีบัก  

## ไลบรารีที่ใช้

ไลบรารีหลักที่ใช้ในโปรเจกต์นี้:  
- **LangChain4j**: สำหรับการรวม AI และจัดการเครื่องมือ  
- **LangChain4j MCP**: สำหรับรองรับ Model Context Protocol  
- **LangChain4j GitHub Models**: สำหรับการรวม GitHub Models  
- **Spring Boot**: สำหรับโครงสร้างแอปพลิเคชันและการฉีดพึ่งพา  

## ใบอนุญาต

โปรเจกต์นี้ได้รับอนุญาตภายใต้ Apache License 2.0 - ดูรายละเอียดได้ที่ไฟล์ [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาด้วย AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความคลาดเคลื่อน เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่น่าเชื่อถือ สำหรับข้อมูลสำคัญ แนะนำให้ใช้การแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้