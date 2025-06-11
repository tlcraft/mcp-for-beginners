<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T15:19:09+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ne"
}
-->
# Lesson: वेब सर्च MCP सर्वर बनाउने

यस अध्यायले देखाउँछ कसरी वास्तविक-विश्वको AI एजेन्ट बनाउने जुन बाह्य API हरूसँग जोडिन्छ, विविध डेटा प्रकारहरू ह्यान्डल गर्छ, त्रुटिहरू व्यवस्थापन गर्छ, र धेरै उपकरणहरू समन्वय गर्छ—सबै उत्पादन-तयार ढाँचामा। तपाईंले देख्नुहुनेछ:

- **प्रमाणीकरण आवश्यक पर्ने बाह्य API हरूसँग एकीकरण**
- **धेरै एन्डपोइन्टबाट विविध डेटा प्रकारहरू ह्यान्डल गर्ने**
- **दृढ त्रुटि व्यवस्थापन र लगिङ रणनीतिहरू**
- **एकै सर्वरमा बहु-उपकरण समन्वय**

अन्त्यसम्म, तपाईंले उन्नत AI र LLM-समर्थित अनुप्रयोगहरूका लागि आवश्यक प्याटर्न र उत्तम अभ्यासहरूमा व्यावहारिक अनुभव पाउनुहुनेछ।

## परिचय

यस पाठमा, तपाईंले SerpAPI प्रयोग गरेर वास्तविक-समय वेब डाटासँग LLM क्षमताहरू विस्तार गर्ने उन्नत MCP सर्वर र क्लाइन्ट कसरी बनाउने भन्ने सिक्नुहुनेछ। यो गतिशील AI एजेन्ट विकासका लागि अत्यावश्यक कौशल हो जसले वेबबाट अद्यावधिक जानकारी पहुँच गर्न सक्छ।

## सिकाइ लक्ष्यहरू

यस पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:

- MCP सर्वरमा बाह्य API हरू (जस्तै SerpAPI) सुरक्षित रूपमा एकीकृत गर्न
- वेब, समाचार, उत्पादन खोज, र प्रश्नोत्तरका लागि धेरै उपकरणहरू कार्यान्वयन गर्न
- संरचित डेटा LLM उपभोगका लागि पार्स र फर्म्याट गर्न
- त्रुटिहरू ह्यान्डल गर्न र API दर सीमाहरू प्रभावकारी रूपमा व्यवस्थापन गर्न
- स्वचालित र अन्तरक्रियात्मक दुबै MCP क्लाइन्ट निर्माण र परीक्षण गर्न

## वेब सर्च MCP सर्वर

यस खण्डले वेब सर्च MCP सर्वरको वास्तुकला र सुविधाहरू प्रस्तुत गर्दछ। तपाईंले FastMCP र SerpAPI कसरी सँगै प्रयोग गरिन्छ भनेर देख्नुहुनेछ जसले LLM क्षमताहरूलाई वास्तविक-समय वेब डाटासँग विस्तार गर्छ।

### अवलोकन

यस कार्यान्वयनमा चार उपकरणहरू छन् जसले MCP को विविध, बाह्य API-चालित कार्यहरूलाई सुरक्षित र प्रभावकारी रूपमा ह्यान्डल गर्ने क्षमता देखाउँछन्:

- **general_search**: व्यापक वेब परिणामहरूको लागि
- **news_search**: हालैका समाचार शीर्षकहरूको लागि
- **product_search**: ई-कमर्स डेटा को लागि
- **qna**: प्रश्नोत्तर अंशहरूको लागि

### सुविधाहरू
- **कोड उदाहरणहरू**: Python का लागि भाषा-विशिष्ट कोड ब्लकहरू समावेश, अन्य भाषामा सजिलै विस्तार गर्न सकिने, स्पष्टताको लागि collapsible सेक्सनहरू प्रयोग गरी

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

क्लाइन्ट चलाउनु अघि, सर्वरले के गर्छ भनेर बुझ्न उपयोगी हुन्छ। [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) मा हेर्न सक्नुहुन्छ।

यहाँ एउटा छोटो उदाहरण छ जसले देखाउँछ सर्वरले कसरी उपकरण परिभाषित र दर्ता गर्छ:

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
- **संरचित डेटा पार्सिङ**: API प्रतिक्रियालाई LLM-मैत्री ढाँचामा परिवर्तन गर्ने तरिका देखाउँछ
- **त्रुटि व्यवस्थापन**: उचित लगिङ सहित दृढ त्रुटि ह्यान्डलिङ
- **अन्तरक्रियात्मक क्लाइन्ट**: स्वचालित परीक्षण र परीक्षणका लागि अन्तरक्रियात्मक मोड दुवै समावेश
- **सन्दर्भ व्यवस्थापन**: अनुरोधहरूको लगिङ र ट्र्याकिङका लागि MCP Context प्रयोग

