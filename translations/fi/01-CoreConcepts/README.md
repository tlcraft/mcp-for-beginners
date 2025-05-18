<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:45:22+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "fi"
}
-->
# 📖 MCP:n ydinkonseptit: Mallin kontekstiprotokollan hallinta AI-integraatiota varten

Model Context Protocol (MCP) on tehokas, standardoitu kehys, joka optimoi viestinnän suurten kielimallien (LLM) ja ulkoisten työkalujen, sovellusten ja tietolähteiden välillä. Tämä SEO-optimoitu opas johdattaa sinut MCP:n ydinkonsepteihin varmistaen, että ymmärrät sen asiakas-palvelin-arkkitehtuurin, keskeiset komponentit, viestintämekaniikan ja parhaat käytännöt toteutuksessa.

## Yleiskatsaus

Tämä oppitunti tutkii Model Context Protocol (MCP) -ekosysteemin perusarkkitehtuuria ja komponentteja. Opit asiakas-palvelin-arkkitehtuurista, keskeisistä komponenteista ja viestintämekanismeista, jotka ohjaavat MCP-vuorovaikutuksia.

## 👩‍🎓 Tärkeimmät oppimistavoitteet

Tämän oppitunnin lopussa osaat:

- Ymmärtää MCP:n asiakas-palvelin-arkkitehtuurin.
- Tunnistaa isäntien, asiakkaiden ja palvelimien roolit ja vastuut.
- Analysoida MCP:n joustavaksi integraatiokerrokseksi tekeviä ydintoimintoja.
- Oppia, miten tieto virtaa MCP-ekosysteemissä.
- Saada käytännön näkemyksiä koodiesimerkkien kautta .NET-, Java-, Python- ja JavaScript-kielillä.

## 🔎 MCP-arkkitehtuuri: Syvällisempi tarkastelu

MCP-ekosysteemi on rakennettu asiakas-palvelin-mallin pohjalta. Tämä modulaarinen rakenne mahdollistaa AI-sovellusten tehokkaan vuorovaikutuksen työkalujen, tietokantojen, API:iden ja kontekstuaalisten resurssien kanssa. Puretaanpa tämä arkkitehtuuri sen keskeisiin komponentteihin.

### 1. Isännät

Model Context Protocol (MCP) -protokollassa isännillä on keskeinen rooli ensisijaisena käyttöliittymänä, jonka kautta käyttäjät ovat vuorovaikutuksessa protokollan kanssa. Isännät ovat sovelluksia tai ympäristöjä, jotka aloittavat yhteyksiä MCP-palvelimiin saadakseen pääsyn tietoihin, työkaluihin ja kehotteisiin. Esimerkkejä isännistä ovat integroitu kehitysympäristö (IDE) kuten Visual Studio Code, AI-työkalut kuten Claude Desktop tai erityistehtäviin suunnitellut mukautetut agentit.

**Isännät** ovat LLM-sovelluksia, jotka aloittavat yhteydet. Ne:

- Suorittavat tai ovat vuorovaikutuksessa AI-mallien kanssa tuottaakseen vastauksia.
- Aloittavat yhteydet MCP-palvelimiin.
- Hallinnoivat keskustelun kulkua ja käyttöliittymää.
- Kontrolloivat lupia ja tietoturvarajoituksia.
- Käsittelevät käyttäjän suostumusta tietojen jakamiseen ja työkalujen suorittamiseen.

### 2. Asiakkaat

Asiakkaat ovat olennaisia komponentteja, jotka helpottavat isäntien ja MCP-palvelimien välistä vuorovaikutusta. Asiakkaat toimivat välittäjinä, jotka mahdollistavat isännille MCP-palvelimien tarjoamien toimintojen hyödyntämisen. Ne ovat keskeisessä roolissa varmistaessaan sujuvan viestinnän ja tehokkaan tiedonvaihdon MCP-arkkitehtuurissa.

**Asiakkaat** ovat liittimiä isäntäohjelmassa. Ne:

- Lähettävät pyyntöjä palvelimille kehotteiden/ohjeiden kanssa.
- Neuvottelevat ominaisuuksista palvelimien kanssa.
- Hallinnoivat mallien työkalun suorituspyyntöjä.
- Käsittelevät ja näyttävät vastaukset käyttäjille.

### 3. Palvelimet

