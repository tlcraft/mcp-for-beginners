<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-16T15:04:42+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "fr"
}
-->
# Service de Calculatrice Basique MCP

Ce service propose des opérations de calcul basiques via le Model Context Protocol (MCP). Il est conçu comme un exemple simple pour les débutants qui souhaitent découvrir les implémentations MCP.

Pour plus d’informations, consultez [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Fonctionnalités

Ce service de calculatrice offre les capacités suivantes :

1. **Opérations arithmétiques de base** :
   - Addition de deux nombres
   - Soustraction d’un nombre par rapport à un autre
   - Multiplication de deux nombres
   - Division d’un nombre par un autre (avec vérification de la division par zéro)

## Utilisation du type `stdio`
  
## Configuration

1. **Configurer les serveurs MCP** :
   - Ouvrez votre espace de travail dans VS Code.
   - Créez un fichier `.vscode/mcp.json` dans le dossier de votre espace de travail pour configurer les serveurs MCP. Exemple de configuration :
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
	- Remplacez le chemin par celui de votre projet. Le chemin doit être absolu et non relatif au dossier de l’espace de travail. (Exemple : D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## Utilisation du Service

Le service expose les points d’API suivants via le protocole MCP :

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` avec votre nom d’utilisateur Docker Hub) :
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Une fois l’image construite, téléchargeons-la sur Docker Hub. Exécutez la commande suivante :
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Utiliser la Version Dockerisée

1. Dans le fichier `.vscode/mcp.json`, remplacez la configuration du serveur par la suivante :
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

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, et comme précédemment, vous pouvez demander au service calculatrice d’effectuer des calculs pour vous.

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforçons d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous ne saurions être tenus responsables des malentendus ou des interprétations erronées résultant de l’utilisation de cette traduction.