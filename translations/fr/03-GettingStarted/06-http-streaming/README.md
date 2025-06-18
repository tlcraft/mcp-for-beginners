<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:29:12+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "fr"
}
-->
# Streaming HTTPS avec le Model Context Protocol (MCP)

Ce chapitre propose un guide complet pour mettre en œuvre un streaming sécurisé, évolutif et en temps réel avec le Model Context Protocol (MCP) via HTTPS. Il couvre la motivation du streaming, les mécanismes de transport disponibles, comment implémenter un HTTP streamable dans MCP, les bonnes pratiques de sécurité, la migration depuis SSE, ainsi que des conseils pratiques pour créer vos propres applications MCP en streaming.

## Mécanismes de Transport et Streaming dans MCP

Cette section explore les différents mécanismes de transport disponibles dans MCP et leur rôle dans l’activation des capacités de streaming pour la communication en temps réel entre clients et serveurs.

### Qu’est-ce qu’un Mécanisme de Transport ?

Un mécanisme de transport définit comment les données sont échangées entre le client et le serveur. MCP supporte plusieurs types de transport adaptés à différents environnements et besoins :

- **stdio** : Entrée/sortie standard, adapté aux outils locaux et en ligne de commande. Simple mais non adapté au web ou au cloud.
- **SSE (Server-Sent Events)** : Permet aux serveurs d’envoyer des mises à jour en temps réel aux clients via HTTP. Bien pour les interfaces web, mais limité en scalabilité et flexibilité.
- **Streamable HTTP** : Transport de streaming moderne basé sur HTTP, supportant les notifications et une meilleure scalabilité. Recommandé pour la plupart des scénarios en production et cloud.

### Tableau Comparatif

Voici un tableau comparatif pour comprendre les différences entre ces mécanismes de transport :

| Transport        | Mises à jour en temps réel | Streaming | Scalabilité | Cas d’utilisation          |
|------------------|----------------------------|-----------|-------------|----------------------------|
| stdio            | Non                        | Non       | Faible      | Outils CLI locaux           |
| SSE              | Oui                        | Oui       | Moyenne     | Web, mises à jour temps réel|
| Streamable HTTP  | Oui                        | Oui       | Élevée      | Cloud, multi-clients       |

> **Astuce :** Le choix du transport impacte la performance, la scalabilité et l’expérience utilisateur. **Streamable HTTP** est recommandé pour des applications modernes, évolutives et prêtes pour le cloud.

Notez les transports stdio et SSE présentés dans les chapitres précédents, et que le streaming HTTP streamable est le transport abordé dans ce chapitre.

## Streaming : Concepts et Motivation

Comprendre les concepts fondamentaux et la motivation derrière le streaming est essentiel pour mettre en place des systèmes de communication en temps réel efficaces.

Le **streaming** est une technique en programmation réseau qui permet d’envoyer et de recevoir des données en petits morceaux gérables ou sous forme de séquence d’événements, plutôt que d’attendre qu’une réponse complète soit prête. Cela est particulièrement utile pour :

- Les fichiers ou ensembles de données volumineux.
- Les mises à jour en temps réel (ex. : chat, barres de progression).
- Les calculs longs où l’on souhaite tenir l’utilisateur informé.

Voici ce qu’il faut retenir sur le streaming à un niveau global :

- Les données sont délivrées progressivement, pas en une seule fois.
- Le client peut traiter les données au fur et à mesure de leur arrivée.
- Réduit la latence perçue et améliore l’expérience utilisateur.

### Pourquoi utiliser le streaming ?

Les raisons d’utiliser le streaming sont les suivantes :

- Les utilisateurs reçoivent un retour immédiat, pas seulement à la fin.
- Permet des applications en temps réel et des interfaces réactives.
- Utilisation plus efficace des ressources réseau et calcul.

### Exemple Simple : Serveur & Client HTTP en Streaming

Voici un exemple simple de mise en œuvre du streaming :

<details>
<summary>Python</summary>

**Serveur (Python, utilisant FastAPI et StreamingResponse) :**
<details>
<summary>Python</summary>

```python
from fastapi import FastAPI
from fastapi.responses import StreamingResponse
import time

app = FastAPI()

async def event_stream():
    for i in range(1, 6):
        yield f"data: Message {i}\n\n"
        time.sleep(1)

@app.get("/stream")
def stream():
    return StreamingResponse(event_stream(), media_type="text/event-stream")
```

