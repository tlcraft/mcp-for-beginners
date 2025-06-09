<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T18:45:20+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "bn"
}
-->
# পাঠ: একটি ওয়েব সার্চ MCP সার্ভার তৈরি করা

এই অধ্যায়ে দেখানো হবে কীভাবে একটি বাস্তব বিশ্বের AI এজেন্ট তৈরি করা যায় যা বাহ্যিক API-গুলোর সাথে ইন্টিগ্রেট করে, বিভিন্ন ধরনের ডেটা পরিচালনা করে, ত্রুটি হ্যান্ডেল করে এবং একাধিক টুল সমন্বয় করে—সবকিছু প্রোডাকশন-রেডি ফরম্যাটে। আপনি দেখতে পাবেন:

- **প্রমাণীকরণ প্রয়োজন এমন বাহ্যিক API-গুলোর সাথে ইন্টিগ্রেশন**
- **বিভিন্ন ধরনের ডেটা হ্যান্ডলিং একাধিক এন্ডপয়েন্ট থেকে**
- **দৃঢ় ত্রুটি হ্যান্ডলিং এবং লগিং কৌশল**
- **একক সার্ভারে একাধিক টুলের সমন্বয়**

শেষ পর্যন্ত, আপনি এমন প্যাটার্ন এবং সেরা অনুশীলনের সঙ্গে বাস্তব অভিজ্ঞতা পাবেন যা উন্নত AI এবং LLM-চালিত অ্যাপ্লিকেশনগুলোর জন্য অপরিহার্য।

## পরিচিতি

এই পাঠে, আপনি শিখবেন কীভাবে একটি উন্নত MCP সার্ভার এবং ক্লায়েন্ট তৈরি করবেন যা SerpAPI ব্যবহার করে রিয়েল-টাইম ওয়েব ডেটার মাধ্যমে LLM ক্ষমতাকে প্রসারিত করে। এটি একটি গুরুত্বপূর্ণ দক্ষতা, যা গতিশীল AI এজেন্ট তৈরি করতে সাহায্য করে যারা ওয়েব থেকে সর্বশেষ তথ্য অ্যাক্সেস করতে পারে।

## শেখার উদ্দেশ্য

এই পাঠের শেষে, আপনি সক্ষম হবেন:

- MCP সার্ভারে বাহ্যিক API (যেমন SerpAPI) নিরাপদে ইন্টিগ্রেট করা
- ওয়েব, নিউজ, প্রোডাক্ট সার্চ এবং প্রশ্নোত্তর জন্য একাধিক টুল বাস্তবায়ন করা
- LLM ব্যবহারের জন্য গঠনমূলক ডেটা পার্স এবং ফরম্যাট করা
- ত্রুটি পরিচালনা এবং API রেট লিমিট দক্ষতার সঙ্গে হ্যান্ডলিং করা
- স্বয়ংক্রিয় এবং ইন্টারেক্টিভ উভয় MCP ক্লায়েন্ট তৈরি ও পরীক্ষা করা

## ওয়েব সার্চ MCP সার্ভার

এই অংশে ওয়েব সার্চ MCP সার্ভারের আর্কিটেকচার এবং ফিচারগুলো উপস্থাপন করা হয়েছে। আপনি দেখতে পাবেন কীভাবে FastMCP এবং SerpAPI একসাথে ব্যবহার করে LLM ক্ষমতাকে রিয়েল-টাইম ওয়েব ডেটার সাথে সম্প্রসারিত করা হয়।

### সারাংশ

এই ইমপ্লিমেন্টেশন চারটি টুল প্রদর্শন করে যা MCP-র ক্ষমতা দেখায় কিভাবে বিভিন্ন ধরনের বাহ্যিক API-চালিত কাজ নিরাপদ ও কার্যকরভাবে পরিচালনা করা যায়:

- **general_search**: বিস্তৃত ওয়েব ফলাফলের জন্য
- **news_search**: সাম্প্রতিক শিরোনামের জন্য
- **product_search**: ই-কমার্স ডেটার জন্য
- **qna**: প্রশ্নোত্তর অংশের জন্য

