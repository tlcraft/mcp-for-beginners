<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-07-13T20:09:06+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "bn"
}
-->
# এই স্যাম্পল চালানো

## -1- ডিপেন্ডেন্সিগুলো ইনস্টল করুন

```bash
dotnet restore
```

## -2- স্যাম্পল চালান

```bash
dotnet run
```

## -3- স্যাম্পল পরীক্ষা করুন

নীচের কমান্ড চালানোর আগে একটি আলাদা টার্মিনাল খুলুন (সার্ভার চালু আছে কিনা নিশ্চিত করুন)।

একটি টার্মিনালে সার্ভার চালু থাকাকালীন, আরেকটি টার্মিনাল খুলে নিচের কমান্ডটি চালান:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

এটি একটি ভিজ্যুয়াল ইন্টারফেস সহ একটি ওয়েব সার্ভার চালু করবে যা আপনাকে স্যাম্পল পরীক্ষা করার সুযোগ দেবে।

> নিশ্চিত করুন যে **SSE** ট্রান্সপোর্ট টাইপ হিসেবে নির্বাচিত আছে, এবং URL হচ্ছে `http://localhost:3001/sse`।

সার্ভার সংযুক্ত হলে:

- টুলস লিস্ট করার চেষ্টা করুন এবং `add` রান করুন, আর্গুমেন্ট হিসেবে ২ এবং ৪ দিন, ফলাফল হিসেবে ৬ দেখতে পাবেন।
- resources এবং resource template এ যান এবং "greeting" কল করুন, একটি নাম টাইপ করুন, আপনি প্রদত্ত নামসহ একটি শুভেচ্ছা দেখতে পাবেন।

### CLI মোডে পরীক্ষা

নিম্নলিখিত কমান্ড চালিয়ে সরাসরি CLI মোডে চালু করতে পারেন:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

এটি সার্ভারে উপলব্ধ সব টুলসের তালিকা দেখাবে। আপনি নিচের আউটপুট দেখতে পাবেন:

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

কোনো টুল কল করতে টাইপ করুন:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

আপনি নিচের আউটপুট দেখতে পাবেন:

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
> সাধারণত ব্রাউজারের তুলনায় CLI মোডে inspector চালানো অনেক দ্রুত হয়।
> inspector সম্পর্কে আরও পড়ুন [এখানে](https://github.com/modelcontextprotocol/inspector)।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।