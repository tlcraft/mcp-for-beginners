<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0bc7bd48f55f1565f1d95ccb2c16f728",
  "translation_date": "2025-06-18T07:51:03+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/README.md",
  "language_code": "no"
}
-->
# Eksempel

Det forrige eksempelet viser hvordan du bruker et lokalt .NET-prosjekt med typen `stdio`. Og hvordan du kjører serveren lokalt i en container. Dette er en god løsning i mange situasjoner. Men det kan være nyttig å ha serveren kjørende eksternt, for eksempel i et sky-miljø. Det er her typen `http` kommer inn.

Når du ser på løsningen i `04-PracticalImplementation`-mappen, kan den virke mye mer kompleks enn den forrige. Men i realiteten er den det ikke. Hvis du ser nøye på prosjektet `src/Calculator`, vil du se at det stort sett er samme kode som i det forrige eksempelet. Den eneste forskjellen er at vi bruker et annet bibliotek `ModelContextProtocol.AspNetCore` for å håndtere HTTP-forespørsler. Og vi endrer metoden `IsPrime` til å være privat, bare for å vise at du kan ha private metoder i koden din. Resten av koden er den samme som før.

De andre prosjektene er fra [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/aspire-overview). Å ha .NET Aspire i løsningen vil forbedre utvikleropplevelsen under utvikling og testing, og hjelpe med observabilitet. Det er ikke nødvendig for å kjøre serveren, men det er en god praksis å ha det i løsningen din.

## Start serveren lokalt

1. Fra VS Code (med C# DevKit-utvidelsen), naviger ned til `04-PracticalImplementation/samples/csharp`-mappen.
1. Kjør følgende kommando for å starte serveren:

   ```bash
    dotnet watch run --project ./src/AppHost
   ```

1. Når en nettleser åpner .NET Aspire-dashboardet, legg merke til `http`-URL-en. Den skal være noe sånt som `http://localhost:5058/`.

   ![.NET Aspire Dashboard](../../../../../translated_images/dotnet-aspire-dashboard.0a7095710e9301e90df2efd867e1b675b3b9bc2ccd7feb1ebddc0751522bc37c.no.png)

## Test Streamable HTTP med MCP Inspector

Hvis du har Node.js 22.7.5 eller nyere, kan du bruke MCP Inspector for å teste serveren din.

Start serveren og kjør følgende kommando i en terminal:

```bash
npx @modelcontextprotocol/inspector http://localhost:5058
```

![MCP Inspector](../../../../../translated_images/mcp-inspector.c223422b9b494fb4a518a3b3911b3e708e6a5715069470f9163ee2ee8d5f1ba9.no.png)

- Velg `Streamable HTTP` as the Transport type.
- In the Url field, enter the URL of the server noted earlier, and append `/mcp`. Det skal være `http` (ikke `https`) something like `http://localhost:5058/mcp`.
- select the Connect button.

A nice thing about the Inspector is that it provide a nice visibility on what is happening.

- Try listing the available tools
- Try some of them, it should works just like before.

## Test MCP Server with GitHub Copilot Chat in VS Code

To use the Streamable HTTP transport with GitHub Copilot Chat, change the configuration of the `calc-mcp` server opprettet tidligere for å se slik ut:

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "http://localhost:5058/mcp"
    }
  }
}
```

Gjør noen tester:

- Be om "3 primtall etter 6780". Legg merke til hvordan Copilot bruker de nye verktøyene `NextFivePrimeNumbers` og kun returnerer de første 3 primtallene.
- Be om "7 primtall etter 111", for å se hva som skjer.
- Be om "John har 24 lollies og vil dele dem likt mellom sine 3 barn. Hvor mange lollies får hvert barn?", for å se hva som skjer.

## Distribuer serveren til Azure

La oss distribuere serveren til Azure slik at flere kan bruke den.

Fra en terminal, naviger til `04-PracticalImplementation/samples/csharp`-mappen og kjør følgende kommando:

```bash
azd up
```

Når distribusjonen er ferdig, skal du se en melding som denne:

![Azd deployment success](../../../../../translated_images/azd-deployment-success.bd42940493f1b834a5ce6251a6f88966546009b350df59d0cc4a8caabe94a4f1.no.png)

Ta tak i URL-en og bruk den i MCP Inspector og i GitHub Copilot Chat.

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "https://calc-mcp.gentleriver-3977fbcf.australiaeast.azurecontainerapps.io/mcp"
    }
  }
}
```

## Hva nå?

Vi prøver forskjellige transporttyper og testverktøy. Vi distribuerer også MCP-serveren til Azure. Men hva om serveren vår trenger tilgang til private ressurser? For eksempel en database eller en privat API? I neste kapittel skal vi se på hvordan vi kan forbedre sikkerheten til serveren vår.

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.