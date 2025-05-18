<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:37:18+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "fi"
}
-->
# Tietoturvan parhaat käytännöt

Model Context Protocolin (MCP) omaksuminen tuo uusia voimakkaita ominaisuuksia tekoälypohjaisiin sovelluksiin, mutta myös ainutlaatuisia tietoturvaongelmia, jotka ulottuvat perinteisten ohjelmistoriskien ulkopuolelle. Vakiintuneiden huolenaiheiden, kuten turvallisen koodauksen, vähimmäisoikeuksien ja toimitusketjun turvallisuuden lisäksi MCP ja tekoälytyökuormat kohtaavat uusia uhkia, kuten kehotteinjektioita, työkalujen saastumista ja dynaamista työkalujen muokkausta. Nämä riskit voivat johtaa tietojen luvattomaan siirtoon, yksityisyyden loukkauksiin ja ei-toivottuun järjestelmän käyttäytymiseen, jos niitä ei hallita oikein.

Tässä oppitunnissa tarkastellaan MCP:hen liittyviä merkittävimpiä tietoturvariskejä, mukaan lukien todennus, valtuutus, liialliset käyttöoikeudet, epäsuora kehotteinjektio ja toimitusketjun haavoittuvuudet, ja tarjotaan käytännön hallintakeinoja ja parhaita käytäntöjä niiden lieventämiseksi. Opit myös hyödyntämään Microsoftin ratkaisuja, kuten Prompt Shields, Azure Content Safety ja GitHub Advanced Security, vahvistaaksesi MCP:n toteutusta. Ymmärtämällä ja soveltamalla näitä hallintakeinoja voit merkittävästi vähentää tietoturvaloukkauksen todennäköisyyttä ja varmistaa, että tekoälyjärjestelmäsi pysyvät vahvoina ja luotettavina.

# Oppimistavoitteet

Tämän oppitunnin lopussa pystyt:

- Tunnistamaan ja selittämään Model Context Protocolin (MCP) aiheuttamat ainutlaatuiset tietoturvariskit, mukaan lukien kehotteinjektio, työkalujen saastuminen, liialliset käyttöoikeudet ja toimitusketjun haavoittuvuudet.
- Kuvailemaan ja soveltamaan tehokkaita hallintakeinoja MCP:n tietoturvariskeihin, kuten vahva todennus, vähimmäisoikeudet, turvallinen tunnusten hallinta ja toimitusketjun varmistus.
- Ymmärtämään ja hyödyntämään Microsoftin ratkaisuja, kuten Prompt Shields, Azure Content Safety ja GitHub Advanced Security, MCP:n ja tekoälytyökuormien suojaamiseen.
- Tunnistamaan työkalujen metatietojen validoinnin, dynaamisten muutosten seurannan ja epäsuorien kehotteinjektiohyökkäysten torjumisen merkityksen.
- Integroimaan vakiintuneet tietoturvan parhaat käytännöt, kuten turvallinen koodaus, palvelimen koventaminen ja nollaluottamusarkkitehtuuri, MCP:n toteutukseen vähentääksesi tietoturvaloukkausten todennäköisyyttä ja vaikutusta.

# MCP:n tietoturvan hallintakeinot

Mikä tahansa järjestelmä, jolla on pääsy tärkeisiin resursseihin, kohtaa implisiittisiä tietoturvahaasteita. Yleisesti ottaen tietoturvahaasteet voidaan ratkaista soveltamalla oikein perustavanlaatuisia tietoturvan hallintakeinoja ja käsitteitä. Koska MCP on vasta äskettäin määritelty, sen määrittely muuttuu hyvin nopeasti protokollan kehittyessä. Lopulta sen sisäiset tietoturvan hallintakeinot kypsyvät, mikä mahdollistaa paremman integroinnin yritysten ja vakiintuneiden tietoturva-arkkitehtuurien ja -käytäntöjen kanssa.

Microsoft Digital Defense Reportissa julkaistu tutkimus toteaa, että 98 % raportoituista tietomurroista voitaisiin estää vankalla tietoturvahygienialla ja paras suojaus kaikenlaisia tietomurtoja vastaan on saada perus tietoturvahygienia, turvallisen koodauksen parhaat käytännöt ja toimitusketjun turvallisuus kuntoon - ne koetellut käytännöt, joista tiedämme, että ne vähentävät tietoturvariskejä merkittävimmin.

