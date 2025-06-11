<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:13:02+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "he"
}
-->
## התחלה  

קטע זה כולל מספר שיעורים:

- **1 השרת הראשון שלך**, בשיעור הראשון תלמד כיצד ליצור את השרת הראשון שלך ולבדוק אותו עם כלי הבדיקה, דרך חשובה לבדיקה וניפוי שגיאות של השרת שלך, [לשיעור](/03-GettingStarted/01-first-server/README.md)

- **2 לקוח**, בשיעור זה תלמד כיצד לכתוב לקוח שיכול להתחבר לשרת שלך, [לשיעור](/03-GettingStarted/02-client/README.md)

- **3 לקוח עם LLM**, דרך טובה אף יותר לכתיבת לקוח היא להוסיף לו LLM כדי ש"יתמקח" עם השרת שלך על מה לעשות, [לשיעור](/03-GettingStarted/03-llm-client/README.md)

- **4 צריכת מצב סוכן GitHub Copilot של השרת ב-Visual Studio Code**. כאן נבחן הפעלת שרת MCP שלנו מתוך Visual Studio Code, [לשיעור](/03-GettingStarted/04-vscode/README.md)

- **5 צריכה מ-SSE (Server Sent Events)** SSE הוא תקן לזרימה מהשרת ללקוח, שמאפשר לשרתים לדחוף עדכונים בזמן אמת ללקוחות דרך HTTP [לשיעור](/03-GettingStarted/05-sse-server/README.md)

- **6 שימוש ב-AI Toolkit ל-VSCode** לצריכה ובדיקה של לקוחות ושרתים של MCP [לשיעור](/03-GettingStarted/06-aitk/README.md)

- **7 בדיקות**. כאן נתמקד במיוחד כיצד ניתן לבדוק את השרת והלקוח בדרכים שונות, [לשיעור](/03-GettingStarted/07-testing/README.md)

- **8 פריסה**. פרק זה יבחן דרכים שונות לפריסת פתרונות MCP שלך, [לשיעור](/03-GettingStarted/08-deployment/README.md)


פרוטוקול Model Context (MCP) הוא פרוטוקול פתוח שמאחד את הדרך שבה אפליקציות מספקות הקשר ל-LLMs. חשבו על MCP כמו על חיבור USB-C לאפליקציות AI - הוא מספק דרך מאוחדת לחבר מודלים של AI למקורות נתונים וכלים שונים.

## מטרות הלמידה

בסוף שיעור זה תוכל:

- להגדיר סביבות פיתוח ל-MCP ב-C#, Java, Python, TypeScript ו-JavaScript
- לבנות ולפרוס שרתי MCP בסיסיים עם תכונות מותאמות אישית (משאבים, פרומפטים וכלים)
- ליצור אפליקציות מארחות שמתחברות לשרתי MCP
- לבדוק ולפתור תקלות ביישומי MCP
- להבין אתגרים נפוצים בהגדרה ופתרונותיהם
- לחבר את יישומי MCP שלך לשירותי LLM פופולריים

## הגדרת סביבת MCP שלך

לפני שתתחיל לעבוד עם MCP, חשוב להכין את סביבת הפיתוח ולהבין את זרימת העבודה הבסיסית. קטע זה ינחה אותך בשלבי ההגדרה הראשוניים כדי להבטיח התחלה חלקה עם MCP.

### דרישות מוקדמות

לפני שתתחיל בפיתוח MCP, ודא שיש לך:

- **סביבת פיתוח**: עבור שפת התכנות שבחרת (C#, Java, Python, TypeScript או JavaScript)
- **IDE/עורך**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm או כל עורך קוד מודרני
- **מנהלי חבילות**: NuGet, Maven/Gradle, pip, או npm/yarn
- **מפתחות API**: עבור כל שירותי AI שתכננת להשתמש בהם באפליקציות המארחות שלך


### SDKs רשמיים

בפרקים הבאים תראה פתרונות שנבנו באמצעות Python, TypeScript, Java ו-.NET. הנה כל ה-SDKs הנתמכים רשמית.

MCP מספק SDKs רשמיים למספר שפות:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - מתוחזק בשיתוף עם Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - מתוחזק בשיתוף עם Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - מימוש רשמי ב-TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - מימוש רשמי ב-Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - מימוש רשמי ב-Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - מתוחזק בשיתוף עם Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - מימוש רשמי ב-Rust

## נקודות מפתח

- הגדרת סביבת פיתוח MCP היא פשוטה עם SDKs ספציפיים לשפה
- בניית שרתי MCP כוללת יצירה ורישום של כלים עם סכימות ברורות
- לקוחות MCP מתחברים לשרתים ולמודלים כדי לנצל יכולות מורחבות
- בדיקות וניפוי שגיאות הם חיוניים ליישומי MCP אמינים
- אפשרויות פריסה מגוונות, מהפיתוח המקומי ועד פתרונות מבוססי ענן

## תרגול

יש לנו אוסף דוגמאות שמשלימות את התרגילים שתראה בכל הפרקים בקטע זה. בנוסף, לכל פרק יש תרגילים ומשימות משלו

- [מחשבון Java](./samples/java/calculator/README.md)
- [מחשבון .Net](../../../03-GettingStarted/samples/csharp)
- [מחשבון JavaScript](./samples/javascript/README.md)
- [מחשבון TypeScript](./samples/typescript/README.md)
- [מחשבון Python](../../../03-GettingStarted/samples/python)

## משאבים נוספים

- [בניית סוכנים באמצעות Model Context Protocol ב-Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP מרוחק עם Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## מה הלאה

הבא: [יצירת שרת MCP ראשון שלך](/03-GettingStarted/01-first-server/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדייק, יש להיות מודעים לכך שתרגומים אוטומטיים עלולים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי אדם. איננו אחראים לכל אי הבנה או פרשנות שגויה הנובעים משימוש בתרגום זה.