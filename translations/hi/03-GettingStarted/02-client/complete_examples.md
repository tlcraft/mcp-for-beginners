<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:32:28+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "hi"
}
-->
# Complete MCP Client Examples

यह डायरेक्टरी विभिन्न प्रोग्रामिंग भाषाओं में MCP क्लाइंट्स के पूर्ण, कार्यशील उदाहरणों को समाहित करती है। प्रत्येक क्लाइंट मुख्य README.md ट्यूटोरियल में वर्णित पूरी कार्यक्षमता को प्रदर्शित करता है।

## Available Clients

### 1. Java Client (`client_example_java.java`)
- **Transport**: SSE (Server-Sent Events) HTTP के माध्यम से
- **Target Server**: `http://localhost:8080`
- **Features**: 
  - कनेक्शन स्थापित करना और पिंग भेजना
  - टूल सूचीबद्ध करना
  - कैलकुलेटर ऑपरेशन (जोड़ना, घटाना, गुणा, भाग, मदद)
  - त्रुटि प्रबंधन और परिणाम निकालना

**To run:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# Client (`client_example_csharp.cs`)
- **Transport**: Stdio (Standard Input/Output)
- **Target Server**: लोकल .NET MCP सर्वर dotnet run के माध्यम से
- **Features**:
  - stdio ट्रांसपोर्ट के जरिए स्वचालित सर्वर स्टार्टअप
  - टूल और संसाधन सूचीबद्ध करना
  - कैलकुलेटर ऑपरेशन
  - JSON परिणाम पार्सिंग
  - व्यापक त्रुटि प्रबंधन

**To run:**
```bash
dotnet run
```

### 3. TypeScript Client (`client_example_typescript.ts`)
- **Transport**: Stdio (Standard Input/Output)
- **Target Server**: लोकल Node.js MCP सर्वर
- **Features**:
  - पूर्ण MCP प्रोटोकॉल सपोर्ट
  - टूल, संसाधन, और प्रॉम्प्ट ऑपरेशन
  - कैलकुलेटर ऑपरेशन
  - संसाधन पढ़ना और प्रॉम्प्ट निष्पादन
  - मजबूत त्रुटि प्रबंधन

**To run:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python Client (`client_example_python.py`)
- **Transport**: Stdio (Standard Input/Output)  
- **Target Server**: लोकल Python MCP सर्वर
- **Features**:
  - Async/await पैटर्न का उपयोग
  - टूल और संसाधन खोज
  - कैलकुलेटर ऑपरेशन परीक्षण
  - संसाधन सामग्री पढ़ना
  - क्लास-आधारित संगठन

**To run:**
```bash
python client_example_python.py
```

## Common Features Across All Clients

प्रत्येक क्लाइंट इम्प्लीमेंटेशन में निम्नलिखित शामिल हैं:

1. **Connection Management**
   - MCP सर्वर से कनेक्शन स्थापित करना
   - कनेक्शन त्रुटियों को संभालना
   - उचित क्लीनअप और संसाधन प्रबंधन

2. **Server Discovery**
   - उपलब्ध टूल्स की सूची बनाना
   - उपलब्ध संसाधनों की सूची (जहाँ समर्थित हो)
   - उपलब्ध प्रॉम्प्ट्स की सूची (जहाँ समर्थित हो)

3. **Tool Invocation**
   - बुनियादी कैलकुलेटर ऑपरेशन (जोड़ना, घटाना, गुणा, भाग)
   - सर्वर जानकारी के लिए मदद कमांड
   - सही तर्क पास करना और परिणाम संभालना

4. **Error Handling**
   - कनेक्शन त्रुटियाँ
   - टूल निष्पादन त्रुटियाँ
   - सहज विफलता और उपयोगकर्ता प्रतिक्रिया

5. **Result Processing**
   - प्रतिक्रियाओं से टेक्स्ट सामग्री निकालना
   - पठनीयता के लिए आउटपुट फॉर्मेटिंग
   - विभिन्न प्रतिक्रिया स्वरूपों को संभालना

## Prerequisites

इन क्लाइंट्स को चलाने से पहले सुनिश्चित करें कि:

1. **संबंधित MCP सर्वर चल रहा हो** (`../01-first-server/` से)
2. **आपकी चुनी हुई भाषा के लिए आवश्यक डिपेंडेंसीज़ इंस्टॉल हों**
3. **सही नेटवर्क कनेक्टिविटी हो** (HTTP आधारित ट्रांसपोर्ट के लिए)

## Key Differences Between Implementations

| Language   | Transport | Server Startup | Async Model | Key Libraries |
|------------|-----------|----------------|-------------|---------------|
| Java       | SSE/HTTP  | External       | Sync        | WebFlux, MCP SDK |
| C#         | Stdio     | Automatic      | Async/Await | .NET MCP SDK |
| TypeScript | Stdio     | Automatic      | Async/Await | Node MCP SDK |
| Python     | Stdio     | Automatic      | AsyncIO     | Python MCP SDK |

## Next Steps

इन क्लाइंट उदाहरणों का अध्ययन करने के बाद:

1. **क्लाइंट्स में नए फीचर्स या ऑपरेशन जोड़ें**
2. **अपना खुद का सर्वर बनाएं और इन क्लाइंट्स के साथ टेस्ट करें**
3. **विभिन्न ट्रांसपोर्ट्स (SSE बनाम Stdio) के साथ प्रयोग करें**
4. **एक अधिक जटिल एप्लिकेशन बनाएं जो MCP कार्यक्षमता को एकीकृत करे**

## Troubleshooting

### Common Issues

1. **Connection refused**: सुनिश्चित करें कि MCP सर्वर अपेक्षित पोर्ट/पाथ पर चल रहा है
2. **Module not found**: अपनी भाषा के लिए आवश्यक MCP SDK इंस्टॉल करें
3. **Permission denied**: stdio ट्रांसपोर्ट के लिए फाइल अनुमतियाँ जांचें
4. **Tool not found**: सुनिश्चित करें कि सर्वर अपेक्षित टूल्स को लागू करता है

### Debug Tips

1. **अपने MCP SDK में विस्तृत लॉगिंग सक्षम करें**
2. **सर्वर लॉग्स में त्रुटि संदेश देखें**
3. **क्लाइंट और सर्वर के बीच टूल नाम और सिग्नेचर मिलान करें**
4. **पहले MCP Inspector के साथ टेस्ट करें ताकि सर्वर कार्यक्षमता सत्यापित हो सके**

## Related Documentation

- [Main Client Tutorial](./README.md)
- [MCP Server Examples](../../../../03-GettingStarted/01-first-server)
- [MCP with LLM Integration](../../../../03-GettingStarted/03-llm-client)
- [Official MCP Documentation](https://modelcontextprotocol.io/)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।