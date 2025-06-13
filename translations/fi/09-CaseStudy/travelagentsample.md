<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:49:34+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "fi"
}
-->
# Case Study: Azure AI Travel Agents – Reference Implementation

## Yleiskatsaus

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) on Microsoftin kehittämä kattava referenssiratkaisu, joka osoittaa, miten rakentaa moniagenttipohjainen, tekoälyllä tehostettu matkasuunnittelusovellus käyttäen Model Context Protocolia (MCP), Azure OpenAI:ta ja Azure AI Searchia. Tämä projekti esittelee parhaita käytäntöjä useiden tekoälyagenttien koordinointiin, yritystietojen integrointiin sekä turvallisen ja laajennettavan alustan tarjoamiseen todellisiin käyttötapauksiin.

## Keskeiset ominaisuudet
- **Moniagenttien koordinointi:** Käyttää MCP:tä erikoistuneiden agenttien (esim. lento-, hotelli- ja matkareittiagentit) yhteistoiminnan ohjaamiseen monimutkaisten matkasuunnittelutehtävien toteuttamiseksi.
- **Yritystietojen integrointi:** Yhdistää Azure AI Searchiin ja muihin yritystietolähteisiin tarjotakseen ajantasaisia ja relevantteja matkasuosituksia.
- **Turvallinen ja skaalautuva arkkitehtuuri:** Hyödyntää Azure-palveluita autentikointiin, valtuutukseen ja skaalautuvaan käyttöönottoon noudattaen yritysturvallisuuden parhaita käytäntöjä.
- **Laajennettavat työkalut:** Toteuttaa uudelleenkäytettäviä MCP-työkaluja ja kehotemalleja, jotka mahdollistavat nopean sopeutumisen uusiin toimialoihin tai liiketoimintavaatimuksiin.
- **Käyttäjäkokemus:** Tarjoaa keskustelupohjaisen käyttöliittymän, jonka kautta käyttäjät voivat olla vuorovaikutuksessa matkailuagenttien kanssa, hyödyntäen Azure OpenAI:ta ja MCP:tä.

## Arkkitehtuuri
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Arkkitehtuurikaavion kuvaus

Azure AI Travel Agents -ratkaisu on suunniteltu modulaarisuutta, skaalautuvuutta ja turvallista integrointia varten useiden tekoälyagenttien ja yritystietolähteiden välillä. Keskeiset komponentit ja tietovirrat ovat seuraavat:

- **Käyttöliittymä:** Käyttäjät ovat vuorovaikutuksessa järjestelmän kanssa keskustelupohjaisen käyttöliittymän kautta (esim. verkkokeskustelu tai Teams-botti), joka lähettää käyttäjän kyselyt ja vastaanottaa matkasuositukset.
- **MCP-palvelin:** Toimii keskeisenä koordinaattorina vastaanottaen käyttäjän syötteen, halliten kontekstia ja ohjaten erikoistuneiden agenttien (esim. FlightAgent, HotelAgent, ItineraryAgent) toimintaa Model Context Protocolin avulla.
- **Tekoälyagentit:** Kukin agentti vastaa omasta toimialueestaan (lennot, hotellit, matkareitit) ja on toteutettu MCP-työkaluna. Agentit käyttävät kehotemalleja ja logiikkaa pyyntöjen käsittelyyn ja vastausten luomiseen.
- **Azure OpenAI -palvelu:** Tarjoaa kehittynyttä luonnollisen kielen ymmärrystä ja tuottamista, mahdollistaen agenttien tulkita käyttäjän tarkoitus ja luoda keskustelumuotoisia vastauksia.
- **Azure AI Search & yritystiedot:** Agentit hakevat Azure AI Searchista ja muista yritystietolähteistä ajantasaisia tietoja lennoista, hotelleista ja matkavaihtoehdoista.
- **Autentikointi ja turvallisuus:** Integroituu Microsoft Entra ID:hen turvallista tunnistautumista varten ja soveltaa vähimmän oikeuden periaatetta kaikkiin resursseihin.
- **Käyttöönotto:** Suunniteltu käytettäväksi Azure Container Apps -ympäristössä, mikä takaa skaalautuvuuden, valvonnan ja operatiivisen tehokkuuden.

Tämä arkkitehtuuri mahdollistaa saumattoman moniagenttien koordinoinnin, turvallisen integroinnin yritystietoihin sekä vahvan ja laajennettavan alustan toimialakohtaisten tekoälyratkaisujen rakentamiseen.

## Arkkitehtuurikaavion vaiheittainen selitys
Kuvittele, että suunnittelet isoa matkaa ja sinulla on tiimi asiantuntija-avustajia auttamassa joka vaiheessa. Azure AI Travel Agents -järjestelmä toimii samalla tavalla, käyttäen eri osia (kuin tiimin jäseniä), joilla jokaisella on oma erityistehtävänsä. Näin kokonaisuus toimii:

### Käyttöliittymä (UI):
Ajattele tätä kuin matkailuagenttisi vastaanottoa. Siellä sinä (käyttäjä) esität kysymyksiä tai teet pyyntöjä, kuten ”Etsi lento Pariisiin.” Tämä voi olla verkkosivun chat-ikkuna tai viestisovellus.

