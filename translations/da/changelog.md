<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T15:04:51+00:00",
  "source_file": "changelog.md",
  "language_code": "da"
}
-->
# Ændringslog: MCP for Begyndere Curriculum

Dette dokument fungerer som en oversigt over alle væsentlige ændringer, der er foretaget i Model Context Protocol (MCP) for Begyndere curriculum. Ændringer er dokumenteret i omvendt kronologisk rækkefølge (nyeste ændringer først).

## 18. august 2025

### Omfattende Opdatering af Dokumentation - MCP 2025-06-18 Standarder

#### MCP Sikkerhedsbedste Praksis (02-Security/) - Fuld Modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Fuld omskrivning i overensstemmelse med MCP Specifikation 2025-06-18
  - **Obligatoriske Krav**: Tilføjet eksplicitte SKAL/SKAL IKKE krav fra den officielle specifikation med tydelige visuelle indikatorer
  - **12 Kerne Sikkerhedspraksisser**: Omstruktureret fra en liste med 15 punkter til omfattende sikkerhedsområder
    - Tokensikkerhed & Autentifikation med integration af eksterne identitetsudbydere
    - Sessionsstyring & Transport Sikkerhed med kryptografiske krav
    - AI-Specifik Trusselsbeskyttelse med Microsoft Prompt Shields integration
    - Adgangskontrol & Tilladelser med princippet om mindst privilegium
    - Indholdssikkerhed & Overvågning med Azure Content Safety integration
    - Forsyningskædesikkerhed med omfattende komponentverifikation
    - OAuth Sikkerhed & Forebyggelse af Confused Deputy med PKCE implementering
    - Hændelsesrespons & Genopretning med automatiserede kapaciteter
    - Overholdelse & Governance med regulatorisk tilpasning
    - Avancerede Sikkerhedskontroller med zero trust arkitektur
    - Microsoft Sikkerhedsøkosystem Integration med omfattende løsninger
    - Kontinuerlig Sikkerhedsevolution med adaptive praksisser
  - **Microsoft Sikkerhedsløsninger**: Forbedret integrationsvejledning for Prompt Shields, Azure Content Safety, Entra ID og GitHub Advanced Security
  - **Implementeringsressourcer**: Kategoriserede omfattende ressourcelinks efter Officiel MCP Dokumentation, Microsoft Sikkerhedsløsninger, Sikkerhedsstandarder og Implementeringsvejledninger

#### Avancerede Sikkerhedskontroller (02-Security/) - Implementering i Virksomheder
- **MCP-SECURITY-CONTROLS-2025.md**: Fuld revision med sikkerhedsramme på virksomhedsniveau
  - **9 Omfattende Sikkerhedsområder**: Udvidet fra grundlæggende kontroller til detaljeret ramme for virksomheder
    - Avanceret Autentifikation & Autorisation med Microsoft Entra ID integration
    - Tokensikkerhed & Anti-Passthrough Kontroller med omfattende validering
    - Sessionssikkerhedskontroller med forebyggelse af kapring
    - AI-Specifikke Sikkerhedskontroller med forebyggelse af prompt injection og værktøjsforgiftning
    - Forebyggelse af Confused Deputy Angreb med OAuth proxy sikkerhed
    - Værktøjsudførelse Sikkerhed med sandboxing og isolation
    - Forsyningskædesikkerhedskontroller med afhængighedsverifikation
    - Overvågnings- & Detektionskontroller med SIEM integration
    - Hændelsesrespons & Genopretning med automatiserede kapaciteter
  - **Implementeringseksempler**: Tilføjet detaljerede YAML-konfigurationsblokke og kodeeksempler
  - **Microsoft Løsninger Integration**: Omfattende dækning af Azure sikkerhedstjenester, GitHub Advanced Security og virksomhedens identitetsstyring

#### Avancerede Emner Sikkerhed (05-AdvancedTopics/mcp-security/) - Produktionsklar Implementering
- **README.md**: Fuld omskrivning for sikkerhedsimplementering i virksomheder
  - **Nuværende Specifikationsjustering**: Opdateret til MCP Specifikation 2025-06-18 med obligatoriske sikkerhedskrav
  - **Forbedret Autentifikation**: Microsoft Entra ID integration med omfattende .NET og Java Spring Security eksempler
  - **AI Sikkerhedsintegration**: Microsoft Prompt Shields og Azure Content Safety implementering med detaljerede Python eksempler
  - **Avanceret Trusselsafværgelse**: Omfattende implementeringseksempler for
    - Forebyggelse af Confused Deputy Angreb med PKCE og brugerens samtykkevalidering
    - Forebyggelse af Token Passthrough med validering af målgruppe og sikker tokenhåndtering
    - Forebyggelse af Sessionskapring med kryptografisk binding og adfærdsanalyse
  - **Virksomhedssikkerhedsintegration**: Azure Application Insights overvågning, trusselsdetektionspipelines og forsyningskædesikkerhed
  - **Implementeringscheckliste**: Klare obligatoriske vs. anbefalede sikkerhedskontroller med fordele ved Microsoft sikkerhedsøkosystem

