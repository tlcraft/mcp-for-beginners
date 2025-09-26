<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T18:30:35+00:00",
  "source_file": "changelog.md",
  "language_code": "sv"
}
-->
# Ändringslogg: MCP för Nybörjare Curriculum

Detta dokument fungerar som en redogörelse för alla betydande ändringar som gjorts i Model Context Protocol (MCP) för Nybörjare curriculum. Ändringar dokumenteras i omvänd kronologisk ordning (nyaste ändringar först).

## 26 september 2025

### Förbättring av Fallstudier - Integration med GitHub MCP Registry

#### Fallstudier (09-CaseStudy/) - Fokus på Ekosystemutveckling
- **README.md**: Större expansion med omfattande fallstudie om GitHub MCP Registry
  - **Fallstudie om GitHub MCP Registry**: Ny omfattande fallstudie som undersöker GitHubs lansering av MCP Registry i september 2025
    - **Problemanalys**: Detaljerad undersökning av utmaningar med fragmenterad MCP-serverupptäckt och distribution
    - **Lösningsarkitektur**: GitHubs centraliserade registry-ansats med installation i VS Code med ett klick
    - **Affärspåverkan**: Mätbara förbättringar i utvecklarintroduktion och produktivitet
    - **Strategiskt värde**: Fokus på modulär agentdistribution och interoperabilitet mellan verktyg
    - **Ekosystemutveckling**: Positionering som grundläggande plattform för agentisk integration
  - **Förbättrad struktur för fallstudier**: Uppdaterade alla sju fallstudier med konsekvent format och omfattande beskrivningar
    - Azure AI Travel Agents: Betoning på multi-agent orkestrering
    - Azure DevOps Integration: Fokus på arbetsflödesautomatisering
    - Realtidsdokumentationshämtning: Implementering av Python-konsolklient
    - Interaktiv studieplansgenerator: Chainlit-konverserande webbapp
    - Dokumentation i redigeraren: Integration med VS Code och GitHub Copilot
    - Azure API Management: Mönster för företagsintegration av API
    - GitHub MCP Registry: Ekosystemutveckling och communityplattform
  - **Omfattande slutsats**: Omskriven slutsats som lyfter fram sju fallstudier som täcker flera MCP-implementeringsdimensioner
    - Företagsintegration, multi-agent orkestrering, utvecklarproduktivitet
    - Ekosystemutveckling, utbildningsapplikationer kategorisering
    - Förbättrade insikter i arkitekturmönster, implementeringsstrategier och bästa praxis
    - Betoning på MCP som ett moget, produktionsklart protokoll

#### Uppdateringar av studieguide (study_guide.md)
- **Visuell läroplan**: Uppdaterad tankekarta för att inkludera GitHub MCP Registry i avsnittet om fallstudier
- **Beskrivning av fallstudier**: Förbättrad från generiska beskrivningar till detaljerad genomgång av sju omfattande fallstudier
- **Repository-struktur**: Uppdaterat avsnitt 10 för att återspegla omfattande täckning av fallstudier med specifika implementeringsdetaljer
- **Integration av ändringslogg**: Lagt till posten för 26 september 2025 som dokumenterar tillägget av GitHub MCP Registry och förbättringar av fallstudier
- **Datumuppdateringar**: Uppdaterad sidfotstidsstämpel för att återspegla senaste revisionen (26 september 2025)

### Förbättringar av dokumentationskvalitet
- **Förbättrad konsekvens**: Standardiserat format och struktur för fallstudier över alla sju exempel
- **Omfattande täckning**: Fallstudier täcker nu scenarier för företag, utvecklarproduktivitet och ekosystemutveckling
- **Strategisk positionering**: Förbättrat fokus på MCP som grundläggande plattform för distribution av agentiska system
- **Resursintegration**: Uppdaterade ytterligare resurser för att inkludera länk till GitHub MCP Registry

## 15 september 2025

### Utvidgning av Avancerade Ämnen - Anpassade Transporter & Kontextteknik

