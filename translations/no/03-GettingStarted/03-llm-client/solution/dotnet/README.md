<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:42:05+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "no"
}
-->
# Kjør dette eksempelet

> [!NOTE]
> Dette eksempelet forutsetter at du bruker en GitHub Codespaces-instans. Hvis du vil kjøre dette lokalt, må du sette opp en personlig tilgangstoken på GitHub.

## Installer biblioteker

```sh
dotnet restore
```

Skal installere følgende biblioteker: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtocol

## Kjør

```sh 
dotnet run
```

Du bør se en utdata som ligner på:

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

Mye av utdataene er bare feilsøking, men det som er viktig er at du lister opp verktøy fra MCP-serveren, gjør dem om til LLM-verktøy, og du ender opp med et MCP-klientrespons "Sum 6".

**Ansvarsfraskrivelse**:  
Dette dokumentet har blitt oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.