<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:07:47+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "bn"
}
-->
# Practical Implementation

প্রায়োগিক বাস্তবায়ন হল যেখানে Model Context Protocol (MCP)-এর শক্তি স্পষ্ট হয়। MCP-এর তত্ত্ব এবং স্থাপত্য বোঝা গুরুত্বপূর্ণ হলেও, প্রকৃত মূল্য তখনই প্রকাশ পায় যখন আপনি এই ধারণাগুলো ব্যবহার করে বাস্তব সমস্যা সমাধানের জন্য সমাধান তৈরি, পরীক্ষা এবং স্থাপন করেন। এই অধ্যায়টি ধারণাগত জ্ঞান এবং হাতে-কলমে উন্নয়নের মধ্যে সেতুবন্ধন তৈরি করে, আপনাকে MCP-ভিত্তিক অ্যাপ্লিকেশনগুলো বাস্তবায়নের প্রক্রিয়ায় পথপ্রদর্শন করে।

আপনি যদি বুদ্ধিমান সহকারী তৈরি করেন, ব্যবসায়িক ওয়ার্কফ্লোতে AI সংহত করেন, অথবা ডেটা প্রক্রিয়াকরণের জন্য কাস্টম টুল তৈরি করেন, MCP একটি নমনীয় ভিত্তি প্রদান করে। এর ভাষা-নিরপেক্ষ নকশা এবং জনপ্রিয় প্রোগ্রামিং ভাষার জন্য অফিসিয়াল SDK গুলো এটি বিভিন্ন ধরণের ডেভেলপারদের কাছে সহজলভ্য করে তোলে। এই SDK গুলো ব্যবহার করে আপনি দ্রুত প্রোটোটাইপ তৈরি, পুনরাবৃত্তি এবং বিভিন্ন প্ল্যাটফর্ম ও পরিবেশে আপনার সমাধান স্কেল করতে পারবেন।

পরবর্তী অংশগুলোতে আপনি ব্যবহারিক উদাহরণ, নমুনা কোড এবং ডিপ্লয়মেন্ট কৌশল পাবেন যা দেখাবে কীভাবে C#, Java, TypeScript, JavaScript, এবং Python-এ MCP বাস্তবায়ন করবেন। এছাড়াও আপনি শিখবেন কীভাবে MCP সার্ভার ডিবাগ এবং পরীক্ষা করবেন, API পরিচালনা করবেন এবং Azure ব্যবহার করে ক্লাউডে সমাধান স্থাপন করবেন। এই হাতে-কলমে রিসোর্সগুলো আপনার শেখার গতি বাড়াতে এবং আত্মবিশ্বাসের সঙ্গে মজবুত, প্রোডাকশন-রেডি MCP অ্যাপ্লিকেশন তৈরি করতে সাহায্য করবে।

## Overview

এই পাঠটি MCP বাস্তবায়নের ব্যবহারিক দিকগুলো বিভিন্ন প্রোগ্রামিং ভাষায় ফোকাস করে। আমরা দেখব কীভাবে C#, Java, TypeScript, JavaScript, এবং Python-এ MCP SDK ব্যবহার করে মজবুত অ্যাপ্লিকেশন তৈরি, MCP সার্ভার ডিবাগ ও পরীক্ষা এবং পুনঃব্যবহারযোগ্য রিসোর্স, প্রম্পট এবং টুল তৈরি করা যায়।

## Learning Objectives

এই পাঠ শেষে আপনি সক্ষম হবেন:
- বিভিন্ন প্রোগ্রামিং ভাষায় অফিসিয়াল SDK ব্যবহার করে MCP সমাধান বাস্তবায়ন করতে
- MCP সার্ভারগুলো সিস্টেম্যাটিকভাবে ডিবাগ এবং পরীক্ষা করতে
- সার্ভার ফিচার (Resources, Prompts, এবং Tools) তৈরি ও ব্যবহার করতে
- জটিল কাজের জন্য কার্যকর MCP ওয়ার্কফ্লো ডিজাইন করতে
- পারফরম্যান্স এবং নির্ভরযোগ্যতার জন্য MCP বাস্তবায়ন অপ্টিমাইজ করতে

## Official SDK Resources

Model Context Protocol বিভিন্ন ভাষার জন্য অফিসিয়াল SDK প্রদান করে:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Working with MCP SDKs

এই অংশে MCP বিভিন্ন প্রোগ্রামিং ভাষায় বাস্তবায়নের ব্যবহারিক উদাহরণ দেওয়া হয়েছে। আপনি `samples` ডিরেক্টরিতে ভাষা অনুযায়ী সংগঠিত নমুনা কোড দেখতে পারবেন।

