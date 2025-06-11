<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:19:45+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "ar"
}
-->
# عميل حاسبة LLM

تطبيق جافا يوضح كيفية استخدام LangChain4j للاتصال بخدمة حاسبة MCP (بروتوكول سياق النموذج) مع تكامل نماذج GitHub.

## المتطلبات المسبقة

- جافا 21 أو أحدث  
- مافن 3.6+ (أو استخدم ملف المافن المرفق)  
- حساب GitHub لديه وصول إلى نماذج GitHub  
- خدمة حاسبة MCP تعمل على `http://localhost:8080`  

## الحصول على رمز GitHub

يستخدم هذا التطبيق نماذج GitHub التي تتطلب رمز وصول شخصي من GitHub. اتبع الخطوات التالية للحصول على الرمز:

### 1. الوصول إلى نماذج GitHub  
1. انتقل إلى [GitHub Models](https://github.com/marketplace/models)  
2. سجّل الدخول باستخدام حساب GitHub الخاص بك  
3. اطلب الوصول إلى نماذج GitHub إذا لم تكن قد فعلت ذلك مسبقًا  

### 2. إنشاء رمز وصول شخصي  
1. انتقل إلى [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)  
2. اضغط على "Generate new token" → "Generate new token (classic)"  
3. امنح الرمز اسمًا وصفيًا (مثل "MCP Calculator Client")  
4. اضبط تاريخ الانتهاء حسب الحاجة  
5. اختر النطاقات التالية:  
   - `repo` (إذا كنت تصل إلى مستودعات خاصة)  
   - `user:email`  
6. اضغط على "Generate token"  
7. **مهم**: انسخ الرمز فورًا - لن تتمكن من رؤيته مرة أخرى!  

### 3. تعيين متغير البيئة

#### على ويندوز (موجه الأوامر):  
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### على ويندوز (PowerShell):  
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### على macOS/Linux:  
```bash
export GITHUB_TOKEN=your_github_token_here
```

## الإعداد والتثبيت

1. **استنساخ المشروع أو الانتقال إلى مجلد المشروع**

2. **تثبيت التبعيات**:  
   ```cmd
   mvnw clean install
   ```  
   أو إذا كان لديك مافن مثبتًا عالميًا:  
   ```cmd
   mvn clean install
   ```

3. **إعداد متغير البيئة** (انظر قسم "الحصول على رمز GitHub" أعلاه)

4. **تشغيل خدمة حاسبة MCP**:  
   تأكد من تشغيل خدمة حاسبة MCP الخاصة بالفصل الأول على `http://localhost:8080/sse`. يجب أن تكون هذه الخدمة تعمل قبل بدء العميل.

## تشغيل التطبيق

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## ماذا يفعل التطبيق

يعرض التطبيق ثلاث تفاعلات رئيسية مع خدمة الحاسبة:

1. **الجمع**: يحسب مجموع 24.5 و17.3  
2. **الجذر التربيعي**: يحسب الجذر التربيعي للعدد 144  
3. **المساعدة**: يعرض الوظائف المتاحة للحاسبة  

## الناتج المتوقع

عند التشغيل بنجاح، يجب أن ترى ناتجًا مشابهًا لـ:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## استكشاف الأخطاء وإصلاحها

### المشاكل الشائعة

1. **"متغير البيئة GITHUB_TOKEN غير مضبوط"**  
   - تأكد من تعيين `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean`  

### التصحيح

لتمكين تسجيل الأخطاء، أضف الوسيطة التالية لـ JVM عند التشغيل:  
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## التهيئة

تم تكوين التطبيق ليقوم بـ:  
- استخدام نماذج GitHub مع `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`  
- استخدام مهلة 60 ثانية للطلبات  
- تفعيل تسجيل الطلبات/الاستجابات لأغراض التصحيح  

## التبعيات

التبعيات الرئيسية المستخدمة في هذا المشروع:  
- **LangChain4j**: للتكامل مع الذكاء الاصطناعي وإدارة الأدوات  
- **LangChain4j MCP**: لدعم بروتوكول سياق النموذج  
- **LangChain4j GitHub Models**: لتكامل نماذج GitHub  
- **Spring Boot**: لإطار عمل التطبيق وحقن التبعيات  

## الترخيص

هذا المشروع مرخص بموجب رخصة Apache 2.0 - راجع ملف [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) للتفاصيل.

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر المعتمد. للمعلومات الهامة، يُنصح بالاستعانة بترجمة بشرية محترفة. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.