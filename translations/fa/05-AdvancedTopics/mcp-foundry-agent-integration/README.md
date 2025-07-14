<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:51:06+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "fa"
}
-->
# ادغام پروتکل مدل کانتکست (MCP) با Azure AI Foundry

این راهنما نحوه ادغام سرورهای پروتکل مدل کانتکست (MCP) با عوامل Azure AI Foundry را نشان می‌دهد که امکان هماهنگی قدرتمند ابزارها و قابلیت‌های هوش مصنوعی سازمانی را فراهم می‌کند.

## مقدمه

پروتکل مدل کانتکست (MCP) یک استاندارد باز است که به برنامه‌های هوش مصنوعی اجازه می‌دهد به‌صورت امن به منابع داده و ابزارهای خارجی متصل شوند. وقتی با Azure AI Foundry ادغام شود، MCP به عوامل امکان می‌دهد به خدمات، APIها و منابع داده خارجی مختلف به روشی استاندارد دسترسی داشته و با آن‌ها تعامل کنند.

این ادغام، انعطاف‌پذیری اکوسیستم ابزارهای MCP را با چارچوب قدرتمند عوامل Azure AI Foundry ترکیب می‌کند و راه‌حل‌های هوش مصنوعی سازمانی با قابلیت‌های سفارشی‌سازی گسترده ارائه می‌دهد.

**توجه:** اگر می‌خواهید از MCP در سرویس عامل Azure AI Foundry استفاده کنید، در حال حاضر فقط مناطق زیر پشتیبانی می‌شوند: westus، westus2، uaenorth، southindia و switzerlandnorth

## اهداف یادگیری

در پایان این راهنما، شما قادر خواهید بود:

- پروتکل مدل کانتکست و مزایای آن را درک کنید
- سرورهای MCP را برای استفاده با عوامل Azure AI Foundry راه‌اندازی کنید
- عوامل را با ادغام ابزار MCP ایجاد و پیکربندی کنید
- مثال‌های عملی با استفاده از سرورهای واقعی MCP پیاده‌سازی کنید
- پاسخ‌ها و ارجاعات ابزارها را در مکالمات عامل مدیریت کنید

## پیش‌نیازها

قبل از شروع، مطمئن شوید که:

- اشتراک Azure با دسترسی به AI Foundry دارید
- پایتون نسخه 3.10 یا بالاتر نصب شده است
- Azure CLI نصب و پیکربندی شده است
- مجوزهای لازم برای ایجاد منابع هوش مصنوعی را دارید

## پروتکل مدل کانتکست (MCP) چیست؟

پروتکل مدل کانتکست روشی استاندارد برای اتصال برنامه‌های هوش مصنوعی به منابع داده و ابزارهای خارجی است. مزایای کلیدی آن عبارتند از:

- **ادغام استاندارد شده**: رابطی یکنواخت برای ابزارها و خدمات مختلف
- **امنیت**: مکانیزم‌های احراز هویت و مجوزدهی امن
- **انعطاف‌پذیری**: پشتیبانی از منابع داده، APIها و ابزارهای سفارشی متنوع
- **قابلیت توسعه**: افزودن آسان قابلیت‌ها و ادغام‌های جدید

## راه‌اندازی MCP با Azure AI Foundry

### ۱. پیکربندی محیط

ابتدا متغیرهای محیطی و وابستگی‌های خود را تنظیم کنید:

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
        instructions="شما یک دستیار مفید هستید. از ابزارهای ارائه شده برای پاسخ به سوالات استفاده کنید. حتماً منابع خود را ذکر کنید.",
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
    print(f"عامل ایجاد شد، شناسه عامل: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # شناسه سرور MCP
    "server_url": "https://api.example.com/mcp", # نقطه پایان سرور MCP
    "require_approval": "never"                 # سیاست تایید: در حال حاضر فقط "never" پشتیبانی می‌شود
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
        # ایجاد عامل با ابزارهای MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="شما یک دستیار مفید متخصص در مستندات مایکروسافت هستید. از سرور MCP مایکروسافت لرن برای جستجوی اطلاعات دقیق و به‌روز استفاده کنید. همیشه منابع خود را ذکر کنید.",
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
        print(f"عامل ایجاد شد، شناسه عامل: {agent.id}")    
        
        # ایجاد رشته مکالمه
        thread = project_client.agents.threads.create()
        print(f"رشته ایجاد شد، شناسه رشته: {thread.id}")

        # ارسال پیام
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content=".NET MAUI چیست؟ چگونه با Xamarin.Forms مقایسه می‌شود؟",
        )
        print(f"پیام ایجاد شد، شناسه پیام: {message.id}")

        # اجرای عامل
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # بررسی تکمیل اجرا
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"وضعیت اجرا: {run.status}")

        # بررسی مراحل اجرا و فراخوانی‌های ابزار
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"مرحله اجرا: {step.id}, وضعیت: {step.status}, نوع: {step.type}")
            if step.type == "tool_calls":
                print("جزئیات فراخوانی ابزار:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # نمایش مکالمه
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## رفع مشکلات رایج

### ۱. مشکلات اتصال
- اطمینان حاصل کنید که URL سرور MCP قابل دسترسی است
- اعتبارنامه‌های احراز هویت را بررسی کنید
- اتصال شبکه را بررسی کنید

### ۲. خطاهای فراخوانی ابزار
- آرگومان‌ها و قالب‌بندی ابزار را بازبینی کنید
- الزامات خاص سرور را بررسی کنید
- مدیریت خطای مناسب را پیاده‌سازی کنید

### ۳. مشکلات عملکرد
- فرکانس فراخوانی ابزار را بهینه کنید
- در صورت لزوم کشینگ را پیاده‌سازی کنید
- زمان پاسخ سرور را نظارت کنید

## مراحل بعدی

برای بهبود بیشتر ادغام MCP خود:

1. **کاوش سرورهای MCP سفارشی**: سرورهای MCP خود را برای منابع داده اختصاصی بسازید
2. **پیاده‌سازی امنیت پیشرفته**: افزودن OAuth2 یا مکانیزم‌های احراز هویت سفارشی
3. **نظارت و تحلیل**: پیاده‌سازی لاگ‌گیری و نظارت بر استفاده از ابزارها
4. **مقیاس‌پذیری راه‌حل**: در نظر گرفتن تعادل بار و معماری‌های توزیع شده سرور MCP

## منابع اضافی

- [مستندات Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- [نمونه‌های پروتکل مدل کانتکست](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [مروری بر عوامل Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [مشخصات MCP](https://spec.modelcontextprotocol.io/)

## پشتیبانی

برای پشتیبانی و سوالات بیشتر:
- مستندات [Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/) را مرور کنید
- منابع جامعه [MCP](https://modelcontextprotocol.io/) را بررسی کنید

## ادامه مطالب

- [۶. مشارکت‌های جامعه](../../06-CommunityContributions/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.