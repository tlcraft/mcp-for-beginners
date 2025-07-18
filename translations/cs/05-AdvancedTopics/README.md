<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a5c1d9e9856024d23da4a65a847c75ac",
  "translation_date": "2025-07-18T07:20:58+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "cs"
}
-->
# Pokročilá témata v MCP

Tato kapitola se zabývá řadou pokročilých témat v implementaci Model Context Protocol (MCP), včetně multimodální integrace, škálovatelnosti, osvědčených bezpečnostních postupů a integrace do podnikových systémů. Tato témata jsou klíčová pro vytváření robustních a produkčně připravených aplikací MCP, které dokážou splnit požadavky moderních AI systémů.

## Přehled

Tato lekce zkoumá pokročilé koncepty implementace Model Context Protocol, se zaměřením na multimodální integraci, škálovatelnost, bezpečnostní osvědčené postupy a integraci do podnikových prostředí. Tato témata jsou nezbytná pro vytváření produkčně připravených aplikací MCP, které zvládnou složité požadavky v podnikových prostředích.

## Cíle učení

Na konci této lekce budete schopni:

- Implementovat multimodální schopnosti v rámci MCP
- Navrhnout škálovatelné MCP architektury pro náročné scénáře
- Aplikovat bezpečnostní osvědčené postupy v souladu s bezpečnostními principy MCP
- Integrovat MCP s podnikových AI systémy a rámci
- Optimalizovat výkon a spolehlivost v produkčním prostředí

## Lekce a ukázkové projekty

| Odkaz | Název | Popis |
|-------|-------|-------|
| [5.1 Integrace s Azure](./mcp-integration/README.md) | Integrace s Azure | Naučte se, jak integrovat váš MCP Server na Azure |
| [5.2 Multimodální ukázka](./mcp-multi-modality/README.md) | MCP multimodální ukázky | Ukázky pro audio, obrázky a multimodální odpovědi |
| [5.3 MCP OAuth2 ukázka](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimální Spring Boot aplikace ukazující OAuth2 s MCP, jak jako Autorizační, tak i Resource Server. Demonstruje bezpečné vydávání tokenů, chráněné koncové body, nasazení na Azure Container Apps a integraci s API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexty | Více o root contextu a jak je implementovat |
| [5.5 Směrování](./mcp-routing/README.md) | Směrování | Naučte se různé typy směrování |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naučte se pracovat se samplingem |
| [5.7 Škálování](./mcp-scaling/README.md) | Škálování | Naučte se o škálování |
| [5.8 Bezpečnost](./mcp-security/README.md) | Bezpečnost | Zabezpečte svůj MCP Server |
| [5.9 Webové vyhledávání MCP](./web-search-mcp/README.md) | Webové vyhledávání MCP | Python MCP server a klient integrující SerpAPI pro vyhledávání na webu, zprávách, produktech a Q&A v reálném čase. Demonstruje orchestraci více nástrojů, integraci externích API a robustní zpracování chyb. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming dat v reálném čase se stal nezbytností v dnešním světě řízeném daty, kde firmy a aplikace potřebují okamžitý přístup k informacím pro včasná rozhodnutí. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Webové vyhledávání | Jak MCP mění vyhledávání na webu v reálném čase tím, že poskytuje standardizovaný přístup k řízení kontextu napříč AI modely, vyhledávači a aplikacemi. |
| [5.12 Entra ID autentizace pro Model Context Protocol servery](./mcp-security-entra/README.md) | Entra ID autentizace | Microsoft Entra ID nabízí robustní cloudové řešení pro správu identity a přístupu, které zajišťuje, že pouze autorizovaní uživatelé a aplikace mohou komunikovat s vaším MCP serverem. |
| [5.13 Integrace Azure AI Foundry agenta](./mcp-foundry-agent-integration/README.md) | Integrace Azure AI Foundry | Naučte se, jak integrovat Model Context Protocol servery s Azure AI Foundry agenty, což umožňuje výkonnou orchestraci nástrojů a podnikové AI schopnosti se standardizovanými připojeními k externím zdrojům dat. |
| [5.14 Context Engineering](./mcp-contextengineering/README.md) | Context Engineering | Budoucí příležitosti technik context engineering pro MCP servery, včetně optimalizace kontextu, dynamického řízení kontextu a strategií pro efektivní prompt engineering v rámci MCP. |

## Další odkazy

Pro nejaktuálnější informace o pokročilých tématech MCP navštivte:
- [MCP Dokumentace](https://modelcontextprotocol.io/)
- [MCP Specifikace](https://spec.modelcontextprotocol.io/)
- [GitHub Repozitář](https://github.com/modelcontextprotocol)

## Klíčové poznatky

- Multimodální implementace MCP rozšiřují AI schopnosti nad rámec zpracování textu
- Škálovatelnost je nezbytná pro podnikové nasazení a lze ji řešit horizontálním i vertikálním škálováním
- Komplexní bezpečnostní opatření chrání data a zajišťují správnou kontrolu přístupu
- Podniková integrace s platformami jako Azure OpenAI a Microsoft AI Foundry rozšiřuje možnosti MCP
- Pokročilé implementace MCP těží z optimalizovaných architektur a pečlivého řízení zdrojů

## Cvičení

Navrhněte podnikové řešení MCP pro konkrétní případ použití:

1. Identifikujte multimodální požadavky pro váš případ použití
2. Nastavte bezpečnostní opatření potřebná k ochraně citlivých dat
3. Navrhněte škálovatelnou architekturu, která zvládne proměnlivou zátěž
4. Naplánujte integrační body s podnikových AI systémy
5. Zdokumentujte možné výkonnostní úzká místa a strategie jejich řešení

## Další zdroje

- [Azure OpenAI Dokumentace](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Dokumentace](https://learn.microsoft.com/en-us/ai-services/)

---

## Co dál

- [5.1 MCP Integrace](./mcp-integration/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.