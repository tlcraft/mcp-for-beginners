<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1197b6dbde36773e04a5ae826557fdb9",
  "translation_date": "2025-08-26T17:28:02+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "bn"
}
-->
## শুরু করা  

[![আপনার প্রথম MCP সার্ভার তৈরি করুন](../../../translated_images/04.0ea920069efd979a0b2dad51e72c1df7ead9c57b3305796068a6cee1f0dd6674.bn.png)](https://youtu.be/sNDZO9N4m9Y)

_(উপরের ছবিতে ক্লিক করে এই পাঠের ভিডিও দেখুন)_

এই অংশটি কয়েকটি পাঠ নিয়ে গঠিত:

- **1 আপনার প্রথম সার্ভার**, এই প্রথম পাঠে, আপনি শিখবেন কীভাবে আপনার প্রথম সার্ভার তৈরি করবেন এবং এটি ইন্সপেক্টর টুল দিয়ে পরীক্ষা করবেন, যা আপনার সার্ভার পরীক্ষা ও ডিবাগ করার একটি গুরুত্বপূর্ণ উপায়, [পাঠে যান](01-first-server/README.md)

- **2 ক্লায়েন্ট**, এই পাঠে, আপনি শিখবেন কীভাবে একটি ক্লায়েন্ট লিখবেন যা আপনার সার্ভারের সাথে সংযোগ স্থাপন করতে পারে, [পাঠে যান](02-client/README.md)

- **3 LLM সহ ক্লায়েন্ট**, ক্লায়েন্ট লেখার আরও ভালো উপায় হলো এতে একটি LLM যোগ করা যাতে এটি আপনার সার্ভারের সাথে "আলোচনা" করতে পারে কী করতে হবে, [পাঠে যান](03-llm-client/README.md)

- **4 Visual Studio Code-এ GitHub Copilot Agent মোডে একটি সার্ভার ব্যবহার করা**। এখানে, আমরা Visual Studio Code থেকে আমাদের MCP সার্ভার চালানোর বিষয়টি দেখব, [পাঠে যান](04-vscode/README.md)

- **5 stdio Transport Server** stdio transport বর্তমান স্পেসিফিকেশনে MCP সার্ভার-টু-ক্লায়েন্ট যোগাযোগের জন্য সুপারিশকৃত মান, যা নিরাপদ subprocess-ভিত্তিক যোগাযোগ প্রদান করে [পাঠে যান](05-stdio-server/README.md)

- **6 MCP সহ HTTP স্ট্রিমিং (Streamable HTTP)**। আধুনিক HTTP স্ট্রিমিং, প্রগ্রেস নোটিফিকেশন এবং কীভাবে Streamable HTTP ব্যবহার করে স্কেলযোগ্য, রিয়েল-টাইম MCP সার্ভার এবং ক্লায়েন্ট তৈরি করবেন তা শিখুন। [পাঠে যান](06-http-streaming/README.md)

- **7 VSCode-এর AI Toolkit ব্যবহার করা** MCP ক্লায়েন্ট এবং সার্ভার ব্যবহার ও পরীক্ষা করার জন্য [পাঠে যান](07-aitk/README.md)

- **8 পরীক্ষা করা**। এখানে আমরা বিশেষভাবে ফোকাস করব কীভাবে বিভিন্ন উপায়ে আমাদের সার্ভার এবং ক্লায়েন্ট পরীক্ষা করা যায়, [পাঠে যান](08-testing/README.md)

- **9 ডিপ্লয়মেন্ট**। এই অধ্যায়ে আমরা MCP সমাধানগুলো ডিপ্লয় করার বিভিন্ন উপায় দেখব, [পাঠে যান](09-deployment/README.md)


Model Context Protocol (MCP) একটি ওপেন প্রোটোকল যা অ্যাপ্লিকেশনগুলো কীভাবে LLM-কে কনটেক্সট প্রদান করে তা স্ট্যান্ডার্ডাইজ করে। MCP-কে AI অ্যাপ্লিকেশনের জন্য USB-C পোর্টের মতো ভাবুন - এটি AI মডেলগুলোকে বিভিন্ন ডেটা সোর্স এবং টুলের সাথে সংযোগ করার একটি স্ট্যান্ডার্ডাইজড উপায় প্রদান করে।

## শেখার লক্ষ্যসমূহ

এই পাঠ শেষে, আপনি সক্ষম হবেন:

- MCP-এর জন্য C#, Java, Python, TypeScript, এবং JavaScript-এ ডেভেলপমেন্ট এনভায়রনমেন্ট সেট আপ করতে
- কাস্টম ফিচার (রিসোর্স, প্রম্পট, এবং টুল) সহ বেসিক MCP সার্ভার তৈরি ও ডিপ্লয় করতে
- MCP সার্ভারের সাথে সংযোগ স্থাপনকারী হোস্ট অ্যাপ্লিকেশন তৈরি করতে
- MCP ইমপ্লিমেন্টেশন পরীক্ষা ও ডিবাগ করতে
- সাধারণ সেটআপ চ্যালেঞ্জ এবং তাদের সমাধান বুঝতে
- আপনার MCP ইমপ্লিমেন্টেশনগুলোকে জনপ্রিয় LLM সার্ভিসের সাথে সংযুক্ত করতে

## MCP এনভায়রনমেন্ট সেট আপ করা

MCP নিয়ে কাজ শুরু করার আগে, আপনার ডেভেলপমেন্ট এনভায়রনমেন্ট প্রস্তুত করা এবং মৌলিক ওয়ার্কফ্লো বুঝা গুরুত্বপূর্ণ। এই অংশটি MCP-এর সাথে একটি মসৃণ শুরু নিশ্চিত করার জন্য প্রাথমিক সেটআপ ধাপগুলো নিয়ে আপনাকে গাইড করবে।

### প্রাক-প্রয়োজনীয়তা

MCP ডেভেলপমেন্টে প্রবেশ করার আগে নিশ্চিত করুন যে আপনার কাছে রয়েছে:

- **ডেভেলপমেন্ট এনভায়রনমেন্ট**: আপনার পছন্দের ভাষার জন্য (C#, Java, Python, TypeScript, বা JavaScript)
- **IDE/এডিটর**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, বা যেকোনো আধুনিক কোড এডিটর
- **প্যাকেজ ম্যানেজার**: NuGet, Maven/Gradle, pip, বা npm/yarn
- **API কী**: আপনি যে AI সার্ভিসগুলো আপনার হোস্ট অ্যাপ্লিকেশনে ব্যবহার করতে চান তার জন্য

### অফিসিয়াল SDKs

পরবর্তী অধ্যায়গুলোতে আপনি Python, TypeScript, Java এবং .NET ব্যবহার করে তৈরি সমাধান দেখতে পাবেন। এখানে সমস্ত অফিসিয়ালি সমর্থিত SDKs দেওয়া হলো।

MCP বিভিন্ন ভাষার জন্য অফিসিয়াল SDKs প্রদান করে:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft-এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ করা হয়
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI-এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ করা হয়
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - অফিসিয়াল TypeScript ইমপ্লিমেন্টেশন
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - অফিসিয়াল Python ইমপ্লিমেন্টেশন
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - অফিসিয়াল Kotlin ইমপ্লিমেন্টেশন
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI-এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ করা হয়
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - অফিসিয়াল Rust ইমপ্লিমেন্টেশন

## মূল বিষয়গুলো

- MCP ডেভেলপমেন্ট এনভায়রনমেন্ট সেট আপ করা ভাষা-নির্দিষ্ট SDKs দিয়ে সহজ
- MCP সার্ভার তৈরি করতে টুল তৈরি ও স্পষ্ট স্কিমা দিয়ে রেজিস্টার করতে হয়
- MCP ক্লায়েন্টগুলো সার্ভার এবং মডেলের সাথে সংযোগ স্থাপন করে বাড়তি সক্ষমতা ব্যবহার করে
- নির্ভরযোগ্য MCP ইমপ্লিমেন্টেশনের জন্য পরীক্ষা ও ডিবাগ করা অপরিহার্য
- ডিপ্লয়মেন্ট অপশনগুলো স্থানীয় ডেভেলপমেন্ট থেকে ক্লাউড-ভিত্তিক সমাধান পর্যন্ত বিস্তৃত

## অনুশীলন

আমাদের কাছে একটি নমুনা সেট রয়েছে যা এই অংশের সমস্ত অধ্যায়ে আপনি যে অনুশীলনগুলো দেখবেন তার পরিপূরক। এছাড়াও প্রতিটি অধ্যায়ে তাদের নিজস্ব অনুশীলন এবং অ্যাসাইনমেন্ট রয়েছে।

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## অতিরিক্ত রিসোর্স

- [Model Context Protocol ব্যবহার করে Azure-এ এজেন্ট তৈরি করুন](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps দিয়ে রিমোট MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## পরবর্তী কী

পরবর্তী: [আপনার প্রথম MCP সার্ভার তৈরি করা](01-first-server/README.md)

---

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ পরিষেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসাধ্য সঠিকতা নিশ্চিত করার চেষ্টা করি, তবে অনুগ্রহ করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল ভাষায় থাকা নথিটিকে প্রামাণিক উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যা হলে আমরা দায়বদ্ধ থাকব না।