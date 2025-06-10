<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:19:22+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "sr"
}
-->
# Weather MCP Server

Ovo je primer MCP Servera u Pythonu koji implementira vremenske alate sa lažnim odgovorima. Može se koristiti kao osnova za vaš sopstveni MCP Server. Uključuje sledeće funkcije:

- **Weather Tool**: alat koji pruža lažne vremenske informacije na osnovu zadate lokacije.
- **Git Clone Tool**: alat koji klonira git repozitorijum u određeni folder.
- **VS Code Open Tool**: alat koji otvara folder u VS Code ili VS Code Insiders.
- **Connect to Agent Builder**: funkcija koja omogućava povezivanje MCP servera sa Agent Builder-om radi testiranja i debagovanja.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: funkcija koja omogućava debagovanje MCP Servera koristeći MCP Inspector.

## Početak rada sa Weather MCP Server šablonom

> **Zahtevi**
>
> Da biste pokrenuli MCP Server na svom lokalnom razvojnom računaru, biće vam potrebno:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (neophodno za git_clone_repo alat)
> - [VS Code](https://code.visualstudio.com/) ili [VS Code Insiders](https://code.visualstudio.com/insiders/) (neophodno za open_in_vscode alat)
> - (*Opcionalno - ako preferirate uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Priprema okruženja

Postoje dva načina za postavljanje okruženja za ovaj projekat. Možete izabrati bilo koji u zavisnosti od vaših preferencija.

> Napomena: Ponovo učitajte VSCode ili terminal kako biste osigurali da se koristi python iz virtuelnog okruženja nakon njegovog kreiranja.

| Pristup | Koraci |
| -------- | ----- |
| Korišćenje `uv` | 1. Kreirajte virtuelno okruženje: `uv venv` <br>2. Pokrenite VSCode komandu "***Python: Select Interpreter***" i izaberite python iz kreiranog virtuelnog okruženja <br>3. Instalirajte zavisnosti (uključujući razvojne): `uv pip install -r pyproject.toml --extra dev` |
| Korišćenje `pip` | 1. Kreirajte virtuelno okruženje: `python -m venv .venv` <br>2. Pokrenite VSCode komandu "***Python: Select Interpreter***" i izaberite python iz kreiranog virtuelnog okruženja<br>3. Instalirajte zavisnosti (uključujući razvojne): `pip install -e .[dev]` |

Nakon podešavanja okruženja, možete pokrenuti server na svom lokalnom razvojnom računaru preko Agent Builder-a kao MCP Klijent da biste započeli:
1. Otvorite VS Code Debug panel. Izaberite `Debug in Agent Builder` ili pritisnite `F5` da biste započeli debagovanje MCP servera.
2. Koristite AI Toolkit Agent Builder da testirate server sa [ovim promptom](../../../../../../../../../../../open_prompt_builder). Server će se automatski povezati sa Agent Builder-om.
3. Kliknite `Run` da testirate server sa promptom.

**Čestitamo**! Uspešno ste pokrenuli Weather MCP Server na svom lokalnom razvojnom računaru preko Agent Builder-a kao MCP Klijent.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Šta je uključeno u šablon

| Folder / Fajl | Sadržaj                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | VSCode fajlovi za debagovanje                   |
| `.aitk`      | Konfiguracije za AI Toolkit                |
| `src`        | Izvorni kod za weather mcp server   |

## Kako debagovati Weather MCP Server

> Napomene:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) je vizuelni alat za programere za testiranje i debagovanje MCP servera.
> - Svi režimi debagovanja podržavaju prekidne tačke, pa možete dodavati prekidne tačke u kod implementacije alata.

## Dostupni alati

### Weather Tool
`get_weather` alat pruža lažne vremenske informacije za određenu lokaciju.

| Parametar | Tip | Opis |
| --------- | ---- | ----------- |
| `location` | string | Lokacija za koju se traže vremenske informacije (npr. ime grada, država ili koordinate) |

### Git Clone Tool
`git_clone_repo` alat klonira git repozitorijum u određeni folder.

| Parametar | Tip | Opis |
| --------- | ---- | ----------- |
| `repo_url` | string | URL git repozitorijuma koji se klonira |
| `target_folder` | string | Putanja do foldera u koji treba klonirati repozitorijum |

Alat vraća JSON objekat sa:
- `success`: Boolean koji pokazuje da li je operacija uspešna
- `target_folder` ili `error`: Putanja kloniranog repozitorijuma ili poruka o grešci

### VS Code Open Tool
`open_in_vscode` alat otvara folder u VS Code ili VS Code Insiders aplikaciji.

| Parametar | Tip | Opis |
| --------- | ---- | ----------- |
| `folder_path` | string | Putanja do foldera koji se otvara |
| `use_insiders` | boolean (opciono) | Da li koristiti VS Code Insiders umesto regularnog VS Code |

Alat vraća JSON objekat sa:
- `success`: Boolean koji pokazuje da li je operacija uspešna
- `message` ili `error`: Poruka o potvrdi ili poruka o grešci

## Debug režim | Opis | Koraci za debagovanje |
| ---------- | ----------- | --------------- |
| Agent Builder | Debagovanje MCP servera u Agent Builder-u preko AI Toolkit-a. | 1. Otvorite VS Code Debug panel. Izaberite `Debug in Agent Builder` i pritisnite `F5` da započnete debagovanje MCP servera.<br>2. Koristite AI Toolkit Agent Builder da testirate server sa [ovim promptom](../../../../../../../../../../../open_prompt_builder). Server će se automatski povezati sa Agent Builder-om.<br>3. Kliknite `Run` da testirate server sa promptom. |
| MCP Inspector | Debagovanje MCP servera koristeći MCP Inspector. | 1. Instalirajte [Node.js](https://nodejs.org/)<br> 2. Podesite Inspector: `cd inspector` && `npm install` <br> 3. Otvorite VS Code Debug panel. Izaberite `Debug SSE in Inspector (Edge)` ili `Debug SSE in Inspector (Chrome)`. Pritisnite F5 za početak debagovanja.<br> 4. Kada se MCP Inspector pokrene u pregledaču, kliknite na dugme `Connect` da povežete ovaj MCP server.<br> 5. Zatim možete `List Tools`, izabrati alat, uneti parametre i `Run Tool` da debagujete svoj serverski kod.<br> |

## Podrazumevani portovi i prilagođavanja

| Debug režim | Portovi | Definicije | Prilagođavanja | Napomena |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Izmenite [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) da promenite navedene portove. | Nema |
| MCP Inspector | 3001 (Server); 5173 i 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Izmenite [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) da promenite navedene portove.| Nema |

## Povratne informacije

Ako imate bilo kakve povratne informacije ili predloge za ovaj šablon, molimo otvorite issue na [AI Toolkit GitHub repozitorijumu](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI преводилачке услуге [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални превод од стране људског преводиоца. Нисмо одговорни за било какве неспоразуме или погрешне тумачења која произилазе из коришћења овог превода.