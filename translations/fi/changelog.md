<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T15:55:35+00:00",
  "source_file": "changelog.md",
  "language_code": "fi"
}
-->
# Muutosloki: MCP for Beginners -opetussuunnitelma

Tämä dokumentti toimii merkittävien muutosten kirjana Model Context Protocol (MCP) for Beginners -opetussuunnitelmassa. Muutokset on dokumentoitu käänteisessä aikajärjestyksessä (uusimmat muutokset ensin).

## 18. elokuuta 2025

### Dokumentaation kattava päivitys - MCP 2025-06-18 -standardit

#### MCP:n turvallisuuskäytännöt (02-Security/) - Täydellinen modernisointi
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Täydellinen uudelleenkirjoitus MCP Specification 2025-06-18 -standardin mukaisesti
  - **Pakolliset vaatimukset**: Lisätty selkeät MUST/MUST NOT -vaatimukset virallisesta spesifikaatiosta visuaalisilla indikaattoreilla
  - **12 keskeistä turvallisuuskäytäntöä**: Jäsennelty 15 kohdan listasta kattaviin turvallisuusalueisiin
    - Token-turvallisuus ja autentikointi ulkoisen identiteettipalvelun integroinnilla
    - Istunnon hallinta ja kuljetusturvallisuus kryptografisilla vaatimuksilla
    - AI-spesifinen uhkien torjunta Microsoft Prompt Shields -integraatiolla
    - Käyttöoikeuksien hallinta vähimmän oikeuden periaatteella
    - Sisällön turvallisuus ja valvonta Azure Content Safety -integraatiolla
    - Toimitusketjun turvallisuus kattavalla komponenttien tarkistuksella
    - OAuth-turvallisuus ja Confused Deputy -hyökkäysten estäminen PKCE-toteutuksella
    - Tapahtumien hallinta ja palautuminen automatisoiduilla ominaisuuksilla
    - Säädöstenmukaisuus ja hallinto sääntelyyn mukautumisella
    - Kehittyneet turvallisuuskontrollit nollaluottamusarkkitehtuurilla
    - Microsoftin turvallisuusekosysteemin integrointi kattavilla ratkaisuilla
    - Jatkuva turvallisuuden kehitys mukautuvilla käytännöillä
  - **Microsoftin turvallisuusratkaisut**: Parannettu integraatio-ohje Prompt Shieldsille, Azure Content Safetylle, Entra ID:lle ja GitHub Advanced Securitylle
  - **Toteutusresurssit**: Kategorisoitu kattavat resurssilinkit virallisen MCP-dokumentaation, Microsoftin turvallisuusratkaisujen, turvallisuusstandardien ja toteutusoppaiden mukaan

#### Kehittyneet turvallisuuskontrollit (02-Security/) - Yritystason toteutus
- **MCP-SECURITY-CONTROLS-2025.md**: Täydellinen uudistus yritystason turvallisuuskehykseen
  - **9 kattavaa turvallisuusaluetta**: Laajennettu peruskontrolleista yksityiskohtaiseen yrityskehykseen
    - Kehittynyt autentikointi ja valtuutus Microsoft Entra ID -integraatiolla
    - Token-turvallisuus ja anti-passthrough-kontrollit kattavalla validoinnilla
    - Istunnon turvallisuuskontrollit kaappauksen estämiseksi
    - AI-spesifiset turvallisuuskontrollit prompt-injektion ja työkalumyrkytyksen estämiseksi
    - Confused Deputy -hyökkäysten estäminen OAuth-välityspalvelimen turvallisuudella
    - Työkalujen suorittamisen turvallisuus sandboxingilla ja eristämisellä
    - Toimitusketjun turvallisuuskontrollit riippuvuuksien tarkistuksella
    - Valvonta- ja havaitsemiskontrollit SIEM-integraatiolla
    - Tapahtumien hallinta ja palautuminen automatisoiduilla ominaisuuksilla
  - **Toteutusesimerkit**: Lisätty yksityiskohtaisia YAML-konfiguraatiolohkoja ja koodiesimerkkejä
  - **Microsoftin ratkaisujen integrointi**: Kattava Azure-turvallisuuspalveluiden, GitHub Advanced Securityn ja yritysidentiteetin hallinnan kattavuus

