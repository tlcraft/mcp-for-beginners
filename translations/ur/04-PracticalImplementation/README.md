<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T08:39:21+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ur"
}
-->
# عملی نفاذ

عملی نفاذ وہ جگہ ہے جہاں Model Context Protocol (MCP) کی طاقت محسوس کی جا سکتی ہے۔ اگرچہ MCP کے نظریے اور فن تعمیر کو سمجھنا اہم ہے، اصل قدر اس وقت سامنے آتی ہے جب آپ ان تصورات کو استعمال کرتے ہوئے ایسے حل تیار، جانچ اور تعینات کرتے ہیں جو حقیقی دنیا کے مسائل کو حل کریں۔ یہ باب نظریاتی علم اور عملی ترقی کے درمیان پل کا کام کرتا ہے، اور آپ کو MCP پر مبنی ایپلیکیشنز کو زندہ کرنے کے عمل میں رہنمائی فراہم کرتا ہے۔

چاہے آپ ذہین معاونین تیار کر رہے ہوں، کاروباری ورک فلو میں AI کو ضم کر رہے ہوں، یا ڈیٹا پروسیسنگ کے لیے حسب ضرورت ٹولز بنا رہے ہوں، MCP ایک لچکدار بنیاد فراہم کرتا ہے۔ اس کی زبان سے آزاد ڈیزائن اور مقبول پروگرامنگ زبانوں کے لیے سرکاری SDKs اسے وسیع پیمانے پر ڈویلپرز کے لیے قابل رسائی بناتے ہیں۔ ان SDKs کا فائدہ اٹھا کر، آپ جلدی سے پروٹوٹائپ بنا سکتے ہیں، بار بار بہتری لا سکتے ہیں، اور اپنے حل کو مختلف پلیٹ فارمز اور ماحول میں اسکیل کر سکتے ہیں۔

آئندہ سیکشنز میں آپ کو عملی مثالیں، نمونہ کوڈ، اور تعیناتی کی حکمت عملی ملیں گی جو دکھاتی ہیں کہ C#, Java, TypeScript, JavaScript، اور Python میں MCP کو کیسے نافذ کیا جائے۔ آپ یہ بھی سیکھیں گے کہ MCP سرورز کو کیسے ڈیبگ اور ٹیسٹ کیا جائے، APIs کو کیسے منظم کیا جائے، اور Azure کے ذریعے کلاؤڈ پر حل کیسے تعینات کیے جائیں۔ یہ عملی وسائل آپ کی سیکھنے کی رفتار کو بڑھانے اور مضبوط، پیداوار کے لیے تیار MCP ایپلیکیشنز بنانے میں آپ کی مدد کے لیے ڈیزائن کیے گئے ہیں۔

## جائزہ

یہ سبق MCP کے عملی نفاذ کے پہلوؤں پر مختلف پروگرامنگ زبانوں میں مرکوز ہے۔ ہم دیکھیں گے کہ MCP SDKs کو C#, Java, TypeScript, JavaScript، اور Python میں کیسے استعمال کیا جائے تاکہ مضبوط ایپلیکیشنز بنائی جا سکیں، MCP سرورز کو ڈیبگ اور ٹیسٹ کیا جا سکے، اور قابلِ دوبارہ استعمال وسائل، پرامپٹس، اور ٹولز تیار کیے جا سکیں۔

## سیکھنے کے مقاصد

اس سبق کے آخر تک، آپ قابل ہوں گے:
- مختلف پروگرامنگ زبانوں میں سرکاری SDKs کا استعمال کرتے ہوئے MCP حل نافذ کرنا
- MCP سرورز کو منظم طریقے سے ڈیبگ اور ٹیسٹ کرنا
- سرور کی خصوصیات (وسائل، پرامپٹس، اور ٹولز) بنانا اور استعمال کرنا
- پیچیدہ کاموں کے لیے مؤثر MCP ورک فلو ڈیزائن کرنا
- کارکردگی اور اعتبار کے لیے MCP نفاذ کو بہتر بنانا

## سرکاری SDK وسائل

Model Context Protocol متعدد زبانوں کے لیے سرکاری SDKs پیش کرتا ہے:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDKs کے ساتھ کام کرنا

