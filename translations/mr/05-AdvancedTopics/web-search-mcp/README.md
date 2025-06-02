<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T18:47:25+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "mr"
}
-->
# धडा: वेब सर्च MCP सर्व्हर तयार करणे

हा अध्याय तुम्हाला एक वास्तविक AI एजंट तयार करण्याची पद्धत दाखवतो जो बाह्य API शी एकत्र काम करतो, विविध डेटा प्रकार हाताळतो, त्रुटी व्यवस्थापित करतो आणि अनेक साधने एकत्र चालवतो—तेही उत्पादनासाठी तयार स्वरूपात. तुम्हाला खालील गोष्टी दिसतील:

- **प्रमाणीकरण आवश्यक असलेल्या बाह्य API सोबत एकत्रीकरण**
- **अनेक एंडपॉइंट्समधून विविध डेटा प्रकार हाताळणे**
- **मजबूत त्रुटी हाताळणी आणि लॉगिंग धोरणे**
- **एकाच सर्व्हरमध्ये अनेक साधनांचे समन्वय**

शेवटी, तुम्हाला प्रगत AI आणि LLM-आधारित अनुप्रयोगांसाठी आवश्यक असलेल्या पॅटर्न्स आणि सर्वोत्तम पद्धतींचा व्यावहारिक अनुभव मिळेल.

## परिचय

या धड्यात, तुम्हाला एक प्रगत MCP सर्व्हर आणि क्लायंट तयार करण्याची पद्धत शिकवली जाईल जो SerpAPI वापरून रिअल-टाइम वेब डेटासह LLM क्षमता वाढवतो. हे वेबवरील अद्ययावत माहिती मिळवणाऱ्या डायनॅमिक AI एजंट्स विकसित करण्यासाठी एक महत्त्वपूर्ण कौशल्य आहे.

## शिकण्याचे उद्दिष्ट

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- MCP सर्व्हरमध्ये सुरक्षितपणे बाह्य API (जसे SerpAPI) एकत्रित करणे
- वेब, बातम्या, उत्पादन शोध आणि Q&A साठी अनेक साधने अंमलात आणणे
- LLM वापरासाठी संरचित डेटा पार्स आणि स्वरूपित करणे
- त्रुटी हाताळणे आणि API रेट लिमिट्स प्रभावीपणे व्यवस्थापित करणे
- स्वयंचलित आणि इंटरॅक्टिव MCP क्लायंट तयार करणे आणि चाचणी करणे

## वेब सर्च MCP सर्व्हर

या विभागात वेब सर्च MCP सर्व्हरची आर्किटेक्चर आणि वैशिष्ट्ये सादर केली आहेत. तुम्हाला FastMCP आणि SerpAPI कसे एकत्र वापरले जातात हे दिसेल जे LLM क्षमता रिअल-टाइम वेब डेटासह वाढवतात.

### आढावा

ही अंमलबजावणी चार साधने वापरते जी MCP च्या सुरक्षित आणि कार्यक्षमपणे विविध बाह्य API-चालित कार्ये हाताळण्याच्या क्षमतेचे प्रदर्शन करतात:

- **general_search**: व्यापक वेब परिणामांसाठी
- **news_search**: अलीकडील शीर्षके शोधण्यासाठी
- **product_search**: ई-कॉमर्स डेटा साठी
- **qna**: प्रश्नोत्तरे मिळवण्यासाठी

### वैशिष्ट्ये
- **कोड उदाहरणे**: Python साठी भाषानुसार कोड ब्लॉक्स (आणि इतर भाषांमध्ये सहज विस्तारयोग्य) स्पष्टतेसाठी संक्षिप्त विभागांमध्ये

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

क्लायंट चालवण्यापूर्वी, सर्व्हर काय करतो हे समजून घेणे उपयुक्त आहे. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) पाहा.

येथे सर्व्हर कसे टूल परिभाषित आणि नोंदवतो याचे एक संक्षिप्त उदाहरण आहे:

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

- **बाह्य API एकत्रीकरण**: API की आणि बाह्य विनंत्यांचा सुरक्षित हाताळणी दाखवते
- **संरचित डेटा पार्सिंग**: API प्रतिसाद LLM-मैत्रीपूर्ण स्वरूपात कसे रूपांतरित करायचे ते दाखवते
- **त्रुटी हाताळणी**: योग्य लॉगिंगसह मजबूत त्रुटी हाताळणी
- **इंटरॅक्टिव क्लायंट**: स्वयंचलित चाचण्या आणि इंटरॅक्टिव मोड दोन्ही समाविष्ट
- **कॉन्टेक्स्ट मॅनेजमेंट**: MCP Context वापरून लॉगिंग आणि विनंती ट्रॅकिंग

