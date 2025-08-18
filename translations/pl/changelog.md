<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T12:08:51+00:00",
  "source_file": "changelog.md",
  "language_code": "pl"
}
-->
# Dziennik zmian: Program nauczania MCP dla początkujących

Ten dokument stanowi zapis wszystkich istotnych zmian wprowadzonych w programie nauczania Model Context Protocol (MCP) dla początkujących. Zmiany są dokumentowane w odwrotnej kolejności chronologicznej (najnowsze zmiany na początku).

## 18 sierpnia 2025

### Kompleksowa aktualizacja dokumentacji - Standardy MCP 2025-06-18

#### Najlepsze praktyki bezpieczeństwa MCP (02-Security/) - Pełna modernizacja
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Całkowite przepisanie zgodne ze specyfikacją MCP 2025-06-18
  - **Wymagania obowiązkowe**: Dodano wyraźne wymagania MUST/MUST NOT z oficjalnej specyfikacji z czytelnymi wskaźnikami wizualnymi
  - **12 kluczowych praktyk bezpieczeństwa**: Przekształcono z listy 15 punktów na kompleksowe domeny bezpieczeństwa
    - Bezpieczeństwo tokenów i uwierzytelnianie z integracją zewnętrznego dostawcy tożsamości
    - Zarządzanie sesjami i bezpieczeństwo transportu z wymaganiami kryptograficznymi
    - Ochrona przed zagrożeniami specyficznymi dla AI z integracją Microsoft Prompt Shields
    - Kontrola dostępu i uprawnień zgodnie z zasadą najmniejszych uprawnień
    - Bezpieczeństwo treści i monitorowanie z integracją Azure Content Safety
    - Bezpieczeństwo łańcucha dostaw z kompleksową weryfikacją komponentów
    - Bezpieczeństwo OAuth i zapobieganie atakom typu Confused Deputy z implementacją PKCE
    - Reagowanie na incydenty i odzyskiwanie z automatycznymi funkcjami
    - Zgodność i zarządzanie zgodne z regulacjami
    - Zaawansowane mechanizmy bezpieczeństwa z architekturą zero trust
    - Integracja z ekosystemem bezpieczeństwa Microsoft z kompleksowymi rozwiązaniami
    - Ciągła ewolucja bezpieczeństwa z adaptacyjnymi praktykami
  - **Rozwiązania bezpieczeństwa Microsoft**: Ulepszono wskazówki dotyczące integracji dla Prompt Shields, Azure Content Safety, Entra ID i GitHub Advanced Security
  - **Zasoby wdrożeniowe**: Skategoryzowano kompleksowe linki do zasobów według oficjalnej dokumentacji MCP, rozwiązań bezpieczeństwa Microsoft, standardów bezpieczeństwa i przewodników wdrożeniowych

#### Zaawansowane mechanizmy bezpieczeństwa (02-Security/) - Wdrożenie na poziomie przedsiębiorstwa
- **MCP-SECURITY-CONTROLS-2025.md**: Całkowita przebudowa z ramami bezpieczeństwa klasy korporacyjnej
  - **9 kompleksowych domen bezpieczeństwa**: Rozszerzono z podstawowych mechanizmów do szczegółowych ram korporacyjnych
    - Zaawansowane uwierzytelnianie i autoryzacja z integracją Microsoft Entra ID
    - Bezpieczeństwo tokenów i mechanizmy zapobiegające przekazywaniu z kompleksową walidacją
    - Mechanizmy bezpieczeństwa sesji z zapobieganiem przechwytywaniu
    - Mechanizmy bezpieczeństwa specyficzne dla AI z zapobieganiem wstrzykiwaniu promptów i zatruwaniu narzędzi
    - Zapobieganie atakom typu Confused Deputy z zabezpieczeniem proxy OAuth
    - Bezpieczeństwo wykonywania narzędzi z izolacją i sandboxingiem
    - Mechanizmy bezpieczeństwa łańcucha dostaw z weryfikacją zależności
    - Mechanizmy monitorowania i wykrywania z integracją SIEM
    - Reagowanie na incydenty i odzyskiwanie z automatycznymi funkcjami
  - **Przykłady wdrożenia**: Dodano szczegółowe bloki konfiguracji YAML i przykłady kodu
  - **Integracja rozwiązań Microsoft**: Kompleksowe omówienie usług bezpieczeństwa Azure, GitHub Advanced Security i zarządzania tożsamością w przedsiębiorstwie

