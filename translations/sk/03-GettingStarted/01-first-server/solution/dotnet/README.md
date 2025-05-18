<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:12:13+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "sk"
}
-->
# Spustenie tejto ukážky

## -1- Nainštalujte závislosti

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Spustite ukážku

```bash
dotnet run
```

## -4- Otestujte ukážku

So spusteným serverom v jednom termináli, otvorte ďalší terminál a spustite nasledujúci príkaz:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Toto by malo spustiť webový server s vizuálnym rozhraním, ktoré vám umožní otestovať ukážku.

Keď je server pripojený:

- skúste zoznam nástrojov a spustite `add` s argumentmi 2 a 4, mali by ste vidieť výsledok 6.
- choďte na zdroje a šablónu zdroja a zavolajte "greeting", zadajte meno a mali by ste vidieť pozdrav s uvedeným menom.

### Testovanie v režime CLI

Môžete ho spustiť priamo v režime CLI spustením nasledujúceho príkazu:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Toto vypíše všetky nástroje dostupné na serveri. Mali by ste vidieť nasledujúci výstup:

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

Na spustenie nástroja zadajte:

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
> Zvyčajne je oveľa rýchlejšie spustiť inšpektora v režime CLI ako v prehliadači.
> Viac o inšpektorovi si prečítajte [tu](https://github.com/modelcontextprotocol/inspector).

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, upozorňujeme, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.