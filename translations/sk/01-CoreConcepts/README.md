<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T18:06:09+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sk"
}
-->
# 📖 MCP Core Concepts: Ovládnutie Model Context Protocol pre integráciu AI

Model Context Protocol (MCP) je výkonný, štandardizovaný rámec, ktorý optimalizuje komunikáciu medzi veľkými jazykovými modelmi (LLM) a externými nástrojmi, aplikáciami a dátovými zdrojmi. Tento SEO-optimalizovaný sprievodca vás prevedie základnými konceptmi MCP, aby ste pochopili jeho klient-server architektúru, kľúčové komponenty, mechanizmy komunikácie a najlepšie praktiky implementácie.

## Prehľad

Táto lekcia skúma základnú architektúru a komponenty, ktoré tvoria ekosystém Model Context Protocol (MCP). Naučíte sa o klient-server architektúre, hlavných komponentoch a komunikačných mechanizmoch, ktoré umožňujú MCP interakcie.

## 👩‍🎓 Kľúčové vzdelávacie ciele

Na konci tejto lekcie budete:

- Rozumieť klient-server architektúre MCP.
- Identifikovať úlohy a zodpovednosti Hosts, Clients a Servers.
- Analyzovať hlavné vlastnosti, ktoré robia MCP flexibilnou integračnou vrstvou.
- Naučiť sa, ako prebieha tok informácií v ekosystéme MCP.
- Získať praktické poznatky prostredníctvom ukážok kódu v .NET, Java, Python a JavaScript.

## 🔎 Architektúra MCP: Hlbší pohľad

Ekosystém MCP je postavený na modeli klient-server. Táto modulárna štruktúra umožňuje AI aplikáciám efektívne komunikovať s nástrojmi, databázami, API a kontextovými zdrojmi. Rozoberme túto architektúru na jej základné komponenty.

### 1. Hosts

V Model Context Protocol (MCP) zohrávajú Hosts kľúčovú úlohu ako primárne rozhranie, cez ktoré používatelia interagujú s protokolom. Hosts sú aplikácie alebo prostredia, ktoré iniciujú spojenia so servermi MCP, aby získali prístup k dátam, nástrojom a promptom. Príklady Hosts zahŕňajú integrované vývojové prostredia (IDE) ako Visual Studio Code, AI nástroje ako Claude Desktop alebo vlastné agenti navrhnutí na špecifické úlohy.

**Hosts** sú LLM aplikácie, ktoré iniciujú spojenia. Ich úlohy sú:

- Spúšťať alebo interagovať s AI modelmi na generovanie odpovedí.
- Iniciovať spojenia so servermi MCP.
- Riadiť tok konverzácie a používateľské rozhranie.
- Kontrolovať oprávnenia a bezpečnostné obmedzenia.
- Zabezpečiť súhlas používateľa so zdieľaním dát a spúšťaním nástrojov.

### 2. Clients

Clients sú nevyhnutné komponenty, ktoré sprostredkúvajú interakciu medzi Hosts a servermi MCP. Clients fungujú ako sprostredkovatelia, ktorí umožňujú Hosts prístup a využívanie funkcií poskytovaných servermi MCP. Zohrávajú dôležitú úlohu v zabezpečení hladkej komunikácie a efektívnej výmeny dát v rámci architektúry MCP.

**Clients** sú konektory v rámci hostiteľskej aplikácie. Ich úlohy sú:

- Posielať požiadavky serverom s promptmi/inštrukciami.
- Rokovať o schopnostiach so servermi.
- Spravovať požiadavky na spustenie nástrojov od modelov.
- Spracovávať a zobrazovať odpovede používateľom.

### 3. Servers

Servers sú zodpovedné za spracovanie požiadaviek od klientov MCP a poskytovanie adekvátnych odpovedí. Riadia rôzne operácie ako získavanie dát, spúšťanie nástrojov a generovanie promptov. Servers zabezpečujú efektívnu a spoľahlivú komunikáciu medzi klientmi a Hosts a udržiavajú integritu interakčného procesu.

