<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2342baa570312086fc19edcf41320250",
  "translation_date": "2025-06-17T15:44:07+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "pl"
}
-->
W poprzednim kodzie:

- Importujemy biblioteki
- Tworzymy instancję klienta i łączymy ją za pomocą stdio jako transportu.
- Wyświetlamy listę promptów, zasobów i narzędzi oraz wywołujemy je wszystkie.

Oto masz klienta, który potrafi komunikować się z serwerem MCP.

W następnej sekcji ćwiczeń poświęcimy czas na szczegółowe omówienie każdego fragmentu kodu i wyjaśnimy, co się dzieje.

## Ćwiczenie: Pisanie klienta

Jak wspomniano wcześniej, poświęćmy czas na wyjaśnienie kodu, a jeśli chcesz, możesz kodować razem z nami.

### -1- Importowanie bibliotek

Zaimportujmy potrzebne biblioteki, będziemy potrzebować odniesień do klienta oraz do wybranego protokołu transportowego, czyli stdio. stdio to protokół przeznaczony do działania na lokalnej maszynie. SSE to inny protokół transportowy, który pokażemy w kolejnych rozdziałach, ale to jest twoja alternatywa. Na razie jednak kontynuujmy ze stdio.

Przejdźmy teraz do tworzenia instancji.

### -2- Tworzenie instancji klienta i transportu

Będziemy musieli stworzyć instancję transportu oraz instancję naszego klienta:

### -3- Wyświetlanie funkcji serwera

Mamy teraz klienta, który może się połączyć, jeśli program zostanie uruchomiony. Jednak nie wyświetla on jeszcze swoich funkcji, zróbmy to teraz:

Świetnie, teraz mamy wszystkie funkcje. Pytanie brzmi, kiedy ich używać? Ten klient jest dość prosty, co oznacza, że musimy wywoływać funkcje explicite, gdy ich potrzebujemy. W następnym rozdziale stworzymy bardziej zaawansowanego klienta, który będzie miał dostęp do własnego dużego modelu językowego (LLM). Na razie zobaczmy, jak wywołać funkcje na serwerze:

### -4- Wywoływanie funkcji

Aby wywołać funkcje, musimy upewnić się, że podajemy poprawne argumenty, a w niektórych przypadkach także nazwę tego, co chcemy wywołać.

### -5- Uruchamianie klienta

Aby uruchomić klienta, wpisz następujące polecenie w terminalu:

## Zadanie

W tym zadaniu wykorzystasz zdobytą wiedzę do stworzenia własnego klienta.

Oto serwer, którego możesz użyć i do którego musisz się odwołać za pomocą swojego kodu klienta. Spróbuj dodać więcej funkcji do serwera, aby był bardziej interesujący.

## Rozwiązanie

[Solution](./solution/README.md)

## Najważniejsze informacje

Najważniejsze informacje dotyczące klientów w tym rozdziale to:

- Mogą służyć zarówno do odkrywania, jak i wywoływania funkcji na serwerze.
- Mogą uruchomić serwer podczas własnego startu (tak jak w tym rozdziale), ale klienci mogą też łączyć się z już działającymi serwerami.
- To świetny sposób na testowanie możliwości serwera obok alternatyw takich jak Inspector, jak opisano w poprzednim rozdziale.

## Dodatkowe zasoby

- [Budowanie klientów w MCP](https://modelcontextprotocol.io/quickstart/client)

## Przykłady

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Co dalej

- Następny: [Tworzenie klienta z LLM](/03-GettingStarted/03-llm-client/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym powinien być uznawany za autorytatywne źródło. W przypadku informacji o kluczowym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.