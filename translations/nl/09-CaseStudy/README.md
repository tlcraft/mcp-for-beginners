<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-14T05:48:16+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "nl"
}
-->
# MCP in Actie: Praktijkvoorbeelden

Het Model Context Protocol (MCP) verandert de manier waarop AI-toepassingen omgaan met data, tools en services. In deze sectie worden praktijkvoorbeelden gepresenteerd die laten zien hoe MCP in verschillende bedrijfsomgevingen wordt toegepast.

## Overzicht

Deze sectie toont concrete voorbeelden van MCP-implementaties en benadrukt hoe organisaties dit protocol gebruiken om complexe zakelijke uitdagingen op te lossen. Door deze cases te bestuderen, krijg je inzicht in de veelzijdigheid, schaalbaarheid en praktische voordelen van MCP in de praktijk.

## Belangrijkste Leerdoelen

Door deze cases te verkennen, zul je:

- Begrijpen hoe MCP kan worden ingezet om specifieke zakelijke problemen op te lossen
- Leren over verschillende integratiepatronen en architecturale benaderingen
- Best practices herkennen voor het implementeren van MCP in bedrijfsomgevingen
- Inzicht krijgen in de uitdagingen en oplossingen die zich voordoen bij implementaties in de praktijk
- Kansen identificeren om vergelijkbare patronen toe te passen in je eigen projecten

## Uitgelichte Praktijkvoorbeelden

### 1. [Azure AI Travel Agents – Referentie-implementatie](./travelagentsample.md)

Deze case onderzoekt Microsofts uitgebreide referentieoplossing die laat zien hoe je een multi-agent, AI-gestuurde reisplanningsapplicatie bouwt met MCP, Azure OpenAI en Azure AI Search. Het project toont:

- Multi-agent orkestratie via MCP
- Integratie van bedrijfsdata met Azure AI Search
- Veilige, schaalbare architectuur met Azure-diensten
- Uitbreidbare tooling met herbruikbare MCP-componenten
- Conversational gebruikerservaring aangedreven door Azure OpenAI

De architectuur en implementatiedetails bieden waardevolle inzichten in het bouwen van complexe multi-agent systemen met MCP als coördinatielaag.

### 2. [Azure DevOps Items bijwerken met YouTube Data](./UpdateADOItemsFromYT.md)

Deze case laat een praktische toepassing van MCP zien voor het automatiseren van workflowprocessen. Het toont hoe MCP-tools kunnen worden gebruikt om:

- Data te extraheren van online platforms (YouTube)
- Werkitems in Azure DevOps bij te werken
- Herhaalbare automatiseringsworkflows te creëren
- Data te integreren tussen verschillende systemen

Dit voorbeeld illustreert hoe zelfs relatief eenvoudige MCP-implementaties aanzienlijke efficiëntiewinst kunnen opleveren door routinetaken te automatiseren en de dataconsistentie tussen systemen te verbeteren.

### 3. [Realtime Documentatie Ophalen met MCP](./docs-mcp/README.md)

Deze case begeleidt je bij het verbinden van een Python console client met een Model Context Protocol (MCP) server om realtime, contextbewuste Microsoft-documentatie op te halen en te loggen. Je leert hoe je:

- Verbindt met een MCP-server via een Python client en de officiële MCP SDK
- Streaming HTTP clients gebruikt voor efficiënte, realtime data-ophaling
- Documentatietools op de server aanroept en reacties direct naar de console logt
- Up-to-date Microsoft-documentatie integreert in je workflow zonder de terminal te verlaten

Het hoofdstuk bevat een praktische opdracht, een minimale werkende codevoorbeeld en links naar aanvullende bronnen voor verdieping. Bekijk de volledige walkthrough en code in het gekoppelde hoofdstuk om te begrijpen hoe MCP de toegang tot documentatie en de productiviteit van ontwikkelaars in console-omgevingen kan transformeren.

### 4. [Interactieve Studieplanner Webapp met MCP](./docs-mcp/README.md)

Deze case laat zien hoe je een interactieve webapplicatie bouwt met Chainlit en het Model Context Protocol (MCP) om gepersonaliseerde studieplannen te genereren voor elk onderwerp. Gebruikers kunnen een onderwerp opgeven (zoals "AI-900 certificering") en een studietijd (bijv. 8 weken), waarna de app een week-tot-week overzicht geeft van aanbevolen content. Chainlit maakt een conversatiegerichte chatinterface mogelijk, wat de ervaring boeiend en adaptief maakt.

- Conversational webapp aangedreven door Chainlit
- Gebruikersgestuurde prompts voor onderwerp en duur
- Week-tot-week contentaanbevelingen met MCP
- Realtime, adaptieve reacties in een chatinterface

Het project toont hoe conversational AI en MCP gecombineerd kunnen worden om dynamische, gebruikersgerichte educatieve tools te creëren in een moderne webomgeving.

### 5. [In-Editor Documentatie met MCP Server in VS Code](./docs-mcp/README.md)

Deze case laat zien hoe je Microsoft Learn Docs direct in je VS Code-omgeving kunt brengen met de MCP-server—geen tabbladen wisselen meer! Je ziet hoe je:

- Direct documenten doorzoekt en leest binnen VS Code via het MCP-paneel of de command palette
- Documentatie verwijst en links invoegt in je README of cursus-markdownbestanden
- GitHub Copilot en MCP samen gebruikt voor naadloze, AI-gestuurde documentatie- en codeworkflows
- Je documentatie valideert en verbetert met realtime feedback en Microsoft-accuratesse
- MCP integreert met GitHub workflows voor continue documentatievalidatie

De implementatie bevat:
- Voorbeeldconfiguratie `.vscode/mcp.json` voor eenvoudige setup
- Screenshot-gebaseerde walkthroughs van de in-editor ervaring
- Tips voor het combineren van Copilot en MCP voor maximale productiviteit

Dit scenario is ideaal voor cursusmakers, documentatieschrijvers en ontwikkelaars die gefocust willen blijven in hun editor terwijl ze werken met docs, Copilot en validatietools—alles aangedreven door MCP.

### 6. [APIM MCP Server Creatie](./apimsample.md)

Deze case biedt een stapsgewijze handleiding voor het maken van een MCP-server met Azure API Management (APIM). Het behandelt:

- Het opzetten van een MCP-server in Azure API Management
- API-operaties blootstellen als MCP-tools
- Policies configureren voor rate limiting en beveiliging
- De MCP-server testen met Visual Studio Code en GitHub Copilot

Dit voorbeeld laat zien hoe je de mogelijkheden van Azure kunt benutten om een robuuste MCP-server te creëren die in diverse toepassingen kan worden gebruikt, en zo de integratie van AI-systemen met bedrijfs-API’s verbetert.

## Conclusie

Deze praktijkvoorbeelden benadrukken de veelzijdigheid en praktische toepassingen van het Model Context Protocol in de echte wereld. Van complexe multi-agent systemen tot gerichte automatiseringsworkflows, MCP biedt een gestandaardiseerde manier om AI-systemen te verbinden met de tools en data die ze nodig hebben om waarde te leveren.

Door deze implementaties te bestuderen, krijg je inzicht in architectuurpatronen, implementatiestrategieën en best practices die je kunt toepassen in je eigen MCP-projecten. De voorbeelden tonen aan dat MCP niet slechts een theoretisch kader is, maar een praktische oplossing voor echte zakelijke uitdagingen.

## Aanvullende Bronnen

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Volgende: Hands on Lab [Streamlining AI Workflows: Building an MCP Server with AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.