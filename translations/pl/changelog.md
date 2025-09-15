<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:10:12+00:00",
  "source_file": "changelog.md",
  "language_code": "pl"
}
-->
# Dziennik zmian: MCP dla początkujących - program nauczania

Ten dokument stanowi zapis wszystkich istotnych zmian wprowadzonych w programie nauczania Model Context Protocol (MCP) dla początkujących. Zmiany są dokumentowane w odwrotnej kolejności chronologicznej (najpierw najnowsze).

## 15 września 2025

### Rozszerzenie zaawansowanych tematów - Niestandardowe transporty i inżynieria kontekstu

#### Niestandardowe transporty MCP (05-AdvancedTopics/mcp-transport/) - Nowy przewodnik wdrożeniowy
- **README.md**: Kompletny przewodnik wdrożeniowy dla niestandardowych mechanizmów transportu MCP
  - **Transport Azure Event Grid**: Kompleksowa implementacja transportu bezserwerowego opartego na zdarzeniach
    - Przykłady w C#, TypeScript i Pythonie z integracją Azure Functions
    - Wzorce architektury opartej na zdarzeniach dla skalowalnych rozwiązań MCP
    - Odbiorniki webhooków i obsługa wiadomości w trybie push
  - **Transport Azure Event Hubs**: Implementacja transportu strumieniowego o wysokiej przepustowości
    - Możliwości strumieniowania w czasie rzeczywistym dla scenariuszy o niskim opóźnieniu
    - Strategie partycjonowania i zarządzanie punktami kontrolnymi
    - Grupowanie wiadomości i optymalizacja wydajności
  - **Wzorce integracji przedsiębiorstw**: Przykłady architektury gotowej do produkcji
    - Rozproszone przetwarzanie MCP w wielu funkcjach Azure
    - Hybrydowe architektury transportowe łączące różne typy transportu
    - Trwałość wiadomości, niezawodność i strategie obsługi błędów
  - **Bezpieczeństwo i monitorowanie**: Integracja Azure Key Vault i wzorce obserwowalności
    - Uwierzytelnianie za pomocą zarządzanych tożsamości i dostęp z minimalnymi uprawnieniami
    - Telemetria Application Insights i monitorowanie wydajności
    - Mechanizmy zabezpieczające i wzorce tolerancji błędów
  - **Frameworki testowe**: Kompleksowe strategie testowania dla niestandardowych transportów
    - Testy jednostkowe z użyciem atrap i frameworków do mockowania
    - Testy integracyjne z Azure Test Containers
    - Uwagi dotyczące testów wydajności i obciążenia

#### Inżynieria kontekstu (05-AdvancedTopics/mcp-contextengineering/) - Nowa dziedzina AI
- **README.md**: Kompleksowe omówienie inżynierii kontekstu jako rozwijającej się dziedziny
  - **Podstawowe zasady**: Pełne udostępnianie kontekstu, świadomość decyzji o działaniach i zarządzanie oknem kontekstu
  - **Dostosowanie do protokołu MCP**: Jak projekt MCP rozwiązuje wyzwania związane z inżynierią kontekstu
    - Ograniczenia okna kontekstu i strategie progresywnego ładowania
    - Określanie istotności i dynamiczne pobieranie kontekstu
    - Obsługa kontekstu wielomodalnego i kwestie bezpieczeństwa
  - **Podejścia wdrożeniowe**: Architektury jednowątkowe vs. wieloagentowe
    - Techniki dzielenia kontekstu i ustalania priorytetów
    - Progresywne ładowanie kontekstu i strategie kompresji
    - Warstwowe podejścia do kontekstu i optymalizacja pobierania
  - **Framework pomiarowy**: Nowe metryki oceny efektywności kontekstu
    - Wydajność wejściowa, jakość, wydajność i doświadczenie użytkownika
    - Eksperymentalne podejścia do optymalizacji kontekstu
    - Analiza błędów i metody poprawy

#### Aktualizacje nawigacji w programie nauczania (README.md)
- **Ulepszona struktura modułów**: Zaktualizowana tabela programu nauczania, uwzględniająca nowe zaawansowane tematy
  - Dodano inżynierię kontekstu (5.14) i niestandardowe transporty (5.15)
  - Spójne formatowanie i linki nawigacyjne we wszystkich modułach
  - Zaktualizowane opisy, aby odzwierciedlały aktualny zakres treści