#### MCP Anpassade Transporter (05-AdvancedTopics/mcp-transport/) - Ny avancerad implementeringsguide
- **README.md**: Komplett implementeringsguide för anpassade MCP-transportmekanismer
  - **Azure Event Grid Transport**: Omfattande serverlös händelsedriven transportimplementering
    - Exempel i C#, TypeScript och Python med integration av Azure Functions
    - Arkitekturmönster för händelsedriven skalbar MCP-lösning
    - Webhook-mottagare och push-baserad meddelandehantering
  - **Azure Event Hubs Transport**: Implementering av högkapacitets streamingtransport
    - Realtidsstreaming för scenarier med låg latens
    - Strategier för partitionering och hantering av kontrollpunkter
    - Meddelandebatchning och optimering av prestanda
  - **Företagsintegrationsmönster**: Produktionsklara arkitekturexempel
    - Distribuerad MCP-bearbetning över flera Azure Functions
    - Hybridtransportarkitekturer som kombinerar flera transporttyper
    - Strategier för meddelandedurabilitet, tillförlitlighet och felhantering
  - **Säkerhet & Övervakning**: Integration med Azure Key Vault och mönster för observabilitet
    - Autentisering med hanterad identitet och åtkomst med minsta privilegier
    - Telemetri med Application Insights och övervakning av prestanda
    - Kretsbrytare och mönster för fel tolerans
  - **Testningsramverk**: Omfattande teststrategier för anpassade transporter
    - Enhetstestning med testdubletter och mockningsramverk
    - Integrationstestning med Azure Test Containers
    - Överväganden för prestanda- och belastningstestning

#### Kontextteknik (05-AdvancedTopics/mcp-contextengineering/) - Framväxande AI-disciplin
- **README.md**: Omfattande utforskning av kontextteknik som ett framväxande område
  - **Kärnprinciper**: Komplett kontextdelning, medvetenhet om beslutsfattande och hantering av kontextfönster
  - **MCP-protokollanpassning**: Hur MCP-designen adresserar utmaningar inom kontextteknik
    - Begränsningar i kontextfönster och strategier för progressiv laddning
    - Relevansbestämning och dynamisk kontexthämtning
    - Hantering av multimodal kontext och säkerhetsöverväganden
  - **Implementeringsmetoder**: Enkelttrådade vs. multi-agent arkitekturer
    - Tekniker för kontextuppdelning och prioritering
    - Progressiv kontextladdning och komprimeringsstrategier
    - Lagerbaserade kontextmetoder och optimering av hämtning
  - **Mätramsverk**: Framväxande metrik för utvärdering av kontexteffektivitet
    - Effektivitet, prestanda, kvalitet och användarupplevelse
    - Experimentella metoder för kontextoptimering
    - Felanalys och förbättringsmetodologier

#### Uppdateringar av läroplansnavigering (README.md)
- **Förbättrad modulstruktur**: Uppdaterad läroplanstabell för att inkludera nya avancerade ämnen
  - Lagt till Kontextteknik (5.14) och Anpassad Transport (5.15)
  - Konsekvent format och navigeringslänkar över alla moduler
  - Uppdaterade beskrivningar för att återspegla aktuellt innehåll

### Förbättringar av katalogstruktur
- **Standardisering av namn**: Bytt namn från "mcp transport" till "mcp-transport" för konsekvens med andra avancerade ämnesmappar
- **Innehållsorganisation**: Alla mappar i 05-AdvancedTopics följer nu konsekvent namngivningsmönster (mcp-[ämne])

### Förbättringar av dokumentationskvalitet
- **Anpassning till MCP-specifikation**: Allt nytt innehåll hänvisar till aktuell MCP-specifikation 2025-06-18
- **Exempel på flera språk**: Omfattande kodexempel i C#, TypeScript och Python
- **Fokus på företag**: Produktionsklara mönster och integration med Azure-molnet
- **Visuell dokumentation**: Mermaid-diagram för arkitektur och flödesvisualisering

## 18 augusti 2025

### Omfattande uppdatering av dokumentation - MCP 2025-06-18 standarder

