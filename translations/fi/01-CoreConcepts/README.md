<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T17:29:44+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "fi"
}
-->
# 📖 MCP Core Concepts: Mallintaminen Model Context Protocolille tekoälyn integroinnissa

Model Context Protocol (MCP) on tehokas ja standardoitu kehys, joka optimoi viestinnän suurten kielimallien (LLM) ja ulkoisten työkalujen, sovellusten sekä tietolähteiden välillä. Tämä SEO-optimoitu opas johdattaa sinut MCP:n keskeisiin käsitteisiin, varmistaen, että ymmärrät sen asiakas-palvelin -arkkitehtuurin, olennaiset osat, viestintämekanismit ja parhaat toteutustavat.

## Yleiskatsaus

Tässä oppitunnissa käsitellään Model Context Protocolin (MCP) perusarkkitehtuuria ja sen muodostavia komponentteja. Opit asiakas-palvelin -arkkitehtuurista, keskeisistä osista ja viestintämekanismeista, jotka mahdollistavat MCP:n toiminnan.

## 👩‍🎓 Keskeiset oppimistavoitteet

Tämän oppitunnin jälkeen osaat:

- Ymmärtää MCP:n asiakas-palvelin -arkkitehtuurin.
- Tunnistaa Hostsien, Clientsien ja Serversien roolit ja vastuut.
- Analysoida MCP:n joustavan integraatiokerroksen keskeiset ominaisuudet.
- Oppia, miten tieto kulkee MCP-ekosysteemissä.
- Saada käytännön näkemyksiä .NET-, Java-, Python- ja JavaScript-koodiesimerkkien kautta.

## 🔎 MCP-arkkitehtuuri: Syvällisempi katsaus

MCP-ekosysteemi rakentuu asiakas-palvelin -mallin varaan. Tämä modulaarinen rakenne mahdollistaa tekoälysovellusten tehokkaan vuorovaikutuksen työkalujen, tietokantojen, API:en ja kontekstuaalisten resurssien kanssa. Puretaan tämä arkkitehtuuri sen keskeisiin osiin.

### 1. Hosts

Model Context Protocolissa (MCP) Hostsilla on keskeinen rooli ensisijaisena rajapintana, jonka kautta käyttäjät ovat vuorovaikutuksessa protokollan kanssa. Hostit ovat sovelluksia tai ympäristöjä, jotka aloittavat yhteydet MCP-palvelimiin päästäkseen käsiksi dataan, työkaluihin ja kehotteisiin. Esimerkkejä Host-sovelluksista ovat integroidut kehitysympäristöt (IDE) kuten Visual Studio Code, tekoälytyökalut kuten Claude Desktop tai tehtäväkohtaisesti räätälöidyt agentit.

**Hostit** ovat LLM-sovelluksia, jotka aloittavat yhteydet. Ne:

- Suorittavat tai ovat vuorovaikutuksessa tekoälymallien kanssa vastauksien tuottamiseksi.
- Aloittavat yhteyden MCP-palvelimiin.
- Hallinnoivat keskustelun kulkua ja käyttöliittymää.
- Valvovat käyttöoikeuksia ja turvallisuusrajoituksia.
- Käsittelevät käyttäjän suostumuksen datan jakamiseen ja työkalujen suorittamiseen.

### 2. Clients

Clients ovat olennaisia komponentteja, jotka helpottavat vuorovaikutusta Hostsien ja MCP-palvelimien välillä. Clients toimivat välikätenä, jonka avulla Hostit voivat käyttää MCP-palvelimien tarjoamia toimintoja. Ne varmistavat sujuvan viestinnän ja tehokkaan tiedonsiirron MCP-arkkitehtuurissa.

**Clients** ovat liittimiä host-sovelluksen sisällä. Ne:

- Lähettävät pyyntöjä palvelimille kehotteiden tai ohjeiden kanssa.
- Neuvottelevat palvelimien kanssa ominaisuuksista.
- Hallinnoivat mallien työkalukutsupyyntöjä.
- Käsittelevät ja näyttävät vastaukset käyttäjille.

### 3. Servers

Servers vastaavat MCP-clienttien pyyntöjen käsittelystä ja sopivien vastausten tarjoamisesta. Ne hallinnoivat erilaisia toimintoja, kuten datan hakua, työkalujen suorittamista ja kehotteiden generointia. Servers varmistavat, että viestintä clienttien ja Hostien välillä on tehokasta ja luotettavaa, ylläpitäen vuorovaikutuksen eheyttä.

