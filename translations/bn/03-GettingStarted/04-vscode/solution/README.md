<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:19:32+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "bn"
}
-->
# নমুনা চালানো

এখানে আমরা ধরে নিচ্ছি যে আপনার কাছে ইতিমধ্যেই একটি কার্যকরী সার্ভার কোড রয়েছে। দয়া করে আগের অধ্যায়গুলোর মধ্যে থেকে একটি সার্ভার খুঁজে বের করুন।

## mcp.json সেট আপ করুন

এখানে একটি ফাইল রয়েছে যা আপনি রেফারেন্স হিসেবে ব্যবহার করতে পারেন, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)।

প্রয়োজন অনুযায়ী সার্ভার এন্ট্রি পরিবর্তন করুন যাতে আপনার সার্ভারের সম্পূর্ণ পথ এবং চালানোর জন্য প্রয়োজনীয় পূর্ণাঙ্গ কমান্ড উল্লেখ থাকে।

উপরের উল্লেখিত উদাহরণ ফাইলে সার্ভার এন্ট্রি এমন দেখায়:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

এটি এমন একটি কমান্ড চালানোর সাথে সঙ্গতিপূর্ণ: `cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` কিছু এরকম টাইপ করুন "add 3 to 20"।

    আপনি চ্যাট টেক্সট বক্সের উপরে একটি টুল প্রদর্শিত হতে দেখবেন যা আপনাকে টুলটি চালানোর জন্য নির্বাচন করতে বলছে, যেমন এই ভিজ্যুয়ালে দেখানো হয়েছে:

    ![VS Code এটি একটি টুল চালাতে চাচ্ছে তা নির্দেশ করছে](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.bn.png)

    টুলটি নির্বাচন করলে একটি সংখ্যাগত ফলাফল "23" প্রদর্শিত হবে যদি আপনার প্রম্পটটি আমরা পূর্বে উল্লেখ করেছি এমন হয়।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসাধ্য সঠিকতার জন্য চেষ্টা করি, তবে দয়া করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। নথির মূল ভাষায় লেখা সংস্করণটিকে প্রামাণিক উৎস হিসাবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে কোন ভুল বোঝাবুঝি বা ভুল ব্যাখ্যা হলে আমরা দায়ী থাকব না।