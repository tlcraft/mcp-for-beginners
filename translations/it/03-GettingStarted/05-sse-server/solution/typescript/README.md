<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:09:37+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "it"
}
-->
# Esecuzione di questo esempio

## -1- Installa le dipendenze

```bash
npm install
```

## -3- Esegui l'esempio

```bash
npm run build
```

## -4- Testa l'esempio

Con il server in esecuzione in un terminale, apri un altro terminale ed esegui il seguente comando:

```bash
npm run inspector
```

Questo dovrebbe avviare un server web con un'interfaccia visiva che ti consente di testare l'esempio.

Una volta che il server è connesso:

- prova a elencare gli strumenti ed esegui `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build`.

- In un terminale separato esegui il seguente comando:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
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

- Invoca un tipo di strumento digitando il seguente comando:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Dovresti vedere il seguente output:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> Di solito è molto più veloce eseguire l'ispector in modalità CLI rispetto al browser.
> Leggi di più sull'ispector [qui](https://github.com/modelcontextprotocol/inspector).

**Disclaimer**: 
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Anche se ci impegniamo per l'accuratezza, si prega di essere consapevoli che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.