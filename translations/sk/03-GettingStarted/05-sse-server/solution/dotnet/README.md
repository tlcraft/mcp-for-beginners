<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:58:39+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "sk"
}
-->
# Spustenie tejto ukážky

## -1- Nainštalujte závislosti

```bash
dotnet run
```

## -2- Spustite ukážku

```bash
dotnet run
```

## -3- Otestujte ukážku

Predtým, než spustíte nižšie uvedené, otvorte samostatný terminál (uistite sa, že server stále beží).

Keď server beží v jednom termináli, otvorte ďalší terminál a spustite nasledujúci príkaz:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Toto by malo spustiť webový server s vizuálnym rozhraním, ktoré vám umožní testovať ukážku.

Keď je server pripojený:

- skúste zobraziť zoznam nástrojov a spustite `add` s argumentmi 2 a 4, mali by ste vidieť výsledok 6.
- choďte na zdroje a šablónu zdroja a zavolajte "greeting", zadajte meno a mali by ste vidieť pozdrav s menom, ktoré ste poskytli.

### Testovanie v režime CLI

Môžete ho spustiť priamo v režime CLI spustením nasledujúceho príkazu:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Tým sa zobrazí zoznam všetkých nástrojov dostupných na serveri. Mali by ste vidieť nasledujúci výstup:

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

Na vyvolanie nástroja napíšte:

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

> [!TIP]
> Zvyčajne je oveľa rýchlejšie spustiť inšpektor v režime CLI než v prehliadači.
> Viac o inšpektore si môžete prečítať [tu](https://github.com/modelcontextprotocol/inspector).

**Upozornenie**:  
Tento dokument bol preložený pomocou AI prekladovej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, upozorňujeme, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho pôvodnom jazyku by sa mal považovať za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nezodpovedáme za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.