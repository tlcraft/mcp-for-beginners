<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:38:08+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "hr"
}
-->
# Weather MCP Server

Ovo je primjer MCP Servera u Pythonu koji implementira vremenske alate s lažnim odgovorima. Može se koristiti kao osnova za vlastiti MCP Server. Uključuje sljedeće značajke:

- **Weather Tool**: alat koji pruža lažne vremenske informacije na temelju zadane lokacije.
- **Connect to Agent Builder**: značajka koja vam omogućuje povezivanje MCP servera s Agent Builderom za testiranje i otklanjanje pogrešaka.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: značajka koja omogućuje otklanjanje pogrešaka MCP Servera pomoću MCP Inspectora.

## Get started with the Weather MCP Server template

> **Prerequisites**
>
> Za pokretanje MCP Servera na vašem lokalnom razvojnom računalu, trebat će vam:
>
> - [Python](https://www.python.org/)
> - (*Opcionalno - ako preferirate uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Prepare environment

Postoje dva pristupa za postavljanje okruženja za ovaj projekt. Možete odabrati onaj koji vam više odgovara.

> Note: Ponovno učitajte VSCode ili terminal kako biste osigurali da se koristi python iz virtualnog okruženja nakon što ga kreirate.

| Approach | Steps |
| -------- | ----- |
| Using `uv` | 1. Kreirajte virtualno okruženje: `uv venv` <br>2. Pokrenite VSCode naredbu "***Python: Select Interpreter***" i odaberite python iz kreiranog virtualnog okruženja <br>3. Instalirajte ovisnosti (uključujući razvojne ovisnosti): `uv pip install -r pyproject.toml --extra dev` |
| Using `pip` | 1. Kreirajte virtualno okruženje: `python -m venv .venv` <br>2. Pokrenite VSCode naredbu "***Python: Select Interpreter***" i odaberite python iz kreiranog virtualnog okruženja<br>3. Instalirajte ovisnosti (uključujući razvojne ovisnosti): `pip install -e .[dev]` | 

Nakon postavljanja okruženja, možete pokrenuti server na lokalnom razvojnom računalu putem Agent Buildera kao MCP Klijenta za početak:
1. Otvorite VS Code Debug panel. Odaberite `Debug in Agent Builder` ili pritisnite `F5` za početak otklanjanja pogrešaka MCP servera.
2. Koristite AI Toolkit Agent Builder za testiranje servera s [ovim promptom](../../../../../../../../../../../open_prompt_builder). Server će se automatski povezati s Agent Builderom.
3. Kliknite `Run` za testiranje servera s promptom.

**Čestitamo**! Uspješno ste pokrenuli Weather MCP Server na vašem lokalnom razvojnom računalu putem Agent Buildera kao MCP Klijenta.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## What's included in the template

| Folder / File| Contents                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | VSCode datoteke za otklanjanje pogrešaka                   |
| `.aitk`      | Konfiguracije za AI Toolkit                |
| `src`        | Izvorni kod za weather mcp server   |

## How to debug the Weather MCP Server

> Notes:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) je vizualni alat za programere za testiranje i otklanjanje pogrešaka MCP servera.
> - Svi načini otklanjanja pogrešaka podržavaju breakpointe, tako da možete dodavati breakpointe u kod implementacije alata.

| Debug Mode | Description | Steps to debug |
| ---------- | ----------- | --------------- |
| Agent Builder | Otklanjanje pogrešaka MCP servera u Agent Builderu putem AI Toolkit-a. | 1. Otvorite VS Code Debug panel. Odaberite `Debug in Agent Builder` i pritisnite `F5` za početak otklanjanja pogrešaka MCP servera.<br>2. Koristite AI Toolkit Agent Builder za testiranje servera s [ovim promptom](../../../../../../../../../../../open_prompt_builder). Server će se automatski povezati s Agent Builderom.<br>3. Kliknite `Run` za testiranje servera s promptom. |
| MCP Inspector | Otklanjanje pogrešaka MCP servera pomoću MCP Inspectora. | 1. Instalirajte [Node.js](https://nodejs.org/)<br> 2. Postavite Inspector: `cd inspector` && `npm install` <br> 3. Otvorite VS Code Debug panel. Odaberite `Debug SSE in Inspector (Edge)` ili `Debug SSE in Inspector (Chrome)`. Pritisnite F5 za početak otklanjanja pogrešaka.<br> 4. Kad se MCP Inspector pokrene u pregledniku, kliknite gumb `Connect` za povezivanje ovog MCP servera.<br> 5. Zatim možete `List Tools`, odabrati alat, unijeti parametre i `Run Tool` za otklanjanje pogrešaka u kodu servera.<br> |

## Default Ports and customizations

| Debug Mode | Ports | Definitions | Customizations | Note |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Uredite [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) da biste promijenili navedene portove. | N/A |
| MCP Inspector | 3001 (Server); 5173 and 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Uredite [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) da biste promijenili navedene portove.| N/A |

## Feedback

Ako imate bilo kakve povratne informacije ili prijedloge za ovaj predložak, molimo otvorite issue na [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Nismo odgovorni za bilo kakve nesporazume ili kriva tumačenja koja proizlaze iz korištenja ovog prijevoda.