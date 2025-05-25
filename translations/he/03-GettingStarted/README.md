<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:12:24+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "he"
}
-->
## התחלת העבודה

חלק זה מורכב ממספר שיעורים:

- **-1- השרת הראשון שלך**, בשיעור הראשון הזה תלמד כיצד ליצור את השרת הראשון שלך ולבדוק אותו עם כלי הבדיקה, דרך חשובה לבדוק ולפתור בעיות בשרת שלך, [לשיעור](/03-GettingStarted/01-first-server/README.md)

- **-2- לקוח**, בשיעור זה תלמד כיצד לכתוב לקוח שיכול להתחבר לשרת שלך, [לשיעור](/03-GettingStarted/02-client/README.md)

- **-3- לקוח עם LLM**, דרך טובה יותר לכתוב לקוח היא על ידי הוספת LLM כדי שיוכל "לנהל משא ומתן" עם השרת שלך על מה לעשות, [לשיעור](/03-GettingStarted/03-llm-client/README.md)

- **-4- שימוש במצב סוכן GitHub Copilot ב-Visual Studio Code**. כאן, אנו מסתכלים על הרצת שרת MCP שלנו מתוך Visual Studio Code, [לשיעור](/03-GettingStarted/04-vscode/README.md)

- **-5- צריכה מ-SSE (Server Sent Events)** SSE הוא תקן לזרימת נתונים משרת ללקוח, המאפשר לשרתים לדחוף עדכונים בזמן אמת ללקוחות דרך HTTP [לשיעור](/03-GettingStarted/05-sse-server/README.md)

- **-6- שימוש בערכת כלים AI עבור VSCode** לצריכה ובדיקה של לקוחות ושרתים MCP [לשיעור](/03-GettingStarted/06-aitk/README.md)

- **-7 בדיקות**. כאן נתמקד במיוחד כיצד נוכל לבדוק את השרת והלקוח שלנו בדרכים שונות, [לשיעור](/03-GettingStarted/07-testing/README.md)

- **-8- פריסה**. פרק זה יעסוק בדרכים שונות לפרוס את פתרונות MCP שלך, [לשיעור](/03-GettingStarted/08-deployment/README.md)

פרוטוקול הקשר המודל (MCP) הוא פרוטוקול פתוח שמגדיר כיצד אפליקציות מספקות הקשר ל-LLMs. חשבו על MCP כמו חיבור USB-C לאפליקציות AI - הוא מספק דרך סטנדרטית לחבר מודלים AI למקורות נתונים וכלים שונים.

## מטרות למידה

בסוף השיעור הזה, תוכל:

- להגדיר סביבות פיתוח עבור MCP ב-C#, Java, Python, TypeScript ו-JavaScript
- לבנות ולפרוס שרתי MCP בסיסיים עם תכונות מותאמות אישית (משאבים, הנחיות וכלים)
- ליצור אפליקציות מארחות שמתחברות לשרתי MCP
- לבדוק ולפתור בעיות ביישומי MCP
- להבין אתגרים נפוצים בהגדרות ופתרונותיהם
- לחבר את יישומי MCP שלך לשירותי LLM פופולריים

## הגדרת סביבת MCP שלך

לפני שתתחיל לעבוד עם MCP, חשוב להכין את סביבת הפיתוח שלך ולהבין את זרימת העבודה הבסיסית. חלק זה ידריך אותך דרך שלבי ההגדרה הראשוניים כדי להבטיח התחלה חלקה עם MCP.

### דרישות מוקדמות

לפני שאתה צולל לפיתוח MCP, ודא שיש לך:

- **סביבת פיתוח**: לשפה שבחרת (C#, Java, Python, TypeScript, או JavaScript)
- **IDE/עורך**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm או כל עורך קוד מודרני
- **מנהלי חבילות**: NuGet, Maven/Gradle, pip או npm/yarn
- **מפתחות API**: לכל שירותי AI שאתה מתכנן להשתמש בהם באפליקציות המארחות שלך

### SDKs רשמיים

בפרקים הבאים תראה פתרונות שנבנו באמצעות Python, TypeScript, Java ו-.NET. הנה כל ה-SDKs הנתמכים רשמית.

MCP מספק SDKs רשמיים למספר שפות:
- [SDK C#](https://github.com/modelcontextprotocol/csharp-sdk) - מתוחזק בשיתוף פעולה עם Microsoft
- [SDK Java](https://github.com/modelcontextprotocol/java-sdk) - מתוחזק בשיתוף פעולה עם Spring AI
- [SDK TypeScript](https://github.com/modelcontextprotocol/typescript-sdk) - המימוש הרשמי של TypeScript
- [SDK Python](https://github.com/modelcontextprotocol/python-sdk) - המימוש הרשמי של Python
- [SDK Kotlin](https://github.com/modelcontextprotocol/kotlin-sdk) - המימוש הרשמי של Kotlin
- [SDK Swift](https://github.com/modelcontextprotocol/swift-sdk) - מתוחזק בשיתוף פעולה עם Loopwork AI
- [SDK Rust](https://github.com/modelcontextprotocol/rust-sdk) - המימוש הרשמי של Rust

## נקודות מפתח

- הגדרת סביבת פיתוח MCP היא פשוטה עם SDKs ספציפיים לשפה
- בניית שרתי MCP כוללת יצירת ורישום כלים עם סכמות ברורות
- לקוחות MCP מתחברים לשרתים ולמודלים כדי לנצל יכולות מורחבות
- בדיקות ופתרון בעיות חיוניים ליישומי MCP אמינים
- אפשרויות פריסה נעות מפיתוח מקומי לפתרונות מבוססי ענן

## תרגול

יש לנו סט של דוגמאות שמשלים את התרגילים שתראה בכל הפרקים בחלק זה. בנוסף, לכל פרק יש גם תרגילים ומשימות משלו

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## משאבים נוספים

- [מאגר GitHub MCP](https://github.com/microsoft/mcp-for-beginners)

## מה הלאה

הבא: [יצירת שרת MCP ראשון שלך](/03-GettingStarted/01-first-server/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). בעוד שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עשויים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור סמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום אנושי מקצועי. אנו לא נושאים באחריות לכל אי הבנות או פרשנויות שגויות הנובעות מהשימוש בתרגום זה.