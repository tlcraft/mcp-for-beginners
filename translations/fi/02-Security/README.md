<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T17:52:40+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "fi"
}
-->
# Turvallisuuden parhaat käytännöt

Model Context Protocolin (MCP) käyttöönotto tuo tekoälypohjaisiin sovelluksiin tehokkaita uusia ominaisuuksia, mutta samalla se tuo mukanaan ainutlaatuisia turvallisuushaasteita, jotka ylittävät perinteiset ohjelmistoriskit. Vakiintuneiden huolenaiheiden, kuten turvallisen koodauksen, vähimmän oikeuden periaatteen ja toimitusketjun turvallisuuden lisäksi MCP ja tekoälykuormitukset kohtaavat uusia uhkia, kuten promptin injektoinnin, työkalujen myrkytyksen ja dynaamisen työkalumuokkauksen. Näiden riskien hallitsemattomuus voi johtaa tietovuotoihin, yksityisyyden loukkauksiin ja odottamattomaan järjestelmän käyttäytymiseen.

Tässä oppitunnissa käsitellään MCP:hen liittyviä keskeisimpiä turvallisuusriskejä — mukaan lukien todennus, valtuutus, liialliset oikeudet, epäsuora promptin injektointi ja toimitusketjun haavoittuvuudet — sekä tarjotaan käytännön ohjeita ja parhaita käytäntöjä niiden hallitsemiseksi. Opit myös hyödyntämään Microsoftin ratkaisuja, kuten Prompt Shields, Azure Content Safety ja GitHub Advanced Security, vahvistaaksesi MCP-toteutustasi. Näiden ohjainten ymmärtäminen ja soveltaminen auttaa merkittävästi vähentämään tietoturvaloukkausten riskiä ja varmistamaan, että tekoälyjärjestelmäsi pysyvät luotettavina ja kestävinä.

# Oppimistavoitteet

Oppitunnin lopuksi osaat:

- Tunnistaa ja selittää Model Context Protocolin (MCP) tuomat ainutlaatuiset turvallisuusuhat, kuten promptin injektoinnin, työkalujen myrkytyksen, liialliset oikeudet ja toimitusketjun haavoittuvuudet.
- Kuvailla ja soveltaa tehokkaita hallintakeinoja MCP:n turvallisuusriskeihin, kuten vahvaa todennusta, vähimmän oikeuden periaatetta, turvallista tokenien hallintaa ja toimitusketjun varmistamista.
- Ymmärtää ja hyödyntää Microsoftin ratkaisuja, kuten Prompt Shields, Azure Content Safety ja GitHub Advanced Security, MCP:n ja tekoälykuormitusten suojaamiseksi.
- Tunnistaa työkalujen metatietojen validoinnin, dynaamisten muutosten seurannan ja epäsuorien promptin injektointihyökkäysten torjunnan merkityksen.
- Sisällyttää vakiintuneita turvallisuuden parhaita käytäntöjä — kuten turvallinen koodaus, palvelinten koventaminen ja zero trust -arkkitehtuuri — MCP-toteutukseesi vähentääksesi tietoturvaloukkausten todennäköisyyttä ja vaikutuksia.

# MCP:n turvallisuusohjaimet

Järjestelmillä, joilla on pääsy tärkeisiin resursseihin, on aina oletettuja turvallisuushaasteita. Näihin haasteisiin voidaan yleensä vastata soveltamalla oikein perustavanlaatuisia turvallisuusohjaimia ja -periaatteita. Koska MCP on vasta hiljattain määritelty, sen spesifikaatio muuttuu nopeasti ja protokolla kehittyy jatkuvasti. Lopulta sen sisäiset turvallisuusohjaimet kypsyvät, mikä mahdollistaa paremman integraation yritysten ja vakiintuneiden turvallisuusarkkitehtuurien ja parhaiden käytäntöjen kanssa.

