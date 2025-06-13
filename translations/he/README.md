<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26ab12045ee411ab7ad0eb0b1b7b1cbb",
  "translation_date": "2025-06-13T00:21:23+00:00",
  "source_file": "README.md",
  "language_code": "he"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.he.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


עקבו אחר השלבים האלה כדי להתחיל להשתמש במשאבים האלה:
1. **צור Fork למאגר**: לחץ על [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **שכפל את המאגר**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**הצטרף ל-Discord של Azure AI Foundry ופגוש מומחים ומפתחים אחרים**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 תמיכה בריבוי שפות

#### נתמך דרך GitHub Action (אוטומטי ותמיד מעודכן)

# 🚀 תכנית הלימודים של Model Context Protocol (MCP) למתחילים

## **למדו MCP עם דוגמאות קוד מעשיות ב-C#, Java, JavaScript, Python ו-TypeScript**

## 🧠 סקירה כללית של תכנית הלימודים של Model Context Protocol

**Model Context Protocol (MCP)** הוא מסגרת חדשנית שנועדה לסטנדרטיזציה של האינטראקציות בין מודלי בינה מלאכותית ליישומי לקוח. תכנית הלימודים בקוד פתוח זו מציעה מסלול למידה מובנה, כולל דוגמאות קוד מעשיות ומקרי שימוש מהעולם האמיתי, בשפות תכנות פופולריות כגון C#, Java, JavaScript, TypeScript ו-Python.

בין אם אתה מפתח בינה מלאכותית, אדריכל מערכות או מהנדס תוכנה, מדריך זה הוא המשאב המקיף שלך לשליטה ביסודות MCP ואסטרטגיות יישום.

## 🔗 משאבים רשמיים של MCP

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – מדריכים מפורטים ומדריכי משתמש  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – ארכיטקטורת הפרוטוקול והתייחסויות טכניות  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – SDKs, כלים ודוגמאות קוד בקוד פתוח  

## 🧭 מבנה מלא של תכנית הלימודים של MCP

| פרק | כותרת | תיאור | קישור |
|--|--|--|--|
| 00 | **מבוא ל-MCP** | סקירה כללית של Model Context Protocol וחשיבותו בצינורות AI, כולל מהו Model Context Protocol, מדוע סטנדרטיזציה חשובה, ומקרי שימוש ויתרונות מעשיים | [Introduction](./00-Introduction/README.md) |
| 01 | **הסברים על מושגים מרכזיים** | חקירה מעמיקה של המושגים המרכזיים ב-MCP, כולל ארכיטקטורת לקוח-שרת, רכיבי הפרוטוקול המרכזיים ודפוסי הודעות | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **אבטחה ב-MCP** | זיהוי איומי אבטחה במערכות מבוססות MCP, טכניקות ופרקטיקות מיטביות לאבטחת יישומים | [Security](/02-Security/README.md) |
| 03 | **התחלה עם MCP** | הגדרת סביבה וקונפיגורציה, יצירת שרתי ולקוחות MCP בסיסיים, שילוב MCP עם יישומים קיימים | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **שרת ראשון** | הקמת שרת בסיסי באמצעות פרוטוקול MCP, הבנת האינטראקציה בין שרת ללקוח, ובדיקת השרת | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **לקוח ראשון** | הקמת לקוח בסיסי באמצעות פרוטוקול MCP, הבנת האינטראקציה בין לקוח לשרת, ובדיקת הלקוח | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **לקוח עם LLM** | הקמת לקוח המשתמש ב-MCP עם מודל שפה גדול (LLM) | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **צריכת שרת עם Visual Studio Code** | הגדרת Visual Studio Code לצריכת שרתים באמצעות פרוטוקול MCP | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **יצירת שרת באמצעות SSE** | SSE מאפשר לנו לחשוף שרת לאינטרנט. חלק זה יעזור לך ליצור שרת באמצעות SSE | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **שימוש ב-AI Toolkit** | AI Toolkit הוא כלי נהדר שיעזור לך לנהל את זרימת העבודה של ה-AI וה-MCP שלך | [Use AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **בדיקת השרת שלך** | בדיקות הן חלק חשוב מתהליך הפיתוח. חלק זה יעזור לך לבדוק באמצעות מספר כלים שונים | [Testing your server](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **פריסת השרת שלך** | איך עוברים מפיתוח מקומי לייצור? חלק זה יעזור לך לפתח ולפרוס את השרת שלך | [Deploy your server](./03-GettingStarted/08-deployment/README.md) |
| 04 | **יישום מעשי** | שימוש ב-SDKs בשפות שונות, איתור שגיאות, בדיקות ואימות, יצירת תבניות פרומפט וזרימות עבודה שניתנות לשימוש חוזר | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **נושאים מתקדמים ב-MCP** | זרימות עבודה מולטימודליות והרחבה, אסטרטגיות אבטחה להרחבה, MCP במערכות ארגוניות | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **אינטגרציה של MCP עם Azure** | מציג אינטגרציה עם Azure | [MCP Azure integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **ריבוי מודאליות** | מציג עבודה עם מודאליות שונות כמו תמונות ועוד | [Multi modality](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **דמו OAuth2 של MCP** | אפליקציית Spring Boot מינימלית המציגה OAuth2 עם MCP, גם כסרבר הרשאה וגם כסרבר משאבים. מדגים הנפקת טוקנים מאובטחת, נקודות קצה מוגנות, פריסת Azure Container Apps ואינטגרציה עם ניהול API | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **קונטקסטים שורשיים** | למדו עוד על קונטקסט שורשי וכיצד ליישם אותם | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **ניתוב** | למדו סוגים שונים של ניתוב | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **דגימה** | למדו כיצד לעבוד עם דגימה | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **הרחבה** | למדו על הרחבת שרתי MCP, כולל אסטרטגיות הרחבה אופקית ואנכית, אופטימיזציה של משאבים וכיוונון ביצועים | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **אבטחה** | אבטחו את שרת MCP שלכם, כולל אסטרטגיות אימות, הרשאה והגנת נתונים | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **חיפוש אינטרנטי MCP** | שרת ולקוח MCP בפייתון המשולבים עם SerpAPI לחיפוש אינטרנטי בזמן אמת, חדשות, מוצרים ושאלות ותשובות. מדגים תיאום רב-כלים, אינטגרציה עם API חיצוני וטיפול שגיאות חזק | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **שידור בזמן אמת** | שידור נתונים בזמן אמת הפך לחיוני בעולם הנתונים של היום, שבו עסקים ויישומים זקוקים לגישה מיידית למידע כדי לקבל החלטות בזמן | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **חיפוש אינטרנטי בזמן אמת** | חיפוש אינטרנטי בזמן אמת – כיצד MCP משנה את חיפוש האינטרנט בזמן אמת על ידי מתן גישה סטנדרטית לניהול קונטקסט בין מודלי AI, מנועי חיפוש ויישומים | [Realtime Web Search](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **תרומות קהילתיות** | כיצד לתרום קוד ותיעוד, שיתוף פעולה דרך GitHub, שיפורים ומשוב מונחי קהילה | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **תובנות מאימוץ מוקדם** | יישומים מהעולם האמיתי ומה עבד, בנייה ופריסה של פתרונות מבוססי MCP, מגמות ומפת דרכים עתידית | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **הנחיות עבודה מומלצות ל-MCP** | כיוונון ביצועים ואופטימיזציה, תכנון מערכות MCP עמידות לתקלות, אסטרטגיות בדיקה ועמידות | [Best Practices](./08-BestPractices/README.md) |
| 09 | **מקרי מבחן ל-MCP** | ניתוח מעמיק של ארכיטקטורות פתרונות MCP, תבניות פריסה וטיפים לאינטגרציה, דיאגרמות מוסברות והדרכות פרויקטים | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **פישוט זרימות עבודה של AI: בניית שרת MCP עם ערכת כלים AI** | סדנת מעשית מקיפה שמשלבת MCP עם ערכת הכלים AI של מיקרוסופט ל-VS Code. למדו לבנות אפליקציות חכמות שמחברות בין מודלי AI לכלים מהעולם האמיתי דרך מודולים מעשיים המכסים יסודות, פיתוח שרת מותאם ואסטרטגיות פריסה בייצור. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## פרויקטים לדוגמה

### 🧮 פרויקטים לדוגמה של מחשבון MCP:
<details>
  <summary><strong>חקור מימושי קוד לפי שפה</strong></summary>

  - [דוגמה לשרת MCP ב-C#](./03-GettingStarted/samples/csharp/README.md)
  - [מחשבון MCP בג'אווה](./03-GettingStarted/samples/java/calculator/README.md)
  - [הדגמת MCP ב-JavaScript](./03-GettingStarted/samples/javascript/README.md)
  - [שרת MCP בפייתון](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [דוגמה ל-MCP ב-TypeScript](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 פרויקטים מתקדמים למחשבון MCP:
<details>
  <summary><strong>חקור דוגמאות מתקדמות</strong></summary>

  - [דוגמה מתקדמת ב-C#](./04-PracticalImplementation/samples/csharp/README.md)
  - [דוגמת אפליקציית מכולה בג'אווה](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [דוגמה מתקדמת ב-JavaScript](./04-PracticalImplementation/samples/javascript/README.md)
  - [מימוש מורכב בפייתון](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [דוגמת מכולה ב-TypeScript](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 דרישות מוקדמות ללימוד MCP

כדי להפיק את המרב מתכנית הלימודים הזו, מומלץ שיהיו לכם:

- ידע בסיסי ב-C#, Java או Python  
- הבנה של מודל לקוח-שרת ו-APIs  
- (אופציונלי) היכרות עם מושגי למידת מכונה  

## 📚 מדריך לימוד

מדריך לימוד מקיף [Study Guide](./study_guide.md) זמין כדי לעזור לכם לנווט במחסן זה ביעילות. המדריך כולל:

- מפת תכנית לימודים ויזואלית המציגה את כל הנושאים המכוסים  
- פירוט מפורט של כל חלק במחסן  
- הדרכה על שימוש בפרויקטים לדוגמה  
- דרכי למידה מומלצות לרמות מיומנות שונות  
- משאבים נוספים להשלמת מסלול הלמידה שלכם  

## 🛠️ איך להשתמש בתכנית הלימודים הזו ביעילות

כל שיעור במדריך זה כולל:

1. הסברים ברורים על מושגי MCP  
2. דוגמאות קוד חיות בשפות שונות  
3. תרגילים לבניית אפליקציות MCP אמיתיות  
4. משאבים נוספים ללומדים מתקדמים  

## 📜 מידע על רישיון

תוכן זה מורשה תחת **רישיון MIT**. לתנאים ולכללים ראו את [LICENSE](../../LICENSE).

## 🤝 הנחיות לתרומה

הפרויקט הזה מקבל תרומות והצעות. רוב התרומות דורשות שתסכימו להסכם רישיון תורם (CLA) שמצהיר שיש לכם את הזכות, וכי אתם אכן מעניקים לנו את הזכויות להשתמש בתרומתכם. לפרטים, בקרו בכתובת <https://cla.opensource.microsoft.com>.

כשאתם מגישים בקשת משיכה, בוט CLA יקבע אוטומטית אם אתם צריכים לספק CLA ויעטר את הבקשה בהתאם (למשל, בדיקת סטטוס, תגובה). פשוט עקבו אחרי ההוראות שהבוט מספק. תצטרכו לעשות זאת רק פעם אחת בכל המחסנים שמשתמשים ב-CLA שלנו.

הפרויקט אימץ את [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). למידע נוסף ראו את [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) או צרו קשר ב-[opencode@microsoft.com](mailto:opencode@microsoft.com) עם שאלות או הערות נוספות.

## 🎒 קורסים נוספים  
הצוות שלנו מפתח קורסים נוספים! בדקו:

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [Generative AI for Beginners using .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)  
- [Generative AI for Beginners using JavaScript](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)  
- [Generative AI for Beginners](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [ML for Beginners](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)  
- [Data Science for Beginners](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)  
- [AI for Beginners](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)  
- [Cybersecurity for Beginners](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)  
- [Web Dev for Beginners](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)  
- [IoT for Beginners](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)  
- [XR Development for Beginners](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [Mastering GitHub Copilot for AI Paired Programming](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for C#/.NET Developers](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Choose Your Own Copilot Adventure](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ הודעת סימן מסחר

ייתכן שהפרויקט הזה מכיל סימני מסחר או לוגואים של פרויקטים, מוצרים או שירותים. שימוש מורשה בסימני המסחר או בלוגואים של Microsoft כפוף וחייב לעמוד ב
[הנחיות סימני המסחר והמוניטין של Microsoft](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
שימוש בסימני המסחר או בלוגואים של Microsoft בגרסאות מותאמות של פרויקט זה אסור שיגרום לבלבול או ירמז על חסות של Microsoft.
כל שימוש בסימני מסחר או בלוגואים של צד שלישי כפוף למדיניות של אותם צדדים שלישיים.

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפתו המקורית הוא המקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי של מתרגם אנושי. אנו לא נושאים באחריות על כל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.