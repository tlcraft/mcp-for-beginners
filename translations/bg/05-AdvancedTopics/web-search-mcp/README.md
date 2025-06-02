<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T19:34:59+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "bg"
}
-->
# Lesson: Създаване на Web Search MCP сървър

Тази глава показва как да се създаде реален AI агент, който се интегрира с външни API-та, обработва различни типове данни, управлява грешки и координира множество инструменти – всичко това в готов за продукция формат. Ще видите:

- **Интеграция с външни API-та, изискващи автентикация**
- **Обработка на различни типове данни от множество крайни точки**
- **Надеждни стратегии за обработка на грешки и логване**
- **Оркестрация на няколко инструмента в един сървър**

В края ще имате практическо преживяване с модели и най-добри практики, които са от съществено значение за напреднали AI и приложения, базирани на LLM.

## Въведение

В този урок ще научите как да създадете напреднал MCP сървър и клиент, които разширяват възможностите на LLM с данни в реално време от уеб чрез SerpAPI. Това е ключово умение за разработка на динамични AI агенти, които могат да достъпват актуална информация от интернет.

## Учебни цели

В края на урока ще можете да:

- Интегрирате външни API-та (като SerpAPI) сигурно в MCP сървър
- Изпълнявате няколко инструмента за търсене в уеб, новини, продукти и въпроси и отговори
- Парсирате и форматирате структурирани данни за използване от LLM
- Обработвате грешки и управлявате ефективно ограниченията на API заявките
- Създавате и тествате както автоматизирани, така и интерактивни MCP клиенти

## Web Search MCP сървър

Тази секция представя архитектурата и функциите на Web Search MCP сървъра. Ще видите как FastMCP и SerpAPI се използват заедно, за да разширят възможностите на LLM с данни от уеб в реално време.

### Преглед

Тази имплементация включва четири инструмента, които демонстрират способността на MCP да обработва разнообразни задачи, базирани на външни API-та, сигурно и ефективно:

- **general_search**: За широки уеб резултати
- **news_search**: За последни новинарски заглавия
- **product_search**: За данни от електронна търговия
- **qna**: За въпроси и отговори

### Функционалности
- **Примери с код**: Включва езиково специфични блокове с код за Python (и лесно разширяеми към други езици) с използване на свиваеми секции за по-голяма яснота

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

Преди да стартирате клиента, полезно е да разберете какво прави сървърът. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Ето кратък пример как сървърът дефинира и регистрира инструмент:

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

- **Интеграция с външни API-та**: Демонстрира сигурно управление на API ключове и външни заявки
- **Парсиране на структурирани данни**: Показва как да се трансформират отговори от API в удобни за LLM формати
- **Обработка на грешки**: Надеждна обработка на грешки с подходящо логване
- **Интерактивен клиент**: Включва както автоматизирани тестове, така и интерактивен режим за тестване
- **Управление на контекст**: Използва MCP Context за логване и проследяване на заявки

## Предварителни изисквания

Преди да започнете, уверете се, че средата ви е настроена правилно, като следвате тези стъпки. Това ще гарантира, че всички зависимости са инсталирани и вашите API ключове са конфигурирани коректно за безпроблемна разработка и тестване.

