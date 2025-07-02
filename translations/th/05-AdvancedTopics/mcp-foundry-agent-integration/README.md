<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:15:44+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "th"
}
-->
# การรวม Model Context Protocol (MCP) กับ Azure AI Foundry

คู่มือนี้จะแสดงวิธีการรวมเซิร์ฟเวอร์ Model Context Protocol (MCP) กับเอเจนต์ Azure AI Foundry เพื่อให้สามารถจัดการเครื่องมืออย่างทรงพลังและใช้ความสามารถ AI สำหรับองค์กรได้

## บทนำ

Model Context Protocol (MCP) คือมาตรฐานเปิดที่ช่วยให้แอปพลิเคชัน AI สามารถเชื่อมต่อกับแหล่งข้อมูลและเครื่องมือภายนอกได้อย่างปลอดภัย เมื่อรวมกับ Azure AI Foundry แล้ว MCP จะช่วยให้เอเจนต์เข้าถึงและโต้ตอบกับบริการภายนอก API และแหล่งข้อมูลต่าง ๆ ในรูปแบบที่เป็นมาตรฐานเดียวกัน

การรวมนี้ผสมผสานความยืดหยุ่นของระบบเครื่องมือ MCP กับกรอบการทำงานเอเจนต์ที่แข็งแกร่งของ Azure AI Foundry เพื่อมอบโซลูชัน AI สำหรับองค์กรที่มีความสามารถในการปรับแต่งอย่างกว้างขวาง

**Note:** หากต้องการใช้ MCP ใน Azure AI Foundry Agent Service ปัจจุบันรองรับเฉพาะภูมิภาคดังต่อไปนี้: westus, westus2, uaenorth, southindia และ switzerlandnorth

## วัตถุประสงค์การเรียนรู้

หลังจากทำตามคู่มือนี้ คุณจะสามารถ:

- เข้าใจ Model Context Protocol และประโยชน์ของมัน
- ตั้งค่าเซิร์ฟเวอร์ MCP เพื่อใช้งานกับเอเจนต์ Azure AI Foundry
- สร้างและกำหนดค่าเอเจนต์ที่รวมเครื่องมือ MCP
- นำตัวอย่างใช้งานจริงกับเซิร์ฟเวอร์ MCP มาใช้
- จัดการกับการตอบกลับของเครื่องมือและการอ้างอิงในบทสนทนาเอเจนต์

## ข้อกำหนดเบื้องต้น

ก่อนเริ่มต้น ตรวจสอบให้แน่ใจว่าคุณมี:

- การสมัครใช้งาน Azure พร้อมการเข้าถึง AI Foundry
- Python 3.10 ขึ้นไป
- ติดตั้งและกำหนดค่า Azure CLI แล้ว
- สิทธิ์ที่เหมาะสมในการสร้างทรัพยากร AI

## Model Context Protocol (MCP) คืออะไร?

Model Context Protocol คือวิธีการมาตรฐานสำหรับแอปพลิเคชัน AI ในการเชื่อมต่อกับแหล่งข้อมูลและเครื่องมือภายนอก ประโยชน์หลักได้แก่:

- **การรวมแบบมาตรฐาน**: อินเทอร์เฟซที่สอดคล้องกันสำหรับเครื่องมือและบริการต่าง ๆ
- **ความปลอดภัย**: กลไกการยืนยันตัวตนและการอนุญาตที่ปลอดภัย
- **ความยืดหยุ่น**: รองรับแหล่งข้อมูล API และเครื่องมือที่หลากหลาย
- **การขยายตัวได้ง่าย**: เพิ่มความสามารถและการรวมระบบใหม่ ๆ ได้ง่าย

## การตั้งค่า MCP กับ Azure AI Foundry

### 1. การกำหนดค่าสภาพแวดล้อม

