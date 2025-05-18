<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:58:43+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sk"
}
-->
# 📖 Základné koncepty MCP: Ovládnutie Model Context Protocol pre integráciu AI

Model Context Protocol (MCP) je silný, štandardizovaný rámec, ktorý optimalizuje komunikáciu medzi veľkými jazykovými modelmi (LLM) a externými nástrojmi, aplikáciami a dátovými zdrojmi. Tento SEO-optimalizovaný sprievodca vás prevedie základnými konceptmi MCP, aby ste pochopili jeho klient-server architektúru, základné komponenty, mechanizmy komunikácie a osvedčené postupy implementácie.

## Prehľad

Táto lekcia skúma základnú architektúru a komponenty, ktoré tvoria ekosystém Model Context Protocol (MCP). Naučíte sa o klient-server architektúre, kľúčových komponentoch a mechanizmoch komunikácie, ktoré poháňajú interakcie MCP.

## 👩‍🎓 Kľúčové vzdelávacie ciele

Na konci tejto lekcie budete:

- Rozumieť klient-server architektúre MCP.
- Identifikovať úlohy a zodpovednosti Hostov, Klientov a Serverov.
- Analyzovať základné funkcie, ktoré robia MCP flexibilnou vrstvou integrácie.
- Naučiť sa, ako informácie prúdia v ekosystéme MCP.
- Získať praktické poznatky prostredníctvom ukážok kódu v .NET, Java, Python a JavaScript.

## 🔎 Architektúra MCP: Hlbší pohľad

Ekosystém MCP je postavený na modeli klient-server. Táto modulárna štruktúra umožňuje AI aplikáciám efektívne interagovať s nástrojmi, databázami, API a kontextovými zdrojmi. Rozložme túto architektúru na jej základné komponenty.

### 1. Hostitelia

V Model Context Protocol (MCP) zohrávajú Hostitelia kľúčovú úlohu ako primárne rozhranie, prostredníctvom ktorého používatelia interagujú s protokolom. Hostitelia sú aplikácie alebo prostredia, ktoré iniciujú spojenia s MCP servermi, aby získali prístup k dátam, nástrojom a výzvam. Príklady Hostov zahŕňajú integrované vývojové prostredia (IDEs) ako Visual Studio Code, AI nástroje ako Claude Desktop, alebo vlastné agenti navrhnutí na špecifické úlohy.

**Hostitelia** sú LLM aplikácie, ktoré iniciujú spojenia. Oni:

- Vykonávajú alebo interagujú s AI modelmi na generovanie odpovedí.
- Iniciujú spojenia s MCP servermi.
- Riadia tok konverzácie a užívateľské rozhranie.
- Kontrolujú povolenia a bezpečnostné obmedzenia.
- Riešia súhlas užívateľa na zdieľanie dát a vykonávanie nástrojov.

### 2. Klienti

Klienti sú základné komponenty, ktoré uľahčujú interakciu medzi Hostmi a MCP servermi. Klienti pôsobia ako sprostredkovatelia, umožňujú Hostom prístup a využívanie funkcií poskytovaných MCP servermi. Zohrávajú kľúčovú úlohu pri zabezpečovaní plynulej komunikácie a efektívnej výmeny dát v rámci architektúry MCP.

**Klienti** sú konektory v rámci hostiteľskej aplikácie. Oni:

- Posielajú požiadavky serverom s výzvami/inštrukciami.
- Rokujú o schopnostiach so servermi.
- Riadia požiadavky na vykonávanie nástrojov od modelov.
- Spracovávajú a zobrazujú odpovede užívateľom.

### 3. Servery

Servery sú zodpovedné za spracovanie požiadaviek od MCP klientov a poskytovanie vhodných odpovedí. Riadi rôzne operácie ako získavanie dát, vykonávanie nástrojov a generovanie výziev. Servery zabezpečujú, že komunikácia medzi klientmi a Hostmi je efektívna a spoľahlivá, udržiavajúc integritu procesu interakcie.

