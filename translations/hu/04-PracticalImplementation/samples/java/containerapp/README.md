<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e5ea5e7582f70008ea9bec3b3820f20a",
  "translation_date": "2025-05-17T14:30:40+00:00",
  "source_file": "04-PracticalImplementation/samples/java/containerapp/README.md",
  "language_code": "hu"
}
-->
## Rendszerarchitektúra

Ez a projekt bemutat egy webalkalmazást, amely tartalombiztonsági ellenőrzést használ, mielőtt a felhasználói utasításokat egy számológép szolgáltatásnak továbbítaná a Model Context Protocol (MCP) segítségével.

### Hogyan működik

1. **Felhasználói bemenet**: A felhasználó egy számítási utasítást ad meg a webes felületen
2. **Tartalombiztonsági ellenőrzés (bemenet)**: Az utasítást az Azure Content Safety API elemzi
3. **Biztonsági döntés (bemenet)**:
   - Ha a tartalom biztonságos (minden kategóriában < 2 a súlyosság), továbbítódik a számológéphez
   - Ha a tartalom potenciálisan károsnak minősül, a folyamat leáll, és figyelmeztetést ad vissza
4. **Számológép integráció**: A biztonságos tartalmat a LangChain4j dolgozza fel, amely kommunikál az MCP számológép szerverrel
5. **Tartalombiztonsági ellenőrzés (kimenet)**: A bot válaszát az Azure Content Safety API elemzi
6. **Biztonsági döntés (kimenet)**:
   - Ha a bot válasza biztonságos, megjelenik a felhasználónak
   - Ha a bot válasza potenciálisan károsnak minősül, figyelmeztetésre cserélődik
7. **Válasz**: Az eredmények (ha biztonságosak) megjelennek a felhasználónak a két biztonsági elemzéssel együtt

## Model Context Protocol (MCP) használata számológép szolgáltatásokkal

Ez a projekt bemutatja, hogyan lehet a Model Context Protocol (MCP) segítségével hívni számológép MCP szolgáltatásokat a LangChain4j-ből. A megvalósítás egy helyi MCP szervert használ, amely a 8080-as porton fut, hogy számológép műveleteket biztosítson.

### Azure Content Safety Service beállítása

A tartalombiztonsági funkciók használata előtt létre kell hoznia egy Azure Content Safety szolgáltatás erőforrást:

1. Jelentkezzen be az [Azure Portálra](https://portal.azure.com)
2. Kattintson a "Create a resource" lehetőségre, és keressen rá a "Content Safety"-re
3. Válassza ki a "Content Safety"-t, és kattintson a "Create" gombra
4. Adjon meg egy egyedi nevet az erőforrásának
5. Válassza ki az előfizetését és erőforráscsoportját (vagy hozzon létre egy újat)
6. Válasszon egy támogatott régiót (további információért nézze meg a [Region availability](https://azure.microsoft.com/en-us/global-infrastructure/services/?products=cognitive-services) oldalt)
7. Válasszon egy megfelelő árazási szintet
8. Kattintson a "Create" gombra az erőforrás telepítéséhez
9. A telepítés befejezése után kattintson a "Go to resource" gombra
10. A bal oldali panelen, az "Resource Management" alatt válassza a "Keys and Endpoint" lehetőséget
11. Másolja le az egyik kulcsot és az endpoint URL-t a következő lépéshez

### Környezeti változók konfigurálása

Állítsa be a `GITHUB_TOKEN` környezeti változót a GitHub modellek hitelesítéséhez:
```sh
export GITHUB_TOKEN=<your_github_token>
```

A tartalombiztonsági funkciókhoz állítsa be:
```sh
export CONTENT_SAFETY_ENDPOINT=<your_content_safety_endpoint>
export CONTENT_SAFETY_KEY=<your_content_safety_key>
```

Ezeket a környezeti változókat az alkalmazás használja az Azure Content Safety szolgáltatással való hitelesítéshez. Ha ezek a változók nincsenek beállítva, az alkalmazás helyőrző értékeket fog használni demonstrációs célokra, de a tartalombiztonsági funkciók nem fognak megfelelően működni.

### Számológép MCP szerver indítása

Mielőtt futtatná az ügyfelet, el kell indítania a számológép MCP szervert SSE módban a localhost:8080 címen.

## Projekt leírása

Ez a projekt bemutatja a Model Context Protocol (MCP) integrációját a LangChain4j-vel számológép szolgáltatások hívására. Főbb jellemzők:

- MCP használata számológép szolgáltatás csatlakoztatásához alapvető matematikai műveletekhez
- Két rétegű tartalombiztonsági ellenőrzés a felhasználói utasításokon és a bot válaszokon
- Integráció a GitHub gpt-4.1-nano modellel a LangChain4j-en keresztül
- Server-Sent Events (SSE) használata MCP szállításhoz

## Tartalombiztonsági integráció

A projekt átfogó tartalombiztonsági funkciókat tartalmaz annak biztosítására, hogy mind a felhasználói bemenetek, mind a rendszer válaszai mentesek legyenek káros tartalmaktól:

1. **Bemeneti ellenőrzés**: Minden felhasználói utasítást elemzünk káros tartalom kategóriákra, mint például gyűlöletbeszéd, erőszak, önkárosítás és szexuális tartalom, mielőtt feldolgoznánk.

2. **Kimeneti ellenőrzés**: Még akkor is, ha potenciálisan cenzúrázatlan modelleket használunk, a rendszer az összes generált választ ugyanazon tartalombiztonsági szűrőkön keresztül ellenőrzi, mielőtt megjelenítené a felhasználónak.

Ez a két rétegű megközelítés biztosítja, hogy a rendszer biztonságos maradjon függetlenül attól, melyik AI modellt használják, védve a felhasználókat mind a káros bemenetektől, mind a potenciálisan problémás AI által generált kimenetektől.

## Webes ügyfél

Az alkalmazás egy felhasználóbarát webes felületet tartalmaz, amely lehetővé teszi a felhasználók számára, hogy kapcsolatba lépjenek a Tartalombiztonsági Számológép rendszerrel:

### Webes felület jellemzői

- Egyszerű, intuitív űrlap a számítási utasítások megadásához
- Két rétegű tartalombiztonsági validáció (bemenet és kimenet)
- Valós idejű visszajelzés az utasítás és válasz biztonságáról
- Színkódolt biztonsági jelzések a könnyű értelmezéshez
- Tiszta, reszponzív design, amely különböző eszközökön működik
- Példa biztonságos utasítások a felhasználók útmutatásához

### A webes ügyfél használata

1. Indítsa el az alkalmazást:
   ```sh
   mvn spring-boot:run
   ```

2. Nyissa meg a böngészőjét, és navigáljon a `http://localhost:8087` címre

3. Adjon meg egy számítási utasítást a megadott szövegmezőben (pl. "Számítsa ki a 24,5 és 17,3 összegét")

4. Kattintson a "Submit" gombra a kérés feldolgozásához

5. Tekintse meg az eredményeket, amelyek tartalmazzák:
   - Az utasítás tartalombiztonsági elemzését
   - A számított eredményt (ha az utasítás biztonságos volt)
   - A bot válaszának tartalombiztonsági elemzését
   - Bármilyen biztonsági figyelmeztetést, ha a bemenet vagy kimenet megjelölésre került

A webes ügyfél automatikusan kezeli mindkét tartalombiztonsági ellenőrzési folyamatot, biztosítva, hogy minden interakció biztonságos és megfelelő legyen, függetlenül attól, melyik AI modellt használják.

**Felelősségi nyilatkozat**:  
Ez a dokumentum az AI fordítószolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével lett lefordítva. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekinthető a hiteles forrásnak. Kritikus információk esetén javasolt a professzionális emberi fordítás igénybevétele. Nem vállalunk felelősséget semmilyen félreértésért vagy félremagyarázásért, amely a fordítás használatából ered.