<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T06:06:34+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "hu"
}
-->
# A minta futtatása

## -1- Telepítsd a függőségeket

```bash
dotnet restore
```

## -3- Futtasd a mintát

```bash
dotnet run
```

## -4- Teszteld a mintát

Amíg a szerver fut az egyik terminálon, nyiss meg egy másik terminált, és futtasd a következő parancsot:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Ez elindít egy webes szervert vizuális felülettel, amely lehetővé teszi a minta tesztelését.

Miután a szerver csatlakozott:

- próbáld meg listázni az eszközöket, majd futtasd az `add` parancsot a 2 és 4 argumentumokkal, az eredménynek 6-nak kell lennie.
- menj a resources és resource template részhez, hívd meg a "greeting" funkciót, írj be egy nevet, és egy névre szóló üdvözletet kell kapnod.

### Tesztelés CLI módban

Közvetlenül CLI módban is elindíthatod a következő parancs futtatásával:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Ez kilistázza a szerveren elérhető összes eszközt. A következő kimenetet kell látnod:

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
> Általában sokkal gyorsabb az inspector futtatása CLI módban, mint a böngészőben.
> Olvass többet az inspector-ról [itt](https://github.com/modelcontextprotocol/inspector).

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum anyanyelvű változata tekintendő hivatalos forrásnak. Fontos információk esetén profi emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.