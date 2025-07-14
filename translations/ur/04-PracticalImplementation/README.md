<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb1ab5c924f58cf75ef1732d474f008a",
  "translation_date": "2025-07-14T17:05:33+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ur"
}
-->
# عملی نفاذ

عملی نفاذ وہ مقام ہے جہاں Model Context Protocol (MCP) کی طاقت محسوس کی جا سکتی ہے۔ اگرچہ MCP کے نظریہ اور فن تعمیر کو سمجھنا اہم ہے، اصل قدر تب سامنے آتی ہے جب آپ ان تصورات کو استعمال کرتے ہوئے ایسے حل تیار، جانچ اور تعینات کرتے ہیں جو حقیقی دنیا کے مسائل کو حل کرتے ہیں۔ یہ باب نظریاتی علم اور عملی ترقی کے درمیان پل کا کام کرتا ہے، اور آپ کو MCP پر مبنی ایپلیکیشنز کو حقیقت میں لانے کے عمل سے رہنمائی فراہم کرتا ہے۔

چاہے آپ ذہین اسسٹنٹس تیار کر رہے ہوں، کاروباری ورک فلو میں AI کو ضم کر رہے ہوں، یا ڈیٹا پروسیسنگ کے لیے حسب ضرورت ٹولز بنا رہے ہوں، MCP ایک لچکدار بنیاد فراہم کرتا ہے۔ اس کی زبان سے آزاد ڈیزائن اور مقبول پروگرامنگ زبانوں کے لیے سرکاری SDKs اسے وسیع پیمانے پر ڈویلپرز کے لیے قابل رسائی بناتے ہیں۔ ان SDKs کا فائدہ اٹھا کر، آپ جلدی سے پروٹوٹائپ بنا سکتے ہیں، بار بار بہتری لا سکتے ہیں، اور مختلف پلیٹ فارمز اور ماحول میں اپنے حل کو بڑھا سکتے ہیں۔

اگلے حصوں میں، آپ کو عملی مثالیں، نمونہ کوڈ، اور تعیناتی کی حکمت عملی ملیں گی جو دکھاتی ہیں کہ MCP کو C#، Java، TypeScript، JavaScript، اور Python میں کیسے نافذ کیا جائے۔ آپ یہ بھی سیکھیں گے کہ MCP سرورز کو کیسے ڈیبگ اور ٹیسٹ کیا جائے، APIs کا انتظام کیسے کیا جائے، اور Azure کا استعمال کرتے ہوئے کلاؤڈ میں حل کیسے تعینات کیے جائیں۔ یہ عملی وسائل آپ کی سیکھنے کی رفتار کو تیز کرنے اور آپ کو مضبوط، پروڈکشن کے قابل MCP ایپلیکیشنز بنانے میں اعتماد فراہم کرنے کے لیے تیار کیے گئے ہیں۔

## جائزہ

یہ سبق MCP کے عملی نفاذ کے مختلف پروگرامنگ زبانوں میں پہلوؤں پر مرکوز ہے۔ ہم دیکھیں گے کہ C#، Java، TypeScript، JavaScript، اور Python میں MCP SDKs کا استعمال کرتے ہوئے مضبوط ایپلیکیشنز کیسے بنائی جائیں، MCP سرورز کو کیسے ڈیبگ اور ٹیسٹ کیا جائے، اور قابلِ استعمال وسائل، پرامپٹس، اور ٹولز کیسے تخلیق کیے جائیں۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ قابل ہوں گے کہ:
- مختلف پروگرامنگ زبانوں میں سرکاری SDKs کا استعمال کرتے ہوئے MCP حل نافذ کریں
- MCP سرورز کو منظم طریقے سے ڈیبگ اور ٹیسٹ کریں
- سرور کی خصوصیات (Resources, Prompts, اور Tools) بنائیں اور استعمال کریں
- پیچیدہ کاموں کے لیے مؤثر MCP ورک فلو ڈیزائن کریں
- کارکردگی اور اعتماد کے لیے MCP نفاذ کو بہتر بنائیں

## سرکاری SDK وسائل

Model Context Protocol مختلف زبانوں کے لیے سرکاری SDKs فراہم کرتا ہے:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDKs کے ساتھ کام کرنا

یہ سیکشن مختلف پروگرامنگ زبانوں میں MCP کے نفاذ کی عملی مثالیں فراہم کرتا ہے۔ آپ `samples` ڈائریکٹری میں زبان کے مطابق منظم نمونہ کوڈ دیکھ سکتے ہیں۔

