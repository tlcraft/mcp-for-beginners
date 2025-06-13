<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90651bcd1df019768921d531653638a",
  "translation_date": "2025-06-12T23:16:40+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "bn"
}
-->
### -2- প্রজেক্ট তৈরি করুন

এখন যেহেতু আপনার SDK ইনস্টল হয়ে গেছে, চলুন পরবর্তী ধাপে একটি প্রজেক্ট তৈরি করি:

### -3- প্রজেক্ট ফাইল তৈরি করুন

### -4- সার্ভারের কোড লিখুন

### -5- একটি টুল এবং একটি রিসোর্স যোগ করা

নিম্নলিখিত কোড যোগ করে একটি টুল এবং একটি রিসোর্স যুক্ত করুন:

### -6- চূড়ান্ত কোড

সার্ভার শুরু করার জন্য প্রয়োজনীয় শেষ কোড যোগ করি:

### -7- সার্ভার পরীক্ষা করুন

নিম্নলিখিত কমান্ড দিয়ে সার্ভার শুরু করুন:

### -8- ইন্সপেক্টর ব্যবহার করে চালানো

ইন্সপেক্টর একটি দুর্দান্ত টুল যা আপনার সার্ভার চালু করে এবং এর সাথে ইন্টারঅ্যাক্ট করার সুযোগ দেয় যাতে আপনি পরীক্ষা করতে পারেন যে এটি সঠিকভাবে কাজ করছে কিনা। চলুন এটি চালু করি:

> [!NOTE]
> "command" ফিল্ডে কমান্ডটি আপনার নির্দিষ্ট রানটাইম অনুযায়ী পরিবর্তিত দেখাতে পারে।

আপনি নিম্নলিখিত ইউজার ইন্টারফেস দেখতে পাবেন:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.bn.png)

1. Connect বোতামে ক্লিক করে সার্ভারের সাথে সংযোগ করুন  
   সার্ভারের সাথে সংযোগ করার পর, আপনি নিম্নলিখিতটি দেখতে পাবেন:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.bn.png)

2. "Tools" এবং "listTools" নির্বাচন করুন, আপনি "Add" দেখতে পাবেন, "Add" নির্বাচন করুন এবং প্যারামিটার মান পূরণ করুন।

   আপনি নিম্নলিখিত প্রতিক্রিয়া দেখতে পাবেন, অর্থাৎ "add" টুল থেকে একটি ফলাফল:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.bn.png)

অভিনন্দন, আপনি সফলভাবে আপনার প্রথম সার্ভার তৈরি এবং চালাতে পেরেছেন!

### অফিসিয়াল SDKs

MCP বিভিন্ন ভাষার জন্য অফিসিয়াল SDK সরবরাহ করে:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft-এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI-এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - অফিসিয়াল TypeScript ইমপ্লিমেন্টেশন  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - অফিসিয়াল Python ইমপ্লিমেন্টেশন  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - অফিসিয়াল Kotlin ইমপ্লিমেন্টেশন  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI-এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - অফিসিয়াল Rust ইমপ্লিমেন্টেশন  

## প্রধান বিষয়সমূহ

- MCP ডেভেলপমেন্ট পরিবেশ সেটআপ ভাষা-নির্দিষ্ট SDK এর মাধ্যমে সহজ  
- MCP সার্ভার তৈরি করার সময় স্পষ্ট স্কিমা সহ টুল তৈরি এবং নিবন্ধন করা প্রয়োজন  
- পরীক্ষণ এবং ডিবাগিং MCP ইমপ্লিমেন্টেশনকে নির্ভরযোগ্য করে তোলে  

## নমুনা

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## অ্যাসাইনমেন্ট

আপনার পছন্দের একটি টুল সহ একটি সহজ MCP সার্ভার তৈরি করুন:  
1. আপনার পছন্দের ভাষায় টুলটি ইমপ্লিমেন্ট করুন (.NET, Java, Python, অথবা JavaScript)।  
2. ইনপুট প্যারামিটার এবং রিটার্ন মান নির্ধারণ করুন।  
3. সার্ভার কাজ করছে কিনা নিশ্চিত করতে ইন্সপেক্টর টুল চালান।  
4. বিভিন্ন ইনপুট দিয়ে ইমপ্লিমেন্টেশন পরীক্ষা করুন।  

## সমাধান

[সমাধান](./solution/README.md)  

## অতিরিক্ত সম্পদ

- [Model Context Protocol ব্যবহার করে Azure-এ এজেন্ট তৈরি করা](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Azure Container Apps সহ রিমোট MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP এজেন্ট](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## পরবর্তী ধাপ

পরবর্তী: [MCP ক্লায়েন্ট দিয়ে শুরু করা](/03-GettingStarted/02-client/README.md)

**দ্রষ্টব্য**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার জন্য চেষ্টা করি, তবে অনুগ্রহ করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ভুল বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজ ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদের পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।