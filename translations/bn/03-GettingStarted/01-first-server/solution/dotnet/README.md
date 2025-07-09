<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "07863f50601f395c3bdfce30f555f11a",
  "translation_date": "2025-07-09T21:57:49+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "bn"
}
-->
# এই স্যাম্পল চালানো

## -1- ডিপেন্ডেন্সিগুলো ইনস্টল করুন

```bash
dotnet restore
```

## -3- স্যাম্পল চালান

```bash
dotnet run
```

## -4- স্যাম্পল পরীক্ষা করুন

একটি টার্মিনালে সার্ভার চালু থাকাকালীন, আরেকটি টার্মিনাল খুলে নিচের কমান্ডটি চালান:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

এটি একটি ভিজ্যুয়াল ইন্টারফেসসহ ওয়েব সার্ভার চালু করবে যা আপনাকে স্যাম্পল পরীক্ষা করার সুযোগ দেবে।

সার্ভার সংযুক্ত হলে:

- টুলগুলো তালিকাভুক্ত করে দেখুন এবং `add` রান করুন, আর্গুমেন্ট হিসেবে ২ এবং ৪ দিন, ফলাফল হিসেবে ৬ দেখতে পাবেন।
- resources এবং resource template-এ যান এবং "greeting" কল করুন, একটি নাম টাইপ করুন, আপনি প্রদত্ত নামসহ একটি শুভেচ্ছা দেখতে পাবেন।

### CLI মোডে পরীক্ষা

নিম্নলিখিত কমান্ড চালিয়ে সরাসরি CLI মোডে চালু করতে পারেন:

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

কোনো টুল চালাতে টাইপ করুন:

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
> সাধারণত ব্রাউজারের তুলনায় CLI মোডে inspector চালানো অনেক দ্রুত হয়।
> inspector সম্পর্কে আরও পড়ুন [এখানে](https://github.com/modelcontextprotocol/inspector)।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।