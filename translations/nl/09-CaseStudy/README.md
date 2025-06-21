<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "671162f2687253f22af11187919ed02d",
  "translation_date": "2025-06-21T13:57:36+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "nl"
}
-->
# MCP in Actie: Praktijkvoorbeelden

Het Model Context Protocol (MCP) verandert de manier waarop AI-toepassingen omgaan met data, tools en services. In deze sectie vind je praktijkvoorbeelden die laten zien hoe MCP in verschillende bedrijfsomgevingen wordt toegepast.

## Overzicht

Deze sectie toont concrete voorbeelden van MCP-implementaties en benadrukt hoe organisaties dit protocol inzetten om complexe zakelijke uitdagingen op te lossen. Door deze casestudy’s te bestuderen, krijg je inzicht in de veelzijdigheid, schaalbaarheid en praktische voordelen van MCP in de praktijk.

## Belangrijkste Leerdoelen

Door deze casestudy’s te verkennen, zul je:

- Begrijpen hoe MCP kan worden ingezet om specifieke zakelijke problemen aan te pakken
- Leren over verschillende integratiepatronen en architecturale benaderingen
- Best practices herkennen voor het implementeren van MCP in bedrijfsomgevingen
- Inzicht krijgen in uitdagingen en oplossingen die zijn tegengekomen bij implementaties in de praktijk
- Kansen ontdekken om vergelijkbare patronen toe te passen in je eigen projecten

## Uitgelichte Casestudy’s

### 1. [Azure AI Travel Agents – Referentie-implementatie](./travelagentsample.md)

Deze casestudy onderzoekt Microsofts uitgebreide referentieoplossing die laat zien hoe je een multi-agent, AI-gestuurde reisplanningsapplicatie bouwt met MCP, Azure OpenAI en Azure AI Search. Het project toont onder andere:

- Multi-agent orkestratie via MCP
- Integratie van bedrijfsdata met Azure AI Search
- Veilige, schaalbare architectuur met Azure-diensten
- Uitbreidbare tooling met herbruikbare MCP-componenten
- Conversational gebruikerservaring aangedreven door Azure OpenAI

De architectuur en implementatiedetails bieden waardevolle inzichten in het bouwen van complexe multi-agent systemen met MCP als coördinatielaag.

### 2. [Azure DevOps-items bijwerken met YouTube-data](./UpdateADOItemsFromYT.md)

Deze casestudy laat een praktische toepassing van MCP zien voor het automatiseren van workflowprocessen. Het toont hoe MCP-tools kunnen worden ingezet om:

- Data te extraheren van online platforms (YouTube)
- Werkitems in Azure DevOps bij te werken
- Herhaalbare automatiseringsworkflows te creëren
- Data te integreren tussen verschillende systemen

Dit voorbeeld illustreert hoe zelfs relatief eenvoudige MCP-implementaties aanzienlijke efficiëntiewinst kunnen opleveren door routinetaken te automatiseren en de dataconsistentie tussen systemen te verbeteren.

### 3. [Realtime documentatie ophalen met MCP](./docs-mcp/README.md)

Deze casestudy begeleidt je bij het verbinden van een Python consoleclient met een Model Context Protocol (MCP) server om realtime, contextbewuste Microsoft-documentatie op te halen en te loggen. Je leert hoe je:

- Verbindt met een MCP-server via een Python client en de officiële MCP SDK
- Streaming HTTP-clients gebruikt voor efficiënte, realtime dataopvraging
- Documentatietools op de server aanroept en reacties direct in de console logt
- Up-to-date Microsoft-documentatie integreert in je workflow zonder de terminal te verlaten

Het hoofdstuk bevat een praktische opdracht, een minimale werkende codevoorbeeld en links naar aanvullende bronnen voor verdieping. Bekijk de volledige walkthrough en code in het gelinkte hoofdstuk om te begrijpen hoe MCP toegang tot documentatie en ontwikkelaarsproductiviteit in console-omgevingen kan transformeren.

### 4. [Interactieve studieplangenerator webapp met MCP](./docs-mcp/README.md)

Deze casestudy laat zien hoe je een interactieve webapp bouwt met Chainlit en het Model Context Protocol (MCP) om gepersonaliseerde studieplannen te genereren voor elk onderwerp. Gebruikers kunnen een onderwerp opgeven (zoals "AI-900 certificering") en een studietijd (bijv. 8 weken), waarna de app een week-tot-week overzicht van aanbevolen content geeft. Chainlit zorgt voor een conversatiegerichte chatinterface, waardoor de ervaring boeiend en adaptief is.

- Conversational webapp aangedreven door Chainlit
- Gebruikersgestuurde prompts voor onderwerp en duur
- Week-tot-week contentaanbevelingen via MCP
- Realtime, adaptieve reacties in een chatinterface

Het project laat zien hoe conversational AI en MCP gecombineerd kunnen worden om dynamische, gebruikersgerichte educatieve tools te creëren in een moderne webomgeving.

### 5. [In-editor documentatie met MCP-server in VS Code](./docs-mcp/README.md)

Deze casestudy laat zien hoe je Microsoft Learn Docs rechtstreeks in je VS Code-omgeving kunt brengen met de MCP-server—geen tabbladen meer wisselen! Je ziet hoe je:

- Direct documenten kunt zoeken en lezen binnen VS Code via het MCP-paneel of de command palette
- Documentatie kunt refereren en links direct kunt invoegen in je README- of cursus-markdownbestanden
- GitHub Copilot en MCP samen gebruikt voor naadloze, AI-gestuurde documentatie- en codeworkflows
- Documentatie valideert en verbetert met realtime feedback en Microsoft-gekoppelde nauwkeurigheid
- MCP integreert met GitHub-workflows voor continue documentatievalidatie

De implementatie bevat:
- Voorbeeld `.vscode/mcp.json` configuratie voor eenvoudige setup
- Screenshot-gebaseerde walkthroughs van de in-editor ervaring
- Tips voor het combineren van Copilot en MCP voor maximale productiviteit

Deze toepassing is ideaal voor cursusmakers, documentatieschrijvers en ontwikkelaars die gefocust willen blijven in hun editor terwijl ze werken met docs, Copilot en validatietools—alles aangedreven door MCP.

## Conclusie

Deze casestudy’s benadrukken de veelzijdigheid en praktische toepassingen van het Model Context Protocol in de praktijk. Van complexe multi-agent systemen tot gerichte automatiseringsworkflows, MCP biedt een gestandaardiseerde manier om AI-systemen te verbinden met de tools en data die ze nodig hebben om waarde te leveren.

Door deze implementaties te bestuderen, krijg je inzicht in architectuurpatronen, implementatiestrategieën en best practices die je kunt toepassen in je eigen MCP-projecten. De voorbeelden laten zien dat MCP niet alleen een theoretisch kader is, maar een praktische oplossing voor echte zakelijke uitdagingen.

## Aanvullende bronnen

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.