<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5384bbb2a92d00d5d7e66274dbe0331d",
  "translation_date": "2025-07-13T22:53:31+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "th"
}
-->
# การใช้งานจริง

การใช้งานจริงคือจุดที่พลังของ Model Context Protocol (MCP) กลายเป็นสิ่งที่จับต้องได้ แม้ว่าการเข้าใจทฤษฎีและสถาปัตยกรรมเบื้องหลัง MCP จะสำคัญ แต่คุณค่าที่แท้จริงจะเกิดขึ้นเมื่อคุณนำแนวคิดเหล่านี้ไปใช้สร้าง ทดสอบ และปรับใช้โซลูชันที่แก้ไขปัญหาในโลกจริง บทนี้จะเชื่อมช่องว่างระหว่างความรู้เชิงแนวคิดกับการพัฒนาจริง โดยแนะนำคุณผ่านกระบวนการนำแอปพลิเคชันที่ใช้ MCP มาใช้งาน

ไม่ว่าคุณจะพัฒนาผู้ช่วยอัจฉริยะ ผสาน AI เข้ากับเวิร์กโฟลว์ธุรกิจ หรือสร้างเครื่องมือเฉพาะสำหรับการประมวลผลข้อมูล MCP มอบพื้นฐานที่ยืดหยุ่น การออกแบบที่ไม่ขึ้นกับภาษาโปรแกรมและ SDK อย่างเป็นทางการสำหรับภาษายอดนิยมช่วยให้เข้าถึงได้สำหรับนักพัฒนาหลากหลายกลุ่ม โดยใช้ SDK เหล่านี้ คุณสามารถสร้างต้นแบบ ทดสอบ และขยายโซลูชันของคุณได้อย่างรวดเร็วในหลายแพลตฟอร์มและสภาพแวดล้อม

ในส่วนถัดไป คุณจะพบตัวอย่างใช้งานจริง โค้ดตัวอย่าง และกลยุทธ์การปรับใช้ที่แสดงวิธีการใช้งาน MCP ใน C#, Java, TypeScript, JavaScript และ Python คุณจะได้เรียนรู้วิธีดีบักและทดสอบเซิร์ฟเวอร์ MCP จัดการ API และปรับใช้โซลูชันบนคลาวด์ด้วย Azure แหล่งข้อมูลเหล่านี้ถูกออกแบบมาเพื่อเร่งการเรียนรู้และช่วยให้คุณสร้างแอป MCP ที่มั่นคงและพร้อมใช้งานในสภาพแวดล้อมจริงได้อย่างมั่นใจ

## ภาพรวม

บทเรียนนี้เน้นด้านการใช้งานจริงของ MCP ในหลายภาษาโปรแกรม เราจะสำรวจวิธีใช้ MCP SDK ใน C#, Java, TypeScript, JavaScript และ Python เพื่อสร้างแอปพลิเคชันที่มั่นคง ดีบักและทดสอบเซิร์ฟเวอร์ MCP รวมถึงสร้างทรัพยากร, prompts และเครื่องมือที่นำกลับมาใช้ใหม่ได้

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:
- นำโซลูชัน MCP ไปใช้งานโดยใช้ SDK อย่างเป็นทางการในหลายภาษาโปรแกรม
- ดีบักและทดสอบเซิร์ฟเวอร์ MCP อย่างเป็นระบบ
- สร้างและใช้ฟีเจอร์ของเซิร์ฟเวอร์ (Resources, Prompts และ Tools)
- ออกแบบเวิร์กโฟลว์ MCP ที่มีประสิทธิภาพสำหรับงานที่ซับซ้อน
- ปรับแต่งการใช้งาน MCP ให้เหมาะสมกับประสิทธิภาพและความน่าเชื่อถือ

## แหล่งข้อมูล SDK อย่างเป็นทางการ

Model Context Protocol มี SDK อย่างเป็นทางการสำหรับหลายภาษา:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## การใช้งาน MCP SDK

ส่วนนี้มีตัวอย่างใช้งานจริงของ MCP ในหลายภาษาโปรแกรม คุณสามารถดูโค้ดตัวอย่างได้ในไดเรกทอรี `samples` ที่จัดเรียงตามภาษา

### ตัวอย่างที่มีให้

ที่เก็บนี้มี [ตัวอย่างการใช้งาน](../../../04-PracticalImplementation/samples) ในภาษาต่อไปนี้:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