**Servers** ovat palveluita, jotka tarjoavat kontekstia ja toiminnallisuuksia. Ne:

- Rekisteröivät saatavilla olevat ominaisuudet (resurssit, kehotteet, työkalut).
- Ottavat vastaan ja suorittavat clienttien työkalukutsut.
- Tarjoavat kontekstuaalista tietoa mallin vastausten rikastamiseksi.
- Palauttavat tulokset clientille.
- Ylläpitävät tilaa vuorovaikutusten aikana tarvittaessa.

Servers voidaan kehittää kuka tahansa laajentamaan mallin toiminnallisuutta erikoistuneilla ominaisuuksilla.

### 4. Server Features

Model Context Protocolin (MCP) palvelimet tarjoavat perusrakennuspalikoita, jotka mahdollistavat monipuoliset vuorovaikutukset clienttien, hostien ja kielimallien välillä. Nämä ominaisuudet on suunniteltu parantamaan MCP:n kyvykkyyksiä tarjoamalla jäsenneltyä kontekstia, työkaluja ja kehotteita.

MCP-palvelimet voivat tarjota seuraavia ominaisuuksia:

#### 📑 Resurssit

MCP:n resurssit kattavat erilaiset kontekstin ja datan tyypit, joita käyttäjät tai tekoälymallit voivat hyödyntää. Näihin kuuluvat:

- **Kontekstuaalinen data**: Tietoa ja kontekstia, jota käyttäjät tai tekoälymallit voivat käyttää päätöksenteossa ja tehtävien suorittamisessa.
- **Tietopankit ja dokumenttivarastot**: Rakenteellista ja rakenteetonta dataa, kuten artikkeleita, käyttöoppaita ja tutkimuspapereita, jotka tarjoavat arvokasta tietoa.
- **Paikalliset tiedostot ja tietokannat**: Laitteilla tai tietokannoissa paikallisesti tallennettua dataa, jota voidaan käsitellä ja analysoida.
- **API:t ja verkkopalvelut**: Ulkoiset rajapinnat ja palvelut, jotka tarjoavat lisätietoa ja toimintoja, mahdollistaen integraation eri verkkolähteisiin ja työkaluihin.

Esimerkki resurssista voi olla tietokannan skeema tai tiedosto, johon pääsee käsiksi seuraavasti:

```text
file://log.txt
database://schema
```

### 🤖 Kehotteet

MCP:n kehotteet sisältävät erilaisia ennalta määriteltyjä malleja ja vuorovaikutuskuvioita, jotka tehostavat käyttäjän työnkulkuja ja parantavat viestintää. Näihin kuuluvat:

- **Mallinnetut viestit ja työnkulut**: Ennalta rakennetut viestit ja prosessit, jotka ohjaavat käyttäjiä tiettyjen tehtävien ja vuorovaikutusten läpi.
- **Ennalta määritellyt vuorovaikutuskuviot**: Standardoidut toimintojen ja vastausten sarjat, jotka helpottavat johdonmukaista ja tehokasta viestintää.
- **Erikoistuneet keskustelumallit**: Räätälöitävät mallit tietyn tyyppisille keskusteluille, varmistaen osuvien ja kontekstuaalisesti sopivien vuorovaikutusten syntymisen.

Kehotemalli voi näyttää tältä:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Työkalut

MCP:n työkalut ovat funktioita, joita tekoälymalli voi suorittaa tiettyjen tehtävien hoitamiseksi. Nämä työkalut on suunniteltu parantamaan mallin kyvykkyyksiä tarjoamalla jäsenneltyjä ja luotettavia toimintoja. Keskeiset piirteet ovat:

- **Mallin suorittamat funktiot**: Työkalut ovat suoritettavia funktioita, joita malli voi kutsua erilaisten tehtävien hoitamiseksi.
- **Uniikki nimi ja kuvaus**: Jokaisella työkalulla on oma selkeä nimi ja yksityiskohtainen kuvaus, joka kertoo sen tarkoituksen ja toiminnallisuuden.
- **Parametrit ja tulosteet**: Työkalut ottavat vastaan määriteltyjä parametreja ja palauttavat jäsenneltyjä tuloksia, varmistaen johdonmukaiset ja ennakoitavat vastaukset.
- **Erilliset toiminnot**: Työkalut suorittavat erillisiä toimintoja, kuten verkkohakuja, laskelmia tai tietokantakyselyjä.

Esimerkkityökalu voi näyttää tältä:

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

