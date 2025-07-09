<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-09T23:17:28+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "sl"
}
-->
# Zagon tega primera

Priporočamo, da namestite `uv`, vendar ni nujno, poglejte [navodila](https://docs.astral.sh/uv/#highlights)

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

## -3- Zaženite primer


```bash
mcp run server.py
```

## -4- Preizkusite primer

Ko je strežnik zagnan v enem terminalu, odprite drug terminal in zaženite naslednji ukaz:

```bash
mcp dev server.py
```

To bi moralo zagnati spletni strežnik z vizualnim vmesnikom, ki vam omogoča testiranje primera.

Ko je strežnik povezan:

- poskusite izpisati orodja in zaženite `add` z argumenti 2 in 4, v rezultatu bi morali videti 6.

- pojdite na resources in resource template ter pokličite get_greeting, vnesite ime in videli boste pozdrav z vnesenim imenom.

### Testiranje v CLI načinu

Inspector, ki ste ga zagnali, je pravzaprav Node.js aplikacija, `mcp dev` pa je ovitek okoli nje.

Lahko ga zaženete neposredno v CLI načinu z naslednjim ukazom:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

To bo izpisalo vsa orodja, ki so na voljo na strežniku. Videli bi morali naslednji izpis:

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
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.