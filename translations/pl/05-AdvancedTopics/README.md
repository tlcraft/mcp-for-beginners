<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T15:33:20+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "pl"
}
-->
# Zaawansowane tematy w MCP

Ten rozdział ma na celu omówienie szeregu zaawansowanych zagadnień związanych z implementacją Model Context Protocol (MCP), w tym integracji multi-modalnej, skalowalności, najlepszych praktyk bezpieczeństwa oraz integracji korporacyjnej. Tematy te są kluczowe dla budowania solidnych i gotowych do produkcji aplikacji MCP, które sprostają wymaganiom nowoczesnych systemów AI.

## Przegląd

Ta lekcja bada zaawansowane koncepcje implementacji Model Context Protocol, koncentrując się na integracji multi-modalnej, skalowalności, najlepszych praktykach bezpieczeństwa oraz integracji korporacyjnej. Tematy te są niezbędne do tworzenia aplikacji MCP na poziomie produkcyjnym, które radzą sobie z złożonymi wymaganiami w środowiskach korporacyjnych.

## Cele nauki

Po ukończeniu tej lekcji będziesz potrafił:

- Wdrażać możliwości multi-modalne w ramach MCP
- Projektować skalowalne architektury MCP na potrzeby scenariuszy o dużym obciążeniu
- Stosować najlepsze praktyki bezpieczeństwa zgodne z zasadami bezpieczeństwa MCP
- Integracja MCP z systemami i frameworkami AI w przedsiębiorstwach
- Optymalizować wydajność i niezawodność w środowiskach produkcyjnych

## Lekcje i przykładowe projekty

| Link | Tytuł | Opis |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integracja z Azure | Naucz się, jak integrować swój serwer MCP na platformie Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Przykłady MCP Multi modal | Przykłady odpowiedzi audio, obrazów i multi-modalnych |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Demo MCP OAuth2 | Minimalna aplikacja Spring Boot pokazująca OAuth2 z MCP, zarówno jako Authorization, jak i Resource Server. Demonstruje bezpieczne wydawanie tokenów, chronione endpointy, wdrożenie w Azure Container Apps oraz integrację z API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Dowiedz się więcej o root context i jak je implementować |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Poznaj różne typy routingu |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naucz się pracy z samplingiem |
| [5.7 Scaling](./mcp-scaling/README.md) | Skalowanie | Poznaj zagadnienia skalowania |
| [5.8 Security](./mcp-security/README.md) | Bezpieczeństwo | Zabezpiecz swój serwer MCP |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Serwer i klient MCP w Pythonie integrujący się z SerpAPI do wyszukiwania w czasie rzeczywistym w sieci, wiadomościach, produktach i Q&A. Demonstruje orkiestrację wielu narzędzi, integrację z zewnętrznymi API oraz solidne zarządzanie błędami. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Transmisja danych w czasie rzeczywistym stała się niezbędna w dzisiejszym świecie opartym na danych, gdzie firmy i aplikacje wymagają natychmiastowego dostępu do informacji, aby podejmować szybkie decyzje. |

## Dodatkowe źródła

Aby uzyskać najnowsze informacje na temat zaawansowanych tematów MCP, zapoznaj się z:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Najważniejsze wnioski

- Implementacje MCP multi-modal rozszerzają możliwości AI poza przetwarzanie tekstu
- Skalowalność jest kluczowa dla wdrożeń korporacyjnych i można ją osiągnąć przez skalowanie poziome i pionowe
- Kompleksowe środki bezpieczeństwa chronią dane i zapewniają właściwą kontrolę dostępu
- Integracja korporacyjna z platformami takimi jak Azure OpenAI i Microsoft AI Foundry wzmacnia możliwości MCP
- Zaawansowane implementacje MCP korzystają z zoptymalizowanych architektur i starannego zarządzania zasobami

## Ćwiczenie

Zaprojektuj implementację MCP na poziomie korporacyjnym dla konkretnego przypadku użycia:

1. Określ wymagania multi-modalne dla swojego przypadku użycia
2. Nakreśl kontrole bezpieczeństwa potrzebne do ochrony wrażliwych danych
3. Zaprojektuj skalowalną architekturę zdolną do obsługi zmiennego obciążenia
4. Zaplanuj punkty integracji z korporacyjnymi systemami AI
5. Udokumentuj potencjalne wąskie gardła wydajności oraz strategie ich łagodzenia

## Dodatkowe zasoby

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Co dalej

- [5.1 MCP Integration](./mcp-integration/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym powinien być traktowany jako źródło autorytatywne. W przypadku istotnych informacji zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.