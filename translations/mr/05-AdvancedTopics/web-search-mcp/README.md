<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T15:16:07+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "mr"
}
-->
# धडा: वेब सर्च MCP सर्व्हर तयार करणे

हा अध्याय दर्शवितो की कसे खऱ्या जगातील AI एजंट तयार करायचा जो बाह्य API शी एकत्रित होतो, विविध डेटा प्रकार हाताळतो, त्रुटी व्यवस्थापित करतो, आणि अनेक टूल्सचे समन्वय करतो—हे सर्व उत्पादनासाठी तयार स्वरूपात. तुम्हाला पाहायला मिळेल:

- **प्रमाणीकरण आवश्यक असलेल्या बाह्य API शी एकत्रीकरण**
- **अनेक एंडपॉइंटमधून विविध डेटा प्रकार हाताळणे**
- **मजबूत त्रुटी हाताळणी आणि लॉगिंग धोरणे**
- **एकाच सर्व्हरमध्ये अनेक टूल्सचे समन्वय**

अखेरीस, तुम्हाला प्रगत AI आणि LLM-आधारित अनुप्रयोगांसाठी आवश्यक असलेल्या पॅटर्न्स आणि सर्वोत्तम पद्धतींचा व्यावहारिक अनुभव मिळेल.

## परिचय

या धड्यात, तुम्ही शिकाल कसे एक प्रगत MCP सर्व्हर आणि क्लायंट तयार करायचा जो SerpAPI वापरून LLM क्षमतांना रिअल-टाइम वेब डेटाने विस्तारित करतो. ही एक महत्त्वाची कौशल्ये आहे जी गतिशील AI एजंट तयार करण्यासाठी आवश्यक आहे जे वेबवरील अद्ययावत माहिती मिळवू शकतात.

## शिकण्याचे उद्दिष्टे

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- बाह्य API (जसे SerpAPI) सुरक्षितपणे MCP सर्व्हरमध्ये एकत्रित करणे
- वेब, बातम्या, उत्पादन शोध आणि Q&A साठी अनेक टूल्स अंमलात आणणे
- LLM वापरासाठी संरचित डेटा पार्स आणि फॉरमॅट करणे
- त्रुटी हाताळणे आणि API रेट लिमिट्स प्रभावीपणे व्यवस्थापित करणे
- स्वयंचलित आणि इंटरऐक्टिव MCP क्लायंट तयार करणे आणि तपासणे

## वेब सर्च MCP सर्व्हर

हा विभाग वेब सर्च MCP सर्व्हरची आर्किटेक्चर आणि वैशिष्ट्ये सादर करतो. तुम्हाला FastMCP आणि SerpAPI कसे एकत्र वापरले जातात हे दिसेल जे LLM क्षमतांना रिअल-टाइम वेब डेटाने वाढवतात.

### आढावा

या अंमलबजावणीत चार टूल्स आहेत जे MCP ची क्षमता दाखवतात की ते विविध, बाह्य API-आधारित कामे सुरक्षित आणि कार्यक्षमतेने हाताळू शकते:

- **general_search**: व्यापक वेब परिणामांसाठी
- **news_search**: अलीकडील हेडलाईन्ससाठी
- **product_search**: ई-कॉमर्स डेटा साठी
- **qna**: प्रश्न-उत्तर तुकड्यांसाठी

### वैशिष्ट्ये
- **कोड उदाहरणे**: Python साठी भाषा-विशिष्ट कोड ब्लॉक्स (आणि इतर भाषांसाठी सहज विस्तारयोग्य) क्लोजेबल सेक्शन्समध्ये स्पष्टतेसाठी

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

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

खालील उदाहरण दाखवते की सर्व्हर कसा टूल परिभाषित करतो आणि नोंदणी करतो:

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

- **बाह्य API एकत्रीकरण**: API कीज आणि बाह्य विनंत्यांचे सुरक्षित हाताळणी दाखवते
- **संरचित डेटा पार्सिंग**: API प्रतिसाद LLM-योग्य स्वरूपात रूपांतर कसे करायचे हे दर्शवते
- **त्रुटी हाताळणी**: योग्य लॉगिंगसह मजबूत त्रुटी हाताळणी
- **इंटरऐक्टिव क्लायंट**: स्वयंचलित चाचण्या आणि इंटरऐक्टिव मोड दोन्हीचा समावेश
- **कॉन्टेक्स्ट व्यवस्थापन**: MCP Context वापरून लॉगिंग आणि विनंती ट्रॅकिंग

