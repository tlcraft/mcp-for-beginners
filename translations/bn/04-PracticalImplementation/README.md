<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5384bbb2a92d00d5d7e66274dbe0331d",
  "translation_date": "2025-07-13T22:48:45+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "bn"
}
-->
# Practical Implementation

প্র্যাকটিক্যাল ইমপ্লিমেন্টেশন হলো সেই জায়গা যেখানে Model Context Protocol (MCP)-এর শক্তি বাস্তবে স্পষ্ট হয়। MCP-এর তত্ত্ব এবং আর্কিটেকচার বোঝা অবশ্যই গুরুত্বপূর্ণ, কিন্তু প্রকৃত মূল্য তখনই আসে যখন আপনি এই ধারণাগুলো ব্যবহার করে বাস্তব সমস্যার সমাধান করতে পারেন, সেগুলো তৈরি, পরীক্ষা এবং ডিপ্লয় করেন। এই অধ্যায়টি ধারণাগত জ্ঞান এবং হাতে-কলমে উন্নয়নের মধ্যে সেতুবন্ধন রচনা করে, আপনাকে MCP-ভিত্তিক অ্যাপ্লিকেশনগুলো জীবন্ত করার প্রক্রিয়ায় গাইড করে।

আপনি যদি বুদ্ধিমান সহকারী তৈরি করেন, ব্যবসায়িক ওয়ার্কফ্লোতে AI ইন্টিগ্রেট করেন, অথবা ডেটা প্রসেসিংয়ের জন্য কাস্টম টুল তৈরি করেন, MCP একটি নমনীয় ভিত্তি প্রদান করে। এর ভাষা-নিরপেক্ষ ডিজাইন এবং জনপ্রিয় প্রোগ্রামিং ভাষার জন্য অফিসিয়াল SDK গুলো বিভিন্ন ধরণের ডেভেলপারদের জন্য সহজলভ্য করে তোলে। এই SDK গুলো ব্যবহার করে আপনি দ্রুত প্রোটোটাইপ তৈরি, পুনরাবৃত্তি এবং বিভিন্ন প্ল্যাটফর্ম ও পরিবেশে আপনার সমাধানগুলো স্কেল করতে পারবেন।

পরবর্তী অংশগুলোতে আপনি পাবেন প্র্যাকটিক্যাল উদাহরণ, স্যাম্পল কোড এবং ডিপ্লয়মেন্ট কৌশল যা দেখাবে কিভাবে MCP কে C#, Java, TypeScript, JavaScript, এবং Python এ ইমপ্লিমেন্ট করতে হয়। এছাড়াও শিখবেন কিভাবে MCP সার্ভার ডিবাগ ও টেস্ট করবেন, API গুলো ম্যানেজ করবেন, এবং Azure ব্যবহার করে ক্লাউডে সমাধানগুলো ডিপ্লয় করবেন। এই হাতে-কলমে রিসোর্সগুলো আপনার শেখার গতি বাড়াবে এবং আত্মবিশ্বাসের সাথে শক্তিশালী, প্রোডাকশন-রেডি MCP অ্যাপ্লিকেশন তৈরি করতে সাহায্য করবে।

## Overview

এই লেসনটি MCP ইমপ্লিমেন্টেশনের প্র্যাকটিক্যাল দিকগুলো বিভিন্ন প্রোগ্রামিং ভাষায় কভার করে। আমরা দেখব কিভাবে MCP SDK গুলো C#, Java, TypeScript, JavaScript, এবং Python এ ব্যবহার করে শক্তিশালী অ্যাপ্লিকেশন তৈরি করা যায়, MCP সার্ভার ডিবাগ ও টেস্ট করা যায়, এবং রিইউজেবল রিসোর্স, প্রম্পট এবং টুল তৈরি করা যায়।

## Learning Objectives

