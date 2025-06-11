<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:04:53+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "bn"
}
-->
## শুরু করা  

এই অংশে কয়েকটি পাঠ রয়েছে:

- **1 আপনার প্রথম সার্ভার**, এই প্রথম পাঠে আপনি শিখবেন কীভাবে আপনার প্রথম সার্ভার তৈরি করতে হয় এবং ইন্সপেক্টর টুল দিয়ে সেটি পরীক্ষা করতে হয়, যা আপনার সার্ভার টেস্ট ও ডিবাগ করার জন্য একটি গুরুত্বপূর্ণ উপায়, [পাঠে যান](/03-GettingStarted/01-first-server/README.md)

- **2 ক্লায়েন্ট**, এই পাঠে আপনি শিখবেন কীভাবে একটি ক্লায়েন্ট লিখতে হয় যা আপনার সার্ভারের সাথে সংযুক্ত হতে পারে, [পাঠে যান](/03-GettingStarted/02-client/README.md)

- **3 LLM সহ ক্লায়েন্ট**, ক্লায়েন্ট লেখার আরও উন্নত উপায় হলো এতে একটি LLM যোগ করা যাতে এটি আপনার সার্ভারের সাথে "আলোচনা" করতে পারে যে কী করতে হবে, [পাঠে যান](/03-GettingStarted/03-llm-client/README.md)

- **4 Visual Studio Code-এ GitHub Copilot Agent মোডে সার্ভার ব্যবহার করা**। এখানে আমরা Visual Studio Code থেকে আমাদের MCP সার্ভার চালানোর বিষয়টি দেখছি, [পাঠে যান](/03-GettingStarted/04-vscode/README.md)

- **5 SSE (Server Sent Events) থেকে ব্যবহার করা** SSE হলো সার্ভার থেকে ক্লায়েন্টে স্ট্রিমিংয়ের একটি স্ট্যান্ডার্ড, যা সার্ভারকে HTTP এর মাধ্যমে রিয়েল-টাইম আপডেট ক্লায়েন্টকে পাঠানোর সুযোগ দেয় [পাঠে যান](/03-GettingStarted/05-sse-server/README.md)

- **6 VSCode-এর জন্য AI Toolkit ব্যবহার করা** যাতে আপনি আপনার MCP ক্লায়েন্ট ও সার্ভার ব্যবহার এবং পরীক্ষা করতে পারেন [পাঠে যান](/03-GettingStarted/06-aitk/README.md)

- **7 টেস্টিং**। এখানে আমরা বিশেষ করে শিখব কীভাবে বিভিন্ন উপায়ে আমাদের সার্ভার ও ক্লায়েন্ট পরীক্ষা করা যায়, [পাঠে যান](/03-GettingStarted/07-testing/README.md)

- **8 ডিপ্লয়মেন্ট**। এই অধ্যায়ে আমরা MCP সমাধান ডিপ্লয় করার বিভিন্ন উপায় দেখব, [পাঠে যান](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) একটি ওপেন প্রোটোকল যা অ্যাপ্লিকেশনগুলোকে LLM-কে প্রসঙ্গ প্রদান করার জন্য স্ট্যান্ডার্ডাইজ করে। MCP কে ভাবুন AI অ্যাপ্লিকেশনের জন্য একটি USB-C পোর্টের মতো — এটি AI মডেলগুলোকে বিভিন্ন ডেটা উৎস এবং টুলের সাথে সংযুক্ত করার জন্য একটি স্ট্যান্ডার্ড উপায় দেয়।

## শেখার লক্ষ্যসমূহ

এই পাঠের শেষে আপনি সক্ষম হবেন:

- C#, Java, Python, TypeScript, এবং JavaScript-এ MCP এর জন্য ডেভেলপমেন্ট এনভায়রনমেন্ট সেটআপ করতে
- কাস্টম ফিচার (resources, prompts, এবং tools) সহ বেসিক MCP সার্ভার তৈরি ও ডিপ্লয় করতে
- MCP সার্ভারের সাথে সংযুক্ত হোস্ট অ্যাপ্লিকেশন তৈরি করতে
- MCP ইমপ্লিমেন্টেশন টেস্ট ও ডিবাগ করতে
- সাধারণ সেটআপ সমস্যা এবং তাদের সমাধান বুঝতে
- আপনার MCP ইমপ্লিমেন্টেশনগুলো জনপ্রিয় LLM সার্ভিসের সাথে সংযুক্ত করতে

