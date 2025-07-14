<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-14T05:45:50+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "pl"
}
-->
# MCP w praktyce: studia przypadków z rzeczywistego świata

Model Context Protocol (MCP) zmienia sposób, w jaki aplikacje AI współpracują z danymi, narzędziami i usługami. W tej sekcji przedstawiono studia przypadków z rzeczywistego świata, które pokazują praktyczne zastosowania MCP w różnych scenariuszach biznesowych.

## Przegląd

Ta sekcja prezentuje konkretne przykłady wdrożeń MCP, podkreślając, jak organizacje wykorzystują ten protokół do rozwiązywania złożonych problemów biznesowych. Analizując te studia przypadków, zdobędziesz wiedzę na temat wszechstronności, skalowalności i praktycznych korzyści MCP w rzeczywistych zastosowaniach.

## Kluczowe cele nauki

Analizując te studia przypadków, będziesz mógł:

- Zrozumieć, jak MCP można zastosować do rozwiązywania konkretnych problemów biznesowych
- Poznać różne wzorce integracji i podejścia architektoniczne
- Rozpoznać najlepsze praktyki wdrażania MCP w środowiskach korporacyjnych
- Zyskać wgląd w wyzwania i rozwiązania napotkane podczas rzeczywistych wdrożeń
- Zidentyfikować możliwości zastosowania podobnych wzorców w swoich projektach

## Prezentowane studia przypadków

### 1. [Azure AI Travel Agents – implementacja referencyjna](./travelagentsample.md)

To studium przypadku analizuje kompleksowe rozwiązanie referencyjne Microsoftu, które pokazuje, jak zbudować wieloagentową aplikację do planowania podróży zasilaną AI, wykorzystując MCP, Azure OpenAI i Azure AI Search. Projekt prezentuje:

- Orkiestrację wieloagentową za pomocą MCP
- Integrację danych korporacyjnych z Azure AI Search
- Bezpieczną, skalowalną architekturę opartą na usługach Azure
- Rozszerzalne narzędzia z wielokrotnego użytku komponentami MCP
- Konwersacyjne doświadczenie użytkownika zasilane przez Azure OpenAI

Architektura i szczegóły implementacji dostarczają cennych wskazówek dotyczących budowy złożonych systemów wieloagentowych z MCP jako warstwą koordynacyjną.

### 2. [Aktualizacja elementów Azure DevOps na podstawie danych z YouTube](./UpdateADOItemsFromYT.md)

To studium przypadku pokazuje praktyczne zastosowanie MCP do automatyzacji procesów roboczych. Prezentuje, jak narzędzia MCP mogą być użyte do:

- Pobierania danych z platform internetowych (YouTube)
- Aktualizacji elementów pracy w systemach Azure DevOps
- Tworzenia powtarzalnych procesów automatyzacji
- Integracji danych między różnymi systemami

Ten przykład ilustruje, jak nawet stosunkowo proste wdrożenia MCP mogą przynieść znaczące korzyści efektywności, automatyzując rutynowe zadania i poprawiając spójność danych między systemami.

### 3. [Pobieranie dokumentacji w czasie rzeczywistym z MCP](./docs-mcp/README.md)

To studium przypadku przeprowadza przez proces łączenia klienta konsolowego w Pythonie z serwerem Model Context Protocol (MCP) w celu pobierania i rejestrowania w czasie rzeczywistym kontekstowej dokumentacji Microsoft. Nauczysz się, jak:

- Połączyć się z serwerem MCP za pomocą klienta Python i oficjalnego SDK MCP
- Korzystać z klienta HTTP streamingowego dla efektywnego pobierania danych w czasie rzeczywistym
- Wywoływać narzędzia dokumentacyjne na serwerze i logować odpowiedzi bezpośrednio do konsoli
- Włączyć aktualną dokumentację Microsoft do swojego workflow bez opuszczania terminala

Rozdział zawiera praktyczne zadanie, minimalny działający przykład kodu oraz linki do dodatkowych zasobów do pogłębionej nauki. Zobacz pełny przewodnik i kod w powiązanym rozdziale, aby zrozumieć, jak MCP może zmienić dostęp do dokumentacji i produktywność programistów w środowiskach konsolowych.

