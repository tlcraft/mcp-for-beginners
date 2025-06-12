<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:23:37+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "bn"
}
-->
# Calculator LLM Client

একটি জাভা অ্যাপ্লিকেশন যা LangChain4j ব্যবহার করে MCP (Model Context Protocol) ক্যালকুলেটর সার্ভিসের সাথে GitHub Models ইন্টিগ্রেশন কীভাবে করা যায় তা প্রদর্শন করে।

## প্রয়োজনীয়তা

- জাভা ২১ বা তার উপরে
- মেভেন ৩.৬+ (অথবা অন্তর্ভুক্ত মেভেন র‍্যাপার ব্যবহার করুন)
- GitHub Models অ্যাক্সেস সহ একটি GitHub অ্যাকাউন্ট
- `http://localhost:8080` এ চলমান একটি MCP ক্যালকুলেটর সার্ভিস

## GitHub Token পাওয়ার পদ্ধতি

এই অ্যাপ্লিকেশন GitHub Models ব্যবহার করে, যা একটি GitHub ব্যক্তিগত অ্যাক্সেস টোকেন প্রয়োজন। আপনার টোকেন পাওয়ার জন্য নিচের ধাপগুলো অনুসরণ করুন:

### ১. GitHub Models এ প্রবেশ করুন
1. [GitHub Models](https://github.com/marketplace/models) এ যান  
2. আপনার GitHub অ্যাকাউন্ট দিয়ে সাইন ইন করুন  
3. যদি এখনও অ্যাক্সেস না থাকে তবে GitHub Models এর জন্য অনুরোধ করুন  

### ২. একটি ব্যক্তিগত অ্যাক্সেস টোকেন তৈরি করুন
1. [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens) এ যান  
2. "Generate new token" → "Generate new token (classic)" ক্লিক করুন  
3. আপনার টোকেনের জন্য একটি বর্ণনামূলক নাম দিন (যেমন, "MCP Calculator Client")  
4. প্রয়োজন অনুযায়ী মেয়াদ নির্ধারণ করুন  
5. নিচের স্কোপগুলো নির্বাচন করুন:  
   - `repo` (যদি প্রাইভেট রিপোজিটরি অ্যাক্সেস করতে হয়)  
   - `user:email`  
6. "Generate token" ক্লিক করুন  
7. **গুরুত্বপূর্ণ**: টোকেনটি অবিলম্বে কপি করুন - এটি আর দেখা যাবে না!

### ৩. পরিবেশ পরিবর্তনশীল সেট করুন

#### Windows (Command Prompt) এ:
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows (PowerShell) এ:
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux এ:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## সেটআপ এবং ইনস্টলেশন

1. **প্রজেক্ট ডিরেক্টরিতে ক্লোন করুন অথবা যান**

2. **ডিপেন্ডেন্সি ইনস্টল করুন**:  
   ```cmd
   mvnw clean install
   ```  
   অথবা যদি আপনার মেভেন গ্লোবালি ইনস্টল করা থাকে:  
   ```cmd
   mvn clean install
   ```

3. **পরিবেশ পরিবর্তনশীল সেট করুন** (উপরের "GitHub Token পাওয়ার পদ্ধতি" অংশ দেখুন)

4. **MCP Calculator সার্ভিস শুরু করুন**:  
   নিশ্চিত করুন যে আপনি chapter 1 এর MCP ক্যালকুলেটর সার্ভিস `http://localhost:8080/sse` এ চালু করেছেন। ক্লায়েন্ট চালানোর আগে এটি চালু থাকা আবশ্যক।

## অ্যাপ্লিকেশন চালানো

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## অ্যাপ্লিকেশনটি কি করে

অ্যাপ্লিকেশনটি ক্যালকুলেটর সার্ভিসের সাথে তিনটি প্রধান ইন্টারঅ্যাকশন প্রদর্শন করে:

1. **যোগ**: ২৪.৫ এবং ১৭.৩ এর যোগফল হিসাব করে  
2. **বর্গমূল**: ১৪৪ এর বর্গমূল হিসাব করে  
3. **সহায়তা**: উপলব্ধ ক্যালকুলেটর ফাংশনগুলো দেখায়  

## প্রত্যাশিত আউটপুট

সফলভাবে চালানোর সময়, নিচের মতো আউটপুট দেখতে পাবেন:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## সমস্যা সমাধান

### সাধারণ সমস্যা

1. **"GITHUB_TOKEN environment variable not set"**  
   - নিশ্চিত করুন আপনি `GITHUB_TOKEN` সেট করেছেন` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean

### ডিবাগিং

ডিবাগ লগিং চালু করতে, রান করার সময় নিচের JVM আর্গুমেন্টটি যোগ করুন:  
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## কনফিগারেশন

অ্যাপ্লিকেশনটি কনফিগার করা হয়েছে:  
- GitHub Models ব্যবহার করতে `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`  
- অনুরোধের জন্য ৬০ সেকেন্ডের টাইমআউট  
- ডিবাগিংয়ের জন্য অনুরোধ/প্রতিক্রিয়া লগিং সক্রিয়

## ডিপেন্ডেন্সি

এই প্রজেক্টে ব্যবহৃত মূল ডিপেন্ডেন্সি:  
- **LangChain4j**: AI ইন্টিগ্রেশন এবং টুল ম্যানেজমেন্টের জন্য  
- **LangChain4j MCP**: Model Context Protocol সাপোর্টের জন্য  
- **LangChain4j GitHub Models**: GitHub Models ইন্টিগ্রেশনের জন্য  
- **Spring Boot**: অ্যাপ্লিকেশন ফ্রেমওয়ার্ক এবং ডিপেন্ডেন্সি ইনজেকশনের জন্য  

## লাইসেন্স

এই প্রজেক্টটি Apache License 2.0 এর অধীনে লাইসেন্সকৃত - বিস্তারিত জানার জন্য [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) ফাইল দেখুন।

**অস্বীকারোক্তি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে দয়া করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ভুল বা অমিল থাকতে পারে। মূল নথিটি তার স্বাভাবিক ভাষায় প্রামাণিক উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।