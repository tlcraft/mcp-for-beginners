<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T13:32:28+00:00",
  "source_file": "changelog.md",
  "language_code": "pl"
}
-->
# Dziennik zmian: Program nauczania MCP dla początkujących

Ten dokument stanowi zapis wszystkich istotnych zmian wprowadzonych w programie nauczania Model Context Protocol (MCP) dla początkujących. Zmiany są dokumentowane w odwrotnej kolejności chronologicznej (najpierw najnowsze).

## 29 września 2025

### Laboratoria integracji bazy danych MCP Server - Kompleksowa ścieżka praktyczna

#### 11-MCPServerHandsOnLabs - Nowy kompletny program nauczania integracji bazy danych
- **Kompletna ścieżka nauczania z 13 laboratoriami**: Dodano kompleksowy program praktyczny dotyczący budowy serwerów MCP gotowych do produkcji z integracją bazy danych PostgreSQL
  - **Praktyczne wdrożenie**: Przykład analityki detalicznej Zava, demonstrujący wzorce klasy korporacyjnej
  - **Struktura nauki**:
    - **Laboratoria 00-03: Podstawy** - Wprowadzenie, Architektura podstawowa, Bezpieczeństwo i wielodostępność, Konfiguracja środowiska
    - **Laboratoria 04-06: Budowa serwera MCP** - Projektowanie bazy danych i schemat, Implementacja serwera MCP, Tworzenie narzędzi  
    - **Laboratoria 07-09: Zaawansowane funkcje** - Integracja wyszukiwania semantycznego, Testowanie i debugowanie, Integracja z VS Code
    - **Laboratoria 10-12: Produkcja i najlepsze praktyki** - Strategie wdrażania, Monitorowanie i obserwowalność, Optymalizacja i najlepsze praktyki
  - **Technologie korporacyjne**: Framework FastMCP, PostgreSQL z pgvector, Azure OpenAI embeddings, Azure Container Apps, Application Insights
  - **Zaawansowane funkcje**: Row Level Security (RLS), wyszukiwanie semantyczne, dostęp do danych wielodostępnych, osadzenia wektorowe, monitorowanie w czasie rzeczywistym

#### Standaryzacja terminologii - Konwersja modułów na laboratoria
- **Kompleksowa aktualizacja dokumentacji**: Systematycznie zaktualizowano wszystkie pliki README w 11-MCPServerHandsOnLabs, aby używać terminologii "Laboratorium" zamiast "Moduł"
  - **Nagłówki sekcji**: Zmieniono "Co obejmuje ten moduł" na "Co obejmuje to laboratorium" we wszystkich 13 laboratoriach
  - **Opis treści**: Zmieniono "Ten moduł dostarcza..." na "To laboratorium dostarcza..." w całej dokumentacji
  - **Cele nauki**: Zmieniono "Po ukończeniu tego modułu..." na "Po ukończeniu tego laboratorium..."
  - **Linki nawigacyjne**: Wszystkie odniesienia "Moduł XX:" zmieniono na "Laboratorium XX:" w odnośnikach i nawigacji
  - **Śledzenie postępów**: Zmieniono "Po ukończeniu tego modułu..." na "Po ukończeniu tego laboratorium..."
  - **Zachowanie odniesień technicznych**: Zachowano odniesienia do modułów Python w plikach konfiguracyjnych (np. `"module": "mcp_server.main"`)

#### Ulepszenie przewodnika nauki (study_guide.md)
- **Wizualna mapa programu nauczania**: Dodano nową sekcję "11. Laboratoria integracji bazy danych" z wizualizacją struktury laboratoriów
- **Struktura repozytorium**: Zaktualizowano z dziesięciu do jedenastu głównych sekcji z opisem 11-MCPServerHandsOnLabs
- **Wskazówki dotyczące ścieżki nauki**: Rozszerzono instrukcje nawigacyjne, aby obejmowały sekcje 00-11
- **Zakres technologiczny**: Dodano szczegóły dotyczące integracji FastMCP, PostgreSQL i usług Azure
- **Efekty nauki**: Podkreślono rozwój serwerów gotowych do produkcji, wzorce integracji bazy danych i bezpieczeństwo korporacyjne

