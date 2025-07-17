<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:31:05+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "fr"
}
-->
# Création d’un client

Les clients sont des applications personnalisées ou des scripts qui communiquent directement avec un serveur MCP pour demander des ressources, des outils et des invites. Contrairement à l’utilisation de l’outil d’inspection, qui offre une interface graphique pour interagir avec le serveur, écrire votre propre client permet des interactions programmatiques et automatisées. Cela permet aux développeurs d’intégrer les capacités MCP dans leurs propres flux de travail, d’automatiser des tâches et de créer des solutions personnalisées adaptées à des besoins spécifiques.

## Vue d’ensemble

Cette leçon introduit le concept de clients dans l’écosystème du Model Context Protocol (MCP). Vous apprendrez à écrire votre propre client et à le connecter à un serveur MCP.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Comprendre ce qu’un client peut faire.
- Écrire votre propre client.
- Connecter et tester le client avec un serveur MCP pour s’assurer que ce dernier fonctionne comme prévu.

## Qu’implique l’écriture d’un client ?

Pour écrire un client, vous devrez faire ce qui suit :

- **Importer les bonnes bibliothèques**. Vous utiliserez la même bibliothèque qu’auparavant, mais avec des constructions différentes.
- **Instancier un client**. Cela implique de créer une instance de client et de la connecter au mode de transport choisi.
- **Décider quelles ressources lister**. Votre serveur MCP propose des ressources, des outils et des invites, vous devez décider lesquels lister.
- **Intégrer le client à une application hôte**. Une fois que vous connaissez les capacités du serveur, vous devez intégrer cela à votre application hôte afin que lorsqu’un utilisateur saisit une invite ou une autre commande, la fonctionnalité correspondante du serveur soit invoquée.

Maintenant que nous avons une idée générale de ce que nous allons faire, examinons un exemple.

### Exemple de client

Jetons un œil à cet exemple de client :

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";

const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);

// List prompts
const prompts = await client.listPrompts();

// Get a prompt
const prompt = await client.getPrompt({
  name: "example-prompt",
  arguments: {
    arg1: "value"
  }
});

// List resources
const resources = await client.listResources();

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});
```

Dans le code précédent, nous avons :

- Importé les bibliothèques
- Créé une instance de client et connecté celle-ci en utilisant stdio comme transport.
- Listé les invites, ressources et outils, puis les avons tous invoqués.

Voilà, un client capable de communiquer avec un serveur MCP.

Prenons le temps dans la section exercice suivante de décomposer chaque extrait de code et d’expliquer ce qui se passe.

## Exercice : Écrire un client

Comme indiqué plus haut, prenons le temps d’expliquer le code, et n’hésitez pas à coder en même temps si vous le souhaitez.

### -1- Importer les bibliothèques

Importons les bibliothèques dont nous avons besoin, nous aurons besoin de références à un client et à notre protocole de transport choisi, stdio. stdio est un protocole destiné aux applications locales. SSE est un autre protocole de transport que nous présenterons dans les chapitres suivants, mais c’est votre autre option. Pour l’instant, continuons avec stdio.

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

### Java

Pour Java, vous allez créer un client qui se connecte au serveur MCP de l’exercice précédent. En utilisant la même structure de projet Java Spring Boot que dans [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), créez une nouvelle classe Java appelée `SDKClient` dans le dossier `src/main/java/com/microsoft/mcp/sample/client/` et ajoutez les imports suivants :

```java
import java.util.Map;
import org.springframework.web.reactive.function.client.WebClient;
import io.modelcontextprotocol.client.McpClient;
import io.modelcontextprotocol.client.transport.WebFluxSseClientTransport;
import io.modelcontextprotocol.spec.McpClientTransport;
import io.modelcontextprotocol.spec.McpSchema.CallToolRequest;
import io.modelcontextprotocol.spec.McpSchema.CallToolResult;
import io.modelcontextprotocol.spec.McpSchema.ListToolsResult;
```

Passons à l’instanciation.

### -2- Instanciation du client et du transport

Nous devons créer une instance du transport et celle de notre client :

### TypeScript

```typescript
const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);
```

Dans le code précédent, nous avons :

- Créé une instance de transport stdio. Notez comment il spécifie la commande et les arguments pour localiser et démarrer le serveur, car c’est quelque chose que nous devons faire lors de la création du client.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Instancié un client en lui donnant un nom et une version.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Connecté le client au transport choisi.

    ```typescript
    await client.connect(transport);
    ```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client

# Create server parameters for stdio connection
server_params = StdioServerParameters(
    command="mcp",  # Executable
    args=["run", "server.py"],  # Optional command line arguments
    env=None,  # Optional environment variables
)

async def run():
    async with stdio_client(server_params) as (read, write):
        async with ClientSession(
            read, write
        ) as session:
            # Initialize the connection
            await session.initialize()

          

if __name__ == "__main__":
    import asyncio

    asyncio.run(run())
```

