<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:54:23+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "bn"
}
-->
# এই নমুনাটি চালানো

## -1- নির্ভরতা ইনস্টল করুন

```bash
dotnet run
```

## -2- নমুনাটি চালান

```bash
dotnet run
```

## -3- নমুনাটি পরীক্ষা করুন

নীচেরটি চালানোর আগে একটি পৃথক টার্মিনাল শুরু করুন (নিশ্চিত করুন যে সার্ভারটি এখনও চলছে)।

একটি টার্মিনালে সার্ভার চালু রেখে, আরেকটি টার্মিনাল খুলুন এবং নিম্নলিখিত কমান্ডটি চালান:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

এটি একটি ভিজ্যুয়াল ইন্টারফেস সহ একটি ওয়েব সার্ভার শুরু করবে যা আপনাকে নমুনাটি পরীক্ষা করার অনুমতি দেবে।

যখন সার্ভার সংযুক্ত হয়:

- টুলগুলি তালিকাভুক্ত করার চেষ্টা করুন এবং `add` চালান, আর্গুমেন্ট ২ এবং ৪ সহ, আপনি ফলাফলে ৬ দেখতে পাবেন।
- রিসোর্স এবং রিসোর্স টেমপ্লেটে যান এবং "greeting" কল করুন, একটি নাম টাইপ করুন এবং আপনি আপনার দেওয়া নাম সহ একটি অভিবাদন দেখতে পাবেন।

### CLI মোডে পরীক্ষা করা

নিম্নলিখিত কমান্ডটি চালিয়ে আপনি সরাসরি CLI মোডে এটি চালু করতে পারেন:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

এটি সার্ভারে উপলব্ধ সমস্ত টুল তালিকাভুক্ত করবে। আপনি নিম্নলিখিত আউটপুট দেখতে পাবেন:

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

একটি টুল আহ্বান করতে টাইপ করুন:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

আপনি নিম্নলিখিত আউটপুট দেখতে পাবেন:

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
> সাধারণত ব্রাউজারে তুলনায় CLI মোডে ইনস্পেক্টর চালানো অনেক দ্রুত হয়।
> ইনস্পেক্টর সম্পর্কে আরও পড়ুন [এখানে](https://github.com/modelcontextprotocol/inspector)।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ পরিষেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে অনুগ্রহ করে সচেতন থাকুন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসংগতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায় কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।