<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:48:12+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "hu"
}
-->
# Szerver használata az AI Toolkit bővítményből a Visual Studio Code-ban

Amikor AI ügynököt építesz, nem csak az okos válaszok generálása a lényeg; az ügynöknek képesnek kell lennie cselekvésre is. Ebben segít a Model Context Protocol (MCP). Az MCP megkönnyíti, hogy az ügynökök egységes módon férjenek hozzá külső eszközökhöz és szolgáltatásokhoz. Olyan, mintha az ügynököd egy olyan szerszámosládába lenne bedugva, amit *valóban* használni tud.

Tegyük fel, hogy egy ügynököt csatlakoztatsz a számológép MCP szerveredhez. Ettől az ügynök képes lesz matematikai műveleteket végezni pusztán azzal, hogy megkap egy kérdést, például: „Mi 47 szor 89?” — nem kell előre beégetett logikát vagy egyedi API-kat készítened.

## Áttekintés

Ebben a leckében azt mutatjuk be, hogyan lehet egy számológép MCP szervert csatlakoztatni egy ügynökhöz az [AI Toolkit](https://aka.ms/AIToolkit) bővítmény segítségével a Visual Studio Code-ban, így az ügynök természetes nyelven képes lesz összeadásra, kivonásra, szorzásra és osztásra.

Az AI Toolkit egy erőteljes bővítmény a Visual Studio Code-hoz, amely egyszerűsíti az ügynökök fejlesztését. AI mérnökök könnyen építhetnek AI alkalmazásokat generatív AI modellek fejlesztésével és tesztelésével — akár helyben, akár a felhőben. A bővítmény támogatja a legtöbb ma elérhető generatív modellt.

*Megjegyzés*: Az AI Toolkit jelenleg Python-t és TypeScript-et támogat.

## Tanulási célok

A lecke végére képes leszel:

- MCP szervert használni az AI Toolkit segítségével.
- Ügynök konfigurációt beállítani, hogy felfedezze és használja az MCP szerver által biztosított eszközöket.
- MCP eszközöket természetes nyelven használni.

## Megközelítés

Így közelítjük meg a feladatot nagy vonalakban:

- Hozz létre egy ügynököt és határozd meg a rendszer promptját.
- Hozz létre egy MCP szervert számológép eszközökkel.
- Csatlakoztasd az Agent Builder-t az MCP szerverhez.
- Teszteld az ügynök eszközhasználatát természetes nyelven.

Remek, most, hogy értjük a folyamatot, állítsuk be az AI ügynököt, hogy az MCP-n keresztül külső eszközöket használhasson, így bővítve a képességeit!

## Előfeltételek

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit a Visual Studio Code-hoz](https://aka.ms/AIToolkit)

## Gyakorlat: Szerver használata

Ebben a gyakorlatban egy AI ügynököt építesz, futtatsz és fejlesztesz MCP szerver eszközökkel a Visual Studio Code-ban az AI Toolkit segítségével.

### -0- Előkészítés: Add hozzá az OpenAI GPT-4o modellt a My Models listához

A gyakorlat a **GPT-4o** modellt használja. A modellt hozzá kell adni a **My Models** listához az ügynök létrehozása előtt.

![Képernyőkép a modellválasztó felületről az AI Toolkit bővítményben a Visual Studio Code-ban. A cím: „Find the right model for your AI Solution”, az alcím arra ösztönöz, hogy fedezd fel, teszteld és telepítsd az AI modelleket. Az „Popular Models” szekcióban hat modell kártya látható: DeepSeek-R1 (GitHub-hostolt), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Kicsi, Gyors), és DeepSeek-R1 (Ollama-hostolt). Mindegyik kártyán van lehetőség a modell hozzáadására vagy kipróbálására a Playground-ban.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.hu.png)

1. Nyisd meg az **AI Toolkit** bővítményt az **Activity Bar**-ból.
1. A **Catalog** szekcióban válaszd a **Models** menüpontot, ami megnyitja a **Model Catalog**-ot egy új szerkesztő fülön.
1. A **Model Catalog** keresőjébe írd be: **OpenAI GPT-4o**.
1. Kattints a **+ Add** gombra, hogy hozzáadd a modellt a **My Models** listához. Győződj meg róla, hogy a **GitHub által hosztolt** modellt választottad.
1. Az **Activity Bar**-ban ellenőrizd, hogy az **OpenAI GPT-4o** modell megjelenik a listában.

