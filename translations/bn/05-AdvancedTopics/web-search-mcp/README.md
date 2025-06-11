<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T15:13:16+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "bn"
}
-->
# পাঠ: একটি ওয়েব সার্চ MCP সার্ভার তৈরি করা

এই অধ্যায়ে দেখানো হয়েছে কিভাবে একটি বাস্তবজীবনের AI এজেন্ট তৈরি করা যায় যা বহিরাগত API-এর সাথে সংযুক্ত, বিভিন্ন ধরনের ডেটা পরিচালনা করে, ত্রুটি নিয়ন্ত্রণ করে এবং একাধিক টুল একসাথে সমন্বয় করে—সবই প্রোডাকশন-রেডি ফরম্যাটে। আপনি দেখতে পাবেন:

- **প্রমাণীকরণ প্রয়োজন এমন বহিরাগত API-এর সাথে ইন্টিগ্রেশন**
- **বিভিন্ন ধরনের ডেটা হ্যান্ডলিং বিভিন্ন এন্ডপয়েন্ট থেকে**
- **দৃঢ় ত্রুটি নিয়ন্ত্রণ এবং লগিং কৌশল**
- **একটি সার্ভারে একাধিক টুলের সমন্বয়**

শেষে, আপনি এমন প্যাটার্ন এবং সেরা অনুশীলনের ব্যবহারিক অভিজ্ঞতা পাবেন যা উন্নত AI এবং LLM-চালিত অ্যাপ্লিকেশনের জন্য অপরিহার্য।

## পরিচিতি

এই পাঠে, আপনি শিখবেন কিভাবে একটি উন্নত MCP সার্ভার এবং ক্লায়েন্ট তৈরি করতে হয় যা SerpAPI ব্যবহার করে রিয়েল-টাইম ওয়েব ডেটার মাধ্যমে LLM ক্ষমতাগুলো বাড়ায়। এটি একটি গুরুত্বপূর্ণ দক্ষতা যা গতিশীল AI এজেন্ট তৈরি করার জন্য প্রয়োজন, যা ওয়েব থেকে সর্বশেষ তথ্য অ্যাক্সেস করতে পারে।

## শেখার লক্ষ্যসমূহ

এই পাঠের শেষে, আপনি সক্ষম হবেন:

- MCP সার্ভারে নিরাপদভাবে বহিরাগত API (যেমন SerpAPI) ইন্টিগ্রেট করা
- ওয়েব, সংবাদ, পণ্য অনুসন্ধান এবং প্রশ্নোত্তরের জন্য একাধিক টুল বাস্তবায়ন করা
- LLM ব্যবহারের জন্য গঠনমূলক ডেটা পার্স এবং ফরম্যাট করা
- ত্রুটি পরিচালনা এবং API রেট লিমিট দক্ষতার সাথে নিয়ন্ত্রণ করা
- স্বয়ংক্রিয় এবং ইন্টারেক্টিভ MCP ক্লায়েন্ট উভয়ই তৈরি এবং পরীক্ষা করা

## ওয়েব সার্চ MCP সার্ভার

এই অংশে Web Search MCP সার্ভারের আর্কিটেকচার এবং বৈশিষ্ট্যগুলি উপস্থাপন করা হয়েছে। আপনি দেখতে পাবেন কিভাবে FastMCP এবং SerpAPI একসাথে ব্যবহার করে LLM ক্ষমতাগুলো রিয়েল-টাইম ওয়েব ডেটার মাধ্যমে বাড়ানো হয়।

### ওভারভিউ

এই বাস্তবায়নে চারটি টুল রয়েছে যা MCP-এর ক্ষমতা প্রদর্শন করে বিভিন্ন, বহিরাগত API-চালিত কাজ নিরাপদ এবং দক্ষভাবে পরিচালনা করার:

- **general_search**: বিস্তৃত ওয়েব ফলাফলের জন্য
- **news_search**: সাম্প্রতিক শিরোনামের জন্য
- **product_search**: ই-কমার্স ডেটার জন্য
- **qna**: প্রশ্নোত্তর অংশের জন্য

### বৈশিষ্ট্যসমূহ
- **কোড উদাহরণ**: ভাষা-নির্দিষ্ট কোড ব্লক অন্তর্ভুক্ত যা Python-এর জন্য (এবং সহজেই অন্যান্য ভাষায় সম্প্রসারণযোগ্য) স্পষ্টতার জন্য কল্যাপ্সযোগ্য সেকশনে রাখা হয়েছে

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

ক্লায়েন্ট চালানোর আগে সার্ভার কী করে তা বোঝা দরকার। [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) ফাইলটি দেখুন।

