<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:22:20+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "he"
}
-->
# הפעלת הדוגמה

כאן אנו מניחים שכבר יש לך קוד שרת עובד. אנא מצא שרת מאחד הפרקים הקודמים.

## הגדרת mcp.json

הנה קובץ שאתה משתמש בו כהפניה, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

שנה את הערך של השרת לפי הצורך כדי להצביע על הנתיב המוחלט לשרת שלך כולל הפקודה המלאה הנדרשת להרצה.

בקובץ הדוגמה שהוזכר לעיל הערך של השרת נראה כך:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

זה תואם להרצת פקודה כמו זו: `cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` הקלד משהו כמו "add 3 to 20".

אתה אמור לראות כלי מוצג מעל תיבת הטקסט של הצ'אט שמציין לך לבחור להריץ את הכלי כמו בתמונה זו:

![VS Code מציין שהוא רוצה להריץ כלי](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.he.png)

בחירת הכלי אמורה להפיק תוצאה מספרית שאומרת "23" אם ההנחיה שלך הייתה כמו שציינו קודם.

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עשויים להכיל טעויות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור סמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום מקצועי אנושי. אנו לא אחראים לכל אי הבנות או פירושים מוטעים הנובעים משימוש בתרגום זה.