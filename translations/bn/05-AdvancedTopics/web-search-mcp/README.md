<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-07-14T03:30:18+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "bn"
}
-->
# পাঠ: একটি ওয়েব সার্চ MCP সার্ভার তৈরি করা

এই অধ্যায়ে দেখানো হয়েছে কিভাবে একটি বাস্তব জীবনের AI এজেন্ট তৈরি করা যায় যা বাহ্যিক API-এর সাথে সংযুক্ত হয়, বিভিন্ন ধরনের ডেটা পরিচালনা করে, ত্রুটি সামলায় এবং একাধিক টুল একসাথে পরিচালনা করে—সবকিছুই প্রোডাকশন-রেডি ফরম্যাটে। আপনি দেখতে পাবেন:

- **প্রমাণীকরণ প্রয়োজন এমন বাহ্যিক API-এর সাথে সংযোগ**
- **বিভিন্ন এন্ডপয়েন্ট থেকে বিভিন্ন ধরনের ডেটা পরিচালনা**
- **দৃঢ় ত্রুটি হ্যান্ডলিং এবং লগিং কৌশল**
- **একক সার্ভারে একাধিক টুলের সমন্বয়**

শেষে, আপনি এমন প্যাটার্ন এবং সেরা অনুশীলন সম্পর্কে বাস্তব অভিজ্ঞতা পাবেন যা উন্নত AI এবং LLM-চালিত অ্যাপ্লিকেশনগুলোর জন্য অপরিহার্য।

## পরিচিতি

এই পাঠে, আপনি শিখবেন কিভাবে একটি উন্নত MCP সার্ভার এবং ক্লায়েন্ট তৈরি করতে হয় যা SerpAPI ব্যবহার করে LLM ক্ষমতাগুলোকে রিয়েল-টাইম ওয়েব ডেটার সাথে সম্প্রসারিত করে। এটি এমন একটি গুরুত্বপূর্ণ দক্ষতা যা গতিশীল AI এজেন্ট তৈরি করতে সাহায্য করে, যারা ওয়েব থেকে সর্বশেষ তথ্য অ্যাক্সেস করতে পারে।

## শেখার উদ্দেশ্য

এই পাঠের শেষে, আপনি সক্ষম হবেন:

- MCP সার্ভারে নিরাপদভাবে বাহ্যিক API (যেমন SerpAPI) সংযুক্ত করতে
- ওয়েব, সংবাদ, পণ্য অনুসন্ধান এবং প্রশ্নোত্তরের জন্য একাধিক টুল বাস্তবায়ন করতে
- LLM ব্যবহারের জন্য কাঠামোবদ্ধ ডেটা পার্স এবং ফরম্যাট করতে
- ত্রুটি সামলাতে এবং API রেট লিমিট কার্যকরভাবে পরিচালনা করতে
- স্বয়ংক্রিয় এবং ইন্টারেক্টিভ MCP ক্লায়েন্ট উভয়ই তৈরি ও পরীক্ষা করতে

## ওয়েব সার্চ MCP সার্ভার

এই অংশে ওয়েব সার্চ MCP সার্ভারের আর্কিটেকচার এবং বৈশিষ্ট্যগুলি উপস্থাপন করা হয়েছে। আপনি দেখতে পাবেন কিভাবে FastMCP এবং SerpAPI একসাথে ব্যবহার করে LLM ক্ষমতাগুলোকে রিয়েল-টাইম ওয়েব ডেটার সাথে সম্প্রসারিত করা হয়।

### ওভারভিউ

এই ইমপ্লিমেন্টেশনে চারটি টুল রয়েছে যা MCP-এর বহুমুখী, বাহ্যিক API-চালিত কাজগুলো নিরাপদ ও দক্ষভাবে পরিচালনার ক্ষমতা প্রদর্শন করে:

