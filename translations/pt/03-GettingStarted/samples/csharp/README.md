<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T12:59:40+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "pt"
}
-->
# Serviço de Calculadora Básica MCP

Este serviço fornece operações básicas de calculadora através do Protocolo de Contexto de Modelo (MCP). É projetado como um exemplo simples para iniciantes que estão aprendendo sobre implementações MCP.

Para mais informações, veja [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Funcionalidades

Este serviço de calculadora oferece as seguintes capacidades:

1. **Operações Aritméticas Básicas**:
   - Adição de dois números
   - Subtração de um número de outro
   - Multiplicação de dois números
   - Divisão de um número por outro (com verificação de divisão por zero)

## Usando `stdio` Tipo

## Configuração

1. **Configurar Servidores MCP**:
   - Abra seu espaço de trabalho no VS Code.
   - Crie um arquivo `.vscode/mcp.json` na pasta do seu espaço de trabalho para configurar servidores MCP. Exemplo de configuração:
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
	- Substitua o caminho pelo caminho do seu projeto. O caminho deve ser absoluto e não relativo à pasta do espaço de trabalho. (Exemplo: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## Usando o Serviço

O serviço expõe os seguintes endpoints de API através do protocolo MCP:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` com seu nome de usuário do Docker Hub):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Após a imagem ser construída, vamos carregá-la no Docker Hub. Execute o seguinte comando:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Usar a Versão Dockerizada

1. No arquivo `.vscode/mcp.json`, substitua a configuração do servidor pela seguinte:
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
   Observando a configuração, você pode ver que o comando é `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, e assim como antes, você pode pedir ao serviço de calculadora para fazer alguns cálculos para você.

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para alcançar precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.