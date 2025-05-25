<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "13231e9951b68efd9df8c56bd5cdb27e",
  "translation_date": "2025-05-17T13:14:11+00:00",
  "source_file": "03-GettingStarted/samples/java/calculator/README.md",
  "language_code": "he"
}
-->
# שירות מחשבון בסיסי MCP

השירות הזה מספק פעולות מחשבון בסיסיות באמצעות פרוטוקול מודל הקשר (MCP) תוך שימוש ב-Spring Boot עם WebFlux. הוא נועד להיות דוגמה פשוטה למתחילים הלומדים על יישומים של MCP.

למידע נוסף, ראו את תיעוד ההתייחסות של [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html).

## סקירה כללית

השירות מציג:
- תמיכה ב-SSE (אירועים שנשלחים מהשרת)
- רישום כלי אוטומטי באמצעות ההערה `@Tool` של Spring AI
- פונקציות מחשבון בסיסיות:
  - חיבור, חיסור, כפל, חילוק
  - חישוב חזקה ושורש ריבועי
  - מודולוס (שארית) וערך מוחלט
  - פונקציית עזרה לתיאור הפעולות

## תכונות

שירות המחשבון מציע את היכולות הבאות:

1. **פעולות אריתמטיות בסיסיות**:
   - חיבור שני מספרים
   - חיסור מספר אחד ממספר אחר
   - כפל שני מספרים
   - חילוק מספר אחד במספר אחר (עם בדיקת חילוק באפס)

2. **פעולות מתקדמות**:
   - חישוב חזקה (העלאת בסיס לחזקה)
   - חישוב שורש ריבועי (עם בדיקת מספר שלילי)
   - חישוב מודולוס (שארית)
   - חישוב ערך מוחלט

3. **מערכת עזרה**:
   - פונקציית עזרה מובנית המסבירה את כל הפעולות הזמינות

## שימוש בשירות

השירות מציג את נקודות הקצה הבאות דרך פרוטוקול MCP:

- `add(a, b)`: חיבור שני מספרים
- `subtract(a, b)`: חיסור המספר השני מהראשון
- `multiply(a, b)`: כפל שני מספרים
- `divide(a, b)`: חילוק המספר הראשון בשני (עם בדיקת אפס)
- `power(base, exponent)`: חישוב חזקה של מספר
- `squareRoot(number)`: חישוב שורש ריבועי (עם בדיקת מספר שלילי)
- `modulus(a, b)`: חישוב השארית בחילוק
- `absolute(number)`: חישוב ערך מוחלט
- `help()`: קבלת מידע על הפעולות הזמינות

## לקוח בדיקה

לקוח בדיקה פשוט כלול בחבילה `com.microsoft.mcp.sample.client`. המחלקה `SampleCalculatorClient` מציגה את הפעולות הזמינות של שירות המחשבון.

## שימוש בלקוח LangChain4j

הפרויקט כולל דוגמת לקוח LangChain4j ב-`com.microsoft.mcp.sample.client.LangChain4jClient` שמדגימה כיצד לשלב את שירות המחשבון עם LangChain4j ודגמי GitHub:

### דרישות מוקדמות

