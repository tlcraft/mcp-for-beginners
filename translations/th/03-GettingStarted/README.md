<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "860935ff95d05b006d1d3323e8e3f9e8",
  "translation_date": "2025-07-09T22:31:39+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "th"
}
-->
## เริ่มต้นใช้งาน  

ส่วนนี้ประกอบด้วยบทเรียนหลายบท:

- **1 เซิร์ฟเวอร์ตัวแรกของคุณ** ในบทเรียนแรกนี้ คุณจะได้เรียนรู้วิธีสร้างเซิร์ฟเวอร์ตัวแรกและตรวจสอบด้วยเครื่องมือ inspector ซึ่งเป็นวิธีที่มีประโยชน์ในการทดสอบและดีบักเซิร์ฟเวอร์ของคุณ [ไปยังบทเรียน](01-first-server/README.md)

- **2 Client** ในบทเรียนนี้ คุณจะได้เรียนรู้วิธีเขียน client ที่สามารถเชื่อมต่อกับเซิร์ฟเวอร์ของคุณได้ [ไปยังบทเรียน](02-client/README.md)

- **3 Client พร้อม LLM** วิธีที่ดียิ่งขึ้นในการเขียน client คือการเพิ่ม LLM เข้าไปเพื่อให้สามารถ "เจรจา" กับเซิร์ฟเวอร์ของคุณเกี่ยวกับสิ่งที่ต้องทำ [ไปยังบทเรียน](03-llm-client/README.md)

- **4 การใช้งานเซิร์ฟเวอร์ในโหมด GitHub Copilot Agent บน Visual Studio Code** ในส่วนนี้เราจะดูวิธีรัน MCP Server ของเราภายใน Visual Studio Code [ไปยังบทเรียน](04-vscode/README.md)

- **5 การใช้งานจาก SSE (Server Sent Events)** SSE เป็นมาตรฐานสำหรับการสตรีมข้อมูลจากเซิร์ฟเวอร์ไปยัง client ช่วยให้เซิร์ฟเวอร์ส่งข้อมูลอัปเดตแบบเรียลไทม์ไปยัง client ผ่าน HTTP [ไปยังบทเรียน](05-sse-server/README.md)

- **6 HTTP Streaming กับ MCP (Streamable HTTP)** เรียนรู้เกี่ยวกับการสตรีม HTTP สมัยใหม่ การแจ้งเตือนความคืบหน้า และวิธีการสร้าง MCP servers และ clients ที่สามารถขยายตัวได้แบบเรียลไทม์โดยใช้ Streamable HTTP [ไปยังบทเรียน](06-http-streaming/README.md)

- **7 การใช้ AI Toolkit สำหรับ VSCode** เพื่อใช้งานและทดสอบ MCP Clients และ Servers ของคุณ [ไปยังบทเรียน](07-aitk/README.md)

- **8 การทดสอบ** ในส่วนนี้เราจะเน้นวิธีการทดสอบเซิร์ฟเวอร์และ client ของเราในรูปแบบต่างๆ [ไปยังบทเรียน](08-testing/README.md)

- **9 การนำไปใช้งาน** บทนี้จะพูดถึงวิธีการต่างๆ ในการนำโซลูชัน MCP ของคุณไปใช้งาน [ไปยังบทเรียน](09-deployment/README.md)


Model Context Protocol (MCP) คือโปรโตคอลเปิดที่กำหนดมาตรฐานวิธีการที่แอปพลิเคชันส่งมอบบริบทให้กับ LLMs ลองนึกถึง MCP เหมือนพอร์ต USB-C สำหรับแอป AI ที่ช่วยให้เชื่อมต่อโมเดล AI กับแหล่งข้อมูลและเครื่องมือต่างๆ ได้อย่างเป็นมาตรฐาน

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- ตั้งค่าสภาพแวดล้อมการพัฒนาสำหรับ MCP ในภาษา C#, Java, Python, TypeScript และ JavaScript
- สร้างและนำ MCP servers พื้นฐานที่มีฟีเจอร์เฉพาะ (resources, prompts, และ tools) ไปใช้งาน
- สร้างแอปโฮสต์ที่เชื่อมต่อกับ MCP servers
- ทดสอบและดีบักการใช้งาน MCP
- เข้าใจปัญหาทั่วไปในการตั้งค่าและวิธีแก้ไข
- เชื่อมต่อการใช้งาน MCP ของคุณกับบริการ LLM ยอดนิยม

## การตั้งค่าสภาพแวดล้อม MCP ของคุณ

ก่อนเริ่มทำงานกับ MCP สิ่งสำคัญคือการเตรียมสภาพแวดล้อมการพัฒนาและเข้าใจกระบวนการทำงานพื้นฐาน ส่วนนี้จะนำทางคุณผ่านขั้นตอนการตั้งค่าเริ่มต้นเพื่อให้เริ่มต้นกับ MCP ได้อย่างราบรื่น

### สิ่งที่ต้องมี

ก่อนเริ่มพัฒนา MCP ให้แน่ใจว่าคุณมี:

- **สภาพแวดล้อมการพัฒนา** สำหรับภาษาที่คุณเลือกใช้ (C#, Java, Python, TypeScript หรือ JavaScript)
- **IDE/Editor** เช่น Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm หรือโปรแกรมแก้ไขโค้ดสมัยใหม่อื่นๆ
- **ตัวจัดการแพ็กเกจ** เช่น NuGet, Maven/Gradle, pip หรือ npm/yarn
- **API Keys** สำหรับบริการ AI ที่คุณวางแผนจะใช้ในแอปโฮสต์ของคุณ


### SDK อย่างเป็นทางการ

ในบทถัดไปคุณจะเห็นโซลูชันที่สร้างด้วย Python, TypeScript, Java และ .NET นี่คือ SDK อย่างเป็นทางการทั้งหมดที่รองรับ

MCP มี SDK อย่างเป็นทางการสำหรับหลายภาษา:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - ดูแลร่วมกับ Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - ดูแลร่วมกับ Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - การใช้งาน TypeScript อย่างเป็นทางการ
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - การใช้งาน Python อย่างเป็นทางการ
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - การใช้งาน Kotlin อย่างเป็นทางการ
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - ดูแลร่วมกับ Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - การใช้งาน Rust อย่างเป็นทางการ

## สาระสำคัญ

- การตั้งค่าสภาพแวดล้อมการพัฒนา MCP ทำได้ง่ายด้วย SDK เฉพาะภาษา
- การสร้าง MCP servers เกี่ยวข้องกับการสร้างและลงทะเบียนเครื่องมือที่มี schema ชัดเจน
- MCP clients เชื่อมต่อกับ servers และโมเดลเพื่อใช้ความสามารถเพิ่มเติม
- การทดสอบและดีบักเป็นสิ่งจำเป็นสำหรับการใช้งาน MCP ที่เชื่อถือได้
- ตัวเลือกการนำไปใช้งานมีตั้งแต่การพัฒนาท้องถิ่นจนถึงโซลูชันบนคลาวด์

## การฝึกฝน

เรามีตัวอย่างชุดหนึ่งที่เสริมการฝึกหัดที่คุณจะได้เห็นในทุกบทในส่วนนี้ นอกจากนี้แต่ละบทยังมีแบบฝึกหัดและงานมอบหมายของตัวเอง

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## แหล่งข้อมูลเพิ่มเติม

- [สร้าง Agents โดยใช้ Model Context Protocol บน Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP กับ Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## ต่อไป

ถัดไป: [สร้าง MCP Server ตัวแรกของคุณ](01-first-server/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้