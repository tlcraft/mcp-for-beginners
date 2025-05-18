<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T15:23:05+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "fi"
}
-->
# 📖 MCP Core Concepts: Mastering the Model Context Protocol for AI Integration

Model Context Protocol (MCP) on tehokas ja standardoitu kehys, joka optimoi viestinnän suurten kielimallien (LLM) ja ulkoisten työkalujen, sovellusten sekä tietolähteiden välillä. Tämä SEO-optimoitu opas johdattaa sinut MCP:n ydinkäsitteisiin, varmistaen, että ymmärrät sen asiakas-palvelinarkkitehtuurin, keskeiset osat, viestintämekanismit ja parhaat toteutustavat.

## Yleiskatsaus

Tässä oppitunnissa tutustutaan Model Context Protocolin (MCP) perusrakenteeseen ja sen muodostaviin osiin. Opit asiakas-palvelinarkkitehtuurista, keskeisistä komponenteista ja viestintämenetelmistä, jotka mahdollistavat MCP:n toiminnot.

## 👩‍🎓 Keskeiset oppimistavoitteet

Oppitunnin lopussa osaat:

- Ymmärtää MCP:n asiakas-palvelinarkkitehtuurin.
- Tunnistaa Hostien, Clientien ja Serverien roolit ja vastuut.
- Analysoida MCP:n joustavuuden mahdollistavia keskeisiä ominaisuuksia.
- Oppia, miten tieto virtaa MCP-ekosysteemissä.
- Saada käytännön näkemyksiä .NET-, Java-, Python- ja JavaScript-koodiesimerkkien kautta.

## 🔎 MCP-arkkitehtuuri: Syvällisempi katsaus

MCP-ekosysteemi perustuu asiakas-palvelin-malliin. Tämä modulaarinen rakenne mahdollistaa tekoälysovellusten tehokkaan vuorovaikutuksen työkalujen, tietokantojen, API:en ja kontekstuaalisten resurssien kanssa. Puretaan tämä arkkitehtuuri sen keskeisiin osiin.

### 1. Hosts

Model Context Protocolissa (MCP) Hostit ovat keskeinen käyttöliittymä, jonka kautta käyttäjät ovat vuorovaikutuksessa protokollan kanssa. Hostit ovat sovelluksia tai ympäristöjä, jotka aloittavat yhteydet MCP-palvelimiin saadakseen käyttöönsä dataa, työkaluja ja kehotteita. Esimerkkejä Hostista ovat integroidut kehitysympäristöt (IDE) kuten Visual Studio Code, tekoälytyökalut kuten Claude Desktop tai tehtäviin räätälöidyt agentit.

**Hostit** ovat LLM-sovelluksia, jotka aloittavat yhteydenoton. Ne:

- Suorittavat tai ovat vuorovaikutuksessa tekoälymallien kanssa vastauksien luomiseksi.
- Aloittavat yhteydet MCP-palvelimiin.
- Hallitsevat keskustelun kulkua ja käyttöliittymää.
- Valvovat käyttöoikeuksia ja turvallisuusrajoituksia.
- Käsittelevät käyttäjän suostumuksen datan jakamiseen ja työkalujen suorittamiseen.

### 2. Clients

Clientit ovat olennaisia komponentteja, jotka mahdollistavat vuorovaikutuksen Hostien ja MCP-palvelimien välillä. Clientit toimivat välittäjinä, joiden avulla Hostit pääsevät käyttämään MCP-palvelimien tarjoamia toimintoja. Ne varmistavat sujuvan viestinnän ja tehokkaan tiedonvaihdon MCP-arkkitehtuurissa.

**Clientit** ovat liittimiä host-sovelluksen sisällä. Ne:

- Lähettävät pyyntöjä palvelimille kehotteiden tai ohjeiden kanssa.
- Neuvottelevat palvelimien kyvykkyyksistä.
- Hallitsevat mallien työkalukäyttöpyyntöjä.
- Käsittelevät ja näyttävät vastaukset käyttäjille.

### 3. Servers

Serverit vastaavat MCP-clientien pyyntöjen käsittelystä ja asianmukaisten vastausten tarjoamisesta. Ne hallinnoivat erilaisia toimintoja, kuten datan hakua, työkalujen suorittamista ja kehotteiden luontia. Serverit varmistavat, että viestintä clientien ja Hostien välillä on tehokasta ja luotettavaa, ylläpitäen vuorovaikutuksen eheyttä.

**Serverit** ovat palveluita, jotka tarjoavat kontekstia ja toiminnallisuuksia. Ne:

