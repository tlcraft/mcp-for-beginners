<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e2c6ed897fa98fa08e0146101776c7ff",
  "translation_date": "2025-07-18T09:16:09+00:00",
  "source_file": "study_guide.md",
  "language_code": "fa"
}
-->
# پروتکل زمینه مدل (MCP) برای مبتدیان - راهنمای مطالعه

این راهنمای مطالعه نمای کلی از ساختار و محتوای مخزن مربوط به دوره «پروتکل زمینه مدل (MCP) برای مبتدیان» را ارائه می‌دهد. از این راهنما برای پیمایش مؤثر در مخزن و بهره‌برداری بهتر از منابع موجود استفاده کنید.

## نمای کلی مخزن

پروتکل زمینه مدل (MCP) چارچوبی استاندارد برای تعاملات بین مدل‌های هوش مصنوعی و برنامه‌های کلاینت است. این پروتکل که ابتدا توسط Anthropic ایجاد شده، اکنون توسط جامعه گسترده‌تر MCP از طریق سازمان رسمی GitHub نگهداری می‌شود. این مخزن یک دوره جامع با نمونه‌های کد عملی در زبان‌های C#، Java، JavaScript، Python و TypeScript ارائه می‌دهد که برای توسعه‌دهندگان هوش مصنوعی، معماران سیستم و مهندسان نرم‌افزار طراحی شده است.

## نقشه تصویری دوره

```mermaid
mindmap
  root((MCP for Beginners))
    00. Introduction
      ::icon(fa fa-book)
      (Protocol Overview)
      (Standardization Benefits)
      (Real-world Use Cases)
      (AI Integration Fundamentals)
    01. Core Concepts
      ::icon(fa fa-puzzle-piece)
      (Client-Server Architecture)
      (Protocol Components)
      (Messaging Patterns)
      (Transport Mechanisms)
    02. Security
      ::icon(fa fa-shield)
      (AI-Specific Threats)
      (Best Practices 2025)
      (Azure Content Safety)
      (Auth & Authorization)
      (Microsoft Prompt Shields)
    03. Getting Started
      ::icon(fa fa-rocket)
      (First Server Implementation)
      (Client Development)
      (LLM Client Integration)
      (VS Code Extensions)
      (SSE Server Setup)
      (HTTP Streaming)
      (AI Toolkit Integration)
      (Testing Frameworks)
      (Deployment Strategies)
    04. Practical Implementation
      ::icon(fa fa-code)
      (Multi-Language SDKs)
      (Testing & Debugging)
      (Prompt Templates)
      (Sample Projects)
      (Production Patterns)
    05. Advanced Topics
      ::icon(fa fa-graduation-cap)
      (Context Engineering)
      (Foundry Agent Integration)
      (Multi-modal AI Workflows)
      (OAuth2 Authentication)
      (Real-time Search)
      (Streaming Protocols)
      (Root Contexts)
      (Routing Strategies)
      (Sampling Techniques)
      (Scaling Solutions)
      (Security Hardening)
      (Entra ID Integration)
      (Web Search MCP)
      
    06. Community
      ::icon(fa fa-users)
      (Code Contributions)
      (Documentation)
      (MCP Client Ecosystem)
      (MCP Server Registry)
      (Image Generation Tools)
      (GitHub Collaboration)
    07. Early Adoption
      ::icon(fa fa-lightbulb)
      (Production Deployments)
      (Microsoft MCP Servers)
      (Azure MCP Service)
      (Enterprise Case Studies)
      (Future Roadmap)
    08. Best Practices
      ::icon(fa fa-check)
      (Performance Optimization)
      (Fault Tolerance)
      (System Resilience)
      (Monitoring & Observability)
    09. Case Studies
      ::icon(fa fa-file-text)
      (Azure API Management)
      (AI Travel Agent)
      (Azure DevOps Integration)
      (Documentation MCP)
      (Real-world Implementations)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (MCP Server Fundamentals)
      (Advanced Development)
      (AI Toolkit Integration)
      (Production Deployment)
      (4-Lab Structure)
```

## ساختار مخزن

مخزن به ده بخش اصلی تقسیم شده است که هر کدام بر جنبه‌های مختلف MCP تمرکز دارند:

1. **مقدمه (00-Introduction/)**
   - نمای کلی پروتکل زمینه مدل
   - اهمیت استانداردسازی در زنجیره‌های هوش مصنوعی
   - موارد کاربرد عملی و مزایا

2. **مفاهیم اصلی (01-CoreConcepts/)**
   - معماری کلاینت-سرور
   - اجزای کلیدی پروتکل
   - الگوهای پیام‌رسانی در MCP