#### Ulepszenie struktury głównego README
- **Terminologia oparta na laboratoriach**: Zaktualizowano główny README.md w 11-MCPServerHandsOnLabs, aby konsekwentnie używać struktury "Laboratorium"
- **Organizacja ścieżki nauki**: Jasna progresja od podstawowych pojęć przez zaawansowaną implementację do wdrożenia produkcyjnego
- **Skupienie na praktyce**: Nacisk na praktyczne, praktyczne uczenie się z wzorcami i technologiami klasy korporacyjnej

### Poprawa jakości i spójności dokumentacji
- **Nacisk na naukę praktyczną**: Wzmocniono praktyczne, oparte na laboratoriach podejście w całej dokumentacji
- **Skupienie na wzorcach korporacyjnych**: Podkreślono implementacje gotowe do produkcji i kwestie bezpieczeństwa korporacyjnego
- **Integracja technologii**: Kompleksowe omówienie nowoczesnych usług Azure i wzorców integracji AI
- **Progresja nauki**: Jasna, uporządkowana ścieżka od podstawowych pojęć do wdrożenia produkcyjnego

## 26 września 2025

### Rozszerzenie studiów przypadków - Integracja GitHub MCP Registry

#### Studia przypadków (09-CaseStudy/) - Skupienie na rozwoju ekosystemu
- **README.md**: Znaczące rozszerzenie o kompleksowe studium przypadku GitHub MCP Registry
  - **Studium przypadku GitHub MCP Registry**: Nowe, kompleksowe studium przypadku analizujące uruchomienie GitHub MCP Registry we wrześniu 2025
    - **Analiza problemu**: Szczegółowe omówienie wyzwań związanych z fragmentacją odkrywania i wdrażania serwerów MCP
    - **Architektura rozwiązania**: Podejście GitHub do scentralizowanego rejestru z instalacją jednym kliknięciem w VS Code
    - **Wpływ biznesowy**: Mierzalne ulepszenia w onboardingu i produktywności deweloperów
    - **Wartość strategiczna**: Skupienie na modułowym wdrażaniu agentów i interoperacyjności narzędzi
    - **Rozwój ekosystemu**: Pozycjonowanie jako platforma podstawowa dla integracji agentów
  - **Ulepszona struktura studiów przypadków**: Zaktualizowano wszystkie siedem studiów przypadków, aby miały spójny format i szczegółowe opisy
    - Azure AI Travel Agents: Nacisk na orkiestrację wieloagentową
    - Integracja z Azure DevOps: Skupienie na automatyzacji przepływów pracy
    - Pobieranie dokumentacji w czasie rzeczywistym: Implementacja klienta konsolowego w Pythonie
    - Interaktywny generator planów nauki: Aplikacja internetowa Chainlit
    - Dokumentacja w edytorze: Integracja z VS Code i GitHub Copilot
    - Zarządzanie API Azure: Wzorce integracji API klasy korporacyjnej
    - GitHub MCP Registry: Rozwój ekosystemu i platforma społecznościowa
  - **Kompleksowe zakończenie**: Przepisana sekcja podsumowująca, podkreślająca siedem studiów przypadków obejmujących różne wymiary implementacji MCP
    - Integracja korporacyjna, orkiestracja wieloagentowa, produktywność deweloperów
    - Rozwój ekosystemu, kategoryzacja zastosowań edukacyjnych
    - Rozszerzone wglądy w wzorce architektoniczne, strategie implementacji i najlepsze praktyki
    - Nacisk na MCP jako dojrzały, gotowy do produkcji protokół

#### Aktualizacje przewodnika nauki (study_guide.md)
- **Wizualna mapa programu nauczania**: Zaktualizowano mapę myśli, aby uwzględnić GitHub MCP Registry w sekcji studiów przypadków
- **Opis studiów przypadków**: Rozszerzono z ogólnych opisów na szczegółowe omówienie siedmiu kompleksowych studiów przypadków
- **Struktura repozytorium**: Zaktualizowano sekcję 10, aby odzwierciedlała kompleksowe pokrycie studiów przypadków ze szczegółami implementacji
- **Integracja dziennika zmian**: Dodano wpis z 26 września 2025 dokumentujący dodanie GitHub MCP Registry i ulepszenia studiów przypadków
- **Aktualizacje daty**: Zaktualizowano stopkę z datą ostatniej rewizji (26 września 2025)

