<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-20T22:26:23+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sk"
}
-->
# 📖 MCP Core Concepts: Ovládnutie Model Context Protocol pre integráciu AI

Model Context Protocol (MCP) je výkonný, štandardizovaný rámec, ktorý optimalizuje komunikáciu medzi veľkými jazykovými modelmi (LLM) a externými nástrojmi, aplikáciami a dátovými zdrojmi. Tento SEO optimalizovaný sprievodca vás prevedie základnými konceptmi MCP, aby ste pochopili jeho klient-server architektúru, kľúčové komponenty, mechanizmy komunikácie a osvedčené postupy implementácie.

## Prehľad

Táto lekcia skúma základnú architektúru a komponenty, ktoré tvoria ekosystém Model Context Protocol (MCP). Naučíte sa o klient-server architektúre, hlavných komponentoch a komunikačných mechanizmoch, ktoré umožňujú MCP interakcie.

## 👩‍🎓 Kľúčové vzdelávacie ciele

Na konci tejto lekcie budete:

- Rozumieť klient-server architektúre MCP.
- Identifikovať úlohy a zodpovednosti Hosts, Clients a Servers.
- Analyzovať hlavné vlastnosti, ktoré robia MCP flexibilnou integračnou vrstvou.
- Naučiť sa, ako informácie plynú v rámci ekosystému MCP.
- Získať praktické poznatky prostredníctvom príkladov kódu v .NET, Java, Python a JavaScript.

## 🔎 Architektúra MCP: Hlbší pohľad

Ekosystém MCP je postavený na modeli klient-server. Táto modulárna štruktúra umožňuje AI aplikáciám efektívne komunikovať s nástrojmi, databázami, API a kontextovými zdrojmi. Rozoberme si túto architektúru na jej základné komponenty.

### 1. Hosts

V Model Context Protocol (MCP) zohrávajú Hosts kľúčovú úlohu ako primárne rozhranie, cez ktoré používatelia interagujú s protokolom. Hosts sú aplikácie alebo prostredia, ktoré iniciujú spojenia s MCP servermi, aby získali prístup k dátam, nástrojom a promptom. Príklady Hosts zahŕňajú integrované vývojové prostredia (IDE) ako Visual Studio Code, AI nástroje ako Claude Desktop, alebo vlastné agenti vytvorení na špecifické úlohy.

**Hosts** sú LLM aplikácie, ktoré iniciujú spojenia. Oni:

- Spúšťajú alebo komunikujú s AI modelmi na generovanie odpovedí.
- Iniciujú spojenia s MCP servermi.
- Riadia tok konverzácie a používateľské rozhranie.
- Kontrolujú povolenia a bezpečnostné obmedzenia.
- Spravujú súhlas používateľa so zdieľaním dát a spúšťaním nástrojov.

### 2. Clients

Clients sú nevyhnutné komponenty, ktoré uľahčujú interakciu medzi Hosts a MCP servermi. Clients fungujú ako sprostredkovatelia, ktorí umožňujú Hosts pristupovať a využívať funkcie poskytované MCP servermi. Zohrávajú dôležitú úlohu pri zabezpečení plynulej komunikácie a efektívnej výmeny dát v rámci architektúry MCP.

**Clients** sú konektory v rámci hostiteľskej aplikácie. Oni:

- Posielajú požiadavky serverom s promptmi/inštrukciami.
- Vyjednávajú schopnosti so servermi.
- Spravujú požiadavky na spúšťanie nástrojov z modelov.
- Spracovávajú a zobrazujú odpovede používateľom.

### 3. Servers

Servers sú zodpovedné za spracovanie požiadaviek od MCP klientov a poskytovanie adekvátnych odpovedí. Spravujú rôzne operácie ako získavanie dát, spúšťanie nástrojov a generovanie promptov. Servers zabezpečujú efektívnu a spoľahlivú komunikáciu medzi klientmi a Hosts, pričom udržiavajú integritu interakčného procesu.