### ফিচারসমূহ
- **কোড উদাহরণ**: ভাষা-নির্দিষ্ট কোড ব্লক (Python সহ অন্যান্য ভাষায় সহজে সম্প্রসারণযোগ্য) স্পষ্টতার জন্য কলাপসযোগ্য সেকশন ব্যবহার করে

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

ক্লায়েন্ট চালানোর আগে, সার্ভার কী করে তা বোঝা দরকার। [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) ফাইলটি দেখুন।

এখানে একটি সংক্ষিপ্ত উদাহরণ দেওয়া হলো কীভাবে সার্ভার একটি টুল ডিফাইন এবং রেজিস্টার করে:

<details>  
<summary>Python Server</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **বাহ্যিক API ইন্টিগ্রেশন**: API কী এবং বাহ্যিক রিকোয়েস্টের নিরাপদ হ্যান্ডলিং দেখানো হয়েছে
- **গঠনমূলক ডেটা পার্সিং**: API রেসপন্সকে LLM-বান্ধব ফরম্যাটে রূপান্তর করার প্রক্রিয়া
- **ত্রুটি হ্যান্ডলিং**: উপযুক্ত লগিং সহ শক্তিশালী ত্রুটি ব্যবস্থাপনা
- **ইন্টারেক্টিভ ক্লায়েন্ট**: স্বয়ংক্রিয় টেস্ট এবং ইন্টারেক্টিভ মোড উভয়ই অন্তর্ভুক্ত
- **কনটেক্সট ম্যানেজমেন্ট**: MCP কনটেক্সট ব্যবহার করে লগিং এবং রিকোয়েস্ট ট্র্যাকিং

## পূর্বশর্তসমূহ

শুরু করার আগে নিশ্চিত করুন আপনার পরিবেশ সঠিকভাবে সেটআপ করা হয়েছে নিম্নলিখিত ধাপগুলো অনুসরণ করে। এটি নিশ্চিত করবে সমস্ত ডিপেনডেন্সি ইনস্টল এবং API কী সঠিকভাবে কনফিগার করা হয়েছে যাতে উন্নয়ন ও পরীক্ষণ নির্বিঘ্ন হয়।

