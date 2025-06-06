<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:33:24+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "fi"
}
-->
# 📖 MCP Core Concepts: Mallinna kontekstiprotokollan hallinta tekoälyintegraatioon

Model Context Protocol (MCP) on tehokas, standardoitu kehys, joka optimoi viestinnän suurten kielimallien (LLM) ja ulkoisten työkalujen, sovellusten sekä tietolähteiden välillä. Tämä SEO-optimoitu opas johdattaa sinut MCP:n keskeisiin käsitteisiin, varmistaen, että ymmärrät sen asiakas-palvelinarkkitehtuurin, olennaiset osat, viestintämekanismit ja toteutuksen parhaat käytännöt.

## Yleiskatsaus

Tässä oppitunnissa käsitellään Model Context Protocol (MCP) -ekosysteemin perustavanlaatuista arkkitehtuuria ja komponentteja. Opit asiakas-palvelinarkkitehtuurista, keskeisistä osista ja viestintämekanismeista, jotka mahdollistavat MCP-vuorovaikutukset.

## 👩‍🎓 Keskeiset oppimistavoitteet

Oppitunnin lopussa osaat:

- Ymmärtää MCP:n asiakas-palvelinarkkitehtuurin.
- Tunnistaa Hostsien, Clientsien ja Serversien roolit ja vastuut.
- Analysoida MCP:n joustavan integraatiokerroksen keskeiset ominaisuudet.
- Oppia, miten tieto virtaa MCP-ekosysteemissä.
- Saada käytännön näkemyksiä koodiesimerkkien kautta .NET:ssä, Javassa, Pythonissa ja JavaScriptissä.

## 🔎 MCP-arkkitehtuuri: Syvällisempi katsaus

MCP-ekosysteemi rakentuu asiakas-palvelin-mallin varaan. Tämä modulaarinen rakenne mahdollistaa tekoälysovellusten tehokkaan vuorovaikutuksen työkalujen, tietokantojen, API:en ja kontekstuaalisten resurssien kanssa. Puretaan tämä arkkitehtuuri sen ydinkomponentteihin.

### 1. Hosts

Model Context Protocolissa (MCP) Hostsilla on keskeinen rooli ensisijaisena käyttöliittymänä, jonka kautta käyttäjät ovat vuorovaikutuksessa protokollan kanssa. Hostit ovat sovelluksia tai ympäristöjä, jotka aloittavat yhteydet MCP-palvelimiin saadakseen käyttöönsä dataa, työkaluja ja kehotteita. Esimerkkejä Host-sovelluksista ovat integroitu kehitysympäristö (IDE) kuten Visual Studio Code, tekoälytyökalut kuten Claude Desktop tai räätälöidyt agentit tiettyihin tehtäviin.

**Hosts** ovat LLM-sovelluksia, jotka aloittavat yhteydenoton. Ne:

- Suorittavat tai ovat vuorovaikutuksessa tekoälymallien kanssa vastauksien tuottamiseksi.
- Aloittavat yhteydet MCP-palvelimiin.
- Hallinnoivat keskustelun kulkua ja käyttöliittymää.
- Valvovat käyttöoikeuksia ja turvallisuusrajoituksia.
- Käsittelevät käyttäjän suostumusta datan jakamiseen ja työkalujen käyttöön.

### 2. Clients

Clients ovat olennaisia komponentteja, jotka helpottavat vuorovaikutusta Hostsien ja MCP-palvelimien välillä. Clients toimivat välittäjinä, jotka mahdollistavat Hostien pääsyn MCP-palvelimien tarjoamiin toimintoihin. Ne varmistavat sujuvan viestinnän ja tehokkaan tiedonsiirron MCP-arkkitehtuurissa.

**Clients** ovat liittimiä host-sovelluksen sisällä. Ne:

- Lähettävät pyyntöjä palvelimille kehotteiden tai ohjeiden kanssa.
- Neuvottelevat palvelimien kanssa tuetuista ominaisuuksista.
- Hallinnoivat mallien työkalukäyttöpyyntöjä.
- Käsittelevät ja näyttävät vastauksia käyttäjille.

### 3. Servers

Servers vastaavat MCP-clienttien pyyntöjen käsittelystä ja sopivien vastausten tarjoamisesta. Ne hoitavat erilaisia toimintoja kuten datan hakua, työkalujen suorittamista ja kehotteiden generointia. Servers varmistavat, että kommunikointi clienttien ja Hostsien välillä on tehokasta ja luotettavaa, säilyttäen vuorovaikutuksen eheyden.

