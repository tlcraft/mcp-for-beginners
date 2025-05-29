<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:25:14+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "fi"
}
-->
# Security Best Practices

Model Context Protocolin (MCP) käyttöönotto tuo tekoälypohjaisiin sovelluksiin tehokkaita uusia ominaisuuksia, mutta myös ainutlaatuisia turvallisuushaasteita, jotka ylittävät perinteiset ohjelmistoriskit. Vakiintuneiden asioiden, kuten turvallisen koodauksen, vähimmän oikeuden periaatteen ja toimitusketjun turvallisuuden lisäksi MCP- ja tekoälykuormitukset kohtaavat uusia uhkia, kuten prompttien injektoinnin, työkalujen myrkytyksen ja dynaamisen työkalumuokkauksen. Näihin riskeihin liittyy tietovuotoja, yksityisyyden loukkauksia ja odottamattomia järjestelmäkäyttäytymisiä, jos niitä ei hallita asianmukaisesti.

Tässä oppitunnissa käsitellään MCP:hen liittyviä keskeisimpiä turvallisuusriskejä — kuten todennus, valtuutus, liialliset käyttöoikeudet, epäsuora prompttien injektointi ja toimitusketjun haavoittuvuudet — sekä tarjotaan käytännön hallintakeinoja ja parhaita käytäntöjä niiden lieventämiseksi. Opit myös hyödyntämään Microsoftin ratkaisuja, kuten Prompt Shields, Azure Content Safety ja GitHub Advanced Security, vahvistaaksesi MCP-toteutustasi. Näiden kontrollien ymmärtäminen ja soveltaminen auttaa merkittävästi vähentämään tietoturvaloukkauksen riskiä ja varmistamaan, että tekoälyjärjestelmäsi pysyvät luotettavina ja kestävinä.

# Learning Objectives

Tämän oppitunnin lopuksi osaat:

- Tunnistaa ja selittää Model Context Protocolin (MCP) aiheuttamat ainutlaatuiset turvallisuusriskit, kuten prompttien injektoinnin, työkalujen myrkytyksen, liialliset käyttöoikeudet ja toimitusketjun haavoittuvuudet.
- Kuvailla ja soveltaa tehokkaita lieventäviä toimenpiteitä MCP:n turvallisuusriskeihin, kuten vahvaa todennusta, vähimmän oikeuden periaatetta, turvallista tokenien hallintaa ja toimitusketjun varmistusta.
- Ymmärtää ja hyödyntää Microsoftin ratkaisuja, kuten Prompt Shields, Azure Content Safety ja GitHub Advanced Security, MCP:n ja tekoälykuormitusten suojaamiseen.
- Tunnistaa työkalumetadatan validoinnin, dynaamisten muutosten seurannan ja epäsuorien prompttien injektointihyökkäysten torjunnan merkityksen.
- Sisällyttää vakiintuneita turvallisuusparhaita käytäntöjä — kuten turvallinen koodaus, palvelimen koventaminen ja zero trust -arkkitehtuuri — MCP-toteutukseesi vähentääksesi tietoturvaloukkausten todennäköisyyttä ja vaikutuksia.

# MCP security controls

Järjestelmillä, joilla on pääsy tärkeisiin resursseihin, on luonnollisesti turvallisuushaasteita. Turvallisuusongelmat voidaan yleensä ratkaista soveltamalla oikein perusturvallisuuskontrolleja ja -periaatteita. Koska MCP on vasta hiljattain määritelty, sen spesifikaatio muuttuu nopeasti ja protokolla kehittyy. Lopulta siihen sisältyvät turvallisuuskontrollit kypsyvät, mikä mahdollistaa paremman integraation yritystason ja vakiintuneiden turvallisuusarkkitehtuurien ja parhaiden käytäntöjen kanssa.

