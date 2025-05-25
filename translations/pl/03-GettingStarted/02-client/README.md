<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-16T15:26:14+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "pl"
}
-->
W powyższym kodzie:

- Importujemy biblioteki
- Tworzymy instancję klienta i łączymy ją z użyciem stdio jako transportu.
- Wypisujemy prompty, zasoby i narzędzia oraz wywołujemy je wszystkie.

Oto masz klienta, który potrafi komunikować się z serwerem MCP.

Poświęćmy trochę czasu w następnej sekcji ćwiczeń, aby przeanalizować każdy fragment kodu i wyjaśnić, co się dzieje.

## Ćwiczenie: Pisanie klienta

Jak wspomniano wcześniej, poświęćmy czas na wyjaśnienie kodu, a jeśli chcesz, koduj razem z nami.

### -1- Importowanie bibliotek

Zaimportujmy potrzebne biblioteki, będziemy potrzebować odwołań do klienta oraz do wybranego protokołu transportowego, czyli stdio. stdio to protokół przeznaczony do działania na lokalnej maszynie. SSE to inny protokół transportowy, który pokażemy w przyszłych rozdziałach, ale na razie skupmy się na stdio.

Przejdźmy teraz do tworzenia instancji.

### -2- Tworzenie instancji klienta i transportu

Musimy utworzyć instancję transportu oraz instancję klienta:

### -3- Wypisywanie funkcji serwera

Teraz mamy klienta, który może się połączyć, gdy program zostanie uruchomiony. Jednak klient nie wypisuje jeszcze dostępnych funkcji, zróbmy to teraz:

Świetnie, mamy już wszystkie funkcje. Pytanie brzmi: kiedy ich używać? Ten klient jest dość prosty – oznacza to, że musimy wywoływać funkcje explicite, gdy chcemy z nich skorzystać. W następnym rozdziale stworzymy bardziej zaawansowanego klienta, który będzie miał dostęp do własnego dużego modelu językowego (LLM). Na razie zobaczmy, jak wywołać funkcje serwera:

### -4- Wywoływanie funkcji

Aby wywołać funkcje, musimy podać odpowiednie argumenty, a w niektórych przypadkach nazwę tego, co chcemy wywołać.

### -5- Uruchamianie klienta

Aby uruchomić klienta, wpisz następujące polecenie w terminalu:

## Zadanie

W tym zadaniu wykorzystasz zdobytą wiedzę do stworzenia własnego klienta.

Oto serwer, którego możesz użyć, wywołując go za pomocą swojego kodu klienta. Sprawdź, czy potrafisz dodać więcej funkcji do serwera, aby uczynić go bardziej interesującym.

## Rozwiązanie

[Solution](./solution/README.md)

## Najważniejsze informacje

Najważniejsze informacje dotyczące klientów w tym rozdziale to:

- Klient może służyć zarówno do odkrywania, jak i wywoływania funkcji na serwerze.
- Klient może uruchomić serwer podczas własnego startu (tak jak w tym rozdziale), ale może też łączyć się z już działającymi serwerami.
- To świetny sposób na testowanie możliwości serwera, obok alternatyw takich jak Inspector, opisany w poprzednim rozdziale.

## Dodatkowe materiały

- [Budowanie klientów w MCP](https://modelcontextprotocol.io/quickstart/client)

## Przykłady

- [Kalkulator w Javie](../samples/java/calculator/README.md)
- [Kalkulator w .Net](../../../../03-GettingStarted/samples/csharp)
- [Kalkulator w JavaScript](../samples/javascript/README.md)
- [Kalkulator w TypeScript](../samples/typescript/README.md)
- [Kalkulator w Pythonie](../../../../03-GettingStarted/samples/python)

## Co dalej

- Następny rozdział: [Tworzenie klienta z LLM](/03-GettingStarted/03-llm-client/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy traktować jako źródło wiążące. W przypadku istotnych informacji zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.