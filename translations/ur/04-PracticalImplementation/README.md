<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T17:59:44+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ur"
}
-->
# عملی نفاذ

عملی نفاذ وہ جگہ ہے جہاں Model Context Protocol (MCP) کی طاقت حقیقت میں بدلتی ہے۔ اگرچہ MCP کے نظریہ اور فن تعمیر کو سمجھنا اہم ہے، حقیقی قدر اس وقت ظاہر ہوتی ہے جب آپ ان تصورات کو استعمال کرکے ایسے حل بناتے، آزماتے اور تعینات کرتے ہیں جو حقیقی دنیا کے مسائل کو حل کرتے ہیں۔ یہ باب نظریاتی علم اور عملی ترقی کے درمیان خلا کو پر کرتا ہے، اور آپ کو MCP پر مبنی ایپلیکیشنز کو زندہ کرنے کے عمل سے گزارتا ہے۔

چاہے آپ ذہین معاونین تیار کر رہے ہوں، کاروباری ورک فلو میں AI کو ضم کر رہے ہوں، یا ڈیٹا پروسیسنگ کے لیے حسب ضرورت ٹولز بنا رہے ہوں، MCP ایک لچکدار بنیاد فراہم کرتا ہے۔ اس کی زبان سے آزاد ڈیزائن اور مقبول پروگرامنگ زبانوں کے لیے سرکاری SDKs اسے وسیع پیمانے پر ڈویلپرز کے لیے قابل رسائی بناتے ہیں۔ ان SDKs کا فائدہ اٹھا کر، آپ تیزی سے پروٹوٹائپ بنا سکتے ہیں، دہرائی کر سکتے ہیں، اور مختلف پلیٹ فارمز اور ماحول میں اپنے حل کو اسکیل کر سکتے ہیں۔

آئندہ سیکشنز میں، آپ کو عملی مثالیں، نمونہ کوڈ، اور تعیناتی کی حکمت عملیاں ملیں گی جو C#, Java, TypeScript, JavaScript, اور Python میں MCP کو نافذ کرنے کے طریقے دکھاتی ہیں۔ آپ یہ بھی سیکھیں گے کہ MCP سرورز کو کیسے ڈی بگ اور ٹیسٹ کیا جائے، APIs کا انتظام کیسے کیا جائے، اور Azure کے ذریعے حل کو کلاؤڈ پر تعینات کیسے کیا جائے۔ یہ عملی وسائل آپ کی سیکھنے کی رفتار کو تیز کرنے اور پراعتماد طریقے سے مضبوط، پروڈکشن کے قابل MCP ایپلیکیشنز بنانے میں مدد کے لیے ڈیزائن کیے گئے ہیں۔

## جائزہ

یہ سبق مختلف پروگرامنگ زبانوں میں MCP نفاذ کے عملی پہلوؤں پر توجہ دیتا ہے۔ ہم دیکھیں گے کہ C#, Java, TypeScript, JavaScript, اور Python میں MCP SDKs کا استعمال کرکے مضبوط ایپلیکیشنز کیسے بنائیں، MCP سرورز کو ڈی بگ اور ٹیسٹ کریں، اور دوبارہ استعمال کے قابل وسائل، پرامپٹس، اور ٹولز کیسے تخلیق کریں۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ قابل ہو جائیں گے:
- مختلف پروگرامنگ زبانوں میں سرکاری SDKs کا استعمال کرتے ہوئے MCP حل نافذ کرنا
- MCP سرورز کو منظم طریقے سے ڈی بگ اور ٹیسٹ کرنا
- سرور کی خصوصیات (وسائل، پرامپٹس، اور ٹولز) بنانا اور استعمال کرنا
- پیچیدہ کاموں کے لیے موثر MCP ورک فلو ڈیزائن کرنا
- کارکردگی اور اعتمادیت کے لیے MCP نفاذ کو بہتر بنانا

## سرکاری SDK وسائل

Model Context Protocol مختلف زبانوں کے لیے سرکاری SDKs فراہم کرتا ہے:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDKs کے ساتھ کام کرنا

یہ سیکشن متعدد پروگرامنگ زبانوں میں MCP نفاذ کی عملی مثالیں فراہم کرتا ہے۔ آپ کو `samples` ڈائریکٹری میں زبان کے مطابق منظم نمونہ کوڈ ملے گا۔

