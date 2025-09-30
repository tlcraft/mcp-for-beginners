<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T17:56:07+00:00",
  "source_file": "changelog.md",
  "language_code": "fi"
}
-->
# Muutosloki: MCP for Beginners -opetussuunnitelma

Tämä asiakirja toimii merkittävien muutosten kirjana Model Context Protocol (MCP) for Beginners -opetussuunnitelmassa. Muutokset on dokumentoitu käänteisessä aikajärjestyksessä (uusimmat muutokset ensin).

## 29. syyskuuta 2025

### MCP Server Database Integration Labs - Kattava käytännön oppimispolku

#### 11-MCPServerHandsOnLabs - Uusi täydellinen tietokantaintegraation opetussuunnitelma
- **Täydellinen 13-laboratorion oppimispolku**: Lisätty kattava käytännön opetussuunnitelma tuotantovalmiiden MCP-palvelimien rakentamiseen PostgreSQL-tietokantaintegraatiolla
  - **Todellisen maailman toteutus**: Zava Retail -analytiikkatapaus, joka esittelee yritystason käytäntöjä
  - **Rakenteellinen oppimisprogressio**:
    - **Laboratoriot 00-03: Perusteet** - Johdanto, ydinarkkitehtuuri, turvallisuus ja monivuokraus, ympäristön asennus
    - **Laboratoriot 04-06: MCP-palvelimen rakentaminen** - Tietokannan suunnittelu ja skeema, MCP-palvelimen toteutus, työkalujen kehitys  
    - **Laboratoriot 07-09: Edistyneet ominaisuudet** - Semanttinen hakuintegraatio, testaus ja virheenkorjaus, VS Code -integraatio
    - **Laboratoriot 10-12: Tuotanto ja parhaat käytännöt** - Julkaisustrategiat, valvonta ja havaittavuus, parhaat käytännöt ja optimointi
  - **Yritysteknologiat**: FastMCP-kehys, PostgreSQL pgvectorilla, Azure OpenAI -upotukset, Azure Container Apps, Application Insights
  - **Edistyneet ominaisuudet**: Rivitasoinen turvallisuus (RLS), semanttinen haku, monivuokraus datan käyttö, vektoriupotukset, reaaliaikainen valvonta

#### Terminologian standardointi - Moduulista laboratorioon muuntaminen
- **Kattava dokumentaation päivitys**: Päivitetty systemaattisesti kaikki README-tiedostot 11-MCPServerHandsOnLabs-osiossa käyttämään "Laboratorio"-terminologiaa "Moduuli"-termin sijaan
  - **Otsikot**: Päivitetty "Mitä tämä moduuli kattaa" muotoon "Mitä tämä laboratorio kattaa" kaikissa 13 laboratoriossa
  - **Sisällön kuvaus**: Muutettu "Tämä moduuli tarjoaa..." muotoon "Tämä laboratorio tarjoaa..." dokumentaation läpi
  - **Oppimistavoitteet**: Päivitetty "Tämän moduulin lopussa..." muotoon "Tämän laboratorion lopussa..."
  - **Navigointilinkit**: Muutettu kaikki "Moduuli XX:" viittaukset muotoon "Laboratorio XX:" ristiinviittauksissa ja navigoinnissa
  - **Suorituksen seuranta**: Päivitetty "Kun olet suorittanut tämän moduulin..." muotoon "Kun olet suorittanut tämän laboratorion..."
  - **Teknisten viittausten säilyttäminen**: Säilytetty Python-moduuliviittaukset konfiguraatiotiedostoissa (esim. `"module": "mcp_server.main"`)

#### Opasmateriaalin parannus (study_guide.md)
- **Visuaalinen opetussuunnitelmakartta**: Lisätty uusi "11. Tietokantaintegraatiolaboratoriot" -osio kattavalla laboratoriostruktuurin visualisoinnilla
- **Repositorion rakenne**: Päivitetty kymmenestä yhdentoista pääosioon yksityiskohtaisella 11-MCPServerHandsOnLabs-kuvauksella
- **Oppimispolun ohjeistus**: Parannettu navigointiohjeita kattamaan osiot 00-11
- **Teknologian kattavuus**: Lisätty FastMCP, PostgreSQL ja Azure-palveluiden integraatiotiedot
- **Oppimistulokset**: Korostettu tuotantovalmiiden palvelimien kehittämistä, tietokantaintegraatiokäytäntöjä ja yritystason turvallisuutta

