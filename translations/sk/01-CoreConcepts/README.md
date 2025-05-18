<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T15:33:13+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sk"
}
-->
# 📖 MCP Core Concepts: Ovládanie Model Context Protocol pre integráciu AI

Model Context Protocol (MCP) je výkonný, štandardizovaný rámec, ktorý optimalizuje komunikáciu medzi veľkými jazykovými modelmi (LLM) a externými nástrojmi, aplikáciami a zdrojmi dát. Tento SEO-optimalizovaný sprievodca vás prevedie základnými konceptmi MCP, aby ste pochopili jeho klient-server architektúru, kľúčové komponenty, mechanizmy komunikácie a osvedčené postupy implementácie.

## Prehľad

Táto lekcia skúma základnú architektúru a komponenty, ktoré tvoria ekosystém Model Context Protocol (MCP). Naučíte sa o klient-server architektúre, hlavných častiach a komunikačných mechanizmoch, ktoré poháňajú interakcie MCP.

## 👩‍🎓 Kľúčové ciele učenia

Na konci tejto lekcie budete:

- Rozumieť klient-server architektúre MCP.
- Identifikovať úlohy a zodpovednosti Hosts, Clients a Servers.
- Analyzovať hlavné vlastnosti, ktoré robia MCP flexibilnou integračnou vrstvou.
- Naučiť sa, ako prebieha tok informácií v ekosystéme MCP.
- Získať praktické poznatky cez ukážky kódu v .NET, Java, Python a JavaScript.

## 🔎 Architektúra MCP: Hlbší pohľad

Ekosystém MCP je postavený na modeli klient-server. Táto modulárna štruktúra umožňuje AI aplikáciám efektívne komunikovať s nástrojmi, databázami, API a kontextovými zdrojmi. Poďme si rozobrať túto architektúru na jej základné komponenty.

### 1. Hosts

V Model Context Protocol (MCP) zohrávajú Hosts kľúčovú úlohu ako hlavné rozhranie, cez ktoré používatelia komunikujú s protokolom. Hosts sú aplikácie alebo prostredia, ktoré iniciujú pripojenia k MCP serverom, aby získali prístup k dátam, nástrojom a promptom. Príklady Hosts zahŕňajú integrované vývojové prostredia (IDE) ako Visual Studio Code, AI nástroje ako Claude Desktop alebo vlastné agenti vytvorení pre špecifické úlohy.

**Hosts** sú LLM aplikácie, ktoré iniciujú pripojenia. Oni:

- Spúšťajú alebo komunikujú s AI modelmi na generovanie odpovedí.
- Iniciujú spojenia s MCP servermi.
- Riadia tok konverzácie a používateľské rozhranie.
- Kontrolujú oprávnenia a bezpečnostné obmedzenia.
- Spravujú súhlas používateľa na zdieľanie dát a spúšťanie nástrojov.

### 2. Clients

Clients sú základné komponenty, ktoré sprostredkúvajú interakciu medzi Hosts a MCP servermi. Clients fungujú ako sprostredkovatelia, umožňujú Hosts prístup a využívanie funkcií poskytovaných MCP servermi. Zohrávajú dôležitú úlohu pri zabezpečení plynulej komunikácie a efektívnej výmeny dát v rámci architektúry MCP.

**Clients** sú konektory v rámci hostiteľskej aplikácie. Oni:

- Posielajú požiadavky serverom s promptmi/inštrukciami.
- Rokujú o schopnostiach so servermi.
- Spravujú požiadavky na spúšťanie nástrojov od modelov.
- Spracovávajú a zobrazujú odpovede používateľom.

### 3. Servers

Servers sú zodpovedné za spracovanie požiadaviek od MCP klientov a poskytovanie príslušných odpovedí. Riadiace rôzne operácie ako získavanie dát, spúšťanie nástrojov a generovanie promptov. Servers zabezpečujú efektívnu a spoľahlivú komunikáciu medzi klientmi a Hosts, udržiavajúc integritu interakčného procesu.