MCP:ssä clientit tarjoavat palvelimille useita keskeisiä ominaisuuksia, jotka parantavat protokollan kokonaisfunktionaalisuutta ja vuorovaikutusta. Yksi merkittävä ominaisuus on Sampling.

### 👉 Sampling

- **Palvelimen aloittamat agenttikäyttäytymiset**: Clientit mahdollistavat palvelimien autonomisesti aloittaa tiettyjä toimintoja tai käyttäytymismalleja, lisäten järjestelmän dynaamisia kykyjä.
- **Rekursiiviset LLM-vuorovaikutukset**: Tämä ominaisuus sallii toistuvat vuorovaikutukset suurten kielimallien kanssa, mahdollistaen monimutkaisempaa ja iteratiivista tehtävien käsittelyä.
- **Lisämallin täydentämisten pyytäminen**: Palvelimet voivat pyytää mallilta lisäkompletteja varmistaakseen vastauksen kattavuuden ja kontekstuaalisen sopivuuden.

## Tiedon kulku MCP:ssä

Model Context Protocol määrittelee rakenteellisen tiedonkulun Hostsien, clienttien, palvelimien ja mallien välillä. Tämän kulun ymmärtäminen selkeyttää, miten käyttäjän pyynnöt käsitellään ja miten ulkoiset työkalut ja data integroidaan mallin vastauksiin.

- **Host aloittaa yhteyden**  
  Host-sovellus (esim. IDE tai chat-käyttöliittymä) muodostaa yhteyden MCP-palvelimeen, tyypillisesti STDIO:n, WebSocketin tai muun tuetun siirtotavan kautta.

- **Kyvykkyysneuvottelu**  
  Client (hostin sisällä) ja palvelin vaihtavat tietoa tuetuista ominaisuuksista, työkaluista, resursseista ja protokollaversioista. Tämä varmistaa, että molemmat osapuolet ymmärtävät käytettävissä olevat kyvykkyydet istunnon aikana.

- **Käyttäjän pyyntö**  
  Käyttäjä on vuorovaikutuksessa hostin kanssa (esim. syöttää kehotteen tai komennon). Host kerää tämän syötteen ja välittää sen clientille käsiteltäväksi.

- **Resurssin tai työkalun käyttö**  
  - Client voi pyytää lisäkontekstia tai resursseja palvelimelta (kuten tiedostoja, tietokanta- tai tietopankkimerkintöjä) rikastuttaakseen mallin ymmärrystä.
  - Jos malli päättää, että työkalua tarvitaan (esim. datan hakemiseen, laskutoimitukseen tai API-kutsuun), client lähettää palvelimelle työkalukutsupyynnön, jossa määritellään työkalun nimi ja parametrit.

- **Palvelimen suoritus**  
  Palvelin vastaanottaa resurssi- tai työkalupyynnön, suorittaa tarvittavat toiminnot (esim. funktioiden suoritus, tietokantakysely tai tiedoston haku) ja palauttaa tulokset clientille jäsennellyssä muodossa.

- **Vastauksen generointi**  
  Client integroi palvelimen vastaukset (resurssidataa, työkalujen tuloksia jne.) käynnissä olevaan mallin vuorovaikutukseen. Malli käyttää tätä tietoa tuottaakseen kattavan ja kontekstuaalisesti osuvan vastauksen.

- **Tuloksen esittäminen**  
  Host vastaanottaa clientiltä lopullisen tuloksen ja esittää sen käyttäjälle, usein sisältäen sekä mallin generoiman tekstin että työkalujen suoritus- tai resurssihakujen tulokset.

Tämä tiedonkulku mahdollistaa MCP:n tukemaan edistyneitä, interaktiivisia ja kontekstin huomioivia tekoälysovelluksia yhdistämällä mallit saumattomasti ulkoisiin työkaluihin ja tietolähteisiin.

## Protokollan yksityiskohdat

