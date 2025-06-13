<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:16:37+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "bn"
}
-->
# Visual Studio Code এর AI Toolkit এক্সটেনশনের মাধ্যমে একটি সার্ভার ব্যবহার করা

যখন আপনি একটি AI এজেন্ট তৈরি করছেন, তখন শুধু বুদ্ধিমান উত্তর তৈরি করাই যথেষ্ট নয়; এজেন্টকে কার্যকরী করার ক্ষমতাও দিতে হয়। এই কাজে Model Context Protocol (MCP) সাহায্য করে। MCP এজেন্টদের বাইরের টুলস এবং সার্ভিসগুলো একরকমভাবে ব্যবহার করতে সহজ করে তোলে। ভাবুন, এটি এমন একটি টুলবক্সের মতো যা আপনার এজেন্ট আসলেই ব্যবহার করতে পারে।

ধরা যাক আপনি একটি ক্যালকুলেটর MCP সার্ভারের সাথে একটি এজেন্ট যুক্ত করেছেন। হঠাৎ করেই আপনার এজেন্ট “47 গুণ 89 কত?” এর মতো প্রম্পট পেয়ে গাণিতিক কাজ করতে পারবে—কোনো হার্ডকোডেড লজিক বা কাস্টম API তৈরি করার দরকার নেই।

## সংক্ষিপ্ত পরিচিতি

এই লেসনে আমরা দেখব কিভাবে Visual Studio Code এর [AI Toolkit](https://aka.ms/AIToolkit) এক্সটেনশনের মাধ্যমে একটি ক্যালকুলেটর MCP সার্ভারকে একটি এজেন্টের সাথে যুক্ত করা যায়, যাতে এজেন্ট যোগ, বিয়োগ, গুণ এবং ভাগের মতো গাণিতিক কাজগুলো প্রাকৃতিক ভাষার মাধ্যমে করতে পারে।

AI Toolkit হলো Visual Studio Code এর একটি শক্তিশালী এক্সটেনশন যা এজেন্ট ডেভেলপমেন্টকে সহজ করে তোলে। AI ইঞ্জিনিয়াররা স্থানীয় বা ক্লাউডে জেনারেটিভ AI মডেল তৈরি ও পরীক্ষা করে সহজেই AI অ্যাপ্লিকেশন তৈরি করতে পারেন। এই এক্সটেনশন আজকের অধিকাংশ প্রধান জেনারেটিভ মডেল সমর্থন করে।

*Note*: AI Toolkit বর্তমানে Python এবং TypeScript সমর্থন করে।

## শেখার লক্ষ্য

এই লেসনের শেষে আপনি পারবেন:

- AI Toolkit এর মাধ্যমে MCP সার্ভার ব্যবহার করা।
- একটি এজেন্ট কনফিগারেশন সেট আপ করা যাতে MCP সার্ভারের সরঞ্জামগুলো আবিষ্কার এবং ব্যবহার করতে পারে।
- প্রাকৃতিক ভাষার মাধ্যমে MCP টুলস ব্যবহার করা।

## পদ্ধতি

উচ্চ পর্যায়ে আমাদের কাজের ধাপগুলো হলো:

- একটি এজেন্ট তৈরি করে তার সিস্টেম প্রম্পট নির্ধারণ করা।
- ক্যালকুলেটর টুলসহ একটি MCP সার্ভার তৈরি করা।
- এজেন্ট বিল্ডারকে MCP সার্ভারের সাথে যুক্ত করা।
- প্রাকৃতিক ভাষার মাধ্যমে এজেন্টের টুল ইনভোকেশন পরীক্ষা করা।

চমৎকার, এখন যেহেতু আমরা পুরো প্রক্রিয়া বুঝে গেছি, চলুন MCP এর মাধ্যমে বাইরের টুলস ব্যবহার করার জন্য একটি AI এজেন্ট কনফিগার করি এবং তার ক্ষমতা বাড়াই!

## প্রয়োজনীয়তা

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## অনুশীলন: একটি সার্ভার ব্যবহার করা

এই অনুশীলনে, আপনি AI Toolkit ব্যবহার করে Visual Studio Code এর মধ্যে একটি MCP সার্ভার থেকে টুলস নিয়ে একটি AI এজেন্ট তৈরি, চালানো এবং উন্নত করবেন।

### -0- পূর্বপর্যায়, My Models এ OpenAI GPT-4o মডেল যোগ করা

এই অনুশীলনে **GPT-4o** মডেল ব্যবহার করা হবে। এজেন্ট তৈরি করার আগে মডেলটি অবশ্যই **My Models** এ যোগ করতে হবে।

![Visual Studio Code এর AI Toolkit এক্সটেনশনের মডেল সিলেকশন ইন্টারফেসের স্ক্রিনশট। শিরোনামে লেখা "Find the right model for your AI Solution" এবং সাবটাইটলে AI মডেল আবিষ্কার, পরীক্ষা ও ডিপ্লয় করার আহ্বান। “Popular Models” এর নিচে ছয়টি মডেল কার্ড দেখানো হয়েছে: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), এবং DeepSeek-R1 (Ollama-hosted)। প্রতিটি কার্ডে “Add” এবং “Try in Playground” অপশন আছে।](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.bn.png)