### Poprawa jakości dokumentacji
- **Ulepszenie spójności**: Ustandaryzowano formatowanie i strukturę studiów przypadków we wszystkich siedmiu przykładach
- **Kompleksowe pokrycie**: Studia przypadków obejmują teraz scenariusze korporacyjne, produktywność deweloperów i rozwój ekosystemu
- **Pozycjonowanie strategiczne**: Wzmocniono nacisk na MCP jako podstawową platformę dla wdrażania systemów agentowych
- **Integracja zasobów**: Zaktualizowano dodatkowe zasoby, aby uwzględnić link do GitHub MCP Registry

## 15 września 2025

### Rozszerzenie zaawansowanych tematów - Niestandardowe transporty i inżynieria kontekstu

#### Niestandardowe transporty MCP (05-AdvancedTopics/mcp-transport/) - Nowy przewodnik implementacji zaawansowanej
- **README.md**: Kompletny przewodnik implementacji niestandardowych mechanizmów transportu MCP
  - **Transport Azure Event Grid**: Kompleksowa implementacja transportu bezserwerowego opartego na zdarzeniach
    - Przykłady w C#, TypeScript i Pythonie z integracją Azure Functions
    - Wzorce architektury opartej na zdarzeniach dla skalowalnych rozwiązań MCP
    - Odbiorniki webhooków i obsługa wiadomości w trybie push
  - **Transport Azure Event Hubs**: Implementacja transportu strumieniowego o wysokiej przepustowości
    - Możliwości strumieniowania w czasie rzeczywistym dla scenariuszy o niskim opóźnieniu
    - Strategie partycjonowania i zarządzanie punktami kontrolnymi
    - Grupowanie wiadomości i optymalizacja wydajności
  - **Wzorce integracji korporacyjnej**: Przykłady architektoniczne gotowe do produkcji
    - Rozproszone przetwarzanie MCP w wielu funkcjach Azure
    - Hybrydowe architektury transportowe łączące różne typy transportu
    - Trwałość wiadomości, niezawodność i strategie obsługi błędów
  - **Bezpieczeństwo i monitorowanie**: Integracja z Azure Key Vault i wzorce obserwowalności
    - Uwierzytelnianie zarządzane tożsamością i dostęp z minimalnymi uprawnieniami
    - Telemetria Application Insights i monitorowanie wydajności
    - Bezpieczniki i wzorce odporności na błędy
  - **Ramki testowe**: Kompleksowe strategie testowania niestandardowych transportów
    - Testy jednostkowe z użyciem atrap i frameworków do mockowania
    - Testy integracyjne z Azure Test Containers
    - Uwagi dotyczące testów wydajności i obciążenia

#### Inżynieria kontekstu (05-AdvancedTopics/mcp-contextengineering/) - Nowa dziedzina AI
- **README.md**: Kompleksowe omówienie inżynierii kontekstu jako nowo powstającej dziedziny
  - **Podstawowe zasady**: Pełne udostępnianie kontekstu, świadomość decyzji o działaniach i zarządzanie oknem kontekstu
  - **Zgodność z protokołem MCP**: Jak projekt MCP rozwiązuje wyzwania inżynierii kontekstu
    - Ograniczenia okna kontekstu i strategie ładowania progresywnego
    - Określanie istotności i dynamiczne pobieranie kontekstu
    - Obsługa kontekstu wielomodalnego i kwestie bezpieczeństwa
  - **Podejścia do implementacji**: Architektury jednowątkowe vs. wieloagentowe
    - Techniki dzielenia i priorytetyzacji kontekstu
    - Progresywne ładowanie i strategie kompresji kontekstu
    - Warstwowe podejścia do kontekstu i optymalizacja pobierania
  - **Ramka pomiarowa**: Nowe metryki oceny efektywności kontekstu
    - Wydajność wejściowa, wydajność, jakość i doświadczenie użytkownika
    - Eksperymentalne podejścia do optymalizacji kontekstu
    - Analiza błędów i metody poprawy

#### Aktualizacje nawigacji programu nauczania (README.md)
- **Ulepszona struktura modułów**: Zaktualizowano tabelę programu nauczania, aby uwzględnić nowe zaawansowane tematy
  - Dodano wpisy Inżynieria kontekstu (5.14) i Niestandardowe transporty (5.15)
  - Spójne formatowanie i linki nawigacyjne we wszystkich modułach
  - Zaktualizowano opisy, aby odzwierciedlały aktualny zakres treści

