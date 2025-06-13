<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T23:06:11+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ur"
}
-->
## شروع کرنا

یہ سیکشن کئی اسباق پر مشتمل ہے:

- **1 آپ کا پہلا سرور**، اس پہلے سبق میں، آپ سیکھیں گے کہ اپنا پہلا سرور کیسے بنائیں اور اسے inspector ٹول کے ذریعے معائنہ کریں، جو آپ کے سرور کی جانچ اور ڈیبگ کرنے کا ایک قیمتی طریقہ ہے، [سبق پر جائیں](/03-GettingStarted/01-first-server/README.md)

- **2 کلائنٹ**، اس سبق میں، آپ سیکھیں گے کہ ایسا کلائنٹ کیسے لکھیں جو آپ کے سرور سے جڑ سکے، [سبق پر جائیں](/03-GettingStarted/02-client/README.md)

- **3 LLM کے ساتھ کلائنٹ**، کلائنٹ لکھنے کا ایک بہتر طریقہ یہ ہے کہ اس میں LLM شامل کریں تاکہ یہ آپ کے سرور کے ساتھ "مذاکرہ" کر سکے کہ کیا کرنا ہے، [سبق پر جائیں](/03-GettingStarted/03-llm-client/README.md)

- **4 Visual Studio Code میں GitHub Copilot Agent موڈ کے ساتھ سرور کا استعمال**۔ یہاں، ہم Visual Studio Code کے اندر سے اپنا MCP سرور چلانے پر غور کر رہے ہیں، [سبق پر جائیں](/03-GettingStarted/04-vscode/README.md)

- **5 SSE (Server Sent Events) سے کنزیوم کرنا**۔ SSE سرور سے کلائنٹ تک اسٹریمنگ کے لیے ایک معیاری طریقہ ہے، جو سرورز کو HTTP کے ذریعے کلائنٹس کو حقیقی وقت کی اپ ڈیٹس بھیجنے کی اجازت دیتا ہے، [سبق پر جائیں](/03-GettingStarted/05-sse-server/README.md)

- **6 MCP کے ساتھ HTTP اسٹریمنگ (Streamable HTTP)**۔ جدید HTTP اسٹریمنگ، پیش رفت کی اطلاعات، اور اسٹریمنبل HTTP کا استعمال کرتے ہوئے اسکیل ایبل، حقیقی وقت کے MCP سرورز اور کلائنٹس کو کیسے نافذ کیا جائے، سیکھیں۔ [سبق پر جائیں](/03-GettingStarted/06-http-streaming/README.md)

- **7 VSCode کے لیے AI Toolkit کا استعمال** تاکہ اپنے MCP کلائنٹس اور سرورز کو استعمال اور ٹیسٹ کیا جا سکے، [سبق پر جائیں](/03-GettingStarted/07-aitk/README.md)

- **8 ٹیسٹنگ**۔ یہاں ہم خاص طور پر اس بات پر توجہ دیں گے کہ ہم اپنے سرور اور کلائنٹ کو مختلف طریقوں سے کیسے ٹیسٹ کر سکتے ہیں، [سبق پر جائیں](/03-GettingStarted/08-testing/README.md)

- **9 تعیناتی**۔ یہ باب آپ کے MCP حلوں کی تعیناتی کے مختلف طریقوں پر نظر ڈالے گا، [سبق پر جائیں](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) ایک کھلا پروٹوکول ہے جو یہ معیاری بناتا ہے کہ ایپلیکیشنز LLMs کو سیاق و سباق کیسے فراہم کرتی ہیں۔ MCP کو AI ایپلیکیشنز کے لیے USB-C پورٹ سمجھیں - یہ AI ماڈلز کو مختلف ڈیٹا ذرائع اور ٹولز سے منسلک کرنے کا ایک معیاری طریقہ فراہم کرتا ہے۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ کر سکیں گے:

