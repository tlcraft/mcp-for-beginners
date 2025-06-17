<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:31:44+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "bn"
}
-->
# স্যাম্পল চালানো

এখানে আমরা ধরে নিচ্ছি আপনার কাছে ইতিমধ্যেই একটি কাজ করা সার্ভার কোড আছে। দয়া করে আগের কোনো অধ্যায় থেকে একটি সার্ভার খুঁজে নিন।

## mcp.json সেট আপ করা

এখানে একটি ফাইল আছে যা আপনি রেফারেন্স হিসেবে ব্যবহার করতে পারেন, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)।

আপনার সার্ভারের সম্পূর্ণ পাথ এবং প্রয়োজনীয় রান কমান্ড সহ সার্ভার এন্ট্রি প্রয়োজন অনুযায়ী পরিবর্তন করুন।

উপরের উদাহরণ ফাইলে সার্ভার এন্ট্রি এরকম দেখাচ্ছে:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

এটি এমন একটি কমান্ড চালানোর সাথে সামঞ্জস্যপূর্ণ: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` যেখানে আপনি "add 3 to 20" এর মতো কিছু টাইপ করবেন।

    আপনি চ্যাট টেক্সট বক্সের উপরে একটি টুল প্রদর্শিত হতে দেখবেন যা আপনাকে টুলটি চালানোর জন্য নির্বাচন করতে বলবে, নিচের ভিজ্যুয়ালের মতো:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.bn.png)

    টুলটি নির্বাচন করলে একটি সংখ্যাসূচক ফলাফল আসবে যা "23" বলবে, যদি আপনার প্রম্পট আগের মতোই হয়।

**দ্রষ্টব্য**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা ভুল থাকতে পারে তা অনুগ্রহ করে বুঝবেন। মূল নথিটি তার নিজ ভাষায়ই প্রামাণিক উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদের পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ব্যাখ্যায় আমরা দায়বদ্ধ নই।