### 4. [Interaktywna aplikacja webowa do generowania planów nauki z MCP](./docs-mcp/README.md)

To studium przypadku pokazuje, jak zbudować interaktywną aplikację webową wykorzystującą Chainlit i Model Context Protocol (MCP) do generowania spersonalizowanych planów nauki dla dowolnego tematu. Użytkownicy mogą określić temat (np. „certyfikacja AI-900”) oraz czas nauki (np. 8 tygodni), a aplikacja dostarczy tygodniowy podział rekomendowanych materiałów. Chainlit umożliwia konwersacyjny interfejs czatu, co sprawia, że doświadczenie jest angażujące i adaptacyjne.

- Konwersacyjna aplikacja webowa zasilana przez Chainlit
- Wprowadzanie tematów i czasu nauki przez użytkownika
- Tygodniowe rekomendacje treści z wykorzystaniem MCP
- Adaptacyjne odpowiedzi w czasie rzeczywistym w interfejsie czatu

Projekt pokazuje, jak AI konwersacyjne i MCP można połączyć, tworząc dynamiczne, sterowane przez użytkownika narzędzia edukacyjne w nowoczesnym środowisku webowym.

### 5. [Dokumentacja w edytorze z serwerem MCP w VS Code](./docs-mcp/README.md)

To studium przypadku pokazuje, jak wprowadzić Microsoft Learn Docs bezpośrednio do środowiska VS Code za pomocą serwera MCP — koniec z przełączaniem się między kartami przeglądarki! Zobaczysz, jak:

- Natychmiast wyszukiwać i czytać dokumentację w VS Code za pomocą panelu MCP lub palety poleceń
- Odwoływać się do dokumentacji i wstawiać linki bezpośrednio do plików README lub kursów w formacie markdown
- Korzystać z GitHub Copilot i MCP razem dla płynnych, zasilanych AI procesów dokumentacji i kodowania
- Weryfikować i ulepszać dokumentację dzięki informacji zwrotnej w czasie rzeczywistym i dokładności pochodzącej od Microsoft
- Integracja MCP z workflow GitHub dla ciągłej walidacji dokumentacji

Wdrożenie zawiera:
- Przykładową konfigurację `.vscode/mcp.json` dla łatwego uruchomienia
- Przewodniki oparte na zrzutach ekranu pokazujące doświadczenie w edytorze
- Wskazówki dotyczące łączenia Copilot i MCP dla maksymalnej produktywności

Ten scenariusz jest idealny dla autorów kursów, twórców dokumentacji i programistów, którzy chcą pozostać skoncentrowani w edytorze podczas pracy z dokumentacją, Copilotem i narzędziami walidacyjnymi — wszystko to dzięki MCP.

### 6. [Tworzenie serwera MCP w APIM](./apimsample.md)

To studium przypadku przedstawia krok po kroku, jak stworzyć serwer MCP za pomocą Azure API Management (APIM). Obejmuje:

- Konfigurację serwera MCP w Azure API Management
- Udostępnianie operacji API jako narzędzi MCP
- Konfigurację polityk ograniczania liczby żądań i zabezpieczeń
- Testowanie serwera MCP za pomocą Visual Studio Code i GitHub Copilot

Ten przykład pokazuje, jak wykorzystać możliwości Azure do stworzenia solidnego serwera MCP, który może być używany w różnych aplikacjach, wzmacniając integrację systemów AI z korporacyjnymi API.

## Podsumowanie

Te studia przypadków podkreślają wszechstronność i praktyczne zastosowania Model Context Protocol w rzeczywistych scenariuszach. Od złożonych systemów wieloagentowych po ukierunkowane procesy automatyzacji, MCP zapewnia ustandaryzowany sposób łączenia systemów AI z narzędziami i danymi niezbędnymi do dostarczania wartości.

Analizując te wdrożenia, możesz zdobyć wiedzę na temat wzorców architektonicznych, strategii implementacji i najlepszych praktyk, które można zastosować w swoich projektach MCP. Przykłady pokazują, że MCP to nie tylko teoria, ale praktyczne rozwiązanie rzeczywistych wyzwań biznesowych.

## Dodatkowe zasoby

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Następny temat: Hands on Lab [Streamlining AI Workflows: Building an MCP Server with AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.