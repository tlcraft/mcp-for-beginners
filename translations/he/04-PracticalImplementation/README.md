<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:18:42+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "he"
}
-->
# יישום מעשי

היישום המעשי הוא המקום שבו כוחו של Model Context Protocol (MCP) מתגשם במציאות. בעוד שהבנת התיאוריה והארכיטקטורה שמאחורי MCP חשובה, הערך האמיתי מתגלה כאשר אתם מיישמים את המושגים האלו לבניית, בדיקה ופריסה של פתרונות שפועלים בבעיות אמיתיות. פרק זה מגשר על הפער בין הידע התיאורטי לפיתוח מעשי, ומנחה אתכם בתהליך של הבאת יישומים מבוססי MCP לחיים.

בין אם אתם מפתחים עוזרים חכמים, משולבים בינה מלאכותית בתהליכי עבודה עסקיים, או בונים כלים מותאמים לעיבוד נתונים, MCP מספק בסיס גמיש. העיצוב הבלתי תלוי בשפה ו-SDKs הרשמיים לשפות תכנות פופולריות מאפשרים גישה למגוון רחב של מפתחים. באמצעות ניצול SDKs אלו, תוכלו ליצור אב-טיפוס במהירות, לבצע איטרציות ולהרחיב את הפתרונות שלכם על פני פלטפורמות וסביבות שונות.

בקטעים הבאים תמצאו דוגמאות מעשיות, קוד לדוגמה ואסטרטגיות פריסה שמדגימות כיצד ליישם MCP ב-C#, Java, TypeScript, JavaScript ו-Python. תלמדו גם כיצד לנפות שגיאות ולבדוק את שרתי MCP שלכם, לנהל APIs, ולפרוס פתרונות לענן באמצעות Azure. המשאבים המעשיים הללו מיועדים להאיץ את הלמידה שלכם ולעזור לכם לבנות בביטחון יישומים יציבים ומוכנים לייצור מבוססי MCP.

## סקירה כללית

השיעור מתמקד בהיבטים מעשיים של יישום MCP בשפות תכנות שונות. נחקור כיצד להשתמש ב-SDKs של MCP ב-C#, Java, TypeScript, JavaScript ו-Python כדי לבנות יישומים יציבים, לנפות שגיאות ולבדוק שרתי MCP, וליצור משאבים, פקודות וכלים לשימוש חוזר.

## מטרות הלמידה

בסוף השיעור תוכלו:
- ליישם פתרונות MCP באמצעות SDKs רשמיים בשפות תכנות שונות
- לנפות שגיאות ולבדוק שרתי MCP בצורה שיטתית
- ליצור ולהשתמש בתכונות שרת (משאבים, פקודות וכלים)
- לתכנן תזרימי עבודה יעילים ל-MCP למשימות מורכבות
- לאופטם יישומי MCP לביצועים ואמינות

## משאבי SDK רשמיים

Model Context Protocol מציע SDKs רשמיים למספר שפות:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## עבודה עם SDKs של MCP

קטע זה מספק דוגמאות מעשיות ליישום MCP בשפות תכנות שונות. תוכלו למצוא קוד לדוגמה בתיקיית `samples` המאורגנת לפי שפה.

### דוגמאות זמינות

הרפוזיטורי כולל [יישומים לדוגמה](../../../04-PracticalImplementation/samples) בשפות הבאות:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

כל דוגמה מדגימה מושגי MCP מרכזיים ודפוסי יישום עבור שפה ואקוסיסטם ספציפיים.

## תכונות מרכזיות של השרת

שרתי MCP יכולים ליישם כל שילוב של התכונות הבאות:

### משאבים
משאבים מספקים הקשר ונתונים לשימוש המשתמש או מודל ה-AI:
- מאגרי מסמכים
- בסיסי ידע
- מקורות נתונים מובנים
- מערכות קבצים

### פקודות
פקודות הן הודעות ותזרימי עבודה מתבניתים למשתמשים:
- תבניות שיחה מוגדרות מראש
- דפוסי אינטראקציה מודרכים
- מבני דיאלוג מיוחדים

