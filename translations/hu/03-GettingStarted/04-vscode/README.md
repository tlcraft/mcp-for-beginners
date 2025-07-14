<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "222e01c3002a33355806d60d558d9429",
  "translation_date": "2025-07-14T09:40:59+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "hu"
}
-->
Beszéljünk részletesebben arról, hogyan használjuk a vizuális felületet a következő szakaszokban.

## Megközelítés

Így kell ezt magas szinten megközelítenünk:

- Konfiguráljunk egy fájlt, hogy megtalálja az MCP szerverünket.
- Indítsuk el vagy csatlakozzunk a szerverhez, hogy listázza a képességeit.
- Használjuk ezeket a képességeket a GitHub Copilot Chat felületen keresztül.

Remek, most, hogy értjük a folyamatot, próbáljuk ki az MCP szerver használatát Visual Studio Code-on keresztül egy gyakorlat segítségével.

## Gyakorlat: Szerver használata

Ebben a gyakorlatban beállítjuk a Visual Studio Code-ot, hogy megtalálja az MCP szerveredet, így az használható lesz a GitHub Copilot Chat felületén.

### -0- Előkészület, MCP szerver felfedezés engedélyezése

Lehet, hogy engedélyezned kell az MCP szerverek felfedezését.

1. Menj a `File -> Preferences -> Settings` menüpontra a Visual Studio Code-ban.

1. Keresd meg az "MCP" kifejezést, és engedélyezd a `chat.mcp.discovery.enabled` beállítást a settings.json fájlban.

### -1- Konfigurációs fájl létrehozása

Kezdd azzal, hogy létrehozol egy konfigurációs fájlt a projekt gyökerében, szükséged lesz egy MCP.json nevű fájlra, amit a .vscode mappába kell helyezned. Így kell kinéznie:

```text
.vscode
|-- mcp.json
```

Most nézzük meg, hogyan adhatunk hozzá egy szerver bejegyzést.

### -2- Szerver konfigurálása

Add hozzá a következő tartalmat az *mcp.json* fájlhoz:

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

A fenti egyszerű példa egy Node.js-ben írt szerver indítását mutatja be, más futtatókörnyezetek esetén a megfelelő parancsot kell megadni a szerver indításához a `command` és `args` mezőkben.

### -3- Szerver indítása

Most, hogy hozzáadtad a bejegyzést, indítsuk el a szervert:

1. Keresd meg a bejegyzésedet az *mcp.json* fájlban, és győződj meg róla, hogy megtalálod a "play" ikont:

  ![Szerver indítása Visual Studio Code-ban](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.hu.png)  

1. Kattints a "play" ikonra, ekkor a GitHub Copilot Chat eszköz ikonja növeli az elérhető eszközök számát. Ha rákattintasz az eszköz ikonra, megjelenik a regisztrált eszközök listája. Be- és kikapcsolhatod az egyes eszközöket attól függően, hogy szeretnéd-e, hogy a GitHub Copilot azokat kontextusként használja:

  ![Szerver indítása Visual Studio Code-ban](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.hu.png)

1. Egy eszköz futtatásához írj be egy olyan promptot, amelyről tudod, hogy illeszkedik az egyik eszköz leírásához, például egy ilyen promptot: "add 22 to 1":

  ![Eszköz futtatása GitHub Copilotból](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.hu.png)

  Válaszként 23-at kell látnod.

## Feladat

Próbálj meg hozzáadni egy szerver bejegyzést az *mcp.json* fájlodhoz, és győződj meg róla, hogy el tudod indítani és le tudod állítani a szervert. Ellenőrizd azt is, hogy tudsz kommunikálni a szervered eszközeivel a GitHub Copilot Chat felületen keresztül.

## Megoldás

[Solution](./solution/README.md)

## Főbb tanulságok

A fejezet főbb tanulságai a következők:

- A Visual Studio Code egy nagyszerű kliens, amely lehetővé teszi több MCP szerver és azok eszközeinek használatát.
- A GitHub Copilot Chat felület az, amin keresztül a szerverekkel kommunikálsz.
- Kérhetsz bevitelt a felhasználótól, például API kulcsokat, amelyeket átadhatsz az MCP szervernek a szerver bejegyzés konfigurálásakor az *mcp.json* fájlban.

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
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.