**Servers** sú služby, ktoré poskytujú kontext a funkcie. Ich úlohy sú:

- Registrovať dostupné funkcie (zdroje, prompty, nástroje).
- Prijímať a vykonávať volania nástrojov od klienta.
- Poskytovať kontextové informácie na zlepšenie odpovedí modelu.
- Vracať výstupy späť klientovi.
- Udržiavať stav počas interakcií podľa potreby.

Servery môže vyvíjať ktokoľvek, kto chce rozšíriť schopnosti modelu o špecializované funkcie.

### 4. Server Features

Servery v Model Context Protocol (MCP) poskytujú základné stavebné bloky, ktoré umožňujú bohaté interakcie medzi klientmi, hosts a jazykovými modelmi. Tieto funkcie sú navrhnuté tak, aby rozšírili schopnosti MCP ponukou štruktúrovaného kontextu, nástrojov a promptov.

MCP servery môžu ponúkať ktorúkoľvek z nasledujúcich funkcií:

#### 📑 Resources

Zdroje v Model Context Protocol (MCP) zahŕňajú rôzne typy kontextu a dát, ktoré môžu používatelia alebo AI modely využiť. Patria sem:

- **Kontextové dáta**: Informácie a kontext, ktoré môžu používatelia alebo AI modely využiť na rozhodovanie a vykonávanie úloh.
- **Znalostné bázy a dokumentové úložiská**: Kolekcie štruktúrovaných a neštruktúrovaných dát, ako sú články, manuály a výskumné práce, poskytujúce cenné informácie.
- **Lokálne súbory a databázy**: Dáta uložené lokálne na zariadeniach alebo v databázach, prístupné na spracovanie a analýzu.
- **API a webové služby**: Externé rozhrania a služby, ktoré ponúkajú ďalšie dáta a funkcie, umožňujúce integráciu s rôznymi online zdrojmi a nástrojmi.

Príklad zdroja môže byť databázové schéma alebo súbor, ku ktorému sa pristupuje napríklad takto:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompty v Model Context Protocol (MCP) zahŕňajú rôzne preddefinované šablóny a vzory interakcií navrhnuté na zjednodušenie pracovných postupov používateľov a zlepšenie komunikácie. Patria sem:

- **Šablónové správy a pracovné postupy**: Predpripravené správy a procesy, ktoré vedú používateľov cez konkrétne úlohy a interakcie.
- **Preddefinované vzory interakcií**: Štandardizované sekvencie akcií a odpovedí, ktoré umožňujú konzistentnú a efektívnu komunikáciu.
- **Špecializované šablóny konverzácií**: Prispôsobiteľné šablóny určené pre konkrétne typy rozhovorov, ktoré zabezpečujú relevantné a kontextovo vhodné interakcie.

Šablóna promptu môže vyzerať napríklad takto:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Nástroje v Model Context Protocol (MCP) sú funkcie, ktoré môže AI model vykonať na splnenie špecifických úloh. Tieto nástroje sú navrhnuté tak, aby rozšírili schopnosti AI modelu poskytovaním štruktúrovaných a spoľahlivých operácií. Kľúčové aspekty zahŕňajú:

- **Funkcie, ktoré AI model môže vykonať**: Nástroje sú spustiteľné funkcie, ktoré model môže vyvolať na vykonanie rôznych úloh.
- **Jedinečný názov a popis**: Každý nástroj má svoj názov a podrobný popis účelu a funkčnosti.
- **Parametre a výstupy**: Nástroje prijímajú špecifické parametre a vracajú štruktúrované výstupy, čím zabezpečujú konzistentné a predvídateľné výsledky.
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

## Client Features

V Model Context Protocol (MCP) klienti ponúkajú serverom niekoľko kľúčových funkcií, ktoré zlepšujú celkovú funkcionalitu a interakciu v rámci protokolu. Jednou z pozoruhodných funkcií je Sampling.

