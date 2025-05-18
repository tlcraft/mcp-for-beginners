<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:15:03+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "bn"
}
-->
# এই নমুনাটি চালানো

আপনার `uv` ইনস্টল করা সুপারিশ করা হয় তবে এটি আবশ্যক নয়, [নির্দেশাবলী](https://docs.astral.sh/uv/#highlights) দেখুন

## -0- একটি ভার্চুয়াল পরিবেশ তৈরি করুন

```bash
python -m venv venv
```

## -1- ভার্চুয়াল পরিবেশ সক্রিয় করুন

```bash
venv\Scrips\activate
```

## -2- নির্ভরতা ইনস্টল করুন

```bash
pip install "mcp[cli]"
```

## -3- নমুনাটি চালান

```bash
mcp run server.py
```

## -4- নমুনাটি পরীক্ষা করুন

একটি টার্মিনালে সার্ভার চালু থাকাকালীন, অন্য একটি টার্মিনাল খুলুন এবং নিম্নলিখিত কমান্ডটি চালান:

```bash
mcp dev server.py
```

এটি একটি ওয়েব সার্ভার শুরু করা উচিত যার একটি ভিজ্যুয়াল ইন্টারফেস রয়েছে যা আপনাকে নমুনাটি পরীক্ষা করতে দেয়।

একবার সার্ভার সংযুক্ত হলে:

- টুলগুলি তালিকাভুক্ত করার চেষ্টা করুন এবং `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` এটি একটি মোড়ক।

আপনি নিম্নলিখিত কমান্ড চালিয়ে এটি সরাসরি CLI মোডে চালু করতে পারেন:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

এটি সার্ভারে উপলব্ধ সমস্ত টুল তালিকাভুক্ত করবে। আপনি নিম্নলিখিত আউটপুট দেখতে পাবেন:

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
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> সাধারণত ব্রাউজারের চেয়ে CLI মোডে ispector চালানো অনেক দ্রুত।
> ispector সম্পর্কে আরও পড়ুন [এখানে](https://github.com/modelcontextprotocol/inspector)।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ পরিষেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসাধ্য সঠিকতার জন্য চেষ্টা করি, তবে দয়া করে সচেতন থাকুন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা ভুল থাকতে পারে। এর মূল ভাষায় থাকা নথিটিকে প্রামাণিক উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে উদ্ভূত কোন ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।