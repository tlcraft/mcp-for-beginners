<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T15:54:08+00:00",
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
2. **Kloonaa repositorio**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Liity Azure AI Foundry Discordiin ja tapaa asiantuntijoita sekä muita kehittäjiä**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Monikielinen tuki

#### Tuettu GitHub Actionin kautta (automaattinen ja aina ajan tasalla)

# 🚀 Model Context Protocol (MCP) -oppimäärä aloittelijoille

## **Opiskele MCP:tä käytännön koodiesimerkkien avulla C#:ssa, Javassa, JavaScriptissä, Pythonissa ja TypeScriptissä**

## 🧠 Yleiskatsaus Model Context Protocol -oppimäärään

**Model Context Protocol (MCP)** on huippuluokan kehys, joka on suunniteltu vakioimaan tekoälymallien ja asiakassovellusten välinen vuorovaikutus. Tämä avoimen lähdekoodin oppimäärä tarjoaa jäsennellyn oppimispolun, sisältäen käytännön koodiesimerkkejä ja todellisia käyttötapauksia suosituilla ohjelmointikielillä, kuten C#, Java, JavaScript, TypeScript ja Python.

Oletpa sitten tekoälykehittäjä, järjestelmäarkkitehti tai ohjelmistoinsinööri, tämä opas on kattava resurssi MCP:n perusteiden ja toteutusstrategioiden hallintaan.

## 🔗 Viralliset MCP-resurssit

