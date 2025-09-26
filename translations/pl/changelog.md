<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T18:20:44+00:00",
  "source_file": "changelog.md",
  "language_code": "pl"
}
-->
# Dziennik zmian: Program nauczania MCP dla początkujących

Ten dokument stanowi zapis wszystkich istotnych zmian wprowadzonych w programie nauczania Model Context Protocol (MCP) dla początkujących. Zmiany są dokumentowane w odwrotnej kolejności chronologicznej (najpierw najnowsze).

## 26 września 2025

### Rozbudowa studiów przypadków - Integracja z GitHub MCP Registry

#### Studia przypadków (09-CaseStudy/) - Skupienie na rozwoju ekosystemu
- **README.md**: Znaczące rozszerzenie z kompleksowym studium przypadku GitHub MCP Registry
  - **Studium przypadku GitHub MCP Registry**: Nowe, szczegółowe studium przypadku dotyczące uruchomienia GitHub MCP Registry we wrześniu 2025 roku
    - **Analiza problemu**: Szczegółowe badanie wyzwań związanych z fragmentacją odkrywania i wdrażania serwerów MCP
    - **Architektura rozwiązania**: Centralne podejście rejestru GitHub z instalacją jednym kliknięciem w VS Code
    - **Wpływ biznesowy**: Mierzalne poprawy w procesie wdrażania deweloperów i ich produktywności
    - **Wartość strategiczna**: Skupienie na modułowym wdrażaniu agentów i interoperacyjności narzędzi
    - **Rozwój ekosystemu**: Pozycjonowanie jako platforma podstawowa dla integracji agentów
  - **Ulepszona struktura studiów przypadków**: Zaktualizowano wszystkie siedem studiów przypadków, zapewniając spójne formatowanie i szczegółowe opisy
    - Azure AI Travel Agents: Nacisk na orkiestrację wielu agentów
    - Integracja Azure DevOps: Automatyzacja przepływów pracy
    - Pobieranie dokumentacji w czasie rzeczywistym: Implementacja klienta konsoli Python
    - Interaktywny generator planów nauki: Aplikacja webowa Chainlit
    - Dokumentacja w edytorze: Integracja VS Code i GitHub Copilot
    - Zarządzanie API Azure: Wzorce integracji API dla przedsiębiorstw
    - GitHub MCP Registry: Rozwój ekosystemu i platforma społecznościowa
  - **Kompleksowe podsumowanie**: Przepisana sekcja podsumowania, podkreślająca siedem studiów przypadków obejmujących różne wymiary implementacji MCP
    - Integracja przedsiębiorstw, orkiestracja wielu agentów, produktywność deweloperów
    - Rozwój ekosystemu, kategoryzacja aplikacji edukacyjnych
    - Pogłębione wglądy w wzorce architektoniczne, strategie implementacji i najlepsze praktyki
    - Podkreślenie MCP jako dojrzałego, gotowego do produkcji protokołu

#### Aktualizacje przewodnika nauki (study_guide.md)
- **Mapa wizualna programu nauczania**: Zaktualizowano mapę myśli, aby uwzględnić GitHub MCP Registry w sekcji studiów przypadków
- **Opis studiów przypadków**: Rozszerzono z ogólnych opisów do szczegółowego podziału siedmiu kompleksowych studiów przypadków
- **Struktura repozytorium**: Zaktualizowano sekcję 10, aby odzwierciedlić kompleksowe pokrycie studiów przypadków ze szczegółami implementacji
- **Integracja dziennika zmian**: Dodano wpis z 26 września 2025 roku dokumentujący dodanie GitHub MCP Registry i ulepszenia studiów przypadków
- **Aktualizacje daty**: Zaktualizowano stopkę z datą ostatniej rewizji (26 września 2025)

### Poprawa jakości dokumentacji
- **Ulepszenie spójności**: Ustandaryzowano formatowanie i strukturę studiów przypadków we wszystkich siedmiu przykładach
- **Kompleksowe pokrycie**: Studia przypadków obejmują teraz scenariusze integracji przedsiębiorstw, produktywności deweloperów i rozwoju ekosystemu
- **Pozycjonowanie strategiczne**: Zwiększono nacisk na MCP jako platformę podstawową dla wdrażania systemów agentowych
- **Integracja zasobów**: Zaktualizowano dodatkowe zasoby, aby uwzględnić link do GitHub MCP Registry

