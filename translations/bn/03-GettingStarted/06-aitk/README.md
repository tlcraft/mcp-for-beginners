<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:31:42+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "bn"
}
-->
# Visual Studio Code-এর AI Toolkit এক্সটেনশনের মাধ্যমে একটি সার্ভার ব্যবহার করা

যখন আপনি একটি AI এজেন্ট তৈরি করছেন, তখন শুধু বুদ্ধিমান উত্তর তৈরি করাই যথেষ্ট নয়; আপনার এজেন্টকে কাজ করার ক্ষমতাও দিতে হবে। এ জন্যই Model Context Protocol (MCP) আছে। MCP এজেন্টদের বাহ্যিক টুল ও সার্ভিসগুলো ধারাবাহিকভাবে ব্যবহার করতে সাহায্য করে। এটা এমন যেন আপনি আপনার এজেন্টকে এমন একটি টুলবক্সে যুক্ত করছেন যা সে *বাস্তবেই* ব্যবহার করতে পারে।

ধরা যাক, আপনি একটি এজেন্টকে আপনার calculator MCP সার্ভারের সাথে সংযুক্ত করলেন। হঠাৎ করে, আপনার এজেন্ট “47 গুণ 89 কত?” এর মতো একটি প্রম্পট পেয়ে গাণিতিক কাজ করতে পারবে—কোনো লজিক হার্ডকোড করার বা কাস্টম API তৈরি করার দরকার নেই।

## ওভারভিউ

এই লেসনে দেখানো হবে কিভাবে Visual Studio Code-এ [AI Toolkit](https://aka.ms/AIToolkit) এক্সটেনশনের মাধ্যমে একটি calculator MCP সার্ভারকে এজেন্টের সাথে সংযুক্ত করে আপনার এজেন্টকে প্রাকৃতিক ভাষার মাধ্যমে যোগ, বিয়োগ, গুণ ও ভাগের গাণিতিক কাজ করানো যায়।

AI Toolkit হলো Visual Studio Code-এর একটি শক্তিশালী এক্সটেনশন যা এজেন্ট ডেভেলপমেন্টকে সহজ করে তোলে। AI ইঞ্জিনিয়াররা সহজেই লোকালি বা ক্লাউডে জেনারেটিভ AI মডেল তৈরি ও পরীক্ষা করে AI অ্যাপ্লিকেশন তৈরি করতে পারেন। এই এক্সটেনশন আজকের বেশিরভাগ প্রধান জেনারেটিভ মডেল সমর্থন করে।

*Note*: AI Toolkit বর্তমানে Python এবং TypeScript সমর্থন করে।

## শেখার লক্ষ্যসমূহ

এই লেসনের শেষে আপনি পারবেন:

- AI Toolkit-এর মাধ্যমে MCP সার্ভার ব্যবহার করা।
- একটি এজেন্ট কনফিগার করা যাতে MCP সার্ভারের সরবরাহকৃত টুলগুলো আবিষ্কার ও ব্যবহার করতে পারে।
- প্রাকৃতিক ভাষার মাধ্যমে MCP টুলগুলো ব্যবহার করা।

## পদ্ধতি

উচ্চ পর্যায়ে আমাদের পদ্ধতিটি এমন:

- একটি এজেন্ট তৈরি করুন এবং এর সিস্টেম প্রম্পট নির্ধারণ করুন।
- calculator টুলসহ একটি MCP সার্ভার তৈরি করুন।
- Agent Builder-কে MCP সার্ভারের সাথে সংযুক্ত করুন।
- প্রাকৃতিক ভাষার মাধ্যমে এজেন্টের টুল ইনভোকেশন পরীক্ষা করুন।

দারুণ, এখন যেহেতু প্রবাহ বুঝে গেছি, চলুন MCP এর মাধ্যমে বাহ্যিক টুল ব্যবহার করার জন্য একটি AI এজেন্ট কনফিগার করি, যার ফলে এর ক্ষমতা বৃদ্ধি পাবে!

## পূর্বশর্ত

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## অনুশীলন: একটি সার্ভার ব্যবহার করা

এই অনুশীলনে, আপনি Visual Studio Code-এ AI Toolkit ব্যবহার করে একটি MCP সার্ভারের টুলগুলোসহ একটি AI এজেন্ট তৈরি, চালানো এবং উন্নত করবেন।

### -0- পূর্বধাপ, OpenAI GPT-4o মডেল My Models-এ যোগ করা

অনুশীলনটি **GPT-4o** মডেল ব্যবহার করে। এজেন্ট তৈরি করার আগে মডেলটি অবশ্যই **My Models**-এ যোগ করতে হবে।

![Visual Studio Code-এর AI Toolkit এক্সটেনশনের মডেল নির্বাচন ইন্টারফেসের স্ক্রিনশট। শিরোনামে লেখা “Find the right model for your AI Solution” এবং সাবটাইটেলে ব্যবহারকারীদের AI মডেল আবিষ্কার, পরীক্ষা ও ডিপ্লয় করার আহ্বান। নিচে “Popular Models” এর আওতায় ছয়টি মডেল কার্ড দেখানো হয়েছে: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), এবং DeepSeek-R1 (Ollama-hosted)। প্রতিটি কার্ডে “Add” এবং “Try in Playground” অপশন রয়েছে।](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.bn.png)

