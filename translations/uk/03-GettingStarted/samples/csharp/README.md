<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-06-17T16:36:29+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "uk"
}
-->
# Основний сервіс калькулятора MCP

Цей сервіс надає базові операції калькулятора через протокол Model Context Protocol (MCP). Він створений як простий приклад для початківців, які вивчають реалізації MCP.

Для отримання додаткової інформації дивіться [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Можливості

Цей сервіс калькулятора пропонує такі функції:

1. **Базові арифметичні операції**:
   - Додавання двох чисел
   - Віднімання одного числа від іншого
   - Множення двох чисел
   - Ділення одного числа на інше (з перевіркою ділення на нуль)

## Використання `stdio` типу

## Налаштування

1. **Налаштування MCP серверів**:
   - Відкрийте вашу робочу область у VS Code.
   - Створіть файл `.vscode/mcp.json` у папці робочої області для налаштування MCP серверів. Приклад конфігурації:
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
	- Замініть шлях на шлях до вашого проекту. Шлях повинен бути абсолютним, а не відносним до папки робочої області. (Приклад: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## Використання сервісу

Сервіс надає такі API ендпоінти через протокол MCP:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` з вашим ім’ям користувача Docker Hub):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Після створення образу, завантажте його на Docker Hub. Виконайте таку команду:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Використання докеризованої версії

1. У файлі `.vscode/mcp.json` замініть конфігурацію сервера на таку:
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
   Якщо подивитися на конфігурацію, ви побачите, що команда `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, і так само, як раніше, ви можете попросити сервіс калькулятора виконати для вас деякі обчислення.

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.