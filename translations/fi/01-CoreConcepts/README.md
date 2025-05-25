<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-20T21:52:46+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "fi"
}
-->
# 📖 MCP Core Concepts: Mallinna kontekstiprotokollan hallinta tekoälyn integrointiin

Model Context Protocol (MCP) on tehokas, standardoitu kehys, joka optimoi kommunikoinnin suurten kielimallien (LLM) ja ulkoisten työkalujen, sovellusten sekä tietolähteiden välillä. Tämä SEO-optimoitu opas johdattaa sinut MCP:n keskeisiin käsitteisiin, varmistaen että ymmärrät sen asiakas-palvelinarkkitehtuurin, olennaiset osat, viestintämekanismit ja toteutuksen parhaat käytännöt.

## Yleiskatsaus

Tässä oppitunnissa käsitellään Model Context Protocolin (MCP) perustavanlaatuista arkkitehtuuria ja komponentteja. Opit asiakas-palvelinarkkitehtuurista, keskeisistä osista ja viestintämekanismeista, jotka mahdollistavat MCP-vuorovaikutukset.

## 👩‍🎓 Keskeiset oppimistavoitteet

Tämän oppitunnin jälkeen osaat:

- Ymmärtää MCP:n asiakas-palvelinarkkitehtuurin.
- Tunnistaa Hostsien, Clientsien ja Serversien roolit ja vastuut.
- Analysoida MCP:n joustavan integraatiokerroksen ydintoiminnot.
- Oppia, miten tieto virtaa MCP-ekosysteemissä.
- Saada käytännön näkemyksiä koodiesimerkkien kautta .NET:ssä, Javassa, Pythonissa ja JavaScriptissä.

## 🔎 MCP-arkkitehtuuri: Syvällisempi katsaus

MCP-ekosysteemi perustuu asiakas-palvelinmalliin. Tämä modulaarinen rakenne mahdollistaa tekoälysovellusten tehokkaan vuorovaikutuksen työkalujen, tietokantojen, rajapintojen ja kontekstuaalisten resurssien kanssa. Puretaanpa tämä arkkitehtuuri sen keskeisiin osiin.

### 1. Hosts

Model Context Protocolissa (MCP) Hostsilla on keskeinen rooli ensisijaisena käyttöliittymänä, jonka kautta käyttäjät ovat vuorovaikutuksessa protokollan kanssa. Hostit ovat sovelluksia tai ympäristöjä, jotka aloittavat yhteydet MCP-palvelimiin päästäkseen käsiksi dataan, työkaluihin ja kehotteisiin. Esimerkkejä Host-sovelluksista ovat integroitu kehitysympäristö (IDE) kuten Visual Studio Code, tekoälytyökalut kuten Claude Desktop tai tehtäviin räätälöidyt agentit.

**Hostit** ovat LLM-sovelluksia, jotka aloittavat yhteydet. Ne:

- Suorittavat tai ovat vuorovaikutuksessa tekoälymallien kanssa vastausten tuottamiseksi.
- Aloittavat yhteydet MCP-palvelimiin.
- Hallinnoivat keskustelun kulkua ja käyttöliittymää.
- Valvovat käyttöoikeuksia ja turvallisuusrajoituksia.
- Käsittelevät käyttäjän suostumuksen tiedon jakamiseen ja työkalujen suorittamiseen.

### 2. Clients

Clientit ovat olennaisia komponentteja, jotka helpottavat vuorovaikutusta Hostsien ja MCP-palvelimien välillä. Clientit toimivat välikäsinä, jotka mahdollistavat Hostien pääsyn MCP-palvelimien tarjoamiin toimintoihin. Ne varmistavat sujuvan viestinnän ja tehokkaan tiedonsiirron MCP-arkkitehtuurissa.

**Clientit** ovat liittimiä host-sovelluksen sisällä. Ne:

- Lähettävät palvelimille pyyntöjä kehotteiden ja ohjeiden kanssa.
- Neuvottelevat ominaisuuksista palvelimien kanssa.
- Hallinnoivat mallien työkalukutsupyyntöjä.
- Käsittelevät ja näyttävät vastaukset käyttäjille.

### 3. Servers

Serverit vastaavat MCP-clienttien pyyntöjen käsittelystä ja sopivien vastausten tarjoamisesta. Ne hoitavat erilaisia toimintoja kuten datan hakua, työkalujen suorittamista ja kehotteiden luomista. Serverit varmistavat, että kommunikointi clienttien ja Hostsien välillä on tehokasta ja luotettavaa, säilyttäen vuorovaikutuksen eheys.