- **general_search**: বিস্তৃত ওয়েব ফলাফলের জন্য
- **news_search**: সাম্প্রতিক শিরোনামের জন্য
- **product_search**: ই-কমার্স ডেটার জন্য
- **qna**: প্রশ্নোত্তর অংশের জন্য

### বৈশিষ্ট্যসমূহ
- **কোড উদাহরণ**: পাইটন (এবং সহজেই অন্যান্য ভাষায় সম্প্রসারণযোগ্য) এর জন্য ভাষা-নির্দিষ্ট কোড ব্লক সহ, স্পষ্টতার জন্য কল্যাপ্সযোগ্য সেকশন ব্যবহার করে

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

ক্লায়েন্ট চালানোর আগে, সার্ভার কী করে তা বোঝা উপকারী। [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) ফাইলটি MCP সার্ভার বাস্তবায়ন করে, যা SerpAPI-এর সাথে সংযুক্ত হয়ে ওয়েব, সংবাদ, পণ্য অনুসন্ধান এবং প্রশ্নোত্তরের জন্য টুলগুলো প্রকাশ করে। এটি আসা অনুরোধগুলো পরিচালনা করে, API কলগুলো নিয়ন্ত্রণ করে, প্রতিক্রিয়া পার্স করে এবং কাঠামোবদ্ধ ফলাফল ক্লায়েন্টকে ফেরত দেয়।

আপনি সম্পূর্ণ ইমপ্লিমেন্টেশনটি [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) এ দেখতে পারেন।

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

- **বাহ্যিক API সংযোগ**: API কী এবং বাহ্যিক অনুরোধ নিরাপদে পরিচালনার উদাহরণ
- **কাঠামোবদ্ধ ডেটা পার্সিং**: API প্রতিক্রিয়াগুলোকে LLM-সুবিধাজনক ফরম্যাটে রূপান্তর করার পদ্ধতি
- **ত্রুটি হ্যান্ডলিং**: যথাযথ লগিং সহ দৃঢ় ত্রুটি পরিচালনা
- **ইন্টারেক্টিভ ক্লায়েন্ট**: স্বয়ংক্রিয় পরীক্ষা এবং ইন্টারেক্টিভ মোড উভয়ই অন্তর্ভুক্ত
- **কনটেক্সট ম্যানেজমেন্ট**: MCP Context ব্যবহার করে লগিং এবং অনুরোধ ট্র্যাকিং

## পূর্বশর্ত

শুরু করার আগে, নিশ্চিত করুন আপনার পরিবেশ সঠিকভাবে সেটআপ করা হয়েছে নিচের ধাপগুলো অনুসরণ করে। এটি নিশ্চিত করবে যে সব নির্ভরতা ইনস্টল হয়েছে এবং আপনার API কী সঠিকভাবে কনফিগার করা হয়েছে যাতে উন্নয়ন ও পরীক্ষায় কোনো সমস্যা না হয়।

