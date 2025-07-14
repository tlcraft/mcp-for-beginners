<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:42:26+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "hr"
}
-->
# Korištenje servera iz AI Toolkit ekstenzije za Visual Studio Code

Kada izrađujete AI agenta, nije riječ samo o generiranju pametnih odgovora; važno je i omogućiti agentu da poduzme akciju. Tu na scenu stupa Model Context Protocol (MCP). MCP olakšava agentima pristup vanjskim alatima i uslugama na dosljedan način. Zamislite to kao priključivanje vašeg agenta u alatni okvir koji on *zaista* može koristiti.

Recimo da povežete agenta s vašim kalkulator MCP serverom. Odjednom, vaš agent može izvoditi matematičke operacije samo primanjem upita poput „Koliko je 47 puta 89?“ — bez potrebe za ručnim kodiranjem logike ili izradom prilagođenih API-ja.

## Pregled

Ova lekcija objašnjava kako povezati kalkulator MCP server s agentom koristeći [AI Toolkit](https://aka.ms/AIToolkit) ekstenziju u Visual Studio Codeu, omogućujući vašem agentu izvođenje matematičkih operacija poput zbrajanja, oduzimanja, množenja i dijeljenja putem prirodnog jezika.

AI Toolkit je moćna ekstenzija za Visual Studio Code koja pojednostavljuje razvoj agenata. AI inženjeri mogu lako graditi AI aplikacije razvijanjem i testiranjem generativnih AI modela — lokalno ili u oblaku. Ekstenzija podržava većinu glavnih generativnih modela dostupnih danas.

*Napomena*: AI Toolkit trenutno podržava Python i TypeScript.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:

- Koristiti MCP server putem AI Toolkita.
- Konfigurirati agentovu postavku kako bi mogao otkrivati i koristiti alate koje pruža MCP server.
- Koristiti MCP alate putem prirodnog jezika.

## Pristup

Evo kako trebamo pristupiti ovom zadatku na visokoj razini:

- Kreirati agenta i definirati njegov sistemski prompt.
- Kreirati MCP server s kalkulator alatima.
- Povezati Agent Builder s MCP serverom.
- Testirati pozivanje alata agenta putem prirodnog jezika.

Odlično, sada kada razumijemo tijek, konfigurirajmo AI agenta da koristi vanjske alate preko MCP-a, čime ćemo proširiti njegove mogućnosti!

## Preduvjeti

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit za Visual Studio Code](https://aka.ms/AIToolkit)

## Vježba: Korištenje servera

U ovoj vježbi izgradit ćete, pokrenuti i unaprijediti AI agenta s alatima iz MCP servera unutar Visual Studio Codea koristeći AI Toolkit.

### -0- Priprema, dodajte OpenAI GPT-4o model u My Models

Vježba koristi **GPT-4o** model. Model treba biti dodan u **My Models** prije nego što kreirate agenta.

![Screenshot sučelja za odabir modela u AI Toolkit ekstenziji za Visual Studio Code. Naslov glasi "Find the right model for your AI Solution" s podnaslovom koji potiče korisnike da otkriju, testiraju i implementiraju AI modele. Ispod, pod “Popular Models,” prikazano je šest kartica modela: DeepSeek-R1 (hostano na GitHubu), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) i DeepSeek-R1 (hostano na Ollama). Svaka kartica ima opcije “Add” ili “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.hr.png)

1. Otvorite **AI Toolkit** ekstenziju iz **Activity Bar**.
1. U odjeljku **Catalog** odaberite **Models** da otvorite **Model Catalog**. Odabirom **Models** otvara se **Model Catalog** u novom editor tabu.
1. U traku za pretraživanje **Model Catalog** upišite **OpenAI GPT-4o**.
1. Kliknite **+ Add** da dodate model na svoj popis **My Models**. Provjerite jeste li odabrali model koji je **Hosted by GitHub**.
1. U **Activity Bar** provjerite da se model **OpenAI GPT-4o** pojavljuje na popisu.

### -1- Kreirajte agenta

**Agent (Prompt) Builder** omogućuje vam kreiranje i prilagodbu vlastitih AI agenata. U ovom dijelu kreirat ćete novog agenta i dodijeliti mu model koji će pokretati razgovor.

