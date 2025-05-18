<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:28:09+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "hu"
}
-->
# AI Toolkit bővítmény használata Visual Studio Code-ban egy szerver fogyasztásához

Amikor AI ügynököt építesz, nem csak az okos válaszok generálásáról van szó; az ügynöknek képesnek kell lennie cselekvésre is. Itt jön képbe a Model Context Protocol (MCP). Az MCP megkönnyíti az ügynökök számára, hogy következetesen hozzáférjenek külső eszközökhöz és szolgáltatásokhoz. Gondolj rá úgy, mintha az ügynököt egy olyan szerszámosláda csatlakoztatnád, amit *valóban* használhat.

Tegyük fel, hogy egy ügynököt csatlakoztatsz a kalkulátor MCP szerverhez. Hirtelen az ügynök képes matematikai műveleteket végrehajtani, csak úgy, hogy kap egy felkérést, mint például „Mennyi 47 szorozva 89-cel?” — nincs szükség a logika kemény kódolására vagy egyedi API-k építésére.

## Áttekintés

Ez a lecke arról szól, hogyan lehet csatlakoztatni egy kalkulátor MCP szervert egy ügynökhöz az [AI Toolkit](https://aka.ms/AIToolkit) bővítménnyel a Visual Studio Code-ban, lehetővé téve az ügynök számára, hogy matematikai műveleteket hajtson végre, mint például összeadás, kivonás, szorzás és osztás természetes nyelven keresztül.

Az AI Toolkit egy erőteljes bővítmény a Visual Studio Code-hoz, amely megkönnyíti az ügynök fejlesztést. Az AI mérnökök könnyedén építhetnek AI alkalmazásokat generatív AI modellek fejlesztésével és tesztelésével — helyben vagy a felhőben. A bővítmény támogatja a legtöbb ma elérhető generatív modellt.

*Megjegyzés*: Az AI Toolkit jelenleg támogatja a Python és TypeScript nyelveket.

## Tanulási célok

A lecke végére képes leszel:

- MCP szervert fogyasztani az AI Toolkit segítségével.
- Konfigurálni egy ügynök konfigurációt, hogy felfedezze és használja az MCP szerver által biztosított eszközöket.
- MCP eszközöket használni természetes nyelven keresztül.

## Megközelítés

Így kell megközelítenünk ezt magas szinten:

- Hozz létre egy ügynököt és határozd meg a rendszer felkérését.
- Hozz létre egy MCP szervert kalkulátor eszközökkel.
- Csatlakoztasd az Agent Builder-t az MCP szerverhez.
- Teszteld az ügynök eszköz hívását természetes nyelven keresztül.

Nagyszerű, most, hogy megértettük a folyamatot, konfiguráljunk egy AI ügynököt, hogy külső eszközöket használjon az MCP-n keresztül, növelve a képességeit!

## Előfeltételek

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## Gyakorlat: Szerver fogyasztása

Ebben a gyakorlatban építesz, futtatsz és fejlesztesz egy AI ügynököt MCP szerver eszközökkel a Visual Studio Code-ban az AI Toolkit segítségével.

### -0- Előlépés, add hozzá az OpenAI GPT-4o modellt a Saját Modellekhez

A gyakorlat a **GPT-4o** modellt használja. A modellt hozzá kell adni a **Saját Modellekhez**, mielőtt létrehoznád az ügynököt.

1. Nyisd meg az **AI Toolkit** bővítményt az **Aktivitás sávból**.
1. A **Katalógus** részben válaszd a **Modellek** lehetőséget a **Modellek Katalógusának** megnyitásához. A **Modellek** kiválasztása új szerkesztő lapban nyitja meg a **Modellek Katalógusát**.
1. A **Modellek Katalógus** keresősávjában írd be **OpenAI GPT-4o**.
1. Kattints a **+ Hozzáadás** gombra, hogy hozzáadd a modellt a **Saját Modellek** listádhoz. Győződj meg róla, hogy a **GitHub által hosztolt** modellt választottad.
1. Az **Aktivitás sávban** erősítsd meg, hogy az **OpenAI GPT-4o** modell megjelenik a listában.

### -1- Ügynök létrehozása

Az **Agent (Prompt) Builder** lehetővé teszi saját AI-alapú ügynökök létrehozását és testreszabását. Ebben a részben létrehozol egy új ügynököt és hozzárendelsz egy modellt a beszélgetés meghajtásához.

1. Nyisd meg az **AI Toolkit** bővítményt az **Aktivitás sávból**.
1. Az **Eszközök** részben válaszd az **Agent (Prompt) Builder** lehetőséget. Az **Agent (Prompt) Builder** kiválasztása új szerkesztő lapban nyitja meg az **Agent (Prompt) Builder**.
1. Kattints a **+ Új Builder** gombra. A bővítmény egy beállító varázslót indít a **Command Palette**-en keresztül.
1. Írd be a nevet **Calculator Agent** és nyomd meg az **Enter**-t.
1. Az **Agent (Prompt) Builder**-ben, a **Model** mezőnél válaszd az **OpenAI GPT-4o (via GitHub)** modellt.

### -2- Rendszer felkérés létrehozása az ügynök számára

Az ügynök vázának létrehozása után itt az ideje meghatározni a személyiségét és célját. Ebben a részben a **Generate system prompt** funkciót használod az ügynök szándékolt viselkedésének leírására—ebben az esetben egy kalkulátor ügynök—és a modell megírja a rendszer felkérést helyetted.

1. A **Prompts** részben kattints a **Generate system prompt** gombra. Ez a gomb megnyitja a felkérés készítőt, amely AI-t használ a rendszer felkérés generálásához az ügynök számára.
1. A **Generate a prompt** ablakban írd be a következőt: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kattints a **Generate** gombra. Egy értesítés jelenik meg a jobb alsó sarokban, megerősítve, hogy a rendszer felkérés generálása folyamatban van. Miután a felkérés generálása befejeződött, a felkérés megjelenik a **System prompt** mezőben az **Agent (Prompt) Builder**-ben.
1. Nézd át a **System prompt**-ot és szükség esetén módosítsd.

### -3- MCP szerver létrehozása

Most, hogy meghatároztad az ügynök rendszer felkérését—irányítva a viselkedését és válaszait—itt az ideje gyakorlati képességekkel felszerelni az ügynököt. Ebben a részben létrehozol egy kalkulátor MCP szervert eszközökkel az összeadás, kivonás, szorzás és osztás műveletek végrehajtására. Ez a szerver lehetővé teszi az ügynök számára, hogy valós idejű matematikai műveleteket hajtson végre természetes nyelvi felkérésekre válaszul.

Az AI Toolkit sablonokkal van felszerelve, hogy megkönnyítse saját MCP szerver létrehozását. A Python sablont fogjuk használni a kalkulátor MCP szerver létrehozásához.

*Megjegyzés*: Az AI Toolkit jelenleg támogatja a Python és TypeScript nyelveket.

1. Az **Agent (Prompt) Builder** **Eszközök** részében kattints a **+ MCP Server** gombra. A bővítmény egy beállító varázslót indít a **Command Palette**-en keresztül.
1. Válaszd a **+ Szerver hozzáadása** lehetőséget.
1. Válaszd az **Új MCP szerver létrehozása** lehetőséget.
1. Válaszd a **python-weather** sablont.
1. Válaszd az **Alapértelmezett mappa** lehetőséget az MCP szerver sablon mentéséhez.
1. Írd be a következő nevet a szerverhez: **Calculator**
1. Egy új Visual Studio Code ablak nyílik meg. Válaszd a **Igen, bízom a szerzőkben** lehetőséget.
1. A terminál (**Terminal** > **New Terminal**) használatával hozz létre egy virtuális környezetet: `python -m venv .venv`
1. A terminál használatával aktiváld a virtuális környezetet:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. A terminál használatával telepítsd a függőségeket: `pip install -e .[dev]`
1. Az **Aktivitás sáv** **Felfedező** nézetében bontsd ki a **src** könyvtárat és válaszd a **server.py** fájlt a szerkesztőben való megnyitáshoz.
1. Cseréld ki a kódot a **server.py** fájlban a következővel és mentsd el:

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

### -4- Ügynök futtatása a kalkulátor MCP szerverrel

Most, hogy az ügynök rendelkezik eszközökkel, itt az ideje használni őket! Ebben a részben felkéréseket küldesz az ügynöknek, hogy teszteld és ellenőrizd, hogy az ügynök megfelelő eszközt használ-e a kalkulátor MCP szerverből.

A kalkulátor MCP szervert a helyi fejlesztői gépeden fogod futtatni az **Agent Builder**-en keresztül MCP kliensként.

1. Nyomd meg az `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Vásároltam 3 darabot, mindegyik ára 25 dollár, majd használtam egy 20 dolláros kedvezményt. Mennyit fizettem?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` értékek vannak hozzárendelve a **subtract** eszközhöz.
    - Az egyes eszközök válasza a megfelelő **Tool Response**-ban található.
    - A modell végső kimenete a végső **Model Response**-ban található.
1. Küldj további felkéréseket az ügynök további teszteléséhez. A meglévő felkérést módosíthatod a **User prompt** mezőben, ha a mezőbe kattintasz és lecseréled a meglévő felkérést.
1. Miután befejezted az ügynök tesztelését, leállíthatod a szervert a **terminál**-on keresztül a **CTRL/CMD+C** beírásával a kilépéshez.

## Feladat

Próbálj meg hozzáadni egy további eszköz bejegyzést a **server.py** fájlodhoz (például: térjen vissza egy szám négyzetgyökével). Küldj további felkéréseket, amelyek az ügynököt a te új eszközöd (vagy meglévő eszközök) használatára kényszerítik. Ügyelj arra, hogy újraindítsd a szervert az újonnan hozzáadott eszközök betöltéséhez.

## Megoldás

[Megoldás](./solution/README.md)

## Főbb tanulságok

A fejezet tanulságai a következők:

- Az AI Toolkit bővítmény nagyszerű kliens, amely lehetővé teszi az MCP szerverek és azok eszközeinek fogyasztását.
- Új eszközöket adhatsz hozzá az MCP szerverekhez, bővítve az ügynök képességeit a fejlődő igények kielégítésére.
- Az AI Toolkit sablonokat tartalmaz (pl. Python MCP szerver sablonok), hogy megkönnyítse az egyedi eszközök létrehozását.

## További források

- [AI Toolkit dokumentáció](https://aka.ms/AIToolkit/doc)

## Mi következik

Következő: [4. lecke Gyakorlati megvalósítás](/04-PracticalImplementation/README.md)

**Felelősség kizárása**:  
Ez a dokumentum az AI fordítási szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével lett lefordítva. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Fontos információk esetén javasolt a professzionális emberi fordítás igénybevétele. Nem vállalunk felelősséget semmilyen félreértésért vagy félremagyarázásért, amely a fordítás használatából ered.