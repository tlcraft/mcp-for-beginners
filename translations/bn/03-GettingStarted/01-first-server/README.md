<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:05:45+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "bn"
}
-->
### -2- প্রজেক্ট তৈরি করুন

এখন যেহেতু আপনার SDK ইনস্টল হয়ে গেছে, চলুন পরবর্তী ধাপে একটি প্রজেক্ট তৈরি করি:

### -3- প্রজেক্ট ফাইল তৈরি করুন

### -4- সার্ভার কোড তৈরি করুন

### -5- একটি টুল এবং একটি রিসোর্স যোগ করা

নিম্নলিখিত কোড যোগ করে একটি টুল এবং একটি রিসোর্স যুক্ত করুন:

### -6- চূড়ান্ত কোড

সার্ভার শুরু করার জন্য প্রয়োজনীয় শেষ কোড যোগ করা যাক:

### -7- সার্ভার পরীক্ষা করুন

নিম্নলিখিত কমান্ড দিয়ে সার্ভার শুরু করুন:

### -8- ইন্সপেক্টর ব্যবহার করে চালান

ইন্সপেক্টর একটি দারুণ টুল যা আপনার সার্ভার চালু করে এবং সেটির সাথে ইন্টারঅ্যাক্ট করার সুযোগ দেয়, যাতে আপনি পরীক্ষা করতে পারেন এটি ঠিকমতো কাজ করছে কিনা। চলুন এটি চালু করি:

> [!NOTE]
> এটি "command" ফিল্ডে ভিন্ন দেখাতে পারে কারণ এতে আপনার নির্দিষ্ট রানটাইম দিয়ে সার্ভার চালানোর কমান্ড থাকে।

আপনি নিচের মতো ইউজার ইন্টারফেস দেখতে পাবেন:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.bn.png)

1. Connect বোতামটি চেপে সার্ভারের সাথে সংযুক্ত হন  
   সার্ভারের সাথে সংযুক্ত হলে আপনি নিচের স্ক্রীন দেখতে পাবেন:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.bn.png)

2. "Tools" এবং "listTools" নির্বাচন করুন, আপনি "Add" দেখতে পাবেন, "Add" নির্বাচন করুন এবং প্যারামিটার মানগুলি পূরণ করুন।

   আপনি নিচের রেসপন্স দেখতে পাবেন, অর্থাৎ "add" টুল থেকে একটি ফলাফল:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.bn.png)

অভিনন্দন, আপনি সফলভাবে আপনার প্রথম সার্ভার তৈরি ও চালাতে পেরেছেন!

### অফিসিয়াল SDK গুলো

MCP বিভিন্ন ভাষার জন্য অফিসিয়াল SDK সরবরাহ করে:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft এর সহযোগিতায় রক্ষণাবেক্ষণ
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI এর সহযোগিতায় রক্ষণাবেক্ষণ
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - অফিসিয়াল TypeScript ইমপ্লিমেন্টেশন
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - অফিসিয়াল Python ইমপ্লিমেন্টেশন
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - অফিসিয়াল Kotlin ইমপ্লিমেন্টেশন
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI এর সহযোগিতায় রক্ষণাবেক্ষণ
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - অফিসিয়াল Rust ইমপ্লিমেন্টেশন

## মূল বিষয়সমূহ

- MCP ডেভেলপমেন্ট পরিবেশ সেটআপ করা ভাষাভিত্তিক SDK দিয়ে সহজ
- MCP সার্ভার তৈরি করার সময় স্পষ্ট স্কিমাসহ টুল তৈরি ও নিবন্ধন করা হয়
- MCP ইমপ্লিমেন্টেশন নির্ভরযোগ্য করতে পরীক্ষা ও ডিবাগিং অপরিহার্য

## নমুনা

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## অ্যাসাইনমেন্ট

নিজের পছন্দের টুল দিয়ে একটি সহজ MCP সার্ভার তৈরি করুন:
1. পছন্দসই ভাষায় (.NET, Java, Python, বা JavaScript) টুল ইমপ্লিমেন্ট করুন।
2. ইনপুট প্যারামিটার এবং রিটার্ন মান নির্ধারণ করুন।
3. ইন্সপেক্টর টুল চালিয়ে নিশ্চিত করুন সার্ভার ঠিকমতো কাজ করছে।
4. বিভিন্ন ইনপুট দিয়ে ইমপ্লিমেন্টেশন পরীক্ষা করুন।

## সমাধান

[সমাধান](./solution/README.md)

## অতিরিক্ত রিসোর্স

- [MCP GitHub রিপোজিটরি](https://github.com/microsoft/mcp-for-beginners)

## পরবর্তী ধাপ

পরবর্তী: [MCP ক্লায়েন্ট দিয়ে শুরু করা](/03-GettingStarted/02-client/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে অনুগ্রহ করে জানুন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃপক্ষের উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদের পরামর্শ দেওয়া হয়। এই অনুবাদ ব্যবহারের ফলে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়বদ্ধ নই।