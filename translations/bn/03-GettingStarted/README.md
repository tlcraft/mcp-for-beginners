<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:25:46+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "bn"
}
-->
## Getting Started  

এই অংশে বেশ কিছু লেসন রয়েছে:

- **-1- Your first server**, এই প্রথম লেসনে, আপনি শিখবেন কীভাবে আপনার প্রথম সার্ভার তৈরি করবেন এবং inspector টুল দিয়ে সেটি পরীক্ষা করবেন, যা আপনার সার্ভার টেস্ট ও ডিবাগ করার একটি মূল্যবান উপায়, [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **-2- Client**, এই লেসনে, আপনি শিখবেন কীভাবে একটি ক্লায়েন্ট লিখবেন যা আপনার সার্ভারের সাথে কানেক্ট করতে পারে, [to the lesson](/03-GettingStarted/02-client/README.md)

- **-3- Client with LLM**, ক্লায়েন্ট লেখার আরও উন্নত একটি উপায় হলো এতে LLM যোগ করা যাতে এটি আপনার সার্ভারের সাথে "আলোচনা" করতে পারে কী করতে হবে তা নির্ধারণ করার জন্য, [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **-4- Consuming a server GitHub Copilot Agent mode in Visual Studio Code**। এখানে, আমরা Visual Studio Code থেকে আমাদের MCP Server চালানোর বিষয়টি দেখছি, [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **-5- Consuming from a SSE (Server Sent Events)** SEE হলো সার্ভার থেকে ক্লায়েন্টে স্ট্রিমিংয়ের একটি স্ট্যান্ডার্ড, যা সার্ভারকে HTTP এর মাধ্যমে ক্লায়েন্টকে রিয়েল-টাইম আপডেট পাঠাতে দেয় [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **-6- Utilising AI Toolkit for VSCode** MCP ক্লায়েন্ট ও সার্ভার পরীক্ষা ও ব্যবহার করার জন্য [to the lesson](/03-GettingStarted/06-aitk/README.md)

- **-7 Testing**। এখানে আমরা বিশেষ করে দেখব কীভাবে বিভিন্ন উপায়ে আমাদের সার্ভার ও ক্লায়েন্ট পরীক্ষা করা যায়, [to the lesson](/03-GettingStarted/07-testing/README.md)

- **-8- Deployment**। এই অধ্যায়ে আমরা MCP সলিউশন ডিপ্লয় করার বিভিন্ন উপায় আলোচনা করব, [to the lesson](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) হলো একটি ওপেন প্রোটোকল যা স্ট্যান্ডার্ড করে কীভাবে অ্যাপ্লিকেশনগুলো LLM গুলোর কাছে প্রসঙ্গ সরবরাহ করে। MCP কে ভাবুন AI অ্যাপ্লিকেশনের জন্য USB-C পোর্টের মতো — এটি AI মডেলগুলোকে বিভিন্ন ডেটা সোর্স ও টুলের সাথে সংযুক্ত করার একটি স্ট্যান্ডার্ড উপায় প্রদান করে।

## Learning Objectives

এই লেসনের শেষে, আপনি সক্ষম হবেন:

- C#, Java, Python, TypeScript, এবং JavaScript এ MCP এর জন্য ডেভেলপমেন্ট পরিবেশ সেটআপ করতে
- কাস্টম ফিচার (resources, prompts, এবং tools) সহ বেসিক MCP সার্ভার তৈরি ও ডিপ্লয় করতে
- MCP সার্ভারের সাথে কানেক্ট করতে হোস্ট অ্যাপ্লিকেশন তৈরি করতে
- MCP ইমপ্লিমেন্টেশন টেস্ট ও ডিবাগ করতে
- সাধারণ সেটআপ সমস্যাগুলো ও তাদের সমাধান বুঝতে
- আপনার MCP ইমপ্লিমেন্টেশনগুলো জনপ্রিয় LLM সার্ভিসের সাথে সংযুক্ত করতে

## Setting Up Your MCP Environment

MCP নিয়ে কাজ শুরু করার আগে, আপনার ডেভেলপমেন্ট পরিবেশ প্রস্তুত করা এবং বেসিক ওয়ার্কফ্লো বোঝা গুরুত্বপূর্ণ। এই অংশ আপনাকে প্রাথমিক সেটআপের ধাপগুলো দেখাবে যাতে MCP দিয়ে কাজ শুরু করতে সহজ হয়।

### Prerequisites

MCP ডেভেলপমেন্টে নামার আগে নিশ্চিত করুন আপনার কাছে আছে:

- **Development Environment**: আপনার নির্বাচিত ভাষার জন্য (C#, Java, Python, TypeScript, অথবা JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, অথবা যেকোন আধুনিক কোড এডিটর
- **Package Managers**: NuGet, Maven/Gradle, pip, অথবা npm/yarn
- **API Keys**: যেকোন AI সার্ভিসের জন্য যা আপনি আপনার হোস্ট অ্যাপ্লিকেশনে ব্যবহার করবেন


### Official SDKs

আগামী অধ্যায়গুলোতে আপনি Python, TypeScript, Java এবং .NET ব্যবহার করে তৈরি সমাধান দেখতে পাবেন। এখানে সব অফিসিয়ালি সাপোর্টেড SDK গুলো দেওয়া হলো।

MCP বিভিন্ন ভাষার জন্য অফিসিয়াল SDK প্রদান করে:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft এর সহযোগিতায় রক্ষণাবেক্ষণ
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI এর সহযোগিতায় রক্ষণাবেক্ষণ
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - অফিসিয়াল TypeScript ইমপ্লিমেন্টেশন
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - অফিসিয়াল Python ইমপ্লিমেন্টেশন
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - অফিসিয়াল Kotlin ইমপ্লিমেন্টেশন
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI এর সহযোগিতায় রক্ষণাবেক্ষণ
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - অফিসিয়াল Rust ইমপ্লিমেন্টেশন

## Key Takeaways

- MCP ডেভেলপমেন্ট পরিবেশ সেটআপ করা ভাষা-নির্দিষ্ট SDK দিয়ে সহজ
- MCP সার্ভার তৈরি মানে স্পষ্ট স্কিমা সহ টুল তৈরি ও রেজিস্টার করা
- MCP ক্লায়েন্ট সার্ভার ও মডেলের সাথে কানেক্ট করে বাড়তি ক্ষমতা নেয়
- টেস্টিং ও ডিবাগিং MCP ইমপ্লিমেন্টেশনের জন্য অপরিহার্য
- ডিপ্লয়মেন্ট অপশনগুলো লোকাল ডেভেলপমেন্ট থেকে ক্লাউড-ভিত্তিক সলিউশন পর্যন্ত বিস্তৃত

## Practicing

আমাদের কাছে কিছু স্যাম্পল আছে যা এই অংশের সব অধ্যায়ে আপনি যে এক্সারসাইজগুলো দেখবেন সেগুলোকে সম্পূরক করে। এছাড়াও প্রতিটি অধ্যায়ের নিজস্ব এক্সারসাইজ ও অ্যাসাইনমেন্ট রয়েছে।

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

Next: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে অনুগ্রহ করে সচেতন থাকুন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায় প্রামাণিক উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদের পরামর্শ দেওয়া হয়। এই অনুবাদ ব্যবহারের ফলে উদ্ভূত কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।