Palvelimet vastaavat MCP-asiakkaiden pyyntöjen käsittelystä ja sopivien vastausten antamisesta. Ne hallitsevat erilaisia toimintoja, kuten tiedonhakua, työkalujen suorittamista ja kehotteiden luomista. Palvelimet varmistavat, että viestintä asiakkaiden ja isäntien välillä on tehokasta ja luotettavaa, säilyttäen vuorovaikutusprosessin eheyden.

**Palvelimet** ovat palveluja, jotka tarjoavat kontekstia ja kykyjä. Ne:

- Rekisteröivät käytettävissä olevat ominaisuudet (resurssit, kehotteet, työkalut)
- Vastaanottavat ja suorittavat asiakaspyynnöistä tulevat työkalukutsut
- Tarjoavat kontekstuaalista tietoa mallin vastausten parantamiseksi
- Palauttavat tuotokset takaisin asiakkaalle
- Ylläpitävät tilaa vuorovaikutusten välillä tarvittaessa

Palvelimia voi kehittää kuka tahansa laajentaakseen mallin kykyjä erikoistuneilla toiminnoilla.

### 4. Palvelimen ominaisuudet

Model Context Protocol (MCP) -palvelimet tarjoavat perustavanlaatuisia rakennuspalikoita, jotka mahdollistavat rikkaan vuorovaikutuksen asiakkaiden, isäntien ja kielimallien välillä. Nämä ominaisuudet on suunniteltu parantamaan MCP:n kykyjä tarjoamalla rakenteellista kontekstia, työkaluja ja kehotteita.

MCP-palvelimet voivat tarjota seuraavia ominaisuuksia:

#### 📑 Resurssit

Model Context Protocol (MCP) -resurssit kattavat erilaisia konteksteja ja tietoja, joita käyttäjät tai AI-mallit voivat hyödyntää. Näitä ovat:

- **Kontekstuaalinen tieto**: Tieto ja konteksti, jota käyttäjät tai AI-mallit voivat hyödyntää päätöksenteossa ja tehtävien suorittamisessa.
- **Tietopohjat ja dokumenttivarastot**: Rakenteellisten ja rakenteettomien tietojen kokoelmat, kuten artikkelit, käyttöoppaat ja tutkimuspaperit, jotka tarjoavat arvokasta tietoa ja näkemyksiä.
- **Paikalliset tiedostot ja tietokannat**: Paikallisesti laitteissa tai tietokannoissa tallennetut tiedot, jotka ovat käytettävissä käsittelyyn ja analyysiin.
- **API:t ja verkkopalvelut**: Ulkoiset rajapinnat ja palvelut, jotka tarjoavat lisätietoa ja toimintoja, mahdollistaen integraation erilaisten verkkolähteiden ja työkalujen kanssa.

Esimerkki resurssista voi olla tietokantaskeema tai tiedosto, johon pääsee käsiksi näin:

```text
file://log.txt
database://schema
```

### 🤖 Kehotteet
Model Context Protocol (MCP) -kehotteet sisältävät erilaisia ennalta määriteltyjä malleja ja vuorovaikutuskuvioita, jotka on suunniteltu virtaviivaistamaan käyttäjän työnkulkuja ja parantamaan viestintää. Näihin kuuluu:

- **Mallinnetut viestit ja työnkulut**: Ennalta rakenteelliset viestit ja prosessit, jotka ohjaavat käyttäjiä tiettyjen tehtävien ja vuorovaikutusten läpi.
- **Ennalta määritellyt vuorovaikutuskuviot**: Standardoidut toimintojen ja vastausten sekvenssit, jotka helpottavat johdonmukaista ja tehokasta viestintää.
- **Erikoistuneet keskustelumallit**: Mukautettavat mallit, jotka on räätälöity tietyn tyyppisille keskusteluille, varmistaen merkitykselliset ja kontekstuaalisesti sopivat vuorovaikutukset.

Kehotemalli voi näyttää tältä:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Työkalut

Model Context Protocol (MCP) -työkalut ovat toimintoja, joita AI-malli voi suorittaa suorittaakseen tiettyjä tehtäviä. Nämä työkalut on suunniteltu parantamaan AI-mallin kykyjä tarjoamalla rakenteellisia ja luotettavia toimintoja. Keskeisiä piirteitä ovat:

- **Toiminnot AI-mallille suoritettavaksi**: Työkalut ovat suoritettavia toimintoja, joita AI-malli voi kutsua suorittaakseen erilaisia tehtäviä.
- **Uniikki nimi ja kuvaus**: Jokaisella työkalulla on erottuva nimi ja yksityiskohtainen kuvaus, joka selittää sen tarkoituksen ja toiminnallisuuden.
- **Parametrit ja tuotokset**: Työkalut hyväksyvät tiettyjä parametreja ja palauttavat rakenteellisia tuotoksia, varmistaen johdonmukaiset ja ennustettavat tulokset.
- **Diskreetit toiminnot**: Työkalut suorittavat diskreettejä toimintoja, kuten verkkohakuja, laskelmia ja tietokantakyselyjä.

