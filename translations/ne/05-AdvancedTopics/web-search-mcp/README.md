<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T18:49:18+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ne"
}
-->
# Lesson: वेब सर्च MCP सर्वर बनाउने

यस अध्यायले देखाउँछ कसरी वास्तविक विश्वको AI एजेन्ट बनाउने जुन बाह्य API हरूसँग जोडिन्छ, विभिन्न डेटा प्रकारहरूलाई सम्हाल्छ, त्रुटिहरू व्यवस्थापन गर्छ, र धेरै उपकरणहरूलाई एकैसाथ सञ्चालन गर्छ—सबै उत्पादन-तयार स्वरूपमा। तपाईंले देख्नुहुनेछ:

- **प्रमाणीकरण आवश्यक पर्ने बाह्य API हरूसँग एकीकरण**
- **धेरै endpoints बाट विभिन्न डेटा प्रकारहरूलाई सम्हाल्ने**
- **दृढ त्रुटि व्यवस्थापन र लगिङ रणनीतिहरू**
- **एकै सर्वरमा बहु-उपकरण सञ्चालन**

अन्त्यसम्म, तपाईंले उन्नत AI र LLM-शक्तियुक्त अनुप्रयोगहरूका लागि आवश्यक ढाँचाहरू र उत्कृष्ट अभ्यासहरूमा व्यावहारिक अनुभव पाउनुहुनेछ।

## परिचय

यस पाठमा, तपाईंले सिक्नुहुनेछ कसरी एक उन्नत MCP सर्वर र क्लाइन्ट बनाउने जसले SerpAPI प्रयोग गरी वास्तविक-समय वेब डाटासँग LLM क्षमताहरू विस्तार गर्छ। यो वेबबाट अद्यावधिक जानकारी पहुँच गर्न सक्ने गतिशील AI एजेन्टहरू विकास गर्न महत्वपूर्ण कौशल हो।

## सिकाइ उद्देश्यहरू

यस पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:

- MCP सर्वरमा सुरक्षित रूपमा बाह्य API हरू (जस्तै SerpAPI) एकीकृत गर्न
- वेब, समाचार, उत्पादन खोज, र Q&A का लागि बहु उपकरणहरू कार्यान्वयन गर्न
- LLM प्रयोगका लागि संरचित डेटा पार्स र फर्म्याट गर्न
- त्रुटिहरू सम्हाल्न र API दर सीमाहरू प्रभावकारी रूपमा व्यवस्थापन गर्न
- स्वचालित र अन्तरक्रियात्मक MCP क्लाइन्टहरू निर्माण र परीक्षण गर्न

## वेब सर्च MCP सर्वर

यस खण्डले वेब सर्च MCP सर्वरको वास्तुकला र सुविधाहरू प्रस्तुत गर्छ। तपाईंले देख्नुहुनेछ कसरी FastMCP र SerpAPI सँगै प्रयोग गरी वास्तविक-समय वेब डाटासँग LLM क्षमताहरू विस्तार गरिन्छ।

### अवलोकन

यस कार्यान्वयनमा चार उपकरणहरू छन् जसले MCP को विविध, बाह्य API-आधारित कार्यहरूलाई सुरक्षित र प्रभावकारी रूपमा सम्हाल्ने क्षमता देखाउँछन्:

- **general_search**: व्यापक वेब परिणामहरूको लागि
- **news_search**: हालैका शीर्षकहरूको लागि
- **product_search**: ई-कॉमर्स डेटा का लागि
- **qna**: प्रश्नोत्तर अंशहरूको लागि

### सुविधाहरू
- **कोड उदाहरणहरू**: Python का लागि भाषा-विशिष्ट कोड ब्लकहरू समावेश छन् (र सजिलै अन्य भाषामा विस्तार गर्न सकिन्छ) स्पष्टताको लागि collapsible सेक्सनहरू प्रयोग गरी

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

