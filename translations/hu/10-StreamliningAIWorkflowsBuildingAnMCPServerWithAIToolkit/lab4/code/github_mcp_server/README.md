<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:17:07+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "hu"
}
-->
# Weather MCP Server

Ez egy minta MCP Server Pythonban, amely időjárás-eszközöket valósít meg hamis válaszokkal. Alapként használható saját MCP Serveredhez. A következő funkciókat tartalmazza:

- **Weather Tool**: Egy eszköz, amely adott hely alapján hamisított időjárási információkat szolgáltat.
- **Git Clone Tool**: Egy eszköz, amely egy git tárolót klónoz egy megadott mappába.
- **VS Code Open Tool**: Egy eszköz, amely megnyit egy mappát VS Code-ban vagy VS Code Insiders-ben.
- **Connect to Agent Builder**: Egy funkció, amely lehetővé teszi az MCP szerver csatlakoztatását az Agent Builderhez teszteléshez és hibakereséshez.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Egy funkció, amellyel az MCP Server hibakereshető az MCP Inspector segítségével.

## Kezdés a Weather MCP Server sablonnal

> **Előfeltételek**
>
> Az MCP Server futtatásához a helyi fejlesztői gépeden szükséged lesz:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (a git_clone_repo eszközhöz szükséges)
> - [VS Code](https://code.visualstudio.com/) vagy [VS Code Insiders](https://code.visualstudio.com/insiders/) (az open_in_vscode eszközhöz szükséges)
> - (*Opcionális - ha az uv-t részesíted előnyben*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Környezet előkészítése

Két megközelítés létezik a projekt környezetének beállítására. Bármelyiket választhatod az igényeid szerint.

> Megjegyzés: A virtuális környezet létrehozása után töltsd újra a VSCode-ot vagy a terminált, hogy a virtuális környezet Pythonja legyen használatban.

| Megközelítés | Lépések |
| -------- | ----- |
| `uv` használata | 1. Virtuális környezet létrehozása: `uv venv` <br>2. Futtasd a VSCode parancsot "***Python: Select Interpreter***" és válaszd ki a létrehozott virtuális környezet Pythonját <br>3. Telepítsd a függőségeket (beleértve a fejlesztői függőségeket is): `uv pip install -r pyproject.toml --extra dev` |
| `pip` használata | 1. Virtuális környezet létrehozása: `python -m venv .venv` <br>2. Futtasd a VSCode parancsot "***Python: Select Interpreter***" és válaszd ki a létrehozott virtuális környezet Pythonját <br>3. Telepítsd a függőségeket (beleértve a fejlesztői függőségeket is): `pip install -e .[dev]` |

A környezet beállítása után a szervert a helyi fejlesztői gépeden az Agent Builder segítségével, MCP kliensként indíthatod el a kezdéshez:
1. Nyisd meg a VS Code Hibakereső paneljét. Válaszd ki `Debug in Agent Builder`-t vagy nyomd meg `F5`-et az MCP szerver hibakeresésének elindításához.
2. Használd az AI Toolkit Agent Buildert a szerver tesztelésére ezzel a [prompttal](../../../../../../../../../../../open_prompt_builder). A szerver automatikusan csatlakozik az Agent Builderhez.
3. Kattints `Run`-ra a prompttal történő teszteléshez.

**Gratulálunk**! Sikeresen futtattad a Weather MCP Servert a helyi fejlesztői gépeden az Agent Builder segítségével MCP kliensként.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Mit tartalmaz a sablon

| Mappa / Fájl | Tartalom                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | VSCode fájlok a hibakereséshez                   |
| `.aitk`      | AI Toolkit konfigurációk                |
| `src`        | Az időjárás MCP szerver forráskódja   |

## Hogyan hibakeressük a Weather MCP Servert

> Megjegyzések:
> - Az [MCP Inspector](https://github.com/modelcontextprotocol/inspector) egy vizuális fejlesztői eszköz MCP szerverek teszteléséhez és hibakereséséhez.
> - Minden hibakeresési mód támogatja a töréspontokat, így töréspontokat adhatsz hozzá az eszköz megvalósítási kódjához.

## Elérhető eszközök

### Weather Tool
Az `get_weather` eszköz hamisított időjárási információkat szolgáltat egy megadott helyhez.

| Paraméter | Típus | Leírás |
| --------- | ---- | ----------- |
| `location` | string | Hely, amelyhez az időjárás lekérése történik (pl. városnév, állam, vagy koordináták) |

### Git Clone Tool
Az `git_clone_repo` eszköz egy git tárolót klónoz egy megadott mappába.

| Paraméter | Típus | Leírás |
| --------- | ---- | ----------- |
| `repo_url` | string | A klónozandó git tároló URL-je |
| `target_folder` | string | A mappa elérési útja, ahová a tárolót klónozni kell |

Az eszköz egy JSON objektumot ad vissza:
- `success`: Boolean érték, amely jelzi, hogy a művelet sikeres volt-e
- `target_folder` vagy `error`: A klónozott tároló elérési útja vagy egy hibaüzenet

### VS Code Open Tool
Az `open_in_vscode` eszköz megnyit egy mappát a VS Code vagy a VS Code Insiders alkalmazásban.

| Paraméter | Típus | Leírás |
| --------- | ---- | ----------- |
| `folder_path` | string | A megnyitandó mappa elérési útja |
| `use_insiders` | boolean (opcionális) | Hogy VS Code Insiders-t használjon-e a normál VS Code helyett |

Az eszköz egy JSON objektumot ad vissza:
- `success`: Boolean érték, amely jelzi, hogy a művelet sikeres volt-e
- `message` vagy `error`: Egy megerősítő üzenet vagy hibaüzenet

## Hibakeresési módok | Leírás | Hibakeresési lépések |
| ---------- | ----------- | --------------- |
| Agent Builder | Az MCP szerver hibakeresése az Agent Builderben az AI Toolkit segítségével. | 1. Nyisd meg a VS Code Hibakereső paneljét. Válaszd ki `Debug in Agent Builder`-t és nyomd meg `F5`-et az MCP szerver hibakeresésének elindításához.<br>2. Használd az AI Toolkit Agent Buildert a szerver tesztelésére ezzel a [prompttal](../../../../../../../../../../../open_prompt_builder). A szerver automatikusan csatlakozik az Agent Builderhez.<br>3. Kattints `Run`-ra a prompttal történő teszteléshez. |
| MCP Inspector | Az MCP szerver hibakeresése az MCP Inspector segítségével. | 1. Telepítsd a [Node.js](https://nodejs.org/)-t<br> 2. Állítsd be az Inspectort: `cd inspector` && `npm install` <br> 3. Nyisd meg a VS Code Hibakereső paneljét. Válaszd ki `Debug SSE in Inspector (Edge)` vagy `Debug SSE in Inspector (Chrome)`. Nyomd meg az F5-öt a hibakeresés elindításához.<br> 4. Amikor az MCP Inspector elindul a böngészőben, kattints a `Connect` gombra az MCP szerver csatlakoztatásához.<br> 5. Ezután `List Tools`, válassz ki egy eszközt, add meg a paramétereket, és `Run Tool` a szerverkód hibakereséséhez.<br> |

## Alapértelmezett portok és testreszabások

| Hibakeresési mód | Portok | Definíciók | Testreszabások | Megjegyzés |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Szerkeszd a [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) fájlokat a portok módosításához. | Nincs |
| MCP Inspector | 3001 (Szerver); 5173 és 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Szerkeszd a [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) fájlokat a portok módosításához. | Nincs |

## Visszajelzés

Ha bármilyen visszajelzésed vagy javaslatod van ehhez a sablonhoz, kérjük, nyiss egy issue-t az [AI Toolkit GitHub tárhelyen](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.