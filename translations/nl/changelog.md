<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T18:39:12+00:00",
  "source_file": "changelog.md",
  "language_code": "nl"
}
-->
# Changelog: MCP voor Beginners Curriculum

Dit document dient als een overzicht van alle belangrijke wijzigingen die zijn aangebracht in het Model Context Protocol (MCP) voor Beginners curriculum. Wijzigingen worden gedocumenteerd in omgekeerde chronologische volgorde (nieuwste wijzigingen eerst).

## 26 september 2025

### Verbetering van Casestudies - Integratie GitHub MCP Registry

#### Casestudies (09-CaseStudy/) - Focus op Ecosysteemontwikkeling
- **README.md**: Grote uitbreiding met uitgebreide casestudy over GitHub MCP Registry
  - **Casestudy GitHub MCP Registry**: Nieuwe uitgebreide casestudy over de lancering van GitHub's MCP Registry in september 2025
    - **Probleemanalyse**: Gedetailleerde analyse van gefragmenteerde MCP-serverontdekking en implementatie-uitdagingen
    - **Oplossingsarchitectuur**: GitHub's gecentraliseerde registry-aanpak met één-klik installatie in VS Code
    - **Zakelijke impact**: Meetbare verbeteringen in ontwikkelaarsonboarding en productiviteit
    - **Strategische waarde**: Focus op modulaire agentimplementatie en interoperabiliteit tussen tools
    - **Ecosysteemontwikkeling**: Positionering als fundamenteel platform voor agentische integratie
  - **Verbeterde structuur casestudies**: Alle zeven casestudies bijgewerkt met consistente opmaak en uitgebreide beschrijvingen
    - Azure AI Travel Agents: Nadruk op multi-agent orkestratie
    - Azure DevOps Integratie: Focus op workflowautomatisering
    - Real-Time Documentatie Retrieval: Implementatie van Python console client
    - Interactieve Studieplan Generator: Chainlit conversatie-webapp
    - Documentatie in Editor: Integratie van VS Code en GitHub Copilot
    - Azure API Management: Patronen voor integratie van bedrijfs-API's
    - GitHub MCP Registry: Ecosysteemontwikkeling en communityplatform
  - **Uitgebreide conclusie**: Herschreven conclusie met nadruk op zeven casestudies die verschillende dimensies van MCP-implementatie bestrijken
    - Categorisatie: Bedrijfsintegratie, multi-agent orkestratie, ontwikkelaarsproductiviteit
    - Ecosysteemontwikkeling, educatieve toepassingen
    - Verbeterde inzichten in architecturale patronen, implementatiestrategieën en best practices
    - Nadruk op MCP als volwassen, productieklare protocol

#### Updates Studiegids (study_guide.md)
- **Visuele Curriculumkaart**: Mindmap bijgewerkt om GitHub MCP Registry toe te voegen aan de sectie Casestudies
- **Beschrijving Casestudies**: Verbeterd van algemene beschrijvingen naar gedetailleerde uiteenzetting van zeven uitgebreide casestudies
- **Repositorystructuur**: Sectie 10 bijgewerkt om uitgebreide dekking van casestudies te weerspiegelen met specifieke implementatiedetails
- **Integratie Changelog**: Ingang van 26 september 2025 toegevoegd met documentatie over GitHub MCP Registry en verbeteringen in casestudies
- **Datumupdates**: Voettekst bijgewerkt om de laatste revisie te weerspiegelen (26 september 2025)

### Verbeteringen in Documentatiekwaliteit
- **Consistentieverbetering**: Gestandaardiseerde opmaak en structuur van casestudies over alle zeven voorbeelden
- **Uitgebreide dekking**: Casestudies bestrijken nu bedrijfs-, ontwikkelaarsproductiviteit- en ecosysteemontwikkelingsscenario's
- **Strategische positionering**: Versterkte focus op MCP als fundamenteel platform voor implementatie van agentische systemen
- **Integratie van bronnen**: Extra bronnen bijgewerkt om GitHub MCP Registry-link op te nemen

## 15 september 2025

### Uitbreiding Geavanceerde Onderwerpen - Aangepaste Transports & Context Engineering