क्लाइन्ट चलाउनुअघि, सर्वरले के गर्छ बुझ्न उपयोगी हुन्छ। [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) हेर्नुहोस्।

यहाँ एउटा छोटो उदाहरण छ जसले देखाउँछ कसरी सर्वरले उपकरण परिभाषित र दर्ता गर्छ:

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

- **बाह्य API एकीकरण**: API कुञ्जी र बाह्य अनुरोधहरूको सुरक्षित ह्यान्डलिङ देखाउँछ
- **संरचित डेटा पार्सिङ**: API प्रतिक्रियाहरूलाई LLM-मैत्री ढाँचामा रूपान्तरण गर्ने तरिका देखाउँछ
- **त्रुटि व्यवस्थापन**: उपयुक्त लगिङसहित दृढ त्रुटि ह्यान्डलिङ
- **अन्तरक्रियात्मक क्लाइन्ट**: स्वचालित परीक्षणहरू र परीक्षणका लागि अन्तरक्रियात्मक मोड समावेश छ
- **सन्दर्भ व्यवस्थापन**: MCP Context प्रयोग गरी लगिङ र अनुरोध ट्र्याकिङ

## पूर्वआवश्यकताहरू

शुरू गर्नु अघि, आफ्नो वातावरण सही रूपमा सेटअप भएको सुनिश्चित गर्न तलका चरणहरू पालना गर्नुहोस्। यसले सबै निर्भरता इन्स्टल गर्न र API कुञ्जीहरू सही रूपमा कन्फिगर गर्न मद्दत गर्नेछ ताकि विकास र परीक्षण सहज होस्।

