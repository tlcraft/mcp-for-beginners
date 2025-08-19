<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T13:45:52+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "cs"
}
-->
# MCP Bezpečnostní osvědčené postupy - aktualizace červenec 2025

## Komplexní bezpečnostní osvědčené postupy pro implementace MCP

Při práci se servery MCP dodržujte tyto bezpečnostní osvědčené postupy, abyste ochránili svá data, infrastrukturu a uživatele:

1. **Validace vstupů**: Vždy validujte a sanitizujte vstupy, abyste předešli injekčním útokům a problémům s „confused deputy“.
   - Zavádějte přísnou validaci všech parametrů nástrojů
   - Používejte validaci podle schématu, aby požadavky odpovídaly očekávaným formátům
   - Filtrujte potenciálně škodlivý obsah před zpracováním

2. **Řízení přístupu**: Implementujte správnou autentizaci a autorizaci pro váš MCP server s jemně nastavenými oprávněními.
   - Používejte OAuth 2.0 s ověřenými poskytovateli identity, jako je Microsoft Entra ID
   - Zavádějte řízení přístupu založené na rolích (RBAC) pro MCP nástroje
   - Nikdy neimplementujte vlastní autentizaci, pokud existují osvědčená řešení

3. **Zabezpečená komunikace**: Používejte HTTPS/TLS pro veškerou komunikaci s MCP serverem a zvažte přidání dalšího šifrování pro citlivá data.
   - Konfigurujte TLS 1.3, kde je to možné
   - Implementujte pinování certifikátů pro kritická spojení
   - Pravidelně měňte certifikáty a ověřujte jejich platnost

4. **Omezení rychlosti (Rate Limiting)**: Zavádějte omezení rychlosti, abyste zabránili zneužití, DoS útokům a lépe spravovali spotřebu zdrojů.
   - Nastavte vhodné limity požadavků podle očekávaných vzorců používání
   - Implementujte postupné reakce na nadměrné množství požadavků
   - Zvažte uživatelsky specifická omezení rychlosti na základě stavu autentizace

5. **Logování a monitorování**: Sledujte MCP server kvůli podezřelé aktivitě a implementujte komplexní auditní stopy.
   - Logujte všechny pokusy o autentizaci a volání nástrojů
   - Zavádějte upozornění v reálném čase na podezřelé vzory
   - Zajistěte bezpečné uložení logů, aby nebyly zneužitelné nebo pozměnitelné

6. **Bezpečné ukládání**: Chraňte citlivá data a přihlašovací údaje správným šifrováním v klidu.
   - Používejte key vaulty nebo bezpečné úložiště přihlašovacích údajů pro všechna tajemství
   - Implementujte šifrování na úrovni polí pro citlivá data
   - Pravidelně měňte šifrovací klíče a přihlašovací údaje

7. **Správa tokenů**: Zabraňte zranitelnostem při přenosu tokenů validací a sanitizací všech vstupů a výstupů modelu.
   - Implementujte validaci tokenů na základě audience claims
   - Nikdy nepřijímejte tokeny, které nejsou explicitně vydány pro váš MCP server
   - Zavádějte správu životnosti tokenů a jejich rotaci

8. **Správa relací**: Implementujte bezpečné zpracování relací, abyste zabránili únosu relace a útokům typu fixation.
   - Používejte bezpečné, nedeterministické ID relací
   - Vazujte relace na uživatelsky specifické informace
   - Zavádějte správné vypršení platnosti a rotaci relací

9. **Sandboxing spouštění nástrojů**: Spouštějte nástroje v izolovaných prostředích, abyste zabránili laterálnímu pohybu v případě kompromitace.
   - Implementujte izolaci kontejnerů pro spouštění nástrojů
   - Aplikujte limity zdrojů, aby se zabránilo útokům vyčerpáním zdrojů
   - Používejte oddělené kontexty pro různé bezpečnostní domény

10. **Pravidelné bezpečnostní audity**: Provádějte pravidelné bezpečnostní kontroly vašich implementací MCP a závislostí.
    - Plánujte pravidelné penetrační testy
    - Používejte automatizované skenovací nástroje k detekci zranitelností
    - Udržujte závislosti aktuální, aby byly řešeny známé bezpečnostní problémy

11. **Filtrování bezpečnosti obsahu**: Zavádějte filtry bezpečnosti obsahu pro vstupy i výstupy.
    - Používejte Azure Content Safety nebo podobné služby k detekci škodlivého obsahu
    - Implementujte techniky ochrany promptů proti injekci promptů
    - Kontrolujte generovaný obsah kvůli možnému úniku citlivých dat

12. **Bezpečnost dodavatelského řetězce**: Ověřujte integritu a autenticitu všech komponent ve vašem AI dodavatelském řetězci.
    - Používejte podepsané balíčky a ověřujte jejich podpisy
    - Implementujte analýzu software bill of materials (SBOM)
    - Sledujte škodlivé aktualizace závislostí

13. **Ochrana definic nástrojů**: Zabraňte „poisoningu“ nástrojů zabezpečením definic a metadat nástrojů.
    - Validujte definice nástrojů před jejich použitím
    - Sledujte neočekávané změny metadat nástrojů
    - Zavádějte kontroly integrity definic nástrojů

14. **Dynamické monitorování spouštění**: Sledujte chování MCP serverů a nástrojů za běhu.
    - Implementujte behaviorální analýzu k detekci anomálií
    - Nastavte upozornění na neočekávané vzory spouštění
    - Používejte techniky runtime application self-protection (RASP)

15. **Princip nejmenších oprávnění**: Zajistěte, aby MCP servery a nástroje fungovaly s minimálními potřebnými oprávněními.
    - Udělujte pouze konkrétní oprávnění potřebná pro každou operaci
    - Pravidelně kontrolujte a auditujte využití oprávnění
    - Implementujte přístup „just-in-time“ pro administrativní funkce

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.