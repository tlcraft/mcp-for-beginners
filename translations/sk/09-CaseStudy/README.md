<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:43:31+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "sk"
}
-->
# Prípadová štúdia: Azure AI Travel Agents – Referenčná implementácia

## Prehľad

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) je komplexné referenčné riešenie vyvinuté spoločnosťou Microsoft, ktoré ukazuje, ako vytvoriť aplikáciu na plánovanie ciest poháňanú viacerými AI agentmi pomocou Model Context Protocol (MCP), Azure OpenAI a Azure AI Search. Tento projekt demonštruje osvedčené postupy pre koordináciu viacerých AI agentov, integráciu podnikových dát a poskytovanie bezpečnej, rozšíriteľnej platformy pre reálne scenáre.

## Kľúčové vlastnosti
- **Orchestrácia viacerých agentov:** Využíva MCP na koordináciu špecializovaných agentov (napr. agenti pre lety, hotely a itineráre), ktorí spolupracujú na riešení zložitých úloh plánovania ciest.
- **Integrácia podnikových dát:** Pripája sa na Azure AI Search a ďalšie podnikové zdroje dát, aby poskytol aktuálne a relevantné informácie pre cestovné odporúčania.
- **Bezpečná a škálovateľná architektúra:** Využíva Azure služby na autentifikáciu, autorizáciu a škálovateľné nasadenie, dodržiavajúc najlepšie bezpečnostné postupy pre podniky.
- **Rozšíriteľné nástroje:** Implementuje znovupoužiteľné MCP nástroje a šablóny promptov, čo umožňuje rýchlu adaptáciu na nové oblasti alebo obchodné požiadavky.
- **Používateľský zážitok:** Poskytuje konverzačné rozhranie, cez ktoré môžu používatelia komunikovať s cestovnými agentmi, poháňané Azure OpenAI a MCP.

## Architektúra
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Popis architektonického diagramu

Riešenie Azure AI Travel Agents je navrhnuté tak, aby bolo modulárne, škálovateľné a bezpečne integrovalo viacerých AI agentov a podnikové zdroje dát. Hlavné komponenty a tok dát sú nasledovné:

- **Používateľské rozhranie:** Používatelia komunikujú so systémom cez konverzačné UI (napr. webový chat alebo Teams bot), ktoré posiela používateľské otázky a prijíma cestovné odporúčania.
- **MCP Server:** Slúži ako centrálny koordinátor, ktorý prijíma vstupy od používateľa, spravuje kontext a koordinuje činnosť špecializovaných agentov (napr. FlightAgent, HotelAgent, ItineraryAgent) cez Model Context Protocol.
- **AI Agenti:** Každý agent je zodpovedný za konkrétnu oblasť (lety, hotely, itineráre) a je implementovaný ako MCP nástroj. Agent používa šablóny promptov a logiku na spracovanie požiadaviek a generovanie odpovedí.
- **Azure OpenAI Service:** Poskytuje pokročilé porozumenie a generovanie prirodzeného jazyka, čo umožňuje agentom interpretovať zámer používateľa a vytvárať konverzačné odpovede.
- **Azure AI Search & podnikové dáta:** Agenti vyhľadávajú v Azure AI Search a ďalších podnikových zdrojoch, aby získali aktuálne informácie o letoch, hoteloch a cestovných možnostiach.
- **Autentifikácia a bezpečnosť:** Integruje sa s Microsoft Entra ID pre bezpečnú autentifikáciu a aplikuje princíp minimálnych oprávnení na všetky zdroje.
- **Nasadenie:** Navrhnuté pre nasadenie na Azure Container Apps, čo zabezpečuje škálovateľnosť, monitorovanie a efektívnosť prevádzky.

Táto architektúra umožňuje plynulú orchestráciu viacerých AI agentov, bezpečnú integráciu podnikových dát a robustnú, rozšíriteľnú platformu pre budovanie špecifických AI riešení.

## Podrobný popis architektonického diagramu krok za krokom
Predstavte si, že plánujete veľkú cestu a máte tím odborných asistentov, ktorí vám pomáhajú s každým detailom. Systém Azure AI Travel Agents funguje podobne, využíva rôzne časti (ako členov tímu), z ktorých každý má svoju špecializovanú úlohu. Takto to všetko spolu funguje:

### Používateľské rozhranie (UI):
Predstavte si to ako recepciu vášho cestovného agenta. Tu vy (používateľ) kladiete otázky alebo zadávate požiadavky, napríklad „Nájdi mi let do Paríža.“ Môže to byť chatové okno na webe alebo v aplikácii na odosielanie správ.

### MCP Server (koordinátor):
MCP Server je ako manažér, ktorý počúva vašu požiadavku na recepcii a rozhoduje, ktorý špecialista by mal riešiť jednotlivé časti. Sleduje priebeh konverzácie a zabezpečuje, že všetko funguje hladko.

### AI Agenti (špecializovaní asistenti):
Každý agent je expert na určitú oblasť – jeden pozná všetko o letoch, druhý o hoteloch a ďalší o plánovaní itinerára. Keď požiadate o cestu, MCP Server posiela vašu požiadavku správnemu agentovi alebo agentom. Tí využívajú svoje znalosti a nástroje na nájdenie najlepších možností pre vás.

### Azure OpenAI Service (jazykový expert):
Je to ako mať jazykového experta, ktorý presne rozumie tomu, čo hovoríte, bez ohľadu na to, ako to poviete. Pomáha agentom pochopiť vaše požiadavky a odpovedať prirodzeným, konverzačným spôsobom.

### Azure AI Search & podnikové dáta (informačná knižnica):
Predstavte si obrovskú, aktuálnu knižnicu so všetkými najnovšími informáciami o cestovaní – letových poriadkoch, dostupnosti hotelov a podobne. Agenti túto knižnicu prehľadávajú, aby vám poskytli najpresnejšie odpovede.

### Autentifikácia a bezpečnosť (bezpečnostná služba):
Rovnako ako bezpečnostná služba kontroluje, kto môže vstúpiť do určitých priestorov, táto časť zabezpečuje, že len autorizované osoby a agenti majú prístup k citlivým informáciám. Chráni vaše dáta a súkromie.

### Nasadenie na Azure Container Apps (budova):
Všetci títo asistenti a nástroje spolupracujú v bezpečnej, škálovateľnej budove (v cloude). To znamená, že systém zvládne veľa používateľov naraz a je vždy pripravený, keď ho potrebujete.

## Ako to všetko spolu funguje:

Začnete otázkou na recepcii (UI).  
Manažér (MCP Server) rozhodne, ktorý špecialista (agent) vám pomôže.  
Špecialista využije jazykového experta (OpenAI), aby pochopil vašu požiadavku, a knižnicu (AI Search), aby našiel najlepšiu odpoveď.  
Bezpečnostná služba (autentifikácia) zabezpečí, že je všetko v poriadku.  
To všetko prebieha v spoľahlivej, škálovateľnej budove (Azure Container Apps), takže váš zážitok je plynulý a bezpečný.  
Táto spolupráca umožňuje systému rýchlo a bezpečne pomôcť s plánovaním vašej cesty, podobne ako tím odborných cestovných agentov pracujúcich v modernom kancelárskom prostredí!

## Technická implementácia
- **MCP Server:** Hostuje jadro orchestrácie, sprístupňuje nástroje agentov a spravuje kontext pre viacstupňové pracovné postupy plánovania ciest.
- **Agenti:** Každý agent (napr. FlightAgent, HotelAgent) je implementovaný ako MCP nástroj so svojimi šablónami promptov a logikou.
- **Integrácia Azure:** Využíva Azure OpenAI pre porozumenie prirodzenému jazyku a Azure AI Search pre získavanie dát.
- **Bezpečnosť:** Integruje sa s Microsoft Entra ID pre autentifikáciu a aplikuje princíp minimálnych oprávnení na všetky zdroje.
- **Nasadenie:** Podporuje nasadenie na Azure Container Apps pre škálovateľnosť a efektívnosť prevádzky.

## Výsledky a dopad
- Ukazuje, ako možno MCP využiť na orchestráciu viacerých AI agentov v reálnom, produkčnom prostredí.
- Urýchľuje vývoj riešení poskytovaním znovupoužiteľných vzorov pre koordináciu agentov, integráciu dát a bezpečné nasadenie.
- Slúži ako plán pre vytváranie špecifických AI aplikácií poháňaných MCP a Azure službami.

## Referencie
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, majte prosím na pamäti, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.