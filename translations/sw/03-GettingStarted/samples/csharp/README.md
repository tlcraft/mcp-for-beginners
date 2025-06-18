<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T06:05:45+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "sw"
}
-->
# Huduma ya Kalkuleta Msingi ya MCP

Huduma hii hutoa shughuli za msingi za kalkuleta kupitia Model Context Protocol (MCP). Imetengenezwa kama mfano rahisi kwa wanaoanza kujifunza kuhusu utekelezaji wa MCP.

Kwa maelezo zaidi, angalia [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Sifa

Huduma hii ya kalkuleta inatoa uwezo ufuatao:

1. **Shughuli za Msingi za Hisabati**:
   - Kuongeza nambari mbili
   - Kutoa nambari moja kutoka kwa nyingine
   - Kuzidisha nambari mbili
   - Kugawanya nambari moja kwa nyingine (ikiwa na ukaguzi wa kugawanya kwa sifuri)

## Kutumia Aina ya `stdio`
  
## Usanidi

1. **Sanidi Seva za MCP**:
   - Fungua eneo lako la kazi (workspace) katika VS Code.
   - Tengeneza faili la `.vscode/mcp.json` katika folda ya eneo lako la kazi ili kusanidi seva za MCP. Mfano wa usanidi:

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

   - Utaulizwa kuingiza mzizi wa hifadhidata ya GitHub, ambayo inaweza kupatikana kwa amri, `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` pamoja na jina lako la mtumiaji wa Docker Hub):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Baada ya picha (image) kujengwa, tushawishi kuipeleka kwenye Docker Hub. Endesha amri ifuatayo:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Tumia Toleo la Docker

1. Katika faili la `.vscode/mcp.json`, badilisha usanidi wa seva kwa ifuatayo:
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
   Ukiangalia usanidi, utaona kwamba amri ni `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, na kama ilivyokuwa awali unaweza kuomba huduma ya kalkuleta kufanya hesabu kwako.

**Tangazo la Kukataa**:  
Hati hii imetafsiriwa kwa kutumia huduma ya utafsiri wa AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya awali katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu na ya binadamu inapendekezwa. Hatuna wajibu kwa maelewano mabaya au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.