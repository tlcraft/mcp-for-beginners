<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T18:37:13+00:00",
  "source_file": "changelog.md",
  "language_code": "fi"
}
-->
# Muutosloki: MCP for Beginners -opetussuunnitelma

Tämä dokumentti toimii kirjana kaikista merkittävistä muutoksista, jotka on tehty Model Context Protocol (MCP) for Beginners -opetussuunnitelmaan. Muutokset on dokumentoitu käänteisessä aikajärjestyksessä (uusimmat muutokset ensin).

## 26. syyskuuta 2025

### Tapaustutkimusten parannus - GitHub MCP Registry -integraatio

#### Tapaustutkimukset (09-CaseStudy/) - Ekosysteemin kehittämisen painopiste
- **README.md**: Merkittävä laajennus kattavalla GitHub MCP Registry -tapaustutkimuksella
  - **GitHub MCP Registry -tapaustutkimus**: Uusi kattava tapaustutkimus GitHubin MCP Registry -julkaisusta syyskuussa 2025
    - **Ongelma-analyysi**: Yksityiskohtainen tarkastelu hajautetun MCP-palvelimen löytämisen ja käyttöönoton haasteista
    - **Ratkaisun arkkitehtuuri**: GitHubin keskitetty rekisterilähestymistapa yhden klikkauksen VS Code -asennuksella
    - **Liiketoiminnallinen vaikutus**: Mitattavat parannukset kehittäjien perehdyttämisessä ja tuottavuudessa
    - **Strateginen arvo**: Painopiste modulaarisessa agenttien käyttöönotossa ja työkalujen välisessä yhteentoimivuudessa
    - **Ekosysteemin kehittäminen**: Sijoittuminen perustavanlaatuiseksi alustaksi agenttien integraatiolle
  - **Parannettu tapaustutkimusten rakenne**: Päivitetty kaikki seitsemän tapaustutkimusta yhtenäisellä muotoilulla ja kattavilla kuvauksilla
    - Azure AI Travel Agents: Painotus monen agentin orkestroinnissa
    - Azure DevOps -integraatio: Työnkulun automaation painopiste
    - Reaaliaikainen dokumentaation haku: Python-konsoliklientin toteutus
    - Interaktiivinen opintosuunnitelman generaattori: Chainlit-keskustelupohjainen verkkosovellus
    - Editorin sisäinen dokumentaatio: VS Code ja GitHub Copilot -integraatio
    - Azure API Management: Yrityksen API-integraatiomallit
    - GitHub MCP Registry: Ekosysteemin kehittäminen ja yhteisöalusta
  - **Kattava johtopäätös**: Uudelleen kirjoitettu johtopäätösosio, joka korostaa seitsemää tapaustutkimusta eri MCP-toteutusulottuvuuksilla
    - Yritysintegraatio, monen agentin orkestrointi, kehittäjien tuottavuus
    - Ekosysteemin kehittäminen, koulutussovellusten kategorisointi
    - Parannettuja näkemyksiä arkkitehtuurimalleista, toteutusstrategioista ja parhaista käytännöistä
    - Painotus MCP:hen kypsänä, tuotantovalmiina protokollana

#### Opas päivitykset (study_guide.md)
- **Visuaalinen opetussuunnitelmakartta**: Päivitetty miellekartta sisältämään GitHub MCP Registry tapaustutkimusten osiossa
- **Tapaustutkimusten kuvaus**: Parannettu yleisistä kuvauksista yksityiskohtaisiin seitsemän kattavan tapaustutkimuksen erittelyihin
- **Repositorion rakenne**: Päivitetty osio 10 heijastamaan kattavaa tapaustutkimusten kattavuutta erityisillä toteutustiedoilla
- **Muutosloki-integraatio**: Lisätty 26. syyskuuta 2025 merkintä dokumentoimaan GitHub MCP Registry -lisäys ja tapaustutkimusten parannukset
- **Päivämääräpäivitykset**: Päivitetty alatunnisteen aikaleima heijastamaan viimeisintä tarkistusta (26. syyskuuta 2025)

