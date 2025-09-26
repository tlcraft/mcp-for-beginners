<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T18:32:24+00:00",
  "source_file": "changelog.md",
  "language_code": "da"
}
-->
# Ændringslog: MCP for Begyndere Curriculum

Dette dokument fungerer som en oversigt over alle væsentlige ændringer, der er foretaget i Model Context Protocol (MCP) for Begyndere curriculum. Ændringerne er dokumenteret i omvendt kronologisk rækkefølge (nyeste ændringer først).

## 26. september 2025

### Forbedring af Case Studies - Integration med GitHub MCP Registry

#### Case Studies (09-CaseStudy/) - Fokus på økosystemudvikling
- **README.md**: Større udvidelse med omfattende case study om GitHub MCP Registry
  - **GitHub MCP Registry Case Study**: Ny omfattende case study om GitHubs lancering af MCP Registry i september 2025
    - **Problem Analyse**: Detaljeret undersøgelse af udfordringer med fragmenteret MCP-serveropdagelse og implementering
    - **Løsningsarkitektur**: GitHubs centraliserede registry-tilgang med ét-klik installation i VS Code
    - **Forretningspåvirkning**: Målbare forbedringer i udvikler onboarding og produktivitet
    - **Strategisk Værdi**: Fokus på modulær agentimplementering og interoperabilitet mellem værktøjer
    - **Økosystemudvikling**: Positionering som en grundlæggende platform for agentisk integration
  - **Forbedret Case Study Struktur**: Opdateret alle syv case studies med ensartet format og omfattende beskrivelser
    - Azure AI Travel Agents: Fokus på multi-agent orkestrering
    - Azure DevOps Integration: Workflow automatisering
    - Real-Time Dokumentationshentning: Python konsolklient implementering
    - Interaktiv Studieplan Generator: Chainlit samtale-webapp
    - Dokumentation i Editor: Integration med VS Code og GitHub Copilot
    - Azure API Management: Mønstre for enterprise API integration
    - GitHub MCP Registry: Økosystemudvikling og fællesskabsplatform
  - **Omfattende Konklusion**: Omskrevet konklusionsafsnit, der fremhæver syv case studies, der dækker flere MCP-implementeringsdimensioner
    - Enterprise Integration, Multi-Agent Orkestrering, Udviklerproduktivitet
    - Økosystemudvikling, Uddannelsesapplikationer kategorisering
    - Forbedrede indsigter i arkitektoniske mønstre, implementeringsstrategier og bedste praksis
    - Fokus på MCP som en moden, produktionsklar protokol

#### Opdateringer i Studieguide (study_guide.md)
- **Visuelt Curriculum Kort**: Opdateret mindmap til at inkludere GitHub MCP Registry i Case Studies sektionen
- **Beskrivelse af Case Studies**: Forbedret fra generelle beskrivelser til detaljeret gennemgang af syv omfattende case studies
- **Repository Struktur**: Opdateret sektion 10 til at afspejle omfattende case study dækning med specifikke implementeringsdetaljer
- **Integration af Ændringslog**: Tilføjet 26. september 2025 indgang, der dokumenterer tilføjelsen af GitHub MCP Registry og forbedringer af case studies
- **Datoopdateringer**: Opdateret fodnote tidsstempel til at afspejle seneste revision (26. september 2025)

### Forbedringer af Dokumentationskvalitet
- **Konsistensforbedring**: Standardiseret format og struktur for case studies på tværs af alle syv eksempler
- **Omfattende Dækning**: Case studies dækker nu enterprise, udviklerproduktivitet og økosystemudviklingsscenarier
- **Strategisk Positionering**: Øget fokus på MCP som en grundlæggende platform for implementering af agentiske systemer
- **Ressourceintegration**: Opdateret yderligere ressourcer til at inkludere GitHub MCP Registry link

## 15. september 2025

### Udvidelse af Avancerede Emner - Custom Transports & Context Engineering

