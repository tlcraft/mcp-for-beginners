<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:34:09+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "he"
}
-->
# Case Study: לחשוף REST API ב-API Management כשרת MCP

Azure API Management היא שירות שמספק שער (Gateway) מעל נקודות הקצה של ה-API שלך. האופן שבו זה עובד הוא ש-Azure API Management פועל כמו פרוקסי מול ה-APIs שלך ויכול להחליט מה לעשות עם הבקשות הנכנסות.

על ידי שימוש בו, אתה מוסיף מגוון רחב של תכונות כמו:

- **אבטחה**, ניתן להשתמש בכל דבר ממפתחות API, JWT ועד זהות מנוהלת.
- **הגבלת קצב**, תכונה מצוינת היא היכולת להחליט כמה קריאות יעברו בפרק זמן מסוים. זה עוזר להבטיח שכל המשתמשים יקבלו חווית שימוש טובה וגם שהשירות שלך לא יעמוס בבקשות.
- **סקיילינג ואיזון עומסים**. ניתן להגדיר מספר נקודות קצה לאיזון העומס וגם להחליט כיצד לבצע את "איזון העומס".
- **תכונות AI כמו semantic caching**, הגבלת טוקנים ומעקב אחר טוקנים ועוד. אלו תכונות מצוינות שמשפרות את התגובה וגם עוזרות לך לשלוט בהוצאות הטוקנים שלך. [קרא עוד כאן](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## למה MCP + Azure API Management?

Model Context Protocol הופך במהירות לסטנדרט לאפליקציות AI סוכניות וכיצד לחשוף כלים ונתונים בצורה עקבית. Azure API Management הוא בחירה טבעית כשאתה צריך "לנהל" APIs. שרתי MCP משתלבים לעיתים קרובות עם APIs אחרים כדי לפתור בקשות לכלי מסוים, לדוגמה. לכן השילוב בין Azure API Management ל-MCP הגיוני מאוד.

## סקירה כללית

במקרה שימוש ספציפי זה נלמד כיצד לחשוף נקודות קצה של API כשרת MCP. בכך, נוכל להפוך את נקודות הקצה הללו לחלק מאפליקציה סוכנית תוך ניצול התכונות של Azure API Management.

## תכונות עיקריות

- אתה בוחר את שיטות נקודת הקצה שברצונך לחשוף ככלים.
- התכונות הנוספות שתקבל תלויות במה שתגדיר במדור המדיניות עבור ה-API שלך. כאן נראה כיצד להוסיף הגבלת קצב.

## שלב מקדים: ייבוא API

אם כבר יש לך API ב-Azure API Management, מצוין, תוכל לדלג על שלב זה. אם לא, עיין בקישור זה, [ייבוא API ל-Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## לחשוף API כשרת MCP

כדי לחשוף את נקודות הקצה של ה-API, נעקוב אחרי השלבים הבאים:

1. עבור ל-Azure Portal בכתובת <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
   עבור למופע ה-API Management שלך.

1. בתפריט השמאלי, בחר APIs > MCP Servers > + Create new MCP Server.

1. ב-API, בחר REST API שברצונך לחשוף כשרת MCP.

1. בחר פעולה אחת או יותר של API שברצונך לחשוף ככלים. ניתן לבחור את כל הפעולות או רק פעולות ספציפיות.

    ![Select methods to expose](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. בחר **Create**.

1. עבור לתפריט **APIs** ו-**MCP Servers**, תראה את התצוגה הבאה:

    ![See the MCP Server in the main pane](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    שרת ה-MCP נוצר ופעולות ה-API נחשפו ככלים. שרת ה-MCP מופיע בלשונית MCP Servers. עמודת ה-URL מציגה את נקודת הקצה של שרת ה-MCP שניתן לקרוא לה לצורך בדיקות או בתוך אפליקציית לקוח.

## אופציונלי: הגדרת מדיניות

ל-Azure API Management יש את המושג המרכזי של מדיניות, שבו מגדירים כללים שונים לנקודות הקצה שלך, כמו הגבלת קצב או semantic caching. המדיניות מוגדרת ב-XML.

כך ניתן להגדיר מדיניות להגבלת קצב לשרת ה-MCP שלך:

1. בפורטל, תחת APIs, בחר **MCP Servers**.

1. בחר את שרת ה-MCP שיצרת.

1. בתפריט השמאלי, תחת MCP, בחר **Policies**.

1. בעורך המדיניות, הוסף או ערוך את המדיניות שברצונך להחיל על הכלים של שרת ה-MCP. המדיניות מוגדרת בפורמט XML. לדוגמה, ניתן להוסיף מדיניות להגבלת קריאות לכלי שרת ה-MCP (בדוגמה זו, 5 קריאות כל 30 שניות לכל כתובת IP של לקוח). הנה XML שיגרום להגבלת קצב:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    הנה תמונה של עורך המדיניות:

    ![Policy editor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## נסה את זה

בוא נוודא ששרת ה-MCP שלנו פועל כמתוכנן.

לשם כך נשתמש ב-Visual Studio Code וב-GitHub Copilot במצב סוכן (Agent mode). נוסיף את שרת ה-MCP ל-*mcp.json*. כך, Visual Studio Code יתפקד כלקוח עם יכולות סוכניות והמשתמשים יוכלו להקליד פקודה ולתקשר עם השרת.

כך מוסיפים את שרת ה-MCP ב-Visual Studio Code:

1. השתמש בפקודה MCP: **Add Server מה-Command Palette**.

1. כאשר תתבקש, בחר את סוג השרת: **HTTP (HTTP or Server Sent Events)**.

1. הזן את כתובת ה-URL של שרת ה-MCP ב-API Management. לדוגמה: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (לנקודת קצה SSE) או **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (לנקודת קצה MCP), שים לב שההבדל בין הפרוטוקולים הוא `/sse` או `/mcp`.

1. הזן מזהה שרת לבחירתך. זהו ערך לא קריטי אך יעזור לך לזכור איזו מופע שרת זה.

1. בחר אם לשמור את ההגדרות בהגדרות סביבת העבודה או בהגדרות המשתמש.

  - **הגדרות סביבת עבודה** - הגדרת השרת נשמרת בקובץ .vscode/mcp.json הזמין רק בסביבת העבודה הנוכחית.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    או אם תבחר ב-HTTP Streaming כפרוטוקול, זה יהיה מעט שונה:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **הגדרות משתמש** - הגדרת השרת מתווספת לקובץ *settings.json* הגלובלי שלך וזמינה בכל סביבת עבודה. ההגדרה נראית כך:

    ![User setting](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. בנוסף, יש להוסיף הגדרה של כותרת (header) כדי לוודא שהאימות מתבצע כראוי מול Azure API Management. משתמשים בכותרת בשם **Ocp-Apim-Subscription-Key**.

    - כך ניתן להוסיף אותה להגדרות:

    ![Adding header for authentication](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), פעולה זו תגרום להופעת חלון קלט שבו תתבקש להזין את מפתח ה-API שניתן למצוא ב-Azure Portal עבור מופע Azure API Management שלך.

   - כדי להוסיף זאת ל-*mcp.json* במקום זאת, ניתן להוסיף כך:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### שימוש במצב סוכן (Agent mode)

כעת הכל מוכן, בין אם בהגדרות המשתמש או בקובץ *.vscode/mcp.json*. בוא ננסה.

צריכה להופיע אייקון כלים (Tools) כך, שבו הכלים שנחשפו מהשרת שלך מופיעים:

![Tools from the server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. לחץ על אייקון הכלים ותראה רשימת כלים כך:

    ![Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. הזן פקודה בצ'אט כדי להפעיל את הכלי. לדוגמה, אם בחרת כלי לקבלת מידע על הזמנה, תוכל לשאול את הסוכן על הזמנה. הנה דוגמת פקודה:

    ```text
    get information from order 2
    ```

    כעת יוצג אייקון כלים שיבקש ממך לאשר הפעלת הכלי. בחר להמשיך ולהריץ את הכלי, כעת תראה פלט כך:

    ![Result from prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **מה שתראה תלוי בכלים שהגדרת, אך הרעיון הוא שתקבל תגובה טקסטואלית כמו למעלה**


## הפניות

כך תוכל ללמוד עוד:

- [מדריך על Azure API Management ו-MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [דוגמת Python: אבטחת שרתי MCP מרוחקים באמצעות Azure API Management (ניסיוני)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [מעבדת הרשאות לקוח MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [שימוש בתוסף Azure API Management ל-VS Code לייבוא וניהול APIs](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [רישום וגילוי שרתי MCP מרוחקים ב-Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) מאגר מצוין שמציג יכולות AI רבות עם Azure API Management
- [סדנאות AI Gateway](https://azure-samples.github.io/AI-Gateway/) מכילות סדנאות המשתמשות ב-Azure Portal, דרך מצוינת להתחיל להעריך יכולות AI.

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.