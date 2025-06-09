<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:40:19+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "sv"
}
-->
# Använda en server från AI Toolkit-tillägget för Visual Studio Code

När du bygger en AI-agent handlar det inte bara om att generera smarta svar; det handlar också om att ge din agent möjlighet att agera. Det är här Model Context Protocol (MCP) kommer in. MCP gör det enkelt för agenter att få tillgång till externa verktyg och tjänster på ett konsekvent sätt. Tänk på det som att koppla in din agent i en verktygslåda som den *verkligen* kan använda.

Låt oss säga att du kopplar en agent till din calculator MCP-server. Plötsligt kan din agent utföra matematiska operationer bara genom att få en fråga som ”Vad är 47 gånger 89?”—utan att behöva hårdkoda logik eller bygga egna API:er.

## Översikt

Den här lektionen visar hur du kopplar en calculator MCP-server till en agent med [AI Toolkit](https://aka.ms/AIToolkit)-tillägget i Visual Studio Code, vilket gör det möjligt för din agent att utföra matematiska operationer som addition, subtraktion, multiplikation och division via naturligt språk.

AI Toolkit är ett kraftfullt tillägg för Visual Studio Code som förenklar agentutveckling. AI Engineers kan enkelt bygga AI-applikationer genom att utveckla och testa generativa AI-modeller—lokalt eller i molnet. Tillägget stödjer de flesta stora generativa modeller som finns idag.

*Note*: AI Toolkit stödjer för närvarande Python och TypeScript.

## Lärandemål

Efter den här lektionen kommer du att kunna:

- Använda en MCP-server via AI Toolkit.
- Konfigurera en agentkonfiguration för att göra det möjligt för agenten att upptäcka och använda verktyg som tillhandahålls av MCP-servern.
- Använda MCP-verktyg via naturligt språk.

## Tillvägagångssätt

Så här behöver vi gå tillväga på en övergripande nivå:

- Skapa en agent och definiera dess systemprompt.
- Skapa en MCP-server med kalkylatorverktyg.
- Koppla Agent Builder till MCP-servern.
- Testa agentens verktygsanrop via naturligt språk.

Bra, nu när vi förstår flödet, låt oss konfigurera en AI-agent för att använda externa verktyg via MCP och därigenom förbättra dess kapabiliteter!

## Förutsättningar

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit för Visual Studio Code](https://aka.ms/AIToolkit)

## Övning: Använda en server

I denna övning kommer du att bygga, köra och förbättra en AI-agent med verktyg från en MCP-server inuti Visual Studio Code med hjälp av AI Toolkit.

### -0- Förberedelse, lägg till OpenAI GPT-4o-modellen i My Models

Övningen använder modellen **GPT-4o**. Modellen ska läggas till i **My Models** innan agenten skapas.

![Screenshot of a model selection interface in Visual Studio Code's AI Toolkit extension. The heading reads "Find the right model for your AI Solution" with a subtitle encouraging users to discover, test, and deploy AI models. Below, under “Popular Models,” six model cards are displayed: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), and DeepSeek-R1 (Ollama-hosted). Each card includes options to “Add” the model or “Try in Playground](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.sv.png)

1. Öppna **AI Toolkit**-tillägget från **Activity Bar**.
1. I avsnittet **Catalog**, välj **Models** för att öppna **Model Catalog**. Att välja **Models** öppnar **Model Catalog** i en ny flik i editorn.
1. Skriv in **OpenAI GPT-4o** i sökfältet i **Model Catalog**.
1. Klicka på **+ Add** för att lägga till modellen i din lista **My Models**. Se till att du har valt modellen som är **Hosted by GitHub**.
1. I **Activity Bar**, bekräfta att modellen **OpenAI GPT-4o** finns med i listan.

### -1- Skapa en agent

**Agent (Prompt) Builder** låter dig skapa och anpassa dina egna AI-drivna agenter. I detta avsnitt skapar du en ny agent och tilldelar en modell som ska driva konversationen.

![Screenshot of the "Calculator Agent" builder interface in the AI Toolkit extension for Visual Studio Code. On the left panel, the model selected is "OpenAI GPT-4o (via GitHub)." A system prompt reads "You are a professor in university teaching math," and the user prompt says, "Explain to me the Fourier equation in simple terms." Additional options include buttons for adding tools, enabling MCP Server, and selecting structured output. A blue “Run” button is at the bottom. On the right panel, under "Get Started with Examples," three sample agents are listed: Web Developer (with MCP Server, Second-Grade Simplifier, and Dream Interpreter, each with brief descriptions of their functions.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.sv.png)

1. Öppna **AI Toolkit**-tillägget från **Activity Bar**.
1. I avsnittet **Tools**, välj **Agent (Prompt) Builder**. Att välja **Agent (Prompt) Builder** öppnar **Agent (Prompt) Builder** i en ny flik i editorn.
1. Klicka på knappen **+ New Agent**. Tillägget startar en installationsguide via **Command Palette**.
1. Ange namnet **Calculator Agent** och tryck på **Enter**.
1. I **Agent (Prompt) Builder**, välj modellen **OpenAI GPT-4o (via GitHub)** i fältet **Model**.

### -2- Skapa en systemprompt för agenten

När agenten är skapad är det dags att definiera dess personlighet och syfte. I detta avsnitt använder du funktionen **Generate system prompt** för att beskriva agentens avsedda beteende—i detta fall en kalkylatoragent—och låta modellen skriva systemprompten åt dig.

![Screenshot of the "Calculator Agent" interface in the AI Toolkit for Visual Studio Code with a modal window open titled "Generate a prompt." The modal explains that a prompt template can be generated by sharing basic details and includes a text box with the sample system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Below the text box are "Close" and "Generate" buttons. In the background, part of the agent configuration is visible, including the selected model "OpenAI GPT-4o (via GitHub)" and fields for system and user prompts.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.sv.png)

1. I avsnittet **Prompts**, klicka på knappen **Generate system prompt**. Den här knappen öppnar promptbyggaren som använder AI för att generera en systemprompt för agenten.
1. I fönstret **Generate a prompt**, ange följande: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klicka på **Generate**. En notifikation visas nere till höger som bekräftar att systemprompten genereras. När genereringen är klar visas prompten i fältet **System prompt** i **Agent (Prompt) Builder**.
1. Granska **System prompt** och ändra vid behov.

### -3- Skapa en MCP-server

Nu när du har definierat agentens systemprompt—som styr dess beteende och svar—är det dags att utrusta agenten med praktiska funktioner. I detta avsnitt skapar du en calculator MCP-server med verktyg för addition, subtraktion, multiplikation och division. Denna server gör det möjligt för din agent att utföra matematiska beräkningar i realtid som svar på naturliga språkfrågor.

!["Screenshot of the lower section of the Calculator Agent interface in the AI Toolkit extension for Visual Studio Code. It shows expandable menus for “Tools” and “Structure output,” along with a dropdown menu labeled “Choose output format” set to “text.” To the right, there is a button labeled “+ MCP Server” for adding a Model Context Protocol server. An image icon placeholder is shown above the Tools section.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.sv.png)

AI Toolkit har mallar som gör det enkelt att skapa din egen MCP-server. Vi använder Python-mallen för att skapa calculator MCP-servern.

*Note*: AI Toolkit stödjer för närvarande Python och TypeScript.

1. I avsnittet **Tools** i **Agent (Prompt) Builder**, klicka på knappen **+ MCP Server**. Tillägget startar en installationsguide via **Command Palette**.
1. Välj **+ Add Server**.
1. Välj **Create a New MCP Server**.
1. Välj mallen **python-weather**.
1. Välj **Default folder** för att spara MCP-servermallen.
1. Ange följande namn för servern: **Calculator**
1. Ett nytt Visual Studio Code-fönster öppnas. Välj **Yes, I trust the authors**.
1. Använd terminalen (**Terminal** > **New Terminal**) för att skapa en virtuell miljö: `python -m venv .venv`
1. Aktivera den virtuella miljön via terminalen:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Installera beroenden via terminalen: `pip install -e .[dev]`
1. I **Explorer**-vyn i **Activity Bar**, expandera katalogen **src** och öppna filen **server.py** i editorn.
1. Ersätt koden i **server.py** med följande och spara:

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

### -4- Kör agenten med calculator MCP-servern

Nu när din agent har verktyg är det dags att använda dem! I detta avsnitt skickar du promptar till agenten för att testa och verifiera att agenten använder rätt verktyg från calculator MCP-servern.

![Screenshot of the Calculator Agent interface in the AI Toolkit extension for Visual Studio Code. On the left panel, under “Tools,” an MCP server named local-server-calculator_server is added, showing four available tools: add, subtract, multiply, and divide. A badge shows that four tools are active. Below is a collapsed “Structure output” section and a blue “Run” button. On the right panel, under “Model Response,” the agent invokes the multiply and subtract tools with inputs {"a": 3, "b": 25} and {"a": 75, "b": 20} respectively. The final “Tool Response” is shown as 75.0. A “View Code” button appears at the bottom.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.sv.png)

Du kommer att köra calculator MCP-servern på din lokala utvecklingsmaskin via **Agent Builder** som MCP-klient.

1. Tryck på `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` värden tilldelas för verktyget **subtract**.
    - Svaren från varje verktyg visas i respektive **Tool Response**.
    - Det slutgiltiga svaret från modellen visas i den slutgiltiga **Model Response**.
1. Skicka fler promptar för att testa agenten ytterligare. Du kan ändra den befintliga prompten i fältet **User prompt** genom att klicka i fältet och ersätta den befintliga prompten.
1. När du är klar med att testa agenten kan du stoppa servern via **terminalen** genom att trycka **CTRL/CMD+C** för att avsluta.

## Uppgift

Försök att lägga till ett extra verktyg i din fil **server.py** (t.ex. returnera kvadratroten av ett tal). Skicka ytterligare promptar som kräver att agenten använder ditt nya verktyg (eller befintliga verktyg). Kom ihåg att starta om servern för att ladda de nya verktygen.

## Lösning

[Solution](./solution/README.md)

## Viktiga punkter

De viktigaste punkterna från detta kapitel är:

- AI Toolkit-tillägget är en utmärkt klient som låter dig använda MCP-servrar och deras verktyg.
- Du kan lägga till nya verktyg i MCP-servrar och därigenom utöka agentens kapabiliteter för att möta förändrade behov.
- AI Toolkit inkluderar mallar (t.ex. Python MCP-servermallar) för att förenkla skapandet av anpassade verktyg.

## Ytterligare resurser

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Vad händer härnäst

Nästa: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, var vänlig notera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.