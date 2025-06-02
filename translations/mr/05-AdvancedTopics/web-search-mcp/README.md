<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:08:49+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "mr"
}
-->
# धडा: वेब सर्च MCP सर्व्हर तयार करणे


हा अध्याय वास्तविक जगातील AI एजंट कसा तयार करायचा हे दाखवतो, जो बाह्य API शी जोडतो, विविध डेटा प्रकार हाताळतो, त्रुटी व्यवस्थापित करतो, आणि अनेक साधने एकत्र चालवतो—तेही उत्पादनासाठी तयार स्वरूपात. तुम्हाला खालील गोष्टी दिसतील:

- **प्रमाणीकरण आवश्यक असलेल्या बाह्य API शी समाकलन**
- **विविध एंडपॉइंटमधून विविध डेटा प्रकार हाताळणे**
- **मजबूत त्रुटी हाताळणी आणि लॉगिंग धोरणे**
- **एकाच सर्व्हरमध्ये अनेक साधनांचे समन्वयन**

अखेर, तुम्हाला प्रगत AI आणि LLM-आधारित अनुप्रयोगांसाठी आवश्यक पद्धती आणि सर्वोत्तम सरावांची व्यावहारिक अनुभव मिळेल.

## परिचय

या धड्यात, तुम्हाला SerpAPI वापरून रिअल-टाइम वेब डेटासह LLM क्षमतांचा विस्तार करणारा प्रगत MCP सर्व्हर आणि क्लायंट तयार करायचा शिकवला जाईल. ही एक महत्त्वाची कौशल्ये आहेत ज्यामुळे डायनॅमिक AI एजंट तयार करता येतात जे वेबवरील अद्ययावत माहिती मिळवू शकतात.

## शिकण्याची उद्दिष्टे

या धड्याच्या शेवटी, तुम्ही खालील गोष्टी करू शकाल:

- बाह्य API (जसे की SerpAPI) सुरक्षितपणे MCP सर्व्हरमध्ये समाकलित करणे
- वेब, बातम्या, उत्पादन शोध आणि Q&A साठी अनेक साधने अंमलात आणणे
- LLM साठी संरचित डेटा पार्स आणि स्वरूपित करणे
- त्रुटी हाताळणी आणि API दर मर्यादा प्रभावीपणे व्यवस्थापित करणे
- स्वयंचलित आणि इंटरएक्टिव MCP क्लायंट तयार करणे आणि चाचणी करणे

## वेब सर्च MCP सर्व्हर

या विभागात वेब सर्च MCP सर्व्हरची रचना आणि वैशिष्ट्ये सादर केली आहेत. तुम्हाला FastMCP आणि SerpAPI एकत्र कसे वापरले जातात हे दिसेल जेणेकरून LLM क्षमतांना रिअल-टाइम वेब डेटासह विस्तारित करता येईल.

### आढावा

ही अंमलबजावणी चार साधनांचा समावेश करते जे MCP च्या सुरक्षित आणि कार्यक्षमपणे विविध बाह्य API-चालित कामे हाताळण्याच्या क्षमतेचे प्रदर्शन करतात:

- **general_search**: विस्तृत वेब निकालांसाठी
- **news_search**: अलीकडील बातम्यांसाठी
- **product_search**: ई-कॉमर्स डेटासाठी
- **qna**: प्रश्नोत्तरे मिळवण्यासाठी

### वैशिष्ट्ये
- **कोड उदाहरणे**: Python साठी भाषा-विशिष्ट कोड ब्लॉक्स (आणि इतर भाषांसाठी सहज विस्तारयोग्य) समाविष्ट, स्पष्टतेसाठी कोंढाळलेले विभाग वापरून

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

येथे एक संक्षिप्त उदाहरण आहे की सर्व्हर कसा साधन परिभाषित करतो आणि नोंदणी करतो:

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