#### Kehittyneet turvallisuusteemat (05-AdvancedTopics/mcp-security/) - Tuotantovalmiit toteutukset
- **README.md**: Täydellinen uudistus yritystason turvallisuustoteutuksille
  - **Nykyisen spesifikaation mukautus**: Päivitetty MCP Specification 2025-06-18 -standardin mukaiseksi pakollisilla turvallisuusvaatimuksilla
  - **Parannettu autentikointi**: Microsoft Entra ID -integraatio kattavilla .NET- ja Java Spring Security -esimerkeillä
  - **AI-turvallisuuden integrointi**: Microsoft Prompt Shields ja Azure Content Safety -toteutus yksityiskohtaisilla Python-esimerkeillä
  - **Kehittynyt uhkien torjunta**: Kattavat toteutusesimerkit
    - Confused Deputy -hyökkäysten estäminen PKCE:llä ja käyttäjän suostumuksen validoinnilla
    - Token-passthrough-ongelmien estäminen yleisön validoinnilla ja turvallisella token-hallinnalla
    - Istunnon kaappauksen estäminen kryptografisella sidonnalla ja käyttäytymisanalyysillä
  - **Yritystason turvallisuuden integrointi**: Azure Application Insights -valvonta, uhkien havaitsemisputket ja toimitusketjun turvallisuus
  - **Toteutuschecklist**: Selkeät pakolliset vs. suositellut turvallisuuskontrollit Microsoftin turvallisuusekosysteemin hyödyillä

### Dokumentaation laatu ja standardien mukautus
- **Spesifikaatioviittaukset**: Päivitetty kaikki viittaukset nykyiseen MCP Specification 2025-06-18 -standardiin
- **Microsoftin turvallisuusekosysteemi**: Parannettu integraatio-ohje kaikessa turvallisuusdokumentaatiossa
- **Käytännön toteutus**: Lisätty yksityiskohtaisia koodiesimerkkejä .NET-, Java- ja Python-kielillä yrityskäytännöillä
- **Resurssien organisointi**: Kategorisoitu kattavat virallisen dokumentaation, turvallisuusstandardien ja toteutusoppaiden resurssilinkit
- **Visuaaliset indikaattorit**: Selkeä merkintä pakollisista vaatimuksista vs. suositelluista käytännöistä

#### Peruskäsitteet (01-CoreConcepts/) - Täydellinen modernisointi
- **Protokollan version päivitys**: Päivitetty viittaamaan nykyiseen MCP Specification 2025-06-18 -standardiin päivämääräpohjaisella versionumeroinnilla (YYYY-MM-DD-muoto)
- **Arkkitehtuurin tarkennus**: Parannettu isäntien, asiakkaiden ja palvelimien kuvauksia nykyisten MCP-arkkitehtuurimallien mukaisesti
  - Isännät määritelty selkeästi AI-sovelluksiksi, jotka koordinoivat useita MCP-asiakasliitäntöjä
  - Asiakkaat kuvattu protokollaliitäntöinä, jotka ylläpitävät yksi-yhteen-suhteita palvelimiin
  - Palvelimet parannettu paikallisten vs. etäasennusten skenaarioilla
- **Primitivien uudelleenjärjestely**: Täydellinen palvelin- ja asiakasprimitivien uudistus
  - Palvelinprimitivit: Resurssit (datapisteet), Promptit (mallit), Työkalut (suoritettavat funktiot) yksityiskohtaisilla selityksillä ja esimerkeillä
  - Asiakasprimitivit: Näytteenotto (LLM-täydennykset), Elicitointi (käyttäjän syöte), Lokitus (debuggaus/valvonta)
  - Päivitetty nykyisillä löytö- (`*/list`), hakemis- (`*/get`) ja suoritus- (`*/call`) menetelmämalleilla