### Ulepszenia struktury katalogów
- **Standaryzacja nazw**: Zmieniono nazwę "mcp transport" na "mcp-transport" dla spójności z innymi folderami zaawansowanych tematów
- **Organizacja treści**: Wszystkie foldery 05-AdvancedTopics teraz stosują spójny wzorzec nazewnictwa (mcp-[temat])

### Ulepszenia jakości dokumentacji
- **Zgodność ze specyfikacją MCP**: Wszystkie nowe treści odnoszą się do aktualnej specyfikacji MCP z 18 czerwca 2025
- **Przykłady w wielu językach**: Kompleksowe przykłady kodu w C#, TypeScript i Pythonie
- **Skupienie na korporacjach**: Wzorce gotowe do produkcji i integracja z chmurą Azure w całej dokumentacji
- **Dokumentacja wizualna**: Diagramy Mermaid do wizualizacji architektury i przepływów

## 18 sierpnia 2025

### Kompleksowa aktualizacja dokumentacji - Standardy MCP 2025-06-18

#### Najlepsze praktyki bezpieczeństwa MCP (02-Security/) - Kompleksowa modernizacja
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kompletny przepis zgodny ze specyfikacją MCP z 2025-06-18
  - **Wymagania obowiązkowe**: Dodano wyraźne wymagania MUST/MUST NOT z oficjalnej specyfikacji z jasnymi wskaźnikami wizualnymi
  - **12 podstawowych praktyk bezpieczeństwa**: Przekształcono z listy 15 pozycji w kompleksowe domeny bezpieczeństwa
    - Bezpieczeństwo tokenów i uwierzytelnianie z integracją zewnętrznego dostawcy tożsamości
    - Zarządzanie sesją i bezpieczeństwo transportu z wymaganiami kryptograficznymi
    - Ochrona przed zagrożeniami specyficznymi dla AI z integracją Microsoft Prompt Shields
    - Kontrola dostępu i uprawnień zgodnie z zasadą najmniejszych uprawnień
    - Bezpieczeństwo treści i monitorowanie z integracją Azure Content Safety
    - Bezpieczeństwo łańcucha dostaw z kompleksową weryfikacją komponentów
    - Bezpieczeństwo OAuth i zapobieganie atakom Confused Deputy z implementacją PKCE
    - Reakcja na incydenty i odzyskiwanie z automatycznymi możliwościami
    - Zgodność i zarządzanie z regulacyjnym dostosowaniem
    - Zaawansowane kontrole bezpieczeństwa z architekturą zero trust
    - Integracja z ekosystemem bezpieczeństwa Microsoft z kompleksowymi rozwiązaniami
    - Ciągła ewolucja bezpieczeństwa z adaptacyjnymi praktykami
  - **Rozwiązania bezpieczeństwa Microsoft**: Ulepszone wskazówki dotyczące integracji dla Prompt Shields, Azure Content Safety, Entra ID i GitHub Advanced Security
  - **Zasoby implementacyjne**: Skategoryzowane kompleksowe linki do zasobów według Oficjalnej dokumentacji MCP, Rozwiązań bezpieczeństwa Microsoft, Standardów bezpieczeństwa i Przewodników implementacyjnych

#### Zaawansowane kontrole bezpieczeństwa (02-Security/) - Implementacja korporacyjna
- **MCP-SECURITY-CONTROLS-2025.md**: Kompleksowa przebudowa z ramami bezpieczeństwa klasy korporacyjnej
  - **9 kompleksowych domen bezpieczeństwa**: Rozszerzono z podstawowych kontroli do szczegółowych ram korporacyjnych
    - Zaawansowane uwierzytelnianie i autoryzacja z integracją Microsoft Entra ID
    - Bezpieczeństwo tokenów i kontrola anty-passthrough z kompleksową walidacją
    - Kontrole bezpieczeństwa sesji z zapobieganiem przejęci
- **Wskaźniki wizualne**: Wyraźne oznaczenie obowiązkowych wymagań i zalecanych praktyk

#### Podstawowe Koncepcje (01-CoreConcepts/) - Kompleksowa Modernizacja
- **Aktualizacja wersji protokołu**: Zaktualizowano odniesienia do bieżącej specyfikacji MCP z datą wersji (format YYYY-MM-DD), obowiązującą od 2025-06-18
- **Udoskonalenie architektury**: Rozszerzono opisy Hostów, Klientów i Serwerów, aby odzwierciedlały aktualne wzorce architektury MCP
  - Hosty są teraz jasno zdefiniowane jako aplikacje AI koordynujące wiele połączeń klientów MCP
  - Klienci opisani jako konektory protokołu utrzymujące relacje jeden-do-jednego z serwerami
  - Serwery wzbogacone o scenariusze lokalnego i zdalnego wdrożenia
