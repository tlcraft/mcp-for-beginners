<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:22:22+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "my"
}
-->
# Model Context Protocol (MCP) ကို Azure AI Foundry နှင့် ပေါင်းစည်းခြင်း

ဤလမ်းညွှန်သည် Model Context Protocol (MCP) ဆာဗာများကို Azure AI Foundry အေးဂျင့်များနှင့် ပေါင်းစည်းခြင်းဖြင့် စွမ်းအားမြင့် ကိရိယာများ စီမံခန့်ခွဲမှုနှင့် စီးပွားရေး AI အင်အားများကို ဖန်တီးနည်းကို ပြသထားသည်။

## နိဒါန်း

Model Context Protocol (MCP) သည် AI အက်ပ်လီကေးရှင်းများအား အပြင်အဆင် ဒေတာအရင်းအမြစ်များနှင့် ကိရိယာများကို လုံခြုံစိတ်ချစွာ ချိတ်ဆက်နိုင်စေသော ဖွင့်လှစ်စံသတ်မှတ်ချက်ဖြစ်သည်။ Azure AI Foundry နှင့် ပေါင်းစည်းသောအခါ MCP သည် အေးဂျင့်များအား အပြင်အဆင် ဝန်ဆောင်မှုများ၊ API များနှင့် ဒေတာအရင်းအမြစ်များကို စံပြပုံစံဖြင့် အသုံးပြုခွင့်နှင့် ဆက်သွယ်ခွင့် ပေးသည်။

ဤပေါင်းစည်းမှုသည် MCP ၏ ကိရိယာ ပတ်ဝန်းကျင်၏ ပေါ့ပါးမှုကို Azure AI Foundry ၏ တည်ငြိမ်သော အေးဂျင့် ဖွဲ့စည်းမှုနှင့် ပေါင်းစပ်ပေးကာ စီးပွားရေးအဆင့် AI ဖြေရှင်းချက်များကို အလွန်ပြောင်းလဲနိုင်မှုများနှင့် ပေးဆောင်သည်။

**[!NOTE]** Azure AI Foundry Agent Service တွင် MCP ကို အသုံးပြုလိုပါက လက်ရှိတွင် အောက်ပါဒေသများသာ ထောက်ခံထားပါသည်။ westus, westus2, uaenorth, southindia နှင့် switzerlandnorth

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤလမ်းညွှန် အဆုံးသတ်သည့်အချိန်တွင် သင်သည် -

- Model Context Protocol ၏ အဓိပ္ပာယ်နှင့် အကျိုးကျေးဇူးများကို နားလည်နိုင်မည်
- Azure AI Foundry အေးဂျင့်များနှင့် အသုံးပြုရန် MCP ဆာဗာများကို တပ်ဆင်နိုင်မည်
- MCP ကိရိယာ ပေါင်းစည်းမှုဖြင့် အေးဂျင့်များကို ဖန်တီးပြီး ဖွဲ့စည်းနိုင်မည်
- အမှန်တကယ် MCP ဆာဗာများ အသုံးပြု၍ လက်တွေ့နမူနာများ လုပ်ဆောင်နိုင်မည်
- အေးဂျင့် ဆွေးနွေးမှုများတွင် ကိရိယာတုံ့ပြန်မှုများနှင့် ရည်ညွှန်းချက်များကို ကိုင်တွယ်နိုင်မည်

## လိုအပ်ချက်များ

စတင်ရန်အတွက် -

- AI Foundry အသုံးပြုခွင့်ပါ Azure စာရင်းသွင်းမှုရှိရမည်
- Python 3.10+ ဗားရှင်း
- Azure CLI ကို ထည့်သွင်းပြီး ပြင်ဆင်ထားရမည်
- AI အရင်းအမြစ်များ ဖန်တီးခွင့်ရှိရမည်

## Model Context Protocol (MCP) ဆိုတာဘာလဲ?

Model Context Protocol သည် AI အက်ပ်များအား အပြင်အဆင် ဒေတာအရင်းအမြစ်များနှင့် ကိရိယာများကို ချိတ်ဆက်ရန် စံပြနည်းလမ်းဖြစ်သည်။ အဓိက အကျိုးကျေးဇူးများမှာ -

- **စံပြ ပေါင်းစည်းမှု** - ကိရိယာများနှင့် ဝန်ဆောင်မှုများအကြား တစ်ပုံစံတည်းသော အင်တာဖေ့စ်
- **လုံခြုံရေး** - လုံခြုံသော အတည်ပြုခြင်းနှင့် ခွင့်ပြုချက်စနစ်များ
- **အလွယ်တကူ ပြောင်းလဲနိုင်မှု** - မတူညီသော ဒေတာအရင်းအမြစ်များ၊ API များနှင့် စိတ်ကြိုက် ကိရိယာများအား ထောက်ပံ့မှု
- **တိုးချဲ့နိုင်မှု** - အသစ်သော လုပ်ဆောင်ချက်များနှင့် ပေါင်းစည်းမှုများ ထည့်သွင်းရလွယ်ကူမှု

## Azure AI Foundry နှင့် MCP တပ်ဆင်ခြင်း

### ၁။ ပတ်ဝန်းကျင် ပြင်ဆင်ခြင်း

