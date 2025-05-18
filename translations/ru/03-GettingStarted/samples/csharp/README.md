<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T12:57:18+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "ru"
}
-->
# Базовый сервис калькулятора MCP

Этот сервис предоставляет основные операции калькулятора через Протокол Контекста Модели (MCP). Он разработан как простой пример для начинающих, изучающих реализации MCP.

Для получения дополнительной информации см. [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Особенности

Этот сервис калькулятора предлагает следующие возможности:

1. **Основные арифметические операции**:
   - Сложение двух чисел
   - Вычитание одного числа из другого
   - Умножение двух чисел
   - Деление одного числа на другое (с проверкой деления на ноль)

## Использование `stdio` Типа
  
## Конфигурация

1. **Настройка MCP серверов**:
   - Откройте вашу рабочую область в VS Code.
   - Создайте файл `.vscode/mcp.json` в папке вашей рабочей области для настройки MCP серверов. Пример конфигурации:
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
   - Замените путь на путь к вашему проекту. Путь должен быть абсолютным, а не относительным к папке рабочей области. (Пример: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## Использование сервиса

Сервис предоставляет следующие API конечные точки через протокол MCP:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` с вашим именем пользователя Docker Hub:
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. После сборки образа, давайте загрузим его на Docker Hub. Выполните следующую команду:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Использование версии в Docker

1. В файле `.vscode/mcp.json` замените конфигурацию сервера на следующую:
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
   Посмотрев на конфигурацию, вы можете увидеть, что команда `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, и как и прежде, вы можете попросить сервис калькулятора выполнить некоторые математические операции для вас.

**Отказ от ответственности**:
Этот документ был переведен с использованием AI-сервиса перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Хотя мы стремимся к точности, пожалуйста, учитывайте, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на его родном языке следует считать авторитетным источником. Для критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные интерпретации, возникшие в результате использования этого перевода.