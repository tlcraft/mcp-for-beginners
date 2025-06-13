<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:51:12+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "ms"
}
-->
# Case Study: Azure AI Travel Agents – Reference Implementation

## Overview

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) היא פתרון ייחוס מקיף שפותח על ידי Microsoft ומדגים כיצד לבנות אפליקציית תכנון טיולים מבוססת בינה מלאכותית עם סוכנים מרובים, תוך שימוש ב-Model Context Protocol (MCP), Azure OpenAI ו-Azure AI Search. הפרויקט מציג שיטות עבודה מומלצות לתיאום סוכני AI מרובים, אינטגרציה עם נתוני ארגון, ומתן פלטפורמה מאובטחת ומורחבת לתרחישים בעולם האמיתי.

## Key Features
- **Multi-Agent Orchestration:** משתמש ב-MCP לתיאום סוכנים מתמחים (כגון סוכני טיסות, מלונות ותכניות טיול) שעובדים יחד לביצוע משימות מורכבות של תכנון טיולים.
- **Enterprise Data Integration:** מתחבר ל-Azure AI Search ולמקורות נתוני ארגון נוספים כדי לספק מידע עדכני ורלוונטי להמלצות טיול.
- **Secure, Scalable Architecture:** מנצל שירותי Azure לאימות, הרשאות ופריסה מדרגתית, בהתאם לשיטות אבטחה בארגוניות.
- **Extensible Tooling:** מיישם כלים ותבניות prompt של MCP שניתן להשתמש בהם מחדש, מה שמאפשר התאמה מהירה לתחומים או דרישות עסקיות חדשות.
- **User Experience:** מספק ממשק שיחתי למשתמשים לתקשר עם סוכני הטיולים, מופעל על ידי Azure OpenAI ו-MCP.

## Architecture
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Architecture Diagram Description

פתרון Azure AI Travel Agents מעוצב למודולריות, מדרגיות ואינטגרציה מאובטחת של סוכני AI מרובים ומקורות נתוני ארגון. הרכיבים המרכזיים וזרימת הנתונים הם:

- **User Interface:** המשתמשים מתקשרים עם המערכת דרך ממשק שיחתי (כגון צ'אט באתר או בוט Teams), ששולח שאילתות ומקבל המלצות טיול.
- **MCP Server:** משמש כמנהל מרכזי, מקבל קלט מהמשתמש, מנהל הקשר ומתאם את פעולות הסוכנים המתמחים (כגון FlightAgent, HotelAgent, ItineraryAgent) באמצעות Model Context Protocol.
- **AI Agents:** כל סוכן אחראי לתחום מסוים (טיסות, מלונות, תכניות טיול) ומיושם ככלי MCP. הסוכנים משתמשים בתבניות prompt ובלוגיקה לעיבוד בקשות ויצירת תגובות.
- **Azure OpenAI Service:** מספק הבנה מתקדמת של שפה טבעית ויצירת תוכן, ומאפשר לסוכנים לפרש כוונות משתמש ולהפיק תגובות שיחתיות.
- **Azure AI Search & Enterprise Data:** הסוכנים מבצעים שאילתות ב-Azure AI Search ובמקורות נתוני ארגון נוספים כדי לקבל מידע עדכני על טיסות, מלונות ואפשרויות טיול.
- **Authentication & Security:** משתלב עם Microsoft Entra ID לאימות מאובטח ומיישם בקרות גישה במינימום הרשאות לכל המשאבים.
- **Deployment:** מתוכנן לפריסה ב-Azure Container Apps, שמבטיחה מדרגיות, ניטור ויעילות תפעולית.

ארכיטקטורה זו מאפשרת תיאום חלק בין סוכני AI מרובים, אינטגרציה מאובטחת עם נתוני ארגון, ופלטפורמה חזקה ומורחבת לבניית פתרונות AI ספציפיים לתחום.

## Step-by-Step Explanation of the Architecture Diagram
תארו לעצמכם שאתם מתכננים טיול גדול ויש לכם צוות מומחים שעוזר לכם בכל פרט. מערכת Azure AI Travel Agents פועלת בדומה, עם חלקים שונים (כמו חברי צוות) שכל אחד מהם מתמחה במשימה מסוימת. כך זה עובד:

### User Interface (UI):
תחשבו על זה כמו דלפק הקבלה של סוכן הטיולים שלכם. כאן אתם (המשתמש) שואלים שאלות או מבקשים שירותים, כמו "מצא לי טיסה לפריז". זה יכול להיות חלון צ'אט באתר או באפליקציית הודעות.

### MCP Server (The Coordinator):
שרת MCP הוא כמו המנהל שמקשיב לבקשה שלכם בדלפק ומחליט איזה מומחה יטפל בכל חלק. הוא עוקב אחרי השיחה ומוודא שהכל מתנהל חלק.

### AI Agents (Specialist Assistants):
כל סוכן הוא מומחה בתחום מסוים—אחד מתמחה בטיסות, אחר במלונות, ואחר בתכנון מסלול הטיול. כשאתם מבקשים טיול, שרת MCP שולח את הבקשה לסוכן המתאים. הסוכנים משתמשים בידע ובכלים שלהם כדי למצוא את האפשרויות הטובות ביותר עבורכם.

### Azure OpenAI Service (Language Expert):
זו כמו מומחה שפה שמבין בדיוק מה אתם מבקשים, לא משנה איך ניסחתם את זה. הוא עוזר לסוכנים להבין את הבקשות שלכם ולענות בשפה טבעית וזורמת.

### Azure AI Search & Enterprise Data (Information Library):
תארו לכם ספרייה ענקית ועדכנית עם כל המידע האחרון על טיסות, זמינות מלונות ועוד. הסוכנים מחפשים בספרייה הזו כדי להביא לכם את התשובות המדויקות ביותר.

### Authentication & Security (Security Guard):
כמו שומר שמוודא מי מורשה להיכנס לאזורים מסוימים, החלק הזה מבטיח שרק אנשים וסוכנים מורשים יוכלו לגשת למידע רגיש. זה שומר על הנתונים שלכם בטוחים ופרטיים.

### Deployment on Azure Container Apps (The Building):
כל העוזרים והכלים האלה עובדים יחד בתוך מבנה מאובטח ומדרגי (הענן). המשמעות היא שהמערכת יכולה לטפל בהרבה משתמשים בו זמנית ותמיד זמינה כשאתם צריכים אותה.

## How it all works together:

אתם מתחילים בשאלה בדלפק הקבלה (UI).
המנהל (MCP Server) מחליט איזה מומחה (סוכן) יוכל לעזור לכם.
המומחה משתמש במומחה השפה (OpenAI) כדי להבין את הבקשה ובספרייה (AI Search) כדי למצוא את התשובה הטובה ביותר.
שומר האבטחה (Authentication) מוודא שהכל בטוח.
כל זה מתרחש בתוך מבנה אמין ומדרגי (Azure Container Apps), כך שהחוויה שלכם חלקה ומאובטחת.
שיתוף הפעולה הזה מאפשר למערכת לעזור לכם לתכנן את הטיול במהירות ובבטחה, ממש כמו צוות מומחים שעובד יחד במשרד מודרני!

## Technical Implementation
- **MCP Server:** מארח את הלוגיקה המרכזית לתיאום, חושף כלים של סוכנים ומנהל הקשר עבור תהליכי תכנון טיולים מרובי שלבים.
- **Agents:** כל סוכן (כגון FlightAgent, HotelAgent) מיושם ככלי MCP עם תבניות prompt ולוגיקה משלו.
- **Azure Integration:** משתמש ב-Azure OpenAI להבנת שפה טבעית וב-Azure AI Search לאיסוף נתונים.
- **Security:** משתלב עם Microsoft Entra ID לאימות ומיישם בקרות גישה במינימום הרשאות לכל המשאבים.
- **Deployment:** תומך בפריסה ב-Azure Container Apps למדרגיות ויעילות תפעולית.

## Results and Impact
- מדגים כיצד ניתן להשתמש ב-MCP לתיאום סוכני AI מרובים בתרחיש אמיתי ומקצועי.
- מאיץ פיתוח פתרונות על ידי מתן דפוסים לשימוש חוזר בתיאום סוכנים, אינטגרציה של נתונים ופריסה מאובטחת.
- משמש כתבנית לבניית יישומים מבוססי AI ספציפיים לתחום באמצעות MCP ושירותי Azure.

## References
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sah. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.