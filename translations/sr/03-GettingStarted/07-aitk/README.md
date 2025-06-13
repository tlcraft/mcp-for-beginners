<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:28:56+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "sr"
}
-->
# Korišćenje servera iz AI Toolkit ekstenzije za Visual Studio Code

Kada pravite AI agenta, nije stvar samo u generisanju pametnih odgovora; važno je i da agent ima mogućnost da preduzme akciju. Tu na scenu stupa Model Context Protocol (MCP). MCP omogućava agentima da na jednostavan i dosledan način pristupaju spoljnim alatima i servisima. Zamislite to kao povezivanje vašeg agenta sa kutijom alata koju on *zaista* može da koristi.

Recimo da povežete agenta sa vašim kalkulator MCP serverom. Odjednom, vaš agent može da izvršava matematičke operacije samo tako što dobije upit tipa „Koliko je 47 puta 89?“—bez potrebe da se logika hardkodira ili prave posebni API-jevi.

## Pregled

Ova lekcija objašnjava kako da povežete kalkulator MCP server sa agentom koristeći [AI Toolkit](https://aka.ms/AIToolkit) ekstenziju u Visual Studio Code-u, omogućavajući agentu da izvršava matematičke operacije poput sabiranja, oduzimanja, množenja i deljenja preko prirodnog jezika.

AI Toolkit je moćna ekstenzija za Visual Studio Code koja pojednostavljuje razvoj agenata. AI inženjeri lako mogu da prave AI aplikacije razvijanjem i testiranjem generativnih AI modela—lokalno ili u oblaku. Ekstenzija podržava većinu glavnih generativnih modela dostupnih danas.

*Napomena*: AI Toolkit trenutno podržava Python i TypeScript.

## Ciljevi učenja

Na kraju ove lekcije bićete u stanju da:

- Koristite MCP server preko AI Toolkita.
- Konfigurišete agenta tako da može da otkriva i koristi alate koje pruža MCP server.
- Koristite MCP alate putem prirodnog jezika.

## Pristup

Evo kako treba da pristupimo ovom zadatku na visokom nivou:

- Napravite agenta i definišite njegov sistemski prompt.
- Napravite MCP server sa kalkulatorskim alatima.
- Povežite Agent Builder sa MCP serverom.
- Testirajte pozivanje alata agenta preko prirodnog jezika.

Odlično, sada kada razumemo tok, hajde da konfigurišemo AI agenta da koristi spoljne alate preko MCP, čime ćemo proširiti njegove mogućnosti!

## Preduslovi

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit za Visual Studio Code](https://aka.ms/AIToolkit)

## Vežba: Korišćenje servera

U ovoj vežbi ćete napraviti, pokrenuti i unaprediti AI agenta koristeći alate sa MCP servera unutar Visual Studio Code-a koristeći AI Toolkit.

### -0- Pripremni korak, dodajte OpenAI GPT-4o model u My Models

Vežba koristi **GPT-4o** model. Model treba da bude dodat u **My Models** pre nego što kreirate agenta.

![Screenshot interfejsa za izbor modela u AI Toolkit ekstenziji Visual Studio Code-a. Naslov glasi "Find the right model for your AI Solution" sa podnaslovom koji ohrabruje korisnike da otkriju, testiraju i implementiraju AI modele. Ispod, u odeljku “Popular Models,” prikazano je šest model kartica: DeepSeek-R1 (hostovan na GitHub-u), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), i DeepSeek-R1 (hostovan na Ollama). Svaka kartica ima opcije za “Add” ili “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.sr.png)

1. Otvorite **AI Toolkit** ekstenziju iz **Activity Bar**.
1. U sekciji **Catalog**, izaberite **Models** da otvorite **Model Catalog**. Izborom **Models** otvara se **Model Catalog** u novom tabu editora.
1. U pretraživaču **Model Catalog** unesite **OpenAI GPT-4o**.
1. Kliknite na **+ Add** da dodate model u listu **My Models**. Proverite da li ste izabrali model koji je **hostovan na GitHub-u**.
1. U **Activity Bar** proverite da li se model **OpenAI GPT-4o** pojavljuje na listi.

