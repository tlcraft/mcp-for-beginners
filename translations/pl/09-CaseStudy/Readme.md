<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-16T14:47:52+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "pl"
}
-->
# Studium przypadku: Azure AI Travel Agents – implementacja referencyjna

## Przegląd

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) to kompleksowe rozwiązanie referencyjne opracowane przez Microsoft, które pokazuje, jak zbudować aplikację do planowania podróży z wieloma agentami wspieranymi przez AI, wykorzystując Model Context Protocol (MCP), Azure OpenAI oraz Azure AI Search. Projekt prezentuje najlepsze praktyki w zakresie koordynacji wielu agentów AI, integracji danych korporacyjnych oraz zapewniania bezpiecznej i rozszerzalnej platformy dla rzeczywistych scenariuszy.

## Kluczowe funkcje
- **Orkiestracja wieloagentowa:** Wykorzystuje MCP do koordynacji wyspecjalizowanych agentów (np. FlightAgent, HotelAgent, ItineraryAgent), którzy współpracują, aby realizować złożone zadania związane z planowaniem podróży.
- **Integracja danych korporacyjnych:** Łączy się z Azure AI Search oraz innymi źródłami danych korporacyjnych, dostarczając aktualne i istotne informacje do rekomendacji podróży.
- **Bezpieczna, skalowalna architektura:** Wykorzystuje usługi Azure do uwierzytelniania, autoryzacji oraz skalowalnego wdrażania, zgodnie z najlepszymi praktykami bezpieczeństwa w przedsiębiorstwach.
- **Rozszerzalne narzędzia:** Implementuje wielokrotnego użytku narzędzia MCP oraz szablony promptów, umożliwiając szybkie dostosowanie do nowych dziedzin lub wymagań biznesowych.
- **Doświadczenie użytkownika:** Udostępnia interfejs konwersacyjny, pozwalający użytkownikom na interakcję z agentami podróży, zasilany przez Azure OpenAI i MCP.

