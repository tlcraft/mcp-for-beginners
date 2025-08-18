<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d26f746e21775c30b4d7ed97962b24df",
  "translation_date": "2025-08-18T22:35:18+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "sl"
}
-->
# Zagon tega primera

Priporočljivo je, da namestite `uv`, vendar to ni nujno potrebno. Glejte [navodila](https://docs.astral.sh/uv/#highlights).

## -0- Ustvarite virtualno okolje

```bash
python -m venv venv
```

## -1- Aktivirajte virtualno okolje

```bash
venv\Scripts\activate
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

Ko strežnik deluje v enem terminalu, odprite drug terminal in zaženite naslednji ukaz:

```bash
mcp dev server.py
```

To bi moralo zagnati spletni strežnik z vizualnim vmesnikom, ki vam omogoča preizkušanje primera.

Ko je strežnik povezan:

- poskusite našteti orodja in zaženite `add` z argumentoma 2 in 4. Videti bi morali rezultat 6.

- pojdite na vire in predlogo virov ter pokličite `get_greeting`. Vnesite ime in videti bi morali pozdrav z vnesenim imenom.

### Testiranje v načinu CLI

Inšpektor, ki ste ga zagnali, je pravzaprav aplikacija Node.js, `mcp dev` pa je njen ovoj. 

Lahko ga zaženete neposredno v načinu CLI z naslednjim ukazom:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

To bo prikazalo seznam vseh orodij, ki so na voljo na strežniku. Videti bi morali naslednji izpis:

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

Videti bi morali naslednji izpis:

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

> [!TIP]  
> Običajno je veliko hitreje zagnati inšpektor v načinu CLI kot v brskalniku.  
> Več o inšpektorju preberite [tukaj](https://github.com/modelcontextprotocol/inspector).

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo strokovno človeško prevajanje. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.