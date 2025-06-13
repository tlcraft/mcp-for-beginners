<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:06:42+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "mr"
}
-->
## चाचणी आणि डीबगिंग

आपला MCP सर्व्हर तपासण्याआधी, उपलब्ध साधने आणि डीबगिंगसाठी सर्वोत्तम पद्धती समजून घेणे महत्त्वाचे आहे. प्रभावी चाचणीमुळे आपला सर्व्हर अपेक्षेनुसार कार्य करतो याची खात्री होते आणि समस्या पटकन ओळखून सोडवता येतात. पुढील विभागात आपली MCP अंमलबजावणी सत्यापित करण्यासाठी शिफारस केलेल्या पद्धतींचा आढावा दिला आहे.

## आढावा

हा धडा योग्य चाचणी पद्धत कशी निवडायची आणि सर्वात प्रभावी चाचणी साधन कोणते आहे हे शिकवतो.

## शिक्षण उद्दिष्टे

या धड्याच्या शेवटी, आपण सक्षम असाल:

- चाचणीसाठी विविध पद्धती वर्णन करण्यासाठी.
- आपला कोड प्रभावीपणे तपासण्यासाठी वेगवेगळ्या साधनांचा वापर करण्यासाठी.

## MCP सर्व्हर्सची चाचणी

MCP आपल्याला सर्व्हर तपासणी आणि डीबगिंगसाठी खालील साधने पुरवते:

- **MCP Inspector**: एक कमांड लाइन साधन जे CLI आणि व्हिज्युअल दोन्ही प्रकारे चालवता येते.
- **मॅन्युअल चाचणी**: curl सारख्या साधनाचा वापर करून वेब विनंत्या चालवू शकता, पण HTTP चालवू शकणं कुठल्याही साधनाने चालेल.
- **युनिट चाचणी**: आपल्या आवडत्या चाचणी फ्रेमवर्कचा वापर करून सर्व्हर आणि क्लायंट दोन्ही फिचर्सची चाचणी करता येते.

### MCP Inspector वापरणे

आम्ही यापूर्वीच्या धड्यांमध्ये या साधनाचा वापर कसा करायचा हे सांगितले आहे, पण थोडक्यात पाहूया. हे Node.js मध्ये तयार केलेले साधन आहे आणि आपण `npx` executable कॉल करून वापरू शकता, जे स्वतःच टूल तात्पुरते डाउनलोड आणि इन्स्टॉल करेल आणि नंतर आपला विनंती पूर्ण झाल्यावर स्वतःला साफ करेल.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) आपल्याला मदत करतो:

- **सर्व्हर क्षमता शोधा**: उपलब्ध संसाधने, साधने आणि प्रॉम्प्ट आपोआप शोधा
- **साधन कार्यान्वयन तपासा**: वेगवेगळे पॅरामीटर्स वापरून रिअल-टाइम प्रतिसाद पहा
- **सर्व्हर मेटाडेटा पहा**: सर्व्हर माहिती, स्कीमा आणि कॉन्फिगरेशन तपासा

साधन चालवण्याचा एक सामान्य प्रकार असा दिसतो:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

वरील कमांड MCP आणि त्याचा व्हिज्युअल इंटरफेस सुरू करते आणि आपल्या ब्राउझरमध्ये स्थानिक वेब इंटरफेस उघडते. आपल्याला नोंदणीकृत MCP सर्व्हर्स, त्यांची उपलब्ध साधने, संसाधने आणि प्रॉम्प्टसह एक डॅशबोर्ड दिसेल. हा इंटरफेस आपल्याला इंटरएक्टिव्हली साधन कार्यान्वयन तपासण्याची, सर्व्हर मेटाडेटा तपासण्याची आणि रिअल-टाइम प्रतिसाद पाहण्याची सुविधा देतो, ज्यामुळे आपली MCP सर्व्हर अंमलबजावणी अधिक सोपी होते.

हे कसे दिसू शकते: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.mr.png)

आपण हे टूल CLI मोडमध्ये देखील चालवू शकता, ज्यासाठी `--cli` अ‍ॅट्रिब्यूट जोडावा लागतो. खाली सर्व्हरवरील सर्व साधने यादीसाठी "CLI" मोडमध्ये टूल चालवण्याचा एक उदाहरण आहे:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### मॅन्युअल चाचणी

सर्व्हर क्षमता तपासण्यासाठी inspector टूल चालवण्याव्यतिरिक्त, HTTP वापरू शकणारा क्लायंट वापरण्याचा एक समान मार्ग म्हणजे curl सारखे साधन.

curl वापरून, आपण थेट HTTP विनंत्यांद्वारे MCP सर्व्हर्सची चाचणी करू शकता:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

वरील curl वापरातून दिसतं की, आपण POST विनंती वापरून साधन आणि त्याच्या पॅरामीटर्ससह पेलोड पाठवून साधन कार्यान्वित करता. आपल्याला जशी सोयीची वाटेल तशी पद्धत वापरा. CLI साधने सामान्यतः वेगवान असतात आणि स्क्रिप्टिंगसाठी योग्य असतात, जे CI/CD वातावरणात उपयुक्त ठरू शकते.

### युनिट चाचणी

आपल्या साधने आणि संसाधनांसाठी युनिट चाचणी तयार करा जेणेकरून ते अपेक्षेनुसार कार्य करतात याची खात्री होईल. खाली काही उदाहरणात्मक चाचणी कोड दिला आहे.

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

वरील कोड हे करतो:

- pytest फ्रेमवर्कचा वापर करतो जो आपल्याला फंक्शन्स म्हणून चाचण्या तयार करण्याची आणि assert स्टेटमेंट्स वापरण्याची परवानगी देतो.
- दोन वेगवेगळ्या साधनांसह MCP सर्व्हर तयार करतो.
- `assert` स्टेटमेंट वापरून काही अटी पूर्ण झाल्या आहेत का तपासतो.

पूर्ण फाइल येथे पहा: [full file here](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

वरील फाइलच्या आधारे, आपण आपला स्वतःचा सर्व्हर तपासू शकता आणि खात्री करू शकता की क्षमता योग्यरित्या तयार केल्या आहेत.

सर्व प्रमुख SDKs मध्ये अशीच चाचणी विभागे असतात त्यामुळे आपण आपल्या निवडलेल्या रनटाइमसाठी ते समायोजित करू शकता.

## नमुने

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## अतिरिक्त संसाधने

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## पुढे काय

- पुढे: [Deployment](/03-GettingStarted/09-deployment/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) चा वापर करून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात ठेवा की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या मूळ भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाची माहिती साठी व्यावसायिक मानवी भाषांतर शिफारस केली जाते. या भाषांतराचा वापर करून झालेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थनिर्णयांसाठी आम्ही जबाबदार नाही.