<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "057dd5cc6bea6434fdb788e6c93f3f3d",
  "translation_date": "2025-08-18T15:29:14+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "sk"
}
-->
# MCP Bezpečnostné Najlepšie Praktiky - Aktualizácia August 2025

> **Dôležité**: Tento dokument odráža najnovšie [MCP Špecifikácie 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) bezpečnostné požiadavky a oficiálne [MCP Bezpečnostné Najlepšie Praktiky](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices). Vždy sa odvolávajte na aktuálnu špecifikáciu pre najnovšie odporúčania.

## Základné Bezpečnostné Praktiky pre MCP Implementácie

Model Context Protocol prináša jedinečné bezpečnostné výzvy, ktoré presahujú tradičné softvérové bezpečnostné opatrenia. Tieto praktiky sa zaoberajú základnými bezpečnostnými požiadavkami a MCP-špecifickými hrozbami, vrátane injekcie príkazov, otravy nástrojov, únosu relácií, problémov zmätku zástupcu a zraniteľností pri prenose tokenov.

### **POVINNÉ Bezpečnostné Požiadavky**

**Kritické Požiadavky zo Špecifikácie MCP:**

> **NESMIE**: MCP servery **NESMÚ** akceptovať žiadne tokeny, ktoré neboli výslovne vydané pre MCP server  
> 
> **MUSÍ**: MCP servery implementujúce autorizáciu **MUSIA** overiť VŠETKY prichádzajúce požiadavky  
>  
> **NESMIE**: MCP servery **NESMÚ** používať relácie na autentifikáciu  
>
> **MUSÍ**: MCP proxy servery používajúce statické ID klientov **MUSIA** získať súhlas používateľa pre každého dynamicky registrovaného klienta  

---

## 1. **Bezpečnosť Tokenov & Autentifikácia**

**Kontroly Autentifikácie & Autorizácie:**  
   - **Dôkladná Kontrola Autorizácie**: Vykonajte komplexné audity logiky autorizácie MCP servera, aby ste zabezpečili, že iba zamýšľaní používatelia a klienti majú prístup k zdrojom  
   - **Integrácia Externého Poskytovateľa Identity**: Používajte etablovaných poskytovateľov identity, ako je Microsoft Entra ID, namiesto implementácie vlastnej autentifikácie  
   - **Validácia Publikum Tokenov**: Vždy overte, že tokeny boli výslovne vydané pre váš MCP server - nikdy neakceptujte tokeny z iných zdrojov  
   - **Správny Životný Cyklus Tokenov**: Implementujte bezpečnú rotáciu tokenov, politiky expirácie a zabráňte útokom na opakovanie tokenov  

**Chránené Ukladanie Tokenov:**  
   - Používajte Azure Key Vault alebo podobné bezpečné úložiská pre všetky tajomstvá  
   - Implementujte šifrovanie tokenov v pokoji aj počas prenosu  
   - Pravidelná rotácia poverení a monitorovanie neoprávneného prístupu  

## 2. **Správa Relácií & Bezpečnosť Prenosu**

**Bezpečné Praktiky Relácií:**  
   - **Kryptograficky Bezpečné ID Relácií**: Používajte bezpečné, nedeterministické ID relácií generované pomocou bezpečných generátorov náhodných čísel  
   - **Väzba na Používateľa**: Viažte ID relácií na identity používateľov pomocou formátov ako `<user_id>:<session_id>` na zabránenie zneužitia relácií medzi používateľmi  
   - **Správa Životného Cyklu Relácií**: Implementujte správnu expiráciu, rotáciu a zneplatnenie na obmedzenie zraniteľných okien  
   - **Povinné HTTPS/TLS**: Povinné HTTPS pre všetku komunikáciu na zabránenie zachytenia ID relácií  

**Bezpečnosť Transportnej Vrstvy:**  
   - Konfigurujte TLS 1.3, kde je to možné, s riadnou správou certifikátov  
   - Implementujte pripínanie certifikátov pre kritické spojenia  
   - Pravidelná rotácia certifikátov a overovanie ich platnosti  

## 3. **Ochrana Pred AI-Špecifickými Hrozbami** 🤖

**Obrana Proti Injekcii Príkazov:**  
   - **Microsoft Prompt Shields**: Nasadzujte AI Prompt Shields na pokročilú detekciu a filtrovanie škodlivých inštrukcií  
   - **Sanitácia Vstupov**: Validujte a čistite všetky vstupy na zabránenie útokom injekcie a problémom zmätku zástupcu  
   - **Obsahové Hranice**: Používajte systémy oddelovačov a označovania dát na rozlíšenie medzi dôveryhodnými inštrukciami a externým obsahom  

