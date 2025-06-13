<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:49:55+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "nl"
}
-->
# Case Study: Azure AI Travel Agents – Referentie-implementatie

## Overzicht

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) is een uitgebreide referentieoplossing ontwikkeld door Microsoft die laat zien hoe je een multi-agent, AI-gestuurde reisplanningsapplicatie kunt bouwen met behulp van het Model Context Protocol (MCP), Azure OpenAI en Azure AI Search. Dit project toont best practices voor het coördineren van meerdere AI-agenten, het integreren van bedrijfsdata en het bieden van een veilige, uitbreidbare platform voor scenario’s uit de praktijk.

## Belangrijkste kenmerken
- **Multi-Agent Orkestratie:** Maakt gebruik van MCP om gespecialiseerde agenten (bijv. flight, hotel en itinerary agenten) te coördineren die samenwerken om complexe reisplanningsopdrachten uit te voeren.
- **Integratie van Bedrijfsdata:** Verbindt met Azure AI Search en andere bedrijfsdatabronnen om actuele, relevante informatie te bieden voor reisaanbevelingen.
- **Veilige, schaalbare architectuur:** Benut Azure-diensten voor authenticatie, autorisatie en schaalbare implementatie, volgens de beste beveiligingspraktijken voor bedrijven.
- **Uitbreidbare tools:** Implementeert herbruikbare MCP-tools en prompt-sjablonen, waardoor snelle aanpassing aan nieuwe domeinen of zakelijke eisen mogelijk is.
- **Gebruikerservaring:** Biedt een conversatie-interface waarmee gebruikers kunnen communiceren met de reisagenten, aangedreven door Azure OpenAI en MCP.

