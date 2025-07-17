<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8ea28e5e566edd5969337fd0b191ba3f",
  "translation_date": "2025-07-17T11:04:39+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "sk"
}
-->
# Používanie servera v režime GitHub Copilot Agent

Visual Studio Code a GitHub Copilot môžu fungovať ako klient a využívať MCP Server. Prečo by sme to chceli robiť, môžete sa pýtať? Znamená to, že všetky funkcie MCP Servera môžete teraz používať priamo vo vašom IDE. Predstavte si napríklad, že pridáte GitHub MCP server, čo by umožnilo ovládať GitHub pomocou príkazov zadaných prirodzeným jazykom namiesto písania konkrétnych príkazov v termináli. Alebo si predstavte čokoľvek, čo by mohlo zlepšiť váš vývojársky zážitok, všetko ovládané prirodzeným jazykom. Už vidíte ten prínos, však?

## Prehľad

Táto lekcia vysvetľuje, ako používať Visual Studio Code a režim GitHub Copilot Agent ako klienta pre váš MCP Server.

## Ciele učenia

Na konci tejto lekcie budete vedieť:

- Využívať MCP Server cez Visual Studio Code.
- Spúšťať funkcie ako nástroje cez GitHub Copilot.
- Nastaviť Visual Studio Code tak, aby našiel a spravoval váš MCP Server.

## Použitie

Svoj MCP server môžete ovládať dvoma spôsobmi:

- Používateľské rozhranie, ukážeme si to neskôr v tejto kapitole.
- Terminál, je možné ovládať server aj z terminálu pomocou spustiteľného súboru `code`:

  Na pridanie MCP servera do vášho používateľského profilu použite príkazovú voľbu --add-mcp a poskytnite JSON konfiguráciu servera vo formáte {\"name\":\"server-name\",\"command\":...}.

  ```
  code --add-mcp "{\"name\":\"my-server\",\"command\": \"uvx\",\"args\": [\"mcp-server-fetch\"]}"
  ```

### Snímky obrazovky

![Sprievodná konfigurácia MCP servera vo Visual Studio Code](../../../../translated_images/chat-mode-agent.729a22473f822216dd1e723aaee1f7d4a2ede571ee0948037a2d9357a63b9d0b.sk.png)  
![Výber nástrojov pre agentnú reláciu](../../../../translated_images/agent-mode-select-tools.522c7ba5df0848f8f0d1e439c2e96159431bc620cb39ccf3f5dc611412fd0006.sk.png)  
![Jednoduché ladenie chýb počas vývoja MCP](../../../../translated_images/mcp-list-servers.fce89eefe3f30032bed8952e110ab9d82fadf043fcfa071f7d40cf93fb1ea9e9.sk.png)

V ďalších častiach si podrobnejšie vysvetlíme, ako používať vizuálne rozhranie.

## Prístup

Takto by sme mali postupovať na vyššej úrovni:

- Nastaviť súbor, ktorý nájde náš MCP Server.
- Spustiť/pripojiť sa k serveru, aby sme získali zoznam jeho funkcií.
- Používať tieto funkcie cez rozhranie GitHub Copilot Chat.

Skvelé, keď už chápeme tento postup, poďme si vyskúšať používanie MCP Servera vo Visual Studio Code v praktickej úlohe.

## Cvičenie: Použitie servera

V tomto cvičení nastavíme Visual Studio Code tak, aby našiel váš MCP server a mohol ho používať cez rozhranie GitHub Copilot Chat.

### -0- Predkrok, povolenie vyhľadávania MCP Serverov

Možno budete musieť povoliť vyhľadávanie MCP Serverov.

1. Choďte do `File -> Preferences -> Settings` vo Visual Studio Code.

1. Vyhľadajte "MCP" a povoľte `chat.mcp.discovery.enabled` v súbore settings.json.

### -1- Vytvorenie konfiguračného súboru

Začnite vytvorením konfiguračného súboru v koreňovom adresári vášho projektu. Potrebujete súbor s názvom MCP.json, ktorý umiestnite do priečinka .vscode. Mal by vyzerať takto:

```text
.vscode
|-- mcp.json
```

Teraz si ukážeme, ako pridať záznam o serveri.

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

Vyššie je jednoduchý príklad, ako spustiť server napísaný v Node.js. Pre iné runtime prostredia uveďte správny príkaz na spustenie servera pomocou `command` a `args`.

### -3- Spustenie servera

Keď ste pridali záznam, spustíme server:

1. Nájdite svoj záznam v *mcp.json* a uistite sa, že vidíte ikonu "play":

  ![Spustenie servera vo Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.sk.png)  

1. Kliknite na ikonu "play", mali by ste vidieť, že ikona nástrojov v GitHub Copilot Chat sa zmení a zobrazí viac dostupných nástrojov. Po kliknutí na túto ikonu sa zobrazí zoznam registrovaných nástrojov. Môžete ich zaškrtnúť alebo odškrtnúť podľa toho, či chcete, aby ich GitHub Copilot používal ako kontext:

  ![Spustenie servera vo Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.sk.png)

1. Na spustenie nástroja zadajte prompt, o ktorom viete, že zodpovedá popisu niektorého z vašich nástrojov, napríklad prompt "add 22 to 1":

  ![Spustenie nástroja z GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.sk.png)

  Mali by ste dostať odpoveď 23.

## Zadanie

Skúste pridať záznam o serveri do vášho *mcp.json* súboru a overte, že viete server spustiť a zastaviť. Tiež sa uistite, že môžete komunikovať s nástrojmi na vašom serveri cez rozhranie GitHub Copilot Chat.

## Riešenie

[Riešenie](./solution/README.md)

## Kľúčové poznatky

Z tejto kapitoly si odnesiete:

- Visual Studio Code je skvelý klient, ktorý umožňuje využívať viac MCP Serverov a ich nástrojov.
- Rozhranie GitHub Copilot Chat je spôsob, ako so servermi komunikovať.
- Môžete vyzvať používateľa na zadanie vstupov, ako sú API kľúče, ktoré sa potom odovzdajú MCP Serveru pri konfigurácii záznamu v *mcp.json*.

## Ukážky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatočné zdroje

- [Visual Studio dokumentácia](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Čo ďalej

- Ďalej: [Vytvorenie SSE Servera](../05-sse-server/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.