**Servers** sú služby, ktoré poskytujú kontext a funkcie. Oni:

- Registrujú dostupné funkcie (zdroje, prompty, nástroje)
- Prijímajú a vykonávajú volania nástrojov od klienta
- Poskytujú kontextové informácie na zlepšenie odpovedí modelu
- Vracia výsledky späť klientovi
- Udržiavajú stav počas interakcií, keď je to potrebné

Servery môže vyvíjať ktokoľvek, aby rozšíril schopnosti modelu o špecializované funkcie.

### 4. Server Features

Servery v Model Context Protocol (MCP) poskytujú základné stavebné bloky, ktoré umožňujú bohaté interakcie medzi klientmi, hostiteľmi a jazykovými modelmi. Tieto funkcie sú navrhnuté tak, aby rozšírili schopnosti MCP ponukou štruktúrovaného kontextu, nástrojov a promptov.

MCP servery môžu ponúkať niektorú z nasledujúcich funkcií:

#### 📑 Resources

Zdroje v Model Context Protocol (MCP) zahŕňajú rôzne typy kontextu a dát, ktoré môžu používatelia alebo AI modely využiť. Patria sem:

- **Kontextové dáta**: Informácie a kontext, ktoré môžu používatelia alebo AI modely využiť pri rozhodovaní a vykonávaní úloh.
- **Bázy poznatkov a dokumentové úložiská**: Kolekcie štruktúrovaných a neštruktúrovaných dát, ako sú články, manuály a výskumné práce, poskytujúce cenné poznatky a informácie.
- **Lokálne súbory a databázy**: Dáta uložené lokálne na zariadeniach alebo v databázach, prístupné na spracovanie a analýzu.
- **API a webové služby**: Externé rozhrania a služby, ktoré ponúkajú dodatočné dáta a funkcie, umožňujúce integráciu s rôznymi online zdrojmi a nástrojmi.

Príkladom zdroja môže byť databázové schéma alebo súbor, ku ktorému sa pristupuje takto:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompty v Model Context Protocol (MCP) zahŕňajú rôzne preddefinované šablóny a vzory interakcie, ktoré zjednodušujú pracovné postupy používateľov a zlepšujú komunikáciu. Patria sem:

- **Šablónové správy a pracovné postupy**: Predštruktúrované správy a procesy, ktoré používateľov vedú cez konkrétne úlohy a interakcie.
- **Preddefinované vzory interakcie**: Štandardizované sekvencie akcií a odpovedí, ktoré umožňujú konzistentnú a efektívnu komunikáciu.
- **Špecializované konverzačné šablóny**: Prispôsobiteľné šablóny určené pre konkrétne typy rozhovorov, zabezpečujúce relevantné a kontextovo vhodné interakcie.

Šablóna promptu môže vyzerať takto:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Nástroje v Model Context Protocol (MCP) sú funkcie, ktoré môže AI model vykonať na splnenie konkrétnych úloh. Tieto nástroje sú navrhnuté tak, aby rozšírili schopnosti AI modelu poskytovaním štruktúrovaných a spoľahlivých operácií. Kľúčové aspekty zahŕňajú:

- **Funkcie, ktoré môže AI model vykonať**: Nástroje sú spustiteľné funkcie, ktoré model môže vyvolať na vykonanie rôznych úloh.
- **Unikátne meno a popis**: Každý nástroj má jedinečný názov a podrobný popis, ktorý vysvetľuje jeho účel a funkčnosť.
- **Parametre a výstupy**: Nástroje prijímajú konkrétne parametre a vracajú štruktúrované výstupy, čo zabezpečuje konzistentné a predvídateľné výsledky.
- **Samostatné funkcie**: Nástroje vykonávajú samostatné funkcie, ako sú webové vyhľadávanie, výpočty a databázové dotazy.

Príklad nástroja môže vyzerať takto:

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

## Client Features