## पूर्वतयारी

सुरू करण्यापूर्वी, तुमचे वातावरण योग्यरित्या सेटअप केले आहे याची खात्री करा. हे सुनिश्चित करेल की सर्व अवलंबित्वे इन्स्टॉल आहेत आणि तुमच्या API कीज योग्यरित्या कॉन्फिगर आहेत जेणेकरून विकास आणि चाचणी सुरळीत पार पडेल.

- Python 3.8 किंवा त्याहून वर
- SerpAPI API Key (साइन अप करा [SerpAPI](https://serpapi.com/) येथे - मोफत टियर उपलब्ध)

## इन्स्टॉलेशन

सुरू करण्यासाठी, तुमचे वातावरण सेटअप करण्यासाठी खालील पायऱ्या फॉलो करा:

1. अवलंबित्वे uv (शिफारस केलेले) किंवा pip वापरून इन्स्टॉल करा:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. प्रोजेक्ट रूटमध्ये `.env` फाइल तयार करा आणि तुमचा SerpAPI की जोडा:

```
SERPAPI_KEY=your_serpapi_key_here
```

## वापर

वेब सर्च MCP सर्व्हर हा मुख्य घटक आहे जो वेब, बातम्या, उत्पादन शोध, आणि Q&A साठी टूल्स प्रदान करतो SerpAPI सह एकत्रित होऊन. तो येणाऱ्या विनंत्या हाताळतो, API कॉल्स व्यवस्थापित करतो, प्रतिसाद पार्स करतो, आणि क्लायंटला संरचित निकाल परत करतो.

पूर्ण अंमलबजावणी तुम्ही [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) मध्ये पाहू शकता.

### सर्व्हर चालवणे

MCP सर्व्हर सुरू करण्यासाठी खालील कमांड वापरा:

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

स्वयंचलित चाचण्या चालवण्यासाठी (हे आपोआप सर्व्हर सुरू करेल):

```bash
python client.py
```

किंवा इंटरऐक्टिव मोडमध्ये चालवा:

```bash
python client.py --interactive
```

### वेगवेगळ्या पद्धतींनी चाचणी

सर्व्हरद्वारे प्रदान केलेल्या टूल्ससह चाचणी आणि संवाद करण्याचे अनेक मार्ग आहेत, तुमच्या गरजा आणि कार्यप्रवाहानुसार.

#### MCP Python SDK वापरून कस्टम टेस्ट स्क्रिप्ट लिहिणे
तुम्ही तुमचे स्वतःचे टेस्ट स्क्रिप्ट MCP Python SDK वापरून तयार करू शकता:

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

या संदर्भात, "टेस्ट स्क्रिप्ट" म्हणजे तुम्ही लिहिलेला एक कस्टम Python प्रोग्राम जो MCP सर्व्हरसाठी क्लायंट म्हणून कार्य करतो. हा औपचारिक युनिट टेस्ट नसून, तुम्हाला प्रोग्रामॅटिकली सर्व्हरशी कनेक्ट होण्याची, त्याच्या कोणत्याही टूल्सना तुमच्या निवडलेल्या पॅरामीटर्ससह कॉल करण्याची, आणि निकाल तपासण्याची परवानगी देतो. हा दृष्टिकोन उपयुक्त आहे:

- टूल कॉल्सची प्रोटोटायपिंग आणि प्रयोग करण्यासाठी
- सर्व्हर विविध इनपुट्सना कसा प्रतिसाद देतो ते तपासण्यासाठी
- पुनरावृत्ती टूल कॉल्स स्वयंचलित करण्यासाठी
- तुमचे स्वतःचे कार्यप्रवाह किंवा इंटिग्रेशन्स MCP सर्व्हरवर तयार करण्यासाठी

तुम्ही टेस्ट स्क्रिप्ट्स वापरून नवीन क्वेरीज पटकन तपासू शकता, टूल वर्तन डिबग करू शकता, किंवा प्रगत ऑटोमेशनसाठी सुरुवात करू शकता. खाली MCP Python SDK वापरून अशा स्क्रिप्ट कशी तयार करायची याचे उदाहरण दिले आहे:

## टूल वर्णने

तुम्ही खालील टूल्स वापरून वेगवेगळ्या प्रकारच्या शोध आणि क्वेरीज करू शकता. प्रत्येक टूल खाली त्याचे पॅरामीटर्स आणि वापराचे उदाहरणांसह वर्णन केले आहे.

हा विभाग प्रत्येक उपलब्ध टूल आणि त्यांचे पॅरामीटर्स याची माहिती देतो.

### general_search

सामान्य वेब शोध करतो आणि फॉरमॅट केलेले निकाल परत करतो.

**हा टूल कसे कॉल करावे:**

तुम्ही `general_search` तुमच्या स्वतःच्या स्क्रिप्टमधून MCP Python SDK वापरून कॉल करू शकता, किंवा Inspector किंवा इंटरऐक्टिव क्लायंट मोड वापरून इंटरऐक्टिवली वापरू शकता. SDK वापरून कोड उदाहरण खाली दिले आहे:

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

किंवा इंटरऐक्टिव मोडमध्ये, `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): शोध क्वेरी निवडा

**उदाहरण विनंती:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

क्वेरीशी संबंधित अलीकडील बातम्या शोधतो.

**हा टूल कसे कॉल करावे:**

तुम्ही `news_search` तुमच्या स्वतःच्या स्क्रिप्टमधून MCP Python SDK वापरून कॉल करू शकता, किंवा Inspector किंवा इंटरऐक्टिव क्लायंट मोड वापरून इंटरऐक्टिवली वापरू शकता. SDK वापरून कोड उदाहरण खाली दिले आहे:

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

किंवा इंटरऐक्टिव मोडमध्ये, `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): शोध क्वेरी निवडा

**उदाहरण विनंती:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

क्वेरीशी जुळणारी उत्पादने शोधतो.

**हा टूल कसे कॉल करावे:**

तुम्ही `product_search` तुमच्या स्वतःच्या स्क्रिप्टमधून MCP Python SDK वापरून कॉल करू शकता, किंवा Inspector किंवा इंटरऐक्टिव क्लायंट मोड वापरून इंटरऐक्टिवली वापरू शकता. SDK वापरून कोड उदाहरण खाली दिले आहे:

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

किंवा इंटरऐक्टिव मोडमध्ये, `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): उत्पादन शोध क्वेरी निवडा

**उदाहरण विनंती:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

शोध इंजिनमधून प्रश्नांची थेट उत्तरे मिळवतो.

**हा टूल कसे कॉल करावे:**

तुम्ही `qna` तुमच्या स्वतःच्या स्क्रिप्टमधून MCP Python SDK वापरून कॉल करू शकता, किंवा Inspector किंवा इंटरऐक्टिव क्लायंट मोड वापरून इंटरऐक्टिवली वापरू शकता. SDK वापरून कोड उदाहरण खाली दिले आहे:

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

किंवा इंटरऐक्टिव मोडमध्ये, `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): उत्तर शोधण्यासाठी प्रश्न निवडा

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

