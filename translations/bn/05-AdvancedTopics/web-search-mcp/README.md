<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:08:20+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "bn"
}
-->
# পাঠ: একটি ওয়েব সার্চ MCP সার্ভার তৈরি করা

এই অধ্যায়ে দেখানো হবে কিভাবে একটি বাস্তব জীবনের AI এজেন্ট তৈরি করা যায় যা বহিরাগত API এর সাথে সংযুক্ত হয়, বিভিন্ন ধরনের ডেটা হ্যান্ডেল করে, ত্রুটি ব্যবস্থাপনা করে, এবং একাধিক টুল একসঙ্গে পরিচালনা করে—সবই প্রোডাকশন-রেডি ফরম্যাটে। আপনি দেখতে পাবেন:

- **প্রমাণীকরণসহ বহিরাগত API সংযোগ**
- **বিভিন্ন এন্ডপয়েন্ট থেকে বিভিন্ন ধরনের ডেটা হ্যান্ডেলিং**
- **মজবুত ত্রুটি পরিচালনা এবং লগিং কৌশল**
- **একক সার্ভারে একাধিক টুলের সমন্বয়**

অবশেষে, আপনি উন্নত AI এবং LLM-চালিত অ্যাপ্লিকেশনগুলোর জন্য প্রয়োজনীয় প্যাটার্ন এবং সেরা অনুশীলনের ব্যবহারিক অভিজ্ঞতা পাবেন।

## পরিচিতি

এই পাঠে, আপনি শিখবেন কিভাবে একটি উন্নত MCP সার্ভার এবং ক্লায়েন্ট তৈরি করতে হয় যা SerpAPI ব্যবহার করে LLM এর ক্ষমতাকে রিয়েল-টাইম ওয়েব ডেটার সাথে সম্প্রসারিত করে। এটি একটি গুরুত্বপূর্ণ দক্ষতা যা গতিশীল AI এজেন্ট তৈরি করার জন্য প্রয়োজন, যারা ওয়েব থেকে সর্বশেষ তথ্য অ্যাক্সেস করতে পারে।

## শেখার উদ্দেশ্য

এই পাঠ শেষ করার পর, আপনি সক্ষম হবেন:

- MCP সার্ভারে নিরাপদভাবে বহিরাগত API (যেমন SerpAPI) সংযুক্ত করতে
- ওয়েব, সংবাদ, পণ্য অনুসন্ধান এবং প্রশ্নোত্তরের জন্য একাধিক টুল প্রয়োগ করতে
- LLM ব্যবহারের জন্য কাঠামোবদ্ধ ডেটা বিশ্লেষণ এবং ফরম্যাট করতে
- ত্রুটি সামলাতে এবং API রেট লিমিট কার্যকরভাবে পরিচালনা করতে
- স্বয়ংক্রিয় এবং ইন্টারঅ্যাকটিভ MCP ক্লায়েন্ট তৈরি ও পরীক্ষা করতে

## ওয়েব সার্চ MCP সার্ভার

এই অংশে ওয়েব সার্চ MCP সার্ভারের স্থাপত্য এবং বৈশিষ্ট্যগুলো উপস্থাপন করা হবে। আপনি দেখতে পাবেন কিভাবে FastMCP এবং SerpAPI একসঙ্গে ব্যবহার করে LLM এর ক্ষমতাকে রিয়েল-টাইম ওয়েব ডেটার সাথে সম্প্রসারিত করা হয়।

### সারাংশ

এই ইমপ্লিমেন্টেশনে চারটি টুল রয়েছে যা MCP এর বহিরাগত API-চালিত বিভিন্ন কাজ নিরাপদ ও দক্ষভাবে পরিচালনার ক্ষমতা প্রদর্শন করে:

- **general_search**: সাধারণ ওয়েব ফলাফলের জন্য
- **news_search**: সাম্প্রতিক শিরোনামের জন্য
- **product_search**: ই-কমার্স ডেটার জন্য
- **qna**: প্রশ্নোত্তর স্নিপেটের জন্য

