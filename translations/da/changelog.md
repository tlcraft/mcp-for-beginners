<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T17:48:23+00:00",
  "source_file": "changelog.md",
  "language_code": "da"
}
-->
# Ændringslog: MCP for Begyndere Curriculum

Dette dokument fungerer som en oversigt over alle væsentlige ændringer, der er foretaget i Model Context Protocol (MCP) for Begyndere curriculum. Ændringer er dokumenteret i omvendt kronologisk rækkefølge (nyeste ændringer først).

## 29. september 2025

### MCP Server Database Integration Labs - Omfattende Praktisk Læringssti

#### 11-MCPServerHandsOnLabs - Ny Komplet Database Integration Curriculum
- **Komplet 13-Labs Læringssti**: Tilføjet omfattende praktisk curriculum til opbygning af produktionsklare MCP-servere med PostgreSQL databaseintegration
  - **Implementering i Virkeligheden**: Zava Retail analytics use case, der demonstrerer mønstre i virksomhedsklassen
  - **Struktureret Læringsprogression**:
    - **Labs 00-03: Grundlag** - Introduktion, Kernearkitektur, Sikkerhed & Multi-Tenancy, Miljøopsætning
    - **Labs 04-06: Opbygning af MCP Server** - Database Design & Schema, MCP Server Implementering, Værktøjsudvikling  
    - **Labs 07-09: Avancerede Funktioner** - Semantisk Søgeintegration, Test & Debugging, VS Code Integration
    - **Labs 10-12: Produktion & Best Practices** - Udrulningsstrategier, Overvågning & Observabilitet, Best Practices & Optimering
  - **Virksomhedsteknologier**: FastMCP framework, PostgreSQL med pgvector, Azure OpenAI embeddings, Azure Container Apps, Application Insights
  - **Avancerede Funktioner**: Row Level Security (RLS), semantisk søgning, multi-tenant dataadgang, vektor embeddings, realtids overvågning

#### Terminologi Standardisering - Modul til Lab Konvertering
- **Omfattende Dokumentationsopdatering**: Systematisk opdateret alle README-filer i 11-MCPServerHandsOnLabs til at bruge "Lab"-terminologi i stedet for "Modul"
  - **Sektion Overskrifter**: Opdateret "Hvad Dette Modul Dækker" til "Hvad Denne Lab Dækker" på tværs af alle 13 labs
  - **Indholdsbeskrivelse**: Ændret "Dette modul giver..." til "Denne lab giver..." i hele dokumentationen
  - **Læringsmål**: Opdateret "Ved slutningen af dette modul..." til "Ved slutningen af denne lab..."
  - **Navigationslinks**: Konverteret alle "Modul XX:" referencer til "Lab XX:" i krydsreferencer og navigation
  - **Fuldførelsessporing**: Opdateret "Efter at have fuldført dette modul..." til "Efter at have fuldført denne lab..."
  - **Bevarede Tekniske Referencer**: Bibeholdt Python modulreferencer i konfigurationsfiler (f.eks., `"module": "mcp_server.main"`)

#### Forbedring af Studievejledning (study_guide.md)
- **Visuel Curriculum Kort**: Tilføjet ny "11. Database Integration Labs" sektion med omfattende lab-struktur visualisering
- **Repository Struktur**: Opdateret fra ti til elleve hovedsektioner med detaljeret beskrivelse af 11-MCPServerHandsOnLabs
- **Læringssti Vejledning**: Forbedret navigationsinstruktioner til at dække sektioner 00-11
- **Teknologidækning**: Tilføjet detaljer om FastMCP, PostgreSQL, Azure services integration
- **Læringsresultater**: Fremhævet udvikling af produktionsklare servere, databaseintegrationsmønstre og virksomhedssikkerhed

#### Forbedring af Hoved README Struktur
- **Lab-Baseret Terminologi**: Opdateret hoved README.md i 11-MCPServerHandsOnLabs til konsekvent at bruge "Lab"-struktur
- **Læringssti Organisation**: Klar progression fra grundlæggende begreber til avanceret implementering og produktionsudrulning
- **Virkelighedsfokus**: Fokus på praktisk, hands-on læring med mønstre og teknologier i virksomhedsklassen

