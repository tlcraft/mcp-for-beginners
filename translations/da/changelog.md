<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:16:19+00:00",
  "source_file": "changelog.md",
  "language_code": "da"
}
-->
# Ændringslog: MCP for Begyndere Curriculum

Dette dokument fungerer som en oversigt over alle væsentlige ændringer, der er foretaget i Model Context Protocol (MCP) for Begyndere curriculum. Ændringer er dokumenteret i omvendt kronologisk rækkefølge (nyeste ændringer først).

## 15. september 2025

### Udvidelse af Avancerede Emner - Tilpassede Transportsystemer & Kontekst Engineering

#### MCP Tilpassede Transportsystemer (05-AdvancedTopics/mcp-transport/) - Ny Avanceret Implementeringsguide
- **README.md**: Komplet implementeringsguide til tilpassede MCP transportmekanismer
  - **Azure Event Grid Transport**: Omfattende serverløs event-drevet transportimplementering
    - Eksempler i C#, TypeScript og Python med Azure Functions integration
    - Arkitekturmønstre for skalerbare MCP-løsninger
    - Webhook-modtagere og push-baseret beskedhåndtering
  - **Azure Event Hubs Transport**: Implementering af højkapacitets streaming transport
    - Realtids streaming kapaciteter til lav-latens scenarier
    - Partitioneringsstrategier og checkpoint-håndtering
    - Beskedbatching og optimering af ydeevne
  - **Enterprise Integrationsmønstre**: Produktionsklare arkitektureksempler
    - Distribueret MCP-behandling på tværs af flere Azure Functions
    - Hybrid transportarkitekturer, der kombinerer flere transporttyper
    - Beskedholdbarhed, pålidelighed og fejlhåndteringsstrategier
  - **Sikkerhed & Overvågning**: Integration med Azure Key Vault og observabilitetsmønstre
    - Administreret identitetsautentifikation og mindst privilegeret adgang
    - Application Insights telemetri og ydeevneovervågning
    - Circuit breakers og mønstre for fejltolerance
  - **Test Frameworks**: Omfattende teststrategier for tilpassede transportsystemer
    - Enhedstest med testdoubles og mocking frameworks
    - Integrationstest med Azure Test Containers
    - Overvejelser om ydeevne- og belastningstest

#### Kontekst Engineering (05-AdvancedTopics/mcp-contextengineering/) - Fremvoksende AI-disciplin
- **README.md**: Omfattende udforskning af kontekst engineering som et fremvoksende felt
  - **Kerneprincipper**: Komplet kontekstdeling, bevidsthed om handlingsbeslutninger og styring af kontekstvinduer
  - **MCP Protokoltilpasning**: Hvordan MCP-design adresserer udfordringer inden for kontekst engineering
    - Begrænsninger i kontekstvinduer og strategier for progressiv indlæsning
    - Relevansbestemmelse og dynamisk konteksthentning
    - Multimodal konteksthåndtering og sikkerhedsovervejelser
  - **Implementeringsmetoder**: Enkelttrådede vs. multi-agent arkitekturer
    - Teknikker til kontekstchunking og prioritering
    - Progressiv kontekstindlæsning og komprimeringsstrategier
    - Lagdelte konteksttilgange og optimering af hentning
  - **Målingsramme**: Fremvoksende metrikker til evaluering af konteksteffektivitet
    - Inputeffektivitet, ydeevne, kvalitet og brugeroplevelse
    - Eksperimentelle tilgange til kontekstoptimering
    - Fejlanalyse og forbedringsmetodologier

#### Opdateringer af Curriculum Navigation (README.md)
- **Forbedret Modulstruktur**: Opdateret curriculum-tabel til at inkludere nye avancerede emner
  - Tilføjet Kontekst Engineering (5.14) og Tilpasset Transport (5.15) poster
  - Konsistent formatering og navigationslinks på tværs af alle moduler
  - Opdaterede beskrivelser for at afspejle det aktuelle indholdsomfang

### Forbedringer af Mappestruktur
- **Navngivningsstandardisering**: Omdøbt "mcp transport" til "mcp-transport" for konsistens med andre avancerede emnemapper
- **Indholdsorganisation**: Alle 05-AdvancedTopics mapper følger nu et konsistent navngivningsmønster (mcp-[emne])