- Python 3.8 বা তার উপরে
- SerpAPI API কী (সাইন আপ করুন [SerpAPI](https://serpapi.com/) - ফ্রি টিয়ার উপলব্ধ)

## ইনস্টলেশন

শুরু করতে, আপনার পরিবেশ সেটআপের জন্য নিচের ধাপগুলো অনুসরণ করুন:

1. uv (সুপারিশকৃত) বা pip ব্যবহার করে নির্ভরতা ইনস্টল করুন:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. প্রকল্পের মূল ডিরেক্টরিতে `.env` ফাইল তৈরি করুন এবং আপনার SerpAPI কী যুক্ত করুন:

```
SERPAPI_KEY=your_serpapi_key_here
```

## ব্যবহার

ওয়েব সার্চ MCP সার্ভার হল মূল উপাদান যা SerpAPI-এর সাথে সংযুক্ত হয়ে ওয়েব, সংবাদ, পণ্য অনুসন্ধান এবং প্রশ্নোত্তরের জন্য টুলগুলো প্রকাশ করে। এটি আসা অনুরোধগুলো পরিচালনা করে, API কলগুলো নিয়ন্ত্রণ করে, প্রতিক্রিয়া পার্স করে এবং কাঠামোবদ্ধ ফলাফল ক্লায়েন্টকে ফেরত দেয়।

আপনি সম্পূর্ণ ইমপ্লিমেন্টেশনটি [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) এ দেখতে পারেন।

### সার্ভার চালানো

MCP সার্ভার শুরু করতে, নিচের কমান্ডটি ব্যবহার করুন:

```bash
python server.py
```

সার্ভার stdio-ভিত্তিক MCP সার্ভার হিসেবে চলবে যা ক্লায়েন্ট সরাসরি সংযুক্ত হতে পারে।

### ক্লায়েন্ট মোড

ক্লায়েন্ট (`client.py`) MCP সার্ভারের সাথে ইন্টারঅ্যাক্ট করার জন্য দুইটি মোড সমর্থন করে:

- **সাধারণ মোড**: স্বয়ংক্রিয় পরীক্ষা চালায় যা সব টুল পরীক্ষা করে এবং তাদের প্রতিক্রিয়া যাচাই করে। এটি দ্রুত পরীক্ষা করার জন্য উপযোগী যে সার্ভার এবং টুলগুলো প্রত্যাশিতভাবে কাজ করছে কিনা।
- **ইন্টারেক্টিভ মোড**: একটি মেনু-চালিত ইন্টারফেস শুরু করে যেখানে আপনি ম্যানুয়ালি টুল নির্বাচন ও কল করতে পারেন, কাস্টম প্রশ্ন দিতে পারেন এবং রিয়েল-টাইমে ফলাফল দেখতে পারেন। এটি সার্ভারের ক্ষমতা অন্বেষণ এবং বিভিন্ন ইনপুট নিয়ে পরীক্ষা করার জন্য আদর্শ।

আপনি সম্পূর্ণ ইমপ্লিমেন্টেশনটি [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) এ দেখতে পারেন।

### ক্লায়েন্ট চালানো

স্বয়ংক্রিয় পরীক্ষা চালাতে (এটি স্বয়ংক্রিয়ভাবে সার্ভারও শুরু করবে):

```bash
python client.py
```

অথবা ইন্টারেক্টিভ মোডে চালাতে:

```bash
python client.py --interactive
```

### বিভিন্ন পদ্ধতিতে পরীক্ষা

আপনার প্রয়োজন এবং কাজের ধারা অনুযায়ী সার্ভারের টুলগুলো পরীক্ষা এবং ইন্টারঅ্যাক্ট করার বিভিন্ন উপায় রয়েছে।

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

এই প্রসঙ্গে, "টেস্ট স্ক্রিপ্ট" বলতে একটি কাস্টম পাইটন প্রোগ্রাম বোঝানো হয় যা MCP সার্ভারের ক্লায়েন্ট হিসেবে কাজ করে। এটি একটি আনুষ্ঠানিক ইউনিট টেস্ট না হলেও, এই স্ক্রিপ্টটি প্রোগ্রাম্যাটিকভাবে সার্ভারের সাথে সংযোগ স্থাপন করে, পছন্দমত প্যারামিটার দিয়ে যেকোনো টুল কল করে এবং ফলাফল পরীক্ষা করতে দেয়। এই পদ্ধতি উপকারী:

- টুল কল প্রোটোটাইপ এবং পরীক্ষা করার জন্য
- সার্ভারের বিভিন্ন ইনপুটে প্রতিক্রিয়া যাচাই করার জন্য
- পুনরাবৃত্ত টুল কল স্বয়ংক্রিয় করার জন্য
- MCP সার্ভারের উপরে নিজস্ব ওয়ার্কফ্লো বা ইন্টিগ্রেশন তৈরি করার জন্য

আপনি টেস্ট স্ক্রিপ্ট ব্যবহার করে দ্রুত নতুন প্রশ্ন পরীক্ষা করতে, টুলের আচরণ ডিবাগ করতে বা উন্নত অটোমেশন শুরু করতে পারেন। নিচে MCP Python SDK ব্যবহার করে এমন একটি স্ক্রিপ্ট তৈরির উদাহরণ দেওয়া হলো:

## টুল বর্ণনা

সার্ভার দ্বারা প্রদত্ত নিম্নলিখিত টুলগুলো ব্যবহার করে বিভিন্ন ধরনের অনুসন্ধান এবং প্রশ্ন করা যায়। প্রতিটি টুলের প্যারামিটার এবং উদাহরণ ব্যবহার নিচে দেওয়া হয়েছে।

এই অংশে প্রতিটি উপলব্ধ টুল এবং তাদের প্যারামিটার সম্পর্কে বিস্তারিত তথ্য দেওয়া হয়েছে।

### general_search

সাধারণ ওয়েব অনুসন্ধান করে এবং ফরম্যাট করা ফলাফল প্রদান করে।

**কিভাবে এই টুল কল করবেন:**

আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে `general_search` কল করতে পারেন, অথবা ইন্টারেক্টিভলি Inspector বা ইন্টারেক্টিভ ক্লায়েন্ট মোড ব্যবহার করে। নিচে SDK ব্যবহার করে একটি কোড উদাহরণ দেওয়া হলো:

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

অথবা, ইন্টারেক্টিভ মোডে মেনু থেকে `general_search` নির্বাচন করুন এবং প্রম্পট পেলে আপনার অনুসন্ধান লিখুন।

**প্যারামিটার:**
- `query` (স্ট্রিং): অনুসন্ধান প্রশ্ন

**উদাহরণ অনুরোধ:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

একটি প্রশ্নের সাথে সম্পর্কিত সাম্প্রতিক সংবাদ অনুসন্ধান করে।

**কিভাবে এই টুল কল করবেন:**

আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে `news_search` কল করতে পারেন, অথবা ইন্টারেক্টিভলি Inspector বা ইন্টারেক্টিভ ক্লায়েন্ট মোড ব্যবহার করে। নিচে SDK ব্যবহার করে একটি কোড উদাহরণ দেওয়া হলো:

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

অথবা, ইন্টারেক্টিভ মোডে মেনু থেকে `news_search` নির্বাচন করুন এবং প্রম্পট পেলে আপনার অনুসন্ধান লিখুন।

**প্যারামিটার:**
- `query` (স্ট্রিং): অনুসন্ধান প্রশ্ন

**উদাহরণ অনুরোধ:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

একটি প্রশ্নের সাথে মিল থাকা পণ্য অনুসন্ধান করে।

**কিভাবে এই টুল কল করবেন:**

আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে `product_search` কল করতে পারেন, অথবা ইন্টারেক্টিভলি Inspector বা ইন্টারেক্টিভ ক্লায়েন্ট মোড ব্যবহার করে। নিচে SDK ব্যবহার করে একটি কোড উদাহরণ দেওয়া হলো:

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

অথবা, ইন্টারেক্টিভ মোডে মেনু থেকে `product_search` নির্বাচন করুন এবং প্রম্পট পেলে আপনার অনুসন্ধান লিখুন।

**প্যারামিটার:**
- `query` (স্ট্রিং): পণ্য অনুসন্ধান প্রশ্ন

**উদাহরণ অনুরোধ:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

অনুসন্ধান ইঞ্জিন থেকে সরাসরি প্রশ্নের উত্তর পায়।

**কিভাবে এই টুল কল করবেন:**

আপনি MCP Python SDK ব্যবহার করে নিজের স্ক্রিপ্ট থেকে `qna` কল করতে পারেন, অথবা ইন্টারেক্টিভলি Inspector বা ইন্টারেক্টিভ ক্লায়েন্ট মোড ব্যবহার করে। নিচে SDK ব্যবহার করে একটি কোড উদাহরণ দেওয়া হলো:

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

অথবা, ইন্টারেক্টিভ মোডে মেনু থেকে `qna` নির্বাচন করুন এবং প্রম্পট পেলে আপনার প্রশ্ন লিখুন।

**প্যারামিটার:**
- `question` (স্ট্রিং): উত্তর খোঁজার জন্য প্রশ্ন

**উদাহরণ অনুরোধ:**

```json
{
  "question": "what is artificial intelligence"
}
```

## কোড বিস্তারিত

এই অংশে সার্ভার এবং ক্লায়েন্ট ইমপ্লিমেন্টেশনের জন্য কোড স্নিপেট এবং রেফারেন্স দেওয়া হয়েছে।

<details>
<summary>Python</summary>

সম্পূর্ণ ইমপ্লিমেন্টেশন দেখতে [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) এবং [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) দেখুন।

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## এই পাঠের উন্নত ধারণা

তৈরি শুরু করার আগে, এখানে কিছু গুরুত্বপূর্ণ উন্নত ধারণা দেওয়া হলো যা এই অধ্যায় জুড়ে বারবার আসবে। এগুলো বোঝা আপনাকে সাহায্য করবে সহজে অনুসরণ করতে, এমনকি যদি আপনি নতুন হন:

- **মাল্টি-টুল সমন্বয়**: এর মানে হল একক MCP সার্ভারে একাধিক ভিন্ন টুল (যেমন ওয়েব সার্চ, সংবাদ অনুসন্ধান, পণ্য অনুসন্ধান, এবং প্রশ্নোত্তর) চালানো। এটি আপনার সার্ভারকে একাধিক কাজ পরিচালনা করার ক্ষমতা দেয়, শুধুমাত্র একটি নয়।
- **API রেট লিমিট হ্যান্ডলিং**: অনেক বাহ্যিক API (যেমন SerpAPI) নির্দিষ্ট সময়ে কত অনুরোধ করা যাবে তা সীমাবদ্ধ করে। ভালো কোড এই সীমাগুলো পরীক্ষা করে এবং সেগুলোকে সুন্দরভাবে সামলায়, যাতে আপনার অ্যাপ ভেঙে না যায়।
- **কাঠামোবদ্ধ ডেটা পার্সিং**: API প্রতিক্রিয়াগুলো প্রায়ই জটিল এবং নেস্টেড হয়। এই ধারণাটি হল সেই প্রতিক্রিয়াগুলোকে পরিষ্কার, সহজে ব্যবহারযোগ্য ফরম্যাটে রূপান্তর করা যা LLM বা অন্যান্য প্রোগ্রামের জন্য সুবিধাজনক।
- **ত্রুটি পুনরুদ্ধার**: কখনও কখনও সমস্যা হয়—হয়তো নেটওয়ার্ক ব্যর্থ হয়, অথবা API প্রত্যাশিত তথ্য দেয় না। ত্রুটি পুনরুদ্ধার মানে আপনার কোড এই সমস্যাগুলো সামলাতে পারে এবং এখনও ব্যবহারযোগ্য প্রতিক্রিয়া দিতে পারে, ক্র্যাশ না করে।
- **প্যারামিটার যাচাই**: এটি নিশ্চিত করে যে আপনার টুলগুলোর সব ইনপুট সঠিক এবং নিরাপদ। এতে ডিফল্ট মান সেট করা এবং টাইপ যাচাই অন্তর্ভুক্ত, যা বাগ এবং বিভ্রান্তি কমায়।

এই অংশটি আপনাকে ওয়েব সার্চ MCP সার্ভারের সাথে কাজ করার সময় সাধারণ সমস্যাগুলো নির্ণয় এবং সমাধান করতে সাহায্য করবে। যদি আপনি ত্রুটি বা অপ্রত্যাশিত আচরণ দেখতে পান, এই ট্রাবলশুটিং অংশটি প্রথমে দেখুন—এগুলো প্রায়ই দ্রুত সমস্যার সমাধান দেয়।

## ট্রাবলশুটিং

ওয়েব সার্চ MCP সার্ভারের সাথে কাজ করার সময় মাঝে মাঝে সমস্যা দেখা দিতে পারে—এটি স্বাভাবিক যখন বাহ্যিক API এবং নতুন টুল নিয়ে কাজ করছেন। এই অংশটি সবচেয়ে সাধারণ সমস্যাগুলোর ব্যবহারিক সমাধান দেয়, যাতে আপনি দ্রুত আবার কাজ শুরু করতে পারেন। যদি কোনো ত্রুটি পান, এখান থেকে শুরু করুন: নিচের টিপসগুলো সবচেয়ে বেশি ব্যবহারকারীর মুখোমুখি হওয়া সমস্যাগুলো সমাধান করে এবং প্রায়ই অতিরিক্ত সাহায্য ছাড়াই আপনার সমস্যা মিটিয়ে দেয়।

### সাধারণ সমস্যা

নিচে কিছু সবচেয়ে সাধারণ সমস্যা এবং সেগুলোর স্পষ্ট ব্যাখ্যা ও সমাধানের ধাপ দেওয়া হলো:

1. **.env ফাইলে SERPAPI_KEY অনুপস্থিত**
   - যদি আপনি `SERPAPI_KEY environment variable not found` ত্রুটি দেখেন, এর মানে আপনার অ্যাপ্লিকেশন SerpAPI অ্যাক্সেসের জন্য প্রয়োজনীয় API কী খুঁজে পাচ্ছে না। এটি ঠিক করতে, আপনার প্রকল্পের মূল ডিরেক্টরিতে `.env` নামক একটি ফাইল তৈরি করুন (যদি না থাকে) এবং এতে `SERPAPI_KEY=your_serpapi_key_here` লাইনটি যোগ করুন। অবশ্যই `your_serpapi_key_here` এর জায়গায় আপনার আসল SerpAPI কী দিন।

2. **মডিউল পাওয়া যায়নি ত্রুটি**
   - যেমন `ModuleNotFoundError: No module named 'httpx'` ত্রুটি নির্দেশ করে যে একটি প্রয়োজনীয় পাইথন প্যাকেজ অনুপস্থিত। সাধারণত এটি ঘটে যদি আপনি সব নির্ভরতা ইনস্টল না করে থাকেন। এটি ঠিক করতে, টার্মিনালে `pip install -r requirements.txt` চালান যাতে আপনার প্রকল্পের সব প্রয়োজনীয় প্যাকেজ ইনস্টল হয়।

3. **সংযোগ সমস্যা**
   - যদি আপনি `Error during client execution` এর মতো ত্রুটি পান, এর মানে হতে পারে ক্লায়েন্ট সার্ভারের সাথে সংযোগ করতে পারছে না, অথবা সার্ভার প্রত্যাশিতভাবে চলছে না। নিশ্চিত করুন ক্লায়েন্ট এবং সার্ভার উভয়ই সামঞ্জস্যপূর্ণ সংস্করণ এবং `server.py` সঠিক ডিরেক্টরিতে আছে এবং চলছে। সার্ভার এবং ক্লায়েন্ট দুটোই পুনরায় চালু করাও সাহায্য করতে পারে।

4. **SerpAPI ত্রুটি**
   - `Search API returned error status: 401` দেখালে এর মানে আপনার SerpAPI কী অনুপস্থিত, ভুল বা মেয়াদোত্তীর্ণ। আপনার SerpAPI ড্যাশবোর্ডে গিয়ে কী যাচাই করুন এবং প্রয়োজনে `.env` ফাইল আপডেট করুন। যদি কী সঠিক হয় কিন্তু ত্রুটি থাকে, তাহলে আপনার ফ্রি

<summary>পাইথন</summary>

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

- [5.10 রিয়েল টাইম স্ট্রিমিং](../mcp-realtimestreaming/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।