</details>

**Client (Python, utilisant requests) :**
<details>
<summary>Python</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

Cet exemple montre un serveur envoyant une série de messages au client dès qu’ils sont disponibles, au lieu d’attendre que tous les messages soient prêts.

**Fonctionnement :**
- Le serveur émet chaque message dès qu’il est prêt.
- Le client reçoit et affiche chaque morceau dès son arrivée.

**Prérequis :**
- Le serveur doit utiliser une réponse en streaming (ex. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**Serveur (Java, utilisant Spring Boot et Server-Sent Events) :**

```java
@RestController
public class CalculatorController {

    @GetMapping(value = "/calculate", produces = MediaType.TEXT_EVENT_STREAM_VALUE)
    public Flux<ServerSentEvent<String>> calculate(@RequestParam double a,
                                                   @RequestParam double b,
                                                   @RequestParam String op) {
        
        double result;
        switch (op) {
            case "add": result = a + b; break;
            case "sub": result = a - b; break;
            case "mul": result = a * b; break;
            case "div": result = b != 0 ? a / b : Double.NaN; break;
            default: result = Double.NaN;
        }

        return Flux.<ServerSentEvent<String>>just(
                    ServerSentEvent.<String>builder()
                        .event("info")
                        .data("Calculating: " + a + " " + op + " " + b)
                        .build(),
                    ServerSentEvent.<String>builder()
                        .event("result")
                        .data(String.valueOf(result))
                        .build()
                )
                .delayElements(Duration.ofSeconds(1));
    }
}
```

**Client (Java, utilisant Spring WebFlux WebClient) :**

```java
@SpringBootApplication
public class CalculatorClientApplication implements CommandLineRunner {

    private final WebClient client = WebClient.builder()
            .baseUrl("http://localhost:8080")
            .build();

    @Override
    public void run(String... args) {
        client.get()
                .uri(uriBuilder -> uriBuilder
                        .path("/calculate")
                        .queryParam("a", 7)
                        .queryParam("b", 5)
                        .queryParam("op", "mul")
                        .build())
                .accept(MediaType.TEXT_EVENT_STREAM)
                .retrieve()
                .bodyToFlux(String.class)
                .doOnNext(System.out::println)
                .blockLast();
    }
}
```

**Notes d’implémentation Java :**
- Utilise la pile réactive de Spring Boot avec `Flux` for streaming
- `ServerSentEvent` provides structured event streaming with event types
- `WebClient` with `bodyToFlux()` enables reactive streaming consumption
- `delayElements()` simulates processing time between events
- Events can have types (`info`, `result`) for better client handling

</details>

### Comparison: Classic Streaming vs MCP Streaming

The differences between how streaming works in a "classical" manner versus how it works in MCP can be depicted like so:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

Additionally, here are some key differences:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

- **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) versus choix du streaming via MCP.

- **Pour des besoins simples de streaming :** Le streaming HTTP classique est plus simple à implémenter et suffisant pour des besoins basiques.

- **Pour des applications complexes et interactives :** Le streaming MCP offre une approche plus structurée avec des métadonnées riches et une séparation entre notifications et résultats finaux.

- **Pour les applications d’IA :** Le système de notification MCP est particulièrement utile pour les tâches IA longues où l’on souhaite tenir l’utilisateur informé de la progression.

## Streaming dans MCP

Vous avez maintenant vu quelques recommandations et comparaisons entre le streaming classique et le streaming dans MCP. Entrons dans le détail de la manière dont vous pouvez exploiter le streaming dans MCP.

Comprendre comment le streaming fonctionne dans le cadre MCP est essentiel pour construire des applications réactives qui fournissent un retour en temps réel aux utilisateurs pendant des opérations longues.

Dans MCP, le streaming ne consiste pas à envoyer la réponse principale en morceaux, mais à envoyer des **notifications** au client pendant qu’un outil traite une requête. Ces notifications peuvent inclure des mises à jour de progression, des logs ou d’autres événements.

### Comment ça fonctionne

Le résultat principal est toujours envoyé en une seule réponse. Cependant, des notifications peuvent être envoyées sous forme de messages séparés pendant le traitement, permettant ainsi de mettre à jour le client en temps réel. Le client doit pouvoir gérer et afficher ces notifications.

## Qu’est-ce qu’une Notification ?

