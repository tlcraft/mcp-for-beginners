<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "222e01c3002a33355806d60d558d9429",
  "translation_date": "2025-07-14T09:41:53+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "sk"
}
-->
Poďme sa v ďalších častiach viac venovať používaniu vizuálneho rozhrania.

## Prístup

Takto by sme mali postupovať na vysokej úrovni:

- Nakonfigurovať súbor, ktorý nájde náš MCP Server.
- Spustiť/pripojiť sa k danému serveru, aby sme získali zoznam jeho schopností.
- Používať tieto schopnosti cez rozhranie GitHub Copilot Chat.

Skvelé, teraz keď rozumieme postupu, vyskúšajme použiť MCP Server vo Visual Studio Code v rámci cvičenia.

## Cvičenie: Použitie servera

V tomto cvičení nakonfigurujeme Visual Studio Code tak, aby našiel váš MCP server a mohol ho používať cez rozhranie GitHub Copilot Chat.

### -0- Predkrok, povolenie objavovania MCP Serverov

Možno budete musieť povoliť objavovanie MCP Serverov.

1. Choďte do `File -> Preferences -> Settings` vo Visual Studio Code.

2. Vyhľadajte "MCP" a povoľte `chat.mcp.discovery.enabled` v súbore settings.json.

### -1- Vytvorenie konfiguračného súboru

Začnite vytvorením konfiguračného súboru v koreňovom adresári vášho projektu, budete potrebovať súbor s názvom MCP.json, ktorý umiestnite do priečinka .vscode. Mal by vyzerať takto:

```text
.vscode
|-- mcp.json
```

Ďalej si ukážeme, ako pridať záznam o serveri.

### -2- Konfigurácia servera

Pridajte nasledujúci obsah do *mcp.json*:

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

Vyššie je jednoduchý príklad, ako spustiť server napísaný v Node.js, pre iné runtime prostredia uveďte správny príkaz na spustenie servera pomocou `command` a `args`.

### -3- Spustenie servera

Keď ste pridali záznam, spustime server:

1. Nájdite svoj záznam v *mcp.json* a uistite sa, že vidíte ikonu "play":

  ![Spustenie servera vo Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.sk.png)  

2. Kliknite na ikonu "play", mali by ste vidieť, že ikona nástrojov v GitHub Copilot Chat sa zvýši o počet dostupných nástrojov. Ak kliknete na túto ikonu nástrojov, zobrazí sa zoznam registrovaných nástrojov. Môžete ich zaškrtnúť alebo odškrtnúť podľa toho, či chcete, aby ich GitHub Copilot používal ako kontext:

  ![Spustenie servera vo Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.sk.png)

3. Na spustenie nástroja zadajte prompt, o ktorom viete, že zodpovedá popisu niektorého z vašich nástrojov, napríklad prompt "add 22 to 1":

  ![Spustenie nástroja z GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.sk.png)

  Mali by ste vidieť odpoveď s výsledkom 23.

## Zadanie

Skúste pridať záznam o serveri do vášho *mcp.json* súboru a uistite sa, že viete server spustiť a zastaviť. Tiež sa uistite, že môžete komunikovať s nástrojmi na vašom serveri cez rozhranie GitHub Copilot Chat.

## Riešenie

[Riešenie](./solution/README.md)

## Kľúčové poznatky

Z tohto kapitoly si odnášame nasledovné:

- Visual Studio Code je skvelý klient, ktorý vám umožní používať viac MCP Serverov a ich nástrojov.
- Rozhranie GitHub Copilot Chat je spôsob, ako komunikovať so servermi.
- Môžete vyzvať používateľa na zadanie vstupov, ako sú API kľúče, ktoré sa môžu odovzdať MCP Serveru pri konfigurácii záznamu v *mcp.json* súbore.

## Ukážky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatočné zdroje

- [Visual Studio dokumentácia](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Čo bude ďalej

- Ďalej: [Vytvorenie SSE Servera](../05-sse-server/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.