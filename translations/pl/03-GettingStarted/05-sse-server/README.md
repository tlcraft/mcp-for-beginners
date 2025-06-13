<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "64645691bf0985f1760b948123edf269",
  "translation_date": "2025-06-13T10:49:24+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "pl"
}
-->
Teraz, gdy wiemy już trochę więcej o SSE, zbudujmy serwer SSE.

## Ćwiczenie: Tworzenie serwera SSE

Aby stworzyć nasz serwer, musimy pamiętać o dwóch rzeczach:

- Musimy użyć serwera WWW, aby udostępnić endpointy do połączenia i wiadomości.
- Zbudować nasz serwer tak, jak zwykle, korzystając z narzędzi, zasobów i promptów, tak jak robiliśmy to ze stdio.

### -1- Utwórz instancję serwera

Do stworzenia serwera używamy tych samych typów co ze stdio. Jednak dla transportu musimy wybrać SSE.

---

Dodajmy teraz potrzebne trasy.

### -2- Dodaj trasy

Dodajmy trasy, które obsługują połączenie i nadchodzące wiadomości:

---

Dodajmy teraz możliwości serwera.

### -3- Dodawanie możliwości serwera

Teraz, gdy mamy wszystko specyficzne dla SSE zdefiniowane, dodajmy możliwości serwera, takie jak narzędzia, prompt i zasoby.

---

Twój pełny kod powinien wyglądać tak:

---

Świetnie, mamy serwer korzystający z SSE, przetestujmy go teraz.

## Ćwiczenie: Debugowanie serwera SSE za pomocą Inspector

Inspector to świetne narzędzie, które poznaliśmy w poprzedniej lekcji [Tworzenie pierwszego serwera](/03-GettingStarted/01-first-server/README.md). Sprawdźmy, czy możemy go użyć również tutaj:

### -1- Uruchamianie Inspector

Aby uruchomić Inspector, najpierw musisz mieć działający serwer SSE, więc zróbmy to teraz:

1. Uruchom serwer

---

1. Uruchom Inspector

    > ![NOTE]
    > Uruchom to w osobnym oknie terminala niż ten, w którym działa serwer. Zwróć też uwagę, że musisz dostosować poniższe polecenie do URL, pod którym działa twój serwer.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Uruchamianie Inspector wygląda tak samo we wszystkich środowiskach uruchomieniowych. Zauważ, że zamiast podawać ścieżkę do naszego serwera i polecenie uruchomienia serwera, podajemy URL, pod którym serwer działa, oraz określamy trasę `/sse`.

### -2- Wypróbowanie narzędzia

Połącz się z serwerem, wybierając SSE z listy rozwijanej i wpisz adres URL, pod którym działa twój serwer, na przykład http://localhost:4321/sse. Następnie kliknij przycisk "Connect". Jak wcześniej, wybierz listę narzędzi, wybierz narzędzie i podaj wartości wejściowe. Powinieneś zobaczyć wynik podobny do poniższego:

![Serwer SSE działający w Inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.pl.png)

Świetnie, możesz pracować z Inspector, zobaczmy teraz, jak możemy korzystać z Visual Studio Code.

## Zadanie

Spróbuj rozbudować swój serwer o więcej możliwości. Zobacz [tę stronę](https://api.chucknorris.io/), aby na przykład dodać narzędzie wywołujące API, sam zdecyduj, jak ma wyglądać serwer. Miłej zabawy :)

## Rozwiązanie

[Rozwiązanie](./solution/README.md) Oto możliwe rozwiązanie z działającym kodem.

## Kluczowe wnioski

Najważniejsze wnioski z tego rozdziału to:

- SSE to drugi obsługiwany typ transportu obok stdio.
- Aby obsługiwać SSE, musisz zarządzać przychodzącymi połączeniami i wiadomościami za pomocą frameworka webowego.
- Możesz używać zarówno Inspector, jak i Visual Studio Code do korzystania z serwera SSE, tak jak z serwerów stdio. Zwróć uwagę, że różni się to nieco między stdio a SSE. Dla SSE musisz osobno uruchomić serwer, a potem narzędzie Inspector. W przypadku Inspector trzeba też podać URL.

## Przykłady

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatkowe zasoby

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Co dalej

- Następny temat: [HTTP Streaming z MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym należy uważać za źródło autorytatywne. W przypadku informacji o istotnym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.