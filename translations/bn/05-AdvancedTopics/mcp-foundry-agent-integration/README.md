<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:12:18+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "bn"
}
-->
# Model Context Protocol (MCP) ইন্টিগ্রেশন Azure AI Foundry-এর সাথে

এই গাইডটি দেখায় কিভাবে Model Context Protocol (MCP) সার্ভারগুলোকে Azure AI Foundry এজেন্টের সাথে সংযুক্ত করা যায়, যা শক্তিশালী টুল অর্কেস্ট্রেশন এবং এন্টারপ্রাইজ AI ক্ষমতা প্রদান করে।

## পরিচিতি

Model Context Protocol (MCP) একটি ওপেন স্ট্যান্ডার্ড যা AI অ্যাপ্লিকেশনগুলোকে নিরাপদে বাইরের ডেটা সোর্স এবং টুলের সাথে সংযুক্ত হতে সাহায্য করে। Azure AI Foundry-এর সাথে ইন্টিগ্রেট করার মাধ্যমে, MCP এজেন্টদের বিভিন্ন বাইরের সার্ভিস, API, এবং ডেটা সোর্সে স্ট্যান্ডার্ড পদ্ধতিতে অ্যাক্সেস এবং ইন্টারঅ্যাক্ট করার সুযোগ দেয়।

এই ইন্টিগ্রেশন MCP-এর টুল ইকোসিস্টেমের নমনীয়তা এবং Azure AI Foundry-এর শক্তিশালী এজেন্ট ফ্রেমওয়ার্ককে একত্রিত করে, যা ব্যাপক কাস্টমাইজেশন ক্ষমতা সহ এন্টারপ্রাইজ-গ্রেড AI সমাধান প্রদান করে।

**Note:** আপনি যদি Azure AI Foundry Agent Service-এ MCP ব্যবহার করতে চান, বর্তমানে শুধুমাত্র নিম্নলিখিত অঞ্চলগুলো সমর্থিত: westus, westus2, uaenorth, southindia এবং switzerlandnorth

## শেখার লক্ষ্যসমূহ

এই গাইড শেষ করার পর, আপনি সক্ষম হবেন:

- Model Context Protocol এবং এর সুবিধাগুলো বুঝতে
- Azure AI Foundry এজেন্টের জন্য MCP সার্ভার সেটআপ করতে
- MCP টুল ইন্টিগ্রেশন সহ এজেন্ট তৈরি ও কনফিগার করতে
- বাস্তব MCP সার্ভার ব্যবহার করে প্রায়োগিক উদাহরণ বাস্তবায়ন করতে
- এজেন্ট কথোপকথনে টুল রেসপন্স এবং উত্স উল্লেখ পরিচালনা করতে

## পূর্বশর্ত

শুরু করার আগে নিশ্চিত করুন আপনার কাছে:

- AI Foundry অ্যাক্সেস সহ একটি Azure সাবস্ক্রিপশন
- Python 3.10 বা তার উপরে
- Azure CLI ইনস্টল ও কনফিগার করা
- AI রিসোর্স তৈরি করার যথাযথ অনুমতি

## Model Context Protocol (MCP) কী?

Model Context Protocol হলো AI অ্যাপ্লিকেশনগুলোকে বাইরের ডেটা সোর্স এবং টুলের সাথে সংযুক্ত করার একটি স্ট্যান্ডার্ড পদ্ধতি। এর মূল সুবিধাসমূহ:

- **স্ট্যান্ডার্ডাইজড ইন্টিগ্রেশন**: বিভিন্ন টুল ও সার্ভিসে একরকম ইন্টারফেস
- **নিরাপত্তা**: নিরাপদ অথেনটিকেশন ও অথরাইজেশন প্রক্রিয়া
- **নমনীয়তা**: বিভিন্ন ডেটা সোর্স, API, এবং কাস্টম টুল সাপোর্ট
- **বিস্তারণযোগ্যতা**: নতুন ক্ষমতা ও ইন্টিগ্রেশন সহজে যুক্ত করা যায়

