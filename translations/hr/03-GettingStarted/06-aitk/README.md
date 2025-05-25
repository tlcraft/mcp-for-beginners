<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:31:05+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "hr"
}
-->
# Korištenje servera iz AI Toolkit ekstenzije za Visual Studio Code

Kada gradite AI agenta, nije dovoljno samo generirati pametne odgovore; važno je i omogućiti vašem agentu da poduzme akciju. Tu dolazi Model Context Protocol (MCP). MCP olakšava agentima pristup vanjskim alatima i uslugama na dosljedan način. Zamislite to kao povezivanje vašeg agenta s kutijom s alatima koju *zaista* može koristiti.

Recimo da povežete agenta sa svojim MCP serverom kalkulatora. Odjednom, vaš agent može izvoditi matematičke operacije samo primanjem upita poput "Koliko je 47 puta 89?"—nema potrebe za hardkodiranjem logike ili izradom prilagođenih API-ja.

## Pregled

Ova lekcija pokriva kako povezati MCP server kalkulatora s agentom koristeći [AI Toolkit](https://aka.ms/AIToolkit) ekstenziju u Visual Studio Code-u, omogućavajući vašem agentu da izvodi matematičke operacije poput zbrajanja, oduzimanja, množenja i dijeljenja putem prirodnog jezika.

AI Toolkit je moćna ekstenzija za Visual Studio Code koja pojednostavljuje razvoj agenata. AI inženjeri mogu lako izgraditi AI aplikacije razvijanjem i testiranjem generativnih AI modela—lokalno ili u oblaku. Ekstenzija podržava većinu glavnih generativnih modela dostupnih danas.

*Napomena*: AI Toolkit trenutno podržava Python i TypeScript.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:

- Koristiti MCP server putem AI Toolkita.
- Konfigurirati konfiguraciju agenta kako bi mu omogućili otkrivanje i korištenje alata koje pruža MCP server.
- Koristiti MCP alate putem prirodnog jezika.

## Pristup

Evo kako trebamo pristupiti ovom na visokoj razini:

- Izraditi agenta i definirati njegov sistemski prompt.
- Izraditi MCP server s alatima kalkulatora.
- Povezati Agent Builder s MCP serverom.
- Testirati pozivanje alata agenta putem prirodnog jezika.

Odlično, sada kada razumijemo tok, konfigurirajmo AI agenta da koristi vanjske alate putem MCP-a, poboljšavajući njegove sposobnosti!

## Preduvjeti

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit za Visual Studio Code](https://aka.ms/AIToolkit)

## Vježba: Korištenje servera

U ovoj vježbi izgradit ćete, pokrenuti i poboljšati AI agenta s alatima iz MCP servera unutar Visual Studio Code-a koristeći AI Toolkit.

### -0- Predkorak, dodajte OpenAI GPT-4o model u Moji modeli

Vježba koristi model **GPT-4o**. Model treba biti dodan u **Moji modeli** prije izrade agenta.

1. Otvorite **AI Toolkit** ekstenziju iz **Activity Bar**.
1. U odjeljku **Catalog**, odaberite **Models** za otvaranje **Model Catalog**. Odabir **Models** otvara **Model Catalog** u novoj kartici urednika.
1. U traci za pretraživanje **Model Catalog** unesite **OpenAI GPT-4o**.
1. Kliknite **+ Add** da dodate model na svoj popis **My Models**. Osigurajte da ste odabrali model koji je **Hosted by GitHub**.
1. U **Activity Bar**, potvrdite da se model **OpenAI GPT-4o** pojavljuje na popisu.

### -1- Izradite agenta

**Agent (Prompt) Builder** omogućuje vam izradu i prilagodbu vlastitih AI agenata. U ovom odjeljku, izradit ćete novog agenta i dodijeliti model za pokretanje razgovora.

1. Otvorite **AI Toolkit** ekstenziju iz **Activity Bar**.
1. U odjeljku **Tools**, odaberite **Agent (Prompt) Builder**. Odabir **Agent (Prompt) Builder** otvara **Agent (Prompt) Builder** u novoj kartici urednika.
1. Kliknite gumb **+ New Builder**. Ekstenzija će pokrenuti čarobnjaka za postavljanje putem **Command Palette**.
1. Unesite ime **Calculator Agent** i pritisnite **Enter**.
1. U **Agent (Prompt) Builder**, za polje **Model**, odaberite model **OpenAI GPT-4o (via GitHub)**.

### -2- Izradite sistemski prompt za agenta

S agentom koji je postavljen, vrijeme je da definirate njegovu osobnost i svrhu. U ovom odjeljku, koristit ćete značajku **Generate system prompt** za opisivanje namjeravanog ponašanja agenta—u ovom slučaju, agenta kalkulatora—i omogućiti modelu da napiše sistemski prompt za vas.

1. Za odjeljak **Prompts**, kliknite gumb **Generate system prompt**. Ovaj gumb otvara generator prompta koji koristi AI za generiranje sistemskog prompta za agenta.
1. U prozoru **Generate a prompt**, unesite sljedeće: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kliknite gumb **Generate**. Obavijest će se pojaviti u donjem desnom kutu potvrđujući da se sistemski prompt generira. Kada generiranje prompta završi, prompt će se pojaviti u polju **System prompt** u **Agent (Prompt) Builder**.
1. Pregledajte **System prompt** i po potrebi ga modificirajte.

### -3- Izradite MCP server

Sada kada ste definirali sistemski prompt svog agenta—usmjeravajući njegovo ponašanje i odgovore—vrijeme je da opremite agenta praktičnim sposobnostima. U ovom odjeljku, izradit ćete MCP server kalkulatora s alatima za izvođenje zbrajanja, oduzimanja, množenja i dijeljenja. Ovaj server će omogućiti vašem agentu da izvrši matematičke operacije u stvarnom vremenu kao odgovor na prirodne jezične upite.

AI Toolkit je opremljen predlošcima za jednostavno stvaranje vlastitog MCP servera. Koristit ćemo Python predložak za stvaranje MCP servera kalkulatora.

*Napomena*: AI Toolkit trenutno podržava Python i TypeScript.

1. U odjeljku **Tools** u **Agent (Prompt) Builder**, kliknite gumb **+ MCP Server**. Ekstenzija će pokrenuti čarobnjaka za postavljanje putem **Command Palette**.
1. Odaberite **+ Add Server**.
1. Odaberite **Create a New MCP Server**.
1. Odaberite **python-weather** kao predložak.
1. Odaberite **Default folder** za spremanje predloška MCP servera.
1. Unesite sljedeće ime za server: **Calculator**
1. Otvorit će se novi prozor Visual Studio Code-a. Odaberite **Yes, I trust the authors**.
1. Koristeći terminal (**Terminal** > **New Terminal**), izradite virtualno okruženje: `python -m venv .venv`
1. Koristeći terminal, aktivirajte virtualno okruženje:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Koristeći terminal, instalirajte ovisnosti: `pip install -e .[dev]`
1. U **Explorer** prikazu **Activity Bar**, proširite **src** direktorij i odaberite **server.py** za otvaranje datoteke u uredniku.
1. Zamijenite kod u datoteci **server.py** sa sljedećim i spremite:

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

### -4- Pokrenite agenta s MCP serverom kalkulatora

Sada kada vaš agent ima alate, vrijeme je da ih iskoristi! U ovom odjeljku, poslat ćete upite agentu kako biste testirali i provjerili koristi li agent odgovarajući alat s MCP servera kalkulatora.

Pokrenut ćete MCP server kalkulatora na svom lokalnom razvojnom stroju putem **Agent Builder** kao MCP klijenta.

1. Pritisnite `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Kupio sam 3 artikla po cijeni od $25 svaki, a zatim sam iskoristio popust od $20. Koliko sam platio?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` vrijednosti su dodijeljene za alat **subtract**.
    - Odgovor od svakog alata je prikazan u odgovarajućem **Tool Response**.
    - Konačni izlaz iz modela je prikazan u konačnom **Model Response**.
1. Podnesite dodatne upite za daljnje testiranje agenta. Možete izmijeniti postojeći upit u polju **User prompt** klikom u polje i zamjenom postojećeg upita.
1. Kada završite s testiranjem agenta, možete zaustaviti server putem **terminala** unosom **CTRL/CMD+C** za izlaz.

## Zadatak

Pokušajte dodati dodatni unos alata u svoju **server.py** datoteku (npr. vratite kvadratni korijen broja). Podnesite dodatne upite koji bi zahtijevali od agenta da iskoristi vaš novi alat (ili postojeće alate). Budite sigurni da ponovno pokrenete server kako biste učitali novo dodane alate.

## Rješenje

[Rješenje](./solution/README.md)

## Ključni zaključci

Zaključci iz ovog poglavlja su sljedeći:

- AI Toolkit ekstenzija je izvrstan klijent koji vam omogućuje korištenje MCP servera i njihovih alata.
- Možete dodati nove alate MCP serverima, proširujući sposobnosti agenta kako bi zadovoljili promjenjive zahtjeve.
- AI Toolkit uključuje predloške (npr. Python MCP server predloške) za pojednostavljenje stvaranja prilagođenih alata.

## Dodatni resursi

- [AI Toolkit dokumentacija](https://aka.ms/AIToolkit/doc)

## Što je sljedeće

Sljedeće: [Lekcija 4 Praktična implementacija](/04-PracticalImplementation/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za ključne informacije preporučuje se profesionalni ljudski prijevod. Ne odgovaramo za nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.