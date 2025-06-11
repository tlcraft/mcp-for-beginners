<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T16:00:03+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "he"
}
-->
# שיעור: בניית שרת MCP לחיפוש באינטרנט

פרק זה מראה כיצד לבנות סוכן AI אמיתי שמשתלב עם APIs חיצוניים, מטפל בסוגי נתונים מגוונים, מנהל שגיאות ומסנכרן כלים מרובים — הכל בפורמט מוכן לפרודקשן. תראו:

- **שילוב עם APIs חיצוניים הדורשים אימות**
- **טיפול בסוגי נתונים מגוונים ממספר נקודות קצה**
- **אסטרטגיות ניהול שגיאות ורישום אמינות**
- **סינכרון כלים מרובים בשרת אחד**

בסוף, יהיה לכם ניסיון מעשי עם דפוסים ופרקטיקות מיטביות שחיוניות ליישומים מתקדמים מבוססי AI ו-LLM.

## מבוא

בשיעור זה תלמדו כיצד לבנות שרת MCP ולקוח מתקדמים שמרחיבים את יכולות ה-LLM עם נתוני רשת בזמן אמת בעזרת SerpAPI. זו מיומנות קריטית לפיתוח סוכני AI דינמיים שיכולים לגשת למידע מעודכן מהאינטרנט.

## מטרות הלמידה

בסיום השיעור תוכלו:

- לשלב APIs חיצוניים (כמו SerpAPI) בצורה מאובטחת בשרת MCP
- לממש כלים מרובים לחיפוש באינטרנט, חדשות, מוצרים ושאלות ותשובות
- לפרסר ולפורמט נתונים מובנים לצריכת LLM
- לנהל שגיאות ומגבלות קצב API ביעילות
- לבנות ולבדוק לקוחות MCP אוטומטיים ואינטראקטיביים

## שרת MCP לחיפוש באינטרנט

חלק זה מציג את הארכיטקטורה והתכונות של שרת MCP לחיפוש באינטרנט. תראו כיצד FastMCP ו-SerpAPI משולבים יחד להרחבת יכולות ה-LLM עם נתוני רשת בזמן אמת.

### סקירה כללית

מימוש זה כולל ארבעה כלים שמדגימים את יכולת ה-MCP לטפל במשימות מגוונות שמונעות על ידי API חיצוני בצורה מאובטחת ויעילה:

- **general_search**: לתוצאות חיפוש רחבות באינטרנט
- **news_search**: לכותרות חדשות עדכניות
- **product_search**: לנתוני מסחר אלקטרוני
- **qna**: למקטעי שאלות ותשובות

### תכונות
- **דוגמאות קוד**: כוללות בלוקי קוד ספציפיים לשפה בפייתון (וקלות להרחבה לשפות אחרות) עם חלקים מתקפלים להבהרה

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

לפני הרצת הלקוח, כדאי להבין מה השרת עושה. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

הנה דוגמה קצרה לאופן שבו השרת מגדיר ומרשום כלי:

<details>  
<summary>Python Server</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **שילוב API חיצוני**: מדגים טיפול מאובטח במפתחות API ובבקשות חיצוניות
- **פרסור נתונים מובנים**: מראה כיצד להמיר תגובות API לפורמטים ידידותיים ל-LLM
- **ניהול שגיאות**: טיפול אמין בשגיאות עם רישום מתאים
- **לקוח אינטראקטיבי**: כולל בדיקות אוטומטיות ומצב אינטראקטיבי לבדיקה
- **ניהול הקשר**: מנצל את MCP Context לרישום ומעקב אחר בקשות

## דרישות מוקדמות

לפני שתתחילו, ודאו שהסביבה שלכם מוגדרת כראוי על ידי ביצוע השלבים הבאים. זה יבטיח שכל התלויות מותקנות ומפתחות ה-API מוגדרים נכון לפיתוח ובדיקות חלקות.

