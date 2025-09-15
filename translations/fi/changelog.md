<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:19:00+00:00",
  "source_file": "changelog.md",
  "language_code": "fi"
}
-->
# Muutosloki: MCP for Beginners -opetussuunnitelma

Tämä dokumentti toimii merkittävien muutosten kirjana Model Context Protocol (MCP) for Beginners -opetussuunnitelmassa. Muutokset dokumentoidaan käänteisessä aikajärjestyksessä (uusimmat muutokset ensin).

## 15. syyskuuta 2025

### Laajennus edistyneisiin aiheisiin - Mukautetut kuljetukset ja kontekstin suunnittelu

#### MCP Mukautetut Kuljetukset (05-AdvancedTopics/mcp-transport/) - Uusi edistyneen tason toteutusopas
- **README.md**: Täydellinen toteutusopas MCP:n mukautetuille kuljetusmekanismeille
  - **Azure Event Grid Transport**: Kattava palveluton tapahtumapohjainen kuljetustoteutus
    - Esimerkit C#:llä, TypeScriptillä ja Pythonilla Azure Functions -integraatiolla
    - Tapahtumapohjaiset arkkitehtuurimallit skaalautuville MCP-ratkaisuille
    - Webhook-vastaanottimet ja push-pohjainen viestien käsittely
  - **Azure Event Hubs Transport**: Suuritehoinen suoratoistokuljetustoteutus
    - Reaaliaikaiset suoratoistomahdollisuudet matalan viiveen skenaarioihin
    - Osiointistrategiat ja tarkistuspisteiden hallinta
    - Viestien eräajot ja suorituskyvyn optimointi
  - **Yritysintegraatiomallit**: Tuotantovalmiit arkkitehtuuriesimerkit
    - Hajautettu MCP-prosessointi useiden Azure Functions -toimintojen välillä
    - Hybridikuljetusarkkitehtuurit, jotka yhdistävät useita kuljetustyyppejä
    - Viestien kestävyys, luotettavuus ja virheenkäsittelystrategiat
  - **Turvallisuus ja valvonta**: Azure Key Vault -integraatio ja havainnointimallit
    - Hallittu identiteettitodennus ja vähimmäisoikeuksien käyttö
    - Application Insights -telemetria ja suorituskyvyn seuranta
    - Piirikatkaisijat ja vikasietomallit
  - **Testauskehykset**: Kattavat testausstrategiat mukautetuille kuljetuksille
    - Yksikkötestaus testidoubleilla ja mockauskehyksillä
    - Integraatiotestaus Azure Test Containers -työkaluilla
    - Suorituskyky- ja kuormitustestauksen huomioiminen

#### Kontekstin suunnittelu (05-AdvancedTopics/mcp-contextengineering/) - Nouseva tekoälyn ala
- **README.md**: Kattava tutkimus kontekstin suunnittelusta nousevana alana
  - **Keskeiset periaatteet**: Täydellinen kontekstin jakaminen, toiminnan päätöksentekotietoisuus ja kontekstin ikkunan hallinta
  - **MCP-protokollan yhteensopivuus**: Kuinka MCP:n suunnittelu vastaa kontekstin suunnittelun haasteisiin
    - Kontekstin ikkunan rajoitukset ja progressiiviset latausstrategiat
    - Relevanssin määrittäminen ja dynaaminen kontekstin haku
    - Monimuotoinen kontekstin käsittely ja turvallisuushuomiot
  - **Toteutustavat**: Yksisäikeiset vs. monitoimija-arkkitehtuurit
    - Kontekstin pilkkominen ja priorisointitekniikat
    - Progressiivinen kontekstin lataus ja pakkausstrategiat
    - Kerrostetut kontekstimenetelmät ja hakujen optimointi
  - **Mittauskehys**: Nousevat mittarit kontekstin tehokkuuden arviointiin
    - Syötteen tehokkuus, suorituskyky, laatu ja käyttäjäkokemuksen huomioiminen
    - Kokeelliset lähestymistavat kontekstin optimointiin
    - Virheanalyysi ja parannusmenetelmät