### 👉 Sampling

- **Agentné správanie iniciované serverom**: Klienti umožňujú serverom autonomne spúšťať konkrétne akcie alebo správanie, čím sa zvyšujú dynamické schopnosti systému.
- **Rekurzívne interakcie s LLM**: Táto funkcia umožňuje rekurzívne interakcie s veľkými jazykovými modelmi, čo umožňuje komplexnejšie a iteratívne spracovanie úloh.
- **Žiadosť o ďalšie dokončenia modelu**: Servery môžu žiadať ďalšie dokončenia od modelu, aby boli odpovede dôkladné a kontextovo relevantné.

## Tok informácií v MCP

Model Context Protocol (MCP) definuje štruktúrovaný tok informácií medzi hosts, clients, servers a modelmi. Pochopenie tohto toku pomáha objasniť, ako sa spracúvajú požiadavky používateľov a ako sa externé nástroje a dáta integrujú do odpovedí modelu.

- **Host iniciuje spojenie**  
  Hostiteľská aplikácia (napr. IDE alebo chat rozhranie) nadväzuje spojenie so serverom MCP, zvyčajne cez STDIO, WebSocket alebo iný podporovaný transport.

- **Rokovanie o schopnostiach**  
  Klient (vložený v hostiteľovi) a server si vymieňajú informácie o podporovaných funkciách, nástrojoch, zdrojoch a verziách protokolu. To zabezpečuje, že obe strany rozumejú dostupným schopnostiam pre danú reláciu.

- **Používateľská požiadavka**  
  Používateľ interaguje s hostiteľom (napr. zadá prompt alebo príkaz). Hostiteľ túto vstupnú informáciu odovzdá klientovi na spracovanie.

- **Použitie zdroja alebo nástroja**  
  - Klient môže požiadať server o dodatočný kontext alebo zdroje (napr. súbory, databázové záznamy alebo články zo znalostnej bázy) na obohatenie modelového porozumenia.
  - Ak model určí, že je potrebný nástroj (napr. na získanie dát, vykonanie výpočtu alebo volanie API), klient odošle serveru požiadavku na spustenie nástroja so špecifikáciou názvu nástroja a parametrov.

- **Vykonanie serverom**  
  Server prijme požiadavku na zdroj alebo nástroj, vykoná potrebné operácie (napr. spustenie funkcie, dotaz do databázy alebo získanie súboru) a výsledky vráti klientovi v štruktúrovanom formáte.

- **Generovanie odpovede**  
  Klient integruje odpovede servera (dáta zo zdrojov, výstupy nástrojov atď.) do prebiehajúcej interakcie s modelom. Model využíva tieto informácie na vytvorenie komplexnej a kontextovo relevantnej odpovede.

- **Prezentácia výsledku**  
  Hostiteľ prijme finálny výstup od klienta a zobrazí ho používateľovi, často vrátane generovaného textu modelu a výsledkov zo spustených nástrojov alebo vyhľadávania zdrojov.

Tento tok umožňuje MCP podporovať pokročilé, interaktívne a kontextovo uvedomelé AI aplikácie tým, že hladko prepája modely s externými nástrojmi a dátovými zdrojmi.

## Detaily protokolu

