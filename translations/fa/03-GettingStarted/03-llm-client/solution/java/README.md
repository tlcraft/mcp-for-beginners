<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:20:06+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "fa"
}
-->
# Calculator LLM Client

یک برنامه جاوا که نحوه استفاده از LangChain4j برای اتصال به سرویس ماشین حساب MCP (پروتکل زمینه مدل) با ادغام GitHub Models را نشان می‌دهد.

## پیش‌نیازها

- جاوا نسخه ۲۱ یا بالاتر  
- Maven نسخه ۳.۶ به بالا (یا استفاده از Maven wrapper همراه)  
- یک حساب GitHub با دسترسی به GitHub Models  
- سرویس ماشین حساب MCP در حال اجرا روی `http://localhost:8080`  

## دریافت توکن GitHub

این برنامه از GitHub Models استفاده می‌کند که نیاز به توکن دسترسی شخصی GitHub دارد. برای دریافت توکن مراحل زیر را دنبال کنید:

### ۱. دسترسی به GitHub Models
1. به [GitHub Models](https://github.com/marketplace/models) بروید  
2. با حساب GitHub خود وارد شوید  
3. در صورت نداشتن دسترسی، درخواست دسترسی به GitHub Models را ارسال کنید  

### ۲. ساخت توکن دسترسی شخصی
1. به [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens) بروید  
2. روی "Generate new token" → "Generate new token (classic)" کلیک کنید  
3. برای توکن خود نامی توصیفی انتخاب کنید (مثلاً "MCP Calculator Client")  
4. زمان انقضا را به دلخواه تنظیم کنید  
5. دسترسی‌های زیر را انتخاب کنید:  
   - `repo` (اگر به مخازن خصوصی دسترسی نیاز دارید)  
   - `user:email`  
6. روی "Generate token" کلیک کنید  
7. **مهم**: توکن را فوراً کپی کنید - بعداً قادر به مشاهده آن نخواهید بود!  

### ۳. تنظیم متغیر محیطی

#### در ویندوز (Command Prompt):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### در ویندوز (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### در macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## راه‌اندازی و نصب

1. **کلون کردن یا رفتن به پوشه پروژه**

2. **نصب وابستگی‌ها**:  
   ```cmd
   mvnw clean install
   ```  
   یا اگر Maven به صورت سراسری نصب است:  
   ```cmd
   mvn clean install
   ```

3. **تنظیم متغیر محیطی** (بخش "دریافت توکن GitHub" را ببینید)

4. **راه‌اندازی سرویس ماشین حساب MCP**:  
   مطمئن شوید سرویس MCP از فصل اول روی `http://localhost:8080/sse` در حال اجراست. این سرویس باید قبل از اجرای کلاینت فعال باشد.  

## اجرای برنامه

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## عملکرد برنامه

این برنامه سه تعامل اصلی با سرویس ماشین حساب را نشان می‌دهد:

1. **جمع**: محاسبه مجموع ۲۴.۵ و ۱۷.۳  
2. **جذر**: محاسبه جذر ۱۴۴  
3. **راهنما**: نمایش توابع موجود ماشین حساب  

## خروجی مورد انتظار

در صورت اجرای موفق، خروجی مشابه زیر را خواهید دید:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## رفع اشکال

### مشکلات رایج

1. **"متغیر محیطی GITHUB_TOKEN تنظیم نشده است"**  
   - مطمئن شوید متغیر `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean` را تنظیم کرده‌اید  

### اشکال‌زدایی

برای فعال کردن لاگ‌گیری دیباگ، هنگام اجرا این آرگومان JVM را اضافه کنید:  
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## پیکربندی

برنامه به گونه‌ای پیکربندی شده است که:  
- از GitHub Models با `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse` استفاده کند  
- تایم‌اوت ۶۰ ثانیه‌ای برای درخواست‌ها داشته باشد  
- لاگ‌گیری درخواست/پاسخ برای دیباگ فعال باشد  

## وابستگی‌ها

وابستگی‌های اصلی این پروژه:  
- **LangChain4j**: برای ادغام هوش مصنوعی و مدیریت ابزارها  
- **LangChain4j MCP**: برای پشتیبانی از پروتکل زمینه مدل  
- **LangChain4j GitHub Models**: برای ادغام GitHub Models  
- **Spring Boot**: برای فریم‌ورک برنامه و تزریق وابستگی‌ها  

## مجوز

این پروژه تحت مجوز Apache License 2.0 منتشر شده است - برای جزئیات به فایل [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) مراجعه کنید.

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل اشتباهات یا نادرستی‌هایی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.