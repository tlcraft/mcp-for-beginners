<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fae57a69c2b62cb7d92ff12da65f36c3",
  "translation_date": "2025-05-17T10:10:22+00:00",
  "source_file": "03-GettingStarted/02-client/solution/typescript/README.md",
  "language_code": "he"
}
-->
# הפעלת הדוגמה הזו

מומלץ להתקין `uv` אבל זה לא חובה, ראו [הוראות](https://docs.astral.sh/uv/#highlights)

## -1- התקן את התלויות

```bash
npm install
```

## -3- הפעל את השרת

```bash
npm run build
```

## -4- הפעל את הלקוח

```sh
npm run client
```

אתה אמור לראות תוצאה דומה ל:

```text
Prompt:  {
  type: 'text',
  text: 'Please review this code:\n\nconsole.log("hello");'
}
Resource template:  file
Tool result:  { content: [ { type: 'text', text: '9' } ] }
```

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). אנו שואפים לדיוק, אך יש להיות מודעים לכך שתרגומים אוטומטיים עשויים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור הסמכותי. למידע קריטי, מומלץ להשתמש בתרגום מקצועי על ידי בני אדם. איננו אחראים לכל אי הבנה או פירוש מוטעה הנובע מהשימוש בתרגום זה.