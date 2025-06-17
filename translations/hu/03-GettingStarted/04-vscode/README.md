<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eb9557780cd0a2551cdb8a16c886b51",
  "translation_date": "2025-06-17T16:07:32+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "hu"
}
-->
Beszéljünk többet arról, hogyan használjuk a vizuális felületet a következő szakaszokban.

## Megközelítés

Így kell magas szinten hozzáállnunk ehhez:

- Konfiguráljunk egy fájlt, hogy megtalálja az MCP szerverünket.
- Indítsuk el vagy csatlakozzunk a szerverhez, hogy lekérjük a képességeit.
- Használjuk ezeket a képességeket a GitHub Copilot Chat felületen keresztül.

Nagyszerű, most, hogy értjük a folyamatot, próbáljuk meg használni az MCP szervert a Visual Studio Code-on keresztül egy gyakorlat segítségével.

## Gyakorlat: Egy szerver használata

Ebben a gyakorlatban beállítjuk a Visual Studio Code-ot, hogy megtalálja az MCP szervered, így az használható lesz a GitHub Copilot Chat felületén.

### -0- Előzetes lépés, engedélyezd az MCP szerverek felfedezését

Előfordulhat, hogy engedélyezned kell az MCP szerverek felfedezését.

1. Menj a `File -> Preferences -> Settings` menüpontra, majd keresd meg a `` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` beállítást a settings.json fájlban.

### -1- Konfigurációs fájl létrehozása

Kezdj azzal, hogy létrehozol egy konfigurációs fájlt a projekt gyökérkönyvtárában. Szükséged lesz egy MCP.json nevű fájlra, amit a .vscode mappába kell helyezned. Így nézzen ki:

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

Fent egy egyszerű példa arra, hogyan indíts el egy Node.js-ben írt szervert. Más futtatókörnyezetek esetén add meg a megfelelő parancsot a szerver indításához a `command` and `args` segítségével.

### -3- A szerver indítása

Most, hogy hozzáadtad a bejegyzést, indítsd el a szervert:

1. Keresd meg a bejegyzésed az *mcp.json* fájlban, és győződj meg róla, hogy megtalálod a "play" ikont:

  ![Szerver indítása Visual Studio Code-ban](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.hu.png)  

1. Kattints a "play" ikonra, ekkor a GitHub Copilot Chat eszköz ikonja mutatja a rendelkezésre álló eszközök számának növekedését. Ha rákattintasz az eszköz ikonra, látni fogod a regisztrált eszközök listáját. Be- és kikapcsolhatod az egyes eszközöket attól függően, hogy szeretnéd-e, hogy a GitHub Copilot azokat kontextusként használja:

  ![Eszközök kezelése Visual Studio Code-ban](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.hu.png)

1. Egy eszköz futtatásához írj be egy olyan promptot, amely megfelel valamelyik eszköz leírásának, például: "add 22 to 1":

  ![Eszköz futtatása GitHub Copilotból](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.hu.png)

  Válaszként 23-at kell kapnod.

## Feladat

Próbálj meg hozzáadni egy szerver bejegyzést az *mcp.json* fájlodhoz, és győződj meg róla, hogy el tudod indítani és le tudod állítani a szervert. Ellenőrizd azt is, hogy tudsz kommunikálni a szervered eszközeivel a GitHub Copilot Chat felületén keresztül.

## Megoldás

[Solution](./solution/README.md)

## Főbb tanulságok

A fejezet legfontosabb tanulságai:

- A Visual Studio Code egy remek kliens, amivel több MCP szervert és azok eszközeit is használhatod.
- A GitHub Copilot Chat felület az, amin keresztül kommunikálsz a szerverekkel.
- Kérhetsz bevitelt a felhasználótól, például API kulcsokat, amiket átadhatsz az MCP szervernek a szerver bejegyzés konfigurálásakor az *mcp.json* fájlban.

## Minták

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## További források

- [Visual Studio dokumentáció](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Mi következik?

- Következő: [SSE szerver létrehozása](/03-GettingStarted/05-sse-server/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum a saját nyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.