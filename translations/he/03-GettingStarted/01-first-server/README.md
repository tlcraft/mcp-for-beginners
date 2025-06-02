<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:12:44+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "he"
}
-->
### -2- יצירת פרויקט

עכשיו כשיש לך את ה-SDK מותקן, בוא ניצור פרויקט בשלב הבא:

### -3- יצירת קבצי הפרויקט

### -4- יצירת קוד השרת

### -5- הוספת כלי ומשאב

הוסף כלי ומשאב על ידי הוספת הקוד הבא:

### -6 קוד סופי

בוא נוסיף את הקוד האחרון שצריך כדי שהשרת יוכל להתחיל לפעול:

### -7- בדיקת השרת

הפעל את השרת עם הפקודה הבאה:

### -8- הפעלה באמצעות ה-Inspector

ה-Inspector הוא כלי מעולה שיכול להפעיל את השרת שלך ומאפשר לך לתקשר איתו כדי לבדוק שהוא עובד. בוא נתחיל:

> [!NOTE]
> ייתכן שזה ייראה שונה בשדה "command" כיוון שהוא מכיל את הפקודה להפעלת שרת עם סביבת הריצה הספציפית שלך

אתה אמור לראות את ממשק המשתמש הבא:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.he.png)

1. התחבר לשרת על ידי בחירת כפתור Connect  
   לאחר שהתחברת לשרת, תראה את המסך הבא:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.he.png)

2. בחר ב-"Tools" ואז ב-"listTools", תראה את האפשרות "Add" מופיעה, בחר ב-"Add" ומלא את ערכי הפרמטרים.

   תקבל את התגובה הבאה, כלומר תוצאה מכלי ה-"add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.he.png)

כל הכבוד, הצלחת ליצור ולהפעיל את השרת הראשון שלך!

### SDK רשמיים

MCP מספק SDK רשמיים למספר שפות:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - מתוחזק בשיתוף עם מיקרוסופט
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - מתוחזק בשיתוף עם Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - המימוש הרשמי של TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - המימוש הרשמי של Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - המימוש הרשמי של Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - מתוחזק בשיתוף עם Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - המימוש הרשמי של Rust

## נקודות מרכזיות

- הקמת סביבת פיתוח ל-MCP היא פשוטה עם SDK ספציפיים לשפות
- בניית שרתי MCP כוללת יצירה ורישום של כלים עם סכימות ברורות
- בדיקות וניפוי שגיאות חיוניים למימושים אמינים של MCP

## דוגמאות

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## משימה

צור שרת MCP פשוט עם כלי לפי בחירתך:  
1. מימש את הכלי בשפת התכנות המועדפת עליך (.NET, Java, Python, או JavaScript).  
2. הגדר פרמטרי קלט וערכי החזרה.  
3. הפעל את כלי ה-Inspector כדי לוודא שהשרת פועל כמצופה.  
4. בדוק את המימוש עם קלטים שונים.

## פתרון

[פתרון](./solution/README.md)

## משאבים נוספים

- [מאגר MCP ב-GitHub](https://github.com/microsoft/mcp-for-beginners)

## מה הלאה

הבא: [התחלה עם לקוחות MCP](/03-GettingStarted/02-client/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. איננו אחראים לכל אי הבנה או פרשנות שגויה הנובעים משימוש בתרגום זה.