<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:41:38+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "no"
}
-->
# Bruke en server fra AI Toolkit-utvidelsen for Visual Studio Code

Når du bygger en AI-agent, handler det ikke bare om å generere smarte svar; det handler også om å gi agenten muligheten til å utføre handlinger. Det er her Model Context Protocol (MCP) kommer inn. MCP gjør det enkelt for agenter å få tilgang til eksterne verktøy og tjenester på en konsistent måte. Tenk på det som å koble agenten din til en verktøykasse den *faktisk* kan bruke.

La oss si at du kobler en agent til kalkulator-MCP-serveren din. Plutselig kan agenten utføre matteoperasjoner bare ved å motta en prompt som «Hva er 47 ganger 89?» — uten behov for å hardkode logikk eller bygge tilpassede API-er.

## Oversikt

Denne leksjonen viser hvordan du kobler en kalkulator-MCP-server til en agent med [AI Toolkit](https://aka.ms/AIToolkit)-utvidelsen i Visual Studio Code, slik at agenten kan utføre matteoperasjoner som addisjon, subtraksjon, multiplikasjon og divisjon via naturlig språk.

AI Toolkit er en kraftig utvidelse for Visual Studio Code som forenkler utvikling av agenter. AI-ingeniører kan enkelt bygge AI-applikasjoner ved å utvikle og teste generative AI-modeller — enten lokalt eller i skyen. Utvidelsen støtter de fleste store generative modeller som finnes i dag.

*Merk*: AI Toolkit støtter for øyeblikket Python og TypeScript.

## Læringsmål

Etter denne leksjonen skal du kunne:

- Bruke en MCP-server via AI Toolkit.
- Konfigurere en agent slik at den kan oppdage og bruke verktøy levert av MCP-serveren.
- Bruke MCP-verktøy gjennom naturlig språk.

## Tilnærming

Slik bør vi gå frem på et overordnet nivå:

- Lag en agent og definer systemprompten.
- Lag en MCP-server med kalkulatorverktøy.
- Koble Agent Builder til MCP-serveren.
- Test agentens verktøybruk via naturlig språk.

Flott, nå som vi forstår flyten, la oss konfigurere en AI-agent som kan bruke eksterne verktøy via MCP og dermed utvide dens funksjonalitet!

## Forutsetninger

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## Øvelse: Bruke en server

I denne øvelsen skal du bygge, kjøre og forbedre en AI-agent med verktøy fra en MCP-server inne i Visual Studio Code ved hjelp av AI Toolkit.

### -0- Forberedelse, legg til OpenAI GPT-4o-modellen i Mine modeller

Øvelsen bruker **GPT-4o**-modellen. Modellen må legges til i **Mine modeller** før du lager agenten.

![Skjermbilde av modellvalg i AI Toolkit-utvidelsen for Visual Studio Code. Overskriften lyder "Finn riktig modell for din AI-løsning" med undertittel som oppfordrer til å oppdage, teste og distribuere AI-modeller. Under “Populære modeller” vises seks modellkort: DeepSeek-R1 (GitHub-hostet), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - liten, rask) og DeepSeek-R1 (Ollama-hostet). Hvert kort har mulighet for “Legg til” eller “Prøv i lekeplass”.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.no.png)

1. Åpne **AI Toolkit**-utvidelsen fra **Aktivitetslinjen**.
2. I **Katalog**-seksjonen velger du **Modeller** for å åpne **Modellkatalogen**. Dette åpner Modellkatalogen i en ny editorfane.
3. Skriv **OpenAI GPT-4o** i søkefeltet i Modellkatalogen.
4. Klikk **+ Legg til** for å legge modellen til i listen **Mine modeller**. Pass på at du velger modellen som er **hostet av GitHub**.
5. I **Aktivitetslinjen** bekrefter du at **OpenAI GPT-4o** vises i listen.

### -1- Lag en agent

**Agent (Prompt) Builder** lar deg lage og tilpasse dine egne AI-drevne agenter. I denne delen lager du en ny agent og tildeler en modell som skal drive samtalen.

