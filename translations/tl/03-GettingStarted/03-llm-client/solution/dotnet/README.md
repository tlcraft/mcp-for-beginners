<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:43:24+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "tl"
}
-->
# Patakbuhin ang halimbawang ito

> [!NOTE]
> Ang halimbawang ito ay inaasahang ginagamit mo ang isang GitHub Codespaces instance. Kung nais mong patakbuhin ito nang lokal, kailangan mong mag-set up ng personal access token sa GitHub.

## Mag-install ng mga library

```sh
dotnet restore
```

Dapat i-install ang mga sumusunod na library: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtocol

## Patakbuhin

```sh 
dotnet run
```

Dapat kang makakita ng output na katulad ng:

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

Marami sa output ay debugging lamang ngunit ang mahalaga ay naglilista ka ng mga tool mula sa MCP Server, gawing mga LLM tool ang mga iyon at matatapos ka sa isang MCP client response na "Sum 6".

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat sinisikap namin ang pagiging tumpak, pakitandaan na ang awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa kanyang katutubong wika ay dapat ituring na mapagkakatiwalaang pinagmulan. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot para sa anumang hindi pagkakaunawaan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.