ပထမဦးဆုံး သင့်ပတ်ဝန်းကျင်၏ environment variables နှင့် အခြားလိုအပ်ချက်များကို ပြင်ဆင်ပါ -

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
        instructions="သင်သည် အကူအညီပေးသူတစ်ဦးဖြစ်သည်။ မေးခွန်းများကို ဖြေဆိုရာတွင် ပေးထားသော ကိရိယာများကို အသုံးပြုပါ။ သင့်ရရှိသော အချက်အလက်များကို အမြဲ ရည်ညွှန်းပါ။",
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
    "server_label": "unique_server_name",      # MCP ဆာဗာအတွက် အမှတ်အသား
    "server_url": "https://api.example.com/mcp", # MCP ဆာဗာ လိပ်စာ
    "require_approval": "never"                 # ခွင့်ပြုချက်မလိုအပ်မှု မူဝါဒ ("never" ကိုသာ ယခုထောက်ခံ)
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
        # MCP ကိရိယာများဖြင့် အေးဂျင့် ဖန်တီးခြင်း
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="သင်သည် Microsoft စာတမ်းများအတွက် အထူးပြု အကူအညီပေးသူတစ်ဦးဖြစ်သည်။ Microsoft Learn MCP ဆာဗာကို အသုံးပြုပြီး တိကျပြီး နောက်ဆုံးရသတင်းအချက်အလက်များ ရှာဖွေပါ။ အမြဲ သင့်ရရှိသော အချက်အလက်များကို ရည်ညွှန်းပါ။",
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
        
        # ဆွေးနွေးမှု အကြောင်းအရာ တစ်ခု ဖန်တီးခြင်း
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # မက်ဆေ့ခ်ျ ပို့ခြင်း
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content=".NET MAUI ဆိုတာဘာလဲ? Xamarin.Forms နှင့် ဘယ်လိုနှိုင်းယှဉ်ရမလဲ?",
        )
        print(f"Created message, message ID: {message.id}")

        # အေးဂျင့်ကို လည်ပတ်စေခြင်း
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # ပြီးဆုံးမှုအထိ စောင့်ကြည့်ခြင်း
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # လည်ပတ်မှု အဆင့်များနှင့် ကိရိယာခေါ်ဆိုမှုများ စစ်ဆေးခြင်း
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Tool call details:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # ဆွေးနွေးမှု ပြသခြင်း
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()


## ပြဿနာများ ဖြေရှင်းနည်းများ

### ၁။ ချိတ်ဆက်မှု ပြဿနာများ
- MCP ဆာဗာ URL ကို လက်လှမ်းမီမှု ရှိ/မရှိ စစ်ဆေးပါ
- အတည်ပြုချက် အချက်အလက်များကို စစ်ဆေးပါ
- ကွန်ယက် ချိတ်ဆက်မှု ရှိ/မရှိ စစ်ဆေးပါ

### ၂။ ကိရိယာ ခေါ်ဆိုမှု မအောင်မြင်မှုများ
- ကိရိယာ အချက်အလက်များနှင့် ပုံစံများကို ပြန်လည်စစ်ဆေးပါ
- ဆာဗာအလိုအလျောက် လိုအပ်ချက်များကို စစ်ဆေးပါ
- မှားယွင်းမှု ကိုင်တွယ်မှုကို မှန်ကန်စွာ ဆောင်ရွက်ပါ

### ၃။ စွမ်းဆောင်ရည် ပြဿနာများ
- ကိရိယာ ခေါ်ဆိုမှု အကြိမ်ရေကို တိုးတက်အောင် ပြင်ဆင်ပါ
- လိုအပ်သည့်နေရာတွင် cache ကို အသုံးပြုပါ
- ဆာဗာ တုံ့ပြန်ချိန်များကို စောင့်ကြည့်ပါ

## နောက်ဆက်တွဲ လုပ်ဆောင်ရန်

သင့် MCP ပေါင်းစည်းမှုကို ပိုမိုတိုးတက်စေရန် -

1. **စိတ်ကြိုက် MCP ဆာဗာများ လေ့လာရန်** - ကိုယ့်ပိုင် ဒေတာအရင်းအမြစ်များအတွက် MCP ဆာဗာများ တည်ဆောက်ပါ
2. **လုံခြုံရေး မြှင့်တင်ရန်** - OAuth2 သို့မဟုတ် စိတ်ကြိုက် အတည်ပြုစနစ်များ ထည့်သွင်းပါ
3. **စောင့်ကြည့်မှုနှင့် သုံးသပ်မှု** - ကိရိယာ အသုံးပြုမှု အတွက် မှတ်တမ်းတင်ခြင်းနှင့် စောင့်ကြည့်မှု လုပ်ဆောင်ပါ
4. **ဖြေရှင်းချက် ကျယ်ပြန့်စေရန်** - Load balancing နှင့် ဖြန့်ဝေထားသော MCP ဆာဗာ ဖွဲ့စည်းမှုများ စဉ်းစားပါ

## အပိုဆောင်း အရင်းအမြစ်များ

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## အထောက်အပံ့

ထပ်မံ အထောက်အပံ့နှင့် မေးခွန်းများအတွက် -
- [Azure AI Foundry documentation](https://learn.microsoft.com/azure/ai-foundry/) ကို ပြန်လည်ကြည့်ရှုပါ
- [MCP community resources](https://modelcontextprotocol.io/) ကို စစ်ဆေးပါ

## နောက်တစ်ဆင့်

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**အချက်ပြချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးပမ်းနေသော်လည်း အလိုအလျောက်ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိခင်ဘာသာဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသောအချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်၏ ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုမှုမှ ဖြစ်ပေါ်သော နားလည်မှုအမှားများ သို့မဟုတ် မမှန်ကန်သော အဓိပ္ပာယ်ဖော်ပြချက်များအတွက် ကျွန်ုပ်တို့မှာ တာဝန်မရှိပါ။