#### MCP Säkerhetsbästa praxis (02-Security/) - Komplett modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Komplett omskrivning i linje med MCP-specifikation 2025-06-18
  - **Obligatoriska krav**: Lagt till explicita MÅSTE/MÅSTE INTE-krav från officiell specifikation med tydliga visuella indikatorer
  - **12 Kärnsäkerhetspraktiker**: Omstrukturerad från 15-punktslista till omfattande säkerhetsdomäner
    - Tokensäkerhet & autentisering med integration av externa identitetsleverantörer
    - Sessionshantering & transportskydd med kryptografiska krav
    - AI-specifik hotbekämpning med Microsoft Prompt Shields-integration
    - Åtkomstkontroll & behörigheter med principen om minsta privilegier
    - Innehållssäkerhet & övervakning med Azure Content Safety-integration
    - Försörjningskedjesäkerhet med omfattande komponentverifiering
    - OAuth-säkerhet & förvirrad ställföreträdarprevention med PKCE-implementering
    - Incidenthantering & återhämtning med automatiserade kapabiliteter
    - Efterlevnad & styrning med regulatorisk anpassning
    - Avancerade säkerhetskontroller med nolltillitsarkitektur
    - Microsofts säkerhetsekosystemintegration med omfattande lösningar
    - Kontinuerlig säkerhetsevolution med adaptiva metoder
  - **Microsofts säkerhetslösningar**: Förbättrad integrationsvägledning för Prompt Shields, Azure Content Safety, Entra ID och GitHub Advanced Security
  - **Implementeringsresurser**: Kategoriserade omfattande resurslänkar efter Officiell MCP-dokumentation, Microsofts säkerhetslösningar, Säkerhetsstandarder och Implementeringsguider

#### Avancerade säkerhetskontroller (02-Security/) - Företagsimplementering
- **MCP-SECURITY-CONTROLS-2025.md**: Komplett översyn med företagsklassad säkerhetsram
  - **9 Omfattande säkerhetsdomäner**: Utökad från grundläggande kontroller till detaljerad företagsram
    - Avancerad autentisering & auktorisering med Microsoft Entra ID-integration
    - Tokensäkerhet & anti-passthrough-kontroller med omfattande validering
    - Sessionssäkerhetskontroller med kapningsprevention
    - AI-specifika säkerhetskontroller med skydd mot promptinjektion och verktygsförgiftning
    - Förvirrad ställföreträdarprevention med OAuth-proxysäkerhet
    - Verktygsutförandesäkerhet med sandboxing och isolering
    - Försörjningskedjesäkerhetskontroller med beroendeverifiering
    - Övervaknings- & detektionskontroller med SIEM-integration
    - Incidenthantering & återhämtning med automatiserade kapabiliteter
  - **Implementeringsexempel**: Lagt till detaljerade YAML-konfigurationsblock och kodexempel
  - **Microsofts lösningsintegration**: Omfattande täckning av Azure-säkerhetstjänster, GitHub Advanced Security och företagsidentitetshantering

#### Avancerade ämnen Säkerhet (05-AdvancedTopics/mcp-security/) - Produktionsklar implementering
- **README.md**: Komplett omskrivning för företagsimplementering av säkerhet
  - **Anpassning till aktuell specifikation**: Uppdaterad till MCP-specifikation 2025-06-18 med obligatoriska säkerhetskrav
  - **Förbättrad autentisering**: Microsoft Entra ID-integration med omfattande exempel i .NET och Java Spring Security
  - **AI-säkerhetsintegration**: Implementering av Microsoft Prompt Shields och Azure Content Safety med detaljerade Python-exempel
  - **Avancerad hotbekämpning**: Omfattande implementeringsexempel för
    - Förvirrad ställföreträdarprevention med PKCE och validering av användarsamtycke
    - Tokensäkerhet med publikvalidering och säker tokenhantering
    - Sessionskapningsprevention med kryptografisk bindning och beteendeanalys
  - **Företagsintegrationssäkerhet**: Övervakning med Azure Application Insights, hotdetektionspipelines och försörjningskedjesäkerhet
  - **Implementeringschecklista**: Tydliga obligatoriska vs. rekommenderade säkerhetskontroller med fördelar från Microsofts säkerhetsekosystem

