<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:38:15+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "pl"
}
-->
# Studium przypadku: Azure AI Travel Agents – implementacja referencyjna

## Przegląd

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) to kompleksowe rozwiązanie referencyjne opracowane przez Microsoft, które pokazuje, jak zbudować aplikację do planowania podróży z wieloma agentami AI, wykorzystując Model Context Protocol (MCP), Azure OpenAI oraz Azure AI Search. Projekt prezentuje najlepsze praktyki w zakresie koordynacji wielu agentów AI, integracji danych korporacyjnych oraz zapewnienia bezpiecznej i rozszerzalnej platformy dla rzeczywistych scenariuszy.

## Kluczowe cechy
- **Orkiestracja wieloagentowa:** Wykorzystuje MCP do koordynacji wyspecjalizowanych agentów (np. FlightAgent, HotelAgent, ItineraryAgent), którzy współpracują, aby zrealizować złożone zadania związane z planowaniem podróży.
- **Integracja danych korporacyjnych:** Łączy się z Azure AI Search oraz innymi źródłami danych przedsiębiorstwa, dostarczając aktualne i istotne informacje do rekomendacji podróży.
- **Bezpieczna, skalowalna architektura:** Wykorzystuje usługi Azure do uwierzytelniania, autoryzacji oraz skalowalnego wdrażania, stosując najlepsze praktyki bezpieczeństwa korporacyjnego.
- **Rozszerzalne narzędzia:** Implementuje wielokrotnego użytku narzędzia MCP oraz szablony promptów, umożliwiające szybkie dostosowanie do nowych dziedzin lub wymagań biznesowych.
- **Doświadczenie użytkownika:** Udostępnia interfejs konwersacyjny, dzięki któremu użytkownicy mogą komunikować się z agentami podróży, wspierany przez Azure OpenAI i MCP.

## Architektura
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Opis diagramu architektury

Rozwiązanie Azure AI Travel Agents zostało zaprojektowane z myślą o modularności, skalowalności oraz bezpiecznej integracji wielu agentów AI i źródeł danych korporacyjnych. Główne komponenty i przepływ danych przedstawiają się następująco:

- **Interfejs użytkownika:** Użytkownicy wchodzą w interakcję z systemem za pomocą konwersacyjnego UI (np. czatu internetowego lub bota Teams), wysyłając zapytania i otrzymując rekomendacje podróży.
- **MCP Server:** Pełni rolę centralnego koordynatora, odbierając dane od użytkownika, zarządzając kontekstem i koordynując działania wyspecjalizowanych agentów (np. FlightAgent, HotelAgent, ItineraryAgent) za pomocą Model Context Protocol.
- **Agenci AI:** Każdy agent odpowiada za określoną dziedzinę (loty, hotele, plan podróży) i jest zaimplementowany jako narzędzie MCP. Agenci korzystają z szablonów promptów i logiki do przetwarzania zapytań i generowania odpowiedzi.
- **Azure OpenAI Service:** Zapewnia zaawansowane rozumienie i generowanie języka naturalnego, umożliwiając agentom interpretację intencji użytkownika i tworzenie konwersacyjnych odpowiedzi.
- **Azure AI Search i dane korporacyjne:** Agenci wyszukują w Azure AI Search oraz innych źródłach danych przedsiębiorstwa, aby uzyskać aktualne informacje o lotach, hotelach i opcjach podróży.
- **Uwierzytelnianie i bezpieczeństwo:** Integruje się z Microsoft Entra ID, zapewniając bezpieczne uwierzytelnianie i stosując zasady najmniejszych uprawnień dla wszystkich zasobów.
- **Wdrożenie:** Zaprojektowane do uruchomienia na Azure Container Apps, co gwarantuje skalowalność, monitorowanie i efektywność operacyjną.

Ta architektura umożliwia płynną orkiestrację wielu agentów AI, bezpieczną integrację z danymi korporacyjnymi oraz stabilną i rozszerzalną platformę do tworzenia specjalistycznych rozwiązań AI.

## Szczegółowe wyjaśnienie diagramu architektury
Wyobraź sobie, że planujesz dużą podróż i masz zespół ekspertów, którzy pomagają Ci w każdym szczególe. System Azure AI Travel Agents działa podobnie, wykorzystując różne elementy (jak członków zespołu), z których każdy ma swoje specjalne zadanie. Oto jak to wszystko działa:

### Interfejs użytkownika (UI):
Pomyśl o tym jak o recepcji twojego agenta podróży. To miejsce, gdzie Ty (użytkownik) zadajesz pytania lub składasz prośby, np. „Znajdź mi lot do Paryża”. Może to być okno czatu na stronie internetowej lub aplikacji do wiadomości.

### MCP Server (koordynator):
MCP Server to jak menedżer, który słucha Twojej prośby na recepcji i decyduje, który specjalista powinien się nią zająć. Śledzi przebieg rozmowy i dba, aby wszystko przebiegało sprawnie.

### Agenci AI (specjalistyczni asystenci):
Każdy agent to ekspert w konkretnej dziedzinie – jeden zna się na lotach, inny na hotelach, a jeszcze inny na planowaniu trasy. Kiedy prosisz o podróż, MCP Server przekazuje Twoje zapytanie do odpowiedniego agenta lub agentów. Oni wykorzystują swoją wiedzę i narzędzia, by znaleźć dla Ciebie najlepsze opcje.

### Azure OpenAI Service (ekspert językowy):
To jak ekspert językowy, który dokładnie rozumie, o co pytasz, niezależnie od tego, jak sformułujesz swoje zdanie. Pomaga agentom zrozumieć Twoje prośby i odpowiadać w naturalnym, rozmownym języku.

### Azure AI Search i dane korporacyjne (biblioteka informacji):
Wyobraź sobie ogromną, zawsze aktualną bibliotekę z najnowszymi informacjami o podróżach – rozkładami lotów, dostępnością hoteli i innymi. Agenci przeszukują tę bibliotekę, aby znaleźć dla Ciebie najbardziej precyzyjne odpowiedzi.

### Uwierzytelnianie i bezpieczeństwo (ochroniarz):
Tak jak ochroniarz sprawdza, kto może wejść do określonych miejsc, ten element dba, aby tylko uprawnione osoby i agenci mieli dostęp do wrażliwych danych. Chroni Twoje informacje i prywatność.

### Wdrożenie na Azure Container Apps (budynek):
Wszyscy ci asystenci i narzędzia działają razem w bezpiecznym, skalowalnym „budynku” (chmurze). Dzięki temu system może obsłużyć wielu użytkowników jednocześnie i jest zawsze dostępny, gdy go potrzebujesz.

## Jak to wszystko działa razem:

Zaczynasz od zadania pytania na recepcji (UI).
Menedżer (MCP Server) ustala, który specjalista (agent) powinien Ci pomóc.
Specjalista korzysta z eksperta językowego (OpenAI), aby zrozumieć Twoje zapytanie, oraz z biblioteki (AI Search), aby znaleźć najlepszą odpowiedź.
Ochroniarz (uwierzytelnianie) dba, by wszystko było bezpieczne.
Całość działa w niezawodnym, skalowalnym „budynku” (Azure Container Apps), dzięki czemu Twoje doświadczenie jest płynne i bezpieczne.
Ta współpraca pozwala systemowi szybko i bezpiecznie pomóc Ci zaplanować podróż, niczym zespół ekspertów pracujących razem w nowoczesnym biurze!

## Implementacja techniczna
- **MCP Server:** Obsługuje główną logikę orkiestracji, udostępnia narzędzia agentów i zarządza kontekstem dla wieloetapowych procesów planowania podróży.
- **Agenci:** Każdy agent (np. FlightAgent, HotelAgent) jest zaimplementowany jako narzędzie MCP z własnymi szablonami promptów i logiką.
- **Integracja z Azure:** Wykorzystuje Azure OpenAI do rozumienia języka naturalnego oraz Azure AI Search do pobierania danych.
- **Bezpieczeństwo:** Integruje się z Microsoft Entra ID w celu uwierzytelniania i stosuje zasady najmniejszych uprawnień dla wszystkich zasobów.
- **Wdrożenie:** Obsługuje wdrożenie na Azure Container Apps dla zapewnienia skalowalności i efektywności operacyjnej.

## Wyniki i wpływ
- Pokazuje, jak MCP może być używany do koordynacji wielu agentów AI w rzeczywistych, produkcyjnych scenariuszach.
- Przyspiesza rozwój rozwiązań, dostarczając wielokrotnego użytku wzorce koordynacji agentów, integracji danych i bezpiecznego wdrażania.
- Stanowi wzorzec do budowy specjalistycznych aplikacji AI opartych na MCP i usługach Azure.

## Źródła
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za autorytatywne źródło. W przypadku informacji o krytycznym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.