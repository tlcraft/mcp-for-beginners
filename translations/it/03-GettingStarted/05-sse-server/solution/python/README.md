<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:02:34+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "it"
}
-->
# Eseguire questo esempio

Si consiglia di installare `uv` ma non è obbligatorio, vedere [istruzioni](https://docs.astral.sh/uv/#highlights)

## -0- Creare un ambiente virtuale

```bash
python -m venv venv
```

## -1- Attivare l'ambiente virtuale

```bash
venv\Scrips\activate
```

## -2- Installare le dipendenze

```bash
pip install "mcp[cli]"
```

## -3- Eseguire l'esempio

```bash
mcp run server.py
```

## -4- Testare l'esempio

Con il server in esecuzione in un terminale, apri un altro terminale ed esegui il seguente comando:

```bash
mcp dev server.py
```

Questo dovrebbe avviare un server web con un'interfaccia visiva che ti permette di testare l'esempio.

Una volta che il server è connesso:

- prova a elencare gli strumenti ed esegui `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` è un wrapper attorno ad esso.

Puoi avviarlo direttamente in modalità CLI eseguendo il seguente comando:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
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

Per invocare uno strumento digita:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Di solito è molto più veloce eseguire l'inspector in modalità CLI che nel browser.
> Leggi di più sull'inspector [qui](https://github.com/modelcontextprotocol/inspector).

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per l'accuratezza, si prega di essere consapevoli che le traduzioni automatizzate possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.