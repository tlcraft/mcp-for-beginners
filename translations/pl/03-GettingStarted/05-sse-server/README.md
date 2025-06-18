<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1681ca3633aeb49ee03766abdbb94a93",
  "translation_date": "2025-06-17T22:10:50+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "pl"
}
-->
Teraz, gdy wiemy już trochę więcej o SSE, zbudujmy serwer SSE.

## Ćwiczenie: Tworzenie serwera SSE

Aby stworzyć nasz serwer, musimy mieć na uwadze dwie rzeczy:

- Musimy użyć serwera WWW, aby udostępnić endpointy do połączenia i przesyłania wiadomości.
- Budujemy serwer tak, jak zwykle, korzystając z narzędzi, zasobów i promptów, tak jak robiliśmy to przy użyciu stdio.

### -1- Utwórz instancję serwera

Do stworzenia serwera używamy tych samych typów co przy stdio. Jednak jako transport wybieramy SSE.

Dodajmy teraz potrzebne trasy.

### -2- Dodaj trasy

Dodajmy trasy, które obsłużą połączenie oraz nadchodzące wiadomości:

Dodajmy teraz funkcjonalności do serwera.

### -3- Dodawanie funkcji serwera

Gdy mamy już wszystko, co specyficzne dla SSE, dodajmy funkcje serwera, takie jak narzędzia, prompt i zasoby.

Twój pełny kod powinien wyglądać tak:

Świetnie, mamy serwer korzystający z SSE, wypróbujmy go teraz.

## Ćwiczenie: Debugowanie serwera SSE za pomocą Inspector

Inspector to świetne narzędzie, które poznaliśmy w poprzedniej lekcji [Tworzenie pierwszego serwera](/03-GettingStarted/01-first-server/README.md). Sprawdźmy, czy możemy go użyć także tutaj:

### -1- Uruchomienie Inspectora

Aby uruchomić Inspectora, najpierw musisz mieć działający serwer SSE, więc zróbmy to teraz:

1. Uruchom serwer

1. Uruchom Inspectora

    > ![NOTE]
    > Uruchom to w osobnym oknie terminala niż ten, w którym działa serwer. Pamiętaj też, aby dostosować poniższe polecenie do URL, pod którym działa Twój serwer.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Uruchamianie Inspectora wygląda tak samo we wszystkich środowiskach uruchomieniowych. Zauważ, że zamiast podawać ścieżkę do naszego serwera i polecenie uruchomienia serwera, podajemy URL, pod którym działa serwer, oraz określamy trasę `/sse`.

### -2- Wypróbowanie narzędzia

Połącz się z serwerem, wybierając SSE z listy rozwijanej i wpisz adres URL, pod którym działa Twój serwer, na przykład http://localhost:4321/sse. Następnie kliknij przycisk "Connect". Jak wcześniej, wybierz listę narzędzi, wybierz narzędzie i podaj wartości wejściowe. Powinieneś zobaczyć wynik podobny do poniższego:

![Serwer SSE działający w inspectorze](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.pl.png)

Świetnie, potrafisz pracować z Inspectorem, zobaczmy teraz, jak pracować z Visual Studio Code.

## Zadanie

Spróbuj rozbudować swój serwer o więcej funkcji. Zobacz [tę stronę](https://api.chucknorris.io/), aby na przykład dodać narzędzie wywołujące API. To Ty decydujesz, jak ma wyglądać serwer. Powodzenia :)

## Rozwiązanie

[Rozwiązanie](./solution/README.md) Oto możliwe rozwiązanie z działającym kodem.

## Najważniejsze wnioski

Najważniejsze wnioski z tego rozdziału to:

- SSE to drugi obsługiwany transport obok stdio.
- Aby obsługiwać SSE, musisz zarządzać przychodzącymi połączeniami i wiadomościami za pomocą frameworka webowego.
- Możesz używać zarówno Inspectora, jak i Visual Studio Code do korzystania z serwera SSE, tak jak z serwerów stdio. Zauważ, że jest tu pewna różnica między stdio a SSE. W przypadku SSE musisz najpierw uruchomić serwer osobno, a potem uruchomić narzędzie Inspector. W przypadku Inspectora jest też różnica w tym, że musisz podać URL.

## Przykłady

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatkowe zasoby

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Co dalej

- Dalej: [HTTP Streaming z MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy pamiętać, że tłumaczenia automatyczne mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy traktować jako źródło autorytatywne. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.