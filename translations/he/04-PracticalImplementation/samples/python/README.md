<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:31:52+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "he"
}
-->
# פרוטוקול הקשר מודל (MCP) מימוש בפייתון

מאגר זה מכיל מימוש בפייתון של פרוטוקול הקשר מודל (MCP), המדגים כיצד ליצור גם אפליקציית שרת וגם לקוח התקשורת באמצעות תקן MCP.

## סקירה כללית

מימוש ה-MCP מורכב משני רכיבים עיקריים:

1. **MCP Server (`server.py`)** – שרת החשוף:
   - **כלים**: פונקציות שניתן לקרוא להן מרחוק
   - **משאבים**: נתונים שניתן לשלוף
   - **הנחיות**: תבניות ליצירת הנחיות למודלים לשוניים

2. **MCP Client (`client.py`)** – אפליקציית לקוח שמתחברת לשרת ומשתמשת בתכונותיו

## תכונות

מימוש זה מדגים מספר תכונות מרכזיות של MCP:

### כלים
- `completion` – מייצר השלמות טקסט ממודלים של בינה מלאכותית (מדומה)
- `add` – מחשבון פשוט שמחבר שני מספרים

### משאבים
- `models://` – מחזיר מידע על מודלי בינה מלאכותית זמינים
- `greeting://{name}` – מחזיר ברכה מותאמת אישית לשם נתון

### הנחיות
- `review_code` – מייצר הנחיה לסקירת קוד

## התקנה

כדי להשתמש במימוש MCP זה, התקן את החבילות הנדרשות:

```powershell
pip install mcp-server mcp-client
```

## הפעלת השרת והלקוח

### הפעלת השרת

הרץ את השרת בחלון טרמינל אחד:

```powershell
python server.py
```

ניתן גם להפעיל את השרת במצב פיתוח באמצעות MCP CLI:

```powershell
mcp dev server.py
```

או להתקין ב-Claude Desktop (אם זמין):

```powershell
mcp install server.py
```

### הפעלת הלקוח

הרץ את הלקוח בחלון טרמינל נוסף:

```powershell
python client.py
```

זה יתחבר לשרת וידגים את כל התכונות הזמינות.

### שימוש בלקוח

הלקוח (`client.py`) מדגים את כל יכולות ה-MCP:

```powershell
python client.py
```

זה יתחבר לשרת ויבצע את כל התכונות כולל כלים, משאבים והנחיות. הפלט יציג:

1. תוצאת כלי המחשבון (5 + 7 = 12)
2. תגובת כלי ההשלמה לשאלה "מה משמעות החיים?"
3. רשימת מודלי הבינה המלאכותית הזמינים
4. ברכה מותאמת אישית ל-"MCP Explorer"
5. תבנית הנחיה לסקירת קוד

## פרטי מימוש

השרת מיושם באמצעות ה-`FastMCP` API, המספק הפשטות ברמה גבוהה להגדרת שירותי MCP. הנה דוגמה פשוטה לאופן הגדרת הכלים:

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

הלקוח משתמש בספריית הלקוח של MCP להתחברות וקריאה לשרת:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## למידע נוסף

למידע נוסף על MCP, בקרו בכתובת: https://modelcontextprotocol.io/

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.