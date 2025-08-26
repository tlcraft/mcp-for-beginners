<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:48:05+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "sr"
}
-->
# MCP сервер са stdio транспортом

> **⚠️ Важно ажурирање**: Од MCP спецификације 2025-06-18, самостални SSE (Server-Sent Events) транспорт је **застарео** и замењен "Streamable HTTP" транспортом. Тренутна MCP спецификација дефинише два примарна механизма транспорта:
> 1. **stdio** - Стандардни улаз/излаз (препоручено за локалне сервере)
> 2. **Streamable HTTP** - За удаљене сервере који могу интерно користити SSE
>
> Ова лекција је ажурирана да се фокусира на **stdio транспорт**, који је препоручени приступ за већину MCP серверских имплементација.

Stdio транспорт омогућава MCP серверима да комуницирају са клијентима преко стандардних улазних и излазних токова. Ово је најчешће коришћен и препоручен механизам транспорта у тренутној MCP спецификацији, пружајући једноставан и ефикасан начин за изградњу MCP сервера који се лако интегришу са различитим клијентским апликацијама.

## Преглед

Ова лекција покрива како изградити и користити MCP сервере користећи stdio транспорт.

## Циљеви учења

До краја ове лекције, бићете у могућности да:

- Изградите MCP сервер користећи stdio транспорт.
- Дебагујете MCP сервер користећи Inspector.
- Користите MCP сервер у Visual Studio Code-у.
- Разумете тренутне MCP механизме транспорта и зашто је stdio препоручен.

## stdio транспорт - Како функционише

Stdio транспорт је један од два подржана типа транспорта у тренутној MCP спецификацији (2025-06-18). Ево како функционише:

- **Једноставна комуникација**: Сервер чита JSON-RPC поруке са стандардног улаза (`stdin`) и шаље поруке на стандардни излаз (`stdout`).
- **Процесно заснован**: Клијент покреће MCP сервер као подпроцес.
- **Формат поруке**: Поруке су појединачни JSON-RPC захтеви, обавештења или одговори, раздвојени новим редовима.
- **Логовање**: Сервер МОЖЕ писати UTF-8 стрингове на стандардну грешку (`stderr`) за потребе логовања.

### Кључни захтеви:
- Поруке МОРАЈУ бити раздвојене новим редовима и НЕ СМЕЈУ садржати уграђене нове редове.
- Сервер НЕ СМЕ писати ништа на `stdout` што није важећа MCP порука.
- Клијент НЕ СМЕ писати ништа на серверов `stdin` што није важећа MCP порука.

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

У претходном коду:

- Увозимо `Server` класу и `StdioServerTransport` из MCP SDK-а.
- Креирамо инстанцу сервера са основном конфигурацијом и могућностима.

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

У претходном коду:

- Креирамо инстанцу сервера користећи MCP SDK.
- Дефинишемо алате користећи декораторе.
- Користимо `stdio_server` контекст менаџер за руковање транспортом.

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

Кључна разлика у односу на SSE је да stdio сервери:

- Не захтевају подешавање веб сервера или HTTP крајњих тачака.
- Покрећу се као подпроцеси од стране клијента.
- Комуницирају преко stdin/stdout токова.
- Једноставнији су за имплементацију и дебаговање.

## Вежба: Креирање stdio сервера

Да бисмо креирали наш сервер, морамо имати на уму две ствари:

- Потребно је користити веб сервер за излагање крајњих тачака за повезивање и поруке.

## Лабораторија: Креирање једноставног MCP stdio сервера

У овој лабораторији, креираћемо једноставан MCP сервер користећи препоручени stdio транспорт. Овај сервер ће излагати алате које клијенти могу позивати користећи стандардни Model Context Protocol.

### Предуслови

- Python 3.8 или новији
- MCP Python SDK: `pip install mcp`
- Основно разумевање асинхроног програмирања

Почнимо са креирањем нашег првог MCP stdio сервера:

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## Кључне разлике у односу на застарели SSE приступ

**Stdio транспорт (тренутни стандард):**
- Једноставан модел подпроцеса - клијент покреће сервер као подпроцес.
- Комуникација преко stdin/stdout користећи JSON-RPC поруке.
- Нема потребе за подешавањем HTTP сервера.
- Боље перформансе и безбедност.
- Лакше дебаговање и развој.

**SSE транспорт (застарео од MCP 2025-06-18):**
- Захтевао је HTTP сервер са SSE крајњим тачкама.
- Комплексније подешавање са инфраструктуром веб сервера.
- Додатна безбедносна разматрања за HTTP крајње тачке.
- Сада замењен Streamable HTTP-ом за веб сценарије.

