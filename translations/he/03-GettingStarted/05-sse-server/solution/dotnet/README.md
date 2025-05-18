<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:57:15+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "he"
}
-->
# הפעלת הדוגמה הזו

## -1- התקן את התלויות

```bash
dotnet run
```

## -2- הפעל את הדוגמה

```bash
dotnet run
```

## -3- בדוק את הדוגמה

פתח מסוף נפרד לפני שאתה מריץ את הפקודה הבאה (ודא שהשרת עדיין פועל).

כשהשרת פועל במסוף אחד, פתח מסוף נוסף והרץ את הפקודה הבאה:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

זה אמור להפעיל שרת אינטרנט עם ממשק חזותי שיאפשר לך לבדוק את הדוגמה.

לאחר שהשרת מחובר:

- נסה לרשום כלים ולהריץ `add`, עם ארגומנטים 2 ו-4, אתה אמור לראות 6 בתוצאה.
- עבור למשאבים ותבנית משאבים וקרא ל"ברכה", הקלד שם ואתה אמור לראות ברכה עם השם שסיפקת.

### בדיקה במצב CLI

אתה יכול להפעיל אותו ישירות במצב CLI על ידי הרצת הפקודה הבאה:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

זה ירשום את כל הכלים הזמינים בשרת. אתה אמור לראות את הפלט הבא:

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

כדי להפעיל כלי, הקלד:

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
> בדרך כלל זה הרבה יותר מהיר להריץ את הבודק במצב CLI מאשר בדפדפן.
> קרא עוד על הבודק [כאן](https://github.com/modelcontextprotocol/inspector).

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). בעוד שאנו שואפים לדיוק, אנא היו מודעים לכך שתרגומים אוטומטיים עשויים להכיל טעויות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור הסמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום מקצועי אנושי. איננו אחראים לאי הבנות או פרשנויות מוטעות הנובעות משימוש בתרגום זה.