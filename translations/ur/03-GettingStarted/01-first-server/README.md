<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "37563349cd6894fe00489bf3b4d488ae",
  "translation_date": "2025-06-02T10:27:38+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ur"
}
-->
### -2- پروجیکٹ بنائیں

اب جب کہ آپ نے SDK انسٹال کر لیا ہے، تو آئیے اگلا قدم پروجیکٹ بنانے کا ہے:

### -3- پروجیکٹ فائلیں بنائیں

### -4- سرور کوڈ بنائیں

### -5- ایک ٹول اور ریسورس شامل کرنا

مندرجہ ذیل کوڈ شامل کر کے ایک ٹول اور ریسورس شامل کریں:

### -6- حتمی کوڈ

آئیے وہ آخری کوڈ شامل کریں جس کی ضرورت ہے تاکہ سرور شروع ہو سکے:

### -7- سرور کی جانچ کریں

مندرجہ ذیل کمانڈ کے ذریعے سرور شروع کریں:

### -8- انسپیکٹر کے ذریعے چلائیں

انسپیکٹر ایک بہترین ٹول ہے جو آپ کے سرور کو شروع کر سکتا ہے اور آپ کو اس کے ساتھ بات چیت کرنے دیتا ہے تاکہ آپ اس کی کارکردگی کی جانچ کر سکیں۔ آئیے اسے شروع کریں:

> [!NOTE]
> "command" فیلڈ میں یہ مختلف نظر آ سکتا ہے کیونکہ اس میں آپ کے مخصوص رن ٹائم کے لیے سرور چلانے کی کمانڈ شامل ہوتی ہے۔

آپ کو درج ذیل یوزر انٹرفیس نظر آئے گا:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ur.png)

1. Connect بٹن منتخب کر کے سرور سے جڑیں  
   جب آپ سرور سے جڑ جائیں گے، تو آپ کو درج ذیل نظر آئے گا:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ur.png)

2. "Tools" اور "listTools" منتخب کریں، آپ کو "Add" نظر آئے گا، "Add" منتخب کریں اور پیرامیٹر کی قدریں درج کریں۔

   آپ کو درج ذیل جواب ملے گا، یعنی "add" ٹول کا نتیجہ:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ur.png)

مبارک ہو، آپ نے اپنا پہلا سرور کامیابی سے بنایا اور چلایا ہے!

### سرکاری SDKs

MCP مختلف زبانوں کے لیے سرکاری SDKs فراہم کرتا ہے:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - مائیکروسافٹ کے تعاون سے مینٹینڈ
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI کے تعاون سے مینٹینڈ
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - سرکاری TypeScript ایمپلیمنٹیشن
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - سرکاری Python ایمپلیمنٹیشن
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - سرکاری Kotlin ایمپلیمنٹیشن
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI کے تعاون سے مینٹینڈ
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - سرکاری Rust ایمپلیمنٹیشن

## اہم نکات

- MCP کے لیے ڈیولپمنٹ ماحول ترتیب دینا زبان کے مخصوص SDKs کے ساتھ آسان ہے
- MCP سرورز بنانے کے لیے واضح schemas کے ساتھ ٹولز بنانا اور رجسٹر کرنا ضروری ہے
- جانچ اور ڈیبگنگ MCP ایمپلیمنٹیشنز کے لیے ناگزیر ہیں

## نمونے

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## اسائنمنٹ

اپنی پسند کا ایک سادہ MCP سرور بنائیں:
1. اپنے پسندیدہ زبان میں ٹول کو ایمپلیمنٹ کریں (.NET، Java، Python، یا JavaScript)۔
2. ان پٹ پیرامیٹرز اور ریٹرن ویلیوز کی تعریف کریں۔
3. انسپیکٹر ٹول چلائیں تاکہ سرور صحیح کام کر رہا ہو۔
4. مختلف ان پٹ کے ساتھ ایمپلیمنٹیشن کی جانچ کریں۔

## حل

[Solution](./solution/README.md)

## اضافی وسائل

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## آگے کیا ہے

اگلا: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**ڈسکلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کی کوشش کرتے ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا نقائص ہو سکتے ہیں۔ اصل دستاویز اپنی مادری زبان میں مستند ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ورانہ انسانی ترجمہ تجویز کیا جاتا ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تعبیر کی ذمہ داری ہم پر نہیں ہوگی۔