เริ่มต้นด้วยการตั้งค่าตัวแปรสภาพแวดล้อมและการติดตั้งที่จำเป็น:

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
        instructions="คุณเป็นผู้ช่วยที่เป็นประโยชน์ ใช้เครื่องมือที่มีเพื่อช่วยตอบคำถาม และอย่าลืมอ้างอิงแหล่งข้อมูลของคุณ",
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
    "require_approval": "never"                 # นโยบายการอนุมัติ: ปัจจุบันรองรับแค่ "never"
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
        # สร้างเอเจนต์ที่ใช้เครื่องมือ MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="คุณเป็นผู้ช่วยที่เชี่ยวชาญด้านเอกสารของ Microsoft ใช้เซิร์ฟเวอร์ MCP ของ Microsoft Learn เพื่อค้นหาข้อมูลที่ถูกต้องและทันสมัย และอย่าลืมอ้างอิงแหล่งข้อมูลเสมอ",
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
        
        # สร้างกระทู้บทสนทนา
        thread = project_client.agents.threads.create()
        print(f"สร้างกระทู้แล้ว, รหัสกระทู้: {thread.id}")

        # ส่งข้อความ
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="NET MAUI คืออะไร? และเปรียบเทียบกับ Xamarin.Forms อย่างไร?",
        )
        print(f"สร้างข้อความแล้ว, รหัสข้อความ: {message.id}")

        # รันเอเจนต์
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # ตรวจสอบสถานะจนเสร็จสิ้น
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"สถานะการทำงาน: {run.status}")

        # ตรวจสอบขั้นตอนการทำงานและการเรียกเครื่องมือ
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"ขั้นตอนการทำงาน: {step.id}, สถานะ: {step.status}, ประเภท: {step.type}")
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
- ตรวจสอบข้อมูลรับรองการยืนยันตัวตน
- ตรวจสอบการเชื่อมต่อเครือข่าย

### 2. การเรียกเครื่องมือไม่สำเร็จ
- ตรวจสอบอาร์กิวเมนต์และรูปแบบของเครื่องมือ
- ตรวจสอบข้อกำหนดเฉพาะของเซิร์ฟเวอร์
- ดำเนินการจัดการข้อผิดพลาดอย่างเหมาะสม

### 3. ปัญหาด้านประสิทธิภาพ
- ปรับปรุงความถี่ในการเรียกเครื่องมือ
- ใช้การแคชเมื่อเหมาะสม
- ติดตามเวลาตอบสนองของเซิร์ฟเวอร์

## ขั้นตอนถัดไป

เพื่อเพิ่มประสิทธิภาพการรวม MCP ของคุณ:

1. **สำรวจเซิร์ฟเวอร์ MCP แบบกำหนดเอง**: สร้างเซิร์ฟเวอร์ MCP ของคุณเองสำหรับแหล่งข้อมูลเฉพาะ
2. **เพิ่มความปลอดภัยขั้นสูง**: เพิ่ม OAuth2 หรือกลไกการยืนยันตัวตนแบบกำหนดเอง
3. **ติดตามและวิเคราะห์**: ดำเนินการบันทึกและติดตามการใช้งานเครื่องมือ
4. **ปรับขนาดโซลูชันของคุณ**: พิจารณาการบาลานซ์โหลดและสถาปัตยกรรมเซิร์ฟเวอร์ MCP แบบกระจาย

## แหล่งข้อมูลเพิ่มเติม

- [เอกสาร Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- [ตัวอย่าง Model Context Protocol](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [ภาพรวม Azure AI Foundry Agents](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [ข้อกำหนด MCP](https://spec.modelcontextprotocol.io/)

## การสนับสนุน

สำหรับการสนับสนุนและคำถามเพิ่มเติม:
- ดูเอกสาร [Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- ตรวจสอบแหล่งข้อมูลชุมชน [MCP](https://modelcontextprotocol.io/)

## สิ่งที่ต้องทำต่อไป

- [6. การมีส่วนร่วมของชุมชน](../../06-CommunityContributions/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลโดยอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดใด ๆ ที่เกิดขึ้นจากการใช้การแปลนี้