### Forbedringer af Dokumentationskvalitet
- **MCP Specifikationsjustering**: Alt nyt indhold refererer til den aktuelle MCP Specifikation 2025-06-18
- **Eksempler på flere sprog**: Omfattende kodeeksempler i C#, TypeScript og Python
- **Enterprise Fokus**: Produktionsklare mønstre og Azure cloud integration gennem hele dokumentationen
- **Visuel Dokumentation**: Mermaid-diagrammer til arkitektur- og flowvisualisering

## 18. august 2025

### Omfattende Dokumentationsopdatering - MCP 2025-06-18 Standarder

#### MCP Sikkerhedsbedste Praksis (02-Security/) - Komplet Modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Komplet omskrivning i overensstemmelse med MCP Specifikation 2025-06-18
  - **Obligatoriske Krav**: Tilføjet eksplicitte SKAL/SKAL IKKE krav fra den officielle specifikation med klare visuelle indikatorer
  - **12 Kerne Sikkerhedspraksisser**: Omstruktureret fra 15-punkts liste til omfattende sikkerhedsdomæner
    - Tokensikkerhed & Autentifikation med integration af eksterne identitetsudbydere
    - Sessionsstyring & Transport Sikkerhed med kryptografiske krav
    - AI-Specifik Trusselsbeskyttelse med Microsoft Prompt Shields integration
    - Adgangskontrol & Tilladelser med princippet om mindst privilegium
    - Indholdssikkerhed & Overvågning med Azure Content Safety integration
    - Forsyningskædesikkerhed med omfattende komponentverifikation
    - OAuth Sikkerhed & Forebyggelse af Forvirret Stedfortræder med PKCE implementering
    - Incidenthåndtering & Genopretning med automatiserede kapaciteter
    - Overholdelse & Styring med regulatorisk tilpasning
    - Avancerede Sikkerhedskontroller med zero trust arkitektur
    - Microsoft Sikkerhedsøkosystem Integration med omfattende løsninger
    - Kontinuerlig Sikkerhedsudvikling med adaptive praksisser
  - **Microsoft Sikkerhedsløsninger**: Forbedret integrationsvejledning til Prompt Shields, Azure Content Safety, Entra ID og GitHub Advanced Security
  - **Implementeringsressourcer**: Kategoriserede omfattende ressourcelinks efter Officiel MCP Dokumentation, Microsoft Sikkerhedsløsninger, Sikkerhedsstandarder og Implementeringsguider

#### Avancerede Sikkerhedskontroller (02-Security/) - Enterprise Implementering
- **MCP-SECURITY-CONTROLS-2025.md**: Komplet revision med enterprise-grade sikkerhedsramme
  - **9 Omfattende Sikkerhedsdomæner**: Udvidet fra grundlæggende kontroller til detaljeret enterprise ramme
    - Avanceret Autentifikation & Autorisation med Microsoft Entra ID integration
    - Tokensikkerhed & Anti-Passthrough Kontroller med omfattende validering
    - Sessionssikkerhedskontroller med kapringforebyggelse
    - AI-Specifikke Sikkerhedskontroller med prompt injection og værktøjsforgiftning forebyggelse
    - Forebyggelse af Forvirret Stedfortræder Angreb med OAuth proxy sikkerhed
    - Værktøjseksekveringssikkerhed med sandboxing og isolation
    - Forsyningskædesikkerhedskontroller med afhængighedsverifikation
    - Overvågnings- & Detektionskontroller med SIEM integration
    - Incidenthåndtering & Genopretning med automatiserede kapaciteter
  - **Implementeringseksempler**: Tilføjet detaljerede YAML-konfigurationsblokke og kodeeksempler
  - **Microsoft Løsninger Integration**: Omfattende dækning af Azure sikkerhedstjenester, GitHub Advanced Security og enterprise identitetsstyring

