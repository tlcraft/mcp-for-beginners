<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T17:36:58+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "sv"
}
-->
# Använda en server från AI Toolkit-tillägget för Visual Studio Code

När du bygger en AI-agent handlar det inte bara om att generera smarta svar; det handlar också om att ge din agent möjlighet att agera. Det är här Model Context Protocol (MCP) kommer in. MCP gör det enkelt för agenter att få tillgång till externa verktyg och tjänster på ett konsekvent sätt. Tänk på det som att koppla in din agent i en verktygslåda som den *verkligen* kan använda.

Låt oss säga att du kopplar en agent till din kalkylator-MCP-server. Plötsligt kan din agent utföra matematiska operationer bara genom att få en prompt som ”Vad är 47 gånger 89?” — utan att behöva hårdkoda logik eller bygga egna API:er.

## Översikt

Den här lektionen visar hur du kopplar en kalkylator-MCP-server till en agent med [AI Toolkit](https://aka.ms/AIToolkit)-tillägget i Visual Studio Code, vilket gör det möjligt för din agent att utföra matematiska operationer som addition, subtraktion, multiplikation och division via naturligt språk.

AI Toolkit är ett kraftfullt tillägg för Visual Studio Code som förenklar agentutveckling. AI-ingenjörer kan enkelt bygga AI-applikationer genom att utveckla och testa generativa AI-modeller — lokalt eller i molnet. Tillägget stödjer de flesta större generativa modeller som finns idag.

*Notera*: AI Toolkit stödjer för närvarande Python och TypeScript.

## Lärandemål

Efter den här lektionen kommer du att kunna:

- Använda en MCP-server via AI Toolkit.
- Konfigurera en agent för att upptäcka och använda verktyg som tillhandahålls av MCP-servern.
- Använda MCP-verktyg via naturligt språk.

## Tillvägagångssätt

Så här behöver vi gå tillväga på en övergripande nivå:

- Skapa en agent och definiera dess systemprompt.
- Skapa en MCP-server med kalkylatorverktyg.
- Koppla Agent Builder till MCP-servern.
- Testa agentens verktygsanrop via naturligt språk.

Bra, nu när vi förstår flödet, låt oss konfigurera en AI-agent för att använda externa verktyg via MCP och därmed utöka dess kapacitet!

## Förutsättningar

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit för Visual Studio Code](https://aka.ms/AIToolkit)

## Övning: Använda en server

I den här övningen kommer du att bygga, köra och förbättra en AI-agent med verktyg från en MCP-server inuti Visual Studio Code med hjälp av AI Toolkit.

### -0- Förberedelse, lägg till OpenAI GPT-4o-modellen i My Models

Övningen använder modellen **GPT-4o**. Modellen bör läggas till i **My Models** innan du skapar agenten.

![Skärmdump av ett modellval i AI Toolkit-tillägget för Visual Studio Code. Rubriken lyder "Find the right model for your AI Solution" med en undertitel som uppmuntrar användare att upptäcka, testa och distribuera AI-modeller. Under ”Popular Models” visas sex modellkort: DeepSeek-R1 (hostad på GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) och DeepSeek-R1 (hostad på Ollama). Varje kort har alternativ för att ”Add” modellen eller ”Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.sv.png)

1. Öppna **AI Toolkit**-tillägget från **Activity Bar**.
1. I avsnittet **Catalog**, välj **Models** för att öppna **Model Catalog**. Att välja **Models** öppnar **Model Catalog** i en ny redigeringsflik.
1. Skriv **OpenAI GPT-4o** i sökfältet i **Model Catalog**.
1. Klicka på **+ Add** för att lägga till modellen i din lista **My Models**. Se till att du valt modellen som är **Hosted by GitHub**.
1. I **Activity Bar**, kontrollera att modellen **OpenAI GPT-4o** visas i listan.

### -1- Skapa en agent

**Agent (Prompt) Builder** låter dig skapa och anpassa dina egna AI-drivna agenter. I det här avsnittet skapar du en ny agent och tilldelar en modell som driver konversationen.

![Skärmdump av "Calculator Agent" i AI Toolkit-tillägget för Visual Studio Code. I vänster panel är modellen "OpenAI GPT-4o (via GitHub)" vald. En systemprompt lyder "You are a professor in university teaching math," och användarprompten säger "Explain to me the Fourier equation in simple terms." Ytterligare alternativ inkluderar knappar för att lägga till verktyg, aktivera MCP Server och välja strukturerad output. En blå “Run”-knapp finns längst ner. I höger panel, under "Get Started with Examples," listas tre exempelagenter: Web Developer (med MCP Server, Second-Grade Simplifier och Dream Interpreter, var och en med korta beskrivningar av deras funktioner).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.sv.png)

1. Öppna **AI Toolkit**-tillägget från **Activity Bar**.
1. I avsnittet **Tools**, välj **Agent (Prompt) Builder**. Att välja **Agent (Prompt) Builder** öppnar den i en ny redigeringsflik.
1. Klicka på knappen **+ New Agent**. Tillägget startar en installationsguide via **Command Palette**.
1. Ange namnet **Calculator Agent** och tryck på **Enter**.
1. I **Agent (Prompt) Builder**, välj modellen **OpenAI GPT-4o (via GitHub)** i fältet **Model**.

### -2- Skapa en systemprompt för agenten

När agenten är skapad är det dags att definiera dess personlighet och syfte. I det här avsnittet använder du funktionen **Generate system prompt** för att beskriva agentens avsedda beteende — i det här fallet en kalkylatoragent — och låta modellen skriva systemprompten åt dig.

![Skärmdump av "Calculator Agent" i AI Toolkit för Visual Studio Code med ett modalt fönster öppet med titeln "Generate a prompt." Det modala fönstret förklarar att en promptmall kan genereras genom att dela grundläggande detaljer och innehåller en textruta med exempel på systemprompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Under textrutan finns knapparna "Close" och "Generate". I bakgrunden syns delar av agentkonfigurationen, inklusive vald modell "OpenAI GPT-4o (via GitHub)" och fält för system- och användarprompt.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.sv.png)

1. I avsnittet **Prompts**, klicka på knappen **Generate system prompt**. Denna knapp öppnar promptbyggaren som använder AI för att generera en systemprompt för agenten.
1. I fönstret **Generate a prompt**, skriv in följande: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klicka på **Generate**. En notis visas nere till höger som bekräftar att systemprompten genereras. När genereringen är klar visas prompten i fältet **System prompt** i **Agent (Prompt) Builder**.
1. Granska **System prompt** och ändra vid behov.

### -3- Skapa en MCP-server

Nu när du har definierat agentens systemprompt — som styr dess beteende och svar — är det dags att utrusta agenten med praktiska funktioner. I det här avsnittet skapar du en kalkylator-MCP-server med verktyg för addition, subtraktion, multiplikation och division. Denna server gör det möjligt för din agent att utföra matematiska beräkningar i realtid som svar på naturliga språk-promptar.

![Skärmdump av den nedre delen av Calculator Agent-gränssnittet i AI Toolkit-tillägget för Visual Studio Code. Den visar expanderbara menyer för ”Tools” och ”Structure output”, tillsammans med en rullgardinsmeny märkt ”Choose output format” inställd på ”text.” Till höger finns en knapp märkt ”+ MCP Server” för att lägga till en Model Context Protocol-server. En bildikon är placerad ovanför Tools-sektionen.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.sv.png)

AI Toolkit är utrustat med mallar för att underlätta skapandet av din egen MCP-server. Vi kommer att använda Python-mallen för att skapa kalkylator-MCP-servern.

*Notera*: AI Toolkit stödjer för närvarande Python och TypeScript.

1. I avsnittet **Tools** i **Agent (Prompt) Builder**, klicka på knappen **+ MCP Server**. Tillägget startar en installationsguide via **Command Palette**.
1. Välj **+ Add Server**.
1. Välj **Create a New MCP Server**.
1. Välj **python-weather** som mall.
1. Välj **Default folder** för att spara MCP-servermallen.
1. Ange följande namn för servern: **Calculator**
1. Ett nytt Visual Studio Code-fönster öppnas. Välj **Yes, I trust the authors**.
1. Använd terminalen (**Terminal** > **New Terminal**) för att skapa en virtuell miljö: `python -m venv .venv`
1. Aktivera den virtuella miljön i terminalen:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Installera beroenden i terminalen: `pip install -e .[dev]`
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

### -4- Kör agenten med kalkylator-MCP-servern

Nu när din agent har verktyg är det dags att använda dem! I det här avsnittet skickar du promptar till agenten för att testa och verifiera att agenten använder rätt verktyg från kalkylator-MCP-servern.

![Skärmdump av Calculator Agent-gränssnittet i AI Toolkit-tillägget för Visual Studio Code. I vänster panel, under ”Tools,” är en MCP-server med namnet local-server-calculator_server tillagd, som visar fyra tillgängliga verktyg: add, subtract, multiply och divide. En badge visar att fyra verktyg är aktiva. Nedanför finns en ihopfälld sektion ”Structure output” och en blå ”Run”-knapp. I höger panel, under ”Model Response,” anropar agenten verktygen multiply och subtract med input {"a": 3, "b": 25} respektive {"a": 75, "b": 20}. Det slutgiltiga ”Tool Response” visas som 75.0. En knapp ”View Code” finns längst ner.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.sv.png)

Du kommer att köra kalkylator-MCP-servern på din lokala utvecklingsmaskin via **Agent Builder** som MCP-klient.

1. Tryck på `F5` för att starta felsökning av MCP-servern. **Agent (Prompt) Builder** öppnas i en ny redigeringsflik. Serverns status syns i terminalen.
1. I fältet **User prompt** i **Agent (Prompt) Builder**, skriv följande prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Klicka på **Run** för att generera agentens svar.
1. Granska agentens output. Modellen bör dra slutsatsen att du betalade **$55**.
1. Här är en sammanfattning av vad som bör hända:
    - Agenten väljer verktygen **multiply** och **subtract** för att hjälpa till med beräkningen.
    - De respektive värdena `a` och `b` tilldelas för verktyget **multiply**.
    - De respektive värdena `a` och `b` tilldelas för verktyget **subtract**.
    - Svaren från varje verktyg visas i respektive **Tool Response**.
    - Det slutgiltiga svaret från modellen visas i den slutgiltiga **Model Response**.
1. Skicka fler promptar för att testa agenten ytterligare. Du kan ändra den befintliga prompten i fältet **User prompt** genom att klicka i fältet och ersätta den befintliga prompten.
1. När du är klar med att testa agenten kan du stoppa servern via terminalen genom att trycka **CTRL/CMD+C** för att avsluta.

## Uppgift

Försök att lägga till ett extra verktyg i din fil **server.py** (t.ex. returnera kvadratroten av ett tal). Skicka fler promptar som kräver att agenten använder ditt nya verktyg (eller befintliga verktyg). Kom ihåg att starta om servern för att ladda de nya verktygen.

## Lösning

[Lösning](./solution/README.md)

## Viktiga insikter

De viktigaste insikterna från detta kapitel är:

- AI Toolkit-tillägget är en utmärkt klient som låter dig använda MCP-servrar och deras verktyg.
- Du kan lägga till nya verktyg till MCP-servrar och därmed utöka agentens kapacitet för att möta förändrade behov.
- AI Toolkit inkluderar mallar (t.ex. Python MCP-servermallar) som förenklar skapandet av egna verktyg.

## Ytterligare resurser

- [AI Toolkit-dokumentation](https://aka.ms/AIToolkit/doc)

## Vad händer härnäst
- Nästa: [Testning & Felsökning](../08-testing/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.