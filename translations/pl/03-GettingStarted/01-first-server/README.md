<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bf05718d019040cf0c7d4ccc6d6a1a88",
  "translation_date": "2025-06-13T05:59:15+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "pl"
}
-->
### -2- Utwórz projekt

Teraz, gdy masz zainstalowane SDK, przejdźmy do utworzenia projektu:

### -3- Utwórz pliki projektu

### -4- Utwórz kod serwera

### -5- Dodawanie narzędzia i zasobu

Dodaj narzędzie i zasób, wstawiając następujący kod:

### -6- Końcowy kod

Dodajmy ostatni potrzebny kod, aby serwer mógł się uruchomić:

### -7- Testowanie serwera

Uruchom serwer za pomocą następującego polecenia:

### -8- Uruchomienie przy użyciu inspektora

Inspektor to świetne narzędzie, które może uruchomić twój serwer i pozwala na interakcję z nim, abyś mógł przetestować jego działanie. Uruchommy go:

> [!NOTE]
> w polu "command" może to wyglądać inaczej, ponieważ zawiera polecenie uruchomienia serwera dla twojego konkretnego środowiska wykonawczego/

Powinieneś zobaczyć następujący interfejs użytkownika:

![Połącz](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.pl.png)

1. Połącz się z serwerem, klikając przycisk Connect  
   Po połączeniu powinieneś zobaczyć następujący widok:

   ![Połączono](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.pl.png)

2. Wybierz "Tools" i "listTools", powinieneś zobaczyć opcję "Add", wybierz ją i wypełnij wartości parametrów.

   Powinieneś zobaczyć następującą odpowiedź, czyli wynik działania narzędzia "add":

   ![Wynik działania add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.pl.png)

Gratulacje, udało Ci się stworzyć i uruchomić swój pierwszy serwer!

### Oficjalne SDK

MCP udostępnia oficjalne SDK dla wielu języków:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Utrzymywane we współpracy z Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Utrzymywane we współpracy z Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Oficjalna implementacja w TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Oficjalna implementacja w Pythonie
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Oficjalna implementacja w Kotlinie
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Utrzymywane we współpracy z Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Oficjalna implementacja w Rust

## Najważniejsze informacje

- Konfiguracja środowiska programistycznego MCP jest prosta dzięki dedykowanym SDK dla poszczególnych języków
- Budowa serwerów MCP polega na tworzeniu i rejestrowaniu narzędzi z jasno określonymi schematami
- Testowanie i debugowanie są kluczowe dla niezawodnych implementacji MCP

## Przykłady

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Zadanie

Stwórz prosty serwer MCP z narzędziem według własnego wyboru:
1. Zaimplementuj narzędzie w wybranym języku (.NET, Java, Python lub JavaScript).
2. Zdefiniuj parametry wejściowe i wartości zwracane.
3. Uruchom narzędzie inspektora, aby upewnić się, że serwer działa poprawnie.
4. Przetestuj implementację z różnymi danymi wejściowymi.

## Rozwiązanie

[Rozwiązanie](./solution/README.md)

## Dodatkowe zasoby

- [Budowanie agentów przy użyciu Model Context Protocol na Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Zdalny MCP z Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Co dalej

Następny krok: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub nieścisłości. Oryginalny dokument w jego języku źródłowym powinien być uważany za źródło wiarygodne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.