**Servery** sú služby, ktoré poskytujú kontext a schopnosti. Oni:

- Registrujú dostupné funkcie (zdroje, výzvy, nástroje).
- Prijímajú a vykonávajú volania nástrojov od klienta.
- Poskytujú kontextové informácie na zlepšenie odpovedí modelu.
- Vrátia výstupy späť klientovi.
- Udržiavajú stav cez interakcie, keď je to potrebné.

Servery môžu byť vyvinuté kýmkoľvek, aby rozšírili schopnosti modelu o špecializovanú funkcionalitu.

### 4. Funkcie servera

Servery v Model Context Protocol (MCP) poskytujú základné stavebné bloky, ktoré umožňujú bohaté interakcie medzi klientmi, hostiteľmi a jazykovými modelmi. Tieto funkcie sú navrhnuté tak, aby rozšírili schopnosti MCP ponúkaním štruktúrovaného kontextu, nástrojov a výziev.

MCP servery môžu ponúknuť niektoré z nasledujúcich funkcií:

#### 📑 Zdroje 

Zdroje v Model Context Protocol (MCP) zahŕňajú rôzne typy kontextu a dát, ktoré môžu byť využité používateľmi alebo AI modelmi. Patria sem:

- **Kontextové dáta**: Informácie a kontext, ktoré môžu používatelia alebo AI modely využiť na rozhodovanie a vykonávanie úloh.
- **Znalostné databázy a úložiská dokumentov**: Zbierky štruktúrovaných a neštruktúrovaných dát, ako sú články, manuály a výskumné práce, ktoré poskytujú cenné poznatky a informácie.
- **Lokálne súbory a databázy**: Dáta uložené lokálne na zariadeniach alebo v rámci databáz, prístupné na spracovanie a analýzu.
- **API a webové služby**: Externé rozhrania a služby, ktoré ponúkajú dodatočné dáta a funkcie, umožňujúce integráciu s rôznymi online zdrojmi a nástrojmi.

Príklad zdroja môže byť schéma databázy alebo súbor, ktorý je možné pristupovať takto:

```text
file://log.txt
database://schema
```

### 🤖 Výzvy
Výzvy v Model Context Protocol (MCP) zahŕňajú rôzne preddefinované šablóny a vzory interakcie navrhnuté na zjednodušenie pracovných tokov používateľov a zlepšenie komunikácie. Patria sem:

- **Šablóny správ a pracovných tokov**: Predštruktúrované správy a procesy, ktoré vedú používateľov cez konkrétne úlohy a interakcie.
- **Preddefinované vzory interakcie**: Štandardizované sekvencie akcií a odpovedí, ktoré uľahčujú konzistentnú a efektívnu komunikáciu.
- **Špecializované šablóny konverzácie**: Prispôsobiteľné šablóny určené pre konkrétne typy konverzácií, zabezpečujúce relevantné a kontextovo vhodné interakcie.

Šablóna výzvy môže vyzerať takto:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Nástroje

Nástroje v Model Context Protocol (MCP) sú funkcie, ktoré AI model môže vykonať na vykonanie konkrétnych úloh. Tieto nástroje sú navrhnuté tak, aby rozšírili schopnosti AI modelu poskytovaním štruktúrovaných a spoľahlivých operácií. Kľúčové aspekty zahŕňajú:

- **Funkcie pre AI model na vykonanie**: Nástroje sú vykonateľné funkcie, ktoré AI model môže vyvolať na vykonanie rôznych úloh.
- **Jedinečný názov a popis**: Každý nástroj má jedinečný názov a podrobný popis, ktorý vysvetľuje jeho účel a funkcionalitu.
- **Parametre a výstupy**: Nástroje prijímajú špecifické parametre a vracajú štruktúrované výstupy, zabezpečujúc konzistentné a predvídateľné výsledky.
- **Diskrétne funkcie**: Nástroje vykonávajú diskrétne funkcie, ako sú webové vyhľadávania, výpočty a dotazy do databázy.

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

