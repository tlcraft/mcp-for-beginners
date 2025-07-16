<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-16T23:06:40+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "pl"
}
-->
# Najnowsze Kontrole Bezpieczeństwa MCP – Aktualizacja lipiec 2025

W miarę jak Model Context Protocol (MCP) nadal się rozwija, bezpieczeństwo pozostaje kluczowym aspektem. Ten dokument przedstawia najnowsze kontrole bezpieczeństwa oraz najlepsze praktyki dotyczące bezpiecznej implementacji MCP na lipiec 2025.

## Uwierzytelnianie i Autoryzacja

### Wsparcie dla delegacji OAuth 2.0

Najnowsze aktualizacje specyfikacji MCP pozwalają serwerom MCP na delegowanie uwierzytelniania użytkowników do zewnętrznych usług, takich jak Microsoft Entra ID. Znacząco poprawia to poziom bezpieczeństwa poprzez:

1. **Eliminację własnych implementacji uwierzytelniania**: Zmniejsza ryzyko błędów bezpieczeństwa w niestandardowym kodzie uwierzytelniającym  
2. **Wykorzystanie sprawdzonych dostawców tożsamości**: Korzystanie z funkcji bezpieczeństwa na poziomie korporacyjnym  
3. **Centralizację zarządzania tożsamością**: Ułatwia zarządzanie cyklem życia użytkownika i kontrolę dostępu  

## Zapobieganie przekazywaniu tokenów

Specyfikacja autoryzacji MCP wyraźnie zabrania przekazywania tokenów, aby zapobiec obchodzeniu kontroli bezpieczeństwa i problemom z odpowiedzialnością.

### Kluczowe wymagania

1. **Serwery MCP NIE MOGĄ akceptować tokenów nieprzeznaczonych dla nich**: Należy weryfikować, czy wszystkie tokeny mają poprawny claim audience  
2. **Wdrożenie właściwej walidacji tokenów**: Sprawdzenie wystawcy, odbiorcy, daty ważności oraz podpisu  
3. **Używanie osobnej emisji tokenów**: Wydawanie nowych tokenów dla usług downstream zamiast przekazywania istniejących  

## Bezpieczne zarządzanie sesjami

Aby zapobiec przejęciu sesji i atakom typu fixation, należy wdrożyć następujące kontrole:

1. **Używaj bezpiecznych, niedeterministycznych identyfikatorów sesji**: Generowanych za pomocą kryptograficznie bezpiecznych generatorów liczb losowych  
2. **Powiąż sesje z tożsamością użytkownika**: Łączenie ID sesji z informacjami specyficznymi dla użytkownika  
3. **Wdroż właściwą rotację sesji**: Po zmianach uwierzytelniania lub eskalacji uprawnień  
4. **Ustaw odpowiednie limity czasu sesji**: Zachowaj równowagę między bezpieczeństwem a wygodą użytkownika  

## Izolacja wykonywania narzędzi

Aby zapobiec ruchowi bocznemu i ograniczyć potencjalne naruszenia:

1. **Izoluj środowiska wykonywania narzędzi**: Używaj kontenerów lub oddzielnych procesów  
2. **Stosuj limity zasobów**: Zapobiegaj atakom wyczerpania zasobów  
3. **Wdrażaj zasadę najmniejszych uprawnień**: Przyznawaj tylko niezbędne uprawnienia  
4. **Monitoruj wzorce wykonywania**: Wykrywaj anomalie w zachowaniu  

## Ochrona definicji narzędzi

Aby zapobiec zatruwaniu narzędzi:

1. **Weryfikuj definicje narzędzi przed użyciem**: Sprawdzaj pod kątem złośliwych instrukcji lub nieodpowiednich wzorców  
2. **Stosuj weryfikację integralności**: Haszuj lub podpisuj definicje narzędzi, aby wykryć nieautoryzowane zmiany  
3. **Wdrażaj monitorowanie zmian**: Powiadamiaj o nieoczekiwanych modyfikacjach metadanych narzędzi  
4. **Kontroluj wersje definicji narzędzi**: Śledź zmiany i umożliwiaj przywracanie poprzednich wersji w razie potrzeby  

Te kontrole współdziałają, tworząc solidną postawę bezpieczeństwa dla implementacji MCP, odpowiadając na unikalne wyzwania systemów opartych na AI, jednocześnie utrzymując silne, tradycyjne praktyki bezpieczeństwa.

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.