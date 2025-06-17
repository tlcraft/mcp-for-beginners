<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:04:35+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "tl"
}
-->
# Pagpapatakbo ng halimbawa

Dito, ipinagpapalagay namin na mayroon ka nang gumaganang server code. Mangyaring hanapin ang server mula sa isa sa mga naunang kabanata.

## I-set up ang mcp.json

Narito ang isang file na maaari mong gamitin bilang sanggunian, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Palitan ang server entry ayon sa kinakailangan upang ituro ang absolutong path ng iyong server kasama ang buong utos na kailangang patakbuhin.

Sa halimbawa ng file na tinutukoy sa itaas, ganito ang hitsura ng server entry:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Ito ay tumutukoy sa pagpapatakbo ng utos na ganito: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` mag-type ng bagay tulad ng "add 3 to 20".

    Makikita mo ang isang tool na ipinapakita sa itaas ng chat text box na nagsasaad na kailangan mong piliin ito upang patakbuhin ang tool tulad ng nasa visual na ito:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.tl.png)

    Ang pagpili sa tool ay magbibigay ng numerikong resulta na nagsasabing "23" kung ang iyong prompt ay tulad ng nabanggit namin kanina.

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang serbisyong AI na pagsasalin [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.