<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "719117a0a5f34ade7b5dfb61ee06fb13",
  "translation_date": "2025-09-26T17:41:09+00:00",
  "source_file": "study_guide.md",
  "language_code": "ar"
}
-->
# دليل دراسة بروتوكول سياق النموذج (MCP) للمبتدئين

يوفر هذا الدليل نظرة عامة على هيكلية المحتوى والمستودع الخاص بمنهج "بروتوكول سياق النموذج (MCP) للمبتدئين". استخدم هذا الدليل للتنقل بكفاءة في المستودع والاستفادة القصوى من الموارد المتاحة.

## نظرة عامة على المستودع

بروتوكول سياق النموذج (MCP) هو إطار عمل معياري للتفاعل بين نماذج الذكاء الاصطناعي وتطبيقات العملاء. تم إنشاؤه في البداية بواسطة Anthropic، ويتم الآن صيانته من قبل مجتمع MCP الأوسع من خلال المنظمة الرسمية على GitHub. يوفر هذا المستودع منهجًا شاملاً مع أمثلة عملية للرمز باستخدام C#، Java، JavaScript، Python، وTypeScript، مصممًا لمطوري الذكاء الاصطناعي، مهندسي الأنظمة، ومهندسي البرمجيات.

## خريطة المنهج البصرية

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
      (GitHub MCP Registry)
      (VS Code Integration)
      (Real-world Implementations)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (MCP Server Fundamentals)
      (Advanced Development)
      (AI Toolkit Integration)
      (Production Deployment)
      (4-Lab Structure)
