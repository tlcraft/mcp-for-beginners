<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-13T18:01:40+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "hu"
}
-->
# A példa futtatása

Ajánlott telepíteni az `uv`-t, de nem kötelező, lásd a [utasításokat](https://docs.astral.sh/uv/#highlights)

## -0- Hozz létre egy virtuális környezetet

```bash
python -m venv venv
```

## -1- Aktiváld a virtuális környezetet

```bash
venv\Scripts\activate
```

## -2- Telepítsd a függőségeket

```bash
pip install "mcp[cli]"
```

## -3- Futtasd a példát

```bash
mcp run server.py
```

## -4- Teszteld a példát

Amíg a szerver fut az egyik terminálban, nyiss egy másik terminált, és futtasd az alábbi parancsot:

```bash
mcp dev server.py
```

Ez elindít egy webes szervert vizuális felülettel, amely lehetővé teszi a példa tesztelését.

Miután a szerver csatlakozott:

- próbáld meg lekérdezni az eszközöket, és futtasd az `add` parancsot a 2 és 4 argumentummal, az eredménynek 6-nak kell lennie.

- menj a resources és resource template részhez, hívd meg a get_greeting-et, írj be egy nevet, és egy névre szóló üdvözlést kell látnod.

### Tesztelés CLI módban

Az inspector, amit futtattál, valójában egy Node.js alkalmazás, és a `mcp dev` egy wrapper köré építve.

Közvetlenül CLI módban is elindíthatod az alábbi parancs futtatásával:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Ez kilistázza a szerveren elérhető összes eszközt. A következő kimenetet kell látnod:

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

Egy eszköz meghívásához írd be:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Az alábbi kimenetet kell látnod:

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
> Általában sokkal gyorsabb az inspectort CLI módban futtatni, mint a böngészőben.
> További információ az inspectorról [itt](https://github.com/modelcontextprotocol/inspector).

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.