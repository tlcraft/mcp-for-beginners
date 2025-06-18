<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:55:31+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "pa"
}
-->
# ਬੇਸਿਕ ਕੈਲਕੁਲੇਟਰ MCP ਸਰਵਿਸ

ਇਹ ਸਰਵਿਸ ਮਾਡਲ ਕਾਂਟੈਕਸਟ ਪ੍ਰੋਟੋਕੋਲ (MCP) ਰਾਹੀਂ ਬੇਸਿਕ ਕੈਲਕੁਲੇਟਰ ਓਪਰੇਸ਼ਨ ਪ੍ਰਦਾਨ ਕਰਦੀ ਹੈ। ਇਹ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਬਾਰੇ ਸਿੱਖਣ ਵਾਲੇ ਸ਼ੁਰੂਆਤੀ ਲਈ ਇੱਕ ਸਧਾਰਣ ਉਦਾਹਰਨ ਵਜੋਂ ਬਣਾਈ ਗਈ ਹੈ।

ਵਧੇਰੇ ਜਾਣਕਾਰੀ ਲਈ ਵੇਖੋ [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## ਫੀਚਰ

ਇਹ ਕੈਲਕੁਲੇਟਰ ਸਰਵਿਸ ਹੇਠ ਲਿਖੀਆਂ ਸਮਰੱਥਾਵਾਂ ਦਿੰਦੀ ਹੈ:

1. **ਬੁਨਿਆਦੀ ਅੰਕਗਣਿਤੀ ਓਪਰੇਸ਼ਨ**:
   - ਦੋ ਨੰਬਰਾਂ ਦਾ ਜੋੜ
   - ਇੱਕ ਨੰਬਰ ਵਿੱਚੋਂ ਦੂਸਰੇ ਦਾ ਘਟਾਅ
   - ਦੋ ਨੰਬਰਾਂ ਦੀ ਗੁਣਾ
   - ਇੱਕ ਨੰਬਰ ਨੂੰ ਦੂਸਰੇ ਨਾਲ ਭਾਗ ਦੇਣਾ (ਜ਼ੀਰੋ ਡਿਵੀਜ਼ਨ ਚੈੱਕ ਸਮੇਤ)

## `stdio` ਕਿਸਮ ਦੀ ਵਰਤੋਂ

## ਸੰਰਚਨਾ

1. **MCP ਸਰਵਰਾਂ ਦੀ ਸੰਰਚਨਾ ਕਰੋ**:
   - VS Code ਵਿੱਚ ਆਪਣਾ ਵਰਕਸਪੇਸ ਖੋਲ੍ਹੋ।
   - MCP ਸਰਵਰਾਂ ਨੂੰ ਸੰਰਚਿਤ ਕਰਨ ਲਈ ਆਪਣੇ ਵਰਕਸਪੇਸ ਫੋਲਡਰ ਵਿੱਚ `.vscode/mcp.json` ਫਾਇਲ ਬਣਾਓ। ਉਦਾਹਰਨ ਸੰਰਚਨਾ:

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

   - ਤੁਹਾਨੂੰ GitHub ਰਿਪੋਜ਼ਟਰੀ ਰੂਟ ਦਰਜ ਕਰਨ ਲਈ ਕਿਹਾ ਜਾਵੇਗਾ, ਜੋ ਕਮਾਂਡ `git rev-parse --show-toplevel` ਰਾਹੀਂ ਪ੍ਰਾਪਤ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ। (ਆਪਣੇ Docker Hub ਯੂਜ਼ਰਨੇਮ ਨਾਲ ``.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` ਵਰਤੋਂ):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. ਇਮੇਜ ਬਣ ਜਾਣ ਤੋਂ ਬਾਅਦ, ਆਓ ਇਸ ਨੂੰ Docker Hub 'ਤੇ ਅਪਲੋਡ ਕਰੀਏ। ਹੇਠਾਂ ਦਿੱਤੀ ਕਮਾਂਡ ਚਲਾਓ:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## ਡੋਕਰਾਈਜ਼ਡ ਵਰਜਨ ਦੀ ਵਰਤੋਂ

1. `.vscode/mcp.json` ਫਾਇਲ ਵਿੱਚ ਸਰਵਰ ਸੰਰਚਨਾ ਨੂੰ ਹੇਠ ਲਿਖੇ ਨਾਲ ਬਦਲੋ:
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
   ਸੰਰਚਨਾ ਵੇਖ ਕੇ, ਤੁਸੀਂ ਦੇਖ ਸਕਦੇ ਹੋ ਕਿ ਕਮਾਂਡ ਹੈ `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, ਅਤੇ ਪਹਿਲਾਂ ਵਾਂਗ ਹੀ ਤੁਸੀਂ ਕੈਲਕੁਲੇਟਰ ਸਰਵਿਸ ਨੂੰ ਕੁਝ ਗਣਿਤ ਕਰਨ ਲਈ ਕਹਿ ਸਕਦੇ ਹੋ।

**ਅਸਵੀਕਾਰੋਕਤ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਆਟੋਮੈਟਿਕ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਹੀਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੀ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੇ ਇਸਤੇਮਾਲ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।