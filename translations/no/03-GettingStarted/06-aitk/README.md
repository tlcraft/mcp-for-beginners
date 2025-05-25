<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:24:07+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "no"
}
-->
# Konsumere en server fra AI Toolkit-utvidelsen for Visual Studio Code

Når du bygger en AI-agent, handler det ikke bare om å generere smarte svar; det handler også om å gi agenten muligheten til å ta handling. Det er her Model Context Protocol (MCP) kommer inn. MCP gjør det enkelt for agenter å få tilgang til eksterne verktøy og tjenester på en konsistent måte. Tenk på det som å koble agenten din til en verktøykasse den faktisk kan bruke.

La oss si at du kobler en agent til MCP-serveren for kalkulatoren din. Plutselig kan agenten utføre matematiske operasjoner bare ved å motta en forespørsel som "Hva er 47 ganger 89?"—ingen behov for å hardkode logikk eller bygge tilpassede API-er.

## Oversikt

Denne leksjonen dekker hvordan man kobler en MCP-server for kalkulator til en agent med [AI Toolkit](https://aka.ms/AIToolkit)-utvidelsen i Visual Studio Code, slik at agenten din kan utføre matematiske operasjoner som addisjon, subtraksjon, multiplikasjon og divisjon gjennom naturlig språk.

AI Toolkit er en kraftig utvidelse for Visual Studio Code som forenkler utviklingen av agenter. AI-ingeniører kan enkelt bygge AI-applikasjoner ved å utvikle og teste generative AI-modeller—lokalt eller i skyen. Utvidelsen støtter de fleste større generative modeller som er tilgjengelige i dag.

*Merk*: AI Toolkit støtter for øyeblikket Python og TypeScript.

## Læringsmål

Ved slutten av denne leksjonen vil du kunne:

- Konsumere en MCP-server via AI Toolkit.
- Konfigurere en agentkonfigurasjon for å gjøre det mulig for den å oppdage og bruke verktøy levert av MCP-serveren.
- Bruke MCP-verktøy via naturlig språk.

## Tilnærming

Her er hvordan vi må nærme oss dette på et høyt nivå:

- Lag en agent og definer systemprompten dens.
- Lag en MCP-server med kalkulatorverktøy.
- Koble Agent Builder til MCP-serveren.
- Test agentens verktøykalling via naturlig språk.

Flott, nå som vi forstår flyten, la oss konfigurere en AI-agent for å utnytte eksterne verktøy gjennom MCP, og forbedre dens evner!

## Forutsetninger

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## Øvelse: Konsumere en server

I denne øvelsen vil du bygge, kjøre og forbedre en AI-agent med verktøy fra en MCP-server inne i Visual Studio Code ved hjelp av AI Toolkit.

### -0- Forberedelse, legg til OpenAI GPT-4o-modellen til Mine Modeller

Øvelsen bruker **GPT-4o**-modellen. Modellen bør legges til **Mine Modeller** før agenten opprettes.

1. Åpne **AI Toolkit**-utvidelsen fra **Aktivitetslinjen**.
1. I **Katalog**-seksjonen, velg **Modeller** for å åpne **Model Catalog**. Når du velger **Modeller**, åpnes **Model Catalog** i en ny redigeringsfane.
1. I søkefeltet i **Model Catalog**, skriv inn **OpenAI GPT-4o**.
1. Klikk **+ Legg til** for å legge modellen til listen **Mine Modeller**. Sørg for at du har valgt modellen som er **Hosted by GitHub**.
1. I **Aktivitetslinjen**, bekreft at **OpenAI GPT-4o**-modellen vises i listen.

### -1- Lag en agent

**Agent (Prompt) Builder** lar deg lage og tilpasse dine egne AI-drevne agenter. I denne delen vil du lage en ny agent og tilordne en modell for å drive samtalen.

1. Åpne **AI Toolkit**-utvidelsen fra **Aktivitetslinjen**.
1. I **Verktøy**-seksjonen, velg **Agent (Prompt) Builder**. Når du velger **Agent (Prompt) Builder**, åpnes **Agent (Prompt) Builder** i en ny redigeringsfane.
1. Klikk på **+ Ny Builder**-knappen. Utvidelsen vil starte en oppsettsveiviser via **Command Palette**.
1. Skriv inn navnet **Kalkulator Agent** og trykk **Enter**.
1. I **Agent (Prompt) Builder**, for **Modell**-feltet, velg **OpenAI GPT-4o (via GitHub)**-modellen.

### -2- Lag en systemprompt for agenten

Med agenten opprettet, er det på tide å definere dens personlighet og formål. I denne delen vil du bruke **Generer systemprompt**-funksjonen for å beskrive agentens tiltenkte oppførsel—i dette tilfellet en kalkulatoragent—og la modellen skrive systemprompten for deg.

1. For **Prompts**-seksjonen, klikk på **Generer systemprompt**-knappen. Denne knappen åpner promptbyggeren som bruker AI til å generere en systemprompt for agenten.
1. I **Generer en prompt**-vinduet, skriv inn følgende: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klikk på **Generer**-knappen. En varsling vil vises i nederste høyre hjørne som bekrefter at systemprompten genereres. Når promptgenereringen er fullført, vil prompten vises i **Systemprompt**-feltet i **Agent (Prompt) Builder**.
1. Gjennomgå **Systemprompt** og modifiser om nødvendig.

### -3- Lag en MCP-server

Nå som du har definert agentens systemprompt—som styrer dens oppførsel og svar—er det på tide å utstyre agenten med praktiske evner. I denne delen vil du lage en MCP-server for kalkulator med verktøy for å utføre addisjon, subtraksjon, multiplikasjon og divisjon beregninger. Denne serveren vil gjøre det mulig for agenten din å utføre sanntids matematiske operasjoner som svar på naturlige språk forespørsler.

AI Toolkit er utstyrt med maler for å gjøre det enkelt å lage din egen MCP-server. Vi vil bruke Python-malen for å lage MCP-serveren for kalkulatoren.

*Merk*: AI Toolkit støtter for øyeblikket Python og TypeScript.

1. I **Verktøy**-seksjonen i **Agent (Prompt) Builder**, klikk på **+ MCP Server**-knappen. Utvidelsen vil starte en oppsettsveiviser via **Command Palette**.
1. Velg **+ Legg til Server**.
1. Velg **Opprett en Ny MCP Server**.
1. Velg **python-weather** som malen.
1. Velg **Standardmappe** for å lagre MCP-servermalen.
1. Skriv inn følgende navn for serveren: **Kalkulator**
1. Et nytt Visual Studio Code-vindu vil åpne seg. Velg **Ja, jeg stoler på forfatterne**.
1. Bruk terminalen (**Terminal** > **Ny Terminal**), opprett et virtuelt miljø: `python -m venv .venv`
1. Bruk terminalen, aktiver det virtuelle miljøet:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Bruk terminalen, installer avhengighetene: `pip install -e .[dev]`
1. I **Explorer**-visningen av **Aktivitetslinjen**, utvid **src**-katalogen og velg **server.py** for å åpne filen i redigereren.
1. Erstatt koden i **server.py**-filen med følgende og lagre:

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

### -4- Kjøre agenten med MCP-serveren for kalkulator

Nå som agenten din har verktøy, er det på tide å bruke dem! I denne delen vil du sende forespørsler til agenten for å teste og validere om agenten bruker det riktige verktøyet fra MCP-serveren for kalkulator.

Du vil kjøre MCP-serveren for kalkulatoren på din lokale utviklingsmaskin via **Agent Builder** som MCP-klienten.

1. Trykk `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Jeg kjøpte 3 varer priset til $25 hver, og brukte deretter en rabatt på $20. Hvor mye betalte jeg?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b`-verdier er tilordnet for **subtract**-verktøyet.
    - Responsen fra hvert verktøy gis i den respektive **Verktøyresponsen**.
    - Den endelige utgangen fra modellen gis i den endelige **Modellresponsen**.
1. Send inn flere forespørsler for å teste agenten ytterligere. Du kan endre den eksisterende forespørselen i **Brukerprompt**-feltet ved å klikke inn i feltet og erstatte den eksisterende forespørselen.
1. Når du er ferdig med å teste agenten, kan du stoppe serveren via **terminalen** ved å skrive inn **CTRL/CMD+C** for å avslutte.

## Oppgave

Prøv å legge til en ekstra verktøypost i **server.py**-filen din (f.eks.: returnere kvadratroten av et tall). Send inn flere forespørsler som vil kreve at agenten utnytter ditt nye verktøy (eller eksisterende verktøy). Sørg for å starte serveren på nytt for å laste inn nyopprettede verktøy.

## Løsning

[Løsning](./solution/README.md)

## Viktige punkter

De viktigste punktene fra dette kapittelet er følgende:

- AI Toolkit-utvidelsen er en flott klient som lar deg konsumere MCP-servere og deres verktøy.
- Du kan legge til nye verktøy til MCP-servere, og utvide agentens evner for å møte utviklende krav.
- AI Toolkit inkluderer maler (f.eks. Python MCP-servermaler) for å forenkle opprettelsen av tilpassede verktøy.

## Tilleggsressurser

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Hva er neste

Neste: [Leksjon 4 Praktisk Implementering](/04-PracticalImplementation/README.md)

Sure, here's the translation to Norwegian:

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi etterstreber nøyaktighet, vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.