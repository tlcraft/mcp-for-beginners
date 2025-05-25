<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:25:04+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "nl"
}
-->
# Een server gebruiken van de AI Toolkit-extensie voor Visual Studio Code

Bij het bouwen van een AI-agent gaat het niet alleen om het genereren van slimme antwoorden; het gaat er ook om je agent in staat te stellen actie te ondernemen. Daar komt het Model Context Protocol (MCP) om de hoek kijken. MCP maakt het eenvoudig voor agents om externe tools en diensten op een consistente manier te benaderen. Zie het als het aansluiten van je agent op een gereedschapskist die het *echt* kan gebruiken.

Stel dat je een agent aansluit op je calculator MCP-server. Plotseling kan je agent wiskundige berekeningen uitvoeren door simpelweg een prompt te ontvangen zoals "Wat is 47 keer 89?"—geen noodzaak om logica hard te coderen of aangepaste API's te bouwen.

## Overzicht

Deze les behandelt hoe je een calculator MCP-server aansluit op een agent met de [AI Toolkit](https://aka.ms/AIToolkit) extensie in Visual Studio Code, zodat je agent wiskundige bewerkingen zoals optellen, aftrekken, vermenigvuldigen en delen kan uitvoeren via natuurlijke taal.

AI Toolkit is een krachtige extensie voor Visual Studio Code die agentontwikkeling stroomlijnt. AI-ingenieurs kunnen eenvoudig AI-toepassingen bouwen door generatieve AI-modellen te ontwikkelen en te testen—lokaal of in de cloud. De extensie ondersteunt de meeste grote generatieve modellen die vandaag beschikbaar zijn.

*Let op*: De AI Toolkit ondersteunt momenteel Python en TypeScript.

## Leerdoelen

Aan het einde van deze les kun je:

- Een MCP-server gebruiken via de AI Toolkit.
- Een agentconfiguratie instellen zodat deze tools kan ontdekken en gebruiken die door de MCP-server worden aangeboden.
- MCP-tools gebruiken via natuurlijke taal.

## Aanpak

Hier is hoe we dit op hoog niveau moeten benaderen:

- Maak een agent en definieer zijn systeemprompt.
- Maak een MCP-server met calculatortools.
- Verbind de Agent Builder met de MCP-server.
- Test de toolaanroep van de agent via natuurlijke taal.

Geweldig, nu we de flow begrijpen, laten we een AI-agent configureren om externe tools via MCP te gebruiken en zijn mogelijkheden te verbeteren!

## Vereisten

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit voor Visual Studio Code](https://aka.ms/AIToolkit)

## Oefening: Een server gebruiken

In deze oefening bouw je, voer je uit en verbeter je een AI-agent met tools van een MCP-server binnen Visual Studio Code met behulp van de AI Toolkit.

### -0- Pre-stap, voeg het OpenAI GPT-4o model toe aan Mijn Modellen

De oefening maakt gebruik van het **GPT-4o** model. Het model moet worden toegevoegd aan **Mijn Modellen** voordat je de agent maakt.

1. Open de **AI Toolkit** extensie vanuit de **Activiteitenbalk**.
1. In de **Catalogus** sectie, selecteer **Modellen** om de **Modelcatalogus** te openen. Door **Modellen** te selecteren wordt de **Modelcatalogus** geopend in een nieuw editor tabblad.
1. Voer in de zoekbalk van de **Modelcatalogus** **OpenAI GPT-4o** in.
1. Klik op **+ Toevoegen** om het model toe te voegen aan je **Mijn Modellen** lijst. Zorg ervoor dat je het model hebt geselecteerd dat **Gehost door GitHub** is.
1. In de **Activiteitenbalk**, bevestig dat het **OpenAI GPT-4o** model verschijnt in de lijst.

### -1- Maak een agent

De **Agent (Prompt) Builder** stelt je in staat om je eigen AI-aangedreven agents te maken en aan te passen. In deze sectie maak je een nieuwe agent en wijs je een model toe om het gesprek te ondersteunen.

1. Open de **AI Toolkit** extensie vanuit de **Activiteitenbalk**.
1. In de **Tools** sectie, selecteer **Agent (Prompt) Builder**. Door **Agent (Prompt) Builder** te selecteren wordt de **Agent (Prompt) Builder** geopend in een nieuw editor tabblad.
1. Klik op de **+ Nieuwe Builder** knop. De extensie start een setup wizard via de **Command Palette**.
1. Voer de naam **Calculator Agent** in en druk op **Enter**.
1. In de **Agent (Prompt) Builder**, voor het **Model** veld, selecteer het **OpenAI GPT-4o (via GitHub)** model.

### -2- Maak een systeemprompt voor de agent

Nu de agent is opgesteld, is het tijd om zijn persoonlijkheid en doel te definiëren. In deze sectie gebruik je de **Genereer systeemprompt** functie om het beoogde gedrag van de agent te beschrijven—in dit geval een calculator agent—en laat je het model de systeemprompt voor je schrijven.

1. Voor de **Prompts** sectie, klik op de **Genereer systeemprompt** knop. Deze knop opent in de prompt builder die AI gebruikt om een systeemprompt voor de agent te genereren.
1. In het **Genereer een prompt** venster, voer het volgende in: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klik op de **Genereer** knop. Er verschijnt een melding in de rechterbenedenhoek die bevestigt dat de systeemprompt wordt gegenereerd. Zodra de promptgeneratie is voltooid, verschijnt de prompt in het **Systeemprompt** veld van de **Agent (Prompt) Builder**.
1. Bekijk de **Systeemprompt** en pas indien nodig aan.

### -3- Maak een MCP-server

Nu je de systeemprompt van je agent hebt gedefinieerd—die zijn gedrag en reacties stuurt—is het tijd om de agent uit te rusten met praktische mogelijkheden. In deze sectie maak je een calculator MCP-server met tools om optel-, aftrek-, vermenigvuldigings- en delingsberekeningen uit te voeren. Deze server stelt je agent in staat om realtime wiskundige bewerkingen uit te voeren als reactie op natuurlijke taalprompts.

AI Toolkit is uitgerust met templates voor het eenvoudig creëren van je eigen MCP-server. We gebruiken het Python-template voor het maken van de calculator MCP-server.

*Let op*: De AI Toolkit ondersteunt momenteel Python en TypeScript.

1. In de **Tools** sectie van de **Agent (Prompt) Builder**, klik op de **+ MCP Server** knop. De extensie start een setup wizard via de **Command Palette**.
1. Selecteer **+ Server toevoegen**.
1. Selecteer **Maak een nieuwe MCP-server**.
1. Selecteer **python-weather** als het template.
1. Selecteer **Standaardmap** om het MCP-servertemplate op te slaan.
1. Voer de volgende naam voor de server in: **Calculator**
1. Er opent een nieuw Visual Studio Code-venster. Selecteer **Ja, ik vertrouw de auteurs**.
1. Gebruik de terminal (**Terminal** > **Nieuwe Terminal**), maak een virtuele omgeving: `python -m venv .venv`
1. Gebruik de terminal, activeer de virtuele omgeving:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Gebruik de terminal, installeer de afhankelijkheden: `pip install -e .[dev]`
1. In de **Explorer** weergave van de **Activiteitenbalk**, vouw de **src** directory uit en selecteer **server.py** om het bestand in de editor te openen.
1. Vervang de code in het **server.py** bestand met het volgende en sla op:

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

### -4- Voer de agent uit met de calculator MCP-server

Nu je agent tools heeft, is het tijd om ze te gebruiken! In deze sectie dien je prompts in bij de agent om te testen en valideren of de agent de juiste tool van de calculator MCP-server benut.

Je voert de calculator MCP-server uit op je lokale ontwikkelmachine via de **Agent Builder** als de MCP-client.

1. Druk op `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Ik kocht 3 items geprijsd op $25 elk en gebruikte vervolgens een korting van $20. Hoeveel betaalde ik?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` waarden worden toegewezen voor de **aftrekken** tool.
    - Het antwoord van elke tool wordt gegeven in de respectieve **Tool Response**.
    - De uiteindelijke output van het model wordt gegeven in de uiteindelijke **Model Response**.
1. Dien aanvullende prompts in om de agent verder te testen. Je kunt de bestaande prompt in het **Gebruikersprompt** veld wijzigen door in het veld te klikken en de bestaande prompt te vervangen.
1. Zodra je klaar bent met het testen van de agent, kun je de server stoppen via de **terminal** door **CTRL/CMD+C** in te voeren om te stoppen.

## Opdracht

Probeer een extra tooltoevoeging toe te voegen aan je **server.py** bestand (bijv. de vierkantswortel van een getal retourneren). Dien aanvullende prompts in die de agent vereisen om je nieuwe tool (of bestaande tools) te gebruiken. Zorg ervoor dat je de server opnieuw start om nieuw toegevoegde tools te laden.

## Oplossing

[Oplossing](./solution/README.md)

## Belangrijkste inzichten

De inzichten uit dit hoofdstuk zijn de volgende:

- De AI Toolkit-extensie is een geweldige client waarmee je MCP-servers en hun tools kunt gebruiken.
- Je kunt nieuwe tools toevoegen aan MCP-servers, waardoor de mogelijkheden van de agent worden uitgebreid om aan veranderende eisen te voldoen.
- De AI Toolkit bevat templates (bijv. Python MCP-servertemplates) om het creëren van aangepaste tools te vereenvoudigen.

## Aanvullende bronnen

- [AI Toolkit documenten](https://aka.ms/AIToolkit/doc)

## Wat is het volgende

Volgende: [Les 4 Praktische Implementatie](/04-PracticalImplementation/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we ons best doen voor nauwkeurigheid, houd er rekening mee dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.