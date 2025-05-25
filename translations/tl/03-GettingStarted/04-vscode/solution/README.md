<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:23:06+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "tl"
}
-->
# Pagpapatakbo ng halimbawa

Dito, inaakala namin na mayroon ka nang gumaganang server code. Mangyaring hanapin ang isang server mula sa isa sa mga naunang kabanata.

## I-set up ang mcp.json

Narito ang isang file na ginagamit mo para sa sanggunian, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Baguhin ang entry ng server ayon sa kinakailangan upang ituro ang tiyak na landas sa iyong server kasama ang kinakailangang buong utos para patakbuhin ito.

Sa halimbawa ng file na binanggit sa itaas, ang entry ng server ay ganito ang hitsura:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

Ito ay tumutukoy sa pagpapatakbo ng isang utos na ganito: `cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` magsulat ng isang bagay tulad ng "idagdag ang 3 sa 20".

Makikita mo ang isang tool na ipinapakita sa itaas ng chat text box na nagpapahiwatig para piliin mong patakbuhin ang tool tulad ng sa visual na ito:

![VS Code na nagpapahiwatig na nais nitong patakbuhin ang isang tool](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.tl.png)

Ang pagpili sa tool ay dapat magresulta sa isang numerong resulta na nagsasabing "23" kung ang iyong prompt ay tulad ng nabanggit namin dati.

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Habang sinisikap naming maging tumpak, pakitandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatumpak. Ang orihinal na dokumento sa kanyang katutubong wika ay dapat ituring na mapagkakatiwalaang pinagmulan. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na nagmumula sa paggamit ng pagsasaling ito.