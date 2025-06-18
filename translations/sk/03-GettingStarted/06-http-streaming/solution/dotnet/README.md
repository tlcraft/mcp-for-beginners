<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:19:12+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "sk"
}
-->
# Spustenie tohto príkladu

## -1- Inštalácia závislostí

```bash
dotnet restore
```

## -2- Spustenie príkladu

```bash
dotnet run
```

## -3- Testovanie príkladu

Pred spustením nasledujúceho príkazu otvorte samostatný terminál (uistite sa, že server stále beží).

Keď server beží v jednom termináli, otvorte ďalší terminál a spustite nasledujúci príkaz:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Tým by sa mal spustiť webový server s vizuálnym rozhraním, ktoré vám umožní testovať príklad.

> Uistite sa, že ako typ prenosu je vybrané **Streamable HTTP** a URL je `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, s argumentmi 2 a 4 by ste mali vidieť výsledok 6.
- prejdite do resources a resource template, zavolajte "greeting", zadajte meno a mali by ste vidieť pozdrav s menom, ktoré ste zadali.

### Testovanie v CLI režime

Môžete ho spustiť priamo v CLI režime pomocou nasledujúceho príkazu:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Tým sa zobrazia všetky nástroje dostupné na serveri. Mali by ste vidieť nasledujúci výstup:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Na spustenie nástroja zadajte:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> Viac o inspectorovi si prečítate [tu](https://github.com/modelcontextprotocol/inspector).

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.