<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-16T21:28:13+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "fr"
}
-->
# Serveur SSE

SSE (Server Sent Events) est une norme pour le streaming serveur-client, permettant aux serveurs d’envoyer des mises à jour en temps réel aux clients via HTTP. C’est particulièrement utile pour des applications nécessitant des mises à jour en direct, comme les applications de chat, les notifications ou les flux de données en temps réel. De plus, votre serveur peut être utilisé par plusieurs clients simultanément puisqu’il tourne sur un serveur, par exemple dans le cloud.

## Vue d’ensemble

Cette leçon explique comment construire et consommer des serveurs SSE.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Construire un serveur SSE.
- Déboguer un serveur SSE avec l’Inspector.
- Consommer un serveur SSE avec Visual Studio Code.

## SSE, comment ça fonctionne

SSE est l’un des deux types de transport supportés. Vous avez déjà vu le premier, stdio, utilisé dans les leçons précédentes. La différence est la suivante :

- SSE nécessite de gérer deux choses : la connexion et les messages.
- Comme ce serveur peut être hébergé n’importe où, cela doit se refléter dans votre manière de travailler avec des outils comme l’Inspector et Visual Studio Code. Cela signifie qu’au lieu d’indiquer comment démarrer le serveur, vous indiquez plutôt le point d’accès (endpoint) où la connexion peut être établie. Voir l’exemple de code ci-dessous :

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
    const transport = new SSEServerTransport('/messages', res);
    transports[transport.sessionId] = transport;
    res.on("close", () => {
        delete transports[transport.sessionId];
    });
    await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
    const sessionId = req.query.sessionId as string;
    const transport = transports[sessionId];
    if (transport) {
        await transport.handlePostMessage(req, res);
    } else {
        res.status(400).send('No transport found for sessionId');
    }
});
```

Dans le code précédent :

- `/sse` est configuré comme une route. Lorsqu’une requête est faite vers cette route, une nouvelle instance de transport est créée et le serveur *se connecte* via ce transport.
- `/messages` est la route qui gère les messages entrants.

### Python

```python
mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)

```

Dans le code précédent, nous :

- Créons une instance d’un serveur ASGI (en utilisant spécifiquement Starlette) et montons la route par défaut `/`.

  En coulisses, les routes `/sse` et `/messages` sont configurées pour gérer respectivement les connexions et les messages. Le reste de l’application, comme l’ajout de fonctionnalités telles que les outils, fonctionne comme avec les serveurs stdio.

### .NET    

```csharp
    var builder = WebApplication.CreateBuilder(args);
    builder.Services
        .AddMcpServer()
        .WithTools<Tools>();


    builder.Services.AddHttpClient();

    var app = builder.Build();

    app.MapMcp();
    ```

    Il y a deux méthodes qui nous aident à passer d’un serveur web à un serveur web supportant SSE :

    - `AddMcpServer`, cette méthode ajoute les fonctionnalités nécessaires.
    - `MapMcp`, qui ajoute des routes comme `/SSE` et `/messages`.

Maintenant que nous en savons un peu plus sur SSE, construisons un serveur SSE.

## Exercice : Créer un serveur SSE

Pour créer notre serveur, il faut garder deux choses en tête :

- Utiliser un serveur web pour exposer des endpoints pour la connexion et les messages.
- Construire notre serveur comme d’habitude avec les outils, ressources et prompts, comme nous le faisions avec stdio.

### -1- Créer une instance de serveur

Pour créer notre serveur, nous utilisons les mêmes types qu’avec stdio. Cependant, pour le transport, il faut choisir SSE.

### TypeScript

```typescript
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

const server = new McpServer({
  name: "example-server",
  version: "1.0.0"
});

const app = express();

const transports: {[sessionId: string]: SSEServerTransport} = {};
```

Dans le code précédent, nous avons :

- Créé une instance de serveur.
- Défini une application avec le framework web express.
- Créé une variable transports que nous utiliserons pour stocker les connexions entrantes.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

Dans le code précédent, nous avons :

- Importé les bibliothèques nécessaires, notamment Starlette (un framework ASGI).
- Créé une instance de serveur MCP `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

À ce stade, nous avons :

- Créé une application web.
- Ajouté le support des fonctionnalités MCP via `AddMcpServer`.

Passons à l’ajout des routes nécessaires.

### -2- Ajouter les routes

Ajoutons maintenant les routes qui gèrent la connexion et les messages entrants :

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport('/messages', res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send('No transport found for sessionId');
  }
});

