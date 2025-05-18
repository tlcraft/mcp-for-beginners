<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T13:03:42+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "bg"
}
-->
# Основна MCP услуга за калкулатор

Тази услуга предоставя основни операции на калкулатор чрез Model Context Protocol (MCP). Тя е проектирана като прост пример за начинаещи, които учат за реализации на MCP.

За повече информация, вижте [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Характеристики

Тази калкулаторна услуга предлага следните възможности:

1. **Основни аритметични операции**:
   - Събиране на две числа
   - Изваждане на едно число от друго
   - Умножение на две числа
   - Деление на едно число на друго (с проверка за деление на нула)

## Използване на `stdio` Тип

## Конфигурация

1. **Конфигуриране на MCP сървъри**:
   - Отворете вашето работно пространство във VS Code.
   - Създайте `.vscode/mcp.json` файл в папката на вашето работно пространство, за да конфигурирате MCP сървъри. Примерна конфигурация:
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
   - Заменете пътя с пътя към вашия проект. Пътят трябва да бъде абсолютен и не относителен спрямо папката на работното пространство. (Пример: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## Използване на услугата

Услугата предоставя следните API крайни точки чрез MCP протокола:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` с вашето потребителско име в Docker Hub:
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. След като изображението е създадено, нека го качим в Docker Hub. Изпълнете следната команда:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Използване на версията с Docker

1. В `.vscode/mcp.json` файла заменете конфигурацията на сървъра със следното:
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
   Гледайки конфигурацията, можете да видите, че командата е `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, и точно както преди можете да поискате калкулаторната услуга да направи някои изчисления за вас.

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI услуга за превод [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматичните преводи може да съдържат грешки или неточности. Оригиналният документ на родния му език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Не носим отговорност за недоразумения или неправилни интерпретации, произтичащи от използването на този превод.