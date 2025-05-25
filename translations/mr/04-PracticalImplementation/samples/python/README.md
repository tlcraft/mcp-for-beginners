<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:29:17+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "mr"
}
-->
# Model Context Protocol (MCP) Python अंमलबजावणी

हा रिपॉझिटरी Model Context Protocol (MCP) ची Python अंमलबजावणी समाविष्ट करतो, ज्यात दाखवले आहे की कसे सर्व्हर आणि क्लायंट अ‍ॅप्लिकेशन तयार करायचे जे MCP स्टँडर्ड वापरून संवाद साधतात.

## आढावा

MCP अंमलबजावणीमध्ये दोन मुख्य घटक आहेत:

1. **MCP Server (`server.py`)** - एक सर्व्हर जो खालील गोष्टी प्रदान करतो:
   - **Tools**: अशा फंक्शन्स जे रिमोटली कॉल केले जाऊ शकतात
   - **Resources**: डेटा जो मिळवता येतो
   - **Prompts**: भाषा मॉडेलसाठी प्रॉम्प्ट तयार करण्यासाठी टेम्पलेट्स

2. **MCP Client (`client.py`)** - एक क्लायंट अ‍ॅप्लिकेशन जे सर्व्हरशी कनेक्ट होते आणि त्याच्या फिचर्स वापरते

## वैशिष्ट्ये

ही अंमलबजावणी MCP चे काही महत्त्वाचे फिचर्स दाखवते:

### Tools
- `completion` - AI मॉडेल्स कडून टेक्स्ट पूर्णता निर्माण करते (सिम्युलेटेड)
- `add` - दोन नंबर जोडणारा साधा कॅल्क्युलेटर

### Resources
- `models://` - उपलब्ध AI मॉडेल्सची माहिती परत करते
- `greeting://{name}` - दिलेल्या नावासाठी वैयक्तिकृत अभिवादन परत करते

### Prompts
- `review_code` - कोड रिव्ह्यूसाठी प्रॉम्प्ट तयार करते

## इंस्टॉलेशन

हा MCP अंमलबजावणी वापरण्यासाठी आवश्यक पॅकेजेस इंस्टॉल करा:

```powershell
pip install mcp-server mcp-client
```

## सर्व्हर आणि क्लायंट चालविणे

### सर्व्हर सुरू करणे

सर्व्हर एका टर्मिनल विंडोमध्ये चालवा:

```powershell
python server.py
```

सर्व्हर विकास मोडमध्ये MCP CLI वापरून देखील चालवता येतो:

```powershell
mcp dev server.py
```

किंवा Claude Desktop मध्ये इंस्टॉल करा (जर उपलब्ध असेल तर):

```powershell
mcp install server.py
```

### क्लायंट चालविणे

दुसऱ्या टर्मिनल विंडोमध्ये क्लायंट चालवा:

```powershell
python client.py
```

हे सर्व्हरशी कनेक्ट होईल आणि उपलब्ध असलेले सर्व फिचर्स दाखवेल.

### क्लायंट वापर

क्लायंट (`client.py`) MCP च्या सर्व क्षमतांचे प्रदर्शन करतो:

```powershell
python client.py
```

हे सर्व्हरशी कनेक्ट होईल आणि टूल्स, रिसोर्सेस आणि प्रॉम्प्टसह सर्व फिचर्स वापरेल. आउटपुटमध्ये दिसेल:

1. कॅल्क्युलेटर टूलचा निकाल (5 + 7 = 12)
2. "What is the meaning of life?" या प्रश्नावर Completion टूलचा प्रतिसाद
3. उपलब्ध AI मॉडेल्सची यादी
4. "MCP Explorer" साठी वैयक्तिकृत अभिवादन
5. कोड रिव्ह्यू प्रॉम्प्ट टेम्पलेट

## अंमलबजावणी तपशील

सर्व्हर `FastMCP` API वापरून तयार केला आहे, जो MCP सेवा परिभाषित करण्यासाठी उच्च-स्तरीय अब्स्ट्रॅक्शन्स प्रदान करतो. खाली टूल्स कसे परिभाषित करतात याचा सोपा उदाहरण आहे:

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

क्लायंट MCP क्लायंट लायब्ररी वापरून सर्व्हरशी कनेक्ट होतो आणि कॉल करतो:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## अधिक जाणून घ्या

MCP बद्दल अधिक माहितीसाठी भेट द्या: https://modelcontextprotocol.io/

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या मूळ भाषेत अधिकृत स्रोत मानला पाहिजे. महत्त्वाची माहिती असल्यास, व्यावसायिक मानवी अनुवाद करण्याचा सल्ला दिला जातो. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुतींसाठी आम्ही जबाबदार नाही.