- C#, Java, Python, TypeScript، اور JavaScript میں MCP کے لیے ترقیاتی ماحول قائم کرنا
- کسٹم فیچرز (resources, prompts, اور tools) کے ساتھ بنیادی MCP سرورز بنانا اور تعینات کرنا
- MCP سرورز سے جڑنے والی host ایپلیکیشنز بنانا
- MCP امپلیمنٹیشنز کی ٹیسٹنگ اور ڈیبگنگ کرنا
- عام سیٹ اپ چیلنجز اور ان کے حل سمجھنا
- اپنی MCP امپلیمنٹیشنز کو مقبول LLM سروسز سے منسلک کرنا

## اپنے MCP ماحول کی ترتیب

MCP کے ساتھ کام شروع کرنے سے پہلے، اپنے ترقیاتی ماحول کو تیار کرنا اور بنیادی ورک فلو کو سمجھنا ضروری ہے۔ یہ سیکشن آپ کو ابتدائی سیٹ اپ کے مراحل سے گزاریگا تاکہ MCP کے ساتھ ایک ہموار آغاز یقینی بنایا جا سکے۔

### ضروریات

MCP کی ترقی میں غوطہ لگانے سے پہلے، یقینی بنائیں کہ آپ کے پاس ہے:

- **ترقیاتی ماحول**: اپنی منتخب زبان (C#, Java, Python, TypeScript، یا JavaScript) کے لیے
- **IDE/ایڈیٹر**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm، یا کوئی جدید کوڈ ایڈیٹر
- **پیکیج مینیجرز**: NuGet, Maven/Gradle, pip، یا npm/yarn
- **API Keys**: ان تمام AI سروسز کے لیے جنہیں آپ اپنی host ایپلیکیشنز میں استعمال کرنا چاہتے ہیں


### آفیشل SDKs

آنے والے ابواب میں آپ Python, TypeScript, Java اور .NET استعمال کرتے ہوئے حل دیکھیں گے۔ یہاں تمام سرکاری طور پر سپورٹ کیے گئے SDKs ہیں۔

MCP متعدد زبانوں کے لیے سرکاری SDKs فراہم کرتا ہے:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft کے تعاون سے برقرار رکھا گیا
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI کے تعاون سے برقرار رکھا گیا
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - سرکاری TypeScript امپلیمنٹیشن
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - سرکاری Python امپلیمنٹیشن
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - سرکاری Kotlin امپلیمنٹیشن
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI کے تعاون سے برقرار رکھا گیا
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - سرکاری Rust امپلیمنٹیشن

## اہم نکات

- MCP ترقیاتی ماحول کی ترتیب زبان مخصوص SDKs کے ساتھ آسان ہے
- MCP سرورز بنانے میں واضح schemas کے ساتھ tools بنانا اور رجسٹر کرنا شامل ہے
- MCP کلائنٹس سرورز اور ماڈلز سے جڑ کر توسیع شدہ صلاحیتیں حاصل کرتے ہیں
- ٹیسٹنگ اور ڈیبگنگ MCP امپلیمنٹیشنز کی قابل اعتمادیت کے لیے ضروری ہیں
- تعیناتی کے اختیارات مقامی ترقی سے کلاؤڈ بیسڈ حلوں تک پھیلے ہوئے ہیں

## مشق کرنا

ہمارے پاس نمونے کا ایک مجموعہ ہے جو اس سیکشن کے تمام ابواب میں آپ کو نظر آنے والی مشقوں کی تکمیل کرتا ہے۔ اس کے علاوہ ہر باب کے اپنے مشقیں اور اسائنمنٹس بھی ہیں۔

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## اضافی وسائل

- [Azure پر Model Context Protocol استعمال کرتے ہوئے ایجنٹس بنائیں](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps کے ساتھ Remote MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## آگے کیا ہے

اگلا: [اپنا پہلا MCP سرور بنانا](/03-GettingStarted/01-first-server/README.md)

**دستخطی:**
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم صحت ہو سکتی ہے۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ تجویز کیا جاتا ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تعبیر کی ذمہ داری ہم پر نہیں ہوگی۔