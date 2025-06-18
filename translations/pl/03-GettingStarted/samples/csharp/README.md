<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:57:54+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "pl"
}
-->
# Podstawowa usługa kalkulatora MCP

Ta usługa udostępnia podstawowe operacje kalkulatora za pomocą Model Context Protocol (MCP). Została zaprojektowana jako prosty przykład dla początkujących, którzy uczą się implementacji MCP.

Więcej informacji znajdziesz w [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Funkcje

Ta usługa kalkulatora oferuje następujące możliwości:

1. **Podstawowe operacje arytmetyczne**:
   - Dodawanie dwóch liczb
   - Odejmowanie jednej liczby od drugiej
   - Mnożenie dwóch liczb
   - Dzielenie jednej liczby przez drugą (z kontrolą dzielenia przez zero)

## Korzystanie z typu `stdio`
  
## Konfiguracja

1. **Konfiguracja serwerów MCP**:
   - Otwórz swoje środowisko pracy w VS Code.
   - Utwórz plik `.vscode/mcp.json` w folderze swojego workspace, aby skonfigurować serwery MCP. Przykładowa konfiguracja:

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

   - Zostaniesz poproszony o podanie katalogu głównego repozytorium GitHub, który można uzyskać za pomocą polecenia `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` wraz z Twoją nazwą użytkownika Docker Hub:
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Po zbudowaniu obrazu, prześlij go do Docker Hub. Uruchom następujące polecenie:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Użycie wersji w kontenerze Docker

1. W pliku `.vscode/mcp.json` zamień konfigurację serwera na następującą:
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
   Patrząc na konfigurację, widzisz, że polecenie to `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, i podobnie jak wcześniej możesz poprosić usługę kalkulatora o wykonanie obliczeń.

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dążymy do dokładności, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło wiążące. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.