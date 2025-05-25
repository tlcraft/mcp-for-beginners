<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:13:41+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "sl"
}
-->
# Zagon tega vzorca

## -1- Namestite odvisnosti

```bash
npm install
```

## -3- Zaženite vzorec

```bash
npm run build
```

## -4- Preizkusite vzorec

Ko je strežnik zagnan v enem terminalu, odprite drug terminal in zaženite naslednji ukaz:

```bash
npm run inspector
```

To bi moralo zagnati spletni strežnik z vizualnim vmesnikom, ki vam omogoča preizkus vzorca.

Ko je strežnik povezan:

- poskusite našteti orodja in zaženite `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build`.

- V ločenem terminalu zaženite naslednji ukaz:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    To bo naštelo vsa orodja, ki so na voljo na strežniku. Videti bi morali naslednji izpis:

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

- Orodje prikličite tako, da vnesete naslednji ukaz:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Videti bi morali naslednji izpis:

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
> Običajno je veliko hitreje zagnati inšpektor v načinu CLI kot v brskalniku.
> Več o inšpektorju preberite [tukaj](https://github.com/modelcontextprotocol/inspector).

**Omejitev odgovornosti**:
Ta dokument je bil preveden z uporabo storitve AI prevajanja [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da se zavedate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku bi moral veljati za avtoritativni vir. Za ključne informacije je priporočljiv strokovni človeški prevod. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne interpretacije, ki bi nastale zaradi uporabe tega prevoda.