### Dokumentaation laadun parannukset
- **Johdonmukaisuuden parannus**: Vakioitu tapaustutkimusten muotoilu ja rakenne kaikissa seitsemässä esimerkissä
- **Kattava kattavuus**: Tapaustutkimukset kattavat nyt yritys-, kehittäjätuottavuus- ja ekosysteemin kehittämisskenaariot
- **Strateginen asema**: Parannettu painotus MCP:hen perustavanlaatuisena alustana agenttijärjestelmien käyttöönotossa
- **Resurssien integrointi**: Päivitetty lisäresurssit sisältämään GitHub MCP Registry -linkin

## 15. syyskuuta 2025

### Edistyneiden aiheiden laajennus - Mukautetut kuljetukset ja kontekstin suunnittelu

#### MCP Mukautetut kuljetukset (05-AdvancedTopics/mcp-transport/) - Uusi edistynyt toteutusopas
- **README.md**: Täydellinen toteutusopas mukautetuille MCP-kuljetusmekanismeille
  - **Azure Event Grid Transport**: Kattava palveluton tapahtumapohjainen kuljetustoteutus
    - C#, TypeScript ja Python-esimerkit Azure Functions -integraatiolla
    - Tapahtumapohjaiset arkkitehtuurimallit skaalautuville MCP-ratkaisuille
    - Webhook-vastaanottimet ja push-pohjainen viestien käsittely
  - **Azure Event Hubs Transport**: Suuritehoinen suoratoistokuljetustoteutus
    - Reaaliaikaiset suoratoistokyvyt matalan viiveen skenaarioille
    - Osiointistrategiat ja tarkistuspisteiden hallinta
    - Viestien eräajot ja suorituskyvyn optimointi
  - **Yrityksen integraatiomallit**: Tuotantovalmiit arkkitehtuuriesimerkit
    - Hajautettu MCP-prosessointi useiden Azure Functions -toimintojen välillä
    - Hybridikuljetusarkkitehtuurit, jotka yhdistävät useita kuljetustyyppejä
    - Viestien kestävyys, luotettavuus ja virheenkäsittelystrategiat
  - **Turvallisuus ja valvonta**: Azure Key Vault -integraatio ja havainnointimallit
    - Hallittu identiteettiautentikointi ja vähimmäisoikeuksien käyttö
    - Application Insights -telemetria ja suorituskyvyn valvonta
    - Piirikatkaisijat ja vikasietomallit
  - **Testauskehykset**: Kattavat testausstrategiat mukautetuille kuljetuksille
    - Yksikkötestaus testikopioilla ja mockauskehyksillä
    - Integraatiotestaus Azure Test Containers -työkaluilla
    - Suorituskyky- ja kuormitustestauksen huomioiminen

#### Kontekstin suunnittelu (05-AdvancedTopics/mcp-contextengineering/) - Nouseva AI-ala
- **README.md**: Kattava tutkimus kontekstin suunnittelusta nousevana alana
  - **Keskeiset periaatteet**: Täydellinen kontekstin jakaminen, toiminnan päätöksentekotietoisuus ja kontekstin ikkunan hallinta
  - **MCP-protokollan linjaus**: Kuinka MCP:n suunnittelu vastaa kontekstin suunnittelun haasteisiin
    - Kontekstin ikkunan rajoitukset ja progressiiviset latausstrategiat
    - Relevanssin määrittäminen ja dynaaminen kontekstin haku
    - Monimuotoinen kontekstin käsittely ja turvallisuushuomiot
  - **Toteutustavat**: Yksisäikeiset vs. monen agentin arkkitehtuurit
    - Kontekstin pilkkominen ja priorisointitekniikat
    - Progressiivinen kontekstin lataus ja pakkausstrategiat
    - Kerrostetut kontekstilähestymistavat ja hakujen optimointi
  - **Mittauskehys**: Nousevat mittarit kontekstin tehokkuuden arviointiin
    - Syötteen tehokkuus, suorituskyky, laatu ja käyttäjäkokemuksen huomioiminen
    - Kokeelliset lähestymistavat kontekstin optimointiin
    - Virheanalyysi ja parannusmenetelmät

#### Opetussuunnitelman navigointipäivitykset (README.md)
- **Parannettu moduulirakenne**: Päivitetty opetussuunnitelman taulukko sisältämään uudet edistyneet aiheet
  - Lisätty Kontekstin suunnittelu (5.14) ja Mukautetut kuljetukset (5.15) -kohdat
  - Johdonmukainen muotoilu ja navigointilinkit kaikissa moduuleissa
  - Päivitetyt kuvaukset heijastamaan nykyistä sisällön laajuutta

