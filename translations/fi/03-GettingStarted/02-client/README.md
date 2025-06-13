<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:47:59+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "fi"
}
-->
Edellisessä koodissa me:

- Tuodaan kirjastot
- Luodaan client-instanssi ja yhdistetään se stdio-siirtoprotokollan kautta.
- Listataan kehotteet, resurssit ja työkalut ja kutsutaan niitä kaikkia.

Siinä se, client, joka pystyy kommunikoimaan MCP-palvelimen kanssa.

Käydään seuraavassa harjoitustehtävässä rauhassa läpi jokainen koodinpätkä ja selitetään, mitä tapahtuu.

## Harjoitus: Clientin kirjoittaminen

Kuten sanottu, käytetään aikaa koodin selittämiseen, ja voit toki koodata mukana halutessasi.

### -1- Kirjastojen tuonti

Tuodaan tarvittavat kirjastot, tarvitsemme viitteet clientiin ja valitsemaamme siirtoprotokollaan, stdio:hon. stdio on protokolla paikallisella koneella ajettaville asioille. SSE on toinen siirtoprotokolla, jota esitellään tulevissa luvuissa, mutta se on toinen vaihtoehtosi. Nyt jatketaan kuitenkin stdio:n kanssa.

Siirrytään instansiointiin.

### -2- Clientin ja siirron instansiointi

Meidän täytyy luoda instanssit siirrolle ja clientille: 

### -3- Palvelimen ominaisuuksien listaaminen

Nyt meillä on client, joka voi yhdistyä, jos ohjelma ajetaan. Se ei kuitenkaan vielä listaa ominaisuuksiaan, tehdään se seuraavaksi:

Hienoa, nyt olemme saaneet kaikki ominaisuudet talteen. Kysymys kuuluu, milloin niitä käytetään? Tämä client on melko yksinkertainen, eli ominaisuuksia täytyy kutsua nimenomaan silloin kun haluamme niitä käyttää. Seuraavassa luvussa luomme kehittyneemmän clientin, jolla on oma suuri kielimalli (LLM). Nyt kuitenkin katsotaan, miten ominaisuuksia voidaan kutsua palvelimella:

### -4- Ominaisuuksien kutsuminen

Ominaisuuksia kutsuttaessa täytyy varmistaa, että annamme oikeat argumentit ja joissakin tapauksissa myös kutsuttavan kohteen nimen.

### -5- Clientin ajaminen

Ajaaksesi clientin, kirjoita terminaaliin seuraava komento:

## Tehtävä

Tässä tehtävässä käytät oppimaasi clientin luomiseen, mutta luot oman clientin.

Tässä on palvelin, jota voit käyttää ja johon sinun tulee kutsua client-koodisi kautta. Yritä lisätä palvelimeen lisää ominaisuuksia, jotta siitä tulee mielenkiintoisempi.

## Ratkaisu

[Ratkaisu](./solution/README.md)

## Keskeiset opit

Tämän luvun keskeiset opit clientistä ovat seuraavat:

- Clientilla voi sekä löytää että kutsua palvelimen ominaisuuksia.
- Client voi käynnistää palvelimen itse (kuten tässä luvussa), mutta clientit voivat myös yhdistää jo käynnissä oleviin palvelimiin.
- Client on erinomainen tapa testata palvelimen toimintoja rinnakkain vaihtoehtoihin kuten Inspector-työkaluun, joka esiteltiin edellisessä luvussa.

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
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattikäännöksissä voi esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä tulee katsoa viralliseksi lähteeksi. Tärkeissä asioissa suositellaan ammattilaisen tekemää ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.