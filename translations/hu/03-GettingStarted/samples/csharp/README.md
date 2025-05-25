<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T13:02:57+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "hu"
}
-->
# Alapvető Kalkulátor MCP Szolgáltatás

Ez a szolgáltatás alapvető kalkulátorműveleteket kínál a Model Context Protocol (MCP) segítségével. Egyszerű példaként készült kezdők számára, akik az MCP implementációkról tanulnak.

További információkért lásd: [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Funkciók

Ez a kalkulátor szolgáltatás a következő képességeket kínálja:

1. **Alapvető Aritmetikai Műveletek**:
   - Két szám összeadása
   - Egy szám kivonása egy másikból
   - Két szám szorzása
   - Egy szám osztása egy másikkal (nullával való osztás ellenőrzéssel)

## `stdio` Típus Használata

## Konfiguráció

1. **MCP Szerverek Konfigurálása**:
   - Nyissa meg a munkaterületét a VS Code-ban.
   - Hozzon létre egy `.vscode/mcp.json` fájlt a munkaterület mappájában MCP szerverek konfigurálásához. Példa konfiguráció:
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
   - Cserélje ki az útvonalat a projekt útvonalával. Az útvonalnak abszolútnak kell lennie, és nem lehet relatív a munkaterület mappájához. (Példa: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## A Szolgáltatás Használata

A szolgáltatás a következő API végpontokat teszi elérhetővé az MCP protokollon keresztül:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` a Docker Hub felhasználónevével:
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Miután az image elkészült, töltsük fel a Docker Hub-ra. Futtassa a következő parancsot:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## A Dockerizált Verzió Használata

1. A `.vscode/mcp.json` fájlban cserélje le a szerver konfigurációt a következővel:
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

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, és ugyanúgy, mint korábban, kérheti a kalkulátor szolgáltatást, hogy végezzen néhány matematikai műveletet önnek.

**Felelősség kizárása**:  
Ezt a dokumentumot AI fordítási szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordították le. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelven tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális emberi fordítás. Nem vállalunk felelősséget semmilyen félreértésért vagy félremagyarázásért, amely a fordítás használatából eredhet.