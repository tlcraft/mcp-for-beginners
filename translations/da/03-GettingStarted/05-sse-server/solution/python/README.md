<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-07-13T20:15:39+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "da"
}
-->
# Kør dette eksempel

Det anbefales at installere `uv`, men det er ikke et krav, se [instruktioner](https://docs.astral.sh/uv/#highlights)

## -0- Opret et virtuelt miljø

```bash
python -m venv venv
```

## -1- Aktivér det virtuelle miljø

```bash
venv\Scrips\activate
```

## -2- Installer afhængighederne

```bash
pip install "mcp[cli]"
```

## -3- Kør eksemplet

```bash
mcp run server.py
```

## -4- Test eksemplet

Med serveren kørende i et terminalvindue, åbn et andet terminalvindue og kør følgende kommando:

```bash
mcp dev server.py
```

Dette skulle starte en webserver med en visuel grænseflade, der giver dig mulighed for at teste eksemplet.

Når serveren er tilsluttet:

- prøv at liste værktøjer og kør `add` med argumenterne 2 og 4, du skulle se 6 som resultat.
- gå til resources og resource template og kald get_greeting, indtast et navn, og du skulle se en hilsen med det navn, du har angivet.

### Test i CLI-tilstand

Inspektøren, du kørte, er faktisk en Node.js-app, og `mcp dev` er en wrapper omkring den.

Du kan starte den direkte i CLI-tilstand ved at køre følgende kommando:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Dette vil liste alle tilgængelige værktøjer på serveren. Du skulle se følgende output:

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

For at kalde et værktøj, skriv:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Du skulle se følgende output:

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
> Det er som regel meget hurtigere at køre inspektøren i CLI-tilstand end i browseren.
> Læs mere om inspektøren [her](https://github.com/modelcontextprotocol/inspector).

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.