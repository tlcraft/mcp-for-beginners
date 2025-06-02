<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:19:26+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ur"
}
-->
## شروعات  

یہ سیکشن کئی اسباق پر مشتمل ہے:

- **-1- آپ کا پہلا سرور**، اس پہلے سبق میں، آپ سیکھیں گے کہ اپنا پہلا سرور کیسے بنائیں اور اسے inspector tool سے جانچیں، جو آپ کے سرور کی جانچ اور ڈیبگنگ کا ایک قیمتی طریقہ ہے، [سبق پر جائیں](/03-GettingStarted/01-first-server/README.md)

- **-2- کلائنٹ**، اس سبق میں، آپ سیکھیں گے کہ ایک ایسا کلائنٹ کیسے لکھیں جو آپ کے سرور سے جڑ سکے، [سبق پر جائیں](/03-GettingStarted/02-client/README.md)

- **-3- LLM کے ساتھ کلائنٹ**، کلائنٹ لکھنے کا ایک بہتر طریقہ یہ ہے کہ اس میں LLM شامل کریں تاکہ یہ آپ کے سرور سے "مذاکرات" کر سکے کہ کیا کرنا ہے، [سبق پر جائیں](/03-GettingStarted/03-llm-client/README.md)

- **-4- Visual Studio Code میں سرور GitHub Copilot ایجنٹ موڈ کا استعمال**۔ یہاں، ہم Visual Studio Code کے اندر سے اپنے MCP Server کو چلانے پر غور کر رہے ہیں، [سبق پر جائیں](/03-GettingStarted/04-vscode/README.md)

- **-5- SSE (Server Sent Events) سے استعمال**۔ SSE سرور سے کلائنٹ تک سٹریمنگ کا ایک معیار ہے، جو سرورز کو HTTP کے ذریعے کلائنٹس کو حقیقی وقت کی اپڈیٹس بھیجنے کی اجازت دیتا ہے، [سبق پر جائیں](/03-GettingStarted/05-sse-server/README.md)

- **-6- VSCode کے لیے AI Toolkit کا استعمال** تاکہ آپ اپنے MCP کلائنٹس اور سرورز کو استعمال اور ٹیسٹ کر سکیں، [سبق پر جائیں](/03-GettingStarted/06-aitk/README.md)

- **-7- ٹیسٹنگ**۔ یہاں ہم خاص طور پر اس بات پر توجہ دیں گے کہ ہم اپنے سرور اور کلائنٹ کو مختلف طریقوں سے کیسے ٹیسٹ کر سکتے ہیں، [سبق پر جائیں](/03-GettingStarted/07-testing/README.md)

- **-8- تعیناتی**۔ یہ باب آپ کے MCP حلوں کی تعیناتی کے مختلف طریقوں پر نظر ڈالے گا، [سبق پر جائیں](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) ایک کھلا پروٹوکول ہے جو یہ معیاری بناتا ہے کہ ایپلیکیشنز LLMs کو سیاق و سباق کیسے فراہم کرتی ہیں۔ MCP کو AI ایپلیکیشنز کے لیے USB-C پورٹ سمجھیں - یہ AI ماڈلز کو مختلف ڈیٹا ذرائع اور ٹولز سے منسلک کرنے کا ایک معیاری طریقہ فراہم کرتا ہے۔

## سیکھنے کے مقاصد

اس سبق کے آخر تک، آپ قابل ہوں گے کہ:

- C#, Java, Python, TypeScript، اور JavaScript میں MCP کے لیے ترقیاتی ماحول قائم کریں
- بنیادی MCP سرورز بنائیں اور تعینات کریں جن میں اپنی مرضی کی خصوصیات (resources, prompts, اور tools) ہوں
- میزبان ایپلیکیشنز تخلیق کریں جو MCP سرورز سے جڑتی ہوں
- MCP کی تنصیبات کو ٹیسٹ اور ڈیبگ کریں
- عام سیٹ اپ کے مسائل اور ان کے حل کو سمجھیں
- اپنے MCP نفاذ کو مقبول LLM خدمات سے منسلک کریں

## اپنے MCP ماحول کی ترتیب

MCP پر کام شروع کرنے سے پہلے، ضروری ہے کہ آپ اپنا ترقیاتی ماحول تیار کریں اور بنیادی ورک فلو کو سمجھیں۔ یہ سیکشن آپ کو ابتدائی سیٹ اپ کے مراحل میں رہنمائی کرے گا تاکہ MCP کے ساتھ ایک آسان آغاز ہو۔

### ضروریات

MCP کی ترقی میں غوطہ لگانے سے پہلے، یقینی بنائیں کہ آپ کے پاس موجود ہے:

- **ترقیاتی ماحول**: آپ کی منتخب زبان کے لیے (C#, Java, Python, TypeScript، یا JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm، یا کوئی جدید کوڈ ایڈیٹر
- **پیکیج مینیجرز**: NuGet, Maven/Gradle, pip، یا npm/yarn
- **API Keys**: ان تمام AI خدمات کے لیے جو آپ اپنے میزبان ایپلیکیشنز میں استعمال کرنے کا ارادہ رکھتے ہیں


### سرکاری SDKs

اگلے ابواب میں آپ Python, TypeScript, Java اور .NET استعمال کرتے ہوئے بنائے گئے حل دیکھیں گے۔ یہاں تمام سرکاری طور پر سپورٹ شدہ SDKs موجود ہیں۔

MCP متعدد زبانوں کے لیے سرکاری SDKs فراہم کرتا ہے:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft کے تعاون سے برقرار رکھا گیا
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI کے تعاون سے برقرار رکھا گیا
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - سرکاری TypeScript نفاذ
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - سرکاری Python نفاذ
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - سرکاری Kotlin نفاذ
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI کے تعاون سے برقرار رکھا گیا
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - سرکاری Rust نفاذ

## اہم نکات

- MCP ترقیاتی ماحول کا قیام زبان مخصوص SDKs کے ساتھ آسان ہے
- MCP سرورز کی تعمیر میں واضح اسکیموں کے ساتھ ٹولز بنانا اور رجسٹر کرنا شامل ہے
- MCP کلائنٹس سرورز اور ماڈلز سے جڑتے ہیں تاکہ وسیع صلاحیتوں کا فائدہ اٹھا سکیں
- ٹیسٹنگ اور ڈیبگنگ MCP نفاذ کے لیے ضروری ہیں
- تعیناتی کے اختیارات مقامی ترقی سے کلاؤڈ بیسڈ حل تک مختلف ہوتے ہیں

## مشق

ہمارے پاس نمونے کا ایک مجموعہ ہے جو اس سیکشن کے تمام ابواب میں دیکھنے والی مشقوں کی تکمیل کرتا ہے۔ اس کے علاوہ، ہر باب میں اپنی مشقیں اور اسائنمنٹس بھی شامل ہیں۔

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## اضافی وسائل

- [Azure پر Model Context Protocol کا استعمال کرتے ہوئے ایجنٹس بنائیں](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps کے ساتھ Remote MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## اگلا کیا ہے

اگلا: [اپنا پہلا MCP Server بنانا](/03-GettingStarted/01-first-server/README.md)

**دستخطی وضاحت**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجموں میں غلطیاں یا غیر درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں مستند ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمہ کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