### دستیاب نمونے

ریپوزیٹری میں درج ذیل زبانوں میں نمونہ نفاذ شامل ہیں:

- C#
- Java
- TypeScript
- JavaScript
- Python

ہر نمونہ مخصوص زبان اور ماحولیاتی نظام کے لیے MCP کے کلیدی تصورات اور نفاذ کے نمونوں کو ظاہر کرتا ہے۔

## بنیادی سرور خصوصیات

MCP سرورز ان خصوصیات کے کسی بھی امتزاج کو نافذ کر سکتے ہیں:

### وسائل  
وسائل صارف یا AI ماڈل کے استعمال کے لیے سیاق و سباق اور ڈیٹا فراہم کرتے ہیں:  
- دستاویزات کے ذخائر  
- علم کے بنیادی ذخائر  
- منظم ڈیٹا ذرائع  
- فائل سسٹمز  

### پرامپٹس  
پرامپٹس صارفین کے لیے ٹیمپلیٹ شدہ پیغامات اور ورک فلو ہوتے ہیں:  
- پہلے سے متعین گفتگو کے ٹیمپلیٹس  
- رہنمائی شدہ تعامل کے نمونے  
- مخصوص مکالماتی ڈھانچے  

### ٹولز  
ٹولز AI ماڈل کے لیے عمل درآمد کرنے والے فنکشنز ہوتے ہیں:  
- ڈیٹا پروسیسنگ کی سہولیات  
- بیرونی API انضمام  
- حسابی صلاحیتیں  
- تلاش کی فعالیت  

## نمونہ نفاذ: C#

سرکاری C# SDK ریپوزیٹری میں MCP کے مختلف پہلوؤں کو ظاہر کرنے والے کئی نمونہ نفاذ شامل ہیں:

- **بنیادی MCP کلائنٹ**: ایک سادہ مثال جو دکھاتی ہے کہ MCP کلائنٹ کیسے بنایا جائے اور ٹولز کو کال کیا جائے  
- **بنیادی MCP سرور**: بنیادی ٹول رجسٹریشن کے ساتھ کم از کم سرور نفاذ  
- **ایڈوانسڈ MCP سرور**: مکمل خصوصیات والا سرور جس میں ٹول رجسٹریشن، تصدیق، اور ایرر ہینڈلنگ شامل ہے  
- **ASP.NET انضمام**: ASP.NET Core کے ساتھ انضمام کی مثالیں  
- **ٹول نفاذ کے نمونے**: مختلف پیچیدگی کی سطحوں کے ساتھ ٹولز کو نافذ کرنے کے مختلف نمونے  

MCP C# SDK ابھی پریویو میں ہے اور APIs میں تبدیلیاں آ سکتی ہیں۔ ہم اس بلاگ کو SDK کی ترقی کے ساتھ مسلسل اپ ڈیٹ کرتے رہیں گے۔

### کلیدی خصوصیات  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)  

- اپنا [پہلا MCP سرور](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/) بنائیں۔  

مکمل C# نفاذ کے نمونوں کے لیے، سرکاری C# SDK نمونہ ریپوزیٹری ملاحظہ کریں: [official C# SDK samples repository](https://github.com/modelcontextprotocol/csharp-sdk)

## نمونہ نفاذ: Java نفاذ

Java SDK MCP نفاذ کے مضبوط اختیارات فراہم کرتا ہے جن میں انٹرپرائز گریڈ خصوصیات شامل ہیں۔

### کلیدی خصوصیات

- Spring Framework انضمام  
- مضبوط ٹائپ سیفٹی  
- ری ایکٹیو پروگرامنگ کی حمایت  
- جامع ایرر ہینڈلنگ  

مکمل Java نفاذ کے نمونے کے لیے، samples ڈائریکٹری میں [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) دیکھیں۔

## نمونہ نفاذ: JavaScript نفاذ

JavaScript SDK MCP نفاذ کے لیے ہلکا اور لچکدار طریقہ فراہم کرتا ہے۔

### کلیدی خصوصیات

- Node.js اور براؤزر کی حمایت  
- Promise-based API  
- Express اور دیگر فریم ورکس کے ساتھ آسان انضمام  
- سٹریمنگ کے لیے WebSocket کی حمایت  

مکمل JavaScript نفاذ کے نمونے کے لیے، samples ڈائریکٹری میں [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) دیکھیں۔