Microsoftin julkaisemassa [Microsoft Digital Defense Reportissa](https://aka.ms/mddr) todetaan, että 98 % raportoituja tietoturvaloukkauksia voitaisiin estää vahvalla turvallisuushygienialla, ja paras suoja minkä tahansa loukkauksen varalta on saada perusasiat kuntoon — turvallinen koodaus, hyvä turvallisuushygienia ja toimitusketjun turvallisuus — ne tutkitut ja testatut käytännöt, jotka edelleen vaikuttavat eniten riskien vähentämiseen.

Katsotaanpa joitakin tapoja, joilla voit alkaa hallita turvallisuusriskejä MCP:n käyttöönotossa.

> **[!NOTE]** Seuraavat tiedot ovat voimassa **29.5.2025**. MCP-protokolla kehittyy jatkuvasti, ja tulevat toteutukset voivat tuoda uusia todennusmalleja ja ohjaimia. Ajantasaisimmat päivitykset ja ohjeistukset löytyvät aina [MCP Specification](https://spec.modelcontextprotocol.io/), virallisesta [MCP GitHub -varastosta](https://github.com/modelcontextprotocol) ja [turvallisuuden parhaiden käytäntöjen sivulta](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Ongelman kuvaus  
Alkuperäinen MCP-spesifikaatio oletti, että kehittäjät kirjoittaisivat oman todennuspalvelimensa. Tämä vaati OAuth-osaamista ja siihen liittyvien turvallisuusrajoitteiden tuntemusta. MCP-palvelimet toimivat OAuth 2.0 -valtuutuspalvelimina, jotka hallinnoivat käyttäjien todennusta suoraan sen sijaan, että delegoisivat sen ulkoiselle palvelulle, kuten Microsoft Entra ID:lle. Päivityksen myötä, joka astui voimaan **26.4.2025**, MCP-spesifikaatio sallii MCP-palvelimien delegoida käyttäjien todennuksen ulkoiselle palvelulle.

### Riskit
- Virheellisesti konfiguroitu valtuutuslogiikka MCP-palvelimessa voi johtaa arkaluonteisten tietojen paljastumiseen ja väärin sovellettuihin käyttöoikeuksiin.
- OAuth-tokenin varastaminen paikalliselta MCP-palvelimelta. Varastettu token voi mahdollistaa MCP-palvelimen esiintymisen ja pääsyn palvelun resursseihin ja tietoihin, joita token koskee.

#### Tokenin läpivienti
Tokenin läpivienti on valtuutussäännöissä nimenomaisesti kielletty, koska se aiheuttaa useita turvallisuusriskejä, kuten:

#### Turvallisuusohjainten kiertäminen
MCP-palvelin tai alaspäin suuntautuvat API:t voivat toteuttaa tärkeitä turvallisuusohjaimia, kuten nopeusrajoituksia, pyyntöjen validointia tai liikenteen seurantaa, jotka perustuvat tokenin vastaanottajaan tai muihin tunnistetietoihin. Jos asiakkaat voivat saada ja käyttää tokeneita suoraan alaspäin suuntautuvissa API:ssa ilman, että MCP-palvelin validoi niitä asianmukaisesti tai varmistaa, että tokenit on myönnetty oikealle palvelulle, nämä ohjaimet ohitetaan.

#### Vastuu ja auditointiongelmat
MCP-palvelin ei pysty tunnistamaan tai erottamaan MCP-asiakkaita, kun asiakkaat kutsuvat ylävirran myöntämällä pääsytokenilla, joka voi olla MCP-palvelimelle läpinäkymätön.  
Alaspäin suuntautuvan resurssipalvelimen lokit voivat näyttää pyyntöjä, jotka vaikuttavat tulevan eri lähteestä eri identiteetillä kuin MCP-palvelin, joka todellisuudessa välittää tokenit.  
Molemmat tekijät vaikeuttavat tapaustutkintaa, ohjainten hallintaa ja auditointia.  
Jos MCP-palvelin välittää tokeneita validoimatta niiden väitteitä (esim. roolit, oikeudet tai vastaanottaja) tai muuta metatietoa, varastetun tokenin haltija voi käyttää palvelinta välityspalvelimena tietovuotoihin.

#### Luottamusrajojen ongelmat
Alaspäin suuntautuva resurssipalvelin myöntää luottamuksen tietyille toimijoille. Tämä luottamus voi sisältää oletuksia alkuperästä tai asiakkaan käyttäytymismalleista. Luottamusrajan rikkominen voi johtaa odottamattomiin ongelmiin.  
Jos token hyväksytään useissa palveluissa ilman asianmukaista validointia, hyökkääjä, joka on saanut haltuunsa yhden palvelun, voi käyttää tokenia päästäkseen muihin yhdistettyihin palveluihin.

#### Tulevaisuuden yhteensopivuusriskit
Vaikka MCP-palvelin alkaisi tänään "puhdasta välityspalvelinta" käyttäen, sen voi myöhemmin olla tarpeen lisätä turvallisuusohjaimia. Oikean tokenin vastaanottajan erottelu alusta alkaen helpottaa turvallisuusmallin kehittymistä.

### Hallintakeinot

**MCP-palvelimet EIVÄT SAA HYVÄKSYÄ mitään tokeneita, joita ei ole nimenomaisesti myönnetty kyseiselle MCP-palvelimelle**

- **Tarkista ja kovenna valtuutuslogiikka:** Tarkista huolellisesti MCP-palvelimesi valtuutus toteutus varmistaaksesi, että vain tarkoitetut käyttäjät ja asiakkaat pääsevät arkaluonteisiin resursseihin. Käytännön ohjeita löydät osoitteista [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) ja [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Noudata turvallisia token-käytäntöjä:** Seuraa [Microsoftin parhaita käytäntöjä tokenien validointiin ja elinkaareen](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) estääksesi pääsytokenien väärinkäytön ja vähentääksesi tokenien uudelleenkäytön tai varastamisen riskiä.
- **Suojaa tokenien tallennus:** Säilytä tokenit aina turvallisesti ja käytä salausmenetelmiä niiden suojaamiseksi levossa ja siirrossa. Toteutusvinkkejä löydät [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) -videolta.

# Liialliset oikeudet MCP-palvelimille

### Ongelman kuvaus  
MCP-palvelimille on voitu myöntää liialliset oikeudet palveluun tai resurssiin, johon ne pääsevät käsiksi. Esimerkiksi MCP-palvelin, joka on osa tekoälypohjaista myyntisovellusta ja yhdistyy yrityksen tietovarastoon, tulisi rajata pääsy vain myyntitietoihin eikä sallia pääsyä kaikkiin tietovaraston tiedostoihin. Paluu vähimmän oikeuden periaatteeseen (yksi vanhimmista turvallisuusperiaatteista) tarkoittaa, että mikään resurssi ei saa oikeuksia enempää kuin mitä sen tehtävien suorittaminen vaatii. Tekoäly lisää haasteita, koska sen joustavuuden mahdollistamiseksi on vaikea määritellä tarkasti tarvittavat oikeudet.

### Riskit  
- Liiallisten oikeuksien myöntäminen voi mahdollistaa tietojen luvattoman siirron tai muokkaamisen, joihin MCP-palvelimen ei ollut tarkoitus päästä käsiksi. Tämä voi myös aiheuttaa yksityisyysongelmia, jos tiedot sisältävät henkilötietoja (PII).

### Hallintakeinot  
- **Sovella vähimmän oikeuden periaatetta:** Myönnä MCP-palvelimelle vain ne vähimmäisoikeudet, jotka se tarvitsee tehtäviensä suorittamiseen. Tarkista ja päivitä oikeuksia säännöllisesti varmistaaksesi, etteivät ne ylitä tarpeellista. Yksityiskohtaiset ohjeet löytyvät [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access) -sivulta.
- **Käytä roolipohjaista pääsynhallintaa (RBAC):** Määritä MCP-palvelimelle roolit, jotka ovat tiukasti rajattuja tiettyihin resursseihin ja toimiin, välttäen laajoja tai tarpeettomia oikeuksia.
- **Seuraa ja auditoi oikeuksia:** Valvo jatkuvasti oikeuksien käyttöä ja tarkasta pääsylokit, jotta liialliset tai käyttämättömät oikeudet voidaan havaita ja korjata nopeasti.

# Epäsuorat promptin injektointihyökkäykset

### Ongelman kuvaus

Vahingolliset tai kaapatut MCP-palvelimet voivat aiheuttaa merkittäviä riskejä paljastamalla asiakastietoja tai mahdollistamalla ei-toivottuja toimintoja. Nämä riskit ovat erityisen merkittäviä tekoäly- ja MCP-pohjaisissa kuormituksissa, joissa:

- **Promptin injektointihyökkäykset:** Hyökkääjät upottavat haitallisia ohjeita promptteihin tai ulkoiseen sisältöön, mikä saa tekoälyjärjestelmän suorittamaan ei-toivottuja toimintoja tai vuotamaan arkaluonteisia tietoja. Lisätietoja: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Työkalujen myrkytys:** Hyökkääjät manipuloivat työkalujen metatietoja (kuten kuvauksia tai parametreja) vaikuttaakseen tekoälyn käyttäytymiseen, mahdollisesti kiertäen turvallisuusohjaimia tai vuotamalla tietoja. Lisätietoja: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Ristiin domainin promptin injektointi:** Haitalliset ohjeet upotetaan dokumentteihin, verkkosivuille tai sähköposteihin, jotka tekoäly sitten käsittelee, aiheuttaen tietovuotoja tai manipulointia.
- **Dynaaminen työkalumuokkaus (Rug Pulls):** Työkalumäärittelyjä voidaan muuttaa käyttäjän hyväksynnän jälkeen, mikä tuo uusia haitallisia toimintoja ilman käyttäjän tietoa.

Nämä haavoittuvuudet korostavat tarvetta vahvalle validoinnille, seurannalle ja turvallisuusohjaimille, kun MCP-palvelimia ja työkaluja integroidaan ympäristöön. Syvällisempää tietoa löytyy yllä linkatuista lähteistä.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.fi.png)

**Epäsuora promptin injektointi** (tunnetaan myös nimellä ristiin domainin promptin injektointi tai XPIA) on kriittinen haavoittuvuus generatiivisissa tekoälyjärjestelmissä, mukaan lukien MCP:tä käyttävät. Tässä hyökkäyksessä haitalliset ohjeet piilotetaan ulkoiseen sisältöön — kuten dokumentteihin, verkkosivuille tai sähköposteihin. Kun tekoäly käsittelee tätä sisältöä, se saattaa tulkita upotetut ohjeet laillisiksi käyttäjän komennoiksi, mikä johtaa ei-toivottuihin toimintoihin, kuten tietovuotoihin, haitallisen sisällön luomiseen tai käyttäjävuorovaikutusten manipulointiin. Tarkemman selityksen ja käytännön esimerkit löydät osoitteesta [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Erityisen vaarallinen muoto tästä hyökkäyksestä on **Työkalujen myrkytys**. Tässä hyökkääjät injektoivat haitallisia ohjeita MCP-työkalujen metatietoihin (kuten työkalukuvausten tai parametrien kenttiin). Koska suuret kielimallit (LLM) käyttävät näitä metatietoja päättäessään, mitä työkaluja kutsutaan, manipuloidut kuvaukset voivat huijata mallia suorittamaan luvattomia työkalukutsuja tai kiertämään turvallisuusohjaimia. Nämä manipulaatiot ovat usein loppukäyttäjille näkymättömiä, mutta tekoälyjärjestelmä voi tulkita ja toimia niiden mukaan. Riski korostuu isännöidyissä MCP-palvelinympäristöissä, joissa työkalumäärittelyjä voidaan päivittää käyttäjän hyväksynnän jälkeen — tilannetta kutsutaan joskus "[rug pulliksi](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Tällöin aiemmin turvallinen työkalu voidaan myöhemmin muuttaa suorittamaan haitallisia toimintoja, kuten tietovuotoja tai järjestelmän käyttäytymisen muuttamista, ilman käyttäjän tietoa. Lisätietoja tästä hyökkäysvektorista löytyy osoitteesta [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.fi.png)

## Riskit  
Ei-toivotut tekoälytoiminnot aiheuttavat monenlaisia turvallisuusriskejä, kuten tietovuotoja ja yksityisyyden loukkauksia.

### Hallintakeinot  
### Prompt Shieldsin käyttö epäsuoria promptin injektointihyökkäyksiä vastaan
-----------------------------------------------------------------------------

**AI Prompt Shields** on Microsoftin kehittämä ratkaisu, joka suojaa sekä suoria että epäsuoria promptin injektointihyökkäyksiä vastaan. Ne auttavat seuraavilla tavoilla:

1.  **Havaitseminen ja suodatus:** Prompt Shields hyödyntävät kehittyneitä koneoppimisalgoritmeja ja luonnollisen kielen käsittely
Toimitusketjun turvallisuus on edelleen keskeistä tekoälyn aikakaudella, mutta toimitusketjun käsite on laajentunut. Perinteisten koodipakettien lisäksi sinun on nyt huolellisesti varmistettava ja valvottava kaikkia tekoälyyn liittyviä komponentteja, kuten perustamalleja, upotepalveluita, kontekstin tarjoajia ja kolmansien osapuolten API-rajapintoja. Jokainen näistä voi aiheuttaa haavoittuvuuksia tai riskejä, jos niitä ei hallita asianmukaisesti.

**Keskeiset toimitusketjun turvallisuuskäytännöt tekoälylle ja MCP:lle:**
- **Varmista kaikki komponentit ennen integrointia:** Tämä koskee paitsi avoimen lähdekoodin kirjastoja myös tekoälymalleja, tietolähteitä ja ulkoisia API-rajapintoja. Tarkista aina alkuperä, lisenssit ja tunnetut haavoittuvuudet.
- **Pidä käyttöönotto-putket turvallisina:** Käytä automatisoituja CI/CD-putkia, joissa on integroitu turvallisuusskannaus ongelmien havaitsemiseksi varhaisessa vaiheessa. Varmista, että tuotantoon otetaan vain luotettavia artefakteja.
- **Seuraa ja tarkasta jatkuvasti:** Toteuta jatkuva valvonta kaikille riippuvuuksille, mukaan lukien mallit ja tietopalvelut, uusien haavoittuvuuksien tai toimitusketjun hyökkäysten havaitsemiseksi.
- **Käytä vähimmän oikeuden periaatetta ja pääsynhallintaa:** Rajoita pääsy malleihin, tietoihin ja palveluihin vain siihen, mikä on välttämätöntä MCP-palvelimesi toiminnalle.
- **Reagoi uhkiin nopeasti:** Ota käyttöön prosessi vaarantuneiden komponenttien korjaamiseksi tai vaihtamiseksi sekä salaisuuksien tai tunnistetietojen kierrättämiseksi, jos tietomurto havaitaan.

[GitHub Advanced Security](https://github.com/security/advanced-security) tarjoaa ominaisuuksia kuten salaisuuksien skannaus, riippuvuuksien skannaus ja CodeQL-analyysi. Nämä työkalut integroituvat [Azure DevOpsin](https://azure.microsoft.com/en-us/products/devops) ja [Azure Reposin](https://azure.microsoft.com/en-us/products/devops/repos/) kanssa auttaen tiimejä tunnistamaan ja lieventämään haavoittuvuuksia sekä koodissa että tekoälyn toimitusketjun komponenteissa.

Microsoft toteuttaa myös laajoja toimitusketjun turvallisuuskäytäntöjä sisäisesti kaikissa tuotteissaan. Lue lisää [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Vakiintuneet turvallisuuskäytännöt, jotka parantavat MCP-toteutuksesi turvallisuustasoa

Mikä tahansa MCP-toteutus perii olemassa olevan turvallisuustason organisaatiosi ympäristöstä, johon se on rakennettu. Siksi MCP:n turvallisuutta osana kokonaisvaltaisia tekoälyjärjestelmiä harkitessasi on suositeltavaa parantaa yleistä olemassa olevaa turvallisuustasoasi. Seuraavat vakiintuneet turvallisuusohjaimet ovat erityisen merkityksellisiä:

- Turvallisen koodauksen parhaat käytännöt tekoälysovelluksessasi – suojaa [OWASP Top 10](https://owasp.org/www-project-top-ten/) -uhkia vastaan, [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559) -listan mukaisesti, käytä turvallisia säilöjä salaisuuksille ja tokeneille, toteuta päästä päähän -turvallinen viestintä kaikkien sovelluskomponenttien välillä jne.
- Palvelimen koventaminen – käytä monivaiheista tunnistautumista (MFA) aina kun mahdollista, pidä päivitykset ajan tasalla, integroi palvelin kolmannen osapuolen identiteetin tarjoajan kanssa pääsyn hallintaan jne.
- Pidä laitteet, infrastruktuuri ja sovellukset ajan tasalla päivityksillä
- Turvallisuusvalvonta – toteuta lokitus ja valvonta tekoälysovellukselle (mukaan lukien MCP-asiakas- ja palvelinpuoli) ja lähetä lokit keskitettyyn SIEM-järjestelmään poikkeavuuksien havaitsemiseksi
- Zero trust -arkkitehtuuri – eristä komponentit verkko- ja identiteettihallinnan avulla loogisesti minimoidaksesi sivuttaisliikkeet, jos tekoälysovellus vaarantuu.

# Keskeiset opit

- Turvallisuuden perusasiat ovat edelleen ratkaisevia: turvallinen koodaus, vähimmän oikeuden periaate, toimitusketjun varmistus ja jatkuva valvonta ovat välttämättömiä MCP:lle ja tekoälykuormituksille.
- MCP tuo mukanaan uusia riskejä, kuten promptin injektoinnin, työkalujen myrkytyksen ja liiallisen käyttöoikeuden, jotka vaativat sekä perinteisiä että tekoälyyn liittyviä hallintakeinoja.
- Käytä vahvaa tunnistautumista, valtuutusta ja tokenien hallintaa hyödyntäen ulkoisia identiteetin tarjoajia, kuten Microsoft Entra ID:tä, aina kun mahdollista.
- Suojaudu epäsuoralta promptin injektoinnilta ja työkalujen myrkytykseltä validoimalla työkalujen metatiedot, seuraamalla dynaamisia muutoksia ja käyttämällä ratkaisuja kuten Microsoft Prompt Shields.
- Kohtele kaikkia tekoälyn toimitusketjun komponentteja – mukaan lukien mallit, upotukset ja kontekstin tarjoajat – yhtä huolellisesti kuin koodiriippuvuuksia.
- Pysy ajan tasalla MCP:n kehittyvistä spesifikaatioista ja osallistu yhteisöön auttaaksesi muokkaamaan turvallisia standardeja.

# Lisäresurssit

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Seuraava

Seuraava: [Luku 3: Aloittaminen](../03-GettingStarted/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.