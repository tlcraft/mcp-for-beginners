<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:11:01+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "da"
}
-->
## Kom godt i gang

Denne sektion består af flere lektioner:

- **-1- Din første server**, i denne første lektion vil du lære, hvordan du opretter din første server og inspicerer den med inspektørværktøjet, en værdifuld måde at teste og fejlfinde din server på, [til lektionen](/03-GettingStarted/01-first-server/README.md)

- **-2- Klient**, i denne lektion vil du lære, hvordan du skriver en klient, der kan forbinde til din server, [til lektionen](/03-GettingStarted/02-client/README.md)

- **-3- Klient med LLM**, en endnu bedre måde at skrive en klient på er ved at tilføje en LLM, så den kan "forhandle" med din server om, hvad der skal gøres, [til lektionen](/03-GettingStarted/03-llm-client/README.md)

- **-4- Forbrug af en server GitHub Copilot Agent mode i Visual Studio Code**. Her ser vi på at køre vores MCP-server fra Visual Studio Code, [til lektionen](/03-GettingStarted/04-vscode/README.md)

- **-5- Forbrug fra en SSE (Server Sent Events)** SSE er en standard for server-til-klient streaming, der tillader servere at sende realtidsopdateringer til klienter over HTTP [til lektionen](/03-GettingStarted/05-sse-server/README.md)

- **-6- Anvendelse af AI Toolkit for VSCode** til at forbruge og teste dine MCP-klienter og -servere [til lektionen](/03-GettingStarted/06-aitk/README.md)

- **-7 Test**. Her vil vi fokusere på, hvordan vi kan teste vores server og klient på forskellige måder, [til lektionen](/03-GettingStarted/07-testing/README.md)

- **-8- Udrulning**. Dette kapitel vil se på forskellige måder at udrulle dine MCP-løsninger på, [til lektionen](/03-GettingStarted/08-deployment/README.md)

Model Context Protocol (MCP) er en åben protokol, der standardiserer, hvordan applikationer giver kontekst til LLM'er. Tænk på MCP som en USB-C-port til AI-applikationer - det giver en standardiseret måde at forbinde AI-modeller til forskellige datakilder og værktøjer.

## Læringsmål

Ved slutningen af denne lektion vil du være i stand til at:

- Opsætte udviklingsmiljøer for MCP i C#, Java, Python, TypeScript og JavaScript
- Bygge og udrulle grundlæggende MCP-servere med brugerdefinerede funktioner (ressourcer, prompts og værktøjer)
- Oprette vært-applikationer, der forbinder til MCP-servere
- Teste og fejlfinde MCP-implementeringer
- Forstå almindelige opsætningsudfordringer og deres løsninger
- Forbinde dine MCP-implementeringer til populære LLM-tjenester

## Opsætning af dit MCP-miljø

Før du begynder at arbejde med MCP, er det vigtigt at forberede dit udviklingsmiljø og forstå den grundlæggende arbejdsgang. Denne sektion vil guide dig gennem de indledende opsætningstrin for at sikre en god start med MCP.

### Forudsætninger

Inden du dykker ned i MCP-udvikling, skal du sikre dig, at du har:

- **Udviklingsmiljø**: For dit valgte sprog (C#, Java, Python, TypeScript eller JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm eller en moderne kodeeditor
- **Pakkehåndterere**: NuGet, Maven/Gradle, pip eller npm/yarn
- **API-nøgler**: Til eventuelle AI-tjenester, du planlægger at bruge i dine vært-applikationer

### Officielle SDK'er

I de kommende kapitler vil du se løsninger bygget ved hjælp af Python, TypeScript, Java og .NET. Her er alle de officielt understøttede SDK'er.

MCP leverer officielle SDK'er til flere sprog:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Vedligeholdt i samarbejde med Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Vedligeholdt i samarbejde med Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Den officielle TypeScript-implementering
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Den officielle Python-implementering
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Den officielle Kotlin-implementering
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Vedligeholdt i samarbejde med Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Den officielle Rust-implementering

## Vigtige punkter

- Opsætning af et MCP-udviklingsmiljø er ligetil med sprog-specifikke SDK'er
- Bygning af MCP-servere indebærer oprettelse og registrering af værktøjer med klare skemaer
- MCP-klienter forbinder til servere og modeller for at udnytte udvidede kapaciteter
- Test og fejlfinding er afgørende for pålidelige MCP-implementeringer
- Udrulningsmuligheder spænder fra lokal udvikling til cloud-baserede løsninger

## Øvelse

Vi har et sæt eksempler, der supplerer de øvelser, du vil se i alle kapitler i denne sektion. Derudover har hvert kapitel også deres egne øvelser og opgaver

- [Java Lommeregner](./samples/java/calculator/README.md)
- [.Net Lommeregner](../../../03-GettingStarted/samples/csharp)
- [JavaScript Lommeregner](./samples/javascript/README.md)
- [TypeScript Lommeregner](./samples/typescript/README.md)
- [Python Lommeregner](../../../03-GettingStarted/samples/python)

## Yderligere ressourcer

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Hvad er det næste

Næste: [Opret din første MCP-server](/03-GettingStarted/01-first-server/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Mens vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi er ikke ansvarlige for eventuelle misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.