V Model Context Protocol (MCP) ponúkajú klienti serverom niekoľko kľúčových funkcií, ktoré zlepšujú celkovú funkcionalitu a interakciu v protokole. Jednou z pozoruhodných funkcií je Sampling.

### 👉 Sampling

- **Serverom iniciované agentné správanie**: Klienti umožňujú serverom autonómne spúšťať špecifické akcie alebo správanie, čím sa zvyšujú dynamické schopnosti systému.
- **Rekurzívne interakcie s LLM**: Táto funkcia umožňuje rekurzívne interakcie s veľkými jazykovými modelmi (LLM), čím sa umožňuje zložitejšie a iteratívne spracovanie úloh.
- **Žiadosti o dodatočné dokončenia modelu**: Servery môžu žiadať ďalšie dokončenia od modelu, aby boli odpovede dôkladné a kontextovo relevantné.

## Tok informácií v MCP

Model Context Protocol (MCP) definuje štruktúrovaný tok informácií medzi hosts, clients, servers a modelmi. Pochopenie tohto toku pomáha objasniť, ako sa spracúvajú požiadavky používateľov a ako sa externé nástroje a dáta integrujú do odpovedí modelu.

- **Host iniciuje pripojenie**  
  Hostiteľská aplikácia (napríklad IDE alebo chatové rozhranie) nadviaže spojenie s MCP serverom, zvyčajne cez STDIO, WebSocket alebo iný podporovaný transport.

- **Rokovanie o schopnostiach**  
  Klient (vložený v hostiteľovi) a server si vymieňajú informácie o podporovaných funkciách, nástrojoch, zdrojoch a verziách protokolu. Tým sa zabezpečí, že obe strany rozumejú dostupným schopnostiam pre danú reláciu.

- **Používateľská požiadavka**  
  Používateľ interaguje s hostiteľom (napríklad zadá prompt alebo príkaz). Hostiteľ zhromaždí tento vstup a odovzdá ho klientovi na spracovanie.

- **Použitie zdroja alebo nástroja**  
  - Klient môže požiadať server o dodatočný kontext alebo zdroje (napríklad súbory, databázové záznamy alebo články z bázy poznatkov), aby obohatil porozumenie modelu.
  - Ak model určí, že je potrebný nástroj (napríklad na získanie dát, vykonanie výpočtu alebo volanie API), klient odošle serveru požiadavku na spustenie nástroja, špecifikujúc názov nástroja a parametre.

- **Vykonanie serverom**  
  Server prijme požiadavku na zdroj alebo nástroj, vykoná potrebné operácie (ako spustenie funkcie, dotaz do databázy alebo načítanie súboru) a vráti výsledky klientovi v štruktúrovanej podobe.

- **Generovanie odpovede**  
  Klient integruje odpovede servera (dáta zo zdrojov, výstupy nástrojov atď.) do prebiehajúcej interakcie s modelom. Model využíva tieto informácie na vytvorenie komplexnej a kontextovo relevantnej odpovede.

- **Prezentácia výsledku**  
  Hostiteľ prijme finálny výstup od klienta a zobrazí ho používateľovi, často vrátane textu generovaného modelom a výsledkov z vykonaných nástrojov alebo vyhľadávania zdrojov.

Tento tok umožňuje MCP podporovať pokročilé, interaktívne a kontextovo uvedomelé AI aplikácie tým, že bezproblémovo prepája modely s externými nástrojmi a dátovými zdrojmi.

## Detaily protokolu

