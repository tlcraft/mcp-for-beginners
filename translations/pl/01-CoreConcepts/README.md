<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T15:13:32+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "pl"
}
-->
# 📖 Podstawowe Koncepcje MCP: Opanowanie Model Context Protocol dla Integracji AI

Model Context Protocol (MCP) to potężny, ustandaryzowany framework, który optymalizuje komunikację między dużymi modelami językowymi (LLM) a zewnętrznymi narzędziami, aplikacjami i źródłami danych. Ten przewodnik zoptymalizowany pod kątem SEO przeprowadzi Cię przez kluczowe koncepcje MCP, zapewniając zrozumienie jego architektury klient-serwer, istotnych komponentów, mechanizmów komunikacji oraz najlepszych praktyk wdrożeniowych.

## Przegląd

Ta lekcja omawia podstawową architekturę i komponenty tworzące ekosystem Model Context Protocol (MCP). Poznasz architekturę klient-serwer, kluczowe elementy oraz mechanizmy komunikacji napędzające interakcje MCP.

## 👩‍🎓 Główne cele nauki

Po zakończeniu tej lekcji będziesz potrafił:

- Zrozumieć architekturę klient-serwer MCP.
- Rozpoznać role i obowiązki Hostów, Klientów i Serwerów.
- Analizować kluczowe cechy, które czynią MCP elastyczną warstwą integracyjną.
- Poznać przepływ informacji w ekosystemie MCP.
- Zdobyć praktyczne wskazówki na podstawie przykładów kodu w .NET, Javie, Pythonie i JavaScript.

## 🔎 Architektura MCP: Szczegółowe spojrzenie

Ekosystem MCP opiera się na modelu klient-serwer. Ta modułowa struktura pozwala aplikacjom AI efektywnie współdziałać z narzędziami, bazami danych, API i zasobami kontekstowymi. Rozbijmy tę architekturę na jej podstawowe komponenty.

### 1. Hosty

W Model Context Protocol (MCP) Hosty pełnią kluczową rolę jako główny interfejs, przez który użytkownicy wchodzą w interakcję z protokołem. Hosty to aplikacje lub środowiska inicjujące połączenia z serwerami MCP w celu dostępu do danych, narzędzi i promptów. Przykładami Hostów są zintegrowane środowiska programistyczne (IDE) takie jak Visual Studio Code, narzędzia AI jak Claude Desktop lub własne agenty stworzone do konkretnych zadań.

**Hosty** to aplikacje LLM, które inicjują połączenia. One:

- Wykonują lub współdziałają z modelami AI w celu generowania odpowiedzi.
- Nawiązują połączenia z serwerami MCP.
- Zarządzają przebiegiem rozmowy i interfejsem użytkownika.
- Kontrolują uprawnienia i ograniczenia bezpieczeństwa.
- Obsługują zgodę użytkownika na udostępnianie danych i wykonywanie narzędzi.

### 2. Klienci

Klienci to kluczowe komponenty ułatwiające interakcję między Hostami a serwerami MCP. Klienci działają jako pośrednicy, umożliwiając Hostom dostęp i korzystanie z funkcjonalności oferowanych przez serwery MCP. Pełnią ważną rolę w zapewnieniu płynnej komunikacji i efektywnej wymiany danych w architekturze MCP.

**Klienci** to konektory w aplikacji hosta. Oni:

- Wysyłają żądania do serwerów z promptami/instrukcjami.
- Negocjują możliwości z serwerami.
- Zarządzają żądaniami wykonania narzędzi od modeli.
- Przetwarzają i wyświetlają odpowiedzi użytkownikom.

### 3. Serwery

Serwery odpowiadają za obsługę żądań od klientów MCP i dostarczanie odpowiednich odpowiedzi. Zarządzają różnymi operacjami, takimi jak pobieranie danych, wykonywanie narzędzi i generowanie promptów. Serwery zapewniają, że komunikacja między klientami a Hostami jest efektywna i niezawodna, utrzymując integralność procesu interakcji.

**Serwery** to usługi dostarczające kontekst i funkcjonalności. One:

