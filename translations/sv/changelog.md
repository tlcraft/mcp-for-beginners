<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T14:42:24+00:00",
  "source_file": "changelog.md",
  "language_code": "sv"
}
-->
# Ändringslogg: MCP för Nybörjare Curriculum

Detta dokument fungerar som en redogörelse för alla betydande ändringar som gjorts i Model Context Protocol (MCP) för Nybörjare curriculum. Ändringar dokumenteras i omvänd kronologisk ordning (nyaste ändringar först).

## 18 augusti 2025

### Omfattande Uppdatering av Dokumentation - MCP 2025-06-18 Standarder

#### MCP Säkerhetsbästa Praxis (02-Security/) - Komplett Modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Fullständig omskrivning i linje med MCP-specifikationen 2025-06-18
  - **Obligatoriska Krav**: Lagt till explicita MÅSTE/MÅSTE INTE-krav från den officiella specifikationen med tydliga visuella indikatorer
  - **12 Kärnsäkerhetsprinciper**: Omstrukturerad från en lista med 15 punkter till omfattande säkerhetsdomäner
    - Tokensäkerhet & Autentisering med integration av externa identitetsleverantörer
    - Sessionshantering & Transportskydd med kryptografiska krav
    - AI-specifik hotbekämpning med Microsoft Prompt Shields-integration
    - Åtkomstkontroll & Behörigheter med principen om minsta privilegium
    - Innehållssäkerhet & Övervakning med Azure Content Safety-integration
    - Leverantörskedjans säkerhet med omfattande komponentverifiering
    - OAuth-säkerhet & Förebyggande av förvirrade proxyattacker med PKCE-implementering
    - Incidenthantering & Återhämtning med automatiserade funktioner
    - Efterlevnad & Styrning med regulatorisk anpassning
    - Avancerade säkerhetskontroller med zero trust-arkitektur
    - Microsofts säkerhetsekosystemintegration med omfattande lösningar
    - Kontinuerlig säkerhetsutveckling med adaptiva praxis
  - **Microsoft Säkerhetslösningar**: Förbättrad integrationsvägledning för Prompt Shields, Azure Content Safety, Entra ID och GitHub Advanced Security
  - **Implementeringsresurser**: Kategoriserade omfattande resurslänkar efter Officiell MCP-dokumentation, Microsoft Säkerhetslösningar, Säkerhetsstandarder och Implementeringsguider

#### Avancerade Säkerhetskontroller (02-Security/) - Företagsimplementering
- **MCP-SECURITY-CONTROLS-2025.md**: Fullständig omarbetning med företagsklassad säkerhetsram
  - **9 Omfattande Säkerhetsdomäner**: Utökad från grundläggande kontroller till detaljerad företagsram
    - Avancerad Autentisering & Auktorisering med Microsoft Entra ID-integration
    - Tokensäkerhet & Anti-Passthrough-kontroller med omfattande validering
    - Sessionssäkerhetskontroller med kapningsförebyggande
    - AI-specifika säkerhetskontroller med skydd mot promptinjektion och verktygsförgiftning
    - Förebyggande av förvirrade proxyattacker med OAuth-proxy-säkerhet
    - Verktygsutförandesäkerhet med sandboxing och isolering
    - Säkerhetskontroller för leverantörskedjan med beroendeverifiering
    - Övervaknings- & Detektionskontroller med SIEM-integration
    - Incidenthantering & Återhämtning med automatiserade funktioner
  - **Implementeringsexempel**: Lagt till detaljerade YAML-konfigurationsblock och kodexempel
  - **Microsoft Lösningsintegration**: Omfattande täckning av Azure säkerhetstjänster, GitHub Advanced Security och företagsidentitetshantering

#### Avancerade Ämnen Säkerhet (05-AdvancedTopics/mcp-security/) - Produktionsklar Implementering
- **README.md**: Fullständig omskrivning för företagsimplementering av säkerhet
  - **Nuvarande Specifikationsanpassning**: Uppdaterad till MCP-specifikationen 2025-06-18 med obligatoriska säkerhetskrav
  - **Förbättrad Autentisering**: Microsoft Entra ID-integration med omfattande .NET- och Java Spring Security-exempel
  - **AI Säkerhetsintegration**: Microsoft Prompt Shields och Azure Content Safety-implementering med detaljerade Python-exempel
  - **Avancerad Hotbekämpning**: Omfattande implementeringsexempel för
    - Förebyggande av förvirrade proxyattacker med PKCE och användarsamtyckesvalidering
    - Förebyggande av token-passthrough med publikvalidering och säker tokenhantering
    - Förebyggande av sessionskapning med kryptografisk bindning och beteendeanalys
  - **Företagsintegration av Säkerhet**: Azure Application Insights-övervakning, hotdetektionspipelines och säkerhet för leverantörskedjan
  - **Implementeringschecklista**: Tydliga obligatoriska kontra rekommenderade säkerhetskontroller med fördelar från Microsofts säkerhetsekosystem