### Dokumentationskvalitet & Konsistensforbedringer
- **Hands-On Læringsfokus**: Styrket praktisk, lab-baseret tilgang i hele dokumentationen
- **Virksomhedsmønstre Fokus**: Fremhævet produktionsklare implementeringer og virksomhedssikkerhedsovervejelser
- **Teknologiintegration**: Omfattende dækning af moderne Azure services og AI integrationsmønstre
- **Læringsprogression**: Klar, struktureret sti fra grundlæggende begreber til produktionsudrulning

## 26. september 2025

### Forbedring af Case Studies - GitHub MCP Registry Integration

#### Case Studies (09-CaseStudy/) - Fokus på Økosystemudvikling
- **README.md**: Større udvidelse med omfattende GitHub MCP Registry case study
  - **GitHub MCP Registry Case Study**: Ny omfattende case study, der undersøger GitHubs MCP Registry lancering i september 2025
    - **Problemanalyse**: Detaljeret undersøgelse af fragmenterede MCP server opdagelses- og udrulningsudfordringer
    - **Løsningsarkitektur**: GitHubs centraliserede registry tilgang med ét-klik VS Code installation
    - **Forretningspåvirkning**: Målbare forbedringer i udvikler onboarding og produktivitet
    - **Strategisk Værdi**: Fokus på modulær agentudrulning og tværværktøjs interoperabilitet
    - **Økosystemudvikling**: Positionering som fundamentalt platform for agentisk integration
  - **Forbedret Case Study Struktur**: Opdateret alle syv case studies med konsekvent formatering og omfattende beskrivelser
    - Azure AI Travel Agents: Fokus på multi-agent orkestrering
    - Azure DevOps Integration: Workflow automatisering
    - Realtids Dokumentationshentning: Python konsolklient implementering
    - Interaktiv Studieplan Generator: Chainlit samtale web app
    - Dokumentation i Editor: VS Code og GitHub Copilot integration
    - Azure API Management: Mønstre for virksomhed API integration
    - GitHub MCP Registry: Økosystemudvikling og fællesskabsplatform
  - **Omfattende Konklusion**: Omskrevet konklusionssektion, der fremhæver syv case studies, der spænder over flere MCP implementeringsdimensioner
    - Virksomhedsintegration, Multi-Agent Orkestrering, Udviklerproduktivitet
    - Økosystemudvikling, Uddannelsesapplikationer kategorisering
    - Forbedrede indsigter i arkitekturmønstre, implementeringsstrategier og best practices
    - Fokus på MCP som moden, produktionsklar protokol

#### Opdateringer af Studievejledning (study_guide.md)
- **Visuel Curriculum Kort**: Opdateret mindmap til at inkludere GitHub MCP Registry i Case Studies sektionen
- **Case Studies Beskrivelse**: Forbedret fra generiske beskrivelser til detaljeret opdeling af syv omfattende case studies
- **Repository Struktur**: Opdateret sektion 10 til at afspejle omfattende case study dækning med specifikke implementeringsdetaljer
- **Ændringslog Integration**: Tilføjet 26. september 2025 indgang, der dokumenterer GitHub MCP Registry tilføjelse og case study forbedringer
- **Datoopdateringer**: Opdateret fodnote tidsstempel til at afspejle seneste revision (26. september 2025)

### Dokumentationskvalitetsforbedringer
- **Konsistensforbedring**: Standardiseret case study formatering og struktur på tværs af alle syv eksempler
- **Omfattende Dækning**: Case studies dækker nu virksomhed, udviklerproduktivitet og økosystemudviklingsscenarier
- **Strategisk Positionering**: Forbedret fokus på MCP som fundamentalt platform for agentisk systemudrulning
- **Ressourceintegration**: Opdateret yderligere ressourcer til at inkludere GitHub MCP Registry link

## 15. september 2025

### Udvidelse af Avancerede Emner - Custom Transports & Context Engineering

