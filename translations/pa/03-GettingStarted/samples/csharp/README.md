<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T12:59:28+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "pa"
}
-->
# ਬੇਸਿਕ ਕੈਲਕੂਲੇਟਰ MCP ਸੇਵਾ

ਇਹ ਸੇਵਾ ਮਾਡਲ ਕਾਂਟੈਕਸਟ ਪ੍ਰੋਟੋਕੋਲ (MCP) ਰਾਹੀਂ ਬੇਸਿਕ ਕੈਲਕੂਲੇਟਰ ਓਪਰੇਸ਼ਨ ਪ੍ਰਦਾਨ ਕਰਦੀ ਹੈ। ਇਹ MCP ਅਮਲਾਂ ਬਾਰੇ ਸਿੱਖਣ ਵਾਲੇ ਸ਼ੁਰੂਆਤੀ ਵਿਦਿਆਰਥੀਆਂ ਲਈ ਇੱਕ ਸਧਾਰਨ ਉਦਾਹਰਨ ਵਜੋਂ ਤਿਆਰ ਕੀਤਾ ਗਿਆ ਹੈ।

ਹੋਰ ਜਾਣਕਾਰੀ ਲਈ, [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) ਦੇਖੋ

## ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ

ਇਹ ਕੈਲਕੂਲੇਟਰ ਸੇਵਾ ਹੇਠਾਂ ਦਿੱਤੀਆਂ ਸਮਰੱਥਾਵਾਂ ਪ੍ਰਦਾਨ ਕਰਦੀ ਹੈ:

1. **ਮੂਲ ਗਣਿਤਕ ਕਾਰਜ**:
   - ਦੋ ਨੰਬਰਾਂ ਦੀ ਜੋੜ
   - ਇੱਕ ਨੰਬਰ ਨੂੰ ਦੂਜੇ ਤੋਂ ਘਟਾਉਣਾ
   - ਦੋ ਨੰਬਰਾਂ ਦਾ ਗੁਣਾ
   - ਇੱਕ ਨੰਬਰ ਨੂੰ ਦੂਜੇ ਨਾਲ ਵੰਡਣਾ (ਜ਼ੀਰੋ ਡਿਵੀਜ਼ਨ ਚੈਕ ਨਾਲ)

## `stdio` ਕਿਸਮ ਦੀ ਵਰਤੋਂ

## ਸੰਰਚਨਾ

1. **MCP ਸਰਵਰਾਂ ਨੂੰ ਸੰਰਚਿਤ ਕਰੋ**:
   - ਆਪਣੇ ਵਰਕਸਪੇਸ ਨੂੰ VS ਕੋਡ ਵਿੱਚ ਖੋਲ੍ਹੋ।
   - ਆਪਣੇ ਵਰਕਸਪੇਸ ਫੋਲਡਰ ਵਿੱਚ ਇੱਕ `.vscode/mcp.json` ਫਾਈਲ ਬਣਾਓ MCP ਸਰਵਰਾਂ ਨੂੰ ਸੰਰਚਿਤ ਕਰਨ ਲਈ। ਉਦਾਹਰਨ ਸੰਰਚਨਾ:
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
	- ਮਾਰਗ ਨੂੰ ਆਪਣੇ ਪ੍ਰਾਜੈਕਟ ਦੇ ਮਾਰਗ ਨਾਲ ਬਦਲੋ। ਮਾਰਗ ਸਧਾਰਨ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ ਅਤੇ ਵਰਕਸਪੇਸ ਫੋਲਡਰ ਨਾਲ ਸਬੰਧਤ ਨਹੀਂ। (ਉਦਾਹਰਨ: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## ਸੇਵਾ ਦੀ ਵਰਤੋਂ

ਸੇਵਾ MCP ਪ੍ਰੋਟੋਕੋਲ ਰਾਹੀਂ ਹੇਠਾਂ ਦਿੱਤੇ API ਐਂਡਪੋਇੰਟਸ ਨੂੰ ਉਜਾਗਰ ਕਰਦੀ ਹੈ:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` ਆਪਣੇ ਡੋਕਰ ਹਬ ਯੂਜ਼ਰਨੇਮ ਨਾਲ):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. ਇਮੇਜ ਬਣਨ ਦੇ ਬਾਅਦ, ਚਲੋ ਇਸਨੂੰ ਡੋਕਰ ਹਬ 'ਤੇ ਅੱਪਲੋਡ ਕਰੀਏ। ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾਓ:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## ਡੋਕਰਾਈਜ਼ਡ ਵਰਜਨ ਦੀ ਵਰਤੋਂ

1. `.vscode/mcp.json` ਫਾਈਲ ਵਿੱਚ, ਸਰਵਰ ਸੰਰਚਨਾ ਨੂੰ ਹੇਠਾਂ ਦਿੱਤੇ ਨਾਲ ਬਦਲੋ:
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
   ਸੰਰਚਨਾ ਨੂੰ ਦੇਖਦੇ ਹੋਏ, ਤੁਸੀਂ ਦੇਖ ਸਕਦੇ ਹੋ ਕਿ ਕਮਾਂਡ `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` ਹੈ, ਅਤੇ ਜਿਵੇਂ ਕਿ ਪਹਿਲਾਂ ਵੀ ਤੁਸੀਂ ਕੈਲਕੂਲੇਟਰ ਸੇਵਾ ਨੂੰ ਤੁਹਾਡੇ ਲਈ ਕੁਝ ਗਣਿਤ ਕਰਨ ਲਈ ਪੁੱਛ ਸਕਦੇ ਹੋ।

**ਅਸਵੀਕਤੀ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਹਾਲਾਂਕਿ ਅਸੀਂ ਸਹੀ ਹੋਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸੁਣੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਇਸਦੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਮੂਲ ਦਸਤਾਵੇਜ਼ ਨੂੰ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੇ ਪ੍ਰਯੋਗ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੇ ਕਿਸੇ ਵੀ ਗਲਤ ਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।