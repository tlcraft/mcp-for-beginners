<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T16:23:14+00:00",
  "source_file": "changelog.md",
  "language_code": "nl"
}
-->
# Changelog: MCP voor Beginners Curriculum

Dit document dient als een overzicht van alle belangrijke wijzigingen in het Model Context Protocol (MCP) voor Beginners curriculum. Wijzigingen worden in omgekeerde chronologische volgorde gedocumenteerd (nieuwste wijzigingen eerst).

## 18 augustus 2025

### Uitgebreide Documentatie-update - MCP 2025-06-18 Standaarden

#### MCP Beveiligingspraktijken (02-Security/) - Volledige Modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Volledige herschrijving in lijn met MCP Specificatie 2025-06-18
  - **Verplichte Vereisten**: Toevoeging van expliciete MOET/MAG NIET vereisten uit de officiële specificatie met duidelijke visuele aanduidingen
  - **12 Kernbeveiligingspraktijken**: Herstructurering van een lijst van 15 items naar uitgebreide beveiligingsdomeinen
    - Tokenbeveiliging & Authenticatie met integratie van externe identiteitsproviders
    - Sessiebeheer & Transportbeveiliging met cryptografische vereisten
    - AI-specifieke Dreigingsbescherming met Microsoft Prompt Shields integratie
    - Toegangscontrole & Machtigingen volgens het principe van minimale rechten
    - Inhoudsveiligheid & Monitoring met Azure Content Safety integratie
    - Beveiliging van de Leveringsketen met uitgebreide componentverificatie
    - OAuth-beveiliging & Voorkoming van Confused Deputy-aanvallen met PKCE-implementatie
    - Incidentrespons & Herstel met geautomatiseerde mogelijkheden
    - Naleving & Governance met regelgevende afstemming
    - Geavanceerde Beveiligingscontroles met zero trust architectuur
    - Integratie met Microsoft Beveiligingsecosysteem met uitgebreide oplossingen
    - Continue Beveiligingsevolutie met adaptieve praktijken
  - **Microsoft Beveiligingsoplossingen**: Verbeterde integratierichtlijnen voor Prompt Shields, Azure Content Safety, Entra ID en GitHub Advanced Security
  - **Implementatiebronnen**: Geordende uitgebreide bronnenlinks per categorie: Officiële MCP Documentatie, Microsoft Beveiligingsoplossingen, Beveiligingsstandaarden en Implementatiehandleidingen

#### Geavanceerde Beveiligingscontroles (02-Security/) - Implementatie op Ondernemingsniveau
- **MCP-SECURITY-CONTROLS-2025.md**: Volledige herziening met een beveiligingsraamwerk op ondernemingsniveau
  - **9 Uitgebreide Beveiligingsdomeinen**: Uitgebreid van basiscontroles naar een gedetailleerd ondernemingsraamwerk
    - Geavanceerde Authenticatie & Autorisatie met Microsoft Entra ID integratie
    - Tokenbeveiliging & Anti-Passthrough Controles met uitgebreide validatie
    - Sessiebeveiligingscontroles met kapingpreventie
    - AI-specifieke Beveiligingscontroles met preventie van promptinjectie en toolvergiftiging
    - Voorkoming van Confused Deputy-aanvallen met OAuth proxy beveiliging
    - Tooluitvoeringsbeveiliging met sandboxing en isolatie
    - Beveiligingscontroles voor de Leveringsketen met afhankelijkheidsverificatie
    - Monitoring & Detectiecontroles met SIEM-integratie
    - Incidentrespons & Herstel met geautomatiseerde mogelijkheden
  - **Implementatievoorbeelden**: Toevoeging van gedetailleerde YAML-configuratieblokken en codevoorbeelden
  - **Integratie van Microsoft Oplossingen**: Uitgebreide dekking van Azure beveiligingsdiensten, GitHub Advanced Security en ondernemingsidentiteitsbeheer

#### Geavanceerde Onderwerpen Beveiliging (05-AdvancedTopics/mcp-security/) - Productieklaar Implementeren
- **README.md**: Volledige herschrijving voor beveiligingsimplementatie op ondernemingsniveau
  - **Huidige Specificatie-afstemming**: Bijgewerkt naar MCP Specificatie 2025-06-18 met verplichte beveiligingsvereisten
  - **Verbeterde Authenticatie**: Microsoft Entra ID integratie met uitgebreide .NET en Java Spring Security voorbeelden
  - **AI Beveiligingsintegratie**: Microsoft Prompt Shields en Azure Content Safety implementatie met gedetailleerde Pythonvoorbeelden
  - **Geavanceerde Dreigingsmitigatie**: Uitgebreide implementatievoorbeelden voor
    - Voorkoming van Confused Deputy-aanvallen met PKCE en gebruikersconsentvalidatie
    - Voorkoming van Token Passthrough met validatie van doelgroepen en veilig tokenbeheer
    - Voorkoming van Sessiekaping met cryptografische binding en gedragsanalyse
  - **Integratie van Ondernemingsbeveiliging**: Azure Application Insights monitoring, dreigingsdetectiepijplijnen en beveiliging van de leveringsketen
  - **Implementatiechecklist**: Duidelijke verplichte versus aanbevolen beveiligingscontroles met voordelen van het Microsoft beveiligingsecosysteem

