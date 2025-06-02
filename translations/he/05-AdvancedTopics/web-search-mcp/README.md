<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T19:16:48+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "he"
}
-->
# שיעור: בניית שרת MCP לחיפוש אינטרנטי

פרק זה מציג כיצד לבנות סוכן AI אמיתי שמשתלב עם APIs חיצוניים, מטפל בסוגי נתונים מגוונים, מנהל שגיאות ומתזמר כלים מרובים — הכל בפורמט מוכן לייצור. תראו:

- **שילוב עם APIs חיצוניים שדורשים אימות**
- **טיפול בסוגי נתונים מגוונים ממספר נקודות קצה**
- **אסטרטגיות חזקות לטיפול בשגיאות ולוגים**
- **תזמור כלים מרובים בשרת אחד**

בסוף, תקבלו ניסיון מעשי עם תבניות ושיטות עבודה מומלצות שחשובות לאפליקציות AI מתקדמות ומונעות LLM.

## מבוא

בשיעור זה תלמדו כיצד לבנות שרת ולקוח MCP מתקדם שמרחיב את יכולות ה-LLM עם נתוני אינטרנט בזמן אמת באמצעות SerpAPI. זו מיומנות קריטית לפיתוח סוכני AI דינמיים שיכולים לגשת למידע עדכני מהאינטרנט.

## מטרות הלמידה

בסוף השיעור תוכלו:

- לשלב APIs חיצוניים (כמו SerpAPI) בצורה מאובטחת בשרת MCP
- ליישם כלים מרובים לחיפוש אינטרנט, חדשות, מוצרים ושאלות ותשובות
- לנתח ולעצב נתונים מובנים לשימוש ב-LLM
- לטפל בשגיאות ולנהל הגבלות קצב API ביעילות
- לבנות ולבדוק לקוחות MCP אוטומטיים ואינטראקטיביים

## שרת MCP לחיפוש אינטרנטי

חלק זה מציג את הארכיטקטורה והתכונות של שרת MCP לחיפוש אינטרנטי. תראו כיצד FastMCP ו-SerpAPI משולבים להרחבת יכולות ה-LLM עם נתוני אינטרנט בזמן אמת.

### סקירה כללית

מימוש זה כולל ארבעה כלים המדגימים את יכולת MCP לטפל במשימות מגוונות המונעות API חיצוני בצורה מאובטחת ויעילה:

- **general_search**: לתוצאות חיפוש אינטרנט רחבות
- **news_search**: לכותרות חדשות עדכניות
- **product_search**: לנתוני מסחר אלקטרוני
- **qna**: לפיסות שאלות ותשובות

### תכונות
- **דוגמאות קוד**: כולל קטעי קוד ספציפיים לשפה בפייתון (וקלים להרחבה לשפות נוספות) עם חלקים נפתחים לשקיפות

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

לפני הרצת הלקוח, מומלץ להבין מה השרת עושה. הקובץ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

הנה דוגמה קצרה לאופן שבו השרת מגדיר ומרשם כלי:

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
- **פירוק נתונים מובנים**: מראה כיצד להפוך תגובות API לפורמט ידידותי ל-LLM
- **טיפול בשגיאות**: טיפול חזק בשגיאות עם רישום מתאים
- **לקוח אינטראקטיבי**: כולל גם בדיקות אוטומטיות וגם מצב אינטראקטיבי לבדיקות
- **ניהול הקשר**: משתמש ב-MCP Context ללוגים ומעקב אחר בקשות

## דרישות מוקדמות

לפני שתתחילו, ודאו שהסביבה שלכם מוגדרת כראוי לפי השלבים הבאים. זה יבטיח שכל התלויות מותקנות ומפתחות ה-API שלכם מוגדרים נכון לפיתוח ובדיקות חלקות.