#### Zaawansowane tematy bezpieczeństwa (05-AdvancedTopics/mcp-security/) - Wdrożenie gotowe do produkcji
- **README.md**: Całkowite przepisanie dla wdrożenia bezpieczeństwa na poziomie przedsiębiorstwa
  - **Zgodność z aktualną specyfikacją**: Zaktualizowano do specyfikacji MCP 2025-06-18 z obowiązkowymi wymaganiami bezpieczeństwa
  - **Ulepszone uwierzytelnianie**: Integracja Microsoft Entra ID z kompleksowymi przykładami w .NET i Java Spring Security
  - **Integracja bezpieczeństwa AI**: Implementacja Microsoft Prompt Shields i Azure Content Safety z szczegółowymi przykładami w Pythonie
  - **Zaawansowane łagodzenie zagrożeń**: Kompleksowe przykłady wdrożenia dla
    - Zapobiegania atakom typu Confused Deputy z PKCE i walidacją zgody użytkownika
    - Zapobiegania przekazywaniu tokenów z walidacją odbiorców i bezpiecznym zarządzaniem tokenami
    - Zapobiegania przechwytywaniu sesji z kryptograficznym powiązaniem i analizą behawioralną
  - **Integracja bezpieczeństwa w przedsiębiorstwie**: Monitorowanie Azure Application Insights, wykrywanie zagrożeń i bezpieczeństwo łańcucha dostaw
  - **Lista kontrolna wdrożenia**: Wyraźne rozróżnienie między obowiązkowymi a zalecanymi mechanizmami bezpieczeństwa z korzyściami ekosystemu bezpieczeństwa Microsoft

### Jakość dokumentacji i zgodność ze standardami
- **Odwołania do specyfikacji**: Zaktualizowano wszystkie odniesienia do aktualnej specyfikacji MCP 2025-06-18
- **Ekosystem bezpieczeństwa Microsoft**: Ulepszono wskazówki dotyczące integracji w całej dokumentacji bezpieczeństwa
- **Praktyczne wdrożenie**: Dodano szczegółowe przykłady kodu w .NET, Java i Python z wzorcami korporacyjnymi
- **Organizacja zasobów**: Kompleksowa kategoryzacja oficjalnej dokumentacji, standardów bezpieczeństwa i przewodników wdrożeniowych
- **Wskaźniki wizualne**: Wyraźne oznaczenie wymagań obowiązkowych w porównaniu do zalecanych praktyk

#### Podstawowe pojęcia (01-CoreConcepts/) - Pełna modernizacja
- **Aktualizacja wersji protokołu**: Zaktualizowano odniesienia do aktualnej specyfikacji MCP 2025-06-18 z wersjonowaniem opartym na dacie (format YYYY-MM-DD)
- **Udoskonalenie architektury**: Ulepszone opisy Hostów, Klientów i Serwerów, aby odzwierciedlały aktualne wzorce architektury MCP
  - Hosty teraz jasno zdefiniowane jako aplikacje AI koordynujące wiele połączeń klientów MCP
  - Klienci opisani jako łączniki protokołu utrzymujące relacje jeden do jednego z serwerami
  - Serwery ulepszone o scenariusze wdrożenia lokalnego i zdalnego
- **Przebudowa prymitywów**: Całkowita przebudowa prymitywów serwera i klienta
  - Prymitywy serwera: Zasoby (źródła danych), Prompty (szablony), Narzędzia (funkcje wykonywalne) z szczegółowymi wyjaśnieniami i przykładami
  - Prymitywy klienta: Próbkowanie (uzupełnienia LLM), Elicytacja (wejście użytkownika), Logowanie (debugowanie/monitorowanie)
  - Zaktualizowano o aktualne wzorce odkrywania (`*/list`), pobierania (`*/get`) i wykonywania (`*/call`)
