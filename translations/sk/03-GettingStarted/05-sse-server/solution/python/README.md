<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-07-13T20:16:58+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "sk"
}
-->
# Spustenie tejto ukážky

Odporúča sa nainštalovať `uv`, ale nie je to povinné, pozrite si [návod](https://docs.astral.sh/uv/#highlights)

## -0- Vytvorte virtuálne prostredie

```bash
python -m venv venv
```

## -1- Aktivujte virtuálne prostredie

```bash
venv\Scrips\activate
```

## -2- Nainštalujte závislosti

```bash
pip install "mcp[cli]"
```

## -3- Spustite ukážku

```bash
uvicorn server:app
```

## -4- Otestujte ukážku

Keď server beží v jednom termináli, otvorte ďalší terminál a spustite nasledujúci príkaz:

```bash
mcp dev server.py
```

Týmto by sa mal spustiť webový server s vizuálnym rozhraním, ktoré vám umožní testovať príklad.

Keď sa server pripojí:

- skúste zobraziť zoznam nástrojov a spustiť `add` s argumentmi 2 a 4, výsledok by mal byť 6.
- prejdite na resources a resource template a zavolajte get_greeting, zadajte meno a mali by ste vidieť pozdrav s menom, ktoré ste zadali.

### Testovanie v režime CLI

Inspector, ktorý ste spustili, je vlastne Node.js aplikácia a `mcp dev` je jej obal.

Môžete ho spustiť priamo v režime CLI pomocou nasledujúceho príkazu:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Tým sa zobrazí zoznam všetkých nástrojov dostupných na serveri. Mali by ste vidieť nasledujúci výstup:

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
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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