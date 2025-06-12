<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:20:30+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "ur"
}
-->
# کلکولیٹر LLM کلائنٹ

ایک جاوا ایپلیکیشن جو LangChain4j کو MCP (ماڈل کانٹیکسٹ پروٹوکول) کلکولیٹر سروس سے جوڑنے کے لیے GitHub Models انٹیگریشن کے ساتھ استعمال کرنے کا طریقہ دکھاتی ہے۔

## ضروریات

- جاوا 21 یا اس سے اوپر
- Maven 3.6+ (یا شامل Maven ریپر استعمال کریں)
- ایک GitHub اکاؤنٹ جسے GitHub Models تک رسائی حاصل ہو
- ایک MCP کلکولیٹر سروس جو `http://localhost:8080` پر چل رہی ہو

## GitHub ٹوکن حاصل کرنا

یہ ایپلیکیشن GitHub Models استعمال کرتی ہے جس کے لیے GitHub پر ذاتی رسائی ٹوکن درکار ہوتا ہے۔ اپنا ٹوکن حاصل کرنے کے لیے درج ذیل مراحل پر عمل کریں:

### 1. GitHub Models تک رسائی
1. [GitHub Models](https://github.com/marketplace/models) پر جائیں
2. اپنے GitHub اکاؤنٹ سے سائن ان کریں
3. اگر آپ نے پہلے درخواست نہیں دی تو GitHub Models تک رسائی کے لیے درخواست دیں

### 2. ذاتی رسائی ٹوکن بنائیں
1. [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens) پر جائیں
2. "Generate new token" → "Generate new token (classic)" پر کلک کریں
3. اپنے ٹوکن کو ایک وضاحتی نام دیں (مثلاً "MCP Calculator Client")
4. ضرورت کے مطابق میعاد مقرر کریں
5. درج ذیل اسکوپس منتخب کریں:
   - `repo` (اگر پرائیویٹ ریپوزٹریز تک رسائی درکار ہو)
   - `user:email`
6. "Generate token" پر کلک کریں
7. **اہم**: ٹوکن فوراً کاپی کریں - آپ اسے دوبارہ نہیں دیکھ سکیں گے!

### 3. ماحول کا متغیر سیٹ کریں

#### ونڈوز (کمانڈ پرامپٹ) پر:
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### ونڈوز (پاور شیل) پر:
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### میک او ایس/لینکس پر:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## سیٹ اپ اور انسٹالیشن

1. **پروجیکٹ ڈائریکٹری کلون کریں یا وہاں جائیں**

2. **انحصارات انسٹال کریں**:
   ```cmd
   mvnw clean install
   ```
   یا اگر Maven آپ کے سسٹم پر گلوبلی انسٹال ہے:
   ```cmd
   mvn clean install
   ```

3. **ماحول کا متغیر سیٹ کریں** (اوپر "GitHub ٹوکن حاصل کرنا" سیکشن دیکھیں)

4. **MCP کلکولیٹر سروس شروع کریں**:
   یقینی بنائیں کہ آپ کے پاس باب 1 کی MCP کلکولیٹر سروس `http://localhost:8080/sse` پر چل رہی ہو۔ کلائنٹ شروع کرنے سے پہلے یہ سروس چل رہی ہونی چاہیے۔

## ایپلیکیشن چلانا

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## ایپلیکیشن کیا کرتی ہے

یہ ایپلیکیشن کلکولیٹر سروس کے ساتھ تین اہم تعاملات دکھاتی ہے:

1. **جمع**: 24.5 اور 17.3 کا مجموعہ حساب کرتی ہے
2. **مربع جذر**: 144 کا مربع جذر نکالتی ہے
3. **مدد**: دستیاب کلکولیٹر فنکشنز دکھاتی ہے

## متوقع نتیجہ

کامیابی سے چلنے پر آپ کو مندرجہ ذیل جیسا آؤٹ پٹ نظر آئے گا:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## مسائل کا حل

### عام مسائل

1. **"GITHUB_TOKEN ماحول کا متغیر سیٹ نہیں ہے"**
   - یقینی بنائیں کہ آپ نے `GITHUB_TOKEN` سیٹ کیا ہوا ہے` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean

### ڈیبگنگ

ڈیبگ لاگنگ کو فعال کرنے کے لیے، ایپلیکیشن چلانے کے دوران درج ذیل JVM آرگیومنٹ شامل کریں:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## کنفیگریشن

ایپلیکیشن کی ترتیب:
- GitHub Models `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse` کے ساتھ استعمال کرتی ہے
- درخواستوں کے لیے 60 سیکنڈ کا ٹائم آؤٹ سیٹ ہے
- ڈیبگنگ کے لیے درخواست/جواب لاگنگ فعال ہے

## انحصارات

اس پروجیکٹ میں استعمال ہونے والے اہم انحصارات:
- **LangChain4j**: AI انٹیگریشن اور ٹول مینجمنٹ کے لیے
- **LangChain4j MCP**: ماڈل کانٹیکسٹ پروٹوکول سپورٹ کے لیے
- **LangChain4j GitHub Models**: GitHub Models انٹیگریشن کے لیے
- **Spring Boot**: ایپلیکیشن فریم ورک اور انحصار انجیکشن کے لیے

## لائسنس

یہ پروجیکٹ Apache License 2.0 کے تحت لائسنس یافتہ ہے - تفصیلات کے لیے [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) فائل دیکھیں۔

**ڈسکلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کی کوشش کرتے ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجموں میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ورانہ انسانی ترجمہ تجویز کیا جاتا ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر نہیں ہوگی۔