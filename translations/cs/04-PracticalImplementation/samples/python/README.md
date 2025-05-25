<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:32:59+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "cs"
}
-->
# Model Context Protocol (MCP) Реализация на C#

Этот репозиторий содержит реализацию Model Context Protocol (MCP) на C#, демонстрирующую, как создать сервер и клиентское приложение, которые обмениваются данными согласно стандарту MCP.

## Обзор

Реализация MCP состоит из двух основных компонентов:

1. **MCP Server (`server.py`)** — сервер, который предоставляет:
   - **Инструменты**: функции, вызываемые удалённо
   - **Ресурсы**: данные, которые можно получить
   - **Подсказки**: шаблоны для генерации подсказок для языковых моделей

2. **MCP Client (`client.py`)** — клиентское приложение, которое подключается к серверу и использует его возможности

## Возможности

Эта реализация демонстрирует несколько ключевых функций MCP:

### Инструменты
- `completion` — генерирует текстовые дополнения с помощью ИИ-моделей (симуляция)
- `add` — простой калькулятор, складывающий два числа

### Ресурсы
- `models://` — возвращает информацию о доступных ИИ-моделях
- `greeting://{name}` — возвращает персонализированное приветствие для заданного имени

### Подсказки
- `review_code` — генерирует шаблон подсказки для обзора кода

## Установка

Для использования этой реализации MCP установите необходимые пакеты:

```powershell
pip install mcp-server mcp-client
```

## Запуск сервера и клиента

### Запуск сервера

Запустите сервер в одном окне терминала:

```powershell
python server.py
```

Сервер также можно запустить в режиме разработки с помощью MCP CLI:

```powershell
mcp dev server.py
```

Или установить в Claude Desktop (если доступно):

```powershell
mcp install server.py
```

### Запуск клиента

Запустите клиент в другом окне терминала:

```powershell
python client.py
```

Это подключится к серверу и продемонстрирует все доступные возможности.

### Использование клиента

Клиент (`client.py`) демонстрирует все функции MCP:

```powershell
python client.py
```

Он подключится к серверу и выполнит все функции, включая инструменты, ресурсы и подсказки. В выводе будет:

1. Результат работы калькулятора (5 + 7 = 12)
2. Ответ инструмента дополнения на вопрос «What is the meaning of life?»
3. Список доступных ИИ-моделей
4. Персонализированное приветствие для «MCP Explorer»
5. Шаблон подсказки для обзора кода

## Детали реализации

Сервер реализован с использованием API `FastMCP`, который предоставляет высокоуровневые абстракции для определения MCP-сервисов. Вот упрощённый пример определения инструментов:

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

Клиент использует библиотеку MCP client для подключения и вызова сервера:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Узнать больше

Для дополнительной информации о MCP посетите: https://modelcontextprotocol.io/

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo mylné výklady vyplývající z použití tohoto překladu.