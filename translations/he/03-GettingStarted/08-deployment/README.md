<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:54:05+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "he"
}
-->
# פריסת שרתי MCP

פריסת שרת ה-MCP שלך מאפשרת לאחרים לגשת לכלים ולמשאבים שלו מעבר לסביבת העבודה המקומית שלך. ישנן מספר אסטרטגיות פריסה שכדאי לשקול, בהתאם לדרישות שלך מבחינת יכולת הרחבה, אמינות ונוחות ניהול. למטה תמצא הנחיות לפריסת שרתי MCP מקומית, במיכלים ובענן.

## סקירה כללית

שיעור זה מכסה כיצד לפרוס את אפליקציית שרת ה-MCP שלך.

## מטרות למידה

בסוף השיעור הזה, תוכל:

- להעריך גישות פריסה שונות.
- לפרוס את האפליקציה שלך.

## פיתוח ופריסה מקומית

אם השרת שלך מיועד לצריכה על ידי ריצה במחשב המשתמשים, תוכל לעקוב אחר השלבים הבאים:

1. **הורד את השרת**. אם לא כתבת את השרת, אז הורד אותו תחילה למחשב שלך.
1. **הפעל את תהליך השרת**: הפעל את אפליקציית שרת ה-MCP שלך

ל-SSE (לא נדרש לשרת מסוג stdio)

1. **הגדר רשתות**: ודא שהשרת נגיש על הפורט הצפוי
1. **חבר לקוחות**: השתמש בכתובות URL לחיבור מקומי כמו `http://localhost:3000`

## פריסת ענן

שרתי MCP יכולים להיות פרוסים לפלטפורמות ענן שונות:

- **פונקציות ללא שרת**: פרוס שרתי MCP קלים כפונקציות ללא שרת
- **שירותי מיכלים**: השתמש בשירותים כמו Azure Container Apps, AWS ECS או Google Cloud Run
- **Kubernetes**: פרוס ונהל שרתי MCP באשכולות Kubernetes לזמינות גבוהה

### דוגמה: Azure Container Apps

Azure Container Apps תומך בפריסת שרתי MCP. זה עדיין בעבודה ותומך כרגע בשרתים מסוג SSE.

כך תוכל לעשות זאת:

1. שיבוט מאגר:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. הפעל אותו מקומית כדי לבדוק דברים:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. כדי לנסות אותו מקומית, צור קובץ *mcp.json* בתיקיית *.vscode* והוסף את התוכן הבא:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  ברגע ששרת ה-SSE מופעל, תוכל ללחוץ על סמל ההפעלה בקובץ ה-JSON, כעת עליך לראות את הכלים על השרת מזוהים על ידי GitHub Copilot, ראה את סמל הכלי.

1. כדי לפרוס, הפעל את הפקודה הבאה:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

זהו, פרוס אותו מקומית, פרוס אותו ל-Azure דרך השלבים האלה.

## משאבים נוספים

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [מאמר על Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [מאגר Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## מה הלאה

- הבא: [יישום מעשי](/04-PracticalImplementation/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עשויים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור הסמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום מקצועי על ידי אדם. אנו לא נושאים באחריות לאי הבנות או פירושים שגויים הנובעים משימוש בתרגום זה.