1. **Activity Bar** থেকে **AI Toolkit** এক্সটেনশন খুলুন।
2. **Catalog** সেকশনে গিয়ে **Models** নির্বাচন করুন, এতে **Model Catalog** নতুন এডিটর ট্যাবে খুলবে।
3. **Model Catalog** এর সার্চ বারে **OpenAI GPT-4o** লিখুন।
4. **+ Add** ক্লিক করে মডেলটি **My Models** এ যোগ করুন। নিশ্চিত করুন যে আপনি GitHub হোস্টেড মডেলটি নির্বাচন করেছেন।
5. **Activity Bar** এ যাচাই করুন যে **OpenAI GPT-4o** মডেলটি তালিকায় আছে।

### -1- একটি এজেন্ট তৈরি করা

**Agent (Prompt) Builder** আপনাকে নিজস্ব AI-চালিত এজেন্ট তৈরি ও কাস্টমাইজ করার সুযোগ দেয়। এই ধাপে আপনি একটি নতুন এজেন্ট তৈরি করে কথোপকথনের জন্য একটি মডেল নির্ধারণ করবেন।

![Visual Studio Code এর AI Toolkit এক্সটেনশনের "Calculator Agent" বিল্ডার ইন্টারফেসের স্ক্রিনশট। বাম প্যানেলে নির্বাচিত মডেল "OpenAI GPT-4o (via GitHub)"। সিস্টেম প্রম্পটে লেখা "You are a professor in university teaching math," এবং ইউজার প্রম্পটে "Explain to me the Fourier equation in simple terms." টুলস যোগ করার, MCP Server সক্রিয় করার এবং স্ট্রাকচার্ড আউটপুট সিলেক্ট করার অপশন রয়েছে। নিচে নীল রঙের “Run” বাটন। ডান পাশে "Get Started with Examples" এর অধীনে তিনটি স্যাম্পল এজেন্ট তালিকাভুক্ত।](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.bn.png)

1. **Activity Bar** থেকে **AI Toolkit** এক্সটেনশন খুলুন।
2. **Tools** সেকশনে গিয়ে **Agent (Prompt) Builder** নির্বাচন করুন, যা নতুন এডিটর ট্যাবে খুলবে।
3. **+ New Agent** বাটনে ক্লিক করুন। এক্সটেনশন একটি সেটআপ উইজার্ড চালু করবে **Command Palette** এর মাধ্যমে।
4. নাম দিন **Calculator Agent** এবং **Enter** চাপুন।
5. **Agent (Prompt) Builder** এ **Model** ফিল্ডে **OpenAI GPT-4o (via GitHub)** মডেল নির্বাচন করুন।

### -2- এজেন্টের জন্য সিস্টেম প্রম্পট তৈরি করা

এজেন্টের কাঠামো তৈরি হওয়ার পর, তার ব্যক্তিত্ব ও উদ্দেশ্য নির্ধারণের পালা। এখানে আপনি **Generate system prompt** ফিচার ব্যবহার করে এজেন্টের আচরণ বর্ণনা করবেন—এই ক্ষেত্রে একটি ক্যালকুলেটর এজেন্ট—এবং মডেলকে সিস্টেম প্রম্পট লিখতে বলবেন।

