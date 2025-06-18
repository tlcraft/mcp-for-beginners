<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:17:25+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "nl"
}
-->
# Praktische Implementatie

Praktische implementatie is waar de kracht van het Model Context Protocol (MCP) tastbaar wordt. Hoewel het begrijpen van de theorie en architectuur achter MCP belangrijk is, ontstaat de echte waarde wanneer je deze concepten toepast om oplossingen te bouwen, testen en implementeren die echte problemen oplossen. Dit hoofdstuk overbrugt de kloof tussen conceptuele kennis en praktische ontwikkeling en begeleidt je bij het tot leven brengen van MCP-gebaseerde applicaties.

Of je nu intelligente assistenten ontwikkelt, AI integreert in bedrijfsprocessen, of maatwerktools bouwt voor dataverwerking, MCP biedt een flexibele basis. Het taalonafhankelijke ontwerp en de officiële SDK’s voor populaire programmeertalen maken het toegankelijk voor een breed scala aan ontwikkelaars. Door gebruik te maken van deze SDK’s kun je snel prototypes maken, itereren en je oplossingen opschalen over verschillende platformen en omgevingen.

In de volgende secties vind je praktische voorbeelden, voorbeeldcode en implementatiestrategieën die laten zien hoe je MCP kunt toepassen in C#, Java, TypeScript, JavaScript en Python. Je leert ook hoe je MCP-servers debugt en test, API’s beheert en oplossingen naar de cloud uitrolt met Azure. Deze hands-on bronnen zijn bedoeld om je leerproces te versnellen en je te helpen met vertrouwen robuuste, productieklare MCP-applicaties te bouwen.

## Overzicht

Deze les richt zich op praktische aspecten van MCP-implementatie in verschillende programmeertalen. We onderzoeken hoe je MCP SDK’s gebruikt in C#, Java, TypeScript, JavaScript en Python om robuuste applicaties te bouwen, MCP-servers te debuggen en testen, en herbruikbare resources, prompts en tools te creëren.

## Leerdoelen

Aan het einde van deze les kun je:
- MCP-oplossingen implementeren met officiële SDK’s in diverse programmeertalen
- MCP-servers systematisch debuggen en testen
- Serverfuncties creëren en gebruiken (Resources, Prompts en Tools)
- Effectieve MCP-workflows ontwerpen voor complexe taken
- MCP-implementaties optimaliseren voor prestaties en betrouwbaarheid

## Officiële SDK-bronnen

Het Model Context Protocol biedt officiële SDK’s voor meerdere talen:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Werken met MCP SDK’s

Deze sectie geeft praktische voorbeelden van MCP-implementatie in verschillende programmeertalen. Je vindt voorbeeldcode in de `samples` map, georganiseerd per taal.

### Beschikbare Voorbeelden

De repository bevat [voorbeeldimplementaties](../../../04-PracticalImplementation/samples) in de volgende talen:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Elk voorbeeld demonstreert belangrijke MCP-concepten en implementatiepatronen voor die specifieke taal en omgeving.

## Kernserverfuncties

MCP-servers kunnen elke combinatie van deze functies implementeren:

### Resources
Resources bieden context en data voor de gebruiker of het AI-model om te gebruiken:
- Documentrepositories
- Kennisbanken
- Gestructureerde databronnen
- Bestandsystemen

### Prompts
Prompts zijn sjablonen voor berichten en workflows voor gebruikers:
- Vooraf gedefinieerde gesprekssjablonen
- Begeleide interactiepatronen
- Gespecialiseerde dialoogstructuren

### Tools
Tools zijn functies die het AI-model kan uitvoeren:
- Hulpmiddelen voor dataverwerking
- Integraties met externe API’s
- Rekenkundige mogelijkheden
- Zoekfunctionaliteit

## Voorbeeldimplementaties: C#

De officiële C# SDK-repository bevat verschillende voorbeeldimplementaties die verschillende aspecten van MCP demonstreren:

- **Basic MCP Client**: Eenvoudig voorbeeld van het maken van een MCP-client en het aanroepen van tools
- **Basic MCP Server**: Minimale serverimplementatie met basisregistratie van tools
- **Advanced MCP Server**: Volledig uitgeruste server met toolregistratie, authenticatie en foutafhandeling
- **ASP.NET Integratie**: Voorbeelden van integratie met ASP.NET Core
- **Tool Implementatiepatronen**: Diverse patronen voor het implementeren van tools met verschillende complexiteitsniveaus

De MCP C# SDK is in preview en API’s kunnen veranderen. We zullen deze blog continu bijwerken naarmate de SDK evolueert.

