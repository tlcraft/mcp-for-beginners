<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:42:34+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "he"
}
-->
# הפעל את הדוגמה הזו

> [!NOTE]
> דוגמה זו מניחה שאתה משתמש במופע של GitHub Codespaces. אם ברצונך להפעיל זאת באופן מקומי, עליך להגדיר אסימון גישה אישי ב-GitHub.

## התקנת ספריות

```sh
dotnet restore
```

יש להתקין את הספריות הבאות: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## הפעלה

```sh 
dotnet run
```

עליך לראות פלט דומה ל:

```text
Setting up stdio transport
Listing tools
Connected to server with tools: Add
Tool description: Adds two numbers
Tool parameters: {"title":"Add","description":"Adds two numbers","type":"object","properties":{"a":{"type":"integer"},"b":{"type":"integer"}},"required":["a","b"]}
Tool definition: Azure.AI.Inference.ChatCompletionsToolDefinition
Properties: {"a":{"type":"integer"},"b":{"type":"integer"}}
MCP Tools def: 0: Azure.AI.Inference.ChatCompletionsToolDefinition
Tool call 0: Add with arguments {"a":2,"b":4}
Sum 6
```

חלק גדול מהפלט הוא רק ניפוי באגים, אבל מה שחשוב הוא שאתה מציג כלים משרת MCP, הופך אותם לכלי LLM ומסיים עם תגובת לקוח MCP "Sum 6".

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). בעוד שאנו שואפים לדיוק, אנא היו מודעים לכך שתרגומים אוטומטיים עשויים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור סמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום מקצועי על ידי בני אדם. אנו לא נושאים באחריות לכל אי הבנה או פירוש שגוי הנובע מהשימוש בתרגום זה.