[Microsoft Digital Defense Report](https://aka.ms/mddr) -raportin mukaan 98 % raportoituista tietomurroista olisi estettävissä vahvalla turvallisuushygienialla. Paras suoja minkä tahansa loukkauksen varalta onkin saada perusturvallisuushygienia, turvallisen koodauksen parhaat käytännöt ja toimitusketjun turvallisuus kuntoon — ne tutkitut ja testatut käytännöt, jotka jo tiedämme, ovat edelleen tehokkaimpia turvallisuusriskien vähentämisessä.

Katsotaanpa joitakin tapoja, joilla voit aloittaa turvallisuusriskien käsittelyn MCP:n käyttöönotossa.

> **Note:** Seuraavat tiedot ovat voimassa **29. toukokuuta 2025**. MCP-protokolla kehittyy jatkuvasti, ja tulevat toteutukset voivat tuoda uusia todennusmalleja ja kontrollikeinoja. Viimeisimmät päivitykset ja ohjeet löydät aina [MCP Specification](https://spec.modelcontextprotocol.io/), virallisesta [MCP GitHub repository](https://github.com/modelcontextprotocol) ja [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices) -sivuilta.

### Problem statement  
Alkuperäinen MCP-spesifikaatio oletti, että kehittäjät kirjoittaisivat oman todennuspalvelimensa. Tämä edellytti OAuthiin ja siihen liittyviin turvallisuusrajoitteisiin perehtymistä. MCP-palvelimet toimivat OAuth 2.0 -valtuutuspalvelimina, hoitaen käyttäjän todennuksen suoraan sen sijaan, että delegoisivat sen ulkoiselle palvelulle, kuten Microsoft Entra ID:lle. Päivityksen myötä 26.4.2025 alkaen MCP-palvelimet voivat delegoida käyttäjien todennuksen ulkoiselle palvelulle.

### Risks
- MCP-palvelimen valtuutuslogiikan väärä konfigurointi voi johtaa arkaluontoisen tiedon vuotamiseen ja virheellisiin käyttöoikeuksiin.
- OAuth-tokenin varastaminen paikalliselta MCP-palvelimelta. Jos token varastetaan, sitä voidaan käyttää esiintymään MCP-palvelimena ja pääsemään käsiksi palvelun resursseihin ja tietoihin, joita token koskee.

#### Token Passthrough  
Tokenin suora välitys on valtuutusspesifikaatiossa nimenomaan kielletty, koska se aiheuttaa useita turvallisuusriskejä, kuten:

#### Turvallisuuskontrollien ohittaminen  
MCP-palvelin tai alavirran API:t voivat toteuttaa tärkeitä turvakontrolleja, kuten pyyntöjen rajoituksia, validointia tai liikenteen seurantaa, jotka perustuvat tokenin kohdeyleisöön tai muihin tunnistetietoihin. Jos asiakkaat voivat saada ja käyttää tokeneita suoraan alavirran API:en kanssa ilman, että MCP-palvelin validoi niitä oikein tai varmistaa, että tokenit on myönnetty oikealle palvelulle, nämä kontrollit ohitetaan.

#### Vastuu ja auditointiongelmat  
MCP-palvelin ei pysty tunnistamaan tai erottamaan MCP-asiakkaita, kun asiakkaat kutsuvat ylävirran myönnetyllä access tokenilla, joka voi olla MCP-palvelimelle läpinäkymätön.  
Alavirran resurssipalvelimen lokit saattavat näyttää pyyntöjä, jotka vaikuttavat tulevan eri lähteestä eri identiteetillä kuin MCP-palvelimelta, joka oikeasti välittää tokenit.  
Molemmat tekijät vaikeuttavat tapaustutkintaa, kontrollien toimeenpanoa ja auditointia.  
Jos MCP-palvelin välittää tokeneita ilman niiden väitteiden (esim. roolit, oikeudet tai kohdeyleisö) tai muun metadatan validointia, pahantahtoinen toimija, jolla on varastettu token, voi käyttää palvelinta välityspalvelimena tietovuotoon.

#### Luottamusrajat  
Alavirran resurssipalvelin luottaa tiettyihin tahoihin. Tämä luottamus voi sisältää oletuksia alkuperästä tai asiakaskäyttäytymismalleista. Tämän luottamusrajan rikkominen voi johtaa odottamattomiin ongelmiin.  
Jos token hyväksytään useissa palveluissa ilman asianmukaista validointia, hyökkääjä, joka on kompromissannut yhden palvelun, voi käyttää tokenia päästäkseen muihin yhdistettyihin palveluihin.

#### Tulevaisuuden yhteensopivuusriski  
Vaikka MCP-palvelin aloittaisi tänään “puhtaana välityspalvelimena”, sen saattaa myöhemmin olla tarpeen lisätä turvakontrolleja. Oikean tokenin kohdeyleisön erottelun aloittaminen helpottaa turvallisuusmallin kehittämistä.

### Mitigating controls

**MCP-palvelimet EIVÄT SAA HYVÄKSYÄ tokenia, joita ei nimenomaisesti ole myönnetty MCP-palvelimelle**

- **Tarkasta ja vahvista valtuutuslogiikka:** Tarkasta huolellisesti MCP-palvelimesi valtuutus toteutus varmistaaksesi, että vain tarkoitetut käyttäjät ja asiakkaat pääsevät arkaluontoisiin resursseihin. Käytännön ohjeita löydät [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) ja [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/) -artikkeleista.
- **Noudattakaa turvallisia token-käytäntöjä:** Noudata [Microsoftin parhaita käytäntöjä tokenien validointiin ja elinkaareen](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) estääksesi tokenien väärinkäytön ja vähentääksesi tokenin toistokäytön tai varastamisen riskiä.
- **Suojaa tokenien tallennus:** Säilytä tokenit aina turvallisesti ja käytä salausmenetelmiä niiden suojaamiseksi levossa ja siirrossa. Toteutusvinkkejä löydät [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) -videolta.

# Excessive permissions for MCP servers

### Problem statement  
MCP-palvelimille on voitu myöntää liialliset käyttöoikeudet palveluun tai resurssiin, johon ne pääsevät käsiksi. Esimerkiksi MCP-palvelin, joka on osa tekoälypohjaista myyntisovellusta ja yhdistyy yrityksen tietovarastoon, tulisi rajata pääsy myyntitietoihin eikä sallia pääsyä kaikkiin varaston tiedostoihin. Viitaten vähimmän oikeuden periaatteeseen (yksi vanhimmista turvallisuusperiaatteista), mikään resurssi ei saisi saada käyttöoikeuksia, jotka ylittävät sen tarvitsemat tehtävät. Tekoäly tuo tähän haasteita, koska joustavuuden mahdollistamiseksi on vaikeaa määritellä tarkasti tarvittavat oikeudet.

### Risks  
- Liiallisten käyttöoikeuksien myöntäminen voi mahdollistaa tietovuodot tai tietojen muokkaamisen, joihin MCP-palvelimen ei ollut tarkoitus päästä käsiksi. Tämä voi olla myös yksityisyysongelma, jos data sisältää henkilötietoja (PII).

### Mitigating controls  
- **Sovella vähimmän oikeuden periaatetta:** Myönnä MCP-palvelimelle vain välttämättömät oikeudet sen tehtävien suorittamiseen. Tarkista ja päivitä käyttöoikeuksia säännöllisesti varmistaaksesi, etteivät ne ylitä tarpeellista. Tarkempia ohjeita löydät [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access) -sivulta.
- **Käytä roolipohjaista käyttöoikeuksien hallintaa (RBAC):** Määrittele MCP-palvelimelle roolit, jotka ovat tiukasti rajattuja tiettyihin resursseihin ja toimiin, välttäen laajoja tai tarpeettomia oikeuksia.
- **Valvo ja auditoi käyttöoikeuksia:** Seuraa jatkuvasti käyttöoikeuksien käyttöä ja auditointilokeja havaitaksesi ja korjataksesi liialliset tai käyttämättömät oikeudet nopeasti.

# Indirect prompt injection attacks

### Problem statement

Pahantahtoiset tai kompromissatut MCP-palvelimet voivat aiheuttaa merkittäviä riskejä paljastamalla asiakastietoja tai sallimalla ei-toivottuja toimintoja. Nämä riskit ovat erityisen merkittäviä tekoäly- ja MCP-pohjaisissa kuormituksissa, joissa:

- **Prompt Injection -hyökkäykset:** Hyökkääjät upottavat haitallisia ohjeita kehotteisiin tai ulkoiseen sisältöön, saaden tekoälyn suorittamaan ei-toivottuja toimintoja tai vuotamaan arkaluontoisia tietoja. Lisätietoja: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Hyökkääjät manipuloivat työkalujen metadataa (kuten kuvauksia tai parametreja) vaikuttaakseen tekoälyn käyttäytymiseen, mahdollisesti ohittaen turvakontrollit tai vuotaen tietoja. Lisätietoja: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Ristiin-domain prompttien injektointi:** Haitalliset ohjeet upotetaan dokumentteihin, verkkosivuille tai sähköposteihin, joita tekoäly sitten käsittelee, johtuen tietovuotoihin tai manipulointiin.
- **Dynaaminen työkalumuokkaus (Rug Pulls):** Työkalumäärittelyjä voidaan muuttaa käyttäjän hyväksynnän jälkeen, tuoden uusia haitallisia toimintoja ilman käyttäjän tietämystä.

Nämä haavoittuvuudet korostavat tarvetta vahvalle validoinnille, seurannalle ja turvallisuuskontrolleille, kun MCP-palvelimia ja työkaluja integroidaan ympäristöösi. Syvällisempää tietoa löydät yllä olevista linkeistä.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.fi.png)

**Epäsuora prompttien injektointi** (tunnetaan myös nimellä ristiindomain prompttien injektointi tai XPIA) on kriittinen haavoittuvuus generatiivisissa tekoälyjärjestelmissä, mukaan lukien MCP:tä käyttävät. Tässä hyökkäyksessä haitalliset ohjeet piilotetaan ulkoiseen sisältöön — kuten dokumentteihin, verkkosivuille tai sähköposteihin. Kun tekoäly käsittelee tätä sisältöä, se saattaa tulkita upotetut ohjeet laillisiksi käyttäjän komennoiksi, mikä johtaa ei-toivottuihin toimintoihin, kuten tietovuotoihin, haitallisen sisällön luomiseen tai käyttäjävuorovaikutuksen manipulointiin. Tarkempi selitys ja käytännön esimerkit löytyvät osoitteesta [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Erityisen vaarallinen hyökkäysmuoto on **Tool Poisoning**. Tässä hyökkääjät injektoivat haitallisia ohjeita MCP-työkalujen metadataan (kuten työkalun kuvaukseen tai parametreihin). Koska suuret kielimallit (LLM) käyttävät tätä metadataa päättäessään, mitä työkaluja kutsua, manipuloidut kuvaukset voivat huijata mallia suorittamaan valtuuttamattomia työkalukutsuja tai ohittamaan turvakontrollit. Nämä manipulaatiot ovat usein loppukäyttäjille näkymättömiä, mutta tekoälyjärjestelmä voi tulkita ja toimia niiden mukaan. Riski korostuu isännöidyissä MCP-palvelinympäristöissä, joissa työkalumäärittelyjä voidaan päivittää käyttäjän hyväksynnän jälkeen — tilannetta kutsutaan joskus "rug pulliksi" ([rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)). Tällöin aiemmin turvallinen työkalu voidaan myöhemmin muuttaa suorittamaan haitallisia toimintoja, kuten tietovuotoja tai järjestelmän käyttäytymisen muuttamista, ilman käyttäjän tietoa. Lisätietoa tästä hyökkäysvektorista löytyy [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks) -artikkelista.

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.fi.png)

## Risks  
Ei-toivotut tekoälytoiminnot aiheuttavat monenlaisia turvallisuusriskejä, kuten tietovuotoja ja yksityisyysloukkauksia.

### Mitigating controls  
### Prompt Shieldsien käyttö epäsuoria prompttien injektointihyökkäyksiä vastaan  
-----------------------------------------------------------------------------

**AI Prompt Shields** ovat Microsoftin kehittämä ratkaisu, joka suojaa sekä suoralta että epäsuoralta prompttien injektoinnilta. Ne auttavat seuraavilla tavoilla:

1.  **Havaitseminen ja suodatus:** Prompt Shields hyödyntävät edistynyttä koneoppimista ja luonnollisen kielen käsittelyä tunnistaakseen ja suodattaakseen haitalliset ohjeet, jotka on upotettu ulkoiseen sisältöön, kuten dokumentteihin, verkkosivuille tai sähköposteihin.
    
2.  **Spotlighting:** Tämä tekniikka auttaa tekoälyä erottamaan pätevät järjestelmäohjeet mahdollisesti epäluotettavista ulkoisista syötteistä. Muokkaamalla syötteen tekstiä mallille merkityksellisemmäksi Spotlighting
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

Seuraava: [Luku 3: Aloittaminen](/03-GettingStarted/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää auktoritatiivisena lähteenä. Tärkeiden tietojen osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.