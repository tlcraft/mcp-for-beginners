<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:15:04+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "fi"
}
-->
# Security Best Practices

Model Context Protocolin (MCP) käyttöönotto tuo tekoälypohjaisiin sovelluksiin tehokkaita uusia ominaisuuksia, mutta samalla se tuo mukanaan ainutlaatuisia tietoturvahaasteita, jotka ylittävät perinteiset ohjelmistoriskit. Vakiintuneiden asioiden, kuten turvallisen koodauksen, vähimmän oikeuden periaatteen ja toimitusketjun turvallisuuden lisäksi MCP ja tekoälykuormitukset kohtaavat uusia uhkia, kuten promptin manipulointi, työkalujen myrkyttäminen ja työkalujen dynaaminen muokkaus. Näitä riskejä ei hallita oikein, ne voivat johtaa tietovuotoihin, yksityisyyden loukkauksiin ja odottamattomiin järjestelmän toimintoihin.

Tässä oppitunnissa käsitellään MCP:hen liittyviä keskeisimpiä tietoturvariskejä — kuten todennus, valtuutus, liialliset käyttöoikeudet, epäsuora promptin manipulointi ja toimitusketjun haavoittuvuudet — ja tarjotaan käytännön ohjeita ja parhaita käytäntöjä niiden hallitsemiseksi. Opit myös hyödyntämään Microsoftin ratkaisuja, kuten Prompt Shields, Azure Content Safety ja GitHub Advanced Security, vahvistaaksesi MCP:n toteutustasi. Näiden hallintakeinojen ymmärtäminen ja soveltaminen auttaa merkittävästi vähentämään tietoturvaloukkauksen riskiä ja varmistamaan, että tekoälyjärjestelmäsi pysyvät luotettavina ja turvallisina.

# Learning Objectives

Tämän oppitunnin jälkeen osaat:

- Tunnistaa ja selittää Model Context Protocolin (MCP) tuomat ainutlaatuiset tietoturvariskit, kuten promptin manipuloinnin, työkalujen myrkyttämisen, liialliset käyttöoikeudet ja toimitusketjun haavoittuvuudet.
- Kuvailla ja soveltaa tehokkaita hallintakeinoja MCP:n tietoturvariskien vähentämiseksi, kuten vahvaa todennusta, vähimmän oikeuden periaatetta, turvallista tokenien hallintaa ja toimitusketjun varmennusta.
- Ymmärtää ja hyödyntää Microsoftin ratkaisuja, kuten Prompt Shields, Azure Content Safety ja GitHub Advanced Security, MCP:n ja tekoälykuormien suojaamiseksi.
- Tunnistaa työkalujen metatietojen validoinnin, dynaamisten muutosten seurannan ja epäsuorien promptin manipulointihyökkäysten torjunnan merkityksen.
- Sisällyttää vakiintuneita tietoturvakäytäntöjä — kuten turvallista koodausta, palvelimen koventamista ja zero trust -arkkitehtuuria — MCP:n toteutukseen vähentääksesi tietoturvaloukkausten riskiä ja vaikutuksia.

# MCP security controls

Järjestelmillä, joilla on pääsy tärkeisiin resursseihin, on luonnollisesti tietoturvahaasteita. Nämä haasteet voidaan yleensä ratkaista soveltamalla oikein perusperiaatteita ja hallintakeinoja. Koska MCP on vasta uusi määritelmä, sen spesifikaatio kehittyy nopeasti. Protokollan kehittyessä myös sen tietoturvatoimenpiteet kypsyvät, mahdollistaen paremman integraation yritys- ja vakiintuneisiin tietoturva-arkkitehtuureihin ja parhaisiin käytäntöihin.

