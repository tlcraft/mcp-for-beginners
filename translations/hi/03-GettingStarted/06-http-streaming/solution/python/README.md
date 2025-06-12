<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-12T22:22:22+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "hi"
}
-->
# इस नमूने को चलाना

यहाँ बताया गया है कि क्लासिक HTTP स्ट्रीमिंग सर्वर और क्लाइंट, साथ ही MCP स्ट्रीमिंग सर्वर और क्लाइंट को Python का उपयोग करके कैसे चलाया जाए।

### अवलोकन

- आप एक MCP सर्वर सेटअप करेंगे जो आइटम प्रोसेस करते समय क्लाइंट को प्रगति सूचनाएँ स्ट्रीम करता है।
- क्लाइंट प्रत्येक सूचना को वास्तविक समय में दिखाएगा।
- यह गाइड आवश्यकताएँ, सेटअप, चलाने और समस्या निवारण को कवर करता है।

### आवश्यकताएँ

- Python 3.9 या नया संस्करण
- `mcp` Python पैकेज (इंस्टॉल करने के लिए `pip install mcp` का उपयोग करें)

### इंस्टॉलेशन और सेटअप

1. रिपॉजिटरी क्लोन करें या समाधान फाइलें डाउनलोड करें।

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **एक वर्चुअल एनवायरनमेंट बनाएं और सक्रिय करें (अनुशंसित):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **जरूरी डिपेंडेंसीज इंस्टॉल करें:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### फाइलें

- **सर्वर:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **क्लाइंट:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### क्लासिक HTTP स्ट्रीमिंग सर्वर चलाना

1. समाधान डायरेक्टरी में जाएँ:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. क्लासिक HTTP स्ट्रीमिंग सर्वर शुरू करें:

   ```pwsh
   python server.py
   ```

3. सर्वर शुरू होगा और यह दिखाएगा:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### क्लासिक HTTP स्ट्रीमिंग क्लाइंट चलाना

1. एक नया टर्मिनल खोलें (उसी वर्चुअल एनवायरनमेंट और डायरेक्टरी को सक्रिय करें):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. आपको स्ट्रीम किए गए संदेश क्रमवार प्रिंट होते दिखाई देंगे:

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

### MCP स्ट्रीमिंग सर्वर चलाना

1. समाधान डायरेक्टरी में जाएँ:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. streamable-http ट्रांसपोर्ट के साथ MCP सर्वर शुरू करें:
   ```pwsh
   python server.py mcp
   ```
3. सर्वर शुरू होगा और यह दिखाएगा:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### MCP स्ट्रीमिंग क्लाइंट चलाना

1. एक नया टर्मिनल खोलें (उसी वर्चुअल एनवायरनमेंट और डायरेक्टरी को सक्रिय करें):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. जैसे ही सर्वर प्रत्येक आइटम को प्रोसेस करता है, आपको सूचनाएँ वास्तविक समय में प्रिंट होती दिखेंगी:
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

### मुख्य कार्यान्वयन कदम

1. **FastMCP का उपयोग करके MCP सर्वर बनाएं।**
2. **एक टूल परिभाषित करें जो एक सूची को प्रोसेस करता है और `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` का उपयोग करके सूचनाएँ भेजता है ताकि ऑपरेशन्स नॉन-ब्लॉकिंग हों।**
- सर्वर और क्लाइंट दोनों में हमेशा एक्सेप्शन्स को हैंडल करें ताकि सिस्टम मजबूत रहे।
- वास्तविक समय अपडेट देखने के लिए कई क्लाइंट के साथ टेस्ट करें।
- यदि आपको त्रुटियाँ मिलें, तो अपने Python संस्करण की जांच करें और सुनिश्चित करें कि सभी डिपेंडेंसीज इंस्टॉल हैं।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या असंगतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।