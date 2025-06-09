<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T18:21:16+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ru"
}
-->
# Урок: Создание MCP сервера для веб-поиска

В этой главе показано, как создать реального AI-агента, который интегрируется с внешними API, обрабатывает разные типы данных, управляет ошибками и координирует работу нескольких инструментов — всё в формате, готовом к промышленному использованию. Вы узнаете:

- **Интеграция с внешними API, требующими аутентификации**
- **Обработка различных типов данных с нескольких конечных точек**
- **Надёжные стратегии обработки ошибок и логирования**
- **Оркестрация нескольких инструментов в одном сервере**

К концу урока у вас будет практический опыт работы с шаблонами и лучшими практиками, необходимыми для продвинутых AI-приложений на базе LLM.

## Введение

В этом уроке вы научитесь создавать продвинутый MCP сервер и клиент, расширяющие возможности LLM за счёт данных из веба в реальном времени с использованием SerpAPI. Это важный навык для разработки динамичных AI-агентов, способных получать актуальную информацию из интернета.

## Цели обучения

К концу урока вы сможете:

- Безопасно интегрировать внешние API (например, SerpAPI) в MCP сервер
- Реализовать несколько инструментов для поиска в интернете, новостей, товаров и вопросов-ответов
- Парсить и форматировать структурированные данные для использования LLM
- Эффективно обрабатывать ошибки и управлять лимитами API
- Создавать и тестировать как автоматизированных, так и интерактивных MCP клиентов

## MCP сервер веб-поиска

В этом разделе представлена архитектура и возможности MCP сервера веб-поиска. Вы увидите, как FastMCP и SerpAPI используются вместе для расширения возможностей LLM данными из интернета в реальном времени.

### Обзор

В реализации используются четыре инструмента, демонстрирующие способность MCP безопасно и эффективно обрабатывать разнообразные задачи, основанные на внешних API:

- **general_search**: Для широкого веб-поиска
- **news_search**: Для свежих новостных заголовков
- **product_search**: Для данных электронной коммерции
- **qna**: Для получения ответов на вопросы

### Особенности
- **Примеры кода**: Включены блоки кода на Python (и легко расширяемые на другие языки) с использованием сворачиваемых секций для удобства

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

Ниже приведён краткий пример того, как сервер определяет и регистрирует инструмент:

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

- **Интеграция с внешними API**: Демонстрирует безопасную работу с API ключами и внешними запросами
- **Парсинг структурированных данных**: Показывает, как преобразовать ответы API в удобные для LLM форматы
- **Обработка ошибок**: Надёжная обработка ошибок с соответствующим логированием
- **Интерактивный клиент**: Включает как автоматические тесты, так и интерактивный режим для тестирования
- **Управление контекстом**: Использует MCP Context для логирования и отслеживания запросов

## Требования

Перед началом убедитесь, что ваша среда настроена правильно, выполнив следующие шаги. Это гарантирует установку всех зависимостей и корректную настройку API ключей для беспроблемной разработки и тестирования.