#### MCP Aangepaste Transports (05-AdvancedTopics/mcp-transport/) - Nieuwe Geavanceerde Implementatiegids
- **README.md**: Complete implementatiegids voor aangepaste MCP-transportmechanismen
  - **Azure Event Grid Transport**: Uitgebreide serverloze event-driven transportimplementatie
    - Voorbeelden in C#, TypeScript en Python met integratie van Azure Functions
    - Architectuurpatronen voor schaalbare MCP-oplossingen
    - Webhook-ontvangers en push-gebaseerde berichtafhandeling
  - **Azure Event Hubs Transport**: Implementatie van streaming transport met hoge doorvoer
    - Real-time streamingmogelijkheden voor scenario's met lage latentie
    - Partitioneringsstrategieën en beheer van controlepunten
    - Berichtbatching en prestatieoptimalisatie
  - **Patronen voor bedrijfsintegratie**: Productieklare architecturale voorbeelden
    - Gedistribueerde MCP-verwerking over meerdere Azure Functions
    - Hybride transportarchitecturen die meerdere transporttypen combineren
    - Strategieën voor berichtduurzaamheid, betrouwbaarheid en foutafhandeling
  - **Beveiliging & Monitoring**: Integratie van Azure Key Vault en observatiepatronen
    - Authenticatie met beheerde identiteit en toegang met minimaal privilege
    - Telemetrie van Application Insights en prestatiemonitoring
    - Circuit breakers en fouttolerantiepatronen
  - **Testframeworks**: Uitgebreide teststrategieën voor aangepaste transports
    - Unit testing met test doubles en mocking frameworks
    - Integratietests met Azure Test Containers
    - Overwegingen voor prestatie- en belastingtests

#### Context Engineering (05-AdvancedTopics/mcp-contextengineering/) - Opkomende AI-discipline
- **README.md**: Uitgebreide verkenning van context engineering als opkomend vakgebied
  - **Kernprincipes**: Volledige contextdeling, bewustzijn van actiebeslissingen en beheer van contextvensters
  - **Afstemming MCP-protocol**: Hoe MCP-ontwerp uitdagingen in context engineering aanpakt
    - Beperkingen van contextvensters en strategieën voor progressieve laden
    - Relevantiebepaling en dynamische contextophaling
    - Multi-modale contextafhandeling en beveiligingsoverwegingen
  - **Implementatiebenaderingen**: Single-threaded versus multi-agent architecturen
    - Technieken voor contextchunking en prioritering
    - Progressieve contextladen en compressiestrategieën
    - Gelaagde contextbenaderingen en optimalisatie van ophaling
  - **Meetkader**: Opkomende metrics voor evaluatie van contexteffectiviteit
    - Overwegingen voor inputefficiëntie, prestaties, kwaliteit en gebruikerservaring
    - Experimentele benaderingen voor contextoptimalisatie
    - Foutanalyse en verbeteringsmethodologieën

#### Updates Curriculum Navigatie (README.md)
- **Verbeterde modulestructuur**: Curriculumtabel bijgewerkt om nieuwe geavanceerde onderwerpen op te nemen
  - Toegevoegd Context Engineering (5.14) en Custom Transport (5.15) vermeldingen
  - Consistente opmaak en navigatielinks over alle modules
  - Beschrijvingen bijgewerkt om huidige inhoudsscope te weerspiegelen

### Verbeteringen in Directorystructuur
- **Standaardisatie van namen**: "mcp transport" hernoemd naar "mcp-transport" voor consistentie met andere geavanceerde onderwerpmappen
- **Inhoudsorganisatie**: Alle 05-AdvancedTopics-mappen volgen nu een consistent naamgevingspatroon (mcp-[onderwerp])

### Verbeteringen in Documentatiekwaliteit
- **Afstemming MCP-specificatie**: Alle nieuwe inhoud verwijst naar huidige MCP-specificatie 2025-06-18
- **Meertalige voorbeelden**: Uitgebreide codevoorbeelden in C#, TypeScript en Python
- **Focus op bedrijfsomgeving**: Productieklare patronen en integratie met Azure-cloud door het hele document
- **Visuele documentatie**: Mermaid-diagrammen voor architectuur en stroomvisualisatie

## 18 augustus 2025

### Uitgebreide Documentatie-update - MCP 2025-06-18 Standaarden

