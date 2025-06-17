<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:57:02+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "nl"
}
-->
# De sample uitvoeren

Hier gaan we ervan uit dat je al een werkende servercode hebt. Zoek een server op uit een van de eerdere hoofdstukken.

## Stel mcp.json in

Hier is een bestand dat je als referentie gebruikt, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Pas de serververmelding aan waar nodig om het absolute pad naar je server aan te geven, inclusief het volledige commando dat nodig is om te draaien.

In het voorbeeldbestand hierboven ziet de serververmelding er als volgt uit:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Dit komt overeen met het uitvoeren van een commando zoals: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` typ iets als "add 3 to 20".

    Je zou een tool boven het chattekstvak moeten zien verschijnen die aangeeft dat je de tool kunt selecteren om deze uit te voeren, zoals in deze afbeelding:

    ![VS Code geeft aan dat het een tool wil uitvoeren](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.nl.png)

    Het selecteren van de tool zou een numeriek resultaat moeten opleveren met "23" als je prompt was zoals eerder genoemd.

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal geldt als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.