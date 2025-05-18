<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:55:26+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "it"
}
-->
# Eseguire questo esempio

## -1- Installa le dipendenze

```bash
dotnet run
```

## -2- Esegui l'esempio

```bash
dotnet run
```

## -3- Testa l'esempio

Avvia un terminale separato prima di eseguire i comandi sottostanti (assicurati che il server sia ancora in esecuzione).

Con il server in esecuzione in un terminale, apri un altro terminale ed esegui il seguente comando:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Questo dovrebbe avviare un server web con un'interfaccia visiva che ti permetterà di testare l'esempio.

Una volta che il server è connesso:

- prova a elencare gli strumenti e eseguire `add`, con argomenti 2 e 4, dovresti vedere 6 nel risultato.
- vai alle risorse e al modello di risorse e chiama "greeting", inserisci un nome e dovresti vedere un saluto con il nome che hai fornito.

### Test in modalità CLI

Puoi avviarlo direttamente in modalità CLI eseguendo il seguente comando:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Questo elencherà tutti gli strumenti disponibili nel server. Dovresti vedere il seguente output:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Per invocare uno strumento digita:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> Di solito è molto più veloce eseguire l'inspector in modalità CLI rispetto al browser.
> Leggi di più sull'inspector [qui](https://github.com/modelcontextprotocol/inspector).

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Anche se ci impegniamo per l'accuratezza, si prega di essere consapevoli che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua madre dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda la traduzione professionale umana. Non siamo responsabili per eventuali malintesi o interpretazioni errate derivanti dall'uso di questa traduzione.