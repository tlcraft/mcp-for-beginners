<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T16:10:57+00:00",
  "source_file": "README.md",
  "language_code": "ro"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.ro.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Urmați acești pași pentru a începe să folosiți aceste resurse:
1. **Faceți fork la Repository**: Click pe [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Clonați Repository-ul**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Alăturați-vă serverului Azure AI Foundry Discord și întâlniți experți și alți dezvoltatori**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Suport Multi-Limbaj

#### Suportat prin GitHub Action (automatizat și întotdeauna actualizat)

# 🚀 Curriculum Model Context Protocol (MCP) pentru Începători

## **Învață MCP cu exemple practice de cod în C#, Java, JavaScript, Python și TypeScript**

## 🧠 Prezentare generală a curriculumului Model Context Protocol

**Model Context Protocol (MCP)** este un cadru de ultimă generație creat pentru a standardiza interacțiunile dintre modelele AI și aplicațiile client. Acest curriculum open-source oferă un traseu de învățare structurat, completat cu exemple practice de cod și cazuri de utilizare din lumea reală, în limbaje de programare populare precum C#, Java, JavaScript, TypeScript și Python.

Indiferent dacă ești dezvoltator AI, arhitect de sisteme sau inginer software, acest ghid este resursa ta completă pentru a stăpâni fundamentele MCP și strategiile de implementare.

## 🔗 Resurse oficiale MCP

- 📘 [Documentația MCP](https://modelcontextprotocol.io/) – Tutoriale detaliate și ghiduri pentru utilizatori  
- 📜 [Specificația MCP](https://spec.modelcontextprotocol.io/) – Arhitectura protocolului și referințe tehnice  
- 🧑‍💻 [Repository-ul MCP pe GitHub](https://github.com/modelcontextprotocol) – SDK-uri open-source, unelte și exemple de cod  

## 🧭 Structura completă a curriculumului MCP

| Ch | Titlu | Descriere | Link |
|--|--|--|--|
| 00 | **Introducere în MCP** | Prezentare generală a Model Context Protocol și importanța sa în fluxurile AI, inclusiv ce este Model Context Protocol, de ce contează standardizarea și cazuri practice și beneficii | [Introducere](./00-Introduction/README.md) |
| 01 | **Concepte de bază explicate** | Explorare detaliată a conceptelor de bază ale MCP, inclusiv arhitectura client-server, componentele cheie ale protocolului și tiparele de mesagerie | [Concepte de bază](./01-CoreConcepts/README.md) |
| 02 | **Securitate în MCP** | Identificarea amenințărilor de securitate în sistemele bazate pe MCP, tehnici și bune practici pentru securizarea implementărilor | [Securitate](./02-Security/README.md) |
| 03 | **Începutul cu MCP** | Configurarea mediului și setările inițiale, crearea de servere și clienți MCP de bază, integrarea MCP cu aplicații existente | [Începutul](./03-GettingStarted/README.md) |
| 3.1 | **Primul server** | Configurarea unui server simplu folosind protocolul MCP, înțelegerea interacțiunii server-client și testarea serverului | [Primul server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Primul client** | Configurarea unui client simplu folosind protocolul MCP, înțelegerea interacțiunii client-server și testarea clientului | [Primul client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Client cu LLM** | Configurarea unui client folosind protocolul MCP cu un Model de Limbaj Mare (LLM) | [Client cu LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Consumarea unui server cu Visual Studio Code** | Configurarea Visual Studio Code pentru a consuma servere folosind protocolul MCP | [Consumarea unui server cu Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Crearea unui server folosind SSE** | SSE ne ajută să expunem un server pe internet. Această secțiune te va ghida să creezi un server folosind SSE | [Crearea unui server folosind SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Streaming HTTP** | Învață cum să implementezi streaming HTTP pentru transfer de date în timp real între clienți și servere MCP | [Streaming HTTP](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **Folosește AI Toolkit** | AI Toolkit este un instrument excelent care te va ajuta să gestionezi fluxul tău de lucru AI și MCP | [Folosește AI Toolkit](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Testarea serverului tău** | Testarea este o parte importantă a procesului de dezvoltare. Această secțiune te va ajuta să testezi folosind mai multe unelte diferite | [Testarea serverului tău](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Deploiază serverul tău** | Cum treci de la dezvoltarea locală la producție? Această secțiune te va ajuta să dezvolți și să deploiezi serverul | [Deploiază serverul tău](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Implementare practică** | Utilizarea SDK-urilor în diferite limbaje, depanare, testare și validare, crearea de șabloane și fluxuri reutilizabile pentru prompturi | [Implementare practică](./04-PracticalImplementation/README.md) |
| 05 | **Subiecte avansate în MCP** | Fluxuri AI multimodale și extensibilitate, strategii sigure de scalare, MCP în ecosisteme enterprise | [Subiecte avansate](./05-AdvancedTopics/README.md) |
| 5.1 | **Integrarea MCP cu Azure** | Demonstrează integrarea cu Azure | [Integrare MCP Azure](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multimodalitate** | Arată cum să lucrezi cu diferite modalități precum imagini și altele | [Multimodalitate](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **Demo MCP OAuth2** | Aplicație minimală Spring Boot care arată OAuth2 cu MCP, atât ca Authorization cât și Resource Server. Demonstrează emiterea securizată a tokenurilor, endpointuri protejate, deployment pe Azure Container Apps și integrare cu API Management | [Demo MCP OAuth2](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Află mai multe despre root context și cum să le implementezi | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Învață diferite tipuri de rutare | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Învață cum să lucrezi cu sampling | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Scalare** | Află despre scalarea serverelor MCP, inclusiv strategii de scalare orizontală și verticală, optimizarea resurselor și ajustarea performanței | [Scalare](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Securitate** | Securizează-ți serverul MCP, inclusiv autentificare, autorizare și strategii de protecție a datelor | [Securitate](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Server și client MCP în Python integrând SerpAPI pentru căutare web, știri, produse și Q&A în timp real. Demonstrează orchestrarea multi-tool, integrarea API-urilor externe și gestionarea robustă a erorilor | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Streaming în timp real** | Streaming-ul de date în timp real a devenit esențial în lumea de azi bazată pe date, unde afacerile și aplicațiile au nevoie de acces imediat la informații pentru a lua decizii rapide | [Streaming în timp real](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Căutare web în timp real** | Căutarea web în timp real: cum MCP transformă căutarea web în timp real oferind o abordare standardizată pentru gestionarea contextului între modele AI, motoare de căutare și aplicații | [Căutare web în timp real](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Contribuții comunitare** | Cum să contribui cu cod și documentație, colaborarea prin GitHub, îmbunătățiri și feedback susținute de comunitate | [Contribuții comunitare](./06-CommunityContributions/README.md) |
| 07 | **Perspective din Adoptarea Timpurie** | Implementări din lumea reală și ce a funcționat, construirea și implementarea soluțiilor bazate pe MCP, tendințe și foaia de parcurs viitoare | [Perspective](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Cele Mai Bune Practici pentru MCP** | Ajustarea performanței și optimizare, proiectarea sistemelor MCP tolerante la erori, strategii de testare și reziliență | [Cele Mai Bune Practici](./08-BestPractices/README.md) |
| 09 | **Studii de Caz MCP** | Analize detaliate ale arhitecturilor soluțiilor MCP, planuri de implementare și sfaturi pentru integrare, diagrame comentate și parcurgeri ale proiectelor | [Studii de Caz](./09-CaseStudy/README.md) |
| 10 | **Optimizarea Fluxurilor AI: Construirea unui Server MCP cu AI Toolkit** | Atelier practic cuprinzător care combină MCP cu AI Toolkit de la Microsoft pentru VS Code. Învață să construiești aplicații inteligente care conectează modelele AI cu instrumente reale prin module practice ce acoperă fundamentele, dezvoltarea serverului personalizat și strategii de implementare în producție. | [Atelier Practic](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Proiecte Exemplu

### 🧮 Proiecte Exemplu MCP Calculator:
<details>
  <summary><strong>Explorează Implementările de Cod pe Limbaje</strong></summary>

  - [Exemplu Server MCP C#](./03-GettingStarted/samples/csharp/README.md)
  - [Calculator MCP Java](./03-GettingStarted/samples/java/calculator/README.md)
  - [Demo MCP JavaScript](./03-GettingStarted/samples/javascript/README.md)
  - [Server MCP Python](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [Exemplu MCP TypeScript](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Proiecte Avansate MCP Calculator:
<details>
  <summary><strong>Explorează Exemple Avansate</strong></summary>

  - [Exemplu Avansat C#](./04-PracticalImplementation/samples/csharp/README.md)
  - [Exemplu Aplicație Container Java](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [Exemplu Avansat JavaScript](./04-PracticalImplementation/samples/javascript/README.md)
  - [Implementare Complexă Python](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [Exemplu Container TypeScript](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Cerințe Prealabile pentru Învățarea MCP

Pentru a profita la maximum de acest curriculum, ar trebui să ai:

- Cunoștințe de bază în C#, Java sau Python  
- Înțelegerea modelului client-server și a API-urilor  
- (Opțional) Familiaritate cu conceptele de învățare automată  

## 📚 Ghid de Studiu

Un [Ghid de Studiu](./study_guide.md) cuprinzător este disponibil pentru a te ajuta să navighezi eficient prin acest depozit. Ghidul include:

- O hartă vizuală a curriculumului care arată toate subiectele acoperite  
- Defalcarea detaliată a fiecărei secțiuni din depozit  
- Instrucțiuni despre cum să folosești proiectele exemplu  
- Căi recomandate de învățare pentru diferite niveluri de competență  
- Resurse suplimentare pentru a-ți completa parcursul de învățare  

## 🛠️ Cum să Folosești Eficient Acest Curriculum

Fiecare lecție din acest ghid include:

1. Explicații clare ale conceptelor MCP  
2. Exemple de cod live în mai multe limbaje  
3. Exerciții pentru a construi aplicații reale MCP  
4. Resurse suplimentare pentru învățăcei avansați  

## 📜 Informații despre Licență

Acest conținut este licențiat sub **MIT License**. Pentru termeni și condiții, vezi [LICENSE](../../LICENSE).

## 🤝 Ghid pentru Contribuții

Acest proiect primește cu plăcere contribuții și sugestii. Majoritatea contribuțiilor necesită să fii de acord cu un Acord de Licență pentru Contribuitori (CLA) prin care declari că ai dreptul și chiar acorzi drepturile de utilizare a contribuției tale. Pentru detalii, vizitează <https://cla.opensource.microsoft.com>.

Când trimiți o cerere de pull, un bot CLA va determina automat dacă trebuie să furnizezi un CLA și va marca PR-ul corespunzător (de ex., verificare status, comentariu). Urmează pur și simplu instrucțiunile oferite de bot. Va trebui să faci acest lucru o singură dată pentru toate depozitele care folosesc CLA-ul nostru.

Acest proiect a adoptat [Codul de Conduită Open Source Microsoft](https://opensource.microsoft.com/codeofconduct/). Pentru mai multe informații vezi [FAQ Cod de Conduită](https://opensource.microsoft.com/codeofconduct/faq/) sau contactează [opencode@microsoft.com](mailto:opencode@microsoft.com) pentru întrebări sau comentarii suplimentare.

## 🎒 Alte Cursuri  
Echipa noastră produce și alte cursuri! Verifică:

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
- [Stăpânirea GitHub Copilot pentru programarea asistată AI în echipă](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Stăpânirea GitHub Copilot pentru dezvoltatori C#/.NET](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Alege-ți propria aventură cu Copilot](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Notă privind marca comercială

Acest proiect poate conține mărci comerciale sau logo-uri pentru proiecte, produse sau servicii. Utilizarea autorizată a mărcilor comerciale sau logo-urilor Microsoft este supusă și trebuie să respecte
[Regulile privind mărcile comerciale și brandurile Microsoft](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Utilizarea mărcilor comerciale sau logo-urilor Microsoft în versiunile modificate ale acestui proiect nu trebuie să creeze confuzie sau să sugereze sponsorizarea Microsoft.
Orice utilizare a mărcilor comerciale sau logo-urilor terților este supusă politicilor acelor terți.

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea în urma utilizării acestei traduceri.