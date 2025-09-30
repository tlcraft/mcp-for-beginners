<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T17:45:26+00:00",
  "source_file": "changelog.md",
  "language_code": "sv"
}
-->
# Ändringslogg: MCP för Nybörjare Curriculum

Detta dokument fungerar som en redogörelse för alla betydande ändringar som gjorts i Model Context Protocol (MCP) för Nybörjare curriculum. Ändringar dokumenteras i omvänd kronologisk ordning (nyaste ändringar först).

## 29 september 2025

### MCP Server Database Integration Labs - Omfattande Praktisk Lärväg

#### 11-MCPServerHandsOnLabs - Ny Komplett Curriculum för Databasintegration
- **Komplett 13-labs lärväg**: Lagt till en omfattande praktisk curriculum för att bygga produktionsklara MCP-servrar med PostgreSQL-databasintegration
  - **Implementering i verkligheten**: Zava Retail-analysfall som demonstrerar mönster på företagsnivå
  - **Strukturerad lärprogression**:
    - **Labs 00-03: Grunder** - Introduktion, Kärnarkitektur, Säkerhet & Multi-Tenancy, Miljöinställning
    - **Labs 04-06: Bygga MCP-servern** - Databasedesign & Schema, MCP-serverimplementering, Verktygsutveckling  
    - **Labs 07-09: Avancerade Funktioner** - Semantisk sökintegration, Testning & Felsökning, VS Code-integration
    - **Labs 10-12: Produktion & Bästa Praxis** - Implementeringsstrategier, Övervakning & Observabilitet, Optimering & Bästa Praxis
  - **Företagsteknologier**: FastMCP-ramverk, PostgreSQL med pgvector, Azure OpenAI-embeddingar, Azure Container Apps, Application Insights
  - **Avancerade Funktioner**: Row Level Security (RLS), semantisk sökning, multi-tenant dataåtkomst, vektorembeddingar, realtidsövervakning

#### Terminologistandardisering - Omvandling från Modul till Lab
- **Omfattande Dokumentationsuppdatering**: Systematiskt uppdaterat alla README-filer i 11-MCPServerHandsOnLabs för att använda "Lab"-terminologi istället för "Modul"
  - **Avsnittsrubriker**: Uppdaterat "Vad denna modul täcker" till "Vad detta lab täcker" i alla 13 labs
  - **Innehållsbeskrivning**: Ändrat "Denna modul tillhandahåller..." till "Detta lab tillhandahåller..." i hela dokumentationen
  - **Lärandemål**: Uppdaterat "I slutet av denna modul..." till "I slutet av detta lab..."
  - **Navigeringslänkar**: Konverterat alla "Modul XX:" referenser till "Lab XX:" i korsreferenser och navigering
  - **Slutföringsspårning**: Uppdaterat "Efter att ha slutfört denna modul..." till "Efter att ha slutfört detta lab..."
  - **Bevarade tekniska referenser**: Bibehållit Python-modulreferenser i konfigurationsfiler (t.ex., `"module": "mcp_server.main"`)

#### Förbättring av Studieguide (study_guide.md)
- **Visuell Curriculumkarta**: Lagt till ny "11. Database Integration Labs"-sektion med omfattande labstrukturvisualisering
- **Repositorystruktur**: Uppdaterat från tio till elva huvudsektioner med detaljerad beskrivning av 11-MCPServerHandsOnLabs
- **Vägledning för lärväg**: Förbättrade navigeringsinstruktioner för att täcka sektioner 00-11
- **Teknologitäckning**: Lagt till detaljer om FastMCP, PostgreSQL och Azure-tjänsters integration
- **Lärandemål**: Betoning på utveckling av produktionsklara servrar, databasintegrationsmönster och företagsäkerhet

#### Förbättring av Huvud-README-struktur
- **Lab-baserad terminologi**: Uppdaterat huvud-README.md i 11-MCPServerHandsOnLabs för att konsekvent använda "Lab"-struktur
- **Organisering av lärväg**: Tydlig progression från grundläggande koncept till avancerad implementering och produktionsimplementering
- **Fokus på verkligheten**: Betoning på praktiskt, hands-on lärande med mönster och teknologier på företagsnivå

