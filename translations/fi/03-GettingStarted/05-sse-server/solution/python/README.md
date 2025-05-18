<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:03:50+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "fi"
}
-->
# Tämän esimerkin suorittaminen

Suosittelemme asentamaan `uv`, mutta se ei ole pakollista, katso [ohjeet](https://docs.astral.sh/uv/#highlights)

## -0- Luo virtuaaliympäristö

```bash
python -m venv venv
```

## -1- Aktivoi virtuaaliympäristö

```bash
venv\Scrips\activate
```

## -2- Asenna riippuvuudet

```bash
pip install "mcp[cli]"
```

## -3- Suorita esimerkki

```bash
mcp run server.py
```

## -4- Testaa esimerkkiä

Kun palvelin on käynnissä yhdessä terminaalissa, avaa toinen terminaali ja suorita seuraava komento:

```bash
mcp dev server.py
```

Tämän pitäisi käynnistää verkkopalvelin, jossa on visuaalinen käyttöliittymä, jonka avulla voit testata esimerkkiä.

Kun palvelin on yhdistetty:

- kokeile listata työkaluja ja suorita `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` on sen ympärille rakennettu.

Voit käynnistää sen suoraan CLI-tilassa suorittamalla seuraavan komennon:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Tämä listaa kaikki palvelimessa saatavilla olevat työkalut. Sinun pitäisi nähdä seuraava tuloste:

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

Kutsua varten kirjoita:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Sinun pitäisi nähdä seuraava tuloste:

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
> Yleensä on paljon nopeampaa suorittaa ispector CLI-tilassa kuin selaimessa.
> Lue lisää ispectorista [täältä](https://github.com/modelcontextprotocol/inspector).

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä AI-käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, on tärkeää huomata, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää ensisijaisena lähteenä. Kriittistä tietoa varten suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.