### Ulepszenia struktury katalogów
- **Standaryzacja nazw**: Zmieniono nazwę "mcp transport" na "mcp-transport" dla spójności z innymi folderami zaawansowanych tematów
- **Organizacja treści**: Wszystkie foldery 05-AdvancedTopics teraz mają spójny wzorzec nazewnictwa (mcp-[temat])

### Ulepszenia jakości dokumentacji
- **Dostosowanie do specyfikacji MCP**: Wszystkie nowe treści odwołują się do aktualnej specyfikacji MCP z 18 czerwca 2025 r.
- **Przykłady w wielu językach**: Kompleksowe przykłady kodu w C#, TypeScript i Pythonie
- **Skupienie na przedsiębiorstwach**: Wzorce gotowe do produkcji i integracja z chmurą Azure
- **Dokumentacja wizualna**: Diagramy Mermaid do wizualizacji architektury i przepływów

## 18 sierpnia 2025

### Kompleksowa aktualizacja dokumentacji - Standardy MCP 2025-06-18

#### Najlepsze praktyki bezpieczeństwa MCP (02-Security/) - Kompleksowa modernizacja
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Całkowicie przepisane zgodnie ze specyfikacją MCP z 18 czerwca 2025 r.
  - **Wymagania obowiązkowe**: Dodano wyraźne wymagania MUST/MUST NOT z oficjalnej specyfikacji z jasnymi wskaźnikami wizualnymi
  - **12 podstawowych praktyk bezpieczeństwa**: Przekształcono z listy 15 pozycji w kompleksowe domeny bezpieczeństwa
    - Bezpieczeństwo tokenów i uwierzytelnianie z integracją zewnętrznego dostawcy tożsamości
    - Zarządzanie sesjami i bezpieczeństwo transportu z wymaganiami kryptograficznymi
    - Ochrona przed zagrożeniami specyficznymi dla AI z integracją Microsoft Prompt Shields
    - Kontrola dostępu i uprawnień zgodnie z zasadą minimalnych uprawnień
    - Bezpieczeństwo treści i monitorowanie z integracją Azure Content Safety
    - Bezpieczeństwo łańcucha dostaw z kompleksową weryfikacją komponentów
    - Bezpieczeństwo OAuth i zapobieganie atakom confused deputy z implementacją PKCE
    - Reakcja na incydenty i odzyskiwanie z automatycznymi możliwościami
    - Zgodność i zarządzanie zgodnością z regulacjami
    - Zaawansowane kontrole bezpieczeństwa z architekturą zero trust
    - Integracja ekosystemu bezpieczeństwa Microsoft z kompleksowymi rozwiązaniami
    - Ciągła ewolucja bezpieczeństwa z adaptacyjnymi praktykami
  - **Rozwiązania Microsoft Security**: Ulepszona integracja z Microsoft Prompt Shields, Azure Content Safety, Entra ID i GitHub Advanced Security
  - **Zasoby wdrożeniowe**: Skategoryzowane kompleksowe linki do zasobów według oficjalnej dokumentacji MCP, rozwiązań Microsoft Security, standardów bezpieczeństwa i przewodników wdrożeniowych

#### Zaawansowane kontrole bezpieczeństwa (02-Security/) - Wdrożenie na poziomie przedsiębiorstwa
- **MCP-SECURITY-CONTROLS-2025.md**: Całkowicie przebudowany z ramami bezpieczeństwa na poziomie przedsiębiorstwa
  - **9 kompleksowych domen bezpieczeństwa**: Rozszerzono z podstawowych kontroli do szczegółowych ram dla przedsiębiorstw
    - Zaawansowane uwierzytelnianie i autoryzacja z integracją Microsoft Entra ID
    - Bezpieczeństwo tokenów i kontrole anty-passthrough z kompleksową walidacją
    - Kontrole bezpieczeństwa sesji z zapobieganiem przejęciu
    - Kontrole bezpieczeństwa specyficzne dla AI z zapobieganiem wstrzykiwaniu promptów i zatruwaniu narzędzi
    - Zapobieganie atakom confused deputy z zabezpieczeniami proxy OAuth
    - Bezpieczeństwo wykonywania narzędzi z izolacją i sandboxingiem
    - Kontrole bezpieczeństwa łańcucha dostaw z weryfikacją zależności
    - Kontrole monitorowania i wykrywania z integracją SIEM
    - Reakcja na incydenty i odzyskiwanie z automatycznymi możliwościami
  - **Przykłady wdrożeniowe**: Dodano szczegółowe bloki konfiguracji YAML i przykłady kodu
  - **Integracja rozwiązań Microsoft**: Kompleksowe pokrycie usług bezpieczeństwa Azure, GitHub Advanced Security i zarządzania tożsamością przedsiębiorstwa

