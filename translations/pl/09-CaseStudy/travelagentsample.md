<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:46:57+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "pl"
}
-->
# Studium przypadku: Azure AI Travel Agents – implementacja referencyjna

## Przegląd

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) to kompleksowe rozwiązanie referencyjne opracowane przez Microsoft, które pokazuje, jak zbudować aplikację do planowania podróży z wieloma agentami AI, wykorzystując Model Context Protocol (MCP), Azure OpenAI oraz Azure AI Search. Projekt ten prezentuje najlepsze praktyki w zakresie koordynacji wielu agentów AI, integracji danych korporacyjnych oraz zapewnienia bezpiecznej i rozszerzalnej platformy do zastosowań w rzeczywistych scenariuszach.

## Kluczowe funkcje
- **Orkiestracja wieloagentowa:** Wykorzystuje MCP do koordynacji wyspecjalizowanych agentów (np. FlightAgent, HotelAgent, ItineraryAgent), którzy współpracują, aby realizować złożone zadania związane z planowaniem podróży.
- **Integracja danych korporacyjnych:** Łączy się z Azure AI Search oraz innymi źródłami danych korporacyjnych, aby dostarczać aktualne i istotne informacje do rekomendacji podróży.
- **Bezpieczna, skalowalna architektura:** Wykorzystuje usługi Azure do uwierzytelniania, autoryzacji oraz skalowalnego wdrożenia, stosując najlepsze praktyki bezpieczeństwa dla przedsiębiorstw.
- **Rozszerzalne narzędzia:** Implementuje wielokrotnego użytku narzędzia MCP oraz szablony promptów, co umożliwia szybkie dostosowanie do nowych dziedzin lub wymagań biznesowych.
- **Doświadczenie użytkownika:** Zapewnia interfejs konwersacyjny, dzięki któremu użytkownicy mogą wchodzić w interakcje z agentami podróży, korzystając z mocy Azure OpenAI i MCP.

## Architektura
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Opis diagramu architektury

Rozwiązanie Azure AI Travel Agents zostało zaprojektowane z myślą o modularności, skalowalności oraz bezpiecznej integracji wielu agentów AI i źródeł danych korporacyjnych. Główne komponenty oraz przepływ danych przedstawiają się następująco:

- **Interfejs użytkownika:** Użytkownicy komunikują się z systemem za pomocą konwersacyjnego UI (np. czat na stronie internetowej lub bot w Teams), który przesyła zapytania i odbiera rekomendacje dotyczące podróży.
- **MCP Server:** Pełni rolę centralnego koordynatora, przyjmując dane od użytkownika, zarządzając kontekstem oraz koordynując działania wyspecjalizowanych agentów (np. FlightAgent, HotelAgent, ItineraryAgent) za pomocą Model Context Protocol.
- **Agenci AI:** Każdy agent odpowiada za określoną dziedzinę (loty, hotele, planowanie tras) i jest zaimplementowany jako narzędzie MCP. Agenci korzystają z szablonów promptów i logiki do przetwarzania zapytań i generowania odpowiedzi.
- **Azure OpenAI Service:** Zapewnia zaawansowane możliwości rozumienia i generowania języka naturalnego, umożliwiając agentom interpretację intencji użytkownika oraz tworzenie odpowiedzi w naturalnym, konwersacyjnym stylu.
- **Azure AI Search i dane korporacyjne:** Agenci korzystają z Azure AI Search oraz innych źródeł danych korporacyjnych, aby uzyskać aktualne informacje o lotach, hotelach i opcjach podróży.
- **Uwierzytelnianie i bezpieczeństwo:** Integruje się z Microsoft Entra ID, zapewniając bezpieczne uwierzytelnianie oraz stosując zasady minimalnych uprawnień do wszystkich zasobów.
- **Wdrożenie:** Zaprojektowane do uruchomienia na Azure Container Apps, co gwarantuje skalowalność, monitorowanie oraz efektywność operacyjną.

Ta architektura umożliwia płynną orkiestrację wielu agentów AI, bezpieczną integrację z danymi korporacyjnymi oraz solidną, rozszerzalną platformę do tworzenia rozwiązań AI specyficznych dla danej dziedziny.

## Szczegółowe wyjaśnienie diagramu architektury
Wyobraź sobie, że planujesz dużą podróż i masz zespół ekspertów, którzy pomagają Ci w każdym szczególe. System Azure AI Travel Agents działa podobnie, wykorzystując różne elementy (jak członków zespołu), z których każdy ma swoje specjalne zadanie. Oto jak to wszystko działa razem:

