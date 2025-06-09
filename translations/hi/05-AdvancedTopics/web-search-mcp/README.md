<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T18:38:31+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "hi"
}
-->
# Lesson: Building a Web Search MCP Server

यह अध्याय दिखाता है कि कैसे एक वास्तविक दुनिया का AI एजेंट बनाया जाए जो बाहरी APIs के साथ इंटीग्रेट होता है, विभिन्न डेटा प्रकारों को संभालता है, त्रुटियों का प्रबंधन करता है, और कई टूल्स को एक साथ ऑर्केस्ट्रेट करता है—और वह भी एक प्रोडक्शन-तैयार फॉर्मेट में। आप देखेंगे:

- **प्रमाणीकरण की आवश्यकता वाले बाहरी APIs के साथ इंटीग्रेशन**
- **कई एंडपॉइंट्स से विविध डेटा प्रकारों को संभालना**
- **मजबूत त्रुटि प्रबंधन और लॉगिंग रणनीतियाँ**
- **एक ही सर्वर में मल्टी-टूल ऑर्केस्ट्रेशन**

अंत तक, आपके पास पैटर्न्स और बेहतरीन प्रैक्टिसेज का व्यावहारिक अनुभव होगा जो उन्नत AI और LLM-पावर्ड एप्लिकेशन के लिए जरूरी हैं।

## परिचय

इस पाठ में, आप सीखेंगे कि कैसे एक उन्नत MCP सर्वर और क्लाइंट बनाया जाए जो SerpAPI का उपयोग करके LLM क्षमताओं को रियल-टाइम वेब डेटा के साथ बढ़ाता है। यह वेब से अपडेटेड जानकारी एक्सेस करने वाले डायनामिक AI एजेंट्स विकसित करने के लिए एक महत्वपूर्ण कौशल है।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- बाहरी APIs (जैसे SerpAPI) को सुरक्षित रूप से MCP सर्वर में इंटीग्रेट करना
- वेब, समाचार, उत्पाद खोज, और प्रश्नोत्तर के लिए कई टूल्स लागू करना
- LLM उपयोग के लिए संरचित डेटा को पार्स और फॉर्मेट करना
- त्रुटियों को संभालना और API दर सीमाओं का प्रभावी प्रबंधन करना
- स्वचालित और इंटरैक्टिव दोनों प्रकार के MCP क्लाइंट बनाना और परीक्षण करना

## Web Search MCP Server

यह अनुभाग वेब सर्च MCP सर्वर की आर्किटेक्चर और विशेषताएं प्रस्तुत करता है। आप देखेंगे कि कैसे FastMCP और SerpAPI को मिलाकर LLM क्षमताओं को रियल-टाइम वेब डेटा के साथ बढ़ाया जाता है।

### अवलोकन

यह इम्प्लीमेंटेशन चार टूल्स पेश करता है जो MCP की विविध, बाहरी API-चालित कार्यों को सुरक्षित और प्रभावी ढंग से संभालने की क्षमता को दर्शाते हैं:

- **general_search**: व्यापक वेब परिणामों के लिए
- **news_search**: हाल की खबरों के लिए
- **product_search**: ई-कॉमर्स डेटा के लिए
- **qna**: प्रश्न-उत्तर स्निपेट्स के लिए

### विशेषताएं
- **कोड उदाहरण**: भाषा-विशिष्ट कोड ब्लॉक्स (Python सहित और आसानी से अन्य भाषाओं में बढ़ाने योग्य) स्पष्टता के लिए कोलैप्सिबल सेक्शन्स में

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

क्लाइंट चलाने से पहले, यह समझना उपयोगी है कि सर्वर क्या करता है। [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)।

यहाँ एक संक्षिप्त उदाहरण है कि सर्वर कैसे एक टूल को परिभाषित और रजिस्टर करता है:

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

- **बाहरी API इंटीग्रेशन**: API कुंजियों और बाहरी अनुरोधों को सुरक्षित रूप से संभालने का प्रदर्शन
- **संरचित डेटा पार्सिंग**: API प्रतिक्रियाओं को LLM-फ्रेंडली फॉर्मेट में बदलना
- **त्रुटि प्रबंधन**: उपयुक्त लॉगिंग के साथ मजबूत त्रुटि प्रबंधन
- **इंटरैक्टिव क्लाइंट**: स्वचालित परीक्षण और इंटरैक्टिव मोड दोनों शामिल
- **संदर्भ प्रबंधन**: अनुरोधों को लॉग और ट्रैक करने के लिए MCP Context का उपयोग

