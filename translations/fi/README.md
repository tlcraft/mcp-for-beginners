<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "292f96c64f54ba097daea9598111ed82",
  "translation_date": "2025-07-02T05:39:36+00:00",
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


[![Microsoft Azure AI Foundry Discord](https://dcbadge.limes.pink/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)

Seuraa näitä ohjeita aloittaaksesi näiden resurssien käytön:
1. **Forkkaa repositorio**: Klikkaa [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Kloonaa repositorio**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Liity Azure AI Foundry Discordiin ja tapaa asiantuntijoita sekä muita kehittäjiä**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Monikielinen tuki

#### Tuettu GitHub Actionin kautta (automaattinen ja aina ajan tasalla)

# 🚀 Model Context Protocol (MCP) -opintokokonaisuus aloittelijoille

## **Opiskele MCP:tä käytännön koodiesimerkkien avulla C#:ssa, Javassa, JavaScriptissä, Pythonissa ja TypeScriptissä**

## 🧠 Yleiskatsaus Model Context Protocol -opintokokonaisuuteen

**Model Context Protocol (MCP)** on edistyksellinen kehys, joka on suunniteltu standardoimaan vuorovaikutusta tekoälymallien ja asiakassovellusten välillä. Tämä avoimen lähdekoodin opintokokonaisuus tarjoaa jäsennellyn oppimispolun, joka sisältää käytännön koodiesimerkkejä ja aitoja käyttötapauksia suosituissa ohjelmointikielissä, kuten C#, Java, JavaScript, TypeScript ja Python.

Oletpa sitten tekoälykehittäjä, järjestelmäarkkitehti tai ohjelmistoinsinööri, tämä opas on kattava resurssi MCP:n perusteiden ja toteutusstrategioiden hallintaan.

## 🔗 Viralliset MCP-resurssit

- 📘 [MCP-dokumentaatio](https://modelcontextprotocol.io/) – Yksityiskohtaiset opetusohjelmat ja käyttäjäoppaat  
- 📜 [MCP-spesifikaatio](https://spec.modelcontextprotocol.io/) – Protokollan arkkitehtuuri ja tekniset viitteet  
- 🧑‍💻 [MCP GitHub-repositorio](https://github.com/modelcontextprotocol) – Avoimen lähdekoodin SDK:t, työkalut ja koodiesimerkit  

## 🧭 MCP-opintokokonaisuuden yleiskatsaus

### Model Context Protocolin perusteet  
<details>
  <summary><strong> Luvut 1-3: Model Context Protocolin perusteet</strong></summary>

- **00. Johdatus MCP:hen**  
  Yleiskatsaus Model Context Protocoliin ja sen merkitykseen tekoälyputkissa. [Lue lisää](./00-Introduction/README.md)
- **01. Keskeiset käsitteet selitettynä**  
  Syvällinen katsaus MCP:n ydinkäsitteisiin. [Lue lisää](./01-CoreConcepts/README.md)
- **02. Turvallisuus MCP:ssä**  
  Turvauhat ja parhaat käytännöt. [Lue lisää](./02-Security/README.md)
- **03. MCP:n käyttöönotto**  
  Ympäristön pystytys, peruspalvelimet/asiakkaat, integrointi. [Lue lisää](./03-GettingStarted/README.md)
</details>

### Ensimmäisen MCP-palvelimen ja -asiakkaan rakentaminen ja käyttöönotto sekä käytännön harjoitukset ja skenaariot  
<details>
  <summary><strong> Luku 3: Ensimmäisen MCP-palvelimen ja -asiakkaan rakentaminen ja käyttöönotto</strong></summary>

- **3.1. Ensimmäinen palvelin** – [Opas](./03-GettingStarted/01-first-server/README.md)
- **3.2. Ensimmäinen asiakas** – [Opas](./03-GettingStarted/02-client/README.md)
- **3.3. Asiakas LLM:llä** – [Opas](./03-GettingStarted/03-llm-client/README.md)
- **3.4. Palvelimen käyttäminen Visual Studio Codella** – [Opas](./03-GettingStarted/04-vscode/README.md)
- **3.5. Palvelimen luominen SSE:llä** – [Opas](./03-GettingStarted/05-sse-server/README.md)
- **3.6. HTTP-suoratoisto** – [Opas](./03-GettingStarted/06-http-streaming/README.md)
- **3.7. AI Toolkitin käyttö** – [Opas](./03-GettingStarted/07-aitk/README.md)
- **3.8. Palvelimen testaaminen** – [Opas](./03-GettingStarted/08-testing/README.md)
- **3.9. Palvelimen käyttöönotto** – [Opas](./03-GettingStarted/09-deployment/README.md)
</details>

### Model Context Protocol käytännössä ja edistyneet aiheet  
<details>
  <summary><strong> Luvut 4-5: Käytännön toteutukset & edistynyt sisältö</strong></summary>

- **04. Käytännön toteutus**  
  SDK:t, virheenkorjaus, testaus, uudelleenkäytettävät prompt-mallit. [Lue lisää](./04-PracticalImplementation/README.md)
- **05. Edistyneet MCP-aiheet**  
  Monimodaalinen tekoäly, skaalaus, yrityskäyttö. [Lue lisää](./05-AdvancedTopics/README.md)
- **5.1. MCP:n integrointi Azureen** – [Opas](./05-AdvancedTopics/mcp-integration/README.md)
- **5.2. Monimodaalisuus** – [Opas](./05-AdvancedTopics/mcp-multi-modality/README.md)
- **5.3. MCP OAuth2 -demo** – [Opas](./05-AdvancedTopics/mcp-oauth2-demo/README.md)
- **5.4. Root Contexts** – [Opas](./05-AdvancedTopics/mcp-root-contexts/README.md)
- **5.5. Reititys** – [Opas](./05-AdvancedTopics/mcp-routing/README.md)
- **5.6. Otanta** – [Opas](./05-AdvancedTopics/mcp-sampling/README.md)
- **5.7. Skaalaus** – [Opas](./05-AdvancedTopics/mcp-scaling/README.md)
- **5.8. Turvallisuus** – [Opas](./05-AdvancedTopics/mcp-security/README.md)
- **5.9. Web-haku MCP:llä** – [Opas](./05-AdvancedTopics/web-search-mcp/README.md)
- **5.10. Reaaliaikainen suoratoisto** – [Opas](./05-AdvancedTopics/mcp-realtimestreaming/README.md)
- **5.11. Reaaliaikainen web-haku** – [Opas](./05-AdvancedTopics/mcp-realtimesearch/README.md)
- **5.12. Entra ID -todennus Model Context Protocol -palvelimille** – [Opas](./05-AdvancedTopics/mcp-security-entra/README.md)
</details>

### Model Context Protocol parhaat käytännöt  
<details>
  <summary><strong> Luvut 6-9: Yhteisö, parhaat käytännöt & harjoitukset</strong></summary>
- **06. Yhteisön panokset** – [Opas](./06-CommunityContributions/README.md)
- **07. Varhaisen käyttöönoton opit** – [Opas](./07-LessonsFromEarlyAdoption/README.md)
- **08. Parhaat käytännöt MCP:lle** – [Opas](./08-BestPractices/README.md)
- **09. MCP-tapaukset** – [Opas](./09-CaseStudy/README.md)
</details>

### Model Context Protocol Käytännön harjoitus AI Toolkitin kanssa VScodessa
<details>
  <summary><strong>Oppitunti 10: Käytännön harjoitus MCP-palvelimen rakentamisesta AI Toolkitilla VScodessa</strong></summary>
    
- **10. AI-työnkulkujen virtaviivaistaminen: MCP-palvelimen rakentaminen AI Toolkitilla** – [Käytännön harjoitus](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)
</details>

## Model Context Protocol Esimerkkiprojektit MCP-laskinprojektin rakentaminen Java-, C#-, JavaScript-, TypeScript- ja Python-kielillä

### 🧮 MCP-laskin esimerkkiprojektit Java-, C#-, JavaScript-, TypeScript- ja Python-kielillä
<details>
  <summary><strong>Tutustu koodiesimerkkeihin kielittäin</strong></summary>

  - [C# MCP-palvelin esimerkki](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP-laskin](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP-demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP-palvelin](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP-esimerkki](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Edistynyt esimerkkiratkaisu: Laskinprojektit C#, Java, JavaScript, TypeScript ja Python
<details>
  <summary><strong>Tutustu edistyneisiin esimerkkeihin</strong></summary>

  - [Edistynyt C#-esimerkki](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container App -esimerkki](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript Edistynyt esimerkki](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Monimutkainen toteutus](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container -esimerkki](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 MCP:n oppimisen edellytykset

Jotta saat tästä oppimateriaalista parhaan hyödyn, sinulla tulisi olla:

- Perustiedot C#, Java- tai Python-kielistä  
- Ymmärrys asiakas-palvelin-mallista ja API:sta  
- (Valinnainen) Tuntemus koneoppimisen perusteista  

## 📚 Opas opiskeluun

Kattava [Opas](./study_guide.md) on saatavilla auttamaan sinua navigoimaan tässä repossa tehokkaasti. Opas sisältää:

- Visuaalisen kurssikartan kaikista käsitellyistä aiheista  
- Yksityiskohtaisen jaon repossa olevista osioista  
- Ohjeita esimerkkiprojektien käyttöön  
- Suosituksia oppimispoluille eri taitotasoille  
- Lisäresursseja oppimismatkan tueksi  

## 🛠️ Kuinka käyttää tätä oppimateriaalia tehokkaasti

Jokainen oppitunti tässä oppaassa sisältää:

1. Selkeät selitykset MCP-konsepteista  
2. Live-koodiesimerkkejä useilla kielillä  
3. Harjoituksia oikeiden MCP-sovellusten rakentamiseen  
4. Lisäresursseja edistyneille oppijoille  

## 🌟 Kiitokset yhteisölle

Kiitos Microsoftin arvostetulle ammattilaiselle [Shivam Goyal](https://www.linkedin.com/in/shivam2003/) tärkeistä koodiesimerkeistä. 

## 📜 Lisenssitiedot

Tämä sisältö on lisensoitu **MIT-lisenssillä**. Ehdot ja säännöt löytyvät [LICENSE](../../LICENSE) -tiedostosta.

## 🤝 Osallistumisohjeet

Tämä projekti toivottaa tervetulleeksi osallistumiset ja ehdotukset. Useimmat osallistumiset edellyttävät, että hyväksyt
Contributor License Agreementin (CLA), jossa vahvistat oikeutesi ja myönnät meille oikeudet käyttää panostasi. Lisätietoja löytyy osoitteesta <https://cla.opensource.microsoft.com>.

Kun lähetät pull requestin, CLA-botti määrittää automaattisesti, tarvitsetko CLA:n ja merkitsee PR:n asianmukaisesti (esim. tilatarkistus, kommentti). Noudata vain botin antamia ohjeita. Tämä prosessi tarvitsee tehdä vain kerran kaikissa CLA:ta käyttävissä repossa.

Tämä projekti on ottanut käyttöön [Microsoftin avoimen lähdekoodin käytännesäännöt](https://opensource.microsoft.com/codeofconduct/). Lisätietoja löytyy [Käytännesääntöjen UKK:sta](https://opensource.microsoft.com/codeofconduct/faq/) tai ota yhteyttä osoitteeseen [opencode@microsoft.com](mailto:opencode@microsoft.com) jos sinulla on lisäkysymyksiä tai kommentteja.

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
- [IoT aloittelijoille](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [XR-kehitys aloittelijoille](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [GitHub Copilotin hallinta tekoälypariohjelmointiin](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [GitHub Copilotin hallinta C#/.NET-kehittäjille](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Valitse oma Copilot-seikkailusi](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Tavara- ja palvelumerkkitiedote

Tässä projektissa voi olla tavara- tai palvelumerkkejä tai logoja projekteihin, tuotteisiin tai palveluihin liittyen. Microsoftin tavara- ja palvelumerkkien tai logojen luvallinen käyttö edellyttää [Microsoftin tavara- ja brändiohjeiden](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general) noudattamista. Microsoftin tavara- tai palvelumerkkien tai logojen käyttö tämän projektin muokatuissa versioissa ei saa aiheuttaa sekaannusta tai antaa vaikutelmaa Microsoftin sponsoroinnista. Kolmansien osapuolten tavara- tai palvelumerkkien tai logojen käyttö on näiden osapuolten sääntöjen alaista.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty tekoälypohjaisella käännöspalvelulla [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattikäännöksissä voi esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.