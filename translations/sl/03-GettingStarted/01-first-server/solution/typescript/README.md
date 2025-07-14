<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-07-13T18:07:47+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "sl"
}
-->
# Zagon tega primera

Priporočamo, da namestite `uv`, vendar ni nujno, poglejte [navodila](https://docs.astral.sh/uv/#highlights)

## -1- Namestite odvisnosti

```bash
npm install
```

## -3- Zaženite primer


```bash
npm run build
```

## -4- Preizkusite primer

Ko je strežnik zagnan v enem terminalu, odprite drug terminal in zaženite naslednji ukaz:

```bash
npm run inspector
```

To bi moralo zagnati spletni strežnik z vizualnim vmesnikom, ki vam omogoča testiranje primera.

Ko je strežnik povezan:

- poskusite našteti orodja in zaženite `add` z argumenti 2 in 4, v rezultatu bi morali videti 6.
- pojdite na resources in resource template ter pokličite "greeting", vnesite ime in videli boste pozdrav z vnesenim imenom.

### Testiranje v CLI načinu

Inspector, ki ste ga zagnali, je pravzaprav Node.js aplikacija, `mcp dev` pa je ovitek okoli nje.

Lahko ga zaženete neposredno v CLI načinu z naslednjim ukazom:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

To bo naštelo vsa orodja, ki so na voljo na strežniku. Videli bi morali naslednji izpis:

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

Za klic orodja vnesite:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Videli bi morali naslednji izpis:

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
> Običajno je veliko hitreje zagnati inspector v CLI načinu kot v brskalniku.
> Več o inspectorju preberite [tukaj](https://github.com/modelcontextprotocol/inspector).

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.