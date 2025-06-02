<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:33:55+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "th"
}
-->
## Getting Started  

ส่วนนี้ประกอบด้วยบทเรียนหลายบท:

- **-1- เซิร์ฟเวอร์ตัวแรกของคุณ** ในบทเรียนแรกนี้ คุณจะได้เรียนรู้วิธีสร้างเซิร์ฟเวอร์ตัวแรกและตรวจสอบมันด้วยเครื่องมือ inspector ซึ่งเป็นวิธีที่มีประโยชน์ในการทดสอบและดีบักเซิร์ฟเวอร์ของคุณ [ไปยังบทเรียน](/03-GettingStarted/01-first-server/README.md)

- **-2- Client** ในบทเรียนนี้ คุณจะได้เรียนรู้วิธีเขียน client ที่สามารถเชื่อมต่อกับเซิร์ฟเวอร์ของคุณได้ [ไปยังบทเรียน](/03-GettingStarted/02-client/README.md)

- **-3- Client พร้อม LLM** วิธีที่ดียิ่งขึ้นในการเขียน client คือการเพิ่ม LLM เข้าไปเพื่อให้มันสามารถ "เจรจา" กับเซิร์ฟเวอร์ของคุณว่าให้ทำอะไร [ไปยังบทเรียน](/03-GettingStarted/03-llm-client/README.md)

- **-4- การใช้งานโหมด GitHub Copilot Agent ของเซิร์ฟเวอร์ใน Visual Studio Code** ที่นี่เราจะดูการรัน MCP Server ของเราจากภายใน Visual Studio Code [ไปยังบทเรียน](/03-GettingStarted/04-vscode/README.md)

- **-5- การใช้งานจาก SSE (Server Sent Events)** SSE เป็นมาตรฐานสำหรับการสตรีมข้อมูลจากเซิร์ฟเวอร์ไปยัง client ช่วยให้เซิร์ฟเวอร์ส่งข้อมูลอัปเดตแบบเรียลไทม์ไปยัง client ผ่าน HTTP [ไปยังบทเรียน](/03-GettingStarted/05-sse-server/README.md)

- **-6- การใช้ AI Toolkit สำหรับ VSCode** เพื่อใช้งานและทดสอบ MCP Clients และ Servers ของคุณ [ไปยังบทเรียน](/03-GettingStarted/06-aitk/README.md)

- **-7 การทดสอบ** ในส่วนนี้เราจะเน้นวิธีการทดสอบเซิร์ฟเวอร์และ client ของเราในรูปแบบต่างๆ [ไปยังบทเรียน](/03-GettingStarted/07-testing/README.md)

- **-8- การปรับใช้** บทนี้จะพูดถึงวิธีการปรับใช้โซลูชัน MCP ของคุณในรูปแบบต่างๆ [ไปยังบทเรียน](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) คือโปรโตคอลแบบเปิดที่กำหนดมาตรฐานวิธีที่แอปพลิเคชันให้ข้อมูลบริบทกับ LLMs คิดว่า MCP เหมือนพอร์ต USB-C สำหรับแอป AI — มันเป็นวิธีมาตรฐานในการเชื่อมต่อโมเดล AI กับแหล่งข้อมูลและเครื่องมือต่างๆ

## Learning Objectives

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- ตั้งค่าสภาพแวดล้อมการพัฒนา MCP ในภาษา C#, Java, Python, TypeScript และ JavaScript
- สร้างและปรับใช้เซิร์ฟเวอร์ MCP พื้นฐานพร้อมฟีเจอร์ที่กำหนดเอง (resources, prompts และ tools)
- สร้างแอปโฮสต์ที่เชื่อมต่อกับเซิร์ฟเวอร์ MCP
- ทดสอบและดีบักการใช้งาน MCP
- เข้าใจความท้าทายทั่วไปในการตั้งค่าและวิธีแก้ไข
- เชื่อมต่อการใช้งาน MCP กับบริการ LLM ยอดนิยม

## Setting Up Your MCP Environment

ก่อนเริ่มทำงานกับ MCP จำเป็นต้องเตรียมสภาพแวดล้อมการพัฒนาและเข้าใจกระบวนการทำงานพื้นฐาน ส่วนนี้จะนำทางคุณผ่านขั้นตอนการตั้งค่าเริ่มต้นเพื่อให้เริ่มต้นกับ MCP ได้อย่างราบรื่น

### Prerequisites

ก่อนลงมือพัฒนา MCP ให้แน่ใจว่าคุณมี:

- **สภาพแวดล้อมการพัฒนา** สำหรับภาษาที่คุณเลือกใช้ (C#, Java, Python, TypeScript หรือ JavaScript)
- **IDE/Editor** เช่น Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm หรือโปรแกรมแก้ไขโค้ดสมัยใหม่อื่นๆ
- **ตัวจัดการแพ็กเกจ** เช่น NuGet, Maven/Gradle, pip หรือ npm/yarn
- **API Keys** สำหรับบริการ AI ที่คุณวางแผนจะใช้ในแอปโฮสต์ของคุณ


### Official SDKs

ในบทต่อๆ ไป คุณจะเห็นโซลูชันที่สร้างด้วย Python, TypeScript, Java และ .NET นี่คือ SDK อย่างเป็นทางการทั้งหมดที่รองรับ

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
- การสร้างเซิร์ฟเวอร์ MCP เกี่ยวข้องกับการสร้างและลงทะเบียนเครื่องมือที่มี schema ชัดเจน
- MCP clients เชื่อมต่อกับเซิร์ฟเวอร์และโมเดลเพื่อใช้ความสามารถที่ขยายเพิ่ม
- การทดสอบและดีบักเป็นสิ่งสำคัญสำหรับการใช้งาน MCP ที่น่าเชื่อถือ
- ตัวเลือกการปรับใช้มีตั้งแต่การพัฒนาในเครื่องจนถึงโซลูชันบนคลาวด์

## Practicing

เรามีตัวอย่างชุดหนึ่งที่เสริมการฝึกฝนซึ่งคุณจะเจอในทุกบทเรียนในส่วนนี้ นอกจากนี้แต่ละบทยังมีแบบฝึกหัดและงานมอบหมายของตัวเอง

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
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลโดยอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางควรถูกพิจารณาเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้การแปลโดยผู้เชี่ยวชาญด้านภาษามนุษย์ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดขึ้นจากการใช้การแปลนี้