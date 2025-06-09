<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:52:05+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "sr"
}
-->
# Korišćenje servera iz AI Toolkit ekstenzije za Visual Studio Code

Kada pravite AI agenta, nije samo važno da generiše pametne odgovore, već i da ima mogućnost da preduzme akciju. Tu na scenu stupa Model Context Protocol (MCP). MCP olakšava agentima pristup spoljnim alatima i servisima na dosledan način. Zamislite to kao priključivanje vašeg agenta u alat koji on *zaista* može da koristi.

Recimo da povežete agenta sa vašim kalkulator MCP serverom. Odjednom, vaš agent može da izvodi matematičke operacije samo tako što dobije upit kao što je „Koliko je 47 puta 89?“ — bez potrebe da ručno kodirate logiku ili pravite prilagođene API-je.

## Pregled

Ova lekcija pokriva kako da povežete kalkulator MCP server sa agentom koristeći [AI Toolkit](https://aka.ms/AIToolkit) ekstenziju u Visual Studio Code-u, omogućavajući agentu da izvršava matematičke operacije kao što su sabiranje, oduzimanje, množenje i deljenje preko prirodnog jezika.

AI Toolkit je moćna ekstenzija za Visual Studio Code koja pojednostavljuje razvoj agenata. AI inženjeri lako mogu da prave AI aplikacije razvijanjem i testiranjem generativnih AI modela — lokalno ili u oblaku. Ekstenzija podržava većinu glavnih generativnih modela dostupnih danas.

*Napomena*: AI Toolkit trenutno podržava Python i TypeScript.

## Ciljevi učenja

Do kraja ove lekcije moći ćete da:

- Koristite MCP server preko AI Toolkit-a.
- Konfigurišete agenta tako da može da otkriva i koristi alate koje obezbeđuje MCP server.
- Koristite MCP alate preko prirodnog jezika.

## Pristup

Evo kako treba da pristupimo ovom zadatku na visokom nivou:

- Kreirajte agenta i definišite njegov sistemski prompt.
- Kreirajte MCP server sa kalkulatorskim alatima.
- Povežite Agent Builder sa MCP serverom.
- Testirajte pozivanje alata od strane agenta putem prirodnog jezika.

Sjajno, sada kada razumemo tok, hajde da konfigurišemo AI agenta da koristi spoljne alate preko MCP-a, čime ćemo proširiti njegove mogućnosti!

## Preduslovi

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit za Visual Studio Code](https://aka.ms/AIToolkit)

## Vežba: Korišćenje servera

U ovoj vežbi izgradićete, pokrenuti i unaprediti AI agenta sa alatima sa MCP servera unutar Visual Studio Code-a koristeći AI Toolkit.

### -0- Prethodni korak, dodajte OpenAI GPT-4o model u My Models

Vežba koristi **GPT-4o** model. Model treba da bude dodat u **My Models** pre nego što napravite agenta.

![Screenshot interfejsa za izbor modela u AI Toolkit ekstenziji za Visual Studio Code. Naslov glasi "Find the right model for your AI Solution" sa podnaslovom koji ohrabruje korisnike da otkriju, testiraju i implementiraju AI modele. Ispod, pod “Popular Models,” prikazano je šest kartica modela: DeepSeek-R1 (hostovan na GitHub-u), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), i DeepSeek-R1 (hostovan na Ollama). Svaka kartica ima opcije za “Add” model ili “Try in Playground”.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.sr.png)

1. Otvorite **AI Toolkit** ekstenziju iz **Activity Bar**.
1. U sekciji **Catalog**, izaberite **Models** da otvorite **Model Catalog**. Izbor **Models** otvara **Model Catalog** u novoj kartici editora.
1. U pretraživaču **Model Catalog** unesite **OpenAI GPT-4o**.
1. Kliknite na **+ Add** da dodate model u vašu listu **My Models**. Proverite da ste izabrali model koji je **Hosted by GitHub**.
1. U **Activity Bar**, potvrdite da se model **OpenAI GPT-4o** pojavljuje na listi.

### -1- Kreirajte agenta