Nous avons parlé de "Notification", qu’est-ce que cela signifie dans le contexte MCP ?

Une notification est un message envoyé du serveur vers le client pour informer de la progression, du statut ou d’autres événements pendant une opération longue. Les notifications améliorent la transparence et l’expérience utilisateur.

Par exemple, un client est censé envoyer une notification une fois que la négociation initiale avec le serveur est effectuée.

Une notification ressemble à ceci sous forme de message JSON :

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Les notifications appartiennent à un topic dans MCP appelé ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Pour activer le logging, le serveur doit l’activer en tant que fonctionnalité/capacité comme ceci :

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Selon le SDK utilisé, le logging peut être activé par défaut, ou vous devrez l’activer explicitement dans la configuration du serveur.

Il existe différents types de notifications :

| Niveau     | Description                    | Exemple d’utilisation          |
|------------|-------------------------------|-------------------------------|
| debug      | Informations détaillées de débogage | Points d’entrée/sortie de fonctions |
| info       | Messages d’information générale | Mises à jour de progression   |
| notice     | Événements normaux mais importants | Changements de configuration  |
| warning    | Conditions d’alerte            | Utilisation de fonctionnalités dépréciées |
| error      | Conditions d’erreur            | Échecs d’opérations           |
| critical   | Conditions critiques           | Pannes de composants système  |
| alert      | Action immédiate requise       | Corruption de données détectée|
| emergency  | Système inutilisable           | Panne complète du système     |

## Implémentation des Notifications dans MCP

Pour implémenter les notifications dans MCP, vous devez configurer à la fois le serveur et le client pour gérer les mises à jour en temps réel. Cela permet à votre application de fournir un retour immédiat aux utilisateurs pendant les opérations longues.

### Côté serveur : Envoi des Notifications

Commençons par le serveur. Dans MCP, vous définissez des outils qui peuvent envoyer des notifications pendant le traitement des requêtes. Le serveur utilise l’objet contexte (généralement `ctx`) pour envoyer des messages au client.

<details>
<summary>Python</summary>

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

Dans l’exemple précédent, la méthode `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` est utilisée pour envoyer des notifications via le transport :

```python
mcp.run(transport="streamable-http")
```

</details>

<details>
<summary>.NET</summary>

```csharp
[Tool("A tool that sends progress notifications")]
public async Task<TextContent> ProcessFiles(string message, ToolContext ctx)
{
    await ctx.Info("Processing file 1/3...");
    await ctx.Info("Processing file 2/3...");
    await ctx.Info("Processing file 3/3...");
    return new TextContent
    {
        Type = "text",
        Text = $"Done: {message}"
    };
}
```

Dans cet exemple .NET, la méthode `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` est utilisée pour envoyer des messages d’information.

Pour activer les notifications dans votre serveur MCP .NET, assurez-vous d’utiliser un transport en streaming :

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Côté client : Réception des Notifications

Le client doit implémenter un gestionnaire de messages pour traiter et afficher les notifications à leur arrivée.

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)

async with ClientSession(
   read_stream, 
   write_stream,
   logging_callback=logging_collector,
   message_handler=message_handler,
) as session:
```

Dans le code précédent, le `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` est utilisé pour gérer les notifications entrantes.

</details>

<details>
<summary>.NET</summary>

```csharp
// Define a message handler
void MessageHandler(IJsonRpcMessage message)
{
    if (message is ServerNotification notification)
    {
        Console.WriteLine($"NOTIFICATION: {notification}");
    }
    else
    {
        Console.WriteLine($"SERVER MESSAGE: {message}");
    }
}

// Create and use a client session with the message handler
var clientOptions = new ClientSessionOptions
{
    MessageHandler = MessageHandler,
    LoggingCallback = (level, message) => Console.WriteLine($"[{level}] {message}")
};

using var client = new ClientSession(readStream, writeStream, clientOptions);
await client.InitializeAsync();

