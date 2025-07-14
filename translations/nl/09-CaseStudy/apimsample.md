<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:33:52+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "nl"
}
-->
# Case Study: REST API blootstellen in API Management als een MCP-server

Azure API Management is een dienst die een Gateway biedt bovenop je API-eindpunten. Azure API Management fungeert als een proxy voor je API's en bepaalt wat er met binnenkomende verzoeken gebeurt.

Door het te gebruiken, voeg je een hele reeks functies toe zoals:

- **Beveiliging**, je kunt alles gebruiken van API-sleutels, JWT tot managed identity.
- **Rate limiting**, een handige functie waarmee je kunt bepalen hoeveel oproepen er per tijdseenheid worden toegelaten. Dit zorgt ervoor dat alle gebruikers een goede ervaring hebben en dat je service niet overbelast raakt.
- **Schaalbaarheid & Load balancing**. Je kunt meerdere eindpunten instellen om de belasting te verdelen en je kunt ook bepalen hoe je de load balanceert.
- **AI-functies zoals semantische caching**, tokenlimieten en tokenmonitoring en meer. Dit zijn geweldige functies die de reactietijd verbeteren en je helpen je tokenverbruik in de gaten te houden. [Lees hier meer](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Waarom MCP + Azure API Management?

Model Context Protocol wordt snel een standaard voor agentische AI-apps en voor het op een consistente manier blootstellen van tools en data. Azure API Management is een logische keuze wanneer je API's wilt "beheren". MCP-servers integreren vaak met andere API's om bijvoorbeeld verzoeken naar een tool te routeren. Daarom is het combineren van Azure API Management en MCP heel logisch.

## Overzicht

In deze specifieke use case leren we hoe je API-eindpunten blootstelt als een MCP-server. Hierdoor kunnen deze eindpunten eenvoudig onderdeel worden van een agentische app, terwijl je ook profiteert van de functies van Azure API Management.

## Belangrijkste functies

- Je selecteert welke endpoint-methoden je wilt blootstellen als tools.
- De extra functies die je krijgt, hangen af van wat je configureert in het beleidsgedeelte van je API. Hier laten we zien hoe je rate limiting kunt toevoegen.

## Voorbereiding: importeer een API

Als je al een API hebt in Azure API Management, dan kun je deze stap overslaan. Zo niet, bekijk dan deze link: [een API importeren in Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## API blootstellen als MCP-server

Volg deze stappen om de API-eindpunten bloot te stellen:

1. Ga naar Azure Portal via <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Navigeer naar je API Management instantie.

1. Selecteer in het linkermenu APIs > MCP Servers > + Create new MCP Server.

1. Kies bij API een REST API die je wilt blootstellen als MCP-server.

1. Selecteer één of meerdere API-operaties die je als tools wilt blootstellen. Je kunt alle operaties of alleen specifieke operaties selecteren.

    ![Selecteer methoden om bloot te stellen](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Klik op **Create**.

1. Ga naar het menu **APIs** en **MCP Servers**, je zou het volgende moeten zien:

    ![Zie de MCP-server in het hoofdvenster](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    De MCP-server is aangemaakt en de API-operaties zijn blootgesteld als tools. De MCP-server wordt weergegeven in het MCP Servers-paneel. De URL-kolom toont het eindpunt van de MCP-server dat je kunt aanroepen voor testen of binnen een clientapplicatie.

## Optioneel: Beleid configureren

Azure API Management werkt met het kernconcept van policies, waarbij je regels instelt voor je eindpunten, zoals rate limiting of semantische caching. Deze policies worden geschreven in XML.

Zo stel je een policy in om je MCP-server te beperken in het aantal oproepen:

1. Ga in de portal onder APIs naar **MCP Servers**.

1. Selecteer de MCP-server die je hebt aangemaakt.

1. Kies in het linkermenu onder MCP voor **Policies**.

1. Voeg in de policy-editor de policies toe of bewerk ze die je wilt toepassen op de tools van de MCP-server. De policies zijn in XML-formaat. Bijvoorbeeld, je kunt een policy toevoegen om het aantal oproepen naar de tools van de MCP-server te beperken (in dit voorbeeld 5 oproepen per 30 seconden per client IP-adres). Dit is de XML die de rate limiting afdwingt:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Dit is een afbeelding van de policy-editor:

    ![Policy-editor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Probeer het uit

Laten we controleren of onze MCP-server werkt zoals bedoeld.

Hiervoor gebruiken we Visual Studio Code en GitHub Copilot in Agent-modus. We voegen de MCP-server toe aan een *mcp.json*. Hierdoor fungeert Visual Studio Code als een client met agentische mogelijkheden en kunnen eindgebruikers een prompt typen en met de server communiceren.

Zo voeg je de MCP-server toe in Visual Studio Code:

1. Gebruik de MCP: **Add Server command uit de Command Palette**.

1. Kies bij de prompt het servertype: **HTTP (HTTP of Server Sent Events)**.

1. Voer de URL in van de MCP-server in API Management. Bijvoorbeeld: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (voor SSE-eindpunt) of **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (voor MCP-eindpunt). Let op het verschil in transport: `/sse` of `/mcp`.

1. Voer een server-ID in naar keuze. Dit is niet kritisch, maar helpt je om de server te herkennen.

1. Kies of je de configuratie opslaat in je workspace-instellingen of gebruikersinstellingen.

  - **Workspace settings** - De serverconfiguratie wordt opgeslagen in een .vscode/mcp.json bestand dat alleen beschikbaar is in de huidige workspace.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    Of als je streaming HTTP als transport kiest, ziet het er iets anders uit:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User settings** - De serverconfiguratie wordt toegevoegd aan je globale *settings.json* bestand en is beschikbaar in alle workspaces. De configuratie ziet er ongeveer zo uit:

    ![Gebruikersinstelling](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Je moet ook een configuratie toevoegen, een header om ervoor te zorgen dat de authenticatie correct verloopt richting Azure API Management. Er wordt een header gebruikt genaamd **Ocp-Apim-Subscription-Key**.

    - Zo voeg je deze toe aan de instellingen:

    ![Header toevoegen voor authenticatie](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), hierdoor verschijnt een prompt waarin je de API-sleutel kunt invoeren die je in Azure Portal vindt voor je Azure API Management instantie.

   - Om het toe te voegen aan *mcp.json*, kun je het als volgt doen:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Agent-modus gebruiken

Nu alles is ingesteld in de instellingen of in *.vscode/mcp.json*. Laten we het uitproberen.

Er zou een Tools-icoon moeten zijn, waar de blootgestelde tools van je server worden weergegeven:

![Tools van de server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Klik op het tools-icoon en je ziet een lijst met tools zoals deze:

    ![Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Typ een prompt in de chat om de tool aan te roepen. Bijvoorbeeld, als je een tool hebt geselecteerd om informatie over een bestelling op te vragen, kun je de agent vragen naar een bestelling. Dit is een voorbeeldprompt:

    ```text
    get information from order 2
    ```

    Je krijgt nu een tools-icoon te zien dat vraagt of je door wilt gaan met het aanroepen van een tool. Kies om door te gaan met het uitvoeren van de tool, je ziet dan een output zoals deze:

    ![Resultaat van prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **Wat je hierboven ziet hangt af van welke tools je hebt ingesteld, maar het idee is dat je een tekstuele reactie krijgt zoals hierboven**


## Referenties

Zo kun je meer leren:

- [Tutorial over Azure API Management en MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python voorbeeld: Beveilig remote MCP-servers met Azure API Management (experimenteel)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP client authorisatie lab](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Gebruik de Azure API Management extensie voor VS Code om API's te importeren en beheren](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Registreer en ontdek remote MCP-servers in Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Geweldige repo die veel AI-mogelijkheden met Azure API Management laat zien
- [AI Gateway workshops](https://azure-samples.github.io/AI-Gateway/) Bevat workshops met Azure Portal, een uitstekende manier om AI-mogelijkheden te verkennen.

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.