### Belangrijke functies
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Bouw je [eerste MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Voor volledige C# implementatievoorbeelden, bezoek de [officiële C# SDK voorbeeldrepository](https://github.com/modelcontextprotocol/csharp-sdk)

## Voorbeeldimplementatie: Java Implementatie

De Java SDK biedt robuuste MCP-implementatieopties met enterprise-grade functies.

### Belangrijke functies

- Integratie met Spring Framework
- Sterke typeveiligheid
- Ondersteuning voor reactief programmeren
- Uitgebreide foutafhandeling

Voor een complete Java implementatievoorbeelden, zie [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) in de samples map.

## Voorbeeldimplementatie: JavaScript Implementatie

De JavaScript SDK biedt een lichte en flexibele aanpak voor MCP-implementatie.

### Belangrijke functies

- Ondersteuning voor Node.js en browsers
- Promise-gebaseerde API
- Gemakkelijke integratie met Express en andere frameworks
- WebSocket-ondersteuning voor streaming

Voor een complete JavaScript implementatievoorbeelden, zie [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) in de samples map.

## Voorbeeldimplementatie: Python Implementatie

De Python SDK biedt een Pythonische aanpak voor MCP-implementatie met uitstekende integraties voor ML-frameworks.

### Belangrijke functies

- Async/await ondersteuning met asyncio
- Integratie met Flask en FastAPI
- Eenvoudige toolregistratie
- Native integratie met populaire ML-bibliotheken

Voor een complete Python implementatievoorbeelden, zie [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) in de samples map.

## API-beheer

Azure API Management is een uitstekende oplossing om MCP-servers te beveiligen. Het idee is om een Azure API Management-instantie voor je MCP-server te plaatsen en deze functies te laten afhandelen die je waarschijnlijk wilt, zoals:

- rate limiting
- tokenbeheer
- monitoring
- load balancing
- beveiliging

### Azure Voorbeeld

Hier is een Azure voorbeeld dat precies dat doet, namelijk [het maken van een MCP Server en het beveiligen ervan met Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Bekijk hoe de autorisatiestroom verloopt in onderstaande afbeelding:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

In de bovenstaande afbeelding gebeurt het volgende:

- Authenticatie/Autorisatie vindt plaats via Microsoft Entra.
- Azure API Management fungeert als gateway en gebruikt policies om verkeer te sturen en te beheren.
- Azure Monitor registreert alle verzoeken voor verdere analyse.

#### Autorisatiestroom

Laten we de autorisatiestroom wat gedetailleerder bekijken:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP autorisatiespecificatie

Lees meer over de [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Remote MCP Server implementeren op Azure

Laten we kijken of we het eerder genoemde voorbeeld kunnen implementeren:

1. Clone de repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Registreer `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` en controleer na enige tijd of de registratie voltooid is.

3. Voer dit [azd](https://aka.ms/azd) commando uit om de API Management service, function app (met code) en alle andere benodigde Azure resources te provisionen

    ```shell
    azd up
    ```

    Dit commando zou alle cloudresources op Azure moeten implementeren

### Testen van je server met MCP Inspector

1. Open een **nieuw terminalvenster**, installeer en start MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Je zou een interface moeten zien zoals:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.nl.png)

2. CTRL-klik om de MCP Inspector webapp te laden via de URL die door de app wordt weergegeven (bijv. http://127.0.0.1:6274/#resources)
3. Stel het transporttype in op `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` en **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**. Klik op een tool en **Run Tool**.

Als alle stappen zijn gelukt, ben je nu verbonden met de MCP-server en kun je een tool aanroepen.

## MCP-servers voor Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Deze set repositories is een quickstart-template voor het bouwen en implementeren van aangepaste remote MCP (Model Context Protocol) servers met Azure Functions in Python, C# .NET of Node/TypeScript.

De voorbeelden bieden een complete oplossing waarmee ontwikkelaars kunnen:

- Lokaal bouwen en draaien: Ontwikkel en debug een MCP-server op een lokale machine
- Implementeren naar Azure: Eenvoudig uitrollen naar de cloud met een simpel azd up-commando
- Verbinden vanuit clients: Verbinden met de MCP-server vanuit verschillende clients, waaronder VS Code’s Copilot agent mode en de MCP Inspector tool

### Belangrijke kenmerken:

- Security by design: De MCP-server is beveiligd met keys en HTTPS
- Authenticatie-opties: Ondersteunt OAuth via ingebouwde authenticatie en/of API Management
- Netwerkisolatie: Biedt netwerkisolatie via Azure Virtual Networks (VNET)
- Serverless architectuur: Maakt gebruik van Azure Functions voor schaalbare, event-driven uitvoering
- Lokale ontwikkeling: Uitgebreide ondersteuning voor lokale ontwikkeling en debugging
- Eenvoudige implementatie: Gestroomlijnd implementatieproces naar Azure

De repository bevat alle benodigde configuratiebestanden, broncode en infrastructuurdefinities om snel aan de slag te gaan met een productieklare MCP-serverimplementatie.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Voorbeeldimplementatie van MCP met Azure Functions in Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Voorbeeldimplementatie van MCP met Azure Functions in C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Voorbeeldimplementatie van MCP met Azure Functions in Node/TypeScript.

## Belangrijkste punten

- MCP SDK’s bieden taalspecifieke tools voor het implementeren van robuuste MCP-oplossingen
- Het debuggen en testen is cruciaal voor betrouwbare MCP-applicaties
- Herbruikbare promptsjablonen zorgen voor consistente AI-interacties
- Goed ontworpen workflows kunnen complexe taken orkestreren met meerdere tools
- Bij het implementeren van MCP-oplossingen moet rekening worden gehouden met beveiliging, prestaties en foutafhandeling

## Oefening

Ontwerp een praktische MCP-workflow die een probleem uit jouw vakgebied oplost:

1. Identificeer 3-4 tools die nuttig zouden zijn voor het oplossen van dit probleem
2. Maak een workflowdiagram waarin je laat zien hoe deze tools samenwerken
3. Implementeer een basisversie van een van de tools in jouw favoriete taal
4. Maak een promptsjabloon dat het model helpt je tool effectief te gebruiken

## Aanvullende bronnen


---

Volgende: [Geavanceerde Onderwerpen](../05-AdvancedTopics/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor belangrijke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.