### Dokumentationskvalitet & Standardanpassning
- **Specifikationsreferenser**: Uppdaterade alla referenser till nuvarande MCP-specifikation 2025-06-18
- **Microsoft Säkerhetsekosystem**: Förbättrad integrationsvägledning genom hela säkerhetsdokumentationen
- **Praktisk Implementering**: Lagt till detaljerade kodexempel i .NET, Java och Python med företagsmönster
- **Resursorganisation**: Omfattande kategorisering av officiell dokumentation, säkerhetsstandarder och implementeringsguider
- **Visuella Indikatorer**: Tydlig markering av obligatoriska krav kontra rekommenderade praxis

#### Kärnkoncept (01-CoreConcepts/) - Komplett Modernisering
- **Protokollversionsuppdatering**: Uppdaterad för att referera till nuvarande MCP-specifikation 2025-06-18 med datum-baserad versionering (YYYY-MM-DD-format)
- **Arkitekturförfining**: Förbättrade beskrivningar av Hosts, Clients och Servers för att återspegla nuvarande MCP-arkitekturmönster
  - Hosts nu tydligt definierade som AI-applikationer som koordinerar flera MCP-klientanslutningar
  - Klienter beskrivna som protokollanslutningar som upprätthåller en-till-en serverrelationer
  - Servrar förbättrade med lokala kontra fjärrdistributionsscenarier
- **Primärstrukturering**: Fullständig omarbetning av server- och klientprimitiver
  - Serverprimitiver: Resurser (datakällor), Prompts (mallar), Verktyg (exekverbara funktioner) med detaljerade förklaringar och exempel
  - Klientprimitiver: Sampling (LLM-kompletteringar), Elicitation (användarinmatning), Logging (felsökning/övervakning)
  - Uppdaterad med nuvarande upptäckt (`*/list`), hämtning (`*/get`) och exekvering (`*/call`) metodmönster
- **Protokollarkitektur**: Introducerade två-lagers arkitekturmodell
  - Dataskikt: JSON-RPC 2.0-grund med livscykelhantering och primitiv
  - Transportskikt: STDIO (lokalt) och Streamable HTTP med SSE (fjärr) transportmekanismer
- **Säkerhetsramverk**: Omfattande säkerhetsprinciper inklusive explicit användarsamtycke, dataintegritetsskydd, verktygsutförandesäkerhet och transportskiktssäkerhet
- **Kommunikationsmönster**: Uppdaterade protokollmeddelanden för att visa initialisering, upptäckt, exekvering och notifieringsflöden
- **Kodexempel**: Uppdaterade flerspråkiga exempel (.NET, Java, Python, JavaScript) för att återspegla nuvarande MCP SDK-mönster

#### Säkerhet (02-Security/) - Omfattande Säkerhetsöversyn  
- **Standardanpassning**: Fullständig anpassning till MCP-specifikationen 2025-06-18 säkerhetskrav
- **Autentiseringens Utveckling**: Dokumenterad utveckling från anpassade OAuth-servrar till delegation av externa identitetsleverantörer (Microsoft Entra ID)
- **AI-specifik Hotanalys**: Förbättrad täckning av moderna AI-attackvektorer
  - Detaljerade scenarier för promptinjektion med verkliga exempel
  - Verktygsförgiftningsmekanismer och "rug pull"-attackmönster
  - Kontextfönsterförgiftning och modellförvirringsattacker
- **Microsoft AI Säkerhetslösningar**: Omfattande täckning av Microsofts säkerhetsekosystem
  - AI Prompt Shields med avancerad detektion, spotlighting och avgränsningstekniker
  - Azure Content Safety-integrationsmönster
  - GitHub Advanced Security för skydd av leverantörskedjan
- **Avancerad Hotbekämpning**: Detaljerade säkerhetskontroller för
  - Sessionskapning med MCP-specifika attackscenarier och kryptografiska sessions-ID-krav
  - Förvirrade proxyproblem i MCP-proxyscenarier med explicita samtyckeskrav
  - Token-passthrough-sårbarheter med obligatoriska valideringskontroller
