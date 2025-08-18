<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d204bc94ea6027d06a703b21b711ca57",
  "translation_date": "2025-08-18T15:27:57+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sk"
}
-->
# Pokročilé témy v MCP

[![Pokročilé MCP: Bezpečné, škálovateľné a multimodálne AI agenti](../../../translated_images/06.42259eaf91fccfc6d06ef1c126c9db04bbff9e5f60a87b782a2ec2616163142f.sk.png)](https://youtu.be/4yjmGvJzYdY)

_(Kliknite na obrázok vyššie pre zobrazenie videa k tejto lekcii)_

Táto kapitola pokrýva sériu pokročilých tém v implementácii Model Context Protocol (MCP), vrátane multimodálnej integrácie, škálovateľnosti, bezpečnostných osvedčených postupov a podnikovej integrácie. Tieto témy sú kľúčové pre vytváranie robustných a produkčne pripravených MCP aplikácií, ktoré dokážu splniť požiadavky moderných AI systémov.

## Prehľad

Táto lekcia skúma pokročilé koncepty v implementácii Model Context Protocol, so zameraním na multimodálnu integráciu, škálovateľnosť, bezpečnostné osvedčené postupy a podnikovú integráciu. Tieto témy sú nevyhnutné pre vytváranie produkčne pripravených MCP aplikácií, ktoré zvládnu komplexné požiadavky v podnikových prostrediach.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Implementovať multimodálne schopnosti v rámci MCP rámcov
- Navrhovať škálovateľné MCP architektúry pre vysoko náročné scenáre
- Aplikovať bezpečnostné osvedčené postupy v súlade s bezpečnostnými princípmi MCP
- Integrovať MCP s podnikovými AI systémami a rámcami
- Optimalizovať výkon a spoľahlivosť v produkčných prostrediach

## Lekcie a ukážkové projekty

| Odkaz | Názov | Popis |
|-------|-------|-------|
| [5.1 Integrácia s Azure](./mcp-integration/README.md) | Integrácia s Azure | Naučte sa, ako integrovať váš MCP server na Azure |
| [5.2 Multimodálna ukážka](./mcp-multi-modality/README.md) | MCP Multimodálne ukážky | Ukážky pre audio, obraz a multimodálne odpovede |
| [5.3 MCP OAuth2 ukážka](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalistická Spring Boot aplikácia ukazujúca OAuth2 s MCP, ako autorizačný aj zdrojový server. Demonštruje vydávanie bezpečných tokenov, chránené koncové body, nasadenie na Azure Container Apps a integráciu s API Management. |
| [5.4 Koreňové kontexty](./mcp-root-contexts/README.md) | Koreňové kontexty | Zistite viac o koreňových kontextoch a ako ich implementovať |
| [5.5 Smerovanie](./mcp-routing/README.md) | Smerovanie | Naučte sa rôzne typy smerovania |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naučte sa pracovať so samplingom |
| [5.7 Škálovanie](./mcp-scaling/README.md) | Škálovanie | Zistite viac o škálovaní |
| [5.8 Bezpečnosť](./mcp-security/README.md) | Bezpečnosť | Zabezpečte váš MCP server |
| [5.9 Ukážka webového vyhľadávania](./web-search-mcp/README.md) | Webové vyhľadávanie MCP | Python MCP server a klient integrujúci sa so SerpAPI pre vyhľadávanie na webe, v správach, produktoch a Q&A v reálnom čase. Demonštruje orchestráciu viacerých nástrojov, integráciu externých API a robustné spracovanie chýb. |
| [5.10 Streamovanie v reálnom čase](./mcp-realtimestreaming/README.md) | Streamovanie | Streamovanie dát v reálnom čase sa stalo nevyhnutnosťou v dnešnom dátovo orientovanom svete, kde podniky a aplikácie potrebujú okamžitý prístup k informáciám na prijímanie včasných rozhodnutí. |
| [5.11 Webové vyhľadávanie v reálnom čase](./mcp-realtimesearch/README.md) | Webové vyhľadávanie | Ako MCP transformuje webové vyhľadávanie v reálnom čase poskytovaním štandardizovaného prístupu k správe kontextu naprieč AI modelmi, vyhľadávačmi a aplikáciami. |
| [5.12 Entra ID autentifikácia pre MCP servery](./mcp-security-entra/README.md) | Entra ID autentifikácia | Microsoft Entra ID poskytuje robustné cloudové riešenie pre správu identity a prístupu, ktoré pomáha zabezpečiť, že s vaším MCP serverom môžu interagovať iba autorizovaní používatelia a aplikácie. |
| [5.13 Integrácia s Azure AI Foundry Agentom](./mcp-foundry-agent-integration/README.md) | Integrácia s Azure AI Foundry | Naučte sa, ako integrovať MCP servery s Azure AI Foundry agentmi, čo umožňuje výkonnú orchestráciu nástrojov a podnikové AI schopnosti so štandardizovanými pripojeniami k externým zdrojom dát. |
| [5.14 Kontextové inžinierstvo](./mcp-contextengineering/README.md) | Kontextové inžinierstvo | Budúce možnosti techník kontextového inžinierstva pre MCP servery, vrátane optimalizácie kontextu, dynamického manažmentu kontextu a stratégií pre efektívne prompt inžinierstvo v rámci MCP rámcov. |

## Ďalšie odkazy

Pre najaktuálnejšie informácie o pokročilých témach MCP si pozrite:
- [MCP Dokumentácia](https://modelcontextprotocol.io/)
- [MCP Špecifikácia](https://spec.modelcontextprotocol.io/)
- [GitHub Repozitár](https://github.com/modelcontextprotocol)

## Kľúčové poznatky

- Multimodálne implementácie MCP rozširujú schopnosti AI nad rámec spracovania textu
- Škálovateľnosť je nevyhnutná pre podnikové nasadenia a možno ju riešiť horizontálnym a vertikálnym škálovaním
- Komplexné bezpečnostné opatrenia chránia dáta a zabezpečujú správnu kontrolu prístupu
- Podniková integrácia s platformami ako Azure OpenAI a Microsoft AI Foundry zvyšuje schopnosti MCP
- Pokročilé implementácie MCP profitujú z optimalizovaných architektúr a starostlivého manažmentu zdrojov

## Cvičenie

Navrhnite podnikové riešenie MCP pre konkrétny prípad použitia:

1. Identifikujte multimodálne požiadavky pre váš prípad použitia
2. Načrtnite bezpečnostné opatrenia potrebné na ochranu citlivých údajov
3. Navrhnite škálovateľnú architektúru, ktorá zvládne meniace sa zaťaženie
4. Naplánujte integračné body s podnikovými AI systémami
5. Zdokumentujte potenciálne úzke miesta výkonu a stratégie na ich zmiernenie

## Ďalšie zdroje

- [Azure OpenAI Dokumentácia](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Dokumentácia](https://learn.microsoft.com/en-us/ai-services/)

---

## Čo ďalej

- [5.1 MCP Integrácia](./mcp-integration/README.md)

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.