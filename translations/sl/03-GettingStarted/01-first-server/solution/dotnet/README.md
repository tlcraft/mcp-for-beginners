<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T06:10:29+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "sl"
}
-->
# Zagon tega primera

## -1- Namestite odvisnosti

```bash
dotnet restore
```

## -3- Zaženite primer


```bash
dotnet run
```

## -4- Testirajte primer

Medtem ko je strežnik zagnan v enem terminalu, odprite drugi terminal in zaženite naslednji ukaz:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

To bo zagnalo spletni strežnik z vizualnim vmesnikom, ki vam omogoča testiranje primera.

Ko je strežnik povezan:

- poskusite našteti orodja in zaženite `add` z argumenti 2 in 4, v rezultatu bi morali videti 6.
- pojdite na resources in resource template ter pokličite "greeting", vnesite ime in videli boste pozdrav z vnesenim imenom.

### Testiranje v CLI načinu

Lahko ga zaženete neposredno v CLI načinu z naslednjim ukazom:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

To bo naštelo vsa orodja, ki so na voljo na strežniku. Videli bi morali naslednji izpis:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
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
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Videli bi morali naslednji izpis:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Običajno je veliko hitreje zagnati inspector v CLI načinu kot v brskalniku.
> Več o inspectorju preberite [tukaj](https://github.com/modelcontextprotocol/inspector).

**Opozorilo**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatski prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Ne odgovarjamo za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.