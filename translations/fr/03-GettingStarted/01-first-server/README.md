<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:15:39+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "fr"
}
-->
### -2- Créer un projet

Maintenant que vous avez installé votre SDK, passons à la création d’un projet : 

### -3- Créer les fichiers du projet

### -4- Écrire le code du serveur

### -5- Ajouter un outil et une ressource

Ajoutez un outil et une ressource en ajoutant le code suivant :

### -6 Code final

Ajoutons le dernier morceau de code nécessaire pour que le serveur puisse démarrer :

### -7- Tester le serveur

Démarrez le serveur avec la commande suivante :

### -8- Utiliser l’inspecteur

L’inspecteur est un excellent outil qui peut démarrer votre serveur et vous permettre d’interagir avec lui pour tester son bon fonctionnement. Démarrons-le :

> [!NOTE]
> il se peut que le champ "commande" soit différent car il contient la commande pour exécuter un serveur avec votre runtime spécifique/

Vous devriez voir l’interface utilisateur suivante :

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.fr.png)

1. Connectez-vous au serveur en sélectionnant le bouton Connect  
   Une fois connecté au serveur, vous devriez voir ceci :

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.fr.png)

2. Sélectionnez "Tools" puis "listTools", vous devriez voir apparaître "Add". Sélectionnez "Add" et remplissez les valeurs des paramètres.

   Vous devriez obtenir la réponse suivante, c’est-à-dire un résultat de l’outil "add" :

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.fr.png)

Félicitations, vous avez réussi à créer et exécuter votre premier serveur !

### SDK officiels

MCP propose des SDK officiels pour plusieurs langages :  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Maintenu en collaboration avec Microsoft  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Maintenu en collaboration avec Spring AI  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implémentation officielle TypeScript  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implémentation officielle Python  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implémentation officielle Kotlin  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Maintenu en collaboration avec Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implémentation officielle Rust  

## Points clés à retenir

- La mise en place d’un environnement de développement MCP est simple grâce aux SDK spécifiques à chaque langage  
- Construire des serveurs MCP consiste à créer et enregistrer des outils avec des schémas clairs  
- Tester et déboguer est essentiel pour des implémentations MCP fiables  

## Exemples

- [Calculatrice Java](../samples/java/calculator/README.md)  
- [Calculatrice .Net](../../../../03-GettingStarted/samples/csharp)  
- [Calculatrice JavaScript](../samples/javascript/README.md)  
- [Calculatrice TypeScript](../samples/typescript/README.md)  
- [Calculatrice Python](../../../../03-GettingStarted/samples/python)  

## Exercice

Créez un serveur MCP simple avec un outil de votre choix :  
1. Implémentez l’outil dans votre langage préféré (.NET, Java, Python ou JavaScript).  
2. Définissez les paramètres d’entrée et les valeurs de retour.  
3. Lancez l’outil inspecteur pour vérifier que le serveur fonctionne comme prévu.  
4. Testez l’implémentation avec différentes entrées.  

## Solution

[Solution](./solution/README.md)

## Ressources supplémentaires

- [Créer des agents avec Model Context Protocol sur Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [MCP distant avec Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [Agent MCP OpenAI .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## Et après ?

Suivant : [Prise en main des clients MCP](/03-GettingStarted/02-client/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforçons d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous ne saurions être tenus responsables de tout malentendu ou mauvaise interprétation résultant de l’utilisation de cette traduction.