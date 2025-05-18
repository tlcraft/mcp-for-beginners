<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:23:16+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "it"
}
-->
# Esecuzione di questo esempio

Si consiglia di installare `uv` ma non è obbligatorio, vedere [istruzioni](https://docs.astral.sh/uv/#highlights)

## -1- Installare le dipendenze

```bash
npm install
```

## -3- Eseguire l'esempio

```bash
npm run build
```

## -4- Testare l'esempio

Con il server in esecuzione in un terminale, apri un altro terminale ed esegui il seguente comando:

```bash
npm run inspector
```

Questo dovrebbe avviare un server web con un'interfaccia visiva che ti consente di testare l'esempio.

Una volta che il server è connesso:

- prova a elencare gli strumenti ed eseguire `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` è un wrapper intorno ad esso.

Puoi avviarlo direttamente in modalità CLI eseguendo il seguente comando:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Questo elencherà tutti gli strumenti disponibili nel server. Dovresti vedere il seguente output:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

Per invocare uno strumento, digita:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Dovresti vedere il seguente output:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Di solito è molto più veloce eseguire l'ispector in modalità CLI piuttosto che nel browser.
> Leggi di più sull'ispector [qui](https://github.com/modelcontextprotocol/inspector).

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per l'accuratezza, si prega di essere consapevoli che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua madre dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali malintesi o interpretazioni errate derivanti dall'uso di questa traduzione.