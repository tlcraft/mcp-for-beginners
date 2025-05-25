<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:23:45+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "sk"
}
-->
# Spustenie ukážky

Predpokladáme, že už máte funkčný kód servera. Nájdite server z jednej z predchádzajúcich kapitol.

## Nastavenie mcp.json

Tu je súbor, ktorý môžete použiť ako referenciu, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Zmeňte záznam servera podľa potreby tak, aby ukazoval na absolútnu cestu k vášmu serveru vrátane potrebného úplného príkazu na spustenie.

V príkladovom súbore uvedenom vyššie záznam servera vyzerá takto:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

To zodpovedá spusteniu príkazu takto: `cmd /c node <absolútna cesta>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` napíšte niečo ako "pridať 3 k 20".

Mali by ste vidieť nástroj, ktorý sa zobrazí nad textovým poľom chatu, čo naznačuje, že si máte vybrať spustenie nástroja ako na tomto obrázku:

![VS Code naznačujúci, že chce spustiť nástroj](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.sk.png)

Výber nástroja by mal priniesť číselný výsledok hovoriaci "23", ak váš príkaz bol taký, ako sme spomenuli predtým.

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, uvedomte si, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.