- **Przebudowa prymitywów**: Kompleksowa reorganizacja prymitywów serwera i klienta
  - Prymitywy serwera: Zasoby (źródła danych), Podpowiedzi (szablony), Narzędzia (funkcje wykonywalne) z szczegółowymi wyjaśnieniami i przykładami
  - Prymitywy klienta: Próbkowanie (wyniki LLM), Wywoływanie (wejście użytkownika), Logowanie (debugowanie/monitorowanie)
  - Zaktualizowano zgodnie z bieżącymi wzorcami metod odkrywania (`*/list`), pobierania (`*/get`) i wykonywania (`*/call`)
- **Architektura protokołu**: Wprowadzono model architektury dwuwarstwowej
  - Warstwa danych: Podstawa JSON-RPC 2.0 z zarządzaniem cyklem życia i prymitywami
  - Warstwa transportowa: STDIO (lokalnie) i Streamable HTTP z SSE (zdalnie)
- **Ramka bezpieczeństwa**: Kompleksowe zasady bezpieczeństwa, w tym wyraźna zgoda użytkownika, ochrona prywatności danych, bezpieczeństwo wykonywania narzędzi i bezpieczeństwo warstwy transportowej
- **Wzorce komunikacji**: Zaktualizowano wiadomości protokołu, aby pokazać przepływy inicjalizacji, odkrywania, wykonywania i powiadomień
- **Przykłady kodu**: Odświeżono przykłady w wielu językach (.NET, Java, Python, JavaScript), aby odzwierciedlały bieżące wzorce MCP SDK

#### Bezpieczeństwo (02-Security/) - Kompleksowa przebudowa bezpieczeństwa  
- **Zgodność ze standardami**: Pełna zgodność z wymaganiami bezpieczeństwa specyfikacji MCP 2025-06-18
- **Ewolucja uwierzytelniania**: Udokumentowano przejście od niestandardowych serwerów OAuth do delegacji zewnętrznych dostawców tożsamości (Microsoft Entra ID)
- **Analiza zagrożeń specyficznych dla AI**: Rozszerzone omówienie nowoczesnych wektorów ataków na AI
  - Szczegółowe scenariusze ataków wstrzykiwania podpowiedzi z przykładami z życia
  - Mechanizmy zatruwania narzędzi i wzorce ataków typu "rug pull"
  - Zatruwanie okna kontekstowego i ataki na dezorientację modelu
- **Rozwiązania bezpieczeństwa AI Microsoft**: Kompleksowe omówienie ekosystemu bezpieczeństwa Microsoft
  - AI Prompt Shields z zaawansowanym wykrywaniem, wyróżnianiem i technikami delimitacji
  - Wzorce integracji Azure Content Safety
  - GitHub Advanced Security dla ochrony łańcucha dostaw
- **Zaawansowane ograniczanie zagrożeń**: Szczegółowe kontrole bezpieczeństwa dla
  - Przejęcia sesji z scenariuszami ataków specyficznymi dla MCP i wymaganiami kryptograficznych identyfikatorów sesji
  - Problemów "zagubionego zastępcy" w scenariuszach proxy MCP z wymaganiami wyraźnej zgody
  - Luk w przekazywaniu tokenów z obowiązkowymi kontrolami walidacji
- **Bezpieczeństwo łańcucha dostaw**: Rozszerzone omówienie łańcucha dostaw AI, w tym modele podstawowe, usługi osadzania, dostawców kontekstu i zewnętrzne API
- **Podstawy bezpieczeństwa**: Zwiększona integracja z wzorcami bezpieczeństwa przedsiębiorstwa, w tym architekturą zero trust i ekosystemem bezpieczeństwa Microsoft
- **Organizacja zasobów**: Skategoryzowane kompleksowe linki do zasobów według typu (Oficjalne dokumenty, Standardy, Badania, Rozwiązania Microsoft, Przewodniki wdrożeniowe)

