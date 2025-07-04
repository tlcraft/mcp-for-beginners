<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T18:32:45+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "hu"
}
-->
# Egy szerver használata az AI Toolkit bővítményből a Visual Studio Code-ban

Amikor AI ügynököt építesz, nem csak az okos válaszok generálása a lényeg; az is fontos, hogy az ügynök képes legyen cselekedni. Itt jön képbe a Model Context Protocol (MCP). Az MCP megkönnyíti, hogy az ügynökök egységes módon férjenek hozzá külső eszközökhöz és szolgáltatásokhoz. Olyan, mintha az ügynököd egy olyan szerszámosládához lenne csatlakoztatva, amit *valóban* használni tud.

Tegyük fel, hogy egy kalkulátor MCP szerverhez csatlakoztatod az ügynököt. Hirtelen az ügynök képes matematikai műveleteket végezni pusztán egy olyan kérés alapján, mint „Mennyi 47 szorozva 89-cel?” — nem kell előre beprogramozni a logikát vagy egyedi API-kat építeni.

## Áttekintés

Ebben a leckében azt mutatjuk be, hogyan lehet egy kalkulátor MCP szervert csatlakoztatni egy ügynökhöz az [AI Toolkit](https://aka.ms/AIToolkit) bővítmény segítségével a Visual Studio Code-ban, lehetővé téve, hogy az ügynök matematikai műveleteket végezzen, mint összeadás, kivonás, szorzás és osztás természetes nyelven keresztül.

Az AI Toolkit egy erőteljes bővítmény a Visual Studio Code-hoz, amely leegyszerűsíti az ügynökfejlesztést. AI mérnökök könnyedén építhetnek AI alkalmazásokat generatív AI modellek fejlesztésével és tesztelésével — helyben vagy a felhőben. A bővítmény támogatja a legtöbb ma elérhető jelentős generatív modellt.

*Megjegyzés*: Az AI Toolkit jelenleg Python és TypeScript nyelveket támogat.

## Tanulási célok

A lecke végére képes leszel:

- MCP szervert használni az AI Toolkit segítségével.
- Ügynök konfigurációt beállítani, hogy felfedezze és használja az MCP szerver által biztosított eszközöket.
- MCP eszközöket természetes nyelven keresztül használni.

## Megközelítés

Nagy vonalakban így haladunk:

- Ügynök létrehozása és a rendszer promptjának meghatározása.
- MCP szerver létrehozása kalkulátor eszközökkel.
- Az Agent Builder összekapcsolása az MCP szerverrel.
- Az ügynök eszközhasználatának tesztelése természetes nyelven.

Remek, most, hogy értjük a folyamatot, állítsuk be az AI ügynököt, hogy MCP-n keresztül külső eszközöket használjon, ezzel bővítve a képességeit!

## Előfeltételek

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit a Visual Studio Code-hoz](https://aka.ms/AIToolkit)

## Gyakorlat: Egy szerver használata

Ebben a gyakorlatban egy AI ügynököt építesz, futtatsz és fejlesztesz tovább egy MCP szerver eszközeivel a Visual Studio Code-ban az AI Toolkit segítségével.

### -0- Előkészítés, add hozzá az OpenAI GPT-4o modellt a Saját Modellekhez

A gyakorlat a **GPT-4o** modellt használja. A modellt hozzá kell adni a **Saját Modellek** listához, mielőtt létrehozod az ügynököt.

![Képernyőkép a modellválasztó felületről a Visual Studio Code AI Toolkit bővítményében. A fejléc így szól: "Találd meg a megfelelő modellt az AI megoldásodhoz", alatta egy alcím bátorítja a felhasználókat, hogy fedezzenek fel, teszteljenek és telepítsenek AI modelleket. Alatta a „Népszerű modellek” alatt hat modellkártya látható: DeepSeek-R1 (GitHub hosztolt), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Kicsi, Gyors), és DeepSeek-R1 (Ollama hosztolt). Minden kártyán lehetőség van a modell „Hozzáadása” vagy „Próbáld ki a Playground-ban” gombokra.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.hu.png)

1. Nyisd meg az **AI Toolkit** bővítményt az **Activity Bar**-ból.
1. A **Katalógus** szekcióban válaszd a **Modellek** menüpontot, hogy megnyisd a **Modell katalógust**. A **Modellek** kiválasztása új szerkesztőfülön nyitja meg a **Modell katalógust**.
1. A **Modell katalógus** keresőmezőjébe írd be: **OpenAI GPT-4o**.
1. Kattints a **+ Hozzáadás** gombra, hogy a modellt hozzáadd a **Saját Modellek** listához. Győződj meg róla, hogy a **GitHub által hosztolt** modellt választottad.
1. Az **Activity Bar**-ban ellenőrizd, hogy az **OpenAI GPT-4o** modell megjelenik a listában.

