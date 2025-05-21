<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:40:52+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "nl"
}
-->
# Case Study: Azure AI Travel Agents – Referentie-implementatie

## Overzicht

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) is een uitgebreide referentieoplossing ontwikkeld door Microsoft die laat zien hoe je een multi-agent, AI-gestuurde reisplanningsapplicatie bouwt met behulp van het Model Context Protocol (MCP), Azure OpenAI en Azure AI Search. Dit project toont best practices voor het coördineren van meerdere AI-agents, het integreren van bedrijfsdata en het bieden van een veilige, uitbreidbare platform voor scenario’s uit de praktijk.

## Belangrijkste kenmerken
- **Multi-Agent Orkestratie:** Maakt gebruik van MCP om gespecialiseerde agents (bijv. flight, hotel en itinerary agents) te coördineren die samenwerken om complexe reisplanningsopdrachten uit te voeren.
- **Integratie van bedrijfsdata:** Verbindt met Azure AI Search en andere bedrijfsdatabronnen om actuele, relevante informatie te bieden voor reisaanbevelingen.
- **Veilige, schaalbare architectuur:** Benut Azure-diensten voor authenticatie, autorisatie en schaalbare uitrol, volgens de beste beveiligingspraktijken voor bedrijven.
- **Uitbreidbare tools:** Implementeert herbruikbare MCP-tools en prompt-sjablonen, waardoor snelle aanpassing aan nieuwe domeinen of zakelijke eisen mogelijk is.
- **Gebruikerservaring:** Biedt een conversatie-interface voor gebruikers om te communiceren met de reisagents, aangedreven door Azure OpenAI en MCP.