#### Opetussuunnitelman navigointipäivitykset (README.md)
- **Parannettu moduulirakenne**: Päivitetty opetussuunnitelman taulukko sisältämään uudet edistyneet aiheet
  - Lisätty Kontekstin suunnittelu (5.14) ja Mukautetut kuljetukset (5.15) -kohdat
  - Johdonmukainen muotoilu ja navigointilinkit kaikissa moduuleissa
  - Päivitetyt kuvaukset heijastamaan nykyistä sisältöä

### Hakemistorakenteen parannukset
- **Nimeämisen standardointi**: Uudelleennimetty "mcp transport" muotoon "mcp-transport" johdonmukaisuuden vuoksi muiden edistyneiden aiheiden kansioiden kanssa
- **Sisällön organisointi**: Kaikki 05-AdvancedTopics-kansiot noudattavat nyt johdonmukaista nimeämismallia (mcp-[aihe])

### Dokumentaation laadun parannukset
- **MCP-määrittelyn yhteensopivuus**: Kaikki uusi sisältö viittaa nykyiseen MCP-määrittelyyn 2025-06-18
- **Monikieliset esimerkit**: Kattavat koodiesimerkit C#:llä, TypeScriptillä ja Pythonilla
- **Yrityskeskeisyys**: Tuotantovalmiit mallit ja Azure-pilvi-integraatio koko sisällössä
- **Visuaalinen dokumentaatio**: Mermaid-kaaviot arkkitehtuurin ja prosessien visualisointiin

## 18. elokuuta 2025

### Dokumentaation kattava päivitys - MCP 2025-06-18 -standardit

#### MCP:n turvallisuuden parhaat käytännöt (02-Security/) - Täydellinen modernisointi
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Täydellinen uudelleenkirjoitus MCP-määrittelyn 2025-06-18 mukaisesti
  - **Pakolliset vaatimukset**: Lisätty selkeät MUST/MUST NOT -vaatimukset virallisesta määrittelystä visuaalisilla indikaattoreilla
  - **12 keskeistä turvallisuuskäytäntöä**: Järjestetty uudelleen 15 kohdan listasta kattaviin turvallisuusalueisiin
    - Token-turvallisuus ja todennus ulkoisen identiteettipalveluntarjoajan integraatiolla
    - Istunnon hallinta ja kuljetusturvallisuus kryptografisilla vaatimuksilla
    - Tekoälyyn liittyvä uhkien torjunta Microsoft Prompt Shields -integraatiolla
    - Pääsynhallinta ja käyttöoikeudet vähimmäisoikeusperiaatteella
    - Sisällön turvallisuus ja valvonta Azure Content Safety -integraatiolla
    - Toimitusketjun turvallisuus kattavalla komponenttien tarkistuksella
    - OAuth-turvallisuus ja Confused Deputy -hyökkäysten estäminen PKCE-toteutuksella
    - Tapahtumien hallinta ja palautuminen automatisoiduilla ominaisuuksilla
    - Säädösten noudattaminen ja hallinto sääntelyyn mukautumisella
    - Edistyneet turvallisuuskontrollit nollaluottamusarkkitehtuurilla
    - Microsoftin turvallisuusekosysteemin integraatio kattavilla ratkaisuilla
    - Jatkuva turvallisuuden kehitys mukautuvilla käytännöillä
  - **Microsoftin turvallisuusratkaisut**: Parannettu integraatio-ohjeistus Prompt Shieldsille, Azure Content Safetylle, Entra ID:lle ja GitHub Advanced Securitylle
  - **Toteutusresurssit**: Kategorisoitu kattavat resurssilinkit virallisen MCP-dokumentaation, Microsoftin turvallisuusratkaisujen, turvallisuusstandardien ja toteutusoppaiden mukaan

