<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T19:30:56+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sk"
}
-->
# Pokročilé témy v MCP

Táto kapitola sa zaoberá sériou pokročilých tém v implementácii Model Context Protocol (MCP), vrátane multimodálnej integrácie, škálovateľnosti, najlepších bezpečnostných postupov a podnikovej integrácie. Témy sú kľúčové pre vytváranie robustných a produkčne pripravených MCP aplikácií, ktoré dokážu splniť požiadavky moderných AI systémov.

## Prehľad

Táto lekcia skúma pokročilé koncepty implementácie Model Context Protocol, so zameraním na multimodálnu integráciu, škálovateľnosť, bezpečnostné postupy a podnikové prepojenie. Tieto témy sú nevyhnutné pre vytváranie produkčných MCP aplikácií schopných zvládnuť zložité požiadavky v podnikových prostrediach.

## Ciele učenia

Na konci tejto lekcie budete vedieť:

- Implementovať multimodálne schopnosti v rámci MCP
- Navrhnúť škálovateľnú MCP architektúru pre náročné scenáre
- Použiť najlepšie bezpečnostné postupy v súlade s bezpečnostnými princípmi MCP
- Integrovať MCP s podnikový AI systémami a rámcami
- Optimalizovať výkon a spoľahlivosť v produkčnom prostredí

## Lekcie a ukážkové projekty

| Link | Názov | Popis |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrácia s Azure | Naučte sa, ako integrovať váš MCP Server na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodálne ukážky | Ukážky pre audio, obrázok a multimodálne odpovede |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalistická Spring Boot aplikácia ukazujúca OAuth2 s MCP, ako Autorizačný a Resource Server. Demonštruje bezpečné vydávanie tokenov, chránené endpointy, nasadenie v Azure Container Apps a integráciu API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root kontexty | Dozviete sa viac o root kontexte a ako ich implementovať |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Naučte sa rôzne typy routovania |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naučte sa pracovať so samplingom |
| [5.7 Scaling](./mcp-scaling/README.md) | Škálovanie | Naučte sa o škálovaní |
| [5.8 Security](./mcp-security/README.md) | Bezpečnosť | Zaistite bezpečnosť vášho MCP Servera |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server a klient integrujúci SerpAPI pre vyhľadávanie na webe, novinky, produkty a Q&A v reálnom čase. Demonštruje orchestráciu viacerých nástrojov, integráciu externých API a robustné spracovanie chýb. |

## Dodatočné odkazy

Pre najaktuálnejšie informácie o pokročilých témach MCP, pozrite si:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Kľúčové poznatky

- Multimodálne implementácie MCP rozširujú schopnosti AI za hranice spracovania textu
- Škálovateľnosť je nevyhnutná pre podnikové nasadenia a dá sa riešiť horizontálnym a vertikálnym škálovaním
- Komplexné bezpečnostné opatrenia chránia dáta a zabezpečujú správnu kontrolu prístupu
- Podniková integrácia s platformami ako Azure OpenAI a Microsoft AI Foundry zvyšuje možnosti MCP
- Pokročilé implementácie MCP profitujú z optimalizovaných architektúr a starostlivého manažmentu zdrojov

## Cvičenie

Navrhnite podnikový MCP systém pre konkrétny prípad použitia:

1. Identifikujte multimodálne požiadavky pre váš prípad použitia
2. Navrhnite bezpečnostné opatrenia na ochranu citlivých dát
3. Navrhnite škálovateľnú architektúru schopnú zvládnuť rôzne záťaže
4. Naplánujte integračné body s podnikový AI systémami
5. Zdokumentujte možné výkonnostné úzke miesta a stratégie ich riešenia

## Dodatočné zdroje

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Čo bude ďalej

- [5.1 MCP Integration](./mcp-integration/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.