// Now the client will process notifications through the MessageHandler
```

Dans cet exemple .NET, le `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` est utilisé, et votre client implémente un gestionnaire de messages pour traiter les notifications.

## Notifications de Progression & Scénarios

Cette section explique le concept de notifications de progression dans MCP, pourquoi elles sont importantes et comment les implémenter avec Streamable HTTP. Vous trouverez également un exercice pratique pour renforcer votre compréhension.

Les notifications de progression sont des messages en temps réel envoyés du serveur au client pendant des opérations longues. Plutôt que d’attendre la fin complète du processus, le serveur tient le client informé du statut actuel. Cela améliore la transparence, l’expérience utilisateur et facilite le débogage.

**Exemple :**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Pourquoi utiliser les notifications de progression ?

Les notifications de progression sont essentielles pour plusieurs raisons :

- **Meilleure expérience utilisateur :** Les utilisateurs voient les mises à jour au fur et à mesure, pas seulement à la fin.
- **Retour en temps réel :** Les clients peuvent afficher des barres de progression ou des logs, rendant l’application plus réactive.
- **Débogage et surveillance facilités :** Les développeurs et utilisateurs peuvent voir où un processus est lent ou bloqué.

### Comment implémenter les notifications de progression

Voici comment vous pouvez implémenter les notifications de progression dans MCP :

- **Côté serveur :** Utilisez `ctx.info()` or `ctx.log()` pour envoyer des notifications à chaque élément traité. Cela envoie un message au client avant que le résultat principal soit prêt.
- **Côté client :** Implémentez un gestionnaire de messages qui écoute et affiche les notifications à leur arrivée. Ce gestionnaire distingue les notifications du résultat final.

**Exemple Serveur :**

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

</details>

**Exemple Client :**

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## Considérations de Sécurité

Lors de la mise en place de serveurs MCP avec des transports basés sur HTTP, la sécurité devient une préoccupation majeure nécessitant une attention rigoureuse aux différents vecteurs d’attaque et mécanismes de protection.

### Vue d’ensemble

La sécurité est cruciale lorsqu’on expose des serveurs MCP via HTTP. Le streaming HTTP introduit de nouvelles surfaces d’attaque et demande une configuration soigneuse.

### Points Clés
- **Validation de l’en-tête Origin** : Validez toujours l’en-tête `Origin` pour empêcher les attaques de type Cross-Origin.
- **Utilisation de HTTPS** : Assurez-vous que toutes les communications se font via HTTPS pour protéger les données en transit.
- **Authentification et Autorisation** : Implémentez des mécanismes solides pour vérifier les utilisateurs et leurs droits.
- **Gestion des erreurs et exceptions** : Ne divulguez pas d’informations sensibles dans les messages d’erreur.
- **Limitation des requêtes** : Protégez-vous contre les attaques par déni de service (DoS) en limitant le nombre de connexions ou requêtes.

### Maintenir la Compatibilité

Il est recommandé de maintenir la compatibilité avec les clients SSE existants durant la migration. Voici quelques stratégies :

- Vous pouvez supporter à la fois SSE et Streamable HTTP en faisant tourner les deux transports sur des points d’accès différents.
- Migrer progressivement les clients vers le nouveau transport.

### Défis

Assurez-vous de gérer les défis suivants lors de la migration :

- Garantir que tous les clients soient mis à jour.
- Gérer les différences dans la livraison des notifications.

### Exercice : Construisez votre propre application MCP en streaming

**Scénario :**  
Créez un serveur et un client MCP où le serveur traite une liste d’éléments (ex. : fichiers ou documents) et envoie une notification pour chaque élément traité. Le client doit afficher chaque notification à son arrivée.

**Étapes :**

1. Implémentez un outil serveur qui traite une liste et envoie des notifications pour chaque élément.
2. Implémentez un client avec un gestionnaire de messages pour afficher les notifications en temps réel.
3. Testez votre implémentation en lançant serveur et client, et observez les notifications.

[Solution](./solution/README.md)

## Lectures Complémentaires & Étapes Suivantes

Pour poursuivre votre apprentissage du streaming MCP et approfondir vos connaissances, cette section propose des ressources supplémentaires et des étapes suggérées pour créer des applications plus avancées.

### Lectures Complémentaires

- [Microsoft : Introduction au HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft : Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft : CORS dans ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests : Requêtes en streaming](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Étapes Suivantes

- Essayez de créer des outils MCP plus avancés qui utilisent le streaming pour l’analyse en temps réel, le chat ou l’édition collaborative.
- Explorez l’intégration du streaming MCP avec des frameworks frontend (React, Vue, etc.) pour des mises à jour d’interface en direct.
- Ensuite : [Utilisation de AI Toolkit pour VSCode](../07-aitk/README.md)

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l'utilisation de cette traduction.