#### MCP Custom Transports (05-AdvancedTopics/mcp-transport/) - Ny Avanceret Implementeringsguide
- **README.md**: Komplet implementeringsguide til custom MCP transportmekanismer
  - **Azure Event Grid Transport**: Omfattende serverless event-drevet transport implementering
    - C#, TypeScript og Python eksempler med Azure Functions integration
    - Event-drevet arkitekturmønstre for skalerbare MCP løsninger
    - Webhook modtagere og push-baseret beskedhåndtering
  - **Azure Event Hubs Transport**: Høj-gennemstrømning streaming transport implementering
    - Realtids streaming kapaciteter for lav-latens scenarier
    - Partitioneringsstrategier og checkpoint management
    - Beskedbatching og performanceoptimering
  - **Virksomhedsintegrationsmønstre**: Produktionsklare arkitektureksempler
    - Distribueret MCP behandling på tværs af flere Azure Functions
    - Hybrid transportarkitekturer, der kombinerer flere transporttyper
    - Beskedholdbarhed, pålidelighed og fejlbehandlingsstrategier
  - **Sikkerhed & Overvågning**: Azure Key Vault integration og observabilitetsmønstre
    - Administreret identitetsautentifikation og mindst privilegeret adgang
    - Application Insights telemetri og performanceovervågning
    - Circuit breakers og fejltolerance mønstre
  - **Test Frameworks**: Omfattende teststrategier for custom transports
    - Enhedstest med test doubles og mocking frameworks
    - Integrationstest med Azure Test Containers
    - Performance og belastningstest overvejelser

#### Context Engineering (05-AdvancedTopics/mcp-contextengineering/) - Fremvoksende AI-disciplin
- **README.md**: Omfattende udforskning af context engineering som et fremvoksende felt
  - **Kerneprincipper**: Komplet context sharing, action decision awareness og context window management
  - **MCP Protocol Tilpasning**: Hvordan MCP design adresserer context engineering udfordringer
    - Begrænsninger i context window og progressive loading strategier
    - Relevansbestemmelse og dynamisk context hentning
    - Multi-modal context håndtering og sikkerhedsovervejelser
  - **Implementeringsmetoder**: Single-threaded vs. multi-agent arkitekturer
    - Context chunking og prioriteringsteknikker
    - Progressiv context loading og komprimeringsstrategier
    - Lagdelte context tilgange og optimering af hentning
  - **Målingsramme**: Fremvoksende metrikker til evaluering af context effektivitet
    - Input effektivitet, performance, kvalitet og brugeroplevelse overvejelser
    - Eksperimentelle tilgange til context optimering
    - Fejlanalyse og forbedringsmetodologier

#### Curriculum Navigationsopdateringer (README.md)
- **Forbedret Modulstruktur**: Opdateret curriculum tabel til at inkludere nye avancerede emner
  - Tilføjet Context Engineering (5.14) og Custom Transport (5.15) poster
  - Konsekvent formatering og navigationslinks på tværs af alle moduler
  - Opdaterede beskrivelser til at afspejle aktuelt indholdsomfang

### Forbedringer af Mappestruktur
- **Navngivningsstandardisering**: Omdøbt "mcp transport" til "mcp-transport" for konsistens med andre avancerede emnefoldere
- **Indholdsorganisation**: Alle 05-AdvancedTopics foldere følger nu konsekvent navngivningsmønster (mcp-[emne])

### Dokumentationskvalitetsforbedringer
- **MCP Specifikationsjustering**: Alt nyt indhold refererer til den aktuelle MCP Specifikation 2025-06-18
- **Multi-Sprog Eksempler**: Omfattende kodeeksempler i C#, TypeScript og Python
- **Virksomhedsfokus**: Produktionsklare mønstre og Azure cloud integration gennem hele
- **Visuel Dokumentation**: Mermaid diagrammer til arkitektur og flow visualisering

## 18. august 2025

### Omfattende Dokumentationsopdatering - MCP 2025-06-18 Standarder

