<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:48:20+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "fa"
}
-->
# سرویس ماشین‌حساب پایه MCP

این سرویس عملیات پایه ماشین‌حساب را از طریق پروتکل مدل کانتکست (MCP) ارائه می‌دهد. این سرویس به عنوان یک مثال ساده برای مبتدیانی که می‌خواهند با پیاده‌سازی‌های MCP آشنا شوند، طراحی شده است.

برای اطلاعات بیشتر، به [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) مراجعه کنید.

## ویژگی‌ها

این سرویس ماشین‌حساب امکانات زیر را فراهم می‌کند:

1. **عملیات حسابی پایه**:
   - جمع دو عدد
   - تفریق یک عدد از عدد دیگر
   - ضرب دو عدد
   - تقسیم یک عدد بر عدد دیگر (با بررسی تقسیم بر صفر)

## استفاده از `stdio` نوع

## پیکربندی

1. **پیکربندی سرورهای MCP**:
   - فضای کاری خود را در VS Code باز کنید.
   - یک فایل `.vscode/mcp.json` در پوشه فضای کاری خود ایجاد کنید تا سرورهای MCP را پیکربندی کنید. نمونه پیکربندی:

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

   - از شما خواسته می‌شود تا ریشه مخزن GitHub را وارد کنید، که می‌توانید با دستور `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` به همراه نام کاربری Docker Hub خود به دست آورید:
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. پس از ساخته شدن تصویر، آن را در Docker Hub آپلود کنیم. دستور زیر را اجرا کنید:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## استفاده از نسخه داکری

1. در فایل `.vscode/mcp.json`، پیکربندی سرور را با موارد زیر جایگزین کنید:
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
   با نگاه به پیکربندی، می‌بینید که دستور `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` است، و درست مثل قبل می‌توانید از سرویس ماشین‌حساب بخواهید که محاسباتی برای شما انجام دهد.

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل خطاها یا نواقصی باشند. سند اصلی به زبان مادری خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا برداشت نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.