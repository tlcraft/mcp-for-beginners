<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b2b9e15e78b9d9a2b3ff3e8fd7d1f434",
  "translation_date": "2025-08-18T19:57:30+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "cs"
}
-->
# MCP Bezpečnostní nejlepší praktiky 2025

Tento komplexní průvodce popisuje základní bezpečnostní nejlepší praktiky pro implementaci systémů Model Context Protocol (MCP) na základě nejnovější specifikace **MCP Specification 2025-06-18** a aktuálních průmyslových standardů. Tyto praktiky se zaměřují jak na tradiční bezpečnostní problémy, tak na hrozby specifické pro AI, které jsou unikátní pro nasazení MCP.

## Kritické bezpečnostní požadavky

### Povinné bezpečnostní kontroly (MUST požadavky)

1. **Ověření tokenů**: MCP servery **NESMÍ** přijímat žádné tokeny, které nebyly výslovně vydány pro samotný MCP server.
2. **Ověření autorizace**: MCP servery implementující autorizaci **MUSÍ** ověřovat VŠECHNY příchozí požadavky a **NESMÍ** používat relace pro autentizaci.  
3. **Souhlas uživatele**: MCP proxy servery používající statické ID klientů **MUSÍ** získat explicitní souhlas uživatele pro každého dynamicky registrovaného klienta.
4. **Bezpečné ID relací**: MCP servery **MUSÍ** používat kryptograficky bezpečné, nedeterministické ID relací generované pomocí bezpečných generátorů náhodných čísel.

## Základní bezpečnostní praktiky

### 1. Validace a sanitace vstupů
- **Komplexní validace vstupů**: Validujte a čistěte všechny vstupy, abyste předešli útokům typu injection, problémům s confused deputy a zranitelnostem prompt injection.
- **Vynucení schématu parametrů**: Implementujte přísnou validaci JSON schémat pro všechny parametry nástrojů a API vstupy.
- **Filtrování obsahu**: Používejte Microsoft Prompt Shields a Azure Content Safety k filtrování škodlivého obsahu v prompty a odpovědích.
- **Sanitace výstupů**: Validujte a čistěte všechny výstupy modelu před jejich prezentací uživatelům nebo downstream systémům.

### 2. Excelentní autentizace a autorizace  
- **Externí poskytovatelé identity**: Delegujte autentizaci na zavedené poskytovatele identity (Microsoft Entra ID, OAuth 2.1 poskytovatele) místo implementace vlastní autentizace.
- **Jemně odstupňovaná oprávnění**: Implementujte granulární, nástrojově specifická oprávnění podle principu nejmenšího oprávnění.
- **Správa životního cyklu tokenů**: Používejte krátkodobé přístupové tokeny s bezpečnou rotací a správným ověřením publika.
- **Vícefaktorová autentizace**: Vyžadujte MFA pro veškerý administrativní přístup a citlivé operace.

### 3. Bezpečné komunikační protokoly
- **Transport Layer Security**: Používejte HTTPS/TLS 1.3 pro všechny MCP komunikace s řádným ověřením certifikátů.
- **End-to-End šifrování**: Implementujte další vrstvy šifrování pro vysoce citlivá data v přenosu i v klidu.
- **Správa certifikátů**: Udržujte správný životní cyklus certifikátů s automatizovanými procesy obnovy.
- **Vynucení verze protokolu**: Používejte aktuální verzi MCP protokolu (2025-06-18) s řádným vyjednáváním verzí.

### 4. Pokročilé omezení rychlosti a ochrana zdrojů
- **Vícevrstvé omezení rychlosti**: Implementujte omezení rychlosti na úrovni uživatele, relace, nástroje a zdrojů, aby se zabránilo zneužití.
- **Adaptivní omezení rychlosti**: Používejte omezení rychlosti založené na strojovém učení, které se přizpůsobuje vzorcům používání a indikátorům hrozeb.
- **Správa kvót zdrojů**: Nastavte vhodné limity pro výpočetní zdroje, využití paměti a dobu provádění.
- **Ochrana proti DDoS**: Nasazujte komplexní ochranu proti DDoS a systémy analýzy provozu.