तुम्ही तयार होण्यापूर्वी, येथे काही महत्त्वाच्या प्रगत संकल्पना आहेत ज्या या अध्यायभर दिसतील. त्यांना समजून घेणे तुम्हाला सोपे जाईल, जरी तुम्हाला त्या आधी माहिती नसेल:

- **मल्टी-टूल समन्वय**: याचा अर्थ एकाच MCP सर्व्हरमध्ये वेगवेगळे टूल्स (जसे वेब सर्च, न्यूज सर्च, प्रॉडक्ट सर्च, आणि Q&A) चालवणे. यामुळे तुमचा सर्व्हर विविध कामे हाताळू शकतो, फक्त एकच नव्हे.
- **API रेट लिमिट हाताळणी**: अनेक बाह्य API (जसे SerpAPI) ठराविक वेळेत किती विनंत्या करता येतील हे मर्यादित करतात. चांगला कोड या मर्यादांचा तपास करतो आणि त्यांना योग्य प्रकारे हाताळतो, ज्यामुळे तुमचा अॅप ब्रेक होत नाही जर तुम्ही मर्यादा ओलांडली.
- **संरचित डेटा पार्सिंग**: API प्रतिसाद अनेकदा गुंतागुंतीचे आणि नेस्टेड असतात. या संकल्पनेचा अर्थ असा की त्या प्रतिसादांना स्वच्छ, वापरण्यास सोपे स्वरूपात रूपांतर करणे जे LLM किंवा इतर प्रोग्रामसाठी अनुकूल असते.
- **त्रुटी पुनर्प्राप्ती**: कधी कधी काही चुकते—कदाचित नेटवर्क फेल होते, किंवा API अपेक्षित प्रतिसाद देत नाही. त्रुटी पुनर्प्राप्ती म्हणजे तुमचा कोड अशा समस्या हाताळू शकतो आणि उपयुक्त अभिप्राय देतो, क्रॅश न होता.
- **पॅरामीटर वैधता तपासणी**: याचा अर्थ तुमच्या टूल्ससाठी सर्व इनपुट्स योग्य आणि सुरक्षित आहेत का ते तपासणे. यात डीफॉल्ट मूल्ये सेट करणे आणि प्रकार योग्य आहेत का हे सुनिश्चित करणे समाविष्ट आहे, जे बग्स आणि गोंधळ टाळते.