## Architektura
![Architecture](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Opis diagramu architektury

Rozwiązanie Azure AI Travel Agents zostało zaprojektowane z myślą o modularności, skalowalności oraz bezpiecznej integracji wielu agentów AI i źródeł danych korporacyjnych. Główne komponenty i przepływ danych przedstawiają się następująco:

- **Interfejs użytkownika:** Użytkownicy wchodzą w interakcję z systemem za pomocą konwersacyjnego UI (np. czat na stronie internetowej lub bot w Teams), które wysyła zapytania użytkownika i odbiera rekomendacje podróży.
- **MCP Server:** Pełni rolę centralnego koordynatora, odbierając dane wejściowe od użytkownika, zarządzając kontekstem oraz koordynując działania wyspecjalizowanych agentów (np. FlightAgent, HotelAgent, ItineraryAgent) za pomocą Model Context Protocol.
- **Agenci AI:** Każdy agent odpowiada za konkretną dziedzinę (loty, hotele, plan podróży) i jest zaimplementowany jako narzędzie MCP. Agenci korzystają z szablonów promptów i logiki do przetwarzania zapytań i generowania odpowiedzi.
- **Azure OpenAI Service:** Zapewnia zaawansowane rozumienie i generowanie języka naturalnego, umożliwiając agentom interpretację intencji użytkownika oraz tworzenie konwersacyjnych odpowiedzi.
- **Azure AI Search & dane korporacyjne:** Agenci wyszukują w Azure AI Search i innych źródłach danych korporacyjnych, aby uzyskać aktualne informacje o lotach, hotelach i opcjach podróży.
- **Uwierzytelnianie i bezpieczeństwo:** Integruje się z Microsoft Entra ID dla bezpiecznego uwierzytelniania i stosuje zasadę najmniejszych uprawnień do wszystkich zasobów.
- **Wdrażanie:** Zaprojektowane do uruchomienia na Azure Container Apps, zapewniając skalowalność, monitorowanie i efektywność operacyjną.

Ta architektura umożliwia płynną orkiestrację wielu agentów AI, bezpieczną integrację z danymi korporacyjnymi oraz solidną, rozszerzalną platformę do tworzenia rozwiązań AI dedykowanych określonym dziedzinom.

## Szczegółowe wyjaśnienie diagramu architektury
Wyobraź sobie, że planujesz dużą podróż i masz zespół ekspertów, którzy pomagają Ci w każdym detalu. System Azure AI Travel Agents działa podobnie, wykorzystując różne elementy (jak członków zespołu), z których każdy ma swoją specjalną rolę. Oto jak to wszystko działa razem:

### Interfejs użytkownika (UI):
Pomyśl o tym jak o recepcji Twojego agenta podróży. To miejsce, gdzie Ty (użytkownik) zadajesz pytania lub składujesz prośby, np. „Znajdź lot do Paryża”. Może to być okno czatu na stronie internetowej lub aplikacja do komunikacji.

### MCP Server (koordynator):
MCP Server jest jak menedżer, który słucha Twojej prośby na recepcji i decyduje, który specjalista powinien się nią zająć. Śledzi przebieg rozmowy i dba, aby wszystko działało sprawnie.

### Agenci AI (specjalistyczni asystenci):
Każdy agent jest ekspertem w konkretnej dziedzinie – jeden zna się na lotach, inny na hotelach, a jeszcze inny na planowaniu trasy. Gdy prosisz o podróż, MCP Server przesyła Twoje zapytanie do odpowiedniego agenta lub agentów. Agenci wykorzystują swoją wiedzę i narzędzia, aby znaleźć najlepsze opcje dla Ciebie.

### Azure OpenAI Service (ekspert językowy):
To jak posiadanie eksperta językowego, który rozumie dokładnie, o co pytasz, bez względu na to, jak sformułujesz swoje zapytanie. Pomaga agentom zrozumieć Twoje prośby i odpowiadać w naturalnym, konwersacyjnym języku.

### Azure AI Search & dane korporacyjne (biblioteka informacji):
Wyobraź sobie ogromną, aktualną bibliotekę z najnowszymi informacjami o podróżach – rozkładami lotów, dostępnością hoteli i innymi danymi. Agenci przeszukują tę bibliotekę, aby uzyskać najdokładniejsze odpowiedzi.

### Uwierzytelnianie i bezpieczeństwo (ochroniarz):
Podobnie jak ochroniarz sprawdza, kto może wejść do określonych miejsc, ta część zapewnia, że tylko upoważnione osoby i agenci mają dostęp do poufnych informacji. Chroni Twoje dane i prywatność.

### Wdrażanie na Azure Container Apps (budynek):
Wszyscy ci asystenci i narzędzia działają razem w bezpiecznym, skalowalnym „budynku” (chmurze). Oznacza to, że system może obsługiwać wielu użytkowników jednocześnie i jest zawsze dostępny, gdy go potrzebujesz.

## Jak to wszystko działa razem:

Zaczynasz od zadania pytania na recepcji (UI).
Menedżer (MCP Server) ustala, który specjalista (agent) powinien Ci pomóc.
Specjalista korzysta z eksperta językowego (OpenAI), aby zrozumieć Twoją prośbę, oraz z biblioteki (AI Search), aby znaleźć najlepszą odpowiedź.
Ochroniarz (uwierzytelnianie) dba o bezpieczeństwo całego procesu.
Wszystko to dzieje się w niezawodnym, skalowalnym budynku (Azure Container Apps), dzięki czemu Twoje doświadczenie jest płynne i bezpieczne.
Ta współpraca pozwala systemowi szybko i bezpiecznie pomóc Ci zaplanować podróż, niczym zespół ekspertów działających razem w nowoczesnym biurze!

## Implementacja techniczna
- **MCP Server:** Hostuje główną logikę orkiestracji, udostępnia narzędzia agentów i zarządza kontekstem dla wieloetapowych procesów planowania podróży.
- **Agenci:** Każdy agent (np. FlightAgent, HotelAgent) jest zaimplementowany jako narzędzie MCP z własnymi szablonami promptów i logiką.
- **Integracja z Azure:** Wykorzystuje Azure OpenAI do rozumienia języka naturalnego oraz Azure AI Search do pobierania danych.
- **Bezpieczeństwo:** Integruje się z Microsoft Entra ID dla uwierzytelniania i stosuje zasadę najmniejszych uprawnień do wszystkich zasobów.
- **Wdrażanie:** Obsługuje wdrażanie na Azure Container Apps, zapewniając skalowalność i efektywność operacyjną.

## Wyniki i wpływ
- Pokazuje, jak MCP może być używany do orkiestracji wielu agentów AI w rzeczywistym, produkcyjnym scenariuszu.
- Przyspiesza rozwój rozwiązań, dostarczając wielokrotnego użytku wzorce koordynacji agentów, integracji danych i bezpiecznego wdrażania.
- Stanowi wzorzec do budowania aplikacji AI dedykowanych określonym dziedzinom, wykorzystujących MCP i usługi Azure.

## Źródła
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być traktowany jako źródło wiarygodne. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.