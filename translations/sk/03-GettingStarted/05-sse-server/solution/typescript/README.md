<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:12:44+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "sk"
}
-->
# Spustenie tejto ukážky

## -1- Nainštalujte závislosti

```bash
npm install
```

## -3- Spustite ukážku

```bash
npm run build
```

## -4- Otestujte ukážku

So spusteným serverom v jednom termináli otvorte ďalší terminál a spustite nasledujúci príkaz:

```bash
npm run inspector
```

Tým by sa mal spustiť webový server s vizuálnym rozhraním, ktoré vám umožní otestovať ukážku.

Keď je server pripojený:

- skúste zoznam nástrojov a spustite `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build`.

- V samostatnom termináli spustite nasledujúci príkaz:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Toto zobrazí všetky nástroje dostupné na serveri. Mali by ste vidieť nasledujúci výstup:

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

- Vyvolajte typ nástroja zadaním nasledujúceho príkazu:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Mali by ste vidieť nasledujúci výstup:

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
> Zvyčajne je oveľa rýchlejšie spustiť inšpektor v režime CLI než v prehliadači.
> Viac o inšpektore si prečítajte [tu](https://github.com/modelcontextprotocol/inspector).

**Upozornenie**:  
Tento dokument bol preložený pomocou služby prekladania AI [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, uvedomte si, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by sa mal považovať za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nezodpovedáme za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.