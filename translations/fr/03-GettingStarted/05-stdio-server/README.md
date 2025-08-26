<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:15:32+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "fr"
}
-->
# Serveur MCP avec transport stdio

> **⚠️ Mise à jour importante** : À partir de la spécification MCP du 18/06/2025, le transport autonome SSE (Server-Sent Events) a été **déprécié** et remplacé par le transport "HTTP Streamable". La spécification actuelle du MCP définit deux mécanismes de transport principaux :
> 1. **stdio** - Entrée/sortie standard (recommandé pour les serveurs locaux)
> 2. **HTTP Streamable** - Pour les serveurs distants pouvant utiliser SSE en interne
>
> Cette leçon a été mise à jour pour se concentrer sur le **transport stdio**, qui est l'approche recommandée pour la plupart des implémentations de serveurs MCP.

Le transport stdio permet aux serveurs MCP de communiquer avec les clients via les flux d'entrée et de sortie standard. C'est le mécanisme de transport le plus couramment utilisé et recommandé dans la spécification actuelle du MCP, offrant une méthode simple et efficace pour construire des serveurs MCP facilement intégrables à diverses applications clientes.

## Vue d'ensemble

Cette leçon explique comment construire et utiliser des serveurs MCP en utilisant le transport stdio.

## Objectifs d'apprentissage

À la fin de cette leçon, vous serez capable de :

- Construire un serveur MCP en utilisant le transport stdio.
- Déboguer un serveur MCP avec l'Inspector.
- Utiliser un serveur MCP avec Visual Studio Code.
- Comprendre les mécanismes de transport MCP actuels et pourquoi le stdio est recommandé.

## Transport stdio - Comment ça fonctionne

Le transport stdio est l'un des deux types de transport pris en charge dans la spécification actuelle du MCP (18/06/2025). Voici comment il fonctionne :

- **Communication simple** : Le serveur lit les messages JSON-RPC depuis l'entrée standard (`stdin`) et envoie des messages à la sortie standard (`stdout`).
- **Basé sur les processus** : Le client lance le serveur MCP en tant que sous-processus.
- **Format des messages** : Les messages sont des requêtes, notifications ou réponses JSON-RPC individuelles, délimitées par des sauts de ligne.
- **Journalisation** : Le serveur PEUT écrire des chaînes UTF-8 sur la sortie d'erreur standard (`stderr`) à des fins de journalisation.

### Exigences clés :
- Les messages DOIVENT être délimités par des sauts de ligne et NE DOIVENT PAS contenir de sauts de ligne intégrés.
- Le serveur NE DOIT PAS écrire quoi que ce soit sur `stdout` qui ne soit pas un message MCP valide.
- Le client NE DOIT PAS écrire quoi que ce soit sur `stdin` du serveur qui ne soit pas un message MCP valide.

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

Dans le code précédent :

- Nous importons la classe `Server` et `StdioServerTransport` depuis le SDK MCP.
- Nous créons une instance de serveur avec une configuration et des capacités de base.

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

Dans le code précédent, nous :

- Créons une instance de serveur en utilisant le SDK MCP.
- Définissons des outils à l'aide de décorateurs.
- Utilisons le gestionnaire de contexte stdio_server pour gérer le transport.

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

La principale différence par rapport au SSE est que les serveurs stdio :

- N'ont pas besoin de configuration de serveur web ou de points de terminaison HTTP.
- Sont lancés en tant que sous-processus par le client.
- Communiquent via les flux stdin/stdout.
- Sont plus simples à implémenter et à déboguer.

## Exercice : Créer un serveur stdio

Pour créer notre serveur, nous devons garder deux choses à l'esprit :

- Nous devons utiliser un serveur web pour exposer des points de terminaison pour la connexion et les messages.

## Atelier : Créer un serveur MCP stdio simple

Dans cet atelier, nous allons créer un serveur MCP simple en utilisant le transport stdio recommandé. Ce serveur exposera des outils que les clients pourront appeler en utilisant le protocole Model Context.

### Prérequis

- Python 3.8 ou version ultérieure
- SDK MCP Python : `pip install mcp`
- Compréhension de base de la programmation asynchrone

Commençons par créer notre premier serveur MCP stdio :

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## Différences clés par rapport à l'approche SSE dépréciée

**Transport stdio (Standard actuel) :**
- Modèle simple de sous-processus - le client lance le serveur comme processus enfant.
- Communication via stdin/stdout en utilisant des messages JSON-RPC.
- Pas besoin de configuration de serveur HTTP.
- Meilleures performances et sécurité.
- Débogage et développement plus faciles.

**Transport SSE (Déprécié depuis MCP 18/06/2025) :**
- Nécessitait un serveur HTTP avec des points de terminaison SSE.
- Configuration plus complexe avec une infrastructure de serveur web.
- Considérations supplémentaires de sécurité pour les points de terminaison HTTP.
- Maintenant remplacé par HTTP Streamable pour les scénarios basés sur le web.