### Hakemistorakenteen parannukset
- **Nimeämisen standardointi**: Uudelleennimetty "mcp transport" muotoon "mcp-transport" johdonmukaisuuden vuoksi muiden edistyneiden aiheiden kansioiden kanssa
- **Sisällön organisointi**: Kaikki 05-AdvancedTopics-kansiot noudattavat nyt johdonmukaista nimeämismallia (mcp-[aihe])

### Dokumentaation laadun parannukset
- **MCP-määrittelyn linjaus**: Kaikki uusi sisältö viittaa nykyiseen MCP-määrittelyyn 2025-06-18
- **Monikieliset esimerkit**: Kattavat koodiesimerkit C#:ssä, TypeScriptissä ja Pythonissa
- **Yrityksen painopiste**: Tuotantovalmiit mallit ja Azure-pilvi-integraatio koko sisällössä
- **Visuaalinen dokumentaatio**: Mermaid-kaaviot arkkitehtuurin ja virtausten visualisointiin

## 18. elokuuta 2025

### Dokumentaation kattava päivitys - MCP 2025-06-18 -standardit

#### MCP Turvallisuuden parhaat käytännöt (02-Security/) - Täydellinen modernisointi
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Täydellinen uudelleenkirjoitus MCP-määrittelyn 2025-06-18 mukaisesti
  - **Pakolliset vaatimukset**: Lisätty selkeät MUST/MUST NOT -vaatimukset virallisesta määrittelystä visuaalisilla indikaattoreilla
  - **12 keskeistä turvallisuuskäytäntöä**: Järjestetty uudelleen 15 kohdan listasta kattaviin turvallisuusalueisiin
    - Token-turvallisuus ja autentikointi ulkoisen identiteettipalveluntarjoajan integraatiolla
    - Istunnon hallinta ja kuljetusturvallisuus kryptografisilla vaatimuksilla
    - AI-spesifinen uhkien torjunta Microsoft Prompt Shields -integraatiolla
    - Pääsynhallinta ja käyttöoikeudet vähimmäisoikeuksien periaatteella
    - Sisällön turvallisuus ja valvonta Azure Content Safety -integraatiolla
    - Toimitusketjun turvallisuus kattavalla komponenttien tarkistuksella
    - OAuth-turvallisuus ja Confused Deputy -hyökkäysten estäminen PKCE-toteutuksella
    - Tapahtumien hallinta ja palautuminen automatisoiduilla ominaisuuksilla
    - Sääntöjenmukaisuus ja hallinto sääntelyyn mukautumisella
    - Edistyneet turvallisuuskontrollit nollaluottamusarkkitehtuurilla
    - Microsoftin turvallisuusekosysteemin integraatio kattavilla ratkaisuilla
    - Jatkuva turvallisuuden kehitys mukautuvilla käytännöillä
  - **Microsoftin turvallisuusratkaisut**: Parannettu integraatio-ohje Prompt Shieldsille, Azure Content Safetylle, Entra ID:lle ja GitHub Advanced Securitylle
  - **Toteutusresurssit**: Kategorisoitu kattavat resurssilinkit virallisen MCP-dokumentaation, Microsoftin turvallisuusratkaisujen, turvallisuusstandardien ja toteutusoppaiden mukaan

