<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:15:48+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "th"
}
-->
# การใช้งานจริง

การใช้งานจริงคือจุดที่พลังของ Model Context Protocol (MCP) ปรากฏให้เห็นอย่างชัดเจน แม้ว่าการเข้าใจทฤษฎีและสถาปัตยกรรมเบื้องหลัง MCP จะสำคัญ แต่คุณค่าที่แท้จริงจะเกิดขึ้นเมื่อคุณนำแนวคิดเหล่านี้ไปใช้ในการสร้าง ทดสอบ และนำเสนอวิธีแก้ปัญหาที่ตอบโจทย์โลกจริง บทนี้เชื่อมช่องว่างระหว่างความรู้เชิงแนวคิดกับการพัฒนาจริง โดยแนะนำขั้นตอนการนำแอปพลิเคชันที่ใช้ MCP ไปใช้งาน

ไม่ว่าคุณจะกำลังพัฒนาผู้ช่วยอัจฉริยะ ผสาน AI เข้ากับเวิร์กโฟลว์ธุรกิจ หรือสร้างเครื่องมือเฉพาะสำหรับประมวลผลข้อมูล MCP มอบฐานที่ยืดหยุ่น การออกแบบที่ไม่ขึ้นกับภาษาโปรแกรม และ SDK อย่างเป็นทางการสำหรับภาษายอดนิยมช่วยให้เข้าถึงได้ง่ายสำหรับนักพัฒนาหลากหลายกลุ่ม โดยใช้ SDK เหล่านี้ คุณสามารถสร้างต้นแบบ ทดลอง และขยายโซลูชันของคุณได้อย่างรวดเร็วในแพลตฟอร์มและสภาพแวดล้อมต่างๆ

ในส่วนถัดไป คุณจะพบตัวอย่างใช้งานจริง โค้ดตัวอย่าง และกลยุทธ์การนำไปใช้งานที่แสดงให้เห็นวิธีการใช้งาน MCP ใน C#, Java, TypeScript, JavaScript และ Python นอกจากนี้คุณยังได้เรียนรู้วิธีดีบักและทดสอบเซิร์ฟเวอร์ MCP การจัดการ API และการนำโซลูชันขึ้นคลาวด์ด้วย Azure ทรัพยากรเหล่านี้ออกแบบมาเพื่อเร่งการเรียนรู้และช่วยให้คุณสร้างแอป MCP ที่มั่นคงและพร้อมใช้งานในสภาพแวดล้อมจริงได้อย่างมั่นใจ

## ภาพรวม

บทเรียนนี้เน้นเรื่องการใช้งานจริงของ MCP ในหลายภาษาโปรแกรม เราจะสำรวจวิธีใช้ MCP SDK ใน C#, Java, TypeScript, JavaScript และ Python เพื่อสร้างแอปพลิเคชันที่แข็งแกร่ง ดีบักและทดสอบเซิร์ฟเวอร์ MCP รวมถึงสร้างทรัพยากร, prompt และเครื่องมือที่นำกลับมาใช้ใหม่ได้

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:
- นำ MCP ไปใช้งานโดยใช้ SDK อย่างเป็นทางการในภาษาต่างๆ
- ดีบักและทดสอบเซิร์ฟเวอร์ MCP อย่างเป็นระบบ
- สร้างและใช้งานฟีเจอร์ของเซิร์ฟเวอร์ (Resources, Prompts, และ Tools)
- ออกแบบเวิร์กโฟลว์ MCP ที่มีประสิทธิภาพสำหรับงานซับซ้อน
- ปรับแต่งการใช้งาน MCP ให้เหมาะสมกับประสิทธิภาพและความน่าเชื่อถือ

## แหล่งข้อมูล SDK อย่างเป็นทางการ

Model Context Protocol มี SDK อย่างเป็นทางการสำหรับหลายภาษา:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## การทำงานกับ MCP SDKs

ส่วนนี้มีตัวอย่างใช้งานจริงของ MCP ในหลายภาษา คุณจะพบโค้ดตัวอย่างในไดเรกทอรี `samples` จัดเรียงตามภาษา

### ตัวอย่างที่มีให้

