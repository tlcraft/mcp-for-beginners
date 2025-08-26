<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "858362ce0118de3fec0f9114bf396101",
  "translation_date": "2025-08-18T14:29:12+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "th"
}
-->
## เริ่มต้นใช้งาน  

[![สร้างเซิร์ฟเวอร์ MCP แรกของคุณ](../../../translated_images/04.0ea920069efd979a0b2dad51e72c1df7ead9c57b3305796068a6cee1f0dd6674.th.png)](https://youtu.be/sNDZO9N4m9Y)

_(คลิกที่ภาพด้านบนเพื่อดูวิดีโอของบทเรียนนี้)_

ส่วนนี้ประกอบด้วยบทเรียนหลายหัวข้อ:

- **1 เซิร์ฟเวอร์แรกของคุณ** ในบทเรียนแรกนี้ คุณจะได้เรียนรู้วิธีสร้างเซิร์ฟเวอร์แรกของคุณและตรวจสอบด้วยเครื่องมือ Inspector ซึ่งเป็นวิธีที่มีประโยชน์ในการทดสอบและดีบักเซิร์ฟเวอร์ของคุณ [ไปที่บทเรียน](01-first-server/README.md)

- **2 ไคลเอนต์** ในบทเรียนนี้ คุณจะได้เรียนรู้วิธีเขียนไคลเอนต์ที่สามารถเชื่อมต่อกับเซิร์ฟเวอร์ของคุณ [ไปที่บทเรียน](02-client/README.md)

- **3 ไคลเอนต์พร้อม LLM** วิธีที่ดียิ่งขึ้นในการเขียนไคลเอนต์คือการเพิ่ม LLM เพื่อให้สามารถ "เจรจา" กับเซิร์ฟเวอร์ของคุณเกี่ยวกับสิ่งที่ต้องทำ [ไปที่บทเรียน](03-llm-client/README.md)

- **4 การใช้งานเซิร์ฟเวอร์ในโหมด GitHub Copilot Agent บน Visual Studio Code** ในหัวข้อนี้ เราจะดูการรัน MCP Server ของเราภายใน Visual Studio Code [ไปที่บทเรียน](04-vscode/README.md)

- **5 การใช้งานจาก SSE (Server Sent Events)** SSE เป็นมาตรฐานสำหรับการสตรีมจากเซิร์ฟเวอร์ไปยังไคลเอนต์ ช่วยให้เซิร์ฟเวอร์สามารถส่งการอัปเดตแบบเรียลไทม์ไปยังไคลเอนต์ผ่าน HTTP [ไปที่บทเรียน](05-sse-server/README.md)

- **6 การสตรีม HTTP กับ MCP (Streamable HTTP)** เรียนรู้เกี่ยวกับการสตรีม HTTP สมัยใหม่ การแจ้งเตือนความคืบหน้า และวิธีการสร้าง MCP เซิร์ฟเวอร์และไคลเอนต์แบบเรียลไทม์ที่สามารถขยายได้โดยใช้ Streamable HTTP [ไปที่บทเรียน](06-http-streaming/README.md)

- **7 การใช้ AI Toolkit สำหรับ VSCode** เพื่อใช้งานและทดสอบ MCP Clients และ Servers ของคุณ [ไปที่บทเรียน](07-aitk/README.md)

- **8 การทดสอบ** ในหัวข้อนี้ เราจะเน้นวิธีการทดสอบเซิร์ฟเวอร์และไคลเอนต์ของคุณในรูปแบบต่างๆ [ไปที่บทเรียน](08-testing/README.md)

- **9 การปรับใช้งาน** บทนี้จะพิจารณาวิธีการต่างๆ ในการปรับใช้โซลูชัน MCP ของคุณ [ไปที่บทเรียน](09-deployment/README.md)

Model Context Protocol (MCP) เป็นโปรโตคอลแบบเปิดที่มาตรฐานการให้บริบทแก่ LLMs คิดว่า MCP เป็นเหมือนพอร์ต USB-C สำหรับแอปพลิเคชัน AI - มันให้วิธีการเชื่อมต่อโมเดล AI กับแหล่งข้อมูลและเครื่องมือต่างๆ ในรูปแบบที่เป็นมาตรฐาน

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- ตั้งค่าสภาพแวดล้อมการพัฒนาสำหรับ MCP ในภาษา C#, Java, Python, TypeScript และ JavaScript
- สร้างและปรับใช้ MCP เซิร์ฟเวอร์พื้นฐานพร้อมฟีเจอร์ที่กำหนดเอง (resources, prompts, และ tools)
- สร้างแอปพลิเคชันโฮสต์ที่เชื่อมต่อกับ MCP เซิร์ฟเวอร์
- ทดสอบและดีบักการใช้งาน MCP
- เข้าใจปัญหาการตั้งค่าทั่วไปและวิธีแก้ไข
- เชื่อมต่อการใช้งาน MCP ของคุณกับบริการ LLM ยอดนิยม

## การตั้งค่าสภาพแวดล้อม MCP ของคุณ

ก่อนที่คุณจะเริ่มทำงานกับ MCP สิ่งสำคัญคือต้องเตรียมสภาพแวดล้อมการพัฒนาและเข้าใจขั้นตอนการทำงานพื้นฐาน ส่วนนี้จะนำคุณผ่านขั้นตอนการตั้งค่าเริ่มต้นเพื่อให้เริ่มต้นกับ MCP ได้อย่างราบรื่น

### ข้อกำหนดเบื้องต้น

ก่อนที่จะเริ่มพัฒนา MCP ตรวจสอบให้แน่ใจว่าคุณมี:

- **สภาพแวดล้อมการพัฒนา**: สำหรับภาษาที่คุณเลือก (C#, Java, Python, TypeScript หรือ JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm หรือโปรแกรมแก้ไขโค้ดสมัยใหม่ใดๆ
- **ตัวจัดการแพ็กเกจ**: NuGet, Maven/Gradle, pip หรือ npm/yarn
- **API Keys**: สำหรับบริการ AI ใดๆ ที่คุณวางแผนจะใช้ในแอปพลิเคชันโฮสต์ของคุณ

### SDK อย่างเป็นทางการ

ในบทถัดไป คุณจะได้เห็นโซลูชันที่สร้างขึ้นโดยใช้ Python, TypeScript, Java และ .NET นี่คือ SDK ที่ได้รับการสนับสนุนอย่างเป็นทางการทั้งหมด

MCP มี SDK อย่างเป็นทางการสำหรับหลายภาษา:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - ดูแลร่วมกับ Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - ดูแลร่วมกับ Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - การใช้งาน TypeScript อย่างเป็นทางการ
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - การใช้งาน Python อย่างเป็นทางการ
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - การใช้งาน Kotlin อย่างเป็นทางการ
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - ดูแลร่วมกับ Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - การใช้งาน Rust อย่างเป็นทางการ

## ประเด็นสำคัญ

- การตั้งค่าสภาพแวดล้อมการพัฒนา MCP เป็นเรื่องง่ายด้วย SDK เฉพาะภาษา
- การสร้าง MCP เซิร์ฟเวอร์เกี่ยวข้องกับการสร้างและลงทะเบียนเครื่องมือด้วยสคีมาที่ชัดเจน
- ไคลเอนต์ MCP เชื่อมต่อกับเซิร์ฟเวอร์และโมเดลเพื่อใช้ความสามารถที่ขยายออกไป
- การทดสอบและดีบักเป็นสิ่งสำคัญสำหรับการใช้งาน MCP ที่เชื่อถือได้
- ตัวเลือกการปรับใช้มีตั้งแต่การพัฒนาท้องถิ่นไปจนถึงโซลูชันบนคลาวด์

## การฝึกฝน

เรามีชุดตัวอย่างที่เสริมการฝึกหัดที่คุณจะได้เห็นในทุกบทในส่วนนี้ นอกจากนี้แต่ละบทยังมีแบบฝึกหัดและการมอบหมายงานของตัวเอง

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## แหล่งข้อมูลเพิ่มเติม

- [สร้าง Agents โดยใช้ Model Context Protocol บน Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP กับ Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## ขั้นตอนถัดไป

ถัดไป: [การสร้าง MCP Server แรกของคุณ](01-first-server/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้การแปลมีความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่แม่นยำ เอกสารต้นฉบับในภาษาดั้งเดิมควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้บริการแปลภาษามนุษย์มืออาชีพ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดซึ่งเกิดจากการใช้การแปลนี้