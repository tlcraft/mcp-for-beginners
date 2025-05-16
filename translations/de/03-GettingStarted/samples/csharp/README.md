<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-16T15:04:52+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "de"
}
-->
# Basic Calculator MCP Service

Dieser Dienst stellt grundlegende Taschenrechnerfunktionen über das Model Context Protocol (MCP) bereit. Er ist als einfaches Beispiel für Einsteiger konzipiert, die MCP-Implementierungen kennenlernen möchten.

Weitere Informationen finden Sie unter [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Funktionen

Dieser Taschenrechnerdienst bietet folgende Möglichkeiten:

1. **Grundlegende arithmetische Operationen**:
   - Addition von zwei Zahlen
   - Subtraktion einer Zahl von einer anderen
   - Multiplikation von zwei Zahlen
   - Division einer Zahl durch eine andere (mit Überprüfung auf Division durch Null)

## Verwendung von `stdio` Typ

## Konfiguration

1. **MCP-Server konfigurieren**:
   - Öffnen Sie Ihren Arbeitsbereich in VS Code.
   - Erstellen Sie eine `.vscode/mcp.json`-Datei in Ihrem Arbeitsverzeichnis, um die MCP-Server zu konfigurieren. Beispielkonfiguration:
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
	- Ersetzen Sie den Pfad durch den Pfad zu Ihrem Projekt. Der Pfad sollte absolut sein und darf nicht relativ zum Arbeitsverzeichnis angegeben werden. (Beispiel: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## Verwendung des Dienstes

Der Dienst stellt über das MCP-Protokoll folgende API-Endpunkte zur Verfügung:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` mit Ihrem Docker-Hub-Benutzernamen):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Nachdem das Image erstellt wurde, laden wir es auf Docker Hub hoch. Führen Sie folgenden Befehl aus:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Verwendung der Docker-Version

1. Ersetzen Sie in der `.vscode/mcp.json`-Datei die Serverkonfiguration durch Folgendes:
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
   Anhand der Konfiguration sehen Sie, dass der Befehl `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` lautet, und wie zuvor können Sie den Taschenrechnerdienst bitten, einige Berechnungen für Sie durchzuführen.

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.