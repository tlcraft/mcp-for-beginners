<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:20:18+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "sl"
}
-->
# Zagon te vzorčne kode

Priporočamo, da namestite `uv`, vendar to ni nujno, glejte [navodila](https://docs.astral.sh/uv/#highlights)

## -0- Ustvarite virtualno okolje

```bash
python -m venv venv
```

## -1- Aktivirajte virtualno okolje

```bash
venv\Scrips\activate
```

## -2- Namestite odvisnosti

```bash
pip install "mcp[cli]"
```

## -3- Zaženite vzorec

```bash
mcp run server.py
```

## -4- Testirajte vzorec

Ko strežnik deluje v enem terminalu, odprite drug terminal in zaženite naslednji ukaz:

```bash
mcp dev server.py
```

To bi moralo zagnati spletni strežnik z vizualnim vmesnikom, ki vam omogoča testiranje vzorca.

Ko je strežnik povezan:

- poskusite našteti orodja in zaženite `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev`, ki je ovojnica okoli njega.

Lahko ga zaženete neposredno v CLI načinu z naslednjim ukazom:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

To bo navedlo vsa orodja, ki so na voljo v strežniku. Videti bi morali naslednji izhod:

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

Za uporabo orodja vnesite:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Videti bi morali naslednji izhod:

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
> Običajno je veliko hitreje zagnati ispektor v CLI načinu kot v brskalniku.
> Več o ispektorju preberite [tukaj](https://github.com/modelcontextprotocol/inspector).

**Omejitev odgovornosti**: 
Ta dokument je bil preveden z uporabo storitve AI za prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, prosimo, upoštevajte, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku bi moral biti obravnavan kot avtoritativni vir. Za kritične informacije je priporočljivo profesionalno človeško prevajanje. Ne odgovarjamo za kakršna koli nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.