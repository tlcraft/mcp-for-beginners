<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c7fbf0cdaa44b3245daff0c8bb4f439e",
  "translation_date": "2025-06-11T15:58:05+00:00",
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


עקבו אחרי השלבים הבאים כדי להתחיל להשתמש במשאבים אלו:
1. **צרו Fork למאגר**: לחצו על [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **שכפלו את המאגר**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**הצטרפו ל- Azure AI Foundry Discord והכירו מומחים ומפתחים נוספים**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 תמיכה בריבוי שפות

#### נתמך דרך GitHub Action (אוטומטי ותמיד מעודכן)

# 🚀 תכנית הלימודים של Model Context Protocol (MCP) למתחילים

## **למדו MCP עם דוגמאות קוד מעשיות ב-C#, Java, JavaScript, Python ו-TypeScript**

## 🧠 סקירה כללית של תכנית הלימודים של Model Context Protocol

**Model Context Protocol (MCP)** הוא מסגרת חדשנית שנועדה לסטנדרטיזציה של האינטראקציות בין מודלים של בינה מלאכותית ליישומי לקוח. תכנית הלימודים בקוד פתוח זו מציעה מסלול למידה מובנה, הכולל דוגמאות קוד מעשיות ומקרי שימוש מהעולם האמיתי, בשפות תכנות פופולריות כמו C#, Java, JavaScript, TypeScript ו-Python.

בין אם אתה מפתח AI, אדריכל מערכות או מהנדס תוכנה, מדריך זה הוא המשאב המקיף שלך לשליטה ביסודות MCP ואסטרטגיות יישום.

## 🔗 משאבים רשמיים של MCP

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – מדריכים מפורטים ומדריכי משתמש  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – ארכיטקטורת הפרוטוקול והפניות טכניות  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – SDKs, כלים ודוגמאות קוד בקוד פתוח  

## 🧭 מבנה מלא של תכנית הלימודים של MCP

| פרק | כותרת | תיאור | קישור |
|--|--|--|--|
| 00 | **הקדמה ל-MCP** | סקירה של Model Context Protocol וחשיבותו בצינורות AI, כולל מהו Model Context Protocol, מדוע סטנדרטיזציה חשובה ומקרי שימוש ויתרונות מעשיים | [Introduction](./00-Introduction/README.md) |
| 01 | **הסברים על מושגי יסוד** | חקירה מעמיקה של מושגי היסוד של MCP, כולל ארכיטקטורת לקוח-שרת, רכיבי הפרוטוקול המרכזיים ודפוסי תקשורת | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **אבטחה ב-MCP** | זיהוי איומי אבטחה במערכות מבוססות MCP, טכניקות ונהלים מומלצים לאבטחת יישומים | [Security](/02-Security/README.md) |
| 03 | **התחלה עם MCP** | הגדרת סביבה וקונפיגורציה, יצירת שרתים ולקוחות בסיסיים ב-MCP, אינטגרציה של MCP עם יישומים קיימים | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **שרת ראשון** | הקמת שרת בסיסי באמצעות פרוטוקול MCP, הבנת האינטראקציה בין שרת ללקוח, ובדיקת השרת | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **לקוח ראשון** | הקמת לקוח בסיסי באמצעות פרוטוקול MCP, הבנת האינטראקציה בין לקוח לשרת, ובדיקת הלקוח | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **לקוח עם LLM** | הקמת לקוח המשתמש בפרוטוקול MCP עם מודל שפה גדול (LLM) | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **צריכת שרת עם Visual Studio Code** | הגדרת Visual Studio Code לצריכת שרתים באמצעות פרוטוקול MCP | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **יצירת שרת באמצעות SSE** | SSE מאפשר לנו לחשוף שרת לאינטרנט. חלק זה יסייע לך ליצור שרת באמצעות SSE | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **שימוש בערכת כלים ל-AI** | ערכת כלים ל-AI היא כלי מצוין שיעזור לך לנהל את זרימת העבודה של AI ו-MCP שלך | [Use AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **בדיקת השרת שלך** | בדיקות הן חלק חשוב בתהליך הפיתוח. חלק זה יסייע לך לבצע בדיקות עם מספר כלים שונים | [Testing your server](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **פריסת השרת שלך** | איך עוברים מפיתוח מקומי לפרודקשן? חלק זה יעזור לך לפתח ולפרוס את השרת שלך | [Deploy your server](./03-GettingStarted/08-deployment/README.md) |
| 04 | **יישום מעשי** | שימוש ב-SDKs בשפות שונות, איתור באגים, בדיקות ואימות, יצירת תבניות פרומפט וזרימות עבודה לשימוש חוזר | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **נושאים מתקדמים ב-MCP** | זרימות עבודה רב-מודאליות והרחבה, אסטרטגיות סקיילינג מאובטחות, MCP באקוסיסטמים ארגוניים | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **אינטגרציה של MCP עם Azure** | מציג אינטגרציה עם Azure | [MCP Azure integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **רב-מודאליות** | מציג עבודה עם מודאליות שונות כמו תמונות ועוד | [Multi modality](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **הדגמת MCP OAuth2** | אפליקציית Spring Boot מינימלית המדגימה OAuth2 עם MCP, הן כשרת הרשאה והן כשרת משאבים. מציגה הנפקת טוקנים מאובטחת, נקודות קצה מוגנות, פריסת Azure Container Apps ואינטגרציה עם ניהול API | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **קונטקסטים שורשיים** | למד עוד על קונטקסט שורשי ואיך ליישם אותם | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **ניתוב** | למד סוגים שונים של ניתוב | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **דגימה** | למד איך לעבוד עם דגימה | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **סקיילינג** | למד על סקיילינג של שרתי MCP, כולל אסטרטגיות סקיילינג אופקי ואנכי, אופטימיזציה של משאבים וכיוונון ביצועים | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **אבטחה** | אבטח את שרת MCP שלך, כולל אסטרטגיות אימות, הרשאה והגנת מידע | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **חיפוש אינטרנטי MCP** | שרת ולקוח MCP בפייתון המשתלבים עם SerpAPI לחיפוש אינטרנטי בזמן אמת, חדשות, מוצרים ושאלות ותשובות. מציג תזמור כלים מרובים, אינטגרציה עם API חיצוני וטיפול שגיאות חזק | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **שידור בזמן אמת** | שידור נתונים בזמן אמת הפך חיוני בעולם הנתונים של היום, שבו עסקים ויישומים דורשים גישה מיידית למידע לקבלת החלטות בזמן אמת | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 06 | **תרומות מהקהילה** | איך לתרום קוד ותיעוד, שיתוף פעולה דרך GitHub, שיפורים והיזון חוזר מונעי קהילה | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **תובנות מאימוץ מוקדם** | יישומים מהעולם האמיתי ומה עבד, בנייה ופריסה של פתרונות מבוססי MCP, מגמות ומפת דרכים עתידית | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **שיטות עבודה מומלצות ל-MCP** | כיוונון ביצועים ואופטימיזציה, תכנון מערכות MCP חסינות לתקלות, אסטרטגיות בדיקה ועמידות | [Best Practices](./08-BestPractices/README.md) |
| 09 | **מקרי מבחן MCP** | ניתוחים מעמיקים של ארכיטקטורות פתרון MCP, תבניות פריסה וטיפים לאינטגרציה, דיאגרמות עם הערות והליכות דרך פרויקטים | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **פישוט זרימות עבודה של AI: בניית שרת MCP עם ערכת כלים AI** | סדנת עבודה מעשית מקיפה המשלבת MCP עם ערכת הכלים של מיקרוסופט ל-AI עבור VS Code. למדו לבנות יישומים חכמים המחברים בין מודלי AI לכלים מעשיים דרך מודולים פרקטיים המכסים יסודות, פיתוח שרת מותאם ואסטרטגיות פריסה בייצור. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## פרויקטים לדוגמה

### 🧮 פרויקטים לדוגמה של מחשבון MCP:
<details>
  <summary><strong>חקור מימושי קוד לפי שפה</strong></summary>

  - [דוגמת שרת MCP ב-C#](./03-GettingStarted/samples/csharp/README.md)
  - [מחשבון MCP ב-Java](./03-GettingStarted/samples/java/calculator/README.md)
  - [דמו MCP ב-JavaScript](./03-GettingStarted/samples/javascript/README.md)
  - [שרת MCP ב-Python](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [דוגמת MCP ב-TypeScript](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 פרויקטים מתקדמים של מחשבון MCP:
<details>
  <summary><strong>חקור דוגמאות מתקדמות</strong></summary>

  - [דוגמה מתקדמת ב-C#](./04-PracticalImplementation/samples/csharp/README.md)
  - [דוגמת אפליקציית מיכל ב-Java](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [דוגמה מתקדמת ב-JavaScript](./04-PracticalImplementation/samples/javascript/README.md)
  - [מימוש מורכב ב-Python](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [דוגמת מיכל ב-TypeScript](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 דרישות מוקדמות ללימוד MCP

כדי להפיק את המיטב מתכנית הלימודים הזו, מומלץ שתהיה לך:

- ידע בסיסי ב-C#, Java או Python  
- הבנה של מודל לקוח-שרת ו-APIs  
- (אופציונלי) היכרות עם מושגי למידת מכונה  

## 📚 מדריך לימוד

מדריך לימוד מקיף [Study Guide](./study_guide.md) זמין כדי לעזור לך לנווט במאגר זה ביעילות. המדריך כולל:

- מפת תוכנית לימודים ויזואלית המציגה את כל הנושאים המכוסים  
- פירוט מפורט של כל חלק במאגר  
- הנחיות לשימוש בפרויקטים לדוגמה  
- מסלולי לימוד מומלצים לרמות מיומנות שונות  
- משאבים נוספים להשלמת מסע הלמידה שלך  

## 🛠️ איך להשתמש בתכנית הלימודים הזו ביעילות

כל שיעור במדריך כולל:

1. הסברים ברורים על מושגי MCP  
2. דוגמאות קוד חיות במספר שפות  
3. תרגילים לבניית יישומי MCP אמיתיים  
4. משאבים נוספים ללומדים מתקדמים  

## 📜 מידע על רישיון

תוכן זה מורשה תחת **MIT License**. לתנאים ולכללים ראו את [LICENSE](../../LICENSE).

## 🤝 הנחיות לתרומה

פרויקט זה מקבל בברכה תרומות והצעות. רוב התרומות דורשות הסכמתך ל  
Contributor License Agreement (CLA) המצהיר שיש לך את הזכות, ואתה למעשה מעניק לנו  
את הזכויות להשתמש בתרומתך. לפרטים, בקר בכתובת <https://cla.opensource.microsoft.com>.

בעת הגשת בקשת משיכה, בוט CLA יקבע אוטומטית אם יש צורך לספק CLA ויעטר את הבקשה בהתאם (למשל, בדיקת מצב, תגובה). פשוט עקוב אחרי ההוראות שהבוט מספק. תצטרך לעשות זאת רק פעם אחת בכל המאגרי הקוד שמשתמשים ב-CLA שלנו.

פרויקט זה אימץ את [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). למידע נוסף ראה את [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) או פנה ל-[opencode@microsoft.com](mailto:opencode@microsoft.com) עם שאלות או הערות נוספות.

## 🎒 קורסים נוספים
הצוות שלנו מייצר קורסים נוספים! בדוק את:

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
- [בחר את הרפתקת Copilot שלך](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)

## ™️ הודעת סימן מסחרי

הפרויקט הזה עשוי לכלול סימני מסחר או לוגואים של פרויקטים, מוצרים או שירותים. שימוש מורשה בסימני המסחר או בלוגואים של Microsoft כפוף וצריך לעמוד ב-
[הנחיות הסימנים המסחריים והמוניטין של Microsoft](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
שימוש בסימני המסחר או בלוגואים של Microsoft בגרסאות ששונו של הפרויקט הזה אסור שיגרום לבלבול או ירמז על חסות מצד Microsoft.
כל שימוש בסימני מסחר או בלוגואים של צד שלישי כפוף למדיניות של אותם צדדים שלישיים.

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו צריך להיחשב כמקור הסמכות. למידע קריטי מומלץ להשתמש בתרגום מקצועי של אדם. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעות משימוש בתרגום זה.