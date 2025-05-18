<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:30:25+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "fi"
}
-->
# Tapaustutkimus: Azure AI Travel Agents – Viiteimplementaatio

## Yleiskatsaus

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) on Microsoftin kehittämä kattava viiteratkaisu, joka osoittaa, miten rakentaa monen agentin, tekoälypohjainen matkasuunnittelusovellus käyttämällä Model Context Protocolia (MCP), Azure OpenAI:ta ja Azure AI Searchia. Tämä projekti esittelee parhaat käytännöt useiden tekoälyagenttien orkestroinnissa, yritystiedon integroinnissa ja turvallisen, laajennettavan alustan tarjoamisessa todellisiin skenaarioihin.

## Keskeiset ominaisuudet
- **Monen agentin orkestrointi:** Hyödyntää MCP:tä koordinoidakseen erikoistuneita agentteja (esim. lento-, hotelli- ja matkasuunnitelma-agentit), jotka tekevät yhteistyötä monimutkaisten matkasuunnittelutehtävien toteuttamiseksi.
- **Yritystiedon integrointi:** Yhdistää Azure AI Searchiin ja muihin yritystiedon lähteisiin tarjotakseen ajankohtaista ja relevanttia tietoa matkasuosituksiin.
- **Turvallinen, skaalautuva arkkitehtuuri:** Hyödyntää Azuren palveluita autentikointiin, valtuutukseen ja skaalautuvaan käyttöönottoon, noudattaen yrityksen turvallisuusparhaita käytäntöjä.
- **Laajennettavat työkalut:** Toteuttaa uudelleenkäytettäviä MCP-työkaluja ja kehotemalleja, mahdollistaa nopean mukauttamisen uusiin toimialoihin tai liiketoimintavaatimuksiin.
- **Käyttäjäkokemus:** Tarjoaa keskusteluliittymän käyttäjille matkatoimistojen kanssa vuorovaikutukseen, Azure OpenAI:n ja MCP:n voimin.