#### MCP Beveiligingsbest Practices (02-Security/) - Volledige Modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Volledige herschrijving afgestemd op MCP-specificatie 2025-06-18
  - **Verplichte vereisten**: Toegevoegd expliciete MOET/MAG NIET vereisten uit officiële specificatie met duidelijke visuele indicatoren
  - **12 Kernbeveiligingspraktijken**: Herstructurering van 15-item lijst naar uitgebreide beveiligingsdomeinen
    - Tokenbeveiliging & Authenticatie met integratie van externe identiteitsproviders
    - Sessiebeheer & Transportbeveiliging met cryptografische vereisten
    - AI-specifieke dreigingsbescherming met Microsoft Prompt Shields integratie
    - Toegangscontrole & Machtigingen met principe van minimaal privilege
    - Inhoudsveiligheid & Monitoring met Azure Content Safety integratie
    - Beveiliging van toeleveringsketen met uitgebreide componentverificatie
    - OAuth-beveiliging & Confused Deputy Preventie met PKCE-implementatie
    - Incidentrespons & Herstel met geautomatiseerde mogelijkheden
    - Naleving & Governance met afstemming op regelgeving
    - Geavanceerde beveiligingscontroles met zero trust architectuur
    - Integratie Microsoft Beveiliging Ecosysteem met uitgebreide oplossingen
    - Continue beveiligingsevolutie met adaptieve praktijken
  - **Microsoft Beveiligingsoplossingen**: Verbeterde integratierichtlijnen voor Prompt Shields, Azure Content Safety, Entra ID en GitHub Advanced Security
  - **Implementatiebronnen**: Gecategoriseerde uitgebreide bronlinks per Officiële MCP Documentatie, Microsoft Beveiligingsoplossingen, Beveiligingsstandaarden en Implementatiegidsen

#### Geavanceerde Beveiligingscontroles (02-Security/) - Implementatie voor Bedrijven
- **MCP-SECURITY-CONTROLS-2025.md**: Volledige revisie met bedrijfsgerichte beveiligingsframework
  - **9 Uitgebreide Beveiligingsdomeinen**: Uitgebreid van basiscontroles naar gedetailleerd bedrijfsframework
    - Geavanceerde Authenticatie & Autorisatie met Microsoft Entra ID integratie
    - Tokenbeveiliging & Anti-Passthrough Controles met uitgebreide validatie
    - Sessiebeveiligingscontroles met preventie van kaping
    - AI-specifieke beveiligingscontroles met preventie van promptinjectie en toolvergiftiging
    - Preventie van Confused Deputy-aanvallen met OAuth proxy beveiliging
    - Tooluitvoeringsbeveiliging met sandboxing en isolatie
    - Beveiligingscontroles voor toeleveringsketen met verificatie van afhankelijkheden
    - Monitoring & Detectiecontroles met SIEM-integratie
    - Incidentrespons & Herstel met geautomatiseerde mogelijkheden
  - **Implementatievoorbeelden**: Gedetailleerde YAML-configuratieblokken en codevoorbeelden toegevoegd
  - **Integratie Microsoft-oplossingen**: Uitgebreide dekking van Azure beveiligingsdiensten, GitHub Advanced Security en bedrijfsidentiteitsbeheer

#### Geavanceerde Onderwerpen Beveiliging (05-AdvancedTopics/mcp-security/) - Productieklare Implementatie
- **README.md**: Volledige herschrijving voor bedrijfsbeveiligingsimplementatie
  - **Afstemming huidige specificatie**: Bijgewerkt naar MCP-specificatie 2025-06-18 met verplichte beveiligingsvereisten
  - **Verbeterde authenticatie**: Microsoft Entra ID integratie met uitgebreide .NET en Java Spring Security voorbeelden
  - **AI Beveiligingsintegratie**: Microsoft Prompt Shields en Azure Content Safety implementatie met gedetailleerde Python voorbeelden
  - **Geavanceerde dreigingsmitigatie**: Uitgebreide implementatievoorbeelden voor
    - Preventie van Confused Deputy-aanvallen met PKCE en validatie van gebruikersconsent
    - Preventie van Token Passthrough met validatie van publiek en veilig tokenbeheer
    - Preventie van sessiekaping met cryptografische binding en gedragsanalyse
  - **Integratie bedrijfsbeveiliging**: Monitoring van Azure Application Insights, dreigingsdetectiepijplijnen en beveiliging van toeleveringsketen
  - **Implementatiechecklist**: Duidelijke verplichte versus aanbevolen beveiligingscontroles met voordelen van Microsoft beveiligingsecosysteem

### Verbeteringen in Documentatiekwaliteit & Standaardafstemming
- **Referenties specificatie**: Alle referenties bijgewerkt naar huidige MCP-specificatie 2025-06-18
- **Microsoft Beveiliging Ecosysteem**: Verbeterde integratierichtlijnen door alle beveiligingsdocumentatie heen
- **Praktische implementatie**: Gedetailleerde codevoorbeelden toegevoegd in .NET, Java en Python met bedrijfsgerichte patronen
- **Organisatie van bronnen**: Uitgebreide categorisatie van officiële documentatie, beveiligingsstandaarden en implementatiegidsen
- **Visuele indicatoren**: Duidelijke markering van verplichte vereisten versus aanbevolen praktijken