1. **Activity Bar** থেকে **AI Toolkit** এক্সটেনশন খুলুন।
2. **Catalog** সেকশনে **Models** নির্বাচন করুন, এতে একটি নতুন এডিটর ট্যাবে **Model Catalog** খুলবে।
3. **Model Catalog**-এর সার্চ বারে **OpenAI GPT-4o** লিখুন।
4. **+ Add** ক্লিক করে মডেলটি **My Models**-এ যোগ করুন। নিশ্চিত করুন যে আপনি **GitHub-hosted** মডেলটি নির্বাচন করেছেন।
5. **Activity Bar**-এ দেখুন **OpenAI GPT-4o** মডেল তালিকায় এসেছে কিনা।

### -1- একটি এজেন্ট তৈরি করুন

**Agent (Prompt) Builder** আপনাকে নিজের AI চালিত এজেন্ট তৈরি ও কাস্টমাইজ করতে সাহায্য করে। এই অংশে, আপনি একটি নতুন এজেন্ট তৈরি করে কথোপকথনের জন্য একটি মডেল নির্ধারণ করবেন।

![Visual Studio Code-এর AI Toolkit এক্সটেনশনের "Calculator Agent" বিল্ডার ইন্টারফেসের স্ক্রিনশট। বাম প্যানেলে নির্বাচিত মডেল “OpenAI GPT-4o (via GitHub)”। একটি সিস্টেম প্রম্পটে লেখা “You are a professor in university teaching math,” এবং ইউজার প্রম্পটে “Explain to me the Fourier equation in simple terms।” অতিরিক্ত অপশনে টুল যোগ, MCP Server সক্রিয়করণ, এবং স্ট্রাকচার্ড আউটপুট নির্বাচন বোতাম রয়েছে। নিচে নীল “Run” বোতাম। ডান প্যানেলে “Get Started with Examples” শিরোনামের নিচে তিনটি স্যাম্পল এজেন্টের তালিকা: Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter সহ)।](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.bn.png)

1. **Activity Bar** থেকে **AI Toolkit** এক্সটেনশন খুলুন।
2. **Tools** সেকশনে **Agent (Prompt) Builder** নির্বাচন করুন, এতে নতুন এডিটর ট্যাবে **Agent (Prompt) Builder** খুলবে।
3. **+ New Agent** বোতাম ক্লিক করুন। এক্সটেনশন **Command Palette**-এর মাধ্যমে একটি সেটআপ উইজার্ড চালু করবে।
4. নাম হিসেবে **Calculator Agent** লিখে **Enter** চাপুন।
5. **Agent (Prompt) Builder**-এ **Model** ফিল্ডে **OpenAI GPT-4o (via GitHub)** মডেল নির্বাচন করুন।

### -2- এজেন্টের জন্য একটি সিস্টেম প্রম্পট তৈরি করুন

এজেন্ট তৈরি হয়ে গেলে, এর ব্যক্তিত্ব ও উদ্দেশ্য নির্ধারণ করার সময় এসেছে। এই অংশে, আপনি **Generate system prompt** ফিচার ব্যবহার করে এজেন্টের উদ্দেশ্য বর্ণনা করবেন—এক্ষেত্রে একটি calculator এজেন্ট—এবং মডেলকে সিস্টেম প্রম্পট লেখাতে বলবেন।