**Agent (Prompt) Builder** vam omogućava da kreirate i prilagodite svoje AI agente. U ovom delu kreiraćete novog agenta i dodeliti mu model koji će pokretati konverzaciju.

![Screenshot interfejsa "Calculator Agent" builder-a u AI Toolkit ekstenziji za Visual Studio Code. Na levom panelu, izabrani model je "OpenAI GPT-4o (via GitHub)." Sistemski prompt glasi "You are a professor in university teaching math," a korisnički prompt kaže "Explain to me the Fourier equation in simple terms." Dodatne opcije uključuju dugmad za dodavanje alata, omogućavanje MCP Servera i izbor strukturiranog izlaza. Plavo dugme “Run” se nalazi na dnu. Na desnom panelu, pod "Get Started with Examples," navedena su tri primer agenta: Web Developer (sa MCP Serverom, Second-Grade Simplifier i Dream Interpreter, svaki sa kratkim opisom funkcija).](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.sr.png)

1. Otvorite **AI Toolkit** ekstenziju iz **Activity Bar**.
1. U sekciji **Tools**, izaberite **Agent (Prompt) Builder**. Izbor otvara **Agent (Prompt) Builder** u novoj kartici editora.
1. Kliknite na dugme **+ New Agent**. Ekstenzija će pokrenuti čarobnjak za podešavanje preko **Command Palette**.
1. Unesite ime **Calculator Agent** i pritisnite **Enter**.
1. U **Agent (Prompt) Builder**, za polje **Model**, izaberite model **OpenAI GPT-4o (via GitHub)**.

### -2- Kreirajte sistemski prompt za agenta

Kada je agent postavljen, vreme je da definišete njegov karakter i svrhu. U ovom delu koristićete opciju **Generate system prompt** da opišete željeno ponašanje agenta — u ovom slučaju, kalkulatorskog agenta — i da model napiše sistemski prompt za vas.

![Screenshot interfejsa "Calculator Agent" u AI Toolkit za Visual Studio Code sa otvorenim modalnim prozorom pod nazivom "Generate a prompt." Modal objašnjava da se šablon prompta može generisati unošenjem osnovnih detalja i uključuje tekstualni okvir sa primerom sistemskog prompta: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Ispod su dugmad "Close" i "Generate". U pozadini je vidljiv deo konfiguracije agenta, uključujući izabrani model "OpenAI GPT-4o (via GitHub)" i polja za sistemski i korisnički prompt.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.sr.png)

1. U sekciji **Prompts**, kliknite na dugme **Generate system prompt**. Ovo dugme otvara prompt builder koji koristi AI za generisanje sistemskog prompta za agenta.
1. U prozoru **Generate a prompt**, unesite sledeće: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kliknite na dugme **Generate**. U donjem desnom uglu pojaviće se obaveštenje da se sistemski prompt generiše. Kada generisanje bude završeno, prompt će se pojaviti u polju **System prompt** u okviru **Agent (Prompt) Builder**.
1. Pregledajte **System prompt** i izmenite ga po potrebi.

### -3- Kreirajte MCP server

Sada kada ste definisali sistemski prompt agenta — koji usmerava njegovo ponašanje i odgovore — vreme je da agenta opremite praktičnim mogućnostima. U ovom delu kreiraćete kalkulatorski MCP server sa alatima za izvršavanje sabiranja, oduzimanja, množenja i deljenja. Ovaj server će omogućiti agentu da u realnom vremenu izvršava matematičke operacije kao odgovor na upite u prirodnom jeziku.