এখানে একটি সংক্ষিপ্ত উদাহরণ দেওয়া হলো কিভাবে সার্ভার একটি টুল সংজ্ঞায়িত এবং নিবন্ধন করে:

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

- **বহিরাগত API ইন্টিগ্রেশন**: API কী এবং বহিরাগত রিকোয়েস্ট নিরাপদে পরিচালনার উদাহরণ
- **গঠনমূলক ডেটা পার্সিং**: API রেসপন্সকে LLM-সঙ্গত ফরম্যাটে রূপান্তর করার পদ্ধতি
- **ত্রুটি নিয়ন্ত্রণ**: যথাযথ লগিং সহ দৃঢ় ত্রুটি নিয়ন্ত্রণ
- **ইন্টারেক্টিভ ক্লায়েন্ট**: স্বয়ংক্রিয় পরীক্ষা এবং ইন্টারেক্টিভ মোড উভয়ই অন্তর্ভুক্ত
- **কনটেক্সট ম্যানেজমেন্ট**: MCP Context ব্যবহার করে লগিং এবং রিকোয়েস্ট ট্র্যাকিং

## পূর্বশর্ত

শুরু করার আগে নিশ্চিত করুন আপনার পরিবেশ সঠিকভাবে সেটআপ করা হয়েছে নিচের ধাপগুলো অনুসরণ করে। এটি নিশ্চিত করবে সব নির্ভরশীলতা ইনস্টল হয়েছে এবং আপনার API কী সঠিকভাবে কনফিগার করা হয়েছে যাতে উন্নয়ন এবং পরীক্ষণ নির্বিঘ্ন হয়।