![Visual Studio Code-এর AI Toolkit-এর "Calculator Agent" ইন্টারফেসের স্ক্রিনশট যেখানে একটি মডাল উইন্ডো “Generate a prompt” শিরোনামে খোলা। মডালটি জানাচ্ছে কিভাবে একটি প্রম্পট টেমপ্লেট তৈরি করা যায় মৌলিক তথ্য শেয়ার করে। একটি টেক্সট বক্সে স্যাম্পল সিস্টেম প্রম্পট লেখা: “You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.” নিচে “Close” ও “Generate” বোতাম। পেছনে এজেন্ট কনফিগারেশন অংশ দৃশ্যমান, নির্বাচিত মডেল “OpenAI GPT-4o (via GitHub)” এবং সিস্টেম ও ইউজার প্রম্পট ফিল্ড।](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.bn.png)

1. **Prompts** সেকশনে **Generate system prompt** বোতাম ক্লিক করুন। এটি প্রম্পট বিল্ডার খুলবে যা AI ব্যবহার করে সিস্টেম প্রম্পট তৈরি করে।
2. **Generate a prompt** উইন্ডোতে নিম্নলিখিত লিখুন: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. **Generate** বোতাম ক্লিক করুন। নিচের ডানদিকে একটি নোটিফিকেশন আসবে যা নিশ্চিত করবে প্রম্পট তৈরি হচ্ছে। প্রম্পট তৈরি শেষ হলে, এটি **Agent (Prompt) Builder**-এর **System prompt** ফিল্ডে দেখাবে।
4. **System prompt** পর্যালোচনা করুন এবং প্রয়োজনে সংশোধন করুন।

### -3- একটি MCP সার্ভার তৈরি করুন

এখন যেহেতু আপনি এজেন্টের সিস্টেম প্রম্পট নির্ধারণ করেছেন—যা এর আচরণ ও উত্তর নির্দেশ করে—এখন এজেন্টকে ব্যবহারিক সক্ষমতা দেওয়ার সময়। এই অংশে, আপনি একটি calculator MCP সার্ভার তৈরি করবেন যা যোগ, বিয়োগ, গুণ ও ভাগের গাণিতিক কাজ করতে পারবে। এই সার্ভারটি আপনার এজেন্টকে প্রাকৃতিক ভাষার প্রম্পটের জবাবে বাস্তব সময় গাণিতিক কাজ করতে সক্ষম করবে।

![Visual Studio Code-এর AI Toolkit এক্সটেনশনের Calculator Agent ইন্টারফেসের নিচের অংশের স্ক্রিনশট। এখানে “Tools” ও “Structure output” এক্সপ্যান্ডেবল মেনু এবং “Choose output format” ড্রপডাউন “text” এ সেট করা। ডানদিকে “+ MCP Server” বোতাম একটি Model Context Protocol সার্ভার যোগ করার জন্য। Tools সেকশনের উপরে একটি ইমেজ আইকন প্লেসহোল্ডার।](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.bn.png)

AI Toolkit আপনার নিজের MCP সার্ভার তৈরি সহজ করতে টেমপ্লেট সরবরাহ করে। আমরা Python টেমপ্লেট ব্যবহার করে calculator MCP সার্ভার তৈরি করব।

*Note*: AI Toolkit বর্তমানে Python এবং TypeScript সমর্থন করে।

1. **Agent (Prompt) Builder**-এর **Tools** সেকশনে **+ MCP Server** বোতাম ক্লিক করুন। এক্সটেনশন **Command Palette**-এর মাধ্যমে একটি সেটআপ উইজার্ড চালু করবে।
2. **+ Add Server** নির্বাচন করুন।
3. **Create a New MCP Server** নির্বাচন করুন।
4. **python-weather** টেমপ্লেট নির্বাচন করুন।
5. MCP সার্ভার টেমপ্লেট সংরক্ষণের জন্য **Default folder** নির্বাচন করুন।
6. সার্ভারের জন্য নাম দিন: **Calculator**
7. একটি নতুন Visual Studio Code উইন্ডো খুলবে। **Yes, I trust the authors** নির্বাচন করুন।
8. টার্মিনালে (**Terminal** > **New Terminal**) একটি ভার্চুয়াল এনভায়রনমেন্ট তৈরি করুন: `python -m venv .venv`
9. টার্মিনালে ভার্চুয়াল এনভায়রনমেন্ট সক্রিয় করুন:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. টার্মিনালে ডিপেনডেন্সি ইনস্টল করুন: `pip install -e .[dev]`
11. **Activity Bar**-এর **Explorer** ভিউতে **src** ডিরেক্টরি এক্সপ্যান্ড করে **server.py** ফাইলটি খুলুন।
12. **server.py** ফাইলের কোড নিম্নরূপ প্রতিস্থাপন করুন এবং সেভ করুন:

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

