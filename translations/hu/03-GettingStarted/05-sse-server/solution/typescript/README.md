<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:21:50+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "hu"
}
-->
# A minta futtatása

## -1- A függőségek telepítése

```bash
npm install
```

## -3- A minta futtatása

```bash
npm run build
```

## -4- A minta tesztelése

Amíg a szerver egy terminálban fut, nyiss meg egy másik terminált, és futtasd a következő parancsot:

```bash
npm run inspector
```

Ez elindít egy web szervert vizuális felülettel, amely lehetővé teszi a minta tesztelését.

Miután a szerver csatlakozott:

- próbáld meg lekérdezni az eszközöket, és futtasd az `add` parancsot a 2 és 4 argumentummal, az eredménynek 6-nak kell lennie.
- menj a resources és resource template részhez, hívd meg a "greeting" függvényt, írj be egy nevet, és egy névre szóló üdvözletet kell látnod.

### Tesztelés CLI módban

Az általad futtatott inspector valójában egy Node.js alkalmazás, és a `mcp dev` egy wrapper köré épül.

- Indítsd el a szervert a `npm run build` paranccsal.

- Egy másik terminálban futtasd a következő parancsot:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
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

- Egy eszköz típus meghívásához írd be a következő parancsot:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

A következő kimenetet kell látnod:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> Általában sokkal gyorsabb az inspectort CLI módban futtatni, mint a böngészőben.
> További információkat az inspectorról [itt](https://github.com/modelcontextprotocol/inspector) találsz.

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.