!["Screenshot donjeg dela interfejsa Calculator Agent u AI Toolkit ekstenziji za Visual Studio Code. Prikazani su proširivi meniji za “Tools” i “Structure output,” kao i padajući meni sa opcijom “Choose output format” podešen na “text.” Sa desne strane je dugme označeno kao “+ MCP Server” za dodavanje Model Context Protocol servera. Iznad sekcije Tools prikazana je ikona slike kao mesto za prikaz.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.sr.png)

AI Toolkit dolazi sa šablonima koji olakšavaju kreiranje sopstvenog MCP servera. Koristićemo Python šablon za pravljenje kalkulatorskog MCP servera.

*Napomena*: AI Toolkit trenutno podržava Python i TypeScript.

1. U sekciji **Tools** u okviru **Agent (Prompt) Builder**, kliknite na dugme **+ MCP Server**. Ekstenzija će pokrenuti čarobnjak za podešavanje preko **Command Palette**.
1. Izaberite **+ Add Server**.
1. Izaberite **Create a New MCP Server**.
1. Izaberite šablon **python-weather**.
1. Izaberite **Default folder** za čuvanje MCP server šablona.
1. Unesite sledeće ime za server: **Calculator**
1. Otvoriće se novi Visual Studio Code prozor. Izaberite **Yes, I trust the authors**.
1. Koristeći terminal (**Terminal** > **New Terminal**), kreirajte virtuelno okruženje: `python -m venv .venv`
1. Aktivirajte virtuelno okruženje u terminalu:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Instalirajte zavisnosti u terminalu: `pip install -e .[dev]`
1. U prikazu **Explorer** u **Activity Bar**, proširite direktorijum **src** i otvorite fajl **server.py** u editoru.
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

### -4- Pokrenite agenta sa kalkulatorskim MCP serverom

Sada kada vaš agent ima alate, vreme je da ih koristite! U ovom delu poslaćete upite agentu da testirate i potvrdite da agent koristi odgovarajući alat sa kalkulatorskog MCP servera.

![Screenshot interfejsa Calculator Agent u AI Toolkit ekstenziji za Visual Studio Code. Na levom panelu, pod “Tools,” dodat je MCP server nazvan local-server-calculator_server, sa prikazom četiri dostupna alata: add, subtract, multiply i divide. Prikazana je značka koja pokazuje da su četiri alata aktivna. Ispod je sklopljena sekcija “Structure output” i plavo dugme “Run.” Na desnom panelu, pod “Model Response,” agent poziva multiply i subtract alate sa ulazima {"a": 3, "b": 25} i {"a": 75, "b": 20} respektivno. Konačni “Tool Response” prikazan je kao 75.0. Dugme “View Code” se nalazi na dnu.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.sr.png)

Pokrenućete kalkulatorski MCP server na vašem lokalnom razvojnom računaru preko **Agent Builder** kao MCP klijent.

1. Pritisnite `F5` da pokrenete agenta.
1. Pošaljite upit: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?` vrednosti za alate **subtract** su dodeljene kao `a` i `b`.
    - Odgovor od svakog alata biće prikazan u odgovarajućem **Tool Response**.
    - Konačni rezultat modela biće prikazan u završnom **Model Response**.
1. Pošaljite dodatne upite da dodatno testirate agenta. Možete izmeniti postojeći upit u polju **User prompt** klikom u polje i zamenom teksta.
1. Kada završite sa testiranjem agenta, možete zaustaviti server u **terminalu** unosom **CTRL/CMD+C** da izađete.

## Zadatak

Pokušajte da dodate dodatni alat u vaš **server.py** fajl (npr. vraćanje kvadratnog korena broja). Pošaljite dodatne upite koji zahtevaju da agent koristi vaš novi alat (ili postojeće alate). Obavezno restartujte server da bi se novi alati učitali.

## Rešenje

[Rešenje](./solution/README.md)

## Ključne poruke

Glavne poruke iz ovog poglavlja su:

- AI Toolkit ekstenzija je odličan klijent koji vam omogućava da koristite MCP servere i njihove alate.
- Možete dodavati nove alate MCP serverima, čime proširujete mogućnosti agenta da zadovolji nove zahteve.
- AI Toolkit uključuje šablone (npr. Python MCP server šablone) koji pojednostavljuju kreiranje prilagođenih alata.

## Dodatni resursi

- [AI Toolkit dokumentacija](https://aka.ms/AIToolkit/doc)

## Šta sledi

Sledeće: [Lekcija 4 Praktična primena](/04-PracticalImplementation/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен помоћу AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо тачности, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Изворни документ на његовом оригиналном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални превод од стране људског преводиоца. Нисмо одговорни за било каква неспоразума или погрешне интерпретације настале коришћењем овог превода.