<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:03:43+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "no"
}
-->
# Kjøre dette eksemplet

Det anbefales å installere `uv`, men det er ikke nødvendig, se [instruksjoner](https://docs.astral.sh/uv/#highlights)

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

## -3- Kjør eksemplet

```bash
mcp run server.py
```

## -4- Test eksemplet

Med serveren kjørende i en terminal, åpne en annen terminal og kjør følgende kommando:

```bash
mcp dev server.py
```

Dette bør starte en webserver med et visuelt grensesnitt som lar deg teste eksemplet.

Når serveren er tilkoblet:

- prøv å liste verktøyene og kjør `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` er en innpakning rundt det.

Du kan starte det direkte i CLI-modus ved å kjøre følgende kommando:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Dette vil liste alle verktøyene som er tilgjengelige på serveren. Du bør se følgende output:

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

For å bruke et verktøy, skriv:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Du bør se følgende output:

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
> Det er vanligvis mye raskere å kjøre inspektøren i CLI-modus enn i nettleseren.
> Les mer om inspektøren [her](https://github.com/modelcontextprotocol/inspector).

I'm sorry, but I need clarification on what you mean by "Translate the following text to no." Could you please specify the language you would like the text translated into?