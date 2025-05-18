<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:22:11+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "nl"
}
-->
# Het voorbeeld uitvoeren

Hier gaan we ervan uit dat je al werkende servercode hebt. Zoek een server uit een van de eerdere hoofdstukken.

## Stel mcp.json in

Hier is een bestand dat je als referentie gebruikt, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Wijzig de serververmelding indien nodig om het absolute pad naar je server aan te geven, inclusief het volledige benodigde commando om uit te voeren.

In het voorbeeldbestand dat hierboven is genoemd, ziet de serververmelding er als volgt uit:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

Dit komt overeen met het uitvoeren van een commando zoals: `cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` typ iets zoals "voeg 3 toe aan 20".

    Je zou een hulpmiddel boven het chattekstvak moeten zien dat aangeeft dat je het hulpmiddel moet selecteren om uit te voeren, zoals in deze afbeelding:

    ![VS Code dat aangeeft een hulpmiddel te willen uitvoeren](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.nl.png)

    Het selecteren van het hulpmiddel zou een numeriek resultaat moeten opleveren dat "23" zegt als je prompt was zoals we eerder noemden.

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, willen we u erop wijzen dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in zijn oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of misinterpretaties die voortvloeien uit het gebruik van deze vertaling.