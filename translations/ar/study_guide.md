<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e2c6ed897fa98fa08e0146101776c7ff",
  "translation_date": "2025-07-18T09:14:24+00:00",
  "source_file": "study_guide.md",
  "language_code": "ar"
}
-->
# بروتوكول سياق النموذج (MCP) للمبتدئين - دليل الدراسة

يوفر هذا الدليل نظرة عامة على هيكل ومستوى المحتوى الخاص بمستودع "بروتوكول سياق النموذج (MCP) للمبتدئين". استخدم هذا الدليل للتنقل بكفاءة داخل المستودع والاستفادة القصوى من الموارد المتاحة.

## نظرة عامة على المستودع

بروتوكول سياق النموذج (MCP) هو إطار معياري للتفاعل بين نماذج الذكاء الاصطناعي وتطبيقات العملاء. تم إنشاؤه في البداية بواسطة Anthropic، ويُدار الآن من قبل مجتمع MCP الأوسع عبر المنظمة الرسمية على GitHub. يوفر هذا المستودع منهجًا شاملاً مع أمثلة عملية على الشيفرة بلغات C#، Java، JavaScript، Python، وTypeScript، موجهًا لمطوري الذكاء الاصطناعي، مهندسي الأنظمة، ومهندسي البرمجيات.

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
      (Real-world Implementations)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (MCP Server Fundamentals)
      (Advanced Development)
      (AI Toolkit Integration)
      (Production Deployment)
      (4-Lab Structure)