- **Protokolla-arkkitehtuuri**: Esitelty kaksikerroksinen arkkitehtuurimalli
  - Datakerros: JSON-RPC 2.0 -perusta elinkaaren hallinnalla ja primitiiveillä
  - Kuljetuskerros: STDIO (paikallinen) ja Streamable HTTP SSE:llä (etäkuljetusmekanismit)
- **Turvallisuuskehys**: Kattavat turvallisuusperiaatteet, mukaan lukien eksplisiittinen käyttäjän suostumus, tietosuojan suojaus, työkalujen suorittamisen turvallisuus ja kuljetuskerroksen turvallisuus
- **Kommunikaatiomallit**: Päivitetty protokollaviestit näyttämään alustuksen, löytämisen, suorittamisen ja ilmoitusvirrat
- **Koodiesimerkit**: Päivitetty monikieliset esimerkit (.NET, Java, Python, JavaScript) nykyisten MCP SDK -mallien mukaisiksi

#### Turvallisuus (02-Security/) - Kattava turvallisuuden uudistus  
- **Standardien mukautus**: Täysi mukautus MCP Specification 2025-06-18 -turvallisuusvaatimuksiin
- **Autentikoinnin kehitys**: Dokumentoitu kehitys mukautetuista OAuth-palvelimista ulkoisen identiteettipalvelun delegointiin (Microsoft Entra ID)
- **AI-spesifinen uhka-analyysi**: Parannettu kattavuus modernien AI-hyökkäysvektorien osalta
  - Yksityiskohtaiset prompt-injektion hyökkäysskenaariot tosielämän esimerkeillä
  - Työkalumyrkytysmekanismit ja "rug pull" -hyökkäysmallit
  - Kontekstin ikkunan myrkytys ja mallin sekaannushyökkäykset
- **Microsoftin AI-turvallisuusratkaisut**: Kattava Microsoftin turvallisuusekosysteemin kattavuus
  - AI Prompt Shields kehittyneillä havaitsemis-, korostus- ja erottelutekniikoilla
  - Azure Content Safety -integraatiomallit
  - GitHub Advanced Security toimitusketjun suojaukseen
- **Kehittynyt uhkien torjunta**: Yksityiskohtaiset turvallisuuskontrollit
  - Istunnon kaappaus MCP-spesifisillä hyökkäysskenaarioilla ja kryptografisilla istunnon tunnistevaatimuksilla
  - Confused Deputy -ongelmat MCP-välityspalvelinskenaarioissa eksplisiittisillä suostumusvaatimuksilla
  - Token-passthrough-haavoittuvuudet pakollisilla validointikontrolleilla
- **Toimitusketjun turvallisuus**: Laajennettu AI-toimitusketjun kattavuus, mukaan lukien perustamallit, upotettujen palvelut, kontekstin tarjoajat ja kolmannen osapuolen API:t
- **Perusturvallisuus**: Parannettu integraatio yritystason turvallisuusmalleihin, mukaan lukien nollaluottamusarkkitehtuuri ja Microsoftin turvallisuusekosysteemi
- **Resurssien organisointi**: Kategorisoitu kattavat resurssilinkit tyypin mukaan (Viralliset dokumentit, standardit, tutkimus, Microsoftin ratkaisut, toteutusoppaat)

### Dokumentaation laatuparannukset
- **Rakenteelliset oppimistavoitteet**: Parannettu oppimistavoitteet konkreettisilla, toteutettavilla tuloksilla
- **Ristiviittaukset**: Lisätty linkkejä liittyvien turvallisuus- ja peruskäsitteiden aiheiden välillä
- **Ajankohtainen tieto**: Päivitetty kaikki päivämääräviittaukset ja spesifikaatiolinkit nykyisiin standardeihin
- **Toteutusohjeet**: Lisätty erityisiä, toteutettavia ohjeita molempiin osioihin

## 16. heinäkuuta 2025