### Documentatiekwaliteit & Standaardafstemming
- **Specificatieverwijzingen**: Alle verwijzingen bijgewerkt naar de huidige MCP Specificatie 2025-06-18
- **Microsoft Beveiligingsecosysteem**: Verbeterde integratierichtlijnen in alle beveiligingsdocumentatie
- **Praktische Implementatie**: Toevoeging van gedetailleerde codevoorbeelden in .NET, Java en Python met ondernemingspatronen
- **Bronorganisatie**: Uitgebreide categorisatie van officiële documentatie, beveiligingsstandaarden en implementatiehandleidingen
- **Visuele Aanduidingen**: Duidelijke markering van verplichte vereisten versus aanbevolen praktijken

#### Kernconcepten (01-CoreConcepts/) - Volledige Modernisering
- **Protocolversie-update**: Bijgewerkt naar de huidige MCP Specificatie 2025-06-18 met datumgebaseerde versie-indeling (YYYY-MM-DD formaat)
- **Architectuurverfijning**: Verbeterde beschrijvingen van Hosts, Clients en Servers om huidige MCP-architectuurpatronen te weerspiegelen
  - Hosts nu duidelijk gedefinieerd als AI-toepassingen die meerdere MCP-clientverbindingen coördineren
  - Clients beschreven als protocolconnectoren die één-op-één serverrelaties onderhouden
  - Servers verbeterd met lokale versus externe implementatiescenario's
- **Herstructurering van Primitieven**: Volledige herziening van server- en clientprimitieven
  - Serverprimitieven: Resources (gegevensbronnen), Prompts (sjablonen), Tools (uitvoerbare functies) met gedetailleerde uitleg en voorbeelden
  - Clientprimitieven: Sampling (LLM-voltooiingen), Elicitation (gebruikersinvoer), Logging (debuggen/monitoren)
  - Bijgewerkt met huidige ontdekking (`*/list`), ophalen (`*/get`) en uitvoering (`*/call`) methodepatronen
- **Protocolarchitectuur**: Invoering van een tweelaags architectuurmodel
  - Gegevenslaag: JSON-RPC 2.0 basis met levenscyclusbeheer en primitieven
  - Transportlaag: STDIO (lokaal) en Streamable HTTP met SSE (extern) transportmechanismen
- **Beveiligingsraamwerk**: Uitgebreide beveiligingsprincipes inclusief expliciete gebruikersconsent, gegevensprivacybescherming, tooluitvoeringsveiligheid en transportlaagbeveiliging
- **Communicatiepatronen**: Bijgewerkte protocolberichten om initialisatie, ontdekking, uitvoering en notificatiestromen te tonen
- **Codevoorbeelden**: Vernieuwde meertalige voorbeelden (.NET, Java, Python, JavaScript) om huidige MCP SDK-patronen te weerspiegelen

#### Beveiliging (02-Security/) - Uitgebreide Beveiligingsoverhaul  
- **Standaardafstemming**: Volledige afstemming met MCP Specificatie 2025-06-18 beveiligingsvereisten
- **Evolutie van Authenticatie**: Gedocumenteerde overgang van aangepaste OAuth-servers naar delegatie van externe identiteitsproviders (Microsoft Entra ID)
- **AI-specifieke Dreigingsanalyse**: Verbeterde dekking van moderne AI-aanvalsvectoren
  - Gedetailleerde scenario's van promptinjectie-aanvallen met praktijkvoorbeelden
  - Mechanismen voor toolvergiftiging en "rug pull" aanvalspatronen
  - Contextvenstervergiftiging en modelverwarringsaanvallen
- **Microsoft AI Beveiligingsoplossingen**: Uitgebreide dekking van Microsoft beveiligingsecosysteem
  - AI Prompt Shields met geavanceerde detectie, spotlighting en delimitertechnieken
  - Azure Content Safety integratiepatronen
  - GitHub Advanced Security voor bescherming van de leveringsketen
- **Geavanceerde Dreigingsmitigatie**: Gedetailleerde beveiligingscontroles voor
  - Sessiekaping met MCP-specifieke aanvalsscenario's en cryptografische sessie-ID vereisten
  - Confused deputy problemen in MCP proxy-scenario's met expliciete consentvereisten
  - Token passthrough kwetsbaarheden met verplichte validatiecontroles
