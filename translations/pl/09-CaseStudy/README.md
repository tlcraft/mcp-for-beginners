<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-07-29T01:32:53+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "pl"
}
-->
# MCP w Praktyce: Studia Przypadków z Rzeczywistego Świata

[![MCP w Praktyce: Studia Przypadków z Rzeczywistego Świata](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.pl.png)](https://youtu.be/IxshWb2Az5w)

_(Kliknij obrazek powyżej, aby obejrzeć wideo z tej lekcji)_

Model Context Protocol (MCP) zmienia sposób, w jaki aplikacje AI współpracują z danymi, narzędziami i usługami. W tej sekcji przedstawiamy studia przypadków z rzeczywistego świata, które pokazują praktyczne zastosowania MCP w różnych scenariuszach biznesowych.

## Przegląd

Ta sekcja prezentuje konkretne przykłady wdrożeń MCP, podkreślając, jak organizacje wykorzystują ten protokół do rozwiązywania złożonych wyzwań biznesowych. Analizując te studia przypadków, zdobędziesz wiedzę na temat wszechstronności, skalowalności i praktycznych korzyści płynących z MCP w rzeczywistych zastosowaniach.

## Kluczowe Cele Nauki

Analizując te studia przypadków, dowiesz się:

- Jak MCP może być stosowany do rozwiązywania konkretnych problemów biznesowych
- Jakie są różne wzorce integracji i podejścia architektoniczne
- Jakie są najlepsze praktyki wdrażania MCP w środowiskach korporacyjnych
- Jakie wyzwania i rozwiązania pojawiają się w rzeczywistych wdrożeniach
- Jak zidentyfikować możliwości zastosowania podobnych wzorców w swoich projektach

## Wybrane Studia Przypadków

### 1. [Azure AI Travel Agents – Wdrożenie Referencyjne](./travelagentsample.md)

To studium przypadku analizuje kompleksowe rozwiązanie referencyjne Microsoftu, które pokazuje, jak zbudować wieloagentową aplikację do planowania podróży opartą na AI, wykorzystując MCP, Azure OpenAI i Azure AI Search. Projekt prezentuje:

- Orkiestrację wieloagentową za pomocą MCP
- Integrację danych korporacyjnych z Azure AI Search
- Bezpieczną, skalowalną architekturę opartą na usługach Azure
- Rozszerzalne narzędzia z wielokrotnego użytku komponentami MCP
- Konwersacyjną obsługę użytkownika wspieraną przez Azure OpenAI

Szczegóły architektury i wdrożenia dostarczają cennych wskazówek dotyczących budowy złożonych systemów wieloagentowych z MCP jako warstwą koordynacyjną.

### 2. [Aktualizacja Elementów Azure DevOps na Podstawie Danych z YouTube](./UpdateADOItemsFromYT.md)

To studium przypadku pokazuje praktyczne zastosowanie MCP do automatyzacji procesów roboczych. Demonstruje, jak narzędzia MCP mogą być używane do:

- Ekstrakcji danych z platform internetowych (YouTube)
- Aktualizacji elementów roboczych w systemach Azure DevOps
- Tworzenia powtarzalnych przepływów pracy automatyzacji
- Integracji danych z różnych systemów

Ten przykład ilustruje, jak nawet stosunkowo proste wdrożenia MCP mogą przynieść znaczące korzyści w zakresie efektywności, automatyzując rutynowe zadania i poprawiając spójność danych w systemach.

### 3. [Pobieranie Dokumentacji w Czasie Rzeczywistym z MCP](./docs-mcp/README.md)

To studium przypadku prowadzi Cię przez proces łączenia klienta konsolowego Python z serwerem Model Context Protocol (MCP) w celu pobierania i rejestrowania w czasie rzeczywistym kontekstowej dokumentacji Microsoftu. Dowiesz się, jak:

- Połączyć się z serwerem MCP za pomocą klienta Python i oficjalnego SDK MCP
- Używać strumieniowych klientów HTTP do efektywnego pobierania danych w czasie rzeczywistym
- Wywoływać narzędzia dokumentacyjne na serwerze i rejestrować odpowiedzi bezpośrednio w konsoli
- Zintegrować aktualną dokumentację Microsoftu w swoim przepływie pracy bez opuszczania terminala

Rozdział zawiera zadanie praktyczne, minimalny działający przykład kodu oraz linki do dodatkowych zasobów umożliwiających pogłębienie wiedzy. Zobacz pełny przewodnik i kod w podlinkowanym rozdziale, aby zrozumieć, jak MCP może zrewolucjonizować dostęp do dokumentacji i produktywność deweloperów w środowiskach konsolowych.

### 4. [Interaktywna Aplikacja Webowa do Generowania Planów Nauki z MCP](./docs-mcp/README.md)

To studium przypadku pokazuje, jak zbudować interaktywną aplikację webową za pomocą Chainlit i Model Context Protocol (MCP), aby generować spersonalizowane plany nauki na dowolny temat. Użytkownicy mogą określić temat (np. "Certyfikacja AI-900") i czas trwania nauki (np. 8 tygodni), a aplikacja dostarczy tygodniowy podział rekomendowanych treści. Chainlit umożliwia konwersacyjną obsługę, czyniąc doświadczenie angażującym i adaptacyjnym.

- Konwersacyjna aplikacja webowa wspierana przez Chainlit
- Wprowadzanie danych przez użytkownika dotyczących tematu i czasu trwania
- Tygodniowe rekomendacje treści za pomocą MCP
- Odpowiedzi w czasie rzeczywistym w interfejsie czatu

Projekt ilustruje, jak konwersacyjna AI i MCP mogą być połączone w celu tworzenia dynamicznych, zorientowanych na użytkownika narzędzi edukacyjnych w nowoczesnym środowisku webowym.

### 5. [Dokumentacja w Edytorze z Serwerem MCP w VS Code](./docs-mcp/README.md)

To studium przypadku pokazuje, jak można przenieść dokumentację Microsoft Learn Docs bezpośrednio do środowiska VS Code za pomocą serwera MCP – bez potrzeby przełączania kart przeglądarki! Dowiesz się, jak:

- Natychmiast wyszukiwać i czytać dokumentację w VS Code za pomocą panelu MCP lub palety poleceń
- Odnosić się do dokumentacji i wstawiać linki bezpośrednio do plików README lub markdown kursów
- Używać GitHub Copilot i MCP razem dla płynnych, wspieranych przez AI przepływów pracy z dokumentacją i kodem
- Walidować i ulepszać dokumentację dzięki opiniom w czasie rzeczywistym i dokładności źródeł Microsoftu
- Zintegrować MCP z przepływami pracy GitHub w celu ciągłej walidacji dokumentacji

Wdrożenie obejmuje:

- Przykładową konfigurację `.vscode/mcp.json` dla łatwego ustawienia
- Przewodniki oparte na zrzutach ekranu dotyczące doświadczenia w edytorze
- Wskazówki dotyczące łączenia Copilot i MCP dla maksymalnej produktywności

Ten scenariusz jest idealny dla autorów kursów, twórców dokumentacji i deweloperów, którzy chcą pozostać skupieni w edytorze, pracując z dokumentacją, Copilotem i narzędziami walidacyjnymi – wszystko wspierane przez MCP.

### 6. [Tworzenie Serwera MCP z APIM](./apimsample.md)

To studium przypadku dostarcza przewodnika krok po kroku, jak stworzyć serwer MCP za pomocą Azure API Management (APIM). Obejmuje:

- Konfigurację serwera MCP w Azure API Management
- Udostępnianie operacji API jako narzędzi MCP
- Konfigurowanie polityk dotyczących limitów szybkości i bezpieczeństwa
- Testowanie serwera MCP za pomocą Visual Studio Code i GitHub Copilot

Ten przykład ilustruje, jak wykorzystać możliwości Azure do stworzenia solidnego serwera MCP, który może być używany w różnych aplikacjach, poprawiając integrację systemów AI z korporacyjnymi API.

## Podsumowanie

Te studia przypadków podkreślają wszechstronność i praktyczne zastosowania Model Context Protocol w rzeczywistych scenariuszach. Od złożonych systemów wieloagentowych po ukierunkowane przepływy pracy automatyzacji, MCP zapewnia ustandaryzowany sposób łączenia systemów AI z narzędziami i danymi, których potrzebują, aby dostarczać wartość.

Analizując te wdrożenia, możesz zdobyć wiedzę na temat wzorców architektonicznych, strategii wdrażania i najlepszych praktyk, które można zastosować w swoich projektach MCP. Przykłady te pokazują, że MCP to nie tylko teoretyczne ramy, ale praktyczne rozwiązanie rzeczywistych wyzwań biznesowych.

## Dodatkowe Zasoby

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Dalej: Laboratorium Praktyczne [Usprawnianie Przepływów Pracy AI: Budowanie Serwera MCP z AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Zastrzeżenie**:  
Ten dokument został przetłumaczony za pomocą usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy wszelkich starań, aby zapewnić precyzję, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w jego rodzimym języku powinien być uznawany za autorytatywne źródło. W przypadku informacji o kluczowym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.