#### Avancerede Emner Sikkerhed (05-AdvancedTopics/mcp-security/) - Produktionsklar Implementering
- **README.md**: Komplet omskrivning til enterprise sikkerhedsimplementering
  - **Aktuel Specifikationsjustering**: Opdateret til MCP Specifikation 2025-06-18 med obligatoriske sikkerhedskrav
  - **Forbedret Autentifikation**: Microsoft Entra ID integration med omfattende .NET og Java Spring Security eksempler
  - **AI Sikkerhedsintegration**: Microsoft Prompt Shields og Azure Content Safety implementering med detaljerede Python eksempler
  - **Avanceret Trusselsreduktion**: Omfattende implementeringseksempler for
    - Forebyggelse af Forvirret Stedfortræder Angreb med PKCE og brugerens samtykkevalidering
    - Forebyggelse af Token Passthrough med validering af målgruppe og sikker tokenhåndtering
    - Forebyggelse af Sessionskapring med kryptografisk binding og adfærdsanalyse
  - **Enterprise Sikkerhedsintegration**: Azure Application Insights overvågning, trusselsdetektionspipelines og forsyningskædesikkerhed
  - **Implementeringscheckliste**: Klare obligatoriske vs. anbefalede sikkerhedskontroller med Microsoft sikkerhedsøkosystemfordele

### Dokumentationskvalitet & Standardtilpasning
- **Specifikationsreferencer**: Opdateret alle referencer til den aktuelle MCP Specifikation 2025-06-18
- **Microsoft Sikkerhedsøkosystem**: Forbedret integrationsvejledning gennem hele sikkerhedsdokumentationen
- **Praktisk Implementering**: Tilføjet detaljerede kodeeksempler i .NET, Java og Python med enterprise mønstre
- **Ressourceorganisation**: Omfattende kategorisering af officiel dokumentation, sikkerhedsstandarder og implementeringsguider
- **Visuelle Indikatorer**: Klar markering af obligatoriske krav vs. anbefalede praksisser

#### Kernekoncepter (01-CoreConcepts/) - Komplet Modernisering
- **Protokolversionsopdatering**: Opdateret til at referere til den aktuelle MCP Specifikation 2025-06-18 med dato-baseret versionering (YYYY-MM-DD format)
- **Arkitekturforfining**: Forbedrede beskrivelser af Hosts, Clients og Servers for at afspejle aktuelle MCP arkitekturmønstre
  - Hosts nu klart defineret som AI-applikationer, der koordinerer flere MCP klientforbindelser
  - Clients beskrevet som protokolforbindelser, der opretholder en-til-en serverrelationer
  - Servers forbedret med lokale vs. fjernudrulningsscenarier
- **Primitiv Omstrukturering**: Komplet revision af server- og klientprimitiver
  - Serverprimitiver: Ressourcer (datakilder), Prompts (skabeloner), Tools (eksekverbare funktioner) med detaljerede forklaringer og eksempler
  - Klientprimitiver: Sampling (LLM completions), Elicitation (brugerinput), Logging (debugging/overvågning)
  - Opdateret med aktuelle discovery (`*/list`), retrieval (`*/get`) og execution (`*/call`) metode mønstre
- **Protokolarkitektur**: Introduceret to-lags arkitekturmodel
  - Datalag: JSON-RPC 2.0 fundament med livscyklusstyring og primitiv
  - Transportlag: STDIO (lokal) og Streamable HTTP med SSE (fjern) transportmekanismer
- **Sikkerhedsramme**: Omfattende sikkerhedsprincipper inklusive eksplicit brugerens samtykke, databeskyttelse, værktøjseksekveringssikkerhed og transportlagssikkerhed
- **Kommunikationsmønstre**: Opdaterede protokolbeskeder til at vise initialisering, discovery, eksekvering og notifikationsflows
- **Kodeeksempler**: Opdaterede eksempler på flere sprog (.NET, Java, Python, JavaScript) for at afspejle aktuelle MCP SDK mønstre

#### Sikkerhed (02-Security/) - Omfattende Sikkerhedsrevision  
- **Standardtilpasning**: Fuld tilpasning til MCP Specifikation 2025-06-18 sikkerhedskrav
- **Autentifikationsudvikling**: Dokumenteret udvikling fra brugerdefinerede OAuth-servere til delegation af eksterne identitetsudbydere (Microsoft Entra ID)
- **AI-Specifik Trusselsanalyse**: Forbedret dækning af moderne AI-angrebsvektorer
  - Detaljerede scenarier for prompt injection angreb med virkelige eksempler
  - Mekanismer for værktøjsforgiftning og "rug pull" angrebsmønstre
  - Kontekstvindueforgiftning og modelforvirringsangreb
- **Microsoft AI Sikkerhedsløsninger**: Omfattende dækning af Microsoft sikkerhedsøkosystem
  - AI Prompt Shields med avanceret detektion, spotlighting og delimiter teknikker
  - Azure Content Safety integrationsmønstre
  - GitHub Advanced Security til forsyningskædebeskyttelse
