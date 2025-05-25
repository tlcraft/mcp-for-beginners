<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:56:53+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "he"
}
-->
# הפעלת הדוגמה הזו

הדוגמה הזו כוללת שימוש ב-LLM על הלקוח. ה-LLM דורש ממך להריץ את זה ב-Codespaces או להגדיר אסימון גישה אישי ב-GitHub כדי שזה יעבוד.

## -1- התקנת התלויות

```bash
npm install
```

## -3- הפעלת השרת

```bash
npm run build
```

## -4- הפעלת הלקוח

```sh
npm run client
```

אתה אמור לראות תוצאה דומה ל:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, אנא היו מודעים לכך שתרגומים אוטומטיים עשויים להכיל טעויות או אי דיוקים. יש להתייחס למסמך המקורי בשפתו המקורית כמקור סמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום מקצועי אנושי. אנו לא נושאים באחריות לאי הבנות או פרשנויות שגויות הנובעות משימוש בתרגום זה.