### دستیاب نمونے

ریپوزیٹری میں درج ذیل زبانوں میں [نمونہ نفاذ](../../../04-PracticalImplementation/samples) شامل ہیں:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

ہر نمونہ مخصوص زبان اور ماحولیاتی نظام کے لیے MCP کے کلیدی تصورات اور نفاذ کے نمونے دکھاتا ہے۔

## بنیادی سرور خصوصیات

MCP سرورز ان خصوصیات کے کسی بھی امتزاج کو نافذ کر سکتے ہیں:

### Resources  
Resources صارف یا AI ماڈل کے لیے سیاق و سباق اور ڈیٹا فراہم کرتے ہیں:  
- دستاویزات کے ذخیرے  
- علم کے مراکز  
- منظم ڈیٹا کے ذرائع  
- فائل سسٹمز  

### Prompts  
Prompts صارفین کے لیے ٹیمپلیٹ شدہ پیغامات اور ورک فلو ہوتے ہیں:  
- پہلے سے طے شدہ گفتگو کے ٹیمپلیٹس  
- رہنمائی شدہ تعامل کے نمونے  
- مخصوص مکالماتی ڈھانچے  

### Tools  
Tools AI ماڈل کے لیے چلانے والے فنکشنز ہوتے ہیں:  
- ڈیٹا پروسیسنگ کے آلات  
- بیرونی API انضمام  
- حسابی صلاحیتیں  
- تلاش کی فعالیت  

## نمونہ نفاذ: C#

سرکاری C# SDK ریپوزیٹری میں MCP کے مختلف پہلوؤں کو ظاہر کرنے والے کئی نمونہ نفاذ شامل ہیں:

- **بنیادی MCP کلائنٹ**: ایک سادہ مثال جو دکھاتی ہے کہ MCP کلائنٹ کیسے بنایا جائے اور ٹولز کو کال کیا جائے  
- **بنیادی MCP سرور**: بنیادی ٹول رجسٹریشن کے ساتھ کم از کم سرور نفاذ  
- **جدید MCP سرور**: مکمل خصوصیات والا سرور جس میں ٹول رجسٹریشن، توثیق، اور ایرر ہینڈلنگ شامل ہے  
- **ASP.NET انضمام**: ASP.NET Core کے ساتھ انضمام کی مثالیں  
- **ٹول نفاذ کے نمونے**: مختلف پیچیدگی کی سطحوں کے ساتھ ٹولز کے نفاذ کے مختلف نمونے  

MCP C# SDK ابھی پریویو میں ہے اور APIs میں تبدیلیاں آ سکتی ہیں۔ ہم اس بلاگ کو SDK کی ترقی کے ساتھ مسلسل اپ ڈیٹ کرتے رہیں گے۔

### کلیدی خصوصیات  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)  
- اپنا [پہلا MCP سرور بنائیں](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)۔  

مکمل C# نفاذ کے نمونوں کے لیے، [سرکاری C# SDK نمونہ ریپوزیٹری](https://github.com/modelcontextprotocol/csharp-sdk) ملاحظہ کریں۔

## نمونہ نفاذ: Java نفاذ

Java SDK مضبوط MCP نفاذ کے اختیارات فراہم کرتا ہے جن میں انٹرپرائز گریڈ خصوصیات شامل ہیں۔

### کلیدی خصوصیات

- Spring Framework انضمام  
- مضبوط ٹائپ سیفٹی  
- ریئیکٹو پروگرامنگ کی حمایت  
- جامع ایرر ہینڈلنگ  

مکمل Java نفاذ کے نمونے کے لیے، samples ڈائریکٹری میں [Java sample](samples/java/containerapp/README.md) دیکھیں۔

## نمونہ نفاذ: JavaScript نفاذ

JavaScript SDK MCP نفاذ کے لیے ہلکا اور لچکدار طریقہ فراہم کرتا ہے۔

### کلیدی خصوصیات

- Node.js اور براؤزر کی حمایت  
- Promise-based API  
- Express اور دیگر فریم ورکس کے ساتھ آسان انضمام  
- سٹریمنگ کے لیے WebSocket کی حمایت  

مکمل JavaScript نفاذ کے نمونے کے لیے، samples ڈائریکٹری میں [JavaScript sample](samples/javascript/README.md) دیکھیں۔

## نمونہ نفاذ: Python نفاذ

