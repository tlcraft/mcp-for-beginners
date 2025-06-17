<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:09:18+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "cs"
}
-->
# Spuštění ukázky

Předpokládáme, že už máte funkční kód serveru. Najděte prosím server z některé z předchozích kapitol.

## Nastavení mcp.json

Toto je soubor, který můžete použít jako referenci, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Upravte položku server podle potřeby tak, aby ukazovala na absolutní cestu k vašemu serveru včetně kompletního příkazu k jeho spuštění.

V příkladovém souboru zmíněném výše vypadá položka server takto:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

To odpovídá spuštění příkazu ve tvaru: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add`, napište něco jako "add 3 to 20".

    Měli byste vidět nástroj zobrazený nad textovým polem chatu, který vás vyzve k jeho spuštění, podobně jako na tomto obrázku:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.cs.png)

    Výběr nástroje by měl vrátit číselný výsledek "23", pokud váš příkaz byl podobný tomu, který jsme zmínili výše.

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo chybné výklady vyplývající z použití tohoto překladu.