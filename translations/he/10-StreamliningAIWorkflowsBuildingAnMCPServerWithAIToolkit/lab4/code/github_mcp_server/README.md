<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:14:18+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "he"
}
-->
# שרת Weather MCP

זהו שרת MCP לדוגמה ב-Python שמממש כלי מזג אוויר עם תגובות מדומות. ניתן להשתמש בו כמסגרת לשרת MCP משלך. הוא כולל את התכונות הבאות:

- **כלי מזג אוויר**: כלי שמספק מידע מזג אוויר מדומה בהתבסס על מיקום נתון.
- **כלי Git Clone**: כלי שמעתיק מאגר git לתיקייה מסוימת.
- **כלי פתיחת VS Code**: כלי שפותח תיקייה ב-VS Code או VS Code Insiders.
- **חיבור ל-Agent Builder**: תכונה שמאפשרת לחבר את שרת ה-MCP ל-Agent Builder לצורך בדיקות וניפוי שגיאות.
- **ניפוי שגיאות ב-[MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: תכונה שמאפשרת לנפות שגיאות בשרת MCP באמצעות MCP Inspector.

## התחלה עם תבנית Weather MCP Server

> **דרישות מוקדמות**
>
> כדי להפעיל את שרת ה-MCP במכונת הפיתוח המקומית שלך, תזדקק ל:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (נדרש עבור כלי git_clone_repo)
> - [VS Code](https://code.visualstudio.com/) או [VS Code Insiders](https://code.visualstudio.com/insiders/) (נדרש עבור כלי open_in_vscode)
> - (*אופציונלי - אם אתה מעדיף uv*) [uv](https://github.com/astral-sh/uv)
> - [הרחבת ניפוי שגיאות Python](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## הכנת הסביבה

יש שתי דרכים להגדיר את הסביבה לפרויקט הזה. ניתן לבחור באחת מהן לפי העדפתך.

> הערה: טען מחדש את VSCode או הטרמינל כדי לוודא שהפייתון של הסביבה הווירטואלית בשימוש לאחר יצירת הסביבה הווירטואלית.

| שיטה | שלבים |
| -------- | ----- |
| שימוש ב-`uv` | 1. צור סביבה וירטואלית: `uv venv` <br>2. הפעל פקודת VSCode "***Python: Select Interpreter***" ובחר את הפייתון מהסביבה הווירטואלית שנוצרה <br>3. התקן את התלויות (כולל תלויות פיתוח): `uv pip install -r pyproject.toml --extra dev` |
| שימוש ב-`pip` | 1. צור סביבה וירטואלית: `python -m venv .venv` <br>2. הפעל פקודת VSCode "***Python: Select Interpreter***" ובחר את הפייתון מהסביבה הווירטואלית שנוצרה<br>3. התקן את התלויות (כולל תלויות פיתוח): `pip install -e .[dev]` |

לאחר הגדרת הסביבה, ניתן להפעיל את השרת במכונת הפיתוח המקומית דרך Agent Builder כלקוח MCP כדי להתחיל:
1. פתח את לוח ניפוי השגיאות ב-VS Code. בחר `Debug in Agent Builder` או לחץ על `F5` כדי להתחיל לנפות שגיאות בשרת MCP.
2. השתמש ב-AI Toolkit Agent Builder כדי לבדוק את השרת עם [הפרומפט הזה](../../../../../../../../../../../open_prompt_builder). השרת יתחבר אוטומטית ל-Agent Builder.
3. לחץ על `Run` כדי לבדוק את השרת עם הפרומפט.

**מזל טוב**! הפעלת בהצלחה את שרת Weather MCP במכונת הפיתוח המקומית שלך דרך Agent Builder כלקוח MCP.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## מה כלול בתבנית

| תיקייה / קובץ | תוכן |
| ------------ | -------------------------------------------- |
| `.vscode` | קבצי VSCode לניפוי שגיאות |
| `.aitk` | הגדרות ל-AI Toolkit |
| `src` | קוד המקור של שרת weather mcp |

## כיצד לנפות שגיאות בשרת Weather MCP

> הערות:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) הוא כלי ויזואלי למפתחים לבדיקות וניפוי שגיאות בשרתי MCP.
> - כל מצבי הניפוי תומכים בנקודות עצירה, כך שניתן להוסיף נקודות עצירה בקוד מימוש הכלי.

## כלים זמינים

### כלי מזג אוויר
הכלי `get_weather` מספק מידע מזג אוויר מדומה עבור מיקום מסוים.

| פרמטר | סוג | תיאור |
| --------- | ---- | ----------- |
| `location` | מחרוזת | מיקום לקבלת מידע מזג אוויר (למשל, שם עיר, מדינה, או קואורדינטות) |

### כלי Git Clone
הכלי `git_clone_repo` מעתיק מאגר git לתיקייה מסוימת.

| פרמטר | סוג | תיאור |
| --------- | ---- | ----------- |
| `repo_url` | מחרוזת | כתובת ה-URL של מאגר ה-git להעתקה |
| `target_folder` | מחרוזת | הנתיב לתיקייה שאליה יש להעתיק את המאגר |

הכלי מחזיר אובייקט JSON עם:
- `success`: בוליאני שמציין אם הפעולה הצליחה
- `target_folder` או `error`: הנתיב של המאגר שהועתק או הודעת שגיאה

### כלי פתיחת VS Code
הכלי `open_in_vscode` פותח תיקייה ב-VS Code או ביישום VS Code Insiders.

| פרמטר | סוג | תיאור |
| --------- | ---- | ----------- |
| `folder_path` | מחרוזת | הנתיב לתיקייה שברצונך לפתוח |
| `use_insiders` | בוליאני (אופציונלי) | האם להשתמש ב-VS Code Insiders במקום ב-VS Code הרגיל |

הכלי מחזיר אובייקט JSON עם:
- `success`: בוליאני שמציין אם הפעולה הצליחה
- `message` או `error`: הודעת אישור או הודעת שגיאה

## מצב ניפוי שגיאות | תיאור | שלבים לניפוי שגיאות |
| ---------- | ----------- | --------------- |
| Agent Builder | ניפוי שגיאות של שרת MCP דרך Agent Builder באמצעות AI Toolkit. | 1. פתח את לוח ניפוי השגיאות ב-VS Code. בחר `Debug in Agent Builder` ולחץ על `F5` כדי להתחיל לנפות שגיאות בשרת MCP.<br>2. השתמש ב-AI Toolkit Agent Builder כדי לבדוק את השרת עם [הפרומפט הזה](../../../../../../../../../../../open_prompt_builder). השרת יתחבר אוטומטית ל-Agent Builder.<br>3. לחץ על `Run` כדי לבדוק את השרת עם הפרומפט. |
| MCP Inspector | ניפוי שגיאות של שרת MCP באמצעות MCP Inspector. | 1. התקן את [Node.js](https://nodejs.org/)<br> 2. הגדר את Inspector: `cd inspector` && `npm install` <br> 3. פתח את לוח ניפוי השגיאות ב-VS Code. בחר `Debug SSE in Inspector (Edge)` או `Debug SSE in Inspector (Chrome)`. לחץ F5 כדי להתחיל לנפות שגיאות.<br> 4. כאשר MCP Inspector נפתח בדפדפן, לחץ על הכפתור `Connect` כדי לחבר את שרת MCP הזה.<br> 5. לאחר מכן תוכל `List Tools`, לבחור כלי, להזין פרמטרים, ו-`Run Tool` כדי לנפות שגיאות בקוד השרת שלך.<br> |

## פורטים ברירת מחדל והתאמות אישיות

| מצב ניפוי שגיאות | פורטים | הגדרות | התאמות אישיות | הערה |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | ערוך את [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) כדי לשנות את הפורטים הנ"ל. | ללא |
| MCP Inspector | 3001 (שרת); 5173 ו-3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | ערוך את [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) כדי לשנות את הפורטים הנ"ל.| ללא |

## משוב

אם יש לך משוב או הצעות לתבנית זו, אנא פתח נושא ב-[מאגר GitHub של AI Toolkit](https://github.com/microsoft/vscode-ai-toolkit/issues)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. יש להתייחס למסמך המקורי בשפתו המקורית כמקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי הבנה או פרשנות שגויה הנובעת מהשימוש בתרגום זה.