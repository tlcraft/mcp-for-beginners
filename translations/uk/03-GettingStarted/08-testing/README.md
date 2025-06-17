<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-17T16:47:42+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "uk"
}
-->
## Тестування та налагодження

Перед тим, як почати тестувати свій MCP сервер, важливо розуміти доступні інструменти та найкращі практики налагодження. Ефективне тестування гарантує, що сервер працює відповідно до очікувань, і допомагає швидко виявляти та усувати проблеми. У наступному розділі описані рекомендовані підходи для перевірки вашої реалізації MCP.

## Огляд

У цьому уроці розглядається, як обрати правильний підхід до тестування та найефективніший інструмент для цього.

## Цілі навчання

До кінця уроку ви зможете:

- Описати різні підходи до тестування.
- Використовувати різні інструменти для ефективного тестування вашого коду.

## Тестування MCP серверів

MCP надає інструменти, які допоможуть вам тестувати та налагоджувати ваші сервери:

- **MCP Inspector**: інструмент командного рядка, який можна запускати як CLI, так і у візуальному режимі.
- **Ручне тестування**: можна використовувати інструмент на кшталт curl для виконання веб-запитів, але підійде будь-який інструмент, що підтримує HTTP.
- **Модульне тестування**: можна використовувати улюблений тестовий фреймворк для перевірки функціоналу як сервера, так і клієнта.

### Використання MCP Inspector

Ми вже описували використання цього інструменту в попередніх уроках, але давайте коротко згадаємо про нього на загальному рівні. Це інструмент, створений на Node.js, і ви можете використовувати його, викликаючи виконуваний файл `npx`, який тимчасово завантажить і встановить інструмент, а після завершення виконання вашого запиту сам очистить себе.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) допомагає вам:

- **Виявляти можливості сервера**: автоматично визначати доступні ресурси, інструменти та підказки
- **Тестувати виконання інструментів**: пробувати різні параметри та бачити відповіді в реальному часі
- **Переглядати метадані сервера**: досліджувати інформацію про сервер, схеми та конфігурації

Типовий запуск інструменту виглядає так:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Вищенаведена команда запускає MCP та його візуальний інтерфейс, відкриваючи локальний веб-інтерфейс у вашому браузері. Ви побачите панель управління з переліком зареєстрованих MCP серверів, доступних інструментів, ресурсів і підказок. Інтерфейс дозволяє інтерактивно тестувати виконання інструментів, переглядати метадані сервера та отримувати відповіді в реальному часі, що значно полегшує перевірку та налагодження реалізацій MCP серверів.

Ось як це може виглядати: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.uk.png)

Також цей інструмент можна запускати в CLI режимі, для чого додається атрибут `--cli`. Ось приклад запуску в режимі "CLI", який виводить список усіх інструментів на сервері:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Ручне тестування

Окрім запуску інструменту inspector для перевірки можливостей сервера, можна також використовувати клієнт, здатний виконувати HTTP-запити, наприклад curl.

За допомогою curl можна тестувати MCP сервери безпосередньо через HTTP-запити:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Як видно з прикладу використання curl, для виклику інструменту використовується POST-запит із тілом, що містить назву інструменту та його параметри. Обирайте підхід, який вам найбільше підходить. CLI-інструменти зазвичай швидші у використанні та зручні для автоматизації, що особливо корисно в CI/CD середовищах.

### Модульне тестування

Створюйте модульні тести для ваших інструментів і ресурсів, щоб переконатися, що вони працюють як слід. Ось приклад коду для тестування.

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

Вищенаведений код робить наступне:

- Використовує фреймворк pytest, який дозволяє створювати тести у вигляді функцій із assert-виразами.
- Створює MCP сервер із двома різними інструментами.
- Використовує assert для перевірки виконання певних умов.

Ознайомтеся з [повним файлом тут](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Виходячи з цього файлу, ви можете протестувати свій сервер, щоб упевнитися, що можливості створені належним чином.

Усі основні SDK мають подібні розділи для тестування, тому ви можете адаптувати їх під ваш вибір середовища виконання.

## Приклади

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Додаткові ресурси

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Що далі

- Далі: [Deployment](/03-GettingStarted/09-deployment/README.md)

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, просимо враховувати, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння чи неправильні тлумачення, що виникли внаслідок використання цього перекладу.