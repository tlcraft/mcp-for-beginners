<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T16:54:10+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ur"
}
-->
### -2- پروجیکٹ بنائیں

اب جب کہ آپ نے اپنا SDK انسٹال کر لیا ہے، تو آئیں اگلا قدم یعنی پروجیکٹ بنائیں:

### -3- پروجیکٹ فائلیں بنائیں

### -4- سرور کا کوڈ لکھیں

### -5- ایک ٹول اور ایک ریسورس شامل کرنا

مندرجہ ذیل کوڈ شامل کر کے ایک ٹول اور ایک ریسورس شامل کریں:

### -6- آخری کوڈ

آئیے وہ آخری کوڈ شامل کریں جس کی ضرورت ہے تاکہ سرور شروع ہو سکے:

### -7- سرور کا ٹیسٹ کریں

مندرجہ ذیل کمانڈ سے سرور شروع کریں:

### -8- انسپکٹر کے ذریعے چلائیں

انسپکٹر ایک بہترین ٹول ہے جو آپ کے سرور کو شروع کرتا ہے اور آپ کو اس کے ساتھ تعامل کرنے دیتا ہے تاکہ آپ جانچ سکیں کہ یہ کام کر رہا ہے۔ آئیے اسے شروع کرتے ہیں:

> [!NOTE]
> یہ "کمانڈ" فیلڈ میں مختلف نظر آ سکتا ہے کیونکہ اس میں آپ کے مخصوص رن ٹائم کے ساتھ سرور چلانے کی کمانڈ شامل ہوتی ہے۔

آپ کو درج ذیل یوزر انٹرفیس نظر آئے گا:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ur.png)

1. Connect بٹن کو منتخب کر کے سرور سے جڑیں  
  جب آپ سرور سے جڑ جائیں گے تو آپ کو درج ذیل نظر آئے گا:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ur.png)

1. "Tools" اور "listTools" کو منتخب کریں، آپ کو "Add" نظر آئے گا، "Add" کو منتخب کریں اور پیرامیٹر ویلیوز بھریں۔

  آپ کو درج ذیل جواب نظر آئے گا، یعنی "add" ٹول سے نتیجہ:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ur.png)

مبارک ہو، آپ نے اپنا پہلا سرور کامیابی سے بنایا اور چلایا ہے!

### Official SDKs

MCP متعدد زبانوں کے لیے آفیشل SDKs فراہم کرتا ہے:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft کے ساتھ تعاون میں تیار  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI کے ساتھ تعاون میں تیار  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - آفیشل TypeScript امپلیمنٹیشن  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - آفیشل Python امپلیمنٹیشن  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - آفیشل Kotlin امپلیمنٹیشن  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI کے ساتھ تعاون میں تیار  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - آفیشل Rust امپلیمنٹیشن  

## کلیدی نکات

- MCP ڈیولپمنٹ ماحول قائم کرنا زبان کے مطابق SDKs کے ساتھ آسان ہے  
- MCP سرورز بنانے میں واضح schemas کے ساتھ ٹولز تخلیق اور رجسٹر کرنا شامل ہے  
- ٹیسٹنگ اور ڈیبگنگ MCP امپلیمنٹیشنز کی قابل اعتمادیت کے لیے ضروری ہیں  

## نمونے

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## اسائنمنٹ

اپنی پسند کا ایک سادہ MCP سرور بنائیں:  
1. اپنی پسندیدہ زبان میں ٹول امپلیمنٹ کریں (.NET, Java, Python, یا JavaScript)  
2. ان پٹ پیرامیٹرز اور ریٹرن ویلیوز کی تعریف کریں  
3. انسپکٹر ٹول چلائیں تاکہ سرور درست کام کر رہا ہو  
4. مختلف ان پٹس کے ساتھ امپلیمنٹیشن کو ٹیسٹ کریں  

## حل

[Solution](./solution/README.md)

## اضافی وسائل

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## اگلا کیا ہے

اگلا: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں معتبر ذریعہ سمجھا جانا چاہیے۔ اہم معلومات کے لیے پیشہ ورانہ انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