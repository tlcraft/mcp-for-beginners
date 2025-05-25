<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:41:49+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "ne"
}
-->
## परीक्षण र डिबगिङ

तपाईंको MCP सर्भर परीक्षण सुरु गर्नु अघि उपलब्ध उपकरणहरू र डिबगिङका लागि उत्तम अभ्यासहरू बुझ्न महत्त्वपूर्ण छ। प्रभावकारी परीक्षणले सुनिश्चित गर्छ कि तपाईंको सर्भर अपेक्षाकृत व्यवहार गर्छ र समस्याहरू चाँडै पहिचान गर्न र समाधान गर्न मद्दत गर्छ। निम्न खण्डमा तपाईंको MCP कार्यान्वयनलाई प्रमाणित गर्ने सिफारिस गरिएको दृष्टिकोणहरू उल्लेख गरिएको छ।

## परिचय

यो पाठले सही परीक्षण दृष्टिकोण चयन गर्ने र सबैभन्दा प्रभावकारी परीक्षण उपकरण कस्तो छ भनेर समेट्छ।

## सिकाइ उद्देश्यहरू

यो पाठको अन्त्यमा, तपाईं सक्षम हुनुहुनेछ:

- परीक्षणका लागि विभिन्न दृष्टिकोण वर्णन गर्नुहोस्।
- तपाईंको कोडलाई प्रभावकारी रूपमा परीक्षण गर्न विभिन्न उपकरणहरू प्रयोग गर्नुहोस्।

## MCP सर्भरहरूको परीक्षण

MCP ले तपाईंलाई सर्भरहरू परीक्षण र डिबग गर्न मद्दत गर्ने उपकरणहरू प्रदान गर्दछ:

- **MCP Inspector**: एक कमाण्ड लाइन उपकरण जुन CLI उपकरण र दृश्य उपकरणको रूपमा चलाउन सकिन्छ।
- **म्यानुअल परीक्षण**: तपाईं curl जस्तो उपकरण प्रयोग गरेर वेब अनुरोधहरू चलाउन सक्नुहुन्छ, तर HTTP चलाउन सक्षम कुनै पनि उपकरणले काम गर्नेछ।
- **यूनिट परीक्षण**: सर्भर र क्लाइन्ट दुवैको विशेषताहरू परीक्षण गर्न तपाईंको मनपर्ने परीक्षण फ्रेमवर्क प्रयोग गर्न सम्भव छ।

### MCP Inspector प्रयोग गर्दै

हामीले यस उपकरणको प्रयोगलाई अघिल्लो पाठहरूमा वर्णन गरेका छौं तर यसबारे उच्च स्तरमा कुरा गरौं। यो Node.js मा निर्माण गरिएको उपकरण हो र तपाईं `npx` कार्यान्वयनलाई बोलाएर यसलाई प्रयोग गर्न सक्नुहुन्छ जसले उपकरणलाई अस्थायी रूपमा डाउनलोड र स्थापना गर्नेछ र तपाईंको अनुरोध चलाइसकेपछि आफैंलाई सफा गर्नेछ।

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) ले तपाईंलाई मद्दत गर्छ:

- **सर्भर क्षमताहरू पत्ता लगाउनुहोस्**: उपलब्ध स्रोतहरू, उपकरणहरू, र प्रॉम्प्टहरू स्वत: पत्ता लगाउनुहोस्
- **उपकरण कार्यान्वयन परीक्षण गर्नुहोस्**: विभिन्न प्यारामिटरहरू प्रयास गर्नुहोस् र प्रतिक्रियाहरू वास्तविक समयमा हेर्नुहोस्
- **सर्भर मेटाडाटा हेर्नुहोस्**: सर्भर जानकारी, स्किमाहरू, र कन्फिगरेसनहरू जाँच गर्नुहोस्

उपकरणको एक सामान्य रन यस प्रकार देखिन्छ:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

