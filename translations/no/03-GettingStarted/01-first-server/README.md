<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d5b044c0924d393af3066e03d7d89c5",
  "translation_date": "2025-07-16T09:46:12+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "no"
}
-->
### -2- Opprett prosjekt

Nå som du har SDK-en installert, la oss opprette et prosjekt neste steg:

### -3- Opprett prosjektfiler

### -4- Lag serverkoden

### -5- Legg til et verktøy og en ressurs

Legg til et verktøy og en ressurs ved å legge til følgende kode:

### -6- Fullstendig kode

La oss legge til den siste koden vi trenger slik at serveren kan starte:

### -7- Test serveren

Start serveren med følgende kommando:

### -8- Kjør med inspector

Inspector er et flott verktøy som kan starte opp serveren din og lar deg samhandle med den slik at du kan teste at den fungerer. La oss starte den:
> [!NOTE]
> det kan se annerledes ut i "command"-feltet siden det inneholder kommandoen for å kjøre en server med din spesifikke runtime/
Du skal nå se følgende brukergrensesnitt:

![Connect](/03-GettingStarted/01-first-server/assets/connect.png)

1. Koble til serveren ved å velge Connect-knappen
  Når du har koblet til serveren, skal du nå se følgende:

  ![Connected](/03-GettingStarted/01-first-server/assets/connected.png)

1. Velg "Tools" og "listTools", du skal se "Add" dukke opp, velg "Add" og fyll inn parameterverdiene.

  Du skal se følgende respons, altså et resultat fra "add"-verktøyet:

  ![Result of running add](/03-GettingStarted/01-first-server/assets/ran-tool.png)

Gratulerer, du har klart å opprette og kjøre din første server!

### Offisielle SDK-er

MCP tilbyr offisielle SDK-er for flere språk:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Vedlikeholdes i samarbeid med Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Vedlikeholdes i samarbeid med Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Den offisielle TypeScript-implementeringen
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Den offisielle Python-implementeringen
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Den offisielle Kotlin-implementeringen
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Vedlikeholdes i samarbeid med Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Den offisielle Rust-implementeringen

## Viktige punkter

- Å sette opp et MCP-utviklingsmiljø er enkelt med språkspesifikke SDK-er
- Å bygge MCP-servere innebærer å lage og registrere verktøy med tydelige skjemaer
- Testing og feilsøking er avgjørende for pålitelige MCP-implementasjoner

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Oppgave

Lag en enkel MCP-server med et verktøy du velger:

1. Implementer verktøyet i ditt foretrukne språk (.NET, Java, Python eller JavaScript).
2. Definer inndata-parametere og returverdier.
3. Kjør inspector-verktøyet for å sikre at serveren fungerer som forventet.
4. Test implementeringen med ulike inndata.

## Løsning

[Løsning](./solution/README.md)

## Ekstra ressurser

- [Bygg agenter med Model Context Protocol på Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Fjernstyrt MCP med Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Hva nå

Neste: [Kom i gang med MCP-klienter](../02-client/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.