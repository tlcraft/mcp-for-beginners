<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T09:02:08+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "hu"
}
-->
# Weather MCP Server

Ez egy példa MCP Server Pythonban, amely időjárás eszközöket valósít meg hamis válaszokkal. Használható kiindulópontként a saját MCP Serveredhez. A következő funkciókat tartalmazza:

- **Weather Tool**: Egy eszköz, amely adott hely alapján hamisított időjárási információkat szolgáltat.
- **Git Clone Tool**: Egy eszköz, amely git tárolót klónoz egy megadott mappába.
- **VS Code Open Tool**: Egy eszköz, amely megnyit egy mappát VS Code-ban vagy VS Code Insiders-ben.
- **Kapcsolódás az Agent Builderhez**: Egy funkció, amely lehetővé teszi az MCP szerver csatlakoztatását az Agent Builderhez tesztelés és hibakeresés céljából.
- **Hibakeresés a [MCP Inspector](https://github.com/modelcontextprotocol/inspector) segítségével**: Egy funkció, amely lehetővé teszi az MCP Server hibakeresését az MCP Inspector használatával.

## Kezdés a Weather MCP Server sablonnal

> **Előfeltételek**
>
> Az MCP Server futtatásához a helyi fejlesztői gépeden szükséged lesz:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (szükséges a git_clone_repo eszközhöz)
> - [VS Code](https://code.visualstudio.com/) vagy [VS Code Insiders](https://code.visualstudio.com/insiders/) (szükséges az open_in_vscode eszközhöz)
> - (*Opcionális - ha az uv-t preferálod*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Környezet előkészítése

Kétféle módon állíthatod be a környezetet ehhez a projekthez. Válaszd ki a neked megfelelőt.

> Megjegyzés: A virtuális környezet létrehozása után töltsd újra a VSCode-ot vagy a terminált, hogy a virtuális környezet Pythonját használja.

| Módszer | Lépések |
| -------- | ----- |
| `uv` használata | 1. Hozd létre a virtuális környezetet: `uv venv` <br>2. Futtasd a VSCode parancsot "***Python: Select Interpreter***", és válaszd ki a létrehozott virtuális környezet Pythonját <br>3. Telepítsd a függőségeket (beleértve a fejlesztői függőségeket is): `uv pip install -r pyproject.toml --extra dev` |
| `pip` használata | 1. Hozd létre a virtuális környezetet: `python -m venv .venv` <br>2. Futtasd a VSCode parancsot "***Python: Select Interpreter***", és válaszd ki a létrehozott virtuális környezet Pythonját<br>3. Telepítsd a függőségeket (beleértve a fejlesztői függőségeket is): `pip install -e .[dev]` |

A környezet beállítása után a szervert a helyi fejlesztői gépeden az Agent Builderen keresztül, MCP kliensként futtathatod a kezdéshez:
1. Nyisd meg a VS Code Hibakereső paneljét. Válaszd a `Debug in Agent Builder` opciót, vagy nyomd meg az `F5`-öt az MCP szerver hibakeresésének elindításához.
2. Használd az AI Toolkit Agent Buildert a szerver teszteléséhez [ezzel a prompttal](../../../../../../../../../../open_prompt_builder). A szerver automatikusan csatlakozik az Agent Builderhez.
3. Kattints a `Run` gombra a prompttal való teszteléshez.

**Gratulálunk**! Sikeresen futtattad a Weather MCP Servert a helyi fejlesztői gépeden az Agent Builderen keresztül MCP kliensként.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Mi található a sablonban

| Mappa / Fájl | Tartalom                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | VSCode fájlok a hibakereséshez               |
| `.aitk`      | AI Toolkit konfigurációk                      |
| `src`        | Az időjárás MCP szerver forráskódja          |

## Hogyan hibakeressük a Weather MCP Servert

> Megjegyzések:
> - A [MCP Inspector](https://github.com/modelcontextprotocol/inspector) egy vizuális fejlesztői eszköz az MCP szerverek teszteléséhez és hibakereséséhez.
> - Minden hibakeresési mód támogatja a töréspontokat, így hozzáadhatsz töréspontokat az eszköz megvalósítási kódjához.

## Elérhető eszközök

### Weather Tool
A `get_weather` eszköz hamisított időjárási információkat szolgáltat egy megadott helyhez.

| Paraméter | Típus | Leírás |
| --------- | ---- | ----------- |
| `location` | string | A hely, amelyhez az időjárást lekérdezzük (pl. városnév, állam vagy koordináták) |

### Git Clone Tool
A `git_clone_repo` eszköz egy git tárolót klónoz egy megadott mappába.

| Paraméter | Típus | Leírás |
| --------- | ---- | ----------- |
| `repo_url` | string | A klónozandó git tároló URL-je |
| `target_folder` | string | A mappa elérési útja, ahová a tárolót klónozni kell |

Az eszköz egy JSON objektumot ad vissza:
- `success`: Boolean, amely jelzi, hogy a művelet sikeres volt-e
- `target_folder` vagy `error`: A klónozott tároló elérési útja vagy egy hibaüzenet

### VS Code Open Tool
Az `open_in_vscode` eszköz megnyit egy mappát a VS Code vagy VS Code Insiders alkalmazásban.

| Paraméter | Típus | Leírás |
| --------- | ---- | ----------- |
| `folder_path` | string | A megnyitandó mappa elérési útja |
| `use_insiders` | boolean (opcionális) | Használja-e a VS Code Insiders-t a sima VS Code helyett |

Az eszköz egy JSON objektumot ad vissza:
- `success`: Boolean, amely jelzi, hogy a művelet sikeres volt-e
- `message` vagy `error`: Egy megerősítő üzenet vagy hibaüzenet

## Hibakeresési módok | Leírás | Hibakeresési lépések |
| ---------- | ----------- | --------------- |
| Agent Builder | Az MCP szerver hibakeresése az Agent Builderen keresztül az AI Toolkit segítségével. | 1. Nyisd meg a VS Code Hibakereső paneljét. Válaszd a `Debug in Agent Builder` opciót, és nyomd meg az `F5`-öt az MCP szerver hibakeresésének elindításához.<br>2. Használd az AI Toolkit Agent Buildert a szerver teszteléséhez [ezzel a prompttal](../../../../../../../../../../open_prompt_builder). A szerver automatikusan csatlakozik az Agent Builderhez.<br>3. Kattints a `Run` gombra a prompttal való teszteléshez. |
| MCP Inspector | Az MCP szerver hibakeresése az MCP Inspector segítségével. | 1. Telepítsd a [Node.js](https://nodejs.org/)-t<br> 2. Állítsd be az Inspectort: `cd inspector` && `npm install` <br> 3. Nyisd meg a VS Code Hibakereső paneljét. Válaszd a `Debug SSE in Inspector (Edge)` vagy `Debug SSE in Inspector (Chrome)` opciót. Nyomd meg az F5-öt a hibakeresés elindításához.<br> 4. Amikor az MCP Inspector elindul a böngészőben, kattints a `Connect` gombra az MCP szerver csatlakoztatásához.<br> 5. Ezután használhatod a `List Tools` funkciót, választhatsz eszközt, megadhatod a paramétereket, és a `Run Tool` segítségével hibakeresheted a szerver kódját.<br> |

## Alapértelmezett portok és testreszabások

| Hibakeresési mód | Portok | Definíciók | Testreszabások | Megjegyzés |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Szerkeszd a [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) fájlokat a portok módosításához. | Nincs |
| MCP Inspector | 3001 (Szerver); 5173 és 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Szerkeszd a [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) fájlokat a portok módosításához. | Nincs |

## Visszajelzés

Ha bármilyen visszajelzésed vagy javaslatod van ehhez a sablonhoz, kérjük, nyiss egy issue-t az [AI Toolkit GitHub tárházában](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.