## आवश्यकताएँ

शुरू करने से पहले, सुनिश्चित करें कि आपका वातावरण सही ढंग से सेटअप है। यह सुनिश्चित करेगा कि सभी निर्भरताएँ इंस्टॉल हों और आपके API कुंजी सही ढंग से कॉन्फ़िगर हों ताकि विकास और परीक्षण बिना रुकावट हो सके।

- Python 3.8 या उससे ऊपर
- SerpAPI API Key ([SerpAPI](https://serpapi.com/) पर साइन अप करें - मुफ्त टियर उपलब्ध)

## इंस्टॉलेशन

शुरू करने के लिए, निम्नलिखित चरणों का पालन करें:

1. uv (अनुशंसित) या pip का उपयोग करके निर्भरताएँ इंस्टॉल करें:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. प्रोजेक्ट रूट में `.env` फाइल बनाएं और उसमें अपना SerpAPI कुंजी डालें:

```
SERPAPI_KEY=your_serpapi_key_here
```

## उपयोग

Web Search MCP Server मुख्य घटक है जो वेब, समाचार, उत्पाद खोज, और प्रश्नोत्तर के लिए टूल्स प्रदान करता है SerpAPI के साथ इंटीग्रेशन करके। यह आने वाले अनुरोधों को संभालता है, API कॉल्स का प्रबंधन करता है, प्रतिक्रियाओं को पार्स करता है, और संरचित परिणाम क्लाइंट को वापस भेजता है।

पूरी इम्प्लीमेंटेशन आप [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) में देख सकते हैं।

### सर्वर चलाना

MCP सर्वर शुरू करने के लिए, निम्न कमांड का उपयोग करें:

```bash
python server.py
```

सर्वर stdio-आधारित MCP सर्वर के रूप में चलेगा जिसे क्लाइंट सीधे कनेक्ट कर सकता है।

### क्लाइंट मोड्स

क्लाइंट (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)।

### क्लाइंट चलाना

स्वचालित परीक्षण चलाने के लिए (यह अपने आप सर्वर भी शुरू कर देगा):

```bash
python client.py
```

या इंटरैक्टिव मोड में चलाने के लिए:

```bash
python client.py --interactive
```

### विभिन्न तरीकों से परीक्षण

आपकी ज़रूरतों और वर्कफ़्लो के अनुसार, सर्वर द्वारा प्रदान किए गए टूल्स का परीक्षण और इंटरैक्शन करने के कई तरीके हैं।

#### MCP Python SDK के साथ कस्टम टेस्ट स्क्रिप्ट लिखना
आप MCP Python SDK का उपयोग करके अपनी खुद की टेस्ट स्क्रिप्ट भी बना सकते हैं:

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

यहाँ "टेस्ट स्क्रिप्ट" का मतलब है एक कस्टम Python प्रोग्राम जो आप MCP सर्वर के क्लाइंट के रूप में लिखते हैं। यह औपचारिक यूनिट टेस्ट नहीं होता, बल्कि यह आपको प्रोग्रामेटिक रूप से सर्वर से कनेक्ट करने, इसके किसी भी टूल को अपने चुने हुए पैरामीटर के साथ कॉल करने, और परिणामों की जांच करने देता है। यह तरीका उपयोगी है:

- टूल कॉल्स के साथ प्रोटोटाइपिंग और प्रयोग करने के लिए
- सर्वर के विभिन्न इनपुट्स पर प्रतिक्रिया को मान्य करने के लिए
- टूल के कई बार कॉल को स्वचालित करने के लिए
- MCP सर्वर के ऊपर अपने वर्कफ़्लोज़ या इंटीग्रेशन बनाने के लिए

आप टेस्ट स्क्रिप्ट्स का उपयोग नए क्वेरीज जल्दी आजमाने, टूल व्यवहार डिबग करने, या अधिक उन्नत ऑटोमेशन के लिए शुरुआती बिंदु के रूप में कर सकते हैं। नीचे MCP Python SDK का उपयोग करके ऐसी स्क्रिप्ट बनाने का उदाहरण दिया गया है:

## टूल विवरण

सर्वर द्वारा प्रदान किए गए निम्न टूल्स का उपयोग विभिन्न प्रकार की खोजों और प्रश्नों के लिए किया जा सकता है। प्रत्येक टूल के पैरामीटर और उदाहरण उपयोग नीचे दिया गया है।

यह अनुभाग उपलब्ध प्रत्येक टूल और उनके पैरामीटर के बारे में विस्तार से जानकारी देता है।

### general_search

सामान्य वेब खोज करता है और फॉर्मेटेड परिणाम लौटाता है।

**इस टूल को कॉल कैसे करें:**

आप `general_search` को MCP Python SDK का उपयोग करके अपनी स्क्रिप्ट से कॉल कर सकते हैं, या Inspector या इंटरैक्टिव क्लाइंट मोड का उपयोग करके इंटरैक्टिवली। यहाँ SDK का उपयोग करते हुए कोड उदाहरण है:

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

वैकल्पिक रूप से, इंटरैक्टिव मोड में, `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): खोज क्वेरी चुनें

**उदाहरण अनुरोध:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

किसी क्वेरी से संबंधित हाल की समाचार लेख खोजता है।

**इस टूल को कॉल कैसे करें:**

आप `news_search` को MCP Python SDK का उपयोग करके अपनी स्क्रिप्ट से कॉल कर सकते हैं, या Inspector या इंटरैक्टिव क्लाइंट मोड में। यहाँ SDK का उदाहरण है:

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

इंटरैक्टिव मोड में, `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): खोज क्वेरी चुनें

**उदाहरण अनुरोध:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

किसी क्वेरी से मेल खाने वाले उत्पाद खोजता है।

**इस टूल को कॉल कैसे करें:**

आप `product_search` को MCP Python SDK का उपयोग करके अपनी स्क्रिप्ट से कॉल कर सकते हैं, या Inspector या इंटरैक्टिव क्लाइंट मोड में। यहाँ SDK का उदाहरण है:

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

इंटरैक्टिव मोड में, `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): उत्पाद खोज क्वेरी चुनें

**उदाहरण अनुरोध:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

खोज इंजनों से सीधे प्रश्नों के उत्तर प्राप्त करता है।

**इस टूल को कॉल कैसे करें:**

आप `qna` को MCP Python SDK का उपयोग करके अपनी स्क्रिप्ट से कॉल कर सकते हैं, या Inspector या इंटरैक्टिव क्लाइंट मोड में। यहाँ SDK का उदाहरण है:

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

इंटरैक्टिव मोड में, `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): उत्तर खोजने के लिए प्रश्न चुनें