- Python 3.8 или по-нова версия
- SerpAPI API ключ (Регистрация на [SerpAPI](https://serpapi.com/) – има безплатен план)

## Инсталация

За да започнете, следвайте тези стъпки за настройка на средата:

1. Инсталирайте зависимости чрез uv (препоръчително) или pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Създайте `.env` файл в корена на проекта с вашия SerpAPI ключ:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Използване

Web Search MCP сървърът е основният компонент, който предоставя инструменти за търсене в уеб, новини, продукти и въпроси и отговори чрез интеграция със SerpAPI. Той обработва входящи заявки, управлява API повиквания, парсира отговори и връща структурирани резултати на клиента.

Можете да разгледате пълната имплементация в [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Стартиране на сървъра

За да стартирате MCP сървъра, използвайте следната команда:

```bash
python server.py
```

Сървърът ще работи като MCP сървър базиран на stdio, към който клиентът може да се свърже директно.

### Режими на клиента

Клиентът (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Стартиране на клиента

За да стартирате автоматизираните тестове (това ще стартира сървъра автоматично):

```bash
python client.py
```

Или в интерактивен режим:

```bash
python client.py --interactive
```

### Тестване с различни методи

Има няколко начина да тествате и взаимодействате с инструментите, предоставени от сървъра, в зависимост от вашите нужди и работен процес.

#### Писане на персонализирани тестови скриптове с MCP Python SDK
Можете също да създадете свои тестови скриптове, използвайки MCP Python SDK:

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

В този контекст „тестов скрипт“ означава персонализирана Python програма, която пишете, за да действа като клиент на MCP сървъра. Вместо да е формален модулен тест, този скрипт ви позволява програмно да се свържете със сървъра, да извиквате някой от инструментите му с избрани от вас параметри и да преглеждате резултатите. Този подход е полезен за:
- Прототипиране и експериментиране с извиквания на инструменти
- Проверка на отговорите на сървъра при различни входни данни
- Автоматизиране на повтарящи се извиквания на инструменти
- Създаване на собствени работни процеси или интеграции върху MCP сървъра

Можете да използвате тестови скриптове, за да изпробвате бързо нови заявки, да отстраните проблеми с поведението на инструментите или дори като отправна точка за по-сложна автоматизация. По-долу е пример как да използвате MCP Python SDK за създаване на такъв скрипт:

## Описания на инструментите

Можете да използвате следните инструменти, предоставени от сървъра, за извършване на различни видове търсения и заявки. Всеки инструмент е описан по-долу с неговите параметри и пример за използване.

Тази секция предоставя подробности за всеки наличен инструмент и техните параметри.

### general_search

Извършва общо търсене в уеб и връща форматирани резултати.

**Как да извикате този инструмент:**

Можете да извикате `general_search` от собствен скрипт, използвайки MCP Python SDK, или интерактивно чрез Inspector или интерактивния режим на клиента. Ето пример с код, използващ SDK:

<details>
<summary>Python пример</summary>

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

Или в интерактивен режим изберете `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Търсена заявка

**Примерна заявка:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Търси за последни новинарски статии, свързани с заявка.

**Как да извикате този инструмент:**

Можете да извикате `news_search` от собствен скрипт, използвайки MCP Python SDK, или интерактивно чрез Inspector или интерактивния режим на клиента. Ето пример с код, използващ SDK:

<details>
<summary>Python пример</summary>

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

Или в интерактивен режим изберете `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Търсена заявка

**Примерна заявка:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Търси продукти, съвпадащи с заявка.

**Как да извикате този инструмент:**

Можете да извикате `product_search` от собствен скрипт, използвайки MCP Python SDK, или интерактивно чрез Inspector или интерактивния режим на клиента. Ето пример с код, използващ SDK:

<details>
<summary>Python пример</summary>

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

Или в интерактивен режим изберете `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Търсена заявка за продукт

**Примерна заявка:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Получава директни отговори на въпроси от търсачки.

**Как да извикате този инструмент:**

Можете да извикате `qna` от собствен скрипт, използвайки MCP Python SDK, или интерактивно чрез Inspector или интерактивния режим на клиента. Ето пример с код, използващ SDK:

<details>
<summary>Python пример</summary>

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

Или в интерактивен режим изберете `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Въпрос, за който търсите отговор

**Примерна заявка:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Подробности за кода

Тази секция предоставя фрагменти от код и препратки за имплементациите на сървъра и клиента.

<details>
<summary>Python</summary>

Вижте [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) за пълни детайли по имплементацията.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Разширени концепции в този урок

Преди да започнете с изграждането, ето някои важни разширени концепции, които ще се появяват през цялата глава. Разбирането им ще ви помогне да следите материала, дори ако са нови за вас:

- **Оркестрация на множество инструменти**: Това означава да стартирате няколко различни инструмента (като уеб търсене, новини, продукти и въпроси и отговори) в един MCP сървър. Това позволява на сървъра да обработва разнообразни задачи, не само една.
- **Управление на ограниченията на API**: Много външни API-та (като SerpAPI) ограничават колко заявки можете да правите за определено време. Добре написан код проверява тези ограничения и ги обработва плавно, така че приложението ви да не се срине, ако достигнете лимит.
- **Парсиране на структурирани данни**: Отговорите от API често са сложни и вложени. Тази концепция се отнася до преобразуването на тези отговори в чисти, лесни за използване формати, удобни за LLM или други програми.
- **Възстановяване при грешки**: Понякога нещата се объркват – например мрежата спира да работи или API не връща очакваното. Възстановяването при грешки означава, че кодът ви може да се справи с тези проблеми и все пак да даде полезна обратна връзка, вместо да се срива.
- **Валидация на параметрите**: Това е свързано с проверката дали всички входни данни за инструментите са коректни и безопасни за използване. Включва задаване на стойности по подразбиране и гарантиране на правилните типове, което помага да се избегнат грешки и объркване.

Тази секция ще ви помогне да диагностицирате и решите често срещани проблеми, с които може да се сблъскате при работа с Web Search MCP сървъра. Ако срещнете грешки или неочаквано поведение, този раздел предлага решения на най-честите проблеми. Прегледайте тези съвети преди да потърсите допълнителна помощ – те често решават проблемите бързо.

## Отстраняване на проблеми

При работа с Web Search MCP сървъра може да срещнете проблеми – това е нормално при разработка с външни API-та и нови инструменти. Тази секция предоставя практически решения на най-честите проблеми, за да можете бързо да се върнете към работа. Ако получите грешка, започнете от тук: съветите по-долу адресират проблемите, с които повечето потребители се сблъскват, и често решават проблема без допълнителна помощ.

### Чести проблеми

По-долу са някои от най-често срещаните проблеми, с които потребителите се сблъскват, заедно с ясни обяснения и стъпки за разрешаване:

1. **Липсва SERPAPI_KEY в .env файла**
   - Ако видите грешка `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` файл ако е необходимо. Ако ключът ви е правилен, но все още виждате тази грешка, проверете дали безплатният ви план не е изчерпал квотата.

### Режим за отстраняване на грешки (Debug Mode)

По подразбиране приложението записва само важна информация. Ако искате да видите повече детайли за случващото се (например за диагностициране на трудни проблеми), можете да активирате DEBUG режим. Това ще ви покаже много повече за всяка стъпка, която приложението извършва.

**Пример: Обичаен изход**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Пример: DEBUG изход**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Забележете как DEBUG режим включва допълнителни редове за HTTP заявки, отговори и други вътрешни детайли. Това може да бъде много полезно при отстраняване на проблеми.

За да активирате DEBUG режим, задайте нивото на логване на DEBUG в началото на вашия `client.py` or `server.py`:

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

## Какво следва

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля имайте предвид, че автоматизираните преводи може да съдържат грешки или неточности. Оригиналният документ на неговия оригинален език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или погрешни тълкувания, възникнали в резултат на използването на този превод.