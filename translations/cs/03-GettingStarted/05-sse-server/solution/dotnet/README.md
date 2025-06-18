<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T06:07:12+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "cs"
}
-->
# Spuštění tohoto příkladu

## -1- Nainstalujte závislosti

```bash
dotnet restore
```

## -2- Spusťte příklad

```bash
dotnet run
```

## -3- Otestujte příklad

Než spustíte níže uvedené příkazy, otevřete si samostatný terminál (ujistěte se, že server stále běží).

S běžícím serverem v jednom terminálu otevřete další terminál a spusťte následující příkaz:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Tím by se měl spustit webový server s vizuálním rozhraním, které vám umožní příklad otestovat.

> Ujistěte se, že jako typ přenosu je vybráno **SSE** a URL je `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`, se vstupními argumenty 2 a 4 byste měli vidět výsledek 6.
- přejděte na resources a resource template, zavolejte "greeting", zadejte jméno a měli byste vidět pozdrav s vámi zadaným jménem.

### Testování v režimu CLI

Přímo v režimu CLI můžete spustit příkazem:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Tím se zobrazí všechny nástroje dostupné na serveru. Měli byste vidět následující výstup:

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

Pro vyvolání nástroje zadejte:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> Obvykle je mnohem rychlejší spustit inspector v režimu CLI než v prohlížeči.
> Více informací o inspectoru najdete [zde](https://github.com/modelcontextprotocol/inspector).

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.