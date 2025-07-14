<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T09:00:19+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "he"
}
-->
# שרת Weather MCP

זהו דוגמה לשרת MCP בפייתון שמממש כלים למזג אוויר עם תגובות מדומות. ניתן להשתמש בו כבסיס לשרת MCP משלך. הוא כולל את התכונות הבאות:

- **כלי מזג אוויר**: כלי שמספק מידע מזג אוויר מדומה בהתבסס על מיקום נתון.
- **כלי Git Clone**: כלי שמעתיק מאגר git לתיקייה מסוימת.
- **כלי פתיחה ב-VS Code**: כלי שפותח תיקייה ב-VS Code או VS Code Insiders.
- **חיבור ל-Agent Builder**: תכונה שמאפשרת לחבר את שרת ה-MCP ל-Agent Builder לצורך בדיקות וניפוי שגיאות.
- **ניפוי שגיאות ב-[MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: תכונה שמאפשרת לנפות שגיאות בשרת ה-MCP באמצעות MCP Inspector.

## התחלה עם תבנית שרת Weather MCP

> **דרישות מוקדמות**
>
> כדי להריץ את שרת ה-MCP במכונת הפיתוח המקומית שלך, תזדקק ל:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (נדרש לכלי git_clone_repo)
> - [VS Code](https://code.visualstudio.com/) או [VS Code Insiders](https://code.visualstudio.com/insiders/) (נדרש לכלי open_in_vscode)
> - (*אופציונלי - אם אתה מעדיף uv*) [uv](https://github.com/astral-sh/uv)
> - [תוסף ניפוי שגיאות לפייתון](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## הכנת הסביבה

ישנן שתי דרכים להגדיר את הסביבה לפרויקט זה. ניתן לבחור באחת מהן לפי ההעדפה שלך.

> הערה: טען מחדש את VSCode או את הטרמינל כדי לוודא שהפייתון של הסביבה הווירטואלית בשימוש לאחר יצירת הסביבה הווירטואלית.

| שיטה | שלבים |
| -------- | ----- |
| שימוש ב-`uv` | 1. צור סביבה וירטואלית: `uv venv` <br>2. הרץ את הפקודה ב-VSCode "***Python: Select Interpreter***" ובחר את הפייתון מהסביבה הווירטואלית שנוצרה <br>3. התקן את התלויות (כולל תלויות פיתוח): `uv pip install -r pyproject.toml --extra dev` |
| שימוש ב-`pip` | 1. צור סביבה וירטואלית: `python -m venv .venv` <br>2. הרץ את הפקודה ב-VSCode "***Python: Select Interpreter***" ובחר את הפייתון מהסביבה הווירטואלית שנוצרה<br>3. התקן את התלויות (כולל תלויות פיתוח): `pip install -e .[dev]` |

לאחר הגדרת הסביבה, ניתן להריץ את השרת במכונת הפיתוח המקומית דרך Agent Builder כלקוח MCP כדי להתחיל:
1. פתח את לוח הבקרה לניפוי שגיאות ב-VS Code. בחר `Debug in Agent Builder` או לחץ על `F5` כדי להתחיל לנפות שגיאות בשרת ה-MCP.
2. השתמש ב-Agent Builder של AI Toolkit כדי לבדוק את השרת עם [הפרומפט הזה](../../../../../../../../../../open_prompt_builder). השרת יתחבר אוטומטית ל-Agent Builder.
3. לחץ על `Run` כדי לבדוק את השרת עם הפרומפט.

**מזל טוב**! הצלחת להפעיל את שרת Weather MCP במכונת הפיתוח המקומית שלך דרך Agent Builder כלקוח MCP.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## מה כלול בתבנית

| תיקייה / קובץ | תוכן                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | קבצי VSCode לניפוי שגיאות                   |
| `.aitk`      | הגדרות ל-AI Toolkit                |
| `src`        | קוד המקור של שרת ה-weather mcp   |

## איך לנפות שגיאות בשרת Weather MCP

> הערות:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) הוא כלי ויזואלי למפתחים לבדיקות וניפוי שגיאות של שרתי MCP.
> - כל מצבי הניפוי תומכים בנקודות עצירה, כך שניתן להוסיף נקודות עצירה בקוד מימוש הכלים.

## כלים זמינים

### כלי מזג אוויר
הכלי `get_weather` מספק מידע מזג אוויר מדומה למיקום מסוים.

| פרמטר | סוג | תיאור |
| --------- | ---- | ----------- |
| `location` | מחרוזת | מיקום לקבלת מידע מזג אוויר (למשל שם עיר, מדינה או קואורדינטות) |

### כלי Git Clone
הכלי `git_clone_repo` מעתיק מאגר git לתיקייה מסוימת.

| פרמטר | סוג | תיאור |
| --------- | ---- | ----------- |
| `repo_url` | מחרוזת | כתובת ה-URL של מאגר ה-git להעתקה |
| `target_folder` | מחרוזת | הנתיב לתיקייה שאליה יש להעתיק את המאגר |

הכלי מחזיר אובייקט JSON עם:
- `success`: בוליאני שמציין אם הפעולה הצליחה
- `target_folder` או `error`: הנתיב של המאגר שהועתק או הודעת שגיאה

### כלי פתיחה ב-VS Code
הכלי `open_in_vscode` פותח תיקייה ביישום VS Code או VS Code Insiders.

| פרמטר | סוג | תיאור |
| --------- | ---- | ----------- |
| `folder_path` | מחרוזת | הנתיב לתיקייה שברצונך לפתוח |
| `use_insiders` | בוליאני (אופציונלי) | האם להשתמש ב-VS Code Insiders במקום ב-VS Code הרגיל |

הכלי מחזיר אובייקט JSON עם:
- `success`: בוליאני שמציין אם הפעולה הצליחה
- `message` או `error`: הודעת אישור או הודעת שגיאה

## מצב ניפוי שגיאות | תיאור | שלבים לניפוי שגיאות |
| ---------- | ----------- | --------------- |
| Agent Builder | ניפוי שגיאות של שרת ה-MCP ב-Agent Builder דרך AI Toolkit. | 1. פתח את לוח הבקרה לניפוי שגיאות ב-VS Code. בחר `Debug in Agent Builder` ולחץ `F5` כדי להתחיל לנפות שגיאות בשרת ה-MCP.<br>2. השתמש ב-Agent Builder של AI Toolkit כדי לבדוק את השרת עם [הפרומפט הזה](../../../../../../../../../../open_prompt_builder). השרת יתחבר אוטומטית ל-Agent Builder.<br>3. לחץ על `Run` כדי לבדוק את השרת עם הפרומפט. |
| MCP Inspector | ניפוי שגיאות של שרת ה-MCP באמצעות MCP Inspector. | 1. התקן [Node.js](https://nodejs.org/)<br> 2. הגדר את Inspector: `cd inspector` && `npm install` <br> 3. פתח את לוח הבקרה לניפוי שגיאות ב-VS Code. בחר `Debug SSE in Inspector (Edge)` או `Debug SSE in Inspector (Chrome)`. לחץ F5 כדי להתחיל לנפות שגיאות.<br> 4. כאשר MCP Inspector ייפתח בדפדפן, לחץ על כפתור `Connect` כדי לחבר את שרת ה-MCP הזה.<br> 5. לאחר מכן תוכל `List Tools`, לבחור כלי, להזין פרמטרים, ולבצע `Run Tool` כדי לנפות שגיאות בקוד השרת.<br> |

## פורטים ברירת מחדל והתאמות אישיות

| מצב ניפוי שגיאות | פורטים | הגדרות | התאמות אישיות | הערה |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | ערוך את [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) כדי לשנות את הפורטים הנ"ל. | ללא |
| MCP Inspector | 3001 (שרת); 5173 ו-3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | ערוך את [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) כדי לשנות את הפורטים הנ"ל.| ללא |

## משוב

אם יש לך משוב או הצעות לתבנית זו, אנא פתח נושא ב-[מאגר GitHub של AI Toolkit](https://github.com/microsoft/vscode-ai-toolkit/issues)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו צריך להיחשב כמקור הסמכות. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.