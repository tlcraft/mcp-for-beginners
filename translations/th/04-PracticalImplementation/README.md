<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:10:33+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "th"
}
-->
# การใช้งานจริง

การใช้งานจริงคือจุดที่พลังของ Model Context Protocol (MCP) กลายเป็นสิ่งที่จับต้องได้ แม้ว่าการเข้าใจทฤษฎีและสถาปัตยกรรมเบื้องหลัง MCP จะสำคัญ แต่คุณค่าที่แท้จริงจะเกิดขึ้นเมื่อคุณนำแนวคิดเหล่านี้ไปใช้สร้าง ทดสอบ และนำเสนอวิธีแก้ปัญหาที่ตอบโจทย์โลกจริง บทนี้จะเชื่อมช่องว่างระหว่างความรู้เชิงแนวคิดกับการพัฒนาจริง โดยแนะนำขั้นตอนการนำแอปพลิเคชันที่ใช้ MCP มาใช้งาน

ไม่ว่าคุณจะพัฒนาผู้ช่วยอัจฉริยะ ผสาน AI เข้ากับกระบวนการทำงานทางธุรกิจ หรือสร้างเครื่องมือเฉพาะสำหรับการประมวลผลข้อมูล MCP ก็เป็นพื้นฐานที่ยืดหยุ่น การออกแบบที่ไม่ขึ้นกับภาษาโปรแกรมและ SDK อย่างเป็นทางการสำหรับภาษายอดนิยมช่วยให้เข้าถึงได้ง่ายสำหรับนักพัฒนาหลากหลายกลุ่ม ด้วยการใช้ SDK เหล่านี้ คุณสามารถสร้างต้นแบบ ทำซ้ำ และขยายโซลูชันของคุณอย่างรวดเร็วบนแพลตฟอร์มและสภาพแวดล้อมต่างๆ

ในส่วนถัดไป คุณจะพบตัวอย่างการใช้งานจริง โค้ดตัวอย่าง และกลยุทธ์การนำเสนอที่แสดงให้เห็นวิธีการใช้งาน MCP ใน C#, Java, TypeScript, JavaScript และ Python คุณจะได้เรียนรู้วิธีดีบักและทดสอบเซิร์ฟเวอร์ MCP การจัดการ API และการนำโซลูชันไปใช้งานบนคลาวด์ด้วย Azure ทรัพยากรเหล่านี้ถูกออกแบบมาเพื่อเร่งการเรียนรู้และช่วยให้คุณสร้างแอปพลิเคชัน MCP ที่มั่นคงและพร้อมใช้งานในสภาพแวดล้อมจริงได้อย่างมั่นใจ

## ภาพรวม

บทเรียนนี้เน้นด้านการใช้งานจริงของ MCP ในหลายภาษาโปรแกรม เราจะสำรวจวิธีการใช้ MCP SDK ใน C#, Java, TypeScript, JavaScript และ Python เพื่อสร้างแอปพลิเคชันที่มั่นคง ดีบักและทดสอบเซิร์ฟเวอร์ MCP และสร้างทรัพยากร ตัวกระตุ้น และเครื่องมือที่นำกลับมาใช้ใหม่ได้

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:
- นำโซลูชัน MCP ไปใช้งานโดยใช้ SDK อย่างเป็นทางการในหลายภาษาโปรแกรม
- ดีบักและทดสอบเซิร์ฟเวอร์ MCP อย่างเป็นระบบ
- สร้างและใช้ฟีเจอร์ของเซิร์ฟเวอร์ (Resources, Prompts, และ Tools)
- ออกแบบเวิร์กโฟลว์ MCP ที่มีประสิทธิภาพสำหรับงานที่ซับซ้อน
- ปรับแต่งการใช้งาน MCP ให้เหมาะสมกับประสิทธิภาพและความน่าเชื่อถือ

## แหล่ง SDK อย่างเป็นทางการ

Model Context Protocol มี SDK อย่างเป็นทางการสำหรับหลายภาษา:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## การใช้งาน MCP SDKs

ส่วนนี้ให้ตัวอย่างการใช้งาน MCP ในหลายภาษาโปรแกรม คุณสามารถหาโค้ดตัวอย่างได้ในไดเรกทอรี `samples` ซึ่งจัดเรียงตามภาษา

### ตัวอย่างที่มีให้

