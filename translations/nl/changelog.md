<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T19:12:05+00:00",
  "source_file": "changelog.md",
  "language_code": "nl"
}
-->
# Changelog: MCP voor Beginners Curriculum

Dit document dient als een overzicht van alle belangrijke wijzigingen die zijn aangebracht in het Model Context Protocol (MCP) voor Beginners curriculum. Wijzigingen worden gedocumenteerd in omgekeerde chronologische volgorde (nieuwste wijzigingen eerst).

## 29 september 2025

### MCP Server Database Integratie Labs - Uitgebreid Hands-On Leerpad

#### 11-MCPServerHandsOnLabs - Nieuw Compleet Database Integratie Curriculum
- **Compleet 13-Lab Leerpad**: Toegevoegd uitgebreid hands-on curriculum voor het bouwen van productieklare MCP-servers met PostgreSQL database-integratie
  - **Implementatie in de praktijk**: Zava Retail analytics use case die patronen van ondernemingsniveau demonstreert
  - **Gestructureerde Leerprogressie**:
    - **Labs 00-03: Basisprincipes** - Introductie, Kernarchitectuur, Beveiliging & Multi-Tenancy, Omgevingsinstelling
    - **Labs 04-06: Het bouwen van de MCP Server** - Databaseontwerp & Schema, MCP Server Implementatie, Toolontwikkeling  
    - **Labs 07-09: Geavanceerde functies** - Integratie van semantisch zoeken, Testen & Debuggen, VS Code Integratie
    - **Labs 10-12: Productie & Best Practices** - Implementatiestrategieën, Monitoring & Observatie, Best Practices & Optimalisatie
  - **Ondernemingstechnologieën**: FastMCP framework, PostgreSQL met pgvector, Azure OpenAI embeddings, Azure Container Apps, Application Insights
  - **Geavanceerde functies**: Row Level Security (RLS), semantisch zoeken, multi-tenant data toegang, vector embeddings, realtime monitoring

#### Terminologie Standaardisatie - Module naar Lab Conversie
- **Uitgebreide Documentatie Update**: Systematisch alle README-bestanden in 11-MCPServerHandsOnLabs bijgewerkt om "Lab" terminologie te gebruiken in plaats van "Module"
  - **Sectiekoppen**: "Wat deze module behandelt" bijgewerkt naar "Wat dit lab behandelt" in alle 13 labs
  - **Inhoudsbeschrijving**: "Deze module biedt..." veranderd naar "Dit lab biedt..." in de hele documentatie
  - **Leerdoelen**: "Aan het einde van deze module..." bijgewerkt naar "Aan het einde van dit lab..."
  - **Navigatielinks**: Alle verwijzingen naar "Module XX:" omgezet naar "Lab XX:" in kruisverwijzingen en navigatie
  - **Volgtracking**: "Na het voltooien van deze module..." bijgewerkt naar "Na het voltooien van dit lab..."
  - **Technische Verwijzingen Behouden**: Python module verwijzingen in configuratiebestanden behouden (bijv. `"module": "mcp_server.main"`)

#### Verbetering Studiegids (study_guide.md)
- **Visuele Curriculumkaart**: Nieuwe sectie "11. Database Integratie Labs" toegevoegd met uitgebreide labstructuur visualisatie
- **Repositorystructuur**: Bijgewerkt van tien naar elf hoofdsecties met gedetailleerde beschrijving van 11-MCPServerHandsOnLabs
- **Leerpad Richtlijnen**: Verbeterde navigatie-instructies om secties 00-11 te dekken
- **Technologie Dekking**: Details toegevoegd over FastMCP, PostgreSQL, Azure services integratie
- **Leerresultaten**: Nadruk gelegd op productieklare serverontwikkeling, database-integratiepatronen en beveiliging op ondernemingsniveau

#### Hoofd README Structuur Verbetering
- **Lab-gebaseerde Terminologie**: Hoofd README.md in 11-MCPServerHandsOnLabs bijgewerkt om consequent "Lab" structuur te gebruiken
- **Leerpad Organisatie**: Duidelijke progressie van basisconcepten via geavanceerde implementatie naar productie-implementatie
- **Praktijkgericht**: Nadruk op praktische, hands-on leren met patronen en technologieën van ondernemingsniveau

