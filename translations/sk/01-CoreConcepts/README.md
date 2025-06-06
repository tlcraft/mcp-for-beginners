<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:45:42+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sk"
}
-->
# 📖 MCP Core Concepts: Ovládanie Model Context Protocol pre integráciu AI

Model Context Protocol (MCP) je výkonný, štandardizovaný rámec, ktorý optimalizuje komunikáciu medzi veľkými jazykovými modelmi (LLM) a externými nástrojmi, aplikáciami a zdrojmi dát. Tento SEO-optimalizovaný sprievodca vás prevedie základnými konceptmi MCP, aby ste pochopili jeho klient-server architektúru, kľúčové komponenty, mechanizmy komunikácie a najlepšie postupy implementácie.

## Prehľad

Táto lekcia skúma základnú architektúru a komponenty, ktoré tvoria ekosystém Model Context Protocol (MCP). Naučíte sa o klient-server architektúre, hlavných komponentoch a komunikačných mechanizmoch, ktoré umožňujú interakcie v rámci MCP.

## 👩‍🎓 Hlavné vzdelávacie ciele

Na konci tejto lekcie budete:

- Rozumieť klient-server architektúre MCP.
- Identifikovať úlohy a zodpovednosti Hosts, Clients a Servers.
- Analyzovať základné vlastnosti, ktoré robia MCP flexibilnou integračnou vrstvou.
- Naučiť sa, ako prebieha tok informácií v ekosystéme MCP.
- Získať praktické poznatky vďaka ukážkam kódu v .NET, Java, Python a JavaScript.

## 🔎 Architektúra MCP: Hlbší pohľad

Ekosystém MCP je postavený na modeli klient-server. Táto modulárna štruktúra umožňuje AI aplikáciám efektívne komunikovať s nástrojmi, databázami, API a kontextuálnymi zdrojmi. Rozoberme si túto architektúru na jej základné časti.

### 1. Hosts

V Model Context Protocol (MCP) zohrávajú Hosts kľúčovú úlohu ako hlavné rozhranie, cez ktoré používatelia interagujú s protokolom. Hosts sú aplikácie alebo prostredia, ktoré iniciujú pripojenia k MCP serverom, aby získali prístup k dátam, nástrojom a promptom. Príklady Hosts zahŕňajú integrované vývojové prostredia (IDE) ako Visual Studio Code, AI nástroje ako Claude Desktop alebo vlastné agentov vytvorených na špecifické úlohy.

**Hosts** sú LLM aplikácie, ktoré iniciujú pripojenia. Ich úlohy:

- Spúšťať alebo interagovať s AI modelmi na generovanie odpovedí.
- Iniciovať spojenia s MCP servermi.
- Riadiť tok konverzácie a používateľské rozhranie.
- Kontrolovať oprávnenia a bezpečnostné obmedzenia.
- Riešiť súhlas používateľa s delením dát a spúšťaním nástrojov.

### 2. Clients

Clients sú nevyhnutné komponenty, ktoré uľahčujú interakciu medzi Hosts a MCP servermi. Klienti fungujú ako sprostredkovatelia, umožňujúc Hosts prístup k funkciám poskytovaným MCP servermi. Hrajú kľúčovú úlohu pri zabezpečení plynulej komunikácie a efektívnej výmeny dát v rámci architektúry MCP.

**Clients** sú konektory v hostiteľskej aplikácii. Ich úlohy:

- Posielať požiadavky serverom s promptmi/inštrukciami.
- Rokovať o schopnostiach so servermi.
- Spravovať požiadavky na spustenie nástrojov z modelov.
- Spracovávať a zobrazovať odpovede používateľom.

### 3. Servers

Servers sú zodpovedné za spracovanie požiadaviek od MCP klientov a poskytovanie vhodných odpovedí. Riadia rôzne operácie ako získavanie dát, spúšťanie nástrojov a generovanie promptov. Servery zabezpečujú efektívnu a spoľahlivú komunikáciu medzi klientmi a Hosts, pričom udržiavajú integritu interakčného procesu.

