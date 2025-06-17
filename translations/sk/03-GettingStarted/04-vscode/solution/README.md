<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:10:52+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "sk"
}
-->
# Spustenie ukážky

Predpokladáme, že už máte funkčný serverový kód. Nájdite server z niektorej z predchádzajúcich kapitol.

## Nastavenie mcp.json

Tu je súbor, ktorý používate ako referenciu, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Zmeňte položku server podľa potreby tak, aby ukazovala na absolútnu cestu k vášmu serveru vrátane potrebného úplného príkazu na spustenie.

V príkladovom súbore uvedenom vyššie vyzerá položka server takto:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

To zodpovedá spusteniu príkazu v tvare: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` a zadajte niečo ako "add 3 to 20".

    Mali by ste vidieť, že nad textovým políčkom chatu sa zobrazí nástroj, ktorý vás vyzýva na jeho spustenie, ako je to znázornené na tomto obrázku:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.sk.png)

    Výber nástroja by mal vygenerovať číselný výsledok "23", ak bol váš vstup ako sme uviedli vyššie.

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.