- 📘 [MCP-dokumentaatio](https://modelcontextprotocol.io/) – Yksityiskohtaiset tutoriaalit ja käyttöoppaat  
- 📜 [MCP-spesifikaatio](https://spec.modelcontextprotocol.io/) – Protokollan arkkitehtuuri ja tekniset viitteet  
- 🧑‍💻 [MCP GitHub-repositorio](https://github.com/modelcontextprotocol) – Avoimen lähdekoodin SDK:t, työkalut ja koodiesimerkit  

## 🧭 MCP-oppimäärän kokonaisrakenne

| Luku | Otsikko | Kuvaus | Linkki |
|--|--|--|--|
| 00 | **Johdanto MCP:hen** | Yleiskatsaus Model Context Protocoliin ja sen merkitykseen tekoälyputkissa, mukaan lukien mitä MCP on, miksi standardointi on tärkeää sekä käytännön käyttötapaukset ja hyödyt | [Johdanto](./00-Introduction/README.md) |
| 01 | **Keskeiset käsitteet selitettynä** | Syvällinen perehtyminen MCP:n keskeisiin käsitteisiin, kuten asiakas-palvelin -arkkitehtuuriin, protokollan pääkomponentteihin ja viestintäkuvioihin | [Keskeiset käsitteet](./01-CoreConcepts/README.md) |
| 02 | **Turvallisuus MCP:ssä** | MCP-pohjaisten järjestelmien turvallisuusuhkien tunnistaminen, menetelmät ja parhaat käytännöt toteutusten suojaamiseen | [Turvallisuus](./02-Security/README.md) |
| 03 | **Aloita MCP:n kanssa** | Ympäristön asennus ja konfigurointi, perus MCP-palvelimien ja -asiakkaiden luominen, MCP:n integrointi olemassa oleviin sovelluksiin | [Aloita](./03-GettingStarted/README.md) |
| 3.1 | **Ensimmäinen palvelin** | Peruspalvelimen pystyttäminen MCP-protokollalla, palvelin-asiakas -vuorovaikutuksen ymmärtäminen ja palvelimen testaaminen | [Ensimmäinen palvelin](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Ensimmäinen asiakas**  | Perusasiakkaan luominen MCP-protokollalla, asiakas-palvelin -vuorovaikutuksen ymmärtäminen ja asiakkaan testaaminen | [Ensimmäinen asiakas](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Asiakas LLM:n kanssa**  | Asiakkaan perustaminen MCP-protokollalla käyttäen suurta kielimallia (LLM) | [Asiakas LLM:n kanssa](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Palvelimen käyttäminen Visual Studio Codella** | Visual Studio Coden konfigurointi MCP-protokollaa käyttävien palvelimien hyödyntämiseen | [Palvelimen käyttäminen Visual Studio Codella](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Palvelimen luominen SSE:llä** | SSE:n avulla voimme avata palvelimen internetiin. Tämä osio auttaa sinua luomaan palvelimen SSE:llä | [Palvelimen luominen SSE:llä](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP-suoratoisto** | Opettele toteuttamaan HTTP-suoratoisto reaaliaikaista tiedonsiirtoa varten asiakkaiden ja MCP-palvelimien välillä | [HTTP-suoratoisto](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **AI Toolkitin käyttö** | AI Toolkit on erinomainen työkalu, joka auttaa hallitsemaan tekoäly- ja MCP-työnkulkua | [AI Toolkitin käyttö](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Palvelimen testaaminen** | Testaus on tärkeä osa kehitysprosessia. Tämä osio opastaa sinua käyttämään useita eri testausvälineitä | [Palvelimen testaaminen](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Palvelimen käyttöönotto** | Miten siirryt paikallisesta kehityksestä tuotantoon? Tämä osio auttaa kehittämään ja ottamaan palvelimen käyttöön | [Palvelimen käyttöönotto](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Käytännön toteutus** | SDK:iden käyttö eri kielillä, virheiden etsintä, testaus ja validointi, uudelleenkäytettävien kehotemallien ja työnkulkujen luominen | [Käytännön toteutus](./04-PracticalImplementation/README.md) |
| 05 | **Edistyneet MCP-aiheet** | Monimuotoiset tekoälytyönkulut ja laajennettavuus, turvalliset skaalausstrategiat, MCP yritysekosysteemeissä | [Edistyneet aiheet](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP:n integrointi Azureen** | Näyttää integraation Azureen | [MCP Azure -integraatio](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Monimuotoisuus** | Näyttää, miten työskennellä erilaisten modaliteettien, kuten kuvien kanssa | [Monimuotoisuus](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 -demo** | Minimipohjainen Spring Boot -sovellus, joka näyttää OAuth2:n käytön MCP:n kanssa sekä valtuutus- että resurssipalvelimena. Demonstroi turvallista tokenin myöntämistä, suojattuja päätepisteitä, Azure Container Apps -käyttöönottoa ja API-hallinnan integrointia | [MCP OAuth2 -demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Opettele lisää root contextista ja sen toteutuksesta | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Reititys** | Opettele erilaisia reititystyyppejä | [Reititys](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Näytteenotto** | Opettele työskentelemään näytteenoton kanssa | [Näytteenotto](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skaalaus** | Opettele MCP-palvelimien skaalaamisesta, mukaan lukien horisontaaliset ja vertikaaliset skaalausstrategiat, resurssien optimointi ja suorituskyvyn hienosäätö | [Skaalaus](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Turvallisuus** | Suojaa MCP-palvelimesi, mukaan lukien autentikointi, valtuutus ja datan suojausstrategiat | [Turvallisuus](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web-haku MCP:llä** | Python MCP -palvelin ja asiakas, jotka integroivat SerpAPI:n reaaliaikaiseen web-, uutis-, tuotehakuun ja kysymys-vastaus -toimintoihin. Demonstroi monityökalujen orkestrointia, ulkoisten API:en integrointia ja vankkaa virheenkäsittelyä | [Web-haku MCP:llä](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Reaaliaikainen suoratoisto** | Reaaliaikainen datan suoratoisto on nykymaailmassa välttämätöntä, kun yritykset ja sovellukset tarvitsevat välitöntä pääsyä tietoon tehdäkseen oikea-aikaisia päätöksiä | [Reaaliaikainen suoratoisto](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Reaaliaikainen web-haku** | Miten MCP muuttaa reaaliaikaista web-hakua tarjoamalla standardoidun lähestymistavan kontekstinhallintaan tekoälymallien, hakukoneiden ja sovellusten välillä | [Reaaliaikainen web-haku](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Yhteisön panokset** | Miten osallistua koodilla ja dokumentaatiolla, yhteistyö GitHubin kautta, yhteisölähtöiset parannukset ja palaute | [Yhteisön panokset](./06-CommunityContributions/README.md) |
| 07 | **Oivalluksia varhaisesta käyttöönotosta** | Käytännön toteutuksia ja toimineita ratkaisuja, MCP-pohjaisten ratkaisujen rakentaminen ja käyttöönotto, trendit ja tulevaisuuden tiekartta | [Oivallukset](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Parhaat käytännöt MCP:lle** | Suorituskyvyn säätö ja optimointi, vikasietoisien MCP-järjestelmien suunnittelu, testaus- ja palautumiskäytännöt | [Parhaat käytännöt](./08-BestPractices/README.md) |
| 09 | **MCP-tapaustutkimukset** | Syväsukelluksia MCP-ratkaisuarkkitehtuureihin, käyttöönoton mallipohjia ja integraatiovinkkejä, selitettyjä kaavioita ja projektikierroksia | [Tapaustutkimukset](./09-CaseStudy/README.md) |
| 10 | **AI-työnkulkujen virtaviivaistaminen: MCP-palvelimen rakentaminen AI Toolkitin avulla** | Kattava käytännön työpaja, joka yhdistää MCP:n ja Microsoftin AI Toolkitin VS Codeen. Opit rakentamaan älykkäitä sovelluksia, jotka yhdistävät AI-mallit todellisiin työkaluihin käytännön moduulien avulla, kattaen perusteet, räätälöidyn palvelimen kehityksen ja tuotantokäyttöönoton strategiat. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Esimerkkiprojektit

### 🧮 MCP-laskin esimerkkiprojektit:
<details>
  <summary><strong>Tutustu koodiesimerkkeihin kielittäin</strong></summary>

  - [C# MCP-palvelin esimerkki](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP-laskin](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP-demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP-palvelin](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP-esimerkki](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP-edistyneet laskinprojektit:
<details>
  <summary><strong>Tutustu edistyneisiin esimerkkeihin</strong></summary>

  - [Edistynyt C# esimerkki](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container App -esimerkki](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript edistynyt esimerkki](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python monimutkainen toteutus](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container -esimerkki](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 MCP:n oppimisen edellytykset

Jotta saat tästä oppimateriaalista parhaan hyödyn, sinulla tulisi olla:

- Perustiedot C#:stä, Javasta tai Pythonista  
- Ymmärrys asiakas-palvelin-mallista ja API:sta  
- (Valinnainen) Tuntemus koneoppimisen perusteista  

## 📚 Opas opiskeluun

Laaja [Opas opiskeluun](./study_guide.md) auttaa sinua liikkumaan tässä repossa tehokkaasti. Opas sisältää:

- Visuaalisen opetussuunnitelmakartan kaikista aiheista  
- Yksityiskohtaisen erittelyn jokaisesta osasta  
- Ohjeita esimerkkiprojektien käyttöön  
- Suositellut oppimispolut eri taitotasoille  
- Lisäresursseja oppimisen tueksi  

## 🛠️ Kuinka käyttää tätä oppimateriaalia tehokkaasti

Jokainen tämän oppaan oppitunti sisältää:

1. Selkeät selitykset MCP-konsepteista  
2. Live-koodiesimerkkejä useilla kielillä  
3. Harjoituksia oikeiden MCP-sovellusten rakentamiseen  
4. Lisäresursseja edistyneille oppijoille  

## 📜 Lisenssitiedot

Tämä sisältö on lisensoitu **MIT-lisenssillä**. Ehdot löytyvät tiedostosta [LICENSE](../../LICENSE).

## 🤝 Osallistumisohjeet

Tämä projekti toivottaa tervetulleeksi osallistumiset ja ehdotukset. Useimmat osallistumiset vaativat, että hyväksyt Contributor License Agreementin (CLA), jossa vahvistat, että sinulla on oikeus ja myönnät meille oikeudet käyttää panostustasi. Lisätietoja löytyy osoitteesta <https://cla.opensource.microsoft.com>.

Kun lähetät pull requestin, CLA-botti tarkistaa automaattisesti, tarvitsetko CLA:n ja merkitsee PR:n asianmukaisesti (esim. statustarkistus, kommentti). Noudata vain botin antamia ohjeita. Tätä tarvitsee tehdä vain kerran kaikissa CLA:ta käyttävissä repohin.

Tämä projekti on ottanut käyttöön [Microsoft Open Source Code of Conductin](https://opensource.microsoft.com/codeofconduct/). Lisätietoja löytyy [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) -sivulta tai ota yhteyttä osoitteeseen [opencode@microsoft.com](mailto:opencode@microsoft.com) jos sinulla on lisäkysymyksiä tai kommentteja.

## 🎒 Muita kursseja
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


## ™️ Tavaramerkki-ilmoitus

Tämä projekti saattaa sisältää tavaramerkkejä tai logoja projekteista, tuotteista tai palveluista. Microsoftin tavaramerkkien tai logojen luvallinen käyttö edellyttää ja noudattaa  
[Microsoftin tavaramerkki- ja brändiohjeita](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).  
Microsoftin tavaramerkkien tai logojen käyttö muokatuissa versioissa tästä projektista ei saa aiheuttaa sekaannusta tai antaa ymmärtää Microsoftin sponsorointia.  
Kolmansien osapuolien tavaramerkkien tai logojen käyttö on näiden osapuolten ehtojen mukaista.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty tekoälypohjaisella käännöspalvelulla [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä on virallinen lähde. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tästä käännöksestä aiheutuvista väärinymmärryksistä tai tulkinnoista.