**Servers** sú služby, ktoré poskytujú kontext a funkcie. Oni:

- Registrujú dostupné funkcie (zdroje, prompty, nástroje)
- Prijímajú a vykonávajú volania nástrojov od klienta
- Poskytujú kontextové informácie na zlepšenie odpovedí modelu
- Vrátia výstupy späť klientovi
- Udržiavajú stav počas interakcií, ak je to potrebné

Servery môže vytvárať ktokoľvek na rozšírenie schopností modelu špecializovanou funkcionalitou.

### 4. Funkcie serverov

Servery v Model Context Protocol (MCP) poskytujú základné stavebné bloky, ktoré umožňujú bohaté interakcie medzi klientmi, hostiteľmi a jazykovými modelmi. Tieto funkcie sú navrhnuté tak, aby rozšírili možnosti MCP ponukou štruktúrovaného kontextu, nástrojov a promptov.

MCP servery môžu ponúkať niektorú z nasledujúcich funkcií:

#### 📑 Zdroje

Zdroje v Model Context Protocol (MCP) zahŕňajú rôzne typy kontextu a dát, ktoré môžu používatelia alebo AI modely využiť. Patria sem:

- **Kontextové dáta**: Informácie a kontext, ktoré môžu používatelia alebo AI modely využiť pri rozhodovaní a vykonávaní úloh.
- **Znalostné bázy a dokumentové repozitáre**: Kolekcie štruktúrovaných a neštruktúrovaných dát, ako sú články, manuály a výskumné práce, ktoré poskytujú cenné poznatky a informácie.
- **Lokálne súbory a databázy**: Dáta uložené lokálne na zariadeniach alebo v databázach, dostupné na spracovanie a analýzu.
- **API a webové služby**: Externé rozhrania a služby, ktoré ponúkajú ďalšie dáta a funkcie, umožňujúce integráciu s rôznymi online zdrojmi a nástrojmi.

Príkladom zdroja môže byť databázové schéma alebo súbor, ku ktorému sa pristupuje takto:

```text
file://log.txt
database://schema
```

### 🤖 Prompty

Prompty v Model Context Protocol (MCP) zahŕňajú rôzne preddefinované šablóny a vzory interakcie navrhnuté na zjednodušenie pracovných tokov používateľov a zlepšenie komunikácie. Patria sem:

- **Šablónové správy a pracovné postupy**: Predpripravené správy a procesy, ktoré vedú používateľov cez konkrétne úlohy a interakcie.
- **Preddefinované vzory interakcie**: Štandardizované sekvencie akcií a odpovedí, ktoré podporujú konzistentnú a efektívnu komunikáciu.
- **Špecializované konverzačné šablóny**: Prispôsobiteľné šablóny určené pre konkrétne typy rozhovorov, zabezpečujúce relevantné a kontextovo vhodné interakcie.

Šablóna promptu môže vyzerať takto:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Nástroje

Nástroje v Model Context Protocol (MCP) sú funkcie, ktoré AI model môže vykonať na splnenie konkrétnych úloh. Tieto nástroje sú navrhnuté na rozšírenie schopností AI modelu poskytovaním štruktúrovaných a spoľahlivých operácií. Kľúčové aspekty zahŕňajú:

- **Funkcie, ktoré môže AI model vykonať**: Nástroje sú spustiteľné funkcie, ktoré môže model vyvolať na vykonanie rôznych úloh.
- **Unikátny názov a popis**: Každý nástroj má jedinečný názov a podrobný popis vysvetľujúci jeho účel a funkčnosť.
- **Parametre a výstupy**: Nástroje prijímajú špecifické parametre a vracajú štruktúrované výstupy, čím zabezpečujú konzistentné a predvídateľné výsledky.
- **Samostatné funkcie**: Nástroje vykonávajú samostatné funkcie ako webové vyhľadávanie, výpočty alebo databázové dotazy.

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

## Funkcie klientov

