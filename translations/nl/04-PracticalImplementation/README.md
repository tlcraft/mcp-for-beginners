<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:55:35+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "nl"
}
-->
# Praktische Implementatie

Praktische implementatie is waar de kracht van het Model Context Protocol (MCP) tastbaar wordt. Hoewel het begrijpen van de theorie en architectuur achter MCP belangrijk is, komt de echte waarde naar voren wanneer je deze concepten toepast om oplossingen te bouwen, testen en implementeren die echte problemen oplossen. Dit hoofdstuk overbrugt de kloof tussen conceptuele kennis en praktische ontwikkeling, en begeleidt je door het proces van het tot leven brengen van MCP-gebaseerde applicaties.

Of je nu intelligente assistenten ontwikkelt, AI integreert in bedrijfsprocessen, of aangepaste tools voor gegevensverwerking bouwt, MCP biedt een flexibele basis. Het taalonafhankelijke ontwerp en de officiële SDK's voor populaire programmeertalen maken het toegankelijk voor een breed scala aan ontwikkelaars. Door gebruik te maken van deze SDK's kun je snel prototypes maken, itereren en je oplossingen opschalen over verschillende platforms en omgevingen.

In de volgende secties vind je praktische voorbeelden, voorbeeldcode en implementatiestrategieën die laten zien hoe je MCP kunt implementeren in C#, Java, TypeScript, JavaScript en Python. Je leert ook hoe je MCP-servers kunt debuggen en testen, API's kunt beheren en oplossingen naar de cloud kunt implementeren met Azure. Deze praktische hulpmiddelen zijn ontworpen om je leerproces te versnellen en je te helpen met vertrouwen robuuste, productieklare MCP-applicaties te bouwen.

## Overzicht

Deze les richt zich op praktische aspecten van MCP-implementatie in meerdere programmeertalen. We verkennen hoe je MCP SDK's kunt gebruiken in C#, Java, TypeScript, JavaScript en Python om robuuste applicaties te bouwen, MCP-servers te debuggen en testen, en herbruikbare bronnen, prompts en tools te creëren.

## Leerdoelen

Aan het einde van deze les kun je:
- MCP-oplossingen implementeren met behulp van officiële SDK's in verschillende programmeertalen
- MCP-servers systematisch debuggen en testen
- Serverfuncties (Resources, Prompts en Tools) creëren en gebruiken
- Effectieve MCP-workflows ontwerpen voor complexe taken
- MCP-implementaties optimaliseren voor prestaties en betrouwbaarheid

## Officiële SDK-bronnen

Het Model Context Protocol biedt officiële SDK's voor meerdere talen:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Werken met MCP SDK's

Deze sectie biedt praktische voorbeelden van MCP-implementatie in meerdere programmeertalen. Je kunt voorbeeldcode vinden in de `samples` directory georganiseerd per taal.

### Beschikbare Voorbeelden

De repository bevat voorbeeldimplementaties in de volgende talen:

- C#
- Java
- TypeScript
- JavaScript
- Python

Elk voorbeeld demonstreert belangrijke MCP-concepten en implementatiepatronen voor die specifieke taal en ecosysteem.

## Kern Server Functies

MCP-servers kunnen elke combinatie van deze functies implementeren:

### Resources
Resources bieden context en gegevens voor de gebruiker of AI-model om te gebruiken:
- Documentenrepositories
- Kennisbanken
- Gestructureerde gegevensbronnen
- Bestandsystemen

### Prompts
Prompts zijn gesjabloneerde berichten en workflows voor gebruikers:
- Vooraf gedefinieerde gesprekssjablonen
- Geleide interactiepatronen
- Gespecialiseerde dialoogstructuren

### Tools
Tools zijn functies die het AI-model kan uitvoeren:
- Hulpprogramma's voor gegevensverwerking
- Integraties met externe API's
- Computationele mogelijkheden
- Zoekfunctionaliteit

## Voorbeeld Implementaties: C#

De officiële C# SDK-repository bevat verschillende voorbeeldimplementaties die verschillende aspecten van MCP demonstreren:

- **Basis MCP Client**: Eenvoudig voorbeeld dat laat zien hoe je een MCP-client maakt en tools aanroept
- **Basis MCP Server**: Minimale serverimplementatie met basis toolregistratie
- **Geavanceerde MCP Server**: Volledig uitgeruste server met toolregistratie, authenticatie en foutafhandeling
- **ASP.NET Integratie**: Voorbeelden die integratie met ASP.NET Core demonstreren
- **Tool Implementatiepatronen**: Verschillende patronen voor het implementeren van tools met verschillende complexiteitsniveaus

De MCP C# SDK is in preview en API's kunnen veranderen. We zullen deze blog continu bijwerken naarmate de SDK evolueert.

### Belangrijkste Kenmerken 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Bouw je [eerste MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Voor volledige C# implementatievoorbeelden, bezoek de [officiële C# SDK voorbeeldenrepository](https://github.com/modelcontextprotocol/csharp-sdk)

## Voorbeeld Implementatie: Java Implementatie

De Java SDK biedt robuuste MCP-implementatieopties met functies van ondernemingsniveau.

### Belangrijkste Kenmerken

- Integratie met Spring Framework
- Sterke typeveiligheid
- Ondersteuning voor reactieve programmering
- Uitgebreide foutafhandeling

Voor een compleet Java implementatievoorbeeld, zie [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) in de voorbeelden directory.

## Voorbeeld Implementatie: JavaScript Implementatie

De JavaScript SDK biedt een lichte en flexibele aanpak voor MCP-implementatie.

### Belangrijkste Kenmerken

- Ondersteuning voor Node.js en browsers
- Promise-gebaseerde API
- Eenvoudige integratie met Express en andere frameworks
- Ondersteuning voor WebSocket voor streaming

