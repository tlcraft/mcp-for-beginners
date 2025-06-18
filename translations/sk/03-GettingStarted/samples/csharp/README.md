<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T06:07:23+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "sk"
}
-->
# Základná kalkulačka MCP služba

Táto služba poskytuje základné kalkulačné operácie prostredníctvom Model Context Protocol (MCP). Je navrhnutá ako jednoduchý príklad pre začiatočníkov, ktorí sa učia o implementáciách MCP.

Pre viac informácií pozrite [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Funkcie

Táto kalkulačná služba ponúka nasledujúce možnosti:

1. **Základné aritmetické operácie**:
   - Sčítanie dvoch čísel
   - Odčítanie jedného čísla od druhého
   - Násobenie dvoch čísel
   - Delenie jedného čísla druhým (s kontrolou delenia nulou)

## Použitie `stdio` typu

## Konfigurácia

1. **Nastavenie MCP serverov**:
   - Otvorte svoj pracovný priestor vo VS Code.
   - Vytvorte súbor `.vscode/mcp.json` vo vašom pracovnom priečinku na konfiguráciu MCP serverov. Príklad konfigurácie:

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

   - Bude vás vyzvaný na zadanie koreňového adresára GitHub repozitára, ktorý môžete získať príkazom `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` s vaším používateľským menom na Docker Hub):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Po zostavení image ho nahrajme na Docker Hub. Spustite nasledujúci príkaz:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Použitie Docker verzie

1. V súbore `.vscode/mcp.json` nahraďte konfiguráciu servera nasledujúcim:
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
   Pri pohľade na konfiguráciu vidíte, že príkaz je `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, a rovnako ako predtým môžete požiadať kalkulačnú službu, aby vám vykonala nejaké výpočty.

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.