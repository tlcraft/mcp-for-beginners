<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:58:22+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "hu"
}
-->
# A példa futtatása

## -1- Telepítse a függőségeket

```bash
dotnet run
```

## -2- Futtassa a példát

```bash
dotnet run
```

## -3- Tesztelje a példát

Indítson el egy külön terminált, mielőtt az alábbiakat futtatná (győződjön meg róla, hogy a szerver még fut).

Ha a szerver fut az egyik terminálban, nyisson meg egy másik terminált, és futtassa a következő parancsot:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Ez elindít egy web szervert egy vizuális felülettel, amely lehetővé teszi a példa tesztelését.

Miután a szerver csatlakozott:

- próbálja meg listázni az eszközöket, és futtassa az `add` parancsot a 2 és 4 argumentumokkal, ekkor 6-ot kell látni az eredményben.
- menjen a forrásokhoz és a forrás sablonhoz, és hívja meg a "greeting"-et, írjon be egy nevet, és látni fogja az üdvözletet az Ön által megadott névvel.

### Tesztelés CLI módban

Közvetlenül CLI módban is elindíthatja a következő parancs futtatásával:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Ez felsorolja az összes eszközt, amely elérhető a szerveren. A következő kimenetet kell látni:

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

Egy eszköz meghívásához írja be:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

A következő kimenetet kell látni:

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
> Általában sokkal gyorsabb CLI módban futtatni az inspektort, mint a böngészőben.
> Olvasson többet az inspektorról [itt](https://github.com/modelcontextprotocol/inspector).

**Felelősség kizárása**:  
Ez a dokumentum az AI fordítási szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével lett lefordítva. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális emberi fordítás igénybevétele. Nem vállalunk felelősséget semmilyen félreértésért vagy téves értelmezésért, amely a fordítás használatából ered.