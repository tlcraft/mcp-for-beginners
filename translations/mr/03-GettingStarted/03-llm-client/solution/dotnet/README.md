<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:40:02+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "mr"
}
-->
# हे नमुना चालवा

> [!NOTE]
> हे नमुना गिटहब कोडस्पेस इंस्टन्स वापरत असल्याचे गृहीत धरते. जर तुम्हाला हे स्थानिक पातळीवर चालवायचे असेल, तर तुम्हाला गिटहबवर वैयक्तिक प्रवेश टोकन सेट करावे लागेल.

## लायब्ररी इंस्टॉल करा

```sh
dotnet restore
```

खालील लायब्ररी इंस्टॉल कराव्यात: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol 

## चालवा

```sh 
dotnet run
```

तुम्हाला खालीलप्रमाणे आउटपुट दिसेल:

```text
Setting up stdio transport
Listing tools
Connected to server with tools: Add
Tool description: Adds two numbers
Tool parameters: {"title":"Add","description":"Adds two numbers","type":"object","properties":{"a":{"type":"integer"},"b":{"type":"integer"}},"required":["a","b"]}
Tool definition: Azure.AI.Inference.ChatCompletionsToolDefinition
Properties: {"a":{"type":"integer"},"b":{"type":"integer"}}
MCP Tools def: 0: Azure.AI.Inference.ChatCompletionsToolDefinition
Tool call 0: Add with arguments {"a":2,"b":4}
Sum 6
```

आउटपुटचा मोठा भाग फक्त डिबगिंग आहे पण महत्त्वाचे म्हणजे तुम्ही MCP सर्व्हरमधून साधने सूचीबद्ध करत आहात, त्यांना LLM साधने बनवा आणि तुम्हाला MCP क्लायंट प्रतिसाद "Sum 6" मिळेल.

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) चा वापर करून भाषांतरित केला गेला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी कृपया लक्षात ठेवा की स्वयंचलित भाषांतरे त्रुटी किंवा अचूकतेच्या अभावाने ग्रस्त असू शकतात. मूळ भाषेतील दस्तऐवज अधिकृत स्रोत म्हणून विचारात घेतला पाहिजे. महत्वाच्या माहितीसाठी, व्यावसायिक मानव भाषांतराची शिफारस केली जाते. या भाषांतराचा वापर करून उद्भवणाऱ्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थास आम्ही जबाबदार नाही.