**Servers** ovat palveluita, jotka tarjoavat kontekstia ja toiminnallisuuksia. Ne:

- Rekisteröivät käytettävissä olevat ominaisuudet (resurssit, kehotteet, työkalut)
- Ottavat vastaan ja suorittavat työkalukutsut clientiltä
- Tarjoavat kontekstuaalista tietoa mallin vastausten parantamiseksi
- Palauttavat tulokset takaisin clientille
- Ylläpitävät tilaa vuorovaikutusten aikana tarvittaessa

Servers voidaan kehittää vapaasti laajentamaan mallin toiminnallisuuksia erikoistuneilla ominaisuuksilla.

### 4. Server Features

Model Context Protocolin (MCP) palvelimet tarjoavat perusrakenteet, jotka mahdollistavat rikkaan vuorovaikutuksen clienttien, hostien ja kielimallien välillä. Nämä ominaisuudet on suunniteltu parantamaan MCP:n kyvykkyyksiä tarjoamalla jäsenneltyä kontekstia, työkaluja ja kehotteita.

MCP-palvelimet voivat tarjota seuraavia ominaisuuksia:

#### 📑 Resurssit

Resurssit MCP:ssä käsittävät erilaisia kontekstin ja datan tyyppejä, joita käyttäjät tai tekoälymallit voivat hyödyntää. Näihin kuuluvat:

- **Kontekstuaalinen data**: Tieto ja konteksti, jota käyttäjät tai mallit voivat käyttää päätöksenteossa ja tehtävien suorittamisessa.
- **Tietopohjat ja dokumenttivarastot**: Rakenteelliset ja rakenteettomat tietokokoelmat, kuten artikkelit, manuaalit ja tutkimuspaperit, jotka tarjoavat arvokasta tietoa.
- **Paikalliset tiedostot ja tietokannat**: Laitteilla tai tietokannoissa paikallisesti säilytettävä data, joka on käytettävissä käsittelyyn ja analyysiin.
- **API:t ja verkkopalvelut**: Ulkoiset rajapinnat ja palvelut, jotka tarjoavat lisätietoja ja toimintoja mahdollistaen integraation eri verkkolähteiden ja työkalujen kanssa.

Esimerkkinä resurssista voi olla tietokantakaavio tai tiedosto, johon pääsee käsiksi esimerkiksi näin:

```text
file://log.txt
database://schema
```

### 🤖 Kehotteet

MCP:n kehotteet sisältävät erilaisia valmiiksi määriteltyjä malleja ja vuorovaikutuskuvioita, jotka on suunniteltu tehostamaan käyttäjän työnkulkuja ja parantamaan viestintää. Näihin kuuluvat:

- **Mallinnetut viestit ja työnkulut**: Ennalta rakennetut viestit ja prosessit, jotka ohjaavat käyttäjiä tiettyjen tehtävien ja vuorovaikutusten läpi.
- **Valmiiksi määritellyt vuorovaikutuskuviot**: Standardoidut toimintojen ja vastausten sarjat, jotka helpottavat johdonmukaista ja tehokasta viestintää.
- **Erikoistuneet keskustelumallit**: Räätälöitävät mallit tiettyihin keskustelutyyppeihin, jotka varmistavat relevantin ja kontekstuaalisesti sopivan vuorovaikutuksen.

Kehotemalli voi näyttää tältä:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Työkalut

MCP:n työkalut ovat toimintoja, joita tekoälymalli voi suorittaa tiettyjen tehtävien hoitamiseksi. Nämä työkalut on suunniteltu laajentamaan mallin kyvykkyyksiä tarjoamalla rakenteellisia ja luotettavia toimintoja. Keskeiset piirteet ovat:

- **Tekoälymallin suoritettavat funktiot**: Työkalut ovat suoritettavia funktioita, joita malli voi kutsua eri tehtäviin.
- **Uniikki nimi ja kuvaus**: Jokaisella työkalulla on selkeä nimi ja yksityiskohtainen kuvaus sen tarkoituksesta ja toiminnasta.
- **Parametrit ja tulosteet**: Työkalut ottavat vastaan tiettyjä parametreja ja palauttavat jäsenneltyjä tuloksia, mikä takaa johdonmukaiset ja ennakoitavat vastaukset.
- **Eristetyt toiminnot**: Työkalut suorittavat erillisiä toimintoja, kuten verkkohakuja, laskelmia tai tietokantakyselyjä.