- Python 3.8 ומעלה
- מפתח SerpAPI (הרשמו ב-[SerpAPI](https://serpapi.com/) - יש שכבת חינם)

## התקנה

כדי להתחיל, בצעו את השלבים הבאים להקמת הסביבה:

1. התקינו את התלויות באמצעות uv (מומלץ) או pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. צרו קובץ `.env` בשורש הפרויקט עם מפתח SerpAPI שלכם:

```
SERPAPI_KEY=your_serpapi_key_here
```

## שימוש

שרת MCP לחיפוש אינטרנטי הוא הרכיב המרכזי שמספק כלים לחיפוש אינטרנט, חדשות, מוצרים ושאלות ותשובות על ידי שילוב עם SerpAPI. הוא מטפל בבקשות נכנסות, מנהל קריאות API, מפרש תגובות ומחזיר תוצאות מובנות ללקוח.

ניתן לעיין במימוש המלא בקובץ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### הפעלת השרת

להפעלת שרת MCP השתמשו בפקודה הבאה:

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

להריץ את הבדיקות האוטומטיות (זה יפעיל את השרת אוטומטית):

```bash
python client.py
```

או להריץ במצב אינטראקטיבי:

```bash
python client.py --interactive
```

### בדיקות בשיטות שונות

יש מספר דרכים לבדוק ולהתממשק עם הכלים שהשרת מספק, בהתאם לצרכים ולזרימת העבודה שלכם.

#### כתיבת סקריפטי בדיקה מותאמים אישית עם MCP Python SDK
ניתן גם לבנות סקריפטי בדיקה מותאמים אישית באמצעות MCP Python SDK:

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

בהקשר זה, "סקריפט בדיקה" הוא תוכנית פייתון מותאמת אישית שאתם כותבים כדי לשמש כלקוח לשרת MCP. במקום להיות בדיקת יחידה פורמלית, הסקריפט מאפשר חיבור תכנותי לשרת, קריאה לכל אחד מהכלים עם פרמטרים שתבחרו, ובדיקת התוצאות. גישה זו שימושית ל:

- פרוטוטייפינג וניסויים עם קריאות כלים
- אימות תגובות השרת לקלטים שונים
- אוטומציה של קריאות כלים חוזרות
- בניית זרימות עבודה או שילובים משלכם מעל שרת MCP

ניתן להשתמש בסקריפטים כדי לנסות שאילתות חדשות במהירות, לתקן באגים בהתנהגות הכלים, או אפילו כנקודת התחלה לאוטומציה מתקדמת יותר. להלן דוגמה לשימוש ב-MCP Python SDK ליצירת סקריפט כזה:

## תיאורי כלים

ניתן להשתמש בכלים הבאים המסופקים על ידי השרת לביצוע סוגי חיפושים ושאילתות שונים. כל כלי מתואר להלן עם הפרמטרים שלו ודוגמת שימוש.

חלק זה מספק פרטים על כל כלי זמין ופרמטריו.

### general_search

מבצע חיפוש אינטרנט כללי ומחזיר תוצאות מעוצבות.

**כיצד לקרוא לכלי זה:**

ניתן לקרוא ל-`general_search` מתוך הסקריפט שלכם באמצעות MCP Python SDK, או באינטראקציה באמצעות Inspector או מצב הלקוח האינטראקטיבי. הנה דוגמת קוד באמצעות ה-SDK:

<details>
<summary>דוגמה בפייתון</summary>

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

ניתן לקרוא ל-`news_search` מתוך הסקריפט שלכם באמצעות MCP Python SDK, או באינטראקציה באמצעות Inspector או מצב הלקוח האינטראקטיבי. הנה דוגמת קוד באמצעות ה-SDK:

<details>
<summary>דוגמה בפייתון</summary>

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

ניתן לקרוא ל-`product_search` מתוך הסקריפט שלכם באמצעות MCP Python SDK, או באינטראקציה באמצעות Inspector או מצב הלקוח האינטראקטיבי. הנה דוגמת קוד באמצעות ה-SDK:

<details>
<summary>דוגמה בפייתון</summary>

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

ניתן לקרוא ל-`qna` מתוך הסקריפט שלכם באמצעות MCP Python SDK, או באינטראקציה באמצעות Inspector או מצב הלקוח האינטראקטיבי. הנה דוגמת קוד באמצעות ה-SDK:

<details>
<summary>דוגמה בפייתון</summary>

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

ראו [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) לפרטי מימוש מלאים.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## מושגים מתקדמים בשיעור זה

לפני שתתחילו לבנות, הנה כמה מושגים מתקדמים חשובים שיתגלו לאורך הפרק. הבנתם תעזור לכם לעקוב, גם אם אתם חדשים להם:

- **תזמור כלים מרובים**: הרצת מספר כלים שונים (כמו חיפוש אינטרנט, חדשות, מוצרים ושאלות ותשובות) בתוך שרת MCP אחד. זה מאפשר לשרת שלכם לטפל במגוון משימות, לא רק באחת.
- **ניהול הגבלת קצב API**: APIs חיצוניים רבים (כמו SerpAPI) מגבילים כמה בקשות אפשר לבצע בפרק זמן מסוים. קוד טוב בודק את ההגבלות האלו ומטפל בהן בנעימות, כדי שהאפליקציה לא תקרוס כשמגיעים למגבלה.
- **פירוק נתונים מובנים**: תגובות API לעיתים מורכבות ומקוננות. המושג הזה עוסק בהפיכת התגובות לפורמטים נקיים וקלים לשימוש, ידידותיים ל-LLM או תוכניות אחרות.
- **שחזור שגיאות**: לפעמים דברים משתבשים — אולי הרשת נכשלה, או ה-API לא החזיר מה שציפיתם. שחזור שגיאות אומר שהקוד שלכם יכול להתמודד עם הבעיות האלו ולספק משוב שימושי, במקום לקרוס.
- **אימות פרמטרים**: זה קשור לוודא שכל הקלטים לכלים שלכם נכונים ובטוחים לשימוש. כולל הגדרת ערכי ברירת מחדל ווידוא סוגי הנתונים נכונים, מה שעוזר למנוע באגים ובלבול.

חלק זה יעזור לכם לאבחן ולפתור בעיות נפוצות שעלולות לצוץ בזמן עבודה עם שרת MCP לחיפוש אינטרנטי. אם נתקלתם בשגיאות או בהתנהגות בלתי צפויה, חלק פתרון הבעיות הזה מספק פתרונות לבעיות השכיחות ביותר. עיינו בטיפים האלו לפני שתפנו לעזרה נוספת — הם לעיתים פותרים בעיות במהירות.

## פתרון בעיות

בעת עבודה עם שרת MCP לחיפוש אינטרנטי, ייתכן שתיתקלו מדי פעם בבעיות — זה טבעי בפיתוח עם APIs חיצוניים וכלים חדשים. חלק זה מספק פתרונות מעשיים לבעיות הנפוצות ביותר, כדי שתוכלו לחזור לעבודה במהירות. אם נתקלתם בשגיאה, התחילו כאן: הטיפים למטה מטפלים בבעיות שרוב המשתמשים נתקלים בהן ולעיתים פותרים את הבעיה ללא צורך בעזרה נוספת.

### בעיות נפוצות

להלן כמה מהבעיות השכיחות ביותר שמשתמשים נתקלים בהן, עם הסברים ברורים ושלבים לפתרונן:

1. **מפתח SERPAPI_KEY חסר בקובץ .env**
   - אם אתם רואים את השגיאה `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env`, ודאו שקובץ `.env` קיים עם המפתח. אם המפתח נכון ועדיין מופיעה השגיאה, בדקו אם שכבת החינם שלכם אזלה.

### מצב ניפוי שגיאות (DEBUG)

ברירת המחדל, האפליקציה רושמת רק מידע חשוב. אם תרצו לראות פרטים נוספים על מה שקורה (למשל, לאבחון בעיות מורכבות), תוכלו להפעיל מצב DEBUG. זה יציג הרבה יותר על כל שלב שהאפליקציה מבצעת.

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

שימו לב שמצב DEBUG כולל שורות נוספות על בקשות HTTP, תגובות ופרטים פנימיים אחרים. זה יכול לעזור מאוד בפתרון תקלות.

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

- [6. תרומות קהילתיות](../../06-CommunityContributions/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי אדם. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.