माथिको कमाण्डले MCP र यसको दृश्य इन्टरफेस सुरु गर्छ र तपाईंको ब्राउजरमा स्थानीय वेब इन्टरफेस लन्च गर्छ। तपाईंले आफ्नो दर्ता गरिएका MCP सर्भरहरू, तिनीहरूको उपलब्ध उपकरणहरू, स्रोतहरू, र प्रॉम्प्टहरू प्रदर्शन गर्ने ड्यासबोर्ड देख्न अपेक्षा गर्न सक्नुहुन्छ। इन्टरफेसले तपाईंलाई इंटरेक्टिभ रूपमा उपकरण कार्यान्वयन परीक्षण गर्न, सर्भर मेटाडाटा निरीक्षण गर्न, र वास्तविक समय प्रतिक्रियाहरू हेर्न अनुमति दिन्छ, जसले तपाईंको MCP सर्भर कार्यान्वयनहरूलाई प्रमाणित र डिबग गर्न सजिलो बनाउँछ।

यसले कस्तो देखिन सक्छ: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.ne.png)

तपाईं यस उपकरणलाई CLI मोडमा पनि चलाउन सक्नुहुन्छ जसमा तपाईंले `--cli` विशेषता थप्नुहुन्छ। यहाँ "CLI" मोडमा उपकरण चलाउने उदाहरण छ जसले सर्भरमा सबै उपकरणहरू सूचीबद्ध गर्छ:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### म्यानुअल परीक्षण

सर्भर क्षमताहरू परीक्षण गर्न निरीक्षक उपकरण चलाउनुको अलावा, अर्को समान दृष्टिकोण भनेको HTTP प्रयोग गर्न सक्षम क्लाइन्ट चलाउनु हो जस्तै उदाहरणका लागि curl।

curl को साथ, तपाईं MCP सर्भरहरूलाई HTTP अनुरोधहरू प्रयोग गरेर प्रत्यक्ष रूपमा परीक्षण गर्न सक्नुहुन्छ:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

जस्तो कि तपाईंले माथिको curl प्रयोगबाट देख्न सक्नुहुन्छ, तपाईंले उपकरणलाई यसको नाम र यसको प्यारामिटरहरू समावेश गर्ने पेलोड प्रयोग गरेर POST अनुरोध प्रयोग गर्नुहुन्छ। तपाईंलाई सबैभन्दा उपयुक्त दृष्टिकोण प्रयोग गर्नुहोस्। सामान्यतया CLI उपकरणहरू छिटो प्रयोग गर्न र स्क्रिप्ट गर्न सक्षम हुन्छन् जुन CI/CD वातावरणमा उपयोगी हुन सक्छ।

### यूनिट परीक्षण

तपाईंको उपकरणहरू र स्रोतहरूका लागि यूनिट परीक्षणहरू सिर्जना गर्नुहोस् ताकि तिनीहरू अपेक्षाकृत काम गर्छन्। यहाँ केही उदाहरण परीक्षण कोड छ।

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

पूर्ववर्ती कोडले निम्न कार्य गर्छ:

- pytest फ्रेमवर्कको उपयोग गर्छ जसले तपाईंलाई कार्यहरूका रूपमा परीक्षणहरू सिर्जना गर्न र assert कथनहरू प्रयोग गर्न अनुमति दिन्छ।
- दुई विभिन्न उपकरणहरूसँग एक MCP सर्भर सिर्जना गर्छ।
- निश्चित सर्तहरू पूरा भएको सुनिश्चित गर्न `assert` कथन प्रयोग गर्छ।

पूरा फाइल यहाँ हेर्नुहोस् [full file here](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

माथिको फाइललाई दिएर, तपाईं आफ्नो सर्भरलाई परीक्षण गर्न सक्नुहुन्छ ताकि क्षमताहरू अपेक्षाकृत सिर्जना भएका छन्।

सबै प्रमुख SDK हरूमा समान परीक्षण खण्डहरू छन् ताकि तपाईं आफ्नो रोजेको रनटाइममा समायोजन गर्न सक्नुहुन्छ।

## नमूनाहरू 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## अतिरिक्त स्रोतहरू

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## के हुनेछ

- अर्को: [Deployment](/03-GettingStarted/08-deployment/README.md)

**अस्वीकरण**:  
यो दस्तावेज एआई अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको छ। हामी शुद्धताको लागि प्रयास गर्छौं भने पनि, कृपया सचेत रहनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्दछन्। यसको मूल भाषामा रहेको दस्तावेजलाई आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीको लागि, व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्या प्रति हामी जिम्मेवार छैनौं।