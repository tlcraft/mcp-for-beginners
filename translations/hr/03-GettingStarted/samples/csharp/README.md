<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T13:04:08+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "hr"
}
-->
# Osnovna Kalkulator MCP Usluga

Ova usluga pruža osnovne kalkulatorske operacije putem Model Context Protocol (MCP). Dizajnirana je kao jednostavan primjer za početnike koji uče o MCP implementacijama.

Za više informacija, pogledajte [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Značajke

Ova kalkulatorska usluga nudi sljedeće mogućnosti:

1. **Osnovne aritmetičke operacije**:
   - Zbrajanje dva broja
   - Oduzimanje jednog broja od drugog
   - Množenje dva broja
   - Dijeljenje jednog broja s drugim (uz provjeru dijeljenja s nulom)

## Korištenje `stdio` Tipa

## Konfiguracija

1. **Konfigurirajte MCP servere**:
   - Otvorite svoj radni prostor u VS Code.
   - Kreirajte `.vscode/mcp.json` datoteku u svojoj radnoj mapi za konfiguriranje MCP servera. Primjer konfiguracije:
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
   - Zamijenite putanju s putanjom do vašeg projekta. Putanja bi trebala biti apsolutna, a ne relativna prema radnoj mapi. (Primjer: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## Korištenje Usluge

Usluga izlaže sljedeće API krajnje točke putem MCP protokola:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` sa vašim Docker Hub korisničkim imenom):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Nakon što je slika izgrađena, idemo je uploadati na Docker Hub. Pokrenite sljedeću naredbu:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Korištenje Dockerizirane Verzije

1. U `.vscode/mcp.json` datoteci, zamijenite konfiguraciju servera sa sljedećom:
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
   Gledajući konfiguraciju, možete vidjeti da je naredba `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, i kao i prije, možete zatražiti od kalkulatorske usluge da obavi neke matematičke operacije za vas.

**Odricanje odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako se trudimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na njegovom izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni prijevod od strane čovjeka. Ne odgovaramo za nesporazume ili pogrešne interpretacije koje proizlaze iz korištenja ovog prijevoda.