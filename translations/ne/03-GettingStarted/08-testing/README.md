<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:07:00+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "ne"
}
-->
## परीक्षण र डिबगिङ

तपाईंको MCP सर्भर परीक्षण गर्न सुरु गर्नु अघि, उपलब्ध उपकरणहरू र डिबगिङका लागि उत्तम अभ्यासहरू बुझ्नु महत्वपूर्ण छ। प्रभावकारी परीक्षणले तपाईंको सर्भरले अपेक्षित रूपमा व्यवहार गर्छ भन्ने सुनिश्चित गर्दछ र समस्या छिटो पत्ता लगाउन र समाधान गर्न मद्दत गर्दछ। निम्न खण्डले तपाईंको MCP कार्यान्वयन प्रमाणित गर्न सिफारिस गरिएका तरिकाहरू प्रस्तुत गर्दछ।

## अवलोकन

यस पाठले सही परीक्षण तरिका चयन गर्ने र सबैभन्दा प्रभावकारी परीक्षण उपकरणको बारेमा कभर गर्दछ।

## सिकाइ उद्देश्यहरू

यस पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:

- परीक्षणका विभिन्न तरिकाहरू वर्णन गर्न।
- विभिन्न उपकरणहरू प्रयोग गरी आफ्नो कोड प्रभावकारी रूपमा परीक्षण गर्न।

## MCP सर्भरहरू परीक्षण गर्दै

MCP ले तपाईंलाई सर्भरहरू परीक्षण र डिबग गर्न मद्दत गर्ने उपकरणहरू प्रदान गर्दछ:

- **MCP Inspector**: एक कमाण्ड लाइन उपकरण जुन CLI उपकरण र भिजुअल उपकरण दुवै रूपमा चलाउन सकिन्छ।
- **म्यानुअल परीक्षण**: curl जस्ता उपकरण प्रयोग गरेर वेब अनुरोधहरू चलाउन सकिन्छ, तर HTTP चलाउन सक्ने कुनै पनि उपकरण प्रयोग गर्न सकिन्छ।
- **युनिट परीक्षण**: तपाईंले मनपर्ने परीक्षण फ्रेमवर्क प्रयोग गरेर सर्भर र क्लाइन्ट दुवैका सुविधाहरू परीक्षण गर्न सक्नुहुन्छ।

### MCP Inspector प्रयोग गर्दै

यस उपकरणको प्रयोग हामीले अघिल्लो पाठहरूमा वर्णन गरिसकेका छौं, तर यहाँ उच्च स्तरमा यसको बारेमा कुरा गरौं। यो Node.js मा बनाइएको उपकरण हो र तपाईंले `npx` executable कल गरेर यसलाई प्रयोग गर्न सक्नुहुन्छ, जसले यस उपकरणलाई अस्थायी रूपमा डाउनलोड र इन्स्टल गर्छ र अनुरोध पूरा भएपछि आफैं सफा गर्छ।

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) तपाईंलाई मद्दत गर्दछ:

- **सर्भर क्षमताहरू पत्ता लगाउने**: उपलब्ध स्रोतहरू, उपकरणहरू, र प्रॉम्प्टहरू स्वचालित रूपमा पत्ता लगाउने
- **उपकरण कार्यान्वयन परीक्षण गर्ने**: विभिन्न प्यारामिटरहरू प्रयास गर्ने र वास्तविक समयमा प्रतिक्रिया हेर्ने
- **सर्भर मेटाडाटा हेर्ने**: सर्भर जानकारी, स्किमाहरू, र कन्फिगरेसनहरू जाँच्ने

यो उपकरणको सामान्य प्रयोग यसरी देखिन्छ:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