- Rekisteröivät saatavilla olevat ominaisuudet (resurssit, kehotteet, työkalut)
- Ottavat vastaan ja suorittavat työkalukutsut clientilta
- Tarjoavat kontekstuaalista tietoa mallin vastausten parantamiseksi
- Palauttavat tulokset clientille
- Ylläpitävät tilaa vuorovaikutusten välillä tarvittaessa

Serverit voivat olla kenen tahansa kehittämiä laajentaakseen mallin kyvykkyyksiä erikoistuneilla toiminnoilla.

### 4. Serverin ominaisuudet

Model Context Protocolin (MCP) serverit tarjoavat perusrakenteet, jotka mahdollistavat rikkaat vuorovaikutukset clientien, hostien ja kielimallien välillä. Nämä ominaisuudet on suunniteltu parantamaan MCP:n kyvykkyyksiä tarjoamalla rakenteellista kontekstia, työkaluja ja kehotteita.

MCP-serverit voivat tarjota seuraavia ominaisuuksia:

#### 📑 Resurssit

MCP:n resurssit kattavat erilaisia kontekstin ja datan tyyppejä, joita käyttäjät tai tekoälymallit voivat hyödyntää. Näihin kuuluvat:

- **Kontekstuaalinen data**: Tieto ja konteksti, joita käyttäjät tai tekoälymallit voivat käyttää päätöksenteossa ja tehtävien suorittamisessa.
- **Tietopankit ja dokumenttivarastot**: Rakenteellista ja rakenteetonta dataa, kuten artikkeleita, käsikirjoja ja tutkimuspapereita, jotka tarjoavat arvokasta tietoa.
- **Paikalliset tiedostot ja tietokannat**: Laitteilla tai tietokannoissa paikallisesti tallennettua dataa, joka on käytettävissä käsittelyyn ja analyysiin.
- **API:t ja verkkopalvelut**: Ulkoiset rajapinnat ja palvelut, jotka tarjoavat lisätietoja ja toiminnallisuuksia mahdollistaen integraation erilaisiin verkkolähteisiin ja työkaluihin.

Esimerkki resurssista voi olla tietokannan skeema tai tiedosto, johon pääsee käsiksi seuraavasti:

```text
file://log.txt
database://schema
```

### 🤖 Kehotteet

MCP:n kehotteet sisältävät erilaisia valmiiksi määriteltyjä malleja ja vuorovaikutuskuvioita, jotka helpottavat käyttäjän työnkulkuja ja parantavat viestintää. Näihin kuuluvat:

- **Mallinnetut viestit ja työnkulut**: Ennalta rakennetut viestit ja prosessit, jotka ohjaavat käyttäjiä tiettyjen tehtävien ja vuorovaikutusten läpi.
- **Ennalta määritellyt vuorovaikutuskuviot**: Standardoidut toimintojen ja vastausten sarjat, jotka tukevat johdonmukaista ja tehokasta viestintää.
- **Erikoistuneet keskustelumallit**: Räätälöitävät mallit tietyn tyyppisille keskusteluille, jotka varmistavat asiaankuuluvan ja kontekstuaalisesti sopivan vuorovaikutuksen.

Kehotepohja voi näyttää tältä:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Työkalut

MCP:n työkalut ovat toimintoja, joita tekoälymalli voi suorittaa tiettyjen tehtävien hoitamiseksi. Nämä työkalut on suunniteltu laajentamaan mallin kyvykkyyksiä tarjoamalla rakenteellisia ja luotettavia toimintoja. Keskeisiä piirteitä ovat:

- **Toiminnot, joita tekoälymalli voi suorittaa**: Työkalut ovat suoritettavia funktioita, joita malli voi kutsua tehtävien hoitamiseksi.
- **Uniikki nimi ja kuvaus**: Jokaisella työkalulla on oma nimi ja yksityiskohtainen kuvaus, joka selittää sen tarkoituksen ja toiminnallisuuden.
- **Parametrit ja tulosteet**: Työkalut ottavat vastaan tiettyjä parametreja ja palauttavat rakenteellisia tuloksia, mikä takaa yhdenmukaiset ja ennustettavat lopputulokset.
- **Eristetyt toiminnot**: Työkalut suorittavat erillisiä toimintoja, kuten verkkohakuja, laskelmia ja tietokantakyselyjä.

Esimerkkityökalu voisi näyttää tältä:

