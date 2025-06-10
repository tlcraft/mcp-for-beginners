<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3ede7f051090bd4acfe5b068bab9f6b0",
  "translation_date": "2025-06-10T04:28:53+00:00",
  "source_file": "README.md",
  "language_code": "no"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.no.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Følg disse trinnene for å komme i gang med å bruke disse ressursene:
1. **Fork Repository**: Klikk [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klon Repository**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Bli med i Azure AI Foundry Discord og møt eksperter og andre utviklere**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Støtte for flere språk

#### Støttes via GitHub Action (Automatisk og alltid oppdatert)

# 🚀 Model Context Protocol (MCP) læreplan for nybegynnere

## **Lær MCP med praktiske kodeeksempler i C#, Java, JavaScript, Python og TypeScript**

## 🧠 Oversikt over Model Context Protocol læreplanen

**Model Context Protocol (MCP)** er et banebrytende rammeverk som standardiserer samspillet mellom AI-modeller og klientapplikasjoner. Denne åpen kildekode-læreplanen tilbyr en strukturert læringsvei, komplett med praktiske kodeeksempler og virkelige brukstilfeller, på populære programmeringsspråk som C#, Java, JavaScript, TypeScript og Python.

Enten du er AI-utvikler, systemarkitekt eller programvareingeniør, er denne guiden din omfattende ressurs for å mestre MCP-grunnprinsippene og implementeringsstrategiene.

## 🔗 Offisielle MCP-ressurser

- 📘 [MCP Dokumentasjon](https://modelcontextprotocol.io/) – Detaljerte veiledninger og brukerguider  
- 📜 [MCP Spesifikasjon](https://spec.modelcontextprotocol.io/) – Protokollarkitektur og tekniske referanser  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Åpen kildekode SDK-er, verktøy og kodeeksempler  

## 🧭 Fullstendig MCP læreplanstruktur

| Kapittel | Tittel | Beskrivelse | Lenke |
|--|--|--|--|
| 00 | **Introduksjon til MCP** | Oversikt over Model Context Protocol og dens betydning i AI-pipelines, inkludert hva MCP er, hvorfor standardisering er viktig, samt praktiske bruksområder og fordeler | [Introduksjon](./00-Introduction/README.md) |
| 01 | **Kjernebegreper forklart** | Grundig gjennomgang av MCPs kjernebegreper, inkludert klient-server-arkitektur, nøkkelkomponenter i protokollen og meldingsmønstre | [Kjernebegreper](./01-CoreConcepts/README.md) |
| 02 | **Sikkerhet i MCP** | Identifisering av sikkerhetstrusler i MCP-baserte systemer, teknikker og beste praksis for sikker implementering | [Sikkerhet](./02-Security/README.md) |
| 03 | **Kom i gang med MCP** | Oppsett og konfigurasjon av miljø, opprette grunnleggende MCP-servere og klienter, integrere MCP med eksisterende applikasjoner | [Kom i gang](./03-GettingStarted/README.md) |
| 3.1 | **Første server** | Oppsett av en enkel server med MCP-protokollen, forståelse av server-klient-interaksjon og testing av serveren | [Første server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Første klient** | Oppsett av en enkel klient med MCP-protokollen, forståelse av klient-server-interaksjon og testing av klienten | [Første klient](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klient med LLM** | Oppsett av en klient med MCP-protokollen sammen med en stor språkmodell (LLM) | [Klient med LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Bruke Visual Studio Code til å konsumere server** | Konfigurere Visual Studio Code for å konsumere servere via MCP-protokollen | [Bruke Visual Studio Code til å konsumere server](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Opprette en server med SSE** | SSE hjelper oss å eksponere en server til internett. Denne delen hjelper deg med å lage en server ved hjelp av SSE | [Opprette en server med SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Bruke AI Toolkit** | AI Toolkit er et flott verktøy som hjelper deg å håndtere AI- og MCP-arbeidsflyten din | [Bruke AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Teste serveren din** | Testing er en viktig del av utviklingsprosessen. Denne delen hjelper deg å teste med flere forskjellige verktøy | [Teste serveren din](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Distribuere serveren din** | Hvordan går du fra lokal utvikling til produksjon? Denne delen hjelper deg med å utvikle og distribuere serveren | [Distribuere serveren din](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Praktisk implementering** | Bruk av SDK-er på tvers av språk, feilsøking, testing og validering, lage gjenbrukbare promptmaler og arbeidsflyter | [Praktisk implementering](./04-PracticalImplementation/README.md) |
| 05 | **Avanserte emner i MCP** | Multimodale AI-arbeidsflyter og utvidbarhet, sikre skaleringsstrategier, MCP i bedriftsøkosystemer | [Avanserte emner](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP-integrasjon med Azure** | Viser integrasjon med Azure | [MCP Azure-integrasjon](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multimodalitet** | Viser hvordan man jobber med ulike modaliteter som bilder og mer | [Multimodalitet](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimal Spring Boot-app som viser OAuth2 med MCP, både som autorisasjons- og ressursserver. Demonstrerer sikker tokenutstedelse, beskyttede endepunkter, Azure Container Apps-distribusjon og API Management-integrasjon | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Lær mer om root context og hvordan implementere dem | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Lær om forskjellige typer ruting | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Lær hvordan du jobber med sampling | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skalering** | Lær om skalering av MCP-servere, inkludert horisontal og vertikal skalering, ressursoptimalisering og ytelsesjustering | [Skalering](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Sikkerhet** | Sikre MCP-serveren din, inkludert autentisering, autorisasjon og databeskyttelsesstrategier | [Sikkerhet](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP-server og klient som integrerer med SerpAPI for sanntidssøk på web, nyheter, produkter og Q&A. Viser flerverktøy-orchestrering, ekstern API-integrasjon og robust feilhåndtering | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Bidrag fra fellesskapet** | Hvordan bidra med kode og dokumentasjon, samarbeid via GitHub, fellesskapsdrevne forbedringer og tilbakemeldinger | [Bidrag fra fellesskapet](./06-CommunityContributions/README.md) |
| 07 | **Innsikt fra tidlig adopsjon** | Virkelige implementeringer og hva som fungerte, bygge og distribuere MCP-baserte løsninger, trender og fremtidig veikart | [Innsikt](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Beste praksis for MCP** | Ytelsesoptimalisering og tuning, design av feiltolerante MCP-systemer, test- og robusthetsstrategier | [Beste praksis](./08-BestPractices/README.md) |
| 09 | **MCP casestudier** | Grundige analyser av MCP-løsningsarkitekturer, distribusjonsplaner og integrasjonstips, annoterte diagrammer og prosjektgjennomganger | [Casestudier](./09-CaseStudy/README.md) |
| 10 | **Strømlinjeforming av AI-arbeidsflyter: Bygge en MCP-server med AI Toolkit** | Omfattende praktisk workshop som kombinerer MCP med Microsofts AI Toolkit for VS Code. Lær å bygge intelligente applikasjoner som kobler AI-modeller med virkelige verktøy gjennom praktiske moduler som dekker grunnleggende konsepter, utvikling av egendefinerte servere og strategier for produksjonssetting. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Eksempelprosjekter

### 🧮 MCP Kalkulator Eksempelprosjekter:
<details>
  <summary><strong>Utforsk kodeimplementasjoner etter språk</strong></summary>

  - [C# MCP Server Eksempel](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Kalkulator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Eksempel](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Avanserte Kalkulatorprosjekter:
<details>
  <summary><strong>Utforsk avanserte eksempler</strong></summary>

  - [Avansert C# Eksempel](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container App Eksempel](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript Avansert Eksempel](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Kompleks Implementasjon](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Eksempel](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 Forutsetninger for å lære MCP

For å få mest mulig ut av dette kurset bør du ha:

- Grunnleggende kunnskap i C#, Java eller Python  
- Forståelse for klient-server-modellen og API-er  
- (Valgfritt) Kjennskap til maskinlæringskonsepter  

## 🛠️ Hvordan bruke dette kurset effektivt

Hver leksjon i denne guiden inneholder:

1. Klare forklaringer av MCP-konsepter  
2. Live kodeeksempler på flere språk  
3. Øvelser for å bygge ekte MCP-applikasjoner  
4. Ekstra ressurser for viderekomne  

## 📜 Lisensinformasjon

Dette innholdet er lisensiert under **MIT License**. For vilkår og betingelser, se [LICENSE](../../LICENSE).

## 🤝 Retningslinjer for bidrag

Dette prosjektet tar imot bidrag og forslag. De fleste bidrag krever at du godtar en Contributor License Agreement (CLA) som bekrefter at du har rettighetene til, og faktisk gir oss, rettighetene til å bruke bidraget ditt. For detaljer, besøk <https://cla.opensource.microsoft.com>.

Når du sender inn en pull request, vil en CLA-bot automatisk avgjøre om du må levere en CLA og merke PR-en deretter (f.eks. status-sjekk, kommentar). Følg bare instruksjonene fra boten. Du trenger kun å gjøre dette én gang for alle repoer som bruker vår CLA.

Dette prosjektet har tatt i bruk [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For mer informasjon, se [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) eller kontakt [opencode@microsoft.com](mailto:opencode@microsoft.com) ved spørsmål eller kommentarer.

## 🎒 Andre kurs
Teamet vårt produserer flere kurs! Sjekk ut:

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

## ™️ Varemerkevarsel

Dette prosjektet kan inneholde varemerker eller logoer for prosjekter, produkter eller tjenester. Autorisert bruk av Microsofts varemerker eller logoer må følge [Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general). Bruk av Microsofts varemerker eller logoer i modifiserte versjoner av dette prosjektet må ikke skape forvirring eller antyde at Microsoft sponser prosjektet. Bruk av tredjeparts varemerker eller logoer er underlagt disse tredjepartenes retningslinjer.

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på det opprinnelige språket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.