- Rejestrują dostępne funkcje (zasoby, prompt, narzędzia)
- Odbierają i wykonują wywołania narzędzi od klienta
- Dostarczają informacje kontekstowe wzbogacające odpowiedzi modelu
- Zwracają wyniki z powrotem do klienta
- Utrzymują stan podczas interakcji, gdy jest to potrzebne

Serwery mogą być tworzone przez każdego, kto chce rozszerzyć możliwości modelu o specjalistyczne funkcje.

### 4. Funkcje Serwera

Serwery w Model Context Protocol (MCP) oferują podstawowe elementy umożliwiające bogate interakcje między klientami, hostami i modelami językowymi. Funkcje te mają na celu zwiększenie możliwości MCP poprzez dostarczanie ustrukturyzowanego kontekstu, narzędzi i promptów.

Serwery MCP mogą oferować następujące funkcje:

#### 📑 Zasoby

Zasoby w Model Context Protocol (MCP) obejmują różne typy kontekstu i danych, które mogą być wykorzystywane przez użytkowników lub modele AI. Należą do nich:

- **Dane kontekstowe**: Informacje i kontekst, z których użytkownicy lub modele AI mogą korzystać podczas podejmowania decyzji i realizacji zadań.
- **Bazy wiedzy i repozytoria dokumentów**: Zbiory danych strukturalnych i niestrukturalnych, takie jak artykuły, podręczniki czy prace naukowe, dostarczające cennych informacji.
- **Lokalne pliki i bazy danych**: Dane przechowywane lokalnie na urządzeniach lub w bazach danych, dostępne do przetwarzania i analizy.
- **API i usługi sieciowe**: Zewnętrzne interfejsy i usługi oferujące dodatkowe dane i funkcjonalności, umożliwiające integrację z różnymi zasobami i narzędziami online.

Przykładem zasobu może być schemat bazy danych lub plik, do którego można uzyskać dostęp w następujący sposób:

```text
file://log.txt
database://schema
```

### 🤖 Prompt

Prompt w Model Context Protocol (MCP) obejmuje różne zdefiniowane wcześniej szablony i wzorce interakcji, zaprojektowane w celu usprawnienia pracy użytkownika i poprawy komunikacji. Należą do nich:

- **Szablony wiadomości i przepływów pracy**: Wstępnie ustrukturyzowane wiadomości i procesy prowadzące użytkowników przez konkretne zadania i interakcje.
- **Zdefiniowane wzorce interakcji**: Standardowe sekwencje działań i odpowiedzi ułatwiające spójną i efektywną komunikację.
- **Specjalistyczne szablony konwersacji**: Dostosowane szablony przeznaczone do określonych typów rozmów, zapewniające odpowiednie i kontekstowo właściwe interakcje.

Szablon promptu może wyglądać tak:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Narzędzia

Narzędzia w Model Context Protocol (MCP) to funkcje, które model AI może wykonać, aby zrealizować określone zadania. Narzędzia te mają na celu zwiększenie możliwości modelu AI poprzez dostarczanie ustrukturyzowanych i niezawodnych operacji. Kluczowe aspekty to:

- **Funkcje do wykonania przez model AI**: Narzędzia to funkcje, które model AI może wywołać, aby wykonać różne zadania.
- **Unikalna nazwa i opis**: Każde narzędzie ma odrębną nazwę i szczegółowy opis wyjaśniający jego cel i funkcjonalność.
- **Parametry i wyniki**: Narzędzia przyjmują określone parametry i zwracają ustrukturyzowane wyniki, zapewniając spójność i przewidywalność efektów.
- **Dyskretne funkcje**: Narzędzia realizują odrębne funkcje, takie jak wyszukiwanie w sieci, obliczenia czy zapytania do baz danych.

Przykład narzędzia może wyglądać tak:

```typescript
server.tool(
  "GetProducts"
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Funkcje Klienta

W Model Context Protocol (MCP) klienci oferują serwerom kilka kluczowych funkcji, które wzbogacają ogólną funkcjonalność i interakcję w protokole. Jedną z wyróżniających się funkcji jest Sampling.

### 👉 Sampling

- **Agentowe zachowania inicjowane przez serwer**: Klienci umożliwiają serwerom autonomiczne inicjowanie określonych działań lub zachowań, zwiększając dynamiczne możliwości systemu.
- **Rekurencyjne interakcje z LLM**: Funkcja ta pozwala na rekurencyjne interakcje z dużymi modelami językowymi (LLM), umożliwiając bardziej złożone i iteracyjne przetwarzanie zadań.
- **Żądanie dodatkowych uzupełnień modelu**: Serwery mogą żądać dodatkowych uzupełnień od modelu, zapewniając, że odpowiedzi są pełne i odpowiednio kontekstualne.

## Przepływ informacji w MCP

Model Context Protocol (MCP) definiuje ustrukturyzowany przepływ informacji między hostami, klientami, serwerami i modelami. Zrozumienie tego przepływu pomaga wyjaśnić, jak przetwarzane są żądania użytkowników oraz jak zewnętrzne narzędzia i dane są integrowane w odpowiedziach modelu.

- **Host inicjuje połączenie**  
  Aplikacja hosta (np. IDE lub interfejs czatu) nawiązuje połączenie z serwerem MCP, zwykle przez STDIO, WebSocket lub inny obsługiwany transport.

- **Negocjacja możliwości**  
  Klient (osadzony w hoście) i serwer wymieniają informacje o obsługiwanych funkcjach, narzędziach, zasobach i wersjach protokołu. Zapewnia to, że obie strony rozumieją, jakie możliwości są dostępne w sesji.

- **Żądanie użytkownika**  
  Użytkownik wchodzi w interakcję z hostem (np. wpisuje prompt lub polecenie). Host zbiera to wejście i przekazuje je do klienta do przetworzenia.

- **Wykorzystanie zasobów lub narzędzi**  
  - Klient może zażądać dodatkowego kontekstu lub zasobów od serwera (np. plików, wpisów w bazie danych czy artykułów z bazy wiedzy), aby wzbogacić rozumienie modelu.
  - Jeśli model stwierdzi, że potrzebne jest narzędzie (np. do pobrania danych, wykonania obliczenia lub wywołania API), klient wysyła do serwera żądanie wywołania narzędzia, podając nazwę narzędzia i parametry.

- **Wykonanie przez serwer**  
  Serwer otrzymuje żądanie zasobu lub narzędzia, wykonuje niezbędne operacje (np. uruchomienie funkcji, zapytanie do bazy danych, pobranie pliku) i zwraca wyniki klientowi w ustrukturyzowanym formacie.

- **Generowanie odpowiedzi**  
  Klient integruje odpowiedzi serwera (dane zasobów, wyniki narzędzi itp.) z bieżącą interakcją modelu. Model wykorzystuje te informacje do wygenerowania wyczerpującej i kontekstowo adekwatnej odpowiedzi.

- **Prezentacja wyniku**  
  Host otrzymuje ostateczny wynik od klienta i prezentuje go użytkownikowi, często zawierając zarówno tekst wygenerowany przez model, jak i wyniki z wykonanych narzędzi lub wyszukiwań w zasobach.

Ten przepływ pozwala MCP wspierać zaawansowane, interaktywne i świadome kontekstu aplikacje AI, łącząc modele z zewnętrznymi narzędziami i źródłami danych w sposób płynny.

## Szczegóły protokołu

MCP (Model Context Protocol) jest zbudowany na bazie [JSON-RPC 2.0](https://www.jsonrpc.org/), oferując ustandaryzowany, niezależny od języka format wiadomości do komunikacji między hostami, klientami i serwerami. Ta podstawa umożliwia niezawodne, ustrukturyzowane i rozszerzalne interakcje na różnych platformach i w różnych językach programowania.

### Kluczowe cechy protokołu

MCP rozszerza JSON-RPC 2.0 o dodatkowe konwencje dotyczące wywoływania narzędzi, dostępu do zasobów i zarządzania promptami. Obsługuje wiele warstw transportu (STDIO, WebSocket, SSE) oraz umożliwia bezpieczną, rozszerzalną i niezależną od języka komunikację między komponentami.

#### 🧢 Podstawowy protokół

- **Format wiadomości JSON-RPC**: Wszystkie żądania i odpowiedzi korzystają ze specyfikacji JSON-RPC 2.0, zapewniając spójną strukturę wywołań metod, parametrów, wyników i obsługi błędów.
- **Połączenia stanowe**: Sesje MCP utrzymują stan przez wiele żądań, wspierając kontynuowane rozmowy, akumulację kontekstu i zarządzanie zasobami.
- **Negocjacja możliwości**: Podczas nawiązywania połączenia klienci i serwery wymieniają informacje o obsługiwanych funkcjach, wersjach protokołu, dostępnych narzędziach i zasobach. Zapewnia to wzajemne zrozumienie i możliwość dostosowania.

#### ➕ Dodatkowe narzędzia

Poniżej znajdują się dodatkowe narzędzia i rozszerzenia protokołu, które MCP oferuje, by poprawić doświadczenie dewelopera i umożliwić zaawansowane scenariusze:

- **Opcje konfiguracyjne**: MCP pozwala na dynamiczną konfigurację parametrów sesji, takich jak uprawnienia narzędzi, dostęp do zasobów i ustawienia modelu, dostosowane do każdej interakcji.
- **Śledzenie postępu**: Operacje długotrwałe mogą raportować aktualizacje postępu, umożliwiając responsywne interfejsy użytkownika i lepsze doświadczenie podczas złożonych zadań.
- **Anulowanie żądań**: Klienci mogą anulować trwające żądania, pozwalając użytkownikom przerwać operacje, które nie są już potrzebne lub trwają zbyt długo.
- **Raportowanie błędów**: Ustandaryzowane komunikaty i kody błędów pomagają diagnozować problemy, obsługiwać awarie w sposób łagodny i dostarczać przydatne informacje zwrotne użytkownikom i deweloperom.
- **Logowanie**: Zarówno klienci, jak i serwery mogą emitować ustrukturyzowane logi do audytu, debugowania i monitorowania interakcji protokołu.

Wykorzystując te cechy protokołu, MCP zapewnia solidną, bezpieczną i elastyczną komunikację między modelami językowymi a zewnętrznymi narzędziami lub źródłami danych.

### 🔐 Aspekty bezpieczeństwa

Implementacje MCP powinny przestrzegać kilku kluczowych zasad bezpieczeństwa, aby zapewnić bezpieczne i wiarygodne interakcje:

- **Zgoda i kontrola użytkownika**: Użytkownicy muszą wyrazić wyraźną zgodę przed dostępem do danych lub wykonaniem operacji. Powinni mieć jasną kontrolę nad tym, jakie dane są udostępniane i które działania są autoryzowane, wspieraną przez intuicyjne interfejsy do przeglądu i zatwierdzania działań.

- **Prywatność danych**: Dane użytkownika powinny być udostępniane tylko za wyraźną zgodą i chronione odpowiednimi mechanizmami kontroli dostępu. Implementacje MCP muszą zapobiegać nieautoryzowanemu przesyłaniu danych i zapewniać ochronę prywatności podczas wszystkich interakcji.

- **Bezpieczeństwo narzędzi**: Przed wywołaniem jakiegokolwiek narzędzia wymagana jest wyraźna zgoda użytkownika. Użytkownicy powinni mieć jasne zrozumienie funkcji każdego narzędzia, a granice bezpieczeństwa muszą być rygorystycznie egzekwowane, by zapobiec niezamierzonemu lub niebezpiecznemu wykonaniu narzędzi.

Przestrzegając tych zasad, MCP zapewnia, że zaufanie, prywatność i bezpieczeństwo użytkowników są zachowane we wszystkich interakcjach protokołu.

## Przykłady kodu: Kluczowe komponenty

Poniżej znajdują się przykłady kodu w kilku popularnych językach programowania, ilustrujące implementację kluczowych komponentów serwera MCP oraz narzędzi.

### Przykład .NET: Tworzenie prostego serwera MCP z narzędziami

Praktyczny przykład kodu .NET pokazujący, jak zaimplementować prosty serwer MCP z własnymi narzędziami. Ten przykład demonstruje, jak definiować i rejestrować narzędzia, obsługiwać żądania oraz

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczeń AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy pamiętać, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym należy traktować jako źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.