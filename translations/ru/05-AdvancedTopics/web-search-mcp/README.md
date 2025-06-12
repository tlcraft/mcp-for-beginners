<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T14:40:39+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ru"
}
-->
# Урок: Создание MCP-сервера веб-поиска

В этой главе показано, как создать реального AI-агента, который интегрируется с внешними API, обрабатывает разные типы данных, управляет ошибками и координирует работу нескольких инструментов — всё в формате, готовом к продакшену. Вы узнаете:

- **Интеграция с внешними API, требующими аутентификацию**
- **Обработка разных типов данных с нескольких эндпоинтов**
- **Надёжные стратегии обработки ошибок и логирования**
- **Координация нескольких инструментов в одном сервере**

К концу урока вы получите практические навыки работы с паттернами и лучшими практиками, которые необходимы для продвинутых AI-приложений с использованием LLM.

## Введение

В этом уроке вы научитесь создавать продвинутый MCP-сервер и клиент, расширяющие возможности LLM с помощью актуальных данных из веба через SerpAPI. Это важный навык для разработки динамичных AI-агентов, которые могут получать свежую информацию из интернета.

## Цели обучения

По окончании урока вы сможете:

- Безопасно интегрировать внешние API (например, SerpAPI) в MCP-сервер
- Реализовывать несколько инструментов для поиска по вебу, новостям, товарам и вопросов-ответов
- Парсить и форматировать структурированные данные для использования LLM
- Эффективно обрабатывать ошибки и управлять ограничениями по количеству запросов к API
- Создавать и тестировать как автоматизированных, так и интерактивных MCP-клиентов

## MCP-сервер веб-поиска

В этом разделе представлена архитектура и возможности MCP-сервера веб-поиска. Вы увидите, как FastMCP и SerpAPI используются вместе для расширения возможностей LLM актуальными веб-данными.

### Обзор

В реализации используются четыре инструмента, демонстрирующие способность MCP безопасно и эффективно обрабатывать разнообразные задачи с внешними API:

- **general_search**: для широкого веб-поиска
- **news_search**: для свежих новостных заголовков
- **product_search**: для данных электронной коммерции
- **qna**: для вопросов и ответов

### Особенности
- **Примеры кода**: Включает блоки кода на Python (легко расширяемые на другие языки) с возможностью сворачивания для удобства

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

Перед запуском клиента полезно понять, что делает сервер. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Ниже краткий пример того, как сервер определяет и регистрирует инструмент:

<details>  
<summary>Python Server</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **Интеграция внешних API**: Демонстрирует безопасную работу с API-ключами и внешними запросами
- **Парсинг структурированных данных**: Показывает, как преобразовывать ответы API в форматы, удобные для LLM
- **Обработка ошибок**: Надёжное управление ошибками с соответствующим логированием
- **Интерактивный клиент**: Включает как автоматические тесты, так и интерактивный режим для проверки
- **Управление контекстом**: Использует MCP Context для логирования и отслеживания запросов

## Требования

Перед началом убедитесь, что ваша среда настроена правильно, выполнив следующие шаги. Это гарантирует установку всех зависимостей и корректную настройку API-ключей для беспроблемной разработки и тестирования.

