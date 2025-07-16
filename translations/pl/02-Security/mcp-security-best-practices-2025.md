<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-16T23:12:14+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "pl"
}
-->
# Najlepsze praktyki bezpieczeństwa MCP – aktualizacja lipiec 2025

## Kompleksowe najlepsze praktyki bezpieczeństwa dla implementacji MCP

Pracując z serwerami MCP, stosuj się do poniższych najlepszych praktyk bezpieczeństwa, aby chronić swoje dane, infrastrukturę i użytkowników:

1. **Walidacja danych wejściowych**: Zawsze waliduj i oczyszczaj dane wejściowe, aby zapobiec atakom typu injection oraz problemom z tzw. confused deputy.
   - Wdrażaj rygorystyczną walidację wszystkich parametrów narzędzi
   - Używaj walidacji schematów, aby upewnić się, że żądania odpowiadają oczekiwanym formatom
   - Filtruj potencjalnie złośliwe treści przed przetwarzaniem

2. **Kontrola dostępu**: Zapewnij odpowiednią autoryzację i uwierzytelnianie dla serwera MCP z precyzyjnym podziałem uprawnień.
   - Korzystaj z OAuth 2.0 z zaufanymi dostawcami tożsamości, takimi jak Microsoft Entra ID
   - Wdrażaj kontrolę dostępu opartą na rolach (RBAC) dla narzędzi MCP
   - Nigdy nie twórz własnych mechanizmów uwierzytelniania, jeśli istnieją sprawdzone rozwiązania

3. **Bezpieczna komunikacja**: Używaj HTTPS/TLS do wszystkich połączeń z serwerem MCP i rozważ dodatkowe szyfrowanie dla wrażliwych danych.
   - Konfiguruj TLS 1.3 tam, gdzie to możliwe
   - Wdrażaj pinning certyfikatów dla krytycznych połączeń
   - Regularnie rotuj certyfikaty i weryfikuj ich ważność

4. **Ograniczanie liczby żądań (rate limiting)**: Wdrażaj ograniczenia liczby żądań, aby zapobiec nadużyciom, atakom DoS oraz kontrolować zużycie zasobów.
   - Ustal odpowiednie limity żądań na podstawie przewidywanych wzorców użytkowania
   - Wdrażaj stopniowane reakcje na nadmierną liczbę żądań
   - Rozważ limity specyficzne dla użytkownika w zależności od statusu uwierzytelnienia

5. **Logowanie i monitorowanie**: Monitoruj serwer MCP pod kątem podejrzanej aktywności i wdrażaj kompleksowe ścieżki audytu.
   - Loguj wszystkie próby uwierzytelnienia i wywołania narzędzi
   - Wdrażaj alerty w czasie rzeczywistym na podejrzane wzorce
   - Zapewnij bezpieczne przechowywanie logów, uniemożliwiające ich modyfikację

6. **Bezpieczne przechowywanie**: Chroń wrażliwe dane i poświadczenia za pomocą odpowiedniego szyfrowania danych w spoczynku.
   - Korzystaj z sejfów kluczy lub bezpiecznych magazynów poświadczeń dla wszystkich sekretów
   - Wdrażaj szyfrowanie na poziomie pól dla wrażliwych danych
   - Regularnie rotuj klucze szyfrowania i poświadczenia

7. **Zarządzanie tokenami**: Zapobiegaj podatnościom związanym z przekazywaniem tokenów, walidując i oczyszczając wszystkie dane wejściowe i wyjściowe modeli.
   - Wdrażaj walidację tokenów na podstawie deklaracji audience
   - Nigdy nie akceptuj tokenów, które nie zostały wyraźnie wydane dla Twojego serwera MCP
   - Zapewnij odpowiednie zarządzanie czasem życia tokenów i ich rotację

8. **Zarządzanie sesjami**: Wdrażaj bezpieczne zarządzanie sesjami, aby zapobiec przejęciu sesji i atakom typu fixation.
   - Używaj bezpiecznych, niedeterministycznych identyfikatorów sesji
   - Powiąż sesje z informacjami specyficznymi dla użytkownika
   - Wdrażaj odpowiednie wygasanie i rotację sesji

9. **Izolacja wykonywania narzędzi**: Uruchamiaj narzędzia w odizolowanych środowiskach, aby zapobiec rozprzestrzenianiu się ataku w przypadku kompromitacji.
   - Wdrażaj izolację kontenerową dla wykonywania narzędzi
   - Nakładaj limity zasobów, aby zapobiec atakom wyczerpania zasobów
   - Używaj oddzielnych kontekstów wykonawczych dla różnych domen bezpieczeństwa

10. **Regularne audyty bezpieczeństwa**: Przeprowadzaj okresowe przeglądy bezpieczeństwa implementacji MCP i ich zależności.
    - Planuj regularne testy penetracyjne
    - Korzystaj z automatycznych narzędzi skanujących w celu wykrywania podatności
    - Aktualizuj zależności, aby usuwać znane problemy bezpieczeństwa

11. **Filtrowanie bezpieczeństwa treści**: Wdrażaj filtry bezpieczeństwa treści zarówno dla danych wejściowych, jak i wyjściowych.
    - Korzystaj z Azure Content Safety lub podobnych usług do wykrywania szkodliwych treści
    - Wdrażaj techniki ochrony promptów, aby zapobiec wstrzykiwaniu poleceń
    - Skanuj generowane treści pod kątem potencjalnego wycieku wrażliwych danych

12. **Bezpieczeństwo łańcucha dostaw**: Weryfikuj integralność i autentyczność wszystkich komponentów w łańcuchu dostaw AI.
    - Używaj podpisanych pakietów i weryfikuj ich podpisy
    - Wdrażaj analizę software bill of materials (SBOM)
    - Monitoruj aktualizacje zależności pod kątem złośliwych zmian

13. **Ochrona definicji narzędzi**: Zapobiegaj zatruwaniu narzędzi, zabezpieczając definicje i metadane narzędzi.
    - Waliduj definicje narzędzi przed ich użyciem
    - Monitoruj nieoczekiwane zmiany w metadanych narzędzi
    - Wdrażaj kontrole integralności definicji narzędzi

14. **Dynamiczne monitorowanie wykonania**: Monitoruj zachowanie serwerów MCP i narzędzi podczas działania.
    - Wdrażaj analizę behawioralną w celu wykrywania anomalii
    - Konfiguruj alerty na nieoczekiwane wzorce wykonania
    - Korzystaj z technik runtime application self-protection (RASP)

15. **Zasada najmniejszych uprawnień**: Zapewnij, że serwery MCP i narzędzia działają z minimalnym niezbędnym poziomem uprawnień.
    - Przyznawaj tylko konkretne uprawnienia potrzebne do wykonania danej operacji
    - Regularnie przeglądaj i audytuj wykorzystanie uprawnień
    - Wdrażaj dostęp just-in-time dla funkcji administracyjnych

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.