- **Beveiliging van de Leveringsketen**: Uitgebreide dekking van AI-leveringsketen inclusief foundation modellen, embeddingsdiensten, contextproviders en externe API's
- **Fundamentele Beveiliging**: Verbeterde integratie met ondernemingsbeveiligingspatronen inclusief zero trust architectuur en Microsoft beveiligingsecosysteem
- **Bronorganisatie**: Geordende uitgebreide bronnenlinks per type (Officiële Documentatie, Standaarden, Onderzoek, Microsoft Oplossingen, Implementatiehandleidingen)

### Documentatiekwaliteitsverbeteringen
- **Gestructureerde Leerdoelen**: Verbeterde leerdoelen met specifieke, uitvoerbare resultaten
- **Kruisverwijzingen**: Toevoeging van links tussen gerelateerde beveiligings- en kernconceptonderwerpen
- **Actuele Informatie**: Bijgewerkt alle datums en specificatielinks naar huidige standaarden
- **Implementatierichtlijnen**: Toevoeging van specifieke, uitvoerbare implementatierichtlijnen doorheen beide secties

## 16 juli 2025

### README en Navigatieverbeteringen
- Volledig herontworpen navigatie in README.md
- `<details>` tags vervangen door toegankelijkere tabelgebaseerde indeling
- Nieuwe alternatieve lay-outopties toegevoegd in de map "alternative_layouts"
- Voorbeelden toegevoegd van kaartgebaseerde, tabbladstijl- en accordeonstijl-navigatie
- Bijgewerkte repositorystructuursectie met alle nieuwste bestanden
- Verbeterde sectie "Hoe gebruik je dit curriculum" met duidelijke aanbevelingen
- Bijgewerkte MCP-specificatielinks naar de juiste URL's
- Sectie Context Engineering (5.14) toegevoegd aan de curriculumstructuur

### Studiegidsupdates
- Volledig herziene studiegids om af te stemmen op de huidige repositorystructuur
- Nieuwe secties toegevoegd voor MCP Clients en Tools, en Populaire MCP Servers
- Visuele Curriculumkaart bijgewerkt om alle onderwerpen nauwkeurig weer te geven
- Beschrijvingen van Geavanceerde Onderwerpen verbeterd om alle gespecialiseerde gebieden te dekken
- Sectie Casestudies bijgewerkt met actuele voorbeelden
- Deze uitgebreide changelog toegevoegd

### Communitybijdragen (06-CommunityContributions/)
- Gedetailleerde informatie toegevoegd over MCP-servers voor beeldgeneratie
- Uitgebreide sectie toegevoegd over het gebruik van Claude in VSCode
- Instructies toegevoegd voor het instellen en gebruiken van de Cline terminalclient
- Sectie MCP-clients bijgewerkt met alle populaire clientopties
- Bijdragevoorbeelden verbeterd met nauwkeurigere codevoorbeelden

### Geavanceerde Onderwerpen (05-AdvancedTopics/)
- Alle gespecialiseerde onderwerpmapnamen consistent georganiseerd
- Materiaal en voorbeelden voor context engineering toegevoegd
- Documentatie voor Foundry-agentintegratie toegevoegd
- Documentatie voor Entra ID beveiligingsintegratie verbeterd

## 11 juni 2025

### Eerste Creatie
- Eerste versie van het MCP voor Beginners curriculum uitgebracht
- Basisstructuur voor alle 10 hoofdsecties gecreëerd
- Visuele Curriculumkaart geïmplementeerd voor navigatie
- Eerste voorbeeldprojecten toegevoegd in meerdere programmeertalen

### Aan de Slag (03-GettingStarted/)
- Eerste serverimplementatievoorbeelden gecreëerd
- Richtlijnen voor clientontwikkeling toegevoegd
- Instructies voor LLM-clientintegratie toegevoegd
- Documentatie voor VS Code-integratie toegevoegd
- Voorbeelden van Server-Sent Events (SSE) servers geïmplementeerd

### Kernconcepten (01-CoreConcepts/)
- Gedetailleerde uitleg toegevoegd over client-serverarchitectuur
- Documentatie gecreëerd over belangrijke protocolcomponenten
- Berichtenpatronen in MCP gedocumenteerd

## 23 mei 2025

### Repositorystructuur
- Repository geïnitialiseerd met basisstructuur
- README-bestanden gecreëerd voor elke hoofdsectie
- Vertaalinfrastructuur opgezet
- Afbeeldingsbestanden en diagrammen toegevoegd

### Documentatie
- Eerste README.md met curriculumoverzicht gecreëerd
- CODE_OF_CONDUCT.md en SECURITY.md toegevoegd
- SUPPORT.md opgezet met hulpinstructies
- Voorlopige structuur voor studiegids gecreëerd

## 15 april 2025

### Planning en Raamwerk
- Eerste planning voor MCP voor Beginners curriculum
- Leerdoelen en doelgroep gedefinieerd
- 10-sectie structuur van het curriculum geschetst
- Conceptueel raamwerk voor voorbeelden en casestudies ontwikkeld
- Eerste prototypevoorbeelden voor kernconcepten gecreëerd

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we ons best doen voor nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.