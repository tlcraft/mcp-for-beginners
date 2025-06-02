<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:02:12+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ur"
}
-->
### -2- پراجیکٹ بنائیں

اب جب کہ آپ نے اپنا SDK انسٹال کر لیا ہے، آئیں اگلا قدم یعنی پراجیکٹ بنائیں:

### -3- پراجیکٹ فائلیں بنائیں

### -4- سرور کا کوڈ لکھیں

### -5- ایک ٹول اور ایک ریسورس شامل کریں

مندرجہ ذیل کوڈ شامل کرکے ایک ٹول اور ایک ریسورس شامل کریں:

### -6- آخری کوڈ

آئیے وہ آخری کوڈ شامل کریں جس کی ضرورت ہے تاکہ سرور شروع ہو سکے:

### -7- سرور کی جانچ کریں

سرور شروع کرنے کے لیے درج ذیل کمانڈ چلائیں:

### -8- انسپیکٹر کے ذریعے چلائیں

انسپیکٹر ایک بہترین ٹول ہے جو آپ کے سرور کو شروع کرتا ہے اور آپ کو اس کے ساتھ بات چیت کرنے دیتا ہے تاکہ آپ اس کی فعالیت کی جانچ کر سکیں۔ آئیے اسے شروع کریں:

> [!NOTE]
> "کمانڈ" فیلڈ میں یہ مختلف نظر آ سکتا ہے کیونکہ اس میں آپ کے مخصوص رن ٹائم کے ساتھ سرور چلانے کی کمانڈ شامل ہوتی ہے۔

آپ کو درج ذیل یوزر انٹرفیس نظر آئے گا:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ur.png)

1. کنیکٹ بٹن کو منتخب کرکے سرور سے جڑیں  
   جب آپ سرور سے جڑ جائیں گے، تو آپ کو یہ نظر آئے گا:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ur.png)

2. "Tools" اور "listTools" کو منتخب کریں، آپ کو "Add" نظر آئے گا، "Add" کو منتخب کریں اور پیرامیٹر کی قدریں بھر دیں۔

   آپ کو درج ذیل جواب نظر آئے گا، یعنی "add" ٹول کا نتیجہ:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ur.png)

مبارک ہو، آپ نے اپنا پہلا سرور کامیابی سے بنایا اور چلایا ہے!

### آفیشل SDKs

MCP کئی زبانوں کے لیے آفیشل SDKs فراہم کرتا ہے:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - مائیکروسافٹ کے تعاون سے  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI کے تعاون سے  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - آفیشل TypeScript امپلیمینٹیشن  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - آفیشل Python امپلیمینٹیشن  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - آفیشل Kotlin امپلیمینٹیشن  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI کے تعاون سے  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - آفیشل Rust امپلیمینٹیشن  

## اہم نکات

- MCP کے لیے ڈویلپمنٹ ماحول قائم کرنا زبان مخصوص SDKs کی بدولت آسان ہے  
- MCP سرور بنانے میں واضح اسکیمز کے ساتھ ٹولز بنانا اور رجسٹر کرنا شامل ہے  
- جانچ اور ڈیبگنگ MCP امپلیمینٹیشنز کے لیے ضروری ہیں  

## نمونے

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## مشق

اپنی پسند کے ٹول کے ساتھ ایک سادہ MCP سرور بنائیں:  
1. اپنی پسندیدہ زبان (.NET، Java، Python، یا JavaScript) میں ٹول کو امپلیمینٹ کریں۔  
2. ان پٹ پیرامیٹرز اور ریٹرن ویلیوز کی تعریف کریں۔  
3. انسپیکٹر ٹول چلائیں تاکہ سرور کی کارکردگی کی تصدیق ہو سکے۔  
4. مختلف ان پٹس کے ساتھ امپلیمینٹیشن کی جانچ کریں۔  

## حل

[حل](./solution/README.md)

## اضافی وسائل

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## اگلا مرحلہ

اگلا: [MCP کلائنٹس کے ساتھ شروعات](/03-GettingStarted/02-client/README.md)

**دسclaimer**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ورانہ انسانی ترجمہ تجویز کیا جاتا ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