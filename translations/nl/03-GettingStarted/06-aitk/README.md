<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:43:24+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "nl"
}
-->
# Een server gebruiken vanuit de AI Toolkit-extensie voor Visual Studio Code

Wanneer je een AI-agent bouwt, draait het niet alleen om het genereren van slimme antwoorden; het gaat er ook om dat je agent in staat is om actie te ondernemen. Daar komt het Model Context Protocol (MCP) om de hoek kijken. MCP maakt het eenvoudig voor agents om op een consistente manier toegang te krijgen tot externe tools en diensten. Zie het als het aansluiten van je agent op een gereedschapskist die hij *echt* kan gebruiken.

Stel dat je een agent koppelt aan je calculator MCP-server. Plots kan je agent wiskundige bewerkingen uitvoeren door simpelweg een prompt te ontvangen zoals “Wat is 47 keer 89?” — zonder dat je logica hoeft te coderen of aangepaste API’s hoeft te bouwen.

## Overzicht

Deze les behandelt hoe je een calculator MCP-server koppelt aan een agent met de [AI Toolkit](https://aka.ms/AIToolkit) extensie in Visual Studio Code, zodat je agent wiskundige bewerkingen zoals optellen, aftrekken, vermenigvuldigen en delen kan uitvoeren via natuurlijke taal.

AI Toolkit is een krachtige extensie voor Visual Studio Code die het ontwikkelen van agents vereenvoudigt. AI Engineers kunnen eenvoudig AI-applicaties bouwen door generatieve AI-modellen te ontwikkelen en testen — lokaal of in de cloud. De extensie ondersteunt de meeste grote generatieve modellen die vandaag beschikbaar zijn.

*Let op*: De AI Toolkit ondersteunt momenteel Python en TypeScript.

## Leerdoelen

Aan het einde van deze les kun je:

- Een MCP-server gebruiken via de AI Toolkit.
- Een agentconfiguratie instellen zodat deze tools kan ontdekken en gebruiken die door de MCP-server worden aangeboden.
- MCP-tools gebruiken via natuurlijke taal.

## Aanpak

Zo pakken we dit op hoofdlijnen aan:

- Maak een agent en definieer zijn system prompt.
- Maak een MCP-server met calculator tools.
- Verbind de Agent Builder met de MCP-server.
- Test het aanroepen van tools door de agent via natuurlijke taal.

Top, nu we de flow begrijpen, laten we een AI-agent configureren om externe tools te gebruiken via MCP en zo zijn mogelijkheden uitbreiden!

## Vereisten

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit voor Visual Studio Code](https://aka.ms/AIToolkit)

## Oefening: Een server gebruiken

In deze oefening bouw, start en verbeter je een AI-agent met tools van een MCP-server binnen Visual Studio Code met behulp van de AI Toolkit.

### -0- Voorbereiding: voeg het OpenAI GPT-4o model toe aan Mijn Modellen

De oefening maakt gebruik van het **GPT-4o** model. Dit model moet worden toegevoegd aan **Mijn Modellen** voordat je de agent aanmaakt.

![Screenshot van een modelselectie-interface in de AI Toolkit-extensie van Visual Studio Code. De titel luidt "Find the right model for your AI Solution" met een ondertitel die gebruikers aanmoedigt AI-modellen te ontdekken, testen en implementeren. Onder “Popular Models” worden zes modelkaarten weergegeven: DeepSeek-R1 (gehost op GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Klein, Snel) en DeepSeek-R1 (gehost op Ollama). Elke kaart bevat opties om het model toe te voegen of te proberen in de Playground.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.nl.png)

1. Open de **AI Toolkit** extensie via de **Activity Bar**.
2. Ga naar de sectie **Catalog** en selecteer **Models** om de **Model Catalog** te openen. Dit opent de **Model Catalog** in een nieuw editor-tabblad.
3. Typ in de zoekbalk van de **Model Catalog** **OpenAI GPT-4o**.
4. Klik op **+ Add** om het model toe te voegen aan je lijst **Mijn Modellen**. Zorg ervoor dat je het model selecteert dat **Gehost door GitHub** is.
5. Controleer in de **Activity Bar** of het **OpenAI GPT-4o** model in de lijst verschijnt.

### -1- Maak een agent

De **Agent (Prompt) Builder** stelt je in staat je eigen AI-gestuurde agents te creëren en aan te passen. In deze sectie maak je een nieuwe agent en wijs je een model toe om het gesprek aan te sturen.

![Screenshot van de "Calculator Agent" builder-interface in de AI Toolkit-extensie voor Visual Studio Code. In het linker paneel is het model "OpenAI GPT-4o (via GitHub)" geselecteerd. Een system prompt luidt "Je bent een professor aan de universiteit die wiskunde geeft," en de user prompt zegt "Leg de Fourier-vergelijking in eenvoudige termen uit." Extra opties bevatten knoppen om tools toe te voegen, MCP Server in te schakelen en gestructureerde output te selecteren. Onderaan staat een blauwe “Run” knop. In het rechterpaneel onder "Get Started with Examples" worden drie voorbeeldagents weergegeven: Web Developer (met MCP Server), Second-Grade Simplifier en Dream Interpreter, elk met korte beschrijvingen van hun functies.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.nl.png)

1. Open de **AI Toolkit** extensie via de **Activity Bar**.
2. Ga naar de sectie **Tools** en selecteer **Agent (Prompt) Builder**. Dit opent de **Agent (Prompt) Builder** in een nieuw editor-tabblad.
3. Klik op de knop **+ New Agent**. De extensie start een setup-wizard via de **Command Palette**.
4. Voer de naam **Calculator Agent** in en druk op **Enter**.
5. Kies in de **Agent (Prompt) Builder** bij het veld **Model** het model **OpenAI GPT-4o (via GitHub)**.

### -2- Maak een system prompt voor de agent

Nu de agent is opgezet, is het tijd om zijn persoonlijkheid en doel te bepalen. In deze sectie gebruik je de functie **Generate system prompt** om het gedrag van de agent te beschrijven — in dit geval een calculator agent — en laat je het model de system prompt voor je schrijven.

![Screenshot van de "Calculator Agent" interface in de AI Toolkit voor Visual Studio Code met een modaal venster open getiteld "Generate a prompt." Het modale venster legt uit dat een prompttemplate gegenereerd kan worden door basisinformatie te delen en bevat een tekstvak met de voorbeeld system prompt: "Je bent een behulpzame en efficiënte wiskunde-assistent. Bij een probleem met basisrekenen geef je het juiste resultaat." Onder het tekstvak staan de knoppen "Close" en "Generate." Op de achtergrond is een deel van de agentconfiguratie zichtbaar, inclusief het geselecteerde model "OpenAI GPT-4o (via GitHub)" en velden voor system en user prompts.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.nl.png)

1. Klik in de sectie **Prompts** op de knop **Generate system prompt**. Deze knop opent de prompt builder die AI gebruikt om een system prompt voor de agent te genereren.
2. Vul in het venster **Generate a prompt** het volgende in: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Klik op de knop **Generate**. Onderaan rechts verschijnt een melding dat de system prompt wordt gegenereerd. Zodra de prompt klaar is, verschijnt deze in het veld **System prompt** van de **Agent (Prompt) Builder**.
4. Bekijk de **System prompt** en pas deze indien nodig aan.

### -3- Maak een MCP-server

Nu je de system prompt van je agent hebt bepaald — die zijn gedrag en reacties stuurt — is het tijd om de agent praktische vaardigheden te geven. In deze sectie maak je een calculator MCP-server met tools om optellen, aftrekken, vermenigvuldigen en delen uit te voeren. Deze server stelt je agent in staat om realtime wiskundige bewerkingen uit te voeren op basis van natuurlijke taal prompts.

![Screenshot van het onderste gedeelte van de Calculator Agent interface in de AI Toolkit extensie voor Visual Studio Code. Het toont uitklapbare menu’s voor “Tools” en “Structure output,” samen met een dropdown menu “Choose output format” ingesteld op “text.” Rechts staat een knop “+ MCP Server” om een Model Context Protocol-server toe te voegen. Boven de Tools-sectie is een afbeelding-icoon als placeholder te zien.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.nl.png)

AI Toolkit heeft templates om het maken van je eigen MCP-server makkelijk te maken. We gebruiken de Python-template om de calculator MCP-server te maken.

*Let op*: De AI Toolkit ondersteunt momenteel Python en TypeScript.

1. Klik in de sectie **Tools** van de **Agent (Prompt) Builder** op de knop **+ MCP Server**. De extensie start een setup-wizard via de **Command Palette**.
2. Selecteer **+ Add Server**.
3. Kies **Create a New MCP Server**.
4. Selecteer **python-weather** als template.
5. Kies de **Default folder** om de MCP-server template op te slaan.
6. Geef de server de naam: **Calculator**
7. Er opent een nieuw Visual Studio Code-venster. Selecteer **Yes, I trust the authors**.
8. Maak in de terminal (**Terminal** > **New Terminal**) een virtuele omgeving aan: `python -m venv .venv`
9. Activeer in de terminal de virtuele omgeving:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. Installeer in de terminal de benodigde dependencies: `pip install -e .[dev]`
11. Open in de **Explorer** van de **Activity Bar** de map **src** en selecteer **server.py** om het bestand te openen.
12. Vervang de code in **server.py** door de volgende code en sla op:

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

### -4- Start de agent met de calculator MCP-server

Nu je agent tools heeft, is het tijd om ze te gebruiken! In deze sectie stuur je prompts naar de agent om te testen en te controleren of de agent de juiste tool uit de calculator MCP-server gebruikt.

![Screenshot van de Calculator Agent interface in de AI Toolkit extensie voor Visual Studio Code. In het linker paneel, onder “Tools,” is een MCP-server toegevoegd met de naam local-server-calculator_server, die vier beschikbare tools toont: add, subtract, multiply en divide. Er is een badge die aangeeft dat vier tools actief zijn. Daaronder is de sectie “Structure output” ingeklapt en een blauwe “Run” knop zichtbaar. In het rechter paneel, onder “Model Response,” roept de agent de multiply en subtract tools aan met inputs {"a": 3, "b": 25} en {"a": 75, "b": 20} respectievelijk. De uiteindelijke “Tool Response” wordt getoond als 75.0. Onderaan staat een “View Code” knop.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.nl.png)

Je draait de calculator MCP-server lokaal op je ontwikkelmachine via de **Agent Builder** als MCP-client.

1. Druk op `F5` om de server te starten.
2. Stuur de prompt: ` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` waarden worden toegewezen aan de **subtract** tool.
    - De reactie van elke tool verschijnt in het bijbehorende **Tool Response**.
    - De uiteindelijke output van het model zie je in de laatste **Model Response**.
3. Verstuur extra prompts om de agent verder te testen. Je kunt de bestaande prompt in het veld **User prompt** aanpassen door erin te klikken en de tekst te wijzigen.
4. Als je klaar bent met testen, stop je de server via de **terminal** met **CTRL/CMD+C**.

## Opdracht

Probeer een extra tool toe te voegen aan je **server.py** bestand (bijvoorbeeld: de wortel van een getal berekenen). Verstuur prompts die de agent dwingen je nieuwe tool (of bestaande tools) te gebruiken. Vergeet niet de server te herstarten zodat de nieuwe tools geladen worden.

## Oplossing

[Oplossing](./solution/README.md)

## Belangrijkste leerpunten

De belangrijkste inzichten uit dit hoofdstuk zijn:

- De AI Toolkit-extensie is een uitstekende client om MCP-servers en hun tools te gebruiken.
- Je kunt nieuwe tools toevoegen aan MCP-servers, waardoor de mogelijkheden van je agent uitbreiden om aan veranderende eisen te voldoen.
- De AI Toolkit bevat templates (bijvoorbeeld Python MCP-server templates) die het maken van eigen tools vereenvoudigen.

## Aanvullende bronnen

- [AI Toolkit documentatie](https://aka.ms/AIToolkit/doc)

## Wat volgt

Volgende les: [Les 4 Praktische Implementatie](/04-PracticalImplementation/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onjuistheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.