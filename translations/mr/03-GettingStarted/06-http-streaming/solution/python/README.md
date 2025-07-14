<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:18:36+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "mr"
}
-->
# हा नमुना चालविणे

क्लासिक HTTP स्ट्रीमिंग सर्व्हर आणि क्लायंट तसेच MCP स्ट्रीमिंग सर्व्हर आणि क्लायंट Python वापरून कसे चालवायचे ते येथे दिले आहे.

### आढावा

- तुम्ही एक MCP सर्व्हर सेटअप कराल जो आयटम प्रक्रिया करताना क्लायंटला प्रगती सूचना पाठवेल.
- क्लायंट प्रत्येक सूचनाही रिअल टाइममध्ये दाखवेल.
- हा मार्गदर्शक पूर्वअट, सेटअप, चालविणे आणि समस्या निवारण यांचा समावेश करतो.

### पूर्वअटी

- Python 3.9 किंवा त्याहून नवीन आवृत्ती
- `mcp` Python पॅकेज (इंस्टॉल करण्यासाठी `pip install mcp` वापरा)

### इंस्टॉलेशन आणि सेटअप

1. रेपॉजिटरी क्लोन करा किंवा सोल्यूशन फाइल्स डाउनलोड करा.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **व्हर्च्युअल एन्व्हायर्नमेंट तयार करा आणि सक्रिय करा (शिफारस केलेले):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **आवश्यक अवलंबित्वे इंस्टॉल करा:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### फाइल्स

- **सर्व्हर:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **क्लायंट:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### क्लासिक HTTP स्ट्रीमिंग सर्व्हर चालविणे

1. सोल्यूशन डायरेक्टरीमध्ये जा:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. क्लासिक HTTP स्ट्रीमिंग सर्व्हर सुरू करा:

   ```pwsh
   python server.py
   ```

3. सर्व्हर सुरू होईल आणि खालीलप्रमाणे दिसेल:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### क्लासिक HTTP स्ट्रीमिंग क्लायंट चालविणे

1. नवीन टर्मिनल उघडा (त्याच व्हर्च्युअल एन्व्हायर्नमेंट आणि डायरेक्टरीमध्ये सक्रिय करा):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. तुम्हाला स्ट्रीम केलेले संदेश क्रमाने प्रिंट होताना दिसतील:

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

### MCP स्ट्रीमिंग सर्व्हर चालविणे

1. सोल्यूशन डायरेक्टरीमध्ये जा:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. streamable-http ट्रान्सपोर्टसह MCP सर्व्हर सुरू करा:
   ```pwsh
   python server.py mcp
   ```
3. सर्व्हर सुरू होईल आणि खालीलप्रमाणे दिसेल:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### MCP स्ट्रीमिंग क्लायंट चालविणे

1. नवीन टर्मिनल उघडा (त्याच व्हर्च्युअल एन्व्हायर्नमेंट आणि डायरेक्टरीमध्ये सक्रिय करा):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. सर्व्हर प्रत्येक आयटम प्रक्रिया करताना तुम्हाला रिअल टाइममध्ये सूचना दिसतील:
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

### मुख्य अंमलबजावणी पावले

1. **FastMCP वापरून MCP सर्व्हर तयार करा.**
2. **एक टूल डिफाइन करा जे यादी प्रक्रिया करेल आणि `ctx.info()` किंवा `ctx.log()` वापरून सूचना पाठवेल.**
3. **`transport="streamable-http"` सह सर्व्हर चालवा.**
4. **क्लायंटमध्ये मेसेज हँडलर अंमलात आणा जे सूचना येताच दाखवेल.**

### कोड वॉकथ्रू
- सर्व्हर async फंक्शन्स आणि MCP संदर्भ वापरून प्रगती अपडेट्स पाठवतो.
- क्लायंट async मेसेज हँडलर वापरून सूचना आणि अंतिम निकाल प्रिंट करतो.

### टिप्स आणि समस्या निवारण

- नॉन-ब्लॉकिंग ऑपरेशन्ससाठी `async/await` वापरा.
- सर्व्हर आणि क्लायंट दोन्हीमध्ये अपवाद हाताळणी नेहमी करा जेणेकरून प्रणाली मजबूत राहील.
- रिअल टाइम अपडेट्स पाहण्यासाठी एकापेक्षा जास्त क्लायंटसह चाचणी करा.
- त्रुटी आल्यास तुमची Python आवृत्ती तपासा आणि सर्व अवलंबित्वे योग्यरित्या इंस्टॉल आहेत का ते पाहा.

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.