<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:52:52+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "hr"
}
-->
# Korištenje servera iz AI Toolkit ekstenzije za Visual Studio Code

Kada razvijate AI agenta, nije riječ samo o generiranju pametnih odgovora; važno je i omogućiti agentu da poduzme akciju. Tu dolazi Model Context Protocol (MCP). MCP olakšava agentima pristup vanjskim alatima i uslugama na dosljedan način. Zamislite to kao priključivanje vašeg agenta u alatni sanduk koji on *zaista* može koristiti.

Recimo da povežete agenta s vašim kalkulator MCP serverom. Odjednom, vaš agent može izvoditi matematičke operacije samo primanjem upita poput „Koliko je 47 puta 89?“ — bez potrebe za hardkodiranjem logike ili izradom prilagođenih API-ja.

## Pregled

Ova lekcija objašnjava kako povezati kalkulator MCP server s agentom koristeći [AI Toolkit](https://aka.ms/AIToolkit) ekstenziju u Visual Studio Code-u, što omogućava agentu izvođenje matematičkih operacija poput zbrajanja, oduzimanja, množenja i dijeljenja putem prirodnog jezika.

AI Toolkit je moćna ekstenzija za Visual Studio Code koja pojednostavljuje razvoj agenata. AI inženjeri mogu lako graditi AI aplikacije razvijanjem i testiranjem generativnih AI modela — lokalno ili u oblaku. Ekstenzija podržava većinu glavnih generativnih modela dostupnih danas.

*Napomena*: AI Toolkit trenutno podržava Python i TypeScript.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:

- Koristiti MCP server preko AI Toolkita.
- Konfigurirati agentovu postavku kako bi mogao otkriti i koristiti alate koje pruža MCP server.
- Koristiti MCP alate putem prirodnog jezika.

## Pristup

Evo kako trebamo pristupiti na visokoj razini:

- Kreirati agenta i definirati njegov sistemski prompt.
- Kreirati MCP server s kalkulator alatima.
- Povezati Agent Builder s MCP serverom.
- Testirati pozivanje alata agenta putem prirodnog jezika.

Odlično, sada kada razumijemo tijek, konfigurirajmo AI agenta da koristi vanjske alate kroz MCP i time proširimo njegove mogućnosti!

## Preduvjeti

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit za Visual Studio Code](https://aka.ms/AIToolkit)

## Vježba: Korištenje servera

U ovoj vježbi izgradit ćete, pokrenuti i unaprijediti AI agenta s alatima iz MCP servera unutar Visual Studio Code-a koristeći AI Toolkit.

### -0- Priprema, dodajte OpenAI GPT-4o model u My Models

Vježba koristi **GPT-4o** model. Model treba dodati u **My Models** prije nego što kreirate agenta.

![Screenshot sučelja za odabir modela u AI Toolkit ekstenziji za Visual Studio Code. Naslov glasi "Find the right model for your AI Solution" s podnaslovom koji potiče korisnike da otkriju, testiraju i implementiraju AI modele. Ispod, pod “Popular Models,” prikazano je šest model kartica: DeepSeek-R1 (hostan na GitHubu), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - mali, brz), i DeepSeek-R1 (hostan na Ollama). Svaka kartica uključuje opcije “Add” ili “Try in Playground”.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.hr.png)

1. Otvorite **AI Toolkit** ekstenziju iz **Activity Bar**.
1. U odjeljku **Catalog**, odaberite **Models** da otvorite **Model Catalog**. Odabirom **Models** otvara se **Model Catalog** u novom editor tabu.
1. U traku za pretraživanje u **Model Catalog** upišite **OpenAI GPT-4o**.
1. Kliknite **+ Add** da dodate model u svoj popis **My Models**. Provjerite da ste odabrali model koji je **Hosted by GitHub**.
1. U **Activity Bar** provjerite da se model **OpenAI GPT-4o** pojavljuje na popisu.

### -1- Kreirajte agenta

