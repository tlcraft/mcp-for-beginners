<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:19:00+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "hu"
}
-->
# A minta futtatása

## -1- Telepítsd a függőségeket

```bash
dotnet restore
```

## -2- Futtasd a mintát

```bash
dotnet run
```

## -3- Teszteld a mintát

Indíts el egy külön terminált, mielőtt lefuttatod az alábbi parancsot (győződj meg róla, hogy a szerver még fut).

Amíg a szerver az egyik terminálban fut, nyiss meg egy másik terminált, és futtasd a következő parancsot:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Ez elindít egy webszervert vizuális felülettel, amely lehetővé teszi a minta tesztelését.

> Győződj meg róla, hogy a **Streamable HTTP** van kiválasztva szállítási típusnak, és az URL `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, az argumentumok pedig 2 és 4, így az eredményben 6-ot kell látnod.
- Lépj a resources és resource template részhez, hívd meg a "greeting"-et, írj be egy nevet, és a megadott névvel egy üdvözlést kell látnod.

### Tesztelés CLI módban

Közvetlenül CLI módban is elindíthatod a következő paranccsal:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Ez kilistázza a szerveren elérhető összes eszközt. A következő kimenetet kell látnod:

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

Egy eszköz meghívásához írd be:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

A következő kimenetet kell látnod:

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
> Általában sokkal gyorsabb az inspector CLI módban, mint a böngészőben futtatni.
> További információ az inspector-ról [itt](https://github.com/modelcontextprotocol/inspector).

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum a saját nyelvén tekintendő hivatalos forrásnak. Kritikus információk esetén profi emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy téves értelmezésekért.