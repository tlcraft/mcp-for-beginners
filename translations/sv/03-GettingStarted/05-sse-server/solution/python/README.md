<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:03:22+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "sv"
}
-->
# Köra detta exempel

Det rekommenderas att installera `uv` men det är inget måste, se [instruktioner](https://docs.astral.sh/uv/#highlights)

## -0- Skapa en virtuell miljö

```bash
python -m venv venv
```

## -1- Aktivera den virtuella miljön

```bash
venv\Scrips\activate
```

## -2- Installera beroenden

```bash
pip install "mcp[cli]"
```

## -3- Kör exemplet

```bash
mcp run server.py
```

## -4- Testa exemplet

Med servern igång i en terminal, öppna en annan terminal och kör följande kommando:

```bash
mcp dev server.py
```

Detta bör starta en webbserver med ett visuellt gränssnitt som låter dig testa exemplet.

När servern är ansluten:

- försök lista verktyg och kör `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` är en omslag kring det.

Du kan starta det direkt i CLI-läge genom att köra följande kommando:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Detta kommer att lista alla verktyg som finns tillgängliga på servern. Du bör se följande output:

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

För att anropa ett verktyg skriv:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Du bör se följande output:

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
> Det är vanligtvis mycket snabbare att köra inspektorn i CLI-läge än i webbläsaren.
> Läs mer om inspektorn [här](https://github.com/modelcontextprotocol/inspector).

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen var medveten om att automatiserade översättningar kan innehålla fel eller felaktigheter. Det ursprungliga dokumentet på dess ursprungliga språk bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.