**Prevencia Otravy Nástrojov:**  
   - **Validácia Metadát Nástrojov**: Implementujte kontroly integrity definícií nástrojov a monitorujte neočakávané zmeny  
   - **Dynamické Monitorovanie Nástrojov**: Monitorujte správanie počas behu a nastavte upozornenia na neočakávané vzory vykonávania  
   - **Schvaľovacie Procesy**: Vyžadujte výslovné schválenie používateľom pre úpravy nástrojov a zmeny schopností  

## 4. **Kontrola Prístupu & Oprávnení**

**Princíp Najmenších Oprávnení:**  
   - Poskytujte MCP serverom iba minimálne oprávnenia potrebné na zamýšľanú funkčnosť  
   - Implementujte kontrolu prístupu založenú na rolách (RBAC) s jemne zrnitými oprávneniami  
   - Pravidelné revízie oprávnení a nepretržité monitorovanie eskalácie oprávnení  

**Kontroly Oprávnení Počas Behom:**  
   - Aplikujte limity zdrojov na zabránenie útokom na vyčerpanie zdrojov  
   - Používajte izoláciu kontajnerov pre prostredia vykonávania nástrojov  
   - Implementujte prístup „just-in-time“ pre administratívne funkcie  

## 5. **Bezpečnosť Obsahu & Monitorovanie**

**Implementácia Bezpečnosti Obsahu:**  
   - **Integrácia Azure Content Safety**: Používajte Azure Content Safety na detekciu škodlivého obsahu, pokusov o jailbreak a porušení politiky  
   - **Behaviorálna Analýza**: Implementujte monitorovanie správania počas behu na detekciu anomálií v MCP serveri a vykonávaní nástrojov  
   - **Komplexné Logovanie**: Logujte všetky pokusy o autentifikáciu, vyvolania nástrojov a bezpečnostné udalosti s bezpečným, nezmeniteľným úložiskom  

**Nepretržité Monitorovanie:**  
   - Upozornenia v reálnom čase na podozrivé vzory a pokusy o neoprávnený prístup  
   - Integrácia so SIEM systémami na centralizované riadenie bezpečnostných udalostí  
   - Pravidelné bezpečnostné audity a penetračné testovanie MCP implementácií  

## 6. **Bezpečnosť Dodávateľského Reťazca**

**Overovanie Komponentov:**  
   - **Skenovanie Závislostí**: Používajte automatizované skenovanie zraniteľností pre všetky softvérové závislosti a AI komponenty  
   - **Validácia Pôvodu**: Overujte pôvod, licencovanie a integritu modelov, zdrojov dát a externých služieb  
   - **Podpísané Balíčky**: Používajte kryptograficky podpísané balíčky a overujte podpisy pred nasadením  

**Bezpečný Vývojový Pipeline:**  
   - **GitHub Advanced Security**: Implementujte skenovanie tajomstiev, analýzu závislostí a statickú analýzu CodeQL  
   - **Bezpečnosť CI/CD**: Integrujte bezpečnostné validácie do automatizovaných pipeline nasadenia  
   - **Integrita Artefaktov**: Implementujte kryptografické overovanie nasadených artefaktov a konfigurácií  

## 7. **OAuth Bezpečnosť & Prevencia Zmätku Zástupcu**

**Implementácia OAuth 2.1:**  
   - **Implementácia PKCE**: Používajte Proof Key for Code Exchange (PKCE) pre všetky požiadavky na autorizáciu  
   - **Výslovný Súhlas**: Získajte súhlas používateľa pre každého dynamicky registrovaného klienta na zabránenie útokom zmätku zástupcu  
   - **Validácia URI Presmerovania**: Implementujte prísnu validáciu URI presmerovania a identifikátorov klientov  

**Bezpečnosť Proxy:**  
   - Zabráňte obchádzaniu autorizácie prostredníctvom zneužitia statického ID klienta  
   - Implementujte správne pracovné postupy súhlasu pre prístup k API tretích strán  
   - Monitorujte krádež autorizačných kódov a neoprávnený prístup k API  

## 8. **Reakcia na Incidenty & Obnova**

**Schopnosti Rýchlej Reakcie:**  
   - **Automatizovaná Reakcia**: Implementujte automatizované systémy na rotáciu poverení a obmedzenie hrozieb  
   - **Postupy Návratu**: Schopnosť rýchlo sa vrátiť k známym dobrým konfiguráciám a komponentom  
   - **Forenzné Schopnosti**: Detailné auditné stopy a logovanie na vyšetrovanie incidentov  

**Komunikácia & Koordinácia:**  
   - Jasné postupy eskalácie pre bezpečnostné incidenty  
   - Integrácia s organizačnými tímami reakcie na incidenty  
   - Pravidelné simulácie bezpečnostných incidentov a cvičenia na stole  

## 9. **Súlad & Správa**

**Regulačný Súlad:**  
   - Zabezpečte, že MCP implementácie spĺňajú požiadavky špecifické pre odvetvie (GDPR, HIPAA, SOC 2)  
   - Implementujte klasifikáciu dát a kontrolu súkromia pre spracovanie AI dát  
   - Udržiavajte komplexnú dokumentáciu pre audity súladu  

