<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:34:04+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "mo"
}
-->
# Case Study: Azure AI Travel Agents – Reference Implementation

## Overview

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) הוא פתרון התייחסות מקיף שפותח על ידי מיקרוסופט ומדגים כיצד לבנות אפליקציית תכנון טיולים מבוססת AI עם סוכנים מרובים, באמצעות Model Context Protocol (MCP), Azure OpenAI ו-Azure AI Search. הפרויקט מציג שיטות עבודה מומלצות לארגון סוכני AI מרובים, שילוב נתוני ארגון, ומתן פלטפורמה מאובטחת והרחיבה לתרחישים אמיתיים.

## Key Features
- **Multi-Agent Orchestration:** משתמש ב-MCP לתיאום סוכנים מתמחים (כגון סוכני טיסות, מלונות ונתיבי טיול) שעובדים יחד כדי למלא משימות תכנון טיול מורכבות.
- **Enterprise Data Integration:** מתחבר ל-Azure AI Search ולמקורות נתוני ארגון נוספים כדי לספק מידע עדכני ורלוונטי להמלצות טיולים.
- **Secure, Scalable Architecture:** מנצל שירותי Azure לאימות, הרשאה ופריסה סקיילבילית, בהתאם לשיטות אבטחת מידע ארגוניות.
- **Extensible Tooling:** מיישם כלים ותבניות פרומפט חוזרות של MCP, המאפשרות התאמה מהירה לתחומים או דרישות עסקיות חדשות.
- **User Experience:** מספק ממשק שיחתי למשתמשים לתקשר עם סוכני הטיולים, מופעל על ידי Azure OpenAI ו-MCP.

## Architecture
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Architecture Diagram Description

פתרון Azure AI Travel Agents מתוכנן למודולריות, סקיילביליות ואינטגרציה מאובטחת של סוכני AI מרובים ומקורות נתוני ארגון. הרכיבים המרכזיים וזרימת הנתונים הם:

