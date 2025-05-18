<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:45:05+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "sl"
}
-->
# इस नमूने को चलाएं

> [!NOTE]
> यह नमूना मानता है कि आप एक GitHub Codespaces उदाहरण का उपयोग कर रहे हैं। यदि आप इसे स्थानीय रूप से चलाना चाहते हैं, तो आपको GitHub पर एक व्यक्तिगत एक्सेस टोकन सेट अप करने की आवश्यकता है।

## लाइब्रेरीज़ स्थापित करें

```sh
dotnet restore
```

निम्नलिखित लाइब्रेरीज़ को स्थापित करना चाहिए: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol 

## चलाएं

```sh 
dotnet run
```

आपको एक आउटपुट देखना चाहिए जो इस प्रकार है:

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

बहुत सारा आउटपुट केवल डिबगिंग है, लेकिन जो महत्वपूर्ण है वह यह है कि आप MCP सर्वर से टूल्स सूचीबद्ध कर रहे हैं, उन्हें LLM टूल्स में बदलें और आपको MCP क्लाइंट प्रतिक्रिया "Sum 6" मिलती है।

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI storitve za prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da se zavedate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku naj bo obravnavan kot avtoritativni vir. Za ključne informacije je priporočljivo profesionalno človeško prevajanje. Ne odgovarjamo za morebitne nesporazume ali napačne razlage, ki izhajajo iz uporabe tega prevoda.