یہ سیکشن مختلف پروگرامنگ زبانوں میں MCP کے عملی نفاذ کی مثالیں فراہم کرتا ہے۔ آپ کو `samples` ڈائریکٹری میں زبان کے مطابق منظم نمونہ کوڈ ملے گا۔

### دستیاب نمونے

ریپوزٹری میں درج ذیل زبانوں میں [نمونہ نفاذ](../../../04-PracticalImplementation/samples) شامل ہیں:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

ہر نمونہ مخصوص زبان اور ماحولیاتی نظام کے لیے MCP کے کلیدی تصورات اور نفاذ کے نمونے دکھاتا ہے۔

## بنیادی سرور خصوصیات

MCP سرورز ان خصوصیات کے کسی بھی امتزاج کو نافذ کر سکتے ہیں:

### وسائل  
وسائل صارف یا AI ماڈل کے لیے سیاق و سباق اور ڈیٹا فراہم کرتے ہیں:
- دستاویزات کے ذخائر
- علم کے مراکز
- منظم ڈیٹا کے ذرائع
- فائل سسٹمز

### پرامپٹس  
پرامپٹس صارفین کے لیے ٹیمپلیٹ شدہ پیغامات اور ورک فلو ہوتے ہیں:
- پہلے سے طے شدہ گفتگو کے ٹیمپلیٹس
- رہنمائی شدہ تعامل کے نمونے
- مخصوص مکالماتی ڈھانچے

### ٹولز  
ٹولز AI ماڈل کے لیے چلانے والے فنکشنز ہوتے ہیں:
- ڈیٹا پروسیسنگ کے آلات
- بیرونی API انضمام
- حسابی صلاحیتیں
- تلاش کی فعالیت

## نمونہ نفاذ: C#

سرکاری C# SDK ریپوزٹری میں MCP کے مختلف پہلوؤں کو ظاہر کرنے والے کئی نمونہ نفاذ شامل ہیں:

- **بنیادی MCP کلائنٹ**: ایک سادہ مثال جو دکھاتی ہے کہ MCP کلائنٹ کیسے بنایا جائے اور ٹولز کو کال کیا جائے
- **بنیادی MCP سرور**: کم از کم سرور نفاذ جس میں بنیادی ٹول رجسٹریشن شامل ہے
- **جدید MCP سرور**: مکمل خصوصیات والا سرور جس میں ٹول رجسٹریشن، توثیق، اور غلطی سنبھالنا شامل ہے
- **ASP.NET انضمام**: ASP.NET Core کے ساتھ انضمام کی مثالیں
- **ٹول نفاذ کے نمونے**: مختلف پیچیدگی کی سطحوں کے ساتھ ٹولز کو نافذ کرنے کے مختلف نمونے

MCP C# SDK ابھی پیش نظارہ (preview) میں ہے اور APIs میں تبدیلیاں آ سکتی ہیں۔ ہم SDK کی ترقی کے ساتھ اس بلاگ کو مسلسل اپ ڈیٹ کرتے رہیں گے۔

### کلیدی خصوصیات  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- اپنا [پہلا MCP سرور بنائیں](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)۔

مکمل C# نفاذ کے نمونوں کے لیے، سرکاری [C# SDK نمونہ ریپوزٹری](https://github.com/modelcontextprotocol/csharp-sdk) ملاحظہ کریں۔

## نمونہ نفاذ: Java Implementation

Java SDK مضبوط MCP نفاذ کے اختیارات فراہم کرتا ہے جو انٹرپرائز گریڈ خصوصیات کے حامل ہیں۔

### کلیدی خصوصیات

- Spring Framework انضمام
- مضبوط ٹائپ سیفٹی
- Reactive programming کی حمایت
- جامع غلطی سنبھالنا

مکمل Java نفاذ کے نمونے کے لیے، samples ڈائریکٹری میں [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) دیکھیں۔

## نمونہ نفاذ: JavaScript Implementation

JavaScript SDK MCP نفاذ کے لیے ہلکا پھلکا اور لچکدار طریقہ فراہم کرتا ہے۔

### کلیدی خصوصیات

- Node.js اور براؤزر کی حمایت
- Promise-based API
- Express اور دیگر فریم ورکس کے ساتھ آسان انضمام
- WebSocket کی حمایت برائے اسٹریمنگ

