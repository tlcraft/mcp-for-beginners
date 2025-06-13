<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:30:47+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "he"
}
-->
# פריסת שרתי MCP

פריסת שרת MCP שלך מאפשרת לאחרים לגשת לכלים ולמשאבים שלו מעבר לסביבה המקומית שלך. ישנן מספר אסטרטגיות פריסה שכדאי לשקול, בהתאם לדרישות שלך להרחבה, אמינות ונוחות ניהול. למטה תמצא הנחיות לפריסת שרתי MCP באופן מקומי, במכולות ובענן.

## סקירה כללית

השיעור הזה עוסק באיך לפרוס את אפליקציית שרת MCP שלך.

## מטרות הלמידה

בסיום השיעור תוכל:

- להעריך גישות פריסה שונות.
- לפרוס את האפליקציה שלך.

## פיתוח ופריסה מקומית

אם השרת שלך מיועד לשימוש על ידי הרצתו במחשב המשתמש, תוכל לבצע את השלבים הבאים:

1. **הורד את השרת**. אם לא כתבת את השרת, הורד אותו קודם כל למחשב שלך.
1. **הפעל את תהליך השרת**: הרץ את אפליקציית שרת MCP שלך.

ל-SSE (לא נדרש לשרת מסוג stdio)

1. **הגדר את הרשת**: ודא שהשרת נגיש בפורט הצפוי.
1. **חבר לקוחות**: השתמש בכתובות חיבור מקומיות כמו `http://localhost:3000`.

## פריסה בענן

ניתן לפרוס שרתי MCP בפלטפורמות ענן שונות:

- **Serverless Functions**: פרוס שרתי MCP קלים כפונקציות ללא שרת.
- **Container Services**: השתמש בשירותים כמו Azure Container Apps, AWS ECS, או Google Cloud Run.
- **Kubernetes**: פרוס ונהל שרתי MCP באשכולות Kubernetes לזמינות גבוהה.

### דוגמה: Azure Container Apps

Azure Container Apps תומך בפריסת שרתי MCP. זה עדיין בתהליך פיתוח והוא תומך כרגע בשרתי SSE.

כך תוכל לעשות זאת:

1. שיבט את הריפוזיטורי:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. הרץ את זה מקומית כדי לבדוק:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. כדי לנסות מקומית, צור קובץ *mcp.json* בתיקיית *.vscode* והוסף את התוכן הבא:

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

  ברגע ששרת SSE מופעל, תוכל ללחוץ על אייקון ההפעלה בקובץ JSON, כעת תראה שכלים מהשרת נלקחים על ידי GitHub Copilot, ראה את אייקון הכלי.

1. לפריסה, הרץ את הפקודה הבאה:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

זה הכל, פרוס מקומית, פרוס ל-Azure דרך השלבים האלה.

## משאבים נוספים

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps article](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## מה הלאה

- הבא: [Practical Implementation](/04-PracticalImplementation/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו צריך להיחשב כמקור הסמכות. למידע קריטי מומלץ להשתמש בתרגום מקצועי שנעשה על ידי אדם. אנו לא נישא באחריות לכל אי-הבנה או פרשנות שגויה הנובעות משימוש בתרגום זה.