### Available Samples

রিপোজিটরিটিতে নিম্নলিখিত ভাষায় নমুনা বাস্তবায়ন অন্তর্ভুক্ত রয়েছে:

- C#
- Java
- TypeScript
- JavaScript
- Python

প্রতিটি নমুনা নির্দিষ্ট ভাষা ও ইকোসিস্টেমের জন্য MCP-এর মূল ধারণা এবং বাস্তবায়ন প্যাটার্ন দেখায়।

## Core Server Features

MCP সার্ভারগুলো নিম্নলিখিত ফিচারগুলোর যেকোনো সংমিশ্রণ বাস্তবায়ন করতে পারে:

### Resources  
Resources ব্যবহারকারী বা AI মডেলের জন্য প্রসঙ্গ এবং ডেটা প্রদান করে:  
- ডকুমেন্ট সংগ্রহস্থল  
- জ্ঞানভিত্তিক ডাটাবেস  
- গঠনমূলক ডেটা উৎস  
- ফাইল সিস্টেম  

### Prompts  
Prompts হল ব্যবহারকারীর জন্য টেমপ্লেট করা বার্তা এবং ওয়ার্কফ্লো:  
- পূর্বনির্ধারিত কথোপকথন টেমপ্লেট  
- পরিচালিত ইন্টারঅ্যাকশন প্যাটার্ন  
- বিশেষায়িত সংলাপ কাঠামো  

### Tools  
Tools হল AI মডেলের জন্য কার্যকরী ফাংশন:  
- ডেটা প্রক্রিয়াকরণ সরঞ্জাম  
- বাহ্যিক API সংহতকরণ  
- গণনামূলক ক্ষমতা  
- অনুসন্ধান কার্যকারিতা  

## Sample Implementations: C#

অফিসিয়াল C# SDK রিপোজিটরিতে MCP-এর বিভিন্ন দিক প্রদর্শন করে কয়েকটি নমুনা বাস্তবায়ন রয়েছে:

- **Basic MCP Client**: MCP ক্লায়েন্ট তৈরি এবং টুল কল করার সরল উদাহরণ  
- **Basic MCP Server**: মৌলিক টুল রেজিস্ট্রেশন সহ সর্বনিম্ন সার্ভার বাস্তবায়ন  
- **Advanced MCP Server**: টুল রেজিস্ট্রেশন, প্রমাণীকরণ, এবং ত্রুটি পরিচালনা সহ সম্পূর্ণ ফিচারযুক্ত সার্ভার  
- **ASP.NET Integration**: ASP.NET Core এর সাথে সংহত করার উদাহরণ  
- **Tool Implementation Patterns**: বিভিন্ন জটিলতার টুল বাস্তবায়নের বিভিন্ন প্যাটার্ন  

MCP C# SDK প্রিভিউ অবস্থায় রয়েছে এবং API গুলো পরিবর্তিত হতে পারে। SDK উন্নয়নের সাথে সাথে আমরা এই ব্লগটি নিয়মিত আপডেট করব।

### Key Features  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- আপনার [প্রথম MCP সার্ভার তৈরি](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/) করার জন্য নির্দেশনা।

সম্পূর্ণ C# বাস্তবায়ন নমুনার জন্য দেখুন [অফিসিয়াল C# SDK নমুনা রিপোজিটরি](https://github.com/modelcontextprotocol/csharp-sdk)

## Sample implementation: Java Implementation

Java SDK শক্তিশালী MCP বাস্তবায়নের অপশন এবং এন্টারপ্রাইজ-গ্রেড ফিচার সরবরাহ করে।

### Key Features

- Spring Framework সংহতকরণ  
- শক্তিশালী টাইপ সেফটি  
- রিয়েক্টিভ প্রোগ্রামিং সাপোর্ট  
- ব্যাপক ত্রুটি পরিচালনা  

সম্পূর্ণ Java বাস্তবায়ন নমুনার জন্য দেখুন [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) ফাইলটি।

## Sample implementation: JavaScript Implementation

JavaScript SDK একটি হালকা এবং নমনীয় MCP বাস্তবায়নের পদ্ধতি দেয়।

### Key Features

- Node.js এবং ব্রাউজার সাপোর্ট  
- Promise-ভিত্তিক API  
- Express এবং অন্যান্য ফ্রেমওয়ার্কের সাথে সহজ সংহতকরণ  
- স্ট্রিমিংয়ের জন্য WebSocket সাপোর্ট  

