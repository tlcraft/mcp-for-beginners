<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:18:56+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "nl"
}
-->
# Praktische Implementatie

Praktische implementatie is waar de kracht van het Model Context Protocol (MCP) tastbaar wordt. Hoewel het belangrijk is om de theorie en architectuur achter MCP te begrijpen, ontstaat de echte waarde wanneer je deze concepten toepast om oplossingen te bouwen, testen en implementeren die echte problemen oplossen. Dit hoofdstuk overbrugt de kloof tussen conceptuele kennis en hands-on ontwikkeling en begeleidt je bij het tot leven brengen van MCP-gebaseerde applicaties.

Of je nu intelligente assistenten ontwikkelt, AI integreert in bedrijfsprocessen, of aangepaste tools bouwt voor dataverwerking, MCP biedt een flexibele basis. Het taal-onafhankelijke ontwerp en de officiële SDK's voor populaire programmeertalen maken het toegankelijk voor een breed scala aan ontwikkelaars. Door gebruik te maken van deze SDK's kun je snel prototypen, itereren en je oplossingen opschalen over verschillende platforms en omgevingen.

In de volgende secties vind je praktische voorbeelden, voorbeeldcode en implementatiestrategieën die laten zien hoe je MCP kunt toepassen in C#, Java, TypeScript, JavaScript en Python. Je leert ook hoe je MCP-servers debugt en test, API’s beheert en oplossingen in de cloud implementeert met Azure. Deze hands-on bronnen zijn ontworpen om je leerproces te versnellen en je te helpen zelfverzekerd robuuste, productieklare MCP-applicaties te bouwen.

## Overzicht

Deze les richt zich op praktische aspecten van MCP-implementatie in meerdere programmeertalen. We onderzoeken hoe je MCP SDK's gebruikt in C#, Java, TypeScript, JavaScript en Python om robuuste applicaties te bouwen, MCP-servers te debuggen en testen, en herbruikbare resources, prompts en tools te creëren.

## Leerdoelen

Aan het einde van deze les kun je:
- MCP-oplossingen implementeren met officiële SDK's in verschillende programmeertalen
- MCP-servers systematisch debuggen en testen
- Serverfuncties creëren en gebruiken (Resources, Prompts en Tools)
- Effectieve MCP-workflows ontwerpen voor complexe taken
- MCP-implementaties optimaliseren voor prestaties en betrouwbaarheid

## Officiële SDK Resources

Het Model Context Protocol biedt officiële SDK's voor meerdere talen:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Werken met MCP SDK's

Deze sectie bevat praktische voorbeelden van MCP-implementaties in verschillende programmeertalen. Je vindt voorbeeldcode in de `samples` map, georganiseerd per taal.

### Beschikbare voorbeelden

De repository bevat voorbeeldimplementaties in de volgende talen:

- C#
- Java
- TypeScript
- JavaScript
- Python

Elk voorbeeld demonstreert belangrijke MCP-concepten en implementatiepatronen voor die specifieke taal en ecosysteem.

## Kernfuncties van de server

MCP-servers kunnen een combinatie van deze functies implementeren:

### Resources
Resources bieden context en data voor de gebruiker of AI-model om te gebruiken:
- Documentrepositories
- Kennisbanken
- Gestructureerde databronnen
- Bestandsystemen

### Prompts
Prompts zijn sjablonen voor berichten en workflows voor gebruikers:
- Vooraf gedefinieerde conversatiesjablonen
- Begeleide interactiepatronen
- Gespecialiseerde dialoogstructuren

### Tools
Tools zijn functies die het AI-model kan uitvoeren:
- Hulpmiddelen voor dataverwerking
- Integraties met externe API’s
- Rekencapaciteiten
- Zoekfunctionaliteit

## Voorbeeldimplementaties: C#

De officiële C# SDK-repository bevat verschillende voorbeeldimplementaties die verschillende aspecten van MCP demonstreren:

- **Basic MCP Client**: Eenvoudig voorbeeld dat laat zien hoe je een MCP-client maakt en tools aanroept
- **Basic MCP Server**: Minimale serverimplementatie met basis tool-registratie
- **Advanced MCP Server**: Volledig uitgeruste server met tool-registratie, authenticatie en foutafhandeling
- **ASP.NET-integratie**: Voorbeelden die integratie met ASP.NET Core laten zien
- **Tool-implementatiepatronen**: Diverse patronen voor het implementeren van tools met verschillende complexiteitsniveaus

De MCP C# SDK is in preview en de API’s kunnen veranderen. We blijven deze blog updaten naarmate de SDK zich ontwikkelt.

### Belangrijke functies 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Bouw je [eerste MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Voor volledige C# implementatievoorbeelden, bezoek de [officiële C# SDK voorbeelden repository](https://github.com/modelcontextprotocol/csharp-sdk)

## Voorbeeldimplementatie: Java

De Java SDK biedt robuuste MCP-implementatieopties met enterprise-grade functionaliteiten.

### Belangrijke functies

- Integratie met Spring Framework
- Sterke typeveiligheid
- Ondersteuning voor reactief programmeren
- Uitgebreide foutafhandeling

Voor een volledige Java-implementatie, zie [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) in de samples map.

## Voorbeeldimplementatie: JavaScript

De JavaScript SDK biedt een lichte en flexibele aanpak voor MCP-implementatie.

### Belangrijke functies