## 15 września 2025

### Rozszerzenie zaawansowanych tematów - Niestandardowe transporty i inżynieria kontekstu

#### Niestandardowe transporty MCP (05-AdvancedTopics/mcp-transport/) - Nowy przewodnik implementacji zaawansowanej
- **README.md**: Kompletny przewodnik implementacji niestandardowych mechanizmów transportu MCP
  - **Transport Azure Event Grid**: Kompleksowa implementacja transportu opartego na zdarzeniach bezserwerowych
    - Przykłady w C#, TypeScript i Python z integracją Azure Functions
    - Wzorce architektury opartej na zdarzeniach dla skalowalnych rozwiązań MCP
    - Odbiorniki webhooków i obsługa wiadomości w trybie push
  - **Transport Azure Event Hubs**: Implementacja transportu strumieniowego o wysokiej przepustowości
    - Możliwości strumieniowania w czasie rzeczywistym dla scenariuszy o niskim opóźnieniu
    - Strategie partycjonowania i zarządzanie punktami kontrolnymi
    - Grupowanie wiadomości i optymalizacja wydajności
  - **Wzorce integracji przedsiębiorstw**: Przykłady architektoniczne gotowe do produkcji
    - Rozproszone przetwarzanie MCP w wielu funkcjach Azure
    - Hybrydowe architektury transportowe łączące różne typy transportu
    - Trwałość wiadomości, niezawodność i strategie obsługi błędów
  - **Bezpieczeństwo i monitorowanie**: Integracja Azure Key Vault i wzorce obserwowalności
    - Uwierzytelnianie za pomocą zarządzanej tożsamości i dostęp z minimalnymi uprawnieniami
    - Telemetria Application Insights i monitorowanie wydajności
    - Wyłączniki obwodów i wzorce tolerancji błędów
  - **Frameworki testowe**: Kompleksowe strategie testowania niestandardowych transportów
    - Testy jednostkowe z podwójnymi testami i frameworkami do mockowania
    - Testy integracyjne z Azure Test Containers
    - Rozważania dotyczące testów wydajnościowych i obciążeniowych

#### Inżynieria kontekstu (05-AdvancedTopics/mcp-contextengineering/) - Nowa dziedzina AI
- **README.md**: Kompleksowe badanie inżynierii kontekstu jako rozwijającej się dziedziny
  - **Podstawowe zasady**: Pełne udostępnianie kontekstu, świadomość decyzji o działaniach i zarządzanie oknem kontekstu
  - **Dostosowanie do protokołu MCP**: Jak projekt MCP rozwiązuje wyzwania inżynierii kontekstu
    - Ograniczenia okna kontekstu i strategie progresywnego ładowania
    - Określanie istotności i dynamiczne pobieranie kontekstu
    - Obsługa kontekstu wielomodalnego i kwestie bezpieczeństwa
  - **Podejścia do implementacji**: Architektury jednowątkowe vs. wieloagentowe
    - Techniki dzielenia i priorytetyzacji kontekstu
    - Progresywne ładowanie kontekstu i strategie kompresji
    - Warstwowe podejścia do kontekstu i optymalizacja pobierania
  - **Framework pomiarowy**: Nowe metryki oceny efektywności kontekstu
    - Wydajność wejściowa, jakość, wydajność i doświadczenie użytkownika
    - Eksperymentalne podejścia do optymalizacji kontekstu
    - Analiza błędów i metody poprawy

#### Aktualizacje nawigacji programu nauczania (README.md)
- **Ulepszona struktura modułów**: Zaktualizowano tabelę programu nauczania, aby uwzględnić nowe zaawansowane tematy
  - Dodano Inżynierię kontekstu (5.14) i Niestandardowe transporty (5.15)
  - Spójne formatowanie i linki nawigacyjne we wszystkich modułach
  - Zaktualizowano opisy, aby odzwierciedlały aktualny zakres treści

