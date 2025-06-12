<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8311f46a35cf608c9780f39b62c9dc3f",
  "translation_date": "2025-06-12T22:04:59+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "pl"
}
-->
## Przykład: Implementacja Root Context dla analizy finansowej

W tym przykładzie utworzymy root context dla sesji analizy finansowej, pokazując, jak utrzymać stan podczas wielu interakcji.

## Przykład: Zarządzanie Root Context

Skuteczne zarządzanie root context jest kluczowe dla utrzymania historii rozmów i stanu. Poniżej znajduje się przykład, jak zaimplementować zarządzanie root context.

## Root Context dla wieloetapowej pomocy

W tym przykładzie utworzymy root context dla sesji wieloetapowej pomocy, demonstrując, jak utrzymać stan podczas wielu interakcji.

## Najlepsze praktyki dotyczące Root Context

Oto kilka najlepszych praktyk dotyczących skutecznego zarządzania root context:

- **Twórz skoncentrowane konteksty**: Twórz oddzielne root context dla różnych celów rozmowy lub dziedzin, aby zachować przejrzystość.

- **Ustal polityki wygasania**: Wdrażaj polityki archiwizacji lub usuwania starych kontekstów, aby zarządzać miejscem i spełniać wymogi dotyczące przechowywania danych.

- **Przechowuj istotne metadane**: Wykorzystuj metadane kontekstu do zapisywania ważnych informacji o rozmowie, które mogą być przydatne później.

- **Korzystaj konsekwentnie z identyfikatorów kontekstu**: Po utworzeniu kontekstu używaj jego ID konsekwentnie we wszystkich powiązanych żądaniach, aby zachować ciągłość.

- **Generuj podsumowania**: Gdy kontekst staje się duży, rozważ generowanie podsumowań, aby uchwycić kluczowe informacje przy jednoczesnym zarządzaniu rozmiarem kontekstu.

- **Wdrażaj kontrolę dostępu**: W systemach wieloużytkownikowych wprowadź odpowiednie mechanizmy kontroli dostępu, aby zapewnić prywatność i bezpieczeństwo kontekstów rozmów.

- **Radź sobie z ograniczeniami kontekstu**: Miej świadomość ograniczeń rozmiaru kontekstu i stosuj strategie radzenia sobie z bardzo długimi rozmowami.

- **Archiwizuj po zakończeniu**: Archiwizuj konteksty po zakończeniu rozmów, aby zwolnić zasoby, zachowując jednocześnie historię rozmowy.

## Co dalej

- [5.5 Routing](../mcp-routing/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.