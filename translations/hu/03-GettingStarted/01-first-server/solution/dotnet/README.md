<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:11:55+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "hu"
}
-->
# A minta futtatása

## -1- Telepítsd a függőségeket

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Futtasd a mintát

```bash
dotnet run
```

## -4- Teszteld a mintát

Amikor a szerver fut az egyik terminálban, nyiss meg egy másik terminált, és futtasd a következő parancsot:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Ez elindít egy webszervert vizuális felülettel, amely lehetővé teszi a minta tesztelését.

Miután a szerver csatlakozott:

- próbáld meg listázni az eszközöket és futtatni az `add`-ot, 2 és 4 argumentummal, a 6-ot kell látnod eredményként.
- menj az erőforrásokhoz és az erőforrás sablonhoz, hívd meg a "greeting"-et, írj be egy nevet, és látni fogsz egy üdvözlést az általad megadott névvel.

### Tesztelés CLI módban

Közvetlenül CLI módban indíthatod el a következő parancs futtatásával:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Ez felsorolja az összes eszközt, amely elérhető a szerveren. A következő kimenetet kell látnod:

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

Egy eszköz meghívásához írd be:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

A következő kimenetet kell látnod:

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
> Általában sokkal gyorsabb CLI módban futtatni az inspektort, mint a böngészőben.
> További információ az inspektorról [itt](https://github.com/modelcontextprotocol/inspector).

**Felelősség kizárása**:  
Ezt a dokumentumot az AI fordítási szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén ajánlott a professzionális emberi fordítás. Nem vállalunk felelősséget semmilyen félreértésért vagy félremagyarázásért, amely a fordítás használatából ered.