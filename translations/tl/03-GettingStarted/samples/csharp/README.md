<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T06:05:11+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "tl"
}
-->
# Basic Calculator MCP Service

Ang serbisyong ito ay nagbibigay ng mga pangunahing operasyon sa calculator gamit ang Model Context Protocol (MCP). Ito ay ginawa bilang isang simpleng halimbawa para sa mga baguhan na nag-aaral tungkol sa mga implementasyon ng MCP.

Para sa karagdagang impormasyon, tingnan ang [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Mga Tampok

Ang serbisyong calculator na ito ay nag-aalok ng mga sumusunod na kakayahan:

1. **Pangunahing Operasyon sa Aritmetika**:
   - Pagdaragdag ng dalawang numero
   - Pagbabawas ng isang numero mula sa isa pa
   - Pagmumultiply ng dalawang numero
   - Paghahati ng isang numero sa isa pa (na may tsek para sa paghahati sa zero)

## Paggamit ng `stdio` Uri
  
## Konfigurasyon

1. **I-configure ang MCP Servers**:
   - Buksan ang iyong workspace sa VS Code.
   - Gumawa ng `.vscode/mcp.json` file sa iyong workspace folder para i-configure ang MCP servers. Halimbawa ng konfigurasyon:

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

   - Hihilingin sa iyo na ilagay ang root ng GitHub repository, na maaaring makuha mula sa utos, `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` gamit ang iyong Docker Hub username):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Pagkatapos mabuo ang image, i-upload natin ito sa Docker Hub. Patakbuhin ang sumusunod na utos:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Gamitin ang Dockerized na Bersyon

1. Sa `.vscode/mcp.json` file, palitan ang server configuration ng sumusunod:
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
   Sa pagtingin sa konfigurasyon, makikita mo na ang utos ay `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, at tulad ng dati, maaari mong hilingin sa calculator service na gawin ang ilang kalkulasyon para sa iyo.

**Pahayag ng Pagwawaksi**:  
Ang dokumentong ito ay isinalin gamit ang serbisyong AI na pagsasalin [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang orihinal na wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.