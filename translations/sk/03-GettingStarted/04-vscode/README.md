<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eb9557780cd0a2551cdb8a16c886b51",
  "translation_date": "2025-06-17T16:10:42+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "sk"
}
-->
Poďme sa v nasledujúcich častiach viac venovať používaniu vizuálneho rozhrania.

## Prístup

Takto by sme mali k tomu na vysokej úrovni pristupovať:

- Nakonfigurovať súbor na nájdenie nášho MCP servera.
- Spustiť/pripojiť sa k uvedenému serveru, aby sme získali zoznam jeho schopností.
- Používať tieto schopnosti prostredníctvom rozhrania GitHub Copilot Chat.

Skvelé, teraz keď rozumieme postupu, poďme si vyskúšať použitie MCP servera vo Visual Studio Code prostredníctvom cvičenia.

## Cvičenie: Použitie servera

V tomto cvičení nakonfigurujeme Visual Studio Code tak, aby našlo váš MCP server a mohlo ho používať prostredníctvom rozhrania GitHub Copilot Chat.

### -0- Predkrok, povolenie zisťovania MCP serverov

Možno budete musieť povoliť zisťovanie MCP serverov.

1. Choďte do `File -> Preferences -> Settings` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` v súbore settings.json.

### -1- Vytvorenie konfiguračného súboru

Začnite vytvorením konfiguračného súboru v koreňovom adresári vášho projektu. Potrebujete súbor s názvom MCP.json, ktorý umiestnite do priečinka .vscode. Mal by vyzerať takto:

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

Vyššie je jednoduchý príklad, ako spustiť server napísaný v Node.js, pre iné runtime prostredia uveďte správny príkaz na spustenie servera pomocou `command` and `args`.

### -3- Spustenie servera

Keď ste pridali záznam, poďme server spustiť:

1. Nájdite svoj záznam v *mcp.json* a uistite sa, že vidíte ikonu "play":

  ![Spustenie servera vo Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.sk.png)  

1. Kliknite na ikonu "play", mali by ste vidieť, že ikona nástrojov v GitHub Copilot Chat sa zvýši o počet dostupných nástrojov. Ak kliknete na túto ikonu nástrojov, zobrazí sa vám zoznam registrovaných nástrojov. Môžete jednotlivé nástroje zaškrtnúť alebo odškrtnúť podľa toho, či chcete, aby ich GitHub Copilot používal ako kontext:

  ![Spustenie servera vo Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.sk.png)

1. Na spustenie nástroja napíšte prompt, o ktorom viete, že zodpovedá popisu niektorého z vašich nástrojov, napríklad prompt "add 22 to 1":

  ![Spustenie nástroja z GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.sk.png)

  Mali by ste vidieť odpoveď s výsledkom 23.

## Zadanie

Skúste pridať záznam o serveri do svojho súboru *mcp.json* a overte, či môžete server spustiť a zastaviť. Tiež sa uistite, že môžete komunikovať s nástrojmi na vašom serveri cez rozhranie GitHub Copilot Chat.

## Riešenie

[Riešenie](./solution/README.md)

## Kľúčové body

Z tohto kapitoly si odnesiete nasledovné:

- Visual Studio Code je skvelý klient, ktorý vám umožní používať viaceré MCP servery a ich nástroje.
- Rozhranie GitHub Copilot Chat je spôsob, ako komunikovať so servermi.
- Môžete požiadať používateľa o vstupy, napríklad API kľúče, ktoré sa môžu odovzdať MCP serveru pri konfigurácii záznamu servera v súbore *mcp.json*.

## Ukážky

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Dodatočné zdroje

- [Visual Studio dokumentácia](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Čo nasleduje

- Ďalej: [Vytvorenie SSE servera](/03-GettingStarted/05-sse-server/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, vezmite prosím na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.