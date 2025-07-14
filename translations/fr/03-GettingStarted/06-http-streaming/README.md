<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-13T20:23:29+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "fr"
}
-->
# Streaming HTTPS avec le Model Context Protocol (MCP)

Ce chapitre offre un guide complet pour mettre en œuvre un streaming sécurisé, évolutif et en temps réel avec le Model Context Protocol (MCP) via HTTPS. Il aborde la motivation du streaming, les mécanismes de transport disponibles, comment implémenter un HTTP streamable dans MCP, les bonnes pratiques de sécurité, la migration depuis SSE, ainsi que des conseils pratiques pour créer vos propres applications MCP en streaming.

## Mécanismes de transport et streaming dans MCP

Cette section explore les différents mécanismes de transport disponibles dans MCP et leur rôle dans l’activation des capacités de streaming pour la communication en temps réel entre clients et serveurs.

### Qu’est-ce qu’un mécanisme de transport ?

Un mécanisme de transport définit comment les données sont échangées entre le client et le serveur. MCP supporte plusieurs types de transport adaptés à différents environnements et besoins :

- **stdio** : Entrée/sortie standard, adapté aux outils locaux et en ligne de commande. Simple mais pas adapté au web ou au cloud.
- **SSE (Server-Sent Events)** : Permet aux serveurs d’envoyer des mises à jour en temps réel aux clients via HTTP. Utile pour les interfaces web, mais limité en scalabilité et flexibilité.
- **Streamable HTTP** : Transport de streaming moderne basé sur HTTP, supportant les notifications et une meilleure scalabilité. Recommandé pour la plupart des scénarios en production et cloud.

### Tableau comparatif

Voici un tableau comparatif pour comprendre les différences entre ces mécanismes de transport :

| Transport         | Mises à jour en temps réel | Streaming | Scalabilité | Cas d’usage              |
|-------------------|----------------------------|-----------|-------------|-------------------------|
| stdio             | Non                        | Non       | Faible      | Outils CLI locaux        |
| SSE               | Oui                        | Oui       | Moyenne     | Web, mises à jour temps réel |
| Streamable HTTP   | Oui                        | Oui       | Élevée      | Cloud, multi-clients    |

> **Astuce :** Le choix du transport impacte les performances, la scalabilité et l’expérience utilisateur. **Streamable HTTP** est recommandé pour des applications modernes, évolutives et prêtes pour le cloud.

Notez les transports stdio et SSE présentés dans les chapitres précédents, et que le streaming HTTP streamable est celui abordé dans ce chapitre.

## Streaming : Concepts et motivation

Comprendre les concepts fondamentaux et les motivations derrière le streaming est essentiel pour mettre en place des systèmes de communication en temps réel efficaces.

Le **streaming** est une technique en programmation réseau qui permet d’envoyer et de recevoir des données en petits morceaux gérables ou sous forme de séquence d’événements, plutôt que d’attendre que la réponse complète soit prête. Cela est particulièrement utile pour :

- Les fichiers ou ensembles de données volumineux.
- Les mises à jour en temps réel (ex. : chat, barres de progression).
- Les calculs longs où l’on souhaite tenir l’utilisateur informé.

Voici l’essentiel à savoir sur le streaming :

- Les données sont livrées progressivement, pas en une seule fois.
- Le client peut traiter les données au fur et à mesure de leur arrivée.
- Réduit la latence perçue et améliore l’expérience utilisateur.

### Pourquoi utiliser le streaming ?

Les raisons d’utiliser le streaming sont les suivantes :

- Les utilisateurs reçoivent un retour immédiat, pas seulement à la fin.
- Permet des applications en temps réel et des interfaces réactives.
- Utilisation plus efficace des ressources réseau et calcul.

### Exemple simple : serveur et client HTTP en streaming

Voici un exemple simple d’implémentation du streaming :

<details>
<summary>Python</summary>

**Serveur (Python, avec FastAPI et StreamingResponse) :**
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

**Client (Python, avec requests) :**
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
- Le client reçoit et affiche chaque morceau à son arrivée.

