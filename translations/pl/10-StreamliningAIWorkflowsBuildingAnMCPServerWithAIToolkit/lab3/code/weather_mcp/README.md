<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:29:46+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "pl"
}
-->
# Weather MCP Server

To jest przykładowy serwer MCP w Pythonie implementujący narzędzia pogodowe z symulowanymi odpowiedziami. Może być używany jako szkielet do stworzenia własnego serwera MCP. Zawiera następujące funkcje:

- **Weather Tool**: narzędzie dostarczające symulowane informacje pogodowe na podstawie podanej lokalizacji.
- **Połączenie z Agent Builder**: funkcja pozwalająca połączyć serwer MCP z Agent Builder do testowania i debugowania.
- **Debugowanie w [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: funkcja umożliwiająca debugowanie serwera MCP za pomocą MCP Inspector.

## Rozpocznij pracę z szablonem Weather MCP Server

> **Wymagania wstępne**
>
> Aby uruchomić serwer MCP na lokalnej maszynie deweloperskiej, potrzebujesz:
>
> - [Python](https://www.python.org/)
> - (*Opcjonalnie - jeśli wolisz uv*) [uv](https://github.com/astral-sh/uv)
> - [Rozszerzenie Python Debugger](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Przygotowanie środowiska

Są dwa sposoby na skonfigurowanie środowiska dla tego projektu. Możesz wybrać ten, który bardziej Ci odpowiada.

> Uwaga: Przeładuj VSCode lub terminal, aby upewnić się, że używany jest python z utworzonego środowiska wirtualnego po jego utworzeniu.

| Podejście | Kroki |
| --------- | ----- |
| Używając `uv` | 1. Utwórz środowisko wirtualne: `uv venv` <br>2. Uruchom polecenie VSCode "***Python: Select Interpreter***" i wybierz pythona z utworzonego środowiska wirtualnego <br>3. Zainstaluj zależności (w tym zależności developerskie): `uv pip install -r pyproject.toml --extra dev` |
| Używając `pip` | 1. Utwórz środowisko wirtualne: `python -m venv .venv` <br>2. Uruchom polecenie VSCode "***Python: Select Interpreter***" i wybierz pythona z utworzonego środowiska wirtualnego<br>3. Zainstaluj zależności (w tym zależności developerskie): `pip install -e .[dev]` |

Po skonfigurowaniu środowiska możesz uruchomić serwer na lokalnej maszynie deweloperskiej poprzez Agent Builder jako klient MCP, aby zacząć:
1. Otwórz panel debugowania w VS Code. Wybierz `Debug in Agent Builder` lub naciśnij `F5`, aby rozpocząć debugowanie serwera MCP.
2. Użyj AI Toolkit Agent Builder, aby przetestować serwer za pomocą [tego promptu](../../../../../../../../../../../open_prompt_builder). Serwer zostanie automatycznie połączony z Agent Builder.
3. Kliknij `Run`, aby przetestować serwer z tym promptem.

**Gratulacje**! Pomyślnie uruchomiłeś Weather MCP Server na lokalnej maszynie deweloperskiej poprzez Agent Builder jako klient MCP.  
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Co zawiera szablon

| Folder / Plik | Zawartość                                  |
| ------------- | ----------------------------------------- |
| `.vscode`    | Pliki VSCode do debugowania               |
| `.aitk`   | Konfiguracje dla AI Toolkit                |
| `src`   | Kod źródłowy serwera weather mcp           |

## Jak debugować Weather MCP Server

> Uwagi:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) to wizualne narzędzie dla deweloperów do testowania i debugowania serwerów MCP.
> - Wszystkie tryby debugowania obsługują punkty przerwania, więc możesz dodawać je w kodzie implementacji narzędzi.

| Tryb debugowania | Opis | Kroki debugowania |
| ---------------- | ----- | ----------------- |
| Agent Builder | Debugowanie serwera MCP w Agent Builder za pomocą AI Toolkit. | 1. Otwórz panel debugowania w VS Code. Wybierz `Debug in Agent Builder` i naciśnij `F5`, aby rozpocząć debugowanie serwera MCP.<br>2. Użyj AI Toolkit Agent Builder, aby przetestować serwer za pomocą [tego promptu](../../../../../../../../../../../open_prompt_builder). Serwer zostanie automatycznie połączony z Agent Builder.<br>3. Kliknij `Run`, aby przetestować serwer z promptem. |
| MCP Inspector | Debugowanie serwera MCP za pomocą MCP Inspector. | 1. Zainstaluj [Node.js](https://nodejs.org/)<br> 2. Skonfiguruj Inspector: `cd inspector` && `npm install` <br> 3. Otwórz panel debugowania w VS Code. Wybierz `Debug SSE in Inspector (Edge)` lub `Debug SSE in Inspector (Chrome)`. Naciśnij F5, aby rozpocząć debugowanie.<br> 4. Gdy MCP Inspector uruchomi się w przeglądarce, kliknij przycisk `Connect`, aby połączyć ten serwer MCP.<br> 5. Następnie możesz `List Tools`, wybrać narzędzie, wprowadzić parametry i `Run Tool`, aby debugować kod serwera.<br> |

## Domyślne porty i dostosowania

| Tryb debugowania | Porty | Definicje | Dostosowania | Uwagi |
| ---------------- | ----- | --------- | ------------ | ----- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Edytuj [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json), aby zmienić powyższe porty. | Brak |
| MCP Inspector | 3001 (Serwer); 5173 i 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Edytuj [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json), aby zmienić powyższe porty. | Brak |

## Opinie

Jeśli masz jakiekolwiek uwagi lub sugestie dotyczące tego szablonu, otwórz zgłoszenie na [repozytorium AI Toolkit na GitHub](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy traktować jako źródło wiarygodne i autorytatywne. W przypadku informacji o krytycznym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.