- **Architektura protokołu**: Wprowadzono model architektury dwuwarstwowej
  - Warstwa danych: Podstawa JSON-RPC 2.0 z zarządzaniem cyklem życia i prymitywami
  - Warstwa transportowa: STDIO (lokalna) i Streamable HTTP z SSE (zdalna) mechanizmy transportowe
- **Ramowe zasady bezpieczeństwa**: Kompleksowe zasady bezpieczeństwa, w tym wyraźna zgoda użytkownika, ochrona prywatności danych, bezpieczeństwo wykonywania narzędzi i bezpieczeństwo warstwy transportowej
- **Wzorce komunikacji**: Zaktualizowano wiadomości protokołu, aby pokazać przepływy inicjalizacji, odkrywania, wykonywania i powiadomień
- **Przykłady kodu**: Odświeżono przykłady w wielu językach (.NET, Java, Python, JavaScript), aby odzwierciedlały aktualne wzorce SDK MCP

#### Bezpieczeństwo (02-Security/) - Kompleksowa przebudowa bezpieczeństwa  
- **Zgodność ze standardami**: Pełna zgodność z wymaganiami bezpieczeństwa specyfikacji MCP 2025-06-18
- **Ewolucja uwierzytelniania**: Udokumentowano przejście od niestandardowych serwerów OAuth do delegacji zewnętrznego dostawcy tożsamości (Microsoft Entra ID)
- **Analiza zagrożeń specyficznych dla AI**: Ulepszono omówienie nowoczesnych wektorów ataków AI
  - Szczegółowe scenariusze ataków typu prompt injection z przykładami z rzeczywistego świata
  - Mechanizmy zatruwania narzędzi i wzorce ataków typu "rug pull"
  - Zatruwanie okna kontekstowego i ataki na dezorientację modelu
- **Rozwiązania bezpieczeństwa AI Microsoft**: Kompleksowe omówienie ekosystemu bezpieczeństwa Microsoft
  - AI Prompt Shields z zaawansowanym wykrywaniem, spotlightingiem i technikami delimitacji
  - Wzorce integracji Azure Content Safety
  - GitHub Advanced Security dla ochrony łańcucha dostaw
- **Zaawansowane łagodzenie zagrożeń**: Szczegółowe mechanizmy bezpieczeństwa dla
  - Przechwytywania sesji z scenariuszami ataków specyficznych dla MCP i wymaganiami kryptograficznymi dla identyfikatorów sesji
  - Problemów typu Confused Deputy w scenariuszach proxy MCP z wyraźnymi wymaganiami zgody
  - Wrażliwości na przekazywanie tokenów z obowiązkowymi mechanizmami walidacji
- **Bezpieczeństwo łańcucha dostaw**: Rozszerzone omówienie łańcucha dostaw AI, w tym modeli bazowych, usług osadzania, dostawców kontekstu i zewnętrznych API
- **Podstawy bezpieczeństwa**: Ulepszona integracja z wzorcami bezpieczeństwa korporacyjnego, w tym architekturą zero trust i ekosystemem bezpieczeństwa Microsoft
- **Organizacja zasobów**: Skategoryzowano kompleksowe linki do zasobów według typu (Oficjalna dokumentacja, Standardy, Badania, Rozwiązania Microsoft, Przewodniki wdrożeniowe)

### Ulepszenia jakości dokumentacji
- **Strukturalne cele nauczania**: Ulepszone cele nauczania z konkretnymi, wykonalnymi wynikami
- **Odnośniki krzyżowe**: Dodano linki między powiązanymi tematami bezpieczeństwa i podstawowych pojęć
- **Aktualne informacje**: Zaktualizowano wszystkie odniesienia do dat i linki do specyfikacji zgodnie z aktualnymi standardami
- **Wskazówki wdrożeniowe**: Dodano konkretne, wykonalne wskazówki wdrożeniowe w całej dokumentacji

## 16 lipca 2025

