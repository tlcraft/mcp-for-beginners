<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ed9cab32cc67c12d8969b407aa47100a",
  "translation_date": "2025-06-11T09:30:45+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/java/README.md",
  "language_code": "bn"
}
-->
# Basic Calculator MCP Service

এই সার্ভিসটি Model Context Protocol (MCP) ব্যবহার করে Spring Boot এর WebFlux ট্রান্সপোর্টের মাধ্যমে মৌলিক ক্যালকুলেটর অপারেশন প্রদান করে। এটি MCP ইমপ্লিমেন্টেশন শিখতে আগ্রহী নবীনদের জন্য একটি সহজ উদাহরণ হিসেবে ডিজাইন করা হয়েছে।

আরও তথ্যের জন্য দেখুন [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html) রেফারেন্স ডকুমেন্টেশন।


## সার্ভিস ব্যবহারের পদ্ধতি

সার্ভিসটি MCP প্রোটোকলের মাধ্যমে নিম্নলিখিত API এন্ডপয়েন্টগুলো প্রদান করে:

- `add(a, b)`: দুটি সংখ্যার যোগফল নির্ণয়
- `subtract(a, b)`: প্রথম সংখ্যা থেকে দ্বিতীয় সংখ্যা বিয়োগ করা
- `multiply(a, b)`: দুটি সংখ্যার গুণফল নির্ণয়
- `divide(a, b)`: প্রথম সংখ্যাকে দ্বিতীয় সংখ্যায় ভাগ করা (শূন্য ভাগের ক্ষেত্রে চেক সহ)
- `power(base, exponent)`: একটি সংখ্যার পাওয়ার নির্ণয়
- `squareRoot(number)`: বর্গমূল নির্ণয় (নেগেটিভ সংখ্যার ক্ষেত্রে চেক সহ)
- `modulus(a, b)`: ভাগশেষ নির্ণয়
- `absolute(number)`: একটি সংখ্যার পরম মান নির্ণয়

## ডিপেনডেন্সিস

প্রকল্পের জন্য নিম্নলিখিত মূল ডিপেনডেন্সিস প্রয়োজন:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

## প্রকল্প নির্মাণ

Maven ব্যবহার করে প্রকল্পটি বিল্ড করুন:
```bash
./mvnw clean install -DskipTests
```

## সার্ভার চালানো

### Java ব্যবহার করে

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### MCP Inspector ব্যবহার করে

MCP Inspector হল MCP সার্ভিসের সাথে ইন্টারঅ্যাক্ট করার জন্য একটি উপকারী টুল। এই ক্যালকুলেটর সার্ভিসের সাথে এটি ব্যবহার করতে:

1. **নতুন টার্মিনাল উইন্ডোতে MCP Inspector ইনস্টল ও চালু করুন**:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **ওয়েব UI অ্যাক্সেস করুন** অ্যাপ দ্বারা প্রদর্শিত URL এ ক্লিক করে (সাধারণত http://localhost:6274)

3. **কনফিগারেশন সেট করুন**:
   - ট্রান্সপোর্ট টাইপ "SSE" সেট করুন
   - URL দিন আপনার চলমান সার্ভারের SSE এন্ডপয়েন্ট: `http://localhost:8080/sse`
   - "Connect" ক্লিক করুন

4. **টুলগুলো ব্যবহার করুন**:
   - "List Tools" ক্লিক করে উপলব্ধ ক্যালকুলেটর অপারেশন দেখুন
   - একটি টুল নির্বাচন করে "Run Tool" ক্লিক করে অপারেশন চালান

![MCP Inspector Screenshot](../../../../../../translated_images/tool.40e180a7b0d0fe2067cf96435532b01f63f7f8619d6b0132355a04b426b669ac.bn.png)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার জন্য চেষ্টা করি, তবে অনুগ্রহ করে জানুন যে স্বয়ংক্রিয় অনুবাদে ভুল বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হবে। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদের পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।