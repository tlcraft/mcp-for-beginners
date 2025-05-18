<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:03:14+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "he"
}
-->
# הפעלת הדוגמה הזו

מומלץ להתקין את `uv` אך זה לא חובה, ראו [הוראות](https://docs.astral.sh/uv/#highlights)

## -0- יצירת סביבה וירטואלית

```bash
python -m venv venv
```

## -1- הפעלת הסביבה הוירטואלית

```bash
venv\Scrips\activate
```

## -2- התקנת התלויות

```bash
pip install "mcp[cli]"
```

## -3- הפעלת הדוגמה

```bash
python client.py
```

אתם אמורים לראות פלט דומה ל:

```text
LISTING RESOURCES
Resource:  ('meta', None)
Resource:  ('nextCursor', None)
Resource:  ('resources', [])
                    INFO     Processing request of type ListToolsRequest                                                                               server.py:534
LISTING TOOLS
Tool:  add
READING RESOURCE
                    INFO     Processing request of type ReadResourceRequest                                                                            server.py:534
CALL TOOL
                    INFO     Processing request of type CallToolRequest                                                                                server.py:534
[TextContent(type='text', text='8', annotations=None)]
```

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). בעוד אנו שואפים לדיוק, אנא היו מודעים לכך שתרגומים אוטומטיים עשויים להכיל טעויות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור הסמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום אנושי מקצועי. איננו אחראים לכל אי הבנות או פרשנויות שגויות הנובעות משימוש בתרגום זה.