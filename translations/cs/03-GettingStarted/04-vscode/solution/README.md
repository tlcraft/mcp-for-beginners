<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:23:36+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "cs"
}
-->
# Spuštění ukázky

Zde předpokládáme, že již máte funkční kód serveru. Najděte server z jedné z předchozích kapitol.

## Nastavení mcp.json

Zde je soubor, který použijete jako referenci, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Upravte položku serveru podle potřeby tak, aby ukazovala na absolutní cestu k vašemu serveru, včetně potřebného úplného příkazu ke spuštění.

V příkladu souboru uvedeném výše vypadá položka serveru takto:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

To odpovídá spuštění příkazu takto: `cmd /c node <absolutní cesta>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` zadejte něco jako "přidej 3 k 20".

    Nad textovým polem chatu byste měli vidět nástroj, který vás vyzývá k jeho spuštění, jako na tomto obrázku:

    ![VS Code naznačující, že chce spustit nástroj](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.cs.png)

    Výběr nástroje by měl vyprodukovat číselný výsledek říkající "23", pokud byl váš vstup tak, jak jsme zmínili dříve.

**Prohlášení**:  
Tento dokument byl přeložen pomocí služby AI překladače [Co-op Translator](https://github.com/Azure/co-op-translator). Ačkoli se snažíme o přesnost, vezměte prosím na vědomí, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme zodpovědní za jakékoli nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.