<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0bc7bd48f55f1565f1d95ccb2c16f728",
  "translation_date": "2025-06-18T07:48:29+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/README.md",
  "language_code": "bn"
}
-->
# নমুনা

পূর্বের উদাহরণটি দেখায় কিভাবে একটি লোকাল .NET প্রকল্প `stdio` টাইপের সাথে ব্যবহার করা যায়। এবং কিভাবে একটি কন্টেইনারে লোকালি সার্ভার চালানো যায়। এটি অনেক পরিস্থিতিতে একটি ভালো সমাধান। তবে, সার্ভারটি রিমোটলি, যেমন ক্লাউড পরিবেশে চালানো উপকারী হতে পারে। এখানেই `http` টাইপ কাজে আসে।

`04-PracticalImplementation` ফোল্ডারের সমাধানটি দেখলে এটি আগেরটির চেয়ে অনেক বেশি জটিল মনে হতে পারে। কিন্তু বাস্তবে তা নয়। যদি আপনি প্রকল্প `src/Calculator` ভালভাবে দেখেন, তাহলে দেখতে পাবেন এটি মূলত আগের উদাহরণের মতোই কোড। একমাত্র পার্থক্য হলো আমরা HTTP অনুরোধগুলি পরিচালনার জন্য একটি ভিন্ন লাইব্রেরি `ModelContextProtocol.AspNetCore` ব্যবহার করছি। এবং আমরা মেথড `IsPrime` কে প্রাইভেট করে দিয়েছি, শুধু দেখানোর জন্য যে আপনার কোডে প্রাইভেট মেথড থাকতে পারে। বাকি কোড আগের মতোই আছে।

অন্যান্য প্রকল্পগুলি [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/aspire-overview) থেকে এসেছে। সমাধানে .NET Aspire থাকার ফলে ডেভেলপারদের জন্য উন্নত অভিজ্ঞতা তৈরি হয় ডেভেলপমেন্ট এবং টেস্টিং এর সময় এবং এটি অবজারভেবিলিটিতেও সাহায্য করে। সার্ভার চালানোর জন্য এটি বাধ্যতামূলক নয়, তবে আপনার সমাধানে এটি থাকা একটি ভালো অভ্যাস।

## লোকালি সার্ভার শুরু করুন

1. VS Code থেকে (C# DevKit এক্সটেনশন সহ), `04-PracticalImplementation/samples/csharp` ডিরেক্টরিতে যান।
1. সার্ভার শুরু করতে নিচের কমান্ডটি চালান:

   ```bash
    dotnet watch run --project ./src/AppHost
   ```

1. যখন একটি ওয়েব ব্রাউজার .NET Aspire ড্যাশবোর্ড খুলবে, তখন `http` URL লক্ষ্য করুন। এটি কিছুটা এরকম হওয়া উচিত `http://localhost:5058/`।

   ![.NET Aspire Dashboard](../../../../../translated_images/dotnet-aspire-dashboard.0a7095710e9301e90df2efd867e1b675b3b9bc2ccd7feb1ebddc0751522bc37c.bn.png)

## MCP Inspector দিয়ে Streamable HTTP পরীক্ষা করুন

আপনার কাছে যদি Node.js 22.7.5 বা তার উপরে থাকে, তাহলে MCP Inspector ব্যবহার করে আপনার সার্ভার পরীক্ষা করতে পারেন।

সার্ভার চালু করুন এবং একটি টার্মিনালে নিচের কমান্ডটি চালান:

```bash
npx @modelcontextprotocol/inspector http://localhost:5058
```

![MCP Inspector](../../../../../translated_images/mcp-inspector.c223422b9b494fb4a518a3b3911b3e708e6a5715069470f9163ee2ee8d5f1ba9.bn.png)

- `Streamable HTTP` as the Transport type.
- In the Url field, enter the URL of the server noted earlier, and append `/mcp` নির্বাচন করুন। এটি হওয়া উচিত `http` (না `https`) something like `http://localhost:5058/mcp`.
- select the Connect button.

A nice thing about the Inspector is that it provide a nice visibility on what is happening.

- Try listing the available tools
- Try some of them, it should works just like before.

## Test MCP Server with GitHub Copilot Chat in VS Code

To use the Streamable HTTP transport with GitHub Copilot Chat, change the configuration of the `calc-mcp` সার্ভারটি পূর্বে তৈরি করা হয়েছে যাতে এরকম দেখায়:

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "http://localhost:5058/mcp"
    }
  }
}
```

কিছু পরীক্ষা করুন:

- "6780 এর পরের 3টি মৌলিক সংখ্যা" জিজ্ঞাসা করুন। লক্ষ্য করুন কিভাবে Copilot নতুন টুলস `NextFivePrimeNumbers` ব্যবহার করে এবং শুধুমাত্র প্রথম 3টি মৌলিক সংখ্যা ফেরত দেয়।
- "111 এর পরের 7টি মৌলিক সংখ্যা" জিজ্ঞাসা করুন, দেখতে কি হয়।
- "জনের কাছে ২৪টি ললি আছে এবং সে তা তার ৩টি সন্তানের মাঝে ভাগ করতে চায়। প্রতিটি সন্তানের কতটি ললি থাকবে?" জিজ্ঞাসা করুন, দেখতে কি হয়।

## সার্ভারটি Azure-এ ডিপ্লয় করুন

চলুন সার্ভারটি Azure-এ ডিপ্লয় করি যাতে আরও বেশি মানুষ এটি ব্যবহার করতে পারে।

একটি টার্মিনাল থেকে `04-PracticalImplementation/samples/csharp` ফোল্ডারে যান এবং নিচের কমান্ডটি চালান:

```bash
azd up
```

ডিপ্লয়মেন্ট শেষ হলে, আপনাকে এরকম একটি মেসেজ দেখা উচিত:

![Azd deployment success](../../../../../translated_images/azd-deployment-success.bd42940493f1b834a5ce6251a6f88966546009b350df59d0cc4a8caabe94a4f1.bn.png)

URLটি নিন এবং MCP Inspector এবং GitHub Copilot Chat-এ ব্যবহার করুন।

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "https://calc-mcp.gentleriver-3977fbcf.australiaeast.azurecontainerapps.io/mcp"
    }
  }
}
```

## পরবর্তীতে কী?

আমরা বিভিন্ন ট্রান্সপোর্ট টাইপ এবং টেস্টিং টুলস চেষ্টা করেছি। আমরা আপনার MCP সার্ভার Azure-এ ডিপ্লয় করেছি। কিন্তু যদি আমাদের সার্ভারকে প্রাইভেট রিসোর্সে অ্যাক্সেস করতে হয়? যেমন, একটি ডাটাবেস বা প্রাইভেট API? পরবর্তী অধ্যায়ে আমরা দেখব কিভাবে আমাদের সার্ভারের নিরাপত্তা উন্নত করা যায়।

**বৈধতা বর্ণনা**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার জন্য চেষ্টা করি, তবে দয়া করে লক্ষ্য করুন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই প্রামাণিক উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহার থেকে উদ্ভূত কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়বদ্ধ নই।