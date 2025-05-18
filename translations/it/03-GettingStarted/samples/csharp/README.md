<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T12:59:58+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "it"
}
-->
# Servizio Calcolatrice Base MCP

Questo servizio fornisce operazioni di calcolatrice base tramite il Model Context Protocol (MCP). È progettato come un semplice esempio per i principianti che imparano a implementare MCP.

Per maggiori informazioni, vedi [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Funzionalità

Questo servizio di calcolatrice offre le seguenti capacità:

1. **Operazioni Aritmetiche di Base**:
   - Addizione di due numeri
   - Sottrazione di un numero da un altro
   - Moltiplicazione di due numeri
   - Divisione di un numero per un altro (con controllo di divisione per zero)

## Utilizzo di `stdio` Type

## Configurazione

1. **Configura i Server MCP**:
   - Apri il tuo spazio di lavoro in VS Code.
   - Crea un file `.vscode/mcp.json` nella cartella del tuo spazio di lavoro per configurare i server MCP. Esempio di configurazione:
     ```json
     {
       "servers": {
         "MyCalculator": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
                "run",
                "--project",
                "D:\\source\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj"
            ],
           "env": {}
         }
       }
     }
     ```
	- Sostituisci il percorso con il percorso del tuo progetto. Il percorso dovrebbe essere assoluto e non relativo alla cartella dello spazio di lavoro. (Esempio: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## Utilizzo del Servizio

Il servizio espone i seguenti endpoint API tramite il protocollo MCP:

- `add(a, b)`: Add two numbers together
- `subtract(a, b)`: Subtract the second number from the first
- `multiply(a, b)`: Multiply two numbers
- `divide(a, b)`: Divide the first number by the second (with zero check)
- isPrime(n): Check if a number is prime

## Test with Github Copilot Chat in VS Code

1. Try making a request to the service using the MCP protocol. For example, you can ask:
   - "Add 5 and 3"
   - "Subtract 10 from 4"
   - "Multiply 6 and 7"
   - "Divide 8 by 2"
   - "Does 37854 prime?"
   - "What are the 3 prime numbers before after 4242?"
2. To make sure it's using the tools add #MyCalculator to the prompt. For example:
   - "Add 5 and 3 #MyCalculator"
   - "Subtract 10 from 4 #MyCalculator


## Containerized Version

The previous soultion is great when you have the .NET SDK installed, and all the dependencies are in place. However, if you would like to share the solution or run it in a different environment, you can use the containerized version.

1. Start Docker and make sure it's running.
1. From a terminal, navigate in the folder `03-GettingStarted\samples\csharp\src` 
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` con il tuo nome utente Docker Hub):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Dopo che l'immagine è stata costruita, carichiamola su Docker Hub. Esegui il seguente comando:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Utilizza la Versione Dockerizzata

1. Nel file `.vscode/mcp.json`, sostituisci la configurazione del server con la seguente:
   ```json
    "mcp-calc": {
      "command": "docker",
      "args": [
        "run",
        "--rm",
        "-i",
        "<YOUR-DOCKER-USERNAME>/mcp-calc"
      ],
      "envFile": "",
      "env": {}
    }
   ```
   Guardando la configurazione, puoi vedere che il comando è `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, e proprio come prima puoi chiedere al servizio calcolatrice di fare qualche calcolo per te.

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per l'accuratezza, si prega di essere consapevoli che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda la traduzione professionale umana. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.