#### Pää-README-rakenteen parannus
- **Laboratoriopohjainen terminologia**: Päivitetty pää-README.md tiedostossa 11-MCPServerHandsOnLabs käyttämään johdonmukaisesti "Laboratorio"-rakennetta
- **Oppimispolun organisointi**: Selkeä progressio perustavanlaatuisista käsitteistä edistyneeseen toteutukseen ja tuotantoon
- **Todellisen maailman painotus**: Käytännön, käytännönläheisen oppimisen korostaminen yritystason käytäntöjen ja teknologioiden avulla

### Dokumentaation laatu- ja johdonmukaisuusparannukset
- **Käytännön oppimisen painotus**: Vahvistettu käytännönläheistä, laboratoriopohjaista lähestymistapaa dokumentaation läpi
- **Yrityskäytäntöjen painotus**: Korostettu tuotantovalmiita toteutuksia ja yritystason turvallisuuskäytäntöjä
- **Teknologian integraatio**: Kattava modernien Azure-palveluiden ja AI-integraatiokäytäntöjen kattavuus
- **Oppimisprogressio**: Selkeä, rakenteellinen polku peruskäsitteistä tuotantoon

## 26. syyskuuta 2025

### Tapaustutkimusten parannus - GitHub MCP Registry -integraatio

#### Tapaustutkimukset (09-CaseStudy/) - Ekosysteemin kehityksen painotus
- **README.md**: Merkittävä laajennus kattavalla GitHub MCP Registry -tapaustutkimuksella
  - **GitHub MCP Registry -tapaustutkimus**: Uusi kattava tapaustutkimus, joka tarkastelee GitHubin MCP Registry -julkaisua syyskuussa 2025
    - **Ongelma-analyysi**: Yksityiskohtainen tarkastelu hajautettujen MCP-palvelimien löytämisen ja käyttöönoton haasteista
    - **Ratkaisun arkkitehtuuri**: GitHubin keskitetty rekisterilähestymistapa yhdellä napsautuksella tehtävään VS Code -asennukseen
    - **Liiketoimintavaikutus**: Mitattavat parannukset kehittäjien perehdyttämisessä ja tuottavuudessa
    - **Strateginen arvo**: Painotus modulaaristen agenttien käyttöönottoon ja työkalujen yhteentoimivuuteen
    - **Ekosysteemin kehitys**: Sijoittuminen perustavanlaatuiseksi alustaksi agenttien integraatiolle
  - **Parannettu tapaustutkimusrakenne**: Päivitetty kaikki seitsemän tapaustutkimusta johdonmukaisella muotoilulla ja kattavilla kuvauksilla
    - Azure AI Travel Agents: Moniagenttien orkestroinnin painotus
    - Azure DevOps -integraatio: Työnkulun automaation painotus
    - Reaaliaikainen dokumentaation haku: Python-konsoliasiakasohjelman toteutus
    - Interaktiivinen opintosuunnitelman generaattori: Chainlit-keskustelupohjainen verkkosovellus
    - Editorin sisäinen dokumentaatio: VS Code ja GitHub Copilot -integraatio
    - Azure API Management: Yrityksen API-integraatiokäytännöt
    - GitHub MCP Registry: Ekosysteemin kehitys ja yhteisöalusta
  - **Kattava johtopäätös**: Uudelleen kirjoitettu johtopäätösosio, joka korostaa seitsemää tapaustutkimusta, jotka kattavat useita MCP-toteutuksen ulottuvuuksia
    - Yrityksen integraatio, moniagenttien orkestrointi, kehittäjien tuottavuus
    - Ekosysteemin kehitys, koulutussovellusten kategorisointi
    - Parannettuja näkemyksiä arkkitehtuurikäytännöistä, toteutusstrategioista ja parhaista käytännöistä
    - Painotus MCP:hen kypsänä, tuotantovalmiina protokollana

#### Opasmateriaalin päivitykset (study_guide.md)
- **Visuaalinen opetussuunnitelmakartta**: Päivitetty miellekartta sisältämään GitHub MCP Registry tapaustutkimusten osiossa
- **Tapaustutkimusten kuvaus**: Parannettu yleisistä kuvauksista yksityiskohtaiseen seitsemän kattavan tapaustutkimuksen erittelyyn
- **Repositorion rakenne**: Päivitetty osio 10 heijastamaan kattavaa tapaustutkimusten kattavuutta erityisillä toteutustiedoilla
- **Muutosloki-integraatio**: Lisätty 26. syyskuuta 2025 merkintä dokumentoimaan GitHub MCP Registry -lisäys ja tapaustutkimusten parannukset
- **Päivämääräpäivitykset**: Päivitetty alatunnisteen aikaleima heijastamaan viimeisintä tarkistusta (26. syyskuuta 2025)

