<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T16:51:42+00:00",
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

### -6- Code final

Ajoutons le dernier morceau de code nécessaire pour que le serveur puisse démarrer :

### -7- Tester le serveur

Démarrez le serveur avec la commande suivante :

### -8- Lancer avec l’inspecteur

L’inspecteur est un excellent outil qui peut démarrer votre serveur et vous permettre d’interagir avec lui pour tester son fonctionnement. Démarrons-le :

> [!NOTE]
> il se peut que le champ « commande » affiche une commande différente selon votre runtime spécifique

Vous devriez voir l’interface utilisateur suivante :

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.fr.png)

1. Connectez-vous au serveur en sélectionnant le bouton Connect  
   Une fois connecté, vous devriez voir ceci :

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.fr.png)

2. Sélectionnez « Tools » puis « listTools », vous verrez apparaître « Add », sélectionnez-le et renseignez les valeurs des paramètres.

   Vous devriez obtenir la réponse suivante, c’est-à-dire un résultat de l’outil « add » :

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.fr.png)

Félicitations, vous avez réussi à créer et exécuter votre premier serveur !

### SDK officiels

MCP propose des SDK officiels pour plusieurs langages :  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Maintenu en collaboration avec Microsoft  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Maintenu en collaboration avec Spring AI  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implémentation officielle en TypeScript  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implémentation officielle en Python  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implémentation officielle en Kotlin  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Maintenu en collaboration avec Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implémentation officielle en Rust  

## Points clés à retenir

- La mise en place d’un environnement de développement MCP est simple grâce aux SDK spécifiques à chaque langage  
- Construire des serveurs MCP implique de créer et d’enregistrer des outils avec des schémas clairs  
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
3. Lancez l’outil inspecteur pour vérifier que le serveur fonctionne comme prévu.  
4. Testez l’implémentation avec différentes entrées.  

## Solution

[Solution](./solution/README.md)  

## Ressources supplémentaires

- [Dépôt GitHub MCP](https://github.com/microsoft/mcp-for-beginners)  

## Et après ?

Suivant : [Premiers pas avec les clients MCP](/03-GettingStarted/02-client/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforçons d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue native doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle humaine est recommandée. Nous ne sommes pas responsables des malentendus ou interprétations erronées résultant de l’utilisation de cette traduction.