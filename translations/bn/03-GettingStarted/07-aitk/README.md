<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T16:33:07+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "bn"
}
-->
# Visual Studio Code-এর AI Toolkit এক্সটেনশনের মাধ্যমে একটি সার্ভার ব্যবহার করা

যখন আপনি একটি AI এজেন্ট তৈরি করছেন, তখন শুধু বুদ্ধিমান উত্তর তৈরি করাই নয়; আপনার এজেন্টকে কাজ করার ক্ষমতাও দিতে হয়। এখানেই Model Context Protocol (MCP) কাজ করে। MCP এজেন্টদের বাইরের টুল এবং সার্ভিসগুলো ধারাবাহিকভাবে ব্যবহার করার সুযোগ দেয়। ভাবুন, এটি এমন একটি টুলবক্সের মতো যেখানে আপনার এজেন্ট *আসলে* কাজ করতে পারে।

ধরা যাক, আপনি একটি এজেন্টকে আপনার calculator MCP সার্ভারের সাথে সংযুক্ত করেছেন। হঠাৎ করে, আপনার এজেন্ট শুধু “47 গুণ 89 কত?” এর মতো একটি প্রম্পট পেয়ে গাণিতিক কাজ করতে পারবে—কোনো কঠিন লজিক কোড করার বা কাস্টম API তৈরির দরকার নেই।

## ওভারভিউ

এই পাঠে দেখানো হবে কিভাবে Visual Studio Code-এর [AI Toolkit](https://aka.ms/AIToolkit) এক্সটেনশনের মাধ্যমে একটি calculator MCP সার্ভারকে একটি এজেন্টের সাথে সংযুক্ত করা যায়, যাতে আপনার এজেন্ট প্রাকৃতিক ভাষার মাধ্যমে যোগ, বিয়োগ, গুণ এবং ভাগের মতো গাণিতিক কাজ করতে পারে।

AI Toolkit হলো Visual Studio Code-এর একটি শক্তিশালী এক্সটেনশন যা এজেন্ট ডেভেলপমেন্টকে সহজ করে তোলে। AI ইঞ্জিনিয়াররা সহজেই স্থানীয় বা ক্লাউডে জেনারেটিভ AI মডেল তৈরি ও পরীক্ষা করে AI অ্যাপ্লিকেশন তৈরি করতে পারেন। এই এক্সটেনশন আজকের বেশিরভাগ প্রধান জেনারেটিভ মডেলকে সমর্থন করে।

*Note*: AI Toolkit বর্তমানে Python এবং TypeScript সমর্থন করে।

## শেখার উদ্দেশ্য

এই পাঠ শেষ করার পর আপনি পারবেন:

- AI Toolkit-এর মাধ্যমে একটি MCP সার্ভার ব্যবহার করা।
- একটি এজেন্ট কনফিগারেশন সেট করা যাতে এটি MCP সার্ভারের সরবরাহিত টুলগুলো আবিষ্কার ও ব্যবহার করতে পারে।
- প্রাকৃতিক ভাষার মাধ্যমে MCP টুলগুলো ব্যবহার করা।

## পদ্ধতি

উচ্চ পর্যায়ে আমাদের পদ্ধতিটি হবে:

- একটি এজেন্ট তৈরি করে তার সিস্টেম প্রম্পট নির্ধারণ করা।
- calculator টুলসহ একটি MCP সার্ভার তৈরি করা।
- Agent Builder-কে MCP সার্ভারের সাথে সংযুক্ত করা।
- প্রাকৃতিক ভাষার মাধ্যমে এজেন্টের টুল ব্যবহার পরীক্ষা করা।

দারুণ, এখন যেহেতু আমরা প্রবাহ বুঝে গেছি, চলুন MCP-এর মাধ্যমে বাইরের টুলগুলো ব্যবহার করার জন্য একটি AI এজেন্ট কনফিগার করি এবং এর ক্ষমতা বাড়াই!

## প্রয়োজনীয়তা

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code-এর জন্য AI Toolkit](https://aka.ms/AIToolkit)

## অনুশীলন: একটি সার্ভার ব্যবহার করা

এই অনুশীলনে, আপনি Visual Studio Code-এর AI Toolkit ব্যবহার করে একটি MCP সার্ভারের টুলসহ একটি AI এজেন্ট তৈরি, চালানো এবং উন্নত করবেন।

### -0- প্রাথমিক ধাপ, My Models-এ OpenAI GPT-4o মডেল যোগ করা

এই অনুশীলনে **GPT-4o** মডেল ব্যবহার করা হবে। এজেন্ট তৈরি করার আগে মডেলটি অবশ্যই **My Models**-এ যোগ করতে হবে।

![Visual Studio Code-এর AI Toolkit এক্সটেনশনের মডেল নির্বাচন ইন্টারফেসের স্ক্রিনশট। শিরোনামে লেখা “Find the right model for your AI Solution” এবং সাবটাইটেলে AI মডেল আবিষ্কার, পরীক্ষা ও ডিপ্লয় করার আহ্বান। “Popular Models” অংশে ছয়টি মডেল কার্ড দেখানো হয়েছে: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), এবং DeepSeek-R1 (Ollama-hosted)। প্রতিটি কার্ডে “Add” এবং “Try in Playground” অপশন রয়েছে।](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.bn.png)

