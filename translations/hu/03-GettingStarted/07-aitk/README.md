<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98bcd044860716da5819e31c152813b7",
<<<<<<< HEAD
  "translation_date": "2025-08-18T19:33:04+00:00",
=======
  "translation_date": "2025-08-18T14:40:57+00:00",
>>>>>>> origin/main
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "hu"
}
-->
<<<<<<< HEAD
# AI Toolkit bővítmény használata Visual Studio Code-ban egy szerver fogyasztásához

Amikor AI ügynököt építesz, nem csak az okos válaszok generálásáról van szó; az is fontos, hogy az ügynök képes legyen cselekedni. Itt jön képbe a Model Context Protocol (MCP). Az MCP lehetővé teszi, hogy az ügynökök külső eszközökhöz és szolgáltatásokhoz férjenek hozzá egységes módon. Gondolj rá úgy, mintha az ügynöködet egy olyan szerszámosládához csatlakoztatnád, amit *valójában* használni tud.

Tegyük fel, hogy csatlakoztatsz egy ügynököt a számológép MCP szerveredhez. Hirtelen az ügynök képes matematikai műveleteket végrehajtani, csak egy olyan utasítás alapján, mint például: „Mennyi 47 szorozva 89-cel?”—nincs szükség hardkódolt logikára vagy egyedi API-k építésére.

## Áttekintés

