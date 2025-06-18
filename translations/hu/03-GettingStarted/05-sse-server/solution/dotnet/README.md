<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T06:06:40+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
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

Indíts el egy külön terminált, mielőtt lefuttatnád a lentit (győződj meg róla, hogy a szerver még fut).

Amíg a szerver az egyik terminálon fut, nyiss meg egy másik terminált, és futtasd a következő parancsot:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Ez elindít egy webszervert vizuális felülettel, amely lehetővé teszi a minta tesztelését.

> Győződj meg róla, hogy a **SSE** van kiválasztva mint szállítási típus, az URL pedig `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`, az argumentumok pedig 2 és 4, így az eredményben 6-ot kell látnod.
- Lépj a resources és resource template részhez, hívd meg a "greeting" funkciót, írj be egy nevet, és egy névre szóló üdvözlést kell látnod.

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
> Általában sokkal gyorsabb az inspector futtatása CLI módban, mint a böngészőben.
> Olvass többet az inspectorról [itt](https://github.com/modelcontextprotocol/inspector).

**Nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget az ezen fordítás használatából eredő félreértésekért vagy félreértelmezésekért.