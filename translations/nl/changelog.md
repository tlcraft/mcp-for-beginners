<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:19:39+00:00",
  "source_file": "changelog.md",
  "language_code": "nl"
}
-->
# Changelog: MCP voor Beginners Curriculum

Dit document dient als een overzicht van alle belangrijke wijzigingen die zijn aangebracht in het Model Context Protocol (MCP) voor Beginners curriculum. Wijzigingen worden gedocumenteerd in omgekeerde chronologische volgorde (nieuwste wijzigingen eerst).

## 15 september 2025

### Uitbreiding Geavanceerde Onderwerpen - Aangepaste Transports & Context Engineering

#### MCP Aangepaste Transports (05-AdvancedTopics/mcp-transport/) - Nieuwe Geavanceerde Implementatiehandleiding
- **README.md**: Volledige implementatiehandleiding voor aangepaste MCP transportmechanismen
  - **Azure Event Grid Transport**: Uitgebreide serverloze event-gedreven transportimplementatie
    - Voorbeelden in C#, TypeScript en Python met Azure Functions integratie
    - Architectuurpatronen voor schaalbare MCP-oplossingen
    - Webhook-ontvangers en push-gebaseerde berichtafhandeling
  - **Azure Event Hubs Transport**: Implementatie van streaming transport met hoge doorvoer
    - Real-time streaming mogelijkheden voor scenario's met lage latentie
    - Partitioneringsstrategieën en checkpointbeheer
    - Berichtbatching en prestatieoptimalisatie
  - **Enterprise Integratiepatronen**: Productieklare architecturale voorbeelden
    - Gedistribueerde MCP-verwerking over meerdere Azure Functions
    - Hybride transportarchitecturen die meerdere transporttypen combineren
    - Berichtduurzaamheid, betrouwbaarheid en foutafhandelingsstrategieën
  - **Beveiliging & Monitoring**: Integratie met Azure Key Vault en observatiepatronen
    - Authenticatie met beheerde identiteit en toegang met minimaal privilege
    - Telemetrie en prestatiemonitoring met Application Insights
    - Circuit breakers en fouttolerantiepatronen
  - **Testframeworks**: Uitgebreide teststrategieën voor aangepaste transports
    - Unit testing met test doubles en mocking frameworks
    - Integratietests met Azure Test Containers
    - Overwegingen voor prestatie- en belastingtests

#### Context Engineering (05-AdvancedTopics/mcp-contextengineering/) - Opkomende AI-discipline
- **README.md**: Uitgebreide verkenning van context engineering als een opkomend vakgebied
  - **Kernprincipes**: Volledige contextdeling, bewustzijn van actiebeslissingen en beheer van contextvensters
  - **MCP Protocol Afstemming**: Hoe MCP-ontwerp context engineering uitdagingen aanpakt
    - Beperkingen van contextvensters en progressieve laadstrategieën
    - Relevantiebepaling en dynamische contextophaling
    - Multi-modale contextafhandeling en beveiligingsoverwegingen
  - **Implementatiebenaderingen**: Single-threaded versus multi-agent architecturen
    - Context chunking en prioriteringstechnieken
    - Progressieve contextladen en compressiestrategieën
    - Gelaagde contextbenaderingen en optimalisatie van ophaling
  - **Meetkader**: Opkomende metrics voor evaluatie van contexteffectiviteit
    - Inputefficiëntie, prestaties, kwaliteit en gebruikerservaring
    - Experimentele benaderingen voor contextoptimalisatie
    - Foutanalyse en verbeteringsmethodologieën

#### Updates Curriculum Navigatie (README.md)
- **Verbeterde Module Structuur**: Bijgewerkte curriculumtabel met nieuwe geavanceerde onderwerpen
  - Toegevoegd Context Engineering (5.14) en Aangepaste Transport (5.15) vermeldingen
  - Consistente opmaak en navigatielinks in alle modules
  - Bijgewerkte beschrijvingen om de huidige inhoudsscope weer te geven

### Verbeteringen Directorystructuur
- **Naamstandaardisatie**: "mcp transport" hernoemd naar "mcp-transport" voor consistentie met andere geavanceerde onderwerpmappen
- **Inhoudsorganisatie**: Alle 05-AdvancedTopics mappen volgen nu een consistent naamgevingspatroon (mcp-[onderwerp])

### Verbeteringen Documentatiekwaliteit
- **Afstemming MCP Specificatie**: Alle nieuwe inhoud verwijst naar de huidige MCP Specificatie 2025-06-18
- **Meertalige Voorbeelden**: Uitgebreide codevoorbeelden in C#, TypeScript en Python
- **Enterprise Focus**: Productieklare patronen en Azure cloudintegratie door het hele curriculum
- **Visuele Documentatie**: Mermaid diagrammen voor architectuur en stroomvisualisatie

