<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-14T00:01:56+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "my"
}
-->
# Model Context Protocol (MCP) ကို Azure AI Foundry နှင့် ပေါင်းစပ်ခြင်း

ဤလမ်းညွှန်သည် Model Context Protocol (MCP) ဆာဗာများကို Azure AI Foundry အေးဂျင့်များနှင့် ပေါင်းစပ်၍ အင်အားကြီးသော ကိရိယာများ စီမံခန့်ခွဲမှုနှင့် စီးပွားရေးအဆင့် AI စွမ်းဆောင်ရည်များကို အသုံးပြုနိုင်ရန် ပြသထားသည်။

## နိဒါန်း

Model Context Protocol (MCP) သည် AI အက်ပလီကေးရှင်းများကို ပြင်ပဒေတာရင်းမြစ်များနှင့် ကိရိယာများနှင့် လုံခြုံစိတ်ချစွာ ချိတ်ဆက်နိုင်စေရန် ဖွင့်လှစ်ထားသော စံသတ်မှတ်ချက်တစ်ခုဖြစ်သည်။ Azure AI Foundry နှင့် ပေါင်းစပ်သည့်အခါ MCP သည် အေးဂျင့်များအား အမျိုးမျိုးသော ပြင်ပဝန်ဆောင်မှုများ၊ API များနှင့် ဒေတာရင်းမြစ်များကို စံပြုထားသည့် နည်းလမ်းဖြင့် ဝင်ရောက်အသုံးပြုနိုင်စေသည်။

ဤပေါင်းစပ်မှုသည် MCP ၏ ကိရိယာပတ်ဝန်းကျင်၏ လွတ်လပ်မှုနှင့် Azure AI Foundry ၏ ခိုင်မာသော အေးဂျင့် ဖွဲ့စည်းမှုကို ပေါင်းစပ်ကာ စီးပွားရေးအဆင့် AI ဖြေရှင်းချက်များကို ကျယ်ပြန့်စွာ စိတ်ကြိုက်ပြင်ဆင်နိုင်စေသည်။

**[!NOTE]** Azure AI Foundry Agent Service တွင် MCP ကို အသုံးပြုလိုပါက လက်ရှိတွင် အောက်ပါဒေသများသာ ထောက်ပံ့ထားပါသည်။ westus, westus2, uaenorth, southindia နှင့် switzerlandnorth

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤလမ်းညွှန်ပြီးဆုံးသည်နှင့်အတူ သင်သည် -

- Model Context Protocol ၏ အဓိပ္ပါယ်နှင့် အကျိုးကျေးဇူးများကို နားလည်နိုင်မည်
- Azure AI Foundry အေးဂျင့်များနှင့် အသုံးပြုရန် MCP ဆာဗာများကို တပ်ဆင်နိုင်မည်
- MCP ကိရိယာ ပေါင်းစပ်ထားသော အေးဂျင့်များကို ဖန်တီးပြီး ပြင်ဆင်နိုင်မည်
- အမှန်တကယ် MCP ဆာဗာများကို အသုံးပြု၍ လက်တွေ့ ဥပမာများကို အကောင်အထည်ဖော်နိုင်မည်
- အေးဂျင့် စကားပြောများတွင် ကိရိယာတုံ့ပြန်ချက်များနှင့် ကိုးကားချက်များကို ကိုင်တွယ်နိုင်မည်

## မတိုင်မီ လိုအပ်ချက်များ

စတင်မတိုင်မီ အောက်ပါအချက်များရှိကြောင်း သေချာစေပါ-

- AI Foundry ဝင်ရောက်ခွင့်ပါသော Azure subscription တစ်ခု
- Python 3.10+ 
- Azure CLI တပ်ဆင်ပြီး ပြင်ဆင်ထားခြင်း
- AI အရင်းအမြစ်များ ဖန်တီးခွင့်ရှိခြင်း

## Model Context Protocol (MCP) ဆိုတာဘာလဲ?

Model Context Protocol သည် AI အက်ပလီကေးရှင်းများအတွက် ပြင်ပဒေတာရင်းမြစ်များနှင့် ကိရိယာများကို ချိတ်ဆက်ရန် စံပြုထားသည့် နည်းလမ်းတစ်ခုဖြစ်သည်။ အဓိက အကျိုးကျေးဇူးများမှာ -

- **စံပြုထားသော ပေါင်းစပ်မှု**: ကိရိယာနှင့် ဝန်ဆောင်မှုအမျိုးမျိုးအတွက် တူညီသော အင်တာဖေ့စ်
- **လုံခြုံမှု**: လုံခြုံသော အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်းစနစ်များ
- **လွတ်လပ်မှု**: အမျိုးမျိုးသော ဒေတာရင်းမြစ်များ၊ API များနှင့် စိတ်ကြိုက်ကိရိယာများကို ထောက်ပံ့မှု
- **တိုးချဲ့နိုင်မှု**: စွမ်းဆောင်ရည်အသစ်များနှင့် ပေါင်းစပ်မှုများကို လွယ်ကူစွာ ထည့်သွင်းနိုင်ခြင်း

## Azure AI Foundry နှင့် MCP တပ်ဆင်ခြင်း

### ၁။ ပတ်ဝန်းကျင် ပြင်ဆင်ခြင်း