```

## هيكل المستودع

ينقسم المستودع إلى عشرة أقسام رئيسية، يركز كل منها على جانب مختلف من MCP:

1. **المقدمة (00-Introduction/)**
   - نظرة عامة على بروتوكول سياق النموذج
   - أهمية التوحيد في خطوط أنابيب الذكاء الاصطناعي
   - حالات استخدام عملية وفوائد

2. **المفاهيم الأساسية (01-CoreConcepts/)**
   - بنية العميل-الخادم
   - المكونات الرئيسية للبروتوكول
   - أنماط الرسائل في MCP

3. **الأمان (02-Security/)**
   - التهديدات الأمنية في أنظمة MCP
   - أفضل الممارسات لتأمين التنفيذات
   - استراتيجيات المصادقة والتفويض
   - **توثيق أمني شامل**:
     - أفضل ممارسات أمان MCP لعام 2025
     - دليل تنفيذ أمان محتوى Azure
     - ضوابط وتقنيات أمان MCP
     - مرجع سريع لأفضل ممارسات MCP
   - **المواضيع الأمنية الرئيسية**:
     - هجمات حقن المطالبات وتسميم الأدوات
     - اختطاف الجلسات ومشاكل الوكيل المشوش
     - ثغرات تمرير الرموز
     - الأذونات المفرطة والتحكم في الوصول
     - أمان سلسلة التوريد لمكونات الذكاء الاصطناعي
     - تكامل Microsoft Prompt Shields

4. **البدء السريع (03-GettingStarted/)**
   - إعداد البيئة والتكوين
   - إنشاء خوادم وعملاء MCP أساسيين
   - التكامل مع التطبيقات القائمة
   - يشمل أقسامًا لـ:
     - تنفيذ أول خادم
     - تطوير العميل
     - تكامل عميل LLM
     - تكامل VS Code
     - خادم الأحداث المرسلة من الخادم (SSE)
     - البث عبر HTTP
     - تكامل AI Toolkit
     - استراتيجيات الاختبار
     - إرشادات النشر

5. **التنفيذ العملي (04-PracticalImplementation/)**
   - استخدام SDKs بلغات برمجة مختلفة
   - تقنيات التصحيح، الاختبار، والتحقق
   - تصميم قوالب مطالبات قابلة لإعادة الاستخدام وسير عمل
   - مشاريع نموذجية مع أمثلة تنفيذية

6. **المواضيع المتقدمة (05-AdvancedTopics/)**
   - تقنيات هندسة السياق
   - تكامل وكيل Foundry
   - سير عمل الذكاء الاصطناعي متعدد الوسائط
   - عروض توضيحية لمصادقة OAuth2
   - قدرات البحث في الوقت الحقيقي
   - البث في الوقت الحقيقي
   - تنفيذ سياقات الجذر
   - استراتيجيات التوجيه
   - تقنيات العينة
   - أساليب التوسع
   - اعتبارات الأمان
   - تكامل أمان Entra ID
   - تكامل البحث على الويب

7. **مساهمات المجتمع (06-CommunityContributions/)**
   - كيفية المساهمة بالشيفرة والتوثيق
   - التعاون عبر GitHub
   - تحسينات المجتمع وردود الفعل
   - استخدام عملاء MCP المتنوعين (Claude Desktop، Cline، VSCode)
   - العمل مع خوادم MCP الشهيرة بما في ذلك توليد الصور

8. **دروس من التبني المبكر (07-LessonsfromEarlyAdoption/)**
   - تطبيقات واقعية وقصص نجاح
   - بناء ونشر حلول قائمة على MCP
   - الاتجاهات وخارطة الطريق المستقبلية
   - **دليل خوادم Microsoft MCP**: دليل شامل لعشرة خوادم MCP جاهزة للإنتاج من Microsoft تشمل:
     - خادم Microsoft Learn Docs MCP
     - خادم Azure MCP (أكثر من 15 موصل متخصص)
     - خادم GitHub MCP
     - خادم Azure DevOps MCP
     - خادم MarkItDown MCP
     - خادم SQL Server MCP
     - خادم Playwright MCP
     - خادم Dev Box MCP
     - خادم Azure AI Foundry MCP
     - خادم Microsoft 365 Agents Toolkit MCP

9. **أفضل الممارسات (08-BestPractices/)**
   - ضبط الأداء والتحسين
   - تصميم أنظمة MCP مقاومة للأخطاء
   - استراتيجيات الاختبار والمرونة

10. **دراسات حالة (09-CaseStudy/)**
    - مثال على تكامل Azure API Management
    - مثال على تنفيذ وكيل السفر
    - تكامل Azure DevOps مع تحديثات YouTube
    - أمثلة تنفيذ MCP مع التوثيق
    - أمثلة تنفيذية مع توثيق مفصل

11. **ورشة عمل تطبيقية (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - ورشة عمل شاملة تجمع بين MCP وAI Toolkit
    - بناء تطبيقات ذكية تربط نماذج الذكاء الاصطناعي بالأدوات الواقعية
    - وحدات عملية تغطي الأساسيات، تطوير الخادم المخصص، واستراتيجيات النشر الإنتاجي
    - **هيكل المختبر**:
      - المختبر 1: أساسيات خادم MCP
      - المختبر 2: تطوير خادم MCP المتقدم
      - المختبر 3: تكامل AI Toolkit
      - المختبر 4: النشر الإنتاجي والتوسع
    - نهج تعليمي قائم على المختبرات مع تعليمات خطوة بخطوة

## موارد إضافية

يتضمن المستودع موارد داعمة:

- **مجلد الصور**: يحتوي على مخططات ورسوم توضيحية مستخدمة في المنهج
- **الترجمات**: دعم متعدد اللغات مع ترجمات آلية للتوثيق
- **الموارد الرسمية لـ MCP**:
  - [توثيق MCP](https://modelcontextprotocol.io/)
  - [مواصفات MCP](https://spec.modelcontextprotocol.io/)
  - [مستودع MCP على GitHub](https://github.com/modelcontextprotocol)

## كيفية استخدام هذا المستودع

1. **التعلم المتسلسل**: اتبع الفصول بالترتيب (من 00 إلى 10) لتجربة تعلم منظمة.
2. **التركيز على لغة معينة**: إذا كنت مهتمًا بلغة برمجة محددة، استكشف مجلدات العينات لتنفيذات بلغتك المفضلة.
3. **التنفيذ العملي**: ابدأ بقسم "البدء السريع" لإعداد بيئتك وإنشاء أول خادم وعميل MCP.
4. **الاستكشاف المتقدم**: بعد إتقان الأساسيات، تعمق في المواضيع المتقدمة لتوسيع معرفتك.
5. **المشاركة المجتمعية**: انضم إلى مجتمع MCP عبر مناقشات GitHub وقنوات Discord للتواصل مع الخبراء والمطورين الآخرين.

## عملاء وأدوات MCP

يغطي المنهج عملاء وأدوات MCP المتنوعة:

1. **العملاء الرسميون**:
   - Visual Studio Code
   - MCP في Visual Studio Code
   - Claude Desktop
   - Claude في VSCode
   - Claude API

2. **عملاء المجتمع**:
   - Cline (واجهة طرفية)
   - Cursor (محرر شيفرة)
   - ChatMCP
   - Windsurf

3. **أدوات إدارة MCP**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## خوادم MCP الشهيرة

يقدم المستودع مجموعة متنوعة من خوادم MCP، منها:

1. **خوادم Microsoft MCP الرسمية**:
   - خادم Microsoft Learn Docs MCP
   - خادم Azure MCP (أكثر من 15 موصل متخصص)
   - خادم GitHub MCP
   - خادم Azure DevOps MCP
   - خادم MarkItDown MCP
   - خادم SQL Server MCP
   - خادم Playwright MCP
   - خادم Dev Box MCP
   - خادم Azure AI Foundry MCP
   - خادم Microsoft 365 Agents Toolkit MCP

2. **خوادم مرجعية رسمية**:
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
   - Terminal Control
   - Code Assistant

5. **خوادم متخصصة**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## المساهمة

يرحب هذا المستودع بمساهمات المجتمع. راجع قسم مساهمات المجتمع للحصول على إرشادات حول كيفية المساهمة بفعالية في نظام MCP البيئي.

## سجل التغييرات

| التاريخ | التغييرات |
|---------|------------|
| 18 يوليو 2025 | - تحديث هيكل المستودع ليشمل دليل خوادم Microsoft MCP<br>- إضافة قائمة شاملة لعشرة خوادم MCP جاهزة للإنتاج من Microsoft<br>- تعزيز قسم خوادم MCP الشهيرة بخوادم Microsoft الرسمية<br>- تحديث قسم دراسات الحالة بأمثلة ملفات فعلية<br>- إضافة تفاصيل هيكل المختبر لورشة العمل التطبيقية |
| 16 يوليو 2025 | - تحديث هيكل المستودع ليعكس المحتوى الحالي<br>- إضافة قسم عملاء وأدوات MCP<br>- إضافة قسم خوادم MCP الشهيرة<br>- تحديث خريطة المنهج البصرية بكل المواضيع الحالية<br>- تعزيز قسم المواضيع المتقدمة بجميع المجالات المتخصصة<br>- تحديث دراسات الحالة لتعكس أمثلة فعلية<br>- توضيح أن MCP تم إنشاؤه بواسطة Anthropic |
| 11 يونيو 2025 | - الإنشاء الأولي لدليل الدراسة<br>- إضافة خريطة المنهج البصرية<br>- تحديد هيكل المستودع<br>- تضمين مشاريع نموذجية وموارد إضافية |

---

*تم تحديث هذا الدليل في 18 يوليو 2025، ويقدم نظرة عامة على المستودع حتى ذلك التاريخ. قد يتم تحديث محتوى المستودع بعد هذا التاريخ.*

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.