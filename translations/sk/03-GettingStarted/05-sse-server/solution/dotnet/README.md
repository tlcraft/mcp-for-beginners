<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T06:07:45+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
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

Pred spustením nižšie uvedeného príkazu otvorte samostatný terminál (uistite sa, že server stále beží).

Keď server beží v jednom termináli, otvorte ďalší terminál a spustite nasledujúci príkaz:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Tým sa spustí webový server s vizuálnym rozhraním, ktoré vám umožní otestovať príklad.

> Uistite sa, že ako typ prenosu je zvolený **SSE** a URL je `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`, s argumentmi 2 a 4 by ste mali vidieť výsledok 6.
- prejdite na resources a resource template a zavolajte "greeting", zadajte meno a mali by ste vidieť pozdrav s menom, ktoré ste zadali.

### Testovanie v režime CLI

Môžete ho spustiť priamo v režime CLI pomocou nasledujúceho príkazu:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Tým sa zobrazia všetky nástroje dostupné na serveri. Mali by ste vidieť nasledovný výstup:

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

Ak chcete vyvolať nástroj, zadajte:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Mali by ste vidieť nasledovný výstup:

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
> Zvyčajne je oveľa rýchlejšie spustiť inspector v režime CLI ako v prehliadači.
> Viac o inspectore si prečítate [tu](https://github.com/modelcontextprotocol/inspector).

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, majte prosím na pamäti, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.