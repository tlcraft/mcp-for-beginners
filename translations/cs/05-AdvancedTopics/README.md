<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b96f2864e0bcb6fae9b4926813c3feb1",
  "translation_date": "2025-06-26T14:18:23+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "cs"
}
-->
# Pokročilá témata v MCP

Tato kapitola se věnuje řadě pokročilých témat v implementaci Model Context Protocol (MCP), včetně multimodální integrace, škálovatelnosti, osvědčených bezpečnostních postupů a integrace do podnikových systémů. Tato témata jsou klíčová pro vytváření robustních a produkčně připravených aplikací MCP, které dokážou splnit požadavky moderních AI systémů.

## Přehled

Tato lekce zkoumá pokročilé koncepty implementace Model Context Protocol, se zaměřením na multimodální integraci, škálovatelnost, bezpečnostní osvědčené postupy a podnikové integrace. Tato témata jsou nezbytná pro vytváření produkčních aplikací MCP, které zvládnou složité požadavky v podnikových prostředích.

## Výukové cíle

Na konci této lekce budete schopni:

- Implementovat multimodální funkce v rámci MCP frameworků
- Navrhnout škálovatelné MCP architektury pro scénáře s vysokou zátěží
- Aplikovat bezpečnostní osvědčené postupy v souladu s bezpečnostními principy MCP
- Integrovat MCP s podnikových AI systémy a frameworky
- Optimalizovat výkon a spolehlivost v produkčním prostředí

## Lekce a ukázkové projekty

| Odkaz | Název | Popis |
|-------|-------|-------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrace s Azure | Naučte se, jak integrovat váš MCP Server na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodální ukázky | Ukázky pro audio, obraz a multimodální odpovědi |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 demo | Minimální Spring Boot aplikace ukazující OAuth2 s MCP, jak jako Authorization, tak Resource Server. Demonstruje bezpečné vydávání tokenů, chráněné endpointy, nasazení na Azure Container Apps a integraci s API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexty | Více o root contextu a jak jej implementovat |
| [5.5 Routing](./mcp-routing/README.md) | Směrování | Naučte se různé typy směrování |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naučte se pracovat se samplingem |
| [5.7 Scaling](./mcp-scaling/README.md) | Škálování | Naučte se o škálování |
| [5.8 Security](./mcp-security/README.md) | Bezpečnost | Zabezpečte svůj MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server a klient integrující SerpAPI pro vyhledávání na webu, v novinkách, produktech a Q&A v reálném čase. Ukazuje orchestrace více nástrojů, integraci externích API a robustní zpracování chyb. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming dat v reálném čase je dnes nezbytností, protože firmy a aplikace potřebují okamžitý přístup k informacím pro včasná rozhodnutí. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Jak MCP mění vyhledávání na webu v reálném čase tím, že poskytuje standardizovaný přístup ke správě kontextu napříč AI modely, vyhledávači a aplikacemi. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID autentizace | Microsoft Entra ID nabízí robustní cloudové řešení pro správu identity a přístupu, které pomáhá zajistit, že s vaším MCP serverem mohou komunikovat pouze autorizovaní uživatelé a aplikace. |

## Další odkazy

Pro nejaktuálnější informace o pokročilých tématech MCP navštivte:
- [MCP Dokumentace](https://modelcontextprotocol.io/)
- [MCP Specifikace](https://spec.modelcontextprotocol.io/)
- [GitHub Repozitář](https://github.com/modelcontextprotocol)

## Hlavní poznatky

- Multimodální implementace MCP rozšiřují schopnosti AI za hranice zpracování textu
- Škálovatelnost je klíčová pro podniková nasazení a řeší se horizontálním i vertikálním škálováním
- Komplexní bezpečnostní opatření chrání data a zajišťují správnou kontrolu přístupu
- Podniková integrace s platformami jako Azure OpenAI a Microsoft AI Foundry rozšiřuje možnosti MCP
- Pokročilé implementace MCP těží z optimalizovaných architektur a pečlivého řízení zdrojů

## Cvičení

Navrhněte podnikové řešení MCP pro konkrétní případ použití:

1. Identifikujte multimodální požadavky pro váš případ použití
2. Nastavte bezpečnostní opatření pro ochranu citlivých dat
3. Navrhněte škálovatelnou architekturu, která zvládne proměnlivou zátěž
4. Naplánujte integrační body s podnikových AI systémy
5. Zdokumentujte možné výkonnostní úzká místa a strategie jejich řešení

## Další zdroje

- [Azure OpenAI Dokumentace](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Dokumentace](https://learn.microsoft.com/en-us/ai-services/)

---

## Co bude dál

- [5.1 MCP Integrace](./mcp-integration/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje využít profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo chybné výklady vyplývající z použití tohoto překladu.