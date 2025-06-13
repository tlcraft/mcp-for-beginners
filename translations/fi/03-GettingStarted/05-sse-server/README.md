<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "64645691bf0985f1760b948123edf269",
  "translation_date": "2025-06-13T10:52:48+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "fi"
}
-->
Nyt kun tiedämme vähän enemmän SSE:stä, rakennetaan seuraavaksi SSE-palvelin.

## Harjoitus: SSE-palvelimen luominen

Palvelimen luomiseksi meidän täytyy pitää mielessä kaksi asiaa:

- Tarvitsemme web-palvelimen, joka tarjoaa päätepisteet yhteyksille ja viesteille.
- Rakennamme palvelimen kuten normaalisti käyttäen työkaluja, resursseja ja kehotteita, kuten stdioa käytettäessä.

### -1- Luo palvelininstanssi

Palvelimen luomiseksi käytämme samoja tyyppejä kuin stdio:ssa. Siitä huolimatta, siirtotavaksi valitaan SSE. 

Seuraavaksi lisätään tarvittavat reitit.

### -2- Lisää reitit

Lisätään reitit, jotka käsittelevät yhteyden ja saapuvat viestit:

Seuraavaksi lisätään palvelimen ominaisuuksia.

### -3- Palvelimen ominaisuuksien lisääminen

Nyt kun olemme määritelleet kaiken SSE-spesifin, lisätään palvelimen ominaisuuksia kuten työkaluja, kehotteita ja resursseja.

Koko koodisi pitäisi näyttää tältä:

Hienoa, meillä on SSE:tä käyttävä palvelin, kokeillaan sitä seuraavaksi.

## Harjoitus: SSE-palvelimen virheenkorjaus Inspectorilla

Inspector on loistava työkalu, jonka näimme aiemmassa oppitunnissa [Ensimmäisen palvelimen luominen](/03-GettingStarted/01-first-server/README.md). Katsotaan, voimmeko käyttää Inspectoria myös tässä:

### -1- Inspectorin käynnistäminen

Inspectoria varten sinun täytyy ensin saada SSE-palvelin käyntiin, tehdään se nyt:

1. Käynnistä palvelin

1. Käynnistä inspector

    > [!NOTE]
    > Suorita tämä eri komentorivillä kuin missä palvelin on käynnissä. Huomaa myös, että sinun täytyy muokata alla olevaa komentoa vastaamaan palvelimesi URL-osoitetta.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Inspectoria ajetaan samalla tavalla kaikissa ajoympäristöissä. Huomaa, että sen sijaan että antaisit polun palvelimeesi ja komennon palvelimen käynnistämiseen, annat URL-osoitteen, jossa palvelin pyörii, ja määrität myös `/sse`-reitin.

### -2- Työkalun kokeileminen

Yhdistä palvelimeen valitsemalla SSE alasvetovalikosta ja täytä URL-kenttään palvelimesi osoite, esimerkiksi http:localhost:4321/sse. Klikkaa sitten "Connect"-painiketta. Valitse kuten ennenkin listaa työkaluja, valitse työkalu ja anna syötearvot. Näet tuloksen alla olevan kuvan kaltaisena:

![SSE-palvelin käynnissä inspectorissa](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.fi.png)

Hienoa, pystyt työskentelemään inspectorin kanssa. Katsotaan seuraavaksi, miten voimme käyttää Visual Studio Codea.

## Tehtävä

Yritä laajentaa palvelintasi lisäämällä siihen enemmän ominaisuuksia. Katso [tästä sivusta](https://api.chucknorris.io/) esimerkiksi, miten voit lisätä työkalun, joka kutsuu APIa – sinä päätät, miltä palvelimesi näyttää. Hauskaa tekemistä :)

## Ratkaisu

[Ratkaisu](./solution/README.md) Tässä on yksi mahdollinen toimiva ratkaisu koodin kera.

## Tärkeimmät opit

Tämän luvun tärkeimmät opit ovat:

- SSE on toinen tuettu siirtotyyppi stdio:n lisäksi.
- SSE:n tukemiseksi sinun täytyy hallita saapuvia yhteyksiä ja viestejä web-kehyksen avulla.
- Voit käyttää sekä Inspectoria että Visual Studio Codea SSE-palvelimen kuluttamiseen, aivan kuten stdio-palvelinten kanssa. Huomaa kuitenkin, että stdio:n ja SSE:n välillä on pieniä eroja. SSE:n kanssa palvelin täytyy käynnistää erikseen ennen inspectorin käynnistämistä. Inspector-työkalussa täytyy myös määrittää URL-osoite.

## Esimerkit

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Lisäresurssit

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Mitä seuraavaksi

- Seuraavaksi: [HTTP Streaming MCP:llä (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinymmärryksistä tai virhetulkinnoista.