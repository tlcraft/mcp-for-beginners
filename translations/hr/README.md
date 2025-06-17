<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T16:16:00+00:00",
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
3. [**Pridružite se Azure AI Foundry Discord zajednici i upoznajte stručnjake i kolege developere**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Višejezična podrška

#### Podržano putem GitHub akcije (Automatski i uvijek ažurno)

# 🚀 Kurikulum Model Context Protocol (MCP) za početnike

## **Naučite MCP kroz praktične primjere koda u C#, Java, JavaScript, Python i TypeScript**

## 🧠 Pregled kurikuluma Model Context Protocol

**Model Context Protocol (MCP)** je napredni okvir osmišljen za standardizaciju interakcija između AI modela i klijentskih aplikacija. Ovaj open-source kurikulum nudi strukturirani put učenja, s praktičnim primjerima koda i stvarnim slučajevima upotrebe, na popularnim programskim jezicima poput C#, Java, JavaScript, TypeScript i Python.

Bilo da ste AI developer, sistemski arhitekt ili softverski inženjer, ovaj vodič je vaš sveobuhvatni resurs za savladavanje osnovnih pojmova i strategija implementacije MCP-a.

## 🔗 Službeni MCP resursi

- 📘 [MCP Dokumentacija](https://modelcontextprotocol.io/) – Detaljni tutorijali i korisnički vodiči  
- 📜 [MCP Specifikacija](https://spec.modelcontextprotocol.io/) – Arhitektura protokola i tehničke reference  
- 🧑‍💻 [MCP GitHub Repozitorij](https://github.com/modelcontextprotocol) – Open-source SDK-ovi, alati i primjeri koda  

## 🧭 Struktura kompletnog MCP kurikuluma

| Ch | Naslov | Opis | Link |
|--|--|--|--|
| 00 | **Uvod u MCP** | Pregled Model Context Protocol-a i njegov značaj u AI procesima, uključujući što je Model Context Protocol, zašto je standardizacija važna te praktične primjere i prednosti | [Uvod](./00-Introduction/README.md) |
| 01 | **Objašnjenje osnovnih pojmova** | Dubinska analiza osnovnih pojmova MCP-a, uključujući klijent-server arhitekturu, ključne komponente protokola i obrasce poruka | [Osnovni pojmovi](./01-CoreConcepts/README.md) |
| 02 | **Sigurnost u MCP-u** | Prepoznavanje sigurnosnih prijetnji u MCP sustavima, tehnike i najbolje prakse za sigurnu implementaciju | [Sigurnost](./02-Security/README.md) |
| 03 | **Početak rada s MCP-om** | Postavljanje i konfiguracija okruženja, kreiranje osnovnih MCP servera i klijenata, integracija MCP-a s postojećim aplikacijama | [Početak rada](./03-GettingStarted/README.md) |
| 3.1 | **Prvi server** | Postavljanje osnovnog servera koristeći MCP protokol, razumijevanje interakcije server-klijent i testiranje servera | [Prvi server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi klijent**  | Postavljanje osnovnog klijenta koristeći MCP protokol, razumijevanje interakcije klijent-server i testiranje klijenta | [Prvi klijent](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klijent s LLM-om**  | Postavljanje klijenta koristeći MCP protokol s velikim jezičnim modelom (LLM) | [Klijent s LLM-om](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Korištenje servera u Visual Studio Code-u** | Postavljanje Visual Studio Code-a za korištenje servera putem MCP protokola | [Korištenje servera u Visual Studio Code-u](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Kreiranje servera koristeći SSE** | SSE nam pomaže izložiti server na internetu. Ovaj dio će vam pomoći da kreirate server koristeći SSE | [Kreiranje servera koristeći SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP Streaming** | Naučite kako implementirati HTTP streaming za prijenos podataka u stvarnom vremenu između klijenata i MCP servera | [HTTP Streaming](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **Korištenje AI Toolkit-a** | AI toolkit je odličan alat koji će vam pomoći u upravljanju AI i MCP radnim tokovima | [Korištenje AI Toolkit-a](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Testiranje vašeg servera** | Testiranje je važan dio procesa razvoja. Ovaj dio će vam pomoći da testirate koristeći nekoliko različitih alata | [Testiranje vašeg servera](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Deploy vašeg servera** | Kako prijeći iz lokalnog razvoja u produkciju? Ovaj dio će vam pomoći u razvoju i postavljanju servera | [Deploy vašeg servera](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Praktična implementacija** | Korištenje SDK-ova na različitim jezicima, debugiranje, testiranje i validacija, izrada ponovljivih predložaka i radnih tokova | [Praktična implementacija](./04-PracticalImplementation/README.md) |
| 05 | **Napredne teme u MCP-u** | Višemodalni AI radni tokovi i proširivost, sigurne strategije skaliranja, MCP u poslovnim ekosustavima | [Napredne teme](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP integracija s Azure-om** | Prikazuje integraciju s Azure platformom | [MCP Azure integracija](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Višemodalnost** | Pokazuje kako raditi s različitim modalitetima poput slika i drugih | [Višemodalnost](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimalna Spring Boot aplikacija koja prikazuje OAuth2 s MCP-om, kao Authorization i Resource Server. Demonstrira sigurno izdavanje tokena, zaštićene krajnje točke, deployment na Azure Container Apps i integraciju s API Managementom | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Saznajte više o root context-u i kako ga implementirati | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Naučite različite vrste usmjeravanja | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Naučite kako raditi s samplingom | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skaliranje** | Naučite o skaliranju MCP servera, uključujući horizontalne i vertikalne strategije skaliranja, optimizaciju resursa i podešavanje performansi | [Skaliranje](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Sigurnost** | Osigurajte svoj MCP server, uključujući autentifikaciju, autorizaciju i strategije zaštite podataka | [Sigurnost](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP server i klijent integrirani sa SerpAPI za pretraživanje weba, vijesti, proizvoda i Q&A u stvarnom vremenu. Demonstrira orkestraciju više alata, integraciju vanjskih API-ja i robusno upravljanje greškama | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Realtime Streaming** | Streaming podataka u stvarnom vremenu postao je ključan u današnjem svijetu vođenom podacima, gdje tvrtke i aplikacije zahtijevaju trenutni pristup informacijama za pravovremene odluke | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Realtime Web Search** | Kako MCP transformira pretraživanje weba u stvarnom vremenu pružajući standardizirani pristup upravljanju kontekstom preko AI modela, tražilica i aplikacija | [Realtime Web Search](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Doprinosi zajednice** | Kako doprinositi kodom i dokumentacijom, suradnja putem GitHub-a, poboljšanja vođena zajednicom i povratne informacije | [Doprinosi zajednice](./06-CommunityContributions/README.md) |
| 07 | **Uvidi iz Rane Primjene** | Implementacije u stvarnom svijetu i što je funkcioniralo, izgradnja i implementacija rješenja baziranih na MCP-u, trendovi i budući planovi | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najbolje Prakse za MCP** | Podešavanje performansi i optimizacija, dizajn otpornog MCP sustava, strategije testiranja i otpornosti | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP Studije Slučaja** | Detaljni pregledi arhitektura MCP rješenja, planovi implementacije i savjeti za integraciju, komentirani dijagrami i vođeni projekti | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Optimizacija AI Radnih Tokova: Izgradnja MCP Servera s AI Toolkitom** | Sveobuhvatan praktični rad koji spaja MCP s Microsoftovim AI Toolkitom za VS Code. Naučite kako izgraditi inteligentne aplikacije koje povezuju AI modele sa stvarnim alatima kroz praktične module koji pokrivaju osnove, razvoj prilagođenog servera i strategije produkcijske implementacije. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Primjer Projekata

### 🧮 MCP Kalkulator Primjer Projekata:
<details>
  <summary><strong>Istražite Implementacije Koda po Jeziku</strong></summary>

  - [C# MCP Server Primjer](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Kalkulator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Primjer](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Napredni Kalkulator Projekti:
<details>
  <summary><strong>Istražite Napredne Primjere</strong></summary>

  - [Napredni C# Primjer](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Primjer Container Aplikacije](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript Napredni Primjer](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Složena Implementacija](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Primjer](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 Preduvjeti za Učenje MCP-a

Da biste maksimalno iskoristili ovaj kurikulum, trebate imati:

- Osnovno znanje C#, Java ili Python jezika
- Razumijevanje klijent-server modela i API-ja
- (Opcionalno) Poznavanje osnovnih pojmova strojnog učenja

## 📚 Vodič za Učenje

Dostupan je sveobuhvatan [Vodič za Učenje](./study_guide.md) koji će vam pomoći da se učinkovito snađete u ovom repozitoriju. Vodič uključuje:

- Vizualnu mapu kurikuluma sa svim obuhvaćenim temama
- Detaljan pregled svakog dijela repozitorija
- Upute kako koristiti primjere projekata
- Preporučene putanje učenja za različite razine znanja
- Dodatne resurse za podršku vašem učenju

## 🛠️ Kako Učinkovito Koristiti Ovaj Kurikulum

Svaka lekcija u ovom vodiču uključuje:

1. Jasna objašnjenja MCP koncepata  
2. Primjere koda uživo na više jezika  
3. Vježbe za izgradnju stvarnih MCP aplikacija  
4. Dodatne resurse za napredne korisnike  

## 📜 Informacije o Licenciji

Ovaj sadržaj je licenciran pod **MIT licencom**. Za uvjete korištenja pogledajte [LICENSE](../../LICENSE).

## 🤝 Smjernice za Doprinos

Ovaj projekt prihvaća doprinose i prijedloge. Većina doprinosa zahtijeva da se složite s Contributor License Agreement (CLA) koji potvrđuje da imate pravo i doista nam dajete prava za korištenje vašeg doprinosa. Za detalje posjetite <https://cla.opensource.microsoft.com>.

Kada pošaljete pull request, CLA bot će automatski provjeriti trebate li dostaviti CLA i označiti PR na odgovarajući način (npr. status provjere, komentar). Jednostavno slijedite upute bota. Ovo je potrebno napraviti samo jednom za sve repozitorije koji koriste naš CLA.

Ovaj projekt je usvojio [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). Za dodatne informacije pogledajte [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) ili kontaktirajte [opencode@microsoft.com](mailto:opencode@microsoft.com) za dodatna pitanja ili komentare.

## 🎒 Ostali Tečajevi
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
- [Savladavanje GitHub Copilot za AI u paru programiranje](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Savladavanje GitHub Copilot za C#/.NET developere](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Odaberi svoju Copilot avanturu](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Obavijest o zaštitnom znaku

Ovaj projekt može sadržavati zaštitne znakove ili logotipe za projekte, proizvode ili usluge. Ovlaštena upotreba Microsoftovih
zaštitnih znakova ili logotipa podliježe i mora se pridržavati
[Microsoftovih smjernica za zaštitne znakove i brendove](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Upotreba Microsoftovih zaštitnih znakova ili logotipa u izmijenjenim verzijama ovog projekta ne smije dovesti do zabune niti sugerirati sponzorstvo Microsofta.
Svaka upotreba zaštitnih znakova ili logotipa trećih strana podliježe pravilima tih trećih strana.

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Nismo odgovorni za bilo kakve nesporazume ili pogrešne interpretacije koje proizlaze iz korištenja ovog prijevoda.