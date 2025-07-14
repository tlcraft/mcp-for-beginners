<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-07-13T18:07:13+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "sk"
}
-->
# Spustenie tohto príkladu

Odporúča sa nainštalovať `uv`, ale nie je to povinné, pozrite si [návod](https://docs.astral.sh/uv/#highlights)

## -1- Nainštalujte závislosti

```bash
npm install
```

## -3- Spustite príklad


```bash
npm run build
```

## -4- Otestujte príklad

Keď máte server spustený v jednom termináli, otvorte ďalší terminál a spustite nasledujúci príkaz:

```bash
npm run inspector
```

Týmto by sa mal spustiť webový server s vizuálnym rozhraním, ktoré vám umožní otestovať príklad.

Keď je server pripojený:

- skúste zobraziť zoznam nástrojov a spustiť `add` s argumentmi 2 a 4, výsledok by mal byť 6.
- prejdite na resources a resource template a zavolajte "greeting", zadajte meno a mali by ste vidieť pozdrav s menom, ktoré ste zadali.

### Testovanie v CLI režime

Inspector, ktorý ste spustili, je vlastne Node.js aplikácia a `mcp dev` je jej obal.

Môžete ho spustiť priamo v CLI režime pomocou nasledujúceho príkazu:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Týmto sa zobrazia všetky nástroje dostupné na serveri. Mali by ste vidieť nasledujúci výstup:

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

Na spustenie nástroja zadajte:

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
> Zvyčajne je oveľa rýchlejšie spustiť inspector v CLI režime než v prehliadači.
> Viac o inspectore si prečítate [tu](https://github.com/modelcontextprotocol/inspector).

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.