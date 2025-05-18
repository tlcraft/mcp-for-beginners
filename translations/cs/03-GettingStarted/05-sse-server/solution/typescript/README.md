<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:12:33+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "cs"
}
-->
# Spuštění tohoto příkladu

## -1- Instalace závislostí

```bash
npm install
```

## -3- Spuštění příkladu

```bash
npm run build
```

## -4- Testování příkladu

S běžícím serverem v jednom terminálu otevřete další terminál a spusťte následující příkaz:

```bash
npm run inspector
```

Tím by se měl spustit webový server s vizuálním rozhraním, které vám umožní testovat příklad.

Jakmile je server připojen:

- zkuste vypsat nástroje a spusťte `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build`.

- V samostatném terminálu spusťte následující příkaz:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Tím se vypíšou všechny dostupné nástroje na serveru. Měli byste vidět následující výstup:

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

- Vyvolejte typ nástroje zadáním následujícího příkazu:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Měli byste vidět následující výstup:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> Obvykle je mnohem rychlejší spustit inspektor v režimu CLI než v prohlížeči.
> Přečtěte si více o inspektoru [zde](https://github.com/modelcontextprotocol/inspector).

**Upozornění**:  
Tento dokument byl přeložen pomocí AI překladové služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože se snažíme o přesnost, mějte na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Neodpovídáme za žádné nedorozumění nebo mylné interpretace vyplývající z použití tohoto překladu.