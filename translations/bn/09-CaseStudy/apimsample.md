<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:28:44+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "bn"
}
-->
# Case Study: API Management-এ MCP সার্ভার হিসেবে REST API প্রকাশ করা

Azure API Management হলো একটি সার্ভিস যা আপনার API Endpoints-এর উপরে একটি গেটওয়ে প্রদান করে। এটি কাজ করে এমনভাবে যে Azure API Management আপনার API-এর সামনে একটি প্রক্সি হিসেবে কাজ করে এবং আসা অনুরোধগুলোর জন্য সিদ্ধান্ত নিতে পারে।

এটি ব্যবহার করে আপনি অনেক ধরনের ফিচার পেতে পারেন, যেমন:

- **সিকিউরিটি**, আপনি API কী, JWT থেকে ম্যানেজড আইডেন্টিটি পর্যন্ত সবকিছু ব্যবহার করতে পারেন।
- **রেট লিমিটিং**, একটি চমৎকার ফিচার যা নির্ধারণ করতে দেয় কতগুলো কল নির্দিষ্ট সময়ের মধ্যে পার হতে পারবে। এটি নিশ্চিত করে যে সব ব্যবহারকারীর অভিজ্ঞতা ভালো হয় এবং আপনার সার্ভিস অতিরিক্ত অনুরোধে ভরাট হয় না।
- **স্কেলিং ও লোড ব্যালান্সিং**। আপনি একাধিক এন্ডপয়েন্ট সেটআপ করতে পারেন লোড ব্যালান্স করার জন্য এবং লোড ব্যালান্সিং কিভাবে হবে তাও নির্ধারণ করতে পারেন।
- **AI ফিচার যেমন সেমান্টিক ক্যাশিং**, টোকেন লিমিট এবং টোকেন মনিটরিং ইত্যাদি। এগুলো রেসপন্সিভনেস বাড়ায় এবং আপনার টোকেন খরচের উপর নজর রাখতে সাহায্য করে। [এখানে আরও পড়ুন](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities)।

## কেন MCP + Azure API Management?

Model Context Protocol দ্রুত এজেন্টিক AI অ্যাপ্লিকেশনগুলোর জন্য একটি স্ট্যান্ডার্ড হয়ে উঠছে এবং টুল ও ডেটা ধারাবাহিকভাবে প্রকাশ করার উপায়। যখন আপনাকে API "ম্যানেজ" করতে হয়, তখন Azure API Management একটি স্বাভাবিক পছন্দ। MCP সার্ভারগুলো প্রায়ই অন্যান্য API-এর সাথে ইন্টিগ্রেট করে টুলের জন্য অনুরোধ সমাধান করে। তাই Azure API Management এবং MCP একসাথে ব্যবহার করা খুবই যুক্তিযুক্ত।

## ওভারভিউ

এই নির্দিষ্ট ব্যবহারের ক্ষেত্রে আমরা শিখব কিভাবে API এন্ডপয়েন্টগুলো MCP সার্ভার হিসেবে প্রকাশ করতে হয়। এর মাধ্যমে আমরা সহজেই এই এন্ডপয়েন্টগুলোকে একটি এজেন্টিক অ্যাপের অংশ করতে পারব এবং Azure API Management-এর ফিচারগুলোও ব্যবহার করতে পারব।

## মূল ফিচারসমূহ

- আপনি যেসব এন্ডপয়েন্ট মেথড টুল হিসেবে প্রকাশ করতে চান সেগুলো নির্বাচন করবেন।
- অতিরিক্ত ফিচারগুলো নির্ভর করে আপনি API-এর পলিসি সেকশনে কী কনফিগার করেন তার উপর। এখানে আমরা দেখাবো কিভাবে রেট লিমিটিং যোগ করবেন।

## প্রি-স্টেপ: একটি API ইমপোর্ট করা

যদি আপনার Azure API Management-এ ইতিমধ্যে একটি API থাকে, তাহলে এই ধাপটি স্কিপ করতে পারেন। না থাকলে, এই লিঙ্কটি দেখুন, [Azure API Management-এ API ইমপোর্ট করা](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api)।

## MCP সার্ভার হিসেবে API প্রকাশ করা

API এন্ডপয়েন্টগুলো প্রকাশ করতে নিচের ধাপগুলো অনুসরণ করুন:

1. Azure Portal-এ যান এবং এই ঠিকানায় যান <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
আপনার API Management ইনস্ট্যান্সে নেভিগেট করুন।

1. বাম মেনু থেকে APIs > MCP Servers > + Create new MCP Server নির্বাচন করুন।

1. API-তে একটি REST API নির্বাচন করুন যা MCP সার্ভার হিসেবে প্রকাশ করবেন।

1. একটি বা একাধিক API অপারেশন নির্বাচন করুন যেগুলো টুল হিসেবে প্রকাশ করতে চান। আপনি সব অপারেশন বা নির্দিষ্ট অপারেশন নির্বাচন করতে পারেন।

    ![Select methods to expose](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. **Create** নির্বাচন করুন।

1. মেনু থেকে **APIs** এবং **MCP Servers**-এ যান, আপনি নিচের মত দেখতে পাবেন:

    ![See the MCP Server in the main pane](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP সার্ভার তৈরি হয়েছে এবং API অপারেশনগুলো টুল হিসেবে প্রকাশিত হয়েছে। MCP সার্ভার MCP Servers পেন-এ তালিকাভুক্ত থাকবে। URL কলামটি MCP সার্ভারের এন্ডপয়েন্ট দেখায় যা আপনি টেস্টিং বা ক্লায়েন্ট অ্যাপ্লিকেশনে কল করতে পারবেন।

## ঐচ্ছিক: পলিসি কনফিগার করা

Azure API Management-এর মূল ধারণা হলো পলিসি, যেখানে আপনি আপনার এন্ডপয়েন্টের জন্য বিভিন্ন নিয়ম সেট করেন যেমন রেট লিমিটিং বা সেমান্টিক ক্যাশিং। এই পলিসিগুলো XML ফরম্যাটে লেখা হয়।

আপনার MCP সার্ভারের জন্য রেট লিমিট পলিসি কনফিগার করার ধাপগুলো:

1. পোর্টালে APIs এর অধীনে **MCP Servers** নির্বাচন করুন।

1. আপনি যে MCP সার্ভার তৈরি করেছেন সেটি নির্বাচন করুন।

1. বাম মেনু থেকে MCP এর অধীনে **Policies** নির্বাচন করুন।

1. পলিসি এডিটরে আপনি MCP সার্ভারের টুলগুলোর জন্য প্রযোজ্য পলিসি যোগ বা সম্পাদনা করতে পারেন। পলিসিগুলো XML ফরম্যাটে থাকে। উদাহরণস্বরূপ, আপনি একটি পলিসি যোগ করতে পারেন যা MCP সার্ভারের টুলগুলোর কল সীমাবদ্ধ করবে (এই উদাহরণে, প্রতি ক্লায়েন্ট IP ঠিকানায় ৩০ সেকেন্ডে ৫ কল)। নিচে XML কোডটি দেখানো হলো যা রেট লিমিট করবে:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    পলিসি এডিটরের একটি ছবি:

    ![Policy editor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## চেষ্টা করে দেখুন

চলুন নিশ্চিত করি আমাদের MCP সার্ভার ঠিকমতো কাজ করছে।

এর জন্য আমরা Visual Studio Code এবং GitHub Copilot-এর Agent মোড ব্যবহার করব। আমরা MCP সার্ভারটি *mcp.json* এ যোগ করব। এর ফলে Visual Studio Code একটি এজেন্টিক ক্ষমতাসম্পন্ন ক্লায়েন্ট হিসেবে কাজ করবে এবং শেষ ব্যবহারকারীরা প্রম্পট টাইপ করে সার্ভারের সাথে ইন্টারঅ্যাক্ট করতে পারবে।

Visual Studio Code-এ MCP সার্ভার যোগ করার ধাপগুলো:

1. Command Palette থেকে MCP: **Add Server কমান্ড** ব্যবহার করুন।

1. প্রম্পট এলে সার্ভার টাইপ নির্বাচন করুন: **HTTP (HTTP or Server Sent Events)**।

1. API Management-এ MCP সার্ভারের URL দিন। উদাহরণ: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (SSE এন্ডপয়েন্টের জন্য) অথবা **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (MCP এন্ডপয়েন্টের জন্য), লক্ষ্য করুন ট্রান্সপোর্টের পার্থক্য `/sse` বা `/mcp`।

1. আপনার পছন্দমতো একটি সার্ভার ID দিন। এটি গুরুত্বপূর্ণ নয়, তবে এটি সার্ভার ইনস্ট্যান্সটি চিনতে সাহায্য করবে।

1. নির্বাচন করুন কনফিগারেশন কোথায় সংরক্ষণ করবেন: ওয়ার্কস্পেস সেটিংস বা ইউজার সেটিংস।

  - **ওয়ার্কস্পেস সেটিংস** - সার্ভার কনফিগারেশন শুধুমাত্র বর্তমান ওয়ার্কস্পেসের .vscode/mcp.json ফাইলে সংরক্ষিত হয়।

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    অথবা যদি আপনি স্ট্রিমিং HTTP ট্রান্সপোর্ট নির্বাচন করেন, তাহলে কিছুটা ভিন্ন হবে:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **ইউজার সেটিংস** - সার্ভার কনফিগারেশন আপনার গ্লোবাল *settings.json* ফাইলে যোগ হয় এবং সব ওয়ার্কস্পেসে উপলব্ধ থাকে। কনফিগারেশন দেখতে নিচের মত:

    ![User setting](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. এছাড়াও আপনাকে একটি হেডার যোগ করতে হবে যাতে Azure API Management-এর প্রতি সঠিকভাবে অথেন্টিকেট করা যায়। এটি একটি হেডার ব্যবহার করে যার নাম **Ocp-Apim-Subscription-Key**।

    - সেটিংসে এটি যোগ করার উপায়:

    ![Adding header for authentication](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), এটি একটি প্রম্পট দেখাবে যেখানে API কী মান দিতে হবে, যা আপনি Azure Portal থেকে আপনার Azure API Management ইনস্ট্যান্সের জন্য পেতে পারেন।

   - *mcp.json* এ যোগ করতে চাইলে, এরকম হবে:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Agent মোড ব্যবহার করুন

এখন আমরা সেটিংস বা *.vscode/mcp.json*-এ সবকিছু সেটআপ করেছি। চলুন চেষ্টা করি।

একটি Tools আইকন থাকা উচিত, যেখানে আপনার সার্ভার থেকে প্রকাশিত টুলগুলো তালিকাভুক্ত থাকবে:

![Tools from the server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Tools আইকনে ক্লিক করুন, আপনি টুলগুলোর একটি তালিকা দেখতে পাবেন:

    ![Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. চ্যাটে একটি প্রম্পট লিখুন টুল কল করার জন্য। উদাহরণস্বরূপ, আপনি যদি একটি টুল নির্বাচন করে থাকেন যা অর্ডারের তথ্য দেয়, তাহলে এজেন্টকে অর্ডার সম্পর্কে জিজ্ঞাসা করতে পারেন। একটি উদাহরণ প্রম্পট:

    ```text
    get information from order 2
    ```

    এখন আপনাকে একটি টুলস আইকন দেখানো হবে যা টুল কল চালিয়ে যেতে বলবে। চালিয়ে যান, আপনি নিচের মত আউটপুট দেখতে পাবেন:

    ![Result from prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **উপরের আউটপুট আপনি যে টুলস সেটআপ করেছেন তার উপর নির্ভর করবে, তবে মূল ধারণা হলো আপনি একটি টেক্সট ভিত্তিক উত্তর পাবেন।**


## রেফারেন্সসমূহ

আরও জানতে পারেন:

- [Azure API Management এবং MCP টিউটোরিয়াল](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python স্যাম্পল: Azure API Management ব্যবহার করে সুরক্ষিত রিমোট MCP সার্ভার (প্রায়োগিক)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP ক্লায়েন্ট অথরাইজেশন ল্যাব](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [VS Code-এর জন্য Azure API Management এক্সটেনশন ব্যবহার করে API ইমপোর্ট ও ম্যানেজ করা](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Azure API Center-এ রিমোট MCP সার্ভার রেজিস্টার ও ডিসকভার করা](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) - Azure API Management-এর সাথে অনেক AI ফিচার দেখানো একটি চমৎকার রিপোজিটরি
- [AI Gateway ওয়ার্কশপসমূহ](https://azure-samples.github.io/AI-Gateway/) - Azure Portal ব্যবহার করে ওয়ার্কশপ, যা AI ফিচার মূল্যায়নের জন্য একটি চমৎকার শুরু।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।