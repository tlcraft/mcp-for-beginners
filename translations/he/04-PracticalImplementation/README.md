<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:56:03+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "he"
}
-->
# יישום מעשי

יישום מעשי הוא המקום שבו כוחו של פרוטוקול הקשר המודל (MCP) הופך למוחשי. בעוד שהבנת התיאוריה והארכיטקטורה שמאחורי MCP היא חשובה, הערך האמיתי מתגלה כשמיישמים את הרעיונות הללו לבנייה, בדיקה ופריסה של פתרונות שמעניקים מענה לבעיות בעולם האמיתי. פרק זה מגשר על הפער בין ידע תיאורטי לפיתוח מעשי, ומדריך אותך בתהליך של הבאת יישומים מבוססי MCP לחיים.

בין אם אתה מפתח עוזרים חכמים, משלב AI לתוך תהליכי עבודה עסקיים, או בונה כלים מותאמים לעיבוד נתונים, MCP מספק בסיס גמיש. עיצובו שאינו תלוי בשפה ו-SDKs רשמיים לשפות תכנות פופולריות הופכים אותו לנגיש למגוון רחב של מפתחים. על ידי ניצול SDKs אלו, תוכל במהירות ליצור אב טיפוס, לחזור ולשפר את הפתרונות שלך על פני פלטפורמות וסביבות שונות.

בקטעים הבאים תמצא דוגמאות מעשיות, קוד לדוגמה ואסטרטגיות פריסה שמדגימות כיצד ליישם MCP ב-C#, Java, TypeScript, JavaScript ו-Python. תלמד גם כיצד לנפות ולבדוק את שרתי MCP שלך, לנהל APIs ולפרוס פתרונות לענן באמצעות Azure. המשאבים המעשיים הללו נועדו להאיץ את הלמידה שלך ולעזור לך לבנות בביטחון יישומי MCP חזקים ומוכנים לייצור.

## סקירה כללית

שיעור זה מתמקד בהיבטים מעשיים של יישום MCP על פני שפות תכנות שונות. נחקור כיצד להשתמש ב-SDKs של MCP ב-C#, Java, TypeScript, JavaScript ו-Python כדי לבנות יישומים חזקים, לנפות ולבדוק שרתי MCP, וליצור משאבים, הנחיות וכלים לשימוש חוזר.

## מטרות הלמידה

בסיום השיעור הזה, תהיה מסוגל:
- ליישם פתרונות MCP באמצעות SDKs רשמיים בשפות תכנות שונות
- לנפות ולבדוק שרתי MCP באופן שיטתי
- ליצור ולהשתמש בתכונות שרת (משאבים, הנחיות וכלים)
- לעצב תהליכי עבודה יעילים של MCP למשימות מורכבות
- לייעל יישומי MCP לביצועים ואמינות

## משאבי SDK רשמיים

פרוטוקול הקשר המודל מציע SDKs רשמיים למספר שפות:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## עבודה עם SDKs של MCP

קטע זה מספק דוגמאות מעשיות ליישום MCP על פני שפות תכנות שונות. תוכל למצוא קוד לדוגמה בתיקיית `samples` מאורגנת לפי שפה.

### דוגמאות זמינות

המאגר כולל יישומים לדוגמה בשפות הבאות:

- C#
- Java
- TypeScript
- JavaScript
- Python

כל דוגמה מדגימה מושגי MCP מרכזיים ודפוסי יישום עבור אותה שפה ואקוסיסטם ספציפיים.

## תכונות שרת ליבה

שרתי MCP יכולים ליישם כל שילוב של התכונות הללו:

### משאבים
משאבים מספקים הקשר ונתונים עבור המשתמש או מודל ה-AI לשימוש:
- מאגרי מסמכים
- בסיסי ידע
- מקורות נתונים מובנים
- מערכות קבצים

### הנחיות
הנחיות הן הודעות ותהליכי עבודה מתוכננים עבור משתמשים:
- תבניות שיחה מוגדרות מראש
- דפוסי אינטראקציה מודרכים
- מבני דיאלוג מיוחדים

