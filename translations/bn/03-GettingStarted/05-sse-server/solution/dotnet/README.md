<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T05:53:59+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "bn"
}
-->
# এই স্যাম্পল চালানো

## -1- নির্ভরশীলতাগুলো ইনস্টল করুন

```bash
dotnet restore
```

## -2- স্যাম্পল রান করুন

```bash
dotnet run
```

## -3- স্যাম্পল পরীক্ষা করুন

নীচের কমান্ডটি চালানোর আগে একটি আলাদা টার্মিনাল খুলুন (সার্ভার চালু আছে কিনা নিশ্চিত করুন)।

একটি টার্মিনালে সার্ভার চলার সময়, অন্য একটি টার্মিনাল খুলুন এবং নিচের কমান্ডটি চালান:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

এটি একটি ভিজ্যুয়াল ইন্টারফেস সহ একটি ওয়েব সার্ভার শুরু করবে যা আপনাকে স্যাম্পল পরীক্ষা করতে সাহায্য করবে।

> নিশ্চিত করুন যে **SSE** ট্রান্সপোর্ট টাইপ হিসেবে নির্বাচিত আছে, এবং URL হচ্ছে `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`, আর্গুমেন্ট হিসেবে ২ এবং ৪ দিলে ফলাফল হিসেবে ৬ দেখতে পাবেন।
- resources এবং resource template এ যান এবং "greeting" কল করুন, একটি নাম টাইপ করুন, আপনি আপনার দেওয়া নাম সহ একটি শুভেচ্ছা দেখতে পাবেন।

### CLI মোডে পরীক্ষা

আপনি সরাসরি CLI মোডে নিচের কমান্ডটি চালিয়ে এটি শুরু করতে পারেন:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

এটি সার্ভারে উপলব্ধ সব টুলের তালিকা দেখাবে। আপনি নিচের আউটপুটটি দেখতে পাবেন:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

কোনো টুল চালাতে টাইপ করুন:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

আপনি নিচের আউটপুটটি দেখতে পাবেন:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> সাধারণত ব্রাউজারের থেকে CLI মোডে inspector চালানো অনেক দ্রুত হয়।
> inspector সম্পর্কে আরও পড়ুন [এখানে](https://github.com/modelcontextprotocol/inspector)।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার জন্য চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদের পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট যেকোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।