1. **Activity Bar** থেকে **AI Toolkit** এক্সটেনশন খুলুন।
1. **Catalog** সেকশনে **Models** নির্বাচন করুন, এতে **Model Catalog** একটি নতুন এডিটর ট্যাবে খুলবে।
1. **Model Catalog**-এর সার্চ বারে **OpenAI GPT-4o** লিখুন।
1. **+ Add** ক্লিক করে মডেলটি **My Models** তালিকায় যোগ করুন। নিশ্চিত করুন যে আপনি **GitHub-hosted** মডেলটি নির্বাচন করেছেন।
1. **Activity Bar**-এ নিশ্চিত করুন যে **OpenAI GPT-4o** মডেলটি তালিকায় দেখা যাচ্ছে।

### -1- একটি এজেন্ট তৈরি করা

**Agent (Prompt) Builder** আপনাকে নিজস্ব AI-চালিত এজেন্ট তৈরি ও কাস্টমাইজ করার সুযোগ দেয়। এই অংশে, আপনি একটি নতুন এজেন্ট তৈরি করবেন এবং কথোপকথনের জন্য একটি মডেল নির্ধারণ করবেন।

![Visual Studio Code-এর AI Toolkit এক্সটেনশনের "Calculator Agent" বিল্ডার ইন্টারফেসের স্ক্রিনশট। বাম প্যানেলে নির্বাচিত মডেল "OpenAI GPT-4o (via GitHub)"। একটি সিস্টেম প্রম্পটে লেখা "You are a professor in university teaching math," এবং ইউজার প্রম্পটে "Explain to me the Fourier equation in simple terms." টুল যোগ করার, MCP Server সক্রিয় করার, এবং স্ট্রাকচার্ড আউটপুট নির্বাচন করার অপশন রয়েছে। নিচে নীল রঙের “Run” বাটন। ডান প্যানেলে "Get Started with Examples" এর অধীনে তিনটি নমুনা এজেন্টের তালিকা: Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter সহ)।](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.bn.png)

1. **Activity Bar** থেকে **AI Toolkit** এক্সটেনশন খুলুন।
1. **Tools** সেকশনে **Agent (Prompt) Builder** নির্বাচন করুন, এটি একটি নতুন এডিটর ট্যাবে খুলবে।
1. **+ New Agent** বাটনে ক্লিক করুন। এক্সটেনশন একটি সেটআপ উইজার্ড চালু করবে **Command Palette**-এর মাধ্যমে।
1. নাম দিন **Calculator Agent** এবং **Enter** চাপুন।
1. **Agent (Prompt) Builder**-এ **Model** ফিল্ডে **OpenAI GPT-4o (via GitHub)** মডেল নির্বাচন করুন।

### -2- এজেন্টের জন্য একটি সিস্টেম প্রম্পট তৈরি করা

এজেন্টের কাঠামো তৈরি হয়ে গেলে, এর ব্যক্তিত্ব ও উদ্দেশ্য নির্ধারণের সময় এসেছে। এই অংশে, আপনি **Generate system prompt** ফিচার ব্যবহার করে এজেন্টের আচরণ বর্ণনা করবেন—এক্ষেত্রে একটি calculator এজেন্ট হিসেবে—এবং মডেলকে সিস্টেম প্রম্পট লিখতে দেবেন।

