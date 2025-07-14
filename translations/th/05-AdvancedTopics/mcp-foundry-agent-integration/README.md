<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:56:22+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "th"
}
-->
# การรวม Model Context Protocol (MCP) กับ Azure AI Foundry

คู่มือนี้แสดงวิธีการรวมเซิร์ฟเวอร์ Model Context Protocol (MCP) กับเอเจนต์ Azure AI Foundry เพื่อเปิดใช้งานการประสานเครื่องมือที่ทรงพลังและความสามารถ AI สำหรับองค์กร

## บทนำ

Model Context Protocol (MCP) เป็นมาตรฐานเปิดที่ช่วยให้แอปพลิเคชัน AI สามารถเชื่อมต่อกับแหล่งข้อมูลและเครื่องมือภายนอกได้อย่างปลอดภัย เมื่อรวมกับ Azure AI Foundry MCP ช่วยให้เอเจนต์สามารถเข้าถึงและโต้ตอบกับบริการภายนอก API และแหล่งข้อมูลต่างๆ ได้ในรูปแบบมาตรฐาน

การรวมนี้ผสมผสานความยืดหยุ่นของระบบนิเวศเครื่องมือ MCP กับกรอบงานเอเจนต์ที่แข็งแกร่งของ Azure AI Foundry เพื่อมอบโซลูชัน AI ระดับองค์กรที่มีความสามารถในการปรับแต่งอย่างกว้างขวาง

**Note:** หากคุณต้องการใช้ MCP ใน Azure AI Foundry Agent Service ปัจจุบันรองรับเฉพาะภูมิภาคดังต่อไปนี้: westus, westus2, uaenorth, southindia และ switzerlandnorth

## วัตถุประสงค์การเรียนรู้

เมื่อจบคู่มือนี้ คุณจะสามารถ:

- เข้าใจ Model Context Protocol และประโยชน์ของมัน
- ตั้งค่าเซิร์ฟเวอร์ MCP สำหรับใช้งานกับเอเจนต์ Azure AI Foundry
- สร้างและกำหนดค่าเอเจนต์ที่รวมเครื่องมือ MCP
- นำตัวอย่างการใช้งานจริงกับเซิร์ฟเวอร์ MCP มาใช้
- จัดการกับการตอบกลับของเครื่องมือและการอ้างอิงในบทสนทนาเอเจนต์

## ข้อกำหนดเบื้องต้น

ก่อนเริ่มต้น ให้แน่ใจว่าคุณมี:

- การสมัครใช้งาน Azure ที่เข้าถึง AI Foundry ได้
- Python 3.10 ขึ้นไป
- ติดตั้งและกำหนดค่า Azure CLI แล้ว
- สิทธิ์ที่เหมาะสมในการสร้างทรัพยากร AI

## Model Context Protocol (MCP) คืออะไร?

Model Context Protocol คือวิธีมาตรฐานสำหรับแอปพลิเคชัน AI ในการเชื่อมต่อกับแหล่งข้อมูลและเครื่องมือภายนอก ประโยชน์หลักได้แก่:

- **การรวมแบบมาตรฐาน**: อินเทอร์เฟซที่สอดคล้องกันสำหรับเครื่องมือและบริการต่างๆ
- **ความปลอดภัย**: กลไกการตรวจสอบสิทธิ์และอนุญาตที่ปลอดภัย
- **ความยืดหยุ่น**: รองรับแหล่งข้อมูล API และเครื่องมือที่หลากหลาย
- **การขยายตัว**: เพิ่มความสามารถและการรวมใหม่ๆ ได้ง่าย

## การตั้งค่า MCP กับ Azure AI Foundry

### 1. การกำหนดค่าสภาพแวดล้อม

เริ่มต้นด้วยการตั้งค่าตัวแปรสภาพแวดล้อมและ dependencies:

```python
import os
import time
import json
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential


### 1. Initialize the AI Project Client

```python
project_client = AIProjectClient(
    endpoint="https://your-project-endpoint.services.ai.azure.com/api/projects/your-project",
    credential=DefaultAzureCredential(),
)
```

### 2. Create an Agent with MCP Tools

Configure an agent with MCP server integration:

```python
with project_client:
    agent = project_client.agents.create_agent(
        model="gpt-4.1-nano", 
        name="mcp_agent", 
        instructions="คุณเป็นผู้ช่วยที่เป็นประโยชน์ ใช้เครื่องมือที่มีเพื่อให้คำตอบ และอย่าลืมอ้างอิงแหล่งข้อมูลของคุณ",
        tools=[
            {
                "type": "mcp",
                "server_label": "microsoft_docs",
                "server_url": "https://learn.microsoft.com/api/mcp",
                "require_approval": "never"
            }
        ],
        tool_resources=None
    )
    print(f"สร้างเอเจนต์แล้ว, รหัสเอเจนต์: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # ตัวระบุสำหรับเซิร์ฟเวอร์ MCP
    "server_url": "https://api.example.com/mcp", # จุดเชื่อมต่อเซิร์ฟเวอร์ MCP
    "require_approval": "never"                 # นโยบายการอนุมัติ: ตอนนี้รองรับแค่ "never"
}
```

## Complete Example: Using Microsoft Learn MCP Server

Here's a complete example that demonstrates creating an agent with MCP integration and processing a conversation:

```python
import time
import json
import os
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential

