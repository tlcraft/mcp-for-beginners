<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:43:47+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "fa"
}
-->
# دمو استریمینگ HTTP ماشین حساب

این پروژه استریمینگ HTTP را با استفاده از Server-Sent Events (SSE) و Spring Boot WebFlux نشان می‌دهد. این پروژه شامل دو برنامه است:

- **Calculator Server**: یک سرویس وب واکنشی که محاسبات را انجام می‌دهد و نتایج را با استفاده از SSE استریم می‌کند
- **Calculator Client**: یک برنامه کلاینت که نقطه انتهایی استریم را مصرف می‌کند

## پیش‌نیازها

- جاوا ۱۷ یا بالاتر
- Maven نسخه ۳.۶ یا بالاتر

## ساختار پروژه

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

## نحوه کار

1. **Calculator Server** نقطه انتهایی `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5` را ارائه می‌دهد
   - پاسخ استریم شده را مصرف می‌کند
   - هر رویداد را در کنسول چاپ می‌کند

## اجرای برنامه‌ها

### گزینه ۱: استفاده از Maven (توصیه شده)

#### ۱. راه‌اندازی Calculator Server

یک ترمینال باز کنید و به دایرکتوری سرور بروید:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

سرور روی `http://localhost:8080` راه‌اندازی خواهد شد

باید خروجی مشابه زیر را ببینید:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### ۲. اجرای Calculator Client

یک **ترمینال جدید** باز کنید و به دایرکتوری کلاینت بروید:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

کلاینت به سرور متصل می‌شود، محاسبه را انجام می‌دهد و نتایج استریم شده را نمایش می‌دهد.

### گزینه ۲: اجرای مستقیم با جاوا

#### ۱. کامپایل و اجرای سرور:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### ۲. کامپایل و اجرای کلاینت:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## تست دستی سرور

می‌توانید سرور را با استفاده از مرورگر وب یا curl نیز تست کنید:

### استفاده از مرورگر وب:
به آدرس `http://localhost:8080/calculate?a=10&b=5&op=add` مراجعه کنید

### استفاده از curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## خروجی مورد انتظار

هنگام اجرای کلاینت، باید خروجی استریم شده مشابه زیر را مشاهده کنید:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## عملیات پشتیبانی شده

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
- بازگرداندن Server-Sent Events با پیشرفت محاسبه و نتیجه

**درخواست نمونه:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**پاسخ نمونه:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## عیب‌یابی

### مشکلات رایج

1. **پورت ۸۰۸۰ در حال استفاده است**
   - هر برنامه دیگری که از پورت ۸۰۸۰ استفاده می‌کند را متوقف کنید
   - یا پورت سرور را در `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` اگر به صورت پس‌زمینه اجرا می‌شود، تغییر دهید

## فناوری‌های استفاده شده

- **Spring Boot 3.3.1** - چارچوب برنامه
- **Spring WebFlux** - چارچوب وب واکنشی
- **Project Reactor** - کتابخانه جریان‌های واکنشی
- **Netty** - سرور I/O غیرمسدودکننده
- **Maven** - ابزار ساخت
- **Java 17+** - زبان برنامه‌نویسی

## مراحل بعدی

سعی کنید کد را تغییر دهید تا:
- عملیات ریاضی بیشتری اضافه کنید
- مدیریت خطا برای عملیات نامعتبر را اضافه کنید
- لاگ‌گیری درخواست/پاسخ را اضافه کنید
- احراز هویت را پیاده‌سازی کنید
- تست‌های واحد اضافه کنید

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه ماشینی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوء تفاهم یا تفسیر نادرستی که از استفاده از این ترجمه ناشی شود، نیستیم.