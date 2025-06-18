<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T06:02:14+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "fi"
}
-->
# Tämän esimerkin suorittaminen

## -1- Asenna riippuvuudet

```bash
dotnet restore
```

## -3- Suorita esimerkki

```bash
dotnet run
```

## -4- Testaa esimerkki

Kun palvelin on käynnissä yhdessä terminaalissa, avaa toinen terminaali ja suorita seuraava komento:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Tämän pitäisi käynnistää verkkopalvelin, jossa on visuaalinen käyttöliittymä, jonka avulla voit testata esimerkkiä.

Kun palvelin on yhdistetty:

- kokeile listata työkalut ja suorittaa `add` komento argumenteilla 2 ja 4, tuloksena pitäisi näkyä 6.
- siirry resources- ja resource template -kohtiin ja kutsu "greeting", kirjoita nimi ja näet tervehdyksen antamallasi nimellä.

### Testaus komentorivillä (CLI-tila)

Voit käynnistää sen suoraan CLI-tilassa suorittamalla seuraavan komennon:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Tämä listaa kaikki palvelimella saatavilla olevat työkalut. Näet seuraavan tulosteen:

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

Työkalun kutsumiseksi kirjoita:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Näet seuraavan tulosteen:

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
> On yleensä paljon nopeampaa suorittaa inspector CLI-tilassa kuin selaimessa.
> Lue lisää inspectorista [täältä](https://github.com/modelcontextprotocol/inspector).

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty tekoälypohjaisella käännöspalvelulla [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ole hyvä ja huomioi, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja omalla kielellään on virallinen lähde. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä mahdollisesti aiheutuvista väärinymmärryksistä tai virhetulkinnoista.