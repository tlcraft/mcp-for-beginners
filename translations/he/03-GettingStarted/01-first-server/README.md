<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d5b044c0924d393af3066e03d7d89c5",
  "translation_date": "2025-07-16T09:47:37+00:00",
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

### -6 קוד סופי

בוא נוסיף את הקוד האחרון שאנחנו צריכים כדי שהשרת יוכל להתחיל לפעול:

### -7- בדוק את השרת

הפעל את השרת עם הפקודה הבאה:

### -8- הפעלה באמצעות ה-Inspector

ה-Inspector הוא כלי מצוין שיכול להפעיל את השרת שלך ומאפשר לך לתקשר איתו כדי לבדוק שהוא עובד. בוא נתחיל אותו:
> [!NOTE]
> זה עשוי להיראות שונה בשדה "command" כי הוא מכיל את הפקודה להרצת שרת עם סביבת הריצה הספציפית שלך/
אתה אמור לראות את ממשק המשתמש הבא:

![Connect](/03-GettingStarted/01-first-server/assets/connect.png)

1. התחבר לשרת על ידי בחירת כפתור Connect  
   ברגע שתתחבר לשרת, אמור להופיע הדבר הבא:

   ![Connected](/03-GettingStarted/01-first-server/assets/connected.png)

1. בחר ב-"Tools" ואז ב-"listTools", אמור להופיע "Add", בחר ב-"Add" ומלא את ערכי הפרמטרים.

   אמור להופיע התגובה הבאה, כלומר תוצאה מהכלי "add":

   ![Result of running add](/03-GettingStarted/01-first-server/assets/ran-tool.png)

מזל טוב, הצלחת ליצור ולהפעיל את השרת הראשון שלך!

### SDKs רשמיים

MCP מספק SDKs רשמיים למספר שפות:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - מתוחזק בשיתוף עם מיקרוסופט  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - מתוחזק בשיתוף עם Spring AI  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - המימוש הרשמי של TypeScript  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - המימוש הרשמי של Python  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - המימוש הרשמי של Kotlin  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - מתוחזק בשיתוף עם Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - המימוש הרשמי של Rust  

## נקודות מפתח

- הקמת סביבת פיתוח ל-MCP פשוטה עם SDKs ספציפיים לשפה  
- בניית שרתי MCP כוללת יצירה ורישום של כלים עם סכימות ברורות  
- בדיקות וניפוי שגיאות חיוניים למימושים אמינים של MCP  

## דוגמאות

- [מחשבון Java](../samples/java/calculator/README.md)  
- [מחשבון .Net](../../../../03-GettingStarted/samples/csharp)  
- [מחשבון JavaScript](../samples/javascript/README.md)  
- [מחשבון TypeScript](../samples/typescript/README.md)  
- [מחשבון Python](../../../../03-GettingStarted/samples/python)  

## משימה

צור שרת MCP פשוט עם כלי לבחירתך:

1. מימש את הכלי בשפתך המועדפת (.NET, Java, Python או JavaScript).  
2. הגדר פרמטרי קלט וערכי החזרה.  
3. הפעל את כלי הבודק כדי לוודא שהשרת פועל כמצופה.  
4. בדוק את המימוש עם קלטים שונים.  

## פתרון

[Solution](./solution/README.md)

## משאבים נוספים

- [בניית סוכנים באמצעות Model Context Protocol ב-Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [MCP מרוחק עם Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [סוכן .NET OpenAI MCP](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## מה הלאה

הבא: [התחלת עבודה עם לקוחות MCP](../02-client/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.