ပထမဦးဆုံး သင့်ပတ်ဝန်းကျင် အပြောင်းအလဲများနှင့် လိုအပ်သော အခြေခံပစ္စည်းများကို ပြင်ဆင်ပါ-

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
        instructions="သင်သည် အကူအညီပေးသူတစ်ဦးဖြစ်သည်။ မေးခွန်းများကို ဖြေဆိုရာတွင် ပေးထားသော ကိရိယာများကို အသုံးပြုပါ။ သင့်ရင်းမြစ်များကို အမြဲကိုးကားပါ။",
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
    "require_approval": "never"                 # ခွင့်ပြုချက်မလိုအပ်မှု မူဝါဒ - ယခုအချိန်တွင် "never" ကိုသာ ထောက်ပံ့သည်
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
        # MCP ကိရိယာများပါသော အေးဂျင့် ဖန်တီးခြင်း
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="သင်သည် Microsoft စာတမ်းများအတွက် အထူးပြု အကူအညီပေးသူတစ်ဦးဖြစ်သည်။ Microsoft Learn MCP ဆာဗာကို အသုံးပြု၍ တိကျပြီး နောက်ဆုံးရသတင်းအချက်အလက်များကို ရှာဖွေပါ။ အမြဲတမ်း သင့်ရင်းမြစ်များကို ကိုးကားပါ။",
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
        
        # စကားပြော အကြောင်းအရာ ဖန်တီးခြင်း
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # စာတိုက်ပို့ခြင်း
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content=".NET MAUI ဆိုတာဘာလဲ? Xamarin.Forms နှင့် ဘယ်လိုနှိုင်းယှဉ်နိုင်သလဲ?",
        )
        print(f"Created message, message ID: {message.id}")

        # အေးဂျင့်ကို လည်ပတ်စေခြင်း
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # ပြီးဆုံးမှုအတွက် စောင့်ကြည့်ခြင်း
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

        # စကားပြောများ ပြသခြင်း
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()


## ပြဿနာများ ဖြေရှင်းခြင်း

### ၁။ ချိတ်ဆက်မှု ပြဿနာများ
- MCP ဆာဗာ URL သည် ဝင်ရောက်နိုင်မှုရှိကြောင်း စစ်ဆေးပါ
- အတည်ပြုချက် အချက်အလက်များကို စစ်ဆေးပါ
- ကွန်ယက် ချိတ်ဆက်မှု ရှိကြောင်း သေချာစေပါ

### ၂။ ကိရိယာခေါ်ဆိုမှု မအောင်မြင်ခြင်း
- ကိရိယာ အချက်အလက်များနှင့် ဖော်မတ်ကို ပြန်လည်စစ်ဆေးပါ
- ဆာဗာအလိုအလျောက် လိုအပ်ချက်များကို စစ်ဆေးပါ
- မှားယွင်းမှုကို မှန်ကန်စွာ ကိုင်တွယ်ပါ

### ၃။ စွမ်းဆောင်ရည် ပြဿနာများ
- ကိရိယာခေါ်ဆိုမှု အကြိမ်ရေကို တိုးတက်အောင် ပြင်ဆင်ပါ
- လိုအပ်သည့်နေရာတွင် Cache ကို အသုံးပြုပါ
- ဆာဗာ တုံ့ပြန်ချိန်များကို စောင့်ကြည့်ပါ

## နောက်တစ်ဆင့်များ

သင့် MCP ပေါင်းစပ်မှုကို ပိုမိုတိုးတက်စေရန် -

1. **စိတ်ကြိုက် MCP ဆာဗာများ ရှာဖွေပါ**: ကိုယ်ပိုင် ဒေတာရင်းမြစ်များအတွက် MCP ဆာဗာများ တည်ဆောက်ပါ
2. **တိုးတက်သော လုံခြုံရေး စနစ်များ ထည့်သွင်းပါ**: OAuth2 သို့မဟုတ် စိတ်ကြိုက် အတည်ပြုစနစ်များ ထည့်သွင်းပါ
3. **စောင့်ကြည့်မှုနှင့် သုံးသပ်မှုများ**: ကိရိယာ အသုံးပြုမှုများအတွက် မှတ်တမ်းတင်ခြင်းနှင့် စောင့်ကြည့်မှုများ ထည့်သွင်းပါ
4. **ဖြေရှင်းချက်ကို တိုးချဲ့ပါ**: Load balancing နှင့် ဖြန့်ဝေထားသော MCP ဆာဗာ ဖွဲ့စည်းမှုများကို စဉ်းစားပါ

## အပိုဆောင်း အရင်းအမြစ်များ

- [Azure AI Foundry စာတမ်းများ](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol နမူနာများ](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents အကြောင်း](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP သတ်မှတ်ချက်](https://spec.modelcontextprotocol.io/)

## အထောက်အပံ့

ထပ်မံအထောက်အပံ့နှင့် မေးခွန်းများအတွက် -
- [Azure AI Foundry စာတမ်းများ](https://learn.microsoft.com/azure/ai-foundry/) ကို ပြန်လည်ကြည့်ရှုပါ
- [MCP အသိုင်းအဝိုင်း အရင်းအမြစ်များ](https://modelcontextprotocol.io/) ကို စစ်ဆေးပါ

## နောက်တစ်ဆင့်

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။