- Python 3.8 वा माथि
- SerpAPI API कुञ्जी (साइन अप गर्नुहोस् [SerpAPI](https://serpapi.com/) मा - निःशुल्क टियर उपलब्ध)

## इन्स्टलेसन

शुरू गर्न, आफ्नो वातावरण सेटअप गर्न तलका चरणहरू पालना गर्नुहोस्:

1. uv (सिफारिस गरिएको) वा pip प्रयोग गरी निर्भरता इन्स्टल गर्नुहोस्:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. परियोजना रुटमा `.env` फाइल बनाउनुहोस् र आफ्नो SerpAPI कुञ्जी राख्नुहोस्:

```
SERPAPI_KEY=your_serpapi_key_here
```

## प्रयोग

वेब सर्च MCP सर्वर मुख्य कम्पोनेन्ट हो जसले वेब, समाचार, उत्पादन खोज, र Q&A का लागि उपकरणहरू उपलब्ध गराउँछ SerpAPI सँग एकीकरण गरेर। यसले आउने अनुरोधहरू सम्हाल्छ, API कलहरू व्यवस्थापन गर्छ, प्रतिक्रियाहरू पार्स गर्छ, र संरचित परिणामहरू क्लाइन्टलाई फिर्ता गर्छ।

पूर्ण कार्यान्वयन [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) मा हेर्न सकिन्छ।

### सर्वर चलाउने

MCP सर्वर सुरु गर्न, तलको कमाण्ड प्रयोग गर्नुहोस्:

```bash
python server.py
```

सर्वर stdio-आधारित MCP सर्वरको रूपमा चल्नेछ जुन क्लाइन्टले सिधै जडान गर्न सक्छ।

### क्लाइन्ट मोडहरू

क्लाइन्ट (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)।

### क्लाइन्ट चलाउने

स्वचालित परीक्षणहरू चलाउन (यसले स्वचालित रूपमा सर्वर सुरु गर्नेछ):

```bash
python client.py
```

वा अन्तरक्रियात्मक मोडमा चलाउन:

```bash
python client.py --interactive
```

### विभिन्न तरिकाले परीक्षण गर्ने

सर्भरले उपलब्ध गराएका उपकरणहरूलाई परीक्षण र अन्तरक्रिया गर्न धेरै तरिकाहरू छन्, तपाईंको आवश्यकताअनुसार।

#### MCP Python SDK सँग कस्टम टेस्ट स्क्रिप्ट लेख्ने
तपाईंले आफ्नो कस्टम टेस्ट स्क्रिप्ट पनि बनाउन सक्नुहुन्छ MCP Python SDK प्रयोग गरेर:

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

यस सन्दर्भमा, "टेस्ट स्क्रिप्ट" भन्नाले तपाईंले लेखेको कस्टम Python प्रोग्राम हो जुन MCP सर्वरको क्लाइन्टको रूपमा काम गर्छ। यो औपचारिक युनिट टेस्ट नभएर तपाईंलाई प्रोग्रामेटिक रूपमा सर्वरमा जडान गर्न, यसको कुनै पनि उपकरणलाई मनपरेका प्यारामिटरहरूसँग कल गर्न, र नतिजाहरू जाँच गर्न अनुमति दिन्छ। यो तरिका उपयोगी छ:

- उपकरण कलहरूको प्रोटोटाइप र प्रयोग गर्न
- सर्वरले विभिन्न इनपुटहरूमा कसरी प्रतिक्रिया दिन्छ भनी मान्य गर्न
- पुनः दोहोरिने उपकरण कलहरू स्वचालित गर्न
- MCP सर्वरमाथि आफ्नै कार्यप्रवाह वा एकीकरण निर्माण गर्न

टेस्ट स्क्रिप्टहरूलाई नयाँ प्रश्नहरू छिटो प्रयास गर्न, उपकरण व्यवहार डिबग गर्न, वा उन्नत स्वचालनको सुरुवातको रूपमा पनि प्रयोग गर्न सकिन्छ। तल MCP Python SDK प्रयोग गरी यस्तो स्क्रिप्ट कसरी बनाउने भन्ने उदाहरण छ:

## उपकरण विवरणहरू

तपाईंले सर्वरले उपलब्ध गराएका निम्न उपकरणहरू प्रयोग गरेर विभिन्न प्रकारका खोज र प्रश्नहरू गर्न सक्नुहुन्छ। प्रत्येक उपकरणको विवरण यसको प्यारामिटरहरू र उदाहरण प्रयोगसहित तल दिइएको छ।

यस खण्डले उपलब्ध प्रत्येक उपकरण र तिनीहरूको प्यारामिटरहरूको विवरण दिन्छ।

### general_search

सामान्य वेब खोज गर्छ र फर्म्याट गरिएको परिणाम फिर्ता गर्छ।

**यस उपकरणलाई कसरी कल गर्ने:**

तपाईं `general_search` लाई आफ्नो स्क्रिप्टबाट MCP Python SDK प्रयोग गरी कल गर्न सक्नुहुन्छ, वा Inspector वा अन्तरक्रियात्मक क्लाइन्ट मोड प्रयोग गरी अन्तरक्रियात्मक रूपमा। यहाँ SDK प्रयोग गरी कोड उदाहरण छ:

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

अथवा अन्तरक्रियात्मक मोडमा, `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): खोज प्रश्न चयन गर्नुहोस्

**उदाहरण अनुरोध:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

कुनै प्रश्नसँग सम्बन्धित हालैका समाचार लेखहरू खोज्छ।

**यस उपकरणलाई कसरी कल गर्ने:**

तपाईं `news_search` लाई आफ्नो स्क्रिप्टबाट MCP Python SDK प्रयोग गरी कल गर्न सक्नुहुन्छ, वा Inspector वा अन्तरक्रियात्मक क्लाइन्ट मोड प्रयोग गरी अन्तरक्रियात्मक रूपमा। यहाँ SDK प्रयोग गरी कोड उदाहरण छ:

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

अथवा अन्तरक्रियात्मक मोडमा, `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): खोज प्रश्न चयन गर्नुहोस्

**उदाहरण अनुरोध:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

कुनै प्रश्नसँग मेल खाने उत्पादनहरू खोज्छ।

**यस उपकरणलाई कसरी कल गर्ने:**

तपाईं `product_search` लाई आफ्नो स्क्रिप्टबाट MCP Python SDK प्रयोग गरी कल गर्न सक्नुहुन्छ, वा Inspector वा अन्तरक्रियात्मक क्लाइन्ट मोड प्रयोग गरी अन्तरक्रियात्मक रूपमा। यहाँ SDK प्रयोग गरी कोड उदाहरण छ:

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

अथवा अन्तरक्रियात्मक मोडमा, `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): उत्पादन खोज प्रश्न चयन गर्नुहोस्

**उदाहरण अनुरोध:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

खोज इन्जिनहरूबाट सोधिएका प्रश्नहरूको प्रत्यक्ष उत्तरहरू ल्याउँछ।

**यस उपकरणलाई कसरी कल गर्ने:**

तपाईं `qna` लाई आफ्नो स्क्रिप्टबाट MCP Python SDK प्रयोग गरी कल गर्न सक्नुहुन्छ, वा Inspector वा अन्तरक्रियात्मक क्लाइन्ट मोड प्रयोग गरी अन्तरक्रियात्मक रूपमा। यहाँ SDK प्रयोग गरी कोड उदाहरण छ:

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

अथवा अन्तरक्रियात्मक मोडमा, `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): उत्तर खोज्न प्रश्न चयन गर्नुहोस्