- Python 3.8 বা তার উপরে
- SerpAPI API কী (সাইন আপ করুন [SerpAPI](https://serpapi.com/) - ফ্রি টিয়ার উপলব্ধ)

## ইনস্টলেশন

শুরু করতে, পরিবেশ সেটআপের জন্য নিচের ধাপগুলো অনুসরণ করুন:

1. uv (সুপারিশকৃত) বা pip ব্যবহার করে ডিপেনডেন্সি ইনস্টল করুন:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. প্রজেক্ট রুটে `.env` ফাইল তৈরি করুন এবং আপনার SerpAPI কী যোগ করুন:

```
SERPAPI_KEY=your_serpapi_key_here
```

## ব্যবহার

ওয়েব সার্চ MCP সার্ভার হল মূল উপাদান যা SerpAPI-এর সাথে ইন্টিগ্রেট করে ওয়েব, নিউজ, প্রোডাক্ট সার্চ এবং প্রশ্নোত্তর টুলগুলো এক্সপোজ করে। এটি আসা রিকোয়েস্টগুলি হ্যান্ডেল করে, API কল ম্যানেজ করে, রেসপন্স পার্স করে এবং ক্লায়েন্টকে গঠনমূলক ফলাফল পাঠায়।

সম্পূর্ণ ইমপ্লিমেন্টেশন আপনি দেখতে পারেন [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) ফাইলে।

### সার্ভার চালানো

MCP সার্ভার শুরু করতে নিচের কমান্ডটি ব্যবহার করুন:

```bash
python server.py
```

সার্ভার stdio-ভিত্তিক MCP সার্ভার হিসেবে চলবে যা ক্লায়েন্ট সরাসরি সংযুক্ত হতে পারে।

### ক্লায়েন্ট মোড

ক্লায়েন্ট (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)।

### ক্লায়েন্ট চালানো

স্বয়ংক্রিয় টেস্ট চালাতে (এটি স্বয়ংক্রিয়ভাবে সার্ভার চালু করবে):

```bash
python client.py
```

অথবা ইন্টারেক্টিভ মোডে চালান:

```bash
python client.py --interactive
```

### বিভিন্ন পদ্ধতিতে টেস্টিং

সার্ভারের টুলগুলো পরীক্ষা এবং ইন্টারেক্ট করার জন্য বিভিন্ন পদ্ধতি রয়েছে, যা আপনার প্রয়োজন এবং কাজের প্রবাহ অনুযায়ী।

#### MCP Python SDK দিয়ে কাস্টম টেস্ট স্ক্রিপ্ট লেখা
আপনি MCP Python SDK ব্যবহার করে নিজস্ব টেস্ট স্ক্রিপ্টও তৈরি করতে পারেন:

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

এই প্রসঙ্গে, "টেস্ট স্ক্রিপ্ট" বলতে বোঝায় এমন একটি কাস্টম Python প্রোগ্রাম যা আপনি MCP সার্ভারের ক্লায়েন্ট হিসেবে লেখেন। এটি একটি ফরমাল ইউনিট টেস্ট না হলেও, প্রোগ্রাম্যাটিক্যালি সার্ভারের সাথে সংযোগ স্থাপন করে যেকোনো টুল কল করতে এবং ফলাফল পরীক্ষা করতে সাহায্য করে। এই পদ্ধতি উপযোগী:

- টুল কল প্রোটোটাইপিং ও পরীক্ষা-নিরীক্ষার জন্য
- বিভিন্ন ইনপুটে সার্ভারের প্রতিক্রিয়া যাচাই করার জন্য
- পুনরাবৃত্ত টুল কল স্বয়ংক্রিয় করার জন্য
- MCP সার্ভারের উপর ভিত্তি করে নিজস্ব ওয়ার্কফ্লো বা ইন্টিগ্রেশন তৈরি করার জন্য

আপনি দ্রুত নতুন কোয়েরি চেষ্টা করতে, টুলের আচরণ ডিবাগ করতে বা উন্নত স্বয়ংক্রিয়তার জন্য শুরু পয়েন্ট হিসেবে টেস্ট স্ক্রিপ্ট ব্যবহার করতে পারেন। নিচে MCP Python SDK ব্যবহার করে এমন একটি স্ক্রিপ্ট তৈরির উদাহরণ দেওয়া হলো:

## টুল বিবরণ

সার্ভার দ্বারা প্রদত্ত নিম্নলিখিত টুলগুলো বিভিন্ন ধরনের সার্চ এবং কোয়েরি সম্পাদনের জন্য ব্যবহার করা যেতে পারে। প্রতিটি টুলের বিবরণ, প্যারামিটার এবং উদাহরণ নিচে দেওয়া হয়েছে।

এই অংশে প্রতিটি উপলব্ধ টুল এবং তাদের প্যারামিটার সম্পর্কে বিস্তারিত তথ্য রয়েছে।

### general_search

একটি সাধারণ ওয়েব সার্চ করে এবং ফরম্যাট করা ফলাফল ফেরত দেয়।

**এই টুল কল করার উপায়:**

আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে `general_search` কল করতে পারেন, অথবা Inspector বা ইন্টারেক্টিভ ক্লায়েন্ট মোড ব্যবহার করেও। SDK ব্যবহার করে একটি কোড উদাহরণ:

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

অথবা ইন্টারেক্টিভ মোডে, `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): সার্চ কোয়েরি নির্বাচন করুন

**উদাহরণ রিকোয়েস্ট:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

কোনো কোয়েরির সাথে সম্পর্কিত সাম্প্রতিক সংবাদ নিবন্ধ সার্চ করে।

**এই টুল কল করার উপায়:**

আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে `news_search` কল করতে পারেন, অথবা Inspector বা ইন্টারেক্টিভ ক্লায়েন্ট মোড ব্যবহার করেও। SDK ব্যবহার করে একটি কোড উদাহরণ:

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

অথবা ইন্টারেক্টিভ মোডে, `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): সার্চ কোয়েরি নির্বাচন করুন

**উদাহরণ রিকোয়েস্ট:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

কোনো কোয়েরির সাথে মেলে এমন পণ্য সার্চ করে।

**এই টুল কল করার উপায়:**

আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে `product_search` কল করতে পারেন, অথবা Inspector বা ইন্টারেক্টিভ ক্লায়েন্ট মোড ব্যবহার করেও। SDK ব্যবহার করে একটি কোড উদাহরণ:

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

অথবা ইন্টারেক্টিভ মোডে, `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): পণ্য সার্চ কোয়েরি নির্বাচন করুন

**উদাহরণ রিকোয়েস্ট:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

সার্চ ইঞ্জিন থেকে সরাসরি প্রশ্নের উত্তর পায়।

**এই টুল কল করার উপায়:**

আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে `qna` কল করতে পারেন, অথবা Inspector বা ইন্টারেক্টিভ ক্লায়েন্ট মোড ব্যবহার করেও। SDK ব্যবহার করে একটি কোড উদাহরণ:

<details>
<summary>Python Example</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

অথবা ইন্টারেক্টিভ মোডে, `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): উত্তর খুঁজতে প্রশ্নটি নির্বাচন করুন