## نمونہ نفاذ: Python نفاذ

Python SDK MCP نفاذ کے لیے Pythonic انداز فراہم کرتا ہے جس میں بہترین ML فریم ورک انضمام شامل ہیں۔

### کلیدی خصوصیات

- asyncio کے ساتھ Async/await کی حمایت  
- Flask اور FastAPI انضمام  
- سادہ ٹول رجسٹریشن  
- مقبول ML لائبریریز کے ساتھ مقامی انضمام  

مکمل Python نفاذ کے نمونے کے لیے، samples ڈائریکٹری میں [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) دیکھیں۔

## API مینجمنٹ

Azure API Management ایک بہترین حل ہے کہ ہم MCP سرورز کو کیسے محفوظ بنا سکتے ہیں۔ خیال یہ ہے کہ آپ اپنے MCP سرور کے سامنے Azure API Management انسٹینس رکھیں اور اسے وہ خصوصیات سنبھالنے دیں جو آپ چاہتے ہیں، جیسے:

- ریٹ لمیٹنگ  
- ٹوکن مینجمنٹ  
- مانیٹرنگ  
- لوڈ بیلنسنگ  
- سیکیورٹی  

### Azure نمونہ

یہاں ایک Azure نمونہ ہے جو بالکل یہی کرتا ہے، یعنی [MCP سرور بنانا اور اسے Azure API Management کے ساتھ محفوظ کرنا](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)۔

نیچے دی گئی تصویر میں دیکھیں کہ اجازت کا عمل کیسے ہوتا ہے:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

پیش کردہ تصویر میں درج ذیل ہوتا ہے:

- Microsoft Entra کے ذریعے توثیق/اجازت ہوتی ہے۔  
- Azure API Management گیٹ وے کے طور پر کام کرتا ہے اور پالیسیز کا استعمال کرتے ہوئے ٹریفک کو ہدایت اور منظم کرتا ہے۔  
- Azure Monitor تمام درخواستوں کو لاگ کرتا ہے تاکہ مزید تجزیہ کیا جا سکے۔  

#### اجازت کا عمل

آئیے اجازت کے عمل کو مزید تفصیل سے دیکھتے ہیں:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP اجازت کی تفصیل

[MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) کے بارے میں مزید جانیں۔

## ریموٹ MCP سرور کو Azure پر تعینات کریں

آئیے دیکھتے ہیں کہ ہم پہلے ذکر کیے گئے نمونے کو تعینات کر سکتے ہیں یا نہیں:

