<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:19:02+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "hu"
}
-->
# A példa futtatása

Ajánlott telepíteni a `uv`, de nem kötelező, lásd [utasítások](https://docs.astral.sh/uv/#highlights)

## -0- Hozzon létre egy virtuális környezetet

```bash
python -m venv venv
```

## -1- Aktiválja a virtuális környezetet

```bash
venv\Scrips\activate
```

## -2- Telepítse a függőségeket

```bash
pip install "mcp[cli]"
```

## -3- Futtassa a példát

```bash
mcp run server.py
```

## -4- Tesztelje a példát

Miközben a szerver fut az egyik terminálban, nyisson meg egy másik terminált, és futtassa az alábbi parancsot:

```bash
mcp dev server.py
```

Ez elindít egy webszervert vizuális felülettel, amely lehetővé teszi a példa tesztelését.

Amint a szerver csatlakozik:

- próbálja meg listázni az eszközöket, és futtassa `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev`, amely köré van csomagolva.

Közvetlenül CLI módban is elindíthatja az alábbi parancs futtatásával:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Ez listázza a szerverben elérhető összes eszközt. A következő kimenetet kell látnia:

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

Egy eszköz meghívásához írja be:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

A következő kimenetet kell látnia:

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
> Általában sokkal gyorsabb CLI módban futtatni az inspectort, mint a böngészőben.
> További információ az inspectorról [itt](https://github.com/modelcontextprotocol/inspector).

**Felelősség kizárása**:  
Ezt a dokumentumot AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordították le. Bár igyekszünk pontosságra törekedni, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekinthető hiteles forrásnak. Fontos információk esetén ajánlott a professzionális emberi fordítás. Nem vállalunk felelősséget semmilyen félreértésért vagy félreértelmezésért, amely a fordítás használatából ered.