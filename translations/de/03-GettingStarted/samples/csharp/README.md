<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:46:44+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "de"
}
-->
# Basisrechner MCP Dienst

Dieser Dienst bietet grundlegende Rechenoperationen über das Model Context Protocol (MCP) an. Er ist als einfaches Beispiel für Einsteiger gedacht, die MCP-Implementierungen kennenlernen möchten.

Weitere Informationen finden Sie unter [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Funktionen

Dieser Rechnerdienst bietet folgende Möglichkeiten:

1. **Grundlegende arithmetische Operationen**:
   - Addition von zwei Zahlen
   - Subtraktion einer Zahl von einer anderen
   - Multiplikation von zwei Zahlen
   - Division einer Zahl durch eine andere (mit Überprüfung auf Division durch Null)

## Verwendung von `stdio` Typ

## Konfiguration

1. **MCP-Server konfigurieren**:
   - Öffnen Sie Ihren Arbeitsbereich in VS Code.
   - Erstellen Sie eine `.vscode/mcp.json` Datei in Ihrem Arbeitsbereichsordner, um MCP-Server zu konfigurieren. Beispielkonfiguration:

     ```jsonc
     {
       "inputs": [
         {
           "type": "promptString",
           "id": "repository-root",
           "description": "The absolute path to the repository root"
         }
       ],
       "servers": {
         "calculator-mcp-dotnet": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
             "run",
             "--project",
             "${input:repository-root}/03-GettingStarted/samples/csharp/src/calculator.csproj"
           ]
         }
       }
     }
     ```

   - Sie werden aufgefordert, das Root-Verzeichnis des GitHub-Repositories einzugeben, welches Sie mit dem Befehl `git rev-parse --show-toplevel`.

## Using the Service

The service exposes the following API endpoints through the MCP protocol:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` mit Ihrem Docker-Hub-Benutzernamen abrufen können:
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ```  
1. Nachdem das Image gebaut wurde, laden wir es auf Docker Hub hoch. Führen Sie folgenden Befehl aus:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Verwendung der Docker-Version

1. Ersetzen Sie in der `.vscode/mcp.json` Datei die Serverkonfiguration durch Folgendes:
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
   Wenn Sie sich die Konfiguration ansehen, sehen Sie, dass der Befehl `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` lautet, und genau wie zuvor können Sie den Rechnerdienst bitten, einige Berechnungen für Sie durchzuführen.

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Nutzung dieser Übersetzung entstehen.