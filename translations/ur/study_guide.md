<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "77bfab7090f987a5b9fe078f50dbda13",
  "translation_date": "2025-07-16T23:41:28+00:00",
  "source_file": "study_guide.md",
  "language_code": "ur"
}
-->
# ماڈل کانٹیکسٹ پروٹوکول (MCP) برائے مبتدی - مطالعہ گائیڈ

یہ مطالعہ گائیڈ "Model Context Protocol (MCP) for Beginners" نصاب کے لیے ریپوزیٹری کی ساخت اور مواد کا جائزہ فراہم کرتی ہے۔ اس گائیڈ کو استعمال کریں تاکہ ریپوزیٹری میں مؤثر طریقے سے نیویگیٹ کیا جا سکے اور دستیاب وسائل سے بھرپور فائدہ اٹھایا جا سکے۔

## ریپوزیٹری کا جائزہ

Model Context Protocol (MCP) ایک معیاری فریم ورک ہے جو AI ماڈلز اور کلائنٹ ایپلیکیشنز کے درمیان تعاملات کے لیے استعمال ہوتا ہے۔ ابتدا میں Anthropic نے اسے تخلیق کیا تھا، اور اب MCP کو وسیع کمیونٹی MCP کی سرکاری GitHub تنظیم کے ذریعے برقرار رکھتی ہے۔ یہ ریپوزیٹری AI ڈویلپرز، سسٹم آرکیٹیکٹس، اور سافٹ ویئر انجینئرز کے لیے C#, Java, JavaScript, Python، اور TypeScript میں عملی کوڈ مثالوں کے ساتھ ایک جامع نصاب فراہم کرتی ہے۔

## بصری نصاب کا نقشہ

```mermaid
mindmap
  root((MCP for Beginners))
    00. Introduction
      ::icon(fa fa-book)
      (Protocol Overview)
      (Standardization)
      (Use Cases)
    01. Core Concepts
      ::icon(fa fa-puzzle-piece)
      (Client-Server Architecture)
      (Protocol Components)
      (Messaging Patterns)
    02. Security
      ::icon(fa fa-shield)
      (Threat Models)
      (Best Practices)
      (Auth Strategies)
    03. Getting Started
      ::icon(fa fa-rocket)
      (First Server)
      (Client)
      (LLM Client)
      (VS Code Integration)
      (SSE Server)
      (HTTP Streaming)
      (AI Toolkit)
      (Testing)
      (Deployment)
    04. Practical Implementation
      ::icon(fa fa-code)
      (SDKs)
      (Testing/Debugging)
      (Prompt Templates)
      (Sample Projects)
    05. Advanced Topics
      ::icon(fa fa-graduation-cap)
      (Context Engineering)
      (Foundry Integration)
      (Multi-modal AI)
      (OAuth2 Demo)
      (Real-time Search)
      (Streaming)
      (Root Contexts)
      (Routing)
      (Sampling)
      (Scaling)
      (Security)
      (Entra ID)
      (Web Search)
      
    06. Community
      ::icon(fa fa-users)
      (Code Contributions)
      (Documentation)
      (MCP Clients)
      (MCP Servers)
      (Image Generation)
    07. Early Adoption
      ::icon(fa fa-lightbulb)
      (Real-world Examples)
      (Deployment Stories)
      (Future Roadmap)
    08. Best Practices
      ::icon(fa fa-check)
      (Performance)
      (Fault Tolerance)
      (Resilience)
    09. Case Studies
      ::icon(fa fa-file-text)
      (API Management)
      (Travel Agent)
      (Azure DevOps)
      (Documentation MCP)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (AI Toolkit Integration)
      (Custom Server Development)
      (Production Deployment)
```

## ریپوزیٹری کی ساخت

ریپوزیٹری کو دس اہم حصوں میں منظم کیا گیا ہے، ہر ایک MCP کے مختلف پہلوؤں پر توجہ دیتا ہے:

1. **تعارف (00-Introduction/)**  
   - Model Context Protocol کا جائزہ  
   - AI پائپ لائنز میں معیاری بنانے کی اہمیت  
   - عملی استعمال کے کیسز اور فوائد  

2. **بنیادی تصورات (01-CoreConcepts/)**  
   - کلائنٹ-سرور آرکیٹیکچر  
   - پروٹوکول کے کلیدی اجزاء  
   - MCP میں میسجنگ کے پیٹرنز  

3. **سیکیورٹی (02-Security/)**  
   - MCP پر مبنی سسٹمز میں سیکیورٹی خطرات  
   - محفوظ نفاذ کے بہترین طریقے  
   - توثیق اور اجازت کی حکمت عملیاں  