#### MCP Custom Transports (05-AdvancedTopics/mcp-transport/) - Ny avanceret implementeringsguide
- **README.md**: Komplet implementeringsguide til custom MCP transportmekanismer
  - **Azure Event Grid Transport**: Omfattende serverless event-drevet transportimplementering
    - Eksempler i C#, TypeScript og Python med Azure Functions integration
    - Mønstre for event-drevet arkitektur til skalerbare MCP-løsninger
    - Webhook modtagere og push-baseret beskedhåndtering
  - **Azure Event Hubs Transport**: Implementering af høj-gennemstrømnings streaming transport
    - Real-time streaming kapaciteter til lav-latens scenarier
    - Partitioneringsstrategier og checkpoint management
    - Beskedbatching og optimering af ydeevne
  - **Enterprise Integration Patterns**: Produktionsklare arkitektoniske eksempler
    - Distribueret MCP behandling på tværs af flere Azure Functions
    - Hybrid transportarkitekturer, der kombinerer flere transporttyper
    - Beskedholdbarhed, pålidelighed og fejlhåndteringsstrategier
  - **Sikkerhed & Overvågning**: Integration med Azure Key Vault og overvågningsmønstre
    - Managed identity autentifikation og mindst privilegeret adgang
    - Application Insights telemetri og ydeevneovervågning
    - Circuit breakers og mønstre for fejltolerance
  - **Test Frameworks**: Omfattende teststrategier for custom transports
    - Enhedstest med testdoubles og mocking frameworks
    - Integrationstest med Azure Test Containers
    - Overvejelser om ydeevne- og belastningstest

#### Context Engineering (05-AdvancedTopics/mcp-contextengineering/) - Fremvoksende AI-disciplin
- **README.md**: Omfattende udforskning af context engineering som et fremvoksende felt
  - **Kerneprincipper**: Komplet context sharing, action decision awareness og context window management
  - **MCP Protokoltilpasning**: Hvordan MCP design adresserer udfordringer inden for context engineering
    - Begrænsninger i context window og progressive loading strategier
    - Relevansbestemmelse og dynamisk context hentning
    - Multi-modal context håndtering og sikkerhedsovervejelser
  - **Implementeringsmetoder**: Single-threaded vs. multi-agent arkitekturer
    - Context chunking og prioriteringsteknikker
    - Progressive context loading og komprimeringsstrategier
    - Lagdelte context tilgange og optimering af hentning
  - **Målingsramme**: Fremvoksende metrikker til evaluering af context effektivitet
    - Input effektivitet, ydeevne, kvalitet og brugeroplevelse
    - Eksperimentelle tilgange til context optimering
    - Fejlanalyse og forbedringsmetodologier

#### Opdateringer i Curriculum Navigation (README.md)
- **Forbedret Modulstruktur**: Opdateret curriculum tabel til at inkludere nye avancerede emner
  - Tilføjet Context Engineering (5.14) og Custom Transport (5.15) indgange
  - Ensartet format og navigationslinks på tværs af alle moduler
  - Opdaterede beskrivelser til at afspejle det aktuelle indholdsomfang

### Forbedringer af Mappestruktur
- **Navngivningsstandardisering**: Omdøbt "mcp transport" til "mcp-transport" for konsistens med andre avancerede emne-mapper
- **Indholdsorganisation**: Alle 05-AdvancedTopics mapper følger nu ensartet navngivningsmønster (mcp-[emne])

### Forbedringer af Dokumentationskvalitet
- **MCP Specifikationsjustering**: Alt nyt indhold refererer til den aktuelle MCP Specifikation 2025-06-18
- **Multi-sprog Eksempler**: Omfattende kodeeksempler i C#, TypeScript og Python
- **Enterprise Fokus**: Produktionsklare mønstre og Azure cloud integration gennem hele dokumentationen
- **Visuel Dokumentation**: Mermaid diagrammer til arkitektur og flow visualisering

## 18. august 2025

### Omfattende Dokumentationsopdatering - MCP 2025-06-18 Standarder

