<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-16T15:23:44+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "pl"
}
-->
## Testowanie i debugowanie

Zanim zaczniesz testować swój serwer MCP, ważne jest, aby zrozumieć dostępne narzędzia i najlepsze praktyki debugowania. Skuteczne testowanie zapewnia, że serwer działa zgodnie z oczekiwaniami i pomaga szybko zidentyfikować oraz rozwiązać problemy. Poniższa sekcja przedstawia zalecane podejścia do weryfikacji implementacji MCP.

## Przegląd

Ta lekcja omawia, jak wybrać odpowiednie podejście do testowania oraz najskuteczniejsze narzędzie testowe.

## Cele nauki

Po ukończeniu tej lekcji będziesz potrafił:

- Opisać różne podejścia do testowania.
- Wykorzystać różne narzędzia do efektywnego testowania kodu.

## Testowanie serwerów MCP

MCP udostępnia narzędzia pomagające testować i debugować serwery:

- **MCP Inspector**: narzędzie wiersza poleceń, które można uruchomić zarówno jako CLI, jak i w wersji wizualnej.
- **Testowanie manualne**: można użyć narzędzia takiego jak curl do wykonywania zapytań sieciowych, ale każde narzędzie obsługujące HTTP będzie odpowiednie.
- **Testy jednostkowe**: można użyć preferowanego frameworka testowego do testowania funkcji zarówno serwera, jak i klienta.

### Korzystanie z MCP Inspector

Opisaliśmy użycie tego narzędzia w poprzednich lekcjach, ale omówmy je krótko na poziomie ogólnym. To narzędzie napisane w Node.js, które uruchamiasz wywołując plik wykonywalny `npx`, który tymczasowo pobierze i zainstaluje narzędzie, a po wykonaniu żądania oczyści środowisko.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) pomaga:

- **Odkrywać możliwości serwera**: automatycznie wykrywa dostępne zasoby, narzędzia i podpowiedzi
- **Testować wykonanie narzędzi**: wypróbuj różne parametry i obserwuj odpowiedzi na żywo
- **Przeglądać metadane serwera**: sprawdź informacje o serwerze, schematy i konfiguracje

Typowe uruchomienie narzędzia wygląda następująco:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Powyższe polecenie uruchamia MCP wraz z interfejsem wizualnym i otwiera lokalny interfejs webowy w przeglądarce. Możesz spodziewać się panelu wyświetlającego zarejestrowane serwery MCP, dostępne narzędzia, zasoby i podpowiedzi. Interfejs pozwala interaktywnie testować wykonanie narzędzi, przeglądać metadane serwera oraz oglądać odpowiedzi w czasie rzeczywistym, co ułatwia weryfikację i debugowanie implementacji serwera MCP.

Tak może to wyglądać: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.pl.png)

Możesz też uruchomić to narzędzie w trybie CLI, dodając atrybut `--cli`. Oto przykład uruchomienia narzędzia w trybie "CLI", który wyświetla wszystkie narzędzia na serwerze:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Testowanie manualne

Poza uruchomieniem narzędzia inspector do testowania możliwości serwera, podobnym podejściem jest uruchomienie klienta obsługującego HTTP, na przykład curl.

Za pomocą curl możesz testować serwery MCP bezpośrednio za pomocą zapytań HTTP:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Jak widać na powyższym przykładzie użycia curl, korzystasz z zapytania POST, aby wywołać narzędzie, przesyłając ładunek zawierający nazwę narzędzia i jego parametry. Wybierz podejście, które najbardziej Ci odpowiada. Narzędzia CLI zazwyczaj są szybsze w użyciu i nadają się do automatyzacji, co może być przydatne w środowisku CI/CD.

### Testy jednostkowe

Twórz testy jednostkowe dla swoich narzędzi i zasobów, aby upewnić się, że działają zgodnie z oczekiwaniami. Oto przykładowy kod testowy.

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

Powyższy kod wykonuje następujące czynności:

- Wykorzystuje framework pytest, który pozwala tworzyć testy jako funkcje i używać instrukcji assert.
- Tworzy serwer MCP z dwoma różnymi narzędziami.
- Używa instrukcji `assert`, aby sprawdzić, czy określone warunki są spełnione.

Zajrzyj do [pełnego pliku tutaj](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Na podstawie powyższego pliku możesz testować własny serwer, aby upewnić się, że możliwości są tworzone zgodnie z założeniami.

Wszystkie główne SDK mają podobne sekcje testowe, więc możesz dostosować je do wybranego środowiska uruchomieniowego.

## Przykłady

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatkowe zasoby

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Co dalej

- Następny: [Deployment](/03-GettingStarted/08-deployment/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było precyzyjne, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy traktować jako źródło wiarygodne i autorytatywne. W przypadku informacji o istotnym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.