### Förbättringar av Dokumentationskvalitet & Konsistens
- **Betoning på praktiskt lärande**: Förstärkt praktisk, lab-baserad metodik i hela dokumentationen
- **Fokus på företagsmönster**: Markerade produktionsklara implementeringar och säkerhetsöverväganden på företagsnivå
- **Teknologiintegration**: Omfattande täckning av moderna Azure-tjänster och AI-integrationsmönster
- **Lärprogression**: Tydlig, strukturerad väg från grundläggande koncept till produktionsimplementering

## 26 september 2025

### Förbättring av Fallstudier - GitHub MCP Registry Integration

#### Fallstudier (09-CaseStudy/) - Fokus på Ekosystemutveckling
- **README.md**: Större expansion med omfattande GitHub MCP Registry-fallstudie
  - **GitHub MCP Registry Fallstudie**: Ny omfattande fallstudie som undersöker GitHubs MCP Registry-lansering i september 2025
    - **Problemanalys**: Detaljerad undersökning av fragmenterade MCP-serverupptäckts- och implementeringsutmaningar
    - **Lösningsarkitektur**: GitHubs centraliserade registry-ansats med installation i VS Code med ett klick
    - **Affärspåverkan**: Mätbara förbättringar i utvecklarintroduktion och produktivitet
    - **Strategiskt värde**: Fokus på modulär agentimplementering och interoperabilitet mellan verktyg
    - **Ekosystemutveckling**: Positionering som grundläggande plattform för agentisk integration
  - **Förbättrad struktur för fallstudier**: Uppdaterat alla sju fallstudier med konsekvent formatering och omfattande beskrivningar
    - Azure AI Travel Agents: Fokus på multi-agent orkestrering
    - Azure DevOps Integration: Fokus på arbetsflödesautomatisering
    - Realtidsdokumentationshämtning: Python-konsolklientimplementering
    - Interaktiv studieplangenerator: Chainlit-konverserande webbapp
    - Dokumentation i redigeraren: VS Code och GitHub Copilot-integration
    - Azure API Management: Mönster för företags API-integration
    - GitHub MCP Registry: Ekosystemutveckling och communityplattform
  - **Omfattande slutsats**: Omskriven slutsatssektion som lyfter fram sju fallstudier som spänner över flera MCP-implementeringsdimensioner
    - Företagsintegration, Multi-Agent Orkestrering, Utvecklarproduktivitet
    - Ekosystemutveckling, Kategorisering av utbildningsapplikationer
    - Förbättrade insikter i arkitekturmönster, implementeringsstrategier och bästa praxis
    - Betoning på MCP som ett moget, produktionsklart protokoll

#### Uppdateringar av Studieguide (study_guide.md)
- **Visuell Curriculumkarta**: Uppdaterad mindmap för att inkludera GitHub MCP Registry i sektionen för Fallstudier
- **Beskrivning av Fallstudier**: Förbättrad från generiska beskrivningar till detaljerad uppdelning av sju omfattande fallstudier
- **Repositorystruktur**: Uppdaterad sektion 10 för att återspegla omfattande täckning av fallstudier med specifika implementeringsdetaljer
- **Integration av Ändringslogg**: Lagt till 26 september 2025-post som dokumenterar tillägget av GitHub MCP Registry och förbättringar av fallstudier
- **Datumuppdateringar**: Uppdaterat fotnotstidsstämpel för att återspegla senaste revisionen (26 september 2025)

### Förbättringar av Dokumentationskvalitet
- **Förbättrad konsistens**: Standardiserad formatering och struktur för fallstudier över alla sju exempel
- **Omfattande täckning**: Fallstudier täcker nu företags-, utvecklarproduktivitet- och ekosystemutvecklingsscenarier
- **Strategisk positionering**: Förbättrat fokus på MCP som grundläggande plattform för agentiska systemimplementeringar
- **Resursintegration**: Uppdaterade ytterligare resurser för att inkludera GitHub MCP Registry-länk

## 15 september 2025

### Utökning av Avancerade Ämnen - Anpassade Transporter & Kontextteknik

