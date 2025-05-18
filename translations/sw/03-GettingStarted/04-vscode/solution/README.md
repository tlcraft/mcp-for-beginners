<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:23:16+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "sw"
}
-->
# Kuendesha sampuli

Hapa tunadhani tayari una msimbo wa seva unaofanya kazi. Tafadhali tafuta seva kutoka kwenye mojawapo ya sura za awali.

## Sanidi mcp.json

Hapa kuna faili unayotumia kama rejeleo, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Badilisha sehemu ya seva kama inavyohitajika ili kuelekeza kwenye njia kamili ya seva yako ikijumuisha amri kamili inayohitajika kuendesha.

Katika faili ya mfano iliyorejelewa hapo juu, sehemu ya seva inaonekana hivi:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

Hii inalingana na kuendesha amri kama hii: `cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` andika kitu kama "ongeza 3 kwa 20".

Unapaswa kuona chombo kikiwasilishwa juu ya kisanduku cha maandishi cha mazungumzo kikionyesha uchague kuendesha chombo kama inavyoonekana katika picha hii:

![VS Code ikionyesha inataka kuendesha chombo](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.sw.png)

Kuchagua chombo kunapaswa kutoa matokeo ya nambari yakisema "23" ikiwa mwongozo wako ulikuwa kama tulivyotaja hapo awali.

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya kibinadamu inapendekezwa. Hatuwajibiki kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.