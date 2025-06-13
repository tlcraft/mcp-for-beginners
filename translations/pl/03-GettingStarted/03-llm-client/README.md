<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:30:49+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "pl"
}
-->
Świetnie, w kolejnym kroku wypiszmy możliwości serwera.

### -2 Wypisz możliwości serwera

Teraz połączymy się z serwerem i poprosimy o jego możliwości:

### -3- Konwersja możliwości serwera na narzędzia LLM

Kolejnym krokiem po wypisaniu możliwości serwera jest przekształcenie ich na format zrozumiały dla LLM. Gdy to zrobimy, możemy udostępnić te możliwości jako narzędzia dla naszego LLM.

Świetnie, jesteśmy gotowi, by obsłużyć zapytania użytkownika, więc zajmijmy się tym teraz.

### -4- Obsługa zapytania użytkownika

W tej części kodu zajmiemy się obsługą zapytań użytkownika.

Świetnie, udało się!

## Zadanie

Weź kod z ćwiczenia i rozbuduj serwer o więcej narzędzi. Następnie stwórz klienta z LLM, tak jak w ćwiczeniu, i przetestuj go różnymi promptami, aby upewnić się, że wszystkie narzędzia serwera są wywoływane dynamicznie. Taki sposób tworzenia klienta zapewnia doskonałe doświadczenie użytkownika końcowego, ponieważ może on korzystać z promptów zamiast dokładnych poleceń klienta i nie musi wiedzieć o wywołaniach serwera MCP.

## Rozwiązanie

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Kluczowe wnioski

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

- Następne: [Korzystanie z serwera za pomocą Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.