#### MCP Anpassade Transporter (05-AdvancedTopics/mcp-transport/) - Ny Avancerad Implementeringsguide
- **README.md**: Komplett implementeringsguide för anpassade MCP-transportmekanismer
  - **Azure Event Grid Transport**: Omfattande serverlös händelsedriven transportimplementering
    - Exempel i C#, TypeScript och Python med Azure Functions-integration
    - Mönster för händelsedriven arkitektur för skalbara MCP-lösningar
    - Webhook-mottagare och push-baserad meddelandehantering
  - **Azure Event Hubs Transport**: Implementering av höggenomströmningsströmningstransport
    - Realtidsströmning för scenarier med låg latens
    - Partitionsstrategier och kontrollpunkthantering
    - Meddelandebatchning och prestandaoptimering
  - **Företagsintegrationsmönster**: Produktionsklara arkitekturexempel
    - Distribuerad MCP-bearbetning över flera Azure Functions
    - Hybridtransportarkitekturer som kombinerar flera transporttyper
    - Meddelandedurabilitet, tillförlitlighet och felhanteringsstrategier
  - **Säkerhet & Övervakning**: Azure Key Vault-integration och observabilitetsmönster
    - Autentisering med hanterad identitet och åtkomst med minsta privilegier
    - Application Insights-telemetri och prestandaövervakning
    - Circuit breakers och felhantering
  - **Testningsramverk**: Omfattande teststrategier för anpassade transporter
    - Enhetstestning med testdubletter och mockningsramverk
    - Integrationstestning med Azure Test Containers
    - Prestanda- och belastningstestningsöverväganden

#### Kontextteknik (05-AdvancedTopics/mcp-contextengineering/) - Framväxande AI-disciplin
- **README.md**: Omfattande utforskning av kontextteknik som ett framväxande område
  - **Kärnprinciper**: Komplett kontextdelning, medvetenhet om beslutsfattande och hantering av kontextfönster
  - **MCP-protokollanpassning**: Hur MCP-designen adresserar utmaningar inom kontextteknik
    - Begränsningar i kontextfönster och progressiva laddningsstrategier
    - Relevansbestämning och dynamisk kontexthämtning
    - Multimodal kontexthantering och säkerhetsöverväganden
  - **Implementeringsmetoder**: Enkelttrådade vs. multi-agent arkitekturer
    - Kontextchunkning och prioriteringstekniker
    - Progressiv kontextladdning och komprimeringsstrategier
    - Lagerbaserade kontextmetoder och optimering av hämtning
  - **Mätramsverk**: Framväxande metrik för utvärdering av kontexteffektivitet
    - Effektivitet, prestanda, kvalitet och användarupplevelseöverväganden
    - Experimentella metoder för kontextoptimering
    - Felanalys och förbättringsmetodologier

#### Uppdateringar av Curriculum-navigering (README.md)
- **Förbättrad modulstruktur**: Uppdaterat curriculumtabellen för att inkludera nya avancerade ämnen
  - Lagt till Kontextteknik (5.14) och Anpassad Transport (5.15)
  - Konsekvent formatering och navigeringslänkar över alla moduler
  - Uppdaterade beskrivningar för att återspegla aktuellt innehåll

### Förbättringar av Katalogstruktur
- **Standardisering av namn**: Bytt namn från "mcp transport" till "mcp-transport" för att vara konsekvent med andra avancerade ämnesmappar
- **Innehållsorganisation**: Alla 05-AdvancedTopics-mappar följer nu konsekvent namngivningsmönster (mcp-[ämne])

### Förbättringar av Dokumentationskvalitet
- **Anpassning till MCP-specifikation**: Allt nytt innehåll refererar till aktuell MCP-specifikation 2025-06-18
- **Exempel på flera språk**: Omfattande kodexempel i C#, TypeScript och Python
- **Fokus på företag**: Produktionsklara mönster och Azure-molnintegration genomgående
- **Visuell dokumentation**: Mermaid-diagram för arkitektur och flödesvisualisering

## 18 augusti 2025

### Omfattande Dokumentationsuppdatering - MCP 2025-06-18 Standarder

