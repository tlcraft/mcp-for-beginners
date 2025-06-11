<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:11:41+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "no"
}
-->
## Komme i gang  

Denne seksjonen består av flere leksjoner:

- **1 Din første server**, i denne første leksjonen vil du lære hvordan du oppretter din første server og inspiserer den med inspektørverktøyet, en verdifull måte å teste og feilsøke serveren på, [til leksjonen](/03-GettingStarted/01-first-server/README.md)

- **2 Klient**, i denne leksjonen vil du lære hvordan du skriver en klient som kan koble til serveren din, [til leksjonen](/03-GettingStarted/02-client/README.md)

- **3 Klient med LLM**, en enda bedre måte å skrive en klient på er ved å legge til en LLM slik at den kan "forhandle" med serveren om hva som skal gjøres, [til leksjonen](/03-GettingStarted/03-llm-client/README.md)

- **4 Bruke en server GitHub Copilot Agent-modus i Visual Studio Code**. Her ser vi på hvordan vi kjører vår MCP Server fra Visual Studio Code, [til leksjonen](/03-GettingStarted/04-vscode/README.md)

- **5 Bruke SSE (Server Sent Events)** SSE er en standard for server-til-klient streaming, som lar servere sende sanntidsoppdateringer til klienter over HTTP [til leksjonen](/03-GettingStarted/05-sse-server/README.md)

- **6 Bruke AI Toolkit for VSCode** for å konsumere og teste MCP-klienter og servere [til leksjonen](/03-GettingStarted/06-aitk/README.md)

- **7 Testing**. Her fokuserer vi spesielt på hvordan vi kan teste serveren og klienten på forskjellige måter, [til leksjonen](/03-GettingStarted/07-testing/README.md)

- **8 Distribusjon**. Dette kapitlet ser på ulike måter å distribuere MCP-løsningene dine på, [til leksjonen](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) er en åpen protokoll som standardiserer hvordan applikasjoner gir kontekst til LLM-er. Tenk på MCP som en USB-C-port for AI-applikasjoner - det gir en standardisert måte å koble AI-modeller til forskjellige datakilder og verktøy.

## Læringsmål

Ved slutten av denne leksjonen vil du kunne:

- Sette opp utviklingsmiljøer for MCP i C#, Java, Python, TypeScript og JavaScript
- Bygge og distribuere grunnleggende MCP-servere med tilpassede funksjoner (ressurser, prompts og verktøy)
- Lage vertsapplikasjoner som kobler til MCP-servere
- Teste og feilsøke MCP-implementasjoner
- Forstå vanlige utfordringer ved oppsett og deres løsninger
- Koble MCP-implementasjonene dine til populære LLM-tjenester

## Sette opp ditt MCP-miljø

Før du begynner å jobbe med MCP, er det viktig å forberede utviklingsmiljøet ditt og forstå den grunnleggende arbeidsflyten. Denne seksjonen vil veilede deg gjennom de første oppsettsstegene for å sikre en god start med MCP.

### Forutsetninger

Før du går i gang med MCP-utvikling, sørg for at du har:

- **Utviklingsmiljø**: For det valgte språket (C#, Java, Python, TypeScript eller JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm eller en moderne kodeeditor
- **Pakkebehandlere**: NuGet, Maven/Gradle, pip eller npm/yarn
- **API-nøkler**: For eventuelle AI-tjenester du planlegger å bruke i vertsapplikasjonene dine


### Offisielle SDK-er

I de kommende kapitlene vil du se løsninger bygget med Python, TypeScript, Java og .NET. Her er alle de offisielt støttede SDK-ene.

MCP tilbyr offisielle SDK-er for flere språk:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Vedlikeholdt i samarbeid med Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Vedlikeholdt i samarbeid med Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Den offisielle TypeScript-implementeringen
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Den offisielle Python-implementeringen
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Den offisielle Kotlin-implementeringen
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Vedlikeholdt i samarbeid med Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Den offisielle Rust-implementeringen

## Viktige punkter

- Å sette opp et MCP-utviklingsmiljø er enkelt med språkspesifikke SDK-er
- Å bygge MCP-servere innebærer å lage og registrere verktøy med klare skjemaer
- MCP-klienter kobler til servere og modeller for å utnytte utvidede muligheter
- Testing og feilsøking er avgjørende for pålitelige MCP-implementasjoner
- Distribusjonsmuligheter spenner fra lokal utvikling til skyløsninger

## Øving

Vi har et sett med eksempler som kompletterer øvelsene du vil se i alle kapitlene i denne seksjonen. I tillegg har hvert kapittel sine egne øvelser og oppgaver

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Ekstra ressurser

- [Bygg agenter med Model Context Protocol på Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Fjern-MCP med Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Hva nå

Neste: [Opprette din første MCP Server](/03-GettingStarted/01-first-server/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår fra bruken av denne oversettelsen.