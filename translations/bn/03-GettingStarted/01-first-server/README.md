<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "37563349cd6894fe00489bf3b4d488ae",
  "translation_date": "2025-06-02T10:30:49+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "bn"
}
-->
### -2- প্রজেক্ট তৈরি করুন

এখন যেহেতু আপনার SDK ইনস্টল হয়ে গেছে, চলুন পরবর্তী ধাপে একটি প্রজেক্ট তৈরি করি:

### -3- প্রজেক্ট ফাইল তৈরি করুন

### -4- সার্ভারের কোড লিখুন

### -5- একটি টুল এবং একটি রিসোর্স যোগ করা

নিম্নলিখিত কোড যোগ করে একটি টুল এবং একটি রিসোর্স যোগ করুন:

### -6- চূড়ান্ত কোড

সার্ভার চালু করার জন্য প্রয়োজনীয় শেষ কোডটি যোগ করি:

### -7- সার্ভার পরীক্ষা করুন

নিম্নলিখিত কমান্ড দিয়ে সার্ভার চালু করুন:

### -8- ইন্সপেক্টর ব্যবহার করে চালান

ইন্সপেক্টর একটি চমৎকার টুল যা আপনার সার্ভার চালু করে এবং আপনার সাথে ইন্টারঅ্যাক্ট করতে দেয়, যাতে আপনি পরীক্ষা করতে পারেন এটি কাজ করছে কিনা। চলুন এটি চালু করি:

> [!NOTE]
> "command" ফিল্ডে এটি ভিন্ন দেখাতে পারে কারণ এটি আপনার নির্দিষ্ট রানটাইমের জন্য সার্ভার চালানোর কমান্ড ধারণ করে।

আপনি নিম্নলিখিত ইউজার ইন্টারফেস দেখতে পাবেন:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.bn.png)

1. Connect বোতাম নির্বাচন করে সার্ভারের সাথে সংযুক্ত হন  
   সার্ভারের সাথে সংযুক্ত হওয়ার পর আপনি নিম্নলিখিত দেখতে পাবেন:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.bn.png)

2. "Tools" এবং "listTools" নির্বাচন করুন, আপনি "Add" দেখতে পাবেন, "Add" নির্বাচন করুন এবং প্যারামিটার মান পূরণ করুন।

   আপনি নিম্নলিখিত প্রতিক্রিয়া দেখতে পাবেন, অর্থাৎ "add" টুল থেকে একটি ফলাফল:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.bn.png)

অভিনন্দন, আপনি সফলভাবে আপনার প্রথম সার্ভার তৈরি এবং চালাতে পেরেছেন!

### অফিসিয়াল SDKs

MCP বিভিন্ন ভাষার জন্য অফিসিয়াল SDK প্রদান করে:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft-এর সহযোগিতায় রক্ষণাবেক্ষণ  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI-এর সহযোগিতায় রক্ষণাবেক্ষণ  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - অফিসিয়াল TypeScript ইমপ্লিমেন্টেশন  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - অফিসিয়াল Python ইমপ্লিমেন্টেশন  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - অফিসিয়াল Kotlin ইমপ্লিমেন্টেশন  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI-এর সহযোগিতায় রক্ষণাবেক্ষণ  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - অফিসিয়াল Rust ইমপ্লিমেন্টেশন  

## মূল বিষয়গুলো

- MCP ডেভেলপমেন্ট পরিবেশ সেটআপ করা ভাষাভিত্তিক SDK ব্যবহার করে সহজ  
- MCP সার্ভার তৈরি করতে পরিষ্কার স্কিমা সহ টুল তৈরি ও রেজিস্টার করতে হয়  
- পরীক্ষণ ও ডিবাগিং MCP ইমপ্লিমেন্টেশনের নির্ভরযোগ্যতার জন্য অপরিহার্য  

## নমুনা

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## অ্যাসাইনমেন্ট

আপনার পছন্দের একটি টুল সহ একটি সাধারণ MCP সার্ভার তৈরি করুন:  
1. আপনার পছন্দের ভাষায় (.NET, Java, Python, অথবা JavaScript) টুলটি ইমপ্লিমেন্ট করুন।  
2. ইনপুট প্যারামিটার এবং রিটার্ন মান নির্ধারণ করুন।  
3. সার্ভার সঠিকভাবে কাজ করছে কিনা নিশ্চিত করতে ইন্সপেক্টর টুল চালান।  
4. বিভিন্ন ইনপুট দিয়ে ইমপ্লিমেন্টেশন পরীক্ষা করুন।  

## সমাধান

[Solution](./solution/README.md)

## অতিরিক্ত রিসোর্স

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## পরবর্তী ধাপ

পরবর্তী: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে দয়া করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই সর্বোত্তম এবং কর্তৃপক্ষপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদের পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।