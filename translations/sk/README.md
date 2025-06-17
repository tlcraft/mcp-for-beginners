<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T16:09:27+00:00",
  "source_file": "README.md",
  "language_code": "sk"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.sk.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Postupujte podľa týchto krokov, aby ste mohli začať používať tieto zdroje:
1. **Vytvorte fork repozitára**: Kliknite na [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Naklonujte repozitár**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Pridajte sa do Azure AI Foundry Discord a stretnite sa s odborníkmi a ďalšími vývojármi**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Podpora viacerých jazykov

#### Podporované cez GitHub Action (automatizované a vždy aktuálne)

# 🚀 Kurikulum Model Context Protocol (MCP) pre začiatočníkov

## **Naučte sa MCP cez praktické príklady v C#, Java, JavaScript, Python a TypeScript**

## 🧠 Prehľad kurikula Model Context Protocol

**Model Context Protocol (MCP)** je moderný rámec navrhnutý na štandardizáciu interakcií medzi AI modelmi a klientskymi aplikáciami. Toto open-source kurikulum ponúka systematickú učebnú cestu, vrátane praktických príkladov kódu a reálnych prípadov použitia v populárnych programovacích jazykoch ako C#, Java, JavaScript, TypeScript a Python.

Či už ste AI vývojár, systémový architekt alebo softvérový inžinier, tento sprievodca je vaším komplexným zdrojom na zvládnutie základov MCP a stratégií jeho implementácie.

## 🔗 Oficiálne zdroje MCP

- 📘 [MCP Dokumentácia](https://modelcontextprotocol.io/) – Podrobné návody a používateľské príručky  
- 📜 [MCP Špecifikácia](https://spec.modelcontextprotocol.io/) – Architektúra protokolu a technické referencie  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Open-source SDK, nástroje a ukážky kódu  

## 🧭 Kompletná štruktúra kurikula MCP

| Kapitola | Názov | Popis | Odkaz |
|--|--|--|--|
| 00 | **Úvod do MCP** | Prehľad Model Context Protocol a jeho význam v AI pipeline, vrátane toho, čo je MCP, prečo je štandardizácia dôležitá a praktické prípady použitia a výhody | [Úvod](./00-Introduction/README.md) |
| 01 | **Vysvetlenie základných konceptov** | Hlboký rozbor základných konceptov MCP, vrátane klient-server architektúry, kľúčových komponentov protokolu a vzorov správy správ | [Základné koncepty](./01-CoreConcepts/README.md) |
| 02 | **Bezpečnosť v MCP** | Identifikácia bezpečnostných hrozieb v systémoch založených na MCP, techniky a najlepšie praktiky zabezpečenia implementácií | [Bezpečnosť](./02-Security/README.md) |
| 03 | **Začíname s MCP** | Nastavenie a konfigurácia prostredia, vytváranie základných MCP serverov a klientov, integrácia MCP do existujúcich aplikácií | [Začíname](./03-GettingStarted/README.md) |
| 3.1 | **Prvý server** | Nastavenie základného servera pomocou MCP protokolu, pochopenie interakcie server-klient a testovanie servera | [Prvý server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvý klient** | Nastavenie základného klienta pomocou MCP protokolu, pochopenie interakcie klient-server a testovanie klienta | [Prvý klient](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klient s LLM** | Nastavenie klienta pomocou MCP protokolu s veľkým jazykovým modelom (LLM) | [Klient s LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Práca so serverom vo Visual Studio Code** | Nastavenie Visual Studio Code na prácu so servermi používajúcimi MCP protokol | [Práca so serverom vo Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Vytvorenie servera pomocou SSE** | SSE nám pomáha sprístupniť server na internete. Táto časť vám pomôže vytvoriť server pomocou SSE | [Vytvorenie servera pomocou SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP Streaming** | Naučte sa, ako implementovať HTTP streaming pre prenos dát v reálnom čase medzi klientmi a MCP servermi | [HTTP Streaming](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **Použitie AI Toolkit** | AI toolkit je skvelý nástroj, ktorý vám pomôže spravovať váš AI a MCP workflow | [Použitie AI Toolkit](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Testovanie vášho servera** | Testovanie je dôležitou súčasťou vývojového procesu. Táto časť vám pomôže testovať pomocou viacerých nástrojov | [Testovanie vášho servera](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Nasadenie servera** | Ako prejsť z lokálneho vývoja do produkcie? Táto časť vám pomôže vyvinúť a nasadiť server | [Nasadenie servera](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Praktická implementácia** | Použitie SDK v rôznych jazykoch, ladenie, testovanie a validácia, tvorba znovupoužiteľných šablón promptov a pracovných tokov | [Praktická implementácia](./04-PracticalImplementation/README.md) |
| 05 | **Pokročilé témy v MCP** | Multimodálne AI workflow a rozšíriteľnosť, bezpečné škálovanie, MCP v podnikových ekosystémoch | [Pokročilé témy](./05-AdvancedTopics/README.md) |
| 5.1 | **Integrácia MCP s Azure** | Ukazuje integráciu s Azure | [Integrácia MCP s Azure](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multimodalita** | Ukazuje prácu s rôznymi modalitami ako obrázky a ďalšie | [Multimodalita](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimálna Spring Boot aplikácia ukazujúca OAuth2 s MCP ako Authorization a Resource Server. Demonštruje bezpečné vydávanie tokenov, chránené endpointy, nasadenie na Azure Container Apps a integráciu s API Management | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Viac o root context a ako ich implementovať | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Naučte sa rôzne typy routovania | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Naučte sa pracovať so samplingom | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Škálovanie** | Naučte sa o škálovaní MCP serverov vrátane horizontálnych a vertikálnych stratégií, optimalizácie zdrojov a ladenia výkonu | [Škálovanie](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Bezpečnosť** | Zabezpečte svoj MCP Server vrátane autentifikácie, autorizácie a stratégií ochrany dát | [Bezpečnosť](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP server a klient integrujúci SerpAPI pre vyhľadávanie na webe, v novinkách, produktoch a Q&A v reálnom čase. Demonštruje orchestráciu viacerých nástrojov, integráciu externých API a robustné spracovanie chýb | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Realtime Streaming** | Streaming dát v reálnom čase je dnes nevyhnutný v dátovo orientovanom svete, kde firmy a aplikácie potrebujú okamžitý prístup k informáciám pre včasné rozhodovanie | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Realtime Web Search** | Ako MCP mení vyhľadávanie na webe v reálnom čase tým, že poskytuje štandardizovaný prístup k správe kontextu naprieč AI modelmi, vyhľadávačmi a aplikáciami | [Realtime Web Search](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Príspevky komunity** | Ako prispievať kódom a dokumentáciou, spolupráca cez GitHub, komunitou riadené vylepšenia a spätná väzba | [Príspevky komunity](./06-CommunityContributions/README.md) |
| 07 | **Poznatky z rannej adopcie** | Reálne implementácie a čo fungovalo, tvorba a nasadzovanie riešení založených na MCP, trendy a budúca cesta | [Poznatky](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najlepšie postupy pre MCP** | Ladenie výkonu a optimalizácia, návrh MCP systémov odolných voči chybám, testovanie a stratégie odolnosti | [Najlepšie postupy](./08-BestPractices/README.md) |
| 09 | **Prípadové štúdie MCP** | Hĺbkové analýzy architektúr riešení MCP, plány nasadenia a tipy na integráciu, komentované diagramy a prechádzky projektom | [Prípadové štúdie](./09-CaseStudy/README.md) |
| 10 | **Zjednodušenie AI pracovných tokov: Tvorba MCP servera s AI Toolkit** | Komplexný praktický workshop kombinujúci MCP s Microsoft AI Toolkit pre VS Code. Naučte sa vytvárať inteligentné aplikácie prepájajúce AI modely s reálnymi nástrojmi cez praktické moduly pokrývajúce základy, vývoj vlastného servera a stratégie nasadenia do produkcie. | [Praktický workshop](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Ukážkové projekty

### 🧮 Ukážkové projekty MCP kalkulačky:
<details>
  <summary><strong>Preskúmajte implementácie kódu podľa jazyka</strong></summary>

  - [Príklad MCP servera v C#](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP kalkulačka](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [Príklad MCP v TypeScript](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Pokročilé MCP kalkulačné projekty:
<details>
  <summary><strong>Preskúmajte pokročilé ukážky</strong></summary>

  - [Pokročilý príklad v C#](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java príklad kontajnerovej aplikácie](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [Pokročilý JavaScript príklad](./04-PracticalImplementation/samples/javascript/README.md)
  - [Zložitá implementácia v Pythone](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript príklad kontajnera](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 Predpoklady pre štúdium MCP

Aby ste z tohto kurikula získali čo najviac, mali by ste mať:

- Základné znalosti C#, Java alebo Python  
- Pochopenie modelu klient-server a API  
- (Voliteľné) Znalosť konceptov strojového učenia  

## 📚 Študijný sprievodca

K dispozícii je komplexný [Študijný sprievodca](./study_guide.md), ktorý vám pomôže efektívne sa orientovať v tomto repozitári. Sprievodca obsahuje:

- Vizualizáciu kurikula so všetkými témami  
- Detailný rozpis jednotlivých častí repozitára  
- Návody na použitie ukážkových projektov  
- Odporúčané študijné cesty pre rôzne úrovne znalostí  
- Doplnkové zdroje na podporu vášho štúdia  

## 🛠️ Ako efektívne využívať toto kurikulum

Každá lekcia v tomto sprievodcovi obsahuje:

1. Jasné vysvetlenie konceptov MCP  
2. Živé príklady kódu v rôznych jazykoch  
3. Cvičenia na tvorbu reálnych MCP aplikácií  
4. Doplnkové zdroje pre pokročilých študentov  

## 📜 Informácie o licencii

Tento obsah je licencovaný pod **MIT licenciou**. Podmienky nájdete v súbore [LICENSE](../../LICENSE).

## 🤝 Pravidlá prispievania

Tento projekt vítá príspevky a návrhy. Väčšina príspevkov vyžaduje súhlas s Contributor License Agreement (CLA), ktorý potvrdzuje, že máte právo a skutočne udeľujete práva na použitie vášho príspevku. Podrobnosti nájdete na <https://cla.opensource.microsoft.com>.

Pri odoslaní pull requestu automaticky CLA bot zistí, či je potrebné poskytnúť CLA, a označí PR príslušne (napr. kontrola stavu, komentár). Stačí postupovať podľa pokynov bota. Túto procedúru budete musieť absolvovať iba raz pre všetky repozitáre využívajúce náš CLA.

Tento projekt prijal [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). Pre viac informácií navštívte [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) alebo kontaktujte [opencode@microsoft.com](mailto:opencode@microsoft.com) s ďalšími otázkami či pripomienkami.

## 🎒 Ďalšie kurzy
Náš tím vytvára aj ďalšie kurzy! Pozrite si:

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
- [Ovládnutie GitHub Copilot pre AI párové programovanie](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Ovládnutie GitHub Copilot pre vývojárov C#/.NET](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Vyberte si vlastné Copilot dobrodružstvo](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Upozornenie na ochrannú známku

Tento projekt môže obsahovať ochranné známky alebo logá projektov, produktov alebo služieb. Povolené používanie ochranných známok alebo log spoločnosti Microsoft podlieha a musí dodržiavať
[Pravidlá používania ochranných známok a značiek spoločnosti Microsoft](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Použitie ochranných známok alebo log spoločnosti Microsoft v upravených verziách tohto projektu nesmie viesť k nejasnostiam ani naznačovať sponzorstvo spoločnosťou Microsoft.
Akékoľvek použitie ochranných známok alebo log tretích strán podlieha pravidlám týchto tretích strán.

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, majte prosím na pamäti, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.