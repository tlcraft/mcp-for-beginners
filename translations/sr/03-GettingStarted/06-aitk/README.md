<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:30:30+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "sr"
}
-->
# Korišćenje servera iz AI Toolkit ekstenzije za Visual Studio Code

Kada pravite AI agenta, nije samo važno generisati pametne odgovore; važno je i omogućiti vašem agentu da preduzme akcije. Tu dolazi Model Context Protocol (MCP). MCP omogućava agentima da pristupe spoljnim alatima i servisima na konzistentan način. Zamislite to kao da priključujete vašeg agenta u kutiju sa alatima koju može *zaista* koristiti.

Recimo da povežete agenta sa vašim MCP serverom kalkulatora. Odjednom, vaš agent može izvoditi matematičke operacije samo primanjem upita kao što je "Koliko je 47 puta 89?"—nema potrebe za hardkodiranjem logike ili izgradnjom prilagođenih API-ja.

## Pregled

Ova lekcija pokriva kako povezati MCP server kalkulatora sa agentom koristeći [AI Toolkit](https://aka.ms/AIToolkit) ekstenziju u Visual Studio Code, omogućavajući vašem agentu da izvodi matematičke operacije kao što su sabiranje, oduzimanje, množenje i deljenje putem prirodnog jezika.

AI Toolkit je moćna ekstenzija za Visual Studio Code koja pojednostavljuje razvoj agenata. AI inženjeri mogu lako razvijati AI aplikacije razvijanjem i testiranjem generativnih AI modela—lokalno ili u oblaku. Ekstenzija podržava većinu glavnih generativnih modela dostupnih danas.

*Napomena*: AI Toolkit trenutno podržava Python i TypeScript.

## Ciljevi učenja

Do kraja ove lekcije, bićete u stanju da:

- Koristite MCP server putem AI Toolkit-a.
- Konfigurišete podešavanje agenta da bi mogao otkriti i koristiti alate koje pruža MCP server.
- Koristite MCP alate putem prirodnog jezika.

## Pristup

Evo kako treba da pristupimo ovome na visokom nivou:

- Kreirajte agenta i definišite njegov sistemski prompt.
- Kreirajte MCP server sa alatima kalkulatora.
- Povežite Agent Builder sa MCP serverom.
- Testirajte pozivanje alata agenta putem prirodnog jezika.

Odlično, sada kada razumemo tok, hajde da konfigurišemo AI agenta da koristi spoljne alate putem MCP, poboljšavajući njegove sposobnosti!

## Preduslovi

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit za Visual Studio Code](https://aka.ms/AIToolkit)

## Vežba: Korišćenje servera

U ovoj vežbi ćete izgraditi, pokrenuti i unaprediti AI agenta sa alatima iz MCP servera unutar Visual Studio Code koristeći AI Toolkit.

### -0- Predkorak, dodajte OpenAI GPT-4o model u Moji modeli

Vežba koristi **GPT-4o** model. Model treba da bude dodat u **Moji modeli** pre nego što kreirate agenta.

1. Otvorite **AI Toolkit** ekstenziju iz **Aktivnost bara**.
1. U sekciji **Katalog**, izaberite **Modeli** da otvorite **Katalog modela**. Izbor **Modeli** otvara **Katalog modela** u novom editor tabu.
1. U pretrazi **Katalog modela**, unesite **OpenAI GPT-4o**.
1. Kliknite **+ Dodaj** da dodate model na vašu listu **Moji modeli**. Uverite se da ste izabrali model koji je **Hostovan od strane GitHub-a**.
1. U **Aktivnost baru**, potvrdite da se model **OpenAI GPT-4o** pojavljuje na listi.

### -1- Kreirajte agenta

**Agent (Prompt) Builder** vam omogućava da kreirate i prilagodite sopstvene agente pokretane veštačkom inteligencijom. U ovom delu, kreiraćete novog agenta i dodeliti model koji će pokretati konverzaciju.

1. Otvorite **AI Toolkit** ekstenziju iz **Aktivnost bara**.
1. U sekciji **Alati**, izaberite **Agent (Prompt) Builder**. Izbor **Agent (Prompt) Builder** otvara **Agent (Prompt) Builder** u novom editor tabu.
1. Kliknite na dugme **+ Novi Builder**. Ekstenzija će pokrenuti čarobnjaka za podešavanje putem **Command Palette**.
1. Unesite ime **Kalkulator Agent** i pritisnite **Enter**.
1. U **Agent (Prompt) Builder**, za polje **Model**, izaberite model **OpenAI GPT-4o (preko GitHub-a)**.

### -2- Kreirajte sistemski prompt za agenta

Sada kada je agent postavljen, vreme je da definišete njegovu ličnost i svrhu. U ovom delu, koristićete funkciju **Generiši sistemski prompt** da opišete planirano ponašanje agenta—u ovom slučaju, agenta kalkulatora—i neka model napiše sistemski prompt za vas.

1. Za sekciju **Prompts**, kliknite na dugme **Generiši sistemski prompt**. Ovo dugme otvara generator prompta koji koristi AI za generisanje sistemskog prompta za agenta.
1. U prozoru **Generiši prompt**, unesite sledeće: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kliknite na dugme **Generiši**. Pojaviće se obaveštenje u donjem desnom uglu koje potvrđuje da se sistemski prompt generiše. Kada je generisanje prompta završeno, prompt će se pojaviti u polju **Sistemski prompt** u **Agent (Prompt) Builder**.
1. Pregledajte **Sistemski prompt** i modifikujte po potrebi.

### -3- Kreirajte MCP server

Sada kada ste definisali sistemski prompt vašeg agenta—koji vodi njegovo ponašanje i odgovore—vreme je da opremite agenta praktičnim sposobnostima. U ovom delu, kreiraćete MCP server kalkulatora sa alatima za izvođenje operacija sabiranja, oduzimanja, množenja i deljenja. Ovaj server će omogućiti vašem agentu da izvodi matematičke operacije u realnom vremenu kao odgovor na upite u prirodnom jeziku.

AI Toolkit je opremljen šablonima za jednostavno kreiranje sopstvenog MCP servera. Koristićemo Python šablon za kreiranje MCP servera kalkulatora.

*Napomena*: AI Toolkit trenutno podržava Python i TypeScript.

1. U sekciji **Alati** u **Agent (Prompt) Builder**, kliknite na dugme **+ MCP Server**. Ekstenzija će pokrenuti čarobnjaka za podešavanje putem **Command Palette**.
1. Izaberite **+ Dodaj Server**.
1. Izaberite **Kreiraj novi MCP Server**.
1. Izaberite **python-weather** kao šablon.
1. Izaberite **Podrazumevani folder** za čuvanje šablona MCP servera.
1. Unesite sledeće ime za server: **Kalkulator**
1. Novi prozor Visual Studio Code-a će se otvoriti. Izaberite **Da, verujem autorima**.
1. Koristeći terminal (**Terminal** > **Novi Terminal**), kreirajte virtuelno okruženje: `python -m venv .venv`
1. Koristeći terminal, aktivirajte virtuelno okruženje:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Koristeći terminal, instalirajte zavisnosti: `pip install -e .[dev]`
1. U prikazu **Explorer** u **Aktivnost baru**, proširite direktorijum **src** i izaberite **server.py** da otvorite datoteku u editoru.
1. Zamenite kod u datoteci **server.py** sa sledećim i sačuvajte:

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

### -4- Pokrenite agenta sa MCP serverom kalkulatora

Sada kada vaš agent ima alate, vreme je da ih iskoristite! U ovom delu, poslaćete upite agentu da testirate i potvrdite da li agent koristi odgovarajući alat sa MCP servera kalkulatora.

Vi ćete pokrenuti MCP server kalkulatora na vašoj lokalnoj razvojnoj mašini putem **Agent Builder** kao MCP klijenta.

1. Pritisnite `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Kupio sam 3 predmeta po ceni od 25 dolara svaki, a zatim iskoristio popust od 20 dolara. Koliko sam platio?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` vrednosti su dodeljene za alat **oduzmi**.
    - Odgovor svakog alata je dat u odgovarajućem **Odgovoru alata**.
    - Konačni izlaz iz modela je dat u konačnom **Odgovoru modela**.
1. Pošaljite dodatne upite za dalje testiranje agenta. Možete modifikovati postojeći upit u polju **Korisnički upit** klikom na polje i zamenom postojećeg upita.
1. Kada završite sa testiranjem agenta, možete zaustaviti server putem **terminala** unosom **CTRL/CMD+C** za prekid.

## Zadatak

Pokušajte da dodate dodatni unos alata u vašu datoteku **server.py** (npr. vraćanje kvadratnog korena broja). Pošaljite dodatne upite koji bi zahtevali od agenta da koristi vaš novi alat (ili postojeće alate). Obavezno ponovo pokrenite server da biste učitali novo dodate alate.

## Rešenje

[Rešenje](./solution/README.md)

## Ključne tačke

Ključne tačke iz ovog poglavlja su sledeće:

- AI Toolkit ekstenzija je odličan klijent koji vam omogućava korišćenje MCP servera i njihovih alata.
- Možete dodati nove alate MCP serverima, proširujući sposobnosti agenta kako bi zadovoljili razvijajuće zahteve.
- AI Toolkit uključuje šablone (npr. Python MCP server šabloni) kako bi pojednostavio kreiranje prilagođenih alata.

## Dodatni resursi

- [AI Toolkit dokumentacija](https://aka.ms/AIToolkit/doc)

## Šta sledi

Dalje: [Lekcija 4 Praktična implementacija](/04-PracticalImplementation/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо ка тачности, имајте на уму да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на свом изворном језику треба сматрати ауторитативним извором. За критичне информације, препоручује се професионални превод од стране људи. Нисмо одговорни за било какве неспоразуме или погрешна тумачења која могу настати коришћењем овог превода.