- Python 3.8 বা তার উপরে
- SerpAPI API কী (সাইন আপ করুন [SerpAPI](https://serpapi.com/) - ফ্রি টিয়ার উপলব্ধ)

## ইনস্টলেশন

শুরু করার জন্য, আপনার পরিবেশ সেটআপ করতে নিচের ধাপগুলো অনুসরণ করুন:

1. uv (সুপারিশকৃত) বা pip ব্যবহার করে নির্ভরশীলতা ইনস্টল করুন:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. প্রজেক্ট রুটে `.env` ফাইল তৈরি করুন এবং আপনার SerpAPI কী দিন:

```
SERPAPI_KEY=your_serpapi_key_here
```

## ব্যবহার

Web Search MCP সার্ভার হল মূল উপাদান যা SerpAPI-এর মাধ্যমে ওয়েব, সংবাদ, পণ্য অনুসন্ধান এবং প্রশ্নোত্তরের টুলগুলো এক্সপোজ করে। এটি ইনকামিং রিকোয়েস্টগুলো পরিচালনা করে, API কল ম্যানেজ করে, রেসপন্স পার্স করে এবং ক্লায়েন্টকে গঠনমূলক ফলাফল ফেরত দেয়।

সম্পূর্ণ বাস্তবায়ন আপনি দেখতে পারেন [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) এ।

### সার্ভার চালানো

MCP সার্ভার চালু করতে নিচের কমান্ড ব্যবহার করুন:

```bash
python server.py
```

সার্ভার stdio-ভিত্তিক MCP সার্ভার হিসেবে চলবে যা ক্লায়েন্ট সরাসরি সংযোগ করতে পারবে।

### ক্লায়েন্ট মোড

ক্লায়েন্ট (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)।

### ক্লায়েন্ট চালানো

স্বয়ংক্রিয় পরীক্ষা চালাতে (এটি স্বয়ংক্রিয়ভাবে সার্ভারও চালু করবে):

```bash
python client.py
```

অথবা ইন্টারেক্টিভ মোডে চালাতে:

```bash
python client.py --interactive
```

### বিভিন্ন পদ্ধতিতে পরীক্ষা

সার্ভার প্রদত্ত টুলগুলো পরীক্ষা এবং ইন্টারঅ্যাক্ট করার জন্য বিভিন্ন পদ্ধতি আছে, যা আপনার প্রয়োজন এবং কাজের ধারা অনুযায়ী।

#### MCP Python SDK দিয়ে কাস্টম টেস্ট স্ক্রিপ্ট লেখা
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

এই প্রসঙ্গে, "টেস্ট স্ক্রিপ্ট" মানে একটি কাস্টম Python প্রোগ্রাম যা আপনি MCP সার্ভারের ক্লায়েন্ট হিসেবে লেখেন। এটি একটি ফরমাল ইউনিট টেস্ট না হলেও, এই স্ক্রিপ্ট দিয়ে আপনি প্রোগ্রাম্যাটিক্যালি সার্ভারের সাথে সংযোগ করতে পারেন, যেকোন টুল প্যারামিটার সহ কল করতে পারেন, এবং ফলাফল পর্যালোচনা করতে পারেন। এই পদ্ধতি উপযোগী:

- টুল কল প্রোটোটাইপিং এবং পরীক্ষার জন্য
- সার্ভারের বিভিন্ন ইনপুটে প্রতিক্রিয়া যাচাই করার জন্য
- পুনরাবৃত্ত টুল কল অটোমেশন করার জন্য
- MCP সার্ভারের উপরে নিজস্ব ওয়ার্কফ্লো বা ইন্টিগ্রেশন তৈরির জন্য

নিচে MCP Python SDK ব্যবহার করে এমন একটি স্ক্রিপ্ট তৈরির উদাহরণ দেওয়া হলো:

## টুল বর্ণনা

সার্ভার প্রদত্ত নিম্নলিখিত টুলগুলো ব্যবহার করে বিভিন্ন ধরনের অনুসন্ধান এবং প্রশ্ন করা যায়। প্রতিটি টুলের প্যারামিটার এবং উদাহরণ নিচে দেওয়া হয়েছে।

এই অংশে প্রতিটি উপলব্ধ টুল এবং তাদের প্যারামিটার সম্পর্কে বিস্তারিত দেওয়া হয়েছে।

### general_search

সাধারণ ওয়েব অনুসন্ধান করে এবং ফরম্যাটকৃত ফলাফল দেয়।

**কিভাবে এই টুল কল করবেন:**

আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে `general_search` কল করতে পারেন, অথবা Inspector বা ইন্টারেক্টিভ ক্লায়েন্ট মোড ব্যবহার করে ইন্টারেক্টিভলি কল করতে পারেন। SDK ব্যবহার করে কোড উদাহরণ:

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

অথবা ইন্টারেক্টিভ মোডে, নির্বাচন করুন `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): অনুসন্ধান প্রশ্ন

**উদাহরণ রিকোয়েস্ট:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

একটি প্রশ্নের সাথে সম্পর্কিত সাম্প্রতিক সংবাদ আর্টিকেল অনুসন্ধান করে।

**কিভাবে এই টুল কল করবেন:**

আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে `news_search` কল করতে পারেন, অথবা Inspector বা ইন্টারেক্টিভ ক্লায়েন্ট মোড ব্যবহার করে ইন্টারেক্টিভলি কল করতে পারেন। SDK ব্যবহার করে কোড উদাহরণ:

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

অথবা ইন্টারেক্টিভ মোডে, নির্বাচন করুন `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): অনুসন্ধান প্রশ্ন

**উদাহরণ রিকোয়েস্ট:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

একটি প্রশ্নের সাথে মিলে এমন পণ্য অনুসন্ধান করে।

**কিভাবে এই টুল কল করবেন:**

আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে `product_search` কল করতে পারেন, অথবা Inspector বা ইন্টারেক্টিভ ক্লায়েন্ট মোড ব্যবহার করে ইন্টারেক্টিভলি কল করতে পারেন। SDK ব্যবহার করে কোড উদাহরণ:

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

অথবা ইন্টারেক্টিভ মোডে, নির্বাচন করুন `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): পণ্য অনুসন্ধান প্রশ্ন

**উদাহরণ রিকোয়েস্ট:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

অনুসন্ধান ইঞ্জিন থেকে সরাসরি প্রশ্নের উত্তর পায়।

**কিভাবে এই টুল কল করবেন:**

আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে `qna` কল করতে পারেন, অথবা Inspector বা ইন্টারেক্টিভ ক্লায়েন্ট মোড ব্যবহার করে ইন্টারেক্টিভলি কল করতে পারেন। SDK ব্যবহার করে কোড উদাহরণ:

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

অথবা ইন্টারেক্টিভ মোডে, নির্বাচন করুন `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): উত্তর খোঁজার প্রশ্ন

**উদাহরণ রিকোয়েস্ট:**

```json
{
  "question": "what is artificial intelligence"
}
```

## কোড বিস্তারিত

এই অংশে সার্ভার এবং ক্লায়েন্ট বাস্তবায়নের জন্য কোড স্নিপেট এবং রেফারেন্স দেওয়া হয়েছে।

<details>
<summary>Python</summary>

সম্পূর্ণ বাস্তবায়নের জন্য দেখুন [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)।

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## এই পাঠের উন্নত ধারণাসমূহ

তৈরি শুরু করার আগে, এখানে কিছু গুরুত্বপূর্ণ উন্নত ধারণা আছে যা এই অধ্যায় জুড়ে আসবে। এগুলো বোঝা আপনাকে সাহায্য করবে ধারাবাহিকভাবে বুঝতে, যদিও আপনি নতুন হন:

