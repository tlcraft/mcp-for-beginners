<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "677cecb63a0bf6c0f49e40ffc15f6189",
  "translation_date": "2025-06-02T12:54:22+00:00",
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


Pratite ove korake da biste započeli korišćenje ovih resursa:
1. **Forkujte repozitorijum**: Kliknite [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klonirajte repozitorijum**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Pridružite se Azure AI Foundry Discord-u i upoznajte stručnjake i druge developere**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Podrška za više jezika

#### Podržano preko GitHub Action (Automatski i uvek ažurno)

# 🚀 Kurikulum Model Context Protocol (MCP) za početnike

## **Naučite MCP kroz praktične primere koda u C#, Java, JavaScript, Python i TypeScript**

## 🧠 Pregled kurikuluma Model Context Protocol

**Model Context Protocol (MCP)** je savremeni okvir dizajniran za standardizaciju interakcija između AI modela i klijentskih aplikacija. Ovaj open-source kurikulum nudi strukturiran put učenja, sa praktičnim primerima koda i stvarnim slučajevima upotrebe, na popularnim programskim jezicima kao što su C#, Java, JavaScript, TypeScript i Python.

Bilo da ste AI developer, sistemski arhitekta ili softverski inženjer, ovaj vodič je vaš sveobuhvatni resurs za savladavanje osnova MCP-a i strategija implementacije.

## 🔗 Zvanični MCP resursi

- 📘 [MCP Dokumentacija](https://modelcontextprotocol.io/) – Detaljni tutorijali i korisnički vodiči  
- 📜 [MCP Specifikacija](https://spec.modelcontextprotocol.io/) – Arhitektura protokola i tehničke reference  
- 🧑‍💻 [MCP GitHub Repozitorijum](https://github.com/modelcontextprotocol) – Open-source SDK-ovi, alati i primeri koda  

## 🧭 Struktura kompletnog MCP kurikuluma

| Ch | Naslov | Opis | Link |
|--|--|--|--|
| 00 | **Uvod u MCP** | Pregled Model Context Protocol-a i njegov značaj u AI procesima, uključujući šta je Model Context Protocol, zašto je standardizacija bitna i praktične primere i prednosti | [Uvod](./00-Introduction/README.md) |
| 01 | **Objašnjeni osnovni koncepti** | Detaljno objašnjenje osnovnih koncepata MCP-a, uključujući klijent-server arhitekturu, ključne komponente protokola i obrasce poruka | [Osnovni koncepti](./01-CoreConcepts/README.md) |
| 02 | **Bezbednost u MCP-u** | Identifikacija bezbednosnih pretnji u MCP sistemima, tehnike i najbolje prakse za bezbednu implementaciju | [Bezbednost](./02-Security/README.md) |
| 03 | **Početak rada sa MCP-om** | Podešavanje okruženja i konfiguracija, kreiranje osnovnih MCP servera i klijenata, integracija MCP-a sa postojećim aplikacijama | [Početak rada](./03-GettingStarted/README.md) |
| 3.1 | **Prvi server** | Postavljanje osnovnog servera koristeći MCP protokol, razumevanje interakcije server-klijent i testiranje servera | [Prvi server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi klijent**  | Postavljanje osnovnog klijenta koristeći MCP protokol, razumevanje interakcije klijent-server i testiranje klijenta | [Prvi klijent](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klijent sa LLM-om**  | Postavljanje klijenta koristeći MCP protokol sa velikim jezičkim modelom (LLM) | [Klijent sa LLM-om](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Korišćenje servera sa Visual Studio Code** | Podešavanje Visual Studio Code za korišćenje servera preko MCP protokola | [Korišćenje servera sa Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Kreiranje servera koristeći SSE** | SSE nam pomaže da izložimo server na internetu. Ovaj deo će vam pomoći da napravite server koristeći SSE | [Kreiranje servera koristeći SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Korišćenje AI Toolkit-a** | AI toolkit je sjajan alat koji će vam pomoći da upravljate AI i MCP radnim tokovima. | [Korišćenje AI Toolkit-a](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Testiranje vašeg servera** | Testiranje je važan deo procesa razvoja. Ovaj deo će vam pomoći da koristite različite alate za testiranje. | [Testiranje vašeg servera](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Deploy vašeg servera** | Kako da pređete sa lokalnog razvoja na produkciju? Ovaj deo će vam pomoći da razvijete i postavite server. | [Deploy vašeg servera](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Praktična implementacija** | Korišćenje SDK-ova na različitim jezicima, debagovanje, testiranje i validacija, kreiranje ponovo upotrebljivih predložaka i radnih tokova | [Praktična implementacija](./04-PracticalImplementation/README.md) |
| 05 | **Napredne teme u MCP-u** | Multimodalni AI radni tokovi i proširivost, sigurni pristupi skaliranju, MCP u enterprise okruženjima | [Napredne teme](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP OAuth2 Demo** | Implementacija OAuth2 autentifikacije sa MCP serverima, uključujući validaciju pristupnih tokena, autorizaciju zasnovanu na opsegu i zaštitu sigurnih API krajnjih tačaka | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.2 | **Web pretraga sa MCP-om** | Implementacija web pretrage koristeći Model Context Protocol, uključujući obradu pretraživačkih upita, rukovanje rezultatima i integraciju sa pretraživačkim API-jima | [Web pretraga MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Doprinos zajednice** | Kako doprineti kodom i dokumentacijom, saradnja preko GitHub-a, unapređenja vođena zajednicom i povratne informacije | [Doprinos zajednice](./06-CommunityContributions/README.md) |
| 07 | **Uvidi iz ranog usvajanja** | Stvarne implementacije i šta je funkcionisalo, izgradnja i postavljanje MCP rešenja, trendovi i budući planovi | [Uvidi](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najbolje prakse za MCP** | Podešavanje performansi i optimizacija, dizajn otpornog MCP sistema, strategije testiranja i otpornosti | [Najbolje prakse](./08-BestPractices/README.md) |
| 09 | **MCP studije slučaja** | Detaljne analize arhitekture MCP rešenja, šabloni za postavljanje i saveti za integraciju, komentarisani dijagrami i pregled projekata | [Studije slučaja](./09-CaseStudy/README.md) |

## Primeri projekata

### 🧮 MCP Kalkulator primer projekata:
<details>
  <summary><strong>Istražite implementacije koda po jeziku</strong></summary>

  - [C# MCP Server primer](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Kalkulator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP primer](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Napredni kalkulator projekti:
<details>
  <summary><strong>Istražite napredne primere</strong></summary>

  - [Napredni C# primer](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container App primer](./04-PracticalImplementation/samples/java/containerapp/README.md)
- [JavaScript Advanced Sample](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Complex Implementation](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Sample](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Preduslovi za učenje MCP

Da biste izvukli maksimum iz ovog kurikuluma, trebalo bi da imate:

- Osnovno znanje C#, Java ili Python
- Razumevanje klijent-server modela i API-ja
- (Opcionalno) Poznavanje koncepata mašinskog učenja

## 🛠️ Kako efikasno koristiti ovaj kurikulum

Svaka lekcija u ovom vodiču uključuje:

1. Jasna objašnjenja MCP koncepata  
2. Primeri koda uživo na više jezika  
3. Vežbe za pravljenje stvarnih MCP aplikacija  
4. Dodatne resurse za napredne učenike  

## 📜 Informacije o licenci

Ovaj sadržaj je licenciran pod **MIT License**. Za uslove korišćenja pogledajte [LICENSE](../../LICENSE).

## 🤝 Uputstva za doprinos

Ovaj projekat prihvata doprinose i sugestije. Većina doprinosa zahteva da se složite sa
Contributor License Agreement (CLA) kojim potvrđujete da imate pravo i zaista dajete
dozvolu za korišćenje vašeg doprinosa. Za detalje posetite <https://cla.opensource.microsoft.com>.

Kada pošaljete pull request, CLA bot će automatski utvrditi da li je potrebno da dostavite
CLA i obeležiće PR na odgovarajući način (npr. status provera, komentar). Samo sledite uputstva
koja daje bot. Ovo je potrebno uraditi samo jednom za sve repozitorijume koji koriste naš CLA.

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


## ™️ Obaveštenje o zaštitnim znakovima

Ovaj projekat može sadržati zaštitne znakove ili logoe projekata, proizvoda ili usluga. Ovlašćena upotreba Microsoft
zaštitnih znakova ili logotipa podložna je i mora se pridržavati
[Microsoft-ovih smernica za zaštitne znakove i brend](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Korišćenje Microsoft zaštitnih znakova ili logotipa u modifikovanim verzijama ovog projekta ne sme izazvati zabunu niti implicirati sponzorstvo Microsoft-a.
Svaka upotreba zaštitnih znakova ili logotipa trećih strana podleže politikama tih trećih strana.

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Изворни документ на оригиналном језику треба сматрати ауторитетом. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешне тумачења настала коришћењем овог превода.