- **User Interface:** המשתמשים מתקשרים עם המערכת דרך ממשק שיחתי (כגון צ'אט באתר או בוט Teams), ששולח שאילתות משתמש ומקבל המלצות טיול.
- **MCP Server:** משמש כמארגן מרכזי, מקבל קלט משתמש, מנהל הקשר ומתאם את פעולות הסוכנים המתמחים (כגון FlightAgent, HotelAgent, ItineraryAgent) באמצעות Model Context Protocol.
- **AI Agents:** כל סוכן אחראי על תחום מסוים (טיסות, מלונות, מסלולי טיול) ומיושם ככלי MCP. הסוכנים משתמשים בתבניות פרומפט ולוגיקה לעיבוד בקשות ויצירת תגובות.
- **Azure OpenAI Service:** מספק הבנה ושפה טבעית מתקדמת, ומאפשר לסוכנים לפרש כוונת משתמש וליצור תגובות שיחתיות.
- **Azure AI Search & Enterprise Data:** הסוכנים מבצעים שאילתות ב-Azure AI Search ובמקורות נתוני ארגון נוספים כדי לקבל מידע עדכני על טיסות, מלונות ואפשרויות טיול.
- **Authentication & Security:** משתלב עם Microsoft Entra ID לאימות מאובטח ומיישם בקרות גישה במינימום הרשאות לכל המשאבים.
- **Deployment:** מתוכנן לפריסה ב-Azure Container Apps, המבטיח סקיילביליות, ניטור ויעילות תפעולית.

ארכיטקטורה זו מאפשרת תיאום חלק של סוכני AI מרובים, אינטגרציה מאובטחת עם נתוני ארגון ופלטפורמה יציבה והרחיבה לבניית פתרונות AI ייעודיים לתחומים.

## Step-by-Step Explanation of the Architecture Diagram
תארו לעצמכם שאתם מתכננים טיול גדול ויש לכם צוות של עוזרים מומחים שעוזרים בכל פרט. מערכת Azure AI Travel Agents עובדת באותו אופן, עם חלקים שונים (כמו חברי צוות) שלכל אחד תפקיד מיוחד. כך הכל מתחבר:

### User Interface (UI):
חשבו על זה כעמדת הקבלה של סוכן הנסיעות שלכם. כאן אתם (המשתמש) שואלים שאלות או מבקשים שירותים, כמו "מצא לי טיסה לפריז". זה יכול להיות חלון צ'אט באתר או אפליקציית מסרים.

### MCP Server (The Coordinator):
שרת MCP הוא כמו המנהל שמקשיב לבקשה שלכם בקבלה ומחליט איזה מומחה צריך לטפל בכל חלק. הוא עוקב אחרי השיחה ומוודא שהכל מתנהל חלק.

### AI Agents (Specialist Assistants):
כל סוכן הוא מומחה בתחום מסוים – אחד בטיסות, אחר במלונות, ואחד בתכנון מסלולי טיול. כשאתם מבקשים טיול, שרת MCP שולח את הבקשה לסוכן/ים המתאים/ים. הסוכנים משתמשים בידע ובכלים שלהם כדי למצוא את האפשרויות הטובות ביותר עבורכם.

### Azure OpenAI Service (Language Expert):
כמו מומחה שפה שמבין בדיוק מה אתם מבקשים, לא משנה איך ניסחתם את זה. הוא עוזר לסוכנים להבין את הבקשות שלכם ולענות בשפה טבעית וזורמת.

### Azure AI Search & Enterprise Data (Information Library):
תארו לעצמכם ספרייה ענקית ומעודכנת עם כל המידע העדכני על טיסות, זמינות מלונות ועוד. הסוכנים מחפשים בספרייה הזו כדי לספק לכם את התשובות המדויקות ביותר.

### Authentication & Security (Security Guard):
כמו שומר ביטחון שבודק מי מורשה להיכנס לאזורים מסוימים, החלק הזה מוודא שרק אנשים וסוכנים מורשים יכולים לגשת למידע רגיש. הוא שומר על המידע שלכם בטוח ופרטי.

### Deployment on Azure Container Apps (The Building):
כל העוזרים והכלים האלו עובדים יחד בתוך בניין מאובטח וסקיילבילי (הענן). זה אומר שהמערכת יכולה לטפל בהרבה משתמשים בו זמנית ותמיד זמינה כשאתם צריכים אותה.

## How it all works together:

אתם מתחילים בשאלה בקבלה (UI).  
המנהל (MCP Server) מחליט איזה מומחה (סוכן) יעזור לכם.  
המומחה משתמש במומחה השפה (OpenAI) כדי להבין את הבקשה ובספרייה (AI Search) כדי למצוא את התשובה הטובה ביותר.  
שומר הביטחון (Authentication) מוודא שהכל בטוח.  
כל זה מתרחש בתוך בניין אמין וסקיילבילי (Azure Container Apps), כך שהחוויה שלכם חלקה ומאובטחת.  
שיתוף הפעולה הזה מאפשר למערכת לעזור לכם לתכנן את הטיול במהירות ובבטחה, ממש כמו צוות מומחי נסיעות במשרד מודרני!

## Technical Implementation
- **MCP Server:** מארח את הלוגיקה המרכזית לתיאום, חושף כלים של סוכנים ומנהל הקשר עבור זרימות עבודה של תכנון טיול רב שלבי.
- **Agents:** כל סוכן (למשל FlightAgent, HotelAgent) מיושם ככלי MCP עם תבניות פרומפט ולוגיקה משלו.
- **Azure Integration:** משתמש ב-Azure OpenAI להבנת שפה טבעית וב-Azure AI Search לשליפת נתונים.
- **Security:** משתלב עם Microsoft Entra ID לאימות ומיישם בקרות גישה במינימום הרשאות לכל המשאבים.
- **Deployment:** תומך בפריסה ב-Azure Container Apps לסקיילביליות ויעילות תפעולית.

## Results and Impact
- מדגים כיצד ניתן להשתמש ב-MCP לתיאום סוכני AI מרובים בתרחיש אמיתי וייצורי.
- מאיץ פיתוח פתרונות על ידי מתן תבניות חוזרות לתיאום סוכנים, שילוב נתונים ופריסה מאובטחת.
- משמש כתבנית לבניית אפליקציות מבוססות AI ייעודיות לתחומים, באמצעות MCP ושירותי Azure.

## References
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Disclaimer**:  
This document has been translated using AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.

---

If by "mo" you mean a specific language or dialect, could you please clarify which language "mo" refers to? This will help me provide an accurate translation.