<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb1ab5c924f58cf75ef1732d474f008a",
  "translation_date": "2025-07-14T17:18:25+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "he"
}
-->
# יישום מעשי

היישום המעשי הוא המקום שבו כוחו של Model Context Protocol (MCP) הופך למוחשי. בעוד שהבנת התיאוריה והארכיטקטורה שמאחורי MCP חשובה, הערך האמיתי מתגלה כאשר מיישמים את המושגים האלה לבניית, בדיקה ופריסה של פתרונות שפועלים בעולם האמיתי. פרק זה גשר בין הידע התיאורטי לפיתוח מעשי, ומנחה אותך בתהליך של הבאת יישומים מבוססי MCP לחיים.

בין אם אתה מפתח עוזרים חכמים, משלב AI בתהליכי עבודה עסקיים, או בונה כלים מותאמים לעיבוד נתונים, MCP מספק בסיס גמיש. העיצוב הבלתי תלוי בשפה וה-SDKs הרשמיים לשפות תכנות פופולריות הופכים אותו לנגיש למגוון רחב של מפתחים. באמצעות ניצול ה-SDKs האלה, תוכל במהירות ליצור אב-טיפוס, לחזור על הפיתוח ולהרחיב את הפתרונות שלך בפלטפורמות וסביבות שונות.

בקטעים הבאים תמצא דוגמאות מעשיות, קוד לדוגמה ואסטרטגיות פריסה שמדגימות כיצד ליישם MCP ב-C#, Java, TypeScript, JavaScript ו-Python. תלמד גם כיצד לנפות שגיאות ולבדוק את שרתי ה-MCP שלך, לנהל APIs ולפרוס פתרונות לענן באמצעות Azure. המשאבים המעשים האלה נועדו להאיץ את הלמידה שלך ולעזור לך לבנות בביטחון יישומים יציבים ומוכנים לייצור מבוססי MCP.

## סקירה כללית

השיעור הזה מתמקד בהיבטים מעשיים של יישום MCP בשפות תכנות שונות. נחקור כיצד להשתמש ב-SDKs של MCP ב-C#, Java, TypeScript, JavaScript ו-Python כדי לבנות יישומים יציבים, לנפות שגיאות ולבדוק שרתי MCP, וליצור משאבים, פרומפטים וכלים לשימוש חוזר.

## מטרות הלמידה

בסיום השיעור תוכל:
- ליישם פתרונות MCP באמצעות SDKs רשמיים בשפות תכנות שונות
- לנפות שגיאות ולבדוק שרתי MCP באופן שיטתי
- ליצור ולהשתמש בתכונות שרת (משאבים, פרומפטים וכלים)
- לתכנן תהליכי עבודה יעילים ב-MCP למשימות מורכבות
- לאופטם יישומי MCP לביצועים ואמינות

## משאבי SDK רשמיים

Model Context Protocol מציע SDKs רשמיים למספר שפות:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## עבודה עם SDKs של MCP

קטע זה מספק דוגמאות מעשיות ליישום MCP בשפות תכנות שונות. ניתן למצוא קוד לדוגמה בתיקיית `samples` הממוינת לפי שפה.

### דוגמאות זמינות

הריפוזיטורי כולל [יישומים לדוגמה](../../../04-PracticalImplementation/samples) בשפות הבאות:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

כל דוגמה מדגימה מושגי מפתח ודפוסי יישום של MCP עבור השפה והאקוסיסטם הספציפיים.

## תכונות מרכזיות של השרת

שרתי MCP יכולים ליישם כל שילוב של התכונות הבאות:

### משאבים  
משאבים מספקים הקשר ונתונים לשימוש המשתמש או מודל ה-AI:  
- מאגרי מסמכים  
- בסיסי ידע  
- מקורות נתונים מובנים  
- מערכות קבצים  

### פרומפטים  
פרומפטים הם תבניות הודעות ותהליכי עבודה למשתמשים:  
- תבניות שיחה מוגדרות מראש  
- דפוסי אינטראקציה מודרכים  
- מבני דיאלוג מיוחדים  

### כלים  
כלים הם פונקציות שהמודל יכול לבצע:  
- כלי עיבוד נתונים  
- אינטגרציות עם API חיצוניים  
- יכולות חישוביות  
- פונקציונליות חיפוש  

## דוגמאות יישום: C#