### README ja navigoinnin parannukset
- Suunniteltu README.md:n navigointi kokonaan uudelleen
- Korvattu `<details>`-tagit saavutettavammalla taulukkomuotoisella rakenteella
- Luotu vaihtoehtoiset asetteluvaihtoehdot uuteen "alternative_layouts" -kansioon
- Lisätty korttipohjaisia, välilehtityylisiä ja harmonikkatyylisiä navigointiesimerkkejä
- Päivitetty hakemistorakenteen osio sisältämään kaikki uusimmat tiedostot
- Parannettu "Kuinka käyttää tätä opetussuunnitelmaa" -osio selkeillä suosituksilla
- Päivitetty MCP-spesifikaatiolinkit osoittamaan oikeisiin URL-osoitteisiin
- Lisätty Context Engineering -osio (5.14) opetussuunnitelman rakenteeseen

### Opintosuunnitelman päivitykset
- Uudistettu opintosuunnitelma vastaamaan nykyistä hakemistorakennetta
- Lisätty uusia osioita MCP-asiakkaille ja -työkaluille sekä suosituimmille MCP-palvelimille
- Päivitetty visuaalinen opetussuunnitelmakartta vastaamaan kaikkia aiheita
- Parannettu kehittyneiden aiheiden kuvauksia kattamaan kaikki erikoistuneet alueet
- Päivitetty tapaustutkimusten osio vastaamaan todellisia esimerkkejä
- Lisätty tämä kattava muutosloki

### Yhteisön panokset (06-CommunityContributions/)
- Lisätty yksityiskohtaista tietoa MCP-palvelimista kuvagenerointiin
- Lisätty kattava osio Clauden käytöstä VSCode:ssa
- Lisätty Cline-päätteen asiakasohjelman asennus- ja käyttöohjeet
- Päivitetty MCP-asiakasosio sisältämään kaikki suosituimmat asiakasvaihtoehdot
- Parannettu esimerkkipanoksia tarkemmilla koodinäytteillä

### Kehittyneet aiheet (05-AdvancedTopics/)
- Järjestetty kaikki erikoistuneet aihehakemistot johdonmukaisilla nimillä
- Lisätty kontekstin suunnittelumateriaalit ja esimerkit
- Lisätty Foundry-agentin integrointidokumentaatio
- Parannettu Entra ID -turvallisuuden integrointidokumentaatio

## 11. kesäkuuta 2025

### Alkuperäinen luominen
- Julkaistu ensimmäinen versio MCP for Beginners -opetussuunnitelmasta
- Luotu perusrakenne kaikille 10 pääosalle
- Toteutettu visuaalinen opetussuunnitelmakartta navigointia varten
- Lisätty alkuperäiset esimerkkiprojektit useilla ohjelmointikielillä

### Aloittaminen (03-GettingStarted/)
- Luotu ensimmäiset palvelimen toteutusesimerkit
- Lisätty asiakasohjelman kehitysopas
- Sisällytetty LLM-asiakasintegraatio-ohjeet
- Lisätty VS Code -integraatiodokumentaatio
- Toteutettu Server-Sent Events (SSE) -palvelinesimerkit

### Peruskäsitteet (01-CoreConcepts/)
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
- Luotu alkuperäinen README.md opetussuunnitelman yleiskatsauksella
- Lisätty CODE_OF_CONDUCT.md ja SECURITY.md
- Asetettu SUPPORT.md ohjeilla avun saamiseksi
- Luotu alustava opintosuunnitelman rakenne

## 15. huhtikuuta 2025

### Suunnittelu ja kehys
- Alustava suunnittelu MCP for Beginners -opetussuunnitelmalle
- Määritelty oppimistavoitteet ja kohdeyleisö
- Jäsennelty opetussuunnitelman 10-osainen rakenne
- Kehitetty käsitteellinen kehys esimerkeille ja tapaustutkimuksille
- Luotu alkuperäiset prototyyppiesimerkit keskeisille käsitteille

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäisellä kielellä tulisi pitää ensisijaisena lähteenä. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.