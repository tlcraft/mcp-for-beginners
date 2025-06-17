<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:52:37+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "da"
}
-->
# Kør eksemplet

Her antager vi, at du allerede har en fungerende serverkode. Find venligst en server fra et af de tidligere kapitler.

## Opsæt mcp.json

Her er en fil, du kan bruge som reference, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Ændr serverindgangen efter behov, så den peger på den absolutte sti til din server inklusive den nødvendige fulde kommando til at køre.

I eksempel-filen nævnt ovenfor ser serverindgangen således ud:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Dette svarer til at køre en kommando som: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` skriv noget som "add 3 to 20".

    Du skulle kunne se et værktøj blive vist over chat-tekstboksen, som beder dig om at vælge at køre værktøjet, som vist her:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.da.png)

    At vælge værktøjet skulle give et numerisk resultat, der siger "23", hvis din prompt var som nævnt tidligere.

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.