### Креирање сервера са stdio транспортом

Да бисмо креирали наш stdio сервер, потребно је:

1. **Увозити потребне библиотеке** - Потребни су нам MCP серверски компоненти и stdio транспорт.
2. **Креирати инстанцу сервера** - Дефинисати сервер са његовим могућностима.
3. **Дефинисати алате** - Додати функционалности које желимо да излажемо.
4. **Подесити транспорт** - Конфигурисати stdio комуникацију.
5. **Покренути сервер** - Стартовати сервер и руковати порукама.

Хајде да ово изградимо корак по корак:

### Корак 1: Креирање основног stdio сервера

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### Корак 2: Додавање више алата

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### Корак 3: Покретање сервера

Сачувајте код као `server.py` и покрените га из командне линије:

```bash
python server.py
```

Сервер ће се покренути и чекати унос са stdin-а. Комуницира преко JSON-RPC порука користећи stdio транспорт.

### Корак 4: Тестирање са Inspector-ом

Можете тестирати свој сервер користећи MCP Inspector:

1. Инсталирајте Inspector: `npx @modelcontextprotocol/inspector`
2. Покрените Inspector и усмерите га на свој сервер.
3. Тестирајте алате које сте креирали.

### Шта треба да видите

Када ваш сервер успешно стартује, требало би да видите:
- Списак могућности сервера у Inspector-у.
- Алате доступне за тестирање.
- Успешну размену JSON-RPC порука.
- Одговоре алата приказане у интерфејсу.

### Уобичајени проблеми и решења

**Сервер се не покреће:**
- Проверите да ли су све зависности инсталиране: `pip install mcp`.
- Уверите се у исправност Python синтаксе и увлачења.
- Потражите поруке о грешци у конзоли.

**Алати се не појављују:**
- Уверите се да су присутни декоратори `@server.tool()`.
- Проверите да су функције алата дефинисане пре `main()`.
- Уверите се да је сервер правилно конфигурисан.

**Проблеми са повезивањем:**
- Проверите да ли сервер правилно користи stdio транспорт.
- Уверите се да други процеси не ометају.
- Проверите синтаксу Inspector команде.

## Задатак

Покушајте да изградите свој сервер са више могућности. Погледајте [ову страницу](https://api.chucknorris.io/) да, на пример, додате алат који позива API. Ви одлучујете како ће сервер изгледати. Забавите се :)

## Решење

[Решење](./solution/README.md) Ево могућег решења са функционалним кодом.

## Кључне поруке

Кључне поруке из овог поглавља су следеће:

- Stdio транспорт је препоручени механизам за локалне MCP сервере.
- Stdio транспорт омогућава беспрекорну комуникацију између MCP сервера и клијената користећи стандардне улазне и излазне токове.
- Можете користити и Inspector и Visual Studio Code за директно коришћење stdio сервера, што чини дебаговање и интеграцију једноставним.

## Примери

- [Java калкулатор](../samples/java/calculator/README.md)
- [.Net калкулатор](../../../../03-GettingStarted/samples/csharp)
- [JavaScript калкулатор](../samples/javascript/README.md)
- [TypeScript калкулатор](../samples/typescript/README.md)
- [Python калкулатор](../../../../03-GettingStarted/samples/python) 

## Додатни ресурси

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Шта следи

## Следећи кораци

Сада када сте научили како да изградите MCP сервере са stdio транспортом, можете истражити напредније теме:

- **Следеће**: [HTTP Streaming са MCP (Streamable HTTP)](../06-http-streaming/README.md) - Научите о другом подржаном механизму транспорта за удаљене сервере.
- **Напредно**: [Најбоље праксе за MCP безбедност](../../02-Security/README.md) - Имплементирајте безбедност у својим MCP серверима.
- **Продукција**: [Стратегије за имплементацију](../09-deployment/README.md) - Имплементирајте своје сервере за продукцијску употребу.

## Додатни ресурси

- [MCP спецификација 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Званична спецификација.
- [MCP SDK документација](https://github.com/modelcontextprotocol/sdk) - SDK референце за све језике.
- [Примери из заједнице](../../06-CommunityContributions/README.md) - Више примера сервера из заједнице.

---

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем услуге за превођење помоћу вештачке интелигенције [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да обезбедимо тачност, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати меродавним извором. За критичне информације препоручује се професионални превод од стране људи. Не преузимамо одговорност за било каква погрешна тумачења или неспоразуме који могу настати услед коришћења овог превода.