```

## هيكلية المستودع

المستودع منظم في عشرة أقسام رئيسية، كل منها يركز على جوانب مختلفة من MCP:

1. **المقدمة (00-Introduction/)**
   - نظرة عامة على بروتوكول سياق النموذج
   - أهمية التوحيد في خطوط أنابيب الذكاء الاصطناعي
   - حالات الاستخدام العملية والفوائد

2. **المفاهيم الأساسية (01-CoreConcepts/)**
   - هيكلية العميل-الخادم
   - المكونات الرئيسية للبروتوكول
   - أنماط الرسائل في MCP

3. **الأمان (02-Security/)**
   - تهديدات الأمان في الأنظمة القائمة على MCP
   - أفضل الممارسات لتأمين التنفيذ
   - استراتيجيات المصادقة والتفويض
   - **وثائق أمان شاملة**:
     - أفضل ممارسات أمان MCP لعام 2025
     - دليل تنفيذ أمان محتوى Azure
     - تقنيات وضوابط أمان MCP
     - مرجع سريع لأفضل ممارسات MCP
   - **مواضيع أمان رئيسية**:
     - هجمات حقن التعليمات البرمجية وتسميم الأدوات
     - اختطاف الجلسات ومشاكل الوكلاء المربكين
     - ثغرات تمرير الرموز
     - الأذونات الزائدة والتحكم في الوصول
     - أمان سلسلة التوريد لمكونات الذكاء الاصطناعي
     - تكامل دروع التعليمات البرمجية من Microsoft

4. **البدء (03-GettingStarted/)**
   - إعداد البيئة والتكوين
   - إنشاء خوادم وعملاء MCP أساسية
   - التكامل مع التطبيقات الحالية
   - يتضمن أقسامًا لـ:
     - تنفيذ أول خادم
     - تطوير العميل
     - تكامل عميل LLM
     - تكامل VS Code
     - خادم أحداث مرسلة من الخادم (SSE)
     - بث HTTP
     - تكامل أدوات الذكاء الاصطناعي
     - استراتيجيات الاختبار
     - إرشادات النشر

5. **التنفيذ العملي (04-PracticalImplementation/)**
   - استخدام SDKs عبر لغات البرمجة المختلفة
   - تقنيات التصحيح والاختبار والتحقق
   - إنشاء قوالب التعليمات البرمجية القابلة لإعادة الاستخدام
   - مشاريع نموذجية مع أمثلة تنفيذية

6. **مواضيع متقدمة (05-AdvancedTopics/)**
   - تقنيات هندسة السياق
   - تكامل وكلاء Foundry
   - سير عمل الذكاء الاصطناعي متعدد الوسائط
   - عروض مصادقة OAuth2
   - قدرات البحث في الوقت الفعلي
   - البث في الوقت الفعلي
   - تنفيذ سياقات الجذر
   - استراتيجيات التوجيه
   - تقنيات أخذ العينات
   - نهج التوسع
   - اعتبارات الأمان
   - تكامل أمان Entra ID
   - تكامل البحث على الويب

7. **مساهمات المجتمع (06-CommunityContributions/)**
   - كيفية المساهمة في الكود والوثائق
   - التعاون عبر GitHub
   - تحسينات وردود فعل يقودها المجتمع
   - استخدام عملاء MCP المختلفين (Claude Desktop، Cline، VSCode)
   - العمل مع خوادم MCP الشهيرة بما في ذلك توليد الصور

8. **دروس من التبني المبكر (07-LessonsfromEarlyAdoption/)**
   - تنفيذات واقعية وقصص نجاح
   - بناء ونشر حلول قائمة على MCP
   - الاتجاهات وخارطة الطريق المستقبلية
   - **دليل خوادم MCP من Microsoft**: دليل شامل لـ 10 خوادم MCP جاهزة للإنتاج من Microsoft بما في ذلك:
     - خادم MCP لوثائق Microsoft Learn
     - خادم MCP لـ Azure (15+ موصلات متخصصة)
     - خادم MCP لـ GitHub
     - خادم MCP لـ Azure DevOps
     - خادم MCP لـ MarkItDown
     - خادم MCP لـ SQL Server
     - خادم MCP لـ Playwright
     - خادم MCP لـ Dev Box
     - خادم MCP لـ Azure AI Foundry
     - خادم MCP لـ Microsoft 365 Agents Toolkit

9. **أفضل الممارسات (08-BestPractices/)**
   - تحسين الأداء وضبطه
   - تصميم أنظمة MCP مقاومة للأعطال
   - استراتيجيات الاختبار والمرونة

10. **دراسات الحالة (09-CaseStudy/)**
    - **سبع دراسات حالة شاملة** تظهر مرونة MCP عبر سيناريوهات متنوعة:
    - **وكلاء السفر للذكاء الاصطناعي من Azure**: تنسيق متعدد الوكلاء مع Azure OpenAI والبحث الذكي
    - **تكامل Azure DevOps**: أتمتة عمليات سير العمل مع تحديثات بيانات YouTube
    - **استرجاع الوثائق في الوقت الفعلي**: عميل Python console مع بث HTTP
    - **مولد خطة دراسة تفاعلي**: تطبيق ويب Chainlit مع الذكاء الاصطناعي الحواري
    - **الوثائق داخل المحرر**: تكامل VS Code مع سير عمل GitHub Copilot
    - **إدارة واجهات برمجة التطبيقات لـ Azure**: تكامل واجهات برمجة التطبيقات المؤسسية مع إنشاء خادم MCP
    - **سجل MCP لـ GitHub**: تطوير النظام البيئي ومنصة التكامل الوكيل
    - أمثلة تنفيذية تمتد عبر التكامل المؤسسي، إنتاجية المطورين، وتطوير النظام البيئي

11. **ورشة عمل عملية (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - ورشة عمل عملية شاملة تجمع بين MCP وأدوات الذكاء الاصطناعي
    - بناء تطبيقات ذكية تربط نماذج الذكاء الاصطناعي بالأدوات الواقعية
    - وحدات عملية تغطي الأساسيات، تطوير الخوادم المخصصة، واستراتيجيات النشر الإنتاجي
    - **هيكلية المختبر**:
      - مختبر 1: أساسيات خادم MCP
      - مختبر 2: تطوير خادم MCP متقدم
      - مختبر 3: تكامل أدوات الذكاء الاصطناعي
      - مختبر 4: النشر الإنتاجي والتوسع
    - نهج تعلم قائم على المختبر مع تعليمات خطوة بخطوة

## موارد إضافية

يتضمن المستودع موارد داعمة:

- **مجلد الصور**: يحتوي على الرسوم البيانية والرسوم التوضيحية المستخدمة في المنهج
- **الترجمات**: دعم متعدد اللغات مع ترجمات تلقائية للوثائق
- **موارد MCP الرسمية**:
  - [وثائق MCP](https://modelcontextprotocol.io/)
  - [مواصفات MCP](https://spec.modelcontextprotocol.io/)
  - [مستودع GitHub لـ MCP](https://github.com/modelcontextprotocol)

## كيفية استخدام هذا المستودع

1. **التعلم المتسلسل**: اتبع الفصول بالترتيب (00 إلى 10) لتجربة تعلم منظمة.
2. **التركيز على لغة معينة**: إذا كنت مهتمًا بلغة برمجة معينة، استكشف أدلة العينات للتنفيذات بلغتك المفضلة.
3. **التنفيذ العملي**: ابدأ بقسم "البدء" لإعداد بيئتك وإنشاء أول خادم وعميل MCP.
4. **الاستكشاف المتقدم**: بمجرد أن تصبح مرتاحًا مع الأساسيات، استكشف المواضيع المتقدمة لتوسيع معرفتك.
5. **التفاعل المجتمعي**: انضم إلى مجتمع MCP عبر مناقشات GitHub وقنوات Discord للتواصل مع الخبراء والمطورين الآخرين.

## عملاء وأدوات MCP

يغطي المنهج عملاء وأدوات MCP المختلفة:

1. **العملاء الرسميون**:
   - Visual Studio Code
   - MCP في Visual Studio Code
   - Claude Desktop
   - Claude في VSCode
   - Claude API

2. **عملاء المجتمع**:
   - Cline (مبني على الطرفية)
   - Cursor (محرر الكود)
   - ChatMCP
   - Windsurf

3. **أدوات إدارة MCP**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## خوادم MCP الشهيرة

يقدم المستودع مجموعة متنوعة من خوادم MCP، بما في ذلك:

1. **خوادم MCP الرسمية من Microsoft**:
   - خادم MCP لوثائق Microsoft Learn
   - خادم MCP لـ Azure (15+ موصلات متخصصة)
   - خادم MCP لـ GitHub
   - خادم MCP لـ Azure DevOps
   - خادم MCP لـ MarkItDown
   - خادم MCP لـ SQL Server
   - خادم MCP لـ Playwright
   - خادم MCP لـ Dev Box
   - خادم MCP لـ Azure AI Foundry
   - خادم MCP لـ Microsoft 365 Agents Toolkit

2. **الخوادم المرجعية الرسمية**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

3. **توليد الصور**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

4. **أدوات التطوير**:
   - Git MCP
   - التحكم في الطرفية
   - مساعد الكود

5. **الخوادم المتخصصة**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## المساهمة

يرحب هذا المستودع بمساهمات المجتمع. راجع قسم مساهمات المجتمع للحصول على إرشادات حول كيفية المساهمة بفعالية في نظام MCP البيئي.

## سجل التغييرات

| التاريخ | التغييرات |
|--------|-----------|
| 26 سبتمبر 2025 | - إضافة دراسة حالة سجل MCP لـ GitHub إلى قسم 09-CaseStudy<br>- تحديث دراسات الحالة لتعكس سبع دراسات حالة شاملة<br>- تحسين أوصاف دراسات الحالة بتفاصيل تنفيذ محددة<br>- تحديث خريطة المنهج البصرية لتشمل سجل MCP لـ GitHub<br>- مراجعة هيكلية دليل الدراسة لتعكس التركيز على تطوير النظام البيئي |
| 18 يوليو 2025 | - تحديث هيكلية المستودع لتشمل دليل خوادم MCP من Microsoft<br>- إضافة قائمة شاملة لـ 10 خوادم MCP جاهزة للإنتاج من Microsoft<br>- تحسين قسم خوادم MCP الشهيرة بخوادم MCP الرسمية من Microsoft<br>- تحديث قسم دراسات الحالة بأمثلة ملفات فعلية<br>- إضافة تفاصيل هيكلية المختبر لورشة العمل العملية |
| 16 يوليو 2025 | - تحديث هيكلية المستودع لتعكس المحتوى الحالي<br>- إضافة قسم عملاء وأدوات MCP<br>- إضافة قسم خوادم MCP الشهيرة<br>- تحديث خريطة المنهج البصرية بجميع المواضيع الحالية<br>- تحسين قسم المواضيع المتقدمة بجميع المجالات المتخصصة<br>- تحديث دراسات الحالة لتعكس أمثلة فعلية<br>- توضيح أصل MCP كإنشاء من Anthropic |
| 11 يونيو 2025 | - إنشاء دليل الدراسة الأولي<br>- إضافة خريطة المنهج البصرية<br>- تحديد هيكلية المستودع<br>- تضمين مشاريع نموذجية وموارد إضافية |

---

*تم تحديث دليل الدراسة هذا في 26 سبتمبر 2025، ويوفر نظرة عامة على المستودع اعتبارًا من ذلك التاريخ. قد يتم تحديث محتوى المستودع بعد هذا التاريخ.*

---

