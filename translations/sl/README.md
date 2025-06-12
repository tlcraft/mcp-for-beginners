<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c7fbf0cdaa44b3245daff0c8bb4f439e",
  "translation_date": "2025-06-11T16:32:09+00:00",
  "source_file": "README.md",
  "language_code": "sl"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.sl.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Sledi tem korakom, da začneš uporabljati te vire:
1. **Razvezi repozitorij**: Klikni [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Kloniraj repozitorij**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Pridruži se Azure AI Foundry Discordu in spoznaj strokovnjake ter druge razvijalce**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Podpora za več jezikov

#### Podprto preko GitHub Action (avtomatsko in vedno posodobljeno)

# 🚀 Model Context Protocol (MCP) Currikulum za začetnike

## **Nauči se MCP z praktičnimi primeri kode v C#, Java, JavaScript, Python in TypeScript**

## 🧠 Pregled Model Context Protocol Currikuluma

**Model Context Protocol (MCP)** je napreden okvir, zasnovan za standardizacijo interakcij med AI modeli in odjemalskimi aplikacijami. Ta odprtokodni kurikulum ponuja strukturirano pot učenja, skupaj s praktičnimi primeri kode in resničnimi primeri uporabe v priljubljenih programskih jezikih, kot so C#, Java, JavaScript, TypeScript in Python.

Ne glede na to, ali ste AI razvijalec, sistemski arhitekt ali programski inženir, je ta vodič vaš celovit vir za obvladovanje osnov MCP in strategij implementacije.

## 🔗 Uradni viri MCP

- 📘 [MCP Dokumentacija](https://modelcontextprotocol.io/) – Podrobni vodiči in uporabniški priročniki  
- 📜 [MCP Specifikacija](https://spec.modelcontextprotocol.io/) – Arhitektura protokola in tehnične reference  
- 🧑‍💻 [MCP GitHub Repozitorij](https://github.com/modelcontextprotocol) – Odprtokodni SDK-ji, orodja in primeri kode  

## 🧭 Celotna struktura MCP kurikuluma

| Ch | Naslov | Opis | Povezava |
|--|--|--|--|
| 00 | **Uvod v MCP** | Pregled Model Context Protocol in njegov pomen v AI procesih, kaj je Model Context Protocol, zakaj je standardizacija pomembna ter praktični primeri in koristi | [Uvod](./00-Introduction/README.md) |
| 01 | **Razlaga osnovnih konceptov** | Poglobljen pregled osnovnih konceptov MCP, vključno s klient-strežniško arhitekturo, ključnimi komponentami protokola in vzorci sporočanja | [Osnovni koncepti](./01-CoreConcepts/README.md) |
| 02 | **Varnost v MCP** | Prepoznavanje varnostnih groženj v sistemih, ki temeljijo na MCP, tehnike in dobre prakse za varno implementacijo | [Varnost](./02-Security/README.md) |
| 03 | **Začetek z MCP** | Nastavitev okolja in konfiguracija, ustvarjanje osnovnih MCP strežnikov in odjemalcev, integracija MCP z obstoječimi aplikacijami | [Začetek](./03-GettingStarted/README.md) |
| 3.1 | **Prvi strežnik** | Nastavitev osnovnega strežnika z uporabo MCP protokola, razumevanje interakcije med strežnikom in odjemalcem ter testiranje strežnika | [Prvi strežnik](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi odjemalec** | Nastavitev osnovnega odjemalca z uporabo MCP protokola, razumevanje interakcije med odjemalcem in strežnikom ter testiranje odjemalca | [Prvi odjemalec](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Odjemalec z LLM** | Nastavitev odjemalca, ki uporablja MCP protokol z velikim jezikovnim modelom (LLM) | [Odjemalec z LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Uporaba strežnika v Visual Studio Code** | Nastavitev Visual Studio Code za uporabo strežnikov preko MCP protokola | [Uporaba strežnika v Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Ustvarjanje strežnika z SSE** | SSE nam pomaga izpostaviti strežnik na internetu. Ta razdelek vam bo pomagal ustvariti strežnik z uporabo SSE | [Ustvarjanje strežnika z SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Uporaba AI Toolkit** | AI toolkit je odlično orodje, ki vam bo pomagalo upravljati vaš AI in MCP delovni proces | [Uporaba AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Testiranje vašega strežnika** | Testiranje je pomemben del razvojnega procesa. Ta razdelek vam bo pomagal z uporabo več različnih orodij za testiranje | [Testiranje vašega strežnika](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Implementacija strežnika** | Kako preiti iz lokalnega razvoja v produkcijo? Ta razdelek vam bo pomagal razviti in implementirati vaš strežnik | [Implementacija strežnika](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Praktična implementacija** | Uporaba SDK-jev v različnih jezikih, odpravljanje napak, testiranje in validacija, ustvarjanje ponovno uporabnih predlog in delovnih tokov | [Praktična implementacija](./04-PracticalImplementation/README.md) |
| 05 | **Napredne teme v MCP** | Večmodalni AI delovni tokovi in razširljivost, varne strategije skaliranja, MCP v podjetniških okoljih | [Napredne teme](./05-AdvancedTopics/README.md) |
| 5.1 | **Integracija MCP z Azure** | Prikaz integracije z Azure | [Integracija MCP z Azure](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Večmodalnost** | Prikaz dela z različnimi modalitetami, kot so slike in druge | [Večmodalnost](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimalna Spring Boot aplikacija, ki prikazuje OAuth2 z MCP, tako kot avtentikacijski kot tudi kot strežnik virov. Prikazuje varno izdajo žetonov, zaščitene končne točke, implementacijo na Azure Container Apps in integracijo z API Management | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Več o root context in kako jih implementirati | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Usmerjanje** | Spoznajte različne vrste usmerjanja | [Usmerjanje](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Vzorčenje** | Naučite se dela z vzorčenjem | [Vzorčenje](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skaliranje** | Spoznajte skaliranje MCP strežnikov, vključno s horizontalnimi in vertikalnimi strategijami skaliranja, optimizacijo virov in prilagajanjem zmogljivosti | [Skaliranje](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Varnost** | Zavarujte vaš MCP strežnik, vključno z avtentikacijo, avtorizacijo in strategijami zaščite podatkov | [Varnost](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP strežnik in odjemalec, ki integrirata SerpAPI za iskanje po spletu, novicah, izdelkih in Q&A v realnem času. Prikazuje orkestracijo več orodij, integracijo zunanjih API-jev in robustno obravnavo napak | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Pretakanje v realnem času** | Pretakanje podatkov v realnem času je danes ključnega pomena, saj podjetja in aplikacije potrebujejo takojšen dostop do informacij za pravočasno odločanje | [Pretakanje v realnem času](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 06 | **Prispevki skupnosti** | Kako prispevati k kodi in dokumentaciji, sodelovanje preko GitHub, izboljšave in povratne informacije, ki jih vodi skupnost | [Prispevki skupnosti](./06-CommunityContributions/README.md) |
| 07 | **Izkušnje zgodnjih uporabnikov** | Resnični primeri implementacij in kaj je delovalo, gradnja in implementacija rešitev na osnovi MCP, trendi in prihodnji načrti | [Izkušnje](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najboljše prakse za MCP** | Prilagajanje zmogljivosti in optimizacija, načrtovanje odpornosti MCP sistemov, testiranje in strategije odpornosti | [Najboljše prakse](./08-BestPractices/README.md)
| 09 | **MCP Case Studies** | Podrobni vpogledi v arhitekture MCP rešitev, načrte uvajanja in nasvete za integracijo, opremljeni diagrami in predstavitve projektov | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Poenostavitev AI delovnih tokov: Gradnja MCP strežnika z AI Toolkit** | Celovit praktični delavnica, ki združuje MCP z Microsoftovim AI Toolkit za VS Code. Naučite se graditi inteligentne aplikacije, ki povezujejo AI modele z orodji iz resničnega sveta skozi praktične module, ki zajemajo osnove, razvoj prilagojenega strežnika in strategije uvajanja v produkcijo. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Vzorčni projekti

### 🧮 MCP kalkulator vzorčni projekti:
<details>
  <summary><strong>Raziščite implementacije kode po jezikih</strong></summary>

  - [C# MCP Server Primer](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP kalkulator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP strežnik](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP primer](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Napredni MCP kalkulator projekti:
<details>
  <summary><strong>Raziščite napredne vzorce</strong></summary>

  - [Napredni C# primer](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container aplikacija primer](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript napredni primer](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python kompleksna implementacija](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container primer](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 Predpogoji za učenje MCP

Da boste kar najbolje izkoristili ta program, bi morali imeti:

- Osnovno znanje C#, Java ali Python
- Razumevanje modela klient-strežnik in API-jev
- (Neobvezno) Poznavanje konceptov strojnega učenja

## 📚 Vodnik za študij

Na voljo je obsežen [Study Guide](./study_guide.md), ki vam bo pomagal učinkovito krmariti po tem repozitoriju. Vodnik vključuje:

- Vizualni zemljevid kurikuluma z vsemi obravnavanimi temami
- Podroben razčlenitev posameznih delov repozitorija
- Navodila, kako uporabljati vzorčne projekte
- Priporočene poti učenja za različne ravni znanja
- Dodatne vire za podporo vašemu učenju

## 🛠️ Kako učinkovito uporabljati ta kurikulum

Vsaka lekcija v tem vodniku vključuje:

1. Jasna pojasnila MCP konceptov  
2. Žive primere kode v več jezikih  
3. Vaje za gradnjo pravih MCP aplikacij  
4. Dodatne vire za napredne učence  

## 📜 Informacije o licenci

Ta vsebina je licencirana pod **MIT License**. Za pogoje in določila glejte [LICENSE](../../LICENSE).

## 🤝 Navodila za prispevanje

Ta projekt sprejema prispevke in predloge. Večina prispevkov zahteva, da se strinjate s Contributor License Agreement (CLA), s katerim izjavite, da imate pravico in dejansko dovoljujete uporabo vašega prispevka. Za podrobnosti obiščite <https://cla.opensource.microsoft.com>.

Ko oddate pull request, bo CLA bot samodejno preveril, ali morate predložiti CLA, in ustrezno označil PR (npr. statusna preverjanja, komentar). Preprosto sledite navodilom bota. To boste morali narediti le enkrat za vse repozitorije, ki uporabljajo naš CLA.

Ta projekt je sprejel [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). Za več informacij glejte [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) ali kontaktirajte [opencode@microsoft.com](mailto:opencode@microsoft.com) za dodatna vprašanja ali komentarje.

## 🎒 Drugi tečaji
Naša ekipa pripravlja tudi druge tečaje! Oglejte si:

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
- [Izberi svojo lastno Copilot avanturo](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Obvestilo o blagovni znamki

Ta projekt lahko vsebuje blagovne znamke ali logotipe za projekte, izdelke ali storitve. Pooblaščena uporaba Microsoftovih
blagovnih znamk ali logotipov je predmet in mora slediti
[Microsoftovim smernicam za blagovne znamke in znamke](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Uporaba Microsoftovih blagovnih znamk ali logotipov v spremenjenih različicah tega projekta ne sme povzročati zmede ali nakazovati sponzorstva Microsofta.
Vsaka uporaba blagovnih znamk ali logotipov tretjih oseb je predmet politik teh tretjih oseb.

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Ne odgovarjamo za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.