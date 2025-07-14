<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:18:47+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "ne"
}
-->
# यो नमुना चलाउने तरिका

यहाँ कसरी क्लासिक HTTP स्ट्रिमिङ सर्भर र क्लाइन्ट, साथै MCP स्ट्रिमिङ सर्भर र क्लाइन्ट Python प्रयोग गरेर चलाउने देखाइएको छ।

### अवलोकन

- तपाईंले एउटा MCP सर्भर सेटअप गर्नुहुनेछ जसले आइटमहरू प्रक्रिया गर्दा क्लाइन्टलाई प्रगति सूचनाहरू स्ट्रिम गर्नेछ।
- क्लाइन्टले प्रत्येक सूचनालाई वास्तविक समयमा देखाउनेछ।
- यो मार्गदर्शनले पूर्वआवश्यकता, सेटअप, चलाउने तरिका, र समस्या समाधान समेट्छ।

### पूर्वआवश्यकता

- Python 3.9 वा नयाँ संस्करण
- `mcp` Python प्याकेज (इन्स्टल गर्न `pip install mcp` प्रयोग गर्नुहोस्)

### इन्स्टलेशन र सेटअप

1. रिपोजिटरी क्लोन गर्नुहोस् वा समाधान फाइलहरू डाउनलोड गर्नुहोस्।

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **भर्चुअल वातावरण सिर्जना गरी सक्रिय गर्नुहोस् (सिफारिस गरिएको):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **आवश्यक निर्भरता इन्स्टल गर्नुहोस्:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### फाइलहरू

- **सर्भर:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **क्लाइन्ट:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### क्लासिक HTTP स्ट्रिमिङ सर्भर चलाउने तरिका

1. समाधान डाइरेक्टरीमा जानुहोस्:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. क्लासिक HTTP स्ट्रिमिङ सर्भर सुरु गर्नुहोस्:

   ```pwsh
   python server.py
   ```

3. सर्भर सुरु भएपछि निम्न देखिनेछ:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### क्लासिक HTTP स्ट्रिमिङ क्लाइन्ट चलाउने तरिका

1. नयाँ टर्मिनल खोल्नुहोस् (उही भर्चुअल वातावरण र डाइरेक्टरी सक्रिय गर्नुहोस्):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. स्ट्रिम गरिएको सन्देशहरू क्रमशः प्रिन्ट हुँदै जानेछन्:

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

### MCP स्ट्रिमिङ सर्भर चलाउने तरिका

1. समाधान डाइरेक्टरीमा जानुहोस्:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. streamable-http ट्रान्सपोर्टसँग MCP सर्भर सुरु गर्नुहोस्:
   ```pwsh
   python server.py mcp
   ```
3. सर्भर सुरु भएपछि निम्न देखिनेछ:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### MCP स्ट्रिमिङ क्लाइन्ट चलाउने तरिका

1. नयाँ टर्मिनल खोल्नुहोस् (उही भर्चुअल वातावरण र डाइरेक्टरी सक्रिय गर्नुहोस्):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. सर्भरले प्रत्येक आइटम प्रक्रिया गर्दा सूचनाहरू वास्तविक समयमा प्रिन्ट हुनेछन्:
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

### मुख्य कार्यान्वयन चरणहरू

1. **FastMCP प्रयोग गरी MCP सर्भर सिर्जना गर्नुहोस्।**
2. **एउटा टुल परिभाषित गर्नुहोस् जसले सूची प्रक्रिया गरी `ctx.info()` वा `ctx.log()` प्रयोग गरेर सूचनाहरू पठाउँछ।**
3. **`transport="streamable-http"` सहित सर्भर चलाउनुहोस्।**
4. **सन्देश ह्यान्डलर सहितको क्लाइन्ट कार्यान्वयन गर्नुहोस् जसले सूचनाहरू आइपुग्दा देखाउँछ।**

### कोड अवलोकन
- सर्भरले async फङ्सनहरू र MCP सन्दर्भ प्रयोग गरी प्रगति अपडेटहरू पठाउँछ।
- क्लाइन्टले async सन्देश ह्यान्डलर कार्यान्वयन गरी सूचनाहरू र अन्तिम परिणाम प्रिन्ट गर्छ।

### सुझाव र समस्या समाधान

- नन-ब्लकिङ अपरेसनका लागि `async/await` प्रयोग गर्नुहोस्।
- दुवै सर्भर र क्लाइन्टमा सधैं अपवादहरू सम्हाल्नुहोस् ताकि मजबुती रहोस्।
- वास्तविक समय अपडेटहरू हेर्न धेरै क्लाइन्टहरूसँग परीक्षण गर्नुहोस्।
- यदि त्रुटिहरू आउँछन् भने, आफ्नो Python संस्करण जाँच गर्नुहोस् र सबै निर्भरता इन्स्टल भएको सुनिश्चित गर्नुहोस्।

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।