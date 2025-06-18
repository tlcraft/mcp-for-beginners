<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:47:49+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "ar"
}
-->
# خدمة الآلة الحاسبة الأساسية MCP

تقدم هذه الخدمة عمليات حسابية أساسية من خلال بروتوكول سياق النموذج (MCP). تم تصميمها كمثال بسيط للمبتدئين الذين يتعلمون عن تطبيقات MCP.

لمزيد من المعلومات، راجع [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## الميزات

تقدم خدمة الآلة الحاسبة هذه القدرات التالية:

1. **العمليات الحسابية الأساسية**:
   - جمع رقمين
   - طرح رقم من رقم آخر
   - ضرب رقمين
   - قسمة رقم على آخر (مع التحقق من القسمة على صفر)

## استخدام `stdio` النوع
  
## التهيئة

1. **تهيئة خوادم MCP**:
   - افتح مساحة العمل الخاصة بك في VS Code.
   - أنشئ ملف `.vscode/mcp.json` في مجلد مساحة العمل لتهيئة خوادم MCP. مثال على التهيئة:

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

   - سيُطلب منك إدخال جذر مستودع GitHub، والذي يمكن الحصول عليه من الأمر، `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` مع اسم مستخدم Docker Hub الخاص بك):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. بعد بناء الصورة، لنقم برفعها إلى Docker Hub. نفذ الأمر التالي:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## استخدام النسخة المحوسبة عبر Docker

1. في ملف `.vscode/mcp.json`، استبدل تهيئة الخادم بالتالي:
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
   بالنظر إلى التهيئة، يمكنك رؤية أن الأمر هو `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`، وكما في السابق يمكنك طلب خدمة الآلة الحاسبة لإجراء بعض العمليات الحسابية لك.

**إخلاء مسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق. للمعلومات الهامة، يُنصح بالاستعانة بالترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.