- Ondersteuning voor Node.js en browsers
- Promise-gebaseerde API
- Gemakkelijke integratie met Express en andere frameworks
- WebSocket-ondersteuning voor streaming

Voor een volledige JavaScript-implementatie, zie [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) in de samples map.

## Voorbeeldimplementatie: Python

De Python SDK biedt een Pythonic aanpak voor MCP-implementatie met uitstekende integraties voor ML-frameworks.

### Belangrijke functies

- Async/await ondersteuning met asyncio
- Integratie met Flask en FastAPI
- Eenvoudige tool-registratie
- Native integratie met populaire ML-bibliotheken

Voor een volledige Python-implementatie, zie [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) in de samples map.

## API-beheer 

Azure API Management is een uitstekende oplossing om MCP-servers te beveiligen. Het idee is om een Azure API Management instantie voor je MCP-server te plaatsen, die functies afhandelt die je waarschijnlijk nodig hebt, zoals:

- rate limiting
- tokenbeheer
- monitoring
- load balancing
- beveiliging

### Azure voorbeeld

Hier is een Azure voorbeeld dat precies dat doet, namelijk [een MCP-server creëren en beveiligen met Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Zie hoe de autorisatiestroom verloopt in onderstaande afbeelding:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

In de bovenstaande afbeelding gebeurt het volgende:

- Authenticatie/Autorisatie vindt plaats via Microsoft Entra.
- Azure API Management fungeert als gateway en gebruikt policies om verkeer te sturen en te beheren.
- Azure Monitor registreert alle verzoeken voor verdere analyse.

#### Autorisatiestroom

Laten we de autorisatiestroom wat gedetailleerder bekijken:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP autorisatiespecificatie

Lees meer over de [MCP Authorization specificatie](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Remote MCP Server implementeren op Azure

Laten we kijken of we het eerder genoemde voorbeeld kunnen implementeren:

1. Clone de repository

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Registreer `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` en controleer na enige tijd of de registratie is voltooid.

3. Voer dit [azd](https://aka.ms/azd) commando uit om de API Management service, function app (met code) en alle andere benodigde Azure resources te provisioneren

    ```shell
    azd up
    ```

    Dit commando zou alle cloudresources op Azure moeten implementeren.

### Test je server met MCP Inspector

1. Open een **nieuw terminalvenster**, installeer en start MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Je zou een interface moeten zien zoals:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.nl.png) 

2. CTRL-klik om de MCP Inspector webapp te laden vanaf de door de app weergegeven URL (bijv. http://127.0.0.1:6274/#resources)
3. Stel het transporttype in op `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` en **Verbind**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**. Klik op een tool en **Run Tool**.  

Als alle stappen gelukt zijn, ben je nu verbonden met de MCP-server en heb je een tool kunnen aanroepen.

## MCP servers voor Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Deze set repositories is een quickstart template voor het bouwen en implementeren van aangepaste remote MCP (Model Context Protocol) servers met Azure Functions in Python, C# .NET of Node/TypeScript.

De voorbeelden bieden een complete oplossing waarmee ontwikkelaars kunnen:

- Lokaal bouwen en draaien: ontwikkel en debug een MCP-server op een lokale machine
- Implementeren naar Azure: eenvoudig implementeren naar de cloud met een simpel azd up-commando
- Verbinden vanaf clients: verbinding maken met de MCP-server vanaf diverse clients, inclusief VS Code's Copilot agent modus en de MCP Inspector tool

### Belangrijke functies:

- Security by design: de MCP-server is beveiligd met sleutels en HTTPS
- Authenticatie-opties: ondersteunt OAuth via ingebouwde authenticatie en/of API Management
- Netwerkisolatie: maakt netwerkisolatie mogelijk via Azure Virtual Networks (VNET)
- Serverless architectuur: maakt gebruik van Azure Functions voor schaalbare, event-gedreven uitvoering
- Lokale ontwikkeling: uitgebreide ondersteuning voor lokale ontwikkeling en debugging
- Eenvoudige implementatie: gestroomlijnd implementatieproces naar Azure

De repository bevat alle benodigde configuratiebestanden, broncode en infrastructuurdefinities om snel aan de slag te gaan met een productieklare MCP-serverimplementatie.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Voorbeeldimplementatie van MCP met Azure Functions in Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Voorbeeldimplementatie van MCP met Azure Functions in C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Voorbeeldimplementatie van MCP met Azure Functions in Node/TypeScript.

## Belangrijkste conclusies

- MCP SDK's bieden taalspecifieke tools voor het implementeren van robuuste MCP-oplossingen
- Het debuggen en testen is cruciaal voor betrouwbare MCP-applicaties
- Herbruikbare prompt-sjablonen zorgen voor consistente AI-interacties
- Goed ontworpen workflows kunnen complexe taken orkestreren met meerdere tools
- Bij het implementeren van MCP-oplossingen moet rekening worden gehouden met beveiliging, prestaties en foutafhandeling

## Oefening

Ontwerp een praktische MCP-workflow die een probleem uit jouw werkveld oplost:

1. Identificeer 3-4 tools die nuttig zijn voor het oplossen van dit probleem
2. Maak een workflowdiagram waarin je laat zien hoe deze tools samenwerken
3. Implementeer een basisversie van een van de tools in jouw favoriete taal
4. Maak een prompt-sjabloon dat het model helpt je tool effectief te gebruiken

## Aanvullende bronnen


---

Volgende: [Geavanceerde onderwerpen](../05-AdvancedTopics/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor belangrijke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.