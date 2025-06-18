<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:19:42+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
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

Pred zagonom spodnjega ukaza odprite ločen terminal (poskrbite, da strežnik še vedno teče).

Ko strežnik teče v enem terminalu, odprite drug terminal in zaženite naslednji ukaz:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

S tem bi se moral zagnati spletni strežnik z vizualnim vmesnikom, ki omogoča preizkus primera.

> Poskrbite, da je kot vrsta prenosa izbran **Streamable HTTP**, URL pa `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, z argumentoma 2 in 4, v rezultatu pa bi morali videti 6.
- pojdite na resources in resource template ter pokličite "greeting", vnesite ime in prikazalo se bo pozdravno sporočilo z vašim imenom.

### Preizkušanje v CLI načinu

Lahko ga zaženete neposredno v CLI načinu z naslednjim ukazom:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

S tem boste dobili seznam vseh orodij, ki so na voljo na strežniku. Prikazal se bo naslednji izpis:

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

Prikazal se bo naslednji izpis:

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
> Običajno je hitreje zagnati inspector v CLI načinu kot v brskalniku.
> Več o inspectorju preberite [tukaj](https://github.com/modelcontextprotocol/inspector).

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatski prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v izvorni jezikovni različici velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.