### Dokumentaation laatuparannukset
- **Johdonmukaisuuden parannus**: Standardoitu tapaustutkimusten muotoilu ja rakenne kaikissa seitsemässä esimerkissä
- **Kattava kattavuus**: Tapaustutkimukset kattavat nyt yrityksen, kehittäjien tuottavuuden ja ekosysteemin kehityksen skenaariot
- **Strateginen asema**: Parannettu painotus MCP:hen perustavanlaatuisena alustana agenttijärjestelmien käyttöönotolle
- **Resurssi-integraatio**: Päivitetty lisäresurssit sisältämään GitHub MCP Registry -linkin

## 15. syyskuuta 2025

### Edistyneiden aiheiden laajennus - Mukautetut kuljetukset ja kontekstin suunnittelu

#### MCP Custom Transports (05-AdvancedTopics/mcp-transport/) - Uusi edistynyt toteutusopas
- **README.md**: Täydellinen toteutusopas mukautetuille MCP-kuljetusmekanismeille
  - **Azure Event Grid Transport**: Kattava palvelimettoman tapahtumapohjaisen kuljetuksen toteutus
    - C#, TypeScript ja Python-esimerkit Azure Functions -integraatiolla
    - Tapahtumapohjaiset arkkitehtuurikäytännöt skaalautuville MCP-ratkaisuille
    - Webhook-vastaanottimet ja push-pohjainen viestien käsittely
  - **Azure Event Hubs Transport**: Suuritehoinen suoratoistokuljetuksen toteutus
    - Reaaliaikaiset suoratoistokyvyt matalan viiveen skenaarioille
    - Osiointistrategiat ja tarkistuspisteiden hallinta
    - Viestien eräajot ja suorituskyvyn optimointi
  - **Yrityksen integraatiokäytännöt**: Tuotantovalmiit arkkitehtuuriesimerkit
    - Hajautettu MCP-prosessointi useiden Azure Functions -toimintojen välillä
    - Hybridikuljetusarkkitehtuurit, jotka yhdistävät useita kuljetustyyppejä
    - Viestien kestävyys, luotettavuus ja virheenkäsittelystrategiat
  - **Turvallisuus ja valvonta**: Azure Key Vault -integraatio ja havaittavuuskäytännöt
    - Hallittu identiteettitodennus ja vähimmäisoikeuksien käyttö
    - Application Insights -telemetria ja suorituskyvyn valvonta
    - Piirikatkaisijat ja vikasietokäytännöt
  - **Testauskehykset**: Kattavat testausstrategiat mukautetuille kuljetuksille
    - Yksikkötestaus testikopioilla ja mockauskehyksillä
    - Integraatiotestaus Azure Test Containers -ratkaisulla
    - Suorituskyvyn ja kuormituksen testausnäkökohdat

#### Kontekstin suunnittelu (05-AdvancedTopics/mcp-contextengineering/) - Nouseva AI-draama
- **README.md**: Kattava tutkimus kontekstin suunnittelusta nousevana alana
  - **Keskeiset periaatteet**: Täydellinen kontekstin jakaminen, toiminnan päätöksentekotietoisuus ja kontekstin ikkunan hallinta
  - **MCP-protokollan linjaus**: Kuinka MCP-suunnittelu vastaa kontekstin suunnittelun haasteisiin
    - Kontekstin ikkunan rajoitukset ja progressiiviset latausstrategiat
    - Relevanssin määrittäminen ja dynaaminen kontekstin haku
    - Monimuotoinen kontekstin käsittely ja turvallisuuskäytännöt
  - **Toteutustavat**: Yksisäikeiset vs. moniagenttiset arkkitehtuurit
    - Kontekstin pilkkominen ja priorisointitekniikat
    - Progressiivinen kontekstin lataus ja pakkausstrategiat
    - Kerrostetut kontekstilähestymistavat ja hakujen optimointi
  - **Mittauskehys**: Nousevat mittarit kontekstin tehokkuuden arviointiin
    - Syötteen tehokkuus, suorituskyky, laatu ja käyttäjäkokemuksen näkökohdat
    - Kokeelliset lähestymistavat kontekstin optimointiin
    - Virheanalyysi ja parannusmenetelmät

