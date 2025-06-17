<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:06:05+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "sw"
}
-->
# Kuendesha sampuli

Hapa tunadhani tayari una msimbo wa server unaofanya kazi. Tafadhali tafuta server kutoka mojawapo ya sura za awali.

## Weka mcp.json

Hapa kuna faili unayotumia kama rejea, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Badilisha kipengee cha server kadri inavyohitajika kuonyesha njia kamili ya server yako pamoja na amri kamili inayohitajika kuendesha.

Katika faili la mfano lililotajwa hapo juu, kipengee cha server kinaonekana hivi:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Hii inahusiana na kuendesha amri kama ifuatavyo: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` andika kitu kama "ongeza 3 kwa 20".

    Unapaswa kuona chombo kinachoonyeshwa juu ya kisanduku cha mazungumzo kikikuonyesha uchague kuendesha chombo kama katika picha hii:

    ![VS Code ikionyesha inataka kuendesha chombo](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.sw.png)

    Kuchagua chombo kunapaswa kutoa matokeo ya nambari ikisema "23" ikiwa ombi lako lilikuwa kama tulivyotaja awali.

**Kiasi cha maelezo**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za moja kwa moja zinaweza kuwa na makosa au upungufu wa usahihi. Hati asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inashauriwa. Hatuna wajibu wowote kwa kutokuelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.