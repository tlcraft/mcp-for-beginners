<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c40c54fa74ded9c223bc0ebfc8a2de7c",
  "translation_date": "2025-06-18T05:48:15+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "ar"
}
-->
# تشغيل هذا المثال

> [!NOTE]
> يفترض هذا المثال أنك تستخدم بيئة GitHub Codespaces. إذا أردت تشغيله محليًا، عليك إعداد رمز وصول شخصي (PAT) على GitHub.
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

## تثبيت المكتبات

```sh
dotnet restore
```

يجب تثبيت المكتبات التالية: Azure AI Inference، Azure Identity، Microsoft.Extension، Model.Hosting، ModelContextProtcol

## التشغيل

```sh 
dotnet run
```

يجب أن ترى ناتجًا مشابهًا لـ:

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

الكثير من الناتج هو فقط لتصحيح الأخطاء، لكن المهم هو أنك تقوم بسرد الأدوات من MCP Server، وتحولها إلى أدوات LLM وتنتهي برد عميل MCP "Sum 6".

**تنويه**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى للدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الحساسة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسيرات خاطئة ناتجة عن استخدام هذه الترجمة.