Ebben a leckében megtanulod, hogyan csatlakoztass egy számológép MCP szervert egy ügynökhöz a [AI Toolkit](https://aka.ms/AIToolkit) bővítmény segítségével a Visual Studio Code-ban. Ez lehetővé teszi az ügynök számára, hogy természetes nyelven keresztül végezzen matematikai műveleteket, például összeadást, kivonást, szorzást és osztást.

Az AI Toolkit egy erőteljes bővítmény a Visual Studio Code-hoz, amely leegyszerűsíti az ügynökfejlesztést. Az AI mérnökök könnyedén építhetnek AI alkalmazásokat generatív AI modellek fejlesztésével és tesztelésével—helyben vagy a felhőben. A bővítmény támogatja a legtöbb ma elérhető generatív modellt.

*Megjegyzés*: Az AI Toolkit jelenleg Python és TypeScript nyelveket támogat.
=======
# Egy szerver használata az AI Toolkit kiterjesztésből a Visual Studio Code-ban

Amikor AI ügynököt építesz, nem csak az okos válaszok generálásáról van szó; az is fontos, hogy az ügynök képes legyen cselekedni. Itt jön képbe a Model Context Protocol (MCP). Az MCP lehetővé teszi, hogy az ügynökök külső eszközökhöz és szolgáltatásokhoz férjenek hozzá egységes módon. Gondolj rá úgy, mintha az ügynöködet egy olyan szerszámosládához csatlakoztatnád, amit *valójában* használni tud.

Tegyük fel, hogy csatlakoztatsz egy ügynököt a számológép MCP szerveredhez. Hirtelen az ügynök képes matematikai műveleteket végrehajtani, csak egy olyan utasítást kapva, mint például: „Mennyi 47 szorozva 89-cel?”—nincs szükség a logika kódolására vagy egyedi API-k létrehozására.

## Áttekintés

Ez a lecke bemutatja, hogyan lehet egy számológép MCP szervert csatlakoztatni egy ügynökhöz a [AI Toolkit](https://aka.ms/AIToolkit) kiterjesztés segítségével a Visual Studio Code-ban, lehetővé téve az ügynök számára, hogy természetes nyelven keresztül végezzen matematikai műveleteket, például összeadást, kivonást, szorzást és osztást.

Az AI Toolkit egy erőteljes kiterjesztés a Visual Studio Code-hoz, amely leegyszerűsíti az ügynökfejlesztést. Az AI mérnökök könnyedén építhetnek AI alkalmazásokat generatív AI modellek fejlesztésével és tesztelésével—helyben vagy a felhőben. A kiterjesztés támogatja a legtöbb ma elérhető generatív modellt.

*Megjegyzés*: Az AI Toolkit jelenleg a Python és TypeScript nyelveket támogatja.
>>>>>>> origin/main

## Tanulási célok

A lecke végére képes leszel:

<<<<<<< HEAD
- MCP szerver fogyasztására az AI Toolkit segítségével.
=======
- MCP szerver használatára az AI Toolkit segítségével.
>>>>>>> origin/main
- Ügynök konfigurációjának beállítására, hogy felfedezze és használja az MCP szerver által biztosított eszközöket.
- MCP eszközök használatára természetes nyelven keresztül.

## Megközelítés

<<<<<<< HEAD
Így kell megközelítenünk a feladatot magas szinten:
=======
Íme, hogyan kell magas szinten megközelíteni ezt:
>>>>>>> origin/main

- Hozz létre egy ügynököt, és határozd meg a rendszerutasítását.
- Hozz létre egy MCP szervert számológép eszközökkel.
- Csatlakoztasd az Agent Buildert az MCP szerverhez.
- Teszteld az ügynök eszközhasználatát természetes nyelven keresztül.

<<<<<<< HEAD
Nagyszerű, most, hogy megértettük a folyamatot, konfiguráljunk egy AI ügynököt, hogy MCP-n keresztül külső eszközöket használhasson, és ezzel bővítsük a képességeit!
=======
Nagyszerű, most, hogy megértettük a folyamatot, konfiguráljunk egy AI ügynököt, hogy külső eszközöket használjon az MCP segítségével, és bővítsük a képességeit!
>>>>>>> origin/main

## Előfeltételek

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

<<<<<<< HEAD
## Gyakorlat: Szerver fogyasztása

> [!WARNING]
> Megjegyzés macOS felhasználóknak. Jelenleg vizsgálunk egy problémát, amely a függőségek telepítését érinti macOS rendszeren. Ennek következtében a macOS felhasználók jelenleg nem tudják befejezni ezt az oktatóanyagot. Amint elérhető lesz a javítás, frissítjük az utasításokat. Köszönjük a türelmet és megértést!

Ebben a gyakorlatban egy AI ügynököt fogsz építeni, futtatni és bővíteni MCP szerver eszközökkel a Visual Studio Code-ban az AI Toolkit segítségével.
=======
## Gyakorlat: Egy szerver használata

> [!WARNING]
> Megjegyzés macOS felhasználóknak. Jelenleg vizsgálunk egy problémát, amely a függőségek telepítését érinti macOS-en. Ennek eredményeként a macOS felhasználók jelenleg nem tudják befejezni ezt az oktatóanyagot. Amint elérhető lesz a javítás, frissítjük az utasításokat. Köszönjük a türelmet és megértést!

Ebben a gyakorlatban egy MCP szerver eszközeivel fogsz AI ügynököt építeni, futtatni és fejleszteni a Visual Studio Code-ban az AI Toolkit segítségével.
>>>>>>> origin/main

### -0- Előkészítő lépés: Add hozzá az OpenAI GPT-4o modellt a Saját modellekhez

A gyakorlat a **GPT-4o** modellt használja. A modellt hozzá kell adni a **Saját modellek** listához, mielőtt létrehoznád az ügynököt.

<<<<<<< HEAD
![Képernyőkép a Visual Studio Code AI Toolkit bővítményének modellválasztó felületéről. A fejléc ezt írja: "Találd meg a megfelelő modellt AI megoldásodhoz," alatta pedig egy alcím bátorítja a felhasználókat, hogy fedezzék fel, teszteljék és telepítsék az AI modelleket. Lent, a “Népszerű modellek” alatt hat modellkártya látható: DeepSeek-R1 (GitHub-hostolt), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Kicsi, Gyors), és DeepSeek-R1 (Ollama-hostolt). Mindegyik kártyán van lehetőség a modell “Hozzáadására” vagy “Kipróbálására a Playgroundban.”](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.hu.png)

1. Nyisd meg az **AI Toolkit** bővítményt az **Aktivitás sávból**.
1. A **Katalógus** szekcióban válaszd a **Modellek** lehetőséget a **Modellek katalógusának** megnyitásához. A **Modellek** kiválasztása egy új szerkesztőfülön nyitja meg a **Modellek katalógusát**.
1. A **Modellek katalógusa** keresősávjába írd be: **OpenAI GPT-4o**.
1. Kattints a **+ Hozzáadás** gombra, hogy a modellt hozzáadd a **Saját modellek** listádhoz. Győződj meg róla, hogy a **GitHub által hostolt** modellt választottad ki.
=======
1. Nyisd meg az **AI Toolkit** kiterjesztést az **Aktivitás sávból**.
1. A **Katalógus** szekcióban válaszd a **Modellek** lehetőséget a **Modellek katalógusának** megnyitásához. A **Modellek** kiválasztása egy új szerkesztőfülön nyitja meg a **Modellek katalógusát**.
1. A **Modellek katalógusa** keresősávjába írd be: **OpenAI GPT-4o**.
1. Kattints a **+ Hozzáadás** gombra, hogy a modellt hozzáadd a **Saját modellek** listádhoz. Győződj meg róla, hogy a **GitHub által hosztolt** modellt választottad ki.
>>>>>>> origin/main
1. Az **Aktivitás sávban** ellenőrizd, hogy az **OpenAI GPT-4o** modell megjelenik-e a listában.

### -1- Hozz létre egy ügynököt

<<<<<<< HEAD
Az **Agent (Prompt) Builder** lehetővé teszi, hogy saját AI-alapú ügynököket hozz létre és testre szabj. Ebben a szakaszban létrehozol egy új ügynököt, és hozzárendelsz egy modellt, amely a beszélgetést vezérli.

![Képernyőkép a "Calculator Agent" építőfelületéről a Visual Studio Code AI Toolkit bővítményében. A bal oldali panelen a kiválasztott modell az "OpenAI GPT-4o (GitHubon keresztül)." Egy rendszerutasítás ezt írja: "Egyetemi professzor vagy, aki matematikát tanít," a felhasználói utasítás pedig: "Magyarázd el nekem egyszerűen a Fourier-egyenletet." További opciók: eszközök hozzáadása, MCP szerver engedélyezése, és strukturált kimenet kiválasztása. Alul egy kék “Futtatás” gomb található. A jobb oldali panelen a "Példák kezdéshez" alatt három mintaügynök szerepel: Webfejlesztő (MCP szerverrel), Másodikos egyszerűsítő, és Álomelemző, mindegyik rövid leírással.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.hu.png)

1. Nyisd meg az **AI Toolkit** bővítményt az **Aktivitás sávból**.
1. Az **Eszközök** szekcióban válaszd az **Agent (Prompt) Builder** lehetőséget. Az **Agent (Prompt) Builder** kiválasztása egy új szerkesztőfülön nyitja meg az **Agent (Prompt) Buildert**.
1. Kattints az **+ Új ügynök** gombra. A bővítmény egy beállítási varázslót indít el a **Parancspalettán** keresztül.
1. Add meg az **Ügynök neve** mezőben: **Calculator Agent**, majd nyomd meg az **Enter** gombot.
1. Az **Agent (Prompt) Builder** felületén a **Modell** mezőben válaszd ki az **OpenAI GPT-4o (GitHubon keresztül)** modellt.

### -2- Hozz létre egy rendszerutasítást az ügynök számára

Miután az ügynök alapját létrehoztad, ideje meghatározni a személyiségét és célját. Ebben a szakaszban a **Rendszerutasítás generálása** funkciót fogod használni, hogy leírd az ügynök szándékolt viselkedését—jelen esetben egy számológép ügynököt—, és a modell megírja helyetted a rendszerutasítást.

![Képernyőkép a "Calculator Agent" felületéről a Visual Studio Code AI Toolkit bővítményében, egy "Utasítás generálása" című modális ablak nyitva. A modális ablak elmagyarázza, hogy egy utasítássablon generálható alapvető részletek megosztásával, és tartalmaz egy szövegdobozt a minta rendszerutasítással: "Egy segítőkész és hatékony matematikai asszisztens vagy. Ha alapvető aritmetikai problémát kapsz, a helyes eredménnyel válaszolsz." A szövegdoboz alatt "Bezárás" és "Generálás" gombok találhatók. A háttérben az ügynök konfigurációjának egy része látható, beleértve a kiválasztott modellt "OpenAI GPT-4o (GitHubon keresztül)" és a rendszer- és felhasználói utasítás mezőket.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.hu.png)

1. Az **Utasítások** szekcióban kattints a **Rendszerutasítás generálása** gombra. Ez megnyitja az utasításépítőt, amely AI-t használ az ügynök rendszerutasításának generálásához.
1. A **Rendszerutasítás generálása** ablakban írd be a következőt: `Egy segítőkész és hatékony matematikai asszisztens vagy. Ha alapvető aritmetikai problémát kapsz, a helyes eredménnyel válaszolsz.`
1. Kattints a **Generálás** gombra. Egy értesítés jelenik meg a jobb alsó sarokban, amely megerősíti, hogy a rendszerutasítás generálása folyamatban van. Miután a generálás befejeződött, az utasítás megjelenik az **Agent (Prompt) Builder** **Rendszerutasítás** mezőjében.
1. Nézd át a **Rendszerutasítást**, és szükség esetén módosítsd.

### -3- Hozz létre egy MCP szervert

Most, hogy meghatároztad az ügynök rendszerutasítását—amely irányítja a viselkedését és válaszait—, ideje gyakorlati képességekkel felruházni. Ebben a szakaszban létrehozol egy számológép MCP szervert, amely eszközöket biztosít összeadás, kivonás, szorzás és osztás végrehajtásához. Ez a szerver lehetővé teszi az ügynök számára, hogy valós idejű matematikai műveleteket hajtson végre természetes nyelvű utasítások alapján.

!["Képernyőkép a Calculator Agent felületének alsó részéről a Visual Studio Code AI Toolkit bővítményében. Kinyitható menük láthatók az “Eszközök” és “Strukturált kimenet” szekciókhoz, valamint egy legördülő menü “Kimeneti formátum kiválasztása” címkével, amely “szöveg” értékre van állítva. Jobbra egy “+ MCP szerver” gomb található a Model Context Protocol szerver hozzáadásához. Egy képkép ikon helyőrző látható az Eszközök szekció felett.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.hu.png)

Az AI Toolkit sablonokat tartalmaz, amelyek megkönnyítik saját MCP szerver létrehozását. A számológép MCP szerver létrehozásához a Python sablont fogjuk használni.

*Megjegyzés*: Az AI Toolkit jelenleg Python és TypeScript nyelveket támogat.

1. Az **Agent (Prompt) Builder** **Eszközök** szekciójában kattints a **+ MCP szerver** gombra. A bővítmény egy beállítási varázslót indít el a **Parancspalettán** keresztül.
1. Válaszd a **+ Szerver hozzáadása** lehetőséget.
1. Válaszd a **Hozz létre egy új MCP szervert** lehetőséget.
1. Válaszd a **python-weather** sablont.
1. Válaszd a **Default folder** lehetőséget az MCP szerver sablon mentéséhez.
1. Add meg a szerver nevét: **Calculator**
=======
Az **Agent (Prompt) Builder** lehetővé teszi, hogy saját AI-alapú ügynököket hozz létre és testre szabj. Ebben a szekcióban létrehozol egy új ügynököt, és hozzárendelsz egy modellt, amely a beszélgetést vezérli.

1. Nyisd meg az **AI Toolkit** kiterjesztést az **Aktivitás sávból**.
1. Az **Eszközök** szekcióban válaszd az **Agent (Prompt) Builder** lehetőséget. Az **Agent (Prompt) Builder** kiválasztása egy új szerkesztőfülön nyitja meg az **Agent (Prompt) Buildert**.
1. Kattints az **+ Új ügynök** gombra. A kiterjesztés egy beállítási varázslót indít el a **Command Palette** segítségével.
1. Add meg a **Számológép ügynök** nevet, majd nyomd meg az **Enter** gombot.
1. Az **Agent (Prompt) Builderben** a **Modell** mezőhöz válaszd ki az **OpenAI GPT-4o (via GitHub)** modellt.

### -2- Hozz létre egy rendszerutasítást az ügynök számára

Miután az ügynök alapját létrehoztad, ideje meghatározni a személyiségét és célját. Ebben a szekcióban a **Rendszerutasítás generálása** funkciót fogod használni, hogy leírd az ügynök szándékolt viselkedését—jelen esetben egy számológép ügynökét—és a modell megírja helyetted a rendszerutasítást.

1. A **Utasítások** szekcióban kattints a **Rendszerutasítás generálása** gombra. Ez a gomb megnyitja az utasításkészítőt, amely AI-t használ a rendszerutasítás generálásához az ügynök számára.
1. A **Rendszerutasítás generálása** ablakban írd be a következőt: `Te egy segítőkész és hatékony matematikai asszisztens vagy. Ha alapvető aritmetikai problémát kapsz, a helyes eredménnyel válaszolsz.`
1. Kattints a **Generálás** gombra. Egy értesítés jelenik meg a jobb alsó sarokban, amely megerősíti, hogy a rendszerutasítás generálása folyamatban van. Miután a generálás befejeződött, az utasítás megjelenik az **Agent (Prompt) Builder** **Rendszerutasítás** mezőjében.
1. Tekintsd át a **Rendszerutasítást**, és szükség esetén módosítsd.

### -3- Hozz létre egy MCP szervert

Most, hogy meghatároztad az ügynök rendszerutasítását—amely irányítja a viselkedését és válaszait—, ideje gyakorlati képességekkel felruházni. Ebben a szekcióban létrehozol egy számológép MCP szervert, amely eszközöket biztosít összeadás, kivonás, szorzás és osztás végrehajtásához. Ez a szerver lehetővé teszi az ügynök számára, hogy valós idejű matematikai műveleteket hajtson végre természetes nyelvű utasításokra válaszul.

Az AI Toolkit sablonokkal van felszerelve, amelyek megkönnyítik saját MCP szerver létrehozását. A számológép MCP szerver létrehozásához a Python sablont fogjuk használni.

*Megjegyzés*: Az AI Toolkit jelenleg a Python és TypeScript nyelveket támogatja.

1. Az **Agent (Prompt) Builder** **Eszközök** szekciójában kattints a **+ MCP szerver** gombra. A kiterjesztés egy beállítási varázslót indít el a **Command Palette** segítségével.
1. Válaszd a **+ Szerver hozzáadása** lehetőséget.
1. Válaszd az **Új MCP szerver létrehozása** lehetőséget.
1. Válaszd a **python-weather** sablont.
1. Válaszd az **Alapértelmezett mappa** lehetőséget az MCP szerver sablon mentéséhez.
1. Add meg a következő nevet a szervernek: **Számológép**
>>>>>>> origin/main
1. Egy új Visual Studio Code ablak nyílik meg. Válaszd a **Yes, I trust the authors** lehetőséget.
1. A terminálban (**Terminál** > **Új terminál**) hozz létre egy virtuális környezetet: `python -m venv .venv`
1. A terminálban aktiváld a virtuális környezetet:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source .venv/bin/activate`
1. A terminálban telepítsd a függőségeket: `pip install -e .[dev]`
<<<<<<< HEAD
1. Az **Aktivitás sáv** **Explorer** nézetében bontsd ki a **src** könyvtárat, és válaszd a **server.py** fájlt, hogy megnyisd a szerkesztőben.
=======
1. Az **Aktivitás sáv** **Felfedező** nézetében bontsd ki a **src** könyvtárat, és válaszd ki a **server.py** fájlt, hogy megnyisd a szerkesztőben.
>>>>>>> origin/main
1. Cseréld ki a **server.py** fájl kódját a következőre, majd mentsd el:

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

### -4- Futtasd az ügynököt a számológép MCP szerverrel

<<<<<<< HEAD
Most, hogy az ügynököd rendelkezik eszközökkel, ideje használni őket! Ebben a szakaszban utasításokat küldesz az ügynöknek, hogy teszteld és ellenőrizd, vajon az ügynök megfelelően használja-e a számológép MCP szerver eszközeit.

![Képernyőkép a Calculator Agent felületéről a Visual Studio Code AI Toolkit bővítményében. A bal oldali panelen az “Eszközök” alatt egy MCP szerver neve: local-server-calculator_server, amely négy elérhető eszközt mutat: add, subtract, multiply, és divide. Egy jelvény mutatja, hogy négy eszköz aktív. Alatta egy összecsukott “Strukturált kimenet” szekció és egy kék “Futtatás” gomb található. A jobb oldali panelen a “Modell válasza” alatt az ügynök a multiply és subtract eszközöket hívja meg a {"a": 3, "b": 25} és {"a": 75, "b": 20} bemenetekkel. A végső “Eszköz válasza” 75.0. Alul egy “Kód megtekintése” gomb látható.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.hu.png)

Az MCP szervert a helyi fejlesztői gépeden fogod futtatni az **Agent Builder** segítségével, mint MCP kliens.

1. Nyomd meg az `F5` gombot az MCP szerver hibakeresésének elindításához. Az **Agent (Prompt) Builder** egy új szerkesztőfülön nyílik meg. A szerver állapota látható a terminálban.
1. Az **Agent (Prompt) Builder** **Felhasználói utasítás** mezőjébe írd be a következő utasítást: `Vettem 3 darab, darabonként 25 dollárba kerülő terméket, majd felhasználtam egy 20 dolláros kedvezményt. Mennyit fizettem?`
1. Kattints a **Futtatás** gombra az ügynök válaszának generálásához.
1. Nézd át az ügynök kimenetét. A modellnek arra kell következtetnie, hogy **55 dollárt** fizettél.
1. Íme, mi történik:
    - Az ügynök kiválasztja a **multiply** és **subtract** eszközöket a számítás segítésére.
    - A megfelelő `a` és `b` értékek hozzárendelődnek a **multiply** eszközhöz.
    - A megfelelő `a` és `b` értékek hozzárendelődnek a **subtract** eszközhöz.
    - Az egyes eszközök válaszai megj
=======
Most, hogy az ügynököd rendelkezik eszközökkel, ideje használni őket! Ebben a szekcióban utasításokat küldesz az ügynöknek, hogy teszteld és ellenőrizd, vajon az ügynök megfelelően használja-e a számológép MCP szerver eszközeit.

1. Nyomd meg az `F5` gombot az MCP szerver hibakeresésének elindításához. Az **Agent (Prompt) Builder** egy új szerkesztőfülön nyílik meg. A szerver állapota látható a terminálban.
1. Az **Agent (Prompt) Builder** **Felhasználói utasítás** mezőjébe írd be a következő utasítást: `Vettem 3 darab 25 dolláros terméket, majd felhasználtam egy 20 dolláros kedvezményt. Mennyit fizettem?`
1. Kattints a **Futtatás** gombra az ügynök válaszának generálásához.
1. Tekintsd át az ügynök kimenetét. A modellnek arra kell következtetnie, hogy **55 dollárt** fizettél.
1. Íme, mi történik:
    - Az ügynök kiválasztja a **szorzás** és **kivonás** eszközöket a számítás elvégzéséhez.
    - A megfelelő `a` és `b` értékek hozzárendelődnek a **szorzás** eszközhöz.
    - A megfelelő `a` és `b` értékek hozzárendelődnek a **kivonás** eszközhöz.
    - Az egyes eszközök válaszai megjelennek a megfelelő **Eszköz válasz** mezőben.
    - A modell végső kimenete megjelenik a **Modell válasz** mezőben.
1. Küldj be további utasításokat az ügynök további teszteléséhez. Az **Felhasználói utasítás** mezőben módosíthatod a meglévő utasítást, ha rákattintasz a mezőre, és lecseréled a meglévő szöveget.
1. Miután befejezted az ügynök tesztelését, a **terminálban** a **CTRL/CMD+C** megadásával leállíthatod a szervert.

## Feladat

Próbálj meg egy további eszközt hozzáadni a **server.py** fájlodhoz (például: egy szám négyzetgyökének visszaadása). Küldj be további utasításokat, amelyek megkövetelik az ügynöktől az új eszköz (vagy meglévő eszközök) használatát. Ne felejtsd el újraindítani a szervert az újonnan hozzáadott eszközök betöltéséhez.

## Megoldás

[Megoldás](./solution/README.md)

## Főbb tanulságok

A fejezet főbb tanulságai a következők:

- Az AI Toolkit kiterjesztés egy nagyszerű kliens, amely lehetővé teszi MCP szerverek és azok eszközeinek használatát.
- Új eszközöket adhatsz hozzá MCP szerverekhez, bővítve az ügynök képességeit az új igények kielégítésére.
- Az AI Toolkit sablonokat tartalmaz (például Python MCP szerver sablonokat), amelyek egyszerűsítik az egyedi eszközök létrehozását.

## További források

- [AI Toolkit dokumentáció](https://aka.ms/AIToolkit/doc)

## Mi következik?
- Következő: [Tesztelés és hibakeresés](../08-testing/README.md)
>>>>>>> origin/main

**Felelősségkizárás**:  
Ez a dokumentum az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatás segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális, emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.