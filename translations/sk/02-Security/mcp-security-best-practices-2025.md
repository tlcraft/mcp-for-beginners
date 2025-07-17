<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T13:46:09+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "sk"
}
-->
# Najlepšie bezpečnostné postupy pre MCP – aktualizácia júl 2025

## Komplexné bezpečnostné postupy pre implementácie MCP

Pri práci so servermi MCP dodržiavajte tieto bezpečnostné postupy na ochranu svojich dát, infraštruktúry a používateľov:

1. **Validácia vstupov**: Vždy overujte a čistite vstupy, aby ste predišli injekčným útokom a problémom s nejasným oprávnením.
   - Zavádzajte prísnu validáciu všetkých parametrov nástrojov
   - Používajte schémové overovanie, aby požiadavky zodpovedali očakávaným formátom
   - Filtrovať potenciálne škodlivý obsah pred spracovaním

2. **Riadenie prístupu**: Implementujte správnu autentifikáciu a autorizáciu pre váš MCP server s jemnozrnnými oprávneniami.
   - Používajte OAuth 2.0 s overenými poskytovateľmi identity, ako je Microsoft Entra ID
   - Zavádzajte riadenie prístupu na základe rolí (RBAC) pre MCP nástroje
   - Nikdy nevytvárajte vlastnú autentifikáciu, ak existujú overené riešenia

3. **Bezpečná komunikácia**: Používajte HTTPS/TLS pre všetku komunikáciu s MCP serverom a zvážte dodatočné šifrovanie citlivých údajov.
   - Konfigurujte TLS 1.3, kde je to možné
   - Zavádzajte pripínanie certifikátov pre kritické spojenia
   - Pravidelne obnovujte certifikáty a overujte ich platnosť

4. **Obmedzovanie rýchlosti (Rate Limiting)**: Zavádzajte obmedzenia rýchlosti, aby ste zabránili zneužitiu, DoS útokom a riadili spotrebu zdrojov.
   - Nastavte primerané limity požiadaviek podľa očakávaných vzorcov používania
   - Zavádzajte stupňované reakcie na nadmerné požiadavky
   - Zvážte používateľsky špecifické limity podľa stavu autentifikácie

5. **Zaznamenávanie a monitorovanie**: Sledujte MCP server pre podozrivé aktivity a implementujte komplexné audítorské záznamy.
   - Zaznamenávajte všetky pokusy o autentifikáciu a spustenie nástrojov
   - Zavádzajte upozornenia v reálnom čase na podozrivé vzory
   - Zabezpečte, aby záznamy boli bezpečne uložené a nebolo možné ich meniť

6. **Bezpečné ukladanie**: Chráňte citlivé údaje a prihlasovacie údaje správnym šifrovaním v pokoji.
   - Používajte kľúčové trezory alebo bezpečné úložiská pre všetky tajomstvá
   - Zavádzajte šifrovanie na úrovni polí pre citlivé údaje
   - Pravidelne obnovujte šifrovacie kľúče a prihlasovacie údaje

7. **Správa tokenov**: Predchádzajte zraniteľnostiam pri prenose tokenov overovaním a čistením všetkých vstupov a výstupov modelov.
   - Zavádzajte overovanie tokenov na základe audience claims
   - Nikdy neprijímajte tokeny, ktoré neboli výslovne vydané pre váš MCP server
   - Implementujte správu životnosti tokenov a ich rotáciu

8. **Správa relácií**: Zavádzajte bezpečné spracovanie relácií, aby ste predišli únosu alebo fixácii relácie.
   - Používajte bezpečné, nedeterministické ID relácií
   - Viažte relácie na používateľsky špecifické informácie
   - Zavádzajte správne vypršanie platnosti a rotáciu relácií

9. **Izolácia vykonávania nástrojov**: Spúšťajte nástroje v izolovaných prostrediach, aby ste zabránili laterálnemu pohybu v prípade kompromitácie.
   - Zavádzajte izoláciu kontajnerov pre vykonávanie nástrojov
   - Uplatňujte limity zdrojov, aby ste predišli útokom vyčerpania zdrojov
   - Používajte samostatné kontexty vykonávania pre rôzne bezpečnostné domény

10. **Pravidelné bezpečnostné audity**: Pravidelne vykonávajte bezpečnostné kontroly vašich implementácií MCP a závislostí.
    - Plánujte pravidelné penetračné testy
    - Používajte automatizované nástroje na detekciu zraniteľností
    - Udržiavajte závislosti aktualizované, aby ste riešili známe bezpečnostné problémy

11. **Filtrovanie bezpečnosti obsahu**: Zavádzajte filtre bezpečnosti obsahu pre vstupy aj výstupy.
    - Používajte Azure Content Safety alebo podobné služby na detekciu škodlivého obsahu
    - Zavádzajte techniky ochrany promptov proti injekcii
    - Skúmajte generovaný obsah na možné úniky citlivých údajov

12. **Bezpečnosť dodávateľského reťazca**: Overujte integritu a pravosť všetkých komponentov vo vašom AI dodávateľskom reťazci.
    - Používajte podpísané balíčky a overujte podpisy
    - Zavádzajte analýzu softvérového zoznamu materiálov (SBOM)
    - Sledujte škodlivé aktualizácie závislostí

13. **Ochrana definícií nástrojov**: Predchádzajte otrave nástrojov zabezpečením definícií a metadát nástrojov.
    - Overujte definície nástrojov pred ich použitím
    - Sledujte neočakávané zmeny v metadátach nástrojov
    - Zavádzajte kontroly integrity definícií nástrojov

14. **Dynamické monitorovanie vykonávania**: Sledujte správanie MCP serverov a nástrojov počas behu.
    - Zavádzajte behaviorálnu analýzu na detekciu anomálií
    - Nastavte upozornenia na neočakávané vzory vykonávania
    - Používajte techniky runtime application self-protection (RASP)

15. **Princíp minimálnych oprávnení**: Zabezpečte, aby MCP servery a nástroje fungovali s minimálnymi potrebnými oprávneniami.
    - Udeľujte len konkrétne oprávnenia potrebné pre každú operáciu
    - Pravidelne kontrolujte a auditujte používanie oprávnení
    - Zavádzajte prístup „just-in-time“ pre administratívne funkcie

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.