<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:04:05+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "nl"
}
-->
# Dit voorbeeld uitvoeren

Het wordt aanbevolen om `uv` te installeren, maar het is niet verplicht, zie [instructies](https://docs.astral.sh/uv/#highlights)

## -0- Maak een virtuele omgeving

```bash
python -m venv venv
```

## -1- Activeer de virtuele omgeving

```bash
venv\Scrips\activate
```

## -2- Installeer de afhankelijkheden

```bash
pip install "mcp[cli]"
```

## -3- Voer het voorbeeld uit

```bash
mcp run server.py
```

## -4- Test het voorbeeld

Met de server draaiend in één terminal, open een andere terminal en voer de volgende opdracht uit:

```bash
mcp dev server.py
```

Dit zou een webserver moeten starten met een visuele interface waarmee je het voorbeeld kunt testen.

Zodra de server is verbonden:

- probeer tools op te sommen en voer `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` uit, dit is een wrapper eromheen.

Je kunt het direct in CLI-modus starten door de volgende opdracht uit te voeren:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Dit zal alle beschikbare tools op de server opsommen. Je zou de volgende uitvoer moeten zien:

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

Om een tool aan te roepen, typ:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Je zou de volgende uitvoer moeten zien:

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
> Het is meestal veel sneller om de inspector in CLI-modus uit te voeren dan in de browser.
> Lees hier meer over de inspector [hier](https://github.com/modelcontextprotocol/inspector).

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, willen we u erop wijzen dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of misinterpretaties die voortvloeien uit het gebruik van deze vertaling.