**উদাহরণ রিকোয়েস্ট:**

```json
{
  "question": "what is artificial intelligence"
}
```

## কোড বিস্তারিত

এই অংশে সার্ভার এবং ক্লায়েন্ট ইমপ্লিমেন্টেশনের জন্য কোড স্নিপেট এবং রেফারেন্স দেওয়া হয়েছে।

<details>
<summary>Python</summary>

সম্পূর্ণ ইমপ্লিমেন্টেশন দেখতে [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) ফাইল দেখুন।

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## এই পাঠের উন্নত ধারণাসমূহ

আপনি তৈরি শুরু করার আগে, এখানে কিছু গুরুত্বপূর্ণ উন্নত ধারণা দেওয়া হলো যা এই অধ্যায় জুড়ে বারবার আসবে। এগুলো বোঝা আপনাকে সাহায্য করবে সহজে অনুসরণ করতে, যদিও আপনি নতুন হন:

- **মাল্টি-টুল সমন্বয়**: এর অর্থ একক MCP সার্ভারে একাধিক ভিন্ন টুল (যেমন ওয়েব সার্চ, নিউজ সার্চ, প্রোডাক্ট সার্চ, এবং Q&A) চালানো। এটি আপনার সার্ভারকে বিভিন্ন ধরনের কাজ করার ক্ষমতা দেয়, শুধু একটি নয়।
- **API রেট লিমিট হ্যান্ডলিং**: অনেক বাহ্যিক API (যেমন SerpAPI) নির্দিষ্ট সময়ে কত রিকোয়েস্ট করতে পারবেন তা সীমাবদ্ধ করে। ভালো কোড এই সীমা পরীক্ষা করে এবং তা অতিক্রম করলে সুষ্ঠুভাবে হ্যান্ডল করে, যাতে আপনার অ্যাপ ভেঙে না পড়ে।
- **গঠনমূলক ডেটা পার্সিং**: API রেসপন্স প্রায়শই জটিল এবং নেস্টেড হয়। এই ধারণাটি হলো সেই রেসপন্সগুলোকে পরিষ্কার, সহজে ব্যবহারযোগ্য ফরম্যাটে রূপান্তর করা যা LLM বা অন্যান্য প্রোগ্রামের জন্য উপযোগী।
- **ত্রুটি পুনরুদ্ধার**: কখনও কখনও সমস্যা হয়—হয়তো নেটওয়ার্ক ব্যর্থ হয়, অথবা API প্রত্যাশিত ডেটা দেয় না। ত্রুটি পুনরুদ্ধার মানে আপনার কোড এসব সমস্যা সামলাতে পারে এবং এখনও ব্যবহারযোগ্য ফিডব্যাক দিতে পারে, ক্র্যাশ না করে।
- **প্যারামিটার ভ্যালিডেশন**: এর মানে আপনার টুলগুলোতে দেওয়া ইনপুটগুলো সঠিক এবং নিরাপদ কিনা পরীক্ষা করা। এতে ডিফল্ট মান সেট করা এবং টাইপ যাচাই অন্তর্ভুক্ত, যা বাগ ও বিভ্রান্তি প্রতিরোধ করে।