- **बाह्य API समाकलन**: API की आणि बाह्य विनंत्यांचे सुरक्षित हाताळणी दाखवते
- **संरचित डेटा पार्सिंग**: API प्रतिसाद LLM-योग्य स्वरूपात रूपांतरित करण्याचा दाखला
- **त्रुटी हाताळणी**: योग्य लॉगिंगसह मजबूत त्रुटी हाताळणी
- **इंटरएक्टिव क्लायंट**: स्वयंचलित चाचण्या आणि इंटरएक्टिव मोड दोन्ही समाविष्ट
- **संदर्भ व्यवस्थापन**: MCP संदर्भ वापरून लॉगिंग आणि विनंत्यांचे ट्रॅकिंग

## पूर्वअटी

तुम्ही सुरू करण्यापूर्वी, खालील पायऱ्या पूर्ण करून तुमचे वातावरण योग्यरित्या सेट करा. यामुळे सर्व अवलंबित्वे इन्स्टॉल होतील आणि तुमच्या API की योग्यरित्या कॉन्फिगर होतील, ज्यामुळे विकास आणि चाचणी सुलभ होईल.

- Python 3.8 किंवा त्याहून वर
- SerpAPI API Key (नोंदणी करा [SerpAPI](https://serpapi.com/) - मोफत स्तर उपलब्ध)

## स्थापना

सुरू करण्यासाठी, तुमचे वातावरण सेट करण्यासाठी खालील पायऱ्या करा:

1. uv (शिफारस केलेले) किंवा pip वापरून अवलंबित्वे इन्स्टॉल करा:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. प्रकल्पाच्या मूळ फोल्डरमध्ये `.env` फाइल तयार करा आणि त्यात तुमचा SerpAPI की जोडा:

```
SERPAPI_KEY=your_serpapi_key_here
```

## वापर

वेब सर्च MCP सर्व्हर हा मुख्य घटक आहे जो वेब, बातम्या, उत्पादन शोध आणि Q&A साठी साधने प्रदान करतो, SerpAPI शी जोडून. तो येणाऱ्या विनंत्यांचे व्यवस्थापन करतो, API कॉल्स हाताळतो, प्रतिसाद पार्स करतो आणि क्लायंटला संरचित निकाल परत करतो.

पूर्ण अंमलबजावणी तुम्ही [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) मध्ये पाहू शकता.

### सर्व्हर चालवणे

MCP सर्व्हर सुरू करण्यासाठी खालील आदेश वापरा:

```bash
python server.py
```

सर्व्हर stdio-आधारित MCP सर्व्हर म्हणून चालेल ज्याला क्लायंट थेट जोडू शकतो.

### क्लायंट मोड

क्लायंट (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### क्लायंट चालवणे

स्वयंचलित चाचण्या चालवण्यासाठी (हे आपोआप सर्व्हर सुरू करेल):

```bash
python client.py
```

किंवा इंटरएक्टिव मोडमध्ये चालवा:

```bash
python client.py --interactive
```

### विविध पद्धतींनी चाचणी करणे

तुमच्या गरजा आणि कामाच्या प्रवाहानुसार, सर्व्हरने दिलेल्या साधनांसह चाचणी आणि संवाद साधण्याचे अनेक मार्ग आहेत.

#### MCP Python SDK वापरून सानुकूल चाचणी स्क्रिप्ट लिहिणे
तुम्ही MCP Python SDK वापरून तुमचे स्वतःचे चाचणी स्क्रिप्ट देखील तयार करू शकता:

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

या संदर्भात, "चाचणी स्क्रिप्ट" म्हणजे तुम्ही लिहिलेला सानुकूल Python प्रोग्राम जो MCP सर्व्हरसाठी क्लायंट म्हणून काम करतो. हा स्क्रिप्ट औपचारिक युनिट चाचणी नसून प्रोग्रामॅटिकली सर्व्हरशी कनेक्ट होऊन, त्याच्या कोणत्याही साधनांना तुम्ही दिलेल्या पॅरामीटर्ससह कॉल करतो आणि निकाल तपासतो. हा दृष्टिकोन उपयुक्त आहे:

- साधन कॉलचे प्रोटोटायपिंग आणि प्रयोग करण्यासाठी
- सर्व्हर वेगवेगळ्या इनपुटवर कसा प्रतिसाद देतो हे पडताळण्यासाठी
- पुनरावृत्ती साधन कॉल स्वयंचलित करण्यासाठी
- MCP सर्व्हरवर तुमचे स्वतःचे कार्यप्रवाह किंवा समाकलने तयार करण्यासाठी

तुम्ही चाचणी स्क्रिप्ट वापरून नवीन क्वेरी जलदपणे तपासू शकता, साधनांच्या वर्तनात त्रुटी शोधू शकता, किंवा प्रगत स्वयंचलनासाठी सुरुवात करू शकता. खाली MCP Python SDK वापरून अशा स्क्रिप्ट तयार करण्याचे उदाहरण दिले आहे:

## साधन वर्णने

तुम्ही सर्व्हरने दिलेली खालील साधने वापरून वेगवेगळ्या प्रकारच्या शोध आणि प्रश्न विचारू शकता. प्रत्येक साधन खाली त्याच्या पॅरामीटर्ससह आणि वापराच्या उदाहरणांसह वर्णन केले आहे.

या विभागात प्रत्येक उपलब्ध साधन आणि त्याचे पॅरामीटर्स तपशीलवार दिले आहेत.

### general_search

सामान्य वेब शोध करतो आणि स्वरूपित निकाल परत करतो.

**हे साधन कसे कॉल करावे:**

तुम्ही `general_search` स्वतःच्या स्क्रिप्टमधून MCP Python SDK वापरून कॉल करू शकता, किंवा Inspector किंवा इंटरएक्टिव क्लायंट मोड वापरून संवादात्मकपणे. SDK वापरून कोड उदाहरण येथे आहे:

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

किंवा इंटरएक्टिव मोडमध्ये, `general_search` from the menu and enter your query when prompted.

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

**हे साधन कसे कॉल करावे:**

तुम्ही `news_search` स्वतःच्या स्क्रिप्टमधून MCP Python SDK वापरून कॉल करू शकता, किंवा Inspector किंवा इंटरएक्टिव क्लायंट मोड वापरून संवादात्मकपणे. SDK वापरून कोड उदाहरण येथे आहे:

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

किंवा इंटरएक्टिव मोडमध्ये, `news_search` from the menu and enter your query when prompted.

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

**हे साधन कसे कॉल करावे:**

तुम्ही `product_search` स्वतःच्या स्क्रिप्टमधून MCP Python SDK वापरून कॉल करू शकता, किंवा Inspector किंवा इंटरएक्टिव क्लायंट मोड वापरून संवादात्मकपणे. SDK वापरून कोड उदाहरण येथे आहे:

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

किंवा इंटरएक्टिव मोडमध्ये, `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): उत्पादन शोध क्वेरी निवडा

**उदाहरण विनंती:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

शोध इंजिनमधून प्रश्नांचे थेट उत्तर मिळवतो.

**हे साधन कसे कॉल करावे:**

तुम्ही `qna` स्वतःच्या स्क्रिप्टमधून MCP Python SDK वापरून कॉल करू शकता, किंवा Inspector किंवा इंटरएक्टिव क्लायंट मोड वापरून संवादात्मकपणे. SDK वापरून कोड उदाहरण येथे आहे:

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

किंवा इंटरएक्टिव मोडमध्ये, `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): उत्तर शोधायचा प्रश्न निवडा

**उदाहरण विनंती:**

```json
{
  "question": "what is artificial intelligence"
}
```

## कोड तपशील

या विभागात सर्व्हर आणि क्लायंट अंमलबजावणीसाठी कोड स्निपेट्स आणि संदर्भ दिले आहेत.

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

तुम्ही तयार करायला सुरुवात करण्यापूर्वी, या अध्यायात वारंवार येणाऱ्या काही महत्त्वाच्या प्रगत संकल्पना येथे आहेत. या समजल्यास तुम्हाला पुढे जाणे सोपे जाईल, अगदी तुम्ही त्यांना आधी न ओळखत असलात तरीही:

- **अनेक साधनांचे समन्वयन**: याचा अर्थ वेगवेगळ्या साधनांना (जसे वेब शोध, बातम्या शोध, उत्पादन शोध, आणि Q&A) एका MCP सर्व्हरमध्ये चालवणे. यामुळे तुमचा सर्व्हर एकाच वेळी विविध कामे हाताळू शकतो.
- **API दर मर्यादा हाताळणी**: अनेक बाह्य API (जसे SerpAPI) काही वेळेत किती विनंत्या करता येतील यावर मर्यादा ठेवतात. चांगला कोड या मर्यादांची तपासणी करतो आणि योग्य प्रकारे हाताळतो, ज्यामुळे तुमचा अॅप मर्यादा ओलांडल्यावरही अडखळत नाही.
- **संरचित डेटा पार्सिंग**: API प्रतिसाद बहुतेक वेळा गुंतागुंतीचे आणि नेस्टेड असतात. हा संकल्पना म्हणजे त्या प्रतिसादांना स्वच्छ, वापरण्यास सुलभ स्वरूपात रूपांतरित करणे जे LLM किंवा इतर प्रोग्रामसाठी अनुकूल असते.
- **त्रुटी पुनर्प्राप्ती**: कधी कधी काही चुकते—कदाचित नेटवर्क अयशस्वी होते किंवा API अपेक्षित माहिती परत देत नाही. त्रुटी पुनर्प्राप्ती म्हणजे तुमचा कोड या समस्या हाताळू शकतो आणि उपयुक्त अभिप्राय देतो, क्रॅश न होता.
- **पॅरामीटर प्रमाणीकरण**: याचा अर्थ तुमच्या साधनांना दिलेले सर्व इनपुट योग्य आणि सुरक्षित आहेत का ते तपासणे. यात डीफॉल्ट मूल्ये सेट करणे आणि प्रकारांची पडताळणी करणे समाविष्ट आहे, जे बग्स आणि गैरसमज टाळण्यास मदत करते.

## समस्या निवारण

वेब सर्च MCP सर्व्हर वापरताना तुम्हाला कधी कधी अडचणी येऊ शकतात—बाह्य API आणि नवीन साधने वापरताना हे सामान्य आहे. हा विभाग सर्वसामान्य समस्या आणि त्यांचे उपाय देतो, ज्यामुळे तुम्ही लवकरच मार्गावर परत येऊ शकता. त्रुटी आल्यास, येथे सुरुवात करा: खालील टिप्स बहुतेक वापरकर्त्यांच्या समस्या सोडवतात आणि तुमची अडचण सोडवू शकतात.

### सामान्य समस्या

खाली काही सर्वसामान्य समस्या आणि त्यांचे स्पष्ट स्पष्टीकरणे आणि निराकरण पद्धती दिल्या आहेत:

1. **.env फाइलमध्ये SERPAPI_KEY नाही**
   - जर तुम्हाला त्रुटी दिसली `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` फाइल तयार करा. तुमचा की बरोबर आहे पण त्रुटी येत असेल तर तपासा की तुमच्या मोफत स्तराचा कोटा संपला नाहीये का.

### डीबग मोड

मुळात, अॅप फक्त महत्त्वाची माहिती लॉग करतो. जर तुम्हाला काय चालले आहे याचे अधिक तपशील पाहायचे असतील (उदाहरणार्थ, कठीण समस्या शोधण्यासाठी), तर तुम्ही DEBUG मोड सक्षम करू शकता. यामुळे अॅप प्रत्येक टप्प्यावर काय करत आहे याची अधिक माहिती दाखवेल.

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

लक्षात ठेवा की DEBUG मोड HTTP विनंत्या, प्रतिसाद आणि इतर अंतर्गत तपशील याबद्दल अतिरिक्त ओळी दाखवतो. हे समस्या शोधण्यासाठी फार उपयुक्त ठरू शकते.

DEBUG मोड सक्षम करण्यासाठी, `client.py` or `server.py` च्या वर लॉगिंग स्तर DEBUG वर सेट करा:

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
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात ठेवा की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या मूळ भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद शिफारसीय आहे. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.