مکمل JavaScript نفاذ کے نمونے کے لیے، samples ڈائریکٹری میں [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) دیکھیں۔

## نمونہ نفاذ: Python Implementation

Python SDK MCP نفاذ کے لیے Pythonic طریقہ فراہم کرتا ہے جس میں بہترین ML فریم ورک انضمام شامل ہیں۔

### کلیدی خصوصیات

- Async/await کی حمایت asyncio کے ساتھ
- Flask اور FastAPI انضمام
- آسان ٹول رجسٹریشن
- مقبول ML لائبریریز کے ساتھ مقامی انضمام

مکمل Python نفاذ کے نمونے کے لیے، samples ڈائریکٹری میں [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) دیکھیں۔

## API مینجمنٹ

Azure API Management ایک بہترین حل ہے کہ ہم MCP سرورز کو کیسے محفوظ بنا سکتے ہیں۔ خیال یہ ہے کہ آپ اپنے MCP سرور کے سامنے Azure API Management انسٹانس رکھیں اور یہ وہ خصوصیات سنبھالے جو آپ چاہتے ہیں جیسے:

- ریٹ لمیٹنگ
- ٹوکن مینجمنٹ
- مانیٹرنگ
- لوڈ بیلنسنگ
- سیکیورٹی

### Azure نمونہ

یہاں ایک Azure نمونہ ہے جو بالکل یہی کرتا ہے، یعنی [MCP سرور بنانا اور Azure API Management کے ذریعے اسے محفوظ بنانا](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)۔

نیچے دی گئی تصویر میں دیکھیں کہ اجازت نامہ کا عمل کیسے ہوتا ہے:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

مندرجہ بالا تصویر میں درج ذیل ہوتا ہے:

- Microsoft Entra کے ذریعے تصدیق/اجازت نامہ ہوتا ہے۔
- Azure API Management گیٹ وے کے طور پر کام کرتا ہے اور ٹریفک کو منظم کرنے کے لیے پالیسیز استعمال کرتا ہے۔
- Azure Monitor تمام درخواستوں کو لاگ کرتا ہے تاکہ بعد میں تجزیہ کیا جا سکے۔

#### اجازت نامہ کا عمل

آئیے اجازت نامہ کے عمل کو مزید تفصیل سے دیکھتے ہیں:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP اجازت نامہ کی تفصیلات

[مزيد معلومات کے لیے MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) ملاحظہ کریں۔

## ریموٹ MCP سرور کو Azure پر تعینات کرنا

آئیے دیکھتے ہیں کہ کیا ہم اس نمونے کو تعینات کر سکتے ہیں جو ہم نے پہلے ذکر کیا تھا:

1. ریپو کلون کریں

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` رجسٹر کریں

    `` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`

    کچھ دیر بعد چیک کریں کہ رجسٹریشن مکمل ہو چکی ہے یا نہیں۔

3. یہ [azd](https://aka.ms/azd) کمانڈ چلائیں تاکہ API مینجمنٹ سروس، فنکشن ایپ (کوڈ کے ساتھ) اور دیگر تمام ضروری Azure وسائل فراہم کیے جائیں

    ```shell
    azd up
    ```

    یہ کمانڈ Azure پر تمام کلاؤڈ وسائل تعینات کرنی چاہیے۔

### MCP Inspector کے ساتھ اپنے سرور کی جانچ

1. **نئے ٹرمینل ونڈو** میں MCP Inspector انسٹال اور چلائیں

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    آپ کو ایک ایسا انٹرفیس نظر آئے گا:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ur.png) 

2. CTRL کلک کریں تاکہ MCP Inspector ویب ایپ کو اس URL سے لوڈ کریں جو ایپ دکھا رہی ہے (مثلاً http://127.0.0.1:6274/#resources)
3. ٹرانسپورٹ کی قسم `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` پر سیٹ کریں اور **Connect** کریں:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**۔ کسی ٹول پر کلک کریں اور **Run Tool** کریں۔

اگر تمام مراحل کامیاب ہوئے ہیں، تو آپ اب MCP سرور سے جڑے ہوئے ہیں اور آپ نے کامیابی سے ٹول کال کر لیا ہے۔

## Azure کے لیے MCP سرورز

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): یہ ریپوزٹریز کا مجموعہ ہے جو Python، C# .NET یا Node/TypeScript کے ساتھ Azure Functions استعمال کرتے ہوئے کسٹم ریموٹ MCP سرورز بنانے اور تعینات کرنے کے لیے کوئیک اسٹارٹ ٹیمپلیٹ فراہم کرتا ہے۔