### Documentatie Kwaliteit & Consistentie Verbeteringen
- **Hands-On Leerfocus**: Praktische, lab-gebaseerde aanpak versterkt in de hele documentatie
- **Focus op Ondernemingspatronen**: Productieklare implementaties en beveiligingsoverwegingen op ondernemingsniveau benadrukt
- **Technologie Integratie**: Uitgebreide dekking van moderne Azure services en AI integratiepatronen
- **Leerprogressie**: Duidelijk, gestructureerd pad van basisconcepten naar productie-implementatie

## 26 september 2025

### Case Studies Verbetering - GitHub MCP Registry Integratie

#### Case Studies (09-CaseStudy/) - Focus op Ecosysteemontwikkeling
- **README.md**: Grote uitbreiding met uitgebreide GitHub MCP Registry case study
  - **GitHub MCP Registry Case Study**: Nieuwe uitgebreide case study over de lancering van GitHub's MCP Registry in september 2025
    - **Probleemanalyse**: Gedetailleerd onderzoek naar gefragmenteerde MCP server ontdekking en implementatie uitdagingen
    - **Oplossingsarchitectuur**: GitHub's gecentraliseerde registry aanpak met één-klik VS Code installatie
    - **Zakelijke Impact**: Meetbare verbeteringen in ontwikkelaar onboarding en productiviteit
    - **Strategische Waarde**: Focus op modulaire agent implementatie en interoperabiliteit tussen tools
    - **Ecosysteemontwikkeling**: Positionering als fundamenteel platform voor agentische integratie
  - **Verbeterde Case Study Structuur**: Alle zeven case studies bijgewerkt met consistente opmaak en uitgebreide beschrijvingen
    - Azure AI Travel Agents: Nadruk op multi-agent orkestratie
    - Azure DevOps Integratie: Focus op workflow automatisering
    - Realtime Documentatie Retrieval: Python console client implementatie
    - Interactieve Studieplan Generator: Chainlit conversatie webapp
    - In-Editor Documentatie: VS Code en GitHub Copilot integratie
    - Azure API Management: Patronen voor API-integratie op ondernemingsniveau
    - GitHub MCP Registry: Ecosysteemontwikkeling en community platform
  - **Uitgebreide Conclusie**: Conclusiesectie herschreven met nadruk op zeven case studies die meerdere MCP implementatiedimensies bestrijken
    - Ondernemingsintegratie, Multi-Agent Orkestratie, Ontwikkelaarsproductiviteit
    - Ecosysteemontwikkeling, Educatieve Toepassingen categorisatie
    - Verbeterde inzichten in architecturale patronen, implementatiestrategieën en best practices
    - Nadruk op MCP als volwassen, productieklare protocol

#### Studiegids Updates (study_guide.md)
- **Visuele Curriculumkaart**: Mindmap bijgewerkt om GitHub MCP Registry op te nemen in de Case Studies sectie
- **Case Studies Beschrijving**: Verbeterd van generieke beschrijvingen naar gedetailleerde uiteenzetting van zeven uitgebreide case studies
- **Repositorystructuur**: Sectie 10 bijgewerkt om uitgebreide case study dekking te weerspiegelen met specifieke implementatiedetails
- **Changelog Integratie**: Ingang van 26 september 2025 toegevoegd die GitHub MCP Registry toevoeging en case study verbeteringen documenteert
- **Datum Updates**: Voettekst tijdstempel bijgewerkt om laatste revisie te weerspiegelen (26 september 2025)

### Documentatie Kwaliteit Verbeteringen
- **Consistentie Verbetering**: Case study opmaak en structuur gestandaardiseerd over alle zeven voorbeelden
- **Uitgebreide Dekking**: Case studies bestrijken nu ondernemings-, ontwikkelaarsproductiviteit- en ecosysteemontwikkelingsscenario's
- **Strategische Positionering**: Verbeterde focus op MCP als fundamenteel platform voor agentische systeemimplementatie
- **Resource Integratie**: Extra bronnen bijgewerkt om GitHub MCP Registry link op te nemen

## 15 september 2025

### Uitbreiding Geavanceerde Onderwerpen - Aangepaste Transports & Context Engineering

