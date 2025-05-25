<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:26:03+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "hu"
}
-->
# A minta futtatása

Ajánlott telepíteni a `uv`-t, de nem kötelező, lásd [utasítások](https://docs.astral.sh/uv/#highlights)

## -1- A függőségek telepítése

```bash
npm install
```

## -3- A minta futtatása

```bash
npm run build
```

## -4- A minta tesztelése

Miközben a szerver fut az egyik terminálban, nyiss meg egy másik terminált, és futtasd a következő parancsot:

```bash
npm run inspector
```

Ez elindít egy webszervert egy vizuális felülettel, amely lehetővé teszi a minta tesztelését.

Miután a szerver csatlakozott:

- próbáld meg listázni az eszközöket és futtatni `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev`, amely egy wrapper körülötte.

Közvetlenül CLI módban is elindíthatod, ha futtatod a következő parancsot:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
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
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Általában sokkal gyorsabb az inspektort CLI módban futtatni, mint a böngészőben.
> Olvass többet az inspektorról [itt](https://github.com/modelcontextprotocol/inspector).

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordítási szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordították le. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelven tekintendő hiteles forrásnak. Kritikus információk esetén ajánlott a professzionális emberi fordítás. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félremagyarázásokért.