<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:11:07+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "nl"
}
-->
# Dit voorbeeld uitvoeren

## -1- Installeer de afhankelijkheden

```bash
npm install
```

## -3- Voer het voorbeeld uit

```bash
npm run build
```

## -4- Test het voorbeeld

Met de server draaiend in één terminal, open een andere terminal en voer het volgende commando uit:

```bash
npm run inspector
```

Dit zou een webserver moeten starten met een visuele interface waarmee je het voorbeeld kunt testen.

Zodra de server is verbonden:

- probeer tools op te sommen en voer `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build` uit.

- Voer in een aparte terminal het volgende commando uit:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Dit zal alle beschikbare tools in de server opsommen. Je zou de volgende output moeten zien:

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

- Roep een tooltype aan door het volgende commando te typen:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Je zou de volgende output moeten zien:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> Het is meestal veel sneller om de inspector in CLI-modus te draaien dan in de browser.
> Lees hier meer over de inspector [hier](https://github.com/modelcontextprotocol/inspector).

**Disclaimer**:
Dit document is vertaald met behulp van AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we ons best doen voor nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in de oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.