<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T09:05:17+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "uk"
}
-->
# Weather MCP Server

Це приклад MCP Server на Python, який реалізує інструменти для погоди з імітованими відповідями. Його можна використовувати як основу для власного MCP Server. Він включає такі функції:

- **Weather Tool**: інструмент, який надає імітовану інформацію про погоду на основі заданого місця.
- **Git Clone Tool**: інструмент, який клонує git-репозиторій у вказану папку.
- **VS Code Open Tool**: інструмент, який відкриває папку у VS Code або VS Code Insiders.
- **Connect to Agent Builder**: функція, що дозволяє підключити MCP сервер до Agent Builder для тестування та налагодження.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: функція, що дозволяє налагоджувати MCP Server за допомогою MCP Inspector.

## Початок роботи з шаблоном Weather MCP Server

> **Вимоги**
>
> Для запуску MCP Server на вашій локальній машині для розробки вам знадобиться:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (потрібен для інструменту git_clone_repo)
> - [VS Code](https://code.visualstudio.com/) або [VS Code Insiders](https://code.visualstudio.com/insiders/) (потрібно для інструменту open_in_vscode)
> - (*Опційно - якщо ви віддаєте перевагу uv*) [uv](https://github.com/astral-sh/uv)
> - [Розширення Python Debugger](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Підготовка середовища

Існує два способи налаштування середовища для цього проєкту. Ви можете обрати будь-який з них залежно від ваших уподобань.

> Примітка: Перезавантажте VSCode або термінал, щоб переконатися, що використовується python з віртуального середовища після його створення.

| Підхід | Кроки |
| -------- | ----- |
| Використання `uv` | 1. Створіть віртуальне середовище: `uv venv` <br>2. Виконайте команду VSCode "***Python: Select Interpreter***" і оберіть python зі створеного віртуального середовища <br>3. Встановіть залежності (включно з dev-залежностями): `uv pip install -r pyproject.toml --extra dev` |
| Використання `pip` | 1. Створіть віртуальне середовище: `python -m venv .venv` <br>2. Виконайте команду VSCode "***Python: Select Interpreter***" і оберіть python зі створеного віртуального середовища<br>3. Встановіть залежності (включно з dev-залежностями): `pip install -e .[dev]` |

Після налаштування середовища ви можете запустити сервер на вашій локальній машині через Agent Builder як MCP Client, щоб почати роботу:
1. Відкрийте панель налагодження VS Code. Виберіть `Debug in Agent Builder` або натисніть `F5` для початку налагодження MCP сервера.
2. Використайте AI Toolkit Agent Builder для тестування сервера за допомогою [цього запиту](../../../../../../../../../../open_prompt_builder). Сервер автоматично підключиться до Agent Builder.
3. Натисніть `Run`, щоб протестувати сервер із запитом.

**Вітаємо**! Ви успішно запустили Weather MCP Server на вашій локальній машині через Agent Builder як MCP Client.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Що входить до шаблону

| Папка / Файл | Зміст                                     |
| ------------ | ----------------------------------------- |
| `.vscode`    | Файли VSCode для налагодження             |
| `.aitk`      | Конфігурації для AI Toolkit                |
| `src`        | Вихідний код MCP сервера для погоди        |

## Як налагоджувати Weather MCP Server

> Примітки:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) — це візуальний інструмент для розробників для тестування та налагодження MCP серверів.
> - Усі режими налагодження підтримують точки зупину, тож ви можете додавати їх у код реалізації інструментів.

## Доступні інструменти

### Weather Tool
Інструмент `get_weather` надає імітовану інформацію про погоду для вказаного місця.

| Параметр | Тип | Опис |
| --------- | ---- | ----------- |
| `location` | string | Місце, для якого потрібно отримати погоду (наприклад, назва міста, штат або координати) |

### Git Clone Tool
Інструмент `git_clone_repo` клонує git-репозиторій у вказану папку.

| Параметр | Тип | Опис |
| --------- | ---- | ----------- |
| `repo_url` | string | URL git-репозиторію для клонування |
| `target_folder` | string | Шлях до папки, куди слід клонувати репозиторій |

Інструмент повертає JSON-об’єкт з:
- `success`: булеве значення, що вказує, чи операція була успішною
- `target_folder` або `error`: шлях до клонованого репозиторію або повідомлення про помилку

### VS Code Open Tool
Інструмент `open_in_vscode` відкриває папку у VS Code або VS Code Insiders.

| Параметр | Тип | Опис |
| --------- | ---- | ----------- |
| `folder_path` | string | Шлях до папки, яку потрібно відкрити |
| `use_insiders` | boolean (опційно) | Чи використовувати VS Code Insiders замість звичайного VS Code |

Інструмент повертає JSON-об’єкт з:
- `success`: булеве значення, що вказує, чи операція була успішною
- `message` або `error`: повідомлення про підтвердження або повідомлення про помилку

## Режими налагодження | Опис | Кроки для налагодження |
| ---------- | ----------- | --------------- |
| Agent Builder | Налагодження MCP сервера в Agent Builder через AI Toolkit. | 1. Відкрийте панель налагодження VS Code. Виберіть `Debug in Agent Builder` і натисніть `F5` для початку налагодження MCP сервера.<br>2. Використайте AI Toolkit Agent Builder для тестування сервера за допомогою [цього запиту](../../../../../../../../../../open_prompt_builder). Сервер автоматично підключиться до Agent Builder.<br>3. Натисніть `Run`, щоб протестувати сервер із запитом. |
| MCP Inspector | Налагодження MCP сервера за допомогою MCP Inspector. | 1. Встановіть [Node.js](https://nodejs.org/)<br> 2. Налаштуйте Inspector: `cd inspector` && `npm install` <br> 3. Відкрийте панель налагодження VS Code. Виберіть `Debug SSE in Inspector (Edge)` або `Debug SSE in Inspector (Chrome)`. Натисніть F5 для початку налагодження.<br> 4. Коли MCP Inspector відкриється у браузері, натисніть кнопку `Connect`, щоб підключити цей MCP сервер.<br> 5. Потім ви можете `List Tools`, обрати інструмент, ввести параметри та `Run Tool` для налагодження коду сервера.<br> |

## Порти за замовчуванням та налаштування

| Режим налагодження | Порти | Визначення | Налаштування | Примітка |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Редагуйте [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json), щоб змінити вказані порти. | Немає |
| MCP Inspector | 3001 (сервер); 5173 та 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Редагуйте [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json), щоб змінити вказані порти. | Немає |

## Зворотній зв’язок

Якщо у вас є відгуки або пропозиції щодо цього шаблону, будь ласка, відкрийте issue у [репозиторії AI Toolkit на GitHub](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.