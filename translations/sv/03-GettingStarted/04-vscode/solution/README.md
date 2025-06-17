<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:51:14+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "sv"
}
-->
# Köra exemplet

Här antar vi att du redan har en fungerande serverkod. Vänligen hitta en server från ett av de tidigare kapitlen.

## Ställ in mcp.json

Här är en fil du kan använda som referens, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Ändra serverposten vid behov så att den pekar på den absoluta sökvägen till din server inklusive den fullständiga kommandoraden som krävs för att köra.

I exempel-filen som nämns ovan ser serverposten ut så här:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Detta motsvarar att köra ett kommando som detta: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` skriv något som "add 3 to 20".

    Du bör se ett verktyg visas ovanför chattens textfält som visar att du kan välja att köra verktyget, ungefär så här:

    ![VS Code indikerar att den vill köra ett verktyg](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.sv.png)

    Att välja verktyget bör ge ett numeriskt resultat som säger "23" om din prompt var som vi nämnde tidigare.

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål ska betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår från användningen av denna översättning.