**Serverit** ovat palveluita, jotka tarjoavat kontekstia ja toimintoja. Ne:

- Rekisteröivät käytettävissä olevat ominaisuudet (resurssit, kehotteet, työkalut).
- Ottavat vastaan ja suorittavat työkalukutsuja clientiltä.
- Tarjoavat kontekstuaalista tietoa mallin vastausten parantamiseksi.
- Palauttavat tulokset clientille.
- Säilyttävät tilan vuorovaikutusten ajan tarvittaessa.

Servereitä voi kuka tahansa kehittää laajentaakseen mallin toiminnallisuutta erikoistuneilla ominaisuuksilla.

### 4. Serverin ominaisuudet

Model Context Protocolin (MCP) serverit tarjoavat perusrakenteet, jotka mahdollistavat rikkaat vuorovaikutukset clienttien, hostsien ja kielimallien välillä. Nämä ominaisuudet on suunniteltu parantamaan MCP:n kyvykkyyksiä tarjoamalla jäsenneltyä kontekstia, työkaluja ja kehotteita.

MCP-serverit voivat tarjota seuraavia ominaisuuksia:

#### 📑 Resurssit

MCP:n resurssit kattavat erilaisia kontekstin ja datan tyyppejä, joita käyttäjät tai tekoälymallit voivat hyödyntää. Näitä ovat:

- **Kontekstuaalinen data**: Tieto ja konteksti, jota käyttäjät tai mallit voivat käyttää päätöksenteossa ja tehtävien suorittamisessa.
- **Tietopohjat ja dokumenttivarastot**: Rakenteelliset ja rakenteettomat tiedonkeräykset, kuten artikkelit, manuaalit ja tutkimuspaperit, jotka tarjoavat arvokkaita näkemyksiä.
- **Paikalliset tiedostot ja tietokannat**: Laitteilla tai tietokannoissa paikallisesti tallennetut tiedot, jotka ovat käytettävissä käsittelyyn ja analyysiin.
- **Rajapinnat ja verkkopalvelut**: Ulkoiset rajapinnat ja palvelut, jotka tarjoavat lisätietoja ja toimintoja mahdollistaen integraation erilaisiin online-resursseihin ja työkaluihin.

Esimerkki resurssista voi olla tietokantakaavio tai tiedosto, johon pääsee käsiksi seuraavasti:

```text
file://log.txt
database://schema
```

### 🤖 Kehotteet

MCP:n kehotteet sisältävät erilaisia valmiiksi määriteltyjä malleja ja vuorovaikutusmalleja, jotka tehostavat käyttäjän työnkulkuja ja parantavat viestintää. Näitä ovat:

- **Mallinnetut viestit ja työnkulut**: Esirakennetut viestit ja prosessit, jotka ohjaavat käyttäjiä tiettyjen tehtävien ja vuorovaikutusten läpi.
- **Ennalta määritellyt vuorovaikutusmallit**: Standardoidut toimintojen ja vastausten sarjat, jotka mahdollistavat johdonmukaisen ja tehokkaan viestinnän.
- **Erikoistuneet keskustelumallit**: Mukautettavat mallit tietyn tyyppisille keskusteluille, jotka takaavat asiaankuuluvat ja kontekstuaalisesti sopivat vuorovaikutukset.

Kehotemalli voi näyttää esimerkiksi tältä:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Työkalut

MCP:n työkalut ovat funktioita, joita tekoälymalli voi suorittaa tiettyjen tehtävien hoitamiseksi. Nämä työkalut on suunniteltu laajentamaan mallin kykyjä tarjoamalla jäsenneltyjä ja luotettavia toimintoja. Keskeisiä piirteitä ovat:

- **Tekoälymallin suoritettavat funktiot**: Työkalut ovat suoritettavia funktioita, joita malli voi kutsua tehtävien suorittamiseen.
- **Uniikki nimi ja kuvaus**: Jokaisella työkalulla on oma nimi ja yksityiskohtainen kuvaus sen tarkoituksesta ja toiminnallisuudesta.
- **Parametrit ja tulosteet**: Työkalut vastaanottavat tiettyjä parametreja ja palauttavat jäsenneltyjä tuloksia, mikä takaa johdonmukaiset ja ennakoitavat lopputulokset.
- **Erottuvat toiminnot**: Työkalut suorittavat erillisiä toimintoja, kuten verkkohakuja, laskelmia ja tietokantakyselyitä.

Esimerkkityökalu voisi näyttää tältä:

```typescript
server.tool(
  "GetProducts",
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Clientin ominaisuudet

MCP:ssä clientit tarjoavat palvelimille useita keskeisiä ominaisuuksia, jotka parantavat protokollan kokonaisfunktionaalisuutta ja vuorovaikutusta. Yksi merkittävistä ominaisuuksista on Sampling.

### 👉 Sampling

- **Palvelimen aloittamat agenttitoiminnot**: Clientit mahdollistavat palvelimille tiettyjen toimintojen tai käyttäytymisten autonomisen aloittamisen, lisäten järjestelmän dynaamisuutta.
- **Rekursiiviset LLM-vuorovaikutukset**: Tämä ominaisuus sallii toistuvat vuorovaikutukset suurten kielimallien kanssa, mahdollistaen monimutkaisemman ja iteratiivisen tehtävien käsittelyn.
- **Lisämallin lopputulosten pyytäminen**: Palvelimet voivat pyytää mallilta lisävalmiita vastauksia varmistaakseen perusteelliset ja kontekstuaalisesti merkitykselliset tulokset.

## Tiedon virtaus MCP:ssä

Model Context Protocol määrittelee jäsennellyn tiedon kulun Hostsien, clienttien, palvelimien ja mallien välillä. Tämä auttaa selventämään, miten käyttäjän pyynnöt käsitellään ja miten ulkoiset työkalut sekä data integroidaan mallivastauksiin.

- **Host aloittaa yhteyden**  
  Host-sovellus (kuten IDE tai chat-käyttöliittymä) muodostaa yhteyden MCP-palvelimeen tyypillisesti STDIO:n, WebSocketin tai muun tuetun siirtotavan kautta.

- **Kyvykkyyksien neuvottelu**  
  Client (hostin sisällä) ja palvelin vaihtavat tietoa tuetuista ominaisuuksista, työkaluista, resursseista ja protokollaversioista. Tämä varmistaa, että molemmat osapuolet ymmärtävät käytettävissä olevat kyvykkyydet.

- **Käyttäjän pyyntö**  
  Käyttäjä on vuorovaikutuksessa hostin kanssa (esim. syöttää kehotteen tai komennon). Host kerää tämän syötteen ja välittää sen clientille käsittelyä varten.

- **Resurssin tai työkalun käyttö**  
  - Client voi pyytää lisäkontekstia tai resursseja palvelimelta (kuten tiedostoja, tietokantatietoja tai tietopohjan artikkeleita) mallin ymmärryksen rikastamiseksi.
  - Jos malli katsoo, että työkalua tarvitaan (esim. tiedon hakemiseen, laskelman tekemiseen tai rajapinnan kutsumiseen), client lähettää työkalukutsupyynnön palvelimelle, jossa määritellään työkalun nimi ja parametrit.

- **Palvelimen suoritus**  
  Palvelin vastaanottaa resurssi- tai työkalupyynnön, suorittaa tarvittavat toimenpiteet (kuten funktion ajon, tietokantakyselyn tai tiedoston haun) ja palauttaa tulokset clientille jäsennellyssä muodossa.

- **Vastauksen muodostus**  
  Client integroi palvelimen vastaukset (resurssidata, työkalutulokset jne.) käynnissä olevaan mallivaihtoon. Malli käyttää tätä tietoa tuottaakseen kattavan ja kontekstuaalisesti sopivan vastauksen.

- **Tuloksen esittäminen**  
  Host vastaanottaa clientiltä lopullisen tuloksen ja esittää sen käyttäjälle, usein sisältäen mallin tuottaman tekstin sekä mahdolliset työkalukutsujen tai resurssihakujen tulokset.

Tämä virtaus mahdollistaa MCP:n tukemaan kehittyneitä, interaktiivisia ja kontekstuaalisesti tietoisia tekoälysovelluksia yhdistämällä mallit saumattomasti ulkoisiin työkaluihin ja tietolähteisiin.

## Protokollan yksityiskohdat

MCP (Model Context Protocol) perustuu [JSON-RPC 2.0](https://www.jsonrpc.org/) -standardiin, tarjoten yhdenmukaisen, kieliriippumattoman viestiformaatin kommunikointiin Hostsien, clienttien ja palvelimien välillä. Tämä perusta mahdollistaa luotettavat, jäsennellyt ja laajennettavat vuorovaikutukset eri alustoilla ja ohjelmointikielillä.

### Keskeiset protokollaominaisuudet

MCP laajentaa JSON-RPC 2.0:aa lisäkäytännöillä työkalukutsuille, resurssien käytölle ja kehotteiden hallinnalle. Se tukee useita siirtokerroksia (STDIO, WebSocket, SSE) ja mahdollistaa turvallisen, laajennettavan ja kieliriippumattoman viestinnän komponenttien välillä.

#### 🧢 Perusprotokolla

- **JSON-RPC-viestimuoto**: Kaikki pyynnöt ja vastaukset noudattavat JSON-RPC 2.0 -määrittelyä, varmistaen yhtenäisen rakenteen metodikutsuissa, parametreissa, tuloksissa ja virheenkäsittelyssä.
- **Tilalliset yhteydet**: MCP-istunnot säilyttävät tilan useiden pyyntöjen ajan, tukien jatkuvia keskusteluja, kontekstin kertymistä ja resurssien hallintaa.
- **Kyvykkyyksien neuvottelu**: Yhteyden muodostuksen yhteydessä clientit ja palvelimet vaihtavat tietoa tuetuista ominaisuuksista, protokollaversioista, käytettävissä olevista työkaluista ja resursseista. Tämä varmistaa molemminpuolisen ymmärryksen ja sopeutumisen.

#### ➕ Lisäominaisuudet

Alla on joitain lisäominaisuuksia ja protokollan laajennuksia, joita MCP tarjoaa kehittäjäkokemuksen parantamiseksi ja kehittyneiden skenaarioiden mahdollistamiseksi:

- **Konfigurointivaihtoehdot**: MCP mahdollistaa istunnon parametrien dynaamisen konfiguroinnin, kuten työkalujen käyttöoikeudet, resurssien pääsy ja mallin asetukset, räätälöitynä kuhunkin vuorovaikutukseen.
- **Edistymisen seuranta**: Pitkään kestävät toiminnot voivat raportoida edistymistietoja, mahdollistaen responsiiviset käyttöliittymät ja paremman käyttäjäkokemuksen monimutkaisissa tehtävissä.
- **Pyyntöjen peruutus**: Clientit voivat peruuttaa kesken olevat pyynnöt, jolloin käyttäjät voivat keskeyttää tarpeettomat tai liian pitkään kestävät toiminnot.
- **Virheraportointi**: Standardoidut virheilmoitukset ja koodit auttavat ongelmien diagnosoinnissa, virheiden hallinnassa ja tarjoavat toimivia palautteita käyttäjille ja kehittäjille.
- **Lokitus**: Sekä clientit että palvelimet voivat tuottaa jäsenneltyjä lokeja auditointia, virheenkorjausta ja protokollan valvontaa varten.

Näiden protokollaominaisuuksien avulla MCP varmistaa luotettavan, turvallisen ja joustavan kommunikoinnin kielimallien ja ulkoisten työkalujen tai tietolähteiden välillä.

### 🔐 Turvallisuusnäkökohdat

MCP:n toteutusten tulee noudattaa useita keskeisiä turvallisuusperiaatteita varmistaakseen turvalliset ja luotettavat vuorovaikutukset:

- **Käyttäjän suostumus ja hallinta**: Käyttäjien on annettava selkeä suostumus ennen kuin mitään dataa käytetään tai toimintoja suoritetaan. Heillä tulee olla selkeä kontrolli siitä, mitä tietoja jaetaan ja mitkä toiminnot ovat sallittuja, tuettuna intuitiivisilla käyttöliittymillä toimien tarkasteluun ja hyväksymiseen.

- **Datan yksityisyys**: Käyttäjätiedot ovat saatavilla vain nimenomaisella suostumuksella ja ne on suojattava asianmukaisin käyttöoikeuksin. MCP-toteutusten on estettävä luvaton tiedonsiirto ja varmistettava yksityisyyden säilyminen kaikissa vuorovaikutuksissa.

- **Työkalujen turvallisuus**: Ennen työkalun kutsumista tarvitaan käyttäjän selkeä suostumus. Käyttäjien tulee ymmärtää kunkin työkalun toiminnallisuus, ja tiukat turvallisuusrajoitukset on toteutettava estämään tahattomat tai vaaralliset työkalusuoritukset.

Näitä periaatteita noudattamalla MCP varmistaa käyttäjien luottamuksen, yksityisyyden ja turvallisuuden kaikissa protokollan vuorovaikutuksissa.

## Koodiesimerkit: Keskeiset komponentit

Alla on esimerkkejä useilla suosituilla ohjelmointikielillä, jotka havainnollistavat, miten toteuttaa keskeisiä MCP-palvelinkomponentteja ja työkaluja.

### .NET-esimerk

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä tulee pitää auktoritatiivisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.