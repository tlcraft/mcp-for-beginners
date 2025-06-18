<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:49:08+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "ur"
}
-->
# بنیادی کیلکولیٹر MCP سروس

یہ سروس ماڈل کانٹیکسٹ پروٹوکول (MCP) کے ذریعے بنیادی کیلکولیٹر آپریشنز فراہم کرتی ہے۔ یہ MCP کی تنفیذات سیکھنے والے ابتدائی افراد کے لیے ایک سادہ مثال کے طور پر ڈیزائن کی گئی ہے۔

مزید معلومات کے لیے دیکھیں [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## خصوصیات

یہ کیلکولیٹر سروس درج ذیل صلاحیتیں فراہم کرتی ہے:

1. **بنیادی حسابی عملیات**:
   - دو نمبروں کا جمع کرنا
   - ایک نمبر کو دوسرے سے منفی کرنا
   - دو نمبروں کا ضرب دینا
   - ایک نمبر کو دوسرے سے تقسیم کرنا (صفر سے تقسیم کی جانچ کے ساتھ)

## `stdio` قسم کا استعمال

## ترتیب

1. **MCP سرورز کو ترتیب دیں**:
   - VS Code میں اپنا ورک اسپیس کھولیں۔
   - اپنے ورک اسپیس فولڈر میں ایک `.vscode/mcp.json` فائل بنائیں تاکہ MCP سرورز کی ترتیب کی جا سکے۔ مثال کے طور پر ترتیب:

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

   - آپ سے GitHub ریپوزٹری روٹ درج کرنے کو کہا جائے گا، جسے کمانڈ `git rev-parse --show-toplevel` سے حاصل کیا جا سکتا ہے۔ اپنے Docker Hub یوزرنیم کے ساتھ ``.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` میں شامل کریں:
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. امیج بن جانے کے بعد، اسے Docker Hub پر اپلوڈ کریں۔ درج ذیل کمانڈ چلائیں:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Dockerized ورژن کا استعمال

1. `.vscode/mcp.json` فائل میں سرور کی ترتیب کو درج ذیل سے بدل دیں:
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
   ترتیب کو دیکھتے ہوئے، آپ دیکھ سکتے ہیں کہ کمانڈ `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` ہے، اور پہلے کی طرح آپ کیلکولیٹر سروس سے کچھ حساب کروا سکتے ہیں۔

**دستخطی دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار تراجم میں غلطیاں یا عدم صحت ہو سکتی ہے۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ تجویز کیا جاتا ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تعبیر کی ذمہ داری ہم پر عائد نہیں ہوتی۔