Microsoftin [Digital Defense Reportissa](https://aka.ms/mddr) julkaistu tutkimus osoittaa, että 98 % raportoituja tietoturvaloukkauksia olisi estetty vahvalla tietoturvahygeinalla. Paras suoja minkä tahansa loukkauksen varalta on saada perusasiat kuntoon — turvallinen koodaus, vähimmän oikeuden periaate ja toimitusketjun turvallisuus — nämä tutkitut ja todistetut käytännöt ovat edelleen tehokkaimpia keinoja vähentää tietoturvariskejä.

Katsotaanpa joitakin keinoja, joilla voit alkaa hallita tietoturvariskejä MCP:n käyttöönotossa.

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** Seuraavat tiedot ovat voimassa 26.4.2025 asti. MCP-protokolla kehittyy jatkuvasti, ja tulevissa toteutuksissa voi olla uusia todennusmalleja ja hallintakeinoja. Ajantasaiset tiedot ja ohjeet löytyvät aina [MCP Specification](https://spec.modelcontextprotocol.io/) -sivustolta ja virallisesta [MCP GitHub -repositoriosta](https://github.com/modelcontextprotocol).

### Ongelman kuvaus  
Alkuperäinen MCP-spesifikaatio oletti, että kehittäjät kirjoittaisivat oman todennuspalvelimensa. Tämä edellytti OAuth-osaamista ja siihen liittyvien tietoturvarajoitteiden hallintaa. MCP-palvelimet toimivat OAuth 2.0 -valtuutuspalvelimina, hoitaen käyttäjien todennuksen itse sen sijaan, että olisivat delegoineet sen ulkoiselle palvelulle, kuten Microsoft Entra ID:lle. 26.4.2025 julkaistu MCP-spesifikaation päivitys mahdollistaa MCP-palvelimien delegoida käyttäjien todennuksen ulkoiselle palvelulle.

### Riskit
- Virheellisesti konfiguroitu valtuutuslogiikka MCP-palvelimessa voi johtaa arkaluonteisen tiedon vuotamiseen ja väärin sovellettuihin pääsynhallintoihin.
- OAuth-tokenin varastaminen paikalliselta MCP-palvelimelta. Jos token varastetaan, sitä voidaan käyttää palvelimen henkilöllisyyden väärentämiseen ja pääsyn saamiseen tokenin kohteena oleviin resursseihin ja tietoihin.

### Hallintakeinot
- **Tarkista ja kovenna valtuutuslogiikkaa:** Tarkista huolellisesti MCP-palvelimesi valtuutusmekanismit varmistaaksesi, että vain tarkoitetut käyttäjät ja asiakkaat pääsevät arkaluonteisiin resursseihin. Käytännön ohjeita löydät mm. [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) ja [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Noudata turvallisia token-käytäntöjä:** Seuraa [Microsoftin parhaita käytäntöjä tokenien validointiin ja elinkaareen](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) estääksesi tokenien väärinkäytön ja vähentääksesi tokenien uudelleenkäytön tai varastamisen riskiä.
- **Suojaa tokenien tallennus:** Säilytä tokenit aina turvallisesti ja käytä salausta niiden suojaamiseksi levossa ja siirrossa. Toteutusvinkkejä löydät [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) -videolta.

# Excessive permissions for MCP servers

### Ongelman kuvaus  
MCP-palvelimille on voitu myöntää liialliset käyttöoikeudet niihin palveluihin tai resursseihin, joihin ne pääsevät käsiksi. Esimerkiksi MCP-palvelin, joka on osa tekoälypohjaista myyntisovellusta ja yhdistyy yrityksen tietovarastoon, tulisi saada käyttöoikeudet rajattuna vain myyntitietoihin, eikä sen tulisi päästä käsiksi kaikkiin varaston tiedostoihin. Paluu vähimmän oikeuden periaatteeseen (yksi vanhimmista tietoturvaperiaatteista) korostaa, ettei resurssilla tulisi olla oikeuksia enempää kuin mitä sen tehtävien suorittaminen vaatii. Tekoäly lisää haasteita, koska sen joustavuuden mahdollistamiseksi on vaikea määritellä tarkasti tarvittavat oikeudet.

### Riskit  
- Liialliset oikeudet voivat mahdollistaa tietojen poistamisen tai muokkaamisen, mihin MCP-palvelimen ei olisi tarkoitus päästä käsiksi. Tämä voi myös aiheuttaa yksityisyysongelmia, jos tiedot sisältävät henkilötietoja (PII).

### Hallintakeinot  
- **Sovella vähimmän oikeuden periaatetta:** Myönnä MCP-palvelimelle vain ne vähimmäisoikeudet, jotka sen tehtävien suorittamiseen tarvitaan. Tarkista ja päivitä nämä oikeudet säännöllisesti, jotta ne eivät ylitä tarpeellista tasoa. Tarkempaa ohjeistusta löytyy [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access) -sivulta.
- **Käytä roolipohjaista pääsynhallintaa (RBAC):** Määritä MCP-palvelimelle roolit, jotka on tiukasti rajattu tiettyihin resursseihin ja toimiin, välttäen laajoja tai tarpeettomia oikeuksia.
- **Seuraa ja tarkasta käyttöoikeuksia:** Valvo käyttöoikeuksien käyttöä jatkuvasti ja tee pääsylokien auditointeja, jotta liialliset tai käyttämättömät oikeudet voidaan havaita ja korjata nopeasti.

# Indirect prompt injection attacks

### Ongelman kuvaus

Vihamieliset tai kompromettoidut MCP-palvelimet voivat aiheuttaa merkittäviä riskejä paljastamalla asiakastietoja tai mahdollistamalla ei-toivottuja toimintoja. Nämä riskit ovat erityisen tärkeitä tekoäly- ja MCP-pohjaisissa kuormissa, joissa:

- **Prompt Injection -hyökkäykset:** Hyökkääjät upottavat haitallisia ohjeita promptteihin tai ulkoiseen sisältöön, jolloin tekoälyjärjestelmä suorittaa ei-toivottuja toimintoja tai vuotaa arkaluonteisia tietoja. Lisätietoja: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Hyökkääjät manipuloivat työkalujen metatietoja (kuten kuvauksia tai parametreja) vaikuttaakseen tekoälyn käyttäytymiseen, mahdollistaen tietoturvatoimien ohittamisen tai tietovuodot. Lisätietoja: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Haitalliset ohjeet on upotettu dokumentteihin, verkkosivuihin tai sähköposteihin, joita tekoäly käsittelee, mikä johtaa tietovuotoihin tai manipulointiin.
- **Dynaaminen työkalumuokkaus (Rug Pulls):** Työkalumäärittelyjä voidaan muuttaa käyttäjän hyväksynnän jälkeen, jolloin uusia haitallisia toimintoja voidaan lisätä käyttäjän tietämättä.

Nämä haavoittuvuudet korostavat vahvan validoinnin, valvonnan ja tietoturvatoimien tarvetta MCP-palvelimien ja työkalujen integroinnissa ympäristöösi. Tarkempaa tietoa löytyy yllä mainituista lähteistä.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.fi.png)

**Epäsuora promptin manipulointi** (tunnetaan myös nimellä cross-domain prompt injection tai XPIA) on vakava haavoittuvuus generatiivisissa tekoälyjärjestelmissä, mukaan lukien MCP:tä käyttävät. Tässä hyökkäyksessä haitalliset ohjeet piilotetaan ulkoiseen sisältöön — kuten dokumentteihin, verkkosivuille tai sähköposteihin. Kun tekoäly käsittelee tätä sisältöä, se saattaa tulkita upotetut ohjeet laillisiksi käyttäjän komennoiksi, mikä johtaa ei-toivottuihin toimintoihin kuten tietovuotoihin, haitallisen sisällön tuottamiseen tai käyttäjävuorovaikutusten manipulointiin. Tarkempi selitys ja esimerkit löytyvät osoitteesta [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Erityisen vaarallinen muoto tästä hyökkäyksestä on **Tool Poisoning**. Tässä hyökkääjät injektoivat haitallisia ohjeita MCP-työkalujen metatietoihin (kuten työkalun kuvauksiin tai parametreihin). Koska suuret kielimallit (LLM:t) käyttävät näitä metatietoja päättääkseen, mitä työkaluja kutsutaan, kompromettoidut kuvaukset voivat huijata mallia suorittamaan luvattomia työkalukutsuja tai ohittamaan tietoturvatoimet. Nämä manipuloinnit ovat usein näkymättömiä loppukäyttäjille, mutta tekoälyjärjestelmä voi tulkita ja toimia niiden mukaan. Tämä riski korostuu isännöidyissä MCP-palvelinympäristöissä, joissa työkalumäärittelyjä voidaan päivittää käyttäjän hyväksynnän jälkeen — tilanne, jota kutsutaan joskus "[rug pulliksi](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Tällöin aiemmin turvallinen työkalu saatetaan myöhemmin muuttaa suorittamaan haitallisia toimintoja, kuten tietovuotoja tai järjestelmän käyttäytymisen muuttamista, ilman käyttäjän tietoa. Lisätietoja tästä hyökkäysvektorista löytyy osoitteesta [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.fi.png)

## Riskit  
Tekoälyn ei-toivotut toiminnot aiheuttavat erilaisia tietoturvariskejä, kuten tietovuotoja ja yksityisyyden loukkauksia.

### Hallintakeinot  
### Prompt Shieldsin käyttö epäsuoria promptin manipulointihyökkäyksiä vastaan
-----------------------------------------------------------------------------

**AI Prompt Shields** on Microsoftin kehittämä ratkaisu, joka suojaa sekä suoralta että epäsuoralta promptin manipuloinnilta. Ne auttavat seuraavasti:

1.  **Havaitseminen ja suodatus:** Prompt Shields käyttävät kehittyneitä koneoppimisalgoritmeja ja luonnollisen kielen käsittelyä tunnistaakseen ja suodattaakseen haitalliset ohjeet ulkoisessa sisällössä, kuten dokumenteissa, verkkosivuilla tai sähköposteissa.
    
2.  **Spotlighting:** Tämä tekniikka auttaa tekoälyä erottamaan lailliset järjestelmäohjeet epäluotettavista ulkoisista syötteistä. Muokkaamalla syötetekstiä mallille merkityksellisempään muotoon Spotlighting varmistaa, että tekoäly tunnistaa ja ohittaa haitalliset ohjeet paremmin.
    
3.  **Erotinmerkit ja datamerkinnät:** Järjestelmäviestiin sisällytettävät erotinmerkit määrittävät selkeästi syötteen sijainnin, auttaen tekoälyä erottamaan käyttäjän syötteet mahdollisesti haitallisesta ulkoisesta sisällöstä. Datamerkinnät laajentavat tätä konseptia käyttämällä erityisiä merkkejä korostamaan luotettujen ja epäluotettujen tietojen rajat.
    
4.  **Jatkuva valvonta ja päivitykset:** Microsoft valvoo ja päivittää Prompt Shields -ratkaisua jatkuvasti uusien ja kehittyvien uhkien torjumiseksi. Tämä ennakoiva lähestymistapa varmistaa, että puolustukset pysyvät tehokkaina uusimpia hyökkäystekniikoita vastaan.
    
5. **Integrointi Azure Content Safetyn kanssa:** Prompt Shields ovat osa laajempaa Azure AI Content Safety -kokonaisuutta, joka tarjoaa lisätyökaluja jailbreak-hyökkäysten, haitallisen sisällön ja muiden tekoälyn tietoturvariskien havaitsemiseen.

Lisätietoja AI prompt shields -ratkaisusta löytyy [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) -sivustolta.

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.fi.png)

### Supply chain security

Toimitusketjun turvallisuus on edelleen keskeistä tekoälyn aikakaudella, mutta toimitusketjun käsitys on laajentunut. Perinteisten koodipakettien lisäksi sinun tulee nyt huolellisesti varmistaa ja valvoa kaikkia tekoälyyn liittyviä komponentteja, mukaan lukien pohjamallit, upotuspalvelut, kontekstin tarjoajat ja kolmannen osapuolen API:t. Jokainen näistä voi tuoda haavoittuvuuksia tai riskejä, jos niitä ei hallita asianmukaisesti.

**Keskeiset toimitusketjun turvallisuuskäytännöt tekoälylle ja MCP:lle:**
- **Varmista kaikki komponentit ennen integrointia:** Tämä koskee paitsi avoimen lähdekoodin kirjastoja, myös tekoälymalleja, tietolähteitä ja ulkoisia API-rajapintoja. Tarkista aina alkuperä, lisenssit ja tunnetut haavoittuvuudet.
- **Ylläpidä turvallisia käyttöönotto-putkia:** Käytä automatisoituja CI/CD-putkia, joissa on integroitu tietoturvaskannaus ongelmien varhaiseen havaitsemiseen. Varmista, että tuot
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Seuraava

Seuraava: [Luku 3: Aloittaminen](/03-GettingStarted/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty tekoälypohjaisella käännöspalvelulla [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeiden tietojen osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinkäsityksistä tai tulkinnoista.