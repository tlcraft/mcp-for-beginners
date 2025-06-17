<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T16:17:28+00:00",
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


Sledite tem korakom, da začnete uporabljati te vire:
1. **Razvezi repozitorij**: Kliknite [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Kloniraj repozitorij**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Pridruži se Azure AI Foundry Discordu in spoznaj strokovnjake ter druge razvijalce**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Podpora za več jezikov

#### Podprto preko GitHub Action (avtomatizirano in vedno posodobljeno)

# 🚀 Kurikulum Model Context Protocol (MCP) za začetnike

## **Naučite se MCP z praktičnimi primeri kode v C#, Java, JavaScript, Python in TypeScript**

## 🧠 Pregled kurikuluma Model Context Protocol

**Model Context Protocol (MCP)** je najsodobnejši okvir, zasnovan za standardizacijo interakcij med AI modeli in odjemalskimi aplikacijami. Ta odprtokodni kurikulum ponuja strukturirano učno pot, ki vključuje praktične primere kode in resnične primere uporabe v priljubljenih programskih jezikih, kot so C#, Java, JavaScript, TypeScript in Python.

Ne glede na to, ali ste razvijalec AI, sistemski arhitekt ali programski inženir, je ta vodič vaš celovit vir za obvladovanje osnov MCP in strategij implementacije.

## 🔗 Uradni viri MCP

- 📘 [MCP Dokumentacija](https://modelcontextprotocol.io/) – Podrobni vodiči in uporabniški priročniki  
- 📜 [MCP Specifikacija](https://spec.modelcontextprotocol.io/) – Arhitektura protokola in tehnične reference  
- 🧑‍💻 [MCP GitHub Repozitorij](https://github.com/modelcontextprotocol) – Odprtokodni SDK-ji, orodja in primeri kode  

## 🧭 Celotna struktura kurikuluma MCP

| Ch | Naslov | Opis | Povezava |
|--|--|--|--|
| 00 | **Uvod v MCP** | Pregled Model Context Protocol in njegovega pomena v AI procesih, vključno s tem, kaj je Model Context Protocol, zakaj je standardizacija pomembna ter praktične uporabe in koristi | [Uvod](./00-Introduction/README.md) |
| 01 | **Razlaga osnovnih konceptov** | Poglobljen pregled osnovnih konceptov MCP, vključno s klient-strežniško arhitekturo, ključnimi komponentami protokola in vzorci sporočanja | [Osnovni koncepti](./01-CoreConcepts/README.md) |
| 02 | **Varnost v MCP** | Prepoznavanje varnostnih groženj v sistemih, ki temeljijo na MCP, tehnike in najboljše prakse za varno implementacijo | [Varnost](./02-Security/README.md) |
| 03 | **Začetek z MCP** | Nastavitev in konfiguracija okolja, ustvarjanje osnovnih MCP strežnikov in odjemalcev, integracija MCP z obstoječimi aplikacijami | [Začetek](./03-GettingStarted/README.md) |
| 3.1 | **Prvi strežnik** | Nastavitev osnovnega strežnika z uporabo MCP protokola, razumevanje interakcije med strežnikom in odjemalcem ter testiranje strežnika | [Prvi strežnik](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi odjemalec** | Nastavitev osnovnega odjemalca z uporabo MCP protokola, razumevanje interakcije med odjemalcem in strežnikom ter testiranje odjemalca | [Prvi odjemalec](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Odjemalec z LLM** | Nastavitev odjemalca z uporabo MCP protokola in velikega jezikovnega modela (LLM) | [Odjemalec z LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Uporaba strežnika v Visual Studio Code** | Nastavitev Visual Studio Code za uporabo strežnikov prek MCP protokola | [Uporaba strežnika v Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Ustvarjanje strežnika s SSE** | SSE omogoča izpostavitev strežnika na internetu. Ta razdelek vam bo pomagal ustvariti strežnik s SSE | [Ustvarjanje strežnika s SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP pretakanje** | Naučite se, kako implementirati HTTP pretakanje za prenos podatkov v realnem času med odjemalci in MCP strežniki | [HTTP pretakanje](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **Uporaba AI orodjarne** | AI orodjarna je odlično orodje, ki vam bo pomagalo upravljati vaš AI in MCP potek dela. | [Uporaba AI orodjarne](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Testiranje vašega strežnika** | Testiranje je pomemben del razvojnega procesa. Ta razdelek vam bo pomagal pri testiranju z uporabo več različnih orodij. | [Testiranje vašega strežnika](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Namestitev strežnika** | Kako preiti iz lokalnega razvoja v produkcijo? Ta razdelek vam bo pomagal razviti in namestiti vaš strežnik. | [Namestitev strežnika](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Praktična implementacija** | Uporaba SDK-jev v različnih jezikih, odpravljanje napak, testiranje in validacija, izdelava ponovno uporabnih predlog in potekov dela | [Praktična implementacija](./04-PracticalImplementation/README.md) |
| 05 | **Napredne teme v MCP** | Večmodalni AI poteki dela in razširljivost, varne strategije skaliranja, MCP v podjetniških ekosistemih | [Napredne teme](./05-AdvancedTopics/README.md) |
| 5.1 | **Integracija MCP z Azure** | Prikazuje integracijo z Azure | [Integracija MCP z Azure](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Večmodalnost** | Prikazuje delo z različnimi modalitetami, kot so slike in druge | [Večmodalnost](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimalna Spring Boot aplikacija, ki prikazuje OAuth2 z MCP, tako kot avtentikacijski kot tudi kot strežnik virov. Prikazuje varno izdajo žetonov, zaščitene končne točke, namestitev v Azure Container Apps in integracijo z API Management. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Izvedite več o root context in kako jih implementirati | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Usmerjanje** | Spoznajte različne vrste usmerjanja | [Usmerjanje](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Vzorčenje** | Naučite se, kako delati z vzorčenjem | [Vzorčenje](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skaliranje** | Spoznajte skaliranje MCP strežnikov, vključno s horizontalnimi in vertikalnimi strategijami, optimizacijo virov in prilagajanjem zmogljivosti | [Skaliranje](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Varnost** | Zavarujte vaš MCP strežnik, vključno z avtentikacijo, avtorizacijo in strategijami zaščite podatkov | [Varnost](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP strežnik in odjemalec, ki se povezuje s SerpAPI za iskanje v realnem času po spletu, novicah, izdelkih in Q&A. Prikazuje večorodno orkestracijo, integracijo zunanjih API-jev in robustno obravnavo napak | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Pretakanje v realnem času** | Pretakanje podatkov v realnem času je postalo ključno v današnjem svetu, kjer podjetja in aplikacije potrebujejo takojšen dostop do informacij za pravočasne odločitve. | [Pretakanje v realnem času](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Iskanje v realnem času po spletu** | Kako MCP spreminja iskanje po spletu v realnem času z zagotavljanjem standardiziranega pristopa k upravljanju konteksta med AI modeli, iskalniki in aplikacijami. | [Iskanje v realnem času po spletu](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Prispevki skupnosti** | Kako prispevati k kodi in dokumentaciji, sodelovanje prek GitHub, izboljšave, ki jih vodi skupnost, in povratne informacije | [Prispevki skupnosti](./06-CommunityContributions/README.md) |
| 07 | **Vpogledi iz zgodnje uporabe** | Dejanske implementacije in kaj je delovalo, gradnja in uvajanje rešitev na osnovi MCP, trendi in prihodnja pot | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najboljše prakse za MCP** | Nastavljanje in optimizacija zmogljivosti, načrtovanje odpornih MCP sistemov, strategije testiranja in odpornosti | [Best Practices](./08-BestPractices/README.md) |
| 09 | **Primeri uporabe MCP** | Poglobljene analize arhitektur MCP rešitev, načrti uvajanja in nasveti za integracijo, označeni diagrami in vodniki skozi projekte | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Poenostavitev AI delovnih tokov: Gradnja MCP strežnika z AI orodnim kompletom** | Celovit praktični delavnica, ki združuje MCP z Microsoftovim AI orodnim kompletom za VS Code. Naučite se graditi inteligentne aplikacije, ki povezujejo AI modele z dejanskimi orodji preko praktičnih modulov, ki zajemajo osnove, razvoj po meri strežnika in strategije uvajanja v produkcijo. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Vzorčni projekti

### 🧮 Vzorčni projekti MCP kalkulatorja:
<details>
  <summary><strong>Raziskujte implementacije kode po jezikih</strong></summary>

  - [C# MCP strežnik primer](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP kalkulator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP strežnik](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP primer](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Napredni MCP kalkulator projekti:
<details>
  <summary><strong>Raziskujte napredne vzorce</strong></summary>

  - [Napredni C# vzorec](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java aplikacija v kontejnerju](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript napredni vzorec](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python kompleksna implementacija](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript kontejnerski vzorec](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Predpogoji za učenje MCP

Da boste iz tega učnega načrta kar najbolje izkoristili, morate imeti:

- Osnovno znanje C#, Java ali Python
- Razumevanje modela klient-strežnik in API-jev
- (Neobvezno) Poznavanje konceptov strojnega učenja

## 📚 Učni vodič

Na voljo je obsežen [Učni vodič](./study_guide.md), ki vam bo pomagal učinkovito raziskovati ta repozitorij. Vodič vključuje:

- Vizualni zemljevid učnega načrta z vsemi pokritimi temami
- Podroben razčlenitev posameznih delov repozitorija
- Navodila za uporabo vzorčnih projektov
- Priporočene učne poti za različne ravni znanja
- Dodatne vire za dopolnitev vašega učenja

## 🛠️ Kako učinkovito uporabljati ta učni načrt

Vsaka lekcija v tem vodiču vključuje:

1. Jasna pojasnila konceptov MCP  
2. Primeri kode v živo v več jezikih  
3. Vaje za izdelavo pravih MCP aplikacij  
4. Dodatne vire za napredne učence  

## 📜 Informacije o licenci

Ta vsebina je licencirana pod **MIT licenco**. Za pogoje in določila glejte [LICENSE](../../LICENSE).

## 🤝 Smernice za prispevke

Ta projekt sprejema prispevke in predloge. Večina prispevkov zahteva, da se strinjate z
Contributor License Agreement (CLA), s katerim izjavljate, da imate pravico in dejansko omogočate,
da uporabljamo vaš prispevek. Za podrobnosti obiščite <https://cla.opensource.microsoft.com>.

Ko oddate pull request, bo CLA bot samodejno preveril, ali morate predložiti
CLA in ustrezno označil PR (npr. statusna kontrola, komentar). Preprosto sledite navodilom,
ki jih poda bot. To boste morali narediti samo enkrat za vse repozitorije, ki uporabljajo naš CLA.

Ta projekt je sprejel [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
Za več informacij glejte [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) ali
kontaktirajte [opencode@microsoft.com](mailto:opencode@microsoft.com) za dodatna vprašanja ali komentarje.

## 🎒 Drugi tečaji
Naša ekipa ustvarja tudi druge tečaje! Oglejte si:

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
- [Obvladovanje GitHub Copilot za AI parno programiranje](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Obvladovanje GitHub Copilot za razvijalce C#/.NET](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Izberi svojo Copilot pustolovščino](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Obvestilo o blagovni znamki

Ta projekt lahko vsebuje blagovne znamke ali logotipe za projekte, izdelke ali storitve. Pooblaščena uporaba Microsoftovih
blagovnih znamk ali logotipov je predmet in mora upoštevati
[Microsoftove smernice za blagovne znamke in znamčenje](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Uporaba Microsoftovih blagovnih znamk ali logotipov v spremenjenih različicah tega projekta ne sme povzročiti zmede ali nakazovati Microsoftovega sponzorstva.
Vsaka uporaba blagovnih znamk ali logotipov tretjih oseb je predmet pravil teh tretjih oseb.

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Ne odgovarjamo za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.