## 18 augustus 2025

### Uitgebreide Update Documentatie - MCP 2025-06-18 Standaarden

#### MCP Beveiligingsbest Practices (02-Security/) - Volledige Modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Volledige herschrijving afgestemd op MCP Specificatie 2025-06-18
  - **Verplichte Vereisten**: Toegevoegd expliciete MOET/MAG NIET vereisten uit de officiële specificatie met duidelijke visuele indicatoren
  - **12 Kernbeveiligingspraktijken**: Herstructurering van een lijst van 15 items naar uitgebreide beveiligingsdomeinen
    - Tokenbeveiliging & Authenticatie met integratie van externe identiteitsproviders
    - Sessiebeheer & Transportbeveiliging met cryptografische vereisten
    - AI-specifieke Dreigingsbescherming met Microsoft Prompt Shields integratie
    - Toegangscontrole & Machtigingen met principe van minimaal privilege
    - Inhoudsveiligheid & Monitoring met Azure Content Safety integratie
    - Leveringsketenbeveiliging met uitgebreide componentverificatie
    - OAuth Beveiliging & Preventie van Verwarde Deputy met PKCE implementatie
    - Incidentrespons & Herstel met geautomatiseerde mogelijkheden
    - Naleving & Governance met reglementaire afstemming
    - Geavanceerde Beveiligingscontroles met zero trust architectuur
    - Microsoft Beveiliging Ecosysteem Integratie met uitgebreide oplossingen
    - Continue Beveiligingsevolutie met adaptieve praktijken
  - **Microsoft Beveiligingsoplossingen**: Verbeterde integratierichtlijnen voor Prompt Shields, Azure Content Safety, Entra ID en GitHub Advanced Security
  - **Implementatiebronnen**: Gecategoriseerde uitgebreide bronnenlinks per Officiële MCP Documentatie, Microsoft Beveiligingsoplossingen, Beveiligingsstandaarden en Implementatiehandleidingen

#### Geavanceerde Beveiligingscontroles (02-Security/) - Enterprise Implementatie
- **MCP-SECURITY-CONTROLS-2025.md**: Volledige revisie met een beveiligingsframework van ondernemingsniveau
  - **9 Uitgebreide Beveiligingsdomeinen**: Uitgebreid van basiscontroles naar gedetailleerd enterprise framework
    - Geavanceerde Authenticatie & Autorisatie met Microsoft Entra ID integratie
    - Tokenbeveiliging & Anti-Passthrough Controles met uitgebreide validatie
    - Sessiebeveiligingscontroles met kapingspreventie
    - AI-specifieke Beveiligingscontroles met promptinjectie en toolvergiftiging preventie
    - Preventie van Verwarde Deputy Aanvallen met OAuth proxy beveiliging
    - Tooluitvoeringsbeveiliging met sandboxing en isolatie
    - Leveringsketenbeveiligingscontroles met afhankelijkheidsverificatie
    - Monitoring & Detectiecontroles met SIEM integratie
    - Incidentrespons & Herstel met geautomatiseerde mogelijkheden
  - **Implementatievoorbeelden**: Toegevoegd gedetailleerde YAML configuratieblokken en codevoorbeelden
  - **Microsoft Oplossingen Integratie**: Uitgebreide dekking van Azure beveiligingsdiensten, GitHub Advanced Security en enterprise identiteitsbeheer

#### Geavanceerde Onderwerpen Beveiliging (05-AdvancedTopics/mcp-security/) - Productieklare Implementatie
- **README.md**: Volledige herschrijving voor enterprise beveiligingsimplementatie
  - **Afstemming Huidige Specificatie**: Bijgewerkt naar MCP Specificatie 2025-06-18 met verplichte beveiligingsvereisten
  - **Verbeterde Authenticatie**: Microsoft Entra ID integratie met uitgebreide .NET en Java Spring Security voorbeelden
  - **AI Beveiligingsintegratie**: Microsoft Prompt Shields en Azure Content Safety implementatie met gedetailleerde Python voorbeelden
  - **Geavanceerde Dreigingsmitigatie**: Uitgebreide implementatievoorbeelden voor
    - Preventie van Verwarde Deputy Aanvallen met PKCE en gebruikersconsentvalidatie
    - Preventie van Token Passthrough met validatie van publiek en veilig tokenbeheer
    - Preventie van Sessiekaping met cryptografische binding en gedragsanalyse
  - **Enterprise Beveiligingsintegratie**: Azure Application Insights monitoring, dreigingsdetectiepijplijnen en leveringsketenbeveiliging
  - **Implementatiechecklist**: Duidelijke verplichte versus aanbevolen beveiligingscontroles met voordelen van Microsoft beveiligingsecosysteem

