<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:35:49+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "hu"
}
-->
# Weather MCP Server

Ez egy példa MCP Server Pythonban, amely időjárás eszközöket valósít meg hamis válaszokkal. Alapként használható a saját MCP szerveredhez. A következő funkciókat tartalmazza:

- **Weather Tool**: Egy eszköz, amely a megadott hely alapján hamis időjárási információkat szolgáltat.
- **Kapcsolódás az Agent Builderhez**: Egy funkció, amely lehetővé teszi, hogy az MCP szervert az Agent Builderhez csatlakoztasd tesztelés és hibakeresés céljából.
- **Hibakeresés a [MCP Inspector](https://github.com/modelcontextprotocol/inspector) segítségével**: Egy funkció, amellyel az MCP szervert az MCP Inspector használatával hibakeresheted.

## Kezdés a Weather MCP Server sablonnal

> **Előfeltételek**
>
> Az MCP Server futtatásához a helyi fejlesztői gépeden szükséged lesz:
>
> - [Python](https://www.python.org/)
> - (*Opcionális - ha az uv-t preferálod*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger bővítmény](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Környezet előkészítése

Kétféle módon állíthatod be a projekt környezetét. Válaszd ki a számodra szimpatikusabbat.

> Megjegyzés: A virtuális környezet létrehozása után töltsd újra a VSCode-ot vagy a terminált, hogy a virtuális környezet Pythonja legyen használatban.

| Módszer | Lépések |
| -------- | ----- |
| `uv` használata | 1. Hozz létre virtuális környezetet: `uv venv` <br>2. Futtasd a VSCode parancsot "***Python: Select Interpreter***", és válaszd ki a létrehozott virtuális környezet Pythonját <br>3. Telepítsd a függőségeket (beleértve a fejlesztői függőségeket is): `uv pip install -r pyproject.toml --extra dev` |
| `pip` használata | 1. Hozz létre virtuális környezetet: `python -m venv .venv` <br>2. Futtasd a VSCode parancsot "***Python: Select Interpreter***", és válaszd ki a létrehozott virtuális környezet Pythonját<br>3. Telepítsd a függőségeket (beleértve a fejlesztői függőségeket is): `pip install -e .[dev]` |

A környezet beállítása után a helyi fejlesztői gépeden az Agent Builder segítségével futtathatod a szervert MCP kliensként a kezdéshez:
1. Nyisd meg a VS Code Hibakereső panelt. Válaszd ki `Debug in Agent Builder`-ot vagy nyomd meg `F5`-et az MCP szerver hibakeresésének indításához.
2. Használd az AI Toolkit Agent Buildert a szerver teszteléséhez ezzel a [prompttal](../../../../../../../../../../../open_prompt_builder). A szerver automatikusan csatlakozik az Agent Builderhez.
3. Kattints `Run`-ra a szerver prompttal történő teszteléséhez.

**Gratulálunk**! Sikeresen futtattad a Weather MCP Server-t a helyi fejlesztői gépeden az Agent Builder segítségével MCP kliensként.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Mi található a sablonban

| Mappa / Fájl | Tartalom                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | VSCode fájlok a hibakereséshez                   |
| `.aitk`      | AI Toolkit konfigurációk                |
| `src`        | Az időjárás MCP szerver forráskódja   |

## Hogyan hibakeressük a Weather MCP Server-t

> Megjegyzések:
> - A [MCP Inspector](https://github.com/modelcontextprotocol/inspector) egy vizuális fejlesztői eszköz az MCP szerverek teszteléséhez és hibakereséséhez.
> - Minden hibakeresési mód támogatja a töréspontokat, így hozzáadhatsz töréspontokat az eszköz implementációs kódjához.

| Hibakeresési mód | Leírás | Hibakeresési lépések |
| ---------- | ----------- | --------------- |
| Agent Builder | Hibakeresés az Agent Builderben az AI Toolkit segítségével. | 1. Nyisd meg a VS Code Hibakereső panelt. Válaszd ki `Debug in Agent Builder`-ot és nyomd meg `F5`-et az MCP szerver hibakeresésének indításához.<br>2. Használd az AI Toolkit Agent Buildert a szerver teszteléséhez ezzel a [prompttal](../../../../../../../../../../../open_prompt_builder). A szerver automatikusan csatlakozik az Agent Builderhez.<br>3. Kattints `Run`-ra a szerver prompttal történő teszteléséhez. |
| MCP Inspector | Hibakeresés az MCP Inspector segítségével. | 1. Telepítsd a [Node.js](https://nodejs.org/)-t<br> 2. Állítsd be az Inspectort: `cd inspector` && `npm install` <br> 3. Nyisd meg a VS Code Hibakereső panelt. Válaszd ki `Debug SSE in Inspector (Edge)`-et vagy `Debug SSE in Inspector (Chrome)`-at. Nyomd meg az F5-öt a hibakeresés indításához.<br> 4. Amikor az MCP Inspector elindul a böngészőben, kattints a `Connect` gombra az MCP szerver csatlakoztatásához.<br> 5. Ezután `List Tools`, válassz ki egy eszközt, add meg a paramétereket, és `Run Tool` a szerverkód hibakereséséhez.<br> |

## Alapértelmezett portok és testreszabások

| Hibakeresési mód | Portok | Definíciók | Testreszabások | Megjegyzés |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Szerkeszd a [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) fájlokat a portok módosításához. | N/A |
| MCP Inspector | 3001 (szerver); 5173 és 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Szerkeszd a [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) fájlokat a portok módosításához.| N/A |

## Visszajelzés

Ha bármilyen visszajelzésed vagy javaslatod van ehhez a sablonhoz, kérjük, nyiss egy issue-t az [AI Toolkit GitHub tárházában](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.