### Dokumentationskvalitet & Standardjustering
- **Specifikationsreferencer**: Opdateret alle referencer til den aktuelle MCP Specifikation 2025-06-18
- **Microsoft Sikkerhedsøkosystem**: Forbedret integrationsvejledning i al sikkerhedsdokumentation
- **Praktisk Implementering**: Tilføjet detaljerede kodeeksempler i .NET, Java og Python med virksomhedsmønstre
- **Ressourceorganisation**: Omfattende kategorisering af officiel dokumentation, sikkerhedsstandarder og implementeringsvejledninger
- **Visuelle Indikatorer**: Tydelig markering af obligatoriske krav vs. anbefalede praksisser

#### Kernekoncepter (01-CoreConcepts/) - Fuld Modernisering
- **Protokolversionsopdatering**: Opdateret til at referere til den aktuelle MCP Specifikation 2025-06-18 med dato-baseret versionering (YYYY-MM-DD format)
- **Arkitekturforfining**: Forbedrede beskrivelser af Hosts, Clients og Servers for at afspejle aktuelle MCP arkitekturmønstre
  - Hosts nu klart defineret som AI-applikationer, der koordinerer flere MCP klientforbindelser
  - Clients beskrevet som protokolforbindelser, der opretholder en-til-en serverrelationer
  - Servers forbedret med lokale vs. fjernudrulningsscenarier
- **Primitiv Omstrukturering**: Fuld revision af server- og klientprimitiver
  - Serverprimitiver: Ressourcer (datakilder), Prompts (skabeloner), Tools (eksekverbare funktioner) med detaljerede forklaringer og eksempler
  - Klientprimitiver: Sampling (LLM fuldførelser), Elicitation (brugerinput), Logging (fejlfinding/overvågning)
  - Opdateret med aktuelle opdagelses (`*/list`), hentnings (`*/get`) og eksekverings (`*/call`) metode mønstre
- **Protokolarkitektur**: Introduceret to-lags arkitekturmodel
  - Datalag: JSON-RPC 2.0 fundament med livscyklusstyring og primitiv
  - Transportlag: STDIO (lokal) og Streamable HTTP med SSE (fjern) transportmekanismer
- **Sikkerhedsramme**: Omfattende sikkerhedsprincipper inklusive eksplicit brugerens samtykke, databeskyttelse, værktøjsudførelse sikkerhed og transportlag sikkerhed
- **Kommunikationsmønstre**: Opdaterede protokolmeddelelser til at vise initialisering, opdagelse, eksekvering og notifikationsflows
- **Kodeeksempler**: Opdaterede flersprogede eksempler (.NET, Java, Python, JavaScript) for at afspejle aktuelle MCP SDK mønstre

#### Sikkerhed (02-Security/) - Omfattende Sikkerhedsrevision  
- **Standardjustering**: Fuld justering med MCP Specifikation 2025-06-18 sikkerhedskrav
- **Autentifikationsudvikling**: Dokumenteret udvikling fra brugerdefinerede OAuth-servere til delegation af eksterne identitetsudbydere (Microsoft Entra ID)
- **AI-Specifik Trusselsanalyse**: Forbedret dækning af moderne AI angrebsvektorer
  - Detaljerede prompt injection angrebsscenarier med virkelige eksempler
  - Værktøjsforgiftningsmekanismer og "rug pull" angrebsmønstre
  - Context window forgiftning og model forvirringsangreb
- **Microsoft AI Sikkerhedsløsninger**: Omfattende dækning af Microsoft sikkerhedsøkosystem
  - AI Prompt Shields med avanceret detektion, spotlighting og delimiter teknikker
  - Azure Content Safety integrationsmønstre
  - GitHub Advanced Security for forsyningskædebeskyttelse
- **Avanceret Trusselsafværgelse**: Detaljerede sikkerhedskontroller for
  - Sessionskapring med MCP-specifikke angrebsscenarier og kryptografiske sessions-ID krav
  - Confused deputy problemer i MCP proxy scenarier med eksplicit samtykkekrav
  - Token passthrough sårbarheder med obligatoriske valideringskontroller