### -1- Kreiranje agenta

**Agent (Prompt) Builder** vam omogućava da kreirate i prilagodite sopstvene AI agente. U ovom delu kreiraćete novog agenta i dodeliti mu model koji će pokretati konverzaciju.

![Screenshot interfejsa "Calculator Agent" builder-a u AI Toolkit ekstenziji za Visual Studio Code. Na levom panelu izabran je model "OpenAI GPT-4o (via GitHub)." Sistem prompt glasi "You are a professor in university teaching math," a korisnički prompt kaže "Explain to me the Fourier equation in simple terms." Dodatne opcije uključuju dugmad za dodavanje alata, uključivanje MCP Servera i izbor strukturiranog izlaza. Plavo dugme “Run” je na dnu. Na desnom panelu, pod "Get Started with Examples," prikazana su tri primera agenata: Web Developer (sa MCP Serverom, Second-Grade Simplifier i Dream Interpreter, svaki sa kratkim opisom funkcija).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.sr.png)

1. Otvorite **AI Toolkit** ekstenziju iz **Activity Bar**.
1. U sekciji **Tools**, izaberite **Agent (Prompt) Builder**. Otvara se u novom tabu editora.
1. Kliknite na dugme **+ New Agent**. Ekstenzija će pokrenuti čarobnjak preko **Command Palette**.
1. Unesite ime **Calculator Agent** i pritisnite **Enter**.
1. U **Agent (Prompt) Builder**, za polje **Model** izaberite model **OpenAI GPT-4o (via GitHub)**.

### -2- Kreiranje sistemskog prompta za agenta

Sada kada ste napravili agenta, vreme je da definišete njegovu ličnost i svrhu. U ovom delu koristićete opciju **Generate system prompt** da opišete ponašanje agenta—in this case, kalkulatorskog agenta—i da model napiše sistemski prompt za vas.

![Screenshot interfejsa "Calculator Agent" u AI Toolkit-u sa otvorenim modalnim prozorom "Generate a prompt." Modal objašnjava da se prompt šablon može generisati deljenjem osnovnih detalja i uključuje tekstualni okvir sa primerom sistemskog prompta: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Ispod su dugmad "Close" i "Generate". U pozadini se vidi deo konfiguracije agenta, uključujući izabrani model "OpenAI GPT-4o (via GitHub)" i polja za sistemski i korisnički prompt.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.sr.png)

1. U sekciji **Prompts**, kliknite na dugme **Generate system prompt**. Otvoriće se prompt builder koji koristi AI za generisanje sistemskog prompta za agenta.
1. U prozoru **Generate a prompt**, unesite sledeće: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kliknite na dugme **Generate**. U donjem desnom uglu pojaviće se obaveštenje da se sistemski prompt generiše. Kada generisanje bude završeno, prompt će se pojaviti u polju **System prompt** u **Agent (Prompt) Builder-u**.
1. Pregledajte **System prompt** i po potrebi ga izmenite.

### -3- Kreiranje MCP servera

Sada kada ste definisali sistemski prompt agenta—koji usmerava njegovo ponašanje i odgovore—vreme je da agenta opremite praktičnim mogućnostima. U ovom delu ćete napraviti kalkulatorski MCP server sa alatima za izvođenje sabiranja, oduzimanja, množenja i deljenja. Ovaj server će omogućiti vašem agentu da izvršava matematičke operacije u realnom vremenu kao odgovor na upite na prirodnom jeziku.

![Screenshot donjeg dela interfejsa Calculator Agent u AI Toolkit ekstenziji za Visual Studio Code. Prikazuju se proširivi meniji za “Tools” i “Structure output,” kao i padajući meni “Choose output format” podešen na “text.” Sa desne strane je dugme “+ MCP Server” za dodavanje Model Context Protocol servera. Iznad sekcije Tools prikazana je ikona slike.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.sr.png)

