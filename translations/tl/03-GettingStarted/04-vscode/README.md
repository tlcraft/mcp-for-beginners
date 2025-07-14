<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "222e01c3002a33355806d60d558d9429",
  "translation_date": "2025-07-14T09:40:15+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "tl"
}
-->
Pag-usapan pa natin kung paano gamitin ang visual interface sa mga susunod na bahagi.

## Paraan

Ganito ang pangkalahatang paraan ng paglapit dito:

- I-configure ang isang file para mahanap ang ating MCP Server.
- Simulan/Kumonekta sa nasabing server para makita ang mga kakayahan nito.
- Gamitin ang mga kakayahang iyon sa pamamagitan ng GitHub Copilot Chat interface.

Maganda, ngayon na naiintindihan na natin ang daloy, subukan nating gamitin ang MCP Server sa Visual Studio Code sa pamamagitan ng isang pagsasanay.

## Pagsasanay: Paggamit ng server

Sa pagsasanay na ito, i-configure natin ang Visual Studio Code para mahanap ang iyong MCP server upang magamit ito mula sa GitHub Copilot Chat interface.

### -0- Paunang hakbang, i-enable ang MCP Server discovery

Maaaring kailanganin mong i-enable ang discovery ng MCP Servers.

1. Pumunta sa `File -> Preferences -> Settings` sa Visual Studio Code.

1. Hanapin ang "MCP" at i-enable ang `chat.mcp.discovery.enabled` sa settings.json file.

### -1- Gumawa ng config file

Magsimula sa paggawa ng config file sa root ng iyong proyekto, kailangan mo ng file na tinatawag na MCP.json at ilagay ito sa folder na tinatawag na .vscode. Dapat itong ganito ang itsura:

```text
.vscode
|-- mcp.json
```

Sunod, tingnan natin kung paano magdagdag ng entry ng server.

### -2- I-configure ang server

Idagdag ang sumusunod na nilalaman sa *mcp.json*:

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

Narito ang isang simpleng halimbawa kung paano simulan ang server na nakasulat sa Node.js, para sa ibang runtime, ituro ang tamang command para simulan ang server gamit ang `command` at `args`.

### -3- Simulan ang server

Ngayon na nakadagdag ka na ng entry, simulan natin ang server:

1. Hanapin ang iyong entry sa *mcp.json* at siguraduhing makita mo ang "play" icon:

  ![Pagsisimula ng server sa Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.tl.png)  

1. I-click ang "play" icon, makikita mo dapat na tataas ang bilang ng mga available na tools sa GitHub Copilot Chat tools icon. Kapag na-click mo ang tools icon, makikita mo ang listahan ng mga rehistradong tools. Pwede mong i-check/uncheck ang bawat tool depende kung gusto mong gamitin ito ng GitHub Copilot bilang konteksto:

  ![Pagsisimula ng server sa Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.tl.png)

1. Para patakbuhin ang isang tool, mag-type ng prompt na alam mong tugma sa paglalarawan ng isa sa iyong mga tool, halimbawa isang prompt na ganito "add 22 to 1":

  ![Pagpapatakbo ng tool mula sa GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.tl.png)

  Dapat kang makakita ng sagot na nagsasabing 23.

## Takdang Aralin

Subukang magdagdag ng server entry sa iyong *mcp.json* file at siguraduhing kaya mong simulan/hintuin ang server. Siguraduhin mo rin na makipag-ugnayan ka sa mga tools sa iyong server gamit ang GitHub Copilot Chat interface.

## Solusyon

[Solution](./solution/README.md)

## Mahahalagang Punto

Ang mga mahahalagang punto mula sa kabanatang ito ay ang mga sumusunod:

- Ang Visual Studio Code ay isang mahusay na client na nagpapahintulot sa iyo na gamitin ang iba't ibang MCP Servers at ang kanilang mga tools.
- Ang GitHub Copilot Chat interface ang paraan ng pakikipag-ugnayan mo sa mga server.
- Maaari kang mag-prompt sa user para sa mga input tulad ng API keys na maaaring ipasa sa MCP Server kapag kino-configure ang server entry sa *mcp.json* file.

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Karagdagang Mga Sanggunian

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Ano ang Susunod

- Susunod: [Paglikha ng SSE Server](../05-sse-server/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.