<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:21:15+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "he"
}
-->
# הרצת הדוגמה הזו

## -1- התקן את התלויות

```bash
npm install
```

## -3- הרץ את הדוגמה


```bash
npm run build
```

## -4- בדוק את הדוגמה

עם השרת פועל במסוף אחד, פתח מסוף נוסף והרץ את הפקודה הבאה:

```bash
npm run inspector
```

זה אמור להפעיל שרת ווב עם ממשק חזותי שיאפשר לך לבדוק את הדוגמה.

ברגע שהשרת מחובר:

- נסה לרשום את הכלים ולהריץ את `add` עם הפרמטרים 2 ו-4, אתה אמור לראות 6 בתוצאה.
- עבור למשאבים ולתבנית המשאב וקרא ל-"greeting", הקלד שם ואתה אמור לראות ברכה עם השם שהזנת.

### בדיקה במצב CLI

ה- inspector שהרצת הוא למעשה אפליקציית Node.js ו- `mcp dev` הוא עטיפה סביבו.

- הפעל את השרת עם הפקודה `npm run build`.

- במסוף נפרד הרץ את הפקודה הבאה:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    זה ירשום את כל הכלים הזמינים בשרת. אתה אמור לראות את הפלט הבא:

    ```text
    {
    "tools": [
        {
        "name": "add",
        "description": "Add two numbers",
        "inputSchema": {
            "type": "object",
            "properties": {
            "a": {
                "title": "A",
                "type": "integer"
            },
            "b": {
                "title": "B",
                "type": "integer"
            }
            },
            "required": [
            "a",
            "b"
            ],
            "title": "addArguments"
        }
        }
    ]
    }
    ```

- הפעל כלי על ידי הקלדת הפקודה הבאה:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

אתה אמור לראות את הפלט הבא:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> בדרך כלל הרבה יותר מהיר להריץ את ה-inspector במצב CLI מאשר בדפדפן.
> קרא עוד על ה-inspector [כאן](https://github.com/modelcontextprotocol/inspector).

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.