![Skjermbilde av "Calculator Agent"-byggergrensesnittet i AI Toolkit-utvidelsen for Visual Studio Code. På venstre panel er modellen valgt til "OpenAI GPT-4o (via GitHub)". En systemprompt lyder "Du er professor ved universitetet og underviser i matematikk," og brukerprompten sier, "Forklar Fourier-ligningen på en enkel måte." Tilleggsvalg inkluderer knapper for å legge til verktøy, aktivere MCP-server og velge strukturert output. En blå “Kjør”-knapp er nederst. På høyre panel under "Kom i gang med eksempler" listes tre prøveagenter: Web Developer (med MCP Server), Second-Grade Simplifier og Dream Interpreter, hver med korte beskrivelser av funksjonene.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.no.png)

1. Åpne **AI Toolkit**-utvidelsen fra **Aktivitetslinjen**.
2. I **Verktøy**-seksjonen velger du **Agent (Prompt) Builder**. Dette åpner Agent (Prompt) Builder i en ny editorfane.
3. Klikk på **+ Ny agent**-knappen. Utvidelsen starter en oppsettsveiviser via **Kommando-paletten**.
4. Skriv inn navnet **Calculator Agent** og trykk **Enter**.
5. I **Agent (Prompt) Builder**, velg **OpenAI GPT-4o (via GitHub)** som modell i **Modell**-feltet.

### -2- Lag en systemprompt for agenten

Når agenten er satt opp, er det tid for å definere dens personlighet og formål. I denne delen bruker du funksjonen **Generer systemprompt** for å beskrive agentens tiltenkte oppførsel — i dette tilfellet en kalkulatoragent — og la modellen skrive systemprompten for deg.

![Skjermbilde av "Calculator Agent"-grensesnittet i AI Toolkit for Visual Studio Code med et modalt vindu åpent med tittelen "Generer en prompt." Vinduet forklarer at en promptmal kan genereres ved å dele grunnleggende detaljer, og inkluderer en tekstboks med eksempel på systemprompt: "Du er en hjelpsom og effektiv matematikkassistent. Når du får et problem som involverer grunnleggende aritmetikk, svarer du med korrekt resultat." Under tekstboksen er det knapper for "Lukk" og "Generer". I bakgrunnen er deler av agentkonfigurasjonen synlig, inkludert valgt modell "OpenAI GPT-4o (via GitHub)" og felt for system- og brukerprompter.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.no.png)

1. I **Prompts**-seksjonen klikker du på **Generer systemprompt**-knappen. Denne åpner promptbyggeren som bruker AI til å lage en systemprompt for agenten.
2. I vinduet **Generer en prompt**, skriv inn: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Klikk **Generer**. En varsling vises nederst til høyre som bekrefter at systemprompten genereres. Når genereringen er ferdig, vil prompten vises i feltet **System prompt** i **Agent (Prompt) Builder**.
4. Gå gjennom systemprompten og endre den ved behov.

### -3- Lag en MCP-server

Nå som du har definert systemprompten som styrer agentens oppførsel og svar, er det tid for å gi agenten praktiske ferdigheter. I denne delen lager du en kalkulator-MCP-server med verktøy for addisjon, subtraksjon, multiplikasjon og divisjon. Denne serveren gjør at agenten kan utføre matteoperasjoner i sanntid som svar på naturlige språk-forespørsler.

![Skjermbilde av nedre del av Calculator Agent-grensesnittet i AI Toolkit-utvidelsen for Visual Studio Code. Viser utvidbare menyer for “Verktøy” og “Strukturert output,” samt en nedtrekksmeny merket “Velg output-format” satt til “tekst.” Til høyre er det en knapp merket “+ MCP Server” for å legge til en Model Context Protocol-server. Et bildeikon-plassholder vises over Verktøy-seksjonen.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.no.png)

AI Toolkit har maler som gjør det enkelt å lage din egen MCP-server. Vi bruker Python-malen for å lage kalkulator-MCP-serveren.

*Merk*: AI Toolkit støtter for øyeblikket Python og TypeScript.