**उदाहरण अनुरोध:**

```json
{
  "question": "what is artificial intelligence"
}
```

## कोड विवरणहरू

यस खण्डले सर्वर र क्लाइन्ट कार्यान्वयनका लागि कोड स्निपेटहरू र सन्दर्भहरू प्रदान गर्छ।

<details>
<summary>Python</summary>

पूर्ण कार्यान्वयन विवरणहरूका लागि [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) हेर्नुहोस्।

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## यस पाठका उन्नत अवधारणाहरू

निर्माण सुरु गर्नु अघि, यहाँ केही महत्वपूर्ण उन्नत अवधारणाहरू छन् जुन यस अध्यायभरि देखिनेछन्। यी बुझ्नाले तपाईंलाई सजिलैसँग पछ्याउन मद्दत गर्नेछ, चाहे तपाईं नयाँ हुनुहुन्छ भने पनि:

- **बहु-उपकरण सञ्चालन**: यसको अर्थ एकै MCP सर्वरमा धेरै विभिन्न उपकरणहरू (जस्तै वेब सर्च, समाचार सर्च, उत्पादन सर्च, र Q&A) चलाउनु हो। यसले तपाईंको सर्वरलाई विभिन्न कार्यहरू सम्हाल्न सक्षम बनाउँछ, एक मात्र होइन।
- **API दर सीमा व्यवस्थापन**: धेरै बाह्य API हरू (जस्तै SerpAPI) निश्चित समयमा कति अनुरोध गर्न सकिन्छ भनेर सीमित गर्छन्। राम्रो कोडले यी सीमाहरू जाँच्छ र सौम्य रूपमा ह्यान्डल गर्छ, जसले गर्दा तपाईंको एप टूट्दैन यदि तपाईं सीमा पार गर्नु भयो भने।
- **संरचित डेटा पार्सिङ**: API प्रतिक्रियाहरू प्रायः जटिल र नेस्टेड हुन्छन्। यो अवधारणा ती प्रतिक्रियाहरूलाई सफा, सजिलै प्रयोग गर्न मिल्ने ढाँचामा रूपान्तरण गर्ने बारे हो जुन LLM वा अन्य प्रोग्रामहरूका लागि मैत्री हुन्छ।
- **त्रुटि पुनःप्राप्ति**: कहिलेकाहीं समस्या आउँछ—सञ्जाल असफल हुन सक्छ, वा API ले अपेक्षा गरेजस्तो जवाफ नदिन सक्छ। त्रुटि पुनःप्राप्ति भनेको तपाईंको कोडले यी समस्याहरूलाई सम्हाल्न र उपयोगी प्रतिक्रिया दिन सक्ने हो, क्र्यास नगरी।
- **प्यारामिटर प्रमाणीकरण**: यसले तपाईंका उपकरणहरूमा आएका सबै इनपुटहरू सही र सुरक्षित छन् भनी जाँच गर्ने कुरा हो। यसमा पूर्वनिर्धारित मानहरू सेट गर्ने र प्रकारहरू मिलाउने समावेश छ, जसले बग र भ्रमबाट बचाउँछ।

