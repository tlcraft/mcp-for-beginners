<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:30:17+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "he"
}
-->
# לקוח מחשבון LLM

יישום Java שמדגים כיצד להשתמש ב-LangChain4j כדי להתחבר לשירות מחשבון MCP (Model Context Protocol) עם אינטגרציה של GitHub Models.

## דרישות מוקדמות

- Java 21 ומעלה  
- Maven 3.6+ (או שימוש ב-Maven wrapper המצורף)  
- חשבון GitHub עם גישה ל-GitHub Models  
- שירות מחשבון MCP שרץ על `http://localhost:8080`  

## קבלת טוקן GitHub

יישום זה משתמש ב-GitHub Models שדורש טוקן גישה אישי של GitHub. בצע את השלבים הבאים כדי לקבל את הטוקן שלך:

### 1. גישה ל-GitHub Models  
1. עבור ל-[GitHub Models](https://github.com/marketplace/models)  
2. התחבר עם חשבון ה-GitHub שלך  
3. בקש גישה ל-GitHub Models אם עדיין לא עשית זאת  

### 2. יצירת טוקן גישה אישי  
1. עבור ל-[GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)  
2. לחץ על "Generate new token" → "Generate new token (classic)"  
3. תן לטוקן שם תיאורי (למשל "MCP Calculator Client")  
4. הגדר תוקף לפי הצורך  
5. בחר את ההרשאות הבאות:  
   - `repo` (אם ניגשים לריפוזיטוריז פרטיים)  
   - `user:email`  
6. לחץ על "Generate token"  
7. **חשוב**: העתק את הטוקן מיד - לא תוכל לראות אותו שוב!  

### 3. הגדרת משתנה סביבה

#### ב-Windows (Command Prompt):  
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### ב-Windows (PowerShell):  
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### ב-macOS/Linux:  
```bash
export GITHUB_TOKEN=your_github_token_here
```

## התקנה והגדרה

1. **שכפל או נווט לתיקיית הפרויקט**

2. **התקן את התלויות**:  
   ```cmd
   mvnw clean install
   ```  
   או אם יש לך Maven מותקן באופן גלובלי:  
   ```cmd
   mvn clean install
   ```

3. **הגדר את משתנה הסביבה** (ראה סעיף "קבלת טוקן GitHub" למעלה)

4. **הפעל את שירות מחשבון MCP**:  
   ודא ששירות MCP מהמדריך בפרק 1 רץ על `http://localhost:8080/sse`. השירות חייב לפעול לפני הפעלת הלקוח.

## הרצת היישום

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## מה היישום עושה

היישום מדגים שלוש אינטראקציות עיקריות עם שירות המחשבון:

1. **חיבור**: מחשב את סכום 24.5 ו-17.3  
2. **שורש ריבועי**: מחשב את השורש הריבועי של 144  
3. **עזרה**: מציג את הפונקציות הזמינות במחשבון  

## פלט צפוי

כאשר רץ בהצלחה, תראה פלט דומה ל:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## פתרון תקלות

### בעיות נפוצות

1. **"GITHUB_TOKEN environment variable not set"**  
   - ודא שהגדרת את `GITHUB_TOKEN` environment variable
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

### דיבוג

כדי להפעיל רישום דיבוג, הוסף את הפרמטר הבא ל-JVM בעת ההרצה:  
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## קונפיגורציה

היישום מוגדר כך ש:  
- משתמש ב-GitHub Models עם `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`  
- משתמש בטיימאוט של 60 שניות לבקשות  
- מפעיל רישום בקשות/תגובות לצורך דיבוג  

## תלותיות

תלויות עיקריות בפרויקט זה:  
- **LangChain4j**: לאינטגרציה עם AI וניהול כלים  
- **LangChain4j MCP**: לתמיכה ב-Model Context Protocol  
- **LangChain4j GitHub Models**: לאינטגרציה עם GitHub Models  
- **Spring Boot**: למסגרת יישומים והזרקת תלויות  

## רישיון

הפרויקט מורשה תחת רישיון Apache 2.0 - ראה את הקובץ [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) לפרטים.

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון שתרגומים אוטומטיים עלולים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפתו המקורית הוא המקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.