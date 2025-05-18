<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:24:57+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "he"
}
-->
# הפעלת הדוגמה הזו

מומלץ להתקין את `uv` אך זה לא חובה, ראו [הוראות](https://docs.astral.sh/uv/#highlights)

## -1- התקנת התלויות

```bash
npm install
```

## -3- הפעלת הדוגמה

```bash
npm run build
```

## -4- בדיקת הדוגמה

עם השרת פועל בטרמינל אחד, פתחו טרמינל נוסף והפעילו את הפקודה הבאה:

```bash
npm run inspector
```

זה אמור להפעיל שרת אינטרנט עם ממשק חזותי שמאפשר לבדוק את הדוגמה.

לאחר שהשרת מחובר:

- נסו לרשום כלים והפעילו `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` הוא מעטפת מסביבו.

ניתן להפעיל אותו ישירות במצב CLI על ידי הרצת הפקודה הבאה:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

זה ירשום את כל הכלים הזמינים בשרת. אמורים לראות את הפלט הבא:

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

כדי להפעיל כלי, הקלידו:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

אמורים לראות את הפלט הבא:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> בדרך כלל הרבה יותר מהיר להפעיל את המפקח במצב CLI מאשר בדפדפן.
> קראו עוד על המפקח [כאן](https://github.com/modelcontextprotocol/inspector).

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). בעוד שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עשויים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור סמכותי. למידע קריטי, מומלץ להשתמש בתרגום מקצועי על ידי בני אדם. אנו לא נושאים באחריות לאי הבנות או פרשנויות שגויות הנובעות מהשימוש בתרגום זה.