Dans le code précédent, nous avons :

- Importé les bibliothèques nécessaires
- Instancié un objet de paramètres serveur que nous utiliserons pour exécuter le serveur afin de pouvoir nous y connecter avec notre client.
- Défini une méthode `run` qui appelle à son tour `stdio_client` qui démarre une session client.
- Créé un point d’entrée où nous fournissons la méthode `run` à `asyncio.run`.

### .NET

```dotnet
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();



var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "dotnet",
    Arguments = ["run", "--project", "path/to/file.csproj"],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

Dans le code précédent, nous avons :

- Importé les bibliothèques nécessaires.
- Créé un transport stdio et un client `mcpClient`. Ce dernier sera utilisé pour lister et invoquer les fonctionnalités sur le serveur MCP.

Notez que dans "Arguments", vous pouvez pointer soit vers le fichier *.csproj* soit vers l’exécutable.

### Java

```java
public class SDKClient {
    
    public static void main(String[] args) {
        var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
        new SDKClient(transport).run();
    }
    
    private final McpClientTransport transport;

    public SDKClient(McpClientTransport transport) {
        this.transport = transport;
    }

    public void run() {
        var client = McpClient.sync(this.transport).build();
        client.initialize();
        
        // Your client logic goes here
    }
}
```

Dans le code précédent, nous avons :

- Créé une méthode main qui configure un transport SSE pointant vers `http://localhost:8080` où notre serveur MCP sera en fonctionnement.
- Créé une classe client qui prend le transport en paramètre du constructeur.
- Dans la méthode `run`, nous créons un client MCP synchrone en utilisant le transport et initialisons la connexion.
- Utilisé le transport SSE (Server-Sent Events) adapté à la communication HTTP avec les serveurs MCP Java Spring Boot.

### -3- Lister les fonctionnalités du serveur

Maintenant, nous avons un client qui peut se connecter si le programme est lancé. Cependant, il ne liste pas encore ses fonctionnalités, faisons-le maintenant :

### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

### Python

```python
# List available resources
resources = await session.list_resources()
print("LISTING RESOURCES")
for resource in resources:
    print("Resource: ", resource)

# List available tools
tools = await session.list_tools()
print("LISTING TOOLS")
for tool in tools.tools:
    print("Tool: ", tool.name)
```

Ici, nous listons les ressources disponibles, `list_resources()` et les outils, `list_tools` et les affichons.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Ci-dessus un exemple de comment lister les outils sur le serveur. Pour chaque outil, nous affichons ensuite son nom.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

Dans le code précédent, nous avons :

- Appelé `listTools()` pour obtenir tous les outils disponibles du serveur MCP.
- Utilisé `ping()` pour vérifier que la connexion au serveur fonctionne.
- Le `ListToolsResult` contient des informations sur tous les outils, y compris leurs noms, descriptions et schémas d’entrée.

Parfait, nous avons maintenant récupéré toutes les fonctionnalités. La question est : quand les utilisons-nous ? Ce client est assez simple, dans le sens où nous devons explicitement appeler les fonctionnalités quand nous en avons besoin. Dans le chapitre suivant, nous créerons un client plus avancé qui aura accès à son propre grand modèle de langage, LLM. Pour l’instant, voyons comment invoquer les fonctionnalités sur le serveur :

### -4- Invoquer les fonctionnalités

Pour invoquer les fonctionnalités, nous devons nous assurer de spécifier les bons arguments et, dans certains cas, le nom de ce que nous essayons d’invoquer.

### TypeScript

```typescript

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});

// call prompt
const promptResult = await client.getPrompt({
    name: "review-code",
    arguments: {
        code: "console.log(\"Hello world\")"
    }
})
```

Dans le code précédent, nous avons :