- Python 3.8 ומעלה
- מפתח SerpAPI (הרשמו ב-[SerpAPI](https://serpapi.com/) - ישנה שכבת שימוש חינמית)

## התקנה

כדי להתחיל, בצעו את השלבים הבאים להגדרת הסביבה:

1. התקנת תלויות באמצעות uv (מומלץ) או pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. צרו קובץ `.env` בשורש הפרויקט עם מפתח ה-SerpAPI שלכם:

```
SERPAPI_KEY=your_serpapi_key_here
```

## שימוש

שרת MCP לחיפוש באינטרנט הוא הרכיב המרכזי שמחשף כלים לחיפוש באינטרנט, חדשות, מוצרים ושאלות ותשובות באמצעות שילוב עם SerpAPI. הוא מטפל בבקשות נכנסות, מנהל קריאות API, מפרסר תגובות ומחזיר תוצאות מובנות ללקוח.

ניתן לעיין במימוש המלא ב-[`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### הרצת השרת

להפעלת שרת ה-MCP השתמשו בפקודה הבאה:

```bash
python server.py
```

השרת ירוץ כשרת MCP מבוסס stdio שאליו הלקוח יכול להתחבר ישירות.

### מצבי הלקוח

הלקוח (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### הרצת הלקוח

להרצת בדיקות אוטומטיות (השרת יופעל אוטומטית):

```bash
python client.py
```

או במצב אינטראקטיבי:

```bash
python client.py --interactive
```

### בדיקות עם שיטות שונות

ישנן מספר דרכים לבדוק ולהתמודד עם הכלים שהשרת מספק, בהתאם לצרכים ולזרימת העבודה שלכם.

#### כתיבת סקריפטים מותאמים אישית עם MCP Python SDK
ניתן גם לבנות סקריפטים מותאמים אישית באמצעות MCP Python SDK:

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

בהקשר זה, "סקריפט בדיקה" הוא תוכנית פייתון מותאמת שאתם כותבים כדי לפעול כלקוח לשרת MCP. במקום להיות בדיקת יחידה פורמלית, הסקריפט מאפשר להתחבר לתוכנה, לקרוא לכלים עם פרמטרים שבחרתם ולבדוק את התוצאות. גישה זו שימושית ל:

- פרוטוטייפינג וניסוי עם קריאות לכלים
- אימות תגובות השרת לקלטים שונים
- אוטומציה של קריאות חוזרות לכלים
- בניית זרימות עבודה או אינטגרציות משלכם מעל שרת MCP

ניתן להשתמש בסקריפטים כדי לנסות שאילתות חדשות במהירות, לאתר באגים בהתנהגות הכלים או אפילו כנקודת התחלה לאוטומציה מתקדמת יותר. להלן דוגמה לשימוש ב-MCP Python SDK ליצירת סקריפט כזה:

## תיאורי כלים

ניתן להשתמש בכלים הבאים שמספק השרת כדי לבצע סוגים שונים של חיפושים ושאילתות. כל כלי מתואר להלן עם הפרמטרים ושימוש לדוגמה.

חלק זה מספק פרטים על כל כלי זמין ופרמטריו.

### general_search

מבצע חיפוש כללי באינטרנט ומחזיר תוצאות מפורמטות.

**כיצד לקרוא לכלי זה:**

ניתן לקרוא ל-`general_search` מתוך הסקריפט שלכם באמצעות MCP Python SDK, או באופן אינטראקטיבי דרך Inspector או במצב הלקוח האינטראקטיבי. הנה דוגמת קוד באמצעות ה-SDK:

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

כחלופה, במצב אינטראקטיבי, בחרו `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (מחרוזת): שאילתת החיפוש

**בקשת דוגמה:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

מחפש מאמרי חדשות עדכניים הקשורים לשאילתה.

**כיצד לקרוא לכלי זה:**

ניתן לקרוא ל-`news_search` מתוך הסקריפט שלכם באמצעות MCP Python SDK, או באופן אינטראקטיבי דרך Inspector או במצב הלקוח האינטראקטיבי. הנה דוגמת קוד באמצעות ה-SDK:

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

כחלופה, במצב אינטראקטיבי, בחרו `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (מחרוזת): שאילתת החיפוש

**בקשת דוגמה:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

מחפש מוצרים התואמים לשאילתה.

**כיצד לקרוא לכלי זה:**

ניתן לקרוא ל-`product_search` מתוך הסקריפט שלכם באמצעות MCP Python SDK, או באופן אינטראקטיבי דרך Inspector או במצב הלקוח האינטראקטיבי. הנה דוגמת קוד באמצעות ה-SDK:

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

כחלופה, במצב אינטראקטיבי, בחרו `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (מחרוזת): שאילתת חיפוש המוצר

**בקשת דוגמה:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

מקבל תשובות ישירות לשאלות ממנועי חיפוש.

**כיצד לקרוא לכלי זה:**

ניתן לקרוא ל-`qna` מתוך הסקריפט שלכם באמצעות MCP Python SDK, או באופן אינטראקטיבי דרך Inspector או במצב הלקוח האינטראקטיבי. הנה דוגמת קוד באמצעות ה-SDK:

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

כחלופה, במצב אינטראקטיבי, בחרו `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (מחרוזת): השאלה למציאת תשובה

**בקשת דוגמה:**

```json
{
  "question": "what is artificial intelligence"
}
```

## פרטי קוד

חלק זה מספק קטעי קוד והפניות למימושי השרת והלקוח.

<details>
<summary>Python</summary>

עיינו ב-[`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) לפרטים מלאים על המימוש.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## מושגים מתקדמים בשיעור זה

לפני שתתחילו לבנות, הנה כמה מושגים מתקדמים חשובים שיופיעו לאורך הפרק. הבנתם תעזור לכם לעקוב, גם אם הם חדשים לכם:

- **סינכרון כלים מרובים**: הרצה של מספר כלים שונים (כמו חיפוש באינטרנט, חדשות, מוצרים ושאלות ותשובות) בתוך שרת MCP אחד. זה מאפשר לשרת לטפל במגוון משימות, לא רק אחת.
- **ניהול מגבלות קצב API**: APIs חיצוניים רבים (כמו SerpAPI) מגבילים כמה בקשות אפשר לבצע בפרק זמן מסוים. קוד טוב בודק את המגבלות ומטפל בהן בצורה חלקה, כך שהאפליקציה לא תקרוס אם תגיע למגבלה.
- **פרסור נתונים מובנים**: תגובות API מורכבות ולעיתים מקוננות. המושג עוסק בהפיכת התגובות לפורמטים נקיים וקלים לשימוש, ידידותיים ל-LLM או תוכניות אחרות.
- **התאוששות משגיאות**: לפעמים דברים משתבשים — אולי הרשת נופלת, או ה-API לא מחזיר את מה שציפיתם. התאוששות משגיאות אומרת שהקוד שלכם יכול להתמודד עם הבעיות האלו ועדיין לספק משוב שימושי, במקום לקרוס.
- **אימות פרמטרים**: בדיקה שכל הקלטים לכלים שלכם נכונים ובטוחים לשימוש. כולל קביעת ערכי ברירת מחדל ווידוא שהסוגים נכונים, מה שעוזר למנוע באגים ובלבול.

חלק זה יעזור לכם לאבחן ולפתור בעיות נפוצות שעלולות להתרחש בעבודה עם שרת MCP לחיפוש באינטרנט. אם תיתקלו בשגיאות או בהתנהגות לא צפויה, חלק זה מספק פתרונות לבעיות הנפוצות ביותר. עיינו בטיפים לפני שתפנו לעזרה נוספת — הם בדרך כלל פותרים בעיות במהירות.

## פתרון בעיות

בעת עבודה עם שרת MCP לחיפוש באינטרנט, ייתכן שתיתקלו מדי פעם בבעיות — זה נורמלי בפיתוח עם APIs חיצוניים וכלים חדשים. חלק זה מספק פתרונות מעשיים לבעיות הנפוצות ביותר, כדי שתוכלו לחזור לעבודה במהירות. אם מופיעה שגיאה, התחילו כאן: הטיפים הבאים מתייחסים לבעיות שהמשתמשים נתקלים בהן לרוב ויכולים לעיתים לפתור את הבעיה ללא צורך בעזרה נוספת.

### בעיות נפוצות

להלן כמה מהבעיות השכיחות ביותר עם הסברים ברורים ושלבים לפתרונן:

1. **חסר SERPAPI_KEY בקובץ .env**
   - אם אתם רואים את השגיאה `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your ``, ודאו שקובץ ה-`.env` קיים עם המפתח הנכון. אם המפתח נכון ועדיין מופיעה השגיאה, בדקו אם שכבת השימוש החינמית שלכם אזלה.

### מצב דיבאג

ברירת המחדל, האפליקציה רושמת רק מידע חשוב. אם תרצו לראות פרטים נוספים על מה שקורה (למשל, לאבחון בעיות מורכבות), ניתן להפעיל מצב DEBUG. זה יציג מידע רב יותר על כל שלב שהאפליקציה מבצעת.

**דוגמה: פלט רגיל**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**דוגמה: פלט DEBUG**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

שימו לב שמצב DEBUG כולל שורות נוספות על בקשות HTTP, תגובות ופרטים פנימיים אחרים. זה יכול לעזור מאוד בפתרון בעיות.

להפעלת מצב DEBUG, הגדירו את רמת הלוגינג ל-DEBUG בראש הקובץ `client.py` or `server.py`:

<details>
<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## מה הלאה

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפתו המקורית הוא המקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות על אי-הבנות או פרשנויות שגויות הנובעות משימוש בתרגום זה.