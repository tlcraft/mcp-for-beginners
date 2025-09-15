<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:15:41+00:00",
  "source_file": "changelog.md",
  "language_code": "sv"
}
-->
# Ändringslogg: MCP för Nybörjare Curriculum

Detta dokument fungerar som en redogörelse för alla betydande ändringar som gjorts i Model Context Protocol (MCP) för nybörjare. Ändringar dokumenteras i omvänd kronologisk ordning (nyaste ändringar först).

## 15 september 2025

### Utökning av Avancerade Ämnen - Anpassade Transporter & Kontextteknik

#### MCP Anpassade Transporter (05-AdvancedTopics/mcp-transport/) - Ny Avancerad Implementeringsguide
- **README.md**: Komplett implementeringsguide för anpassade MCP transportmekanismer
  - **Azure Event Grid Transport**: Omfattande serverlös händelsedriven transportimplementering
    - Exempel i C#, TypeScript och Python med Azure Functions-integration
    - Händelsedrivna arkitekturmodeller för skalbara MCP-lösningar
    - Webhook-mottagare och push-baserad meddelandehantering
  - **Azure Event Hubs Transport**: Implementering för hög genomströmning och strömmande transport
    - Realtidsströmning för scenarier med låg latens
    - Strategier för partitionering och hantering av kontrollpunkter
    - Meddelandebatchning och prestandaoptimering
  - **Enterprise Integration Patterns**: Produktionsklara arkitekturexempel
    - Distribuerad MCP-bearbetning över flera Azure Functions
    - Hybridtransportarkitekturer som kombinerar flera transporttyper
    - Meddelandedurabilitet, tillförlitlighet och strategier för felhantering
  - **Säkerhet & Övervakning**: Integration med Azure Key Vault och observabilitetsmönster
    - Autentisering med hanterad identitet och åtkomst med minsta privilegier
    - Telemetri med Application Insights och prestandaövervakning
    - Kretsbrytare och mönster för fel tolerans
  - **Testningsramverk**: Omfattande teststrategier för anpassade transporter
    - Enhetstester med testdubletter och mockning
    - Integrationstester med Azure Test Containers
    - Överväganden för prestanda- och belastningstester

#### Kontextteknik (05-AdvancedTopics/mcp-contextengineering/) - Framväxande AI-disciplin
- **README.md**: Omfattande utforskning av kontextteknik som ett framväxande område
  - **Kärnprinciper**: Fullständig kontextdelning, medvetenhet om beslutsfattande och hantering av kontextfönster
  - **MCP Protokollanpassning**: Hur MCP-designen adresserar utmaningar inom kontextteknik
    - Begränsningar i kontextfönster och strategier för progressiv laddning
    - Relevansbestämning och dynamisk kontexthämtning
    - Multimodal kontexthantering och säkerhetsöverväganden
  - **Implementeringsmetoder**: Enkelttrådade vs. multi-agent arkitekturer
    - Tekniker för kontextchunkning och prioritering
    - Progressiv kontextladdning och komprimeringsstrategier
    - Lagerbaserade kontextmetoder och optimering av hämtning
  - **Mätramsverk**: Framväxande metrik för utvärdering av kontexteffektivitet
    - Effektivitet, prestanda, kvalitet och användarupplevelse
    - Experimentella metoder för kontextoptimering
    - Felanalys och förbättringsmetoder

#### Uppdateringar av Curriculum-navigering (README.md)
- **Förbättrad Modulstruktur**: Uppdaterad curriculum-tabell för att inkludera nya avancerade ämnen
  - Lagt till Kontextteknik (5.14) och Anpassad Transport (5.15)
  - Konsekvent formatering och navigeringslänkar över alla moduler
  - Uppdaterade beskrivningar för att återspegla aktuellt innehåll

### Förbättringar av Katalogstruktur
- **Standardisering av Namngivning**: Bytt namn från "mcp transport" till "mcp-transport" för konsekvens med andra avancerade ämnesmappar
- **Innehållsorganisation**: Alla 05-AdvancedTopics-mappar följer nu ett konsekvent namngivningsmönster (mcp-[ämne])

