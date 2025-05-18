<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:05:40+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ur"
}
-->
## شروع کرنا

یہ حصہ کئی اسباق پر مشتمل ہے:

- **-1- آپ کا پہلا سرور**، اس پہلے سبق میں، آپ سیکھیں گے کہ اپنا پہلا سرور کیسے بنائیں اور انسپکٹر ٹول کے ساتھ اس کا معائنہ کریں، جو آپ کے سرور کو جانچنے اور ڈیبگ کرنے کا قیمتی طریقہ ہے، [سبق کی طرف](/03-GettingStarted/01-first-server/README.md)

- **-2- کلائنٹ**، اس سبق میں، آپ سیکھیں گے کہ ایسا کلائنٹ کیسے لکھا جائے جو آپ کے سرور سے جڑ سکے، [سبق کی طرف](/03-GettingStarted/02-client/README.md)

- **-3- LLM کے ساتھ کلائنٹ**، کلائنٹ لکھنے کا ایک اور بہتر طریقہ یہ ہے کہ اس میں LLM شامل کیا جائے تاکہ وہ آپ کے سرور کے ساتھ "بات چیت" کر سکے کہ کیا کرنا ہے، [سبق کی طرف](/03-GettingStarted/03-llm-client/README.md)

- **-4- Visual Studio Code میں GitHub Copilot Agent mode کے ساتھ سرور کا استعمال**۔ یہاں، ہم Visual Studio Code کے اندر سے اپنے MCP سرور کو چلانے پر غور کر رہے ہیں، [سبق کی طرف](/03-GettingStarted/04-vscode/README.md)

- **-5- SSE (Server Sent Events) سے استعمال** SEE ایک معیار ہے جو سرور سے کلائنٹ تک سٹریمنگ کے لیے ہے، جس سے سرورز کو HTTP پر کلائنٹس کو حقیقی وقت کی اپ ڈیٹس بھیجنے کی اجازت ملتی ہے [سبق کی طرف](/03-GettingStarted/05-sse-server/README.md)

- **-6- VSCode کے لیے AI Toolkit کا استعمال** اپنے MCP کلائنٹس اور سرورز کو استعمال کرنے اور جانچنے کے لیے [سبق کی طرف](/03-GettingStarted/06-aitk/README.md)

- **-7 جانچ**۔ یہاں ہم خاص طور پر اس پر توجہ دیں گے کہ ہم اپنے سرور اور کلائنٹ کو مختلف طریقوں سے کیسے جانچ سکتے ہیں، [سبق کی طرف](/03-GettingStarted/07-testing/README.md)

- **-8- تعیناتی**۔ یہ باب آپ کے MCP حل کو تعینات کرنے کے مختلف طریقوں پر نظر ڈالے گا، [سبق کی طرف](/03-GettingStarted/08-deployment/README.md)

ماڈل کانٹیکسٹ پروٹوکول (MCP) ایک کھلا پروٹوکول ہے جو اس بات کو معیاری بناتا ہے کہ ایپلیکیشنز LLMs کو کس طرح سیاق و سباق فراہم کرتی ہیں۔ MCP کو AI ایپلیکیشنز کے لیے USB-C پورٹ کی طرح سمجھیں - یہ AI ماڈلز کو مختلف ڈیٹا سورسز اور ٹولز سے منسلک کرنے کا ایک معیاری طریقہ فراہم کرتا ہے۔

## سیکھنے کے مقاصد

اس سبق کے اختتام پر، آپ قابل ہوں گے:

- C#, Java, Python, TypeScript, اور JavaScript میں MCP کے لیے ترقیاتی ماحول ترتیب دیں
- بنیادی MCP سرورز کو کسٹم خصوصیات (وسائل، پرامپٹس، اور ٹولز) کے ساتھ بنائیں اور تعینات کریں
- میزبان ایپلیکیشنز بنائیں جو MCP سرورز سے جڑتی ہیں
- MCP کے نفاذ کو جانچیں اور ڈیبگ کریں
- عام سیٹ اپ چیلنجز اور ان کے حل کو سمجھیں
- اپنی MCP کے نفاذ کو مشہور LLM خدمات سے جوڑیں