MCP (Model Context Protocol) rakentuu [JSON-RPC 2.0](https://www.jsonrpc.org/) -protokollan päälle, tarjoten standardoidun ja kieliriippumattoman viestiformaatin hostsien, clienttien ja palvelimien väliseen viestintään. Tämä pohja mahdollistaa luotettavat, jäsennellyt ja laajennettavat vuorovaikutukset eri alustoilla ja ohjelmointikielillä.

### Keskeiset protokollaominaisuudet

MCP laajentaa JSON-RPC 2.0:aa lisäkäytännöillä työkalukutsuille, resurssien käytölle ja kehotteiden hallinnalle. Se tukee useita siirtokerroksia (STDIO, WebSocket, SSE) ja mahdollistaa turvallisen, laajennettavan ja kieliriippumattoman viestinnän komponenttien välillä.

#### 🧢 Perusprotokolla

- **JSON-RPC-viestiformaatti**: Kaikki pyynnöt ja vastaukset noudattavat JSON-RPC 2.0 -määritystä, varmistaen yhtenäisen rakenteen metodikutsuille, parametreille, tuloksille ja virheenkäsittelylle.
- **Tilalliset yhteydet**: MCP-istunnot ylläpitävät tilaa useiden pyyntöjen yli, mahdollistaen jatkuvat keskustelut, kontekstin kertymisen ja resurssien hallinnan.
- **Kyvykkyysneuvottelu**: Yhteyden muodostuksen yhteydessä clientit ja palvelimet vaihtavat tietoa tuetuista ominaisuuksista, protokollaversioista, käytettävissä olevista työkaluista ja resursseista. Tämä varmistaa molemminpuolisen ymmärryksen ja sopeutumisen.

#### ➕ Lisätoiminnot

Alla muutamia lisäominaisuuksia ja protokollan laajennuksia, joita MCP tarjoaa kehittäjäkokemuksen parantamiseksi ja kehittyneiden skenaarioiden mahdollistamiseksi:

- **Konfigurointivaihtoehdot**: MCP mahdollistaa istuntoparametrien dynaamisen asetuksen, kuten työkalujen käyttöoikeudet, resurssien pääsy ja mallin asetukset, räätälöitynä kuhunkin vuorovaikutukseen.
- **Edistymisen seuranta**: Pitkään kestävät toiminnot voivat raportoida edistymistietoja, mahdollistaen reagoivat käyttöliittymät ja paremman käyttökokemuksen monimutkaisissa tehtävissä.
- **Pyyntöjen peruutus**: Clientit voivat peruuttaa kesken olevia pyyntöjä, antaen käyttäjille mahdollisuuden keskeyttää tarpeettomat tai hidastuvat operaatiot.
- **Virheraportointi**: Standardoidut virheilmoitukset ja koodit auttavat ongelmien diagnosoinnissa, virheiden hallinnassa ja tarjoavat käyttäjille ja kehittäjille toimivia palautteita.
- **Lokitus**: Sekä clientit että palvelimet voivat tuottaa jäsenneltyjä lokeja auditointia, virheenkorjausta ja protokollan seurantaa varten.

Näitä protokollaominaisuuksia hyödyntämällä MCP varmistaa luotettavan, turvallisen ja joustavan viestinnän kielimallien ja ulkoisten työkalujen tai tietolähteiden välillä.

### 🔐 Turvallisuusnäkökohdat

MCP:n toteutusten tulee noudattaa useita keskeisiä turvallisuusperiaatteita turvallisten ja luotettavien vuorovaikutusten varmistamiseksi:

- **Käyttäjän suostumus ja hallinta**: Käyttäjiltä on saatava selkeä suostumus ennen datan käyttöä tai toimintojen suorittamista. Heillä tulee olla selkeä hallinta siitä, mitä tietoja jaetaan ja mitä toimintoja sallitaan, tuettuna intuitiivisilla käyttöliittymillä aktiviteettien tarkasteluun ja hyväksymiseen.

- **Datan yksityisyys**: Käyttäjädatan käyttö on sallittua vain selkeällä suostumuksella ja se tulee suojata asianmukaisin pääsynhallinnoin. MCP-toteutusten on estettävä luvaton datansiirto ja varmistettava yksityisyyden säilyminen kaikissa vuorovaikutuksissa.

- **Työkalujen turvallisuus**: Ennen työkalun kutsumista tarvitaan käyttäjän selkeä suostumus. Käyttäjien tulee ymmärtää kunkin työkalun toiminnallisuus, ja tiukat turvallisuusrajat on otettava käyttöön estämään ei-toivottu tai vaarallinen työkalujen suoritus.

Näitä periaatteita noudattamalla MCP varmistaa käyttäjien luottamuksen, yksityisyyden ja turvallisuuden kaikissa protokollan vuorovaikutuksissa.

## Koodiesimerkit: Keskeiset komponentit

Alla on esimerkkejä useilla suosituilla ohjelmointikielillä, jotka havainnollistavat keskeisten MCP-palvelinkomponenttien ja työkalujen toteutusta.

### .NET-esimerkki: Yksink

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttäen tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaisen ihmiskääntäjän käyttöä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.