Python SDK MCP نفاذ کے لیے Pythonic انداز فراہم کرتا ہے جس میں بہترین ML فریم ورک انضمام شامل ہیں۔

### کلیدی خصوصیات

- asyncio کے ساتھ async/await کی حمایت  
- FastAPI انضمام  
- آسان ٹول رجسٹریشن  
- مقبول ML لائبریریوں کے ساتھ مقامی انضمام  

مکمل Python نفاذ کے نمونے کے لیے، samples ڈائریکٹری میں [Python sample](samples/python/README.md) دیکھیں۔

## API مینجمنٹ

Azure API Management ایک بہترین حل ہے کہ ہم MCP سرورز کو کیسے محفوظ بنا سکتے ہیں۔ خیال یہ ہے کہ آپ اپنے MCP سرور کے سامنے Azure API Management انسٹینس رکھیں اور اسے وہ خصوصیات سنبھالنے دیں جو آپ چاہتے ہیں، جیسے:

- ریٹ لمیٹنگ  
- ٹوکن مینجمنٹ  
- مانیٹرنگ  
- لوڈ بیلنسنگ  
- سیکیورٹی  

### Azure نمونہ

یہاں ایک Azure نمونہ ہے جو بالکل یہی کرتا ہے، یعنی [MCP سرور بنانا اور اسے Azure API Management کے ذریعے محفوظ کرنا](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)۔

نیچے دی گئی تصویر میں اجازت کا عمل دکھایا گیا ہے:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

مندرجہ بالا تصویر میں درج ذیل ہوتا ہے:

- Microsoft Entra کے ذریعے توثیق/اجازت دی جاتی ہے۔  
- Azure API Management گیٹ وے کے طور پر کام کرتا ہے اور پالیسیز کے ذریعے ٹریفک کو ہدایت اور منظم کرتا ہے۔  
- Azure Monitor تمام درخواستوں کو لاگ کرتا ہے تاکہ مزید تجزیہ کیا جا سکے۔  

#### اجازت کا عمل

آئیے اجازت کے عمل کو مزید تفصیل سے دیکھتے ہیں:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP اجازت کی وضاحت

[MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) کے بارے میں مزید جانیں۔

## ریموٹ MCP سرور کو Azure پر تعینات کرنا

آئیے دیکھتے ہیں کہ کیا ہم پہلے ذکر کیے گئے نمونے کو تعینات کر سکتے ہیں:

