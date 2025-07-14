<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-07-13T20:10:42+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "fi"
}
-->
# Tämän esimerkin suorittaminen

## -1- Asenna riippuvuudet

```bash
dotnet restore
```

## -2- Suorita esimerkki

```bash
dotnet run
```

## -3- Testaa esimerkki

Avaa erillinen terminaali ennen alla olevan komennon suorittamista (varmista, että palvelin on edelleen käynnissä).

Kun palvelin on käynnissä yhdessä terminaalissa, avaa toinen terminaali ja suorita seuraava komento:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Tämän pitäisi käynnistää web-palvelin, jossa on visuaalinen käyttöliittymä esimerkin testaamista varten.

> Varmista, että **SSE** on valittuna siirtotyyppinä ja URL on `http://localhost:3001/sse`.

Kun palvelin on yhdistetty:

- kokeile listata työkalut ja suorita `add` argumenteilla 2 ja 4, tuloksena pitäisi näkyä 6.
- siirry resources- ja resource template -kohtiin ja kutsu "greeting", kirjoita nimi ja näet tervehdyksen antamallasi nimellä.

### Testaus CLI-tilassa

Voit käynnistää sen suoraan CLI-tilassa suorittamalla seuraavan komennon:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Tämä listaa kaikki palvelimella saatavilla olevat työkalut. Näet seuraavanlaisen tulosteen:

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

Työkalun kutsumiseksi kirjoita:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Näet seuraavanlaisen tulosteen:

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
> On yleensä paljon nopeampaa käyttää inspector-työkalua CLI-tilassa kuin selaimessa.
> Lue lisää inspectorista [täältä](https://github.com/modelcontextprotocol/inspector).

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.