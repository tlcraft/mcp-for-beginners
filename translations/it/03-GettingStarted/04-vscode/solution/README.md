<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:20:37+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "it"
}
-->
# Eseguire l'esempio

Qui presupponiamo che tu abbia già un codice server funzionante. Trova un server da uno dei capitoli precedenti.

## Configurare mcp.json

Ecco un file che usi come riferimento, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Modifica l'entry del server come necessario per indicare il percorso assoluto del tuo server, incluso il comando completo necessario per eseguirlo.

Nel file di esempio menzionato sopra, l'entry del server appare così:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

Questo corrisponde all'esecuzione di un comando come: `cmd /c node <percorso assoluto>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` scrivi qualcosa come "aggiungi 3 a 20".

    Dovresti vedere uno strumento presentato sopra la casella di testo della chat che ti indica di selezionare per eseguire lo strumento come in questo esempio visivo:

    ![VS Code che indica di voler eseguire uno strumento](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.it.png)

    Selezionando lo strumento dovrebbe produrre un risultato numerico dicendo "23" se il tuo prompt era come abbiamo menzionato in precedenza.

**Dichiarazione di non responsabilità**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Anche se ci impegniamo per garantire l'accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua madre deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali malintesi o interpretazioni errate derivanti dall'uso di questa traduzione.