4. **شروع کرنے کا طریقہ (03-GettingStarted/)**  
   - ماحول کی ترتیب اور کنفیگریشن  
   - بنیادی MCP سرورز اور کلائنٹس کی تخلیق  
   - موجودہ ایپلیکیشنز کے ساتھ انضمام  
   - شامل سیکشنز:  
     - پہلا سرور نفاذ  
     - کلائنٹ کی ترقی  
     - LLM کلائنٹ انضمام  
     - VS Code انضمام  
     - Server-Sent Events (SSE) سرور  
     - HTTP اسٹریمنگ  
     - AI Toolkit انضمام  
     - ٹیسٹنگ کی حکمت عملیاں  
     - تعیناتی کے رہنما اصول  

5. **عملی نفاذ (04-PracticalImplementation/)**  
   - مختلف پروگرامنگ زبانوں میں SDKs کا استعمال  
   - ڈیبگنگ، ٹیسٹنگ، اور تصدیقی تکنیکیں  
   - دوبارہ استعمال کے قابل پرامپٹ ٹیمپلیٹس اور ورک فلو تیار کرنا  
   - نفاذ کی مثالوں کے ساتھ نمونہ پروجیکٹس  

6. **جدید موضوعات (05-AdvancedTopics/)**  
   - کانٹیکسٹ انجینئرنگ کی تکنیکیں  
   - Foundry ایجنٹ انضمام  
   - ملٹی موڈل AI ورک فلو  
   - OAuth2 توثیق کے مظاہرے  
   - حقیقی وقت کی تلاش کی صلاحیتیں  
   - حقیقی وقت کی اسٹریمنگ  
   - روٹ کانٹیکسٹس کا نفاذ  
   - روٹنگ کی حکمت عملیاں  
   - سیمپلنگ تکنیکیں  
   - اسکیلنگ کے طریقے  
   - سیکیورٹی کے پہلو  
   - Entra ID سیکیورٹی انضمام  
   - ویب سرچ انضمام  

7. **کمیونٹی کی شراکتیں (06-CommunityContributions/)**  
   - کوڈ اور دستاویزات میں تعاون کیسے کریں  
   - GitHub کے ذریعے تعاون  
   - کمیونٹی کی جانب سے بہتری اور تاثرات  
   - مختلف MCP کلائنٹس کا استعمال (Claude Desktop, Cline, VSCode)  
   - مقبول MCP سرورز کے ساتھ کام کرنا بشمول امیج جنریشن  

8. **ابتدائی اپنانے سے حاصل شدہ اسباق (07-LessonsfromEarlyAdoption/)**  
   - حقیقی دنیا میں نفاذ اور کامیابی کی کہانیاں  
   - MCP پر مبنی حل کی تعمیر اور تعیناتی  
   - رجحانات اور مستقبل کا روڈ میپ  

9. **بہترین طریقے (08-BestPractices/)**  
   - کارکردگی کی بہتری اور اصلاح  
   - خرابی برداشت کرنے والے MCP سسٹمز کی ڈیزائننگ  
   - ٹیسٹنگ اور لچک کی حکمت عملیاں  

10. **کیس اسٹڈیز (09-CaseStudy/)**  
    - کیس اسٹڈی: Azure API Management انضمام  
    - کیس اسٹڈی: ٹریول ایجنٹ نفاذ  
    - کیس اسٹڈی: Azure DevOps کا YouTube کے ساتھ انضمام  
    - تفصیلی دستاویزات کے ساتھ نفاذ کی مثالیں  