#### MCP Sikkerhedsbedste Praksis (02-Security/) - Komplet Modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Komplet omskrivning i overensstemmelse med MCP Specifikation 2025-06-18
  - **Obligatoriske Krav**: Tilføjet eksplicitte MUST/MUST NOT krav fra den officielle specifikation med klare visuelle indikatorer
  - **12 Kerne Sikkerhedspraksisser**: Omstruktureret fra 15-punkts liste til omfattende sikkerhedsdomæner
    - Token Sikkerhed & Autentifikation med integration af eksterne identitetsudbydere
    - Sessionshåndtering & Transport Sikkerhed med kryptografiske krav
    - AI-Specifik Trusselsbeskyttelse med Microsoft Prompt Shields integration
    - Adgangskontrol & Tilladelser med princippet om mindst privilegium
    - Indholdssikkerhed & Overvågning med Azure Content Safety integration
    - Forsyningskædesikkerhed med omfattende komponentverifikation
    - OAuth Sikkerhed & Forebyggelse af Confused Deputy med PKCE implementering
    - Incident Response & Recovery med automatiserede kapaciteter
    - Overholdelse & Governance med regulatorisk tilpasning
    - Avancerede Sikkerhedskontroller med zero trust arkitektur
    - Microsoft Sikkerhedsøkosystem Integration med omfattende løsninger
    - Kontinuerlig Sikkerhedsevolution med adaptive praksisser
  - **Microsoft Sikkerhedsløsninger**: Forbedret integrationsvejledning for Prompt Shields, Azure Content Safety, Entra ID og GitHub Advanced Security
  - **Implementeringsressourcer**: Kategoriserede omfattende ressourcelinks efter Officiel MCP Dokumentation, Microsoft Sikkerhedsløsninger, Sikkerhedsstandarder og Implementeringsguider

#### Avancerede Sikkerhedskontroller (02-Security/) - Enterprise Implementering
- **MCP-SECURITY-CONTROLS-2025.md**: Komplet revision med enterprise-grade sikkerhedsramme
  - **9 Omfattende Sikkerhedsdomæner**: Udvidet fra grundlæggende kontroller til detaljeret enterprise ramme
    - Avanceret Autentifikation & Autorisation med Microsoft Entra ID integration
    - Token Sikkerhed & Anti-Passthrough Kontroller med omfattende validering
    - Sessionssikkerhedskontroller med kapringforebyggelse
    - AI-Specifikke Sikkerhedskontroller med prompt injection og værktøjsforgiftning forebyggelse
    - Forebyggelse af Confused Deputy Angreb med OAuth proxy sikkerhed
    - Værktøjsudførelsessikkerhed med sandboxing og isolation
    - Forsyningskædesikkerhedskontroller med afhængighedsverifikation
    - Overvågnings- & Detektionskontroller med SIEM integration
    - Incident Response & Recovery med automatiserede kapaciteter
  - **Implementeringseksempler**: Tilføjet detaljerede YAML konfigurationsblokke og kodeeksempler
  - **Microsoft Løsninger Integration**: Omfattende dækning af Azure sikkerhedstjenester, GitHub Advanced Security og enterprise identitetsstyring

#### Avancerede Emner Sikkerhed (05-AdvancedTopics/mcp-security/) - Produktionsklar Implementering
- **README.md**: Komplet omskrivning for enterprise sikkerhedsimplementering
  - **Aktuel Specifikationsjustering**: Opdateret til MCP Specifikation 2025-06-18 med obligatoriske sikkerhedskrav
  - **Forbedret Autentifikation**: Microsoft Entra ID integration med omfattende .NET og Java Spring Security eksempler
  - **AI Sikkerhedsintegration**: Microsoft Prompt Shields og Azure Content Safety implementering med detaljerede Python eksempler
  - **Avanceret Trusselsafværgning**: Omfattende implementeringseksempler for
    - Forebyggelse af Confused Deputy Angreb med PKCE og validering af brugerens samtykke
    - Forebyggelse af Token Passthrough med validering af målgruppe og sikker tokenhåndtering
    - Forebyggelse af Sessionskapring med kryptografisk binding og adfærdsanalyse
  - **Enterprise Sikkerhedsintegration**: Azure Application Insights overvågning, trusselsdetektionspipelines og forsyningskædesikkerhed
  - **Implementeringscheckliste**: Klare obligatoriske vs. anbefalede sikkerhedskontroller med Microsoft sikkerhedsøkosystem fordele

