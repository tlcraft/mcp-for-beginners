<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:32:42+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "fi"
}
-->
# Weather MCP Server

Tämä on esimerkkisovellus MCP Serveristä Pythonilla, joka toteuttaa säätiedon työkalut mock-vastauksilla. Sitä voi käyttää pohjana omalle MCP Serverillesi. Se sisältää seuraavat ominaisuudet:

- **Weather Tool**: Työkalu, joka tarjoaa simuloitua säätietoa annetun sijainnin perusteella.
- **Yhdistä Agent Builderiin**: Ominaisuus, jonka avulla voit yhdistää MCP-serverin Agent Builderiin testaukseen ja virheenkorjaukseen.
- **Virheenkorjaus [MCP Inspectorilla](https://github.com/modelcontextprotocol/inspector)**: Ominaisuus, jonka avulla voit virheenkorjata MCP Serverin MCP Inspector -työkalulla.

## Aloita Weather MCP Server -mallipohjalla

> **Esivaatimukset**
>
> MCP Serverin suorittamiseen paikallisella kehityskoneellasi tarvitset:
>
> - [Python](https://www.python.org/)
> - (*Valinnainen - jos haluat käyttää uv:tä*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Valmistele ympäristö

Tämän projektin ympäristön voi ottaa käyttöön kahdella eri tavalla. Voit valita mieltymyksesi mukaan kumman tahansa.

> Huomautus: Lataa VSCode tai terminaali uudelleen varmistaaksesi, että virtuaaliympäristön python on käytössä sen luomisen jälkeen.

| Tapa | Vaiheet |
| -------- | ----- |
| Käyttämällä `uv` | 1. Luo virtuaaliympäristö: `uv venv` <br>2. Suorita VSCode-komento "***Python: Select Interpreter***" ja valitse luodun virtuaaliympäristön python <br>3. Asenna riippuvuudet (sisältäen kehitysriippuvuudet): `uv pip install -r pyproject.toml --extra dev` |
| Käyttämällä `pip` | 1. Luo virtuaaliympäristö: `python -m venv .venv` <br>2. Suorita VSCode-komento "***Python: Select Interpreter***" ja valitse luodun virtuaaliympäristön python<br>3. Asenna riippuvuudet (sisältäen kehitysriippuvuudet): `pip install -e .[dev]` |

Ympäristön asetettuasi voit käynnistää palvelimen paikallisella kehityskoneellasi Agent Builderin kautta MCP Clientinä aloittaaksesi:
1. Avaa VS Code Debug-paneeli. Valitse `Debug in Agent Builder` tai paina `F5` aloittaaksesi MCP-serverin virheenkorjauksen.
2. Käytä AI Toolkit Agent Builderia testataksesi palvelinta [tällä kehotteella](../../../../../../../../../../../open_prompt_builder). Palvelin yhdistetään automaattisesti Agent Builderiin.
3. Klikkaa `Run` testataksesi palvelinta kehotteella.

**Onnittelut**! Olet onnistuneesti käynnistänyt Weather MCP Serverin paikallisella kehityskoneellasi Agent Builderin kautta MCP Clientinä.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Mitä mallipohja sisältää

| Kansio / Tiedosto | Sisältö                                   |
| ------------ | -------------------------------------------- |
| `.vscode`    | VSCode-tiedostot virheenkorjaukseen             |
| `.aitk`      | Asetukset AI Toolkitille                       |
| `src`        | Lähdekoodi weather mcp serverille               |

## Kuinka virheenkorjata Weather MCP Serveriä

> Huomautuksia:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) on visuaalinen kehittäjätyökalu MCP-serverien testaamiseen ja virheenkorjaukseen.
> - Kaikki virheenkorjaustilat tukevat breakpointteja, joten voit lisätä pysäytyspisteitä työkalun toteutuskoodiin.

| Virheenkorjaustila | Kuvaus | Vaiheet virheenkorjaukseen |
| ---------- | ----------- | --------------- |
| Agent Builder | Virheenkorjaa MCP-serveriä Agent Builderissa AI Toolkitin kautta. | 1. Avaa VS Code Debug-paneeli. Valitse `Debug in Agent Builder` ja paina `F5` aloittaaksesi MCP-serverin virheenkorjauksen.<br>2. Käytä AI Toolkit Agent Builderia testataksesi palvelinta [tällä kehotteella](../../../../../../../../../../../open_prompt_builder). Palvelin yhdistetään automaattisesti Agent Builderiin.<br>3. Klikkaa `Run` testataksesi palvelinta kehotteella. |
| MCP Inspector | Virheenkorjaa MCP-serveriä MCP Inspectorilla. | 1. Asenna [Node.js](https://nodejs.org/)<br> 2. Määritä Inspector: `cd inspector` && `npm install` <br> 3. Avaa VS Code Debug-paneeli. Valitse `Debug SSE in Inspector (Edge)` tai `Debug SSE in Inspector (Chrome)`. Paina F5 aloittaaksesi virheenkorjauksen.<br> 4. Kun MCP Inspector käynnistyy selaimessa, klikkaa `Connect`-painiketta yhdistääksesi tämän MCP-serverin.<br> 5. Sen jälkeen voit `List Tools`, valita työkalun, syöttää parametrit ja `Run Tool` virheenkorjataksesi palvelimen koodia.<br> |

## Oletusportit ja mukautukset

| Virheenkorjaustila | Portit | Määritelmät | Mukautukset | Huomautus |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Muokkaa [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) vaihtaaksesi yllä olevia portteja. | Ei sovellu |
| MCP Inspector | 3001 (Server); 5173 ja 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Muokkaa [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) vaihtaaksesi yllä olevia portteja.| Ei sovellu |

## Palautetta

Jos sinulla on palautetta tai ehdotuksia tähän mallipohjaan liittyen, avaa issue [AI Toolkit GitHub -varastossa](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.