- Lu une ressource, nous appelons la ressource en utilisant `readResource()` en spécifiant `uri`. Voici à quoi cela ressemble très probablement côté serveur :

    ```typescript
    server.resource(
        "readFile",
        new ResourceTemplate("file://{name}", { list: undefined }),
        async (uri, { name }) => ({
          contents: [{
            uri: uri.href,
            text: `Hello, ${name}!`
          }]
        })
    );
    ```

    Notre valeur `uri` `file://example.txt` correspond à `file://{name}` sur le serveur. `example.txt` sera mappé à `name`.

- Appelé un outil, nous le faisons en spécifiant son `name` et ses `arguments` comme suit :

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Obtenu une invite, pour obtenir une invite, vous appelez `getPrompt()` avec `name` et `arguments`. Le code serveur ressemble à ceci :

    ```typescript
    server.prompt(
        "review-code",
        { code: z.string() },
        ({ code }) => ({
            messages: [{
            role: "user",
            content: {
                type: "text",
                text: `Please review this code:\n\n${code}`
            }
            }]
        })
    );
    ```

    et votre code client résultant ressemble donc à ceci pour correspondre à ce qui est déclaré sur le serveur :

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

Dans le code précédent, nous avons :

- Appelé une ressource appelée `greeting` en utilisant `read_resource`.
- Invoqué un outil appelé `add` en utilisant `call_tool`.

### .NET

1. Ajoutons du code pour appeler un outil :

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Pour afficher le résultat, voici un code pour gérer cela :

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

### Java

```java
// Call various calculator tools
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
System.out.println("Add Result = " + resultAdd);

CallToolResult resultSubtract = client.callTool(new CallToolRequest("subtract", Map.of("a", 10.0, "b", 4.0)));
System.out.println("Subtract Result = " + resultSubtract);

CallToolResult resultMultiply = client.callTool(new CallToolRequest("multiply", Map.of("a", 6.0, "b", 7.0)));
System.out.println("Multiply Result = " + resultMultiply);

CallToolResult resultDivide = client.callTool(new CallToolRequest("divide", Map.of("a", 20.0, "b", 4.0)));
System.out.println("Divide Result = " + resultDivide);

CallToolResult resultHelp = client.callTool(new CallToolRequest("help", Map.of()));
System.out.println("Help = " + resultHelp);
```

Dans le code précédent, nous avons :

- Appelé plusieurs outils de calculatrice en utilisant la méthode `callTool()` avec des objets `CallToolRequest`.
- Chaque appel d’outil spécifie le nom de l’outil et une `Map` des arguments requis par cet outil.
- Les outils serveur attendent des noms de paramètres spécifiques (comme "a", "b" pour les opérations mathématiques).
- Les résultats sont retournés sous forme d’objets `CallToolResult` contenant la réponse du serveur.

### -5- Exécuter le client

Pour exécuter le client, tapez la commande suivante dans le terminal :

### TypeScript

Ajoutez l’entrée suivante dans la section "scripts" de votre *package.json* :

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Appelez le client avec la commande suivante :

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Assurez-vous d’abord que votre serveur MCP fonctionne sur `http://localhost:8080`. Ensuite, lancez le client :

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Vous pouvez aussi exécuter le projet client complet fourni dans le dossier solution `03-GettingStarted\02-client\solution\java` :

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Exercice

Dans cet exercice, vous utiliserez ce que vous avez appris pour créer un client, mais cette fois un client qui vous appartient.

Voici un serveur que vous pouvez utiliser et que vous devez appeler via votre code client, voyez si vous pouvez ajouter plus de fonctionnalités au serveur pour le rendre plus intéressant.

### TypeScript

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});

// Add an addition tool
server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

// Add a dynamic greeting resource
server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout

async function main() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
  console.error("MCPServer started on stdin/stdout");
}

main().catch((error) => {
  console.error("Fatal error: ", error);
  process.exit(1);
});
```

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")


# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"

```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