- Python 3.8 или выше
- API ключ SerpAPI (зарегистрируйтесь на [SerpAPI](https://serpapi.com/) — доступен бесплатный тариф)

## Установка

Чтобы начать, выполните следующие шаги для настройки среды:

1. Установите зависимости с помощью uv (рекомендуется) или pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Создайте файл `.env` в корне проекта и добавьте в него ваш ключ SerpAPI:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Использование

MCP сервер веб-поиска — это основной компонент, который предоставляет инструменты для поиска в интернете, новостей, товаров и вопросов-ответов, интегрируясь с SerpAPI. Он обрабатывает входящие запросы, управляет вызовами API, парсит ответы и возвращает структурированные результаты клиенту.

Полную реализацию можно посмотреть в [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Запуск сервера

Чтобы запустить MCP сервер, используйте следующую команду:

```bash
python server.py
```

Сервер будет работать как MCP сервер на основе stdio, к которому клиент может подключаться напрямую.

### Режимы клиента

Клиент (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Запуск клиента

Для запуска автоматических тестов (это автоматически запустит сервер):

```bash
python client.py
```

Или запустите в интерактивном режиме:

```bash
python client.py --interactive
```

### Тестирование разными способами

Существует несколько способов тестирования и взаимодействия с инструментами сервера в зависимости от ваших потребностей и рабочего процесса.

#### Написание собственных тестовых скриптов с MCP Python SDK
Вы также можете создавать свои тестовые скрипты, используя MCP Python SDK:

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

В данном контексте «тестовый скрипт» — это пользовательская программа на Python, которую вы пишете как клиента для MCP сервера. Вместо формального модульного теста этот скрипт позволяет программно подключаться к серверу, вызывать любые инструменты с нужными параметрами и изучать результаты. Такой подход полезен для:
- Прототипирования и экспериментов с вызовами инструментов
- Проверки, как сервер реагирует на разные входные данные
- Автоматизации повторных вызовов инструментов
- Создания собственных рабочих процессов или интеграций поверх MCP сервера

Тестовые скрипты позволяют быстро пробовать новые запросы, отлаживать поведение инструментов или служить отправной точкой для более сложной автоматизации. Ниже пример использования MCP Python SDK для создания такого скрипта:

## Описание инструментов

Вы можете использовать следующие инструменты, предоставляемые сервером, для различных видов поиска и запросов. Каждый инструмент описан ниже с параметрами и примером использования.

В этом разделе приведены детали каждого доступного инструмента и их параметры.

### general_search

Выполняет общий веб-поиск и возвращает отформатированные результаты.

**Как вызвать этот инструмент:**

Вы можете вызвать `general_search` из своего скрипта с помощью MCP Python SDK или интерактивно через Inspector или интерактивный режим клиента. Пример кода с использованием SDK:

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

Ищет последние новости по запросу.

**Как вызвать этот инструмент:**

Вы можете вызвать `news_search` из своего скрипта с помощью MCP Python SDK или интерактивно через Inspector или интерактивный режим клиента. Пример кода с использованием SDK:

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

Вы можете вызвать `product_search` из своего скрипта с помощью MCP Python SDK или интерактивно через Inspector или интерактивный режим клиента. Пример кода с использованием SDK:

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
- `query` (строка): запрос для поиска товара

**Пример запроса:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Получает прямые ответы на вопросы из поисковых систем.

**Как вызвать этот инструмент:**

Вы можете вызвать `qna` из своего скрипта с помощью MCP Python SDK или интерактивно через Inspector или интерактивный режим клиента. Пример кода с использованием SDK:

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
- `question` (строка): вопрос для поиска ответа

**Пример запроса:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Детали кода

В этом разделе приведены фрагменты кода и ссылки на реализации сервера и клиента.

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

Перед тем как начать разработку, ознакомьтесь с важными продвинутыми концепциями, которые будут встречаться в этой главе. Понимание их поможет вам лучше следить за материалом, даже если вы с ними не знакомы:

- **Оркестрация нескольких инструментов**: Запуск нескольких разных инструментов (например, веб-поиск, новости, поиск товаров и вопросы-ответы) в одном MCP сервере. Это позволяет серверу выполнять разнообразные задачи, а не только одну.
- **Обработка лимитов API**: Многие внешние API (как SerpAPI) ограничивают количество запросов за определённое время. Хороший код проверяет эти лимиты и корректно с ними работает, чтобы приложение не ломалось при достижении лимита.
- **Парсинг структурированных данных**: Ответы API часто сложные и вложенные. Эта концепция — о том, как преобразовать такие ответы в чистые, удобные форматы, которые легко использовать LLM или другим программам.
- **Восстановление после ошибок**: Иногда что-то идёт не так — например, сбой сети или неожиданный ответ API. Восстановление после ошибок означает, что ваш код может обработать эти проблемы и предоставить полезную информацию, а не аварийно завершиться.
- **Проверка параметров**: Это проверка, что все входные данные в ваши инструменты корректны и безопасны. Включает установку значений по умолчанию и проверку типов, что помогает избежать ошибок и недоразумений.

Этот раздел поможет вам диагностировать и решать типичные проблемы, с которыми вы можете столкнуться при работе с MCP сервером веб-поиска. Если вы столкнулись с ошибками или неожиданным поведением, начните с этого раздела — здесь есть решения для самых распространённых проблем, которые часто позволяют быстро исправить ситуацию.

## Устранение неполадок

При работе с MCP сервером веб-поиска время от времени могут возникать проблемы — это нормально при разработке с внешними API и новыми инструментами. В этом разделе приведены практические решения самых распространённых проблем, чтобы вы могли быстро вернуться к работе. Если вы столкнулись с ошибкой, начните здесь: советы ниже охватывают проблемы, с которыми чаще всего сталкиваются пользователи, и часто позволяют решить их без дополнительной помощи.

### Распространённые проблемы

Ниже приведены некоторые из самых частых проблем, с которыми сталкиваются пользователи, вместе с понятными объяснениями и шагами для их решения:

1. **Отсутствует SERPAPI_KEY в файле .env**
   - Если вы видите ошибку `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env`, создайте файл `.env`, если он отсутствует. Если ключ правильный, но ошибка сохраняется, проверьте, не исчерпан ли бесплатный лимит.

### Режим отладки

По умолчанию приложение логирует только важную информацию. Если вы хотите видеть больше деталей о происходящем (например, для диагностики сложных проблем), включите режим DEBUG. Он покажет гораздо больше информации о каждом шаге приложения.

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

Обратите внимание, что в режиме DEBUG выводятся дополнительные строки о HTTP-запросах, ответах и других внутренних деталях. Это очень помогает при отладке.

Чтобы включить режим DEBUG, установите уровень логирования в DEBUG в начале вашего `client.py` or `server.py`:

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

- [6. Вклад сообщества](../../06-CommunityContributions/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия обеспечить точность, пожалуйста, учитывайте, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на исходном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.