### -1- Ügynök létrehozása

Az **Agent (Prompt) Builder** lehetővé teszi, hogy saját AI alapú ügynököket hozz létre és testreszabj. Ebben a részben létrehozol egy új ügynököt, és hozzárendelsz egy modellt, amely működteti a beszélgetést.

![Képernyőkép a „Calculator Agent” felépítő felületéről az AI Toolkit bővítményben a Visual Studio Code-ban. A bal oldali panelen az OpenAI GPT-4o (GitHub-on keresztül) modell van kiválasztva. Egy rendszer prompt azt írja: „Te egy egyetemi professzor vagy, aki matematikát tanít,” a felhasználói prompt pedig: „Magyarázd el egyszerűen a Fourier-egyenletet.” További opciók között van eszközök hozzáadása, MCP szerver engedélyezése és strukturált kimenet választása. Alul egy kék „Run” gomb található. A jobb oldali panelen a „Get Started with Examples” alatt három minta ügynök látható: Web Developer (MCP Serverrel, másodikos egyszerűsítővel és álomfejtővel, mindegyik rövid leírással a funkciójukról).](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.hu.png)

1. Nyisd meg az **AI Toolkit** bővítményt az **Activity Bar**-ból.
1. A **Tools** szekcióban válaszd az **Agent (Prompt) Builder**-t, ami egy új szerkesztőfülön nyílik meg.
1. Kattints a **+ New Agent** gombra. A bővítmény elindít egy beállító varázslót a **Command Palette**-en keresztül.
1. Írd be a nevet: **Calculator Agent**, majd nyomj Entert.
1. Az **Agent (Prompt) Builder**-ben a **Model** mezőnél válaszd az **OpenAI GPT-4o (via GitHub)** modellt.

### -2- Rendszer prompt létrehozása az ügynök számára

Most, hogy az ügynök alapjai megvannak, ideje meghatározni a személyiségét és célját. Ebben a részben a **Generate system prompt** funkcióval megadhatod az ügynök kívánt viselkedését — jelen esetben egy számológép ügynököt —, és a modell megírja neked a rendszer promptot.

![Képernyőkép a „Calculator Agent” felületről az AI Toolkitben, ahol egy „Generate a prompt” nevű modális ablak nyitva van. Az ablak elmagyarázza, hogy egy prompt sablon generálható alapvető adatok megosztásával, és tartalmaz egy szövegdobozt a mintarendszer prompttal: „Te egy segítőkész és hatékony matematikai asszisztens vagy. Ha alapvető aritmetikai feladatot kapsz, helyes eredménnyel válaszolsz.” Az ablak alatt „Close” és „Generate” gombok vannak. A háttérben látható az ügynök konfigurációja a kiválasztott modellel és a prompt mezőkkel.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.hu.png)

1. A **Prompts** szekcióban kattints a **Generate system prompt** gombra. Ez megnyitja a prompt generálót, amely AI segítségével létrehozza az ügynök rendszer promptját.
1. A **Generate a prompt** ablakban írd be: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kattints a **Generate** gombra. A jobb alsó sarokban értesítés jelenik meg, hogy a rendszer prompt generálása folyamatban van. A generálás befejeztével a prompt megjelenik az **Agent (Prompt) Builder** **System prompt** mezőjében.
1. Nézd át a **System prompt**-ot, és szükség esetén módosítsd.

### -3- MCP szerver létrehozása

Most, hogy meghatároztad az ügynök rendszer promptját — amely irányítja a viselkedését és válaszait —, ideje gyakorlati képességekkel felruházni az ügynököt. Ebben a részben létrehozol egy számológép MCP szervert, amely eszközöket tartalmaz összeadás, kivonás, szorzás és osztás végrehajtására. Ez a szerver lehetővé teszi, hogy az ügynök valós időben végezzen matematikai műveleteket természetes nyelvű kérdésekre válaszolva.

![Képernyőkép a Calculator Agent felület alsó részéről az AI Toolkitben. Láthatóak a kibővíthető menük a „Tools” és a „Structure output” számára, valamint egy legördülő menü „Choose output format” felirattal, amely „text”-re van állítva. Jobbra egy „+ MCP Server” gomb van egy Model Context Protocol szerver hozzáadásához. A Tools rész fölött egy kép ikon helyőrző látható.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.hu.png)

