<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "69ba3bd502bd743233137bac5539c08b",
  "translation_date": "2025-08-18T16:58:13+00:00",
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
uvicorn server:app
```

## -4- בדיקת הדוגמה

כאשר השרת פועל בחלון טרמינל אחד, פתחו חלון טרמינל נוסף והריצו את הפקודה הבאה:

```bash
mcp dev server.py
```

זה אמור להפעיל שרת אינטרנט עם ממשק חזותי שיאפשר לכם לבדוק את הדוגמה.

לאחר שהשרת מחובר:

- נסו להציג את רשימת הכלים ולהריץ את `add`, עם הפרמטרים 2 ו-4. אתם אמורים לראות 6 בתוצאה.
- עברו למשאבים ולתבנית המשאבים וקראו ל-`get_greeting`. הקלידו שם, ואתם אמורים לראות ברכה עם השם שסיפקתם.

### בדיקה במצב CLI

ה-Inspector שהרצתם הוא למעשה אפליקציית Node.js, ו-`mcp dev` הוא מעטפת סביבה עבורה.

ניתן להפעיל אותו ישירות במצב CLI על ידי הרצת הפקודה הבאה:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

זה יציג את כל הכלים הזמינים בשרת. אתם אמורים לראות את הפלט הבא:

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

> [!TIP]  
> בדרך כלל מהיר יותר להריץ את ה-Inspector במצב CLI מאשר בדפדפן.  
> קראו עוד על ה-Inspector [כאן](https://github.com/modelcontextprotocol/inspector).

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון שתרגומים אוטומטיים עשויים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור סמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום מקצועי על ידי אדם. איננו נושאים באחריות לאי הבנות או לפרשנויות שגויות הנובעות משימוש בתרגום זה.