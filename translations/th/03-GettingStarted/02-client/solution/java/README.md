<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:11:31+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "th"
}
-->
# MCP Java Client - Calculator Demo

โปรเจกต์นี้แสดงวิธีการสร้าง Java client ที่เชื่อมต่อและโต้ตอบกับ MCP (Model Context Protocol) server ในตัวอย่างนี้ เราจะเชื่อมต่อกับ calculator server จากบทที่ 01 และทำการคำนวณทางคณิตศาสตร์ต่างๆ

## สิ่งที่ต้องเตรียม

ก่อนรัน client นี้ คุณต้อง:

1. **เริ่มต้น Calculator Server** จากบทที่ 01:
   - ไปที่โฟลเดอร์ของ calculator server: `03-GettingStarted/01-first-server/solution/java/`
   - สร้างและรัน calculator server:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - เซิร์ฟเวอร์ควรจะรันอยู่ที่ `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` เป็นแอปพลิเคชัน Java ที่สาธิตวิธีการ:
- เชื่อมต่อกับ MCP server โดยใช้ Server-Sent Events (SSE) transport
- แสดงรายการเครื่องมือที่มีจากเซิร์ฟเวอร์
- เรียกใช้งานฟังก์ชัน calculator ต่างๆ จากระยะไกล
- จัดการกับการตอบกลับและแสดงผลลัพธ์

## วิธีการทำงาน

Client ใช้ Spring AI MCP framework เพื่อ:

1. **สร้างการเชื่อมต่อ**: สร้าง WebFlux SSE client transport เพื่อเชื่อมต่อกับ calculator server
2. **เริ่มต้น Client**: ตั้งค่า MCP client และสร้างการเชื่อมต่อ
3. **ค้นหาเครื่องมือ**: แสดงรายการการทำงาน calculator ทั้งหมดที่มี
4. **เรียกใช้งาน**: เรียกใช้ฟังก์ชันทางคณิตศาสตร์ต่างๆ ด้วยข้อมูลตัวอย่าง
5. **แสดงผลลัพธ์**: แสดงผลลัพธ์ของแต่ละการคำนวณ

## โครงสร้างโปรเจกต์

```
src/
└── main/
    └── java/
        └── com/
            └── microsoft/
                └── mcp/
                    └── sample/
                        └── client/
                            └── SDKClient.java    # Main client implementation
```

## ไลบรารีหลักที่ใช้

โปรเจกต์นี้ใช้ไลบรารีหลักดังนี้:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

ไลบรารีนี้ให้:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - SSE transport สำหรับการสื่อสารผ่านเว็บ
- สคีมา MCP protocol และชนิดข้อมูล request/response

## การสร้างโปรเจกต์

สร้างโปรเจกต์โดยใช้ Maven wrapper:

```cmd
.\mvnw clean install
```

## การรัน Client

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**หมายเหตุ**: ตรวจสอบให้แน่ใจว่า calculator server รันอยู่ที่ `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **แสดงรายการเครื่องมือ** - แสดงการทำงาน calculator ทั้งหมดที่มี
3. **ทำการคำนวณ**:
   - บวก: 5 + 3 = 8
   - ลบ: 10 - 4 = 6
   - คูณ: 6 × 7 = 42
   - หาร: 20 ÷ 4 = 5
   - ยกกำลัง: 2^8 = 256
   - รากที่สอง: √16 = 4
   - ค่าสัมบูรณ์: |-5.5| = 5.5
   - ช่วยเหลือ: แสดงการทำงานที่มี

## ผลลัพธ์ที่คาดหวัง

```
Available Tools = ListToolsResult[tools=[Tool[name=add, description=Add two numbers together, ...], ...]]
Add Result = CallToolResult[content=[TextContent[text="5,00 + 3,00 = 8,00"]], isError=false]
Subtract Result = CallToolResult[content=[TextContent[text="10,00 - 4,00 = 6,00"]], isError=false]
Multiply Result = CallToolResult[content=[TextContent[text="6,00 * 7,00 = 42,00"]], isError=false]
Divide Result = CallToolResult[content=[TextContent[text="20,00 / 4,00 = 5,00"]], isError=false]
Power Result = CallToolResult[content=[TextContent[text="2,00 ^ 8,00 = 256,00"]], isError=false]
Square Root Result = CallToolResult[content=[TextContent[text="√16,00 = 4,00"]], isError=false]
Absolute Result = CallToolResult[content=[TextContent[text="|-5,50| = 5,50"]], isError=false]
Help = CallToolResult[content=[TextContent[text="Basic Calculator MCP Service\n\nAvailable operations:\n1. add(a, b) - Adds two numbers\n2. subtract(a, b) - Subtracts the second number from the first\n..."]], isError=false]
```

**หมายเหตุ**: อาจเห็นคำเตือนของ Maven เกี่ยวกับเธรดที่ยังทำงานอยู่ตอนจบ - เป็นเรื่องปกติของแอปพลิเคชันแบบ reactive และไม่ใช่ข้อผิดพลาด

## ทำความเข้าใจโค้ด

### 1. การตั้งค่า Transport
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
ส่วนนี้สร้าง SSE (Server-Sent Events) transport ที่เชื่อมต่อกับ calculator server

### 2. การสร้าง Client
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
สร้าง MCP client แบบ synchronous และเริ่มต้นการเชื่อมต่อ

### 3. การเรียกใช้งานเครื่องมือ
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
เรียกใช้เครื่องมือ "add" พร้อมพารามิเตอร์ a=5.0 และ b=3.0

## การแก้ไขปัญหา

### เซิร์ฟเวอร์ไม่ทำงาน
ถ้าเกิดข้อผิดพลาดเชื่อมต่อ ให้ตรวจสอบว่า calculator server จากบทที่ 01 กำลังรันอยู่:
```
Error: Connection refused
```
**วิธีแก้ไข**: เริ่มต้น calculator server ก่อน

### พอร์ตถูกใช้งานแล้ว
ถ้าพอร์ต 8080 ถูกใช้งาน:
```
Error: Address already in use
```
**วิธีแก้ไข**: ปิดแอปพลิเคชันอื่นที่ใช้พอร์ต 8080 หรือเปลี่ยนพอร์ตของเซิร์ฟเวอร์

### ข้อผิดพลาดในการสร้างโปรเจกต์
ถ้าเจอข้อผิดพลาดตอน build:
```cmd
.\mvnw clean install -DskipTests
```

## เรียนรู้เพิ่มเติม

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความคลาดเคลื่อน เอกสารต้นฉบับในภาษาต้นทางควรถูกพิจารณาเป็นแหล่งข้อมูลที่ถูกต้องและเชื่อถือได้ สำหรับข้อมูลที่สำคัญ ควรใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้