#### Opetussuunnitelman navigointipäivitykset (README.md)
- **Parannettu moduulirakenne**: Päivitetty opetussuunnitelmataulukko sisältämään uudet edistyneet aiheet
  - Lisätty Kontekstin suunnittelu (5.14) ja Mukautettu kuljetus (5.15) -merkinnät
  - Johdonmukainen muotoilu ja navigointilinkit kaikissa moduuleissa
  - Päivitetyt kuvaukset heijastamaan nykyistä sisällön laajuutta

### Hakemistorakenteen parannukset
- **Nimeämisen standardointi**: Uudelleennimetty "mcp transport" muotoon "mcp-transport" johdonmukaisuuden vuoksi muiden edistyneiden aiheiden kansioiden kanssa
- **Sisällön organisointi**: Kaikki 05-AdvancedTopics-kansiot noudattavat nyt johdonmukaista nimeämismallia (mcp-[aihe])

### Dokumentaation laatuparannukset
- **MCP-määrittelyn linjaus**: Kaikki uusi sisältö viittaa nykyiseen MCP-määrittelyyn 2025-06-18
- **Monikieliset esimerkit**: Kattavat koodiesimerkit C#:ssa, TypeScriptissä ja Pythonissa
- **Yrityksen painotus**: Tuotantovalmiit käytännöt ja Azure-pilvi-integraatio dokumentaation läpi
- **Visuaalinen dokumentaatio**: Mermaid-kaaviot arkkitehtuurin ja virtausvisualisoinnin tueksi

## 18. elokuuta 2025

### Dokumentaation kattava päivitys - MCP 2025-06-18 -standardit

#### MCP Security Best Practices (02-Security/) - Täydellinen modernisointi
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Täydellinen uudelleenkirjoitus MCP-määrittelyn 2025-06-18 mukaisesti
  - **Pakolliset vaatimukset**: Lisätty selkeät MUST/MUST NOT -vaatimukset virallisesta määrittelystä visuaalisilla indikaattoreilla
  - **12 ydinturvallisuuskäytäntöä**: Järjestetty uudelleen 15 kohdan listasta kattaviin turvallisuusalueisiin
    - Token-turvallisuus ja todennus ulkoisen identiteettipalveluntarjoajan integraatiolla
    - Istunnon hallinta ja kuljetusturvallisuus kryptografisilla vaatimuksilla
    - AI-spesifinen uhkien torjunta Microsoft Prompt Shields -integraatiolla
    - Pääsynhallinta ja käyttöoikeudet vähimmäisoikeuksien periaatteella
    - Sisällön turvallisuus ja valvonta Azure Content Safety -integraatiolla
    - Toimitusketjun turvallisuus kattavalla komponenttien tarkistuksella
    - OAuth-turvallisuus ja Confused Deputy -hyökkäysten estäminen PKCE-toteutuksella
    - Tapahtumien hallinta ja palautuminen automatisoiduilla ominaisuuksilla
    - Säädösten noudattaminen ja hallinto sääntelyyn mukautumisella
    - Edistyneet turvallisuuskontrollit nollaluottamusarkkitehtuurilla
    - Microsoftin turvallisuusekosysteemin integraatio kattavilla ratkaisuilla
    - Jatkuva turvallisuuden kehitys mukautuvilla käytännöillä
  - **Microsoftin turvallisuusratkaisut**: Parannettu integraatio-ohjeistus Prompt Shieldsille, Azure Content Safetylle, Entra ID:lle ja GitHub Advanced Securitylle
  - **Tote
- **Visuaaliset indikaattorit**: Selkeä merkintä pakollisista vaatimuksista vs. suositelluista käytännöistä

#### Ydinkonseptit (01-CoreConcepts/) - Täydellinen modernisointi
- **Protokollaversion päivitys**: Päivitetty viittaamaan nykyiseen MCP-määrittelyyn 2025-06-18 käyttäen päivämääräpohjaista versionumerointia (YYYY-MM-DD-muoto)
- **Arkkitehtuurin tarkennus**: Parannettu isäntien, asiakkaiden ja palvelimien kuvauksia nykyisten MCP-arkkitehtuurimallien mukaisesti
  - Isännät määritelty selkeästi AI-sovelluksiksi, jotka koordinoivat useita MCP-asiakasliitäntöjä
  - Asiakkaat kuvattu protokollaliitäntöinä, jotka ylläpitävät yksi-yhteen-suhdetta palvelimiin
  - Palvelimet parannettu paikallisten vs. etäkäyttöön liittyvien skenaarioiden osalta