3. **امنیت (02-Security/)**
   - تهدیدات امنیتی در سیستم‌های مبتنی بر MCP
   - بهترین روش‌ها برای ایمن‌سازی پیاده‌سازی‌ها
   - استراتژی‌های احراز هویت و مجوزدهی
   - **مستندات جامع امنیتی**:
     - بهترین روش‌های امنیتی MCP 2025
     - راهنمای پیاده‌سازی Azure Content Safety
     - کنترل‌ها و تکنیک‌های امنیتی MCP
     - مرجع سریع بهترین روش‌های MCP
   - **موضوعات کلیدی امنیتی**:
     - حملات تزریق پرامپت و مسمومیت ابزار
     - ربودن نشست و مشکلات نماینده گیج‌شده
     - آسیب‌پذیری‌های عبور توکن
     - مجوزهای بیش از حد و کنترل دسترسی
     - امنیت زنجیره تأمین برای اجزای هوش مصنوعی
     - ادغام Microsoft Prompt Shields

4. **شروع به کار (03-GettingStarted/)**
   - راه‌اندازی و پیکربندی محیط
   - ایجاد سرورها و کلاینت‌های پایه MCP
   - ادغام با برنامه‌های موجود
   - شامل بخش‌هایی برای:
     - پیاده‌سازی اولین سرور
     - توسعه کلاینت
     - ادغام کلاینت LLM
     - ادغام با VS Code
     - سرور رویدادهای ارسال شده از سرور (SSE)
     - استریمینگ HTTP
     - ادغام AI Toolkit
     - استراتژی‌های تست
     - راهنمای استقرار

5. **پیاده‌سازی عملی (04-PracticalImplementation/)**
   - استفاده از SDKها در زبان‌های برنامه‌نویسی مختلف
   - تکنیک‌های اشکال‌زدایی، تست و اعتبارسنجی
   - ساخت قالب‌ها و جریان‌های کاری قابل استفاده مجدد برای پرامپت‌ها
   - پروژه‌های نمونه با مثال‌های پیاده‌سازی

6. **موضوعات پیشرفته (05-AdvancedTopics/)**
   - تکنیک‌های مهندسی زمینه
   - ادغام عامل Foundry
   - جریان‌های کاری چندرسانه‌ای هوش مصنوعی
   - دموهای احراز هویت OAuth2
   - قابلیت‌های جستجوی بلادرنگ
   - استریمینگ بلادرنگ
   - پیاده‌سازی زمینه‌های ریشه‌ای
   - استراتژی‌های مسیریابی
   - تکنیک‌های نمونه‌گیری
   - رویکردهای مقیاس‌پذیری
   - ملاحظات امنیتی
   - ادغام امنیتی Entra ID
   - ادغام جستجوی وب

7. **مشارکت‌های جامعه (06-CommunityContributions/)**
   - نحوه مشارکت در کد و مستندات
   - همکاری از طریق GitHub
   - بهبودها و بازخوردهای مبتنی بر جامعه
   - استفاده از کلاینت‌های مختلف MCP (Claude Desktop، Cline، VSCode)
   - کار با سرورهای محبوب MCP از جمله تولید تصویر

8. **درس‌هایی از پذیرش اولیه (07-LessonsfromEarlyAdoption/)**
   - پیاده‌سازی‌های واقعی و داستان‌های موفقیت
   - ساخت و استقرار راه‌حل‌های مبتنی بر MCP
   - روندها و نقشه راه آینده
   - **راهنمای سرورهای Microsoft MCP**: راهنمای جامع ۱۰ سرور Microsoft MCP آماده تولید شامل:
     - Microsoft Learn Docs MCP Server
     - Azure MCP Server (بیش از ۱۵ کانکتور تخصصی)
     - GitHub MCP Server
     - Azure DevOps MCP Server
     - MarkItDown MCP Server
     - SQL Server MCP Server
     - Playwright MCP Server
     - Dev Box MCP Server
     - Azure AI Foundry MCP Server
     - Microsoft 365 Agents Toolkit MCP Server

9. **بهترین روش‌ها (08-BestPractices/)**
   - بهینه‌سازی عملکرد و تنظیمات
   - طراحی سیستم‌های MCP مقاوم در برابر خطا
   - استراتژی‌های تست و تاب‌آوری

10. **مطالعات موردی (09-CaseStudy/)**
    - نمونه ادغام Azure API Management
    - نمونه پیاده‌سازی آژانس مسافرتی
    - ادغام Azure DevOps با به‌روزرسانی‌های YouTube
    - نمونه‌های پیاده‌سازی MCP مستندسازی شده
    - مثال‌های پیاده‌سازی با مستندات دقیق

