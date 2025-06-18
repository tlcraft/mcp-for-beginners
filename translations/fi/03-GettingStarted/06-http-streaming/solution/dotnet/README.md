<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:18:12+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "fi"
}
-->
# Näytteen suorittaminen

## -1- Asenna riippuvuudet

```bash
dotnet restore
```

## -2- Suorita näyte

```bash
dotnet run
```

## -3- Testaa näyte

Avaa erillinen terminaali ennen alla olevan komennon suorittamista (varmista, että palvelin on edelleen käynnissä).

Kun palvelin on käynnissä yhdessä terminaalissa, avaa toinen terminaali ja suorita seuraava komento:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Tämän pitäisi käynnistää web-palvelin, jossa on visuaalinen käyttöliittymä, jonka avulla voit testata näytettä.

> Varmista, että **Streamable HTTP** on valittu siirtotavaksi ja URL on `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, argumenteilla 2 ja 4, jolloin tuloksena pitäisi näkyä 6.
- siirry resources- ja resource template -kohtiin ja kutsu "greeting", kirjoita nimi ja näet tervehdyksen antamallasi nimellä.

### Testaus CLI-tilassa

Voit käynnistää sen suoraan CLI-tilassa suorittamalla seuraavan komennon:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Tämä listaa kaikki palvelimella käytettävissä olevat työkalut. Näet seuraavan tulosteen:

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
> On yleensä paljon nopeampaa suorittaa inspector CLI-tilassa kuin selaimessa.
> Lue lisää inspectorista [täältä](https://github.com/modelcontextprotocol/inspector).

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää ensisijaisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.