**Prérequis :**
- Le serveur doit utiliser une réponse en streaming (ex. `StreamingResponse` dans FastAPI).
- Le client doit traiter la réponse comme un flux (`stream=True` dans requests).
- Le Content-Type est généralement `text/event-stream` ou `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Serveur (Java, avec Spring Boot et Server-Sent Events) :**

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

**Client (Java, avec Spring WebFlux WebClient) :**

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

**Notes sur l’implémentation Java :**
- Utilise la pile réactive de Spring Boot avec `Flux` pour le streaming
- `ServerSentEvent` fournit un streaming d’événements structuré avec types d’événements
- `WebClient` avec `bodyToFlux()` permet la consommation réactive du streaming
- `delayElements()` simule un temps de traitement entre les événements
- Les événements peuvent avoir des types (`info`, `result`) pour une meilleure gestion côté client

</details>

### Comparaison : Streaming classique vs streaming MCP

Les différences entre le streaming "classique" et le streaming dans MCP peuvent se résumer ainsi :

| Fonctionnalité         | Streaming HTTP classique       | Streaming MCP (Notifications)     |
|-----------------------|-------------------------------|----------------------------------|
| Réponse principale    | En morceaux (chunked)          | Unique, à la fin                 |
| Mises à jour de progression | Envoyées en morceaux de données | Envoyées sous forme de notifications |
| Exigences côté client | Doit traiter le flux            | Doit implémenter un gestionnaire de messages |
| Cas d’usage           | Fichiers volumineux, flux de tokens IA | Progression, logs, retours en temps réel |

### Différences clés observées

Voici quelques différences majeures :

- **Mode de communication :**
   - Streaming HTTP classique : utilise un encodage chunked simple pour envoyer les données en morceaux
   - Streaming MCP : utilise un système structuré de notifications avec le protocole JSON-RPC

- **Format des messages :**
   - HTTP classique : morceaux de texte brut avec des retours à la ligne
   - MCP : objets LoggingMessageNotification structurés avec métadonnées

- **Implémentation client :**
   - HTTP classique : client simple qui traite les réponses en streaming
   - MCP : client plus sophistiqué avec un gestionnaire de messages pour traiter différents types de messages

- **Mises à jour de progression :**
   - HTTP classique : la progression fait partie du flux principal de la réponse
   - MCP : la progression est envoyée via des messages de notification séparés tandis que la réponse principale arrive à la fin

### Recommandations

Voici quelques conseils pour choisir entre un streaming classique (comme l’endpoint `/stream` montré plus haut) et un streaming via MCP :

- **Pour des besoins simples de streaming :** Le streaming HTTP classique est plus simple à mettre en œuvre et suffisant pour des besoins basiques.

- **Pour des applications complexes et interactives :** Le streaming MCP offre une approche plus structurée avec des métadonnées riches et une séparation claire entre notifications et résultats finaux.

- **Pour les applications IA :** Le système de notifications MCP est particulièrement utile pour les tâches IA longues où l’on souhaite tenir l’utilisateur informé de la progression.

## Streaming dans MCP

Vous avez vu des recommandations et comparaisons sur la différence entre streaming classique et streaming MCP. Entrons maintenant dans le détail de la manière dont vous pouvez exploiter le streaming dans MCP.

Comprendre comment fonctionne le streaming dans le cadre MCP est essentiel pour construire des applications réactives qui fournissent un retour en temps réel aux utilisateurs lors d’opérations longues.

Dans MCP, le streaming ne consiste pas à envoyer la réponse principale en morceaux, mais à envoyer des **notifications** au client pendant qu’un outil traite une requête. Ces notifications peuvent inclure des mises à jour de progression, des logs ou d’autres événements.

### Comment ça marche

Le résultat principal est toujours envoyé en une seule réponse. Cependant, des notifications peuvent être envoyées sous forme de messages séparés pendant le traitement, permettant ainsi de mettre à jour le client en temps réel. Le client doit être capable de gérer et d’afficher ces notifications.

## Qu’est-ce qu’une notification ?

Nous avons parlé de "Notification", que signifie ce terme dans le contexte MCP ?

Une notification est un message envoyé du serveur au client pour informer de la progression, du statut ou d’autres événements durant une opération longue. Les notifications améliorent la transparence et l’expérience utilisateur.

Par exemple, un client doit envoyer une notification une fois que la négociation initiale avec le serveur est effectuée.

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

Les notifications appartiennent à un sujet dans MCP appelé ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Pour activer le logging, le serveur doit l’activer comme fonctionnalité/capacité ainsi :

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Selon le SDK utilisé, le logging peut être activé par défaut, ou vous devrez peut-être l’activer explicitement dans la configuration du serveur.

Il existe différents types de notifications :

| Niveau     | Description                    | Exemple d’utilisation          |
|------------|-------------------------------|-------------------------------|
| debug      | Informations détaillées de débogage | Points d’entrée/sortie de fonction |
| info       | Messages d’information générale | Mises à jour de progression   |
| notice     | Événements normaux mais significatifs | Changements de configuration  |
| warning    | Conditions d’avertissement      | Utilisation de fonctionnalités dépréciées |
| error      | Conditions d’erreur             | Échecs d’opération            |
| critical   | Conditions critiques            | Pannes de composants système  |
| alert      | Action immédiate requise        | Corruption de données détectée |
| emergency  | Système inutilisable            | Panne complète du système     |

## Implémentation des notifications dans MCP

Pour implémenter les notifications dans MCP, vous devez configurer à la fois le serveur et le client pour gérer les mises à jour en temps réel. Cela permet à votre application de fournir un retour immédiat aux utilisateurs lors d’opérations longues.

### Côté serveur : envoi des notifications

Commençons par le serveur. Dans MCP, vous définissez des outils capables d’envoyer des notifications pendant le traitement des requêtes. Le serveur utilise l’objet contexte (généralement `ctx`) pour envoyer des messages au client.

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

Dans l’exemple précédent, l’outil `process_files` envoie trois notifications au client au fur et à mesure du traitement de chaque fichier. La méthode `ctx.info()` est utilisée pour envoyer des messages d’information.

</details>

De plus, pour activer les notifications, assurez-vous que votre serveur utilise un transport en streaming (comme `streamable-http`) et que votre client implémente un gestionnaire de messages pour traiter les notifications. Voici comment configurer le serveur pour utiliser le transport `streamable-http` :

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

Dans cet exemple .NET, l’outil `ProcessFiles` est décoré avec l’attribut `Tool` et envoie trois notifications au client pendant le traitement de chaque fichier. La méthode `ctx.Info()` est utilisée pour envoyer des messages d’information.

Pour activer les notifications dans votre serveur MCP .NET, assurez-vous d’utiliser un transport en streaming :

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Côté client : réception des notifications

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

Dans le code précédent, la fonction `message_handler` vérifie si le message entrant est une notification. Si c’est le cas, elle affiche la notification ; sinon, elle traite le message comme une réponse serveur classique. Notez également comment `ClientSession` est initialisé avec `message_handler` pour gérer les notifications entrantes.

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

Dans cet exemple .NET, la fonction `MessageHandler` vérifie si le message entrant est une notification. Si oui, elle affiche la notification ; sinon, elle la traite comme un message serveur classique. `ClientSession` est initialisé avec le gestionnaire de messages via `ClientSessionOptions`.

</details>

Pour activer les notifications, assurez-vous que votre serveur utilise un transport en streaming (comme `streamable-http`) et que votre client implémente un gestionnaire de messages pour traiter les notifications.

## Notifications de progression & scénarios

Cette section explique le concept des notifications de progression dans MCP, pourquoi elles sont importantes, et comment les implémenter avec Streamable HTTP. Vous trouverez également un exercice pratique pour renforcer votre compréhension.

Les notifications de progression sont des messages en temps réel envoyés du serveur au client pendant des opérations longues. Plutôt que d’attendre la fin complète du processus, le serveur tient le client informé de l’état actuel. Cela améliore la transparence, l’expérience utilisateur et facilite le débogage.

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
- **Débogage et surveillance facilités :** Développeurs et utilisateurs peuvent voir où un processus est lent ou bloqué.

### Comment implémenter les notifications de progression

Voici comment implémenter les notifications de progression dans MCP :

- **Côté serveur :** Utilisez `ctx.info()` ou `ctx.log()` pour envoyer des notifications à chaque étape du traitement. Cela envoie un message au client avant que le résultat principal soit prêt.
- **Côté client :** Implémentez un gestionnaire de messages qui écoute et affiche les notifications à leur arrivée. Ce gestionnaire distingue les notifications du résultat final.

**Exemple serveur :**

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

Lors de la mise en place de serveurs MCP utilisant des transports basés sur HTTP, la sécurité devient une préoccupation majeure nécessitant une attention particulière à plusieurs vecteurs d’attaque et mécanismes de protection.

### Vue d’ensemble

La sécurité est essentielle lorsqu’on expose des serveurs MCP via HTTP. Le streaming HTTP introduit de nouvelles surfaces d’attaque et demande une configuration rigoureuse.

### Points Clés
- **Validation de l’en-tête Origin** : Validez toujours l’en-tête `Origin` pour éviter les attaques de type DNS rebinding.
- **Liaison à localhost** : Pour le développement local, liez les serveurs à `localhost` afin d’éviter une exposition sur Internet.
- **Authentification** : Mettez en place une authentification (par exemple, clés API, OAuth) pour les déploiements en production.
- **CORS** : Configurez les politiques Cross-Origin Resource Sharing (CORS) pour restreindre l’accès.
- **HTTPS** : Utilisez HTTPS en production pour chiffrer les échanges.

### Bonnes Pratiques
- Ne faites jamais confiance aux requêtes entrantes sans validation.
- Enregistrez et surveillez tous les accès et erreurs.
- Mettez régulièrement à jour les dépendances pour corriger les vulnérabilités de sécurité.

### Défis
- Trouver un équilibre entre sécurité et facilité de développement
- Assurer la compatibilité avec différents environnements clients


## Passage de SSE à Streamable HTTP

Pour les applications utilisant actuellement Server-Sent Events (SSE), migrer vers Streamable HTTP offre des capacités améliorées et une meilleure pérennité pour vos implémentations MCP.

### Pourquoi migrer ?

Deux raisons majeures justifient la migration de SSE vers Streamable HTTP :

- Streamable HTTP offre une meilleure scalabilité, compatibilité et un support plus riche des notifications que SSE.
- C’est le transport recommandé pour les nouvelles applications MCP.

### Étapes de migration

Voici comment migrer de SSE vers Streamable HTTP dans vos applications MCP :

- **Mettez à jour le code serveur** pour utiliser `transport="streamable-http"` dans `mcp.run()`.
- **Mettez à jour le code client** pour utiliser `streamablehttp_client` à la place du client SSE.
- **Implémentez un gestionnaire de messages** côté client pour traiter les notifications.
- **Testez la compatibilité** avec les outils et workflows existants.

### Maintien de la compatibilité

Il est conseillé de maintenir la compatibilité avec les clients SSE existants pendant la migration. Voici quelques stratégies :

- Vous pouvez supporter à la fois SSE et Streamable HTTP en exécutant les deux transports sur des points d’accès différents.
- Migrer progressivement les clients vers le nouveau transport.

### Défis

Assurez-vous de prendre en compte les défis suivants lors de la migration :

- Veiller à ce que tous les clients soient mis à jour
- Gérer les différences dans la livraison des notifications

## Considérations de Sécurité

La sécurité doit être une priorité absolue lors de la mise en œuvre de tout serveur, en particulier avec des transports HTTP comme Streamable HTTP dans MCP.

Lors de la mise en place de serveurs MCP utilisant des transports basés sur HTTP, la sécurité devient une préoccupation majeure nécessitant une attention particulière à plusieurs vecteurs d’attaque et mécanismes de protection.

### Vue d’ensemble

La sécurité est essentielle lorsqu’on expose des serveurs MCP via HTTP. Streamable HTTP introduit de nouvelles surfaces d’attaque et demande une configuration rigoureuse.

Voici quelques points clés en matière de sécurité :

- **Validation de l’en-tête Origin** : Validez toujours l’en-tête `Origin` pour éviter les attaques de type DNS rebinding.
- **Liaison à localhost** : Pour le développement local, liez les serveurs à `localhost` afin d’éviter une exposition sur Internet.
- **Authentification** : Mettez en place une authentification (par exemple, clés API, OAuth) pour les déploiements en production.
- **CORS** : Configurez les politiques Cross-Origin Resource Sharing (CORS) pour restreindre l’accès.
- **HTTPS** : Utilisez HTTPS en production pour chiffrer les échanges.

### Bonnes Pratiques

De plus, voici quelques bonnes pratiques à suivre lors de la mise en œuvre de la sécurité dans votre serveur de streaming MCP :

- Ne faites jamais confiance aux requêtes entrantes sans validation.
- Enregistrez et surveillez tous les accès et erreurs.
- Mettez régulièrement à jour les dépendances pour corriger les vulnérabilités de sécurité.

### Défis

Vous rencontrerez certains défis lors de la mise en œuvre de la sécurité dans les serveurs de streaming MCP :

- Trouver un équilibre entre sécurité et facilité de développement
- Assurer la compatibilité avec différents environnements clients

### Exercice : Créez votre propre application MCP en streaming

**Scénario :**  
Créez un serveur et un client MCP où le serveur traite une liste d’éléments (par exemple, fichiers ou documents) et envoie une notification pour chaque élément traité. Le client doit afficher chaque notification dès sa réception.

**Étapes :**

1. Implémentez un outil serveur qui traite une liste et envoie des notifications pour chaque élément.
2. Implémentez un client avec un gestionnaire de messages pour afficher les notifications en temps réel.
3. Testez votre implémentation en lançant serveur et client, et observez les notifications.

[Solution](./solution/README.md)

## Lectures complémentaires & Étapes suivantes

Pour poursuivre votre apprentissage du streaming MCP et approfondir vos connaissances, cette section propose des ressources supplémentaires et des suggestions pour créer des applications plus avancées.

### Lectures complémentaires

- [Microsoft : Introduction au streaming HTTP](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft : Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft : CORS dans ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests : Requêtes en streaming](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Étapes suivantes

- Essayez de créer des outils MCP plus avancés utilisant le streaming pour l’analyse en temps réel, le chat ou l’édition collaborative.
- Explorez l’intégration du streaming MCP avec des frameworks frontend (React, Vue, etc.) pour des mises à jour d’interface en direct.
- Suivant : [Utilisation de AI Toolkit pour VSCode](../07-aitk/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.