## Funkcie klienta
V Model Context Protocol (MCP) klienti ponúkajú niekoľko kľúčových funkcií serverom, zlepšujúc celkovú funkcionalitu a interakciu v rámci protokolu. Jednou z pozoruhodných funkcií je Sampling.

### 👉 Sampling

- **Agentické správanie iniciované serverom**: Klienti umožňujú serverom iniciovať konkrétne akcie alebo správanie autonómne, zlepšujúc dynamické schopnosti systému.
- **Rekurzívne interakcie LLM**: Táto funkcia umožňuje rekurzívne interakcie s veľkými jazykovými modelmi (LLM), umožňujúc zložitejšie a iteratívne spracovanie úloh.
- **Žiadosť o dodatočné dokončenia modelu**: Servery môžu požiadať o dodatočné dokončenia od modelu, zabezpečujúc, že odpovede sú dôkladné a kontextovo relevantné.

## Tok informácií v MCP

Model Context Protocol (MCP) definuje štruktúrovaný tok informácií medzi hostiteľmi, klientmi, servermi a modelmi. Porozumenie tomuto toku pomáha objasniť, ako sú užívateľské požiadavky spracované a ako sú externé nástroje a dáta integrované do odpovedí modelu.

- **Hostiteľ iniciuje spojenie**  
  Hostiteľská aplikácia (ako IDE alebo chatové rozhranie) nadviaže spojenie s MCP serverom, zvyčajne cez STDIO, WebSocket alebo iný podporovaný transport.

- **Rokovanie o schopnostiach**  
  Klient (zabudovaný v hostiteľovi) a server si vymieňajú informácie o svojich podporovaných funkciách, nástrojoch, zdrojoch a verziách protokolu. To zabezpečuje, že obe strany chápu, aké schopnosti sú k dispozícii pre danú reláciu.

- **Požiadavka užívateľa**  
  Užívateľ interaguje s hostiteľom (napr. zadá výzvu alebo príkaz). Hostiteľ zhromaždí tento vstup a odošle ho klientovi na spracovanie.

- **Použitie zdroja alebo nástroja**  
  - Klient môže požiadať o dodatočný kontext alebo zdroje od servera (ako sú súbory, záznamy v databáze alebo články zo znalostnej databázy), aby obohatil porozumenie modelu.
  - Ak model určí, že je potrebný nástroj (napr. na získanie dát, vykonanie výpočtu alebo volanie API), klient odošle požiadavku na vyvolanie nástroja serveru, špecifikujúc názov nástroja a parametre.

- **Vykonanie serverom**  
  Server prijíma požiadavku na zdroj alebo nástroj, vykonáva potrebné operácie (ako spustenie funkcie, dotaz do databázy alebo získanie súboru) a vracia výsledky klientovi v štruktúrovanom formáte.

- **Generovanie odpovede**  
  Klient integruje odpovede servera (dáta zo zdrojov, výstupy nástrojov atď.) do prebiehajúcej interakcie modelu. Model využíva tieto informácie na generovanie komplexnej a kontextovo relevantnej odpovede.

- **Prezentácia výsledku**  
  Hostiteľ prijíma konečný výstup od klienta a prezentuje ho užívateľovi, často vrátane textu generovaného modelom a akýchkoľvek výsledkov z vykonania nástrojov alebo vyhľadávania zdrojov.

Tento tok umožňuje MCP podporovať pokročilé, interaktívne a kontextovo uvedomelé AI aplikácie tým, že bezproblémovo spája modely s externými nástrojmi a dátovými zdrojmi.

## Detaily protokolu