![Visual Studio Code-এর AI Toolkit-এর "Calculator Agent" ইন্টারফেসের স্ক্রিনশট, যেখানে একটি মডাল উইন্ডো খোলা আছে যার শিরোনাম "Generate a prompt"। মডাল জানাচ্ছে যে একটি প্রম্পট টেমপ্লেট তৈরি করা যাবে মৌলিক তথ্য শেয়ার করে। একটি টেক্সট বক্সে নমুনা সিস্টেম প্রম্পট: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." নিচে "Close" এবং "Generate" বাটন। পেছনে এজেন্ট কনফিগারেশনের অংশ দেখা যাচ্ছে, নির্বাচিত মডেল "OpenAI GPT-4o (via GitHub)" এবং সিস্টেম ও ইউজার প্রম্পট ফিল্ড।](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.bn.png)

1. **Prompts** সেকশনে **Generate system prompt** বাটনে ক্লিক করুন। এটি প্রম্পট বিল্ডার খুলবে যা AI ব্যবহার করে সিস্টেম প্রম্পট তৈরি করে।
1. **Generate a prompt** উইন্ডোতে লিখুন: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** বাটনে ক্লিক করুন। ডান নিচে একটি নোটিফিকেশন আসবে যা জানাবে সিস্টেম প্রম্পট তৈরি হচ্ছে। প্রম্পট তৈরি শেষ হলে এটি **Agent (Prompt) Builder**-এর **System prompt** ফিল্ডে দেখাবে।
1. **System prompt** পর্যালোচনা করুন এবং প্রয়োজনে পরিবর্তন করুন।

### -3- একটি MCP সার্ভার তৈরি করা

এখন যেহেতু আপনি এজেন্টের সিস্টেম প্রম্পট নির্ধারণ করেছেন—যা এর আচরণ ও প্রতিক্রিয়া নির্দেশ করে—এখন এজেন্টকে ব্যবহারিক ক্ষমতা দেওয়ার সময়। এই অংশে, আপনি একটি calculator MCP সার্ভার তৈরি করবেন যা যোগ, বিয়োগ, গুণ এবং ভাগের গাণিতিক কাজ করতে পারবে। এই সার্ভারটি আপনার এজেন্টকে প্রাকৃতিক ভাষার প্রম্পটের জবাবে রিয়েল-টাইম গাণিতিক কাজ করতে সক্ষম করবে।

!["Visual Studio Code-এর AI Toolkit এক্সটেনশনের Calculator Agent ইন্টারফেসের নিচের অংশের স্ক্রিনশট। এখানে “Tools” এবং “Structure output” এর জন্য এক্সপ্যান্ডেবল মেনু, “Choose output format” ড্রপডাউন মেনু “text” এ সেট করা, এবং ডানদিকে “+ MCP Server” বাটন দেখানো হয়েছে। Tools সেকশনের উপরে একটি ইমেজ আইকন প্লেসহোল্ডার।](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.bn.png)

AI Toolkit আপনার নিজের MCP সার্ভার তৈরি সহজ করার জন্য টেমপ্লেট সরবরাহ করে। আমরা calculator MCP সার্ভার তৈরির জন্য Python টেমপ্লেট ব্যবহার করব।

*Note*: AI Toolkit বর্তমানে Python এবং TypeScript সমর্থন করে।

1. **Agent (Prompt) Builder**-এর **Tools** সেকশনে **+ MCP Server** বাটনে ক্লিক করুন। এক্সটেনশন একটি সেটআপ উইজার্ড চালু করবে **Command Palette**-এর মাধ্যমে।
1. **+ Add Server** নির্বাচন করুন।
1. **Create a New MCP Server** নির্বাচন করুন।
1. **python-weather** টেমপ্লেট নির্বাচন করুন।
1. MCP সার্ভার টেমপ্লেট সংরক্ষণের জন্য **Default folder** নির্বাচন করুন।
1. সার্ভারের জন্য নাম দিন: **Calculator**
1. একটি নতুন Visual Studio Code উইন্ডো খুলবে। **Yes, I trust the authors** নির্বাচন করুন।
1. টার্মিনালে (**Terminal** > **New Terminal**) একটি ভার্চুয়াল এনভায়রনমেন্ট তৈরি করুন: `python -m venv .venv`
1. ভার্চুয়াল এনভায়রনমেন্ট সক্রিয় করুন:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. ডিপেন্ডেন্সি ইনস্টল করুন: `pip install -e .[dev]`
1. **Activity Bar**-এর **Explorer** ভিউতে **src** ডিরেক্টরি এক্সপ্যান্ড করুন এবং **server.py** ফাইলটি খুলুন।
1. **server.py** ফাইলের কোড নিচের কোড দিয়ে প্রতিস্থাপন করুন এবং সেভ করুন:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- calculator MCP সার্ভারসহ এজেন্ট চালানো

এখন যেহেতু আপনার এজেন্টের কাছে টুল আছে, সেগুলো ব্যবহার করার সময় এসেছে! এই অংশে, আপনি এজেন্টকে প্রম্পট পাঠাবেন এবং যাচাই করবেন যে এজেন্ট calculator MCP সার্ভারের সঠিক টুল ব্যবহার করছে কিনা।

![Visual Studio Code-এর AI Toolkit এক্সটেনশনের Calculator Agent ইন্টারফেসের স্ক্রিনশট। বাম প্যানেলে “Tools” এর অধীনে একটি MCP সার্ভার local-server-calculator_server যুক্ত আছে, যেখানে চারটি টুল আছে: add, subtract, multiply, এবং divide। একটি ব্যাজ দেখাচ্ছে চারটি টুল সক্রিয়। নিচে “Structure output” সেকশন কোলাপ্স করা আছে এবং নীচে নীল “Run” বাটন। ডান প্যানেলে “Model Response” অংশে এজেন্ট multiply এবং subtract টুল ইনভোক করছে ইনপুট সহ {"a": 3, "b": 25} এবং {"a": 75, "b": 20}। চূড়ান্ত “Tool Response” 75.0 দেখাচ্ছে। নিচে “View Code” বাটন।](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.bn.png)

আপনি আপনার লোকাল ডেভ মেশিনে **Agent Builder**-এর মাধ্যমে MCP ক্লায়েন্ট হিসেবে calculator MCP সার্ভার চালাবেন।

1. MCP সার্ভার ডিবাগিং শুরু করতে `F5` চাপুন। **Agent (Prompt) Builder** একটি নতুন এডিটর ট্যাবে খুলবে। টার্মিনালে সার্ভারের স্ট্যাটাস দেখা যাবে।
1. **Agent (Prompt) Builder**-এর **User prompt** ফিল্ডে লিখুন: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. **Run** বাটনে ক্লিক করে এজেন্টের উত্তর তৈরি করুন।
1. এজেন্টের আউটপুট পর্যালোচনা করুন। মডেলটি নিশ্চিত করবে যে আপনি **$55** পরিশোধ করেছেন।
1. যা ঘটার কথা তার সংক্ষিপ্ত বিবরণ:
    - এজেন্ট গাণিতিক হিসাবের জন্য **multiply** এবং **subtract** টুল নির্বাচন করে।
    - **multiply** টুলের জন্য `a` এবং `b` মান নির্ধারণ করা হয়।
    - **subtract** টুলের জন্য `a` এবং `b` মান নির্ধারণ করা হয়।
    - প্রতিটি টুলের উত্তর **Tool Response**-এ দেখানো হয়।
    - মডেলের চূড়ান্ত আউটপুট **Model Response**-এ প্রদর্শিত হয়।
1. এজেন্ট আরও পরীক্ষা করার জন্য অতিরিক্ত প্রম্পট পাঠান। **User prompt** ফিল্ডে ক্লিক করে বিদ্যমান প্রম্পট পরিবর্তন করতে পারেন।
1. পরীক্ষা শেষ হলে, টার্মিনালে **CTRL/CMD+C** চাপ দিয়ে সার্ভার বন্ধ করুন।

## অ্যাসাইনমেন্ট

আপনার **server.py** ফাইলে একটি অতিরিক্ত টুল এন্ট্রি যোগ করার চেষ্টা করুন (যেমন: একটি সংখ্যার বর্গমূল ফেরত দেওয়া)। এমন প্রম্পট পাঠান যা এজেন্টকে আপনার নতুন টুল (অথবা বিদ্যমান টুল) ব্যবহার করতে বাধ্য করবে। নতুন টুল লোড করার জন্য সার্ভার পুনরায় চালু করতে ভুলবেন না।

## সমাধান

[Solution](./solution/README.md)

## মূল বিষয়সমূহ

এই অধ্যায় থেকে মূল বিষয়গুলো হলো:

- AI Toolkit এক্সটেনশন একটি চমৎকার ক্লায়েন্ট যা MCP সার্ভার এবং তাদের টুল ব্যবহার করতে দেয়।
- আপনি MCP সার্ভারে নতুন টুল যোগ করতে পারেন, যা এজেন্টের ক্ষমতা বাড়িয়ে পরিবর্তিত চাহিদা পূরণ করে।
- AI Toolkit টেমপ্লেট (যেমন Python MCP সার্ভার টেমপ্লেট) অন্তর্ভুক্ত করে যা কাস্টম টুল তৈরি সহজ করে।

## অতিরিক্ত সম্পদ

- [AI Toolkit ডকুমেন্টেশন](https://aka.ms/AIToolkit/doc)

## পরবর্তী ধাপ
- পরবর্তী: [Testing & Debugging](../08-testing/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।