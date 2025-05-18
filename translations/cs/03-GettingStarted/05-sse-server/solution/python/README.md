<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:05:34+00:00",
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
mcp run server.py
```

## -4- Testování příkladu

S serverem spuštěným v jednom terminálu otevřete další terminál a spusťte následující příkaz:

```bash
mcp dev server.py
```

Tím by se měl spustit webový server s vizuálním rozhraním, které vám umožní testovat příklad.

Jakmile je server připojen:

- zkuste vypsat nástroje a spusťte `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev`, což je obal kolem něj.

Můžete jej spustit přímo v režimu CLI spuštěním následujícího příkazu:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

To vypíše všechny nástroje dostupné na serveru. Měli byste vidět následující výstup:

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

> ![!TIP]
> Obvykle je mnohem rychlejší spustit inspektor v režimu CLI než v prohlížeči.
> Přečtěte si více o inspektoru [zde](https://github.com/modelcontextprotocol/inspector).

**Zřeknutí se odpovědnosti**:  
Tento dokument byl přeložen pomocí služby pro automatický překlad [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.