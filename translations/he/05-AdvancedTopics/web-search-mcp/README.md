<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:19:52+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "he"
}
-->
# שיעור: בניית שרת MCP לחיפוש באינטרנט

פרק זה מראה כיצד לבנות סוכן AI אמיתי שמשתלב עם APIs חיצוניים, מטפל בסוגי נתונים מגוונים, מנהל שגיאות ומאחד כלים רבים – הכל בפורמט מוכן לפרודקשן. תראה:

- **שילוב עם APIs חיצוניים שדורשים אימות**
- **טיפול בסוגי נתונים מגוונים ממספר נקודות קצה**
- **אסטרטגיות טיפול ושמירת שגיאות יציבות**
- **אורקסטרציה של כלים מרובים בשרת יחיד**

בסוף, תרכוש ניסיון מעשי בדפוסים ובשיטות עבודה מומלצות שחשובים ליישומים מתקדמים מבוססי AI ו-LLM.

## מבוא

בשיעור זה תלמד כיצד לבנות שרת MCP ולקוח מתקדמים שמרחיבים את יכולות ה-LLM עם נתוני רשת בזמן אמת בעזרת SerpAPI. זו מיומנות חיונית לפיתוח סוכני AI דינמיים שיכולים לגשת למידע מעודכן מהרשת.

## מטרות הלמידה

בסיום השיעור תוכל:

- לשלב APIs חיצוניים (כמו SerpAPI) בצורה מאובטחת בשרת MCP
- לממש כלים מרובים לחיפוש באינטרנט, חדשות, מוצרים ושאלות ותשובות
- לפרסר ולעצב נתונים מובנים לצריכת LLM
- לטפל בשגיאות ולנהל מגבלות קצב API ביעילות
- לבנות ולבדוק לקוחות MCP אוטומטיים ואינטראקטיביים

## שרת MCP לחיפוש באינטרנט

בחלק זה מוצגים הארכיטקטורה והתכונות של שרת MCP לחיפוש באינטרנט. תראה כיצד FastMCP ו-SerpAPI משולבים יחד להרחבת יכולות ה-LLM עם נתוני רשת בזמן אמת.

### סקירה כללית

מימוש זה כולל ארבעה כלים המדגימים את יכולת ה-MCP לטפל במשימות מגוונות המונעות על ידי APIs חיצוניים בצורה מאובטחת ויעילה:

- **general_search**: לתוצאות חיפוש רחבות באינטרנט
- **news_search**: לכותרות חדשות אחרונות
- **product_search**: לנתוני מסחר אלקטרוני
- **qna**: לקטעי שאלות ותשובות

### תכונות
- **דוגמאות קוד**: כוללות קטעי קוד לשפה ספציפית בפייתון (וקלה להרחבה לשפות אחרות) עם חלקים מתכווצים להבהרה

<details>  
<summary>פייתון</summary>  

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

לפני הרצת הלקוח, מומלץ להבין מה השרת עושה. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

להלן דוגמה קצרה לאופן שבו השרת מגדיר ומרשום כלי:

<details>  
<summary>שרת בפייתון</summary> 

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
- **פירוש נתונים מובנים**: מראה כיצד להמיר תגובות API לפורמטים ידידותיים ל-LLM
- **טיפול בשגיאות**: טיפול יציב בשגיאות עם רישום מתאים
- **לקוח אינטראקטיבי**: כולל גם בדיקות אוטומטיות וגם מצב אינטראקטיבי לבדיקות
- **ניהול הקשר**: משתמש ב-MCP Context לרישום ומעקב אחר בקשות

## דרישות מוקדמות

לפני שתתחיל, ודא שסביבת העבודה שלך מוגדרת כראוי לפי השלבים הבאים. זה יבטיח שכל התלויות מותקנות ומפתחות ה-API מוגדרים נכון לפיתוח ובדיקות חלקות.