ריפוזיטורי ה-SDK הרשמי של C# מכיל מספר דוגמאות שמדגימות היבטים שונים של MCP:

- **לקוח MCP בסיסי**: דוגמה פשוטה שמראה כיצד ליצור לקוח MCP ולהפעיל כלים  
- **שרת MCP בסיסי**: יישום שרת מינימלי עם רישום כלים בסיסי  
- **שרת MCP מתקדם**: שרת מלא עם רישום כלים, אימות וטיפול בשגיאות  
- **אינטגרציה עם ASP.NET**: דוגמאות המראות אינטגרציה עם ASP.NET Core  
- **דפוסי יישום כלים**: דפוסים שונים ליישום כלים ברמות מורכבות שונות  

ה-SDK של MCP ב-C# נמצא בבטא ו-APIs עשויים להשתנות. נעדכן את הבלוג באופן שוטף ככל שה-SDK יתפתח.

### תכונות מרכזיות  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- בניית [שרת MCP ראשון](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

למשאבי יישום מלאים ב-C#, בקר ב-[ריפוזיטורי הדוגמאות הרשמי של C#](https://github.com/modelcontextprotocol/csharp-sdk)

## דוגמת יישום: Java

ה-SDK של Java מציע אפשרויות יישום MCP חזקות עם תכונות ברמת ארגונית.

### תכונות מרכזיות

- אינטגרציה עם Spring Framework  
- בטיחות טיפוס חזקה  
- תמיכה בתכנות ריאקטיבי  
- טיפול שגיאות מקיף  

לדוגמה מלאה של יישום Java, ראה [דוגמת Java](samples/java/containerapp/README.md) בתיקיית הדוגמאות.

## דוגמת יישום: JavaScript

ה-SDK של JavaScript מספק גישה קלה וגמישה ליישום MCP.

### תכונות מרכזיות

- תמיכה ב-Node.js ודפדפן  
- API מבוסס Promise  
- אינטגרציה פשוטה עם Express ומסגרות נוספות  
- תמיכה ב-WebSocket לזרימה  

לדוגמה מלאה של יישום JavaScript, ראה [דוגמת JavaScript](samples/javascript/README.md) בתיקיית הדוגמאות.

## דוגמת יישום: Python

ה-SDK של Python מציע גישה פייתונית ליישום MCP עם אינטגרציות מצוינות למסגרות ML.

### תכונות מרכזיות

- תמיכה ב-async/await עם asyncio  
- אינטגרציה עם FastAPI  
- רישום כלים פשוט  
- אינטגרציה טבעית עם ספריות ML פופולריות  

לדוגמה מלאה של יישום Python, ראה [דוגמת Python](samples/python/README.md) בתיקיית הדוגמאות.

## ניהול API

Azure API Management היא פתרון מצוין לאבטחת שרתי MCP. הרעיון הוא למקם מופע Azure API Management מול שרת ה-MCP שלך ולתת לו לנהל תכונות שאתה צפוי להזדקק להן כמו:

- הגבלת קצב  
- ניהול טוקנים  
- ניטור  
- איזון עומסים  
- אבטחה  

### דוגמת Azure