#### Edistyneet turvallisuuskontrollit (02-Security/) - Yritystason toteutus
- **MCP-SECURITY-CONTROLS-2025.md**: Täydellinen uudistus yritystason turvallisuuskehyksellä
  - **9 kattavaa turvallisuusaluetta**: Laajennettu peruskontrolleista yksityiskohtaiseen yrityskehykseen
    - Edistynyt autentikointi ja valtuutus Microsoft Entra ID -integraatiolla
    - Token-turvallisuus ja anti-passthrough-kontrollit kattavalla validoinnilla
    - Istunnon turvallisuuskontrollit kaappauksen estämiseksi
    - AI-spesifiset turvallisuuskontrollit prompt-injektion ja työkalumyrkytyksen estämiseksi
    - Confused Deputy -hyökkäysten estäminen OAuth-välityspalvelimen turvallisuudella
    - Työkalujen suorittamisen turvallisuus hiekkalaatikko- ja eristysratkaisuilla
    - Toimitusketjun turvallisuuskontrollit riippuvuuksien tarkistuksella
    - Valvonta- ja havainnointikontrollit SIEM-integraatiolla
    - Tapahtumien hallinta ja palautuminen automatisoiduilla ominaisuuksilla
  - **Toteutusesimerkit**: Lisätty yksityiskohtaiset YAML-konfiguraatiolohkot ja koodiesimerkit
  - **Microsoftin ratkaisujen integraatio**: Kattava Azure-turvallisuuspalveluiden, GitHub Advanced Securityn ja yrityksen identiteetinhallinnan kattavuus

#### Edistyneet aiheet turvallisuus (05-AdvancedTopics/mcp-security/) - Tuotantovalmiit toteutukset
- **README.md**: Täydellinen uudelleenkirjoitus yritystason turvallisuustoteutuksille
  - **Nykyisen määrittelyn linjaus**: Päivitetty MCP-määrittelyyn 2025-06-18 pakollisilla turvallisuusvaatimuksilla
  - **Parannettu autentikointi**: Microsoft Entra ID -integraatio kattavilla .NET- ja Java Spring Security -esimerkeillä
  - **AI-turvallisuuden integraatio**: Microsoft Prompt Shields ja Azure Content Safety -toteutus yksityiskohtaisilla Python-esimerkeillä
  - **Edistyneet uhkien torjuntakeinot**: Kattavat toteutusesimerkit
    - Confused Deputy -hyökkäysten estäminen PKCE:llä ja käyttäjän suostumuksen validoinnilla
    - Token-passthrough-haavoittuvuuksien estäminen yleisön validoinnilla ja turvallisella token-hallinnalla
    - Istunnon kaappauksen estäminen kryptografisella sidonnalla ja käyttäytymisanalyysillä
  - **Yrityksen turvallisuuden integraatio**: Azure Application Insights -valvonta, uhkien havainnointiputket ja toimitusketjun turvallisuus
  - **Toteutuschecklist**: Selkeät pakolliset vs. suositellut turvallisuuskontrollit Microsoftin turvallisuusekosysteemin hyödyillä

### Dokumentaation laatu ja standardien linjaus
- **Määrittelyviittaukset**: Päivitetty kaikki viittaukset nykyiseen MCP-määrittelyyn 2025-06-18
- **Microsoftin turvallisuusekosysteemi**: Parannettu integraatio-ohje koko turvallisuusdokumentaatiossa
- **Käytännön toteutus**: Lisätty yksityiskohtaiset koodiesimerkit .NET:ssä, Javassa ja Pythonissa yritysmalleilla
- **Resurssien organisointi**: Kattava virallisen dokumentaation, turvallisuusstandardien ja toteutusoppaiden kategorisointi
- **Visuaaliset indikaattorit**: Selkeä merkintä pakollisista vaatimuksista vs. suositelluista käytännöistä

#### Keskeiset käsitteet (01-CoreConcepts/) - Täydellinen modernisointi
- **Protokollan versio päivitys**: Päivitetty viittaamaan nykyiseen MCP-määrittelyyn 2025-06-18 päivämääräpohjaisella versioinnilla (YYYY-MM-DD-muoto)
- **Arkkitehtuurin tarkennus**: Parannettu isäntien, asiakkaiden ja palvelimien kuvauksia heijastamaan nykyisiä MCP-arkkitehtuurimalleja
  - Isännät määritelty selkeästi AI-sovelluksiksi, jotka koordinoivat useita MCP-asiakasliitäntöjä
  - Asiakkaat kuvattu protokollaliitäntöinä, jotka ylläpitävät yksi-yhteen palvelinsuhteita
  - Palvelimet parannettu paikallisten vs. etäkäyttöönottoskenaarioiden osalta