```typescript
server.tool(
  "GetProducts"
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Clientin ominaisuudet

MCP:ssa clientit tarjoavat useita keskeisiä ominaisuuksia servereille, jotka parantavat protokollan kokonaisfunktionaalisuutta ja vuorovaikutusta. Yksi merkittävistä ominaisuuksista on Sampling.

### 👉 Sampling

- **Palvelimen käynnistämät agenttitoiminnot**: Clientit mahdollistavat serverien autonomisten toimintojen tai käyttäytymisten käynnistämisen, mikä lisää järjestelmän dynaamisia kyvykkyyksiä.
- **Rekursiiviset LLM-vuorovaikutukset**: Tämä ominaisuus mahdollistaa rekursiivisen vuorovaikutuksen suurten kielimallien kanssa, mahdollistaen monimutkaisemman ja iteratiivisemman tehtävien käsittelyn.
- **Lisämallin täydentämisten pyytäminen**: Serverit voivat pyytää mallilta lisävastauksia varmistaakseen, että vastaukset ovat perusteellisia ja kontekstuaalisesti relevantteja.

## Tiedon kulku MCP:ssä

Model Context Protocol (MCP) määrittelee rakenteellisen tiedonkulun Hostien, Clientien, Serverien ja mallien välillä. Tämän virran ymmärtäminen auttaa hahmottamaan, miten käyttäjän pyynnöt käsitellään ja miten ulkoiset työkalut ja data integroidaan mallin vastauksiin.

- **Host aloittaa yhteyden**  
  Host-sovellus (esim. IDE tai chat-käyttöliittymä) muodostaa yhteyden MCP-palvelimeen, tyypillisesti STDIO:n, WebSocketin tai muun tuetun kuljetusmenetelmän kautta.

- **Kyvykkyyksien neuvottelu**  
  Client (hostin sisällä) ja serveri vaihtavat tietoa tukemistaan ominaisuuksista, työkaluista, resursseista ja protokollaversioista. Tämä varmistaa, että molemmat osapuolet ymmärtävät käytettävissä olevat kyvykkyydet istunnon ajaksi.

- **Käyttäjän pyyntö**  
  Käyttäjä on vuorovaikutuksessa hostin kanssa (esim. syöttää kehotteen tai komennon). Host kerää tämän syötteen ja välittää sen clientille käsittelyä varten.

- **Resurssin tai työkalun käyttö**  
  - Client voi pyytää lisäkontekstia tai resursseja serveriltä (kuten tiedostoja, tietokantamerkintöjä tai tietopankkiartikkeleita) rikastuttaakseen mallin ymmärrystä.
  - Jos malli katsoo työkalun tarpeelliseksi (esim. datan hakemiseen, laskutoimituksen tekemiseen tai API-kutsuun), client lähettää työkalukutsupyynnön serverille, määrittäen työkalun nimen ja parametrit.

- **Serverin suoritus**  
  Serveri vastaanottaa resurssi- tai työkalupyynnön, suorittaa tarvittavat toimenpiteet (kuten funktion ajon, tietokantakyselyn tai tiedoston haun) ja palauttaa tulokset clientille rakenteellisessa muodossa.

- **Vastauksen muodostaminen**  
  Client yhdistää serverin vastaukset (resurssidatan, työkalujen tulokset jne.) käynnissä olevaan mallin vuorovaikutukseen. Malli käyttää tätä tietoa luodakseen kattavan ja kontekstuaalisesti sopivan vastauksen.

- **Tuloksen esittäminen**  
  Host saa lopullisen tuloksen clientiltä ja esittää sen käyttäjälle, usein sisältäen sekä mallin generoiman tekstin että työkalujen suoritus- tai resurssihakujen tulokset.

Tämä tiedonkulku mahdollistaa MCP:n tukemaan kehittyneitä, interaktiivisia ja kontekstia ymmärtäviä tekoälysovelluksia yhdistämällä mallit saumattomasti ulkoisiin työkaluihin ja tietolähteisiin.

## Protokollan yksityiskohdat

MCP (Model Context Protocol) rakentuu [JSON-RPC 2.0](https://www.jsonrpc.org/) -protokollan päälle, tarjoten standardoidun ja kieliriippumattoman viestimuodon hostien, clientien ja serverien väliseen viestintään. Tämä perusta mahdollistaa luotettavat, rakenteelliset ja laajennettavat vuorovaikutukset eri alustoilla ja ohjelmointikielillä.

### Keskeiset protokollaominaisuudet

MCP laajentaa JSON-RPC 2.0:aa lisäsäännöillä työkalukutsujen, resurssien käytön ja kehotteiden hallinnan osalta. Se tukee useita kuljetuskerroksia (STDIO, WebSocket, SSE) ja mahdollistaa turvallisen, laajennettavan ja kieliriippumattoman viestinnän komponenttien välillä.

#### 🧢 Perusprotokolla

- **JSON-RPC-viestimuoto**: Kaikki pyynnöt ja vastaukset noudattavat JSON-RPC 2.0 -määritystä, mikä takaa yhdenmukaisen rakenteen metodikutsuille, parametreille, tuloksille ja virheenkäsittelylle.
- **Tila säilyttävät yhteydet**: MCP-istunnot ylläpitävät tilaa useiden pyyntöjen ajan, mahdollistaen jatkuvat keskustelut, kontekstin kertymisen ja resurssien hallinnan.
- **Kyvykkyyksien neuvottelu**: Yhteyden muodostamisen yhteydessä client ja serveri vaihtavat tietoa tukemistaan ominaisuuksista, protokollaversioista, käytettävissä olevista työkaluista ja resursseista. Tämä varmistaa, että molemmat osapuolet ymmärtävät toistensa kyvykkyydet ja voivat mukautua niiden mukaan.

#### ➕ Lisäominaisuudet

Alla on joitakin lisäominaisuuksia ja protokollan laajennuksia, joita MCP tarjoaa kehittäjäkokemuksen parantamiseksi ja edistyneiden skenaarioiden mahdollistamiseksi:

- **Konfigurointivaihtoehdot**: MCP mahdollistaa istuntoparametrien dynaamisen konfiguroinnin, kuten työkalujen käyttöoikeudet, resurssien käyttö ja mallin asetukset, räätälöityinä kuhunkin vuorovaikutukseen.
- **Edistymisen seuranta**: Pitkään kestävät operaatiot voivat raportoida edistymistietoja, mahdollistaen responsiivisen käyttöliittymän ja paremman käyttökokemuksen monimutkaisissa tehtävissä.
- **Pyyntöjen peruutus**: Clientit voivat peruuttaa käynnissä olevia pyyntöjä, antaen käyttäjille mahdollisuuden keskeyttää tarpeettomat tai liian pitkään kestävät toiminnot.
- **Virheraportointi**: Standardoidut virheilmoitukset ja -koodit auttavat ongelmien diagnosoinnissa, virheiden hallinnassa ja tarjoavat käyttäjille sekä kehittäjille käyttökelpoista palautetta.
- **Lokitus**: Sekä clientit että serverit voivat tuottaa rakenteellisia lokeja auditointia, virheenkorjausta ja protokollan valvontaa varten.

Näiden protokollaominaisuuksien avulla MCP takaa vahvan, turvallisen ja joustavan viestinnän kielimallien ja ulkoisten työkalujen tai tietolähteiden välillä.

### 🔐 Turvallisuusnäkökohdat

MCP:n toteutusten tulisi noudattaa useita keskeisiä turvallisuusperiaatteita varmistaakseen turvalliset ja luotettavat vuorovaikutukset:

- **Käyttäjän suostumus ja hallinta**: Käyttäjien on annettava selkeä suostumus ennen datan käyttöä tai toimintojen suorittamista. Heillä tulee olla selkeä kontrolli siitä, mitä dataa jaetaan ja mitkä toimet ovat sallittuja, tuettuna intuitiivisilla käyttöliittymillä toimien tarkasteluun ja hyväksymiseen.

- **Datan yksityisyys**: Käyttäjädatan käyttö on sallittua vain selkeällä suostumuksella, ja se on suojattava asianmukaisin pääsynvalvontakeinoin. MCP:n toteutusten on estettävä luvaton datansiirto ja varmistettava yksityisyyden säilyminen kaikissa vuorovaikutuksissa.

- **Työkalujen turvallisuus**: Ennen työkalun kutsumista vaaditaan käyttäjän selkeä suostumus. Käyttäjien tulee ymmärtää kunkin työkalun toiminnallisuus, ja tiukat turvallisuusrajat on toteutettava estämään ei-toivottu tai vaarallinen työkalun suoritus.

Näiden periaatteiden noudattaminen varmistaa, että MCP ylläpitää käyttäjien luottamusta, yksityisyyttä ja turvallisuutta kaikissa protokollan vuorovaikutuksissa.

## Koodiesimerkit: Keskeiset komponentit

Alla on esimerkkejä useilla suosituilla ohjelmointikielillä, jotka havainnollistavat, miten keskeisiä MCP-serverikomponent

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää ensisijaisena lähteenä. Tärkeiden tietojen osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinymmärryksistä tai virhetulkinnoista.