- **Primitivien uudelleenjärjestely**: Täydellinen palvelin- ja asiakasprimitivien uudistus
  - Palvelinprimitivit: Resurssit (datapisteet), Kehotteet (mallipohjat), Työkalut (suoritettavat funktiot) yksityiskohtaisilla selityksillä ja esimerkeillä
  - Asiakasprimitivit: Näytteenotto (LLM-täydennykset), Tiedustelu (käyttäjän syöte), Lokitus (virheenkorjaus/seuranta)
  - Päivitetty nykyisillä löytämisen (`*/list`), hakemisen (`*/get`) ja suorittamisen (`*/call`) menetelmämalleilla
- **Protokolla-arkkitehtuuri**: Esitelty kaksikerroksinen arkkitehtuurimalli
  - Datalayer: JSON-RPC 2.0 -pohja elinkaaren hallinnalla ja primitiiveillä
  - Kuljetuskerros: STDIO (paikallinen) ja Streamable HTTP SSE:llä (etäkäyttö)
- **Turvallisuuskehys**: Kattavat turvallisuusperiaatteet, mukaan lukien käyttäjän nimenomainen suostumus, tietosuojan suojaaminen, työkalujen turvallinen suorittaminen ja kuljetuskerroksen turvallisuus
- **Viestintämallit**: Päivitetty protokollaviestit näyttämään alustuksen, löytämisen, suorittamisen ja ilmoitusvirrat
- **Koodiesimerkit**: Uudistettu monikieliset esimerkit (.NET, Java, Python, JavaScript) nykyisten MCP SDK -mallien mukaisiksi

#### Turvallisuus (02-Security/) - Kattava turvallisuuden uudistus  
- **Standardien mukaisuus**: Täysi yhdenmukaisuus MCP-määrittelyn 2025-06-18 turvallisuusvaatimusten kanssa
- **Autentikoinnin kehitys**: Dokumentoitu siirtyminen mukautetuista OAuth-palvelimista ulkoisten identiteettipalveluntarjoajien delegointiin (Microsoft Entra ID)
- **AI-spesifinen uhka-analyysi**: Parannettu nykyaikaisten AI-hyökkäysvektorien kattavuus
  - Yksityiskohtaiset kehotteen injektiohyökkäysskenaariot tosielämän esimerkeillä
  - Työkalujen myrkytysmenetelmät ja "rug pull" -hyökkäysmallit
  - Kontekstin ikkunan myrkytys ja mallin sekaannushyökkäykset
- **Microsoftin AI-turvallisuusratkaisut**: Kattava Microsoftin turvallisuusekosysteemin kattavuus
  - AI Prompt Shields edistyneillä tunnistus-, korostus- ja erottelutekniikoilla
  - Azure Content Safety -integraatiomallit
  - GitHub Advanced Security toimitusketjun suojaamiseen
- **Edistyneet uhkien lieventämiskeinot**: Yksityiskohtaiset turvallisuuskontrollit
  - Istunnon kaappaus MCP-spesifisillä hyökkäysskenaarioilla ja kryptografisilla istuntotunnistevaatimuksilla
  - Hämmentyneen sijaisen ongelmat MCP-välitysskenaarioissa nimenomaisilla suostumusvaatimuksilla
  - Tokenin läpivientivulnerabiliteetit pakollisilla validointikontrolleilla
- **Toimitusketjun turvallisuus**: Laajennettu AI-toimitusketjun kattavuus, mukaan lukien perustamallit, upotettujen palvelut, kontekstin tarjoajat ja kolmannen osapuolen API:t
- **Perusturvallisuus**: Parannettu integraatio yritysturvallisuusmallien kanssa, mukaan lukien nollaluottamusarkkitehtuuri ja Microsoftin turvallisuusekosysteemi
- **Resurssien organisointi**: Kategorisoitu kattavat resurssilinkit tyypin mukaan (viralliset dokumentit, standardit, tutkimus, Microsoftin ratkaisut, toteutusoppaat)

### Dokumentaation laadun parannukset
- **Rakenteelliset oppimistavoitteet**: Parannettu oppimistavoitteet konkreettisilla, toiminnallisilla tuloksilla
- **Ristiviittaukset**: Lisätty linkkejä liittyvien turvallisuus- ja ydinkonseptiaiheiden välillä
- **Ajankohtainen tieto**: Päivitetty kaikki päivämääräviittaukset ja määrittelylinkit nykyisiin standardeihin
- **Toteutusohjeet**: Lisätty konkreettisia, toiminnallisia toteutusohjeita molempiin osioihin

