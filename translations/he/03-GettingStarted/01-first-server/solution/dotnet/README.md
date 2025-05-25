<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:10:49+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "he"
}
-->
# הרצת דוגמה זו

## -1- התקנת התלויות

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- הרצת הדוגמה

```bash
dotnet run
```

## -4- בדיקת הדוגמה

עם השרת פועל בטרמינל אחד, פתח טרמינל נוסף והפעל את הפקודה הבאה:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

זה אמור להפעיל שרת אינטרנט עם ממשק חזותי שיאפשר לך לבדוק את הדוגמה.

ברגע שהשרת מחובר:

- נסה לרשום כלים ולהפעיל `add`, עם ארגומנטים 2 ו-4, אתה אמור לראות 6 בתוצאה.
- עבור למשאבים ותבנית משאבים וקרא ל-"greeting", הקלד שם ואתה אמור לראות ברכה עם השם שסיפקת.

### בדיקה במצב CLI

ניתן להפעיל ישירות במצב CLI על ידי הרצת הפקודה הבאה:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

זה ירשום את כל הכלים הזמינים בשרת. אתה אמור לראות את הפלט הבא:

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

כדי להפעיל כלי, הקלד:

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
> בדרך כלל הרבה יותר מהיר להפעיל את המפקח במצב CLI מאשר בדפדפן.
> קרא עוד על המפקח [כאן](https://github.com/modelcontextprotocol/inspector).

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, אנא היו מודעים לכך שתרגומים אוטומטיים עשויים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור הסמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום מקצועי על ידי אדם. אנו לא נושאים באחריות לכל אי הבנות או פירושים שגויים הנובעים משימוש בתרגום זה.