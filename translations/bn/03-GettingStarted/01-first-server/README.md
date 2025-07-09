<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "315ecce765d22639b60dbc41344c8533",
  "translation_date": "2025-07-09T23:01:30+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "bn"
}
-->
### -2- একটি প্রকল্প তৈরি করুন

এখন যেহেতু আপনার SDK ইনস্টল হয়ে গেছে, চলুন পরবর্তী ধাপে একটি প্রকল্প তৈরি করি:

### -3- প্রকল্প ফাইল তৈরি করুন

### -4- সার্ভারের কোড তৈরি করুন

### -5- একটি টুল এবং একটি রিসোর্স যোগ করা

নিম্নলিখিত কোড যোগ করে একটি টুল এবং একটি রিসোর্স যুক্ত করুন:

### -6- চূড়ান্ত কোড

সার্ভার শুরু করার জন্য প্রয়োজনীয় শেষ কোডটি যোগ করি:

### -7- সার্ভার পরীক্ষা করুন

নিম্নলিখিত কমান্ড দিয়ে সার্ভার শুরু করুন:

### -8- ইন্সপেক্টর ব্যবহার করে চালান

ইন্সপেক্টর একটি চমৎকার টুল যা আপনার সার্ভার চালু করে এবং আপনাকে এর সাথে ইন্টারঅ্যাক্ট করার সুযোগ দেয় যাতে আপনি পরীক্ষা করতে পারেন এটি সঠিকভাবে কাজ করছে কিনা। চলুন এটি চালু করি:
> [!NOTE]
> "command" ফিল্ডে এটি ভিন্ন দেখাতে পারে কারণ এতে আপনার নির্দিষ্ট রানটাইমের সাথে সার্ভার চালানোর কমান্ড থাকে/
আপনি নিম্নলিখিত ব্যবহারকারী ইন্টারফেস দেখতে পাবেন:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.bn.png)

1. Connect বোতামটি নির্বাচন করে সার্ভারের সাথে সংযোগ করুন  
  সার্ভারের সাথে সংযোগ করার পর, আপনি নিম্নলিখিত দেখতে পাবেন:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.bn.png)

1. "Tools" এবং "listTools" নির্বাচন করুন, আপনি "Add" দেখতে পাবেন, "Add" নির্বাচন করুন এবং প্যারামিটার মানগুলি পূরণ করুন।

  আপনি নিম্নলিখিত প্রতিক্রিয়া দেখতে পাবেন, অর্থাৎ "add" টুল থেকে একটি ফলাফল:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.bn.png)

অভিনন্দন, আপনি সফলভাবে আপনার প্রথম সার্ভার তৈরি ও চালাতে পেরেছেন!

### অফিসিয়াল SDKs

MCP বিভিন্ন ভাষার জন্য অফিসিয়াল SDK প্রদান করে:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft-এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ করা হয়
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI-এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ করা হয়
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - অফিসিয়াল TypeScript ইমপ্লিমেন্টেশন
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - অফিসিয়াল Python ইমপ্লিমেন্টেশন
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - অফিসিয়াল Kotlin ইমপ্লিমেন্টেশন
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI-এর সাথে সহযোগিতায় রক্ষণাবেক্ষণ করা হয়
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - অফিসিয়াল Rust ইমপ্লিমেন্টেশন

## মূল বিষয়সমূহ

- MCP ডেভেলপমেন্ট পরিবেশ সেটআপ করা ভাষা-নির্দিষ্ট SDK দিয়ে সহজ
- MCP সার্ভার তৈরি করা মানে স্পষ্ট স্কিমাসহ টুল তৈরি ও নিবন্ধন করা
- নির্ভরযোগ্য MCP ইমপ্লিমেন্টেশনের জন্য টেস্টিং ও ডিবাগিং অপরিহার্য

## নমুনা

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## অ্যাসাইনমেন্ট

আপনার পছন্দের একটি টুল নিয়ে একটি সহজ MCP সার্ভার তৈরি করুন:

1. আপনার পছন্দের ভাষায় টুলটি ইমপ্লিমেন্ট করুন (.NET, Java, Python, বা JavaScript)।
2. ইনপুট প্যারামিটার এবং রিটার্ন মান নির্ধারণ করুন।
3. সার্ভার সঠিকভাবে কাজ করছে কিনা তা নিশ্চিত করতে inspector টুল চালান।
4. বিভিন্ন ইনপুট দিয়ে ইমপ্লিমেন্টেশন পরীক্ষা করুন।

## সমাধান

[Solution](./solution/README.md)

## অতিরিক্ত সম্পদ

- [Azure-এ Model Context Protocol ব্যবহার করে এজেন্ট তৈরি](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps-এ রিমোট MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## পরবর্তী ধাপ

পরবর্তী: [MCP ক্লায়েন্ট দিয়ে শুরু করা](../02-client/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।