#### MCP Aangepaste Transports (05-AdvancedTopics/mcp-transport/) - Nieuwe Geavanceerde Implementatiegids
- **README.md**: Complete implementatiegids voor aangepaste MCP transportmechanismen
  - **Azure Event Grid Transport**: Uitgebreide serverloze event-gedreven transportimplementatie
    - C#, TypeScript, en Python voorbeelden met Azure Functions integratie
    - Event-gedreven architectuurpatronen voor schaalbare MCP-oplossingen
    - Webhook ontvangers en push-gebaseerde berichtafhandeling
  - **Azure Event Hubs Transport**: Hoge doorvoer streaming transportimplementatie
    - Realtime streaming mogelijkheden voor lage latentie scenario's
    - Partitioneringsstrategieën en checkpointbeheer
    - Berichtbatching en prestatieoptimalisatie
  - **Ondernemingsintegratiepatronen**: Productieklare architecturale voorbeelden
    - Gedistribueerde MCP verwerking over meerdere Azure Functions
    - Hybride transportarchitecturen die meerdere transporttypen combineren
    - Berichtduurzaamheid, betrouwbaarheid, en foutafhandelingsstrategieën
  - **Beveiliging & Monitoring**: Azure Key Vault integratie en observatiepatronen
    - Beheerde identiteit authenticatie en toegang met minimaal privilege
    - Application Insights telemetrie en prestatiemonitoring
    - Circuit breakers en fouttolerantiepatronen
  - **Testframeworks**: Uitgebreide teststrategieën voor aangepaste transports
    - Unit testing met test doubles en mocking frameworks
    - Integratietesten met Azure Test Containers
    - Prestatie- en belastingtestoverwegingen

#### Context Engineering (05-AdvancedTopics/mcp-contextengineering/) - Opkomende AI Discipline
- **README.md**: Uitgebreide verkenning van context engineering als opkomend vakgebied
  - **Kernprincipes**: Volledige contextdeling, bewustzijn van actiebeslissingen, en contextvensterbeheer
  - **MCP Protocol Afstemming**: Hoe MCP ontwerp context engineering uitdagingen aanpakt
    - Contextvensterbeperkingen en progressieve laadstrategieën
    - Relevantiebepaling en dynamische contextophaling
    - Multi-modale contextafhandeling en beveiligingsoverwegingen
  - **Implementatiebenaderingen**: Single-threaded vs. multi-agent architecturen
    - Context chunking en prioriteringstechnieken
    - Progressieve contextladen en compressiestrategieën
    - Gelaagde contextbenaderingen en optimalisatie van ophaling
  - **Meetkader**: Opkomende metrics voor evaluatie van contexteffectiviteit
    - Inputefficiëntie, prestaties, kwaliteit, en gebruikerservaringsoverwegingen
    - Experimentele benaderingen voor contextoptimalisatie
    - Foutanalyse en verbeteringsmethodologieën

#### Curriculum Navigatie Updates (README.md)
- **Verbeterde Module Structuur**: Curriculumtabel bijgewerkt om nieuwe geavanceerde onderwerpen op te nemen
  - Context Engineering (5.14) en Custom Transport (5.15) toegevoegd
  - Consistente opmaak en navigatielinks over alle modules
  - Beschrijvingen bijgewerkt om huidige inhoudsscope te weerspiegelen

### Verbeteringen Directorystructuur
- **Naamgeving Standaardisatie**: "mcp transport" hernoemd naar "mcp-transport" voor consistentie met andere geavanceerde onderwerp mappen
- **Inhoudsorganisatie**: Alle 05-AdvancedTopics mappen volgen nu een consistent naamgevingspatroon (mcp-[onderwerp])

### Documentatie Kwaliteit Verbeteringen
- **MCP Specificatie Afstemming**: Alle nieuwe inhoud verwijst naar huidige MCP Specificatie 2025-06-18
- **Meertalig Voorbeelden**: Uitgebreide codevoorbeelden in C#, TypeScript, en Python
- **Focus op Ondernemingen**: Productieklare patronen en Azure cloud integratie in de hele documentatie
- **Visuele Documentatie**: Mermaid diagrammen voor architectuur en stroomvisualisatie

## 18 augustus 2025

### Documentatie Uitgebreide Update - MCP 2025-06-18 Standaarden

