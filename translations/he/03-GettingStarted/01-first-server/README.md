<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bf05718d019040cf0c7d4ccc6d6a1a88",
  "translation_date": "2025-06-13T06:03:37+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "he"
}
-->
### -2- יצירת פרויקט

עכשיו כשיש לך את ה-SDK מותקן, בוא ניצור פרויקט בשלב הבא:

### -3- יצירת קבצי הפרויקט

### -4- כתיבת קוד השרת

### -5- הוספת כלי ומשאב

הוסף כלי ומשאב על ידי הוספת הקוד הבא:

### -6- קוד סופי

בוא נוסיף את הקוד האחרון שאנחנו צריכים כדי שהשרת יוכל להתחיל לפעול:

### -7- בדיקת השרת

הפעל את השרת עם הפקודה הבאה:

### -8- הפעלה באמצעות ה-Inspector

ה-Inspector הוא כלי מצוין שיכול להפעיל את השרת שלך ומאפשר לך לתקשר איתו כדי לבדוק שהוא פועל. בוא נתחיל:

> [!NOTE]
> ייתכן שהשדה "command" ייראה שונה כי הוא מכיל את הפקודה להפעלת השרת עם סביבת הריצה הספציפית שלך

אתה אמור לראות את ממשק המשתמש הבא:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.he.png)

1. התחבר לשרת על ידי לחיצה על כפתור Connect  
   ברגע שתתחבר לשרת, תראה את המסך הבא:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.he.png)

2. בחר ב-"Tools" ואז ב-"listTools", אתה אמור לראות את "Add" מופיע, בחר ב-"Add" ומלא את ערכי הפרמטרים.

   תקבל את התגובה הבאה, כלומר תוצאה מכלי "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.he.png)

כל הכבוד, הצלחת ליצור ולהפעיל את השרת הראשון שלך!

### SDKs רשמיים

MCP מספק SDKs רשמיים למספר שפות:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - מנוהל בשיתוף עם מיקרוסופט
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - מנוהל בשיתוף עם Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - המימוש הרשמי של TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - המימוש הרשמי של Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - המימוש הרשמי של Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - מנוהל בשיתוף עם Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - המימוש הרשמי של Rust

## נקודות מפתח

- הקמת סביבת פיתוח ל-MCP פשוטה עם SDKs ספציפיים לשפות
- בניית שרתי MCP כוללת יצירה והרשמה של כלים עם סכימות ברורות
- בדיקות ופתרון תקלות הם חיוניים למימושים אמינים של MCP

## דוגמאות

- [מחשבון Java](../samples/java/calculator/README.md)
- [מחשבון .Net](../../../../03-GettingStarted/samples/csharp)
- [מחשבון JavaScript](../samples/javascript/README.md)
- [מחשבון TypeScript](../samples/typescript/README.md)
- [מחשבון Python](../../../../03-GettingStarted/samples/python)

## משימה

צור שרת MCP פשוט עם כלי לבחירתך:
1. מימש את הכלי בשפתך המועדפת (.NET, Java, Python, או JavaScript).
2. הגדר פרמטרי קלט וערכי החזרה.
3. הפעל את כלי ה-Inspector כדי לוודא שהשרת פועל כמתוכנן.
4. בדוק את המימוש עם קלטים שונים.

## פתרון

[פתרון](./solution/README.md)

## משאבים נוספים

- [בניית סוכנים באמצעות Model Context Protocol ב-Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP מרוחק עם Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [סוכן OpenAI MCP ב-.NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## מה הלאה

הבא: [התחלה עם לקוחות MCP](/03-GettingStarted/02-client/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתירגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו צריך להיחשב כמקור הסמכותי. למידע קריטי מומלץ להיעזר בתרגום מקצועי על ידי אדם. אנו לא אחראים לכל אי-הבנות או פרשנויות שגויות הנובעות משימוש בתרגום זה.