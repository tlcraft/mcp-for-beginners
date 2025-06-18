<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T05:53:54+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "bn"
}
-->
# এই নমুনাটি চালানো

## -1- নির্ভরশীলতাগুলো ইনস্টল করুন

```bash
dotnet restore
```

## -3- নমুনাটি চালান


```bash
dotnet run
```

## -4- নমুনাটি পরীক্ষা করুন

একটি টার্মিনালে সার্ভার চলতে থাকা অবস্থায়, আরেকটি টার্মিনাল খুলুন এবং নিচের কমান্ডটি চালান:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

এটি একটি ওয়েব সার্ভার শুরু করবে যার ভিজ্যুয়াল ইন্টারফেস থাকবে যা আপনাকে নমুনাটি পরীক্ষা করার সুযোগ দেবে।

সার্ভার কানেক্ট হওয়ার পর:

- টুলগুলোর তালিকা দেখুন এবং `add` চালান, আর্গুমেন্ট হিসেবে ২ এবং ৪ দিন, ফলাফল হিসেবে ৬ দেখতে পাবেন।
- resources এবং resource template-এ যান এবং "greeting" কল করুন, একটি নাম টাইপ করুন এবং আপনি আপনার দেওয়া নামসহ একটি শুভেচ্ছা দেখতে পাবেন।

### CLI মোডে পরীক্ষা করা

নিচের কমান্ডটি চালিয়ে সরাসরি CLI মোডে এটি চালাতে পারেন:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

এটি সার্ভারে উপলব্ধ সব টুলের তালিকা দেখাবে। আপনি নিচের আউটপুট দেখতে পাবেন:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

একটি টুল কল করতে টাইপ করুন:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

আপনি নিচের আউটপুট দেখতে পাবেন:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> সাধারণত ব্রাউজারের চেয়ে CLI মোডে inspector চালানো অনেক দ্রুত হয়।
> inspector সম্পর্কে আরও পড়ুন [এখানে](https://github.com/modelcontextprotocol/inspector)।

**দায়বদ্ধতা থেকে অব্যাহতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার জন্য চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ভুল বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায় সর্বাধিক বিশ্বাসযোগ্য উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদের পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।