<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T06:07:39+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "sk"
}
-->
# Spustenie tohto príkladu

## -1- Nainštalujte závislosti

```bash
dotnet restore
```

## -3- Spustite príklad


```bash
dotnet run
```

## -4- Otestujte príklad

Keď máte server spustený v jednom termináli, otvorte ďalší terminál a spustite nasledujúci príkaz:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Tým sa spustí webový server s vizuálnym rozhraním, ktoré vám umožní testovať príklad.

Keď je server pripojený:

- skúste vypísať nástroje a spustiť `add` s argumentmi 2 a 4, výsledok by mal byť 6.
- prejdite na resources a resource template a zavolajte "greeting", zadajte meno a mali by ste vidieť pozdrav s menom, ktoré ste zadali.

### Testovanie v CLI režime

Môžete ho spustiť priamo v CLI režime pomocou nasledujúceho príkazu:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Tým sa zobrazia všetky nástroje dostupné na serveri. Mali by ste vidieť nasledujúci výstup:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Na vyvolanie nástroja zadajte:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Mali by ste vidieť nasledujúci výstup:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Bežne je oveľa rýchlejšie spustiť inspector v CLI režime ako v prehliadači.
> Viac o inspektorovi sa dozviete [tu](https://github.com/modelcontextprotocol/inspector).

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nezodpovedáme za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.