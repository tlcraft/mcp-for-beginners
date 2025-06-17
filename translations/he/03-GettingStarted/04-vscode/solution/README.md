<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:58:32+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "he"
}
-->
# הרצת הדוגמה

כאן מניחים שכבר יש לכם קוד שרת עובד. אנא מצאו שרת מאחד הפרקים הקודמים.

## הגדרת mcp.json

הנה קובץ לשימוש כהפניה, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

שנו את הערך של השרת לפי הצורך כדי להצביע על הנתיב המוחלט לשרת שלכם כולל הפקודה המלאה הדרושה להרצה.

בקובץ הדוגמה שהוזכר למעלה, הערך של השרת נראה כך:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

זה מתאים להרצת פקודה כמו: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` הקלידו משהו כמו "add 3 to 20".

    אתם אמורים לראות כלי שמוצג מעל תיבת הטקסט של הצ'אט שמראה לכם לבחור להריץ את הכלי כמו בתמונה הבאה:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.he.png)

    בחירת הכלי אמורה להניב תוצאה מספרית שאומרת "23" אם ההודעה שלכם הייתה כמו שציינו קודם.

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. יש להתייחס למסמך המקורי בשפתו המקורית כמקור הסמכות. למידע קריטי מומלץ להשתמש בתרגום מקצועי אנושי. אנו לא אחראים לכל אי-הבנה או פרשנות שגויה הנובעים מהשימוש בתרגום זה.