Voor een compleet JavaScript implementatievoorbeeld, zie [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) in de voorbeelden directory.

## Voorbeeld Implementatie: Python Implementatie

De Python SDK biedt een Pythonic aanpak voor MCP-implementatie met uitstekende integraties met ML-frameworks.

### Belangrijkste Kenmerken

- Ondersteuning voor Async/await met asyncio
- Integratie met Flask en FastAPI
- Eenvoudige toolregistratie
- Native integratie met populaire ML-bibliotheken

Voor een compleet Python implementatievoorbeeld, zie [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) in de voorbeelden directory.

## API beheer 

Azure API Management is een geweldige oplossing voor het beveiligen van MCP-servers. Het idee is om een Azure API Management instantie voor je MCP-server te plaatsen en deze functies te laten afhandelen die je waarschijnlijk wilt, zoals:

- snelheidsbeperking
- tokenbeheer
- monitoring
- load balancing
- beveiliging

### Azure Voorbeeld

Hier is een Azure Voorbeeld dat precies dat doet, namelijk [een MCP-server creëren en beveiligen met Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Zie hoe de autorisatiestroom plaatsvindt in onderstaande afbeelding:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

In de bovenstaande afbeelding gebeurt het volgende:

- Authenticatie/Autorisatie vindt plaats met Microsoft Entra.
- Azure API Management fungeert als een gateway en gebruikt beleidsregels om verkeer te sturen en beheren.
- Azure Monitor registreert alle verzoeken voor verdere analyse.

#### Autorisatiestroom

Laten we de autorisatiestroom meer in detail bekijken:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP autorisatiespecificatie

Lees meer over de [MCP Autorisatiespecificatie](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Remote MCP Server implementeren naar Azure

Laten we eens kijken of we het eerder genoemde voorbeeld kunnen implementeren:

1. Clone de repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registreer `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` na enige tijd om te controleren of de registratie is voltooid.

2. Voer dit [azd](https://aka.ms/azd) commando uit om de api management service, function app (met code) en alle andere benodigde Azure resources te voorzien

    ```shell
    azd up
    ```

    Deze commando's moeten alle cloudresources op Azure implementeren

### Je server testen met MCP Inspector

1. In een **nieuw terminalvenster**, installeer en voer MCP Inspector uit

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Je zou een interface moeten zien die lijkt op:

    ![Connect to Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.nl.png)

1. CTRL klik om de MCP Inspector webapp te laden vanaf de URL die door de app wordt weergegeven (bijv. http://127.0.0.1:6274/#resources)
1. Stel het transporttype in op `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` en **Verbind**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Lijst Tools**. Klik op een tool en **Voer Tool uit**.  

Als alle stappen hebben gewerkt, zou je nu verbonden moeten zijn met de MCP-server en heb je een tool kunnen aanroepen.

## MCP-servers voor Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Deze set repositories zijn een snelstartsjabloon voor het bouwen en implementeren van aangepaste remote MCP (Model Context Protocol) servers met behulp van Azure Functions met Python, C# .NET of Node/TypeScript. 

De voorbeelden bieden een complete oplossing waarmee ontwikkelaars:

- Lokaal kunnen bouwen en uitvoeren: Ontwikkel en debug een MCP-server op een lokale machine
- Implementeren naar Azure: Eenvoudig naar de cloud implementeren met een eenvoudig azd up commando
- Verbinden vanuit clients: Verbinden met de MCP-server vanuit verschillende clients, waaronder VS Code's Copilot agent mode en de MCP Inspector tool

### Belangrijkste Kenmerken:

- Beveiliging door ontwerp: De MCP-server is beveiligd met sleutels en HTTPS
- Authenticatie-opties: Ondersteunt OAuth met ingebouwde authenticatie en/of API Management
- Netwerkisolatie: Mogelijkheid tot netwerkisolatie met Azure Virtual Networks (VNET)
- Serverloze architectuur: Maakt gebruik van Azure Functions voor schaalbare, gebeurtenisgestuurde uitvoering
- Lokale ontwikkeling: Uitgebreide ondersteuning voor lokale ontwikkeling en debugging
- Eenvoudige implementatie: Gestroomlijnd implementatieproces naar Azure

De repository bevat alle benodigde configuratiebestanden, broncode en infrastructuurdefinities om snel aan de slag te gaan met een productieklare MCP-serverimplementatie.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Voorbeeldimplementatie van MCP met Azure Functions met Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Voorbeeldimplementatie van MCP met Azure Functions met C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Voorbeeldimplementatie van MCP met Azure Functions met Node/TypeScript.

## Belangrijkste Leerpunten

- MCP SDK's bieden taal-specifieke tools voor het implementeren van robuuste MCP-oplossingen
- Het debuggen en testen proces is cruciaal voor betrouwbare MCP-applicaties
- Herbruikbare prompt sjablonen maken consistente AI-interacties mogelijk
- Goed ontworpen workflows kunnen complexe taken orkestreren met behulp van meerdere tools
- Het implementeren van MCP-oplossingen vereist aandacht voor beveiliging, prestaties en foutafhandeling

## Oefening

Ontwerp een praktische MCP-workflow die een echt probleem in jouw domein aanpakt:

1. Identificeer 3-4 tools die nuttig zouden zijn voor het oplossen van dit probleem
2. Maak een workflowdiagram dat laat zien hoe deze tools interageren
3. Implementeer een basisversie van een van de tools met behulp van jouw voorkeurs taal
4. Maak een prompt sjabloon die het model zou helpen jouw tool effectief te gebruiken

## Aanvullende Bronnen


---

Volgende: [Geavanceerde Onderwerpen](../05-AdvancedTopics/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we ons best doen voor nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in zijn oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.