11. **کارگاه عملی (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - کارگاه عملی جامع ترکیب MCP با AI Toolkit
    - ساخت برنامه‌های هوشمند که مدل‌های هوش مصنوعی را با ابزارهای دنیای واقعی پیوند می‌دهند
    - ماژول‌های عملی شامل مبانی، توسعه سرور سفارشی و استراتژی‌های استقرار در تولید
    - **ساختار آزمایشگاه**:
      - آزمایشگاه ۱: مبانی سرور MCP
      - آزمایشگاه ۲: توسعه پیشرفته سرور MCP
      - آزمایشگاه ۳: ادغام AI Toolkit
      - آزمایشگاه ۴: استقرار و مقیاس‌پذیری در تولید
    - رویکرد یادگیری مبتنی بر آزمایشگاه با دستورالعمل‌های گام به گام

## منابع اضافی

مخزن شامل منابع پشتیبانی است:

- **پوشه تصاویر**: شامل نمودارها و تصاویر استفاده شده در سراسر دوره
- **ترجمه‌ها**: پشتیبانی چندزبانه با ترجمه‌های خودکار مستندات
- **منابع رسمی MCP**:
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## نحوه استفاده از این مخزن

1. **یادگیری متوالی**: فصل‌ها را به ترتیب (از ۰۰ تا ۱۰) دنبال کنید تا تجربه یادگیری ساختاریافته‌ای داشته باشید.
2. **تمرکز بر زبان خاص**: اگر به زبان برنامه‌نویسی خاصی علاقه‌مندید، دایرکتوری نمونه‌ها را برای پیاده‌سازی‌ها در زبان مورد نظر خود بررسی کنید.
3. **پیاده‌سازی عملی**: با بخش «شروع به کار» شروع کنید تا محیط خود را راه‌اندازی کرده و اولین سرور و کلاینت MCP خود را بسازید.
4. **کاوش پیشرفته**: پس از آشنایی با مبانی، به موضوعات پیشرفته بپردازید تا دانش خود را گسترش دهید.
5. **مشارکت در جامعه**: از طریق بحث‌های GitHub و کانال‌های Discord به جامعه MCP بپیوندید تا با کارشناسان و توسعه‌دهندگان دیگر ارتباط برقرار کنید.

## کلاینت‌ها و ابزارهای MCP

دوره شامل کلاینت‌ها و ابزارهای مختلف MCP است:

1. **کلاینت‌های رسمی**:
   - Visual Studio Code
   - MCP در Visual Studio Code
   - Claude Desktop
   - Claude در VSCode
   - Claude API

2. **کلاینت‌های جامعه**:
   - Cline (مبتنی بر ترمینال)
   - Cursor (ویرایشگر کد)
   - ChatMCP
   - Windsurf

3. **ابزارهای مدیریت MCP**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## سرورهای محبوب MCP

مخزن سرورهای مختلف MCP را معرفی می‌کند، از جمله:

1. **سرورهای رسمی Microsoft MCP**:
   - Microsoft Learn Docs MCP Server
   - Azure MCP Server (بیش از ۱۵ کانکتور تخصصی)
   - GitHub MCP Server
   - Azure DevOps MCP Server
   - MarkItDown MCP Server
   - SQL Server MCP Server
   - Playwright MCP Server
   - Dev Box MCP Server
   - Azure AI Foundry MCP Server
   - Microsoft 365 Agents Toolkit MCP Server

2. **سرورهای مرجع رسمی**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

3. **تولید تصویر**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

4. **ابزارهای توسعه**:
   - Git MCP
   - Terminal Control
   - Code Assistant

5. **سرورهای تخصصی**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## مشارکت

این مخزن از مشارکت‌های جامعه استقبال می‌کند. برای راهنمایی در مورد نحوه مشارکت مؤثر در اکوسیستم MCP به بخش مشارکت‌های جامعه مراجعه کنید.

## تغییرات

| تاریخ | تغییرات |
|-------|---------|
| ۱۸ ژوئیه ۲۰۲۵ | - به‌روزرسانی ساختار مخزن برای افزودن راهنمای سرورهای Microsoft MCP<br>- اضافه کردن فهرست جامع ۱۰ سرور Microsoft MCP آماده تولید<br>- تقویت بخش سرورهای محبوب MCP با سرورهای رسمی Microsoft MCP<br>- به‌روزرسانی بخش مطالعات موردی با نمونه‌های واقعی فایل<br>- افزودن جزئیات ساختار آزمایشگاه برای کارگاه عملی |
| ۱۶ ژوئیه ۲۰۲۵ | - به‌روزرسانی ساختار مخزن برای بازتاب محتوای فعلی<br>- افزودن بخش کلاینت‌ها و ابزارهای MCP<br>- افزودن بخش سرورهای محبوب MCP<br>- به‌روزرسانی نقشه تصویری دوره با تمام موضوعات فعلی<br>- تقویت بخش موضوعات پیشرفته با تمام حوزه‌های تخصصی<br>- به‌روزرسانی مطالعات موردی با نمونه‌های واقعی<br>- روشن‌سازی اینکه MCP توسط Anthropic ایجاد شده است |
| ۱۱ ژوئن ۲۰۲۵ | - ایجاد اولیه راهنمای مطالعه<br>- افزودن نقشه تصویری دوره<br>- ترسیم ساختار مخزن<br>- افزودن پروژه‌های نمونه و منابع اضافی |

---

*این راهنمای مطالعه در تاریخ ۱۸ ژوئیه ۲۰۲۵ به‌روزرسانی شده و نمای کلی مخزن تا آن تاریخ را ارائه می‌دهد. محتوای مخزن ممکن است پس از این تاریخ به‌روزرسانی شود.*

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.