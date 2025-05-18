<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:54:08+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "bn"
}
-->
# এই নমুনাটি চালানো

এই নমুনাটিতে ক্লায়েন্টে একটি LLM থাকার প্রয়োজন। LLM এর জন্য আপনাকে এটি হয় Codespaces এ চালাতে হবে অথবা GitHub এ একটি ব্যক্তিগত অ্যাক্সেস টোকেন সেট আপ করতে হবে।

## -1- নির্ভরশীলতাগুলি ইনস্টল করুন

```bash
npm install
```

## -3- সার্ভার চালান

```bash
npm run build
```

## -4- ক্লায়েন্ট চালান

```sh
npm run client
```

আপনার একটি ফলাফল দেখতে পাওয়া উচিত যা এরকম:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ পরিষেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসম্ভব সঠিক অনুবাদের চেষ্টা করি, তবে অনুগ্রহ করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। নেটিভ ভাষায় মূল নথিটিকে প্রামাণিক উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে সৃষ্ট কোন ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।