#### MCP Beveiligingsbest Practices (02-Security/) - Volledige Modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Volledige herschrijving afgestemd op MCP Specificatie 2025-06-18
  - **Verplichte Vereisten**: Toegevoegd expliciete MOET/MAG NIET vereisten uit officiële specificatie met duidelijke visuele indicatoren
  - **12 Kernbeveiligingspraktijken**: Herstructureerd van 15-item lijst naar uitgebreide beveiligingsdomeinen
    - Tokenbeveiliging & Authenticatie met externe identiteitsprovider integratie
    - Sessiebeheer & Transportbeveiliging met cryptografische vereisten
    - AI-Specifieke Dreigingsbescherming met Microsoft Prompt Shields integratie
    - Toegangscontrole & Machtigingen met principe van minimaal privilege
    - Inhoudsveiligheid & Monitoring met Azure Content Safety integratie
    - Leveringsketenbeveiliging met uitgebreide componentverificatie
    - OAuth Beveiliging & Preventie van Verwarde Deputy met PKCE implementatie
    - Incidentrespons & Herstel met geautomatiseerde mogelijkheden
    - Naleving & Governance met regelgevingsafstemming
    - Geavanceerde Beveiligingscontroles met zero trust architectuur
    - Microsoft Beveiliging Ecosysteem Integratie met uitgebreide oplossingen
    - Continue Beveiligingsevolutie met adaptieve praktijken
  - **Microsoft Beveiligingsoplossingen**: Verbeterde integratierichtlijnen voor Prompt Shields, Azure Content Safety, Entra ID, en GitHub Advanced Security
  - **Implementatiebronnen**: Gecategoriseerde uitgebreide resource links per Officiële MCP Documentatie, Microsoft Beveiligingsoplossingen, Beveiligingsstandaarden, en Implementatiegidsen

#### Geavanceerde Beveiligingscontroles (02-Security/) - Implementatie op Ondernemingsniveau
- **MCP-SECURITY-CONTROLS-2025.md**: Volledige revisie met beveiligingskader op ondernemingsniveau
  - **9 Uitgebreide Beveiligingsdomeinen**: Uitgebreid van basiscontroles naar gedetailleerd ondernemingskader
    - Geavanceerde Authenticatie & Autorisatie met Microsoft Entra ID integratie
    - Tokenbeveiliging & Anti-Passthrough Controles met uitgebreide validatie
    - Sessiebeveiligingscontroles met kapingpreventie
    - AI-Specifieke Beveiligingscontroles met promptinjectie en toolvergiftiging preventie
    - Preventie van Verwarde Deputy Aanvallen met OAuth proxy beveiliging
    - Tooluitvoeringsbeveiliging met sandboxing en isolatie
    - Leveringsketenbeveiligingscontroles met afhankelijkheidsverificatie
    - Monitoring & Detectiecontroles met SIEM integratie
    - Incidentrespons & Herstel met geautomatiseerde mogelijkheden
  - **Implementatievoorbeelden**: Gedetailleerde YAML configuratieblokken en codevoorbeelden toegevoegd
  - **Microsoft Oplossingen Integratie**: Uitgebreide dekking van Azure beveiligingsservices, GitHub Advanced Security, en ondernemingsidentiteitsbeheer

#### Geavanceerde Onderwerpen Beveiliging (05-AdvancedTopics/mcp-security/) - Productieklare Implementatie
- **README.md**: Volledige herschrijving voor beveiligingsimplementatie op ondernemingsniveau
  - **Huidige Specificatie Afstemming**: Bijgewerkt naar MCP Specificatie 2025-06-18 met verplichte beveiligingsvereisten
  - **Verbeterde Authenticatie**: Microsoft Entra ID integratie met uitgebreide .NET en Java Spring Security voorbeelden
  - **AI Beveiligingsintegratie**: Microsoft Prompt Shields en Azure Content Safety implementatie met gedetailleerde Python voorbeelden
  - **Geavanceerde Dreigingsmitigatie**: Uitgebreide implementatievoorbeelden voor
    - Preventie van Verwarde Deputy Aanvallen met PKCE en gebruikersconsent validatie
    - Preventie van Token Passthrough met validatie van publiek en veilig tokenbeheer
    - Preventie van Sessiekaping met cryptografische binding en gedragsanalyse
  - **Ondernemingsbeveiligingsintegratie**: Azure Application Insights monitoring, dreigingsdetectiepijplijnen, en leveringsketenbeveiliging
  - **Implementatiechecklist**: Duidelijke verplichte versus aanbevolen beveiligingscontroles met voordelen van Microsoft beveiligingsecosysteem

### Documentatie Kwaliteit & Standaarden Afstemming
- **Specificatieverwijzingen**: Alle verwijzingen bijgewerkt naar huidige MCP Specificatie 2025-06-18
- **Microsoft Beveiliging Ecosysteem**: Verbeterde integratierichtlijnen in alle beveiligingsdocumentatie
- **Praktische Implementatie**: Gedetailleerde codevoorbeelden toegevoegd in .NET, Java, en Python met patronen op ondernemingsniveau
- **Resourceorganisatie**: Uitgebreide categorisatie van officiële documentatie, beveiligingsstandaarden, en implementatiegidsen
- **Visuele Indicatoren**: Duidelijke markering van verplichte vereisten versus aanbevolen praktijken

