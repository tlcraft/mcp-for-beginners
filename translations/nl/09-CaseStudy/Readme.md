<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:30:49+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "nl"
}
-->
# Case Study: Azure AI Travel Agents – Referentie-implementatie

## Overzicht

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) is een uitgebreide referentieoplossing ontwikkeld door Microsoft die demonstreert hoe je een multi-agent, AI-gestuurde reisplanningsapplicatie bouwt met behulp van het Model Context Protocol (MCP), Azure OpenAI en Azure AI Search. Dit project toont best practices voor het orkestreren van meerdere AI-agenten, het integreren van bedrijfsdata en het bieden van een veilig, uitbreidbaar platform voor realistische scenario's.

## Belangrijkste Kenmerken
- **Multi-Agent Orkestratie:** Maakt gebruik van MCP om gespecialiseerde agenten (bijv. vlucht-, hotel- en reisroute-agenten) te coördineren die samenwerken om complexe reisplanningsopdrachten uit te voeren.
- **Integratie van Bedrijfsdata:** Verbindt met Azure AI Search en andere bedrijfsdatasystemen om actuele, relevante informatie te bieden voor reisaanbevelingen.
- **Veilige, Schaalbare Architectuur:** Benut Azure-diensten voor authenticatie, autorisatie en schaalbare implementatie, volgens de beste praktijken voor bedrijfsbeveiliging.
- **Uitbreidbare Tools:** Implementeert herbruikbare MCP-tools en prompt-sjablonen, waarmee snelle aanpassing aan nieuwe domeinen of bedrijfsvereisten mogelijk is.
- **Gebruikerservaring:** Biedt een conversatie-interface voor gebruikers om te communiceren met de reisagenten, aangedreven door Azure OpenAI en MCP.