### MCP-palvelin (Koordinaattori):
MCP-palvelin on kuin johtaja, joka kuuntelee pyyntöäsi vastaanotossa ja päättää, kuka asiantuntijoista hoitaa minkäkin osan. Se seuraa keskustelua ja varmistaa, että kaikki sujuu joustavasti.

### Tekoälyagentit (Erikoisasiantuntijat):
Jokainen agentti on oman alansa asiantuntija—yksi tuntee lennot, toinen hotellit ja kolmas matkareittien suunnittelun. Kun pyydät matkaa, MCP-palvelin lähettää pyyntösi oikealle agentille tai agenteille. Nämä agentit käyttävät tietämystään ja työkalujaan löytääkseen sinulle parhaat vaihtoehdot.

### Azure OpenAI -palvelu (Kieliasiantuntija):
Tämä on kuin kieliasiantuntija, joka ymmärtää tarkasti, mitä tarkoitat, riippumatta siitä, miten ilmaiset sen. Se auttaa agentteja ymmärtämään pyyntösi ja vastaamaan luonnollisella, keskustelullisella kielellä.

### Azure AI Search & yritystiedot (Tietokirjasto):
Kuvittele valtava, ajantasainen kirjasto, jossa on kaikki viimeisimmät matkailutiedot—lentoaikataulut, hotellien saatavuus ja muuta. Agentit etsivät tästä kirjastosta tarkimmat vastaukset sinulle.

### Autentikointi ja turvallisuus (Turvamies):
Kuten turvamies tarkistaa, kuka pääsee tiettyihin tiloihin, tämä osa varmistaa, että vain valtuutetut henkilöt ja agentit pääsevät käsiksi arkaluontoisiin tietoihin. Se pitää tietosi turvassa ja yksityisinä.

### Käyttöönotto Azure Container Appsissa (Rakennus):
Kaikki nämä avustajat ja työkalut toimivat yhdessä turvallisessa, skaalautuvassa rakennuksessa (pilvessä). Tämä tarkoittaa, että järjestelmä pystyy palvelemaan monia käyttäjiä samanaikaisesti ja on aina käytettävissä, kun sitä tarvitset.

## Miten kaikki toimii yhdessä:

Aloitat kysymyksellä vastaanotossa (UI).
Johtaja (MCP-palvelin) päättää, mikä asiantuntija (agentti) auttaa sinua.
Asiantuntija käyttää kieliasiantuntijaa (OpenAI) ymmärtämään pyyntösi ja kirjastoa (AI Search) löytääkseen parhaan vastauksen.
Turvamies (autentikointi) varmistaa, että kaikki on turvallista.
Kaikki tapahtuu luotettavassa, skaalautuvassa rakennuksessa (Azure Container Apps), joten käyttökokemus on sujuva ja turvallinen.
Tämä tiimityöskentely mahdollistaa järjestelmän nopean ja turvallisen avun matkasuunnittelussa, aivan kuin asiantunteva matkailutiimi työskentelisi yhdessä nykyaikaisessa toimistossa!

## Tekninen toteutus
- **MCP-palvelin:** Isännöi keskeistä orkestrointilogiikkaa, tarjoaa agenttityökaluja ja hallinnoi kontekstia monivaiheisissa matkasuunnitteluprosesseissa.
- **Agentit:** Kukin agentti (esim. FlightAgent, HotelAgent) on toteutettu MCP-työkaluna omine kehotemalleineen ja logiikoineen.
- **Azure-integraatio:** Käyttää Azure OpenAI:ta luonnollisen kielen ymmärtämiseen ja Azure AI Searchia tiedonhakuun.
- **Turvallisuus:** Integroituu Microsoft Entra ID:hen tunnistautumista varten ja soveltaa vähimmän oikeuden periaatetta kaikkiin resursseihin.
- **Käyttöönotto:** Tukee käyttöönottoa Azure Container Appsissa skaalautuvuuden ja operatiivisen tehokkuuden takaamiseksi.

## Tulokset ja vaikutus
- Havainnollistaa, miten MCP:tä voidaan käyttää useiden tekoälyagenttien koordinointiin todellisessa, tuotantovalmiissa ympäristössä.
- Nopeuttaa ratkaisun kehitystä tarjoamalla uudelleenkäytettäviä malleja agenttien koordinointiin, tiedon integrointiin ja turvalliseen käyttöönottoon.
- Toimii pohjana toimialakohtaisten, tekoälyllä tehostettujen sovellusten rakentamiseen MCP:n ja Azure-palveluiden avulla.

## Viitteet
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty tekoälypohjaisella käännöspalvelulla [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ole hyvä ja huomioi, että automaattikäännöksissä voi esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää auktoritatiivisena lähteenä. Tärkeissä tiedoissa suositellaan ammattilaisen tekemää ihmiskäännöstä. Emme ole vastuussa tästä käännöksestä aiheutuvista väärinkäsityksistä tai virhetulkinnoista.