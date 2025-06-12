<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c7fbf0cdaa44b3245daff0c8bb4f439e",
  "translation_date": "2025-06-11T15:52:51+00:00",
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

#### Tuettu GitHub Actionin kautta (automaattinen & aina ajan tasalla)

# 🚀 Model Context Protocol (MCP) -opetussuunnitelma aloittelijoille

## **Opiskele MCP:tä käytännön koodiesimerkkien avulla C#:ssa, Javassa, JavaScriptissä, Pythonissa ja TypeScriptissä**

## 🧠 Yleiskatsaus Model Context Protocol -opetussuunnitelmaan

**Model Context Protocol (MCP)** on huipputeknologiaa edustava kehys, joka on suunniteltu vakioimaan vuorovaikutus tekoälymallien ja asiakasohjelmien välillä. Tämä avoimen lähdekoodin opetussuunnitelma tarjoaa jäsennellyn oppimispolun, joka sisältää käytännön koodiesimerkkejä ja todellisia käyttötapauksia suosituilla ohjelmointikielillä kuten C#, Java, JavaScript, TypeScript ja Python.

Olitpa sitten tekoälykehittäjä, järjestelmäarkkitehti tai ohjelmistoinsinööri, tämä opas on kattava resurssi MCP:n perusteiden ja toteutusstrategioiden hallintaan.

## 🔗 Viralliset MCP-resurssit

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Yksityiskohtaiset opetusohjelmat ja käyttäjäoppaat  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Protokollan arkkitehtuuri ja tekniset viitteet  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Avoimen lähdekoodin SDK:t, työkalut ja koodiesimerkit  

## 🧭 MCP:n täydellinen opetussuunnitelman rakenne

