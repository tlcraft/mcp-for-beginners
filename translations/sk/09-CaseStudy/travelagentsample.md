<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:53:02+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "sk"
}
-->
# Prípadová štúdia: Azure AI Travel Agents – Referenčná implementácia

## Prehľad

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) je komplexné referenčné riešenie vyvinuté spoločnosťou Microsoft, ktoré ukazuje, ako vytvoriť viacagentnú, AI-poháňanú aplikáciu na plánovanie ciest pomocou Model Context Protocol (MCP), Azure OpenAI a Azure AI Search. Tento projekt predstavuje osvedčené postupy pre koordináciu viacerých AI agentov, integráciu podnikových dát a poskytuje bezpečnú, rozšíriteľnú platformu pre reálne scenáre.

## Kľúčové vlastnosti
- **Koordinácia viacerých agentov:** Využíva MCP na koordináciu špecializovaných agentov (napr. agenti pre lety, hotely a itineráre), ktorí spolupracujú pri riešení zložitých úloh plánovania ciest.
- **Integrácia podnikových dát:** Pripája sa k Azure AI Search a ďalším zdrojom podnikových dát, aby poskytol aktuálne a relevantné informácie pre odporúčania pri cestovaní.
- **Bezpečná a škálovateľná architektúra:** Využíva Azure služby pre autentifikáciu, autorizáciu a škálovateľné nasadenie, dodržiavajúc najlepšie bezpečnostné postupy pre podniky.
- **Rozšíriteľné nástroje:** Implementuje znovupoužiteľné MCP nástroje a šablóny promptov, ktoré umožňujú rýchlu adaptáciu na nové oblasti alebo obchodné požiadavky.
- **Používateľský zážitok:** Poskytuje konverzačné rozhranie, cez ktoré môžu používatelia komunikovať s cestovnými agentmi, poháňané Azure OpenAI a MCP.

## Architektúra
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Popis architektonického diagramu

Riešenie Azure AI Travel Agents je navrhnuté s dôrazom na modularitu, škálovateľnosť a bezpečnú integráciu viacerých AI agentov a podnikových zdrojov dát. Hlavné komponenty a tok dát sú nasledovné:

- **Používateľské rozhranie:** Používatelia komunikujú so systémom cez konverzačné UI (napr. webový chat alebo Teams bot), ktoré posiela používateľské dotazy a prijíma odporúčania na cestovanie.
- **MCP Server:** Slúži ako centrálny koordinátor, prijíma vstupy od používateľa, spravuje kontext a koordinuje činnosti špecializovaných agentov (napr. FlightAgent, HotelAgent, ItineraryAgent) cez Model Context Protocol.
- **AI agenti:** Každý agent zodpovedá za konkrétnu oblasť (lety, hotely, itineráre) a je implementovaný ako MCP nástroj. Agent používa šablóny promptov a logiku na spracovanie požiadaviek a generovanie odpovedí.
- **Azure OpenAI Service:** Poskytuje pokročilé porozumenie prirodzenému jazyku a generovanie textu, vďaka čomu agenti rozumejú zámerom používateľa a tvoria konverzačné odpovede.
- **Azure AI Search a podnikové dáta:** Agenti dotazujú Azure AI Search a ďalšie podnikové zdroje, aby získali aktuálne informácie o letoch, hoteloch a možnostiach cestovania.
- **Autentifikácia a bezpečnosť:** Integruje sa s Microsoft Entra ID pre bezpečnú autentifikáciu a aplikuje prístupové práva s najmenším možným rozsahom na všetky zdroje.
- **Nasadenie:** Navrhnuté na nasadenie v Azure Container Apps, čo zabezpečuje škálovateľnosť, monitoring a efektívnu prevádzku.

Táto architektúra umožňuje hladkú koordináciu viacerých AI agentov, bezpečnú integráciu s podnikových dát a robustnú, rozšíriteľnú platformu pre tvorbu AI riešení špecifických pre jednotlivé oblasti.

## Krok za krokom vysvetlenie architektonického diagramu
Predstavte si, že plánujete veľkú cestu a máte tím odborných asistentov, ktorí vám pomáhajú s každým detailom. Systém Azure AI Travel Agents funguje podobne, využíva rôzne časti (ako členov tímu), z ktorých každý má špeciálnu úlohu. Takto to všetko spolu funguje:

### Používateľské rozhranie (UI):
Predstavte si to ako recepciu vášho cestovného agenta. Tu vy (používateľ) kladiete otázky alebo zadávate požiadavky, napríklad „Nájdi mi let do Paríža.“ Môže to byť chatové okno na webe alebo v aplikácii na správy.

### MCP Server (Koordinátor):
MCP Server je ako manažér, ktorý počúva vašu požiadavku na recepcii a rozhoduje, ktorý špecialista by mal riešiť jednotlivé časti. Sleduje priebeh konverzácie a zabezpečuje, že všetko prebieha hladko.

### AI agenti (Špecializovaní asistenti):
Každý agent je expertom na konkrétnu oblasť – jeden pozná všetko o letoch, ďalší o hoteloch a ďalší o plánovaní itinerárov. Keď požiadate o cestu, MCP Server pošle vašu požiadavku príslušnému agentovi/agentom. Tí využívajú svoje znalosti a nástroje na nájdenie najlepších možností pre vás.

### Azure OpenAI Service (Jazykový expert):
Je to ako mať jazykového experta, ktorý presne rozumie tomu, čo žiadate, bez ohľadu na to, ako to poviete. Pomáha agentom pochopiť vaše požiadavky a odpovedať prirodzeným, konverzačným štýlom.

### Azure AI Search a podnikové dáta (Informačná knižnica):
Predstavte si obrovskú, aktuálnu knižnicu so všetkými najnovšími informáciami o cestovaní – letové poriadky, dostupnosť hotelov a ďalšie. Agenti túto knižnicu prehľadávajú, aby vám poskytli najpresnejšie odpovede.

### Autentifikácia a bezpečnosť (Strážca bezpečnosti):
Rovnako ako strážca kontroluje, kto môže vstúpiť do určitých priestorov, táto časť zabezpečuje, že iba oprávnené osoby a agenti majú prístup k citlivým informáciám. Chráni vaše dáta a súkromie.

### Nasadenie v Azure Container Apps (Budova):
Všetci títo asistenti a nástroje spolupracujú v bezpečnej, škálovateľnej budove (cloude). To znamená, že systém zvládne veľa používateľov naraz a je vždy k dispozícii, keď ho potrebujete.

## Ako to všetko spolu funguje:

Najprv položíte otázku na recepcii (UI).  
Manažér (MCP Server) zistí, ktorý špecialista (agent) vám má pomôcť.  
Špecialista využije jazykového experta (OpenAI), aby pochopil vašu požiadavku, a knižnicu (AI Search), aby našiel najlepšiu odpoveď.  
Strážca bezpečnosti (Autentifikácia) zabezpečí, že je všetko v poriadku.  
To všetko prebieha v spoľahlivej, škálovateľnej budove (Azure Container Apps), takže váš zážitok je plynulý a bezpečný.  
Táto tímová práca umožňuje systému rýchlo a bezpečne pomôcť s plánovaním vašej cesty, presne ako tím odborných cestovných agentov pracujúcich spolu v modernom kancelárskom prostredí!

## Technická implementácia
- **MCP Server:** Hostuje základnú logiku orchestrácie, sprístupňuje nástroje agentov a spravuje kontext pre viacstupňové pracovné postupy plánovania ciest.
- **Agenti:** Každý agent (napr. FlightAgent, HotelAgent) je implementovaný ako MCP nástroj so svojimi vlastnými šablónami promptov a logikou.
- **Integrácia Azure:** Používa Azure OpenAI pre porozumenie prirodzenému jazyku a Azure AI Search pre získavanie dát.
- **Bezpečnosť:** Integruje sa s Microsoft Entra ID pre autentifikáciu a aplikuje prístupové práva s najmenším možným rozsahom na všetky zdroje.
- **Nasadenie:** Podporuje nasadenie v Azure Container Apps pre škálovateľnosť a efektívnu prevádzku.

## Výsledky a dopad
- Ukazuje, ako možno MCP využiť na koordináciu viacerých AI agentov v reálnom, produkčnom prostredí.
- Urýchľuje vývoj riešení vďaka znovupoužiteľným vzorom pre koordináciu agentov, integráciu dát a bezpečné nasadenie.
- Slúži ako vzor pre tvorbu AI aplikácií špecifických pre jednotlivé oblasti s využitím MCP a Azure služieb.

## Referencie
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, vezmite prosím na vedomie, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.