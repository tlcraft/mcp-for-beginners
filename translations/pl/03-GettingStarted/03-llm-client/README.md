<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:21:39+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "pl"
}
-->
Świetnie, w kolejnym kroku wypiszmy możliwości serwera.

### -2 Wypisz możliwości serwera

Teraz połączymy się z serwerem i poprosimy o jego możliwości:

### -3- Konwersja możliwości serwera na narzędzia LLM

Kolejnym krokiem po wypisaniu możliwości serwera jest przekształcenie ich do formatu zrozumiałego dla LLM. Gdy to zrobimy, możemy udostępnić te możliwości jako narzędzia dla naszego LLM.

Świetnie, teraz jesteśmy gotowi, aby obsłużyć żądania użytkownika, zajmijmy się tym.

### -4- Obsługa zapytań użytkownika

W tej części kodu zajmiemy się obsługą zapytań użytkownika.

Świetnie, udało się!

## Zadanie

Weź kod z ćwiczenia i rozbuduj serwer o dodatkowe narzędzia. Następnie stwórz klienta z LLM, tak jak w ćwiczeniu, i przetestuj go z różnymi promptami, aby upewnić się, że wszystkie narzędzia serwera są wywoływane dynamicznie. Ten sposób tworzenia klienta zapewnia użytkownikowi końcowemu doskonałe doświadczenie, ponieważ może korzystać z promptów zamiast precyzyjnych poleceń klienta i nie musi wiedzieć o wywoływaniu serwera MCP.

## Rozwiązanie

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Najważniejsze informacje

- Dodanie LLM do klienta zapewnia lepszy sposób interakcji użytkowników z serwerami MCP.
- Musisz przekształcić odpowiedź serwera MCP do formatu zrozumiałego dla LLM.

## Przykłady

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatkowe zasoby

## Co dalej

- Dalej: [Korzystanie z serwera za pomocą Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy uważać za źródło autorytatywne. W przypadku istotnych informacji zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.