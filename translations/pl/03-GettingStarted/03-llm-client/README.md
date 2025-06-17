<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:48:49+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "pl"
}
-->
Świetnie, w kolejnym kroku wypiszmy możliwości serwera.

### -2 Wypisz możliwości serwera

Teraz połączymy się z serwerem i zapytamy o jego możliwości: 

### -3- Konwersja możliwości serwera na narzędzia LLM

Kolejnym krokiem po wypisaniu możliwości serwera jest przekształcenie ich do formatu, który rozumie LLM. Gdy to zrobimy, możemy udostępnić te możliwości jako narzędzia dla naszego LLM.

Świetnie, teraz jesteśmy gotowi obsłużyć żądania użytkownika, zajmijmy się tym.

### -4- Obsługa zapytań użytkownika

W tej części kodu będziemy obsługiwać zapytania użytkownika.

Świetnie, udało się!

## Zadanie

Weź kod z ćwiczenia i rozbuduj serwer o więcej narzędzi. Następnie stwórz klienta z LLM, tak jak w ćwiczeniu, i przetestuj go z różnymi promptami, aby upewnić się, że wszystkie narzędzia serwera są wywoływane dynamicznie. Taki sposób budowania klienta zapewnia użytkownikowi końcowemu świetne doświadczenie, ponieważ może korzystać z promptów zamiast dokładnych poleceń klienta i nie musi wiedzieć o wywołaniach serwera MCP.

## Rozwiązanie

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Najważniejsze wnioski

- Dodanie LLM do klienta zapewnia lepszy sposób interakcji użytkowników z serwerami MCP.
- Musisz przekształcić odpowiedź serwera MCP na format zrozumiały dla LLM.

## Przykłady

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatkowe zasoby

## Co dalej

- Następny temat: [Korzystanie z serwera za pomocą Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być traktowany jako źródło autorytatywne. W przypadku informacji o krytycznym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.