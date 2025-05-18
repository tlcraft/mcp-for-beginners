<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:24:34+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "fi"
}
-->
# Tämän esimerkin suorittaminen

Suosittelemme asentamaan `uv`, mutta se ei ole välttämätöntä, katso [ohjeet](https://docs.astral.sh/uv/#highlights)

## -1- Asenna riippuvuudet

```bash
npm install
```

## -3- Suorita esimerkki

```bash
npm run build
```

## -4- Testaa esimerkki

Kun palvelin toimii yhdessä terminaalissa, avaa toinen terminaali ja suorita seuraava komento:

```bash
npm run inspector
```

Tämän pitäisi käynnistää verkkopalvelin, jossa on visuaalinen käyttöliittymä, jonka avulla voit testata esimerkkiä.

Kun palvelin on yhdistetty:

- kokeile listata työkaluja ja suorittaa `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` on sen ympärillä oleva kääre.

Voit käynnistää sen suoraan CLI-tilassa suorittamalla seuraavan komennon:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
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

Työkalun käynnistämiseksi kirjoita:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
Tämä asiakirja on käännetty käyttämällä tekoälyn käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta ole tietoinen siitä, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää ensisijaisena lähteenä. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinkäsityksistä tai virhetulkinnoista.