**Agent (Prompt) Builder** omogućava vam stvaranje i prilagodbu vlastitih AI agenata. U ovom dijelu kreirat ćete novog agenta i dodijeliti mu model koji će pokretati razgovor.

![Screenshot sučelja "Calculator Agent" u AI Toolkit ekstenziji za Visual Studio Code. Na lijevoj ploči, odabrani model je "OpenAI GPT-4o (via GitHub)." Sistemski prompt glasi "You are a professor in university teaching math," a korisnički prompt "Explain to me the Fourier equation in simple terms." Dodatne opcije uključuju gumbe za dodavanje alata, omogućavanje MCP Servera i odabir strukturiranog izlaza. Na dnu plavi gumb “Run.” Na desnoj ploči, pod "Get Started with Examples," navedena su tri uzorka agenata: Web Developer (s MCP Serverom, Second-Grade Simplifier i Dream Interpreter, svaki s kratkim opisom funkcija).](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.hr.png)

1. Otvorite **AI Toolkit** ekstenziju iz **Activity Bar**.
1. U odjeljku **Tools** odaberite **Agent (Prompt) Builder**. Odabirom se otvara **Agent (Prompt) Builder** u novom editor tabu.
1. Kliknite gumb **+ New Agent**. Ekstenzija će pokrenuti čarobnjak za postavljanje kroz **Command Palette**.
1. Unesite ime **Calculator Agent** i pritisnite **Enter**.
1. U **Agent (Prompt) Builder**, za polje **Model**, odaberite model **OpenAI GPT-4o (via GitHub)**.

### -2- Kreirajte sistemski prompt za agenta

Sada kada ste postavili agenta, vrijeme je da definirate njegov karakter i svrhu. U ovom dijelu koristit ćete opciju **Generate system prompt** da opišete željeno ponašanje agenta — u ovom slučaju kalkulator agenta — i da model za vas napiše sistemski prompt.

![Screenshot sučelja "Calculator Agent" u AI Toolkit za Visual Studio Code s otvorenim modalnim prozorom pod nazivom "Generate a prompt." Modal objašnjava da se predložak prompta može generirati dijeljenjem osnovnih detalja i uključuje tekstni okvir s primjerom sistemskog prompta: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Ispod su gumbi "Close" i "Generate." U pozadini je vidljiv dio konfiguracije agenta, uključujući odabrani model "OpenAI GPT-4o (via GitHub)" i polja za sistemski i korisnički prompt.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.hr.png)

1. U odjeljku **Prompts** kliknite gumb **Generate system prompt**. Ovaj gumb otvara prompt builder koji koristi AI za generiranje sistemskog prompta za agenta.
1. U prozoru **Generate a prompt** unesite sljedeće: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kliknite gumb **Generate**. U donjem desnom kutu pojavit će se obavijest da se generira sistemski prompt. Kad je generiranje završeno, prompt će se pojaviti u polju **System prompt** u **Agent (Prompt) Builderu**.
1. Pregledajte **System prompt** i po potrebi ga izmijenite.

### -3- Kreirajte MCP server

Sada kada ste definirali sistemski prompt svog agenta — koji usmjerava njegovo ponašanje i odgovore — vrijeme je da ga opremite praktičnim sposobnostima. U ovom dijelu kreirat ćete kalkulator MCP server s alatima za izvođenje zbrajanja, oduzimanja, množenja i dijeljenja. Ovaj server omogućit će vašem agentu izvođenje matematičkih operacija u stvarnom vremenu kao odgovor na upite prirodnim jezikom.

