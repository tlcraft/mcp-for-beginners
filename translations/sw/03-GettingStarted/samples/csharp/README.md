<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T13:02:47+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "sw"
}
-->
# Huduma ya Kipimajedwali ya Msingi ya MCP

Huduma hii inatoa shughuli za kimsingi za kipimajedwali kupitia Model Context Protocol (MCP). Imeundwa kama mfano rahisi kwa wanaoanza kujifunza kuhusu utekelezaji wa MCP.

Kwa maelezo zaidi, angalia [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Vipengele

Huduma hii ya kipimajedwali inatoa uwezo ufuatao:

1. **Shughuli za Kimsingi za Hisabati**:
   - Kuongeza namba mbili
   - Kutoa namba moja kutoka kwa nyingine
   - Kuzidisha namba mbili
   - Kugawanya namba moja kwa nyingine (kwa ukaguzi wa mgawanyiko kwa sifuri)

## Kutumia `stdio` Aina

## Usanidi

1. **Sanidi Seva za MCP**:
   - Fungua eneo la kazi lako katika VS Code.
   - Unda faili ya `.vscode/mcp.json` kwenye folda ya eneo la kazi lako ili kusanidi seva za MCP. Mfano wa usanidi:
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
   - Badilisha njia na njia ya mradi wako. Njia inapaswa kuwa ya moja kwa moja na siyo ya kuhusiana na folda ya eneo la kazi. (Mfano: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## Kutumia Huduma

Huduma inatoa njia za API zifuatazo kupitia itifaki ya MCP:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` na jina lako la mtumiaji wa Docker Hub):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Baada ya picha kujengwa, hebu ipakie kwenye Docker Hub. Endesha amri ifuatayo:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Tumia Toleo la Docker

1. Katika faili ya `.vscode/mcp.json`, badilisha usanidi wa seva kwa yafuatayo:
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
   Ukiangalia usanidi, utaona kuwa amri ni `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, na kama hapo awali unaweza kuuliza huduma ya kipimajedwali kufanya hesabu fulani kwako.

**Kanusho**: 
Hati hii imetafsiriwa kwa kutumia huduma ya kutafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya awali katika lugha yake asili inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatuwajibiki kwa kutoelewana au kutafsiri vibaya kunakotokana na matumizi ya tafsiri hii.