Esimerkki työkalusta voisi näyttää tältä:

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

## Asiakasominaisuudet
Model Context Protocol (MCP) -protokollassa asiakkaat tarjoavat useita keskeisiä ominaisuuksia palvelimille, parantaen protokollan yleistä toiminnallisuutta ja vuorovaikutusta. Yksi merkittävistä ominaisuuksista on näytteenotto.

### 👉 Näytteenotto

- **Palvelimen aloittamat agenttikäyttäytymiset**: Asiakkaat mahdollistavat palvelimien aloittaa tiettyjä toimintoja tai käyttäytymismalleja itsenäisesti, parantaen järjestelmän dynaamisia kykyjä.
- **Rekursiiviset LLM-vuorovaikutukset**: Tämä ominaisuus mahdollistaa rekursiiviset vuorovaikutukset suurten kielimallien (LLM) kanssa, mahdollistaen monimutkaisemman ja iteratiivisemman tehtävien käsittelyn.
- **Lisämallien täydentämisen pyytäminen**: Palvelimet voivat pyytää lisätäydennyksiä mallilta, varmistaen, että vastaukset ovat perusteellisia ja kontekstuaalisesti merkityksellisiä.

## Tiedonkulku MCP:ssä

Model Context Protocol (MCP) määrittelee rakenteellisen tiedonkulun isäntien, asiakkaiden, palvelimien ja mallien välillä. Tämän kulun ymmärtäminen auttaa selventämään, miten käyttäjäpyynnöt käsitellään ja miten ulkoiset työkalut ja tiedot integroidaan mallin vastauksiin.

- **Isäntä aloittaa yhteyden**  
  Isäntäohjelma (kuten IDE tai keskustelukäyttöliittymä) luo yhteyden MCP-palvelimeen, yleensä STDIO:n, WebSocketin tai muun tuetun siirtotavan kautta.

- **Ominaisuusneuvottelu**  
  Asiakas (upotettuna isäntään) ja palvelin vaihtavat tietoa tuetuista ominaisuuksistaan, työkaluistaan, resursseistaan ja protokollaversioistaan. Tämä varmistaa, että molemmat osapuolet ymmärtävät, mitä kykyjä on käytettävissä istunnon aikana.

- **Käyttäjäpyyntö**  
  Käyttäjä on vuorovaikutuksessa isännän kanssa (esim. syöttää kehotteen tai komennon). Isäntä kerää tämän syötteen ja välittää sen asiakkaalle käsiteltäväksi.

- **Resurssin tai työkalun käyttö**  
  - Asiakas voi pyytää lisäkontekstia tai resursseja palvelimelta (kuten tiedostoja, tietokantamerkintöjä tai tietopohja-artikkeleita) rikastuttaakseen mallin ymmärrystä.
  - Jos malli päättää, että tarvitaan työkalu (esim. tiedon hakemiseen, laskennan suorittamiseen tai API-kutsun tekemiseen), asiakas lähettää työkalukutsupyynnön palvelimelle, määrittäen työkalun nimen ja parametrit.

- **Palvelimen suoritus**  
  Palvelin vastaanottaa resurssi- tai työkalupyynnön, suorittaa tarvittavat toiminnot (kuten toiminnon suorittaminen, tietokantakysely tai tiedoston hakeminen) ja palauttaa tulokset asiakkaalle rakenteellisessa muodossa.

- **Vastauksen luominen**  
  Asiakas integroi palvelimen vastaukset (resurssitiedot, työkalun tuotokset jne.) meneillään olevaan mallivuorovaikutukseen. Malli käyttää tätä tietoa luodakseen kattavan ja kontekstuaalisesti merkityksellisen vastauksen.

- **Tuloksen esittäminen**  
  Isäntä vastaanottaa lopullisen tuloksen asiakkaalta ja esittää sen käyttäjälle, usein sisältäen sekä mallin tuottaman tekstin että kaikki työkalusuorituksista tai resurssihakemuksista saadut tulokset.

Tämä kulku mahdollistaa MCP:n tukemaan edistyneitä, interaktiivisia ja kontekstuaalisesti tietoisia AI-sovelluksia yhdistämällä saumattomasti mallit ulkoisiin työkaluihin ja tietolähteisiin.