แต่ละตัวอย่างแสดงแนวคิดหลักของ MCP และรูปแบบการใช้งานสำหรับภาษานั้นๆ และระบบนิเวศที่เกี่ยวข้อง

## ฟีเจอร์หลักของเซิร์ฟเวอร์

เซิร์ฟเวอร์ MCP สามารถใช้งานฟีเจอร์ใดก็ได้ตามนี้:

### Resources
Resources ให้บริบทและข้อมูลสำหรับผู้ใช้หรือโมเดล AI ใช้งาน เช่น:
- ที่เก็บเอกสาร
- ฐานความรู้
- แหล่งข้อมูลที่มีโครงสร้าง
- ระบบไฟล์

### Prompts
Prompts คือข้อความและเวิร์กโฟลว์ที่เป็นแม่แบบสำหรับผู้ใช้ เช่น:
- เทมเพลตบทสนทนาที่กำหนดไว้ล่วงหน้า
- รูปแบบการโต้ตอบที่มีการแนะนำ
- โครงสร้างบทสนทนาเฉพาะทาง

### Tools
Tools คือฟังก์ชันที่โมเดล AI สามารถเรียกใช้งานได้ เช่น:
- เครื่องมือประมวลผลข้อมูล
- การผสานรวม API ภายนอก
- ความสามารถในการคำนวณ
- ฟังก์ชันการค้นหา

## ตัวอย่างการใช้งาน: C#

ที่เก็บ SDK อย่างเป็นทางการของ C# มีตัวอย่างหลายแบบที่แสดงแง่มุมต่างๆ ของ MCP:

- **Basic MCP Client**: ตัวอย่างง่ายๆ แสดงวิธีสร้าง MCP client และเรียกใช้ tools
- **Basic MCP Server**: เซิร์ฟเวอร์พื้นฐานที่ลงทะเบียน tools อย่างง่าย
- **Advanced MCP Server**: เซิร์ฟเวอร์ครบฟีเจอร์พร้อมการลงทะเบียน tools, การตรวจสอบสิทธิ์ และการจัดการข้อผิดพลาด
- **ASP.NET Integration**: ตัวอย่างการผสานรวมกับ ASP.NET Core
- **Tool Implementation Patterns**: รูปแบบต่างๆ ในการสร้าง tools ที่มีความซับซ้อนแตกต่างกัน

SDK C# ของ MCP ยังอยู่ในช่วงพรีวิวและ API อาจมีการเปลี่ยนแปลง เราจะอัปเดตบล็อกนี้อย่างต่อเนื่องตามการพัฒนา SDK

