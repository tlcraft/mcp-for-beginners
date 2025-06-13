<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3b97186cd9162b9fe9b90261e63e32d",
  "translation_date": "2025-06-13T14:17:19+00:00",
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
1. **Forkkaa arkisto**: Klikkaa [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Kloonaa arkisto**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Liity Azure AI Foundry Discordiin ja tapaa asiantuntijoita sekä muita kehittäjiä**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Monikielinen tuki

#### Tuettu GitHub Actionin kautta (automaattinen ja aina ajan tasalla)

# 🚀 Model Context Protocol (MCP) Opetussuunnitelma Aloittelijoille

## **Opi MCP käytännön koodiesimerkkien avulla C#:ssa, Javassa, JavaScriptissä, Pythonissa ja TypeScriptissä**

## 🧠 Yleiskatsaus Model Context Protocol -opetussuunnitelmaan

**Model Context Protocol (MCP)** on edistyksellinen kehys, jonka tarkoituksena on standardoida vuorovaikutus AI-mallien ja asiakasohjelmien välillä. Tämä avoimen lähdekoodin opetussuunnitelma tarjoaa jäsennellyn oppimispolun, joka sisältää käytännön koodiesimerkkejä ja todellisia käyttötapauksia suosituilla ohjelmointikielillä, kuten C#, Java, JavaScript, TypeScript ja Python.

Olitpa sitten AI-kehittäjä, järjestelmäarkkitehti tai ohjelmistosuunnittelija, tämä opas on kattava resurssi MCP:n perusteiden ja toteutusstrategioiden hallintaan.

## 🔗 Viralliset MCP-resurssit

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Yksityiskohtaiset opetusohjelmat ja käyttäjäoppaat  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Protokollan arkkitehtuuri ja tekniset viitteet  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Avoimen lähdekoodin SDK:t, työkalut ja koodiesimerkit  

## 🧭 MCP-opetussuunnitelman kokonaisrakenne

| Ch | Otsikko | Kuvaus | Linkki |
|--|--|--|--|
| 00 | **Johdanto MCP:hen** | Yleiskatsaus Model Context Protocoliin ja sen merkitykseen AI-putkistoissa, mukaan lukien mitä MCP on, miksi standardisointi on tärkeää sekä käytännön esimerkit ja hyödyt | [Johdanto](./00-Introduction/README.md) |
| 01 | **Keskeiset käsitteet selitettynä** | Syvällinen katsaus MCP:n keskeisiin käsitteisiin, kuten asiakas-palvelin-arkkitehtuuriin, protokollan tärkeimpiin osiin ja viestintämalleihin | [Keskeiset käsitteet](./01-CoreConcepts/README.md) |
| 02 | **Turvallisuus MCP:ssä** | Turvauhkien tunnistaminen MCP-pohjaisissa järjestelmissä, tekniikat ja parhaat käytännöt turvallisen toteutuksen varmistamiseksi | [Turvallisuus](./02-Security/README.md) |
| 03 | **MCP:n käyttöönotto** | Ympäristön asennus ja konfigurointi, perus MCP-palvelinten ja -asiakkaiden luominen, MCP:n integrointi olemassa oleviin sovelluksiin | [Käyttöönotto](./03-GettingStarted/README.md) |
| 3.1 | **Ensimmäinen palvelin** | Peruspalvelimen pystyttäminen MCP-protokollalla, palvelin-asiakas-vuorovaikutuksen ymmärtäminen ja palvelimen testaaminen | [Ensimmäinen palvelin](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Ensimmäinen asiakas** | Perusasiakkaan pystyttäminen MCP-protokollalla, asiakas-palvelin-vuorovaikutuksen ymmärtäminen ja asiakkaan testaaminen | [Ensimmäinen asiakas](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Asiakas LLM:n kanssa** | Asiakkaan luominen MCP-protokollalla, jossa käytetään suurta kielimallia (LLM) | [Asiakas LLM:n kanssa](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Palvelimen käyttäminen Visual Studio Codella** | Visual Studio Coden asetukset MCP-protokollaa käyttäville palvelimille | [Palvelimen käyttäminen Visual Studio Codella](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Palvelimen luominen SSE:n avulla** | SSE:n avulla palvelimen avaaminen internetiin. Tämä osio auttaa sinua luomaan palvelimen SSE:n avulla | [Palvelimen luominen SSE:llä](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP-suoratoisto** | Opettele toteuttamaan HTTP-suoratoistoa reaaliaikaiseen tiedonsiirtoon asiakkaiden ja MCP-palvelinten välillä | [HTTP-suoratoisto](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **AI Toolkitin käyttö** | AI Toolkit on erinomainen työkalu, joka auttaa hallitsemaan AI- ja MCP-työnkulkuasi | [AI Toolkitin käyttö](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Palvelimen testaaminen** | Testaus on tärkeä osa kehitysprosessia. Tämä osio auttaa sinua testaamaan useilla eri työkaluilla | [Palvelimen testaaminen](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Palvelimen käyttöönotto** | Miten siirryt paikallisesta kehityksestä tuotantoon? Tämä osio opastaa palvelimen kehittämisessä ja käyttöönotossa | [Palvelimen käyttöönotto](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Käytännön toteutus** | SDK:iden käyttö eri kielillä, virheenkorjaus, testaus ja validointi, uudelleenkäytettävien prompt-mallien ja työnkulkujen luominen | [Käytännön toteutus](./04-PracticalImplementation/README.md) |
| 05 | **Edistyneet MCP-aiheet** | Monimodaaliset AI-työnkulut ja laajennettavuus, turvalliset skaalausstrategiat, MCP yritysympäristöissä | [Edistyneet aiheet](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP:n integrointi Azureen** | Näyttää integroinnin Azureen | [MCP Azure -integrointi](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Monimodaalisuus** | Näyttää miten työskennellä eri modaliteettien, kuten kuvien kanssa | [Monimodaalisuus](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimipitkä Spring Boot -sovellus, joka näyttää OAuth2:n MCP:n kanssa sekä valtuutus- että resurssipalvelimena. Demonstroi turvallista tokenin myöntämistä, suojattuja päätepisteitä, Azure Container Apps -käyttöönottoa ja API Management -integraatiota | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Opettele lisää root contextista ja sen toteuttamisesta | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Reititys** | Opettele erilaiset reititystyypit | [Reititys](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Näytteenotto** | Opettele työskentelemään näytteenoton kanssa | [Näytteenotto](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skaalaus** | Opettele MCP-palvelinten skaalaamista, mukaan lukien horisontaaliset ja vertikaaliset skaalausstrategiat, resurssien optimointi ja suorituskyvyn hienosäätö | [Skaalaus](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Turvallisuus** | Suojaa MCP-palvelimesi, mukaan lukien autentikointi, valtuutus ja datan suojausstrategiat | [Turvallisuus](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web-haku MCP:llä** | Python MCP -palvelin ja asiakas, jotka integroivat SerpAPI:n reaaliaikaiseen web-, uutis-, tuotehakuun ja kysymyksiin & vastauksiin. Demonstroi monityökalun orkestrointia, ulkoisten API:en integraatiota ja vahvaa virheenkäsittelyä | [Web-haku MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Reaaliaikainen suoratoisto** | Reaaliaikainen tiedonsuoratoisto on nykypäivän datalähtöisessä maailmassa välttämätöntä, kun yritykset ja sovellukset tarvitsevat välitöntä pääsyä tietoon tehdäksensä oikea-aikaisia päätöksiä | [Reaaliaikainen suoratoisto](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Reaaliaikainen web-haku** | Miten MCP muuttaa reaaliaikaista web-hakua tarjoamalla standardoidun lähestymistavan kontekstinhallintaan AI-mallien, hakukoneiden ja sovellusten välillä | [Reaaliaikainen web-haku](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Yhteisön panokset** | Kuinka osallistua koodin ja dokumentaation kehittämiseen, yhteistyö GitHubissa, yhteisölähtöiset parannukset ja palaute | [Yhteisön panokset](./06-CommunityContributions/README.md) |
| 07 | **Oivalluksia varhaisesta käyttöönotosta** | Käytännön toteutuksia ja toimineita ratkaisuja, MCP-pohjaisten ratkaisujen rakentaminen ja käyttöönotto, trendit ja tulevaisuuden tiekartta | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Parhaat käytännöt MCP:lle** | Suorituskyvyn viritys ja optimointi, vikankestävien MCP-järjestelmien suunnittelu, testaus- ja palautumisen strategiat | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP-tapaustutkimukset** | Syväsukelluksia MCP-ratkaisuarkkitehtuureihin, käyttöönoton suunnitelmiin ja integraatiovinkkeihin, selitetyt kaaviot ja projektien läpikäynnit | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **AI-työnkulkujen virtaviivaistaminen: MCP-palvelimen rakentaminen AI Toolkitin avulla** | Kattava käytännön työpaja, jossa yhdistetään MCP Microsoftin AI Toolkitin kanssa VS Codessa. Opit rakentamaan älykkäitä sovelluksia, jotka yhdistävät AI-mallit todellisiin työkaluihin käytännön moduulien kautta, jotka kattavat perusteet, mukautetun palvelinkehityksen ja tuotantoon käyttöönoton strategiat. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

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

### 💡 MCP-edistynyt laskinprojektit:
<details>
  <summary><strong>Tutustu edistyneisiin esimerkkeihin</strong></summary>

  - [Advanced C# Sample](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container App Example](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript Advanced Sample](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Complex Implementation](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Sample](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 MCP:n oppimisen edellytykset

Jotta saat tästä oppimateriaalista parhaan hyödyn, sinulla tulisi olla:

- Perustiedot C#:stä, Javasta tai Pythonista  
- Ymmärrys asiakas-palvelin-mallista ja API:sta  
- (Valinnainen) Tuntemus koneoppimisen peruskäsitteistä  

## 📚 Opas

Laaja [Opas](./study_guide.md) on saatavilla auttamaan sinua navigoimaan tässä repossa tehokkaasti. Opas sisältää:

- Visuaalisen opetussuunnitelmakartan, jossa kaikki käsitellyt aiheet  
- Yksityiskohtaisen jaon repositorion osioista  
- Ohjeita esimerkkiprojektien käyttöön  
- Suositeltuja oppimispolkuja eri taitotasoille  
- Lisäresursseja oppimismatkasi tueksi  

## 🛠️ Kuinka käyttää tätä opetussuunnitelmaa tehokkaasti

Jokainen tämän oppaan oppitunti sisältää:

1. Selkeät selitykset MCP-konsepteista  
2. Live-koodiesimerkkejä useilla kielillä  
3. Harjoituksia todellisten MCP-sovellusten rakentamiseen  
4. Lisäresursseja edistyneille oppijoille  

## 📜 Lisenssitiedot

Tämä sisältö on lisensoitu **MIT-lisenssillä**. Ehdot ja vaatimukset löydät tiedostosta [LICENSE](../../LICENSE).

## 🤝 Osallistumisohjeet

Tämä projekti toivottaa tervetulleeksi osallistumiset ja ehdotukset. Useimmat osallistumiset edellyttävät, että hyväksyt
Contributor License Agreementin (CLA), jossa vahvistat oikeutesi ja suostumuksesi antaa meille oikeudet käyttää panostasi. Lisätietoja löydät osoitteesta <https://cla.opensource.microsoft.com>.

Kun lähetät pull requestin, CLA-botti arvioi automaattisesti, tarvitsetko CLA:n ja merkitsee PR:n asianmukaisesti (esim. statustarkistus, kommentti). Noudata vain botin antamia ohjeita. Tämä toimenpide tarvitsee tehdä vain kerran kaikissa CLA:ta käyttävissä repokokonaisuuksissa.

Tämä projekti on omaksunut [Microsoftin avoimen lähdekoodin käytöskoodin](https://opensource.microsoft.com/codeofconduct/). Lisätietoja löydät [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) -sivulta tai ota yhteyttä osoitteeseen [opencode@microsoft.com](mailto:opencode@microsoft.com) lisäkysymyksiä tai kommentteja varten.

## 🎒 Muut kurssit
Tiimimme tuottaa myös muita kursseja! Tutustu:

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


## ™️ Tavaramerkkitiedote

Tämä projekti saattaa sisältää tavaramerkkejä tai logoja projekteihin, tuotteisiin tai palveluihin liittyen. Microsoftin tavaramerkkien tai logojen luvallinen käyttö edellyttää ja noudattaa
[Microsoftin tavaramerkki- ja brändiohjeita](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Microsoftin tavaramerkkien tai logojen käyttö tämän projektin muokatuissa versioissa ei saa aiheuttaa sekaannusta eikä antaa vaikutelmaa Microsoftin sponsoroinnista.
Kolmansien osapuolten tavaramerkkien tai logojen käyttö on kyseisten osapuolten sääntöjen alaista.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ota huomioon, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää auktoritatiivisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa mahdollisista väärinymmärryksistä tai tulkinnoista, jotka johtuvat tämän käännöksen käytöstä.