माथिको कमाण्डले MCP र यसको भिजुअल इन्टरफेस सुरु गर्छ र तपाईंको ब्राउजरमा स्थानीय वेब इन्टरफेस खोल्छ। तपाईंले ड्यासबोर्डमा दर्ता भएका MCP सर्भरहरू, तिनीहरूका उपलब्ध उपकरणहरू, स्रोतहरू, र प्रॉम्प्टहरू देख्न सक्नुहुन्छ। इन्टरफेसले तपाईंलाई अन्तरक्रियात्मक रूपमा उपकरण परीक्षण गर्न, सर्भर मेटाडाटा निरीक्षण गर्न, र वास्तविक समयमा प्रतिक्रिया हेर्न मद्दत गर्दछ जसले तपाईंको MCP सर्भर कार्यान्वयन प्रमाणित र डिबग गर्न सजिलो बनाउँछ।

यो कस्तो देखिन सक्छ भन्ने उदाहरण: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ne.png)

तपाईं यस उपकरणलाई CLI मोडमा पनि चलाउन सक्नुहुन्छ, जसका लागि `--cli` विकल्प थप्नुहोस्। यहाँ "CLI" मोडमा उपकरण चलाउने उदाहरण छ जसले सर्भरमा भएका सबै उपकरणहरू सूचीबद्ध गर्छ:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### म्यानुअल परीक्षण

सर्भर क्षमताहरू परीक्षण गर्न inspector उपकरण चलाउने बाहेक, अर्को समान तरिका HTTP प्रयोग गर्न सक्ने क्लाइन्ट चलाउनु हो, जस्तै curl।

curl प्रयोग गरेर, तपाईं MCP सर्भरहरूलाई HTTP अनुरोधहरू मार्फत सिधै परीक्षण गर्न सक्नुहुन्छ:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

माथिको curl प्रयोगबाट देख्न सकिन्छ कि तपाईंले POST अनुरोध प्रयोग गरी उपकरणलाई यसको नाम र प्यारामिटरहरूको payload सहित कल गर्नुहुन्छ। तपाईंलाई सबैभन्दा उपयुक्त लाग्ने तरिका प्रयोग गर्नुहोस्। CLI उपकरणहरू सामान्यतया छिटो प्रयोग गर्न सकिन्छ र स्क्रिप्ट गर्न सजिलो हुन्छ जुन CI/CD वातावरणमा उपयोगी हुन सक्छ।

### युनिट परीक्षण

तपाईंका उपकरण र स्रोतहरू अपेक्षित रूपमा काम गर्छन् भनी सुनिश्चित गर्न युनिट परीक्षणहरू सिर्जना गर्नुहोस्। यहाँ केही परीक्षण कोडको उदाहरण छ।

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

माथिको कोडले निम्न कार्यहरू गर्दछ:

- pytest फ्रेमवर्क प्रयोग गर्दछ जुन तपाईंलाई फङ्सनको रूपमा परीक्षणहरू सिर्जना गर्न र assert कथनहरू प्रयोग गर्न दिन्छ।
- दुई फरक उपकरणहरूसहितको MCP सर्भर सिर्जना गर्दछ।
- निश्चित सर्तहरू पूरा भएको जाँच्न `assert` कथन प्रयोग गर्दछ।

[पूर्ण फाइल यहाँ हेर्नुहोस्](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

माथिको फाइल अनुसार, तपाईं आफ्नो सर्भर परीक्षण गर्न सक्नुहुन्छ र सुनिश्चित गर्न सक्नुहुन्छ कि क्षमताहरू ठीकसँग सिर्जना भएका छन्।

सबै प्रमुख SDK हरूमा यस्तै परीक्षण खण्डहरू हुन्छन् त्यसैले तपाईं आफ्नो रोजेको रनटाइम अनुसार अनुकूलन गर्न सक्नुहुन्छ।

## नमूनाहरू

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## अतिरिक्त स्रोतहरू

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## अब के गर्ने

- अर्को: [Deployment](/03-GettingStarted/09-deployment/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताको लागि प्रयास गर्छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा असङ्गतिहरू हुन सक्छन्। मूल दस्तावेज यसको मूल भाषामा अधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीको लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।