![Screenshot sučelja "Calculator Agent" u AI Toolkit ekstenziji za Visual Studio Code. Na lijevoj strani odabran je model "OpenAI GPT-4o (via GitHub)." Sistemski prompt glasi "You are a professor in university teaching math," a korisnički prompt kaže "Explain to me the Fourier equation in simple terms." Dodatne opcije uključuju gumbe za dodavanje alata, omogućavanje MCP Servera i odabir strukturiranog izlaza. Na dnu je plavi gumb “Run.” Na desnoj strani, pod "Get Started with Examples," navedena su tri primjera agenata: Web Developer (s MCP Serverom, Second-Grade Simplifier i Dream Interpreter, svaki s kratkim opisom funkcija).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.hr.png)

1. Otvorite **AI Toolkit** ekstenziju iz **Activity Bar**.
1. U odjeljku **Tools** odaberite **Agent (Prompt) Builder**. Odabirom se otvara **Agent (Prompt) Builder** u novom editor tabu.
1. Kliknite gumb **+ New Agent**. Ekstenzija će pokrenuti čarobnjak za postavljanje putem **Command Palette**.
1. Unesite ime **Calculator Agent** i pritisnite **Enter**.
1. U **Agent (Prompt) Builder**, za polje **Model** odaberite model **OpenAI GPT-4o (via GitHub)**.

### -2- Kreirajte sistemski prompt za agenta

Nakon što ste postavili agenta, vrijeme je da definirate njegovu osobnost i svrhu. U ovom dijelu koristit ćete opciju **Generate system prompt** da opišete željeno ponašanje agenta — u ovom slučaju kalkulator agenta — i da model napiše sistemski prompt za vas.

![Screenshot sučelja "Calculator Agent" u AI Toolkit za Visual Studio Code s otvorenim modalnim prozorom pod nazivom "Generate a prompt." Modal objašnjava da se prompt predložak može generirati dijeljenjem osnovnih podataka i uključuje tekstni okvir s primjerom sistemskog prompta: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Ispod su gumbi "Close" i "Generate." U pozadini je vidljiv dio konfiguracije agenta, uključujući odabrani model "OpenAI GPT-4o (via GitHub)" i polja za sistemski i korisnički prompt.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.hr.png)

1. U odjeljku **Prompts** kliknite gumb **Generate system prompt**. Ovaj gumb otvara prompt builder koji koristi AI za generiranje sistemskog prompta za agenta.
1. U prozoru **Generate a prompt** unesite sljedeće: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kliknite gumb **Generate**. U donjem desnom kutu pojavit će se obavijest da se generira sistemski prompt. Nakon što je generiranje završeno, prompt će se pojaviti u polju **System prompt** u **Agent (Prompt) Builderu**.
1. Pregledajte **System prompt** i po potrebi ga prilagodite.

### -3- Kreirajte MCP server

Sada kada ste definirali sistemski prompt agenta — koji usmjerava njegovo ponašanje i odgovore — vrijeme je da agenta opremite praktičnim mogućnostima. U ovom dijelu kreirat ćete kalkulator MCP server s alatima za izvođenje zbrajanja, oduzimanja, množenja i dijeljenja. Ovaj server omogućit će vašem agentu izvođenje matematičkih operacija u stvarnom vremenu kao odgovor na upite prirodnim jezikom.