#### MCP Sikkerheds Best Practices (02-Security/) - Komplet Modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Komplet omskrivning tilpasset MCP Specifikation 2025-06-18
  - **Obligatoriske Krav**: Tilføjet eksplicitte MUST/MUST NOT krav fra officiel specifikation med klare visuelle indikatorer
  - **12 Kerne Sikkerhedspraksisser**: Omstruktureret fra 15-punkts liste til omfattende sikkerhedsområder
    - Token Sikkerhed & Autentifikation med ekstern identitetsudbyder integration
    - Session Management & Transport Sikkerhed med kryptografiske krav
    - AI-Specifik Trusselsbeskyttelse med Microsoft Prompt Shields integration
    - Adgangskontrol & Tilladelser med princippet om mindst privilegium
    - Indholdssikkerhed & Overvågning med Azure Content Safety integration
    - Forsyningskæde Sikkerhed med omfattende komponentverifikation
    - OAuth Sikkerhed & Forebyggelse af Forvirret Stedfortræder med PKCE implementering
    - Incident Response & Recovery med automatiserede kapaciteter
    - Overholdelse & Governance med regulatorisk tilpasning
    - Avancerede Sikkerhedskontroller med zero trust arkitektur
    - Microsoft Sikkerheds Økosystem Integration med omfattende løsninger
    - Kontinuerlig Sikkerhedsudvikling med adaptive praksisser
  - **Microsoft Sikkerhedsløsninger**: Forbedret integrationsvejledning for Prompt Shields, Azure Content Safety, Entra ID og GitHub Advanced Security
  - **Implementeringsressourcer**: Kategoriseret omfattende ressource links efter Officiel MCP Dokumentation, Microsoft Sikkerhedsløsninger, Sikkerhedsstandarder og Implementeringsguider

#### Avancerede Sikkerhedskontroller (02-Security/) - Virksomhedsimplementering
- **MCP-SECURITY-CONTROLS-2025.md**: Komplet revision med virksomhedsklasse sikkerhedsramme
  - **9 Omfattende Sikkerhedsområder**: Udvidet fra grundlæggende kontroller til detaljeret virksomhedsklasse ramme
    - Avanceret Autentifikation & Autorisation med Microsoft Entra ID integration
    - Token Sikkerhed & Anti-Passthrough Kontroller med omfattende validering
    - Session Sikkerhedskontroller med kapring forebyggelse
    - AI-Specifik Sikkerhedskontroller med prompt injection og værktøjsforgiftning forebyggelse
    - Forebyggelse af Forvirret Stedfortræder Angreb med OAuth proxy sikkerhed
    - Værktøjsudførelse Sikkerhed med sandboxing og isolation
    - Forsyningskæde Sikkerhedskontroller med afhængighedsverifikation
    - Overvågning & Detektion Kontroller med SIEM integration
    - Incident Response & Recovery med automatiserede kapaciteter
  - **Implementeringseksempler**: Tilføjet detaljerede YAML konfigurationsblokke og kodeeksempler
  - **Microsoft Løsninger Integration**: Omfattende dækning af Azure sikkerhedstjenester, GitHub Advanced Security og virksomhedens identitetsstyring

#### Avancerede Emner Sikkerhed (05-AdvancedTopics/mcp-security/) - Produktionsklar Implementering
- **README.md**: Komplet omskrivning for virksomhedsklasse sikkerhedsimplementering
  - **Aktuel Specifikationsjustering**: Opdateret til MCP Specifikation 2025-06-18 med obligatoriske sikkerhedskrav
  - **Forbedret Autentifikation**: Microsoft Entra ID integration med omfattende .NET og Java Spring Security eksempler
  - **AI Sikkerhedsintegration**: Microsoft Prompt Shields og Azure Content Safety implementering med detaljerede Python eksempler
  - **Avanceret Trusselsafværgning**: Omfattende implementeringseksempler for
    - Forebyggelse af Forvirret Stedfortræder Angreb med PKCE og bruger samtykke validering
    - Forebyggelse af Token Passthrough med audience validering og sikker token management
    - Forebyggelse af Session Kapring med kryptografisk binding og adfærdsanalyse
  - **Virksomhedssikkerhedsintegration**: Azure Application Insights overvågning, trusselsdetektions pipelines og forsyningskæde sikkerhed
  - **Implementeringscheckliste**: Klar obligatorisk vs. anbefalede sikkerhedskontroller med Microsoft sikkerhedsøkosystem fordele

### Dokumentationskvalitet & Standarder Justering
- **Specifikationsreferencer**: Opdateret alle referencer til aktuel MCP Specifikation 2025-06-18
- **Microsoft Sikkerheds Økosystem**: Forbedret integrationsvejledning gennem hele sikkerhedsdokumentationen
- **Praktisk Implementering**: Tilføjet detaljerede kodeeksempler i .NET, Java og Python med virksomhedsmønstre
- **Ressourceorganisation**: Omfattende kategorisering af officiel dokumentation, sikkerhedsstandarder og implementeringsguider
- **Visuelle indikatorer**: Klar markering af obligatoriske krav vs. anbefalede praksisser

