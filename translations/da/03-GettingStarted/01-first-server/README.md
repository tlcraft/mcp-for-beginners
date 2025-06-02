<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:11:09+00:00",
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

### -6- Færdig kode

Lad os tilføje den sidste kode, vi har brug for, så serveren kan starte:

### -7- Test serveren

Start serveren med følgende kommando:

### -8- Kør med inspector

Inspector er et fantastisk værktøj, der kan starte din server og lade dig interagere med den, så du kan teste, at den fungerer. Lad os starte den:

> [!NOTE]
> Det kan se anderledes ud i "command"-feltet, da det indeholder kommandoen til at køre en server med din specifikke runtime/

Du burde se følgende brugerflade:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.da.png)

1. Forbind til serveren ved at vælge Connect-knappen  
   Når du er forbundet til serveren, burde du nu se følgende:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.da.png)

2. Vælg "Tools" og "listTools", du burde se "Add" dukke op, vælg "Add" og udfyld parameter-værdierne.

   Du burde se følgende svar, altså et resultat fra "add"-værktøjet:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.da.png)

Tillykke, du har formået at oprette og køre din første server!

### Officielle SDK'er

MCP tilbyder officielle SDK'er til flere sprog:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Vedligeholdt i samarbejde med Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Vedligeholdt i samarbejde med Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Den officielle TypeScript-implementering
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Den officielle Python-implementering
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Den officielle Kotlin-implementering
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Vedligeholdt i samarbejde med Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Den officielle Rust-implementering

## Vigtige pointer

- Opsætning af et MCP-udviklingsmiljø er enkelt med sprog-specifikke SDK'er
- At bygge MCP-servere indebærer at skabe og registrere værktøjer med klare skemaer
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
2. Definer inputparametre og returværdier.  
3. Kør inspector-værktøjet for at sikre, at serveren fungerer som forventet.  
4. Test implementeringen med forskellige input.

## Løsning

[Løsning](./solution/README.md)

## Yderligere ressourcer

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Hvad nu?

Næste: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.