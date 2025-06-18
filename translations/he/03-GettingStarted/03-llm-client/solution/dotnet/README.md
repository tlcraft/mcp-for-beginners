<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c40c54fa74ded9c223bc0ebfc8a2de7c",
  "translation_date": "2025-06-18T06:03:36+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "he"
}
-->
# הפעל את הדוגמה הזו

> [!NOTE]
> דוגמה זו מניחה שאתם משתמשים במופע GitHub Codespaces. אם ברצונכם להריץ זאת מקומית, עליכם להגדיר אסימון גישה אישי (PAT) ב-GitHub.
>
> ```bash
> # zsh/bash
> export GITHUB_TOKEN="{{YOUR_GITHUB_PAT}}"
> ```
>
> ```powershell
> # PowerShell
> $env:GITHUB_TOKEN = "{{YOUR_GITHUB_PAT}}"
> ```

## התקנת ספריות

```sh
dotnet restore
```

יש להתקין את הספריות הבאות: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## הפעלה

```sh 
dotnet run
```

עליכם לראות פלט דומה ל:

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

רוב הפלט הוא לצורך ניפוי שגיאות, אבל מה שחשוב הוא שאתם מציגים כלים משרת MCP, הופכים אותם לכלי LLM ובסוף מקבלים תגובת לקוח MCP "Sum 6".

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להיעזר בתרגום מקצועי אנושי. אנו לא נושאים באחריות לכל אי הבנה או פרשנות שגויה הנובעים משימוש בתרגום זה.