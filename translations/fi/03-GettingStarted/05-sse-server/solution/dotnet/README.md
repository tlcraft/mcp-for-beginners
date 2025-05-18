<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:56:50+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "fi"
}
-->
# Tämän esimerkin suorittaminen

## -1- Asenna riippuvuudet

```bash
dotnet run
```

## -2- Suorita esimerkki

```bash
dotnet run
```

## -3- Testaa esimerkki

Avaa erillinen pääte ennen kuin suoritat alla olevan (varmista, että palvelin on yhä käynnissä).

Kun palvelin on käynnissä yhdessä päätteessä, avaa toinen pääte ja suorita seuraava komento:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Tämän pitäisi käynnistää verkkopalvelin visuaalisella käyttöliittymällä, joka mahdollistaa esimerkin testaamisen.

Kun palvelin on yhdistetty:

- kokeile listata työkalut ja suorittaa `add` käyttäen argumentteina 2 ja 4, tuloksena pitäisi olla 6.
- mene resursseihin ja resurssipohjaan ja kutsu "greeting", kirjoita nimi ja sinun pitäisi nähdä tervehdys antamallasi nimellä.

### Testaus CLI-tilassa

Voit käynnistää sen suoraan CLI-tilassa suorittamalla seuraavan komennon:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Tämä listaa kaikki palvelimella käytettävissä olevat työkalut. Sinun pitäisi nähdä seuraava tulos:

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

Käyttääksesi työkalua kirjoita:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Sinun pitäisi nähdä seuraava tulos:

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
> On yleensä paljon nopeampaa suorittaa ispector CLI-tilassa kuin selaimessa.
> Lue lisää ispectorista [täältä](https://github.com/modelcontextprotocol/inspector).

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttäen tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää ensisijaisena lähteenä. Kriittisen tiedon kohdalla suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinkäsityksistä tai virheellisistä tulkinnoista.