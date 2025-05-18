<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:07:54+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "bn"
}
-->
# এই নমুনাটি চালানো

## -1- নির্ভরশীলতা ইনস্টল করুন

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- নমুনাটি চালান

```bash
dotnet run
```

## -4- নমুনাটি পরীক্ষা করুন

একটি টার্মিনালে সার্ভার চালু থাকলে, আরেকটি টার্মিনাল খুলে নিচের কমান্ডটি চালান:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

এটি একটি ভিজ্যুয়াল ইন্টারফেস সহ একটি ওয়েব সার্ভার শুরু করবে যা আপনাকে নমুনাটি পরীক্ষা করার অনুমতি দেবে।

যখন সার্ভার সংযুক্ত থাকবে:

- টুলগুলি তালিকাভুক্ত করার চেষ্টা করুন এবং `add` চালান, ২ এবং ৪ আর্গুমেন্ট দিয়ে, আপনি ফলাফলে ৬ দেখতে পাবেন।
- রিসোর্স এবং রিসোর্স টেমপ্লেটে যান এবং "greeting" কল করুন, একটি নাম টাইপ করুন এবং আপনি আপনার প্রদত্ত নাম সহ একটি শুভেচ্ছা দেখতে পাবেন।

### CLI মোডে পরীক্ষা করা

আপনি সরাসরি CLI মোডে নিম্নলিখিত কমান্ড চালিয়ে এটি চালু করতে পারেন:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

এটি সার্ভারে উপলব্ধ সমস্ত টুল তালিকাভুক্ত করবে। আপনি নিম্নলিখিত আউটপুট দেখতে পাবেন:

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

একটি টুল আহ্বান করতে টাইপ করুন:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

আপনি নিম্নলিখিত আউটপুট দেখতে পাবেন:

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

> [!TIP]
> সাধারণত ব্রাউজারের তুলনায় CLI মোডে ইন্সপেক্টর চালানো অনেক দ্রুত হয়।
> ইন্সপেক্টর সম্পর্কে আরও পড়ুন [এখানে](https://github.com/modelcontextprotocol/inspector)।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ পরিষেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য নির্ভুলতার চেষ্টা করি, তবে দয়া করে সচেতন থাকুন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসংগতি থাকতে পারে। এর মূল ভাষায় থাকা নথিটিকে প্রামাণিক উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে উদ্ভূত কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।