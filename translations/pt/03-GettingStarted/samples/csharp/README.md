<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:56:13+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "pt"
}
-->
# Serviço Básico de Calculadora MCP

Este serviço oferece operações básicas de calculadora através do Model Context Protocol (MCP). Foi concebido como um exemplo simples para iniciantes que estão a aprender sobre implementações MCP.

Para mais informações, consulte [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Funcionalidades

Este serviço de calculadora disponibiliza as seguintes capacidades:

1. **Operações Aritméticas Básicas**:
   - Adição de dois números
   - Subtração de um número por outro
   - Multiplicação de dois números
   - Divisão de um número por outro (com verificação de divisão por zero)

## Utilização do `stdio` Type
  
## Configuração

1. **Configurar Servidores MCP**:
   - Abra o seu espaço de trabalho no VS Code.
   - Crie um ficheiro `.vscode/mcp.json` na pasta do seu espaço de trabalho para configurar os servidores MCP. Exemplo de configuração:

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

   - Será solicitado que insira a raiz do repositório GitHub, que pode ser obtida com o comando `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` com o seu nome de utilizador do Docker Hub):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Depois de a imagem estar construída, vamos carregá-la para o Docker Hub. Execute o seguinte comando:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Usar a Versão Dockerizada

1. No ficheiro `.vscode/mcp.json`, substitua a configuração do servidor pela seguinte:
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
   Observando a configuração, pode ver que o comando é `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, e tal como antes, pode pedir ao serviço de calculadora para fazer alguns cálculos por si.

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.