<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:26:24+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "bg"
}
-->
# Lesson: Създаване на Web Search MCP сървър


Тази глава показва как да се изгради реален AI агент, който се интегрира с външни API-та, обработва различни типове данни, управлява грешки и координира множество инструменти — всичко това в готов за продукция формат. Ще видите:

- **Интеграция с външни API-та, изискващи автентикация**
- **Обработка на разнообразни типове данни от различни крайни точки**
- **Надеждно управление на грешки и стратегии за логване**
- **Координация на няколко инструмента в един сървър**

В края ще имате практичен опит с шаблони и добри практики, които са ключови за напреднали AI и LLM-базирани приложения.

## Въведение

В този урок ще научите как да създадете усъвършенстван MCP сървър и клиент, които разширяват възможностите на LLM с данни в реално време от уеб чрез SerpAPI. Това е ключово умение за разработване на динамични AI агенти, които могат да достъпват актуална информация от интернет.

## Учебни цели

След края на този урок ще можете да:

- Интегрирате външни API-та (като SerpAPI) сигурно в MCP сървър
- Имплементирате множество инструменти за търсене в уеб, новини, продукти и въпроси и отговори
- Парсвате и форматирате структурирани данни за консумация от LLM
- Управлявате грешки и API лимити ефективно
- Създавате и тествате както автоматизирани, така и интерактивни MCP клиенти

## Web Search MCP сървър

Този раздел представя архитектурата и функционалностите на Web Search MCP сървъра. Ще видите как FastMCP и SerpAPI работят заедно, за да разширят възможностите на LLM с данни в реално време от уеб.

### Преглед

Тази имплементация включва четири инструмента, които демонстрират способността на MCP да обработва разнообразни задачи, базирани на външни API-та, сигурно и ефективно:

- **general_search**: За широки уеб резултати
- **news_search**: За последни новини
- **product_search**: За данни от електронна търговия
- **qna**: За въпроси и кратки отговори

### Функционалности
- **Примери с код**: Включва езиково специфични кодови блокове за Python (лесно разширими и за други езици) с използване на свиваеми секции за по-голяма яснота

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