## Architectuur
![Architectuur](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Beschrijving van het architectuurdiagram

De Azure AI Travel Agents-oplossing is ontworpen voor modulariteit, schaalbaarheid en veilige integratie van meerdere AI-agenten en bedrijfsdatabronnen. De belangrijkste componenten en datastromen zijn als volgt:

- **Gebruikersinterface:** Gebruikers communiceren met het systeem via een conversatie-UI (zoals een webchat of Teams-bot), die gebruikersvragen verstuurt en reisaanbevelingen ontvangt.
- **MCP Server:** Dient als centrale orkestrator, ontvangt gebruikersinvoer, beheert context en coördineert de acties van gespecialiseerde agenten (bijv. FlightAgent, HotelAgent, ItineraryAgent) via het Model Context Protocol.
- **AI-agenten:** Elke agent is verantwoordelijk voor een specifiek domein (vluchten, hotels, reisroutes) en is geïmplementeerd als een MCP-tool. Agenten gebruiken prompt-sjablonen en logica om verzoeken te verwerken en antwoorden te genereren.
- **Azure OpenAI Service:** Biedt geavanceerd natuurlijk taalbegrip en -generatie, waardoor agenten de intentie van gebruikers kunnen interpreteren en conversatie-antwoorden kunnen maken.
- **Azure AI Search & Bedrijfsdata:** Agenten raadplegen Azure AI Search en andere bedrijfsdatabronnen om actuele informatie over vluchten, hotels en reisopties op te halen.
- **Authenticatie & Beveiliging:** Integreert met Microsoft Entra ID voor veilige authenticatie en past het principe van minste rechten toe op alle resources.
- **Implementatie:** Ontworpen voor uitrol op Azure Container Apps, wat zorgt voor schaalbaarheid, monitoring en operationele efficiëntie.

Deze architectuur maakt naadloze orkestratie van meerdere AI-agenten mogelijk, veilige integratie met bedrijfsdata en een robuust, uitbreidbaar platform voor het bouwen van domeinspecifieke AI-oplossingen.

## Stapsgewijze uitleg van het architectuurdiagram
Stel je voor dat je een grote reis plant en een team van deskundige assistenten hebt die je bij elk detail helpen. Het Azure AI Travel Agents-systeem werkt op een vergelijkbare manier, met verschillende onderdelen (zoals teamleden) die elk een speciale taak hebben. Zo werkt het allemaal samen:

### Gebruikersinterface (UI):
Zie dit als de balie van je reisagent. Hier stel je vragen of doe je verzoeken, zoals “Vind een vlucht naar Parijs.” Dit kan een chatvenster op een website zijn of een berichtendienst.

### MCP Server (De coördinator):
De MCP Server is als de manager die naar je verzoek luistert bij de balie en beslist welke specialist welk deel moet afhandelen. Hij houdt het gesprek bij en zorgt dat alles soepel verloopt.

### AI-agenten (Specialistische assistenten):
Elke agent is expert op een bepaald gebied – de ene weet alles van vluchten, de andere van hotels, weer een ander van het plannen van je reisroute. Wanneer je een reis vraagt, stuurt de MCP Server je verzoek naar de juiste agent(en). Deze agenten gebruiken hun kennis en tools om de beste opties voor jou te vinden.

### Azure OpenAI Service (Taalexpert):
Dit is alsof je een taalexpert hebt die precies begrijpt wat je vraagt, ongeacht hoe je het formuleert. Het helpt de agenten om je verzoeken te begrijpen en op een natuurlijke, gesprekstoon te reageren.

### Azure AI Search & Bedrijfsdata (Informatiebibliotheek):
Stel je een enorme, altijd actuele bibliotheek voor met de nieuwste reisinfo – vluchtschema’s, hotelbeschikbaarheid en meer. De agenten doorzoeken deze bibliotheek om de meest accurate antwoorden voor jou te vinden.

### Authenticatie & Beveiliging (Beveiligingsbeambte):
Net als een beveiligingsbeambte die controleert wie waar binnen mag, zorgt dit onderdeel ervoor dat alleen geautoriseerde personen en agenten toegang hebben tot gevoelige informatie. Zo blijft jouw data veilig en privé.

### Implementatie op Azure Container Apps (Het gebouw):
Al deze assistenten en tools werken samen binnen een veilig, schaalbaar gebouw (de cloud). Dit betekent dat het systeem veel gebruikers tegelijk aankan en altijd beschikbaar is wanneer jij het nodig hebt.

## Hoe het allemaal samenwerkt:

Je begint met een vraag bij de balie (UI).  
De manager (MCP Server) bepaalt welke specialist (agent) je helpt.  
De specialist gebruikt de taalexpert (OpenAI) om je verzoek te begrijpen en de bibliotheek (AI Search) om het beste antwoord te vinden.  
De beveiligingsbeambte (Authenticatie) zorgt dat alles veilig verloopt.  
Dit alles gebeurt binnen een betrouwbaar, schaalbaar gebouw (Azure Container Apps), zodat jouw ervaring soepel en veilig is.  
Deze samenwerking zorgt ervoor dat het systeem snel en veilig je reis kan plannen, net als een team van deskundige reisagenten die samenwerken in een modern kantoor!

## Technische implementatie
- **MCP Server:** Bevat de kernlogica voor orkestratie, biedt agenttools aan en beheert de context voor meerstaps-reisplanningsworkflows.
- **Agenten:** Elke agent (bijv. FlightAgent, HotelAgent) is geïmplementeerd als een MCP-tool met eigen prompt-sjablonen en logica.
- **Azure-integratie:** Maakt gebruik van Azure OpenAI voor natuurlijk taalbegrip en Azure AI Search voor data-opvraging.
- **Beveiliging:** Integreert met Microsoft Entra ID voor authenticatie en past het principe van minste rechten toe op alle resources.
- **Implementatie:** Ondersteunt uitrol naar Azure Container Apps voor schaalbaarheid en operationele efficiëntie.

## Resultaten en impact
- Laat zien hoe MCP kan worden gebruikt om meerdere AI-agenten te coördineren in een productieklare, praktijkgerichte situatie.
- Versnelt de ontwikkeling van oplossingen door herbruikbare patronen te bieden voor agentcoördinatie, dataintegratie en veilige implementatie.
- Dient als blauwdruk voor het bouwen van domeinspecifieke, AI-gestuurde applicaties met MCP en Azure-diensten.

## Referenties
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.