#### Kernconcepten (01-CoreConcepts/) - Volledige Modernisering
- **Protocolversie-update**: Bijgewerkt naar de huidige MCP-specificatie 2025-06-18 met datumgebaseerde versie-indeling (YYYY-MM-DD-formaat)
- **Architectuurverfijning**: Verbeterde beschrijvingen van Hosts, Clients en Servers om de huidige MCP-architectuurpatronen te weerspiegelen
  - Hosts nu duidelijk gedefinieerd als AI-toepassingen die meerdere MCP-clientverbindingen coördineren
  - Clients beschreven als protocolconnectoren die één-op-één serverrelaties onderhouden
  - Servers verbeterd met scenario's voor lokale versus externe implementatie
- **Herstructurering van Primitieven**: Volledige revisie van server- en clientprimitieven
  - Serverprimitieven: Resources (gegevensbronnen), Prompts (sjablonen), Tools (uitvoerbare functies) met gedetailleerde uitleg en voorbeelden
  - Clientprimitieven: Sampling (LLM-completions), Elicitation (gebruikersinput), Logging (debugging/monitoring)
  - Bijgewerkt met huidige ontdekking (`*/list`), ophalen (`*/get`) en uitvoeringsmethoden (`*/call`) patronen
- **Protocolarchitectuur**: Invoering van een tweelaags architectuurmodel
  - Datalaag: JSON-RPC 2.0 basis met levenscyclusbeheer en primitieven
  - Transportlaag: STDIO (lokaal) en Streamable HTTP met SSE (extern) transportmechanismen
- **Beveiligingskader**: Uitgebreide beveiligingsprincipes, waaronder expliciete gebruikersinstemming, gegevensprivacybescherming, veiligheid van tooluitvoering en transportlaagbeveiliging
- **Communicatiepatronen**: Bijgewerkte protocolberichten om initialisatie, ontdekking, uitvoering en notificatiestromen te tonen
- **Codevoorbeelden**: Vernieuwde voorbeelden in meerdere talen (.NET, Java, Python, JavaScript) om huidige MCP SDK-patronen te weerspiegelen

#### Beveiliging (02-Security/) - Uitgebreide Beveiligingsherziening  
- **Normenafstemming**: Volledige afstemming met MCP-specificatie 2025-06-18 beveiligingseisen
- **Evolutie van Authenticatie**: Gedocumenteerde overgang van aangepaste OAuth-servers naar delegatie van externe identiteitsproviders (Microsoft Entra ID)
- **AI-specifieke Dreigingsanalyse**: Verbeterde dekking van moderne AI-aanvalsvectoren
  - Gedetailleerde scenario's voor promptinjectie-aanvallen met praktijkvoorbeelden
  - Mechanismen voor toolvergiftiging en "rug pull"-aanvalspatronen
  - Contextvenstervergiftiging en modelverwarringsaanvallen
- **Microsoft AI-beveiligingsoplossingen**: Uitgebreide dekking van het Microsoft-beveiligingsecosysteem
  - AI Prompt Shields met geavanceerde detectie, markering en scheidingstechnieken
  - Integratiepatronen voor Azure Content Safety
  - GitHub Advanced Security voor bescherming van de toeleveringsketen
- **Geavanceerde Dreigingsbeperking**: Gedetailleerde beveiligingsmaatregelen voor
  - Sessiekaping met MCP-specifieke aanvalsscenario's en cryptografische sessie-ID-vereisten
  - Problemen met verwarde tussenpersonen in MCP-proxyscenario's met expliciete instemmingsvereisten
  - Token-doorvoerkwetsbaarheden met verplichte validatiecontroles
- **Beveiliging van de Toeleveringsketen**: Uitgebreide dekking van AI-toeleveringsketens, inclusief funderingsmodellen, embeddingservices, contextproviders en externe API's
- **Fundamentele Beveiliging**: Verbeterde integratie met bedrijfsbeveiligingspatronen, waaronder zero trust-architectuur en het Microsoft-beveiligingsecosysteem
- **Organisatie van Bronnen**: Gecategoriseerde uitgebreide bronnenlinks per type (Officiële Documentatie, Normen, Onderzoek, Microsoft-oplossingen, Implementatierichtlijnen)

