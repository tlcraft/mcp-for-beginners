<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-12T22:02:10+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "pl"
}
-->
Teraz, gdy wiemy już trochę więcej o SSE, zbudujmy serwer SSE.

## Ćwiczenie: Tworzenie serwera SSE

Aby stworzyć nasz serwer, musimy pamiętać o dwóch rzeczach:

- Musimy użyć serwera webowego, aby udostępnić endpointy do połączenia i wiadomości.
- Zbudować nasz serwer tak, jak zwykle, korzystając z narzędzi, zasobów i promptów, tak jak przy użyciu stdio.

### -1- Utwórz instancję serwera

Aby stworzyć serwer, używamy tych samych typów co przy stdio. Jednak dla transportu musimy wybrać SSE.

---

Dodajmy teraz potrzebne trasy.

### -2- Dodaj trasy

Dodajmy trasy obsługujące połączenie i przychodzące wiadomości:

---

Dodajmy teraz możliwości serwera.

### -3- Dodawanie możliwości serwera

Skoro mamy już wszystko specyficzne dla SSE, dodajmy możliwości serwera, takie jak narzędzia, prompt i zasoby.

---

Twój pełny kod powinien wyglądać tak:

---

Świetnie, mamy serwer korzystający z SSE, teraz przetestujmy go.

## Ćwiczenie: Debugowanie serwera SSE za pomocą Inspectora

Inspector to świetne narzędzie, które poznaliśmy w poprzedniej lekcji [Tworzenie pierwszego serwera](/03-GettingStarted/01-first-server/README.md). Sprawdźmy, czy możemy go użyć także tutaj:

### -1- Uruchamianie Inspectora

Aby uruchomić Inspectora, najpierw musisz mieć działający serwer SSE, więc zróbmy to teraz:

1. Uruchom serwer

---

1. Uruchom Inspectora

    > ![NOTE]
    > Uruchom to w osobnym oknie terminala niż ten, w którym działa serwer. Zwróć też uwagę, że musisz dostosować poniższe polecenie do adresu URL, pod którym działa twój serwer.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Uruchamianie Inspectora wygląda tak samo we wszystkich środowiskach uruchomieniowych. Zauważ, że zamiast podawać ścieżkę do serwera i komendę uruchamiającą serwer, podajemy URL, pod którym serwer działa, oraz określamy trasę `/sse`.

### -2- Wypróbowanie narzędzia

Połącz się z serwerem, wybierając SSE z listy rozwijanej i wpisz adres URL, pod którym działa twój serwer, na przykład http:localhost:4321/sse. Następnie kliknij przycisk "Connect". Jak wcześniej, wybierz listę narzędzi, wybierz narzędzie i podaj wartości wejściowe. Powinieneś zobaczyć wynik podobny do poniższego:

![Serwer SSE działający w inspectorze](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.pl.png)

Świetnie, możesz pracować z Inspectorem, zobaczmy teraz, jak pracować z Visual Studio Code.

## Zadanie

Spróbuj rozbudować swój serwer o więcej możliwości. Zobacz [tę stronę](https://api.chucknorris.io/), aby na przykład dodać narzędzie wywołujące API, zdecyduj, jak ma wyglądać twój serwer. Powodzenia :)

## Rozwiązanie

[Rozwiązanie](./solution/README.md) Oto możliwe rozwiązanie z działającym kodem.

## Kluczowe wnioski

Najważniejsze wnioski z tego rozdziału to:

- SSE to drugi wspierany transport obok stdio.
- Aby obsłużyć SSE, musisz zarządzać przychodzącymi połączeniami i wiadomościami za pomocą frameworka webowego.
- Możesz używać zarówno Inspectora, jak i Visual Studio Code do korzystania z serwera SSE, tak jak z serwerami stdio. Zauważ, że różni się to nieco między stdio a SSE. W przypadku SSE musisz osobno uruchomić serwer, a potem uruchomić narzędzie Inspector. Dla narzędzia Inspector jest też różnica w tym, że musisz podać URL.

## Przykłady

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatkowe zasoby

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Co dalej

- Następne: [HTTP Streaming z MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub nieścisłości. Oryginalny dokument w jego języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.