## Azure AI Foundry-এর সাথে MCP সেটআপ করা

### ১. পরিবেশ কনফিগারেশন

প্রথমে আপনার পরিবেশের ভেরিয়েবল এবং ডিপেন্ডেন্সিগুলো সেটআপ করুন:

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
    "server_label": "unique_server_name",      # MCP সার্ভারের আইডেন্টিফায়ার
    "server_url": "https://api.example.com/mcp", # MCP সার্ভারের এন্ডপয়েন্ট
    "require_approval": "never"                 # অনুমোদনের নীতি: এই সময় শুধুমাত্র "never" সমর্থিত
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
        # MCP টুল সহ এজেন্ট তৈরি করুন
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
        
        # কথোপকথন থ্রেড তৈরি করুন
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # মেসেজ পাঠান
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="What is .NET MAUI? How does it compare to Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # এজেন্ট চালান
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # সম্পন্ন হওয়া পর্যন্ত অপেক্ষা করুন
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # রান স্টেপ এবং টুল কল পরীক্ষা করুন
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Tool call details:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # কথোপকথন প্রদর্শন করুন
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
```

## সাধারণ সমস্যাগুলোর সমাধান

### ১. সংযোগ সমস্যা
- MCP সার্ভারের URL অ্যাক্সেসযোগ্য কিনা যাচাই করুন
- অথেনটিকেশন ক্রেডেনশিয়াল চেক করুন
- নেটওয়ার্ক সংযোগ নিশ্চিত করুন

### ২. টুল কল ব্যর্থতা
- টুল আর্গুমেন্ট এবং ফরম্যাটিং পর্যালোচনা করুন
- সার্ভার-নির্দিষ্ট চাহিদাগুলো যাচাই করুন
- সঠিক এরর হ্যান্ডলিং বাস্তবায়ন করুন

### ৩. কর্মক্ষমতা সমস্যা
- টুল কলের ফ্রিকোয়েন্সি অপ্টিমাইজ করুন
- যেখানে প্রযোজ্য, ক্যাশিং ব্যবহার করুন
- সার্ভার রেসপন্স টাইম মনিটর করুন

## পরবর্তী ধাপ

আপনার MCP ইন্টিগ্রেশন আরও উন্নত করতে:

1. **কাস্টম MCP সার্ভার তৈরি করুন**: নিজস্ব MCP সার্ভার তৈরি করুন আপনার প্রোপাইটারি ডেটা সোর্সের জন্য
2. **উন্নত নিরাপত্তা বাস্তবায়ন করুন**: OAuth2 বা কাস্টম অথেনটিকেশন প্রক্রিয়া যোগ করুন
3. **মনিটরিং এবং অ্যানালিটিক্স**: টুল ব্যবহারের লগিং এবং মনিটরিং যুক্ত করুন
4. **আপনার সমাধান স্কেল করুন**: লোড ব্যালান্সিং এবং বিতরণকৃত MCP সার্ভার আর্কিটেকচার বিবেচনা করুন

## অতিরিক্ত সম্পদ

- [Azure AI Foundry ডকুমেন্টেশন](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol নমুনা](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents ওভারভিউ](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP স্পেসিফিকেশন](https://spec.modelcontextprotocol.io/)

## সহায়তা

অতিরিক্ত সহায়তা এবং প্রশ্নের জন্য:
- [Azure AI Foundry ডকুমেন্টেশন](https://learn.microsoft.com/azure/ai-foundry/) দেখুন
- [MCP কমিউনিটি রিসোর্স](https://modelcontextprotocol.io/) চেক করুন

## পরবর্তী

- [6. কমিউনিটি অবদান](../../06-CommunityContributions/README.md)

**দায়িত্ব পরিহার**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা সঠিকতার জন্য চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ভুল বা ত্রুটি থাকতে পারে তা দয়া করে বিবেচনা করুন। মূল নথিটি তার মাতৃভাষায়ই প্রামাণিক উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।