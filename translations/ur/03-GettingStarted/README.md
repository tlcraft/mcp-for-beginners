<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1197b6dbde36773e04a5ae826557fdb9",
  "translation_date": "2025-08-26T17:12:38+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ur"
}
-->
## شروع کریں  

[![اپنا پہلا MCP سرور بنائیں](../../../translated_images/04.0ea920069efd979a0b2dad51e72c1df7ead9c57b3305796068a6cee1f0dd6674.ur.png)](https://youtu.be/sNDZO9N4m9Y)

_(اوپر دی گئی تصویر پر کلک کریں تاکہ اس سبق کی ویڈیو دیکھ سکیں)_

یہ سیکشن کئی اسباق پر مشتمل ہے:

- **1 آپ کا پہلا سرور**، اس پہلے سبق میں، آپ سیکھیں گے کہ اپنا پہلا سرور کیسے بنانا ہے اور اسے انسپکٹر ٹول کے ذریعے جانچنا ہے، جو آپ کے سرور کو ٹیسٹ اور ڈیبگ کرنے کا ایک قیمتی طریقہ ہے، [سبق کے لیے جائیں](01-first-server/README.md)

- **2 کلائنٹ**، اس سبق میں، آپ سیکھیں گے کہ ایسا کلائنٹ کیسے لکھا جائے جو آپ کے سرور سے جڑ سکے، [سبق کے لیے جائیں](02-client/README.md)

- **3 LLM کے ساتھ کلائنٹ**، کلائنٹ لکھنے کا ایک اور بہتر طریقہ یہ ہے کہ اس میں LLM شامل کیا جائے تاکہ وہ آپ کے سرور کے ساتھ "بات چیت" کر سکے کہ کیا کرنا ہے، [سبق کے لیے جائیں](03-llm-client/README.md)

- **4 Visual Studio Code میں GitHub Copilot Agent موڈ کے ساتھ سرور کا استعمال**۔ یہاں، ہم Visual Studio Code کے اندر سے اپنا MCP سرور چلانے پر غور کریں گے، [سبق کے لیے جائیں](04-vscode/README.md)

- **5 stdio ٹرانسپورٹ سرور**۔ stdio ٹرانسپورٹ موجودہ وضاحت میں MCP سرور سے کلائنٹ کمیونیکیشن کے لیے تجویز کردہ معیار ہے، جو محفوظ سب پروسیس پر مبنی کمیونیکیشن فراہم کرتا ہے، [سبق کے لیے جائیں](05-stdio-server/README.md)

- **6 MCP کے ساتھ HTTP اسٹریمنگ (Streamable HTTP)**۔ جدید HTTP اسٹریمنگ، پروگریس نوٹیفکیشنز، اور Streamable HTTP کا استعمال کرتے ہوئے قابل توسیع، ریئل ٹائم MCP سرورز اور کلائنٹس کو نافذ کرنے کے بارے میں جانیں، [سبق کے لیے جائیں](06-http-streaming/README.md)

- **7 VSCode کے لیے AI ٹول کٹ کا استعمال**۔ اپنے MCP کلائنٹس اور سرورز کو استعمال اور ٹیسٹ کرنے کے لیے [سبق کے لیے جائیں](07-aitk/README.md)

- **8 ٹیسٹنگ**۔ یہاں ہم خاص طور پر اس بات پر توجہ دیں گے کہ ہم مختلف طریقوں سے اپنے سرور اور کلائنٹ کو کیسے ٹیسٹ کر سکتے ہیں، [سبق کے لیے جائیں](08-testing/README.md)

- **9 تعیناتی**۔ یہ باب آپ کے MCP حلوں کو تعینات کرنے کے مختلف طریقوں پر غور کرے گا، [سبق کے لیے جائیں](09-deployment/README.md)

Model Context Protocol (MCP) ایک اوپن پروٹوکول ہے جو اس بات کو معیاری بناتا ہے کہ ایپلیکیشنز LLMs کو کانٹیکسٹ کیسے فراہم کرتی ہیں۔ MCP کو AI ایپلیکیشنز کے لیے USB-C پورٹ کی طرح سمجھیں - یہ مختلف ڈیٹا سورسز اور ٹولز سے AI ماڈلز کو جوڑنے کا ایک معیاری طریقہ فراہم کرتا ہے۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ یہ کرنے کے قابل ہوں گے:

- C#, Java, Python, TypeScript، اور JavaScript میں MCP کے لیے ڈویلپمنٹ ماحول ترتیب دینا  
- اپنی مرضی کے فیچرز (وسائل، پرامپٹس، اور ٹولز) کے ساتھ بنیادی MCP سرورز بنانا اور تعینات کرنا  
- ایسی ہوسٹ ایپلیکیشنز بنانا جو MCP سرورز سے جڑ سکیں  
- MCP کے نفاذ کو ٹیسٹ اور ڈیبگ کرنا  
- عام سیٹ اپ چیلنجز اور ان کے حل کو سمجھنا  
- اپنی MCP تنصیبات کو مشہور LLM سروسز سے جوڑنا  

## اپنا MCP ماحول ترتیب دینا

MCP پر کام شروع کرنے سے پہلے، یہ ضروری ہے کہ آپ اپنا ڈویلپمنٹ ماحول تیار کریں اور بنیادی ورک فلو کو سمجھیں۔ یہ سیکشن آپ کو ابتدائی سیٹ اپ کے مراحل کے ذریعے رہنمائی کرے گا تاکہ MCP کے ساتھ ایک ہموار آغاز یقینی بنایا جا سکے۔

### ضروریات

MCP ڈویلپمنٹ میں جانے سے پہلے، یقینی بنائیں کہ آپ کے پاس یہ چیزیں موجود ہیں:

- **ڈویلپمنٹ ماحول**: آپ کی منتخب کردہ زبان کے لیے (C#, Java, Python, TypeScript، یا JavaScript)  
- **IDE/ایڈیٹر**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm، یا کوئی بھی جدید کوڈ ایڈیٹر  
- **پیکیج مینیجرز**: NuGet, Maven/Gradle, pip، یا npm/yarn  
- **API کیز**: ان AI سروسز کے لیے جنہیں آپ اپنی ہوسٹ ایپلیکیشنز میں استعمال کرنے کا ارادہ رکھتے ہیں  

### آفیشل SDKs

آنے والے ابواب میں آپ Python, TypeScript, Java، اور .NET کا استعمال کرتے ہوئے بنائے گئے حل دیکھیں گے۔ یہاں تمام آفیشل سپورٹڈ SDKs ہیں۔

MCP مختلف زبانوں کے لیے آفیشل SDKs فراہم کرتا ہے:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft کے ساتھ تعاون میں برقرار رکھا گیا  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI کے ساتھ تعاون میں برقرار رکھا گیا  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - آفیشل TypeScript نفاذ  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - آفیشل Python نفاذ  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - آفیشل Kotlin نفاذ  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI کے ساتھ تعاون میں برقرار رکھا گیا  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - آفیشل Rust نفاذ  

## اہم نکات

- MCP ڈویلپمنٹ ماحول ترتیب دینا زبان کے مخصوص SDKs کے ساتھ آسان ہے  
- MCP سرورز بنانا واضح اسکیموں کے ساتھ ٹولز بنانے اور رجسٹر کرنے پر مشتمل ہے  
- MCP کلائنٹس سرورز اور ماڈلز سے جڑتے ہیں تاکہ اضافی صلاحیتوں سے فائدہ اٹھا سکیں  
- قابل اعتماد MCP نفاذ کے لیے ٹیسٹنگ اور ڈیبگنگ ضروری ہیں  
- تعیناتی کے اختیارات مقامی ترقی سے لے کر کلاؤڈ پر مبنی حلوں تک ہیں  

## مشق

ہمارے پاس نمونوں کا ایک سیٹ ہے جو اس سیکشن کے تمام ابواب میں دی گئی مشقوں کی تکمیل کرتا ہے۔ اس کے علاوہ، ہر باب میں اپنی مشقیں اور اسائنمنٹس بھی شامل ہیں۔

- [Java کیلکولیٹر](./samples/java/calculator/README.md)  
- [.Net کیلکولیٹر](../../../03-GettingStarted/samples/csharp)  
- [JavaScript کیلکولیٹر](./samples/javascript/README.md)  
- [TypeScript کیلکولیٹر](./samples/typescript/README.md)  
- [Python کیلکولیٹر](../../../03-GettingStarted/samples/python)  

## اضافی وسائل

- [Azure پر Model Context Protocol کا استعمال کرتے ہوئے ایجنٹس بنائیں](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Azure Container Apps کے ساتھ ریموٹ MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP ایجنٹ](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## آگے کیا ہے

اگلا: [اپنا پہلا MCP سرور بنانا](01-first-server/README.md)  

---

**ڈسکلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ ہم درستگی کے لیے کوشش کرتے ہیں، لیکن براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا غیر درستیاں ہو سکتی ہیں۔ اصل دستاویز کو اس کی اصل زبان میں مستند ذریعہ سمجھا جانا چاہیے۔ اہم معلومات کے لیے، پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