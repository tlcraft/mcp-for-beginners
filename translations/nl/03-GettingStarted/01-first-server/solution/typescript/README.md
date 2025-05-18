<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:24:45+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "nl"
}
-->
# Deze sample uitvoeren

Het wordt aanbevolen om `uv` te installeren, maar het is niet verplicht, zie [instructies](https://docs.astral.sh/uv/#highlights)

## -1- Installeer de afhankelijkheden

```bash
npm install
```

## -3- Voer de sample uit

```bash
npm run build
```

## -4- Test de sample

Met de server draaiend in één terminal, open je een andere terminal en voer je het volgende commando uit:

```bash
npm run inspector
```

Dit zou een webserver moeten starten met een visuele interface waarmee je de sample kunt testen.

Zodra de server is verbonden:

- probeer tools op te sommen en voer `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` uit als een wrapper eromheen.

Je kunt het direct in CLI-modus starten door het volgende commando uit te voeren:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Dit zal alle beschikbare tools in de server opsommen. Je zou de volgende uitvoer moeten zien:

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
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
Dit document is vertaald met behulp van de AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of misinterpretaties die voortvloeien uit het gebruik van deze vertaling.