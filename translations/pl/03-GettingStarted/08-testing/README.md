<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-12T22:24:43+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
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
- Korzystać z różnych narzędzi do skutecznego testowania kodu.

## Testowanie serwerów MCP

MCP udostępnia narzędzia, które pomogą Ci testować i debugować serwery:

- **MCP Inspector**: narzędzie wiersza poleceń, które można uruchamiać zarówno jako CLI, jak i w trybie wizualnym.
- **Testowanie manualne**: możesz użyć narzędzia takiego jak curl do wykonywania żądań sieciowych, ale każde narzędzie obsługujące HTTP będzie odpowiednie.
- **Testy jednostkowe**: możesz użyć wybranego frameworka testowego do testowania funkcji zarówno serwera, jak i klienta.

### Korzystanie z MCP Inspector

Opisaliśmy użycie tego narzędzia w poprzednich lekcjach, ale omówmy je teraz pokrótce. To narzędzie napisane w Node.js, które możesz uruchomić wywołując wykonywalny plik `npx`. Spowoduje to tymczasowe pobranie i instalację narzędzia, a po zakończeniu obsługi żądania narzędzie samo się posprząta.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) pomaga:

- **Odkrywać możliwości serwera**: automatycznie wykrywa dostępne zasoby, narzędzia i podpowiedzi
- **Testować wykonanie narzędzi**: pozwala wypróbować różne parametry i oglądać odpowiedzi w czasie rzeczywistym
- **Przeglądać metadane serwera**: umożliwia analizę informacji o serwerze, schematach i konfiguracjach

Typowe uruchomienie narzędzia wygląda następująco:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Powyższe polecenie uruchamia MCP wraz z jego interfejsem wizualnym i otwiera lokalny interfejs webowy w przeglądarce. Możesz spodziewać się pulpitu nawigacyjnego wyświetlającego zarejestrowane serwery MCP, dostępne narzędzia, zasoby i podpowiedzi. Interfejs pozwala interaktywnie testować wykonanie narzędzi, przeglądać metadane serwera i oglądać odpowiedzi w czasie rzeczywistym, co ułatwia weryfikację i debugowanie implementacji serwera MCP.

Tak może to wyglądać: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.pl.png)

Możesz też uruchomić to narzędzie w trybie CLI, dodając atrybut `--cli`. Oto przykład uruchomienia narzędzia w trybie "CLI", który wyświetla listę wszystkich narzędzi na serwerze:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Testowanie manualne

Poza uruchamianiem narzędzia inspector do testowania możliwości serwera, innym podobnym podejściem jest użycie klienta obsługującego HTTP, na przykład curl.

Za pomocą curl możesz testować serwery MCP bezpośrednio poprzez żądania HTTP:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Jak widać z powyższego przykładu użycia curl, do wywołania narzędzia używasz żądania POST z ładunkiem zawierającym nazwę narzędzia i jego parametry. Wybierz podejście, które najlepiej Ci odpowiada. Narzędzia CLI zazwyczaj są szybsze w użyciu i łatwo je zautomatyzować, co może być przydatne w środowisku CI/CD.

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

Powyższy kod robi następujące rzeczy:

- Wykorzystuje framework pytest, który pozwala tworzyć testy jako funkcje i używać instrukcji assert.
- Tworzy serwer MCP z dwoma różnymi narzędziami.
- Używa instrukcji `assert` do sprawdzania, czy spełnione są określone warunki.

Zobacz [pełny plik tutaj](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Mając powyższy plik, możesz testować własny serwer, aby upewnić się, że możliwości są tworzone zgodnie z założeniami.

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

- Następny: [Deployment](/03-GettingStarted/09-deployment/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za autorytatywne źródło. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.