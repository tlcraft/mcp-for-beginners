<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T06:09:09+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "sr"
}
-->
# Основна услуга калкулатора MCP

Ова услуга пружа основне операције калкулатора преко Model Context Protocol (MCP). Дизајнирана је као једноставан пример за почетнике који уче о имплементацијама MCP.

За више информација, погледајте [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Карактеристике

Ова услуга калкулатора нуди следеће могућности:

1. **Основне аритметичке операције**:
   - Сабирање два броја
   - Одузимање једног броја од другог
   - Множење два броја
   - Дељење једног броја са другим (са провером за дељење нулом)

## Коришћење `stdio` типа
  
## Конфигурација

1. **Конфигуришите MCP сервере**:
   - Отворите свој радни простор у VS Code.
   - Креирајте `.vscode/mcp.json` фајл у фасцикли вашег радног простора за конфигурацију MCP сервера. Пример конфигурације:

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

   - Бићете упитани да унесете корен GitHub репозиторијума, који можете добити из команде `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` са вашим Docker Hub корисничким именом):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Након што је слика направљена, учитајмо је на Docker Hub. Покрените следећу команду:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Коришћење Docker верзије

1. У `.vscode/mcp.json` фајлу замените конфигурацију сервера следећим:
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
   Погледом на конфигурацију, можете видети да је команда `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, и као и раније, можете тражити од услуге калкулатора да изврши неке математичке операције за вас.

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем АИ услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде прецизан, молимо вас да имате у виду да аутоматизовани преводи могу садржати грешке или нетачности. Изворни документ на његовом оригиналном језику треба сматрати ауторитетом. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било какве неспоразуме или погрешна тумачења настала употребом овог превода.