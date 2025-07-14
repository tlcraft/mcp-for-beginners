<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T09:04:33+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "sl"
}
-->
# Weather MCP Server

To je primer MCP strežnika v Pythonu, ki implementira vremenska orodja z lažnimi odgovori. Uporabite ga lahko kot osnovo za svoj lasten MCP strežnik. Vključuje naslednje funkcije:

- **Weather Tool**: Orodje, ki zagotavlja lažne vremenske informacije glede na podano lokacijo.
- **Git Clone Tool**: Orodje, ki klonira git repozitorij v določeno mapo.
- **VS Code Open Tool**: Orodje, ki odpre mapo v VS Code ali VS Code Insiders.
- **Povezava z Agent Builderjem**: Funkcija, ki omogoča povezavo MCP strežnika z Agent Builderjem za testiranje in odpravljanje napak.
- **Odpravljanje napak v [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Funkcija, ki omogoča odpravljanje napak MCP strežnika z uporabo MCP Inspectorja.

## Začnite z Weather MCP Server predlogo

> **Pogoji**
>
> Za zagon MCP strežnika na lokalnem razvojnem računalniku potrebujete:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (potrebno za orodje git_clone_repo)
> - [VS Code](https://code.visualstudio.com/) ali [VS Code Insiders](https://code.visualstudio.com/insiders/) (potrebno za orodje open_in_vscode)
> - (*Neobvezno - če raje uporabljate uv*) [uv](https://github.com/astral-sh/uv)
> - [Razširitev za Python Debugger](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Priprava okolja

Za nastavitev okolja za ta projekt obstajata dva pristopa. Izberete lahko tistega, ki vam bolj ustreza.

> Opomba: Ponovno naložite VSCode ali terminal, da zagotovite uporabo pythona iz virtualnega okolja po njegovi ustvaritvi.

| Pristop | Koraki |
| -------- | ----- |
| Uporaba `uv` | 1. Ustvarite virtualno okolje: `uv venv` <br>2. Zaženite ukaz v VSCode "***Python: Select Interpreter***" in izberite python iz ustvarjenega virtualnega okolja <br>3. Namestite odvisnosti (vključno z razvojnimi): `uv pip install -r pyproject.toml --extra dev` |
| Uporaba `pip` | 1. Ustvarite virtualno okolje: `python -m venv .venv` <br>2. Zaženite ukaz v VSCode "***Python: Select Interpreter***" in izberite python iz ustvarjenega virtualnega okolja<br>3. Namestite odvisnosti (vključno z razvojnimi): `pip install -e .[dev]` |

Po nastavitvi okolja lahko strežnik zaženete na lokalnem razvojnem računalniku preko Agent Builderja kot MCP klienta, da začnete:
1. Odprite razdelek za odpravljanje napak v VS Code. Izberite `Debug in Agent Builder` ali pritisnite `F5` za začetek odpravljanja napak MCP strežnika.
2. Uporabite AI Toolkit Agent Builder za testiranje strežnika z [tem pozivom](../../../../../../../../../../open_prompt_builder). Strežnik bo samodejno povezan z Agent Builderjem.
3. Kliknite `Run` za testiranje strežnika s pozivom.

**Čestitke**! Uspešno ste zagnali Weather MCP Server na svojem lokalnem razvojnem računalniku preko Agent Builderja kot MCP klienta.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Kaj je vključeno v predlogo

| Mapa / Datoteka | Vsebina                                     |
| --------------- | -------------------------------------------- |
| `.vscode`       | Datoteke za odpravljanje napak v VSCode     |
| `.aitk`         | Konfiguracije za AI Toolkit                   |
| `src`           | Izvorna koda za weather mcp strežnik         |

## Kako odpraviti napake v Weather MCP Serverju

> Opombe:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) je vizualno orodje za razvijalce za testiranje in odpravljanje napak MCP strežnikov.
> - Vsi načini odpravljanja napak podpirajo točke prekinitve, zato lahko dodate točke prekinitve v kodo orodja.

## Na voljo orodja

### Weather Tool
Orodje `get_weather` zagotavlja lažne vremenske informacije za določeno lokacijo.

| Parameter | Tip | Opis |
| --------- | --- | ----- |
| `location` | niz | Lokacija, za katero želite pridobiti vreme (npr. ime mesta, država ali koordinate) |

### Git Clone Tool
Orodje `git_clone_repo` klonira git repozitorij v določeno mapo.

| Parameter | Tip | Opis |
| --------- | --- | ----- |
| `repo_url` | niz | URL git repozitorija, ki ga želite klonirati |
| `target_folder` | niz | Pot do mape, kamor naj se repozitorij klonira |

Orodje vrne JSON objekt z:
- `success`: Boolean, ki označuje, ali je bila operacija uspešna
- `target_folder` ali `error`: Pot do kloniranega repozitorija ali sporočilo o napaki

### VS Code Open Tool
Orodje `open_in_vscode` odpre mapo v aplikaciji VS Code ali VS Code Insiders.

| Parameter | Tip | Opis |
| --------- | --- | ----- |
| `folder_path` | niz | Pot do mape, ki jo želite odpreti |
| `use_insiders` | boolean (neobvezno) | Ali uporabiti VS Code Insiders namesto običajnega VS Code |

Orodje vrne JSON objekt z:
- `success`: Boolean, ki označuje, ali je bila operacija uspešna
- `message` ali `error`: Potrdilno sporočilo ali sporočilo o napaki

## Načini odpravljanja napak | Opis | Koraki za odpravljanje napak |
| ------------------------- | ----------- | ---------------------------- |
| Agent Builder | Odpravljanje napak MCP strežnika v Agent Builderju preko AI Toolkit. | 1. Odprite razdelek za odpravljanje napak v VS Code. Izberite `Debug in Agent Builder` in pritisnite `F5` za začetek odpravljanja napak MCP strežnika.<br>2. Uporabite AI Toolkit Agent Builder za testiranje strežnika z [tem pozivom](../../../../../../../../../../open_prompt_builder). Strežnik bo samodejno povezan z Agent Builderjem.<br>3. Kliknite `Run` za testiranje strežnika s pozivom. |
| MCP Inspector | Odpravljanje napak MCP strežnika z uporabo MCP Inspectorja. | 1. Namestite [Node.js](https://nodejs.org/)<br> 2. Nastavite Inspector: `cd inspector` && `npm install` <br> 3. Odprite razdelek za odpravljanje napak v VS Code. Izberite `Debug SSE in Inspector (Edge)` ali `Debug SSE in Inspector (Chrome)`. Pritisnite F5 za začetek odpravljanja napak.<br> 4. Ko se MCP Inspector zažene v brskalniku, kliknite gumb `Connect` za povezavo tega MCP strežnika.<br> 5. Nato lahko `List Tools`, izberete orodje, vnesete parametre in `Run Tool` za odpravljanje napak vaše kode strežnika.<br> |

## Privzeti porti in prilagoditve

| Način odpravljanja napak | Porti | Definicije | Prilagoditve | Opomba |
| ------------------------ | ----- | ---------- | ------------ | ------ |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Uredite [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) za spremembo zgornjih portov. | N/A |
| MCP Inspector | 3001 (strežnik); 5173 in 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Uredite [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) za spremembo zgornjih portov. | N/A |

## Povratne informacije

Če imate kakršnekoli povratne informacije ali predloge za to predlogo, prosimo, odprite zadevo na [AI Toolkit GitHub repozitoriju](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.