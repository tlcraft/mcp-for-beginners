<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:52:53+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "th"
}
-->
# การปรับใช้เซิร์ฟเวอร์ MCP

การปรับใช้เซิร์ฟเวอร์ MCP ของคุณจะช่วยให้ผู้อื่นสามารถเข้าถึงเครื่องมือและทรัพยากรของมันได้มากกว่าสภาพแวดล้อมในเครื่องของคุณ มีหลายกลยุทธ์ในการปรับใช้ที่ควรพิจารณา ขึ้นอยู่กับความต้องการของคุณในเรื่องการขยายตัว ความน่าเชื่อถือ และความง่ายในการจัดการ ด้านล่างนี้คุณจะพบคำแนะนำสำหรับการปรับใช้เซิร์ฟเวอร์ MCP ในเครื่อง ในคอนเทนเนอร์ และบนคลาวด์

## ภาพรวม

บทเรียนนี้ครอบคลุมวิธีการปรับใช้แอปเซิร์ฟเวอร์ MCP ของคุณ

## วัตถุประสงค์การเรียนรู้

เมื่อสิ้นสุดบทเรียนนี้ คุณจะสามารถ:

- ประเมินแนวทางการปรับใช้ที่แตกต่างกัน
- ปรับใช้แอปของคุณ

## การพัฒนาและการปรับใช้ในเครื่อง

ถ้าเซิร์ฟเวอร์ของคุณมีไว้เพื่อให้ผู้ใช้ใช้งานบนเครื่องของพวกเขา คุณสามารถทำตามขั้นตอนดังนี้:

1. **ดาวน์โหลดเซิร์ฟเวอร์** ถ้าคุณไม่ได้เขียนเซิร์ฟเวอร์เอง ให้ดาวน์โหลดมันก่อนลงเครื่องของคุณ
1. **เริ่มกระบวนการเซิร์ฟเวอร์**: รันแอปพลิเคชันเซิร์ฟเวอร์ MCP ของคุณ

สำหรับ SSE (ไม่จำเป็นสำหรับเซิร์ฟเวอร์ประเภท stdio)

1. **กำหนดค่าเครือข่าย**: ตรวจสอบให้แน่ใจว่าเซิร์ฟเวอร์สามารถเข้าถึงได้บนพอร์ตที่คาดหวัง
1. **เชื่อมต่อไคลเอนต์**: ใช้ URL การเชื่อมต่อในเครื่อง เช่น `http://localhost:3000`

## การปรับใช้บนคลาวด์

เซิร์ฟเวอร์ MCP สามารถปรับใช้บนแพลตฟอร์มคลาวด์ต่างๆ ได้:

- **ฟังก์ชันเซิร์ฟเวอร์เลส**: ปรับใช้เซิร์ฟเวอร์ MCP ที่มีน้ำหนักเบาเป็นฟังก์ชันเซิร์ฟเวอร์เลส
- **บริการคอนเทนเนอร์**: ใช้บริการอย่างเช่น Azure Container Apps, AWS ECS หรือ Google Cloud Run
- **Kubernetes**: ปรับใช้และจัดการเซิร์ฟเวอร์ MCP ใน Kubernetes clusters เพื่อความพร้อมใช้งานสูง

### ตัวอย่าง: Azure Container Apps

Azure Container Apps รองรับการปรับใช้เซิร์ฟเวอร์ MCP ซึ่งยังอยู่ในระหว่างการพัฒนาและปัจจุบันรองรับเซิร์ฟเวอร์ SSE

นี่คือวิธีที่คุณสามารถทำได้:

1. โคลน repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. รันในเครื่องเพื่อทดสอบ:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. เพื่อทดลองในเครื่อง สร้างไฟล์ *mcp.json* ในไดเรกทอรี *.vscode* และเพิ่มเนื้อหาดังนี้:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  เมื่อเซิร์ฟเวอร์ SSE เริ่มทำงาน คุณสามารถคลิกไอคอนเล่นในไฟล์ JSON คุณควรจะเห็นเครื่องมือบนเซิร์ฟเวอร์ถูกหยิบขึ้นมาโดย GitHub Copilot ดูไอคอนเครื่องมือ

1. เพื่อปรับใช้ รันคำสั่งต่อไปนี้:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

นี่คือวิธีที่คุณสามารถปรับใช้ในเครื่อง ปรับใช้บน Azure ผ่านขั้นตอนเหล่านี้

## แหล่งข้อมูลเพิ่มเติม

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [บทความ Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## ขั้นตอนต่อไป

- ถัดไป: [การดำเนินการในทางปฏิบัติ](/04-PracticalImplementation/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ได้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาที่เป็นต้นฉบับควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้บริการแปลภาษามนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดอันเกิดจากการใช้การแปลนี้