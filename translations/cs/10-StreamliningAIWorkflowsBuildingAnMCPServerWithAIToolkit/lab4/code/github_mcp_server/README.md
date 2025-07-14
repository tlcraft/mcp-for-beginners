<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T09:02:29+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "cs"
}
-->
# Weather MCP Server

Toto je ukázkový MCP Server v Pythonu, který implementuje nástroje pro počasí s falešnými odpověďmi. Může sloužit jako základ pro váš vlastní MCP Server. Obsahuje následující funkce:

- **Weather Tool**: Nástroj, který poskytuje simulované informace o počasí na základě zadané lokality.
- **Git Clone Tool**: Nástroj, který klonuje git repozitář do určené složky.
- **VS Code Open Tool**: Nástroj, který otevírá složku ve VS Code nebo VS Code Insiders.
- **Connect to Agent Builder**: Funkce, která umožňuje připojit MCP server k Agent Builderu pro testování a ladění.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Funkce, která umožňuje ladit MCP Server pomocí MCP Inspectoru.

## Začínáme s šablonou Weather MCP Serveru

> **Požadavky**
>
> Pro spuštění MCP Serveru na vašem lokálním vývojovém počítači budete potřebovat:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (vyžadováno pro nástroj git_clone_repo)
> - [VS Code](https://code.visualstudio.com/) nebo [VS Code Insiders](https://code.visualstudio.com/insiders/) (vyžadováno pro nástroj open_in_vscode)
> - (*Volitelné - pokud preferujete uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Příprava prostředí

Existují dva způsoby, jak nastavit prostředí pro tento projekt. Vyberte si ten, který vám více vyhovuje.

> Poznámka: Po vytvoření virtuálního prostředí znovu načtěte VSCode nebo terminál, aby se používal python z virtuálního prostředí.

| Přístup | Kroky |
| -------- | ----- |
| Použití `uv` | 1. Vytvořte virtuální prostředí: `uv venv` <br>2. Spusťte příkaz ve VSCode "***Python: Select Interpreter***" a vyberte python z vytvořeného virtuálního prostředí <br>3. Nainstalujte závislosti (včetně vývojových): `uv pip install -r pyproject.toml --extra dev` |
| Použití `pip` | 1. Vytvořte virtuální prostředí: `python -m venv .venv` <br>2. Spusťte příkaz ve VSCode "***Python: Select Interpreter***" a vyberte python z vytvořeného virtuálního prostředí<br>3. Nainstalujte závislosti (včetně vývojových): `pip install -e .[dev]` |

Po nastavení prostředí můžete spustit server na svém lokálním vývojovém počítači přes Agent Builder jako MCP klienta a začít:
1. Otevřete panel ladění ve VS Code. Vyberte `Debug in Agent Builder` nebo stiskněte `F5` pro spuštění ladění MCP serveru.
2. Použijte AI Toolkit Agent Builder k otestování serveru s [tímto promptem](../../../../../../../../../../open_prompt_builder). Server se automaticky připojí k Agent Builderu.
3. Klikněte na `Run` pro otestování serveru s promptem.

**Gratulujeme**! Úspěšně jste spustili Weather MCP Server na svém lokálním vývojovém počítači přes Agent Builder jako MCP klienta.  
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Co šablona obsahuje

| Složka / Soubor | Obsah                                      |
| --------------- | ------------------------------------------ |
| `.vscode`       | Soubory VSCode pro ladění                   |
| `.aitk`         | Konfigurace pro AI Toolkit                   |
| `src`           | Zdrojový kód Weather MCP serveru             |

## Jak ladit Weather MCP Server

> Poznámky:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) je vizuální nástroj pro vývojáře pro testování a ladění MCP serverů.
> - Všechny režimy ladění podporují breakpointy, takže můžete přidávat breakpointy do kódu implementace nástrojů.

## Dostupné nástroje

### Weather Tool  
Nástroj `get_weather` poskytuje simulované informace o počasí pro zadanou lokalitu.

| Parametr | Typ | Popis |
| -------- | --- | ----- |
| `location` | string | Lokalita, pro kterou chcete získat počasí (např. název města, stát nebo souřadnice) |

### Git Clone Tool  
Nástroj `git_clone_repo` klonuje git repozitář do určené složky.

| Parametr | Typ | Popis |
| -------- | --- | ----- |
| `repo_url` | string | URL git repozitáře, který chcete klonovat |
| `target_folder` | string | Cesta ke složce, kam se má repozitář klonovat |

Nástroj vrací JSON objekt s:
- `success`: Boolean, zda operace proběhla úspěšně
- `target_folder` nebo `error`: Cesta ke klonovanému repozitáři nebo chybová zpráva

### VS Code Open Tool  
Nástroj `open_in_vscode` otevírá složku v aplikaci VS Code nebo VS Code Insiders.

| Parametr | Typ | Popis |
| -------- | --- | ----- |
| `folder_path` | string | Cesta ke složce, kterou chcete otevřít |
| `use_insiders` | boolean (volitelné) | Zda použít VS Code Insiders místo běžného VS Code |

Nástroj vrací JSON objekt s:
- `success`: Boolean, zda operace proběhla úspěšně
- `message` nebo `error`: Potvrzovací zpráva nebo chybová zpráva

## Režimy ladění | Popis | Kroky ladění |
| ------------- | ----------- | ------------- |
| Agent Builder | Ladění MCP serveru v Agent Builderu přes AI Toolkit. | 1. Otevřete panel ladění ve VS Code. Vyberte `Debug in Agent Builder` a stiskněte `F5` pro spuštění ladění MCP serveru.<br>2. Použijte AI Toolkit Agent Builder k otestování serveru s [tímto promptem](../../../../../../../../../../open_prompt_builder). Server se automaticky připojí k Agent Builderu.<br>3. Klikněte na `Run` pro otestování serveru s promptem. |
| MCP Inspector | Ladění MCP serveru pomocí MCP Inspectoru. | 1. Nainstalujte [Node.js](https://nodejs.org/)<br>2. Nastavte Inspector: `cd inspector` && `npm install`<br>3. Otevřete panel ladění ve VS Code. Vyberte `Debug SSE in Inspector (Edge)` nebo `Debug SSE in Inspector (Chrome)`. Stiskněte F5 pro spuštění ladění.<br>4. Po spuštění MCP Inspectoru v prohlížeči klikněte na tlačítko `Connect` pro připojení tohoto MCP serveru.<br>5. Poté můžete `List Tools`, vybrat nástroj, zadat parametry a `Run Tool` pro ladění kódu serveru.<br> |

## Výchozí porty a přizpůsobení

| Režim ladění | Porty | Definice | Přizpůsobení | Poznámka |
| ------------ | ----- | -------- | ------------ | -------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Upravte [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) pro změnu portů. | N/A |
| MCP Inspector | 3001 (Server); 5173 a 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Upravte [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) pro změnu portů. | N/A |

## Zpětná vazba

Pokud máte jakoukoli zpětnou vazbu nebo návrhy k této šabloně, otevřete prosím issue na [AI Toolkit GitHub repozitáři](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.