<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T06:10:35+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "sl"
}
-->
# Zagon tega primera

## -1- Namestite odvisnosti

```bash
dotnet restore
```

## -2- Zaženite primer

```bash
dotnet run
```

## -3- Preizkusite primer

Preden zaženete spodnje, odprite ločen terminal (prepričajte se, da strežnik še vedno teče).

Ko strežnik teče v enem terminalu, odprite drugega in zaženite naslednji ukaz:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

To bi moralo zagnati spletni strežnik z vizualnim vmesnikom, ki vam omogoča testiranje primera.

> Prepričajte se, da je kot tip prenosa izbran **SSE**, URL pa je `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`, z argumenti 2 in 4 boste v rezultatu videli 6.
- pojdite na resources in resource template ter pokličite "greeting", vnesite ime in videli boste pozdrav z vnesenim imenom.

### Testiranje v CLI načinu

Lahko ga zaženete neposredno v CLI načinu z naslednjim ukazom:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

To bo prikazalo vse orodja, ki so na voljo na strežniku. Videli bi morali naslednji izpis:

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

Za zagon orodja vnesite:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Videli boste naslednji izpis:

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

**Opozorilo:**  
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.