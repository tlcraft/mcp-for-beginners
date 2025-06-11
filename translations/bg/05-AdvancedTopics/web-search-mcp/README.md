<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T16:26:40+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "bg"
}
-->
# Урок: Създаване на Web Search MCP сървър

Тази глава показва как да се изгради реален AI агент, който се интегрира с външни API-та, обработва различни типове данни, управлява грешки и координира множество инструменти – всичко това в готов за производство формат. Ще видите:

- **Интеграция с външни API-та, изискващи автентикация**
- **Обработка на различни типове данни от множество крайни точки**
- **Здрави стратегии за обработка на грешки и логване**
- **Координация на няколко инструмента в един сървър**

В края на урока ще имате практически опит с модели и добри практики, които са от съществено значение за напреднали AI и LLM-базирани приложения.

## Въведение

В този урок ще научите как да изградите напреднал MCP сървър и клиент, които разширяват възможностите на LLM с реално време уеб данни чрез SerpAPI. Това е ключово умение за разработване на динамични AI агенти, които могат да достъпват актуална информация от мрежата.

## Учебни цели

В края на този урок ще можете да:

- Интегрирате външни API-та (като SerpAPI) сигурно в MCP сървър
- Имплементирате множество инструменти за търсене в уеб, новини, продукти и въпроси и отговори
- Парсирате и форматирате структурирани данни за LLM
- Обработвате грешки и управлявате лимити на API повиквания ефективно
- Създавате и тествате както автоматизирани, така и интерактивни MCP клиенти

## Web Search MCP сървър

Този раздел представя архитектурата и функциите на Web Search MCP сървъра. Ще видите как FastMCP и SerpAPI работят заедно, за да разширят възможностите на LLM с уеб данни в реално време.

### Преглед

Тази имплементация включва четири инструмента, които демонстрират способността на MCP да обработва различни, външни API задачи сигурно и ефективно:

- **general_search**: За широки уеб резултати
- **news_search**: За последни новини
- **product_search**: За данни от електронна търговия
- **qna**: За въпроси и кратки отговори

### Функции
- **Примери с код**: Включва езиково-специфични кодови блокове за Python (и лесно разширими за други езици) с използване на свиваеми секции за яснота

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
- **Парсване на структурирани данни**: Показва как да се преобразуват отговорите на API в формати, подходящи за LLM
- **Обработка на грешки**: Здрава обработка на грешки с подходящо логване
- **Интерактивен клиент**: Включва както автоматизирани тестове, така и интерактивен режим за тестване
- **Управление на контекст**: Използва MCP Context за логване и проследяване на заявки

## Предварителни изисквания

Преди да започнете, уверете се, че средата ви е настроена правилно, като следвате тези стъпки. Това ще гарантира, че всички зависимости са инсталирани и вашите API ключове са конфигурирани коректно за безпроблемно разработване и тестване.

