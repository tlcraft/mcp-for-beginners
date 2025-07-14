<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-13T23:43:52+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "pl"
}
-->
# Zaawansowane tematy w MCP

Ten rozdział ma na celu omówienie szeregu zaawansowanych zagadnień związanych z implementacją Model Context Protocol (MCP), w tym integracji multimodalnej, skalowalności, najlepszych praktyk bezpieczeństwa oraz integracji korporacyjnej. Tematy te są kluczowe dla budowania solidnych i gotowych do produkcji aplikacji MCP, które sprostają wymaganiom nowoczesnych systemów AI.

## Przegląd

Ta lekcja bada zaawansowane koncepcje implementacji Model Context Protocol, koncentrując się na integracji multimodalnej, skalowalności, najlepszych praktykach bezpieczeństwa oraz integracji korporacyjnej. Tematy te są niezbędne do tworzenia aplikacji MCP na poziomie produkcyjnym, które mogą obsługiwać złożone wymagania w środowiskach korporacyjnych.

## Cele nauki

Po ukończeniu tej lekcji będziesz potrafił:

- Wdrażać możliwości multimodalne w ramach MCP
- Projektować skalowalne architektury MCP na potrzeby scenariuszy o dużym zapotrzebowaniu
- Stosować najlepsze praktyki bezpieczeństwa zgodne z zasadami bezpieczeństwa MCP
- Integracja MCP z korporacyjnymi systemami i frameworkami AI
- Optymalizować wydajność i niezawodność w środowiskach produkcyjnych

## Lekcje i przykładowe projekty

| Link | Tytuł | Opis |
|------|-------|------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integracja z Azure | Naucz się, jak zintegrować swój MCP Server na platformie Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Przykłady MCP multimodalnego | Przykłady odpowiedzi audio, obrazów i multimodalnych |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Demo MCP OAuth2 | Minimalna aplikacja Spring Boot pokazująca OAuth2 z MCP, zarówno jako Authorization, jak i Resource Server. Demonstruje bezpieczne wydawanie tokenów, chronione endpointy, wdrożenie w Azure Container Apps oraz integrację z API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Konteksty główne | Dowiedz się więcej o kontekście głównym i jak go zaimplementować |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Poznaj różne typy routingu |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naucz się, jak pracować z samplingiem |
| [5.7 Scaling](./mcp-scaling/README.md) | Skalowanie | Dowiedz się o skalowaniu |
| [5.8 Security](./mcp-security/README.md) | Bezpieczeństwo | Zabezpiecz swój MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Pythonowy serwer i klient MCP integrujący się z SerpAPI do wyszukiwania w czasie rzeczywistym w sieci, wiadomości, produktów oraz Q&A. Demonstruje orkiestrację wielu narzędzi, integrację z zewnętrznymi API oraz solidne zarządzanie błędami. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming danych w czasie rzeczywistym stał się niezbędny w dzisiejszym świecie opartym na danych, gdzie firmy i aplikacje wymagają natychmiastowego dostępu do informacji, aby podejmować szybkie decyzje. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Wyszukiwanie w czasie rzeczywistym | Jak MCP zmienia wyszukiwanie w czasie rzeczywistym, oferując ustandaryzowane podejście do zarządzania kontekstem między modelami AI, wyszukiwarkami i aplikacjami. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Uwierzytelnianie Entra ID | Microsoft Entra ID zapewnia solidne, oparte na chmurze rozwiązanie do zarządzania tożsamością i dostępem, pomagając zapewnić, że tylko uprawnieni użytkownicy i aplikacje mogą komunikować się z Twoim serwerem MCP. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Integracja Azure AI Foundry | Dowiedz się, jak integrować serwery Model Context Protocol z agentami Azure AI Foundry, umożliwiając potężną orkiestrację narzędzi i możliwości AI w przedsiębiorstwach dzięki ustandaryzowanym połączeniom z zewnętrznymi źródłami danych. |

## Dodatkowe odniesienia

Aby uzyskać najnowsze informacje na temat zaawansowanych tematów MCP, zapoznaj się z:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Kluczowe wnioski

- Implementacje MCP multimodalnego rozszerzają możliwości AI poza przetwarzanie tekstu
- Skalowalność jest niezbędna dla wdrożeń korporacyjnych i można ją osiągnąć poprzez skalowanie poziome i pionowe
- Kompleksowe środki bezpieczeństwa chronią dane i zapewniają właściwą kontrolę dostępu
- Integracja korporacyjna z platformami takimi jak Azure OpenAI i Microsoft AI Foundry wzmacnia możliwości MCP
- Zaawansowane implementacje MCP korzystają z zoptymalizowanych architektur i starannego zarządzania zasobami

## Ćwiczenie

Zaprojektuj implementację MCP na poziomie korporacyjnym dla konkretnego przypadku użycia:

1. Określ wymagania multimodalne dla swojego przypadku użycia
2. Nakreśl środki bezpieczeństwa potrzebne do ochrony danych wrażliwych
3. Zaprojektuj skalowalną architekturę zdolną do obsługi zmiennego obciążenia
4. Zaplanuj punkty integracji z korporacyjnymi systemami AI
5. Udokumentuj potencjalne wąskie gardła wydajności i strategie ich łagodzenia

## Dodatkowe zasoby

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Co dalej

- [5.1 MCP Integration](./mcp-integration/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.