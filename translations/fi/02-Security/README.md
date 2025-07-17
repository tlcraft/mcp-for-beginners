<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T07:02:22+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "fi"
}
-->
# Turvallisuuden parhaat käytännöt

Model Context Protocolin (MCP) käyttöönotto tuo tekoälypohjaisiin sovelluksiin tehokkaita uusia ominaisuuksia, mutta samalla se tuo mukanaan ainutlaatuisia turvallisuushaasteita, jotka ylittävät perinteiset ohjelmistoriskit. Vakiintuneiden huolien, kuten turvallisen koodauksen, vähimmän oikeuden periaatteen ja toimitusketjun turvallisuuden lisäksi MCP- ja tekoälykuormitukset kohtaavat uusia uhkia, kuten prompt-injektio, työkalujen myrkytys, dynaaminen työkalumuokkaus, istunnon kaappaus, confused deputy -hyökkäykset ja tokenin läpivientihaavoittuvuudet. Näitä riskejä ei hallita asianmukaisesti, ne voivat johtaa tietovuotoihin, yksityisyyden loukkauksiin ja odottamattomaan järjestelmän käyttäytymiseen.

Tässä oppitunnissa käsitellään MCP:hen liittyviä keskeisimpiä turvallisuusriskejä — mukaan lukien todennus, valtuutus, liialliset oikeudet, epäsuora prompt-injektio, istunnon turvallisuus, confused deputy -ongelmat, tokenin läpivientihaavoittuvuudet ja toimitusketjun haavoittuvuudet — sekä annetaan käytännön ohjeita ja parhaita käytäntöjä niiden hallitsemiseksi. Opit myös hyödyntämään Microsoftin ratkaisuja, kuten Prompt Shields, Azure Content Safety ja GitHub Advanced Security, vahvistaaksesi MCP-toteutustasi. Näiden kontrollien ymmärtäminen ja soveltaminen auttaa merkittävästi vähentämään tietoturvaloukkausten riskiä ja varmistamaan, että tekoälyjärjestelmäsi pysyvät luotettavina ja kestävinä.

# Oppimistavoitteet

Oppitunnin lopuksi osaat:

- Tunnistaa ja selittää Model Context Protocolin (MCP) tuomat ainutlaatuiset turvallisuusriskit, kuten prompt-injektion, työkalujen myrkytyksen, liialliset oikeudet, istunnon kaappauksen, confused deputy -ongelmat, tokenin läpivientihaavoittuvuudet ja toimitusketjun haavoittuvuudet.
- Kuvailla ja soveltaa tehokkaita lieventäviä toimenpiteitä MCP:n turvallisuusriskeihin, kuten vahvaa todennusta, vähimmän oikeuden periaatetta, turvallista tokenien hallintaa, istunnon suojausmekanismeja ja toimitusketjun varmistusta.
- Ymmärtää ja hyödyntää Microsoftin ratkaisuja, kuten Prompt Shields, Azure Content Safety ja GitHub Advanced Security, MCP:n ja tekoälykuormitusten suojaamiseksi.
- Tunnistaa työkalujen metatietojen validoinnin, dynaamisten muutosten seurannan, epäsuorien prompt-injektiohyökkäysten torjunnan ja istunnon kaappauksen estämisen tärkeyden.
- Sisällyttää vakiintuneita turvallisuuden parhaita käytäntöjä — kuten turvallinen koodaus, palvelinten koventaminen ja zero trust -arkkitehtuuri — MCP-toteutukseesi vähentääksesi tietoturvaloukkausten todennäköisyyttä ja vaikutuksia.

# MCP:n turvallisuuskontrollit

Järjestelmillä, joilla on pääsy tärkeisiin resursseihin, on aina implisiittisiä turvallisuushaasteita. Näihin haasteisiin voidaan yleensä vastata soveltamalla oikein perustavanlaatuisia turvallisuuskontrolleja ja -periaatteita. Koska MCP on vasta hiljattain määritelty, sen spesifikaatio muuttuu nopeasti ja protokolla kehittyy. Lopulta sen sisäiset turvallisuuskontrollit kypsyvät, mikä mahdollistaa paremman integraation yritysten ja vakiintuneiden turvallisuusarkkitehtuurien ja parhaiden käytäntöjen kanssa.

