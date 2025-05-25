<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T13:01:36+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "nl"
}
-->
# Basis Rekenmachine MCP Dienst

Deze dienst biedt basisrekenmachinefuncties via het Model Context Protocol (MCP). Het is ontworpen als een eenvoudig voorbeeld voor beginners die leren over MCP-implementaties.

Voor meer informatie, zie [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Functies

Deze rekenmachinedienst biedt de volgende mogelijkheden:

1. **Basis Rekenkundige Bewerkingen**:
   - Optellen van twee getallen
   - Aftrekken van een getal van een ander
   - Vermenigvuldigen van twee getallen
   - Delen van een getal door een ander (met controle op deling door nul)

## Gebruik van `stdio` Type
  
## Configuratie

1. **Configureer MCP Servers**:
   - Open je werkruimte in VS Code.
   - Maak een `.vscode/mcp.json` bestand in je werkruimte map om MCP servers te configureren. Voorbeeldconfiguratie:
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
   - Vervang het pad door het pad naar je project. Het pad moet absoluut zijn en niet relatief ten opzichte van de werkruimte map. (Voorbeeld: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## Gebruik van de Dienst

De dienst biedt de volgende API-eindpunten aan via het MCP-protocol:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` met je Docker Hub gebruikersnaam):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Nadat de image is gebouwd, laten we deze uploaden naar Docker Hub. Voer het volgende commando uit:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Gebruik de Gedockeriseerde Versie

1. In het `.vscode/mcp.json` bestand, vervang de serverconfiguratie door het volgende:
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
   Als je naar de configuratie kijkt, zie je dat het commando `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` is, en net zoals eerder kun je de rekenmachinedienst vragen om wat wiskunde voor je te doen.

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertaaldienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we ons inzetten voor nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in zijn oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.