**उदाहरण अनुरोध:**

```json
{
  "question": "what is artificial intelligence"
}
```

## कोड विवरण

यह अनुभाग सर्वर और क्लाइंट इम्प्लीमेंटेशन के कोड स्निपेट्स और संदर्भ प्रदान करता है।

<details>
<summary>Python</summary>

पूरी इम्प्लीमेंटेशन के लिए [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) देखें।

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## इस पाठ के उन्नत अवधारणाएँ

बिल्डिंग शुरू करने से पहले, यहाँ कुछ महत्वपूर्ण उन्नत अवधारणाएँ हैं जो इस अध्याय में बार-बार आएंगी। इन्हें समझना आपको बेहतर तरीके से आगे बढ़ने में मदद करेगा, भले ही आप इनके लिए नए हों:

- **मल्टी-टूल ऑर्केस्ट्रेशन**: इसका मतलब है कि एक ही MCP सर्वर में कई अलग-अलग टूल्स (जैसे वेब सर्च, न्यूज सर्च, प्रोडक्ट सर्च, और Q&A) चलाना। यह आपके सर्वर को केवल एक कार्य नहीं, बल्कि विभिन्न कार्यों को संभालने की क्षमता देता है।
- **API दर सीमा प्रबंधन**: कई बाहरी APIs (जैसे SerpAPI) सीमित करते हैं कि आप एक निश्चित समय में कितने अनुरोध कर सकते हैं। अच्छा कोड इन सीमाओं की जांच करता है और उन्हें संभालता है ताकि आपकी एप्लिकेशन टूटे नहीं जब आप सीमा पार करें।
- **संरचित डेटा पार्सिंग**: API प्रतिक्रियाएं अक्सर जटिल और नेस्टेड होती हैं। यह अवधारणा उन प्रतिक्रियाओं को साफ, उपयोग में आसान फॉर्मेट में बदलने के बारे में है जो LLM या अन्य प्रोग्रामों के लिए अनुकूल हों।
- **त्रुटि पुनर्प्राप्ति**: कभी-कभी नेटवर्क फेल हो सकता है या API अपेक्षित डेटा वापस नहीं करता। त्रुटि पुनर्प्राप्ति का मतलब है कि आपका कोड इन समस्याओं को संभाल सकता है और उपयोगी प्रतिक्रिया दे सकता है, बजाय क्रैश होने के।
- **पैरामीटर सत्यापन**: यह सुनिश्चित करना कि आपके टूल्स को दिए गए सभी इनपुट सही और सुरक्षित हैं। इसमें डिफ़ॉल्ट मान सेट करना और सही प्रकार की जांच शामिल है, जो बग और भ्रम से बचाता है।