### כלים
כלים הם פונקציות שמודל ה-AI יכול לבצע:
- כלי עיבוד נתונים
- אינטגרציות עם APIs חיצוניים
- יכולות חישוביות
- פונקציונליות חיפוש

## דוגמאות יישום: C#

רפוזיטורי ה-C# הרשמי מכיל מספר דוגמאות שמדגימות היבטים שונים של MCP:

- **לקוח MCP בסיסי**: דוגמה פשוטה שמראה כיצד ליצור לקוח MCP ולהפעיל כלים
- **שרת MCP בסיסי**: יישום שרת מינימלי עם רישום כלים בסיסי
- **שרת MCP מתקדם**: שרת מלא תכונות עם רישום כלים, אימות וטיפול בשגיאות
- **אינטגרציה עם ASP.NET**: דוגמאות המראות אינטגרציה עם ASP.NET Core
- **דפוסי יישום כלים**: דפוסים שונים ליישום כלים ברמות מורכבות שונות

ה-SDK של MCP ל-C# נמצא במצב תצוגה מוקדמת ו-APIs עשויים להשתנות. נעדכן את הבלוג הזה בהתפתחות ה-SDK.

### תכונות מרכזיות  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- בניית [שרת MCP ראשון](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

למשאבים מלאים של דוגמאות ליישום ב-C#, בקרו ב-[רפוזיטורי הרשמי של SDK ל-C#](https://github.com/modelcontextprotocol/csharp-sdk)

## דוגמא ליישום: יישום ב-Java

ה-SDK של Java מציע אפשרויות יישום MCP חזקות עם תכונות ברמת ארגונית.

### תכונות מרכזיות

- אינטגרציה עם Spring Framework
- בטיחות טיפוס חזקה
- תמיכה בתכנות ריאקטיבי
- טיפול שגיאות מקיף

לדוגמה מלאה ליישום ב-Java ראו את [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) בתיקיית הדוגמאות.

## דוגמא ליישום: יישום ב-JavaScript

ה-SDK של JavaScript מספק גישה קלה וגמישה ליישום MCP.

### תכונות מרכזיות

- תמיכה ב-Node.js ודפדפן
- API מבוסס Promise
- אינטגרציה פשוטה עם Express ומסגרות נוספות
- תמיכה ב-WebSocket לזרימה

לדוגמה מלאה ליישום ב-JavaScript ראו את [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) בתיקיית הדוגמאות.

## דוגמא ליישום: יישום ב-Python

ה-SDK של Python מציע גישה פייתונית ליישום MCP עם אינטגרציות מצוינות למסגרות ML.

### תכונות מרכזיות

- תמיכה ב-async/await עם asyncio
- אינטגרציה עם Flask ו-FastAPI
- רישום כלים פשוט
- אינטגרציה טבעית עם ספריות ML פופולריות

לדוגמה מלאה ליישום ב-Python ראו את [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) בתיקיית הדוגמאות.

## ניהול API

Azure API Management היא פתרון מצוין לאבטחת שרתי MCP. הרעיון הוא למקם מופע Azure API Management מול שרת MCP ולתת לו לנהל תכונות שאתם צפויים לרצות כגון:

- הגבלת קצב
- ניהול אסימונים
- ניטור
- איזון עומסים
- אבטחה

### דוגמת Azure

