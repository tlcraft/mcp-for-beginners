<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:36:40+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "sk"
}
-->
# Weather MCP Server

Toto je ukážkový MCP Server v Pythone, ktorý implementuje nástroje na počasie s falošnými odpoveďami. Môže slúžiť ako základ pre váš vlastný MCP Server. Obsahuje nasledujúce funkcie:

- **Weather Tool**: Nástroj, ktorý poskytuje simulované informácie o počasí na základe zadanej lokality.
- **Pripojenie k Agent Builderu**: Funkcia, ktorá umožňuje pripojiť MCP server k Agent Builderu na testovanie a ladenie.
- **Ladenie v [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Funkcia, ktorá umožňuje ladiť MCP Server pomocou MCP Inspector.

## Začnite s šablónou Weather MCP Server

> **Predpoklady**
>
> Na spustenie MCP Servera na vašom lokálnom vývojovom stroji potrebujete:
>
> - [Python](https://www.python.org/)
> - (*Voliteľné - ak preferujete uv*) [uv](https://github.com/astral-sh/uv)
> - [Rozšírenie Python Debugger](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Príprava prostredia

Existujú dva spôsoby, ako nastaviť prostredie pre tento projekt. Môžete si vybrať ten, ktorý vám viac vyhovuje.

> Poznámka: Pre načítanie virtuálneho prostredia python je potrebné reštartovať VSCode alebo terminál po vytvorení virtuálneho prostredia.

| Prístup | Kroky |
| -------- | ----- |
| Použitie `uv` | 1. Vytvorte virtuálne prostredie: `uv venv` <br>2. Spustite príkaz vo VSCode "***Python: Select Interpreter***" a vyberte python z vytvoreného virtuálneho prostredia <br>3. Nainštalujte závislosti (vrátane vývojových): `uv pip install -r pyproject.toml --extra dev` |
| Použitie `pip` | 1. Vytvorte virtuálne prostredie: `python -m venv .venv` <br>2. Spustite príkaz vo VSCode "***Python: Select Interpreter***" a vyberte python z vytvoreného virtuálneho prostredia<br>3. Nainštalujte závislosti (vrátane vývojových): `pip install -e .[dev]` |

Po nastavení prostredia môžete spustiť server na vašom lokálnom vývojovom stroji cez Agent Builder ako MCP klienta, aby ste mohli začať:
1. Otvorte panel ladenia vo VS Code. Vyberte `Debug in Agent Builder` alebo stlačte `F5` na spustenie ladenia MCP servera.
2. Použite AI Toolkit Agent Builder na testovanie servera s [týmto promptom](../../../../../../../../../../../open_prompt_builder). Server sa automaticky pripojí k Agent Builderu.
3. Kliknite na `Run` pre otestovanie servera s promptom.

**Gratulujeme**! Úspešne ste spustili Weather MCP Server na vašom lokálnom vývojovom stroji cez Agent Builder ako MCP klienta.  
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Čo je zahrnuté v šablóne

| Zložka / Súbor | Obsah |
| -------------- | ------ |
| `.vscode` | Súbory VSCode na ladenie |
| `.aitk` | Konfigurácie pre AI Toolkit |
| `src` | Zdrojový kód weather mcp servera |

## Ako ladiť Weather MCP Server

> Poznámky:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) je vizuálny nástroj pre vývojárov na testovanie a ladenie MCP serverov.
> - Všetky režimy ladenia podporujú breakpointy, takže môžete pridávať breakpointy do kódu implementácie nástroja.

| Režim ladenia | Popis | Kroky na ladenie |
| ------------- | ------ | ----------------- |
| Agent Builder | Ladenie MCP servera v Agent Builderi cez AI Toolkit. | 1. Otvorte panel ladenia vo VS Code. Vyberte `Debug in Agent Builder` a stlačte `F5` na spustenie ladenia MCP servera.<br>2. Použite AI Toolkit Agent Builder na testovanie servera s [týmto promptom](../../../../../../../../../../../open_prompt_builder). Server sa automaticky pripojí k Agent Builderu.<br>3. Kliknite na `Run` pre otestovanie servera s promptom. |
| MCP Inspector | Ladenie MCP servera pomocou MCP Inspector. | 1. Nainštalujte [Node.js](https://nodejs.org/)<br>2. Nastavte Inspector: `cd inspector` && `npm install` <br>3. Otvorte panel ladenia vo VS Code. Vyberte `Debug SSE in Inspector (Edge)` alebo `Debug SSE in Inspector (Chrome)`. Stlačte F5 na spustenie ladenia.<br>4. Keď sa MCP Inspector spustí v prehliadači, kliknite na tlačidlo `Connect` pre pripojenie tohto MCP servera.<br>5. Potom môžete `List Tools`, vybrať nástroj, zadať parametre a `Run Tool` na ladenie vášho serverového kódu.<br> |

## Predvolené porty a prispôsobenia

| Režim ladenia | Porty | Definície | Prispôsobenia | Poznámka |
| ------------- | ----- | --------- | ------------- | -------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Upraviť [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) pre zmenu týchto portov. | N/A |
| MCP Inspector | 3001 (Server); 5173 a 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Upraviť [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) pre zmenu týchto portov. | N/A |

## Spätná väzba

Ak máte nejaké pripomienky alebo návrhy k tejto šablóne, otvorte prosím issue na [AI Toolkit GitHub repozitári](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, majte prosím na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.