Katsotaanpa joitakin tapoja, joilla voit alkaa käsitellä tietoturvariskejä MCP:n käyttöönotossa.

# MCP-palvelimen todennus (jos MCP-toteutuksesi oli ennen 26. huhtikuuta 2025)

> **Huom:** Seuraavat tiedot ovat oikeita 26. huhtikuuta 2025. MCP-protokolla kehittyy jatkuvasti, ja tulevat toteutukset voivat tuoda mukanaan uusia todennusmalleja ja hallintakeinoja. Saat uusimmat päivitykset ja ohjeet aina viittaamalla [MCP Specification](https://spec.modelcontextprotocol.io/) ja viralliseen [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Ongelman kuvaus
Alkuperäinen MCP-määrittely oletti, että kehittäjät kirjoittavat oman todennuspalvelimensa. Tämä vaati tietämystä OAuthista ja siihen liittyvistä tietoturvarajoituksista. MCP-palvelimet toimivat OAuth 2.0 -valtuutuspalvelimina, jotka hallitsivat vaadittua käyttäjän todennusta suoraan sen sijaan, että olisivat delegoineet sen ulkoiselle palvelulle, kuten Microsoft Entra ID:lle. 26. huhtikuuta 2025 lähtien MCP-määrittelyn päivitys mahdollistaa MCP-palvelinten delegoida käyttäjän todennuksen ulkoiselle palvelulle.

### Riskit
- Väärin määritelty valtuutuslogiikka MCP-palvelimessa voi johtaa arkaluontoisten tietojen paljastumiseen ja virheellisesti sovellettuihin käyttöoikeuksiin.
- OAuth-tunnuksen varkaus paikallisella MCP-palvelimella. Jos tunnus varastetaan, sitä voidaan käyttää MCP-palvelimen esittämiseen ja pääsyyn resursseihin ja tietoihin, joihin OAuth-tunnus oikeuttaa.

### Hallintakeinot
- **Tarkista ja vahvista valtuutuslogiikka:** Tarkasta huolellisesti MCP-palvelimen valtuutuksen toteutus varmistaaksesi, että vain tarkoitetut käyttäjät ja asiakkaat voivat käyttää arkaluontoisia resursseja. Käytännön ohjeita varten katso [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) ja [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Pakota turvalliset tunnuskäytännöt:** Seuraa [Microsoftin parhaita käytäntöjä tunnuksen validoinnille ja eliniälle](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) estääksesi pääsytunnusten väärinkäytön ja vähentääksesi tunnuksen uudelleenkäytön tai varkauden riskiä.
- **Suojaa tunnuksen tallennus:** Säilytä tunnuksia aina turvallisesti ja käytä salausta suojataksesi niitä levossa ja siirrossa. Toteutusvinkkejä varten katso [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Liialliset käyttöoikeudet MCP-palvelimille

### Ongelman kuvaus
MCP-palvelimille on voitu myöntää liialliset käyttöoikeudet palveluun/resurssiin, jota ne käyttävät. Esimerkiksi MCP-palvelin, joka on osa tekoälymyyntisovellusta, joka yhdistää yrityksen tietovarastoon, pitäisi olla rajoitettu pääsy myyntitietoihin eikä sen pitäisi saada käyttää kaikkia tiedostoja varastossa. Viitaten takaisin vähimmäisoikeusperiaatteeseen (yksi vanhimmista tietoturvaperiaatteista), millään resurssilla ei pitäisi olla enempää käyttöoikeuksia kuin mitä sen tehtävien suorittaminen edellyttää. Tekoäly aiheuttaa lisääntyneen haasteen tällä alueella, koska sen mahdollistaminen joustavaksi voi olla haastavaa määritellä tarkat tarvittavat käyttöoikeudet.

### Riskit 
- Liiallisten käyttöoikeuksien myöntäminen voi mahdollistaa tietojen luvattoman siirron tai muokkaamisen, joita MCP-palvelimen ei ollut tarkoitus voida käyttää. Tämä voisi olla myös yksityisyyden suojaongelma, jos tiedot ovat henkilötietoja (PII).

### Hallintakeinot
- **Sovella vähimmäisoikeusperiaatetta:** Myönnä MCP-palvelimelle vain vähimmäisoikeudet, jotka ovat tarpeen sen tehtävien suorittamiseksi. Tarkista ja päivitä nämä käyttöoikeudet säännöllisesti varmistaaksesi, että ne eivät ylitä tarvittavaa. Tarkempia ohjeita varten katso [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Käytä roolipohjaista pääsynhallintaa (RBAC):** Määritä MCP-palvelimelle rooleja, jotka on tiukasti rajattu tiettyihin resursseihin ja toimiin, välttäen laajoja tai tarpeettomia käyttöoikeuksia.
- **Seuraa ja tarkasta käyttöoikeudet:** Seuraa jatkuvasti käyttöoikeuksien käyttöä ja tarkasta pääsylokit havaitaksesi ja korjataksesi liialliset tai käyttämättömät käyttöoikeudet nopeasti.

# Epäsuorat kehotteinjektiohyökkäykset

### Ongelman kuvaus

Vahingolliset tai vaarantuneet MCP-palvelimet voivat aiheuttaa merkittäviä riskejä paljastamalla asiakastietoja tai mahdollistamalla ei-toivottuja toimia. Nämä riskit ovat erityisen merkityksellisiä tekoäly- ja MCP-pohjaisissa työkuormissa, joissa:

- **Kehotteinjektiohyökkäykset**: Hyökkääjät upottavat haitallisia ohjeita kehotteisiin tai ulkoiseen sisältöön, aiheuttaen tekoälyjärjestelmän suorittamaan ei-toivottuja toimia tai vuotamaan arkaluonteisia tietoja. Lue lisää: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Työkalujen saastuminen**: Hyökkääjät manipuloivat työkalujen metatietoja (kuten kuvauksia tai parametreja) vaikuttaakseen tekoälyn käyttäytymiseen, mahdollisesti ohittaen tietoturvakontrollit tai vuotaen tietoja. Yksityiskohdat: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Rajat ylittävä kehotteinjektio**: Vahingollisia ohjeita upotetaan asiakirjoihin, verkkosivuille tai sähköposteihin, jotka tekoäly sitten käsittelee, mikä johtaa tietovuotoihin tai manipulointiin.
- **Dynaaminen työkalujen muokkaus (Rug Pulls)**: Työkalujen määritelmät voidaan muuttaa käyttäjän hyväksynnän jälkeen, mikä tuo uusia haitallisia käyttäytymismalleja ilman käyttäjän tietoisuutta.

Nämä haavoittuvuudet korostavat vahvan validoinnin, seurannan ja tietoturvakontrollien tarvetta, kun integroit MCP-palvelimia ja työkaluja ympäristöösi. Syvällisempi tarkastelu, katso yllä linkitetyt viitteet.

**Epäsuora kehotteinjektio** (tunnetaan myös nimellä rajat ylittävä kehotteinjektio tai XPIA) on kriittinen haavoittuvuus generatiivisissa tekoälyjärjestelmissä, mukaan lukien ne, jotka käyttävät Model Context Protocolia (MCP). Tässä hyökkäyksessä haitalliset ohjeet piilotetaan ulkoiseen sisältöön, kuten asiakirjoihin, verkkosivuille tai sähköposteihin. Kun tekoälyjärjestelmä käsittelee tätä sisältöä, se saattaa tulkita upotetut ohjeet laillisiksi käyttäjäkäskyiksi, mikä johtaa ei-toivottuihin toimiin, kuten tietovuotoihin, haitallisen sisällön tuottamiseen tai käyttäjävuorovaikutusten manipulointiin. Yksityiskohtainen selitys ja tosielämän esimerkkejä löytyy [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Erityisen vaarallinen muoto tästä hyökkäyksestä on **Työkalujen saastuminen**. Tässä hyökkääjät injektoivat haitallisia ohjeita MCP-työkalujen metatietoihin (kuten työkalun kuvauksiin tai parametreihin). Koska suuret kielimallit (LLM:t) luottavat näihin metatietoihin päättääkseen, mitä työkaluja kutsua, vaarantuneet kuvaukset voivat huijata mallin suorittamaan luvattomia työkalukutsuja tai ohittamaan tietoturvakontrollit. Nämä manipulaatiot ovat usein näkymättömiä loppukäyttäjille, mutta tekoälyjärjestelmä voi tulkita ja toimia niiden perusteella. Tämä riski kasvaa isännöidyissä MCP-palvelinympäristöissä, joissa työkalujen määritelmät voidaan päivittää käyttäjän hyväksynnän jälkeen - tilanne, jota joskus kutsutaan "[rug pulliksi](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Tällaisissa tapauksissa työkalu, joka aiemmin oli turvallinen, voidaan myöhemmin muuttaa suorittamaan haitallisia toimia, kuten tietojen vuotamista tai järjestelmän käyttäytymisen muuttamista, ilman käyttäjän tietoa. Lisätietoja tästä hyökkäysvektorista löytyy [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

## Riskit
Tarkoituksettomat tekoälytoimet aiheuttavat erilaisia tietoturvariskejä, jotka sisältävät tietojen luvattoman siirron ja yksityisyyden loukkaukset.

### Hallintakeinot
### Kehotteen suojien käyttäminen epäsuoria kehotteinjektiohyökkäyksiä vastaan
-----------------------------------------------------------------------------

**AI Prompt Shields** ovat Microsoftin kehittämä ratkaisu sekä suoria että epäsuoria kehotteinjektiohyökkäyksiä vastaan. Ne auttavat seuraavilla tavoilla:

1.  **Havaitseminen ja suodatus**: Prompt Shields käyttää kehittyneitä koneoppimisalgoritmeja ja luonnollisen kielen käsittelyä havaitakseen ja suodattaakseen ulkoiseen sisältöön upotetut haitalliset ohjeet, kuten asiakirjoihin, verkkosivuille tai sähköposteihin.
    
2.  **Spotlighting**: Tämä tekniikka auttaa tekoälyjärjestelmää erottamaan kelvolliset järjestelmäohjeet ja mahdollisesti epäluotettavat ulkoiset syötteet. Muuntamalla syötetyn tekstin mallille merkityksellisemmäksi Spotlighting varmistaa, että tekoäly voi paremmin tunnistaa ja jättää huomiotta haitalliset ohjeet.
    
3.  **Erotinmerkit ja datamerkinnät**: Järjestelmäviestiin sisällytetyt erotinmerkit määrittelevät syötetyn tekstin sijainnin, mikä auttaa tekoälyjärjestelmää tunnistamaan ja erottamaan käyttäjän syötteet mahdollisesti haitallisesta ulkoisesta sisällöstä. Datamerkinnät laajentavat tätä käsitettä käyttämällä erityisiä merkkejä korostamaan luotettujen ja epäluotettujen tietojen rajoja.
    
4.  **Jatkuva seuranta ja päivitykset**: Microsoft seuraa ja päivittää Prompt Shieldsejä jatkuvasti uusien ja kehittyvien uhkien varalta. Tämä ennakoiva lähestymistapa varmistaa, että suojaukset pysyvät tehokkaina uusimpia hyökkäystekniikoita vastaan.
    
5. **Integrointi Azure Content Safetyyn:** Prompt Shields on osa laajempaa Azure AI Content Safety -kokonaisuutta, joka tarjoaa lisätyökaluja vankilapakoyritysten, haitallisen sisällön ja muiden tietoturvariskien havaitsemiseen tekoälysovelluksissa.

Voit lukea lisää AI Prompt Shieldseistä [Prompt Shields -dokumentaatiosta](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

### Toimitusketjun turvallisuus

Toimitusketjun turvallisuus on edelleen keskeinen tekijä tekoälyaikana, mutta käsitys siitä, mitä toimitusketjuusi kuuluu, on laajentunut. Perinteisten koodipakettien lisäksi sinun on nyt tarkasti tarkistettava ja valvottava kaikkia tekoälyyn liittyviä komponentteja, mukaan lukien perustamallit, upotetut palvelut, kontekstintarjoajat ja kolmannen osapuolen rajapinnat. Kukin näistä voi tuoda mukanaan haavoittuvuuksia tai riskejä, jos niitä ei hallita asianmukaisesti.

**Keskeiset toimitusketjun tietoturvakäytännöt tekoälylle ja MCP:lle:**
- **Varmista kaikki komponentit ennen integrointia
- [OWASP Top 10 LLM:ille](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Microsoftin matka ohjelmistojen toimitusketjun turvaamiseen](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Vähiten etuoikeutetun pääsyn turvaaminen (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Parhaat käytännöt tunnusten validointiin ja elinikään](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Käytä turvallista tunnusten säilytystä ja salaa tunnukset (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management MCP:n todennusporttina](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra ID:n käyttäminen MCP-palvelimien todennukseen](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Seuraavaksi

Seuraavaksi: [Luku 3: Aloittaminen](/03-GettingStarted/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta otathan huomioon, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää ensisijaisena lähteenä. Tärkeää tietoa varten suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinkäsityksistä tai virhetulkinnoista.