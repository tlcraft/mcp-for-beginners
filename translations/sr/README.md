<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4458d89100952180348d8775b149295e",
  "translation_date": "2025-06-02T19:35:32+00:00",
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
1. **Форк репозиторијума**: Кликните [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Клонирајте репозиторијум**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Придружите се Azure AI Foundry Discord-у и упознајте стручњаке и друге програмере**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Подршка за више језика

#### Подржано преко GitHub Action-а (аутоматски и увек ажурирано)

# 🚀 Kurikulum Model Context Protocol (MCP) za Početnike

## **Naučite MCP kroz praktične primere koda u C#, Java, JavaScript, Python i TypeScript**

## 🧠 Pregled Kurikuluma Model Context Protocol

**Model Context Protocol (MCP)** je savremeni okvir dizajniran da standardizuje interakcije između AI modela i klijentskih aplikacija. Ovaj otvoreni kurikulum nudi strukturirani put učenja, sa praktičnim primerima koda i stvarnim upotrebama, na popularnim programskim jezicima kao što su C#, Java, JavaScript, TypeScript i Python.

Bilo da ste AI developer, sistemski arhitekta ili softverski inženjer, ovaj vodič je vaš sveobuhvatni resurs za savladavanje osnova MCP-a i strategija implementacije.

## 🔗 Zvanični MCP Resursi

- 📘 [MCP Dokumentacija](https://modelcontextprotocol.io/) – Detaljni tutorijali i korisnički vodiči  
- 📜 [MCP Specifikacija](https://spec.modelcontextprotocol.io/) – Arhitektura protokola i tehničke reference  
- 🧑‍💻 [MCP GitHub Repozitorijum](https://github.com/modelcontextprotocol) – Otvoreni SDK-ovi, alati i primeri koda  

## 🧭 Kompletna Struktura Kurikuluma MCP

| Ch | Naslov | Opis | Link |
|--|--|--|--|
| 00 | **Uvod u MCP** | Pregled Model Context Protocol-a i njegov značaj u AI procesima, uključujući šta je Model Context Protocol, zašto je standardizacija bitna i praktične primere upotrebe i koristi | [Uvod](./00-Introduction/README.md) |
| 01 | **Objašnjeni Osnovni Pojmovi** | Detaljna analiza osnovnih pojmova MCP-a, uključujući klijent-server arhitekturu, ključne komponente protokola i obrasce poruka | [Osnovni Pojmovi](./01-CoreConcepts/README.md) |
| 02 | **Bezbednost u MCP-u** | Prepoznavanje bezbednosnih pretnji u sistemima zasnovanim na MCP-u, tehnike i najbolje prakse za zaštitu implementacija | [Bezbednost](/02-Security/README.md) |
| 03 | **Početak sa MCP-om** | Postavljanje i konfiguracija okruženja, kreiranje osnovnih MCP servera i klijenata, integracija MCP-a sa postojećim aplikacijama | [Početak](./03-GettingStarted/README.md) |
| 3.1 | **Prvi server** | Postavljanje osnovnog servera koristeći MCP protokol, razumevanje interakcije server-klijent i testiranje servera | [Prvi Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi klijent**  | Postavljanje osnovnog klijenta koristeći MCP protokol, razumevanje interakcije klijent-server i testiranje klijenta | [Prvi Klijent](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klijent sa LLM-om**  | Postavljanje klijenta koristeći MCP protokol sa Velikim Jezičkim Modelom (LLM) | [Klijent sa LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Korišćenje servera u Visual Studio Code** | Podešavanje Visual Studio Code za korišćenje servera preko MCP protokola | [Korišćenje servera u Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Kreiranje servera koristeći SSE** | SSE nam pomaže da izložimo server na internetu. Ovaj deo će vam pomoći da kreirate server koristeći SSE | [Kreiranje servera koristeći SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Korišćenje AI Toolkit-a** | AI toolkit je sjajan alat koji će vam pomoći da upravljate svojim AI i MCP radnim tokovima. | [Korišćenje AI Toolkit-a](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Testiranje vašeg servera** | Testiranje je važan deo procesa razvoja. Ovaj deo će vam pomoći da testirate koristeći nekoliko različitih alata. | [Testiranje vašeg servera](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Deploy vašeg servera** | Kako da pređete sa lokalnog razvoja na produkciju? Ovaj deo će vam pomoći da razvijete i postavite server. | [Deploy vašeg servera](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Praktična Implementacija** | Korišćenje SDK-ova na različitim jezicima, debagovanje, testiranje i validacija, kreiranje ponovo upotrebljivih šablona i radnih tokova | [Praktična Implementacija](./04-PracticalImplementation/README.md) |
| 05 | **Napredne Tematike u MCP-u** | Multi-modalni AI radni tokovi i proširivost, bezbedne strategije skaliranja, MCP u enterprise ekosistemima | [Napredne Tematike](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP Integracija sa Azure** | Prikaz integracije sa Azure | [MCP Azure integracija](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multi modalnost** | Prikaz rada sa različitim modalitetima kao što su slike i drugi | [Multi modalnost](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimalna Spring Boot aplikacija koja pokazuje OAuth2 sa MCP-om, i kao Authorization i Resource Server. Demonstrira bezbedno izdavanje tokena, zaštićene endpoint-e, deploy na Azure Container Apps i integraciju sa API Management-om. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Saznajte više o root context-u i kako ih implementirati | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Naučite različite tipove rutiranja | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Naučite kako da radite sa sampling-om | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Scaling** | Naučite o skaliranju MCP servera, uključujući horizontalne i vertikalne strategije skaliranja, optimizaciju resursa i podešavanje performansi | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Bezbednost** | Osigurajte vaš MCP Server, uključujući autentifikaciju, autorizaciju i strategije zaštite podataka | [Bezbednost](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP server i klijent integrisani sa SerpAPI za pretragu veba, vesti, proizvoda i Q&A u realnom vremenu. Prikazuje orkestraciju više alata, integraciju eksternih API-ja i robusno rukovanje greškama | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Doprinosi Zajednice** | Kako doprineti kodom i dokumentacijom, saradnja preko GitHub-a, unapređenja i povratne informacije iz zajednice | [Doprinosi Zajednice](./06-CommunityContributions/README.md) |
| 07 | **Uvidi iz Rane Primene** | Stvarne implementacije i šta je funkcionisalo, izgradnja i postavljanje MCP rešenja, trendovi i buduća mapa puta | [Uvidi](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najbolje Prakse za MCP** | Podešavanje i optimizacija performansi, dizajniranje otpornog MCP sistema, strategije testiranja i otpornosti | [Najbolje Prakse](./08-BestPractices/README.md) |
| 09 | **MCP Studije Slučaja** | Dubinska analiza MCP arhitektura rešenja, šabloni postavljanja i saveti za integraciju, anotirani dijagrami i prikazi projekata | [Studije Slučaja](./09-CaseStudy/README.md) |

## Primeri Projekata

### 🧮 MCP Kalkulator Primeri Projekata:
<details>
  <summary><strong>Istražite Implementacije Koda po Jeziku</strong></summary>
- [C# MCP Server Primerak](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Kalkulator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Primerak](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Napredni Projekti Kalkulatora:
<details>
  <summary><strong>Istražite Napredne Primere</strong></summary>

  - [Napredni C# Primerak](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Primerak Container Aplikacije](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript Napredni Primerak](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Kompleksna Implementacija](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Primerak](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Preduslovi za Učenje MCP

Da biste maksimalno iskoristili ovaj kurikulum, trebalo bi da imate:

- Osnovno znanje C#, Java ili Python
- Razumevanje klijent-server modela i API-ja
- (Opcionalno) Poznavanje koncepata mašinskog učenja

## 🛠️ Kako Efikasno Koristiti Ovaj Kurikulum

Svaka lekcija u ovom vodiču sadrži:

1. Jasna objašnjenja MCP koncepata  
2. Primere koda uživo na više jezika  
3. Vežbe za pravljenje stvarnih MCP aplikacija  
4. Dodatne resurse za napredne učenike  

## 📜 Informacije o Licenci

Ovaj sadržaj je licenciran pod **MIT Licencom**. Za uslove korišćenja pogledajte [LICENSE](../../LICENSE).

## 🤝 Uputstva za Doprinose

Ovaj projekat pozdravlja doprinose i predloge. Većina doprinosa zahteva da pristanete na
Contributor License Agreement (CLA) kojim izjavljujete da imate pravo i da nam zapravo dajete
prava da koristimo vaš doprinos. Za detalje posetite <https://cla.opensource.microsoft.com>.

Kada pošaljete pull request, CLA bot će automatski odrediti da li je potrebno da dostavite
CLA i odgovarajuće označiti PR (npr. status provera, komentar). Jednostavno pratite uputstva
koja daje bot. Ovo je potrebno uraditi samo jednom za sve repozitorijume koji koriste naš CLA.

Ovaj projekat je usvojio [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
Za više informacija pogledajte [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) ili
kontaktirajte [opencode@microsoft.com](mailto:opencode@microsoft.com) za dodatna pitanja ili komentare.

## 🎒 Ostali Kursevi
Naš tim pravi i druge kurseve! Pogledajte:

- [AI Agenti za Početnike](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Generativna AI za Početnike koristeći .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [Generativna AI za Početnike koristeći JavaScript](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [Generativna AI za Početnike](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [ML za Početnike](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [Data Science za Početnike](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [AI za Početnike](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [Cybersecurity za Početnike](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [Web Dev za Početnike](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [IoT za Početnike](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [XR Razvoj za Početnike](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Savladavanje GitHub Copilot za AI Parno Programiranje](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Savladavanje GitHub Copilot za C#/.NET Developere](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Izaberi Svoju Copilot Avanturu](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Obaveštenje o Žigu

Ovaj projekat može sadržavati žigove ili logoe za projekte, proizvode ili usluge. Ovlašćena upotreba Microsoft
žigova ili logotipa podleže i mora pratiti
[Microsoftove smernice za žigove i brend](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Korišćenje Microsoft žigova ili logotipa u modifikovanim verzijama ovog projekta ne sme izazvati zabunu niti
implicirati Microsoftovu sponzorstvo.
Svaka upotreba žigova ili logotipa trećih strana podleže politikama tih trećih strana.

**Ограничење одговорности**:  
Овај документ је преведен коришћењем AI преводилачке услуге [Co-op Translator](https://github.com/Azure/co-op-translator). Иако настојимо да превод буде прецизан, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешне тумачења која могу настати коришћењем овог превода.