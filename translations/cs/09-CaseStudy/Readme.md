<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:34:12+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "cs"
}
-->
# Případová studie: Azure AI Cestovní agenti – Referenční implementace

## Přehled

[Azure AI Cestovní agenti](https://github.com/Azure-Samples/azure-ai-travel-agents) je komplexní referenční řešení vyvinuté společností Microsoft, které ukazuje, jak vytvořit víceagentní, AI poháněnou aplikaci pro plánování cestování pomocí Model Context Protocol (MCP), Azure OpenAI a Azure AI Search. Tento projekt prezentuje osvědčené postupy pro orchestraci více AI agentů, integraci podnikových dat a poskytování bezpečné, rozšiřitelné platformy pro reálné scénáře.

## Klíčové vlastnosti
- **Orchestrace více agentů:** Využívá MCP k koordinaci specializovaných agentů (např. let, hotelů a itinerářů), kteří spolupracují na splnění složitých úkolů plánování cestování.
- **Integrace podnikových dat:** Připojuje se k Azure AI Search a dalším podnikových datovým zdrojům pro poskytování aktuálních, relevantních informací pro doporučení cestování.
- **Bezpečná, škálovatelná architektura:** Využívá služby Azure pro autentizaci, autorizaci a škálovatelné nasazení, v souladu s osvědčenými postupy podnikové bezpečnosti.
- **Rozšiřitelné nástroje:** Implementuje znovupoužitelné MCP nástroje a šablony promptů, což umožňuje rychlou adaptaci na nové domény nebo obchodní požadavky.
- **Uživatelská zkušenost:** Poskytuje konverzační rozhraní pro uživatele k interakci s cestovními agenty, poháněné Azure OpenAI a MCP.

## Architektura
![Architektura](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Popis diagramu architektury

Řešení Azure AI Cestovní agenti je navrženo pro modularitu, škálovatelnost a bezpečnou integraci více AI agentů a podnikových datových zdrojů. Hlavní komponenty a tok dat jsou následující:

- **Uživatelské rozhraní:** Uživatelé komunikují se systémem prostřednictvím konverzačního UI (jako je webový chat nebo Teams bot), které posílá dotazy uživatelů a přijímá doporučení pro cestování.
- **MCP Server:** Slouží jako centrální orchestrátor, přijímá vstupy uživatelů, spravuje kontext a koordinuje akce specializovaných agentů (např. FlightAgent, HotelAgent, ItineraryAgent) prostřednictvím Model Context Protocol.
- **AI agenti:** Každý agent je zodpovědný za konkrétní oblast (lety, hotely, itineráře) a je implementován jako MCP nástroj. Agenti používají šablony promptů a logiku k zpracování požadavků a generování odpovědí.
- **Azure OpenAI služba:** Poskytuje pokročilé porozumění a generování přirozeného jazyka, což umožňuje agentům interpretovat úmysly uživatelů a generovat konverzační odpovědi.
- **Azure AI Search & podniková data:** Agenti dotazují Azure AI Search a další podnikové datové zdroje, aby získali aktuální informace o letech, hotelech a cestovních možnostech.
- **Autentizace a bezpečnost:** Integruje se s Microsoft Entra ID pro bezpečnou autentizaci a aplikuje princip nejnižších oprávnění na všechny zdroje.
- **Nasazení:** Navrženo pro nasazení na Azure Container Apps, zajišťující škálovatelnost, monitorování a provozní efektivitu.

Tato architektura umožňuje bezproblémovou orchestraci více AI agentů, bezpečnou integraci s podnikovými daty a robustní, rozšiřitelnou platformu pro budování doménově specifických AI řešení.

## Krok za krokem vysvětlení diagramu architektury
Představte si plánování velké cesty a mít tým odborných asistentů, kteří vám pomohou s každým detailem. Systém Azure AI Cestovní agenti funguje podobným způsobem, používá různé části (jako členy týmu), z nichž každý má speciální úkol. Tady je, jak to všechno do sebe zapadá:

### Uživatelské rozhraní (UI):
Představte si to jako přední pult vašeho cestovního agenta. Je to místo, kde (uživatel) kladete otázky nebo děláte požadavky, jako "Najdi mi let do Paříže." To může být chatovací okno na webu nebo aplikace pro zasílání zpráv.

### MCP Server (Koordinátor):
MCP Server je jako manažer, který naslouchá vašemu požadavku na předním pultu a rozhoduje, který specialista by měl každou část zpracovat. Sleduje vaši konverzaci a zajišťuje, že vše běží hladce.

### AI agenti (Specializovaní asistenti):
Každý agent je odborníkem v konkrétní oblasti – jeden zná vše o letech, další o hotelech a další o plánování vašeho itineráře. Když žádáte o cestu, MCP Server pošle váš požadavek správnému agentovi. Tito agenti používají své znalosti a nástroje k nalezení nejlepších možností pro vás.

### Azure OpenAI služba (Jazykový expert):
To je jako mít jazykového experta, který přesně rozumí tomu, co se ptáte, bez ohledu na to, jak to formulujete. Pomáhá agentům rozumět vašim požadavkům a reagovat přirozeným, konverzačním jazykem.

### Azure AI Search & podniková data (Informační knihovna):
Představte si obrovskou, aktuální knihovnu se všemi nejnovějšími informacemi o cestování – letové řády, dostupnost hotelů a další. Agenti prohledávají tuto knihovnu, aby získali co nejpřesnější odpovědi pro vás.

### Autentizace a bezpečnost (Bezpečnostní stráž):
Stejně jako bezpečnostní stráž kontroluje, kdo může vstoupit do určitých oblastí, tato část zajišťuje, že pouze autorizovaní lidé a agenti mohou přistupovat k citlivým informacím. Udržuje vaše data v bezpečí a soukromí.

### Nasazení na Azure Container Apps (Budova):
Všichni tito asistenti a nástroje pracují společně uvnitř bezpečné, škálovatelné budovy (cloudu). To znamená, že systém zvládne spoustu uživatelů najednou a je vždy k dispozici, když ho potřebujete.

## Jak to všechno funguje dohromady:

Začnete tím, že položíte otázku na předním pultu (UI).
Manažer (MCP Server) zjistí, který specialista (agent) by vám měl pomoci.
Specialista používá jazykového experta (OpenAI) k pochopení vašeho požadavku a knihovnu (AI Search) k nalezení nejlepší odpovědi.
Bezpečnostní stráž (Autentizace) zajišťuje, že vše je bezpečné.
To vše se děje uvnitř spolehlivé, škálovatelné budovy (Azure Container Apps), takže vaše zkušenost je plynulá a bezpečná.
Tato týmová práce umožňuje systému rychle a bezpečně pomoci vám naplánovat vaši cestu, stejně jako tým odborných cestovních agentů pracujících společně v moderní kanceláři!

## Technická implementace
- **MCP Server:** Hostuje hlavní orchestraci logiky, zpřístupňuje nástroje agentů a spravuje kontext pro vícestupňové pracovní postupy plánování cestování.
- **Agenti:** Každý agent (např. FlightAgent, HotelAgent) je implementován jako MCP nástroj s vlastními šablonami promptů a logikou.
- **Integrace Azure:** Používá Azure OpenAI pro porozumění přirozenému jazyku a Azure AI Search pro vyhledávání dat.
- **Bezpečnost:** Integruje se s Microsoft Entra ID pro autentizaci a aplikuje princip nejnižších oprávnění na všechny zdroje.
- **Nasazení:** Podporuje nasazení na Azure Container Apps pro škálovatelnost a provozní efektivitu.

## Výsledky a dopad
- Ukazuje, jak lze MCP použít k orchestraci více AI agentů ve scénáři reálného světa na produkční úrovni.
- Zrychluje vývoj řešení poskytnutím znovupoužitelných vzorů pro koordinaci agentů, integraci dat a bezpečné nasazení.
- Slouží jako plán pro budování doménově specifických, AI poháněných aplikací pomocí MCP a služeb Azure.

## Odkazy
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Zřeknutí se odpovědnosti**:
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, prosím, uvědomte si, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.