<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:00:51+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ur"
}
-->
## شروع کرنا

یہ سیکشن کئی اسباق پر مشتمل ہے:

- **1 آپ کا پہلا سرور**، اس پہلے سبق میں، آپ سیکھیں گے کہ اپنا پہلا سرور کیسے بنائیں اور اسے inspector ٹول سے معائنہ کریں، جو آپ کے سرور کو ٹیسٹ اور ڈیبگ کرنے کا ایک قیمتی طریقہ ہے، [سبق کے لیے](/03-GettingStarted/01-first-server/README.md)

- **2 کلائنٹ**، اس سبق میں، آپ سیکھیں گے کہ ایسا کلائنٹ کیسے لکھا جائے جو آپ کے سرور سے جڑ سکے، [سبق کے لیے](/03-GettingStarted/02-client/README.md)

- **3 LLM کے ساتھ کلائنٹ**، کلائنٹ لکھنے کا ایک بہتر طریقہ یہ ہے کہ اس میں LLM شامل کیا جائے تاکہ یہ آپ کے سرور کے ساتھ "بات چیت" کر سکے کہ کیا کرنا ہے، [سبق کے لیے](/03-GettingStarted/03-llm-client/README.md)

- **4 Visual Studio Code میں GitHub Copilot Agent موڈ کے ساتھ سرور کا استعمال**۔ یہاں ہم Visual Studio Code کے اندر سے اپنا MCP Server چلانے پر غور کر رہے ہیں، [سبق کے لیے](/03-GettingStarted/04-vscode/README.md)

- **5 SSE (Server Sent Events) سے کنزیوم کرنا**۔ SSE سرور سے کلائنٹ تک اسٹریم کرنے کا ایک معیار ہے، جو سرورز کو کلائنٹس کو حقیقی وقت کی اپ ڈیٹس HTTP کے ذریعے بھیجنے کی اجازت دیتا ہے، [سبق کے لیے](/03-GettingStarted/05-sse-server/README.md)

- **6 VSCode کے لیے AI Toolkit کا استعمال** تاکہ آپ اپنے MCP کلائنٹس اور سرورز کو استعمال اور ٹیسٹ کر سکیں، [سبق کے لیے](/03-GettingStarted/06-aitk/README.md)

- **7 ٹیسٹنگ**۔ یہاں ہم خاص طور پر اس بات پر توجہ دیں گے کہ ہم اپنے سرور اور کلائنٹ کو مختلف طریقوں سے کیسے ٹیسٹ کر سکتے ہیں، [سبق کے لیے](/03-GettingStarted/07-testing/README.md)

- **8 تعیناتی**۔ یہ باب آپ کے MCP حلوں کو تعینات کرنے کے مختلف طریقوں پر غور کرے گا، [سبق کے لیے](/03-GettingStarted/08-deployment/README.md)

Model Context Protocol (MCP) ایک کھلا پروٹوکول ہے جو اس بات کو معیاری بناتا ہے کہ ایپلیکیشنز LLMs کو سیاق و سباق کیسے فراہم کرتی ہیں۔ MCP کو AI ایپلیکیشنز کے لیے USB-C پورٹ سمجھیں - یہ AI ماڈلز کو مختلف ڈیٹا ذرائع اور ٹولز سے منسلک کرنے کا ایک معیاری طریقہ فراہم کرتا ہے۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ قابل ہوں گے:

- C#, Java, Python, TypeScript، اور JavaScript میں MCP کے لیے ترقیاتی ماحول ترتیب دینا
- کسٹم خصوصیات (resources, prompts, اور tools) کے ساتھ بنیادی MCP سرورز بنانا اور تعینات کرنا
- میزبان ایپلیکیشنز تخلیق کرنا جو MCP سرورز سے جڑتی ہوں
- MCP کے نفاذ کو ٹیسٹ اور ڈیبگ کرنا
- عام سیٹ اپ چیلنجز اور ان کے حل کو سمجھنا
- اپنے MCP نفاذ کو مقبول LLM خدمات سے جوڑنا

## اپنے MCP ماحول کی ترتیب

MCP پر کام شروع کرنے سے پہلے، یہ ضروری ہے کہ آپ اپنا ترقیاتی ماحول تیار کریں اور بنیادی ورک فلو کو سمجھیں۔ یہ سیکشن آپ کو ابتدائی سیٹ اپ کے مراحل سے گزرے گا تاکہ MCP کے ساتھ آسان آغاز یقینی بنایا جا سکے۔

### ضروریات

MCP کی ترقی میں غوطہ لگانے سے پہلے، اس بات کو یقینی بنائیں کہ آپ کے پاس ہے:

- **ترقیاتی ماحول**: آپ کی منتخب زبان کے لیے (C#, Java, Python, TypeScript، یا JavaScript)
- **IDE/ایڈیٹر**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm، یا کوئی جدید کوڈ ایڈیٹر
- **پیکیج مینیجرز**: NuGet, Maven/Gradle, pip، یا npm/yarn
- **API Keys**: کسی بھی AI خدمات کے لیے جو آپ اپنی میزبان ایپلیکیشنز میں استعمال کرنے کا ارادہ رکھتے ہیں

### سرکاری SDKs

آنے والے ابواب میں آپ Python, TypeScript, Java اور .NET استعمال کرتے ہوئے بنائے گئے حل دیکھیں گے۔ یہاں تمام سرکاری طور پر سپورٹ کیے گئے SDKs ہیں۔

MCP مختلف زبانوں کے لیے سرکاری SDKs فراہم کرتا ہے:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft کے تعاون سے برقرار رکھا گیا
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI کے تعاون سے برقرار رکھا گیا
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - سرکاری TypeScript امپلیمنٹیشن
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - سرکاری Python امپلیمنٹیشن
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - سرکاری Kotlin امپلیمنٹیشن
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI کے تعاون سے برقرار رکھا گیا
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - سرکاری Rust امپلیمنٹیشن

## اہم نکات

- MCP ترقیاتی ماحول کی ترتیب زبان مخصوص SDKs کے ساتھ آسان ہے
- MCP سرورز بنانے میں واضح schemas کے ساتھ ٹولز تخلیق اور رجسٹر کرنا شامل ہے
- MCP کلائنٹس سرورز اور ماڈلز سے جڑتے ہیں تاکہ اضافی صلاحیتوں کا فائدہ اٹھایا جا سکے
- ٹیسٹنگ اور ڈیبگنگ قابل اعتماد MCP نفاذ کے لیے ضروری ہیں
- تعیناتی کے اختیارات مقامی ترقی سے لے کر کلاؤڈ پر مبنی حل تک پھیلے ہوئے ہیں

## مشقیں

ہمارے پاس نمونوں کا ایک سیٹ ہے جو اس سیکشن کے تمام ابواب میں آپ کو دکھائے جانے والے مشقوں کی تکمیل کرتا ہے۔ اس کے علاوہ ہر باب کے اپنے مشقیں اور اسائنمنٹس بھی ہیں۔

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## اضافی وسائل

- [Azure پر Model Context Protocol کا استعمال کرتے ہوئے ایجنٹس بنائیں](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps کے ساتھ Remote MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## آگے کیا ہے

آگے: [اپنا پہلا MCP Server بنانا](/03-GettingStarted/01-first-server/README.md)

**ڈسکلیمر**:  
اس دستاویز کا ترجمہ AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے کیا گیا ہے۔ اگرچہ ہم درستگی کی کوشش کرتے ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجموں میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ذریعہ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ تجویز کیا جاتا ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر نہیں ہوگی۔