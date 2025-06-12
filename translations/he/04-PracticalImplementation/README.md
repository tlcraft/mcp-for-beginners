<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:19:36+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "he"
}
-->
# יישום מעשי

היישום המעשי הוא המקום שבו הכוח של Model Context Protocol (MCP) הופך מוחשי. בעוד שהבנת התיאוריה והארכיטקטורה מאחורי MCP חשובה, הערך האמיתי מתגלה כאשר אתם מיישמים את המושגים האלו כדי לבנות, לבדוק ולפרוס פתרונות שפועלים על בעיות מהעולם האמיתי. פרק זה גשר בין הידע התיאורטי לפיתוח מעשי, ומנחה אתכם בתהליך הבאת יישומים מבוססי MCP לחיים.

בין אם אתם מפתחים עוזרים חכמים, משולבים AI בתהליכי עבודה עסקיים, או בונים כלים מותאמים לעיבוד נתונים, MCP מספקת בסיס גמיש. העיצוב הלא תלוי בשפה וה-SDKs הרשמיים לשפות תכנות פופולריות מאפשרים גישה למגוון רחב של מפתחים. באמצעות ניצול ה-SDKs הללו, תוכלו במהירות ליצור אב-טיפוס, לחזור על פיתוח ולהגדיל את הפתרונות שלכם על פני פלטפורמות וסביבות שונות.

בקטעים הבאים תמצאו דוגמאות מעשיות, קוד לדוגמה ואסטרטגיות פריסה שמדגימות כיצד ליישם MCP ב-C#, Java, TypeScript, JavaScript ו-Python. תלמדו גם כיצד לדבג ולבדוק שרתי MCP, לנהל APIs ולפרוס פתרונות לענן באמצעות Azure. המשאבים המעשים האלו נועדו להאיץ את הלמידה שלכם ולעזור לכם לבנות בביטחון יישומים יציבים ומוכנים לייצור מבוססי MCP.

## סקירה כללית

השיעור מתמקד בהיבטים מעשיים של יישום MCP במגוון שפות תכנות. נחקור כיצד להשתמש ב-SDKs של MCP ב-C#, Java, TypeScript, JavaScript ו-Python כדי לבנות יישומים יציבים, לדבג ולבדוק שרתי MCP, וליצור משאבים, פרומפטים וכלים שניתן להשתמש בהם שוב.

## מטרות למידה

בסיום השיעור תוכלו:
- ליישם פתרונות MCP באמצעות ה-SDKs הרשמיים בשפות תכנות שונות
- לדבג ולבדוק שרתי MCP באופן שיטתי
- ליצור ולהשתמש בתכונות שרת (משאבים, פרומפטים וכלים)
- לתכנן תהליכי עבודה יעילים ל-MCP למשימות מורכבות
- לאופטימיזציה של יישומי MCP לביצועים ואמינות

## משאבים רשמיים של SDK

Model Context Protocol מציע SDKs רשמיים למספר שפות:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## עבודה עם SDKs של MCP

חלק זה מספק דוגמאות מעשיות ליישום MCP במגוון שפות תכנות. תוכלו למצוא קוד לדוגמה בתיקיית `samples` הממוינת לפי שפה.

### דוגמאות זמינות

הרפוזיטורי כולל יישומים לדוגמה בשפות הבאות:

- C#
- Java
- TypeScript
- JavaScript
- Python

כל דוגמה מציגה מושגי MCP מרכזיים ודפוסי יישום לשפה ולאקוסיסטם הספציפי.

## תכונות מרכזיות של השרת

שרתי MCP יכולים ליישם כל שילוב מהתכונות הבאות:

### משאבים
משאבים מספקים הקשר ונתונים למשתמש או למודל AI להשתמש בהם:
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
כלים הם פונקציות שהמודל AI יכול להפעיל:
- כלי עיבוד נתונים
- אינטגרציות API חיצוניות
- יכולות חישוביות
- פונקציונליות חיפוש

## דוגמאות יישום: C#

