<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T13:39:01+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "cs"
}
-->
# Nejnovější bezpečnostní kontroly MCP – aktualizace červenec 2025

S dalším vývojem Model Context Protocolu (MCP) zůstává bezpečnost klíčovou prioritou. Tento dokument shrnuje nejnovější bezpečnostní kontroly a osvědčené postupy pro bezpečnou implementaci MCP k červenci 2025.

## Autentizace a autorizace

### Podpora delegace OAuth 2.0

Nedávné aktualizace specifikace MCP nyní umožňují MCP serverům delegovat autentizaci uživatelů na externí služby, jako je Microsoft Entra ID. To výrazně zlepšuje bezpečnostní úroveň tím, že:

1. **Odstraňuje potřebu vlastní implementace autentizace**: Snižuje riziko bezpečnostních chyb v uživatelském autentizačním kódu  
2. **Využívá zavedené poskytovatele identity**: Využívá bezpečnostní funkce na úrovni podniku  
3. **Centralizuje správu identity**: Zjednodušuje správu životního cyklu uživatelů a řízení přístupu  

## Prevence průchodu tokenů

Specifikace autorizace MCP výslovně zakazuje průchod tokenů, aby se zabránilo obcházení bezpečnostních kontrol a problémům s odpovědností.

### Klíčové požadavky

1. **MCP servery NESMÍ přijímat tokeny nevydané pro ně**: Ověřte, že všechny tokeny mají správný audience claim  
2. **Implementujte správnou validaci tokenů**: Kontrola vydavatele, audience, expirace a podpisu  
3. **Používejte samostatné vydávání tokenů**: Vydávejte nové tokeny pro downstream služby místo předávání existujících tokenů  

## Bezpečná správa relací

Aby se zabránilo únosu relace a útokům na fixaci relace, implementujte následující opatření:

1. **Používejte bezpečné, nedeterministické ID relací**: Generované kryptograficky bezpečnými generátory náhodných čísel  
2. **Vazba relací na identitu uživatele**: Kombinujte ID relace s uživatelsky specifickými informacemi  
3. **Implementujte správnou rotaci relací**: Po změně autentizace nebo zvýšení oprávnění  
4. **Nastavte vhodné časové limity relací**: Vyvážení bezpečnosti a uživatelského komfortu  

## Izolace spouštění nástrojů

Aby se zabránilo laterálnímu pohybu a omezilo možné kompromitace:

1. **Izolujte prostředí pro spouštění nástrojů**: Používejte kontejnery nebo samostatné procesy  
2. **Aplikujte limity zdrojů**: Zabraňte útokům vyčerpáním zdrojů  
3. **Implementujte princip nejmenších oprávnění**: Udělujte pouze nezbytná oprávnění  
4. **Monitorujte vzory spouštění**: Detekujte anomální chování  

## Ochrana definic nástrojů

Aby se zabránilo „poisoningu“ nástrojů:

1. **Validujte definice nástrojů před použitím**: Kontrola na škodlivé instrukce nebo nevhodné vzory  
2. **Používejte ověřování integrity**: Hashování nebo podepisování definic nástrojů pro detekci neoprávněných změn  
3. **Implementujte sledování změn**: Upozornění na neočekávané úpravy metadat nástrojů  
4. **Verzujte definice nástrojů**: Sledujte změny a umožněte návrat k předchozím verzím  

Tyto kontroly společně vytvářejí pevný bezpečnostní rámec pro implementace MCP, řeší jedinečné výzvy systémů řízených umělou inteligencí a zároveň zachovávají silné tradiční bezpečnostní postupy.

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.