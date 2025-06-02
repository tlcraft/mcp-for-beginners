<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T17:04:28+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "he"
}
-->
### -2- צור פרויקט

עכשיו כשיש לך את ה-SDK מותקן, בוא ניצור פרויקט בשלב הבא:

### -3- צור קבצי פרויקט

### -4- צור את קוד השרת

### -5- הוספת כלי ומשאב

הוסף כלי ומשאב על ידי הוספת הקוד הבא:

### -6- קוד סופי

בוא נוסיף את הקוד האחרון הדרוש כדי שהשרת יוכל להתחיל לפעול:

### -7- בדוק את השרת

הפעל את השרת עם הפקודה הבאה:

### -8- הפעלה באמצעות ה-Inspector

ה-Inspector הוא כלי מצוין שיכול להפעיל את השרת שלך ומאפשר לך לתקשר איתו כדי לבדוק שהוא פועל. בוא נתחיל:

> [!NOTE]
> ייתכן שהשדה "command" ייראה שונה כי הוא מכיל את הפקודה להפעלת השרת עם סביבת הריצה הספציפית שלך

אתה אמור לראות את ממשק המשתמש הבא:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.he.png)

1. התחבר לשרת על ידי בחירת כפתור Connect  
   לאחר ההתחברות לשרת, תראה כעת את המסך הבא:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.he.png)

2. בחר ב-"Tools" ואז ב-"listTools", תראה את האפשרות "Add", בחר ב-"Add" ומלא את ערכי הפרמטרים.

   אתה אמור לראות את התגובה הבאה, כלומר תוצאה מהכלי "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.he.png)

כל הכבוד, הצלחת ליצור ולהפעיל את השרת הראשון שלך!

### SDKs רשמיים

MCP מספק SDKs רשמיים למספר שפות:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - מתוחזק בשיתוף עם מיקרוסופט
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - מתוחזק בשיתוף עם Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - מימוש רשמי ב-TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - מימוש רשמי ב-Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - מימוש רשמי ב-Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - מתוחזק בשיתוף עם Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - מימוש רשמי ב-Rust

## נקודות מרכזיות

- הקמת סביבת פיתוח ל-MCP פשוטה עם SDKs מותאמים לשפות השונות  
- בניית שרתי MCP כוללת יצירה ורישום של כלים עם סכימות ברורות  
- בדיקות וניפוי שגיאות הם חיוניים ליישום אמין של MCP  

## דוגמאות

- [מחשבון ב-Java](../samples/java/calculator/README.md)  
- [מחשבון ב-.Net](../../../../03-GettingStarted/samples/csharp)  
- [מחשבון ב-JavaScript](../samples/javascript/README.md)  
- [מחשבון ב-TypeScript](../samples/typescript/README.md)  
- [מחשבון ב-Python](../../../../03-GettingStarted/samples/python)  

## משימה

צור שרת MCP פשוט עם כלי לבחירתך:  
1. יישם את הכלי בשפתך המועדפת (.NET, Java, Python, או JavaScript).  
2. הגדר פרמטרי קלט וערכי החזרה.  
3. הפעל את כלי ה-Inspector כדי לוודא שהשרת פועל כמצופה.  
4. בדוק את היישום עם קלטים שונים.

## פתרון

[פתרון](./solution/README.md)

## משאבים נוספים

- [מאגר GitHub של MCP](https://github.com/microsoft/mcp-for-beginners)

## מה הלאה

הבא: [התחלת עבודה עם לקוחות MCP](/03-GettingStarted/02-client/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפת המקור שלו הוא המקור הסמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום מקצועי על ידי אדם. אנו לא נושאים באחריות לכל אי הבנה או פרשנות שגויה הנובעים משימוש בתרגום זה.