### Interfejs użytkownika (UI):
To jak recepcja twojego agenta podróży. To miejsce, gdzie Ty (użytkownik) zadajesz pytania lub składasz prośby, na przykład „Znajdź lot do Paryża”. Może to być okno czatu na stronie lub aplikacja do komunikacji.

### MCP Server (koordynator):
MCP Server to jak menedżer, który słucha Twojej prośby na recepcji i decyduje, który specjalista powinien się nią zająć. Śledzi przebieg rozmowy i dba o to, aby wszystko działało sprawnie.

### Agenci AI (specjalistyczni asystenci):
Każdy agent jest ekspertem w swojej dziedzinie – jeden zna się na lotach, inny na hotelach, a kolejny na planowaniu tras. Kiedy prosisz o podróż, MCP Server przekazuje Twoje zapytanie odpowiednim agentom. Agenci wykorzystują swoją wiedzę i narzędzia, aby znaleźć dla Ciebie najlepsze opcje.

### Azure OpenAI Service (ekspert językowy):
To jak posiadanie eksperta językowego, który dokładnie rozumie, o co pytasz, niezależnie od sposobu wyrażenia. Pomaga agentom zrozumieć Twoje zapytania i odpowiadać w naturalnym, konwersacyjnym stylu.

### Azure AI Search i dane korporacyjne (biblioteka informacji):
Wyobraź sobie ogromną, aktualną bibliotekę z najnowszymi informacjami o podróżach – rozkłady lotów, dostępność hoteli i inne dane. Agenci przeszukują tę bibliotekę, by dostarczyć Ci najdokładniejsze odpowiedzi.

### Uwierzytelnianie i bezpieczeństwo (ochroniarz):
Podobnie jak ochroniarz sprawdzający, kto może wejść do określonych stref, ta część dba, aby tylko uprawnione osoby i agenci mieli dostęp do wrażliwych informacji. Chroni Twoje dane i prywatność.

### Wdrożenie na Azure Container Apps (budynek):
Wszyscy ci asystenci i narzędzia współpracują w bezpiecznym, skalowalnym „budynku” (chmurze). Oznacza to, że system może obsłużyć wielu użytkowników jednocześnie i jest dostępny zawsze, gdy go potrzebujesz.

## Jak to wszystko działa razem:

Zaczynasz od zadania pytania na recepcji (UI).  
Menedżer (MCP Server) decyduje, który specjalista (agent) powinien Ci pomóc.  
Specjalista korzysta z eksperta językowego (OpenAI), aby zrozumieć Twoje zapytanie, oraz z biblioteki (AI Search), by znaleźć najlepszą odpowiedź.  
Ochroniarz (uwierzytelnianie) dba o bezpieczeństwo całego procesu.  
Wszystko to dzieje się w niezawodnym, skalowalnym „budynku” (Azure Container Apps), dzięki czemu Twoje doświadczenie jest płynne i bezpieczne.  
Ta współpraca pozwala systemowi szybko i bezpiecznie pomóc Ci zaplanować podróż, tak jak zespół ekspertów pracujący razem w nowoczesnym biurze!

## Implementacja techniczna
- **MCP Server:** Hostuje główną logikę orkiestracji, udostępnia narzędzia agentów oraz zarządza kontekstem dla wieloetapowych procesów planowania podróży.
- **Agenci:** Każdy agent (np. FlightAgent, HotelAgent) jest zaimplementowany jako narzędzie MCP z własnymi szablonami promptów i logiką.
- **Integracja z Azure:** Wykorzystuje Azure OpenAI do rozumienia języka naturalnego oraz Azure AI Search do pobierania danych.
- **Bezpieczeństwo:** Integruje się z Microsoft Entra ID w celu uwierzytelniania i stosuje zasady minimalnych uprawnień do wszystkich zasobów.
- **Wdrożenie:** Obsługuje wdrożenie na Azure Container Apps, zapewniając skalowalność i efektywność operacyjną.

## Wyniki i wpływ
- Pokazuje, jak MCP może być wykorzystany do orkiestracji wielu agentów AI w scenariuszu produkcyjnym.
- Przyspiesza rozwój rozwiązań, dostarczając wzorce wielokrotnego użytku do koordynacji agentów, integracji danych i bezpiecznego wdrożenia.
- Służy jako wzorzec do budowania aplikacji AI specyficznych dla danej dziedziny, wykorzystujących MCP i usługi Azure.

## Źródła
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za autorytatywne źródło. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.