यस खण्डले तपाईंलाई वेब सर्च MCP सर्वरसँग काम गर्दा आउने सामान्य समस्याहरू पहिचान र समाधान गर्न मद्दत गर्नेछ। यदि तपाईंले त्रुटि वा अनपेक्षित व्यवहार देख्नुभयो भने, यो समस्या समाधान खण्डले सबैभन्दा सामान्य समस्याहरूका समाधानहरू दिन्छ। थप सहयोग खोज्नुअघि यी सुझावहरू समीक्षा गर्नुहोस्—अक्सर यीले समस्या छिटो समाधान गर्छन्।

## समस्या समाधान

वेब सर्च MCP सर्वरसँग काम गर्दा कहिलेकाहीं समस्या आउन सक्छ—यो सामान्य हो जब तपाईं बाह्य API र नयाँ उपकरणहरूसँग विकास गर्दै हुनुहुन्छ। यस खण्डले सबैभन्दा सामान्य समस्याहरूका व्यावहारिक समाधानहरू प्रदान गर्छ, ताकि तपाईं छिटो काममा फर्कन सक्नुहोस्। यदि तपाईंले त्रुटि देख्नुभयो भने, यहाँबाट सुरु गर्नुहोस्: तलका सुझावहरूले धेरै प्रयोगकर्ताहरूले भोगेका समस्याहरू सम्बोधन गर्छन् र प्रायः तपाईंको समस्या बिना अतिरिक्त सहयोगको समाधान गर्छन्।

### सामान्य समस्या

तल केही सबैभन्दा सामान्य समस्याहरू र तिनीहरूको स्पष्ट व्याख्या र समाधानका चरणहरू छन्:

1. **.env फाइलमा SERPAPI_KEY हराएको छ**
   - यदि तपाईंले त्रुटि देख्नुभयो `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` फाइल आवश्यक परेमा बनाउनुहोस्। यदि तपाईंको कुञ्जी सही छ तर अझै त्रुटि देखिन्छ भने, जाँच गर्नुहोस् कि तपाईंको निःशुल्क टियरको कोटा सकिएको छैन।

### डिबग मोड

डिफल्ट रूपमा, एपले मात्र महत्वपूर्ण जानकारी लग गर्दछ। यदि तपाईं के भइरहेको छ भनी थप विवरण हेर्न चाहनुहुन्छ (जस्तै जटिल समस्याहरू पत्ता लगाउन), तपाईं DEBUG मोड सक्षम गर्न सक्नुहुन्छ। यसले प्रत्येक चरणमा एपले के गरिरहेको छ भनी धेरै विवरण देखाउनेछ।

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

ध्यान दिनुहोस् DEBUG मोडमा HTTP अनुरोधहरू, प्रतिक्रियाहरू, र अन्य आन्तरिक विवरणहरू समावेश छन्। यो समस्या समाधानमा धेरै उपयोगी हुन सक्छ।

DEBUG मोड सक्षम गर्न, `client.py` or `server.py` को शीर्षमा लगिङ स्तर DEBUG मा सेट गर्नुहोस्:

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

## अब के गर्ने

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) को प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताको प्रयास गर्छौं, तर कृपया जानकार हुनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धिहरू हुन सक्छन्। मूल दस्तावेज़ यसको मूल भाषामा आधिकारिक स्रोत मान्नुपर्छ। महत्वपूर्ण जानकारीको लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।