## 16. heinäkuuta 2025

### README ja navigoinnin parannukset
- Suunniteltu README.md:n kurssinavigointi kokonaan uudelleen
- Korvattu `<details>`-tagit saavutettavammalla taulukkomuotoisella rakenteella
- Luotu vaihtoehtoisia asetteluvaihtoehtoja uuteen "alternative_layouts" -kansioon
- Lisätty korttipohjaisia, välilehtityylisiä ja haitarityylisiä navigointiesimerkkejä
- Päivitetty hakemistorakenteen osio sisältämään kaikki uusimmat tiedostot
- Parannettu "Kuinka käyttää tätä kurssia" -osio selkeillä suosituksilla
- Päivitetty MCP-määrittelylinkit osoittamaan oikeisiin URL-osoitteisiin
- Lisätty kontekstin suunnittelun osio (5.14) kurssirakenteeseen

### Opasmuutokset
- Uudistettu opas kokonaan nykyisen hakemistorakenteen mukaiseksi
- Lisätty uusia osioita MCP-asiakkaille ja -työkaluille sekä suosituimmille MCP-palvelimille
- Päivitetty visuaalinen kurssikartta vastaamaan tarkasti kaikkia aiheita
- Parannettu edistyneiden aiheiden kuvauksia kattamaan kaikki erikoistuneet alueet
- Päivitetty tapaustutkimusten osio vastaamaan todellisia esimerkkejä
- Lisätty tämä kattava muutosloki

### Yhteisön panokset (06-CommunityContributions/)
- Lisätty yksityiskohtaista tietoa MCP-palvelimista kuvagenerointia varten
- Lisätty kattava osio Clauden käytöstä VSCode:ssa
- Lisätty Cline-päätteen asiakasohjelman asennus- ja käyttöohjeet
- Päivitetty MCP-asiakasosio sisältämään kaikki suosituimmat asiakasvaihtoehdot
- Parannettu esimerkkipanoksia tarkemmilla koodinäytteillä

### Edistyneet aiheet (05-AdvancedTopics/)
- Järjestetty kaikki erikoistuneiden aiheiden kansiot johdonmukaisilla nimillä
- Lisätty kontekstin suunnittelumateriaaleja ja esimerkkejä
- Lisätty Foundry-agentin integrointidokumentaatio
- Parannettu Entra ID -turvallisuusintegraation dokumentaatio

## 11. kesäkuuta 2025

### Alkuperäinen luominen
- Julkaistu ensimmäinen versio MCP for Beginners -kurssista
- Luotu perusrakenne kaikille 10 pääosiolle
- Toteutettu visuaalinen kurssikartta navigointia varten
- Lisätty alkuperäiset esimerkkiprojektit useilla ohjelmointikielillä

### Aloittaminen (03-GettingStarted/)
- Luotu ensimmäiset palvelimen toteutusesimerkit
- Lisätty asiakasohjelman kehitysopas
- Sisällytetty LLM-asiakasintegraatio-ohjeet
- Lisätty VS Code -integraation dokumentaatio
- Toteutettu Server-Sent Events (SSE) -palvelinesimerkit

### Ydinkonseptit (01-CoreConcepts/)
- Lisätty yksityiskohtainen selitys asiakas-palvelin-arkkitehtuurista
- Luotu dokumentaatio keskeisistä protokollakomponenteista
- Dokumentoitu viestintämallit MCP:ssä

## 23. toukokuuta 2025

### Hakemistorakenne
- Alustettu hakemisto peruskansiorakenteella
- Luotu README-tiedostot jokaiselle pääosalle
- Asetettu käännösinfrastruktuuri
- Lisätty kuvatiedostot ja kaaviot

### Dokumentaatio
- Luotu alkuperäinen README.md kurssin yleiskatsauksella
- Lisätty CODE_OF_CONDUCT.md ja SECURITY.md
- Asetettu SUPPORT.md ohjeilla avun saamiseen
- Luotu alustava opasrakenne

## 15. huhtikuuta 2025

### Suunnittelu ja kehys
- Alustava suunnittelu MCP for Beginners -kurssille
- Määritelty oppimistavoitteet ja kohdeyleisö
- Luotu kurssin 10-osainen rakenne
- Kehitetty käsitteellinen kehys esimerkeille ja tapaustutkimuksille
- Luotu alkuperäiset prototyyppiesimerkit keskeisistä konsepteista

---

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää ensisijaisena lähteenä. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.