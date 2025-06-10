<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:37:40+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "sr"
}
-->
# Weather MCP Server

Ovo je primer MCP Servera u Pythonu koji implementira vremenske alate sa lažnim odgovorima. Može se koristiti kao osnova za vaš sopstveni MCP Server. Uključuje sledeće funkcionalnosti:

- **Weather Tool**: alat koji pruža lažne informacije o vremenu na osnovu zadate lokacije.
- **Povezivanje sa Agent Builder-om**: funkcija koja omogućava povezivanje MCP servera sa Agent Builder-om za testiranje i otklanjanje grešaka.
- **Debugovanje u [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: funkcija koja omogućava debugovanje MCP Servera koristeći MCP Inspector.

## Početak rada sa Weather MCP Server šablonom

> **Preduslovi**
>
> Da biste pokrenuli MCP Server na vašem lokalnom razvojnom računaru, biće vam potrebno:
>
> - [Python](https://www.python.org/)
> - (*Opcionalno - ako preferirate uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Priprema okruženja

Postoje dva pristupa za podešavanje okruženja za ovaj projekat. Možete izabrati bilo koji u zavisnosti od vaših preferencija.

> Napomena: Ponovo pokrenite VSCode ili terminal kako biste bili sigurni da se koristi python iz virtuelnog okruženja nakon njegovog kreiranja.

| Pristup | Koraci |
| -------- | ----- |
| Korišćenje `uv` | 1. Kreirajte virtuelno okruženje: `uv venv` <br>2. Pokrenite VSCode komandu "***Python: Select Interpreter***" i izaberite python iz kreiranog virtuelnog okruženja <br>3. Instalirajte zavisnosti (uključujući i razvojne): `uv pip install -r pyproject.toml --extra dev` |
| Korišćenje `pip` | 1. Kreirajte virtuelno okruženje: `python -m venv .venv` <br>2. Pokrenite VSCode komandu "***Python: Select Interpreter***" i izaberite python iz kreiranog virtuelnog okruženja<br>3. Instalirajte zavisnosti (uključujući i razvojne): `pip install -e .[dev]` |

Nakon podešavanja okruženja, možete pokrenuti server na vašem lokalnom razvojnom računaru preko Agent Builder-a kao MCP Klijent da biste započeli:
1. Otvorite VS Code Debug panel. Izaberite `Debug in Agent Builder` ili pritisnite `F5` da biste započeli debugovanje MCP servera.
2. Koristite AI Toolkit Agent Builder da testirate server sa [ovim promptom](../../../../../../../../../../../open_prompt_builder). Server će automatski biti povezan sa Agent Builder-om.
3. Kliknite `Run` da testirate server sa promptom.

**Čestitamo**! Uspešno ste pokrenuli Weather MCP Server na vašem lokalnom razvojnom računaru preko Agent Builder-a kao MCP Klijent.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Šta je uključeno u šablon

| Folder / Fajl | Sadržaj                                    |
| ------------ | -------------------------------------------- |
| `.vscode`    | VSCode fajlovi za debugovanje                   |
| `.aitk`      | Konfiguracije za AI Toolkit                |
| `src`        | Izvorni kod za weather mcp server           |

## Kako debugovati Weather MCP Server

> Napomene:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) je vizuelni alat za programere za testiranje i debugovanje MCP servera.
> - Svi režimi debugovanja podržavaju breakpoints, tako da možete dodavati tačke prekida u kod implementacije alata.

| Režim debugovanja | Opis | Koraci za debugovanje |
| ---------- | ----------- | --------------- |
| Agent Builder | Debugujte MCP server u Agent Builder-u preko AI Toolkit-a. | 1. Otvorite VS Code Debug panel. Izaberite `Debug in Agent Builder` i pritisnite `F5` da započnete debugovanje MCP servera.<br>2. Koristite AI Toolkit Agent Builder da testirate server sa [ovim promptom](../../../../../../../../../../../open_prompt_builder). Server će automatski biti povezan sa Agent Builder-om.<br>3. Kliknite `Run` da testirate server sa promptom. |
| MCP Inspector | Debugujte MCP server koristeći MCP Inspector. | 1. Instalirajte [Node.js](https://nodejs.org/)<br> 2. Podesite Inspector: `cd inspector` && `npm install` <br> 3. Otvorite VS Code Debug panel. Izaberite `Debug SSE in Inspector (Edge)` ili `Debug SSE in Inspector (Chrome)`. Pritisnite F5 da započnete debugovanje.<br> 4. Kada se MCP Inspector pokrene u pregledaču, kliknite na dugme `Connect` da povežete ovaj MCP server.<br> 5. Zatim možete `List Tools`, izabrati alat, uneti parametre i `Run Tool` da debugujete kod servera.<br> |

## Podrazumevani portovi i prilagođavanja

| Režim debugovanja | Portovi | Definicije | Prilagođavanja | Napomena |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Izmenite [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) da promenite navedene portove. | N/A |
| MCP Inspector | 3001 (Server); 5173 i 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Izmenite [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) da promenite navedene portove. | N/A |

## Povratne informacije

Ako imate bilo kakve povratne informacije ili predloge za ovaj šablon, molimo vas da otvorite issue na [AI Toolkit GitHub repozitorijumu](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Ограничење одговорности**:  
Овај документ је преведен помоћу АИ преводилачке услуге [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде прецизан, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која могу настати употребом овог превода.