def create_mcp_agent_example():

    project_client = AIProjectClient(
        endpoint="https://your-endpoint.services.ai.azure.com/api/projects/your-project",
        credential=DefaultAzureCredential(),
    )

    with project_client:
        # สร้างเอเจนต์พร้อมเครื่องมือ MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="คุณเป็นผู้ช่วยที่เชี่ยวชาญด้านเอกสาร Microsoft ใช้เซิร์ฟเวอร์ Microsoft Learn MCP เพื่อค้นหาข้อมูลที่ถูกต้องและทันสมัย และอย่าลืมอ้างอิงแหล่งข้อมูลเสมอ",
            tools=[
                {
                    "type": "mcp",
                    "server_label": "mslearn",
                    "server_url": "https://learn.microsoft.com/api/mcp",
                    "require_approval": "never"
                }
            ],
            tool_resources=None
        )
        print(f"สร้างเอเจนต์แล้ว, รหัสเอเจนต์: {agent.id}")    
        
        # สร้างเธรดบทสนทนา
        thread = project_client.agents.threads.create()
        print(f"สร้างเธรดแล้ว, รหัสเธรด: {thread.id}")

        # ส่งข้อความ
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="What is .NET MAUI? How does it compare to Xamarin.Forms?",
        )
        print(f"สร้างข้อความแล้ว, รหัสข้อความ: {message.id}")

        # รันเอเจนต์
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # ตรวจสอบสถานะจนเสร็จ
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"สถานะการรัน: {run.status}")

        # ตรวจสอบขั้นตอนการรันและการเรียกเครื่องมือ
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"ขั้นตอนการรัน: {step.id}, สถานะ: {step.status}, ประเภท: {step.type}")
            if step.type == "tool_calls":
                print("รายละเอียดการเรียกเครื่องมือ:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # แสดงบทสนทนา
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## การแก้ไขปัญหาที่พบบ่อย

### 1. ปัญหาการเชื่อมต่อ
- ตรวจสอบว่า URL ของเซิร์ฟเวอร์ MCP เข้าถึงได้
- ตรวจสอบข้อมูลรับรองการตรวจสอบสิทธิ์
- ตรวจสอบการเชื่อมต่อเครือข่าย

### 2. การเรียกเครื่องมือล้มเหลว
- ตรวจสอบอาร์กิวเมนต์และรูปแบบของเครื่องมือ
- ตรวจสอบข้อกำหนดเฉพาะของเซิร์ฟเวอร์
- ใช้การจัดการข้อผิดพลาดที่เหมาะสม

### 3. ปัญหาด้านประสิทธิภาพ
- ปรับความถี่ในการเรียกเครื่องมือ
- ใช้การแคชเมื่อเหมาะสม
- ตรวจสอบเวลาตอบสนองของเซิร์ฟเวอร์

## ขั้นตอนถัดไป

เพื่อเพิ่มประสิทธิภาพการรวม MCP ของคุณ:

1. **สำรวจเซิร์ฟเวอร์ MCP แบบกำหนดเอง**: สร้างเซิร์ฟเวอร์ MCP ของคุณเองสำหรับแหล่งข้อมูลเฉพาะ
2. **ใช้งานความปลอดภัยขั้นสูง**: เพิ่ม OAuth2 หรือกลไกการตรวจสอบสิทธิ์แบบกำหนดเอง
3. **ติดตามและวิเคราะห์**: ใช้งานการบันทึกและการตรวจสอบการใช้งานเครื่องมือ
4. **ขยายโซลูชันของคุณ**: พิจารณาการบาลานซ์โหลดและสถาปัตยกรรมเซิร์ฟเวอร์ MCP แบบกระจาย

## แหล่งข้อมูลเพิ่มเติม

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## การสนับสนุน

สำหรับการสนับสนุนและคำถามเพิ่มเติม:
- ดูเอกสาร [Azure AI Foundry documentation](https://learn.microsoft.com/azure/ai-foundry/)
- ตรวจสอบ [MCP community resources](https://modelcontextprotocol.io/)

## ต่อไปคืออะไร

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้