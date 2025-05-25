<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T12:57:56+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "ur"
}
-->
# بنیادی کیلکولیٹر MCP سروس

یہ سروس ماڈل کانٹیکسٹ پروٹوکول (MCP) کے ذریعے بنیادی کیلکولیٹر آپریشنز فراہم کرتی ہے۔ یہ ابتدائی افراد کے لیے ایک سادہ مثال کے طور پر تیار کی گئی ہے جو MCP کے نفاذ کے بارے میں سیکھ رہے ہیں۔

مزید معلومات کے لیے دیکھیں [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## خصوصیات

یہ کیلکولیٹر سروس درج ذیل صلاحیتیں فراہم کرتی ہے:

1. **بنیادی حسابی آپریشنز**:
   - دو نمبروں کا جمع
   - ایک نمبر کو دوسرے نمبر سے منفی کرنا
   - دو نمبروں کی ضرب
   - ایک نمبر کو دوسرے نمبر سے تقسیم کرنا (صفر تقسیم کی جانچ کے ساتھ)

## `stdio` قسم کا استعمال

## ترتیب

1. **MCP سرورز کو ترتیب دیں**:
   - اپنے ورک اسپیس کو VS کوڈ میں کھولیں۔
   - اپنے ورک اسپیس فولڈر میں ایک `.vscode/mcp.json` فائل بنائیں تاکہ MCP سرورز کو ترتیب دیا جا سکے۔ مثال ترتیب:
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
	- راستے کو اپنے پروجیکٹ کے راستے سے تبدیل کریں۔ راستہ مکمل ہونا چاہیے اور ورک اسپیس فولڈر سے نسبتاً نہیں ہونا چاہیے۔ (مثال: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## سروس کا استعمال

سروس MCP پروٹوکول کے ذریعے درج ذیل API اینڈپوائنٹس کو ظاہر کرتی ہے:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` اپنے Docker Hub یوزر نیم کے ساتھ تبدیل کریں):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. جب امیج بن جائے، تو اسے Docker Hub پر اپلوڈ کریں۔ درج ذیل کمانڈ چلائیں:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Dockerized ورژن کا استعمال

1. `.vscode/mcp.json` فائل میں، سرور کی ترتیب کو درج ذیل کے ساتھ تبدیل کریں:
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

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` ہے، اور جیسے پہلے آپ کیلکولیٹر سروس سے کچھ حساب کرنے کو کہہ سکتے ہیں۔

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ ہم درستگی کے لیے کوشش کرتے ہیں، لیکن براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا بے ضابطگیاں ہو سکتی ہیں۔ اصل دستاویز کو اس کی اصل زبان میں مستند ذریعہ سمجھا جانا چاہیے۔ اہم معلومات کے لیے، پیشہ ورانہ انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمہ کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے لیے ہم ذمہ دار نہیں ہیں۔