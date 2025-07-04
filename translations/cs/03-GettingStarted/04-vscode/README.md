<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "54e9ffc5dba01afcb8880a9949fd1881",
  "translation_date": "2025-07-04T18:37:56+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "cs"
}
-->
Pojďme si v dalších částech více povědět o tom, jak používáme vizuální rozhraní.

## Přístup

Zde je, jak k tomu musíme přistoupit na vysoké úrovni:

- Nakonfigurovat soubor, aby našel náš MCP Server.
- Spustit/Připojit se k danému serveru, aby vypsal své schopnosti.
- Používat tyto schopnosti přes rozhraní GitHub Copilot Chat.

Skvěle, teď když rozumíme postupu, pojďme si vyzkoušet použití MCP Serveru ve Visual Studio Code v rámci cvičení.

## Cvičení: Použití serveru

V tomto cvičení nakonfigurujeme Visual Studio Code tak, aby našel váš MCP server a mohl být použit z rozhraní GitHub Copilot Chat.

### -0- Předkrok, povolení objevování MCP Serverů

Možná budete muset povolit objevování MCP Serverů.

1. Přejděte do `Soubor -> Předvolby -> Nastavení` ve Visual Studio Code.

1. Vyhledejte "MCP" a povolte `chat.mcp.discovery.enabled` v souboru settings.json.

### -1- Vytvoření konfiguračního souboru

Začněte vytvořením konfiguračního souboru v kořenovém adresáři projektu, budete potřebovat soubor s názvem MCP.json, který umístíte do složky .vscode. Měl by vypadat takto:

```text
.vscode
|-- mcp.json
```

Dále si ukážeme, jak přidat záznam serveru.

### -2- Konfigurace serveru

Přidejte následující obsah do *mcp.json*:

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

Výše je jednoduchý příklad, jak spustit server napsaný v Node.js, pro jiné runtime uveďte správný příkaz pro spuštění serveru pomocí `command` a `args`.

### -3- Spuštění serveru

Nyní, když jste přidali záznam, spusťte server:

1. Najděte svůj záznam v *mcp.json* a ujistěte se, že vidíte ikonu "play":

  ![Spuštění serveru ve Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.cs.png)  

1. Klikněte na ikonu "play", měli byste vidět, že ikona nástrojů v GitHub Copilot Chat zvýší počet dostupných nástrojů. Pokud na tuto ikonu kliknete, uvidíte seznam registrovaných nástrojů. Můžete jednotlivé nástroje zaškrtnout nebo odškrtnout podle toho, zda chcete, aby je GitHub Copilot používal jako kontext:

  ![Spuštění serveru ve Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.cs.png)

1. Pro spuštění nástroje napište prompt, o kterém víte, že odpovídá popisu některého z vašich nástrojů, například prompt „add 22 to 1“:

  ![Spuštění nástroje z GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.cs.png)

  Měli byste vidět odpověď s hodnotou 23.

## Zadání

Zkuste přidat záznam serveru do svého souboru *mcp.json* a ujistěte se, že můžete server spustit a zastavit. Také ověřte, že můžete komunikovat s nástroji na vašem serveru přes rozhraní GitHub Copilot Chat.

## Řešení

[Řešení](./solution/README.md)

## Klíčové poznatky

Z tohoto kapitoly si odnesete následující:

- Visual Studio Code je skvělý klient, který vám umožní používat několik MCP Serverů a jejich nástrojů.
- Rozhraní GitHub Copilot Chat je způsob, jak komunikovat se servery.
- Můžete vyzvat uživatele k zadání vstupů, jako jsou API klíče, které lze předat MCP Serveru při konfiguraci záznamu serveru v souboru *mcp.json*.

## Ukázky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Další zdroje

- [Visual Studio dokumentace](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Co dál

- Další: [Vytvoření SSE serveru](../05-sse-server/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.