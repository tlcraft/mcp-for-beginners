<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3ede7f051090bd4acfe5b068bab9f6b0",
  "translation_date": "2025-06-10T04:42:01+00:00",
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


Пратите ове кораке да бисте почели да користите ове ресурсе:
1. **Направите форк репозиторијума**: Кликните [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Клонирајте репозиторијум**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Придружите се Azure AI Foundry Discord-у и упознајте стручњаке и друге програмере**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Подршка за више језика

#### Подржано преко GitHub Action-а (аутоматски и увек ажурирано)

# 🚀 Kurikulum Model Context Protocol (MCP) za početnike

## **Naučite MCP kroz praktične primere koda u C#, Java, JavaScript, Python i TypeScript**

## 🧠 Pregled kurikuluma Model Context Protocol

**Model Context Protocol (MCP)** je savremeni okvir dizajniran da standardizuje interakcije između AI modela i klijentskih aplikacija. Ovaj open-source kurikulum nudi strukturisan put učenja, sa praktičnim primerima koda i stvarnim slučajevima upotrebe, na popularnim programskim jezicima kao što su C#, Java, JavaScript, TypeScript i Python.

Bilo da ste AI programer, sistemski arhitekta ili softverski inženjer, ovaj vodič je vaš sveobuhvatni resurs za savladavanje osnovnih principa MCP-a i strategija implementacije.

## 🔗 Zvanični MCP resursi

- 📘 [MCP Dokumentacija](https://modelcontextprotocol.io/) – Detaljni tutorijali i korisnički vodiči  
- 📜 [MCP Specifikacija](https://spec.modelcontextprotocol.io/) – Arhitektura protokola i tehničke reference  
- 🧑‍💻 [MCP GitHub Repozitorijum](https://github.com/modelcontextprotocol) – Open-source SDK-ovi, alati i primeri koda  

## 🧭 Struktura kompletnog MCP kurikuluma

| Ch | Naslov | Opis | Link |
|--|--|--|--|
| 00 | **Uvod u MCP** | Pregled Model Context Protocol-a i njegov značaj u AI procesima, uključujući šta je Model Context Protocol, zašto je standardizacija važna i praktične primere upotrebe i koristi | [Uvod](./00-Introduction/README.md) |
| 01 | **Objašnjenje osnovnih pojmova** | Detaljno proučavanje osnovnih pojmova MCP-a, uključujući klijent-server arhitekturu, ključne komponente protokola i obrasce poruka | [Osnovni pojmovi](./01-CoreConcepts/README.md) |
| 02 | **Bezbednost u MCP-u** | Identifikovanje bezbednosnih pretnji u sistemima zasnovanim na MCP-u, tehnike i najbolje prakse za bezbednu implementaciju | [Bezbednost](/02-Security/README.md) |
| 03 | **Početak rada sa MCP-om** | Podešavanje okruženja i konfiguracija, kreiranje osnovnih MCP servera i klijenata, integracija MCP-a sa postojećim aplikacijama | [Početak rada](./03-GettingStarted/README.md) |
| 3.1 | **Prvi server** | Podešavanje osnovnog servera koristeći MCP protokol, razumevanje interakcije server-klijent i testiranje servera | [Prvi server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi klijent**  | Podešavanje osnovnog klijenta koristeći MCP protokol, razumevanje interakcije klijent-server i testiranje klijenta | [Prvi klijent](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klijent sa LLM-om**  | Podešavanje klijenta koristeći MCP protokol sa Large Language Model-om (LLM) | [Klijent sa LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Konzumiranje servera u Visual Studio Code-u** | Podešavanje Visual Studio Code-a za korišćenje servera preko MCP protokola | [Konzumiranje servera u Visual Studio Code-u](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Kreiranje servera koristeći SSE** | SSE nam pomaže da izložimo server na internetu. Ovaj deo će vam pomoći da napravite server koristeći SSE | [Kreiranje servera koristeći SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Korišćenje AI Toolkit-a** | AI toolkit je odličan alat koji će vam pomoći da upravljate svojim AI i MCP radnim tokovima. | [Korišćenje AI Toolkit-a](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Testiranje vašeg servera** | Testiranje je važan deo procesa razvoja. Ovaj deo će vam pomoći da koristite različite alate za testiranje. | [Testiranje vašeg servera](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Deploy vašeg servera** | Kako da pređete sa lokalnog razvoja na produkciju? Ovaj deo će vam pomoći da razvijete i postavite server. | [Deploy vašeg servera](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Praktična implementacija** | Korišćenje SDK-ova na različitim jezicima, debagovanje, testiranje i validacija, kreiranje ponovo upotrebljivih predložaka i radnih tokova | [Praktična implementacija](./04-PracticalImplementation/README.md) |
| 05 | **Napredne teme u MCP-u** | Multimodalni AI radni tokovi i proširivost, bezbedne strategije skaliranja, MCP u enterprise ekosistemima | [Napredne teme](./05-AdvancedTopics/README.md) |
| 5.1 | **Integracija MCP-a sa Azure-om** | Prikazuje integraciju sa Azure-om | [Integracija MCP-a sa Azure-om](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multimodalnost** | Prikazuje rad sa različitim modalitetima kao što su slike i drugi | [Multimodalnost](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 demo** | Minimalna Spring Boot aplikacija koja prikazuje OAuth2 sa MCP-om, kao Authorization i Resource Server. Demonstrira bezbedno izdavanje tokena, zaštićene endpoint-e, deploy na Azure Container Apps i integraciju sa API Management-om. | [MCP OAuth2 demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Saznajte više o root context-u i kako ih implementirati | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Naučite različite vrste rutiranja | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Naučite kako da radite sa sampling-om | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skaliranje** | Naučite o skaliranju MCP servera, uključujući horizontalne i vertikalne strategije skaliranja, optimizaciju resursa i podešavanje performansi | [Skaliranje](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Bezbednost** | Zaštitite svoj MCP server, uključujući autentifikaciju, autorizaciju i strategije zaštite podataka | [Bezbednost](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP server i klijent integrisani sa SerpAPI za pretragu veba, vesti, proizvoda i Q&A u realnom vremenu. Prikazuje orkestraciju više alata, integraciju eksternih API-ja i robusno upravljanje greškama | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Doprinosi zajednice** | Kako doprineti kodom i dokumentacijom, saradnja preko GitHub-a, poboljšanja vođena zajednicom i povratne informacije | [Doprinosi zajednice](./06-CommunityContributions/README.md) |
| 07 | **Uvidi iz ranog usvajanja** | Stvarne implementacije i šta je funkcionisalo, izgradnja i deploy MCP zasnovanih rešenja, trendovi i buduća mapa puta | [Uvidi](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najbolje prakse za MCP** | Podešavanje performansi i optimizacija, dizajniranje otpornog MCP sistema, strategije testiranja i otpornosti | [Najbolje prakse](./08-BestPractices/README.md) |
| 09 | **MCP studije slučaja** | Detaljna analiza MCP arhitektura rešenja, planovi za deploy i saveti za integraciju, anotirani dijagrami i vođeni projekti | [Studije slučaja](./09-CaseStudy/README.md) |
| 10 | **Optimizacija AI tokova rada: Izgradnja MCP servera sa AI Toolkit-om** | Sveobuhvatan praktični radionica koja kombinuje MCP sa Microsoftovim AI Toolkit-om za VS Code. Naučite kako da pravite inteligentne aplikacije koje povezuju AI modele sa stvarnim alatima kroz praktične module koji pokrivaju osnove, razvoj prilagođenog servera i strategije za produkcijsko postavljanje. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Primeri Projekata

### 🧮 MCP Calculator Primeri Projekata:
<details>
  <summary><strong>Istražite implementacije koda po jeziku</strong></summary>

  - [C# MCP Server Primer](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Calculator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Primer](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Napredni Calculator Projekti:
<details>
  <summary><strong>Istražite napredne primere</strong></summary>

  - [Napredni C# Primer](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container App Primer](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript Napredni Primer](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Složena Implementacija](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Primer](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Preduslovi za učenje MCP

Da biste maksimalno iskoristili ovaj kurikulum, potrebno je da imate:

- Osnovno znanje C#, Java ili Python jezika  
- Razumevanje klijent-server modela i API-ja  
- (Opcionalno) Poznavanje koncepata mašinskog učenja  

## 🛠️ Kako efikasno koristiti ovaj kurikulum

Svaka lekcija u ovom vodiču sadrži:

1. Jasna objašnjenja MCP koncepata  
2. Primeri koda uživo na više jezika  
3. Vežbe za izradu stvarnih MCP aplikacija  
4. Dodatne resurse za napredne korisnike  

## 📜 Informacije o licenci

Ovaj sadržaj je licenciran pod **MIT licencom**. Za uslove korišćenja pogledajte [LICENSE](../../LICENSE).

## 🤝 Uputstva za doprinos

Ovaj projekat pozdravlja doprinose i sugestije. Većina doprinosa zahteva da prihvatite
Contributor License Agreement (CLA) kojim izjavljujete da imate pravo i zaista dajete
prava za korišćenje vašeg doprinosa. Za detalje posetite <https://cla.opensource.microsoft.com>.

Kada pošaljete pull request, CLA bot će automatski utvrditi da li treba da dostavite
CLA i obeležiti PR na odgovarajući način (npr. status check, komentar). Jednostavno pratite uputstva
koja vam bot daje. Ovo je potrebno uraditi samo jednom za sve repozitorijume koji koriste naš CLA.

Ovaj projekat je usvojio [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
Za više informacija pogledajte [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) ili
kontaktirajte [opencode@microsoft.com](mailto:opencode@microsoft.com) za dodatna pitanja ili komentare.

## 🎒 Ostali kursevi
Naš tim pravi i druge kurseve! Pogledajte:

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
- [Choose Your Own Copilot Adventure](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Obaveštenje o žigu

Ovaj projekat može sadržati žigove ili logoe za projekte, proizvode ili usluge. Ovlašćena upotreba Microsoft
žigova ili logotipa podleže i mora se pridržavati
[Microsoft-ovih smernica za žigove i brend](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Korišćenje Microsoft žigova ili logotipa u modifikovanim verzijama ovog projekta ne sme izazvati zabunu niti sugerisati da Microsoft sponzoriše projekat.
Svaka upotreba žigova ili logotipa trećih strana podleže pravilima tih trećih lica.

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korišćenjem AI prevodilačke usluge [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo tačnosti, imajte na umu da automatski prevodi mogu sadržati greške ili netačnosti. Originalni dokument na izvornom jeziku treba smatrati zvaničnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prevod. Ne snosimo odgovornost za bilo kakva nesporazumevanja ili pogrešna tumačenja nastala korišćenjem ovog prevoda.