1. **הגדרת אסימון GitHub**:

   כדי להשתמש בדגמי AI של GitHub (כמו phi-4), אתם צריכים אסימון גישה אישי של GitHub:

   א. עברו להגדרות החשבון שלכם ב-GitHub: https://github.com/settings/tokens
   
   ב. לחצו על "Generate new token" → "Generate new token (classic)"
   
   ג. תנו לאסימון שלכם שם תיאורי
   
   ד. בחרו את התחומים הבאים:
      - `repo` (שליטה מלאה על מאגרים פרטיים)
      - `read:org` (קריאת חברות בארגון וצוות, קריאת פרויקטים ארגוניים)
      - `gist` (יצירת גיסטים)
      - `user:email` (גישה לכתובות דוא"ל של משתמשים (קריאה בלבד))
   
   ה. לחצו על "Generate token" והעתיקו את האסימון החדש שלכם
   
   ו. הגדירו אותו כמשתנה סביבה:
      
      ב-Windows:
      ```
      set GITHUB_TOKEN=your-github-token
      ```
      
      ב-macOS/Linux:
      ```bash
      export GITHUB_TOKEN=your-github-token
      ```

   ז. להגדרה מתמשכת, הוסיפו אותו למשתני הסביבה שלכם דרך הגדרות המערכת

2. הוסיפו את התלות של LangChain4j GitHub לפרויקט שלכם (כבר כלול ב-pom.xml):
   ```xml
   <dependency>
       <groupId>dev.langchain4j</groupId>
       <artifactId>langchain4j-github</artifactId>
       <version>${langchain4j.version}</version>
   </dependency>
   ```

3. ודאו ששרת המחשבון פועל ב-`localhost:8080`

### הפעלת לקוח LangChain4j

דוגמה זו מדגימה:
- חיבור לשרת המחשבון MCP באמצעות SSE
- שימוש ב-LangChain4j ליצירת צ'אט-בוט שמנצל פעולות מחשבון
- שילוב עם דגמי AI של GitHub (כעת משתמשים בדגם phi-4)

הלקוח שולח את השאילתות הבאות כדוגמה להדגמת פונקציונליות:
1. חישוב סכום של שני מספרים
2. מציאת שורש ריבועי של מספר
3. קבלת מידע עזרה על פעולות מחשבון זמינות

הריצו את הדוגמה ובדקו את הפלט בקונסולה כדי לראות כיצד מודל ה-AI משתמש בכלי המחשבון כדי להגיב לשאילתות.

### הגדרת דגם GitHub

לקוח LangChain4j מוגדר להשתמש בדגם phi-4 של GitHub עם ההגדרות הבאות:

```java
ChatLanguageModel model = GitHubChatModel.builder()
    .apiKey(System.getenv("GITHUB_TOKEN"))
    .timeout(Duration.ofSeconds(60))
    .modelName("phi-4")
    .logRequests(true)
    .logResponses(true)
    .build();
```

כדי להשתמש בדגמי GitHub שונים, פשוט החליפו את הפרמטר `modelName` לדגם אחר נתמך (למשל, "claude-3-haiku-20240307", "llama-3-70b-8192", וכו').

## תלות

הפרויקט דורש את התלויות המרכזיות הבאות:

```xml
<!-- For MCP Server -->
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>

<!-- For LangChain4j integration -->
<dependency>
    <groupId>dev.langchain4j</groupId>
    <artifactId>langchain4j-mcp</artifactId>
    <version>${langchain4j.version}</version>
</dependency>

<!-- For GitHub models support -->
<dependency>
    <groupId>dev.langchain4j</groupId>
    <artifactId>langchain4j-github</artifactId>
    <version>${langchain4j.version}</version>
</dependency>
```

## בניית הפרויקט

בנו את הפרויקט באמצעות Maven:
```bash
./mvnw clean install -DskipTests
```

## הפעלת השרת

### שימוש ב-Java

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### שימוש ב-MCP Inspector

MCP Inspector הוא כלי מועיל לאינטראקציה עם שירותי MCP. כדי להשתמש בו עם שירות המחשבון הזה:

1. **התקינו והריצו את MCP Inspector** בחלון טרמינל חדש:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **גשו לממשק האינטרנט** על ידי לחיצה על ה-URL שמוצג על ידי האפליקציה (בדרך כלל http://localhost:6274)

3. **הגדירו את החיבור**:
   - הגדירו את סוג התעבורה ל-"SSE"
   - הגדירו את ה-URL לנקודת הקצה של SSE של השרת הפועל שלכם: `http://localhost:8080/sse`
   - לחצו על "Connect"

4. **השתמשו בכלים**:
   - לחצו על "List Tools" כדי לראות את פעולות המחשבון הזמינות
   - בחרו כלי ולחצו על "Run Tool" כדי לבצע פעולה

![צילום מסך של MCP Inspector](../../../../../../translated_images/tool.d45bdee7d4d5740a48d0d6378c9a8af0c1a289f1e0f2ae95ee176f1a5afb40a8.he.png)

### שימוש ב-Docker

הפרויקט כולל Dockerfile לפריסה במיכל:

1. **בנו את תמונת Docker**:
   ```bash
   docker build -t calculator-mcp-service .
   ```

2. **הריצו את מיכל Docker**:
   ```bash
   docker run -p 8080:8080 calculator-mcp-service
   ```

זה יבצע:
- בניית תמונת Docker מרובת שלבים עם Maven 3.9.9 ו-Eclipse Temurin 24 JDK
- יצירת תמונת מיכל אופטימלית
- חשיפת השירות על פורט 8080
- הפעלת שירות המחשבון MCP בתוך המיכל

ניתן לגשת לשירות ב-`http://localhost:8080` לאחר שהמיכל פועל.

## פתרון בעיות

### בעיות נפוצות עם אסימון GitHub

1. **בעיות הרשאה של אסימון**: אם אתם מקבלים שגיאת 403 Forbidden, בדקו שהאסימון שלכם מכיל את ההרשאות הנכונות כפי שמתואר בדרישות המוקדמות.

2. **אסימון לא נמצא**: אם אתם מקבלים שגיאת "No API key found", ודאו שמשתנה הסביבה GITHUB_TOKEN מוגדר כראוי.

3. **הגבלת קצב**: ל-API של GitHub יש הגבלות קצב. אם אתם נתקלים בשגיאת הגבלת קצב (קוד סטטוס 429), המתינו כמה דקות לפני ניסיון נוסף.

4. **תפוגת אסימון**: אסימוני GitHub יכולים לפוג. אם אתם מקבלים שגיאות אימות לאחר זמן מה, צרו אסימון חדש ועדכנו את משתנה הסביבה שלכם.

אם אתם זקוקים לעזרה נוספת, בדקו את תיעוד [LangChain4j](https://github.com/langchain4j/langchain4j) או את תיעוד [GitHub API](https://docs.github.com/en/rest).

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עשויים להכיל טעויות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור סמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום מקצועי אנושי. אנו לא אחראים על אי הבנות או פרשנויות מוטעות הנובעות משימוש בתרגום זה.