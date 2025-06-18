<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f01d4263fc6eec331615fef42429b720",
  "translation_date": "2025-06-18T18:21:41+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "th"
}
-->
### -2- สร้างโปรเจกต์

ตอนนี้ที่คุณได้ติดตั้ง SDK แล้ว ขั้นตอนต่อไปคือการสร้างโปรเจกต์กันเลย:

### -3- สร้างไฟล์โปรเจกต์

### -4- เขียนโค้ดเซิร์ฟเวอร์

### -5- เพิ่มเครื่องมือและแหล่งข้อมูล

เพิ่มเครื่องมือและแหล่งข้อมูลโดยเพิ่มโค้ดดังต่อไปนี้:

### -6 โค้ดสุดท้าย

มาเพิ่มโค้ดส่วนสุดท้ายที่จำเป็นเพื่อให้เซิร์ฟเวอร์สามารถเริ่มทำงานได้:

### -7- ทดสอบเซิร์ฟเวอร์

เริ่มเซิร์ฟเวอร์ด้วยคำสั่งดังนี้:

### -8- รันด้วย inspector

inspector เป็นเครื่องมือที่ยอดเยี่ยมที่ช่วยให้คุณเริ่มเซิร์ฟเวอร์และโต้ตอบกับมันเพื่อทดสอบการทำงานของเซิร์ฟเวอร์ มาเริ่มใช้งานกัน:

> [!NOTE]
> อาจจะเห็นแตกต่างในช่อง "command" เพราะมันแสดงคำสั่งสำหรับรันเซิร์ฟเวอร์ด้วย runtime ที่คุณใช้

คุณจะเห็นส่วนติดต่อผู้ใช้ดังนี้:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.th.png)

1. เชื่อมต่อกับเซิร์ฟเวอร์โดยเลือกปุ่ม Connect
  เมื่อเชื่อมต่อสำเร็จ คุณจะเห็นดังนี้:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.th.png)

2. เลือก "Tools" และ "listTools" คุณจะเห็น "Add" ปรากฏขึ้น เลือก "Add" แล้วกรอกค่าพารามิเตอร์

  คุณจะเห็นผลลัพธ์ดังนี้ ซึ่งเป็นผลลัพธ์จากเครื่องมือ "add":

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.th.png)

ขอแสดงความยินดี คุณสามารถสร้างและรันเซิร์ฟเวอร์ตัวแรกของคุณได้สำเร็จ!

### SDK อย่างเป็นทางการ

MCP มี SDK อย่างเป็นทางการสำหรับหลายภาษา:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - ร่วมมือกับ Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - ร่วมมือกับ Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - การใช้งาน TypeScript อย่างเป็นทางการ
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - การใช้งาน Python อย่างเป็นทางการ
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - การใช้งาน Kotlin อย่างเป็นทางการ
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - ร่วมมือกับ Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - การใช้งาน Rust อย่างเป็นทางการ

## สรุปสำคัญ

- การตั้งค่าสภาพแวดล้อมการพัฒนา MCP ทำได้ง่ายด้วย SDK เฉพาะภาษา
- การสร้างเซิร์ฟเวอร์ MCP ต้องสร้างและลงทะเบียนเครื่องมือพร้อม schema ที่ชัดเจน
- การทดสอบและดีบักเป็นสิ่งจำเป็นสำหรับการใช้งาน MCP ที่น่าเชื่อถือ

## ตัวอย่าง

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## แบบฝึกหัด

สร้างเซิร์ฟเวอร์ MCP ง่ายๆ พร้อมเครื่องมือที่คุณเลือก:

1. พัฒนาเครื่องมือในภาษาที่คุณถนัด (.NET, Java, Python หรือ JavaScript)
2. กำหนดพารามิเตอร์นำเข้าและค่าที่ส่งกลับ
3. รันเครื่องมือ inspector เพื่อตรวจสอบว่าเซิร์ฟเวอร์ทำงานได้ตามที่ต้องการ
4. ทดสอบการใช้งานด้วยค่าต่างๆ

## คำตอบ

[คำตอบ](./solution/README.md)

## แหล่งข้อมูลเพิ่มเติม

- [สร้าง Agents โดยใช้ Model Context Protocol บน Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP กับ Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## ต่อไป

ถัดไป: [เริ่มต้นใช้งาน MCP Clients](/03-GettingStarted/02-client/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาด้วย AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางควรถูกพิจารณาเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้การแปลโดยมนุษย์ผู้เชี่ยวชาญ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดขึ้นจากการใช้การแปลนี้