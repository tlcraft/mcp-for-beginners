<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:45:40+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "fr"
}
-->
# Service Calculatrice Basique MCP

Ce service fournit des opérations de calcul basiques via le Model Context Protocol (MCP). Il est conçu comme un exemple simple pour les débutants qui découvrent les implémentations MCP.

Pour plus d’informations, consultez [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Fonctionnalités

Ce service calculatrice offre les capacités suivantes :

1. **Opérations arithmétiques de base** :
   - Addition de deux nombres
   - Soustraction d’un nombre par rapport à un autre
   - Multiplication de deux nombres
   - Division d’un nombre par un autre (avec vérification de la division par zéro)

## Utilisation de `stdio` Type

## Configuration

1. **Configurer les serveurs MCP** :
   - Ouvrez votre espace de travail dans VS Code.
   - Créez un fichier `.vscode/mcp.json` dans votre dossier de travail pour configurer les serveurs MCP. Exemple de configuration :

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

   - Il vous sera demandé d’entrer la racine du dépôt GitHub, que vous pouvez obtenir avec la commande `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` en remplaçant par votre nom d’utilisateur Docker Hub :
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Une fois l’image construite, téléchargeons-la sur Docker Hub. Exécutez la commande suivante :
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Utiliser la version Dockerisée

1. Dans le fichier `.vscode/mcp.json`, remplacez la configuration du serveur par ce qui suit :
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
   En regardant la configuration, vous pouvez voir que la commande est `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, et comme précédemment, vous pouvez demander au service calculatrice de faire des calculs pour vous.

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, il est recommandé de recourir à une traduction professionnelle réalisée par un humain. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.