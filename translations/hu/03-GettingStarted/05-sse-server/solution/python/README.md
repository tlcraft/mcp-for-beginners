<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "69ba3bd502bd743233137bac5539c08b",
  "translation_date": "2025-08-18T19:34:02+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "hu"
}
-->
# A példa futtatása

Ajánlott telepíteni az `uv`-t, de nem kötelező, lásd [útmutató](https://docs.astral.sh/uv/#highlights)

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

## -3- Futtasd a példát

```bash
uvicorn server:app
```

## -4- Teszteld a példát

Amíg a szerver fut az egyik terminálban, nyiss egy másik terminált, és futtasd az alábbi parancsot:

```bash
mcp dev server.py
```

Ez elindít egy webszervert vizuális felülettel, amely lehetővé teszi a példa tesztelését.

Miután a szerver csatlakozott:

- Próbáld meg listázni az eszközöket, és futtasd az `add` eszközt a 2 és 4 argumentumokkal, az eredményben 6-ot kell látnod.
- Menj a resources és resource template részhez, és hívd meg a get_greeting-et, írj be egy nevet, és látnod kell egy üdvözlést az általad megadott névvel.

### Tesztelés CLI módban

Az inspector, amit futtattál, valójában egy Node.js alkalmazás, és az `mcp dev` egy wrapper körülötte.

Közvetlenül CLI módban is elindíthatod az alábbi parancs futtatásával:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Ez listázza az összes elérhető eszközt a szerveren. A következő kimenetet kell látnod:

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

> [!TIP]  
> Általában sokkal gyorsabb az inspectort CLI módban futtatni, mint a böngészőben.  
> További információ az inspectorról [itt](https://github.com/modelcontextprotocol/inspector).

**Felelősségkizárás**:  
Ez a dokumentum az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatás segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális, emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.