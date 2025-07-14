<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:51:23+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "ur"
}
-->
# ماڈل کانٹیکسٹ پروٹوکول (MCP) کا Azure AI Foundry کے ساتھ انضمام

یہ رہنما بتاتا ہے کہ ماڈل کانٹیکسٹ پروٹوکول (MCP) سرورز کو Azure AI Foundry ایجنٹس کے ساتھ کیسے مربوط کیا جائے، تاکہ طاقتور ٹول آرکسٹریشن اور انٹرپرائز AI صلاحیتیں حاصل کی جا سکیں۔

## تعارف

ماڈل کانٹیکسٹ پروٹوکول (MCP) ایک اوپن اسٹینڈرڈ ہے جو AI ایپلیکیشنز کو بیرونی ڈیٹا ذرائع اور ٹولز سے محفوظ طریقے سے جڑنے کی اجازت دیتا ہے۔ Azure AI Foundry کے ساتھ انضمام کے ذریعے، MCP ایجنٹس کو مختلف بیرونی سروسز، APIs، اور ڈیٹا ذرائع تک معیاری انداز میں رسائی اور تعامل کی سہولت دیتا ہے۔

یہ انضمام MCP کے ٹول ایکو سسٹم کی لچک کو Azure AI Foundry کے مضبوط ایجنٹ فریم ورک کے ساتھ جوڑتا ہے، جو انٹرپرائز گریڈ AI حل فراہم کرتا ہے جن میں وسیع تخصیص کی صلاحیتیں شامل ہیں۔

**Note:** اگر آپ Azure AI Foundry Agent Service میں MCP استعمال کرنا چاہتے ہیں، تو فی الحال صرف درج ذیل ریجنز کی حمایت کی جاتی ہے: westus, westus2, uaenorth, southindia اور switzerlandnorth

## سیکھنے کے مقاصد

اس رہنما کے اختتام تک، آپ قابل ہوں گے کہ:

- ماڈل کانٹیکسٹ پروٹوکول اور اس کے فوائد کو سمجھیں
- Azure AI Foundry ایجنٹس کے ساتھ استعمال کے لیے MCP سرورز سیٹ اپ کریں
- MCP ٹول انضمام کے ساتھ ایجنٹس بنائیں اور ترتیب دیں
- حقیقی MCP سرورز استعمال کرتے ہوئے عملی مثالیں نافذ کریں
- ایجنٹ کی گفتگو میں ٹول کے جوابات اور حوالہ جات کو سنبھالیں

## ضروریات

شروع کرنے سے پہلے، یقینی بنائیں کہ آپ کے پاس ہے:

- Azure سبسکرپشن جس میں AI Foundry کی رسائی ہو
- Python 3.10 یا اس سے جدید ورژن
- Azure CLI انسٹال اور ترتیب دیا ہوا ہو
- AI وسائل بنانے کی مناسب اجازتیں

## ماڈل کانٹیکسٹ پروٹوکول (MCP) کیا ہے؟

ماڈل کانٹیکسٹ پروٹوکول AI ایپلیکیشنز کے لیے ایک معیاری طریقہ ہے جو بیرونی ڈیٹا ذرائع اور ٹولز سے جڑنے کی سہولت دیتا ہے۔ اہم فوائد میں شامل ہیں:

- **معیاری انضمام**: مختلف ٹولز اور سروسز کے لیے یکساں انٹرفیس
- **سیکیورٹی**: محفوظ تصدیق اور اجازت کے طریقہ کار
- **لچک**: مختلف ڈیٹا ذرائع، APIs، اور کسٹم ٹولز کی حمایت
- **توسیع پذیری**: نئی صلاحیتیں اور انضمامات آسانی سے شامل کرنا

## Azure AI Foundry کے ساتھ MCP سیٹ اپ کرنا

### 1. ماحول کی ترتیب

سب سے پہلے، اپنے ماحول کے متغیرات اور انحصارات سیٹ کریں:

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
        instructions="آپ ایک مددگار معاون ہیں۔ سوالات کے جواب دینے کے لیے فراہم کردہ ٹولز استعمال کریں۔ اپنے ذرائع کا حوالہ دینا یقینی بنائیں۔",
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
    print(f"Created agent, agent ID: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # MCP سرور کے لیے شناخت کنندہ
    "server_url": "https://api.example.com/mcp", # MCP سرور کا اینڈ پوائنٹ
    "require_approval": "never"                 # منظوری کی پالیسی: فی الحال صرف "never" کی حمایت ہے
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
        # MCP ٹولز کے ساتھ ایجنٹ بنائیں
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="آپ ایک مددگار معاون ہیں جو Microsoft دستاویزات میں مہارت رکھتے ہیں۔ Microsoft Learn MCP سرور استعمال کریں تاکہ درست اور تازہ ترین معلومات تلاش کی جا سکیں۔ ہمیشہ اپنے ذرائع کا حوالہ دیں۔",
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
        print(f"Created agent, agent ID: {agent.id}")    
        
        # گفتگو کا تھریڈ بنائیں
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # پیغام بھیجیں
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content=".NET MAUI کیا ہے؟ یہ Xamarin.Forms سے کیسے مختلف ہے؟",
        )
        print(f"Created message, message ID: {message.id}")

        # ایجنٹ چلائیں
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # مکمل ہونے کا انتظار کریں
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # رن کے مراحل اور ٹول کالز کا جائزہ لیں
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Tool call details:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # گفتگو دکھائیں
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()


## عام مسائل کا حل

### 1. کنکشن کے مسائل
- MCP سرور URL کی دستیابی کی تصدیق کریں
- تصدیقی اسناد چیک کریں
- نیٹ ورک کنیکٹیویٹی یقینی بنائیں

### 2. ٹول کال کی ناکامیاں
- ٹول کے دلائل اور فارمیٹنگ کا جائزہ لیں
- سرور کی مخصوص ضروریات چیک کریں
- مناسب ایرر ہینڈلنگ نافذ کریں

### 3. کارکردگی کے مسائل
- ٹول کال کی فریکوئنسی کو بہتر بنائیں
- جہاں مناسب ہو کیشنگ نافذ کریں
- سرور کے ردعمل کے اوقات کی نگرانی کریں

## اگلے اقدامات

اپنے MCP انضمام کو مزید بہتر بنانے کے لیے:

1. **کسٹم MCP سرورز دریافت کریں**: اپنے مخصوص ڈیٹا ذرائع کے لیے MCP سرورز بنائیں
2. **جدید سیکیورٹی نافذ کریں**: OAuth2 یا کسٹم تصدیقی طریقے شامل کریں
3. **مانیٹرنگ اور تجزیات**: ٹول کے استعمال کے لیے لاگنگ اور مانیٹرنگ نافذ کریں
4. **اپنے حل کو اسکیل کریں**: لوڈ بیلنسنگ اور تقسیم شدہ MCP سرور آرکیٹیکچرز پر غور کریں

## اضافی وسائل

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## سپورٹ

مزید مدد اور سوالات کے لیے:
- [Azure AI Foundry documentation](https://learn.microsoft.com/azure/ai-foundry/) کا جائزہ لیں
- [MCP community resources](https://modelcontextprotocol.io/) چیک کریں

## اگلا کیا ہے

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**دستخطی دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