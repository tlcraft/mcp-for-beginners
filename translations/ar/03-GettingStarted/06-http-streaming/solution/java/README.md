<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:43:39+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "ar"
}
-->
# عرض توضيحي لتدفق HTTP في الآلة الحاسبة

يعرض هذا المشروع تدفق HTTP باستخدام Server-Sent Events (SSE) مع Spring Boot WebFlux. ويتكون من تطبيقين:

- **خادم الآلة الحاسبة**: خدمة ويب تفاعلية تقوم بالعمليات الحسابية وتبث النتائج باستخدام SSE  
- **عميل الآلة الحاسبة**: تطبيق عميل يستهلك نقطة النهاية للبث

## المتطلبات الأساسية

- جافا 17 أو أعلى  
- مافن 3.6 أو أعلى  

## هيكل المشروع

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

## كيف يعمل

1. يقوم **خادم الآلة الحاسبة** بكشف نقطة النهاية `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`  
   - يستهلك استجابة التدفق  
   - يعرض كل حدث في وحدة التحكم  

## تشغيل التطبيقات

### الخيار 1: استخدام مافن (موصى به)

#### 1. تشغيل خادم الآلة الحاسبة

افتح الطرفية وانتقل إلى مجلد الخادم:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

سيبدأ الخادم على `http://localhost:8080`

يجب أن ترى مخرجات مثل:  
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. تشغيل عميل الآلة الحاسبة

افتح **طرفية جديدة** وانتقل إلى مجلد العميل:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

سيتصل العميل بالخادم، وينفذ العملية الحسابية، ويعرض نتائج التدفق.

### الخيار 2: استخدام جافا مباشرةً

#### 1. تجميع وتشغيل الخادم:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. تجميع وتشغيل العميل:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## اختبار الخادم يدويًا

يمكنك أيضًا اختبار الخادم باستخدام متصفح الويب أو curl:

### باستخدام متصفح الويب:  
زر الرابط: `http://localhost:8080/calculate?a=10&b=5&op=add`

### باستخدام curl:  
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## المخرجات المتوقعة

عند تشغيل العميل، يجب أن ترى تدفقًا مماثلًا للآتي:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## العمليات المدعومة

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
- يعيد Server-Sent Events مع تقدم العملية والنتيجة

**مثال على الطلب:**  
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**مثال على الاستجابة:**  
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## استكشاف الأخطاء وإصلاحها

### المشاكل الشائعة

1. **المنفذ 8080 مستخدم بالفعل**  
   - أوقف أي تطبيقات أخرى تستخدم المنفذ 8080  
   - أو غيّر منفذ الخادم في `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` إذا كنت تشغله كعملية في الخلفية  

## تقنية المشروع

- **Spring Boot 3.3.1** - إطار عمل التطبيق  
- **Spring WebFlux** - إطار عمل الويب التفاعلي  
- **Project Reactor** - مكتبة تدفقات تفاعلية  
- **Netty** - خادم I/O غير محظور  
- **Maven** - أداة البناء  
- **Java 17+** - لغة البرمجة  

## الخطوات التالية

جرّب تعديل الكود لـ:  
- إضافة المزيد من العمليات الحسابية  
- تضمين معالجة الأخطاء للعمليات غير الصالحة  
- إضافة تسجيل الطلبات/الاستجابات  
- تنفيذ المصادقة  
- إضافة اختبارات وحدات

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر المعتمد. للمعلومات الحساسة أو الهامة، يُنصح بالاعتماد على الترجمة المهنية البشرية. نحن غير مسؤولين عن أي سوء فهم أو تفسير خاطئ ناتج عن استخدام هذه الترجمة.