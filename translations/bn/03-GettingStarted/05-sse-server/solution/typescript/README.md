<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:08:30+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "bn"
}
-->
# এই নমুনা চালানো

## -1- নির্ভরশীলতা ইনস্টল করুন

```bash
npm install
```

## -3- নমুনা চালান

```bash
npm run build
```

## -4- নমুনা পরীক্ষা করুন

একটি টার্মিনালে সার্ভার চালু থাকলে, অন্য একটি টার্মিনাল খুলুন এবং নিম্নলিখিত কমান্ড চালান:

```bash
npm run inspector
```

এটি একটি ভিজ্যুয়াল ইন্টারফেস সহ একটি ওয়েব সার্ভার শুরু করবে যা আপনাকে নমুনা পরীক্ষা করতে সহায়তা করবে।

একবার সার্ভার সংযুক্ত হলে:

- টুল তালিকা করার চেষ্টা করুন এবং `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build` চালান।

- একটি পৃথক টার্মিনালে নিম্নলিখিত কমান্ড চালান:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
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

- একটি টুল টাইপ আহ্বান করুন নিম্নলিখিত কমান্ড টাইপ করে:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

আপনি নিম্নলিখিত আউটপুট দেখতে পাবেন:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> সাধারণত CLI মোডে ইন্সপেক্টর চালানো ব্রাউজারের চেয়ে অনেক দ্রুত হয়।
> ইন্সপেক্টর সম্পর্কে আরও পড়ুন [এখানে](https://github.com/modelcontextprotocol/inspector)।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসাধ্য সঠিকতা বজায় রাখার চেষ্টা করি, তবে অনুগ্রহ করে সচেতন থাকুন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল ভাষায় থাকা নথিটি কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদের ব্যবহার থেকে উদ্ভূত কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী থাকব না।