نمونے ایک مکمل حل فراہم کرتے ہیں جو ڈویلپرز کو اجازت دیتا ہے کہ وہ:

- مقامی طور پر بنائیں اور چلائیں: ایک MCP سرور مقامی مشین پر تیار اور ڈیبگ کریں
- Azure پر تعینات کریں: آسانی سے کلاؤڈ پر تعینات کریں ایک سادہ azd up کمانڈ کے ذریعے
- کلائنٹس سے کنیکٹ کریں: مختلف کلائنٹس جیسے VS Code کے Copilot ایجنٹ موڈ اور MCP Inspector ٹول سے MCP سرور سے جڑیں

### کلیدی خصوصیات:

- سیکیورٹی بذریعہ ڈیزائن: MCP سرور کو کیز اور HTTPS کے ذریعے محفوظ کیا گیا ہے
- توثیق کے اختیارات: بلٹ ان آتھ اور/یا API مینجمنٹ کے ذریعے OAuth کی حمایت
- نیٹ ورک تنہائی: Azure Virtual Networks (VNET) کے ذریعے نیٹ ورک تنہائی کی اجازت
- سرورلیس آرکیٹیکچر: Azure Functions کو استعمال کرتے ہوئے اسکیل ایبل، ایونٹ پر مبنی عمل
- مقامی ترقی: مکمل مقامی ترقی اور ڈیبگنگ کی حمایت
- آسان تعیناتی: Azure پر تعیناتی کا آسان عمل

ریپوزٹری میں تمام ضروری کنفیگریشن فائلز، سورس کوڈ، اور انفراسٹرکچر کی تعریفات شامل ہیں تاکہ آپ جلدی سے پیداوار کے لیے تیار MCP سرور نفاذ کے ساتھ شروع کر سکیں۔

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python کے ساتھ Azure Functions استعمال کرتے ہوئے MCP کا نمونہ نفاذ

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET کے ساتھ Azure Functions استعمال کرتے ہوئے MCP کا نمونہ نفاذ

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScript کے ساتھ Azure Functions استعمال کرتے ہوئے MCP کا نمونہ نفاذ۔

## اہم نکات

- MCP SDKs زبان مخصوص ٹولز فراہم کرتے ہیں جو مضبوط MCP حل نافذ کرنے کے لیے ضروری ہیں
- ڈیبگنگ اور ٹیسٹنگ کا عمل قابل اعتماد MCP ایپلیکیشنز کے لیے نہایت اہم ہے
- قابلِ دوبارہ استعمال پرامپٹ ٹیمپلیٹس AI تعاملات کو مستقل بناتے ہیں
- اچھی طرح ڈیزائن کردہ ورک فلو پیچیدہ کاموں کو متعدد ٹولز کے ذریعے منظم کر سکتے ہیں
- MCP حل نافذ کرتے وقت سیکیورٹی، کارکردگی، اور غلطی سنبھالنے کو مدنظر رکھنا ضروری ہے

## مشق

اپنے میدان میں ایک حقیقی مسئلے کو حل کرنے والا عملی MCP ورک فلو ڈیزائن کریں:

1. 3-4 ایسے ٹولز کی نشاندہی کریں جو اس مسئلے کو حل کرنے میں مددگار ہوں
2. ایک ورک فلو ڈایاگرام بنائیں جو دکھائے کہ یہ ٹولز کیسے آپس میں تعامل کرتے ہیں
3. اپنی پسندیدہ زبان میں ان میں سے ایک ٹول کا بنیادی ورژن نافذ کریں
4. ایک پرامپٹ ٹیمپلیٹ بنائیں جو ماڈل کو آپ کے ٹول کو مؤثر طریقے سے استعمال کرنے میں مدد دے

## اضافی وسائل


---

اگلا: [Advanced Topics](../05-AdvancedTopics/README.md)

**دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کی کوشش کرتے ہیں، براہ کرم آگاہ رہیں کہ خودکار تراجم میں غلطیاں یا عدم صحت ہو سکتی ہے۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر نہیں ہوگی۔