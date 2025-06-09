<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:39:19+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "he"
}
-->
### -2- יצירת פרויקט

עכשיו כשהתקנת את ה-SDK, בוא ניצור פרויקט בשלב הבא:

### -3- יצירת קבצי הפרויקט

### -4- כתיבת קוד השרת

### -5- הוספת כלי ומשאב

הוסף כלי ומשאב על ידי הוספת הקוד הבא:

### -6- קוד סופי

בוא נוסיף את הקוד האחרון שאנחנו צריכים כדי שהשרת יוכל להתחיל לפעול:

### -7- בדיקת השרת

הפעל את השרת עם הפקודה הבאה:

### -8- הפעלה באמצעות ה-Inspector

ה-Inspector הוא כלי מצוין שיכול להפעיל את השרת שלך ומאפשר לך לתקשר איתו כדי לבדוק שהוא פועל כראוי. בוא נתחיל:

> [!NOTE]
> ייתכן שהשדה "command" ייראה שונה כי הוא מכיל את הפקודה להרצת השרת עם סביבת הריצה הספציפית שלך.

אתה אמור לראות את ממשק המשתמש הבא:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.he.png)

1. התחבר לשרת על ידי בחירת כפתור Connect  
   לאחר ההתחברות לשרת, תראה את המסך הבא:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.he.png)

2. בחר ב-"Tools" ואז ב-"listTools", תראה את הכפתור "Add" מופיע, לחץ עליו ומלא את ערכי הפרמטרים.

   תראה את התגובה הבאה, כלומר תוצאה מהכלי "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.he.png)

כל הכבוד, הצלחת ליצור ולהפעיל את השרת הראשון שלך!

### SDKs רשמיים

MCP מספק SDKs רשמיים למספר שפות:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - מתוחזק בשיתוף עם Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - מתוחזק בשיתוף עם Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - מימוש רשמי ב-TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - מימוש רשמי בפייתון
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - מימוש רשמי בקוטלין
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - מתוחזק בשיתוף עם Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - מימוש רשמי ב-Rust

## נקודות מפתח

- הקמת סביבת פיתוח ל-MCP פשוטה עם SDK ספציפיים לשפות
- בניית שרתי MCP כוללת יצירה ורישום של כלים עם סכימות ברורות
- בדיקות וניפוי שגיאות הם חיוניים ליישום MCP אמין

## דוגמאות

- [מחשבון ב-Java](../samples/java/calculator/README.md)
- [מחשבון ב-.Net](../../../../03-GettingStarted/samples/csharp)
- [מחשבון ב-JavaScript](../samples/javascript/README.md)
- [מחשבון ב-TypeScript](../samples/typescript/README.md)
- [מחשבון ב-Python](../../../../03-GettingStarted/samples/python)

## משימה

צור שרת MCP פשוט עם כלי לבחירתך:
1. מימוש הכלי בשפתך המועדפת (.NET, Java, Python, או JavaScript).
2. הגדרת פרמטרי קלט וערכי החזרה.
3. הרץ את כלי ה-inspector כדי לוודא שהשרת פועל כמצופה.
4. בדוק את המימוש עם קלטים שונים.

## פתרון

[פתרון](./solution/README.md)

## משאבים נוספים

- [בניית סוכנים באמצעות Model Context Protocol ב-Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP מרוחק עם Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [סוכן MCP ב-.NET OpenAI](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## מה הלאה

הבא: [התחלה עם לקוחות MCP](/03-GettingStarted/02-client/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו הוא המקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי של אדם. איננו אחראים לכל אי-הבנות או פרשנויות שגויות הנובעות מהשימוש בתרגום זה.