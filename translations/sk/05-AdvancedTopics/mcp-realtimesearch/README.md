<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "16bef2c93c6a86d4ca6a8ce9e120e384",
  "translation_date": "2025-06-13T03:01:05+00:00",
  "source_file": "05-AdvancedTopics/mcp-realtimesearch/README.md",
  "language_code": "sk"
}
-->
## Zrieknutie zodpovednosti k príkladom kódu

> **Dôležitá poznámka**: Nižšie uvedené príklady kódu demonštrujú integráciu Model Context Protocol (MCP) s funkciami webového vyhľadávania. Aj keď nasledujú vzory a štruktúry oficiálnych MCP SDK, boli zjednodušené pre vzdelávacie účely.
> 
> Tieto príklady ukazujú:
> 
> 1. **Implementácia v Pythone**: Implementáciu FastMCP servera, ktorý poskytuje nástroj na webové vyhľadávanie a pripája sa k externému vyhľadávaciemu API. Tento príklad demonštruje správu životného cyklu, spracovanie kontextu a implementáciu nástroja podľa vzorov [oficiálneho MCP Python SDK](https://github.com/modelcontextprotocol/python-sdk). Server používa odporúčaný transport Streamable HTTP, ktorý nahradil starší SSE transport pre produkčné nasadenia.
> 
> 2. **Implementácia v JavaScripte**: Implementáciu v TypeScripte/JavaScripte využívajúcu FastMCP vzor z [oficiálneho MCP TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) na vytvorenie vyhľadávacieho servera so správnymi definíciami nástrojov a klientskymi pripojeniami. Nasleduje najnovšie odporúčané vzory pre správu relácií a uchovávanie kontextu.
> 
> Tieto príklady by v produkčnom nasadení vyžadovali ďalšie spracovanie chýb, autentifikáciu a špecifickú integráciu API. Ukázané vyhľadávacie API koncové body (`https://api.search-service.example/search`) sú zástupné a musia byť nahradené skutočnými koncovými bodmi vyhľadávacích služieb.
> 
> Pre kompletné implementačné detaily a najaktuálnejšie prístupy sa prosím obráťte na [oficiálnu špecifikáciu MCP](https://spec.modelcontextprotocol.io/) a dokumentáciu SDK.

## Základné koncepty

### Rámec Model Context Protocol (MCP)

Na svojej podstate poskytuje Model Context Protocol štandardizovaný spôsob, ako si AI modely, aplikácie a služby vymieňajú kontext. V reálnom čase pri webovom vyhľadávaní je tento rámec nevyhnutný pre vytvorenie koherentných, viackolových vyhľadávacích zážitkov. Kľúčové komponenty zahŕňajú:

1. **Klient-server architektúra**: MCP zavádza jasné oddelenie medzi vyhľadávacími klientmi (žiadateľmi) a vyhľadávacími servermi (poskytovateľmi), čo umožňuje flexibilné modely nasadenia.

2. **Komunikácia JSON-RPC**: Protokol používa JSON-RPC na výmenu správ, vďaka čomu je kompatibilný s webovými technológiami a ľahko implementovateľný na rôznych platformách.

3. **Správa kontextu**: MCP definuje štruktúrované metódy na udržiavanie, aktualizáciu a využívanie vyhľadávacieho kontextu počas viacerých interakcií.

4. **Definície nástrojov**: Vyhľadávacie schopnosti sú vystavené ako štandardizované nástroje s presne definovanými parametrami a návratovými hodnotami.

5. **Podpora streamovania**: Protokol podporuje streamovanie výsledkov, čo je kľúčové pre reálne časové vyhľadávanie, kde výsledky môžu prichádzať postupne.

### Vzory integrácie webového vyhľadávania

Pri integrácii MCP s webovým vyhľadávaním sa objavuje niekoľko vzorov:

#### 1. Priama integrácia poskytovateľa vyhľadávania

```mermaid
graph LR
    Client[MCP Client] --> |MCP Request| Server[MCP Server]
    Server --> |API Call| SearchAPI[Search API]
    SearchAPI --> |Results| Server
    Server --> |MCP Response| Client
```

V tomto vzore MCP server priamo komunikuje s jedným alebo viacerými vyhľadávacími API, prekladá MCP požiadavky do API špecifických volaní a formátuje výsledky ako MCP odpovede.

#### 2. Federované vyhľadávanie s uchovaním kontextu

```mermaid
graph LR
    Client[MCP Client] --> |MCP Request| Federation[MCP Federation Layer]
    Federation --> |MCP Request 1| Search1[Search Provider 1]
    Federation --> |MCP Request 2| Search2[Search Provider 2]
    Federation --> |MCP Request 3| Search3[Search Provider 3]
    Search1 --> |MCP Response 1| Federation
    Search2 --> |MCP Response 2| Federation
    Search3 --> |MCP Response 3| Federation
    Federation --> |Aggregated MCP Response| Client
```

Tento vzor rozdeľuje vyhľadávacie dotazy medzi viacerých MCP-kompatibilných poskytovateľov vyhľadávania, z ktorých každý sa môže špecializovať na rôzne typy obsahu alebo vyhľadávacie schopnosti, pričom sa zachováva jednotný kontext.

#### 3. Vyhľadávací reťazec s obohateným kontextom

```mermaid
graph LR
    Client[MCP Client] --> |Query + Context| Server[MCP Server]
    Server --> |1. Query Analysis| NLP[NLP Service]
    NLP --> |Enhanced Query| Server
    Server --> |2. Search Execution| Search[Search Engine]
    Search --> |Raw Results| Server
    Server --> |3. Result Processing| Enhancement[Result Enhancement]
    Enhancement --> |Enhanced Results| Server
    Server --> |Final Results + Updated Context| Client
```

V tomto vzore je vyhľadávací proces rozdelený do viacerých fáz, pričom sa kontext na každom kroku obohacuje, čo vedie k postupne relevantnejším výsledkom.

### Komponenty vyhľadávacieho kontextu

V MCP založenom webovom vyhľadávaní kontext zvyčajne obsahuje:

- **Históriu dotazov**: Predchádzajúce vyhľadávacie dotazy v rámci relácie
- **Preferencie používateľa**: Jazyk, región, nastavenia bezpečného vyhľadávania
- **Históriu interakcií**: Ktoré výsledky boli kliknuté, čas strávený pri výsledkoch
- **Parametre vyhľadávania**: Filtre, poradie zoradenia a ďalšie modifikátory vyhľadávania
- **Doménové znalosti**: Kontext špecifický pre predmet vyhľadávania
- **Časový kontext**: Faktory relevantnosti založené na čase
- **Preferencie zdrojov**: Dôveryhodné alebo preferované informačné zdroje

## Použitie a aplikácie

### Výskum a zhromažďovanie informácií

MCP zlepšuje výskumné pracovné postupy tým, že:

- Uchováva výskumný kontext počas vyhľadávacích relácií
- Umožňuje sofistikovanejšie a kontextovo relevantné dotazy
- Podporuje federované vyhľadávanie z viacerých zdrojov
- Uľahčuje extrakciu poznatkov z výsledkov vyhľadávania

### Monitorovanie noviniek a trendov v reálnom čase

Vyhľadávanie poháňané MCP ponúka výhody pre sledovanie správ:

- Objavovanie nových správ takmer v reálnom čase
- Kontextové filtrovanie relevantných informácií
- Sledovanie tém a entít naprieč viacerými zdrojmi
- Personalizované upozornenia na správy založené na používateľskom kontexte

### AI-podporované prehliadanie a výskum

MCP otvára nové možnosti pre AI-podporované prehliadanie:

- Kontextové návrhy vyhľadávania založené na aktuálnej aktivite prehliadača
- Bezproblémová integrácia webového vyhľadávania s asistentmi poháňanými LLM
- Viackolové doladenie vyhľadávania s uchovaným kontextom
- Vylepšené overovanie faktov a verifikácia informácií

## Budúce trendy a inovácie

### Vývoj MCP vo webovom vyhľadávaní

Do budúcnosti očakávame, že MCP bude riešiť:

- **Multimodálne vyhľadávanie**: Integrácia textového, obrazového, audio a video vyhľadávania s uchovaným kontextom
- **Decentralizované vyhľadávanie**: Podpora distribuovaných a federovaných vyhľadávacích ekosystémov
- **Súkromie vo vyhľadávaní**: Kontextovo uvedomelé mechanizmy ochrany súkromia pri vyhľadávaní
- **Porozumenie dotazom**: Hlboké sémantické spracovanie prirodzených jazykových vyhľadávacích dotazov

### Potenciálne technologické pokroky

Nové technológie, ktoré ovplyvnia budúcnosť MCP vyhľadávania:

1. **Neurónové vyhľadávacie architektúry**: Vyhľadávacie systémy založené na embeddingoch optimalizované pre MCP
2. **Personalizovaný vyhľadávací kontext**: Učenie sa individuálnych vzorcov vyhľadávania používateľa v čase
3. **Integrácia znalostných grafov**: Kontextové vyhľadávanie vylepšené doménovo špecifickými znalostnými grafmi
4. **Krosmodálny kontext**: Uchovávanie kontextu naprieč rôznymi modalitami vyhľadávania

## Praktické cvičenia

### Cvičenie 1: Nastavenie základného MCP vyhľadávacieho pipeline

V tomto cvičení sa naučíte:
- Konfigurovať základné MCP vyhľadávacie prostredie
- Implementovať spracovanie kontextu pre webové vyhľadávanie
- Testovať a overovať uchovanie kontextu počas viacerých vyhľadávacích iterácií

### Cvičenie 2: Vytvorenie výskumného asistenta s MCP vyhľadávaním

Vytvorte kompletnú aplikáciu, ktorá:
- Spracováva výskumné otázky v prirodzenom jazyku
- Vykonáva kontextovo uvedomelé webové vyhľadávanie
- Synthesizuje informácie z viacerých zdrojov
- Predstavuje organizované výskumné výsledky

### Cvičenie 3: Implementácia federovaného vyhľadávania z viacerých zdrojov s MCP

Pokročilé cvičenie pokrývajúce:
- Kontextovo uvedomelé smerovanie dotazov do viacerých vyhľadávacích motorov
- Zoradenie a agregáciu výsledkov
- Kontextovú deduplikáciu výsledkov vyhľadávania
- Spracovanie metadát špecifických pre zdroj

## Dodatočné zdroje

- [Model Context Protocol Specification](https://spec.modelcontextprotocol.io/) - Oficiálna špecifikácia MCP a podrobná dokumentácia protokolu
- [Model Context Protocol Documentation](https://modelcontextprotocol.io/) - Podrobné návody a implementačné príručky
- [MCP Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Oficiálna Python implementácia MCP protokolu
- [MCP TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Oficiálna TypeScript implementácia MCP protokolu
- [MCP Reference Servers](https://github.com/modelcontextprotocol/servers) - Referenčné implementácie MCP serverov
- [Bing Web Search API Documentation](https://learn.microsoft.com/en-us/bing/search-apis/bing-web-search/overview) - Microsoft API pre webové vyhľadávanie
- [Google Custom Search JSON API](https://developers.google.com/custom-search/v1/overview) - Programovateľný vyhľadávací engine Google
- [SerpAPI Documentation](https://serpapi.com/search-api) - API pre výsledky vyhľadávača
- [Meilisearch Documentation](https://www.meilisearch.com/docs) - Open-source vyhľadávací engine
- [Elasticsearch Documentation](https://www.elastic.co/guide/index.html) - Distribuovaný vyhľadávací a analytický engine
- [LangChain Documentation](https://python.langchain.com/docs/get_started/introduction) - Tvorba aplikácií s LLM

## Výsledky učenia

Po absolvovaní tohto modulu budete schopní:

- Pochopiť základy reálneho časového webového vyhľadávania a jeho výzvy
- Vysvetliť, ako Model Context Protocol (MCP) zlepšuje schopnosti reálneho časového webového vyhľadávania
- Implementovať MCP-založené vyhľadávacie riešenia pomocou populárnych frameworkov a API
- Navrhovať a nasadzovať škálovateľné, vysoko výkonné vyhľadávacie architektúry s MCP
- Aplikovať koncepty MCP na rôzne použitia vrátane sémantického vyhľadávania, výskumných asistentov a AI-podporovaného prehliadania
- Hodnotiť nové trendy a budúce inovácie v MCP-založených vyhľadávacích technológiách

### Úvahy o dôvere a bezpečnosti

Pri implementácii MCP-založených riešení webového vyhľadávania majte na pamäti tieto dôležité zásady zo špecifikácie MCP:

1. **Súhlas a kontrola používateľa**: Používatelia musia výslovne súhlasiť a rozumieť všetkým prístupom k dátam a operáciám. Toto je obzvlášť dôležité pri implementáciách webového vyhľadávania, ktoré môžu pristupovať k externým dátovým zdrojom.

2. **Ochrana súkromia dát**: Zabezpečte primerané zaobchádzanie s vyhľadávacími dotazmi a výsledkami, najmä ak môžu obsahovať citlivé informácie. Implementujte vhodné prístupové kontroly na ochranu používateľských dát.

3. **Bezpečnosť nástrojov**: Implementujte správnu autorizáciu a validáciu pre vyhľadávacie nástroje, pretože predstavujú potenciálne bezpečnostné riziká cez spustenie ľubovoľného kódu. Popisy správania nástrojov by mali byť považované za nedôveryhodné, pokiaľ nie sú získané z dôveryhodného servera.

4. **Jasná dokumentácia**: Poskytnite jasnú dokumentáciu o schopnostiach, obmedzeniach a bezpečnostných aspektoch vašej MCP-založenej vyhľadávacej implementácie v súlade s pokynmi zo špecifikácie MCP.

5. **Robustné procesy súhlasu**: Vytvorte robustné toky súhlasu a autorizácie, ktoré jasne vysvetľujú, čo každý nástroj robí pred jeho povolením, obzvlášť pre nástroje, ktoré interagujú s externými webovými zdrojmi.

Pre kompletné informácie o bezpečnosti a dôvere MCP sa obráťte na [oficiálnu dokumentáciu](https://modelcontextprotocol.io/specification/2025-03-26#security-and-trust-%26-safety).

## Čo ďalej

- [6. Príspevky komunity](../../06-CommunityContributions/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.