- Python 3.8 или выше
- API-ключ SerpAPI (зарегистрируйтесь на [SerpAPI](https://serpapi.com/) — доступен бесплатный тариф)

## Установка

Чтобы начать, выполните следующие шаги для настройки окружения:

1. Установите зависимости с помощью uv (рекомендуется) или pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Создайте файл `.env` в корне проекта и добавьте ваш SerpAPI ключ:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Использование

MCP-сервер веб-поиска — это основной компонент, предоставляющий инструменты для поиска по вебу, новостям, товарам и вопросам-ответам через интеграцию с SerpAPI. Он обрабатывает входящие запросы, управляет вызовами API, парсит ответы и возвращает структурированные результаты клиенту.

Полная реализация доступна в [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Запуск сервера

Для запуска MCP-сервера используйте команду:

```bash
python server.py
```

Сервер будет работать как stdio-ориентированный MCP-сервер, к которому клиент может подключаться напрямую.

### Режимы клиента

Клиент (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Запуск клиента

Для запуска автоматических тестов (автоматически запустится сервер):

```bash
python client.py
```

Или в интерактивном режиме:

```bash
python client.py --interactive
```

### Тестирование разными способами

Существует несколько способов протестировать и взаимодействовать с инструментами сервера в зависимости от ваших потребностей и рабочего процесса.

#### Написание собственных тестовых скриптов с MCP Python SDK
Вы также можете создавать собственные тестовые скрипты с помощью MCP Python SDK:

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

В данном контексте «тестовый скрипт» — это пользовательская программа на Python, которую вы пишете, чтобы выступать в роли клиента MCP-сервера. Вместо формального юнит-теста этот скрипт позволяет программно подключаться к серверу, вызывать любые его инструменты с нужными параметрами и просматривать результаты. Такой подход полезен для:
- Прототипирования и экспериментов с вызовами инструментов
- Проверки реакции сервера на разные входные данные
- Автоматизации повторяющихся вызовов инструментов
- Создания собственных рабочих процессов или интеграций поверх MCP-сервера

Тестовые скрипты позволяют быстро опробовать новые запросы, отлаживать работу инструментов или служить отправной точкой для более сложной автоматизации. Ниже пример использования MCP Python SDK для создания такого скрипта:

## Описание инструментов

Вы можете использовать следующие инструменты, предоставляемые сервером, для выполнения различных видов поиска и запросов. Каждый инструмент описан ниже с параметрами и примером использования.

В этом разделе подробно описаны доступные инструменты и их параметры.

### general_search

Выполняет общий веб-поиск и возвращает отформатированные результаты.

**Как вызвать этот инструмент:**

Вы можете вызвать `general_search` из собственного скрипта с помощью MCP Python SDK или интерактивно через Inspector или интерактивный режим клиента. Вот пример кода с использованием SDK:

<details>
<summary>Пример на Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

Или в интерактивном режиме выберите `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (строка): поисковый запрос

**Пример запроса:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Ищет свежие новостные статьи по запросу.

**Как вызвать этот инструмент:**

Вы можете вызвать `news_search` из собственного скрипта с помощью MCP Python SDK или интерактивно через Inspector или интерактивный режим клиента. Вот пример кода с использованием SDK:

<details>
<summary>Пример на Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

Или в интерактивном режиме выберите `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (строка): поисковый запрос

**Пример запроса:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Ищет товары, соответствующие запросу.

**Как вызвать этот инструмент:**

Вы можете вызвать `product_search` из собственного скрипта с помощью MCP Python SDK или интерактивно через Inspector или интерактивный режим клиента. Вот пример кода с использованием SDK:

<details>
<summary>Пример на Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

Или в интерактивном режиме выберите `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (строка): поисковый запрос товаров

**Пример запроса:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Получает прямые ответы на вопросы из поисковых систем.

**Как вызвать этот инструмент:**

Вы можете вызвать `qna` из собственного скрипта с помощью MCP Python SDK или интерактивно через Inspector или интерактивный режим клиента. Вот пример кода с использованием SDK:

<details>
<summary>Пример на Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

Или в интерактивном режиме выберите `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (строка): вопрос, на который нужно найти ответ

**Пример запроса:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Детали кода

В этом разделе представлены фрагменты кода и ссылки на реализации сервера и клиента.

<details>
<summary>Python</summary>

Смотрите [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) для полного описания реализации.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Продвинутые концепции в этом уроке

Перед началом разработки обратите внимание на важные продвинутые концепции, которые будут встречаться в этой главе. Их понимание поможет вам лучше ориентироваться, даже если вы с ними не знакомы:

- **Координация нескольких инструментов**: означает запуск нескольких разных инструментов (например, веб-поиска, новостей, поиска товаров и Q&A) в одном MCP-сервере. Это позволяет серверу выполнять разнообразные задачи, а не только одну.
- **Обработка ограничений API**: многие внешние API (как SerpAPI) ограничивают количество запросов за определённый промежуток времени. Хороший код проверяет эти лимиты и аккуратно с ними справляется, чтобы приложение не ломалось при достижении лимита.
- **Парсинг структурированных данных**: ответы API часто сложные и вложенные. Эта концепция — о преобразовании таких ответов в чистые и удобные форматы, подходящие для LLM или других программ.
- **Восстановление после ошибок**: иногда что-то идёт не так — сеть падает или API возвращает неожиданные данные. Восстановление после ошибок означает, что код умеет справляться с такими проблемами и выдавать полезные сообщения, а не падать.
- **Валидация параметров**: проверка правильности и безопасности всех входных данных для инструментов. Включает установку значений по умолчанию и проверку типов, что помогает избежать багов и недоразумений.

Этот раздел поможет вам диагностировать и решать распространённые проблемы, с которыми можно столкнуться при работе с MCP-сервером веб-поиска. Если вы столкнулись с ошибками или неожиданным поведением, сначала ознакомьтесь с этим разделом — советы часто помогают быстро решить проблему.

## Устранение неполадок

При работе с MCP-сервером веб-поиска иногда возникают проблемы — это нормально при разработке с внешними API и новыми инструментами. В этом разделе собраны практические решения самых частых проблем, чтобы вы могли быстро вернуться к работе. Если возникла ошибка, начните здесь: приведённые советы касаются наиболее распространённых ситуаций и часто позволяют решить проблему без дополнительной помощи.

### Частые проблемы

Ниже перечислены самые распространённые проблемы с понятными объяснениями и шагами для их решения:

1. **Отсутствует SERPAPI_KEY в файле .env**
   - Если вы видите ошибку `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your ``, создайте файл `.env`, если его нет. Если ключ введён верно, но ошибка сохраняется, проверьте, не исчерпан ли бесплатный лимит.

### Режим отладки

По умолчанию приложение логирует только важную информацию. Если хотите видеть больше деталей о происходящем (например, для диагностики сложных проблем), можно включить режим DEBUG. Он покажет гораздо больше информации на каждом шаге.

**Пример: обычный вывод**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Пример: вывод в режиме DEBUG**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Обратите внимание, что в режиме DEBUG добавляются строки с HTTP-запросами, ответами и другими внутренними деталями. Это очень помогает при устранении неполадок.

Чтобы включить режим DEBUG, установите уровень логирования в DEBUG в начале `client.py` or `server.py`:

<details>
<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## Что дальше

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия обеспечить точность, пожалуйста, имейте в виду, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.