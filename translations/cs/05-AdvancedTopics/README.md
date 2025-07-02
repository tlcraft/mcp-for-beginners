<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T09:50:55+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "cs"
}
-->
# Pokročilá témata v MCP

Tato kapitola je zaměřena na řadu pokročilých témat v implementaci Model Context Protocol (MCP), včetně multimodální integrace, škálovatelnosti, bezpečnostních osvědčených postupů a integrace do podnikových systémů. Tato témata jsou klíčová pro tvorbu robustních a produkčně připravených MCP aplikací, které dokážou splnit požadavky moderních AI systémů.

## Přehled

Tato lekce se zabývá pokročilými koncepty implementace Model Context Protocol, se zaměřením na multimodální integraci, škálovatelnost, bezpečnostní osvědčené postupy a integraci do podnikových systémů. Tato témata jsou nezbytná pro vytváření produkčních MCP aplikací, které zvládnou složité požadavky v podnikových prostředích.

## Výukové cíle

Na konci této lekce budete schopni:

- Implementovat multimodální funkce v rámci MCP frameworků
- Navrhnout škálovatelné MCP architektury pro náročné scénáře
- Aplikovat bezpečnostní osvědčené postupy v souladu s bezpečnostními principy MCP
- Integrovat MCP s podnikových AI systémy a frameworky
- Optimalizovat výkon a spolehlivost v produkčním prostředí

## Lekce a ukázkové projekty

| Odkaz | Název | Popis |
|-------|-------|-------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrace s Azure | Naučte se, jak integrovat svůj MCP Server na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodální ukázky | Ukázky pro audio, obrázky a multimodální odpovědi |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalistická Spring Boot aplikace ukazující OAuth2 s MCP, jak jako Authorization, tak Resource Server. Demonstruje bezpečné vydávání tokenů, chráněné endpointy, nasazení na Azure Container Apps a integraci s API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexty | Dozvíte se více o root contextu a jak jej implementovat |
| [5.5 Routing](./mcp-routing/README.md) | Směrování | Naučte se různé typy směrování |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naučte se pracovat se samplingem |
| [5.7 Scaling](./mcp-scaling/README.md) | Škálování | Naučte se o škálování |
| [5.8 Security](./mcp-security/README.md) | Bezpečnost | Zabezpečte svůj MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server a klient integrující SerpAPI pro vyhledávání na webu, v novinkách, produktech a Q&A v reálném čase. Demonstruje orchestraci více nástrojů, integraci externích API a robustní zpracování chyb. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming dat v reálném čase se stal nezbytností v dnešním světě řízeném daty, kde firmy a aplikace potřebují okamžitý přístup k informacím pro včasná rozhodnutí. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Webové vyhledávání | Jak MCP mění vyhledávání na webu v reálném čase tím, že poskytuje standardizovaný přístup k řízení kontextu napříč AI modely, vyhledávači a aplikacemi. |
| [5.12 Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID autentizace | Microsoft Entra ID nabízí robustní cloudové řešení pro správu identit a přístupů, které pomáhá zajistit, že pouze autorizovaní uživatelé a aplikace mohou komunikovat s vaším MCP serverem. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Integrace Azure AI Foundry | Naučte se, jak integrovat Model Context Protocol servery s Azure AI Foundry agenty, což umožňuje výkonnou orchestraci nástrojů a podnikové AI schopnosti se standardizovanými připojeními na externí zdroje dat. |

## Další odkazy

Pro nejaktuálnější informace o pokročilých tématech MCP se podívejte na:
- [MCP Dokumentace](https://modelcontextprotocol.io/)
- [MCP Specifikace](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Hlavní poznatky

- Multimodální implementace MCP rozšiřují AI schopnosti nad rámec zpracování textu
- Škálovatelnost je klíčová pro podniková nasazení a lze ji řešit horizontálním i vertikálním škálováním
- Komplexní bezpečnostní opatření chrání data a zajišťují správnou kontrolu přístupu
- Podniková integrace s platformami jako Azure OpenAI a Microsoft AI Foundry rozšiřuje možnosti MCP
- Pokročilé MCP implementace profitují z optimalizovaných architektur a pečlivého řízení zdrojů

## Cvičení

Navrhněte MCP implementaci na úrovni podniku pro konkrétní případ použití:

1. Identifikujte multimodální požadavky pro váš případ použití
2. Nastavte bezpečnostní opatření potřebná k ochraně citlivých dat
3. Navrhněte škálovatelnou architekturu schopnou zvládat proměnlivou zátěž
4. Naplánujte integrační body s podnikových AI systémy
5. Zdokumentujte možné výkonnostní úzká místa a strategie jejich řešení

## Další zdroje

- [Azure OpenAI Dokumentace](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Dokumentace](https://learn.microsoft.com/en-us/ai-services/)

---

## Co dál

- [5.1 MCP Integration](./mcp-integration/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo mylné výklady vyplývající z použití tohoto překladu.