### -1- Ügynök létrehozása

Az **Agent (Prompt) Builder** lehetővé teszi, hogy saját AI-alapú ügynököket hozz létre és testre szabj. Ebben a részben létrehozol egy új ügynököt, és hozzárendelsz egy modellt a beszélgetéshez.

![Képernyőkép a "Calculator Agent" felépítő felületéről az AI Toolkit bővítményben a Visual Studio Code-ban. A bal oldali panelen az OpenAI GPT-4o (GitHub-on keresztül) modell van kiválasztva. Egy rendszer prompt így szól: "Te egy egyetemi professzor vagy, aki matematikát tanít," a felhasználói prompt pedig: "Magyarázd el nekem egyszerűen a Fourier-egyenletet." További opciók között szerepelnek gombok eszközök hozzáadásához, MCP szerver engedélyezéséhez és strukturált kimenet kiválasztásához. Alul egy kék „Futtatás” gomb látható. A jobb oldali panelen, a "Kezdés példákkal" alatt három minta ügynök szerepel: Webfejlesztő (MCP szerverrel, másodikos egyszerűsítővel és álomfejtővel, mindegyik rövid leírással a funkcióikról).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.hu.png)

1. Nyisd meg az **AI Toolkit** bővítményt az **Activity Bar**-ból.
1. A **Tools** szekcióban válaszd az **Agent (Prompt) Builder**-t. Ez új szerkesztőfülön nyitja meg az **Agent (Prompt) Builder**-t.
1. Kattints a **+ Új ügynök** gombra. A bővítmény elindít egy beállító varázslót a **Command Palette**-en keresztül.
1. Írd be a nevet: **Calculator Agent**, majd nyomj Entert.
1. Az **Agent (Prompt) Builder**-ben a **Model** mezőnél válaszd az **OpenAI GPT-4o (via GitHub)** modellt.

### -2- Rendszer prompt létrehozása az ügynök számára

Miután az ügynök alapjai megvannak, ideje meghatározni a személyiségét és célját. Ebben a részben a **Generate system prompt** funkciót használod, hogy leírd az ügynök kívánt viselkedését — jelen esetben egy kalkulátor ügynököt —, és a modell megírja helyetted a rendszer promptot.

![Képernyőkép a "Calculator Agent" felületről az AI Toolkit-ben a Visual Studio Code-ban, egy "Generate a prompt" nevű modális ablak nyitva. Az ablak elmagyarázza, hogy egy prompt sablon generálható alapadatok megadásával, és tartalmaz egy szövegdobozt a mintarendszer prompttal: "Te egy segítőkész és hatékony matematikai asszisztens vagy. Amikor alapvető aritmetikai problémát kapsz, helyes eredménnyel válaszolsz." Az ablak alatt "Bezárás" és "Generálás" gombok vannak. A háttérben az ügynök konfigurációjának egy része látható, beleértve a kiválasztott modellt "OpenAI GPT-4o (via GitHub)" és a rendszer- és felhasználói prompt mezőket.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.hu.png)

1. A **Prompts** szekcióban kattints a **Generate system prompt** gombra. Ez megnyitja a prompt generálót, amely AI segítségével készít rendszer promptot az ügynök számára.
1. A **Generate a prompt** ablakban írd be a következőt: `Te egy segítőkész és hatékony matematikai asszisztens vagy. Amikor alapvető aritmetikai problémát kapsz, helyes eredménnyel válaszolsz.`
1. Kattints a **Generate** gombra. A jobb alsó sarokban értesítés jelenik meg, hogy a rendszer prompt generálása folyamatban van. Amint elkészül, a prompt megjelenik az **Agent (Prompt) Builder** **System prompt** mezőjében.
1. Nézd át a **System prompt**-ot, és szükség esetén módosítsd.

### -3- MCP szerver létrehozása

Most, hogy meghatároztad az ügynök rendszer promptját — amely irányítja a viselkedését és válaszait —, ideje gyakorlati képességekkel felruházni. Ebben a részben létrehozol egy kalkulátor MCP szervert, amely eszközöket tartalmaz összeadás, kivonás, szorzás és osztás végrehajtásához. Ez a szerver lehetővé teszi, hogy az ügynök valós időben végezzen matematikai műveleteket természetes nyelvű kérésekre reagálva.

![Képernyőkép a Calculator Agent felület alsó részéről az AI Toolkit bővítményben a Visual Studio Code-ban. Láthatóak kibontható menük a „Tools” és a „Structure output” számára, valamint egy legördülő menü „Choose output format” felirattal, amely „text”-re van állítva. Jobbra egy „+ MCP Server” gomb látható egy Model Context Protocol szerver hozzáadásához. A Tools szekció felett egy kép ikon helyőrző látható.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.hu.png)

