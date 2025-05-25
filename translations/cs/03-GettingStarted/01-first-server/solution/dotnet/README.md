<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:12:04+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "cs"
}
-->
# Spuštění tohoto příkladu

## -1- Nainstalujte závislosti

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Spusťte příklad

```bash
dotnet run
```

## -4- Otestujte příklad

S běžícím serverem v jednom terminálu otevřete další terminál a spusťte následující příkaz:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

To by mělo spustit webový server s vizuálním rozhraním, které vám umožní otestovat příklad.

Jakmile je server připojen:

- zkuste vypsat nástroje a spusťte `add` s argumenty 2 a 4, měli byste vidět výsledek 6.
- přejděte na zdroje a šablonu zdrojů a zavolejte "greeting", zadejte jméno a měli byste vidět pozdrav se jménem, které jste zadali.

### Testování v režimu CLI

Můžete jej spustit přímo v režimu CLI spuštěním následujícího příkazu:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Tím se vypíší všechny nástroje dostupné na serveru. Měli byste vidět následující výstup:

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

Pro vyvolání nástroje zadejte:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Měli byste vidět následující výstup:

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
> Obvykle je mnohem rychlejší spustit inspektor v režimu CLI než v prohlížeči.
> Přečtěte si více o inspektoru [zde](https://github.com/modelcontextprotocol/inspector).

**Prohlášení**:  
Tento dokument byl přeložen pomocí služby AI pro překlad [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, vezměte prosím na vědomí, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nezodpovídáme za žádná nedorozumění nebo mylné interpretace vyplývající z použití tohoto překladu.