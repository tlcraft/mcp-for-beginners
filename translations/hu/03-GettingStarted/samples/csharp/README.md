<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T06:06:16+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "hu"
}
-->
# Alap Számológép MCP Szolgáltatás

Ez a szolgáltatás alapvető számológép műveleteket biztosít a Model Context Protocol (MCP) segítségével. Egyszerű példaként készült kezdők számára, akik az MCP implementációkat tanulják.

További információért lásd a [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) oldalt.

## Jellemzők

Ez a számológép szolgáltatás a következő funkciókat kínálja:

1. **Alapvető matematikai műveletek**:
   - Két szám összeadása
   - Egy szám kivonása egy másikból
   - Két szám szorzása
   - Egy szám osztása egy másikkal (nullával való osztás ellenőrzéssel)

## `stdio` típus használata

## Konfiguráció

1. **MCP szerverek beállítása**:
   - Nyisd meg a munkaterületedet VS Code-ban.
   - Hozz létre egy `.vscode/mcp.json` fájlt a munkaterületed mappájában az MCP szerverek konfigurálásához. Példa konfiguráció:

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

   - A GitHub tároló gyökérkönyvtárát meg kell adnod, amely lekérdezhető a `git rev-parse --show-toplevel` parancsból`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` helyére a Docker Hub felhasználónevedet írd be):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ```
2. Miután az image elkészült, töltsük fel a Docker Hubra. Futtasd a következő parancsot:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## A Dockerizált verzió használata

1. A `.vscode/mcp.json` fájlban cseréld le a szerver konfigurációt az alábbiakra:
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
   A konfigurációt nézve látható, hogy a parancs `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, és ahogy korábban, kérheted a számológép szolgáltatást, hogy végezzen el néhány számítást.

**Felelősségkizárás**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum anyanyelvén tekintendő hivatalos forrásnak. Kritikus információk esetén profi, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.