<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:42:21+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "mo"
}
-->
# Case Study: Azure AI Travel Agents – Reference Implementation

## Overview

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) הוא פתרון התייחסות מקיף שפותח על ידי מיקרוסופט, המדגים כיצד לבנות אפליקציית תכנון טיולים מבוססת AI עם סוכנים מרובים, באמצעות Model Context Protocol (MCP), Azure OpenAI ו-Azure AI Search. הפרויקט מציג שיטות עבודה מומלצות לארגון סוכני AI רבים, אינטגרציה של נתוני ארגונים, וספק פלטפורמה מאובטחת ומותאמת לסביבות אמיתיות.

## Key Features
- **Multi-Agent Orchestration:** משתמש ב-MCP לתיאום סוכנים מומחים (כגון סוכני טיסות, מלונות, ותכנוני מסלול) העובדים יחד כדי למלא משימות מורכבות בתכנון טיולים.
- **Enterprise Data Integration:** מחבר ל-Azure AI Search ולמקורות נתונים ארגוניים נוספים כדי לספק מידע עדכני ורלוונטי להמלצות טיול.
- **Secure, Scalable Architecture:** מנצל שירותי Azure לאימות, הרשאות ופריסה סקלאבילית, בהתאם לשיטות האבטחה הטובות ביותר בארגונים.
- **Extensible Tooling:** מיישם כלים ותבניות פרומפט חוזרות לשימוש ב-MCP, המאפשרות התאמה מהירה לתחומים או דרישות עסקיות חדשות.
- **User Experience:** מספק ממשק שיחה למשתמשים כדי לתקשר עם סוכני הטיולים, מופעל על ידי Azure OpenAI ו-MCP.

## Architecture
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Architecture Diagram Description

פתרון Azure AI Travel Agents בנוי למודולריות, סקלאביליות ואינטגרציה מאובטחת של סוכני AI רבים ומקורות נתונים ארגוניים. הרכיבים העיקריים וזרימת הנתונים הם:

- **User Interface:** המשתמשים מתקשרים עם המערכת דרך ממשק שיחה (כגון צ'אט באתר או בוט ב-Teams), ששולח שאילתות ומקבל המלצות טיול.
- **MCP Server:** משמש כמנהל המרכזי, מקבל את הקלט מהמשתמש, מנהל את ההקשר ומתאם את פעולות הסוכנים המומחים (כגון FlightAgent, HotelAgent, ItineraryAgent) באמצעות Model Context Protocol.
- **AI Agents:** כל סוכן אחראי לתחום מסוים (טיסות, מלונות, מסלולים) וממומש ככלי MCP. הסוכנים משתמשים בתבניות פרומפט ולוגיקה לעיבוד בקשות ויצירת תגובות.
- **Azure OpenAI Service:** מספק הבנה ויצירת שפה טבעית מתקדמת, ומאפשר לסוכנים לפרש את כוונת המשתמש וליצור תגובות שיחה.
- **Azure AI Search & Enterprise Data:** הסוכנים מבצעים שאילתות ב-Azure AI Search ובמקורות נתונים ארגוניים נוספים כדי לקבל מידע עדכני על טיסות, מלונות ואפשרויות נסיעה.
- **Authentication & Security:** משתלב עם Microsoft Entra ID לאימות מאובטח ומיישם בקרות גישה ברמת הרשאות מינימליות לכל המשאבים.
- **Deployment:** מתוכנן לפריסה ב-Azure Container Apps, המבטיחה סקלאביליות, ניטור ויעילות תפעולית.

ארכיטקטורה זו מאפשרת תיאום חלק של סוכני AI מרובים, אינטגרציה מאובטחת עם נתוני ארגון, ופלטפורמה חזקה ומותאמת לבניית פתרונות AI תחומיים.

## Step-by-Step Explanation of the Architecture Diagram
תארו לעצמכם שאתם מתכננים טיול גדול ויש לכם צוות של עוזרים מומחים שעוזרים לכם בכל פרט. מערכת Azure AI Travel Agents פועלת באופן דומה, כשהחלקים השונים (כמו חברי צוות) כל אחד ממלא תפקיד מיוחד. כך זה מתחבר:

### User Interface (UI):
תחשבו על זה כלשכת הקבלה של סוכן הנסיעות שלכם. כאן אתם (המשתמשים) שואלים שאלות או מבקשים משהו, כמו "מצא לי טיסה לפריז". זה יכול להיות חלון צ'אט באתר או אפליקציית הודעות.

### MCP Server (The Coordinator):
שרת MCP הוא כמו המנהל שמקשיב לבקשה שלכם בלשכה ומחליט איזה מומחה יטפל בכל חלק. הוא עוקב אחרי השיחה ודואג שהכל יתנהל חלק.

### AI Agents (Specialist Assistants):
כל סוכן הוא מומחה בתחום מסוים – אחד בטיסות, אחר במלונות, ואחר בתכנון מסלול. כשהם מבקשים טיול, שרת MCP שולח את הבקשה לסוכן המתאים. הסוכנים משתמשים בידע ובכלים שלהם כדי למצוא את האפשרויות הטובות ביותר עבורכם.

### Azure OpenAI Service (Language Expert):
כמו מומחה שפה שמבין בדיוק מה אתם מבקשים, לא משנה איך ניסחתם את זה. הוא עוזר לסוכנים להבין את הבקשות שלכם ולהגיב בשפה טבעית ושיחה.

### Azure AI Search & Enterprise Data (Information Library):
תארו לכם ספרייה ענקית ומעודכנת עם כל המידע העדכני על טיסות, זמינות מלונות ועוד. הסוכנים מחפשים בספרייה הזאת כדי להביא לכם את התשובות המדויקות ביותר.

### Authentication & Security (Security Guard):
כמו שומר שמוודא מי מורשה להיכנס לאזורים מסוימים, החלק הזה מוודא שרק אנשים וסוכנים מורשים יכולים לגשת למידע רגיש. הוא שומר על הנתונים שלכם בטוחים ופרטיים.

### Deployment on Azure Container Apps (The Building):
כל העוזרים והכלים האלה עובדים יחד בתוך בניין מאובטח וסקלאבילי (הענן). זה אומר שהמערכת יכולה לטפל בהרבה משתמשים בו זמנית ותמיד זמינה כשאתם צריכים אותה.

## How it all works together:

אתם מתחילים בשאלה בלשכה (UI).  
המנהל (MCP Server) מחליט איזה מומחה (סוכן) יעזור לכם.  
המומחה משתמש במומחה השפה (OpenAI) כדי להבין את הבקשה ובספרייה (AI Search) כדי למצוא את התשובה הטובה ביותר.  
השומר (Authentication) מוודא שהכל בטוח.  
כל זה מתרחש בתוך בניין אמין וסקלאבילי (Azure Container Apps), כך שהחוויה שלכם חלקה ומאובטחת.  
העבודה הצוותית הזו מאפשרת למערכת לעזור לכם לתכנן את הטיול במהירות ובבטחה, ממש כמו צוות סוכני נסיעות מומחים במשרד מודרני!

## Technical Implementation
- **MCP Server:** מארח את הלוגיקה המרכזית לארגון, חושף כלים של סוכנים ומנהל הקשר עבור תהליכי תכנון טיולים רב-שלביים.
- **Agents:** כל סוכן (כגון FlightAgent, HotelAgent) ממומש ככלי MCP עם תבניות פרומפט ולוגיקה משלו.
- **Azure Integration:** משתמש ב-Azure OpenAI להבנת שפה טבעית ו-Azure AI Search לשליפת נתונים.
- **Security:** משתלב עם Microsoft Entra ID לאימות ומיישם בקרות גישה ברמת הרשאות מינימליות לכל המשאבים.
- **Deployment:** תומך בפריסה ל-Azure Container Apps לסקלאביליות ויעילות תפעולית.

## Results and Impact
- מדגים כיצד ניתן להשתמש ב-MCP לארגון סוכני AI רבים בתרחיש אמיתי וייצורי.
- מאיץ פיתוח פתרונות באמצעות תבניות חוזרות לתיאום סוכנים, אינטגרציית נתונים ופריסה מאובטחת.
- משמש כתבנית לבניית אפליקציות AI תחומיות מבוססות MCP ושירותי Azure.

## References
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Disclaimer**:  
This document has been translated using AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.

---

(Note: "mo" is not a recognized language code or widely known language. Could you please clarify which language "mo" refers to, or provide more details?)