সম্পূর্ণ JavaScript বাস্তবায়ন নমুনার জন্য দেখুন [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) ফাইলটি।

## Sample implementation: Python Implementation

Python SDK MCP বাস্তবায়নের জন্য Pythonic পদ্ধতি এবং চমৎকার ML ফ্রেমওয়ার্ক সংহতকরণ প্রদান করে।

### Key Features

- Async/await সাপোর্ট asyncio-র মাধ্যমে  
- Flask এবং FastAPI সংহতকরণ  
- সহজ টুল রেজিস্ট্রেশন  
- জনপ্রিয় ML লাইব্রেরির সাথে নেটিভ সংহতকরণ  

সম্পূর্ণ Python বাস্তবায়ন নমুনার জন্য দেখুন [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) ফাইলটি।

## API management 

Azure API Management MCP সার্ভারগুলোকে নিরাপদ রাখার জন্য একটি চমৎকার সমাধান। ধারণাটি হল MCP সার্ভারের সামনে একটি Azure API Management ইনস্ট্যান্স রাখা এবং এটি নিচের মতো ফিচারগুলো পরিচালনা করতে দেয়:

- রেট লিমিটিং  
- টোকেন ম্যানেজমেন্ট  
- মনিটরিং  
- লোড ব্যালেন্সিং  
- নিরাপত্তা  

### Azure Sample