#### MCP Säkerhetsbästa praxis (02-Security/) - Komplett Modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Komplett omskrivning anpassad till MCP-specifikation 2025-06-18
  - **Obligatoriska krav**: Lagt till explicita MÅSTE/MÅSTE INTE-krav från officiell specifikation med tydliga visuella indikatorer
  - **12 Kärnsäkerhetspraxis**: Omstrukturerad från 15-punktslista till omfattande säkerhetsdomäner
    - Tokensäkerhet & Autentisering med integration av externa identitetsleverantörer
    - Sessionshantering & Transportsäkerhet med kryptografiska krav
    - AI-specifik hotbekämpning med Microsoft Prompt Shields-integration
    - Åtkomstkontroll & Behörigheter med principen om minsta privilegier
    - Innehållssäkerhet & Övervakning med Azure Content Safety-integration
    - Leverantörskedjesäkerhet med omfattande komponentverifiering
    - OAuth-säkerhet & Förebyggande av förvirrade proxyattacker med PKCE-implementering
    - Incidenthantering & Återhämtning med automatiserade kapaciteter
    - Efterlevnad & Styrning med regulatorisk anpassning
    - Avancerade säkerhetskontroller med zero trust-arkitektur
    - Microsofts säkerhetsekosystemintegration med omfattande lösningar
    - Kontinuerlig säkerhetsevolution med adaptiva praxis
  - **Microsofts säkerhetslösningar**: Förbättrad integrationsvägledning för Prompt Shields, Azure Content Safety, Entra ID och GitHub Advanced Security
  - **Implementeringsresurser**: Kategoriserade omfattande resurslänkar efter Officiell MCP-dokumentation, Microsofts säkerhetslösningar, Säkerhetsstandarder och Implementeringsguider

#### Avancerade Säkerhetskontroller (02-Security/) - Företagsimplementering
- **MCP-SECURITY-CONTROLS-2025.md**: Komplett översyn med företagsklassad säkerhetsram
  - **9 Omfattande Säkerhetsdomäner**: Utökad från grundläggande kontroller till detaljerad företagsram
    - Avancerad Autentisering & Auktorisering med Microsoft Entra ID-integration
    - Tokensäkerhet & Anti-Passthrough-kontroller med omfattande validering
    - Sessionssäkerhetskontroller med kapningsförebyggande
    - AI-specifika säkerhetskontroller med skydd mot promptinjektion och verktygsförgiftning
    - Förebyggande av förvirrade proxyattacker med OAuth-proxysäkerhet
    - Verktygsutförandesäkerhet med sandboxing och isolering
    - Leverantörskedjesäkerhetskontroller med beroendeverifiering
    - Övervaknings- & Detektionskontroller med SIEM-integration
    - Incidenthantering & Återhämtning med automatiserade kapaciteter
  - **Implementeringsexempel**: Lagt till detaljerade YAML-konfigurationsblock och kodexempel
  - **Microsofts Lösningsintegration**: Omfattande täckning av Azure-säkerhetstjänster, GitHub Advanced Security och företagsidentitetshantering

#### Avancerade Ämnen Säkerhet (05-AdvancedTopics/mcp-security/) - Produktionsklar Implementering
- **README.md**: Komplett omskrivning för företagsklassad säkerhetsimplementering
  - **Anpassning till aktuell specifikation**: Uppdaterad till MCP-specifikation 2025-06-18 med obligatoriska säkerhetskrav
  - **Förbättrad autentisering**: Microsoft Entra ID-integration med omfattande .NET- och Java Spring Security-exempel
  - **AI-säkerhetsintegration**: Microsoft Prompt Shields och Azure Content Safety-implementering med detaljerade Python-exempel
  - **Avancerad hotbekämpning**: Omfattande implementeringsexempel för
    - Förebyggande av förvirrade proxyattacker med PKCE och användarsamtyckesvalidering
    - Förebyggande av token-passthrough med publikvalidering och säker tokenhantering
    - Förebyggande av sessionskapning med kryptografisk bindning och beteendeanalys
  - **Företagsklassad säkerhetsintegration**: Azure Application Insights-övervakning, hotdetektionspipelines och leverantörskedjesäkerhet
  - **Implementeringschecklista**: Tydliga obligatoriska
- **Visuella indikatorer**: Tydlig markering av obligatoriska krav kontra rekommenderade metoder

