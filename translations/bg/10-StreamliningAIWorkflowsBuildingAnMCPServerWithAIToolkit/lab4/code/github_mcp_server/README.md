<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:18:54+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "bg"
}
-->
# Weather MCP Server

Това е примерен MCP сървър на Python, който реализира инструменти за прогноза на времето с фиктивни отговори. Може да се използва като основа за ваш собствен MCP сървър. Включва следните функции:

- **Weather Tool**: Инструмент, който предоставя фиктивна информация за времето на базата на зададеното място.
- **Git Clone Tool**: Инструмент, който клонира git хранилище в посочена папка.
- **VS Code Open Tool**: Инструмент, който отваря папка във VS Code или VS Code Insiders.
- **Connect to Agent Builder**: Функция, която позволява свързване на MCP сървъра с Agent Builder за тестване и отстраняване на грешки.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Функция, която позволява отстраняване на грешки в MCP сървъра чрез MCP Inspector.

## Започнете с Weather MCP Server шаблона

> **Изисквания**
>
> За да стартирате MCP сървъра на локалната си машина за разработка, ще ви трябват:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (задължително за git_clone_repo инструмента)
> - [VS Code](https://code.visualstudio.com/) или [VS Code Insiders](https://code.visualstudio.com/insiders/) (задължително за open_in_vscode инструмента)
> - (*По избор - ако предпочитате uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Подготовка на средата

Има два начина за настройка на средата за този проект. Можете да изберете този, който предпочитате.

> Забележка: Рестартирайте VSCode или терминала, за да сте сигурни, че се използва python от виртуалната среда след създаването ѝ.

| Подход | Стъпки |
| -------- | ----- |
| Използване на `uv` | 1. Създайте виртуална среда: `uv venv` <br>2. Стартирайте VSCode командата "***Python: Select Interpreter***" и изберете python от създадената виртуална среда <br>3. Инсталирайте зависимости (включително dev зависимости): `uv pip install -r pyproject.toml --extra dev` |
| Използване на `pip` | 1. Създайте виртуална среда: `python -m venv .venv` <br>2. Стартирайте VSCode командата "***Python: Select Interpreter***" и изберете python от създадената виртуална среда<br>3. Инсталирайте зависимости (включително dev зависимости): `pip install -e .[dev]` |

След като настроите средата, можете да стартирате сървъра на локалната си машина чрез Agent Builder като MCP клиент, за да започнете:
1. Отворете панела за отстраняване на грешки във VS Code. Изберете `Debug in Agent Builder` или натиснете `F5`, за да стартирате отстраняването на грешки на MCP сървъра.
2. Използвайте AI Toolkit Agent Builder, за да тествате сървъра с [този промпт](../../../../../../../../../../../open_prompt_builder). Сървърът ще се свърже автоматично с Agent Builder.
3. Натиснете `Run`, за да тествате сървъра с промпта.

**Поздравления**! Успешно стартирахте Weather MCP Server на локалната си машина чрез Agent Builder като MCP клиент.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Какво е включено в шаблона

| Папка / Файл | Съдържание |
| ------------ | -------------------------------------------- |
| `.vscode`    | Файлове за VSCode за отстраняване на грешки                   |
| `.aitk`      | Конфигурации за AI Toolkit                |
| `src`        | Изходен код за weather mcp сървъра   |

## Как да отстранявате грешки в Weather MCP Server

> Забележки:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) е визуален инструмент за разработчици за тестване и отстраняване на грешки в MCP сървъри.
> - Всички режими на отстраняване на грешки поддържат прекъсвания, така че можете да добавяте прекъсвания в кода на инструментите.

## Налични инструменти

### Weather Tool
Инструментът `get_weather` предоставя фиктивна информация за времето за посочено място.

| Параметър | Тип | Описание |
| --------- | ---- | ----------- |
| `location` | string | Местоположение, за което да се получи информация за времето (например име на град, щат или координати) |

### Git Clone Tool
Инструментът `git_clone_repo` клонира git хранилище в посочена папка.

| Параметър | Тип | Описание |
| --------- | ---- | ----------- |
| `repo_url` | string | URL на git хранилището, което да се клонира |
| `target_folder` | string | Път до папката, в която да се клонира хранилището |

Инструментът връща JSON обект с:
- `success`: Булева стойност, указваща дали операцията е успешна
- `target_folder` или `error`: Пътят на клонираното хранилище или съобщение за грешка

### VS Code Open Tool
Инструментът `open_in_vscode` отваря папка в приложението VS Code или VS Code Insiders.

| Параметър | Тип | Описание |
| --------- | ---- | ----------- |
| `folder_path` | string | Път до папката, която да се отвори |
| `use_insiders` | boolean (по избор) | Дали да се използва VS Code Insiders вместо обикновения VS Code |

Инструментът връща JSON обект с:
- `success`: Булева стойност, указваща дали операцията е успешна
- `message` или `error`: Потвърждаващо съобщение или съобщение за грешка

## Режим на отстраняване на грешки | Описание | Стъпки за отстраняване на грешки |
| ---------- | ----------- | --------------- |
| Agent Builder | Отстраняване на грешки на MCP сървъра в Agent Builder чрез AI Toolkit. | 1. Отворете панела за отстраняване на грешки във VS Code. Изберете `Debug in Agent Builder` и натиснете `F5`, за да стартирате отстраняването на грешки на MCP сървъра.<br>2. Използвайте AI Toolkit Agent Builder, за да тествате сървъра с [този промпт](../../../../../../../../../../../open_prompt_builder). Сървърът ще се свърже автоматично с Agent Builder.<br>3. Натиснете `Run`, за да тествате сървъра с промпта. |
| MCP Inspector | Отстраняване на грешки на MCP сървъра чрез MCP Inspector. | 1. Инсталирайте [Node.js](https://nodejs.org/)<br> 2. Настройте Inspector: `cd inspector` && `npm install` <br> 3. Отворете панела за отстраняване на грешки във VS Code. Изберете `Debug SSE in Inspector (Edge)` или `Debug SSE in Inspector (Chrome)`. Натиснете F5, за да стартирате отстраняването на грешки.<br> 4. Когато MCP Inspector се стартира в браузъра, натиснете бутона `Connect`, за да свържете този MCP сървър.<br> 5. След това можете да `List Tools`, изберете инструмент, въведете параметри и `Run Tool`, за да отстранявате грешки в кода на сървъра.<br> |

## Стандартни портове и персонализации

| Режим на отстраняване на грешки | Портове | Дефиниции | Персонализации | Забележка |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Редактирайте [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json), за да промените горните портове. | Няма |
| MCP Inspector | 3001 (Сървър); 5173 и 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Редактирайте [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json), за да промените горните портове.| Няма |

## Обратна връзка

Ако имате обратна връзка или предложения за този шаблон, моля, отворете issue в [AI Toolkit GitHub хранилището](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или погрешни тълкувания, произтичащи от използването на този превод.