#### Kernekoncepter (01-CoreConcepts/) - Fuld modernisering
- **Opdatering af protokolversion**: Opdateret til at referere til den aktuelle MCP-specifikation 2025-06-18 med dato-baseret versionering (YYYY-MM-DD format)
- **Arkitekturforfining**: Forbedrede beskrivelser af Hosts, Clients og Servers for at afspejle aktuelle MCP-arkitekturmønstre
  - Hosts er nu klart defineret som AI-applikationer, der koordinerer flere MCP-klientforbindelser
  - Klienter beskrevet som protokolforbindelser, der opretholder en-til-en serverrelationer
  - Servere forbedret med scenarier for lokal vs. fjernimplementering
- **Omstrukturering af primitive elementer**: Total revision af server- og klientprimitiver
  - Serverprimitiver: Ressourcer (datakilder), Prompts (skabeloner), Værktøjer (eksekverbare funktioner) med detaljerede forklaringer og eksempler
  - Klientprimitiver: Sampling (LLM-udfyldelser), Elicitation (brugerinput), Logging (fejlfinding/overvågning)
  - Opdateret med aktuelle metoder til opdagelse (`*/list`), hentning (`*/get`) og eksekvering (`*/call`)
- **Protokolarkitektur**: Introduceret to-lags arkitekturmodel
  - Datalag: JSON-RPC 2.0 fundament med livscyklusstyring og primitive elementer
  - Transportlag: STDIO (lokal) og Streamable HTTP med SSE (fjern) transportmekanismer
- **Sikkerhedsramme**: Omfattende sikkerhedsprincipper, herunder eksplicit brugeraccept, databeskyttelse, værktøjssikkerhed og transportlagssikkerhed
- **Kommunikationsmønstre**: Opdaterede protokolmeddelelser til at vise initialisering, opdagelse, eksekvering og notifikationsflows
- **Kodeeksempler**: Opdaterede eksempler i flere programmeringssprog (.NET, Java, Python, JavaScript) for at afspejle aktuelle MCP SDK-mønstre

#### Sikkerhed (02-Security/) - Omfattende sikkerhedsrevision  
- **Standardtilpasning**: Fuld tilpasning til MCP-specifikationens sikkerhedskrav 2025-06-18
- **Udvikling af autentifikation**: Dokumenteret overgang fra brugerdefinerede OAuth-servere til delegation via eksterne identitetsudbydere (Microsoft Entra ID)
- **AI-specifik trusselsanalyse**: Udvidet dækning af moderne AI-angrebsvektorer
  - Detaljerede scenarier for prompt injection-angreb med eksempler fra virkeligheden
  - Mekanismer for værktøjsforgiftning og "rug pull"-angrebsmønstre
  - Forgiftning af kontekstvinduer og model-forvirringsangreb
- **Microsoft AI-sikkerhedsløsninger**: Omfattende dækning af Microsofts sikkerhedsøkosystem
  - AI Prompt Shields med avanceret detektion, fremhævelse og afgrænsningsteknikker
  - Azure Content Safety integrationsmønstre
  - GitHub Advanced Security til beskyttelse af forsyningskæden
- **Avanceret trusselsafværgelse**: Detaljerede sikkerhedskontroller for
  - Session hijacking med MCP-specifikke angrebsscenarier og krav til kryptografiske session-ID'er
  - Problemer med forvirrede stedfortrædere i MCP-proxy-scenarier med eksplicit samtykke
  - Sårbarheder ved token-passthrough med obligatoriske valideringskontroller
- **Forsyningskædesikkerhed**: Udvidet dækning af AI-forsyningskæden, herunder grundlæggende modeller, embeddings-tjenester, kontekstudbydere og tredjeparts-API'er
- **Grundlæggende sikkerhed**: Forbedret integration med virksomhedssikkerhedsmønstre, herunder zero trust-arkitektur og Microsofts sikkerhedsøkosystem
- **Ressourceorganisation**: Kategoriserede omfattende ressourcelinks efter type (Officielle dokumenter, standarder, forskning, Microsoft-løsninger, implementeringsvejledninger)