এই অংশটি আপনাকে সাহায্য করবে ওয়েব সার্চ MCP সার্ভারের সঙ্গে কাজ করার সময় সাধারণ সমস্যাগুলো সনাক্ত এবং সমাধান করতে। যদি আপনি ত্রুটি বা অপ্রত্যাশিত আচরণ দেখতে পান, এই ট্রাবলশুটিং অংশটি প্রথমে দেখুন—এগুলি প্রায়ই দ্রুত সমস্যা সমাধান করে।

## ট্রাবলশুটিং

ওয়েব সার্চ MCP সার্ভারের সঙ্গে কাজ করার সময় মাঝে মাঝে সমস্যা দেখা দিতে পারে—এটি স্বাভাবিক যখন আপনি বাহ্যিক API এবং নতুন টুল নিয়ে কাজ করছেন। এই অংশটি সবচেয়ে সাধারণ সমস্যাগুলোর বাস্তবসম্মত সমাধান দেয়, যাতে আপনি দ্রুত পুনরায় পথে ফিরতে পারেন। যদি কোনো ত্রুটি পান, এখান থেকে শুরু করুন: নিচের টিপসগুলো বেশিরভাগ ব্যবহারকারীর মুখোমুখি হওয়া সমস্যা সমাধান করে এবং অতিরিক্ত সাহায্য ছাড়াই আপনার সমস্যা মিটিয়ে দিতে পারে।

### সাধারণ সমস্যা

নিচে কিছু সবচেয়ে সাধারণ সমস্যা এবং তাদের পরিষ্কার ব্যাখ্যা ও সমাধানের ধাপ দেওয়া হলো:

1. **.env ফাইলে SERPAPI_KEY অনুপস্থিত**
   - যদি আপনি `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` ত্রুটি দেখেন, তাহলে প্রয়োজন হলে `.env` ফাইল তৈরি করুন। যদি আপনার কী সঠিক হয় কিন্তু ত্রুটি আসে, তাহলে চেক করুন আপনার ফ্রি টিয়ারের কোটা শেষ হয়ে গেছে কিনা।

### ডিবাগ মোড

ডিফল্টভাবে, অ্যাপ শুধুমাত্র গুরুত্বপূর্ণ তথ্য লগ করে। যদি আপনি আরও বিস্তারিত দেখতে চান (যেমন জটিল সমস্যা নির্ণয়ের জন্য), তাহলে DEBUG মোড চালু করতে পারেন। এটি অ্যাপের প্রতিটি ধাপের আরও বিস্তারিত তথ্য দেখাবে।

**উদাহরণ: সাধারণ আউটপুট**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**উদাহরণ: DEBUG আউটপুট**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

দ্রষ্টব্য, DEBUG মোডে HTTP রিকোয়েস্ট, রেসপন্স এবং অন্যান্য অভ্যন্তরীণ বিস্তারিত লাইন যুক্ত হয়। এটি সমস্যা সমাধানে খুবই সহায়ক।

DEBUG মোড চালু করতে, আপনার `client.py` or `server.py` এর শীর্ষে লগিং লেভেল DEBUG এ সেট করুন:

<details>
<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## পরবর্তী ধাপ

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**বিস্তারিত সতর্কতা**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ভুল বা অসঙ্গতি থাকতে পারে। মূল নথি তার নিজ ভাষায় সর্বোত্তম এবং কর্তৃপক্ষপ্রাপ্ত উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।