<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:00:29+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "bn"
}
-->
# এই নমুনাটি চালানো

ক্লাসিক HTTP স্ট্রিমিং সার্ভার এবং ক্লায়েন্ট, পাশাপাশি MCP স্ট্রিমিং সার্ভার এবং ক্লায়েন্ট Python ব্যবহার করে কীভাবে চালাতে হয় তা এখানে দেওয়া হলো।

### ওভারভিউ

- আপনি একটি MCP সার্ভার সেটআপ করবেন যা আইটেম প্রক্রিয়াকরণের সময় ক্লায়েন্টকে প্রগ্রেস নোটিফিকেশন পাঠাবে।
- ক্লায়েন্ট প্রতিটি নোটিফিকেশন রিয়েল টাইমে প্রদর্শন করবে।
- এই গাইডে প্রয়োজনীয়তা, সেটআপ, চালানো এবং সমস্যার সমাধান কভার করা হয়েছে।

### প্রয়োজনীয়তা

- Python 3.9 বা এর নতুন ভার্সন
- `mcp` Python প্যাকেজ (ইনস্টল করতে `pip install mcp` ব্যবহার করুন)

### ইনস্টলেশন ও সেটআপ

1. রিপোজিটরি ক্লোন করুন অথবা সলিউশন ফাইল ডাউনলোড করুন।

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **একটি ভার্চুয়াল এনভায়রনমেন্ট তৈরি ও সক্রিয় করুন (প্রস্তাবিত):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **প্রয়োজনীয় ডিপেন্ডেন্সি ইনস্টল করুন:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### ফাইলসমূহ

- **সার্ভার:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **ক্লায়েন্ট:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### ক্লাসিক HTTP স্ট্রিমিং সার্ভার চালানো

1. সলিউশন ডিরেক্টরিতে যান:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. ক্লাসিক HTTP স্ট্রিমিং সার্ভার শুরু করুন:

   ```pwsh
   python server.py
   ```

3. সার্ভার চালু হয়ে নিচের মতো প্রদর্শিত হবে:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### ক্লাসিক HTTP স্ট্রিমিং ক্লায়েন্ট চালানো

1. একটি নতুন টার্মিনাল খুলুন (একই ভার্চুয়াল এনভায়রনমেন্ট এবং ডিরেক্টরি সক্রিয় করুন):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. আপনি ধারাবাহিকভাবে স্ট্রিম হওয়া মেসেজগুলি দেখতে পাবেন:

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### MCP স্ট্রিমিং সার্ভার চালানো

1. সলিউশন ডিরেক্টরিতে যান:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. streamable-http ট্রান্সপোর্ট ব্যবহার করে MCP সার্ভার শুরু করুন:
   ```pwsh
   python server.py mcp
   ```
3. সার্ভার চালু হয়ে নিচের মতো প্রদর্শিত হবে:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### MCP স্ট্রিমিং ক্লায়েন্ট চালানো

1. একটি নতুন টার্মিনাল খুলুন (একই ভার্চুয়াল এনভায়রনমেন্ট এবং ডিরেক্টরি সক্রিয় করুন):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. সার্ভার প্রতিটি আইটেম প্রক্রিয়াকরণের সময় রিয়েল টাইমে নোটিফিকেশন দেখতে পাবেন:
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### মূল ইমপ্লিমেন্টেশন ধাপসমূহ

1. **FastMCP ব্যবহার করে MCP সার্ভার তৈরি করুন।**
2. **একটি টুল সংজ্ঞায়িত করুন যা একটি তালিকা প্রক্রিয়াকরণ করে এবং `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` ব্যবহার করে নোটিফিকেশন পাঠায়, যা নন-ব্লকিং অপারেশন নিশ্চিত করে।**
- সার্ভার এবং ক্লায়েন্ট উভয়েই এক্সসেপশন হ্যান্ডল করা উচিত যাতে robustness থাকে।
- একাধিক ক্লায়েন্ট নিয়ে পরীক্ষা করুন যাতে রিয়েল টাইম আপডেট দেখা যায়।
- কোনো ত্রুটি হলে, আপনার Python ভার্সন এবং সমস্ত ডিপেন্ডেন্সি ইনস্টল হয়েছে কিনা তা পরীক্ষা করুন।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে দয়া করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজ ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।