### כלים
כלים הם פונקציות עבור מודל ה-AI לביצוע:
- כלי עיבוד נתונים
- שילובים של API חיצוניים
- יכולות חישוביות
- פונקציונליות חיפוש

## יישומים לדוגמה: C#

המאגר הרשמי של C# SDK מכיל מספר יישומים לדוגמה המדגימים היבטים שונים של MCP:

- **לקוח MCP בסיסי**: דוגמה פשוטה המראה כיצד ליצור לקוח MCP ולקרוא לכלים
- **שרת MCP בסיסי**: יישום שרת מינימלי עם רישום כלי בסיסי
- **שרת MCP מתקדם**: שרת מלא עם רישום כלי, אימות וטיפול בשגיאות
- **שילוב ASP.NET**: דוגמאות המדגימות שילוב עם ASP.NET Core
- **דפוסי יישום כלי**: דפוסים שונים ליישום כלים עם רמות מורכבות שונות

ה-SDK של MCP ב-C# נמצא בתצוגה מקדימה ו-APIs עשויים להשתנות. נעדכן את הבלוג הזה באופן רציף ככל שה-SDK מתפתח.

### תכונות מפתח 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- בניית [שרת MCP הראשון שלך](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

לצפייה ביישומים מלאים ב-C#, בקר במאגר הדוגמאות הרשמי של [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## יישום לדוגמה: יישום Java

ה-SDK של Java מציע אפשרויות יישום MCP חזקות עם תכונות ברמה ארגונית.

### תכונות מפתח

- שילוב עם Spring Framework
- בטיחות סוגים חזקה
- תמיכה בתכנות תגובתי
- טיפול שגיאות מקיף

לצפייה ביישום Java מלא, ראה [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) בתיקיית הדוגמאות.

## יישום לדוגמה: יישום JavaScript

ה-SDK של JavaScript מספק גישה קלה וגמישה ליישום MCP.

### תכונות מפתח

- תמיכה ב-Node.js ודפדפן
- API מבוסס הבטחות
- שילוב קל עם Express ומסגרות אחרות
- תמיכה ב-WebSocket להזרמה

לצפייה ביישום JavaScript מלא, ראה [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) בתיקיית הדוגמאות.

## יישום לדוגמה: יישום Python

ה-SDK של Python מציע גישה פייתונית ליישום MCP עם שילובים מצוינים של מסגרות ML.

### תכונות מפתח

- תמיכה ב-Async/await עם asyncio
- שילוב עם Flask ו-FastAPI
- רישום כלי פשוט
- שילוב ילידי עם ספריות ML פופולריות

לצפייה ביישום Python מלא, ראה [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) בתיקיית הדוגמאות.

## ניהול API

ניהול API של Azure הוא תשובה מצוינת לשאלה כיצד ניתן לאבטח שרתי MCP. הרעיון הוא לשים מופע ניהול API של Azure לפני שרת ה-MCP שלך ולתת לו לטפל בתכונות שאתה עשוי לרצות כמו:

- הגבלת קצב
- ניהול אסימונים
- ניטור
- איזון עומסים
- אבטחה

### דוגמת Azure

