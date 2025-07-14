<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:18:16+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "hi"
}
-->
# इस सैंपल को चलाना

यहाँ बताया गया है कि क्लासिक HTTP स्ट्रीमिंग सर्वर और क्लाइंट, साथ ही MCP स्ट्रीमिंग सर्वर और क्लाइंट को Python का उपयोग करके कैसे चलाया जाए।

### अवलोकन

- आप एक MCP सर्वर सेटअप करेंगे जो आइटम प्रोसेस करते समय क्लाइंट को प्रगति सूचनाएँ स्ट्रीम करेगा।
- क्लाइंट प्रत्येक सूचना को रियल टाइम में दिखाएगा।
- यह गाइड आवश्यकताओं, सेटअप, चलाने और समस्या निवारण को कवर करता है।

### आवश्यकताएँ

- Python 3.9 या नया संस्करण
- `mcp` Python पैकेज (इसे `pip install mcp` से इंस्टॉल करें)

### इंस्टॉलेशन और सेटअप

1. रिपॉजिटरी क्लोन करें या समाधान फाइलें डाउनलोड करें।

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **एक वर्चुअल एनवायरनमेंट बनाएं और सक्रिय करें (सिफारिश की जाती है):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **जरूरी डिपेंडेंसीज़ इंस्टॉल करें:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### फाइलें

- **सर्वर:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **क्लाइंट:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### क्लासिक HTTP स्ट्रीमिंग सर्वर चलाना

1. समाधान डायरेक्टरी में जाएं:

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

2. आपको स्ट्रीम किए गए संदेश क्रमवार प्रिंट होते दिखेंगे:

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

1. समाधान डायरेक्टरी में जाएं:  
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
2. जैसे-जैसे सर्वर प्रत्येक आइटम को प्रोसेस करता है, आपको रियल टाइम में सूचनाएँ प्रिंट होती दिखेंगी:  
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

### मुख्य कार्यान्वयन चरण

1. **FastMCP का उपयोग करके MCP सर्वर बनाएं।**  
2. **एक टूल परिभाषित करें जो एक सूची को प्रोसेस करता है और `ctx.info()` या `ctx.log()` के जरिए सूचनाएँ भेजता है।**  
3. **`transport="streamable-http"` के साथ सर्वर चलाएं।**  
4. **एक क्लाइंट बनाएं जिसमें संदेश हैंडलर हो जो सूचनाओं को आते ही दिखाए।**

### कोड वॉकथ्रू

- सर्वर async फंक्शन्स और MCP संदर्भ का उपयोग करके प्रगति अपडेट भेजता है।  
- क्लाइंट async संदेश हैंडलर लागू करता है जो सूचनाएँ और अंतिम परिणाम प्रिंट करता है।

### सुझाव और समस्या निवारण

- नॉन-ब्लॉकिंग ऑपरेशंस के लिए `async/await` का उपयोग करें।  
- सर्वर और क्लाइंट दोनों में हमेशा एक्सेप्शंस को संभालें ताकि कोड मजबूत रहे।  
- रियल टाइम अपडेट देखने के लिए कई क्लाइंट्स के साथ टेस्ट करें।  
- यदि कोई त्रुटि आती है, तो अपने Python संस्करण और सभी डिपेंडेंसीज़ इंस्टॉल होने की जांच करें।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।