- Python 3.8 или по-нова версия
- SerpAPI API ключ (регистрирайте се на [SerpAPI](https://serpapi.com/) - има безплатен план)

## Инсталация

За да започнете, следвайте тези стъпки за настройка на средата:

1. Инсталирайте зависимостите чрез uv (препоръчително) или pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Създайте `.env` файл в основната папка на проекта с вашия SerpAPI ключ:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Използване

Web Search MCP сървърът е основният компонент, който предоставя инструменти за търсене в уеб, новини, продукти и въпроси и отговори чрез интеграция с SerpAPI. Той обработва входящи заявки, управлява API повиквания, парсира отговорите и връща структурирани резултати към клиента.

Можете да разгледате пълната имплементация в [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Стартиране на сървъра

За да стартирате MCP сървъра, използвайте следната команда:

```bash
python server.py
```

Сървърът ще работи като stdio-базиран MCP сървър, към който клиентът може да се свърже директно.

### Режими на клиента

Клиентът (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Стартиране на клиента

За да стартирате автоматизираните тестове (това автоматично стартира сървъра):

```bash
python client.py
```

Или стартирайте в интерактивен режим:

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

В този контекст „тестов скрипт“ означава персонализирана Python програма, която пишете, за да действа като клиент към MCP сървъра. Вместо формален модулен тест, този скрипт ви позволява програмно да се свързвате със сървъра, да извиквате някой от инструментите с параметри по ваш избор и да разглеждате резултатите. Този подход е полезен за:
- Прототипиране и експериментиране с повиквания на инструменти
- Валидиране на реакцията на сървъра към различни входни данни
- Автоматизиране на многократни повиквания на инструменти
- Създаване на собствени работни процеси или интеграции върху MCP сървъра

Можете да използвате тестови скриптове, за да пробвате нови заявки, да отстраните грешки в поведението на инструментите или дори като отправна точка за по-сложна автоматизация. По-долу е пример как да използвате MCP Python SDK за създаване на такъв скрипт:

## Описания на инструментите

Можете да използвате следните инструменти, предоставени от сървъра, за извършване на различни видове търсения и заявки. Всеки инструмент е описан по-долу с параметрите и примерната употреба.

Този раздел предоставя подробности за всеки наличен инструмент и техните параметри.

### general_search

Извършва общо търсене в уеб и връща форматирани резултати.

**Как да извикате този инструмент:**

Можете да извикате `general_search` от свой скрипт, използвайки MCP Python SDK, или интерактивно чрез Inspector или интерактивния режим на клиента. Ето примерен код с SDK:

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

Алтернативно, в интерактивен режим изберете `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Търсена заявка

**Примерна заявка:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Търси последни новинарски статии, свързани с дадена заявка.

**Как да извикате този инструмент:**

Можете да извикате `news_search` от свой скрипт, използвайки MCP Python SDK, или интерактивно чрез Inspector или интерактивния режим на клиента. Ето примерен код с SDK:

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

Алтернативно, в интерактивен режим изберете `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Търсена заявка

**Примерна заявка:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Търси продукти, съвпадащи с дадена заявка.

**Как да извикате този инструмент:**

Можете да извикате `product_search` от свой скрипт, използвайки MCP Python SDK, или интерактивно чрез Inspector или интерактивния режим на клиента. Ето примерен код с SDK:

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

Алтернативно, в интерактивен режим изберете `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Търсена заявка за продукт

**Примерна заявка:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Връща директни отговори на въпроси от търсачки.

**Как да извикате този инструмент:**

Можете да извикате `qna` от свой скрипт, използвайки MCP Python SDK, или интерактивно чрез Inspector или интерактивния режим на клиента. Ето примерен код с SDK:

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

Алтернативно, в интерактивен режим изберете `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Въпрос, за който търсите отговор

**Примерна заявка:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Детайли по кода

Този раздел предоставя кодови фрагменти и препратки за имплементациите на сървъра и клиента.

<details>
<summary>Python</summary>

Вижте [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) за пълни детайли на имплементацията.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Напреднали концепции в този урок

Преди да започнете изграждането, ето някои важни напреднали концепции, които ще се появяват през цялата глава. Разбирането им ще ви помогне да следите урока, дори ако са нови за вас:

- **Координация на няколко инструмента**: Това означава да се управляват няколко различни инструмента (като уеб търсене, новини, продукти и въпроси и отговори) в един MCP сървър. Позволява на сървъра ви да се справя с разнообразни задачи, а не само с една.
- **Обработка на лимити на API повиквания**: Много външни API-та (като SerpAPI) ограничават броя на заявките за определено време. Добър код проверява тези лимити и ги обработва елегантно, така че приложението ви да не се срине при достигане на лимит.
- **Парсване на структурирани данни**: Отговорите на API често са сложни и вложени. Тази концепция е за превръщане на тези отговори в чисти, лесни за използване формати, подходящи за LLM или други програми.
- **Възстановяване при грешки**: Понякога нещата се объркват – може мрежата да се провали или API-то да не върне очакваното. Възстановяването при грешки означава, че кодът ви може да се справи с тези проблеми и все пак да даде полезна обратна връзка, вместо да се срине.
- **Валидация на параметрите**: Това е за проверка, че всички входни данни към инструментите са правилни и безопасни за използване. Включва задаване на стойности по подразбиране и проверка на типовете, което помага за предотвратяване на грешки и объркване.

Този раздел ще ви помогне да диагностицирате и разрешите често срещани проблеми, които може да срещнете при работа с Web Search MCP сървъра. Ако се сблъскате с грешки или неочаквано поведение, този раздел за отстраняване на проблеми предлага решения на най-честите проблеми. Прегледайте тези съвети преди да търсите допълнителна помощ – те често решават проблемите бързо.

## Отстраняване на проблеми

При работа с Web Search MCP сървъра понякога може да срещнете проблеми – това е нормално при разработка с външни API-та и нови инструменти. Този раздел предлага практични решения на най-честите проблеми, за да можете бързо да продължите напред. Ако срещнете грешка, започнете от тук: съветите по-долу адресират проблемите, с които повечето потребители се сблъскват, и често могат да решат проблема без допълнителна помощ.

### Често срещани проблеми

По-долу са някои от най-често срещаните проблеми, с които потребителите се сблъскват, заедно с ясни обяснения и стъпки за решаването им:

1. **Липсва SERPAPI_KEY в .env файла**
   - Ако видите грешка `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` файл, го създайте ако липсва. Ако ключът ви е правилен, но все още виждате тази грешка, проверете дали безплатният ви план не е изчерпал квотата.

### Режим за отстраняване на грешки (Debug)

По подразбиране приложението логва само важна информация. Ако искате да видите повече детайли за това, което се случва (например за диагностика на сложни проблеми), можете да активирате DEBUG режим. Това ще ви покаже много повече за всяка стъпка, която приложението извършва.

**Пример: Нормален изход**
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

Обърнете внимание как DEBUG режим включва допълнителни редове за HTTP заявки, отговори и други вътрешни детайли. Това може да е много полезно при отстраняване на проблеми.

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

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или погрешни тълкувания, произтичащи от използването на този превод.