| Luku | Otsikko | Kuvaus | Linkki |
|--|--|--|--|
| 00 | **Johdanto MCP:hen** | Yleiskatsaus Model Context Protocoliin ja sen merkitykseen tekoälyputkissa, mukaan lukien mitä MCP on, miksi standardointi on tärkeää sekä käytännön esimerkit ja hyödyt | [Johdanto](./00-Introduction/README.md) |
| 01 | **Keskeiset käsitteet selitettynä** | Syvällinen tarkastelu MCP:n ydinkäsitteisiin, kuten asiakas-palvelin -arkkitehtuuriin, keskeisiin protokollakomponentteihin ja viestintämalleihin | [Keskeiset käsitteet](./01-CoreConcepts/README.md) |
| 02 | **Turvallisuus MCP:ssä** | Turvauhkien tunnistaminen MCP-pohjaisissa järjestelmissä, tekniikat ja parhaat käytännöt toteutusten suojaamiseksi | [Turvallisuus](./02-Security/README.md) |
| 03 | **Aloittaminen MCP:n kanssa** | Ympäristön asennus ja konfigurointi, perus MCP-palvelimien ja -asiakkaiden luominen, MCP:n integrointi olemassa oleviin sovelluksiin | [Aloittaminen](./03-GettingStarted/README.md) |
| 3.1 | **Ensimmäinen palvelin** | Peruspalvelimen pystyttäminen MCP-protokollalla, palvelin-asiakas -vuorovaikutuksen ymmärtäminen ja palvelimen testaaminen | [Ensimmäinen palvelin](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Ensimmäinen asiakas** | Perusasiakkaan pystyttäminen MCP-protokollalla, asiakas-palvelin -vuorovaikutuksen ymmärtäminen ja asiakkaan testaaminen | [Ensimmäinen asiakas](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Asiakas LLM:n kanssa** | Asiakkaan perustaminen MCP-protokollalla käyttäen suurta kielimallia (LLM) | [Asiakas LLM:n kanssa](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Palvelimen käyttäminen Visual Studio Codella** | Visual Studio Coden konfigurointi MCP-protokollalla toimivien palvelimien käyttämiseen | [Palvelimen käyttäminen Visual Studio Codella](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Palvelimen luominen SSE:n avulla** | SSE auttaa avaamaan palvelimen internetiin. Tämä osio opastaa palvelimen luomisessa SSE:n avulla | [Palvelimen luominen SSE:llä](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **AI Toolkitin käyttö** | AI Toolkit on erinomainen työkalu, joka auttaa hallitsemaan tekoäly- ja MCP-työnkulkuja | [AI Toolkitin käyttö](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Palvelimen testaaminen** | Testaus on tärkeä osa kehitysprosessia. Tämä osio opastaa testaamaan useilla eri työkaluilla | [Palvelimen testaaminen](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Palvelimen käyttöönotto** | Miten siirryt paikallisesta kehityksestä tuotantoon? Tämä osio auttaa kehittämään ja ottamaan palvelimen käyttöön | [Palvelimen käyttöönotto](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Käytännön toteutus** | SDK:iden käyttö eri kielillä, virheenkorjaus, testaus ja validointi, uudelleenkäytettävien kehotemallien ja työnkulkujen laatiminen | [Käytännön toteutus](./04-PracticalImplementation/README.md) |
| 05 | **Edistyneet MCP-aiheet** | Monimodaaliset tekoälytyönkulut ja laajennettavuus, turvalliset skaalausstrategiat, MCP yritysympäristöissä | [Edistyneet aiheet](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP:n integrointi Azureen** | Esittelee integraation Azureen | [MCP Azure -integraatio](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Monimodaalisuus** | Näyttää, miten työskennellä eri modaliteettien, kuten kuvien kanssa | [Monimodaalisuus](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 -demo** | Minimalistinen Spring Boot -sovellus, joka näyttää OAuth2:n MCP:n kanssa sekä valtuutus- että resurssipalvelimena. Demonstroi turvallista tokenin myöntämistä, suojattuja päätepisteitä, Azure Container Apps -käyttöönottoa ja API Management -integraatiota | [MCP OAuth2 -demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Lisätietoa root contextista ja sen toteuttamisesta | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Reititys** | Opettele erilaisia reititystyyppejä | [Reititys](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Näytteistys** | Opettele työskentelemään näytteistyksen kanssa | [Näytteistys](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skaalaus** | Opettele MCP-palvelimien skaalausta, mukaan lukien vaakasuorat ja pystysuorat skaalausstrategiat, resurssien optimointi ja suorituskyvyn hienosäätö | [Skaalaus](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Turvallisuus** | Suojaa MCP-palvelimesi, mukaan lukien todennus, valtuutus ja tietosuoja | [Turvallisuus](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web-haku MCP:llä** | Python-pohjainen MCP-palvelin ja -asiakas, jotka integroivat SerpAPI:n reaaliaikaiseen web-, uutis-, tuotehakuun ja kysymys-vastaus -toimintoihin. Demonstroi monityökalujen orkestrointia, ulkoisten API:en integraatiota ja vahvaa virheenkäsittelyä | [Web-haku MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Reaaliaikainen suoratoisto** | Reaaliaikainen datavirtaus on nykymaailmassa välttämätöntä, kun yritykset ja sovellukset tarvitsevat välitöntä pääsyä tietoihin tehdäksensä oikea-aikaisia päätöksiä | [Reaaliaikainen suoratoisto](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 06 | **Yhteisön panokset** | Kuinka osallistua koodiin ja dokumentaatioon, yhteistyö GitHubin kautta, yhteisön ohjaamat parannukset ja palaute | [Yhteisön panokset](./06-CommunityContributions/README.md) |
| 07 | **Oppeja varhaisesta käyttöönotosta** | Todelliset toteutukset ja toimineet ratkaisut, MCP-pohjaisten ratkaisujen rakentaminen ja käyttöönotto, trendit ja tulevaisuuden tiekartta | [Opit](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Parhaat käytännöt MCP:lle** | Suorituskyvyn hienosäätö ja optimointi, vikasietoisten MCP-järjestelmien suunnittelu, testaus- ja kestävyysstrategiat | [Parhaat käytännöt](./08-BestPractices/README.md) |
| 09 | **MCP Case Studies** | Syvällisiä tarkasteluja MCP-ratkaisuarkkitehtuureista, käyttöönoton malleista ja integraatiovinkeistä, selitettyjä kaavioita ja projektien läpikäyntejä | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Streamlining AI Workflows: Building an MCP Server with AI Toolkit** | Kattava käytännön työpaja, jossa yhdistetään MCP Microsoftin AI Toolkitin kanssa VS Codeen. Opit rakentamaan älykkäitä sovelluksia, jotka yhdistävät AI-mallit todellisiin työkaluihin käytännön moduulien avulla, jotka kattavat perusteet, räätälöidyn palvelimen kehityksen ja tuotantoon siirtymisen strategiat. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Sample Projects

### 🧮 MCP Calculator Sample Projects:
<details>
  <summary><strong>Tutustu koodiesimerkkeihin kielittäin</strong></summary>

  - [C# MCP Server Example](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Calculator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Example](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Advanced Calculator Projects:
<details>
  <summary><strong>Tutustu edistyneempiin esimerkkeihin</strong></summary>

  - [Advanced C# Sample](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container App Example](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript Advanced Sample](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Complex Implementation](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Sample](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 MCP:n oppimisen ennakkovaatimukset

Jotta saat tästä oppimateriaalista parhaan hyödyn, sinulla tulisi olla:

- Perustiedot C#:stä, Javasta tai Pythonista  
- Ymmärrys asiakas-palvelin-mallista ja API:sta  
- (Valinnainen) Tutustuminen koneoppimisen peruskäsitteisiin  

## 📚 Opas opiskeluun

Laaja [Opas opiskeluun](./study_guide.md) auttaa sinua liikkumaan tässä arkistossa tehokkaasti. Opas sisältää:

- Visuaalisen kurssikartan, joka näyttää kaikki käsitellyt aiheet  
- Yksityiskohtaisen jaon jokaisesta arkiston osiosta  
- Ohjeet näytteiden käyttöön  
- Suositellut oppimispolut eri taitotasoille  
- Lisäresursseja oppimismatkan tueksi  

## 🛠️ Kuinka käyttää tätä oppimateriaalia tehokkaasti

Jokainen tämän oppaan oppitunti sisältää:

1. Selkeät selitykset MCP-konsepteista  
2. Live-koodiesimerkkejä useilla kielillä  
3. Harjoituksia oikeiden MCP-sovellusten rakentamiseen  
4. Lisäresursseja edistyneille oppijoille  

## 📜 Lisenssitiedot

Tämä sisältö on lisensoitu **MIT-lisenssillä**. Ehdot ja säännöt löytyvät tiedostosta [LICENSE](../../LICENSE).

## 🤝 Osallistumisohjeet

Tämä projekti ottaa mielellään vastaan panoksia ja ehdotuksia. Useimmat panokset edellyttävät, että hyväksyt Contributor License Agreementin (CLA), jossa vahvistat, että sinulla on oikeus ja annat meille oikeudet käyttää panostasi. Lisätietoja löytyy osoitteesta <https://cla.opensource.microsoft.com>.

Kun lähetät pull requestin, CLA-botti tarkistaa automaattisesti, tarvitseeko sinun toimittaa CLA, ja merkitsee PR:n asianmukaisesti (esim. tilatarkistus, kommentti). Noudata vain botin ohjeita. Tämä riittää tekemään kerran kaikissa CLA:ta käyttävissä arkistoissa.

Tämä projekti on ottanut käyttöön [Microsoft Open Source Code of Conductin](https://opensource.microsoft.com/codeofconduct/). Lisätietoja saat [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) -sivulta tai ottamalla yhteyttä osoitteeseen [opencode@microsoft.com](mailto:opencode@microsoft.com) mahdollisissa kysymyksissä tai palautteessa.

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
- [Valitse oma Copilot-seikkailusi](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Tavaramerkki-ilmoitus

Tämä projekti saattaa sisältää tavaramerkkejä tai logoja projekteista, tuotteista tai palveluista. Microsoftin tavaramerkkien tai logojen luvallinen käyttö edellyttää ja noudattaa
[Microsoftin tavaramerkki- ja brändiohjeita](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Microsoftin tavaramerkkien tai logojen käyttö tämän projektin muokatuissa versioissa ei saa aiheuttaa sekaannusta tai antaa ymmärtää Microsoftin sponsorointia.
Kolmansien osapuolten tavaramerkkien tai logojen käyttö on näiden osapuolten sääntöjen alaista.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty tekoälypohjaisella käännöspalvelulla [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattikäännöksissä voi esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää auktoritatiivisena lähteenä. Tärkeiden tietojen osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.