हा विभाग तुम्हाला वेब सर्च MCP सर्व्हरसह काम करताना येणाऱ्या सामान्य समस्या ओळखण्यास आणि सोडविण्यास मदत करेल. जर तुम्हाला त्रुटी किंवा अनपेक्षित वर्तन दिसले तर हा ट्रबलशूटिंग विभाग पहा—हे टिप्स अनेक समस्या पटकन सोडवतात.

## ट्रबलशूटिंग

वेब सर्च MCP सर्व्हरसह काम करताना, कधीकधी तुम्हाला अडचणी येऊ शकतात—बाह्य API आणि नवीन टूल्ससह विकास करताना हे सामान्य आहे. हा विभाग सर्वात सामान्य समस्यांसाठी व्यावहारिक उपाय देतो, जेणेकरून तुम्ही लवकरच पुन्हा ट्रॅकवर येऊ शकता. तुम्हाला एखादी त्रुटी आली तर इथे सुरुवात करा: खालील टिप्स सर्वाधिक वापरकर्त्यांना येणाऱ्या समस्या सोडवतात आणि बहुधा तुमची समस्या अतिरिक्त मदत न घेता सुटू शकते.

### सामान्य समस्या

खाली वापरकर्त्यांना येणाऱ्या काही सर्वात सामान्य समस्या आणि त्यांचे स्पष्ट स्पष्टीकरणे व सोडवण्याचे पावले दिले आहेत:

1. **.env फाइलमध्ये SERPAPI_KEY गहाळ आहे**
   - जर तुम्हाला त्रुटी दिसली `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` फाइल तयार करा. तुमची की बरोबर आहे पण त्रुटी येत आहे तर तपासा की तुमचा मोफत टियर कोटा संपलेला नाही का.

### डीबग मोड

डिफॉल्टनुसार, अॅप फक्त महत्त्वाची माहिती लॉग करते. जर तुम्हाला काय चालले आहे याबद्दल अधिक तपशील पाहायचे असतील (उदा., क्लिष्ट समस्या निदान करण्यासाठी), तर DEBUG मोड सक्षम करू शकता. हे तुम्हाला अॅपच्या प्रत्येक टप्प्याबद्दल अधिक माहिती दाखवेल.

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

लक्षात घ्या की DEBUG मोड HTTP विनंत्या, प्रतिसाद, आणि इतर अंतर्गत तपशील याबद्दल अतिरिक्त ओळी दाखवतो. हे ट्रबलशूटिंगसाठी खूप उपयुक्त ठरू शकते.

DEBUG मोड सक्षम करण्यासाठी, `client.py` or `server.py` च्या वर लॉगिंग लेव्हल DEBUG वर सेट करा:

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

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात ठेवा की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जातो. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद शिफारसीय आहे. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागीसाठी आम्ही जबाबदार नाही.