### Créer un serveur avec le transport stdio

Pour créer notre serveur stdio, nous devons :

1. **Importer les bibliothèques nécessaires** - Nous avons besoin des composants du serveur MCP et du transport stdio.
2. **Créer une instance de serveur** - Définir le serveur avec ses capacités.
3. **Définir des outils** - Ajouter les fonctionnalités que nous voulons exposer.
4. **Configurer le transport** - Configurer la communication stdio.
5. **Exécuter le serveur** - Démarrer le serveur et gérer les messages.

Construisons cela étape par étape :

### Étape 1 : Créer un serveur stdio basique

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### Étape 2 : Ajouter plus d'outils

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### Étape 3 : Exécuter le serveur

Enregistrez le code sous `server.py` et exécutez-le depuis la ligne de commande :

```bash
python server.py
```

Le serveur démarrera et attendra des entrées depuis stdin. Il communique en utilisant des messages JSON-RPC via le transport stdio.

### Étape 4 : Tester avec l'Inspector

Vous pouvez tester votre serveur en utilisant l'Inspector MCP :

1. Installez l'Inspector : `npx @modelcontextprotocol/inspector`
2. Exécutez l'Inspector et pointez-le vers votre serveur.
3. Testez les outils que vous avez créés.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

## Debugging your stdio server

### Using the MCP Inspector

The MCP Inspector is a valuable tool for debugging and testing MCP servers. Here's how to use it with your stdio server:

1. **Install the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Run the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

3. **Test your server**: The Inspector provides a web interface where you can:
   - View server capabilities
   - Test tools with different parameters
   - Monitor JSON-RPC messages
   - Debug connection issues

### Using VS Code

You can also debug your MCP server directly in VS Code:

1. Create a launch configuration in `.vscode/launch.json`:
   ```json
   {
     "version": "0.2.0",
     "configurations": [
       {
         "name": "Déboguer le serveur MCP",
         "type": "python",
         "request": "launch",
         "program": "server.py",
         "console": "integratedTerminal"
       }
     ]
   }
   ```

2. Set breakpoints in your server code
3. Run the debugger and test with the Inspector

### Common debugging tips

- Use `stderr` for logging - never write to `stdout` as it's reserved for MCP messages
- Ensure all JSON-RPC messages are newline-delimited
- Test with simple tools first before adding complex functionality
- Use the Inspector to verify message formats

## Consuming your stdio server in VS Code

Once you've built your MCP stdio server, you can integrate it with VS Code to use it with Claude or other MCP-compatible clients.

### Configuration

1. **Create an MCP configuration file** at `%APPDATA%\Claude\claude_desktop_config.json` (Windows) or `~/Library/Application Support/Claude/claude_desktop_config.json` (Mac):

   ```json
   {
     "mcpServers": {
       "example-stdio-server": {
         "command": "python",
         "args": ["path/to/your/server.py"]
       }
     }
   }
   ```

2. **Restart Claude**: Close and reopen Claude to load the new server configuration.

3. **Test the connection**: Start a conversation with Claude and try using your server's tools:
   - "Can you greet me using the greeting tool?"
   - "Calculate the sum of 15 and 27"
   - "What's the server info?"

### TypeScript stdio server example

Here's a complete TypeScript example for reference:

```typescript
#!/usr/bin/env node
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { CallToolRequestSchema, ListToolsRequestSchema } from "@modelcontextprotocol/sdk/types.js";

const server = new Server(
  {
    name: "example-stdio-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);

// Ajouter des outils
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Obtenir un message de bienvenue personnalisé",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Nom de la personne à saluer",
            },
          },
          required: ["name"],
        },
      },
    ],
  };
});

server.setRequestHandler(CallToolRequestSchema, async (request) => {
  if (request.params.name === "get_greeting") {
    return {
      content: [
        {
          type: "text",
          text: `Bonjour, ${request.params.arguments?.name} ! Bienvenue sur le serveur MCP stdio.`,
        },
      ],
    };
  } else {
    throw new Error(`Outil inconnu : ${request.params.name}`);
  }
});

async function runServer() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
}

runServer().catch(console.error);
```

### .NET stdio server example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

var app = builder.Build();
await app.RunAsync();

public class Tools
{
    [Description("Obtenir un message de bienvenue personnalisé")]
    public string GetGreeting(string name)
    {
        return $"Bonjour, {name} ! Bienvenue sur le serveur MCP stdio.";
    }

