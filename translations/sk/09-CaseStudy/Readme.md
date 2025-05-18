<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:34:41+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "sk"
}
-->
# Prípadová štúdia: Azure AI Cestovní agenti – Referenčná implementácia

## Prehľad

[Azure AI Cestovní agenti](https://github.com/Azure-Samples/azure-ai-travel-agents) je komplexné referenčné riešenie vyvinuté spoločnosťou Microsoft, ktoré demonštruje, ako vytvoriť aplikáciu na plánovanie ciest poháňanú umelou inteligenciou s viacerými agentmi pomocou Model Context Protocol (MCP), Azure OpenAI a Azure AI Search. Tento projekt predstavuje osvedčené postupy pre orchestráciu viacerých AI agentov, integráciu podnikových dát a poskytovanie bezpečnej, rozšíriteľnej platformy pre reálne scenáre.

## Kľúčové vlastnosti
- **Orchestrácia viacerých agentov:** Využíva MCP na koordináciu špecializovaných agentov (napr. agentov pre lety, hotely a itineráre), ktorí spolupracujú na splnení komplexných úloh plánovania ciest.
- **Integrácia podnikových dát:** Pripája sa k Azure AI Search a iným podnikovým zdrojom dát, aby poskytol aktuálne a relevantné informácie pre cestovné odporúčania.
- **Bezpečná, škálovateľná architektúra:** Využíva služby Azure na autentifikáciu, autorizáciu a škálovateľné nasadenie, pričom dodržiava osvedčené bezpečnostné postupy pre podniky.
- **Rozšíriteľné nástroje:** Implementuje znovupoužiteľné MCP nástroje a šablóny výziev, čo umožňuje rýchlu adaptáciu na nové oblasti alebo obchodné požiadavky.
- **Používateľská skúsenosť:** Poskytuje konverzačné rozhranie pre používateľov na interakciu s cestovnými agentmi, poháňané Azure OpenAI a MCP.

## Architektúra
![Architektúra](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Popis diagramu architektúry

Riešenie Azure AI Cestovní agenti je navrhnuté pre modularitu, škálovateľnosť a bezpečnú integráciu viacerých AI agentov a podnikových zdrojov dát. Hlavné komponenty a tok dát sú nasledovné:

- **Používateľské rozhranie:** Používatelia interagujú so systémom prostredníctvom konverzačného UI (ako je webový chat alebo Teams bot), ktorý posiela užívateľské dotazy a prijíma cestovné odporúčania.
- **MCP Server:** Slúži ako centrálny orchestrátor, prijíma vstupy od používateľov, spravuje kontext a koordinuje činnosti špecializovaných agentov (napr. FlightAgent, HotelAgent, ItineraryAgent) prostredníctvom Model Context Protocol.
- **AI agenti:** Každý agent je zodpovedný za konkrétnu oblasť (lety, hotely, itineráre) a je implementovaný ako MCP nástroj. Agenti používajú šablóny výziev a logiku na spracovanie požiadaviek a generovanie odpovedí.
- **Azure OpenAI Service:** Poskytuje pokročilé porozumenie a generovanie prirodzeného jazyka, čo umožňuje agentom interpretovať úmysly používateľov a generovať konverzačné odpovede.
- **Azure AI Search & Podnikové dáta:** Agenti vyhľadávajú v Azure AI Search a iných podnikových zdrojoch dát, aby získali aktuálne informácie o letoch, hoteloch a cestovných možnostiach.
- **Autentifikácia a bezpečnosť:** Integruje sa s Microsoft Entra ID pre bezpečnú autentifikáciu a uplatňuje prístupové kontroly s minimálnymi oprávneniami na všetky zdroje.
- **Nasadenie:** Navrhnuté pre nasadenie na Azure Container Apps, čo zabezpečuje škálovateľnosť, monitorovanie a operačnú efektívnosť.

Táto architektúra umožňuje bezproblémovú orchestráciu viacerých AI agentov, bezpečnú integráciu s podnikovými dátami a robustnú, rozšíriteľnú platformu pre budovanie doménovo špecifických AI riešení.

## Krok za krokom vysvetlenie diagramu architektúry
Predstavte si, že plánujete veľkú cestu a máte tím odborných asistentov, ktorí vám pomáhajú s každým detailom. Systém Azure AI Cestovní agenti funguje podobným spôsobom, používa rôzne časti (ako členovia tímu), z ktorých každá má špeciálnu úlohu. Tu je, ako to všetko do seba zapadá:

### Používateľské rozhranie (UI):
Predstavte si to ako recepciu vášho cestovného agenta. Je to miesto, kde vy (používateľ) kladiete otázky alebo robíte požiadavky, ako napríklad „Nájdi mi let do Paríža.“ Môže to byť chatovacie okno na webovej stránke alebo aplikácia na odosielanie správ.

### MCP Server (Koordinátor):
MCP Server je ako manažér, ktorý počúva vašu požiadavku na recepcii a rozhoduje, ktorý špecialista by mal riešiť každú časť. Sleduje vašu konverzáciu a zabezpečuje, aby všetko prebiehalo hladko.

### AI agenti (Špecializovaní asistenti):
Každý agent je expert v konkrétnej oblasti – jeden vie všetko o letoch, ďalší o hoteloch a ďalší o plánovaní itinerára. Keď požiadate o cestu, MCP Server pošle vašu požiadavku správnemu agentovi(om). Títo agenti používajú svoje znalosti a nástroje, aby pre vás našli tie najlepšie možnosti.

### Azure OpenAI Service (Jazykový expert):
To je ako mať jazykového experta, ktorý presne rozumie, čo sa pýtate, bez ohľadu na to, ako to formulujete. Pomáha agentom rozumieť vašim požiadavkám a odpovedať prirodzeným, konverzačným jazykom.

### Azure AI Search & Podnikové dáta (Informačná knižnica):
Predstavte si obrovskú, aktuálnu knižnicu so všetkými najnovšími cestovnými informáciami – letové poriadky, dostupnosť hotelov a ďalšie. Agenti prehľadávajú túto knižnicu, aby získali najpresnejšie odpovede pre vás.

### Autentifikácia a bezpečnosť (Bezpečnostná služba):
Rovnako ako bezpečnostná služba kontroluje, kto môže vstúpiť do určitých oblastí, táto časť zabezpečuje, že len autorizovaní ľudia a agenti môžu pristupovať k citlivým informáciám. Udržuje vaše dáta v bezpečí a súkromí.

### Nasadenie na Azure Container Apps (Budova):
Všetci títo asistenti a nástroje pracujú spolu v bezpečnej, škálovateľnej budove (cloude). To znamená, že systém môže zvládnuť veľa používateľov naraz a je vždy k dispozícii, keď ho potrebujete.

## Ako to všetko funguje spolu:

Začnete tým, že položíte otázku na recepcii (UI).
Manažér (MCP Server) zistí, ktorý špecialista (agent) by vám mal pomôcť.
Špecialista použije jazykového experta (OpenAI), aby porozumel vašej požiadavke a knižnicu (AI Search), aby našiel najlepšiu odpoveď.
Bezpečnostná služba (Autentifikácia) zabezpečí, že všetko je bezpečné.
To všetko sa deje v spoľahlivej, škálovateľnej budove (Azure Container Apps), takže vaša skúsenosť je plynulá a bezpečná.
Tímová práca umožňuje systému rýchlo a bezpečne pomôcť vám naplánovať vašu cestu, rovnako ako tím odborných cestovných agentov pracujúcich spolu v modernom kancelárii!

## Technická implementácia
- **MCP Server:** Hosťuje základnú logiku orchestrácie, vystavuje nástroje agentov a spravuje kontext pre viacstupňové pracovné postupy plánovania ciest.
- **Agenti:** Každý agent (napr. FlightAgent, HotelAgent) je implementovaný ako MCP nástroj s vlastnými šablónami výziev a logikou.
- **Integrácia Azure:** Používa Azure OpenAI na porozumenie prirodzeného jazyka a Azure AI Search na získavanie dát.
- **Bezpečnosť:** Integruje sa s Microsoft Entra ID pre autentifikáciu a uplatňuje prístupové kontroly s minimálnymi oprávneniami na všetky zdroje.
- **Nasadenie:** Podporuje nasadenie na Azure Container Apps pre škálovateľnosť a operačnú efektívnosť.

## Výsledky a vplyv
- Demonštruje, ako môže byť MCP použitý na orchestráciu viacerých AI agentov v reálnom, produkčnom prostredí.
- Urýchľuje vývoj riešení poskytovaním znovupoužiteľných vzorov pre koordináciu agentov, integráciu dát a bezpečné nasadenie.
- Slúži ako plán na vytváranie doménovo špecifických aplikácií poháňaných AI pomocou MCP a služieb Azure.

## Referencie
- [Azure AI Cestovní agenti GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, uvedomte si, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho pôvodnom jazyku by mal byť považovaný za záväzný zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.