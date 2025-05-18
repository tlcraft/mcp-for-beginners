<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:05:24+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "hu"
}
-->
# A minta futtatása

Ajánlott telepíteni a `uv`, de nem kötelező, lásd [útmutató](https://docs.astral.sh/uv/#highlights)

## -0- Hozz létre egy virtuális környezetet

```bash
python -m venv venv
```

## -1- Aktiváld a virtuális környezetet

```bash
venv\Scrips\activate
```

## -2- Telepítsd a függőségeket

```bash
pip install "mcp[cli]"
```

## -3- Futtasd a mintát

```bash
mcp run server.py
```

## -4- Teszteld a mintát

Miközben a szerver fut egy terminálban, nyiss meg egy másik terminált és futtasd a következő parancsot:

```bash
mcp dev server.py
```

Ez elindít egy web szervert vizuális felülettel, amely lehetővé teszi a minta tesztelését.

Amint a szerver csatlakozott:

- próbáld meg felsorolni az eszközöket és futtasd `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` egy burkoló körülötte.

Közvetlenül CLI módban is elindíthatod a következő parancs futtatásával:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Ez felsorolja az összes elérhető eszközt a szerveren. A következő kimenetet kell látnod:

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
> Általában sokkal gyorsabb futtatni az inspectort CLI módban, mint a böngészőben.
> További információ az inspectorról [itt](https://github.com/modelcontextprotocol/inspector).

**Felelősség kizárása**:  
Ez a dokumentum AI fordítószolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) használatával lett lefordítva. Bár igyekszünk pontosságra törekedni, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum a saját nyelvén tekintendő hiteles forrásnak. Fontos információk esetén javasolt a professzionális emberi fordítás. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félremagyarázásokért.