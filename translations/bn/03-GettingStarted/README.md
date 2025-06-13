<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T23:16:07+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "bn"
}
-->
## শুরু করা  

এই অংশে কয়েকটি পাঠ রয়েছে:

- **1 Your first server**, এই প্রথম পাঠে, আপনি শিখবেন কীভাবে আপনার প্রথম সার্ভার তৈরি করতে হয় এবং inspector টুল দিয়ে সেটি পরীক্ষা করতে হয়, যা আপনার সার্ভার টেস্ট ও ডিবাগ করার জন্য খুবই কার্যকরী, [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, এই পাঠে, আপনি শিখবেন কীভাবে একটি ক্লায়েন্ট লিখতে হয় যা আপনার সার্ভারের সাথে সংযোগ করতে পারে, [to the lesson](/03-GettingStarted/02-client/README.md)

- **3 Client with LLM**, ক্লায়েন্ট লেখার আরও উন্নত একটি উপায় হলো এতে একটি LLM যোগ করা যাতে এটি আপনার সার্ভারের সাথে "আলোচনা" করতে পারে কী করতে হবে, [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **4 Consuming a server GitHub Copilot Agent mode in Visual Studio Code**। এখানে, আমরা Visual Studio Code থেকে আমাদের MCP সার্ভার চালানোর বিষয়ে আলোচনা করব, [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **5 Consuming from a SSE (Server Sent Events)** SSE হলো সার্ভার থেকে ক্লায়েন্টে স্ট্রিমিংয়ের একটি স্ট্যান্ডার্ড, যা সার্ভারকে HTTP এর মাধ্যমে ক্লায়েন্টকে রিয়েল-টাইম আপডেট পাঠাতে সক্ষম করে [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming with MCP (Streamable HTTP)**। আধুনিক HTTP স্ট্রিমিং, প্রগ্রেস নোটিফিকেশন এবং কীভাবে Streamable HTTP ব্যবহার করে স্কেলেবল, রিয়েল-টাইম MCP সার্ভার ও ক্লায়েন্ট তৈরি করা যায় তা শিখুন। [to the lesson](/03-GettingStarted/06-http-streaming/README.md)

- **7 Utilising AI Toolkit for VSCode** MCP ক্লায়েন্ট ও সার্ভার ব্যবহার ও পরীক্ষা করার জন্য [to the lesson](/03-GettingStarted/07-aitk/README.md)

- **8 Testing**। এখানে আমরা বিশেষভাবে শিখব কীভাবে বিভিন্ন উপায়ে আমাদের সার্ভার ও ক্লায়েন্ট পরীক্ষা করা যায়, [to the lesson](/03-GettingStarted/08-testing/README.md)

- **9 Deployment**। এই অধ্যায়ে MCP সলিউশন ডিপ্লয় করার বিভিন্ন উপায় আলোচনা করা হবে, [to the lesson](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) একটি ওপেন প্রোটোকল যা অ্যাপ্লিকেশনগুলো কীভাবে LLM-এ প্রসঙ্গ প্রদান করে তা স্ট্যান্ডার্ড করে। MCP-কে ভাবুন AI অ্যাপ্লিকেশনের জন্য USB-C পোর্টের মতো - এটি AI মডেলগুলোকে বিভিন্ন ডেটা সোর্স ও টুলের সাথে সংযুক্ত করার একটি স্ট্যান্ডার্ড পদ্ধতি প্রদান করে।

## শেখার লক্ষ্যসমূহ

এই পাঠের শেষে, আপনি সক্ষম হবেন:

- C#, Java, Python, TypeScript, এবং JavaScript এ MCP ডেভেলপমেন্ট পরিবেশ সেটআপ করতে
- কাস্টম ফিচার (resources, prompts, এবং tools) সহ বেসিক MCP সার্ভার তৈরি ও ডিপ্লয় করতে
- MCP সার্ভারের সাথে সংযুক্ত হোস্ট অ্যাপ্লিকেশন তৈরি করতে
- MCP ইমপ্লিমেন্টেশন টেস্ট ও ডিবাগ করতে
- সাধারণ সেটআপ সমস্যাগুলো ও তাদের সমাধান বুঝতে
- জনপ্রিয় LLM সার্ভিসের সাথে আপনার MCP ইমপ্লিমেন্টেশন সংযুক্ত করতে

## আপনার MCP পরিবেশ সেটআপ করা

MCP নিয়ে কাজ শুরু করার আগে, আপনার ডেভেলপমেন্ট পরিবেশ প্রস্তুত করা এবং বেসিক ওয়ার্কফ্লো বুঝে নেওয়া গুরুত্বপূর্ণ। এই অংশ আপনাকে শুরু করার জন্য প্রাথমিক সেটআপ ধাপগুলো দেখাবে যাতে MCP দিয়ে কাজ করা সহজ হয়।

### প্রয়োজনীয়তা

MCP ডেভেলপমেন্টে প্রবেশ করার আগে নিশ্চিত করুন আপনার কাছে রয়েছে:

- **ডেভেলপমেন্ট পরিবেশ**: আপনার নির্বাচিত ভাষার জন্য (C#, Java, Python, TypeScript, বা JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, অথবা যেকোনো আধুনিক কোড এডিটর
- **প্যাকেজ ম্যানেজার**: NuGet, Maven/Gradle, pip, অথবা npm/yarn
- **API কী**: যেকোনো AI সার্ভিসের জন্য যা আপনি আপনার হোস্ট অ্যাপ্লিকেশনগুলোতে ব্যবহার করতে চান


### অফিসিয়াল SDKs

আগামী অধ্যায়গুলোতে আপনি Python, TypeScript, Java এবং .NET ব্যবহার করে তৈরি সমাধান দেখবেন। এখানে সব অফিসিয়াল সমর্থিত SDKs দেওয়া হলো।

MCP বিভিন্ন ভাষার জন্য অফিসিয়াল SDK প্রদান করে:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft-এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI-এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - অফিসিয়াল TypeScript ইমপ্লিমেন্টেশন
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - অফিসিয়াল Python ইমপ্লিমেন্টেশন
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - অফিসিয়াল Kotlin ইমপ্লিমেন্টেশন
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI-এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - অফিসিয়াল Rust ইমপ্লিমেন্টেশন

## মূল বিষয়সমূহ

- MCP ডেভেলপমেন্ট পরিবেশ সেটআপ ভাষাভিত্তিক SDK দিয়ে সহজ
- MCP সার্ভার তৈরি মানে স্পষ্ট স্কিমা সহ টুল তৈরি ও নিবন্ধন করা
- MCP ক্লায়েন্ট সার্ভার ও মডেলের সাথে সংযোগ করে উন্নত ফিচার ব্যবহার করে
- টেস্টিং ও ডিবাগিং MCP ইমপ্লিমেন্টেশনের নির্ভরযোগ্যতার জন্য অপরিহার্য
- ডিপ্লয়মেন্ট অপশন স্থানীয় ডেভেলপমেন্ট থেকে ক্লাউড-ভিত্তিক সলিউশন পর্যন্ত বিস্তৃত

## অনুশীলন

আমাদের কাছে এমন কিছু স্যাম্পল আছে যা এই অংশের সব অধ্যায়ের অনুশীলনগুলোকে সম্পূরক করে। এছাড়াও প্রতিটি অধ্যায়ের নিজস্ব অনুশীলন ও অ্যাসাইনমেন্ট রয়েছে।

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## অতিরিক্ত সম্পদ

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## পরবর্তী ধাপ

পরবর্তী: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**বিচ্ছিন্নতা**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার জন্য চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার স্বতন্ত্র ভাষায়ই কর্তৃত্বপ্রাপ্ত উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদের পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে যে কোনও ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।