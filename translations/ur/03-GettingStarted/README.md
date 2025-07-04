<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "97f1c99b5b12cf03d4b1be68b3636a4a",
  "translation_date": "2025-07-04T15:50:13+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ur"
}
-->
## شروعات  

یہ سیکشن کئی اسباق پر مشتمل ہے:

- **1 آپ کا پہلا سرور**، اس پہلے سبق میں، آپ سیکھیں گے کہ اپنا پہلا سرور کیسے بنائیں اور اسے inspector ٹول کے ذریعے جانچیں، جو آپ کے سرور کو ٹیسٹ اور ڈیبگ کرنے کا ایک قیمتی طریقہ ہے، [سبق پر جائیں](/03-GettingStarted/01-first-server/README.md)

- **2 کلائنٹ**، اس سبق میں، آپ سیکھیں گے کہ ایک ایسا کلائنٹ کیسے لکھا جائے جو آپ کے سرور سے جڑ سکے، [سبق پر جائیں](/03-GettingStarted/02-client/README.md)

- **3 LLM کے ساتھ کلائنٹ**، کلائنٹ لکھنے کا ایک بہتر طریقہ یہ ہے کہ اس میں LLM شامل کیا جائے تاکہ یہ آپ کے سرور کے ساتھ "مذاکرات" کر سکے کہ کیا کرنا ہے، [سبق پر جائیں](/03-GettingStarted/03-llm-client/README.md)

- **4 Visual Studio Code میں GitHub Copilot Agent موڈ کے ذریعے سرور کا استعمال**۔ یہاں، ہم Visual Studio Code کے اندر سے اپنے MCP سرور کو چلانے پر غور کر رہے ہیں، [سبق پر جائیں](/03-GettingStarted/04-vscode/README.md)

- **5 SSE (Server Sent Events) سے کنزیوم کرنا**۔ SSE سرور سے کلائنٹ تک اسٹریمنگ کا ایک معیار ہے، جو سرورز کو HTTP کے ذریعے کلائنٹس کو حقیقی وقت کی اپ ڈیٹس بھیجنے کی اجازت دیتا ہے، [سبق پر جائیں](/03-GettingStarted/05-sse-server/README.md)

- **6 MCP کے ساتھ HTTP اسٹریمنگ (Streamable HTTP)**۔ جدید HTTP اسٹریمنگ، پیش رفت کی اطلاعات، اور اسٹریمیبل HTTP کا استعمال کرتے ہوئے اسکیل ایبل، حقیقی وقت کے MCP سرورز اور کلائنٹس کو کیسے نافذ کیا جائے، سیکھیں۔ [سبق پر جائیں](/03-GettingStarted/06-http-streaming/README.md)

- **7 VSCode کے لیے AI Toolkit کا استعمال** تاکہ آپ اپنے MCP کلائنٹس اور سرورز کو کنزیوم اور ٹیسٹ کر سکیں، [سبق پر جائیں](/03-GettingStarted/07-aitk/README.md)

- **8 ٹیسٹنگ**۔ یہاں ہم خاص طور پر اس بات پر توجہ دیں گے کہ ہم اپنے سرور اور کلائنٹ کو مختلف طریقوں سے کیسے ٹیسٹ کر سکتے ہیں، [سبق پر جائیں](/03-GettingStarted/08-testing/README.md)

- **9 تعیناتی**۔ یہ باب آپ کے MCP حل کو تعینات کرنے کے مختلف طریقوں پر نظر ڈالے گا، [سبق پر جائیں](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) ایک کھلا پروٹوکول ہے جو اس بات کو معیاری بناتا ہے کہ ایپلیکیشنز LLMs کو کس طرح کانٹیکسٹ فراہم کرتی ہیں۔ MCP کو AI ایپلیکیشنز کے لیے USB-C پورٹ سمجھیں - یہ AI ماڈلز کو مختلف ڈیٹا ذرائع اور ٹولز سے منسلک کرنے کا ایک معیاری طریقہ فراہم کرتا ہے۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ قابل ہوں گے کہ:

- C#, Java, Python, TypeScript، اور JavaScript میں MCP کے لیے ترقیاتی ماحول قائم کریں
- بنیادی MCP سرورز بنائیں اور تعینات کریں جن میں حسب ضرورت خصوصیات (resources, prompts, اور tools) شامل ہوں
- میزبان ایپلیکیشنز بنائیں جو MCP سرورز سے جڑتی ہوں
- MCP کی تنصیبات کو ٹیسٹ اور ڈیبگ کریں
- عام سیٹ اپ کے چیلنجز اور ان کے حل کو سمجھیں
- اپنے MCP نفاذ کو مقبول LLM خدمات سے منسلک کریں

## اپنے MCP ماحول کی تیاری

MCP کے ساتھ کام شروع کرنے سے پہلے، اپنے ترقیاتی ماحول کو تیار کرنا اور بنیادی ورک فلو کو سمجھنا ضروری ہے۔ یہ سیکشن آپ کو ابتدائی سیٹ اپ کے مراحل سے گزاریگا تاکہ MCP کے ساتھ آسان آغاز ہو۔

### ضروریات

MCP کی ترقی میں غوطہ لگانے سے پہلے، یقینی بنائیں کہ آپ کے پاس ہے:

- **ترقیاتی ماحول**: اپنی منتخب زبان (C#, Java, Python, TypeScript، یا JavaScript) کے لیے
- **IDE/ایڈیٹر**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm، یا کوئی جدید کوڈ ایڈیٹر
- **پیکیج مینیجرز**: NuGet, Maven/Gradle, pip، یا npm/yarn
- **API Keys**: کسی بھی AI سروسز کے لیے جو آپ اپنی میزبان ایپلیکیشنز میں استعمال کرنے کا ارادہ رکھتے ہیں


### سرکاری SDKs

آنے والے ابواب میں آپ Python, TypeScript, Java اور .NET استعمال کرتے ہوئے بنائی گئی حل دیکھیں گے۔ یہاں تمام سرکاری طور پر سپورٹ شدہ SDKs دیے گئے ہیں۔

MCP متعدد زبانوں کے لیے سرکاری SDKs فراہم کرتا ہے:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft کے تعاون سے برقرار رکھا گیا
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI کے تعاون سے برقرار رکھا گیا
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - سرکاری TypeScript نفاذ
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - سرکاری Python نفاذ
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - سرکاری Kotlin نفاذ
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI کے تعاون سے برقرار رکھا گیا
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - سرکاری Rust نفاذ

## اہم نکات

- MCP ترقیاتی ماحول قائم کرنا زبان مخصوص SDKs کے ساتھ آسان ہے
- MCP سرورز بنانے میں واضح schemas کے ساتھ ٹولز بنانا اور رجسٹر کرنا شامل ہے
- MCP کلائنٹس سرورز اور ماڈلز سے جڑ کر اضافی صلاحیتیں حاصل کرتے ہیں
- ٹیسٹنگ اور ڈیبگنگ قابل اعتماد MCP نفاذ کے لیے ضروری ہیں
- تعیناتی کے اختیارات مقامی ترقی سے لے کر کلاؤڈ پر مبنی حل تک ہوتے ہیں

## مشق

ہمارے پاس نمونے کا ایک مجموعہ ہے جو اس سیکشن کے تمام ابواب میں آپ کو ملنے والی مشقوں کی تکمیل کرتا ہے۔ اس کے علاوہ ہر باب کی اپنی مشقیں اور اسائنمنٹس بھی ہیں۔

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

اگلا: [اپنا پہلا MCP سرور بنانا](./01-first-server/README.md)

**دستخطی نوٹ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