11. **عملی ورکشاپ (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**  
    - MCP اور AI Toolkit کو یکجا کرنے والی جامع عملی ورکشاپ  
    - ذہین ایپلیکیشنز کی تعمیر جو AI ماڈلز کو حقیقی دنیا کے ٹولز سے جوڑتی ہیں  
    - بنیادی اصول، کسٹم سرور کی ترقی، اور پروڈکشن تعیناتی کی حکمت عملیاں شامل عملی ماڈیولز  
    - مرحلہ وار ہدایات کے ساتھ لیب پر مبنی سیکھنے کا طریقہ  

## اضافی وسائل

ریپوزیٹری میں معاون وسائل شامل ہیں:

- **Images فولڈر**: نصاب میں استعمال ہونے والے خاکے اور تصاویر  
- **Translations**: دستاویزات کے خودکار ترجمے کے ساتھ کثیراللسانی معاونت  
- **سرکاری MCP وسائل**:  
  - [MCP Documentation](https://modelcontextprotocol.io/)  
  - [MCP Specification](https://spec.modelcontextprotocol.io/)  
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)  

## اس ریپوزیٹری کو کیسے استعمال کریں

1. **متسلسل سیکھنا**: ترتیب وار ابواب (00 سے 10 تک) کا مطالعہ کریں تاکہ منظم طریقے سے سیکھا جا سکے۔  
2. **زبان پر مخصوص توجہ**: اگر آپ کسی خاص پروگرامنگ زبان میں دلچسپی رکھتے ہیں تو اپنی پسندیدہ زبان میں نفاذ کے لیے samples ڈائریکٹریز کو دیکھیں۔  
3. **عملی نفاذ**: "Getting Started" سیکشن سے شروع کریں تاکہ اپنا ماحول ترتیب دیں اور اپنا پہلا MCP سرور اور کلائنٹ بنائیں۔  
4. **جدید دریافت**: بنیادی باتوں میں مہارت حاصل کرنے کے بعد جدید موضوعات میں غوطہ لگائیں تاکہ اپنی معلومات کو بڑھایا جا سکے۔  
5. **کمیونٹی میں شمولیت**: MCP کمیونٹی میں GitHub مباحثوں اور Discord چینلز کے ذریعے شامل ہوں تاکہ ماہرین اور دیگر ڈویلپرز سے رابطہ قائم کیا جا سکے۔  

## MCP کلائنٹس اور ٹولز

نصاب مختلف MCP کلائنٹس اور ٹولز کا احاطہ کرتا ہے:

1. **سرکاری کلائنٹس**:  
   - Claude Desktop  
   - VSCode میں Claude  
   - Claude API  

2. **کمیونٹی کلائنٹس**:  
   - Cline (ٹرمینل بیسڈ)  
   - Cursor (کوڈ ایڈیٹر)  
   - ChatMCP  
   - Windsurf  

3. **MCP مینجمنٹ ٹولز**:  
   - MCP CLI  
   - MCP Manager  
   - MCP Linker  
   - MCP Router  

## مقبول MCP سرورز

ریپوزیٹری مختلف MCP سرورز متعارف کراتی ہے، جن میں شامل ہیں:

1. **سرکاری ریفرنس سرورز**:  
   - Filesystem  
   - Fetch  
   - Memory  
   - Sequential Thinking  

2. **امیج جنریشن**:  
   - Azure OpenAI DALL-E 3  
   - Stable Diffusion WebUI  
   - Replicate  

3. **ترقیاتی ٹولز**:  
   - Git MCP  
   - Terminal Control  
   - Code Assistant  

4. **خصوصی سرورز**:  
   - Salesforce  
   - Microsoft Teams  
   - Jira & Confluence  

## تعاون

یہ ریپوزیٹری کمیونٹی کی شراکتوں کا خیرمقدم کرتی ہے۔ MCP ماحولیاتی نظام میں مؤثر تعاون کے لیے Community Contributions سیکشن دیکھیں۔

## تبدیلیوں کا ریکارڈ

| تاریخ | تبدیلیاں |  
|-------|----------|  
| 16 جولائی، 2025 | - موجودہ مواد کی عکاسی کے لیے ریپوزیٹری کی ساخت کو اپ ڈیٹ کیا گیا<br>- MCP کلائنٹس اور ٹولز کا سیکشن شامل کیا گیا<br>- مقبول MCP سرورز کا سیکشن شامل کیا گیا<br>- تمام موجودہ موضوعات کے ساتھ بصری نصاب کا نقشہ اپ ڈیٹ کیا گیا<br>- تمام خصوصی شعبوں کے ساتھ جدید موضوعات کے سیکشن کو بہتر بنایا گیا<br>- حقیقی مثالوں کی عکاسی کے لیے کیس اسٹڈیز کو اپ ڈیٹ کیا گیا<br>- MCP کی ابتدا کو Anthropic کی تخلیق کے طور پر واضح کیا گیا |  
| 11 جون، 2025 | - مطالعہ گائیڈ کی ابتدائی تخلیق<br>- بصری نصاب کا نقشہ شامل کیا گیا<br>- ریپوزیٹری کی ساخت کا خاکہ پیش کیا گیا<br>- نمونہ پروجیکٹس اور اضافی وسائل شامل کیے گئے |  

---

*یہ مطالعہ گائیڈ 16 جولائی، 2025 کو اپ ڈیٹ کی گئی تھی اور اس تاریخ تک ریپوزیٹری کا جائزہ فراہم کرتی ہے۔ اس تاریخ کے بعد ریپوزیٹری کا مواد اپ ڈیٹ ہو سکتا ہے۔*

**دستخطی نوٹ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