Consultez ce projet pour voir comment [ajouter des invites et des ressources](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Consultez également ce lien pour savoir comment invoquer [invites et ressources](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Solution

Le **dossier solution** contient des implémentations complètes et prêtes à l’emploi de clients qui démontrent tous les concepts abordés dans ce tutoriel. Chaque solution inclut à la fois le code client et serveur organisés en projets séparés et autonomes.

### 📁 Structure de la solution

Le répertoire solution est organisé par langage de programmation :

```
solution/
├── typescript/          # TypeScript client with npm/Node.js setup
│   ├── package.json     # Dependencies and scripts
│   ├── tsconfig.json    # TypeScript configuration
│   └── src/             # Source code
├── java/                # Java Spring Boot client project
│   ├── pom.xml          # Maven configuration
│   ├── src/             # Java source files
│   └── mvnw            # Maven wrapper
├── python/              # Python client implementation
│   ├── client.py        # Main client code
│   ├── server.py        # Compatible server
│   └── README.md        # Python-specific instructions
├── dotnet/              # .NET client project
│   ├── dotnet.csproj    # Project configuration
│   ├── Program.cs       # Main client code
│   └── dotnet.sln       # Solution file
└── server/              # Additional .NET server implementation
    ├── Program.cs       # Server code
    └── server.csproj    # Server project file
```

### 🚀 Ce que chaque solution inclut

Chaque solution spécifique à un langage fournit :

- **Implémentation complète du client** avec toutes les fonctionnalités du tutoriel
- **Structure de projet fonctionnelle** avec dépendances et configuration appropriées
- **Scripts de build et d’exécution** pour une installation et un lancement faciles
- **README détaillé** avec instructions spécifiques au langage
- **Gestion des erreurs** et exemples de traitement des résultats

### 📖 Utilisation des solutions

1. **Naviguez vers le dossier de votre langage préféré** :
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Suivez les instructions du README** dans chaque dossier pour :
   - Installer les dépendances
   - Compiler le projet
   - Exécuter le client

3. **Exemple de sortie** que vous devriez voir :
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Pour une documentation complète et des instructions pas à pas, consultez : **[📖 Documentation de la solution](./solution/README.md)**

## 🎯 Exemples complets

Nous avons fourni des implémentations complètes et fonctionnelles de clients pour tous les langages de programmation abordés dans ce tutoriel. Ces exemples démontrent toutes les fonctionnalités décrites ci-dessus et peuvent servir de références ou de points de départ pour vos propres projets.

### Exemples complets disponibles

| Langage | Fichier | Description |
|---------|---------|-------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java) | Client Java complet utilisant le transport SSE avec gestion complète des erreurs |
| **C#** | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs) | Client C# complet utilisant le transport stdio avec démarrage automatique du serveur |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Client TypeScript complet avec support total du protocole MCP |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py) | Client Python complet utilisant les patterns async/await |

Chaque exemple complet inclut :

- ✅ **Établissement de la connexion** et gestion des erreurs
- ✅ **Découverte du serveur** (outils, ressources, invites le cas échéant)
- ✅ **Opérations de calculatrice** (addition, soustraction, multiplication, division, aide)
- ✅ **Traitement des résultats** et sortie formatée
- ✅ **Gestion complète des erreurs**
- ✅ **Code propre et documenté** avec commentaires étape par étape

### Pour commencer avec les exemples complets

1. **Choisissez votre langage préféré** dans le tableau ci-dessus
2. **Examinez le fichier d’exemple complet** pour comprendre l’implémentation complète
3. **Exécutez l’exemple** en suivant les instructions dans [`complete_examples.md`](./complete_examples.md)
4. **Modifiez et étendez** l’exemple pour votre cas d’usage spécifique

Pour une documentation détaillée sur l’exécution et la personnalisation de ces exemples, consultez : **[📖 Documentation des exemples complets](./complete_examples.md)**

### 💡 Solution vs. Exemples complets

| **Dossier Solution** | **Exemples Complets** |
|---------------------|----------------------|
| Structure complète de projet avec fichiers de build | Implémentations en fichier unique |
| Prêt à l’emploi avec dépendances | Exemples de code ciblés |
| Configuration proche de la production | Référence pédagogique |
| Outils spécifiques au langage | Comparaison inter-langages |
Les deux approches sont utiles - utilisez le **dossier solution** pour des projets complets et les **exemples complets** pour apprendre et vous référer.

## Points clés

Les points clés de ce chapitre concernant les clients sont les suivants :

- Peuvent être utilisés à la fois pour découvrir et invoquer des fonctionnalités sur le serveur.
- Peuvent démarrer un serveur en même temps qu’eux-mêmes (comme dans ce chapitre), mais les clients peuvent aussi se connecter à des serveurs déjà en fonctionnement.
- Constituent un excellent moyen de tester les capacités du serveur, en complément d’alternatives comme l’Inspector, comme décrit dans le chapitre précédent.

## Ressources supplémentaires

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Exemples

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Suite

- Suivant : [Creating a client with an LLM](../03-llm-client/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.