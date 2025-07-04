<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T17:41:50+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "da"
}
-->
# Forbrug af en server fra AI Toolkit-udvidelsen til Visual Studio Code

Når du bygger en AI-agent, handler det ikke kun om at generere smarte svar; det handler også om at give din agent mulighed for at handle. Det er her, Model Context Protocol (MCP) kommer ind i billedet. MCP gør det nemt for agenter at få adgang til eksterne værktøjer og tjenester på en ensartet måde. Tænk på det som at tilslutte din agent til en værktøjskasse, den *virkelig* kan bruge.

Lad os sige, at du forbinder en agent til din calculator MCP-server. Pludselig kan din agent udføre matematiske operationer blot ved at modtage en prompt som "Hvad er 47 gange 89?" — uden at skulle hardkode logik eller bygge brugerdefinerede API’er.

## Oversigt

Denne lektion gennemgår, hvordan du forbinder en calculator MCP-server til en agent med [AI Toolkit](https://aka.ms/AIToolkit)-udvidelsen i Visual Studio Code, så din agent kan udføre matematiske operationer som addition, subtraktion, multiplikation og division via naturligt sprog.

AI Toolkit er en kraftfuld udvidelse til Visual Studio Code, der forenkler agentudvikling. AI Engineers kan nemt bygge AI-applikationer ved at udvikle og teste generative AI-modeller — lokalt eller i skyen. Udvidelsen understøtter de fleste større generative modeller, der findes i dag.

*Note*: AI Toolkit understøtter i øjeblikket Python og TypeScript.

## Læringsmål

Når du er færdig med denne lektion, vil du kunne:

- Forbruge en MCP-server via AI Toolkit.
- Konfigurere en agentkonfiguration, så den kan opdage og bruge værktøjer leveret af MCP-serveren.
- Bruge MCP-værktøjer via naturligt sprog.

## Fremgangsmåde

Her er, hvordan vi skal gribe det an på et overordnet plan:

- Opret en agent og definer dens systemprompt.
- Opret en MCP-server med calculator-værktøjer.
- Forbind Agent Builder til MCP-serveren.
- Test agentens værktøjsanvendelse via naturligt sprog.

Fint, nu hvor vi forstår flowet, lad os konfigurere en AI-agent til at udnytte eksterne værktøjer gennem MCP og dermed forbedre dens evner!

## Forudsætninger

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit til Visual Studio Code](https://aka.ms/AIToolkit)

## Øvelse: Forbrug af en server

I denne øvelse vil du bygge, køre og forbedre en AI-agent med værktøjer fra en MCP-server inde i Visual Studio Code ved hjælp af AI Toolkit.

### -0- Forberedelse: Tilføj OpenAI GPT-4o-modellen til My Models

Øvelsen bruger **GPT-4o**-modellen. Modellen skal tilføjes til **My Models**, før du opretter agenten.

![Screenshot af en modelvalggrænseflade i Visual Studio Codes AI Toolkit-udvidelse. Overskriften lyder "Find den rigtige model til din AI-løsning" med en undertitel, der opfordrer brugere til at opdage, teste og implementere AI-modeller. Under “Popular Models” vises seks modelkort: DeepSeek-R1 (hostet på GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Lille, Hurtig) og DeepSeek-R1 (hostet på Ollama). Hvert kort har muligheder for at “Add” modellen eller “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.da.png)

1. Åbn **AI Toolkit**-udvidelsen fra **Activity Bar**.
1. I **Catalog**-sektionen vælg **Models** for at åbne **Model Catalog**. Ved at vælge **Models** åbnes **Model Catalog** i en ny editor-fane.
1. Søg efter **OpenAI GPT-4o** i søgefeltet i **Model Catalog**.
1. Klik på **+ Add** for at tilføje modellen til din liste over **My Models**. Sørg for, at du har valgt modellen, der er **Hosted by GitHub**.
1. Bekræft i **Activity Bar**, at **OpenAI GPT-4o**-modellen vises på listen.

### -1- Opret en agent

**Agent (Prompt) Builder** giver dig mulighed for at oprette og tilpasse dine egne AI-drevne agenter. I denne sektion opretter du en ny agent og tildeler en model, der skal drive samtalen.

![Screenshot af "Calculator Agent"-byggergrænsefladen i AI Toolkit-udvidelsen til Visual Studio Code. I venstre panel er den valgte model "OpenAI GPT-4o (via GitHub)." En systemprompt lyder "You are a professor in university teaching math," og brugerprompten siger "Explain to me the Fourier equation in simple terms." Yderligere muligheder inkluderer knapper til at tilføje værktøjer, aktivere MCP Server og vælge struktureret output. En blå “Run”-knap er nederst. I højre panel under "Get Started with Examples" listes tre eksempler på agenter: Web Developer (med MCP Server, Second-Grade Simplifier og Dream Interpreter, hver med korte beskrivelser af deres funktioner).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.da.png)

1. Åbn **AI Toolkit**-udvidelsen fra **Activity Bar**.
1. I **Tools**-sektionen vælg **Agent (Prompt) Builder**. Ved at vælge **Agent (Prompt) Builder** åbnes den i en ny editor-fane.
1. Klik på **+ New Agent**-knappen. Udvidelsen starter en opsætningsguide via **Command Palette**.
1. Indtast navnet **Calculator Agent** og tryk på **Enter**.
1. I **Agent (Prompt) Builder** vælg modellen **OpenAI GPT-4o (via GitHub)** i feltet **Model**.

### -2- Opret en systemprompt til agenten

Nu hvor agenten er oprettet, er det tid til at definere dens personlighed og formål. I denne sektion bruger du funktionen **Generate system prompt** til at beskrive agentens tiltænkte adfærd — i dette tilfælde en calculator-agent — og lade modellen skrive systemprompten for dig.

![Screenshot af "Calculator Agent"-grænsefladen i AI Toolkit til Visual Studio Code med et modalvindue åbent med titlen "Generate a prompt." Modalvinduet forklarer, at en prompt-skabelon kan genereres ved at dele grundlæggende oplysninger og indeholder en tekstboks med eksempel på systemprompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Under tekstboksen er knapperne "Close" og "Generate." I baggrunden ses dele af agentkonfigurationen, inklusive den valgte model "OpenAI GPT-4o (via GitHub)" og felter til system- og brugerprompter.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.da.png)

1. I sektionen **Prompts** klik på knappen **Generate system prompt**. Denne knap åbner promptbyggeren, som bruger AI til at generere en systemprompt til agenten.
1. I vinduet **Generate a prompt** indtast følgende: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klik på **Generate**-knappen. En notifikation vises nederst til højre, der bekræfter, at systemprompten genereres. Når promptgenereringen er færdig, vises prompten i feltet **System prompt** i **Agent (Prompt) Builder**.
1. Gennemgå **System prompt** og rediger om nødvendigt.

### -3- Opret en MCP-server

Nu hvor du har defineret agentens systemprompt — som styrer dens adfærd og svar — er det tid til at udstyre agenten med praktiske evner. I denne sektion opretter du en calculator MCP-server med værktøjer til at udføre addition, subtraktion, multiplikation og division. Denne server gør det muligt for din agent at udføre matematiske operationer i realtid som svar på naturlige sprogprompter.

!["Screenshot af den nederste del af Calculator Agent-grænsefladen i AI Toolkit-udvidelsen til Visual Studio Code. Den viser udvidelige menuer for “Tools” og “Structure output” samt en dropdown-menu mærket “Choose output format” sat til “text.” Til højre er en knap mærket “+ MCP Server” til at tilføje en Model Context Protocol-server. Et billedeikon-pladsholder vises over Tools-sektionen.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.da.png)

AI Toolkit har skabeloner, der gør det nemt at oprette din egen MCP-server. Vi bruger Python-skabelonen til at oprette calculator MCP-serveren.

*Note*: AI Toolkit understøtter i øjeblikket Python og TypeScript.

1. I **Tools**-sektionen i **Agent (Prompt) Builder** klik på **+ MCP Server**-knappen. Udvidelsen starter en opsætningsguide via **Command Palette**.
1. Vælg **+ Add Server**.
1. Vælg **Create a New MCP Server**.
1. Vælg **python-weather** som skabelon.
1. Vælg **Default folder** til at gemme MCP-server-skabelonen.
1. Indtast følgende navn til serveren: **Calculator**
1. Et nyt Visual Studio Code-vindue åbnes. Vælg **Yes, I trust the authors**.
1. Brug terminalen (**Terminal** > **New Terminal**) til at oprette et virtuelt miljø: `python -m venv .venv`
1. Aktivér det virtuelle miljø i terminalen:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Installer afhængighederne i terminalen: `pip install -e .[dev]`
1. I **Explorer**-visningen i **Activity Bar** udvid **src**-mappen og vælg **server.py** for at åbne filen i editoren.
1. Erstat koden i **server.py**-filen med følgende og gem:

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

Nu hvor din agent har værktøjer, er det tid til at bruge dem! I denne sektion sender du prompts til agenten for at teste og bekræfte, om agenten bruger det rette værktøj fra calculator MCP-serveren.

![Screenshot af Calculator Agent-grænsefladen i AI Toolkit-udvidelsen til Visual Studio Code. I venstre panel under “Tools” er en MCP-server med navnet local-server-calculator_server tilføjet, som viser fire tilgængelige værktøjer: add, subtract, multiply og divide. Et badge viser, at fire værktøjer er aktive. Under er en sammenklappet sektion “Structure output” og en blå “Run”-knap. I højre panel under “Model Response” kalder agenten multiply- og subtract-værktøjerne med inputtene {"a": 3, "b": 25} og {"a": 75, "b": 20} henholdsvis. Det endelige “Tool Response” vises som 75.0. En “View Code”-knap vises nederst.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.da.png)

Du vil køre calculator MCP-serveren på din lokale udviklingsmaskine via **Agent Builder** som MCP-klient.

1. Tryk på `F5` for at starte fejlsøgning af MCP-serveren. **Agent (Prompt) Builder** åbnes i en ny editor-fane. Serverens status vises i terminalen.
1. I feltet **User prompt** i **Agent (Prompt) Builder** indtast følgende prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Klik på **Run**-knappen for at generere agentens svar.
1. Gennemgå agentens output. Modellen bør konkludere, at du betalte **$55**.
1. Her er en oversigt over, hvad der bør ske:
    - Agenten vælger værktøjerne **multiply** og **subtract** for at hjælpe med beregningen.
    - De respektive `a` og `b` værdier tildeles til **multiply**-værktøjet.
    - De respektive `a` og `b` værdier tildeles til **subtract**-værktøjet.
    - Svaret fra hvert værktøj vises i den respektive **Tool Response**.
    - Det endelige output fra modellen vises i den endelige **Model Response**.
1. Send flere prompts for at teste agenten yderligere. Du kan ændre den eksisterende prompt i **User prompt**-feltet ved at klikke i feltet og erstatte den eksisterende prompt.
1. Når du er færdig med at teste agenten, kan du stoppe serveren via **terminalen** ved at trykke **CTRL/CMD+C** for at afslutte.

## Opgave

Prøv at tilføje et ekstra værktøj til din **server.py**-fil (f.eks. returner kvadratroden af et tal). Send flere prompts, der kræver, at agenten bruger dit nye værktøj (eller eksisterende værktøjer). Husk at genstarte serveren for at indlæse de nyligt tilføjede værktøjer.

## Løsning

[Løsning](./solution/README.md)

## Vigtige pointer

De vigtigste pointer fra dette kapitel er:

- AI Toolkit-udvidelsen er en fremragende klient, der lader dig forbruge MCP-servere og deres værktøjer.
- Du kan tilføje nye værktøjer til MCP-servere og dermed udvide agentens evner til at imødekomme nye krav.
- AI Toolkit inkluderer skabeloner (f.eks. Python MCP-server-skabeloner) for at gøre det nemmere at oprette brugerdefinerede værktøjer.

## Yderligere ressourcer

- [AI Toolkit-dokumentation](https://aka.ms/AIToolkit/doc)

## Hvad er det næste?
- Næste: [Testing & Debugging](../08-testing/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.