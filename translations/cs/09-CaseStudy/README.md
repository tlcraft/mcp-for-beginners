<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:43:13+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "cs"
}
-->
# Case Study: Azure AI Travel Agents – Referenční implementace

## Přehled

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) je komplexní referenční řešení vyvinuté společností Microsoft, které ukazuje, jak vytvořit aplikaci pro plánování cestování s více agenty využívající umělou inteligenci pomocí Model Context Protocol (MCP), Azure OpenAI a Azure AI Search. Tento projekt představuje osvědčené postupy pro koordinaci více AI agentů, integraci podnikových dat a poskytování bezpečné, rozšiřitelné platformy pro reálné scénáře.

## Klíčové vlastnosti
- **Koordinace více agentů:** Využívá MCP k řízení specializovaných agentů (např. agenti pro lety, hotely a itineráře), kteří spolupracují na plnění složitých úkolů plánování cest.
- **Integrace podnikových dat:** Připojuje se k Azure AI Search a dalším podnikových datovým zdrojům, aby poskytoval aktuální a relevantní informace pro cestovní doporučení.
- **Bezpečná a škálovatelná architektura:** Využívá služby Azure pro autentizaci, autorizaci a škálovatelné nasazení, podle nejlepších bezpečnostních praktik pro podniky.
- **Rozšiřitelné nástroje:** Implementuje znovupoužitelné MCP nástroje a šablony promptů, což umožňuje rychlé přizpůsobení novým oblastem nebo obchodním požadavkům.
- **Uživatelská zkušenost:** Nabízí konverzační rozhraní, kde uživatelé komunikují s cestovními agenty, poháněné Azure OpenAI a MCP.

## Architektura
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Popis architektonického diagramu

Řešení Azure AI Travel Agents je navrženo pro modularitu, škálovatelnost a bezpečnou integraci více AI agentů a podnikových datových zdrojů. Hlavní komponenty a tok dat jsou následující:

- **Uživatelské rozhraní:** Uživatelé komunikují se systémem přes konverzační UI (například webový chat nebo Teams bot), které odesílá dotazy uživatele a přijímá cestovní doporučení.
- **MCP Server:** Slouží jako centrální koordinátor, přijímá vstupy od uživatele, spravuje kontext a koordinuje akce specializovaných agentů (např. FlightAgent, HotelAgent, ItineraryAgent) pomocí Model Context Protocol.
- **AI agenti:** Každý agent je odpovědný za konkrétní oblast (lety, hotely, itineráře) a je implementován jako MCP nástroj. Agent používají šablony promptů a logiku k zpracování požadavků a generování odpovědí.
- **Azure OpenAI Service:** Poskytuje pokročilé porozumění přirozenému jazyku a generování textu, což agentům umožňuje interpretovat záměr uživatele a vytvářet konverzační odpovědi.
- **Azure AI Search & podniková data:** Agenti dotazují Azure AI Search a další podnikové zdroje, aby získali aktuální informace o letech, hotelech a možnostech cestování.
- **Autentizace a bezpečnost:** Integruje se s Microsoft Entra ID pro bezpečnou autentizaci a uplatňuje přístupová práva s nejmenšími oprávněními ke všem zdrojům.
- **Nasazení:** Navrženo pro nasazení na Azure Container Apps, což zajišťuje škálovatelnost, monitoring a provozní efektivitu.

Tato architektura umožňuje plynulou koordinaci více AI agentů, bezpečnou integraci podnikových dat a robustní, rozšiřitelnou platformu pro tvorbu doménově specifických AI řešení.

## Krok za krokem vysvětlení architektonického diagramu
Představte si, že plánujete velký výlet a máte tým zkušených asistentů, kteří vám pomáhají s každým detailem. Systém Azure AI Travel Agents funguje podobným způsobem, používá různé části (jako členy týmu), z nichž každý má svou specializaci. Takto to všechno funguje dohromady:

### Uživatelské rozhraní (UI):
Představte si to jako přepážku vašeho cestovního agenta. Zde vy (uživatel) kladete otázky nebo zadáváte požadavky, například „Najdi mi let do Paříže.“ Může to být chatovací okno na webu nebo v aplikaci pro zasílání zpráv.

### MCP Server (Koordinátor):
MCP Server je jako manažer, který poslouchá váš požadavek na přepážce a rozhoduje, který specialista má danou část vyřídit. Sleduje průběh konverzace a zajišťuje, že vše probíhá hladce.

### AI agenti (Specialisté):
Každý agent je odborník na určitou oblast – jeden zná vše o letech, druhý o hotelech a další o plánování itineráře. Když požádáte o cestu, MCP Server předá váš požadavek příslušnému agentovi/agentům. Ti využívají své znalosti a nástroje, aby našli nejlepší možnosti.

### Azure OpenAI Service (Jazykový expert):
Je to jako mít jazykového experta, který přesně rozumí tomu, co žádáte, bez ohledu na to, jak to formulujete. Pomáhá agentům pochopit vaše požadavky a reagovat přirozeně a srozumitelně.

### Azure AI Search & podniková data (Informační knihovna):
Představte si obrovskou, aktuální knihovnu se všemi nejnovějšími informacemi o cestování – letové řády, dostupnost hotelů a další. Agenti v této knihovně hledají nejpřesnější odpovědi pro vás.

### Autentizace a bezpečnost (Ostraha):
Stejně jako ostraha kontroluje, kdo může vstoupit do určitých prostor, tato část zajišťuje, že pouze oprávnění lidé a agenti mají přístup k citlivým informacím. Vaše data tak zůstávají v bezpečí a soukromí.

### Nasazení na Azure Container Apps (Budova):
Všichni tito asistenti a nástroje pracují společně uvnitř bezpečné, škálovatelné budovy (cloudu). To znamená, že systém zvládne obsloužit mnoho uživatelů současně a je vždy k dispozici, když ho potřebujete.

## Jak to všechno funguje dohromady:

Začnete otázkou na přepážce (UI).  
Manažer (MCP Server) určí, který specialista (agent) vám pomůže.  
Specialista využije jazykového experta (OpenAI), aby pochopil váš požadavek, a knihovnu (AI Search), aby našel nejlepší odpověď.  
Ostraha (Autentizace) zajistí, že vše je bezpečné.  
To vše probíhá v spolehlivé, škálovatelné budově (Azure Container Apps), takže vaše zkušenost je plynulá a bezpečná.  
Tato spolupráce umožňuje systému rychle a bezpečně pomoci s plánováním vaší cesty, stejně jako tým zkušených cestovních agentů pracujících společně v moderní kanceláři!

## Technická implementace
- **MCP Server:** Hostuje základní logiku orchestrace, vystavuje nástroje agentů a spravuje kontext pro vícestupňové pracovní postupy plánování cest.
- **Agenti:** Každý agent (např. FlightAgent, HotelAgent) je implementován jako MCP nástroj se svými vlastními šablonami promptů a logikou.
- **Integrace Azure:** Využívá Azure OpenAI pro porozumění přirozenému jazyku a Azure AI Search pro získávání dat.
- **Bezpečnost:** Integruje se s Microsoft Entra ID pro autentizaci a uplatňuje přístupová práva s nejmenšími oprávněními ke všem zdrojům.
- **Nasazení:** Podporuje nasazení na Azure Container Apps pro škálovatelnost a provozní efektivitu.

## Výsledky a dopad
- Ukazuje, jak lze MCP využít ke koordinaci více AI agentů v reálném, produkčním prostředí.
- Urychluje vývoj řešení díky poskytování znovupoužitelných vzorů pro koordinaci agentů, integraci dat a bezpečné nasazení.
- Slouží jako vzor pro tvorbu doménově specifických aplikací s umělou inteligencí využívajících MCP a služby Azure.

## Reference
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho původním jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo chybné výklady vyplývající z použití tohoto překladu.