AI Toolkit dolazi sa šablonima koji olakšavaju kreiranje sopstvenog MCP servera. Koristićemo Python šablon za kreiranje kalkulatorskog MCP servera.

*Napomena*: AI Toolkit trenutno podržava Python i TypeScript.

1. U sekciji **Tools** u **Agent (Prompt) Builder-u**, kliknite na dugme **+ MCP Server**. Ekstenzija će pokrenuti čarobnjak preko **Command Palette**.
1. Izaberite **+ Add Server**.
1. Izaberite **Create a New MCP Server**.
1. Izaberite šablon **python-weather**.
1. Izaberite **Default folder** za čuvanje MCP server šablona.
1. Unesite sledeće ime za server: **Calculator**
1. Otvoriće se novi prozor Visual Studio Code-a. Izaberite **Yes, I trust the authors**.
1. U terminalu (**Terminal** > **New Terminal**) kreirajte virtuelno okruženje: `python -m venv .venv`
1. Aktivirajte virtuelno okruženje:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Instalirajte zavisnosti: `pip install -e .[dev]`
1. U **Explorer** prikazu u **Activity Bar**, proširite direktorijum **src** i otvorite fajl **server.py**.
1. Zamenite kod u fajlu **server.py** sledećim i sačuvajte:

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

### -4- Pokretanje agenta sa kalkulatorskim MCP serverom

Sada kada vaš agent ima alate, vreme je da ih iskoristi! U ovom delu ćete slati upite agentu da testirate i potvrdite da li agent koristi odgovarajući alat sa kalkulatorskog MCP servera.

![Screenshot interfejsa Calculator Agent u AI Toolkit ekstenziji za Visual Studio Code. Na levom panelu, u sekciji “Tools,” dodat je MCP server pod imenom local-server-calculator_server, sa četiri dostupna alata: add, subtract, multiply i divide. Prikazana je značka koja pokazuje da su četiri alata aktivna. Ispod je skupljena sekcija “Structure output” i plavo dugme “Run.” Na desnom panelu, u sekciji “Model Response,” agent poziva alate multiply i subtract sa ulazima {"a": 3, "b": 25} i {"a": 75, "b": 20}. Konačni “Tool Response” prikazan je kao 75.0. Na dnu se nalazi dugme “View Code”.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.sr.png)

Pokrenućete kalkulatorski MCP server na lokalnoj razvojnoj mašini preko **Agent Builder-a** kao MCP klijenta.

1. Pritisnite `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` vrednosti su dodeljene za alat **subtract**.
    - Odgovori sa svakog alata biće prikazani u odgovarajućem **Tool Response**.
    - Konačni izlaz iz modela biće prikazan u završnom **Model Response**.
1. Pošaljite dodatne upite da dodatno testirate agenta. Možete izmeniti postojeći prompt u polju **User prompt** klikom i zamenom teksta.
1. Kada završite sa testiranjem, možete zaustaviti server u **terminalu** unosom **CTRL/CMD+C**.

## Zadatak

Pokušajte da dodate dodatni alat u vaš **server.py** fajl (npr. funkciju koja vraća kvadratni koren broja). Pošaljite dodatne upite kojima agent treba da koristi vaš novi alat (ili postojeće alate). Ne zaboravite da restartujete server da bi novi alati bili učitani.

## Rešenje

[Solution](./solution/README.md)

## Ključni zaključci

Glavne poruke iz ovog poglavlja su:

- AI Toolkit ekstenzija je odličan klijent koji vam omogućava da koristite MCP servere i njihove alate.
- Možete dodavati nove alate MCP serverima, proširujući mogućnosti agenta da odgovori na nove zahteve.
- AI Toolkit uključuje šablone (npr. Python MCP server šablone) koji olakšavaju kreiranje prilagođenih alata.

## Dodatni resursi

- [AI Toolkit dokumentacija](https://aka.ms/AIToolkit/doc)

## Šta sledi
- Sledeće: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен помоћу AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо прецизности, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која произилазе из коришћења овог превода.