### Forbedringer af Dokumentationskvalitet & Standardtilpasning
- **Specifikationsreferencer**: Opdateret alle referencer til den aktuelle MCP Specifikation 2025-06-18
- **Microsoft Sikkerhedsøkosystem**: Forbedret integrationsvejledning gennem hele sikkerhedsdokumentationen
- **Praktisk Implementering**: Tilføjet detaljerede kodeeksempler i .NET, Java og Python med enterprise mønstre
- **Ressourceorganisation**: Omfattende kategorisering af officiel dokumentation, sikkerhedsstandarder og implementeringsguider
- **Visuelle Indikatorer**: Klar markering af obligatoriske krav vs. anbefalede praksisser

#### Kernekoncepter (01-CoreConcepts/) - Komplet Modernisering
- **Protokolversionsopdatering**: Opdateret til at referere til den aktuelle MCP Specifikation 2025-06-18 med dato-baseret versionering (YYYY-MM-DD format)
- **Arkitekturforfining**: Forbedrede beskrivelser af Hosts, Clients og Servers til at afspejle aktuelle MCP arkitekturmønstre
  - Hosts nu klart defineret som AI-applikationer, der koordinerer flere MCP klientforbindelser
  - Clients beskrevet som protokolforbindelser, der opretholder én-til-én serverrelationer
  - Servers forbedret med lokale vs. fjernimplementeringsscenarier
- **Primitive Omstrukturering**: Komplet revision af server- og klientprimitiver
  - Server Primitiver: Ressourcer (datakilder), Prompts (skabeloner), Tools (eksekverbare funktioner) med detaljerede forklaringer og eksempler
  - Klient Primitiver: Sampling (LLM completions), Elicitation (brugerinput), Logging (debugging/overvågning)
  - Opdateret med aktuelle opdagelses (`*/list`), hentnings (`*/get`) og eksekverings (`*/call`) metode mønstre
- **Protokolarkitektur**: Introduceret to-lags arkitekturmodel
  - Datalag: JSON-RPC 2.0 fundament med livscyklushåndtering og primitiv
  - Transportlag: STDIO (lokal) og Streamable HTTP med SSE (fjern) transportmekanismer
- **Sikkerhedsramme**: Omfattende sikkerhedsprincipper inklusive eksplicit brugerens samtykke, databeskyttelse, værktøjsudførelsessikkerhed og transportlagssikkerhed
- **Kommunikationsmønstre**: Opdaterede protokolbeskeder til at vise initialisering, opdagelse, eksekvering og notifikationsflows
- **Kodeeksempler**: Opdaterede multi-sprog eksempler (.NET, Java, Python, JavaScript) til at afspejle aktuelle MCP SDK mønstre

#### Sikkerhed (02-Security/) - Omfattende Sikkerhedsrevision  
- **Standardtilpasning**: Fuld tilpasning til MCP Specifikation 2025-06-18 sikkerhedskrav
- **Udvikling af Autentifikation**: Dokumenteret udvikling fra custom OAuth servers til delegation af eksterne identitetsudbydere (Microsoft Entra ID)
- **AI-Specifik Trusselsanalyse**: Forbedret dækning af moderne AI angrebsvektorer
  - Detaljerede scenarier for prompt injection angreb med virkelige eksempler
  - Mekanismer for værktøjsforgiftning og "rug pull" angrebsmønstre
  - Context window forgiftning og model forvirringsangreb
- **Microsoft AI Sikkerhedsløsninger**: Omfattende dækning af Microsoft sikkerhedsøkosystem
  - AI Prompt Shields med avanceret detektion, spotlighting og delimiter teknikker
  - Azure Content Safety integrationsmønstre
  - GitHub Advanced Security til forsyningskædebeskyttelse
- **Avanceret Trusselsafværgning**: Detaljerede sikkerhedskontroller for
  - Sessionskapring med MCP-specifikke angrebsscenarier og kryptografiske session ID krav
  - Confused deputy problemer i MCP proxy scenarier med eksplicitte samtykkekrav
  - Token passthrough sårbarheder med obligatoriske valideringskontroller
- **Forsyningskædesikkerhed**: Udvidet AI forsyningskædedækning inklusive foundation models, embeddings services, context providers og tredjeparts API'er
- **Grundlæggende Sikkerhed**: Forbedret integration med enterprise sikkerhedsmønstre inklusive zero trust arkitektur og Microsoft sikkerhedsøkosystem
- **Ressourceorganisation**: Kategoriserede omfattende ressourcelinks efter type (Officielle Dokumenter, Standarder, Forskning, Microsoft Løsninger, Implementeringsguider)

