<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T17:00:38+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "pl"
}
-->
### -2- Utwórz projekt

Teraz, gdy masz zainstalowane SDK, utwórzmy kolejny projekt:

### -3- Utwórz pliki projektu

### -4- Napisz kod serwera

### -5- Dodawanie narzędzia i zasobu

Dodaj narzędzie i zasób, wstawiając poniższy kod:

### -6- Końcowy kod

Dodajmy ostatni fragment kodu, który pozwoli serwerowi się uruchomić:

### -7- Testowanie serwera

Uruchom serwer za pomocą następującego polecenia:

### -8- Uruchomienie przy użyciu inspektora

Inspektor to świetne narzędzie, które może uruchomić twój serwer i pozwala na interakcję z nim, abyś mógł przetestować jego działanie. Uruchommy go:

> [!NOTE]
> może wyglądać inaczej w polu „command”, ponieważ zawiera polecenie uruchomienia serwera dla twojego konkretnego środowiska wykonawczego/

Powinieneś zobaczyć następujący interfejs użytkownika:

![Połącz](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.pl.png)

1. Połącz się z serwerem, klikając przycisk Connect  
   Po połączeniu z serwerem powinieneś zobaczyć następujące:

   ![Połączono](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.pl.png)

2. Wybierz „Tools” i „listTools”, powinieneś zobaczyć opcję „Add”, kliknij „Add” i wypełnij wartości parametrów.

   Powinieneś zobaczyć następującą odpowiedź, czyli wynik działania narzędzia „add”:

   ![Wynik działania add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.pl.png)

Gratulacje, udało Ci się stworzyć i uruchomić swój pierwszy serwer!

### Oficjalne SDK

MCP udostępnia oficjalne SDK dla wielu języków:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - utrzymywane we współpracy z Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - utrzymywane we współpracy ze Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - oficjalna implementacja w TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - oficjalna implementacja w Pythonie
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - oficjalna implementacja w Kotlinie
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - utrzymywane we współpracy z Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - oficjalna implementacja w Rust

## Kluczowe wnioski

- Konfiguracja środowiska deweloperskiego MCP jest prosta dzięki dedykowanym SDK dla poszczególnych języków
- Tworzenie serwerów MCP polega na tworzeniu i rejestrowaniu narzędzi z jasnymi schematami
- Testowanie i debugowanie są niezbędne dla niezawodnych implementacji MCP

## Przykłady

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Zadanie

Stwórz prosty serwer MCP z wybranym przez siebie narzędziem:
1. Zaimplementuj narzędzie w preferowanym języku (.NET, Java, Python lub JavaScript).
2. Zdefiniuj parametry wejściowe i wartości zwracane.
3. Uruchom narzędzie inspektora, aby upewnić się, że serwer działa poprawnie.
4. Przetestuj implementację na różnych danych wejściowych.

## Rozwiązanie

[Rozwiązanie](./solution/README.md)

## Dodatkowe zasoby

- [Repozytorium MCP na GitHub](https://github.com/microsoft/mcp-for-beginners)

## Co dalej

Następny krok: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy traktować jako źródło ostateczne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.