<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d5b044c0924d393af3066e03d7d89c5",
  "translation_date": "2025-07-16T09:33:49+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "fr"
}
-->
### -2- Créer un projet

Maintenant que vous avez installé votre SDK, passons à la création d’un projet :

### -3- Créer les fichiers du projet

### -4- Écrire le code du serveur

### -5- Ajouter un outil et une ressource

Ajoutez un outil et une ressource en insérant le code suivant :

### -6 Code final

Ajoutons le dernier morceau de code nécessaire pour que le serveur puisse démarrer :

### -7- Tester le serveur

Démarrez le serveur avec la commande suivante :

### -8- Lancer avec l’inspecteur

L’inspecteur est un excellent outil qui peut démarrer votre serveur et vous permettre d’interagir avec lui pour vérifier son bon fonctionnement. Démarrons-le :
> [!NOTE]  
> cela peut sembler différent dans le champ "command" car il contient la commande pour lancer un serveur avec votre runtime spécifique/
Vous devriez voir l'interface utilisateur suivante :

![Connect](/03-GettingStarted/01-first-server/assets/connect.png)

1. Connectez-vous au serveur en sélectionnant le bouton Connect
  Une fois connecté au serveur, vous devriez voir ceci :

  ![Connected](/03-GettingStarted/01-first-server/assets/connected.png)

1. Sélectionnez "Tools" puis "listTools", vous devriez voir apparaître "Add", sélectionnez "Add" et remplissez les valeurs des paramètres.

  Vous devriez voir la réponse suivante, c’est-à-dire un résultat de l’outil "add" :

  ![Result of running add](/03-GettingStarted/01-first-server/assets/ran-tool.png)

Félicitations, vous avez réussi à créer et exécuter votre premier serveur !

### SDK officiels

MCP propose des SDK officiels pour plusieurs langages :

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Maintenu en collaboration avec Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Maintenu en collaboration avec Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - L’implémentation officielle en TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - L’implémentation officielle en Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - L’implémentation officielle en Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Maintenu en collaboration avec Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - L’implémentation officielle en Rust

## Points clés à retenir

- La mise en place d’un environnement de développement MCP est simple grâce aux SDK spécifiques à chaque langage
- Construire des serveurs MCP consiste à créer et enregistrer des outils avec des schémas clairs
- Les tests et le débogage sont essentiels pour des implémentations MCP fiables

## Exemples

- [Calculatrice Java](../samples/java/calculator/README.md)
- [Calculatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculatrice JavaScript](../samples/javascript/README.md)
- [Calculatrice TypeScript](../samples/typescript/README.md)
- [Calculatrice Python](../../../../03-GettingStarted/samples/python)

## Exercice

Créez un serveur MCP simple avec un outil de votre choix :

1. Implémentez l’outil dans le langage de votre choix (.NET, Java, Python ou JavaScript).
2. Définissez les paramètres d’entrée et les valeurs de retour.
3. Lancez l’outil inspector pour vérifier que le serveur fonctionne comme prévu.
4. Testez l’implémentation avec différentes entrées.

## Solution

[Solution](./solution/README.md)

## Ressources supplémentaires

- [Créer des agents avec Model Context Protocol sur Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP distant avec Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [Agent MCP OpenAI .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Et ensuite

Suivant : [Premiers pas avec les clients MCP](../02-client/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.