### Ulepszenia jakości dokumentacji
- **Strukturalne cele nauki**: Udoskonalone cele nauki z konkretnymi, możliwymi do realizacji wynikami
- **Odnośniki krzyżowe**: Dodano linki między powiązanymi tematami bezpieczeństwa i podstawowych koncepcji
- **Aktualne informacje**: Zaktualizowano wszystkie odniesienia do dat i linki do specyfikacji zgodnie z bieżącymi standardami
- **Wskazówki wdrożeniowe**: Dodano konkretne, możliwe do realizacji wskazówki wdrożeniowe w obu sekcjach

## 16 lipca 2025

### README i ulepszenia nawigacji
- Całkowicie przeprojektowano nawigację w README.md
- Zastąpiono tagi `<details>` bardziej dostępnym formatem tabeli
- Utworzono alternatywne opcje układu w nowym folderze "alternative_layouts"
- Dodano przykłady nawigacji w stylu kart, zakładek i akordeonu
- Zaktualizowano sekcję struktury repozytorium, aby uwzględnić wszystkie najnowsze pliki
- Udoskonalono sekcję "Jak korzystać z tego programu nauczania" z jasnymi rekomendacjami
- Zaktualizowano linki do specyfikacji MCP, aby wskazywały poprawne adresy URL
- Dodano sekcję Inżynieria kontekstu (5.14) do struktury programu nauczania

### Aktualizacje przewodnika nauki
- Całkowicie zrewidowano przewodnik nauki, aby dostosować go do bieżącej struktury repozytorium
- Dodano nowe sekcje dotyczące klientów MCP i narzędzi oraz popularnych serwerów MCP
- Zaktualizowano wizualną mapę programu nauczania, aby dokładnie odzwierciedlała wszystkie tematy
- Udoskonalono opisy zaawansowanych tematów, aby objąć wszystkie specjalistyczne obszary
- Zaktualizowano sekcję studiów przypadków, aby odzwierciedlała rzeczywiste przykłady
- Dodano ten kompleksowy dziennik zmian

### Wkład społeczności (06-CommunityContributions/)
- Dodano szczegółowe informacje o serwerach MCP do generowania obrazów
- Dodano kompleksową sekcję dotyczącą korzystania z Claude w VSCode
- Dodano instrukcje konfiguracji i użytkowania klienta terminalowego Cline
- Zaktualizowano sekcję klientów MCP, aby uwzględnić wszystkie popularne opcje klientów
- Udoskonalono przykłady wkładów z bardziej precyzyjnymi próbkami kodu

### Zaawansowane tematy (05-AdvancedTopics/)
- Zorganizowano wszystkie foldery specjalistycznych tematów z jednolitą nazwą
- Dodano materiały i przykłady dotyczące inżynierii kontekstu
- Dodano dokumentację integracji agenta Foundry
- Udoskonalono dokumentację integracji bezpieczeństwa Entra ID

## 11 czerwca 2025

### Pierwsze utworzenie
- Wydano pierwszą wersję programu nauczania MCP dla początkujących
- Utworzono podstawową strukturę dla wszystkich 10 głównych sekcji
- Wdrożono wizualną mapę programu nauczania dla nawigacji
- Dodano początkowe projekty przykładowe w wielu językach programowania

### Pierwsze kroki (03-GettingStarted/)
- Utworzono pierwsze przykłady implementacji serwera
- Dodano wskazówki dotyczące rozwoju klienta
- Uwzględniono instrukcje integracji klienta LLM
- Dodano dokumentację integracji z VS Code
- Wdrożono przykłady serwera z Server-Sent Events (SSE)

### Podstawowe koncepcje (01-CoreConcepts/)
- Dodano szczegółowe wyjaśnienie architektury klient-serwer
- Utworzono dokumentację kluczowych komponentów protokołu
- Udokumentowano wzorce wiadomości w MCP

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
- Utworzono wstępną strukturę przewodnika nauki

## 15 kwietnia 2025

### Planowanie i ramy
- Wstępne planowanie programu nauczania MCP dla początkujących
- Zdefiniowano cele nauki i grupę docelową
- Nakreślono 10-sekcyjną strukturę programu nauczania
- Opracowano koncepcyjne ramy dla przykładów i studiów przypadków
- Utworzono początkowe prototypy przykładów dla kluczowych koncepcji

---

**Zastrzeżenie**:  
Ten dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż staramy się zapewnić dokładność, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w jego języku źródłowym powinien być uznawany za autorytatywne źródło. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.