### Forbedringer af dokumentationskvalitet
- **Strukturerede læringsmål**: Forbedrede læringsmål med specifikke, handlingsorienterede resultater
- **Krydsreferencer**: Tilføjet links mellem relaterede sikkerheds- og kernekonceptemner
- **Aktuelle oplysninger**: Opdateret alle datoreferencer og specifikationslinks til aktuelle standarder
- **Implementeringsvejledning**: Tilføjet specifikke, handlingsorienterede implementeringsvejledninger i begge sektioner

## 16. juli 2025

### README og navigationsforbedringer
- Fuldt redesign af curriculum-navigationen i README.md
- Erstattet `<details>`-tags med mere tilgængeligt tabelbaseret format
- Oprettet alternative layoutmuligheder i den nye "alternative_layouts"-mappe
- Tilføjet kortbaserede, fanebaserede og harmonikabaserede navigations-eksempler
- Opdateret sektionen om repository-struktur til at inkludere alle nyeste filer
- Forbedret sektionen "Sådan bruger du dette curriculum" med klare anbefalinger
- Opdateret MCP-specifikationslinks til at pege på korrekte URL'er
- Tilføjet sektionen Context Engineering (5.14) til curriculum-strukturen

### Opdateringer af studievejledning
- Fuldt revideret studievejledning for at tilpasse sig den aktuelle repository-struktur
- Tilføjet nye sektioner for MCP-klienter og værktøjer samt populære MCP-servere
- Opdateret det visuelle curriculum-kort for at afspejle alle emner korrekt
- Forbedret beskrivelser af avancerede emner for at dække alle specialiserede områder
- Opdateret sektionen med casestudier for at afspejle faktiske eksempler
- Tilføjet denne omfattende ændringslog

### Community Contributions (06-CommunityContributions/)
- Tilføjet detaljerede oplysninger om MCP-servere til billedgenerering
- Tilføjet omfattende sektion om brug af Claude i VSCode
- Tilføjet opsætnings- og brugsinstruktioner for Cline terminalklient
- Opdateret MCP-klientsektionen til at inkludere alle populære klientmuligheder
- Forbedret bidragseksempler med mere præcise kodeeksempler

### Avancerede emner (05-AdvancedTopics/)
- Organiseret alle specialiserede emnemapper med ensartede navne
- Tilføjet materialer og eksempler om kontekstengineering
- Tilføjet dokumentation om Foundry-agentintegration
- Forbedret dokumentation om Entra ID-sikkerhedsintegration

## 11. juni 2025

### Oprettelse af curriculum
- Udgivet første version af MCP for Beginners-curriculum
- Oprettet grundlæggende struktur for alle 10 hovedsektioner
- Implementeret visuelt curriculum-kort til navigation
- Tilføjet indledende prøveprojekter i flere programmeringssprog

### Kom godt i gang (03-GettingStarted/)
- Oprettet første serverimplementeringseksempler
- Tilføjet vejledning til klientudvikling
- Inkluderet instruktioner til LLM-klientintegration
- Tilføjet dokumentation om VS Code-integration
- Implementeret eksempler på Server-Sent Events (SSE)-servere

### Kernekoncepter (01-CoreConcepts/)
- Tilføjet detaljeret forklaring af klient-server-arkitektur
- Oprettet dokumentation om nøgleprotokolkomponenter
- Dokumenteret beskedmønstre i MCP

## 23. maj 2025

### Repository-struktur
- Initialiseret repository med grundlæggende mappestruktur
- Oprettet README-filer for hver hovedsektion
- Opsat oversættelsesinfrastruktur
- Tilføjet billedressourcer og diagrammer

### Dokumentation
- Oprettet indledende README.md med curriculum-oversigt
- Tilføjet CODE_OF_CONDUCT.md og SECURITY.md
- Opsat SUPPORT.md med vejledning til at få hjælp
- Oprettet foreløbig struktur for studievejledning

## 15. april 2025

### Planlægning og rammeværk
- Indledende planlægning for MCP for Beginners-curriculum
- Defineret læringsmål og målgruppe
- Skitseret 10-sektionsstruktur for curriculum
- Udviklet konceptuelt rammeværk for eksempler og casestudier
- Oprettet indledende prototypeeksempler for nøglekoncepter

---

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på at sikre nøjagtighed, skal det bemærkes, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os ikke ansvar for misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.