!["Screenshot donjeg dijela sučelja Calculator Agent u AI Toolkit ekstenziji za Visual Studio Code. Prikazuju se proširivi izbornici za “Tools” i “Structure output,” zajedno s padajućim izbornikom “Choose output format” postavljenim na “text.” S desne strane nalazi se gumb “+ MCP Server” za dodavanje Model Context Protocol servera. Iznad odjeljka Tools prikazana je ikona slike kao zamjena.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.hr.png)

AI Toolkit dolazi s predlošcima koji olakšavaju kreiranje vlastitih MCP servera. Koristit ćemo Python predložak za kreiranje kalkulator MCP servera.

*Napomena*: AI Toolkit trenutno podržava Python i TypeScript.

1. U odjeljku **Tools** u **Agent (Prompt) Builderu** kliknite gumb **+ MCP Server**. Ekstenzija će pokrenuti čarobnjak za postavljanje kroz **Command Palette**.
1. Odaberite **+ Add Server**.
1. Odaberite **Create a New MCP Server**.
1. Odaberite predložak **python-weather**.
1. Odaberite **Default folder** za spremanje predloška MCP servera.
1. Unesite sljedeće ime servera: **Calculator**
1. Otvorit će se novi Visual Studio Code prozor. Odaberite **Yes, I trust the authors**.
1. Koristeći terminal (**Terminal** > **New Terminal**), kreirajte virtualno okruženje: `python -m venv .venv`
1. Aktivirajte virtualno okruženje:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Instalirajte potrebne ovisnosti: `pip install -e .[dev]`
1. U **Explorer** prikazu na **Activity Bar**, proširite direktorij **src** i otvorite datoteku **server.py**.
1. Zamijenite kod u datoteci **server.py** sljedećim i spremite:

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

### -4- Pokrenite agenta s kalkulator MCP serverom

Sada kada vaš agent ima alate, vrijeme je da ih koristite! U ovom dijelu poslat ćete upite agentu kako biste testirali i provjerili koristi li agent odgovarajući alat iz kalkulator MCP servera.

![Screenshot sučelja Calculator Agent u AI Toolkit ekstenziji za Visual Studio Code. Na lijevoj ploči, pod “Tools,” dodan je MCP server pod imenom local-server-calculator_server s četiri dostupna alata: add, subtract, multiply i divide. Prikazuje se oznaka da su četiri alata aktivna. Ispod je sklopljeni odjeljak “Structure output” i plavi gumb “Run.” Na desnoj ploči, pod “Model Response,” agent poziva multiply i subtract alate s unosima {"a": 3, "b": 25} i {"a": 75, "b": 20} respektivno. Konačni “Tool Response” prikazan je kao 75.0. Na dnu je gumb “View Code.”](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.hr.png)

Pokrenut ćete kalkulator MCP server na svojem lokalnom razvojnom računalu putem **Agent Buildera** kao MCP klijenta.

1. Pritisnite `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` vrijednosti su dodijeljene za alat **subtract**.
    - Odgovori svakog alata prikazani su u odgovarajućem polju **Tool Response**.
    - Konačni izlaz modela prikazan je u polju **Model Response**.
1. Pošaljite dodatne upite za daljnje testiranje agenta. Možete promijeniti postojeći prompt u polju **User prompt** klikom u polje i zamjenom postojeće poruke.
1. Kad završite s testiranjem agenta, možete zaustaviti server u terminalu pritiskom na **CTRL/CMD+C** za prekid.

## Zadatak

Pokušajte dodati dodatni alat u svoju datoteku **server.py** (npr. izračunavanje kvadratnog korijena broja). Pošaljite dodatne upite koji bi zahtijevali da agent koristi vaš novi alat (ili postojeće alate). Obavezno ponovno pokrenite server da učita novo dodane alate.

## Rješenje

[Rješenje](./solution/README.md)

## Ključne lekcije

Glavne lekcije iz ovog poglavlja su:

- AI Toolkit ekstenzija je odličan klijent koji vam omogućuje korištenje MCP servera i njihovih alata.
- Možete dodavati nove alate MCP serverima, čime proširujete sposobnosti agenta da zadovolji rastuće zahtjeve.
- AI Toolkit uključuje predloške (npr. Python MCP server predloške) koji pojednostavljuju izradu prilagođenih alata.

## Dodatni resursi

- [AI Toolkit dokumentacija](https://aka.ms/AIToolkit/doc)

## Što slijedi

Sljedeće: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Odricanje od odgovornosti**:  
Ovaj je dokument preveden pomoću AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba se smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili kriva tumačenja proizašla iz korištenja ovog prijevoda.