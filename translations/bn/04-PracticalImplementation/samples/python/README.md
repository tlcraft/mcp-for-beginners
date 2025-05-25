<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:29:06+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "bn"
}
-->
# Model Context Protocol (MCP) Python Implementation

এই রিপোজিটরিতে Model Context Protocol (MCP)-এর একটি পাইথন ইমপ্লিমেন্টেশন রয়েছে, যা দেখায় কীভাবে MCP স্ট্যান্ডার্ড ব্যবহার করে সার্ভার এবং ক্লায়েন্ট অ্যাপ্লিকেশন তৈরি করা যায়।

## ওভারভিউ

MCP ইমপ্লিমেন্টেশনটি দুটি প্রধান উপাদান নিয়ে গঠিত:

1. **MCP Server (`server.py`)** - একটি সার্ভার যা প্রদান করে:
   - **Tools**: ফাংশন যা দূর থেকে কল করা যায়
   - **Resources**: ডেটা যা রিট্রিভ করা যায়
   - **Prompts**: ভাষা মডেলের জন্য প্রম্পট তৈরির টেমপ্লেট

2. **MCP Client (`client.py`)** - একটি ক্লায়েন্ট অ্যাপ্লিকেশন যা সার্ভারের সাথে সংযোগ করে এবং তার ফিচারগুলো ব্যবহার করে

## ফিচারসমূহ

এই ইমপ্লিমেন্টেশনটি MCP-এর কয়েকটি গুরুত্বপূর্ণ ফিচার প্রদর্শন করে:

### Tools
- `completion` - AI মডেল থেকে টেক্সট কমপ্লিশন তৈরি করে (সিমুলেটেড)
- `add` - সহজ ক্যালকুলেটর যা দুটি সংখ্যা যোগ করে

### Resources
- `models://` - উপলব্ধ AI মডেলগুলোর তথ্য প্রদান করে
- `greeting://{name}` - নির্দিষ্ট নামের জন্য ব্যক্তিগতকৃত অভিবাদন প্রদান করে

### Prompts
- `review_code` - কোড রিভিউ করার জন্য প্রম্পট তৈরি করে

## ইনস্টলেশন

এই MCP ইমপ্লিমেন্টেশন ব্যবহার করতে, প্রয়োজনীয় প্যাকেজগুলো ইনস্টল করুন:

```powershell
pip install mcp-server mcp-client
```

## সার্ভার এবং ক্লায়েন্ট চালানো

### সার্ভার শুরু করা

একটি টার্মিনাল উইন্ডোতে সার্ভার চালান:

```powershell
python server.py
```

সার্ভার ডেভেলপমেন্ট মোডেও চালানো যেতে পারে MCP CLI ব্যবহার করে:

```powershell
mcp dev server.py
```

অথবা Claude Desktop-এ ইনস্টল করে (যদি উপলব্ধ থাকে):

```powershell
mcp install server.py
```

### ক্লায়েন্ট চালানো

অন্য একটি টার্মিনাল উইন্ডোতে ক্লায়েন্ট চালান:

```powershell
python client.py
```

এটি সার্ভারের সাথে সংযোগ করবে এবং সব উপলব্ধ ফিচার প্রদর্শন করবে।

### ক্লায়েন্ট ব্যবহার

ক্লায়েন্ট (`client.py`) MCP-এর সব ক্ষমতা প্রদর্শন করে:

```powershell
python client.py
```

এটি সার্ভারের সাথে সংযোগ স্থাপন করে এবং টুলস, রিসোর্সেস, প্রম্পটসহ সব ফিচার ব্যবহার করবে। আউটপুট দেখাবে:

1. ক্যালকুলেটর টুলের ফলাফল (5 + 7 = 12)
2. "What is the meaning of life?" প্রশ্নের জন্য কমপ্লিশন টুলের উত্তর
3. উপলব্ধ AI মডেলগুলোর তালিকা
4. "MCP Explorer" এর জন্য ব্যক্তিগতকৃত অভিবাদন
5. কোড রিভিউ প্রম্পট টেমপ্লেট

## ইমপ্লিমেন্টেশন বিস্তারিত

সার্ভারটি `FastMCP` API ব্যবহার করে ইমপ্লিমেন্ট করা হয়েছে, যা MCP সার্ভিস ডিফাইন করার জন্য উচ্চ-স্তরের বিমূর্ততা প্রদান করে। এখানে একটি সরল উদাহরণ দেখানো হয়েছে কীভাবে টুলস ডিফাইন করা হয়:

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

ক্লায়েন্ট MCP ক্লায়েন্ট লাইব্রেরি ব্যবহার করে সার্ভারের সাথে সংযোগ স্থাপন করে এবং কল করে:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## আরও জানুন

MCP সম্পর্কে আরও তথ্যের জন্য দেখুন: https://modelcontextprotocol.io/

**অস্বীকারোক্তি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতা বজায় রাখার চেষ্টা করি, তবে দয়া করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃপক্ষ সূত্র হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করা উচিৎ। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়বদ্ধ নই।