## اپنے MCP ماحول کو ترتیب دینا

MCP کے ساتھ کام شروع کرنے سے پہلے، یہ ضروری ہے کہ آپ اپنے ترقیاتی ماحول کو تیار کریں اور بنیادی ورک فلو کو سمجھیں۔ یہ سیکشن آپ کو MCP کے ساتھ ایک ہموار آغاز کے لیے ابتدائی سیٹ اپ کے مراحل سے رہنمائی کرے گا۔

### ضروریات

MCP کی ترقی میں غوطہ لگانے سے پہلے، یقینی بنائیں کہ آپ کے پاس:

- **ترقیاتی ماحول**: آپ کی منتخب کردہ زبان (C#, Java, Python, TypeScript, یا JavaScript) کے لیے
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm، یا کوئی بھی جدید کوڈ ایڈیٹر
- **پیکج مینیجرز**: NuGet, Maven/Gradle, pip, یا npm/yarn
- **API کیز**: کسی بھی AI خدمات کے لیے جو آپ اپنی میزبان ایپلیکیشنز میں استعمال کرنے کا ارادہ رکھتے ہیں

### آفیشل SDKs

آنے والے ابواب میں آپ Python, TypeScript, Java اور .NET استعمال کرتے ہوئے حل دیکھیں گے۔ یہاں تمام آفیشل سپورٹڈ SDKs ہیں۔

MCP متعدد زبانوں کے لیے آفیشل SDKs فراہم کرتا ہے:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft کے ساتھ تعاون میں برقرار رکھا گیا
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI کے ساتھ تعاون میں برقرار رکھا گیا
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - آفیشل TypeScript نفاذ
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - آفیشل Python نفاذ
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - آفیشل Kotlin نفاذ
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI کے ساتھ تعاون میں برقرار رکھا گیا
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - آفیشل Rust نفاذ

## اہم نکات

- زبان کے مخصوص SDKs کے ساتھ MCP ترقیاتی ماحول کو ترتیب دینا آسان ہے
- MCP سرورز بنانے میں واضح اسکیموں کے ساتھ ٹولز بنانا اور رجسٹر کرنا شامل ہے
- MCP کلائنٹس سرورز اور ماڈلز سے جڑتے ہیں تاکہ وسیع صلاحیتوں کا فائدہ اٹھایا جا سکے
- قابل اعتماد MCP نفاذ کے لیے جانچ اور ڈیبگنگ ضروری ہیں
- تعیناتی کے اختیارات مقامی ترقی سے کلاؤڈ پر مبنی حل تک مختلف ہیں

## مشق کرنا

ہمارے پاس نمونوں کا ایک مجموعہ ہے جو اس سیکشن کے تمام ابواب میں آپ کو نظر آنے والی مشقوں کی تکمیل کرتا ہے۔ اس کے علاوہ ہر باب میں اپنی مشقیں اور اسائنمنٹس بھی ہیں

- [Java کیلکولیٹر](./samples/java/calculator/README.md)
- [.Net کیلکولیٹر](../../../03-GettingStarted/samples/csharp)
- [JavaScript کیلکولیٹر](./samples/javascript/README.md)
- [TypeScript کیلکولیٹر](./samples/typescript/README.md)
- [Python کیلکولیٹر](../../../03-GettingStarted/samples/python)

## اضافی وسائل

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## اگلا کیا ہے

اگلا: [اپنا پہلا MCP سرور بنانا](/03-GettingStarted/01-first-server/README.md)

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ ہم درستگی کے لیے کوشش کرتے ہیں، لیکن براہ کرم آگاہ رہیں کہ خودکار تراجم میں غلطیاں یا نادرستیاں ہو سکتی ہیں۔ اصل دستاویز کو اس کی مقامی زبان میں معتبر ذریعہ سمجھا جانا چاہیے۔ اہم معلومات کے لیے، پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