## Arkkitehtuuri
![Arkkitehtuuri](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Arkkitehtuurikaavion kuvaus

Azure AI Travel Agents -ratkaisu on suunniteltu moduulisuuden, skaalautuvuuden ja turvallisen integraation vuoksi useiden tekoälyagenttien ja yritystiedon lähteiden kanssa. Pääkomponentit ja tietovirta ovat seuraavat:

- **Käyttöliittymä:** Käyttäjät ovat vuorovaikutuksessa järjestelmän kanssa keskusteluliittymän kautta (kuten verkkokeskustelu tai Teams-botti), joka lähettää käyttäjäkyselyitä ja vastaanottaa matkasuosituksia.
- **MCP-palvelin:** Toimii keskeisenä orkestroijana, vastaanottaa käyttäjän syötteen, hallitsee kontekstia ja koordinoi erikoistuneiden agenttien (esim. FlightAgent, HotelAgent, ItineraryAgent) toimia Model Context Protocolin avulla.
- **Tekoälyagentit:** Jokainen agentti vastaa tietystä alueesta (lennot, hotellit, matkasuunnitelmat) ja toteutetaan MCP-työkaluna. Agentit käyttävät kehotemalleja ja logiikkaa käsitelläkseen pyyntöjä ja luodakseen vastauksia.
- **Azure OpenAI -palvelu:** Tarjoaa edistyneen luonnollisen kielen ymmärryksen ja generoinnin, mikä mahdollistaa agenttien tulkita käyttäjän tarkoitusta ja luoda keskustelullisia vastauksia.
- **Azure AI Search & Yritystieto:** Agentit tekevät kyselyitä Azure AI Searchiin ja muihin yritystiedon lähteisiin saadakseen ajankohtaista tietoa lennoista, hotelleista ja matkavaihtoehdoista.
- **Autentikointi & Turvallisuus:** Integroituu Microsoft Entra ID:hen turvalliseen autentikointiin ja soveltaa vähimmän oikeuden pääsyn valvontaa kaikille resursseille.
- **Käyttöönotto:** Suunniteltu käyttöönotettavaksi Azure Container Appsissa, mikä varmistaa skaalautuvuuden, valvonnan ja operatiivisen tehokkuuden.

Tämä arkkitehtuuri mahdollistaa saumattoman useiden tekoälyagenttien orkestroinnin, turvallisen integraation yritystiedon kanssa ja vankan, laajennettavan alustan toimialakohtaisten tekoälyratkaisujen rakentamiseen.

## Arkkitehtuurikaavion vaiheittainen selitys
Kuvittele suunnittelevasi suurta matkaa ja sinulla on joukko asiantuntija-avustajia auttamassa joka yksityiskohdassa. Azure AI Travel Agents -järjestelmä toimii samalla tavalla, käyttäen eri osia (kuten tiimin jäseniä), joilla on jokaisella erityinen tehtävä. Näin se kaikki sopii yhteen:

### Käyttöliittymä (UI):
Ajattele tätä matkatoimistosi vastaanottona. Se on paikka, jossa sinä (käyttäjä) esität kysymyksiä tai teet pyyntöjä, kuten "Etsi minulle lento Pariisiin." Tämä voisi olla chat-ikkuna verkkosivustolla tai viestisovelluksessa.

### MCP-palvelin (Koordinaattori):
MCP-palvelin on kuin johtaja, joka kuuntelee pyyntöäsi vastaanotolla ja päättää, mikä asiantuntija hoitaa kunkin osan. Se pitää kirjaa keskustelustasi ja varmistaa, että kaikki sujuu kitkattomasti.

### Tekoälyagentit (Erikoisavustajat):
Jokainen agentti on asiantuntija tietyllä alueella—yksi tietää kaiken lennoista, toinen hotelleista ja kolmas matkasuunnitelmien laatimisesta. Kun pyydät matkaa, MCP-palvelin lähettää pyyntösi oikealle agentille. Nämä agentit käyttävät tietämystään ja työkalujaan löytääkseen sinulle parhaat vaihtoehdot.

### Azure OpenAI -palvelu (Kieliasiantuntija):
Tämä on kuin kieliasiantuntija, joka ymmärtää tarkalleen, mitä pyydät, riippumatta siitä, miten sen muotoilet. Se auttaa agentteja ymmärtämään pyyntöjäsi ja vastaamaan luonnollisella, keskustelullisella kielellä.

### Azure AI Search & Yritystieto (Tietokirjasto):
Kuvittele valtava, ajantasainen kirjasto, jossa on kaikki viimeisimmät matkailutiedot—lentoaikataulut, hotellien saatavuus ja paljon muuta. Agentit etsivät tästä kirjastosta saadakseen sinulle tarkimmat vastaukset.

### Autentikointi & Turvallisuus (Turvamies):
Aivan kuten turvamies tarkistaa, ketkä voivat päästä tiettyihin alueisiin, tämä osa varmistaa, että vain valtuutetut henkilöt ja agentit pääsevät käsiksi arkaluontoisiin tietoihin. Se pitää tietosi turvassa ja yksityisenä.

### Käyttöönotto Azure Container Appsissa (Rakennus):
Kaikki nämä avustajat ja työkalut toimivat yhdessä turvallisessa, skaalautuvassa rakennuksessa (pilvessä). Tämä tarkoittaa, että järjestelmä voi käsitellä paljon käyttäjiä kerralla ja on aina käytettävissä, kun tarvitset sitä.

## Kuinka kaikki toimii yhdessä:

Aloitat esittämällä kysymyksen vastaanotolla (UI).
Johtaja (MCP-palvelin) selvittää, mikä asiantuntija (agentti) voi auttaa sinua.
Asiantuntija käyttää kieliasiantuntijaa (OpenAI) ymmärtääkseen pyyntösi ja kirjastoa (AI Search) löytääkseen parhaan vastauksen.
Turvamies (Autentikointi) varmistaa, että kaikki on turvallista.
Kaikki tämä tapahtuu luotettavassa, skaalautuvassa rakennuksessa (Azure Container Apps), joten kokemuksesi on sujuva ja turvallinen.
Tämä tiimityö mahdollistaa järjestelmän nopean ja turvallisen avun matkan suunnittelussa, aivan kuten asiantuntijamatkatoimistojen tiimi, joka työskentelee yhdessä modernissa toimistossa!

## Tekninen toteutus
- **MCP-palvelin:** Isännöi keskeistä orkestrointilogikkaa, paljastaa agenttityökaluja ja hallitsee kontekstia monivaiheisissa matkasuunnittelutyönkuluissa.
- **Agentit:** Jokainen agentti (esim. FlightAgent, HotelAgent) toteutetaan MCP-työkaluna omilla kehotemalleilla ja logiikalla.
- **Azure-integraatio:** Käyttää Azure OpenAI:ta luonnollisen kielen ymmärtämiseen ja Azure AI Searchia tiedonhakuun.
- **Turvallisuus:** Integroituu Microsoft Entra ID:hen autentikointia varten ja soveltaa vähimmän oikeuden pääsyn valvontaa kaikille resursseille.
- **Käyttöönotto:** Tukee käyttöönottoa Azure Container Appsissa skaalautuvuuden ja operatiivisen tehokkuuden vuoksi.

## Tulokset ja vaikutus
- Osoittaa, miten MCP:tä voidaan käyttää useiden tekoälyagenttien orkestrointiin todellisessa, tuotantovalmiissa skenaariossa.
- Kiihdyttää ratkaisun kehitystä tarjoamalla uudelleenkäytettäviä malleja agenttien koordinointiin, tiedon integrointiin ja turvalliseen käyttöönottoon.
- Toimii mallina toimialakohtaisten, tekoälypohjaisten sovellusten rakentamiseen MCP:n ja Azure-palveluiden avulla.

## Viitteet
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttäen tekoälykäännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta ole tietoinen, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää auktoriteettisena lähteenä. Kriittisen tiedon kohdalla suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinkäsityksistä tai virhetulkinnoista.