### Ulepszenia struktury katalogów
- **Standaryzacja nazw**: Zmieniono nazwę "mcp transport" na "mcp-transport" dla spójności z innymi folderami zaawansowanych tematów
- **Organizacja treści**: Wszystkie foldery 05-AdvancedTopics teraz mają spójny wzorzec nazewnictwa (mcp-[temat])

### Poprawa jakości dokumentacji
- **Dostosowanie do specyfikacji MCP**: Wszystkie nowe treści odwołują się do aktualnej specyfikacji MCP z 18 czerwca 2025
- **Przykłady w wielu językach**: Kompleksowe przykłady kodu w C#, TypeScript i Python
- **Skupienie na przedsiębiorstwach**: Wzorce gotowe do produkcji i integracja z chmurą Azure
- **Dokumentacja wizualna**: Diagramy Mermaid do wizualizacji architektury i przepływów

## 18 sierpnia 2025

### Kompleksowa aktualizacja dokumentacji - Standardy MCP 2025-06-18

#### Najlepsze praktyki bezpieczeństwa MCP (02-Security/) - Kompleksowa modernizacja
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kompletny przepis zgodny ze specyfikacją MCP z 2025-06-18
  - **Wymagania obowiązkowe**: Dodano wyraźne wymagania MUST/MUST NOT z oficjalnej specyfikacji z jasnymi wskaźnikami wizualnymi
  - **12 podstawowych praktyk bezpieczeństwa**: Przekształcono z listy 15 pozycji w kompleksowe domeny bezpieczeństwa
    - Bezpieczeństwo tokenów i uwierzytelnianie z integracją zewnętrznego dostawcy tożsamości
    - Zarządzanie sesjami i bezpieczeństwo transportu z wymaganiami kryptograficznymi
    - Ochrona przed zagrożeniami specyficznymi dla AI z integracją Microsoft Prompt Shields
    - Kontrola dostępu i uprawnień zgodnie z zasadą najmniejszych uprawnień
    - Bezpieczeństwo treści i monitorowanie z integracją Azure Content Safety
    - Bezpieczeństwo łańcucha dostaw z kompleksową weryfikacją komponentów
    - Bezpieczeństwo OAuth i zapobieganie atakom confused deputy z implementacją PKCE
    - Reakcja na incydenty i odzyskiwanie z automatycznymi możliwościami
    - Zgodność i zarządzanie zgodnością z regulacjami
    - Zaawansowane kontrole bezpieczeństwa z architekturą zero trust
    - Integracja ekosystemu bezpieczeństwa Microsoft z kompleksowymi rozwiązaniami
    - Ciągła ewolucja bezpieczeństwa z adaptacyjnymi praktykami
  - **Rozwiązania bezpieczeństwa Microsoft**: Ulepszone wskazówki dotyczące integracji dla Prompt Shields, Azure Content Safety, Entra ID i GitHub Advanced Security
  - **Zasoby implementacyjne**: Skategoryzowane kompleksowe linki do zasobów według oficjalnej dokumentacji MCP, rozwiązań bezpieczeństwa Microsoft, standardów bezpieczeństwa i przewodników implementacji

#### Zaawansowane kontrole bezpieczeństwa (02-Security/) - Implementacja dla przedsiębiorstw
- **MCP-SECURITY-CONTROLS-2025.md**: Kompleksowa przebudowa z ramami bezpieczeństwa na poziomie przedsiębiorstwa
  - **9 kompleksowych domen bezpieczeństwa**: Rozszerzono z podstawowych kontroli do szczegółowych ram dla przedsiębiorstw
    - Zaawansowane uwierzytelnianie i autoryzacja z integracją Microsoft Entra ID
    - Bezpieczeństwo tokenów i kontrole anty-passthrough z kompleksową walidacją
    - Kontrole bezpieczeństwa sesji z zapobieganiem przejęciom
    - Kontrole bezpieczeństwa specyficzne dla AI z zapobieganiem wstrzykiwaniu promptów i zatruwaniu narzędzi
    - Zapobieganie atakom confused deputy z bezpieczeństwem proxy OAuth
    - Bezpieczeństwo wykonywania narzędzi z izolacją i sandboxingiem
    - Kontrole bezpieczeństwa łańcucha dostaw z weryfikacją zależności
    - Monitorowanie i wykrywanie zagrożeń z integracją SIEM
    - Reakcja na incydenty i odzyskiwanie z automatycznymi możliwościami
  - **Przykłady implementacji**: Dodano szczegółowe bloki konfiguracji YAML i przykłady kodu
  - **Integracja rozwiązań Microsoft**: Kompleksowe pokrycie usług bezpieczeństwa Azure, GitHub Advanced Security i zarządzania tożsamością przedsiębiorstwa