1. ریپو کلون کریں

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. `Microsoft.App` رجسٹر کریں  
`` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`  
کچھ وقت بعد چیک کریں کہ رجسٹریشن مکمل ہو گئی ہے یا نہیں۔

2. یہ [azd](https://aka.ms/azd) کمانڈ چلائیں تاکہ API Management سروس، فنکشن ایپ (کوڈ کے ساتھ)، اور دیگر تمام مطلوبہ Azure وسائل فراہم کیے جا سکیں:

    ```shell
    azd up
    ```

    یہ کمانڈز Azure پر تمام کلاؤڈ وسائل تعینات کرنی چاہئیں۔

### MCP Inspector کے ساتھ اپنے سرور کا ٹیسٹ کرنا

1. ایک **نئی ٹرمینل ونڈو** میں MCP Inspector انسٹال اور چلائیں:

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    آپ کو ایک ایسا انٹرفیس نظر آنا چاہیے:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ur.png) 

1. CTRL کلک کریں تاکہ MCP Inspector ویب ایپ کو اس URL سے لوڈ کیا جا سکے جو ایپ دکھا رہا ہے (مثلاً http://127.0.0.1:6274/#resources)  
1. ٹرانسپورٹ ٹائپ کو `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` پر سیٹ کریں اور **Connect** کریں:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **ٹولز کی فہرست**۔ کسی ٹول پر کلک کریں اور **Run Tool** کریں۔  

اگر تمام مراحل کامیاب ہوئے ہیں، تو آپ اب MCP سرور سے جُڑے ہوئے ہیں اور آپ نے ٹول کو کال کرنے میں کامیابی حاصل کی ہے۔

## Azure کے لیے MCP سرورز

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): یہ ریپوزیٹریز کا مجموعہ تیز شروع کرنے کا ٹیمپلیٹ ہے جو Azure Functions کے ساتھ Python، C# .NET یا Node/TypeScript استعمال کرتے ہوئے کسٹم ریموٹ MCP (Model Context Protocol) سرورز بنانے اور تعینات کرنے کے لیے ہے۔

نمونے ایک مکمل حل فراہم کرتے ہیں جو ڈویلپرز کو اجازت دیتا ہے کہ وہ:

- لوکل طور پر بنائیں اور چلائیں: لوکل مشین پر MCP سرور تیار اور ڈی بگ کریں  
- Azure پر تعینات کریں: ایک سادہ azd up کمانڈ کے ساتھ کلاؤڈ پر آسانی سے تعینات کریں  
- کلائنٹس سے کنیکٹ کریں: مختلف کلائنٹس سے MCP سرور سے جُڑیں، جن میں VS Code کا Copilot ایجنٹ موڈ اور MCP Inspector ٹول شامل ہیں  

### کلیدی خصوصیات:

- ڈیزائن کے ذریعے سیکیورٹی: MCP سرور کیز اور HTTPS کے ذریعے محفوظ ہے  
- توثیق کے اختیارات: بلٹ ان آتھ اور/یا API مینجمنٹ کے ذریعے OAuth کی حمایت  
- نیٹ ورک آئسولیشن: Azure Virtual Networks (VNET) کے ذریعے نیٹ ورک آئسولیشن کی اجازت  
- سرور لیس فن تعمیر: Azure Functions کا فائدہ اٹھا کر اسکیل ایبل، ایونٹ ڈرون عمل درآمد  
- مقامی ترقی: مکمل مقامی ترقی اور ڈی بگنگ کی حمایت  
- آسان تعیناتی: Azure پر آسان اور منظم تعیناتی کا عمل  

ریپوزیٹری میں تمام ضروری کنفیگریشن فائلز، سورس کوڈ، اور انفراسٹرکچر کی تعریفیں شامل ہیں تاکہ آپ جلدی سے پروڈکشن کے قابل MCP سرور نفاذ کے ساتھ شروع کر سکیں۔

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python کے ساتھ Azure Functions استعمال کرتے ہوئے MCP کا نمونہ نفاذ  

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET کے ساتھ Azure Functions استعمال کرتے ہوئے MCP کا نمونہ نفاذ  

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScript کے ساتھ Azure Functions استعمال کرتے ہوئے MCP کا نمونہ نفاذ  

## اہم نکات

- MCP SDKs زبان مخصوص ٹولز فراہم کرتے ہیں تاکہ مضبوط MCP حل نافذ کیے جا سکیں  
- ڈی بگنگ اور ٹیسٹنگ کا عمل قابل اعتماد MCP ایپلیکیشنز کے لیے نہایت اہم ہے  
- دوبارہ استعمال کے قابل پرامپٹ ٹیمپلیٹس AI تعاملات کو مستقل بناتے ہیں  
- اچھے ڈیزائن کردہ ورک فلو پیچیدہ کاموں کو مختلف ٹولز کے استعمال سے مربوط کر سکتے ہیں  
- MCP حل نافذ کرنے کے لیے سیکیورٹی، کارکردگی، اور ایرر ہینڈلنگ کا خیال رکھنا ضروری ہے  

## مشق

اپنے ڈومین میں ایک حقیقی مسئلے کو حل کرنے والا عملی MCP ورک فلو ڈیزائن کریں:

1. 3-4 ایسے ٹولز کی نشاندہی کریں جو اس مسئلے کو حل کرنے میں مددگار ہوں  
2. ایک ورک فلو ڈایاگرام بنائیں جو دکھائے کہ یہ ٹولز کس طرح آپس میں تعامل کرتے ہیں  
3. اپنی پسندیدہ زبان میں ایک ٹول کا بنیادی ورژن نافذ کریں  
4. ایک پرامپٹ ٹیمپلیٹ بنائیں جو ماڈل کو آپ کے ٹول کو مؤثر طریقے سے استعمال کرنے میں مدد دے  

## اضافی وسائل


---

اگلا: [Advanced Topics](../05-AdvancedTopics/README.md)

**ڈسکلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کی کوشش کرتے ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار ترجموں میں غلطیاں یا غیر درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں مستند ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ورانہ انسانی ترجمہ تجویز کیا جاتا ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر نہیں ہوگی۔