## पूर्वापेक्षाहरू

सुरु गर्नु अघि, सुनिश्चित गर्नुहोस् कि तपाईंको वातावरण सही रूपमा सेटअप गरिएको छ। यसले सबै निर्भरताहरू इन्स्टल गरिएको र तपाईंका API कुञ्जीहरू ठीकसँग कन्फिगर गरिएको सुनिश्चित गर्दछ ताकि विकास र परीक्षण सहज होस्।

- Python 3.8 वा माथि
- SerpAPI API कुञ्जी (साइन अप गर्न [SerpAPI](https://serpapi.com/) मा जानुहोस् - निःशुल्क टियर उपलब्ध)

## स्थापना

शुरु गर्न, तपाईंको वातावरण सेटअप गर्न तलका कदमहरू पालना गर्नुहोस्:

1. uv (सिफारिस गरिएको) वा pip प्रयोग गरी निर्भरताहरू इन्स्टल गर्नुहोस्:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. प्रोजेक्ट रूटमा `.env` फाइल बनाउनुहोस् र आफ्नो SerpAPI कुञ्जी राख्नुहोस्:

```
SERPAPI_KEY=your_serpapi_key_here
```

## प्रयोग

वेब सर्च MCP सर्वर मुख्य कम्पोनेन्ट हो जसले वेब, समाचार, उत्पादन खोज, र प्रश्नोत्तरका लागि उपकरणहरू प्रदान गर्दछ र SerpAPI सँग एकीकृत हुन्छ। यसले आउने अनुरोधहरू ह्यान्डल गर्छ, API कलहरू व्यवस्थापन गर्छ, प्रतिक्रिया पार्स गर्छ, र क्लाइन्टलाई संरचित परिणामहरू फिर्ता गर्छ।

पूर्ण कार्यान्वयन [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) मा हेर्न सक्नुहुन्छ।

### सर्वर चलाउने

MCP सर्वर सुरु गर्न तलको कमाण्ड प्रयोग गर्नुहोस्:

```bash
python server.py
```

सर्वर stdio-आधारित MCP सर्वरको रूपमा चल्नेछ जसमा क्लाइन्ट सिधै जडान हुन सक्छ।

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

सर्भरले प्रदान गर्ने उपकरणहरूलाई तपाईंको आवश्यकताअनुसार र कार्यप्रवाहअनुसार परीक्षण र अन्तरक्रिया गर्ने विभिन्न तरिकाहरू छन्।

#### MCP Python SDK प्रयोग गरी कस्टम टेस्ट स्क्रिप्ट लेख्ने
तपाईं आफ्नो टेस्ट स्क्रिप्टहरू MCP Python SDK प्रयोग गरेर पनि बनाउन सक्नुहुन्छ:

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

यस सन्दर्भमा, "टेस्ट स्क्रिप्ट" भनेको तपाईंले लेख्नुभएको एउटा कस्टम Python प्रोग्राम हो जुन MCP सर्वरको क्लाइन्टको रूपमा काम गर्छ। यो औपचारिक युनिट टेस्ट होइन, तर यसले तपाईंलाई प्रोग्रामेटिक रूपमा सर्वरमा जडान गर्न, कुनै पनि उपकरणलाई तपाईंले छनोट गरेको प्यारामिटरहरूसँग कल गर्न, र परिणामहरू निरीक्षण गर्न दिन्छ। यो तरिका उपयोगी छ:

- उपकरण कलहरू प्रोटोटाइप र परीक्षण गर्न
- सर्वरले विभिन्न इनपुटहरूमा कसरी प्रतिक्रिया दिन्छ भनी मान्य गर्न
- उपकरणहरूलाई बारम्बार कल गर्ने प्रक्रिया स्वचालित गर्न
- MCP सर्वर माथि आफ्नै कार्यप्रवाह वा एकीकरण निर्माण गर्न

तपाईंले नयाँ क्वेरीहरू छिटो परीक्षण गर्न, उपकरण व्यवहार डिबग गर्न, वा उन्नत स्वचालनको सुरुवातको रूपमा टेस्ट स्क्रिप्ट प्रयोग गर्न सक्नुहुन्छ। तल MCP Python SDK कसरी प्रयोग गर्ने उदाहरण छ:

## उपकरण विवरणहरू

सर्भरले प्रदान गर्ने निम्न उपकरणहरू प्रयोग गरेर विभिन्न प्रकारका खोज र प्रश्नहरू गर्न सक्नुहुन्छ। प्रत्येक उपकरणका प्यारामिटरहरू र प्रयोगको उदाहरण तल दिइएको छ।

यस खण्डले उपलब्ध प्रत्येक उपकरण र तिनका प्यारामिटरहरूको विवरण दिन्छ।

### general_search

सामान्य वेब खोज गर्छ र फर्म्याट गरिएको परिणामहरू फिर्ता गर्छ।

**यस उपकरणलाई कसरी कल गर्ने:**

तपाईं `general_search` लाई आफ्नो स्क्रिप्टबाट MCP Python SDK प्रयोग गरेर कल गर्न सक्नुहुन्छ, वा Inspector वा अन्तरक्रियात्मक क्लाइन्ट मोड प्रयोग गरेर अन्तरक्रियात्मक रूपमा। यहाँ SDK प्रयोग गरी कोड उदाहरण छ:

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

वा अन्तरक्रियात्मक मोडमा, `general_search` from the menu and enter your query when prompted.

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

तपाईं `news_search` लाई आफ्नो स्क्रिप्टबाट MCP Python SDK प्रयोग गरेर कल गर्न सक्नुहुन्छ, वा Inspector वा अन्तरक्रियात्मक क्लाइन्ट मोड प्रयोग गरेर अन्तरक्रियात्मक रूपमा। यहाँ SDK प्रयोग गरी कोड उदाहरण छ:

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

वा अन्तरक्रियात्मक मोडमा, `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): खोज प्रश्न चयन गर्नुहोस्

**उदाहरण अनुरोध:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

प्रश्नसँग मेल खाने उत्पादनहरू खोज्छ।

**यस उपकरणलाई कसरी कल गर्ने:**

तपाईं `product_search` लाई आफ्नो स्क्रिप्टबाट MCP Python SDK प्रयोग गरेर कल गर्न सक्नुहुन्छ, वा Inspector वा अन्तरक्रियात्मक क्लाइन्ट मोड प्रयोग गरेर अन्तरक्रियात्मक रूपमा। यहाँ SDK प्रयोग गरी कोड उदाहरण छ:

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

वा अन्तरक्रियात्मक मोडमा, `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): उत्पादन खोज प्रश्न चयन गर्नुहोस्

**उदाहरण अनुरोध:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

खोज इन्जिनहरूबाट सोधिएको प्रश्नहरूको प्रत्यक्ष उत्तर प्राप्त गर्छ।

**यस उपकरणलाई कसरी कल गर्ने:**

तपाईं `qna` लाई आफ्नो स्क्रिप्टबाट MCP Python SDK प्रयोग गरेर कल गर्न सक्नुहुन्छ, वा Inspector वा अन्तरक्रियात्मक क्लाइन्ट मोड प्रयोग गरेर अन्तरक्रियात्मक रूपमा। यहाँ SDK प्रयोग गरी कोड उदाहरण छ:

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

वा अन्तरक्रियात्मक मोडमा, `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): उत्तर खोज्न प्रश्न चयन गर्नुहोस्

**उदाहरण अनुरोध:**

```json
{
  "question": "what is artificial intelligence"
}
```

## कोड विवरण

यस खण्डले सर्वर र क्लाइन्ट कार्यान्वयनका लागि कोड स्निपेटहरू र सन्दर्भहरू प्रदान गर्दछ।

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

निर्माण सुरु गर्नु अघि, यहाँ केही महत्त्वपूर्ण उन्नत अवधारणाहरू छन् जुन यस अध्यायभर देखिनेछन्। यी बुझ्नाले तपाईंलाई सजिलैसँग साथ दिन मद्दत गर्नेछ, यदि तपाईं नयाँ हुनुहुन्छ भने पनि:

- **बहु-उपकरण समन्वय**: यसको अर्थ हो एकै MCP सर्वरमा विभिन्न उपकरणहरू (जस्तै वेब सर्च, समाचार सर्च, उत्पादन सर्च, र Q&A) चलाउनु। यसले तपाईंको सर्वरलाई एक भन्दा बढी कार्यहरू ह्यान्डल गर्न सक्षम बनाउँछ।
- **API दर सीमा व्यवस्थापन**: धेरै बाह्य API हरू (जस्तै SerpAPI) निश्चित समयमा कति अनुरोध गर्न सकिन्छ भनेर सीमा लगाउँछन्। राम्रो कोडले यी सीमाहरू जाँच्छ र सुचारु रूपमा ह्यान्डल गर्छ, ताकि तपाईंको एप्लिकेशन सीमा पुगे पनि बिग्रिंदैन।
- **संरचित डेटा पार्सिङ**: API प्रतिक्रियाहरू प्रायः जटिल र नेस्टेड हुन्छन्। यो अवधारणा ती प्रतिक्रियाहरूलाई सफा, प्रयोग गर्न सजिलो ढाँचामा परिणत गर्ने बारे हो जुन LLM वा अन्य प्रोग्रामहरूका लागि मैत्री हुन्छ।
- **त्रुटि पुनर्प्राप्ति**: कहिलेकाहीं समस्या आउँछ—साइतमा नेटवर्क समस्या हुन सक्छ, वा API ले अपेक्षित डेटा नदिन सक्छ। त्रुटि पुनर्प्राप्ति भनेको तपाईंको कोडले यी समस्याहरू ह्यान्डल गर्न सक्नु र उपयोगी प्रतिक्रिया दिन सक्नु हो, क्र्यास नगरी।
- **प्यारामिटर प्रमाणीकरण**: यो उपकरणहरूमा पठाइएका सबै इनपुटहरू सही र सुरक्षित छन् कि छैनन् भनेर जाँच्ने बारे हो। यसमा पूर्वनिर्धारित मान सेट गर्ने र प्रकारहरू मिलाउने समावेश छ, जसले बग र भ्रम कम गर्छ।

यस खण्डले तपाईंलाई वेब सर्च MCP सर्वरसँग काम गर्दा देखिने सामान्य समस्याहरू पत्ता लगाउन र समाधान गर्न मद्दत गर्नेछ। यदि तपाईंले त्रुटि वा अप्रत्याशित व्यवहार देख्नुभयो भने, यो समस्या समाधान खण्डले प्रायः समस्या छिटो समाधान गर्ने उपायहरू दिन्छ। थप सहयोग खोज्नु अघि यी सुझावहरू अवश्य हेर्नुहोस्।

## समस्या समाधान

वेब सर्च MCP सर्वरसँग काम गर्दा कहिलेकाहीं समस्या आउन सक्छ—यो बाह्य API र नयाँ उपकरणहरूसँग विकास गर्दा सामान्य हो। यस खण्डले सबैभन्दा सामान्य समस्याहरूका व्यावहारिक समाधानहरू प्रदान गर्दछ, ताकि तपाईं छिटो काममा फर्कन सक्नुहोस्। यदि तपाईंले त्रुटि पाउनुभयो भने, यहाँबाट सुरु गर्नुहोस्: तलका सुझावहरूले प्रायः प्रयोगकर्ताहरूले भोगेका समस्याहरू सम्बोधन गर्छन् र तपाईंको समस्या बिना थप सहयोग समाधान हुन सक्छ।

### सामान्य समस्याहरू

तल केही सबैभन्दा सामान्य समस्याहरू छन् जुन प्रयोगकर्ताहरूले सामना गर्छन्, स्पष्ट व्याख्या र समाधान कदमहरूसहित:

1. **.env फाइलमा SERPAPI_KEY हराइरहेको छ**
   - यदि तपाईंले `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` त्रुटि देख्नु भयो भने, आवश्यक भए `.env` फाइल बनाएर आफ्नो सही कुञ्जी राख्नुहोस्। यदि तपाईंको कुञ्जी सही छ तर त्रुटि आउँछ भने, तपाईंको निःशुल्क टियरको कोटा सकिएको छ कि छैन जाँच गर्नुहोस्।

### डिबग मोड

पूर्वनिर्धारित रूपमा, एपले मात्र महत्त्वपूर्ण जानकारी लग गर्छ। यदि तपाईंले के हुँदैछ भन्ने विस्तृत जानकारी हेर्न चाहनुहुन्छ (जस्तै जटिल समस्याहरू पत्ता लगाउन), तपाईं DEBUG मोड सक्षम गर्न सक्नुहुन्छ। यसले एपले लिइरहेका प्रत्येक कदमको धेरै विस्तृत विवरण देखाउनेछ।

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

ध्यान दिनुहोस् DEBUG मोडले HTTP अनुरोध, प्रतिक्रिया, र अन्य आन्तरिक विवरणहरू समावेश गर्दछ। यो समस्या समाधानका लागि धेरै उपयोगी हुन सक्छ।

DEBUG मोड सक्षम गर्न, `client.py` or `server.py` को माथिल्लो भागमा लगिङ स्तर DEBUG मा सेट गर्नुहोस्:

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

- [5.10 वास्तविक समय स्ट्रिमिङ](../mcp-realtimestreaming/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया बुझ्नुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।