<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-07-13T20:10:53+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "he"
}
-->
# הרצת הדוגמה הזו

## -1- התקן את התלויות

```bash
dotnet restore
```

## -2- הרץ את הדוגמה

```bash
dotnet run
```

## -3- בדוק את הדוגמה

פתח טרמינל נפרד לפני הרצת הפקודה הבאה (ודא שהשרת עדיין רץ).

כאשר השרת רץ בטרמינל אחד, פתח טרמינל נוסף והריץ את הפקודה הבאה:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

זה אמור להפעיל שרת ווב עם ממשק חזותי שיאפשר לך לבדוק את הדוגמה.

> ודא ש-**SSE** נבחר כסוג ההעברה, וכתובת ה-URL היא `http://localhost:3001/sse`.

כאשר השרת מחובר:

- נסה לרשום את הכלים ולהריץ את `add` עם הפרמטרים 2 ו-4, התוצאה צריכה להיות 6.
- עבור למשאבים ולתבנית המשאב וקרא ל-"greeting", הקלד שם ותראה ברכה עם השם שהזנת.

### בדיקה במצב CLI

ניתן להפעיל ישירות במצב CLI על ידי הרצת הפקודה הבאה:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

זה ירשום את כל הכלים הזמינים בשרת. התוצאה צריכה להיות:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

כדי להפעיל כלי הקלד:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

התוצאה צריכה להיות:

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
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי אדם. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.