<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:11:21+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "no"
}
-->
## Komme i gang

Denne seksjonen består av flere leksjoner:

- **-1- Din første server**, i denne første leksjonen vil du lære hvordan du oppretter din første server og inspiserer den med inspektørverktøyet, en verdifull måte å teste og feilsøke serveren din på, [til leksjonen](/03-GettingStarted/01-first-server/README.md)

- **-2- Klient**, i denne leksjonen vil du lære hvordan du skriver en klient som kan koble til serveren din, [til leksjonen](/03-GettingStarted/02-client/README.md)

- **-3- Klient med LLM**, en enda bedre måte å skrive en klient på er ved å legge til en LLM slik at den kan "forhandle" med serveren din om hva den skal gjøre, [til leksjonen](/03-GettingStarted/03-llm-client/README.md)

- **-4- Konsumere en server i GitHub Copilot Agent-modus i Visual Studio Code**. Her ser vi på å kjøre vår MCP-server fra Visual Studio Code, [til leksjonen](/03-GettingStarted/04-vscode/README.md)

- **-5- Konsumere fra en SSE (Server Sent Events)** SSE er en standard for server-til-klient streaming, som lar servere sende sanntidsoppdateringer til klienter over HTTP [til leksjonen](/03-GettingStarted/05-sse-server/README.md)

- **-6- Utnytte AI Toolkit for VSCode** for å konsumere og teste dine MCP-klienter og -servere [til leksjonen](/03-GettingStarted/06-aitk/README.md)

- **-7 Testing**. Her vil vi spesielt fokusere på hvordan vi kan teste serveren og klienten vår på forskjellige måter, [til leksjonen](/03-GettingStarted/07-testing/README.md)

- **-8- Distribusjon**. Dette kapitlet vil se på forskjellige måter å distribuere dine MCP-løsninger på, [til leksjonen](/03-GettingStarted/08-deployment/README.md)

Model Context Protocol (MCP) er en åpen protokoll som standardiserer hvordan applikasjoner gir kontekst til LLM-er. Tenk på MCP som en USB-C-port for AI-applikasjoner - den gir en standardisert måte å koble AI-modeller til forskjellige datakilder og verktøy på.

## Læringsmål

Ved slutten av denne leksjonen vil du kunne:

- Sette opp utviklingsmiljøer for MCP i C#, Java, Python, TypeScript og JavaScript
- Bygge og distribuere grunnleggende MCP-servere med tilpassede funksjoner (ressurser, ledetekster og verktøy)
- Lage vertsapplikasjoner som kobler til MCP-servere
- Teste og feilsøke MCP-implementasjoner
- Forstå vanlige oppsettsutfordringer og deres løsninger
- Koble MCP-implementasjonene dine til populære LLM-tjenester

## Sette opp ditt MCP-miljø

Før du begynner å jobbe med MCP, er det viktig å forberede utviklingsmiljøet ditt og forstå den grunnleggende arbeidsflyten. Denne delen vil veilede deg gjennom de innledende oppsettsstegene for å sikre en jevn start med MCP.

### Forutsetninger

Før du dykker inn i MCP-utvikling, sørg for at du har:

- **Utviklingsmiljø**: For ditt valgte språk (C#, Java, Python, TypeScript eller JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm eller en hvilken som helst moderne kodeeditor
- **Pakkeadministratorer**: NuGet, Maven/Gradle, pip eller npm/yarn
- **API-nøkler**: For eventuelle AI-tjenester du planlegger å bruke i vertsapplikasjonene dine

### Offisielle SDK-er

I de kommende kapitlene vil du se løsninger bygget ved hjelp av Python, TypeScript, Java og .NET. Her er alle de offisielt støttede SDK-ene.

MCP gir offisielle SDK-er for flere språk:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Vedlikeholdt i samarbeid med Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Vedlikeholdt i samarbeid med Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Den offisielle TypeScript-implementasjonen
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Den offisielle Python-implementasjonen
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Den offisielle Kotlin-implementasjonen
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Vedlikeholdt i samarbeid med Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Den offisielle Rust-implementasjonen

## Viktige punkter

- Å sette opp et MCP-utviklingsmiljø er enkelt med språkspesifikke SDK-er
- Å bygge MCP-servere innebærer å lage og registrere verktøy med klare skjemaer
- MCP-klienter kobler til servere og modeller for å utnytte utvidede kapabiliteter
- Testing og feilsøking er essensielt for pålitelige MCP-implementasjoner
- Distribusjonsalternativer spenner fra lokal utvikling til skybaserte løsninger

## Øving

Vi har et sett med eksempler som utfyller øvelsene du vil se i alle kapitler i denne delen. I tillegg har hvert kapittel også sine egne øvelser og oppgaver

- [Java Kalkulator](./samples/java/calculator/README.md)
- [.Net Kalkulator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](./samples/javascript/README.md)
- [TypeScript Kalkulator](./samples/typescript/README.md)
- [Python Kalkulator](../../../03-GettingStarted/samples/python)

## Ekstra ressurser

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Hva er neste

Neste: [Opprette din første MCP-server](/03-GettingStarted/01-first-server/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.