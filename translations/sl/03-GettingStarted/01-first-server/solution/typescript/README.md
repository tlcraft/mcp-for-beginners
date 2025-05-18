<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:27:20+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "sl"
}
-->
# Zaženite ta vzorec

Priporočljivo je namestiti `uv`, vendar to ni nujno, glejte [navodila](https://docs.astral.sh/uv/#highlights)

## -1- Namestite odvisnosti

```bash
npm install
```

## -3- Zaženite vzorec

```bash
npm run build
```

## -4- Preizkusite vzorec

Ko strežnik teče v enem terminalu, odprite drug terminal in zaženite naslednji ukaz:

```bash
npm run inspector
```

To bi moralo zagnati spletni strežnik z vizualnim vmesnikom, ki vam omogoča preizkus vzorca.

Ko je strežnik povezan:

- poskusite našteti orodja in zaženite `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev`, ki je ovojnica okoli njega.

Lahko ga zaženete neposredno v načinu CLI z naslednjim ukazom:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
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

Za priklic orodja vnesite:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Običajno je veliko hitreje zagnati ispektor v načinu CLI kot v brskalniku.
> Preberite več o ispektorju [tukaj](https://github.com/modelcontextprotocol/inspector).

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve AI prevajanja [Co-op Translator](https://github.com/Azure/co-op-translator). Medtem ko si prizadevamo za natančnost, vas prosimo, da se zavedate, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v svojem maternem jeziku je treba obravnavati kot avtoritativni vir. Za kritične informacije se priporoča profesionalni človeški prevod. Ne odgovarjamo za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.