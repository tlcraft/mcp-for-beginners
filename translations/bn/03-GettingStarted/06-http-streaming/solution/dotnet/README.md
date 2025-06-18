<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:16:46+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
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

## -3- স্যাম্পল টেস্ট করুন

নীচের কমান্ড চালানোর আগে একটি আলাদা টার্মিনাল খুলুন (নিশ্চিত করুন সার্ভার এখনও চালু আছে)।

একটি টার্মিনালে সার্ভার চলার সময়, আরেকটি টার্মিনাল খুলে নিচের কমান্ডটি চালান:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

এটি একটি ভিজ্যুয়াল ইন্টারফেস সহ একটি ওয়েব সার্ভার শুরু করবে যা আপনাকে স্যাম্পলটি টেস্ট করার সুযোগ দেবে।

> নিশ্চিত করুন যে **Streamable HTTP** ট্রান্সপোর্ট টাইপ হিসেবে নির্বাচিত আছে, এবং URL হল `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, আর্গুমেন্ট হিসেবে ২ এবং ৪ দিলে ফলাফল হিসেবে ৬ দেখতে পাবেন।
- resources এবং resource template-এ যান এবং "greeting" কল করুন, একটি নাম টাইপ করুন, তাহলে আপনি আপনার দেওয়া নামসহ একটি শুভেচ্ছা দেখতে পাবেন।

### CLI মোডে টেস্ট করা

নিম্নলিখিত কমান্ডটি চালিয়ে সরাসরি CLI মোডে এটি চালাতে পারেন:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

এটি সার্ভারে উপলব্ধ সকল টুলের তালিকা দেখাবে। আপনি নিচের আউটপুট দেখতে পাবেন:

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
> সাধারণত ব্রাউজারের চেয়ে CLI মোডে inspector চালানো অনেক দ্রুত হয়।
> inspector সম্পর্কে আরও পড়ুন [এখানে](https://github.com/modelcontextprotocol/inspector)।

**বিস্তারিত বিবৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতা বজায় রাখার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা ভুল থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায় কর্তৃপক্ষের উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহার থেকে উদ্ভূত কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়বদ্ধ নই।