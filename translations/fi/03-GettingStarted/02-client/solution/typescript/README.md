<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fae57a69c2b62cb7d92ff12da65f36c3",
  "translation_date": "2025-05-17T10:09:51+00:00",
  "source_file": "03-GettingStarted/02-client/solution/typescript/README.md",
  "language_code": "fi"
}
-->
# Tämän esimerkin suorittaminen

Suosittelemme asentamaan `uv`, mutta se ei ole pakollista, katso [ohjeet](https://docs.astral.sh/uv/#highlights)

## -1- Asenna riippuvuudet

```bash
npm install
```

## -3- Suorita palvelin

```bash
npm run build
```

## -4- Suorita asiakas

```sh
npm run client
```

Sinun pitäisi nähdä tulos, joka on samanlainen kuin:

```text
Prompt:  {
  type: 'text',
  text: 'Please review this code:\n\nconsole.log("hello");'
}
Resource template:  file
Tool result:  { content: [ { type: 'text', text: '9' } ] }
```

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää ensisijaisena lähteenä. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskääntämistä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinkäsityksistä tai virhetulkinnoista.