<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T06:00:24+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "sv"
}
-->
# Basic Calculator MCP Service

Denna tjänst tillhandahåller grundläggande kalkylatoroperationer via Model Context Protocol (MCP). Den är utformad som ett enkelt exempel för nybörjare som vill lära sig om MCP-implementationer.

För mer information, se [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Funktioner

Denna kalkylatortjänst erbjuder följande möjligheter:

1. **Grundläggande aritmetiska operationer**:
   - Addition av två tal
   - Subtraktion av ett tal från ett annat
   - Multiplikation av två tal
   - Division av ett tal med ett annat (med kontroll för division med noll)

## Använda `stdio` Typ
  
## Konfiguration

1. **Konfigurera MCP-servrar**:
   - Öppna din arbetsyta i VS Code.
   - Skapa en `.vscode/mcp.json`-fil i din arbetsmapp för att konfigurera MCP-servrar. Exempel på konfiguration:

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

   - Du kommer att bli ombedd att ange roten för GitHub-repositoriet, vilket kan hämtas från kommandot `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` med ditt Docker Hub-användarnamn):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. När bilden är byggd, låt oss ladda upp den till Docker Hub. Kör följande kommando:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Använd den Dockeriserade versionen

1. I `.vscode/mcp.json`-filen, ersätt serverkonfigurationen med följande:
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
   Om du tittar på konfigurationen ser du att kommandot är `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, och precis som tidigare kan du be kalkylatortjänsten göra lite matte åt dig.

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, var vänlig observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål ska betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.