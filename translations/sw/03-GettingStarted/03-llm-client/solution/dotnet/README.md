<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c40c54fa74ded9c223bc0ebfc8a2de7c",
  "translation_date": "2025-06-18T06:06:12+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "sw"
}
-->
# Endesha mfano huu

> [!NOTE]
> Mfano huu unadhani unatumia GitHub Codespaces. Ikiwa unataka kuendesha hii kwa ndani, unahitaji kuweka tokeni ya upatikanaji binafsi (PAT) kwenye GitHub.
>
> ```bash
> # zsh/bash
> export GITHUB_TOKEN="{{YOUR_GITHUB_PAT}}"
> ```
>
> ```powershell
> # PowerShell
> $env:GITHUB_TOKEN = "{{YOUR_GITHUB_PAT}}"
> ```

## Sakinisha maktaba

```sh
dotnet restore
```

Inapaswa kusakinisha maktaba zifuatazo: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

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

Sehemu kubwa ya matokeo ni za kufuatilia makosa, lakini muhimu ni kwamba unataja zana kutoka kwa MCP Server, kuzibadilisha kuwa zana za LLM na mwisho wa siku unapata jibu la mteja wa MCP "Jumla 6".

**Kiarifu cha Kutokujali**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za moja kwa moja zinaweza kuwa na makosa au upotovu. Hati ya asili katika lugha yake ya mama inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.