ที่เก็บโค้ดประกอบด้วยตัวอย่างการใช้งานในภาษาต่อไปนี้:

- C#
- Java
- TypeScript
- JavaScript
- Python

แต่ละตัวอย่างแสดงแนวคิดหลักของ MCP และรูปแบบการใช้งานสำหรับภาษานั้นๆ และระบบนิเวศของมัน

## ฟีเจอร์หลักของเซิร์ฟเวอร์

เซิร์ฟเวอร์ MCP สามารถใช้งานฟีเจอร์เหล่านี้ได้ตามต้องการ:

### Resources
Resources ให้บริบทและข้อมูลสำหรับผู้ใช้หรือโมเดล AI ใช้:
- แหล่งเก็บเอกสาร
- ฐานความรู้
- แหล่งข้อมูลแบบมีโครงสร้าง
- ระบบไฟล์

### Prompts
Prompts คือข้อความและเวิร์กโฟลว์ที่เป็นแม่แบบสำหรับผู้ใช้:
- แม่แบบบทสนทนาที่กำหนดไว้ล่วงหน้า
- รูปแบบการโต้ตอบที่มีคำแนะนำ
- โครงสร้างบทสนทนาเฉพาะทาง

### Tools
Tools คือฟังก์ชันที่โมเดล AI สามารถเรียกใช้ได้:
- เครื่องมือประมวลผลข้อมูล
- การเชื่อมต่อ API ภายนอก
- ความสามารถในการคำนวณ
- ฟังก์ชันการค้นหา

## ตัวอย่างการใช้งาน: C#

ที่เก็บโค้ด C# SDK อย่างเป็นทางการมีตัวอย่างหลายแบบที่แสดงด้านต่างๆ ของ MCP:

- **Basic MCP Client**: ตัวอย่างง่ายๆ แสดงวิธีสร้าง MCP client และเรียกใช้ tools
- **Basic MCP Server**: การใช้งานเซิร์ฟเวอร์ขั้นพื้นฐานพร้อมลงทะเบียนเครื่องมือพื้นฐาน
- **Advanced MCP Server**: เซิร์ฟเวอร์ฟีเจอร์ครบถ้วนพร้อมลงทะเบียนเครื่องมือ, การตรวจสอบสิทธิ์ และการจัดการข้อผิดพลาด
- **ASP.NET Integration**: ตัวอย่างการผสานกับ ASP.NET Core
- **Tool Implementation Patterns**: รูปแบบต่างๆ สำหรับการสร้างเครื่องมือที่มีความซับซ้อนแตกต่างกัน

SDK C# MCP ยังอยู่ในสถานะพรีวิวและ API อาจมีการเปลี่ยนแปลง เราจะอัปเดตบล็อกนี้อย่างต่อเนื่องตามการพัฒนาของ SDK

