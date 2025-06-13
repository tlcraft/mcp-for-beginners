<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3b97186cd9162b9fe9b90261e63e32d",
  "translation_date": "2025-06-13T14:31:18+00:00",
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
1. **Napravite fork repozitorijuma**: Kliknite [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klonirajte repozitorijum**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Pridružite se Azure AI Foundry Discord-u i upoznajte stručnjake i kolege programere**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Višejezička podrška

#### Podržano putem GitHub Action (Automatski i uvek ažurno)

# 🚀 Model Context Protocol (MCP) Kurikulum za Početnike

## **Naučite MCP kroz praktične primere koda u C#, Java, JavaScript, Python i TypeScript**

## 🧠 Pregled Model Context Protocol Kurikuluma

**Model Context Protocol (MCP)** je savremeni okvir osmišljen da standardizuje interakcije između AI modela i klijentskih aplikacija. Ovaj open-source kurikulum nudi strukturisan put učenja, sa praktičnim primerima koda i realnim scenarijima, na popularnim programskim jezicima kao što su C#, Java, JavaScript, TypeScript i Python.

Bilo da ste AI programer, sistemski arhitekta ili softverski inženjer, ovaj vodič je vaš sveobuhvatni resurs za savladavanje osnovnih principa MCP-a i strategija implementacije.

## 🔗 Zvanični MCP Resursi

- 📘 [MCP Dokumentacija](https://modelcontextprotocol.io/) – Detaljni tutorijali i korisnički vodiči  
- 📜 [MCP Specifikacija](https://spec.modelcontextprotocol.io/) – Arhitektura protokola i tehničke reference  
- 🧑‍💻 [MCP GitHub Repozitorijum](https://github.com/modelcontextprotocol) – Open-source SDK-ovi, alati i primeri koda  

## 🧭 Kompletna Struktura MCP Kurikuluma

| Ch | Naslov | Opis | Link |
|--|--|--|--|
| 00 | **Uvod u MCP** | Pregled Model Context Protocol-a i njegov značaj u AI procesima, uključujući šta je Model Context Protocol, zašto je standardizacija važna, kao i praktične primere i koristi | [Uvod](./00-Introduction/README.md) |
| 01 | **Objašnjenje osnovnih pojmova** | Detaljno objašnjenje osnovnih pojmova MCP-a, uključujući klijent-server arhitekturu, ključne komponente protokola i obrasce razmene poruka | [Osnovni pojmovi](./01-CoreConcepts/README.md) |
| 02 | **Bezbednost u MCP-u** | Identifikovanje bezbednosnih pretnji u sistemima zasnovanim na MCP-u, tehnike i najbolje prakse za sigurnu implementaciju | [Bezbednost](./02-Security/README.md) |
| 03 | **Početak rada sa MCP-om** | Podešavanje okruženja i konfiguracija, kreiranje osnovnih MCP servera i klijenata, integracija MCP-a sa postojećim aplikacijama | [Početak rada](./03-GettingStarted/README.md) |
| 3.1 | **Prvi server** | Postavljanje osnovnog servera koristeći MCP protokol, razumevanje interakcije server-klijent i testiranje servera | [Prvi server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi klijent**  | Postavljanje osnovnog klijenta koristeći MCP protokol, razumevanje interakcije klijent-server i testiranje klijenta | [Prvi klijent](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klijent sa LLM-om**  | Postavljanje klijenta koristeći MCP protokol sa velikim jezičkim modelom (LLM) | [Klijent sa LLM-om](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Konzumiranje servera u Visual Studio Code-u** | Podešavanje Visual Studio Code-a za korišćenje servera preko MCP protokola | [Konzumiranje servera u Visual Studio Code-u](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Kreiranje servera koristeći SSE** | SSE nam pomaže da izložimo server na internetu. Ovaj deo će vam pomoći da napravite server koristeći SSE | [Kreiranje servera koristeći SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP Streaming** | Naučite kako da implementirate HTTP streaming za prenos podataka u realnom vremenu između klijenata i MCP servera | [HTTP Streaming](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **Korišćenje AI Toolkit-a** | AI toolkit je odličan alat koji će vam pomoći da upravljate vašim AI i MCP radnim tokovima | [Korišćenje AI Toolkit-a](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Testiranje vašeg servera** | Testiranje je važan deo procesa razvoja. Ovaj deo će vam pomoći da testirate koristeći različite alate | [Testiranje vašeg servera](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Deploy vašeg servera** | Kako preći sa lokalnog razvoja na produkciju? Ovaj deo će vam pomoći da razvijete i postavite vaš server | [Deploy vašeg servera](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Praktična implementacija** | Korišćenje SDK-ova na različitim jezicima, debagovanje, testiranje i validacija, pravljenje ponovo upotrebljivih šablona i radnih tokova | [Praktična implementacija](./04-PracticalImplementation/README.md) |
| 05 | **Napredne teme u MCP-u** | Više-modalni AI radni tokovi i proširivost, bezbedne strategije skaliranja, MCP u poslovnim ekosistemima | [Napredne teme](./05-AdvancedTopics/README.md) |
| 5.1 | **Integracija MCP-a sa Azure-om** | Prikazuje integraciju sa Azure-om | [Integracija MCP sa Azure-om](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Više modaliteta** | Prikazuje rad sa različitim modalitetima poput slika i drugih | [Više modaliteta](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimalna Spring Boot aplikacija koja prikazuje OAuth2 sa MCP-om, kako kao Authorization tako i Resource Server. Demonstrira sigurno izdavanje tokena, zaštićene krajnje tačke, deployment na Azure Container Apps i integraciju sa API Management-om. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Saznajte više o root context-u i kako ih implementirati | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Naučite različite vrste rutiranja | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Naučite kako da radite sa sampling-om | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Scaling** | Naučite o skaliranju MCP servera, uključujući horizontalne i vertikalne strategije skaliranja, optimizaciju resursa i podešavanje performansi | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Security** | Osigurajte vaš MCP server, uključujući strategije autentifikacije, autorizacije i zaštite podataka | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP server i klijent integrisani sa SerpAPI za pretragu weba, vesti, proizvoda i Q&A u realnom vremenu. Prikazuje orkestraciju više alata, integraciju eksternih API-ja i robusno rukovanje greškama | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Realtime Streaming** | Streaming podataka u realnom vremenu postao je neophodan u današnjem svetu vođenom podacima, gde biznisi i aplikacije zahtevaju trenutni pristup informacijama za pravovremene odluke | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Realtime Web Search** | Kako MCP menja pretragu weba u realnom vremenu pružajući standardizovani pristup upravljanju kontekstom između AI modela, pretraživača i aplikacija | [Realtime Web Search](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Doprinosi zajednice** | Kako doprineti kodom i dokumentacijom, saradnja preko GitHub-a, unapređenja vođena zajednicom i povratne informacije | [Doprinosi zajednice](./06-CommunityContributions/README.md) |
| 07 | **Uvidi iz Rane Primene** | Implementacije iz stvarnog sveta i šta je funkcionisalo, izgradnja i implementacija rešenja zasnovanih na MCP-u, trendovi i budući planovi | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najbolje Prakse za MCP** | Podešavanje performansi i optimizacija, dizajniranje otpornog MCP sistema, strategije testiranja i otpornosti | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP Studije Slučaja** | Detaljne analize arhitektura MCP rešenja, šabloni za implementaciju i saveti za integraciju, anotirani dijagrami i vođeni projekti | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Optimizacija AI Radnih Tokova: Izgradnja MCP Servera sa AI Toolkit-om** | Sveobuhvatan praktični radionica koja kombinuje MCP sa Microsoftovim AI Toolkit-om za VS Code. Naučite kako da pravite inteligentne aplikacije koje povezuju AI modele sa stvarnim alatima kroz praktične module koji pokrivaju osnove, razvoj prilagođenog servera i strategije za produkcijsko postavljanje. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Primeri Projekata

### 🧮 MCP Kalkulator Primeri Projekata:
<details>
  <summary><strong>Istražite implementacije koda po jeziku</strong></summary>

  - [C# MCP Server Primer](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Kalkulator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Primer](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Napredni Kalkulator Projekti:
<details>
  <summary><strong>Istražite napredne primere</strong></summary>

  - [Napredni C# Primer](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Primer Kontejnerske Aplikacije](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript Napredni Primer](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Složena Implementacija](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Kontejnerski Primer](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 Preduslovi za Učenje MCP-a

Da biste maksimalno iskoristili ovaj kurikulum, trebalo bi da imate:

- Osnovno znanje C#, Java ili Python jezika  
- Razumevanje klijent-server modela i API-ja  
- (Opcionalno) Poznavanje koncepata mašinskog učenja  

## 📚 Vodič za Učenje

Sveobuhvatan [Vodič za Učenje](./study_guide.md) je dostupan da vam pomogne da efikasno koristite ovaj repozitorijum. Vodič sadrži:

- Vizuelnu mapu kurikuluma sa svim pokrivenim temama  
- Detaljnu podelu svakog dela repozitorijuma  
- Uputstva kako koristiti primere projekata  
- Preporučene putanje učenja za različite nivoe znanja  
- Dodatne resurse koji dopunjuju vaše učenje  

## 🛠️ Kako Efikasno Koristiti Ovaj Kurikulum

Svaka lekcija u ovom vodiču uključuje:

1. Jasna objašnjenja MCP koncepata  
2. Primeri koda uživo na više jezika  
3. Vežbe za pravljenje stvarnih MCP aplikacija  
4. Dodatne resurse za napredne korisnike  

## 📜 Informacije o Licenci

Ovaj sadržaj je licenciran pod **MIT Licencom**. Za uslove korišćenja pogledajte [LICENSE](../../LICENSE).

## 🤝 Uputstva za Doprinose

Ovaj projekat prihvata doprinose i sugestije. Većina doprinosa zahteva da se složite sa Contributor License Agreement (CLA) kojim potvrđujete da imate pravo i zaista dajete dozvolu za korišćenje vašeg doprinosa. Za detalje posetite <https://cla.opensource.microsoft.com>.

Kada pošaljete pull request, CLA bot će automatski proveriti da li je potrebno da dostavite CLA i odgovarajuće označiti PR (npr. status provera, komentar). Samo pratite uputstva koja daje bot. Ovo je potrebno uraditi samo jednom za sve repozitorijume koji koriste naš CLA.

Ovaj projekat je usvojio [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). Za više informacija pogledajte [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) ili kontaktirajte [opencode@microsoft.com](mailto:opencode@microsoft.com) za dodatna pitanja ili komentare.

## 🎒 Ostali Kursevi
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
- [Savladavanje GitHub Copilot-a za AI par-programiranje](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Savladavanje GitHub Copilot-a za C#/.NET programere](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Izaberi svoju Copilot avanturu](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Obaveštenje o zaštitnom znaku

Ovaj projekat može sadržati zaštitne znakove ili logoe za projekte, proizvode ili usluge. Ovlašćena upotreba Microsoftovih zaštitnih znakova ili logoa podleže i mora se pridržavati
[Microsoftovih smernica za zaštitne znakove i brend](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Korišćenje Microsoftovih zaštitnih znakova ili logoa u izmenjenim verzijama ovog projekta ne sme izazvati zabunu niti implicirati da Microsoft sponzoriše projekat.
Svaka upotreba zaštitnih znakova ili logoa trećih strana podleže pravilima tih trećih strana.

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако настојимо да превод буде прецизан, имајте у виду да аутоматизовани преводи могу садржати грешке или нетачности. Изворни документ на његовом оригиналном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења настала употребом овог превода.