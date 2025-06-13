<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3b97186cd9162b9fe9b90261e63e32d",
  "translation_date": "2025-06-13T14:32:26+00:00",
  "source_file": "README.md",
  "language_code": "hr"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.hr.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Slijedite ove korake kako biste započeli korištenje ovih resursa:
1. **Napravite fork repozitorija**: Kliknite [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klonirajte repozitorij**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Pridružite se Azure AI Foundry Discordu i upoznajte stručnjake i kolege developere**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Podrška za više jezika

#### Podržano putem GitHub Action (Automatski i uvijek ažurno)

# 🚀 Model Context Protocol (MCP) Kurikulum za Početnike

## **Naučite MCP kroz praktične primjere koda u C#, Java, JavaScript, Python i TypeScript**

## 🧠 Pregled Model Context Protocol Kurikuluma

**Model Context Protocol (MCP)** je napredni okvir dizajniran za standardizaciju interakcija između AI modela i klijentskih aplikacija. Ovaj open-source kurikulum nudi strukturirani put učenja, sa praktičnim primjerima koda i stvarnim slučajevima upotrebe, na popularnim programskim jezicima poput C#, Java, JavaScript, TypeScript i Python.

Bilo da ste AI developer, sistemski arhitekt ili softverski inženjer, ovaj vodič je vaš sveobuhvatni resurs za savladavanje osnova MCP-a i strategija implementacije.

## 🔗 Službeni MCP Resursi

- 📘 [MCP Dokumentacija](https://modelcontextprotocol.io/) – Detaljni tutorijali i korisnički vodiči  
- 📜 [MCP Specifikacija](https://spec.modelcontextprotocol.io/) – Arhitektura protokola i tehničke reference  
- 🧑‍💻 [MCP GitHub Repozitorij](https://github.com/modelcontextprotocol) – Open-source SDK-ovi, alati i primjeri koda  

## 🧭 Kompletna Struktura MCP Kurikuluma

| Ch | Naslov | Opis | Link |
|--|--|--|--|
| 00 | **Uvod u MCP** | Pregled Model Context Protocol-a i njegova važnost u AI pipeline-ima, uključujući što je Model Context Protocol, zašto je standardizacija važna te praktične primjere i prednosti | [Uvod](./00-Introduction/README.md) |
| 01 | **Objašnjeni Osnovni Pojmovi** | Detaljno istraživanje osnovnih pojmova MCP-a, uključujući klijent-server arhitekturu, ključne komponente protokola i obrasce poruka | [Osnovni Pojmovi](./01-CoreConcepts/README.md) |
| 02 | **Sigurnost u MCP-u** | Identifikacija sigurnosnih prijetnji u MCP baziranim sustavima, tehnike i najbolje prakse za sigurnu implementaciju | [Sigurnost](/02-Security/README.md) |
| 03 | **Početak rada s MCP-om** | Postavljanje okruženja i konfiguracija, kreiranje osnovnih MCP servera i klijenata, integracija MCP-a s postojećim aplikacijama | [Početak rada](./03-GettingStarted/README.md) |
| 3.1 | **Prvi server** | Postavljanje osnovnog servera koristeći MCP protokol, razumijevanje interakcije server-klijent i testiranje servera | [Prvi server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi klijent** | Postavljanje osnovnog klijenta koristeći MCP protokol, razumijevanje interakcije klijent-server i testiranje klijenta | [Prvi klijent](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klijent s LLM-om** | Postavljanje klijenta koristeći MCP protokol s velikim jezičnim modelom (LLM) | [Klijent s LLM-om](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Korištenje servera u Visual Studio Code-u** | Postavljanje Visual Studio Code-a za korištenje servera putem MCP protokola | [Korištenje servera u Visual Studio Code-u](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Kreiranje servera pomoću SSE-a** | SSE nam pomaže da izložimo server na internet. Ovaj dio će vam pomoći da kreirate server koristeći SSE | [Kreiranje servera pomoću SSE-a](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP Streaming** | Naučite kako implementirati HTTP streaming za prijenos podataka u stvarnom vremenu između klijenata i MCP servera | [HTTP Streaming](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **Korištenje AI Toolkit-a** | AI toolkit je izvrstan alat koji će vam pomoći u upravljanju AI i MCP radnim tokovima. | [Korištenje AI Toolkit-a](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Testiranje vašeg servera** | Testiranje je važan dio procesa razvoja. Ovaj dio će vam pomoći da koristite nekoliko različitih alata za testiranje. | [Testiranje vašeg servera](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Implementacija servera** | Kako prijeći iz lokalnog razvoja u produkciju? Ovaj dio će vam pomoći u razvoju i implementaciji servera. | [Implementacija servera](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Praktična Implementacija** | Korištenje SDK-ova u različitim jezicima, debugiranje, testiranje i validacija, kreiranje ponovljivih predložaka i radnih tokova | [Praktična Implementacija](./04-PracticalImplementation/README.md) |
| 05 | **Napredne teme u MCP-u** | Multimodalni AI radni tokovi i proširivost, sigurnosne strategije skaliranja, MCP u enterprise ekosustavima | [Napredne teme](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP integracija s Azure-om** | Prikazuje integraciju s Azure-om | [MCP integracija s Azure-om](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multimodalnost** | Pokazuje rad s različitim modalitetima poput slika i drugih | [Multimodalnost](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimalna Spring Boot aplikacija koja pokazuje OAuth2 s MCP-om, kao Authorization i Resource Server. Demonstrira sigurnu izdaju tokena, zaštićene endpoint-e, implementaciju u Azure Container Apps i integraciju s API Management-om. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Saznajte više o root context-u i kako ih implementirati | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Naučite različite vrste rutiranja | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Naučite kako raditi sa sampling-om | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Scaling** | Naučite o skaliranju MCP servera, uključujući horizontalne i vertikalne strategije skaliranja, optimizaciju resursa i podešavanje performansi | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Sigurnost** | Osigurajte svoj MCP server, uključujući autentifikaciju, autorizaciju i strategije zaštite podataka | [Sigurnost](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP server i klijent integrirani sa SerpAPI za pretraživanje weba, vijesti, proizvoda i Q&A u stvarnom vremenu. Demonstrira orkestraciju više alata, integraciju vanjskih API-ja i robusno rukovanje greškama | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Realtime Streaming** | Streaming podataka u stvarnom vremenu postao je ključan u današnjem svijetu vođenom podacima, gdje tvrtke i aplikacije zahtijevaju trenutni pristup informacijama za pravovremene odluke. | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Realtime Web Search** | Kako MCP transformira pretraživanje weba u stvarnom vremenu pružajući standardizirani pristup upravljanju kontekstom između AI modela, tražilica i aplikacija. | [Realtime Web Search](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Doprinosi Zajednice** | Kako doprinijeti kodom i dokumentacijom, suradnja putem GitHub-a, poboljšanja vođena zajednicom i povratne informacije | [Doprinosi Zajednice](./06-CommunityContributions/README.md) |
| 07 | **Uvidi iz rane primjene** | Implementacije u stvarnom svijetu i što je uspjelo, izgradnja i implementacija rješenja temeljenih na MCP-u, trendovi i budući planovi | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najbolje prakse za MCP** | Podešavanje performansi i optimizacija, dizajn otpornog MCP sustava, strategije testiranja i otpornosti | [Best Practices](./08-BestPractices/README.md) |
| 09 | **Studije slučaja MCP-a** | Detaljni pregledi arhitektura MCP rješenja, planovi implementacije i savjeti za integraciju, komentirani dijagrami i vođene prezentacije projekata | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Optimizacija AI radnih procesa: Izgradnja MCP servera s AI Toolkitom** | Sveobuhvatan praktični rad koji kombinira MCP s Microsoftovim AI Toolkitom za VS Code. Naučite kako izgraditi inteligentne aplikacije koje povezuju AI modele sa stvarnim alatima kroz praktične module koji pokrivaju osnove, razvoj prilagođenog servera i strategije produkcijske implementacije. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Primjeri projekata

### 🧮 Primjeri MCP kalkulatora:
<details>
  <summary><strong>Istražite implementacije koda po jeziku</strong></summary>

  - [C# MCP Server primjer](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP kalkulator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP primjer](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Napredni MCP kalkulator projekti:
<details>
  <summary><strong>Istražite napredne primjere</strong></summary>

  - [Napredni C# primjer](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java primjer aplikacije u kontejneru](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript napredni primjer](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python složena implementacija](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript primjer u kontejneru](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 Preduvjeti za učenje MCP-a

Da biste maksimalno iskoristili ovaj kurikulum, trebali biste imati:

- Osnovno znanje C#, Java ili Python
- Razumijevanje klijent-server modela i API-ja
- (Opcionalno) Poznavanje pojmova strojnog učenja

## 📚 Vodič za učenje

Sveobuhvatan [Vodič za učenje](./study_guide.md) dostupan je kako bi vam pomogao efikasno se snalaziti u ovom spremištu. Vodič uključuje:

- Vizualnu kartu kurikuluma sa svim obuhvaćenim temama
- Detaljnu podjelu svake sekcije spremišta
- Upute kako koristiti primjere projekata
- Preporučene putanje učenja za različite razine znanja
- Dodatne resurse za nadopunu vašeg učenja

## 🛠️ Kako učinkovito koristiti ovaj kurikulum

Svaka lekcija u ovom vodiču uključuje:

1. Jasna objašnjenja MCP koncepata  
2. Primjere koda uživo na više jezika  
3. Vježbe za izgradnju stvarnih MCP aplikacija  
4. Dodatne resurse za napredne učenike  

## 📜 Informacije o licenci

Ovaj sadržaj je licenciran pod **MIT licencom**. Za uvjete korištenja pogledajte [LICENSE](../../LICENSE).

## 🤝 Smjernice za doprinos

Ovaj projekt prihvaća doprinose i prijedloge. Većina doprinosa zahtijeva da pristanete na Contributor License Agreement (CLA) kojim izjavljujete da imate pravo i stvarno dajete prava na korištenje vašeg doprinosa. Za detalje posjetite <https://cla.opensource.microsoft.com>.

Kad pošaljete pull request, CLA bot će automatski utvrditi trebate li pružiti CLA i označiti PR na odgovarajući način (npr. status provjera, komentar). Jednostavno slijedite upute koje daje bot. Ovo ćete morati napraviti samo jednom za sve repozitorije koji koriste naš CLA.

Ovaj projekt je usvojio [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). Za više informacija pogledajte [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) ili kontaktirajte [opencode@microsoft.com](mailto:opencode@microsoft.com) za dodatna pitanja ili komentare.

## 🎒 Ostali tečajevi
Naš tim proizvodi i druge tečajeve! Pogledajte:

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
- [Savladavanje GitHub Copilota za AI programiranje u paru](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Savladavanje GitHub Copilota za C#/.NET developere](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Odaberite svoju Copilot avanturu](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Obavijest o zaštitnom znaku

Ovaj projekt može sadržavati zaštitne znakove ili logotipe projekata, proizvoda ili usluga. Ovlaštena upotreba Microsoftovih
zaštitnih znakova ili logotipa podliježe i mora slijediti
[Microsoftove smjernice za zaštitne znakove i brendiranje](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Korištenje Microsoftovih zaštitnih znakova ili logotipa u izmijenjenim verzijama ovog projekta ne smije stvarati zabunu niti implicirati sponzorstvo Microsofta.
Svaka upotreba zaštitnih znakova ili logotipa trećih strana podliježe pravilima tih trećih strana.

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili kriva tumačenja koja proizlaze iz korištenja ovog prijevoda.