הנה דוגמת Azure שעושה בדיוק את זה, כלומר [יצירת שרת MCP ואבטחתו עם Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

ראה כיצד מתבצע תהליך האישור בתמונה הבאה:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

בתמונה שלמעלה מתרחשים הדברים הבאים:

- אימות/הרשאה מתבצעים באמצעות Microsoft Entra.  
- Azure API Management פועל כשער ומשתמש במדיניות לניהול והכוונת התעבורה.  
- Azure Monitor רושם את כל הבקשות לניתוח נוסף.  

#### תהליך ההרשאה

בוא נבחן את תהליך ההרשאה ביתר פירוט:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### מפרט הרשאת MCP

למידע נוסף על [מפרט ההרשאה של MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## פריסת שרת MCP מרוחק ל-Azure

בוא נראה אם נוכל לפרוס את הדוגמה שהזכרנו קודם:

1. שכפל את הריפוזיטורי

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. רישום ספק המשאבים `Microsoft.App`.  
    * אם אתה משתמש ב-Azure CLI, הרץ `az provider register --namespace Microsoft.App --wait`.  
    * אם אתה משתמש ב-Azure PowerShell, הרץ `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. לאחר מכן הרץ `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` לאחר זמן מה כדי לבדוק אם הרישום הושלם.  

2. הרץ את הפקודה [azd](https://aka.ms/azd) כדי להקצות את שירות ניהול ה-API, אפליקציית הפונקציות (עם הקוד) וכל שאר המשאבים הנדרשים ב-Azure

    ```shell
    azd up
    ```

    פקודה זו אמורה לפרוס את כל משאבי הענן ב-Azure

### בדיקת השרת שלך עם MCP Inspector

1. בחלון טרמינל חדש, התקן והרץ את MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    תראה ממשק דומה ל:

    ![Connect to Node inspector](/03-GettingStarted/01-first-server/assets/connect.png) 

1. לחץ עם CTRL כדי לטעון את אפליקציית הווב של MCP Inspector מה-URL שמוצג על ידי האפליקציה (למשל http://127.0.0.1:6274/#resources)  
1. הגדר את סוג ההעברה ל-`SSE`  
1. הגדר את ה-URL לנקודת הקצה SSE של ניהול ה-API שלך שמוצגת לאחר `azd up` ולחץ **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **רשימת כלים**. לחץ על כלי ו**הרץ את הכלי**.  

אם כל השלבים בוצעו בהצלחה, כעת אתה מחובר לשרת MCP והצלחת להפעיל כלי.

## שרתי MCP ל-Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): אוסף ריפוזיטוריים זה הוא תבנית התחלה מהירה לבניית ופריסת שרתי MCP מרוחקים מותאמים אישית באמצעות Azure Functions עם Python, C# .NET או Node/TypeScript.

הדוגמאות מספקות פתרון מלא שמאפשר למפתחים:

- בנייה והרצה מקומית: פיתוח וניפוי שגיאות של שרת MCP במכונה מקומית  
- פריסה ל-Azure: פריסה פשוטה לענן באמצעות פקודת azd up  
- חיבור מלקוחות: חיבור לשרת MCP מלקוחות שונים כולל מצב סוכן Copilot ב-VS Code וכלי MCP Inspector  

### תכונות מרכזיות:

- אבטחה כברירת מחדל: שרת MCP מאובטח באמצעות מפתחות ו-HTTPS  
- אפשרויות אימות: תומך ב-OAuth באמצעות אימות מובנה ו/או ניהול API  
- בידוד רשת: מאפשר בידוד רשת באמצעות Azure Virtual Networks (VNET)  
- ארכיטקטורה ללא שרת: משתמש ב-Azure Functions לביצוע סקלאבילי ומונחה אירועים  
- פיתוח מקומי: תמיכה מקיפה בפיתוח וניפוי שגיאות מקומי  
- פריסה פשוטה: תהליך פריסה חלק ל-Azure  

הריפוזיטורי כולל את כל קבצי התצורה, קוד המקור והגדרות התשתית הדרושים כדי להתחיל במהירות עם יישום שרת MCP מוכן לייצור.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - דוגמת יישום MCP באמצעות Azure Functions עם Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - דוגמת יישום MCP באמצעות Azure Functions עם C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - דוגמת יישום MCP באמצעות Azure Functions עם Node/TypeScript.

## נקודות מפתח

- SDKs של MCP מספקים כלים ספציפיים לשפה ליישום פתרונות MCP יציבים  
- תהליך ניפוי השגיאות והבדיקה קריטי ליישומים אמינים  
- תבניות פרומפט לשימוש חוזר מאפשרות אינטראקציות AI עקביות  
- תהליכי עבודה מתוכננים היטב יכולים לתזמר משימות מורכבות באמצעות כלים מרובים  
- יישום פתרונות MCP דורש התייחסות לאבטחה, ביצועים וטיפול בשגיאות  

## תרגיל

עצב תהליך עבודה מעשי ב-MCP שמתמודד עם בעיה אמיתית בתחום שלך:

1. זהה 3-4 כלים שיהיו שימושיים לפתרון הבעיה  
2. צור דיאגרמת תהליך עבודה שמראה כיצד הכלים האלה מתקשרים  
3. יישם גרסה בסיסית של אחד הכלים בשפת התכנות המועדפת עליך  
4. צור תבנית פרומפט שתעזור למודל להשתמש בכלי שלך בצורה יעילה  

## משאבים נוספים


---

הבא: [נושאים מתקדמים](../05-AdvancedTopics/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. יש להתייחס למסמך המקורי בשפת המקור כמקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.