- **মাল্টি-টুল সমন্বয়**: এর মানে একাধিক ভিন্ন টুল (যেমন ওয়েব সার্চ, সংবাদ সার্চ, পণ্য সার্চ, এবং প্রশ্নোত্তর) একক MCP সার্ভারে চালানো। এটি সার্ভারকে বিভিন্ন কাজ পরিচালনা করতে সক্ষম করে, শুধু একটি নয়।
- **API রেট লিমিট নিয়ন্ত্রণ**: অনেক বহিরাগত API (যেমন SerpAPI) নির্দিষ্ট সময়ে কত রিকোয়েস্ট করতে পারবেন তা সীমাবদ্ধ করে। ভালো কোড এই সীমাগুলো চেক করে এবং সেগুলো সঠিকভাবে পরিচালনা করে, যাতে আপনার অ্যাপ ভেঙে না যায়।
- **গঠনমূলক ডেটা পার্সিং**: API রেসপন্স প্রায়ই জটিল এবং নেস্টেড হয়। এই ধারণা হল সেই রেসপন্সগুলোকে পরিষ্কার, সহজে ব্যবহারযোগ্য ফরম্যাটে রূপান্তর করা যা LLM বা অন্যান্য প্রোগ্রামের জন্য সুবিধাজনক।
- **ত্রুটি পুনরুদ্ধার**: কখনও কখনও সমস্যা হয়—হয়তো নেটওয়ার্ক ব্যর্থ হয়, অথবা API প্রত্যাশিত তথ্য দেয় না। ত্রুটি পুনরুদ্ধার মানে আপনার কোড এই সমস্যাগুলো সামলাতে পারে এবং কার্যকর ফিডব্যাক দিতে পারে, ক্র্যাশ না করে।
- **প্যারামিটার যাচাই**: এটি মানে আপনার টুলগুলোর সব ইনপুট সঠিক এবং নিরাপদ কিনা যাচাই করা। এতে ডিফল্ট মান সেট করা এবং টাইপ সঠিক আছে কিনা নিশ্চিত করা অন্তর্ভুক্ত, যা বাগ এবং বিভ্রান্তি রোধ করে।

## সমস্যা সমাধান

এই অংশটি আপনাকে Web Search MCP সার্ভার নিয়ে কাজ করার সময় সাধারণ সমস্যাগুলো সনাক্ত এবং সমাধান করতে সাহায্য করবে। যদি আপনি ত্রুটি বা অপ্রত্যাশিত আচরণ দেখতে পান, এই Troubleshooting অংশটি দেখুন—এখানে সবচেয়ে সাধারণ সমস্যা এবং তাদের সমাধান দেওয়া আছে যা প্রায়ই দ্রুত সমস্যার সমাধান করে।

### সাধারণ সমস্যা

নিচে ব্যবহারকারীরা সবচেয়ে বেশি যে সমস্যাগুলো মুখোমুখি হয় তার কিছু তালিকা এবং পরিষ্কার ব্যাখ্যা ও সমাধানের ধাপ দেওয়া হলো:

1. **.env ফাইলে SERPAPI_KEY অনুপস্থিত**
   - যদি আপনি এই ত্রুটিটি পান: `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `` তাহলে `.env` ফাইল তৈরি করুন এবং আপনার কী সঠিকভাবে দিন। আপনার কী সঠিক হলেও যদি ত্রুটি হয়, তাহলে চেক করুন আপনার ফ্রি টিয়ারের কোটা শেষ হয়ে যায়নি।

### ডিবাগ মোড

ডিফল্টভাবে, অ্যাপ শুধুমাত্র গুরুত্বপূর্ণ তথ্য লগ করে। যদি আপনি আরও বিস্তারিত দেখতে চান (যেমন জটিল সমস্যা নির্ণয়ের জন্য), তাহলে DEBUG মোড চালু করতে পারেন। এতে অ্যাপ প্রতিটি ধাপের আরও বিস্তারিত তথ্য দেখাবে।

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

দ্রষ্টব্য, DEBUG মোডে HTTP রিকোয়েস্ট, রেসপন্স এবং অন্যান্য অভ্যন্তরীণ বিস্তারিত তথ্য অন্তর্ভুক্ত থাকে যা সমস্যা সমাধানে খুব সাহায্য করে।

DEBUG মোড চালু করতে, আপনার `client.py` or `server.py` ফাইলের শীর্ষে লগিং লেভেল DEBUG-এ সেট করুন:

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

## পরবর্তী কী আছে

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার জন্য চেষ্টা করি, তবে দয়া করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ভুল বা অশুদ্ধি থাকতে পারে। মূল নথিটি তার স্বাভাবিক ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদের পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারের ফলে কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।