### ฟีเจอร์สำคัญ
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- การสร้าง [MCP Server แรกของคุณ](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

สำหรับตัวอย่างการใช้งาน C# แบบครบถ้วน โปรดเยี่ยมชม [ที่เก็บตัวอย่าง SDK C# อย่างเป็นทางการ](https://github.com/modelcontextprotocol/csharp-sdk)

## ตัวอย่างการใช้งาน: Java

Java SDK มีตัวเลือกการใช้งาน MCP ที่แข็งแกร่งพร้อมฟีเจอร์ระดับองค์กร

### ฟีเจอร์สำคัญ

- การผสานรวมกับ Spring Framework
- ความปลอดภัยของชนิดข้อมูลที่เข้มงวด
- รองรับการเขียนโปรแกรมเชิงปฏิกิริยา
- การจัดการข้อผิดพลาดอย่างครบถ้วน

สำหรับตัวอย่างการใช้งาน Java แบบครบถ้วน ดูได้ที่ [Java sample](samples/java/containerapp/README.md) ในไดเรกทอรีตัวอย่าง

## ตัวอย่างการใช้งาน: JavaScript

JavaScript SDK มอบวิธีการใช้งาน MCP ที่เบาและยืดหยุ่น

### ฟีเจอร์สำคัญ

- รองรับ Node.js และเบราว์เซอร์
- API แบบ Promise
- ผสานรวมง่ายกับ Express และเฟรมเวิร์กอื่นๆ
- รองรับ WebSocket สำหรับการสตรีม

สำหรับตัวอย่างการใช้งาน JavaScript แบบครบถ้วน ดูได้ที่ [JavaScript sample](samples/javascript/README.md) ในไดเรกทอรีตัวอย่าง

## ตัวอย่างการใช้งาน: Python

Python SDK นำเสนอวิธีการใช้งาน MCP ที่เป็น Pythonic พร้อมการผสานรวมกับเฟรมเวิร์ก ML อย่างยอดเยี่ยม

### ฟีเจอร์สำคัญ

- รองรับ async/await ด้วย asyncio
- ผสานรวมกับ Flask และ FastAPI
- การลงทะเบียน tools ที่ง่าย
- การผสานรวมเนทีฟกับไลบรารี ML ยอดนิยม

สำหรับตัวอย่างการใช้งาน Python แบบครบถ้วน ดูได้ที่ [Python sample](samples/python/README.md) ในไดเรกทอรีตัวอย่าง

## การจัดการ API

Azure API Management เป็นคำตอบที่ดีสำหรับการรักษาความปลอดภัยของ MCP Servers แนวคิดคือการวาง Azure API Management ไว้หน้าคลัสเตอร์ MCP Server ของคุณและให้มันจัดการฟีเจอร์ที่คุณน่าจะต้องการ เช่น:

- การจำกัดอัตราการใช้งาน
- การจัดการโทเค็น
- การตรวจสอบ
- การกระจายโหลด
- ความปลอดภัย

### ตัวอย่าง Azure

นี่คือตัวอย่าง Azure ที่ทำสิ่งนี้อย่างชัดเจน เช่น [การสร้าง MCP Server และรักษาความปลอดภัยด้วย Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

ดูวิธีการทำงานของโฟลว์การอนุญาตในภาพด้านล่าง:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

ในภาพด้านบนเกิดเหตุการณ์ดังนี้:

- การตรวจสอบสิทธิ์/อนุญาตเกิดขึ้นโดยใช้ Microsoft Entra
- Azure API Management ทำหน้าที่เป็นเกตเวย์และใช้โพลิซีเพื่อกำหนดเส้นทางและจัดการทราฟฟิก
- Azure Monitor บันทึกคำขอทั้งหมดเพื่อการวิเคราะห์เพิ่มเติม

#### โฟลว์การอนุญาต

มาดูโฟลว์การอนุญาตอย่างละเอียดมากขึ้น:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### ข้อกำหนดการอนุญาต MCP

เรียนรู้เพิ่มเติมเกี่ยวกับ [ข้อกำหนดการอนุญาต MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## การปรับใช้ Remote MCP Server บน Azure

มาดูว่าคุณสามารถปรับใช้ตัวอย่างที่กล่าวถึงก่อนหน้านี้ได้อย่างไร:

1. โคลนรีโป

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. ลงทะเบียน resource provider `Microsoft.App`
    * หากใช้ Azure CLI ให้รันคำสั่ง `az provider register --namespace Microsoft.App --wait`
    * หากใช้ Azure PowerShell ให้รัน `Register-AzResourceProvider -ProviderNamespace Microsoft.App` จากนั้นรัน `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` หลังจากเวลาหนึ่งเพื่อตรวจสอบว่าการลงทะเบียนเสร็จสมบูรณ์หรือไม่

2. รันคำสั่ง [azd](https://aka.ms/azd) นี้เพื่อจัดเตรียมบริการ API Management, ฟังก์ชันแอป (พร้อมโค้ด) และทรัพยากร Azure ที่จำเป็นทั้งหมด

    ```shell
    azd up
    ```

    คำสั่งนี้จะปรับใช้ทรัพยากรทั้งหมดบน Azure

### การทดสอบเซิร์ฟเวอร์ของคุณด้วย MCP Inspector

1. ใน **หน้าต่างเทอร์มินัลใหม่** ติดตั้งและรัน MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    คุณจะเห็นอินเทอร์เฟซคล้ายกับ:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.th.png) 

1. กด CTRL คลิกเพื่อโหลดเว็บแอป MCP Inspector จาก URL ที่แอปแสดง (เช่น http://127.0.0.1:6274/#resources)
1. ตั้งค่าประเภทการส่งข้อมูลเป็น `SSE`
1. ตั้งค่า URL เป็นจุดเชื่อมต่อ API Management SSE ที่กำลังรันซึ่งแสดงหลังคำสั่ง `azd up` แล้วกด **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **แสดงรายการ Tools** คลิกที่เครื่องมือและกด **Run Tool**

ถ้าทุกขั้นตอนทำงานถูกต้อง คุณจะเชื่อมต่อกับเซิร์ฟเวอร์ MCP ได้และสามารถเรียกใช้เครื่องมือได้

## MCP servers สำหรับ Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): ชุดรีโปนี้เป็นเทมเพลตเริ่มต้นสำหรับการสร้างและปรับใช้เซิร์ฟเวอร์ MCP ระยะไกลแบบกำหนดเองโดยใช้ Azure Functions กับ Python, C# .NET หรือ Node/TypeScript

ตัวอย่างเหล่านี้มอบโซลูชันครบวงจรที่ช่วยให้นักพัฒนาสามารถ:

- สร้างและรันในเครื่อง: พัฒนาและดีบักเซิร์ฟเวอร์ MCP บนเครื่องท้องถิ่น
- ปรับใช้บน Azure: ปรับใช้บนคลาวด์ได้ง่ายด้วยคำสั่ง azd up เพียงคำสั่งเดียว
- เชื่อมต่อจากไคลเอนต์: เชื่อมต่อกับเซิร์ฟเวอร์ MCP จากไคลเอนต์หลากหลาย รวมถึงโหมด Copilot agent ของ VS Code และเครื่องมือ MCP Inspector

### ฟีเจอร์สำคัญ:

- ความปลอดภัยโดยการออกแบบ: เซิร์ฟเวอร์ MCP ถูกปกป้องด้วยคีย์และ HTTPS
- ตัวเลือกการตรวจสอบสิทธิ์: รองรับ OAuth โดยใช้ระบบตรวจสอบสิทธิ์ในตัวและ/หรือ API Management
- การแยกเครือข่าย: รองรับการแยกเครือข่ายด้วย Azure Virtual Networks (VNET)
- สถาปัตยกรรมแบบ Serverless: ใช้ Azure Functions สำหรับการประมวลผลที่ปรับขนาดได้และขับเคลื่อนด้วยเหตุการณ์
- การพัฒนาในเครื่อง: รองรับการพัฒนาและดีบักในเครื่องอย่างครบถ้วน
- การปรับใช้ที่ง่าย: กระบวนการปรับใช้ที่ราบรื่นไปยัง Azure

ที่เก็บนี้รวมไฟล์กำหนดค่าทั้งหมด โค้ดต้นฉบับ และคำจำกัดความโครงสร้างพื้นฐานที่จำเป็นเพื่อเริ่มต้นใช้งานเซิร์ฟเวอร์ MCP ที่พร้อมใช้งานในสภาพแวดล้อมจริงได้อย่างรวดเร็ว

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - ตัวอย่างการใช้งาน MCP ด้วย Azure Functions และ Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - ตัวอย่างการใช้งาน MCP ด้วย Azure Functions และ C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - ตัวอย่างการใช้งาน MCP ด้วย Azure Functions และ Node/TypeScript

## สรุปประเด็นสำคัญ

- SDK MCP มอบเครื่องมือเฉพาะภาษาสำหรับการสร้างโซลูชัน MCP ที่มั่นคง
- กระบวนการดีบักและทดสอบเป็นสิ่งสำคัญสำหรับแอป MCP ที่เชื่อถือได้
- เทมเพลต prompt ที่นำกลับมาใช้ใหม่ได้ช่วยให้การโต้ตอบกับ AI มีความสม่ำเสมอ
- เวิร์กโฟลว์ที่ออกแบบดีสามารถจัดการงานซับซ้อนได้โดยใช้หลายเครื่องมือร่วมกัน
- การใช้งาน MCP ต้องคำนึงถึงความปลอดภัย ประสิทธิภาพ และการจัดการข้อผิดพลาด

## แบบฝึกหัด

ออกแบบเวิร์กโฟลว์ MCP ที่ใช้งานได้จริงเพื่อแก้ปัญหาในโดเมนของคุณ:

1. ระบุเครื่องมือ 3-4 ตัวที่มีประโยชน์สำหรับแก้ปัญหานี้
2. สร้างแผนภาพเวิร์กโฟลว์แสดงการทำงานร่วมกันของเครื่องมือเหล่านี้
3. พัฒนาเวอร์ชันพื้นฐานของเครื่องมือหนึ่งตัวโดยใช้ภาษาที่คุณถนัด
4. สร้างเทมเพลต prompt ที่ช่วยให้โมเดลใช้เครื่องมือของคุณได้อย่างมีประสิทธิภาพ

## แหล่งข้อมูลเพิ่มเติม


---

ถัดไป: [หัวข้อขั้นสูง](../05-AdvancedTopics/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้