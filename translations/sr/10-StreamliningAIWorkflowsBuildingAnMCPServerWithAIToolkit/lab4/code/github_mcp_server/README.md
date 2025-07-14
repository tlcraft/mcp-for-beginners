<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T09:03:49+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "sr"
}
-->
# Weather MCP Server

Ово је пример MCP сервера у Python-у који имплементира алате за временску прогнозу са лажним одговорима. Може се користити као основа за ваш сопствени MCP сервер. Укључује следеће функције:

- **Weather Tool**: Алат који пружа лажне информације о времену на основу дате локације.
- **Git Clone Tool**: Алат који клонира git репозиторијум у одређени фолдер.
- **VS Code Open Tool**: Алат који отвара фолдер у VS Code или VS Code Insiders.
- **Connect to Agent Builder**: Функција која вам омогућава да повежете MCP сервер са Agent Builder-ом ради тестирања и отклањања грешака.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Функција која вам омогућава да отклањате грешке на MCP серверу користећи MCP Inspector.

## Почетак рада са Weather MCP Server шаблоном

> **Претпоставке**
>
> Да бисте покренули MCP сервер на свом локалном развојном рачунару, потребно вам је:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (потребно за git_clone_repo алат)
> - [VS Code](https://code.visualstudio.com/) или [VS Code Insiders](https://code.visualstudio.com/insiders/) (потребно за open_in_vscode алат)
> - (*Опционо - ако више волите uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Припрема окружења

Постоје два начина за подешавање окружења за овај пројекат. Можете изабрати онај који вам више одговара.

> Напомена: Поново учитајте VSCode или терминал да бисте били сигурни да се користи python из виртуелног окружења након његовог креирања.

| Приступ | Кораци |
| -------- | ----- |
| Коришћење `uv` | 1. Креирајте виртуелно окружење: `uv venv` <br>2. Покрените VSCode команду "***Python: Select Interpreter***" и изаберите python из креираног виртуелног окружења <br>3. Инсталирајте зависности (укључујући dev зависности): `uv pip install -r pyproject.toml --extra dev` |
| Коришћење `pip` | 1. Креирајте виртуелно окружење: `python -m venv .venv` <br>2. Покрените VSCode команду "***Python: Select Interpreter***" и изаберите python из креираног виртуелног окружења<br>3. Инсталирајте зависности (укључујући dev зависности): `pip install -e .[dev]` |

Након подешавања окружења, можете покренути сервер на свом локалном развојном рачунару преко Agent Builder-а као MCP клијента да бисте почели:
1. Отворите VS Code Debug панел. Изаберите `Debug in Agent Builder` или притисните `F5` да бисте започели отклањање грешака на MCP серверу.
2. Користите AI Toolkit Agent Builder да тестирате сервер са [овим упитом](../../../../../../../../../../open_prompt_builder). Сервер ће аутоматски бити повезан са Agent Builder-ом.
3. Кликните `Run` да тестирате сервер са упитом.

**Честитамо**! Успешно сте покренули Weather MCP Server на свом локалном развојном рачунару преко Agent Builder-а као MCP клијента.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Шта је укључено у шаблон

| Фолдер / Фајл | Садржај                                     |
| ------------- | ------------------------------------------ |
| `.vscode`     | VSCode фајлови за отклањање грешака        |
| `.aitk`       | Конфигурације за AI Toolkit                 |
| `src`         | Изворни код за weather mcp сервер          |

## Како отклањати грешке на Weather MCP Server-у

> Напомене:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) је визуелни алат за развојне програмере за тестирање и отклањање грешака на MCP серверима.
> - Сви режими отклањања грешака подржавају тачке прекида, тако да можете додавати тачке прекида у код имплементације алата.

## Доступни алати

### Weather Tool
`get_weather` алат пружа лажне информације о времену за одређену локацију.

| Параметар | Тип | Опис |
| --------- | --- | ----- |
| `location` | string | Локација за коју се добија временска прогноза (нпр. име града, држава или координате) |

### Git Clone Tool
`git_clone_repo` алат клонира git репозиторијум у одређени фолдер.

| Параметар | Тип | Опис |
| --------- | --- | ----- |
| `repo_url` | string | URL git репозиторијума који се клонира |
| `target_folder` | string | Путања до фолдера у који треба клонирати репозиторијум |

Алат враћа JSON објекат са:
- `success`: Булова вредност која показује да ли је операција била успешна
- `target_folder` или `error`: Путања клонираног репозиторијума или порука о грешци

### VS Code Open Tool
`open_in_vscode` алат отвара фолдер у VS Code или VS Code Insiders апликацији.

| Параметар | Тип | Опис |
| --------- | --- | ----- |
| `folder_path` | string | Путања до фолдера који се отвара |
| `use_insiders` | boolean (опционо) | Да ли да се користи VS Code Insiders уместо обичног VS Code-а |

Алат враћа JSON објекат са:
- `success`: Булова вредност која показује да ли је операција била успешна
- `message` или `error`: Потврдна порука или порука о грешци

## Режими отклањања грешака | Опис | Кораци за отклањање грешака |
| ------------------ | ----------- | ---------------------------- |
| Agent Builder | Отклањање грешака MCP сервера у Agent Builder-у преко AI Toolkit-а. | 1. Отворите VS Code Debug панел. Изаберите `Debug in Agent Builder` и притисните `F5` да започнете отклањање грешака на MCP серверу.<br>2. Користите AI Toolkit Agent Builder да тестирате сервер са [овим упитом](../../../../../../../../../../open_prompt_builder). Сервер ће аутоматски бити повезан са Agent Builder-ом.<br>3. Кликните `Run` да тестирате сервер са упитом. |
| MCP Inspector | Отклањање грешака MCP сервера користећи MCP Inspector. | 1. Инсталирајте [Node.js](https://nodejs.org/)<br> 2. Подесите Inspector: `cd inspector` && `npm install` <br> 3. Отворите VS Code Debug панел. Изаберите `Debug SSE in Inspector (Edge)` или `Debug SSE in Inspector (Chrome)`. Притисните F5 да започнете отклањање грешака.<br> 4. Када се MCP Inspector покрене у прегледачу, кликните на дугме `Connect` да бисте повезали овај MCP сервер.<br> 5. Затим можете `List Tools`, изабрати алат, унети параметре и `Run Tool` да бисте отклањали грешке у коду сервера.<br> |

## Подразумевани портови и прилагођавања

| Режим отклањања грешака | Портови | Дефиниције | Прилагођавања | Напомена |
| ------------------------ | ------- | ---------- | ------------- | -------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Измените [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) да бисте променили наведене портове. | Нема |
| MCP Inspector | 3001 (Server); 5173 и 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Измените [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) да бисте променили наведене портове. | Нема |

## Повратне информације

Ако имате било какве повратне информације или предлоге за овај шаблон, молимо вас да отворите issue на [AI Toolkit GitHub репозиторијуму](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која произилазе из коришћења овог превода.