<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-09T23:10:29+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "he"
}
-->
# הרצת הדוגמה הזו

מומלץ להתקין את `uv` אבל זה לא חובה, ראה [הוראות](https://docs.astral.sh/uv/#highlights)

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

## -3- הרצת הדוגמה

```bash
mcp run server.py
```

## -4- בדיקת הדוגמה

כאשר השרת רץ במסוף אחד, פתח מסוף נוסף והרץ את הפקודה הבאה:

```bash
mcp dev server.py
```

זה אמור להפעיל שרת אינטרנט עם ממשק חזותי שיאפשר לך לבדוק את הדוגמה.

ברגע שהשרת מחובר:

- נסה לרשום את הכלים ולהריץ את `add` עם הפרמטרים 2 ו-4, אתה אמור לראות 6 בתוצאה.

- עבור למשאבים ולתבנית המשאב וקרא ל-get_greeting, הקלד שם ואתה אמור לראות ברכה עם השם שהזנת.

### בדיקה במצב CLI

ה-inspector שהרצת הוא למעשה אפליקציית Node.js ו-`mcp dev` הוא עטיפה סביבו.

אתה יכול להפעיל אותו ישירות במצב CLI על ידי הרצת הפקודה הבאה:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
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

כדי להפעיל כלי הקלד:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

אתה אמור לראות את הפלט הבא:

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
> בדרך כלל הרבה יותר מהיר להריץ את ה-inspector במצב CLI מאשר בדפדפן.
> קרא עוד על ה-inspector [כאן](https://github.com/modelcontextprotocol/inspector).

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.