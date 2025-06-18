<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T06:03:25+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "he"
}
-->
# הרצת הדוגמה הזו

## -1- התקן את התלויות

```bash
dotnet restore
```

## -3- הרץ את הדוגמה


```bash
dotnet run
```

## -4- בדוק את הדוגמה

כששרת רץ בטורמינל אחד, פתח טורמינל נוסף והריץ את הפקודה הבאה:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

זה אמור להפעיל שרת ווב עם ממשק חזותי שמאפשר לך לבדוק את הדוגמה.

ברגע שהשרת מחובר:

- נסה לרשום את הכלים ולהריץ את `add` עם הפרמטרים 2 ו-4, אתה אמור לראות 6 בתוצאה.
- עבור ל-resources ול-resource template וקרא ל-"greeting", הקלד שם ואתה אמור לראות ברכה עם השם שהזנת.

### בדיקה במצב CLI

אתה יכול להפעיל אותו ישירות במצב CLI על ידי הרצת הפקודה הבאה:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

זה יציג את כל הכלים הזמינים בשרת. אתה אמור לראות את הפלט הבא:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
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
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

אתה אמור לראות את הפלט הבא:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> בדרך כלל הרבה יותר מהיר להריץ את ה-inspector במצב CLI מאשר בדפדפן.
> קרא עוד על ה-inspector [כאן](https://github.com/modelcontextprotocol/inspector).

**כתב ויתור:**  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו צריך להיחשב כמקור הסמכות. למידע קריטי מומלץ להשתמש בתרגום מקצועי אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.