#### Kernconcepten (01-CoreConcepts/) - Volledige Modernisering
- **Protocolversie-update**: Bijgewerkt naar huidige MCP-specificatie 2025-06-18 met datumgebaseerde versie (YYYY-MM-DD formaat)
- **Architectuurverfijning**: Verbeterde beschrijvingen van Hosts, Clients en Servers om huidige MCP-architectuurpatronen te weerspiegelen
  - Hosts nu duidelijk gedefinieerd als AI-toepassingen die meerdere MCP-clientverbindingen coördineren
  - Clients beschreven als protocolconnectoren die één-op-één serverrelaties onderhouden
  - Servers verbeterd met lokale versus externe implementatiescenario's
- **Herstructurering van Primitieven**: Volledige revisie van server- en clientprimitieven
  - Serverprimitieven: Resources (gegevensbronnen), Prompts (sjablonen), Tools (uitvoerbare functies) met gedetailleerde uitleg en voorbeelden
  - Clientprimitieven: Sampling (LLM-completions), Elicitation (gebruikersinput), Logging (debugging/monitoring)
  - Bijgewerkt met huidige ontdekking (`*/list`), ophaling (`*/get`) en uitvoering (`*/call`) methodenpatronen
- **Protocolarchitectuur**: Twee-laags architectuurmodel geïntroduceerd
  - Datalaag: JSON-RPC 2.0 basis met levenscyclusbeheer en primitieven
  - Transportlaag: STDIO (lokaal) en Streamable HTTP met SSE (extern) transportmechanismen
- **Beveiligingsframework**: Uitgebreide beveiligingsprincipes inclusief expliciete gebruikersconsent, gegevensprivacybescherming, tooluitvoeringsveiligheid en transportlaagbeveiliging
- **Communicatiepatronen**: Protocolberichten bijgewerkt om initialisatie, ontdekking, uitvoering en notificatiestromen te tonen
- **Codevoorbeelden**: Meertalige voorbeelden vernieuwd (.NET, Java, Python, JavaScript) om huidige MCP SDK-patronen te weerspiegelen

#### Beveiliging (02-Security/) - Uitgebreide Beveiligingsrevisie  
- **Afstemming standaarden**: Volledige afstemming met MCP-specificatie 2025-06-18 beveiligingsvereisten
- **Evolutie authenticatie**: Documentatie van evolutie van aangepaste OAuth-servers naar delegatie van externe identiteitsproviders (Microsoft Entra ID)
- **AI-specifieke dreigingsanalyse**: Verbeterde dekking van moderne AI-aanvalsvectoren
  - Gedetailleerde promptinjectie-aanvalsscenario's met praktijkvoorbeelden
  - Mechanismen voor toolvergiftiging en "rug pull" aanvalspatronen
  - Vergiftiging van contextvensters en modelverwarringsaanvallen
- **Microsoft AI Beveiligingsoplossingen**: Uitgebreide dekking van Microsoft beveiligingsecosysteem
  - AI Prompt Shields met geavanceerde detectie, spotlighting en delimitertechnieken
  - Integratiepatronen van Azure Content Safety
  - GitHub Advanced Security voor bescherming van toeleveringsketen
- **Geavanceerde dreigingsmitigatie**: Gedetailleerde beveiligingscontroles voor
  - Sessiekaping met MCP-specifieke aanvalsscenario's en cryptografische sessie-ID vereisten
  - Confused deputy problemen in MCP proxy-scenario's met expliciete consentvereisten
  - Token passthrough kwetsbaarheden met verplichte validatiecontroles
- **Beveiliging van toeleveringsketen**: Uitgebreide dekking van AI-toeleveringsketen inclusief foundation models, embeddings services, contextproviders en externe API's
- **Fundamentele beveiliging**: Verbeterde integratie met bedrijfsbeveiligingspatronen inclusief zero trust architectuur en Microsoft beveiligingsecosysteem
- **Organisatie van bronnen**: Gecategoriseerde uitgebreide bronlinks per type (Officiële Documentatie, Standaarden, Onderzoek, Microsoft Oplossingen, Implementatiegidsen)