#### Zaawansowane tematy bezpieczeństwa (05-AdvancedTopics/mcp-security/) - Wdrożenie gotowe do produkcji
- **README.md**: Całkowicie przepisane dla wdrożenia bezpieczeństwa na poziomie przedsiębiorstwa
  - **Dostosowanie do aktualnej specyfikacji**: Zaktualizowano zgodnie ze specyfikacją MCP z 18 czerwca 2025 r. z obowiązkowymi wymaganiami bezpieczeństwa
  - **Ulepszone uwierzytelnianie**: Integracja Microsoft Entra ID z kompleksowymi przykładami w .NET i Java Spring Security
  - **Integracja bezpieczeństwa AI**: Implementacja Microsoft Prompt Shields i Azure Content Safety z szczegółowymi przykładami w Pythonie
  - **Zaawansowane łagodzenie zagrożeń**: Kompleksowe przykłady wdrożeniowe dla
    - Zapobiegania atakom confused deputy z PKCE i walidacją zgody użytkownika
    - Zapobiegania przekazywaniu tokenów z walidacją odbiorców i zarządzaniem tokenami
    - Zapobiegania przejęciu sesji z kryptograficznym wiązaniem i analizą behawioralną
  - **Integracja bezpieczeństwa przedsiębiorstwa**: Monitorowanie Azure Application Insights, wykrywanie zagrożeń i bezpieczeństwo łańcucha dostaw
  - **Lista kontrolna wdrożenia**: Jasne rozróżnienie między obowiązkowymi a zalecanymi kontrolami bezpieczeństwa z korzyściami ekosystemu bezpieczeństwa Microsoft

### Ulepszenia jakości dokumentacji i dostosowanie do standardów
- **Odwołania do specyfikacji**: Zaktualizowano wszystkie odwołania do aktualnej specyfikacji MCP z 18 czerwca 2025 r.
- **Ekosystem bezpieczeństwa Microsoft**: Ulepszona integracja w całej dokumentacji bezpieczeństwa
- **Praktyczne wdrożenie**: Dodano szczegółowe przykłady kodu w .NET, Java i Pythonie z wzorcami dla przedsiębiorstw
- **Organizacja zasobów**: Kompleksowa kategoryzacja oficjalnej dokumentacji, standardów bezpieczeństwa i przewodników wdrożeniowych
- **Wskaźniki wizualne**: Wyraźne oznaczenie wymagań obowiązkowych vs. zalecanych praktyk

#### Podstawowe koncepcje (01-CoreConcepts/) - Kompleksowa modernizacja
- **Aktualizacja wersji protokołu**: Zaktualizowano odniesienia do aktualnej specyfikacji MCP z 18 czerwca 2025 r. z wersjonowaniem opartym na dacie (format YYYY-MM-DD)
- **Udoskonalenie architektury**: Ulepszone opisy Hostów, Klientów i Serwerów, aby odzwierciedlały aktualne wzorce architektury MCP
  - Hosty teraz jasno zdefiniowane jako aplikacje AI koordynujące wiele połączeń klientów MCP
  - Klienci opisani jako konektory protokołu utrzymujące relacje jeden-do-jednego z serwerami
  - Serwery ulepszone o scenariusze lokalne vs. zdalne wdrożenie
- **Restrukturyzacja prymitywów**: Kompleksowa przebudowa prymitywów serwera i klienta
  - Prymitywy serwera: Zasoby (źródła danych), Prompty (szablony), Narzędzia (funkcje wykonywalne) z szczegółowymi wyjaśnieniami i przykładami
  - Prymitywy klienta: Sampling (kompletacje LLM), Elicitation (wejście użytkownika), Logging (debugowanie/monitorowanie)
  - Zaktualizowano o aktualne wzorce metod odkrywania (`*/list`), pobierania (`*/get`) i wykonywania (`*/call`)
- **Architektura protokołu**: Wprowadzono model architektury dwuwarstwowej
  - Warstwa danych: Podstawa JSON-RPC 2.0 z zarządzaniem cyklem życia i prymitywami
  - Warstwa transportowa: STDIO (lokalna) i Streamable HTTP z SSE (zdalna) mechanizmy transportowe
