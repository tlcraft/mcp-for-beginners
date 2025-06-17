<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-17T16:53:35+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "uk"
}
-->
# Урок: Створення MCP-сервера для веб-пошуку

У цьому розділі показано, як створити реального AI-агента, який інтегрується з зовнішніми API, обробляє різні типи даних, керує помилками та координує роботу кількох інструментів — все це у форматі, готовому до використання в продакшені. Ви дізнаєтеся про:

- **Інтеграцію з зовнішніми API, що потребують автентифікації**
- **Обробку різноманітних типів даних з кількох кінцевих точок**
- **Надійне оброблення помилок та стратегії логування**
- **Оркестрацію кількох інструментів в одному сервері**

До кінця уроку ви отримаєте практичний досвід роботи з патернами та кращими практиками, які є необхідними для просунутих AI-додатків на базі LLM.

## Вступ

У цьому уроці ви навчитеся створювати просунутий MCP-сервер і клієнта, які розширюють можливості LLM за допомогою даних з вебу в реальному часі через SerpAPI. Це критично важлива навичка для розробки динамічних AI-агентів, які можуть отримувати актуальну інформацію з інтернету.

## Цілі навчання

Після проходження цього уроку ви зможете:

- Безпечно інтегрувати зовнішні API (наприклад, SerpAPI) у MCP-сервер
- Реалізувати кілька інструментів для веб-пошуку, новин, пошуку товарів та Q&A
- Парсити та форматувати структуровані дані для використання LLM
- Ефективно обробляти помилки та керувати обмеженнями API
- Створювати та тестувати як автоматизованих, так і інтерактивних MCP-клієнтів

## MCP-сервер для веб-пошуку

У цьому розділі розглядається архітектура та функції MCP-сервера для веб-пошуку. Ви побачите, як FastMCP і SerpAPI працюють разом, щоб розширити можливості LLM за допомогою даних з вебу в реальному часі.

### Огляд

Ця реалізація містить чотири інструменти, які демонструють здатність MCP безпечно і ефективно виконувати різноманітні завдання, що базуються на зовнішніх API:

- **general_search**: для широкого веб-пошуку
- **news_search**: для останніх новинних заголовків
- **product_search**: для даних електронної комерції
- **qna**: для отримання відповідей на запитання

### Особливості
- **Приклади коду**: включає мовозалежні блоки коду для Python (та легко розширювані на інші мови) з використанням розгортальних секцій для зручності

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

Перед запуском клієнта корисно розібратися, що робить сервер. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Нижче наведено короткий приклад того, як сервер визначає та реєструє інструмент:

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

- **Інтеграція зовнішніх API**: демонструє безпечне керування API-ключами та зовнішніми запитами
- **Парсинг структурованих даних**: показує, як перетворювати відповіді API у формати, зручні для LLM
- **Обробка помилок**: надійне опрацювання помилок з відповідним логуванням
- **Інтерактивний клієнт**: включає як автоматизовані тести, так і інтерактивний режим для тестування
- **Керування контекстом**: використовує MCP Context для логування та відстеження запитів

## Вимоги

Перед початком переконайтеся, що ваше середовище налаштоване відповідно, виконавши наведені кроки. Це гарантує, що всі залежності встановлені, а ваші API-ключі налаштовані правильно для безперебійної розробки та тестування.

