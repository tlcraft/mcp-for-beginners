<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:10:10+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "no"
}
-->
# Kjøre dette eksempelet

## -1- Installer avhengighetene

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Kjør eksempelet

```bash
dotnet run
```

## -4- Test eksempelet

Med serveren kjørende i ett terminalvindu, åpne et annet terminalvindu og kjør følgende kommando:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Dette skal starte en webserver med et visuelt grensesnitt som lar deg teste eksempelet.

Når serveren er tilkoblet:

- prøv å liste verktøyene og kjør `add` med argumentene 2 og 4, du skal se 6 i resultatet.
- gå til ressurser og ressursmal og kall "greeting", skriv inn et navn, og du skal se en hilsen med navnet du oppga.

### Testing i CLI-modus

Du kan starte det direkte i CLI-modus ved å kjøre følgende kommando:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Dette vil liste alle verktøyene tilgjengelige på serveren. Du skal se følgende utdata:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

For å bruke et verktøy, skriv:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Du skal se følgende utdata:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Det er vanligvis mye raskere å kjøre inspiseren i CLI-modus enn i nettleseren.
> Les mer om inspiseren [her](https://github.com/modelcontextprotocol/inspector).

**Ansvarsfraskrivelse**:  
Dette dokumentet har blitt oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Vi streber etter nøyaktighet, men vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.