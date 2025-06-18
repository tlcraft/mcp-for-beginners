<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T06:01:27+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "no"
}
-->
# Basic Calculator MCP Service

Denne tjenesten tilbyr grunnleggende kalkulatoroperasjoner gjennom Model Context Protocol (MCP). Den er laget som et enkelt eksempel for nybegynnere som lærer om MCP-implementasjoner.

For mer informasjon, se [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Funksjoner

Denne kalkulatortjenesten tilbyr følgende muligheter:

1. **Grunnleggende aritmetiske operasjoner**:
   - Addisjon av to tall
   - Subtraksjon av ett tall fra et annet
   - Multiplikasjon av to tall
   - Divisjon av ett tall med et annet (med sjekk for divisjon med null)

## Bruke `stdio` Type
  
## Konfigurasjon

1. **Konfigurer MCP-servere**:
   - Åpne arbeidsområdet ditt i VS Code.
   - Opprett en `.vscode/mcp.json` fil i arbeidsområdet ditt for å konfigurere MCP-servere. Eksempel på konfigurasjon:

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

   - Du vil bli bedt om å oppgi roten til GitHub-repositoriet, som kan hentes med kommandoen, `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` med ditt Docker Hub-brukernavn):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Etter at imaget er bygget, laster vi det opp til Docker Hub. Kjør følgende kommando:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Bruk den Dockeriserte Versjonen

1. I `.vscode/mcp.json` filen, erstatt serverkonfigurasjonen med følgende:
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
   Når du ser på konfigurasjonen, kan du se at kommandoen er `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, og akkurat som før kan du be kalkulatortjenesten om å gjøre noen beregninger for deg.

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på dets opprinnelige språk skal betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår som følge av bruk av denne oversettelsen.