#### Edistyneet turvallisuuskontrollit (02-Security/) - Yritystason toteutus
- **MCP-SECURITY-CONTROLS-2025.md**: Täydellinen uudistus yritystason turvallisuuskehyksellä
  - **9 kattavaa turvallisuusaluetta**: Laajennettu peruskontrolleista yksityiskohtaiseen yrityskehykseen
    - Edistynyt todennus ja valtuutus Microsoft Entra ID -integraatiolla
    - Token-turvallisuus ja anti-passthrough-kontrollit kattavalla validoinnilla
    - Istunnon turvallisuuskontrollit kaappauksen estämiseksi
    - Tekoälyyn liittyvät turvallisuuskontrollit prompt-injektion ja työkalumyrkytyksen estämiseksi
    - Confused Deputy -hyökkäysten estäminen OAuth-välityspalvelimen turvallisuudella
    - Työkalujen suorittamisen turvallisuus hiekkalaatikko- ja eristysmenetelmillä
    - Toimitusketjun turvallisuuskontrollit riippuvuuksien tarkistuksella
    - Valvonta- ja havainnointikontrollit SIEM-integraatiolla
    - Tapahtumien hallinta ja palautuminen automatisoiduilla ominaisuuksilla
  - **Toteutusesimerkit**: Lisätty yksityiskohtaisia YAML-konfiguraatiolohkoja ja koodiesimerkkejä
  - **Microsoftin ratkaisujen integraatio**: Kattava Azure-turvallisuuspalveluiden, GitHub Advanced Securityn ja yrityksen identiteetinhallinnan käsittely

#### Edistyneet aiheet turvallisuus (05-AdvancedTopics/mcp-security/) - Tuotantovalmiit toteutukset
- **README.md**: Täydellinen uudelleenkirjoitus yritystason turvallisuustoteutuksille
  - **Nykyisen määrittelyn yhteensopivuus**: Päivitetty MCP-määrittelyyn 2025-06-18 pakollisilla turvallisuusvaatimuksilla
  - **Parannettu todennus**: Microsoft Entra ID -integraatio kattavilla .NET- ja Java Spring Security -esimerkeillä
  - **Tekoälyn turvallisuusintegraatio**: Microsoft Prompt Shields ja Azure Content Safety -toteutus yksityiskohtaisilla Python-esimerkeillä
  - **Edistyneet uhkien torjuntamenetelmät**: Kattavat toteutusesimerkit
    - Confused Deputy -hyökkäysten estäminen PKCE:llä ja käyttäjän suostumuksen validoinnilla
    - Token-passthrough-haavoittuvuuksien estäminen yleisön validoinnilla ja turvallisella token-hallinnalla
    - Istunnon kaappauksen estäminen kryptografisella sidonnalla ja käyttäytymisanalyysillä
  - **Yritystason turvallisuusintegraatio**: Azure Application Insights -valvonta, uhkien havainnointiputket ja toimitusketjun turvallisuus
  - **Toteutuschecklist**: Selkeät pakolliset vs. suositellut turvallisuuskontrollit Microsoftin turvallisuusekosysteemin hyödyillä

### Dokumentaation laatu ja standardien yhteensopivuus
- **Määrittelyviittaukset**: Päivitetty kaikki viittaukset nykyiseen MCP-määrittelyyn 2025-06-18
- **Microsoftin turvallisuusekosysteemi**: Parannettu integraatio-ohjeistus koko turvallisuusdokumentaatiossa
- **Käytännön toteutus**: Lisätty yksityiskohtaisia koodiesimerkkejä .NET-, Java- ja Python-kielillä yritysmalleilla
- **Resurssien organisointi**: Kattava virallisen dokumentaation, turvallisuusstandardien ja toteutusoppaiden kategorisointi
- **Visuaaliset indikaattorit**: Selkeä merkintä pakollisista vaatimuksista vs. suositelluista käytännöistä

## 16. heinäkuuta 2025

### README ja navigointiparannukset
- README.md:n opetussuunnitelman navigointi täysin uudistettu
- Korvattu `<details>`-tagit saavutettavammalla taulukkomuotoisella rakenteella
- Luotu vaihtoehtoisia asetteluvaihtoehtoja uuteen "alternative_layouts" -kansioon
- Lisätty korttipohjaisia, välilehtityylisiä ja haitarityylisiä navigointiesimerkkejä
- Päivitetty hakemistorakenteen osio sisältämään kaikki uusimmat tiedostot
- Parannettu "Kuinka käyttää tätä opetussuunnitelmaa" -osio selkeillä suosituksilla
- Päivitetty MCP-määrittelylinkit osoittamaan oikeisiin URL-osoitteisiin
- Lisätty Kontekstin suunnittelu -osio (5.14) opetussuunnitelman rakenteeseen

