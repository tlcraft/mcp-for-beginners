<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:48:06+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "bg"
}
-->
## Тестване и Отстраняване на Грешки

Преди да започнете да тествате вашия MCP сървър, е важно да разберете наличните инструменти и най-добрите практики за отстраняване на грешки. Ефективното тестване гарантира, че вашият сървър се държи според очакванията и ви помага бързо да идентифицирате и решите проблеми. Следващият раздел очертава препоръчителни подходи за валидиране на вашата MCP имплементация.

## Общ преглед

Този урок обхваща как да изберете правилния подход за тестване и най-ефективния инструмент за тестване.

## Цели на Обучението

До края на този урок ще можете да:

- Описвате различни подходи за тестване.
- Използвате различни инструменти за ефективно тестване на вашия код.

## Тестване на MCP Сървъри

MCP предоставя инструменти, които да ви помогнат да тествате и отстранявате грешки на вашите сървъри:

- **MCP Inspector**: Инструмент за команден ред, който може да бъде изпълняван както като CLI инструмент, така и като визуален инструмент.
- **Ръчно тестване**: Можете да използвате инструмент като curl за изпълнение на уеб заявки, но всеки инструмент, способен да изпълнява HTTP, ще свърши работа.
- **Модулно тестване**: Възможно е да използвате предпочитаната от вас рамка за тестване, за да тествате функциите както на сървъра, така и на клиента.

### Използване на MCP Inspector

Описахме използването на този инструмент в предишни уроци, но нека поговорим за него малко на високо ниво. Това е инструмент, създаден в Node.js, и можете да го използвате, като извикате изпълнимия файл `npx`, който временно ще изтегли и инсталира самия инструмент и ще се почисти, след като завърши изпълнението на вашата заявка.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) ви помага:

- **Откриване на възможности на сървъра**: Автоматично откриване на налични ресурси, инструменти и подсказки.
- **Тестване на изпълнение на инструменти**: Изпробване на различни параметри и виждане на отговори в реално време.
- **Преглед на метаданни на сървъра**: Изследване на информация за сървъра, схеми и конфигурации.

Типично изпълнение на инструмента изглежда така:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Горната команда стартира MCP и неговия визуален интерфейс и отваря локален уеб интерфейс във вашия браузър. Можете да очаквате да видите табло, показващо вашите регистрирани MCP сървъри, техните налични инструменти, ресурси и подсказки. Интерфейсът ви позволява интерактивно да тествате изпълнението на инструменти, да инспектирате метаданни на сървъра и да видите отговори в реално време, което прави по-лесно валидирането и отстраняването на грешки в имплементациите на вашия MCP сървър.

Ето как може да изглежда: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.bg.png)

Можете също да изпълните този инструмент в CLI режим, като добавите атрибута `--cli`. Ето пример за изпълнение на инструмента в "CLI" режим, който изброява всички инструменти на сървъра:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Ръчно Тестване

Освен изпълнението на инспектор инструмента за тестване на възможностите на сървъра, друг подобен подход е да стартирате клиент, способен да използва HTTP, като например curl.

С curl можете директно да тествате MCP сървъри, използвайки HTTP заявки:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Както виждате от горното използване на curl, използвате POST заявка, за да извикате инструмент, използвайки полезен товар, състоящ се от името на инструмента и неговите параметри. Използвайте подхода, който ви подхожда най-добре. CLI инструментите обикновено са по-бързи за използване и могат да бъдат скриптирани, което може да бъде полезно в CI/CD среда.

### Модулно Тестване

Създайте модулни тестове за вашите инструменти и ресурси, за да се уверите, че работят според очакванията. Ето примерен тестов код.

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

Предходният код прави следното:

- Използва рамката pytest, която ви позволява да създавате тестове като функции и да използвате оператори assert.
- Създава MCP сървър с два различни инструмента.
- Използва оператор assert, за да провери, че определени условия са изпълнени.

Разгледайте [пълния файл тук](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Въз основа на горния файл, можете да тествате вашия собствен сървър, за да се уверите, че възможностите са създадени както трябва.

Всички основни SDK имат подобни секции за тестване, така че можете да се адаптирате към избраното от вас изпълнение.

## Примери

- [Java Калкулатор](../samples/java/calculator/README.md)
- [.Net Калкулатор](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Калкулатор](../samples/javascript/README.md)
- [TypeScript Калкулатор](../samples/typescript/README.md)
- [Python Калкулатор](../../../../03-GettingStarted/samples/python)

## Допълнителни Ресурси

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Какво Следва

- Следващо: [Деплоймент](/03-GettingStarted/08-deployment/README.md)

**Отказ от отговорност**:
Този документ е преведен с помощта на AI услуга за превод [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи може да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Не носим отговорност за каквито и да било недоразумения или погрешни интерпретации, възникнали в резултат на използването на този превод.