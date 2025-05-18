<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:22:08+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "bn"
}
-->
# এই নমুনা চালানো

আপনার `uv` ইনস্টল করা সুপারিশ করা হচ্ছে তবে এটি আবশ্যক নয়, দেখুন [নির্দেশনা](https://docs.astral.sh/uv/#highlights)

## -1- নির্ভরতাগুলি ইনস্টল করুন

```bash
npm install
```

## -3- নমুনা চালান

```bash
npm run build
```

## -4- নমুনা পরীক্ষা করুন

একটি টার্মিনালে সার্ভার চলমান অবস্থায়, অন্য একটি টার্মিনাল খুলুন এবং নিম্নলিখিত কমান্ড চালান:

```bash
npm run inspector
```

এটি একটি ভিজ্যুয়াল ইন্টারফেস সহ একটি ওয়েব সার্ভার শুরু করবে যা আপনাকে নমুনাটি পরীক্ষা করতে দেবে।

একবার সার্ভার সংযুক্ত হলে:

- টুলগুলি তালিকাভুক্ত করার চেষ্টা করুন এবং `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` এটি একটি মোড়ক। 

আপনি CLI মোডে সরাসরি নিম্নলিখিত কমান্ড চালিয়ে এটি চালু করতে পারেন:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

এটি সার্ভারে উপলব্ধ সমস্ত টুলের তালিকা দেবে। আপনি নিম্নলিখিত আউটপুটটি দেখতে পাবেন:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

একটি টুল আহ্বান করতে টাইপ করুন:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

আপনি নিম্নলিখিত আউটপুটটি দেখতে পাবেন:

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
> সাধারণত ব্রাউজারের তুলনায় CLI মোডে ইন্সপেক্টর চালানো অনেক দ্রুত হয়।
> ইন্সপেক্টর সম্পর্কে আরও পড়ুন [এখানে](https://github.com/modelcontextprotocol/inspector)।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসাধ্য সঠিকতা বজায় রাখার চেষ্টা করি, তবে অনুগ্রহ করে সচেতন থাকুন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসংগতি থাকতে পারে। মূল ভাষায় থাকা নথিটিকেই প্রামাণিক উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।