Az AI Toolkit sablonokat kínál, hogy megkönnyítse saját MCP szerver létrehozását. Mi a Python sablont fogjuk használni a kalkulátor MCP szerver elkészítéséhez.

*Megjegyzés*: Az AI Toolkit jelenleg Python és TypeScript nyelveket támogat.

1. Az **Agent (Prompt) Builder** **Tools** szekciójában kattints a **+ MCP Server** gombra. A bővítmény elindít egy beállító varázslót a **Command Palette**-en keresztül.
1. Válaszd a **+ Add Server** opciót.
1. Válaszd a **Create a New MCP Server** lehetőséget.
1. Válaszd a **python-weather** sablont.
1. Válaszd az **Alapértelmezett mappa** mentési helynek.
1. Add meg a szerver nevét: **Calculator**
1. Egy új Visual Studio Code ablak nyílik meg. Válaszd az **Igen, megbízom a szerzőkben** opciót.
1. A terminálban (**Terminal** > **New Terminal**) hozz létre egy virtuális környezetet: `python -m venv .venv`
1. A terminálban aktiváld a virtuális környezetet:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. A terminálban telepítsd a függőségeket: `pip install -e .[dev]`
1. Az **Activity Bar** **Explorer** nézetében bontsd ki a **src** mappát, és nyisd meg a **server.py** fájlt szerkesztésre.
1. Cseréld le a **server.py** fájl tartalmát az alábbi kódra, majd mentsd el:

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

### -4- Az ügynök futtatása a kalkulátor MCP szerverrel

Most, hogy az ügynököd rendelkezik eszközökkel, ideje használni őket! Ebben a részben promptokat küldesz az ügynöknek, hogy teszteld és ellenőrizd, valóban a kalkulátor MCP szerver megfelelő eszközét használja-e.

![Képernyőkép a Calculator Agent felületről az AI Toolkit bővítményben a Visual Studio Code-ban. A bal oldali panelen, a „Tools” alatt egy MCP szerver, local-server-calculator_server van hozzáadva, amely négy elérhető eszközt mutat: add, subtract, multiply és divide. Egy jelvény mutatja, hogy négy eszköz aktív. Alatta összehajtható „Structure output” szekció és egy kék „Futtatás” gomb látható. A jobb oldali panelen, a „Model Response” alatt az ügynök meghívja a multiply és subtract eszközöket a bemenetekkel {"a": 3, "b": 25} és {"a": 75, "b": 20}. A végső „Tool Response” 75.0. Alul egy „View Code” gomb látható.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.hu.png)

A kalkulátor MCP szervert a helyi fejlesztői gépeden fogod futtatni az **Agent Builder**-en keresztül MCP kliensként.

1. Nyomd meg az `F5`-öt az MCP szerver hibakeresésének elindításához. Az **Agent (Prompt) Builder** új szerkesztőfülön nyílik meg. A szerver állapota látható a terminálban.
1. Az **Agent (Prompt) Builder** **User prompt** mezőjébe írd be a következő kérést: `Vettem 3 darab terméket, darabonként 25 dollárért, majd használtam egy 20 dolláros kedvezményt. Mennyit fizettem?`
1. Kattints a **Run** gombra az ügynök válaszának generálásához.
1. Nézd át az ügynök válaszát. A modellnek arra kell következtetnie, hogy **55 dollárt** fizettél.
1. Íme, mi történik a háttérben:
    - Az ügynök kiválasztja a **multiply** és **subtract** eszközöket a számításhoz.
    - A megfelelő `a` és `b` értékek hozzárendelése megtörténik a **multiply** eszközhöz.
    - A megfelelő `a` és `b` értékek hozzárendelése megtörténik a **subtract** eszközhöz.
    - Az egyes eszközök válasza megjelenik a megfelelő **Tool Response** mezőben.
    - A modell végső válasza megjelenik a végső **Model Response** mezőben.
1. Küldj további promptokat az ügynök teszteléséhez. A meglévő promptot módosíthatod a **User prompt** mezőbe kattintva és a szöveg cseréjével.
1. Ha befejezted az ügynök tesztelését, a szervert leállíthatod a **terminálban** a **CTRL/CMD+C** billentyűkombinációval.

## Feladat

Próbálj meg egy új eszköz bejegyzést hozzáadni a **server.py** fájlodhoz (pl. számítsd ki egy szám négyzetgyökét). Küldj olyan promptokat, amelyekhez az ügynöknek használnia kell az új (vagy meglévő) eszközt. Ne felejtsd el újraindítani a szervert, hogy betöltse az új eszközöket.

## Megoldás

[Megoldás](./solution/README.md)

## Főbb tanulságok

A fejezet főbb tanulságai:

- Az AI Toolkit bővítmény remek kliens, amely lehetővé teszi MCP szerverek és eszközeik használatát.
- Új eszközöket adhatsz hozzá MCP szerverekhez,

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.