## Protokollan yksityiskohdat

MCP (Model Context Protocol) perustuu [JSON-RPC 2.0](https://www.jsonrpc.org/):aan, tarjoten standardoidun, kieliriippumattoman viestimuodon isäntien, asiakkaiden ja palvelimien väliseen viestintään. Tämä perusta mahdollistaa luotettavat, rakenteelliset ja laajennettavat vuorovaikutukset monipuolisilla alustoilla ja ohjelmointikielillä.

### Keskeiset protokollaominaisuudet

MCP laajentaa JSON-RPC 2.0:aa lisäkonventioilla työkalukutsuille, resurssien käytölle ja kehotteiden hallinnalle. Se tukee useita siirtokerroksia (STDIO, WebSocket, SSE) ja mahdollistaa turvallisen, laajennettavan ja kieliriippumattoman viestinnän komponenttien välillä.

#### 🧢 Perusprotokolla

- **JSON-RPC-viestimuoto**: Kaikki pyynnöt ja vastaukset käyttävät JSON-RPC 2.0 -määrittelyä, varmistaen johdonmukaisen rakenteen menetelmäkutsuille, parametreille, tuloksille ja virheenkäsittelylle.
- **Tilalliset yhteydet**: MCP-istunnot ylläpitävät tilaa useiden pyyntöjen välillä, tukien jatkuvia keskusteluja, kontekstin kertymistä ja resurssien hallintaa.
- **Ominaisuusneuvottelu**: Yhteyden muodostamisen aikana asiakkaat ja palvelimet vaihtavat tietoa tuetuista ominaisuuksista, protokollaversioista, käytettävissä olevista työkaluista ja resursseista. Tämä varmistaa, että molemmat osapuolet ymmärtävät toistensa kyvyt ja voivat mukautua vastaavasti.

#### ➕ Lisätyökalut

Alla on joitain lisätyökaluja ja protokollalaajennuksia, joita MCP tarjoaa parantaakseen kehittäjäkokemusta ja mahdollistamaan edistyneitä skenaarioita:

- **Määritysasetukset**: MCP mahdollistaa istuntoparametrien dynaamisen määrityksen, kuten työkaluluvat, resurssien käyttö ja malliasetukset, räätälöitynä jokaiselle vuorovaikutukselle.
- **Edistymisen seuranta**: Pitkäkestoiset toiminnot voivat raportoida edistymispäivityksiä, mahdollistaen reagoivat käyttöliittymät ja paremman käyttäjäkokemuksen monimutkaisten tehtävien aikana.
- **Pyyntöjen peruutus**: Asiakkaat voivat peruuttaa kesken olevat pyynnöt, mahdollistaen käyttäjille keskeyttää toiminnot, joita ei enää tarvita tai jotka kestävät liian kauan.
- **Virheraportointi**: Standardoidut virheilmoitukset ja koodit auttavat diagnosoimaan ongelmia, käsittelemään virheitä sujuvasti ja tarjoamaan toimivia palautteita käyttäjille ja kehittäjille.
- **Lokitus**: Sekä asiakkaat että palvelimet voivat lähettää rakenteellisia lokitietoja auditointia, virheenkorjausta ja protokollavuorovaikutusten seurantaa varten.

Hyödyntämällä näitä protokollaominaisuuksia MCP varmistaa kestävän, turvallisen ja joustavan viestinnän kielimallien ja ulkoisten työkalujen tai tietolähteiden välillä.

### 🔐 Turvallisuuskysymykset

MCP-toteutusten tulisi noudattaa useita keskeisiä turvallisuusperiaatteita varmistaakseen turvalliset ja luotettavat vuorovaikutukset:

- **Käyttäjän suostumus ja hallinta**: Käyttäjien on annettava nimenomainen suostumus ennen kuin mitään tietoja käytetään tai toimintoja suoritetaan. Heillä tulisi olla selkeä hallinta siitä, mitä tietoja jaetaan ja mitkä toiminnot ovat sallittuja, tukien intuitiivisia käyttöliittymiä toimintojen tarkistamiseen ja hyväksymiseen.

- **Tietosuoja**: Käyttäjätietoja tulisi paljastaa vain nimenomaisella suostumuksella, ja niiden on oltava suojattu asianmukaisilla käyttöoikeuksilla. MCP-toteutusten on suojattava luvattomalta tiedonsiirrolta ja varmistettava

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, olkaa tietoisia siitä, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää virallisena lähteenä. Kriittistä tietoa varten suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.