V Model Context Protocol (MCP) klienti ponúkajú serverom niekoľko kľúčových funkcií, ktoré zlepšujú celkovú funkcionalitu a interakciu v rámci protokolu. Jednou z významných funkcií je Sampling.

### 👉 Sampling

- **Agentné správanie iniciované serverom**: Klienti umožňujú serverom autonómne spúšťať konkrétne akcie alebo správanie, čím zvyšujú dynamické schopnosti systému.
- **Rekurzívne interakcie s LLM**: Táto funkcia umožňuje rekurzívne interakcie s veľkými jazykovými modelmi (LLM), čo umožňuje komplexnejšie a iteratívne spracovanie úloh.
- **Žiadanie ďalších dokončení modelu**: Servery môžu žiadať ďalšie dokončenia od modelu, aby zabezpečili dôkladné a kontextovo relevantné odpovede.

## Tok informácií v MCP

Model Context Protocol (MCP) definuje štruktúrovaný tok informácií medzi hostiteľmi, klientmi, servermi a modelmi. Pochopenie tohto toku pomáha objasniť, ako sa spracovávajú požiadavky používateľov a ako sa externé nástroje a dáta integrujú do odpovedí modelu.

- **Host iniciuje spojenie**  
  Hostiteľská aplikácia (napr. IDE alebo chat rozhranie) nadviaže spojenie s MCP serverom, zvyčajne cez STDIO, WebSocket alebo iný podporovaný transport.

- **Vyjednávanie schopností**  
  Klient (vložený v hostiteľovi) a server si vymieňajú informácie o podporovaných funkciách, nástrojoch, zdrojoch a verziách protokolu. Tým sa zabezpečí, že obe strany rozumejú dostupným možnostiam počas relácie.

- **Používateľská požiadavka**  
  Používateľ interaguje s hostiteľom (napr. zadá prompt alebo príkaz). Hostiteľ tento vstup zozbiera a odovzdá klientovi na spracovanie.

- **Použitie zdroja alebo nástroja**  
  - Klient môže požiadať server o dodatočný kontext alebo zdroje (napr. súbory, záznamy z databázy alebo články zo znalostnej bázy), aby obohatil porozumenie modelu.
  - Ak model rozhodne, že je potrebný nástroj (napr. na získanie dát, vykonanie výpočtu alebo volanie API), klient odošle serveru požiadavku na spustenie nástroja s uvedením názvu nástroja a parametrov.

- **Vykonanie serverom**  
  Server prijme požiadavku na zdroj alebo nástroj, vykoná potrebné operácie (napr. spustenie funkcie, dotaz do databázy alebo načítanie súboru) a vráti výsledky klientovi v štruktúrovanom formáte.

- **Generovanie odpovede**  
  Klient integruje odpovede servera (dáta zo zdrojov, výstupy nástrojov atď.) do prebiehajúcej interakcie modelu. Model tieto informácie využije na vytvorenie komplexnej a kontextovo relevantnej odpovede.

- **Prezentácia výsledku**  
  Hostiteľ prijme finálny výstup od klienta a zobrazí ho používateľovi, často vrátane textu generovaného modelom a výsledkov z vykonaných nástrojov alebo vyhľadávania v zdrojoch.

Tento tok umožňuje MCP podporovať pokročilé, interaktívne a kontextovo uvedomelé AI aplikácie bezproblémovým prepojením modelov s externými nástrojmi a dátovými zdrojmi.

## Detaily protokolu

