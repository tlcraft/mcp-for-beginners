<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:57:25+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "cs"
}
-->
# 📖 MCP Základní koncepty: Ovládnutí Model Context Protocol pro integraci AI

Model Context Protocol (MCP) je silný, standardizovaný rámec, který optimalizuje komunikaci mezi velkými jazykovými modely (LLMs) a externími nástroji, aplikacemi a datovými zdroji. Tento SEO-optimalizovaný průvodce vás provede základními koncepty MCP, zajistí, že pochopíte jeho klient-server architekturu, základní komponenty, komunikační mechanismy a osvědčené postupy implementace.

## Přehled

Tato lekce zkoumá základní architekturu a komponenty, které tvoří ekosystém Model Context Protocol (MCP). Naučíte se o klient-server architektuře, klíčových komponentách a komunikačních mechanismech, které pohánějí interakce MCP.

## 👩‍🎓 Klíčové učební cíle

Na konci této lekce budete:

- Rozumět klient-server architektuře MCP.
- Identifikovat role a odpovědnosti hostitelů, klientů a serverů.
- Analyzovat klíčové funkce, které činí MCP flexibilní integrační vrstvou.
- Naučit se, jak informace proudí v ekosystému MCP.
- Získat praktické poznatky prostřednictvím ukázek kódu v .NET, Java, Python a JavaScript.

## 🔎 MCP Architektura: Podrobnější pohled

Ekosystém MCP je postaven na modelu klient-server. Tato modulární struktura umožňuje AI aplikacím efektivně komunikovat s nástroji, databázemi, API a kontextovými zdroji. Rozložme tuto architekturu na její základní komponenty.

### 1. Hostitelé

V Model Context Protocol (MCP) hrají hostitelé klíčovou roli jako primární rozhraní, skrze které uživatelé komunikují s protokolem. Hostitelé jsou aplikace nebo prostředí, které iniciují spojení s MCP servery pro přístup k datům, nástrojům a výzvám. Příklady hostitelů zahrnují integrovaná vývojová prostředí (IDEs) jako Visual Studio Code, AI nástroje jako Claude Desktop nebo agenti vytvoření na míru pro specifické úkoly.

**Hostitelé** jsou LLM aplikace, které iniciují spojení. Oni:

- Provádějí nebo komunikují s AI modely k vytváření odpovědí.
- Iniciují spojení s MCP servery.
- Řídí tok konverzace a uživatelské rozhraní.
- Kontrolují oprávnění a bezpečnostní omezení.
- Zpracovávají souhlas uživatele pro sdílení dat a provádění nástrojů.

### 2. Klienti

Klienti jsou nezbytné komponenty, které usnadňují interakci mezi hostiteli a MCP servery. Klienti působí jako zprostředkovatelé, umožňující hostitelům přístup k funkcionalitám poskytovaným MCP servery. Hrají klíčovou roli v zajištění hladké komunikace a efektivní výměny dat v architektuře MCP.

**Klienti** jsou konektory v rámci hostitelské aplikace. Oni:

- Posílají požadavky na servery s výzvami/instrukcemi.
- Vyjednávají schopnosti se servery.
- Řídí požadavky na provedení nástrojů od modelů.
- Zpracovávají a zobrazují odpovědi uživatelům.

### 3. Servery

Servery jsou zodpovědné za zpracování požadavků od MCP klientů a poskytování vhodných odpovědí. Řídí různé operace jako získávání dat, provádění nástrojů a generování výzev. Servery zajišťují, že komunikace mezi klienty a hostiteli je efektivní a spolehlivá, udržují integritu procesu interakce.

**Servery** jsou služby, které poskytují kontext a schopnosti. Oni:

- Registrují dostupné funkce (zdroje, výzvy, nástroje).
- Přijímají a provádějí volání nástrojů od klienta.
- Poskytují kontextové informace pro zlepšení odpovědí modelu.
- Vrací výstupy zpět klientovi.
- Udržují stav napříč interakcemi, když je to potřeba.

Servery mohou být vyvinuty kýmkoli, aby rozšířily schopnosti modelu s specializovanou funkcionalitou.

### 4. Funkce serveru

Servery v Model Context Protocol (MCP) poskytují základní stavební bloky, které umožňují bohaté interakce mezi klienty, hostiteli a jazykovými modely. Tyto funkce jsou navrženy tak, aby zlepšily schopnosti MCP nabídkou strukturovaného kontextu, nástrojů a výzev.

MCP servery mohou nabídnout některou z následujících funkcí:

#### 📑 Zdroje

Zdroje v Model Context Protocol (MCP) zahrnují různé typy kontextu a dat, které mohou být využity uživateli nebo AI modely. Ty zahrnují:

- **Kontextová data**: Informace a kontext, které uživatelé nebo AI modely mohou využít pro rozhodování a provádění úkolů.
- **Znalostní základny a úložiště dokumentů**: Kolekce strukturovaných a nestrukturovaných dat, jako jsou články, manuály a výzkumné práce, které poskytují hodnotné poznatky a informace.
- **Lokální soubory a databáze**: Data uložená lokálně na zařízeních nebo v rámci databází, dostupná pro zpracování a analýzu.
- **API a webové služby**: Externí rozhraní a služby, které nabízejí další data a funkce, umožňující integraci s různými online zdroji a nástroji.

