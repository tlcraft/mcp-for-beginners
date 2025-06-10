<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f83bc722dc758efffd68667d6a1db470",
  "translation_date": "2025-06-10T06:42:37+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/README.md",
  "language_code": "mo"
}
-->
# 🐙 Module 4: Practical MCP Development - Custom GitHub Clone Server

![Duration](https://img.shields.io/badge/Duration-30_minutes-blue?style=flat-square)
![Difficulty](https://img.shields.io/badge/Difficulty-Intermediate-orange?style=flat-square)
![MCP](https://img.shields.io/badge/MCP-Custom%20Server-purple?style=flat-square&logo=github)
![VS Code](https://img.shields.io/badge/VS%20Code-Integration-blue?style=flat-square&logo=visualstudiocode)
![GitHub Copilot](https://img.shields.io/badge/GitHub%20Copilot-Agent%20Mode-green?style=flat-square&logo=github)

> **⚡ התחלה מהירה:** בנו שרת MCP מוכן לייצור שמבצע אוטומציה של שכפול מאגרי GitHub ואינטגרציה עם VS Code תוך 30 דקות בלבד!

## 🎯 מטרות הלמידה

בסיום המעבדה הזו תדעו:

- ✅ ליצור שרת MCP מותאם לעבודה עם תהליכי פיתוח אמיתיים
- ✅ ליישם פונקציונליות לשכפול מאגרי GitHub דרך MCP
- ✅ לשלב שרתי MCP מותאמים עם VS Code ו-Agent Builder
- ✅ להשתמש במצב Agent של GitHub Copilot עם כלי MCP מותאמים
- ✅ לבדוק ולפרוס שרתי MCP מותאמים בסביבת ייצור

## 📋 דרישות מוקדמות

- השלמת מעבדות 1-3 (יסודות MCP ופיתוח מתקדם)
- מנוי ל-GitHub Copilot ([הרשמה חינמית זמינה](https://github.com/github-copilot/signup))
- VS Code עם הרחבות AI Toolkit ו-GitHub Copilot
- התקנת Git CLI והגדרתו

## 🏗️ סקירת הפרויקט

### **אתגר פיתוח מהעולם האמיתי**
כמפתחים, אנו משתמשים לעיתים קרובות ב-GitHub כדי לשכפל מאגרים ולפתוח אותם ב-VS Code או VS Code Insiders. התהליך הידני כולל:
1. פתיחת מסוף/שורת פקודה
2. ניווט לתיקייה הרצויה
3. הרצת הפקודה `git clone`
4. פתיחת VS Code בתיקייה ששוכפלה

**פתרון ה-MCP שלנו מפשט את כל זה לפקודה חכמה אחת!**

### **מה תבנו**
שרת **GitHub Clone MCP** (`git_mcp_server`) שמציע:

| תכונה | תיאור | יתרון |
|---------|-------------|---------|
| 🔄 **שכפול מאגרים חכם** | שכפול מאגרים מ-GitHub עם אימות | בדיקת שגיאות אוטומטית |
| 📁 **ניהול תיקיות אינטיליגנטי** | בדיקה ויצירת תיקיות בצורה בטוחה | מונע כתיבה על קבצים קיימים |
| 🚀 **אינטגרציה בין-פלטפורמית עם VS Code** | פתיחת פרויקטים ב-VS Code/Insiders | מעבר חלק בין שלבים בעבודה |
| 🛡️ **טיפול שגיאות יציב** | טיפול בבעיות רשת, הרשאות ונתיבים | אמינות בסביבת ייצור |

---

## 📖 יישום שלב אחר שלב

### שלב 1: יצירת סוכן GitHub ב-Agent Builder

1. **הפעל את Agent Builder** דרך הרחבת AI Toolkit
2. **צור סוכן חדש** עם התצורה הבאה:
   ```
   Agent Name: GitHubAgent
   ```

3. **אתחל שרת MCP מותאם:**
   - עבור ל-**Tools** → **Add Tool** → **MCP Server**
   - בחר **"Create A new MCP Server"**
   - בחר בתבנית **Python** לגמישות מקסימלית
   - **שם השרת:** `git_mcp_server`

### שלב 2: הגדרת מצב Agent של GitHub Copilot

1. **פתח את GitHub Copilot** ב-VS Code (Ctrl/Cmd + Shift + P → "GitHub Copilot: Open")
2. **בחר במודל Agent** בממשק Copilot
3. **בחר במודל Claude 3.7** לשיפור יכולות ההסקה
4. **אפשר אינטגרציה עם MCP** לגישה לכלים

> **💡 טיפ מקצועי:** Claude 3.7 מספק הבנה מעמיקה יותר של תהליכי פיתוח ודפוסי טיפול בשגיאות.

### שלב 3: יישום פונקציונליות ליבת שרת MCP

**השתמשו בפרומפט המפורט הבא במצב Agent של GitHub Copilot:**

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

### שלב 4: בדיקת שרת MCP שלכם

#### 4א. בדיקה ב-Agent Builder

1. **הפעל את תצורת הדיבוג** ב-Agent Builder
2. **הגדר את הסוכן עם פרומפט מערכת זה:**

```
SYSTEM_PROMPT:
You are my intelligent coding repository assistant. You help developers efficiently clone GitHub repositories and set up their development environment. Always provide clear feedback about operations and handle errors gracefully.
```

3. **בדוק עם תרחישי משתמש ריאליסטיים:**

```
USER_PROMPT EXAMPLES:

Scenario : Basic Clone and Open
"Clone {Your GitHub Repo link such as https://github.com/kinfey/GHCAgentWorkshop
 } and save to {The global path you specify}, then open it with VS Code Insiders"
```

![Agent Builder Testing](../../../../translated_images/DebugAgent.81d152370c503241b3b39a251b8966f7f739286df19dd57f9147f6402214a012.mo.png)

**תוצאות צפויות:**
- ✅ שכפול מוצלח עם אישור נתיב
- ✅ הפעלה אוטומטית של VS Code
- ✅ הודעות שגיאה ברורות במקרים לא תקינים
- ✅ טיפול תקין במקרים מיוחדים

#### 4ב. בדיקה ב-MCP Inspector

![MCP Inspector Testing](../../../../translated_images/DebugInspector.eb5c95f94c69a8ba36944941b9a3588309a3a2fae101ace470ee09bde41d1667.mo.png)

---

**🎉 כל הכבוד!** יצרתם בהצלחה שרת MCP מעשי ומוכן לייצור שפותר את אתגרי תהליכי הפיתוח האמיתיים. שרת השכפול המותאם שלכם מדגים את כוחו של MCP באוטומציה ושיפור פרודוקטיביות המפתחים.

### 🏆 הישגים:
- ✅ **מפתח MCP** - יצירת שרת MCP מותאם
- ✅ **אוטומטור תהליכים** - ייעול תהליכי פיתוח  
- ✅ **מומחה אינטגרציה** - חיבור כלים שונים לפיתוח
- ✅ **מוכן לייצור** - בניית פתרונות לפריסה

---

## 🎓 סיום הסדנה: המסע שלך עם Model Context Protocol

**משתתף יקר,**

ברכות על השלמת כל ארבעת המודולים של סדנת Model Context Protocol! עברתם דרך ארוכה מהבנת יסודות AI Toolkit ועד לבניית שרתי MCP מוכנים לייצור הפותרים אתגרי פיתוח אמיתיים.

### 🚀 סיכום מסלול הלמידה שלך:

**[מודול 1](../lab1/README.md)**: התחלתם בחקר יסודות AI Toolkit, בדיקות מודלים ויצירת הסוכן AI הראשון שלכם.

**[מודול 2](../lab2/README.md)**: למדתם על ארכיטקטורת MCP, שילוב Playwright MCP ובניתם סוכן אוטומציה לדפדפן.

**[מודול 3](../lab3/README.md)**: התקדמתם לפיתוח שרת MCP מותאם עם שרת Weather MCP ולמדתם כלים לדיבוג.

**[מודול 4](../lab4/README.md)**: יישמתם את כל הידע ליצירת כלי אוטומציה מעשי לשכפול מאגרי GitHub.

### 🌟 מה שלטתם בו:

- ✅ **אקוסיסטם AI Toolkit**: מודלים, סוכנים ודפוסי אינטגרציה
- ✅ **ארכיטקטורת MCP**: עיצוב לקוח-שרת, פרוטוקולי תקשורת ואבטחה
- ✅ **כלי מפתח**: מ-Playground ועד Inspector ועד לפריסה בסביבת ייצור
- ✅ **פיתוח מותאם**: בנייה, בדיקה ופריסה של שרתי MCP משלכם
- ✅ **יישומים מעשיים**: פתרון אתגרי תהליכים אמיתיים עם AI

### 🔮 הצעדים הבאים שלך:

1. **בנה את שרת MCP משלך**: יישם את הכישורים לאוטומציה של תהליכים ייחודיים
2. **הצטרף לקהילת MCP**: שתף את יצירותיך ולמד מאחרים
3. **חקור אינטגרציה מתקדמת**: חבר שרתי MCP למערכות ארגוניות
4. **תרום לקוד פתוח**: סייע בשיפור כלי MCP ותיעוד

זכור, הסדנה הזו היא רק ההתחלה. אקוסיסטם Model Context Protocol מתפתח במהירות, ועכשיו יש לך את הכלים להיות בחזית הפיתוח המונע בינה מלאכותית.

**תודה על ההשתתפות והמסירות ללמידה!**

אנו מקווים שהסדנה הזו עוררה בך רעיונות שישנו את הדרך בה אתה בונה ומתקשר עם כלי AI במסע הפיתוח שלך.

**קידוד מהנה!**

---

**Disclaimer**:  
This document has been translated using AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.

---

If you meant "mo" as a specific language or code, could you please clarify which language "mo" refers to? This will help me provide an accurate translation.