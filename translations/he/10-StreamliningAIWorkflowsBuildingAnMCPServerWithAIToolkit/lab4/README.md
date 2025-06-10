<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f83bc722dc758efffd68667d6a1db470",
  "translation_date": "2025-06-10T06:53:08+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/README.md",
  "language_code": "he"
}
-->
# 🐙 מודול 4: פיתוח מעשי של MCP - שרת מותאם אישית לשכפול GitHub

![Duration](https://img.shields.io/badge/Duration-30_minutes-blue?style=flat-square)
![Difficulty](https://img.shields.io/badge/Difficulty-Intermediate-orange?style=flat-square)
![MCP](https://img.shields.io/badge/MCP-Custom%20Server-purple?style=flat-square&logo=github)
![VS Code](https://img.shields.io/badge/VS%20Code-Integration-blue?style=flat-square&logo=visualstudiocode)
![GitHub Copilot](https://img.shields.io/badge/GitHub%20Copilot-Agent%20Mode-green?style=flat-square&logo=github)

> **⚡ התחלה מהירה:** בנו שרת MCP מוכן לייצור שמבצע אוטומציה לשכפול מאגרי GitHub ואינטגרציה עם VS Code תוך 30 דקות בלבד!

## 🎯 מטרות הלמידה

בסיום המעבדה הזו, תדעו:

- ✅ ליצור שרת MCP מותאם אישית עבור תהליכי פיתוח אמיתיים
- ✅ לממש פונקציונליות לשכפול מאגרי GitHub דרך MCP
- ✅ לשלב שרתי MCP מותאמים עם VS Code ו-Agent Builder
- ✅ להשתמש במצב Agent של GitHub Copilot עם כלי MCP מותאמים
- ✅ לבדוק ולפרוס שרתי MCP מותאמים בסביבות ייצור

## 📋 דרישות מוקדמות

- השלמת המעבדות 1-3 (יסודות MCP ופיתוח מתקדם)
- מנוי ל-GitHub Copilot ([הרשמה חינמית זמינה](https://github.com/github-copilot/signup))
- VS Code עם הרחבות AI Toolkit ו-GitHub Copilot
- התקנה וקונפיגורציה של Git CLI

## 🏗️ סקירת הפרויקט

### **אתגר פיתוח אמיתי**
כמפתחים, אנו משתמשים לעיתים קרובות ב-GitHub כדי לשכפל מאגרים ולפתוח אותם ב-VS Code או ב-VS Code Insiders. התהליך הידני כולל:
1. פתיחת טרמינל/שורת פקודה
2. ניווט לתיקייה הרצויה
3. הרצת הפקודה `git clone`
4. פתיחת VS Code בתיקייה המשוכפלת

**הפתרון שלנו ב-MCP מפשט את כל זה לפקודה חכמה אחת!**

### **מה תבנו**
שרת **GitHub Clone MCP** (`git_mcp_server`) שמציע:

| תכונה | תיאור | יתרון |
|---------|-------------|---------|
| 🔄 **שכפול מאגרים חכם** | שכפול מאגרים עם אימות | בדיקת שגיאות אוטומטית |
| 📁 **ניהול תיקיות אינטיליגנטי** | בדיקה ויצירת תיקיות בצורה בטוחה | מונע דריסת קבצים |
| 🚀 **אינטגרציה חוצת פלטפורמות עם VS Code** | פתיחת פרויקטים ב-VS Code/Insiders | מעבר חלק בין שלבי העבודה |
| 🛡️ **טיפול שגיאות חזק** | טיפול בבעיות רשת, הרשאות ונתיבים | אמינות מוכנה לייצור |

---

## 📖 מימוש שלב אחר שלב

### שלב 1: יצירת סוכן GitHub ב-Agent Builder

1. **הפעל את Agent Builder** דרך הרחבת AI Toolkit
2. **צור סוכן חדש** עם התצורה הבאה:
   ```
   Agent Name: GitHubAgent
   ```

3. **אתחל שרת MCP מותאם אישית:**
   - עבור ל-**כלים** → **הוסף כלי** → **שרת MCP**
   - בחר **"Create A new MCP Server"**
   - בחר בתבנית **Python** לגמישות מקסימלית
   - **שם השרת:** `git_mcp_server`

### שלב 2: קונפיגורציה של מצב Agent ב-GitHub Copilot

1. **פתח את GitHub Copilot** ב-VS Code (Ctrl/Cmd + Shift + P → "GitHub Copilot: Open")
2. **בחר דגם Agent** בממשק Copilot
3. **בחר בדגם Claude 3.7** לשיפור יכולות ההבנה
4. **אפשר אינטגרציה עם MCP** לגישה לכלים

> **💡 טיפ מקצועי:** Claude 3.7 מספק הבנה מעמיקה יותר של תהליכי פיתוח ודפוסי טיפול בשגיאות.

### שלב 3: מימוש פונקציונליות ליבת שרת MCP

**השתמש בפרומפט המפורט הבא עם מצב Agent של GitHub Copilot:**

```
Create two MCP tools with the following comprehensive requirements:

🔧 TOOL A: clone_repository
Requirements:
- Clone any GitHub repository to a specified local folder
- Return the absolute path of the successfully cloned project
- Implement comprehensive validation:
  ✓ Check if target directory already exists (return error if exists)
  ✓ Validate GitHub URL format (https://github.com/user/repo)
  ✓ Verify git command availability (prompt installation if missing)
  ✓ Handle network connectivity issues
  ✓ Provide clear error messages for all failure scenarios

🚀 TOOL B: open_in_vscode
Requirements:
- Open specified folder in VS Code or VS Code Insiders
- Cross-platform compatibility (Windows/Linux/macOS)
- Use direct application launch (not terminal commands)
- Auto-detect available VS Code installations
- Handle cases where VS Code is not installed
- Provide user-friendly error messages

Additional Requirements:
- Follow MCP 1.9.3 best practices
- Include proper type hints and documentation
- Implement logging for debugging purposes
- Add input validation for all parameters
- Include comprehensive error handling
```

### שלב 4: בדיקת שרת MCP שלך

#### 4א. בדיקה ב-Agent Builder

1. **הפעל את תצורת הדיבאג** ב-Agent Builder
2. **קונפיגורציה של הסוכן עם פרומפט מערכת זה:**

```
SYSTEM_PROMPT:
You are my intelligent coding repository assistant. You help developers efficiently clone GitHub repositories and set up their development environment. Always provide clear feedback about operations and handle errors gracefully.
```

3. **בדוק עם תרחישי משתמש מציאותיים:**

```
USER_PROMPT EXAMPLES:

Scenario : Basic Clone and Open
"Clone {Your GitHub Repo link such as https://github.com/kinfey/GHCAgentWorkshop
 } and save to {The global path you specify}, then open it with VS Code Insiders"
```

![Agent Builder Testing](../../../../translated_images/DebugAgent.81d152370c503241b3b39a251b8966f7f739286df19dd57f9147f6402214a012.he.png)

**תוצאות צפויות:**
- ✅ שכפול מוצלח עם אישור נתיב
- ✅ פתיחה אוטומטית של VS Code
- ✅ הודעות שגיאה ברורות במצבים לא תקינים
- ✅ טיפול נכון במקרי קצה

#### 4ב. בדיקה ב-MCP Inspector

![MCP Inspector Testing](../../../../translated_images/DebugInspector.eb5c95f94c69a8ba36944941b9a3588309a3a2fae101ace470ee09bde41d1667.he.png)

---

**🎉 מזל טוב!** יצרת בהצלחה שרת MCP מעשי ומוכן לייצור הפותר את אתגרי תהליכי הפיתוח האמיתיים. שרת השכפול המותאם שלך מראה את הכוח של MCP לאוטומציה והעצמת פרודוקטיביות המפתחים.

### 🏆 הישגים שהושגו:
- ✅ **מפתח MCP** - יצירת שרת MCP מותאם אישית
- ✅ **אוטומציה של תהליכים** - ייעול תהליכי פיתוח  
- ✅ **מומחה אינטגרציה** - חיבור כלים רבים לפיתוח
- ✅ **מוכן לייצור** - בניית פתרונות לפריסה

---

## 🎓 סיום הסדנה: המסע שלך עם Model Context Protocol

**משתתף יקר,**

מזל טוב על השלמת כל ארבעת המודולים בסדנת Model Context Protocol! עברת דרך ארוכה מהבנת יסודות AI Toolkit ועד לבניית שרתי MCP מוכנים לייצור הפותרים את אתגרי הפיתוח האמיתיים.

### 🚀 סיכום מסלול הלמידה שלך:

**[מודול 1](../lab1/README.md)**: התחלת עם יסודות AI Toolkit, בדיקות מודלים ויצירת סוכן AI ראשון.

**[מודול 2](../lab2/README.md)**: למדת את ארכיטקטורת MCP, אינטגרציה עם Playwright MCP ובנית סוכן אוטומציה לדפדפן.

**[מודול 3](../lab3/README.md)**: התקדמת לפיתוח שרת MCP מותאם אישית עם שרת Weather MCP ולימדת כלים לניפוי שגיאות.

**[מודול 4](../lab4/README.md)**: כעת יישמת הכל ליצירת כלי אוטומציה מעשי לתהליכי עבודה עם מאגרי GitHub.

### 🌟 מה שלטת בו:

- ✅ **מערכת AI Toolkit**: מודלים, סוכנים ודפוסי אינטגרציה
- ✅ **ארכיטקטורת MCP**: עיצוב לקוח-שרת, פרוטוקולי תקשורת ואבטחה
- ✅ **כלי פיתוח**: מ-Playground ל-Inspector ועד לפריסה
- ✅ **פיתוח מותאם**: בנייה, בדיקה ופריסה של שרתי MCP
- ✅ **יישומים מעשיים**: פתרון אתגרים אמיתיים בתהליכי עבודה עם AI

### 🔮 הצעדים הבאים שלך:

1. **בנה את שרת MCP משלך**: הפעל את היכולות לאוטומציה של תהליכים ייחודיים
2. **הצטרף לקהילת MCP**: שתף את יצירותיך ולמד מאחרים
3. **חקור אינטגרציה מתקדמת**: חבר שרתי MCP למערכות ארגוניות
4. **תרום לקוד פתוח**: סייע בשיפור כלי MCP והתיעוד

זכור, הסדנה הזו היא רק ההתחלה. מערכת Model Context Protocol מתפתחת במהירות, ואתה מצויד להיות בחזית כלי הפיתוח המונעים ב-AI.

**תודה על ההשתתפות והמסירות ללמידה!**

אנו מקווים שהסדנה עוררה בך רעיונות שישנו את אופן בניית האינטראקציה שלך עם כלי AI במסע הפיתוח שלך.

**קידוד מהנה!**

---

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. יש להתייחס למסמך המקורי בשפת המקור כמקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות על אי-הבנות או פרשנויות שגויות הנובעות משימוש בתרגום זה.