הנה דוגמת Azure שעושה בדיוק את זה, כלומר [יצירת שרת MCP ואבטחתו עם ניהול API של Azure](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

ראה כיצד מתרחש תהליך האישור בתמונה למטה:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

בתמונה הקודמת, מתרחש הדבר הבא:

- אימות/אישור מתרחש באמצעות Microsoft Entra.
- ניהול API של Azure פועל כשער ומשתמש במדיניות כדי לכוון ולנהל תעבורה.
- Azure Monitor רושם את כל הבקשות לניתוח נוסף.

#### תהליך האישור

בואו נסתכל על תהליך האישור בצורה מפורטת יותר:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### מפרט אישור MCP

למד עוד על [מפרט אישור MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## פריסת שרת MCP מרוחק ל-Azure

בואו נראה אם נוכל לפרוס את הדוגמה שהזכרנו קודם:

1. לשכפל את המאגר

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. לרשום `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` לאחר זמן מה כדי לבדוק אם ההרשמה הושלמה.

2. להריץ את הפקודה הזו [azd](https://aka.ms/azd) כדי להקצות את שירות ניהול ה-API, אפליקציית פונקציה (עם קוד) וכל משאבי Azure הנדרשים האחרים

    ```shell
    azd up
    ```

    פקודה זו צריכה לפרוס את כל משאבי הענן ב-Azure

### בדיקת השרת שלך עם MCP Inspector

1. ב**חלון טרמינל חדש**, התקן והרץ את MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    אתה אמור לראות ממשק דומה ל:

    ![Connect to Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.he.png)

1. לחץ על CTRL כדי לטעון את אפליקציית הווב MCP Inspector מה-URL שמוצג על ידי האפליקציה (למשל http://127.0.0.1:6274/#resources)
1. הגדר את סוג התחבורה ל`SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` ולחץ על **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **רשום כלים**. לחץ על כלי ו**הרץ כלי**.  

אם כל השלבים עבדו, אתה אמור להיות מחובר לשרת MCP והיית מסוגל לקרוא לכלי.

## שרתי MCP עבור Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): סט זה של מאגרים הוא תבנית התחלה מהירה לבניית ופריסת שרתי MCP מרוחקים מותאמים אישית באמצעות פונקציות Azure עם Python, C# .NET או Node/TypeScript. 

הדוגמאות מספקות פתרון מלא שמאפשר למפתחים:

- לבנות ולהריץ מקומית: לפתח ולנפות שרת MCP במחשב מקומי
- לפרוס ל-Azure: לפרוס בקלות לענן עם פקודת azd up פשוטה
- להתחבר מלקוחות: להתחבר לשרת MCP ממגוון לקוחות כולל מצב סוכן של VS Code Copilot וכלי MCP Inspector

### תכונות מפתח:

- אבטחה בעיצוב: שרת MCP מאובטח באמצעות מפתחות ו-HTTPS
- אפשרויות אימות: תומך ב-OAuth באמצעות אימות מובנה ו/או ניהול API
- בידוד רשת: מאפשר בידוד רשת באמצעות רשתות וירטואליות של Azure (VNET)
- ארכיטקטורה חסרת שרת: מנצל פונקציות Azure לביצוע ניתן להרחבה, מונע אירועים
- פיתוח מקומי: תמיכה מקיפה בפיתוח וניפוי שגיאות מקומיים
- פריסה פשוטה: תהליך פריסה פשוט ל-Azure

המאגר כולל את כל קבצי התצורה הדרושים, קוד המקור והגדרות התשתית כדי להתחיל במהירות עם יישום שרת MCP מוכן לייצור.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - יישום לדוגמה של MCP באמצעות פונקציות Azure עם Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - יישום לדוגמה של MCP באמצעות פונקציות Azure עם C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - יישום לדוגמה של MCP באמצעות פונקציות Azure עם Node/TypeScript.

## נקודות מפתח

- SDKs של MCP מספקים כלים ספציפיים לשפה ליישום פתרונות MCP חזקים
- תהליך הניפוי ובדיקת השגיאות קריטי ליישומי MCP אמינים
- תבניות הנחיות לשימוש חוזר מאפשרות אינטראקציות AI עקביות
- תהליכי עבודה מעוצבים היטב יכולים לארגן משימות מורכבות באמצעות כלים מרובים
- יישום פתרונות MCP דורש התחשבות באבטחה, ביצועים וטיפול בשגיאות

## תרגיל

עצב תהליך עבודה מעשי של MCP שמטפל בבעיה בעולם האמיתי בתחום שלך:

1. זיהוי 3-4 כלים שיהיו מועילים לפתרון בעיה זו
2. צור דיאגרמת תהליך עבודה שמראה כיצד כלים אלו מתקשרים
3. יישם גרסה בסיסית של אחד הכלים באמצעות השפה המועדפת עליך
4. צור תבנית הנחיה שתעזור למודל להשתמש ביעילות בכלי שלך

## משאבים נוספים

---

הבא: [נושאים מתקדמים](../05-AdvancedTopics/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). בעוד אנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עשויים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור סמכותי. למידע קריטי, מומלץ להשתמש בתרגום מקצועי אנושי. אנו לא נושאים באחריות לכל אי הבנות או פרשנויות שגויות הנובעות משימוש בתרגום זה.