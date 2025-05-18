<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e5ea5e7582f70008ea9bec3b3820f20a",
  "translation_date": "2025-05-17T14:31:07+00:00",
  "source_file": "04-PracticalImplementation/samples/java/containerapp/README.md",
  "language_code": "cs"
}
-->
## Architektura systému

Tento projekt demonstruje webovou aplikaci, která používá kontrolu bezpečnosti obsahu před odesláním uživatelských požadavků kalkulační službě prostřednictvím Model Context Protocol (MCP).

### Jak to funguje

1. **Uživatelský vstup**: Uživatel zadá požadavek na výpočet do webového rozhraní.
2. **Kontrola bezpečnosti obsahu (vstup)**: Požadavek je analyzován pomocí Azure Content Safety API.
3. **Rozhodnutí o bezpečnosti (vstup)**:
   - Pokud je obsah bezpečný (závažnost < 2 ve všech kategoriích), pokračuje ke kalkulačce.
   - Pokud je obsah označen jako potenciálně škodlivý, proces se zastaví a vrátí se varování.
4. **Integrace kalkulačky**: Bezpečný obsah je zpracován LangChain4j, který komunikuje s MCP serverem kalkulačky.
5. **Kontrola bezpečnosti obsahu (výstup)**: Odezva botu je analyzována pomocí Azure Content Safety API.
6. **Rozhodnutí o bezpečnosti (výstup)**:
   - Pokud je odezva botu bezpečná, je zobrazena uživateli.
   - Pokud je odezva botu označena jako potenciálně škodlivá, je nahrazena varováním.
7. **Odezva**: Výsledky (pokud jsou bezpečné) jsou zobrazeny uživateli spolu s oběma analýzami bezpečnosti.

## Použití Model Context Protocol (MCP) s kalkulačními službami

Tento projekt demonstruje, jak používat Model Context Protocol (MCP) k volání kalkulačních MCP služeb z LangChain4j. Implementace používá lokální MCP server běžící na portu 8080 k poskytování kalkulačních operací.

### Nastavení služby Azure Content Safety

Než začnete používat funkce bezpečnosti obsahu, musíte vytvořit zdroj služby Azure Content Safety:

1. Přihlaste se do [Azure Portal](https://portal.azure.com)
2. Klikněte na "Vytvořit zdroj" a vyhledejte "Content Safety"
3. Vyberte "Content Safety" a klikněte na "Vytvořit"
4. Zadejte jedinečný název pro váš zdroj
5. Vyberte vaše předplatné a skupinu zdrojů (nebo vytvořte novou)
6. Vyberte podporovaný region (zjistěte [Dostupnost regionů](https://azure.microsoft.com/en-us/global-infrastructure/services/?products=cognitive-services) pro podrobnosti)
7. Vyberte vhodnou cenovou úroveň
8. Klikněte na "Vytvořit" pro nasazení zdroje
9. Po dokončení nasazení klikněte na "Přejít ke zdroji"
10. V levém panelu, pod "Správa zdrojů", vyberte "Klíče a koncový bod"
11. Zkopírujte jeden z klíčů a URL koncového bodu pro použití v dalším kroku

### Konfigurace proměnných prostředí

Nastavte proměnnou `GITHUB_TOKEN` prostředí pro autentizaci GitHub modelů:
```sh
export GITHUB_TOKEN=<your_github_token>
```

Pro funkce bezpečnosti obsahu nastavte:
```sh
export CONTENT_SAFETY_ENDPOINT=<your_content_safety_endpoint>
export CONTENT_SAFETY_KEY=<your_content_safety_key>
```

Tyto proměnné prostředí jsou používány aplikací k autentizaci s Azure Content Safety službou. Pokud tyto proměnné nejsou nastaveny, aplikace použije hodnoty zástupných znaků pro demonstrační účely, ale funkce bezpečnosti obsahu nebudou fungovat správně.

### Spuštění MCP serveru kalkulačky

Než spustíte klienta, musíte spustit MCP server kalkulačky v režimu SSE na localhost:8080.

## Popis projektu

Tento projekt demonstruje integraci Model Context Protocol (MCP) s LangChain4j k volání kalkulačních služeb. Klíčové vlastnosti zahrnují:

- Použití MCP k připojení ke kalkulační službě pro základní matematické operace
- Dvouúrovňovou kontrolu bezpečnosti obsahu jak na uživatelských požadavcích, tak na odezvách botu
- Integraci s modelem GitHub gpt-4.1-nano prostřednictvím LangChain4j
- Použití Server-Sent Events (SSE) pro MCP transport

## Integrace bezpečnosti obsahu

Projekt zahrnuje komplexní funkce bezpečnosti obsahu, aby bylo zajištěno, že jak uživatelské vstupy, tak systémové odezvy jsou bez škodlivého obsahu:

1. **Kontrola vstupu**: Všechny uživatelské požadavky jsou analyzovány na škodlivé kategorie obsahu, jako je nenávistná řeč, násilí, sebepoškozování a sexuální obsah před zpracováním.

2. **Kontrola výstupu**: I při použití potenciálně necenzurovaných modelů systém kontroluje všechny generované odezvy přes stejné filtry bezpečnosti obsahu před jejich zobrazením uživateli.

Tento dvouúrovňový přístup zajišťuje, že systém zůstane bezpečný bez ohledu na to, který AI model je používán, chrání uživatele před škodlivými vstupy i potenciálně problematickými AI generovanými výstupy.

## Webový klient

Aplikace zahrnuje uživatelsky přívětivé webové rozhraní, které umožňuje uživatelům interakci se systémem Content Safety Calculator:

### Vlastnosti webového rozhraní

- Jednoduchý, intuitivní formulář pro zadání požadavků na výpočet
- Dvouúrovňová validace bezpečnosti obsahu (vstup a výstup)
- Okamžitá zpětná vazba o bezpečnosti požadavku a odezvy
- Barevně kódované indikátory bezpečnosti pro snadnou interpretaci
- Čistý, responzivní design, který funguje na různých zařízeních
- Příklady bezpečných požadavků k vedení uživatelů

### Použití webového klienta

1. Spusťte aplikaci:
   ```sh
   mvn spring-boot:run
   ```

2. Otevřete prohlížeč a přejděte na `http://localhost:8087`

3. Zadejte požadavek na výpočet do poskytnutého textového pole (např. "Spočítejte součet 24.5 a 17.3")

4. Klikněte na "Odeslat" pro zpracování vaší žádosti

5. Zobrazte výsledky, které budou zahrnovat:
   - Analýzu bezpečnosti obsahu vašeho požadavku
   - Vypočtený výsledek (pokud byl požadavek bezpečný)
   - Analýzu bezpečnosti obsahu odezvy botu
   - Jakákoli varování o bezpečnosti, pokud byl buď vstup nebo výstup označen

Webový klient automaticky zpracovává oba procesy ověřování bezpečnosti obsahu, zajišťuje, že všechny interakce jsou bezpečné a vhodné bez ohledu na to, který AI model je používán.

**Prohlášení**:  
Tento dokument byl přeložen pomocí AI překladové služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro důležité informace je doporučen profesionální lidský překlad. Nejsme zodpovědní za jakékoli nedorozumění nebo mylné interpretace vyplývající z použití tohoto překladu.