### Verbeteringen in Documentatiekwaliteit
- **Gestructureerde Leerdoelen**: Verbeterde leerdoelen met specifieke, uitvoerbare resultaten
- **Kruisverwijzingen**: Toegevoegde links tussen gerelateerde beveiligings- en kernconceptonderwerpen
- **Actuele Informatie**: Alle datums en specificatielinks bijgewerkt naar huidige normen
- **Implementatierichtlijnen**: Specifieke, uitvoerbare implementatierichtlijnen toegevoegd in beide secties

## 16 juli 2025

### README en Navigatieverbeteringen
- Volledig herontworpen curriculum-navigatie in README.md
- `<details>`-tags vervangen door een toegankelijker tabelgebaseerd formaat
- Alternatieve lay-outopties gemaakt in de nieuwe map "alternative_layouts"
- Voorbeelden toegevoegd van kaartgebaseerde, tabbladstijl- en accordeonstijl-navigatie
- Sectie over repositorystructuur bijgewerkt om alle nieuwste bestanden op te nemen
- Sectie "Hoe gebruik je dit curriculum" verbeterd met duidelijke aanbevelingen
- MCP-specificatielinks bijgewerkt naar de juiste URL's
- Sectie Context Engineering (5.14) toegevoegd aan de curriculumstructuur

### Updates van Studiegids
- Studiegids volledig herzien om overeen te komen met de huidige repositorystructuur
- Nieuwe secties toegevoegd voor MCP Clients en Tools, en Populaire MCP Servers
- Visuele Curriculumkaart bijgewerkt om alle onderwerpen nauwkeurig weer te geven
- Beschrijvingen van Geavanceerde Onderwerpen verbeterd om alle gespecialiseerde gebieden te dekken
- Sectie Case Studies bijgewerkt om werkelijke voorbeelden te weerspiegelen
- Deze uitgebreide changelog toegevoegd

### Communitybijdragen (06-CommunityContributions/)
- Gedetailleerde informatie toegevoegd over MCP-servers voor beeldgeneratie
- Uitgebreide sectie toegevoegd over het gebruik van Claude in VSCode
- Instructies toegevoegd voor het instellen en gebruiken van de Cline-terminalclient
- MCP-clientsectie bijgewerkt om alle populaire clientopties op te nemen
- Bijdragevoorbeelden verbeterd met nauwkeurigere codevoorbeelden

### Geavanceerde Onderwerpen (05-AdvancedTopics/)
- Alle gespecialiseerde onderwerpmappen georganiseerd met consistente naamgeving
- Materialen en voorbeelden voor contextengineering toegevoegd
- Documentatie voor Foundry-agentintegratie toegevoegd
- Documentatie voor Entra ID-beveiligingsintegratie verbeterd

## 11 juni 2025

### Eerste Creatie
- Eerste versie van het MCP voor Beginners-curriculum uitgebracht
- Basisstructuur gecreëerd voor alle 10 hoofdsecties
- Visuele Curriculumkaart geïmplementeerd voor navigatie
- Eerste voorbeeldprojecten toegevoegd in meerdere programmeertalen

### Aan de Slag (03-GettingStarted/)
- Eerste serverimplementatievoorbeelden gecreëerd
- Richtlijnen voor clientontwikkeling toegevoegd
- Instructies voor LLM-clientintegratie toegevoegd
- Documentatie voor VS Code-integratie toegevoegd
- Voorbeelden van Server-Sent Events (SSE) server geïmplementeerd

### Kernconcepten (01-CoreConcepts/)
- Gedetailleerde uitleg toegevoegd over client-serverarchitectuur
- Documentatie gecreëerd over belangrijke protocolcomponenten
- Berichtenpatronen in MCP gedocumenteerd

## 23 mei 2025

### Repositorystructuur
- Repository geïnitialiseerd met basismapstructuur
- README-bestanden gecreëerd voor elke hoofdsectie
- Vertaalinfrastructuur opgezet
- Afbeeldingsassets en diagrammen toegevoegd

### Documentatie
- Eerste README.md gecreëerd met curriculumoverzicht
- CODE_OF_CONDUCT.md en SECURITY.md toegevoegd
- SUPPORT.md opgezet met richtlijnen voor hulp
- Voorlopige structuur van studiegids gecreëerd

## 15 april 2025

### Planning en Framework
- Eerste planning voor MCP voor Beginners-curriculum
- Leerdoelen en doelgroep gedefinieerd
- Structuur van 10 secties van het curriculum geschetst
- Conceptueel framework ontwikkeld voor voorbeelden en casestudies
- Eerste prototypevoorbeelden gecreëerd voor kernconcepten

---

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.