### Förbättringar av Dokumentationskvalitet
- **Anpassning till MCP-specifikation**: Allt nytt innehåll hänvisar till aktuell MCP-specifikation 2025-06-18
- **Exempel på flera språk**: Omfattande kodexempel i C#, TypeScript och Python
- **Fokus på Företag**: Produktionsklara mönster och Azure-molnintegration genomgående
- **Visuell Dokumentation**: Mermaid-diagram för arkitektur och flödesvisualisering

## 18 augusti 2025

### Omfattande Dokumentationsuppdatering - MCP 2025-06-18 Standarder

#### MCP Säkerhetsbästa praxis (02-Security/) - Komplett Modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Komplett omskrivning anpassad till MCP-specifikation 2025-06-18
  - **Obligatoriska Krav**: Lagt till explicita MÅSTE/MÅSTE INTE krav från officiell specifikation med tydliga visuella indikatorer
  - **12 Kärnsäkerhetsmetoder**: Omstrukturerad från 15-punktslista till omfattande säkerhetsdomäner
    - Tokensäkerhet & Autentisering med integration av externa identitetsleverantörer
    - Sessionshantering & Transportsäkerhet med kryptografiska krav
    - AI-specifik hotskydd med Microsoft Prompt Shields-integration
    - Åtkomstkontroll & Behörigheter med principen om minsta privilegier
    - Innehållssäkerhet & Övervakning med Azure Content Safety-integration
    - Leverantörskedjesäkerhet med omfattande komponentverifiering
    - OAuth-säkerhet & Förvirrad Ställföreträdare-förebyggande med PKCE-implementering
    - Incidenthantering & Återhämtning med automatiserade funktioner
    - Efterlevnad & Styrning med regulatorisk anpassning
    - Avancerade Säkerhetskontroller med nolltillitsarkitektur
    - Microsoft Säkerhetsekosystemintegration med omfattande lösningar
    - Kontinuerlig Säkerhetsevolution med adaptiva metoder
  - **Microsoft Säkerhetslösningar**: Förbättrad integrationsvägledning för Prompt Shields, Azure Content Safety, Entra ID och GitHub Advanced Security
  - **Implementeringsresurser**: Kategoriserade omfattande resurslänkar efter Officiell MCP-dokumentation, Microsoft Säkerhetslösningar, Säkerhetsstandarder och Implementeringsguider

#### Avancerade Säkerhetskontroller (02-Security/) - Företagsimplementering
- **MCP-SECURITY-CONTROLS-2025.md**: Komplett översyn med företagsklassat säkerhetsramverk
  - **9 Omfattande Säkerhetsdomäner**: Utökad från grundläggande kontroller till detaljerat företagsramverk
    - Avancerad Autentisering & Auktorisering med Microsoft Entra ID-integration
    - Tokensäkerhet & Anti-Passthrough-kontroller med omfattande validering
    - Sessionssäkerhetskontroller med kapningsförebyggande
    - AI-specifika Säkerhetskontroller med promptinjektion och verktygsförgiftning
    - Förvirrad Ställföreträdare Attackförebyggande med OAuth proxy-säkerhet
    - Verktygsutförande Säkerhet med sandboxing och isolering
    - Leverantörskedjesäkerhetskontroller med beroendeverifiering
    - Övervaknings- & Detektionskontroller med SIEM-integration
    - Incidenthantering & Återhämtning med automatiserade funktioner
  - **Implementeringsexempel**: Lagt till detaljerade YAML-konfigurationsblock och kodexempel
  - **Microsoft Lösningsintegration**: Omfattande täckning av Azure säkerhetstjänster, GitHub Advanced Security och företagsidentitetshantering

