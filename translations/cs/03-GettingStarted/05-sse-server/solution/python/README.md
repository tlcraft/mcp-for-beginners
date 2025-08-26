<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "69ba3bd502bd743233137bac5539c08b",
  "translation_date": "2025-08-19T15:43:54+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "cs"
}
-->
# Spuštění tohoto příkladu

Doporučuje se nainstalovat `uv`, ale není to nutné, viz [instrukce](https://docs.astral.sh/uv/#highlights)

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
uvicorn server:app
```

## -4- Testování příkladu

S běžícím serverem v jednom terminálu otevřete další terminál a spusťte následující příkaz:

```bash
mcp dev server.py
```

Tím by se měl spustit webový server s vizuálním rozhraním, které vám umožní testovat příklad.

Jakmile je server připojen:

- zkuste vypsat nástroje a spustit `add` s argumenty 2 a 4, měli byste vidět výsledek 6.
- přejděte na resources a resource template a zavolejte get_greeting, zadejte jméno a měli byste vidět pozdrav s uvedeným jménem.

### Testování v režimu CLI

Inspektor, který jste spustili, je ve skutečnosti aplikace Node.js a `mcp dev` je obal kolem ní.

Můžete jej spustit přímo v režimu CLI pomocí následujícího příkazu:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
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

Pro spuštění nástroje zadejte:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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

> [!TIP]  
> Obvykle je mnohem rychlejší spustit inspektor v režimu CLI než v prohlížeči.  
> Více o inspektoru si můžete přečíst [zde](https://github.com/modelcontextprotocol/inspector).

**Upozornění**:  
Tento dokument byl přeložen pomocí služby pro automatický překlad [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o co největší přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho původním jazyce by měl být považován za závazný zdroj. Pro důležité informace doporučujeme profesionální lidský překlad. Neodpovídáme za žádná nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.