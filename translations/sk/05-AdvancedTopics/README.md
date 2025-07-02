<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T09:52:25+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sk"
}
-->
# Pokročilé témy v MCP

Táto kapitola je určená na pokrytie série pokročilých tém v implementácii Model Context Protocol (MCP), vrátane multimodálnej integrácie, škálovateľnosti, najlepších bezpečnostných praktík a integrácie v podnikových prostrediach. Tieto témy sú kľúčové pre vytváranie robustných a produkčne pripravených MCP aplikácií, ktoré dokážu splniť požiadavky moderných AI systémov.

## Prehľad

Táto lekcia skúma pokročilé koncepty implementácie Model Context Protocol, so zameraním na multimodálnu integráciu, škálovateľnosť, najlepšie bezpečnostné postupy a integráciu v podnikových prostrediach. Témy sú nevyhnutné pre tvorbu produkčných MCP aplikácií, ktoré zvládnu zložité požiadavky v podnikových prostrediach.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Implementovať multimodálne schopnosti v rámci MCP frameworkov
- Navrhnúť škálovateľné MCP architektúry pre náročné scenáre
- Použiť najlepšie bezpečnostné postupy v súlade s bezpečnostnými princípmi MCP
- Integrovať MCP s podnikových AI systémami a frameworkami
- Optimalizovať výkon a spoľahlivosť v produkčných prostrediach

## Lekcie a ukážkové projekty

| Odkaz | Názov | Popis |
|-------|-------|-------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrácia s Azure | Naučte sa, ako integrovať svoj MCP Server na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodálne ukážky | Ukážky pre audio, obrázky a multimodálne odpovede |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimálna Spring Boot aplikácia ukazujúca OAuth2 s MCP, ako Authorization aj Resource Server. Demonštruje bezpečné vydávanie tokenov, chránené endpointy, nasadenie na Azure Container Apps a integráciu s API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root kontexty | Viac o root kontexte a ako ich implementovať |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Naučte sa rôzne typy routingu |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naučte sa pracovať so samplingom |
| [5.7 Scaling](./mcp-scaling/README.md) | Škálovanie | Naučte sa o škálovaní |
| [5.8 Security](./mcp-security/README.md) | Bezpečnosť | Zaistite bezpečnosť svojho MCP Servera |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server a klient integrujúci SerpAPI pre vyhľadávanie na webe, v správach, produktoch a Q&A v reálnom čase. Ukazuje multi-tool orchestráciu, integráciu externých API a robustné spracovanie chýb. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming dát v reálnom čase je dnes nevyhnutný v dátovo orientovanom svete, kde firmy a aplikácie potrebujú okamžitý prístup k informáciám pre rýchle rozhodovanie. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Reálne vyhľadávanie na webe a spôsob, akým MCP transformuje vyhľadávanie v reálnom čase cez štandardizovaný prístup k správe kontextu naprieč AI modelmi, vyhľadávačmi a aplikáciami. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID autentifikácia | Microsoft Entra ID poskytuje robustné cloudové riešenie správy identity a prístupu, ktoré zabezpečuje, že iba autorizovaní používatelia a aplikácie môžu komunikovať s vaším MCP serverom. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Integrácia Azure AI Foundry | Naučte sa, ako integrovať Model Context Protocol servery s Azure AI Foundry agentmi, čo umožňuje výkonnú orchestráciu nástrojov a podnikové AI schopnosti so štandardizovanými pripojeniami na externé zdroje dát. |

## Dodatočné odkazy

Pre najaktuálnejšie informácie o pokročilých témach MCP navštívte:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Kľúčové poznatky

- Multimodálne implementácie MCP rozširujú AI schopnosti za hranice spracovania textu
- Škálovateľnosť je nevyhnutná pre podnikové nasadenia a rieši sa horizontálnym a vertikálnym škálovaním
- Komplexné bezpečnostné opatrenia chránia dáta a zabezpečujú správnu kontrolu prístupu
- Podniková integrácia s platformami ako Azure OpenAI a Microsoft AI Foundry rozširuje schopnosti MCP
- Pokročilé MCP implementácie profitujú z optimalizovaných architektúr a starostlivého manažmentu zdrojov

## Cvičenie

Navrhnite podnikové MCP riešenie pre konkrétny prípad použitia:

1. Identifikujte multimodálne požiadavky pre váš prípad použitia
2. Nastavte bezpečnostné kontroly na ochranu citlivých údajov
3. Navrhnite škálovateľnú architektúru, ktorá zvládne meniacu sa záťaž
4. Naplánujte integračné body s podnikových AI systémami
5. Zdokumentujte potenciálne výkonnostné úzke miesta a stratégie ich riešenia

## Dodatočné zdroje

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Čo ďalej

- [5.1 MCP Integration](./mcp-integration/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, berte prosím na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.