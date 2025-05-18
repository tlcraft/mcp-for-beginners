<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:04:17+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "he"
}
-->
# הפעלת הדוגמה הזו

מומלץ להתקין את `uv`, אבל זה לא חובה. ראו [הוראות](https://docs.astral.sh/uv/#highlights)

## -0- יצירת סביבה וירטואלית

```bash
python -m venv venv
```

## -1- הפעלת הסביבה הווירטואלית

```bash
venv\Scrips\activate
```

## -2- התקנת התלויות

```bash
pip install "mcp[cli]"
```

## -3- הפעלת הדוגמה

```bash
mcp run server.py
```

## -4- בדיקת הדוגמה

עם השרת פועל בחלון טרמינל אחד, פתחו חלון טרמינל נוסף והפעילו את הפקודה הבאה:

```bash
mcp dev server.py
```

זה אמור להפעיל שרת אינטרנט עם ממשק חזותי שיאפשר לכם לבדוק את הדוגמה.

ברגע שהשרת מחובר:

- נסו לרשום כלים ולהפעיל `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` הוא עוטף אותו.

ניתן להפעיל אותו ישירות במצב CLI על ידי הפעלת הפקודה הבאה:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

זה יפרט את כל הכלים הזמינים בשרת. אתם אמורים לראות את הפלט הבא:

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
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

אתם אמורים לראות את הפלט הבא:

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
> בדרך כלל מהיר יותר להפעיל את הבודק במצב CLI מאשר בדפדפן.
> קראו עוד על הבודק [כאן](https://github.com/modelcontextprotocol/inspector).

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). בעוד אנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עשויים להכיל טעויות או אי-דיוקים. יש להתייחס למסמך המקורי בשפתו המקורית כמקור סמכותי. עבור מידע קריטי, מומלץ להשתמש בשירותי תרגום מקצועיים של בני אדם. אנו לא אחראים לכל אי הבנה או פרשנות שגויה הנובעות משימוש בתרגום זה.