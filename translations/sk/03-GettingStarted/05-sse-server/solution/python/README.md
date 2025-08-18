<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "69ba3bd502bd743233137bac5539c08b",
  "translation_date": "2025-08-18T15:38:38+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "sk"
}
-->
# Spustenie tejto ukážky

Odporúča sa nainštalovať `uv`, ale nie je to nevyhnutné, pozrite si [inštrukcie](https://docs.astral.sh/uv/#highlights)

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

Týmto sa spustí webový server s vizuálnym rozhraním, ktoré vám umožní otestovať ukážku.

Keď sa server pripojí:

- skúste zobraziť zoznam nástrojov a spustite `add` s argumentmi 2 a 4, v výsledku by ste mali vidieť číslo 6.
- prejdite na zdroje a šablónu zdrojov a zavolajte funkciu get_greeting, zadajte meno a mali by ste vidieť pozdrav s menom, ktoré ste zadali.

### Testovanie v režime CLI

Inšpektor, ktorý ste spustili, je v skutočnosti aplikácia Node.js a `mcp dev` je jej obal.

Môžete ho spustiť priamo v režime CLI pomocou nasledujúceho príkazu:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Týmto sa zobrazí zoznam všetkých nástrojov dostupných na serveri. Mali by ste vidieť nasledujúci výstup:

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

Ak chcete spustiť nástroj, zadajte:

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
> Zvyčajne je oveľa rýchlejšie spustiť inšpektora v režime CLI ako v prehliadači.
> Viac o inšpektorovi si prečítajte [tu](https://github.com/modelcontextprotocol/inspector).

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nenesieme zodpovednosť za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.