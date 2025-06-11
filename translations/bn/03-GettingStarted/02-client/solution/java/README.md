<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:08:05+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "bn"
}
-->
# MCP Java Client - Calculator Demo

এই প্রকল্পটি দেখায় কিভাবে একটি Java ক্লায়েন্ট তৈরি করতে হয় যা MCP (Model Context Protocol) সার্ভারের সাথে সংযুক্ত হয় এবং ইন্টারঅ্যাক্ট করে। এই উদাহরণে, আমরা অধ্যায় ০১ এর ক্যালকুলেটর সার্ভারের সাথে সংযুক্ত হয়ে বিভিন্ন গাণিতিক অপারেশন সম্পাদন করব।

## প্রয়োজনীয়তা

এই ক্লায়েন্ট চালানোর আগে, আপনাকে:

1. **অধ্যায় ০১ থেকে ক্যালকুলেটর সার্ভার চালু করুন**:
   - ক্যালকুলেটর সার্ভার ডিরেক্টরিতে যান: `03-GettingStarted/01-first-server/solution/java/`
   - ক্যালকুলেটর সার্ভার বিল্ড এবং চালান:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - সার্ভারটি `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `` এ চলতে থাকবে।

`SDKClient` একটি Java অ্যাপ্লিকেশন যা দেখায় কিভাবে:
- MCP সার্ভারের সাথে Server-Sent Events (SSE) ট্রান্সপোর্ট ব্যবহার করে সংযুক্ত হওয়া যায়
- সার্ভার থেকে উপলব্ধ টুলস তালিকা করা যায়
- বিভিন্ন ক্যালকুলেটর ফাংশন রিমোটলি কল করা যায়
- রেসপন্স হ্যান্ডেল করে ফলাফল প্রদর্শন করা যায়

## এটি কিভাবে কাজ করে

ক্লায়েন্টটি Spring AI MCP ফ্রেমওয়ার্ক ব্যবহার করে:

1. **সংযোগ স্থাপন**: ক্যালকুলেটর সার্ভারের সাথে সংযোগের জন্য WebFlux SSE ক্লায়েন্ট ট্রান্সপোর্ট তৈরি করে
2. **ক্লায়েন্ট ইনিশিয়ালাইজ**: MCP ক্লায়েন্ট সেট আপ করে এবং সংযোগ স্থাপন করে
3. **টুলস আবিষ্কার**: উপলব্ধ সব ক্যালকুলেটর অপারেশন তালিকা করে
4. **অপারেশন সম্পাদন**: নমুনা ডেটা দিয়ে বিভিন্ন গাণিতিক ফাংশন কল করে
5. **ফলাফল প্রদর্শন**: প্রতিটি গণনার ফলাফল দেখায়

## প্রকল্পের কাঠামো

```
src/
└── main/
    └── java/
        └── com/
            └── microsoft/
                └── mcp/
                    └── sample/
                        └── client/
                            └── SDKClient.java    # Main client implementation
```

## প্রধান ডিপেন্ডেন্সি

প্রকল্পটি নিম্নলিখিত প্রধান ডিপেন্ডেন্সিগুলো ব্যবহার করে:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

এই ডিপেন্ডেন্সি প্রদান করে:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - ওয়েবভিত্তিক যোগাযোগের জন্য SSE ট্রান্সপোর্ট
- MCP প্রোটোকল স্কিমা এবং রিকোয়েস্ট/রেসপন্স টাইপস

## প্রকল্প বিল্ড করা

Maven wrapper ব্যবহার করে প্রকল্প বিল্ড করুন:

```cmd
.\mvnw clean install
```

## ক্লায়েন্ট চালানো

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: নিশ্চিত করুন ক্যালকুলেটর সার্ভারটি `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080` এ চলছে।

2. **টুলস তালিকা করা** - উপলব্ধ সব ক্যালকুলেটর অপারেশন দেখায়  
3. **গণনা সম্পাদন করা**:
   - যোগ: ৫ + ৩ = ৮
   - বিয়োগ: ১০ - ৪ = ৬
   - গুণ: ৬ × ৭ = ৪২
   - ভাগ: ২০ ÷ ৪ = ৫
   - পাওয়ার: ২^৮ = ২৫৬
   - বর্গমূল: √১৬ = ৪
   - পরম মান: |-৫.৫| = ৫.৫
   - সাহায্য: উপলব্ধ অপারেশনগুলো দেখায়

## প্রত্যাশিত আউটপুট

```
Available Tools = ListToolsResult[tools=[Tool[name=add, description=Add two numbers together, ...], ...]]
Add Result = CallToolResult[content=[TextContent[text="5,00 + 3,00 = 8,00"]], isError=false]
Subtract Result = CallToolResult[content=[TextContent[text="10,00 - 4,00 = 6,00"]], isError=false]
Multiply Result = CallToolResult[content=[TextContent[text="6,00 * 7,00 = 42,00"]], isError=false]
Divide Result = CallToolResult[content=[TextContent[text="20,00 / 4,00 = 5,00"]], isError=false]
Power Result = CallToolResult[content=[TextContent[text="2,00 ^ 8,00 = 256,00"]], isError=false]
Square Root Result = CallToolResult[content=[TextContent[text="√16,00 = 4,00"]], isError=false]
Absolute Result = CallToolResult[content=[TextContent[text="|-5,50| = 5,50"]], isError=false]
Help = CallToolResult[content=[TextContent[text="Basic Calculator MCP Service\n\nAvailable operations:\n1. add(a, b) - Adds two numbers\n2. subtract(a, b) - Subtracts the second number from the first\n..."]], isError=false]
```

**Note**: আপনি মেভেনের কিছু ওয়ার্নিং দেখতে পারেন যা শেষের দিকে থ্রেড লিঙ্গারিং সম্পর্কে - এটি রিয়েক্টিভ অ্যাপ্লিকেশনগুলোর জন্য স্বাভাবিক এবং কোনো ত্রুটি নির্দেশ করে না।

## কোড বোঝা

### ১. ট্রান্সপোর্ট সেটআপ
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```  
এটি একটি SSE (Server-Sent Events) ট্রান্সপোর্ট তৈরি করে যা ক্যালকুলেটর সার্ভারের সাথে সংযুক্ত হয়।

### ২. ক্লায়েন্ট তৈরি
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```  
একটি সিঙ্ক্রোনাস MCP ক্লায়েন্ট তৈরি করে এবং সংযোগ শুরু করে।

### ৩. টুলস কল করা
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```  
"add" টুলটি প্যারামিটার a=5.0 এবং b=3.0 দিয়ে কল করে।

## সমস্যা সমাধান

### সার্ভার চালু নেই
যদি সংযোগে সমস্যা হয়, নিশ্চিত করুন অধ্যায় ০১ থেকে ক্যালকুলেটর সার্ভারটি চলছে:
```
Error: Connection refused
```  
**সমাধান**: প্রথমে ক্যালকুলেটর সার্ভার চালু করুন।

### পোর্ট ইতিমধ্যে ব্যস্ত
যদি পোর্ট ৮০৮০ ব্যস্ত থাকে:
```
Error: Address already in use
```  
**সমাধান**: পোর্ট ৮০৮০ ব্যবহার করছে এমন অন্য অ্যাপ্লিকেশন বন্ধ করুন অথবা সার্ভারটি অন্য পোর্টে চালানোর জন্য পরিবর্তন করুন।

### বিল্ড ত্রুটি
যদি বিল্ডে ত্রুটি হয়:
```cmd
.\mvnw clean install -DskipTests
```

## আরও জানুন

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে দয়া করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ভুল বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজ ভাষায় প্রামাণিক উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।