### -4- calculator MCP সার্ভারসহ এজেন্ট চালান

এখন যেহেতু আপনার এজেন্টের কাছে টুল আছে, সেগুলো ব্যবহার করার সময়! এই অংশে, আপনি এজেন্টকে প্রম্পট পাঠিয়ে পরীক্ষা করবেন যে এটি calculator MCP সার্ভারের সঠিক টুল ব্যবহার করছে কিনা।

![Visual Studio Code-এর AI Toolkit এক্সটেনশনের Calculator Agent ইন্টারফেসের স্ক্রিনশট। বাম প্যানেলে “Tools” এর অধীনে local-server-calculator_server নামে একটি MCP সার্ভার যোগ করা হয়েছে, যেখানে চারটি টুল রয়েছে: add, subtract, multiply, এবং divide। একটি ব্যাজ দেখাচ্ছে চারটি টুল সক্রিয়। নিচে “Structure output” সেকশন কোলাপ্স করা এবং নীল “Run” বোতাম। ডান প্যানেলে “Model Response” অংশে এজেন্ট multiply ও subtract টুল ইনভোক করছে ইনপুট সহ {"a": 3, "b": 25} এবং {"a": 75, "b": 20}। চূড়ান্ত “Tool Response” দেখাচ্ছে 75.0। নিচে “View Code” বোতাম।](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.bn.png)

আপনি আপনার লোকাল ডেভ মেশিনে **Agent Builder** ব্যবহার করে calculator MCP সার্ভার চালাবেন MCP ক্লায়েন্ট হিসেবে।

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` মানগুলো **subtract** টুলের জন্য নির্ধারিত।
    - প্রতিটি টুলের উত্তর সংশ্লিষ্ট **Tool Response**-এ দেখানো হয়।
    - মডেলের চূড়ান্ত আউটপুট **Model Response**-এ পাওয়া যায়।
2. এজেন্টের আরো পরীক্ষা করার জন্য অতিরিক্ত প্রম্পট জমা দিন। **User prompt** ফিল্ডে ক্লিক করে বিদ্যমান প্রম্পট পরিবর্তন করতে পারেন।
3. পরীক্ষা শেষ হলে, টার্মিনালে **CTRL/CMD+C** চাপিয়ে সার্ভার বন্ধ করতে পারেন।

## অ্যাসাইনমেন্ট

আপনার **server.py** ফাইলে একটি অতিরিক্ত টুল এন্ট্রি যোগ করার চেষ্টা করুন (যেমন: একটি সংখ্যার বর্গমূল ফেরত দেওয়া)। এমন প্রম্পট জমা দিন যা আপনার নতুন টুল (অথবা বিদ্যমান টুল) ব্যবহার করতে এজেন্টকে প্ররোচিত করবে। নতুন টুল লোড করার জন্য সার্ভার রিস্টার্ট করতে ভুলবেন না।

## সমাধান

[Solution](./solution/README.md)

## মূল বিষয়সমূহ

এই অধ্যায় থেকে প্রধান শেখাগুলো:

- AI Toolkit এক্সটেনশন একটি চমৎকার ক্লায়েন্ট যা MCP সার্ভার ও তাদের টুল ব্যবহার করতে দেয়।
- MCP সার্ভারে নতুন টুল যোগ করে এজেন্টের ক্ষমতা বাড়ানো যায়, যা পরিবর্তিত চাহিদা পূরণে সহায়ক।
- AI Toolkit-এ টেমপ্লেট রয়েছে (যেমন Python MCP সার্ভার টেমপ্লেট) যা কাস্টম টুল তৈরি সহজ করে।

## অতিরিক্ত সম্পদ

- [AI Toolkit ডকুমেন্টেশন](https://aka.ms/AIToolkit/doc)

## পরবর্তী কী

পরবর্তী: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**অস্বীকারোক্তি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা ভুল থাকতে পারে। মূল নথি তার নিজস্ব ভাষায় সর্বোত্তম এবং নির্ভরযোগ্য উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করা উচিৎ। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।