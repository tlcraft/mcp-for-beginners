<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2342baa570312086fc19edcf41320250",
  "translation_date": "2025-06-17T15:55:06+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "fi"
}
-->
Edellisessä koodissa me:

- Tuomme kirjastot
- Luomme client-instanssin ja yhdistämme sen stdio-siirtoprotokollan avulla.
- Listaamme kehotteet, resurssit ja työkalut ja kutsumme ne kaikki käyttöön.

Siinä se, client, joka osaa kommunikoida MCP-palvelimen kanssa.

Käydään seuraavassa harjoituksessa koodinpätkät läpi rauhassa ja selitetään, mitä missäkin tapahtuu.

## Harjoitus: Clientin kirjoittaminen

Kuten edellä sanottu, käytetään aikaa koodin selittämiseen, ja voit toki koodata mukana halutessasi.

### -1- Kirjastojen tuonti

Tuodaan tarvittavat kirjastot, tarvitsemme viitteet clientiin ja valittuun siirtoprotokollaan, stdioon. stdio on protokolla paikallisesti ajettaville sovelluksille. SSE on toinen siirtoprotokolla, jota esittelemme myöhemmissä luvuissa, mutta se on toinen vaihtoehtosi. Nyt jatketaan kuitenkin stdiolla.

Siirrytään luontivaiheeseen.

### -2- Clientin ja siirron instansointi

Meidän täytyy luoda instanssit siirtoprotokollalle ja clientille:

### -3- Palvelimen ominaisuuksien listaaminen

Nyt meillä on client, joka osaa yhdistää palvelimeen, kun ohjelma ajetaan. Se ei kuitenkaan listaa ominaisuuksiaan, joten tehdään se seuraavaksi:

Hienoa, nyt olemme saaneet kaikki ominaisuudet talteen. Mutta milloin niitä käytetään? Tämä client on melko yksinkertainen, eli ominaisuudet pitää kutsua erikseen silloin kun niitä tarvitaan. Seuraavassa luvussa luomme kehittyneemmän clientin, jolla on oma suuri kielimalli (LLM). Nyt kuitenkin katsotaan, miten ominaisuuksia voidaan kutsua palvelimelta:

### -4- Ominaisuuksien kutsuminen

Ominaisuuksia kutsuttaessa täytyy varmistaa, että annamme oikeat argumentit ja joissain tapauksissa myös kutsuttavan kohteen nimen.

### -5- Clientin ajaminen

Ajaaksesi clientin, kirjoita seuraava komento terminaaliin:

## Tehtävä

Tässä tehtävässä hyödynnät oppimaasi clientin luomisessa ja luot oman clientin.

Tässä on palvelin, jota voit käyttää ja johon sinun tulee yhdistää client-koodillasi. Katso, voitko lisätä palvelimeen ominaisuuksia, jotka tekevät siitä mielenkiintoisemman.

## Ratkaisu

[Ratkaisu](./solution/README.md)

## Tärkeimmät opit

Tämän luvun tärkeimmät opit clientteihin liittyen ovat:

- Clientteja voi käyttää sekä palvelimen ominaisuuksien löytämiseen että kutsumiseen.
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

- Seuraavaksi: [Clientin luominen LLM:n kanssa](/03-GettingStarted/03-llm-client/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää auktoritatiivisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.