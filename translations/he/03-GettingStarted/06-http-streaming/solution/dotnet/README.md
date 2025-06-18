<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:18:23+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
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

הפעל טרמינל נפרד לפני שתריץ את הפקודה הבאה (ודא שהשרת עדיין רץ).

כאשר השרת רץ בטרמינל אחד, פתח טרמינל נוסף והרץ את הפקודה הבאה:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

זה אמור להפעיל שרת ווב עם ממשק ויזואלי שיאפשר לך לבדוק את הדוגמה.

> ודא שסוג ההעברה שנבחר הוא **Streamable HTTP**, וה-URL הוא `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, עם הפרמטרים 2 ו-4, תראה 6 בתוצאה.
- עבור ל-resources ו-resource template וקרא ל-"greeting", הקלד שם ותראה ברכה עם השם שהזנת.

### בדיקה במצב CLI

אתה יכול להפעיל זאת ישירות במצב CLI על ידי הרצת הפקודה הבאה:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

זה יציג את כל הכלים הזמינים בשרת. אתה אמור לראות את הפלט הבא:

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
> בדרך כלל הרבה יותר מהיר להפעיל את ה-inspector במצב CLI מאשר בדפדפן.
> קרא עוד על ה-inspector [כאן](https://github.com/modelcontextprotocol/inspector).

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפתו המקורית נחשב למקור המוסמך. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי אדם. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעים משימוש בתרגום זה.