MCP (Model Context Protocol) je postavený na [JSON-RPC 2.0](https://www.jsonrpc.org/), poskytujúc štandardizovaný, jazykovo nezávislý formát správ na komunikáciu medzi hostiteľmi, klientmi a servermi. Tento základ umožňuje spoľahlivé, štruktúrované a rozšíriteľné interakcie naprieč rôznymi platformami a programovacími jazykmi.

### Kľúčové funkcie protokolu

MCP rozširuje JSON-RPC 2.0 o dodatočné konvencie pre vyvolanie nástroja, prístup k zdrojom a správu výziev. Podporuje viacero transportných vrstiev (STDIO, WebSocket, SSE) a umožňuje bezpečnú, rozšíriteľnú a jazykovo nezávislú komunikáciu medzi komponentmi.

#### 🧢 Základný protokol

- **Formát správ JSON-RPC**: Všetky požiadavky a odpovede používajú špecifikáciu JSON-RPC 2.0, zabezpečujúc konzistentnú štruktúru pre volania metód, parametre, výsledky a riešenie chýb.
- **Stavové spojenia**: MCP relácie udržujú stav naprieč viacerými požiadavkami, podporujúc prebiehajúce konverzácie, akumuláciu kontextu a správu zdrojov.
- **Rokovanie o schopnostiach**: Počas nastavenia spojenia si klienti a servery vymieňajú informácie o podporovaných funkciách, verziách protokolu, dostupných nástrojoch a zdrojoch. To zabezpečuje, že obe strany chápu schopnosti druhej strany a môžu sa podľa toho prispôsobiť.

#### ➕ Dodatočné nástroje

Nižšie sú uvedené niektoré dodatočné nástroje a rozšírenia protokolu, ktoré MCP poskytuje na zlepšenie skúsenosti vývojárov a umožnenie pokročilých scenárov:

- **Konfiguračné možnosti**: MCP umožňuje dynamickú konfiguráciu parametrov relácie, ako sú povolenia nástrojov, prístup k zdrojom a nastavenia modelu, prispôsobené každej interakcii.
- **Sledovanie pokroku**: Dlhodobé operácie môžu hlásiť aktualizácie pokroku, umožňujúc citlivé užívateľské rozhrania a lepšiu užívateľskú skúsenosť počas zložitých úloh.
- **Zrušenie požiadavky**: Klienti môžu zrušiť požiadavky v procese, umožňujúc používateľom prerušiť operácie, ktoré už nie sú potrebné alebo trvajú príliš dlho.
- **Hlásenie chýb**: Štandardizované hlásenia chýb a kódy pomáhajú diagnostikovať problémy, zvládať zlyhania elegantne a poskytovať akčné spätné väzby používateľom a vývojárom.
- **Protokolovanie**: Klienti aj servery môžu emitovať štruktúrované logy pre auditovanie, ladenie a monitorovanie interakcií protokolu.

Využitím týchto funkcií protokolu MCP zabezpečuje robustnú, bezpečnú a flexibilnú komunikáciu medzi jazykovými modelmi a externými nástrojmi alebo dátovými zdrojmi.

### 🔐 Bezpečnostné úvahy

Implementácie MCP by mali dodržiavať niekoľko kľúčových bezpečnostných princípov na zabezpečenie bezpečných a dôveryhodných interakcií:

- **Súhlas a kontrola používateľa**: Používatelia musia poskytnúť explicitný súhlas pred prístupom k akýmkoľvek dátam alebo vykonaním operácií. Mali by mať jasnú kontrolu nad tým, ktoré dáta sú zdieľané a ktoré akcie sú autorizované, podporované intuitívnymi užívateľskými rozhraniami na prezeranie a schvaľovanie aktivít.

- **Ochrana dát**: Údaje používateľa by mali byť vystavené len s explicitným súhlasom a musia byť chránené vhodnými prístupovými kontrolami. Implementácie MCP musia chrániť proti neoprávnenej transmisii dát a zabezpečiť, že súkromie je udržiavané počas všetkých interakcií.

- **Bezpečnosť nástrojov**: Pred vyvolaním akéhokoľvek nástroja je potrebný explicitný súhlas používateľa. Používatelia by

**Upozornenie**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne interpretácie vzniknuté použitím tohto prekladu.