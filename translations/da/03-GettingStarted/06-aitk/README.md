<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:23:42+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "da"
}
-->
# Forbrug af en server fra AI Toolkit-udvidelsen til Visual Studio Code

Når du bygger en AI-agent, handler det ikke kun om at generere smarte svar; det handler også om at give din agent evnen til at tage handling. Det er her Model Context Protocol (MCP) kommer ind i billedet. MCP gør det nemt for agenter at få adgang til eksterne værktøjer og tjenester på en ensartet måde. Tænk på det som at tilslutte din agent til en værktøjskasse, den rent faktisk kan bruge.

Lad os sige, at du forbinder en agent til din lommeregner MCP-server. Pludselig kan din agent udføre matematiske operationer blot ved at modtage en prompt som "Hvad er 47 gange 89?"—ingen grund til at hardkode logik eller bygge tilpassede API'er.

## Oversigt

Denne lektion dækker, hvordan man forbinder en lommeregner MCP-server til en agent med [AI Toolkit](https://aka.ms/AIToolkit) udvidelsen i Visual Studio Code, hvilket gør det muligt for din agent at udføre matematiske operationer som addition, subtraktion, multiplikation og division gennem naturligt sprog.

AI Toolkit er en kraftfuld udvidelse til Visual Studio Code, der strømliner agentudvikling. AI-ingeniører kan nemt bygge AI-applikationer ved at udvikle og teste generative AI-modeller—lokalt eller i skyen. Udvidelsen understøtter de fleste større generative modeller, der er tilgængelige i dag.

*Bemærk*: AI Toolkit understøtter i øjeblikket Python og TypeScript.

## Læringsmål

Ved afslutningen af denne lektion vil du være i stand til:

- Forbruge en MCP-server via AI Toolkit.
- Konfigurere en agentkonfiguration for at gøre det muligt for den at opdage og udnytte værktøjer leveret af MCP-serveren.
- Udnytte MCP-værktøjer via naturligt sprog.

## Fremgangsmåde

Sådan skal vi nærme os dette på et højt niveau:

- Opret en agent og definér dens systemprompt.
- Opret en MCP-server med lommeregner-værktøjer.
- Forbind Agent Builder til MCP-serveren.
- Test agentens værktøjsindkaldelse via naturligt sprog.

Godt, nu hvor vi forstår flowet, lad os konfigurere en AI-agent til at udnytte eksterne værktøjer gennem MCP, og dermed forbedre dens kapaciteter!

## Forudsætninger

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## Øvelse: Forbrug af en server

I denne øvelse vil du bygge, køre og forbedre en AI-agent med værktøjer fra en MCP-server inden i Visual Studio Code ved hjælp af AI Toolkit.

### -0- Forberedelse, tilføj OpenAI GPT-4o modellen til Mine Modeller

Øvelsen udnytter **GPT-4o** modellen. Modellen skal tilføjes til **Mine Modeller** før du opretter agenten.

1. Åbn **AI Toolkit** udvidelsen fra **Aktivitetslinjen**.
1. I **Katalog** sektionen, vælg **Modeller** for at åbne **Modelkataloget**. Ved at vælge **Modeller** åbnes **Modelkataloget** i en ny editorfane.
1. I **Modelkatalogets** søgefelt, indtast **OpenAI GPT-4o**.
1. Klik på **+ Tilføj** for at tilføje modellen til din **Mine Modeller** liste. Sørg for, at du har valgt modellen, der er **Hosted by GitHub**.
1. I **Aktivitetslinjen**, bekræft at **OpenAI GPT-4o** modellen vises i listen.

### -1- Opret en agent

**Agent (Prompt) Builder** gør det muligt for dig at oprette og tilpasse dine egne AI-drevne agenter. I denne sektion vil du oprette en ny agent og tildele en model til at drive samtalen.

1. Åbn **AI Toolkit** udvidelsen fra **Aktivitetslinjen**.
1. I **Værktøjer** sektionen, vælg **Agent (Prompt) Builder**. Ved at vælge **Agent (Prompt) Builder** åbnes **Agent (Prompt) Builder** i en ny editorfane.
1. Klik på **+ Ny Builder** knappen. Udvidelsen vil starte en opsætningsguide via **Kommando Paletten**.
1. Indtast navnet **Calculator Agent** og tryk på **Enter**.
1. I **Agent (Prompt) Builder**, for **Model** feltet, vælg **OpenAI GPT-4o (via GitHub)** modellen.

### -2- Opret en systemprompt for agenten

Med agenten skitseret, er det tid til at definere dens personlighed og formål. I denne sektion vil du bruge **Generér systemprompt** funktionen til at beskrive agentens tilsigtede adfærd—i dette tilfælde en lommeregner-agent—og få modellen til at skrive systemprompten for dig.

1. For **Prompts** sektionen, klik på **Generér systemprompt** knappen. Denne knap åbner prompt builder, som udnytter AI til at generere en systemprompt for agenten.
1. I **Generér en prompt** vinduet, indtast følgende: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klik på **Generér** knappen. En notifikation vil dukke op i nederste højre hjørne, der bekræfter, at systemprompten bliver genereret. Når promptgenereringen er færdig, vil prompten dukke op i **Systemprompt** feltet i **Agent (Prompt) Builder**.
1. Gennemgå **Systemprompten** og modificér hvis nødvendigt.

### -3- Opret en MCP-server

Nu hvor du har defineret din agents systemprompt—der guider dens adfærd og svar—er det tid til at udstyre agenten med praktiske kapaciteter. I denne sektion vil du oprette en lommeregner MCP-server med værktøjer til at udføre addition, subtraktion, multiplikation og divisionsberegninger. Denne server vil gøre det muligt for din agent at udføre realtids matematiske operationer som svar på naturlige sprogprompts.

AI Toolkit er udstyret med skabeloner for nemt at oprette din egen MCP-server. Vi vil bruge Python-skabelonen til at oprette lommeregner MCP-serveren.

*Bemærk*: AI Toolkit understøtter i øjeblikket Python og TypeScript.

1. I **Værktøjer** sektionen af **Agent (Prompt) Builder**, klik på **+ MCP Server** knappen. Udvidelsen vil starte en opsætningsguide via **Kommando Paletten**.
1. Vælg **+ Tilføj Server**.
1. Vælg **Opret en Ny MCP Server**.
1. Vælg **python-weather** som skabelonen.
1. Vælg **Standard mappe** for at gemme MCP-server skabelonen.
1. Indtast følgende navn for serveren: **Calculator**
1. Et nyt Visual Studio Code vindue vil åbne. Vælg **Ja, jeg stoler på forfatterne**.
1. Brug terminalen (**Terminal** > **Ny Terminal**), opret et virtuelt miljø: `python -m venv .venv`
1. Brug terminalen, aktiver det virtuelle miljø:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Brug terminalen, installer afhængighederne: `pip install -e .[dev]`
1. I **Explorer** visningen af **Aktivitetslinjen**, udvid **src** mappen og vælg **server.py** for at åbne filen i editoren.
1. Erstat koden i **server.py** filen med følgende og gem:

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

### -4- Kør agenten med lommeregner MCP-serveren

Nu hvor din agent har værktøjer, er det tid til at bruge dem! I denne sektion vil du indsende prompts til agenten for at teste og validere, om agenten anvender det passende værktøj fra lommeregner MCP-serveren.

Du vil køre lommeregner MCP-serveren på din lokale udviklingsmaskine via **Agent Builder** som MCP-klienten.

1. Tryk `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Jeg købte 3 varer til $25 hver, og brugte derefter en $20 rabat. Hvor meget betalte jeg?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` værdier er tildelt for **subtract** værktøjet.
    - Svaret fra hvert værktøj er angivet i den respektive **Tool Response**.
    - Det endelige output fra modellen er angivet i den endelige **Model Response**.
1. Indsend yderligere prompts for at teste agenten yderligere. Du kan ændre den eksisterende prompt i **User prompt** feltet ved at klikke ind i feltet og erstatte den eksisterende prompt.
1. Når du er færdig med at teste agenten, kan du stoppe serveren via **terminalen** ved at indtaste **CTRL/CMD+C** for at afslutte.

## Opgave

Prøv at tilføje en ekstra værktøjsindgang til din **server.py** fil (f.eks. returnere kvadratroden af et tal). Indsend yderligere prompts, der ville kræve, at agenten anvender dit nye værktøj (eller eksisterende værktøjer). Sørg for at genstarte serveren for at indlæse nyligt tilføjede værktøjer.

## Løsning

[Løsning](./solution/README.md)

## Nøglepunkter

Nøglepunkterne fra dette kapitel er følgende:

- AI Toolkit-udvidelsen er en fantastisk klient, der lader dig forbruge MCP-servere og deres værktøjer.
- Du kan tilføje nye værktøjer til MCP-servere, udvide agentens kapaciteter for at imødekomme udviklende krav.
- AI Toolkit inkluderer skabeloner (f.eks. Python MCP-server skabeloner) for at forenkle oprettelsen af tilpassede værktøjer.

## Yderligere ressourcer

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Hvad er næste

Næste: [Lektionen 4 Praktisk Implementering](/04-PracticalImplementation/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiske oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi er ikke ansvarlige for misforståelser eller fejltolkninger, der måtte opstå ved brug af denne oversættelse.