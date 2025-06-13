<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:26:26+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "hu"
}
-->
# Egy szerver használata az AI Toolkit bővítményből a Visual Studio Code-ban

Amikor AI ügynököt építesz, nem csak az okos válaszok generálása a lényeg; az ügynöknek cselekvési képességekkel is rendelkeznie kell. Itt jön képbe a Model Context Protocol (MCP). Az MCP megkönnyíti, hogy az ügynökök egységes módon férjenek hozzá külső eszközökhöz és szolgáltatásokhoz. Olyan, mintha az ügynököd egy olyan szerszámosládába lenne bedugva, amit tényleg használni tud.

Tegyük fel, hogy összekapcsolsz egy ügynököt a számológép MCP szervereddel. Hirtelen az ügynök képes lesz matematikai műveleteket végezni csak azzal, hogy megkapja a „Mi 47 szorozva 89-cel?” kérdést — nincs szükség logika keménykódolására vagy egyedi API-k építésére.

## Áttekintés

Ebben a leckében azt mutatjuk be, hogyan kapcsolj egy számológép MCP szervert egy ügynökhöz az [AI Toolkit](https://aka.ms/AIToolkit) bővítmény segítségével a Visual Studio Code-ban, lehetővé téve, hogy az ügynök matematikai műveleteket hajtson végre, például összeadást, kivonást, szorzást és osztást természetes nyelven keresztül.

Az AI Toolkit egy hatékony bővítmény a Visual Studio Code-hoz, amely leegyszerűsíti az ügynökök fejlesztését. Az AI mérnökök könnyen építhetnek AI alkalmazásokat generatív AI modellek fejlesztésével és tesztelésével — akár helyben, akár a felhőben. A bővítmény támogatja a legtöbb ma elérhető jelentős generatív modellt.

*Megjegyzés*: Az AI Toolkit jelenleg a Python és a TypeScript nyelveket támogatja.

## Tanulási célok

A lecke végére képes leszel:

- MCP szervert használni az AI Toolkit segítségével.
- Ügynök konfigurációt beállítani, hogy felfedezze és használja az MCP szerver által biztosított eszközöket.
- MCP eszközöket természetes nyelven keresztül használni.

## Megközelítés

Így kell nagy vonalakban hozzáállnunk:

- Hozz létre egy ügynököt és határozd meg a rendszer promptját.
- Hozz létre egy MCP szervert számológép eszközökkel.
- Kapcsold össze az Agent Builder-t az MCP szerverrel.
- Teszteld az ügynök eszközhasználatát természetes nyelven.

Remek, most, hogy értjük a folyamatot, állítsuk be az AI ügynököt, hogy MCP-n keresztül használjon külső eszközöket, így bővítve a képességeit!

## Előfeltételek

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit a Visual Studio Code-hoz](https://aka.ms/AIToolkit)

## Gyakorlat: Egy szerver használata

Ebben a gyakorlatban egy MCP szerver eszközeivel rendelkező AI ügynököt fogsz építeni, futtatni és fejleszteni a Visual Studio Code-on belül az AI Toolkit segítségével.

### -0- Előkészítés, add hozzá az OpenAI GPT-4o modellt a My Models listához

A gyakorlat a **GPT-4o** modellt használja. A modellt hozzá kell adni a **My Models** listához az ügynök létrehozása előtt.

![Képernyőkép az AI Toolkit bővítmény modellválasztó felületéről a Visual Studio Code-ban. A cím: "Find the right model for your AI Solution", az alcím arra buzdít, hogy fedezd fel, teszteld és telepítsd az AI modelleket. Az alatta lévő “Popular Models” alatt hat modellkártya látható: DeepSeek-R1 (GitHub-hostolt), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Kicsi, Gyors), és DeepSeek-R1 (Ollama-hostolt). Mindegyik kártyán lehetőség van a modell “Add” hozzáadására vagy “Try in Playground” kipróbálására.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.hu.png)

1. Nyisd meg az **AI Toolkit** bővítményt az **Activity Bar**-ból.
1. A **Catalog** szekcióban válaszd ki a **Models** részt a **Model Catalog** megnyitásához. A **Models** kiválasztása új szerkesztőfülön nyitja meg a **Model Catalog**-ot.
1. A **Model Catalog** keresősávjába írd be az **OpenAI GPT-4o** kifejezést.
1. Kattints a **+ Add** gombra, hogy hozzáadd a modellt a **My Models** listádhoz. Győződj meg róla, hogy a **GitHub által hosztolt** modellt választottad.
1. Az **Activity Bar**-ban ellenőrizd, hogy az **OpenAI GPT-4o** modell megjelenik a listában.