    [Description("Calculer la somme de deux nombres")]
    public int CalculateSum(int a, int b)
    {
        return a + b;
    }
}
```

## Summary

In this updated lesson, you learned how to:

- Build MCP servers using the current **stdio transport** (recommended approach)
- Understand why SSE transport was deprecated in favor of stdio and Streamable HTTP
- Create tools that can be called by MCP clients
- Debug your server using the MCP Inspector
- Integrate your stdio server with VS Code and Claude

The stdio transport provides a simpler, more secure, and more performant way to build MCP servers compared to the deprecated SSE approach. It's the recommended transport for most MCP server implementations as of the 2025-06-18 specification.
```

### .NET

1. Créons d'abord quelques outils. Pour cela, nous allons créer un fichier *Tools.cs* avec le contenu suivant :

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

## Exercise: Testing your stdio server

Now that you've built your stdio server, let's test it to make sure it works correctly.

### Prerequisites

1. Ensure you have the MCP Inspector installed:
   ```bash
   npm install -g @modelcontextprotocol/inspector
   ```

2. Your server code should be saved (e.g., as `server.py`)

### Testing with the Inspector

1. **Start the Inspector with your server**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

2. **Ouvrir l'interface web** : L'Inspector ouvrira une fenêtre de navigateur affichant les capacités de votre serveur.

3. **Tester les outils** : 
   - Essayez l'outil `get_greeting` avec différents noms.
   - Testez l'outil `calculate_sum` avec divers nombres.
   - Appelez l'outil `get_server_info` pour voir les métadonnées du serveur.

4. **Surveiller la communication** : L'Inspector montre les messages JSON-RPC échangés entre le client et le serveur.

### Ce que vous devriez voir

Lorsque votre serveur démarre correctement, vous devriez voir :
- Les capacités du serveur listées dans l'Inspector.
- Les outils disponibles pour les tests.
- Des échanges de messages JSON-RPC réussis.
- Les réponses des outils affichées dans l'interface.

### Problèmes courants et solutions

**Le serveur ne démarre pas :**
- Vérifiez que toutes les dépendances sont installées : `pip install mcp`.
- Vérifiez la syntaxe et l'indentation Python.
- Recherchez les messages d'erreur dans la console.

**Les outils n'apparaissent pas :**
- Assurez-vous que les décorateurs `@server.tool()` sont présents.
- Vérifiez que les fonctions des outils sont définies avant `main()`.
- Vérifiez que le serveur est correctement configuré.

**Problèmes de connexion :**
- Assurez-vous que le serveur utilise correctement le transport stdio.
- Vérifiez qu'aucun autre processus n'interfère.
- Vérifiez la syntaxe de la commande Inspector.

## Devoir

Essayez d'ajouter plus de fonctionnalités à votre serveur. Consultez [cette page](https://api.chucknorris.io/) pour, par exemple, ajouter un outil qui appelle une API. Vous décidez de l'apparence du serveur. Amusez-vous :)

## Solution

[Solution](./solution/README.md) Voici une solution possible avec du code fonctionnel.

## Points clés

Les points clés de ce chapitre sont les suivants :

- Le transport stdio est le mécanisme recommandé pour les serveurs MCP locaux.
- Le transport stdio permet une communication fluide entre les serveurs MCP et les clients en utilisant les flux d'entrée et de sortie standard.
- Vous pouvez utiliser l'Inspector et Visual Studio Code pour consommer directement les serveurs stdio, ce qui facilite le débogage et l'intégration.

## Exemples 

- [Calculatrice Java](../samples/java/calculator/README.md)
- [Calculatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculatrice JavaScript](../samples/javascript/README.md)
- [Calculatrice TypeScript](../samples/typescript/README.md)
- [Calculatrice Python](../../../../03-GettingStarted/samples/python) 

## Ressources supplémentaires

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Et ensuite

## Prochaines étapes

Maintenant que vous avez appris à construire des serveurs MCP avec le transport stdio, vous pouvez explorer des sujets plus avancés :

- **Suivant** : [Streaming HTTP avec MCP (HTTP Streamable)](../06-http-streaming/README.md) - Découvrez l'autre mécanisme de transport pris en charge pour les serveurs distants.
- **Avancé** : [Meilleures pratiques de sécurité MCP](../../02-Security/README.md) - Implémentez la sécurité dans vos serveurs MCP.
- **Production** : [Stratégies de déploiement](../09-deployment/README.md) - Déployez vos serveurs pour une utilisation en production.

## Ressources supplémentaires

- [Spécification MCP 18/06/2025](https://spec.modelcontextprotocol.io/specification/) - Spécification officielle.
- [Documentation SDK MCP](https://github.com/modelcontextprotocol/sdk) - Références SDK pour tous les langages.
- [Exemples communautaires](../../06-CommunityContributions/README.md) - Plus d'exemples de serveurs de la communauté.

---

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatisées peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant autorité. Pour des informations critiques, il est recommandé de recourir à une traduction professionnelle effectuée par un humain. Nous déclinons toute responsabilité en cas de malentendus ou d'interprétations erronées résultant de l'utilisation de cette traduction.