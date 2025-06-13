<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26ab12045ee411ab7ad0eb0b1b7b1cbb",
  "translation_date": "2025-06-13T01:18:34+00:00",
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


Slijedite ove korake da biste započeli s korištenjem ovih resursa:
1. **Forkajte repozitorij**: Kliknite [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klonirajte repozitorij**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Pridružite se Azure AI Foundry Discordu i upoznajte stručnjake i druge developere**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Podrška za više jezika

#### Podržano putem GitHub akcije (automatizirano i uvijek ažurirano)

# 🚀 Model Context Protocol (MCP) Kurikulum za Početnike

## **Naučite MCP kroz praktične primjere koda u C#, Java, JavaScript, Python i TypeScript**

## 🧠 Pregled Model Context Protocol Kurikuluma

**Model Context Protocol (MCP)** je napredni okvir dizajniran za standardizaciju interakcija između AI modela i klijentskih aplikacija. Ovaj open-source kurikulum nudi strukturirani put učenja, s praktičnim primjerima koda i stvarnim slučajevima korištenja, na popularnim programskim jezicima kao što su C#, Java, JavaScript, TypeScript i Python.

Bilo da ste AI developer, sistemski arhitekt ili softverski inženjer, ovaj vodič je vaš sveobuhvatni resurs za savladavanje osnova MCP-a i strategija implementacije.

## 🔗 Službeni MCP Resursi

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Detaljni tutorijali i korisnički vodiči  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Arhitektura protokola i tehničke reference  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Open-source SDK-ovi, alati i primjeri koda  

## 🧭 Struktura Potpunog MCP Kurikuluma

| Ch | Naslov | Opis | Link |
|--|--|--|--|
| 00 | **Uvod u MCP** | Pregled Model Context Protocola i njegova važnost u AI procesima, uključujući što je Model Context Protocol, zašto je standardizacija važna te praktične primjere i prednosti | [Introduction](./00-Introduction/README.md) |
| 01 | **Objašnjeni osnovni koncepti** | Dubinsko proučavanje osnovnih koncepata MCP-a, uključujući klijent-server arhitekturu, ključne komponente protokola i obrasce poruka | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **Sigurnost u MCP-u** | Identifikacija sigurnosnih prijetnji u sustavima temeljenim na MCP-u, tehnike i najbolje prakse za sigurnu implementaciju | [Security](/02-Security/README.md) |
| 03 | **Početak rada s MCP-om** | Postavljanje okruženja i konfiguracija, kreiranje osnovnih MCP servera i klijenata, integracija MCP-a s postojećim aplikacijama | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **Prvi server** | Postavljanje osnovnog servera koristeći MCP protokol, razumijevanje interakcije server-klijent i testiranje servera | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi klijent** | Postavljanje osnovnog klijenta koristeći MCP protokol, razumijevanje interakcije klijent-server i testiranje klijenta | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klijent s LLM-om** | Postavljanje klijenta koristeći MCP protokol s velikim jezičnim modelom (LLM) | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Korištenje servera s Visual Studio Code-om** | Postavljanje Visual Studio Code-a za korištenje servera preko MCP protokola | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Kreiranje servera koristeći SSE** | SSE nam pomaže da izložimo server na internet. Ovaj dio će vam pomoći da napravite server koristeći SSE | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Korištenje AI Toolkit-a** | AI toolkit je izvrstan alat koji će vam pomoći u upravljanju AI i MCP radnim procesima. | [Use AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Testiranje vašeg servera** | Testiranje je važan dio procesa razvoja. Ovaj dio će vam pomoći koristiti nekoliko različitih alata za testiranje. | [Testing your server](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Deploy vašeg servera** | Kako prijeći iz lokalnog razvoja u produkciju? Ovaj dio će vam pomoći u razvoju i implementaciji vašeg servera. | [Deploy your server](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Praktična implementacija** | Korištenje SDK-ova u različitim jezicima, debugiranje, testiranje i validacija, kreiranje ponovo iskoristivih predložaka promptova i radnih procesa | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **Napredne teme u MCP-u** | Multi-modalni AI radni procesi i proširivost, sigurnosne strategije skaliranja, MCP u enterprise ekosustavima | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP integracija s Azure** | Prikazuje integraciju s Azureom | [MCP Azure integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multi modalnost** | Pokazuje kako raditi s različitim modalitetima poput slika i drugih | [Multi modality](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimalna Spring Boot aplikacija koja pokazuje OAuth2 s MCP-om, kao Authorization i Resource Server. Demonstrira sigurno izdavanje tokena, zaštićene krajnje točke, deployment u Azure Container Apps i integraciju s API Managementom. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Saznajte više o root contextu i kako ga implementirati | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Naučite različite vrste usmjeravanja | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Naučite kako raditi sa samplingom | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Scaling** | Naučite o skaliranju MCP servera, uključujući horizontalne i vertikalne strategije skaliranja, optimizaciju resursa i podešavanje performansi | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Sigurnost** | Osigurajte svoj MCP server, uključujući strategije autentifikacije, autorizacije i zaštite podataka | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP server i klijent integrirani sa SerpAPI za pretraživanje weba, vijesti, proizvoda i Q&A u stvarnom vremenu. Demonstrira orkestraciju više alata, integraciju vanjskih API-ja i robusno rukovanje greškama | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Realtime Streaming** | Streaming podataka u stvarnom vremenu postao je ključan u današnjem svijetu vođenom podacima, gdje tvrtke i aplikacije trebaju trenutni pristup informacijama za pravovremene odluke. | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Realtime Web Search** | Kako MCP transformira pretraživanje weba u stvarnom vremenu pružajući standardizirani pristup upravljanju kontekstom između AI modela, tražilica i aplikacija. | [Realtime Web Search](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Doprinosi zajednice** | Kako doprinijeti kodom i dokumentacijom, suradnja putem GitHub-a, poboljšanja i povratne informacije vođene zajednicom | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **Uvidi iz ranih usvajanja** | Implementacije u stvarnom svijetu i što je uspjelo, izgradnja i implementacija rješenja temeljenih na MCP-u, trendovi i budući planovi | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najbolje prakse za MCP** | Podešavanje performansi i optimizacija, dizajniranje MCP sustava otpornog na greške, strategije testiranja i otpornosti | [Best Practices](./08-BestPractices/README.md) |
| 09 | **Studije slučaja MCP-a** | Dubinske analize arhitektura MCP rješenja, planovi implementacije i savjeti za integraciju, komentirani dijagrami i vođeni projekti | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Optimizacija AI tijekova rada: Izgradnja MCP servera s AI Toolkitom** | Sveobuhvatna praktična radionica koja kombinira MCP s Microsoftovim AI Toolkitom za VS Code. Naučite kako graditi inteligentne aplikacije koje povezuju AI modele s alatima iz stvarnog svijeta kroz praktične module koji pokrivaju osnove, razvoj prilagođenog servera i strategije implementacije u produkciju. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Primjerni projekti

### 🧮 MCP kalkulator - primjeri projekata:
<details>
  <summary><strong>Istražite implementacije koda po jezicima</strong></summary>

  - [C# MCP Server primjer](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP kalkulator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP primjer](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Napredni MCP kalkulator - projekti:
<details>
  <summary><strong>Istražite napredne primjere</strong></summary>

  - [Napredni C# primjer](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java primjer aplikacije u kontejneru](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript napredni primjer](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python složena implementacija](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript primjer u kontejneru](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Preduvjeti za učenje MCP-a

Da biste izvukli maksimum iz ovog kurikuluma, trebate imati:

- Osnovno znanje C#, Java ili Python
- Razumijevanje modela klijent-server i API-ja
- (Opcionalno) Poznavanje koncepata strojnog učenja

## 📚 Vodič za učenje

Sveobuhvatan [Vodič za učenje](./study_guide.md) dostupan je kako bi vam pomogao učinkovito koristiti ovaj repozitorij. Vodič uključuje:

- Vizualnu mapu kurikuluma sa svim obrađenim temama
- Detaljan pregled svakog dijela repozitorija
- Upute za korištenje primjera projekata
- Preporučene putanje učenja za različite razine znanja
- Dodatne resurse za podršku vašem učenju

## 🛠️ Kako učinkovito koristiti ovaj kurikulum

Svaka lekcija u ovom vodiču sadrži:

1. Jasna objašnjenja MCP koncepata  
2. Primjere koda uživo na više jezika  
3. Vježbe za izradu stvarnih MCP aplikacija  
4. Dodatne resurse za napredne korisnike  

## 📜 Informacije o licenci

Ovaj sadržaj je licenciran pod **MIT licencom**. Za uvjete korištenja pogledajte [LICENSE](../../LICENSE).

## 🤝 Smjernice za doprinos

Ovaj projekt pozdravlja doprinose i prijedloge. Većina doprinosa zahtijeva da se složite s
Contributor License Agreement (CLA) u kojem potvrđujete da imate pravo i zaista dajete
prava na korištenje vašeg doprinosa. Za detalje posjetite <https://cla.opensource.microsoft.com>.

Kada pošaljete pull request, CLA bot će automatski utvrditi trebate li pružiti
CLA i označiti PR na odgovarajući način (npr. status provjera, komentar). Jednostavno slijedite upute
koje vam bot daje. Ovo je potrebno napraviti samo jednom za sve repozitorije koji koriste naš CLA.

Ovaj projekt je usvojio [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
Za više informacija pogledajte [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) ili
kontaktirajte [opencode@microsoft.com](mailto:opencode@microsoft.com) za dodatna pitanja ili komentare.

## 🎒 Ostali tečajevi
Naš tim izrađuje i druge tečajeve! Pogledajte:

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
- [Savladavanje GitHub Copilota za C#/.NET developere](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Izaberi svoju Copilot avanturu](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Obavijest o zaštitnom znaku

Ovaj projekt može sadržavati zaštitne znakove ili logotipe za projekte, proizvode ili usluge. Ovlaštena upotreba Microsoftovih
zaštitnih znakova ili logotipa podliježe i mora se pridržavati
[Microsoftovih smjernica za zaštitne znakove i brend](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Korištenje Microsoftovih zaštitnih znakova ili logotipa u izmijenjenim verzijama ovog projekta ne smije izazvati zabunu niti implicirati sponzorstvo Microsofta.
Svaka upotreba zaštitnih znakova ili logotipa trećih strana podliježe pravilima tih trećih strana.

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.