<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:10:04+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "he"
}
-->
## בדיקה וניפוי שגיאות

לפני שתתחילו לבדוק את שרת ה-MCP שלכם, חשוב להבין את הכלים הזמינים ואת השיטות הטובות לניפוי שגיאות. בדיקה יעילה מבטיחה שהשרת שלכם מתנהג כפי שציפיתם ועוזרת לכם לזהות ולפתור בעיות במהירות. הסעיף הבא מפרט גישות מומלצות לאימות יישום ה-MCP שלכם.

## סקירה כללית

השיעור הזה עוסק כיצד לבחור את גישת הבדיקה הנכונה ואת כלי הבדיקה היעיל ביותר.

## מטרות הלמידה

בסוף השיעור תוכלו:

- לתאר גישות שונות לבדיקות.
- להשתמש בכלים שונים כדי לבדוק את הקוד שלכם בצורה יעילה.

## בדיקת שרתי MCP

MCP מספק כלים שיעזרו לכם לבדוק ולנפות שגיאות בשרתים שלכם:

- **MCP Inspector**: כלי שורת פקודה שניתן להריץ גם ככלי CLI וגם ככלי חזותי.
- **בדיקה ידנית**: ניתן להשתמש בכלי כמו curl להרצת בקשות רשת, אבל כל כלי שיכול להריץ HTTP יעבוד.
- **בדיקות יחידה**: ניתן להשתמש במסגרת הבדיקה המועדפת עליכם כדי לבדוק את הפיצ'רים של השרת והלקוח.

### שימוש ב-MCP Inspector

תיארנו את השימוש בכלי זה בשיעורים קודמים, אבל נדבר עליו בקצרה ברמה גבוהה. זהו כלי שנבנה ב-Node.js ואתם יכולים להשתמש בו על ידי קריאה לקובץ ההרצה `npx` שירד ויתקין את הכלי באופן זמני וינקה את עצמו לאחר סיום הרצת הבקשה שלכם.

ה-[MCP Inspector](https://github.com/modelcontextprotocol/inspector) עוזר לכם:

- **לגלות יכולות שרת**: לזהות אוטומטית משאבים, כלים והנחיות זמינות
- **לבדוק הרצת כלים**: לנסות פרמטרים שונים ולראות תגובות בזמן אמת
- **לצפות במטא-דאטה של השרת**: לבדוק מידע על השרת, סכימות והגדרות

הרצת הכלי טיפוסית נראית כך:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

הפקודה הנ"ל מפעילה MCP וממשק חזותי שלו ומשיקה ממשק רשת מקומי בדפדפן שלכם. תוכלו לראות לוח בקרה המציג את שרתי ה-MCP הרשומים שלכם, הכלים, המשאבים וההנחיות הזמינים להם. הממשק מאפשר לבדוק אינטראקטיבית את הרצת הכלים, לבדוק את המטא-דאטה של השרת ולראות תגובות בזמן אמת, מה שמקל על אימות וניפוי שגיאות ביישומי ה-MCP שלכם.

כך זה עשוי להיראות: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.he.png)

ניתן גם להפעיל את הכלי במצב CLI על ידי הוספת הפרמטר `--cli`. הנה דוגמה להרצת הכלי במצב "CLI" שמציגה את כל הכלים על השרת:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### בדיקה ידנית

מלבד הרצת כלי ה-inspector לבדוק את יכולות השרת, גישה דומה נוספת היא להפעיל לקוח שיכול להשתמש ב-HTTP כמו למשל curl.

עם curl, ניתן לבדוק שרתי MCP ישירות באמצעות בקשות HTTP:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

כפי שניתן לראות מהשימוש ב-curl למעלה, אתם משתמשים בבקשת POST כדי להפעיל כלי עם מטען הכולל את שם הכלי והפרמטרים שלו. השתמשו בגישה שהכי מתאימה לכם. כלים בשורת הפקודה בדרך כלל מהירים יותר לשימוש וניתנים לאוטומציה, מה שיכול להיות שימושי בסביבת CI/CD.

### בדיקות יחידה

צרו בדיקות יחידה לכלים ולמשאבים שלכם כדי לוודא שהם פועלים כמצופה. הנה דוגמת קוד בדיקה.

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

הקוד לעיל עושה את הדברים הבאים:

- מנצל את מסגרת pytest שמאפשרת ליצור בדיקות כפונקציות ולהשתמש בפקודות assert.
- יוצר שרת MCP עם שני כלים שונים.
- משתמש בפקודת `assert` כדי לבדוק שעמידה בתנאים מסוימים מתקיימת.

עיינו בקובץ המלא [כאן](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

בהתבסס על הקובץ שלמעלה, תוכלו לבדוק את השרת שלכם כדי לוודא שהיכולות נוצרות כראוי.

כל ערכות הפיתוח העיקריות כוללות סעיפי בדיקה דומים כך שתוכלו להתאים לסביבת הריצה שבחרתם.

## דוגמאות

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## משאבים נוספים

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## מה הלאה

- הבא: [Deployment](/03-GettingStarted/09-deployment/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון שתרגומים אוטומטיים עלולים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפת המקור שלו הוא המקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי אדם. אנו לא נושאים באחריות לכל אי הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.