- Python 3.8 або вище
- API-ключ SerpAPI (зареєструйтесь на [SerpAPI](https://serpapi.com/) — доступний безкоштовний тариф)

## Встановлення

Щоб розпочати, виконайте наступні кроки для налаштування середовища:

1. Встановіть залежності за допомогою uv (рекомендовано) або pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Створіть файл `.env` у корені проекту з вашим ключем SerpAPI:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Використання

MCP-сервер для веб-пошуку — це основний компонент, який надає інструменти для пошуку в інтернеті, новин, товарів та Q&A через інтеграцію з SerpAPI. Він обробляє вхідні запити, керує викликами API, парсить відповіді та повертає структуровані результати клієнту.

Повну реалізацію можна переглянути у файлі [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Запуск сервера

Щоб запустити MCP-сервер, використайте таку команду:

```bash
python server.py
```

Сервер працюватиме як MCP-сервер на основі stdio, до якого клієнт може підключатися безпосередньо.

### Режими клієнта

Клієнт (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Запуск клієнта

Для запуску автоматизованих тестів (сервер буде запущено автоматично):

```bash
python client.py
```

Або запустіть у інтерактивному режимі:

```bash
python client.py --interactive
```

### Тестування різними способами

Існує кілька способів протестувати та взаємодіяти з інструментами сервера залежно від ваших потреб і робочого процесу.

#### Написання власних тестових скриптів з MCP Python SDK
Ви також можете створювати власні тестові скрипти, використовуючи MCP Python SDK:

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

У цьому контексті "тестовий скрипт" означає власну програму на Python, яку ви пишете, щоб виступати в ролі клієнта MCP-сервера. Замість формального юніт-тесту цей скрипт дозволяє програмно підключатися до сервера, викликати будь-який із його інструментів із потрібними параметрами та переглядати результати. Цей підхід корисний для:
- Прототипування та експериментів із викликами інструментів
- Перевірки реакції сервера на різні вхідні дані
- Автоматизації повторюваних викликів інструментів
- Побудови власних робочих процесів або інтеграцій поверх MCP-сервера

Ви можете використовувати тестові скрипти для швидкого опрацювання нових запитів, налагодження поведінки інструментів або як точку відліку для складнішої автоматизації. Нижче наведено приклад використання MCP Python SDK для створення такого скрипта:

## Опис інструментів

Ви можете використовувати наступні інструменти, які надає сервер, для виконання різних типів пошуку та запитів. Кожен інструмент описано нижче з параметрами та прикладами використання.

Цей розділ містить деталі про кожен доступний інструмент та їх параметри.

### general_search

Виконує загальний веб-пошук і повертає відформатовані результати.

**Як викликати цей інструмент:**

Ви можете викликати `general_search` зі свого скрипта, використовуючи MCP Python SDK, або інтерактивно через Inspector чи інтерактивний режим клієнта. Ось приклад коду з SDK:

<details>
<summary>Приклад на Python</summary>

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

Або в інтерактивному режимі виберіть `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (рядок): пошуковий запит

**Приклад запиту:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Шукає останні новинні статті за запитом.

**Як викликати цей інструмент:**

Ви можете викликати `news_search` зі свого скрипта, використовуючи MCP Python SDK, або інтерактивно через Inspector чи інтерактивний режим клієнта. Ось приклад коду з SDK:

<details>
<summary>Приклад на Python</summary>

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

Або в інтерактивному режимі виберіть `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (рядок): пошуковий запит

**Приклад запиту:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Шукає товари, що відповідають запиту.

**Як викликати цей інструмент:**

Ви можете викликати `product_search` зі свого скрипта, використовуючи MCP Python SDK, або інтерактивно через Inspector чи інтерактивний режим клієнта. Ось приклад коду з SDK:

<details>
<summary>Приклад на Python</summary>

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

Або в інтерактивному режимі виберіть `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (рядок): пошуковий запит товару

**Приклад запиту:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Отримує прямі відповіді на запитання з пошукових систем.

**Як викликати цей інструмент:**

Ви можете викликати `qna` зі свого скрипта, використовуючи MCP Python SDK, або інтерактивно через Inspector чи інтерактивний режим клієнта. Ось приклад коду з SDK:

<details>
<summary>Приклад на Python</summary>

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

Або в інтерактивному режимі виберіть `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (рядок): питання, на яке потрібно знайти відповідь

**Приклад запиту:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Деталі коду

У цьому розділі наведено фрагменти коду та посилання на реалізації сервера і клієнта.

<details>
<summary>Python</summary>

Дивіться [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) для повних деталей реалізації.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Просунуті концепції цього уроку

Перед тим як почати розробку, ознайомтеся з важливими просунутими концепціями, які будуть зустрічатися впродовж цього розділу. Розуміння їх допоможе вам краще слідкувати за матеріалом, навіть якщо ви з ними раніше не стикалися:

- **Оркестрація кількох інструментів**: означає одночасну роботу кількох різних інструментів (веб-пошук, новини, пошук товарів, Q&A) у межах одного MCP-сервера. Це дозволяє серверу виконувати різноманітні завдання, а не лише одне.
- **Обробка обмежень API (Rate Limit)**: багато зовнішніх API (як SerpAPI) обмежують кількість запитів за певний час. Хороший код перевіряє ці обмеження і коректно їх обробляє, щоб ваш додаток не зламався при досягненні ліміту.
- **Парсинг структурованих даних**: відповіді API часто складні і вкладені. Ця концепція полягає у перетворенні таких відповідей у чисті, зручні формати, дружні до LLM або інших програм.
- **Відновлення після помилок**: іноді щось йде не так — наприклад, мережа відмовляє або API повертає неочікувані дані. Відновлення означає, що ваш код може опрацьовувати такі проблеми і все одно надавати корисний відгук замість аварійного завершення.
- **Валідація параметрів**: перевірка, що всі вхідні дані для ваших інструментів є правильними і безпечними. Включає встановлення значень за замовчуванням та перевірку типів, що допомагає уникнути багів і плутанини.

Цей розділ допоможе вам діагностувати та вирішувати поширені проблеми, з якими ви можете зіткнутися під час роботи з MCP-сервером для веб-пошуку. Якщо ви натрапили на помилки або несподівану поведінку, ця секція надасть рішення для найбільш поширених випадків. Ознайомтеся з цими порадами перед тим, як звертатися за додатковою допомогою — вони часто допомагають швидко вирішити проблему.

## Вирішення проблем

Під час роботи з MCP-сервером для веб-пошуку ви іноді можете стикатися з проблемами — це нормально при розробці з використанням зовнішніх API та нових інструментів. У цьому розділі наведено практичні рішення для найпоширеніших проблем, щоб ви могли швидко повернутися до роботи. Якщо ви отримали помилку, почніть звідси: наведені нижче поради охоплюють проблеми, з якими найчастіше стикаються користувачі, і часто дозволяють вирішити їх без додаткової допомоги.

### Поширені проблеми

Нижче наведено деякі з найпоширеніших проблем, з якими стикаються користувачі, разом із чіткими поясненнями та кроками для їх усунення:

1. **Відсутній SERPAPI_KEY у файлі .env**
   - Якщо ви бачите помилку `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env`, створіть файл `.env` із вашим ключем. Якщо ключ правильний, але помилка залишається, перевірте, чи не вичерпано ліміт безкоштовного тарифу.

### Режим налагодження (Debug Mode)

За замовчуванням додаток логуватиме лише важливу інформацію. Якщо хочете бачити більше деталей про те, що відбувається (наприклад, для діагностики складних проблем), можна увімкнути режим DEBUG. Це покаже значно більше інформації про кожен крок роботи додатка.

**Приклад: звичайний вивід**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Приклад: вивід у режимі DEBUG**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Зверніть увагу, що режим DEBUG включає додаткові рядки про HTTP-запити, відповіді та інші внутрішні деталі. Це дуже корисно для налагодження.

Щоб увімкнути режим DEBUG, встановіть рівень логування на DEBUG у верхній частині вашого `client.py` or `server.py`:

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

## Що далі

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.