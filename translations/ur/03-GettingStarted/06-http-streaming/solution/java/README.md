<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:43:57+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "ur"
}
-->
# Calculator HTTP Streaming Demo

یہ پروجیکٹ Server-Sent Events (SSE) کے ذریعے HTTP streaming کو Spring Boot WebFlux کے ساتھ دکھاتا ہے۔ یہ دو ایپلیکیشنز پر مشتمل ہے:

- **Calculator Server**: ایک reactive ویب سروس جو حساب کتاب کرتی ہے اور SSE کے ذریعے نتائج کو stream کرتی ہے  
- **Calculator Client**: ایک کلائنٹ ایپلیکیشن جو streaming endpoint کو استعمال کرتی ہے

## ضروریات

- Java 17 یا اس سے زیادہ  
- Maven 3.6 یا اس سے زیادہ

## پروجیکٹ کی ساخت

```
java/
├── calculator-server/     # Spring Boot server with SSE endpoint
│   ├── src/main/java/com/example/calculatorserver/
│   │   ├── CalculatorServerApplication.java
│   │   └── CalculatorController.java
│   └── pom.xml
├── calculator-client/     # Spring Boot client application
│   ├── src/main/java/com/example/calculatorclient/
│   │   └── CalculatorClientApplication.java
│   └── pom.xml
└── README.md
```

## کام کرنے کا طریقہ

1. **Calculator Server** ایک `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5` endpoint فراہم کرتا ہے  
   - streaming response کو استعمال کرتا ہے  
   - ہر event کو کنسول پر پرنٹ کرتا ہے

## ایپلیکیشنز چلانا

### آپشن 1: Maven کے ذریعے (تجویز کردہ)

#### 1. Calculator Server شروع کریں

ٹرمینل کھولیں اور سرور ڈائریکٹری میں جائیں:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

سرور `http://localhost:8080` پر شروع ہو جائے گا

آپ کو اس طرح کا آؤٹ پٹ نظر آئے گا:  
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Calculator Client چلائیں

ایک **نیا ٹرمینل** کھولیں اور کلائنٹ ڈائریکٹری میں جائیں:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

کلائنٹ سرور سے کنیکٹ ہوگا، حساب کتاب کرے گا، اور streaming نتائج دکھائے گا۔

### آپشن 2: Java کو براہ راست استعمال کرنا

#### 1. سرور کو کمپائل اور چلائیں:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. کلائنٹ کو کمپائل اور چلائیں:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## سرور کو دستی طور پر ٹیسٹ کرنا

آپ ویب براؤزر یا curl کے ذریعے بھی سرور کو ٹیسٹ کر سکتے ہیں:

### ویب براؤزر استعمال کرتے ہوئے:  
یہاں جائیں: `http://localhost:8080/calculate?a=10&b=5&op=add`

### curl استعمال کرتے ہوئے:  
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## متوقع آؤٹ پٹ

جب کلائنٹ چلائیں گے تو آپ کو اس طرح کا streaming آؤٹ پٹ نظر آئے گا:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## سپورٹ شدہ آپریشنز

- `add` - Addition (a + b)
- `sub` - Subtraction (a - b)
- `mul` - Multiplication (a * b)
- `div` - Division (a / b, returns NaN if b = 0)

## API Reference

### GET /calculate

**Parameters:**
- `a` (required): First number (double)
- `b` (required): Second number (double)
- `op` (required): Operation (`add`, `sub`, `mul`, `div`)

**Response:**
- Content-Type: `text/event-stream`  
- Server-Sent Events کے ذریعے حساب کتاب کی پیش رفت اور نتیجہ واپس کرتا ہے

**مثال کے طور پر درخواست:**  
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**مثال کے طور پر جواب:**  
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## مسئلے حل کرنا

### عام مسائل

1. **پورٹ 8080 پہلے سے استعمال میں ہے**  
   - کسی اور ایپلیکیشن کو بند کریں جو پورٹ 8080 استعمال کر رہی ہو  
   - یا `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` میں سرور کا پورٹ تبدیل کریں اگر یہ پس منظر میں چل رہا ہو

## ٹیکنالوجی اسٹیک

- **Spring Boot 3.3.1** - ایپلیکیشن فریم ورک  
- **Spring WebFlux** - ری ایکٹو ویب فریم ورک  
- **Project Reactor** - ری ایکٹو streams لائبریری  
- **Netty** - نان بلاکنگ I/O سرور  
- **Maven** - بلڈ ٹول  
- **Java 17+** - پروگرامنگ زبان

## اگلے اقدامات

کوڈ میں ترمیم کرنے کی کوشش کریں تاکہ:  
- مزید ریاضیاتی آپریشنز شامل کیے جا سکیں  
- غلط آپریشنز کے لیے ایرر ہینڈلنگ شامل کی جائے  
- درخواست/جواب کی لاگنگ شامل کی جائے  
- تصدیق (authentication) نافذ کی جائے  
- یونٹ ٹیسٹ شامل کیے جائیں

**دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجموں میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں معتبر ذریعہ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