- **Leverantörskedjans Säkerhet**: Utökad täckning av AI-leverantörskedjan inklusive grundmodeller, embeddings-tjänster, kontextleverantörer och tredjeparts-API:er
- **Grundläggande Säkerhet**: Förbättrad integration med företagsmönster för säkerhet inklusive zero trust-arkitektur och Microsofts säkerhetsekosystem
- **Resursorganisation**: Kategoriserade omfattande resurslänkar efter typ (Officiella Dokument, Standarder, Forskning, Microsoft Lösningar, Implementeringsguider)

### Förbättringar av Dokumentationskvalitet
- **Strukturerade Lärandemål**: Förbättrade lärandemål med specifika, handlingsbara resultat 
- **Korsreferenser**: Lagt till länkar mellan relaterade säkerhets- och kärnkonceptämnen
- **Aktuell Information**: Uppdaterade alla datumreferenser och specifikationslänkar till nuvarande standarder
- **Implementeringsvägledning**: Lagt till specifika, handlingsbara implementeringsriktlinjer genom båda sektionerna

## 16 juli 2025

### README och Navigeringsförbättringar
- Fullständigt omdesignad curriculum-navigering i README.md
- Ersatte `<details>`-taggar med mer tillgängligt tabellbaserat format
- Skapade alternativa layoutalternativ i den nya "alternative_layouts"-mappen
- Lagt till kortbaserade, flikbaserade och dragspelsbaserade navigeringsexempel
- Uppdaterade avsnittet om repository-struktur för att inkludera alla senaste filer
- Förbättrade avsnittet "Hur man använder detta curriculum" med tydliga rekommendationer
- Uppdaterade MCP-specifikationslänkar för att peka på korrekta URL:er
- Lagt till avsnittet Context Engineering (5.14) i curriculum-strukturen

### Uppdateringar av Studieguiden
- Fullständigt reviderad studieguiden för att anpassas till nuvarande repository-struktur
- Lagt till nya avsnitt för MCP-klienter och verktyg, samt populära MCP-servrar
- Uppdaterade den visuella curriculum-kartan för att korrekt återspegla alla ämnen
- Förbättrade beskrivningar av avancerade ämnen för att täcka alla specialiserade områden
- Uppdaterade avsnittet Fallstudier för att återspegla faktiska exempel
- Lagt till denna omfattande ändringslogg

### Community Contributions (06-CommunityContributions/)
- Lagt till detaljerad information om MCP-servrar för bildgenerering
- Lagt till omfattande avsnitt om att använda Claude i VSCode
- Lagt till instruktioner för Cline terminalklientens installation och användning
- Uppdaterade MCP-klientavsnittet för att inkludera alla populära klientalternativ
- Förbättrade bidragsexempel med mer korrekta kodexempel

### Avancerade Ämnen (05-AdvancedTopics/)
- Organiserade alla specialiserade ämnesmappar med konsekvent namngivning
- Lagt till material och exempel för kontextteknik
- Lagt till dokumentation för Foundry-agentintegration
- Förbättrade dokumentationen för Entra ID-säkerhetsintegration

## 11 juni 2025

### Initial Skapelse
- Släppt första versionen av MCP för Nybörjare curriculum
- Skapade grundläggande struktur för alla 10 huvudsektioner
- Implementerade Visuell Curriculum-karta för navigering
- Lagt till initiala exempelprojekt i flera programmeringsspråk

### Komma Igång (03-GettingStarted/)
- Skapade första serverimplementeringsexempel
- Lagt till vägledning för klientutveckling
- Inkluderade instruktioner för LLM-klientintegration
- Lagt till dokumentation för VS Code-integration
- Implementerade Server-Sent Events (SSE) serverexempel

### Kärnkoncept (01-CoreConcepts/)
- Lagt till detaljerad förklaring av klient-serverarkitektur
- Skapade dokumentation om nyckelprotokollkomponenter
- Dokumenterade meddelandemönster i MCP

## 23 maj 2025

### Repository-struktur
- Initierade repository med grundläggande mappstruktur
- Skapade README-filer för varje större sektion
- Satt upp översättningsinfrastruktur
- Lagt till bildtillgångar och diagram

### Dokumentation
- Skapade initial README.md med curriculum-översikt
- Lagt till CODE_OF_CONDUCT.md och SECURITY.md
- Satt upp SUPPORT.md med vägledning för att få hjälp
- Skapade preliminär struktur för studieguiden

## 15 april 2025

### Planering och Ramverk
- Initial planering för MCP för Nybörjare curriculum
- Definierade lärandemål och målgrupp
- Skisserade 10-sektionsstrukturen för curriculum
- Utvecklade konceptuellt ramverk för exempel och fallstudier
- Skapade initiala prototypexempel för nyckelkoncept

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen notera att automatiska översättningar kan innehålla fel eller felaktigheter. Det ursprungliga dokumentet på dess originalspråk bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.