### Verbeteringen Documentatiekwaliteit & Standaardafstemming
- **Specificatieverwijzingen**: Bijgewerkt alle verwijzingen naar huidige MCP Specificatie 2025-06-18
- **Microsoft Beveiliging Ecosysteem**: Verbeterde integratierichtlijnen door alle beveiligingsdocumentatie heen
- **Praktische Implementatie**: Toegevoegd gedetailleerde codevoorbeelden in .NET, Java en Python met enterprise patronen
- **Bronorganisatie**: Uitgebreide categorisatie van officiële documentatie, beveiligingsstandaarden en implementatiehandleidingen
- **Visuele Indicatoren**: Duidelijke markering van verplichte vereisten versus aanbevolen praktijken

#### Kernconcepten (01-CoreConcepts/) - Volledige Modernisering
- **Protocolversie Update**: Bijgewerkt om te verwijzen naar huidige MCP Specificatie 2025-06-18 met datumgebaseerde versie (YYYY-MM-DD formaat)
- **Architectuurverfijning**: Verbeterde beschrijvingen van Hosts, Clients en Servers om huidige MCP architectuurpatronen te weerspiegelen
  - Hosts nu duidelijk gedefinieerd als AI-toepassingen die meerdere MCP clientverbindingen coördineren
  - Clients beschreven als protocolconnectoren die één-op-één serverrelaties onderhouden
  - Servers verbeterd met lokale versus externe implementatiescenario's
- **Primitieve Herstructurering**: Volledige revisie van server- en clientprimitieven
  - Serverprimitieven: Resources (gegevensbronnen), Prompts (sjablonen), Tools (uitvoerbare functies) met gedetailleerde uitleg en voorbeelden
  - Clientprimitieven: Sampling (LLM voltooiingen), Elicitation (gebruikersinput), Logging (debugging/monitoring)
  - Bijgewerkt met huidige discovery (`*/list`), retrieval (`*/get`) en execution (`*/call`) methodenpatronen
- **Protocolarchitectuur**: Ingevoerd tweelaags architectuurmodel
  - Gegevenslaag: JSON-RPC 2.0 basis met levenscyclusbeheer en primitieven
  - Transportlaag: STDIO (lokaal) en Streamable HTTP met SSE (extern) transportmechanismen
- **Beveiligingsframework**: Uitgebreide beveiligingsprincipes inclusief expliciete gebruikersconsent, gegevensprivacybescherming, tooluitvoeringsveiligheid en transportlaagbeveiliging
- **Communicatiepatronen**: Bijgewerkte protocolberichten om initialisatie, discovery, uitvoering en notificatiestromen te tonen
- **Codevoorbeelden**: Vernieuwde meertalige voorbeelden (.NET, Java, Python, JavaScript) om huidige MCP SDK patronen te weerspiegelen

#### Beveiliging (02-Security/) - Uitgebreide Beveiligingsrevisie  
- **Afstemming Standaarden**: Volledige afstemming met MCP Specificatie 2025-06-18 beveiligingsvereisten
- **Evolutie Authenticatie**: Gedocumenteerde evolutie van aangepaste OAuth servers naar delegatie van externe identiteitsproviders (Microsoft Entra ID)
- **AI-specifieke Dreigingsanalyse**: Verbeterde dekking van moderne AI-aanvalsvectoren
  - Gedetailleerde promptinjectie-aanvalsscenario's met praktijkvoorbeelden
  - Toolvergiftigingsmechanismen en "rug pull" aanvalspatronen
  - Contextvenstervergiftiging en modelverwarringsaanvallen
- **Microsoft AI Beveiligingsoplossingen**: Uitgebreide dekking van Microsoft beveiligingsecosysteem
  - AI Prompt Shields met geavanceerde detectie, spotlighting en delimiter technieken
  - Azure Content Safety integratiepatronen
  - GitHub Advanced Security voor leveringsketenbescherming
- **Geavanceerde Dreigingsmitigatie**: Gedetailleerde beveiligingscontroles voor
  - Sessiekaping met MCP-specifieke aanvalsscenario's en cryptografische sessie-ID vereisten
  - Verwarde deputy problemen in MCP proxy scenario's met expliciete consentvereisten
  - Token passthrough kwetsbaarheden met verplichte validatiecontroles
- **Leveringsketenbeveiliging**: Uitgebreide AI leveringsketendekking inclusief foundation modellen, embeddings services, contextproviders en externe API's
- **Fundamentele Beveiliging**: Verbeterde integratie met enterprise beveiligingspatronen inclusief zero trust architectuur en Microsoft beveiligingsecosysteem
- **Bronorganisatie**: Gecategoriseerde uitgebreide bronnenlinks per type (Officiële Documentatie, Standaarden, Onderzoek, Microsoft Oplossingen, Implementatiehandleidingen)

