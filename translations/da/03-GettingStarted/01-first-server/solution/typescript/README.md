<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-07-13T18:05:55+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "da"
}
-->
# Kør dette eksempel

Det anbefales at installere `uv`, men det er ikke et krav, se [instructions](https://docs.astral.sh/uv/#highlights)

## -1- Installer afhængighederne

```bash
npm install
```

## -3- Kør eksemplet

```bash
npm run build
```

## -4- Test eksemplet

Med serveren kørende i et terminalvindue, åbn et andet terminalvindue og kør følgende kommando:

```bash
npm run inspector
```

Dette skulle starte en webserver med en visuel grænseflade, der giver dig mulighed for at teste eksemplet.

Når serveren er tilsluttet:

- prøv at liste værktøjer og kør `add` med argumenterne 2 og 4, du skulle se 6 som resultat.
- gå til resources og resource template og kald "greeting", indtast et navn, og du skulle se en hilsen med det navn, du har angivet.

### Test i CLI-tilstand

Inspektøren, du kørte, er faktisk en Node.js-app, og `mcp dev` er en wrapper omkring den.

Du kan starte den direkte i CLI-tilstand ved at køre følgende kommando:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
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
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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