### Verbeteringen in Documentatiekwaliteit
- **Gestructureerde leerdoelen**: Verbeterde leerdoelen met specifieke, uitvoerbare resultaten 
- **Kruisverwijzingen**: Links toegevoegd tussen gerelateerde beveiligings- en kernconceptonderwerpen
- **Actuele informatie**: Alle datums en specificatielinks bijgewerkt naar huidige standaarden
- **Implementatierichtlijnen**: Specifieke, uitvoerbare implementatierichtlijnen toegevoegd door beide secties heen

## 16 juli 2025

### Verbeteringen README en Navigatie
- Curriculumnavigatie in README.md volledig opnieuw ontworpen
- Vervangen `<details>` tags door een toegankelijker tabelgebaseerd formaat
- Alternatieve lay-outopties gemaakt in de nieuwe map "alternative_layouts"
- Voorbeelden toegevoegd van navigatie in kaartstijl, tabstijl en accordeonstijl
- Sectie over repositorystructuur bijgewerkt om alle nieuwste bestanden op te nemen
- Sectie "Hoe gebruik je dit curriculum" verbeterd met duidelijke aanbevelingen
- MCP-specificatielinks bijgewerkt naar de juiste URL's
- Sectie Context Engineering (5.14) toegevoegd aan de curriculumstructuur

### Updates Studiegids
- Studiegids volledig herzien om aan te sluiten bij de huidige repositorystructuur
- Nieuwe secties toegevoegd voor MCP Clients en Tools, en Populaire MCP Servers
- Visuele Curriculumkaart bijgewerkt om alle onderwerpen nauwkeurig weer te geven
- Beschrijvingen van Geavanceerde Onderwerpen verbeterd om alle gespecialiseerde gebieden te dekken
- Sectie Casestudies bijgewerkt om echte voorbeelden te reflecteren
- Deze uitgebreide changelog toegevoegd

### Communitybijdragen (06-CommunityContributions/)
- Gedetailleerde informatie toegevoegd over MCP-servers voor beeldgeneratie
- Uitgebreide sectie toegevoegd over het gebruik van Claude in VSCode
- Instructies toegevoegd voor het instellen en gebruiken van de Cline terminalclient
- Sectie MCP-clients bijgewerkt om alle populaire clientopties op te nemen
- Voorbeelden van bijdragen verbeterd met nauwkeurigere codevoorbeelden

### Geavanceerde Onderwerpen (05-AdvancedTopics/)
- Alle gespecialiseerde onderwerpmappen georganiseerd met consistente naamgeving
- Materialen en voorbeelden voor context engineering toegevoegd
- Documentatie voor Foundry-agentintegratie toegevoegd
- Documentatie voor Entra ID-beveiligingsintegratie verbeterd

## 11 juni 2025

### Eerste Creatie
- Eerste versie van het MCP voor Beginners-curriculum uitgebracht
- Basisstructuur gecreëerd voor alle 10 hoofdsecties
- Visuele Curriculumkaart geïmplementeerd voor navigatie
- Eerste voorbeeldprojecten toegevoegd in meerdere programmeertalen

### Aan de slag (03-GettingStarted/)
- Eerste serverimplementatievoorbeelden gecreëerd
- Richtlijnen voor clientontwikkeling toegevoegd
- Instructies voor LLM-clientintegratie opgenomen
- Documentatie voor VS Code-integratie toegevoegd
- Voorbeelden van Server-Sent Events (SSE) server geïmplementeerd

### Kernconcepten (01-CoreConcepts/)
- Gedetailleerde uitleg toegevoegd over client-serverarchitectuur
- Documentatie gemaakt over belangrijke protocolcomponenten
- Berichtpatronen in MCP gedocumenteerd

## 23 mei 2025

### Repositorystructuur
- Repository geïnitialiseerd met basismapstructuur
- README-bestanden gemaakt voor elke hoofdsectie
- Vertaalinfrastructuur opgezet
- Afbeeldingsbestanden en diagrammen toegevoegd

### Documentatie
- Eerste README.md gemaakt met curriculumoverzicht
- CODE_OF_CONDUCT.md en SECURITY.md toegevoegd
- SUPPORT.md opgezet met richtlijnen voor hulp
- Voorlopige structuur voor studiegids gecreëerd

## 15 april 2025

### Planning en Framework
- Eerste planning voor MCP voor Beginners-curriculum
- Leerdoelen en doelgroep gedefinieerd
- 10-sectie structuur van het curriculum uitgestippeld
- Conceptueel framework ontwikkeld voor voorbeelden en casestudies
- Eerste prototypevoorbeelden gecreëerd voor kernconcepten

---

