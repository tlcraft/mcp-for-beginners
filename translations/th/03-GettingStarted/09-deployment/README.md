<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:29:49+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "th"
}
-->
# การปรับใช้เซิร์ฟเวอร์ MCP

การปรับใช้เซิร์ฟเวอร์ MCP ของคุณช่วยให้ผู้อื่นสามารถเข้าถึงเครื่องมือและทรัพยากรได้เกินกว่าการใช้งานในเครื่องของคุณเอง มีหลายวิธีในการปรับใช้ ขึ้นอยู่กับความต้องการเรื่องการขยายตัว ความน่าเชื่อถือ และความสะดวกในการจัดการ ด้านล่างนี้คือคำแนะนำสำหรับการปรับใช้เซิร์ฟเวอร์ MCP ในเครื่อง คอนเทนเนอร์ และบนคลาวด์

## ภาพรวม

บทเรียนนี้ครอบคลุมวิธีการปรับใช้แอป MCP Server ของคุณ

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- ประเมินวิธีการปรับใช้ที่แตกต่างกันได้
- ปรับใช้แอปของคุณ

## การพัฒนาและปรับใช้ในเครื่อง

ถ้าเซิร์ฟเวอร์ของคุณถูกออกแบบมาให้ใช้งานบนเครื่องของผู้ใช้ คุณสามารถทำตามขั้นตอนดังนี้:

1. **ดาวน์โหลดเซิร์ฟเวอร์** หากคุณไม่ได้เขียนเซิร์ฟเวอร์เอง ให้ดาวน์โหลดมาเก็บไว้ในเครื่องก่อน
1. **เริ่มต้นกระบวนการเซิร์ฟเวอร์**: รันแอป MCP Server ของคุณ

สำหรับ SSE (ไม่จำเป็นสำหรับเซิร์ฟเวอร์แบบ stdio)

1. **ตั้งค่าเครือข่าย**: ตรวจสอบให้แน่ใจว่าเซิร์ฟเวอร์สามารถเข้าถึงได้ผ่านพอร์ตที่กำหนดไว้
1. **เชื่อมต่อไคลเอนต์**: ใช้ URL การเชื่อมต่อในเครื่อง เช่น `http://localhost:3000`

## การปรับใช้บนคลาวด์

เซิร์ฟเวอร์ MCP สามารถปรับใช้บนแพลตฟอร์มคลาวด์ต่างๆ ได้ดังนี้:

- **Serverless Functions**: ปรับใช้เซิร์ฟเวอร์ MCP แบบน้ำหนักเบาในรูปแบบฟังก์ชันไร้เซิร์ฟเวอร์
- **Container Services**: ใช้บริการเช่น Azure Container Apps, AWS ECS หรือ Google Cloud Run
- **Kubernetes**: ปรับใช้และจัดการเซิร์ฟเวอร์ MCP ในคลัสเตอร์ Kubernetes เพื่อความพร้อมใช้งานสูง

### ตัวอย่าง: Azure Container Apps

Azure Container Apps รองรับการปรับใช้ MCP Servers ซึ่งยังอยู่ในระหว่างการพัฒนาและปัจจุบันรองรับเฉพาะเซิร์ฟเวอร์ SSE

นี่คือวิธีที่คุณสามารถทำได้:

1. โคลนรีโป:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. รันในเครื่องเพื่อลองทดสอบ:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. เพื่อทดสอบในเครื่อง สร้างไฟล์ *mcp.json* ในโฟลเดอร์ *.vscode* และเพิ่มเนื้อหาดังนี้:

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

  เมื่อเซิร์ฟเวอร์ SSE เริ่มทำงานแล้ว คุณสามารถคลิกไอคอนเล่นในไฟล์ JSON ได้ คุณจะเห็นเครื่องมือบนเซิร์ฟเวอร์ถูก GitHub Copilot ดึงขึ้นมา ดูที่ไอคอนเครื่องมือ

1. ในการปรับใช้ ให้รันคำสั่งต่อไปนี้:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

เท่านี้ก็เสร็จเรียบร้อย ปรับใช้ในเครื่อง หรือปรับใช้บน Azure ตามขั้นตอนนี้ได้เลย

## แหล่งข้อมูลเพิ่มเติม

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [บทความ Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [รีโป Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## ต่อไปคืออะไร

- ถัดไป: [การใช้งานจริง](/04-PracticalImplementation/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้มีความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลโดยอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลสำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญที่เป็นมนุษย์ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้