Esimerkki työkalusta voisi näyttää tältä:

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

## Client-ominaisuudet

Model Context Protocolissa (MCP) clientit tarjoavat useita keskeisiä ominaisuuksia palvelimille, parantaen protokollan kokonaisfunktionaalisuutta ja vuorovaikutusta. Yksi merkittävistä ominaisuuksista on Sampling.

### 👉 Sampling

- **Palvelimen aloittamat agenttikäyttäytymiset**: Clientit mahdollistavat palvelimien autonomiset toimet tai käyttäytymismallit, lisäten järjestelmän dynaamisia kyvykkyyksiä.
- **Rekursiiviset LLM-vuorovaikutukset**: Tämä ominaisuus sallii toistuvat vuorovaikutukset suurten kielimallien kanssa, mahdollistaen monimutkaisempaa ja iteratiivista tehtävien käsittelyä.
- **Lisämallin täydentämisten pyytäminen**: Palvelimet voivat pyytää mallilta lisävalmisteluja varmistaen, että vastaukset ovat perusteellisia ja kontekstuaalisesti sopivia.

## Tiedon kulku MCP:ssä

Model Context Protocol (MCP) määrittelee jäsennellyn tiedonkulun hostsien, clienttien, palvelimien ja mallien välillä. Tämän virtauksen ymmärtäminen selkeyttää, miten käyttäjän pyynnöt käsitellään ja miten ulkoiset työkalut ja data integroidaan mallin vastauksiin.

- **Host aloittaa yhteyden**  
  Host-sovellus (kuten IDE tai chat-käyttöliittymä) muodostaa yhteyden MCP-palvelimeen, tyypillisesti STDIO:n, WebSocketin tai muun tuetun siirtokerroksen kautta.

- **Ominaisuuksien neuvottelu**  
  Client (hostin sisällä) ja palvelin vaihtavat tietoa tuetuista ominaisuuksista, työkaluista, resursseista ja protokollaversioista. Tämä varmistaa, että molemmat osapuolet ymmärtävät käytettävissä olevat kyvykkyydet istunnon aikana.

- **Käyttäjän pyyntö**  
  Käyttäjä on vuorovaikutuksessa hostin kanssa (esim. syöttää kehotteen tai komennon). Host kerää tämän syötteen ja välittää sen clientille käsittelyä varten.

- **Resurssin tai työkalun käyttö**  
  - Client voi pyytää lisäkontekstia tai resursseja palvelimelta (esim. tiedostoja, tietokanta-merkintöjä tai tietopohjan artikkeleita) mallin ymmärryksen rikastamiseksi.
  - Jos malli päättää, että työkalua tarvitaan (esim. datan hakemiseen, laskelman suorittamiseen tai API-kutsuun), client lähettää työkalukutsupyynnön palvelimelle, määrittäen työkalun nimen ja parametrit.

- **Palvelimen suoritus**  
  Palvelin vastaanottaa resurssi- tai työkalupyynnön, suorittaa tarvittavat toimenpiteet (kuten funktion suoritus, tietokantakysely tai tiedoston haku) ja palauttaa tulokset clientille jäsennellyssä muodossa.

- **Vastauksen generointi**  
  Client integroi palvelimen vastaukset (resurssidata, työkalujen tulosteet jne.) meneillään olevaan mallin vuorovaikutukseen. Malli käyttää tätä tietoa luodakseen kattavan ja kontekstuaalisesti sopivan vastauksen.

- **Tuloksen esittäminen**  
  Host vastaanottaa clientin lopullisen tuloksen ja esittää sen käyttäjälle, usein sisältäen sekä mallin generoiman tekstin että mahdolliset työkalujen suoritustulokset tai resurssihaut.

Tämä tiedonkulku mahdollistaa MCP:n tukemaan edistyneitä, interaktiivisia ja kontekstitietoisia tekoälysovelluksia yhdistämällä mallit saumattomasti ulkoisiin työkaluihin ja tietolähteisiin.

## Protokollan yksityiskohdat

