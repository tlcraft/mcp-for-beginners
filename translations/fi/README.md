<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26ab12045ee411ab7ad0eb0b1b7b1cbb",
  "translation_date": "2025-06-13T00:12:41+00:00",
  "source_file": "README.md",
  "language_code": "fi"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.fi.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Seuraa näitä ohjeita aloittaaksesi näiden resurssien käytön:
1. **Forkkaa repositorio**: Klikkaa [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Kloonaa repositorio**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Liity Azure AI Foundry Discordiin ja tapaa asiantuntijoita sekä muita kehittäjiä**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Monikielinen tuki

#### Tuettu GitHub Actionin kautta (automaattinen ja aina ajan tasalla)

# 🚀 Model Context Protocol (MCP) Aloittelijoille

## **Opiskele MCP:tä käytännön koodiesimerkkien avulla C#, Java, JavaScript, Python ja TypeScript -kielillä**

## 🧠 Yleiskatsaus Model Context Protocol -opintokokonaisuuteen

**Model Context Protocol (MCP)** on huipputason kehys, joka on suunniteltu vakioimaan vuorovaikutukset AI-mallien ja asiakasohjelmistojen välillä. Tämä avoimen lähdekoodin opintokokonaisuus tarjoaa jäsennellyn oppimispolun, joka sisältää käytännön koodiesimerkkejä ja todellisia käyttötapauksia suosituilla ohjelmointikielillä, kuten C#, Java, JavaScript, TypeScript ja Python.

Oletpa sitten AI-kehittäjä, järjestelmäarkkitehti tai ohjelmistoinsinööri, tämä opas on kattava resurssi MCP:n perusteiden ja toteutusstrategioiden hallintaan.

## 🔗 Viralliset MCP-resurssit

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Yksityiskohtaiset opetusohjelmat ja käyttäjäoppaat  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Protokollan arkkitehtuuri ja tekniset viitteet  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Avoimen lähdekoodin SDK:t, työkalut ja koodiesimerkit  

## 🧭 MCP-opintokokonaisuuden rakenne

| Ch | Otsikko | Kuvaus | Linkki |
|--|--|--|--|
| 00 | **Johdanto MCP:hen** | Yleiskatsaus Model Context Protocoliin ja sen merkitykseen AI-putkistoissa, mukaan lukien mitä MCP on, miksi standardisointi on tärkeää sekä käytännön käyttötapaukset ja hyödyt | [Johdanto](./00-Introduction/README.md) |
| 01 | **Keskeiset käsitteet selitettynä** | Syvällinen katsaus MCP:n keskeisiin käsitteisiin, kuten asiakas-palvelin-arkkitehtuuriin, protokollan tärkeisiin osiin ja viestintämalleihin | [Keskeiset käsitteet](./01-CoreConcepts/README.md) |
| 02 | **Turvallisuus MCP:ssä** | Turvauhkien tunnistaminen MCP-pohjaisissa järjestelmissä, menetelmät ja parhaat käytännöt toteutusten suojaamiseen | [Turvallisuus](/02-Security/README.md) |
| 03 | **Aloita MCP:n kanssa** | Ympäristön asennus ja konfigurointi, perus MCP-palvelinten ja -asiakkaiden luominen, MCP:n integrointi olemassa oleviin sovelluksiin | [Aloita](./03-GettingStarted/README.md) |
| 3.1 | **Ensimmäinen palvelin** | Peruspalvelimen pystyttäminen MCP-protokollalla, palvelin-asiakas-vuorovaikutuksen ymmärtäminen ja palvelimen testaaminen | [Ensimmäinen palvelin](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Ensimmäinen asiakas**  | Perusasiakkaan pystyttäminen MCP-protokollalla, asiakas-palvelin-vuorovaikutuksen ymmärtäminen ja asiakkaan testaaminen | [Ensimmäinen asiakas](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Asiakas LLM:n kanssa**  | Asiakkaan pystyttäminen MCP-protokollalla käyttäen suurta kielimallia (LLM) | [Asiakas LLM:n kanssa](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Palvelimen käyttäminen Visual Studio Codella** | Visual Studio Coden konfigurointi MCP-protokollaa käyttävien palvelimien kuluttamiseen | [Palvelimen käyttäminen Visual Studio Codella](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Palvelimen luominen SSE:n avulla** | SSE:n avulla palvelin saadaan julkistettua internetiin. Tämä osio opastaa palvelimen luomisessa SSE:n avulla | [Palvelimen luominen SSE:llä](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **AI Toolkitin käyttö** | AI Toolkit on erinomainen työkalu, joka auttaa hallitsemaan AI- ja MCP-työnkulkuasi | [AI Toolkitin käyttö](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Palvelimen testaaminen** | Testaus on tärkeä osa kehitysprosessia. Tässä osiossa opit käyttämään useita eri testausvälineitä | [Palvelimen testaaminen](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Palvelimen käyttöönotto** | Miten siirryt paikallisesta kehityksestä tuotantoon? Tämä osio opastaa palvelimen kehittämisessä ja käyttöönotossa | [Palvelimen käyttöönotto](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Käytännön toteutus** | SDK:iden käyttö eri kielillä, virheenkorjaus, testaus ja validointi, uudelleenkäytettävien prompt-pohjien ja työnkulkujen luominen | [Käytännön toteutus](./04-PracticalImplementation/README.md) |
| 05 | **Edistyneet MCP-aiheet** | Monimodaaliset AI-työnkulut ja laajennettavuus, turvalliset skaalausstrategiat, MCP yritysympäristöissä | [Edistyneet aiheet](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP:n integrointi Azureen** | Näyttää integraation Azureen | [MCP Azure-integraatio](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Monimodaalisuus** | Kuinka työskennellä eri modaliteettien, kuten kuvien kanssa | [Monimodaalisuus](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 -demo** | Minimikehys Spring Boot -sovelluksesta, joka näyttää OAuth2:n MCP:n kanssa, sekä Authorization- että Resource Serverinä. Demonstroi turvallista tokenin myöntämistä, suojattuja päätepisteitä, Azure Container Apps -käyttöönottoa ja API Management -integraatiota | [MCP OAuth2 -demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Lisätietoa root contextista ja sen toteuttamisesta | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Reititys** | Eri reititystyypit | [Reititys](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Näytteenotto** | Kuinka työskennellä näytteenoton kanssa | [Näytteenotto](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skaalaus** | MCP-palvelinten skaalaus, mukaan lukien vaakasuora ja pystysuora skaalaus, resurssien optimointi ja suorituskyvyn hienosäätö | [Skaalaus](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Turvallisuus** | MCP-palvelimen suojaaminen, mukaan lukien autentikointi, valtuutus ja datan suojausstrategiat | [Turvallisuus](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web-haku MCP:llä** | Python MCP -palvelin ja asiakas, jotka integroivat SerpAPI:n reaaliaikaiseen web-, uutis-, tuotehakuun ja Q&A-toimintoihin. Demonstroi monityökalujen orkestrointia, ulkoisten API:en integraatiota ja vankkaa virheenkäsittelyä | [Web-haku MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Reaaliaikainen suoratoisto** | Reaaliaikainen datan suoratoisto on nykyajan dataohjautuvassa maailmassa välttämätöntä, kun yritykset ja sovellukset tarvitsevat välitöntä pääsyä tietoihin tehdäkseen oikea-aikaisia päätöksiä | [Reaaliaikainen suoratoisto](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Reaaliaikainen web-haku** | Kuinka MCP muuttaa reaaliaikaista web-hakua tarjoamalla vakioidun lähestymistavan kontekstinhallintaan AI-mallien, hakukoneiden ja sovellusten välillä | [Reaaliaikainen web-haku](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Yhteisön panokset** | Kuinka osallistua koodin ja dokumentaation tekemiseen, yhteistyö GitHubissa, yhteisölähtöiset parannukset ja palaute | [Yhteisön panokset](./06-CommunityContributions/README.md) |
| 07 | **Oppeja varhaisesta käyttöönotosta** | Käytännön toteutukset ja toimineet ratkaisut, MCP-pohjaisten ratkaisujen rakentaminen ja käyttöönotto, trendit ja tulevaisuuden tiekartta | [Oppeja](./07-LessonsFromEarlyAdoption/README.md)
| 08 | **Parhaat käytännöt MCP:lle** | Suorituskyvyn viritys ja optimointi, vikasietoisien MCP-järjestelmien suunnittelu, testaus- ja kestävyyden varmistamisstrategiat | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP-tapaustutkimukset** | Syvällisiä katsauksia MCP-ratkaisujen arkkitehtuureihin, käyttöönoton mallipohjiin ja integraatiovinkkeihin, selitettyjä kaavioita ja projektikierroksia | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **AI-työnkulkujen tehostaminen: MCP-palvelimen rakentaminen AI Toolkitin avulla** | Kattava käytännön työpaja, jossa yhdistetään MCP ja Microsoftin AI Toolkit VS Codeen. Opit rakentamaan älykkäitä sovelluksia, jotka yhdistävät AI-mallit todellisiin työkaluihin käytännön moduulien kautta, jotka käsittelevät perusteita, räätälöityä palvelinkehitystä ja tuotantoon siirtymisen strategioita. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Esimerkkiprojektit

### 🧮 MCP-laskin esimerkkiprojektit:
<details>
  <summary><strong>Tutustu koodiesimerkkeihin kielittäin</strong></summary>

  - [C# MCP Server Example](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Calculator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Example](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP-edistyneet laskinprojektit:
<details>
  <summary><strong>Tutustu edistyneisiin esimerkkeihin</strong></summary>

  - [Advanced C# Sample](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container App Example](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript Advanced Sample](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Complex Implementation](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Sample](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 MCP:n oppimisen ennakkovaatimukset

Saadaksesi tästä oppimateriaalista parhaan hyödyn, sinulla tulisi olla:

- Perustiedot C#:stä, Javasta tai Pythonista
- Ymmärrys asiakas-palvelin -mallista ja API:sta
- (Valinnainen) Tutustuminen koneoppimisen käsitteisiin

## 📚 Opas opiskeluun

Laaja [Opas opiskeluun](./study_guide.md) auttaa sinua liikkumaan tässä repossa tehokkaasti. Opas sisältää:

- Visuaalisen opetussuunnitelmakartan kaikista aiheista
- Yksityiskohtaisen erittelyn repossa käsitellyistä osioista
- Ohjeet esimerkkiprojektien käyttöön
- Suositellut oppimispolut eri taitotasoille
- Lisäresursseja oppimismatkan tueksi

## 🛠️ Kuinka käyttää tätä opetussuunnitelmaa tehokkaasti

Jokainen tämän oppaan oppitunti sisältää:

1. Selkeät selitykset MCP-käsitteistä  
2. Live-koodiesimerkkejä useilla kielillä  
3. Harjoituksia oikeiden MCP-sovellusten rakentamiseen  
4. Lisäresursseja edistyneille oppijoille  

## 📜 Lisenssitiedot

Tämä sisältö on lisensoitu **MIT-lisenssillä**. Ehdot ja käyttöoikeudet löydät tiedostosta [LICENSE](../../LICENSE).

## 🤝 Osallistumisohjeet

Tämä projekti ottaa mielellään vastaan panoksia ja ehdotuksia. Useimmat panokset edellyttävät, että hyväksyt
Contributor License Agreementin (CLA), jossa vahvistat oikeutesi ja myönnät meille oikeudet käyttää panostasi. Lisätietoja löytyy osoitteesta <https://cla.opensource.microsoft.com>.

Kun lähetät pull requestin, CLA-botti arvioi automaattisesti, tarvitseeko sinun toimittaa CLA ja merkitsee PR:n asianmukaisesti (esim. tilantarkistus, kommentti). Noudata vain botin ohjeita. Tämä riittää tekemään vain kerran kaikissa CLA:a käyttävissä repossa.

Tämä projekti on ottanut käyttöön [Microsoft Open Source Code of Conductin](https://opensource.microsoft.com/codeofconduct/).
Lisätietoja löytyy [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) -sivulta tai ota yhteyttä osoitteeseen [opencode@microsoft.com](mailto:opencode@microsoft.com) lisäkysymyksiä tai kommentteja varten.

## 🎒 Muut kurssit
Tiimimme tarjoaa myös muita kursseja! Tutustu:

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using JavaScript](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [ML for Beginners](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [Data Science for Beginners](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [AI for Beginners](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [Cybersecurity for Beginners](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [Web Dev for Beginners](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [IoT for Beginners](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [XR Development for Beginners](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for AI Paired Programming](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for C#/.NET Developers](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Choose Your Own Copilot Adventure](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Tavaramerkki-ilmoitus

Tämä projekti saattaa sisältää tavaramerkkejä tai logoja projekteihin, tuotteisiin tai palveluihin liittyen. Microsoftin tavaramerkkien tai logojen luvallinen käyttö edellyttää ja noudattaa
[Microsoftin tavaramerkki- ja brändiohjeita](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Microsoftin tavaramerkkien tai logojen käyttö tässä projektin muokatuissa versioissa ei saa aiheuttaa sekaannusta tai antaa vaikutelmaa Microsoftin sponsoroimasta.
Kolmansien osapuolien tavaramerkkien tai logojen käyttö on näiden osapuolien sääntöjen alaista.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ole hyvä ja huomioi, että automaattikäännöksissä voi esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulee pitää auktoritatiivisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa mahdollisista väärinymmärryksistä tai tulkinnoista, jotka johtuvat tämän käännöksen käytöstä.