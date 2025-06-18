<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:47:07+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "th"
}
-->
# Calculator HTTP Streaming Demo

โปรเจกต์นี้แสดงตัวอย่างการสตรีม HTTP โดยใช้ Server-Sent Events (SSE) กับ Spring Boot WebFlux ประกอบด้วยแอปพลิเคชันสองตัว:

- **Calculator Server**: เว็บเซอร์วิสแบบ reactive ที่ทำการคำนวณและสตรีมผลลัพธ์ด้วย SSE
- **Calculator Client**: แอปพลิเคชันฝั่งไคลเอนต์ที่รับข้อมูลจากจุดเชื่อมต่อสตรีมมิ่ง

## ข้อกำหนดเบื้องต้น

- Java 17 ขึ้นไป
- Maven 3.6 ขึ้นไป

## โครงสร้างโปรเจกต์

```
java/
├── calculator-server/     # Spring Boot server with SSE endpoint
│   ├── src/main/java/com/example/calculatorserver/
│   │   ├── CalculatorServerApplication.java
│   │   └── CalculatorController.java
│   └── pom.xml
├── calculator-client/     # Spring Boot client application
│   ├── src/main/java/com/example/calculatorclient/
│   │   └── CalculatorClientApplication.java
│   └── pom.xml
└── README.md
```

## วิธีการทำงาน

1. **Calculator Server** เปิดเผย endpoint `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - รับข้อมูลสตรีมมิ่งจากเซิร์ฟเวอร์
   - แสดงแต่ละเหตุการณ์ในคอนโซล

## การรันแอปพลิเคชัน

### ตัวเลือกที่ 1: ใช้ Maven (แนะนำ)

#### 1. เริ่มต้น Calculator Server

เปิดเทอร์มินัลและไปยังไดเรกทอรีของเซิร์ฟเวอร์:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

เซิร์ฟเวอร์จะเริ่มทำงานที่ `http://localhost:8080`

คุณจะเห็นผลลัพธ์ประมาณนี้:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. รัน Calculator Client

เปิด **เทอร์มินัลใหม่** และไปยังไดเรกทอรีของไคลเอนต์:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

ไคลเอนต์จะเชื่อมต่อกับเซิร์ฟเวอร์ ทำการคำนวณ และแสดงผลลัพธ์แบบสตรีมมิ่ง

### ตัวเลือกที่ 2: ใช้ Java โดยตรง

#### 1. คอมไพล์และรันเซิร์ฟเวอร์:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. คอมไพล์และรันไคลเอนต์:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## การทดสอบเซิร์ฟเวอร์ด้วยตัวเอง

คุณสามารถทดสอบเซิร์ฟเวอร์ด้วยเว็บเบราว์เซอร์หรือ curl ได้เช่นกัน:

### ใช้เว็บเบราว์เซอร์:
เข้าไปที่: `http://localhost:8080/calculate?a=10&b=5&op=add`

### ใช้ curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## ผลลัพธ์ที่คาดหวัง

เมื่อรันไคลเอนต์ คุณจะเห็นผลลัพธ์แบบสตรีมมิ่งคล้ายกับ:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## การดำเนินการที่รองรับ

- `add` - Addition (a + b)
- `sub` - Subtraction (a - b)
- `mul` - Multiplication (a * b)
- `div` - Division (a / b, returns NaN if b = 0)

## API Reference

### GET /calculate

**Parameters:**
- `a` (required): First number (double)
- `b` (required): Second number (double)
- `op` (required): Operation (`add`, `sub`, `mul`, `div`)

**Response:**
- Content-Type: `text/event-stream`
- ส่งกลับ Server-Sent Events ที่แสดงความคืบหน้าและผลลัพธ์ของการคำนวณ

**ตัวอย่างคำขอ:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**ตัวอย่างคำตอบ:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## การแก้ไขปัญหา

### ปัญหาที่พบบ่อย

1. **พอร์ต 8080 ถูกใช้งานอยู่แล้ว**
   - หยุดแอปพลิเคชันอื่นที่ใช้พอร์ต 8080
   - หรือเปลี่ยนพอร์ตเซิร์ฟเวอร์ใน `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` หากรันเป็นโปรเซสเบื้องหลัง

## เทคโนโลยีที่ใช้

- **Spring Boot 3.3.1** - เฟรมเวิร์กแอปพลิเคชัน
- **Spring WebFlux** - เฟรมเวิร์กเว็บแบบ reactive
- **Project Reactor** - ไลบรารี reactive streams
- **Netty** - เซิร์ฟเวอร์แบบ non-blocking I/O
- **Maven** - เครื่องมือสร้างโปรเจกต์
- **Java 17+** - ภาษาโปรแกรม

## ขั้นตอนถัดไป

ลองแก้ไขโค้ดเพื่อ:
- เพิ่มการดำเนินการทางคณิตศาสตร์เพิ่มเติม
- เพิ่มการจัดการข้อผิดพลาดสำหรับการดำเนินการที่ไม่ถูกต้อง
- เพิ่มการบันทึกคำขอ/คำตอบ
- เพิ่มระบบตรวจสอบสิทธิ์
- เขียน unit test เพิ่มเติม

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้มีความถูกต้องสูงสุด โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่แม่นยำ เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญแนะนำให้ใช้บริการแปลโดยมืออาชีพ เรายังไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดใดๆ ที่เกิดจากการใช้การแปลนี้