<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T19:15:17+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "sl"
}
-->
# Uporaba strežnika iz razširitve AI Toolkit za Visual Studio Code

Ko ustvarjate AI agenta, ne gre le za generiranje pametnih odgovorov; pomembno je tudi, da agent lahko ukrepa. Tu pride v poštev Model Context Protocol (MCP). MCP agentom omogoča enostaven in dosleden dostop do zunanjih orodij in storitev. Predstavljajte si ga kot priklop vašega agenta na orodjarno, ki jo lahko *dejansko* uporablja.

Recimo, da povežete agenta s strežnikom MCP za kalkulator. Nenadoma lahko vaš agent izvaja matematične operacije samo z ukazom, kot je “Koliko je 47 krat 89?” — brez potrebe po ročnem kodiranju logike ali ustvarjanju lastnih API-jev.

## Pregled

Ta lekcija prikazuje, kako povezati strežnik MCP za kalkulator z agentom v razširitvi [AI Toolkit](https://aka.ms/AIToolkit) za Visual Studio Code, kar omogoča agentu izvajanje matematičnih operacij, kot so seštevanje, odštevanje, množenje in deljenje, preko naravnega jezika.

AI Toolkit je zmogljiva razširitev za Visual Studio Code, ki poenostavi razvoj agentov. AI inženirji lahko enostavno ustvarjajo AI aplikacije z razvojem in testiranjem generativnih AI modelov — lokalno ali v oblaku. Razširitev podpira večino glavnih generativnih modelov, ki so danes na voljo.

*Opomba*: AI Toolkit trenutno podpira Python in TypeScript.

## Cilji učenja

Na koncu te lekcije boste znali:

- Uporabiti MCP strežnik preko AI Toolkit.
- Nastaviti konfiguracijo agenta, da lahko odkrije in uporablja orodja, ki jih ponuja MCP strežnik.
- Uporabljati MCP orodja preko naravnega jezika.

## Pristop

Tako bomo pristopili k nalogi na visoki ravni:

- Ustvariti agenta in določiti njegov sistemski poziv.
- Ustvariti MCP strežnik s kalkulatorskimi orodji.
- Povezati Agent Builder s MCP strežnikom.
- Preizkusiti klic orodij agenta preko naravnega jezika.

Super, zdaj ko razumemo potek, konfigurirajmo AI agenta, da bo lahko uporabljal zunanja orodja preko MCP in tako razširil svoje zmožnosti!

## Predpogoji

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit za Visual Studio Code](https://aka.ms/AIToolkit)

## Vaja: Uporaba strežnika

V tej vaji boste zgradili, zagnali in izboljšali AI agenta z orodji iz MCP strežnika znotraj Visual Studio Code z uporabo AI Toolkit.

### -0- Predpriprava, dodajte model OpenAI GPT-4o v My Models

Vaja uporablja model **GPT-4o**. Model je treba dodati v **My Models** pred ustvarjanjem agenta.

![Posnetek zaslona vmesnika za izbiro modela v razširitvi AI Toolkit za Visual Studio Code. Naslov pravi "Find the right model for your AI Solution" z podnaslovom, ki spodbuja k odkrivanju, testiranju in nameščanju AI modelov. Pod “Popular Models” je prikazanih šest modelov: DeepSeek-R1 (gostovan na GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - majhen, hiter) in DeepSeek-R1 (gostovan na Ollama). Vsaka kartica ima možnosti “Add” ali “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.sl.png)

1. Odprite razširitev **AI Toolkit** iz **Activity Bar**.
1. V razdelku **Catalog** izberite **Models**, da odprete **Model Catalog**. Izbira **Models** odpre **Model Catalog** v novem zavihku urejevalnika.
1. V iskalno vrstico **Model Catalog** vpišite **OpenAI GPT-4o**.
1. Kliknite **+ Add**, da dodate model na seznam **My Models**. Prepričajte se, da ste izbrali model, ki je **Hosted by GitHub**.
1. V **Activity Bar** preverite, da se model **OpenAI GPT-4o** pojavi na seznamu.

### -1- Ustvarite agenta

**Agent (Prompt) Builder** vam omogoča ustvarjanje in prilagajanje lastnih AI agentov. V tem razdelku boste ustvarili novega agenta in mu dodelili model, ki bo poganjal pogovor.

![Posnetek zaslona vmesnika "Calculator Agent" v razširitvi AI Toolkit za Visual Studio Code. Na levem panelu je izbran model "OpenAI GPT-4o (via GitHub)." Sistemski poziv pravi "You are a professor in university teaching math," uporabniški poziv pa "Explain to me the Fourier equation in simple terms." Dodatne možnosti vključujejo gumbe za dodajanje orodij, omogočanje MCP Server in izbiro strukturiranega izhoda. Na dnu je modri gumb “Run.” Na desnem panelu so pod "Get Started with Examples" trije primeri agentov: Web Developer (z MCP Server, Second-Grade Simplifier in Dream Interpreter, vsak s kratkim opisom funkcij).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.sl.png)

1. Odprite razširitev **AI Toolkit** iz **Activity Bar**.
1. V razdelku **Tools** izberite **Agent (Prompt) Builder**. Izbira odpre **Agent (Prompt) Builder** v novem zavihku urejevalnika.
1. Kliknite gumb **+ New Agent**. Razširitev bo zagnala čarovnika za nastavitev preko **Command Palette**.
1. Vnesite ime **Calculator Agent** in pritisnite **Enter**.
1. V **Agent (Prompt) Builder**, za polje **Model** izberite model **OpenAI GPT-4o (via GitHub)**.

### -2- Ustvarite sistemski poziv za agenta

Ko je agent pripravljen, je čas, da določite njegovo osebnost in namen. V tem razdelku boste uporabili funkcijo **Generate system prompt**, da opišete želeno vedenje agenta — v tem primeru kalkulatorskega agenta — in model bo za vas ustvaril sistemski poziv.

![Posnetek zaslona vmesnika "Calculator Agent" v AI Toolkit za Visual Studio Code z odprtim modalnim oknom z naslovom "Generate a prompt." Modalno okno pojasnjuje, da je mogoče ustvariti predlogo poziva z deljenjem osnovnih podatkov in vsebuje besedilno polje s primerom sistemskega poziva: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Pod besedilnim poljem sta gumba "Close" in "Generate." V ozadju je del konfiguracije agenta, vključno z izbranim modelom "OpenAI GPT-4o (via GitHub)" in polji za sistemski in uporabniški poziv.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.sl.png)

1. V razdelku **Prompts** kliknite gumb **Generate system prompt**. Ta gumb odpre graditelja pozivov, ki uporablja AI za generiranje sistemskega poziva za agenta.
1. V oknu **Generate a prompt** vnesite naslednje: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kliknite gumb **Generate**. V spodnjem desnem kotu se bo prikazalo obvestilo, da se sistemski poziv generira. Ko je generiranje končano, se bo poziv prikazal v polju **System prompt** v **Agent (Prompt) Builder**.
1. Preglejte **System prompt** in po potrebi prilagodite.

### -3- Ustvarite MCP strežnik

Zdaj, ko ste definirali sistemski poziv agenta — ki usmerja njegovo vedenje in odzive — je čas, da agenta opremite s praktičnimi zmožnostmi. V tem razdelku boste ustvarili kalkulatorski MCP strežnik z orodji za izvajanje seštevanja, odštevanja, množenja in deljenja. Ta strežnik bo agentu omogočil izvajanje matematičnih operacij v realnem času kot odgovor na naravne jezikovne ukaze.

![Posnetek spodnjega dela vmesnika Calculator Agent v razširitvi AI Toolkit za Visual Studio Code. Prikazani so razširljivi meniji za “Tools” in “Structure output,” skupaj z izbirnim menijem “Choose output format” nastavljenim na “text.” Na desni je gumb “+ MCP Server” za dodajanje Model Context Protocol strežnika. Nad razdelkom Tools je prikazana ikona za sliko.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.sl.png)

AI Toolkit je opremljen s predlogami, ki olajšajo ustvarjanje lastnih MCP strežnikov. Uporabili bomo Python predlogo za ustvarjanje kalkulatorskega MCP strežnika.

*Opomba*: AI Toolkit trenutno podpira Python in TypeScript.

1. V razdelku **Tools** v **Agent (Prompt) Builder** kliknite gumb **+ MCP Server**. Razširitev bo zagnala čarovnika za nastavitev preko **Command Palette**.
1. Izberite **+ Add Server**.
1. Izberite **Create a New MCP Server**.
1. Izberite predlogo **python-weather**.
1. Izberite **Default folder** za shranjevanje predloge MCP strežnika.
1. Vnesite ime strežnika: **Calculator**
1. Odprlo se bo novo okno Visual Studio Code. Izberite **Yes, I trust the authors**.
1. V terminalu (**Terminal** > **New Terminal**) ustvarite virtualno okolje: `python -m venv .venv`
1. V terminalu aktivirajte virtualno okolje:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. V terminalu namestite odvisnosti: `pip install -e .[dev]`
1. V pogledu **Explorer** v **Activity Bar** razširite mapo **src** in izberite **server.py**, da odprete datoteko v urejevalniku.
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

### -4- Zaženite agenta s kalkulatorskim MCP strežnikom

Zdaj, ko ima vaš agent orodja, je čas, da jih uporabite! V tem razdelku boste agentu poslali pozive, da preizkusite in potrdite, ali agent uporablja ustrezno orodje iz kalkulatorskega MCP strežnika.

![Posnetek zaslona vmesnika Calculator Agent v razširitvi AI Toolkit za Visual Studio Code. Na levem panelu, pod “Tools,” je dodan MCP strežnik z imenom local-server-calculator_server, ki prikazuje štiri razpoložljiva orodja: add, subtract, multiply in divide. Prikazana je značka, da so štiri orodja aktivna. Spodaj je strnjen razdelek “Structure output” in modri gumb “Run.” Na desnem panelu, pod “Model Response,” agent kliče orodji multiply in subtract z vhodoma {"a": 3, "b": 25} in {"a": 75, "b": 20}. Končni “Tool Response” je prikazan kot 75.0. Na dnu je gumb “View Code.”](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.sl.png)

Kalkulatorski MCP strežnik boste zagnali na svojem lokalnem razvojnem računalniku preko **Agent Builder** kot MCP odjemalec.

1. Pritisnite `F5` za začetek razhroščevanja MCP strežnika. **Agent (Prompt) Builder** se bo odprl v novem zavihku urejevalnika. Status strežnika je viden v terminalu.
1. V polje **User prompt** v **Agent (Prompt) Builder** vnesite naslednji poziv: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Kliknite gumb **Run**, da ustvarite odgovor agenta.
1. Preglejte izhod agenta. Model bi moral zaključiti, da ste plačali **$55**.
1. Tukaj je razčlenitev, kaj se zgodi:
    - Agent izbere orodji **multiply** in **subtract**, da pomaga pri izračunu.
    - Za orodje **multiply** so dodeljene vrednosti `a` in `b`.
    - Za orodje **subtract** so dodeljene vrednosti `a` in `b`.
    - Odziv vsakega orodja je prikazan v ustreznem polju **Tool Response**.
    - Končni izhod modela je prikazan v polju **Model Response**.
1. Pošljite dodatne pozive za nadaljnje testiranje agenta. Obstoječi poziv lahko spremenite tako, da kliknete v polje **User prompt** in zamenjate besedilo.
1. Ko končate s testiranjem, lahko strežnik ustavite v terminalu s pritiskom na **CTRL/CMD+C**.

## Naloga

Poskusite dodati dodatno orodje v vašo datoteko **server.py** (npr. vrnite kvadratni koren števila). Pošljite dodatne pozive, ki bodo zahtevali uporabo vašega novega orodja (ali obstoječih orodij). Ne pozabite ponovno zagnati strežnika, da naložite novo dodana orodja.

## Rešitev

[Rešitev](./solution/README.md)

## Ključne ugotovitve

Ključne ugotovitve iz tega poglavja so:

- Razširitev AI Toolkit je odličen odjemalec, ki omogoča uporabo MCP strežnikov in njihovih orodij.
- MCP strežnikom lahko dodajate nova orodja, s čimer razširite zmožnosti agenta glede na spreminjajoče se zahteve.
- AI Toolkit vključuje predloge (npr. Python MCP strežniške predloge), ki poenostavijo ustvarjanje lastnih orodij.

## Dodatni viri

- [Dokumentacija AI Toolkit](https://aka.ms/AIToolkit/doc)

## Kaj sledi
- Naslednje: [Testiranje in razhroščevanje](../08-testing/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.