#### Avancerade Ämnen Säkerhet (05-AdvancedTopics/mcp-security/) - Produktionsklar Implementering
- **README.md**: Komplett omskrivning för företagsimplementering av säkerhet
  - **Anpassning till Aktuell Specifikation**: Uppdaterad till MCP-specifikation 2025-06-18 med obligatoriska säkerhetskrav
  - **Förbättrad Autentisering**: Microsoft Entra ID-integration med omfattande .NET och Java Spring Security-exempel
  - **AI Säkerhetsintegration**: Microsoft Prompt Shields och Azure Content Safety-implementering med detaljerade Python-exempel
  - **Avancerad Hotreducering**: Omfattande implementeringsexempel för
    - Förvirrad Ställföreträdare Attackförebyggande med PKCE och användarsamtyckesvalidering
    - Token Passthrough Förebyggande med publikvalidering och säker tokenhantering
    - Sessionskapningsförebyggande med kryptografisk bindning och beteendeanalys
  - **Företags Säkerhetsintegration**: Övervakning med Azure Application Insights, hotdetekteringspipelines och leverantörskedjesäkerhet
  - **Implementeringschecklista**: Tydliga obligatoriska vs. rekommenderade säkerhetskontroller med fördelar från Microsofts säkerhetsekosystem

### Förbättringar av Dokumentationskvalitet & Standardanpassning
- **Specifikationsreferenser**: Uppdaterade alla referenser till aktuell MCP-specifikation 2025-06-18
- **Microsoft Säkerhetsekosystem**: Förbättrad integrationsvägledning genom hela säkerhetsdokumentationen
- **Praktisk Implementering**: Lagt till detaljerade kodexempel i .NET, Java och Python med företagsmönster
- **Resursorganisation**: Omfattande kategorisering av officiell dokumentation, säkerhetsstandarder och implementeringsguider
- **Visuella Indikatorer**: Tydlig markering av obligatoriska krav vs. rekommenderade metoder

#### Kärnkoncept (01-CoreConcepts/) - Komplett Modernisering
- **Protokollversionsuppdatering**: Uppdaterad för att referera till aktuell MCP-specifikation 2025-06-18 med datum-baserad versionering (YYYY-MM-DD-format)
- **Arkitekturförfining**: Förbättrade beskrivningar av Hosts, Clients och Servers för att återspegla aktuella MCP-arkitekturmodeller
  - Hosts nu tydligt definierade som AI-applikationer som koordinerar flera MCP-klientanslutningar
  - Klienter beskrivna som protokollanslutningar som upprätthåller en-till-en serverrelationer
  - Servrar förbättrade med lokala vs. fjärrdistributionsscenarier
- **Omstrukturering av Primitiver**: Komplett översyn av server- och klientprimitiver
  - Serverprimitiver: Resurser (datakällor), Prompts (mallar), Verktyg (exekverbara funktioner) med detaljerade förklaringar och exempel
  - Klientprimitiver: Sampling (LLM-kompletteringar), Elicitation (användarinmatning), Logging (felsökning/övervakning)
  - Uppdaterad med aktuella upptäckts- (`*/list`), hämtnings- (`*/get`) och exekverings- (`*/call`) metodmönster
- **Protokollarkitektur**: Introducerade två-lagers arkitekturmodell
  - Datalager: JSON-RPC 2.0 grund med livscykelhantering och primitiv
  - Transportlager: STDIO (lokalt) och Streamable HTTP med SSE (fjärr) transportmekanismer
- **Säkerhetsramverk**: Omfattande säkerhetsprinciper inklusive explicit användarsamtycke, dataintegritetsskydd, verktygsutförandesäkerhet och transportsäkerhet
- **Kommunikationsmönster**: Uppdaterade protokollmeddelanden för att visa initialisering, upptäckt, exekvering och notifieringsflöden
- **Kodexempel**: Uppdaterade flerspråkiga exempel (.NET, Java, Python, JavaScript) för att återspegla aktuella MCP SDK-mönster

#### Säkerhet (02-Security/) - Omfattande Säkerhetsöversyn  
- **Standardanpassning**: Fullständig anpassning till MCP-specifikation 2025-06-18 säkerhetskrav
- **Utveckling av Autentisering**: Dokumenterad utveckling från anpassade OAuth-servrar till delegation av externa identitetsleverantörer (Microsoft Entra ID)
- **AI-specifik Hotanalys**: Förbättrad täckning av moderna AI-attackvektorer
  - Detaljerade scenarier för promptinjektion med verkliga exempel
  - Verktygsförgiftning och "rug pull"-attackmönster
  - Förgiftning av kontextfönster och modellförvirringsattacker
- **Microsoft AI Säkerhetslösningar**: Omfattande täckning av Microsofts säkerhetsekosystem
  - AI Prompt Shields med avancerad detektion, spotlighting och delimitertekniker
  - Azure Content Safety integrationsmönster
  - GitHub Advanced Security för leverantörskedjeskydd
