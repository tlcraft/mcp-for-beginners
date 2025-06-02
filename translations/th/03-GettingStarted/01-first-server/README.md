<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:10:15+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "th"
}
-->
### -2- สร้างโปรเจกต์

ตอนนี้ที่คุณได้ติดตั้ง SDK แล้ว ขั้นตอนถัดไปคือการสร้างโปรเจกต์กันเถอะ:

### -3- สร้างไฟล์โปรเจกต์

### -4- เขียนโค้ดเซิร์ฟเวอร์

### -5- เพิ่มเครื่องมือและทรัพยากร

เพิ่มเครื่องมือและทรัพยาดังนี้:

### -6 โค้ดขั้นสุดท้าย

มาเพิ่มโค้ดส่วนสุดท้ายที่จำเป็นเพื่อให้เซิร์ฟเวอร์สามารถเริ่มทำงานได้:

### -7- ทดสอบเซิร์ฟเวอร์

เริ่มเซิร์ฟเวอร์ด้วยคำสั่งดังนี้:

### -8- รันด้วย inspector

Inspector เป็นเครื่องมือที่ดีมากที่ช่วยให้คุณเริ่มเซิร์ฟเวอร์และโต้ตอบกับมันเพื่อทดสอบการทำงาน มาเริ่มกันเลย:

> [!NOTE]
> อาจจะเห็นแตกต่างในช่อง "command" เพราะมีคำสั่งสำหรับรันเซิร์ฟเวอร์ด้วย runtime ที่คุณเลือกใช้

คุณจะเห็นอินเทอร์เฟซผู้ใช้ดังนี้:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.th.png)

1. เชื่อมต่อกับเซิร์ฟเวอร์โดยการเลือกปุ่ม Connect  
   เมื่อเชื่อมต่อสำเร็จ คุณจะเห็นดังนี้:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.th.png)

2. เลือก "Tools" และ "listTools" คุณจะเห็นตัวเลือก "Add" ปรากฏขึ้น เลือก "Add" และกรอกค่าพารามิเตอร์

   คุณจะเห็นผลลัพธ์ดังนี้ ซึ่งเป็นผลลัพธ์จากเครื่องมือ "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.th.png)

ยินดีด้วย คุณได้สร้างและรันเซิร์ฟเวอร์แรกของคุณสำเร็จแล้ว!

### Official SDKs

MCP มี SDK อย่างเป็นทางการสำหรับหลายภาษา:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - ดูแลร่วมกับ Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - ดูแลร่วมกับ Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - การใช้งาน TypeScript อย่างเป็นทางการ
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - การใช้งาน Python อย่างเป็นทางการ
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - การใช้งาน Kotlin อย่างเป็นทางการ
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - ดูแลร่วมกับ Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - การใช้งาน Rust อย่างเป็นทางการ

## สิ่งสำคัญที่ควรจดจำ

- การตั้งค่าสภาพแวดล้อมการพัฒนา MCP ทำได้ง่ายด้วย SDK เฉพาะภาษาต่างๆ
- การสร้างเซิร์ฟเวอร์ MCP ต้องสร้างและลงทะเบียนเครื่องมือพร้อมสคีมาที่ชัดเจน
- การทดสอบและดีบักเป็นสิ่งจำเป็นเพื่อให้การใช้งาน MCP เชื่อถือได้

## ตัวอย่าง

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## การบ้าน

สร้างเซิร์ฟเวอร์ MCP ง่ายๆ พร้อมเครื่องมือที่คุณเลือก:
1. เขียนเครื่องมือในภาษาที่คุณถนัด (.NET, Java, Python หรือ JavaScript)
2. กำหนดพารามิเตอร์อินพุตและค่าผลลัพธ์
3. รันเครื่องมือ inspector เพื่อให้แน่ใจว่าเซิร์ฟเวอร์ทำงานถูกต้อง
4. ทดสอบการทำงานด้วยข้อมูลอินพุตหลากหลาย

## วิธีแก้ไข

[Solution](./solution/README.md)

## แหล่งข้อมูลเพิ่มเติม

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## ต่อไป

ถัดไป: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความคลาดเคลื่อนได้ เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลสำคัญแนะนำให้ใช้บริการแปลโดยมืออาชีพที่เป็นมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดขึ้นจากการใช้การแปลนี้