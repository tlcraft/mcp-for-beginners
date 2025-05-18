<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e5ea5e7582f70008ea9bec3b3820f20a",
  "translation_date": "2025-05-17T14:31:27+00:00",
  "source_file": "04-PracticalImplementation/samples/java/containerapp/README.md",
  "language_code": "sk"
}
-->
## Architektúra systému

Tento projekt demonštruje webovú aplikáciu, ktorá používa kontrolu bezpečnosti obsahu pred tým, než odošle používateľské výzvy kalkulačnému servisu cez Model Context Protocol (MCP).

### Ako to funguje

1. **Vstup používateľa**: Používateľ zadá výzvu na výpočet do webového rozhrania.
2. **Kontrola bezpečnosti obsahu (Vstup)**: Výzva je analyzovaná pomocou Azure Content Safety API.
3. **Rozhodnutie o bezpečnosti (Vstup)**:
   - Ak je obsah bezpečný (závažnosť < 2 vo všetkých kategóriách), pokračuje k kalkulačke.
   - Ak je obsah označený ako potenciálne škodlivý, proces sa zastaví a vráti varovanie.
4. **Integrácia kalkulačky**: Bezpečný obsah je spracovaný LangChain4j, ktorý komunikuje s MCP kalkulačným serverom.
5. **Kontrola bezpečnosti obsahu (Výstup)**: Odpoveď bota je analyzovaná pomocou Azure Content Safety API.
6. **Rozhodnutie o bezpečnosti (Výstup)**:
   - Ak je odpoveď bota bezpečná, je zobrazená používateľovi.
   - Ak je odpoveď bota označená ako potenciálne škodlivá, je nahradená varovaním.
7. **Odpoveď**: Výsledky (ak sú bezpečné) sú zobrazené používateľovi spolu s oboma analýzami bezpečnosti.

## Použitie Model Context Protocol (MCP) s kalkulačnými službami

Tento projekt demonštruje, ako používať Model Context Protocol (MCP) na volanie kalkulačných MCP služieb z LangChain4j. Implementácia používa lokálny MCP server bežiaci na porte 8080 na poskytovanie kalkulačných operácií.

### Nastavenie služby Azure Content Safety

Pred použitím funkcií bezpečnosti obsahu je potrebné vytvoriť zdroj služby Azure Content Safety:

1. Prihláste sa do [Azure Portálu](https://portal.azure.com)
2. Kliknite na "Vytvoriť zdroj" a vyhľadajte "Content Safety"
3. Vyberte "Content Safety" a kliknite na "Vytvoriť"
4. Zadajte jedinečný názov pre váš zdroj
5. Vyberte svoje predplatné a skupinu zdrojov (alebo vytvorte novú)
6. Vyberte podporovanú oblasť (skontrolujte [Dostupnosť regiónov](https://azure.microsoft.com/en-us/global-infrastructure/services/?products=cognitive-services) pre podrobnosti)
7. Vyberte vhodnú cenovú úroveň
8. Kliknite na "Vytvoriť" na nasadenie zdroja
9. Po dokončení nasadenia kliknite na "Prejsť na zdroj"
10. V ľavom paneli, pod "Správa zdrojov", vyberte "Kľúče a koncový bod"
11. Skopírujte jeden z kľúčov a URL koncového bodu pre použitie v ďalšom kroku

### Konfigurácia environmentálnych premenných

Nastavte environmentálnu premennú `GITHUB_TOKEN` pre autentifikáciu GitHub modelov:
```sh
export GITHUB_TOKEN=<your_github_token>
```

Pre funkcie bezpečnosti obsahu nastavte:
```sh
export CONTENT_SAFETY_ENDPOINT=<your_content_safety_endpoint>
export CONTENT_SAFETY_KEY=<your_content_safety_key>
```

Tieto environmentálne premenné sú používané aplikáciou na autentifikáciu so službou Azure Content Safety. Ak tieto premenné nie sú nastavené, aplikácia použije hodnoty zástupcov pre demonštračné účely, ale funkcie bezpečnosti obsahu nebudú fungovať správne.

### Spustenie kalkulačného MCP servera

Pred spustením klienta je potrebné spustiť kalkulačný MCP server v SSE móde na localhost:8080.

## Popis projektu

Tento projekt demonštruje integráciu Model Context Protocol (MCP) s LangChain4j na volanie kalkulačných služieb. Kľúčové funkcie zahŕňajú:

- Použitie MCP na pripojenie ku kalkulačnej službe pre základné matematické operácie
- Dvojvrstvová kontrola bezpečnosti obsahu na používateľských výzvach a odpovediach bota
- Integrácia s GitHub modelom gpt-4.1-nano cez LangChain4j
- Použitie Server-Sent Events (SSE) pre MCP prenos

## Integrácia bezpečnosti obsahu

Projekt zahŕňa komplexné funkcie bezpečnosti obsahu na zabezpečenie, že používateľské vstupy a systémové odpovede sú bez škodlivého obsahu:

1. **Kontrola vstupu**: Všetky používateľské výzvy sú analyzované na kategórie škodlivého obsahu, ako je nenávistná reč, násilie, sebapoškodzovanie a sexuálny obsah pred spracovaním.

2. **Kontrola výstupu**: Aj pri použití potenciálne necenzurovaných modelov systém kontroluje všetky generované odpovede cez rovnaké filtre bezpečnosti obsahu pred ich zobrazením používateľovi.

Tento dvojvrstvový prístup zabezpečuje, že systém zostáva bezpečný bez ohľadu na to, ktorý AI model sa používa, chrániac používateľov pred škodlivými vstupmi a potenciálne problematickými AI-generovanými výstupmi.

## Webový klient

Aplikácia obsahuje používateľsky prívetivé webové rozhranie, ktoré umožňuje používateľom interakciu so systémom Content Safety Calculator:

### Funkcie webového rozhrania

- Jednoduchý, intuitívny formulár na zadanie výziev na výpočet
- Dvojvrstvová validácia bezpečnosti obsahu (vstup a výstup)
- Okamžitá spätná väzba o bezpečnosti výzvy a odpovede
- Farebne kódované indikátory bezpečnosti pre jednoduchú interpretáciu
- Čistý, responzívny dizajn, ktorý funguje na rôznych zariadeniach
- Príklady bezpečných výziev na usmernenie používateľov

### Použitie webového klienta

1. Spustite aplikáciu:
   ```sh
   mvn spring-boot:run
   ```

2. Otvorte prehliadač a prejdite na `http://localhost:8087`

3. Zadajte výzvu na výpočet do poskytnutého textového poľa (napr. "Vypočítaj súčet 24.5 a 17.3")

4. Kliknite na "Odoslať" na spracovanie vašej požiadavky

5. Zobraziť výsledky, ktoré budú obsahovať:
   - Analýzu bezpečnosti obsahu vašej výzvy
   - Vypočítaný výsledok (ak bola výzva bezpečná)
   - Analýzu bezpečnosti obsahu odpovede bota
   - Akékoľvek varovania o bezpečnosti, ak bol označený buď vstup alebo výstup

Webový klient automaticky spracováva oba procesy verifikácie bezpečnosti obsahu, čím zabezpečuje, že všetky interakcie sú bezpečné a vhodné bez ohľadu na to, ktorý AI model sa používa.

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladovej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, uvedomte si, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho pôvodnom jazyku by sa mal považovať za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nezodpovedáme za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.