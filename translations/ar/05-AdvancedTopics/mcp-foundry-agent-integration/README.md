<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:09:07+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "ar"
}
-->
# تكامل بروتوكول سياق النموذج (MCP) مع Azure AI Foundry

يوضح هذا الدليل كيفية دمج خوادم Model Context Protocol (MCP) مع وكلاء Azure AI Foundry، مما يتيح تنظيم الأدوات بشكل قوي وقدرات الذكاء الاصطناعي على مستوى المؤسسات.

## المقدمة

بروتوكول سياق النموذج (MCP) هو معيار مفتوح يتيح لتطبيقات الذكاء الاصطناعي الاتصال بشكل آمن بمصادر البيانات الخارجية والأدوات. عند دمجه مع Azure AI Foundry، يسمح MCP للوكلاء بالوصول إلى خدمات مختلفة وواجهات برمجة التطبيقات ومصادر البيانات الخارجية والتفاعل معها بطريقة موحدة.

يجمع هذا التكامل بين مرونة نظام أدوات MCP وإطار العمل القوي لوكلاء Azure AI Foundry، مقدمًا حلول ذكاء اصطناعي على مستوى المؤسسات مع قدرات تخصيص واسعة.

**ملاحظة:** إذا كنت ترغب في استخدام MCP في خدمة وكلاء Azure AI Foundry، فإن المناطق المدعومة حاليًا هي فقط: westus، westus2، uaenorth، southindia، و switzerlandnorth

## أهداف التعلم

بنهاية هذا الدليل، ستكون قادرًا على:

- فهم بروتوكول سياق النموذج وفوائده  
- إعداد خوادم MCP لاستخدامها مع وكلاء Azure AI Foundry  
- إنشاء وتكوين وكلاء مع تكامل أدوات MCP  
- تنفيذ أمثلة عملية باستخدام خوادم MCP حقيقية  
- التعامل مع ردود الأدوات والاستشهادات في محادثات الوكيل  

## المتطلبات الأساسية

قبل البدء، تأكد من أن لديك:

- اشتراك Azure مع وصول إلى AI Foundry  
- Python 3.10 أو أحدث  
- تثبيت وتكوين Azure CLI  
- الأذونات المناسبة لإنشاء موارد الذكاء الاصطناعي  

## ما هو بروتوكول سياق النموذج (MCP)؟

بروتوكول سياق النموذج هو طريقة موحدة لتطبيقات الذكاء الاصطناعي للاتصال بمصادر البيانات والأدوات الخارجية. تشمل الفوائد الرئيسية:

- **تكامل موحد**: واجهة متسقة عبر أدوات وخدمات مختلفة  
- **الأمان**: آليات مصادقة وتفويض آمنة  
- **المرونة**: دعم لمصادر بيانات متعددة، وواجهات برمجة التطبيقات، والأدوات المخصصة  
- **قابلية التوسع**: سهولة إضافة قدرات وتكاملات جديدة  

## إعداد MCP مع Azure AI Foundry

### 1. تكوين البيئة

أولاً، قم بإعداد متغيرات البيئة والاعتمادات:

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
        instructions="أنت مساعد مفيد. استخدم الأدوات المقدمة للإجابة على الأسئلة. تأكد من الاستشهاد بمصادرك.",  
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
    print(f"تم إنشاء الوكيل، معرف الوكيل: {agent.id}")  
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python  
mcp_tool = {  
    "type": "mcp",  
    "server_label": "unique_server_name",      # معرف خادم MCP  
    "server_url": "https://api.example.com/mcp", # نقطة نهاية خادم MCP  
    "require_approval": "never"                 # سياسة الموافقة: تدعم حاليًا فقط "never"  
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
        # إنشاء وكيل مع أدوات MCP  
        agent = project_client.agents.create_agent(  
            model="gpt-4.1-nano",   
            name="documentation_assistant",   
            instructions="أنت مساعد مفيد متخصص في توثيقات مايكروسوفت. استخدم خادم MCP الخاص بـ Microsoft Learn للبحث عن معلومات دقيقة ومحدثة. استشهد دائمًا بمصادرك.",  
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
        print(f"تم إنشاء الوكيل، معرف الوكيل: {agent.id}")      
        
        # إنشاء سلسلة المحادثة  
        thread = project_client.agents.threads.create()  
        print(f"تم إنشاء السلسلة، معرف السلسلة: {thread.id}")  

        # إرسال رسالة  
        message = project_client.agents.messages.create(  
            thread_id=thread.id,   
            role="user",   
            content="ما هو .NET MAUI؟ كيف يقارن بـ Xamarin.Forms؟",  
        )  
        print(f"تم إنشاء الرسالة، معرف الرسالة: {message.id}")  

        # تشغيل الوكيل  
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)  
        
        # الاستعلام عن حالة الإنجاز  
        while run.status in ["queued", "in_progress", "requires_action"]:  
            time.sleep(1)  
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)  
            print(f"حالة التنفيذ: {run.status}")  

        # فحص خطوات التنفيذ واستدعاءات الأدوات  
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)  
        for step in run_steps:  
            print(f"خطوة التنفيذ: {step.id}, الحالة: {step.status}, النوع: {step.type}")  
            if step.type == "tool_calls":  
                print("تفاصيل استدعاء الأداة:")  
                for tool_call in step.step_details.tool_calls:  
                    print(json.dumps(tool_call.as_dict(), indent=2))  

        # عرض المحادثة  
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)  
        for data_point in messages:  
            last_message_content = data_point.content[-1]  
            if isinstance(last_message_content, MessageTextContent):  
                print(f"{data_point.role}: {last_message_content.text.value}")  

        return agent.id, thread.id  

if __name__ == "__main__":  
    create_mcp_agent_example()  

## استكشاف المشكلات الشائعة

### 1. مشاكل الاتصال  
- تحقق من إمكانية الوصول إلى عنوان خادم MCP  
- راجع بيانات الاعتماد الخاصة بالمصادقة  
- تأكد من اتصال الشبكة  

### 2. فشل استدعاءات الأدوات  
- راجع وسائط وأسلوب استدعاء الأدوات  
- تحقق من متطلبات الخادم الخاصة  
- نفذ معالجة الأخطاء بشكل صحيح  

### 3. مشاكل الأداء  
- حسّن تكرار استدعاءات الأدوات  
- استخدم التخزين المؤقت عند الضرورة  
- راقب أوقات استجابة الخادم  

## الخطوات التالية

لتعزيز تكامل MCP الخاص بك:

1. **استكشاف خوادم MCP المخصصة**: أنشئ خوادم MCP خاصة بمصادر بياناتك  
2. **تنفيذ أمان متقدم**: أضف آليات مصادقة مثل OAuth2 أو مخصصة  
3. **المراقبة والتحليلات**: نفذ تسجيل ومراقبة لاستخدام الأدوات  
4. **توسيع الحل الخاص بك**: فكر في موازنة التحميل وهياكل خوادم MCP الموزعة  

## موارد إضافية

- [توثيق Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)  
- [عينات بروتوكول سياق النموذج](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)  
- [نظرة عامة على وكلاء Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/agents/)  
- [مواصفات MCP](https://spec.modelcontextprotocol.io/)  

## الدعم

للحصول على دعم إضافي وأسئلة:  
- راجع [توثيق Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)  
- تحقق من [موارد مجتمع MCP](https://modelcontextprotocol.io/)  

## ما التالي

- [6. مساهمات المجتمع](../../06-CommunityContributions/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالترجمة المهنية البشرية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.