#### Zaawansowane tematy bezpieczeństwa (05-AdvancedTopics/mcp-security/) - Implementacja gotowa do produkcji
- **README.md**: Kompleksowa przebudowa dla implementacji bezpieczeństwa na poziomie przedsiębiorstwa
  - **Dostosowanie do aktualnej specyfikacji**: Zaktualizowano zgodnie ze specyfikacją MCP z 2025-06-18 z obowiązkowymi wymaganiami bezpieczeństwa
  - **Ulepszone uwierzytelnianie**: Integracja Microsoft Entra ID z kompleksowymi przykładami w .NET i Java Spring Security
  - **Integracja bezpieczeństwa AI**: Implementacja Microsoft Prompt Shields i Azure Content Safety z szczegółowymi przykładami w Python
  - **Zaawansowane łagodzenie zagrożeń**: Kompleksowe przykłady implementacji dla
    - Zapobieganie atakom confused deputy z PKCE i walidacją zgody użytkownika
    - Zapobieganie przekazywaniu tokenów z walidacją odbiorców i zarządzaniem tokenami
    - Zapobieganie przejęciom sesji z kryptograficznym wiązaniem i analizą behawioralną
  - **Integracja bezpieczeństwa przedsiębiorstwa**: Monitorowanie Azure Application Insights, wykrywanie zagrożeń i bezpieczeństwo łańcucha dostaw
  - **Lista kontrolna implementacji**: Jasne rozróżnienie między obowiązkowymi a zalecanymi kontrolami bezpieczeństwa z korzyściami ekosystemu bezpieczeństwa Microsoft

### Poprawa jakości dokumentacji i dostosowanie do standardów
- **Odwołania do specyfikacji**: Zaktualizowano wszystkie odwołania do aktualnej specyfikacji MCP z 2025-06-18
- **Ekosystem bezpieczeństwa Microsoft**: Ulepszone wskazówki dotyczące integracji w całej dokumentacji bezpieczeństwa
- **Praktyczna implementacja**: Dodano szczegółowe przykłady kodu w .NET, Java i Python z wzorcami dla przedsiębiorstw
- **Organizacja zasobów**: Kompleksowa kategoryzacja oficjalnej dokumentacji, standardów bezpieczeństwa i przewodników implementacji
- **Wskaźniki wizualne**: Wyraźne oznaczenie wymagań obowiązkowych vs. zalecanych praktyk

#### Podstawowe koncepcje (01-CoreConcepts/) - Kompleksowa modernizacja
- **Aktualizacja wersji protokołu**: Zaktualizowano odniesienia do aktualnej specyfikacji MCP z 2025-06-18 z wersjonowaniem opartym na dacie (format YYYY-MM-DD)
- **Udoskonalenie architektury**: Ulepszone opisy Hostów, Klientów i Serwerów, aby odzwierciedlały aktualne wzorce architektury MCP
  - Hosty teraz jasno zdefiniowane jako aplikacje AI koordynujące wiele połączeń klientów MCP
  - Klienci opisani jako konektory protokołu utrzymujące relacje jeden-do-jednego z serwerami
  - Serwery ulepszone o scenariusze lokalnego vs. zdalnego wdrażania
- **Przebudowa prymitywów**: Kompleksowa przebudowa prymitywów serwera i klienta
  - Prymitywy serwera: Zasoby (źródła danych), Prompty (szablony), Narzędzia (funkcje wykonywalne) z szczegółowymi wyjaśnieniami i przykładami
  - Prymitywy klienta: Próbkowanie (kompletacje LLM), Wywoływanie (wejście użytkownika), Logowanie (debugowanie/monitorowanie)
  - Zaktualizowano o aktualne wzorce metod odkrywania (`*/list`), pobierania (`*/get`) i wykonywania (`*/call`)
