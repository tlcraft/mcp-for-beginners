<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "222e01c3002a33355806d60d558d9429",
  "translation_date": "2025-07-14T09:35:12+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "th"
}
-->
มาคุยกันเพิ่มเติมเกี่ยวกับการใช้ส่วนติดต่อแบบกราฟิกในส่วนถัดไปกันเถอะ

## แนวทาง

นี่คือวิธีการที่เราควรดำเนินการในภาพรวม:

- กำหนดค่าไฟล์เพื่อค้นหา MCP Server ของเรา
- เริ่มต้น/เชื่อมต่อกับเซิร์ฟเวอร์ดังกล่าวเพื่อให้มันแสดงรายการความสามารถของมัน
- ใช้ความสามารถเหล่านั้นผ่านอินเทอร์เฟซ GitHub Copilot Chat

เยี่ยมเลย ตอนนี้ที่เราเข้าใจกระบวนการแล้ว ลองมาใช้ MCP Server ผ่าน Visual Studio Code ด้วยแบบฝึกหัดนี้กัน

## แบบฝึกหัด: การใช้งานเซิร์ฟเวอร์

ในแบบฝึกหัดนี้ เราจะกำหนดค่า Visual Studio Code เพื่อค้นหา MCP Server ของคุณ เพื่อให้สามารถใช้งานผ่านอินเทอร์เฟซ GitHub Copilot Chat ได้

### -0- ขั้นตอนเตรียมเปิดใช้งานการค้นหา MCP Server

คุณอาจต้องเปิดใช้งานการค้นหา MCP Servers

1. ไปที่ `File -> Preferences -> Settings` ใน Visual Studio Code

2. ค้นหาคำว่า "MCP" และเปิดใช้งาน `chat.mcp.discovery.enabled` ในไฟล์ settings.json

### -1- สร้างไฟล์ config

เริ่มต้นด้วยการสร้างไฟล์ config ในโฟลเดอร์หลักของโปรเจกต์ คุณจะต้องมีไฟล์ชื่อ MCP.json และวางไว้ในโฟลเดอร์ชื่อ .vscode ไฟล์ควรมีลักษณะดังนี้:

```text
.vscode
|-- mcp.json
```

ต่อไป มาดูวิธีเพิ่มรายการเซิร์ฟเวอร์กัน

### -2- กำหนดค่าเซิร์ฟเวอร์

เพิ่มเนื้อหาต่อไปนี้ใน *mcp.json*:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

ตัวอย่างง่ายๆ ข้างต้นแสดงวิธีเริ่มเซิร์ฟเวอร์ที่เขียนด้วย Node.js สำหรับ runtime อื่นๆ ให้ระบุคำสั่งที่ถูกต้องสำหรับการเริ่มเซิร์ฟเวอร์โดยใช้ `command` และ `args`

### -3- เริ่มเซิร์ฟเวอร์

ตอนนี้ที่คุณเพิ่มรายการแล้ว ลองเริ่มเซิร์ฟเวอร์กัน:

1. หา entry ของคุณใน *mcp.json* และตรวจสอบให้แน่ใจว่าคุณเห็นไอคอน "เล่น" (play):

  ![Starting server in Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.th.png)  

2. คลิกไอคอน "เล่น" คุณจะเห็นไอคอนเครื่องมือใน GitHub Copilot Chat เพิ่มจำนวนเครื่องมือที่พร้อมใช้งาน หากคุณคลิกไอคอนเครื่องมือดังกล่าว คุณจะเห็นรายการเครื่องมือที่ลงทะเบียนไว้ คุณสามารถเลือกหรือลบเลือกแต่ละเครื่องมือได้ตามต้องการว่าต้องการให้ GitHub Copilot ใช้เป็นบริบทหรือไม่:

  ![Starting server in Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.th.png)

3. เพื่อเรียกใช้เครื่องมือ ให้พิมพ์คำสั่งที่คุณรู้ว่าจะตรงกับคำอธิบายของเครื่องมือ เช่น คำสั่งว่า "add 22 to 1":

  ![Running a tool from GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.th.png)

  คุณควรเห็นคำตอบเป็น 23

## การบ้าน

ลองเพิ่มรายการเซิร์ฟเวอร์ในไฟล์ *mcp.json* ของคุณ และตรวจสอบให้แน่ใจว่าคุณสามารถเริ่ม/หยุดเซิร์ฟเวอร์ได้ รวมถึงสามารถสื่อสารกับเครื่องมือบนเซิร์ฟเวอร์ผ่านอินเทอร์เฟซ GitHub Copilot Chat ได้ด้วย

## วิธีแก้ไข

[Solution](./solution/README.md)

## ข้อสรุปสำคัญ

ข้อสรุปจากบทนี้คือ:

- Visual Studio Code เป็นไคลเอนต์ที่ยอดเยี่ยมที่ช่วยให้คุณใช้งาน MCP Servers และเครื่องมือต่างๆ ได้หลายตัว
- อินเทอร์เฟซ GitHub Copilot Chat คือวิธีที่คุณโต้ตอบกับเซิร์ฟเวอร์เหล่านั้น
- คุณสามารถขอข้อมูลจากผู้ใช้ เช่น คีย์ API ที่จะส่งไปยัง MCP Server เมื่อกำหนดค่า entry ของเซิร์ฟเวอร์ในไฟล์ *mcp.json*

## ตัวอย่าง

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## แหล่งข้อมูลเพิ่มเติม

- [เอกสาร Visual Studio](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## ต่อไป

- ถัดไป: [การสร้าง SSE Server](../05-sse-server/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้