<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:11:59+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "hi"
}
-->
# Model Context Protocol (MCP) का Azure AI Foundry के साथ एकीकरण

यह गाइड बताता है कि Model Context Protocol (MCP) सर्वर्स को Azure AI Foundry एजेंट्स के साथ कैसे एकीकृत किया जाए, जिससे शक्तिशाली टूल ऑर्केस्ट्रेशन और एंटरप्राइज AI क्षमताएं संभव होती हैं।

## परिचय

Model Context Protocol (MCP) एक ओपन स्टैंडर्ड है जो AI एप्लिकेशन्स को बाहरी डेटा स्रोतों और टूल्स से सुरक्षित रूप से कनेक्ट करने में सक्षम बनाता है। Azure AI Foundry के साथ एकीकरण के दौरान, MCP एजेंट्स को विभिन्न बाहरी सेवाओं, APIs, और डेटा स्रोतों तक मानकीकृत तरीके से पहुँचने और इंटरैक्ट करने की अनुमति देता है।

यह एकीकरण MCP के टूल इकोसिस्टम की लचीलापन को Azure AI Foundry के मजबूत एजेंट फ्रेमवर्क के साथ जोड़ता है, जिससे व्यापक कस्टमाइज़ेशन क्षमताओं के साथ एंटरप्राइज-ग्रेड AI समाधान मिलते हैं।

**Note:** यदि आप Azure AI Foundry Agent Service में MCP का उपयोग करना चाहते हैं, तो वर्तमान में केवल निम्नलिखित क्षेत्र समर्थित हैं: westus, westus2, uaenorth, southindia और switzerlandnorth

## सीखने के उद्देश्य

इस गाइड के अंत तक, आप सक्षम होंगे:

- Model Context Protocol और इसके लाभों को समझना
- Azure AI Foundry एजेंट्स के लिए MCP सर्वर्स सेटअप करना
- MCP टूल इंटीग्रेशन के साथ एजेंट बनाना और कॉन्फ़िगर करना
- वास्तविक MCP सर्वर्स का उपयोग करते हुए व्यावहारिक उदाहरण लागू करना
- एजेंट वार्तालापों में टूल प्रतिक्रियाओं और संदर्भों को संभालना

## पूर्व आवश्यकताएँ

शुरू करने से पहले, सुनिश्चित करें कि आपके पास है:

- AI Foundry एक्सेस के साथ Azure सब्सक्रिप्शन
- Python 3.10 या उससे ऊपर
- Azure CLI इंस्टॉल और कॉन्फ़िगर किया हुआ
- AI संसाधन बनाने के लिए उचित अनुमतियाँ

## Model Context Protocol (MCP) क्या है?

Model Context Protocol AI एप्लिकेशन्स के लिए बाहरी डेटा स्रोतों और टूल्स से जुड़ने का एक मानकीकृत तरीका है। इसके मुख्य लाभ हैं:

- **मानकीकृत एकीकरण**: विभिन्न टूल्स और सेवाओं के लिए सुसंगत इंटरफेस
- **सुरक्षा**: सुरक्षित प्रमाणीकरण और अधिकृतकरण तंत्र
- **लचीलापन**: विभिन्न डेटा स्रोतों, APIs, और कस्टम टूल्स का समर्थन
- **विस्तार क्षमता**: नई क्षमताओं और एकीकरणों को आसानी से जोड़ना

## Azure AI Foundry के साथ MCP सेटअप करना

### 1. पर्यावरण कॉन्फ़िगरेशन

सबसे पहले, अपने पर्यावरण चर और निर्भरताओं को सेट करें:

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
        instructions="You are a helpful assistant. Use the tools provided to answer questions. Be sure to cite your sources.",
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
    "server_label": "unique_server_name",      # MCP सर्वर के लिए पहचानकर्ता
    "server_url": "https://api.example.com/mcp", # MCP सर्वर का एंडपॉइंट
    "require_approval": "never"                 # अनुमोदन नीति: वर्तमान में केवल "never" समर्थित है
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
        # MCP टूल्स के साथ एजेंट बनाएं
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="You are a helpful assistant specializing in Microsoft documentation. Use the Microsoft Learn MCP server to search for accurate, up-to-date information. Always cite your sources.",
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
        
        # वार्तालाप थ्रेड बनाएं
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # संदेश भेजें
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="What is .NET MAUI? How does it compare to Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # एजेंट चलाएं
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # पूर्णता के लिए पोल करें
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # रन स्टेप्स और टूल कॉल्स की जांच करें
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Tool call details:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # वार्तालाप प्रदर्शित करें
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## सामान्य समस्याओं का निवारण

### 1. कनेक्शन समस्याएं
- सुनिश्चित करें कि MCP सर्वर URL पहुँच योग्य है
- प्रमाणीकरण क्रेडेंशियल्स जांचें
- नेटवर्क कनेक्टिविटी सुनिश्चित करें

### 2. टूल कॉल विफलताएं
- टूल आर्गुमेंट्स और फॉर्मेटिंग की समीक्षा करें
- सर्वर-विशिष्ट आवश्यकताओं की जाँच करें
- उचित त्रुटि हैंडलिंग लागू करें

### 3. प्रदर्शन संबंधी समस्याएं
- टूल कॉल की आवृत्ति को अनुकूलित करें
- जहाँ आवश्यक हो कैशिंग लागू करें
- सर्वर प्रतिक्रिया समय की निगरानी करें

## अगले कदम

अपने MCP एकीकरण को और बेहतर बनाने के लिए:

1. **कस्टम MCP सर्वर एक्सप्लोर करें**: अपने स्वामित्व वाले डेटा स्रोतों के लिए MCP सर्वर बनाएं
2. **उन्नत सुरक्षा लागू करें**: OAuth2 या कस्टम प्रमाणीकरण तंत्र जोड़ें
3. **निगरानी और विश्लेषण**: टूल उपयोग के लिए लॉगिंग और मॉनिटरिंग लागू करें
4. **अपने समाधान को स्केल करें**: लोड बैलेंसिंग और वितरित MCP सर्वर आर्किटेक्चर पर विचार करें

## अतिरिक्त संसाधन

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## समर्थन

अतिरिक्त सहायता और प्रश्नों के लिए:
- [Azure AI Foundry documentation](https://learn.microsoft.com/azure/ai-foundry/) देखें
- [MCP community resources](https://modelcontextprotocol.io/) जांचें

## आगे क्या है

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।