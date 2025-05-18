<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:39:49+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "bn"
}
-->
# এই নমুনা চালান

> [!NOTE]
> এই নমুনাটি ধরে নিচ্ছে যে আপনি একটি GitHub Codespaces ইনস্ট্যান্স ব্যবহার করছেন। যদি আপনি এটি স্থানীয়ভাবে চালাতে চান, তাহলে আপনাকে GitHub এ একটি ব্যক্তিগত অ্যাক্সেস টোকেন সেট আপ করতে হবে।

## লাইব্রেরি ইনস্টল করুন

```sh
dotnet restore
```

নিম্নলিখিত লাইব্রেরিগুলি ইনস্টল করা উচিত: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## চালান

```sh 
dotnet run
```

আপনার আউটপুট এরকম কিছু দেখতে পাওয়া উচিত:

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

অনেক আউটপুট শুধুমাত্র ডিবাগিং, কিন্তু গুরুত্বপূর্ণ হলো আপনি MCP সার্ভার থেকে টুলগুলির তালিকা তৈরি করছেন, সেগুলোকে LLM টুলে পরিণত করছেন এবং আপনি একটি MCP ক্লায়েন্ট প্রতিক্রিয়া "Sum 6" পাচ্ছেন।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ পরিষেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসম্ভব সঠিক অনুবাদের চেষ্টা করি, তবে অনুগ্রহ করে সচেতন থাকুন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসংগতি থাকতে পারে। এর মূল ভাষায় থাকা নথিটিকে প্রামাণিক সূত্র হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।