<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-04T17:10:37+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "pl"
}
-->
W poprzednim kodzie:

- Importujemy biblioteki
- Tworzymy instancję klienta i łączymy ją za pomocą stdio jako transportu.
- Wypisujemy promptsy, zasoby i narzędzia oraz wywołujemy je wszystkie.

Oto masz klienta, który potrafi komunikować się z serwerem MCP.

W następnej sekcji ćwiczeń poświęcimy czas na rozbicie każdego fragmentu kodu i wyjaśnienie, co się dzieje.

## Ćwiczenie: Pisanie klienta

Jak wspomniano wcześniej, poświęćmy czas na wyjaśnienie kodu, a jeśli chcesz, możesz kodować razem z nami.

### -1- Importowanie bibliotek

Zaimportujmy potrzebne biblioteki, będziemy potrzebować odniesień do klienta oraz do wybranego protokołu transportowego, czyli stdio. stdio to protokół przeznaczony do działania na lokalnej maszynie. SSE to inny protokół transportowy, który pokażemy w przyszłych rozdziałach, ale to jest twoja inna opcja. Na razie jednak kontynuujmy ze stdio.

Przejdźmy teraz do tworzenia instancji.

### -2- Tworzenie instancji klienta i transportu

Musimy utworzyć instancję transportu oraz instancję naszego klienta:

### -3- Wypisywanie funkcji serwera

Teraz mamy klienta, który może się połączyć, jeśli program zostanie uruchomiony. Jednak nie wypisuje on jeszcze swoich funkcji, więc zróbmy to teraz:

Świetnie, teraz mamy wszystkie funkcje. Pytanie brzmi: kiedy ich używać? Ten klient jest dość prosty, w tym sensie, że musimy wywoływać funkcje explicite, gdy ich potrzebujemy. W następnym rozdziale stworzymy bardziej zaawansowanego klienta, który będzie miał dostęp do własnego dużego modelu językowego (LLM). Na razie jednak zobaczmy, jak wywołać funkcje na serwerze:

### -4- Wywoływanie funkcji

Aby wywołać funkcje, musimy upewnić się, że podajemy poprawne argumenty, a w niektórych przypadkach nazwę tego, co chcemy wywołać.

### -5- Uruchomienie klienta

Aby uruchomić klienta, wpisz następujące polecenie w terminalu:

## Zadanie

W tym zadaniu wykorzystasz to, czego się nauczyłeś, tworząc własnego klienta.

Oto serwer, którego możesz użyć i do którego musisz się odwołać za pomocą swojego kodu klienta. Spróbuj dodać więcej funkcji do serwera, aby uczynić go bardziej interesującym.

## Rozwiązanie

[Solution](./solution/README.md)

## Najważniejsze wnioski

Najważniejsze wnioski z tego rozdziału dotyczące klientów to:

- Mogą służyć zarówno do odkrywania, jak i wywoływania funkcji na serwerze.
- Mogą uruchomić serwer podczas własnego startu (jak w tym rozdziale), ale klienci mogą też łączyć się z już działającymi serwerami.
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

- Następny: [Tworzenie klienta z LLM](../03-llm-client/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy traktować jako źródło wiążące. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.