<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:39:13+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "mo"
}
-->
# تشغيل هذا النموذج

> [!NOTE]
> يفترض هذا النموذج أنك تستخدم مثيل GitHub Codespaces. إذا كنت ترغب في تشغيله محليًا، تحتاج إلى إعداد رمز وصول شخصي على GitHub.

## تثبيت المكتبات

```sh
dotnet restore
```

يجب تثبيت المكتبات التالية: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## التشغيل

```sh 
dotnet run
```

يجب أن ترى مخرجات مشابهة لـ:

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

الكثير من المخرجات هي مجرد تصحيح أخطاء، ولكن المهم هو أنك تسرد الأدوات من خادم MCP، تحولها إلى أدوات LLM وتنتهي باستجابة عميل MCP "Sum 6".

Certainly! However, it seems like there might be a typo in your request, as "mo" isn't a recognized language code. If you meant "Māori," I can provide a translation into Māori. Please confirm or clarify the language you need.