### Förbättringar av dokumentationskvalitet & standardanpassning
- **Referenser till specifikation**: Uppdaterade alla referenser till aktuell MCP-specifikation 2025-06-18
- **Microsofts säkerhetsekosystem**: Förbättrad integrationsvägledning genom hela säkerhetsdokumentationen
- **Praktisk implementering**: Lagt till detaljerade kodexempel i .NET, Java och Python med företagsmönster
- **Resursorganisation**: Omfattande kategorisering av officiell dokumentation, säkerhetsstandarder och implementeringsguider
- **Visuella indikatorer**: Tydlig markering av obligatoriska krav vs. rekommenderade praxis

#### Kärnkoncept (01-CoreConcepts/) - Komplett modernisering
- **Protokollversionsuppdatering**: Uppdaterad för att referera till aktuell MCP-specifikation 2025-06-18 med datumformat (YYYY-MM-DD)
- **Arkitekturförfining**: Förbättrade beskrivningar av Hosts, Clients och Servers för att återspegla aktuella MCP-arkitekturmönster
  - Hosts nu tydligt definierade som AI-applikationer som koordinerar flera MCP-klientanslutningar
  - Clients beskrivna som protokollanslutningar som upprätthåller en-till-en serverrelationer
  - Servers förbättrade med lokala vs. fjärrdistributionsscenarier
- **Omstrukturering av primitiv**: Komplett översyn av server- och klientprimitiv
  - Serverprimitiv: Resurser (datakällor), Prompts (mallar), Verktyg (exekverbara funktioner) med detaljerade förklaringar och exempel
  - Klientprimitiv: Sampling (LLM-kompletteringar), Elicitation (användarinmatning), Logging (felsökning/övervakning)
  - Uppdaterad med aktuella upptäcktsmetoder (`*/list`), hämtning (`*/get`) och exekvering (`*/call`)
- **Protokollarkitektur**: Introducerade två-lagers arkitekturmodell
  - Dataskikt: JSON-RPC 2.0 grund med livscykelhantering och primitiv
  - Transportskikt: STDIO (lokal) och Streamable HTTP med SSE (fjärr) transportmekanismer
- **Säkerhetsramverk**: Omfattande säkerhetsprinciper inklusive explicit användarsamtycke, dataintegritetsskydd, verktygsutförandesäkerhet och transportskiktssäkerhet
- **Kommunikationsmönster**: Uppdaterade protokollmeddelanden för att visa initialisering, upptäckt, exekvering och notifieringsflöden
- **Kodexempel**: Uppdaterade flerspråkiga exempel (.NET, Java, Python, JavaScript) för att återspegla aktuella MCP SDK-mönster

#### Säkerhet (02-Security/) - Omfattande säkerhetsöversyn  
- **Standardanpassning**: Fullständig anpassning till MCP-specifikation 2025-06-18 säkerhetskrav
- **Utveckling av autentisering**: Dokumenterad utveckling från anpassade OAuth-servrar till delegation av externa identitetsleverantörer (Microsoft Entra ID)
- **AI-specifik hotanalys**: Förbättrad täckning av moderna AI-attackvektorer
  - Detaljerade scenarier för promptinjektion med verkliga exempel
  - Mekanismer för verktygsförgiftning och "rug pull"-attacker
  - Förgiftning av kontextfönster och modellförvirringsattacker
- **Microsoft AI-säkerhetslösningar**: Omfattande täckning av Microsofts säkerhetsekosystem
  - AI Prompt Shields med avancerad detektion, spotlighting och delimitertekniker
  - Azure Content Safety integrationsmönster
  - GitHub Advanced Security för skydd av försörjningskedjan
