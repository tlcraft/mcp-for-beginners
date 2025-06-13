<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:22:14+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "no"
}
-->
# Bruke en server fra AI Toolkit-utvidelsen for Visual Studio Code

Når du bygger en AI-agent, handler det ikke bare om å generere smarte svar; det handler også om å gi agenten muligheten til å utføre handlinger. Det er her Model Context Protocol (MCP) kommer inn. MCP gjør det enkelt for agenter å få tilgang til eksterne verktøy og tjenester på en konsistent måte. Tenk på det som å koble agenten din til en verktøykasse den *faktisk* kan bruke.

La oss si at du kobler en agent til kalkulator-MCP-serveren din. Plutselig kan agenten utføre matematiske operasjoner bare ved å motta en forespørsel som «Hva er 47 ganger 89?»—uten å måtte hardkode logikk eller bygge egne API-er.

## Oversikt

Denne leksjonen forklarer hvordan du kobler en kalkulator-MCP-server til en agent med [AI Toolkit](https://aka.ms/AIToolkit)-utvidelsen i Visual Studio Code, slik at agenten kan utføre matematiske operasjoner som addisjon, subtraksjon, multiplikasjon og divisjon ved hjelp av naturlig språk.

AI Toolkit er en kraftig utvidelse for Visual Studio Code som forenkler utviklingen av agenter. AI-ingeniører kan enkelt bygge AI-applikasjoner ved å utvikle og teste generative AI-modeller—lokalt eller i skyen. Utvidelsen støtter de fleste store generative modeller som er tilgjengelige i dag.

*Merk*: AI Toolkit støtter for øyeblikket Python og TypeScript.

## Læringsmål

Etter denne leksjonen skal du kunne:

- Bruke en MCP-server via AI Toolkit.
- Konfigurere en agent slik at den kan oppdage og bruke verktøy som tilbys av MCP-serveren.
- Bruke MCP-verktøy via naturlig språk.

## Fremgangsmåte

Slik bør vi gå frem på et overordnet nivå:

- Lag en agent og definer systemprompten dens.
- Lag en MCP-server med kalkulatorverktøy.
- Koble Agent Builder til MCP-serveren.
- Test agentens bruk av verktøy via naturlig språk.

Flott, nå som vi forstår flyten, la oss konfigurere en AI-agent som utnytter eksterne verktøy gjennom MCP og utvider dens funksjonalitet!

## Forutsetninger

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## Øvelse: Bruke en server

I denne øvelsen skal du bygge, kjøre og forbedre en AI-agent med verktøy fra en MCP-server i Visual Studio Code ved hjelp av AI Toolkit.

### -0- Forberedelse, legg til OpenAI GPT-4o-modellen i Mine modeller

Øvelsen bruker **GPT-4o**-modellen. Modellen må legges til i **Mine modeller** før du oppretter agenten.

![Skjermbilde av modellvalggrensesnitt i AI Toolkit-utvidelsen for Visual Studio Code. Overskriften lyder "Finn riktig modell for din AI-løsning" med en undertittel som oppfordrer brukere til å oppdage, teste og distribuere AI-modeller. Under “Populære modeller” vises seks modellkort: DeepSeek-R1 (hostet på GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - liten, rask) og DeepSeek-R1 (hostet på Ollama). Hvert kort har alternativer for å “Legge til” modellen eller “Prøve i Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.no.png)

1. Åpne **AI Toolkit**-utvidelsen fra **Aktivitetslinjen**.
1. I **Katalog**-seksjonen, velg **Modeller** for å åpne **Model Catalog**. Valg av **Modeller** åpner **Model Catalog** i en ny editorfane.
1. Skriv **OpenAI GPT-4o** i søkefeltet i **Model Catalog**.
1. Klikk **+ Legg til** for å legge modellen til i listen **Mine modeller**. Pass på at du har valgt modellen som er **hostet på GitHub**.
1. Bekreft i **Aktivitetslinjen** at **OpenAI GPT-4o** vises i listen.

### -1- Lag en agent

**Agent (Prompt) Builder** lar deg lage og tilpasse dine egne AI-drevne agenter. I denne delen oppretter du en ny agent og velger en modell som skal drive samtalen.

![Skjermbilde av "Calculator Agent"-byggergrensesnittet i AI Toolkit-utvidelsen for Visual Studio Code. På venstre panel er modellen "OpenAI GPT-4o (via GitHub)" valgt. En systemprompt lyder "Du er professor ved universitet og underviser i matematikk," og brukerprompten sier "Forklar Fourier-ligningen på en enkel måte." Ytterligere alternativer inkluderer knapper for å legge til verktøy, aktivere MCP-server og velge strukturert output. En blå “Kjør”-knapp er nederst. På høyre panel, under "Kom i gang med eksempler," listes tre prøveagenter: Web Developer (med MCP Server, Second-Grade Simplifier og Dream Interpreter, hver med korte beskrivelser av funksjonene deres).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.no.png)

1. Åpne **AI Toolkit**-utvidelsen fra **Aktivitetslinjen**.
1. I **Verktøy**-seksjonen, velg **Agent (Prompt) Builder**. Dette åpner **Agent (Prompt) Builder** i en ny editorfane.
1. Klikk på **+ Ny agent**-knappen. Utvidelsen starter en oppsettsveiviser via **Command Palette**.
1. Skriv inn navnet **Calculator Agent** og trykk **Enter**.
1. I **Agent (Prompt) Builder**, velg **OpenAI GPT-4o (via GitHub)** som modell i feltet **Model**.

### -2- Lag en systemprompt for agenten

Nå som agenten er opprettet, er det på tide å definere dens personlighet og formål. I denne delen bruker du funksjonen **Generate system prompt** for å beskrive agentens ønskede oppførsel—her en kalkulatoragent—og la modellen skrive systemprompten for deg.

![Skjermbilde av "Calculator Agent"-grensesnittet i AI Toolkit for Visual Studio Code med et modalvindu åpent med tittelen "Generate a prompt." Modalvinduet forklarer at en promptmal kan genereres ved å dele grunnleggende detaljer og inkluderer en tekstboks med eksempel på systemprompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Under tekstboksen er det "Lukk" og "Generer"-knapper. I bakgrunnen vises deler av agentkonfigurasjonen, inkludert valgt modell "OpenAI GPT-4o (via GitHub)" og felt for system- og brukerprompter.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.no.png)

1. I **Prompts**-seksjonen klikker du på **Generate system prompt**-knappen. Denne åpner promptbyggeren som bruker AI til å generere en systemprompt for agenten.
1. I vinduet **Generate a prompt**, skriv inn følgende: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klikk på **Generate**-knappen. En varsling vises nederst til høyre som bekrefter at systemprompten genereres. Når genereringen er ferdig, vises prompten i feltet **System prompt** i **Agent (Prompt) Builder**.
1. Gå gjennom **System prompt** og endre om nødvendig.

### -3- Lag en MCP-server

Nå som du har definert agentens systemprompt—som styrer oppførselen og svarene—er det på tide å gi agenten praktiske evner. I denne delen lager du en kalkulator-MCP-server med verktøy som utfører addisjon, subtraksjon, multiplikasjon og divisjon. Denne serveren gjør det mulig for agenten å utføre sanntids matematiske operasjoner som svar på naturlige språkforespørsler.

![Skjermbilde av den nederste delen av Calculator Agent-grensesnittet i AI Toolkit-utvidelsen for Visual Studio Code. Viser utvidbare menyer for “Tools” og “Structure output,” sammen med en rullegardinmeny merket “Choose output format” satt til “text.” Til høyre er det en knapp merket “+ MCP Server” for å legge til en Model Context Protocol-server. En bildeikon-plassholder vises over Tools-seksjonen.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.no.png)

AI Toolkit har maler som gjør det enkelt å lage din egen MCP-server. Vi bruker Python-malen for å lage kalkulator-MCP-serveren.

*Merk*: AI Toolkit støtter for øyeblikket Python og TypeScript.

1. I **Tools**-seksjonen i **Agent (Prompt) Builder**, klikk på **+ MCP Server**-knappen. Utvidelsen starter en oppsettsveiviser via **Command Palette**.
1. Velg **+ Add Server**.
1. Velg **Create a New MCP Server**.
1. Velg malen **python-weather**.
1. Velg **Default folder** for å lagre MCP-servermalen.
1. Skriv inn følgende navn for serveren: **Calculator**
1. Et nytt Visual Studio Code-vindu åpnes. Velg **Yes, I trust the authors**.
1. Bruk terminalen (**Terminal** > **New Terminal**) til å opprette et virtuelt miljø: `python -m venv .venv`
1. Aktiver det virtuelle miljøet i terminalen:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Installer avhengighetene via terminalen: `pip install -e .[dev]`
1. I **Explorer**-visningen i **Aktivitetslinjen**, utvid **src**-mappen og åpne **server.py** i editoren.
1. Erstatt koden i **server.py** med følgende og lagre:

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

### -4- Kjør agenten med kalkulator-MCP-serveren

Nå som agenten har verktøy, er det på tide å bruke dem! I denne delen sender du forespørsler til agenten for å teste og bekrefte at agenten bruker riktig verktøy fra kalkulator-MCP-serveren.

![Skjermbilde av Calculator Agent-grensesnittet i AI Toolkit-utvidelsen for Visual Studio Code. På venstre panel, under “Tools,” er en MCP-server kalt local-server-calculator_server lagt til, med fire tilgjengelige verktøy: add, subtract, multiply og divide. En merkelapp viser at fire verktøy er aktive. Under er en kollapset “Structure output”-seksjon og en blå “Kjør”-knapp. På høyre panel, under “Model Response,” bruker agenten multiply og subtract-verktøyene med inputtene {"a": 3, "b": 25} og {"a": 75, "b": 20}. Det endelige “Tool Response” vises som 75.0. En “View Code”-knapp vises nederst.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.no.png)

Du skal kjøre kalkulator-MCP-serveren lokalt via **Agent Builder** som MCP-klient.

1. Trykk `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Jeg kjøpte 3 varer til 25 dollar hver, og brukte deretter en rabatt på 20 dollar. Hvor mye betalte jeg?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b`-verdier er tildelt for **subtract**-verktøyet.
    - Svaret fra hvert verktøy vises i respektive **Tool Response**.
    - Det endelige svaret fra modellen vises i **Model Response**.
1. Send flere forespørsler for å teste agenten videre. Du kan endre den eksisterende prompten i **User prompt**-feltet ved å klikke inn i feltet og erstatte teksten.
1. Når du er ferdig med å teste agenten, kan du stoppe serveren via terminalen ved å trykke **CTRL/CMD+C**.

## Oppgave

Prøv å legge til et nytt verktøy i **server.py**-filen (f.eks. returner kvadratroten av et tall). Send flere forespørsler som krever at agenten bruker det nye verktøyet (eller eksisterende verktøy). Husk å starte serveren på nytt for å laste inn nye verktøy.

## Løsning

[Løsning](./solution/README.md)

## Viktige punkter

Hovedpoengene fra dette kapitlet er:

- AI Toolkit-utvidelsen er en utmerket klient som lar deg bruke MCP-servere og deres verktøy.
- Du kan legge til nye verktøy i MCP-servere for å utvide agentens funksjonalitet etter behov.
- AI Toolkit inkluderer maler (f.eks. Python MCP-servermaler) som gjør det enklere å lage egne verktøy.

## Ekstra ressurser

- [AI Toolkit-dokumentasjon](https://aka.ms/AIToolkit/doc)

## Hva nå

- Neste: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på det opprinnelige språket bør anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.