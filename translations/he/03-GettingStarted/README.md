<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:38:50+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "he"
}
-->
## התחלה  

הקטע הזה כולל כמה שיעורים:

- **-1- השרת הראשון שלך**, בשיעור הראשון תלמד איך ליצור את השרת הראשון שלך ולבדוק אותו עם כלי הבדיקה, דרך חשובה לבדוק ולתקן את השרת, [לשיעור](/03-GettingStarted/01-first-server/README.md)

- **-2- לקוח**, בשיעור הזה תלמד איך לכתוב לקוח שיכול להתחבר לשרת שלך, [לשיעור](/03-GettingStarted/02-client/README.md)

- **-3- לקוח עם LLM**, דרך אפילו טובה יותר לכתוב לקוח היא להוסיף לו LLM כדי שיוכל "לנהל משא ומתן" עם השרת שלך על מה לעשות, [לשיעור](/03-GettingStarted/03-llm-client/README.md)

- **-4- שימוש במצב סוכן GitHub Copilot של השרת ב-Visual Studio Code**. כאן, נבחן איך להריץ את MCP Server שלנו מתוך Visual Studio Code, [לשיעור](/03-GettingStarted/04-vscode/README.md)

- **-5- צריכה מ-SSE (Server Sent Events)** SSE הוא תקן לזרימה מהשרת ללקוח, שמאפשר לשרתים לדחוף עדכונים בזמן אמת ללקוחות דרך HTTP [לשיעור](/03-GettingStarted/05-sse-server/README.md)

- **-6- שימוש ב-AI Toolkit ל-VSCode** לצריכה ובדיקה של לקוחות ושרתים של MCP שלך [לשיעור](/03-GettingStarted/06-aitk/README.md)

- **-7- בדיקות**. כאן נתמקד במיוחד איך אפשר לבדוק את השרת והלקוח שלנו בדרכים שונות, [לשיעור](/03-GettingStarted/07-testing/README.md)

- **-8- פריסה**. פרק זה יבחן דרכים שונות לפרוס את הפתרונות שלך ב-MCP, [לשיעור](/03-GettingStarted/08-deployment/README.md)


פרוטוקול Model Context (MCP) הוא פרוטוקול פתוח שמאחד את הדרך שבה אפליקציות מספקות הקשר ל-LLMs. אפשר לחשוב על MCP כמו חיבור USB-C לאפליקציות AI - הוא מספק דרך סטנדרטית לחבר מודלים של AI למקורות נתונים וכלים שונים.

## מטרות הלמידה

בסיום השיעור הזה, תוכל:

- להגדיר סביבות פיתוח ל-MCP ב-C#, Java, Python, TypeScript ו-JavaScript
- לבנות ולפרוס שרתי MCP בסיסיים עם תכונות מותאמות (משאבים, הנחיות, וכלים)
- ליצור אפליקציות מארחות שמתחברות לשרתי MCP
- לבדוק ולתקן יישומי MCP
- להבין את האתגרים הנפוצים בהגדרה ואת הפתרונות להם
- לחבר את יישומי MCP שלך לשירותי LLM פופולריים

## הגדרת סביבת MCP שלך

לפני שתתחיל לעבוד עם MCP, חשוב להכין את סביבת הפיתוח ולהבין את זרימת העבודה הבסיסית. חלק זה ינחה אותך בשלבי ההגדרה הראשוניים כדי להבטיח התחלה חלקה עם MCP.

### דרישות מוקדמות

לפני שמתחילים בפיתוח MCP, ודא שיש לך:

- **סביבת פיתוח**: עבור השפה שבחרת (C#, Java, Python, TypeScript או JavaScript)
- **IDE/עורך קוד**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm או כל עורך קוד מודרני
- **מנהלי חבילות**: NuGet, Maven/Gradle, pip, או npm/yarn
- **מפתחות API**: עבור כל שירות AI שתכננת להשתמש בו באפליקציות המארחות שלך


### SDK רשמיים

בפרקים הבאים תראה פתרונות שנבנו ב-Python, TypeScript, Java ו-.NET. הנה כל ה-SDKים הנתמכים רשמית.

MCP מספק SDK רשמיים למספר שפות:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - מתוחזק בשיתוף עם Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - מתוחזק בשיתוף עם Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - המימוש הרשמי ל-TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - המימוש הרשמי ל-Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - המימוש הרשמי ל-Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - מתוחזק בשיתוף עם Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - המימוש הרשמי ל-Rust

## נקודות מרכזיות

- הגדרת סביבת פיתוח ל-MCP היא פשוטה עם SDKים ספציפיים לשפות
- בניית שרתי MCP כוללת יצירה ורישום של כלים עם סכימות ברורות
- לקוחות MCP מתחברים לשרתי ומודלים כדי לנצל יכולות מורחבות
- בדיקות ותיקון תקלות הם חיוניים ליישומים אמינים של MCP
- אפשרויות הפריסה נעות מפיתוח מקומי ועד פתרונות מבוססי ענן

## תרגול

יש לנו סט דוגמאות שמשלים את התרגילים שתראה בכל הפרקים בקטע הזה. בנוסף, לכל פרק יש גם תרגילים ומשימות משלו

- [מחשבון ב-Java](./samples/java/calculator/README.md)
- [מחשבון ב-.Net](../../../03-GettingStarted/samples/csharp)
- [מחשבון ב-JavaScript](./samples/javascript/README.md)
- [מחשבון ב-TypeScript](./samples/typescript/README.md)
- [מחשבון ב-Python](../../../03-GettingStarted/samples/python)

## משאבים נוספים

- [בניית סוכנים באמצעות Model Context Protocol על Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP מרוחק עם Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [סוכן OpenAI MCP ב-.NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## מה הלאה

הבא: [יצירת השרת הראשון שלך ב-MCP](/03-GettingStarted/01-first-server/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי אנושי. אנו לא אחראים לכל אי-הבנה או פרשנות שגויה הנובעים משימוש בתרגום זה.