MCP (Model Context Protocol) je postavený na [JSON-RPC 2.0](https://www.jsonrpc.org/), ktorý poskytuje štandardizovaný, jazykovo nezávislý formát správ na komunikáciu medzi hostiteľmi, klientmi a servermi. Tento základ umožňuje spoľahlivé, štruktúrované a rozšíriteľné interakcie naprieč rôznymi platformami a programovacími jazykmi.

### Kľúčové vlastnosti protokolu

MCP rozširuje JSON-RPC 2.0 o ďalšie konvencie pre volanie nástrojov, prístup k zdrojom a správu promptov. Podporuje viaceré transportné vrstvy (STDIO, WebSocket, SSE) a umožňuje bezpečnú, rozšíriteľnú a jazykovo nezávislú komunikáciu medzi komponentmi.

#### 🧢 Základný protokol

- **Formát správ JSON-RPC**: Všetky požiadavky a odpovede používajú špecifikáciu JSON-RPC 2.0, čo zabezpečuje konzistentnú štruktúru pre volania metód, parametre, výsledky a spracovanie chýb.
- **Stavové spojenia**: MCP relácie udržiavajú stav cez viaceré požiadavky, podporujúc prebiehajúce konverzácie, akumuláciu kontextu a správu zdrojov.
- **Vyjednávanie schopností**: Počas nadviazania spojenia si klienti a servery vymieňajú informácie o podporovaných funkciách, verziách protokolu, dostupných nástrojoch a zdrojoch. Tým sa zabezpečí, že obe strany rozumejú možnostiam a môžu sa podľa toho prispôsobiť.

#### ➕ Ďalšie nástroje

Nižšie sú uvedené niektoré doplnkové nástroje a rozšírenia protokolu, ktoré MCP poskytuje na zlepšenie vývojárskej skúsenosti a umožnenie pokročilých scenárov:

- **Konfiguračné možnosti**: MCP umožňuje dynamickú konfiguráciu parametrov relácie, ako sú povolenia nástrojov, prístup k zdrojom a nastavenia modelu, prispôsobené každej interakcii.
- **Sledovanie priebehu**: Dlhodobé operácie môžu hlásiť aktualizácie priebehu, čo umožňuje responzívne používateľské rozhranie a lepší používateľský zážitok pri zložitých úlohách.
- **Zrušenie požiadavky**: Klienti môžu zrušiť prebiehajúce požiadavky, čo umožňuje používateľom prerušiť operácie, ktoré už nie sú potrebné alebo trvajú príliš dlho.
- **Hlásenie chýb**: Štandardizované chybové správy a kódy pomáhajú diagnostikovať problémy, elegantne zvládať zlyhania a poskytovať konštruktívnu spätnú väzbu používateľom a vývojárom.
- **Logovanie**: Klienti aj servery môžu emitovať štruktúrované logy na auditovanie, ladenie a monitorovanie interakcií protokolu.

Vďaka týmto vlastnostiam MCP zabezpečuje robustnú, bezpečnú a flexibilnú komunikáciu medzi jazykovými modelmi a externými nástrojmi alebo dátovými zdrojmi.

### 🔐 Bezpečnostné aspekty

Implementácie MCP by mali dodržiavať niekoľko kľúčových bezpečnostných princípov, aby zabezpečili bezpečné a dôveryhodné interakcie:

- **Súhlas a kontrola používateľa**: Používatelia musia výslovne súhlasiť pred tým, než sa pristúpi k dátam alebo vykonajú operácie. Mali by mať jasnú kontrolu nad tým, aké dáta sú zdieľané a aké akcie sú autorizované, podporené intuitívnym používateľským rozhraním na kontrolu a schvaľovanie aktivít.

- **Ochrana súkromia dát**: Dáta používateľa by mali byť sprístupnené len s výslovným súhlasom a musia byť chránené primeranými prístupovými kontrolami. Implementácie MCP musia zabrániť neoprávnenému prenosu dát a zabezpečiť zachovanie súkromia počas všetkých interakcií.

- **Bezpečnosť nástrojov**: Pred spustením akéhokoľvek nástroja je potrebný výslovný súhlas používateľa. Používatelia by mali jasne rozumieť funkciám každého nástroja a musia byť vynútené pevné bezpečnostné hranice, aby sa predišlo nechcenému alebo nebezpečnému spusteniu nástrojov.

Dodržiavaním týchto princípov MCP zabezpečuje dôveru používateľov, ochranu súkromia a bezpečnosť počas všetkých inter

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, vezmite prosím na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.