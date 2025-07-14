<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:21:09+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "nl"
}
-->
# Deze sample uitvoeren

## -1- Installeer de dependencies

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

Zodra de server verbonden is:

- probeer tools op te sommen en voer `add` uit met argumenten 2 en 4, je zou 6 als resultaat moeten zien.
- ga naar resources en resource template en roep "greeting" aan, typ een naam in en je zou een begroeting met de door jou opgegeven naam moeten zien.

### Testen in CLI-modus

De inspector die je hebt gestart is eigenlijk een Node.js-app en `mcp dev` is een wrapper daaromheen.

- Start de server met het commando `npm run build`.

- Voer in een aparte terminal het volgende commando uit:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Dit zal alle beschikbare tools op de server weergeven. Je zou de volgende output moeten zien:

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

- Roep een tool type aan door het volgende commando te typen:

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
> Lees meer over de inspector [hier](https://github.com/modelcontextprotocol/inspector).

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.