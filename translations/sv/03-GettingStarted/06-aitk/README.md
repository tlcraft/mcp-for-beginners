<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:23:11+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "sv"
}
-->
# Konsumera en server från AI Toolkit-tillägget för Visual Studio Code

När du bygger en AI-agent handlar det inte bara om att generera smarta svar; det handlar också om att ge din agent möjlighet att agera. Det är här Model Context Protocol (MCP) kommer in. MCP gör det enkelt för agenter att få tillgång till externa verktyg och tjänster på ett konsekvent sätt. Tänk på det som att koppla in din agent i en verktygslåda som den faktiskt kan använda.

Låt oss säga att du kopplar en agent till din kalkylator MCP-server. Plötsligt kan din agent utföra matematiska operationer bara genom att få en uppmaning som "Vad är 47 gånger 89?"—ingen behov av att hårdkoda logik eller bygga anpassade API:er.

## Översikt

Denna lektion täcker hur man ansluter en kalkylator MCP-server till en agent med [AI Toolkit](https://aka.ms/AIToolkit)-tillägget i Visual Studio Code, vilket gör att din agent kan utföra matematiska operationer som addition, subtraktion, multiplikation och division genom naturligt språk.

AI Toolkit är ett kraftfullt tillägg för Visual Studio Code som effektiviserar agentutveckling. AI-ingenjörer kan enkelt bygga AI-applikationer genom att utveckla och testa generativa AI-modeller—lokalt eller i molnet. Tillägget stöder de flesta större generativa modeller som finns tillgängliga idag.

*Obs*: AI Toolkit stöder för närvarande Python och TypeScript.

## Inlärningsmål

I slutet av denna lektion kommer du att kunna:

- Konsumera en MCP-server via AI Toolkit.
- Konfigurera en agentkonfiguration för att möjliggöra att den upptäcker och använder verktyg som tillhandahålls av MCP-servern.
- Använda MCP-verktyg via naturligt språk.

## Tillvägagångssätt

Så här behöver vi närma oss detta på en hög nivå:

- Skapa en agent och definiera dess systemprompt.
- Skapa en MCP-server med kalkylatorverktyg.
- Anslut Agent Builder till MCP-servern.
- Testa agentens verktygsanrop via naturligt språk.

Bra, nu när vi förstår flödet, låt oss konfigurera en AI-agent för att utnyttja externa verktyg genom MCP och förbättra dess förmågor!

## Förutsättningar

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit för Visual Studio Code](https://aka.ms/AIToolkit)

## Övning: Konsumera en server

I denna övning kommer du att bygga, köra och förbättra en AI-agent med verktyg från en MCP-server inuti Visual Studio Code med hjälp av AI Toolkit.

### -0- Förberedelse, lägg till OpenAI GPT-4o-modellen till Mina Modeller

Övningen använder **GPT-4o**-modellen. Modellen bör läggas till i **Mina Modeller** innan agenten skapas.

1. Öppna **AI Toolkit**-tillägget från **Aktivitetsfältet**.
1. I **Katalog**-sektionen, välj **Modeller** för att öppna **Model Catalog**. Att välja **Modeller** öppnar **Model Catalog** i en ny redigeringsflik.
1. I **Model Catalog** sökfältet, ange **OpenAI GPT-4o**.
1. Klicka på **+ Lägg till** för att lägga till modellen i din **Mina Modeller**-lista. Se till att du har valt modellen som är **Hosted by GitHub**.
1. I **Aktivitetsfältet**, bekräfta att **OpenAI GPT-4o**-modellen visas i listan.

### -1- Skapa en agent

**Agent (Prompt) Builder** gör det möjligt för dig att skapa och anpassa dina egna AI-drivna agenter. I denna sektion kommer du att skapa en ny agent och tilldela en modell för att driva konversationen.

1. Öppna **AI Toolkit**-tillägget från **Aktivitetsfältet**.
1. I **Verktyg**-sektionen, välj **Agent (Prompt) Builder**. Att välja **Agent (Prompt) Builder** öppnar **Agent (Prompt) Builder** i en ny redigeringsflik.
1. Klicka på **+ Ny Builder**-knappen. Tillägget kommer att starta en installationsguide via **Kommandopaletten**.
1. Ange namnet **Calculator Agent** och tryck på **Enter**.
1. I **Agent (Prompt) Builder**, för **Modell**-fältet, välj **OpenAI GPT-4o (via GitHub)**-modellen.

### -2- Skapa en systemprompt för agenten

Med agenten skapad är det dags att definiera dess personlighet och syfte. I denna sektion kommer du att använda funktionen **Generera systemprompt** för att beskriva agentens avsedda beteende—i detta fall en kalkylatoragent—och låta modellen skriva systemprompten åt dig.

1. För **Prompts**-sektionen, klicka på **Generera systemprompt**-knappen. Denna knapp öppnar promptskaparen som använder AI för att generera en systemprompt för agenten.
1. I **Generera en prompt**-fönstret, ange följande: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klicka på **Generera**-knappen. En avisering kommer att visas i det nedre högra hörnet som bekräftar att systemprompten genereras. När promptgenereringen är klar kommer prompten att visas i **Systemprompt**-fältet i **Agent (Prompt) Builder**.
1. Granska **Systemprompten** och ändra vid behov.

### -3- Skapa en MCP-server

Nu när du har definierat din agents systemprompt—som styr dess beteende och svar—är det dags att utrusta agenten med praktiska möjligheter. I denna sektion kommer du att skapa en kalkylator MCP-server med verktyg för att utföra addition, subtraktion, multiplikation och division. Denna server gör det möjligt för din agent att utföra matematiska operationer i realtid som svar på naturliga språkprompter.

AI Toolkit är utrustad med mallar för att underlätta skapandet av din egen MCP-server. Vi kommer att använda Python-mallen för att skapa kalkylator MCP-servern.

*Obs*: AI Toolkit stöder för närvarande Python och TypeScript.

1. I **Verktyg**-sektionen av **Agent (Prompt) Builder**, klicka på **+ MCP Server**-knappen. Tillägget kommer att starta en installationsguide via **Kommandopaletten**.
1. Välj **+ Lägg till Server**.
1. Välj **Skapa en Ny MCP Server**.
1. Välj **python-weather** som mallen.
1. Välj **Standardmapp** för att spara MCP-servermallen.
1. Ange följande namn för servern: **Calculator**
1. Ett nytt Visual Studio Code-fönster öppnas. Välj **Ja, jag litar på författarna**.
1. Använd terminalen (**Terminal** > **Ny Terminal**), skapa en virtuell miljö: `python -m venv .venv`
1. Använd terminalen, aktivera den virtuella miljön:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Använd terminalen, installera beroendena: `pip install -e .[dev]`
1. I **Utforskare**-vyn av **Aktivitetsfältet**, expandera **src**-katalogen och välj **server.py** för att öppna filen i redigeraren.
1. Ersätt koden i **server.py**-filen med följande och spara:

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

### -4- Kör agenten med kalkylator MCP-servern

Nu när din agent har verktyg är det dags att använda dem! I denna sektion kommer du att skicka in prompter till agenten för att testa och validera om agenten utnyttjar rätt verktyg från kalkylator MCP-servern.

Du kommer att köra kalkylator MCP-servern på din lokala utvecklingsmaskin via **Agent Builder** som MCP-klienten.

1. Tryck `F5` för att köra agenten och servern.
1. I **Användarprompt**-fältet, ange en fråga som agenten kan lösa med hjälp av MCP-serverns verktyg, till exempel: "Jag köpte 3 varor som kostade $25 vardera och använde sedan en rabatt på $20. Hur mycket betalade jag?"
1. Klicka på **Kör**-knappen för att skicka in prompten.
1. Kontrollera att rätt verktyg aktiveras och att korrekt **a** och **b**-värden tilldelas för **subtract**-verktyget.
    - Svaret från varje verktyg visas i respektive **Verktygssvar**.
    - Den slutliga utgången från modellen visas i den slutliga **Modellsvar**.
1. Skicka in ytterligare prompter för att vidare testa agenten. Du kan ändra den befintliga prompten i **Användarprompt**-fältet genom att klicka i fältet och ersätta den befintliga prompten.
1. När du är klar med att testa agenten kan du stoppa servern via **terminalen** genom att ange **CTRL/CMD+C** för att avsluta.

## Uppgift

Försök att lägga till en ytterligare verktygsinmatning till din **server.py**-fil (ex: returnera kvadratroten av ett nummer). Skicka in ytterligare prompter som skulle kräva att agenten utnyttjar ditt nya verktyg (eller befintliga verktyg). Se till att starta om servern för att ladda nyligen tillagda verktyg.

## Lösning

[Lösning](./solution/README.md)

## Viktiga insikter

Insikterna från detta kapitel är följande:

- AI Toolkit-tillägget är en utmärkt klient som låter dig konsumera MCP-servrar och deras verktyg.
- Du kan lägga till nya verktyg till MCP-servrar, vilket utökar agentens förmågor för att möta föränderliga krav.
- AI Toolkit inkluderar mallar (t.ex. Python MCP-servermallar) för att förenkla skapandet av anpassade verktyg.

## Ytterligare resurser

- [AI Toolkit-dokumentation](https://aka.ms/AIToolkit/doc)

## Vad är nästa

Nästa: [Lektion 4 Praktisk Implementering](/04-PracticalImplementation/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen notera att automatiserade översättningar kan innehålla fel eller felaktigheter. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi är inte ansvariga för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.