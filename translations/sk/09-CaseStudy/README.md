<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6c11b6162171abc895ed75d1e0f368a3",
  "translation_date": "2025-06-20T19:10:47+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "sk"
}
-->
# MCP v praxi: Skutočné prípadové štúdie

Model Context Protocol (MCP) mení spôsob, akým AI aplikácie komunikujú s dátami, nástrojmi a službami. Táto sekcia predstavuje skutočné prípadové štúdie, ktoré ukazujú praktické využitie MCP v rôznych podnikových scenároch.

## Prehľad

Táto časť predstavuje konkrétne príklady implementácií MCP, zdôrazňujúc, ako organizácie využívajú tento protokol na riešenie zložitých obchodných výziev. Štúdiom týchto prípadových štúdií získate prehľad o všestrannosti, škálovateľnosti a praktických výhodách MCP v reálnych situáciách.

## Hlavné učebné ciele

Preskúmaním týchto prípadových štúdií budete:

- Rozumieť, ako možno MCP použiť na riešenie konkrétnych obchodných problémov
- Naučiť sa o rôznych integračných vzorcoch a architektonických prístupoch
- Spoznať osvedčené postupy pre implementáciu MCP v podnikových prostrediach
- Získať prehľad o výzvach a riešeniach, ktoré sa objavili pri reálnych implementáciách
- Identifikovať príležitosti na použitie podobných vzorcov vo vlastných projektoch

## Vybrané prípadové štúdie

### 1. [Azure AI Travel Agents – Referenčná implementácia](./travelagentsample.md)

Táto prípadová štúdia skúma komplexné referenčné riešenie od Microsoftu, ktoré ukazuje, ako vytvoriť viacagentovú aplikáciu na plánovanie ciest poháňanú AI pomocou MCP, Azure OpenAI a Azure AI Search. Projekt predstavuje:

- Orchestru viac agentov cez MCP
- Integráciu podnikových dát s Azure AI Search
- Bezpečnú a škálovateľnú architektúru využívajúcu Azure služby
- Rozšíriteľné nástroje s opakovane použiteľnými komponentmi MCP
- Konverzačný používateľský zážitok poháňaný Azure OpenAI

Architektúra a detaily implementácie poskytujú cenné poznatky o budovaní komplexných viacagentových systémov s MCP ako koordinačnou vrstvou.

### 2. [Aktualizácia položiek Azure DevOps z údajov YouTube](./UpdateADOItemsFromYT.md)

Táto prípadová štúdia ukazuje praktické využitie MCP na automatizáciu pracovných procesov. Demonštruje, ako možno MCP nástroje využiť na:

- Extrahovanie dát z online platforiem (YouTube)
- Aktualizáciu pracovných položiek v systémoch Azure DevOps
- Vytváranie opakovateľných automatizačných pracovných tokov
- Integráciu dát naprieč rôznymi systémami

Tento príklad ukazuje, že aj relatívne jednoduché implementácie MCP môžu priniesť významné zlepšenie efektivity automatizáciou rutinných úloh a zlepšením konzistencie dát medzi systémami.

## Záver

Tieto prípadové štúdie zdôrazňujú všestrannosť a praktické využitie Model Context Protocol v reálnych situáciách. Od komplexných viacagentových systémov po cielené automatizačné pracovné toky, MCP poskytuje štandardizovaný spôsob prepojenia AI systémov s nástrojmi a dátami, ktoré potrebujú na poskytovanie hodnoty.

Štúdiom týchto implementácií môžete získať poznatky o architektonických vzorcoch, stratégiách implementácie a osvedčených postupoch, ktoré môžete využiť vo vlastných MCP projektoch. Príklady ukazujú, že MCP nie je len teoretický rámec, ale praktické riešenie reálnych obchodných výziev.

## Dodatočné zdroje

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, berte prosím na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nezodpovedáme za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.