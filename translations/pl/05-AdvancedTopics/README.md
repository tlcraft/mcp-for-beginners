<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T18:59:48+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "pl"
}
-->
# Zaawansowane tematy w MCP

Ten rozdział ma na celu omówienie szeregu zaawansowanych zagadnień związanych z implementacją Model Context Protocol (MCP), w tym integracji multimodalnej, skalowalności, najlepszych praktyk bezpieczeństwa oraz integracji korporacyjnej. Tematy te są kluczowe dla budowy solidnych i gotowych do produkcji aplikacji MCP, które sprostają wymaganiom nowoczesnych systemów AI.

## Przegląd

Ta lekcja bada zaawansowane koncepcje implementacji Model Context Protocol, koncentrując się na integracji multimodalnej, skalowalności, najlepszych praktykach bezpieczeństwa oraz integracji korporacyjnej. Tematy te są niezbędne do tworzenia aplikacji MCP na poziomie produkcyjnym, które potrafią sprostać złożonym wymaganiom w środowiskach korporacyjnych.

## Cele nauki

Po zakończeniu tej lekcji będziesz potrafił:

- Implementować możliwości multimodalne w ramach MCP
- Projektować skalowalne architektury MCP dla scenariuszy o dużym zapotrzebowaniu
- Stosować najlepsze praktyki bezpieczeństwa zgodne z zasadami bezpieczeństwa MCP
- Integrować MCP z korporacyjnymi systemami i frameworkami AI
- Optymalizować wydajność i niezawodność w środowiskach produkcyjnych

## Lekcje i przykładowe projekty

| Link | Tytuł | Opis |
|------|-------|------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integracja z Azure | Naucz się, jak integrować swój MCP Server na platformie Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Przykłady MCP multimodalnego | Przykłady odpowiedzi audio, obrazów i multimodalnych |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Demo MCP OAuth2 | Minimalna aplikacja Spring Boot pokazująca OAuth2 z MCP, zarówno jako Authorization, jak i Resource Server. Demonstruje bezpieczne wydawanie tokenów, chronione endpointy, wdrożenie na Azure Container Apps oraz integrację z API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Dowiedz się więcej o root context i jak je implementować |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Poznaj różne typy routingu |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naucz się, jak pracować z samplingiem |
| [5.7 Scaling](./mcp-scaling/README.md) | Skalowanie | Poznaj zasady skalowania |
| [5.8 Security](./mcp-security/README.md) | Bezpieczeństwo | Zabezpiecz swój MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Pythonowy serwer i klient MCP integrujący się z SerpAPI do wyszukiwania w czasie rzeczywistym w sieci, wiadomościach, produktach oraz Q&A. Demonstruje orkiestrację wielu narzędzi, integrację z zewnętrznymi API oraz solidne zarządzanie błędami. |

## Dodatkowe materiały

Aby uzyskać najnowsze informacje na temat zaawansowanych zagadnień MCP, zapoznaj się z:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Kluczowe wnioski

- Implementacje MCP multimodalnego rozszerzają możliwości AI poza przetwarzanie tekstu
- Skalowalność jest niezbędna w wdrożeniach korporacyjnych i można ją osiągnąć poprzez skalowanie poziome i pionowe
- Kompleksowe środki bezpieczeństwa chronią dane i zapewniają właściwą kontrolę dostępu
- Integracja korporacyjna z platformami takimi jak Azure OpenAI i Microsoft AI Foundry zwiększa możliwości MCP
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
Ten dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dążymy do dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uważany za autorytatywne źródło. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.