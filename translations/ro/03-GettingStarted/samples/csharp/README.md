<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T06:07:56+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "ro"
}
-->
# Serviciu Calculator de Bază MCP

Acest serviciu oferă operații de bază pentru calculator prin Model Context Protocol (MCP). Este conceput ca un exemplu simplu pentru începători care învață despre implementările MCP.

Pentru mai multe informații, vezi [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Funcționalități

Acest serviciu de calculator oferă următoarele capabilități:

1. **Operații aritmetice de bază**:
   - Adunarea a două numere
   - Scăderea unui număr din altul
   - Înmulțirea a două numere
   - Împărțirea unui număr la altul (cu verificare pentru împărțirea la zero)

## Utilizarea `stdio` Type

## Configurare

1. **Configurează serverele MCP**:
   - Deschide spațiul de lucru în VS Code.
   - Creează un fișier `.vscode/mcp.json` în folderul spațiului de lucru pentru a configura serverele MCP. Exemplu de configurare:

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

   - Ți se va cere să introduci rădăcina depozitului GitHub, care poate fi obținută cu comanda `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` cu numele tău de utilizator Docker Hub):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. După ce imaginea este construită, să o încărcăm pe Docker Hub. Rulează următoarea comandă:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Folosirea Versiunii Dockerizate

1. În fișierul `.vscode/mcp.json`, înlocuiește configurația serverului cu următoarea:
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
   Privind configurația, poți observa că comanda este `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, iar, la fel ca înainte, poți cere serviciului de calculator să facă niște calcule pentru tine.

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original, în limba sa nativă, trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.