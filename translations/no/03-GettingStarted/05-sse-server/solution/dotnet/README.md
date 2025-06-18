<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T06:01:48+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "no"
}
-->
# Kjøre dette eksempelet

## -1- Installer avhengighetene

```bash
dotnet restore
```

## -2- Kjør eksempelet

```bash
dotnet run
```

## -3- Test eksempelet

Start et eget terminalvindu før du kjører kommandoen nedenfor (sørg for at serveren fortsatt kjører).

Med serveren i gang i ett terminalvindu, åpne et annet terminalvindu og kjør følgende kommando:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Dette skal starte en webserver med et visuelt grensesnitt som lar deg teste eksempelet.

> Pass på at **SSE** er valgt som transporttype, og at URL-en er `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`, med argumentene 2 og 4, da skal du se 6 i resultatet.
- gå til resources og resource template og kall "greeting", skriv inn et navn, og du skal se en hilsen med navnet du oppga.

### Testing i CLI-modus

Du kan starte det direkte i CLI-modus ved å kjøre følgende kommando:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Dette vil liste opp alle verktøyene som er tilgjengelige på serveren. Du skal se følgende output:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

For å kalle et verktøy, skriv:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Du skal se følgende output:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Det går som regel mye raskere å kjøre inspektøren i CLI-modus enn i nettleseren.
> Les mer om inspektøren [her](https://github.com/modelcontextprotocol/inspector).

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på dets opprinnelige språk skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.