![Visual Studio Code এর AI Toolkit এ "Calculator Agent" ইন্টারফেসের স্ক্রিনশট, যেখানে একটি মডাল উইন্ডো খোলা যার শিরোনাম "Generate a prompt"। মডাল জানায় যে প্রম্পট টেমপ্লেট তৈরি করা যাবে মৌলিক তথ্য শেয়ার করে। একটি টেক্সট বক্সে নমুনা সিস্টেম প্রম্পট: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." নিচে "Close" এবং "Generate" বাটন। পেছনে এজেন্ট কনফিগারেশনের অংশ দেখা যাচ্ছে, নির্বাচিত মডেল "OpenAI GPT-4o (via GitHub)" এবং সিস্টেম ও ইউজার প্রম্পটের ফিল্ড।](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.bn.png)

1. **Prompts** সেকশনে **Generate system prompt** বাটনে ক্লিক করুন। এটি AI ব্যবহার করে সিস্টেম প্রম্পট তৈরি করবে।
2. **Generate a prompt** উইন্ডোতে নিম্নলিখিত লিখুন: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. **Generate** বাটনে ক্লিক করুন। ডান নিচের কোণে একটি নোটিফিকেশন আসবে যা জানাবে প্রম্পট তৈরি হচ্ছে। প্রক্রিয়া শেষ হলে প্রম্পট **Agent (Prompt) Builder** এর **System prompt** ফিল্ডে প্রদর্শিত হবে।
4. প্রয়োজনে **System prompt** পর্যালোচনা ও সম্পাদনা করুন।

### -3- একটি MCP সার্ভার তৈরি করা

এখন যেহেতু আপনি এজেন্টের সিস্টেম প্রম্পট নির্ধারণ করেছেন যা তার আচরণ ও প্রতিক্রিয়া নির্দেশ করে, সময় এসেছে এজেন্টকে ব্যবহারিক ক্ষমতা দেওয়ার। এখানে আপনি একটি ক্যালকুলেটর MCP সার্ভার তৈরি করবেন যেটি যোগ, বিয়োগ, গুণ এবং ভাগের হিসাব করতে পারবে। এই সার্ভারটি এজেন্টকে প্রাকৃতিক ভাষার প্রম্পটের ভিত্তিতে রিয়েল-টাইম গাণিতিক কাজ করার সুযোগ দেবে।

![Visual Studio Code এর AI Toolkit এক্সটেনশনের Calculator Agent ইন্টারফেসের নিচের অংশের স্ক্রিনশট। এখানে “Tools” এবং “Structure output” এর জন্য এক্সপ্যান্ডেবল মেনু এবং “Choose output format” ড্রপডাউন “text” এ সেট করা। ডানদিকে “+ MCP Server” বাটন, একটি ইমেজ আইকন প্লেসহোল্ডার টুলস সেকশনের উপরে।](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.bn.png)

AI Toolkit এ MCP সার্ভার তৈরির জন্য টেমপ্লেট রয়েছে। আমরা Python টেমপ্লেট ব্যবহার করব ক্যালকুলেটর MCP সার্ভার তৈরির জন্য।

*Note*: AI Toolkit বর্তমানে Python এবং TypeScript সমর্থন করে।

1. **Agent (Prompt) Builder** এর **Tools** সেকশনে **+ MCP Server** বাটনে ক্লিক করুন। এটি **Command Palette** এর মাধ্যমে সেটআপ উইজার্ড চালু করবে।
2. **+ Add Server** নির্বাচন করুন।
3. **Create a New MCP Server** নির্বাচন করুন।
4. টেমপ্লেট হিসেবে **python-weather** নির্বাচন করুন।
5. MCP সার্ভার টেমপ্লেট সংরক্ষণের জন্য **Default folder** নির্বাচন করুন।
6. সার্ভারের নাম দিন: **Calculator**
7. একটি নতুন Visual Studio Code উইন্ডো খুলবে। **Yes, I trust the authors** নির্বাচন করুন।
8. টার্মিনালে যান (**Terminal** > **New Terminal**) এবং একটি ভার্চুয়াল এনভায়রনমেন্ট তৈরি করুন: `python -m venv .venv`
9. টার্মিনালে ভার্চুয়াল এনভায়রনমেন্ট সক্রিয় করুন:
    - Windows - `.venv\Scripts\activate`
    - macOS/Linux - `source venv/bin/activate`
10. ডিপেন্ডেন্সি ইনস্টল করুন: `pip install -e .[dev]`
11. **Activity Bar** এর **Explorer** ভিউতে **src** ডিরেক্টরি এক্সপ্যান্ড করুন এবং **server.py** ফাইলটি খুলুন।
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

### -4- ক্যালকুলেটর MCP সার্ভার সহ এজেন্ট চালানো

এখন যেহেতু আপনার এজেন্টের কাছে টুলস আছে, সেগুলো ব্যবহার করার পালা! এই ধাপে আপনি এজেন্টকে প্রম্পট পাঠিয়ে পরীক্ষা করবেন যে এজেন্ট ক্যালকুলেটর MCP সার্ভারের সঠিক টুল ব্যবহার করছে কিনা।

![Visual Studio Code এর AI Toolkit এক্সটেনশনের Calculator Agent ইন্টারফেসের স্ক্রিনশট। বাম প্যানেলে “Tools” এর অধীনে local-server-calculator_server নামে একটি MCP সার্ভার যুক্ত, যেখানে চারটি টুল: add, subtract, multiply, এবং divide দেখানো হয়েছে। একটি ব্যাজে চারটি টুল সক্রিয় আছে। নিচে “Structure output” সেকশন কোলাপ্স করা আছে এবং নীচে নীল “Run” বাটন। ডান প্যানেলে “Model Response” এর অধীনে multiply এবং subtract টুল ইনভোকেশন ইনপুটসহ দেখানো হয়েছে। চূড়ান্ত “Tool Response” 75.0 এবং নিচে “View Code” বাটন।](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.bn.png)

আপনি **Agent Builder** এর মাধ্যমে MCP ক্লায়েন্ট হিসেবে আপনার লোকাল ডেভ মেশিনে ক্যালকুলেটর MCP সার্ভার চালাবেন।

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` মানগুলো **subtract** টুলের জন্য নির্ধারিত হবে।
    - প্রতিটি টুল থেকে প্রাপ্ত উত্তর সংশ্লিষ্ট **Tool Response** এ প্রদর্শিত হবে।
    - মডেলের চূড়ান্ত আউটপুট **Model Response** এ দেখানো হবে।
2. এজেন্টকে আরও পরীক্ষা করার জন্য অতিরিক্ত প্রম্পট সাবমিট করুন। **User prompt** ফিল্ডে ক্লিক করে বিদ্যমান প্রম্পট পরিবর্তন করতে পারেন।
3. পরীক্ষা শেষে, **terminal** থেকে **CTRL/CMD+C** চাপিয়ে সার্ভার বন্ধ করুন।

## অ্যাসাইনমেন্ট

আপনার **server.py** ফাইলে একটি অতিরিক্ত টুল এন্ট্রি যোগ করার চেষ্টা করুন (যেমন: একটি সংখ্যার বর্গমূল ফেরত দেওয়া)। এমন প্রম্পট সাবমিট করুন যা আপনার নতুন (অথবা বিদ্যমান) টুল ব্যবহার করবে। নতুন টুল লোড করার জন্য সার্ভার রিস্টার্ট করতে ভুলবেন না।

## সমাধান

[Solution](./solution/README.md)

## মূল বিষয়সমূহ

এই অধ্যায় থেকে যা শেখা হলো:

- AI Toolkit এক্সটেনশন একটি চমৎকার ক্লায়েন্ট যা MCP সার্ভার এবং তাদের টুলস ব্যবহার করতে দেয়।
- MCP সার্ভারে নতুন টুল যোগ করে এজেন্টের ক্ষমতা বাড়ানো যায়, যাতে এটি পরিবর্তিত চাহিদা মেটাতে পারে।
- AI Toolkit এ টেমপ্লেট (যেমন Python MCP সার্ভার টেমপ্লেট) রয়েছে যা কাস্টম টুল তৈরি সহজ করে।

## অতিরিক্ত সম্পদ

- [AI Toolkit ডকুমেন্টেশন](https://aka.ms/AIToolkit/doc)

## পরবর্তী ধাপ
- পরবর্তী: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**অস্বীকারোক্তি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা সঠিকতার জন্য চেষ্টা করি, তবে অনুগ্রহ করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ভুল বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার স্থানীয় ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসাবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদের পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।