### Ulepszenia README i nawigacji
- Całkowicie przeprojektowano nawigację w README.md
- Zastąpiono tagi `<details>` bardziej dostępnym formatem tabelarycznym
- Utworzono alternatywne opcje układu w nowym folderze "alternative_layouts"
- Dodano przykłady nawigacji w stylu kart, zakładek i akordeonu
- Zaktualizowano sekcję struktury repozytorium, aby uwzględnić wszystkie najnowsze pliki
- Ulepszono sekcję "Jak korzystać z tego programu nauczania" z jasnymi rekomendacjami
- Zaktualizowano linki do specyfikacji MCP, aby wskazywały poprawne adresy URL
- Dodano sekcję Inżynieria kontekstowa (5.14) do struktury programu nauczania

### Aktualizacje przewodnika do nauki
- Całkowicie zrewidowano przewodnik do nauki, aby był zgodny z aktualną strukturą repozytorium
- Dodano nowe sekcje dotyczące klientów MCP i narzędzi oraz popularnych serwerów MCP
- Zaktualizowano wizualną mapę programu nauczania, aby dokładnie odzwierciedlała wszystkie tematy
- Ulepszono opisy zaawansowanych tematów, aby objąć wszystkie specjalistyczne obszary
- Zaktualizowano sekcję studiów przypadków, aby odzwierciedlała rzeczywiste przykłady
- Dodano ten kompleksowy dziennik zmian

### Wkłady społeczności (06-CommunityContributions/)
- Dodano szczegółowe informacje o serwerach MCP do generowania obrazów
- Dodano kompleksową sekcję dotyczącą korzystania z Claude w VSCode
- Dodano instrukcje konfiguracji i użytkowania klienta terminalowego Cline
- Zaktualizowano sekcję klientów MCP, aby uwzględnić wszystkie popularne opcje klientów
- Ulepszono przykłady wkładów z dokładniejszymi przykładami kodu

### Zaawansowane tematy (05-AdvancedTopics/)
- Zorganizowano wszystkie foldery specjalistycznych tematów z jednolitą nazwą
- Dodano materiały i przykłady dotyczące inżynierii kontekstowej
- Dodano dokumentację integracji agenta Foundry
- Ulepszono dokumentację integracji bezpieczeństwa Entra ID

## 11 czerwca 2025

### Pierwsze utworzenie
- Wydano pierwszą wersję programu nauczania MCP dla początkujących
- Utworzono podstawową strukturę dla wszystkich 10 głównych sekcji
- Wdrożono wizualną mapę programu nauczania dla nawigacji
- Dodano początkowe projekty przykładowe w wielu językach programowania

### Pierwsze kroki (03-GettingStarted/)
- Utworzono pierwsze przykłady implementacji serwera
- Dodano wskazówki dotyczące rozwoju klientów
- Uwzględniono instrukcje integracji klientów LLM
- Dodano dokumentację integracji z VS Code
- Wdrożono przykłady serwera Server-Sent Events (SSE)

### Podstawowe pojęcia (01-CoreConcepts/)
- Dodano szczegółowe wyjaśnienie architektury klient-serwer
- Utworzono dokumentację kluczowych komponentów protokołu
- Udokumentowano wzorce komunikacji w MCP

## 23 maja 2025

### Struktura repozytorium
- Zainicjowano repozytorium z podstawową strukturą folderów
- Utworzono pliki README dla każdej głównej sekcji
- Skonfigurowano infrastrukturę tłumaczeń
- Dodano zasoby graficzne i diagramy

### Dokumentacja
- Utworzono początkowy README.md z przeglądem programu nauczania
- Dodano CODE_OF_CONDUCT.md i SECURITY.md
- Skonfigurowano SUPPORT.md z wytycznymi dotyczącymi uzyskiwania pomocy
- Utworzono wstępną strukturę przewodnika do nauki

## 15 kwietnia 2025

### Planowanie i ramy
- Wstępne planowanie programu nauczania MCP dla początkujących
- Zdefiniowano cele nauczania i grupę docelową
- Nakreślono 10-sekcyjną strukturę programu nauczania
- Opracowano ramy koncepcyjne dla przykładów i studiów przypadków
- Utworzono początkowe prototypy przykładów dla kluczowych pojęć

**Zastrzeżenie**:  
Ten dokument został przetłumaczony za pomocą usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy wszelkich starań, aby tłumaczenie było precyzyjne, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w jego rodzimym języku powinien być uznawany za wiarygodne źródło. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.