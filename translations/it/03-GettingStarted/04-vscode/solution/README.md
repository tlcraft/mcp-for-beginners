<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:43:00+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "it"
}
-->
# Esecuzione dell'esempio

Qui si assume che tu abbia già un codice server funzionante. Per favore, individua un server da uno dei capitoli precedenti.

## Configurare mcp.json

Ecco un file che puoi usare come riferimento, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Modifica la voce server come necessario per indicare il percorso assoluto al tuo server, includendo il comando completo necessario per l'esecuzione.

Nel file di esempio citato sopra, la voce server appare così:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Questo corrisponde a eseguire un comando del tipo: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` digita qualcosa come "add 3 to 20".

    Dovresti vedere uno strumento apparire sopra la casella di testo della chat che ti indica di selezionare lo strumento da eseguire, come mostrato in questa immagine:

    ![VS Code che indica la volontà di eseguire uno strumento](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.it.png)

    Selezionando lo strumento dovrebbe comparire un risultato numerico con il valore "23" se il tuo prompt era come quello menzionato prima.

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un essere umano. Non ci assumiamo alcuna responsabilità per eventuali incomprensioni o interpretazioni errate derivanti dall’uso di questa traduzione.