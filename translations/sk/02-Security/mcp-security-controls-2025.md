<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T13:39:12+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "sk"
}
-->
# MCP Bezpečnostné Kontroly - Aktualizácia August 2025

> **Aktuálny Štandard**: Tento dokument odráža bezpečnostné požiadavky [MCP Špecifikácie 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) a oficiálne [MCP Bezpečnostné Najlepšie Praktiky](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices).

Model Context Protocol (MCP) sa výrazne vyvinul s vylepšenými bezpečnostnými kontrolami, ktoré riešia tradičné softvérové bezpečnostné hrozby aj hrozby špecifické pre AI. Tento dokument poskytuje komplexné bezpečnostné kontroly pre bezpečné implementácie MCP k augustu 2025.

## Overovanie a autorizácia

### Podpora delegácie OAuth 2.0

Nedávne aktualizácie špecifikácie MCP teraz umožňujú MCP serverom delegovať overovanie používateľov na externé služby, ako je Microsoft Entra ID. Toto výrazne zlepšuje bezpečnostnú úroveň tým, že:

1. **Odstraňuje potrebu vlastnej implementácie overovania**: Znižuje riziko bezpečnostných chýb v kóde overovania
2. **Využíva etablovaných poskytovateľov identity**: Využíva bezpečnostné funkcie na úrovni podnikov
3. **Centralizuje správu identity**: Zjednodušuje správu životného cyklu používateľov a kontrolu prístupu

## Prevencia prenosu tokenov

Špecifikácia autorizácie MCP výslovne zakazuje prenos tokenov, aby sa zabránilo obchádzaniu bezpečnostných opatrení a problémom s zodpovednosťou.

### Kľúčové požiadavky

1. **MCP servery NESMÚ akceptovať tokeny nevydané pre ne**: Overte, že všetky tokeny majú správny parameter audience
2. **Implementujte správnu validáciu tokenov**: Skontrolujte vydavateľa, audience, platnosť a podpis
3. **Používajte samostatné vydávanie tokenov**: Vydávajte nové tokeny pre downstream služby namiesto prenosu existujúcich tokenov

## Bezpečná správa relácií

Aby sa zabránilo únosu alebo fixácii relácie, implementujte nasledujúce opatrenia:

1. **Používajte bezpečné, nedeterministické ID relácií**: Generované kryptograficky bezpečnými generátormi náhodných čísel
2. **Viažte relácie na identitu používateľa**: Kombinujte ID relácie s informáciami špecifickými pre používateľa
3. **Implementujte správnu rotáciu relácií**: Po zmene overenia alebo eskalácii oprávnení
4. **Nastavte primerané časové limity relácií**: Vyvážte bezpečnosť a používateľský komfort

## Izolácia vykonávania nástrojov

Aby sa zabránilo laterálnemu pohybu a obmedzili možné kompromisy:

1. **Izolujte prostredia vykonávania nástrojov**: Používajte kontajnery alebo samostatné procesy
2. **Aplikujte limity zdrojov**: Zabraňte útokom vyčerpania zdrojov
3. **Implementujte prístup s najmenšími oprávneniami**: Udeľujte len nevyhnutné povolenia
4. **Monitorujte vzory vykonávania**: Detekujte anomálne správanie

## Ochrana definícií nástrojov

Aby sa zabránilo otráveniu nástrojov:

1. **Validujte definície nástrojov pred použitím**: Skontrolujte prítomnosť škodlivých inštrukcií alebo nevhodných vzorov
2. **Používajte overovanie integrity**: Hashujte alebo podpisujte definície nástrojov na detekciu neoprávnených zmien
3. **Implementujte monitorovanie zmien**: Upozorňujte na neočakávané úpravy metadát nástrojov
4. **Verzujte definície nástrojov**: Sledujte zmeny a umožnite návrat k predchádzajúcim verziám v prípade potreby

Tieto kontroly spoločne vytvárajú pevný bezpečnostný základ pre implementácie MCP, riešiac jedinečné výzvy systémov riadených AI a zároveň zachovávajúc silné tradičné bezpečnostné postupy.

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.