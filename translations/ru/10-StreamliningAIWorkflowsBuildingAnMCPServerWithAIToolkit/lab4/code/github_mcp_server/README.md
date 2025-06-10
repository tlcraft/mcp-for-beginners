<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:01:36+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "ru"
}
-->
# Weather MCP Server

Это пример MCP Server на Python, реализующий инструменты для работы с погодой с использованием имитационных ответов. Его можно использовать как основу для собственного MCP Server. Включает следующие функции:

- **Weather Tool**: инструмент, предоставляющий имитированную информацию о погоде для заданного местоположения.
- **Git Clone Tool**: инструмент для клонирования git-репозитория в указанную папку.
- **VS Code Open Tool**: инструмент для открытия папки в VS Code или VS Code Insiders.
- **Connect to Agent Builder**: функция, позволяющая подключить MCP сервер к Agent Builder для тестирования и отладки.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: функция, позволяющая отлаживать MCP Server с помощью MCP Inspector.

## Начало работы с шаблоном Weather MCP Server

> **Требования**
>
> Для запуска MCP Server на вашей локальной машине для разработки вам потребуется:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (требуется для инструмента git_clone_repo)
> - [VS Code](https://code.visualstudio.com/) или [VS Code Insiders](https://code.visualstudio.com/insiders/) (требуется для инструмента open_in_vscode)
> - (*Опционально - если предпочитаете uv*) [uv](https://github.com/astral-sh/uv)
> - [Расширение Python Debugger](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Подготовка окружения

Существует два способа настройки окружения для этого проекта. Вы можете выбрать любой из них в зависимости от ваших предпочтений.

> Примечание: Перезапустите VSCode или терминал, чтобы убедиться, что используется python из виртуального окружения после его создания.

| Способ | Шаги |
| -------- | ----- |
| Использование `uv` | 1. Создайте виртуальное окружение: `uv venv` <br>2. Выполните команду VSCode "***Python: Select Interpreter***" и выберите python из созданного виртуального окружения <br>3. Установите зависимости (включая dev-зависимости): `uv pip install -r pyproject.toml --extra dev` |
| Использование `pip` | 1. Создайте виртуальное окружение: `python -m venv .venv` <br>2. Выполните команду VSCode "***Python: Select Interpreter***" и выберите python из созданного виртуального окружения<br>3. Установите зависимости (включая dev-зависимости): `pip install -e .[dev]` |

После настройки окружения вы можете запустить сервер на своей локальной машине для разработки через Agent Builder в качестве MCP Client, чтобы начать работу:
1. Откройте панель отладки VS Code. Выберите `Debug in Agent Builder` или нажмите `F5`, чтобы начать отладку MCP сервера.
2. Используйте AI Toolkit Agent Builder для тестирования сервера с помощью [этого запроса](../../../../../../../../../../../open_prompt_builder). Сервер автоматически подключится к Agent Builder.
3. Нажмите `Run`, чтобы протестировать сервер с этим запросом.

**Поздравляем!** Вы успешно запустили Weather MCP Server на своей локальной машине для разработки через Agent Builder в качестве MCP Client.  
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Что включено в шаблон

| Папка / Файл | Содержание |
| ------------ | -------------------------------------------- |
| `.vscode`    | Файлы VSCode для отладки                   |
| `.aitk`      | Конфигурации для AI Toolkit                |
| `src`        | Исходный код Weather MCP Server   |

## Как отлаживать Weather MCP Server

> Примечания:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) — визуальный инструмент для разработчиков для тестирования и отладки MCP серверов.
> - Все режимы отладки поддерживают точки останова, так что вы можете ставить точки останова в коде реализации инструментов.

## Доступные инструменты

### Weather Tool  
Инструмент `get_weather` предоставляет имитированную информацию о погоде для указанного местоположения.

| Параметр | Тип | Описание |
| --------- | ---- | ----------- |
| `location` | string | Местоположение для получения прогноза погоды (например, название города, штат или координаты) |

### Git Clone Tool  
Инструмент `git_clone_repo` клонирует git-репозиторий в указанную папку.

| Параметр | Тип | Описание |
| --------- | ---- | ----------- |
| `repo_url` | string | URL git-репозитория для клонирования |
| `target_folder` | string | Путь к папке, куда должен быть клонирован репозиторий |

Инструмент возвращает JSON объект с:
- `success`: Boolean, указывающий, успешна ли операция
- `target_folder` или `error`: Путь к клонированному репозиторию или сообщение об ошибке

### VS Code Open Tool  
Инструмент `open_in_vscode` открывает папку в приложении VS Code или VS Code Insiders.

| Параметр | Тип | Описание |
| --------- | ---- | ----------- |
| `folder_path` | string | Путь к папке для открытия |
| `use_insiders` | boolean (опционально) | Использовать ли VS Code Insiders вместо обычного VS Code |

Инструмент возвращает JSON объект с:
- `success`: Boolean, указывающий, успешна ли операция
- `message` или `error`: Сообщение подтверждения или сообщение об ошибке

## Режим отладки | Описание | Шаги для отладки |
| ---------- | ----------- | --------------- |
| Agent Builder | Отладка MCP сервера в Agent Builder через AI Toolkit. | 1. Откройте панель отладки VS Code. Выберите `Debug in Agent Builder` и нажмите `F5`, чтобы начать отладку MCP сервера.<br>2. Используйте AI Toolkit Agent Builder для тестирования сервера с помощью [этого запроса](../../../../../../../../../../../open_prompt_builder). Сервер автоматически подключится к Agent Builder.<br>3. Нажмите `Run`, чтобы протестировать сервер с этим запросом. |
| MCP Inspector | Отладка MCP сервера с помощью MCP Inspector. | 1. Установите [Node.js](https://nodejs.org/)<br> 2. Настройте Inspector: `cd inspector` && `npm install` <br> 3. Откройте панель отладки VS Code. Выберите `Debug SSE in Inspector (Edge)` или `Debug SSE in Inspector (Chrome)`. Нажмите F5 для начала отладки.<br> 4. Когда MCP Inspector запустится в браузере, нажмите кнопку `Connect`, чтобы подключить этот MCP сервер.<br> 5. После этого вы можете `List Tools`, выбрать инструмент, ввести параметры и `Run Tool` для отладки кода сервера.<br> |

## Порты по умолчанию и настройки

| Режим отладки | Порты | Определения | Настройки | Примечание |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Измените [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json), чтобы изменить указанные порты. | Нет |
| MCP Inspector | 3001 (Сервер); 5173 и 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Измените [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json), чтобы изменить указанные порты.| Нет |

## Обратная связь

Если у вас есть отзывы или предложения по этому шаблону, пожалуйста, создайте issue в репозитории [AI Toolkit GitHub](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, просим учитывать, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на исходном языке следует считать авторитетным источником. Для критически важной информации рекомендуется использовать профессиональный перевод, выполненный человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.