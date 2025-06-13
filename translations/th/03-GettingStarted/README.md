<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T23:55:45+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "th"
}
-->
## Getting Started  

ส่วนนี้ประกอบด้วยบทเรียนหลายบท:

- **1 Your first server** ในบทเรียนแรกนี้ คุณจะได้เรียนรู้วิธีสร้างเซิร์ฟเวอร์ตัวแรกของคุณและตรวจสอบมันด้วยเครื่องมือ inspector ซึ่งเป็นวิธีที่มีประโยชน์ในการทดสอบและดีบักเซิร์ฟเวอร์ของคุณ [ไปที่บทเรียน](/03-GettingStarted/01-first-server/README.md)

- **2 Client** ในบทเรียนนี้ คุณจะได้เรียนรู้วิธีเขียน client ที่สามารถเชื่อมต่อกับเซิร์ฟเวอร์ของคุณได้ [ไปที่บทเรียน](/03-GettingStarted/02-client/README.md)

- **3 Client with LLM** วิธีที่ดียิ่งขึ้นในการเขียน client คือการเพิ่ม LLM เข้าไป เพื่อให้มันสามารถ "เจรจา" กับเซิร์ฟเวอร์ของคุณเกี่ยวกับสิ่งที่จะทำ [ไปที่บทเรียน](/03-GettingStarted/03-llm-client/README.md)

- **4 Consuming a server GitHub Copilot Agent mode in Visual Studio Code** ที่นี่เราจะดูการรัน MCP Server ของเราจากภายใน Visual Studio Code [ไปที่บทเรียน](/03-GettingStarted/04-vscode/README.md)

- **5 Consuming from a SSE (Server Sent Events)** SSE เป็นมาตรฐานสำหรับการสตรีมจากเซิร์ฟเวอร์ไปยัง client ช่วยให้เซิร์ฟเวอร์ส่งข้อมูลอัปเดตแบบเรียลไทม์ไปยัง client ผ่าน HTTP [ไปที่บทเรียน](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming with MCP (Streamable HTTP)** เรียนรู้เกี่ยวกับการสตรีม HTTP สมัยใหม่ การแจ้งเตือนความคืบหน้า และวิธีการสร้าง MCP servers และ clients แบบเรียลไทม์ที่ปรับขนาดได้โดยใช้ Streamable HTTP [ไปที่บทเรียน](/03-GettingStarted/06-http-streaming/README.md)

- **7 Utilising AI Toolkit for VSCode** เพื่อใช้งานและทดสอบ MCP Clients และ Servers ของคุณ [ไปที่บทเรียน](/03-GettingStarted/07-aitk/README.md)

- **8 Testing** ที่นี่เราจะเน้นวิธีทดสอบเซิร์ฟเวอร์และ client ของเราในหลายๆ รูปแบบ [ไปที่บทเรียน](/03-GettingStarted/08-testing/README.md)

- **9 Deployment** บทนี้จะดูวิธีการต่างๆ ในการนำ MCP solutions ของคุณไปใช้งาน [ไปที่บทเรียน](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) คือโปรโตคอลเปิดที่กำหนดมาตรฐานการให้บริบทกับ LLMs คิดว่า MCP เหมือนพอร์ต USB-C สำหรับแอป AI ที่ให้วิธีเชื่อมต่อมาตรฐานระหว่างโมเดล AI กับแหล่งข้อมูลและเครื่องมือต่างๆ

## Learning Objectives

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- ตั้งค่าสภาพแวดล้อมการพัฒนาสำหรับ MCP ในภาษา C#, Java, Python, TypeScript และ JavaScript
- สร้างและนำ MCP servers พื้นฐานที่มีฟีเจอร์เฉพาะ (resources, prompts, และ tools) ไปใช้งาน
- สร้างแอปโฮสต์ที่เชื่อมต่อกับ MCP servers
- ทดสอบและดีบักการใช้งาน MCP
- เข้าใจปัญหาทั่วไปในการตั้งค่าและวิธีแก้ไข
- เชื่อมต่อการใช้งาน MCP ของคุณกับบริการ LLM ที่ได้รับความนิยม

## Setting Up Your MCP Environment

ก่อนเริ่มใช้งาน MCP สิ่งสำคัญคือการเตรียมสภาพแวดล้อมการพัฒนาและเข้าใจกระบวนการทำงานพื้นฐาน ส่วนนี้จะนำคุณผ่านขั้นตอนการตั้งค่าเริ่มต้นเพื่อให้เริ่มต้นกับ MCP ได้อย่างราบรื่น

### Prerequisites

ก่อนเริ่มพัฒนา MCP ให้แน่ใจว่าคุณมี:

- **สภาพแวดล้อมการพัฒนา** สำหรับภาษาที่คุณเลือกใช้ (C#, Java, Python, TypeScript หรือ JavaScript)
- **IDE/Editor** เช่น Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm หรือโปรแกรมแก้ไขโค้ดสมัยใหม่อื่นๆ
- **Package Managers** เช่น NuGet, Maven/Gradle, pip หรือ npm/yarn
- **API Keys** สำหรับบริการ AI ที่คุณวางแผนจะใช้ในแอปโฮสต์ของคุณ


### Official SDKs

ในบทถัดไป คุณจะเห็นตัวอย่างโซลูชันที่สร้างด้วย Python, TypeScript, Java และ .NET นี่คือ SDK อย่างเป็นทางการทั้งหมดที่รองรับ

MCP มี SDK อย่างเป็นทางการสำหรับหลายภาษา:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - ดูแลร่วมกับ Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - ดูแลร่วมกับ Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - การใช้งาน TypeScript อย่างเป็นทางการ
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - การใช้งาน Python อย่างเป็นทางการ
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - การใช้งาน Kotlin อย่างเป็นทางการ
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - ดูแลร่วมกับ Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - การใช้งาน Rust อย่างเป็นทางการ

## Key Takeaways

- การตั้งค่าสภาพแวดล้อมการพัฒนา MCP ทำได้ง่ายด้วย SDK เฉพาะภาษา
- การสร้าง MCP servers เกี่ยวข้องกับการสร้างและลงทะเบียนเครื่องมือที่มี schema ชัดเจน
- MCP clients เชื่อมต่อกับเซิร์ฟเวอร์และโมเดลเพื่อใช้ความสามารถเพิ่มเติม
- การทดสอบและดีบักเป็นสิ่งจำเป็นสำหรับการใช้งาน MCP ที่น่าเชื่อถือ
- ตัวเลือกการนำไปใช้งานมีตั้งแต่การพัฒนาในเครื่องจนถึงโซลูชันบนคลาวด์

## Practicing

เรามีชุดตัวอย่างที่ช่วยเสริมการฝึกฝนในทุกบทเรียนในส่วนนี้ นอกจากนี้แต่ละบทยังมีแบบฝึกหัดและงานที่เกี่ยวข้อง

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

ถัดไป: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ความถูกต้องสูงสุด โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นฉบับถือเป็นแหล่งข้อมูลที่ถูกต้องและเชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญด้านภาษามนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดขึ้นจากการใช้การแปลนี้