## Architectuur
![Architectuur](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Beschrijving van het architectuurschema

De Azure AI Travel Agents-oplossing is ontworpen voor modulariteit, schaalbaarheid en veilige integratie van meerdere AI-agents en bedrijfsdatabronnen. De belangrijkste componenten en datastromen zijn als volgt:

- **Gebruikersinterface:** Gebruikers communiceren met het systeem via een conversatie-UI (zoals een webchat of Teams-bot), die gebruikersvragen verstuurt en reisaanbevelingen ontvangt.
- **MCP Server:** Dient als centrale coördinator, ontvangt gebruikersinput, beheert context en coördineert de acties van gespecialiseerde agents (bijv. FlightAgent, HotelAgent, ItineraryAgent) via het Model Context Protocol.
- **AI Agents:** Elke agent is verantwoordelijk voor een specifiek domein (vluchten, hotels, reisroutes) en is geïmplementeerd als een MCP-tool. Agents gebruiken prompt-sjablonen en logica om verzoeken te verwerken en antwoorden te genereren.
- **Azure OpenAI Service:** Biedt geavanceerd begrip en generatie van natuurlijke taal, waardoor agents de intentie van gebruikers kunnen interpreteren en conversatie-antwoorden kunnen geven.
- **Azure AI Search & Bedrijfsdata:** Agents raadplegen Azure AI Search en andere bedrijfsdatabronnen om actuele informatie over vluchten, hotels en reismogelijkheden op te halen.
- **Authenticatie & Beveiliging:** Integreert met Microsoft Entra ID voor veilige authenticatie en past het principe van minste rechten toe op alle resources.
- **Uitrol:** Ontworpen voor uitrol op Azure Container Apps, wat schaalbaarheid, monitoring en operationele efficiëntie garandeert.

Deze architectuur maakt naadloze orkestratie van meerdere AI-agents mogelijk, veilige integratie met bedrijfsdata en een robuust, uitbreidbaar platform voor het bouwen van domeinspecifieke AI-oplossingen.

## Stapsgewijze uitleg van het architectuurschema
Stel je voor dat je een grote reis plant en een team van deskundige assistenten hebt die je bij elk detail helpen. Het Azure AI Travel Agents-systeem werkt op een vergelijkbare manier, met verschillende onderdelen (zoals teamleden) die elk een speciale taak hebben. Zo werkt het allemaal samen:

### Gebruikersinterface (UI):
Zie dit als de balie van je reisagent. Hier stel je vragen of doe je verzoeken, zoals “Zoek een vlucht naar Parijs.” Dit kan een chatvenster op een website zijn of een berichtendienst.

### MCP Server (De coördinator):
De MCP Server is als de manager die aan de balie naar je verzoek luistert en bepaalt welke specialist welk deel moet afhandelen. Hij houdt het gesprek bij en zorgt dat alles soepel verloopt.

### AI Agents (Specialistische assistenten):
Elke agent is expert in een bepaald gebied – de een weet alles van vluchten, de ander van hotels en weer een ander van het plannen van je reisschema. Wanneer je om een reis vraagt, stuurt de MCP Server je verzoek naar de juiste agent(s). Deze agents gebruiken hun kennis en tools om de beste opties voor jou te vinden.

### Azure OpenAI Service (Taalexpert):
Dit is alsof je een taalexpert hebt die precies begrijpt wat je vraagt, ongeacht hoe je het formuleert. Hij helpt de agents om je verzoeken te begrijpen en natuurlijk, conversatiegericht te antwoorden.

### Azure AI Search & Bedrijfsdata (Informatiebibliotheek):
Stel je een enorme, up-to-date bibliotheek voor met de laatste reisinfo – vluchtschema’s, hotelbeschikbaarheid en meer. De agents doorzoeken deze bibliotheek om de meest accurate antwoorden voor jou te vinden.

### Authenticatie & Beveiliging (Beveiligingsbeambte):
Net zoals een beveiliger controleert wie bepaalde ruimtes mag betreden, zorgt dit onderdeel ervoor dat alleen geautoriseerde personen en agents toegang hebben tot gevoelige informatie. Zo blijft je data veilig en privé.

### Uitrol op Azure Container Apps (Het gebouw):
Al deze assistenten en tools werken samen binnen een veilig, schaalbaar gebouw (de cloud). Dit betekent dat het systeem veel gebruikers tegelijk aankan en altijd beschikbaar is wanneer jij het nodig hebt.

## Hoe het allemaal samenwerkt:

Je begint met het stellen van een vraag aan de balie (UI).  
De manager (MCP Server) bepaalt welke specialist (agent) je kan helpen.  
De specialist gebruikt de taalexpert (OpenAI) om je verzoek te begrijpen en de bibliotheek (AI Search) om het beste antwoord te vinden.  
De beveiliger (Authenticatie) zorgt dat alles veilig verloopt.  
Dit alles gebeurt binnen een betrouwbaar, schaalbaar gebouw (Azure Container Apps), zodat jouw ervaring soepel en veilig is.  
Deze samenwerking zorgt ervoor dat het systeem je snel en veilig helpt met het plannen van je reis, net als een team van deskundige reisagenten die samenwerken in een modern kantoor!

## Technische implementatie
- **MCP Server:** Bevat de kernlogica voor orkestratie, stelt agent-tools beschikbaar en beheert de context voor meerstaps reisplanningsworkflows.
- **Agents:** Elke agent (bijv. FlightAgent, HotelAgent) is geïmplementeerd als een MCP-tool met eigen prompt-sjablonen en logica.
- **Azure-integratie:** Gebruikt Azure OpenAI voor begrip van natuurlijke taal en Azure AI Search voor data-opvraging.
- **Beveiliging:** Integreert met Microsoft Entra ID voor authenticatie en past het principe van minste rechten toe op alle resources.
- **Uitrol:** Ondersteunt uitrol naar Azure Container Apps voor schaalbaarheid en operationele efficiëntie.

## Resultaten en impact
- Toont aan hoe MCP kan worden gebruikt om meerdere AI-agents te coördineren in een scenario van productiekwaliteit.
- Versnelt de ontwikkeling van oplossingen door herbruikbare patronen te bieden voor agentcoördinatie, dataintegratie en veilige uitrol.
- Dient als blauwdruk voor het bouwen van domeinspecifieke, AI-gestuurde applicaties met MCP en Azure-diensten.

## Referenties
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.