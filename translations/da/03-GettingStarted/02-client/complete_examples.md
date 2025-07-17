<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T09:10:40+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "da"
}
-->
# Færdige MCP Client Eksempler

Denne mappe indeholder komplette, fungerende eksempler på MCP clients i forskellige programmeringssprog. Hver client demonstrerer den fulde funktionalitet beskrevet i hoved-README.md tutorialen.

## Tilgængelige Clients

### 1. Java Client (`client_example_java.java`)
- **Transport**: SSE (Server-Sent Events) over HTTP
- **Målserver**: `http://localhost:8080`
- **Funktioner**: 
  - Oprettelse af forbindelse og ping
  - Liste over værktøjer
  - Lommeregner-operationer (add, subtract, multiply, divide, help)
  - Fejlhåndtering og resultatudtrækning

**For at køre:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# Client (`client_example_csharp.cs`)
- **Transport**: Stdio (Standard Input/Output)
- **Målserver**: Lokal .NET MCP server via dotnet run
- **Funktioner**:
  - Automatisk serverstart via stdio transport
  - Liste over værktøjer og ressourcer
  - Lommeregner-operationer
  - JSON resultatparsing
  - Omfattende fejlhåndtering

**For at køre:**
```bash
dotnet run
```

### 3. TypeScript Client (`client_example_typescript.ts`)
- **Transport**: Stdio (Standard Input/Output)
- **Målserver**: Lokal Node.js MCP server
- **Funktioner**:
  - Fuld MCP protokol support
  - Værktøjer, ressourcer og prompt-operationer
  - Lommeregner-operationer
  - Ressourcelæsning og prompt-eksekvering
  - Robust fejlhåndtering

**For at køre:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python Client (`client_example_python.py`)
- **Transport**: Stdio (Standard Input/Output)  
- **Målserver**: Lokal Python MCP server
- **Funktioner**:
  - Async/await mønster til operationer
  - Opdagelse af værktøjer og ressourcer
  - Test af lommeregner-operationer
  - Læsning af ressourceindhold
  - Klassebaseret organisering

**For at køre:**
```bash
python client_example_python.py
```

## Fælles Funktioner på Tværs af Alle Clients

Hver client-implementering demonstrerer:

1. **Forbindelsesstyring**
   - Oprettelse af forbindelse til MCP server
   - Håndtering af forbindelsesfejl
   - Korrekt oprydning og ressourcehåndtering

2. **Serveropdagelse**
   - Liste over tilgængelige værktøjer
   - Liste over tilgængelige ressourcer (hvor understøttet)
   - Liste over tilgængelige prompts (hvor understøttet)

3. **Værktøjskald**
   - Grundlæggende lommeregner-operationer (add, subtract, multiply, divide)
   - Help-kommando for serverinformation
   - Korrekt argumentoverførsel og resultatbehandling

4. **Fejlhåndtering**
   - Forbindelsesfejl
   - Fejl ved værktøjsudførelse
   - Elegant fejlhåndtering og brugerfeedback

5. **Resultatbehandling**
   - Udtrækning af tekstindhold fra svar
   - Formatering af output for læsbarhed
   - Håndtering af forskellige svarformater

## Forudsætninger

Før du kører disse clients, skal du sikre dig:

1. **At den tilsvarende MCP server kører** (fra `../01-first-server/`)
2. **At nødvendige afhængigheder er installeret** for dit valgte sprog
3. **At der er korrekt netværksforbindelse** (for HTTP-baserede transports)

## Væsentlige Forskelle Mellem Implementeringerne

| Sprog      | Transport | Serverstart    | Async Model | Vigtige Biblioteker |
|------------|-----------|----------------|-------------|--------------------|
| Java       | SSE/HTTP  | Ekstern        | Synkron     | WebFlux, MCP SDK    |
| C#         | Stdio     | Automatisk     | Async/Await | .NET MCP SDK        |
| TypeScript | Stdio     | Automatisk     | Async/Await | Node MCP SDK        |
| Python     | Stdio     | Automatisk     | AsyncIO     | Python MCP SDK      |

## Næste Skridt

Efter at have gennemgået disse client-eksempler:

1. **Ændr clients** for at tilføje nye funktioner eller operationer
2. **Lav din egen server** og test den med disse clients
3. **Eksperimenter med forskellige transports** (SSE vs. Stdio)
4. **Byg en mere kompleks applikation** der integrerer MCP funktionalitet

## Fejlfinding

### Almindelige Problemer

1. **Connection refused**: Sørg for at MCP serveren kører på den forventede port/sti
2. **Module not found**: Installer den nødvendige MCP SDK til dit sprog
3. **Permission denied**: Tjek filrettigheder for stdio transport
4. **Tool not found**: Bekræft at serveren implementerer de forventede værktøjer

### Debug Tips

1. **Aktivér detaljeret logning** i din MCP SDK
2. **Tjek serverlogs** for fejlmeddelelser
3. **Bekræft at værktøjsnavne og signaturer** stemmer overens mellem client og server
4. **Test først med MCP Inspector** for at validere serverfunktionalitet

## Relateret Dokumentation

- [Main Client Tutorial](./README.md)
- [MCP Server Examples](../../../../03-GettingStarted/01-first-server)
- [MCP with LLM Integration](../../../../03-GettingStarted/03-llm-client)
- [Official MCP Documentation](https://modelcontextprotocol.io/)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.