הרפוזיטורי הרשמי של C# SDK מכיל מספר דוגמאות שמדגימות היבטים שונים של MCP:

- **לקוח MCP בסיסי**: דוגמה פשוטה שמראה כיצד ליצור לקוח MCP ולהפעיל כלים
- **שרת MCP בסיסי**: יישום שרת מינימלי עם רישום כלים בסיסי
- **שרת MCP מתקדם**: שרת מלא תכונות עם רישום כלים, אימות וטיפול בשגיאות
- **אינטגרציה עם ASP.NET**: דוגמאות שמדגימות אינטגרציה עם ASP.NET Core
- **דפוסי יישום כלים**: דפוסים שונים ליישום כלים ברמות מורכבות שונות

ה-SDK של MCP ל-C# נמצא במצב תצוגה מקדימה ו-APIs עשויים להשתנות. נעדכן את הבלוג הזה בהתפתחות ה-SDK.

### תכונות מרכזיות
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- בניית [שרת MCP ראשון](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

לדוגמאות יישום מלאות ב-C# בקרו ב-[רפוזיטורי הדוגמאות הרשמי של C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## דוגמאות יישום: יישום Java

ה-SDK של Java מציע אפשרויות יישום MCP יציבות עם תכונות ברמת ארגונים.

### תכונות מרכזיות

- אינטגרציה עם Spring Framework
- בטיחות טיפוס חזקה
- תמיכה בתכנות ריאקטיבי
- טיפול מקיף בשגיאות

לדוגמת יישום Java מלאה ראו את [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) בתיקיית הדוגמאות.

## דוגמאות יישום: יישום JavaScript

ה-SDK של JavaScript מספק גישה קלה וגמישה ליישום MCP.

### תכונות מרכזיות

- תמיכה ב-Node.js ובדפדפן
- API מבוסס Promise
- אינטגרציה פשוטה עם Express ומסגרות נוספות
- תמיכה ב-WebSocket לזרימה

לדוגמת יישום JavaScript מלאה ראו את [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) בתיקיית הדוגמאות.

## דוגמאות יישום: יישום Python

ה-SDK של Python מציע גישה פייתונית ליישום MCP עם אינטגרציות מצוינות למסגרות ML.

### תכונות מרכזיות

- תמיכה ב-async/await עם asyncio
- אינטגרציה עם Flask ו-FastAPI
- רישום כלים פשוט
- אינטגרציה מקורית עם ספריות ML פופולריות

לדוגמת יישום Python מלאה ראו את [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) בתיקיית הדוגמאות.

## ניהול API

Azure API Management הוא פתרון מצוין לשאלה כיצד לאבטח שרתי MCP. הרעיון הוא למקם מופע Azure API Management מול שרת ה-MCP שלכם ולתת לו לטפל בתכונות שתרצו, כמו:

- הגבלת קצב
- ניהול טוקנים
- ניטור
- איזון עומסים
- אבטחה

### דוגמת Azure

זוהי דוגמת Azure שעושה בדיוק את זה, כלומר [יצירת שרת MCP ואבטחתו עם Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

ראו כיצד מתבצע תהליך האישור בתמונה הבאה:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

בתמונה שלמעלה מתרחשים הדברים הבאים:

- אימות/הרשאה מתבצעים באמצעות Microsoft Entra.
- Azure API Management משמש כשער ומנהל תנועה באמצעות מדיניות.
- Azure Monitor רושם את כל הבקשות לניתוח נוסף.

#### תהליך הרשאה

בואו נבחן את תהליך ההרשאה ביתר פירוט:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### מפרט הרשאת MCP

למידע נוסף על [מפרט ההרשאה של MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## פריסת שרת MCP מרוחק ל-Azure

בואו נראה אם נוכל לפרוס את הדוגמה שהזכרנו קודם:

1. שיבוט הרפוזיטורי

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. רישום `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` ובדיקה לאחר זמן מה אם הרישום הושלם.

3. הרצת הפקודה [azd](https://aka.ms/azd) כדי לספק את שירות ניהול ה-API, אפליקציית הפונקציות (עם הקוד) וכל שאר המשאבים הנדרשים ב-Azure

    ```shell
    azd up
    ```

    פקודה זו אמורה לפרוס את כל המשאבים בענן ב-Azure

### בדיקת השרת עם MCP Inspector

1. בחלון טרמינל חדש, התקינו והפעילו את MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    תראו ממשק דומה ל:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.he.png)

2. לחצו CTRL כדי לטעון את אפליקציית האינטרנט של MCP Inspector מה-URL שמוצג באפליקציה (למשל http://127.0.0.1:6274/#resources)
3. הגדירו את סוג ההעברה ל-`SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` ולחצו **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **רשימת כלים**. לחצו על כלי ובצעו **Run Tool**.

אם כל השלבים בוצעו בהצלחה, אתם כעת מחוברים לשרת MCP והצלחתם לקרוא לכלי.

## שרתי MCP עבור Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): סט רפוזיטוריות זה הוא תבנית התחלה מהירה לבניית ופריסת שרתי MCP מרוחקים מותאמים אישית באמצעות Azure Functions עם Python, C# .NET או Node/TypeScript.

הדוגמאות מספקות פתרון שלם שמאפשר למפתחים:

- בנייה והרצה מקומית: פיתוח ודיבוג שרת MCP במכונה מקומית
- פריסה ל-Azure: פריסה פשוטה לענן עם פקודת azd up
- חיבור מלקוחות: חיבור לשרת MCP מלקוחות שונים כולל מצב סוכן Copilot של VS Code וכלי MCP Inspector

### תכונות מרכזיות:

- אבטחה כברירת מחדל: שרת MCP מאובטח באמצעות מפתחות ו-HTTPS
- אפשרויות אימות: תמיכה ב-OAuth עם אימות מובנה ו/או ניהול API
- בידוד רשת: מאפשר בידוד רשת באמצעות רשתות וירטואליות של Azure (VNET)
- ארכיטקטורה ללא שרת: משתמש ב-Azure Functions לביצוע סקלאבילי ומונחה אירועים
- פיתוח מקומי: תמיכה מקיפה בפיתוח ודיבוג מקומי
- פריסה פשוטה: תהליך פריסה פשוט ל-Azure

הרפוזיטורי כולל את כל קבצי הקונפיגורציה, קוד המקור והגדרות התשתית הדרושים כדי להתחיל במהירות עם יישום שרת MCP מוכן לייצור.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - דוגמת יישום MCP באמצעות Azure Functions עם Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - דוגמת יישום MCP באמצעות Azure Functions עם C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - דוגמת יישום MCP באמצעות Azure Functions עם Node/TypeScript.

## נקודות מפתח

- SDKs של MCP מספקים כלים ספציפיים לשפות ליישום פתרונות MCP יציבים
- תהליך הדיבוג והבדיקה קריטי ליישומים אמינים של MCP
- תבניות פרומפט שניתן להשתמש בהן שוב מאפשרות אינטראקציות AI עקביות
- תהליכי עבודה מתוכננים היטב יכולים לתזמן משימות מורכבות באמצעות כלים מרובים
- יישום פתרונות MCP דורש התייחסות לאבטחה, ביצועים וטיפול בשגיאות

## תרגיל

תכננו תהליך עבודה מעשי ל-MCP שמטפל בבעיה מהעולם האמיתי בתחום שלכם:

1. זיהוי 3-4 כלים שיהיו שימושיים לפתרון הבעיה
2. יצירת דיאגרמת תהליך עבודה שמראה כיצד הכלים האלו מתקשרים
3. יישום גרסה בסיסית של אחד הכלים בשפה המועדפת עליכם
4. יצירת תבנית פרומפט שתעזור למודל להשתמש בכלי שלכם ביעילות

## משאבים נוספים


---

הבא: [Advanced Topics](../05-AdvancedTopics/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עלולים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי אנושי. אנו לא נושאים באחריות לכל אי הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.