รีโพสิตอรีมี [ตัวอย่างการใช้งาน](../../../04-PracticalImplementation/samples) ในภาษาดังนี้:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

แต่ละตัวอย่างแสดงแนวคิดหลักและรูปแบบการใช้งาน MCP สำหรับภาษานั้นๆ และระบบนิเวศที่เกี่ยวข้อง

## ฟีเจอร์หลักของเซิร์ฟเวอร์

เซิร์ฟเวอร์ MCP สามารถใช้งานฟีเจอร์ใดๆ เหล่านี้ร่วมกันได้:

### Resources
Resources ให้บริบทและข้อมูลสำหรับผู้ใช้หรือโมเดล AI ใช้งาน เช่น:
- ที่เก็บเอกสาร
- ฐานความรู้
- แหล่งข้อมูลแบบมีโครงสร้าง
- ระบบไฟล์

### Prompts
Prompts คือข้อความและเวิร์กโฟลว์แบบแม่แบบสำหรับผู้ใช้ เช่น:
- แม่แบบบทสนทนาที่กำหนดไว้ล่วงหน้า
- รูปแบบการโต้ตอบที่แนะนำ
- โครงสร้างบทสนทนาเฉพาะทาง

### Tools
Tools คือฟังก์ชันที่โมเดล AI สามารถเรียกใช้งานได้ เช่น:
- เครื่องมือประมวลผลข้อมูล
- การเชื่อมต่อกับ API ภายนอก
- ความสามารถในการคำนวณ
- ฟังก์ชันการค้นหา

## ตัวอย่างการใช้งาน: C#

รีโพสิตอรี SDK อย่างเป็นทางการของ C# มีตัวอย่างหลายแบบที่แสดงแง่มุมต่างๆ ของ MCP:

- **Basic MCP Client**: ตัวอย่างง่ายๆ แสดงวิธีสร้าง MCP client และเรียกใช้เครื่องมือ
- **Basic MCP Server**: การใช้งานเซิร์ฟเวอร์พื้นฐานที่ลงทะเบียนเครื่องมืออย่างง่าย
- **Advanced MCP Server**: เซิร์ฟเวอร์ฟีเจอร์ครบครันที่มีการลงทะเบียนเครื่องมือ การยืนยันตัวตน และการจัดการข้อผิดพลาด
- **ASP.NET Integration**: ตัวอย่างการผสานรวมกับ ASP.NET Core
- **Tool Implementation Patterns**: รูปแบบต่างๆ สำหรับการใช้งานเครื่องมือที่มีความซับซ้อนแตกต่างกัน

SDK C# ของ MCP ยังอยู่ในช่วงพรีวิวและ API อาจมีการเปลี่ยนแปลง เราจะอัปเดตบล็อกนี้อย่างต่อเนื่องตามการพัฒนา SDK