यह अनुभाग आपको Web Search MCP Server के साथ काम करते समय आम समस्याओं का निदान और समाधान करने में मदद करेगा। यदि आपको त्रुटियाँ या अप्रत्याशित व्यवहार मिलता है, तो यह ट्रबलशूटिंग सेक्शन सबसे आम समस्याओं के समाधान देता है। आगे मदद मांगने से पहले इन टिप्स को देखें—अक्सर ये जल्दी समस्या हल कर देते हैं।

## ट्रबलशूटिंग

Web Search MCP Server के साथ काम करते समय, आपको कभी-कभी समस्याएँ आ सकती हैं—यह बाहरी APIs और नए टूल्स के साथ विकास करते समय सामान्य है। यह अनुभाग सबसे आम समस्याओं के व्यावहारिक समाधान प्रदान करता है ताकि आप जल्दी वापस ट्रैक पर आ सकें। यदि आपको कोई त्रुटि मिलती है, तो यहाँ से शुरू करें: नीचे दिए गए सुझाव उन समस्याओं को संबोधित करते हैं जिनका अधिकांश उपयोगकर्ता सामना करते हैं और अक्सर बिना अतिरिक्त मदद के आपके समस्या का समाधान कर देते हैं।

### सामान्य समस्याएँ

नीचे कुछ सबसे आम समस्याएँ हैं जिनका उपयोगकर्ता सामना करते हैं, उनके स्पष्ट स्पष्टीकरण और समाधान के साथ:

1. **.env फ़ाइल में SERPAPI_KEY गायब है**
   - यदि आपको त्रुटि मिलती है `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` फ़ाइल बनाएँ यदि आवश्यक हो। यदि आपकी कुंजी सही है लेकिन फिर भी यह त्रुटि आती है, तो जांचें कि क्या आपका मुफ्त टियर कोटा समाप्त हो गया है।

### डिबग मोड

डिफ़ॉल्ट रूप से, ऐप केवल महत्वपूर्ण जानकारी लॉग करता है। यदि आप यह देखना चाहते हैं कि क्या हो रहा है (जैसे जटिल समस्याओं का निदान करने के लिए), तो आप DEBUG मोड सक्षम कर सकते हैं। इससे आपको ऐप के प्रत्येक चरण के बारे में अधिक जानकारी मिलेगी।

**उदाहरण: सामान्य आउटपुट**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**उदाहरण: DEBUG आउटपुट**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

ध्यान दें कि DEBUG मोड HTTP अनुरोधों, प्रतिक्रियाओं, और अन्य आंतरिक विवरणों के अतिरिक्त लाइनें शामिल करता है। यह ट्रबलशूटिंग के लिए बहुत मददगार हो सकता है।

DEBUG मोड सक्षम करने के लिए, अपने `client.py` or `server.py` के शीर्ष पर लॉगिंग स्तर को DEBUG सेट करें:

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

## आगे क्या है

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या गलतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।