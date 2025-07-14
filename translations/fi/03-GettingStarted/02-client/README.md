<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-13T18:17:11+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "fi"
}
-->
Edellisessä koodissa me:

- Tuomme kirjastot
- Luomme client-instanssin ja yhdistämme sen stdio-siirtoprotokollan avulla.
- Listaamme kehotteet, resurssit ja työkalut ja kutsumme ne kaikki.

Siinä se, client, joka osaa kommunikoida MCP-palvelimen kanssa.

Käydään seuraavassa harjoituksessa rauhassa läpi jokainen koodinpätkä ja selitetään, mitä tapahtuu.

## Harjoitus: Clientin kirjoittaminen

Kuten sanottu, käytetään aikaa koodin selittämiseen, ja voit toki koodata mukana halutessasi.

### -1- Kirjastojen tuonti

Tuodaan tarvittavat kirjastot, tarvitsemme viittaukset clienttiin ja valitsemaamme siirtoprotokollaan, stdioon. Stdio on protokolla paikallisesti ajettaville sovelluksille. SSE on toinen siirtoprotokolla, jonka esittelemme tulevissa luvuissa, mutta se on toinen vaihtoehtosi. Nyt jatketaan kuitenkin stdiolla.

Siirrytään instansiointiin.

### -2- Clientin ja siirron instansiointi

Meidän täytyy luoda instanssit siirtoprotokollasta ja clientistä: 

### -3- Palvelimen ominaisuuksien listaaminen

Nyt meillä on client, joka voi yhdistää palvelimeen, kun ohjelma ajetaan. Se ei kuitenkaan vielä listaa ominaisuuksiaan, tehdään se nyt:

Hienoa, nyt olemme saaneet kaikki ominaisuudet talteen. Kysymys kuuluu, milloin niitä käytetään? Tämä client on melko yksinkertainen siinä mielessä, että ominaisuudet täytyy kutsua eksplisiittisesti silloin kun niitä halutaan käyttää. Seuraavassa luvussa luomme kehittyneemmän clientin, jolla on oma suuri kielimalli (LLM). Nyt kuitenkin katsotaan, miten ominaisuuksia voidaan kutsua palvelimella:

### -4- Ominaisuuksien kutsuminen

Ominaisuuksia kutsuttaessa täytyy varmistaa, että annamme oikeat argumentit ja joissain tapauksissa myös kutsuttavan kohteen nimen.

### -5- Clientin ajaminen

Ajaaksesi clientin, kirjoita seuraava komento terminaaliin:

## Tehtävä

Tässä tehtävässä käytät oppimaasi clientin luomisessa, mutta luot oman clientin.

Tässä on palvelin, jota voit käyttää ja johon sinun täytyy tehdä kutsuja client-koodillasi. Katso, voitko lisätä palvelimeen lisää ominaisuuksia, jotta siitä tulee mielenkiintoisempi.

## Ratkaisu

[Solution](./solution/README.md)

## Tärkeimmät opit

Tämän luvun tärkeimmät opit clientteihin liittyen ovat:

- Niitä voi käyttää sekä palvelimen ominaisuuksien löytämiseen että kutsumiseen.
- Client voi käynnistää palvelimen samalla kun se käynnistyy (kuten tässä luvussa), mutta clientit voivat myös yhdistää jo käynnissä oleviin palvelimiin.
- Client on erinomainen tapa testata palvelimen ominaisuuksia vaihtoehtona esimerkiksi Inspector-työkalulle, kuten edellisessä luvussa kuvattiin.

## Lisäresurssit

- [Clienttien rakentaminen MCP:ssä](https://modelcontextprotocol.io/quickstart/client)

## Esimerkit

- [Java-laskin](../samples/java/calculator/README.md)
- [.Net-laskin](../../../../03-GettingStarted/samples/csharp)
- [JavaScript-laskin](../samples/javascript/README.md)
- [TypeScript-laskin](../samples/typescript/README.md)
- [Python-laskin](../../../../03-GettingStarted/samples/python)

## Mitä seuraavaksi

- Seuraavaksi: [Clientin luominen LLM:n kanssa](../03-llm-client/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.