### Verbeteringen Documentatiekwaliteit
- **Gestructureerde Leerdoelen**: Verbeterde leerdoelen met specifieke, uitvoerbare resultaten 
- **Kruisverwijzingen**: Toegevoegd links tussen gerelateerde beveiligings- en kernconceptonderwerpen
- **Actuele Informatie**: Bijgewerkt alle datums en specificatielinks naar huidige standaarden
- **Implementatierichtlijnen**: Toegevoegd specifieke, uitvoerbare implementatierichtlijnen door beide secties heen

## 16 juli 2025

### README en Navigatieverbeteringen
- Volledig herontworpen curriculum navigatie in README.md
- Vervangen `<details>` tags door meer toegankelijke tabelgebaseerde opmaak
- Alternatieve lay-outopties gemaakt in nieuwe "alternative_layouts" map
- Toegevoegd kaartgebaseerde, tabbladstijl en accordeonstijl navigatievoorbeelden
- Bijgewerkte sectie repositorystructuur om alle nieuwste bestanden op te nemen
- Verbeterde sectie "Hoe gebruik je dit curriculum" met duidelijke aanbevelingen
- Bijgewerkte MCP specificatielinks naar correcte URL's
- Toegevoegd Context Engineering sectie (5.14) aan de curriculumstructuur

### Updates Studiegids
- Volledig herzien studiegids om af te stemmen op huidige repositorystructuur
- Nieuwe secties toegevoegd voor MCP Clients en Tools, en Populaire MCP Servers
- Bijgewerkte Visuele Curriculumkaart om alle onderwerpen nauwkeurig weer te geven
- Verbeterde beschrijvingen van Geavanceerde Onderwerpen om alle gespecialiseerde gebieden te dekken
- Bijgewerkte sectie Case Studies om werkelijke voorbeelden te weerspiegelen
- Toegevoegd deze uitgebreide changelog

### Community Bijdragen (06-CommunityContributions/)
- Gedetailleerde informatie toegevoegd over MCP servers voor beeldgeneratie
- Uitgebreide sectie toegevoegd over het gebruik van Claude in VSCode
- Instructies toegevoegd voor Cline terminal client setup en gebruik
- Bijgewerkte MCP client sectie om alle populaire clientopties op te nemen
- Verbeterde bijdragevoorbeelden met meer nauwkeurige codevoorbeelden

### Geavanceerde Onderwerpen (05-AdvancedTopics/)
- Alle gespecialiseerde onderwerpmappen georganiseerd met consistente naamgeving
- Toegevoegd context engineering materialen en voorbeelden
- Toegevoegd Foundry agent integratiedocumentatie
- Verbeterde Entra ID beveiligingsintegratiedocumentatie

## 11 juni 2025

### Initiële Creatie
- Eerste versie van het MCP voor Beginners curriculum uitgebracht
- Basisstructuur gecreëerd voor alle 10 hoofdsecties
- Visuele Curriculumkaart geïmplementeerd voor navigatie
- Eerste voorbeeldprojecten toegevoegd in meerdere programmeertalen

### Aan de Slag (03-GettingStarted/)
- Eerste serverimplementatievoorbeelden gecreëerd
- Richtlijnen voor clientontwikkeling toegevoegd
- Instructies voor LLM clientintegratie toegevoegd
- Documentatie voor VS Code integratie toegevoegd
- Server-Sent Events (SSE) servervoorbeelden geïmplementeerd

### Kernconcepten (01-CoreConcepts/)
- Gedetailleerde uitleg toegevoegd over client-server architectuur
- Documentatie gecreëerd over belangrijke protocolcomponenten
- Berichtenpatronen in MCP gedocumenteerd

## 23 mei 2025

### Repositorystructuur
- Repository geïnitialiseerd met basismapstructuur
- README bestanden gecreëerd voor elke hoofdsectie
- Vertaalinfrastructuur opgezet
- Afbeeldingsassets en diagrammen toegevoegd

### Documentatie
- Initiële README.md gecreëerd met curriculumoverzicht
- CODE_OF_CONDUCT.md en SECURITY.md toegevoegd
- SUPPORT.md opgezet met richtlijnen voor hulp
- Voorlopige structuur studiegids gecreëerd

## 15 april 2025

### Planning en Framework
- Initiële planning voor MCP voor Beginners curriculum
- Leerdoelen en doelgroep gedefinieerd
- 10-sectie structuur van het curriculum geschetst
- Conceptueel framework ontwikkeld voor voorbeelden en case studies
- Eerste prototypevoorbeelden gecreëerd voor kernconcepten

---

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in zijn oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.