**Servers** sú služby poskytujúce kontext a funkcie. Ich úlohy:

- Registrovať dostupné funkcie (zdroje, prompty, nástroje).
- Prijímať a vykonávať volania nástrojov od klienta.
- Poskytovať kontextové informácie na zlepšenie odpovedí modelu.
- Vracať výstupy späť klientovi.
- Udržiavať stav naprieč interakciami podľa potreby.

Servery môžu vyvíjať ľubovoľní vývojári na rozšírenie schopností modelu špecializovanými funkciami.

### 4. Server Features

Servery v Model Context Protocol (MCP) poskytujú základné stavebné bloky, ktoré umožňujú bohaté interakcie medzi klientmi, hostiteľmi a jazykovými modelmi. Tieto funkcie sú navrhnuté na rozšírenie možností MCP ponukou štruktúrovaného kontextu, nástrojov a promptov.

MCP servery môžu ponúkať niektorú z nasledujúcich funkcií:

#### 📑 Resources

Zdroje v Model Context Protocol (MCP) zahŕňajú rôzne typy kontextu a dát, ktoré môžu používatelia alebo AI modely využiť. Patria sem:

- **Kontextové dáta**: Informácie a kontext, ktoré môžu používatelia alebo AI modely využiť pri rozhodovaní a vykonávaní úloh.
- **Znalostné bázy a dokumentové úložiská**: Kolekcie štruktúrovaných a neštruktúrovaných dát, ako sú články, manuály a výskumné práce, ktoré poskytujú cenné poznatky a informácie.
- **Lokálne súbory a databázy**: Dáta uložené lokálne na zariadeniach alebo v databázach, dostupné na spracovanie a analýzu.
- **API a webové služby**: Externé rozhrania a služby, ktoré ponúkajú ďalšie dáta a funkcie, umožňujúce integráciu s rôznymi online zdrojmi a nástrojmi.

Príkladom zdroja môže byť databázové schéma alebo súbor, ku ktorému sa pristupuje takto:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompty v Model Context Protocol (MCP) zahŕňajú rôzne preddefinované šablóny a vzory interakcie, ktoré majú zjednodušiť pracovné postupy používateľov a zlepšiť komunikáciu. Patria sem:

- **Šablónové správy a pracovné postupy**: Predpripravené správy a procesy, ktoré vedú používateľov cez konkrétne úlohy a interakcie.
- **Preddefinované vzory interakcie**: Štandardizované sekvencie akcií a odpovedí, ktoré umožňujú konzistentnú a efektívnu komunikáciu.
- **Špecializované konverzačné šablóny**: Prispôsobiteľné šablóny určené pre konkrétne typy konverzácií, zabezpečujúce relevantné a kontextovo vhodné interakcie.

Šablóna promptu môže vyzerať takto:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Nástroje v Model Context Protocol (MCP) sú funkcie, ktoré môže AI model vykonať na splnenie špecifických úloh. Tieto nástroje sú navrhnuté tak, aby rozšírili schopnosti AI modelu poskytovaním štruktúrovaných a spoľahlivých operácií. Kľúčové vlastnosti:

- **Funkcie na vykonanie AI modelom**: Nástroje sú spustiteľné funkcie, ktoré môže model vyvolať na vykonanie rôznych úloh.
- **Jedinečný názov a popis**: Každý nástroj má jedinečný názov a podrobný popis, ktorý vysvetľuje jeho účel a funkcionalitu.
- **Parametre a výstupy**: Nástroje prijímajú špecifické parametre a vracajú štruktúrované výstupy, zabezpečujúce konzistentné a predvídateľné výsledky.
- **Diskrétne funkcie**: Nástroje vykonávajú samostatné funkcie ako webové vyhľadávanie, výpočty alebo databázové dotazy.

Príklad nástroja môže vyzerať takto:

```typescript
server.tool(
  "GetProducts",
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Funkcie klienta

V Model Context Protocol (MCP) klienti ponúkajú serverom niekoľko kľúčových funkcií, ktoré zlepšujú celkovú funkcionalitu a interakciu v rámci protokolu. Jednou z pozoruhodných funkcií je Sampling.

### 👉 Sampling

- **Agentické správanie iniciované serverom**: Klienti umožňujú serverom autonómne iniciovať konkrétne akcie alebo správanie, čím sa zvyšujú dynamické schopnosti systému.
- **Rekurzívne interakcie s LLM**: Táto funkcia umožňuje rekurzívne interakcie s veľkými jazykovými modelmi (LLM), čo vedie k zložitejšiemu a iteratívnemu spracovaniu úloh.
- **Žiadanie ďalších dokončení modelu**: Servery môžu žiadať ďalšie dokončenia od modelu, aby zabezpečili dôkladné a kontextovo relevantné odpovede.

## Tok informácií v MCP

Model Context Protocol (MCP) definuje štruktúrovaný tok informácií medzi hosts, clients, servers a modelmi. Pochopenie tohto toku pomáha objasniť, ako sa spracúvajú používateľské požiadavky a ako sa do odpovedí modelu integrujú externé nástroje a dáta.

- **Host iniciuje pripojenie**  
  Hostiteľská aplikácia (napr. IDE alebo chatové rozhranie) nadväzuje spojenie s MCP serverom, zvyčajne cez STDIO, WebSocket alebo iný podporovaný transport.

- **Rokovanie o schopnostiach**  
  Klient (vložený v hostiteľovi) a server si vymieňajú informácie o podporovaných funkciách, nástrojoch, zdrojoch a verziách protokolu. Tým sa zabezpečí, že obe strany rozumejú dostupným možnostiam pre danú reláciu.

- **Používateľská požiadavka**  
  Používateľ komunikuje s hostiteľom (napr. zadá prompt alebo príkaz). Hostiteľ tento vstup zhromažďuje a odovzdáva klientovi na spracovanie.

- **Použitie zdroja alebo nástroja**  
  - Klient môže požiadať server o ďalší kontext alebo zdroje (napr. súbory, databázové záznamy alebo články zo znalostnej bázy), aby obohatil porozumenie modelu.
  - Ak model určí, že je potrebný nástroj (napr. na získanie dát, vykonanie výpočtu alebo volanie API), klient odošle serveru požiadavku na spustenie nástroja, špecifikujúc jeho názov a parametre.

- **Vykonanie serverom**  
  Server prijme požiadavku na zdroj alebo nástroj, vykoná potrebné operácie (napr. spustí funkciu, vykoná databázový dotaz alebo načíta súbor) a vráti výsledky klientovi v štruktúrovanej podobe.

- **Generovanie odpovede**  
  Klient integruje odpovede servera (dáta zo zdrojov, výstupy nástrojov atď.) do prebiehajúcej interakcie s modelom. Model použije tieto informácie na vytvorenie komplexnej a kontextovo relevantnej odpovede.

- **Prezentácia výsledku**  
  Hostiteľ prijme konečný výstup od klienta a zobrazí ho používateľovi, často vrátane textu generovaného modelom a výsledkov zo spustených nástrojov alebo vyhľadávania v zdrojoch.

Tento tok umožňuje MCP podporovať pokročilé, interaktívne a kontextovo uvedomelé AI aplikácie hladkým prepojením modelov s externými nástrojmi a zdrojmi dát.

## Detaily protokolu

MCP (Model Context Protocol) je postavený na [JSON-RPC 2.0](https://www.jsonrpc.org/), ktorý poskytuje štandardizovaný, jazykovo nezávislý formát správ pre komunikáciu medzi hosts, clients a servers. Tento základ umožňuje spoľahlivé, štruktúrované a rozšíriteľné interakcie naprieč rôznymi platformami a programovacími jazykmi.

### Kľúčové vlastnosti protokolu

MCP rozširuje JSON-RPC 2.0 o ďalšie konvencie pre volanie nástrojov, prístup k zdrojom a správu promptov. Podporuje viacero transportných vrstiev (STDIO, WebSocket, SSE) a umožňuje bezpečnú, rozšíriteľnú a jazykovo nezávislú komunikáciu medzi komponentmi.

#### 🧢 Základný protokol

- **Formát správ JSON-RPC**: Všetky požiadavky a odpovede používajú špecifikáciu JSON-RPC 2.0, čím je zabezpečená konzistentná štruktúra pre volania metód, parametre, výsledky a spracovanie chýb.
- **Stavové spojenia**: MCP relácie udržiavajú stav cez viaceré požiadavky, podporujúc prebiehajúce konverzácie, akumuláciu kontextu a správu zdrojov.
- **Rokovanie o schopnostiach**: Počas nastavovania spojenia si klienti a servery vymieňajú informácie o podporovaných funkciách, verziách protokolu, dostupných nástrojoch a zdrojoch. To zabezpečuje, že obe strany rozumejú schopnostiam druhej strany a môžu sa podľa toho prispôsobiť.

#### ➕ Ďalšie nástroje

Nižšie sú uvedené ďalšie nástroje a rozšírenia protokolu, ktoré MCP poskytuje na zlepšenie vývoja a podporu pokročilých scenárov:

- **Konfiguračné možnosti**: MCP umožňuje dynamickú konfiguráciu parametrov relácie, ako sú oprávnenia nástrojov, prístup k zdrojom a nastavenia modelu, prispôsobené pre každú interakciu.
- **Sledovanie priebehu**: Dlhé operácie môžu hlásiť priebežné aktualizácie, čo umožňuje responzívne používateľské rozhrania a lepší používateľský zážitok pri zložitých úlohách.
- **Zrušenie požiadaviek**: Klienti môžu zrušiť prebiehajúce požiadavky, čo umožňuje používateľom prerušiť operácie, ktoré už nie sú potrebné alebo trvajú príliš dlho.
- **Hlásenie chýb**: Štandardizované chybové správy a kódy pomáhajú diagnostikovať problémy, zvládať zlyhania elegantne a poskytovať užitočnú spätnú väzbu používateľom a vývojárom.
- **Logovanie**: Klienti aj servery môžu emitovať štruktúrované logy na audit, ladenie a monitorovanie interakcií protokolu.

Vďaka týmto vlastnostiam MCP zabezpečuje robustnú, bezpečnú a flexibilnú komunikáciu medzi jazykovými modelmi a externými nástrojmi či dátovými zdrojmi.

### 🔐 Bezpečnostné úvahy

Implementácie MCP by mali dodržiavať niekoľko kľúčových bezpečnostných princípov na zabezpečenie bezpečných a dôveryhodných interakcií:

- **Súhlas a kontrola používateľa**: Používatelia musia poskytnúť výslovný súhlas pred prístupom k dátam alebo vykonaním operácií. Mali by mať jasnú kontrolu nad tým, aké dáta sa zdieľajú a ktoré akcie sú autorizované, podporené intuitívnym používateľským rozhraním na kontrolu a schvaľovanie činností.

- **Ochrana súkromia dát**: Dáta používateľov by mali byť sprístupnené len s výslovným súhlasom a musia byť chránené vhodnými prístupovými kontrolami. Implementácie MCP musia zabrániť neoprávnenému prenosu dát a zabezpečiť, že súkromie je zachované počas všetkých interakcií.

- **Bezpečnosť nástrojov**: Pred vyvolaním akéhokoľvek nástroja je potrebný výslovný súhlas používateľa. Používatelia by mali mať jasné pochopenie funkcií každého nástroja a musia byť uplatnené pevné bezpečnostné hranice, aby sa zabránilo neúmyselnému alebo nebezpečnému spusteniu nástrojov.

Dodržiavaním týchto princípov MCP zabezpečuje dôveru používateľov, ochranu súkromia a bezpečnosť počas všetkých interakcií v rámci

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, majte prosím na pamäti, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.