Az AI Toolkit sablonokat kínál, hogy megkönnyítse saját MCP szerver létrehozását. A számológép MCP szerverhez a Python sablont fogjuk használni.

*Megjegyzés*: Az AI Toolkit jelenleg Python-t és TypeScript-et támogat.

1. Az **Agent (Prompt) Builder** **Tools** szekciójában kattints a **+ MCP Server** gombra. A bővítmény elindít egy beállító varázslót a **Command Palette**-en keresztül.
1. Válaszd a **+ Add Server** opciót.
1. Válaszd a **Create a New MCP Server** lehetőséget.
1. Válaszd a **python-weather** sablont.
1. Válaszd az **Alapértelmezett mappa** mentési helynek.
1. Írd be a szerver nevét: **Calculator**
1. Megnyílik egy új Visual Studio Code ablak. Válaszd a **Yes, I trust the authors** lehetőséget.
1. A terminálban (**Terminal** > **New Terminal**) hozz létre egy virtuális környezetet: `python -m venv .venv`
1. A terminálban aktiváld a virtuális környezetet:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. A terminálban telepítsd a függőségeket: `pip install -e .[dev]`
1. Az **Explorer** nézetben az **Activity Bar**-ban bontsd ki a **src** mappát, és nyisd meg a **server.py** fájlt szerkesztésre.
1. Cseréld ki a **server.py** fájl tartalmát az alábbi kódra, majd mentsd el:

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

Most, hogy az ügynököd rendelkezik eszközökkel, ideje használni őket! Ebben a részben promptokat küldesz az ügynöknek, hogy teszteld, valóban a számológép MCP szerver megfelelő eszközét használja-e.

![Képernyőkép a Calculator Agent felületről az AI Toolkit bővítményben. A bal oldali panelen a „Tools” alatt egy MCP szerver, local-server-calculator_server van hozzáadva, amely négy elérhető eszközt mutat: add, subtract, multiply és divide. Egy jelző mutatja, hogy négy eszköz aktív. Alatta egy összecsukott „Structure output” szekció és egy kék „Run” gomb látható. A jobb oldali panelen a „Model Response” alatt az ügynök meghívja a multiply és subtract eszközöket a bemenetekkel {"a": 3, "b": 25} és {"a": 75, "b": 20}. A végső „Tool Response” 75.0. Alul egy „View Code” gomb látható.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.hu.png)

A számológép MCP szervert a helyi fejlesztői gépeden fogod futtatni az **Agent Builder**-en keresztül MCP kliensként.

1. Nyomd meg az `F5`-öt, hogy elindítsd az ügynököt és az MCP klienst.
1. Próbálj ki például egy promptot: `Vettem 3 darab 25 dolláros terméket, majd használtam egy 20 dolláros kedvezményt. Mennyi az összeg, amit fizettem?` Az értékek `a` és `b` az **subtract** eszközhöz lesznek hozzárendelve.
    - Minden eszköz válasza megjelenik a megfelelő **Tool Response** mezőben.
    - A modell végső válasza a **Model Response** mezőben jelenik meg.
1. Küldj további promptokat az ügynök teszteléséhez. A **User prompt** mezőbe kattintva módosíthatod a meglévő promptot.
1. Ha végeztél az ügynök tesztelésével, a terminálban a **CTRL/CMD+C** megnyomásával állíthatod le a szervert.

## Feladat

Próbálj meg egy új eszközt hozzáadni a **server.py** fájlhoz (például számolja ki egy szám négyzetgyökét). Küldj olyan promptokat, amelyek használják az új vagy a meglévő eszközöket. Ne felejtsd el újraindítani a szervert, hogy betöltse az új eszközöket.

## Megoldás

[Solution](./solution/README.md)

## Főbb tanulságok

A fejezet legfontosabb tanulságai:

- Az AI Toolkit bővítmény kiváló kliens az MCP szerverek és eszközeik használatához.
- Új eszközöket adhatsz hozzá MCP szerverekhez, bővítve az ügynök képességeit a változó igényekhez igazodva.
- Az AI Toolkit sablonokat tartalmaz (pl. Python MCP szerver sablonok), amelyek megkönnyítik egyedi eszközök létrehozását.

## További források

- [AI Toolkit dokumentáció](https://aka.ms/AIToolkit/doc)

## Mi következik

Következő: [4. lecke: Gyakorlati megvalósítás](/04-PracticalImplementation/README.md)

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) használatával fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy téves értelmezésekért.