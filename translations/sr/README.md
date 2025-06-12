<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c7fbf0cdaa44b3245daff0c8bb4f439e",
  "translation_date": "2025-06-11T16:27:21+00:00",
  "source_file": "README.md",
  "language_code": "sr"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.sr.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Pratite ove korake da biste započeli sa korišćenjem ovih resursa:
1. **Forkujte repozitorijum**: Kliknite [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klonirajte repozitorijum**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Pridružite se Azure AI Foundry Discord-u i upoznajte stručnjake i druge developere**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Podrška za više jezika

#### Podržano putem GitHub akcije (Automatski i uvek ažurno)

# 🚀 Kurikulum za Model Context Protocol (MCP) za početnike

## **Naučite MCP kroz praktične primere koda u C#, Java, JavaScript, Python i TypeScript**

## 🧠 Pregled kurikuluma za Model Context Protocol

**Model Context Protocol (MCP)** je savremeni okvir osmišljen da standardizuje interakcije između AI modela i klijentskih aplikacija. Ovaj otvoreni kurikulum pruža strukturisan put učenja, sa praktičnim primerima koda i stvarnim slučajevima upotrebe, na popularnim programskim jezicima kao što su C#, Java, JavaScript, TypeScript i Python.

Bilo da ste AI developer, sistemski arhitekta ili softverski inženjer, ovaj vodič je vaš sveobuhvatni resurs za savladavanje osnova MCP-a i strategija implementacije.

## 🔗 Zvanični MCP resursi

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Detaljni tutorijali i korisnički vodiči  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Arhitektura protokola i tehničke reference  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Open-source SDK-ovi, alati i primeri koda  

## 🧭 Kompletna struktura MCP kurikuluma

| Ch | Naslov | Opis | Link |
|--|--|--|--|
| 00 | **Uvod u MCP** | Pregled Model Context Protocol-a i njegov značaj u AI tokovima, uključujući šta je MCP, zašto je standardizacija važna i praktične primere i koristi | [Introduction](./00-Introduction/README.md) |
| 01 | **Objašnjeni osnovni pojmovi** | Detaljno objašnjenje osnovnih pojmova MCP-a, uključujući klijent-server arhitekturu, ključne komponente protokola i obrasce poruka | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **Bezbednost u MCP-u** | Identifikacija bezbednosnih pretnji u sistemima zasnovanim na MCP-u, tehnike i najbolje prakse za bezbednu implementaciju | [Security](/02-Security/README.md) |
| 03 | **Početak rada sa MCP-om** | Postavljanje i konfiguracija okruženja, kreiranje osnovnih MCP servera i klijenata, integracija MCP-a sa postojećim aplikacijama | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **Prvi server** | Postavljanje osnovnog servera koristeći MCP protokol, razumevanje interakcije server-klijent i testiranje servera | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi klijent**  | Postavljanje osnovnog klijenta koristeći MCP protokol, razumevanje interakcije klijent-server i testiranje klijenta | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klijent sa LLM-om**  | Postavljanje klijenta koristeći MCP protokol sa velikim jezičkim modelom (LLM) | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Korišćenje servera u Visual Studio Code-u** | Podešavanje Visual Studio Code-a za korišćenje servera preko MCP protokola | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Kreiranje servera koristeći SSE** | SSE nam pomaže da izložimo server na internetu. Ovaj deo će vam pomoći da kreirate server koristeći SSE | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Korišćenje AI Toolkit-a** | AI Toolkit je odličan alat koji će vam pomoći da upravljate svojim AI i MCP radnim tokovima. | [Use AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Testiranje vašeg servera** | Testiranje je važan deo procesa razvoja. Ovaj deo će vam pomoći da koristite različite alate za testiranje. | [Testing your server](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Deploy vašeg servera** | Kako preći sa lokalnog razvoja na produkciju? Ovaj deo će vam pomoći da razvijete i postavite server. | [Deploy your server](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Praktična implementacija** | Korišćenje SDK-ova na različitim jezicima, otklanjanje grešaka, testiranje i validacija, kreiranje ponovo upotrebljivih šablona i tokova | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **Napredne teme u MCP-u** | Višemodalni AI tokovi i proširivost, bezbedne strategije skaliranja, MCP u enterprise okruženjima | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP integracija sa Azure-om** | Prikazuje integraciju sa Azure-om | [MCP Azure integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Višemodalnost** | Prikazuje rad sa različitim modalitetima kao što su slike i drugi | [Multi modality](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimalna Spring Boot aplikacija koja pokazuje OAuth2 sa MCP-om, kao Authorization i Resource Server. Demonstrira sigurno izdavanje tokena, zaštićene krajnje tačke, deployment na Azure Container Apps i integraciju sa API Management-om. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Saznajte više o root context-u i kako ih implementirati | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Naučite različite tipove rutiranja | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Naučite kako da radite sa sampling-om | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skaliranje** | Naučite o skaliranju MCP servera, uključujući horizontalne i vertikalne strategije skaliranja, optimizaciju resursa i podešavanje performansi | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Bezbednost** | Osigurajte svoj MCP server, uključujući autentifikaciju, autorizaciju i strategije zaštite podataka | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP server i klijent koji integrišu SerpAPI za pretragu veba, vesti, proizvoda i Q&A u realnom vremenu. Demonstrira orkestraciju više alata, integraciju eksternih API-ja i robusno rukovanje greškama | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Realtime Streaming** | Streaming podataka u realnom vremenu postao je ključan u današnjem svetu vođenom podacima, gde preduzeća i aplikacije zahtevaju trenutni pristup informacijama za pravovremene odluke. | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 06 | **Doprinosi zajednice** | Kako doprineti kodom i dokumentacijom, saradnja preko GitHub-a, poboljšanja i povratne informacije iz zajednice | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **Uvidi iz ranog usvajanja** | Stvarne implementacije i šta je funkcionisalo, izgradnja i postavljanje rešenja zasnovanih na MCP-u, trendovi i budući planovi | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najbolje prakse za MCP** | Podešavanje performansi i optimizacija, dizajn otpornog MCP sistema, strategije testiranja i otpornosti | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP Studije slučaja** | Detaljni prikazi arhitektura MCP rešenja, šabloni za implementaciju i saveti za integraciju, sa anotiranim dijagramima i pregledima projekata | [Studije slučaja](./09-CaseStudy/README.md) |
| 10 | **Optimizacija AI radnih tokova: Izgradnja MCP servera sa AI Toolkit-om** | Sveobuhvatan praktični radionica koja kombinuje MCP sa Microsoftovim AI Toolkit-om za VS Code. Naučite kako da pravite inteligentne aplikacije koje povezuju AI modele sa stvarnim alatima kroz praktične module koji pokrivaju osnove, razvoj prilagođenog servera i strategije za produkcijsko postavljanje. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Primeri projekata

### 🧮 MCP Kalkulator primeri projekata:
<details>
  <summary><strong>Pregled implementacija koda po jezicima</strong></summary>

  - [C# MCP Server primer](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Kalkulator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP primer](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Napredni kalkulator projekti:
<details>
  <summary><strong>Pregled naprednih primera</strong></summary>

  - [Napredni C# primer](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java primer Container aplikacije](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript napredni primer](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python kompleksna implementacija](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container primer](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 Preduslovi za učenje MCP-a

Da biste maksimalno iskoristili ovaj kurikulum, trebalo bi da imate:

- Osnovno znanje C#, Java ili Python jezika  
- Razumevanje modela klijent-server i API-ja  
- (Opcionalno) Poznavanje koncepta mašinskog učenja  

## 📚 Vodič za učenje

Dostupan je sveobuhvatan [Vodič za učenje](./study_guide.md) koji će vam pomoći da efikasno koristite ovaj repozitorijum. Vodič uključuje:

- Vizuelnu mapu kurikuluma sa svim pokrivenim temama  
- Detaljnu razradu svakog dela repozitorijuma  
- Uputstva za korišćenje primera projekata  
- Preporučene putanje učenja za različite nivoe znanja  
- Dodatne resurse koji upotpunjuju vaš proces učenja  

## 🛠️ Kako efikasno koristiti ovaj kurikulum

Svaka lekcija u ovom vodiču sadrži:

1. Jasna objašnjenja MCP koncepata  
2. Primeri koda uživo na više jezika  
3. Vežbe za pravljenje stvarnih MCP aplikacija  
4. Dodatne resurse za napredne učenike  

## 📜 Informacije o licenci

Ovaj sadržaj je licenciran pod **MIT licencom**. Za uslove korišćenja pogledajte [LICENSE](../../LICENSE).

## 🤝 Uputstva za doprinos

Ovaj projekat pozdravlja doprinose i sugestije. Većina doprinosa zahteva da se saglasite sa Contributor License Agreement (CLA) koji potvrđuje da imate pravo i zaista dajete prava za korišćenje vašeg doprinosa. Za detalje posetite <https://cla.opensource.microsoft.com>.

Kada podnesete pull request, CLA bot će automatski odrediti da li je potrebno da dostavite CLA i prikazaće odgovarajuće oznake (npr. status check, komentar). Jednostavno pratite uputstva koja daje bot. Ovo je potrebno uraditi samo jednom za sve repozitorijume koji koriste naš CLA.

Ovaj projekat je usvojio [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). Za više informacija pogledajte [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) ili kontaktirajte [opencode@microsoft.com](mailto:opencode@microsoft.com) za dodatna pitanja ili komentare.

## 🎒 Ostali kursevi
Naš tim proizvodi i druge kurseve! Pogledajte:

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
- [Izaberi svoju Copilot avanturu](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Obaveštenje o žigu

Ovaj projekat može sadržati žigove ili logoe za projekte, proizvode ili usluge. Ovlašćena upotreba Microsoft
žigova ili logotipa podleže i mora se pridržavati
[Microsoft-ovih smernica za žigove i brend](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Korišćenje Microsoft žigova ili logotipa u modifikovanim verzijama ovog projekta ne sme izazvati zabunu niti sugerisati sponzorstvo Microsoft-a.
Svaka upotreba žigova ili logotipa trećih strana podleže pravilima tih trećih strana.

**Ограничење одговорности**:  
Овај документ је преведен помоћу AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, имајте у виду да аутоматизовани преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешне тумачења која могу настати коришћењем овог превода.