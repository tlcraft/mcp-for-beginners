<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:21:57+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "cs"
}
-->
# Spuštění tohoto příkladu

## -1- Nainstalujte závislosti

```bash
npm install
```

## -3- Spusťte příklad


```bash
npm run build
```

## -4- Otestujte příklad

Se spuštěným serverem v jednom terminálu otevřete další terminál a spusťte následující příkaz:

```bash
npm run inspector
```

Tím by se měl spustit webový server s vizuálním rozhraním, které vám umožní příklad otestovat.

Jakmile je server připojen:

- zkuste vypsat nástroje a spustit `add` s argumenty 2 a 4, v výsledku byste měli vidět 6.
- přejděte na resources a resource template a zavolejte "greeting", zadejte jméno a měli byste vidět pozdrav s vámi zadaným jménem.

### Testování v režimu CLI

Inspector, který jste spustili, je vlastně Node.js aplikace a `mcp dev` je její obal.

- Spusťte server příkazem `npm run build`.

- V jiném terminálu spusťte následující příkaz:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Tím se vypíšou všechny nástroje dostupné na serveru. Měli byste vidět následující výstup:

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

- Zavolejte typ nástroje zadáním následujícího příkazu:

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
> Obvykle je mnohem rychlejší spustit inspector v režimu CLI než v prohlížeči.
> Více o inspectoru si přečtěte [zde](https://github.com/modelcontextprotocol/inspector).

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.