## Architectuur
![Architectuur](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Beschrijving van het Architectuurdiagram

De Azure AI Travel Agents-oplossing is ontworpen voor modulariteit, schaalbaarheid en veilige integratie van meerdere AI-agenten en bedrijfsdatasystemen. De belangrijkste componenten en gegevensstromen zijn als volgt:

- **Gebruikersinterface:** Gebruikers communiceren met het systeem via een conversatie-UI (zoals een webchat of Teams-bot), die gebruikersvragen verstuurt en reisaanbevelingen ontvangt.
- **MCP Server:** Dient als de centrale orkestrator, ontvangt gebruikersinvoer, beheert context en coördineert de acties van gespecialiseerde agenten (bijv. FlightAgent, HotelAgent, ItineraryAgent) via het Model Context Protocol.
- **AI Agenten:** Elke agent is verantwoordelijk voor een specifiek domein (vluchten, hotels, reisroutes) en is geïmplementeerd als een MCP-tool. Agenten gebruiken prompt-sjablonen en logica om verzoeken te verwerken en reacties te genereren.
- **Azure OpenAI Service:** Biedt geavanceerd begrip en generatie van natuurlijke taal, waardoor agenten gebruikersintenties kunnen interpreteren en conversatiereacties kunnen genereren.
- **Azure AI Search & Bedrijfsdata:** Agenten raadplegen Azure AI Search en andere bedrijfsdatasystemen om actuele informatie over vluchten, hotels en reismogelijkheden op te halen.
- **Authenticatie & Beveiliging:** Integreert met Microsoft Entra ID voor veilige authenticatie en past minimaal toegangsprivilege toe op alle bronnen.
- **Implementatie:** Ontworpen voor implementatie op Azure Container Apps, wat schaalbaarheid, monitoring en operationele efficiëntie garandeert.

Deze architectuur maakt naadloze orkestratie van meerdere AI-agenten mogelijk, veilige integratie met bedrijfsdata en een robuust, uitbreidbaar platform voor het bouwen van domeinspecifieke AI-oplossingen.

## Stapsgewijze Uitleg van het Architectuurdiagram
Stel je voor dat je een grote reis plant en een team van deskundige assistenten hebt die je met elk detail helpen. Het Azure AI Travel Agents-systeem werkt op een vergelijkbare manier, met verschillende onderdelen (zoals teamleden) die elk een speciale taak hebben. Zo past alles in elkaar:

### Gebruikersinterface (UI):
Denk aan dit als de balie van je reisagent. Hier stel je (de gebruiker) vragen of doe je verzoeken, zoals "Zoek een vlucht naar Parijs." Dit kan een chatvenster op een website of een berichtenapp zijn.

### MCP Server (De Coördinator):
De MCP Server is als de manager die je verzoek aan de balie hoort en beslist welke specialist elk onderdeel moet afhandelen. Het houdt je gesprek bij en zorgt ervoor dat alles soepel verloopt.

### AI Agenten (Specialistische Assistenten):
Elke agent is een expert in een specifiek gebied—de een weet alles over vluchten, de ander over hotels, en weer een ander over het plannen van je reisroute. Wanneer je om een reis vraagt, stuurt de MCP Server je verzoek naar de juiste agent(en). Deze agenten gebruiken hun kennis en tools om de beste opties voor je te vinden.

### Azure OpenAI Service (Taalexpert):
Dit is als een taalexpert die precies begrijpt wat je vraagt, ongeacht hoe je het formuleert. Het helpt de agenten om je verzoeken te begrijpen en te reageren in natuurlijke, conversatie-taal.

### Azure AI Search & Bedrijfsdata (Informatiebibliotheek):
Stel je een enorme, actuele bibliotheek voor met alle nieuwste reisinfo—vluchtschema's, hotelbeschikbaarheid en meer. De agenten doorzoeken deze bibliotheek om de meest nauwkeurige antwoorden voor je te vinden.

### Authenticatie & Beveiliging (Beveiligingsbewaker):
Net zoals een beveiligingsbewaker controleert wie toegang heeft tot bepaalde gebieden, zorgt dit onderdeel ervoor dat alleen geautoriseerde personen en agenten toegang hebben tot gevoelige informatie. Het houdt je gegevens veilig en privé.

### Implementatie op Azure Container Apps (Het Gebouw):
Al deze assistenten en tools werken samen binnen een veilig, schaalbaar gebouw (de cloud). Dit betekent dat het systeem veel gebruikers tegelijk aankan en altijd beschikbaar is wanneer je het nodig hebt.

## Hoe alles samenwerkt:

Je begint met een vraag bij de balie (UI).
De manager (MCP Server) bepaalt welke specialist (agent) je moet helpen.
De specialist gebruikt de taalexpert (OpenAI) om je verzoek te begrijpen en de bibliotheek (AI Search) om het beste antwoord te vinden.
De beveiligingsbewaker (Authenticatie) zorgt ervoor dat alles veilig is.
Dit alles gebeurt binnen een betrouwbaar, schaalbaar gebouw (Azure Container Apps), zodat je ervaring soepel en veilig is.
Deze samenwerking stelt het systeem in staat om je snel en veilig te helpen bij het plannen van je reis, net zoals een team van deskundige reisagenten die samen werken in een modern kantoor!

## Technische Implementatie
- **MCP Server:** Host de kernorkestratielogica, stelt agent-tools bloot en beheert context voor multi-step reisplanningsworkflows.
- **Agenten:** Elke agent (bijv. FlightAgent, HotelAgent) is geïmplementeerd als een MCP-tool met eigen prompt-sjablonen en logica.
- **Azure-integratie:** Gebruikt Azure OpenAI voor natuurlijk taalbegrip en Azure AI Search voor gegevensopvraging.
- **Beveiliging:** Integreert met Microsoft Entra ID voor authenticatie en past minimaal toegangsprivilege toe op alle bronnen.
- **Implementatie:** Ondersteunt implementatie naar Azure Container Apps voor schaalbaarheid en operationele efficiëntie.

## Resultaten en Impact
- Demonstreert hoe MCP kan worden gebruikt om meerdere AI-agenten te orkestreren in een realistische, productieklare situatie.
- Versnelt oplossingontwikkeling door herbruikbare patronen te bieden voor agentcoördinatie, gegevensintegratie en veilige implementatie.
- Dient als een blauwdruk voor het bouwen van domeinspecifieke, AI-gestuurde applicaties met behulp van MCP en Azure-diensten.

## Referenties
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we ons best doen voor nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in zijn oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.