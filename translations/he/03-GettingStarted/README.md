<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-13T00:22:13+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "he"
}
-->
## התחלה  

הקטע הזה מורכב ממספר שיעורים:

- **1 השרת הראשון שלך**, בשיעור הראשון תלמד כיצד ליצור את השרת הראשון שלך ולבדוק אותו עם כלי הבדיקה, דרך חשובה לבחון ולתקן את השרת שלך, [לשיעור](/03-GettingStarted/01-first-server/README.md)

- **2 לקוח**, בשיעור זה תלמד כיצד לכתוב לקוח שיכול להתחבר לשרת שלך, [לשיעור](/03-GettingStarted/02-client/README.md)

- **3 לקוח עם LLM**, דרך טובה אף יותר לכתוב לקוח היא להוסיף לו LLM כדי שיוכל "לנהל משא ומתן" עם השרת שלך על מה לעשות, [לשיעור](/03-GettingStarted/03-llm-client/README.md)

- **4 שימוש במצב סוכן GitHub Copilot ב-Visual Studio Code**. כאן נבחן את הרצת שרת MCP שלנו מתוך Visual Studio Code, [לשיעור](/03-GettingStarted/04-vscode/README.md)

- **5 צריכה מ-SSE (Server Sent Events)** SSE הוא תקן להזנה רציפה מהשרת ללקוח, המאפשר לשרתים לדחוף עדכונים בזמן אמת ללקוחות דרך HTTP [לשיעור](/03-GettingStarted/05-sse-server/README.md)

- **6 הזרמת HTTP עם MCP (Streamable HTTP)**. תלמד על הזרמת HTTP מודרנית, התראות התקדמות, וכיצד ליישם שרתי MCP ולקוחות בזמן אמת ובקנה מידה באמצעות Streamable HTTP. [לשיעור](/03-GettingStarted/06-http-streaming/README.md)

- **7 שימוש בערכת כלים של AI ל-VSCode** לצריכה ובדיקת לקוחות ושרתים של MCP שלך [לשיעור](/03-GettingStarted/07-aitk/README.md)

- **8 בדיקות**. כאן נתמקד במיוחד כיצד ניתן לבדוק את השרת והלקוח שלנו בדרכים שונות, [לשיעור](/03-GettingStarted/08-testing/README.md)

- **9 פריסה**. פרק זה יבחן דרכים שונות לפרוס את הפתרונות שלך ב-MCP, [לשיעור](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) הוא פרוטוקול פתוח שמאחד כיצד יישומים מספקים הקשר ל-LLMs. אפשר לחשוב על MCP כמו על חיבור USB-C ליישומי AI - הוא מספק דרך אחידה לחבר מודלים של AI למקורות נתונים וכלים שונים.

## מטרות הלמידה

בסיום השיעור הזה תוכל:

- להגדיר סביבות פיתוח ל-MCP ב-C#, Java, Python, TypeScript ו-JavaScript  
- לבנות ולפרוס שרתי MCP בסיסיים עם תכונות מותאמות (משאבים, פרומפטים וכלים)  
- ליצור יישומי מארח שמתחברים לשרתי MCP  
- לבדוק ולתקן יישומי MCP  
- להבין את האתגרים הנפוצים בהגדרה ואת הפתרונות שלהם  
- לחבר את יישומי MCP שלך לשירותי LLM פופולריים  

## הגדרת סביבת ה-MCP שלך

לפני שתתחיל לעבוד עם MCP, חשוב להכין את סביבת הפיתוח ולהבין את תהליך העבודה הבסיסי. הקטע הזה ינחה אותך בשלבי ההגדרה הראשוניים כדי להבטיח התחלה חלקה עם MCP.

### דרישות מוקדמות

לפני שתתחיל בפיתוח MCP, ודא שיש לך:

- **סביבת פיתוח**: לשפת התכנות שבחרת (C#, Java, Python, TypeScript או JavaScript)  
- **IDE/עורך קוד**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm או כל עורך קוד מודרני  
- **מנהל חבילות**: NuGet, Maven/Gradle, pip או npm/yarn  
- **מפתחות API**: עבור כל שירות AI שתכננת להשתמש בו ביישומי המארח שלך  

### SDKs רשמיים

בפרקים הקרובים תראה פתרונות שנבנו באמצעות Python, TypeScript, Java ו-.NET. הנה כל ה-SDKs הנתמכים רשמית.

MCP מספק SDKs רשמיים למספר שפות:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - מתוחזק בשיתוף עם Microsoft  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - מתוחזק בשיתוף עם Spring AI  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - מימוש רשמי ל-TypeScript  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - מימוש רשמי ל-Python  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - מימוש רשמי ל-Kotlin  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - מתוחזק בשיתוף עם Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - מימוש רשמי ל-Rust  

## נקודות מפתח

- הגדרת סביבת פיתוח MCP פשוטה עם SDKs ספציפיים לשפות  
- בניית שרתי MCP כוללת יצירה ורישום כלים עם סכימות ברורות  
- לקוחות MCP מתחברים לשרתים ולמודלים כדי לנצל יכולות מורחבות  
- בדיקות ותיקונים חיוניים ליישומי MCP אמינים  
- אפשרויות פריסה מגוונות - מפיתוח מקומי ועד פתרונות מבוססי ענן  

## תרגול

יש לנו אוסף דוגמאות שמלוות את התרגילים שתראה בכל הפרקים בקטע זה. בנוסף, לכל פרק יש גם תרגילים ומשימות משלו.

- [מחשבון Java](./samples/java/calculator/README.md)  
- [מחשבון .Net](../../../03-GettingStarted/samples/csharp)  
- [מחשבון JavaScript](./samples/javascript/README.md)  
- [מחשבון TypeScript](./samples/typescript/README.md)  
- [מחשבון Python](../../../03-GettingStarted/samples/python)  

## משאבים נוספים

- [בניית סוכנים באמצעות Model Context Protocol על Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [MCP מרוחק עם Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## מה הלאה

הבא: [יצירת שרת MCP ראשון שלך](/03-GettingStarted/01-first-server/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו הוא המקור הסמכותי. עבור מידע קריטי מומלץ להיעזר בתרגום מקצועי אנושי. אנו לא נושאים באחריות לכל אי-הבנות או פרשנויות שגויות הנובעות משימוש בתרגום זה.