### -1- Ügynök létrehozása

Az **Agent (Prompt) Builder** lehetővé teszi, hogy saját AI-alapú ügynököket hozz létre és testre szabj. Ebben a részben létrehozol egy új ügynököt, és hozzárendelsz egy modellt a beszélgetéshez.

![Képernyőkép a "Calculator Agent" építőfelületéről az AI Toolkit bővítményben a Visual Studio Code-ban. A bal oldali panelen az "OpenAI GPT-4o (via GitHub)" modell van kiválasztva. A rendszer prompt így szól: "You are a professor in university teaching math," a felhasználói prompt pedig: "Explain to me the Fourier equation in simple terms." További opciók között szerepel az eszközök hozzáadása, MCP Server engedélyezése és strukturált kimenet választása. Az alsó részen egy kék “Run” gomb látható. A jobb oldali panelen a "Get Started with Examples" alatt három minta ügynök szerepel: Web Developer (MCP Server-rel, Second-Grade Simplifier-rel és Dream Interpreter-rel, rövid leírásokkal).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.hu.png)

1. Nyisd meg az **AI Toolkit** bővítményt az **Activity Bar**-ból.
1. A **Tools** szekcióban válaszd ki az **Agent (Prompt) Builder**-t. Ez új szerkesztőfülön nyitja meg az **Agent (Prompt) Builder**-t.
1. Kattints a **+ New Agent** gombra. A bővítmény elindít egy beállító varázslót a **Command Palette** segítségével.
1. Írd be a nevet: **Calculator Agent**, majd nyomj **Enter**-t.
1. Az **Agent (Prompt) Builder**-ben a **Model** mezőnél válaszd ki az **OpenAI GPT-4o (via GitHub)** modellt.

### -2- Rendszer prompt létrehozása az ügynöknek

Miután az ügynök alapjai megvannak, ideje meghatározni a személyiségét és célját. Ebben a részben a **Generate system prompt** funkciót használod, hogy leírd az ügynök szándékolt viselkedését — jelen esetben egy számológép ügynököt —, és a modell megírja helyetted a rendszer promptot.

![Képernyőkép a "Calculator Agent" felületről az AI Toolkit-ben a Visual Studio Code-ban, egy "Generate a prompt" nevű modális ablak nyitva. Az ablak elmagyarázza, hogy egy prompt sablon generálható alapadatok megadásával, és egy szövegdobozban minta rendszer prompt látható: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Az ablak alatt "Close" és "Generate" gombok vannak. A háttérben részben látható az ügynök konfigurációja, a kiválasztott modell "OpenAI GPT-4o (via GitHub)" és a rendszer, illetve felhasználói prompt mezők.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.hu.png)

1. A **Prompts** szekcióban kattints a **Generate system prompt** gombra. Ez megnyitja a prompt építőt, amely AI segítségével generálja az ügynök rendszer promptját.
1. A **Generate a prompt** ablakban írd be a következőt: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kattints a **Generate** gombra. Egy értesítés jelenik meg a jobb alsó sarokban, amely megerősíti, hogy a rendszer prompt generálása folyamatban van. Amint kész, a prompt megjelenik az **Agent (Prompt) Builder** **System prompt** mezőjében.
1. Nézd át a **System prompt**-ot, és szükség szerint módosítsd.

### -3- MCP szerver létrehozása

Most, hogy meghatároztad az ügynök rendszer promptját — amely irányítja a viselkedését és válaszait — ideje gyakorlati képességekkel felruházni az ügynököt. Ebben a részben létrehozol egy számológép MCP szervert, amely eszközöket tartalmaz összeadás, kivonás, szorzás és osztás végrehajtásához. Ez a szerver lehetővé teszi, hogy az ügynök valós időben végezzen matematikai műveleteket természetes nyelvű kérések alapján.

![Képernyőkép a Calculator Agent felület alsó részéről az AI Toolkit bővítményben a Visual Studio Code-ban. Láthatóak a kibővíthető menük: “Tools” és “Structure output”, egy legördülő menü “Choose output format” felirattal, amely “text”-re van állítva. Jobbra egy “+ MCP Server” gomb látható egy Model Context Protocol szerver hozzáadásához. A Tools szekció felett egy kép ikon helyőrző látható.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.hu.png)