#### Grundläggande koncept (01-CoreConcepts/) - Fullständig modernisering
- **Uppdatering av protokollversion**: Uppdaterad för att referera till den aktuella MCP-specifikationen 2025-06-18 med datum-baserad versionering (formatet ÅÅÅÅ-MM-DD)
- **Förfining av arkitektur**: Förbättrade beskrivningar av värdar, klienter och servrar för att återspegla aktuella MCP-arkitekturmönster
  - Värdar definieras nu tydligt som AI-applikationer som koordinerar flera MCP-klientanslutningar
  - Klienter beskrivs som protokollanslutningar som upprätthåller en-till-en relationer med servrar
  - Servrar förbättras med scenarier för lokal kontra fjärrdistribution
- **Omstrukturering av primitiva element**: Fullständig översyn av server- och klientprimitiva element
  - Serverprimitiva element: Resurser (datakällor), Uppmaningar (mallar), Verktyg (exekverbara funktioner) med detaljerade förklaringar och exempel
  - Klientprimitiva element: Sampling (LLM-slutföranden), Elicitering (användarinmatning), Loggning (felsökning/övervakning)
  - Uppdaterad med aktuella upptäckts- (`*/list`), hämtnings- (`*/get`) och exekverings- (`*/call`) metodmönster
- **Protokollarkitektur**: Infört tvålagers arkitekturmodell
  - Dataskikt: JSON-RPC 2.0-grund med livscykelhantering och primitiva element
  - Transportskikt: STDIO (lokalt) och Streamable HTTP med SSE (fjärr) transportmekanismer
- **Säkerhetsramverk**: Omfattande säkerhetsprinciper inklusive explicit användarsamtycke, dataskydd, verktygssäkerhet och transportskiktssäkerhet
- **Kommunikationsmönster**: Uppdaterade protokollmeddelanden för att visa initiering, upptäckt, exekvering och notifieringsflöden
- **Kodexempel**: Uppdaterade flerspråkiga exempel (.NET, Java, Python, JavaScript) för att återspegla aktuella MCP SDK-mönster

#### Säkerhet (02-Security/) - Omfattande säkerhetsöversyn  
- **Standardanpassning**: Fullständig anpassning till MCP-specifikationen 2025-06-18 säkerhetskrav
- **Utveckling av autentisering**: Dokumenterad utveckling från anpassade OAuth-servrar till extern identitetsleverantörsdelegation (Microsoft Entra ID)
- **AI-specifik hotanalys**: Förbättrad täckning av moderna AI-attackvektorer
  - Detaljerade scenarier för promptinjektionsattacker med verkliga exempel
  - Mekanismer för verktygsförgiftning och "rug pull"-attackmönster
  - Förgiftning av kontextfönster och förvirringsattacker mot modeller
- **Microsoft AI-säkerhetslösningar**: Omfattande täckning av Microsofts säkerhetsekosystem
  - AI Prompt Shields med avancerad upptäckt, spotlightning och avgränsningstekniker
  - Azure Content Safety-integrationsmönster
  - GitHub Advanced Security för skydd av leveranskedjan
- **Avancerad hotreducering**: Detaljerade säkerhetskontroller för
  - Sessionskapning med MCP-specifika attackscenarier och krav på kryptografiska sessions-ID
  - Problem med förvirrade ställföreträdare i MCP-proxyscenarier med krav på explicit samtycke
  - Sårbarheter vid tokenpassering med obligatoriska valideringskontroller
- **Säkerhet i leveranskedjan**: Utökad täckning av AI-leveranskedjan inklusive grundmodeller, embeddingstjänster, kontextleverantörer och tredjeparts-API:er
- **Grundläggande säkerhet**: Förbättrad integration med företags säkerhetsmönster inklusive zero trust-arkitektur och Microsofts säkerhetsekosystem
- **Resursorganisation**: Kategoriserade omfattande resurslänkar efter typ (Officiella dokument, standarder, forskning, Microsoft-lösningar, implementeringsguider)