- **Ramka bezpieczeństwa**: Kompleksowe zasady bezpieczeństwa, w tym wyraźna zgoda użytkownika, ochrona prywatności danych, bezpieczeństwo wykonywania narzędzi i bezpieczeństwo warstwy transportowej
- **Wzorce komunikacji**: Zaktualizowano wiadomości protokołu, aby pokazać inicjalizację, odkrywanie, wykonywanie i przepływy powiadomień
- **Przykłady kodu**: Odświeżone przykłady w wielu językach (.NET, Java, Python, JavaScript), aby odzwierciedlały aktualne wzorce SDK MCP

#### Bezpieczeństwo (02-Security/) - Kompleksowa przebudowa bezpieczeństwa  
- **Dostosowanie do standardów**: Pełne dostosowanie do wymagań bezpieczeństwa specyfikacji MCP z 18 czerwca 2025 r.
- **Ewolucja uwierzytelniania**: Udokumentowano ewolucję od niestandardowych serwerów OAuth do delegacji zewnętrznego dostawcy tożsamości (Microsoft Entra ID)
- **Analiza zagrożeń specyficznych dla AI**: Ulepszone pokrycie nowoczesnych wektorów ataków AI
  - Szczegółowe scenariusze ataków wstrzykiwania promptów z przykładami z rzeczywistego świata
  - Mechanizmy zatruwania narzędzi i wzorce ataków "rug pull"
  - Zatruwanie okna kontekstu i ataki na dezorientację modelu
- **Rozwiązania Microsoft AI Security**: Kompleksowe pokrycie ekosystemu bezpieczeństwa Microsoft
  - AI Prompt Shields z zaawansowanym wykrywaniem, spotlightingiem i technikami delimitacji
  - Wzorce integracji Azure Content Safety
  - GitHub Advanced Security dla ochrony łańcucha dostaw
- **Zaawansowane łagodzenie zagrożeń**: Szczegółowe kontrole bezpieczeństwa dla
  - Przejęcia sesji z scenariuszami ataków specyficznych dla MCP i wymaganiami kryptograficznymi dla identyfikatorów sesji
  - Problemów confused deputy w scenariuszach proxy MCP z wyraźnymi wymaganiami zgody
  - Wrażliwości przekazywania tokenów z obowiązkowymi kontrolami walidacji
- **Bezpieczeństwo łańcucha dostaw**: Rozszerzone pokrycie łańcucha dostaw AI, w tym modele podstawowe, usługi osadzania, dostawcy kontekstu i zewnętrzne API
- **Podstawowe bezpieczeństwo**: Ulepszona integracja z wzorcami bezpieczeństwa przedsiębiorstwa, w tym architekturą zero trust i ekosystemem bezpieczeństwa Microsoft
- **Organizacja zasobów**: Skategoryzowane kompleksowe linki do zasobów według typu (Oficjalne dokumenty, Standardy, Badania, Rozwiązania Microsoft, Przewodniki wdrożeniowe)

### Ulepszenia jakości dokumentacji
- **Struktura celów nauczania**: Ulepszone cele nauczania z konkretnymi, możliwymi do realizacji wynikami
- **Odnośniki krzyżowe**: Dodano linki między powiązanymi tematami bezpieczeństwa i podstawowych koncepcji
- **Aktualne informacje**: Zaktualizowano wszystkie odniesienia do dat i linki do specyfikacji zgodnie z aktualnymi standardami
- **Wskazówki wdrożeniowe**: Dodano konkretne, możliwe do realizacji wskazówki wdrożeniowe w całej dokumentacji

## 16 lipca 2025

### Ulepszenia README i nawigacji
- Całkowicie przeprojektowano nawigację w README.md
- Zastąpiono tagi `<details>` bardziej dostępnym formatem opartym na tabelach
- Utworzono alternatywne opcje układu w nowym folderze "alternative_layouts"
- Dodano przykłady nawigacji w stylu kart, zakładek i akordeonu
- Zaktualizowano sekcję struktury repozytor

---

**Zastrzeżenie**:  
Ten dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy wszelkich starań, aby tłumaczenie było precyzyjne, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w jego rodzimym języku powinien być uznawany za wiarygodne źródło. W przypadku informacji o kluczowym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.