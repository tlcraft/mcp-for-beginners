<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:41:00+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "da"
}
-->
# Forbrug af en server fra AI Toolkit-udvidelsen til Visual Studio Code

Når du bygger en AI-agent, handler det ikke kun om at generere smarte svar; det handler også om at give din agent mulighed for at handle. Her kommer Model Context Protocol (MCP) ind i billedet. MCP gør det nemt for agenter at få adgang til eksterne værktøjer og tjenester på en ensartet måde. Tænk på det som at forbinde din agent til en værktøjskasse, den *faktisk* kan bruge.

Lad os sige, at du forbinder en agent til din calculator MCP-server. Pludselig kan din agent udføre matematiske operationer blot ved at modtage en prompt som "Hvad er 47 gange 89?" — uden behov for at hardkode logik eller bygge specialiserede API’er.

## Oversigt

Denne lektion viser, hvordan du forbinder en calculator MCP-server til en agent med [AI Toolkit](https://aka.ms/AIToolkit)-udvidelsen i Visual Studio Code, så din agent kan udføre matematiske operationer som addition, subtraktion, multiplikation og division via naturligt sprog.

AI Toolkit er en kraftfuld udvidelse til Visual Studio Code, der forenkler agentudvikling. AI Engineers kan nemt bygge AI-applikationer ved at udvikle og teste generative AI-modeller — lokalt eller i skyen. Udvidelsen understøtter de fleste større generative modeller, der findes i dag.

*Note*: AI Toolkit understøtter i øjeblikket Python og TypeScript.

## Læringsmål

Når du er færdig med denne lektion, vil du kunne:

- Forbruge en MCP-server via AI Toolkit.
- Konfigurere en agent, så den kan finde og bruge værktøjer leveret af MCP-serveren.
- Bruge MCP-værktøjer via naturligt sprog.

## Fremgangsmåde

Her er, hvordan vi skal gribe det an på et overordnet plan:

- Opret en agent og definer dens systemprompt.
- Opret en MCP-server med calculator-værktøjer.
- Forbind Agent Builder til MCP-serveren.
- Test agentens brug af værktøjerne via naturligt sprog.

Godt, nu hvor vi forstår flowet, lad os konfigurere en AI-agent til at udnytte eksterne værktøjer gennem MCP og dermed forbedre dens evner!

## Forudsætninger

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit til Visual Studio Code](https://aka.ms/AIToolkit)

## Øvelse: Forbrug en server

I denne øvelse skal du bygge, køre og forbedre en AI-agent med værktøjer fra en MCP-server inde i Visual Studio Code ved hjælp af AI Toolkit.

### -0- Forberedelse, tilføj OpenAI GPT-4o-modellen til My Models

Øvelsen bruger **GPT-4o**-modellen. Modellen skal tilføjes til **My Models**, før du opretter agenten.

![Screenshot af modelvalg i AI Toolkit-udvidelsen til Visual Studio Code med overskriften "Find the right model for your AI Solution" og en undertekst, der opfordrer brugere til at opdage, teste og implementere AI-modeller. Under “Popular Models” vises seks modelkort: DeepSeek-R1 (hostet på GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) og DeepSeek-R1 (hostet på Ollama). Hvert kort har knapper til at “Add” modellen eller “Try in Playground”.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.da.png)

1. Åbn **AI Toolkit**-udvidelsen fra **Activity Bar**.
1. Vælg **Models** under **Catalog** for at åbne **Model Catalog**. Valget åbner **Model Catalog** i en ny editor-fane.
1. Søg efter **OpenAI GPT-4o** i søgefeltet i **Model Catalog**.
1. Klik på **+ Add** for at tilføje modellen til din **My Models**-liste. Sørg for, at modellen er **Hosted by GitHub**.
1. Bekræft i **Activity Bar**, at **OpenAI GPT-4o** vises på listen.

### -1- Opret en agent

**Agent (Prompt) Builder** gør det muligt at oprette og tilpasse dine egne AI-drevne agenter. I denne sektion opretter du en ny agent og vælger en model, der skal drive samtalen.

![Screenshot af "Calculator Agent" builder-interface i AI Toolkit-udvidelsen til Visual Studio Code. Til venstre er modellen valgt som "OpenAI GPT-4o (via GitHub)." En systemprompt lyder "You are a professor in university teaching math," og brugerprompten siger "Explain to me the Fourier equation in simple terms." Yderligere muligheder inkluderer knapper til at tilføje værktøjer, aktivere MCP Server og vælge struktureret output. Nederst ses en blå “Run”-knap. Til højre under "Get Started with Examples" listes tre eksempelagenter: Web Developer (med MCP Server, Second-Grade Simplifier og Dream Interpreter, hver med korte beskrivelser af deres funktioner).](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.da.png)

1. Åbn **AI Toolkit**-udvidelsen fra **Activity Bar**.
1. Vælg **Agent (Prompt) Builder** under **Tools**. Det åbner **Agent (Prompt) Builder** i en ny editor-fane.
1. Klik på **+ New Agent**. Udvidelsen starter en opsætningsguide via **Command Palette**.
1. Indtast navnet **Calculator Agent** og tryk **Enter**.
1. I **Agent (Prompt) Builder** vælg modellen **OpenAI GPT-4o (via GitHub)** i feltet **Model**.

### -2- Opret en systemprompt til agenten

Når agenten er oprettet, er det tid til at definere dens personlighed og formål. I denne sektion bruger du funktionen **Generate system prompt** til at beskrive agentens tiltænkte adfærd — i dette tilfælde en calculator-agent — og få modellen til at skrive systemprompten for dig.

![Screenshot af "Calculator Agent" interface i AI Toolkit til Visual Studio Code med en modal vindue åbent med titlen "Generate a prompt." Modalvinduet forklarer, at en prompt-skabelon kan genereres ved at dele grundlæggende oplysninger og indeholder en tekstboks med eksempel på systemprompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Under tekstboksen er der knapperne "Close" og "Generate." I baggrunden ses dele af agentkonfigurationen, inklusive den valgte model "OpenAI GPT-4o (via GitHub)" og felter for system- og brugerprompter.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.da.png)

1. Under **Prompts** klik på knappen **Generate system prompt**. Denne åbner promptbuilderen, som bruger AI til at generere en systemprompt til agenten.
1. Indtast følgende i vinduet **Generate a prompt**: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klik på **Generate**. En notifikation vises nederst til højre, der bekræfter, at systemprompten genereres. Når genereringen er færdig, vises prompten i feltet **System prompt** i **Agent (Prompt) Builder**.
1. Gennemgå systemprompten og rediger den om nødvendigt.

### -3- Opret en MCP-server

Nu hvor du har defineret agentens systemprompt — som styrer dens adfærd og svar — er det tid til at give agenten praktiske evner. I denne sektion opretter du en calculator MCP-server med værktøjer til addition, subtraktion, multiplikation og division. Denne server gør det muligt for agenten at udføre matematiske operationer i realtid som svar på naturlige sprog-prompt.

!["Screenshot af nederste del af Calculator Agent interfacet i AI Toolkit-udvidelsen til Visual Studio Code. Viser udvidelige menuer for “Tools” og “Structure output” samt en dropdown-menu med “Choose output format” sat til “text.” Til højre er en knap mærket “+ MCP Server” til at tilføje en Model Context Protocol-server. Ovenover Tools-sektionen ses en billedikon-plads.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.da.png)

AI Toolkit indeholder skabeloner, der gør det nemt at oprette din egen MCP-server. Vi bruger Python-skabelonen til at oprette calculator MCP-serveren.

*Note*: AI Toolkit understøtter i øjeblikket Python og TypeScript.

1. Klik på **+ MCP Server** i **Tools**-sektionen i **Agent (Prompt) Builder**. Udvidelsen starter en opsætningsguide via **Command Palette**.
1. Vælg **+ Add Server**.
1. Vælg **Create a New MCP Server**.
1. Vælg **python-weather** som skabelon.
1. Vælg **Default folder** til at gemme MCP-server-skabelonen.
1. Indtast navnet **Calculator** til serveren.
1. Et nyt Visual Studio Code-vindue åbnes. Vælg **Yes, I trust the authors**.
1. Opret et virtuelt miljø via terminalen (**Terminal** > **New Terminal**): `python -m venv .venv`
1. Aktivér det virtuelle miljø via terminalen:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Installer afhængighederne via terminalen: `pip install -e .[dev]`
1. Udvid **src**-mappen i **Explorer**-visningen i **Activity Bar** og åbn **server.py** i editoren.
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

![Screenshot af Calculator Agent interfacet i AI Toolkit-udvidelsen til Visual Studio Code. Til venstre under “Tools” er en MCP-server tilføjet med navnet local-server-calculator_server, der viser fire tilgængelige værktøjer: add, subtract, multiply og divide. Et badge viser, at fire værktøjer er aktive. Under er en sammenklappet “Structure output”-sektion og en blå “Run”-knap. Til højre under “Model Response” kalder agenten multiply- og subtract-værktøjerne med inputtene {"a": 3, "b": 25} og {"a": 75, "b": 20} henholdsvis. Det endelige “Tool Response” vises som 75.0. Nederst ses en “View Code”-knap.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.da.png)

Du kører calculator MCP-serveren på din lokale udviklingsmaskine via **Agent Builder** som MCP-klient.

1. Tryk på `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` værdier tildeles til **subtract**-værktøjet.
    - Svaret fra hvert værktøj vises i den respektive **Tool Response**.
    - Det endelige output fra modellen vises i den sidste **Model Response**.
1. Send flere prompts for at teste agenten yderligere. Du kan ændre den eksisterende prompt i feltet **User prompt** ved at klikke i feltet og erstatte prompten.
1. Når du er færdig med at teste agenten, kan du stoppe serveren via terminalen ved at trykke **CTRL/CMD+C** for at afslutte.

## Opgave

Prøv at tilføje et ekstra værktøj til din **server.py**-fil (fx returner kvadratroden af et tal). Send flere prompts, der kræver, at agenten bruger dit nye værktøj (eller eksisterende værktøjer). Husk at genstarte serveren for at indlæse de nye værktøjer.

## Løsning

[Løsning](./solution/README.md)

## Vigtige pointer

De vigtigste pointer fra dette kapitel er:

- AI Toolkit-udvidelsen er en fremragende klient, der gør det muligt at forbruge MCP-servere og deres værktøjer.
- Du kan tilføje nye værktøjer til MCP-servere og dermed udvide agentens evner til at opfylde skiftende behov.
- AI Toolkit inkluderer skabeloner (fx Python MCP-server skabeloner) for at gøre det nemmere at skabe brugerdefinerede værktøjer.

## Yderligere ressourcer

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Hvad er det næste

Næste: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.