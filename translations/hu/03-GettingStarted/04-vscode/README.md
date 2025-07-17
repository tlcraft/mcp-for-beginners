<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8ea28e5e566edd5969337fd0b191ba3f",
  "translation_date": "2025-07-17T10:31:39+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "hu"
}
-->
# Egy szerver használata GitHub Copilot Agent módból

A Visual Studio Code és a GitHub Copilot képesek kliensként működni, és fogyasztani egy MCP szervert. Talán felmerül a kérdés, hogy miért is szeretnénk ezt? Nos, ez azt jelenti, hogy az MCP szerver által kínált funkciókat mostantól az IDE-dből is elérheted. Képzeld el például, hogy hozzáadod a GitHub MCP szerverét, ami lehetővé tenné, hogy GitHubot parancsok begépelése helyett természetes nyelvű utasításokkal irányítsd. Vagy bármi mást, ami javíthatja a fejlesztői élményt, mindezt természetes nyelven vezérelve. Már látod is az előnyt, ugye?

## Áttekintés

Ebben a leckében azt mutatjuk be, hogyan használhatod a Visual Studio Code-ot és a GitHub Copilot Agent módot kliensként az MCP szerveredhez.

## Tanulási célok

A lecke végére képes leszel:

- MCP szervert használni Visual Studio Code-on keresztül.
- Eszközöket futtatni a GitHub Copilot segítségével.
- Beállítani a Visual Studio Code-ot, hogy megtalálja és kezelje az MCP szerveredet.

## Használat

Az MCP szerveredet kétféleképpen irányíthatod:

- Felhasználói felületen, ezt később ebben a fejezetben megmutatjuk.
- Terminálból, a `code` futtatható fájl segítségével is vezérelheted:

  Ahhoz, hogy egy MCP szervert hozzáadj a felhasználói profilodhoz, használd a --add-mcp parancssori opciót, és add meg a JSON szerver konfigurációt a következő formában: {\"name\":\"server-name\",\"command\":...}.

  ```
  code --add-mcp "{\"name\":\"my-server\",\"command\": \"uvx\",\"args\": [\"mcp-server-fetch\"]}"
  ```

### Képernyőképek

![Vezérelt MCP szerver konfiguráció Visual Studio Code-ban](../../../../translated_images/chat-mode-agent.729a22473f822216dd1e723aaee1f7d4a2ede571ee0948037a2d9357a63b9d0b.hu.png)
![Eszközök kiválasztása agent munkamenetenként](../../../../translated_images/agent-mode-select-tools.522c7ba5df0848f8f0d1e439c2e96159431bc620cb39ccf3f5dc611412fd0006.hu.png)
![Hibák könnyű hibakeresése MCP fejlesztés közben](../../../../translated_images/mcp-list-servers.fce89eefe3f30032bed8952e110ab9d82fadf043fcfa071f7d40cf93fb1ea9e9.hu.png)

A következő szakaszokban részletesebben beszélünk a vizuális felület használatáról.

## Megközelítés

Így érdemes magas szinten hozzáállni a folyamathoz:

- Konfigurálj egy fájlt, amely megtalálja az MCP szerveredet.
- Indítsd el vagy csatlakozz a szerverhez, hogy lekérd a képességeit.
- Használd ezeket a képességeket a GitHub Copilot Chat felületen keresztül.

Remek, most, hogy értjük a folyamatot, próbáljuk ki egy gyakorlaton keresztül, hogyan használhatunk MCP szervert Visual Studio Code-ból.

## Gyakorlat: Egy szerver használata

Ebben a gyakorlatban beállítjuk a Visual Studio Code-ot, hogy megtalálja az MCP szerveredet, így azt a GitHub Copilot Chat felületen keresztül használhatod.

### -0- Előkészület, MCP szerver felfedezés engedélyezése

Lehet, hogy engedélyezned kell az MCP szerverek felfedezését.

1. Nyisd meg a `File -> Preferences -> Settings` menüpontot a Visual Studio Code-ban.

1. Keresd meg az "MCP" kifejezést, és engedélyezd a `chat.mcp.discovery.enabled` beállítást a settings.json fájlban.

### -1- Konfigurációs fájl létrehozása

Kezdd azzal, hogy létrehozol egy konfigurációs fájlt a projekt gyökerében, szükséged lesz egy MCP.json nevű fájlra, amit a .vscode mappába kell helyezned. Így kell kinéznie:

```text
.vscode
|-- mcp.json
```

Most nézzük meg, hogyan adhatunk hozzá egy szerver bejegyzést.

### -2- Szerver konfigurálása

Add hozzá a következő tartalmat a *mcp.json* fájlhoz:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

A fenti egyszerű példa egy Node.js-ben írt szerver indítását mutatja be, más futtatókörnyezetek esetén a megfelelő parancsot kell megadni a `command` és `args` mezőkben a szerver indításához.

### -3- A szerver indítása

Miután hozzáadtad a bejegyzést, indítsd el a szervert:

1. Keresd meg a bejegyzésedet a *mcp.json* fájlban, és győződj meg róla, hogy megtalálod a "play" ikont:

  ![Szerver indítása Visual Studio Code-ban](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.hu.png)  

1. Kattints a "play" ikonra, ekkor a GitHub Copilot Chat eszköz ikonja megnöveli az elérhető eszközök számát. Ha rákattintasz az eszköz ikonra, megjelenik a regisztrált eszközök listája. Be- és kikapcsolhatod az egyes eszközöket attól függően, hogy szeretnéd-e, hogy a GitHub Copilot azokat kontextusként használja:

  ![Szerver indítása Visual Studio Code-ban](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.hu.png)

1. Egy eszköz futtatásához írj be egy olyan promptot, amely illeszkedik az egyik eszköz leírásához, például: "add 22 to 1":

  ![Eszköz futtatása GitHub Copilotból](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.hu.png)

  Válaszként 23-at kell látnod.

## Feladat

Próbálj meg hozzáadni egy szerver bejegyzést a *mcp.json* fájlodhoz, és győződj meg róla, hogy el tudod indítani és le tudod állítani a szervert. Ellenőrizd azt is, hogy a GitHub Copilot Chat felületen keresztül tudsz kommunikálni a szervered eszközeivel.

## Megoldás

[Solution](./solution/README.md)

## Főbb tanulságok

A fejezet legfontosabb tanulságai:

- A Visual Studio Code remek kliens, amely lehetővé teszi több MCP szerver és azok eszközeinek használatát.
- A GitHub Copilot Chat felület az, amin keresztül a szerverekkel kommunikálsz.
- Kérhetsz bevitelt a felhasználótól, például API kulcsokat, amelyeket átadhatsz az MCP szervernek a *mcp.json* fájl szerver bejegyzésének konfigurálásakor.

## Minták

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## További források

- [Visual Studio dokumentáció](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Mi következik

- Következő: [SSE szerver létrehozása](../05-sse-server/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.