### 5. Komplexní logování a monitorování
- **Strukturované auditní logování**: Implementujte podrobné, vyhledatelné logy pro všechny MCP operace, provádění nástrojů a bezpečnostní události.
- **Monitorování bezpečnosti v reálném čase**: Nasazujte SIEM systémy s AI-powered detekcí anomálií pro MCP pracovní zátěže.
- **Logování v souladu s ochranou soukromí**: Logujte bezpečnostní události při respektování požadavků na ochranu dat a regulací.
- **Integrace reakce na incidenty**: Připojte logovací systémy k automatizovaným pracovním postupům reakce na incidenty.

### 6. Vylepšené bezpečné úložiště
- **Hardwarové bezpečnostní moduly**: Používejte úložiště klíčů podporované HSM (Azure Key Vault, AWS CloudHSM) pro kritické kryptografické operace.
- **Správa šifrovacích klíčů**: Implementujte správnou rotaci klíčů, segregaci a kontrolu přístupu pro šifrovací klíče.
- **Správa tajemství**: Ukládejte všechny API klíče, tokeny a přihlašovací údaje v dedikovaných systémech pro správu tajemství.
- **Klasifikace dat**: Klasifikujte data podle úrovní citlivosti a aplikujte odpovídající ochranná opatření.

### 7. Pokročilá správa tokenů
- **Prevence průchodu tokenů**: Výslovně zakazujte vzory průchodu tokenů, které obcházejí bezpečnostní kontroly.
- **Ověření publika**: Vždy ověřujte, že tvrzení o publiku tokenu odpovídají identitě zamýšleného MCP serveru.
- **Autorizace založená na tvrzeních**: Implementujte jemně odstupňovanou autorizaci na základě tvrzení tokenů a atributů uživatele.
- **Vázání tokenů**: Vážte tokeny na konkrétní relace, uživatele nebo zařízení, kde je to vhodné.

### 8. Bezpečná správa relací
- **Kryptografická ID relací**: Generujte ID relací pomocí kryptograficky bezpečných generátorů náhodných čísel (ne předvídatelných sekvencí).
- **Vázání na uživatele**: Vážte ID relací na informace specifické pro uživatele pomocí bezpečných formátů jako `<user_id>:<session_id>`.
- **Kontroly životního cyklu relací**: Implementujte správné mechanismy pro vypršení, rotaci a zneplatnění relací.
- **Bezpečnostní hlavičky relací**: Používejte odpovídající HTTP bezpečnostní hlavičky pro ochranu relací.

### 9. Bezpečnostní kontroly specifické pro AI
- **Obrana proti prompt injection**: Nasazujte Microsoft Prompt Shields s technikami spotlighting, delimitery a datamarking.
- **Prevence otravy nástrojů**: Validujte metadata nástrojů, monitorujte dynamické změny a ověřujte integritu nástrojů.
- **Validace výstupů modelu**: Skenujte výstupy modelu na potenciální úniky dat, škodlivý obsah nebo porušení bezpečnostních politik.
- **Ochrana kontextového okna**: Implementujte kontroly, které zabrání otravě kontextového okna a útokům manipulace.

### 10. Bezpečnost provádění nástrojů
- **Sandboxing provádění**: Provádějte nástroje v kontejnerizovaných, izolovaných prostředích s omezením zdrojů.
- **Oddělení oprávnění**: Provádějte nástroje s minimálními požadovanými oprávněními a oddělenými servisními účty.
- **Izolace sítě**: Implementujte segmentaci sítě pro prostředí provádění nástrojů.
- **Monitorování provádění**: Monitorujte provádění nástrojů na anomální chování, využití zdrojů a bezpečnostní porušení.