MCP (Model Context Protocol) rakentuu [JSON-RPC 2.0](https://www.jsonrpc.org/) -protokollan päälle tarjoten standardoidun, kieliriippumattoman viestimuodon hostsien, clienttien ja palvelimien väliseen viestintään. Tämä perusta mahdollistaa luotettavat, rakenteelliset ja laajennettavat vuorovaikutukset eri alustoilla ja ohjelmointikielillä.

### Keskeiset protokollaominaisuudet

MCP laajentaa JSON-RPC 2.0:aa lisäkäytännöillä työkalukutsuille, resurssien käytölle ja kehotteiden hallinnalle. Se tukee useita siirtokerroksia (STDIO, WebSocket, SSE) ja mahdollistaa turvallisen, laajennettavan ja kieliriippumattoman viestinnän komponenttien välillä.

#### 🧢 Perusprotokolla

- **JSON-RPC-viestimuoto**: Kaikki pyynnöt ja vastaukset käyttävät JSON-RPC 2.0 -määrittelyä, varmistaen yhtenäisen rakenteen metodikutsuille, parametreille, tuloksille ja virheenkäsittelylle.
- **Tila säilyvät yhteydet**: MCP-istunnot ylläpitävät tilaa useiden pyyntöjen yli, tukien jatkuvia keskusteluja, kontekstin kertymistä ja resurssien hallintaa.
- **Ominaisuuksien neuvottelu**: Yhteyden muodostuksen yhteydessä clientit ja palvelimet vaihtavat tietoa tuetuista ominaisuuksista, protokollaversioista, käytettävissä olevista työkaluista ja resursseista. Tämä varmistaa molemminpuolisen ymmärryksen ja joustavan sopeutumisen.

#### ➕ Lisäapuvälineitä

Alla on joitakin MCP:n tarjoamia lisäapuvälineitä ja protokollan laajennuksia, jotka parantavat kehittäjäkokemusta ja mahdollistavat edistyneet käyttötapaukset:

- **Konfigurointivaihtoehdot**: MCP sallii istuntoparametrien dynaamisen konfiguroinnin, kuten työkalujen käyttöoikeudet, resurssien saatavuus ja mallin asetukset, räätälöitynä kuhunkin vuorovaikutukseen.
- **Edistymisen seuranta**: Pitkään kestävät toiminnot voivat raportoida edistymistietoja, mahdollistaen responsiivisen käyttöliittymän ja paremman käyttökokemuksen monimutkaisissa tehtävissä.
- **Pyyntöjen peruutus**: Clientit voivat peruuttaa kesken olevia pyyntöjä, antaen käyttäjille mahdollisuuden keskeyttää tarpeettomat tai liian pitkään kestävät toiminnot.
- **Virheraportointi**: Standardoidut virheilmoitukset ja -koodit auttavat ongelmien diagnosoinnissa, virheiden hallinnassa ja tarjoavat toiminnallista palautetta käyttäjille ja kehittäjille.
- **Lokitus**: Sekä clientit että palvelimet voivat tuottaa jäsenneltyjä lokitietoja auditointia, virheenkorjausta ja protokollan valvontaa varten.

Näiden protokollaominaisuuksien avulla MCP takaa vankan, turvallisen ja joustavan viestinnän kielimallien ja ulkoisten työkalujen tai tietolähteiden välillä.

### 🔐 Turvallisuusnäkökohdat

MCP:n toteutusten tulee noudattaa useita keskeisiä turvallisuusperiaatteita varmistaakseen turvalliset ja luotettavat vuorovaikutukset:

- **Käyttäjän suostumus ja hallinta**: Käyttäjiltä on saatava selkeä suostumus ennen datan käyttöä tai toimintojen suorittamista. Heillä tulee olla selkeä hallinta siitä, mitä tietoja jaetaan ja mitkä toimet ovat sallittuja, tuettuna intuitiivisilla käyttöliittymillä toimintojen tarkasteluun ja hyväksyntään.

- **Datan yksityisyys**: Käyttäjädatan näkyvyys on sallittava vain nimenomaisella suostumuksella, ja sitä tulee suojata asianmukaisin käyttöoikeuksin. MCP-toteutusten tulee estää luvaton datansiirto ja varmistaa yksityisyyden säilyminen kaikissa vuorovaikutuksissa.

- **Työkalujen turvallisuus**: Ennen työkalun kutsumista vaaditaan käyttäjän selkeä suostumus. Käyttäjien tulee ymmärtää kunkin työkalun toiminta, ja tiukat turvallisuusrajoitteet on otettava käyttöön estämään tahattomat tai vaaralliset työkalun suoritukset.

Näiden periaatteiden noudattaminen varmistaa, että MCP ylläpitää käyttäjien luottamusta, yksityisyyttä ja turvallisuutta kaikissa protokollan vuorovaikutuksissa.

## Koodiesimerkit: Keskeiset komponentit

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää auktoritatiivisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinkäsityksistä tai tulkinnoista.