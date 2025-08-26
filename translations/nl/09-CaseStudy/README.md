<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-08-18T16:23:59+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "nl"
}
-->
# MCP in Actie: Praktijkvoorbeelden

[![MCP in Actie: Praktijkvoorbeelden](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.nl.png)](https://youtu.be/IxshWb2Az5w)

_(Klik op de afbeelding hierboven om de video van deze les te bekijken)_

Het Model Context Protocol (MCP) verandert de manier waarop AI-toepassingen omgaan met data, tools en diensten. In deze sectie worden praktijkvoorbeelden gepresenteerd die laten zien hoe MCP wordt toegepast in verschillende zakelijke scenario's.

## Overzicht

Deze sectie toont concrete voorbeelden van MCP-implementaties en laat zien hoe organisaties dit protocol gebruiken om complexe zakelijke uitdagingen op te lossen. Door deze cases te bestuderen, krijg je inzicht in de veelzijdigheid, schaalbaarheid en praktische voordelen van MCP in de praktijk.

## Belangrijke Leerdoelen

Door deze praktijkvoorbeelden te verkennen, leer je:

- Hoe MCP kan worden toegepast om specifieke zakelijke problemen op te lossen
- Meer over verschillende integratiepatronen en architecturale benaderingen
- Best practices voor het implementeren van MCP in bedrijfsomgevingen
- Inzicht in de uitdagingen en oplossingen die in de praktijk zijn tegengekomen
- Mogelijkheden herkennen om vergelijkbare patronen toe te passen in je eigen projecten

## Uitgelichte Praktijkvoorbeelden

### 1. [Azure AI Reisagenten – Referentie-implementatie](./travelagentsample.md)

Deze case study onderzoekt de uitgebreide referentieoplossing van Microsoft die laat zien hoe je een multi-agent, AI-gestuurde reisplanningsapplicatie kunt bouwen met MCP, Azure OpenAI en Azure AI Search. Het project toont:

- Multi-agent orkestratie via MCP
- Integratie van bedrijfsdata met Azure AI Search
- Veilige, schaalbare architectuur met Azure-diensten
- Uitbreidbare tools met herbruikbare MCP-componenten
- Conversatiegerichte gebruikerservaring aangedreven door Azure OpenAI

De architectuur en implementatiedetails bieden waardevolle inzichten in het bouwen van complexe, multi-agent systemen met MCP als coördinatielaag.

### 2. [Azure DevOps Items Bijwerken met YouTube Data](./UpdateADOItemsFromYT.md)

Deze case study laat een praktische toepassing van MCP zien voor het automatiseren van werkprocessen. Het toont hoe MCP-tools kunnen worden gebruikt om:

- Data te extraheren van online platforms (YouTube)
- Werkitems bij te werken in Azure DevOps-systemen
- Herhaalbare automatiseringsworkflows te creëren
- Data te integreren tussen verschillende systemen

Dit voorbeeld laat zien hoe zelfs relatief eenvoudige MCP-implementaties aanzienlijke efficiëntiewinsten kunnen opleveren door routinetaken te automatiseren en de consistentie van data tussen systemen te verbeteren.

### 3. [Realtime Documentatie Ophalen met MCP](./docs-mcp/README.md)

Deze case study begeleidt je bij het verbinden van een Python-consoleclient met een Model Context Protocol (MCP)-server om realtime, contextbewuste Microsoft-documentatie op te halen en te loggen. Je leert hoe je:

- Verbindt met een MCP-server met behulp van een Python-client en de officiële MCP SDK
- Streaming HTTP-clients gebruikt voor efficiënte, realtime data-ophaling
- Documentatietools op de server aanroept en reacties direct naar de console logt
- Up-to-date Microsoft-documentatie integreert in je workflow zonder de terminal te verlaten

Het hoofdstuk bevat een hands-on opdracht, een minimale werkende codevoorbeeld en links naar aanvullende bronnen voor verdere verdieping. Bekijk de volledige walkthrough en code in het gekoppelde hoofdstuk om te begrijpen hoe MCP documentatietoegang en ontwikkelaarsproductiviteit in console-gebaseerde omgevingen kan transformeren.

### 4. [Interactieve Studieplan Generator Webapp met MCP](./docs-mcp/README.md)

Deze case study laat zien hoe je een interactieve webapplicatie kunt bouwen met Chainlit en het Model Context Protocol (MCP) om gepersonaliseerde studieplannen te genereren voor elk onderwerp. Gebruikers kunnen een onderwerp specificeren (zoals "AI-900 certificering") en een studieduur (bijvoorbeeld 8 weken), en de app biedt een week-tot-week overzicht van aanbevolen inhoud. Chainlit zorgt voor een conversatiegerichte chatinterface, wat de ervaring boeiend en adaptief maakt.

- Conversatiegerichte webapp aangedreven door Chainlit
- Gebruikersgestuurde prompts voor onderwerp en duur
- Week-tot-week inhoudsaanbevelingen met MCP
- Realtime, adaptieve reacties in een chatinterface

Het project illustreert hoe conversatie-AI en MCP kunnen worden gecombineerd om dynamische, gebruikersgestuurde educatieve tools te creëren in een moderne webomgeving.

### 5. [In-Editor Documentatie met MCP Server in VS Code](./docs-mcp/README.md)

Deze case study laat zien hoe je Microsoft Learn-documentatie rechtstreeks in je VS Code-omgeving kunt brengen met behulp van de MCP-server—geen tabbladen meer wisselen! Je leert hoe je:

- Direct documentatie zoekt en leest in VS Code via het MCP-paneel of de opdrachtpalet
- Documentatie verwijst en links direct invoegt in je README of cursusmarkdownbestanden
- GitHub Copilot en MCP samen gebruikt voor naadloze, AI-gestuurde documentatie- en codeworkflows
- Je documentatie valideert en verbetert met realtime feedback en Microsoft-bronnen
- MCP integreert met GitHub-workflows voor continue documentatievalidatie

De implementatie omvat:

- Een voorbeeld `.vscode/mcp.json` configuratie voor eenvoudige setup
- Walkthroughs met screenshots van de in-editor ervaring
- Tips voor het combineren van Copilot en MCP voor maximale productiviteit

Dit scenario is ideaal voor cursusmakers, documentatieschrijvers en ontwikkelaars die zich willen concentreren in hun editor terwijl ze werken met documentatie, Copilot en validatietools—allemaal aangedreven door MCP.

### 6. [APIM MCP Server Maken](./apimsample.md)

Deze case study biedt een stapsgewijze handleiding voor het maken van een MCP-server met Azure API Management (APIM). Het behandelt:

- Het opzetten van een MCP-server in Azure API Management
- API-operaties blootstellen als MCP-tools
- Beleid configureren voor snelheidslimieten en beveiliging
- De MCP-server testen met Visual Studio Code en GitHub Copilot

Dit voorbeeld laat zien hoe je de mogelijkheden van Azure kunt benutten om een robuuste MCP-server te creëren die in verschillende toepassingen kan worden gebruikt, waardoor de integratie van AI-systemen met bedrijfs-API's wordt verbeterd.

## Conclusie

Deze praktijkvoorbeelden benadrukken de veelzijdigheid en praktische toepassingen van het Model Context Protocol in de echte wereld. Van complexe multi-agent systemen tot gerichte automatiseringsworkflows, MCP biedt een gestandaardiseerde manier om AI-systemen te verbinden met de tools en data die ze nodig hebben om waarde te leveren.

Door deze implementaties te bestuderen, kun je inzicht krijgen in architectuurpatronen, implementatiestrategieën en best practices die je kunt toepassen op je eigen MCP-projecten. De voorbeelden laten zien dat MCP niet alleen een theoretisch kader is, maar een praktische oplossing voor echte zakelijke uitdagingen.

## Aanvullende Bronnen

- [Azure AI Reisagenten GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Volgende: Hands-on Lab [AI Workflows Stroomlijnen: Een MCP Server Bouwen met AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.