- Python 3.8 ומעלה
- מפתח SerpAPI (הירשם ב-[SerpAPI](https://serpapi.com/) - יש שכבת חינם)

## התקנה

כדי להתחיל, בצע את השלבים הבאים להגדרת הסביבה:

1. התקן תלויות באמצעות uv (מומלץ) או pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. צור קובץ `.env` בשורש הפרויקט עם מפתח SerpAPI שלך:

```
SERPAPI_KEY=your_serpapi_key_here
```

## שימוש

שרת MCP לחיפוש באינטרנט הוא הרכיב המרכזי שמספק כלים לחיפוש באינטרנט, חדשות, מוצרים ושאלות ותשובות באמצעות שילוב עם SerpAPI. הוא מטפל בבקשות נכנסות, מנהל קריאות API, מפרש תגובות ומחזיר תוצאות מובנות ללקוח.

ניתן לעיין במימוש המלא בקובץ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### הפעלת השרת

להפעלת שרת MCP, השתמש בפקודה הבאה:

```bash
python server.py
```

השרת ירוץ כשרת MCP מבוסס stdio שהלקוח יכול להתחבר אליו ישירות.

### מצבי לקוח

הלקוח (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### הפעלת הלקוח

להרצת בדיקות אוטומטיות (השרת יופעל אוטומטית):

```bash
python client.py
```

או הפעלה במצב אינטראקטיבי:

```bash
python client.py --interactive
```

### בדיקות בשיטות שונות

ישנן מספר דרכים לבדוק ולהתממשק עם הכלים שהשרת מספק, בהתאם לצרכים ולזרימת העבודה שלך.

#### כתיבת סקריפטי בדיקה מותאמים עם MCP Python SDK
ניתן גם לבנות סקריפטי בדיקה משלך באמצעות MCP Python SDK:

<details>
<summary>פייתון</summary>

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

בהקשר זה, "סקריפט בדיקה" הוא תוכנית פייתון מותאמת שאתה כותב לפעול כלקוח לשרת MCP. במקום להיות בדיקת יחידה פורמלית, סקריפט זה מאפשר לך להתחבר לתוכנית לשרת, לקרוא לכל אחד מהכלים עם פרמטרים שתבחר, ולבדוק את התוצאות. גישה זו שימושית ל:

- פרוטוטייפינג וניסויים בקריאות כלים
- אימות תגובות השרת לקלטים שונים
- אוטומציה של קריאות כלים חוזרות
- בניית זרימות עבודה או אינטגרציות משלך מעל שרת MCP

ניתן להשתמש בסקריפטים לבדיקה מהירה של שאילתות חדשות, ניפוי באגים של התנהגות כלים, או אפילו כנקודת התחלה לאוטומציה מתקדמת יותר. להלן דוגמה לשימוש ב-MCP Python SDK ליצירת סקריפט כזה:

## תיאורי כלים

ניתן להשתמש בכלים הבאים שמספק השרת לביצוע סוגי חיפושים ושאילתות שונים. כל כלי מתואר להלן עם הפרמטרים שלו ודוגמת שימוש.

בחלק זה מפורטים פרטים על כל כלי זמין ופרמטריו.

### general_search

מבצע חיפוש כללי באינטרנט ומחזיר תוצאות מעוצבות.

**איך לקרוא לכלי זה:**

ניתן לקרוא ל-`general_search` מתוך הסקריפט שלך באמצעות MCP Python SDK, או באינטראקציה עם Inspector או במצב הלקוח האינטראקטיבי. להלן דוגמת קוד בשימוש ב-SDK:

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

לחלופין, במצב אינטראקטיבי, בחר `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): מחרוזת השאילתה

**בקשת דוגמה:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

מחפש מאמרי חדשות אחרונים הקשורים לשאילתה.

**איך לקרוא לכלי זה:**

ניתן לקרוא ל-`news_search` מתוך הסקריפט שלך באמצעות MCP Python SDK, או באינטראקציה עם Inspector או במצב הלקוח האינטראקטיבי. להלן דוגמת קוד בשימוש ב-SDK:

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

לחלופין, במצב אינטראקטיבי, בחר `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): מחרוזת השאילתה

**בקשת דוגמה:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

מחפש מוצרים התואמים לשאילתה.

**איך לקרוא לכלי זה:**

ניתן לקרוא ל-`product_search` מתוך הסקריפט שלך באמצעות MCP Python SDK, או באינטראקציה עם Inspector או במצב הלקוח האינטראקטיבי. להלן דוגמת קוד בשימוש ב-SDK:

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

לחלופין, במצב אינטראקטיבי, בחר `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): מחרוזת חיפוש המוצר

**בקשת דוגמה:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

מקבל תשובות ישירות לשאלות ממנועי חיפוש.

**איך לקרוא לכלי זה:**

ניתן לקרוא ל-`qna` מתוך הסקריפט שלך באמצעות MCP Python SDK, או באינטראקציה עם Inspector או במצב הלקוח האינטראקטיבי. להלן דוגמת קוד בשימוש ב-SDK:

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

לחלופין, במצב אינטראקטיבי, בחר `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): השאלה למציאת תשובה

**בקשת דוגמה:**

```json
{
  "question": "what is artificial intelligence"
}
```

## פרטי קוד

בחלק זה מוצגים קטעי קוד והפניות למימושי השרת והלקוח.

<details>
<summary>פייתון</summary>

עיין ב-[`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) לפרטי מימוש מלאים.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## מושגים מתקדמים בשיעור זה

לפני שתתחיל לבנות, הנה כמה מושגים מתקדמים חשובים שיופיעו לאורך הפרק. הבנתם תסייע לך לעקוב, גם אם הם חדשים לך:

- **אורקסטרציה של כלים מרובים**: משמעות הדבר היא הרצת מספר כלים שונים (כמו חיפוש באינטרנט, חדשות, מוצרים ושאלות ותשובות) בתוך שרת MCP יחיד. זה מאפשר לשרת שלך לטפל במגוון משימות, לא רק באחת.
- **ניהול מגבלות קצב API**: APIs רבים (כמו SerpAPI) מגבילים כמה בקשות ניתן לשלוח בפרק זמן מסוים. קוד טוב בודק מגבלות אלה ומטפל בהן בצורה חלקה, כך שהאפליקציה לא תקרוס אם תגיע למגבלה.
- **פירוש נתונים מובנים**: תגובות API לעיתים מורכבות ומקוננות. המושג מתייחס להפיכת תגובות אלה לפורמטים נקיים, קלים לשימוש וידידותיים ל-LLM או תוכניות אחרות.
- **שחזור שגיאות**: לפעמים מתרחשות תקלות – אולי הרשת נכשלה, או ה-API לא החזיר את מה שציפית. שחזור שגיאות אומר שהקוד שלך יכול להתמודד עם הבעיות האלה ולספק משוב שימושי, במקום לקרוס.
- **אימות פרמטרים**: זה כולל בדיקה שכל הקלטים לכלים שלך תקינים ובטוחים לשימוש. זה כולל הגדרת ערכי ברירת מחדל ווידוא סוגי הנתונים, מה שעוזר למנוע באגים ובלבול.

בחלק זה תוכל לאבחן ולפתור בעיות נפוצות שעשויות להתרחש במהלך העבודה עם שרת MCP לחיפוש באינטרנט. אם נתקלת בשגיאות או בהתנהגות לא צפויה, סעיף פתרון הבעיות הזה מציע פתרונות לבעיות הנפוצות ביותר. עיין בטיפים לפני שתבקש עזרה נוספת – לרוב הם פותרים בעיות במהירות.

## פתרון בעיות

בעת עבודה עם שרת MCP לחיפוש באינטרנט, ייתכן שתיתקל מדי פעם בבעיות – זה טבעי בפיתוח עם APIs חיצוניים וכלים חדשים. חלק זה מספק פתרונות מעשיים לבעיות הנפוצות ביותר, כדי שתוכל לחזור לפעילות במהירות. אם נתקלת בשגיאה, התחל כאן: הטיפים הבאים מתמקדים בבעיות שרוב המשתמשים נתקלים בהן ולעיתים קרובות פותרים את הבעיה ללא צורך בעזרה נוספת.

### בעיות נפוצות

להלן כמה מהבעיות הנפוצות ביותר שמשתמשים נתקלים בהן, עם הסברים ברורים ושלבים לפתרונן:

1. **חסר SERPAPI_KEY בקובץ .env**
   - אם אתה רואה את השגיאה `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your ``, ודא שקובץ ה-`.env` קיים ומכיל את המפתח. אם המפתח נכון ועדיין מופיעה השגיאה, בדוק אם שכבת החינם שלך אזלה.

### מצב ניפוי שגיאות (DEBUG)

ברירת המחדל היא שהאפליקציה רושמת רק מידע חשוב. אם ברצונך לראות פרטים נוספים על מה שקורה (למשל, לאבחון בעיות מורכבות), ניתן להפעיל מצב DEBUG. זה יציג מידע רב יותר על כל שלב שהאפליקציה מבצעת.

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

שים לב שמצב DEBUG כולל שורות נוספות על בקשות HTTP, תגובות ופרטים פנימיים אחרים. זה יכול להיות מאוד שימושי לפתרון תקלות.

להפעלת מצב DEBUG, הגדר את רמת הלוג ל-DEBUG בראש הקובץ `client.py` or `server.py`:

<details>
<summary>פייתון</summary>

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

- [6. תרומות מהקהילה](../../06-CommunityContributions/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו צריך להיחשב כמקור המוסמך. עבור מידע קריטי, מומלץ להשתמש בתרגום מקצועי אנושי. אנו לא נושאים באחריות לכל אי הבנה או פרשנות שגויה הנובעים משימוש בתרגום זה.