Příklad zdroje může být schéma databáze nebo soubor, který lze přistupovat takto:

```text
file://log.txt
database://schema
```

### 🤖 Výzvy

Výzvy v Model Context Protocol (MCP) zahrnují různé předem definované šablony a interakční vzory navržené tak, aby zjednodušily uživatelské pracovní postupy a zlepšily komunikaci. Ty zahrnují:

- **Šablonované zprávy a pracovní postupy**: Předem strukturované zprávy a procesy, které vedou uživatele skrze specifické úkoly a interakce.
- **Předem definované interakční vzory**: Standardizované sekvence akcí a odpovědí, které usnadňují konzistentní a efektivní komunikaci.
- **Specializované šablony konverzací**: Přizpůsobitelné šablony navržené pro specifické typy konverzací, zajišťující relevantní a kontextově vhodné interakce.

Šablona výzvy může vypadat takto:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Nástroje

Nástroje v Model Context Protocol (MCP) jsou funkce, které AI model může provádět pro vykonání specifických úkolů. Tyto nástroje jsou navrženy tak, aby zlepšily schopnosti AI modelu poskytováním strukturovaných a spolehlivých operací. Klíčové aspekty zahrnují:

- **Funkce pro provedení AI modelem**: Nástroje jsou proveditelné funkce, které AI model může vyvolat pro vykonání různých úkolů.
- **Jedinečný název a popis**: Každý nástroj má jedinečný název a podrobný popis, který vysvětluje jeho účel a funkcionalitu.
- **Parametry a výstupy**: Nástroje přijímají specifické parametry a vrací strukturované výstupy, zajišťující konzistentní a předvídatelné výsledky.
- **Diskrétní funkce**: Nástroje provádějí diskrétní funkce jako webové vyhledávání, výpočty a dotazy do databáze.

Příklad nástroje může vypadat takto:

```typescript
server.tool(
  "GetProducts"
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Funkce klienta

V Model Context Protocol (MCP) nabízejí klienti několik klíčových funkcí serverům, zlepšujících celkovou funkcionalitu a interakci v rámci protokolu. Jednou z významných funkcí je Sampling.

### 👉 Sampling

- **Chování iniciované serverem**: Klienti umožňují serverům autonomně iniciovat specifické akce nebo chování, čímž zvyšují dynamické schopnosti systému.
- **Rekurzivní interakce LLM**: Tato funkce umožňuje rekurzivní interakce s velkými jazykovými modely (LLMs), umožňující složitější a iterativní zpracování úkolů.
- **Požadování dodatečných dokončení modelu**: Servery mohou požadovat dodatečné dokončení od modelu, zajišťující, že odpovědi jsou důkladné a kontextově relevantní.

## Tok informací v MCP

Model Context Protocol (MCP) definuje strukturovaný tok informací mezi hostiteli, klienty, servery a modely. Pochopení tohoto toku pomáhá objasnit, jak jsou uživatelské požadavky zpracovány a jak jsou externí nástroje a data integrovány do odpovědí modelu.

- **Hostitel iniciuje spojení**  
  Hostitelská aplikace (například IDE nebo chatovací rozhraní) naváže spojení s MCP serverem, obvykle přes STDIO, WebSocket nebo jiný podporovaný transport.

- **Vyjednávání schopností**  
  Klient (vestavěný v hostiteli) a server si vyměňují informace o svých podporovaných funkcích, nástrojích, zdrojích a verzích protokolu. To zajišťuje, že obě strany rozumí dostupným schopnostem pro danou relaci.

- **Uživatelský požadavek**  
  Uživatel interaguje s hostitelem (např. zadá výzvu nebo příkaz). Hostitel shromažďuje tento vstup a předává jej klientovi k zpracování.

- **Použití zdroje nebo nástroje**  
  - Klient může požadovat dodatečný kontext nebo zdroje od serveru (jako soubory, záznamy v databázi nebo články ze znalostní základny), aby obohatil porozumění modelu.
  - Pokud model určí, že je potřeba nástroj (např. k získání dat, provedení výpočtu nebo volání API), klient odešle žádost o vyvolání nástroje serveru, specifikující název nástroje a parametry.

- **Provedení serveru**  
  Server přijme žádost o zdroj nebo nástroj, provede potřebné operace (jako spuštění funkce, dotazování do databáze nebo získání souboru) a vrátí výsledky klientovi ve strukturovaném formátu.

- **Generování odpovědi**  
  Klient integruje odpovědi serveru (data zdroje, výstupy nástroje atd.) do probíhající interakce modelu. Model využívá tyto informace k vytvoření komplexní a kontextově relevantní odpovědi.

- **Prezentace výsledku**  
  Hostitel obdrží konečný výstup od klienta a prezentuje jej uživateli, často včetně jak textu generovaného modelem, tak jakýchkoli výsledků z provedení nástrojů nebo vyhledání zdrojů.

Tento tok umožňuje MCP podporovat pokročilé, interaktivní a kontextově vnímavé AI aplikace tím, že bezproblémově propojuje modely s externími nástroji a datovými zdroji.

## Detaily protokolu

MCP (Model Context Protocol) je postaven na vrcholu [JSON-RPC 2.0](https://www.jsonrpc.org/), poskytující standardizovaný, jazykově agnostický formát zpráv pro komunikaci mezi hostiteli, klienty a servery. Tento základ umožňuje spolehlivé, strukturované a rozšiřitelné interakce napříč různými platformami a programovacími jazyky.

### Klíčové vlastnosti protokolu

MCP rozšiřuje JSON-RPC 2.0 o další konvence pro vyvolání nástroje, přístup ke zdrojům a správu výzev. Podporuje více transportních vrstev (STDIO, WebSocket, SSE) a umožňuje bezpečnou, rozšiřitelnou a jazykově agnostickou komunikaci mezi komponenty.

#### 🧢 Základní protokol

- **Formát zpráv JSON-RPC**: Všechny požadavky a odpovědi používají specifikaci JSON-RPC 2.0, zajišťující konzistentní strukturu pro volání metod, parametry, výsledky a zpracování chyb.
- **Stavové spojení**: MCP relace udržují stav napříč více požadavky, podporující probíhající konverzace, akumulaci kontextu a správu zdrojů.
- **Vyjednávání schopností**: Během nastavení spojení si klienti a servery vyměňují informace o podporovaných funkcích, verzích protokolu, dostupných nástrojích a zdrojích. To zajišťuje, že obě strany rozumí schopnostem druhé strany a mohou se podle toho přizpůsobit.

#### ➕ Další nástroje

Níže jsou uvedeny některé další nástroje a rozšíření protokolu, které MCP poskytuje pro zlepšení zkušenosti vývojářů a umožnění pokročilých scénářů:

- **Možnosti konfigurace**: MCP umožňuje dynamickou konfiguraci parametrů relace, jako jsou oprávnění nástrojů, přístup ke zdrojům a nastavení modelu, přizpůsobená každé interakci.
- **Sledování pokroku**: Dlouhotrvající operace mohou hlásit aktualizace pokroku, umožňující responzivní uživatelská rozhraní a lepší uživatelskou zkušenost během složitých úkolů.
- **Zrušení požadavku**: Klienti mohou zrušit probíhající požadavky, umožňující uživatelům přerušit operace, které již nejsou potřebné nebo trvají příliš dlouho.
- **Zprávy o chybách**: Standardizované chybové zprávy a kódy pomáhají diagnostikovat problémy, řešit selhání elegantně a poskytovat akční zpětnou vazbu uživatelům a vývojářům.
- **Logování**: Klienti i servery mohou emitovat strukturované logy pro auditování, ladění a monitorování interakcí protokolu.

Využitím těchto vlastností protokolu MCP zajišťuje robustní, bezpečnou a flexibilní komunikaci mezi jazykovými modely a externími nástroji nebo datovými zdroji.

### 🔐 Bezpečnostní úvahy

Implementace MCP by měly dodržovat několik klíčových bezpečnostních principů, aby zajistily bezpečné a důvěryhodné interakce:

- **Souhlas a kontrola uživatele**: Uživatelé musí poskytnout explicitní souhlas před přístupem k jakýmkoli datům nebo prováděním operací. Měli by mít jasnou kontrolu nad tím, jaká data jsou sdílena a které akce jsou autorizovány, podporované intuitivními uživatelskými rozhraními pro kontrolu a schvalování aktivit.

- **Ochrana dat**: Uživatelská data by měla být vystavena pouze s explicitním souhlasem a musí být chráněna odpovídajícími kontrolami přístupu. Implementace MCP musí chránit proti neautorizovanému přenosu dat a zajistit, že soukromí je udržováno během všech interakcí.

- **Bezpečnost nástrojů**: Před vyvoláním jakéhokoli nástroje je vyžadován explicitní souhlas uživatele. Uživatelé by měli mít jasné porozumění funkcionalitě každého nástroje a musí být vynuceny robustní bezpečnostní hranice, aby se zabránilo neúmyslnému nebo nebezpečnému provedení nástroje.

Dodržováním těchto principů MCP zajišťuje, že důvěra, soukromí a bezpečnost uživatelů jsou udržovány napříč všemi interakcemi protokolu.

## Ukázky kódu: Klíčové komponenty

Níže jsou uvedeny ukázky kódu v několika populárních programovacích jazycích, které ukazují, jak implementovat klíčové komponenty serveru MCP a nástroje.

### Příklad .NET: Vytvoření jednoduchého MCP serveru s nástroji

Zde je praktický příklad kódu v .NET, který demonstruje, jak implementovat jednoduchý MCP server s vlastními nástroji. Tento příklad ukazuje, jak definovat

**Upozornění**:  
Tento dokument byl přeložen pomocí služby AI překladů [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Neodpovídáme za žádná nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.