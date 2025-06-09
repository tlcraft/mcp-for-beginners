<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:34:38+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "th"
}
-->
### -2- สร้างโปรเจกต์

ตอนนี้ที่คุณติดตั้ง SDK เรียบร้อยแล้ว มาสร้างโปรเจกต์กันต่อเลย:

### -3- สร้างไฟล์โปรเจกต์

### -4- เขียนโค้ดเซิร์ฟเวอร์

### -5- เพิ่มเครื่องมือและทรัพยากร

เพิ่มเครื่องมือและทรัพยากรโดยเพิ่มโค้ดดังนี้:

### -6 โค้ดสุดท้าย

มาเพิ่มโค้ดสุดท้ายที่จำเป็นเพื่อให้เซิร์ฟเวอร์เริ่มทำงานได้:

### -7- ทดสอบเซิร์ฟเวอร์

เริ่มเซิร์ฟเวอร์ด้วยคำสั่งดังนี้:

### -8- รันด้วย inspector

Inspector เป็นเครื่องมือที่ยอดเยี่ยมที่ช่วยให้คุณเริ่มเซิร์ฟเวอร์และโต้ตอบกับมันเพื่อทดสอบว่าใช้งานได้หรือไม่ มาเริ่มกันเลย:

> [!NOTE]
> ในช่อง "command" อาจจะดูต่างออกไปเพราะมีคำสั่งสำหรับรันเซิร์ฟเวอร์ด้วย runtime เฉพาะของคุณ

คุณจะเห็นอินเทอร์เฟซผู้ใช้ดังนี้:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.th.png)

1. เชื่อมต่อกับเซิร์ฟเวอร์โดยกดปุ่ม Connect  
   เมื่อเชื่อมต่อสำเร็จ คุณจะเห็นหน้าจอดังนี้:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.th.png)

2. เลือก "Tools" และ "listTools" คุณจะเห็น "Add" ปรากฏขึ้น ให้เลือก "Add" และกรอกค่าพารามิเตอร์

   คุณจะเห็นผลลัพธ์ดังนี้ คือผลลัพธ์จากเครื่องมือ "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.th.png)

ยินดีด้วย คุณสามารถสร้างและรันเซิร์ฟเวอร์ตัวแรกของคุณได้สำเร็จ!

### SDK อย่างเป็นทางการ

MCP มี SDK อย่างเป็นทางการสำหรับหลายภาษา:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - ร่วมมือกับ Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - ร่วมมือกับ Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - เวอร์ชัน TypeScript อย่างเป็นทางการ
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - เวอร์ชัน Python อย่างเป็นทางการ
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - เวอร์ชัน Kotlin อย่างเป็นทางการ
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - ร่วมมือกับ Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - เวอร์ชัน Rust อย่างเป็นทางการ

## สรุปประเด็นสำคัญ

- การตั้งค่าสภาพแวดล้อมการพัฒนา MCP ทำได้ง่ายด้วย SDK เฉพาะภาษา
- การสร้างเซิร์ฟเวอร์ MCP คือการสร้างและลงทะเบียนเครื่องมือที่มี schema ชัดเจน
- การทดสอบและดีบักเป็นสิ่งสำคัญสำหรับการใช้งาน MCP ที่เชื่อถือได้

## ตัวอย่าง

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## แบบฝึกหัด

สร้างเซิร์ฟเวอร์ MCP ง่ายๆ พร้อมเครื่องมือที่คุณเลือก:
1. พัฒนาเครื่องมือด้วยภาษาที่คุณถนัด (.NET, Java, Python หรือ JavaScript)
2. กำหนดพารามิเตอร์นำเข้าและค่าผลลัพธ์
3. รันเครื่องมือ inspector เพื่อตรวจสอบว่าเซิร์ฟเวอร์ทำงานถูกต้อง
4. ทดสอบการใช้งานด้วยข้อมูลนำเข้าหลากหลายรูปแบบ

## คำตอบ

[คำตอบ](./solution/README.md)

## แหล่งข้อมูลเพิ่มเติม

- [สร้าง Agents ด้วย Model Context Protocol บน Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP กับ Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## ต่อไป

ถัดไป: [เริ่มต้นกับ MCP Clients](/03-GettingStarted/02-client/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ความถูกต้อง แต่โปรดทราบว่าการแปลโดยอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นฉบับควรถูกพิจารณาเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยมนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดที่เกิดจากการใช้การแปลนี้