### Förbättringar av dokumentationskvalitet
- **Strukturerade lärandemål**: Förbättrade lärandemål med specifika, handlingsbara resultat
- **Korsreferenser**: Lagt till länkar mellan relaterade säkerhets- och grundläggande konceptämnen
- **Aktuell information**: Uppdaterade alla datumreferenser och specifikationslänkar till aktuella standarder
- **Implementeringsvägledning**: Lagt till specifika, handlingsbara implementeringsriktlinjer genom båda sektionerna

## 16 juli 2025

### Förbättringar av README och navigering
- Fullständigt omdesignad navigering i README.md för läroplanen
- Ersatte `<details>`-taggar med mer tillgängligt tabellbaserat format
- Skapade alternativa layoutalternativ i den nya mappen "alternative_layouts"
- Lagt till exempel på kortbaserad, flikbaserad och dragspelsbaserad navigering
- Uppdaterade avsnittet om mappstruktur för att inkludera alla senaste filer
- Förbättrade avsnittet "Hur man använder denna läroplan" med tydliga rekommendationer
- Uppdaterade MCP-specifikationslänkar för att peka på korrekta URL:er
- Lagt till avsnittet Context Engineering (5.14) till läroplansstrukturen

### Uppdateringar av studievägledning
- Fullständigt reviderad studievägledning för att anpassas till aktuell mappstruktur
- Lagt till nya avsnitt för MCP-klienter och verktyg, samt populära MCP-servrar
- Uppdaterade den visuella läroplansöversikten för att korrekt återspegla alla ämnen
- Förbättrade beskrivningar av avancerade ämnen för att täcka alla specialiserade områden
- Uppdaterade avsnittet Fallstudier för att återspegla verkliga exempel
- Lagt till denna omfattande ändringslogg

### Gemenskapsbidrag (06-CommunityContributions/)
- Lagt till detaljerad information om MCP-servrar för bildgenerering
- Lagt till omfattande avsnitt om att använda Claude i VSCode
- Lagt till instruktioner för installation och användning av Cline-terminalklient
- Uppdaterade MCP-klientavsnittet för att inkludera alla populära klientalternativ
- Förbättrade bidragsexempel med mer exakta kodexempel

### Avancerade ämnen (05-AdvancedTopics/)
- Organiserade alla specialiserade ämnesmappar med konsekvent namngivning
- Lagt till material och exempel för kontextteknik
- Lagt till dokumentation för Foundry-agentintegration
- Förbättrade dokumentation för Entra ID-säkerhetsintegration

## 11 juni 2025

### Initial skapelse
- Släppt första versionen av MCP för nybörjare-läroplanen
- Skapade grundläggande struktur för alla 10 huvudsektioner
- Implementerade visuell läroplansöversikt för navigering
- Lagt till initiala exempelprojekt i flera programmeringsspråk

### Komma igång (03-GettingStarted/)
- Skapade första serverimplementeringsexempel
- Lagt till vägledning för klientutveckling
- Inkluderade instruktioner för LLM-klientintegration
- Lagt till dokumentation för VS Code-integration
- Implementerade exempel på servrar med Server-Sent Events (SSE)

### Grundläggande koncept (01-CoreConcepts/)
- Lagt till detaljerad förklaring av klient-serverarkitektur
- Skapade dokumentation om nyckelkomponenter i protokollet
- Dokumenterade meddelandemönster i MCP

## 23 maj 2025

### Mappstruktur
- Initierade mappen med grundläggande mappstruktur
- Skapade README-filer för varje större sektion
- Ställde in översättningsinfrastruktur
- Lagt till bildresurser och diagram

### Dokumentation
- Skapade initial README.md med översikt över läroplanen
- Lagt till CODE_OF_CONDUCT.md och SECURITY.md
- Ställde in SUPPORT.md med vägledning för att få hjälp
- Skapade preliminär struktur för studievägledning

## 15 april 2025

### Planering och ramverk
- Initial planering för MCP för nybörjare-läroplanen
- Definierade lärandemål och målgrupp
- Skisserade 10-sektionsstruktur för läroplanen
- Utvecklade konceptuellt ramverk för exempel och fallstudier
- Skapade initiala prototypexempel för nyckelkoncept

---

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, bör det noteras att automatiska översättningar kan innehålla fel eller felaktigheter. Det ursprungliga dokumentet på dess originalspråk bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.