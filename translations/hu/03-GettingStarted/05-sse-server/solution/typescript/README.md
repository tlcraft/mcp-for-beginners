<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:12:24+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "hu"
}
-->
# A példa futtatása

## -1- Telepítse a függőségeket

```bash
npm install
```

## -3- Futtassa a mintát

```bash
npm run build
```

## -4- Tesztelje a mintát

Amikor a szerver fut egy terminálban, nyisson meg egy másik terminált, és futtassa a következő parancsot:

```bash
npm run inspector
```

Ez elindít egy webes szervert vizuális felülettel, amely lehetővé teszi a minta tesztelését.

Amikor a szerver csatlakozott:

- próbálja meg felsorolni az eszközöket, és futtassa az `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build` parancsot.

- Egy külön terminálban futtassa a következő parancsot:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Ez felsorolja az összes elérhető eszközt a szerveren. A következő kimenetet kell látnia:

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

- Hívjon meg egy eszköztípust a következő parancs beírásával:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

A következő kimenetet kell látnia:

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
> Általában sokkal gyorsabb az inspektort CLI módban futtatni, mint a böngészőben.
> További információ az inspektorról [itt](https://github.com/modelcontextprotocol/inspector).

**Felelősség kizárása**:  
Ezt a dokumentumot AI fordítási szolgáltatással, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordították. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén javasolt a professzionális emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félremagyarázásokért.