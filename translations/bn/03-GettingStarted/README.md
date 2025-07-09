<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "860935ff95d05b006d1d3323e8e3f9e8",
  "translation_date": "2025-07-09T22:29:14+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "bn"
}
-->
## Getting Started  

এই অংশে কয়েকটি পাঠ রয়েছে:

- **1 Your first server**, এই প্রথম পাঠে, আপনি শিখবেন কিভাবে আপনার প্রথম সার্ভার তৈরি করবেন এবং inspector টুল দিয়ে এটি পরীক্ষা করবেন, যা আপনার সার্ভার টেস্ট এবং ডিবাগ করার জন্য একটি মূল্যবান উপায়, [to the lesson](01-first-server/README.md)

- **2 Client**, এই পাঠে, আপনি শিখবেন কিভাবে একটি ক্লায়েন্ট লিখবেন যা আপনার সার্ভারের সাথে সংযোগ করতে পারে, [to the lesson](02-client/README.md)

- **3 Client with LLM**, ক্লায়েন্ট লেখার আরও উন্নত উপায় হল এতে একটি LLM যোগ করা যাতে এটি আপনার সার্ভারের সাথে "আলোচনা" করতে পারে যে কী করতে হবে, [to the lesson](03-llm-client/README.md)

- **4 Consuming a server GitHub Copilot Agent mode in Visual Studio Code**। এখানে, আমরা Visual Studio Code থেকে আমাদের MCP Server চালানোর বিষয়টি দেখছি, [to the lesson](04-vscode/README.md)

- **5 Consuming from a SSE (Server Sent Events)** SSE হলো সার্ভার থেকে ক্লায়েন্টে স্ট্রিমিংয়ের একটি স্ট্যান্ডার্ড, যা সার্ভারকে HTTP এর মাধ্যমে ক্লায়েন্টদের রিয়েল-টাইম আপডেট পাঠাতে দেয় [to the lesson](05-sse-server/README.md)

- **6 HTTP Streaming with MCP (Streamable HTTP)**। আধুনিক HTTP স্ট্রিমিং, প্রগ্রেস নোটিফিকেশন এবং কিভাবে স্কেলেবল, রিয়েল-টাইম MCP সার্ভার ও ক্লায়েন্ট Streamable HTTP ব্যবহার করে তৈরি করবেন তা শিখুন। [to the lesson](06-http-streaming/README.md)

- **7 Utilising AI Toolkit for VSCode** MCP ক্লায়েন্ট এবং সার্ভার ব্যবহার ও পরীক্ষা করার জন্য [to the lesson](07-aitk/README.md)

- **8 Testing**। এখানে আমরা বিশেষভাবে ফোকাস করব কিভাবে বিভিন্ন উপায়ে আমাদের সার্ভার এবং ক্লায়েন্ট পরীক্ষা করা যায়, [to the lesson](08-testing/README.md)

- **9 Deployment**। এই অধ্যায়ে আমরা MCP সমাধান ডিপ্লয় করার বিভিন্ন উপায় দেখব, [to the lesson](09-deployment/README.md)


Model Context Protocol (MCP) একটি ওপেন প্রোটোকল যা অ্যাপ্লিকেশনগুলোকে LLM গুলোর জন্য কনটেক্সট প্রদান করার পদ্ধতি স্ট্যান্ডার্ড করে। MCP কে ভাবুন AI অ্যাপ্লিকেশনের জন্য একটি USB-C পোর্টের মতো — এটি AI মডেলগুলোকে বিভিন্ন ডেটা সোর্স এবং টুলের সাথে সংযুক্ত করার একটি স্ট্যান্ডার্ড পদ্ধতি প্রদান করে।

## Learning Objectives

এই পাঠের শেষে, আপনি সক্ষম হবেন:

- C#, Java, Python, TypeScript, এবং JavaScript এ MCP এর জন্য ডেভেলপমেন্ট এনভায়রনমেন্ট সেটআপ করতে
- কাস্টম ফিচার (resources, prompts, এবং tools) সহ বেসিক MCP সার্ভার তৈরি ও ডিপ্লয় করতে
- MCP সার্ভারের সাথে সংযোগ স্থাপনকারী হোস্ট অ্যাপ্লিকেশন তৈরি করতে
- MCP ইমপ্লিমেন্টেশন টেস্ট ও ডিবাগ করতে
- সাধারণ সেটআপ চ্যালেঞ্জ এবং তাদের সমাধান বুঝতে
- আপনার MCP ইমপ্লিমেন্টেশনগুলো জনপ্রিয় LLM সার্ভিসের সাথে সংযুক্ত করতে

## Setting Up Your MCP Environment

MCP নিয়ে কাজ শুরু করার আগে, আপনার ডেভেলপমেন্ট এনভায়রনমেন্ট প্রস্তুত করা এবং মৌলিক ওয়ার্কফ্লো বোঝা গুরুত্বপূর্ণ। এই অংশটি আপনাকে MCP এর সাথে মসৃণ শুরু করার জন্য প্রাথমিক সেটআপ ধাপগুলো দেখাবে।

### Prerequisites

MCP ডেভেলপমেন্টে প্রবেশ করার আগে নিশ্চিত করুন আপনার কাছে আছে:

- **Development Environment**: আপনার পছন্দের ভাষার জন্য (C#, Java, Python, TypeScript, অথবা JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, অথবা যেকোনো আধুনিক কোড এডিটর
- **Package Managers**: NuGet, Maven/Gradle, pip, অথবা npm/yarn
- **API Keys**: যেকোনো AI সার্ভিসের জন্য যা আপনি আপনার হোস্ট অ্যাপ্লিকেশনে ব্যবহার করতে চান


### Official SDKs

আগামী অধ্যায়গুলোতে আপনি Python, TypeScript, Java এবং .NET ব্যবহার করে তৈরি সমাধান দেখতে পাবেন। এখানে সব অফিসিয়াল সমর্থিত SDK গুলো দেওয়া হলো।

MCP বিভিন্ন ভাষার জন্য অফিসিয়াল SDK প্রদান করে:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - অফিসিয়াল TypeScript ইমপ্লিমেন্টেশন
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - অফিসিয়াল Python ইমপ্লিমেন্টেশন
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - অফিসিয়াল Kotlin ইমপ্লিমেন্টেশন
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - অফিসিয়াল Rust ইমপ্লিমেন্টেশন

## Key Takeaways

- MCP ডেভেলপমেন্ট এনভায়রনমেন্ট সেটআপ করা ভাষা-নির্দিষ্ট SDK গুলোর মাধ্যমে সহজ
- MCP সার্ভার তৈরি মানে স্পষ্ট স্কিমা সহ টুল তৈরি ও রেজিস্টার করা
- MCP ক্লায়েন্ট সার্ভার এবং মডেলের সাথে সংযোগ করে বিস্তৃত ক্ষমতা ব্যবহার করে
- টেস্টিং এবং ডিবাগিং MCP ইমপ্লিমেন্টেশনের জন্য অপরিহার্য
- ডিপ্লয়মেন্ট অপশনগুলো স্থানীয় ডেভেলপমেন্ট থেকে ক্লাউড-ভিত্তিক সমাধান পর্যন্ত বিস্তৃত

## Practicing

আমাদের কাছে কিছু স্যাম্পল আছে যা এই অংশের সব অধ্যায়ের অনুশীলনগুলোকে সম্পূরক করে। এছাড়াও প্রতিটি অধ্যায়ের নিজস্ব অনুশীলন এবং অ্যাসাইনমেন্ট রয়েছে।

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

Next: [Creating your first MCP Server](01-first-server/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।