### ฟีเจอร์สำคัญ
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- การสร้าง [MCP Server ตัวแรกของคุณ](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

สำหรับตัวอย่างการใช้งาน C# แบบครบถ้วน โปรดเยี่ยมชม [รีโพสิตอรีตัวอย่าง C# อย่างเป็นทางการ](https://github.com/modelcontextprotocol/csharp-sdk)

## ตัวอย่างการใช้งาน: Java Implementation

Java SDK มีตัวเลือกการใช้งาน MCP ที่แข็งแกร่งพร้อมฟีเจอร์ระดับองค์กร

### ฟีเจอร์สำคัญ

- การผสานรวมกับ Spring Framework
- ความปลอดภัยของชนิดข้อมูลสูง
- รองรับการเขียนโปรแกรมแบบ reactive
- การจัดการข้อผิดพลาดครบถ้วน

สำหรับตัวอย่างการใช้งาน Java แบบครบถ้วน ดูได้ที่ [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) ในไดเรกทอรีตัวอย่าง

## ตัวอย่างการใช้งาน: JavaScript Implementation

JavaScript SDK ให้วิธีการใช้งาน MCP ที่เบาและยืดหยุ่น

### ฟีเจอร์สำคัญ

- รองรับ Node.js และเบราว์เซอร์
- API แบบ Promise
- ผสานรวมง่ายกับ Express และเฟรมเวิร์กอื่นๆ
- รองรับ WebSocket สำหรับการสตรีม

สำหรับตัวอย่างการใช้งาน JavaScript แบบครบถ้วน ดูได้ที่ [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) ในไดเรกทอรีตัวอย่าง

## ตัวอย่างการใช้งาน: Python Implementation

Python SDK มีแนวทางการใช้งาน MCP ที่เป็น Pythonic พร้อมการผสานรวมกับเฟรมเวิร์ก ML ที่ยอดเยี่ยม

### ฟีเจอร์สำคัญ

- รองรับ async/await ด้วย asyncio
- ผสานรวมกับ Flask และ FastAPI
- การลงทะเบียนเครื่องมือที่ง่าย
- การผสานรวมเนทีฟกับไลบรารี ML ยอดนิยม

สำหรับตัวอย่างการใช้งาน Python แบบครบถ้วน ดูได้ที่ [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) ในไดเรกทอรีตัวอย่าง

## การจัดการ API

Azure API Management เป็นคำตอบที่ดีสำหรับการรักษาความปลอดภัยของ MCP Servers แนวคิดคือการวาง Azure API Management ไว้หน้าตัว MCP Server ของคุณเพื่อจัดการฟีเจอร์ที่คุณน่าจะต้องการ เช่น:

- การจำกัดอัตราการเข้าถึง
- การจัดการโทเคน
- การตรวจสอบ
- การกระจายโหลด
- ความปลอดภัย

### ตัวอย่าง Azure

นี่คือตัวอย่าง Azure ที่ทำงานตามแนวคิดนี้ คือ [สร้าง MCP Server และรักษาความปลอดภัยด้วย Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

ดูวิธีการทำงานของกระบวนการอนุญาตในภาพด้านล่างนี้:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

ในภาพด้านบน เกิดกระบวนการดังนี้:

- การยืนยันตัวตน/อนุญาตทำผ่าน Microsoft Entra
- Azure API Management ทำหน้าที่เป็นเกตเวย์และใช้โพลิซีเพื่อกำหนดเส้นทางและจัดการทราฟฟิก
- Azure Monitor บันทึกการร้องขอทั้งหมดเพื่อการวิเคราะห์เพิ่มเติม

#### กระบวนการอนุญาต

มาดูรายละเอียดของกระบวนการอนุญาตกัน:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### ข้อกำหนดการอนุญาต MCP

เรียนรู้เพิ่มเติมเกี่ยวกับ [ข้อกำหนดการอนุญาต MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## การนำ Remote MCP Server ไปใช้บน Azure

มาดูกันว่าเราสามารถนำตัวอย่างที่กล่าวถึงไปใช้งานได้หรือไม่:

1. โคลนรีโพสิตอรี

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. ลงทะเบียน `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` รอสักครู่แล้วตรวจสอบว่าการลงทะเบียนเสร็จสมบูรณ์หรือไม่

3. รันคำสั่ง [azd](https://aka.ms/azd) นี้เพื่อจัดเตรียมบริการ api management, function app (พร้อมโค้ด) และทรัพยากร Azure ที่จำเป็นทั้งหมด

    ```shell
    azd up
    ```

    คำสั่งนี้จะนำทรัพยากรทั้งหมดไปใช้งานบน Azure

### การทดสอบเซิร์ฟเวอร์ด้วย MCP Inspector

1. เปิดหน้าต่างเทอร์มินัลใหม่ ติดตั้งและรัน MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    คุณจะเห็นอินเทอร์เฟซคล้ายกับ:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.th.png) 

2. กด CTRL คลิกเพื่อโหลดเว็บแอป MCP Inspector จาก URL ที่แอปแสดง (เช่น http://127.0.0.1:6274/#resources)
3. ตั้งค่าประเภทการส่งข้อมูลเป็น `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` และกด **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **แสดงรายการ Tools** คลิกที่เครื่องมือแล้วกด **Run Tool**

ถ้าทุกขั้นตอนสำเร็จ คุณจะเชื่อมต่อกับเซิร์ฟเวอร์ MCP ได้และสามารถเรียกใช้เครื่องมือได้

## MCP servers สำหรับ Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): ชุดรีโพสิตอรีนี้เป็นเทมเพลตเริ่มต้นอย่างรวดเร็วสำหรับการสร้างและนำ MCP เซิร์ฟเวอร์ระยะไกลแบบกำหนดเองไปใช้โดยใช้ Azure Functions กับ Python, C# .NET หรือ Node/TypeScript

ตัวอย่างเหล่านี้ให้โซลูชันครบถ้วนที่ช่วยให้นักพัฒนาสามารถ:

- สร้างและรันในเครื่อง: พัฒนาและดีบัก MCP เซิร์ฟเวอร์บนเครื่องท้องถิ่น
- นำไปใช้บน Azure: นำไปใช้บนคลาวด์ได้ง่ายด้วยคำสั่ง azd up เพียงคำสั่งเดียว
- เชื่อมต่อจากไคลเอนต์: เชื่อมต่อกับ MCP เซิร์ฟเวอร์จากไคลเอนต์หลากหลาย รวมถึงโหมด Copilot agent ของ VS Code และเครื่องมือ MCP Inspector

### ฟีเจอร์สำคัญ:

- ความปลอดภัยโดยออกแบบ: เซิร์ฟเวอร์ MCP ถูกป้องกันด้วยคีย์และ HTTPS
- ตัวเลือกการยืนยันตัวตน: รองรับ OAuth โดยใช้ระบบยืนยันตัวตนในตัวและ/หรือ API Management
- การแยกเครือข่าย: รองรับการแยกเครือข่ายด้วย Azure Virtual Networks (VNET)
- สถาปัตยกรรมแบบไร้เซิร์ฟเวอร์: ใช้ Azure Functions สำหรับการประมวลผลที่ขยายตัวและขับเคลื่อนด้วยเหตุการณ์
- การพัฒนาในเครื่อง: รองรับการพัฒนาและดีบักในเครื่องอย่างครบถ้วน
- การนำไปใช้งานง่าย: กระบวนการนำไปใช้งานบน Azure ที่ง่ายและรวดเร็ว

รีโพสิตอรีนี้มีไฟล์กำหนดค่าทั้งหมด โค้ดต้นฉบับ และคำจำกัดความโครงสร้างพื้นฐานที่จำเป็นสำหรับเริ่มต้นใช้งาน MCP เซิร์ฟเวอร์ที่พร้อมใช้งานในสภาพแวดล้อมจริงได้อย่างรวดเร็ว

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - ตัวอย่างการใช้งาน MCP ด้วย Azure Functions กับ Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - ตัวอย่างการใช้งาน MCP ด้วย Azure Functions กับ C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - ตัวอย่างการใช้งาน MCP ด้วย Azure Functions กับ Node/TypeScript

## สรุปประเด็นสำคัญ

- SDK ของ MCP ให้เครื่องมือเฉพาะภาษาสำหรับการใช้งาน MCP ที่มั่นคง
- กระบวนการดีบักและทดสอบมีความสำคัญต่อความน่าเชื่อถือของแอปพลิเคชัน MCP
- แม่แบบ prompt ที่นำกลับมาใช้ใหม่ช่วยให้การโต้ตอบกับ AI มีความสม่ำเสมอ
- เวิร์กโฟลว์ที่ออกแบบดีสามารถจัดการงานซับซ้อนได้ด้วยการใช้เครื่องมือหลายตัว
- การใช้งาน MCP ต้องคำนึงถึงความปลอดภัย ประสิทธิภาพ และการจัดการข้อผิดพลาด

## แบบฝึกหัด

ออกแบบเวิร์กโฟลว์ MCP ที่ใช้งานได้จริงเพื่อแก้ปัญหาในโลกจริงของโดเมนคุณ:

1. ระบุเครื่องมือ 3-4 ตัวที่มีประโยชน์สำหรับแก้ปัญหานี้
2. สร้างไดอะแกรมเวิร์กโฟลว์แสดงการทำงานร่วมกันของเครื่องมือเหล่านี้
3. พัฒนาเครื่องมือพื้นฐานตัวใดตัวหนึ่งโดยใช้ภาษาที่คุณถนัด
4. สร้างแม่แบบ prompt ที่ช่วยให้โมเดลใช้เครื่องมือของคุณได้อย่างมีประสิทธิภาพ

## แหล่งข้อมูลเพิ่มเติม


---

ถัดไป: [หัวข้อขั้นสูง](../05-AdvancedTopics/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารฉบับนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่มีความสำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดใด ๆ ที่เกิดจากการใช้การแปลนี้