### ฟีเจอร์หลัก
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- การสร้าง [MCP Server แรกของคุณ](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

สำหรับตัวอย่างการใช้งาน C# แบบครบถ้วน ดูที่ [ที่เก็บตัวอย่าง SDK C# อย่างเป็นทางการ](https://github.com/modelcontextprotocol/csharp-sdk)

## ตัวอย่างการใช้งาน: Java Implementation

Java SDK มีตัวเลือกการใช้งาน MCP ที่แข็งแกร่งพร้อมฟีเจอร์ระดับองค์กร

### ฟีเจอร์หลัก

- การผสานกับ Spring Framework
- ความปลอดภัยของประเภทข้อมูลสูง
- รองรับ reactive programming
- การจัดการข้อผิดพลาดอย่างครอบคลุม

สำหรับตัวอย่างการใช้งาน Java แบบครบถ้วน ดูที่ [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) ในไดเรกทอรีตัวอย่าง

## ตัวอย่างการใช้งาน: JavaScript Implementation

JavaScript SDK มอบวิธีการใช้งาน MCP ที่เบาและยืดหยุ่น

### ฟีเจอร์หลัก

- รองรับ Node.js และเบราว์เซอร์
- API แบบ Promise
- ผสานกับ Express และเฟรมเวิร์กอื่นๆ ได้ง่าย
- รองรับ WebSocket สำหรับการสตรีม

สำหรับตัวอย่างการใช้งาน JavaScript แบบครบถ้วน ดูที่ [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) ในไดเรกทอรีตัวอย่าง

## ตัวอย่างการใช้งาน: Python Implementation

Python SDK มอบวิธีใช้งาน MCP แบบ Pythonic พร้อมการผสานกับเฟรมเวิร์ก ML อย่างยอดเยี่ยม

### ฟีเจอร์หลัก

- รองรับ async/await ด้วย asyncio
- ผสานกับ Flask และ FastAPI
- การลงทะเบียนเครื่องมือที่เรียบง่าย
- การผสานเนทีฟกับไลบรารี ML ยอดนิยม

สำหรับตัวอย่างการใช้งาน Python แบบครบถ้วน ดูที่ [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) ในไดเรกทอรีตัวอย่าง

## การจัดการ API

Azure API Management เป็นคำตอบที่ดีสำหรับการรักษาความปลอดภัยเซิร์ฟเวอร์ MCP แนวคิดคือวาง Azure API Management ไว้หน้าระบบ MCP Server ของคุณและให้มันจัดการฟีเจอร์ต่างๆ ที่คุณน่าจะต้องการ เช่น:

- การจำกัดอัตรา (rate limiting)
- การจัดการโทเค็น
- การตรวจสอบ
- การกระจายโหลด
- ความปลอดภัย

### ตัวอย่าง Azure

นี่คือตัวอย่าง Azure ที่ทำสิ่งนี้โดยตรง เช่น [การสร้าง MCP Server และรักษาความปลอดภัยด้วย Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

ดูภาพการทำงานของ authorization flow ด้านล่าง:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

ในภาพด้านบนเกิดเหตุการณ์ดังนี้:

- การตรวจสอบสิทธิ์/อนุญาตเกิดขึ้นโดยใช้ Microsoft Entra
- Azure API Management ทำหน้าที่เป็นเกตเวย์และใช้โพลิซีเพื่อจัดการและควบคุมการรับส่งข้อมูล
- Azure Monitor บันทึกคำขอทั้งหมดเพื่อนำไปวิเคราะห์ต่อ

#### ลำดับการอนุญาต

มาดูลำดับการอนุญาตอย่างละเอียด:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### ข้อกำหนด MCP Authorization

เรียนรู้เพิ่มเติมเกี่ยวกับ [ข้อกำหนด MCP Authorization](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## การนำ Remote MCP Server ขึ้น Azure

มาดูกันว่าคุณสามารถนำตัวอย่างที่กล่าวถึงไปใช้งานได้หรือไม่:

1. โคลนรีโพ

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. ลงทะเบียน `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` หลังจากนั้นรอสักครู่เพื่อตรวจสอบว่าการลงทะเบียนเสร็จสมบูรณ์หรือไม่

2. รันคำสั่ง [azd](https://aka.ms/azd) นี้เพื่อจัดเตรียมบริการ api management, function app (พร้อมโค้ด) และทรัพยากร Azure อื่นๆ ที่จำเป็นทั้งหมด

    ```shell
    azd up
    ```

    คำสั่งนี้จะนำทรัพยากรคลาวด์ทั้งหมดขึ้น Azure

### การทดสอบเซิร์ฟเวอร์ของคุณด้วย MCP Inspector

1. ใน **หน้าต่างเทอร์มินัลใหม่** ติดตั้งและรัน MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    คุณจะเห็นอินเทอร์เฟซที่คล้ายกับ:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.th.png)

1. คลิก CTRL เพื่อโหลดเว็บแอป MCP Inspector จาก URL ที่แอปแสดง (เช่น http://127.0.0.1:6274/#resources)
1. ตั้งค่า transport type เป็น `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` และ **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **แสดงรายการ Tools** คลิกที่เครื่องมือและ **Run Tool**

ถ้าทุกขั้นตอนทำงานได้ คุณจะเชื่อมต่อกับเซิร์ฟเวอร์ MCP ได้และเรียกใช้เครื่องมือสำเร็จ

## เซิร์ฟเวอร์ MCP สำหรับ Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): ชุดรีโพนี้เป็นเทมเพลตเริ่มต้นสำหรับการสร้างและนำเซิร์ฟเวอร์ MCP ระยะไกลแบบกำหนดเองโดยใช้ Azure Functions กับ Python, C# .NET หรือ Node/TypeScript

ตัวอย่างนี้มอบโซลูชันครบวงจรที่ช่วยให้นักพัฒนาสามารถ:

- สร้างและรันในเครื่อง: พัฒนาและดีบักเซิร์ฟเวอร์ MCP บนเครื่องของตัวเอง
- นำขึ้น Azure: นำขึ้นคลาวด์ได้ง่ายด้วยคำสั่ง azd up เพียงคำสั่งเดียว
- เชื่อมต่อจากไคลเอนต์: เชื่อมต่อกับเซิร์ฟเวอร์ MCP จากไคลเอนต์ต่างๆ รวมถึงโหมด Copilot ของ VS Code และเครื่องมือ MCP Inspector

### ฟีเจอร์หลัก:

- ความปลอดภัยตั้งแต่การออกแบบ: เซิร์ฟเวอร์ MCP ถูกปกป้องด้วยคีย์และ HTTPS
- ตัวเลือกการตรวจสอบสิทธิ์: รองรับ OAuth โดยใช้ระบบ auth ในตัวและ/หรือ API Management
- การแยกเครือข่าย: รองรับการแยกเครือข่ายด้วย Azure Virtual Networks (VNET)
- สถาปัตยกรรมแบบ Serverless: ใช้ Azure Functions สำหรับการประมวลผลแบบอีเวนต์และปรับขนาดได้
- การพัฒนาในเครื่อง: รองรับการพัฒนาและดีบักในเครื่องอย่างครบถ้วน
- การนำไปใช้งานง่าย: กระบวนการนำไปใช้งานบน Azure ที่เรียบง่าย

รีโพนี้ประกอบด้วยไฟล์คอนฟิก โค้ดต้นฉบับ และนิยามโครงสร้างพื้นฐานทั้งหมดที่จำเป็นเพื่อเริ่มต้นอย่างรวดเร็วกับการใช้งานเซิร์ฟเวอร์ MCP ที่พร้อมใช้งานจริง

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - ตัวอย่างการใช้งาน MCP ด้วย Azure Functions และ Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - ตัวอย่างการใช้งาน MCP ด้วย Azure Functions และ C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - ตัวอย่างการใช้งาน MCP ด้วย Azure Functions และ Node/TypeScript

## ประเด็นสำคัญ

- MCP SDKs มอบเครื่องมือเฉพาะภาษาสำหรับการสร้างโซลูชัน MCP ที่มั่นคง
- กระบวนการดีบักและทดสอบสำคัญต่อความน่าเชื่อถือของแอป MCP
- แม่แบบ prompt ที่นำกลับมาใช้ใหม่ช่วยให้การโต้ตอบกับ AI มีความสม่ำเสมอ
- เวิร์กโฟลว์ที่ออกแบบดีสามารถจัดการงานซับซ้อนได้โดยใช้หลายเครื่องมือร่วมกัน
- การใช้งาน MCP ต้องคำนึงถึงความปลอดภัย ประสิทธิภาพ และการจัดการข้อผิดพลาด

## แบบฝึกหัด

ออกแบบเวิร์กโฟลว์ MCP ที่ใช้งานได้จริงเพื่อแก้ปัญหาในโดเมนของคุณ:

1. ระบุเครื่องมือ 3-4 ชนิดที่เป็นประโยชน์สำหรับแก้ปัญหานี้
2. สร้างแผนภาพเวิร์กโฟลว์แสดงการทำงานร่วมกันของเครื่องมือเหล่านี้
3. สร้างเวอร์ชันพื้นฐานของเครื่องมือหนึ่งในภาษาที่คุณถนัด
4. สร้างแม่แบบ prompt ที่ช่วยให้โมเดลใช้เครื่องมือของคุณได้อย่างมีประสิทธิภาพ

## แหล่งข้อมูลเพิ่มเติม


---

ถัดไป: [Advanced Topics](../05-AdvancedTopics/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาด้วย AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่น่าเชื่อถือที่สุด สำหรับข้อมูลที่สำคัญ ควรใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดใด ๆ ที่เกิดจากการใช้การแปลนี้