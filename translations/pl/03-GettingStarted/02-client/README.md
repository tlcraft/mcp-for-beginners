<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:44:42+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "pl"
}
-->
W poprzednim kodzie:

- Importujemy biblioteki
- Tworzymy instancję klienta i łączymy ją za pomocą stdio jako transportu.
- Wyświetlamy listę promptów, zasobów i narzędzi oraz wywołujemy je wszystkie.

Oto masz klienta, który może komunikować się z serwerem MCP.

Poświęćmy teraz trochę czasu w kolejnej sekcji ćwiczeń, aby przeanalizować każdy fragment kodu i wyjaśnić, co się dzieje.

## Ćwiczenie: Pisanie klienta

Jak wspomniano wcześniej, poświęćmy czas na wyjaśnienie kodu, a jeśli chcesz, możesz pisać kod razem z nami.

### -1- Importowanie bibliotek

Zaimportujmy potrzebne biblioteki, będziemy potrzebować odniesień do klienta oraz do wybranego protokołu transportowego, czyli stdio. stdio to protokół przeznaczony do działania na lokalnej maszynie. SSE to inny protokół transportowy, który pokażemy w przyszłych rozdziałach, ale to jest twoja inna opcja. Na razie jednak kontynuujmy ze stdio.

Przejdźmy teraz do tworzenia instancji.

### -2- Tworzenie instancji klienta i transportu

Musimy stworzyć instancję transportu oraz instancję naszego klienta:

### -3- Wyświetlanie funkcji serwera

Teraz mamy klienta, który może się połączyć, gdy program zostanie uruchomiony. Jednak nie wyświetla on jeszcze swoich funkcji, więc zróbmy to teraz:

Świetnie, teraz mamy wszystkie funkcje. Pojawia się pytanie: kiedy ich używać? Ten klient jest dość prosty, w tym sensie, że musimy jawnie wywoływać funkcje, gdy ich potrzebujemy. W kolejnym rozdziale stworzymy bardziej zaawansowanego klienta, który będzie miał dostęp do własnego dużego modelu językowego (LLM). Na razie zobaczmy, jak możemy wywołać funkcje na serwerze:

### -4- Wywoływanie funkcji

Aby wywołać funkcje, musimy upewnić się, że podajemy poprawne argumenty, a w niektórych przypadkach nazwę tego, co chcemy wywołać.

### -5- Uruchamianie klienta

Aby uruchomić klienta, wpisz następujące polecenie w terminalu:

## Zadanie

W tym zadaniu wykorzystasz to, czego się nauczyłeś, tworząc klienta, ale stworzysz własnego klienta.

Oto serwer, którego możesz użyć i do którego musisz się odwołać za pomocą swojego kodu klienta. Spróbuj dodać więcej funkcji do serwera, aby uczynić go bardziej interesującym.

## Rozwiązanie

[Rozwiązanie](./solution/README.md)

## Kluczowe wnioski

Najważniejsze informacje o klientach z tego rozdziału to:

- Mogą służyć zarówno do odkrywania, jak i wywoływania funkcji na serwerze.
- Mogą uruchomić serwer podczas własnego startu (tak jak w tym rozdziale), ale klienci mogą też łączyć się z już działającymi serwerami.
- To świetny sposób na przetestowanie możliwości serwera obok innych narzędzi, takich jak Inspector, opisany w poprzednim rozdziale.

## Dodatkowe zasoby

- [Tworzenie klientów w MCP](https://modelcontextprotocol.io/quickstart/client)

## Przykłady

- [Kalkulator w Javie](../samples/java/calculator/README.md)
- [Kalkulator w .Net](../../../../03-GettingStarted/samples/csharp)
- [Kalkulator w JavaScript](../samples/javascript/README.md)
- [Kalkulator w TypeScript](../samples/typescript/README.md)
- [Kalkulator w Pythonie](../../../../03-GettingStarted/samples/python)

## Co dalej

- Dalej: [Tworzenie klienta z LLM](/03-GettingStarted/03-llm-client/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczeń AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy traktować jako źródło ostateczne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.