এই লেসনের শেষে আপনি সক্ষম হবেন:
- বিভিন্ন প্রোগ্রামিং ভাষায় অফিসিয়াল SDK ব্যবহার করে MCP সমাধান ইমপ্লিমেন্ট করতে
- MCP সার্ভারগুলো সিস্টেম্যাটিকভাবে ডিবাগ ও টেস্ট করতে
- সার্ভার ফিচার (Resources, Prompts, এবং Tools) তৈরি ও ব্যবহার করতে
- জটিল কাজের জন্য কার্যকর MCP ওয়ার্কফ্লো ডিজাইন করতে
- পারফরম্যান্স এবং নির্ভরযোগ্যতার জন্য MCP ইমপ্লিমেন্টেশন অপটিমাইজ করতে

## Official SDK Resources

Model Context Protocol বিভিন্ন ভাষার জন্য অফিসিয়াল SDK প্রদান করে:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Working with MCP SDKs

এই অংশে MCP বিভিন্ন প্রোগ্রামিং ভাষায় ইমপ্লিমেন্ট করার প্র্যাকটিক্যাল উদাহরণ দেওয়া হয়েছে। আপনি `samples` ডিরেক্টরিতে ভাষা অনুযায়ী সংগঠিত স্যাম্পল কোড পাবেন।

### Available Samples

রিপোজিটরিতে নিম্নলিখিত ভাষায় [স্যাম্পল ইমপ্লিমেন্টেশন](../../../04-PracticalImplementation/samples) অন্তর্ভুক্ত:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

প্রতিটি স্যাম্পল নির্দিষ্ট ভাষা ও ইকোসিস্টেমের জন্য MCP-এর মূল ধারণা এবং ইমপ্লিমেন্টেশন প্যাটার্নগুলো প্রদর্শন করে।

## Core Server Features

MCP সার্ভারগুলো নিম্নলিখিত ফিচারগুলোর যেকোনো সংমিশ্রণ ইমপ্লিমেন্ট করতে পারে:

### Resources
Resources ব্যবহারকারী বা AI মডেলের জন্য প্রসঙ্গ এবং ডেটা প্রদান করে:
- ডকুমেন্ট রিপোজিটরি
- জ্ঞানভিত্তিক বেস
- স্ট্রাকচার্ড ডেটা সোর্স
- ফাইল সিস্টেম

### Prompts
Prompts হলো ব্যবহারকারীদের জন্য টেমপ্লেটেড মেসেজ এবং ওয়ার্কফ্লো:
- পূর্বনির্ধারিত কথোপকথন টেমপ্লেট
- গাইডেড ইন্টারঅ্যাকশন প্যাটার্ন
- বিশেষায়িত সংলাপ কাঠামো

### Tools
Tools হলো AI মডেলের জন্য কার্যকরী ফাংশন:
- ডেটা প্রসেসিং ইউটিলিটি
- এক্সটার্নাল API ইন্টিগ্রেশন
- গণনামূলক ক্ষমতা
- সার্চ ফাংশনালিটি

## Sample Implementations: C#

অফিসিয়াল C# SDK রিপোজিটরিতে MCP-এর বিভিন্ন দিক প্রদর্শন করে বেশ কিছু স্যাম্পল ইমপ্লিমেন্টেশন রয়েছে:

- **Basic MCP Client**: MCP ক্লায়েন্ট তৈরি এবং টুল কল করার সহজ উদাহরণ
- **Basic MCP Server**: বেসিক টুল রেজিস্ট্রেশন সহ মিনিমাল সার্ভার ইমপ্লিমেন্টেশন
- **Advanced MCP Server**: টুল রেজিস্ট্রেশন, অথেনটিকেশন এবং এরর হ্যান্ডলিং সহ পূর্ণাঙ্গ সার্ভার
- **ASP.NET Integration**: ASP.NET Core এর সাথে ইন্টিগ্রেশনের উদাহরণ
- **Tool Implementation Patterns**: বিভিন্ন জটিলতার টুল ইমপ্লিমেন্টেশনের প্যাটার্ন

