<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90ca3d326c48fab2ac0ebd3a9876f59",
  "translation_date": "2025-07-04T17:51:45+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "fi"
}
-->
Nyt kun tiedämme hieman enemmän SSE:stä, rakennetaan seuraavaksi SSE-palvelin.

## Harjoitus: SSE-palvelimen luominen

Palvelimen luomiseksi meidän on pidettävä mielessä kaksi asiaa:

- Tarvitsemme web-palvelimen, joka tarjoaa päätepisteet yhteyksille ja viesteille.
- Rakennamme palvelimen kuten tavallisesti käyttäen työkaluja, resursseja ja kehotteita, kuten stdioa käytettäessä.

### -1- Luo palvelininstanssi

Palvelimen luomiseksi käytämme samoja tyyppejä kuin stdio:ssa. Kuljetustavaksi valitsemme kuitenkin SSE:n.

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

Inspectorin käynnistämiseksi sinun täytyy ensin saada SSE-palvelin käyntiin, tehdään se nyt:

1. Käynnistä palvelin

1. Käynnistä inspector

    > [!NOTE]
    > Suorita tämä eri terminaali-ikkunassa kuin missä palvelin on käynnissä. Huomaa myös, että sinun täytyy muokata alla olevaa komentoa vastaamaan URL-osoitetta, jossa palvelimesi toimii.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Inspectorin käynnistäminen näyttää samalta kaikissa ajoympäristöissä. Huomaa, että sen sijaan että antaisit polun palvelimelle ja komennon palvelimen käynnistämiseksi, annat URL-osoitteen, jossa palvelin toimii, ja määrität myös `/sse`-reitin.

### -2- Työkalun kokeileminen

Yhdistä palvelimeen valitsemalla pudotusvalikosta SSE ja täytä URL-kenttään palvelimesi osoite, esimerkiksi http:localhost:4321/sse. Klikkaa sitten "Connect"-painiketta. Valitse kuten ennenkin listaa työkaluja, valitse työkalu ja anna syötearvot. Näet tuloksen kuten alla:

![SSE-palvelin käynnissä inspectorissa](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.fi.png)

Hienoa, pystyt työskentelemään inspectorin kanssa, katsotaan seuraavaksi miten voit työskennellä Visual Studio Coden kanssa.

## Tehtävä

Yritä laajentaa palvelintasi lisäämällä siihen ominaisuuksia. Katso [tästä sivusta](https://api.chucknorris.io/) esimerkiksi, miten lisätä työkalu, joka kutsuu API:a. Sinä päätät, miltä palvelimen tulisi näyttää. Hauskaa koodausta :)

## Ratkaisu

[Ratkaisu](./solution/README.md) Tässä on mahdollinen ratkaisu toimivalla koodilla.

## Tärkeimmät opit

Tämän luvun tärkeimmät opit ovat:

- SSE on toinen stdio:n lisäksi tuetuista kuljetustavoista.
- SSE:n tukemiseksi sinun täytyy hallita saapuvia yhteyksiä ja viestejä web-kehyksen avulla.
- Voit käyttää sekä Inspectoria että Visual Studio Codea SSE-palvelimen kuluttamiseen, aivan kuten stdio-palvelimien kanssa. Huomaa, että stdio:n ja SSE:n välillä on pieniä eroja. SSE:n kanssa palvelin täytyy käynnistää erikseen ja sen jälkeen suorittaa inspector-työkalu. Inspector-työkalussa on myös eroavaisuuksia, sillä sinun täytyy määrittää URL-osoite.

## Esimerkit

- [Java-laskin](../samples/java/calculator/README.md)
- [.Net-laskin](../../../../03-GettingStarted/samples/csharp)
- [JavaScript-laskin](../samples/javascript/README.md)
- [TypeScript-laskin](../samples/typescript/README.md)
- [Python-laskin](../../../../03-GettingStarted/samples/python)

## Lisäresurssit

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Mitä seuraavaksi

- Seuraavaksi: [HTTP Streaming MCP:llä (Streamable HTTP)](../06-http-streaming/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.