הנה דוגמת Azure שמבצעת בדיוק זאת, כלומר [יצירת שרת MCP ואבטחתו באמצעות Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

ראו כיצד מתבצע תהליך האישור בתמונה למטה:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

בתמונה שלמעלה מתרחשים הדברים הבאים:

- אימות/הרשאה מתבצעים באמצעות Microsoft Entra.
- Azure API Management פועל כשער ומשתמש במדיניות לניהול והכוונת התנועה.
- Azure Monitor מתעד את כל הבקשות לניתוח נוסף.

#### תהליך האישור

בואו נבחן את תהליך האישור ביתר פירוט:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### מפרט אישור MCP

למידע נוסף ראו את [מפרט האישור של MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## פריסת שרת MCP מרוחק ל-Azure

בואו נראה אם נוכל לפרוס את הדוגמה שהזכרנו קודם:

1. שיבוט הרפוזיטורי

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. רישום `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` לאחר זמן מה לבדוק אם הרישום הושלם.

3. הרצת הפקודה [azd](https://aka.ms/azd) כדי לספק את שירות ניהול ה-API, אפליקציית הפונקציות (עם קוד) וכל שאר משאבי Azure הנדרשים

    ```shell
    azd up
    ```

    פקודות אלו אמורות לפרוס את כל המשאבים בענן ב-Azure

### בדיקת השרת עם MCP Inspector

1. בחלון טרמינל חדש, התקינו והפעילו את MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    תראו ממשק דומה ל:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.he.png) 

2. לחצו על CTRL ופתחו את אפליקציית ה-MCP Inspector מה-URL שמוצג באפליקציה (למשל http://127.0.0.1:6274/#resources)
3. הגדירו את סוג התעבורה ל-`SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` ולחצו **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **רשימת כלים**. לחצו על כלי ולחצו **Run Tool**.

אם כל השלבים עברו בהצלחה, כעת אתם מחוברים לשרת MCP והצלחתם לקרוא לכלי.

## שרתי MCP עבור Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): אוסף רפוזיטוריים שמספק תבנית התחלה מהירה לבניית ופריסת שרתי MCP מרוחקים מותאמים אישית באמצעות Azure Functions ב-Python, C# .NET או Node/TypeScript.

הדוגמאות מספקות פתרון מלא שמאפשר למפתחים:

- בנייה והרצה מקומית: פיתוח וניפוי שגיאות של שרת MCP במחשב מקומי
- פריסה ל-Azure: פריסה פשוטה לענן עם פקודת azd up
- חיבור מלקוחות: חיבור לשרת MCP מלקוחות שונים כולל מצב סוכן Copilot של VS Code וכלי MCP Inspector

### תכונות מרכזיות:

- אבטחה מעוצבת מראש: שרת MCP מאובטח באמצעות מפתחות ו-HTTPS
- אפשרויות אימות: תמיכה ב-OAuth באמצעות אימות מובנה ו/או ניהול API
- בידוד רשת: מאפשר בידוד רשת באמצעות Azure Virtual Networks (VNET)
- ארכיטקטורה ללא שרת: ניצול Azure Functions לביצוע סקלאבילי ומונחה אירועים
- פיתוח מקומי: תמיכה מלאה בפיתוח וניפוי שגיאות מקומי
- פריסה פשוטה: תהליך פריסה חלק ל-Azure

הרפוזיטורי כולל את כל קבצי התצורה, קוד המקור והגדרות התשתית הדרושים כדי להתחיל במהירות עם יישום שרת MCP מוכן לייצור.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - דוגמת יישום MCP באמצעות Azure Functions עם Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - דוגמת יישום MCP באמצעות Azure Functions עם C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - דוגמת יישום MCP באמצעות Azure Functions עם Node/TypeScript.

## נקודות מרכזיות

- SDKs של MCP מספקים כלים ייעודיים לשפות ליישום פתרונות MCP יציבים
- תהליך ניפוי השגיאות והבדיקה קריטי ליישומים אמינים של MCP
- תבניות פקודות לשימוש חוזר מאפשרות אינטראקציות עקביות עם AI
- תזרימי עבודה מתוכננים היטב יכולים לארגן משימות מורכבות עם כלים מרובים
- יישום פתרונות MCP דורש התייחסות לאבטחה, ביצועים וטיפול בשגיאות

## תרגיל

עצבו תזרימי עבודה מעשיים ל-MCP שמטפלים בבעיה אמיתית בתחום שלכם:

1. זיהוי 3-4 כלים שיהיו שימושיים לפתרון הבעיה
2. יצירת דיאגרמת תזרימי עבודה שמראה כיצד הכלים האלו מתקשרים
3. יישום גרסה בסיסית של אחד הכלים בשפת התכנות המועדפת עליכם
4. יצירת תבנית פקודה שתסייע למודל להשתמש בכלי שלכם ביעילות

## משאבים נוספים


---

הבא: [נושאים מתקדמים](../05-AdvancedTopics/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. יש להתייחס למסמך המקורי בשפתו המקורית כמקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי שנעשה על ידי אדם. אנו לא נושאים באחריות לכל אי הבנה או פרשנות שגויה הנובעת מהשימוש בתרגום זה.