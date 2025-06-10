<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:18:00+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "sk"
}
-->
# Weather MCP Server

Toto je ukážkový MCP Server v Pythone, ktorý implementuje nástroje na počasie s falošnými odpoveďami. Môže slúžiť ako základ pre váš vlastný MCP Server. Obsahuje nasledujúce funkcie:

- **Weather Tool**: Nástroj, ktorý poskytuje simulované informácie o počasí na základe zadanej lokality.
- **Git Clone Tool**: Nástroj, ktorý klonuje git repozitár do zvoleného priečinka.
- **VS Code Open Tool**: Nástroj, ktorý otvorí priečinok vo VS Code alebo VS Code Insiders.
- **Connect to Agent Builder**: Funkcia, ktorá umožňuje pripojiť MCP server k Agent Builderu na testovanie a ladenie.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Funkcia umožňujúca ladenie MCP Servera pomocou MCP Inspectora.

## Začnite s Weather MCP Server šablónou

> **Predpoklady**
>
> Na spustenie MCP Servera na vašom lokálnom vývojovom počítači budete potrebovať:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (vyžaduje sa pre git_clone_repo nástroj)
> - [VS Code](https://code.visualstudio.com/) alebo [VS Code Insiders](https://code.visualstudio.com/insiders/) (vyžaduje sa pre open_in_vscode nástroj)
> - (*Voliteľné - ak preferujete uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Príprava prostredia

Pre nastavenie prostredia pre tento projekt existujú dva spôsoby. Môžete si vybrať ten, ktorý vám viac vyhovuje.

> Poznámka: Po vytvorení virtuálneho prostredia reštartujte VSCode alebo terminál, aby sa použil python z virtuálneho prostredia.

| Prístup | Kroky |
| -------- | ----- |
| Použitie `uv` | 1. Vytvorte virtuálne prostredie: `uv venv` <br>2. Spustite VSCode príkaz "***Python: Select Interpreter***" a vyberte python z vytvoreného virtuálneho prostredia <br>3. Nainštalujte závislosti (vrátane dev závislostí): `uv pip install -r pyproject.toml --extra dev` |
| Použitie `pip` | 1. Vytvorte virtuálne prostredie: `python -m venv .venv` <br>2. Spustite VSCode príkaz "***Python: Select Interpreter***" a vyberte python z vytvoreného virtuálneho prostredia<br>3. Nainštalujte závislosti (vrátane dev závislostí): `pip install -e .[dev]` |

Po nastavení prostredia môžete spustiť server na vašom lokálnom vývojovom počítači cez Agent Builder ako MCP Klient, aby ste mohli začať:
1. Otvorte panel ladenia vo VS Code. Vyberte `Debug in Agent Builder` alebo stlačte `F5` pre spustenie ladenia MCP servera.
2. Použite AI Toolkit Agent Builder na testovanie servera s [týmto promptom](../../../../../../../../../../../open_prompt_builder). Server sa automaticky pripojí k Agent Builderu.
3. Kliknite na `Run`, aby ste otestovali server s promptom.

**Gratulujeme**! Úspešne ste spustili Weather MCP Server na vašom lokálnom vývojovom počítači cez Agent Builder ako MCP Klient.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Čo obsahuje šablóna

| Priečinok / Súbor | Obsah                                      |
| ----------------- | ------------------------------------------ |
| `.vscode`     | Súbory VSCode pre ladenie                   |
| `.aitk`       | Konfigurácie pre AI Toolkit                 |
| `src`         | Zdrojový kód pre weather mcp server          |

## Ako ladiť Weather MCP Server

> Poznámky:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) je vizuálny nástroj pre vývojárov na testovanie a ladenie MCP serverov.
> - Všetky režimy ladenia podporujú breakpointy, takže môžete pridávať breakpointy do kódu implementácie nástrojov.

## Dostupné nástroje

### Weather Tool
Nástroj `get_weather` poskytuje simulované informácie o počasí pre zadanú lokalitu.

| Parameter | Typ | Popis |
| --------- | --- | ----- |
| `location` | string | Lokalita, pre ktorú sa má získať počasie (napr. názov mesta, štát alebo súradnice) |

### Git Clone Tool
Nástroj `git_clone_repo` klonuje git repozitár do zvoleného priečinka.

| Parameter | Typ | Popis |
| --------- | --- | ----- |
| `repo_url` | string | URL git repozitára, ktorý sa má klonovať |
| `target_folder` | string | Cesta k priečinku, kam sa má repozitár klonovať |

Nástroj vracia JSON objekt s:
- `success`: Boolean hodnota indikujúca úspešnosť operácie
- `target_folder` alebo `error`: Cesta ku klonovanému repozitáru alebo chybová správa

### VS Code Open Tool
Nástroj `open_in_vscode` otvorí priečinok vo VS Code alebo VS Code Insiders aplikácii.

| Parameter | Typ | Popis |
| --------- | --- | ----- |
| `folder_path` | string | Cesta k priečinku, ktorý sa má otvoriť |
| `use_insiders` | boolean (voliteľné) | Či sa má použiť VS Code Insiders namiesto bežného VS Code |

Nástroj vracia JSON objekt s:
- `success`: Boolean hodnota indikujúca úspešnosť operácie
- `message` alebo `error`: Potvrdzovacia správa alebo chybová správa

## Debug Mode | Popis | Kroky na ladenie |
| ---------- | ----------- | --------------- |
| Agent Builder | Ladenie MCP servera v Agent Builderi cez AI Toolkit. | 1. Otvorte panel ladenia vo VS Code. Vyberte `Debug in Agent Builder` a stlačte `F5` pre spustenie ladenia MCP servera.<br>2. Použite AI Toolkit Agent Builder na testovanie servera s [týmto promptom](../../../../../../../../../../../open_prompt_builder). Server sa automaticky pripojí k Agent Builderu.<br>3. Kliknite na `Run`, aby ste otestovali server s promptom. |
| MCP Inspector | Ladenie MCP servera pomocou MCP Inspectora. | 1. Nainštalujte [Node.js](https://nodejs.org/)<br> 2. Nastavte Inspector: `cd inspector` && `npm install` <br> 3. Otvorte panel ladenia vo VS Code. Vyberte `Debug SSE in Inspector (Edge)` alebo `Debug SSE in Inspector (Chrome)`. Stlačte F5 pre spustenie ladenia.<br> 4. Keď sa MCP Inspector spustí v prehliadači, kliknite na tlačidlo `Connect` pre pripojenie tohto MCP servera.<br> 5. Potom môžete `List Tools`, vybrať nástroj, zadať parametre a `Run Tool` pre ladenie vášho serverového kódu.<br> |

## Predvolené porty a prispôsobenia

| Režim ladenia | Porty | Definície | Prispôsobenia | Poznámka |
| ------------- | ----- | --------- | ------------- | -------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Upraviť [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) pre zmenu týchto portov. | N/A |
| MCP Inspector | 3001 (Server); 5173 a 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Upraviť [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) pre zmenu týchto portov.| N/A |

## Spätná väzba

Ak máte nejaké pripomienky alebo návrhy k tejto šablóne, prosím, otvorte issue v [AI Toolkit GitHub repozitári](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, berte prosím na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.