!["Screenshot donjeg dijela sučelja Calculator Agent u AI Toolkit ekstenziji za Visual Studio Code. Prikazuju se proširivi izbornici za “Tools” i “Structure output,” zajedno s padajućim izbornikom “Choose output format” postavljenim na “text.” Desno je gumb “+ MCP Server” za dodavanje Model Context Protocol servera. Iznad odjeljka Tools prikazana je ikona slike kao rezervirano mjesto.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.hr.png)

AI Toolkit dolazi s predlošcima koji olakšavaju izradu vlastitog MCP servera. Koristit ćemo Python predložak za kreiranje kalkulator MCP servera.

*Napomena*: AI Toolkit trenutno podržava Python i TypeScript.

1. U odjeljku **Tools** u **Agent (Prompt) Builderu** kliknite gumb **+ MCP Server**. Ekstenzija će pokrenuti čarobnjak za postavljanje putem **Command Palette**.
1. Odaberite **+ Add Server**.
1. Odaberite **Create a New MCP Server**.
1. Odaberite predložak **python-weather**.
1. Odaberite **Default folder** za spremanje MCP server predloška.
1. Unesite sljedeće ime za server: **Calculator**
1. Otvorit će se novi Visual Studio Code prozor. Odaberite **Yes, I trust the authors**.
1. U terminalu (**Terminal** > **New Terminal**) kreirajte virtualno okruženje: `python -m venv .venv`
1. U terminalu aktivirajte virtualno okruženje:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. U terminalu instalirajte ovisnosti: `pip install -e .[dev]`
1. U prikazu **Explorer** u **Activity Bar** proširite direktorij **src** i otvorite datoteku **server.py** u editoru.
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

Sada kada vaš agent ima alate, vrijeme je da ih iskoristite! U ovom dijelu poslat ćete upite agentu kako biste testirali i provjerili koristi li agent odgovarajući alat iz kalkulator MCP servera.

![Screenshot sučelja Calculator Agent u AI Toolkit ekstenziji za Visual Studio Code. Na lijevoj strani, pod “Tools,” dodan je MCP server naziva local-server-calculator_server, koji prikazuje četiri dostupna alata: add, subtract, multiply i divide. Prikazuje se oznaka da su četiri alata aktivna. Ispod je sklopljeni odjeljak “Structure output” i plavi gumb “Run.” Na desnoj strani, pod “Model Response,” agent poziva alate multiply i subtract s unosima {"a": 3, "b": 25} i {"a": 75, "b": 20}. Konačni “Tool Response” prikazan je kao 75.0. Na dnu se nalazi gumb “View Code.”](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.hr.png)

Pokrenut ćete kalkulator MCP server na svojem lokalnom razvojnom računalu putem **Agent Buildera** kao MCP klijenta.

1. Pritisnite `F5` za pokretanje debugiranja MCP servera. **Agent (Prompt) Builder** otvorit će se u novom editor tabu. Status servera vidljiv je u terminalu.
1. U polje **User prompt** u **Agent (Prompt) Builderu** unesite sljedeći upit: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Kliknite gumb **Run** za generiranje odgovora agenta.
1. Pregledajte izlaz agenta. Model bi trebao zaključiti da ste platili **$55**.
1. Evo što bi se trebalo dogoditi:
    - Agent odabire alate **multiply** i **subtract** za pomoć u izračunu.
    - Dodjeljuju se odgovarajuće vrijednosti `a` i `b` za alat **multiply**.
    - Dodjeljuju se odgovarajuće vrijednosti `a` i `b` za alat **subtract**.
    - Odgovori svakog alata prikazuju se u polju **Tool Response**.
    - Konačni rezultat modela prikazan je u polju **Model Response**.
1. Pošaljite dodatne upite za daljnje testiranje agenta. Možete izmijeniti postojeći upit u polju **User prompt** klikom i zamjenom teksta.
1. Kada završite s testiranjem, možete zaustaviti server u terminalu pritiskom na **CTRL/CMD+C**.

## Zadatak

Pokušajte dodati dodatni alat u svoju datoteku **server.py** (npr. funkciju za izračunavanje kvadratnog korijena broja). Pošaljite dodatne upite koji će zahtijevati da agent koristi vaš novi alat (ili postojeće alate). Obavezno ponovno pokrenite server da bi se novi alati učitali.

## Rješenje

[Rješenje](./solution/README.md)

## Ključne spoznaje

Glavne spoznaje iz ovog poglavlja su:

- AI Toolkit ekstenzija je izvrstan klijent koji vam omogućuje korištenje MCP servera i njihovih alata.
- Možete dodavati nove alate MCP serverima, proširujući mogućnosti agenta kako bi zadovoljio rastuće zahtjeve.
- AI Toolkit uključuje predloške (npr. Python MCP server predloške) koji pojednostavljuju izradu prilagođenih alata.

## Dodatni resursi

- [AI Toolkit dokumentacija](https://aka.ms/AIToolkit/doc)

## Što slijedi
- Sljedeće: [Testiranje i ispravljanje pogrešaka](../08-testing/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za važne informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.