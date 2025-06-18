<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T06:02:20+00:00",
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

Tämän pitäisi käynnistää web-palvelin, jossa on visuaalinen käyttöliittymä, jonka avulla voit testata esimerkkiä.

> Varmista, että **SSE** on valittuna siirtotyyppinä, ja URL on `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`. Kun argumentit ovat 2 ja 4, näet tuloksena 6.
- mene resources- ja resource template -kohtiin ja kutsu "greeting", kirjoita nimi ja näet tervehdyksen antamallasi nimellä.

### Testaus komentorivillä

Voit käynnistää sen suoraan komentorivitilassa suorittamalla seuraavan komennon:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Tämä listaa kaikki palvelimella saatavilla olevat työkalut. Näet seuraavan tulosteen:

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

Näet seuraavan tulosteen:

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
> On yleensä paljon nopeampaa käyttää inspector-työkalua komentoriviltä kuin selaimessa.
> Lue lisää inspectorista [täältä](https://github.com/modelcontextprotocol/inspector).

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäisellä kielellä on virallinen lähde. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinkäsityksistä tai virhetulkinnoista.