- **Architektura protokołu**: Wprowadzono model architektury dwuwarstwowej
  - Warstwa danych: Podstawa JSON-RPC 2.0 z zarządzaniem cyklem życia i prymitywami
  - Warstwa transportu: STDIO (lokalny) i Streamable HTTP z SSE (zdalny) mechanizmy transportu
- **Ramka bezpieczeństwa**: Kompleksowe zasady bezpieczeństwa, w tym wyraźna zgoda użytkownika, ochrona prywatności danych, bezpieczeństwo wykony
- Zastąpiono tagi `<details>` bardziej dostępnym formatem opartym na tabelach
- Utworzono alternatywne opcje układu w nowym folderze "alternative_layouts"
- Dodano przykłady nawigacji opartej na kartach, zakładkach i akordeonie
- Zaktualizowano sekcję struktury repozytorium, uwzględniając wszystkie najnowsze pliki
- Udoskonalono sekcję "Jak korzystać z tego programu nauczania" z jasnymi rekomendacjami
- Zaktualizowano linki do specyfikacji MCP, aby wskazywały poprawne adresy URL
- Dodano sekcję Inżynieria Kontekstowa (5.14) do struktury programu nauczania

### Aktualizacje Przewodnika do Nauki
- Całkowicie zrewidowano przewodnik do nauki, aby dostosować go do obecnej struktury repozytorium
- Dodano nowe sekcje dotyczące klientów MCP i narzędzi oraz popularnych serwerów MCP
- Zaktualizowano Wizualną Mapę Programu Nauczania, aby dokładnie odzwierciedlała wszystkie tematy
- Udoskonalono opisy Zaawansowanych Tematów, obejmując wszystkie specjalistyczne obszary
- Zaktualizowano sekcję Studiów Przypadków, aby odzwierciedlała rzeczywiste przykłady
- Dodano ten kompleksowy dziennik zmian

### Wkład Społeczności (06-CommunityContributions/)
- Dodano szczegółowe informacje o serwerach MCP do generowania obrazów
- Dodano kompleksową sekcję dotyczącą korzystania z Claude w VSCode
- Dodano instrukcje konfiguracji i użytkowania klienta terminalowego Cline
- Zaktualizowano sekcję klientów MCP, uwzględniając wszystkie popularne opcje
- Udoskonalono przykłady wkładów z bardziej precyzyjnymi próbkami kodu

### Zaawansowane Tematy (05-AdvancedTopics/)
- Zorganizowano wszystkie foldery specjalistycznych tematów z jednolitą nazwą
- Dodano materiały i przykłady dotyczące inżynierii kontekstowej
- Dodano dokumentację integracji agenta Foundry
- Udoskonalono dokumentację integracji zabezpieczeń Entra ID

## 11 czerwca 2025

### Pierwsze Wydanie
- Opublikowano pierwszą wersję programu nauczania MCP dla początkujących
- Utworzono podstawową strukturę dla wszystkich 10 głównych sekcji
- Zaimplementowano Wizualną Mapę Programu Nauczania dla nawigacji
- Dodano początkowe projekty przykładowe w wielu językach programowania

### Pierwsze Kroki (03-GettingStarted/)
- Utworzono pierwsze przykłady implementacji serwera
- Dodano wskazówki dotyczące rozwoju klienta
- Uwzględniono instrukcje integracji klienta LLM
- Dodano dokumentację integracji z VS Code
- Zaimplementowano przykłady serwera Server-Sent Events (SSE)

### Podstawowe Koncepcje (01-CoreConcepts/)
- Dodano szczegółowe wyjaśnienie architektury klient-serwer
- Utworzono dokumentację kluczowych komponentów protokołu
- Udokumentowano wzorce komunikacji w MCP

## 23 maja 2025

### Struktura Repozytorium
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

### Planowanie i Ramy
- Rozpoczęto planowanie programu nauczania MCP dla początkujących
- Zdefiniowano cele edukacyjne i grupę docelową
- Nakreślono 10-sekcyjną strukturę programu nauczania
- Opracowano koncepcyjne ramy dla przykładów i studiów przypadków
- Utworzono początkowe prototypy przykładów dla kluczowych koncepcji

---