MCP C# SDK এখনো প্রিভিউ অবস্থায় এবং API গুলো পরিবর্তিত হতে পারে। SDK এর উন্নয়নের সাথে সাথে এই ব্লগ আপডেট করা হবে।

### Key Features 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- আপনার [প্রথম MCP সার্ভার তৈরি](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/) করার গাইড।

সম্পূর্ণ C# ইমপ্লিমেন্টেশন স্যাম্পল দেখতে, অফিসিয়াল C# SDK স্যাম্পল রিপোজিটরি দেখুন: [https://github.com/modelcontextprotocol/csharp-sdk](https://github.com/modelcontextprotocol/csharp-sdk)

## Sample implementation: Java Implementation

Java SDK MCP ইমপ্লিমেন্টেশনের জন্য শক্তিশালী এবং এন্টারপ্রাইজ-গ্রেড ফিচার প্রদান করে।

### Key Features

- Spring Framework ইন্টিগ্রেশন
- শক্তিশালী টাইপ সেফটি
- রিয়েক্টিভ প্রোগ্রামিং সাপোর্ট
- ব্যাপক এরর হ্যান্ডলিং

সম্পূর্ণ Java ইমপ্লিমেন্টেশন স্যাম্পলের জন্য, স্যাম্পল ডিরেক্টরির [Java sample](samples/java/containerapp/README.md) দেখুন।

## Sample implementation: JavaScript Implementation

JavaScript SDK MCP ইমপ্লিমেন্টেশনের জন্য হালকা ও নমনীয় পদ্ধতি প্রদান করে।

### Key Features

- Node.js এবং ব্রাউজার সাপোর্ট
- Promise-ভিত্তিক API
- Express এবং অন্যান্য ফ্রেমওয়ার্কের সাথে সহজ ইন্টিগ্রেশন
- স্ট্রিমিংয়ের জন্য WebSocket সাপোর্ট

সম্পূর্ণ JavaScript ইমপ্লিমেন্টেশন স্যাম্পলের জন্য, স্যাম্পল ডিরেক্টরির [JavaScript sample](samples/javascript/README.md) দেখুন।

## Sample implementation: Python Implementation

Python SDK MCP ইমপ্লিমেন্টেশনের জন্য পাইথনিক পদ্ধতি এবং চমৎকার ML ফ্রেমওয়ার্ক ইন্টিগ্রেশন প্রদান করে।

### Key Features

- asyncio সহ Async/await সাপোর্ট
- Flask এবং FastAPI ইন্টিগ্রেশন
- সহজ টুল রেজিস্ট্রেশন
- জনপ্রিয় ML লাইব্রেরির সাথে নেটিভ ইন্টিগ্রেশন

সম্পূর্ণ Python ইমপ্লিমেন্টেশন স্যাম্পলের জন্য, স্যাম্পল ডিরেক্টরির [Python sample](samples/python/README.md) দেখুন।

## API management 

Azure API Management MCP সার্ভারগুলোকে সুরক্ষিত করার জন্য একটি চমৎকার সমাধান। ধারণাটি হলো আপনার MCP সার্ভারের সামনে একটি Azure API Management ইনস্ট্যান্স রাখা এবং এটি এমন ফিচারগুলো পরিচালনা করবে যা আপনি চাইবেন, যেমন:

- রেট লিমিটিং
- টোকেন ম্যানেজমেন্ট
- মনিটরিং
- লোড ব্যালেন্সিং
- সিকিউরিটি

### Azure Sample

