<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T16:57:25+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "bn"
}
-->
### -2- প্রজেক্ট তৈরি করুন

এখন যেহেতু আপনার SDK ইনস্টল হয়ে গেছে, চলুন পরবর্তী ধাপে প্রজেক্ট তৈরি করি:

### -3- প্রজেক্ট ফাইল তৈরি করুন

### -4- সার্ভারের কোড লিখুন

### -5- একটি টুল এবং একটি রিসোর্স যোগ করা

নিম্নলিখিত কোড যোগ করে একটি টুল এবং একটি রিসোর্স যুক্ত করুন:

### -6- চূড়ান্ত কোড

সার্ভার চালু করার জন্য প্রয়োজনীয় শেষ কোড যোগ করি:

### -7- সার্ভার পরীক্ষা করুন

নিম্নলিখিত কমান্ড দিয়ে সার্ভার শুরু করুন:

### -8- ইন্সপেক্টর ব্যবহার করে চালান

ইন্সপেক্টর একটি চমৎকার টুল যা আপনার সার্ভার চালু করে এবং আপনার ইন্টারঅ্যাকশনের মাধ্যমে পরীক্ষা করার সুযোগ দেয়। চলুন এটি শুরু করি:

> [!NOTE]
> "command" ফিল্ডে কমান্ডটি আপনার নির্দিষ্ট রানটাইম অনুযায়ী একটু আলাদা দেখাতে পারে।

আপনি নিম্নলিখিত ইউজার ইন্টারফেস দেখতে পাবেন:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.bn.png)

1. Connect বোতামটি সিলেক্ট করে সার্ভারের সাথে সংযোগ করুন  
   সার্ভারের সাথে সংযোগ করার পর আপনি নিম্নলিখিত দেখতে পাবেন:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.bn.png)

2. "Tools" এবং "listTools" নির্বাচন করুন, আপনি "Add" দেখতে পাবেন, "Add" সিলেক্ট করে প্যারামিটার মানগুলো পূরণ করুন।

   আপনি নিম্নলিখিত প্রতিক্রিয়া দেখতে পাবেন, অর্থাৎ "add" টুল থেকে ফলাফল:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.bn.png)

অভিনন্দন, আপনি সফলভাবে আপনার প্রথম সার্ভার তৈরি ও চালাতে পেরেছেন!

### অফিসিয়াল SDKs

MCP বিভিন্ন ভাষার জন্য অফিসিয়াল SDK প্রদান করে:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - মাইক্রোসফটের সহযোগিতায় রক্ষণাবেক্ষণ  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI এর সহযোগিতায় রক্ষণাবেক্ষণ  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - অফিসিয়াল TypeScript ইমপ্লিমেন্টেশন  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - অফিসিয়াল Python ইমপ্লিমেন্টেশন  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - অফিসিয়াল Kotlin ইমপ্লিমেন্টেশন  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI এর সহযোগিতায় রক্ষণাবেক্ষণ  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - অফিসিয়াল Rust ইমপ্লিমেন্টেশন  

## মূল বিষয়সমূহ

- MCP ডেভেলপমেন্ট এনভায়রনমেন্ট সেটআপ করা ভাষা-নির্দিষ্ট SDK দিয়ে সহজ  
- MCP সার্ভার তৈরি করার সময় স্পষ্ট স্কিমাসহ টুল তৈরি ও রেজিস্টার করা হয়  
- পরীক্ষা ও ডিবাগিং MCP ইমপ্লিমেন্টেশনের নির্ভরযোগ্যতার জন্য অপরিহার্য  

## স্যাম্পলস

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## অ্যাসাইনমেন্ট

নিজের পছন্দের একটি টুল নিয়ে একটি সহজ MCP সার্ভার তৈরি করুন:  
1. আপনার পছন্দের ভাষায় ( .NET, Java, Python, বা JavaScript) টুল ইমপ্লিমেন্ট করুন।  
2. ইনপুট প্যারামিটার এবং রিটার্ন ভ্যালু নির্ধারণ করুন।  
3. সার্ভার ঠিকমতো কাজ করছে কিনা যাচাই করতে ইন্সপেক্টর টুল চালান।  
4. বিভিন্ন ইনপুট দিয়ে ইমপ্লিমেন্টেশন পরীক্ষা করুন।  

## সমাধান

[সমাধান](./solution/README.md)

## অতিরিক্ত সম্পদ

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## পরবর্তী ধাপ

পরবর্তী: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**দ্রষ্টব্য**:  
এই ডকুমেন্টটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে দয়া করে লক্ষ্য করুন যে স্বয়ংক্রিয় অনুবাদে ভুল বা ত্রুটি থাকতে পারে। মূল ডকুমেন্টটি তার নিজ ভাষায়ই প্রামাণিক উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।