Az AI Toolkit sablonokat kínál, hogy megkönnyítse saját MCP szerver létrehozását. Mi a Python sablont fogjuk használni a számológép MCP szerver létrehozásához.

*Megjegyzés*: Az AI Toolkit jelenleg Python és TypeScript nyelvet támogat.

1. Az **Agent (Prompt) Builder** **Tools** szekciójában kattints a **+ MCP Server** gombra. A bővítmény elindít egy beállító varázslót a **Command Palette** segítségével.
1. Válaszd a **+ Add Server** opciót.
1. Válaszd a **Create a New MCP Server** lehetőséget.
1. Válaszd a **python-weather** sablont.
1. Válaszd az **Alapértelmezett mappa** mentési helynek.
1. Írd be a szerver nevét: **Calculator**
1. Egy új Visual Studio Code ablak nyílik meg. Válaszd az **Igen, megbízom a szerzőkben** opciót.
1. A terminálban (**Terminal** > **New Terminal**) hozz létre egy virtuális környezetet: `python -m venv .venv`
1. A terminálban aktiváld a virtuális környezetet:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. A terminálban telepítsd a függőségeket: `pip install -e .[dev]`
1. Az **Explorer** nézetben az **Activity Bar**-on belül bontsd ki a **src** könyvtárat, majd nyisd meg a **server.py** fájlt.
1. Cseréld le a **server.py** fájl tartalmát az alábbiakra, majd mentsd el:

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

### -4- Az ügynök futtatása a számológép MCP szerverrel

Most, hogy az ügynököd rendelkezik eszközökkel, itt az ideje használni őket! Ebben a részben promptokat küldesz az ügynöknek, hogy teszteld és megerősítsd, az ügynök megfelelően használja-e a számológép MCP szerver eszközeit.

![Képernyőkép a Calculator Agent felületről az AI Toolkit bővítményben a Visual Studio Code-ban. A bal oldali panelen a “Tools” alatt egy MCP szerver, local-server-calculator_server hozzáadva, négy elérhető eszközzel: add, subtract, multiply és divide. Egy jelvény mutatja, hogy négy eszköz aktív. Alatta összehajtható “Structure output” rész és egy kék “Run” gomb látható. A jobb oldali panelen a “Model Response” alatt az ügynök meghívja a multiply és subtract eszközöket a bemenetekkel {"a": 3, "b": 25} és {"a": 75, "b": 20}. A végső “Tool Response” 75.0. Az alján “View Code” gomb látható.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.hu.png)

Az MCP klienseként az **Agent Builder**-en keresztül futtatod a számológép MCP szervert a helyi fejlesztői gépeden.

1. Nyomd meg az `F5`-öt` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Vettem 3 darab terméket, darabonként 25 dollárért, majd használtam egy 20 dolláros kedvezményt. Mennyiért fizettem?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` értékeket rendelnek a **subtract** eszközhöz.
    - Minden eszköz válasza megjelenik a hozzá tartozó **Tool Response** mezőben.
    - A modell végső válasza a **Model Response** mezőben látható.
1. Küldj további promptokat az ügynök teszteléséhez. A meglévő promptot módosíthatod a **User prompt** mezőbe kattintva és a szöveg lecserélésével.
1. Ha befejezted az ügynök tesztelését, leállíthatod a szervert a **terminálban** a **CTRL/CMD+C** billentyűkombinációval.

## Feladat

Próbálj meg egy újabb eszközt hozzáadni a **server.py** fájlhoz (például számítsd ki egy szám négyzetgyökét). Küldj olyan promptokat, amelyek az új eszköz használatát igénylik (vagy a meglévő eszközökét). Ne felejtsd el újraindítani a szervert, hogy az új eszközök betöltődjenek.

## Megoldás

[Solution](./solution/README.md)

## Főbb tanulságok

A fejezet legfontosabb tanulságai:

- Az AI Toolkit bővítmény remek kliens, amely lehetővé teszi MCP szerverek és eszközeik használatát.
- Új eszközöket adhatsz hozzá az MCP szerverekhez, bővítve az ügynök képességeit az igények változásával.
- Az AI Toolkit sablonokat tartalmaz (például Python MCP szerver sablonokat), hogy megkönnyítse egyedi eszközök létrehozását.

## További források

- [AI Toolkit dokumentáció](https://aka.ms/AIToolkit/doc)

## Mi következik
- Következő: [Tesztelés és hibakeresés](/03-GettingStarted/08-testing/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy félreértelmezésekért.