<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:31:30+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "sl"
}
-->
# Potrošnja strežnika iz razširitve AI Toolkit za Visual Studio Code

Ko gradite AI agenta, ne gre le za generiranje pametnih odgovorov; gre tudi za omogočanje vašemu agentu, da ukrepa. Tukaj pride v igro Model Context Protocol (MCP). MCP agentom omogoča dostop do zunanjih orodij in storitev na konsistenten način. Pomislite na to kot na priklop vašega agenta v orodjarno, ki jo lahko *dejansko* uporablja.

Recimo, da povežete agenta s strežnikom MCP kalkulatorja. Nenadoma lahko vaš agent izvaja matematične operacije samo s prejemanjem vprašanja, kot je "Koliko je 47 krat 89?"—ni potrebe po kodiranju logike ali gradnji prilagojenih API-jev.

## Pregled

Ta lekcija pokriva, kako povezati strežnik MCP kalkulatorja z agentom z razširitvijo [AI Toolkit](https://aka.ms/AIToolkit) v Visual Studio Code, kar omogoča vašemu agentu izvajanje matematičnih operacij, kot so seštevanje, odštevanje, množenje in deljenje prek naravnega jezika.

AI Toolkit je močna razširitev za Visual Studio Code, ki poenostavi razvoj agentov. AI inženirji lahko enostavno gradijo AI aplikacije z razvojem in testiranjem generativnih AI modelov—lokalno ali v oblaku. Razširitev podpira večino večjih generativnih modelov, ki so danes na voljo.

*Opomba*: AI Toolkit trenutno podpira Python in TypeScript.

## Cilji učenja

Na koncu te lekcije boste sposobni:

- Porabiti MCP strežnik preko AI Toolkita.
- Konfigurirati konfiguracijo agenta, da mu omogočite odkrivanje in uporabo orodij, ki jih ponuja MCP strežnik.
- Uporabljati MCP orodja preko naravnega jezika.

## Pristop

Tukaj je, kako se moramo pristopiti k temu na visoki ravni:

- Ustvarite agenta in določite njegov sistemski poziv.
- Ustvarite MCP strežnik z orodji kalkulatorja.
- Povežite Builder agenta z MCP strežnikom.
- Testirajte agentovo invokacijo orodij preko naravnega jezika.

Odlično, zdaj ko razumemo potek, konfigurirajmo AI agenta za izkoriščanje zunanjih orodij prek MCP, s čimer povečamo njegove zmogljivosti!

## Predpogoji

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit za Visual Studio Code](https://aka.ms/AIToolkit)

## Vaja: Poraba strežnika

V tej vaji boste zgradili, zagnali in izboljšali AI agenta z orodji iz MCP strežnika znotraj Visual Studio Code z uporabo AI Toolkita.

### -0- Predkorak, dodajte model OpenAI GPT-4o v Moji modeli

Vaja uporablja model **GPT-4o**. Model je treba dodati v **Moji modeli** pred ustvarjanjem agenta.

1. Odprite razširitev **AI Toolkit** iz **Activity Bar**.
1. V razdelku **Catalog** izberite **Models** za odpiranje **Model Catalog**. Izbira **Models** odpre **Model Catalog** v novem zavihku urejevalnika.
1. V iskalni vrstici **Model Catalog** vnesite **OpenAI GPT-4o**.
1. Kliknite **+ Add**, da dodate model v vaš seznam **Moji modeli**. Poskrbite, da ste izbrali model, ki je **Hosted by GitHub**.
1. V **Activity Bar** potrdite, da se model **OpenAI GPT-4o** pojavi na seznamu.

### -1- Ustvarite agenta

**Agent (Prompt) Builder** vam omogoča ustvarjanje in prilagajanje lastnih AI agentov. V tem razdelku boste ustvarili novega agenta in mu dodelili model za pogon pogovora.

1. Odprite razširitev **AI Toolkit** iz **Activity Bar**.
1. V razdelku **Tools** izberite **Agent (Prompt) Builder**. Izbira **Agent (Prompt) Builder** odpre **Agent (Prompt) Builder** v novem zavihku urejevalnika.
1. Kliknite gumb **+ New Builder**. Razširitev bo zagnala čarovnika za nastavitev prek **Command Palette**.
1. Vnesite ime **Calculator Agent** in pritisnite **Enter**.
1. V **Agent (Prompt) Builder**, za polje **Model** izberite model **OpenAI GPT-4o (via GitHub)**.

### -2- Ustvarite sistemski poziv za agenta

Z agentom, ki je zasnovan, je čas, da določite njegovo osebnost in namen. V tem razdelku boste uporabili funkcijo **Generate system prompt** za opis predvidenega vedenja agenta—v tem primeru kalkulator agenta—in model bo za vas napisal sistemski poziv.

1. Za razdelek **Prompts** kliknite gumb **Generate system prompt**. Ta gumb se odpre v graditelju pozivov, ki uporablja AI za generiranje sistemskega poziva za agenta.
1. V oknu **Generate a prompt** vnesite naslednje: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kliknite gumb **Generate**. V spodnjem desnem kotu se bo pojavilo obvestilo, ki potrjuje, da se generira sistemski poziv. Ko je generacija poziva končana, se bo poziv pojavil v polju **System prompt** v **Agent (Prompt) Builder**.
1. Preglejte **System prompt** in po potrebi spremenite.

### -3- Ustvarite MCP strežnik

Zdaj, ko ste definirali sistemski poziv agenta—ki usmerja njegovo vedenje in odzive—je čas, da agenta opremite s praktičnimi zmogljivostmi. V tem razdelku boste ustvarili MCP strežnik kalkulatorja z orodji za izvajanje izračunov seštevanja, odštevanja, množenja in deljenja. Ta strežnik bo omogočil vašemu agentu izvajanje matematičnih operacij v realnem času kot odziv na naravne jezikovne pozive.

AI Toolkit je opremljen s predlogami za lažje ustvarjanje lastnega MCP strežnika. Uporabili bomo Python predlogo za ustvarjanje MCP strežnika kalkulatorja.

*Opomba*: AI Toolkit trenutno podpira Python in TypeScript.

1. V razdelku **Tools** v **Agent (Prompt) Builder** kliknite gumb **+ MCP Server**. Razširitev bo zagnala čarovnika za nastavitev prek **Command Palette**.
1. Izberite **+ Add Server**.
1. Izberite **Create a New MCP Server**.
1. Izberite **python-weather** kot predlogo.
1. Izberite **Default folder** za shranjevanje predloge MCP strežnika.
1. Vnesite naslednje ime za strežnik: **Calculator**
1. Odprlo se bo novo okno Visual Studio Code. Izberite **Yes, I trust the authors**.
1. Z uporabo terminala (**Terminal** > **New Terminal**) ustvarite virtualno okolje: `python -m venv .venv`
1. Z uporabo terminala aktivirajte virtualno okolje:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Z uporabo terminala namestite odvisnosti: `pip install -e .[dev]`
1. V pogledu **Explorer** v **Activity Bar** razširite imenik **src** in izberite **server.py** za odpiranje datoteke v urejevalniku.
1. Zamenjajte kodo v datoteki **server.py** z naslednjo in shranite:

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

### -4- Zaženite agenta s MCP strežnikom kalkulatorja

Zdaj, ko vaš agent ima orodja, je čas, da jih uporabi! V tem razdelku boste agentu poslali pozive, da preizkusite in preverite, ali agent uporablja ustrezno orodje iz MCP strežnika kalkulatorja.

Strežnik MCP kalkulatorja boste zagnali na svojem lokalnem dev računalniku prek **Agent Builder** kot MCP klient.

1. Pritisnite `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Kupil sem 3 predmete, vsak po ceni $25, nato pa uporabil popust $20. Koliko sem plačal?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` vrednosti so dodeljene za orodje **subtract**.
    - Odziv vsakega orodja je zagotovljen v ustreznem **Tool Response**.
    - Končni izhod modela je zagotovljen v končnem **Model Response**.
1. Pošljite dodatne pozive za nadaljnje testiranje agenta. Obstoječi poziv lahko spremenite v polju **User prompt** tako, da kliknete v polje in zamenjate obstoječi poziv.
1. Ko končate testiranje agenta, lahko ustavite strežnik prek **terminala** tako, da vnesete **CTRL/CMD+C** za prekinitev.

## Naloga

Poskusite dodati dodatno orodno vnos v vašo datoteko **server.py** (npr. vrniti kvadratni koren števila). Pošljite dodatne pozive, ki bi zahtevali, da agent izkoristi vaše novo orodje (ali obstoječa orodja). Poskrbite, da boste ponovno zagnali strežnik za nalaganje novo dodanih orodij.

## Rešitev

[Rešitev](./solution/README.md)

## Ključni poudarki

Ključni poudarki tega poglavja so naslednji:

- Razširitev AI Toolkit je odličen klient, ki vam omogoča porabo MCP strežnikov in njihovih orodij.
- Lahko dodate nova orodja v MCP strežnike, s čimer razširite zmogljivosti agenta, da zadostite spreminjajočim se zahtevam.
- AI Toolkit vključuje predloge (npr. Python predloge MCP strežnikov) za poenostavitev ustvarjanja prilagojenih orodij.

## Dodatni viri

- [AI Toolkit dokumentacija](https://aka.ms/AIToolkit/doc)

## Kaj sledi

Naslednje: [Lekcija 4 Praktična implementacija](/04-PracticalImplementation/README.md)

**Omejitev odgovornosti**:
Ta dokument je bil preveden z uporabo storitve AI prevajanja [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za kritične informacije je priporočljivo profesionalno prevajanje s strani človeka. Ne prevzemamo odgovornosti za morebitne nesporazume ali napačne razlage, ki izhajajo iz uporabe tega prevoda.