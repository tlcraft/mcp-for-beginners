<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:33:26+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "he"
}
-->
# שרת MCP למזג אוויר

זהו דוגמה לשרת MCP בפייתון שמממש כלים למזג אוויר עם תגובות מדומות. ניתן להשתמש בו כבסיס לשרת MCP משלך. הוא כולל את התכונות הבאות:

- **כלי מזג אוויר**: כלי שמספק מידע מזג אוויר מדומה על בסיס מיקום נתון.
- **חיבור ל-Agent Builder**: תכונה שמאפשרת חיבור של שרת ה-MCP ל-Agent Builder לצורך בדיקה ופתרון בעיות.
- **דיבוג ב-[MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: תכונה שמאפשרת דיבוג של שרת ה-MCP באמצעות MCP Inspector.

## התחלה עם תבנית שרת MCP למזג אוויר

> **דרישות מוקדמות**
>
> כדי להריץ את שרת ה-MCP במכונת הפיתוח המקומית שלך, תזדקק ל:
>
> - [Python](https://www.python.org/)
> - (*אופציונלי - אם אתה מעדיף uv*) [uv](https://github.com/astral-sh/uv)
> - [הרחבת דיבוג לפייתון](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## הכנת הסביבה

יש שתי דרכים להגדיר את הסביבה לפרויקט זה. ניתן לבחור באחת מהן בהתאם להעדפה שלך.

> הערה: טען מחדש את VSCode או את הטרמינל כדי לוודא שמשתמשים בפייתון של הסביבה הווירטואלית לאחר יצירתה.

| גישה | שלבים |
| -------- | ----- |
| שימוש ב-`uv` | 1. צור סביבה וירטואלית: `uv venv` <br>2. הפעל את הפקודה ב-VSCode "***Python: Select Interpreter***" ובחר את הפייתון מהסביבה הווירטואלית שנוצרה <br>3. התקן את התלויות (כולל תלויות פיתוח): `uv pip install -r pyproject.toml --extra dev` |
| שימוש ב-`pip` | 1. צור סביבה וירטואלית: `python -m venv .venv` <br>2. הפעל את הפקודה ב-VSCode "***Python: Select Interpreter***" ובחר את הפייתון מהסביבה הווירטואלית שנוצרה<br>3. התקן את התלויות (כולל תלויות פיתוח): `pip install -e .[dev]` |

לאחר הגדרת הסביבה, ניתן להריץ את השרת במכונת הפיתוח המקומית שלך דרך Agent Builder כלקוח MCP כדי להתחיל:
1. פתח את לוח הדיבוג ב-VS Code. בחר `Debug in Agent Builder` או לחץ על `F5` כדי להתחיל בדיבוג של שרת ה-MCP.
2. השתמש ב-AI Toolkit Agent Builder כדי לבדוק את השרת עם [הפרומפט הזה](../../../../../../../../../../../open_prompt_builder). השרת יתחבר אוטומטית ל-Agent Builder.
3. לחץ על `Run` כדי לבדוק את השרת עם הפרומפט.

**כל הכבוד**! הצלחת להפעיל את שרת MCP למזג אוויר במכונת הפיתוח המקומית שלך דרך Agent Builder כלקוח MCP.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## מה כלול בתבנית

| תיקייה / קובץ| תוכן                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | קבצי VSCode לדיבוג                   |
| `.aitk`      | הגדרות עבור AI Toolkit                |
| `src`        | קוד המקור של שרת ה-weather mcp   |

## איך לדבג את שרת MCP למזג אוויר

> הערות:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) הוא כלי ויזואלי למפתחים לבדיקות ודיבוג שרתי MCP.
> - כל מצבי הדיבוג תומכים בנקודות עצירה, כך שניתן להוסיף נקודות עצירה בקוד מימוש הכלי.

| מצב דיבוג | תיאור | שלבים לדיבוג |
| ---------- | ----------- | --------------- |
| Agent Builder | דיבוג שרת ה-MCP ב-Agent Builder דרך AI Toolkit. | 1. פתח את לוח הדיבוג ב-VS Code. בחר `Debug in Agent Builder` ולחץ על `F5` כדי להתחיל בדיבוג של שרת ה-MCP.<br>2. השתמש ב-AI Toolkit Agent Builder כדי לבדוק את השרת עם [הפרומפט הזה](../../../../../../../../../../../open_prompt_builder). השרת יתחבר אוטומטית ל-Agent Builder.<br>3. לחץ על `Run` כדי לבדוק את השרת עם הפרומפט. |
| MCP Inspector | דיבוג שרת ה-MCP באמצעות MCP Inspector. | 1. התקן את [Node.js](https://nodejs.org/)<br> 2. הגדר את Inspector: `cd inspector` && `npm install` <br> 3. פתח את לוח הדיבוג ב-VS Code. בחר `Debug SSE in Inspector (Edge)` או `Debug SSE in Inspector (Chrome)`. לחץ F5 כדי להתחיל בדיבוג.<br> 4. כאשר MCP Inspector נפתח בדפדפן, לחץ על כפתור `Connect` כדי להתחבר לשרת MCP הזה.<br> 5. אז תוכל `List Tools`, לבחור כלי, להזין פרמטרים, ו-`Run Tool` כדי לדבג את קוד השרת שלך.<br> |

## פורטים ברירת מחדל והתאמות אישיות

| מצב דיבוג | פורטים | הגדרות | התאמות אישיות | הערה |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | ערוך את [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) כדי לשנות את הפורטים הנ"ל. | לא רלוונטי |
| MCP Inspector | 3001 (שרת); 5173 ו-3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | ערוך את [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) כדי לשנות את הפורטים הנ"ל.| לא רלוונטי |

## משוב

אם יש לך משוב או הצעות לתבנית זו, אנא פתח נושא ב-[מאגר AI Toolkit ב-GitHub](https://github.com/microsoft/vscode-ai-toolkit/issues)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון שתרגומים אוטומטיים עלולים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפת המקור שלו צריך להיחשב כמקור הסמכות. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי אדם. אנו לא אחראים לכל אי הבנות או פרשנויות שגויות הנובעות משימוש בתרגום זה.