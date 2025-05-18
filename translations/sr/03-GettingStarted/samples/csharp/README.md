<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T13:03:53+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "sr"
}
-->
# Osnovna Kalkulator MCP Usluga

Ova usluga pruža osnovne operacije kalkulatora putem Model Context Protocol-a (MCP). Dizajnirana je kao jednostavan primer za početnike koji uče o MCP implementacijama.

Za više informacija, pogledajte [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Karakteristike

Ova kalkulator usluga nudi sledeće mogućnosti:

1. **Osnovne Aritmetičke Operacije**:
   - Sabiranje dva broja
   - Oduzimanje jednog broja od drugog
   - Množenje dva broja
   - Deljenje jednog broja drugim (sa proverom deljenja nulom)

## Korišćenje `stdio` Tip

## Konfiguracija

1. **Konfigurišite MCP Servere**:
   - Otvorite svoj radni prostor u VS Code-u.
   - Kreirajte `.vscode/mcp.json` datoteku u svom radnom folderu da konfigurišete MCP servere. Primer konfiguracije:
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
   - Zamenite putanju sa putanjom do vašeg projekta. Putanja treba da bude apsolutna, a ne relativna u odnosu na radni folder. (Primer: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## Korišćenje Usluge

Usluga izlaže sledeće API krajnje tačke putem MCP protokola:

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
1. Nakon što je slika izgrađena, hajde da je otpremimo na Docker Hub. Pokrenite sledeću komandu:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Koristite Verziju u Docker-u

1. U `.vscode/mcp.json` datoteci, zamenite konfiguraciju servera sa sledećom:
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
   Gledajući konfiguraciju, možete videti da je komanda `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, i kao i ranije, možete tražiti od kalkulator usluge da uradi neku matematiku za vas.

**Ограничење одговорности**:  
Овај документ је преведен користећи AI услугу превођења [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо ка тачности, молимо вас да будете свесни да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом матерњем језику треба сматрати ауторитативним извором. За критичне информације, препоручује се професионални људски превод. Нисмо одговорни за било каква погрешна схватања или погрешна тумачења која произилазе из коришћења овог превода.