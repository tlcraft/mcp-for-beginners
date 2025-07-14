<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-13T18:00:40+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "no"
}
-->
# Kjøre dette eksempelet

Det anbefales å installere `uv`, men det er ikke et krav, se [instruksjoner](https://docs.astral.sh/uv/#highlights)

## -0- Opprett et virtuelt miljø

```bash
python -m venv venv
```

## -1- Aktiver det virtuelle miljøet

```bash
venv\Scrips\activate
```

## -2- Installer avhengighetene

```bash
pip install "mcp[cli]"
```

## -3- Kjør eksempelet


```bash
mcp run server.py
```

## -4- Test eksempelet

Med serveren kjørende i ett terminalvindu, åpne et nytt terminalvindu og kjør følgende kommando:

```bash
mcp dev server.py
```

Dette skal starte en webserver med et visuelt grensesnitt som lar deg teste eksempelet.

Når serveren er tilkoblet:

- prøv å liste opp verktøy og kjør `add` med argumentene 2 og 4, du skal se 6 som resultat.

- gå til resources og resource template og kall get_greeting, skriv inn et navn og du skal se en hilsen med navnet du oppga.

### Testing i CLI-modus

Inspektøren du kjørte er egentlig en Node.js-app, og `mcp dev` er et wrapper rundt den.

Du kan starte den direkte i CLI-modus ved å kjøre følgende kommando:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Dette vil liste opp alle verktøyene som er tilgjengelige på serveren. Du skal se følgende output:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

For å kalle et verktøy, skriv:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.