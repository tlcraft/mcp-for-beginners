<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:10:19+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "th"
}
-->
## Getting Started  

ส่วนนี้ประกอบด้วยบทเรียนหลายบท:

- **1 Your first server** ในบทเรียนแรกนี้ คุณจะได้เรียนรู้วิธีสร้างเซิร์ฟเวอร์เครื่องแรกของคุณและตรวจสอบด้วยเครื่องมือ inspector ซึ่งเป็นวิธีที่มีประโยชน์สำหรับทดสอบและดีบักเซิร์ฟเวอร์ของคุณ [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **2 Client** ในบทเรียนนี้ คุณจะได้เรียนรู้วิธีเขียน client ที่สามารถเชื่อมต่อกับเซิร์ฟเวอร์ของคุณได้ [to the lesson](/03-GettingStarted/02-client/README.md)

- **3 Client with LLM** วิธีที่ดีกว่าในการเขียน client คือการเพิ่ม LLM เข้าไปเพื่อให้สามารถ "เจรจา" กับเซิร์ฟเวอร์ของคุณว่าควรทำอะไร [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **4 Consuming a server GitHub Copilot Agent mode in Visual Studio Code** ที่นี่เราจะดูวิธีรัน MCP Server ของเราภายใน Visual Studio Code [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **5 Consuming from a SSE (Server Sent Events)** SSE คือมาตรฐานสำหรับการสตรีมข้อมูลจากเซิร์ฟเวอร์ไปยัง client ช่วยให้เซิร์ฟเวอร์ส่งอัปเดตแบบเรียลไทม์ผ่าน HTTP [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **6 Utilising AI Toolkit for VSCode** เพื่อใช้และทดสอบ MCP Clients และ Servers ของคุณ [to the lesson](/03-GettingStarted/06-aitk/README.md)

- **7 Testing** ที่นี่เราจะเน้นวิธีการทดสอบเซิร์ฟเวอร์และ client ของเราในหลายรูปแบบ [to the lesson](/03-GettingStarted/07-testing/README.md)

- **8 Deployment** บทนี้จะดูวิธีการต่าง ๆ ในการนำ MCP solutions ของคุณไปใช้งานจริง [to the lesson](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) คือโปรโตคอลเปิดที่กำหนดมาตรฐานวิธีการที่แอปพลิเคชันให้บริบทกับ LLMs คิดว่า MCP เหมือนพอร์ต USB-C สำหรับแอป AI — มันให้วิธีมาตรฐานในการเชื่อมต่อโมเดล AI กับแหล่งข้อมูลและเครื่องมือต่าง ๆ

## Learning Objectives

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- ตั้งค่าสภาพแวดล้อมการพัฒนาสำหรับ MCP ใน C#, Java, Python, TypeScript และ JavaScript
- สร้างและนำ MCP servers พื้นฐานที่มีฟีเจอร์เฉพาะ (resources, prompts, และ tools) ไปใช้งาน
- สร้างแอปโฮสต์ที่เชื่อมต่อกับ MCP servers
- ทดสอบและดีบักการใช้งาน MCP
- เข้าใจปัญหาทั่วไปในการตั้งค่าและวิธีแก้ไข
- เชื่อมต่อการใช้งาน MCP ของคุณกับบริการ LLM ยอดนิยม

## Setting Up Your MCP Environment

ก่อนเริ่มทำงานกับ MCP สิ่งสำคัญคือต้องเตรียมสภาพแวดล้อมการพัฒนาและเข้าใจขั้นตอนการทำงานพื้นฐาน ส่วนนี้จะช่วยแนะนำขั้นตอนการตั้งค่าเริ่มต้นเพื่อให้คุณเริ่มต้นกับ MCP ได้อย่างราบรื่น

### Prerequisites

ก่อนเริ่มพัฒนา MCP ให้แน่ใจว่าคุณมี:

- **Development Environment** สำหรับภาษาที่คุณเลือกใช้ (C#, Java, Python, TypeScript หรือ JavaScript)
- **IDE/Editor** เช่น Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm หรือโปรแกรมแก้ไขโค้ดสมัยใหม่อื่น ๆ
- **Package Managers** เช่น NuGet, Maven/Gradle, pip หรือ npm/yarn
- **API Keys** สำหรับบริการ AI ที่คุณวางแผนจะใช้ในแอปโฮสต์ของคุณ


### Official SDKs

ในบทต่อไปคุณจะเห็นโซลูชันที่สร้างด้วย Python, TypeScript, Java และ .NET นี่คือ SDKs ที่ได้รับการสนับสนุนอย่างเป็นทางการทั้งหมด

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
- การทดสอบและดีบักมีความสำคัญต่อการใช้งาน MCP ที่เชื่อถือได้
- ตัวเลือกการนำไปใช้งานมีตั้งแต่การพัฒนาในเครื่องจนถึงโซลูชันบนคลาวด์

## Practicing

เรามีตัวอย่างชุดหนึ่งที่ช่วยเสริมการฝึกฝนที่คุณจะเจอในทุกบทเรียนในส่วนนี้ นอกจากนี้แต่ละบทเรียนยังมีแบบฝึกหัดและงานที่ต้องทำของตัวเองด้วย

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../../../03-GettingStarted/samples/javascript)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

Next: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารฉบับนี้ได้รับการแปลโดยใช้บริการแปลภาษาด้วย AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้การแปลมีความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่แม่นยำ เอกสารต้นฉบับในภาษาต้นทางควรถูกพิจารณาเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่มีความสำคัญ ควรใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดที่เกิดขึ้นจากการใช้การแปลนี้