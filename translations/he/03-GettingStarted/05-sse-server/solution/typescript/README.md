<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:11:18+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "he"
}
-->
# הפעלת הדוגמה הזו

## -1- התקן את התלויות

```bash
npm install
```

## -3- הפעל את הדוגמה

```bash
npm run build
```

## -4- בדוק את הדוגמה

עם השרת פועל בטרמינל אחד, פתח טרמינל נוסף והפעל את הפקודה הבאה:

```bash
npm run inspector
```

זה אמור להתחיל שרת אינטרנט עם ממשק חזותי שמאפשר לך לבדוק את הדוגמה.

ברגע שהשרת מחובר:

- נסה לרשום כלים והפעל `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build`.

- בטרמינל נפרד הפעל את הפקודה הבאה:

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

- הפעל סוג כלי על ידי הקלדת הפקודה הבאה:

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
> בדרך כלל הרבה יותר מהר להפעיל את המפקח במצב CLI מאשר בדפדפן.
> קרא עוד על המפקח [כאן](https://github.com/modelcontextprotocol/inspector).

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). בעוד שאנו שואפים לדיוק, אנא היו מודעים לכך שתרגומים אוטומטיים עשויים להכיל טעויות או אי דיוקים. יש לראות במסמך המקורי בשפתו המקורית את המקור הסמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום מקצועי אנושי. אנו לא נושאים באחריות לאי הבנות או פרשנויות שגויות הנובעות מהשימוש בתרגום זה.