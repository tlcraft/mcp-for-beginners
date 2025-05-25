<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:42:10+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "fi"
}
-->
# Asiakkaan luominen

Asiakkaat ovat mukautettuja sovelluksia tai skriptejä, jotka kommunikoivat suoraan MCP-palvelimen kanssa pyytääkseen resursseja, työkaluja ja kehotteita. Toisin kuin tarkastustyökalun käyttäminen, joka tarjoaa graafisen käyttöliittymän palvelimen kanssa vuorovaikutukseen, oman asiakkaan kirjoittaminen mahdollistaa ohjelmallisen ja automatisoidun vuorovaikutuksen. Tämä mahdollistaa kehittäjille MCP-ominaisuuksien integroinnin omiin työnkulkuihin, tehtävien automatisoinnin ja mukautettujen ratkaisujen rakentamisen erityisiin tarpeisiin.

## Yleiskatsaus

Tämä oppitunti esittelee asiakkaiden käsitteen Model Context Protocol (MCP) -ekosysteemissä. Opit kirjoittamaan oman asiakkaasi ja yhdistämään sen MCP-palvelimeen.

## Oppimistavoitteet

Tämän oppitunnin lopussa pystyt:

- Ymmärtämään, mitä asiakas voi tehdä.
- Kirjoittamaan oman asiakkaasi.
- Yhdistämään ja testaamaan asiakkaan MCP-palvelimen kanssa varmistaaksesi, että jälkimmäinen toimii odotetusti.

## Mitä asiakkaan kirjoittamiseen tarvitaan?

Asiakkaan kirjoittamiseen tarvitset seuraavat vaiheet:

- **Tuoda oikeat kirjastot**. Käytät samaa kirjastoa kuin aiemmin, mutta eri rakenteita.
- **Asiakkaan luominen**. Tämä sisältää asiakasinstanssin luomisen ja sen yhdistämisen valittuun kuljetusmenetelmään.
- **Päättää, mitä resursseja listataan**. MCP-palvelimesi tarjoaa resursseja, työkaluja ja kehotteita, sinun on päätettävä, mitkä niistä listataan.
- **Asiakkaan integroiminen isäntäsovellukseen**. Kun tiedät palvelimen ominaisuudet, sinun on integroitava tämä isäntäsovellukseesi niin, että jos käyttäjä kirjoittaa kehotteen tai muun komennon, vastaava palvelimen ominaisuus käynnistyy.

Nyt kun ymmärrämme yleisellä tasolla, mitä olemme tekemässä, katsotaan seuraavaksi esimerkkiä.

### Esimerkkiasiakas

Tarkastellaan tätä esimerkkiasiakasta:
Sinut on koulutettu tietoihin lokakuuhun 2023 asti.

Edellisessä koodissa teemme:

- Tuomme kirjastot
- Luomme asiakkaan instanssin ja yhdistämme sen käyttämällä stdio:ta kuljetukseen.
- Listaamme kehotteet, resurssit ja työkalut ja kutsumme ne kaikki.

Siinä se, asiakas, joka voi kommunikoida MCP-palvelimen kanssa.

Käydään seuraavassa harjoitusosiossa ajan kanssa läpi jokainen koodinpätkä ja selitetään, mitä tapahtuu.

## Harjoitus: Asiakkaan kirjoittaminen

Kuten sanottu, käydään ajan kanssa läpi koodi, ja voit koodata mukana, jos haluat.

### -1- Kirjastojen tuominen

Tuodaan tarvittavat kirjastot, tarvitsemme viittaukset asiakkaaseen ja valitsemaamme kuljetusprotokollaan, stdio:hon. stdio on protokolla asioille, jotka on tarkoitettu toimimaan paikallisella koneellasi. SSE on toinen kuljetusprotokolla, jota esittelemme tulevissa luvuissa, mutta se on toinen vaihtoehtosi. Nyt kuitenkin jatketaan stdio:lla.

Siirrytään asiakkaan ja kuljetuksen luomiseen.

### -2- Asiakkaan ja kuljetuksen luominen

Meidän on luotava kuljetuksen ja asiakkaamme instanssi:

### -3- Palvelimen ominaisuuksien listaaminen

Nyt meillä on asiakas, joka voi yhdistää, jos ohjelma suoritetaan. Kuitenkaan se ei vielä listaa ominaisuuksiaan, joten tehdään se seuraavaksi:

Hienoa, nyt olemme tallentaneet kaikki ominaisuudet. Kysymys kuuluu, milloin käytämme niitä? No, tämä asiakas on melko yksinkertainen, yksinkertainen siinä mielessä, että meidän on kutsuttava ominaisuudet nimenomaan silloin, kun haluamme niitä. Seuraavassa luvussa luomme kehittyneemmän asiakkaan, jolla on pääsy omaan suuren kielen malliin, LLM. Nyt kuitenkin katsotaan, miten voimme kutsua ominaisuuksia palvelimella:

### -4- Ominaisuuksien kutsuminen

Ominaisuuksien kutsumiseksi meidän on varmistettava, että määritämme oikeat argumentit ja joissakin tapauksissa sen, mitä yritämme kutsua.

### -5- Asiakkaan suorittaminen

Asiakkaan suorittamiseksi kirjoita seuraava komento terminaaliin:

## Tehtävä

Tässä tehtävässä käytät oppimaasi luodaksesi oman asiakkaan.

Tässä on palvelin, jota voit käyttää ja johon sinun on soitettava asiakaskoodisi kautta, katso, voitko lisätä palvelimelle lisää ominaisuuksia tehdäksesi siitä mielenkiintoisemman.

## Ratkaisu

[Ratkaisu](./solution/README.md)

## Keskeiset opit

Tämän luvun keskeiset opit asiakkaista ovat seuraavat:

- Voidaan käyttää sekä palvelimen ominaisuuksien löytämiseen että niiden kutsumiseen.
- Voi käynnistää palvelimen samalla kun se käynnistyy itse (kuten tässä luvussa), mutta asiakkaat voivat myös yhdistää käynnissä oleviin palvelimiin.
- On loistava tapa testata palvelimen ominaisuuksia vaihtoehtojen, kuten Tarkastajan, rinnalla, kuten edellisessä luvussa kuvattiin.

## Lisäresurssit

- [Asiakkaiden rakentaminen MCP:ssä](https://modelcontextprotocol.io/quickstart/client)

## Esimerkit

- [Java-laskin](../samples/java/calculator/README.md)
- [.Net-laskin](../../../../03-GettingStarted/samples/csharp)
- [JavaScript-laskin](../samples/javascript/README.md)
- [TypeScript-laskin](../samples/typescript/README.md)
- [Python-laskin](../../../../03-GettingStarted/samples/python)

## Mitä seuraavaksi

- Seuraavaksi: [Asiakkaan luominen LLM:n kanssa](/03-GettingStarted/03-llm-client/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä AI-käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, on hyvä olla tietoinen siitä, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää auktoritatiivisena lähteenä. Kriittisen tiedon kohdalla suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinkäsityksistä tai virhetulkinnoista.