MCP (Model Context Protocol) je postavený na [JSON-RPC 2.0](https://www.jsonrpc.org/), poskytujúc štandardizovaný, jazykovo nezávislý formát správ pre komunikáciu medzi hosts, clients a servers. Táto základňa umožňuje spoľahlivé, štruktúrované a rozšíriteľné interakcie naprieč rôznymi platformami a programovacími jazykmi.

### Kľúčové vlastnosti protokolu

MCP rozširuje JSON-RPC 2.0 o ďalšie konvencie pre volanie nástrojov, prístup k zdrojom a správu promptov. Podporuje viacero transportných vrstiev (STDIO, WebSocket, SSE) a umožňuje bezpečnú, rozšíriteľnú a jazykovo nezávislú komunikáciu medzi komponentmi.

#### 🧢 Základný protokol

- **Formát správ JSON-RPC**: Všetky požiadavky a odpovede používajú špecifikáciu JSON-RPC 2.0, čím sa zabezpečuje konzistentná štruktúra pre volania metód, parametre, výsledky a spracovanie chýb.
- **Stavové spojenia**: MCP relácie udržiavajú stav naprieč viacerými požiadavkami, podporujúc prebiehajúce konverzácie, akumuláciu kontextu a správu zdrojov.
- **Rokovanie o schopnostiach**: Počas nadväzovania spojenia si klienti a servery vymieňajú informácie o podporovaných funkciách, verziách protokolu, dostupných nástrojoch a zdrojoch. To zabezpečuje, že obe strany rozumejú možnostiam druhej strany a môžu sa prispôsobiť.

#### ➕ Dodatočné nástroje

Nižšie sú uvedené niektoré ďalšie nástroje a rozšírenia protokolu, ktoré MCP poskytuje na zlepšenie vývojárskej skúsenosti a umožnenie pokročilých scenárov:

- **Možnosti konfigurácie**: MCP umožňuje dynamickú konfiguráciu parametrov relácie, ako sú oprávnenia nástrojov, prístup k zdrojom a nastavenia modelu, prispôsobené každej interakcii.
- **Sledovanie priebehu**: Operácie trvajúce dlhší čas môžu hlásiť priebeh, čo umožňuje responzívne používateľské rozhrania a lepší používateľský zážitok pri zložitých úlohách.
- **Zrušenie požiadaviek**: Klienti môžu zrušiť prebiehajúce požiadavky, čo umožňuje používateľom prerušiť operácie, ktoré už nie sú potrebné alebo trvajú príliš dlho.
- **Hlásenie chýb**: Štandardizované chybové správy a kódy pomáhajú diagnostikovať problémy, elegantne zvládať zlyhania a poskytovať užitočnú spätnú väzbu používateľom a vývojárom.
- **Logovanie**: Klienti aj servery môžu generovať štruktúrované logy pre audit, ladenie a monitorovanie interakcií protokolu.

Využitím týchto vlastností protokolu MCP zabezpečuje robustnú, bezpečnú a flexibilnú komunikáciu medzi jazykovými modelmi a externými nástrojmi či dátovými zdrojmi.

### 🔐 Bezpečnostné úvahy

Implementácie MCP by mali dodržiavať niekoľko kľúčových bezpečnostných princípov na zabezpečenie bezpečných a dôveryhodných interakcií:

- **Súhlas a kontrola používateľa**: Používatelia musia poskytnúť výslovný súhlas pred akýmkoľvek prístupom k dátam alebo vykonaním operácií. Mali by mať jasnú kontrolu nad tým, ktoré dáta sa zdieľajú a ktoré akcie sú autorizované, podporené intuitívnymi používateľskými rozhraniami na prehliadanie a schvaľovanie aktivít.

- **Ochrana súkromia dát**: Dáta používateľov by mali byť sprístupnené len s výslovným súhlasom a musia byť chránené vhodnými prístupovými kontrolami. Implementácie MCP musia zabrániť neoprávnenému prenosu dát a zabezpečiť ochranu súkromia počas všetkých interakcií.

- **Bezpečnosť nástrojov**: Pred spustením akéhokoľvek nástroja je potrebný výslovný súhlas používateľa. Používatelia by mali mať jasné pochopenie funkčnosti každého nástroja a musia byť vynútené pevné bezpečnostné hranice, aby sa predišlo neželanému alebo nebezpečnému spusteniu nástrojov.

Dodržiavaním týchto princípov MCP zabezpečuje, že dôvera používateľov, súkromie a bezpeč

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, berte prosím na vedomie, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.