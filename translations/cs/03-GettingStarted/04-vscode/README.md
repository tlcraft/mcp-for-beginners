<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c37fabfbc0dcbc9a4afb6d17e7d3be9f",
  "translation_date": "2025-05-27T16:22:19+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "cs"
}
-->
Pojďme si v dalších částech více povědět o tom, jak používat vizuální rozhraní.

## Přístup

Zde je obecný postup, jak na to:

- Nakonfigurovat soubor, který najde náš MCP Server.
- Spustit/Připojit se k serveru, aby vypsal své schopnosti.
- Použít tyto schopnosti přes chatovací rozhraní GitHub Copilota.

Skvělé, teď když rozumíme postupu, pojďme si vyzkoušet použití MCP Serveru ve Visual Studio Code v rámci cvičení.

## Cvičení: Použití serveru

V tomto cvičení nakonfigurujeme Visual Studio Code tak, aby našlo váš MCP server a mohl být použit přes chatovací rozhraní GitHub Copilota.

### -0- Předběžný krok, povolení objevování MCP Serverů

Možná bude potřeba povolit objevování MCP Serverů.

1. Jděte do `File -> Preferences -> Settings` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` v souboru settings.json.

### -1- Vytvoření konfiguračního souboru

Začněte vytvořením konfiguračního souboru v kořenovém adresáři projektu. Potřebujete soubor s názvem MCP.json, který umístíte do složky .vscode. Měl by vypadat takto:

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
           "command": "cmd",
           "args": [
               "/c", "node", "<absolute path>\\build\\index.js"
           ]
       }
    }
}
```

Výše je jednoduchý příklad, jak spustit server napsaný v Node.js. U jiných runtime prosím uveďte správný příkaz pro spuštění serveru pomocí `command` and `args`.

### -3- Spuštění serveru

Teď když jste přidali záznam, spusťme server:

1. Najděte svůj záznam v *mcp.json* a ujistěte se, že vidíte ikonu „play“:

  ![Spuštění serveru ve Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.cs.png)  

2. Klikněte na ikonu „play“, měli byste vidět, že se v chatu GitHub Copilota zvýší počet dostupných nástrojů. Po kliknutí na ikonu nástrojů se zobrazí seznam registrovaných nástrojů. Můžete jednotlivé nástroje zaškrtnout nebo odškrtnout podle toho, zda chcete, aby je GitHub Copilot používal jako kontext:

  ![Nástroje ve Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.cs.png)

3. Pro spuštění nástroje napište prompt, o kterém víte, že odpovídá popisu některého z vašich nástrojů, například „add 22 to 1“:

  ![Spuštění nástroje z GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.cs.png)

  Měli byste vidět odpověď s výsledkem 23.

## Úkol

Zkuste přidat záznam serveru do svého *mcp.json* souboru a ověřte, že můžete server spustit i zastavit. Také si ověřte, že můžete komunikovat s nástroji na vašem serveru přes chatovací rozhraní GitHub Copilota.

## Řešení

[Řešení](./solution/README.md)

## Klíčové body

Hlavní body z této kapitoly jsou:

- Visual Studio Code je skvělý klient, který umožňuje používat více MCP Serverů a jejich nástrojů.
- S GitHub Copilot chatovacím rozhraním komunikujete se servery.
- Můžete vyzvat uživatele k zadání vstupů, například API klíčů, které lze předat MCP Serveru při konfiguraci záznamu v *mcp.json*.

## Ukázky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Další zdroje

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Co bude dál

- Dále: [Vytvoření SSE Serveru](/03-GettingStarted/05-sse-server/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.