Microsoftin julkaisemassa [Digital Defense Reportissa](https://aka.ms/mddr) todetaan, että 98 % raportoituja tietoturvaloukkauksia voitaisiin estää vahvalla turvallisuushygienialla, ja paras suoja minkä tahansa loukkauksen varalta on saada perusasiat kuntoon — turvallinen koodaus, hyvä turvallisuushygienia ja toimitusketjun turvallisuus — ne tutkitut ja testatut käytännöt, jotka edelleen vähentävät eniten turvallisuusriskiä.

Katsotaanpa joitakin tapoja, joilla voit alkaa hallita turvallisuusriskejä MCP:n käyttöönotossa.

> **[!NOTE]:** Seuraavat tiedot ovat voimassa **29.5.2025** asti. MCP-protokolla kehittyy jatkuvasti, ja tulevat toteutukset voivat tuoda uusia todennusmalleja ja kontrollimekanismeja. Ajantasaisimmat päivitykset ja ohjeistukset löytyvät aina [MCP Specification](https://spec.modelcontextprotocol.io/), virallisesta [MCP GitHub -varastosta](https://github.com/modelcontextprotocol) sekä [turvallisuuden parhaiden käytäntöjen sivulta](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Ongelman kuvaus  
Alkuperäinen MCP-spesifikaatio oletti, että kehittäjät kirjoittaisivat oman todennuspalvelimensa. Tämä vaati OAuth-osaamista ja siihen liittyvien turvallisuusrajoitteiden tuntemusta. MCP-palvelimet toimivat OAuth 2.0 -valtuutuspalvelimina, hoitaen käyttäjien todennuksen suoraan sen sijaan, että delegoisivat sen ulkoiselle palvelulle, kuten Microsoft Entra ID:lle. Päivityksen myötä **26.4.2025** alkaen MCP-palvelimet voivat delegoida käyttäjien todennuksen ulkoiselle palvelulle.

### Riskit
- MCP-palvelimen väärin konfiguroitu valtuutuslogiikka voi johtaa arkaluonteisten tietojen paljastumiseen ja väärin sovellettuihin käyttöoikeuksiin.
- OAuth-tokenin varastaminen paikalliselta MCP-palvelimelta. Varastettu token voi mahdollistaa MCP-palvelimen esiintymisen ja pääsyn palvelun resursseihin ja tietoihin, joita token koskee.

#### Tokenin läpivienti
Tokenin läpivienti on valtuutusspesifikaatiossa nimenomaisesti kielletty, koska se aiheuttaa useita turvallisuusriskejä, kuten:

#### Turvallisuuskontrollien kiertäminen
MCP-palvelin tai alaspäin suuntautuvat API:t voivat toteuttaa tärkeitä turvallisuuskontrolleja, kuten nopeusrajoituksia, pyyntöjen validointia tai liikenteen seurantaa, jotka perustuvat tokenin vastaanottajaan tai muihin tunnistetietoihin. Jos asiakkaat voivat saada ja käyttää tokeneita suoraan alaspäin suuntautuvissa API:ssa ilman, että MCP-palvelin validoi niitä asianmukaisesti tai varmistaa, että tokenit on myönnetty oikealle palvelulle, nämä kontrollit ohitetaan.

#### Vastuu ja auditointiongelmat
MCP-palvelin ei pysty tunnistamaan tai erottamaan MCP-asiakkaita, kun asiakkaat kutsuvat ylävirran myöntämällä access tokenilla, joka voi olla MCP-palvelimelle läpinäkymätön.  
Alaspäin suuntautuvan resurssipalvelimen lokit voivat näyttää pyyntöjä, jotka vaikuttavat tulevan eri lähteestä eri identiteetillä kuin MCP-palvelin, joka todellisuudessa välittää tokenit.  
Molemmat tekijät vaikeuttavat tapaustutkintaa, kontrollien toteutusta ja auditointia.  
Jos MCP-palvelin välittää tokeneita validoimatta niiden väitteitä (esim. roolit, oikeudet tai vastaanottaja) tai muuta metatietoa, varastetun tokenin haltija voi käyttää palvelinta välityspalvelimena tietovuotoon.

#### Luottamusrajaongelmat
Alaspäin suuntautuva resurssipalvelin myöntää luottamuksen tietyille toimijoille. Tämä luottamus voi sisältää oletuksia alkuperästä tai asiakkaan käyttäytymismalleista. Luottamusrajan rikkominen voi johtaa odottamattomiin ongelmiin.  
Jos token hyväksytään useissa palveluissa ilman asianmukaista validointia, hyökkääjä, joka on saanut haltuunsa yhden palvelun, voi käyttää tokenia päästäkseen muihin yhdistettyihin palveluihin.

#### Tulevaisuuden yhteensopivuusriskit
Vaikka MCP-palvelin alkaisi tänään "puhtaana välityspalvelimena", sen voi myöhemmin olla tarpeen lisätä turvallisuuskontrolleja. Oikean tokenin vastaanottajan erottelun aloittaminen helpottaa turvallisuusmallin kehittämistä.

### Lieventävät kontrollit

**MCP-palvelimet EIVÄT SAA HYVÄKSYÄ mitään tokeneita, joita ei ole nimenomaisesti myönnetty MCP-palvelimelle**

- **Tarkista ja kovenna valtuutuslogiikka:** Tarkista huolellisesti MCP-palvelimesi valtuutusmekanismit varmistaaksesi, että vain tarkoitetut käyttäjät ja asiakkaat pääsevät arkaluonteisiin resursseihin. Käytännön ohjeita löydät osoitteista [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) ja [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Noudata turvallisia token-käytäntöjä:** Seuraa [Microsoftin parhaita käytäntöjä tokenien validointiin ja elinkaareen](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) estääksesi access tokenien väärinkäytön ja vähentääksesi tokenin uudelleenkäytön tai varastamisen riskiä.
- **Suojaa tokenien tallennus:** Säilytä tokenit aina turvallisesti ja käytä salausta niiden suojaamiseksi levossa ja siirrossa. Toteutusvinkkejä löydät [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) -videolta.

# Liialliset oikeudet MCP-palvelimille

### Ongelman kuvaus  
MCP-palvelimille on voitu myöntää liialliset oikeudet palveluun tai resurssiin, johon ne pääsevät käsiksi. Esimerkiksi MCP-palvelin, joka on osa tekoälypohjaista myyntisovellusta ja yhdistyy yrityksen tietovarastoon, tulisi saada käyttöoikeudet rajattuna vain myyntitietoihin, eikä sen tulisi päästä kaikkiin tietovaraston tiedostoihin. Paluu vähimmän oikeuden periaatteeseen (yksi vanhimmista turvallisuusperiaatteista) tarkoittaa, että mikään resurssi ei saa oikeuksia enempää kuin mitä sen tehtävien suorittaminen vaatii. Tekoäly lisää haasteita, koska sen joustavuuden mahdollistamiseksi on vaikea määritellä tarkasti tarvittavat oikeudet.

### Riskit  
- Liiallisten oikeuksien myöntäminen voi mahdollistaa tietojen luvattoman siirron tai muokkaamisen, joihin MCP-palvelimen ei ollut tarkoitus päästä käsiksi. Tämä voi myös aiheuttaa yksityisyysongelmia, jos tiedot sisältävät henkilötietoja (PII).

### Lieventävät kontrollit  
- **Sovella vähimmän oikeuden periaatetta:** Myönnä MCP-palvelimelle vain ne vähimmäisoikeudet, jotka se tarvitsee tehtäviensä suorittamiseen. Tarkista ja päivitä oikeuksia säännöllisesti varmistaaksesi, etteivät ne ylitä tarpeellista. Yksityiskohtaiset ohjeet löytyvät [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access) -sivulta.
- **Käytä roolipohjaista käyttöoikeuksien hallintaa (RBAC):** Määritä MCP-palvelimelle roolit, jotka ovat tiukasti rajattuja tiettyihin resursseihin ja toimiin, välttäen laajoja tai tarpeettomia oikeuksia.
- **Seuraa ja auditoi oikeuksia:** Valvo jatkuvasti oikeuksien käyttöä ja tarkasta pääsylokit, jotta liialliset tai käyttämättömät oikeudet voidaan havaita ja korjata nopeasti.

# Epäsuorat prompt-injektiohyökkäykset

### Ongelman kuvaus

Vihamieliset tai vaarantuneet MCP-palvelimet voivat aiheuttaa merkittäviä riskejä paljastamalla asiakastietoja tai mahdollistamalla ei-toivottuja toimintoja. Nämä riskit ovat erityisen merkittäviä tekoäly- ja MCP-pohjaisissa kuormituksissa, joissa:

- **Prompt-injektiohyökkäykset:** Hyökkääjät upottavat haitallisia ohjeita kehotteisiin tai ulkoiseen sisältöön, mikä saa tekoälyjärjestelmän suorittamaan ei-toivottuja toimintoja tai vuotamaan arkaluonteisia tietoja. Lisätietoja: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Työkalujen myrkytys:** Hyökkääjät manipuloivat työkalujen metatietoja (kuten kuvauksia tai parametreja) vaikuttaakseen tekoälyn käyttäytymiseen, mahdollisesti kiertäen turvallisuusmekanismeja tai vuotamalla tietoja. Lisätietoja: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Ristiindomain prompt-injektio:** Haitalliset ohjeet upotetaan dokumentteihin, verkkosivuille tai sähköposteihin, jotka tekoäly sitten käsittelee, aiheuttaen tietovuotoja tai manipulointia.
- **Dynaaminen työkalumuokkaus (Rug Pulls):** Työkalumäärittelyjä voidaan muuttaa käyttäjän hyväksynnän jälkeen, mikä tuo uusia haitallisia toimintoja ilman käyttäjän tietoa.

Nämä haavoittuvuudet korostavat tarvetta vahvalle validoinnille, seurannalle ja turvallisuusmekanismeille, kun MCP-palvelimia ja työkaluja integroidaan ympäristöön. Syvällisempää tietoa löytyy yllä linkatuista lähteistä.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.fi.png)

**Epäsuora prompt-injektio** (tunnetaan myös nimellä ristiindomain prompt-injektio tai XPIA) on kriittinen haavoittuvuus generatiivisissa tekoälyjärjestelmissä, mukaan lukien MCP:tä käyttävät. Tässä hyökkäyksessä haitalliset ohjeet piilotetaan ulkoiseen sisältöön — kuten dokumentteihin, verkkosivuille tai sähköposteihin. Kun tekoäly käsittelee tätä sisältöä, se saattaa tulkita upotetut ohjeet laillisiksi käyttäjäkäskyiksi, mikä johtaa ei-toivottuihin toimintoihin, kuten tietovuotoihin, haitallisen sisällön luomiseen tai käyttäjävuorovaikutusten manipulointiin. Tarkempi selitys ja esimerkit löytyvät osoitteesta [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Erityisen vaarallinen muoto tästä hyökkäyksestä on **Työkalujen myrkytys**. Tässä hyökkääjät upottavat haitallisia ohjeita MCP-työkalujen metatietoihin (kuten työkalun kuvaukseen tai parametreihin). Koska suuret kielimallit (LLM) käyttävät näitä metatietoja päättääkseen, mitä työkaluja kutsutaan, vaarantuneet kuvaukset voivat huijata mallia suorittamaan luvattomia työkalukutsuja tai kiertämään turvallisuusmekanismeja. Nämä manipulaatiot ovat usein loppukäyttäjille näkymättömiä, mutta tekoälyjärjestelmä voi tulkita ja toimia niiden mukaan. Riski korostuu isännöidyissä MCP-palvelinympäristöissä, joissa työkalumäärittelyjä voidaan päivittää käyttäjän hyväksynnän jälkeen — tilannetta kutsutaan joskus "[rug pulliksi](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Tällöin aiemmin turvallinen työkalu voidaan myöhemmin muuttaa suorittamaan haitallisia toimintoja, kuten tietovuotoja tai järjestelmän käyttäytymisen muuttamista, ilman käyttäjän tietoa. Lisätietoja hyökkäysvektorista löytyy osoitteesta [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.fi.png)

## Riskit  
Ei-toivotut tekoälytoiminnot aiheuttavat monenlaisia turvallisuusriskejä, kuten tietovuotoja ja yksityisyyden loukkauksia.

### Lieventävät kontrollit  
### Prompt Shieldsin käyttö epäsuoria prompt-injektiohyökkäyksiä vastaan
-----------------------------------------------------------------------------

**AI Prompt Shields** on Microsoftin kehittämä ratkaisu, joka suojaa sekä suoria että epäsuoria prompt-injektiohyökkäyksiä vastaan. Ne auttavat
Confused deputy -ongelma on tietoturva-aukko, joka ilmenee, kun MCP-palvelin toimii välittäjänä MCP-asiakkaiden ja kolmansien osapuolten API:en välillä. Tätä haavoittuvuutta voidaan hyödyntää, kun MCP-palvelin käyttää staattista client ID:tä todennukseen kolmannen osapuolen valtuutuspalvelimella, joka ei tue dynaamista client-rekisteröintiä.

### Riskit

- **Evästeisiin perustuva suostumuksen ohitus**: Jos käyttäjä on aiemmin todennut itsensä MCP-välityspalvelimen kautta, kolmannen osapuolen valtuutuspalvelin saattaa asettaa suostumusevästeen käyttäjän selaimeen. Hyökkääjä voi myöhemmin hyödyntää tätä lähettämällä käyttäjälle haitallisen linkin, joka sisältää muokatun valtuutuspyynnön ja haitallisen uudelleenohjaus-URI:n.
- **Valtuutuskoodin varastaminen**: Kun käyttäjä klikkaa haitallista linkkiä, kolmannen osapuolen valtuutuspalvelin saattaa ohittaa suostumusnäytön olemassa olevan evästeen vuoksi, ja valtuutuskoodi voidaan ohjata hyökkääjän palvelimelle.
- **Luvaton API-käyttö**: Hyökkääjä voi vaihtaa varastetun valtuutuskoodin käyttöoikeustokeneiksi ja esiintyä käyttäjänä päästäkseen kolmannen osapuolen API:iin ilman nimenomaista lupaa.

### Haittojen ehkäisy

- **Nimenomaiset suostumusvaatimukset**: MCP-välityspalvelinten, jotka käyttävät staattisia client ID:itä, **TÄYTYY** hankkia käyttäjän suostumus jokaiselle dynaamisesti rekisteröidylle clientille ennen pyyntöjen välittämistä kolmannen osapuolen valtuutuspalvelimille.
- **Oikea OAuth-toteutus**: Noudata OAuth 2.1 -turvakäytäntöjä, mukaan lukien koodin haasteiden (PKCE) käyttö valtuutuspyynnöissä sieppaushyökkäysten estämiseksi.
- **Clientin validointi**: Toteuta tiukka uudelleenohjaus-URI:en ja client-tunnisteiden validointi estääksesi haitallisten toimijoiden hyväksikäytön.

# Token Passthrough -haavoittuvuudet

### Ongelman kuvaus

"Token passthrough" on anti-malli, jossa MCP-palvelin hyväksyy MCP-asiakkaalta tokeneita tarkistamatta, että tokenit on asianmukaisesti myönnetty juuri kyseiselle MCP-palvelimelle, ja "välittää" ne eteenpäin alaspäin meneville API:ille. Tämä käytäntö rikkoo MCP-valtuutusspezifikaatiota ja aiheuttaa vakavia tietoturvariskejä.

### Riskit

- **Turvavalvonnan kiertäminen**: Asiakkaat voivat ohittaa tärkeitä turvatoimia, kuten nopeusrajoituksia, pyyntöjen validointia tai liikenteen valvontaa, jos he voivat käyttää tokeneita suoraan alaspäin menevissä API:issa ilman asianmukaista validointia.
- **Vastuullisuus- ja auditointiongelmat**: MCP-palvelin ei pysty tunnistamaan tai erottamaan MCP-asiakkaita, kun asiakkaat käyttävät ylävirrasta myönnettyjä käyttöoikeustokeneita, mikä vaikeuttaa tapaustutkintaa ja auditointia.
- **Datan vuotaminen**: Jos tokeneita välitetään ilman asianmukaista vaatimusten validointia, varastetulla tokenilla varustettu hyökkääjä voi käyttää palvelinta datan vuotokanavana.
- **Luottamuksen rajojen rikkominen**: Alaspäin menevät resurssipalvelimet voivat myöntää luottamusta tietyille toimijoille oletuksilla alkuperästä tai käyttäytymismalleista. Tämän luottamuksen rikkoontuminen voi johtaa odottamattomiin tietoturvaongelmiin.
- **Monipalvelintokenien väärinkäyttö**: Jos tokeneita hyväksytään useissa palveluissa ilman asianmukaista validointia, hyökkääjä, joka on saanut haltuunsa yhden palvelun, voi käyttää tokenia päästäkseen muihin liitettyihin palveluihin.

### Haittojen ehkäisy

- **Tokenien validointi**: MCP-palvelimet **EIVÄT SAA** hyväksyä tokeneita, joita ei ole nimenomaisesti myönnetty kyseiselle MCP-palvelimelle.
- **Kohdeyleisön tarkistus**: Varmista aina, että tokeneissa on oikea audience-vaatimus, joka vastaa MCP-palvelimen identiteettiä.
- **Oikea tokenien elinkaaren hallinta**: Käytä lyhytikäisiä käyttöoikeustokeneita ja asianmukaisia tokenien kierrätyskäytäntöjä vähentääksesi tokenien varastamisen ja väärinkäytön riskiä.

# Istunnon kaappaus

### Ongelman kuvaus

Istunnon kaappaus on hyökkäys, jossa palvelin antaa asiakkaalle istunnon tunnisteen, ja luvaton osapuoli saa haltuunsa tämän saman istunnon tunnisteen ja käyttää sitä esiintyäkseen alkuperäisenä asiakkaana sekä suorittaakseen luvattomia toimintoja tämän puolesta. Tämä on erityisen huolestuttavaa tilallisia HTTP-palvelimia käsiteltäessä MCP-pyyntöjä.

### Riskit

- **Istunnon kaappauksen kehotteen injektio**: Hyökkääjä, joka saa istunnon tunnisteen, voi lähettää haitallisia tapahtumia palvelimelle, joka jakaa istuntotilan palvelimen kanssa, johon asiakas on yhteydessä, mahdollisesti laukaisten haitallisia toimintoja tai pääsyn arkaluontoisiin tietoihin.
- **Istunnon kaappauksen esiintyminen**: Hyökkääjä varastetulla istunnon tunnisteella voi tehdä suoria kutsuja MCP-palvelimelle ohittaen todennuksen ja esiintyä laillisena käyttäjänä.
- **Vialliset jatkettavat virrat**: Kun palvelin tukee uudelleenlähetystä tai jatkettavia virtoja, hyökkääjä voi keskeyttää pyynnön ennenaikaisesti, jolloin alkuperäinen asiakas jatkaa sitä myöhemmin mahdollisesti haitallisella sisällöllä.

### Haittojen ehkäisy

- **Valtuutuksen tarkistus**: MCP-palvelimet, jotka toteuttavat valtuutuksen, **TÄYTYY** tarkistaa kaikki saapuvat pyynnöt eikä **SAA** käyttää istuntoja todennukseen.
- **Turvalliset istunnon tunnisteet**: MCP-palvelimet **TÄYTYY** käyttää turvallisia, ei-deterministisiä istunnon tunnisteita, jotka on luotu turvallisilla satunnaislukugeneraattoreilla. Vältä ennustettavia tai peräkkäisiä tunnisteita.
- **Käyttäjäkohtainen istunnon sidonta**: MCP-palvelinten **TULISI** sitoa istunnon tunniste käyttäjäkohtaisiin tietoihin, yhdistäen istunnon tunniste käyttäjän yksilölliseen tietoon (kuten sisäinen käyttäjätunnus) muodossa `<user_id>:<session_id>`.
- **Istunnon vanheneminen**: Toteuta asianmukainen istunnon vanheneminen ja kierto rajoittaaksesi haavoittuvuusikkunaa, jos istunnon tunniste vaarantuu.
- **Siirtoturvallisuus**: Käytä aina HTTPS-yhteyttä kaiken viestinnän suojaamiseksi istunnon tunnisteen sieppaukselta.

# Toimitusketjun turvallisuus

Toimitusketjun turvallisuus on edelleen keskeistä tekoälyn aikakaudella, mutta toimitusketjun määritelmä on laajentunut. Perinteisten koodipakettien lisäksi sinun tulee nyt huolellisesti varmistaa ja valvoa kaikkia tekoälyyn liittyviä komponentteja, mukaan lukien perustamallit, upotepalvelut, kontekstin tarjoajat ja kolmannen osapuolen API:t. Jokainen näistä voi tuoda mukanaan haavoittuvuuksia tai riskejä, jos niitä ei hallita asianmukaisesti.

**Keskeiset toimitusketjun turvallisuuskäytännöt tekoälylle ja MCP:lle:**
- **Varmista kaikki komponentit ennen integrointia:** Tämä koskee paitsi avoimen lähdekoodin kirjastoja myös tekoälymalleja, tietolähteitä ja ulkoisia API:ita. Tarkista aina alkuperä, lisenssit ja tunnetut haavoittuvuudet.
- **Pidä käyttöönotto-putket turvallisina:** Käytä automatisoituja CI/CD-putkia, joissa on integroitu turvallisuusskannaus ongelmien havaitsemiseksi varhaisessa vaiheessa. Varmista, että vain luotettavat artefaktit otetaan tuotantoon.
- **Jatkuva valvonta ja auditointi:** Toteuta jatkuva valvonta kaikille riippuvuuksille, mukaan lukien mallit ja tietopalvelut, uusien haavoittuvuuksien tai toimitusketjuhyökkäysten havaitsemiseksi.
- **Vähimmän oikeuden periaate ja pääsynhallinta:** Rajoita pääsy malleihin, dataan ja palveluihin vain MCP-palvelimen toiminnan kannalta välttämättömään.
- **Nopea reagointi uhkiin:** Ota käyttöön prosessi vaarantuneiden komponenttien korjaamiseksi tai vaihtamiseksi sekä salaisuuksien tai tunnistetietojen kierrättämiseksi, jos tietomurto havaitaan.

[GitHub Advanced Security](https://github.com/security/advanced-security) tarjoaa ominaisuuksia kuten salaisuuksien skannaus, riippuvuuksien skannaus ja CodeQL-analyysi. Nämä työkalut integroituvat [Azure DevOpsin](https://azure.microsoft.com/en-us/products/devops) ja [Azure Reposin](https://azure.microsoft.com/en-us/products/devops/repos/) kanssa auttaen tiimejä tunnistamaan ja lieventämään haavoittuvuuksia sekä koodissa että tekoälyn toimitusketjun komponenteissa.

Microsoft toteuttaa myös laajamittaisia toimitusketjun turvallisuuskäytäntöjä sisäisesti kaikissa tuotteissaan. Lisätietoja löytyy [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Vakiintuneet tietoturvakäytännöt, jotka parantavat MCP-toteutuksesi turvallisuutta

Mikä tahansa MCP-toteutus perii organisaatiosi ympäristön olemassa olevan tietoturvaprofiilin, joten MCP:n tietoturvaa kokonaisuutena arvioidessasi on suositeltavaa parantaa myös yleistä tietoturvatasoa. Seuraavat vakiintuneet tietoturvakontrollit ovat erityisen merkityksellisiä:

- Turvallisen koodauksen parhaat käytännöt tekoälysovelluksessasi – suojaa [OWASP Top 10](https://owasp.org/www-project-top-ten/) -uhkia vastaan, [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), käytä turvallisia säilöjä salaisuuksille ja tokeneille, toteuta päästä päähän -turvallinen viestintä kaikkien sovelluskomponenttien välillä jne.
- Palvelimen koventaminen – käytä monivaiheista tunnistautumista (MFA) aina kun mahdollista, pidä päivitykset ajan tasalla, integroi palvelin kolmannen osapuolen identiteetin tarjoajan kanssa pääsyn hallintaan jne.
- Pidä laitteet, infrastruktuuri ja sovellukset ajan tasalla päivityksillä
- Turvallisuusvalvonta – toteuta lokitus ja valvonta tekoälysovellukselle (mukaan lukien MCP-asiakas/palvelimet) ja lähetä lokit keskitettyyn SIEM-järjestelmään poikkeavuuksien havaitsemiseksi
- Zero trust -arkkitehtuuri – eristä komponentit verkko- ja identiteettihallinnan avulla loogisesti minimoidaksesi sivuttaisliikkeet, jos tekoälysovellus vaarantuu.

# Keskeiset opit

- Turvallisuuden perusasiat ovat edelleen ratkaisevia: turvallinen koodaus, vähimmän oikeuden periaate, toimitusketjun varmistus ja jatkuva valvonta ovat välttämättömiä MCP:lle ja tekoälykuormille.
- MCP tuo mukanaan uusia riskejä, kuten kehotteen injektio, työkalujen myrkytys, istunnon kaappaus, confused deputy -ongelmat, token passthrough -haavoittuvuudet ja liialliset oikeudet, jotka vaativat sekä perinteisiä että tekoälyyn liittyviä kontrollitoimia.
- Käytä vahvaa todennusta, valtuutusta ja tokenien hallintaa hyödyntäen ulkoisia identiteetin tarjoajia kuten Microsoft Entra ID:tä aina kun mahdollista.
- Suojaa epäsuoralta kehotteen injektiolta ja työkalujen myrkytykseltä validoimalla työkalujen metatiedot, valvomalla dynaamisia muutoksia ja käyttämällä ratkaisuja kuten Microsoft Prompt Shields.
- Toteuta turvallinen istunnon hallinta käyttämällä ei-deterministisiä istunnon tunnisteita, sitomalla istunnot käyttäjäidentiteetteihin ja välttämällä istuntojen käyttöä todennuksessa.
- Estä confused deputy -hyökkäykset vaatimalla nimenomaista käyttäjän suostumusta jokaiselle dynaamisesti rekisteröidylle clientille ja toteuttamalla oikeat OAuth-turvakäytännöt.
- Vältä token passthrough -haavoittuvuudet varmistamalla, että MCP-palvelimet hyväksyvät vain nimenomaisesti itselleen myönnetyt tokenit ja validoivat tokenien vaatimukset asianmukaisesti.
- Kohtele kaikkia tekoälyn toimitusketjun komponentteja – mukaan lukien mallit, upotukset ja kontekstin tarjoajat – yhtä huolellisesti kuin koodiriippuvuuksia.
- Pysy ajan tasalla kehittyvistä MCP-spesifikaatioista ja osallistu yhteisöön auttaaksesi muokkaamaan turvallisia standardeja.

# Lisäresurssit

## Ulkoiset resurssit
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
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
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Lisäturvallisuusasiakirjat

Yksityiskohtaisempaa tietoturvaohjeistusta varten tutustu näihin asiakirjoihin:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) – Kattava lista MCP-toteutusten tietoturvakäytännöistä
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) – Esimerkkejä Azure Content Safen integroinnista MCP-palvelimiin
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) – Viimeisimmät tietoturvakontrollit ja -tekniikat MCP-järjestelmien suojaamiseen

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.