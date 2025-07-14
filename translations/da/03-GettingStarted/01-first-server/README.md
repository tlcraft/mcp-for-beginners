<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "315ecce765d22639b60dbc41344c8533",
  "translation_date": "2025-07-13T17:34:20+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "da"
}
-->
### -2- Opret projekt

Nu hvor du har installeret dit SDK, lad os oprette et projekt næste skridt:

### -3- Opret projektfiler

### -4- Opret serverkode

### -5- Tilføj et værktøj og en ressource

Tilføj et værktøj og en ressource ved at indsætte følgende kode:

### -6 Færdig kode

Lad os tilføje den sidste kode, vi har brug for, så serveren kan starte:

### -7- Test serveren

Start serveren med følgende kommando:

### -8- Kør med inspector

Inspector er et fantastisk værktøj, der kan starte din server op og lade dig interagere med den, så du kan teste, at den fungerer. Lad os starte den:
> [!NOTE]
> det kan se anderledes ud i "command"-feltet, da det indeholder kommandoen til at køre en server med din specifikke runtime/
Du skulle nu kunne se følgende brugergrænseflade:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.da.png)

1. Forbind til serveren ved at vælge Connect-knappen  
  Når du har forbindelse til serveren, skulle du nu kunne se følgende:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.da.png)

1. Vælg "Tools" og "listTools", du skulle nu kunne se "Add" dukke op, vælg "Add" og udfyld parameter-værdierne.

  Du skulle nu kunne se følgende svar, altså et resultat fra "add"-værktøjet:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.da.png)

Tillykke, du har nu oprettet og kørt din første server!

### Officielle SDK'er

MCP tilbyder officielle SDK'er til flere sprog:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Vedligeholdes i samarbejde med Microsoft  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Vedligeholdes i samarbejde med Spring AI  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Den officielle TypeScript-implementering  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Den officielle Python-implementering  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Den officielle Kotlin-implementering  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Vedligeholdes i samarbejde med Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Den officielle Rust-implementering  

## Vigtige pointer

- Opsætning af et MCP-udviklingsmiljø er enkelt med sprog-specifikke SDK'er  
- At bygge MCP-servere indebærer at oprette og registrere værktøjer med klare skemaer  
- Test og fejlfinding er afgørende for pålidelige MCP-implementeringer  

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Opgave

Opret en simpel MCP-server med et værktøj efter eget valg:

1. Implementer værktøjet i dit foretrukne sprog (.NET, Java, Python eller JavaScript).  
2. Definér inputparametre og returværdier.  
3. Kør inspector-værktøjet for at sikre, at serveren fungerer som forventet.  
4. Test implementeringen med forskellige input.  

## Løsning

[Løsning](./solution/README.md)

## Yderligere ressourcer

- [Byg agenter med Model Context Protocol på Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Remote MCP med Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## Hvad er det næste

Næste: [Kom godt i gang med MCP-klienter](../02-client/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.