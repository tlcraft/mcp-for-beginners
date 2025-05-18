<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:26:24+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "sk"
}
-->
# Spustenie tejto ukážky

Odporúča sa nainštalovať `uv`, ale nie je to povinné, pozrite si [pokyny](https://docs.astral.sh/uv/#highlights)

## -1- Inštalácia závislostí

```bash
npm install
```

## -3- Spustenie ukážky

```bash
npm run build
```

## -4- Testovanie ukážky

So spusteným serverom v jednom termináli otvorte ďalší terminál a spustite nasledujúci príkaz:

```bash
npm run inspector
```

Toto by malo spustiť webový server s vizuálnym rozhraním, ktoré vám umožní otestovať ukážku.

Keď je server pripojený:

- skúste vypísať nástroje a spustiť `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` je obal okolo neho.

Môžete ho spustiť priamo v režime CLI pomocou nasledujúceho príkazu:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Toto vypíše všetky nástroje dostupné na serveri. Mali by ste vidieť nasledujúci výstup:

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

Na vyvolanie nástroja zadajte:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Mali by ste vidieť nasledujúci výstup:

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
> Zvyčajne je oveľa rýchlejšie spustiť inspector v režime CLI než v prehliadači.
> Prečítajte si viac o inspectorovi [tu](https://github.com/modelcontextprotocol/inspector).

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladov [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, uvedomte si, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.