1. I **Verktøy**-seksjonen i **Agent (Prompt) Builder**, klikk på **+ MCP Server**-knappen. Utvidelsen starter en oppsettsveiviser via **Kommando-paletten**.
2. Velg **+ Legg til server**.
3. Velg **Lag en ny MCP-server**.
4. Velg **python-weather** som mal.
5. Velg **Standardmappe** for å lagre MCP-servermalen.
6. Skriv inn navnet på serveren: **Calculator**
7. Et nytt Visual Studio Code-vindu åpnes. Velg **Ja, jeg stoler på forfatterne**.
8. I terminalen (**Terminal** > **Ny terminal**), opprett et virtuelt miljø: `python -m venv .venv`
9. Aktiver det virtuelle miljøet i terminalen:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. Installer avhengighetene i terminalen: `pip install -e .[dev]`
11. I **Utforsker**-visningen i **Aktivitetslinjen**, utvid **src**-mappen og åpne **server.py** i editoren.
12. Erstatt koden i **server.py** med følgende og lagre:

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

Nå som agenten har verktøy, er det tid for å bruke dem! I denne delen sender du inn forespørsler til agenten for å teste og bekrefte at den bruker riktig verktøy fra kalkulator-MCP-serveren.

![Skjermbilde av Calculator Agent-grensesnittet i AI Toolkit-utvidelsen for Visual Studio Code. På venstre panel under “Verktøy” er en MCP-server kalt local-server-calculator_server lagt til, med fire tilgjengelige verktøy: add, subtract, multiply og divide. En badge viser at fire verktøy er aktive. Under er en sammenfoldet “Strukturert output”-seksjon og en blå “Kjør”-knapp. På høyre panel under “Modellsvar” kaller agenten opp multiply- og subtract-verktøyene med input {"a": 3, "b": 25} og {"a": 75, "b": 20} henholdsvis. Det endelige “Tool Response” vises som 75.0. En “Se kode”-knapp vises nederst.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.no.png)

Du skal kjøre kalkulator-MCP-serveren på din lokale utviklermaskin via **Agent Builder** som MCP-klient.

1. Trykk `F5` for å starte agenten og serveren.
2. Skriv inn følgende prompt i **Brukerprompt**-feltet:  
   `Jeg kjøpte 3 varer til 25 dollar hver, og brukte deretter en rabatt på 20 dollar. Hvor mye betalte jeg?`
3. Verdiene `a` og `b` settes for **subtract**-verktøyet.
    - Svaret fra hvert verktøy vises i den respektive **Tool Response**.
    - Det endelige svaret fra modellen vises i **Model Response**.
4. Send inn flere forespørsler for å teste agenten videre. Du kan endre den eksisterende prompten ved å klikke i **Brukerprompt**-feltet og erstatte teksten.
5. Når du er ferdig med å teste agenten, kan du stoppe serveren i terminalen ved å trykke **CTRL/CMD+C**.

## Oppgave

Prøv å legge til et ekstra verktøy i **server.py**-filen (f.eks. returner kvadratroten av et tall). Send inn flere forespørsler som krever at agenten bruker ditt nye verktøy (eller eksisterende verktøy). Husk å starte serveren på nytt for å laste inn de nye verktøyene.

## Løsning

[Løsning](./solution/README.md)

## Viktige punkter

Hovedpoengene fra dette kapitlet er:

- AI Toolkit-utvidelsen er en flott klient som lar deg bruke MCP-servere og verktøyene deres.
- Du kan legge til nye verktøy i MCP-servere for å utvide agentens funksjonalitet etter behov.
- AI Toolkit inkluderer maler (f.eks. Python MCP-servermaler) som gjør det enklere å lage egne verktøy.

## Ekstra ressurser

- [AI Toolkit-dokumentasjon](https://aka.ms/AIToolkit/doc)

## Hva nå

Neste: [Leksjon 4 Praktisk implementering](/04-PracticalImplementation/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på dets opprinnelige språk bør anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår fra bruk av denne oversettelsen.