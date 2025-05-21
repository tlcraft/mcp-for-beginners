<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:40:30+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "fi"
}
-->
# Case Study: Azure AI Travel Agents – Reference Implementation

## Yleiskatsaus

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) on Microsoftin kehittämä kattava referenssiratkaisu, joka näyttää, miten rakentaa moniagenttinen, tekoälyllä toimiva matkan suunnittelusovellus käyttäen Model Context Protocolia (MCP), Azure OpenAI:ta ja Azure AI Searchia. Tämä projekti esittelee parhaita käytäntöjä useiden tekoälyagenttien orkestroinnissa, yritysdatan integroinnissa sekä turvallisen ja laajennettavan alustan tarjoamisessa todellisiin käyttötapauksiin.

## Keskeiset ominaisuudet
- **Moniagenttinen orkestrointi:** Käyttää MCP:tä erikoistuneiden agenttien (esim. lento-, hotelli- ja matkasuunnitteluagentit) koordinoimiseen, jotka tekevät yhteistyötä monimutkaisten matkan suunnittelutehtävien toteuttamiseksi.
- **Yritysdatan integrointi:** Yhdistää Azure AI Searchiin ja muihin yritysdatalähteisiin tarjoten ajantasaista ja relevanttia tietoa matkasuosituksiin.
- **Turvallinen ja skaalautuva arkkitehtuuri:** Hyödyntää Azure-palveluita autentikointiin, valtuutukseen ja skaalautuvaan käyttöönottoon noudattaen yritystason turvallisuuskäytäntöjä.
- **Laajennettavat työkalut:** Toteuttaa uudelleenkäytettäviä MCP-työkaluja ja kehotepohjia, jotka mahdollistavat nopean sopeutumisen uusiin toimialoihin tai liiketoimintavaatimuksiin.
- **Käyttäjäkokemus:** Tarjoaa keskustelupohjaisen käyttöliittymän, jonka kautta käyttäjät voivat olla vuorovaikutuksessa matka-agenttien kanssa, hyödyntäen Azure OpenAI:ta ja MCP:tä.

## Arkkitehtuuri
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Arkkitehtuurikaavion kuvaus

Azure AI Travel Agents -ratkaisu on suunniteltu modulaarisuutta, skaalautuvuutta ja turvallista integrointia silmällä pitäen useiden tekoälyagenttien ja yritysdatalähteiden kanssa. Pääkomponentit ja datan kulku ovat seuraavat:

- **Käyttöliittymä:** Käyttäjät ovat vuorovaikutuksessa järjestelmän kanssa keskustelupohjaisen käyttöliittymän (esim. verkkokeskustelu tai Teams-botti) kautta, joka lähettää käyttäjän kyselyt ja vastaanottaa matkasuositukset.
- **MCP-palvelin:** Toimii keskeisenä orkestroijana, vastaanottaa käyttäjän syötteen, hallinnoi kontekstia ja koordinoi erikoistuneiden agenttien (esim. FlightAgent, HotelAgent, ItineraryAgent) toimintaa Model Context Protocolin avulla.
- **Tekoälyagentit:** Jokainen agentti vastaa omasta osa-alueestaan (lennot, hotellit, matkasuunnitelmat) ja on toteutettu MCP-työkaluna. Agentit käyttävät kehotepohjia ja logiikkaa pyyntöjen käsittelyyn ja vastausten luomiseen.
- **Azure OpenAI -palvelu:** Tarjoaa kehittyneen luonnollisen kielen ymmärryksen ja generoinnin, jonka avulla agentit tulkitsevat käyttäjän tarkoituksen ja tuottavat keskustelumuotoisia vastauksia.
- **Azure AI Search & yritysdata:** Agentit hakevat Azure AI Searchista ja muista yritysdatalähteistä ajantasaista tietoa lennoista, hotelleista ja matkavaihtoehdoista.
- **Autentikointi & turvallisuus:** Integroituu Microsoft Entra ID:hen turvallista autentikointia varten ja soveltaa vähimmän oikeuden periaatetta kaikkiin resursseihin.
- **Käyttöönotto:** Suunniteltu käyttöön Azure Container Apps -ympäristössä, mikä takaa skaalautuvuuden, valvonnan ja operatiivisen tehokkuuden.

Tämä arkkitehtuuri mahdollistaa useiden tekoälyagenttien saumattoman orkestroinnin, turvallisen integroinnin yritysdatan kanssa sekä vankan ja laajennettavan alustan toimialakohtaisten tekoälyratkaisujen rakentamiseen.

## Arkkitehtuurikaavion vaiheittainen selitys
Kuvittele, että suunnittelet isoa matkaa ja sinulla on tiimi asiantuntija-avustajia auttamassa joka yksityiskohdassa. Azure AI Travel Agents -järjestelmä toimii samalla tavalla, käyttäen eri osia (kuten tiimin jäseniä), joilla jokaisella on oma erityistehtävänsä. Näin kaikki toimii yhdessä:

### Käyttöliittymä (UI):
Ajattele tätä matka-agenttisi vastaanottona. Siinä sinä (käyttäjä) esität kysymyksiä tai teet pyyntöjä, kuten ”Löydä lento Pariisiin.” Tämä voi olla chat-ikkuna verkkosivulla tai viestisovelluksessa.

### MCP-palvelin (Koordinaattori):
MCP-palvelin on kuin vastaanoton johtaja, joka kuuntelee pyyntöäsi ja päättää, kuka asiantuntija hoitaa minkäkin osan. Se seuraa keskustelua ja varmistaa, että kaikki sujuu sujuvasti.

### Tekoälyagentit (Asiantuntija-avustajat):
Jokainen agentti on oman alansa asiantuntija—yksi tuntee lennot, toinen hotellit ja kolmas matkasuunnitelmat. Kun pyydät matkaa, MCP-palvelin lähettää pyyntösi oikealle agentille tai agenteille. Nämä agentit käyttävät osaamistaan ja työkalujaan löytääkseen parhaat vaihtoehdot sinulle.

### Azure OpenAI -palvelu (Kieliasiantuntija):
Tämä on kuin kieliasiantuntija, joka ymmärtää täsmälleen, mitä pyydät, riippumatta siitä, miten sen muotoilet. Se auttaa agentteja ymmärtämään pyyntöjäsi ja vastaamaan luonnollisella, keskustelunomaisella kielellä.

### Azure AI Search & yritysdata (Tietokirjasto):
Kuvittele valtava, ajantasainen kirjasto, jossa on kaikki viimeisimmät matkailutiedot—lentoaikataulut, hotellien saatavuus ja muuta. Agentit etsivät tästä kirjastosta tarkimmat vastaukset sinulle.

### Autentikointi & turvallisuus (Turvamies):
Aivan kuten turvamies tarkistaa, kuka pääsee tietyille alueille, tämä osa varmistaa, että vain valtuutetut henkilöt ja agentit pääsevät käsiksi arkaluonteisiin tietoihin. Se pitää tietosi turvassa ja yksityisinä.

### Käyttöönotto Azure Container Appsissa (Rakennus):
Kaikki nämä avustajat ja työkalut toimivat yhdessä turvallisessa ja skaalautuvassa rakennuksessa (pilvessä). Tämä tarkoittaa, että järjestelmä pystyy palvelemaan monta käyttäjää samanaikaisesti ja on aina käytettävissä, kun sitä tarvitset.

## Miten kaikki toimii yhdessä:

Aloitat esittämällä kysymyksen vastaanotossa (UI).
Johtaja (MCP-palvelin) päättää, kuka asiantuntija (agentti) auttaa sinua.
Asiantuntija käyttää kieliasiantuntijaa (OpenAI) ymmärtämään pyyntösi ja kirjastoa (AI Search) löytämään parhaan vastauksen.
Turvamies (autentikointi) varmistaa, että kaikki on turvallista.
Kaikki tapahtuu luotettavassa, skaalautuvassa rakennuksessa (Azure Container Apps), joten käyttökokemuksesi on sujuva ja turvallinen.
Tämä tiimityöskentely mahdollistaa järjestelmän nopean ja turvallisen avun matkasuunnittelussa, aivan kuin joukko asiantuntevia matka-agentteja työskentelisi yhdessä modernissa toimistossa!

## Tekninen toteutus
- **MCP-palvelin:** Isännöi keskeistä orkestrointilogiikkaa, tarjoaa agenttityökaluja ja hallinnoi kontekstia monivaiheisissa matkasuunnitteluprosesseissa.
- **Agentit:** Jokainen agentti (esim. FlightAgent, HotelAgent) on toteutettu MCP-työkaluna omine kehotepohjineen ja logiikoineen.
- **Azure-integraatio:** Käyttää Azure OpenAI:ta luonnollisen kielen ymmärtämiseen ja Azure AI Searchia tiedon hakemiseen.
- **Turvallisuus:** Integroituu Microsoft Entra ID:hen autentikointia varten ja soveltaa vähimmän oikeuden periaatetta kaikkiin resursseihin.
- **Käyttöönotto:** Tukee käyttöönottoa Azure Container Appsissa skaalautuvuuden ja operatiivisen tehokkuuden takaamiseksi.

## Tulokset ja vaikutus
- Havainnollistaa, miten MCP:tä voidaan käyttää useiden tekoälyagenttien orkestrointiin todellisessa, tuotantotason ympäristössä.
- Nopeuttaa ratkaisun kehitystä tarjoamalla uudelleenkäytettäviä malleja agenttien koordinointiin, dataintegrointiin ja turvalliseen käyttöönottoon.
- Toimii mallina toimialakohtaisten, tekoälyllä tehostettujen sovellusten rakentamiseen käyttäen MCP:tä ja Azure-palveluita.

## Viitteet
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttäen tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattikäännöksissä voi esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa mahdollisista väärinymmärryksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.