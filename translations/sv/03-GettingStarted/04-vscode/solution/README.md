<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:21:22+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "sv"
}
-->
# Köra exemplet

Här antar vi att du redan har fungerande serverkod. Vänligen lokalisera en server från ett av de tidigare kapitlen.

## Ställ in mcp.json

Här är en fil du använder som referens, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Ändra serverposten vid behov för att peka ut den absoluta sökvägen till din server inklusive det nödvändiga fullständiga kommandot för att köra.

I den exempel fil som hänvisas ovan ser serverposten ut så här:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

Detta motsvarar att köra ett kommando som så: `cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` skriv något som "lägg till 3 till 20".

Du borde se ett verktyg presenteras ovanför chattens textfält som indikerar att du ska välja att köra verktyget som i denna visuella:

![VS Code som indikerar att det vill köra ett verktyg](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.sv.png)

Att välja verktyget bör ge ett numeriskt resultat som säger "23" om din prompt var som vi nämnde tidigare.

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, var medveten om att automatiserade översättningar kan innehålla fel eller felaktigheter. Det ursprungliga dokumentet på dess originalspråk bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för missförstånd eller misstolkningar som uppstår vid användning av denna översättning.