### 11. Kontinuální validace bezpečnosti
- **Automatizované bezpečnostní testování**: Integrujte bezpečnostní testování do CI/CD pipeline s nástroji jako GitHub Advanced Security.
- **Správa zranitelností**: Pravidelně skenujte všechny závislosti, včetně AI modelů a externích služeb.
- **Penetrační testování**: Provádějte pravidelné bezpečnostní hodnocení zaměřené specificky na implementace MCP.
- **Revize bezpečnostního kódu**: Implementujte povinné bezpečnostní revize pro všechny změny kódu souvisejícího s MCP.

### 12. Bezpečnost dodavatelského řetězce pro AI
- **Ověření komponent**: Ověřujte původ, integritu a bezpečnost všech AI komponent (modelů, embeddingů, API).
- **Správa závislostí**: Udržujte aktuální inventáře všech softwarových a AI závislostí s sledováním zranitelností.
- **Důvěryhodné repozitáře**: Používejte ověřené, důvěryhodné zdroje pro všechny AI modely, knihovny a nástroje.
- **Monitorování dodavatelského řetězce**: Nepřetržitě monitorujte kompromitace u poskytovatelů AI služeb a repozitářů modelů.

## Pokročilé bezpečnostní vzory

### Architektura Zero Trust pro MCP
- **Nikdy nedůvěřuj, vždy ověřuj**: Implementujte kontinuální ověřování pro všechny MCP účastníky.
- **Mikro-segmentace**: Izolujte MCP komponenty s granulárními síťovými a identitními kontrolami.
- **Podmíněný přístup**: Implementujte přístupové kontroly založené na riziku, které se přizpůsobují kontextu a chování.
- **Kontinuální hodnocení rizik**: Dynamicky vyhodnocujte bezpečnostní postoj na základě aktuálních indikátorů hrozeb.

### Implementace AI s ochranou soukromí
- **Minimalizace dat**: Zveřejňujte pouze minimálně nezbytná data pro každou MCP operaci.
- **Diferenciální soukromí**: Implementujte techniky ochrany soukromí pro zpracování citlivých dat.
- **Homomorfní šifrování**: Používejte pokročilé šifrovací techniky pro bezpečné výpočty na šifrovaných datech.
- **Federované učení**: Implementujte distribuované přístupy k učení, které zachovávají lokalitu dat a soukromí.

### Reakce na incidenty pro AI systémy
- **Postupy specifické pro AI incidenty**: Vyvíjejte postupy reakce na incidenty přizpůsobené hrozbám specifickým pro AI a MCP.
- **Automatizovaná reakce**: Implementujte automatizované omezení a nápravu pro běžné bezpečnostní incidenty AI.  
- **Forenzní schopnosti**: Udržujte připravenost na forenzní analýzu kompromitací AI systémů a úniků dat.
- **Postupy obnovy**: Zaveďte postupy pro obnovu po otravě AI modelů, útocích prompt injection a kompromitacích služeb.

## Implementační zdroje a standardy