MCP (Model Context Protocol) je postavený na základe [JSON-RPC 2.0](https://www.jsonrpc.org/), ktorý poskytuje štandardizovaný, jazykovo nezávislý formát správ pre komunikáciu medzi hosts, clients a servers. Tento základ umožňuje spoľahlivé, štruktúrované a rozšíriteľné interakcie naprieč rôznymi platformami a programovacími jazykmi.

### Kľúčové vlastnosti protokolu

MCP rozširuje JSON-RPC 2.0 o ďalšie konvencie pre vyvolávanie nástrojov, prístup ku zdrojom a správu promptov. Podporuje viacero transportných vrstiev (STDIO, WebSocket, SSE) a umožňuje bezpečnú, rozšíriteľnú a jazykovo nezávislú komunikáciu medzi komponentmi.

#### 🧢 Základný protokol

- **Formát správ JSON-RPC**: Všetky požiadavky a odpovede používajú špecifikáciu JSON-RPC 2.0, čím sa zabezpečuje konzistentná štruktúra pre volania metód, parametre, výsledky a spracovanie chýb.
- **Stavové pripojenia**: MCP relácie udržiavajú stav naprieč viacerými požiadavkami, podporujúc prebiehajúce konverzácie, akumuláciu kontextu a správu zdrojov.
- **Rokovanie o schopnostiach**: Počas nastavovania spojenia si klienti a servery vymieňajú informácie o podporovaných funkciách, verziách protokolu, dostupných nástrojoch a zdrojoch. Tým sa zabezpečí, že obe strany rozumejú schopnostiam toho druhého a môžu sa podľa toho prispôsobiť.

#### ➕ Ďalšie nástroje

Nižšie sú uvedené ďalšie nástroje a rozšírenia protokolu, ktoré MCP poskytuje na zlepšenie vývojárskej skúsenosti a umožnenie pokročilých scenárov:

- **Konfiguračné možnosti**: MCP umožňuje dynamickú konfiguráciu parametrov relácie, ako sú oprávnenia nástrojov, prístup ku zdrojom a nastavenia modelu, prispôsobené každej interakcii.
- **Sledovanie priebehu**: Operácie s dlhým trvaním môžu hlásiť priebežné aktualizácie, čo umožňuje responzívne používateľské rozhranie a lepšiu používateľskú skúsenosť počas zložitých úloh.
- **Zrušenie požiadavky**: Klienti môžu zrušiť prebiehajúce požiadavky, čo umožňuje používateľom prerušiť operácie, ktoré už nie sú potrebné alebo trvajú príliš dlho.
- **Hlásenie chýb**: Štandardizované chybové správy a kódy pomáhajú diagnostikovať problémy, elegantne zvládať zlyhania a poskytovať užitočnú spätnú väzbu používateľom a vývojárom.
- **Logovanie**: Klienti aj servery môžu emitovať štruktúrované logy na audit, ladenie a monitorovanie interakcií protokolu.

Vďaka týmto funkciám MCP zabezpečuje robustnú, bezpečnú a flexibilnú komunikáciu medzi jazykovými modelmi a externými nástrojmi alebo dátovými zdrojmi.

### 🔐 Bezpečnostné aspekty

Implementácie MCP by mali dodržiavať niekoľko kľúčových bezpečnostných princípov, aby zabezpečili bezpečné a dôveryhodné interakcie:

- **Súhlas a kontrola používateľa**: Používatelia musia poskytnúť explicitný súhlas pred prístupom k akýmkoľvek dátam alebo vykonaním operácií. Mali by mať jasnú kontrolu nad tým, aké dáta sú zdieľané a ktoré akcie sú povolené, podporené intuitívnym používateľským rozhraním na prezeranie a schvaľovanie činností.

- **Ochrana súkromia dát**: Dáta používateľov by mali byť sprístupnené len s explicitným súhlasom a musia byť chránené vhodnými prístupovými kontrolami. Implementácie MCP musia zabrániť neoprávnenému prenosu dát a zabezpečiť ochranu súkromia počas všetkých interakcií.

- **Bezpečnosť nástrojov**: Pred spustením akéhokoľvek nástroja je potrebný explicitný súhlas používateľa. Používatelia by mali mať jasné pochopenie funkčnosti každého nástroja a musia byť vynútené pevné bezpečnostné hranice, aby sa predišlo nechcenému alebo nebezpečnému spusteniu nástrojov.

Dodržiavaním týchto princípov MCP zabezpečuje, že dôvera používateľov, súkromie a bezpečnosť sú

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, berte prosím na vedomie, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.