### Opasmateriaalin päivitykset
- Opasmateriaali täysin uudistettu vastaamaan nykyistä hakemistorakennetta
- Lisätty uusia osioita MCP-asiakkaista ja -työkaluista sekä suosituista MCP-palvelimista
- Päivitetty visuaalinen opetussuunnitelmakartta vastaamaan kaikkia aiheita
- Parannettu edistyneiden aiheiden kuvauksia kattamaan kaikki erikoistuneet alueet
- Päivitetty tapaustutkimusten osio vastaamaan todellisia esimerkkejä
- Lisätty tämä kattava muutosloki

### Yhteisön panokset (06-CommunityContributions/)
- Lisätty yksityiskohtaista tietoa MCP-palvelimista kuvagenerointiin
- Lisätty kattava osio Clauden käytöstä VSCode:ssa
- Lisätty Cline-päätteen asiakasohjelman asennus- ja käyttöohjeet
- Päivitetty MCP-asiakasosio sisältämään kaikki suositut asiakasvaihtoehdot
- Parannettu esimerkkikoodia tarkemmilla näytteillä

### Edistyneet aiheet (05-AdvancedTopics/)
- Järjestetty kaikki erikoistuneet aihehakemistot johdonmukaisella nimeämisellä
- Lisätty kontekstin suunnittelumateriaaleja ja esimerkkejä
- Lisätty Foundry-agentin integraatiodokumentaatio
- Parannettu Entra ID -turvallisuusintegraatiodokumentaatio

## 11. kesäkuuta 2025

### Alkuperäinen luominen
- Julkaistu ensimmäinen versio MCP for Beginners -opetussuunnitelmasta
- Luotu perusrakenne kaikille 10 pääosalle
- Toteutettu visuaalinen opetussuunnitelmakartta navigointia varten
- Lisätty alkuperäiset esimerkkiprojektit useilla ohjelmointikielillä

### Aloittaminen (03-GettingStarted/)
- Luotu ensimmäiset palvelintoteutusesimerkit
- Lisätty asiakasohjelman kehitysopas
- Sisällytetty LLM-asiakasintegraatio-ohjeet
- Lisätty VS Code -integraatiodokumentaatio
- Toteutettu Server-Sent Events (SSE) -palvelinesimerkit

### Keskeiset käsitteet (01-CoreConcepts/)
- Lisätty yksityiskohtainen selitys asiakas-palvelin-arkkitehtuurista
- Luotu dokumentaatio keskeisistä protokollakomponenteista
- Dokumentoitu viestintämallit MCP:ssä

## 23. toukokuuta 2025

### Hakemistorakenne
- Alustettu hakemisto perusrakenteella
- Luotu README-tiedostot jokaiselle pääosalle
- Asetettu käännösinfrastruktuuri
- Lisätty kuvatiedostot ja kaaviot

### Dokumentaatio
- Luotu alkuperäinen README.md opetussuunnitelman yleiskatsauksella
- Lisätty CODE_OF_CONDUCT.md ja SECURITY.md
- Asetettu SUPPORT.md ohjeilla avun saamiseen
- Luotu alustava opasmateriaalin rakenne

## 15. huhtikuuta 2025

### Suunnittelu ja kehys
- MCP for Beginners -opetussuunnitelman alkuperäinen suunnittelu
- Määritelty oppimistavoitteet ja kohdeyleisö
- Luotu 10-osainen rakenne opetussuunnitelmalle
- Kehitetty käsitteellinen kehys esimerkeille ja tapaustutkimuksille
- Luotu alkuperäiset prototyyppiesimerkit keskeisistä käsitteistä

---

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäisellä kielellä tulisi pitää ensisijaisena lähteenä. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.