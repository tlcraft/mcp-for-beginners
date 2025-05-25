<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:38:29+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "ar"
}
-->
# تشغيل هذا النموذج

> [!NOTE]
> يفترض هذا النموذج أنك تستخدم مثيل GitHub Codespaces. إذا كنت ترغب في تشغيله محليًا، تحتاج إلى إعداد رمز وصول شخصي على GitHub.

## تثبيت المكتبات

```sh
dotnet restore
```

يجب تثبيت المكتبات التالية: Azure AI Inference، Azure Identity، Microsoft.Extension، Model.Hosting، ModelContextProtcol

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

الكثير من المخرجات هي مجرد تصحيح الأخطاء، ولكن المهم هو أنك تقوم بإدراج أدوات من خادم MCP، تحويل تلك إلى أدوات LLM وتنتهي باستجابة عميل MCP "Sum 6".

**إخلاء المسؤولية**:  
تمت ترجمة هذه الوثيقة باستخدام خدمة الترجمة بالذكاء الاصطناعي [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار الوثيقة الأصلية بلغتها الأصلية المصدر الموثوق. للحصول على معلومات حاسمة، يُوصى بالترجمة البشرية الاحترافية. نحن غير مسؤولين عن أي سوء فهم أو تفسيرات خاطئة تنشأ عن استخدام هذه الترجمة.