1. ریپو کلون کریں

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` resource provider کو رجسٹر کریں۔  
    * اگر آپ Azure CLI استعمال کر رہے ہیں، تو `az provider register --namespace Microsoft.App --wait` چلائیں۔  
    * اگر آپ Azure PowerShell استعمال کر رہے ہیں، تو `Register-AzResourceProvider -ProviderNamespace Microsoft.App` چلائیں۔ پھر کچھ دیر بعد `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` چیک کریں کہ رجسٹریشن مکمل ہو چکی ہے یا نہیں۔  

3. یہ [azd](https://aka.ms/azd) کمانڈ چلائیں تاکہ API Management سروس، function app (کوڈ کے ساتھ)، اور دیگر تمام ضروری Azure وسائل فراہم کیے جا سکیں:

    ```shell
    azd up
    ```

    یہ کمانڈز Azure پر تمام کلاؤڈ وسائل تعینات کر دیں گے۔

### MCP Inspector کے ساتھ اپنے سرور کی جانچ

1. **نئی ٹرمینل ونڈو** میں MCP Inspector انسٹال اور چلائیں

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    آپ کو ایک ایسا انٹرفیس نظر آئے گا:

    ![Connect to Node inspector](/03-GettingStarted/01-first-server/assets/connect.png) 

2. CTRL کلک کریں تاکہ MCP Inspector ویب ایپ اس URL سے لوڈ ہو جو ایپ دکھا رہی ہے (مثلاً http://127.0.0.1:6274/#resources)  
3. ٹرانسپورٹ کی قسم `SSE` پر سیٹ کریں  
4. URL کو اپنے چلتے ہوئے API Management SSE اینڈپوائنٹ پر سیٹ کریں جو `azd up` کے بعد دکھایا گیا ہو اور **Connect** کریں:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools** پر کلک کریں۔ کسی ٹول پر کلک کریں اور **Run Tool** کریں۔  

اگر تمام مراحل کامیاب ہو گئے ہیں، تو آپ اب MCP سرور سے جُڑ چکے ہیں اور آپ نے ایک ٹول کو کال کرنے میں کامیابی حاصل کی ہے۔

## Azure کے لیے MCP سرورز

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): یہ ریپوزیٹریز کا مجموعہ ہے جو Azure Functions کے ساتھ Python، C# .NET، یا Node/TypeScript استعمال کرتے ہوئے کسٹم ریموٹ MCP (Model Context Protocol) سرورز بنانے اور تعینات کرنے کے لیے کوئیک اسٹارٹ ٹیمپلیٹ فراہم کرتا ہے۔

یہ نمونے ایک مکمل حل فراہم کرتے ہیں جو ڈویلپرز کو اجازت دیتا ہے کہ:

- لوکل مشین پر MCP سرور بنائیں اور چلائیں: لوکل مشین پر MCP سرور تیار اور ڈیبگ کریں  
- Azure پر تعینات کریں: آسانی سے کلاؤڈ پر تعینات کریں صرف ایک azd up کمانڈ کے ذریعے  
- کلائنٹس سے کنیکٹ کریں: مختلف کلائنٹس سے MCP سرور سے جڑیں، بشمول VS Code کے Copilot ایجنٹ موڈ اور MCP Inspector ٹول  

### کلیدی خصوصیات:

- ڈیزائن کے لحاظ سے سیکیورٹی: MCP سرور کو کیز اور HTTPS کے ذریعے محفوظ کیا گیا ہے  
- توثیق کے اختیارات: بلٹ ان آتھ اور/یا API Management کے ذریعے OAuth کی حمایت  
- نیٹ ورک علیحدگی: Azure Virtual Networks (VNET) کے ذریعے نیٹ ورک علیحدگی کی اجازت  
- سرورلیس فن تعمیر: Azure Functions کا استعمال کرتے ہوئے اسکیل ایبل، ایونٹ پر مبنی عمل  
- مقامی ترقی: مکمل لوکل ڈیولپمنٹ اور ڈیبگنگ کی حمایت  
- آسان تعیناتی: Azure پر تعیناتی کا آسان عمل  

ریپوزیٹری میں تمام ضروری کنفیگریشن فائلز، سورس کوڈ، اور انفراسٹرکچر کی تعریفیں شامل ہیں تاکہ آپ جلدی سے پروڈکشن کے قابل MCP سرور نفاذ کے ساتھ شروع کر سکیں۔

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python کے ساتھ Azure Functions استعمال کرتے ہوئے MCP کا نمونہ نفاذ  
- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET کے ساتھ Azure Functions استعمال کرتے ہوئے MCP کا نمونہ نفاذ  
- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScript کے ساتھ Azure Functions استعمال کرتے ہوئے MCP کا نمونہ نفاذ  

## اہم نکات

- MCP SDKs زبان مخصوص ٹولز فراہم کرتے ہیں جو مضبوط MCP حل نافذ کرنے میں مدد دیتے ہیں  
- ڈیبگنگ اور ٹیسٹنگ کا عمل قابل اعتماد MCP ایپلیکیشنز کے لیے نہایت اہم ہے  
- قابلِ استعمال پرامپٹ ٹیمپلیٹس AI تعاملات کو مستقل بناتے ہیں  
- اچھی طرح ڈیزائن کردہ ورک فلو پیچیدہ کاموں کو متعدد ٹولز کے ذریعے منظم کر سکتے ہیں  
- MCP حل نافذ کرنے کے لیے سیکیورٹی، کارکردگی، اور ایرر ہینڈلنگ پر غور کرنا ضروری ہے  

## مشق

اپنے شعبے میں ایک حقیقی مسئلے کو حل کرنے والا عملی MCP ورک فلو ڈیزائن کریں:

1. 3-4 ایسے ٹولز کی نشاندہی کریں جو اس مسئلے کو حل کرنے میں مددگار ہوں  
2. ایک ورک فلو ڈایاگرام بنائیں جو دکھائے کہ یہ ٹولز کیسے ایک دوسرے کے ساتھ تعامل کرتے ہیں  
3. اپنی پسندیدہ زبان میں ان میں سے ایک ٹول کا بنیادی ورژن نافذ کریں  
4. ایک پرامپٹ ٹیمپلیٹ بنائیں جو ماڈل کو آپ کے ٹول کو مؤثر طریقے سے استعمال کرنے میں مدد دے  

## اضافی وسائل


---

اگلا: [Advanced Topics](../05-AdvancedTopics/README.md)

**دستخطی نوٹ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