- **Avanceret Trusselsreduktion**: Detaljerede sikkerhedskontroller for
  - Sessionskapring med MCP-specifikke angrebsscenarier og kryptografiske session-ID krav
  - Forvirret stedfortræder problemer i MCP proxy-scenarier med eksplicit samtykkekrav
  - Token passthrough sårbarheder med obligatoriske valideringskontroller
- **Forsyningskædesikkerhed**: Udvidet AI forsyningskædedækning inklusive fundamentmodeller, embeddings tjenester, kontekstudbydere og tredjeparts API'er
- **Grundlæggende Sikkerhed**: Forbedret integration med enterprise sikkerhedsmønstre inklusive zero trust arkitektur og Microsoft sikkerhedsøkosystem
- **Ressourceorganisation**: Kategoriserede omfattende ressourcelinks efter type (Officielle Dokumenter, Standarder, Forskning, Microsoft Løsninger, Implementeringsguider)

### Forbedringer af Dokumentationskvalitet
- **Strukturerede Læringsmål**: Forbedrede læringsmål med specifikke, handlingsorienterede resultater 
- **Krydsreferencer**: Tilføjet links mellem relaterede sikkerheds- og kernekonceptemner
- **Aktuel Information**: Opdateret alle datoreferencer og specifikationslinks til aktuelle standarder
- **Implementeringsvejledning**: Tilføjet specifikke, handlingsorienterede implementeringsretningslinjer gennem begge sektioner

## 16. juli 2025

### README og Navigationsforbedringer
- Fuldt redesign af curriculum navigation i README.md
- Erstattet `<details>` tags med mere tilgængeligt tabelbaseret format
- Oprettet alternative layoutmuligheder i ny "alternative_layouts" mappe
- Tilføjet kortbaserede, fanebaserede og accordion-stil navigationsmuligheder
- Opdateret afsnittet om repository-struktur til at inkludere alle nyeste filer
- Forbedret afsnittet "Sådan bruger du dette curriculum" med klare anbefalinger
- Opdateret MCP specifikationslinks til at pege på korrekte URL'er
- Tilføjet Kontekst Engineering sektion (5.14) til curriculum-strukturen

### Opdateringer af Studievejledning
- Fuldt revideret studievejledning for at tilpasse sig den aktuelle repository-struktur
- Tilføjet nye sektioner for MCP Klienter og Værktøjer samt Populære MCP Servere
- Opdateret det Visuelle Curriculum Kort for nøjagtigt at afspejle alle emner
- Forbedret beskrivelser af Avancerede Emner for at dække alle specialiserede områder
- Opdateret afsnittet om Case Studies for at afspejle faktiske eksempler
- Tilføjet denne omfattende ændringslog

### Community Bidrag (06-CommunityContributions/)
- Tilføjet detaljeret information om MCP servere til billedgenerering
- Tilføjet omfattende sektion om brug af Claude i VSCode
- Tilføjet Cline terminal klient opsætnings- og brugsinstruktioner
- Opdateret MCP klient sektion for at inkludere alle populære klientmuligheder
- Forbedret bidragseksempler med mere præcise kodeeksempler

### Avancerede Emner (05-AdvancedTopics/)
- Organiseret alle specialiserede emnemapper med konsistent navngivning
- Tilføjet kontekst engineering materialer og eksempler
- Tilføjet Foundry agent integrationsdokumentation
- Forbedret Entra ID sikkerhedsintegrationsdokumentation

## 11. juni 2025

### Oprettelse af Grundstruktur
- Udgivet første version af MCP for Begyndere curriculum
- Oprettet grundstruktur for alle 10 hovedsektioner
- Implementeret Visuelt Curriculum Kort til navigation
- Tilføjet indledende eksempler på projekter i flere programmeringssprog

### Kom godt i gang (03-GettingStarted/)
- Oprettet første serverimplementeringseksempler
- Tilføjet vejledning til klientudvikling
- Inkluderet LLM klient integrationsinstruktioner
- Tilføjet VS Code integrationsdokumentation
- Implementeret Server-Sent Events (SSE) servereksempler

### Kernekoncepter (01-CoreConcepts/)
- Tilføjet detaljeret forklaring af klient-server arkitektur
- Oprettet dokumentation om nøgleprotokolkomponent

---

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi er ikke ansvarlige for eventuelle misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.