### বৈশিষ্ট্যসমূহ
- **কোড উদাহরণ**: ভাষা-নির্দিষ্ট কোড ব্লক রয়েছে Python এর জন্য (এবং সহজেই অন্যান্য ভাষায় সম্প্রসারিতযোগ্য) যা স্পষ্টতার জন্য কল্যাপ্সযোগ্য সেকশন ব্যবহার করে

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

ক্লায়েন্ট চালানোর আগে, সার্ভার কী করে তা বোঝা দরকার। [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) ফাইলটি দেখুন।

নিচে একটি সংক্ষিপ্ত উদাহরণ দেওয়া হলো কিভাবে সার্ভার একটি টুল ডিফাইন এবং রেজিস্টার করে:

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

- **বহিরাগত API সংযোগ**: API কী এবং বহিরাগত রিকোয়েস্ট নিরাপদে হ্যান্ডেল করার উদাহরণ
- **কাঠামোবদ্ধ ডেটা পার্সিং**: API রেসপন্সকে LLM-ফ্রেন্ডলি ফরম্যাটে রূপান্তর করার উপায়
- **ত্রুটি ব্যবস্থাপনা**: যথাযথ লগিং সহ মজবুত ত্রুটি হ্যান্ডলিং
- **ইন্টারঅ্যাকটিভ ক্লায়েন্ট**: স্বয়ংক্রিয় টেস্ট এবং ইন্টারঅ্যাকটিভ মোড উভয়ই অন্তর্ভুক্ত
- **কন্টেক্সট ম্যানেজমেন্ট**: MCP Context ব্যবহার করে লগিং এবং রিকোয়েস্ট ট্র্যাকিং

## পূর্বপ্রয়োজনীয়তা

শুরু করার আগে, নিশ্চিত করুন আপনার পরিবেশ সঠিকভাবে সেটআপ হয়েছে নিম্নলিখিত ধাপগুলো অনুসরণ করে। এতে সব ডিপেনডেন্সি ইনস্টল থাকবে এবং API কী সঠিকভাবে কনফিগার করা থাকবে যাতে উন্নয়ন ও পরীক্ষায় সমস্যা না হয়।