### Forbedringer af Dokumentationskvalitet
- **Strukturerede Læringsmål**: Forbedrede læringsmål med specifikke, handlingsorienterede resultater 
- **Krydsreferencer**: Tilføjet links mellem relaterede sikkerheds- og kernekonceptemner
- **Aktuel Information**: Opdateret alle datoreferencer og
- Udskiftede `<details>` tags med et mere tilgængeligt tabelbaseret format
- Oprettede alternative layoutmuligheder i den nye "alternative_layouts"-mappe
- Tilføjede eksempler på kortbaseret, faneblad-stil og harmonika-stil navigation
- Opdaterede afsnittet om repository-struktur til at inkludere alle nyeste filer
- Forbedrede afsnittet "Sådan bruger du dette pensum" med klare anbefalinger
- Opdaterede MCP-specifikationslinks, så de peger på de korrekte URL'er
- Tilføjede afsnittet Context Engineering (5.14) til pensumstrukturen

### Opdateringer til Studievejledningen
- Fuldt revideret studievejledningen for at tilpasse den til den aktuelle repository-struktur
- Tilføjede nye afsnit om MCP-klienter og værktøjer samt populære MCP-servere
- Opdaterede det visuelle pensumkort, så det nøjagtigt afspejler alle emner
- Forbedrede beskrivelser af avancerede emner for at dække alle specialiserede områder
- Opdaterede afsnittet om casestudier med faktiske eksempler
- Tilføjede denne omfattende ændringslog

### Fællesskabsbidrag (06-CommunityContributions/)
- Tilføjede detaljeret information om MCP-servere til billedgenerering
- Tilføjede omfattende afsnit om brug af Claude i VSCode
- Tilføjede opsætnings- og brugsinstruktioner for Cline terminalklient
- Opdaterede MCP-klientafsnittet til at inkludere alle populære klientmuligheder
- Forbedrede bidragseksempler med mere præcise kodeeksempler

### Avancerede Emner (05-AdvancedTopics/)
- Organiserede alle specialiserede emnemapper med ensartede navne
- Tilføjede materialer og eksempler om kontekstengineering
- Tilføjede dokumentation om Foundry-agentintegration
- Forbedrede dokumentation om Entra ID-sikkerhedsintegration

## 11. juni 2025

### Første Oprettelse
- Udgav første version af MCP for Beginners-pensum
- Oprettede grundstruktur for alle 10 hovedafsnit
- Implementerede visuelt pensumkort til navigation
- Tilføjede indledende prøveprojekter i flere programmeringssprog

### Kom godt i gang (03-GettingStarted/)
- Oprettede de første eksempler på serverimplementering
- Tilføjede vejledning til klientudvikling
- Inkluderede instruktioner til LLM-klientintegration
- Tilføjede dokumentation om VS Code-integration
- Implementerede eksempler på Server-Sent Events (SSE)-servere

### Grundlæggende Koncepter (01-CoreConcepts/)
- Tilføjede detaljeret forklaring af klient-server-arkitektur
- Oprettede dokumentation om nøgleprotokolkomponenter
- Dokumenterede beskedmønstre i MCP

## 23. maj 2025

### Repository-struktur
- Initialiserede repository med grundlæggende mappestruktur
- Oprettede README-filer for hver hovedsektion
- Opsatte oversættelsesinfrastruktur
- Tilføjede billedressourcer og diagrammer

### Dokumentation
- Oprettede indledende README.md med pensumoversigt
- Tilføjede CODE_OF_CONDUCT.md og SECURITY.md
- Opsatte SUPPORT.md med vejledning til at få hjælp
- Oprettede foreløbig struktur for studievejledningen

## 15. april 2025

### Planlægning og Rammeværk
- Indledende planlægning for MCP for Beginners-pensum
- Definerede læringsmål og målgruppe
- Skitserede 10-sektionsstrukturen for pensum
- Udviklede konceptuelt rammeværk for eksempler og casestudier
- Oprettede indledende prototypeeksempler for nøglekoncepter

---