## पूर्वअट

सुरू करण्यापूर्वी, तुमचे वातावरण योग्यरित्या सेटअप केलेले आहे याची खात्री करा. यामुळे सर्व अवलंबित्वे इन्स्टॉल होतील आणि तुमच्या API की योग्यरित्या कॉन्फिगर होतील जेणेकरून विकास आणि चाचणी सुलभ होईल.

- Python 3.8 किंवा त्याहून अधिक
- SerpAPI API Key (साइन अप करा [SerpAPI](https://serpapi.com/) वर - फ्री टियर उपलब्ध)

## इन्स्टॉलेशन

सुरू करण्यासाठी, तुमचे वातावरण सेटअप करण्यासाठी खालील चरणांचे पालन करा:

1. uv (शिफारसीय) किंवा pip वापरून अवलंबित्वे इन्स्टॉल करा:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. प्रोजेक्टच्या मूळ फोल्डरमध्ये `.env` फाइल तयार करा आणि तुमचा SerpAPI की जोडा:

```
SERPAPI_KEY=your_serpapi_key_here
```

## वापर

वेब सर्च MCP सर्व्हर हा मुख्य घटक आहे जो वेब, बातम्या, उत्पादन शोध आणि Q&A साठी साधने SerpAPI शी एकत्र करून उपलब्ध करतो. तो येणाऱ्या विनंत्या हाताळतो, API कॉल्स व्यवस्थापित करतो, प्रतिसाद पार्स करतो आणि क्लायंटला संरचित निकाल परत करतो.

पूर्ण अंमलबजावणी तुम्ही [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) मध्ये पाहू शकता.

### सर्व्हर चालवणे

MCP सर्व्हर सुरू करण्यासाठी खालील आदेश वापरा:

```bash
python server.py
```

सर्व्हर stdio-आधारित MCP सर्व्हर म्हणून चालेल ज्याला क्लायंट थेट कनेक्ट होऊ शकतो.

### क्लायंट मोड्स

क्लायंट (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### क्लायंट चालवणे

स्वयंचलित चाचण्या चालवण्यासाठी (हे आपोआप सर्व्हरही सुरू करेल):

```bash
python client.py
```

किंवा इंटरॅक्टिव मोडमध्ये चालवा:

```bash
python client.py --interactive
```

### वेगवेगळ्या पद्धतींनी चाचणी

सर्व्हरद्वारे दिलेल्या साधनांसह चाचणी आणि संवाद साधण्यासाठी अनेक मार्ग आहेत, तुमच्या गरजा आणि कार्यप्रवाहानुसार.

#### MCP Python SDK वापरून कस्टम टेस्ट स्क्रिप्ट लिहिणे

तुम्ही MCP Python SDK वापरून तुमचे स्वतःचे टेस्ट स्क्रिप्ट तयार करू शकता:

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

या संदर्भात, "टेस्ट स्क्रिप्ट" म्हणजे तुम्ही लिहिलेला एक कस्टम Python प्रोग्राम जो MCP सर्व्हरसाठी क्लायंट म्हणून काम करतो. हा औपचारिक युनिट टेस्ट नसून, तुम्हाला प्रोग्रामॅटिकली सर्व्हरशी कनेक्ट होऊन, कोणत्याही टूलला तुमच्या निवडलेल्या पॅरामीटर्ससह कॉल करण्याची आणि निकाल तपासण्याची परवानगी देतो. हा दृष्टिकोन उपयोगी आहे:

- टूल कॉल्सचे प्रोटोटायपिंग आणि प्रयोग करण्यासाठी
- सर्व्हर वेगवेगळ्या इनपुटवर कसा प्रतिसाद देतो हे तपासण्यासाठी
- टूल कॉल्सचे स्वयंचलित पुनरावृत्ती करण्यासाठी
- तुमचे स्वतःचे कार्यप्रवाह किंवा एकत्रीकरण MCP सर्व्हरवर तयार करण्यासाठी

टेस्ट स्क्रिप्ट वापरून तुम्ही नवीन क्वेरीज पटकन तपासू शकता, टूल वर्तन डीबग करू शकता, किंवा प्रगत स्वयंचलनासाठी सुरुवात करू शकता. खाली MCP Python SDK वापरून अशी स्क्रिप्ट कशी तयार करायची याचे उदाहरण आहे:

## टूल वर्णने

सर्व्हरद्वारे दिलेली खालील साधने विविध प्रकारच्या शोध आणि क्वेरीजसाठी वापरू शकता. प्रत्येक साधन खाली त्याच्या पॅरामीटर्स आणि उदाहरणांसह वर्णन केले आहे.

या विभागात प्रत्येक उपलब्ध टूल आणि त्याचे पॅरामीटर्स तपशीलवार दिले आहेत.

### general_search

सामान्य वेब शोध करतो आणि स्वरूपित निकाल परत करतो.

**हे टूल कसे कॉल करायचे:**

तुम्ही `general_search` तुमच्या स्वतःच्या स्क्रिप्टमधून MCP Python SDK वापरून कॉल करू शकता, किंवा Inspector किंवा इंटरॅक्टिव क्लायंट मोड वापरून संवादात्मकपणे. SDK वापरून कोड उदाहरण खाली दिले आहे:

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

इतर पर्याय म्हणून, इंटरॅक्टिव मोडमध्ये, `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): शोध क्वेरी निवडा

**उदाहरण विनंती:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

एखाद्या क्वेरीशी संबंधित अलीकडील बातम्या शोधतो.

**हे टूल कसे कॉल करायचे:**

तुम्ही `news_search` तुमच्या स्वतःच्या स्क्रिप्टमधून MCP Python SDK वापरून कॉल करू शकता, किंवा Inspector किंवा इंटरॅक्टिव क्लायंट मोड वापरून संवादात्मकपणे. SDK वापरून कोड उदाहरण खाली दिले आहे:

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

इतर पर्याय म्हणून, इंटरॅक्टिव मोडमध्ये, `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): शोध क्वेरी निवडा

**उदाहरण विनंती:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

एखाद्या क्वेरीशी सुसंगत उत्पादने शोधतो.

**हे टूल कसे कॉल करायचे:**

तुम्ही `product_search` तुमच्या स्वतःच्या स्क्रिप्टमधून MCP Python SDK वापरून कॉल करू शकता, किंवा Inspector किंवा इंटरॅक्टिव क्लायंट मोड वापरून संवादात्मकपणे. SDK वापरून कोड उदाहरण खाली दिले आहे:

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

इतर पर्याय म्हणून, इंटरॅक्टिव मोडमध्ये, `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): उत्पादन शोध क्वेरी निवडा

**उदाहरण विनंती:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

शोध इंजिनकडून थेट प्रश्नांची उत्तरे मिळवतो.

**हे टूल कसे कॉल करायचे:**

तुम्ही `qna` तुमच्या स्वतःच्या स्क्रिप्टमधून MCP Python SDK वापरून कॉल करू शकता, किंवा Inspector किंवा इंटरॅक्टिव क्लायंट मोड वापरून संवादात्मकपणे. SDK वापरून कोड उदाहरण खाली दिले आहे:

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

इतर पर्याय म्हणून, इंटरॅक्टिव मोडमध्ये, `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): उत्तर शोधायचा प्रश्न निवडा

**उदाहरण विनंती:**

```json
{
  "question": "what is artificial intelligence"
}
```

## कोड तपशील

हा विभाग सर्व्हर आणि क्लायंट अंमलबजावणीसाठी कोड स्निपेट्स आणि संदर्भ प्रदान करतो.

<details>
<summary>Python</summary>

पूर्ण अंमलबजावणीसाठी [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) पहा.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## या धड्यातील प्रगत संकल्पना

तुम्ही तयार करताना, येथे काही महत्त्वाच्या प्रगत संकल्पना आहेत ज्या या अध्यायात वारंवार येतील. या समजल्याने तुम्हाला पुढे जाणे सोपे जाईल, अगदी तुम्ही नवशिक्या असलात तरी:

- **मल्टि-टूल समन्वय**: याचा अर्थ एका MCP सर्व्हरमध्ये वेगवेगळ्या टूल्स (जसे वेब सर्च, न्यूज सर्च, प्रॉडक्ट सर्च, आणि Q&A) चालवणे. त्यामुळे तुमचा सर्व्हर फक्त एक काम नव्हे, तर अनेक कामे हाताळू शकतो.
- **API रेट लिमिट हाताळणी**: अनेक बाह्य API (जसे SerpAPI) ठराविक वेळेत किती विनंत्या करता येतील यावर मर्यादा घालतात. चांगला कोड या मर्यादांवर लक्ष ठेवतो आणि योग्यरित्या हाताळतो, जेणेकरून तुमचा अॅप ब्रेक होणार नाही.
- **संरचित डेटा पार्सिंग**: API प्रतिसाद अनेकदा गुंतागुंतीचे आणि नेस्टेड असतात. हा संकल्पना म्हणजे त्या प्रतिसादांना स्वच्छ, वापरण्यास सोपे स्वरूपात रूपांतरित करणे जे LLM किंवा इतर प्रोग्रामसाठी सोयीचे असते.
- **त्रुटी पुनर्प्राप्ती**: कधी कधी समस्या येतात—नेटवर्क फेल होणे, API अपेक्षित डेटा न देणे इत्यादी. त्रुटी पुनर्प्राप्ती म्हणजे तुमचा कोड अशा समस्या हाताळू शकतो आणि उपयुक्त प्रतिसाद देतो, अॅप क्रॅश न होऊ देता.
- **पॅरामीटर पडताळणी**: हे म्हणजे तुमच्या टूल्समध्ये दिलेले इनपुट योग्य आणि सुरक्षित आहेत की नाही हे तपासणे. यात डीफॉल्ट मूल्ये सेट करणे आणि प्रकार योग्य आहेत का हे पाहणे यांचा समावेश होतो, ज्यामुळे बग्स आणि गोंधळ टाळता येतो.

हा विभाग तुम्हाला वेब सर्च MCP सर्व्हरवर काम करताना येणाऱ्या सामान्य समस्या ओळखण्यात आणि सोडवण्यात मदत करेल. जर तुम्हाला त्रुटी किंवा अनपेक्षित वर्तन आढळले तर हा ट्रबलशूटिंग विभाग पहा—हे टिप्स बहुतेक वेळा समस्या लवकर सुटवतात.

## समस्या निवारण

वेब सर्च MCP सर्व्हरवर काम करताना कधी कधी अडचणी येऊ शकतात—बाह्य API आणि नवीन साधनांसोबत विकास करताना हे सामान्य आहे. हा विभाग सर्वात सामान्य समस्या आणि त्यांचे व्यावहारिक उपाय देतो, ज्यामुळे तुम्ही लवकर मार्गावर येऊ शकता. त्रुटी आढळल्यास, येथे सुरुवात करा: खालील टिप्स अनेक वापरकर्त्यांच्या समस्या सोडवतात आणि अतिरिक्त मदत न घेता समस्या सुटू शकतात.

### सामान्य समस्या

खाली वापरकर्त्यांना आढळणाऱ्या काही सामान्य समस्यांची यादी आहे, सोबत स्पष्ट स्पष्टीकरणे आणि सोडवण्याचे पद्धती:

1. **.env फाइलमध्ये SERPAPI_KEY नाही**
   - जर तुम्हाला `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` त्रुटी दिसली तर `.env` फाइल तयार करा आणि तुमचा की योग्यरित्या सेट करा. तुमची की बरोबर असली तरी त्रुटी येत असेल तर तुमचा फ्री टियर क्वोटा संपलेला आहे का ते तपासा.

### डीबग मोड

मुळात, अॅप फक्त महत्त्वाची माहिती लॉग करते. जर तुम्हाला काय चालू आहे याबद्दल अधिक तपशील पाहायचे असतील (उदा. कठीण समस्या शोधण्यासाठी), तर DEBUG मोड सक्षम करू शकता. त्यामुळे अॅप प्रत्येक टप्प्यावर अधिक माहिती दाखवेल.

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

DEBUG मोडमध्ये HTTP विनंत्या, प्रतिसाद आणि इतर अंतर्गत तपशील अधिक दिसतात. हे त्रुटी शोधण्यात खूप उपयुक्त ठरते.

DEBUG मोड सक्षम करण्यासाठी, `client.py` or `server.py` च्या सुरुवातीला लॉगिंग लेव्हल DEBUG वर सेट करा:

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

## पुढे काय

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, परंतु कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थनिर्देशनासाठी आम्ही जबाबदार नाही.