নিচের Azure Sample-টি ঠিক এটি করে, অর্থাৎ MCP সার্ভার তৈরি এবং Azure API Management দিয়ে নিরাপদ করা। ([লিঙ্ক](https://github.com/Azure-Samples/remote-mcp-apim-functions-python))

নিচের ছবিতে অনুমোদন প্রবাহ কিভাবে ঘটে তা দেখুন:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

উপরের ছবিতে নিম্নলিখিত কাজগুলো ঘটে:

- Microsoft Entra ব্যবহার করে প্রমাণীকরণ/অনুমোদন সম্পন্ন হয়।  
- Azure API Management একটি গেটওয়ে হিসেবে কাজ করে এবং নীতি ব্যবহার করে ট্রাফিক পরিচালনা করে।  
- Azure Monitor সমস্ত অনুরোধ লগ করে পরবর্তী বিশ্লেষণের জন্য।  

#### Authorization flow

অনুমোদন প্রবাহটি আরও বিস্তারিতভাবে দেখা যাক:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

আরও জানুন [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Deploy Remote MCP Server to Azure

আগে উল্লেখিত নমুনাটি Azure-তে ডিপ্লয় করা যায় কিনা দেখি:

1. রিপো ক্লোন করুন

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` রেজিস্টার করুন:  

    `` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`  

    কিছুক্ষণ পর যাচাই করুন রেজিস্ট্রেশন সম্পন্ন হয়েছে কিনা।

3. এই [azd](https://aka.ms/azd) কমান্ডটি চালান যা API Management সার্ভিস, ফাংশন অ্যাপ (কোডসহ) এবং অন্যান্য প্রয়োজনীয় Azure রিসোর্স প্রোভিশন করবে:

    ```shell
    azd up
    ```

    এই কমান্ডটি Azure-তে সব ক্লাউড রিসোর্স ডিপ্লয় করবে।

### Testing your server with MCP Inspector

1. একটি **নতুন টার্মিনাল উইন্ডোতে** MCP Inspector ইনস্টল এবং চালান:

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    আপনি নিম্নলিখিত মত একটি ইন্টারফেস দেখতে পাবেন:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.bn.png) 

2. CTRL ক্লিক করে MCP Inspector ওয়েব অ্যাপটি লোড করুন প্রদর্শিত URL থেকে (যেমন http://127.0.0.1:6274/#resources)  
3. ট্রান্সপোর্ট টাইপ `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` সেট করুন এবং **Connect** করুন:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools** দেখুন। একটি টুলে ক্লিক করে **Run Tool** করুন।  

যদি সব ধাপ সফল হয়, তাহলে আপনি MCP সার্ভারের সাথে সংযুক্ত হয়েছেন এবং একটি টুল কল করতে পেরেছেন।

## MCP servers for Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): এই সেট রিপোজিটরি দ্রুত শুরু করার টেমপ্লেট সরবরাহ করে যা Python, C# .NET অথবা Node/TypeScript ব্যবহার করে Azure Functions-এর মাধ্যমে কাস্টম রিমোট MCP (Model Context Protocol) সার্ভার তৈরি ও ডিপ্লয় করতে সাহায্য করে।

নমুনাগুলো একটি সম্পূর্ণ সমাধান দেয় যা ডেভেলপারদের সক্ষম করে:

- লোকালি তৈরি ও চালনা: লোকাল মেশিনে MCP সার্ভার ডেভেলপ এবং ডিবাগ করা  
- Azure-তে ডিপ্লয়: সহজেই azd up কমান্ড দিয়ে ক্লাউডে ডিপ্লয় করা  
- ক্লায়েন্ট থেকে সংযোগ: VS Code-এর Copilot এজেন্ট মোড এবং MCP Inspector টুলসহ বিভিন্ন ক্লায়েন্ট থেকে MCP সার্ভারে সংযোগ করা  

### Key Features:

- ডিজাইনে নিরাপত্তা: MCP সার্ভার কী এবং HTTPS ব্যবহার করে সুরক্ষিত  
- প্রমাণীকরণ বিকল্প: বিল্ট-ইন auth এবং/অথবা API Management ব্যবহার করে OAuth সাপোর্ট  
- নেটওয়ার্ক বিচ্ছিন্নতা: Azure Virtual Networks (VNET) ব্যবহার করে নেটওয়ার্ক বিচ্ছিন্নতা  
- সার্ভারলেস স্থাপত্য: Azure Functions ব্যবহার করে স্কেলযোগ্য, ইভেন্ট-চালিত এক্সিকিউশন  
- লোকাল ডেভেলপমেন্ট: ব্যাপক লোকাল ডেভেলপমেন্ট এবং ডিবাগিং সাপোর্ট  
- সহজ ডিপ্লয়মেন্ট: Azure-তে ডিপ্লয়মেন্ট প্রক্রিয়া সরল করা  

রিপোজিটরিতে সব প্রয়োজনীয় কনফিগারেশন ফাইল, সোর্স কোড, এবং অবকাঠামো সংজ্ঞা রয়েছে যাতে দ্রুত প্রোডাকশন-রেডি MCP সার্ভার বাস্তবায়ন শুরু করা যায়।

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python ব্যবহার করে Azure Functions-এর মাধ্যমে MCP বাস্তবায়নের নমুনা  
- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET ব্যবহার করে Azure Functions-এর মাধ্যমে MCP বাস্তবায়নের নমুনা  
- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScript ব্যবহার করে Azure Functions-এর মাধ্যমে MCP বাস্তবায়নের নমুনা  

## Key Takeaways

- MCP SDK গুলো ভাষা-নির্দিষ্ট টুল সরবরাহ করে যা মজবুত MCP সমাধান বাস্তবায়নে সহায়ক  
- ডিবাগিং এবং পরীক্ষার প্রক্রিয়া নির্ভরযোগ্য MCP অ্যাপ্লিকেশনের জন্য অপরিহার্য  
- পুনঃব্যবহারযোগ্য প্রম্পট টেমপ্লেট AI ইন্টারঅ্যাকশনকে ধারাবাহিক করে তোলে  
- ভালো ডিজাইনকৃত ওয়ার্কফ্লো একাধিক টুল ব্যবহার করে জটিল কাজ পরিচালনা করতে পারে  
- MCP সমাধান বাস্তবায়নে নিরাপত্তা, পারফরম্যান্স এবং ত্রুটি পরিচালনা বিবেচনা করা জরুরি  

## Exercise

আপনার ডোমেইনে একটি বাস্তব সমস্যার সমাধান করতে একটি ব্যবহারিক MCP ওয়ার্কফ্লো ডিজাইন করুন:

1. এই সমস্যার সমাধানে সহায়ক ৩-৪টি টুল সনাক্ত করুন  
2. একটি ওয়ার্কফ্লো ডায়াগ্রাম তৈরি করুন যা দেখায় এই টুলগুলো কিভাবে ইন্টারঅ্যাক্ট করে  
3. আপনার পছন্দের ভাষায় একটি টুলের মৌলিক সংস্করণ বাস্তবায়ন করুন  
4. এমন একটি প্রম্পট টেমপ্লেট তৈরি করুন যা মডেলকে আপনার টুল কার্যকরভাবে ব্যবহারে সাহায্য করবে  

## Additional Resources


---

Next: [Advanced Topics](../05-AdvancedTopics/README.md)

**অস্বীকারোক্তি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে অনুগ্রহ করে জানুন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা ভুল থাকতে পারে। মূল নথিটি তার স্বাভাবিক ভাষায়ই কর্তৃত্বপ্রাপ্ত উৎস হিসাবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়বদ্ধ নই।