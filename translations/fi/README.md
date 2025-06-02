<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "677cecb63a0bf6c0f49e40ffc15f6189",
  "translation_date": "2025-06-02T12:33:33+00:00",
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
1. **Forkkaa Repository**: Klikkaa [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Kloonaa Repository**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Liity Azure AI Foundry Discordiin ja tapaa asiantuntijoita sekä muita kehittäjiä**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Monikielinen tuki

#### Tuettu GitHub Actionin kautta (automaattinen ja aina ajan tasalla)

# 🚀 Model Context Protocol (MCP) Aloittelijoille

## **Opiskele MCP:tä käytännön koodiesimerkkien avulla C#:ssa, Javassa, JavaScriptissä, Pythonissa ja TypeScriptissä**

## 🧠 Model Context Protocol -oppimäärän yleiskatsaus

**Model Context Protocol (MCP)** on huipputeknologiaa edustava kehys, jonka tarkoituksena on standardoida tekoälymallien ja asiakasohjelmien välistä vuorovaikutusta. Tämä avoimen lähdekoodin oppimäärä tarjoaa jäsennellyn oppimispolun, joka sisältää käytännön koodiesimerkkejä ja todellisia käyttötapauksia suosituilla ohjelmointikielillä, kuten C#, Java, JavaScript, TypeScript ja Python.

Oletpa sitten tekoälykehittäjä, järjestelmäarkkitehti tai ohjelmistoinsinööri, tämä opas on kattava resurssi MCP:n perusteiden ja toteutusstrategioiden hallintaan.

## 🔗 Viralliset MCP-resurssit

- 📘 [MCP-dokumentaatio](https://modelcontextprotocol.io/) – Yksityiskohtaiset opetusohjelmat ja käyttöoppaat  
- 📜 [MCP-määritys](https://spec.modelcontextprotocol.io/) – Protokollan arkkitehtuuri ja tekniset viitteet  
- 🧑‍💻 [MCP GitHub-repositorio](https://github.com/modelcontextprotocol) – Avoimen lähdekoodin SDK:t, työkalut ja koodiesimerkit  

## 🧭 MCP-kokonaisoppimäärän rakenne

| Luku | Otsikko | Kuvaus | Linkki |
|--|--|--|--|
| 00 | **Johdanto MCP:hen** | Yleiskatsaus Model Context Protocoliin ja sen merkitykseen tekoälyputkissa, mukaan lukien mitä MCP on, miksi standardointi on tärkeää sekä käytännön käyttötapaukset ja hyödyt | [Johdanto](./00-Introduction/README.md) |
| 01 | **Keskeiset käsitteet selitettynä** | Syvällinen tarkastelu MCP:n keskeisistä käsitteistä, kuten asiakas-palvelin-arkkitehtuurista, protokollan pääkomponenteista ja viestintämalleista | [Keskeiset käsitteet](./01-CoreConcepts/README.md) |
| 02 | **Turvallisuus MCP:ssä** | Turvauhkien tunnistaminen MCP-pohjaisissa järjestelmissä, tekniikat ja parhaat käytännöt turvallisen toteutuksen varmistamiseksi | [Turvallisuus](./02-Security/README.md) |
| 03 | **Aloita MCP:n kanssa** | Ympäristön asennus ja konfigurointi, perus MCP-palvelimien ja -asiakkaiden luominen, MCP:n integrointi olemassa oleviin sovelluksiin | [Aloita](./03-GettingStarted/README.md) |
| 3.1 | **Ensimmäinen palvelin** | Peruspalvelimen perustaminen MCP-protokollaa käyttäen, palvelin-asiakas-vuorovaikutuksen ymmärtäminen ja palvelimen testaaminen | [Ensimmäinen palvelin](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Ensimmäinen asiakas**  | Perusasiakkaan perustaminen MCP-protokollaa käyttäen, asiakas-palvelin-vuorovaikutuksen ymmärtäminen ja asiakkaan testaaminen | [Ensimmäinen asiakas](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Asiakas LLM:llä**  | Asiakkaan perustaminen MCP-protokollaa käyttäen ja hyödyntäen suurta kielimallia (LLM) | [Asiakas LLM:llä](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Palvelimen käyttäminen Visual Studio Codella** | Visual Studio Coden konfigurointi palvelimien käyttämiseen MCP-protokollalla | [Palvelimen käyttäminen Visual Studio Codella](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Palvelimen luominen SSE:llä** | SSE mahdollistaa palvelimen avaamisen internetiin. Tässä osiossa opit luomaan palvelimen SSE:tä käyttäen | [Palvelimen luominen SSE:llä](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **AI Toolkitin käyttö** | AI Toolkit on erinomainen työkalu, joka auttaa hallitsemaan tekoäly- ja MCP-työnkulkua | [AI Toolkitin käyttö](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Palvelimen testaaminen** | Testaus on olennainen osa kehitysprosessia. Tässä osiossa opit käyttämään useita eri työkaluja testaamiseen | [Palvelimen testaaminen](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Palvelimen käyttöönotto** | Miten siirryt paikallisesta kehityksestä tuotantoon? Tämä osio auttaa sinua kehittämään ja ottamaan palvelimen käyttöön | [Palvelimen käyttöönotto](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Käytännön toteutus** | SDK:iden käyttö eri kielillä, virheenkorjaus, testaus ja validointi, uudelleenkäytettävien kehotepohjien ja työnkulkujen laatiminen | [Käytännön toteutus](./04-PracticalImplementation/README.md) |
| 05 | **Edistyneet MCP-aiheet** | Monimodaaliset tekoälytyönkulut ja laajennettavuus, turvalliset skaalausstrategiat, MCP yritysympäristöissä | [Edistyneet aiheet](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP OAuth2 -demo** | OAuth2-todennuksen toteuttaminen MCP-palvelimilla, mukaan lukien käyttöoikeustunnuksen vahvistus, laajuuspohjainen valtuutus ja turvallinen API-päätepisteiden suojaus | [MCP OAuth2 -demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.2 | **Verkkohaku MCP:llä** | Verkkohakutoimintojen toteutus Model Context Protocolia käyttäen, mukaan lukien hakukyselyjen käsittely, tulosten hallinta ja integraatio hakukoneiden API:hin | [Verkkohaku MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Yhteisön panokset** | Kuinka osallistua koodin ja dokumentaation tekemiseen, yhteistyö GitHubin kautta, yhteisön vetämät parannukset ja palaute | [Yhteisön panokset](./06-CommunityContributions/README.md) |
| 07 | **Oppeja varhaisesta käyttöönotosta** | Käytännön toteutukset ja toimivat ratkaisut, MCP-pohjaisten ratkaisujen rakentaminen ja käyttöönotto, trendit ja tulevaisuuden tiekartta | [Opit](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Parhaat käytännöt MCP:lle** | Suorituskyvyn säätäminen ja optimointi, vikasietoisten MCP-järjestelmien suunnittelu, testaus- ja kestävyyden varmistusstrategiat | [Parhaat käytännöt](./08-BestPractices/README.md) |
| 09 | **MCP-tapaukset** | Syväluotaavia tarkasteluja MCP-ratkaisuarkkitehtuureista, käyttöönoton malleista ja integraatiovinkeistä, selitetyt kaaviot ja projektikierrokset | [Tapaukset](./09-CaseStudy/README.md) |

## Esimerkkiprojektit

### 🧮 MCP-laskin esimerkkiprojektit:
<details>
  <summary><strong>Tutustu koodiesimerkkeihin kielittäin</strong></summary>

  - [C# MCP -palvelin esimerkki](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP -laskin](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP -demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP -palvelin](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP -esimerkki](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP-edistyneet laskinprojektit:
<details>
  <summary><strong>Tutustu edistyneisiin esimerkkeihin</strong></summary>

  - [Edistynyt C# -esimerkki](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java-säiliösovellus esimerkki](./04-PracticalImplementation/samples/java/containerapp/README.md)
- [JavaScript Advanced Sample](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Complex Implementation](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Sample](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 MCP:n Oppimisen Edellytykset

Jotta saat tästä opetussuunnitelmasta parhaan hyödyn, sinun tulisi hallita:

- Perustiedot C#:stä, Javasta tai Pythonista  
- Ymmärrys asiakas-palvelin-mallista ja API:sta  
- (Valinnainen) Tuntemus koneoppimisen peruskäsitteistä  

## 🛠️ Kuinka Käyttää Tätä Opetussuunnitelmaa Tehokkaasti

Jokainen tämän oppaan oppitunti sisältää:

1. Selkeät selitykset MCP:n käsitteistä  
2. Live-koodiesimerkkejä useilla kielillä  
3. Harjoituksia aitojen MCP-sovellusten rakentamiseen  
4. Lisäresursseja edistyneille oppijoille  

## 📜 Lisenssitiedot

Tämä sisältö on lisensoitu **MIT-lisenssillä**. Ehdot löydät tiedostosta [LICENSE](../../LICENSE).

## 🤝 Osallistumisohjeet

Tämä projekti ottaa mielellään vastaan panoksia ja ehdotuksia. Useimmat panokset edellyttävät, että hyväksyt Contributor License Agreementin (CLA), jossa vakuutat omistavasi oikeudet ja myönnät meille oikeuden käyttää panostasi. Lisätietoja löytyy osoitteesta <https://cla.opensource.microsoft.com>.

Kun lähetät pull requestin, CLA-botti tarkistaa automaattisesti, tarvitsetko CLA:n ja lisää PR:ään asianmukaiset merkinnät (esim. tilatarkistus, kommentti). Noudata botin ohjeita. Tämä prosessi tarvitsee tehdä vain kerran kaikissa CLA:ta käyttävissä repositorioissa.

Tämä projekti on ottanut käyttöön [Microsoft Open Source Code of Conductin](https://opensource.microsoft.com/codeofconduct/). Lisätietoja löytyy [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) -sivulta tai ota yhteyttä osoitteeseen [opencode@microsoft.com](mailto:opencode@microsoft.com) mahdollisissa kysymyksissä tai kommenteissa.

## 🎒 Muut Kurssit  
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

Tämä projekti saattaa sisältää tavaramerkkejä tai logoja projekteihin, tuotteisiin tai palveluihin liittyen. Microsoftin tavaramerkkien tai logojen luvallinen käyttö edellyttää ja noudattaa [Microsoftin tavaramerkki- ja brändiohjeita](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general). Microsoftin tavaramerkkien tai logojen käyttö tämän projektin muokatuissa versioissa ei saa aiheuttaa sekaannusta tai antaa ymmärtää Microsoftin sponsorointia. Kolmansien osapuolten tavaramerkkien tai logojen käyttö on näiden osapuolten sääntöjen alaista.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta otathan huomioon, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä on katsottava viralliseksi lähteeksi. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinymmärryksistä tai tulkinnoista.