### Oficiální dokumentace MCP
- [MCP Specification 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) - Aktuální specifikace MCP protokolu
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) - Oficiální bezpečnostní pokyny
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization) - Vzory autentizace a autorizace
- [MCP Transport Security](https://modelcontextprotocol.io/specification/2025-06-18/transports/) - Požadavky na bezpečnost transportní vrstvy

### Microsoft bezpečnostní řešení
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) - Pokročilá ochrana proti prompt injection
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/) - Komplexní filtrování AI obsahu
- [Microsoft Entra ID](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow) - Podniková správa identity a přístupu
- [Azure Key Vault](https://learn.microsoft.com/azure/key-vault/general/basic-concepts) - Bezpečná správa tajemství a přihlašovacích údajů
- [GitHub Advanced Security](https://github.com/security/advanced-security) - Skenování bezpečnosti dodavatelského řetězce a kódu

### Bezpečnostní standardy a rámce
- [OAuth 2.1 Security Best Practices](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-security-topics) - Aktuální pokyny pro bezpečnost OAuth
- [OWASP Top 10](https://owasp.org/www-project-top-ten/) - Rizika webových aplikací
- [OWASP Top 10 pro LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559) - Rizika specifická pro AI
- [NIST AI Risk Management Framework](https://www.nist.gov/itl/ai-risk-management-framework) - Komplexní správa rizik AI
- [ISO 27001:2022](https://www.iso.org/standard/27001) - Systémy řízení bezpečnosti informací

### Implementační průvodce a tutoriály
- [Azure API Management jako MCP Auth Gateway](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) - Vzory podnikové autentizace
- [Microsoft Entra ID s MCP servery](https://den.dev/blog/mcp-server-auth-entra-id-session/) - Integrace poskytovatele identity
- [Implementace bezpečného úložiště tokenů](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) - Nejlepší praktiky správy tokenů
- [End-to-End šifrování pro AI](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption) - Pokročilé šifrovací vzory

### Pokročilé bezpečnostní zdroje
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl) - Praktiky bezpečného vývoje
- [AI Red Team Guidance](https://learn.microsoft.com/security/ai-red-team/) - Testování bezpečnosti specifické pro AI
- [Threat Modeling pro AI systémy](https://learn.microsoft.com/security/adoption/approach/threats-ai) - Metodologie modelování hrozeb pro AI
- [Privacy Engineering pro AI](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/) - Techniky ochrany soukromí pro AI

### Soulad a správa
- [GDPR Compliance pro AI](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments) - Soulad ochrany soukromí v AI systémech
- [AI Governance Framework](https://learn.microsoft.com/azure/architecture/guide/responsible-ai/responsible-ai-overview) - Implementace odpovědné AI
- [SOC 2 pro AI služby](https://learn.microsoft.com/compliance/regulatory/offering-soc) - Bezpečnostní kontroly pro poskytovatele AI služeb
- [HIPAA Compliance pro AI](https://learn.microsoft.com/compliance/regulatory/offering-hipaa-hitech) - Požadavky na soulad AI v oblasti zdravotnictví

### DevSecOps a automatizace
- [DevSecOps Pipeline pro AI](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline) - Bezpečné vývojové pipeline pro AI
- [Automatizované bezpečnostní testování](https://learn.microsoft.com/security/engineering/devsecops) - Kontinuální validace bezpečnosti
- [Bezpečnost infrastruktury jako kódu](https://learn.microsoft.com/security/engineering/infrastructure-security) - Bezpečné nasazení infrastruktury
- [Bezpečnost kontejnerů pro AI](https://learn.microsoft.com/azure/container-instances/container-instances-image-security) - Bezpečnost kontejnerizace AI pracovních zátěží

### Monitorování a reakce na incidenty  
- [Azure Monitor pro AI pracovní zátěže](https://learn.microsoft.com/azure/azure-monitor/overview) - Komplexní monitorovací řešení
- [Reakce na bezpečnostní incidenty AI](https://learn.microsoft.com/security/compass/incident-response-playbooks)
- **Vývoj nástrojů**: Vyvíjejte a sdílejte bezpečnostní nástroje a knihovny pro ekosystém MCP

---

*Tento dokument odráží osvědčené bezpečnostní postupy MCP k datu 18. srpna 2025, na základě specifikace MCP 2025-06-18. Bezpečnostní postupy by měly být pravidelně přezkoumávány a aktualizovány, jak se protokol a hrozby vyvíjejí.*

**Prohlášení:**  
Tento dokument byl přeložen pomocí služby pro automatický překlad [Co-op Translator](https://github.com/Azure/co-op-translator). Ačkoli se snažíme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho původním jazyce by měl být považován za autoritativní zdroj. Pro důležité informace doporučujeme profesionální lidský překlad. Neodpovídáme za žádné nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.