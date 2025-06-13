<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:21:49+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "da"
}
-->
# Forbrug af en server fra AI Toolkit-udvidelsen til Visual Studio Code

Når du bygger en AI-agent, handler det ikke kun om at generere smarte svar; det handler også om at give din agent evnen til at handle. Her kommer Model Context Protocol (MCP) ind i billedet. MCP gør det nemt for agenter at få adgang til eksterne værktøjer og tjenester på en ensartet måde. Tænk på det som at tilslutte din agent til en værktøjskasse, den *virkelig* kan bruge.

Lad os sige, at du forbinder en agent til din calculator MCP-server. Pludselig kan din agent udføre matematiske operationer blot ved at modtage en prompt som "Hvad er 47 gange 89?" — uden at skulle kode logikken direkte eller bygge specialiserede API'er.

## Oversigt

Denne lektion viser, hvordan du forbinder en calculator MCP-server til en agent med [AI Toolkit](https://aka.ms/AIToolkit)-udvidelsen i Visual Studio Code, så din agent kan udføre matematiske operationer som addition, subtraktion, multiplikation og division via naturligt sprog.

AI Toolkit er en kraftfuld udvidelse til Visual Studio Code, der forenkler udviklingen af agenter. AI-ingeniører kan nemt bygge AI-applikationer ved at udvikle og teste generative AI-modeller — enten lokalt eller i skyen. Udvidelsen understøtter de fleste større generative modeller, der findes i dag.

*Note*: AI Toolkit understøtter i øjeblikket Python og TypeScript.

## Læringsmål

Når du er færdig med denne lektion, vil du kunne:

- Forbruge en MCP-server via AI Toolkit.
- Konfigurere en agent, så den kan finde og bruge værktøjer, der leveres af MCP-serveren.
- Bruge MCP-værktøjer via naturligt sprog.

## Fremgangsmåde

Her er en overordnet tilgang:

- Opret en agent og definer dens systemprompt.
- Opret en MCP-server med calculator-værktøjer.
- Forbind Agent Builder til MCP-serveren.
- Test agentens brug af værktøjer via naturligt sprog.

Godt, nu hvor vi forstår flowet, lad os konfigurere en AI-agent til at udnytte eksterne værktøjer gennem MCP og dermed udvide dens evner!

## Forudsætninger

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit til Visual Studio Code](https://aka.ms/AIToolkit)

## Øvelse: Forbrug en server

I denne øvelse skal du bygge, køre og forbedre en AI-agent med værktøjer fra en MCP-server inde i Visual Studio Code ved hjælp af AI Toolkit.

### -0- Forberedelse, tilføj OpenAI GPT-4o-modellen til My Models

Øvelsen bruger **GPT-4o**-modellen. Modellen skal tilføjes til **My Models**, inden du opretter agenten.

![Screenshot af modelvalg i AI Toolkit-udvidelsen til Visual Studio Code. Overskriften lyder "Find the right model for your AI Solution" med en undertekst, der opfordrer brugere til at opdage, teste og implementere AI-modeller. Under “Popular Models” vises seks modelkort: DeepSeek-R1 (hostet på GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) og DeepSeek-R1 (hostet på Ollama). Hvert kort har knapper til at “Add” modellen eller “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.da.png)

1. Åbn **AI Toolkit**-udvidelsen fra **Activity Bar**.
1. I **Catalog**-sektionen vælg **Models** for at åbne **Model Catalog**. Når du vælger **Models**, åbnes **Model Catalog** i en ny editor-fane.
1. Søg efter **OpenAI GPT-4o** i søgefeltet i **Model Catalog**.
1. Klik på **+ Add** for at tilføje modellen til din liste over **My Models**. Sørg for, at du har valgt modellen, der er **hostet af GitHub**.
1. Bekræft i **Activity Bar**, at **OpenAI GPT-4o**-modellen nu vises i listen.

### -1- Opret en agent

**Agent (Prompt) Builder** gør det muligt at oprette og tilpasse dine egne AI-drevne agenter. I denne sektion opretter du en ny agent og vælger en model til at drive samtalen.

![Screenshot af "Calculator Agent" builder-interface i AI Toolkit-udvidelsen til Visual Studio Code. Til venstre er modellen valgt som "OpenAI GPT-4o (via GitHub)." En systemprompt lyder "You are a professor in university teaching math," og brugerprompten siger "Explain to me the Fourier equation in simple terms." Yderligere muligheder inkluderer knapper til at tilføje værktøjer, aktivere MCP Server og vælge struktureret output. En blå “Run” knap er nederst. Til højre vises under "Get Started with Examples" tre eksempler på agenter: Web Developer (med MCP Server), Second-Grade Simplifier og Dream Interpreter, hver med korte beskrivelser af deres funktioner.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.da.png)

1. Åbn **AI Toolkit**-udvidelsen fra **Activity Bar**.
1. I **Tools**-sektionen vælg **Agent (Prompt) Builder**. Når du vælger **Agent (Prompt) Builder**, åbnes den i en ny editor-fane.
1. Klik på **+ New Agent**-knappen. Udvidelsen åbner en opsætningsguide via **Command Palette**.
1. Indtast navnet **Calculator Agent** og tryk på **Enter**.
1. I **Agent (Prompt) Builder**, under **Model**, vælg modellen **OpenAI GPT-4o (via GitHub)**.

### -2- Opret en systemprompt til agenten

Når agenten er sat op, er det tid til at definere dens personlighed og formål. I denne sektion bruger du funktionen **Generate system prompt** til at beskrive, hvordan agenten skal opføre sig — i dette tilfælde en calculator-agent — og lade modellen skrive systemprompten for dig.

![Screenshot af "Calculator Agent"-interface i AI Toolkit til Visual Studio Code med et modalt vindue åbent med titlen "Generate a prompt." Det forklares, at en prompt-skabelon kan genereres ved at dele grundlæggende oplysninger, og der er en tekstboks med eksempel på systemprompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Under tekstboksen er knapperne "Close" og "Generate". I baggrunden kan man se agentkonfigurationen, inkl. den valgte model "OpenAI GPT-4o (via GitHub)" og felter til system- og brugerprompter.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.da.png)

1. I sektionen **Prompts** klik på knappen **Generate system prompt**. Denne knap åbner promptbyggeren, som bruger AI til at generere en systemprompt til agenten.
1. I vinduet **Generate a prompt**, indtast følgende: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klik på **Generate**-knappen. En besked vises nederst til højre, der bekræfter, at systemprompten genereres. Når genereringen er færdig, vises prompten i feltet **System prompt** i **Agent (Prompt) Builder**.
1. Gennemgå **System prompt** og tilpas den, hvis nødvendigt.

### -3- Opret en MCP-server

Nu hvor du har defineret agentens systemprompt — som styrer dens adfærd og svar — er det tid til at give agenten praktiske evner. I denne sektion opretter du en calculator MCP-server med værktøjer til addition, subtraktion, multiplikation og division. Denne server gør det muligt for din agent at udføre matematiske beregninger i realtid som svar på naturlige sprogspørgsmål.

![Screenshot af den nederste del af Calculator Agent-interface i AI Toolkit-udvidelsen til Visual Studio Code. Den viser udvidelige menuer for “Tools” og “Structure output,” samt en dropdown-menu med label “Choose output format” sat til “text.” Til højre er der en knap mærket “+ MCP Server” til at tilføje en Model Context Protocol-server. Over Tools-sektionen vises et billedeikon som pladsholder.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.da.png)

AI Toolkit har skabeloner, der gør det nemt at oprette din egen MCP-server. Vi bruger Python-skabelonen til at oprette calculator MCP-serveren.

*Note*: AI Toolkit understøtter i øjeblikket Python og TypeScript.

1. I **Tools**-sektionen i **Agent (Prompt) Builder** klik på knappen **+ MCP Server**. Udvidelsen åbner en opsætningsguide via **Command Palette**.
1. Vælg **+ Add Server**.
1. Vælg **Create a New MCP Server**.
1. Vælg **python-weather** som skabelon.
1. Vælg **Default folder** til at gemme MCP-server-skabelonen.
1. Indtast navnet på serveren: **Calculator**
1. Et nyt Visual Studio Code-vindue åbnes. Vælg **Yes, I trust the authors**.
1. Brug terminalen (**Terminal** > **New Terminal**) til at oprette et virtuelt miljø: `python -m venv .venv`
1. Aktivér det virtuelle miljø i terminalen:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Installer afhængighederne i terminalen: `pip install -e .[dev]`
1. I **Explorer**-visningen i **Activity Bar**, udvid **src**-mappen og åbn **server.py** i editoren.
1. Erstat koden i **server.py** med følgende og gem:

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

### -4- Kør agenten med calculator MCP-serveren

Nu hvor din agent har værktøjer, er det tid til at bruge dem! I denne sektion sender du prompts til agenten for at teste og bekræfte, at agenten bruger det rette værktøj fra calculator MCP-serveren.

![Screenshot af Calculator Agent-interface i AI Toolkit-udvidelsen til Visual Studio Code. Til venstre under “Tools” er en MCP-server med navnet local-server-calculator_server tilføjet, der viser fire tilgængelige værktøjer: add, subtract, multiply og divide. Et badge viser, at fire værktøjer er aktive. Under er en sammenklappet sektion “Structure output” og en blå “Run” knap. Til højre under “Model Response” kalder agenten multiply og subtract værktøjerne med inputtene {"a": 3, "b": 25} og {"a": 75, "b": 20}. Det endelige “Tool Response” vises som 75.0. Nederst ses en “View Code” knap.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.da.png)

Du vil køre calculator MCP-serveren på din lokale udviklingsmaskine via **Agent Builder** som MCP-klient.

1. Tryk på `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Jeg købte 3 varer til $25 stykket og brugte derefter en rabat på $20. Hvor meget betalte jeg?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` værdier tildeles for **subtract**-værktøjet.
    - Svaret fra hvert værktøj vises i den respektive **Tool Response**.
    - Det endelige output fra modellen vises i den afsluttende **Model Response**.
1. Send flere prompts for at teste agenten yderligere. Du kan ændre den eksisterende prompt i feltet **User prompt** ved at klikke i feltet og erstatte den nuværende prompt.
1. Når du er færdig med at teste agenten, kan du stoppe serveren via **terminalen** ved at trykke **CTRL/CMD+C**.

## Opgave

Prøv at tilføje et ekstra værktøj til din **server.py**-fil (f.eks. returner kvadratroden af et tal). Send yderligere prompts, der kræver, at agenten bruger dit nye værktøj (eller eksisterende værktøjer). Husk at genstarte serveren for at indlæse de nye værktøjer.

## Løsning

[Løsning](./solution/README.md)

## Vigtige pointer

De vigtigste pointer fra dette kapitel er:

- AI Toolkit-udvidelsen er en fremragende klient, der lader dig forbruge MCP-servere og deres værktøjer.
- Du kan tilføje nye værktøjer til MCP-servere og dermed udvide agentens evner til at opfylde nye krav.
- AI Toolkit inkluderer skabeloner (f.eks. Python MCP-server skabeloner) for at gøre det nemmere at oprette brugerdefinerede værktøjer.

## Yderligere ressourcer

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Hvad er næste skridt
- Næste: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.