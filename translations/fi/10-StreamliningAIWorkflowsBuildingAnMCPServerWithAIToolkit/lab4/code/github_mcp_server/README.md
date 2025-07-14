<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T08:59:39+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "fi"
}
-->
# Weather MCP Server

Tämä on esimerkkimallinen MCP Server Pythonilla, joka toteuttaa säätyökaluja mock-vastauksilla. Sitä voi käyttää pohjana omalle MCP Serverillesi. Se sisältää seuraavat ominaisuudet:

- **Weather Tool**: Työkalu, joka tarjoaa mockattua sääinformaatiota annetun sijainnin perusteella.
- **Git Clone Tool**: Työkalu, joka kloonaa git-repositorion määriteltyyn kansioon.
- **VS Code Open Tool**: Työkalu, joka avaa kansion VS Codessa tai VS Code Insidersissa.
- **Connect to Agent Builder**: Ominaisuus, joka mahdollistaa MCP-serverin yhdistämisen Agent Builderiin testaukseen ja virheenkorjaukseen.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Ominaisuus, joka mahdollistaa MCP Serverin virheenkorjauksen MCP Inspectorin avulla.

## Aloita Weather MCP Server -mallipohjalla

> **Esivaatimukset**
>
> Jotta voit ajaa MCP Serveriä paikallisella kehityskoneellasi, tarvitset:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (vaaditaan git_clone_repo-työkalulle)
> - [VS Code](https://code.visualstudio.com/) tai [VS Code Insiders](https://code.visualstudio.com/insiders/) (vaaditaan open_in_vscode-työkalulle)
> - (*Valinnainen - jos haluat käyttää uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Ympäristön valmistelu

Tämän projektin ympäristön voi valmistella kahdella eri tavalla. Voit valita mieleisesi.

> Huomautus: Lataa VSCode tai terminaali uudelleen varmistaaksesi, että virtuaaliympäristön python on käytössä virtuaaliympäristön luomisen jälkeen.

| Tapa | Vaiheet |
| -------- | ----- |
| Käyttämällä `uv` | 1. Luo virtuaaliympäristö: `uv venv` <br>2. Suorita VSCode-komento "***Python: Select Interpreter***" ja valitse luodun virtuaaliympäristön python <br>3. Asenna riippuvuudet (sisältäen kehitysriippuvuudet): `uv pip install -r pyproject.toml --extra dev` |
| Käyttämällä `pip` | 1. Luo virtuaaliympäristö: `python -m venv .venv` <br>2. Suorita VSCode-komento "***Python: Select Interpreter***" ja valitse luodun virtuaaliympäristön python<br>3. Asenna riippuvuudet (sisältäen kehitysriippuvuudet): `pip install -e .[dev]` |

Ympäristön valmistelun jälkeen voit ajaa palvelimen paikallisella kehityskoneellasi Agent Builderin kautta MCP Clientinä aloittaaksesi:
1. Avaa VS Code Debug-paneeli. Valitse `Debug in Agent Builder` tai paina `F5` aloittaaksesi MCP-serverin virheenkorjauksen.
2. Käytä AI Toolkit Agent Builderia testataksesi palvelinta [tällä kehotteella](../../../../../../../../../../open_prompt_builder). Palvelin yhdistyy automaattisesti Agent Builderiin.
3. Klikkaa `Run` testataksesi palvelinta kehotteella.

**Onnittelut**! Olet onnistuneesti ajanut Weather MCP Serverin paikallisella kehityskoneellasi Agent Builderin kautta MCP Clientinä.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Mitä mallipohja sisältää

| Kansio / Tiedosto | Sisältö                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | VSCode-tiedostot virheenkorjausta varten    |
| `.aitk`      | AI Toolkitin asetukset                       |
| `src`        | Weather MCP Serverin lähdekoodi              |

## Kuinka virheenkorjata Weather MCP Serveriä

> Huomautuksia:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) on visuaalinen kehitystyökalu MCP-serverien testaamiseen ja virheenkorjaukseen.
> - Kaikki virheenkorjaustilat tukevat breakpointteja, joten voit lisätä breakpointteja työkalun toteutuskoodiin.

## Saatavilla olevat työkalut

### Weather Tool
`get_weather`-työkalu tarjoaa mockattua sääinformaatiota määritellylle sijainnille.

| Parametri | Tyyppi | Kuvaus |
| --------- | ---- | ----------- |
| `location` | string | Sijainti, jolle sää halutaan (esim. kaupungin nimi, osavaltio tai koordinaatit) |

### Git Clone Tool
`git_clone_repo`-työkalu kloonaa git-repositorion määriteltyyn kansioon.

| Parametri | Tyyppi | Kuvaus |
| --------- | ---- | ----------- |
| `repo_url` | string | Git-repositorion URL, joka kloonataan |
| `target_folder` | string | Polku kansioon, johon repositorio kloonataan |

Työkalu palauttaa JSON-objektin, jossa on:
- `success`: Boolean, joka kertoo onnistuiko operaatio
- `target_folder` tai `error`: Kloonatun repositorion polku tai virheilmoitus

### VS Code Open Tool
`open_in_vscode`-työkalu avaa kansion VS Code- tai VS Code Insiders -sovelluksessa.

| Parametri | Tyyppi | Kuvaus |
| --------- | ---- | ----------- |
| `folder_path` | string | Polku avattavaan kansioon |
| `use_insiders` | boolean (valinnainen) | Käytetäänkö VS Code Insidersia tavallisen VS Coden sijaan |

Työkalu palauttaa JSON-objektin, jossa on:
- `success`: Boolean, joka kertoo onnistuiko operaatio
- `message` tai `error`: Vahvistusviesti tai virheilmoitus

## Virheenkorjaustilat | Kuvaus | Vaiheet virheenkorjaukseen |
| ---------- | ----------- | --------------- |
| Agent Builder | Virheenkorjaa MCP-serveriä Agent Builderissa AI Toolkitin kautta. | 1. Avaa VS Code Debug-paneeli. Valitse `Debug in Agent Builder` ja paina `F5` aloittaaksesi MCP-serverin virheenkorjauksen.<br>2. Käytä AI Toolkit Agent Builderia testataksesi palvelinta [tällä kehotteella](../../../../../../../../../../open_prompt_builder). Palvelin yhdistyy automaattisesti Agent Builderiin.<br>3. Klikkaa `Run` testataksesi palvelinta kehotteella. |
| MCP Inspector | Virheenkorjaa MCP-serveriä MCP Inspectorin avulla. | 1. Asenna [Node.js](https://nodejs.org/)<br> 2. Valmistele Inspector: `cd inspector` && `npm install` <br> 3. Avaa VS Code Debug-paneeli. Valitse `Debug SSE in Inspector (Edge)` tai `Debug SSE in Inspector (Chrome)`. Paina F5 aloittaaksesi virheenkorjauksen.<br> 4. Kun MCP Inspector käynnistyy selaimessa, klikkaa `Connect` yhdistääksesi tämän MCP-serverin.<br> 5. Tämän jälkeen voit `List Tools`, valita työkalun, syöttää parametrit ja `Run Tool` virheenkorjataksesi palvelimen koodia.<br> |

## Oletusportit ja mukautukset

| Virheenkorjaustila | Portit | Määrittelyt | Mukautukset | Huomautus |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Muokkaa [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) muuttaaksesi yllä olevia portteja. | Ei sovellu |
| MCP Inspector | 3001 (Server); 5173 ja 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Muokkaa [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) muuttaaksesi yllä olevia portteja.| Ei sovellu |

## Palaute

Jos sinulla on palautetta tai ehdotuksia tähän mallipohjaan liittyen, avaa issue [AI Toolkitin GitHub-repositoriossa](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.