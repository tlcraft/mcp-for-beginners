<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:02:53+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "he"
}
-->
# הרצת הדוגמה הזו

כאן תמצאו כיצד להפעיל את שרת ולקוח הזרמת HTTP הקלאסיים, וכן את שרת ולקוח ה-MCP באמצעות Python.

### סקירה כללית

- תגדירו שרת MCP שמשדר התראות התקדמות ללקוח בזמן שהוא מעבד פריטים.
- הלקוח יציג כל התראה בזמן אמת.
- מדריך זה מכסה דרישות מוקדמות, הגדרה, הרצה ופתרון תקלות.

### דרישות מוקדמות

- Python 3.9 או גרסה חדשה יותר
- חבילת `mcp` של Python (התקנה עם `pip install mcp`)

### התקנה והגדרה

1. שיכפלו את המאגר או הורידו את קבצי הפתרון.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **צרו והפעילו סביבת וירטואלית (מומלץ):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **התקינו את התלויות הנדרשות:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### קבצים

- **שרת:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **לקוח:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### הרצת שרת הזרמת HTTP הקלאסי

1. עברו לתיקיית הפתרון:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. התחילו את שרת הזרמת HTTP הקלאסי:

   ```pwsh
   python server.py
   ```

3. השרת יתחיל ויציג:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### הרצת לקוח הזרמת HTTP הקלאסי

1. פתחו טרמינל חדש (הפעילו את אותה סביבת וירטואלית ותיקייה):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. תראו הודעות משודרות המודפסות ברצף:

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

### הרצת שרת הזרמת MCP

1. עברו לתיקיית הפתרון:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. התחילו את שרת MCP עם ה-transport מסוג streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. השרת יתחיל ויציג:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### הרצת לקוח הזרמת MCP

1. פתחו טרמינל חדש (הפעילו את אותה סביבת וירטואלית ותיקייה):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. תראו התראות המודפסות בזמן אמת בזמן שהשרת מעבד כל פריט:
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

### שלבי מימוש עיקריים

1. **צרו את שרת ה-MCP באמצעות FastMCP.**
2. **הגדירו כלי שמעבד רשימה ושולח התראות באמצעות `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` לפעולות לא חוסמות.**
- תמיד לטפל בשגיאות גם בשרת וגם בלקוח לשמירה על יציבות.
- בדקו עם מספר לקוחות כדי לצפות בעדכונים בזמן אמת.
- אם נתקלים בשגיאות, בדקו את גרסת ה-Python ודאו שכל התלויות מותקנות.

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. איננו אחראים לכל אי הבנה או פרשנות שגויה הנובעים משימוש בתרגום זה.