Преди да стартирате клиента, полезно е да разберете какво прави сървърът. Файлът [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

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
- **Парсване на структурирани данни**: Показва как да се трансформират отговорите от API в удобен за LLM формат
- **Обработка на грешки**: Надеждно управление на грешки с подходящо логване
- **Интерактивен клиент**: Включва както автоматизирани тестове, така и интерактивен режим за тестване
- **Управление на контекст**: Използва MCP Context за логване и проследяване на заявки

## Предварителни условия

Преди да започнете, уверете се, че средата ви е настроена правилно, като следвате тези стъпки. Това ще гарантира, че всички зависимости са инсталирани и API ключовете са конфигурирани правилно за безпроблемна разработка и тестване.

- Python 3.8 или по-нова версия
- SerpAPI API ключ (Регистрирайте се на [SerpAPI](https://serpapi.com/) - има безплатен план)

## Инсталация

За да започнете, следвайте тези стъпки за настройка на средата:

1. Инсталирайте зависимостите с uv (препоръчително) или pip:

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

Web Search MCP сървърът е основният компонент, който предоставя инструменти за търсене в уеб, новини, продукти и въпроси и отговори чрез интеграция със SerpAPI. Той обработва входящите заявки, управлява API повикванията, парсва отговорите и връща структурирани резултати на клиента.

Можете да прегледате пълната имплементация във файла [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

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

За да стартирате автоматизираните тестове (това автоматично ще стартира сървъра):

```bash
python client.py
```

Или стартирайте в интерактивен режим:

```bash
python client.py --interactive
```

### Тестване с различни методи

Има няколко начина да тествате и взаимодействате с инструментите, предоставени от сървъра, в зависимост от нуждите и работния ви процес.

#### Писане на собствени тестови скриптове с MCP Python SDK
Можете също да създадете свои собствени тестови скриптове, използвайки MCP Python SDK:

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


В този контекст "тестов скрипт" означава персонална Python програма, която пишете, за да действа като клиент към MCP сървъра. Вместо да е формален юнит тест, този скрипт ви позволява програмно да се свържете със сървъра, да извикате някой от инструментите с параметри по ваш избор и да разгледате резултатите. Този подход е полезен за:
- Прототипиране и експериментиране с извиквания на инструменти
- Проверка как сървърът реагира на различни входни данни
- Автоматизиране на повтарящи се извиквания на инструменти
- Създаване на собствени работни потоци или интеграции върху MCP сървъра

Можете да използвате тестови скриптове, за да пробвате нови заявки бързо, да дебъгвате поведението на инструменти или дори като отправна точка за по-сложна автоматизация. По-долу е пример как да използвате MCP Python SDK за създаване на такъв скрипт:

## Описания на инструментите

Можете да използвате следните инструменти, предоставени от сървъра, за различни видове търсения и заявки. Всеки инструмент е описан по-долу с параметрите и пример за употреба.

Този раздел предоставя подробности за всеки наличен инструмент и техните параметри.

### general_search

Извършва общо уеб търсене и връща форматирани резултати.

**Как да извикате този инструмент:**

Можете да извикате `general_search` от собствен скрипт, използвайки MCP Python SDK, или интерактивно чрез Inspector или интерактивния клиентски режим. Ето пример с код, използващ SDK:

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

Търси за последни новинарски статии, свързани с дадена заявка.

**Как да извикате този инструмент:**

Можете да извикате `news_search` от собствен скрипт, използвайки MCP Python SDK, или интерактивно чрез Inspector или интерактивния клиентски режим. Ето пример с код, използващ SDK:

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

Търси продукти, съвпадащи с заявката.

**Как да извикате този инструмент:**

Можете да извикате `product_search` от собствен скрипт, използвайки MCP Python SDK, или интерактивно чрез Inspector или интерактивния клиентски режим. Ето пример с код, използващ SDK:

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

Получава директни отговори на въпроси от търсачки.

**Как да извикате този инструмент:**

Можете да извикате `qna` от собствен скрипт, използвайки MCP Python SDK, или интерактивно чрез Inspector или интерактивния клиентски режим. Ето пример с код, използващ SDK:

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

Алтернативно, в интерактивен режим изберете `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Въпрос, за който търсите отговор

**Примерна заявка:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Подробности за кода

Този раздел предоставя кодови фрагменти и референции за имплементациите на сървъра и клиента.

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

Преди да започнете да изграждате, ето някои важни напреднали концепции, които ще се появяват през цялата глава. Разбирането им ще ви помогне да следвате материала, дори ако са нови за вас:

- **Координация на няколко инструмента**: Това означава да се изпълняват няколко различни инструмента (като уеб търсене, новини, продукти и въпроси и отговори) в един MCP сървър. Позволява на сървъра да обработва разнообразни задачи, а не само една.
- **Управление на API лимити**: Много външни API-та (като SerpAPI) ограничават колко заявки можете да правите за определен период. Добре написан код проверява тези лимити и ги обработва внимателно, за да не се срине приложението ви при достигане на лимит.
- **Парсване на структурирани данни**: Отговорите от API често са сложни и вложени. Тази концепция се отнася до преобразуването им в чисти, лесни за използване формати, удобни за LLM или други програми.
- **Възстановяване при грешки**: Понякога нещата се объркват — например мрежата прекъсва или API не връща очакваното. Възстановяването при грешки означава, че кодът ви може да се справи с тези проблеми и да даде полезна обратна връзка, вместо да спре работа.
- **Валидация на параметри**: Това е проверка дали всички входни данни към инструментите са правилни и безопасни за използване. Включва задаване на стойности по подразбиране и проверка на типовете, което помага за предотвратяване на грешки и объркване.

Този раздел ще ви помогне да диагностицирате и разрешите често срещани проблеми при работа с Web Search MCP сървъра. Ако срещнете грешки или неочаквано поведение, този раздел предлага решения на най-често срещаните проблеми. Прегледайте тези съвети преди да търсите допълнителна помощ — те често решават проблемите бързо.

## Отстраняване на проблеми

При работа с Web Search MCP сървъра понякога може да срещнете затруднения — това е нормално при разработка с външни API-та и нови инструменти. Този раздел предлага практични решения на най-често срещаните проблеми, за да се върнете бързо към работа. Ако получите грешка, започнете оттук: съветите по-долу адресират проблемите, с които най-често се сблъскват потребителите, и често могат да решат проблема без допълнителна помощ.

### Често срещани проблеми

По-долу са някои от най-честите проблеми, с които се сблъскват потребителите, заедно с ясни обяснения и стъпки за разрешаване:

1. **Липсва SERPAPI_KEY в .env файла**
   - Ако видите грешка `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` файл, създайте го ако липсва. Ако ключът е правилен, но грешката продължава, проверете дали безплатният ви план не е изчерпал квотата.

### Режим за отстраняване на грешки (Debug Mode)

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

Забележете как DEBUG режим включва допълнителни редове за HTTP заявки, отговори и други вътрешни детайли. Това може да е много полезно при отстраняване на проблеми.

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
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи може да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за никакви недоразумения или неправилни тълкувания, произтичащи от използването на този превод.