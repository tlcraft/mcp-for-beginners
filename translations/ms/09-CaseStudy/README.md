<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:42:00+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "ms"
}
-->
# Case Study: Azure AI Travel Agents – Reference Implementation

## Overview

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) הוא פתרון ייחוס מקיף שפותח על ידי Microsoft ומדגים כיצד לבנות אפליקציית תכנון טיולים מבוססת AI עם סוכנים מרובים, תוך שימוש ב-Model Context Protocol (MCP), Azure OpenAI ו-Azure AI Search. הפרויקט מציג שיטות עבודה מומלצות לתיאום סוכני AI שונים, שילוב נתוני ארגוניים, וסיפוק פלטפורמה מאובטחת וגמישה לתרחישים אמיתיים.

## Key Features
- **Multi-Agent Orchestration:** משתמש ב-MCP לתיאום סוכנים מתמחים (כגון סוכני טיסות, מלונות ונתיבי טיול) שעובדים יחד כדי למלא משימות מורכבות של תכנון טיולים.
- **Enterprise Data Integration:** מחבר ל-Azure AI Search ולמקורות נתונים ארגוניים נוספים כדי לספק מידע עדכני ורלוונטי להמלצות טיול.
- **Secure, Scalable Architecture:** מנצל שירותי Azure לאימות, הרשאות ופריסה סקלאבילית, בהתאם לשיטות עבודה מומלצות לאבטחת ארגונים.
- **Extensible Tooling:** מיישם כלים ותבניות בקשות (prompt templates) של MCP לשימוש חוזר, שמאפשרים התאמה מהירה לתחומים או דרישות עסקיות חדשות.
- **User Experience:** מספק ממשק שיחה למשתמשים לתקשורת עם סוכני הטיול, מונע על ידי Azure OpenAI ו-MCP.

## Architecture
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Architecture Diagram Description

פתרון Azure AI Travel Agents בנוי למודולריות, סקלאביליות ושילוב מאובטח של סוכני AI מרובים ומקורות נתונים ארגוניים. הרכיבים המרכזיים וזרימת הנתונים הם:

- **User Interface:** המשתמשים מתקשרים עם המערכת דרך ממשק שיחה (כגון צ'אט באתר או בוט Teams), ששולח שאילתות ומקבל המלצות טיול.
- **MCP Server:** משמש כמנהל המרכזי, מקבל קלט מהמשתמש, מנהל את ההקשר ומתאם את פעולות הסוכנים המיוחדים (כגון FlightAgent, HotelAgent, ItineraryAgent) באמצעות Model Context Protocol.
- **AI Agents:** כל סוכן אחראי לתחום מסוים (טיסות, מלונות, מסלולי טיול) ומיושם ככלי MCP. הסוכנים משתמשים בתבניות בקשות ולוגיקה לעיבוד בקשות ויצירת תגובות.
- **Azure OpenAI Service:** מספק הבנה ויצירת שפה טבעית מתקדמת, ומאפשר לסוכנים לפרש את כוונת המשתמש וליצור תגובות שיחה.
- **Azure AI Search & Enterprise Data:** הסוכנים מבצעים שאילתות ל-Azure AI Search ולמקורות נתונים ארגוניים נוספים לקבלת מידע עדכני על טיסות, מלונות ואפשרויות טיול.
- **Authentication & Security:** משתלב עם Microsoft Entra ID לאימות מאובטח ומיישם בקרות גישה מינימליות לכל המשאבים.
- **Deployment:** מתוכנן לפריסה ב-Azure Container Apps, המבטיח סקלאביליות, ניטור ויעילות תפעולית.

ארכיטקטורה זו מאפשרת תיאום חלק של סוכני AI מרובים, שילוב מאובטח עם נתונים ארגוניים ופלטפורמה יציבה וגמישה לבניית פתרונות AI ספציפיים לתחום.

## Step-by-Step Explanation of the Architecture Diagram
תארו לעצמכם שאתם מתכננים טיול גדול ויש לכם צוות של עוזרים מומחים שמסייעים לכם בכל פרט. מערכת Azure AI Travel Agents פועלת באופן דומה, כשהרכיבים השונים (כמו חברי צוות) כל אחד עם תפקיד מיוחד. כך זה עובד:

### User Interface (UI):
תחשבו על זה כעמדת הקבלה של סוכן הטיולים שלכם. כאן אתם (המשתמש) שואלים שאלות או מבקשים דברים, כמו "מצא לי טיסה לפריז." זה יכול להיות חלון צ'אט באתר או אפליקציית מסרים.

### MCP Server (The Coordinator):
שרת ה-MCP הוא כמו המנהל שמקשיב לבקשתכם בעמדה ומחליט איזה מומחה יטפל בכל חלק. הוא שומר על מעקב אחרי השיחה ודואג שהכל יתנהל חלק.

### AI Agents (Specialist Assistants):
כל סוכן הוא מומחה בתחום מסוים – אחד בטיסות, אחר במלונות, ואחר בתכנון מסלול. כשאתם מבקשים טיול, שרת ה-MCP שולח את הבקשה לסוכן המתאים. הסוכנים משתמשים בידע ובכלים שלהם כדי למצוא את האפשרויות הטובות ביותר עבורכם.

### Azure OpenAI Service (Language Expert):
כמו מומחה שפה שמבין בדיוק מה אתם מבקשים, בלי קשר לאופן שבו ניסחתם את זה. הוא עוזר לסוכנים להבין את הבקשות שלכם ולהגיב בשפה טבעית וזורמת.

### Azure AI Search & Enterprise Data (Information Library):
תארו לכם ספרייה ענקית ועדכנית עם כל המידע האחרון על טיסות, זמינות מלונות ועוד. הסוכנים מחפשים בספרייה הזו כדי לספק את התשובות המדויקות ביותר.

### Authentication & Security (Security Guard):
כמו שומר אבטחה שבודק מי מורשה להיכנס לאזורים מסוימים, חלק זה מוודא שרק אנשים וסוכנים מורשים יכולים לגשת למידע רגיש. הוא שומר על הנתונים שלכם בטוחים ופרטיים.

### Deployment on Azure Container Apps (The Building):
כל העוזרים והכלים האלה פועלים בתוך "בניין" מאובטח וסקלאבילי (הענן). זה אומר שהמערכת יכולה לטפל בהרבה משתמשים בו זמנית ותמיד זמינה כשאתם צריכים אותה.

## How it all works together:

אתם מתחילים בשאלה בעמדה (UI).  
המנהל (MCP Server) מזהה איזה מומחה (סוכן) יכול לעזור.  
המומחה משתמש במומחה השפה (OpenAI) כדי להבין את הבקשה ובספרייה (AI Search) כדי למצוא את התשובה הטובה ביותר.  
שומר האבטחה (Authentication) מוודא שהכל בטוח.  
כל זה קורה בתוך בניין אמין וסקלאבילי (Azure Container Apps), כך שהחוויה שלכם חלקה ומאובטחת.  
שיתוף הפעולה הזה מאפשר למערכת לעזור לכם לתכנן את הטיול במהירות ובבטחה, ממש כמו צוות מומחים במשרד מודרני!

## Technical Implementation
- **MCP Server:** מארח את הלוגיקה המרכזית לתיאום, חושף כלים של סוכנים ומנהל הקשר עבור תהליכי תכנון טיולים מרובי שלבים.
- **Agents:** כל סוכן (כגון FlightAgent, HotelAgent) מיושם ככלי MCP עם תבניות בקשות ולוגיקה משלו.
- **Azure Integration:** משתמש ב-Azure OpenAI להבנת שפה טבעית וב-Azure AI Search לשליפת נתונים.
- **Security:** משתלב עם Microsoft Entra ID לאימות ומיישם בקרות גישה מינימליות לכל המשאבים.
- **Deployment:** תומך בפריסה ב-Azure Container Apps לסקלאביליות ויעילות תפעולית.

## Results and Impact
- מדגים כיצד ניתן להשתמש ב-MCP לתיאום סוכני AI מרובים בתרחיש אמיתי וייצור.
- מזרז פיתוח פתרונות באמצעות תבניות שימוש חוזר לתיאום סוכנים, שילוב נתונים ופריסה מאובטחת.
- משמש כתבנית לבניית אפליקציות מבוססות AI ספציפיות לתחום, באמצעות MCP ושירותי Azure.

## References
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab terhadap sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.