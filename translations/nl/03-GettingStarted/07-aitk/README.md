<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:36:44+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "nl"
}
-->
# Een server gebruiken vanuit de AI Toolkit-extensie voor Visual Studio Code

Wanneer je een AI-agent bouwt, draait het niet alleen om het genereren van slimme antwoorden; het gaat er ook om je agent de mogelijkheid te geven om actie te ondernemen. Daar komt het Model Context Protocol (MCP) om de hoek kijken. MCP maakt het eenvoudig voor agents om op een consistente manier toegang te krijgen tot externe tools en diensten. Zie het als het aansluiten van je agent op een gereedschapskist die hij *echt* kan gebruiken.

Stel dat je een agent koppelt aan je calculator MCP-server. Plots kan je agent wiskundige bewerkingen uitvoeren door simpelweg een prompt te ontvangen zoals “Wat is 47 keer 89?”—zonder dat je logica hoeft te coderen of aangepaste API’s hoeft te bouwen.

## Overzicht

Deze les behandelt hoe je een calculator MCP-server koppelt aan een agent met de [AI Toolkit](https://aka.ms/AIToolkit) extensie in Visual Studio Code, zodat je agent wiskundige bewerkingen zoals optellen, aftrekken, vermenigvuldigen en delen kan uitvoeren via natuurlijke taal.

AI Toolkit is een krachtige extensie voor Visual Studio Code die het ontwikkelen van agents vereenvoudigt. AI Engineers kunnen eenvoudig AI-toepassingen bouwen door generatieve AI-modellen te ontwikkelen en te testen—lokaal of in de cloud. De extensie ondersteunt de meeste grote generatieve modellen die vandaag beschikbaar zijn.

*Opmerking*: De AI Toolkit ondersteunt momenteel Python en TypeScript.

## Leerdoelen

Aan het einde van deze les kun je:

- Een MCP-server gebruiken via de AI Toolkit.
- Een agentconfiguratie instellen zodat deze tools kan ontdekken en gebruiken die door de MCP-server worden aangeboden.
- MCP-tools gebruiken via natuurlijke taal.

## Aanpak

Dit is hoe we het op hoofdlijnen aanpakken:

- Maak een agent en definieer de system prompt.
- Maak een MCP-server met calculator tools.
- Verbind de Agent Builder met de MCP-server.
- Test het aanroepen van tools door de agent via natuurlijke taal.

Geweldig, nu we de flow begrijpen, laten we een AI-agent configureren om externe tools via MCP te gebruiken en zo zijn mogelijkheden te vergroten!

## Vereisten

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit voor Visual Studio Code](https://aka.ms/AIToolkit)

## Oefening: Een server gebruiken

In deze oefening bouw, draai en verbeter je een AI-agent met tools van een MCP-server binnen Visual Studio Code met behulp van de AI Toolkit.

### -0- Voorbereiding: voeg het OpenAI GPT-4o model toe aan Mijn Modellen

De oefening maakt gebruik van het **GPT-4o** model. Dit model moet worden toegevoegd aan **Mijn Modellen** voordat je de agent maakt.

![Screenshot van een modelselectie-interface in de AI Toolkit-extensie van Visual Studio Code. De koptekst luidt "Find the right model for your AI Solution" met een ondertitel die gebruikers aanmoedigt AI-modellen te ontdekken, testen en implementeren. Onder “Popular Models” worden zes modelkaarten getoond: DeepSeek-R1 (gehost op GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Klein, Snel), en DeepSeek-R1 (gehost op Ollama). Elke kaart bevat opties om het model toe te voegen of te proberen in de Playground.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.nl.png)

1. Open de **AI Toolkit** extensie via de **Activity Bar**.
1. Selecteer in de sectie **Catalog** de optie **Models** om de **Model Catalog** te openen. Dit opent de **Model Catalog** in een nieuw editor-tabblad.
1. Typ in de zoekbalk van de **Model Catalog** **OpenAI GPT-4o**.
1. Klik op **+ Add** om het model toe te voegen aan je lijst **Mijn Modellen**. Zorg dat je het model selecteert dat **gehost wordt door GitHub**.
1. Controleer in de **Activity Bar** of het model **OpenAI GPT-4o** in de lijst verschijnt.

### -1- Maak een agent

De **Agent (Prompt) Builder** stelt je in staat om je eigen AI-gestuurde agents te maken en aan te passen. In deze sectie maak je een nieuwe agent en wijs je een model toe om het gesprek aan te sturen.

![Screenshot van de "Calculator Agent" builder-interface in de AI Toolkit-extensie voor Visual Studio Code. In het linker paneel is het model "OpenAI GPT-4o (via GitHub)" geselecteerd. Een system prompt luidt "You are a professor in university teaching math," en de user prompt zegt "Explain to me the Fourier equation in simple terms." Extra opties zijn knoppen om tools toe te voegen, MCP Server in te schakelen en gestructureerde output te selecteren. Onderaan staat een blauwe “Run” knop. In het rechter paneel, onder "Get Started with Examples," staan drie voorbeeldagents: Web Developer (met MCP Server), Second-Grade Simplifier en Dream Interpreter, elk met een korte beschrijving van hun functies.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.nl.png)

1. Open de **AI Toolkit** extensie via de **Activity Bar**.
1. Selecteer in de sectie **Tools** de optie **Agent (Prompt) Builder**. Dit opent de **Agent (Prompt) Builder** in een nieuw editor-tabblad.
1. Klik op de knop **+ New Agent**. De extensie start een setup-wizard via de **Command Palette**.
1. Voer de naam **Calculator Agent** in en druk op **Enter**.
1. Selecteer in het veld **Model** van de **Agent (Prompt) Builder** het model **OpenAI GPT-4o (via GitHub)**.

### -2- Maak een system prompt voor de agent

Nu de agent is opgezet, is het tijd om zijn persoonlijkheid en doel te definiëren. In deze sectie gebruik je de functie **Generate system prompt** om het beoogde gedrag van de agent te beschrijven—in dit geval een calculator-agent—en laat je het model de system prompt voor je schrijven.

![Screenshot van de "Calculator Agent" interface in de AI Toolkit voor Visual Studio Code met een modaal venster open getiteld "Generate a prompt." Het modale venster legt uit dat een prompttemplate gegenereerd kan worden door basisgegevens te delen en bevat een tekstvak met de voorbeeld system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Onder het tekstvak staan de knoppen "Close" en "Generate." Op de achtergrond is een deel van de agentconfiguratie zichtbaar, inclusief het geselecteerde model "OpenAI GPT-4o (via GitHub)" en velden voor system en user prompts.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.nl.png)

1. Klik in de sectie **Prompts** op de knop **Generate system prompt**. Deze knop opent de prompt builder die AI gebruikt om een system prompt voor de agent te genereren.
1. Voer in het venster **Generate a prompt** het volgende in: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klik op de knop **Generate**. Er verschijnt een melding rechtsonder dat de system prompt wordt gegenereerd. Zodra de prompt klaar is, verschijnt deze in het veld **System prompt** van de **Agent (Prompt) Builder**.
1. Bekijk de **System prompt** en pas deze aan indien nodig.

### -3- Maak een MCP-server

Nu je de system prompt van je agent hebt gedefinieerd—die zijn gedrag en reacties stuurt—is het tijd om de agent praktische mogelijkheden te geven. In deze sectie maak je een calculator MCP-server met tools om optellen, aftrekken, vermenigvuldigen en delen uit te voeren. Deze server stelt je agent in staat om realtime wiskundige bewerkingen uit te voeren als reactie op natuurlijke taal prompts.

!["Screenshot van het onderste gedeelte van de Calculator Agent interface in de AI Toolkit-extensie voor Visual Studio Code. Het toont uitklapbare menu’s voor “Tools” en “Structure output,” samen met een dropdownmenu “Choose output format” ingesteld op “text.” Rechts is een knop “+ MCP Server” om een Model Context Protocol-server toe te voegen. Boven de Tools-sectie is een afbeelding-icoon als placeholder zichtbaar.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.nl.png)

AI Toolkit is uitgerust met templates om het maken van je eigen MCP-server te vergemakkelijken. We gebruiken de Python-template om de calculator MCP-server te maken.

*Opmerking*: De AI Toolkit ondersteunt momenteel Python en TypeScript.

1. Klik in de sectie **Tools** van de **Agent (Prompt) Builder** op de knop **+ MCP Server**. De extensie start een setup-wizard via de **Command Palette**.
1. Selecteer **+ Add Server**.
1. Kies **Create a New MCP Server**.
1. Selecteer **python-weather** als template.
1. Kies de **Default folder** om de MCP-server template op te slaan.
1. Voer de volgende naam in voor de server: **Calculator**
1. Er opent een nieuw Visual Studio Code-venster. Selecteer **Yes, I trust the authors**.
1. Maak een virtuele omgeving aan via de terminal (**Terminal** > **New Terminal**): `python -m venv .venv`
1. Activeer de virtuele omgeving via de terminal:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Installeer de dependencies via de terminal: `pip install -e .[dev]`
1. Open in de **Explorer**-weergave van de **Activity Bar** de map **src** en selecteer **server.py** om het bestand te openen in de editor.
1. Vervang de code in het bestand **server.py** door de volgende code en sla op:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- Draai de agent met de calculator MCP-server

Nu je agent tools heeft, is het tijd om ze te gebruiken! In deze sectie stuur je prompts naar de agent om te testen en te controleren of de agent de juiste tool van de calculator MCP-server gebruikt.

![Screenshot van de Calculator Agent interface in de AI Toolkit-extensie voor Visual Studio Code. In het linker paneel, onder “Tools,” is een MCP-server toegevoegd met de naam local-server-calculator_server, met vier beschikbare tools: add, subtract, multiply en divide. Een badge toont dat vier tools actief zijn. Daaronder is een ingeklapt “Structure output” gedeelte en een blauwe “Run” knop. In het rechter paneel, onder “Model Response,” roept de agent de multiply en subtract tools aan met inputs {"a": 3, "b": 25} en {"a": 75, "b": 20} respectievelijk. De uiteindelijke “Tool Response” is 75.0. Onderaan staat een “View Code” knop.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.nl.png)

Je draait de calculator MCP-server op je lokale ontwikkelmachine via de **Agent Builder** als MCP-client.

1. Druk op `F5` om de MCP-server te starten in debugmodus. De **Agent (Prompt) Builder** opent in een nieuw editor-tabblad. De status van de server is zichtbaar in de terminal.
1. Voer in het veld **User prompt** van de **Agent (Prompt) Builder** de volgende prompt in: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Klik op de knop **Run** om de reactie van de agent te genereren.
1. Bekijk de output van de agent. Het model zou moeten concluderen dat je **$55** hebt betaald.
1. Dit is wat er zou moeten gebeuren:
    - De agent kiest de tools **multiply** en **subtract** om te helpen bij de berekening.
    - De respectievelijke waarden `a` en `b` worden toegewezen voor de tool **multiply**.
    - De respectievelijke waarden `a` en `b` worden toegewezen voor de tool **subtract**.
    - De respons van elke tool wordt weergegeven in de respectievelijke **Tool Response**.
    - De uiteindelijke output van het model wordt weergegeven in de laatste **Model Response**.
1. Stuur extra prompts om de agent verder te testen. Je kunt de bestaande prompt in het veld **User prompt** aanpassen door erin te klikken en de prompt te vervangen.
1. Als je klaar bent met testen, kun je de server stoppen via de **terminal** door **CTRL/CMD+C** in te voeren.

## Opdracht

Probeer een extra tool toe te voegen aan je **server.py** bestand (bijvoorbeeld: het berekenen van de wortel van een getal). Stuur extra prompts in die de agent dwingen om je nieuwe tool (of bestaande tools) te gebruiken. Vergeet niet de server opnieuw te starten om de nieuw toegevoegde tools te laden.

## Oplossing

[Oplossing](./solution/README.md)

## Belangrijkste punten

De belangrijkste punten uit dit hoofdstuk zijn:

- De AI Toolkit-extensie is een uitstekende client waarmee je MCP-servers en hun tools kunt gebruiken.
- Je kunt nieuwe tools toevoegen aan MCP-servers, waardoor de mogelijkheden van de agent kunnen meegroeien met veranderende eisen.
- De AI Toolkit bevat templates (bijvoorbeeld Python MCP-server templates) om het maken van aangepaste tools te vereenvoudigen.

## Extra bronnen

- [AI Toolkit documentatie](https://aka.ms/AIToolkit/doc)

## Wat volgt
- Volgende: [Testen & Debuggen](../08-testing/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.