- **Avancerad hotbekämpning**: Detaljerade säkerhetskontroller för
  - Sessionskapning med MCP-specifika attackscenarier och kryptografiska sessions-ID-krav
  - Förvirrade ställföreträdarproblem i MCP-proxyscenarier med explicita samtyckeskrav
  - Tokensäkerhetsproblem med obligatoriska valideringskontroller
- **Försörjningskedjesäkerhet**: Utökad täckning av AI-försörjningskedjan inklusive grundmodeller, embeddings-tjänster, kontextleverantörer och tredjeparts-
- Ersatte `<details>`-taggar med ett mer tillgängligt tabellbaserat format
- Skapade alternativa layoutalternativ i den nya mappen "alternative_layouts"
- Lade till exempel på kortbaserad, flikbaserad och dragspelsbaserad navigering
- Uppdaterade avsnittet om repository-struktur för att inkludera alla senaste filer
- Förbättrade avsnittet "Hur man använder denna läroplan" med tydliga rekommendationer
- Uppdaterade MCP-specifikationslänkar för att peka på korrekta URL:er
- Lade till avsnittet Context Engineering (5.14) i läroplansstrukturen

### Uppdateringar av studieguide
- Fullständigt reviderat studieguiden för att stämma överens med den aktuella repository-strukturen
- Lade till nya avsnitt för MCP-klienter och verktyg, samt populära MCP-servrar
- Uppdaterade den visuella läroplansöversikten för att korrekt återspegla alla ämnen
- Förbättrade beskrivningar av avancerade ämnen för att täcka alla specialiserade områden
- Uppdaterade avsnittet om fallstudier för att återspegla faktiska exempel
- Lade till denna omfattande ändringslogg

### Gemenskapsbidrag (06-CommunityContributions/)
- Lade till detaljerad information om MCP-servrar för bildgenerering
- Lade till omfattande avsnitt om att använda Claude i VSCode
- Lade till instruktioner för installation och användning av Cline terminalklient
- Uppdaterade MCP-klientavsnittet för att inkludera alla populära klientalternativ
- Förbättrade bidragsexempel med mer korrekta kodexempel

### Avancerade ämnen (05-AdvancedTopics/)
- Organiserade alla specialiserade ämnesmappar med konsekvent namngivning
- Lade till material och exempel för Context Engineering
- Lade till dokumentation för Foundry-agentintegration
- Förbättrade dokumentation för säkerhetsintegration med Entra ID

## 11 juni 2025

### Initial skapelse
- Släppte första versionen av MCP för nybörjare-läroplanen
- Skapade grundstruktur för alla 10 huvudavsnitt
- Implementerade visuell läroplansöversikt för navigering
- Lade till initiala exempelprojekt i flera programmeringsspråk

### Komma igång (03-GettingStarted/)
- Skapade första serverimplementeringsexempel
- Lade till vägledning för klientutveckling
- Inkluderade instruktioner för LLM-klientintegration
- Lade till dokumentation för VS Code-integration
- Implementerade exempel på Server-Sent Events (SSE)-servrar

### Grundläggande koncept (01-CoreConcepts/)
- Lade till detaljerad förklaring av klient-server-arkitektur
- Skapade dokumentation om nyckelkomponenter i protokollet
- Dokumenterade meddelandemönster i MCP

## 23 maj 2025

### Repository-struktur
- Initierade repository med grundläggande mappstruktur
- Skapade README-filer för varje större avsnitt
- Satt upp översättningsinfrastruktur
- Lade till bildresurser och diagram

### Dokumentation
- Skapade initial README.md med översikt över läroplanen
- Lade till CODE_OF_CONDUCT.md och SECURITY.md
- Satt upp SUPPORT.md med vägledning för att få hjälp
- Skapade preliminär struktur för studieguide

## 15 april 2025

### Planering och ramverk
- Initial planering för MCP för nybörjare-läroplanen
- Definierade lärandemål och målgrupp
- Skisserade 10-avsnittsstrukturen för läroplanen
- Utvecklade konceptuellt ramverk för exempel och fallstudier
- Skapade initiala prototypexempel för nyckelkoncept

---

