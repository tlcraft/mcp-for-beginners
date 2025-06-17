<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:18:59+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "sl"
}
-->
# Zagon vzorca

Tukaj predpostavljamo, da že imate delujočo kodo strežnika. Prosimo, poiščite strežnik iz enega od prejšnjih poglavij.

## Nastavitev mcp.json

Tukaj je datoteka, ki jo uporabljate kot referenco, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Spremenite vnos strežnika po potrebi, da bo kazal na absolutno pot do vašega strežnika, vključno z vsemi potrebnimi ukazi za zagon.

V zgornjem primerku datoteke vnos strežnika izgleda takole:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

To ustreza zagonu ukaza, kot je: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` in vtipkajte nekaj v stilu "add 3 to 20".

    Nad besedilnim poljem za klepet bi se moral prikazati pripomoček, ki vas poziva, da izberete zagon orodja, kot na tej sliki:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.sl.png)

    Izbira orodja bi morala prikazati numerični rezultat "23", če je vaš poziv podoben prej omenjenemu.

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne prevzemamo odgovornosti.