- **Primitivien uudelleenjärjestely**: Täydellinen palvelin- ja asiakasprimitivien uudistus
  - Palvelinprimitivit: Resurssit (datapisteet), Kehotteet (mallit), Työkalut (suoritettavat fun
- Korvattu `<details>`-tagit saavutettavammalla taulukkomuotoisella esityksellä
- Luotu vaihtoehtoisia asetteluvaihtoehtoja uuteen "alternative_layouts"-kansioon
- Lisätty korttipohjaisia, välilehtityylisiä ja haitarityylisiä navigointiesimerkkejä
- Päivitetty "Repository Structure" -osio sisältämään kaikki uusimmat tiedostot
- Parannettu "How to Use This Curriculum" -osio selkeillä suosituksilla
- Päivitetty MCP-spesifikaatiolinkit osoittamaan oikeisiin URL-osoitteisiin
- Lisätty "Context Engineering" -osio (5.14) opetussuunnitelman rakenteeseen

### Opasmuutokset
- Opas uudistettu kokonaan vastaamaan nykyistä repository-rakennetta
- Lisätty uusia osioita MCP-asiakkaille ja -työkaluille sekä suosituimmille MCP-palvelimille
- Päivitetty visuaalinen opetussuunnitelmakartta vastaamaan kaikkia aiheita
- Parannettu "Advanced Topics" -kuvauksia kattamaan kaikki erikoistuneet alueet
- Päivitetty "Case Studies" -osio vastaamaan todellisia esimerkkejä
- Lisätty tämä kattava muutosloki

### Yhteisön panokset (06-CommunityContributions/)
- Lisätty yksityiskohtaista tietoa MCP-palvelimista kuvien generointiin
- Lisätty kattava osio Clauden käytöstä VSCode:ssa
- Lisätty Cline-päätteen asiakasohjelman asennus- ja käyttöohjeet
- Päivitetty MCP-asiakasosio sisältämään kaikki suosituimmat asiakasvaihtoehdot
- Parannettu esimerkkipanoksia tarkemmilla koodinäytteillä

### Edistyneet aiheet (05-AdvancedTopics/)
- Järjestetty kaikki erikoistuneet aihehakemistot yhtenäisillä nimillä
- Lisätty materiaaleja ja esimerkkejä kontekstisuunnittelusta
- Lisätty Foundry-agentin integrointidokumentaatio
- Parannettu Entra ID -turvaintegraation dokumentaatio

## 11. kesäkuuta 2025

### Ensimmäinen julkaisu
- Julkaistu MCP for Beginners -opetussuunnitelman ensimmäinen versio
- Luotu perusrakenne kaikille 10 pääosiolle
- Toteutettu visuaalinen opetussuunnitelmakartta navigointia varten
- Lisätty alkuperäiset esimerkkiprojektit useilla ohjelmointikielillä

### Aloittaminen (03-GettingStarted/)
- Luotu ensimmäiset palvelimen toteutusesimerkit
- Lisätty ohjeita asiakasohjelman kehittämiseen
- Sisällytetty LLM-asiakasintegraation ohjeet
- Lisätty VS Code -integraation dokumentaatio
- Toteutettu Server-Sent Events (SSE) -palvelimen esimerkit

### Peruskäsitteet (01-CoreConcepts/)
- Lisätty yksityiskohtainen selitys asiakas-palvelin-arkkitehtuurista
- Luotu dokumentaatio keskeisistä protokollakomponenteista
- Dokumentoitu viestintämallit MCP:ssä

## 23. toukokuuta 2025

### Repository-rakenne
- Alustettu repository peruskansiorakenteella
- Luotu README-tiedostot jokaiselle pääosalle
- Asetettu käännösinfrastruktuuri
- Lisätty kuvatiedostot ja kaaviot

### Dokumentaatio
- Luotu ensimmäinen README.md opetussuunnitelman yleiskatsauksella
- Lisätty CODE_OF_CONDUCT.md ja SECURITY.md
- Asetettu SUPPORT.md ohjeilla avun saamiseen
- Luotu alustava opasrakenne

## 15. huhtikuuta 2025

### Suunnittelu ja kehys
- Aloitettu MCP for Beginners -opetussuunnitelman suunnittelu
- Määritelty oppimistavoitteet ja kohdeyleisö
- Luotu 10-osainen opetussuunnitelman rakenne
- Kehitetty käsitteellinen kehys esimerkeille ja tapaustutkimuksille
- Luotu ensimmäiset prototyyppiesimerkit keskeisistä käsitteistä

---

