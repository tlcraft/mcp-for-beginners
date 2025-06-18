<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:46:14+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "es"
}
-->
# Servicio Básico de Calculadora MCP

Este servicio ofrece operaciones básicas de calculadora a través del Model Context Protocol (MCP). Está diseñado como un ejemplo sencillo para principiantes que están aprendiendo sobre implementaciones MCP.

Para más información, consulta [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Características

Este servicio de calculadora ofrece las siguientes funcionalidades:

1. **Operaciones Aritméticas Básicas**:
   - Suma de dos números
   - Resta de un número a otro
   - Multiplicación de dos números
   - División de un número por otro (con verificación de división por cero)

## Uso del tipo `stdio`
  
## Configuración

1. **Configurar Servidores MCP**:
   - Abre tu espacio de trabajo en VS Code.
   - Crea un archivo `.vscode/mcp.json` en la carpeta de tu espacio de trabajo para configurar los servidores MCP. Ejemplo de configuración:

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

   - Se te pedirá ingresar la raíz del repositorio de GitHub, que puedes obtener con el comando `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` con tu nombre de usuario de Docker Hub):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Después de construir la imagen, subámosla a Docker Hub. Ejecuta el siguiente comando:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Usar la Versión Dockerizada

1. En el archivo `.vscode/mcp.json`, reemplaza la configuración del servidor por la siguiente:
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
   Observando la configuración, puedes ver que el comando es `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, y al igual que antes, puedes pedirle al servicio de calculadora que haga algunos cálculos por ti.

**Aviso Legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de ningún malentendido o interpretación errónea derivada del uso de esta traducción.