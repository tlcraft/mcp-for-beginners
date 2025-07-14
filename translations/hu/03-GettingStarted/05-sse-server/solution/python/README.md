<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-07-13T20:16:44+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "hu"
}
-->
# A minta futtatása

Ajánlott telepíteni az `uv`-t, de nem kötelező, lásd a [utasításokat](https://docs.astral.sh/uv/#highlights)

## -0- Virtuális környezet létrehozása

```bash
python -m venv venv
```

## -1- A virtuális környezet aktiválása

```bash
venv\Scrips\activate
```

## -2- A függőségek telepítése

```bash
pip install "mcp[cli]"
```

## -3- A minta futtatása

```bash
mcp run server.py
```

## -4- A minta tesztelése

Amíg a szerver fut az egyik terminálban, nyiss meg egy másik terminált, és futtasd a következő parancsot:

```bash
mcp dev server.py
```

Ez elindít egy web szervert vizuális felülettel, amely lehetővé teszi a minta tesztelését.

Miután a szerver csatlakozott:

- próbáld meg lekérdezni az eszközöket, és futtasd az `add` parancsot a 2 és 4 argumentummal, az eredménynek 6-nak kell lennie.
- menj a resources és resource template részhez, hívd meg a get_greeting-et, írj be egy nevet, és egy névre szóló üdvözletet kell látnod.

### Tesztelés CLI módban

Az inspector, amit futtattál, valójában egy Node.js alkalmazás, és a `mcp dev` egy wrapper köré építve.

Közvetlenül CLI módban is elindíthatod a következő paranccsal:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Ez kilistázza az összes elérhető eszközt a szerveren. A következő kimenetet kell látnod:

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
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Általában sokkal gyorsabb az inspectort CLI módban futtatni, mint a böngészőben.
> További információ az inspectorról [itt](https://github.com/modelcontextprotocol/inspector).

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.