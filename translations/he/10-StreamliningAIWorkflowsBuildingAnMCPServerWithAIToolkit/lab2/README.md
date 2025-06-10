<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a22b7dd11cd7690f99f9195877cafdc3",
  "translation_date": "2025-06-10T05:52:38+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab2/README.md",
  "language_code": "he"
}
-->
# 🌐 מודול 2: יסודות MCP עם ערכת כלים AI

[![Duration](https://img.shields.io/badge/Duration-20%20minutes-blue.svg)]()
[![Difficulty](https://img.shields.io/badge/Difficulty-Intermediate-yellow.svg)]()
[![Prerequisites](https://img.shields.io/badge/Prerequisites-Module%201%20Complete-orange.svg)]()

## 📋 מטרות הלמידה

בסיום מודול זה תוכל:
- ✅ להבין את ארכיטקטורת Model Context Protocol (MCP) ואת היתרונות שלה
- ✅ לחקור את מערך שרתי MCP של מיקרוסופט
- ✅ לשלב שרתי MCP עם AI Toolkit Agent Builder
- ✅ לבנות סוכן אוטומציה לדפדפן פונקציונלי באמצעות Playwright MCP
- ✅ להגדיר ולבדוק כלי MCP בתוך הסוכנים שלך
- ✅ לייצא ולפרוס סוכני MCP לשימוש בפרודקשן

## 🎯 המשך למודול 1

במודול 1 רכשנו את יסודות AI Toolkit ויצרנו את סוכן הפייתון הראשון שלנו. עכשיו נוכל **להעצים** את הסוכנים שלך על ידי חיבורם לכלים ולשירותים חיצוניים דרך פרוטוקול מהפכני בשם **Model Context Protocol (MCP)**.

תחשוב על זה כשדרוג ממחשבון פשוט למחשב מלא - סוכני ה-AI שלך יקבלו את היכולת:
- 🌐 לגלוש ולהתفاعل עם אתרים
- 📁 לגשת ולנהל קבצים
- 🔧 להשתלב עם מערכות ארגוניות
- 📊 לעבד נתונים בזמן אמת מ-APIs

## 🧠 הבנת Model Context Protocol (MCP)

### 🔍 מה זה MCP?

Model Context Protocol (MCP) הוא ה"USB-C של יישומי AI" - תקן פתוח מהפכני שמחבר מודלים גדולים של שפה (LLMs) לכלים חיצוניים, מקורות נתונים ושירותים. בדיוק כמו ש-USB-C פתר את בעיית הכבלים עם חיבור אוניברסלי אחד, MCP מפשט את האינטגרציה של AI עם פרוטוקול סטנדרטי אחד.

### 🎯 הבעיה ש-MCP פותר

**לפני MCP:**
- 🔧 אינטגרציות מותאמות לכל כלי בנפרד
- 🔄 תלות בספקים עם פתרונות קנייניים  
- 🔒 פרצות אבטחה מחיבורים לא מתוכננים
- ⏱️ חודשים של פיתוח לאינטגרציות בסיסיות

**עם MCP:**
- ⚡ אינטגרציה פשוטה עם כלים מוכנים לשימוש
- 🔄 ארכיטקטורה בלתי תלויה בספקים
- 🛡️ אבטחה מובנית לפי מיטב הנוהגים
- 🚀 הוספת יכולות חדשות בתוך דקות

### 🏗️ ארכיטקטורת MCP לעומק

MCP מבוסס על ארכיטקטורת **לקוח-שרת** שיוצרת אקוסיסטם מאובטח וניתן להרחבה:

```mermaid
graph TB
    A[AI Application/Agent] --> B[MCP Client]
    B --> C[MCP Server 1: Files]
    B --> D[MCP Server 2: Web APIs]
    B --> E[MCP Server 3: Database]
    B --> F[MCP Server N: Custom Tools]
    
    C --> G[Local File System]
    D --> H[External APIs]
    E --> I[Database Systems]
    F --> J[Enterprise Systems]
```

**🔧 רכיבים מרכזיים:**

| רכיב | תפקיד | דוגמאות |
|-----------|------|----------|
| **MCP Hosts** | יישומים שצורכים שירותי MCP | Claude Desktop, VS Code, AI Toolkit |
| **MCP Clients** | מנהלי פרוטוקול (1:1 עם שרתים) | משולבים ביישומי ה-host |
| **MCP Servers** | חושפים יכולות דרך פרוטוקול סטנדרטי | Playwright, Files, Azure, GitHub |
| **שכבת תקשורת** | שיטות תקשורת | stdio, HTTP, WebSockets |


## 🏢 מערך שרתי MCP של מיקרוסופט

מיקרוסופט מובילה את אקוסיסטם ה-MCP עם סט שרתים ארגוניים מקיף שמענה לצרכים עסקיים אמיתיים.

### 🌟 שרתי MCP מובילים של מיקרוסופט

#### 1. ☁️ שרת Azure MCP
**🔗 מאגר קוד**: [azure/azure-mcp](https://github.com/azure/azure-mcp)  
**🎯 מטרה**: ניהול משאבי Azure מקיף עם אינטגרציית AI

**✨ תכונות עיקריות:**
- פרוביז’נינג תשתיתי דקלרטיבי  
- ניטור משאבים בזמן אמת  
- המלצות לאופטימיזציית עלויות  
- בדיקת תאימות אבטחה

**🚀 מקרי שימוש:**
- Infrastructure-as-Code עם סיוע AI  
- סקיילינג אוטומטי של משאבים  
- אופטימיזציית עלויות ענן  
- אוטומציה של תהליכי DevOps

#### 2. 📊 Microsoft Dataverse MCP
**📚 תיעוד**: [Microsoft Dataverse Integration](https://go.microsoft.com/fwlink/?linkid=2320176)  
**🎯 מטרה**: ממשק שפה טבעית לנתוני עסק

**✨ תכונות עיקריות:**
- שאילתות מסדי נתונים בשפה טבעית  
- הבנת הקשר עסקי  
- תבניות פרומפט מותאמות  
- ממשל נתוני ארגון

**🚀 מקרי שימוש:**
- דיווחים של בינה עסקית  
- ניתוח נתוני לקוחות  
- תובנות לצינור מכירות  
- שאילתות נתוני תאימות

#### 3. 🌐 שרת Playwright MCP
**🔗 מאגר קוד**: [microsoft/playwright-mcp](https://github.com/microsoft/playwright-mcp)  
**🎯 מטרה**: אוטומציה לדפדפן ויכולות אינטראקציה עם אתרים

**✨ תכונות עיקריות:**
- אוטומציה חוצת דפדפנים (Chrome, Firefox, Safari)  
- זיהוי אלמנטים חכם  
- יצירת צילומי מסך ו-PDF  
- ניטור תעבורת רשת

**🚀 מקרי שימוש:**
- אוטומציה של תהליכי בדיקה  
- סקרייפינג והפקת נתונים מהאתר  
- ניטור UI/UX  
- אוטומציה לניתוח תחרות

#### 4. 📁 שרת Files MCP
**🔗 מאגר קוד**: [microsoft/files-mcp-server](https://github.com/microsoft/files-mcp-server)  
**🎯 מטרה**: ניהול מערכת קבצים חכמה

**✨ תכונות עיקריות:**
- ניהול קבצים דקלרטיבי  
- סינכרון תוכן  
- אינטגרציה עם בקרת גרסאות  
- חילוץ מטא-דאטה

**🚀 מקרי שימוש:**
- ניהול תיעוד  
- ארגון מאגרי קוד  
- תהליכי פרסום תוכן  
- טיפול בקבצים בצנרת נתונים

#### 5. 📝 שרת MarkItDown MCP
**🔗 מאגר קוד**: [microsoft/markitdown](https://github.com/microsoft/markitdown)  
**🎯 מטרה**: עיבוד ומניפולציה מתקדמים של Markdown

**✨ תכונות עיקריות:**
- ניתוח Markdown עשיר  
- המרת פורמטים (MD ↔ HTML ↔ PDF)  
- ניתוח מבנה תוכן  
- עיבוד תבניות

**🚀 מקרי שימוש:**
- תהליכי תיעוד טכני  
- מערכות ניהול תוכן  
- יצירת דוחות  
- אוטומציה של בסיסי ידע

#### 6. 📈 שרת Clarity MCP
**📦 חבילה**: [@microsoft/clarity-mcp-server](https://www.npmjs.com/package/@microsoft/clarity-mcp-server)  
**🎯 מטרה**: ניתוח ווב ותובנות התנהגות משתמש

**✨ תכונות עיקריות:**
- ניתוח מפות חום  
- הקלטות סשנים של משתמשים  
- מדדי ביצועים  
- ניתוח משפך המרה

**🚀 מקרי שימוש:**
- אופטימיזציית אתרים  
- מחקר חוויית משתמש  
- ניתוח A/B  
- לוחות מחוונים של בינה עסקית

### 🌍 אקוסיסטם קהילתי

מעבר לשרתי מיקרוסופט, אקוסיסטם MCP כולל:
- **🐙 GitHub MCP**: ניהול מאגרים וניתוח קוד  
- **🗄️ Database MCPs**: אינטגרציות עם PostgreSQL, MySQL, MongoDB  
- **☁️ Cloud Provider MCPs**: כלים ל-AWS, GCP, Digital Ocean  
- **📧 Communication MCPs**: אינטגרציות עם Slack, Teams, דוא"ל

## 🛠️ מעבדת פרקטיקה: בניית סוכן אוטומציה לדפדפן

**🎯 מטרת הפרויקט**: ליצור סוכן אוטומציה חכם לדפדפן באמצעות שרת Playwright MCP שיכול לגלוש באתרים, לחלץ מידע ולבצע אינטראקציות מורכבות.

### 🚀 שלב 1: הקמת בסיס הסוכן

#### שלב 1: אתחל את הסוכן שלך
1. **פתח את AI Toolkit Agent Builder**  
2. **צור סוכן חדש** עם ההגדרות הבאות:  
   - **שם**: `BrowserAgent`
   - **Model**: Choose GPT-4o 

![BrowserAgent](../../../../translated_images/BrowserAgent.09c1adde5e136573b64ab1baecd830049830e295eac66cb18bebb85fb386e00a.he.png)


### 🔧 Phase 2: MCP Integration Workflow

#### Step 3: Add MCP Server Integration
1. **Navigate to Tools Section** in Agent Builder
2. **Click "Add Tool"** to open the integration menu
3. **Select "MCP Server"** from available options

![AddMCP](../../../../translated_images/AddMCP.afe3308ac20aa94469a5717b632d77b2197b9838a438b05d39aeb2db3ec47ef1.he.png)

**🔍 Understanding Tool Types:**
- **Built-in Tools**: Pre-configured AI Toolkit functions
- **MCP Servers**: External service integrations
- **Custom APIs**: Your own service endpoints
- **Function Calling**: Direct model function access

#### Step 4: MCP Server Selection
1. **Choose "MCP Server"** option to proceed
![AddMCPServer](../../../../translated_images/AddMCPServer.69b911ccef872cbd0d0c0c2e6a00806916e1673e543b902a23dee23e6ff54b4c.he.png)

2. **Browse MCP Catalog** to explore available integrations
![MCPCatalog](../../../../translated_images/MCPCatalog.a817d053145699006264f5a475f2b48fbd744e43633f656b6453c15a09ba5130.he.png)


### 🎮 Phase 3: Playwright MCP Configuration

#### Step 5: Select and Configure Playwright
1. **Click "Use Featured MCP Servers"** to access Microsoft's verified servers
2. **Select "Playwright"** from the featured list
3. **Accept Default MCP ID** or customize for your environment

![MCPID](../../../../translated_images/MCPID.67d446052979e819c945ff7b6430196ef587f5217daadd3ca52fa9659c1245c9.he.png)

#### Step 6: Enable Playwright Capabilities
**🔑 Critical Step**: Select **ALL** available Playwright methods for maximum functionality

![Tools](../../../../translated_images/Tools.3ea23c447b4d9feccbd7101e6dcf9e27cb0e5273f351995fde62c5abf9a78b4c.he.png)

**🛠️ Essential Playwright Tools:**
- **Navigation**: `goto`, `goBack`, `goForward`, `reload`
- **Interaction**: `click`, `fill`, `press`, `hover`, `drag`
- **Extraction**: `textContent`, `innerHTML`, `getAttribute`
- **Validation**: `isVisible`, `isEnabled`, `waitForSelector`
- **Capture**: `screenshot`, `pdf`, `video`
- **Network**: `setExtraHTTPHeaders`, `route`, `waitForResponse`

#### שלב 7: אמת הצלחת אינטגרציה
**✅ סימני הצלחה:**
- כל הכלים מופיעים בממשק Agent Builder  
- אין הודעות שגיאה בפאנל האינטגרציה  
- סטטוס שרת Playwright מציג "Connected"

![AgentTools](../../../../translated_images/AgentTools.053cfb96a17e02199dcc6563010d2b324d4fc3ebdd24889657a6950647a52f63.he.png)

**🔧 פתרון תקלות נפוצות:**
- **כשל בחיבור**: בדוק את חיבור האינטרנט והגדרות חומת האש  
- **כלים חסרים**: ודא שכל היכולות נבחרו בזמן ההגדרה  
- **שגיאות הרשאה**: וודא ש-VS Code מקבל הרשאות מערכת נדרשות

### 🎯 שלב 4: הנדסת פרומפטים מתקדמת

#### שלב 8: עצב פרומפטים חכמים למערכת
צור פרומפטים מתוחכמים שמנצלים את כל יכולות Playwright:

```markdown
# Web Automation Expert System Prompt

## Core Identity
You are an advanced web automation specialist with deep expertise in browser automation, web scraping, and user experience analysis. You have access to Playwright tools for comprehensive browser control.

## Capabilities & Approach
### Navigation Strategy
- Always start with screenshots to understand page layout
- Use semantic selectors (text content, labels) when possible
- Implement wait strategies for dynamic content
- Handle single-page applications (SPAs) effectively

### Error Handling
- Retry failed operations with exponential backoff
- Provide clear error descriptions and solutions
- Suggest alternative approaches when primary methods fail
- Always capture diagnostic screenshots on errors

### Data Extraction
- Extract structured data in JSON format when possible
- Provide confidence scores for extracted information
- Validate data completeness and accuracy
- Handle pagination and infinite scroll scenarios

### Reporting
- Include step-by-step execution logs
- Provide before/after screenshots for verification
- Suggest optimizations and alternative approaches
- Document any limitations or edge cases encountered

## Ethical Guidelines
- Respect robots.txt and rate limiting
- Avoid overloading target servers
- Only extract publicly available information
- Follow website terms of service
```

#### שלב 9: צור פרומפטים דינמיים למשתמש
עצב פרומפטים שמדגימים יכולות שונות:

**🌐 דוגמה לניתוח ווב:**
```markdown
Navigate to github.com/kinfey and provide a comprehensive analysis including:
1. Repository structure and organization
2. Recent activity and contribution patterns  
3. Documentation quality assessment
4. Technology stack identification
5. Community engagement metrics
6. Notable projects and their purposes

Include screenshots at key steps and provide actionable insights.
```

![Prompt](../../../../translated_images/Prompt.bfc846605db4999f4d9c1b09c710ef63cae7b3057444e68bf07240fb142d9f8f.he.png)

### 🚀 שלב 5: ביצוע ובדיקה

#### שלב 10: הפעל את האוטומציה הראשונה שלך
1. **לחץ על "Run"** כדי להתחיל את רצף האוטומציה  
2. **עקוב אחרי ביצוע בזמן אמת**:  
   - דפדפן Chrome נפתח אוטומטית  
   - הסוכן גולש לאתר היעד  
   - צילומי מסך מתועדים בכל שלב חשוב  
   - תוצאות הניתוח מופיעות בשידור חי

![Browser](../../../../translated_images/Browser.ec011d0bd64d0d112c8a29bd8cc44c76d0bbfd0b019cb2983ef679328435ce5d.he.png)

#### שלב 11: נתח תוצאות ותובנות
סקור ניתוח מקיף בממשק Agent Builder:

![Result](../../../../translated_images/Result.8638f2b6703e9ea6d58d4e4475e39456b6a51d4c787f9bf481bae694d370a69a.he.png)

### 🌟 שלב 6: יכולות מתקדמות ופריסה

#### שלב 12: ייצא ופרוס לפרודקשן
Agent Builder תומך באפשרויות פריסה מגוונות:

![Code](../../../../translated_images/Code.d9eeeead0b96db0ca19c5b10ad64cfea8c1d0d1736584262970a4d43e1403d13.he.png)

## 🎓 סיכום מודול 2 ושלבים הבאים

### 🏆 הישג שהושג: מאסטר באינטגרציית MCP

**✅ מיומנויות שנרכשו:**
- [ ] הבנת ארכיטקטורת MCP ויתרונותיה  
- [ ] ניווט במערך שרתי MCP של מיקרוסופט  
- [ ] שילוב Playwright MCP עם AI Toolkit  
- [ ] בניית סוכני אוטומציה לדפדפן מתקדמים  
- [ ] הנדסת פרומפטים מתקדמת לאוטומציה וובית

### 📚 משאבים נוספים

- **🔗 מפרט MCP**: [מסמכי הפרוטוקול הרשמיים](https://modelcontextprotocol.io/)  
- **🛠️ API של Playwright**: [מדריך שיטות מלא](https://playwright.dev/docs/api/class-playwright)  
- **🏢 שרתי MCP של מיקרוסופט**: [מדריך אינטגרציה ארגונית](https://github.com/microsoft/mcp-servers)  
- **🌍 דוגמאות קהילתיות**: [גלריית שרתי MCP](https://github.com/modelcontextprotocol/servers)

**🎉 מזל טוב!** שלטת בהצלחה באינטגרציית MCP ועכשיו תוכל לבנות סוכני AI מוכנים לפרודקשן עם יכולות כלים חיצוניים!


### 🔜 המשך למודול הבא

מוכן לקחת את מיומנויות ה-MCP שלך לשלב הבא? המשך ל-**[מודול 3: פיתוח MCP מתקדם עם AI Toolkit](../lab3/README.md)** שם תלמד כיצד:  
- ליצור שרתי MCP מותאמים אישית משלך  
- להגדיר ולהשתמש ב-SDK האחרון של MCP לפייתון  
- להקים את MCP Inspector לצורך ניפוי באגים  
- לשלוט בתהליכי פיתוח שרתי MCP מתקדמים  
- לבנות שרת MCP למזג אוויר מאפס

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון שתרגומים אוטומטיים עלולים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפת המקור שלו צריך להיחשב כמקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי אדם. אנו לא אחראים לכל אי הבנה או פרשנות שגויה הנובעים משימוש בתרגום זה.