- **Forsyningskædesikkerhed**: Udvidet AI forsyningskædedækning inklusive grundlæggende modeller, embeddings tjenester, kontekstudbydere og tredjeparts API'er
- **Grundlæggende Sikkerhed**: Forbedret integration med virksomhedens sikkerhedsmønstre inklusive zero trust arkitektur og Microsoft sikkerhedsøkosystem
- **Ressourceorganisation**: Kategoriserede omfattende ressourcelinks efter type (Officielle Dokumenter, Standarder, Forskning, Microsoft Løsninger, Implementeringsvejledninger)

### Dokumentationskvalitetsforbedringer
- **Strukturerede Læringsmål**: Forbedrede læringsmål med specifikke, handlingsorienterede resultater 
- **Krydsreferencer**: Tilføjet links mellem relaterede sikkerheds- og kernekonceptemner
- **Aktuel Information**: Opdateret alle datoreferencer og specifikationslinks til aktuelle standarder
- **Implementeringsvejledning**: Tilføjet specifikke, handlingsorienterede implementeringsretningslinjer i begge sektioner

## 16. juli 2025

### README og Navigationsforbedringer
- Fuldt redesign af curriculum navigation i README.md
- Erstattet `<details>` tags med mere tilgængeligt tabelbaseret format
- Oprettet alternative layoutmuligheder i ny "alternative_layouts" mappe
- Tilføjet kortbaserede, fanebaserede og accordion-stil navigations eksempler
- Opdateret sektionen om repository struktur til at inkludere alle nyeste filer
- Forbedret "Sådan Bruger Du Dette Curriculum" sektion med klare anbefalinger
- Opdateret MCP specifikationslinks til at pege på korrekte URL'er
- Tilføjet Context Engineering sektion (5.14) til curriculum strukturen

### Opdateringer af Studievejledning
- Fuldt revideret studievejledning for at tilpasse sig den aktuelle repository struktur
- Tilføjet nye sektioner for MCP Klienter og Værktøjer samt Populære MCP Servere
- Opdateret det Visuelle Curriculum Kort for nøjagtigt at afspejle alle emner
- Forbedrede beskrivelser af Avancerede Emner for at dække alle specialiserede områder
- Opdateret sektionen om Case Studies for at afspejle faktiske eksempler
- Tilføjet denne omfattende ændringslog

### Fællesskabsbidrag (06-CommunityContributions/)
- Tilføjet detaljeret information om MCP servere til billedgenerering
- Tilføjet omfattende sektion om brug af Claude i VSCode
- Tilføjet Cline terminal klient opsætning og brugsinstruktioner
- Opdateret MCP klient sektion for at inkludere alle populære klientmuligheder
- Forbedrede bidragseksempler med mere præcise kodeeksempler

### Avancerede Emner (05-AdvancedTopics/)
- Organiseret alle specialiserede emnemapper med konsistent navngivning
- Tilføjet materialer og eksempler om kontekst engineering
- Tilføjet Foundry agent integrationsdokumentation
- Forbedret Entra ID sikkerhedsintegrationsdokumentation

## 11. juni 2025

### Oprettelse af Curriculum
- Udgivet første version af MCP for Begyndere curriculum
- Oprettet grundlæggende struktur for alle 10 hovedsektioner
- Implementeret Visuelt Curriculum Kort for navigation
- Tilføjet indledende prøveprojekter i flere programmeringssprog

### Kom godt i gang (03-GettingStarted/)
- Oprettet første serverimplementeringseksempler
- Tilføjet vejledning til klientudvikling
- Inkluderet LLM klientintegrationsinstruktioner
- Tilføjet VS Code integrationsdokumentation
- Implementeret Server-Sent Events (SSE) servereksempler

### Kernekoncepter (01-CoreConcepts/)
- Tilføjet detaljeret forklaring af klient-server arkitektur
- Oprettet dokumentation om nøgleprotokolkomponenter
- Dokumenteret beskedmønstre i MCP

## 23. maj 2025

### Repository Struktur
- Initialiseret repository med grundlæggende mappestruktur
- Oprettet README filer for hver hovedsektion
- Opsat oversættelsesinfrastruktur
- Tilføjet billedaktiver og diagrammer

### Dokumentation
- Oprettet indledende README.md med curriculum oversigt
- Tilføjet CODE_OF_CONDUCT.md og SECURITY.md
- Opsat SUPPORT.md med vejledning til at få hjælp
- Oprettet foreløbig struktur for studievejledning

## 15. april 2025

### Planlægning og Ramme
- Indledende planlægning for MCP for Begyndere curriculum
- Defineret læringsmål og målgruppe
- Skitseret 10-sektionsstruktur for curriculum
- Udviklet konceptuel ramme for eksempler og case studies
- Oprettet indledende prototypeeksempler for nøglekoncepter

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal det bemærkes, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os ikke ansvar for eventuelle misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.