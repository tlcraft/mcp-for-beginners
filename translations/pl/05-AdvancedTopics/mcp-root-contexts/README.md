<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8311f46a35cf608c9780f39b62c9dc3f",
  "translation_date": "2025-07-14T02:02:30+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "pl"
}
-->
## Przykład: Implementacja Root Context dla analizy finansowej

W tym przykładzie utworzymy root context dla sesji analizy finansowej, pokazując, jak utrzymać stan podczas wielu interakcji.

## Przykład: Zarządzanie Root Context

Skuteczne zarządzanie root contexts jest kluczowe dla utrzymania historii rozmów i stanu. Poniżej znajduje się przykład implementacji zarządzania root context.

## Root Context dla wieloetapowej pomocy

W tym przykładzie utworzymy root context dla sesji wieloetapowej pomocy, demonstrując, jak utrzymać stan podczas wielu interakcji.

## Najlepsze praktyki dotyczące Root Context

Oto kilka najlepszych praktyk dotyczących skutecznego zarządzania root contexts:

- **Twórz skoncentrowane konteksty**: Twórz oddzielne root contexts dla różnych celów rozmowy lub dziedzin, aby zachować przejrzystość.

- **Ustal polityki wygasania**: Wdrażaj polityki archiwizacji lub usuwania starych kontekstów, aby zarządzać przestrzenią dyskową i spełniać wymogi dotyczące przechowywania danych.

- **Przechowuj istotne metadane**: Wykorzystuj metadane kontekstu do zapisywania ważnych informacji o rozmowie, które mogą być przydatne później.

- **Korzystaj ze spójnych identyfikatorów kontekstu**: Po utworzeniu kontekstu używaj jego ID konsekwentnie we wszystkich powiązanych żądaniach, aby zachować ciągłość.

- **Generuj podsumowania**: Gdy kontekst staje się obszerny, rozważ generowanie podsumowań, które uchwycą najważniejsze informacje, jednocześnie kontrolując rozmiar kontekstu.

- **Wdrażaj kontrolę dostępu**: W systemach wieloużytkownikowych zapewnij odpowiednie mechanizmy kontroli dostępu, aby chronić prywatność i bezpieczeństwo kontekstów rozmów.

- **Radź sobie z ograniczeniami kontekstu**: Bądź świadomy ograniczeń rozmiaru kontekstu i wdrażaj strategie radzenia sobie z bardzo długimi rozmowami.

- **Archiwizuj po zakończeniu**: Archiwizuj konteksty po zakończeniu rozmów, aby zwolnić zasoby, jednocześnie zachowując historię konwersacji.

## Co dalej

- [5.5 Routing](../mcp-routing/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.