- **Avancerad Hotreducering**: Detaljerade säkerhetskontroller för
  - Sessionskapning med MCP-specifika attackscenarier och kryptografiska sessions-ID-krav
  - Förvirrade ställföreträdare problem i MCP proxy-scenarier med explicita samtyckeskrav
  - Token passthrough sårbarheter med obligatoriska valideringskontroller
- **Leverantörskedjesäkerhet**: Utökad AI-leverantörskedjetäckning inklusive grundmodeller, embeddings-tjänster, kontextleverantörer och tredjeparts-API:er
- **Grundläggande Säkerhet**: Förbättrad integration med företags säkerhetsmönster inklusive nolltillitsarkitektur och Microsofts säkerhetsekosystem
- **Resursorganisation**: Kategoriserade omfattande resurslänkar efter typ (Officiella Dokument, Standarder, Forskning, Microsoft Lösningar, Implementeringsguider)

### Förbättringar av Dokumentationskvalitet
- **Strukturerade Lärandemål**: Förbättrade lärandemål med specifika, handlingsbara resultat 
- **Korsreferenser**: Lagt till länkar mellan relaterade säkerhets- och kärnkonceptämnen
- **Aktuell Information**: Uppdaterade alla datumreferenser och specifikationslänkar till aktuella standarder
- **Implementeringsvägledning**: Lagt till specifika, handlingsbara implementeringsriktlinjer genom båda sektionerna

## 16 juli 2025

### Förbättringar av README och Navigering
- Fullständigt omdesignad curriculum-navigering i README.md
- Ersatte `<details>`-taggar med mer tillgängligt tabellbaserat format
- Skapade alternativa layoutalternativ i ny "alternative_layouts"-mapp
- Lagt till kortbaserade, flikbaserade och dragspelsbaserade navigeringsexempel
- Uppdaterade avsnittet om repository-struktur för att inkludera alla senaste filer
- Förbättrade avsnittet "Hur man använder detta curriculum" med tydliga rekommendationer
- Uppdaterade MCP-specifikationslänkar för att peka på korrekta URL:er
- Lagt till Kontextteknik-sektionen (5.14) i curriculum-strukturen

### Uppdateringar av Studievägledning
- Fullständigt reviderad studievägledning för att anpassa till aktuell repository-struktur
- Lagt till nya sektioner för MCP-klienter och verktyg, samt populära MCP-servrar
- Uppdaterade den visuella curriculum-kartan för att korrekt återspegla alla ämnen
- Förbättrade beskrivningar av avancerade ämnen för att täcka alla specialiserade områden
- Uppdaterade avsnittet om fallstudier för att återspegla faktiska exempel
- Lagt till denna omfattande ändringslogg

### Community Bidrag (06-CommunityContributions/)
- Lagt till detaljerad information om MCP-servrar för bildgenerering
- Lagt till omfattande avsnitt om att använda Claude i VSCode
- Lagt till instruktioner för Cline terminalklientinstallation och användning
- Uppdaterade MCP-klientsektionen för att inkludera alla populära klientalternativ
- Förbättrade bidragsexempel med mer exakta kodexempel

### Avancerade Ämnen (05-AdvancedTopics/)
- Organiserade alla specialiserade ämnesmappar med konsekvent namngivning
- Lagt till material och exempel för kontextteknik
- Lagt till dokumentation för Foundry-agentintegration
- Förbättrade dokumentation för Entra ID säkerhetsintegration

## 11 juni 2025

### Initial Skapelse
- Släppt första versionen av MCP för Nybörjare curriculum
- Skapade grundläggande struktur för alla 10 huvudsektioner
- Implementerade Visuell Curriculum-karta för navigering
- Lagt till initiala exempelprojekt i flera programmeringsspråk

### Komma Igång (03-GettingStarted/)
- Skapade första serverimplementeringsexempel
- Lagt till vägledning för klientutveckling
- Inkl

---

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, bör det noteras att automatiserade översättningar kan innehålla fel eller inexaktheter. Det ursprungliga dokumentet på dess originalspråk bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.