**Správa Zmien:**  
   - Formálne procesy bezpečnostného preskúmania pre všetky modifikácie MCP systému  
   - Kontrola verzií a pracovné postupy schvaľovania pre zmeny konfigurácie  
   - Pravidelné hodnotenia súladu a analýza medzier  

## 10. **Pokročilé Bezpečnostné Opatrenia**

**Architektúra Zero Trust:**  
   - **Nikdy Never, Vždy Overuj**: Nepretržité overovanie používateľov, zariadení a spojení  
   - **Mikro-segmentácia**: Jemne zrnitá kontrola siete izolujúca jednotlivé MCP komponenty  
   - **Podmienený Prístup**: Kontroly prístupu založené na riziku prispôsobené aktuálnemu kontextu a správaniu  

**Ochrana Aplikácií Počas Behom:**  
   - **Runtime Application Self-Protection (RASP)**: Nasadzujte RASP techniky na detekciu hrozieb v reálnom čase  
   - **Monitorovanie Výkonu Aplikácií**: Monitorujte výkonové anomálie, ktoré môžu naznačovať útoky  
   - **Dynamické Bezpečnostné Politiky**: Implementujte bezpečnostné politiky, ktoré sa prispôsobujú aktuálnemu hroznému prostrediu  

## 11. **Integrácia Microsoft Bezpečnostného Ekosystému**

**Komplexná Microsoft Bezpečnosť:**  
   - **Microsoft Defender for Cloud**: Správa bezpečnostného stavu cloudu pre MCP pracovné zaťaženia  
   - **Azure Sentinel**: Cloud-native SIEM a SOAR schopnosti na pokročilú detekciu hrozieb  
   - **Microsoft Purview**: Správa dát a súlad pre AI pracovné postupy a zdroje dát  

**Správa Identity & Prístupu:**  
   - **Microsoft Entra ID**: Podniková správa identity s politikami podmieneného prístupu  
   - **Privileged Identity Management (PIM)**: Prístup „just-in-time“ a pracovné postupy schvaľovania pre administratívne funkcie  
   - **Ochrana Identity**: Podmienený prístup založený na riziku a automatizovaná reakcia na hrozby  

## 12. **Nepretržitý Vývoj Bezpečnosti**

**Udržiavanie Aktuálnosti:**  
   - **Monitorovanie Špecifikácií**: Pravidelná kontrola aktualizácií MCP špecifikácií a zmien bezpečnostných odporúčaní  
   - **Inteligencia o Hrozbách**: Integrácia AI-špecifických zdrojov hrozieb a indikátorov kompromitácie  
   - **Zapojenie do Bezpečnostnej Komunity**: Aktívna účasť v MCP bezpečnostnej komunite a programoch na zverejňovanie zraniteľností  

**Adaptívna Bezpečnosť:**  
   - **Bezpečnosť Strojového Učenia**: Používajte detekciu anomálií založenú na strojovom učení na identifikáciu nových vzorov útokov  
   - **Prediktívna Bezpečnostná Analytika**: Implementujte prediktívne modely na proaktívnu identifikáciu hrozieb  
   - **Automatizácia Bezpečnosti**: Automatizované aktualizácie bezpečnostných politík na základe inteligencie o hrozbách a zmien špecifikácií  

---

## **Kritické Bezpečnostné Zdroje**

### **Oficiálna Dokumentácia MCP**
- [MCP Špecifikácia (2025-06-18)](https://spec.modelcontextprotocol.io/specification/2025-06-18/)  
- [MCP Bezpečnostné Najlepšie Praktiky](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices)  
- [MCP Špecifikácia Autorizácie](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization)  

### **Microsoft Bezpečnostné Riešenia**
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)  
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/)  
- [Microsoft Entra ID Bezpečnosť](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)  
- [GitHub Advanced Security](https://github.com/security/advanced-security)  

### **Bezpečnostné Štandardy**
- [OAuth 2.0 Bezpečnostné Najlepšie Praktiky (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)  
- [OWASP Top 10 pre Veľké Jazykové Modely](https://genai.owasp.org/)  
- [NIST AI Rámec Riadenia Rizík](https://www.nist.gov/itl/ai-risk-management-framework)  

### **Implementačné Príručky**
- [Azure API Management MCP Autentifikačná Brána](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)  
- [Microsoft Entra ID s MCP Servermi](https://den.dev/blog/mcp-server-auth-entra-id-session/)  

---

> **Bezpečnostné Upozornenie**: MCP bezpečnostné praktiky sa rýchlo vyvíjajú. Vždy overujte podľa aktuálnej [MCP špecifikácie](https://spec.modelcontextprotocol.io/) a [oficiálnej bezpečnostnej dokumentácie](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) pred implementáciou.

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nenesieme zodpovednosť za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.