- Python 3.8 বা তার উপরে
- SerpAPI API কী (সাইন আপ করুন [SerpAPI](https://serpapi.com/) - ফ্রি টিয়ার উপলব্ধ)

## ইনস্টলেশন

শুরু করতে, আপনার পরিবেশ সেটআপের জন্য নিচের ধাপগুলো অনুসরণ করুন:

1. uv (প্রস্তাবিত) বা pip ব্যবহার করে ডিপেনডেন্সি ইনস্টল করুন:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. প্রজেক্ট রুটে `.env` ফাইল তৈরি করুন এবং আপনার SerpAPI কী সেখানে রাখুন:

```
SERPAPI_KEY=your_serpapi_key_here
```

## ব্যবহার

ওয়েব সার্চ MCP সার্ভার হল মূল উপাদান যা SerpAPI এর সাথে সংযুক্ত হয়ে ওয়েব, সংবাদ, পণ্য অনুসন্ধান এবং প্রশ্নোত্তরের জন্য টুলগুলো এক্সপোজ করে। এটি আসা রিকোয়েস্ট হ্যান্ডেল করে, API কল ম্যানেজ করে, রেসপন্স পার্স করে, এবং কাঠামোবদ্ধ ফলাফল ক্লায়েন্টকে ফেরত দেয়।

সম্পূর্ণ ইমপ্লিমেন্টেশন দেখতে পারেন [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) ফাইলে।

### সার্ভার চালানো

MCP সার্ভার চালু করতে নিচের কমান্ডটি ব্যবহার করুন:

```bash
python server.py
```

সার্ভার stdio-ভিত্তিক MCP সার্ভার হিসেবে চলবে যা ক্লায়েন্ট সরাসরি সংযুক্ত হতে পারবে।

### ক্লায়েন্ট মোড

ক্লায়েন্ট (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)।

### ক্লায়েন্ট চালানো

স্বয়ংক্রিয় টেস্ট চালাতে (এতে সার্ভার স্বয়ংক্রিয়ভাবে শুরু হবে):

```bash
python client.py
```

অথবা ইন্টারঅ্যাকটিভ মোডে চালাতে:

```bash
python client.py --interactive
```

### বিভিন্ন পদ্ধতিতে পরীক্ষা

সার্ভারের সরবরাহকৃত টুলগুলো পরীক্ষা এবং ইন্টারঅ্যাক্ট করার বিভিন্ন উপায় আছে, যা আপনার প্রয়োজন ও কাজের প্রবাহ অনুসারে পরিবর্তিত হতে পারে।

#### MCP Python SDK দিয়ে কাস্টম টেস্ট স্ক্রিপ্ট লেখা
আপনি MCP Python SDK ব্যবহার করে নিজের টেস্ট স্ক্রিপ্টও তৈরি করতে পারেন:

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

এখানে "টেস্ট স্ক্রিপ্ট" বলতে বোঝায় একটি কাস্টম Python প্রোগ্রাম যা আপনি MCP সার্ভারের ক্লায়েন্ট হিসেবে লিখেন। এটি একটি ফরমাল ইউনিট টেস্ট নয়, বরং প্রোগ্রাম্যাটিকভাবে সার্ভারের সাথে সংযোগ করে টুলগুলো প্যারামিটার সহ কল করে এবং ফলাফল পরীক্ষা করার উপায়। এই পদ্ধতি কাজে লাগে:

- টুল কলের প্রোটোটাইপ এবং পরীক্ষা করার জন্য
- সার্ভারের বিভিন্ন ইনপুটে প্রতিক্রিয়া যাচাই করতে
- টুল কল পুনরাবৃত্তি স্বয়ংক্রিয় করতে
- MCP সার্ভারের ওপর ভিত্তি করে নিজের কাজের প্রবাহ বা ইন্টিগ্রেশন তৈরি করতে

টেস্ট স্ক্রিপ্ট ব্যবহার করে দ্রুত নতুন প্রশ্ন পরীক্ষা করতে, টুলের আচরণ ডিবাগ করতে বা উন্নত অটোমেশনের জন্য শুরু করতে পারেন। নিচে MCP Python SDK ব্যবহার করে এমন একটি স্ক্রিপ্ট তৈরির উদাহরণ দেওয়া হলো:

## টুল বর্ণনা

সার্ভার থেকে সরবরাহকৃত নিচের টুলগুলো ব্যবহার করে বিভিন্ন ধরনের অনুসন্ধান এবং প্রশ্নোত্তর করতে পারবেন। প্রতিটি টুলের প্যারামিটার এবং ব্যবহার উদাহরণ নিচে দেওয়া হলো।

এই অংশে প্রতিটি উপলব্ধ টুল এবং তাদের প্যারামিটার বিস্তারিতভাবে বর্ণনা করা হয়েছে।

### general_search

সাধারণ ওয়েব অনুসন্ধান করে ফরম্যাট করা ফলাফল প্রদান করে।

**কিভাবে কল করবেন:**

`general_search` আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে কল করতে পারেন, অথবা Inspector বা ইন্টারঅ্যাকটিভ ক্লায়েন্ট মোড থেকে ইন্টারঅ্যাকটিভলি ব্যবহার করতে পারেন। SDK ব্যবহার করে কোড উদাহরণ:

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

অথবা, ইন্টারঅ্যাকটিভ মোডে, `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (স্ট্রিং): অনুসন্ধান প্রশ্ন নির্বাচন করুন

**উদাহরণ রিকোয়েস্ট:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

একটি প্রশ্নের সাথে সম্পর্কিত সাম্প্রতিক সংবাদ আর্টিকেল অনুসন্ধান করে।

**কিভাবে কল করবেন:**

`news_search` আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে কল করতে পারেন, অথবা Inspector বা ইন্টারঅ্যাকটিভ ক্লায়েন্ট মোড থেকে ইন্টারঅ্যাকটিভলি ব্যবহার করতে পারেন। SDK ব্যবহার করে কোড উদাহরণ:

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

অথবা, ইন্টারঅ্যাকটিভ মোডে, `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (স্ট্রিং): অনুসন্ধান প্রশ্ন নির্বাচন করুন

**উদাহরণ রিকোয়েস্ট:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

একটি প্রশ্নের সাথে মিলিয়ে পণ্য অনুসন্ধান করে।

**কিভাবে কল করবেন:**

`product_search` আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে কল করতে পারেন, অথবা Inspector বা ইন্টারঅ্যাকটিভ ক্লায়েন্ট মোড থেকে ইন্টারঅ্যাকটিভলি ব্যবহার করতে পারেন। SDK ব্যবহার করে কোড উদাহরণ:

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

অথবা, ইন্টারঅ্যাকটিভ মোডে, `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (স্ট্রিং): পণ্য অনুসন্ধান প্রশ্ন নির্বাচন করুন

**উদাহরণ রিকোয়েস্ট:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

সার্চ ইঞ্জিন থেকে সরাসরি প্রশ্নের উত্তর নিয়ে আসে।

**কিভাবে কল করবেন:**

`qna` আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে কল করতে পারেন, অথবা Inspector বা ইন্টারঅ্যাকটিভ ক্লায়েন্ট মোড থেকে ইন্টারঅ্যাকটিভলি ব্যবহার করতে পারেন। SDK ব্যবহার করে কোড উদাহরণ:

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

অথবা, ইন্টারঅ্যাকটিভ মোডে, `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (স্ট্রিং): উত্তর খোঁজার জন্য প্রশ্ন নির্বাচন করুন

**উদাহরণ রিকোয়েস্ট:**

```json
{
  "question": "what is artificial intelligence"
}
```

## কোড বিস্তারিত

এই অংশে সার্ভার এবং ক্লায়েন্ট ইমপ্লিমেন্টেশনের কোড স্নিপেট এবং রেফারেন্স দেওয়া হয়েছে।

<details>
<summary>Python</summary>

সম্পূর্ণ ইমপ্লিমেন্টেশন দেখতে [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) দেখুন।

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## এই পাঠের উন্নত ধারণা

আপনি তৈরি শুরু করার আগে, এখানে কিছু গুরুত্বপূর্ণ উন্নত ধারণা দেওয়া হলো যা এই অধ্যায়ে বারংবার আসবে। এগুলো বোঝা আপনাকে সহায়তা করবে সহজে ফলো করতে, যদিও আপনি নতুন হন:

- **মাল্টি-টুল সমন্বয়**: এর মানে হল একাধিক ভিন্ন টুল (যেমন ওয়েব সার্চ, সংবাদ অনুসন্ধান, পণ্য অনুসন্ধান, এবং প্রশ্নোত্তর) একক MCP সার্ভারে চালানো। এটি আপনার সার্ভারকে বিভিন্ন কাজ সামলাতে সক্ষম করে, শুধুমাত্র একটি নয়।
- **API রেট লিমিট হ্যান্ডলিং**: অনেক বহিরাগত API (যেমন SerpAPI) নির্দিষ্ট সময়ের মধ্যে কত রিকোয়েস্ট করা যাবে তা সীমাবদ্ধ করে। ভালো কোড এই সীমা পরীক্ষা করে এবং সেগুলোকে সুন্দরভাবে হ্যান্ডেল করে যাতে আপনার অ্যাপ ক্র্যাশ না করে।
- **কাঠামোবদ্ধ ডেটা পার্সিং**: API রেসপন্স সাধারণত জটিল ও নেস্টেড হয়। এই ধারণা হল সেই রেসপন্সগুলোকে পরিষ্কার, ব্যবহার সহজ এমন ফরম্যাটে রূপান্তর করা যা LLM বা অন্য প্রোগ্রামের জন্য সুবিধাজনক।
- **ত্রুটি পুনরুদ্ধার**: কখনো কখনো সমস্যা হয়—যেমন নেটওয়ার্ক ব্যর্থতা বা API প্রত্যাশিত ডেটা না দেওয়া। ত্রুটি পুনরুদ্ধার মানে আপনার কোড এইসব সমস্যা সামলাতে পারে এবং কার্যকর প্রতিক্রিয়া দেয়, ক্র্যাশ না করে।
- **প্যারামিটার যাচাই**: টুলগুলোতে যেসব ইনপুট দেওয়া হয় তা সঠিক ও নিরাপদ কিনা পরীক্ষা করা। এতে ডিফল্ট মান সেট করা এবং টাইপ যাচাই অন্তর্ভুক্ত, যা বাগ ও বিভ্রান্তি রোধ করে।

## সমস্যা সমাধান

ওয়েব সার্চ MCP সার্ভারের সঙ্গে কাজ করার সময় মাঝে মাঝে সমস্যা হতে পারে—এটি স্বাভাবিক যখন আপনি বহিরাগত API এবং নতুন টুল নিয়ে কাজ করছেন। এই অংশে সবচেয়ে সাধারণ সমস্যাগুলোর বাস্তবসম্মত সমাধান দেওয়া হয়েছে, যাতে দ্রুত কাজে ফিরে যেতে পারেন। যদি কোনো ত্রুটি পান, এখানে শুরু করুন: নিচের টিপসগুলো বেশিরভাগ ব্যবহারকারীর সমস্যার সমাধান করে থাকে এবং অতিরিক্ত সাহায্য ছাড়াই সমস্যার সমাধান দিতে পারে।

### সাধারণ সমস্যা

নিচে কিছু সবচেয়ে বেশি দেখা সমস্যার তালিকা দেওয়া হলো, স্পষ্ট ব্যাখ্যা ও সমাধানের ধাপসহ:

1. **.env ফাইলে SERPAPI_KEY অনুপস্থিত**
   - যদি আপনি এই ত্রুটি দেখেন `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your ``, তাহলে `.env` ফাইলটি প্রয়োজন অনুযায়ী তৈরি করুন। আপনার কী সঠিক হলেও যদি এই ত্রুটি আসে, তাহলে আপনার ফ্রি টিয়ার কোটা শেষ হয়ে গেছে কিনা পরীক্ষা করুন।

### ডিবাগ মোড

ডিফল্টভাবে, অ্যাপ শুধুমাত্র গুরুত্বপূর্ণ তথ্য লগ করে। যদি আপনি আরও বিস্তারিত দেখতে চান (যেমন জটিল সমস্যা নির্ণয়ের জন্য), তাহলে DEBUG মোড চালু করতে পারেন। এতে অ্যাপের প্রতিটি ধাপের অনেক বেশি তথ্য প্রদর্শিত হবে।

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

দেখবেন DEBUG মোডে HTTP রিকোয়েস্ট, রেসপন্স এবং অন্যান্য অভ্যন্তরীণ তথ্য সম্পর্কে অতিরিক্ত লাইন থাকে। এটি সমস্যা সমাধানে খুব সহায়ক।

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

## পরবর্তী পদক্ষেপ

- [6. কমিউনিটি অবদান](../../06-CommunityContributions/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার স্বদেশী ভাষায়ই সর্বোত্তম এবং নির্ভরযোগ্য উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানুষের অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়বদ্ধ নই।