## আপনার MCP এনভায়রনমেন্ট সেটআপ করা

MCP নিয়ে কাজ শুরু করার আগে, আপনার ডেভেলপমেন্ট এনভায়রনমেন্ট প্রস্তুত করা এবং মৌলিক ওয়ার্কফ্লো বুঝে নেওয়া গুরুত্বপূর্ণ। এই অংশটি আপনাকে MCP-এর সাথে সহজে শুরু করার জন্য প্রাথমিক সেটআপ ধাপগুলো নির্দেশ করবে।

### প্রাথমিক শর্তাবলী

MCP ডেভেলপমেন্টে প্রবেশ করার আগে নিশ্চিত করুন আপনার কাছে আছে:

- **ডেভেলপমেন্ট এনভায়রনমেন্ট**: আপনার নির্বাচিত ভাষার জন্য (C#, Java, Python, TypeScript, বা JavaScript)
- **IDE/এডিটর**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, অথবা যেকোন আধুনিক কোড এডিটর
- **প্যাকেজ ম্যানেজার**: NuGet, Maven/Gradle, pip, অথবা npm/yarn
- **API কী**: যেকোন AI সার্ভিস ব্যবহারের জন্য যা আপনি হোস্ট অ্যাপ্লিকেশনে ব্যবহার করবেন

### অফিসিয়াল SDKs

আগামী অধ্যায়গুলোতে আপনি Python, TypeScript, Java এবং .NET ব্যবহার করে তৈরি সমাধান দেখতে পাবেন। এখানে সব অফিসিয়ালি সমর্থিত SDKs দেওয়া হলো।

MCP বিভিন্ন ভাষার জন্য অফিসিয়াল SDK সরবরাহ করে:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ করা হয়
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ করা হয়
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - অফিসিয়াল TypeScript ইমপ্লিমেন্টেশন
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - অফিসিয়াল Python ইমপ্লিমেন্টেশন
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - অফিসিয়াল Kotlin ইমপ্লিমেন্টেশন
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ করা হয়
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - অফিসিয়াল Rust ইমপ্লিমেন্টেশন

## মূল বিষয়সমূহ

- MCP ডেভেলপমেন্ট এনভায়রনমেন্ট সেটআপ ভাষা-নির্দিষ্ট SDK দিয়ে সহজ
- MCP সার্ভার তৈরি করার সময় স্পষ্ট স্কিমাসহ টুল তৈরি ও রেজিস্টার করতে হয়
- MCP ক্লায়েন্ট সার্ভার ও মডেলের সাথে সংযুক্ত হয়ে বর্ধিত ক্ষমতা ব্যবহার করে
- টেস্টিং ও ডিবাগিং MCP ইমপ্লিমেন্টেশনের নির্ভরযোগ্যতার জন্য অপরিহার্য
- ডিপ্লয়মেন্ট অপশনগুলো লোকাল ডেভেলপমেন্ট থেকে ক্লাউডভিত্তিক সমাধান পর্যন্ত বিস্তৃত

## অনুশীলন

আমাদের কাছে এমন কিছু স্যাম্পল রয়েছে যা এই অংশের সব অধ্যায়ে দেখানো অনুশীলনগুলোকে সম্পূরক করে। অতিরিক্তভাবে প্রতিটি অধ্যায়ে তাদের নিজস্ব অনুশীলন ও অ্যাসাইনমেন্টও রয়েছে।

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## অতিরিক্ত সম্পদ

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## পরবর্তী পদক্ষেপ

পরবর্তী: [আপনার প্রথম MCP সার্ভার তৈরি করা](/03-GettingStarted/01-first-server/README.md)

**অস্বীকারোক্তি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে দয়া করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই সর্বোত্তম এবং নির্ভরযোগ্য উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহার থেকে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।