app.listen(3001);
```

Dans le code précédent, nous avons défini :

- Une route `/sse` qui instancie un transport de type SSE et appelle `connect` sur le serveur MCP.
- Une route `/messages` qui gère les messages entrants.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

Dans le code précédent, nous avons :

- Créé une instance d’application ASGI avec le framework Starlette. Nous avons passé `mcp.sse_app()` dans la liste des routes, ce qui monte les routes `/sse` et `/messages` sur l’application.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Nous avons ajouté une ligne de code à la fin `add.MapMcp()`, ce qui signifie que nous avons maintenant les routes `/SSE` et `/messages`.

Passons à l’ajout des fonctionnalités au serveur.

### -3- Ajouter des fonctionnalités au serveur

Maintenant que tout ce qui est spécifique à SSE est défini, ajoutons des fonctionnalités au serveur comme des outils, des prompts et des ressources.

### TypeScript

```typescript
server.tool("random-joke", "A joke returned by the chuck norris api", {},
  async () => {
    const response = await fetch("https://api.chucknorris.io/jokes/random");
    const data = await response.json();

    return {
      content: [
        {
          type: "text",
          text: data.value
        }
      ]
    };
  }
);
```

Voici comment ajouter un outil par exemple. Cet outil spécifique crée un outil appelé "random-joke" qui interroge une API Chuck Norris et retourne une réponse JSON.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Votre serveur dispose maintenant d’un outil.

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// Create an MCP server
const server = new McpServer({
  name: "example-server",
  version: "1.0.0",
});

const app = express();

const transports: { [sessionId: string]: SSEServerTransport } = {};

app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport("/messages", res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send("No transport found for sessionId");
  }
});

server.tool("random-joke", "A joke returned by the chuck norris api", {}, async () => {
  const response = await fetch("https://api.chucknorris.io/jokes/random");
  const data = await response.json();

  return {
    content: [
      {
        type: "text",
        text: data.value,
      },
    ],
  };
});

app.listen(3001);
```

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. Commençons par créer quelques outils, pour cela nous allons créer un fichier *Tools.cs* avec le contenu suivant :

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

  namespace server;

  [McpServerToolType]
  public sealed class Tools
  {

      public Tools()
      {
      
      }

      [McpServerTool, Description("Add two numbers together.")]
      public async Task<string> AddNumbers(
          [Description("The first number")] int a,
          [Description("The second number")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  Ici, nous avons ajouté :

  - Créé une classe `Tools` avec le décorateur `McpServerToolType`.
  - Défini un outil `AddNumbers` en décorant la méthode avec `McpServerTool`. Nous avons aussi fourni les paramètres et l’implémentation.

1. Utilisons la classe `Tools` que nous venons de créer :

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Nous avons ajouté un appel à `WithTools` qui spécifie `Tools` comme la classe contenant les outils. Voilà, nous sommes prêts.

Super, nous avons un serveur utilisant SSE, testons-le maintenant.

## Exercice : Déboguer un serveur SSE avec Inspector

Inspector est un excellent outil que nous avons vu dans une leçon précédente [Créer votre premier serveur](/03-GettingStarted/01-first-server/README.md). Voyons si nous pouvons l’utiliser ici aussi :

### -1- Lancer l’inspecteur

Pour lancer l’inspecteur, vous devez d’abord avoir un serveur SSE en fonctionnement, faisons cela :

1. Démarrer le serveur

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Notez que nous utilisons l’exécutable `uvicorn` qui est installé lorsque nous tapons `pip install "mcp[cli]"`. Le fait de taper `server:app` signifie que nous essayons d’exécuter un fichier `server.py` qui contient une instance Starlette appelée `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Cela devrait démarrer le serveur. Pour interagir avec lui, ouvrez un nouveau terminal.

1. Lancer l’inspecteur

    > ![NOTE]
    > Exécutez ceci dans une fenêtre de terminal différente de celle où tourne le serveur. Notez aussi que vous devez adapter la commande ci-dessous à l’URL où votre serveur est hébergé.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Lancer l’inspecteur est identique dans tous les environnements. Notez qu’au lieu de passer un chemin vers notre serveur et une commande pour démarrer le serveur, nous passons l’URL où le serveur tourne et spécifions la route `/sse`.

### -2- Tester l’outil

Connectez le serveur en sélectionnant SSE dans la liste déroulante et remplissez le champ URL avec l’adresse où votre serveur tourne, par exemple http:localhost:4321/sse. Cliquez ensuite sur le bouton "Connect". Comme précédemment, sélectionnez la liste des outils, choisissez un outil et fournissez les valeurs d’entrée. Vous devriez voir un résultat comme ci-dessous :

![Serveur SSE en fonctionnement dans l’inspecteur](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.fr.png)

Super, vous pouvez utiliser l’inspecteur, voyons maintenant comment travailler avec Visual Studio Code.

## Travail à faire

Essayez d’enrichir votre serveur avec plus de fonctionnalités. Consultez [cette page](https://api.chucknorris.io/) pour, par exemple, ajouter un outil qui interroge une API. C’est vous qui décidez à quoi doit ressembler le serveur. Amusez-vous bien :)

## Solution

[Solution](./solution/README.md) Voici une solution possible avec un code fonctionnel.

## Points clés à retenir

Les points clés de ce chapitre sont les suivants :

- SSE est le second type de transport supporté après stdio.
- Pour supporter SSE, il faut gérer les connexions entrantes et les messages via un framework web.
- Vous pouvez utiliser à la fois Inspector et Visual Studio Code pour consommer un serveur SSE, tout comme pour les serveurs stdio. Notez cependant quelques différences entre stdio et SSE. Pour SSE, il faut démarrer le serveur séparément puis lancer l’outil inspector. Pour l’outil inspector, il y a aussi des différences, notamment la nécessité de spécifier l’URL.

## Exemples

- [Calculatrice Java](../samples/java/calculator/README.md)
- [Calculatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculatrice JavaScript](../samples/javascript/README.md)
- [Calculatrice TypeScript](../samples/typescript/README.md)
- [Calculatrice Python](../../../../03-GettingStarted/samples/python)

## Ressources supplémentaires

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Suite

- Suivant : [Streaming HTTP avec MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.