এখানে একটি Azure Sample দেওয়া হয়েছে যা ঠিক এই কাজটি করে, অর্থাৎ MCP সার্ভার তৈরি এবং Azure API Management দিয়ে সুরক্ষিত করা: [https://github.com/Azure-Samples/remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

নিচের ছবিতে দেখুন অথরাইজেশন ফ্লো কিভাবে ঘটে:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

উপরের ছবিতে নিম্নলিখিত ঘটনা ঘটে:

- Microsoft Entra ব্যবহার করে Authentication/Authorization হয়।
- Azure API Management একটি গেটওয়ে হিসেবে কাজ করে এবং পলিসি ব্যবহার করে ট্রাফিক পরিচালনা করে।
- Azure Monitor সমস্ত রিকোয়েস্ট লগ করে পরবর্তী বিশ্লেষণের জন্য।

#### Authorization flow

আসুন অথরাইজেশন ফ্লো আরও বিস্তারিত দেখি:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

আরও জানুন [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) সম্পর্কে।

## Deploy Remote MCP Server to Azure

চলুন দেখি আমরা আগের উল্লেখিত স্যাম্পলটি ডিপ্লয় করতে পারি কিনা:

1. রিপো ক্লোন করুন

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. `Microsoft.App` রিসোর্স প্রোভাইডার রেজিস্টার করুন।
    * যদি আপনি Azure CLI ব্যবহার করেন, তাহলে চালান `az provider register --namespace Microsoft.App --wait`।
    * যদি Azure PowerShell ব্যবহার করেন, তাহলে চালান `Register-AzResourceProvider -ProviderNamespace Microsoft.App`। কিছুক্ষণ পর চালান `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` রেজিস্ট্রেশন সম্পন্ন হয়েছে কিনা যাচাই করার জন্য।

2. এই [azd](https://aka.ms/azd) কমান্ডটি চালান যা API Management সার্ভিস, ফাংশন অ্যাপ (কোডসহ) এবং অন্যান্য প্রয়োজনীয় Azure রিসোর্স প্রোভিশন করবে

    ```shell
    azd up
    ```

    এই কমান্ডটি Azure-এ সব ক্লাউড রিসোর্স ডিপ্লয় করবে।

### Testing your server with MCP Inspector

1. একটি **নতুন টার্মিনাল উইন্ডোতে**, MCP Inspector ইনস্টল ও চালান

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    আপনি নিচের মতো একটি ইন্টারফেস দেখতে পাবেন:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.bn.png) 

1. CTRL ক্লিক করে MCP Inspector ওয়েব অ্যাপটি লোড করুন URL থেকে যা অ্যাপ দেখাচ্ছে (যেমন http://127.0.0.1:6274/#resources)
1. ট্রান্সপোর্ট টাইপ `SSE` সেট করুন
1. URL সেট করুন আপনার চলমান API Management SSE এন্ডপয়েন্ট যা `azd up` কমান্ডের পরে দেখানো হয় এবং **Connect** করুন:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**। একটি টুলে ক্লিক করুন এবং **Run Tool** করুন।  

যদি সব ধাপ সঠিকভাবে সম্পন্ন হয়, তাহলে আপনি MCP সার্ভারের সাথে সংযুক্ত হয়েছেন এবং একটি টুল কল করতে পেরেছেন।

## MCP servers for Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): এই সেট রিপোজিটরি দ্রুত শুরু করার টেমপ্লেট হিসেবে কাজ করে যা Azure Functions ব্যবহার করে Python, C# .NET বা Node/TypeScript দিয়ে কাস্টম রিমোট MCP সার্ভার তৈরি ও ডিপ্লয় করার জন্য।

স্যাম্পলগুলো একটি পূর্ণাঙ্গ সমাধান প্রদান করে যা ডেভেলপারদের সক্ষম করে:

- লোকালি তৈরি ও চালানো: একটি MCP সার্ভার লোকাল মেশিনে ডেভেলপ ও ডিবাগ করা
- Azure-এ ডিপ্লয় করা: সহজে ক্লাউডে ডিপ্লয় করা একটি সরল azd up কমান্ড দিয়ে
- ক্লায়েন্ট থেকে সংযোগ: বিভিন্ন ক্লায়েন্ট থেকে MCP সার্ভারের সাথে সংযোগ করা, যেমন VS Code এর Copilot এজেন্ট মোড এবং MCP Inspector টুল

### Key Features:

- ডিজাইন থেকে নিরাপত্তা: MCP সার্ভার কী এবং HTTPS ব্যবহার করে সুরক্ষিত
- অথেনটিকেশন অপশন: বিল্ট-ইন অথ এবং/অথবা API Management ব্যবহার করে OAuth সাপোর্ট
- নেটওয়ার্ক আইসোলেশন: Azure Virtual Networks (VNET) ব্যবহার করে নেটওয়ার্ক আইসোলেশন
- সার্ভারলেস আর্কিটেকচার: স্কেলেবল, ইভেন্ট-চালিত এক্সিকিউশনের জন্য Azure Functions ব্যবহার
- লোকাল ডেভেলপমেন্ট: ব্যাপক লোকাল ডেভেলপমেন্ট এবং ডিবাগিং সাপোর্ট
- সহজ ডিপ্লয়মেন্ট: Azure-এ স্ট্রিমলাইনড ডিপ্লয়মেন্ট প্রসেস

রিপোজিটরিতে সব প্রয়োজনীয় কনফিগারেশন ফাইল, সোর্স কোড এবং ইনফ্রাস্ট্রাকচার ডেফিনিশন রয়েছে যা দ্রুত প্রোডাকশন-রেডি MCP সার্ভার ইমপ্লিমেন্টেশন শুরু করতে সাহায্য করে।

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python দিয়ে Azure Functions ব্যবহার করে MCP এর স্যাম্পল ইমপ্লিমেন্টেশন

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET দিয়ে Azure Functions ব্যবহার করে MCP এর স্যাম্পল ইমপ্লিমেন্টেশন

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScript দিয়ে Azure Functions ব্যবহার করে MCP এর স্যাম্পল ইমপ্লিমেন্টেশন

## Key Takeaways

- MCP SDK গুলো ভাষা-নির্দিষ্ট টুল প্রদান করে শক্তিশালী MCP সমাধান ইমপ্লিমেন্ট করার জন্য
- ডিবাগিং এবং টেস্টিং প্রক্রিয়া নির্ভরযোগ্য MCP অ্যাপ্লিকেশনের জন্য অত্যন্ত গুরুত্বপূর্ণ
- রিইউজেবল প্রম্পট টেমপ্লেট AI ইন্টারঅ্যাকশনগুলোকে ধারাবাহিক করে তোলে
- ভালো ডিজাইনকৃত ওয়ার্কফ্লো জটিল কাজগুলো একাধিক টুল ব্যবহার করে সমন্বয় করতে পারে
- MCP সমাধান ইমপ্লিমেন্টেশনে নিরাপত্তা, পারফরম্যান্স এবং এরর হ্যান্ডলিং বিবেচনা করা প্রয়োজন

## Exercise

আপনার ডোমেইনে একটি বাস্তব সমস্যার সমাধান করার জন্য একটি প্র্যাকটিক্যাল MCP ওয়ার্কফ্লো ডিজাইন করুন:

1. ৩-৪টি টুল চিহ্নিত করুন যা এই সমস্যার সমাধানে সহায়ক হবে
2. একটি ওয়ার্কফ্লো ডায়াগ্রাম তৈরি করুন যা দেখাবে কিভাবে এই টুলগুলো একে অপরের সাথে ইন্টারঅ্যাক্ট করে
3. আপনার পছন্দের ভাষায় একটি টুলের বেসিক ভার্সন ইমপ্লিমেন্ট করুন
4. একটি প্রম্পট টেমপ্লেট তৈরি করুন যা মডেলকে আপনার টুল কার্যকরভাবে ব্যবহার করতে সাহায্য করবে

## Additional Resources


---

Next: [Advanced Topics](../05-AdvancedTopics/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।