<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b96f2864e0bcb6fae9b4926813c3feb1",
  "translation_date": "2025-06-26T13:58:32+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "pl"
}
-->
# Zaawansowane tematy w MCP

Ten rozdział ma na celu omówienie szeregu zaawansowanych zagadnień związanych z implementacją Model Context Protocol (MCP), w tym integracji multimodalnej, skalowalności, najlepszych praktyk bezpieczeństwa oraz integracji korporacyjnej. Tematy te są kluczowe dla tworzenia solidnych i gotowych do produkcji aplikacji MCP, które sprostają wymaganiom nowoczesnych systemów AI.

## Przegląd

Ta lekcja bada zaawansowane koncepcje implementacji Model Context Protocol, skupiając się na integracji multimodalnej, skalowalności, najlepszych praktykach bezpieczeństwa oraz integracji korporacyjnej. Tematy te są niezbędne do tworzenia aplikacji MCP na poziomie produkcyjnym, które radzą sobie z złożonymi wymaganiami w środowiskach korporacyjnych.

## Cele nauki

Po ukończeniu tej lekcji będziesz potrafił:

- Wdrażać możliwości multimodalne w ramach MCP
- Projektować skalowalne architektury MCP na potrzeby scenariuszy o dużym zapotrzebowaniu
- Stosować najlepsze praktyki bezpieczeństwa zgodne z zasadami MCP
- Integracja MCP z systemami i frameworkami AI w przedsiębiorstwach
- Optymalizować wydajność i niezawodność w środowiskach produkcyjnych

## Lekcje i przykładowe projekty

| Link | Tytuł | Opis |
|------|-------|------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integracja z Azure | Naucz się, jak zintegrować swój MCP Server na platformie Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Przykłady MCP multimodalnych | Przykłady dla audio, obrazów oraz odpowiedzi multimodalnych |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Demo MCP OAuth2 | Minimalna aplikacja Spring Boot pokazująca OAuth2 z MCP, zarówno jako Authorization, jak i Resource Server. Demonstruje bezpieczne wydawanie tokenów, chronione endpointy, wdrożenie na Azure Container Apps oraz integrację z API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Dowiedz się więcej o root context i jak je zaimplementować |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Poznaj różne typy routingu |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naucz się, jak pracować z samplingiem |
| [5.7 Scaling](./mcp-scaling/README.md) | Skalowanie | Poznaj zagadnienia związane ze skalowaniem |
| [5.8 Security](./mcp-security/README.md) | Bezpieczeństwo | Zabezpiecz swój MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Serwer i klient MCP w Pythonie integrujący się z SerpAPI do wyszukiwania w czasie rzeczywistym: strony internetowe, wiadomości, produkty i Q&A. Demonstruje orkiestrację wielu narzędzi, integrację z zewnętrznymi API oraz solidne zarządzanie błędami. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming danych w czasie rzeczywistym stał się niezbędny w dzisiejszym świecie opartym na danych, gdzie firmy i aplikacje potrzebują natychmiastowego dostępu do informacji, aby podejmować szybkie decyzje. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Wyszukiwanie internetowe w czasie rzeczywistym – jak MCP zmienia podejście do zarządzania kontekstem w czasie rzeczywistym pomiędzy modelami AI, wyszukiwarkami i aplikacjami. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID Authentication | Microsoft Entra ID oferuje solidne, oparte na chmurze rozwiązanie do zarządzania tożsamością i dostępem, które pomaga zapewnić, że tylko uprawnieni użytkownicy i aplikacje mogą komunikować się z Twoim serwerem MCP. |

## Dodatkowe materiały

Dla najbardziej aktualnych informacji na temat zaawansowanych tematów MCP, zapoznaj się z:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Kluczowe wnioski

- Implementacje MCP z multimodalnością rozszerzają możliwości AI poza przetwarzanie tekstu
- Skalowalność jest kluczowa dla wdrożeń korporacyjnych i można ją osiągnąć przez skalowanie poziome i pionowe
- Kompleksowe środki bezpieczeństwa chronią dane i zapewniają odpowiednią kontrolę dostępu
- Integracja korporacyjna z platformami takimi jak Azure OpenAI i Microsoft AI Foundry wzmacnia możliwości MCP
- Zaawansowane implementacje MCP korzystają z zoptymalizowanych architektur i starannego zarządzania zasobami

## Ćwiczenie

Zaprojektuj implementację MCP na poziomie korporacyjnym dla konkretnego przypadku użycia:

1. Zidentyfikuj wymagania multimodalne dla swojego przypadku użycia
2. Nakreśl środki bezpieczeństwa potrzebne do ochrony danych wrażliwych
3. Zaprojektuj skalowalną architekturę, która poradzi sobie z różnym obciążeniem
4. Zaplanuj punkty integracji z korporacyjnymi systemami AI
5. Udokumentuj potencjalne wąskie gardła wydajności oraz strategie ich łagodzenia

## Dodatkowe zasoby

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Co dalej

- [5.1 MCP Integration](./mcp-integration/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczeń AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dążymy do dokładności, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być traktowany jako źródło wiążące. W przypadku informacji o istotnym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.