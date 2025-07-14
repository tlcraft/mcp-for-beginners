<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:53:47+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "mr"
}
-->
# Model Context Protocol (MCP) चे Azure AI Foundry सोबत एकत्रीकरण

हा मार्गदर्शक Model Context Protocol (MCP) सर्व्हर्सना Azure AI Foundry एजंट्ससोबत कसे एकत्र करायचे हे दाखवतो, ज्यामुळे शक्तिशाली टूल ऑर्केस्ट्रेशन आणि एंटरप्राइझ AI क्षमता मिळतात.

## परिचय

Model Context Protocol (MCP) हा एक खुला मानक आहे जो AI अनुप्रयोगांना सुरक्षितपणे बाह्य डेटा स्रोत आणि टूल्सशी जोडण्याची परवानगी देतो. Azure AI Foundry सोबत एकत्र केल्यावर, MCP एजंट्सना विविध बाह्य सेवा, API आणि डेटा स्रोतांशी प्रमाणित पद्धतीने प्रवेश आणि संवाद साधता येतो.

हे एकत्रीकरण MCP च्या टूल इकोसिस्टमची लवचिकता आणि Azure AI Foundry च्या मजबूत एजंट फ्रेमवर्कला एकत्र करून एंटरप्राइझ-ग्रेड AI सोल्यूशन्ससाठी विस्तृत सानुकूलन क्षमता प्रदान करते.

**Note:** जर तुम्हाला Azure AI Foundry Agent Service मध्ये MCP वापरायचा असेल, तर सध्या फक्त खालील प्रदेश समर्थित आहेत: westus, westus2, uaenorth, southindia आणि switzerlandnorth

## शिकण्याचे उद्दिष्टे

या मार्गदर्शकाच्या शेवटी, तुम्ही सक्षम असाल:

- Model Context Protocol आणि त्याचे फायदे समजून घेणे
- Azure AI Foundry एजंट्ससाठी MCP सर्व्हर्स सेटअप करणे
- MCP टूल एकत्रीकरणासह एजंट तयार करणे आणि कॉन्फिगर करणे
- प्रत्यक्ष MCP सर्व्हर्स वापरून व्यावहारिक उदाहरणे अंमलात आणणे
- एजंट संवादांमध्ये टूल प्रतिसाद आणि संदर्भ हाताळणे

## पूर्वअट

सुरू करण्यापूर्वी, खात्री करा की तुमच्याकडे आहे:

- AI Foundry प्रवेशासह Azure सदस्यता
- Python 3.10 किंवा त्याहून अधिक
- Azure CLI स्थापित आणि कॉन्फिगर केलेले
- AI संसाधने तयार करण्यासाठी योग्य परवानग्या

## Model Context Protocol (MCP) म्हणजे काय?

Model Context Protocol हा AI अनुप्रयोगांना बाह्य डेटा स्रोत आणि टूल्सशी जोडण्यासाठी एक प्रमाणित मार्ग आहे. मुख्य फायदे:

- **प्रमाणित एकत्रीकरण**: विविध टूल्स आणि सेवांमध्ये सुसंगत इंटरफेस
- **सुरक्षा**: सुरक्षित प्रमाणीकरण आणि अधिकृतता यंत्रणा
- **लवचिकता**: विविध डेटा स्रोत, API आणि सानुकूल टूल्ससाठी समर्थन
- **विस्तारयोग्यता**: नवीन क्षमता आणि एकत्रीकरण सहज जोडता येतात

## Azure AI Foundry सोबत MCP सेटअप करणे

### 1. पर्यावरण कॉन्फिगरेशन

सर्वप्रथम, तुमचे पर्यावरणीय चल आणि अवलंबित्व सेट करा:

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
        instructions="तुम्ही एक उपयुक्त सहाय्यक आहात. प्रश्नांची उत्तरे देण्यासाठी दिलेले टूल्स वापरा. तुमच्या स्रोतांचा संदर्भ देणे विसरू नका.",
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
    "server_label": "unique_server_name",      # MCP सर्व्हरसाठी ओळख
    "server_url": "https://api.example.com/mcp", # MCP सर्व्हर एंडपॉइंट
    "require_approval": "never"                 # मंजुरी धोरण: सध्या फक्त "never" समर्थित
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
        # MCP टूल्ससह एजंट तयार करा
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="तुम्ही Microsoft दस्तऐवजीकरणात तज्ञ असलेला उपयुक्त सहाय्यक आहात. अचूक आणि अद्ययावत माहिती शोधण्यासाठी Microsoft Learn MCP सर्व्हर वापरा. नेहमी तुमच्या स्रोतांचा संदर्भ द्या.",
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
        
        # संभाषण थ्रेड तयार करा
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # संदेश पाठवा
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content=".NET MAUI म्हणजे काय? ते Xamarin.Forms शी कसे तुलना करते?",
        )
        print(f"Created message, message ID: {message.id}")

        # एजंट चालवा
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # पूर्णतेसाठी पोल करा
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # रन स्टेप्स आणि टूल कॉल तपासा
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Tool call details:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # संभाषण प्रदर्शित करा
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()


## सामान्य समस्या निवारण

### 1. कनेक्शन समस्या
- MCP सर्व्हर URL प्रवेशयोग्य आहे का तपासा
- प्रमाणीकरण क्रेडेन्शियल्स तपासा
- नेटवर्क कनेक्टिव्हिटी सुनिश्चित करा

### 2. टूल कॉल अयशस्वी होणे
- टूल आर्ग्युमेंट्स आणि फॉरमॅटिंग तपासा
- सर्व्हर-विशिष्ट आवश्यकता तपासा
- योग्य त्रुटी हाताळणी अंमलात आणा

### 3. कार्यक्षमता समस्या
- टूल कॉलची वारंवारिता ऑप्टिमाइझ करा
- जिथे योग्य असेल तिथे कॅशिंग वापरा
- सर्व्हर प्रतिसाद वेळा मॉनिटर करा

## पुढील पावले

तुमच्या MCP एकत्रीकरणाला अधिक सुधारण्यासाठी:

1. **सानुकूल MCP सर्व्हर्स एक्सप्लोर करा**: तुमच्या खासगी डेटा स्रोतांसाठी स्वतःचे MCP सर्व्हर्स तयार करा
2. **प्रगत सुरक्षा अंमलात आणा**: OAuth2 किंवा सानुकूल प्रमाणीकरण यंत्रणा जोडा
3. **मॉनिटरिंग आणि विश्लेषण**: टूल वापरासाठी लॉगिंग आणि मॉनिटरिंग अंमलात आणा
4. **तुमचे सोल्यूशन स्केल करा**: लोड बॅलन्सिंग आणि वितरित MCP सर्व्हर आर्किटेक्चरचा विचार करा

## अतिरिक्त संसाधने

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## समर्थन

अधिक मदतीसाठी आणि प्रश्नांसाठी:
- [Azure AI Foundry documentation](https://learn.microsoft.com/azure/ai-foundry/) पहा
- [MCP community resources](https://modelcontextprotocol.io/) तपासा

## पुढे काय

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.