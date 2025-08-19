<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d26f746e21775c30b4d7ed97962b24df",
  "translation_date": "2025-08-19T16:08:31+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "sk"
}
-->
# Spustenie tejto ukážky

Odporúča sa nainštalovať `uv`, ale nie je to povinné, pozrite si [pokyny](https://docs.astral.sh/uv/#highlights)

## -0- Vytvorte virtuálne prostredie

```bash
python -m venv venv
```

## -1- Aktivujte virtuálne prostredie

```bash
venv\Scripts\activate
```

## -2- Nainštalujte závislosti

```bash
pip install "mcp[cli]"
```

## -3- Spustite ukážku

```bash
mcp run server.py
```

## -4- Otestujte ukážku

Keď server beží v jednom termináli, otvorte ďalší terminál a spustite nasledujúci príkaz:

```bash
mcp dev server.py
```

Tým by sa mal spustiť webový server s vizuálnym rozhraním, ktoré vám umožní otestovať ukážku.

Keď je server pripojený:

- skúste zobraziť zoznam nástrojov a spustiť `add` s argumentmi 2 a 4, mali by ste vidieť výsledok 6.

- prejdite na zdroje a šablónu zdroja a zavolajte get_greeting, zadajte meno a mali by ste vidieť pozdrav s menom, ktoré ste zadali.

### Testovanie v režime CLI

Inšpektor, ktorý ste spustili, je vlastne aplikácia Node.js a `mcp dev` je obal okolo nej.

Môžete ho spustiť priamo v režime CLI pomocou nasledujúceho príkazu:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
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

Na spustenie nástroja zadajte:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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

> [!TIP]
> Zvyčajne je oveľa rýchlejšie spustiť inšpektora v režime CLI ako v prehliadači.
> Viac o inšpektorovi si prečítajte [tu](https://github.com/modelcontextprotocol/inspector).

**Upozornenie**:  
Tento dokument bol preložený pomocou služby na automatický preklad [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, upozorňujeme, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nezodpovedáme za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.