<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-09T23:14:11+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "cs"
}
-->
# Spuštění tohoto příkladu

Doporučujeme nainstalovat `uv`, ale není to nutné, viz [návod](https://docs.astral.sh/uv/#highlights)

## -0- Vytvoření virtuálního prostředí

```bash
python -m venv venv
```

## -1- Aktivace virtuálního prostředí

```bash
venv\Scrips\activate
```

## -2- Instalace závislostí

```bash
pip install "mcp[cli]"
```

## -3- Spuštění příkladu

```bash
mcp run server.py
```

## -4- Testování příkladu

Se spuštěným serverem v jednom terminálu otevřete další terminál a spusťte následující příkaz:

```bash
mcp dev server.py
```

Tím by se měl spustit webový server s vizuálním rozhraním, které vám umožní příklad otestovat.

Jakmile je server připojen:

- zkuste vypsat nástroje a spustit `add` s argumenty 2 a 4, ve výsledku byste měli vidět 6.

- přejděte na resources a resource template a zavolejte get_greeting, zadejte jméno a měli byste vidět pozdrav s vámi zadaným jménem.

### Testování v CLI režimu

Inspector, který jste spustili, je vlastně Node.js aplikace a `mcp dev` je její obal.

Můžete ji spustit přímo v CLI režimu pomocí následujícího příkazu:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Tím se vypíší všechny nástroje dostupné na serveru. Měli byste vidět následující výstup:

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

Pro vyvolání nástroje napište:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Měli byste vidět následující výstup:

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
> Obvykle je mnohem rychlejší spustit inspector v CLI režimu než v prohlížeči.
> Více o inspectoru si přečtěte [zde](https://github.com/modelcontextprotocol/inspector).

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.