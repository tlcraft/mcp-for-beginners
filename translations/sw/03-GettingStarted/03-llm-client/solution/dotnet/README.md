<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:43:30+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "sw"
}
-->
# Endesha sampuli hii

> [!NOTE]
> Sampuli hii inadhani unatumia mazingira ya GitHub Codespaces. Ikiwa unataka kuendesha hii kwenye kompyuta yako, unahitaji kuunda tokeni ya ufikiaji wa kibinafsi kwenye GitHub.

## Sakinisha maktaba

```sh
dotnet restore
```

Inapaswa kusakinisha maktaba zifuatazo: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtocol 

## Endesha

```sh 
dotnet run
```

Unapaswa kuona matokeo yanayofanana na:

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

Sehemu kubwa ya matokeo ni ya kusuluhisha matatizo, lakini muhimu ni kwamba unaorodhesha zana kutoka kwa MCP Server, geuza hizo kuwa zana za LLM na unapata jibu la mteja wa MCP "Sum 6".

**Kanusho**: 
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo chenye mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatutawajibika kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.