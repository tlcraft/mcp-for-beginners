<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:54:02+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "no"
}
-->
# Kjøre eksempelet

Her antar vi at du allerede har en fungerende serverkode. Vennligst finn en server fra et av de tidligere kapitlene.

## Sett opp mcp.json

Her er en fil du kan bruke som referanse, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Endre serveroppføringen etter behov for å peke til den absolutte banen til serveren din, inkludert den nødvendige fullstendige kommandoen for å kjøre den.

I eksempel-filen nevnt ovenfor ser serveroppføringen slik ut:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Dette tilsvarer å kjøre en kommando som denne: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` skriv noe som "add 3 to 20".

    Du bør se et verktøy bli vist over tekstboksen for chat, som indikerer at du kan velge å kjøre verktøyet, slik som i denne visuelle fremstillingen:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.no.png)

    Å velge verktøyet skal gi et numerisk resultat som sier "23" hvis prompten din var som vi nevnte tidligere.

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på dets opprinnelige språk skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår som følge av bruk av denne oversettelsen.