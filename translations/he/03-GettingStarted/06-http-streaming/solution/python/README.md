<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:20:57+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "he"
}
-->
# הפעלת הדוגמה הזו

הנה איך להפעיל את שרת ולקוח ה-HTTP הזרמתי הקלאסי, כמו גם את שרת ולקוח ה-MCP הזרמתי באמצעות Python.

### סקירה כללית

- תגדיר שרת MCP שמשדר התראות התקדמות ללקוח בזמן שהוא מעבד פריטים.
- הלקוח יציג כל התראה בזמן אמת.
- מדריך זה מכסה דרישות מוקדמות, התקנה, הפעלה ופתרון בעיות.

### דרישות מוקדמות

- Python 3.9 או גרסה חדשה יותר
- חבילת Python בשם `mcp` (התקנה עם `pip install mcp`)

### התקנה והגדרה

1. שיבט את המאגר או הורד את קבצי הפתרון.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **צור והפעל סביבה וירטואלית (מומלץ):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **התקן את התלויות הנדרשות:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### קבצים

- **שרת:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **לקוח:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### הפעלת שרת ה-HTTP הזרמתי הקלאסי

1. עבור לתיקיית הפתרון:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. הפעל את שרת ה-HTTP הזרמתי הקלאסי:

   ```pwsh
   python server.py
   ```

3. השרת יתחיל ויציג:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### הפעלת לקוח ה-HTTP הזרמתי הקלאסי

1. פתח טרמינל חדש (הפעל את אותה סביבה וירטואלית ותיקייה):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. תראה הודעות משודרות מודפסות ברצף:

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### הפעלת שרת ה-MCP הזרמתי

1. עבור לתיקיית הפתרון:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. הפעל את שרת ה-MCP עם ה-transport מסוג streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. השרת יתחיל ויציג:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### הפעלת לקוח ה-MCP הזרמתי

1. פתח טרמינל חדש (הפעל את אותה סביבה וירטואלית ותיקייה):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. תראה התראות מודפסות בזמן אמת בזמן שהשרת מעבד כל פריט:
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### שלבי מפתח ביישום

1. **צור את שרת ה-MCP באמצעות FastMCP.**
2. **הגדר כלי שמעבד רשימה ושולח התראות באמצעות `ctx.info()` או `ctx.log()`.**
3. **הפעל את השרת עם `transport="streamable-http"`.**
4. **ממש לקוח עם מטפל הודעות להצגת ההתראות כשהן מגיעות.**

### סקירת הקוד
- השרת משתמש בפונקציות אסינכרוניות ובהקשר MCP כדי לשלוח עדכוני התקדמות.
- הלקוח מיישם מטפל הודעות אסינכרוני להדפסת ההתראות והתוצאה הסופית.

### טיפים ופתרון בעיות

- השתמש ב-`async/await` לפעולות לא חוסמות.
- תמיד טפל בשגיאות גם בשרת וגם בלקוח כדי להבטיח יציבות.
- בדוק עם מספר לקוחות כדי לראות עדכונים בזמן אמת.
- אם נתקלת בשגיאות, בדוק את גרסת ה-Python שלך וודא שכל התלויות מותקנות.

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.