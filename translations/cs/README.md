<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T16:07:51+00:00",
  "source_file": "README.md",
  "language_code": "cs"
}
-->
![MCP-pro-začátečníky](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.cs.png) 

[![GitHub přispěvatelé](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub problémy](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull requesty](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub sledující](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forky](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub hvězdy](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Postupujte podle těchto kroků, abyste mohli začít používat tyto zdroje:
1. **Vytvořte Fork repozitáře**: Klikněte na [![GitHub forky](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Naklonujte repozitář**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Připojte se k Azure AI Foundry Discordu a setkejte se s experty a dalšími vývojáři**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Podpora více jazyků

#### Podporováno přes GitHub Action (automatizované a vždy aktuální)

# 🚀 Kurikulum Model Context Protocol (MCP) pro začátečníky

## **Naučte se MCP na praktických příkladech v C#, Java, JavaScript, Python a TypeScript**

## 🧠 Přehled kurikula Model Context Protocol

**Model Context Protocol (MCP)** je špičkový rámec navržený pro standardizaci interakcí mezi AI modely a klientskými aplikacemi. Toto open-source kurikulum nabízí strukturovanou cestu učení, včetně praktických příkladů kódu a reálných případů použití v populárních programovacích jazycích jako C#, Java, JavaScript, TypeScript a Python.

Ať už jste vývojář AI, systémový architekt nebo softwarový inženýr, tento průvodce je vaším komplexním zdrojem pro zvládnutí základů MCP a strategií implementace.

## 🔗 Oficiální zdroje MCP

- 📘 [MCP Dokumentace](https://modelcontextprotocol.io/) – Podrobné tutoriály a uživatelské příručky  
- 📜 [MCP Specifikace](https://spec.modelcontextprotocol.io/) – Architektura protokolu a technické reference  
- 🧑‍💻 [MCP GitHub Repozitář](https://github.com/modelcontextprotocol) – Open-source SDK, nástroje a ukázky kódu  

## 🧭 Kompletní struktura kurikula MCP

| Kapitola | Název | Popis | Odkaz |
|--|--|--|--|
| 00 | **Úvod do MCP** | Přehled Model Context Protocol a jeho význam v AI pipelinech, včetně toho, co MCP je, proč je standardizace důležitá a praktické případy použití a výhody | [Úvod](./00-Introduction/README.md) |
| 01 | **Vysvětlení základních pojmů** | Podrobný průzkum základních konceptů MCP, včetně klient-server architektury, klíčových komponent protokolu a vzorů zpráv | [Základní pojmy](./01-CoreConcepts/README.md) |
| 02 | **Bezpečnost v MCP** | Identifikace bezpečnostních hrozeb v systémech založených na MCP, techniky a osvědčené postupy zabezpečení implementací | [Bezpečnost](./02-Security/README.md) |
| 03 | **Začínáme s MCP** | Nastavení a konfigurace prostředí, tvorba základních MCP serverů a klientů, integrace MCP do stávajících aplikací | [Začínáme](./03-GettingStarted/README.md) |
| 3.1 | **První server** | Nastavení základního serveru pomocí MCP protokolu, pochopení interakce server-klient a testování serveru | [První server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **První klient** | Nastavení základního klienta pomocí MCP protokolu, pochopení interakce klient-server a testování klienta | [První klient](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klient s LLM** | Nastavení klienta používajícího MCP protokol s velkým jazykovým modelem (LLM) | [Klient s LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Použití serveru ve Visual Studio Code** | Nastavení Visual Studio Code pro využívání serverů pomocí MCP protokolu | [Použití serveru ve Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Vytvoření serveru pomocí SSE** | SSE nám pomáhá zpřístupnit server na internetu. Tato část vám pomůže vytvořit server pomocí SSE | [Vytvoření serveru pomocí SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP Streaming** | Naučte se implementovat HTTP streaming pro přenos dat v reálném čase mezi klienty a MCP servery | [HTTP Streaming](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **Použití AI Toolkit** | AI toolkit je skvělý nástroj, který vám pomůže spravovat váš AI a MCP workflow. | [Použití AI Toolkit](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Testování vašeho serveru** | Testování je důležitou součástí vývojového procesu. Tato část vám pomůže otestovat server pomocí různých nástrojů. | [Testování vašeho serveru](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Nasazení vašeho serveru** | Jak přejít z lokálního vývoje do produkce? Tato část vám pomůže vyvinout a nasadit váš server. | [Nasazení vašeho serveru](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Praktická implementace** | Použití SDK v různých jazycích, ladění, testování a validace, tvorba znovupoužitelných šablon promptů a workflow | [Praktická implementace](./04-PracticalImplementation/README.md) |
| 05 | **Pokročilá témata MCP** | Multi-modální AI workflow a rozšiřitelnost, bezpečné škálování, MCP v podnikových ekosystémech | [Pokročilá témata](./05-AdvancedTopics/README.md) |
| 5.1 | **Integrace MCP s Azure** | Ukazuje integraci s Azure | [Integrace MCP s Azure](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multimodalita** | Ukazuje práci s různými modalitami jako jsou obrázky a další | [Multimodalita](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimální Spring Boot aplikace ukazující OAuth2 s MCP, jak jako autorizační, tak resource server. Demonstruje bezpečné vydávání tokenů, chráněné endpointy, nasazení v Azure Container Apps a integraci s API Management. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Více o root kontextu a jak je implementovat | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Naučte se různé typy směrování | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Naučte se pracovat s samplingem | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Škálování** | Naučte se o škálování MCP serverů, včetně horizontálních a vertikálních strategií, optimalizace zdrojů a ladění výkonu | [Škálování](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Bezpečnost** | Zabezpečte svůj MCP server, včetně autentizace, autorizace a strategií ochrany dat | [Bezpečnost](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP server a klient integrující SerpAPI pro vyhledávání na webu, zprávách, produktech a Q&A v reálném čase. Demonstruje orchestraci více nástrojů, integraci externích API a robustní zpracování chyb | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Realtime Streaming** | Přenos dat v reálném čase se stal nezbytností v dnešním světě řízeném daty, kde firmy a aplikace potřebují okamžitý přístup k informacím pro včasná rozhodnutí. | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Realtime Web Search** | Jak MCP mění vyhledávání na webu v reálném čase tím, že poskytuje standardizovaný přístup k řízení kontextu napříč AI modely, vyhledávači a aplikacemi. | [Realtime Web Search](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Příspěvky komunity** | Jak přispívat kódem a dokumentací, spolupráce přes GitHub, komunitou řízené vylepšení a zpětná vazba | [Příspěvky komunity](./06-CommunityContributions/README.md) |
| 07 | **Poznatky z raného přijetí** | Reálné implementace a co fungovalo, vytváření a nasazování řešení založených na MCP, trendy a budoucí plán | [Poznatky](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Nejlepší postupy pro MCP** | Ladění výkonu a optimalizace, návrh odolných systémů MCP, strategie testování a odolnosti | [Nejlepší postupy](./08-BestPractices/README.md) |
| 09 | **Případové studie MCP** | Hloubkové analýzy architektur řešení MCP, šablony nasazení a tipy pro integraci, anotované diagramy a průchody projekty | [Případové studie](./09-CaseStudy/README.md) |
| 10 | **Zjednodušení AI pracovních postupů: Vytvoření MCP serveru s AI Toolkit** | Komplexní praktický workshop kombinující MCP s Microsoft AI Toolkit pro VS Code. Naučte se vytvářet inteligentní aplikace propojující AI modely s reálnými nástroji prostřednictvím praktických modulů pokrývajících základy, vývoj vlastního serveru a strategie nasazení do produkce. | [Praktický kurz](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Ukázkové projekty

### 🧮 Ukázkové projekty MCP kalkulačky:
<details>
  <summary><strong>Prozkoumejte implementace kódu podle jazyka</strong></summary>

  - [Příklad MCP serveru v C#](./03-GettingStarted/samples/csharp/README.md)
  - [MCP kalkulačka v Javě](./03-GettingStarted/samples/java/calculator/README.md)
  - [MCP demo v JavaScriptu](./03-GettingStarted/samples/javascript/README.md)
  - [MCP server v Pythonu](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [Příklad MCP v TypeScriptu](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Pokročilé projekty MCP kalkulačky:
<details>
  <summary><strong>Prozkoumejte pokročilé ukázky</strong></summary>

  - [Pokročilý příklad v C#](./04-PracticalImplementation/samples/csharp/README.md)
  - [Příklad Java Container aplikace](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [Pokročilý příklad v JavaScriptu](./04-PracticalImplementation/samples/javascript/README.md)
  - [Složitá implementace v Pythonu](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [Příklad Container v TypeScriptu](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 Předpoklady pro studium MCP

Abyste z tohoto kurikula vytěžili co nejvíce, měli byste mít:

- Základní znalosti C#, Javy nebo Pythonu  
- Pochopení klient-server modelu a API  
- (Volitelné) Znalost základů strojového učení  

## 📚 Studijní průvodce

K dispozici je komplexní [Studijní průvodce](./study_guide.md), který vám pomůže efektivně se orientovat v tomto repozitáři. Průvodce obsahuje:

- Vizualizaci osnovy pokrývající všechny témata  
- Podrobný rozbor jednotlivých částí repozitáře  
- Návody, jak používat ukázkové projekty  
- Doporučené studijní cesty pro různé úrovně znalostí  
- Další zdroje k doplnění vašeho studia  

## 🛠️ Jak efektivně používat toto kurikulum

Každá lekce v tomto průvodci obsahuje:

1. Jasná vysvětlení konceptů MCP  
2. Živé příklady kódu v několika jazycích  
3. Cvičení pro tvorbu reálných MCP aplikací  
4. Další zdroje pro pokročilé uživatele  

## 📜 Informace o licenci

Tento obsah je licencován pod **MIT licencí**. Podmínky naleznete v souboru [LICENSE](../../LICENSE).

## 🤝 Pravidla přispívání

Tento projekt vítá příspěvky a návrhy. Většina příspěvků vyžaduje, abyste souhlasili s Contributor License Agreement (CLA), ve kterém prohlašujete, že máte právo a skutečně udělujete práva k použití vašeho příspěvku. Podrobnosti najdete na <https://cla.opensource.microsoft.com>.

Po odeslání pull requestu automaticky CLA bot zjistí, zda je potřeba CLA poskytnout, a označí PR příslušně (např. kontrola stavu, komentář). Stačí postupovat podle pokynů bota. Toto je potřeba udělat pouze jednou pro všechny repozitáře používající naši CLA.

Tento projekt přijal [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). Pro více informací navštivte [Často kladené dotazy k Code of Conduct](https://opensource.microsoft.com/codeofconduct/faq/) nebo kontaktujte [opencode@microsoft.com](mailto:opencode@microsoft.com) s dalšími dotazy či připomínkami.

## 🎒 Další kurzy
Náš tým připravuje i další kurzy! Podívejte se na:

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
- [Ovládnutí GitHub Copilot pro AI párové programování](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Ovládnutí GitHub Copilot pro vývojáře C#/.NET](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Vyberte si vlastní dobrodružství s Copilotem](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Upozornění na ochrannou známku

Tento projekt může obsahovat ochranné známky nebo loga projektů, produktů či služeb. Autorizované použití ochranných známek nebo log Microsoftu podléhá a musí dodržovat
[Pravidla používání ochranných známek a značek Microsoft](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Použití ochranných známek nebo log Microsoftu v upravených verzích tohoto projektu nesmí vést k záměně ani naznačovat sponzorství Microsoftem.
Jakékoli použití ochranných známek nebo log třetích stran podléhá pravidlům těchto třetích stran.

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho původním jazyce by měl být považován za závazný zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo mylné výklady vyplývající z použití tohoto překladu.