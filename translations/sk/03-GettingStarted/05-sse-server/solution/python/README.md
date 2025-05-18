<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:05:45+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "sk"
}
-->
# Spustenie tejto ukážky

Odporúčame nainštalovať `uv`, ale nie je to nevyhnutné, pozrite si [pokyny](https://docs.astral.sh/uv/#highlights).

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
mcp run server.py
```

## -4- Otestujte ukážku

S bežiacim serverom v jednom termináli otvorte ďalší terminál a spustite nasledujúci príkaz:

```bash
mcp dev server.py
```

Toto by malo spustiť webový server s vizuálnym rozhraním, ktoré vám umožní otestovať ukážku.

Keď je server pripojený:

- skúste vypísať nástroje a spustiť `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` je obálka okolo neho.

Môžete ho spustiť priamo v režime CLI pomocou nasledujúceho príkazu:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Toto vypíše všetky dostupné nástroje na serveri. Mali by ste vidieť nasledujúci výstup:

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
> Zvyčajne je oveľa rýchlejšie spustiť inspector v režime CLI než v prehliadači.
> Viac o inspectorovi si prečítajte [tu](https://github.com/modelcontextprotocol/inspector).

**Upozornenie**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, uvedomte si, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.