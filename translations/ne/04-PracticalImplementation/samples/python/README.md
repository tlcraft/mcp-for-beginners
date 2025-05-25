<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:29:28+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "ne"
}
-->
# Model Context Protocol (MCP) Python कार्यान्वयन

यो रिपोजिटरीमा Model Context Protocol (MCP) को Python कार्यान्वयन समावेश छ, जसले कसरी MCP मापदण्ड प्रयोग गरेर सर्भर र क्लाइन्ट एप्लिकेशन दुवै बनाउन सकिन्छ भनेर देखाउँछ।

## अवलोकन

MCP कार्यान्वयन दुई मुख्य भागहरूबाट बनेको छ:

1. **MCP Server (`server.py`)** - एउटा सर्भर जसले प्रदान गर्छ:
   - **Tools**: दूरबाट कल गर्न सकिने कार्यहरू
   - **Resources**: प्राप्त गर्न सकिने डेटा
   - **Prompts**: भाषा मोडेलका लागि प्रॉम्प्ट बनाउने टेम्प्लेटहरू

2. **MCP Client (`client.py`)** - सर्भरमा जडान भएर यसको सुविधाहरू प्रयोग गर्ने क्लाइन्ट एप्लिकेशन

## सुविधाहरू

यस कार्यान्वयनले MCP का मुख्य सुविधाहरू देखाउँछ:

### Tools
- `completion` - AI मोडेलबाट टेक्स्ट पूरा गर्ने (नक्कली रूपमा)
- `add` - दुई संख्याको जोड गर्ने साधारण क्यालकुलेटर

### Resources
- `models://` - उपलब्ध AI मोडेलहरूको जानकारी फर्काउँछ
- `greeting://{name}` - दिइएको नामका लागि व्यक्तिगत अभिवादन फर्काउँछ

### Prompts
- `review_code` - कोड समीक्षा गर्ने प्रॉम्प्ट बनाउँछ

## स्थापना

यस MCP कार्यान्वयन प्रयोग गर्न, आवश्यक प्याकेजहरू इन्स्टल गर्नुहोस्:

```powershell
pip install mcp-server mcp-client
```

## सर्भर र क्लाइन्ट चलाउने तरिका

### सर्भर सुरु गर्ने

एउटा टर्मिनल विन्डोमा सर्भर चलाउनुहोस्:

```powershell
python server.py
```

सर्भर विकास मोडमा MCP CLI प्रयोग गरेर पनि चलाउन सकिन्छ:

```powershell
mcp dev server.py
```

वा Claude Desktop मा इन्स्टल गरेर (यदि उपलब्ध छ भने):

```powershell
mcp install server.py
```

### क्लाइन्ट चलाउने

अर्को टर्मिनल विन्डोमा क्लाइन्ट चलाउनुहोस्:

```powershell
python client.py
```

यसले सर्भरमा जडान गरी सबै उपलब्ध सुविधाहरू देखाउनेछ।

### क्लाइन्ट प्रयोग

क्लाइन्ट (`client.py`) ले MCP का सबै क्षमता देखाउँछ:

```powershell
python client.py
```

यसले सर्भरमा जडान गरी टुल्स, रिसोर्सेस र प्रॉम्प्टहरू सबै प्रयोग गर्नेछ। आउटपुटमा देखिनेछ:

1. क्यालकुलेटर टुलको परिणाम (5 + 7 = 12)
2. "What is the meaning of life?" को लागि कम्प्लेशन टुलको प्रतिक्रिया
3. उपलब्ध AI मोडेलहरूको सूची
4. "MCP Explorer" का लागि व्यक्तिगत अभिवादन
5. कोड समीक्षा प्रॉम्प्ट टेम्प्लेट

## कार्यान्वयन विवरण

सर्भर `FastMCP` API प्रयोग गरेर बनाइएको छ, जसले MCP सेवा परिभाषित गर्न उच्च स्तरका एब्स्ट्र्याक्सनहरू प्रदान गर्छ। यहाँ टुल्स कसरी परिभाषित गरिन्छ भन्ने सरल उदाहरण छ:

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

क्लाइन्ट MCP क्लाइन्ट लाइब्रेरी प्रयोग गरेर सर्भरमा जडान र कल गर्छ:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## थप जान्न

MCP सम्बन्धी थप जानकारीको लागि हेर्नुहोस्: https://modelcontextprotocol.io/

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा असंगतिहरू हुन सक्छन्। मूल दस्तावेज यसको मूल भाषामा नै आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।